This is the development documentation for Pickin' Sticks Unity.

This documentation is incomplete, covering only the trickiest parts of the project, and may be amended at a later date.

This was written and tested with unity version 2018.3.10f1, but it should work for at least a while.

Setting Inputs
---

Go to Edit -> Project Settings -> Input.

When using the built-in input system, I set the "gravity" and "sensitivity" of any inputs (such as "Horizontal" and "Vertical") to 1000. This simulates a simple pressed-or-not-pressed state when taking input from the keyboard.

Importing A Single Sprite
---

When you're importing a single sprite from a file, select that file in the project view to bring the metadata up in the inspector, and use the following settings for the highest possible quality:

Texture Type: Sprite (2D and UI)  
Sprite Mode: Single  
Pixels Per Unit: 100 (see the note on tilemaps and scaling)  
Mesh Type: Full Rect  
Extrude Edges: 1  
Wrap Mode: Clamp  
Filter Mode: Point (no filter)  
Compression: None  

Importing A Sprite Sheet Or Tileset
---

When you're importing a sprite sheet or a tileset from a file, select that file in the project view to bring the metadata up in the inspector, and use the following settings for the highest possible quality:

Texture Type: Sprite (2D and UI)  
Sprite Mode: Multiple  
Pixels Per Unit: 100 (see the note on tilemaps and scaling)  
Mesh Type: Full Rect  
Extrude Edges: 1  
Wrap Mode: Clamp  
Filter Mode: Point (no filter)  
Compression: None  

THEN select the "Sprite Editor" button. Select the "Slice" dropdown from the top left, and set type to "Grid By Cell Count" (or "Grid by Cell Size", if you feel more comfortable dealing with pixels). You can also set the "pivot" here, which is treated as the origin of the sprite as a whole. Finally, select "Apply" from the top right, and you'll have a nicely sliced spritesheet for use in the animation system below.

Animation System
---

The built-in animation system is *unpleasant* to use in any major capacity. I highly recommend finding a tool such as SpriterDotNet to abstract away this section. For simple projects though, this should be enough.

Open both the "Animation" and "Animator" windows - don't get the two confused.

in the Animation window, this is where you build animations by hand, while the Animator window is where you put them together in a logical order using the state machine.

To create a single animation, select an object in the scene overview, and then select "Create New Clip" from the drop-down and save it with a logical name. Then, you can set the animation speed (the default is 60), and drag individual sprites from the project overview window into the animation window.

Once you create an animation, it becomes visible in the animator window. This window is a "state machine", which means the process moves from one "state" or animation to another, based on a number of conditions. These conditions are created in the "Parameters" field, and set in the code; conditions can be strings, booleans, integers and triggers (the latter of which only occurs for one frame).

To create a transition between different state, right click one, and select "Make Transition", then click the destination state. This should create a line with an arrow between the two. Select the line, and set the "Transition Duration" and "Transition Offset" values to 0 - these only cause problems with sprites.

Finally, press the little "+" button under conditions, which will link a parameter to this transition. Select the correct parameter, it's condition and optionally it's value.

In the code attached to this object, you can call a number of functions such as "SetInteger()", "SetBool()", and "SetTrigger()" with the animator component to alter the parameters.

Tilemaps and Scaling
---

There is a slight unity bug when using Tilemaps and a moving camera - small gaps can occasionally appear between tiles. This is a fundemental flaw with unity, and won't be addressed anytime soon. So, here's a solution that has worked for me in testing, but I've yet to try it in practice.

Increase the scale of the world by 100.

The default pixel size to unity unit is 100:1. Change this to 1:1, and you'll be able to side-step the above problem. To do this, Tileset Grids will need a size of x = 32 and y = 32; the camera will need to be moved WAY back to about 1000, and it's far clipping plane needs to be set higher, to about 10,000. Also, any sprites you import will need a "Pixels Per Unit" set to 1.

Please note that this project does not use this bugfix, since it doesn't have a moving camera - instead it uses unity's default settings where possible. This is just a solution to keep in mind for later.

