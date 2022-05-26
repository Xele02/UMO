import json
import logging
import argparse
import os
import re
import requests

# Default Config
default_config = { "download_path" : "Data/" }

parser = argparse.ArgumentParser()
parser.add_argument(
	"-l",
	"--log",
	default="warning",
	help="Provide logging level. Example --log debug', default='warning'"
)
parser.add_argument("-d","--delete",action='store_true',help="Delete encrypted file after decryption success")
parser.add_argument("-o","--output",help="Download path")
parser.add_argument("files_pattern", nargs='*', default=".*", help="Regex patterns for matching file to download. Default is .*")

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

patterns = options.files_pattern
if len(patterns) == 0:
	files = [".*"]

output_dir = options.output
if output_dir is None:
	output_dir = default_config["download_path"]

with open("../Data/RequestGetFiles.json", "r") as f:
	files_info = json.load(f)

file_list = files_info["files"]

def filter_func(x):
	for pattern in patterns:
		if re.search(pattern, x["file"]) != None:
			return True
	return False

file_list = list(filter(filter_func, file_list))

url = files_info["base_url"]
print("Download on "+url)

cnt = 0
for file in file_list:
	print(str(cnt)+"/"+str(len(file_list))+" "+file["file"])
	fullpath = output_dir + file["file"]
	if os.path.isfile(fullpath+".md5"):
		with open(fullpath+".md5", "r") as md5file:
			md5 = md5file.read()
		if md5 != file["hash_value"]:
			print("Wrong hash, redld")
		else:
			print("Skip")
			continue
	try:
		request = requests.get(url+file["file"], allow_redirects=True)
		if request.status_code != 200:
			logging.error("Http error : "+str(request.status_code))
		open('tmp','wb').write(request.content)
		os.makedirs(os.path.dirname(fullpath), exist_ok=True)
		os.rename("tmp", fullpath)
		open(fullpath+".md5","w").write(file["hash_value"])
	except ValueError:
		logging.error(VaueError)
	cnt = cnt + 1
