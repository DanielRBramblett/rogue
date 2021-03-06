# R.O.G.U.E
**R**eal-time **O**pen-source **G**ame **U**sing **E**ntities

Descend into a dark dungeon filled with fearsome foes. Your torch reveals the twisting passageways and rooms of the procedurally generated map. Battle gruesome goblins, pathfinding raptors with x-ray vision, and invisible ninjas as you search for the key to unlock the door to the ultimate boss. Only the most fleet-fingered will live to tell the tale!

Gameplay video: https://youtu.be/WOM-geJYmXc

Travis CI [![Build Status](https://travis-ci.org/bgoldbeck/rogue.svg?branch=master)](https://travis-ci.org/bgoldbeck/rogue)

## Copyright ##
Copyright (C) 2018 "Daniel Bramblett" <code>&lt;bram4@pdx.edu&gt;</code>, "Daniel Dupriest" <code>&lt;kououken@gmail.com&gt;</code>, "Brandon Goldbeck" <code>&lt;bpg@pdx.edu&gt;</code>
  
## Contact Us ##
Daniel Bramblett: daniel.r.bramblett@gmail.com or bram4@pdx.edu <br />
Daniel Dupriest: kououken@gmail.com <br />
Brandon Goldbeck: bpg@pdx.edu

## Bug Tracker ##
https://github.com/bgoldbeck/rogue/issues

## What is this repository for? ##

* This repository contains the term project for CS461P Open Source Software development with professor Bart Massey.

## Setting up for Development ##

### Windows ###

The software is set up as a Visual Studio 2017 solution.

1. Clone the project. `git clone https://github.com/bgoldbeck/rogue.git`
2. Download and install Visual Studio 2017. [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/)
3. Download and install .NET Core app SDK 2.1 from Microsoft. [.NET Core SDK 2.1](https://www.microsoft.com/net/download/dotnet-core/sdk-2.1.300)
4. Open the solution `.sln` file in Visual Studio 2017.
5. Run the project with `F5`.

To build an executable for 64bit Windows 10:

1. In a terminal, navigate to the project folder then run `dotnet publish -c Release -r win10-x64`.
2. The release files will be generated in `..\rogue\bin\Release\netcoreapp2.1\win10-x64`.
3. The `publish` directory contents are not needed.

### Linux ###

1. Clone the project. `git clone https://github.com/bgoldbeck/rogue.git`
2. Download and install Visual Studio Code. [Visual Studio Code](https://code.visualstudio.com/)
3. Download and install .NET Core app SDK 2.1 from Microsoft. [.NET Core SDK 2.1](https://www.microsoft.com/net/download/dotnet-core/sdk-2.1.300) Instructions for your distribution may vary.
4. Launch Visual Studio Code.
5. Open the project folder from VS Code and select View > Extensions.
  1. Install "C# for visual studio code" extension.
  2. Install "C# FixFormat" extension.
  3. Install "C# Extensions" extension.
  4. Install "C# XML Documentation Comments" extension.
  5. Install NuGet package Manager extension.
6. Open the terminal in Visual Studio Code "Ctrl + tilde" and type `dotnet run` to run the application.
7. Run tests with `dotnet test`.

# License

This work is licensed under the MIT license. See LICENSE for full text.
