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
using XeApp.Game.AR;
using XeApp.Game.Common;
using XeSys;

public class DocusaurusGenerator
{
    OKGLGHCBCJP_Database Database;
    ARMarkerMasterData ARMarkerData;
    AREventMasterData AREventData;
    IIEDOGCMCIE DbArchive;
    string DataPath;
    private MusicTextDatabase musicText;
    private SNSRoomTextDatabase roomText;

    [MenuItem("Docusaurus/Generate Data")]
    public static void GenerateData()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
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
        //generator.DumpValkyrieImages();
        //generator.DumpARStamp();

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

        try
        {
            str = BBGDKLLEPIB.OGCDNCDMLCA_MxDir + "/db/ar_marker.dat";
            IIEDOGCMCIE tar = new IIEDOGCMCIE();

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
            bool res = tar.KHEKNNFCAOI_Load(request.Result);
            if(!res)
            {
                throw new Exception("Failed to decrypt database");
            }

            CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File db_file = tar.KGHAJGGMPKL_Files.Find((CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File _) => {
                //0xBBB100
                return _.OPFGFINHFCE_Name.Contains(string.Format("{0}.bytes", "ar_marker"));
            });
            if(db_file != null)
            {
                ARMarkerData = new ARMarkerMasterData();
                //File.WriteAllBytes(Application.dataPath + "/../../Data/db/ar_marker.bytes", db_file.DBBGALAPFGC_Data);
                ARMarkerData.Initialize(db_file.DBBGALAPFGC_Data);
            }

        } catch(Exception e)
        {
            UnityEngine.Debug.LogError(e);
        }

        try
        {
            str = BBGDKLLEPIB.OGCDNCDMLCA_MxDir + "/db/ar_event.dat";
            IIEDOGCMCIE tar = new IIEDOGCMCIE();

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
            bool res = tar.KHEKNNFCAOI_Load(request.Result);
            if(!res)
            {
                throw new Exception("Failed to decrypt database");
            }

            CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File db_file = tar.KGHAJGGMPKL_Files.Find((CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File _) => {
                //0xBBB100
                return _.OPFGFINHFCE_Name.Contains(string.Format("{0}.bytes", "ar_event"));
            });
            if(db_file != null)
            {
                AREventData = new AREventMasterData();
                //File.WriteAllBytes(Application.dataPath + "/../../Data/db/ar_event.bytes", db_file.DBBGALAPFGC_Data);
                AREventData.Initialize(db_file.DBBGALAPFGC_Data);
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
            var members = type.GetMembers(BindingFlags.Public|BindingFlags.Instance).Concat(type.GetMembers(BindingFlags.NonPublic|BindingFlags.Instance)).Where(
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
            var members = type.GetMembers(BindingFlags.Public|BindingFlags.Instance).Concat(type.GetMembers(BindingFlags.NonPublic|BindingFlags.Instance)).Where(
                    prop => Attribute.IsDefined(prop, typeof(UMOMember)));
            foreach(var m in members)
            {
                System.Object memberObj = null;
                if(m.MemberType == MemberTypes.Field)
                {
                    FieldInfo field = type.GetField(m.Name, BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Instance);
                    memberObj = field.GetValue(obj);
                }
                else if(m.MemberType == MemberTypes.Property)
                {
                    PropertyInfo prop = type.GetProperty(m.Name, BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Instance);
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

        // Dump AR Marker data
        {
            string block = "ar_marker";
            string database_path = DataPath + "database/"+block+"/";
            CheckPath(database_path);

            db_struct.Add(block);

            {
                EDOHBJAPLPF_JsonData schema = GenerateStructInfo(ARMarkerData.GetType());
                KIJECNFNNDB_JsonWriter writer = new KIJECNFNNDB_JsonWriter();
                writer.GALFODHMEOL_PrettyPrint = true;
                schema.EJCOJCGIBNG_ToJson(writer);
                string fileStr = writer.ToString();
                File.WriteAllText(database_path + block + ".struct.json", fileStr);
            }

            {
                EDOHBJAPLPF_JsonData datas = GenerateDataInfo(ARMarkerData);
                KIJECNFNNDB_JsonWriter writer = new KIJECNFNNDB_JsonWriter();
                writer.GALFODHMEOL_PrettyPrint = true;
                datas.EJCOJCGIBNG_ToJson(writer);
                string fileStr = writer.ToString();
                if(fileStr == "")
                    fileStr = "{}";
                File.WriteAllText(database_path + block + ".data.json", fileStr);
            }
        }

        // Dump AR Event data
        {
            string block = "ar_event";
            string database_path = DataPath + "database/"+block+"/";
            CheckPath(database_path);

            db_struct.Add(block);

            {
                EDOHBJAPLPF_JsonData schema = GenerateStructInfo(AREventData.GetType());
                KIJECNFNNDB_JsonWriter writer = new KIJECNFNNDB_JsonWriter();
                writer.GALFODHMEOL_PrettyPrint = true;
                schema.EJCOJCGIBNG_ToJson(writer);
                string fileStr = writer.ToString();
                File.WriteAllText(database_path + block + ".struct.json", fileStr);
            }

            {
                EDOHBJAPLPF_JsonData datas = GenerateDataInfo(AREventData);
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

        string poPath = Application.dataPath + "/../../Localization/Database/{name}/po/";
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
                if((MessageLoader.eSheet)sheet == MessageLoader.eSheet.master)
                {
                    p = poPath.Replace("{name}", sheet.ToString() + "_sns");
                    poFile.LoadFile(p + "messages_full.pot");
                    poFile.LoadFile(p + lang + ".po");

                    p = poPath.Replace("{name}", sheet.ToString() + "_scene");
                    poFile.LoadFile(p + "messages_full.pot");
                    poFile.LoadFile(p + lang + ".po");
                }

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
                    string p = Application.dataPath + "/../../Localization/JpLiteralStrings/po/";
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


    public void DumpValkyrieImages()
    {
        string[][] FilesList = {
            new string[] {"{0:D2}_{1:D2}_icon", "/ct/vl/01/{0:D2}_{1:D2}.xab"}, // 
            new string[] {"{0:D2}_{1:D2}_portrait", "/ct/vl/02/{0:D2}_{1:D2}.xab"} // 
        };

        string imgs_path = DataPath + "images/valkyries/";
        CheckPath(imgs_path);

        DOKOHKJIDBO a = new DOKOHKJIDBO();
        a.KIDFJDNOGDG();
        a.LoadEditor();

        OAFCKDDEBFN decryptor = new OAFCKDDEBFN();
        decryptor.PGLANLKJBLI_Init();

        foreach(var valkyrie in Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_ValkyrieList)
        {
            if(valkyrie.PPEGAKEIEGM_Enabled != 2)
                continue;
            foreach(var file in FilesList)
            {
                for(int i = 0; i < 3; i++)
                {
                    string outName = string.Format(file[0], valkyrie.GPPEFLKGGGJ_Id, i);
                    if(File.Exists(imgs_path + outName + ".png"))
                        continue;
                    string bundleName = string.Format(file[1], valkyrie.DAJGPBLEEOB_ModelId, i);
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

                    bundle.Unload(true);
                }
            }
        }
    }

    public void DumpARStamp()
    {
        string[][] FilesList = {
            new string[] {"{0:D2}_{1:D4}_stamp", "/ct/ar/st/{0:D2}/ar{1:D4}.xab"}, // 
        };

        string imgs_path = DataPath + "images/ar/";
        CheckPath(imgs_path);

        DOKOHKJIDBO a = new DOKOHKJIDBO();
        a.KIDFJDNOGDG();
        a.LoadEditor();

        OAFCKDDEBFN decryptor = new OAFCKDDEBFN();
        decryptor.PGLANLKJBLI_Init();

        for(int id = 0; id < 400; id++)
        {
            foreach(var file in FilesList)
            {
                for(int i = 1; i <= 2; i++)
                {
                    string outName = string.Format(file[0], i, id);
                    if(File.Exists(imgs_path + outName + ".png"))
                        continue;
                    string bundleName = string.Format(file[1], i, id);
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

                    bundle.Unload(true);
                }
            }
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
