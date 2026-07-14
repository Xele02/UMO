using XeSys;
using System.Collections.Generic;
using System.Linq;
using System;



[Serializable]
public class DlcLanguage : DlcContent
{
    public List<UMOPopupLanguage.LanguageInfo> LanguageCodes;

    public override void Load(EDOHBJAPLPF_JsonData json_data)
    {
        LanguageCodes = new List<UMOPopupLanguage.LanguageInfo>();
        if(json_data.BBAJPINMOEP_Contains("languages"))
        {
            Enabled = true;
            for(int i = 0; i < json_data["languages"].HNBFOAJIIAL_Count; i++)
            {
                if(json_data["languages"][i].BBAJPINMOEP_Contains("code"))
                {
                    UMOPopupLanguage.LanguageInfo lang = new UMOPopupLanguage.LanguageInfo();
                    lang.name = (string)json_data["languages"][i]["code"];
                    if(json_data["languages"][i].BBAJPINMOEP_Contains("name"))
                        lang.languageName = (string)json_data["languages"][i]["name"];
                    LanguageCodes.Add(lang);
                }
            }
        }
    }

    public override void Save(EDOHBJAPLPF_JsonData json_data)
    {
        json_data["languages"] = new EDOHBJAPLPF_JsonData();
        json_data["languages"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
        foreach(var l in LanguageCodes)
        {
            EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
            json["code"] = l.name;
            json["name"] = l.languageName;
            json_data["languages"].Add(json);
        }
    }

#if UNITY_EDITOR
    public override void FillBuilder(DlcBuilder builder)
    {
        if(LanguageCodes != null)
            builder.Bank.SetLanguagesCode(LanguageCodes.Select(c => c.name).ToList());
    }
#endif

}

