var target = Argument("target", "ExecuteBuild");
var configuration = Argument("configuration", "Release");
var solutionFolder ="./";
var outputFolder= "./salidaFichero";
var myLibraryOutputFolder = "./salidaFichero/swagger";
var myLibraryFolder = "./Swagger";
var databaseRuntime = Argument("databaseRuntime", "win-x64");
var prerelease = Argument("prerelease", "");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory(outputFolder);
    CleanDirectory(myLibraryOutputFolder);
});

Task("Restore")
    .Does(()=>{
        DotNetCoreRestore(solutionFolder);
        DotNetCoreRestore(myLibraryFolder);
    });

Task("Build")
    .IsDependentOn("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
{
    DotNetCoreBuild(solutionFolder, new DotNetCoreBuildSettings
    {
        NoRestore = true,
        Configuration = configuration,
    });
});

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
{
    DotNetCoreTest(solutionFolder, new DotNetCoreTestSettings
    {
        NoRestore =true,
        Configuration = configuration,
        NoBuild = true,
    });
});
Task("Publish")
    .IsDependentOn("Test")
    .Does(()=>{
        DotNetCorePublish(solutionFolder, new DotNetCorePublishSettings{
            NoRestore=true,
            Configuration = configuration,
            NoBuild= true,
            OutputDirectory=outputFolder           
        });

    });



//.....................................................................................
//......................      Genera cada Archivo       ...............................
//.....................................................................................


class ProjectInformation
{
    public string Name { get; set; }
    public string FullPath { get; set; }
    public string Runtime { get; set; }
    public bool IsTestProject { get; set; }
}

List<ProjectInformation> projects;
Setup(context =>
{
    if (BuildSystem.IsLocalBuild && string.IsNullOrEmpty(prerelease))
    {
        prerelease = "-local";
    }
   

    foreach( var dir in GetSubDirectories(solutionFolder))
    {   
        if (FileExists(dir.ToString()+"/Properties/launchSettings.json"))
        {
            Information("File exists!"+ dir.ToString());
            projects = GetFiles(solutionFolder+"**/*.csproj").Select(p => new ProjectInformation
            {
                Name = p.GetFilenameWithoutExtension().ToString(),
                FullPath = p.GetDirectory().FullPath,
                Runtime = p.GetFilenameWithoutExtension().ToString() == "OctopusSamples.OctoPetShop.Database" ? databaseRuntime : null,
                IsTestProject = p.GetFilenameWithoutExtension().ToString().EndsWith(".Tests"),
            }).ToList();
        }
    }
});

Task("CleanEach")
    .Does(() =>
        {
            CleanDirectory(outputFolder);
            var cleanSettings = new DotNetCoreCleanSettings { Configuration = configuration };
            foreach(var project in projects)
            {
                DotNetCoreClean(project.FullPath, cleanSettings);
            }
        });
Task("RestoreEach")
    .Does(()=>{
        DotNetCoreRestore(solutionFolder);
        //var restoreSettings = new DotNetCoreRestoreSettings { Configuration = configuration };
        foreach(var project in projects)
        {
            DotNetCoreRestore(project.FullPath);
        }
    });


Task("BuildEach")
    .IsDependentOn("CleanEach")
    //.IsDependentOn("RestoreEach")
    .Does(() =>
    {
        foreach(var project in projects)
        {
            var buildSettings = new DotNetCoreBuildSettings()
                {
                    Configuration = configuration,
                    NoRestore = true
                };
            //if (!string.IsNullOrEmpty(project.Runtime))
            //{
            //    buildSettings.Runtime = project.Runtime;
            //}
            DotNetCoreBuild(project.FullPath, buildSettings);
            //DotNetCoreTest(project.FullPath, new DotNetCoreTestSettings { Configuration = configuration });
            DotNetCorePublish(project.FullPath, new DotNetCorePublishSettings{
                NoRestore=true,
                Configuration = configuration,
                NoBuild= true,
                OutputDirectory=outputFolder+"/"+project.Name
            });   
        }
    });




Task("ExecuteBuild")
    //.IsDependentOn("Publish")
    .IsDependentOn("BuildEach");

RunTarget(target);  



//problema Necesita borrra las capetas no necesarias.
/*
 bool esCarpetaCorrecta= false;
    dirs=GetSubDirectories(solutionFolder).Select(p => new DirectoryInformation{
        Name = p.GetDirectory().ToString(),
        FullPath=p.GetDirectory.FullPath,
    }).ToList();

    var buildDir = Directory("./src/Example/bin") + Directory(configuration);


     List<string> dirs = new List<string>(Directory.EnumerateDirectories(solutionFolder));
    //GetFiles("Properties/*.json");




    foreach (var dir in dirs)
    {
         Console.WriteLine(dir.Name);
    }
    projects = GetFiles(".csproj").Select(p => new ProjectInformation
   /* {
        Name = p.GetFilenameWithoutExtension().ToString(),
        FullPath = p.GetDirectory().FullPath,
        Runtime = p.GetFilenameWithoutExtension().ToString() == "OctopusSamples.OctoPetShop.Database" ? databaseRuntime : null,
        IsTestProject = p.GetFilenameWithoutExtension().ToString().EndsWith(".Tests"),
    }).ToList();*/
