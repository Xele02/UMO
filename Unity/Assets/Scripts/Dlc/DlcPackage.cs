

using System;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;
using XeSys;
using System.Collections.Generic;
using System.Linq;




#if UNITY_EDITOR
using UnityEditor;
#endif

public class DlcDisplayCheckAttribute : PropertyAttribute
{
}

public class DlcCheckValueAttribute : PropertyAttribute
{
    virtual public bool IsValid(object value) { return true; }
#if UNITY_EDITOR
    virtual public bool IsValidProperty(SerializedProperty prop) { return true; }
#endif
}

public class DlcCheckStringValueAttribute : DlcCheckValueAttribute
{
    override public bool IsValid(object value)
    { 
        if(value is string)
            return IsValidString(value as string);
        return false;
    }
#if UNITY_EDITOR
    override public bool IsValidProperty(SerializedProperty prop) 
    { 
        if(prop.propertyType == SerializedPropertyType.String)
            return IsValidString(prop.stringValue); 
        return false;
    }
#endif
    virtual public bool IsValidString(string value) { return true; }
}

public class DlcCheckEmptyStringValueAttribute : DlcCheckStringValueAttribute
{
    public override bool IsValidString(string value)
    {
        return !string.IsNullOrEmpty(value);
    }
}

public class DlcCheckRegexValueAttribute : DlcCheckStringValueAttribute
{
    public string RegexVal;

    public override bool IsValidString(string value)
    {
        return Regex.IsMatch(value, RegexVal);
    }
}

[CreateAssetMenu(fileName = "Dlc", menuName = "ScriptableObjects/DlcSetting", order = 1)]
public class DlcPackage : ScriptableObject
{
    const string RegexPackage = @"^[a-zA-Z0-9][a-zA-Z0-9\.\-_]*$";
    [DlcCheckRegexValueAttribute(RegexVal = RegexPackage)]
    public string PackageName;
    [DlcCheckEmptyStringValueAttribute]
    public string Title;
    public int Version = 1;
    [DlcCheckRegexValue(RegexVal = @"^[0-9]+\.[0-9]+\.[0-9]+$")]
    public string MinUMOVersion;

    public DlcCostume costume = new DlcCostume();
    public DlcLoginBonus loginBonus = new DlcLoginBonus();
    public DlcLanguage language = new DlcLanguage();

    public Dictionary<string, DlcContent> DictContent { get => new Dictionary<string, DlcContent>(){
        {"costume", costume},
        {"login_bonus", loginBonus},
        {"language", language}
    }; }

    [DlcDisplayCheck()]
    public DlcChecker DisplayCheck;

    static public bool PackageNameCheck(string value) { return Regex.IsMatch(value, RegexPackage); }

    protected DlcBuilder CacheBuilders = new DlcBuilder();

    public void LoadInit(string dlcPath)
    {
        if(File.Exists(Path.Combine(dlcPath, "dlc.json")))
        {
            string data = File.ReadAllText(Path.Combine(dlcPath, "dlc.json"));
            EDOHBJAPLPF_JsonData json_data = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(data);
            LoadInitInner(json_data);
        }
    }
    protected void LoadInitInner(EDOHBJAPLPF_JsonData json_data)
    {
        if(json_data.BBAJPINMOEP_Contains("package_name"))
        {
            PackageName = (string)json_data["package_name"];
        }
        if(json_data.BBAJPINMOEP_Contains("title"))
        {
            Title = (string)json_data["title"];
        }
        if(json_data.BBAJPINMOEP_Contains("version"))
        {
            Version = (int)json_data["version"];
        }
        if(json_data.BBAJPINMOEP_Contains("min_umo_version"))
        {
            MinUMOVersion = (string)json_data["min_umo_version"];
        }
        foreach(var content in DictContent)
        {
            content.Value.Load(json_data);
        }
    }

    protected void SaveInner(EDOHBJAPLPF_JsonData json_data)
    {
        json_data["package_name"] = PackageName;
        json_data["title"] = Title;
        json_data["version"] = Version;
        json_data["min_umo_version"] = MinUMOVersion;
        foreach(var content in DictContent)
        {
            if(content.Value.Enabled)
                content.Value.Save(json_data);
        }
    }

    public bool IsUMOVersionCompatible()
    {
        string UMOVersion = Application.version;
        string[] UMOSplit = UMOVersion.Split(new char[]{'.'});
        string[] SelfSplit = MinUMOVersion.Split(new char[]{'.'});
        for(int i = 0; i < 3; i++)
        {
            if(int.Parse(UMOSplit[i]) < int.Parse(SelfSplit[i]))
                return false;
            else if(int.Parse(UMOSplit[i]) > int.Parse(SelfSplit[i]))
                return true;
        }
        return true;
    }

    public virtual void UpdateDatabase(string dlcPath)
    {
        DlcContext CurrentContext = GetContext();
        CurrentContext.SetCurrentDlc(this);
        foreach(var content in DictContent)
        {
            if(content.Value.Enabled)
                content.Value.UpdateDatabase(dlcPath, this);
        }
        CacheBuilders.UpdateDatabase(CurrentContext);
    }

    public virtual void UpdateFileList(string dlcPath)
    {
        //DlcContent[] Content = GetContentInfos();
        DlcContext CurrentContext = GetContext();
        CurrentContext.SetCurrentDlc(this);
        /*ForEachContent(CurrentContext, Content, (DlcContent content) => {
            content.UpdateFileList(dlcPath, CurrentContext);
        });*/
        foreach(var content in DictContent)
        {
            if(content.Value.Enabled)
                content.Value.UpdateFileList(dlcPath);
        }
        CacheBuilders.UpdateFileList(dlcPath, CurrentContext);
    }

    public virtual void UpdateBank(string bankName, MessageBank bank)
    {
        DlcContext CurrentContext = GetContext();
        CurrentContext.SetCurrentDlc(this);
        foreach(var content in DictContent)
        {
            if(content.Value.Enabled)
                content.Value.UpdateBank(bankName, bank);
        }
        CacheBuilders.UpdateBank(CurrentContext, bankName, bank);
    }

#if UNITY_EDITOR
    
    public void UpdateBuilderCache()
    {
        CacheBuilders = new DlcBuilder();
        foreach(var content in DictContent)
        {
            if(content.Value.Enabled)
                content.Value.FillBuilder(CacheBuilders);
        }
    }

    public bool IsValid(out string Error)
    {
        Error = "";
        // if(!PackageNameCheck(PackageName))
        //     return false;
        // if(string.IsNullOrEmpty(Title))
        //     return false;
        foreach(var m in GetType().GetFields())
        {
            foreach(var attr in m.GetCustomAttributes(typeof(DlcCheckValueAttribute), true))
            {
                if(!(attr as DlcCheckValueAttribute).IsValid(m.GetValue(this)))
                    return false;
            }
        }

        UpdateBuilderCache();
        DlcContext CurrentContext = GetContext();
        CurrentContext.SetCurrentDlc(this);
        foreach(var content in DictContent)
        {
            if(!content.Value.Enabled)
                continue;
            if(content.Value.IsValid(out Error) == 2)
                return false;
        }
        return CacheBuilders.IsValid(CurrentContext, out Error, true) != 2;
    }

    public bool Build(bool checkLanguage = true)
    {
        if(!IsValid(out string Error))
        {
            if (!EditorUtility.DisplayDialog("Build Error", "DLC Setup has error, the result package can make the game crash.\n"+Error, "Continue", "Cancel"))
            {
                return false;
            }
        }

        if(!BuildPipeline.IsBuildTargetSupported(BuildTargetGroup.Android, BuildTarget.Android))
        {
            if (!EditorUtility.DisplayDialog("Build Error", "Android build is not supported. The bundles will be build on target "+EditorUserBuildSettings.activeBuildTarget+" and will only work on it.", "Continue", "Cancel"))
            {
                return false;
            }
        }

        if(checkLanguage && language.Enabled)
        {
            // When language is set, build one package per language

            string thisPath = AssetDatabase.GetAssetPath(this);
            foreach(var lang in language.LanguageCodes)
            {
                string tmpPath = Path.Combine(Path.GetDirectoryName(thisPath), "tmp.asset");
                AssetDatabase.CopyAsset(thisPath, tmpPath);
                DlcPackage builder = AssetDatabase.LoadAssetAtPath<DlcPackage>(tmpPath);
                builder.PackageName = PackageName + "-" + lang.name;
                builder.Title = Title + " ("+lang.languageName+")";
                builder.language.Enabled = true;
                builder.language.LanguageCodes = new List<UMOPopupLanguage.LanguageInfo>();
                builder.language.LanguageCodes.Add(lang);
                AssetDatabase.SaveAssets();
                try
                {
                    builder.Build(false);
                }
                catch(System.Exception e)
                {
                    UnityEngine.Debug.LogError(e.ToString());
                }
                AssetDatabase.DeleteAsset(tmpPath);
            }
            return true;
        }

        string PkgName = PackageNameCheck(PackageName) ? PackageName : "dlc";

        string tmpBuildDir = Path.Combine( Application.dataPath, "../Build/TmpBundles", PkgName);
        if(Directory.Exists(tmpBuildDir))
            Directory.Delete(tmpBuildDir, true);
        string dlcBuildDir = Path.Combine( tmpBuildDir, "Dlc" );
        Directory.CreateDirectory(dlcBuildDir);

        UpdateBuilderCache();
        DlcContext Context = GetContext();
        Context.SetCurrentDlc(this);
        foreach(var content in DictContent)
        {
            if(content.Value.Enabled)
                content.Value.Build(Context, tmpBuildDir, dlcBuildDir);
        }
        CacheBuilders.Build(Context, tmpBuildDir, dlcBuildDir);

        EDOHBJAPLPF_JsonData json_data = new EDOHBJAPLPF_JsonData();
        SaveInner(json_data);
        File.WriteAllText(Path.Combine( dlcBuildDir, "dlc.json"), json_data.EJCOJCGIBNG_ToJson());
        
        ICSharpCode.SharpZipLib.Zip.FastZip Compress = new ICSharpCode.SharpZipLib.Zip.FastZip();
        string suffix = "";
        if(Directory.Exists(Path.Combine(dlcBuildDir, "bundles")))
            suffix = "_" + EditorUserBuildSettings.activeBuildTarget;
        Compress.CreateZip( Path.Combine( tmpBuildDir, PkgName+"_"+Version+suffix+".zip"), dlcBuildDir, true, null);
        Compress.CreateZip( Path.Combine( tmpBuildDir, PkgName+"_"+Version+"_Source.zip"), Context.GetAbsolutePath(Context.BasePath), true, null);
        return true;
    }

    public void CreateMissingAssets()
    {
        UpdateBuilderCache();
        DlcContext CurrentContext = GetContext();
        CurrentContext.SetCurrentDlc(this);
        CacheBuilders.CreateMissingAssets(CurrentContext);
        AssetDatabase.Refresh();
    }

    public List<DlcDisplayCheckDrawer.GroupLabel> DisplayAssetsCheck()
    {
        DlcContext CurrentContext = GetContext();
        CurrentContext.SetCurrentDlc(this);
        if(CurrentContext.BasePath == "")
            return new List<DlcDisplayCheckDrawer.GroupLabel>();
        if(CacheBuilders == null)
            UpdateBuilderCache();
        return CacheBuilders.DisplayAssetCheck(CurrentContext);
        /*DlcBuilderBase[] contentInfoStruct = GetContentInfos();
        ForEachContent(CurrentContext, contentInfoStruct, (DlcBuilderBase content) => {
            content.DisplayAssetCheck(CurrentContext);
        });*/
    }

    static public void ForEachContent(DlcContext context, List<DlcBuilderBase> list, Action<DlcBuilderBase> func)
    {
        if(list == null)
            return;
        foreach(var content in list)
        {
            context.AddContent(content);
            func(content);
            context.PopContent();
        }
    }

    static public void ForEachContent(DlcContext context, List<DlcBuilderBase> list, Func<DlcBuilderBase, bool> func)
    {
        if(list == null)
            return;
        foreach(var content in list)
        {
            context.AddContent(content);
            if(!func(content))
            {
                context.PopContent();
                break;
            }
            context.PopContent();
        }
    }

    public virtual void RefreshContent()
    {
        
    }
    public virtual void CheckModif()
    {

    }

#endif

    public virtual DlcContext GetContext()
    {
        return new DlcContext();
    }

    public void FillLanguageInfos(List<UMOPopupLanguage.LanguageInfo> languageInfos)
    {
        if(DictContent["language"].Enabled)
        {
            languageInfos.AddRange((DictContent["language"] as DlcLanguage).LanguageCodes);
        }
    }

}

[Serializable]
public class DlcChecker
{

}

#if UNITY_EDITOR
public static class DlcBase_Editor
{
    private static GUIStyle RedLabelStyle_;
    public static GUIStyle RedLabelStyle {
        get {
            if(RedLabelStyle_ == null)
            {
                RedLabelStyle_ = new GUIStyle(EditorStyles.label);
                RedLabelStyle_.normal.textColor = Color.red;
            }
            return RedLabelStyle_;
        }
    }
}

[CustomPropertyDrawer(typeof(DlcCheckValueAttribute), true)]
public class DlcCheckStringValueDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        Color oldColor = GUI.backgroundColor;
        DlcCheckValueAttribute attr = attribute as DlcCheckValueAttribute;
        if (!attr.IsValidProperty(property))
        {
            GUI.backgroundColor = Color.red;
        }
        EditorGUI.PropertyField(position, property, label);
        GUI.backgroundColor = oldColor;
        EditorGUI.EndProperty();
    }
}

[CustomPropertyDrawer(typeof(DlcDisplayCheckAttribute))]
public class DlcDisplayCheckDrawer : PropertyDrawer
/*{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        DlcPackage owner = property.serializedObject.targetObject as DlcPackage;
        owner.DisplayAssetsCheck();
    }
}*/

//[CustomPropertyDrawer(typeof(DlcChecker))]
//public class DlcChecker_Inspector : PropertyDrawer
{
    public class GroupLabel
    {
        public string Name;
        public int ValidityStatus = -1;
        public List<GroupLabel> children = new List<GroupLabel>();
    }
    //     SerializedProperty Bundles;

    //     DlcBuilderBase[] bundlesInfoStruct;
    //     protected DlcContext CurrentContext;

    //     public static GUIStyle RedLabelStyle;

    //     SerializedProperty PackageNameProp;
    //     SerializedProperty TitleProp;
    //     SerializedProperty VersionProp;
    //     SerializedProperty MinUMOVersionProp;

    //     protected string Title = "Base DLC";

    //     void OnEnable()
    //     {
    //         RedLabelStyle = new GUIStyle(EditorStyles.label);
    //         RedLabelStyle.normal.textColor = Color.red;
    //         InitProperties();
    //     }

    //     protected virtual void InitProperties()
    //     {
    //         //Bundles = serializedObject.FindProperty("Bundles");
    //         ((DlcBase)serializedObject.targetObject).RefreshContent();  
    //         bundlesInfoStruct = ((DlcBase)serializedObject.targetObject).GetContentInfos();
    //         PackageNameProp = serializedObject.FindProperty("PackageName");
    //         TitleProp = serializedObject.FindProperty("Title");
    //         VersionProp = serializedObject.FindProperty("Version");
    //         MinUMOVersionProp = serializedObject.FindProperty("MinUMOVersion");
    //     }

    //     public virtual void DrawDlcProperties()
    //     {

    //     }

    //     protected void DisplayPropertyChecked(SerializedProperty prop, Func<SerializedProperty, bool> check)
    //     {
    //         Color oldColor = GUI.backgroundColor;
    //         if (!check(prop))
    //         {
    //             GUI.backgroundColor = Color.red;
    //         }
    //         EditorGUILayout.PropertyField(prop);
    //         GUI.backgroundColor = oldColor;
    //     }

    //     protected bool CheckEmptyString(SerializedProperty prop)
    //     {
    //         return !string.IsNullOrEmpty(prop.stringValue);
    //     }

    //     protected Func<SerializedProperty, bool> CheckStringProp(Func<string, bool> check)
    //     {
    //         return (SerializedProperty p) => check(p.stringValue);
    //     }

    protected int CountRecurs(List<GroupLabel> list)
    {
        int res = list.Count();
        foreach(var l in list)
        {
            res += CountRecurs(l.children);
        }
        return res;
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        float height = EditorStyles.label.CalcHeight(new GUIContent("a"), 200);
        if(!property.serializedObject.isEditingMultipleObjects)
        {
            DlcPackage dlc = property.serializedObject.targetObject as DlcPackage;
            List<GroupLabel> toDisplay = dlc.DisplayAssetsCheck();
            return CountRecurs(toDisplay) * height
                + EditorStyles.boldLabel.CalcHeight(new GUIContent("a"), 200) * 3;
        }
        return base.GetPropertyHeight(property, label);
    }

    private void DisplayRecurs(List<GroupLabel> list, ref Rect position)
    {
        float height = EditorStyles.label.CalcHeight(new GUIContent("a"), 200);
        foreach(var l in list)
        {
            EditorGUI.LabelField(new Rect(position.x, position.y, position.width, height), l.Name, l.ValidityStatus == 2 ? DlcBase_Editor.RedLabelStyle : EditorStyles.label);
            position.y = position.y + height;
            EditorGUI.indentLevel++;
            DisplayRecurs(l.children, ref position);
            EditorGUI.indentLevel--;
        }
    }

    private int UpdateCount = -1;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        if(!property.serializedObject.isEditingMultipleObjects)
        {
            DlcPackage dlc = property.serializedObject.targetObject as DlcPackage;
            float boldHeight = EditorStyles.boldLabel.CalcHeight(new GUIContent("a"), 200);
            if(GUI.Button(new Rect(position.x, position.y, position.width, boldHeight), "Build"))
            {
                EditorGUI.EndProperty();
                dlc.Build();
                UpdateCount++;
                return;
            }
            position.y = position.y + boldHeight;
            EditorGUI.LabelField(new Rect(position.x, position.y, position.width, boldHeight), "File check", EditorStyles.boldLabel);
            position.y = position.y + boldHeight;
            if(GUI.Button(new Rect(position.x, position.y, position.width, boldHeight), "Generate missing files"))
            {
                dlc.CreateMissingAssets();
                dlc.UpdateBuilderCache();
                EditorGUI.EndProperty();
                UpdateCount++;
                return;
            }
            position.y = position.y + boldHeight;
            if(UpdateCount < 0)
                dlc.UpdateBuilderCache();
            List<GroupLabel> toDisplay = dlc.DisplayAssetsCheck();
            DisplayRecurs(toDisplay, ref position);
        }
        EditorGUI.EndProperty();
        UpdateCount++;
//         GUIStyle style = new GUIStyle();
//         EditorGUILayout.LabelField(Title, EditorStyles.boldLabel);
//         if(GUILayout.Button("Build DLC"))
//         {
//             ((DlcBase)serializedObject.targetObject).Build();
//             return;
//         }
//         DisplayPropertyChecked(PackageNameProp, CheckStringProp(DlcBase.PackageNameCheck));
//         DisplayPropertyChecked(TitleProp, CheckEmptyString);

//         EditorGUILayout.PropertyField(VersionProp);

//         DisplayPropertyChecked(MinUMOVersionProp, (SerializedProperty prop) => {
//             return Regex.IsMatch(prop.stringValue, @"^[0-9]+\.[0-9]+\.[0-9]+$");
//         });

//         EditorGUILayout.Separator();
//         DrawDlcProperties();
//         EditorGUILayout.Separator();
//         DrawDlcAssetCheck();
        
//         //EditorGUILayout.PropertyField(Bundles);
//         serializedObject.ApplyModifiedProperties();
//         CurrentContext.DLC.CheckModif();
    }

//     protected virtual void CreateMissingAssets()
//     {
//         ((DlcBase)serializedObject.targetObject).CreateMissingAssets();
//     }

//     protected virtual void DisplayAssetsCheck()
//     {
//         CurrentContext.SetCurrentDlc((DlcBase)serializedObject.targetObject);
//         CurrentContext.DLC.DisplayAssetsCheck();
//     }

//     protected void DrawDlcAssetCheck()
//     {
//         EditorGUILayout.Separator();
//         EditorGUILayout.LabelField("Assets check", EditorStyles.boldLabel);
//         if(GUILayout.Button("Create placeholder missing assets"))
//         {
//             CreateMissingAssets();
//         }
//         DisplayAssetsCheck();
//     }
}
#endif
