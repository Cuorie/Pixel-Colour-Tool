# Pixel-Colour-Tool

===========================
        WHAT IS IT?
===========================
Pixel Colour Tool is a tool to be used in Unity to easy get the colour of a pixel coordinate in a texture.
Additionally it marks the current pixel so you easily can see where the pixel is located in the texture.


===========================
      HOW DO I USE IT?
===========================

Either use the tool in the project provided or just add the two scripts PixelTool.cs and PixelToolCustomEditor.cs to your own project and attach PixelTool.cs to a GameObject.
If you want to see the marking on the texture, you will need to add an Image component too.

You do not need to press Play for the tool to work.


TEXTURE
The texture you want to know the pixel colours of.

INPUT VALUES
Set the desired coordinates of the pixel you want to know the colour of.
The Mark Colour is the colour that will be used to mark current pixel.

OUTPUT VALUES
Colour: The colour of the current pixel.
Colour Values: The colour values of the current pixel in RGB 0-1.0

TEXTURE SIZE
Tells you the height and width of the texture you added.

PREVIOUS PIXEL & NEXT PIXEL BUTTONS
Moves one pixel at the time either forward or backward.
Works as a scanner from left to right and from down to up.

UP, LEFT, RIGHT & DOWN BUTTONS
Pretty self explanatory. 
Use up button to go one pixel up.
Use down button to one pixel down.
Use left button to go one pixel to the left.
Use right button to one pixel to the right.
If the pixel is at the end of the texture it will go around to the other side.


HOW TO CHANGE TEXTURE
Add a texture of your choice to the project and add it in the inspector of PixelTool in Texture. 
To see the marking on the texture in Unity, also add the same texture to the Image component.


===========================
       GOOD TO KNOW
===========================

PIXEL COORDINATES
The pixel with coordinate (0, 0) is in the lower left corner.
The pixel with coordinate (textureWidth, TextureHeight) is in the higher right corner.

TEXTURE SETTINGS
Set Texture Type to Sprite (2D and UI) (note: might work with other types, but has only rested this one)
Set Read/Write Enabled to true (find it in Advanced)
If you get a format error, change the Format (e.g. RGBA 32 bit works)

KNOWN PROBLEMS/BUGS
It can happen that old markings will appear on the texture, meaning several markings will be seen at the same time.
Most often happens when changing textures.
An easy fix for it is to restart Unity.