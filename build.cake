#tool nuget:?package=NUnit.ConsoleRunner&version=3.11.1
#addin nuget:?package=Cake.Coverlet&version=2.4.2
#tool nuget:?package=ReportGenerator&version=4.6.1
#tool nuget:?package=MSBuild.SonarQube.Runner.Tool&version=4.8.0
#addin nuget:?package=Cake.Sonar&version=1.1.25

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var sonarLogin = Argument("sonarLogin", "");

var srcPath = Directory("./src");
var slnPath = $"{srcPath}/Krafted.sln";
var coveragePath = Directory("./coverage-results");

#region CI

Task("Clean")
    .Description("Cleans the output of a project.")
    .Does(() =>
    {
        var settings = new DotNetCoreCleanSettings { OutputDirectory = "./artifacts/" };
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

Task("SonarEnd")
    .Does(() => SonarEnd(new SonarEndSettings { Login = sonarLogin }));

Task("Sonar")
  .Description("Run Sonar code analyzers and send the result to Sonar Cloud.")
  .IsDependentOn("SonarBegin")
  .IsDependentOn("Clean")
  .IsDependentOn("Build")
  .IsDependentOn("Coverage")
  .IsDependentOn("SonarEnd");

#endregion

#region  Nuget

Task("CleanPackage")
    .Description("Clears the output folder of nuget packages.")
    .Does(() => CleanDirectory("./packages"));

Task("Pack")
    .Description("Generates the nuget packages.")
    .IsDependentOn("Clean")
    .IsDependentOn("CleanPackage")
    .Does(() =>
    {
        var settings = new DotNetCorePackSettings
        {
            Configuration = configuration,
            OutputDirectory = "./packages",
            IncludeSymbols = true,
            IncludeSource = true,
            NoBuild = false
        };

        DotNetCorePack(slnPath, settings);
    });

#endregion

Task("Default")
    .Description("Run the CI pipeline: Clean, Restore, Build, Test, and Coverage tasks, in that order.")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .IsDependentOn("Build")
    .IsDependentOn("Test")
    .IsDependentOn("Coverage")
    .Does(() => {
});

RunTarget(target);
