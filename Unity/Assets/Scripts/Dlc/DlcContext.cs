using System.IO;
using UnityEngine;
using System.Collections.Generic;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class DlcContext
{
    public string BasePath = "";
    public DlcPackage DLC;
    public List<DlcBuilderBase> Stack = new List<DlcBuilderBase>();
    public string CurPath = "";

    public string GetAbsolutePath(string path)
    {
        return path.Replace("Assets", Application.dataPath);
    }

    public virtual void SetCurrentDlc(DlcPackage _Dlc)
    {
        DLC = _Dlc;
#if UNITY_EDITOR
        string p = AssetDatabase.GetAssetPath(DLC);
        if(p != null && p != "")
            BasePath = Path.GetDirectoryName(p);
#endif
    }

#if UNITY_EDITOR
    public void AddContent(DlcBuilderBase Content)
    {
        Stack.Add(Content);
        UpdatePath();
    }

    public void PopContent()
    {
        Stack.RemoveAt(Stack.Count - 1);
        UpdatePath();
    }

    private void UpdatePath()
    {
        string newCurPath = "";
        foreach(var content in Stack)
        {
            newCurPath = content.UpdateCurPath(this, newCurPath);
        }
        CurPath = newCurPath;
    }
#endif
}
