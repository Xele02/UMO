

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using XeSys;

public class BundleShaderInfo : SingletonMonoBehaviour<BundleShaderInfo>
{
    public Dictionary<int,string> shaderList = new Dictionary<int, string>();
    //bool m_Initialized = false;

    public void Start()
    {
        UnityEngine.Object.DontDestroyOnLoad(this);
        //StartCoroutine(PreloadBundleShader(Application.persistentDataPath+"/data/android/handmade/shader.xab.decrypted"));
    }

	public IEnumerator PreloadBundleShader(string path)
	{
        UnityEngine.Debug.Log("Enter PreloadBundleShader");
        AssetBundleCreateRequest req = AssetBundle.LoadFromFileAsync(path);
		yield return req;
        
		var shaderBundle2 = req.assetBundle;

		string[] data = shaderBundle2.GetAllAssetNames();
		foreach(string s in data)
		{
			AssetBundleRequest req3 = shaderBundle2.LoadAssetWithSubAssetsAsync<Shader>(s);
			yield return req3;
			foreach(Shader o in req3.allAssets)
			{
				if(o == null)
					continue;
				if(!shaderList.ContainsKey(o.GetInstanceID()))
				{
					shaderList.Add(o.GetInstanceID(),s.Replace("assets/bundles/handmade/","").Replace(".shader",""));
					Debug.Log("Loaded game shader "+o.GetInstanceID()+" "+s);
				}
			}
		}
       // m_Initialized = true;
		
		yield break;
	}

    public IEnumerator FixMaterialShader(AssetBundle myLoadedAssetBundle)
    {
        AssetBundleRequest reqasset = myLoadedAssetBundle.LoadAllAssetsAsync<Material>();
		yield return reqasset;
		UnityEngine.Object[] materials = reqasset.allAssets;
		if(materials.Length > 0)
		{
            string[] data = myLoadedAssetBundle.GetAllAssetNames();
            foreach(string s in data)
            {
                AssetBundleRequest req3 = myLoadedAssetBundle.LoadAssetWithSubAssetsAsync<Shader>(s);
                yield return req3;
                foreach(Shader o in req3.allAssets)
                {
                    if(o == null)
                        continue;
                    if(!shaderList.ContainsKey(o.GetInstanceID()))
                    {
                        shaderList.Add(o.GetInstanceID(),System.IO.Path.GetFileNameWithoutExtension(s));
                        Debug.Log("Loaded game shader "+o.GetInstanceID()+" "+s);
                    }
                }
            }

			foreach(Material mat in materials)
			{
				if(shaderList.ContainsKey(mat.shader.GetInstanceID()))
				{
					string[] shadersList = AssetDatabase.FindAssets(shaderList[mat.shader.GetInstanceID()]+" t:Shader");
					bool bFound = false;
					foreach(string s in shadersList)
					{
						if(System.IO.Path.GetFileNameWithoutExtension(AssetDatabase.GUIDToAssetPath(s)).ToLower() == System.IO.Path.GetFileNameWithoutExtension(shaderList[mat.shader.GetInstanceID()].ToLower()))
						{
							Shader shader = AssetDatabase.LoadAssetAtPath<Shader>(AssetDatabase.GUIDToAssetPath(s));
							var so = new SerializedObject(mat);
							int renderQueue = so.FindProperty("m_CustomRenderQueue").intValue;
							mat.shader = shader;
							if(renderQueue != -1)
								mat.renderQueue = renderQueue;
							Debug.Log("Loaded shader "+shader.name+" / path = "+AssetDatabase.GUIDToAssetPath(s)+" on "+mat.name);
							bFound = true;
							break;
						}
					}
					if(!bFound)
					{
						Debug.LogError("shader not found : "+shaderList[mat.shader.GetInstanceID()]+" : "+System.IO.Path.GetFileNameWithoutExtension(shaderList[mat.shader.GetInstanceID()])+" for "+mat.name);
					}
				}
				else
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
				}
			}
		}
    }
	
}