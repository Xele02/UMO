import re
import json

class_pattern = re.compile(r"public sealed class ([A-Z]+) : FGDIPIOKOBP")
endclass_pattern = re.compile(r"^}", re.MULTILINE)
property_pattern = re.compile(r"public ([a-zA-Z]+) ([A-Z]+) { get; }")
function_pattern = re.compile(r"public (static )?([^ ]+) ([A-Z]+)\(([^)]*)\) { }")

classes = []

with open("dump.cs","r", encoding="utf8") as f:
    file_text = f.read();
    start_pos = 0;
    while True:
        class_match = class_pattern.search(file_text, start_pos)
        if class_match:
            start_pos = class_match.end(0)
            class_info ={"name":class_match.group(1), "property":[], "function":[]}
            
            end_match = endclass_pattern.search(file_text, start_pos)
            
            prop_search_pos = start_pos
            while True:
                property_match = property_pattern.search(file_text, prop_search_pos, end_match.end(0))
                if property_match:
                    class_info["property"].append({
                                "name":property_match.group(2),
                                "type":property_match.group(1)
                                })
                    prop_search_pos = property_match.end(0)
                else:
                    break
                    
            func_search_pos = start_pos
            while True:
                function_match = function_pattern.search(file_text, func_search_pos, end_match.end(0))
                if function_match:
                    arg_list = function_match.group(4).split(", ") if function_match.group(4) != None else []
                    func_info = {
                        "pos":function_match.start(0)-start_pos,
                        "static":function_match.group(1) != None,
                        "name":function_match.group(3),
                        "return_type":function_match.group(2),
                        "args":[]
                    }
                    for a in arg_list:
                        func_info["args"].append(a.split(" "))
                    
                    class_info["function"].append(func_info)
                    
                    func_search_pos = function_match.end(0)
                else:
                    break;
            
            start_pos = end_match.end(0)
            classes.append(class_info)
        else: 
            break            

name_replace = {
    "Offset":"AAABLJBBNJH_Offset",
    "StringOffset":"EANEPBLOKJB_StringOffset",
    "VectorOffset":"EPIPFBNHFKI_VectorOffset",
    "Struct":"MOJCOLLMMIG_Struct",
    "Table":"FGDIPIOKOBP_Table",
    "ByteBuffer":"JMPAJDKFFGL_ByteBuffer",
    "__init":"MNKGOIDFMPF___init",
    "FlatBufferBuilder":"EJJNJDFCICC_FlatBufferBuilder"
}

viewer_data = {

}

def add_name_replace(map, func_name, replace_name):
    if func_name not in map:
        map[func_name] = replace_name


with open("database.fbs","w") as fs:
    for classe in classes:
        fs.write("table "+classe["name"]+" {\n")
        
        state = 0
        member_counter = 0
        property_counter = 0
        func_counter = 0
        start_getter_func = 0

        viewer_info = {"vars":[]}
        
        while func_counter < len(classe["function"]):
            func = classe["function"][func_counter]
            if state == 0: # common create/init func
                if func_counter == 0:
                    add_name_replace(name_replace, "GetRootAs"+classe["name"], func["name"]+"_GetRootAs"+classe["name"])
                if func_counter == 2:
                    start_getter_func = func_counter + 1
                    state = 1
            elif state == 1: # ignore getter and go to Create func
                if func["static"] == True and func["return_type"] == "AAABLJBBNJH<"+classe["name"]+">":
                    state = 2
                    members = func["args"][1:]
                    
                    add_name_replace(name_replace, "Create"+classe["name"], func["name"]+"_Create"+classe["name"])
            elif state == 2: # start func
                add_name_replace(name_replace, "Start"+classe["name"], func["name"]+"_Start"+classe["name"])
                state = 10
            elif state == 10: # add members
                prop = classe["property"][property_counter]
                
                gfunc = classe["function"][func_counter]
                add_name_replace(name_replace, "Add"+prop["name"], gfunc["name"]+"_Add"+prop["name"])
                
                if members[member_counter][0] == "EPIPFBNHFKI": # list
                    assert prop["type"] == "int"
                    func_type = classe["function"][func_counter + 1]
                    real_type = func_type["args"][1][0]
                    assert "[]" in real_type, real_type+" does not contain []"
                    real_type = real_type.replace("[]","")
                    if "AAABLJBBNJH" in real_type:
                        real_type = real_type.replace("AAABLJBBNJH<","").replace(">","")
                    if real_type == "EANEPBLOKJB":
                        real_type = "string"
                    
                    fs.write("\t"+prop["name"]+":["+real_type+"];\n")

                    viewer_info["vars"].append({"name":prop["name"], "type":"list", "inner_type":real_type})

                    gfunc = classe["function"][func_counter + 1]
                    add_name_replace(name_replace, "Create"+prop["name"]+"Vector", gfunc["name"]+"_CreateVector"+prop["name"])
                    gfunc = classe["function"][func_counter + 2]
                    add_name_replace(name_replace, "Start"+prop["name"]+"Vector", gfunc["name"]+"_StartVector"+prop["name"])
                    
                    # will generate 2 or 3 getter func
                    if real_type == "string":
                        gfunc2 = classe["function"][start_getter_func]
                        assert gfunc2["return_type"] == real_type, gfunc2["return_type"]+" == "+real_type
                        add_name_replace(name_replace, "Get"+prop["name"], gfunc["name"]+"_Get"+prop["name"])
                        
                        gfunc3 = classe["function"][start_getter_func+1]
                        assert gfunc3["return_type"] == "int", gfunc3["return_type"]
                        add_name_replace(name_replace, prop["name"]+"Length", prop["name"]+"_Length")
                        
                        start_getter_func = start_getter_func + 1
                    elif real_type == "int" or real_type == "uint":
                        gfunc2 = classe["function"][start_getter_func]
                        assert gfunc2["return_type"] == real_type, gfunc2["return_type"]+" == "+real_type
                        add_name_replace(name_replace, "Get"+prop["name"], gfunc["name"]+"_Get"+prop["name"])
                        
                        gfunc3 = classe["function"][start_getter_func+2]
                        assert gfunc3["return_type"] == "Nullable<ArraySegment<byte>>", gfunc3["return_type"]
                        add_name_replace(name_replace, "Get"+prop["name"]+"Bytes", gfunc3["name"]+"_GetBytes"+prop["name"])
                        
                        start_getter_func = start_getter_func + 2
                    else:
                        gfunc = classe["function"][start_getter_func]
                        assert gfunc["return_type"] == real_type, gfunc["return_type"]+" == "+real_type
                        add_name_replace(name_replace, "Get"+prop["name"], gfunc["name"]+"_Get"+prop["name"])
                        
                        gfunc2 = classe["function"][start_getter_func+1]
                        assert gfunc2["return_type"] == real_type, gfunc2["return_type"]+" == "+real_type
                        assert gfunc2["name"] == gfunc["name"]
                        
                        gfunc3 = classe["function"][start_getter_func+2]
                        assert gfunc3["return_type"] == "int", gfunc3["return_type"]
                        add_name_replace(name_replace, prop["name"]+"Length", prop["name"]+"_Length")
                    
                        start_getter_func = start_getter_func + 2
                    func_counter = func_counter + 2 # object consume 3 function
                
                elif members[member_counter][0] == "EANEPBLOKJB": # string
                    assert prop["type"] == "string"
                    fs.write("\t"+prop["name"]+":"+prop["type"]+";\n")
                    
                    viewer_info["vars"].append({"name":prop["name"], "type":"string"})

                    gfunc = classe["function"][start_getter_func]
                    assert gfunc["return_type"] == prop["type"], gfunc["return_type"]+" == "+prop["type"]
                    
                    gfunc = classe["function"][start_getter_func + 1]
                    assert gfunc["return_type"] == "Nullable<ArraySegment<byte>>"
                    add_name_replace(name_replace, "Get"+prop["name"]+"Bytes", gfunc["name"]+"_GetBytes"+prop["name"])
                    
                    start_getter_func = start_getter_func + 1
                
                elif "AAABLJBBNJH" in members[member_counter][0]: # object
                    real_type = members[member_counter][0].replace("AAABLJBBNJH<","").replace(">","")
                    assert real_type == prop["type"]
                    fs.write("\t"+prop["name"]+":"+prop["type"]+";\n")

                    viewer_info["vars"].append({"name":prop["name"], "type":prop["type"]})
                    
                    gfunc = classe["function"][start_getter_func]
                    assert gfunc["return_type"] == prop["type"], gfunc["return_type"]+" == "+prop["type"]
                    
                    gfunc = classe["function"][start_getter_func + 1]
                    assert gfunc["return_type"] == prop["type"], gfunc["return_type"]+" == "+prop["type"]
                    add_name_replace(name_replace, "Get"+prop["name"], gfunc["name"]+"_Get"+prop["name"])
                    
                    start_getter_func = start_getter_func + 1
                else: # others
                    assert members[member_counter][0] == "int" or members[member_counter][0] == "uint"
                    assert members[member_counter][0] == prop["type"], members[member_counter][0]+" != "+prop["type"]
                    fs.write("\t"+prop["name"]+":"+prop["type"]+";\n")

                    viewer_info["vars"].append({"name":prop["name"], "type":prop["type"]})
                    
                    gfunc = classe["function"][start_getter_func]
                    assert gfunc["return_type"] == prop["type"], gfunc["return_type"]+" == "+prop["type"]
                    
                property_counter = property_counter + 1
                member_counter = member_counter + 1
                start_getter_func = start_getter_func + 1
                if member_counter >= len(members):
                    assert property_counter >= len(classe["property"])
                    state = 20
            elif state == 20:
                assert func["static"] == True and func["return_type"] == "AAABLJBBNJH<"+classe["name"]+">"
                add_name_replace(name_replace, "End"+classe["name"], gfunc["name"]+"_End"+classe["name"])
                
            func_counter = func_counter + 1
        fs.write("}\n\n\n")

        viewer_data[classe["name"]] = viewer_info

with open("name_replace.json","w") as fs:
    fs.write(json.dumps(name_replace))

with open("viewer_data.json", "w") as fs:
    fs.write(json.dumps(viewer_data))
