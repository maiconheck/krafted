#tool nuget:?package=NUnit.ConsoleRunner&version=3.11.1
#addin nuget:?package=Cake.Coverlet&version=2.4.2
#tool nuget:?package=ReportGenerator&version=4.6.1
#tool nuget:?package=MSBuild.SonarQube.Runner.Tool&version=4.8.0
#addin nuget:?package=Cake.Sonar&version=1.1.25

var target = Argument("target", "CI");
var configuration = Argument("configuration", "Release");
var sonarLogin = Argument("sonarLogin", "");
var apiKey = Argument("apiKey", "");

var srcPath = Directory("./src");
var slnPath = $"{srcPath}/Krafted.sln";
var coveragePath = Directory("./coverage-results");
var artifactsPath = Directory("./artifacts");

#region CI

Task("Clean")
    .Description("Cleans the output of a project.")
    .Does(() =>
    {
        var settings = new DotNetCoreCleanSettings { OutputDirectory = artifactsPath };
        DotNetCoreClean(slnPath, settings);
    });

Task("Restore")
    .Description("Restores the dependencies and tools of a project.")
    .Does(() => DotNetCoreRestore(slnPath));

Task("Build")
    .Description("Clean / Restore / Build a project and all of its dependencies.")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .Does(() =>
    {
        var settings = new DotNetCoreBuildSettings
        {
             Configuration = configuration,
             NoRestore = true
        };

        DotNetCoreBuild(slnPath, settings);
    });

Task("Test")
    .Description("Executes all unit / integration tests on the solution.")
    .IsDependentOn("Build")
    .Does(() =>
    {
        CleanDirectory(coveragePath);

        var testSettings = new DotNetCoreTestSettings
        {
            ArgumentCustomization = args => args.Append($"--logger trx"),
            NoRestore = true
        };

        var coverletSettings = new CoverletSettings
        {
            CollectCoverage = true,
            CoverletOutputName = "coverage",
            CoverletOutputDirectory = coveragePath,
            Exclude = {"[xunit.*]*,[*]*.Texts"},
            //Threshold = 100
        };

        // TODO: Krafted.IntegrationTest disabled to replacement DB with docker
        //var testProjects = GetFiles($"{srcPath}/**/*Test.csproj");
        var testProjects = GetFiles($"{srcPath}/Krafted.UnitTest/Krafted.UnitTest.csproj");
        var jsonResult = $"{coveragePath}/coverage.json";

        foreach(var project in testProjects)
        {
            string projectPath = MakeAbsolute(project).ToString();

            if(project != testProjects.First())
            {
                coverletSettings.MergeWithFile = jsonResult;
            }

            if (project == testProjects.Last())
            {
                coverletSettings.CoverletOutputFormat = CoverletOutputFormat.opencover;
                coverletSettings.CoverletOutputName = "opencover-coverage.xml";
            }

            DotNetCoreTest(projectPath, testSettings, coverletSettings);
        }
    });

Task("Coverage")
    .Description("Calculates and generates a code coverage report.")
    .IsDependentOn("Test")
    .Does(() => ReportGenerator($"./{coveragePath}/opencover-coverage.xml", $"./{coveragePath}/report/"));


#endregion

#region CD

Task("Package")
    .Description("Generates the nuget packages.")
    .IsDependentOn("Coverage")
    .Does(() =>
    {
        // var version = GetPackageVersion();

        var settings = new DotNetCorePackSettings
        {
            Configuration = configuration,
            OutputDirectory = artifactsPath,
            IncludeSymbols = true,
            IncludeSource = true,
            NoBuild = false
        };

        DotNetCorePack(slnPath, settings);
    });

Task("Publish")
    .Description("Pushes the packages to the server and publishes them.")
    .IsDependentOn("Package")
    .Does(() =>
    {
        var packages = GetFiles($"./{artifactsPath}/*.nupkg");

        NuGetPush(packages, new NuGetPushSettings
        {
            Source = "https://nuget.pkg.github.com/maiconheck/index.json",
            ApiKey = apiKey
        });
    });

#endregion

#region Sonar

Task("SonarBegin")
  .Does(() =>
  {
     SonarBegin(
        new SonarBeginSettings
        {
            Key = "key",
            Organization = "organization",
            Url = "https://sonarcloud.io",
            Login = sonarLogin,
            ArgumentCustomization = args => args.Append($"/d:sonar.cs.opencover.reportsPaths=./{coveragePath}/opencover-coverage.xml")
        });
  });

Task("SonarEnd").Does(() => SonarEnd(new SonarEndSettings { Login = sonarLogin }));

Task("Sonar")
  .Description("Run Sonar code analyzers and send the result to Sonar Cloud.")
  .IsDependentOn("SonarBegin")
  .IsDependentOn("Clean")
  .IsDependentOn("Build")
  .IsDependentOn("Coverage")
  .IsDependentOn("SonarEnd");

#endregion

Task("CI")
    .Description("Run the CI pipeline: Clean, Restore, Build, Code Quality Analysis, Test, and Coverage tasks, in that order.")
    .IsDependentOn("Coverage");

Task("CD")
    .Description("Run the CD pipeline: Clean, Restore, Build, Code Quality Analysis, Test, Coverage, Package and Publish tasks, in that order.")
    .IsDependentOn("Publish");

RunTarget(target);

