
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
using XeApp.Game.Adv;

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
        {
            //Export Tips texts
            PoFile poFile = new PoFile();
            BCKMELFCKKN_Tips tipsDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KNMFNBEOGON_Tips;
            for(int i = 0; i < tipsDb.CDENCMNHNGA.Count; i++)
            {
                string prfx = string.Format("tips_{0:D4}_title", i);
                poFile.translationData.Add(prfx, tipsDb.CDENCMNHNGA[i].ADCMNODJBGJ_Title);
                prfx = string.Format("tips_{0:D4}_msg", i);
                poFile.translationData.Add(prfx, tipsDb.CDENCMNHNGA[i].JONNCMDGMKA_Message);
            }
            string p = PoPath.Replace("{name}", "tipsDb_text");
            Directory.CreateDirectory(p);
            poFile.SaveFile(p + "messages_full.pot", isTemplate:true);
            poFile.SaveFile(p + "messages.pot", isTemplate:true, stripEmpty:true);
            poFile.SaveFile(p + "jp.po", stripEmpty:true);
        }
        {
            //Export VcItem texts
            PoFile poFile = new PoFile();
            DKJMDIFAKKD_VcItem vcDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KCCDBKIOLDJ_VcItem;
            for(int i = 0; i < vcDb.CDENCMNHNGA.Count; i++)
            {
                string prfx = string.Format("vcitem_{0:D4}_title", i);
                poFile.translationData.Add(prfx, vcDb.CDENCMNHNGA[i].OPFGFINHFCE_Name);
                prfx = string.Format("vcitem_{0:D4}_desc", i);
                poFile.translationData.Add(prfx, vcDb.CDENCMNHNGA[i].KLMPFGOCBHC_Desc);
            }
            string p = PoPath.Replace("{name}", "tipsDb_text");
            Directory.CreateDirectory(p);
            poFile.SaveFile(p + "messages_full.pot", isTemplate:true);
            poFile.SaveFile(p + "messages.pot", isTemplate:true, stripEmpty:true);
            poFile.SaveFile(p + "jp.po", stripEmpty:true);
        }
        {
            //Export TutoPict texts
            PoFile poFile = new PoFile();
            PJANOOPJIDE_TutorialPict tutoDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KIBMNCOLJNC_TutorialPict;
            for(int i = 0; i < tutoDb.CDENCMNHNGA.Count; i++)
            {
                for(int j = 0; j < tutoDb.CDENCMNHNGA[i].ADCMNODJBGJ_Titles.Length; j++)
                {
                    string prfx = string.Format("tutopict_{0:D4}_{1:D4}_title", i, j);
                    poFile.translationData.Add(prfx, tutoDb.CDENCMNHNGA[i].ADCMNODJBGJ_Titles[j]);
                }
                for(int j = 0; j < tutoDb.CDENCMNHNGA[i].JONNCMDGMKA_Messages.Length; j++)
                {
                    string prfx = string.Format("tutopict_{0:D4}_{1:D4}_msg", i, j);
                    poFile.translationData.Add(prfx, tutoDb.CDENCMNHNGA[i].JONNCMDGMKA_Messages[j]);
                }
            }
            string p = PoPath.Replace("{name}", "tutoPictDb_text");
            Directory.CreateDirectory(p);
            poFile.SaveFile(p + "messages_full.pot", isTemplate:true);
            poFile.SaveFile(p + "messages.pot", isTemplate:true, stripEmpty:true);
            poFile.SaveFile(p + "jp.po", stripEmpty:true);
        }
        {
            // Export Adv strings
            PoFile poFile = new PoFile();
            GPMHOAKFALE_Adventure advDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EFMAIKAHFEK_Adventure;
            for(int i = 0; i < advDb.CDENCMNHNGA.Count; i++)
            {
                if(advDb.CDENCMNHNGA[i].PPEGAKEIEGM_Enabled == 2)
                {
                    AdvScriptData adv_data = new AdvScriptData();
                    bool done = false;
                    adv_data.Load(advDb.CDENCMNHNGA[i].KKPPFAHFOJI_FileId, () =>
                    {
                        done = true;
                    });
                    while(!done)
                        yield return null;
                    for(int j = 0; j < adv_data.GetMessageCount(); j++)
                    {
                        string prfx = string.Format("adv_{0:D4}_{1:D4}_msg", advDb.CDENCMNHNGA[i].KKPPFAHFOJI_FileId, j);
                        poFile.translationData.Add(prfx, adv_data.GetMessage(j));
                    }
                }
            }
            string p = PoPath.Replace("{name}", "adv_text");
            Directory.CreateDirectory(p);
            poFile.SaveFile(p + "messages_full.pot", isTemplate:true);
            poFile.SaveFile(p + "messages.pot", isTemplate:true, stripEmpty:true);
            poFile.SaveFile(p + "jp.po", stripEmpty:true);
        }
        {
            // Export TutoMiniAdv strings
            PoFile poFile = new PoFile();
            ILLPGHGGKLL_TutorialMiniAdv blockDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LINHIDCNAMG_TutorialMiniAdv;
            for(int i = 0; i < blockDb.CDENCMNHNGA.Count; i++)
            {
                for(int j = 0; j < blockDb.CDENCMNHNGA[i].JONNCMDGMKA_Messages.Length; j++)
                {
                    string prfx = string.Format("tuto_miniadv_{0:D4}_{1:D4}_msg", i, j);
                    poFile.translationData.Add(prfx, blockDb.CDENCMNHNGA[i].JONNCMDGMKA_Messages[j]);
                }
            }
            string p = PoPath.Replace("{name}", "tutoMiniAdvDb_text");
            Directory.CreateDirectory(p);
            poFile.SaveFile(p + "messages_full.pot", isTemplate:true);
            poFile.SaveFile(p + "messages.pot", isTemplate:true, stripEmpty:true);
            poFile.SaveFile(p + "jp.po", stripEmpty:true);
        }
        {
            // Export Anketo strings
            PoFile poFile = new PoFile();
            IPJBAPLFECP_Anketo blockDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OILKBADFBOK_Anketo;
            for(int i = 0; i < blockDb.CDENCMNHNGA.Count; i++)
            {
                {
                    string prfx = string.Format("anketo_{0:D4}_question", i);
                    poFile.translationData.Add(prfx, blockDb.CDENCMNHNGA[i].ADCMNODJBGJ_Question);
                }
                for(int j = 0; j < blockDb.CDENCMNHNGA[i].BNMCMNPPPCI_ChoiceText.Length; j++)
                {
                    string prfx = string.Format("anketo_{0:D4}_{1:D4}_choice", i, j);
                    poFile.translationData.Add(prfx, blockDb.CDENCMNHNGA[i].BNMCMNPPPCI_ChoiceText[j]);
                }
            }
            string p = PoPath.Replace("{name}", "anketoDb_text");
            Directory.CreateDirectory(p);
            poFile.SaveFile(p + "messages_full.pot", isTemplate:true);
            poFile.SaveFile(p + "messages.pot", isTemplate:true, stripEmpty:true);
            poFile.SaveFile(p + "jp.po", stripEmpty:true);
        }
        {
            // Export helpBrowser strings
            PoFile poFile = new PoFile();
            KCDJCKCKKFM_HelpBrowser blockDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LOJAMHAADBF_HelpBrowser;
            for(int i = 0; i < blockDb.LOMHJBIJMOD.Length; i++)
            {
                if(blockDb.LOMHJBIJMOD[i].PLALNIIBLOF == 2)
                {
                    string prfx = string.Format("category_{0:D4}_name", i);
                    poFile.translationData.Add(prfx, blockDb.LOMHJBIJMOD[i].OPFGFINHFCE);
                }
            }
            for(int i = 0; i < blockDb.FBJCBCOEBBB.Length; i++)
            {
                for(int j = 0; j < blockDb.FBJCBCOEBBB[i].EBEMOEPADJB.Length; j++)
                {
                    string prfx = string.Format("help_{0:D4}_{1:D4}_name", i, j);
                    poFile.translationData.Add(prfx, blockDb.FBJCBCOEBBB[i].EBEMOEPADJB[j].OPFGFINHFCE);
                }
                for(int j = 0; j < blockDb.FBJCBCOEBBB[i].OJMEIBNMLNP.Length; j++)
                {
                    string prfx = string.Format("wiki_{0:D4}_{1:D4}_name", i, j);
                    poFile.translationData.Add(prfx, blockDb.FBJCBCOEBBB[i].OJMEIBNMLNP[j].OPFGFINHFCE);
                }
            }
            string p = PoPath.Replace("{name}", "helpBrowserDb_text");
            Directory.CreateDirectory(p);
            poFile.SaveFile(p + "messages_full.pot", isTemplate:true);
            poFile.SaveFile(p + "messages.pot", isTemplate:true, stripEmpty:true);
            poFile.SaveFile(p + "jp.po", stripEmpty:true);
        }
        {
            // Export homeBg strings
            PoFile poFile = new PoFile();
            ALJHJDHNFFB_HomeBg blockDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PFEKKPABPKL_HomeBg;
            for(int i = 0; i < blockDb.CDENCMNHNGA.Count; i++)
            {
                string prfx = string.Format("homebg_{0:D4}_name", i);
                poFile.translationData.Add(prfx, blockDb.CDENCMNHNGA[i].OPFGFINHFCE_Name);
            }
            string p = PoPath.Replace("{name}", "homeBgDb_text");
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

            for(int i = 0; i < (int)eBank.End; i++)
            {
                //Import texts
                PoFile poFile = new PoFile();
                
                string p = PoPath.Replace("{name}", ((eBank)i).ToString());
                poFile.LoadFile(p + "messages_full.pot", clear:true);
                poFile.LoadFile(p + "jp.po");
                poFile.LoadFile(p + lang + ".po");

                poFile.WriteToArchiveAsBankData(archive, ((eBank)i).ToString() + ".bytes");
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
        tipsDb_text,
        vcItemDb_text,
        tutoPictDb_text,
        tutoMiniAdvDb_text,
        anketoDb_text,
        helpBrowserDb_text,
        homeBgDb_text,
        room_text,
        music_text,
        adv_text,
        string_literals,
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

    private static string Translate(eBank bank, string key, string def)
    {
        if(RuntimeSettings.CurrentSettings.ShowStringUsed)
            return bank.ToString() + "/" + key;
        if(banks[(int)bank] != null)
        {
            return banks[(int)bank].GetMessageByLabel(key);
        }
        else
        {
            if(RuntimeSettings.CurrentSettings.DumpStringUsed)
				UnityEngine.Debug.Log("Using string "+bank.ToString()+" "+key+" => "+def);
            return def;
        }
    }

    public static string TranslateSnsRoomName(int roomId, string def)
    {
        string prfx = string.Format("room_name_{0:D4}_txt", roomId);
        return Translate(eBank.snsDb_text, prfx, def);
    }
    public static string TranslateSnsCharaName(int roomId, string def)
    {
        string prfx = string.Format("chara_name_{0:D4}_txt", roomId);
        return Translate(eBank.snsDb_text, prfx, def);
    }
    public static string TranslateRoomText(int textId, string def)
    {
        string prfx = string.Format("message_{0:D4}_txt", textId);
        return Translate(eBank.room_text, prfx, def);
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
        return Translate(eBank.music_text, prfx, def);
    }

    public static string TranslateStringLiterals(string k, string def)
    {
        return Translate(eBank.string_literals, k, def);
    }

    public static string TranslateTipsTitle(int tipsId, string def)
    {
        string prfx = string.Format("tips_{0:D4}_title", tipsId);
        return Translate(eBank.tipsDb_text, prfx, def);
    }

    public static string TranslateTipsMessage(int tipsId, string def)
    {
        string prfx = string.Format("tips_{0:D4}_msg", tipsId);
        return Translate(eBank.tipsDb_text, prfx, def);
    }

    public static string TranslateVcItemName(int vcItemId, string def)
    {
        string prfx = string.Format("vcitem_{0:D4}_title", vcItemId);
        return Translate(eBank.vcItemDb_text, prfx, def);
    }

    public static string TranslateVcItemDesc(int vcItemId, string def)
    {
        string prfx = string.Format("vcitem_{0:D4}_desc", vcItemId);
        return Translate(eBank.vcItemDb_text, prfx, def);
    }

    public static string TranslateTutoPictTitle(int tutoId, int strId, string def)
    {
        string prfx = string.Format("tutopict_{0:D4}_{1:D4}_title", tutoId, strId);
        return Translate(eBank.tutoPictDb_text, prfx, def);
    }

    public static string TranslateTutoPictMessage(int tutoId, int strId, string def)
    {
        string prfx = string.Format("tutopict_{0:D4}_{1:D4}_msg", tutoId, strId);
        return Translate(eBank.tutoPictDb_text, prfx, def);
    }

    public static string TranslateAdventureMessage(int advId, int strId, string def)
    {
        string prfx = string.Format("adv_{0:D4}_{1:D4}_msg", advId, strId);
        return Translate(eBank.adv_text, prfx, def);
    }

    public static string TranslateTutoMiniAdventureMessage(int advId, int strId, string def)
    {
        string prfx = string.Format("tuto_miniadv_{0:D4}_{1:D4}_msg", advId, strId);
        return Translate(eBank.tutoMiniAdvDb_text, prfx, def);
    }

    public static string TranslateAnketoQuestion(int anketoId, string def)
    {
        string prfx = string.Format("anketo_{0:D4}_question", anketoId);
        return Translate(eBank.anketoDb_text, prfx, def);
    }

    public static string TranslateAnketoChoice(int anketoId, int strId, string def)
    {
        string prfx = string.Format("anketo_{0:D4}_{1:D4}_choice", anketoId, strId);
        return Translate(eBank.anketoDb_text, prfx, def);
    }

    public static string TranslateHelpCategory(int catId, string def)
    {
        string prfx = string.Format("category_{0:D4}_name", catId);
        return Translate(eBank.helpBrowserDb_text, prfx, def);
    }

    public static string TranslateHelpName(int helpId, int strId, string def)
    {
        string prfx = string.Format("help_{0:D4}_{1:D4}_name", helpId, strId);
        return Translate(eBank.helpBrowserDb_text, prfx, def);
    }

    public static string TranslateHelpWikiName(int helpId, int strId, string def)
    {
        string prfx = string.Format("wiki_{0:D4}_{1:D4}_name", helpId, strId);
        return Translate(eBank.helpBrowserDb_text, prfx, def);
    }

    public static string TranslateHomeBgName(int homeBgId, string def)
    {
        string prfx = string.Format("homebg_{0:D4}_name", homeBgId);
        return Translate(eBank.homeBgDb_text, prfx, def);
    }
}