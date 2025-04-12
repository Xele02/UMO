
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
using UnityEngine.UI;
using XeApp.Core;
using XeSys.Gfx;

public static class DatabaseTextConverter
{
    public static string PoPath = Application.dataPath + "/../../Localization/Database/{name}/po/";
    public static string LocalDatabasePath = Application.dataPath + "/Resources/Localizations/{name}/";
    public static List<string> supportedLanguage = new List<string>() { "fr", "en", "zh_Hans", "ko" };

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
            for(int i = 0; i < snsDb.NPKPBDIDBBG_Rooms.Count; i++)
            {
                if(snsDb.NPKPBDIDBBG_Rooms[i].PPEGAKEIEGM_Enabled == 2 && snsDb.NPKPBDIDBBG_Rooms[i].MALFHCHNEFN_Room > 0)
                {
                    string prfx = string.Format("room_name_{0:D4}_txt", i);
                    poFile.translationData.Add(prfx, snsDb.NPKPBDIDBBG_Rooms[i].OPFGFINHFCE_Name);
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
            string p = PoPath.Replace("{name}", "vcItemDb_text");
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
            List<int> advIds = new List<int>() { 1, 2, 3, 4, 5, 6 };
            for(int i = 0; i < advDb.CDENCMNHNGA_List.Count; i++)
            {
                if(advDb.CDENCMNHNGA_List[i].PPEGAKEIEGM_Enabled == 2)
                {
                    if(!advIds.Contains(advDb.CDENCMNHNGA_List[i].KKPPFAHFOJI_FileId))
                        advIds.Add(advDb.CDENCMNHNGA_List[i].KKPPFAHFOJI_FileId);
                }
            }
            for(int i = 0; i < advIds.Count; i++)
            {
                AdvScriptData adv_data = new AdvScriptData();
                bool done = false;
                adv_data.Load(advIds[i], () =>
                {
                    done = true;
                });
                while(!done)
                    yield return null;
                for(int j = 0; j < adv_data.GetMessageCount(); j++)
                {
                    string prfx = string.Format("adv_{0:D6}_{1:D4}_msg", advIds[i], j);
                    poFile.translationData.Add(prfx, adv_data.GetMessage(j));
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
        {
            // Export shopDb strings
            PoFile poFile = new PoFile();
            BKPAPCMJKHE_Shop blockDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop;
            for(int i = 0; i < blockDb.CDENCMNHNGA.Count; i++)
            {
                string prfx = string.Format("shop_{0:D4}_name", i);
                poFile.translationData.Add(prfx, blockDb.CDENCMNHNGA[i].NEMKDKDIIDK_ShopName);
            }
            string p = PoPath.Replace("{name}", "shopDb_text");
            Directory.CreateDirectory(p);
            poFile.SaveFile(p + "messages_full.pot", isTemplate:true);
            poFile.SaveFile(p + "messages.pot", isTemplate:true, stripEmpty:true);
            poFile.SaveFile(p + "jp.po", stripEmpty:true);
        }
        {
            // Export bingoDb strings
            PoFile poFile = new PoFile();
            JKICPBIIHNE_Bingo blockDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FPOIPGFFAPE_Bingo;
            for (int i = 0; i < blockDb.JJAICEAEGKF.Count; i++)
            {
                for(int j = 0; j < blockDb.JJAICEAEGKF[i].DPGMFEGFCJN.Count; j++)
                {
                    for(int k = 0; k < blockDb.JJAICEAEGKF[i].DPGMFEGFCJN[j].MFMGDFACBON.Count; k++)
                    {
                        string prfx = string.Format("bingo_{0:D4}_{1:D4}_{2:D4}_desc", blockDb.JJAICEAEGKF[i].PPFNGGCBJKC, blockDb.JJAICEAEGKF[i].DPGMFEGFCJN[j].PPFNGGCBJKC, blockDb.JJAICEAEGKF[i].DPGMFEGFCJN[j].MFMGDFACBON[k].PPFNGGCBJKC);
                        poFile.translationData.Add(prfx, blockDb.JJAICEAEGKF[i].DPGMFEGFCJN[j].MFMGDFACBON[k].FEMMDNIELFC);
                        prfx = string.Format("bingo_{0:D4}_{1:D4}_{2:D4}_cond", blockDb.JJAICEAEGKF[i].PPFNGGCBJKC, blockDb.JJAICEAEGKF[i].DPGMFEGFCJN[j].PPFNGGCBJKC, blockDb.JJAICEAEGKF[i].DPGMFEGFCJN[j].MFMGDFACBON[k].PPFNGGCBJKC);
                        poFile.translationData.Add(prfx, blockDb.JJAICEAEGKF[i].DPGMFEGFCJN[j].MFMGDFACBON[k].JEPGJJJBFLN);
                    }
                }
            }
            string p = PoPath.Replace("{name}", "bingo_text");
            Directory.CreateDirectory(p);
            poFile.SaveFile(p + "messages_full.pot", isTemplate:true);
            poFile.SaveFile(p + "messages.pot", isTemplate:true, stripEmpty:true);
            poFile.SaveFile(p + "jp.po", stripEmpty:true);
        }
        {
            // Export event strings
            PoFile poFile = new PoFile();
            List<string> blocksName = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PKOJMBICNHH_GetBlockNames();
            for(int sIdx = 0; sIdx < blocksName.Count; sIdx++)
            {
                ICFLJACCIKF_EventBattle blockDbBattle = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(blocksName[sIdx]) as ICFLJACCIKF_EventBattle;
                if(blockDbBattle != null)
                {
                    for (int i = 0; i < blockDbBattle.NNMPGOAGEOL_Missions.Count; i++)
                    {
                        string prfx = string.Format("mission_desc_{0}_{1:D4}", blockDbBattle.NNMPGOAGEOL_Missions[i].JOPOPMLFINI, blockDbBattle.NNMPGOAGEOL_Missions[i].PPFNGGCBJKC_Id);
                        poFile.translationData.Add(prfx, blockDbBattle.NNMPGOAGEOL_Missions[i].FEMMDNIELFC_Desc);
                        prfx = string.Format("mission_desc2_{0}_{1:D4}", blockDbBattle.NNMPGOAGEOL_Missions[i].JOPOPMLFINI, blockDbBattle.NNMPGOAGEOL_Missions[i].PPFNGGCBJKC_Id);
                        poFile.translationData.Add(prfx, blockDbBattle.NNMPGOAGEOL_Missions[i].BGBJPGEIEDE_DescBalloon);
                    }
                    for(int i = 0; i < blockDbBattle.LLCLJBEJOPM_BannerInfo.Count; i++)
                    {
                        string prfx = string.Format("event_banner_{0}_{1:D4}", blockDbBattle.JIKKNHIAEKG_BlockName, blockDbBattle.LLCLJBEJOPM_BannerInfo[i].PPFNGGCBJKC);
                        poFile.translationData.Add(prfx, blockDbBattle.LLCLJBEJOPM_BannerInfo[i].KLMPFGOCBHC_BannerText);
                    }
                }
                LNELCMNJPIC_EventGoDiva blockDbGoDiva = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(blocksName[sIdx]) as LNELCMNJPIC_EventGoDiva;
                if(blockDbGoDiva != null)
                {
                    for (int i = 0; i < blockDbGoDiva.NNMPGOAGEOL_Missions.Count; i++)
                    {
                        string prfx = string.Format("mission_desc_{0}_{1:D4}", blockDbGoDiva.NNMPGOAGEOL_Missions[i].JOPOPMLFINI, blockDbGoDiva.NNMPGOAGEOL_Missions[i].PPFNGGCBJKC_Id);
                        poFile.translationData.Add(prfx, blockDbGoDiva.NNMPGOAGEOL_Missions[i].FEMMDNIELFC_Desc);
                        prfx = string.Format("mission_desc2_{0}_{1:D4}", blockDbGoDiva.NNMPGOAGEOL_Missions[i].JOPOPMLFINI, blockDbGoDiva.NNMPGOAGEOL_Missions[i].PPFNGGCBJKC_Id);
                        poFile.translationData.Add(prfx, blockDbGoDiva.NNMPGOAGEOL_Missions[i].BGBJPGEIEDE_DescBalloon);
                    }
                    for(int i = 0; i < blockDbGoDiva.LLCLJBEJOPM_BannerInfo.Count; i++)
                    {
                        string prfx = string.Format("event_banner_{0}_{1:D4}", blockDbGoDiva.JIKKNHIAEKG_BlockName, blockDbGoDiva.LLCLJBEJOPM_BannerInfo[i].PPFNGGCBJKC);
                        poFile.translationData.Add(prfx, blockDbGoDiva.LLCLJBEJOPM_BannerInfo[i].KLMPFGOCBHC_BannerText);
                    }
                }
                KCGOMAFPGDD_EventAprilFool blockDbAprilFool = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(blocksName[sIdx]) as KCGOMAFPGDD_EventAprilFool;
                if(blockDbAprilFool != null)
                {
                    for (int i = 0; i < blockDbAprilFool.NNMPGOAGEOL_Missions.Count; i++)
                    {
                        string prfx = string.Format("mission_desc_{0}_{1:D4}", blockDbAprilFool.NNMPGOAGEOL_Missions[i].JOPOPMLFINI, blockDbAprilFool.NNMPGOAGEOL_Missions[i].PPFNGGCBJKC_Id);
                        poFile.translationData.Add(prfx, blockDbAprilFool.NNMPGOAGEOL_Missions[i].FEMMDNIELFC_Desc);
                        prfx = string.Format("mission_desc2_{0}_{1:D4}", blockDbAprilFool.NNMPGOAGEOL_Missions[i].JOPOPMLFINI, blockDbAprilFool.NNMPGOAGEOL_Missions[i].PPFNGGCBJKC_Id);
                        poFile.translationData.Add(prfx, blockDbAprilFool.NNMPGOAGEOL_Missions[i].BGBJPGEIEDE_DescBalloon);
                    }
                }
            }
            string p = PoPath.Replace("{name}", "events_text");
            Directory.CreateDirectory(p);
            poFile.SaveFile(p + "messages_full.pot", isTemplate:true);
            poFile.SaveFile(p + "messages.pot", isTemplate:true, stripEmpty:true);
            poFile.SaveFile(p + "jp.po", stripEmpty:true);
        }
    }

    [MenuItem("UMO/Localization/Import Database strings")]
    public static void GenerateGameFiles()
    {
        GenerateGameFiles2(LocalDatabasePath, PoPath, StringLiteralsConverter.PoPath);
    }

#endif
    public static void GenerateTmpGameFiles()
    {
        GenerateGameFiles2(Application.persistentDataPath + "/Localizations/{name}/", Application.persistentDataPath + "/Localization/Database/{name}/po/", Application.persistentDataPath + "/Localization/JpLiteralStrings/po/", keepUntransladedAsKey:RuntimeSettings.CurrentSettings.ShowStringUsed);
    }

    public static void GenerateGameFiles2(string outDir, string poPath, string poPath2, bool keepUntransladedAsKey = false)
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
                        string p = poPath.Replace("{name}", sheet.ToString());
                        poFile.KeyPrefix = sheet.ToString() + "/";
                        poFile.LoadFile(p + "messages_full.pot", clear:true); // Read the full template for filling all key
                        poFile.LoadFile(p + "jp.po", useKeyInsteadOfString:keepUntransladedAsKey); // Read the jp one for filling non translated files
                        poFile.LoadFile(p + lang + ".po");
                        // We need to add original jp item name as <key>_jp since they are used as product id and te code check the name
                        {
                            PoFile tmpFile = new PoFile();
                            tmpFile.LoadFile(p + "messages_full.pot", clear:true);
                            tmpFile.LoadFile(p + "jp.po");
                            // Copied from EKLNMHFCAOI, don't use EKLNMHFCAOI or it will initialize the static before the string are all loaded
                            string[] BJIECJAOMDJ = new string[45] {
                                "vc_0000", "vc_0001", "vc_gt_{0:D4}", "vc_0003", "sn_{0:D4}", "cos_{0:D4}", "vn_{0:D4}", "gn_{0:D4}", 
                                "ep_i_nm_{0:D4}", "em_nm_{0:D4}", "evn_{0:D4}", "et_nm_{0:D4}", "diva_{0:D2}", "cmp_nm_{0:D4}", "sns_nm_{0:D4}", 
                                "eng_nm_{0:D4}", "mvtk_nm_{0:D4}", "mdl_nm_{0:D4}", "bvc_nm_{0:D4}", "egt_nm_{0:D4}", "itp_nm_{0:D4}", 
                                "spitm_nm_{0:D4}", "cs_i_nm_{0:D4}", "rup_nm_{0:D4}", "lmitm_nm_{0:D4}", "vc_0004", "dc_itm_nm_{0:D4}_bg", 
                                "dc_itm_nm_{0:D4}_obj", "dc_itm_nm_{0:D4}_chr", "dc_itm_nm_{0:D4}_srf", "dc_itm_nm_{0:D4}_sp", "val_itm_nm_{0:D4}", 
                                "dcpt_nm_{0:D4}", "dc_itm_nm_{0:D4}_pst", "sn_{0:D4}", "sn_{0:D4}", "rd_i_nm_{0:D4}", "rd_mdl_nm_{0:D4}", 
                                "dc_stmp_nm_{0:D4}", "dc_set_nm_{0:D4}", "vff_nm_{0:D4}", "trs_nm_{0:D4}", "sk_nm_{0:D4}", "hm_bg_nm_{0:D4}", 
                                "gc_lm_nm_{0:D4}"
                            }; // 0xC
                            for(int i = 0; i < BJIECJAOMDJ.Length; i++)
                            {
                                string k = BJIECJAOMDJ[i].Replace("{0:D4}", "");
                                foreach(var it in tmpFile.translationData)
                                {
                                    if(it.Key.StartsWith(k))
                                    {
                                        poFile.translationData.Add(it.Key+"_jp", it.Value);
                                    }
                                }
                            }
                        }

                    }
                    {
                        string p = poPath.Replace("{name}", sheet.ToString()+"_sns");
                        poFile.KeyPrefix = sheet.ToString() + "_sns/";
                        poFile.LoadFile(p + "messages_full.pot");
                        poFile.LoadFile(p + "jp.po", useKeyInsteadOfString:keepUntransladedAsKey);
                        poFile.LoadFile(p + lang + ".po");
                    }
                    {
                        string p = poPath.Replace("{name}", sheet.ToString()+"_scene");
                        poFile.KeyPrefix = sheet.ToString() + "_scene/";
                        poFile.LoadFile(p + "messages_full.pot");
                        poFile.LoadFile(p + "jp.po", useKeyInsteadOfString:keepUntransladedAsKey);
                        poFile.LoadFile(p + lang + ".po");
                    }
                }
                else
                {
                    string p = poPath.Replace("{name}", sheet.ToString());
                    poFile.LoadFile(p + "messages_full.pot", clear:true);
                    poFile.LoadFile(p + "jp.po", useKeyInsteadOfString:keepUntransladedAsKey);
                    poFile.LoadFile(p + lang + ".po");
                }

                poFile.WriteToArchiveAsBankData(archive, string.Format("{0}_{1:D8}.bytes", MessageLoader.s_path[(int)sheet], 0));
            }

            for(int i = 0; i < (int)eBank.End; i++)
            {
                //Import texts
                PoFile poFile = new PoFile();
                if((eBank)i == eBank.string_literals)
                {
                    string p = poPath2;
                    poFile.KeyPrefix = ((eBank)i).ToString() + "/";
                    poFile.LoadFile(p + "messages.pot", clear:true);
                    poFile.LoadFile(p + "jp.po", useKeyInsteadOfString:keepUntransladedAsKey);
                    poFile.LoadFile(p + lang + ".po");
                }
                else
                {
                    string p = poPath.Replace("{name}", ((eBank)i).ToString());
                    poFile.KeyPrefix = ((eBank)i).ToString() + "/";
                    poFile.LoadFile(p + "messages_full.pot", clear:true);
                    poFile.LoadFile(p + "jp.po", useKeyInsteadOfString:keepUntransladedAsKey);
                    poFile.LoadFile(p + lang + ".po");
                    if( i == (int)eBank.music_text )
                    {
                        // Load original & romanized music names
                        PoFile poFile_ = new PoFile();
                        poFile_.LoadFile(p + "jp.po");
                        PoFile poFile2_ = new PoFile();
                        poFile2_.LoadFile(p + "ja_rm.po");

                        foreach(var data in poFile_.translationData)
                        {
                            if(data.Key.EndsWith("_musicname") || data.Key.EndsWith("_officialName"))
                            {
                                poFile.translationData.Add(data.Key + "_jp", data.Value);
                                if(poFile2_.translationData.ContainsKey(data.Key))
                                    poFile.translationData.Add(data.Key + "_jprm", poFile2_.translationData[data.Key]);
                            }
                        }
                    }
                }
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
                string p = outDir.Replace("{name}", "Database") + lang + ".bytes";
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
    public enum eBank
    {
        snsDb_text,
        tipsDb_text,
        vcItemDb_text,
        tutoPictDb_text,
        tutoMiniAdvDb_text,
        anketoDb_text,
        helpBrowserDb_text,
        homeBgDb_text,
        shopDb_text,
        room_text,
        music_text,
        adv_text,
        bingo_text,
        events_text,
        string_literals,
        End,
    }
    static MessageBank[] banks = new MessageBank[(int)eBank.End];

    public static IEnumerator LoadAdditionalLanguageBank()
    {
        if(!string.IsNullOrEmpty(RuntimeSettings.CurrentSettings.Language))
        {
            if(RuntimeSettings.CurrentSettings.UseTmpLocalizationFiles)
            {
                GenerateTmpGameFiles();
            }

            StringBuilder str = new StringBuilder(64);
            Dictionary<string,string> dic = new Dictionary<string, string>(1);
            bool isDone = false;
            Action<byte[]> OnDone = (byte[] bytes) =>
            {
                CBBJHPBGBAJ_Archive tar = new CBBJHPBGBAJ_Archive();
                tar.KHEKNNFCAOI_Load(bytes);
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
            };
            if(RuntimeSettings.CurrentSettings.UseTmpLocalizationFiles)
            {
                str.AppendFormat("{0}/Localizations/Database/{1}.bytes", Application.persistentDataPath, RuntimeSettings.CurrentSettings.Language);
                OnDone(File.ReadAllBytes(str.ToString()));
            }
            else
            {
                str.AppendFormat("Localizations/Database/{0}", RuntimeSettings.CurrentSettings.Language);
                ResourcesManager.Instance.Request(str.ToString(), (FileResultObject fro) =>
                {
                    OnDone((fro.unityObject as TextAsset).bytes);
                    return true;
                }, dic, 0);
                ResourcesManager.Instance.Load();
            }
            while(!isDone)
                yield return null;
        }
    }

    private static string Translate(eBank bank, string key, string def)
    {
        if(RuntimeSettings.CurrentSettings.ShowStringUsed && (banks[(int)bank] == null || !RuntimeSettings.CurrentSettings.UseTmpLocalizationFiles))
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
        StoryTitle,
        MusicName_jp,
        MusicName_rm,
        OfficialName_jp,
        OfficialName_rm
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
            case MusicTextType.MusicName_jp:
                prfx = string.Format("musicName_{0:D4}_musicname_jp", musicId);
                break;
            case MusicTextType.MusicName_rm:
                prfx = string.Format("musicName_{0:D4}_musicname_jprm", musicId);
                break;
            case MusicTextType.OfficialName_jp:
                prfx = string.Format("musicName_{0:D4}_officialName_jp", musicId);
                break;
            case MusicTextType.OfficialName_rm:
                prfx = string.Format("musicName_{0:D4}_officialName_jprm", musicId);
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
        string prfx = string.Format("adv_{0:D6}_{1:D4}_msg", advId, strId);
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

    public static string TranslateShopName(int shopId, string def)
    {
        string prfx = string.Format("shop_{0:D4}_name", shopId);
        return Translate(eBank.shopDb_text, prfx, def);
    }

    public static string TranslateBingo(int bingoId, int id2, int blockId, string def, int type)
    {
        string prfx = string.Format("bingo_{0:D4}_{1:D4}_{2:D4}_{3}", bingoId, id2, blockId, type == 0 ? "desc" : "cond");
        return Translate(eBank.bingo_text, prfx, def);
    }

    public static string TranslateEventMissionDesc(string event_db_name, int mission_id, string def)
    {
        string prfx = string.Format("mission_desc_{0}_{1:D4}", event_db_name, mission_id);
        return Translate(eBank.events_text, prfx, def);
    }

    public static string TranslateEventMissionDesc2(string event_db_name, int mission_id, string def)
    {
        string prfx = string.Format("mission_desc2_{0}_{1:D4}", event_db_name, mission_id);
        return Translate(eBank.events_text, prfx, def);
    }

    public static string TranslateEventBannerText(string event_db_name, int banner_id, string def)
    {
        string prfx = string.Format("event_banner_{0}_{1:D4}", event_db_name, banner_id);
        return Translate(eBank.events_text, prfx, def);
    }

    private static int CntTranslating = 0;

    public static bool IsTranslating()
    {
        return CntTranslating != 0;
    }

    public static void TranslateImage(GameObject root, Action callBack = null)
    {
        N.a.StartCoroutineWatched(TranslateImages(root, callBack));
    }

    public static IEnumerator TranslateImages(GameObject root, Action cb = null)
    {
        if(string.IsNullOrEmpty(RuntimeSettings.CurrentSettings.Language))
            yield break;

        CntTranslating++;

        Graphic[] imgs = root.GetComponentsInChildren<Graphic>(true);

        // List all materials & textures
        HashSet<Material> mats = new HashSet<Material>();
        Dictionary<string, HashSet<Graphic> > imgsByTexName = new Dictionary<string, HashSet<Graphic> >();
        List<Material> tmpMats = new List<Material>();
        for(int i = 0; i < imgs.Length; i++)
        {
            tmpMats.Clear();
            tmpMats.Add(imgs[i].material);
            if(imgs[i] is RawImageEx)
            {
                RawImageEx imgsEx = imgs[i] as RawImageEx;
                tmpMats.Add(imgsEx.MaterialMul);
                tmpMats.Add(imgsEx.MaterialAdd);
            }
            for(int j = 0; j < tmpMats.Count; j++)
            {
                if(tmpMats[j] == null || tmpMats[j].mainTexture == null)
                    continue;
                mats.Add(tmpMats[j]);
                if(!imgsByTexName.ContainsKey(tmpMats[j].mainTexture.name))
                {
                    imgsByTexName.Add(tmpMats[j].mainTexture.name, new HashSet<Graphic>());
                }
                imgsByTexName[tmpMats[j].mainTexture.name].Add(imgs[i]);
            }
        }

        // Get all translated infos for each texture
        Dictionary<string, TexUVList> uvsListByTexName = new Dictionary<string, TexUVList>();
        Dictionary<string, Texture2D> baseTexByTexname = new Dictionary<string, Texture2D>();
        Dictionary<string, Texture2D> maskTexByTexname = new Dictionary<string, Texture2D>();
        HashSet<Texture2D> loadedTex = new HashSet<Texture2D>();
        foreach(var it in imgsByTexName)
        {
            byte[] res = null;
            string bundleName = "";
            if(it.Key.EndsWith("cmn_menu_pack_base"))
            {
                bundleName = "cmn_menu_pack";
            }
            else if(it.Key.EndsWith("ui_home_pack_base"))
            {
                bundleName = "ui_home_pack";
            }
            if(bundleName != "")
            {
                string path = "localizations/"+RuntimeSettings.CurrentSettings.Language+"/"+bundleName+".xab";
                if(File.Exists(Application.persistentDataPath+"/data/android/"+path))
                {
                    AssetBundleLoadAllAssetOperationBase op = AssetBundleManager.LoadAllAssetAsync(path);
                    yield return op;
                    if(!op.IsError())
                    {
                        TextAsset uvData = op.GetAsset<TextAsset>(bundleName + "_uvlist");
                        if(uvData != null)
                        {
                            TexUVList t = new TexUVList();
                            t.Initialize(uvData.bytes, null);
                            uvsListByTexName.Add(it.Key, t);
                        }
                        Texture2D texBase = op.GetAsset<Texture2D>(bundleName + "_base");
                        if(texBase != null)
                        {
                            baseTexByTexname.Add(it.Key, texBase);
                        }
                        Texture2D texMask = op.GetAsset<Texture2D>(bundleName + "_mask");
                        if(texMask != null)
                        {
                            maskTexByTexname.Add(it.Key, texMask);
                        }
                        AssetBundleManager.UnloadAssetBundle(path, false);
                    }
                }
            }
        }

        // Update all unique mats
        foreach(var m in mats)
        {
            string texName = m.mainTexture.name;
            if(baseTexByTexname.ContainsKey(texName))
            {
                m.mainTexture = baseTexByTexname[texName];
                if(m.HasProperty("_MaskTex") && m.GetTexture("_MaskTex") != null && maskTexByTexname.ContainsKey(texName))
                {
                    m.SetTexture("_MaskTex", maskTexByTexname[texName]);
                }
            }
        }

        // Update sprite
        foreach(var it in uvsListByTexName)
        {
            if(imgsByTexName.ContainsKey(it.Key))
            {
                foreach(var g in imgsByTexName[it.Key])
                {
                    if(g is Image)
                    {
                        Image srcImage = g as Image;
                        Sprite sp = srcImage.sprite;
                        if(sp != null)
                        {
                            string spriteName = sp.name;
                            if(uvsListByTexName.ContainsKey(it.Key))
                            {
                                Material m = srcImage.material;
                                Rect r = LayoutUGUIUtility.MakeUnitySpriteTextureRect(m.mainTexture, uvsListByTexName[it.Key].GetUVData(spriteName));
                                //UnityEngine.Debug.LogError(r);
                                Sprite newSprite = Sprite.Create(m.mainTexture as Texture2D, r, sp.pivot);
                                srcImage.sprite = newSprite;
                            }
                        }
                    }
                }
            }
        }

        // Update rawimage ex texture
        foreach(var g in imgs)
        {
            if(g is RawImageEx)
            {
                RawImageEx imgsEx = g as RawImageEx;
                if(imgsEx.texture != null && baseTexByTexname.ContainsKey(imgsEx.texture.name))
                    imgsEx.texture = baseTexByTexname[imgsEx.texture.name];
                if(imgsEx.alphaTexture != null && maskTexByTexname.ContainsKey(imgsEx.texture.name.Replace("_mask", "_base")))
                    imgsEx.alphaTexture = maskTexByTexname[imgsEx.texture.name.Replace("_mask", "_base")];
            }
        }

        if(cb != null)
            cb();
            
        CntTranslating--;
    }

    public static IEnumerator TranslateUvList(string uvListName, Action<byte[]> cb)
    {
        if(!string.IsNullOrEmpty(RuntimeSettings.CurrentSettings.Language))
        {
            byte[] res = null;
            string bundleName = "";
            if(uvListName.EndsWith("cmn_menu_pack_uvlist"))
            {
                bundleName = "cmn_menu_pack";
            }
            else if(uvListName.EndsWith("ui_home_pack_uvlist"))
            {
                bundleName = "ui_home_pack";
            }
            if(bundleName != "")
            {
                string path = "localizations/"+RuntimeSettings.CurrentSettings.Language+"/"+bundleName+".xab";
                if(File.Exists(Application.persistentDataPath+"/data/android/"+path))
                {
                    AssetBundleLoadAllAssetOperationBase op = AssetBundleManager.LoadAllAssetAsync(path);
                    yield return op;
                    TextAsset uvData = op.GetAsset<TextAsset>(bundleName + "_uvlist");
                    res = uvData.bytes;
                    AssetBundleManager.UnloadAssetBundle(path, false);
                }
            }
            cb(res);
        }
    }
}