#tool nuget:?package=NUnit.ConsoleRunner&version=3.4.0
#addin nuget:?package=Cake.Coverlet&version=2.2.1
#tool nuget:?package=ReportGenerator&version=4.0.15
#tool nuget:?package=MSBuild.SonarQube.Runner.Tool&version=4.3.1
#addin nuget:?package=Cake.Sonar&version=1.1.18

var target = Argument("target", "Default");
var sonarLogin = Argument("sonarLogin", "");
var coveragePath = "./coverage-results/result.opencover.xml";

Task("Clean").Does(() => DotNetCoreClean("src"));

Task("Restore").Does(() => DotNetCoreRestore("src"));

Task("Build")    
    .Does(() =>
    {
        var settings = new DotNetCoreBuildSettings { Configuration = "Debug" };
        DotNetCoreBuild("src", settings);
    });

Task("Test")
    .IsDependentOn("Build")
    .Does(() => 
    {
        var testSettings = new DotNetCoreTestSettings { };

        var coverletSettings = new CoverletSettings 
        {
            CollectCoverage = true,
            CoverletOutputFormat = CoverletOutputFormat.opencover,
            CoverletOutputDirectory = Directory(@".\coverage-results\"),
            CoverletOutputName = "result",
            Exclude = {"[xunit.*]*"},
            Threshold = 100
        };

        DotNetCoreTest("src", testSettings, coverletSettings);
    });

Task("Coverage")
    .IsDependentOn("Test")
    .Does(() => ReportGenerator($"{coveragePath}", "./coverage-results/reports/"));

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
            ArgumentCustomization = args => args.Append($"/d:sonar.cs.opencover.reportsPaths={coveragePath}")
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