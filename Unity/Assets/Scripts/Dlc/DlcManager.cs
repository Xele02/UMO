
using UnityEngine;
using XeSys;
using System.IO;
using System.Collections.Generic;

public class DlcManager : SingletonMonoBehaviour<DlcManager>
{
    private List<DlcPackage> Dlcs = new List<DlcPackage>();
    static public string DlcPath { get => UnityEngine.Application.persistentDataPath + "/data/dlc/"; }
    public int GetNumDLCs()
    {
        return Dlcs.Count;
    }

    public DlcPackage Get(int index)
    {
        if(index >= 0 && index < Dlcs.Count)
            return Dlcs[index];
        return null;
    }
    public DlcPackage Get(string packageName)
    {
        return Dlcs.Find(c => c.PackageName == packageName);
    }
	public void Start()
    {
        UnityEngine.Object.DontDestroyOnLoad(this);
	}

    public string GetPath(string packageName)
    {
        string p = Path.Combine(DlcPath, "_" + packageName);
        if(Directory.Exists(p))
            return p;
        return Path.Combine( DlcPath, packageName);
    }

    public bool Exists(string packageName)
    {
        return File.Exists(Path.Combine( GetPath(packageName), "dlc.xab")) || File.Exists(Path.Combine( GetPath(packageName), "dlc.json"));
    }

    public void SetEnabled(DlcPackage dlc, bool enabled)
    {
        string NewPath = Path.Combine(DlcPath, enabled ? dlc.PackageName : "_" + dlc.PackageName);
        if(NewPath != GetPath(dlc.PackageName))
            Directory.Move(GetPath(dlc.PackageName), NewPath);
    }

    public bool IsEnabled(string packageName)
    {
        return IsEnabled(Get(packageName));
    }

    public bool IsEnabled(DlcPackage dlc)
    {
        return dlc != null && dlc.IsUMOVersionCompatible() && Directory.Exists(Path.Combine(DlcPath, dlc.PackageName));
    }

    public void Uninstall(DlcPackage dlc)
    {
        if(Directory.Exists(GetPath(dlc.PackageName)))
            Directory.Delete(GetPath(dlc.PackageName), true);
        Dlcs.RemoveAll((DlcPackage _dlc) => _dlc.PackageName == dlc.PackageName);
    }

    public DlcPackage GetDlcFile(string path)
    {
        DlcPackage dlc = null;
        if(File.Exists(Path.Combine(path, "dlc.json")))
        {
            dlc = new DlcPackage();
        }
        if(dlc == null && File.Exists(Path.Combine(path, "dlc.xab")))
        {
            AssetBundle bundle = AssetBundle.LoadFromFile(Path.Combine(path,"dlc.xab"));
            //UnityEngine.Debug.LogError(bundle);
            Object infoObj = bundle.LoadAsset("info.asset");
            //UnityEngine.Debug.LogError(infoObj);
            //UnityEngine.Debug.LogError(string.Join(" ",bundle.GetAllAssetNames()));
            dlc = infoObj as DlcPackage;
            //UnityEngine.Debug.LogError(info);
            bundle.Unload(false);
        }
        if(dlc != null)
        {
            dlc.LoadInit(path);
        }
        return dlc;
    }

    public void Load(string packageName)
    {
        string path = GetPath(packageName);
        Dlcs.RemoveAll((DlcPackage _dlc) => _dlc.PackageName == packageName);
        DlcPackage dlc = GetDlcFile(path);
        if(dlc != null)
        {
            Dlcs.Add(dlc);
            dlc.UpdateFileList(Path.Combine("dlc",dlc.PackageName));
        }
    }

    public void LoadDlcFiles()
    {
        Dlcs.Clear();
        FileSystemProxy.ClearDlcFiles();
        if(Directory.Exists(DlcPath))
        {
            //UnityEngine.Debug.LogError(DlcPath);
            foreach(var dir in Directory.EnumerateDirectories(DlcPath))
            {
                //UnityEngine.Debug.LogError(dir);
                string pkgName = Path.GetFileName(dir);
                if(pkgName.StartsWith("_"))
                    pkgName = pkgName.Substring(1);
                Load(pkgName);
            }
        }
    }

    public void UpdateDatabase()
    {
        foreach(var dlc in Dlcs)
        {
            if(IsEnabled(dlc))
                dlc.UpdateDatabase(GetPath(dlc.PackageName));
        }
    }

    public void UpdateBank(string bankName, MessageBank bank)
    {
        foreach(var dlc in Dlcs)
        {
            if(IsEnabled(dlc))
                dlc.UpdateBank(bankName, bank);
        }
    }

    public List<UMOPopupLanguage.LanguageInfo> GetDLCLanguageInfos()
    {
        List<UMOPopupLanguage.LanguageInfo> LanguageInfos = new List<UMOPopupLanguage.LanguageInfo>();
        foreach(var dlc in Dlcs)
        {
            dlc.FillLanguageInfos(LanguageInfos);
        }
        return LanguageInfos;
    }

}
