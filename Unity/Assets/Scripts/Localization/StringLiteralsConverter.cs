
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

        PropertyInfo[] fields = t.GetProperties(BindingFlags.Static | BindingFlags.Public);
        foreach(var k in fields)
        {
            poFile.translationData.Add(k.Name, k.GetValue(null).ToString());
        }

        Directory.CreateDirectory(PoPath);
        poFile.SaveFile(PoPath + "messages.pot", true);
        poFile.SaveFile(PoPath + "jp.po");
    }
}
#endif