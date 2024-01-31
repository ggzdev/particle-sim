@echo off

dotnet publish -c Release -r win-x64 --self-contained
dotnet publish -c Release -r win-x86 --self-contained