# postcards
The project for drawing pictures. See details in README file.
=============================================================
This is a small personal project created for my child by me in 2015.

The idea of this desktop application is creating some pictures which can be used like postcards. A user/child can choose a background, add, move ( by keeping down mouse right button), increase (max 6 times), rotate (to the right by 18 degrees) and delete (by pressing twice mouse right button) elements and save the received picture as a *.png file.

Technical aspects:
*.cs file contains eight event handlers: cboBackgrounds_SelectionChanged, DrawFlower_Click, SaveButton_Click, canvasDrawingArea_MouseMove, canvasDrawingArea_MouseWheel, canvasDrawingArea_MouseLeftButtonDown, canvasDrawingArea_MouseRightButtonDown, canvasDrawingArea_MouseRightButtonUp.

In *.xaml.cs LinearGradientBrushes, SolidColorBrushes were created for backgrounds, 22 DrawingBrushes for images of flowers and stems and added under <Window.Resources>

“Postcards” can be found in the blog article:
https://nataliasiren.wordpress.com/2016/09/27/a-miracle-of-vector-graphic/

