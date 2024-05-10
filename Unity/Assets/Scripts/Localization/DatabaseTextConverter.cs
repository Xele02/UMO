
#if UNITY_EDITOR
using UnityEditor;
#endif
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using XeApp.Game;
using XeApp.Game.Common;
using XeSys;

public static class DatabaseTextConverter
{
    public static string PoPath = Application.dataPath + "/../../Localization/Database/{name}/po/";
    public static string LocalDatabasePath = Application.dataPath + "/Resources/Localizations/{name}/";
    public static List<string> supportedLanguage = new List<string>() { "fr" };

#if UNITY_EDITOR
	[MenuItem("UMO/Localization/Export Database strings", validate = true)]
	static bool ExportCostumeListAvaiable()
	{
		return Application.isPlaying && IMMAOANGPNK.HHCJCDFCLOB != null && IMMAOANGPNK.HHCJCDFCLOB.LNAHEIEIBOI_Initialized;
	}

    [MenuItem("UMO/Localization/Export Database strings")]
    public static void GeneratePoFiles()
    {
        GameManager.Instance.StartCoroutineWatched(GeneratePoFilesCoroutine());
    }

    public static IEnumerator GeneratePoFilesCoroutine()
    {
        MessageLoader.Create();
		MessageManager.Create();

		foreach(var sheet in Enum.GetValues(typeof(MessageLoader.eSheet)))
		{
			MessageLoader.Instance.Request((MessageLoader.eSheet)sheet, 0);
            yield return MessageLoader.Instance.WaitForDone(GameManager.Instance);
		}
		
		foreach(var sheet in Enum.GetValues(typeof(MessageLoader.eSheet)))
		{
            yield return null;
            if(MessageManager.Instance.IsExistBank(sheet.ToString()))
            {
                MessageBank bank = MessageManager.Instance.GetBank(sheet.ToString());
                if(bank != null)
                {
                    if((MessageLoader.eSheet)sheet == MessageLoader.eSheet.master)
                    {
                        PoFile poFileCommon = new PoFile();
                        PoFile poFileSns = new PoFile();
                        PoFile poFileScenes = new PoFile();
                        for(int i = 0; i < bank.count; i++)
                        {
                            string s = bank.GetLabel(i);
                            if(s.StartsWith("sns_"))
                                poFileSns.translationData.Add(s, bank.GetMessageByIndex(i));
                            else if(s.StartsWith("sn_"))
                                poFileScenes.translationData.Add(s, bank.GetMessageByIndex(i));
                            else
                                poFileCommon.translationData.Add(s, bank.GetMessageByIndex(i));
                        }
                        {
                            string p = PoPath.Replace("{name}", sheet.ToString());
                            Directory.CreateDirectory(p);
                            poFileCommon.SaveFile(p + "messages_full.pot", isTemplate:true);
                            poFileCommon.SaveFile(p + "messages.pot", isTemplate:true, stripEmpty:true);
                            poFileCommon.SaveFile(p + "jp.po", stripEmpty:true);
                        }
                        {
                            string p = PoPath.Replace("{name}", sheet.ToString()+"_sns");
                            Directory.CreateDirectory(p);
                            poFileSns.SaveFile(p + "messages_full.pot", isTemplate:true);
                            poFileSns.SaveFile(p + "messages.pot", isTemplate:true, stripEmpty:true);
                            poFileSns.SaveFile(p + "jp.po", stripEmpty:true);
                        }
                        {
                            string p = PoPath.Replace("{name}", sheet.ToString()+"_scene");
                            Directory.CreateDirectory(p);
                            poFileScenes.SaveFile(p + "messages_full.pot", isTemplate:true);
                            poFileScenes.SaveFile(p + "messages.pot", isTemplate:true, stripEmpty:true);
                            poFileScenes.SaveFile(p + "jp.po", stripEmpty:true);
                        }
                    }
                    else
                    {
                        PoFile poFile = new PoFile();
                        for(int i = 0; i < bank.count; i++)
                        {
                            poFile.translationData.Add(bank.GetLabel(i), bank.GetMessageByIndex(i));
                        }
                        string p = PoPath.Replace("{name}", sheet.ToString());
                        Directory.CreateDirectory(p);
                        poFile.SaveFile(p + "messages_full.pot", isTemplate:true);
                        poFile.SaveFile(p + "messages.pot", isTemplate:true, stripEmpty:true);
                        poFile.SaveFile(p + "jp.po", stripEmpty:true);
                    }
                }
            }
		}

        {
            // Export music texts
            PoFile poFile = new PoFile();
            for(int i = 0; ; i++)
            {
                MusicTextDatabase.TextInfo data = Database.Instance.musicText.Get(i);
                if(data == null)
                    break;
                string prfx = string.Format("musicName_{0:D4}_", i);
                poFile.translationData.Add(prfx + "musicname", data.musicName);
                poFile.translationData.Add(prfx + "officialName", data.officialName);
                poFile.translationData.Add(prfx + "vocalName", data.vocalName);
                poFile.translationData.Add(prfx + "vocalNameLF", data.vocalNameLF);
                poFile.translationData.Add(prfx + "description", data.description);
                poFile.translationData.Add(prfx + "storyDesc", data.storyDesc);
                poFile.translationData.Add(prfx + "storyTitle", data.storyTitle);
            }
            string p = PoPath.Replace("{name}", "music_text");
            Directory.CreateDirectory(p);
            poFile.SaveFile(p + "messages_full.pot", isTemplate:true);
            poFile.SaveFile(p + "messages.pot", isTemplate:true, stripEmpty:true);
            poFile.SaveFile(p + "jp.po", stripEmpty:true);
        }
        {
            //Export SNS data
            PoFile poFile = new PoFile();
            for(int i = 0; i < Database.Instance.roomText.textData.MessageCount; i++)
            {
                string txt = Database.Instance.roomText.textData.FindMessage(i);
                string prfx = string.Format("message_{0:D4}_txt", i);
                poFile.translationData.Add(prfx, txt);
            }
            string p = PoPath.Replace("{name}", "room_text");
            Directory.CreateDirectory(p);
            poFile.SaveFile(p + "messages_full.pot", isTemplate:true);
            poFile.SaveFile(p + "messages.pot", isTemplate:true, stripEmpty:true);
            poFile.SaveFile(p + "jp.po", stripEmpty:true);
        }
        {
            //Export SNSDb texts
            PoFile poFile = new PoFile();
            BOKMNHAFJHF_Sns snsDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns;
            for(int i = 0; i < snsDb.NPKPBDIDBBG_Room.Count; i++)
            {
                if(snsDb.NPKPBDIDBBG_Room[i].PPEGAKEIEGM_Enabled == 2 && snsDb.NPKPBDIDBBG_Room[i].MALFHCHNEFN_Room > 0)
                {
                    string prfx = string.Format("room_name_{0:D4}_txt", i);
                    poFile.translationData.Add(prfx, snsDb.NPKPBDIDBBG_Room[i].OPFGFINHFCE_Name);
                }
            }
            for(int i = 0; i < snsDb.KHCACDIKJLG_Characters.Count; i++)
            {
                string prfx = string.Format("chara_name_{0:D4}_txt", i);
                poFile.translationData.Add(prfx, snsDb.KHCACDIKJLG_Characters[i].OPFGFINHFCE_Name);
            }
            string p = PoPath.Replace("{name}", "snsDb_text");
            Directory.CreateDirectory(p);
            poFile.SaveFile(p + "messages_full.pot", isTemplate:true);
            poFile.SaveFile(p + "messages.pot", isTemplate:true, stripEmpty:true);
            poFile.SaveFile(p + "jp.po", stripEmpty:true);
        }
    }

    [MenuItem("UMO/Localization/Import Database strings")]
    public static void GenerateGameFiles()
    {
        foreach(var lang in supportedLanguage)
        {
            CBBJHPBGBAJ_Archive archive = new CBBJHPBGBAJ_Archive();
            foreach(var sheet in Enum.GetValues(typeof(MessageLoader.eSheet)))
            {
                PoFile poFile = new PoFile();
                if((MessageLoader.eSheet)sheet == MessageLoader.eSheet.master)
                {
                    {
                        string p = PoPath.Replace("{name}", sheet.ToString());
                        poFile.LoadFile(p + "messages_full.pot", clear:true); // Read the full template for filling all key
                        poFile.LoadFile(p + "jp.po"); // Read the jp one for filling non translated files
                        poFile.LoadFile(p + lang + ".po");
                    }
                    {
                        string p = PoPath.Replace("{name}", sheet.ToString()+"_sns");
                        poFile.LoadFile(p + "messages_full.pot");
                        poFile.LoadFile(p + "jp.po");
                        poFile.LoadFile(p + lang + ".po");
                    }
                    {
                        string p = PoPath.Replace("{name}", sheet.ToString()+"_scene");
                        poFile.LoadFile(p + "messages_full.pot");
                        poFile.LoadFile(p + "jp.po");
                        poFile.LoadFile(p + lang + ".po");
                    }
                }
                else
                {
                    string p = PoPath.Replace("{name}", sheet.ToString());
                    poFile.LoadFile(p + "messages_full.pot", clear:true);
                    poFile.LoadFile(p + "jp.po");
                    poFile.LoadFile(p + lang + ".po");
                }

                poFile.WriteToArchiveAsBankData(archive, string.Format("{0}_{1:D8}.bytes", MessageLoader.s_path[(int)sheet], 0));
            }

            {
                //Import SNSDb texts
                PoFile poFile = new PoFile();
                
                string p = PoPath.Replace("{name}", "snsDb_text");
                poFile.LoadFile(p + "messages_full.pot", clear:true);
                poFile.LoadFile(p + "jp.po");
                poFile.LoadFile(p + lang + ".po");

                poFile.WriteToArchiveAsBankData(archive, "snsDb_text.bytes");
            }

            {
                //Import room_text
                PoFile poFile = new PoFile();
                
                string p = PoPath.Replace("{name}", "room_text");
                poFile.LoadFile(p + "messages_full.pot", clear:true);
                poFile.LoadFile(p + "jp.po");
                poFile.LoadFile(p + lang + ".po");

                poFile.WriteToArchiveAsBankData(archive, "room_text.bytes");
            }

            {
                //Import music_text
                PoFile poFile = new PoFile();
                
                string p = PoPath.Replace("{name}", "music_text");
                poFile.LoadFile(p + "messages_full.pot", clear:true);
                poFile.LoadFile(p + "jp.po");
                poFile.LoadFile(p + lang + ".po");

                poFile.WriteToArchiveAsBankData(archive, "music_text.bytes");
            }

            // Save the archive
            // Format from CBBJHPBGBAJ_Archive: (tar format)
            //  0 : Filename Encoding.UTF8 "./" + name
            //  124 : Taille (en texte)
            //   156 : 0
            //   512 : Data
            // Jump next 512
            if(archive.KGHAJGGMPKL_Files.Count > 0)
            {
                string p = LocalDatabasePath.Replace("{name}", "Database") + lang + ".bytes";
                Directory.CreateDirectory(new FileInfo(p).DirectoryName);
                using(FileStream stream = new FileStream(p, FileMode.Create, FileAccess.Write))
                {
                    using(BinaryWriter writer = new BinaryWriter(stream))
                    {
                        int offset = 0;
                        for(int i = 0; i < archive.KGHAJGGMPKL_Files.Count; i++)
                        {
                            byte[] buffer = new byte[512];
                            DateTime TheEpoch = new DateTime(1970, 1, 1, 0, 0, 0);
                            Array.Clear(buffer,0, buffer.Length);
                            string strName = "./"+archive.KGHAJGGMPKL_Files[i].OPFGFINHFCE_Name.Replace("\0",string.Empty);
                            Encoding.UTF8.GetBytes(strName.PadRight(100, '\0')).CopyTo(buffer, 0);
                            Encoding.ASCII.GetBytes(Convert.ToString(511, 8).PadLeft(7, '0')).CopyTo(buffer, 100);
                            Encoding.ASCII.GetBytes(Convert.ToString(61, 8).PadLeft(7, '0')).CopyTo(buffer, 108);
                            Encoding.ASCII.GetBytes(Convert.ToString(61, 8).PadLeft(7, '0')).CopyTo(buffer, 116);
                            Encoding.ASCII.GetBytes(Convert.ToString(archive.KGHAJGGMPKL_Files[i].DBBGALAPFGC_Data.Length, 8).PadLeft(11, '0')).CopyTo(buffer, 124);
                            Encoding.ASCII.GetBytes(Convert.ToString((long)(DateTime.Now - TheEpoch).TotalSeconds, 8).PadLeft(11, '0')).CopyTo(buffer, 136);
                            buffer[156] = (byte)'0';

                            byte[] spaces = Encoding.ASCII.GetBytes("        ");
                            spaces.CopyTo(buffer, 148);
                            long headerChecksum = 0;
                            foreach (byte b in buffer)
                            {
                                headerChecksum += b;
                            }

                            Encoding.ASCII.GetBytes(Convert.ToString(headerChecksum, 8).PadLeft(6, '0')).CopyTo(buffer, 148);

                            writer.Write(buffer);
                            offset += 512;

                            writer.Write(archive.KGHAJGGMPKL_Files[i].DBBGALAPFGC_Data);
                            offset += archive.KGHAJGGMPKL_Files[i].DBBGALAPFGC_Data.Length;
                            while((offset % 512) != 0)
                            {
                                writer.Write((byte)0);
                                offset++;
                            }
                        }
                    }
                }
            }
        }
    }
#endif
    enum eBank
    {
        snsDb_text,
        room_text,
        music_text,
        End,
    }
    static MessageBank[] banks = new MessageBank[(int)eBank.End];

    public static IEnumerator LoadAdditionalLanguageBank()
    {
        if(!string.IsNullOrEmpty(RuntimeSettings.CurrentSettings.Language))
        {
            StringBuilder str = new StringBuilder(64);
            str.AppendFormat("Localizations/Database/{0}", RuntimeSettings.CurrentSettings.Language);
            Dictionary<string,string> dic = new Dictionary<string, string>(1);
            bool isDone = false;
            ResourcesManager.Instance.Request(str.ToString(), (FileResultObject fro) =>
            {
                CBBJHPBGBAJ_Archive tar = new CBBJHPBGBAJ_Archive();
                tar.KHEKNNFCAOI_Load((fro.unityObject as TextAsset).bytes);
                for(int i = 0; i < (int)eBank.End; i++)
                {
                    StringBuilder fileName = new StringBuilder(64);
                    fileName.AppendFormat("{0}.bytes", ((eBank)i).ToString());
                    string name = fileName.ToString();
                    CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File file = tar.KGHAJGGMPKL_Files.Find((CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File x) => {
                        //0x111780C
                        return x.OPFGFINHFCE_Name.Contains(name);
                    });
                    if(file != null)
                    {
                        MessageBank bank = new MessageBank();
                        bank.Setup(file.DBBGALAPFGC_Data, ((eBank)i).ToString());
                        banks[i] = bank;
                    }
                }
                isDone = true;
                return true;
            }, dic, 0);
            ResourcesManager.Instance.Load();
            while(!isDone)
                yield return null;
        }
    }

    public static string TranslateSnsRoomName(int roomId, string def)
    {
        string prfx = string.Format("room_name_{0:D4}_txt", roomId);
        if(RuntimeSettings.CurrentSettings.ShowStringUsed)
            return "snsDb_text/" + prfx;
        if(banks[(int)eBank.snsDb_text] != null)
        {
            return banks[(int)eBank.snsDb_text].GetMessageByLabel(prfx);
        }
        else
        {
            if(RuntimeSettings.CurrentSettings.DumpStringUsed)
				UnityEngine.Debug.Log("Using string snsDb_text "+prfx+" => "+def);
            return def;
        }
    }
    public static string TranslateSnsCharaName(int roomId, string def)
    {
        string prfx = string.Format("chara_name_{0:D4}_txt", roomId);
        if(RuntimeSettings.CurrentSettings.ShowStringUsed)
            return "snsDb_text/" + prfx;
        if(banks[(int)eBank.snsDb_text] != null)
        {
            return banks[(int)eBank.snsDb_text].GetMessageByLabel(prfx);
        }
        else
        {
            if(RuntimeSettings.CurrentSettings.DumpStringUsed)
				UnityEngine.Debug.Log("Using string snsDb_text "+prfx+" => "+def);
            return def;
        }
    }
    public static string TranslateRoomText(int textId, string def)
    {
        string prfx = string.Format("message_{0:D4}_txt", textId);
        if(RuntimeSettings.CurrentSettings.ShowStringUsed)
            return "room_text/" + prfx;
        if(banks[(int)eBank.room_text] != null)
        {
            return banks[(int)eBank.room_text].GetMessageByLabel(prfx);
        }
        else
        {
            if(RuntimeSettings.CurrentSettings.DumpStringUsed)
				UnityEngine.Debug.Log("Using string room_text "+prfx+" => "+def);
            return def;
        }
    }
    public enum MusicTextType
    {
        MusicName,
        OfficialName,
        VocalName,
        VocalNameLF,
        Description,
        StoryDesc,
        StoryTitle
    }
    public static string TranslateMusicText(MusicTextType type, int musicId, string def)
    {
        string prfx = "";
        switch(type)
        {
            case MusicTextType.MusicName:
                prfx = string.Format("musicName_{0:D4}_musicname", musicId);
                break;
            case MusicTextType.OfficialName:
                prfx = string.Format("musicName_{0:D4}_officialName", musicId);
                break;
            case MusicTextType.VocalName:
                prfx = string.Format("musicName_{0:D4}_vocalName", musicId);
                break;
            case MusicTextType.VocalNameLF:
                prfx = string.Format("musicName_{0:D4}_vocalNameLF", musicId);
                break;
            case MusicTextType.Description:
                prfx = string.Format("musicName_{0:D4}_description", musicId);
                break;
            case MusicTextType.StoryDesc:
                prfx = string.Format("musicName_{0:D4}_storyDesc", musicId);
                break;
            case MusicTextType.StoryTitle:
                prfx = string.Format("musicName_{0:D4}_storyTitle", musicId);
                break;
            default:
                return def;
        }
        if(RuntimeSettings.CurrentSettings.ShowStringUsed)
            return "music_text/" + prfx;
        if(banks[(int)eBank.music_text] != null)
        {
            for(int i = 0; ; i++)
            {
                MusicTextDatabase.TextInfo data = Database.Instance.musicText.Get(i);
                if(data == null)
                    break;
            }
            return banks[(int)eBank.music_text].GetMessageByLabel(prfx);
        }
        else
        {
            if(RuntimeSettings.CurrentSettings.DumpStringUsed)
				UnityEngine.Debug.Log("Using string music_text "+prfx+" => "+def);
            return def;
        }
    }
}