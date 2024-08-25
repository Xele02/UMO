Rewrite project of UtaMacross mobile game. 

**Current version : 1.0.6**

Fonctionality : 
* Almost everything of the game.
* Playing song :
  * Editor gameplay : Use key S-D-F-H-J-K for the 6 lanes, and D-F-H-J for 4 lanes songs. Slide note are automatically valided on hit. Lane change on 6 lane mode don't work. Key can be changed in the options (menu UMO > Options).
* A few event can be activated (Apil fools, ...). Can be acceded from UMO Setting popup on the title screen (pad icon)
* Account picker : Use the top right button on the start screen. You can create new accounts, copy and delete. You can also create and use a cheat account (which was the one used before 1.0.0).
* Translation : You can switch to other languages (en / fr) in the UMO Setting. This is still a work in progress and only a small part is translated.

# Translation

The original game is in japanese only. The translation in others languages is currently working on :
* English : 1%
* French : 10%. Most of the important parts to understand the game is available.

# Requirement / Installation

* [Install on PC using Unity Editor](https://github.com/Xele02/UMO/wiki/Install-on-PC-with-Unity-Editor)
* [Install on Android](https://github.com/Xele02/UMO/wiki/Install-on-android)

# Support

You can join the discrod server for support and more information on release : https://discord.gg/xeT57fyayE .

# Used library :

* [VGMToolbox](https://sourceforge.net/projects/vgmtoolbox/) to load acb/awb and usm files
* [DereTore](https://github.com/OpenCGSS/DereTore) to play hca files
* [Flatbuffers](https://google.github.io/flatbuffers/) to read database
* [LitJson](https://litjson.net/) to read some json
* [LibVLC](https://code.videolan.org/videolan/vlc) / [LibVLCSharp](https://code.videolan.org/videolan/LibVLCSharp) to play the movies
