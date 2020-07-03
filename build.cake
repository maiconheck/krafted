#tool nuget:?package=NUnit.ConsoleRunner&version=3.11.1
#tool nuget:?package=nuget.commandline&version=5.5.1
#tool nuget:?package=ReportGenerator&version=4.6.1

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Debug");

var srcPath = Directory("./src");
var slnPath = $"{srcPath}/Krafted.sln";
var artifactsPath = Directory("./artifacts");

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
             NoRestore = true,
             MSBuildSettings = new DotNetCoreMSBuildSettings
             {
                TreatAllWarningsAs = MSBuildTreatAllWarningsAs.Error
             }
        };

        DotNetCoreBuild(slnPath, settings);
    });

Task("Test")
    .Description("Executes all unit / integration tests on the solution.")
    .IsDependentOn("Build")
    .Does(() =>
    {
        var settings = new DotNetCoreTestSettings { NoRestore = true };
        DotNetCoreTest(slnPath, settings);
    });

Task("Default")
    .Description("Run Clean, Restore, Build and Test tasks, in that order.")
    .IsDependentOn("Test");

RunTarget(target);
