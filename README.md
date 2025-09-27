## Game Overview
The objective of the game is to reach the flag on the rightmost side of the game level. It is a platformer game where you win by reaching the flag, you lose by running out of lives or when your score drops to zero. There are Slot Machines located throughout the level, press 'F' while near one to activate it. It will spin for a while and then give a 'ding' sound, or a 'womp womp' sound. If it dings, then it will do one of the following: give you an extra heart, give you 2x speed for 10 seconds, or add 5 to your score. It also has a chance to explode, which deals damage to you and is how you lose hearts. You will also lose all hearts and score if you fall off the map. If you lose all hearts or score, you die and must press the restart button. Damage also lowers your score. At a certain point, you will find dice rolling around. They are bouncy and will launch you into the air. The Dice were originally going to be enemies that hurt you when you touched them, but when I added the knockback effect to the player I found it was too much fun to just jump on them that I had to make them bouncy fun objects.

## Controls
A - move left
D - move right
Spacebar - jump
F - activate

## Technical Implementation
Player - The player contains the movement and collision for the Player object as well as code to update the players animations. It also contains and updates the players score and heart count. Contains all user input and changes the state of Slot Machines.
Slots - Two types of slots, regular slots and real slots. Regular slots are from regular slot machines. These just randomly cycle through slot sprites. Real slots are attached to the slot machines after the player activates them. These cycle through fast and then get slower before stopping.
Slot Machines - Spawn three slot items on them at start of the game and cycles through. When the player activates them, they get deleted and immediately replaced by a real slot machine that when the slots stop moving it checks what kind of slot they are displaying and if they have 2 or more of a slot, they give that bonus (updating the players score, hearts, speed, doing nothing, or initiating on explosion).
Dice - Dice roll around randomly either right or left until they collide with something other than the ground. When they do, they switch directions. When the player collides with them, the player gets knocked upwards.
Canvas - Contains text for score, "You Win!" screen, and hearts display. Hearts are checked and get shown or hidden on the UI layer depending on the players hearts int.

## Technical Requirements Completed
Levels - One level, objective is clear as you only have one direction you can go
Sprites - unique sprites for every object
Prefabs - Prefabs used for the ground, dice, platforms, invisible walls, dice collision walls, slot machines, slots, etc.
Colliders - Colliders used in practically every object. Player, dice, ground, platforms, etc.
Rigidbodies - Dice and Players have rigidbodies
Triggers - Win flag is a trigger and so are the slot machines
UI Text - Score and game over screen are ui text, hearts are ui images
Sprite Movement - Control player movement, with animated sprites
Particle System - Explosion particles on the slot machines and boost particles for when the dice launch you up
GameObject Management - Slot machines are destroyed and recreated as new objects when they are activated. Slots also are created and destroyed dynamically when needed or when the slot machine blows up. Player health and score is changed dynamically during play by the player and by slot machines.
Game Release - Build for Windows and Web. Windows build is in the repo at "\cs276-assignment-2\Windows Build\cs276-assignment-2.exe"
Web Build - https://play.unity.com/en/games/13abeb8c-f5d6-4c54-94b3-0a2ec99ca508/cs-276-assignment-2

## Future Development Plan
How would you extend the game with additional levels?
    Dice based puzzles - you can push around dice already and stack them to get launched even higher. I could add areas where you need to do this to advance
    More different kinds of platforming. Bosses at the end of certain levels.
What new game objects or mechanics would you add?
    Enemies that deal damage to the player. Throwable cards for the player to throw at enemies, dealing damage to them. Replace the points system with chips (just visually). I also want to change the player sprite but I am awful at drawing animated sprites so I used a free asset for the player.
How would you expand the story or theme?
    Keep new items in line with the casino them I have going on. Create a backstory for what is happening in the game and explain it to the player.

## Development Reflection
What was the most challenging aspect of this project?
    I ran into issues such as one where my Players hearts would infinitely increase that took me a while to figure out. Or any issues related to the Slot Machines were kind of annoying because they take like 10 seconds to actually pick a slot configuration (I know i could've and probably should've just removed that while debugging but...). Getting the slots exactly how I wanted them was probably the most challenging?
What did you learn about Unity or game development?
    I learned a lot about how Unity worked in general. I got a lot more comfortable using it as well as more comfortable using C# syntax.
What would you do differently next time?
    I would draw my own Player sprite, I ran out of time and didn't want to invest the energy/time into drawing and animating one. Add a proper enemy to the game.

## Attributions
explosion13.wav by V-ktor -- https://freesound.org/s/435416/ -- License: Creative Commons 0
wah wah sad trombone.wav by kirbydx -- https://freesound.org/s/175409/ -- License: Creative Commons 0
8-bit Happy Ding by JapanYoshiTheGamer -- https://freesound.org/s/361264/ -- License: Creative Commons 0
Wilhelm Scream by qubodup -- https://freesound.org/s/813308/ -- License: Creative Commons 0
S38-01 Man eaten by alligator; screams [Wilhelm screams].wav by craigsmith -- https://freesound.org/s/675810/ -- License: Creative Commons 0

The player spritesheet from "Simple 2D Platformer Assets Pack" by Goldmetal on the Unity Asset Store


All other sprites/sounds were made by me.