rem build
dotnet build DNIC.sln -c Release
cd %cd%\nuget
rem clear old nuget packages
for %%i in (*.nupkg) do del /q/a/f/s %%i
rem create nuget packages
nuget pack DNIC.Common.nuspec
rem upload nuget packages
for %%i in (*.nupkg) do nuget push %%i -Source https://www.nuget.org/api/v2/package
cd ..
