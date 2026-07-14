
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using XeSys;


#if UNITY_EDITOR
using UnityEditor;
#endif

[Serializable]
public class DlcTranslatedString
{
    [SerializeField]
    List<string> Keys = new List<string>();
    [SerializeField]
    List<string> Values = new List<string>();

    public void Serialize(EDOHBJAPLPF_JsonData jsonData)
    {
        jsonData.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object);
        for(int i = 0; i < Keys.Count && i < Values.Count; i++)
        {
            jsonData[Keys[i]] = Values[i];
        }
    }
    public void Deserialize(EDOHBJAPLPF_JsonData jsonData)
    {
        if(jsonData == null)
            return;
        Keys.Clear();
        Values.Clear();
        for(int i = 0; i < jsonData.HNBFOAJIIAL_Count; i++)
        {
            Keys.Add(jsonData.FLPBHNAOIOB(i));
            Values.Add((string)jsonData[i]);
        }
    }
    public string this[int index] 
    {
        get { return Values[index]; }
    }
    public string this[string key] 
    {
        get 
        {
            int idx = Keys.IndexOf(key);
            return idx > -1 ? Values[idx] : ""; 
        }
    }

    public string GetText()
    {
        if(Keys.Contains("bank") && Keys.Contains("id"))
        {
            return MessageManager.Instance.GetMessage(this["bank"], this["id"]);
        }
        if(RuntimeSettings.CurrentSettings.Language != "")
        {
            string res = this[RuntimeSettings.CurrentSettings.Language];
            if(res != "")
            {
                if(res.StartsWith("__"))
                    res = res.Substring(2);
                return res;
            }
        }
        return this["jp"];
    }
}

public class DlcTranslationBankBuilder : DlcBuilderBase
{
    public string InnerPath = "";
    public string BankName = "";
    public List<string> LanguagesCode = new List<string>();

    List<DlcBuilderBase> Content;

    List<DlcBuilderBase> GetContent(DlcContext Context)
    {
        if(Content == null)
        {
            Content = new List<DlcBuilderBase>();
            Content.Add(new DlcFileBuilder() { Exts = new string[] {".po"}, NamePattern = "jp", Required = true, Type = typeof(TextAsset) });
            foreach(var lang in LanguagesCode)
            {
                Content.Add(new DlcFileBuilder() { Exts = new string[] {".po"}, NamePattern = lang, Required = true, Type = typeof(TextAsset) });
            }
        }
        return Content;
    }

#if UNITY_EDITOR
    public override void CreateMissingAssets(DlcContext Context)
    {
        throw new NotImplementedException();
    }

    public override List<DlcDisplayCheckDrawer.GroupLabel> DisplayAssetCheck(DlcContext CurrentContext)
    {
        int valid = IsValid(CurrentContext, out string BundleError);
        if(valid == 1)
            return new List<DlcDisplayCheckDrawer.GroupLabel>();
        List<DlcDisplayCheckDrawer.GroupLabel> res = new List<DlcDisplayCheckDrawer.GroupLabel>()
        {
            new DlcDisplayCheckDrawer.GroupLabel()
            {
                Name = Path.Combine(InnerPath, BankName),
                ValidityStatus = valid
            }
        };
        List<DlcBuilderBase> srcFiles = GetContent(CurrentContext);
        DlcPackage.ForEachContent(CurrentContext, srcFiles.ConvertAll(c => c as DlcBuilderBase), (DlcBuilderBase file) => 
        {
            res[0].children.AddRange(file.DisplayAssetCheck(CurrentContext));
        });
        return res;
    }
    public override string UpdateCurPath(DlcContext Context, string path)
    {
        return Path.Combine(path, InnerPath, BankName, "po");
    }

    public override int IsValid(DlcContext Context, out string Error, bool CheckFiles = false)
    {
        string Error_ = "";
        int Res = 0;
        if(CheckFiles)
        {
            List<DlcBuilderBase> srcFiles = GetContent(Context);
            DlcPackage.ForEachContent(Context, srcFiles.ConvertAll(c => c as DlcBuilderBase), (DlcBuilderBase file) => 
            {
                if(file.IsValid(Context, out Error_, CheckFiles) == 2)
                {
                    Res = 2;
                    return false;
                }
                return true;
            });
        }
        Error = Error_;
        return Res;
    }
#endif
}

public class DlcTranslationBuilder : DlcBuilderBase
{
    private List<string> LanguagesCode = new List<string>();

    public DlcTranslationBuilder()
    {
    }

    private List<DlcBuilderBase> Banks = new List<DlcBuilderBase>();
    List<DlcBuilderBase> Content;

    List<DlcBuilderBase> GetContent(DlcContext CurrentContext)
    {
#if UNITY_EDITOR
        if(Content == null)
        {
            Content = new List<DlcBuilderBase>();

            string basePath = CurrentContext.GetAbsolutePath(Path.Combine(CurrentContext.BasePath, CurrentContext.CurPath));
            if(Directory.Exists(basePath))
            {
                List<string> dirs = new List<string>();
                SearchBankRecurs(basePath, "", ref dirs);
                foreach(var dir in dirs)
                {
                    DirectoryInfo d = new DirectoryInfo(dir);
                    Content.Add(new DlcTranslationBankBuilder() { BankName = d.Name, InnerPath = Path.GetDirectoryName(dir), LanguagesCode = LanguagesCode });
                }
            }
        }
#endif
        return Content;
    }


#if UNITY_EDITOR
    public override void CreateMissingAssets(DlcContext Context)
    {
    }

    private void SearchBankRecurs(string baseDir, string curDir, ref List<string> BankList)
    {
        foreach(var dir in Directory.EnumerateDirectories(baseDir))
        {
            DirectoryInfo d = new DirectoryInfo(dir);
            if(Directory.Exists(Path.Combine(dir, "po")))
            {
                BankList.Add(Path.Combine(curDir, d.Name));
            }
            else
            {
                SearchBankRecurs(dir, Path.Combine(curDir, d.Name), ref BankList);
            }
        }
    }


    public override List<DlcDisplayCheckDrawer.GroupLabel> DisplayAssetCheck(DlcContext CurrentContext)
    {
        CurrentContext.AddContent(this);
        int valid = IsValid(CurrentContext, out string BundleError);
        if(valid == 1)
        {
            CurrentContext.PopContent();
            return new List<DlcDisplayCheckDrawer.GroupLabel>();
        }
        List<DlcDisplayCheckDrawer.GroupLabel> res = new List<DlcDisplayCheckDrawer.GroupLabel>();
        List<DlcBuilderBase> srcFiles = GetContent(CurrentContext);
        DlcPackage.ForEachContent(CurrentContext, srcFiles.ConvertAll(c => c as DlcBuilderBase), (DlcBuilderBase file) => 
        {
            res.AddRange(file.DisplayAssetCheck(CurrentContext));
        });
        CurrentContext.PopContent();
        return res;
    }

    public override void Build(DlcContext Context, string tmpDir, string outDir)
    {
        Context.AddContent(this);
        DatabaseTextConverter.GenerateGameFiles2(Path.Combine(outDir, "translation"), Context.GetAbsolutePath(Path.Combine(Context.BasePath, Context.CurPath, "Database/{name}/po/")) , Context.GetAbsolutePath(Path.Combine(Context.BasePath, Context.CurPath, "JpLiteralStrings/po/")), false, LanguagesCode);

        base.Build(Context, tmpDir, outDir);
        Context.PopContent();
    }

    public override string UpdateCurPath(DlcContext Context, string path)
    {
        return Path.Combine(path, "translation");
    }

    public override int IsValid(DlcContext Context, out string Error, bool CheckFiles = false)
    {
        Context.AddContent(this);
        string Error_ = "";
        int Res = 0;
        if(CheckFiles)
        {
            List<DlcBuilderBase> srcFiles = GetContent(Context);
            DlcPackage.ForEachContent(Context, srcFiles.ConvertAll(c => c as DlcBuilderBase), (DlcBuilderBase file) => 
            {
                if(file.IsValid(Context, out Error_, CheckFiles) == 2)
                {
                    Res = 2;
                    return false;
                }
                return true;
            });
        }
        Error = Error_;
        Context.PopContent();
        return Res;
    }

    public void SetLanguagesCode(List<string> languageCodes)
    {
        if(LanguagesCode == null || languageCodes.Count != LanguagesCode.Count || !languageCodes.SequenceEqual(LanguagesCode))
        {
            LanguagesCode = languageCodes.ToList();
            Content = null;
        }
    }
#endif
}