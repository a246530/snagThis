# snagThis

### Simple screen capture utility written in c#
Take a screen shot and have it save to a default folder, a location of your choosing, or just copy it to the clipboard so you can paste it later. That simple.

### How to use
Open application and a small box with a camera in it will appear in the left upper corner of your screen. The background will be red until you initiate taking a screenshot by clicking on the icon. 
![template](/helpmeimages/beforeclick.JPG)

After you click the icon, it will turn green.
![template](/helpmeimages/afterclick.JPG)

The next click you make will be the one that takes the screenshot. Click on the window you want a screenshot of and wait a second. This window will come up once the screenshot is complete.
![template](/helpmeimages/captured.JPG)

The following options are available:
1. Save- Will save to the default location (can be setup in the settings window)
2. Save As- This will display a popup and let you pick where to save it and the name of the screenshot
3. Clipboard- Saves the image to the clipboard so you can paste it where you want
4. Email- *Still has not been completed.

#### Change Settings
When you open the application a small icon with a camera is put into the right part of the taskbar. When you right click on the application you will see a menu appear. Select settings to access.
![template](/helpmeimages/iconMenu.JPG)

The settings window is pretty self explanatory. 
1. Dark or light mode- Do you want the background of application to be white or black?
2. Primary color- Color of buttons and such.
3. Accent color- nothing uses the accent color yet...
4. Default save path- When you take a screenshot and press save not save as, it will put the image in the folder you setup in your settings. IF you do not set this up and press save, the application put it in the logged in users pictures folder.
5. Auto Focus- If this is on, then when you press the camera button and then put your mouse over different windows on the screen, they will get pulled to the front of the screen above everything else (experimental still)
![template](/helpmeimages/settings.JPG)
