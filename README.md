Rewrite project of UtaMacross mobile game. 

**Current version : 0.4 Alpha 3**

Fonctionality : 
* Basic loading of the game with default profile
* Main menu : Only Music button works.
* Music menu : Music selection. Number of diva / difficulty / 4-6 lane.
* S-Live :
  * Diva select menu : Selection of diva, costume & valkyrie.
* Playing song :
  * Selecting diva/valkyrie and cards, everything is unlocked but at level 1. Expected score is partially working and values can be wrong.
  * Use key S-D-F-H-J-K for the 6 lanes, and D-F-H-J for 4 lanes songs. Slide note are automatically valided on hit. Lane change on 6 lane mode don't work. Key can be changed in the config asset in Resources/EditorRuntimeSettings.
  * There is a invincible mode activated by default to compensate the low level team selectable.
* Very basic result screen for the flow.

# Requirement

* Unity version 2018.4.23f1 or 2018.4.24f1
* The game data dump with android and db directories. Game can load from encrypted or decrypted bundle, with name format like bundle.xab, bundle.xab.decrypted, bundle!sxxxxxxz!.xab, bundle!sxxxxxxz!.xab.decrypted. Check the Tools directory to get the game data (this method can stop working anytime).
* **For linux user** : Install vlc to have libvlc 3.0 avaiable :
  * Ubuntu : ```apt-get install vlc```
  * To check it's working : ```/sbin/ldconfig -p | grep vlc``` should show libvlc and libvlccore.

# Installation

* Clone the project or extract the release zip (If you extract the zip on a older installation, remove the Unity directory before doing so).
* For automatic game data detection, you can copy android and db directory from the game dump into Tools/Data/
* Launch Unity Editor 2018.4.23f1 or 2018.4.24f1 (Accept the upgrade asset popup), load the project in Unity folder.
* Start the game : 
  * Either using the menu UMO/Start Game.
  * or load the scene Scenes/Start and hit play.
* The game will search game data in Tools/Data or Data directory (default directories when using python script to download from game server). If you put your game data elsewhere, select the directory containing "android" and "db" directories in the next popup. For advanced configuration, you can check the asset Resources/EditorRuntimeSettings.

# Used library :

* [VGMToolbox](https://sourceforge.net/projects/vgmtoolbox/) to load acb/awb and usm files
* [DereTore](https://github.com/OpenCGSS/DereTore) to play hca files
* [Flatbuffers](https://google.github.io/flatbuffers/) to read database
* [LitJson](https://litjson.net/) to read some json
* [LibVLC](https://code.videolan.org/videolan/vlc) / [LibVLCSharp](https://code.videolan.org/videolan/LibVLCSharp) to play the movies
