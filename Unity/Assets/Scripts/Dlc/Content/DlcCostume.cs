


using UnityEngine;
using XeSys;
using UnityEngine.Localization.SmartFormat;
using System.Collections.Generic;
using System.Linq;
using System;







#if UNITY_EDITOR
using UnityEditor;
#endif

[Serializable]
public class DlcCostume : DlcContent
{
    [Serializable]
    public class CostumeSetup
    {
        public int DivaId;
        public int CostumeId;
        public int CostumePrismId;
        public DlcTranslatedString CostumeName = new DlcTranslatedString();
    }
    public List<CostumeSetup> Costumes = new List<CostumeSetup>();

    public override void Load(EDOHBJAPLPF_JsonData json_data)
    {
        if(json_data.BBAJPINMOEP_Contains("costume"))
        {
            Enabled = true;
            Costumes = new List<CostumeSetup>();
            for(int i = 0; i < json_data["costume"].HNBFOAJIIAL_Count; i++)
            {
                CostumeSetup setup = new CostumeSetup();
                if(json_data["costume"][i].BBAJPINMOEP_Contains("diva_id"))
                    setup.DivaId = (int)json_data["costume"][i]["diva_id"];
                else continue;
                if(json_data["costume"][i].BBAJPINMOEP_Contains("costume_id"))
                    setup.CostumeId = (int)json_data["costume"][i]["costume_id"];
                else continue;
                if(json_data["costume"][i].BBAJPINMOEP_Contains("costume_prism_id"))
                    setup.CostumePrismId = (int)json_data["costume"][i]["costume_prism_id"];
                else continue;
                if(json_data["costume"][i].BBAJPINMOEP_Contains("costume_name"))
                    setup.CostumeName.Deserialize(json_data["costume"][i]["costume_name"]);
                Costumes.Add(setup);
            }
        }
    }

    public override void Save(EDOHBJAPLPF_JsonData json_data)
    {
        if(Costumes.Count > 0)
        {
            json_data["costume"] = new EDOHBJAPLPF_JsonData();
            json_data["costume"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
            foreach(var cos in Costumes)
            {
                EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
                data["diva_id"] = cos.DivaId;
                data["costume_id"] = cos.CostumeId;
                data["costume_prism_id"] = cos.CostumePrismId;
                data["costume_name"] = new EDOHBJAPLPF_JsonData();
                cos.CostumeName.Serialize(data["costume_name"]);
                json_data["costume"].Add(data);
            }
        }
    }

#if UNITY_EDITOR
    public override void FillBuilder(DlcBuilder builder)
    {
        foreach(var s in Costumes)
        {
            AddBuilder(builder, s);
        }
    }
#endif

    public static void AddBuilder(DlcBuilder builder, CostumeSetup Setup)
    {
        builder.Bundles.Bundles.AddRange(
            new DlcBundleBuilder[]{
                new DlcBundleBuilder() 
                { 
                    Path = "dv/cs/", 
                    NamePattern = Smart.Format("{DivaId:D3}_{CostumePrismId:D3}.xab", Setup), 
                    Required = true, 
                    Files = new DlcFileBuilder[]
                    {
                        new DlcFilePrefabBuilder() { Required = true, NamePattern = Smart.Format("diva_{DivaId:D3}_cos_{CostumePrismId:D3}_prefab", Setup) },
                        new DlcFilePrefabBuilder() { Required = false, NamePattern = Smart.Format("diva_{DivaId:D3}_cos_{CostumePrismId:D3}_mike_prefab", Setup) },
                        new DlcFilePrefabBuilder() { Required = false, NamePattern = Smart.Format("diva_{DivaId:D3}_cos_{CostumePrismId:D3}_sp_effect_01", Setup) },
                        new DlcFilePrefabBuilder() { Required = false, NamePattern = Smart.Format("diva_{DivaId:D3}_cos_{CostumePrismId:D3}_sp_effect_02", Setup) },
                        new DlcFilePrefabBuilder() { Required = false, NamePattern = Smart.Format("diva_{DivaId:D3}_cos_{CostumePrismId:D3}_sp_effect_03", Setup) },
                        new DlcFilePrefabBuilder() { Required = false, NamePattern = Smart.Format("diva_{DivaId:D3}_cos_{CostumePrismId:D3}_wind", Setup) },

                        new DlcFileAnimationBuilder() { Required = false, NamePattern = Smart.Format("diva_{DivaId:D3}_menu_idle_body", Setup) },
                        new DlcFileAnimationBuilder() { Required = false, NamePattern = Smart.Format("diva_{DivaId:D3}_menu_idle_face", Setup) },
                        new DlcFileAnimationBuilder() { Required = false, NamePattern = Smart.Format("diva_{DivaId:D3}_menu_idle_mouth", Setup) },
                        new DlcFileAnimationBuilder() { Required = false, NamePattern = Smart.Format("diva_{DivaId:D3}_result_start_h_body", Setup) },
                        new DlcFileAnimationBuilder() { Required = false, NamePattern = Smart.Format("diva_{DivaId:D3}_result_start_h_face", Setup) },
                        new DlcFileAnimationBuilder() { Required = false, NamePattern = Smart.Format("diva_{DivaId:D3}_result_start_h_mouth", Setup) },
                        new DlcFileAnimationBuilder() { Required = false, NamePattern = Smart.Format("diva_{DivaId:D3}_result_end_loop_h_body", Setup) },
                        new DlcFileAnimationBuilder() { Required = false, NamePattern = Smart.Format("diva_{DivaId:D3}_result_end_loop_h_face", Setup) },
                        new DlcFileAnimationBuilder() { Required = false, NamePattern = Smart.Format("diva_{DivaId:D3}_result_end_loop_h_mouth", Setup) }
                    }
                },
                new DlcBundleBuilder() 
                { 
                    Path = "dv/cs/", 
                    NamePattern = Smart.Format("{DivaId:D3}_{CostumePrismId:D3}_00.xab", Setup), // whatever color id
                    Required = false, 
                    Files = new DlcFileBuilder[]
                    {
                        // Todo conditional file for texture
                    }
                },
                new DlcBundleBuilder() 
                { 
                    Path = "dv/bs/", 
                    NamePattern = Smart.Format("{DivaId:D3}_{CostumePrismId:D3}.xab", Setup),
                    Required = true, 
                    Files = new DlcFileBuilder[]
                    {
                        // Todo conditional file for the 30 bs
                    }
                },
                new DlcBundleBuilder() 
                { 
                    Path = "ct/dv/ps/", 
                    NamePattern = Smart.Format("{DivaId:D2}_{CostumePrismId:D2}.xab", Setup),
                    Required = true, 
                    Files = new DlcFileBuilder[]
                    {
                        new DlcFileTextureBuilder() { Required = true, NamePattern = Smart.Format("{DivaId:D2}_{CostumePrismId:D2}", Setup), TextureType=DlcFileTextureBuilder.ETextureType.BaseMask, MinSize = new Vector2(512, 512), MaxSize = new Vector2(512, 512) }
                    }
                },
                new DlcBundleBuilder() 
                { 
                    Path = "ct/dv/co/", 
                    NamePattern = Smart.Format("{DivaId:D2}_{CostumePrismId:D3}.xab", Setup),
                    Required = true, 
                    Files = new DlcFileBuilder[]
                    {
                        new DlcFileTextureBuilder() { Required = true, NamePattern = Smart.Format("{DivaId:D2}_{CostumePrismId:D3}", Setup), TextureType=DlcFileTextureBuilder.ETextureType.BaseMask, MinSize = new Vector2(256, 256), MaxSize = new Vector2(256, 256) }
                    }
                },
                /*new DlcBundleBuilder() 
                { 
                    Path = "ct/dv/co/", 
                    NamePattern = "{DivaId:D2}_{CostumePrismId:D3}_{ColorId:2}.xab",
                    Required = false, 
                    Files = new DlcFileInfo[]
                    {
                        new DlcFileTextureBuilder() { Required = true, NamePattern = "{DivaId:D2}_{CostumePrismId:D3}_{ColorId:2}", TextureType=DlcFileTextureBuilder.ETextureType.BaseMask, MinSize = new Vector2(256, 256), MaxSize = new Vector2(256, 256) }
                    }
                },*/
                new DlcBundleBuilder() 
                { 
                    Path = "ct/dv/me/01/", 
                    NamePattern = Smart.Format("{DivaId:D2}_{CostumePrismId:D2}.xab", Setup),
                    Required = true, 
                    Files = new DlcFileBuilder[]
                    {
                        new DlcFileTextureBuilder() { Required = true, NamePattern = Smart.Format("{DivaId:D2}_{CostumePrismId:D2}", Setup), TextureType=DlcFileTextureBuilder.ETextureType.BaseMask, MinSize = new Vector2(128, 128), MaxSize = new Vector2(128, 128) },
                    }
                },
                new DlcBundleBuilder() 
                { 
                    Path = "ct/dv/me/02/", 
                    NamePattern = Smart.Format("{DivaId:D2}_{CostumePrismId:D2}.xab", Setup),
                    Required = true, 
                    Files = new DlcFileBuilder[]
                    {
                        new DlcFileTextureBuilder() { Required = true, NamePattern = Smart.Format("{DivaId:D2}_{CostumePrismId:D2}", Setup), TextureType=DlcFileTextureBuilder.ETextureType.BaseMask, MinSize = new Vector2(256, 256), MaxSize = new Vector2(256, 256) },
                    }
                },
                new DlcBundleBuilder() 
                { 
                    Path = "ct/dv/me/03/", 
                    NamePattern = Smart.Format("{DivaId:D2}_{CostumePrismId:D2}.xab", Setup),
                    Required = true, 
                    Files = new DlcFileBuilder[]
                    {
                        new DlcFileTextureBuilder() { Required = true, NamePattern = Smart.Format("{DivaId:D2}_{CostumePrismId:D2}", Setup), TextureType=DlcFileTextureBuilder.ETextureType.BaseMask, MinSize = new Vector2(512, 512), MaxSize = new Vector2(512, 512) },
                    }
                },
                new DlcBundleBuilder() 
                { 
                    Path = "ct/im/", 
                    NamePattern = Smart.Format("5{CostumeId:D4}.xab", Setup),
                    Required = true, 
                    Files = new DlcFileBuilder[]
                    {
                        new DlcFileTextureBuilder() { Required = true, NamePattern = Smart.Format("5{CostumeId:D4}", Setup), TextureType=DlcFileTextureBuilder.ETextureType.BaseMask, MinSize = new Vector2(128, 128), MaxSize = new Vector2(128, 128) },
                    }
                },
                new DlcBundleBuilder() 
                { 
                    Path = "ct/dv/tx/bu/", 
                    NamePattern = Smart.Format("{DivaId:D3}_{CostumePrismId:D3}.xab", Setup),
                    Required = true, 
                    Files = new DlcFileBuilder[]
                    {
                        new DlcFileTextureBuilder() { Required = true, NamePattern = Smart.Format("{DivaId:D3}_{CostumePrismId:D3}", Setup), TextureType=DlcFileTextureBuilder.ETextureType.BaseMask, MinSize = new Vector2(512, 512), MaxSize = new Vector2(512, 512) },
                    }
                },
                /*new DlcBundleBuilder()  // Only _01, 1 per diva
                { 
                    Path = "ct/dv/me/05/", 
                    NamePattern = "{DivaId:D2}_{CostumePrismId:D2}.xab",
                    Required = true, 
                    Files = new DlcFileBuilder[]
                    {
                        new DlcFileBuilder() { Required = true, NamePattern = "{DivaId:D2}_{CostumePrismId:D2}_base", Type = typeof(Texture) },
                        new DlcFileBuilder() { Required = true, NamePattern = "{DivaId:D2}_{CostumePrismId:D2}_mask", Type = typeof(Texture) }
                    }
                },*/
                /*new DlcBundleBuilder()   // Only _01, 1 per diva
                { 
                    Path = "ct/dv/me/06/", 
                    NamePattern = "{DivaId:D2}_{CostumePrismId:D2}.xab",
                    Required = true, 
                    Files = new DlcFileBuilder[]
                    {
                        new DlcFileBuilder() { Required = true, NamePattern = "{DivaId:D2}_{CostumePrismId:D2}_base", Type = typeof(Texture) },
                        new DlcFileBuilder() { Required = true, NamePattern = "{DivaId:D2}_{CostumePrismId:D2}_mask", Type = typeof(Texture) }
                    }
                },*/
                /*new DlcBundleBuilder()  // Only 1 per diva
                { 
                    Path = "ct/dv/me/07/", 
                    NamePattern = "{DivaId:D2}_{CostumePrismId:D2}.xab",
                    Required = true, 
                    Files = new DlcFileBuilder[]
                    {
                        new DlcFileBuilder() { Required = true, NamePattern = "{DivaId:D2}_{CostumePrismId:D2}_base", Type = typeof(Texture) },
                        new DlcFileBuilder() { Required = true, NamePattern = "{DivaId:D2}_{CostumePrismId:D2}_mask", Type = typeof(Texture) }
                    }
                },*/
                /*new DlcBundleBuilder()  // Only 1 per diva
                { 
                    Path = "ct/dv/me/08/", 
                    NamePattern = "{DivaId:D2}_{CostumePrismId:D2}.xab",
                    Required = true, 
                    Files = new DlcFileBuilder[]
                    {
                        new DlcFileBuilder() { Required = true, NamePattern = "{DivaId:D2}_{CostumePrismId:D2}_base", Type = typeof(Texture) },
                        new DlcFileBuilder() { Required = true, NamePattern = "{DivaId:D2}_{CostumePrismId:D2}_mask", Type = typeof(Texture) }
                    }
                }*/
            }
        );
    }

    public override void UpdateDatabase(string dlcPath, DlcPackage dlc)
    {
        LCLCCHLDNHJ_Costume cosDb = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume;
        // TODO restore the costume at the same id if already installed, for now use the fixed id build
        foreach(var cosSetup in Costumes)
        {
            LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = cosDb.CDENCMNHNGA_table[cosSetup.CostumeId - 1];
            cos.AHHJLDLAPAN_DivaId = (short)cosSetup.DivaId;
            cos.JPIDIENBGKH_CostumeId = cosSetup.CostumeId;
            cos.DAJGPBLEEOB_ModelId = (short)cosSetup.CostumePrismId;
            cos.PPEGAKEIEGM_Enabled = 2;
            cos.DlcId = dlc.PackageName+"-"+cosSetup.CostumeId;
        }
    }

    public override void UpdateFileList(string dlcPath)
    {
        //FileSystemProxy.AddDlcFile("/android/ct/dv/ps/01_80.xab", "/android/ct/dv/ps/01_01.xab");
        //FileSystemProxy.AddDlcFile("/android/dv/bs/001_080.xab", "/android/dv/bs/001_001.xab");
        //FileSystemProxy.AddDlcFile("/android/ct/im/50400.xab", "/android/ct/im/50001.xab");
        //FileSystemProxy.AddDlcFile("/android/ct/dv/co/01_080.xab", "/android/ct/dv/co/01_001.xab");
    }

    public override void UpdateBank(string bankName, MessageBank bank)
    {
        base.UpdateBank(bankName, bank);
        if(bankName == "master")
        {
            foreach(var cos in Costumes)
            {
                bank.UpdateMessage(string.Format("cos_{0:D4}", cos.CostumeId), cos.CostumeName.GetText());
            }
        }
    }

}
