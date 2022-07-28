import frida, sys, json, os, time, subprocess
import jwt # install pyjwt

ss = """
var state = {};
Interceptor.attach(Module.findExportByName(null, "open"), {
    onEnter: function (args) {
		if(!state.dllbind)
		{
			var moduleaddr = Module.findBaseAddress("libil2cpp.so");
			if(moduleaddr)
			{
				state.dllbind = true;
				console.log("il2cpp loaded");
				/*var receivejson = resolveAddress('libil2cpp.so', '0x0', '0x18F2B50');
				Interceptor.attach(receivejson,
					function (args)
					{
						var size = Memory.readU32(this.context.r1.add(8));
						var string = Memory.readUtf16String(this.context.r1.add(12), size);
						send({"name":"jsonData", "data":string});
					}
				);*/
				var initsakasho = resolveAddress('libil2cpp.so', '0x0', '0x2E6B344');
				Interceptor.attach(initsakasho, {
					onLeave:function (retval)
					{
						var decryptjson = resolveAddress('libsakasho.so', '0x0', '0x00059480', true);
						Interceptor.attach(decryptjson,
							function (args)
							{
								var buf = Memory.readByteArray(this.context.r3, 120);
								send("key", buf);
							}
						);
					}
					}
				);
			}
		}
    },
    onLeave: function (retval) {
    }
});
function resolveAddress(name, idaBase, idaAddr, thumb = false) {
    var baseAddr = Module.findBaseAddress(name);
    console.log('[+] BaseAddr of ' + name + ': ' + baseAddr);
      
    // Calculate offset in memory from base address in IDA database
    var offset = ptr(idaAddr).sub(idaBase);
      
    // Add current memory base address to offset of function to monitor
    var result = baseAddr.add(offset);
      
	if(thumb)
		result = ptr(result.toInt32() | 0x1);
	  
    // Write location of function in memory to console
    console.log('[+] Address in memory: ' + result);
    return result;
	
}
"""

javass = """

Java.perform(function () {
	var bx = Java.use("bx");
	
	var PrintWriter = Java.use("java.io.PrintWriter");
	var FileOutputStream = Java.use("java.io.FileOutputStream");
	var fileCounter = 0;
	
	bx.a.overload().implementation = function()
	{
		var data = {"info":{},"in":{"name":""}, "out":{"name":""}};
		
		var methodURL = "";
		var requestHeaders = "";
		var responseHeaders = "";
		var responseBody = "";
		var Connection = this.b.value;
		var localCounter = fileCounter++;
		var randprotect = Math.floor(Math.random() * 100);

		var requestURL = Connection.getURL().toString();
		var requestMethod = Connection.getRequestMethod();
		var requestProperties
		methodURL = requestMethod + " " + requestURL;
		var dumpinput = !requestURL.includes("/1246/")
		
		if(dumpinput)
			console.log(methodURL)
		else
			console.log(methodURL+" : Ignore dlded file")
		
		var myFileIn = null;
		if(dumpinput)
			myFileIn = FileOutputStream.$new("/storage/emulated/0/Android/data/com.dena.a12024374/files/httprequest_"+localCounter+"_"+randprotect+".in");
		
		data["info"]["method"] = requestMethod;
		data["info"]["url"] = requestURL;

		data["info"]["request_data"] = {"no_keys":[]};
		if (Connection.getRequestProperties) {
		  var Keys = Connection.getRequestProperties().keySet().toArray();
		  var Values = Connection.getRequestProperties().values().toArray();
		  for (var key in Keys) {
			if (Keys[key] && Keys[key] !== null && Values[key]) {
			  data["info"]["request_data"][Keys[key]] = Values[key].toString();
			} else if (Values[key]) {
			  data["info"]["request_data"]["no_keys"].push(Values[key].toString());
			}
		  }
		}
		
		var byArray = this.c.value.c;
		if (Connection.getDoOutput() && byArray != null && byArray.value.length != 0)
		{
			data["in"]["name"] = "httprequest_"+localCounter+"_"+randprotect+".out"
			var myFileOut = FileOutputStream.$new("/storage/emulated/0/Android/data/com.dena.a12024374/files/httprequest_"+localCounter+"_"+randprotect+".out");
			myFileOut.write(byArray.value);
			myFileOut.close();
		}
		
		var res = this.a.call(this);
		
		data["info"]["headerFields"] = {"no_keys":[]};
		if (Connection.getHeaderFields) {
		  var Keys = Connection.getHeaderFields().keySet().toArray();
		  var Values = Connection.getHeaderFields().values().toArray();
		  for (var key in Keys) {
			if (Keys[key] && Keys[key] !== null && Values[key]) {
			  data["info"]["headerFields"][Keys[key]] = Values[key].toString();
			} else if (Values[key]) {
			  data["info"]["headerFields"]["no_keys"].push(Values[key].toString());
			}
		  }
		}
		
		var readData = this.d.value;
		
		if(myFileIn)
		{
			myFileIn.write(readData);
			myFileIn.close();
			data["in"]["name"] = "httprequest_"+localCounter+"_"+randprotect+".in"
		}
		
		send(data);
		
		return res;
	}
});
"""

adb_path = input("Enter Adb/Nox_adb path to automatically download datas : (ie : c:/Nox/bin/nox_adb.exe) : ")

if adb_path == "" or not os.path.isfile(adb_path):
	print(adb_path+" not found")
	exit(1)
	
output_path = input("Enter output path (default : utamacross_dump) : ")
if output_path == "" :
	output_path = "utamacross_dump"
	
output_path += "/"+str((int)(time.time() * 1000))
	
if not os.path.isdir(output_path):
	print("Create output directory "+output_path)
	os.mkdir(output_path)

if adb_path != "":
	print("Game will start. Once done, close it to download datas");

json_keys = []
json_crypted_queue = []

def decypher(data, internalKey):
	for i in range(len(data)):
		keyChar = internalKey[(i+1) % len(internalKey)]
		dataChar = data[i]
		if (keyChar & 7) == 0:
			dataChar = dataChar ^ keyChar
		else:
			b1 = -keyChar & 7
			b2 = keyChar & 7
			dataChar = (dataChar >> b1 | dataChar << b2)
		data[i] = dataChar & 0xFF

def try_decrypt(request):
	for key in json_keys:
		try:
			file_data = bytearray(request["data"][:])
			decypher(file_data, key)
			data = jwt.decode(bytes(file_data), options={"verify_signature": False}, algorithms="HS256")
			#print("Write "+output_path+"/"+request["filename"]+".json");
			with open(output_path+"/"+request["filename"]+".json", "w") as f:
				json.dump(data, f, indent=4);
				return
		except BaseException as err:
			print(err)
			pass
	print("request not decrypted, requeue "+request["filename"])
	json_crypted_queue.append(request)

def try_decrypt_queue():
	global json_crypted_queue
	cur_queue = json_crypted_queue.copy();
	json_crypted_queue = []
	for request in cur_queue:
		try_decrypt(request)

data_path = "/storage/emulated/0/Android/data/com.dena.a12024374/files/"
session = None
device = frida.get_usb_device(timeout=1)
pid = device.spawn(["com.dena.a12024374"])
session = device.attach(pid, realm='emulated')
script = session.create_script(ss)
def on_message(message, data):
	if message["type"] == "send":
		if type(message["payload"]) is dict:
			if "name" in message["payload"] and message["payload"]["name"] == "jsonData":
				#print(message["payload"]["data"])
				jsonData = json.loads(message["payload"]["data"]);
				nowTime = (int)(time.time() * 1000)
				filename = ""
				filename += str(nowTime)
				params = []
				for a in jsonData.keys():
					if not "SAKASHO_CURRENT" in a:
						params.append(a)
				if len(params) > 0:
					filename += "_" + "_".join(params)
				filename += ".json"
				print("Write "+filename);
				with open(output_path+"/"+filename, "w") as f:
					json.dump(jsonData, f, indent=4);
				return
			if "info" in message["payload"]:
				jsonData = message["payload"]["info"];
				nowTime = (int)(time.time() * 1000)
				filename = ""
				filename += str(nowTime)
				cleanpath = "".join(x for x in jsonData["url"] if (x.isalnum() or x in "_-"))
				cleanpath = cleanpath[:50]
				filename += "_"+jsonData["method"]+"_"+cleanpath
				#print("Write "+filename);
				with open(output_path+"/"+filename+".json", "w") as f:
					json.dump(jsonData, f, indent=4);
				if message["payload"]["out"]["name"] != "":
					subprocess.call([adb_path, "pull", data_path+message["payload"]["out"]["name"], output_path+"/"])
					with open(output_path+"/"+message["payload"]["out"]["name"], "rb") as f:
						outData = f.read()
					os.remove(output_path+"/"+message["payload"]["out"]["name"])
					if outData[0] == 123:
						outData = json.loads(outData.decode("utf-8"));
						with open(output_path+"/"+filename+".out.json", "w") as f:
							json.dump(outData, f, indent=4);
					else:
						try_decrypt({"filename":filename+".out", "data":outData})
				
				if message["payload"]["in"]["name"] != "":
					subprocess.call([adb_path, "pull", data_path+message["payload"]["in"]["name"], output_path+"/"])
					with open(output_path+"/"+message["payload"]["in"]["name"], "rb") as f:
						inData = f.read()
					os.remove(output_path+"/"+message["payload"]["in"]["name"])
					if inData[0] == 123:
						inData = json.loads(inData.decode("utf-8"));
						with open(output_path+"/"+filename+".in.json", "w") as f:
							json.dump(inData, f, indent=4);
					else:
						try_decrypt({"filename":filename+".in", "data":inData})
				return
		if message["payload"] == "key":
			key_str = data
			if not key_str in json_keys:
				print("New json decrypt key : "+key_str.decode("utf-8"))
				json_keys.append(key_str)
				try_decrypt_queue()
				global session
				session.detach()
			return
	print(message)
	if data:
		print(str(data))
	
def on_detached():
	print("Game closed.")
	
	try_decrypt_queue()
	global json_crypted_queue
	for request in json_crypted_queue:
		#print("Write "+output_path+"/"+request["filename"]);
		with open(output_path+"/"+request["filename"], "wb") as f:
			f.write(request["data"]);
	json_crypted_queue = []
	
	if adb_path != "":
		print("Start copying local save files")
		dirlist = ["40", "50", "60", "mx", "SaveData", "sys"]
		for a in dirlist:
			subprocess.call([adb_path, "pull", data_path+a, output_path+"/"])
	
	print("Done, hit CTRL-C to exit")
	
script.on('message', on_message)
script.load()


session2 = device.attach(pid)
session2.on('detached', on_detached)
scriptjava = session2.create_script(javass)
scriptjava.on('message', on_message)
scriptjava.load();

device.resume(pid)
sys.stdin.read()