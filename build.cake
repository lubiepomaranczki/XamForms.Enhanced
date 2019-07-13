#tool vswhere
#tool GitVersion.CommandLine
#addin Cake.Figlet
#addin nuget:?package=Cake.Plist
#addin nuget:?package=Cake.Git&version=0.19.0

var sln = new FilePath("./XamForms.Enhanced.sln");
var iOSProj = new FilePath("./iOS/XamForms.Enhanced.iOS.csproj");
var droidProj = new FilePath("./Droid/XamForms.Enhanced.Droid.csproj");
var coreProj = new FilePath("./XamForms.Enhanced.Abstractions/XamForms.Enhanced.csproj");
var target = Argument("target", "Any CPU");
var configuration = Argument("configuration", "Release");
var verbosityArg = Argument("verbosity", "Minimal");
var prereleaseTools = Argument<bool>("prereleasetools", false);
var verbosity = Verbosity.Minimal;
var outputDirArgument = Argument("outputDir", "./artifacts");
var outputDir = new DirectoryPath(outputDirArgument);
var gitVersionLog = new FilePath("./gitversion.log");

// Azure DevOps release note args
var azureDevOpsApiKey = Argument("azureDevOpsApiKey", "");

GitVersion versionInfo = null;

Setup(context =>
{
    versionInfo = context.GitVersion(new GitVersionSettings {
        UpdateAssemblyInfo = true,
        OutputType = GitVersionOutput.Json,
        LogFilePath = gitVersionLog
    });

    var cakeVersion = typeof(ICakeContext).Assembly.GetName().Version.ToString();

    Information(Figlet("XamForms.Enhanced"));
    Information("Building version {0} {1}, ({2}, {3}) using version {4} of Cake.",
        versionInfo.SemVer,
        versionInfo.BuildMetaData,
        configuration,
        target,
        cakeVersion);

    verbosity = Verbosity.Normal; //(Verbosity) Enum.Parse(typeof(Verbosity), verbosityArg, true);
});

Task("Clean")
    .Does(() =>
{    
    CleanDirectories("./**/bin");
    CleanDirectories("./**/obj");
    
    CleanDirectory(outputDir.FullPath);

    EnsureDirectoryExists(outputDir);

    MoveFileToDirectory(gitVersionLog, outputDir);
    
});

Task("CleanUntracked")
    .IsDependentOn("Clean")
    .Does(() =>
{
    var repoPath = MakeAbsolute(new DirectoryPath("./"));
    Information("Cleaning untracked files in: {0}", repoPath.FullPath.ToString());
    GitClean(repoPath);
});

FilePath msBuildPath;
Task("ResolveBuildTools")
    .WithCriteria(() => IsRunningOnWindows())
    .Does(() =>
{
    var vsWhereSettings = new VSWhereLatestSettings
    {
        IncludePrerelease = prereleaseTools,
        Requires = "Component.Xamarin"
    };

    var vsLatest = VSWhereLatest(vsWhereSettings);
    msBuildPath = (vsLatest == null)
        ? null
        : vsLatest.CombineWithFilePath("./MSBuild/Current/Bin/MSBuild.exe");

    if (msBuildPath != null)
        Information("Found MSBuild at {0}", msBuildPath.ToString());
});

Task("RestorePackages")
    .IsDependentOn("ResolveBuildTools")
    .Does(() =>
{
    var settings = GetDefaultBuildSettings()
        .WithTarget("Restore");
    MSBuild(sln, settings);
});

Task("BuildAndroid")
    .IsDependentOn("Clean")
    .IsDependentOn("ResolveBuildTools")
    .IsDependentOn("RestorePackages")
    .IsDependentOn("Build")
    .Does(() =>
{  
    var settings = GetDefaultBuildSettings()
        .WithProperty("Version", versionInfo.SemVer)
        .WithProperty("PackageVersion", versionInfo.SemVer)
        .WithProperty("InformationalVersion", versionInfo.InformationalVersion)
        .WithTarget("Build");

    MSBuild(iOSProj, settings);
});

Task("BuildiOS")
    .IsDependentOn("Clean")
    .IsDependentOn("ResolveBuildTools")
    .IsDependentOn("RestorePackages")
    .IsDependentOn("Build")
    .Does(() =>
{
    var settings = GetDefaultBuildSettings()
        .WithProperty("Version", versionInfo.SemVer)
        .WithProperty("PackageVersion", versionInfo.SemVer)
        .WithProperty("InformationalVersion", versionInfo.InformationalVersion)
        .WithTarget("Build");

    MSBuild(iOSProj, settings);
});

Task("Build")
    .IsDependentOn("Clean")
    .IsDependentOn("ResolveBuildTools")
    .IsDependentOn("RestorePackages")
    .Does(() =>
{
    var settings = GetDefaultBuildSettings()
        .WithProperty("Version", versionInfo.SemVer)
        .WithProperty("PackageVersion", versionInfo.SemVer)
        .WithProperty("InformationalVersion", versionInfo.InformationalVersion)
        .WithTarget("Build");

    MSBuild(coreProj, settings);
});

Task("CopyPackages")
    .IsDependentOn("Build")
    .Does(() => 
{
    var nugetFiles = GetFiles("./*/**/bin/" + configuration + "/**/*.nupkg");
    CopyFiles(nugetFiles, outputDir);
});

Task("ExportDsym")
    .Does(async () => 
{
});

RunTarget(target);

MSBuildSettings GetDefaultBuildSettings()
{
    var settings = new MSBuildSettings
    {
        Configuration = configuration,
        ToolPath = msBuildPath,
        Verbosity = verbosity,
        ArgumentCustomization = args => args.Append("/m"),
        ToolVersion = MSBuildToolVersion.VS2019
    };

    return settings;
}