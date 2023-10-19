# Timun-Mas-The-Cosmic-Descent
## [Aspect List In Game](https://app.milanote.com/1QOHtK16KajU7f/timun-mas--the-cosmic-descent)

## Changelog:
Alpha Release

Version 1.0.7

19/10/2023
### New Update :
- Game System
   - Camera Following
      - Camera Bounds
- Button Animation
   - Main Menu
      - Play Button
         - Level Selection
            - Test Level
               - Restart
               - Respawn
               - Pause Menu
            - Tutorial Level
            - Level 1
            - Level 2
            - Level 3 Boss
            - Main Menu
      - Option Button
Back
      - Credits Button
Back
      - Tips Button
Back
      - Exit Button
         - Yes
         - No
   - Pause Menu
      - Resume
      - Restart
      - Option
         - Back
      - Main Menu
### New Bug Fix :
- Game System
   - Loading Function
      - Replace The Loading Function at the target scene

## Changelog:
Alpha Release

Version 1.0.6

18/10/2023
### New Update And Optimization :
- Game System
   - Camera Following
      - The camera has been slightly adjusted.
- Button
   - Level Choice
      - Test Level
         - The Respawn button is now functional.
- Player Mechanic
   - Player characters won't overlap with enemy characters.
- Enemy Mechanic
   - Enemy characters can no longer jump.
- Player Animation
   - Attack
      - The Hit Attack is now timed correctly.
      - Attack delay has been reduced.
   - Hurt
      - Player's Hurt animation now plays immediately without delay after the enemy attack animation.

## Changelog:
In Development

Version 1.0.5

18/10/2023
### New Features :
- Game System
   - Loading Panel
- Background Music
   - Level 3 Boss Scene
      - Basic (Temp)
- Sound Effect
   - Button Sfx
      - Main Menu
         - Play
         - Option
            - Mute
         - Credits
            - Back
         - Tips
            - Back
         - Exit
            - Yes
            - No
      - Pause Menu
         - Resume
         - Restart
         - Option
         - Level Choice
         - Main Menu
      - Level Choice
         - Test Level
         - Tutorial Level
         - Level 1
         - Level 2
         - Level 3
         - Main Menu
### New Bug:
- Button
   - Play Button
      - Cannot use the invoke function after returning from the 'Test Level' and 'Boss Level' scenes."
- Game System
   - Loading Function
      - The problem occurs when I use it on the button in the 'level selection' scene, to fill the loading panel before switching to the selected level from the 'level selection' scene. Everything runs smoothly as               expected when I switch from the 'main menu' scene to the 'level selection' scene and execute the 'Invoke' and 'IEnumerator' functions. However, after I return to the 'main menu' scene and then go back to the             'level selection' scene, the Invoke and IEnumerator functions no longer work.


## Changelog:
In Development

Version 1.0.4

13/10/2023
### New Features :
- Game System
   - Add Background Sound Manager
- Background Music
   - Main Menu Scene
      - Add  Basic (Temp)
   - Level Choice Scene
      - Add Basic (Temp)
   - Test Level
      - Add Basic (Temp)
- Scene Manager
   - Play
      - Add Basic (Temp)
   - Option
      - Add Basic (Temp)
   - Credits
      - Add Basic (Temp)
   - Exit
      - Add Basic (Temp)
- Button
   - Main Menu
      - Option Menu
         - Add Sound Setting
         - Add Mute
   - Pause Menu
      - Option Menu
         - Add Sound Setting
         - Add Mute
- Sound Effect
   - Player Animation Sfx
      - Add Attack
      - Add Jump
      - Add Run
      - Add Hurt
      - Add Die
   - Game Background
      - Add Basic (Temp)
   - Enemy Animation Sfx
      - Add Attack
      - Add Run
      - Add Hurt
      - Add Die

## Changelog:
In Development

Version 1.0.3

11/10/2023
### New Features :
- Game System
   - Basic Pause Menu
      - Add Restart From Pause Menu
      - Add Freeze Game At Pause Menu

## Changelog:
In Development

Version 1.0.2

09/10/2023
### New Features :
- Scene Manager
   - Main Menu
      - Add Basic Main Menu
   - Play
      - Add Basic Level Selection
- Item
   - Add Timun
   - Add Heal Item

### New Update :
- Game System
   - Game Over
      - Update Restart Level
    
### New Remove :
- Button "Die" at Test Level

### New Bug Fix :
- Game System
   - Checkpoint
      - Jump in checkpoint can reduce lives (problem with button "die")
- Player Animation
   - Hurt
      - Inconsistent Animation Timing
   - Die
      - Late Animation Timing

## Changelog:
In Development 

Version 1.0.1

07/10/2023
### New Features:
1. Game System
   - Add Checkpoint
      - Can Back To Last Checkpoint
   - Add Game Over
      - Restart Level
2. Player Mechanic
   - Add Respawn
   - Add Die
3. Player Animation (Not Real Asset)
   - Add Attack
   - Add Jump
   - Add Move (Left/Right)
   - Add Hurt
   - Add Die
4. Enemy Animation (Not Real Asset)
   - Add Attack
   - Add Move (Left/Right)
   - Add Hurt
   - Add Die

### New Update:
1. Player Mechanic
   - Update Player Health

### New Bug:
1. Game System
   - Checkpoint
      - Jump in checkpoint can reduce lives
2. Player Animation
   - Hurt
      - Inconsistent Animation Timing
   - Die
      - Late Animation Timing

## Changelog:
In Development
Version 1.0.0

06/10/2023
### New Features:
1. Scene Manager
   - Add Test Level
2. Player Mechanic
   - Add Attack
   - Add Jump
   - Add Move
   - Add Player Health
   - Add Action
     - Get Timun (Item)
     - Get Score
3. Enemy Mechanic
   - Add Attack
   - Add Move
   - Add Enemy Health
4. Game System
   - Add Score
       - From Timun (Item)
       - Add Score
   - Add Health
       - Player Heatlh
       - Enemy Health
   - Add Trap
       - Reduce Player Health
   - Add Camera Following
