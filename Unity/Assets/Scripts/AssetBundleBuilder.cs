#if UNITY_EDITOR
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Build.Pipeline;
using UnityEngine;
using UnityEngine.Build.Pipeline;

public class AssetBundleBuilder
{
    static public void BuildBundle(string DataPath, string OutputPath)
    {
        if(!Directory.Exists(DataPath))
            return;
        if(!Directory.Exists(OutputPath))
            Directory.CreateDirectory(OutputPath);
        string[] assetsName = AssetDatabase.FindAssets("*", new string[]{DataPath});
        //Object[] assets = assetsName.ForEach();
        //BuildPipeline.BuildAssetBundle(null, assets, OutputPath, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
        AssetBundleBuild bundle = new AssetBundleBuild();
        bundle.assetBundleName = new DirectoryInfo(DataPath).Name.Replace("_xab",".xab");
        bundle.assetNames = assetsName.Select((string T) => AssetDatabase.GUIDToAssetPath(T)).ToArray();
        CompatibilityBuildPipeline.BuildAssetBundles(OutputPath, new AssetBundleBuild[] {bundle}, BuildAssetBundleOptions.None, BuildTarget.StandaloneLinux);
    }

    static public void BuildBundles(string OutputPath, List<AssetBundleBuild> Bundles, BuildTarget target)
    {
        if(!Directory.Exists(OutputPath))
            Directory.CreateDirectory(OutputPath);
        CompatibilityAssetBundleManifest res = CompatibilityBuildPipeline.BuildAssetBundles(OutputPath, Bundles.ToArray(), BuildAssetBundleOptions.None, target);
        //UnityEngine.Debug.LogError(res.ToString());
    }


	[MenuItem("Assets/UMO/Build bundle", true)]
	private static bool CheckScriptable()
	{
        var path = "";
        var obj = Selection.activeObject;

        if (obj != null)
            path = AssetDatabase.GetAssetPath(obj.GetInstanceID());

		return path != "" && path.Contains("_xab");
	}

	[MenuItem("Assets/UMO/Build bundle")]
	private static void BuildSelected()
	{
        
        var path = "";
        var obj = Selection.activeObject;

        if (obj != null)
        {
            path = AssetDatabase.GetAssetPath(obj.GetInstanceID());
            path = path.Substring(0, path.IndexOf("_xab") + 4);
            BuildBundle(path, Application.dataPath + "/../Build/TmpBundles/");
        }

		//(Selection.activeObject as ShaderList).ReloadAssetList();
	}
}

#endif