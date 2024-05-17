#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using XeSys.Gfx;

public class TexturePacker : EditorWindow
{
	[MenuItem("UMO/Localization/TexturePacker", priority=2)]
	static void ShowOption()
	{
		Create();
	}

	public static TexturePacker Create()
	{
		var window = GetWindow<TexturePacker>(typeof(TexturePacker));
		return window;
	}

    Texture2D baseTex;
    Texture2D maskTex;
    byte[] uvList;
	Vector2 scrollPos = Vector2.zero;
    string[] AssetsList = new string[1] { "---" };
    int selectedIdx = 0;
    string generatedName = "";
    int language = 0;
    string[] languageList = new string[1] { "fr" };

	private void OnGUI()
	{
        string path = Application.dataPath+"/../../Localization/Assets/";
		EditorGUILayout.BeginVertical(EditorStyles.helpBox);
		scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
        if(GUILayout.Button("Update directories"))
        {
            // Update dir list
            List<string> dirs = Directory.GetDirectories(path).ToList();
            for(int i = 0; i < AssetsList.Length; i++)
            {
                dirs[i] = new DirectoryInfo(dirs[i]).Name;
            }
            dirs.Insert(0, "---");
            string oldDir = AssetsList[selectedIdx];
            AssetsList = dirs.ToArray();
            selectedIdx = Array.FindIndex(AssetsList, (string _) => { return _ == oldDir; });
            if(selectedIdx == -1)
                selectedIdx = 0;
        }
		//assetEditor.OnInspectorGUI();
        selectedIdx = EditorGUILayout.Popup("Texture", selectedIdx, AssetsList);
        if(AssetsList[selectedIdx] != "---")
        {
            if(generatedName != AssetsList[selectedIdx])
            {
                generatedName = AssetsList[selectedIdx];
                maskTex = null;
                baseTex = null;
                uvList = null;
                
                if(File.Exists(path + generatedName + "/jp/" + generatedName + "_base.png"))
                {
                    baseTex = new Texture2D(1, 1);
                    baseTex.LoadImage(File.ReadAllBytes(path + generatedName + "/jp/" + generatedName + "_base.png"), false);   
                }
                if(File.Exists(path + generatedName + "/jp/" + generatedName + "_mask.png"))
                {
                    maskTex = new Texture2D(1, 1);
                    maskTex.LoadImage(File.ReadAllBytes(path + generatedName + "/jp/" + generatedName + "_mask.png"), false);
                }
                if(File.Exists(path + generatedName + "/jp/" + generatedName + "_uvlist.txt"))
                {
                    uvList = File.ReadAllBytes(path + generatedName + "/jp/" + generatedName + "_uvlist.txt");
                }
            }
		    GUI.enabled = false;
            baseTex = EditorGUILayout.ObjectField("Base Tex", baseTex, typeof(Texture2D), false) as Texture2D;
            maskTex = EditorGUILayout.ObjectField("Mask Tex", maskTex, typeof(Texture2D), false) as Texture2D;
		    GUI.enabled = true;
            if(baseTex != null && uvList != null)
            {
                if(GUILayout.Button("Separate"))
                {
                    Directory.CreateDirectory(path+generatedName+"/jp/unpacked/");
                    TexUVList t = new TexUVList();
                    t.Initialize(uvList, baseTex);
                    List<string> keys = t.GetKeys();
                    for(int i = 0; i < keys.Count; i++)
                    {
                        TexUVData data = t.GetUVData(keys[i]);
                        int x = (int)(data.u * t.width);
                        int y = (int)((1 - data.v - data.height) * t.height);
                        int w = (int)(data.width * t.width);
                        int h = (int)(data.height * t.height);
                        Texture2D newTex = new Texture2D(w, h, baseTex.format, false, true);
                        Color[] cols = baseTex.GetPixels(x, y, w, h);
                        if(maskTex != null)
                        {
                            Color[] cols2 = maskTex.GetPixels(x, y, w, h);
                            for(int j = 0; j < cols.Length; j++)
                            {
                                cols[j].a = cols2[j].r;
                            }
                        }
                        newTex.SetPixels(0, 0, w, h, cols);
                        newTex.Apply();
                        byte[] pngData = newTex.EncodeToPNG();
                        File.WriteAllBytes(path+generatedName+"/jp/unpacked/"+keys[i]+".png", pngData);
                    }
                }
                // MaskField > language to recreate
                language = EditorGUILayout.MaskField("Language", language, languageList);
                if(GUILayout.Button("Generate languages"))
                {
                    TexUVList t = new TexUVList();
                    t.Initialize(uvList, baseTex);
                    List<string> keys = t.GetKeys();

                    for(int i = 0; i < languageList.Length; i++)
                    {
                        if((language & (1 << i)) == 0)
                            continue;
                        string langPath = path+generatedName+"/"+languageList[i];
                        if(Directory.Exists(langPath))
                        {
                            string[] newTexList = Directory.GetFiles(langPath+"/unpacked");
                            Texture2D[] allTex = new Texture2D[keys.Count];
                            for(int j = 0; j < keys.Count; j++)
                            {
                                string texFile = "";
                                int idx = System.Array.FindIndex(newTexList, (string _) =>
                                {
                                    return _.Contains("/"+keys[j]+".png");
                                });
                                if(idx >= 0)
                                    texFile = newTexList[idx];
                                else
                                    texFile = path+generatedName+"/jp/unpacked/"+keys[j]+".png";
                                allTex[j] = new Texture2D(1, 1);
                                allTex[j].LoadImage(File.ReadAllBytes(texFile));
                            }
                            Texture2D packedFile = new Texture2D(1, 1);
                            Rect[] rects = packedFile.PackTextures(allTex, 0, 2048, false);
                            Color[] cols = packedFile.GetPixels(0, 0, packedFile.width, packedFile.height, 0);
                            Texture2D baseFile = new Texture2D(packedFile.width, packedFile.height, TextureFormat.ARGB32, false, true);
                            for(int k = 0; k < cols.Length; k++)
                            {
                                cols[k].a = 1;
                            }
                            baseFile.SetPixels(0, 0, packedFile.width, packedFile.height, cols, 0);
                            File.WriteAllBytes(langPath + "/" + generatedName + "_base.png", baseFile.EncodeToPNG());
                            if(maskTex != null)
                            {
                                Texture2D maskFile = new Texture2D(packedFile.width, packedFile.height, TextureFormat.ARGB32, false, true);
                                cols = packedFile.GetPixels(0, 0, packedFile.width, packedFile.height, 0);
                                for(int k = 0; k < cols.Length; k++)
                                {
                                    cols[k].r = cols[k].a;
                                    cols[k].g = cols[k].a;
                                    cols[k].b = cols[k].a;
                                    cols[k].a = 1;
                                }
                                maskFile.SetPixels(0, 0, packedFile.width, packedFile.height, cols, 0);
                                File.WriteAllBytes(langPath + "/" + generatedName + "_mask.png", maskFile.EncodeToPNG());
                            }
                            using(StreamWriter fw = new StreamWriter(langPath + "/" + generatedName + "_uvlist.txt", false))
                            {
                                fw.WriteLine(string.Format("{0},{1},{2}", generatedName, packedFile.width, packedFile.height));
                                for(int j = 0; j < rects.Length; j++)
                                {
                                    int x = (int)(rects[j].xMin * packedFile.width);
                                    int y = (int)((1 - rects[j].yMin - rects[j].height) * packedFile.height);
                                    int w = (int)(rects[j].width * packedFile.width);
                                    int h = (int)(rects[j].height * packedFile.height);
                                    fw.WriteLine(string.Format("{0},{1},{2},{3},{4}", keys[j], x, y, w, h));
                                }
                            }
                        }
                    }
                }
            }
        }
		EditorGUILayout.EndScrollView();
		EditorGUILayout.EndVertical();
	}
}
#endif
