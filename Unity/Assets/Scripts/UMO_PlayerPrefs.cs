using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class UMO_PlayerPrefs
{
    static Dictionary<string, int> intValues = new Dictionary<string, int>();
    static string path = Application.persistentDataPath + "/pref.json";
    static bool isLoaded = false;
    static int version = 1;

    public static void SetInt(string key, int value)
    {
        if(intValues.ContainsKey(key))
            intValues[key] = value;
        else
            intValues.Add(key, value);
    }

    public static void CheckLoad()
    {
        if(isLoaded)
            return;
        isLoaded = true;
        if(!File.Exists(path))
            return;
        string saveData = File.ReadAllText(path);
		EDOHBJAPLPF_JsonData data = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(saveData);
        if(data.BBAJPINMOEP_Contains("ints"))
        {
            EDOHBJAPLPF_JsonData b = data["ints"];
            for(int i = 0; i < b.HNBFOAJIIAL_Count; i++)
            {
                intValues.Add((string)b[i]["k"], (int)b[i]["v"]);
            }
        }
        if(GetInt("version", 0) < 1)
        {
            SetInt("forceWideScreen", 1);
        }
    }

    public static int GetInt(string key, int defaultValue)
    {
        CheckLoad();
        if(intValues.ContainsKey(key))
            return intValues[key];
        return defaultValue;
    }
    public static void Save()
    {
        SetInt("version", 1);
        EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
        data["ints"] = new EDOHBJAPLPF_JsonData();
        data["ints"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
        foreach(var k in intValues)
        {
            EDOHBJAPLPF_JsonData d = new EDOHBJAPLPF_JsonData();
            d["k"] = k.Key;
            d["v"] = k.Value;
            data["ints"].Add(d);
        }

        KIJECNFNNDB_JsonWriter writer = new KIJECNFNNDB_JsonWriter();
        writer.GALFODHMEOL_PrettyPrint = true;
        data.EJCOJCGIBNG_ToJson(writer);
        string saveData = writer.ToString();

        File.WriteAllText(path, saveData);
    }
}