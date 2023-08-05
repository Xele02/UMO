Rewrite project of UtaMacross mobile game. 

**Current version : 0.4 Beta**

Fonctionality : 
* Basic loading of the game with default profile (all costume/cards unlocked and fully leveled)
* Main menu : Only Music button works.
* Music menu
* Playing song :
  * Use key S-D-F-H-J-K for the 6 lanes, and D-F-H-J for 4 lanes songs. Slide note are automatically valided on hit. Lane change on 6 lane mode don't work. Key can be changed in the options (menu UMO > Options).

# Requirement

* Unity version 2018.4.23f1 or 2018.4.24f1
* The game data dump with android and db directories. Game can load from encrypted or decrypted bundle, with name format like bundle.xab, bundle.xab.decrypted, bundle!sxxxxxxz!.xab, bundle!sxxxxxxz!.xab.decrypted. Check the Tools directory to get the game data (this method can stop working anytime).
* **For linux user** : FFMpeg installed to convert movies. If not installed, check "Disable movies" in the options.

# Installation

* Clone the project or extract the release zip (If you extract the zip on a older installation, remove the Unity directory before doing so).
* For automatic game data detection, you can copy android and db directory from the game dump into Tools/Data/
* Launch Unity Editor 2018.4.23f1 or 2018.4.24f1 (Accept the upgrade asset popup), load the project in Unity folder.
* **Linux user** : You can convert all the movies instead of when needed with the menu UMO > Convert all movies. This use FFMpeg and take a long time.
* Start the game using the menu UMO > Start Game.
* The game will search game data in Tools/Data or Data directory (default directories when using python script to download from game server). If you put your game data elsewhere, select the directory containing "android" and "db" directories in the next popup. For advanced configuration, you can check the options.

# Usage
**Menu UMO**
* Start Game : Start the game.
* Start Auto SLive Viewer : Start the game in automatic mode, randomply selecting songs and diva costumes.
* Options : Open a window with UMO specific options
  * Profile
    * Force tuto skip : Unused actually
    * Can skip unplayed songs : Allow the skip button to be enabled even for song never played
  * Live
    * Is Invincible Cheat : Will not lose the song even when life hit 0
    * Force perfect note : All note will be a perfect. Work like an autoplay
    * Force Live Valkyrie Mode : Force going in valkyrie mode even if gauge is not filled
    * Force Live Diva Mode : Force going in standard diva mode
    * Force Live Awaken Diva Mode : Force going on awaken diva mode
    * Touch* : Select the key to use for each lane and the active skill button.
  * S-Live
    * Disable note sound : Disable the note sound in SLive because setting the note sound in the option to 0 still play sound in this mode. This won't mute the sound in normal play mode.
    * Disable watermak : Disable the UtaMacross watermark
    * Disable Movies : Disable playing movies
  * Data Directory : Local directory where game data was downloaded.
  * Data Web server URL : URL Where to download data (this require uploading the data somewhere accessible on a web server)
  * Debug : Debug options for dev.
* Copy song setup for bug report : Allow to generate the song infos to help doing the report.
* Create song notes data : Allow to generate a log of a song play to help doing a bug report when tapping note is broken.
* (Linux user) Convert all movies. Allow to convert all movies at once.

# Used library :

* [VGMToolbox](https://sourceforge.net/projects/vgmtoolbox/) to load acb/awb and usm files
* [DereTore](https://github.com/OpenCGSS/DereTore) to play hca files
* [Flatbuffers](https://google.github.io/flatbuffers/) to read database
* [LitJson](https://litjson.net/) to read some json
* [LibVLC](https://code.videolan.org/videolan/vlc) / [LibVLCSharp](https://code.videolan.org/videolan/LibVLCSharp) to play the movies
