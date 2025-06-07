
#if UNITY_EDITOR
using System;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public static class StringLiteralsConverter
{
    public static string PoPath = Application.dataPath + "/../../Localization/JpLiteralStrings/po/";

    [MenuItem("UMO/Localization/Export JpStringLiterals strings")]
    public static void GeneratePoFile()
    {
        PoFile poFile = new PoFile();

        Type t = Type.GetType("JpStringLiterals");

        string OldLang = RuntimeSettings.CurrentSettings.Language;
        bool oldSet1 = RuntimeSettings.CurrentSettings.ShowStringUsed;
        bool oldSet2 = RuntimeSettings.CurrentSettings.UseTmpLocalizationFiles;
        RuntimeSettings.CurrentSettings.Language = "jp";
        RuntimeSettings.CurrentSettings.ShowStringUsed = false;
        RuntimeSettings.CurrentSettings.UseTmpLocalizationFiles = false;

        PropertyInfo[] fields = t.GetProperties(BindingFlags.Static | BindingFlags.Public);
        foreach(var k in fields)
        {
            poFile.translationData.Add(k.Name, k.GetValue(null).ToString());
        }

        RuntimeSettings.CurrentSettings.Language = OldLang;
        RuntimeSettings.CurrentSettings.ShowStringUsed = oldSet1;
        RuntimeSettings.CurrentSettings.UseTmpLocalizationFiles = oldSet2;

        Directory.CreateDirectory(PoPath);
        poFile.SaveFile(PoPath + "messages.pot", true);
        poFile.SaveFile(PoPath + "jp.po");
    }
}
#endif