#!/bin/bash

msbuild /t:Clean
msbuild /t:restore XamForms.Enhanced.sln
msbuild /t:rebuild XamForms.Enhanced.Abstractions/XamForms.Enhanced.csproj  /property:Configuration=Release
msbuild /t:rebuild iOS/XamForms.Enhanced.iOS.csproj  /property:Configuration=Release
msbuild /t:rebuild Droid/XamForms.Enhanced.Droid.csproj  /property:Configuration=Release
nuget pack XamForms.Enhanced.nuspec 

tput bel
