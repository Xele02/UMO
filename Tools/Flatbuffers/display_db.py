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
allFiles = tarFile.getmembers();

file_bufs = {}


# LPPGENBEECK.IIEMACPEEBJ
# BMHPFEELLNP.HEGEKFMJNCC(DBBGALAPFGC
# JKFNAKIBOCI.BECBBFKCOIH

file_bufs["./adventure.bytes"] = {"buffer":None, "class":"EADNHFHCKIA"}                     # GPMHOAKFALE
file_bufs["./anketo.bytes"] = {"buffer":None, "class":"EBDJIPDILLC"}                        # IPJBAPLFECP
file_bufs["./asset.bytes"] = {"buffer":None, "class":"OHOIIACCJAH"}                         # LFPJCEMANCK
file_bufs["./bingo.bytes"] = {"buffer":None, "class":"JGABIAKLIJE"}                         # JKICPBIIHNE
file_bufs["./board.bytes"] = {"buffer":None, "class":"ANBBEHKIHLJ"}                         # KOGHKIODHPA
file_bufs["./bonus_vc.bytes"] = {"buffer":None, "class":"FKNGHMMLIJF"}                      # HHJHIFJIKAC
file_bufs["./campaign_diva.bytes"] = {"buffer":None, "class":"JKIJAPMNHFJ"}                 # AIPOFGJGPKI
file_bufs["./compo.bytes"] = {"buffer":None, "class":"MNENFGHNPFJ"}                         # HHPEMHHCKBE
file_bufs["./cos_item.bytes"] = {"buffer":None, "class":"OOKJGIANFNP"}                      # PLPBJOFICEJ
file_bufs["./costume.bytes"] = {"buffer":None, "class":"OGCAPIHPNLC"}                       # LCLCCHLDNHJ
file_bufs["./deco_item.bytes"] = {"buffer":None, "class":"MOHBMMEAEON"}                     # NDBFKHKMMCE
file_bufs["./deco_item_init.bytes"] = {"buffer":None, "class":"OJJJPOGDHKM"}                # JEPMHCPBIGD
file_bufs["./deco_point.bytes"] = {"buffer":None, "class":"JHNNMJEDOLG"}                    # GAEBMAEDNAN
file_bufs["./deco_set_item.bytes"] = {"buffer":None, "class":"JBMPGMCNGNP"}                 # BBLECJKKKLA
file_bufs["./deco_sp_setting.bytes"] = {"buffer":None, "class":"NCJELDIPMGO"}               # NEGELNMPEPH
file_bufs["./deco_stamp.bytes"] = {"buffer":None, "class":"GLBBAECGHNN"}                    # IHFIAFDLAAK
file_bufs["./diva.bytes"] = {"buffer":None, "class":"OEMMCAHOCEL"}                          # HPBPIOPPDCB
file_bufs["./diva2.bytes"] = {"buffer":None, "class":"PKLIOFHMFFC"}                         # HMIJOOPHJLB
file_bufs["./drop.bytes"] = {"buffer":None, "class":"BECPINGJFLI"}                          # NBPHJDCOECH
file_bufs["./emblem.bytes"] = {"buffer":None, "class":"MLCJDNPCFHI"}                        # IHGBPAJMJFK
file_bufs["./enemy.bytes"] = {"buffer":None, "class":"PCIEJLEICFK"}                         # MHDFCLCMDKO
file_bufs["./energy_item.bytes"] = {"buffer":None, "class":"AMMFBOPDMFI"}                   # JKDKODAPGBJ
file_bufs["./episode.bytes"] = {"buffer":None, "class":"KFHCGBOADLE"}                       # KMOGDEOKHPG
file_bufs["./epi_item.bytes"] = {"buffer":None, "class":"CBOPKMNJJIA"}                      # KIICLPJJBNL
file_bufs["./event_gacha_ticket.bytes"] = {"buffer":None, "class":"ONCFNGIBLHO"}            # JNGINLMOJKH
file_bufs["./event_godiva_ranking.bytes"] = {"buffer":None, "class":"AIAIHLIBPLM"}          # JPJGOECJFEE
file_bufs["./event_item.bytes"] = {"buffer":None, "class":"DOLNHKKDNCC"}                    # HGLPLKKBBOL
file_bufs["./event_raid_item.bytes"] = {"buffer":None, "class":"AGKBCKADDKJ"}               # NKBOMKGFGIO
file_bufs["./event_ticket.bytes"] = {"buffer":None, "class":"AIAGNLHOHPF"}                  # ABBOEIPOBLJ
file_bufs["./event_weekday.bytes"] = {"buffer":None, "class":"CFFBOCDCDCJ"}                 # DKCJADHKGAN
file_bufs["./event_story.bytes"] = {"buffer":None, "class":"HKILNANKLLB"}                   # FBIOJHECAHB
file_bufs["./exp.bytes"] = {"buffer":None, "class":"NLMKDBJHCCM"}                           # JJOPEDJCCJK
file_bufs["./gacha_limit.bytes"] = {"buffer":None, "class":"ACCMHHCLELG"}                   # BIHCALIAJII
file_bufs["./gacha_ticket.bytes"] = {"buffer":None, "class":"NMOEOEOBDAD"}                  # PMDCIJMMNGK
file_bufs["./game.bytes"] = {"buffer":None, "class":"PFOCKFPDBBD"}                          # LDDDBPNGGIN
file_bufs["./grow_item.bytes"] = {"buffer":None, "class":"GAPIOFFIFKN"}                     # KEEKEFEPKFN
file_bufs["./help_browser.bytes"] = {"buffer":None, "class":"JAFMFLPLHEB"}                  # KCDJCKCKKFM
file_bufs["./home_bg.bytes"] = {"buffer":None, "class":"CHFNKBBHDGM"}                       # ALJHJDHNFFB
file_bufs["./home_pickup.bytes"] = {"buffer":None, "class":"KIPJDHHEGND"}                   # JJCJKALEIAC
file_bufs["./home_voice.bytes"] = {"buffer":None, "class":"BNMAJCFEFOK"}                    # NPCCDMKJBMM
file_bufs["./rich_banner.bytes"] = {"buffer":None, "class":"OGOJIHOJMHD"}                   # JKMLBONMAHD
file_bufs["./intimacy.bytes"] = {"buffer":None, "class":"KHKJEJCOAHJ"}                      # GJALOMELEHD
file_bufs["./limit_over.bytes"] = {"buffer":None, "class":"GPDPAKFCMMO"}                    # LLKLAKGKNLD
file_bufs["./limited_item.bytes"] = {"buffer":None, "class":"BHNBHGFFDII"}                  # EGLOKAEIHCB
file_bufs["./medal.bytes"] = {"buffer":None, "class":"PCGHGHNPJDO"}                         # HHFFOACILKG
file_bufs["./monthly_pass.bytes"] = {"buffer":None, "class":"PBIDNKDHLOB"}                  # KBCCGHLCFNO
file_bufs["./music.bytes"] = {"buffer":None, "class":"JKFNAKIBOCI"}                         # LPPGENBEECK
file_bufs["./mv_ticket.bytes"] = {"buffer":None, "class":"MHNDFPBJOGK"}                     # GJAEGCMKMEK
file_bufs["./offer.bytes"] = {"buffer":None, "class":"DNCDFDOLLLP"}                         # LGHIPHEDCNC
file_bufs["./pilot.bytes"] = {"buffer":None, "class":"IBBBNNBOBLD"}                         # MPOEMCEBBJH
file_bufs["./present_item.bytes"] = {"buffer":None, "class":"JPNGMOOGNIA"}                  # MDACFBPPIHD
file_bufs["./quest.bytes"] = {"buffer":None, "class":"EEBLKICOJPH"}                         # DHOJHGODBAB
file_bufs["./rareup_item.bytes"] = {"buffer":None, "class":"FJGGBKGOPEG"}                   # CKDOOBKOJBB
file_bufs["./scene.bytes"] = {"buffer":None, "class":"IGLOKFOAKDB"}                         # MLIBEPGADJH
file_bufs["./shop.bytes"] = {"buffer":None, "class":"DFHBOFFBKDB"}                          # BKPAPCMJKHE
file_bufs["./skill.bytes"] = {"buffer":None, "class":"HPKOMBFEADM"}                         # JNKEEAOKNCI
file_bufs["./sns.bytes"] = {"buffer":None, "class":"DEMFEEEPCCO"}                           # BOKMNHAFJHF
file_bufs["./sp_item.bytes"] = {"buffer":None, "class":"EAHMHMEDAOG"}                       # PPNFHHPJOKK
file_bufs["./story.bytes"] = {"buffer":None, "class":"PLONLLOGMEJ"}                         # LAEGMENIEDB
file_bufs["./system.bytes"] = {"buffer":None, "class":"DHFKAKFHFOL"}                        # PEBFNABDJDI
file_bufs["./tips.bytes"] = {"buffer":None, "class":"BGECCLJCLID"}                          # BCKMELFCKKN
file_bufs["./title_banner.bytes"] = {"buffer":None, "class":"CJMBCLHMFBF"}                  # JOHKNBEFHHP
file_bufs["./tutorial_mini_adv.bytes"] = {"buffer":None, "class":"JAAOECLAKNC"}             # ILLPGHGGKLL
file_bufs["./tutorial_pict.bytes"] = {"buffer":None, "class":"PCIPKGNLLBO"}                 # PJANOOPJIDE
file_bufs["./uc_item.bytes"] = {"buffer":None, "class":"CFOEKHAFGOJ"}                       # DGDIEDDPNNG
file_bufs["./val_item.bytes"] = {"buffer":None, "class":"OOKJGIANFNP"}                      # INDEPDKCJDD
file_bufs["./val_skill.bytes"] = {"buffer":None, "class":"HACLELJLADO"}                     # GKFMJAHKEMA
file_bufs["./valkyrie.bytes"] = {"buffer":None, "class":"LDLCKBMOFJC"}                      # JPIANKEOOMB
file_bufs["./vc_item.bytes"] = {"buffer":None, "class":"LBAGNFKGHIB"}                       # DKJMDIFAKKD
file_bufs["./highscore_rating.bytes"] = {"buffer":None, "class":"KMANHBAOCLJ"}              # HGPEFPFODHO
file_bufs["./limited_compo_item.bytes"] = {"buffer":None, "class":"IOOJDNCIHIC"}            # JHAAHJNEBOG
file_bufs["./schedule.bytes"] = {"buffer":None, "class":"NGIOPBLNBDJ"}                      # IMMAOANGPNK
file_bufs["./schema_hash.bytes"] = {"buffer":None, "class":"ODNNPHLAMGH"}                   # 
file_bufs["./version.bytes"] = {"buffer":None, "class":"JHCHMCIFCND"}                       # IMMAOANGPNK

# FKMOKDCJFEN$$JKBOOMAPOBL
# "event_april_fool_a";		
# "event_april_fool_b";
# "event_april_fool_c";
# "event_april_fool_d";
# "event_april_fool_e";
# "event_april_fool_f";
# "event_april_fool_g";
# "event_april_fool_h";
# "event_april_fool_i";
# "event_battle_a";
# "event_battle_b";
# "event_battle_c";
# "event_box_gacha_a";
# "event_box_gacha_b";
# "event_box_gacha_c";
# "event_box_gacha_d";
# "event_box_gacha_e";
# "event_box_gacha_f";
# "event_collection_a";
# "event_collection_b";
# "event_collection_c";
# "event_godiva_a";
# "event_godiva_b";
# "event_godiva_c";
# "event_mission_a";
# "event_mission_b";
# "event_mission_c";
# "event_present_campaign_a
# "event_raid_a";
# "event_raid_b";
# "event_raid_c";
# "event_raid_d";
# "event_raidlobby_a";
# "event_raidlobby_b";
# "event_raidlobby_c";
# "event_raidlobby_d";
# "event_quest_a";
# "event_quest_b";
# "event_quest_c";
# "event_score_a";
# "event_score_b";
# "event_score_c";
# "event_score_d";
# "event_score_e";
# "event_score_f";
# "event_sp_a";

file_bufs["./message_common_jp_00000000.bytes"] = {"buffer":None, "class":"Unity TextAsset"}
file_bufs["./message_diva001_jp_00000000.bytes"] = {"buffer":None, "class":"Unity TextAsset"}
file_bufs["./message_diva002_jp_00000000.bytes"] = {"buffer":None, "class":"Unity TextAsset"}
file_bufs["./message_diva003_jp_00000000.bytes"] = {"buffer":None, "class":"Unity TextAsset"}
file_bufs["./message_diva004_jp_00000000.bytes"] = {"buffer":None, "class":"Unity TextAsset"}
file_bufs["./message_diva005_jp_00000000.bytes"] = {"buffer":None, "class":"Unity TextAsset"}
file_bufs["./message_diva006_jp_00000000.bytes"] = {"buffer":None, "class":"Unity TextAsset"}
file_bufs["./message_diva007_jp_00000000.bytes"] = {"buffer":None, "class":"Unity TextAsset"}
file_bufs["./message_diva008_jp_00000000.bytes"] = {"buffer":None, "class":"Unity TextAsset"}
file_bufs["./message_diva009_jp_00000000.bytes"] = {"buffer":None, "class":"Unity TextAsset"}
file_bufs["./message_diva010_jp_00000000.bytes"] = {"buffer":None, "class":"Unity TextAsset"}
file_bufs["./message_master_jp_00000000.bytes"] = {"buffer":None, "class":"Unity TextAsset"}
file_bufs["./message_music_jp_00000000.bytes"] = {"buffer":None, "class":"Unity TextAsset"}
file_bufs["./message_menu_jp_00000000.bytes"] = {"buffer":None, "class":"Unity TextAsset"}
file_bufs["./message_room_text.bytes"] = {"buffer":None, "class":"Bit Converter XeApp.Game.Common.SNSRoomTextData$$Init"}

for file in allFiles:
    if not file.name in file_bufs and file.isfile():
        file_bufs[file.name] = {"buffer":None, "class":None}

for fb in file_bufs:
    f = tarFile.extractfile(fb);
    buf=f.read()
    if buf[0:1] == b'{':
        file_bufs[fb]["class"] = "Json"
    #if file_bufs[fb]["class"] == None:
    #    print(fb+" "+str(buf[:10]))
    buf = bytearray(buf)
    file_bufs[fb]["buffer"] = buf
    
file_bufs = dict(sorted(file_bufs.items()))

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

def get_py_type_str(obj):
    if type(obj) is dict:
        return "dict"
    if type(obj) is list:
        return "list"
    if type(obj) is int:
        return "int"
    if type(obj) is float:
        return "float"
    if type(obj) is str:
        return "string" 
    print(str(type(obj))+" unknown")
    return str(type(obj))

class mytree(wx.TreeCtrl):

    def __init__(self, parent, id, pos, size, style, file_bufs):
        wx.TreeCtrl.__init__(self, parent, id, pos, size, style)
        self.file_bufs = file_bufs
        root = self.AddRoot("Root")

        for k in file_bufs:
            if file_bufs[k]["class"] == None:
                self.AppendItem(root, k)
            else:
                className = file_bufs[k]["class"]
                object=None
                if className in table_def:
                    nodeData = table_def[className].copy()
                    module_=getattr(outputpy, className)
                    class_=getattr(module_, className)
                    method_=getattr(class_, "GetRootAs"+className)
                    object = method_(file_bufs[k]["buffer"], 0)
                elif className == "Json":
                    object = json.loads((file_bufs[k]["buffer"].decode("utf-8")))
                    className += "_"+get_py_type_str(object)
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
        elif "JSon" in data:
            if type(data["JSon"]) is dict:
                for k in data["JSon"]:
                    self.AddObjectNode(item, "Json_"+get_py_type_str(data["JSon"][k]), k, data["JSon"][k])
            elif type(data["JSon"]) is list:
                numChild = len(data["JSon"])
                for i in range(numChild):
                    self.AddObjectNode(item, "Json_"+get_py_type_str(data["JSon"][i]), str(i), data["JSon"][i])
            else:
                print("Unknow type "+str(type(data["JSon"])))
        data["childCreated"] = True

    def AddObjectNode(self, item, className, label, object):
        child = self.AppendItem(item, label)
        if className == "uint":
            self.SetItemText(child, label+" : "+str(object))
        elif className == "int" or className == "Json_int":
            self.SetItemText(child, label+" : "+str(object))
        elif className == "Json_float":
            self.SetItemText(child, label+" : "+str(object))
        elif className == "string" or className == "Json_string":
            self.SetItemText(child, label+" : "+(object if type(object) is str else object.decode('utf-8')))
        elif className == "Json_list" or className == "Json_dict":
            self.SetItemHasChildren(child)
            nodeData = {}
            nodeData["JSon"] = object
            self.SetItemData(child, nodeData)
        elif className in table_def:
            self.SetItemHasChildren(child)
            nodeData = table_def[className].copy()
            nodeData["FB"] = object
            self.SetItemData(child, nodeData)

class treepanel(wx.Panel):

    def __init__(self, parent, file_bufs):
        wx.Panel.__init__(self, parent)

        self.tree = mytree(self, wx.ID_ANY, wx.DefaultPosition, wx.DefaultSize,
                           wx.TR_HAS_BUTTONS + wx.TR_HIDE_ROOT + wx.TR_LINES_AT_ROOT, file_bufs)

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



