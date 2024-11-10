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
using XeApp.Game.Adv;
using XeApp.Game.Common;
using XeSys;

public class DocusaurusGenerator
{
    OKGLGHCBCJP_Database Database;
    IIEDOGCMCIE DbArchive;
    string DataPath;
    private MusicTextDatabase musicText;
    private SNSRoomTextDatabase roomText;

    [MenuItem("Docusaurus/Generate Data")]
    public static void GenerateData()
    {
        MNNCBFONAOL.KHEKNNFCAOI_Init();

        DocusaurusGenerator generator = new DocusaurusGenerator();
        generator.LoadDatabase();
        generator.Init();
        generator.DumpDatabaseData();
        //generator.DumpTexts();
        //generator.DumpDivaImages();
        //generator.DumpDivaCostumes();
        //generator.DumpAdv();
        //generator.DumpEventStory();
        //generator.DumpSNS();

        MNNCBFONAOL.PDENBOEFJGE();
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

            {
                long JHNMKKNEENE_Time = Utility.GetCurrentUnixTime();
                CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File arch = DbArchive.KGHAJGGMPKL_Files.Find((CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File GHPLINIACBB) =>
                {
                    return GHPLINIACBB.OPFGFINHFCE_Name.Contains("version.bytes");
                }); // 0x9FDDD8
                if(arch != null)
                {
                    List<IMMAOANGPNK.MPFFINOMILP> MGFBEKNMJOA = new List<IMMAOANGPNK.MPFFINOMILP>();
                    IDEELDJLDBN a = IDEELDJLDBN.HEGEKFMJNCC(arch.DBBGALAPFGC_Data);
                    JGIHJPPECBB[] b = a.MLOPDBGPLFI;
                    IMMAOANGPNK.MPFFINOMILP obj = null;
                    for(int i = 0; i < b.Length; i++)
                    {
                        int val = b[i].BEBJKJKBOGH;
                        if(JHNMKKNEENE_Time >= val)
                        {
                            if(obj != null)
                            {
                                if(obj.PDBPFJJCADD >= val)
                                {
                                    continue;
                                }
                            }
                            obj = new IMMAOANGPNK.MPFFINOMILP();
                            obj.OPFGFINHFCE_Name = b[i].OPFGFINHFCE;
                            obj.PDBPFJJCADD = val;
                            obj.IJEKNCDIIAE_MVer = b[i].IJEKNCDIIAE;
                        }
                        else
                        {
                            IMMAOANGPNK.MPFFINOMILP obj2 = new IMMAOANGPNK.MPFFINOMILP();
                            obj2.OPFGFINHFCE_Name = b[i].OPFGFINHFCE;
                            obj2.PDBPFJJCADD = val;
                            obj2.IJEKNCDIIAE_MVer = b[i].IJEKNCDIIAE;
                            MGFBEKNMJOA.Add(obj2);
                        }
                    }
                    if(obj != null)
                    {
                        MGFBEKNMJOA.Add(obj);
                    }
                    
                    MGFBEKNMJOA.Sort((IMMAOANGPNK.MPFFINOMILP HKICMNAACDA, IMMAOANGPNK.MPFFINOMILP BNKHBCBJBKI) => {
                        //0x9FDE64 
                        return HKICMNAACDA.PDBPFJJCADD.CompareTo(BNKHBCBJBKI.PDBPFJJCADD);
                    });
                    if(MGFBEKNMJOA.Count > 0)
                    {
                        IMMAOANGPNK.MPFFINOMILP item = MGFBEKNMJOA[0];
                        if(JHNMKKNEENE_Time >= item.PDBPFJJCADD)
                        {
                            DIHHCBACKGG_DbSection.IEFOPDOOLOK_MasterVersion = item.IJEKNCDIIAE_MVer;
                        }
                    }
                }
            }

            //musicText = new MusicTextDatabase();
            //musicText.LoadFromTAR(DbArchive);
            roomText = new SNSRoomTextDatabase();
            roomText.LoadFromBinaryTAR(DbArchive);

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
                if(type.IsGenericType)
                {
                    Type itemType = type.GetGenericArguments()[0];
                    data["innerType"] = GenerateStructInfo(itemType);
                }
                else
                {
                    Type itemType = type.GetElementType();
                    data["innerType"] = GenerateStructInfo(itemType);
                }
                return data;
            }
        }
        foreach (Type interfaceType in type.GetInterfaces())
        {
            if (interfaceType.IsGenericType &&
                interfaceType.GetGenericTypeDefinition()
                == typeof(IDictionary<,>))
            {
                data["type"] = "dict";
                if(type.IsGenericType)
                {
                    data["innerTypeKey"] = GenerateStructInfo(type.GetGenericArguments()[0]);
                    data["innerTypeValue"] = GenerateStructInfo(type.GetGenericArguments()[1]);
                }
                else
                {
                    Debug.LogError("Dictionary is not generic "+type.ToString());
                }
                return data;
            }
        }
        if(typeof(CEBFFLDKAEC_SecureInt).IsAssignableFrom(type))
        {
            data["type"] = typeof(int).Name;
        }
        else if(typeof(NNJFKLBPBNK_SecureString).IsAssignableFrom(type))
        {
            data["type"] = typeof(string).Name;
        }
        else if(type.IsClass && !typeof(string).IsAssignableFrom(type))
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
                    mStruct["member_reader_child"] = m.GetCustomAttribute<UMOMember>().ReaderMemberChild;
                    mStruct["member_readableName"] = m.GetCustomAttribute<UMOMember>().Name;
                    mStruct["member_readerDisplay"] = m.GetCustomAttribute<UMOMember>().ReaderDisplay;
                    mStruct["member_desc"] = m.GetCustomAttribute<UMOMember>().Desc;
                    mStruct["member_display"] = m.GetCustomAttribute<UMOMember>().Display;
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
        foreach (Type interfaceType in type.GetInterfaces())
        {
            if (interfaceType.IsGenericType &&
                interfaceType.GetGenericTypeDefinition()
                == typeof(IDictionary<,>))
            {
                data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
                IDictionary objDict = obj as IDictionary;
                foreach(var objChils in objDict.Keys)
                {
                    EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
                    data2["key"] = GenerateDataInfo(objChils);
                    data2["value"] = GenerateDataInfo(objDict[objChils]);
                    data.Add(data2);
                }
                return data;
            }
        }
        if(typeof(CEBFFLDKAEC_SecureInt).IsAssignableFrom(type))
        {
            return (obj as CEBFFLDKAEC_SecureInt).DNJEJEANJGL_Value;
        }
        else if(typeof(NNJFKLBPBNK_SecureString).IsAssignableFrom(type))
        {
            return (obj as NNJFKLBPBNK_SecureString).DNJEJEANJGL_Value;
        }
        else if(type.IsClass && !typeof(string).IsAssignableFrom(type))
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
            if(obj is Color)
                return ((Color)obj).HexStringRGBA();
            return obj.ToString();
        }
        return data;
    }

    public void DumpDatabaseData()
    {
        List<string> blocks = Database.PKOJMBICNHH_GetBlockNames();

        EDOHBJAPLPF_JsonData db_struct = new EDOHBJAPLPF_JsonData();
        db_struct.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);

        foreach(var block in blocks)
        {
            string database_path = DataPath + "database/"+block+"/";
            CheckPath(database_path);

            db_struct.Add(block);
            DIHHCBACKGG_DbSection section = Database.LBDOLHGDIEB_GetDbSection(block);

            {
                EDOHBJAPLPF_JsonData schema = GenerateStructInfo(section.GetType());
                KIJECNFNNDB_JsonWriter writer = new KIJECNFNNDB_JsonWriter();
                writer.GALFODHMEOL_PrettyPrint = true;
                schema.EJCOJCGIBNG_ToJson(writer);
                string fileStr = writer.ToString();
                File.WriteAllText(database_path + block + ".struct.json", fileStr);
            }

            {
                EDOHBJAPLPF_JsonData datas = GenerateDataInfo(section);
                KIJECNFNNDB_JsonWriter writer = new KIJECNFNNDB_JsonWriter();
                writer.GALFODHMEOL_PrettyPrint = true;
                datas.EJCOJCGIBNG_ToJson(writer);
                string fileStr = writer.ToString();
                if(fileStr == "")
                    fileStr = "{}";
                File.WriteAllText(database_path + block + ".data.json", fileStr);
            }
        }

        {
            string database_path = DataPath + "database/";
            CheckPath(database_path);

            KIJECNFNNDB_JsonWriter writer = new KIJECNFNNDB_JsonWriter();
            writer.GALFODHMEOL_PrettyPrint = true;
            db_struct.EJCOJCGIBNG_ToJson(writer);
            string fileStr = writer.ToString();
            File.WriteAllText(database_path + "db_struct.json", fileStr);
        }
    }

    public void DumpTexts()
    {
        string texts_path = DataPath + "texts/";
        CheckPath(texts_path);

        string poPath = Application.persistentDataPath + "/Localization/Database/{name}/po/";
        List<string> langs = DatabaseTextConverter.supportedLanguage;
        langs.Add("jp");
        foreach(var lang in langs)
        {
            CBBJHPBGBAJ_Archive archive = new CBBJHPBGBAJ_Archive();
            foreach(var sheet in Enum.GetValues(typeof(MessageLoader.eSheet)))
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

            for(int i = 0; i < (int)DatabaseTextConverter.eBank.End; i++)
            {
                //Import texts
                PoFile poFile = new PoFile();
                if((DatabaseTextConverter.eBank)i == DatabaseTextConverter.eBank.string_literals)
                {
                    string p = Application.persistentDataPath + "/Localization/JpLiteralStrings/po/";
                    poFile.LoadFile(p + "messages.pot", clear:true);
                    poFile.LoadFile(p + lang + ".po");
                }
                else
                {
                    string p = poPath.Replace("{name}", ((DatabaseTextConverter.eBank)i).ToString());
                    poFile.LoadFile(p + "messages_full.pot", clear:true);
                    poFile.LoadFile(p + lang + ".po");
                }
                
                string fileStr = "";
                EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
                data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object);
                    
                foreach(var k in poFile.translationData)
                {
                    data[k.Key] = k.Value;
                }

                fileStr += "export const "+((DatabaseTextConverter.eBank)i).ToString()+"_"+lang+" = ";

                KIJECNFNNDB_JsonWriter writer = new KIJECNFNNDB_JsonWriter();
                writer.GALFODHMEOL_PrettyPrint = true;
                data.EJCOJCGIBNG_ToJson(writer);
                fileStr += writer.ToString() + ";";

                File.WriteAllText( texts_path + ((DatabaseTextConverter.eBank)i).ToString()+"_"+lang+".data.js", fileStr);
            }
        }

        // MessageLoader msgLoader = new MessageLoader();
        // MessageManager msgManager = new MessageManager();

		// foreach(var sheet in Enum.GetValues(typeof(MessageLoader.eSheet)))
		// {
		// 	//MessageLoader.Instance.Request((MessageLoader.eSheet)sheet, 0);
        //     /*StringBuilder str = new StringBuilder(64);
        //     str.AppendFormat("Message/{0}_{1:D8}", MessageLoader.s_path[(int)sheet], 0);

        //     Dictionary<string, string> dict = new Dictionary<string, string>(1);
        //     dict.Add("bankName", sheet.ToString());
        //     //ResourcesManager.Instance.Request(str.ToString(), this.LoadCallback, dict, 0);
		// 	ResourcesInfo ri = new ResourcesInfo(str.ToString(), null, dict, 0);
        //     ri.Load();

        //     TextAsset text = ri.resourceObject as TextAsset;
		// 	msgManager.RegisterBank(dict["bankName"], text.bytes);*/
        //     StringBuilder str = new StringBuilder(64);
		// 	str.AppendFormat("{0}_{1:D8}.bytes", MessageLoader.s_path[(int)sheet], 0);
		// 	string name = str.ToString();
		// 	CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File file = DbArchive.KGHAJGGMPKL_Files.Find((CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File x) =>
		// 	{
		// 		//0x1117860
		// 		return x.OPFGFINHFCE_Name.Contains(name);
		// 	});
		// 	if(file != null)
		// 	{
		// 		msgManager.ReleaseBank(sheet.ToString());
		// 		msgManager.RegisterBank(sheet.ToString(), file.DBBGALAPFGC_Data);
		// 	}
		// }
        // string poPath = Application.persistentDataPath + "/Localization/Database/{name}/po/";

		// foreach(var sheet in Enum.GetValues(typeof(MessageLoader.eSheet)))
		// {
        //     if(msgManager.IsExistBank(sheet.ToString()))
        //     {
        //         MessageBank bank = msgManager.GetBank(sheet.ToString());
        //         if(bank != null)
        //         {
        //             /*if((MessageLoader.eSheet)sheet == MessageLoader.eSheet.master)
        //             {
        //                 PoFile poFileCommon = new PoFile();
        //                 PoFile poFileSns = new PoFile();
        //                 PoFile poFileScenes = new PoFile();
        //                 for(int i = 0; i < bank.count; i++)
        //                 {
        //                     string s = bank.GetLabel(i);
        //                     if(s.StartsWith("sns_"))
        //                         poFileSns.translationData.Add(s, bank.GetMessageByIndex(i));
        //                     else if(s.StartsWith("sn_"))
        //                         poFileScenes.translationData.Add(s, bank.GetMessageByIndex(i));
        //                     else
        //                         poFileCommon.translationData.Add(s, bank.GetMessageByIndex(i));
        //                 }
        //                 {
        //                     string p = PoPath.Replace("{name}", sheet.ToString());
        //                     Directory.CreateDirectory(p);
        //                     poFileCommon.SaveFile(p + "messages_full.pot", isTemplate:true);
        //                     poFileCommon.SaveFile(p + "messages.pot", isTemplate:true, stripEmpty:true);
        //                     poFileCommon.SaveFile(p + "jp.po", stripEmpty:true);
        //                 }
        //                 {
        //                     string p = PoPath.Replace("{name}", sheet.ToString()+"_sns");
        //                     Directory.CreateDirectory(p);
        //                     poFileSns.SaveFile(p + "messages_full.pot", isTemplate:true);
        //                     poFileSns.SaveFile(p + "messages.pot", isTemplate:true, stripEmpty:true);
        //                     poFileSns.SaveFile(p + "jp.po", stripEmpty:true);
        //                 }
        //                 {
        //                     string p = PoPath.Replace("{name}", sheet.ToString()+"_scene");
        //                     Directory.CreateDirectory(p);
        //                     poFileScenes.SaveFile(p + "messages_full.pot", isTemplate:true);
        //                     poFileScenes.SaveFile(p + "messages.pot", isTemplate:true, stripEmpty:true);
        //                     poFileScenes.SaveFile(p + "jp.po", stripEmpty:true);
        //                 }
        //             }
        //             else
        //             {*/
        //                 {
        //                     string fileStr = "";
        //                     EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
        //                     data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object);
        //                     for(int i = 0; i < bank.count; i++)
        //                     {
        //                         data[bank.GetLabel(i)] = bank.GetMessageByIndex(i);
        //                     }

        //                     fileStr += "export const "+sheet.ToString()+" = ";

        //                     KIJECNFNNDB_JsonWriter writer = new KIJECNFNNDB_JsonWriter();
        //                     writer.GALFODHMEOL_PrettyPrint = true;
        //                     data.EJCOJCGIBNG_ToJson(writer);
        //                     fileStr += writer.ToString() + ";";

        //                     File.WriteAllText( texts_path + sheet.ToString() + ".data.js", fileStr);
        //                 }

        //                 foreach(var lang in DatabaseTextConverter.supportedLanguage)
        //                 {
        //                     PoFile poFile = new PoFile();
        //                     string p = poPath.Replace("{name}", sheet.ToString());
        //                     poFile.LoadFile(p + "messages_full.pot", clear:true); // Read the full template for filling all key
        //                     poFile.LoadFile(p + lang + ".po");

        //                     string fileStr = "";
        //                     EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
        //                     data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object);
                                
        //                     foreach(var k in poFile.translationData)
        //                     {
        //                         data[k.Key] = k.Value;
        //                     }

        //                     fileStr += "export const "+sheet.ToString()+"_"+lang+" = ";

        //                     KIJECNFNNDB_JsonWriter writer = new KIJECNFNNDB_JsonWriter();
        //                     writer.GALFODHMEOL_PrettyPrint = true;
        //                     data.EJCOJCGIBNG_ToJson(writer);
        //                     fileStr += writer.ToString() + ";";

        //                     File.WriteAllText( texts_path + sheet.ToString()+"_"+lang+".data.js", fileStr);
        //                 }
        //             //}
        //         }
        //     }
		// }
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


    public void DumpDivaCostumes()
    {
        string[][] FilesList = {
            new string[] {"{0:D2}_{1:D2}_diva-s-size", "/ct/dv/me/01/{0:D2}_{1:D2}.xab"}, // 
            new string[] {"{0:D2}_{1:D2}_diva-m-size", "/ct/dv/me/02/{0:D2}_{1:D2}.xab"}, // 
            new string[] {"{0:D2}_{1:D2}_diva-l-size", "/ct/dv/me/03/{0:D2}_{1:D2}.xab"}, // 
            new string[] {"{0:D2}_{1:D2}_diva-ps", "/ct/dv/ps/{0:D2}_{1:D2}.xab"}, // 
            new string[] {"{0:D2}_{1:D2}_{2:D2}_diva-s-size-in-color", "/ct/dv/me/01/{0:D2}_{1:D2}_{2:D2}.xab"}, // 
            new string[] {"{0:D2}_{1:D2}_{2:D2}_diva-m-size-in-color", "/ct/dv/me/02/{0:D2}_{1:D2}_{2:D2}.xab"}, // 
            new string[] {"{0:D2}_{1:D2}_{2:D2}_diva-l-size-in-color", "/ct/dv/me/03/{0:D2}_{1:D2}_{2:D2}.xab"}, // 
            new string[] {"{0:D2}_{1:D2}_{2:D2}_diva-ps-size-in-color", "/ct/dv/ps/{0:D2}_{1:D2}_{2:D2}.xab"}, // 
            new string[] {"{0:D2}_{1:D3}_costume", "/ct/dv/co/{0:D2}_{1:D3}.xab"}, // 
            new string[] {"{0:D2}_{1:D3}_{2:D2}_costume", "/ct/dv/co/{0:D2}_{1:D3}_{2:D2}.xab"} // 
        };

        string imgs_path = DataPath + "images/costumes/";
        CheckPath(imgs_path);

        DOKOHKJIDBO a = new DOKOHKJIDBO();
        a.KIDFJDNOGDG();
        a.LoadEditor();

        OAFCKDDEBFN decryptor = new OAFCKDDEBFN();
        decryptor.PGLANLKJBLI_Init();

        foreach(var costume in Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes)
        {
            int i = costume.AHHJLDLAPAN_PrismDivaId;
            int cosId = costume.DAJGPBLEEOB_PrismCostumeModelId;
            short[] cols = costume.CHDBGFLFPNC_GetAllAvaiableColors();
            if(cols.Length > 1)
                Debug.LogError("Too much unlockable color");
            int colId = 0;
            if(cols.Length > 0)
                colId = cols[0];
            
            foreach(var file in FilesList)
            {
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

                if(file[0].Contains("diva-l-size"))
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

    void DumpAdv()
    {
        string temp_adv_path = DataPath + "temp/adv/";
        CheckPath(temp_adv_path);
        //foreach(var advDb in Database.EFMAIKAHFEK_Adventure.CDENCMNHNGA_List)
        EDOHBJAPLPF_JsonData advList = new EDOHBJAPLPF_JsonData();
        advList.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
        foreach(var file in Directory.GetFiles(Application.persistentDataPath + "/data/android/adv/"))
        {
            string fileName = file;
            if(!File.Exists(fileName))
                continue;
            string outName = temp_adv_path + file.Replace(Application.persistentDataPath + "/data/android/adv/", "");
            if(outName.EndsWith("000007.dat"))
                continue;
            advList.Add(file.Replace(Application.persistentDataPath + "/data/android/adv/", "").Replace(".dat",""));
            if(File.Exists(outName))
                continue;
            CBBJHPBGBAJ_Archive c = new CBBJHPBGBAJ_Archive();
            //IPGPAGNBBIK
            Cryptor.DsfdLoader.ILoadRequest request = Cryptor.DsfdLoader.LoadFile(fileName);
            if(!request.IsDone)
            {
                UnityEngine.Debug.LogError("Not decrypted done");
                return;
            }
            c.KHEKNNFCAOI_Load(request.Result);
            CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File f = c.KGHAJGGMPKL_Files.Find((CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File x) =>
            {
                //0xE58B5C
                return x.OPFGFINHFCE_Name.Contains("adv_script");
            });
            if(f != null)
            {
                File.WriteAllBytes(outName, f.DBBGALAPFGC_Data);
            }
        }
        {
            string adv_path = DataPath + "adv/";
            CheckPath(adv_path);
            KIJECNFNNDB_JsonWriter writer = new KIJECNFNNDB_JsonWriter();
            writer.GALFODHMEOL_PrettyPrint = true;
            advList.EJCOJCGIBNG_ToJson(writer);
            string fileStr = writer.ToString();
            File.WriteAllText(adv_path + "advList.json", fileStr);
        }

        DOKOHKJIDBO a = new DOKOHKJIDBO();
        a.KIDFJDNOGDG();
        a.LoadEditor();

        OAFCKDDEBFN decryptor = new OAFCKDDEBFN();
        decryptor.PGLANLKJBLI_Init();

        string adv_path_bg = DataPath + "images/adv/bg/";
        CheckPath(adv_path_bg);
        EDOHBJAPLPF_JsonData bgList = new EDOHBJAPLPF_JsonData();
        bgList.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
        for(int i = 1; i < 85; i++)
        {
            string bundleName = string.Format("/ad/bg/{0:D4}.xab", i);
            if(!File.Exists(Application.persistentDataPath + "/data/android/" + bundleName))
                continue;
            bgList.Add(i);
            string outName = string.Format("{0:D4}", i);
            if(File.Exists(adv_path_bg + outName + ".jpg"))
                continue;
            byte[] assetBytes = File.ReadAllBytes(Application.persistentDataPath + "/data/android/" + bundleName);

            BEEINMBNKNM_Encryption encryption = decryptor.MFHAOMELJKJ_FindDecryptor(bundleName);
            encryption.CLNHGLGOKPF_Decrypt(assetBytes);
            AssetBundle bundle = AssetBundle.LoadFromMemory(assetBytes);
            string name = Path.GetFileNameWithoutExtension(bundleName);
            Texture BaseTexture = bundle.LoadAsset(outName) as Texture;
            Texture2D t = TextureHelper.Copy(BaseTexture as Texture2D, -1, -1);
            File.WriteAllBytes(adv_path_bg + outName + ".jpg", t.EncodeToJPG());
            bundle.Unload(true);
        }
        {
            KIJECNFNNDB_JsonWriter writer = new KIJECNFNNDB_JsonWriter();
            writer.GALFODHMEOL_PrettyPrint = true;
            bgList.EJCOJCGIBNG_ToJson(writer);
            string fileStr = writer.ToString();
            File.WriteAllText(adv_path_bg + "bglist.json", fileStr);
        }

        string adv_path_chara = DataPath + "images/adv/chara/";
        CheckPath(adv_path_chara);
        EDOHBJAPLPF_JsonData charaList = new EDOHBJAPLPF_JsonData();
        charaList.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object);
        for(int i = 1; i < 40; i++)
        {
            EDOHBJAPLPF_JsonData poseList = new EDOHBJAPLPF_JsonData();
            poseList.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
            for(int j = 1; j < 999; j++)
            {
                string bundleName = string.Format("/ad/ch/{0:D4}_{1:D3}.xab", i, j);
                if(!File.Exists(Application.persistentDataPath + "/data/android/" + bundleName))
                    continue;
                poseList.Add(j);
                string outName = string.Format("{0:D4}_{1:D3}", i, j);
                if(File.Exists(adv_path_chara + outName + ".png"))
                    continue;
                byte[] assetBytes = File.ReadAllBytes(Application.persistentDataPath + "/data/android/" + bundleName);

                BEEINMBNKNM_Encryption encryption = decryptor.MFHAOMELJKJ_FindDecryptor(bundleName);
                encryption.CLNHGLGOKPF_Decrypt(assetBytes);
                AssetBundle bundle = AssetBundle.LoadFromMemory(assetBytes);
                string name = Path.GetFileNameWithoutExtension(bundleName);
                AdvCharacterData charaData = bundle.LoadAsset("CharaData") as AdvCharacterData;
                Material mat = charaData.GetMaterial();
                mat.shader = Shader.Find("XeSys/Unlit/SplitTexture");
                Texture2D t = TextureHelper.Copy(mat.mainTexture as Texture2D, -1, -1, mat);
                File.WriteAllBytes(adv_path_chara + outName + ".png", t.EncodeToPNG());
                bundle.Unload(true);
            }
            if(poseList.HNBFOAJIIAL_Count > 0)
                charaList[i.ToString()] = poseList;
        }
        {
            KIJECNFNNDB_JsonWriter writer = new KIJECNFNNDB_JsonWriter();
            writer.GALFODHMEOL_PrettyPrint = true;
            charaList.EJCOJCGIBNG_ToJson(writer);
            string fileStr = writer.ToString();
            File.WriteAllText(adv_path_chara + "charaList.json", fileStr);
        }
    }


    void DumpEventStory()
    {
        DOKOHKJIDBO a = new DOKOHKJIDBO();
        a.KIDFJDNOGDG();
        a.LoadEditor();

        OAFCKDDEBFN decryptor = new OAFCKDDEBFN();
        decryptor.PGLANLKJBLI_Init();

        string event_path_banner = DataPath + "images/event/banner/";
        CheckPath(event_path_banner);
        EDOHBJAPLPF_JsonData eventBannerList = new EDOHBJAPLPF_JsonData();
        eventBannerList.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
        foreach(var story in Database.NBEMLGADAGK_EventStory.ILEJEJKNOBN_StoryList)
        {
            int i = story.OAFJONPIFGM_EventId;
            string bundleName = string.Format("/ct/ev/ba/01/{0:D4}.xab", i);
            if(!File.Exists(Application.persistentDataPath + "/data/android/" + bundleName))
                continue;
            eventBannerList.Add(i);
            string outName = string.Format("{0:D4}", i);
            if(File.Exists(event_path_banner + outName + ".png") || File.Exists(event_path_banner + outName + ".jpg"))
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
                File.WriteAllBytes(event_path_banner + outName + ".png", t.EncodeToPNG());
            else
                File.WriteAllBytes(event_path_banner + outName + ".jpg", t.EncodeToJPG());

            bundle.Unload(true);
        }
        {
            KIJECNFNNDB_JsonWriter writer = new KIJECNFNNDB_JsonWriter();
            writer.GALFODHMEOL_PrettyPrint = true;
            eventBannerList.EJCOJCGIBNG_ToJson(writer);
            string fileStr = writer.ToString();
            File.WriteAllText(event_path_banner + "bannerlist.json", fileStr);
        }
    }


    void DumpSNS()
    {
        DOKOHKJIDBO a = new DOKOHKJIDBO();
        a.KIDFJDNOGDG();
        a.LoadEditor();

        OAFCKDDEBFN decryptor = new OAFCKDDEBFN();
        decryptor.PGLANLKJBLI_Init();

        string sns_chara_path = DataPath + "images/sns/character/";
        CheckPath(sns_chara_path);
        EDOHBJAPLPF_JsonData snsCharaList = new EDOHBJAPLPF_JsonData();
        snsCharaList.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
        foreach(var chara in Database.OMGFKMANMAB_Sns.KHCACDIKJLG_Characters)
        {
            int i = chara.EAHPLCJMPHD_PicId;
            string bundleName = string.Format("/ct/sn/ch/{0:D2}.xab", i);
            if(!File.Exists(Application.persistentDataPath + "/data/android/" + bundleName))
                continue;
            snsCharaList.Add(i);
            string outName = string.Format("{0:D2}", i);
            if(File.Exists(sns_chara_path + outName + ".png") || File.Exists(sns_chara_path + outName + ".jpg"))
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
                File.WriteAllBytes(sns_chara_path + outName + ".png", t.EncodeToPNG());
            else
                File.WriteAllBytes(sns_chara_path + outName + ".jpg", t.EncodeToJPG());

            bundle.Unload(true);
        }
        {
            KIJECNFNNDB_JsonWriter writer = new KIJECNFNNDB_JsonWriter();
            writer.GALFODHMEOL_PrettyPrint = true;
            snsCharaList.EJCOJCGIBNG_ToJson(writer);
            string fileStr = writer.ToString();
            File.WriteAllText(sns_chara_path + "charalist.json", fileStr);
        }

        {
            EDOHBJAPLPF_JsonData snsData = new EDOHBJAPLPF_JsonData();
            foreach(var snsTalk in Database.OMGFKMANMAB_Sns.CDENCMNHNGA_Talks)
            {
                SNSRoomTextData.Header h = roomText.textData.FindHeader(snsTalk.AJIDLAGFPGM_TalkId);
                if(h != null)
                {
                    EDOHBJAPLPF_JsonData snsHeader = new EDOHBJAPLPF_JsonData();
                    snsHeader["talkId"] = h.talkId;
                    snsHeader["startIndex"] = h.startIndex;
                    snsHeader["endIndex"] = h.endIndex;
                    snsHeader["headMessageIndex"] = h.headMessageIndex;
                    EDOHBJAPLPF_JsonData snsTalkDatas = new EDOHBJAPLPF_JsonData();
                    snsTalkDatas.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
                    snsHeader["snsTalkDatas"] = snsTalkDatas;
                    for(int i = h.startIndex; i <= h.endIndex; i++)
                    {
                        SNSRoomTextData.TalkData t = roomText.textData.FindData(i);
                        if(t != null)
                        {
                            EDOHBJAPLPF_JsonData snsTalkData = new EDOHBJAPLPF_JsonData();
                            snsTalkData["index"] = i;
                            snsTalkData["charaId"] = t.charaId;
                            snsTalkData["windowShapeId"] = t.windowShapeId;
                            snsTalkData["windowSizeId"] = t.windowSizeId;
                            snsTalkData["messageIndex"] = t.messageIndex;
                            snsTalkData["timeOffset"] = t.timeOffset;
                            snsTalkDatas.Add(snsTalkData);
                        }
                    }
                    snsData[snsTalk.AJIDLAGFPGM_TalkId.ToString()] = snsHeader;
                }
            }
            string sns_data_path = DataPath + "sns/";
            CheckPath(sns_data_path);
            KIJECNFNNDB_JsonWriter writer = new KIJECNFNNDB_JsonWriter();
            writer.GALFODHMEOL_PrettyPrint = true;
            snsData.EJCOJCGIBNG_ToJson(writer);
            string fileStr = writer.ToString();
            File.WriteAllText(sns_data_path + "snslist.json", fileStr);
        }
    }
}

#endif

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
public class UMOMember : Attribute
{
    public string ReaderMember;
    public string ReaderMemberChild;
    public string Name;
    public string Desc;
    public string ReaderDisplay;
    public string Display;
    public bool CryptedInMemory = false;
}

[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
public class UMOClass : Attribute
{
    public string ReaderClass;
}
