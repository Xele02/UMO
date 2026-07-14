
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class DlcFileCopyBuilder : DlcBuilderBase
{

    public DlcFileCopyBuilder()
    {
    }

    List<DlcBuilderBase> Content = new List<DlcBuilderBase>();

#if UNITY_EDITOR
    public override void CreateMissingAssets(DlcContext Context)
    {
        Context.AddContent(this);

        DlcPackage.ForEachContent(Context, Content.ConvertAll(c => c as DlcBuilderBase), (DlcBuilderBase file) => 
        {
            file.CreateMissingAssets(Context);
        });

        Context.PopContent();
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
        List<DlcBuilderBase> srcFiles = Content;
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
        
        string path = Context.GetAbsolutePath(Path.Combine(Context.BasePath, Context.CurPath));
        if(Directory.Exists(path))
        {
            // Todo directory copy
            Action<string, string> copyContent = null;
            copyContent = (string basePath, string _path) => {
                foreach(var dir in Directory.EnumerateDirectories(_path))
                {
                    copyContent(path, dir);
                }
                foreach(var file in Directory.EnumerateFiles(_path))
                {
                    if(Path.GetExtension(file) == ".meta")
                        continue;
                    string subPath = Path.GetDirectoryName(file).Substring(basePath.Length + 1);
                    Directory.CreateDirectory(Path.GetDirectoryName(Path.Combine(outDir, "files", subPath)));
                    File.Copy(file, Path.Combine(outDir, "files", subPath, Path.GetFileName(file)), true);
                }
            };
            copyContent(path, path);
        }

        base.Build(Context, tmpDir, outDir);
        Context.PopContent();
    }

    public override string UpdateCurPath(DlcContext Context, string path)
    {
        return Path.Combine(path, "files");
    }

    public override int IsValid(DlcContext Context, out string Error, bool CheckFiles = false)
    {
        Context.AddContent(this);
        string Error_ = "";
        int Res = 0;
        if(CheckFiles)
        {
            DlcPackage.ForEachContent(Context, Content.ConvertAll(c => c as DlcBuilderBase), (DlcBuilderBase file) => 
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

#endif
}