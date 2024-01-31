# particle-sim
Small particle simulator inspired by CodeMaker_4. rewritten in C#

# About & Usage
Particle Simulator - Version 0.0.1 alpha
developed and remade in C# by: ggzdev

:: original idea by: CodeMaker_4 (YT: https://www.youtube.com/@CodeMaker4)


--> There is a pre-compiled version with the standart window settings in the ZIP folder as a .tar, a .7z and a .zip file.
--> If you want to change the window settings you have to recompile the program.

How to reccompile:

(If you have'nt already): Install the .NET 8.0 SDK or Visual Studio with the C# development kit
--> verify the correct installation of the c# compiler by typing: dotnet

1. Open your folder in the terminal
2. If you type 'dir', you should see a batch file called make.bat
3. Run it by typing 'make'
4. If everything goes to plan, you should see no errors : You have now compiled the project for x32 and x64 operating systems.
--> You can find the binarys in .\bin\Release\net7.0\win-x64(or win-x86)\\particle.simulator.exe

NOTE: The project is self contained which means it runs without any additional installs such as interpreters or the .net runtime, but
all the files in the program bin folder are REQUIRED!

NOTE 2: If you want to modify the code, you have to create a new c# project:
WHEN WORKING IN VISUAL STUDIO: Create new project + copy & paste code
WHEN WORKING IN VSCODE: use cmd and type 'dotnet new console' to create a project in the current folder then copy & paste the code.
WHY? --> I cant upload the obj and bin files unfortunatly so you have to try it out for yourself.
