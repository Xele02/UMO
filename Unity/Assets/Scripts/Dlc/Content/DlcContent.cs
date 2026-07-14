
using System;
using XeSys;

[Serializable]
abstract public class DlcContent
{
    public bool Enabled;
    public abstract void Save(EDOHBJAPLPF_JsonData json_data);

    public abstract void Load(EDOHBJAPLPF_JsonData json_data);

#if UNITY_EDITOR
    public abstract void FillBuilder(DlcBuilder builder);
#endif

    public virtual void UpdateDatabase(string dlcPath, DlcPackage dlc) {}
    public virtual void UpdateFileList(string dlcPath) {}
    public virtual void UpdateBank(string bankName, MessageBank bank) {}

    public int IsValid(out string Error)
    {
        Error = "";
        return 0;
    }

    public virtual void Build(DlcContext Context, string tmpDir, string outDir)
    {
    }
}
