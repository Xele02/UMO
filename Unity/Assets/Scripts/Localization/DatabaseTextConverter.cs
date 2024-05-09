#if UNITY_EDITOR
using System;
using System.Collections;
using System.IO;
using UnityEditor;
using UnityEngine;
using XeApp.Game;
using XeApp.Game.Common;
using XeSys;

public static class DatabaseTextConverter
{
    public static string PoPath = Application.dataPath + "../../../Localization/Database/{name}/po/";

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
    }
}
#endif