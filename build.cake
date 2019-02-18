#tool nuget:?package=NUnit.ConsoleRunner&version=3.4.0

var target = Argument("target", "Default");

Task("Clean")
    .Does(() => { DotNetCoreClean("src"); });

Task("Restore")
    .Does(() => { DotNetCoreRestore("src"); });

Task("Build")    
    .Does(() =>
    {
        var settings = new DotNetCoreBuildSettings { Configuration = "Debug" };
        DotNetCoreBuild("src", settings);
    });

Task("Test")
    .Does(() => { DotNetCoreTest("src"); });

Task("Default")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .IsDependentOn("Build")
    .IsDependentOn("Test")
    .Does(() => { 
});

RunTarget(target);