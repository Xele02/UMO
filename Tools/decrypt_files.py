import json
import logging
import argparse
import os
import re
import glob

# Default Config
default_config = { "files" : ["Data/android/*"] }

parser = argparse.ArgumentParser()
parser.add_argument(
	"-l", 
	"--log",
	default="warning",
	help="Provide logging level. Example --log debug', default='warning'"
)
parser.add_argument("-d","--delete",action='store_true',help="Delete encrypted file after decryption success")
parser.add_argument("files", nargs='*', help="Files to decrypt")

options = parser.parse_args()

levels = {
	'critical': logging.CRITICAL,
	'error': logging.ERROR,
	'warn': logging.WARNING,
	'warning': logging.WARNING,
	'info': logging.INFO,
	'debug': logging.DEBUG
}
level = levels.get(options.log.lower())
if level is None:
    raise ValueError(
        f"log level given: {options.log}"
        f" -- must be one of: {' | '.join(levels.keys())}")
logging.basicConfig(level=level)

config_filename = os.path.splitext(os.path.abspath(__file__))[0]+"_config.json"
if not os.path.isfile(config_filename):
	logging.info("Create config file "+config_filename)
	with open(config_filename, 'w') as config_file:
		json.dump(default_config, config_file)
else:
	logging.info("Using config file "+config_filename)
	with open(config_filename, 'r') as config_file:
		default_config = json.load(config_file)

files = options.files
if len(files) == 0:
	files = default_config["files"]

logging.info("Searching in paths :")
logging.info(files)

delete_file = options.delete

keys = []
decrypt_ext = ".decrypted"

def generate_key(seed):
	logging.info("Generate key for seed "+str(seed))
	key = []
	i = 0;
	while i < 1024:
		a = (seed ^ (seed << 0xd)) & 0xffffffff
		a = a ^ (a >> 0x11)
		a = (a ^ (a << 5)) & 0xffffffff
		seed = a
		key.append((a >> 3) & 0xff)
		i = i + 1
	logging.debug(key)
	return key

sound_key = {
	88:1, 89:2, 119:3, 138:4, 158:6, 159:7
}

def decrypt_file(path, outfile):
	filesize = os.path.getsize(path)
	with open(path, "rb") as f:
		with open("tmp"+decrypt_ext, "wb") as outf:

			algo_type = 0
			key = None
			for key_data in keys:
				found = re.search(key_data["f"], path.replace("\\","/"))
				if found != None:
					if key_data["k"] == 0:
						logging.info("Pattern "+key_data+" is not encrypted, skip")
						return
					logging.info("Using key for pattern "+key_data["f"])
					key = key_data["key"]
					break;
			if key == None:
				match_sound = re.search(r"cs_w_([0-9]+)_d.*\.awb", path)
				if match_sound:
					sound_id = int(match_sound.group(1))
					if sound_id in sound_key and sound_key[sound_id] in sound_keys:
						key = sound_keys[sound_key[sound_id]]
						logging.info("Using sound key w"+str(sound_key[sound_id]))
						algo_type = 1
			if key == None:
				logging.warning("No pattern found for file "+path)
				return

			byte = f.read(1)
			cnt = 0
			ip = filesize
			first = True
			filesize = os.path.getsize(path)
			if algo_type == 1:
				q = filesize // key["a2"]
				print(str(filesize)+"//"+str(key["a2"])+"="+str(q))

			while byte:
				if algo_type == 0:
					r4 = (ip << 3)&0xffffffff;
					ip = r4 - ip
					ip = ip + 1
					r4 = int.from_bytes(byte,  byteorder='little') ^ key[ip%1024]
				else:
					q = (q * key["a0"] + key["a1"]) & 0xFFFFFFFF
					r4 = int.from_bytes(byte,  byteorder='little') ^ key["key"][q & 0x3ff]
				outf.write(r4.to_bytes(1, byteorder='little', signed=False))
				byte = f.read(1)
				cnt = cnt + 1
	os.rename("tmp"+decrypt_ext, outfile)
	if delete_file == True:
		logging.info("Delete file "+path)
		os.remove(path)


print("Generating keys")

with open('../Data/RequestMaster.json', 'r') as f:
	data_json = json.load(f)

keys = data_json["master"]["s_ak"]["data"]
for obj in keys:
	if obj["k"] != 0:
		obj["key"] = generate_key(obj["k"])

sounds_keys_data = data_json["master"]["s_sys_int"]["data"]
sound_keys = {}
for i in range(1,8):
	name = "w"+str(i)
	sound_keys[i] = { "key":generate_key(next((val["v"] for val in sounds_keys_data if val["k"] == name+"_3"), 0) + 7),
			"a0":next((val["v"] for val in sounds_keys_data if val["k"] == name+"_0"), 0),
			"a1":next((val["v"] for val in sounds_keys_data if val["k"] == name+"_1"), 0),
			"a2":next((val["v"] for val in sounds_keys_data if val["k"] == name+"_2"), 0)
			}

allfileslist = []

print("Generating files list")

def recurs_find_files(path):
	if os.path.isfile(path):
		ext = os.path.splitext(path)[1]
		if ext != ".md5" and ext != decrypt_ext:
			if os.path.isfile(path+decrypt_ext):
				if os.path.getsize(path) != os.path.getsize(path+decrypt_ext):
					logging.warning("Decrypted file size differ, force update")
				else:
					logging.debug(path+" already decrypted, Skip")
					if delete_file == True:
						logging.info("Delete file "+path)
						os.remove(path)
					return
			allfileslist.append(path)
	elif os.path.isdir(path):
		sub_files = os.listdir(path)
		for file in sub_files:
			recurs_find_files(path+"/"+file)

for file in files:
	fullpath = os.path.abspath(file)
	sub_files = glob.glob(fullpath, recursive=True)
	for sub_file in sub_files:
		recurs_find_files(sub_file)

print("Decrypting files")

cnt = 1;
cntlist = len(allfileslist)
for file in allfileslist:
	print(str(cnt)+"/"+str(cntlist)+" "+file)
	decrypt_file(file, file+decrypt_ext)
	cnt = cnt + 1
