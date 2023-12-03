Rewrite project of UtaMacross mobile game. 

**Current version : 0.9**

Fonctionality : 
* Basic loading of the game with default profile (all costume/cards unlocked and fully leveled)
* Main menu : Music/Home, Diva, VOP, SNS, Home bg switch, Home diva switch, Memory zone, Deco room, Gacha, Bingo, Missions buttons works.
* Playing song :
  * Editor gameplay : Use key S-D-F-H-J-K for the 6 lanes, and D-F-H-J for 4 lanes songs. Slide note are automatically valided on hit. Lane change on 6 lane mode don't work. Key can be changed in the options (menu UMO > Options).
* A few event can be activated (Apil fools, ...). Can be acceded from UMO Setting popup on the title screen (pad icon)

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
