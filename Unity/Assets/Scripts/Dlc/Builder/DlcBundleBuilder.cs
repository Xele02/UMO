
using System.Collections.Generic;
using System.IO;
using System.Linq;

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Localization.SmartFormat;

public class DlcBundleBuilder : DlcBuilderBase
{
    public bool Required = false;
    public string Path;
    public string NamePattern;

    public DlcFileBuilder[] Files;

    public string GetBundleName(DlcContext Context)
    {
        return Smart.Format(NamePattern, Context);
    }

    public string GetSourceDir(DlcContext Context)
    {
        return System.IO.Path.Combine( Context.BasePath, Context.CurPath);
    }

    public override void UpdateFileList(string dlcPath, DlcContext CurrentContext)
    {
        /*string destPath = System.IO.Path.Combine( Application.persistentDataPath, "data", dlcPath, Path ,GetBundleName(CurrentContext));
        if(File.Exists( destPath ))
            FileSystemProxy.AddDlcFile(System.IO.Path.Combine( "/android/", Path, GetBundleName(CurrentContext)), "/"+System.IO.Path.Combine( dlcPath, Path ,GetBundleName(CurrentContext)));*/
        base.UpdateFileList(dlcPath, CurrentContext);
    }

#if UNITY_EDITOR
    public override int IsValid(DlcContext Context, out string Error, bool CheckFiles = false)
    {
        string DirPath = GetSourceDir(Context);
        bool valid = Directory.Exists(Context.GetAbsolutePath(DirPath));
        Error = "";
        if(!valid)
        {
            if(Required)
                Error = "Path does not exist : "+DirPath;
            else
                return 1;
        }
        else if(CheckFiles && Files != null)
        {
            string Error_ = "";
            DlcPackage.ForEachContent(Context, Files.ToList().ConvertAll((v) => v as DlcBuilderBase), (DlcBuilderBase content) => {
                int fileValid = content.IsValid(Context, out Error_);
                if(fileValid == 2)
                {
                    valid = false;
                    return;
                }
            });
            Error = Error_;
        }
        return valid ? 0 : 2;
    }

    public override string UpdateCurPath(DlcContext Context, string path)
    {
        return System.IO.Path.Combine( path, Path, GetBundleName(Context).Replace(".xab", "_xab") );
    }

    public override void CreateMissingAssets(DlcContext Context)
    {
        string AbsSourcePath = Context.GetAbsolutePath(GetSourceDir(Context));
        if(!Directory.Exists(AbsSourcePath))
        {
            if(Required)
                Directory.CreateDirectory(AbsSourcePath);
            else
                return;
        }

        DlcPackage.ForEachContent(Context, Files.ToList().ConvertAll((v) => v as DlcBuilderBase), (DlcBuilderBase file) => {
            file.CreateMissingAssets(Context);
        });
    }

    public AssetBundleBuild GetBundleBuildInfo(DlcContext StringFormater)
    {
        AssetBundleBuild Data = new AssetBundleBuild();
        Data.assetBundleName = System.IO.Path.Combine(Path, GetBundleName(StringFormater));
        string[] assetsName = AssetDatabase.FindAssets("*", new string[]{GetSourceDir(StringFormater)});
        Data.assetNames = assetsName.Select((string T) => AssetDatabase.GUIDToAssetPath(T)).ToArray();
        Data.addressableNames = Data.assetNames.Select(s => System.IO.Path.GetFileNameWithoutExtension(s)).ToArray();
        return Data;
    }

    private static GUIStyle Red_;
    public static GUIStyle Red { get {
        if(Red_ == null)
        {
            Red_ = new GUIStyle(EditorStyles.foldout);
            Red_.normal.textColor = Color.red;
            Red_.active.textColor = Color.red;
        }
        return Red_;
    } }
    public override List<DlcDisplayCheckDrawer.GroupLabel> DisplayAssetCheck(DlcContext CurrentContext)
    {
        int valid = IsValid(CurrentContext, out string BundleError);
        if(valid == 1)
            return new List<DlcDisplayCheckDrawer.GroupLabel>();
        List<DlcDisplayCheckDrawer.GroupLabel> res = new List<DlcDisplayCheckDrawer.GroupLabel>()
        {
            new DlcDisplayCheckDrawer.GroupLabel()
            {
                Name = Path + GetBundleName(CurrentContext),
                ValidityStatus = valid,
            }
        };
        DlcPackage.ForEachContent(CurrentContext, Files.ToList().ConvertAll((v) => v as DlcBuilderBase), (DlcBuilderBase file) => {
            res[0].children.AddRange(file.DisplayAssetCheck(CurrentContext));
        });
        return res;
    }
#endif
}

public class DlcBundleGroupBuilder : DlcBuilderBase
{
    public List<DlcBundleBuilder> Bundles = new List<DlcBundleBuilder>();

    public override void UpdateFileList(string dlcPath, DlcContext Context)
    {
        EDOHBJAPLPF_JsonData json_data = null;
        string absoluteDlcPath = Path.Combine(Application.persistentDataPath, "data", dlcPath);
        string BundlePath = Path.Combine(absoluteDlcPath, "bundles");
        if(!Directory.Exists(BundlePath))
            return;
        string fileJson = Path.Combine(absoluteDlcPath, "files.json");
        if(!File.Exists(fileJson))
        {
            json_data = new EDOHBJAPLPF_JsonData();
            json_data["files"] = new EDOHBJAPLPF_JsonData();
            json_data["files"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
            // list all xab
            foreach(var file in Directory.EnumerateFiles(BundlePath, "*.xab", SearchOption.AllDirectories))
            {
                json_data["files"].Add(file.Substring(BundlePath.Length + 1));
            }
            File.WriteAllText(fileJson, json_data.EJCOJCGIBNG_ToJson());
        }
        else
        {
            string data = File.ReadAllText(fileJson);
            json_data = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(data);
        }
        if(json_data.BBAJPINMOEP_Contains("files") && json_data["files"].EPNGJLOKGIF_IsArray)
        {
            for(int i = 0; i < json_data["files"].HNBFOAJIIAL_Count; i++)
            {
                string bundlePath = (string)json_data["files"][i];
                string destPath = Path.Combine( Application.persistentDataPath, "data", dlcPath, "bundles", bundlePath);
                if(File.Exists( destPath ))
                    FileSystemProxy.AddDlcFile(Path.Combine( "/android/", bundlePath), "/"+Path.Combine( dlcPath, "bundles", bundlePath));
            }
        }
    }
#if UNITY_EDITOR
    public override int IsValid(DlcContext CurrentContext, out string Error, bool CheckFiles = false)
    {
        CurrentContext.AddContent(this);
        string Error_ = "";
        int Res = 0;
        DlcPackage.ForEachContent(CurrentContext, Bundles.ConvertAll((v) => v as DlcBuilderBase), (DlcBuilderBase file) =>
        {
            if(file.IsValid(CurrentContext, out Error_, CheckFiles) == 2)
            {
                Res = 2;
                return false;
            }
            return true;
        });
        Error = Error_;
        CurrentContext.PopContent();
        return Res;
    }

    public override string UpdateCurPath(DlcContext Context, string path)
    {
        return Path.Combine( path, "bundles");
    }

    public override void CreateMissingAssets(DlcContext CurrentContext)
    {
        CurrentContext.AddContent(this);
        DlcPackage.ForEachContent(CurrentContext, Bundles.ConvertAll((v) => v as DlcBuilderBase), (DlcBuilderBase file) =>
        {
            file.CreateMissingAssets(CurrentContext);
        });
        CurrentContext.PopContent();
    }
    public override List<DlcDisplayCheckDrawer.GroupLabel> DisplayAssetCheck(DlcContext CurrentContext)
    {
        CurrentContext.AddContent(this);
        List<DlcDisplayCheckDrawer.GroupLabel> res = new List<DlcDisplayCheckDrawer.GroupLabel>();
        DlcPackage.ForEachContent(CurrentContext, Bundles.ConvertAll((v) => v as DlcBuilderBase), (DlcBuilderBase file) =>
        {
            res.AddRange(file.DisplayAssetCheck(CurrentContext));
        });
        CurrentContext.PopContent();
        return res;
    }
    public override void Build(DlcContext Context, string tmpDir, string outDir)
    {
        Context.AddContent(this);
        List<AssetBundleBuild> BundlesToBuild = new List<AssetBundleBuild>();

        string absolutePath = Context.GetAbsolutePath(Path.Combine(Context.BasePath, Context.CurPath));
        if(!Directory.Exists(absolutePath))
        {
            Context.PopContent();
            return;
        }
        List<DlcBundleBuilder> pathToBuild = new List<DlcBundleBuilder>();
        foreach(var file in Directory.EnumerateDirectories(absolutePath, "*_xab", SearchOption.AllDirectories))
        {
            string p = file.Substring(absolutePath.Length + 1);
            DlcBundleBuilder inf = new DlcBundleBuilder() { Required = true, Path = Path.GetDirectoryName(p), NamePattern = Path.GetFileName(p).Replace("_xab", ".xab") };
            pathToBuild.Add(inf);
        }

        DlcPackage.ForEachContent(Context, /*Bundles*/pathToBuild.ConvertAll((v) => v as DlcBuilderBase), (DlcBuilderBase file) =>
        {
            DlcBundleBuilder bundle = file as DlcBundleBuilder;
            int bundleValid = bundle.IsValid(Context, out string Error, true);
            if(bundleValid == 0)
            {
                BundlesToBuild.Add(bundle.GetBundleBuildInfo(Context));
            }
            else if(bundleValid == 2)
            {
                Debug.LogError("Error building "+bundle.GetBundleName(Context)+" : "+Error);
            }
        });

        string tmpBuildDir = Path.Combine(tmpDir, "bundles");
        BuildTarget buildTarget = BuildTarget.Android;
        if(!BuildPipeline.IsBuildTargetSupported(BuildTargetGroup.Android, BuildTarget.Android))
            buildTarget = EditorUserBuildSettings.activeBuildTarget;
        AssetBundleBuilder.BuildBundles(tmpBuildDir, BundlesToBuild, buildTarget);

        DlcPackage.ForEachContent(Context, /*Bundles*/pathToBuild.ConvertAll((v) => v as DlcBuilderBase), (DlcBuilderBase file) =>
        {
            DlcBundleBuilder bundle = file as DlcBundleBuilder;
            string bundleName = Path.Combine(bundle.Path, bundle.GetBundleName(Context));
            if(File.Exists(Path.Combine( tmpBuildDir, bundleName)))
            {
                string dlcDir = Path.GetDirectoryName(bundleName);
                Directory.CreateDirectory(Path.Combine( outDir, "bundles", dlcDir));
                File.Move(Path.Combine(tmpBuildDir, bundleName), Path.Combine(outDir, "bundles", bundleName));
            }
        });
        Context.PopContent();
    }
#endif
}
