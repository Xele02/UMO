
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Localization.SmartFormat;

public class DlcFileBuilder : DlcBuilderBase
{
    public bool Required = false;
    public string NamePattern;
    public Type Type;
    public string[] Exts = new string[0];

    public string GetFileName(DlcContext Context)
    {
        return Smart.Format(NamePattern, Context);
    }

#if UNITY_EDITOR
    public override void CreateMissingAssets(DlcContext Context)
    {

    }

    public override List<DlcDisplayCheckDrawer.GroupLabel> DisplayAssetCheck(DlcContext CurrentContext)
    {
        int fileValid = IsValid(CurrentContext, out string Error);
        if(fileValid == 1)
            return new List<DlcDisplayCheckDrawer.GroupLabel>();
        return new List<DlcDisplayCheckDrawer.GroupLabel>()
        {
            new DlcDisplayCheckDrawer.GroupLabel()
            {
                Name = fileValid == 0 ? GetValidFile(CurrentContext) : Error,
                ValidityStatus = fileValid
            }
        };
    }

    public string GetValidFile(DlcContext Context)
    {
        string FormatedFile = GetFileName(Context);
        string FilePath = Path.Combine(Context.BasePath, Context.CurPath, FormatedFile);
        foreach(var TestExt in Exts)
        {
            if(File.Exists(Context.GetAbsolutePath( FilePath ) + TestExt))
            {
                return FormatedFile + TestExt;
            }
        }
        return null;
    }

    public override int IsValid(DlcContext Context, out string Error, bool CheckFiles = false)
    {
        string FormatedFile = GetFileName(Context);
        string FilePath = Path.Combine( Context.CurPath, FormatedFile);
        string FoundFile = GetValidFile(Context);
        bool fileValid = FoundFile != null;
        Error = "";
        if(!fileValid)
        {
            if(Required)
                Error = "File does not exist : "+FilePath+"["+string.Join(",", Exts)+"]";
            else
                return 1;
        }
        return fileValid ? 0 : 2;
    }
#endif
}

public class DlcFilePrefabBuilder : DlcFileBuilder
{
    public DlcFilePrefabBuilder()
    {
        Type = typeof(GameObject);
        Exts = new string[] { ".prefab" };
    }

#if UNITY_EDITOR
    public override void CreateMissingAssets(DlcContext Context)
    {
        if(IsValid(Context, out string Error) == 2)
        {
            string FormatedFile = GetFileName(Context);
            string FilePath = Path.Combine( Context.BasePath, Context.CurPath, FormatedFile + ".prefab");
            GameObject obj = new GameObject(FormatedFile);
            GameObject prefab = PrefabUtility.SaveAsPrefabAsset(obj, FilePath, out bool Success);
            obj.hideFlags = HideFlags.HideAndDontSave;
            UnityEngine.Object.DestroyImmediate(obj);
        }
    }
#endif
}

public class DlcFileAnimationBuilder : DlcFileBuilder
{
    public DlcFileAnimationBuilder()
    {
        Type = typeof(AnimationClip);
        Exts = new string[] { ".anim" };
    }

#if UNITY_EDITOR
    public override void CreateMissingAssets(DlcContext Context)
    {
        if(IsValid(Context, out string Error) == 2)
        {
            string FormatedFile = GetFileName(Context);
            string FilePath = Path.Combine( Context.BasePath, Context.CurPath, FormatedFile + ".anim");
            AnimationClip obj = new AnimationClip();
            AssetDatabase.CreateAsset(obj, FilePath);
            UnityEngine.Object.DestroyImmediate(obj);
        }
    }
#endif
}

public class DlcFileTextureBuilder : DlcFileBuilder
{
    public DlcFileTextureBuilder()
    {
        Type = typeof(AnimationClip);
        Exts = new string[] { ".png", ".jpg" };
    }

    public enum ETextureType
    {
        SingleTexture,
        BaseMask, // _base.png, _mask.png
    }

    public ETextureType TextureType = ETextureType.SingleTexture;
    public Vector2 MinSize;
    public Vector2 MaxSize;

    public DlcFileTextureBuilder[] GetTextureFiles()
    {
        switch(TextureType)
        {
            case ETextureType.BaseMask:
                return new DlcFileTextureBuilder[] {
                    new DlcFileTextureBuilder() { Required=true, NamePattern = NamePattern + "_base", MinSize = MinSize, MaxSize = MaxSize },
                    new DlcFileTextureBuilder() { Required=true, NamePattern = NamePattern + "_mask", MinSize = MinSize, MaxSize = MaxSize },
                };
        }
        return null;
    }

#if UNITY_EDITOR
    public override int IsValid(DlcContext Context, out string Error, bool CheckFiles = false)
    {
        DlcFileTextureBuilder[] multipleFiles = GetTextureFiles();
        if(multipleFiles != null)
        {
            int Res = 0;
            Error = "";
            int NumError = 0;
            foreach(var file in multipleFiles)
            {
                if(file.IsValid(Context, out Error) == 2)
                {
                    Res = 2;
                    NumError++;
                }
            }
            if(Res == 2 && NumError == multipleFiles.Length && !Required)
                Res = 1;
            return Res;
        }
        else
            return base.IsValid(Context, out Error);
    }

    public override void CreateMissingAssets(DlcContext Context)
    {
        if(IsValid(Context, out string Error) == 2)
        {
            string FormatedFile = GetFileName(Context);
            switch(TextureType)
            {
                case ETextureType.BaseMask:
                {
                    Texture2D tex = new Texture2D((int)MinSize.x, (int)MinSize.y);
                    tex.Apply();
                    byte[] data = tex.EncodeToPNG();

                    string FilePath = Path.Combine( Context.BasePath, Context.CurPath, FormatedFile + "_base.png");
                    if(!File.Exists(FilePath))
                        File.WriteAllBytes(FilePath, data);
                    FilePath = Path.Combine( Context.BasePath, Context.CurPath, FormatedFile + "_mask.png");
                    if(!File.Exists(FilePath))
                        File.WriteAllBytes(FilePath, data);
                    UnityEngine.Object.DestroyImmediate(tex);
                    break;
                }
                default:
                {
                    string FilePath = Path.Combine( Context.BasePath, Context.CurPath, FormatedFile + ".png" );
                    Texture2D tex = new Texture2D((int)MinSize.x, (int)MinSize.y);
                    byte[] data = tex.EncodeToPNG();
                    if(!File.Exists(FilePath))
                        File.WriteAllBytes(FilePath, data);

                    UnityEngine.Object.DestroyImmediate(tex);
                    break;
                }
            }
        }
    }
    public override List<DlcDisplayCheckDrawer.GroupLabel> DisplayAssetCheck(DlcContext CurrentContext)
    {
        DlcFileTextureBuilder[] underFiles = GetTextureFiles();
        if(underFiles != null)
        {
            List<DlcDisplayCheckDrawer.GroupLabel> res = new List<DlcDisplayCheckDrawer.GroupLabel>();
            foreach(var f in underFiles)
            {
                res.AddRange(f.DisplayAssetCheck(CurrentContext));
            }
            return res;
        }
        else
        {
            return base.DisplayAssetCheck(CurrentContext);
        }
    }
#endif
}
