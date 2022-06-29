import re
import json

endclass_pattern = re.compile(r"^}", re.MULTILINE)
property_pattern = re.compile(r"public (?P<type>[a-zA-Z\[\]0-9]+) (?P<name>[A-Z]+) { get; set; }")
function_pattern = re.compile(r"public (?P<static>static )?([^ ]+) (?P<name>[A-Z]+)\((?P<params>[^)]*)\) { }")
backfield_pattern = re.compile(r"private (?P<type>[a-zA-Z\[\]0-9]+) \<(?P<name>[A-Z]+)\>k__BackingField; // (?P<addr>0x[0-9ABCDEF]+)")
getter_pattern = re.compile(r"\[CompilerGeneratedAttribute\][^\n]*[^/]*// RVA: (?P<addr>0x[0-9ABCDEF]+) [^\n]*[^p]*public (?P<type>[a-zA-Z\[\]0-9]+) (?P<name>[A-Z]+)\(\) { }")
setter_pattern = re.compile(r"\[CompilerGeneratedAttribute\][^\n]*[^/]*// RVA: (?P<addr>0x[0-9ABCDEF]+) [^\n]*[^p]*public void (?P<name>[A-Z]+)\((?P<type>[a-zA-Z\[\]0-9]+) NANNGLGOFKH\) { }")

with open("viewer_data.json","r") as f:
	fb_json_data = json.load(f)

def get_class_info(className, file_data):
	class_pattern = re.compile(r"public class "+className+" //")
	loadfunc_pattern = re.compile(r"// RVA: (?P<addr>0x[0-9ABCDEF]+) [^\n]*[^p]*public static "+className+" HEGEKFMJNCC\(byte\[\] NIODCJLINJN\) { }")

	result = {"properties":[], "name":className, "functions":[]}
	class_match = class_pattern.search(file_data)
	if class_match != None:
		end_match = endclass_pattern.search(file_data, class_match.end(0))

		# search properties
		start_pos = class_match.end(0)
		end_pos = end_match.start(0)

		back_field = []
		while True:
			field_match = backfield_pattern.search(file_data, start_pos, end_pos)
			if field_match == None:
				break
			back_field.append(field_match)

			start_pos = field_match.end(0)
		start_pos = class_match.end(0)
		getters = []
		while True:
			getter_match = getter_pattern.search(file_data, start_pos, end_pos)
			if getter_match == None:
				break
			getters.append(getter_match)

			start_pos = getter_match.end(0)

		start_pos = class_match.end(0)
		setters = []
		while True:
			setter_match = setter_pattern.search(file_data, start_pos, end_pos)
			if setter_match == None:
				break
			setters.append(setter_match)

			start_pos = setter_match.end(0)

		start_pos = class_match.end(0)
		cnt = 0
		while True:
			prop_match = property_pattern.search(file_data, start_pos, end_pos)
			if prop_match == None:
				break
			prop_info = {}
			assert prop_match.group(1) == back_field[cnt]["type"]
			assert prop_match.group(1) == getters[cnt]["type"]
			assert prop_match.group(1) == setters[cnt]["type"]
			prop_info["type"] = prop_match.group("type")
			prop_info["name"] = prop_match.group("name")
			prop_info["backfield"] = back_field[cnt]
			prop_info["getter"] = getters[cnt]
			prop_info["setter"] = setters[cnt]
			result["properties"].append(prop_info)

			if "[]" in prop_info["type"]:
				realType = prop_info["type"].replace("[]","")
				if realType != "uint" and realType != "int" and realType != "string":
					prop_info["class_info"] = get_class_info(realType, file_data)
			elif prop_info["type"] == "uint" or prop_info["type"] == "int" or prop_info["type"] == "string":
				pass
			else:
				prop_info["class_info"] = get_class_info(prop_info["type"], file_data)

			start_pos = prop_match.end(0)
			cnt = cnt + 1

		start_pos = class_match.end(0)
		loadfunc_match = loadfunc_pattern.search(file_data, start_pos, end_pos)
		if loadfunc_match:
			result["loadfunc"] = loadfunc_match

	return result

def print_class(class_info):
	output = ""
	for prop in class_info["properties"]:
		if "class_info" in prop:
			output += print_class(prop["class_info"])

	output += "public class "+class_info["name"]+"\n"
	output += "{\n"
	for prop in class_info["properties"]:
		output += "	public "+prop["type"]+" "+prop["name"]+" { get; set; } // "
		output += prop["backfield"].group("addr")+" "+prop["backfield"].group("name")+" "
		output += prop["getter"].group("name")+" "+prop["setter"].group("name")+"\n";
	for func in class_info["functions"]:
		output += "	"+("public " if "public" in func and func["public"] else "private");
		if "static" in func and func["static"]:
			output += "static "
		output += func["return_type"]+" "
		output += func["name"]+"("
		output += func["params"]
		output += ")"
		if "content" in func:
			output += "// "+func["addr"]+"\n	{\n"
			output += func["content"]
			output += "	}\n"
		else:
			output += " {} // "+func["addr"]+"\n"
	output += "}\n"
	return output

def generate_class_copy(prefix, class_info, self_var):
	assert class_info["FB_class"] in fb_json_data, class_info["FB_class"]
	fb_info = fb_json_data[class_info["FB_class"]]

	output = ""
	output += prefix+class_info["name"]+" "+self_var+"_data = new "+class_info["name"]+"();\n"
	output += "\n"

	cnt = 0
	for prop in class_info["properties"]:
		fb_prop = fb_info["vars"][cnt]
		output += generate_prop_copy(prefix, prop, self_var+"_readData", self_var+"_data", fb_prop)
		cnt = cnt + 1
	return output

def generate_prop_copy(prefix, prop_info, fb_var, self_var, fb_prop_info):
	output = ""
	if "[]" in prop_info["type"]: # array
		realType = prop_info["type"].replace("[]","")
		output += prefix+"List<"+realType+"> "+prop_info["name"]+"_list = new List<"+realType+">();\n"
		index_name = prop_info["name"]+"_idx"
		output += prefix+"for(int "+index_name+" = 0; "+index_name+" < "+fb_var+"."+fb_prop_info["name"]+"Length; "+index_name+"++)\n"
		output += prefix+"{\n"
		if realType == "uint" or realType == "int" or realType == "string":
			output += prefix+"	"+prop_info["name"]+"_list.Add("+fb_var+".Get"+fb_prop_info["name"]+"("+index_name+"));\n"
		else:
			prop_info["class_info"]["FB_class"] = fb_prop_info["inner_type"]
			output += prefix+"	"+fb_prop_info["inner_type"]+" "+prop_info["name"]+"_readData = "+fb_var+".Get"+fb_prop_info["name"]+"("+index_name+");\n"
			output += generate_class_copy(prefix+"	", prop_info["class_info"], prop_info["name"])
			output += prefix+"	"+prop_info["name"]+"_list.Add("+prop_info["name"]+"_data);\n"
		output += prefix+"}\n"
		output += prefix+self_var+"."+prop_info["name"]+" = "+prop_info["name"]+"_list.ToArray();\n"
		output += "\n"
	elif prop_info["type"] == "uint" or prop_info["type"] == "int" or prop_info["type"] == "string":
		output += prefix+self_var+"."+prop_info["name"]+" = "+fb_var+"."+fb_prop_info["name"]+";\n"
	else:
		#print(prop_info)
		#print(fb_var)
		#print(fb_prop_info)
		#assert False, "impl type "+prop_info["type"]
		#output += "//TODO "+prop_info["type"]+"\n"
		prop_info["class_info"]["FB_class"] = fb_prop_info["type"]
		output += prefix+fb_prop_info["type"]+" "+prop_info["name"]+"_readData = "+fb_var+"."+fb_prop_info["name"]+";\n"
		output += generate_class_copy(prefix, prop_info["class_info"], prop_info["name"])
		output += prefix+self_var+"."+prop_info["name"]+" = "+prop_info["name"]+"_data;\n"
	return output

class_to_generate = {
	"BMHPFEELLNP" : {"FB_class":"JKFNAKIBOCI"},
	"IOBIKMEGCAL" : {"FB_class":"NGIOPBLNBDJ"},
	"BNBONBECPKB" : {"FB_class":"ODNNPHLAMGH"},
	"IDEELDJLDBN" : {"FB_class":"JHCHMCIFCND"},
	"GGNFFEBIPON" : {"FB_class":"ANBBEHKIHLJ"},
	"IBCDCBLBJKE" : {"FB_class":"OGCAPIHPNLC"},
	"NLFIKMMPOAL" : {"FB_class":"MOHBMMEAEON"},
	"MDMEBHPAKIH" : {"FB_class":"JBMPGMCNGNP"},
	"MHKHMCAPDKK" : {"FB_class":"OEMMCAHOCEL"},
	"IPDBLJMFKHL" : {"FB_class":"PFOCKFPDBBD"},
	"AMBAEMHAMDB" : {"FB_class":"KHKJEJCOAHJ"},
	"OJMIALAOHDB" : {"FB_class":"PBIDNKDHLOB"},
	"IAIDGBJGDBH" : {"FB_class":"DHFKAKFHFOL"},
	"PJADOKMABLA" : {"FB_class":"NBKNKAIJOGL"},
	"IINMAJAFDIF" : {"FB_class":"JJKEIOGAGKI"},
}


with open("../../Data/CSharp/dump.cs","r", encoding="utf8") as f:
	file_data = f.read()


for k in class_to_generate:
	class_info = get_class_info(k, file_data)
	#print(class_info)

	class_info["FB_class"] = class_to_generate[k]["FB_class"]

	file_output = "using FlatBuffers;\nusing System.Collections.Generic;\n\n"

	assert "loadfunc" in class_info
	loadfunc = {"name":"HEGEKFMJNCC", "params":"byte[] NIODCJLINJN", "return_type":k, "static":True, "public":True, "addr":class_info["loadfunc"].group("addr")}

	loadfunc_content = ""
	loadfunc_content += "		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);\n"
	loadfunc_content += "		"+class_info["FB_class"]+" res_readData = "+class_info["FB_class"]+".GetRootAs"+class_info["FB_class"]+"(buffer);\n"

	loadfunc_content += generate_class_copy("		", class_info, "res")

	loadfunc_content += "		return res_data;\n"
	loadfunc["content"] = loadfunc_content
	class_info["functions"].append(loadfunc)

	file_output += print_class(class_info)

	#print(file_output)
	with open("../../Unity/Assets/UMAssets/Scripts/Database/Reader/"+k+".cs", "w") as f:
		f.write(file_output)
