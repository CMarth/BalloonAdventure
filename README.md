# BalloonAdventure

XNA + C# project, 2012

College project | Videogames 1 class | UANL FCFM

Programmers/Artists

-M. C. Perez-Ayala Cano

-Brenda Joo Lara

-Luis Carlos Garcia Cantu

Composer

-Erik Herrera

---------------------------------------------------------------------------------------------------------------------

#How to play

-Movement keys:

~~ W - up

~~ A - back/left

~~ S - down

~~ D - font/right

~~ Q - select

~~ E - select exit (should probably just change for Q wtf)

---------------------------------------------------------------------------------------------------------------------

#File Structure

Main folder is divided into two categories:

-SwordfishAI

~~The main folder contains the core programming. Classes found here are the main class and the subclasses for the AI, PC movement, Background, controls, etc.

~~The bin folder, if explored to bin>x86>Debug, contains an executable file which can be used to try the game without opening it in VisualStudio. It's called SwordfishAI.exe. It also contains a copy of the content folder to run this exe on, as well as the app.publish folder, which has the files needed for an installation for the game.

~~One can find similar content in the obj folder. The properties folder holds the assemblyinfo file.

-SwordfishAIContent

~~The main folder holds the font file as well as the file that links the content to the project

~~Background - Contains BG image files, divided in four equal parts, for all three levels. These are also in their alpha stage.

~~BGM - Contains the music files for the game. All except Native Son were composed by the group.

~~The bin folder is empty other than various folders akin to the bin folder in the SwordfishAI folder.

~~img - Contains the alpha sprites used for the game, as well as other images needed (start screen, etc)

~~The obj folder holds some copy files akin to the obj folder found in SwordfishAI folder

~~Video - holds the alpha ending credits video


---------------------------------------------------------------------------------------------------------------------

#To-Do List

-Smoothen transition between still and moving sprite so it doesn't push itself forward due to different sprite lenghts

-Add item drop mechanic to increase lives

-Finish Final Boss

-Finalize sprites (Currently in alpha stage)

#Current bugs

::Most show only after extensive gameplay::

-Octopus enemy sometimes fails to kill

-Boss sometimes does not come out after extended play

-Background suddenly repeated itself without cycling to the next bg file

-Sometimes just phases through turtle enemy

-Airplane enemy hitbox has errors

-smoothen learning curve

-some homing enemies fail to notice the balloon if you stick to the top

-When dying you stay in the same spot, can die again pretty easily. Add invinsibility moment
