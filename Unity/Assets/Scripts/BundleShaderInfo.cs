

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using XeSys;

public class BundleShaderInfo : SingletonMonoBehaviour<BundleShaderInfo>
{
	struct ShaderInfo
	{
		public string name;
		public Shader shader;
	}
    private  Dictionary<int,ShaderInfo> shaderList = new Dictionary<int, ShaderInfo>();
	private HashSet<string> alreadyParsedBundle = new HashSet<string>();

    public void Start()
    {
        UnityEngine.Object.DontDestroyOnLoad(this);
    }

	public void RegisterShaderIds(AssetBundle shaderBundle2, Action onCompleted)
	{
		StartCoroutine(Co_RegisterShaderIds(shaderBundle2, onCompleted));
	}

	public IEnumerator Co_RegisterShaderIds(AssetBundle shaderBundle2, Action onCompleted)
	{
        UnityEngine.Debug.Log("Enter Co_RegisterShaderIds "+shaderBundle2.name);
		if(alreadyParsedBundle.Contains(shaderBundle2.name))
		{
			if(onCompleted != null)
				onCompleted();
			yield break;
		}
        
		string[] data = shaderBundle2.GetAllAssetNames();
		foreach(string assetName in data)
		{
			AssetBundleRequest req3 = shaderBundle2.LoadAssetWithSubAssetsAsync<Shader>(assetName);
			yield return req3;
			foreach(Shader o in req3.allAssets)
			{
				if(o == null)
					continue;
				if(!shaderList.ContainsKey(o.GetInstanceID()))
				{
					ShaderInfo info = new ShaderInfo();
					info.name = System.IO.Path.GetFileNameWithoutExtension(assetName);

					string[] shadersList = AssetDatabase.FindAssets(info.name+" t:Shader");
					foreach(string s in shadersList)
					{
						if(System.IO.Path.GetFileNameWithoutExtension(AssetDatabase.GUIDToAssetPath(s)).ToLower() == info.name.ToLower())
						{
							info.shader = AssetDatabase.LoadAssetAtPath<Shader>(AssetDatabase.GUIDToAssetPath(s));
							break;
						}
					}
					if(info.shader == null)
					{
						Debug.LogError("shader not found : "+assetName+" : "+info.name);
					}
					
					shaderList.Add(o.GetInstanceID(), info);
					Debug.Log("Loaded game shader "+o.GetInstanceID()+" "+info.name);
				}
			}
		}
		alreadyParsedBundle.Add(shaderBundle2.name);
		if(onCompleted != null)
			onCompleted();
		yield break;
	}

	public void FixMaterialShader(UnityEngine.Object obj)
	{
		if(obj is GameObject)
			FixMaterialShaderGO(obj as GameObject);
		if(obj is Material)
			FixMaterialShaderMat(obj as Material);
	}

	public void FixMaterialShaderMat(Material mat)
	{
		if(mat.shader.isSupported)
			return;
		if(shaderList.ContainsKey(mat.shader.GetInstanceID()))
		{
			Shader shader = shaderList[mat.shader.GetInstanceID()].shader;
			if(shader != null)
			{
				var so = new SerializedObject(mat);
				int renderQueue = so.FindProperty("m_CustomRenderQueue").intValue;
				mat.shader = shader;
				if(renderQueue != -1)
					mat.renderQueue = renderQueue;
				Debug.Log("Loaded shader "+shader.name+" on "+mat.name);
			}
			else
			{
				Debug.LogError("shader not found : "+shaderList[mat.shader.GetInstanceID()].name+" for "+mat.name);
			}
		}
		/*else
		{
			Shader shader_ = Shader.Find(mat.shader.name);
			if(shader_)
			{
				var so = new SerializedObject(mat);
				int renderQueue = so.FindProperty("m_CustomRenderQueue").intValue;
				mat.shader = shader_;
				if(renderQueue != -1)
					mat.renderQueue = renderQueue;
				Debug.Log("Loaded Shader "+shader_.name+" on "+mat.name);
			}
			else
				Debug.LogError("Shader not found for "+mat.name+" "+mat.shader.GetInstanceID()+" "+mat.shader.name);
		}*/
	}

	public void FixMaterialShaderGO(GameObject obj)
	{
		// Search in Graphic element
		Graphic[] graphics = obj.GetComponentsInChildren<Graphic>(true);
		for(int i = 0; i < graphics.Length; i++)
		{
			FixMaterialShader(graphics[i].material);
		}
	}

    public IEnumerator FixMaterialShader_Co(AssetBundle myLoadedAssetBundle)
    {
        AssetBundleRequest reqasset = myLoadedAssetBundle.LoadAllAssetsAsync<Material>();
		yield return reqasset;
		UnityEngine.Object[] materials = reqasset.allAssets;
		if(materials.Length > 0)
		{
			foreach(Material mat in materials)
			{
				FixMaterialShaderMat(mat);
			}
		}
    }
	
}