#properties ---------------------------------------------------------------------------------------------------------

properties {
    $base_dir = resolve-path .
    $build_dir = "$base_dir\Builds"
    $source_dir = "$base_dir\Source"
    $tools_dir = "$base_dir\Tools"
}

#tasks -------------------------------------------------------------------------------------------------------------

task default -depends build

task clean {
    "Cleaning SignalR.Castle.Windsor bin and obj directories"
    delete_directory "$source_dir\SignalR.Castle.Windsor\bin"
    delete_directory "$source_dir\SignalR.Castle.Windsor\obj"

    "Cleaning SignalR.Castle.Windsor.Sample bin and obj directories"
    delete_directory "$source_dir\SignalR.Castle.Windsor.Sample\bin"
    delete_directory "$source_dir\SignalR.Castle.Windsor.Sample\obj"
}

task build -depends clean {
    "Building SignalR.Castle.Windsor.sln"
    exec { msbuild $source_dir\SignalR.Castle.Windsor.sln /p:Configuration=Release }
}

task package -depends build {
    "Creating SignalR.Castle.Windsor.nupkg"
    exec { & $tools_dir\NuGet.CommandLine.2.1.0\tools\nuget.exe pack $source_dir\SignalR.Castle.Windsor\Package.nuspec -OutputDirectory $build_dir }

    "Creating SignalR.Castle.Windsor.Sample.nupkg"
    exec { & $tools_dir\NuGet.CommandLine.2.1.0\tools\nuget.exe pack $source_dir\SignalR.Castle.Windsor.Sample\Package.nuspec -OutputDirectory $build_dir }
}

task publish {
    "Publishing SignalR.Castle.Windsor.nupkg"
    $apiKey = Read-Host 'Enter your API key: '
    $version = Read-Host 'Enter the number of the version you want to pubilsh: '
    exec { & $tools_dir\NuGet.CommandLine.2.1.0\tools\nuget.exe push $build_dir\SignalR.Castle.Windsor.$version.nupkg $apiKey }
}

#functions ---------------------------------------------------------------------------------------------------------

function global:delete_directory($directory_name) {
    rd $directory_name -recurse -force -ErrorAction SilentlyContinue | out-null
}