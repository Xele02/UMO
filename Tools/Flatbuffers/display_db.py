import sys, os
sys.path.insert(1,os.path.dirname(os.path.abspath(__file__)) + "/outputpy/")

import tarfile
import flatbuffers
import outputpy
import wx
import importlib
import json

for name in os.listdir("outputpy"):
    if name.endswith(".py"):
         module = name[:-3]
         importlib.import_module("outputpy" + "." + module)

tarFile = tarfile.open(name="../../Unity/Assets/UMAssets/Database/cwc_1950939.bytes", mode="r")

file_bufs = {}

file_bufs["./music.bytes"] = {"buffer":None, "class":"JKFNAKIBOCI"}

for fb in file_bufs:
    f = tarFile.extractfile(fb);
    buf=f.read()
    buf = bytearray(buf)
    file_bufs[fb]["buffer"] = buf


table_def = {
	"JKFNAKIBOCI":{
	"vars":[
		{"name":"PMNLBNBKCDM", "type":"list", "inner_type":"IGBINOLLPPB"},
		{"name":"IPFGDNLPHFA", "type":"list", "inner_type":"CDCEKBNNJLL"}
	]},
	"IGBINOLLPPB":{
	"vars":[
		{"name":"HLCDELCABOF", "type":"uint"},
		{"name":"HOFPKKMIOAL", "type":"list", "inner_type":"uint"}
	]
	}
}
with open("viewer_data.json","r") as f:
    table_def = json.load(f)

class mytree(wx.TreeCtrl):

    def __init__(self, parent, id, pos, size, style, file_bufs):
        wx.TreeCtrl.__init__(self, parent, id, pos, size, style)
        self.file_bufs = file_bufs
        root = self.AddRoot("Root")

        for k in file_bufs:
            #node = self.AppendItem(root, k)
            #self.SetItemHasChildren(node)
            #self.SetItemData(node, file_bufs[k].copy())
            className = file_bufs[k]["class"]
            nodeData = table_def[className].copy()
            module_=getattr(outputpy, className)
            class_=getattr(module_, className)
            method_=getattr(class_, "GetRootAs"+className)
            object = method_(file_bufs[k]["buffer"], 0)
            self.AddObjectNode(root, className, k+":"+className, object)

        self.Bind(wx.EVT_TREE_ITEM_EXPANDING, self.OnItemExpanding)

    def OnItemExpanding(self, event):
        item = event.GetItem()
        data = self.GetItemData(item)

        if data == None:
            return

        if "childCreated" in data:
            return

        if "FB" in data:
            for var in data["vars"]:
                if var["type"] == "list":
                    child = self.AppendItem(item, var["name"]+":["+var["inner_type"]+"]")
                    self.SetItemHasChildren(child)
                    numChild = getattr(data["FB"], var["name"]+"Length")()
                    for i in range(numChild):
                        self.AddObjectNode(child, var["inner_type"], str(i), getattr(data["FB"],var["name"])(i))
                else:
                    self.AddObjectNode(item, var["type"], var["name"]+":"+var["type"], getattr(data["FB"], var["name"])())
        data["childCreated"] = True

    def AddObjectNode(self, item, className, label, object):
        child = self.AppendItem(item, label)
        if className == "uint":
            self.SetItemText(child, label+" : "+str(object))
        elif className == "int":
            self.SetItemText(child, label+" : "+str(object))
        elif className == "string":
            self.SetItemText(child, label+" : "+str(object))
        elif className in table_def:
            self.SetItemHasChildren(child)
            nodeData = table_def[className].copy()
            nodeData["FB"] = object
            self.SetItemData(child, nodeData)

class treepanel(wx.Panel):

    def __init__(self, parent, file_bufs):
        wx.Panel.__init__(self, parent)

        self.tree = mytree(self, wx.ID_ANY, wx.DefaultPosition, wx.DefaultSize,
                           wx.TR_HAS_BUTTONS | wx.TR_HIDE_ROOT, file_bufs)

        sizer = wx.BoxSizer(wx.VERTICAL)
        sizer.Add(self.tree, 1, wx.EXPAND)
        self.SetSizer(sizer)


class mainframe(wx.Frame):

    def __init__(self, file_bufs):
        wx.Frame.__init__(self, parent=None, title='UtaMacross database viewer')
        panel = treepanel(self, file_bufs)
        self.Show()


if __name__ == '__main__':
    app = wx.App(redirect=False)
    frame = mainframe(file_bufs)
    app.MainLoop()



