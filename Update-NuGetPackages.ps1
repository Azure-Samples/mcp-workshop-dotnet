$projects = Get-ChildItem -Path *.csproj -Recurse
$projects | ForEach-Object {
    $directory = $_.Directory.FullName
    $packages = dotnet list $directory package --format json | ConvertFrom-Json
    $packages.projects[0].frameworks[0].topLevelPackages | ForEach-Object {
        $packageId = $_.id
        dotnet add $directory package $packageId
    }
}