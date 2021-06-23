using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

[CheckBuildProjectConfigurations]
[ShutdownDotNetAfterServerBuild]
class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode

    public static int Main () => Execute<Build>(x => x.Compile);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;
    [Parameter] string MyApiKey;

    [Solution] readonly Solution Solution;
    [GitRepository] readonly GitRepository GitRepository;
    [GitVersion] readonly GitVersion GitVersion;

    AbsolutePath SourceDirectory => RootDirectory / "source";
    AbsolutePath TestsDirectory => RootDirectory / "tests";
    AbsolutePath OutputDirectory => RootDirectory / "output";

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            SourceDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
            TestsDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
            EnsureCleanDirectory(OutputDirectory);
        });

    Target Restore => _ => _
        .Executes(() =>
        {
            DotNetRestore(s => s
                .SetProjectFile(Solution));
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            Logger.Info("Hello world");
            //DotNetBuild(s => s
            //    .SetProjectFile(Solution)
            //    .SetConfiguration(Configuration)
            //    .SetAssemblyVersion(GitVersion.AssemblySemVer)
            //    .SetFileVersion(GitVersion.AssemblySemFileVer)
            //    .SetInformationalVersion(GitVersion.InformationalVersion)
            //    .EnableNoRestore());
            DotNetBuild(s => s
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
                .EnableNoRestore());
        });

    Target Test => _ => _
      .DependsOn(Compile)
      .Executes(() =>
      {
          DotNetTest(s => s
              .SetOutput(OutputDirectory / "Test")
              .SetProjectFile(Solution)
              .SetConfiguration(Configuration)
              .EnableNoRestore()
              .EnableNoBuild());
      });
    static string GlobalToolName => "WenUI/WenUI";
    Target Pack => _ => _
        .DependsOn(Test)
        .Executes(() =>
        {
            DotNetPack(s => s
                .SetProject(Solution)
                //.SetProject(RootDirectory /$"{GlobalToolName}.fsproj")
                .SetAuthors("YiDong Zhu")
                //.SetProject(Solution.GetProject("Nuke.Sample"))
                .SetIncludeSymbols(true)
                .SetConfiguration(Configuration)
                .EnableNoRestore()
                .EnableNoBuild()
                .SetOutputDirectory(OutputDirectory / "package"));
        });

    string PackagesDirectory => OutputDirectory / "package";
    Target Push => _ => _
       .DependsOn(Pack)
       .Requires(() => MyApiKey) //Configuration.Equals(Configuration.Release))
       .Executes(() =>
       {
           var packages = GlobFiles(PackagesDirectory, ".nupkg");
           foreach (var package in packages)
           {
               DotNetNuGetPush(s => s
                      .SetTargetPath(package)
                      .SetSource("https://www.myget.org/F/nuke/api/v1 ")
                      .SetApiKey(MyApiKey)

               );
           }
       });
}
