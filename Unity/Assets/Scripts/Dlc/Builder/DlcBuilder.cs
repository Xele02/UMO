

using System;
using System.Collections.Generic;
using XeSys;


public class DlcBuilder
{
    public DlcBundleGroupBuilder Bundles = new DlcBundleGroupBuilder();
    public DlcTranslationBuilder Bank = new DlcTranslationBuilder();
    public DlcFileCopyBuilder FileCopy = new DlcFileCopyBuilder();

    public void UpdateDatabase(DlcContext Context)
    {
        Bundles.UpdateDatabase(Context);
        Bank.UpdateDatabase(Context);
        FileCopy.UpdateDatabase(Context);
    }

    public void UpdateBank(DlcContext Context, string bankName, MessageBank bank)
    {
        Bundles.UpdateBank(Context, bankName, bank);
        Bank.UpdateBank(Context, bankName, bank);
        FileCopy.UpdateBank(Context, bankName, bank);
    }

    internal void UpdateFileList(string dlcPath, DlcContext Context)
    {
        Bundles.UpdateFileList(dlcPath, Context);
        Bank.UpdateFileList(dlcPath, Context);
        FileCopy.UpdateFileList(dlcPath, Context);
    }

#if UNITY_EDITOR
    public int IsValid(DlcContext Context, out string Error, bool CheckFiles = false)
    {
        int Res = Bundles.IsValid(Context, out Error, CheckFiles);
        if(Res == 2) return 2;
        Res = Bank.IsValid(Context, out Error, CheckFiles);
        if(Res == 2) return 2;
        Res = FileCopy.IsValid(Context, out Error, CheckFiles);
        if(Res == 2) return 2;
        return 0;
    }
    
    public void Build(DlcContext Context, string tmpDir, string outDir)
    {
        Bundles.Build(Context, tmpDir, outDir);
        Bank.Build(Context, tmpDir, outDir);
        FileCopy.Build(Context, tmpDir, outDir);
    }

    public void CreateMissingAssets(DlcContext Context)
    {
        Bundles.CreateMissingAssets(Context);
        Bank.CreateMissingAssets(Context);
        FileCopy.CreateMissingAssets(Context);
    }
    public List<DlcDisplayCheckDrawer.GroupLabel> DisplayAssetCheck(DlcContext CurrentContext)
    {
        return new List<DlcDisplayCheckDrawer.GroupLabel>() {
            new DlcDisplayCheckDrawer.GroupLabel()
            {
                Name = "Bundles",
                children = Bundles.DisplayAssetCheck(CurrentContext)
            },
            new DlcDisplayCheckDrawer.GroupLabel()
            {
                Name = "Translation",
                children = Bank.DisplayAssetCheck(CurrentContext)
            },
            new DlcDisplayCheckDrawer.GroupLabel()
            {
                Name = "Files",
                children = FileCopy.DisplayAssetCheck(CurrentContext)
            }
        };
    }
#endif
}


public abstract class DlcBuilderBase
{
    public virtual void UpdateFileList(string dlcPath, DlcContext Context) {}
    public virtual void UpdateDatabase(DlcContext Context) {}
    public virtual void UpdateBank(DlcContext Context, string bankName, MessageBank bank) {}

#if UNITY_EDITOR
    public virtual string UpdateCurPath(DlcContext Context, string path) { return path; }
    public abstract int IsValid(DlcContext Context, out string Error, bool CheckFiles = false);
    public virtual void Build(DlcContext Context, string tmpDir, string outDir) {}
    public abstract void CreateMissingAssets(DlcContext Context);
    public abstract List<DlcDisplayCheckDrawer.GroupLabel> DisplayAssetCheck(DlcContext CurrentContext);
#endif
}

public class DlcGroupBuilder : DlcBuilderBase
{
    public List<DlcBuilderBase> Files;

    public override void UpdateFileList(string dlcPath, DlcContext Context)
    {
        foreach(var file in Files)
        {
            file.UpdateFileList(dlcPath, Context);
        }
        base.UpdateFileList(dlcPath, Context);
    }

#if UNITY_EDITOR
    public override int IsValid(DlcContext CurrentContext, out string Error, bool CheckFiles = false)
    {
        Error = "";
        foreach(var file in Files)
        {
            if(file.IsValid(CurrentContext, out Error, CheckFiles) == 2)
                return 2;
        }
        return 0;
    }
    public override void Build(DlcContext CurrentContext, string tmpDir, string outDir)
    {
        foreach(var file in Files)
        {
            file.Build(CurrentContext, tmpDir, outDir);
        }
    }

    public override void CreateMissingAssets(DlcContext CurrentContext)
    {
        foreach(var file in Files)
        {
            file.CreateMissingAssets(CurrentContext);
        }
    }
    public override List<DlcDisplayCheckDrawer.GroupLabel> DisplayAssetCheck(DlcContext CurrentContext)
    {
        List<DlcDisplayCheckDrawer.GroupLabel> res = new List<DlcDisplayCheckDrawer.GroupLabel>();
        foreach(var file in Files)
        {
            res.AddRange(file.DisplayAssetCheck(CurrentContext));
        }
        return res;
    }
#endif
}