#tool nuget:?package=NUnit.ConsoleRunner&version=3.4.0
#addin nuget:?package=Cake.Coverlet&version=2.2.1
#tool nuget:?package=ReportGenerator&version=4.0.15
#tool nuget:?package=MSBuild.SonarQube.Runner.Tool&version=4.3.1
#addin nuget:?package=Cake.Sonar&version=1.1.18

var target = Argument("target", "Default");
var sonarLogin = Argument("sonarLogin", "");
var coverageFolder = Directory(System.IO.Directory.GetCurrentDirectory()) + Directory("coverage-results");
var src = Directory("./src");

Task("Clean").Does(() => DotNetCoreClean("src"));

Task("Restore").Does(() => DotNetCoreRestore("src"));

Task("Build")    
    .IsDependentOn("Clean")
    .Does(() =>
    {
        var settings = new DotNetCoreBuildSettings 
        {
             Configuration = "Debug",
             ArgumentCustomization = arg => arg.AppendSwitch("/p:DebugType","=","Full")
        };
        
        DotNetCoreBuild("src", settings);
    });

Task("Test")
    .IsDependentOn("Build")
    .Does(() => 
    {
        CleanDirectory(coverageFolder);

        var testSettings = new DotNetCoreTestSettings 
        {
            ArgumentCustomization = args => args.Append($"--logger trx")
        };

        var coverletSettings = new CoverletSettings 
        {
            CollectCoverage = true,            
            CoverletOutputName = "coverage",
            CoverletOutputDirectory = "./coverage-results",
            Exclude = {"[xunit.*]*"},
            Threshold = 100
        };

        var testProjects = GetFiles(src.Path.FullPath + "/**/*Test.csproj");
        var jsonResult = coverageFolder.Path.FullPath + "/coverage.json";

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
    .IsDependentOn("Test")
    .Does(() => ReportGenerator("./coverage-results/opencover-coverage.xml", "./coverage-results/report/"));

Task("SonarBegin")
  .Does(() => 
  {
     SonarBegin(
        new SonarBeginSettings 
        {
            Key = "maiconheck_krafted",
            Organization = "maiconheck-github",
            Url = "https://sonarcloud.io",
            Login = sonarLogin,
            ArgumentCustomization = args => args.Append($"/d:sonar.cs.opencover.reportsPaths=./coverage-results/opencover-coverage.xml")
        });
  });

Task("SonarEnd").Does(() => SonarEnd(new SonarEndSettings { Login = sonarLogin }));

Task("Sonar")
  .IsDependentOn("SonarBegin")
  .IsDependentOn("Clean")
  .IsDependentOn("Build")
  .IsDependentOn("Coverage")
  .IsDependentOn("SonarEnd");

Task("CleanPackage").Does(() => CleanDirectory("./packages"));

Task("Pack")
    .IsDependentOn("Clean")
    .IsDependentOn("CleanPackage")
    .Does(() => 
    {
        var settings = new DotNetCoreBuildSettings { Configuration = "Release" };
        DotNetCoreBuild("src", settings);
    });

Task("SetupEnv").Does(() => CopyFile("pre-push", "./.git/hooks/pre-push"));

Task("Default")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .IsDependentOn("Build")
    .IsDependentOn("Test")
    .IsDependentOn("Coverage")
    .Does(() => { 
});

RunTarget(target);