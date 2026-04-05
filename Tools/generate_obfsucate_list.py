import re
import os
import json

obfusced_name = re.compile(r"[^A-Z]([A-Z]{11})[^A-Z]")
obfusced_name_renamed = re.compile(r"[^A-Z]([A-Z]{11})_([M0-9]+_)?([a-zA-Z_0-9]+)[^a-zA-Z_0-9]")
fb_name = re.compile(r"/\*([a-zA-Z0-9_]+)\*/")
enum_detect = re.compile(r"^[M0-9]+$")

ignore_list = ["TEXTMESHPRO", "DESCRIPTION", "ACHIEVEMENT", "APPLICATION", "DIVARANKING", 'EVENTBATTLE', "EVENTGODIVA", "INAPPUSERID", "LOBBYMEMBER", "MUSICSELECT", "OFFERSELECT", "QUESTSELECT", "SCENEGROWTH", "SCENESELECT", "SETTINGMENU", "STORYSELECT", "TRANSACTION", "UNAVAILABLE", "UNSUPPORTED"]

with open("../Data/CSharp/dump.cs.txt", "r") as f:
	file_data = f.read()

names_dict = {}

start_pos = 0
while True:
	name_found = obfusced_name.search(file_data, start_pos)
	if name_found == None:
		break
	if name_found.group(1) in ignore_list:
		start_pos = name_found.end(0)
		continue
	names_dict[name_found.group(1)] = {"names":{}}
	start_pos = name_found.end(0)

names_dict = dict(sorted(names_dict.items()))

unity_code_path = "../Unity/Assets/"

def recurs_check(path):
	if os.path.isfile(path):
		ext = os.path.splitext(path)[1]
		if ext == ".cs":
			#if "Reader" in path:
			#	return
			if "Table" in path:
				return
			with open(path,"r") as f:
				file_data = f.read()
			start_pos = 0
			while True:
				name_single = obfusced_name.search(file_data, start_pos)
				if name_single == None:
					break
				if name_single.group(1) in ignore_list:
					start_pos = name_single.end(0)
					continue
				old_name = name_single.group(1)
				name_found = obfusced_name_renamed.search(file_data, start_pos)
				#if "LDEB" in path:
				#	print(str(name_single)+" "+str(name_found))
				if name_found != None and enum_detect.match(name_found.group(3)) != None: # Consider enum empty as not found
					name_found = None
				#if name_single.group(1) == "AAOCPMCMPCP":
				#	print(str(name_single.start(1)) + file_data[name_single.start(1) - 6:name_single.start(1) - 1] )
				if name_found != None and name_found.group(3) == "bgs":
					name_found = None
				if name_found == None: # or name_found.start(1) != name_single.start(1):
					if "FlatBuffers" in path:
						break
					if "Reader" in path:
						fbname_found = fb_name.search(file_data, name_single.end(1))
						if fbname_found != None and fbname_found.start(0) == name_single.end(1) and name_single.group(1) != "AGOIMGHMGOH":
							#print(str(fbname_found)+" "+file_data[name_single.end(1):name_single.end(1) + 10]+" "+str(fbname_found.start(1))+" "+str(name_single.end(1)))
							if old_name in names_dict:
								if fbname_found.group(1) not in names_dict[old_name]["names"]:
									names_dict[old_name]["names"][fbname_found.group(1)] = {"source":"FB", "num":0}
						start_pos = name_single.end(1)
						continue
					if file_data[name_single.start(1) - 6:name_single.start(1) - 1] == "class" or \
							file_data[name_single.start(1) - 7:name_single.start(1) - 1] == "struct" or \
							file_data[name_single.start(1) - 5:name_single.start(1) - 1] == "enum" or \
							file_data[name_single.start(1) - 10:name_single.start(1) - 1] == "interface":
						start_pos = name_single.end(1)
						continue
					if old_name in names_dict:
						if "" in names_dict[old_name]["names"]:
							names_dict[old_name]["names"][""]["num"] += 1
						else:
							names_dict[old_name]["names"][""] = {"source":path+" "+str(name_single.start(1)), "num":1}
					start_pos = name_single.end(1)
					continue
				if name_found.start(1) != name_single.start(1):
					if "FlatBuffers" in path:
						start_pos = name_single.end(1)
						continue
					if "Reader" in path:
						fbname_found = fb_name.search(file_data, name_single.end(1))
						if fbname_found != None and fbname_found.start(0) == name_single.end(1) and name_single.group(1) != "AGOIMGHMGOH":
							#print(str(fbname_found)+" "+file_data[name_single.end(1):name_single.end(1) + 10]+" "+str(fbname_found.start(1))+" "+str(name_single.end(1)))
							if old_name in names_dict:
								if fbname_found.group(1) not in names_dict[old_name]["names"]:
									names_dict[old_name]["names"][fbname_found.group(1)] = {"source":"FB", "num":0}
						start_pos = name_single.end(1)
						continue
					if file_data[name_single.start(1) - 6:name_single.start(1) - 1] == "class" or \
							file_data[name_single.start(1) - 7:name_single.start(1) - 1] == "struct" or \
							file_data[name_single.start(1) - 5:name_single.start(1) - 1] == "enum" or \
							file_data[name_single.start(1) - 10:name_single.start(1) - 1] == "interface":
						start_pos = name_single.end(1)
						continue
					if old_name in names_dict:
						if "" in names_dict[old_name]["names"]:
							names_dict[old_name]["names"][""]["num"] += 1
						else:
							names_dict[old_name]["names"][""] = {"source":path+" "+str(name_single.start(1)), "num":1}
					start_pos = name_single.end(1)
					continue
				if name_found.group(1) in ignore_list:
					start_pos = name_found.end(3)
					continue
				old_name = name_found.group(1)
				new_name = name_found.group(3)
				if "Reader" in path and (new_name == "idx_" or new_name == "list_" or new_name == "readData_" or new_name == "data_"):
					start_pos = name_found.end(3)
					continue
				if old_name in names_dict:
					if new_name not in names_dict[old_name]["names"]:
						names_dict[old_name]["names"][new_name] = {"source":"", "num":0}
					source = "Guess"+" "+path+" "+str(name_single.start(1)) if names_dict[old_name]["names"][new_name]["source"] == "" else names_dict[old_name]["names"][new_name]["source"]
					if "LitJson" in path:
						source = "LitJson"+" "+path+" "+str(name_single.start(1))
					if "FlatBuffers" in path:
						source = "FlatBuffers"+" "+path+" "+str(name_single.start(1))
					names_dict[old_name]["names"][new_name]["source"] = source
					names_dict[old_name]["names"][new_name]["num"] += 1
				start_pos = name_found.end(3)
	elif os.path.isdir(path):
		sub_files = os.listdir(path)
		for file in sub_files:
			recurs_check(path+"/"+file)

recurs_check(os.path.abspath(unity_code_path))

#print(names_dict)

#with open("namelist.json", "w") as f:
convertlist = {}
convertlistUnknown = {}
for k in names_dict:
	found = False
	for k2 in names_dict[k]["names"]:
		if k2 != "":
			convertlist[k] = k2
			found = True
	if not found:
		convertlistUnknown[k] = ""
with open("namelist.json", "w") as f:
	json.dump(convertlist, f, indent=True)
with open("namelist_unknown.json", "w") as f:
	json.dump(convertlistUnknown, f, indent=True)

with open("obfuscate.csv", "w") as f:
	for k in names_dict:
		if len(names_dict[k]["names"]) == 1 and "" in names_dict[k]["names"]:
			f.write(k+";"+str(names_dict[k]["names"][""]["num"])+"\n")

with open("obfuscate2.csv", "w") as f:
	for k in names_dict:
		if len(names_dict[k]["names"]) > 1:
			for k2 in names_dict[k]["names"]:
				f.write(k+";"+k2+";"+names_dict[k]["names"][k2]["source"]+";"+str(names_dict[k]["names"][k2]["num"])+"\n")
		#else:
		#	f.write(k+";;\n")
