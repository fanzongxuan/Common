rem build
dotnet build DNIC.sln -c Release
cd %cd%\nuget
rem clear old nuget packages
for %%i in (*.nupkg) do del /q/a/f/s %%i
rem create nuget packages
nuget pack DNIC.Common.nuspec
rem upload nuget packages
for %%i in (*.nupkg) do nuget push %%i -Source http://zlzforever.6655.la:40001/nuget
cd ..
