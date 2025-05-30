# FPS_Project
Taken ~ 6 hours to make, over a period of 2.5 days. All assets in scene were either from the built-in Unity system or made by me. 

## Instructions
Can you shoot the colored target with the matching colored bullets over 15 times in one minute?
Approach the gun to pick it up. 
Left-click the Color Palette with your mouse to pick a color that matches color of the target. 
Right-click to aim, right-click to disable aim view.
Left-click to shoot the target and win a point!

This game requires a mouse and a keyboard to play.

## What I built (and how this project meets each of the requirements)
To begin with, I made a UML diagram for my personal reference, so that I could keep track of the requirements and plan out my iteration before developing each of the scripts. I built out this UML diagram while grey-boxing the environment.

<img width="689" alt="image" src="https://github.com/user-attachments/assets/108fded3-0c9d-4cbc-8f63-a4cb70d6c338" />

- **Player movement (keyboard or controller)**
  - A character that can move around in the environments using both WASD and arrow keys to make it easier to iterate through the game.
- **At least two interactions (e.g., door switch, object pickup, trigger event)**
  - The character will be able to pick up a gun by colliding with it, change the colors of the bullets and shoot the target.
  - when you click on the environment to select the color of your bullets, the game fires off a bullet, since we are also using the left-click functionality to select the button in question. So, I made it so that by pressing a key (R for Red, Y for Yellow and B for Blue), you would select the color in question, without firing off that extra bullet.
- **A basic UI element (e.g., feedback, message, score)**
  - The character will be able to read a set of instructions at the beginning of the game, with instruction regarding controls and available functionality. 
  - The character will be able to see their score at the top of the screen, and the amount of time being taken so that they know how much time they have left.  
- **Optional: creative camera perspective or projection-mapped feel**
  - Switch the position of the camera by moving it closer to the character when they are aiming and shooting, to make it easier to view the target, as opposed to the third-=party perspective.
 
##  What I would have added if I had time

If I had more time, I would have added functionality to have cannons at the top of the walls. Everytime a bullet missed the target and landed on the wall, the cannons would aim at the character and fire back at them, adding a level of challenge within the short amount of time. I also would have 3D Modeled my own assets - for the sake of time, I greyboxed the scene, with the intention of adding 3D Models later. In addition, I would have made a physical switch that the character could use, kind of like a lever, to change the color in the physical game, as opposed to using the UI. 

I would have created an inventory system to store ammo, and a system to collect ammo in between dodging the cannons, and firing at the target. I would have added a restart button to easily restart the game. I would have added a scoreboard for players to view and beat their high score. It could have been interesting to add a coin-collection system in the environment. 



