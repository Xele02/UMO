using System;
#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEditor;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;

public class DocusaurusGenerator
{
    OKGLGHCBCJP_Database Database;
    IIEDOGCMCIE DbArchive;
    string DataPath;

    [MenuItem("Docusaurus/Generate Data")]
    public static void GenerateData()
    {
        DocusaurusGenerator generator = new DocusaurusGenerator();
        generator.LoadDatabase();
        generator.Init();
        generator.DumpDivasData();
        //generator.DumpTexts();
        //generator.DumpDivaImages();
    }

    public void Init()
    {
        DataPath = Application.dataPath + "/../../Docusaurus/";
        CheckPath(DataPath);
    }

    public void CheckPath(string path)
    {
        if(!Directory.Exists(path))
            Directory.CreateDirectory(path);
    }
    public void LoadDatabase()
    {
        // Copy from IMMAOANGPNK.MHEKMICKGDM_LoadFromStorage();
        IMMAOANGPNK dataA = new IMMAOANGPNK();
        dataA.IJBGPAENLJA(null);
        Database = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database;
        List<OKGLGHCBCJP_Database.BEOKNKGHFFE_Section> sections = new List<OKGLGHCBCJP_Database.BEOKNKGHFFE_Section>();
        for(OKGLGHCBCJP_Database.BEOKNKGHFFE_Section i = 0; i < OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.CGKOFIKBMMI; i++)
        {
            sections.Add(i);
        }
        Database.LNAKMLCCEJG_AddSections(sections, OKGLGHCBCJP_Database.GAAEFILMAED_BaseSectionList);
        Database.KHEKNNFCAOI_Init(sections);

        List<string> listStr = Database.PKOJMBICNHH_GetBlockNames();

        DbArchive = new IIEDOGCMCIE();
        string str = BBGDKLLEPIB.OGCDNCDMLCA_MxDir + "/db/md-20220626-000000_v00007790_s1_h00000000.dat";
        //DbArchive.MCDJJPAKBLH();
        MNNCBFONAOL.KHEKNNFCAOI_Init();
        try
        {
            Cryptor.DsfdLoader.ILoadRequest request = Cryptor.DsfdLoader.LoadFile(str);
            if(!request.IsDone)
            {
                UnityEngine.Debug.LogError("Not decrypted done");
                return;
            }

            byte[] result = request.Result;
            bool r = BOBCNJIPPJN.AGJJGJCIMKI(result);
            if(!r)
            {
                //ANCJLICGOLP a = DOKOHKJIDBO.HHCJCDFCLOB.IKCAJDOKNOM;
                int val1 = 17;//a.LPJLEHAJADA("m_0", 0);
                int val2 = 1;//a.LPJLEHAJADA("m_1", 0);
                int val3 = 1;//a.LPJLEHAJADA("m_2", 0);
                int val4 = 683274560;//a.LPJLEHAJADA("m_3", 0);
                BEEINMBNKNM_Encryption encryption = new BEEINMBNKNM_Encryption();
                encryption.KHEKNNFCAOI_Init((uint)(val4 + 7));
                encryption.DGBPHDMEDNP(val1, val2, val3);
                encryption.FAEFDAJAMCE(result);
                encryption.AAGCKDHEMFD_GenerateKey();
            }
            bool res = DbArchive.KHEKNNFCAOI_Load(request.Result);
            if(!res)
            {
                throw new Exception("Failed to decrypt database");
            }

            bool valid = Database.IIEMACPEEBJ(listStr, DbArchive);
            if(valid)
            {
                if(valid)
                {
                    MLIBEPGADJH_Scene a = Database.ECNHDEHADGL_Scene;
                    if(a != null)
                    {
                        KOGHKIODHPA_Board b = Database.JEMMMJEJLNL_Board;
                        if(b != null)
                        {
                            a.AMACEDAPNKJ(Database.HNMMJINNHII_Game, b);
                        }
                    }
                    BBLECJKKKLA_DecoSetItem c = Database.MJALLIOHKEJ_DecoSetItem;
                    if(c != null)
                    {
                        NDBFKHKMMCE_DecoItem d = Database.EPAHOAKPAJJ_DecoItem;
                        if(d != null)
                        {
                            d.MFIAFCCJHOF(c);
                        }
                    }
                }
            }
        } catch(Exception e)
        {
            UnityEngine.Debug.LogError(e);
        }

        MNNCBFONAOL.PDENBOEFJGE();
    }

    private string[] CutName(string name)
    {
        string[] res = new string[2];
        if(name.Length > 11 && name[11] == '_')
        {
            res[0] = name.Substring(0, 11);
            res[1] = name.Substring(12);
        }
        else if(name.Length == 8)
        {
            res[0] = name;
            res[1] = "";
        }
        else
        {
            res[0] = "";
            res[1] = name;
        }
        return res;
    }

    public EDOHBJAPLPF_JsonData GenerateStructInfo(Type type)
    {
        EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();

        foreach (Type interfaceType in type.GetInterfaces())
        {
            if (interfaceType.IsGenericType &&
                interfaceType.GetGenericTypeDefinition()
                == typeof(IList<>))
            {
                data["type"] = "list";
                Type itemType = type.GetGenericArguments()[0];
                data["innerType"] = GenerateStructInfo(itemType);
                return data;
            }
        }
        if(type.IsClass)
        {
            data["type"] = "class";
            string[] n = CutName(type.Name);
            data["name"] = type.Name;
            data["cryptedName"] = n[0];
            data["realName"] = n[1];
            data["readerClass"] = type.GetCustomAttribute<UMOClass>()?.ReaderClass;
            data["members"] = new EDOHBJAPLPF_JsonData();
            data["members"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
            var members = type.GetMembers().Where(
                    prop => Attribute.IsDefined(prop, typeof(UMOMember)));
            foreach(var m in members)
            {
                Type t = null;
                string mType = "";
                if(m.MemberType == MemberTypes.Field)
                {
                    mType = "field";
                    t = (m as FieldInfo).FieldType;
                }
                else if(m.MemberType == MemberTypes.Property)
                {
                    mType = "property";
                    t = (m as PropertyInfo).PropertyType;
                }

                if(t != null)
                {
                    EDOHBJAPLPF_JsonData mStruct = GenerateStructInfo(t);
                    mStruct["member_type"] = mType;
                    mStruct["member_name"] = m.Name;
                    n = CutName(m.Name);
                    mStruct["member_cryptedName"] = n[0];
                    mStruct["member_realName"] = n[1];
                    mStruct["member_reader"] = m.GetCustomAttribute<UMOMember>().ReaderMember;
                    mStruct["member_readableName"] = m.GetCustomAttribute<UMOMember>().Name;
                    mStruct["member_readerDisplay"] = m.GetCustomAttribute<UMOMember>().ReaderDisplay;
                    mStruct["member_desc"] = m.GetCustomAttribute<UMOMember>().Desc;
                    data["members"].Add(mStruct);
                }
                else
                {
                    Debug.LogError("Couldn't find type for "+m.Name+" "+m.MemberType);
                }
            }
        }
        else
        {
            data["type"] = type.Name;
        }
        return data;
    }

    public EDOHBJAPLPF_JsonData GenerateDataInfo(System.Object obj)
    {
        EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
        Type type = obj.GetType();

        foreach (Type interfaceType in type.GetInterfaces())
        {
            if (interfaceType.IsGenericType &&
                interfaceType.GetGenericTypeDefinition()
                == typeof(IList<>))
            {
                data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
                foreach(var objChild in (obj as IList))
                {
                    data.Add(GenerateDataInfo(objChild));
                }
                return data;
            }
        }
        if(type.IsClass)
        {
            var members = type.GetMembers().Where(
                    prop => Attribute.IsDefined(prop, typeof(UMOMember)));
            foreach(var m in members)
            {
                System.Object memberObj = null;
                if(m.MemberType == MemberTypes.Field)
                {
                    FieldInfo field = type.GetField(m.Name);
                    memberObj = field.GetValue(obj);
                }
                else if(m.MemberType == MemberTypes.Property)
                {
                    PropertyInfo prop = type.GetProperty(m.Name);
                    memberObj = prop.GetValue(obj);
                }

                if(memberObj != null)
                {
                    EDOHBJAPLPF_JsonData mChildObj = GenerateDataInfo(memberObj);
                    data[m.Name] = mChildObj;
                }
                else
                {
                    Debug.LogError("Couldn't find data for "+m.Name+" "+m.MemberType);
                }
            }
        }
        else
        {
            return obj.ToString();
        }
        return data;
    }

    public void DumpDivasData()
    {
        string database_diva_path = DataPath + "database/divas/";
        CheckPath(database_diva_path);

        {
            EDOHBJAPLPF_JsonData schema = GenerateStructInfo(Database.MGFMPKLLGHE_Diva.GetType());
            KIJECNFNNDB_JsonWriter writer = new KIJECNFNNDB_JsonWriter();
            writer.GALFODHMEOL_PrettyPrint = true;
            schema.EJCOJCGIBNG_ToJson(writer);
            string fileStr = writer.ToString();
            File.WriteAllText(database_diva_path + "diva.struct.json", fileStr);
        }

        {
            EDOHBJAPLPF_JsonData datas = GenerateDataInfo(Database.MGFMPKLLGHE_Diva);
            KIJECNFNNDB_JsonWriter writer = new KIJECNFNNDB_JsonWriter();
            writer.GALFODHMEOL_PrettyPrint = true;
            datas.EJCOJCGIBNG_ToJson(writer);
            string fileStr = writer.ToString();
            File.WriteAllText(database_diva_path + "diva.data.json", fileStr);
        }

        return;

        {
            string fileStr = "";
            EDOHBJAPLPF_JsonData data = Database.MGFMPKLLGHE_Diva.Serialize();
            fileStr += "export const divas = ";

            KIJECNFNNDB_JsonWriter writer = new KIJECNFNNDB_JsonWriter();
            writer.GALFODHMEOL_PrettyPrint = true;
            data.EJCOJCGIBNG_ToJson(writer);
            fileStr += writer.ToString() + ";";

            File.WriteAllText(database_diva_path + "diva.data.js", fileStr);
        }

        string db_diva_page = @"---
sidebar_custom_props: {sb_hide: true}
---
import { divas } from ""./divas.data"";

import Content from './_template.mdx';

<Content diva={divas[##idx##]} />";

        for(int i = 0; i < 10; i++)
        {
            File.WriteAllText(database_diva_path + string.Format("{0:D2}-diva{1:D2}.mdx", i+1, i), db_diva_page.Replace("##idx##", ""+i));
        }

    }

    public void DumpTexts()
    {
        string texts_path = DataPath + "texts/";
        CheckPath(texts_path);

        MessageLoader msgLoader = new MessageLoader();
        MessageManager msgManager = new MessageManager();

		foreach(var sheet in Enum.GetValues(typeof(MessageLoader.eSheet)))
		{
			//MessageLoader.Instance.Request((MessageLoader.eSheet)sheet, 0);
            /*StringBuilder str = new StringBuilder(64);
            str.AppendFormat("Message/{0}_{1:D8}", MessageLoader.s_path[(int)sheet], 0);

            Dictionary<string, string> dict = new Dictionary<string, string>(1);
            dict.Add("bankName", sheet.ToString());
            //ResourcesManager.Instance.Request(str.ToString(), this.LoadCallback, dict, 0);
			ResourcesInfo ri = new ResourcesInfo(str.ToString(), null, dict, 0);
            ri.Load();

            TextAsset text = ri.resourceObject as TextAsset;
			msgManager.RegisterBank(dict["bankName"], text.bytes);*/
            StringBuilder str = new StringBuilder(64);
			str.AppendFormat("{0}_{1:D8}.bytes", MessageLoader.s_path[(int)sheet], 0);
			string name = str.ToString();
			CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File file = DbArchive.KGHAJGGMPKL_Files.Find((CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File x) =>
			{
				//0x1117860
				return x.OPFGFINHFCE_Name.Contains(name);
			});
			if(file != null)
			{
				msgManager.ReleaseBank(sheet.ToString());
				msgManager.RegisterBank(sheet.ToString(), file.DBBGALAPFGC_Data);
			}
		}
        string poPath = Application.persistentDataPath + "/Localization/Database/{name}/po/";

		foreach(var sheet in Enum.GetValues(typeof(MessageLoader.eSheet)))
		{
            if(msgManager.IsExistBank(sheet.ToString()))
            {
                MessageBank bank = msgManager.GetBank(sheet.ToString());
                if(bank != null)
                {
                    /*if((MessageLoader.eSheet)sheet == MessageLoader.eSheet.master)
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
                    {*/
                        {
                            string fileStr = "";
                            EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
                            data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object);
                            for(int i = 0; i < bank.count; i++)
                            {
                                data[bank.GetLabel(i)] = bank.GetMessageByIndex(i);
                            }

                            fileStr += "export const "+sheet.ToString()+" = ";

                            KIJECNFNNDB_JsonWriter writer = new KIJECNFNNDB_JsonWriter();
                            writer.GALFODHMEOL_PrettyPrint = true;
                            data.EJCOJCGIBNG_ToJson(writer);
                            fileStr += writer.ToString() + ";";

                            File.WriteAllText( texts_path + sheet.ToString() + ".data.js", fileStr);
                        }

                        foreach(var lang in DatabaseTextConverter.supportedLanguage)
                        {
                            PoFile poFile = new PoFile();
                            string p = poPath.Replace("{name}", sheet.ToString());
                            poFile.LoadFile(p + "messages_full.pot", clear:true); // Read the full template for filling all key
                            poFile.LoadFile(p + lang + ".po");

                            string fileStr = "";
                            EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
                            data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object);
                                
                            foreach(var k in poFile.translationData)
                            {
                                data[k.Key] = k.Value;
                            }

                            fileStr += "export const "+sheet.ToString()+"_"+lang+" = ";

                            KIJECNFNNDB_JsonWriter writer = new KIJECNFNNDB_JsonWriter();
                            writer.GALFODHMEOL_PrettyPrint = true;
                            data.EJCOJCGIBNG_ToJson(writer);
                            fileStr += writer.ToString() + ";";

                            File.WriteAllText( texts_path + sheet.ToString()+"_"+lang+".data.js", fileStr);
                        }
                    //}
                }
            }
		}
/*
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
            for(int i = 0; i < advDb.CDENCMNHNGA.Count; i++)
            {
                if(advDb.CDENCMNHNGA[i].PPEGAKEIEGM_Enabled == 2)
                {
                    if(!advIds.Contains(advDb.CDENCMNHNGA[i].KKPPFAHFOJI_FileId))
                        advIds.Add(advDb.CDENCMNHNGA[i].KKPPFAHFOJI_FileId);
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
        */
    }

    public void DumpDivaImages()
    {
        string[][] FilesList = {
            new string[] {"{0:D2}_{1:D2}_diva-s-size", "/ct/dv/me/01/{0:D2}_{1:D2}.xab"}, // 
            new string[] {"{0:D2}_{1:D2}_diva-m-size", "/ct/dv/me/02/{0:D2}_{1:D2}.xab"}, // 
            new string[] {"{0:D2}_{1:D2}_diva-l-size", "/ct/dv/me/03/{0:D2}_{1:D2}.xab"}, // 
            new string[] {"{0:D2}_{1:D2}_diva-ps", "/ct/dv/ps/{0:D2}_{1:D2}.xab"}, // 
            new string[] {"{0:D2}_{1:D2}_diva-story", "/ct/dv/me/05/{0:D2}_{1:D2}.xab"}, // 
            new string[] {"{0:D2}_{1:D2}_diva-small-bustup", "/ct/dv/me/06/{0:D2}_{1:D2}.xab"}, // 
            new string[] {"{0:D2}_{1:D2}_diva-standing-costume", "/ct/dv/me/07/{0:D2}_{1:D2}.xab"}, // 
            new string[] {"{0:D2}_01_diva-event-go-diva", "/ct/dv/me/08/{0:D2}_01.xab"}, // 
            new string[] {"{0:D2}_{1:D2}_diva-event-go-diva-typed", "/ct/dv/me/08/{0:D2}_{1:D2}.xab"}, // 
            new string[] {"{0:D2}_{1:D2}_{2:D2}_diva-s-size-in-color", "/ct/dv/me/01/{0:D2}_{1:D2}_{2:D2}.xab"}, // 
            new string[] {"{0:D2}_{1:D2}_{2:D2}_diva-m-size-in-color", "/ct/dv/me/02/{0:D2}_{1:D2}_{2:D2}.xab"}, // 
            new string[] {"{0:D2}_{1:D2}_{2:D2}_diva-l-size-in-color", "/ct/dv/me/03/{0:D2}_{1:D2}_{2:D2}.xab"}, // 
            new string[] {"{0:D2}_{1:D2}_{2:D2}_diva-ps-size-in-color", "/ct/dv/ps/{0:D2}_{1:D2}_{2:D2}.xab"} // 
        };

        string imgs_path = DataPath + "images/divas/";
        CheckPath(imgs_path);

        DOKOHKJIDBO a = new DOKOHKJIDBO();
        a.KIDFJDNOGDG();
        a.LoadEditor();

        OAFCKDDEBFN decryptor = new OAFCKDDEBFN();
        decryptor.PGLANLKJBLI_Init();

        for(int i = 1; i <= 10; i++)
        {
            foreach(var file in FilesList)
            {
                // Tmp
                int cosId = 1;
                int colId = 0;
                if(file[0] == "{0:D2}_{1:D2}_diva-standing-costume")
                {
                    cosId = new int[10]{3, 2, 2, 2, 2, 2, 3, 2, 2, 2}[i - 1];
                }
                // End Tmp
                
                string outName = string.Format(file[0], i, cosId, colId);
                if(File.Exists(imgs_path + outName + ".png"))
                    continue;
                string bundleName = string.Format(file[1], i, cosId, colId);
                //BDFPCPHIJCN request = new BDFPCPHIJCN(path, withoutPlarformPath, this.FileLoadedCallback, this.FailedCallback, args, argValue, fi, loadedDispose);
                if(!File.Exists(Application.persistentDataPath + "/data/android/" + bundleName))
                    continue;
                byte[] assetBytes = File.ReadAllBytes(Application.persistentDataPath + "/data/android/" + bundleName);

                BEEINMBNKNM_Encryption encryption = decryptor.MFHAOMELJKJ_FindDecryptor(bundleName);
                encryption.CLNHGLGOKPF_Decrypt(assetBytes);
                AssetBundle bundle = AssetBundle.LoadFromMemory(assetBytes);
                string name = Path.GetFileNameWithoutExtension(bundleName);
                Texture BaseTexture = bundle.LoadAsset(name+"_base") as Texture;
                Texture MaskTexture = bundle.LoadAsset(name+"_mask") as Texture;
                Material mat = null;
                if(MaskTexture != null)
                {
                    mat = new Material(Shader.Find("XeSys/Unlit/SplitTexture"));
                    mat.SetTexture("_MainTex", BaseTexture);
                    mat.SetTexture("_MaskTex", MaskTexture);
                }
                Texture2D t = TextureHelper.Copy(BaseTexture as Texture2D, -1, -1, mat);
                if(MaskTexture != null)
                    File.WriteAllBytes(imgs_path + outName + ".png", t.EncodeToPNG());
                else
                    File.WriteAllBytes(imgs_path + outName + ".jpg", t.EncodeToJPG());

                // Tmp

                if(file[0] == "{0:D2}_{1:D2}_diva-l-size")
                {
                    Rect r = new Rect(77, BaseTexture.height - 384 - 51, 358, 384);
                    t = TextureHelper.Copy(BaseTexture as Texture2D, -1, -1, mat, r);
                    if(MaskTexture != null)
                        File.WriteAllBytes(imgs_path + outName + "_crop.png", t.EncodeToPNG());
                    else
                        File.WriteAllBytes(imgs_path + outName + "_crop.jpg", t.EncodeToJPG());
                }

                bundle.Unload(true);
            }
        }
    }
}

#endif

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
public class UMOMember : Attribute
{
    public string ReaderMember;
    public string Name;
    public string Desc;
    public string ReaderDisplay;
}

[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
public class UMOClass : Attribute
{
    public string ReaderClass;
}
