Python script require Python 3 with requests module.

To install requests module : 

```
python3 -m pip install requests
```

# Download files from server

Download files using Data/RequestGetFiles.json data. 

Directory by default is Data/, can be changed with -o argument. 

Use regex in files_pattern arg to limit downloaded files. 

Once downloaded, will create another file with .md5 extension. .md5 files are used to fast check if a file changed on the server and redownload it. Script will also skip download if a file decrypted (.decrypted extension) is found with original file deleted.

```
Usage: download_game_files.py [-h] [-l LOG] [-d] [-o OUTPUT] [files_pattern [files_pattern ...]]

positional arguments:
  files_pattern         Regex patterns for matching file to download. Default is .*

optional arguments:
  -h, --help            show this help message and exit
  -l LOG, --log LOG     Provide logging level. Example --log debug', default='warning'
  -d, --delete          Delete encrypted file after decryption success
  -o OUTPUT, --output OUTPUT
                        Download path
```

# Decrypt downloaded files

Decrypt files given as argument, either direct name or directory. By default, it scan Data/android/ directory. 

IT will create a new file with .decrypted extension on success. Use -d flag to remove orginal file once decrypted.

```
Usage: decrypt_files.py [-h] [-l LOG] [-d] [files [files ...]]

positional arguments:
  files              Files to decrypt

optional arguments:
  -h, --help         show this help message and exit
  -l LOG, --log LOG  Provide logging level. Example --log debug', default='warning'
  -d, --delete       Delete encrypted file after decryption success
```
