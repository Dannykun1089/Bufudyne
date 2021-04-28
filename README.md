# Bufudyne
A small winforms app for downloading albums/tracks off of BandCamp.com

__Please note this app only works on windows__

## Installing from releases (Use this if not sure what to do)

* Go to this page's releases section, find the most recent .exe
* This exe is a self extracting archive which will create a folder called "Bufudyne" in the directory where you specified
* In this folder contains the executable, all necessary DLLs, and the latest regex patterns JSON file
* The program depends on the DLL files and the regex_patterns.json file
* Launch bufudyne.exe to start the program

## Installing from source (For people paranoid about using premade binaries)

* Download the necessary tools needed to compile via the visual studio installer (C# Support, .NET Support, Winforms, etc, should just all be under one package)
* Download all the source files and open the solution (.sln) file with MS visual studio 
* Build from there
* Place the regex_patterns.json file in the directory of the compiled executable (this file is needed to find the correct parts in the HTML and doesn't function without it)
* And run from there

## On the regex patterns file

regex_patterns.json contains 2 key pairs, one for finding the relative track URLs within the album HTML page, and another for finding the audio URL within a track page. This is done so in case of a site-change, new patterns can be made and the app can work again by changing this text file instead of writing more code and needing a new update.

## Credits
Big thanks to my mate B00 for alowing me to use a vectorized version of his art as the icon for this program, and for giving me the idea in the first place. Love ya man <3
