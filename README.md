# EscapeRoom
Escape Room game for CS3365

![alt text](https://github.com/hannahmestes/EscapeRoom/blob/master/gif.gif?raw=true "GIF of App")


## Members & Responsibilities:

|         | Team Member | Responsibilities  |
|:---:|:---:|:---:|
| ![Picture](https://i.imgur.com/CH8zog6.jpg) | Hannah Estes | Antidote interactions and VR mechanics |
|  ![Picture](https://i.imgur.com/jGlkQcz.jpg) | Hriddhi Kulkarni | Key and lock interactions |
| ![Picture](https://i.imgur.com/vBoP71w.jpg)| Tasnia Heya | Key pad interactions |
| ![Picture](https://i.imgur.com/Hjeut15.jpg) | Jeffrey Lance | Narrative and music |
| ![Picture](https://i.imgur.com/gXLSGLL.jpg) | Katrina Bueno | Timer and main menu | 

## Sketches

### Oculus Touch controller diagram for reference:

![alt text](https://github.com/hannahmestes/EscapeRoom/blob/master/oculus_controller.png?raw=true "Oculus Controller")


### Teleportation

![alt text](https://github.com/hannahmestes/EscapeRoom/blob/master/TeleportDiagram.png?raw=true "Teleport")


### Picking Up Items

![alt text](https://github.com/hannahmestes/EscapeRoom/blob/master/grabDiagram.png?raw=true "Pick up Item")


### Using Items

![alt text](https://github.com/hannahmestes/EscapeRoom/blob/master/useKeyDiagram.png?raw=true "Use Item")


### Room Blueprint

![alt text](https://github.com/hannahmestes/EscapeRoom/blob/master/Blueprint.png?raw=true "Blueprint")


### Current State of Room
![alt text](https://github.com/hannahmestes/EscapeRoom/blob/master/Morgue.png?raw=true "Blueprint")


### Current Progress
* Teleportation and grabbing items actions are working
* Morgue setting working
* Teleportation zones added
* Identified needed assets

### Plan going forward
* Finish designing puzzles
* Implement puzzles
* Add sound and other details
* Add menu screen
* User testing

### Demo link
[Link](https://youtu.be/PNY4jpVfhyI)

### Task description
* There are three glass tubes available with purple, green and orange colored components(liquids)
* The user's task is to create a mixture of the three colored components

### Hypothesis
* The three color components are available in glass tubes on a table in the Escape Room 
* We ask the user to create a mixture of the three colored components
* We explain the controls and user will be able to figure it out without any extra assistance

### Final Demo Link
[Link](https://youtu.be/dqQRXxbc524)

## Final Project Report

![alt text](https://github.com/hannahmestes/EscapeRoom/blob/master/Menu.png?raw=true "Title Screen")

This project is a VR Escape Room game, in which we take the standard escape room experience and translate it into VR. Our goal was to take a game concept that the average player might be familiar with, then make a major change to the way the player would interact with that game. We knew early on that we wanted the new kind of interaction to come from VR, which provides great opportunities for immersion and immediacy, and quickly realized that an escape room was quite well suited to the medium.

In a traditional escape room game, the player clicks around a room in an attempt to find clues that will eventually help them escape. These might be keys, notes, items, pictures, etc., and they are often hidden or only reachable in a certain sequence. Usually, this translates to a lot of screen scanning and clicking around to find the interactive objects until the puzzle begins to take shape. But because the player is simply looking at a screen and moving their mouse, there is an automatic layer of removal from the experience. VR presents a unique opportunity, because it allows the player to actually feel stuck in the room and be immersed in the experience of being “trapped,” so to speak.

Furthermore, while the traditional escape room involves locating interactive objects in a 2D space, our VR implementation creates a 3D interactive environment. Instead of just scanning around and clicking with a mouse to trigger events, the player can actually move through the space, pick up objects, and physically interact with them. Rather than simply click on a key and click on a lock, the player can grab the key, unlock the door, and open it. However, what we realized was that, with this level of freedom of movement and interactivity, it would be very easy to get carried away with placing tons of objects and puzzles in the game world. Because of this, we decided to keep the scope of the game small, limit ourselves to a few key puzzles, and focus on having the player solve something unique to the VR experience.

![alt text](https://github.com/hannahmestes/EscapeRoom/blob/master/SceneMap.png?raw=true "SceneMap")
![alt text](https://github.com/hannahmestes/EscapeRoom/blob/master/PlayerSart.png?raw=true "UserView")


To that end, the full route of the VR game is as follows: the player enters a morgue in which there is a body on a table in front of them; a note on top of the body makes the player aware of an infection which, presumably, both the player and the dead person (known as “V”) were attempting to cure. At this point, the player is infected and has 5 minutes to make the cure and escape, and will see a timer indicating their remaining time. The note also mentions someone “Persephone,” who the player might presume is V’s wife, and on a nearby table is a picture frame with a picture of V’s family. Near the picture is a key which the player can use to unlock a cabinet in the morgue. Inside the cabinet, the player will find the vials that enable them to make the cure, as well as a note which has both the formula for the cure and the door code.

![alt text](https://github.com/hannahmestes/EscapeRoom/blob/master/Cabinet.png?raw=true "Cabinet")

At this point, the player can use the door code to exit the room, but if they have not taken the cure, they will die upon exiting. We wanted to include different possible routes for the player to take, such that the game allows some player choice, rather than being entirely on rails. But we also assumed that an average player, upon finding the tools to make the cure, would make use of them—even if only out of curiosity.

![alt text](https://github.com/hannahmestes/EscapeRoom/blob/master/Mixing.png?raw=true "Mixing Colors")

If the player chooses to make the cure, they must follow the formula sheet by first mixing three secondary colors from the three primary colors, and then mixing those secondary colors in a particular order. We wanted this addition of color at a key stage in the game to make it feel more vibrant, visually engaging, and fun, while still presenting an opportunity for interaction and puzzle solving. This puzzle is the focal point of the game and is intended to highlight the interactive capabilities afforded by a VR experience. The player can physically pick up the vials, pour them, mix them, and even simulate drinking them. The formula sheet is color coded, so the puzzle can be solved by simply following the colors without having to memorize a complex sequence. 

![alt text](https://github.com/hannahmestes/EscapeRoom/blob/master/PinPad.png?raw=true "Keypad")

For a successful run of the game, once the player has made and taken the cure, they will progress to the keypad and unlock the main door with the 4-digit code found on the note from the cabinet. The code is disguised as part of the drug trial designation for the cure, but is underlined to draw the player’s attention. Once the player puts in the code, they can open the door and exit the room, winning the game. If a player knows exactly what to do, a full run can be completed very quickly, but a new player will likely be racing against the clock, and might even have to take a few tries to successfully exit.

Overall, this project was an incredibly enjoyable effort and we’re very satisfied with the final game. While simple in scope, it is a fun and interactive experience that we feel makes good use of the capabilities provided by VR. It takes the traditional escape room and fully immerses the player in the experience, allowing them to truly be stuck in the room and physically find their way to an escape. And moving forward, we feel this project would serve as an excellent starting point for a more complex, lengthy, and challenging game.


### Citations
* Libraries:
1. [Key](https://www.turbosquid.com/FullPreview/Index.cfm/ID/778308) 
2. [Lock](https://www.turbosquid.com/FullPreview/Index.cfm/ID/718013)
3. [Zombie](https://assetstore.unity.com/packages/3d/characters/humanoids/zombie-30232)
4. [Laboratory pack](https://assetstore.unity.com/packages/3d/props/tools/free-laboratory-pack-123782)
5. [Old radio](https://assetstore.unity.com/packages/3d/props/interior/old-radio-ocean-72923)
6. [Morque room](https://assetstore.unity.com/packages/3d/environments/morgue-room-pbr-65817)
7. [Horror](https://assetstore.unity.com/packages/3d/props/horror-assets-69717)
8. [Oculus integration](https://assetstore.unity.com/packages/tools/integration/oculus-integration-82022)

* References:
1. [Unity Documentation](https://docs.unity3d.com/Manual/index.html)
2. [Unity Learn course](https://learn.unity.com/course/oculus-vr)
3. [VR toolkit](https://vrtoolkit.readme.io)
