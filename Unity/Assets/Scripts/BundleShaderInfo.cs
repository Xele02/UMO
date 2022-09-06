

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using XeSys;

public class BundleShaderInfo : SingletonMonoBehaviour<BundleShaderInfo>
{
	class ShaderInfo
	{
		public string name;
		public Shader shader;
	}
    private  Dictionary<int,ShaderInfo> shaderList = new Dictionary<int, ShaderInfo>();
	private HashSet<string> alreadyParsedBundle = new HashSet<string>();
	private bool isInitialized = false;

    public void Start()
    {
        UnityEngine.Object.DontDestroyOnLoad(this);
		isInitialized = true;

	}

	public bool IsInitialized { get { return isInitialized; } }

	public void RegisterShaderIds(AssetBundle shaderBundle2, Action onCompleted)
	{
		StartCoroutine(Co_RegisterShaderIds(shaderBundle2, onCompleted));
	}

	public IEnumerator Co_RegisterShaderIds(AssetBundle shaderBundle2, Action onCompleted)
	{
		if(shaderBundle2 == null)
		{
			UnityEngine.Debug.LogError("Error Register shader, bundle is null");
			yield break;
		}
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
		UnityEngine.Debug.Log("Checking shader for mat "+mat.name+" with shader "+mat.shader.GetInstanceID()+" "+mat.shader.name);
		if(!string.IsNullOrEmpty(AssetDatabase.GetAssetPath(mat.shader)) && !AssetDatabase.GetAssetPath(mat.shader).Contains("unity default resources"))
		{
			UnityEngine.Debug.Log("Already on disk shader used : "+AssetDatabase.GetAssetPath(mat.shader));
			return;
		}
		//if(mat.shader.isSupported)
		//	return;
		if(!shaderList.ContainsKey(mat.shader.GetInstanceID()))
		{
			ShaderInfo info = null;
			if(info == null)
			{
				Shader shader = Shader.Find(mat.shader.name);
				if(shader != null)
				{
					UnityEngine.Debug.Log(mat.shader.name);
					info = new ShaderInfo();
					info.shader = shader;
					info.name = System.IO.Path.GetFileNameWithoutExtension(AssetDatabase.GetAssetPath(shader));
				}
			}
			if(info != null)
			{
				shaderList.Add(mat.shader.GetInstanceID(), info);
				Debug.Log("Loaded game shader "+mat.shader.GetInstanceID()+" "+info.name);
			}
		}
		int shaderId = mat.shader.GetInstanceID();
		if(shaderList.ContainsKey(shaderId))
		{
			Shader shader = shaderList[shaderId].shader;
			if(shader != null)
			{
				var so = new SerializedObject(mat);
				int renderQueue = so.FindProperty("m_CustomRenderQueue").intValue;
				mat.shader = shader;
				if(renderQueue != -1)
					mat.renderQueue = renderQueue;
				Debug.Log("Loaded shader "+shaderId+" "+shader.name+" on "+mat.name);
			}
			else
			{
				Debug.LogError("shader not found : "+shaderList[shaderId].name+" "+shaderId+" for "+mat.name);
			}
		}
		else
		{
			Debug.LogError("shader not found : "+mat.shader.name+" "+shaderId+" for "+mat.name);
		}
	}

	public void FixMaterialShaderGO(GameObject obj)
	{
		UnityEngine.Debug.Log("Checking shader for object "+obj.name);
		// Search in Graphic element
		Graphic[] graphics = obj.GetComponentsInChildren<Graphic>(true);
		for(int i = 0; i < graphics.Length; i++)
		{
			FixMaterialShader(graphics[i].material);
		}
		Renderer[] renderers = obj.GetComponentsInChildren<Renderer>(true);
		for (int i = 0; i < renderers.Length; i++)
		{
			if(renderers[i].sharedMaterials != null)
			{
				for(int j = 0; j < renderers[i].sharedMaterials.Length; j++)
					FixMaterialShader(renderers[i].sharedMaterials[j]);
			}
		}
		TMP_Text[] text = obj.GetComponentsInChildren<TMP_Text>(true);
		for(int i = 0; i < text.Length; i++)
		{
			if (text[i].fontSharedMaterials != null)
			{
				for (int j = 0; j < text[i].fontSharedMaterials.Length; j++)
					FixMaterialShader(text[i].fontSharedMaterials[j]);
			}
		}
		Projector[] projs = obj.GetComponentsInChildren<Projector>(true);
		for(int i = 0; i < projs.Length; i++)
		{
			if (projs[i].material != null)
			{
				FixMaterialShader(projs[i].material);
			}
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
