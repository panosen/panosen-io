@echo off

dotnet restore

dotnet build --no-restore -c Release

move /Y Panosen.IO\bin\Release\Panosen.IO.*.nupkg D:\LocalSavoryNuget\

pause