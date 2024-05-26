#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
    string[] uvListAsset;
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
            for(int i = 0; i < dirs.Count; i++)
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
                uvListAsset = null;
                
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
                if(File.Exists(path + generatedName + "/jp/" + generatedName + "_uvlist.asset"))
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
                    uvListAsset = File.ReadAllLines(path + generatedName + "/jp/" + generatedName + "_uvlist.asset");
                    if(uvListAsset != null)
                    {
                        // Parse YAML
                        int mw = 0;
                        int mh = 0;
                        string mn;
                        List<Rect> mr = new List<Rect>();
                        List<string> ms = new List<string>();
                        for(int i = 0; i < uvListAsset.Length; i++)
                        {
                            if(uvListAsset[i].Contains("m_width:"))
                            {
                                mw = int.Parse(uvListAsset[i].Split(new char[1]{' '}).Last());
                            }
                            else if(uvListAsset[i].Contains("m_height:"))
                            {
                                mh = int.Parse(uvListAsset[i].Split(new char[1]{' '}).Last());
                            }
                            else if(uvListAsset[i].Contains("m_name:"))
                            {
                                mn = uvListAsset[i].Split(new char[1]{' '}).Last();
                            }
                            else if(uvListAsset[i].Contains("m_serializeDatas:"))
                            {
                                i++;
                                int tu = -1;
                                int tv = -1;
                                int tw = -1;
                                int th = -1;
                                string ts = "";
                                while(i < uvListAsset.Length)
                                {
                                    if(uvListAsset[i].Contains("- name:"))
                                    {
                                        ms.Add(uvListAsset[i].Split(new char[1]{' '}).Last());
                                        mr.Add(new Rect());
                                    }
                                    else if(uvListAsset[i].Contains("  u:"))
                                    {
                                        Rect r = mr[mr.Count - 1];
                                        r.x = Single.Parse(uvListAsset[i].Split(new char[1]{' '}).Last());
                                        mr[mr.Count - 1] = r;
                                    }
                                    else if(uvListAsset[i].Contains("  v:"))
                                    {
                                        Rect r = mr[mr.Count - 1];
                                        r.y = Single.Parse(uvListAsset[i].Split(new char[1]{' '}).Last());
                                        mr[mr.Count - 1] = r;
                                    }
                                    else if(uvListAsset[i].Contains("  width:"))
                                    {
                                        Rect r = mr[mr.Count - 1];
                                        r.width = Single.Parse(uvListAsset[i].Split(new char[1]{' '}).Last());
                                        mr[mr.Count - 1] = r;
                                    }
                                    else if(uvListAsset[i].Contains("  height:"))
                                    {
                                        Rect r = mr[mr.Count - 1];
                                        r.height = Single.Parse(uvListAsset[i].Split(new char[1]{' '}).Last());
                                        mr[mr.Count - 1] = r;
                                    }
                                    else
                                        break;
                                    i++;
                                }
                            }
                        }
                        string res = "";
                        res += string.Format("{0},{1},{2}\n", ms, mw, mh);
                        for(int j = 0; j < mr.Count; j++)
                        {
                            res += string.Format("{0},{1},{2},{3},{4}\n", ms[j], (int)(mr[j].x * mw), (int)(mr[j].y * mh), (int)(mr[j].width * mw), (int)(mr[j].height * mh));
                        }
                        uvList = Encoding.ASCII.GetBytes(res);
                    }
                }
            }
		    GUI.enabled = false;
            baseTex = EditorGUILayout.ObjectField("Base Tex", baseTex, typeof(Texture2D), false) as Texture2D;
            maskTex = EditorGUILayout.ObjectField("Mask Tex", maskTex, typeof(Texture2D), false) as Texture2D;
		    GUI.enabled = true;
            if(baseTex != null && (uvList != null || uvListAsset != null))
            {
                if(GUILayout.Button("Separate"))
                {
                    Directory.CreateDirectory(path+generatedName+"/jp/unpacked/");
                    TexUVList t = new TexUVList();
                    if(uvList != null)
                    {
                        t.Initialize(uvList, baseTex);
                    }
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
                            bool[] isTranslated = new bool[keys.Count];
                            Texture2D tmpTex = new Texture2D(1, 1);
                            bool isSameSize = true;
                            for(int j = 0; j < keys.Count; j++)
                            {
                                string texFile = "";
                                int idx = System.Array.FindIndex(newTexList, (string _) =>
                                {
                                    return _.Contains("/"+keys[j]+".png");
                                });
                                isTranslated[j] = idx >= 0;
                                if(idx >= 0)
                                    texFile = newTexList[idx];
                                else
                                    texFile = path+generatedName+"/jp/unpacked/"+keys[j]+".png";
                                tmpTex.LoadImage(File.ReadAllBytes(texFile));
                                int w = (int)(t.GetUVData(keys[j]).width * t.width);
                                int h = (int)(t.GetUVData(keys[j]).height * t.height);
                                isSameSize &= (w == tmpTex.width && h == tmpTex.height);
                                allTex[j] = new Texture2D(tmpTex.width + 2, tmpTex.height + 2);
                                allTex[j].SetPixels(1, 1, tmpTex.width, tmpTex.height, tmpTex.GetPixels(0, 0, tmpTex.width, tmpTex.height));
                                for(int y = 0; y < allTex[j].height; y++)
                                {
                                    allTex[j].SetPixel(0, y, allTex[j].GetPixel(1, Mathf.Clamp(y, 1, allTex[j].height - 2)));
                                    allTex[j].SetPixel(allTex[j].width - 1, y, allTex[j].GetPixel(allTex[j].width - 2, Mathf.Clamp(y, 1, allTex[j].height - 2)));
                                }
                                for(int x = 1; x < allTex[j].width - 1; x++)
                                {
                                    allTex[j].SetPixel(x, 0, allTex[j].GetPixel(Mathf.Clamp(x, 1, allTex[j].width - 2), 1));
                                    allTex[j].SetPixel(x, allTex[j].height - 1, allTex[j].GetPixel(Mathf.Clamp(x, 1, allTex[j].width - 2), allTex[j].height - 2));
                                }
                            }
                            if(isSameSize)
                            {
                                // Override the existing texture
                                //File.Copy(, langPath + "/" + generatedName + "_base.png");
                                Texture2D packedFile = new Texture2D(1, 1);
                                packedFile.LoadImage(File.ReadAllBytes(path + generatedName + "/jp/" + generatedName + "_base.png"), false);
                                Texture2D maskPackedFile = null;
                                if(maskTex != null)
                                {
                                    //File.Copy(, langPath + "/" + generatedName + "_mask.png");
                                    maskPackedFile = new Texture2D(1, 1);
                                    maskPackedFile.LoadImage(File.ReadAllBytes(path + generatedName + "/jp/" + generatedName + "_mask.png"), false);
                                }
                                for(int j = 0; j < keys.Count; j++)
                                {
                                    if(!isTranslated[j])
                                        continue;
                                    TexUVData data = t.GetUVData(keys[j]);
                                    int x = (int)(data.u * t.width);
                                    int y = (int)((1 - data.v - data.height) * t.height);
                                    int w = (int)(data.width * t.width);
                                    int h = (int)(data.height * t.height);
                                    Color[] cols = allTex[j].GetPixels(0, 0, w, h);
                                    for(int k = 0; k < cols.Length; k++)
                                        cols[k].a = 1;
                                    packedFile.SetPixels(x, y, w, h, cols);
                                    if(maskPackedFile != null)
                                    {
                                        cols = allTex[j].GetPixels(0, 0, w, h);
                                        for(int k = 0; k < cols.Length; k++)
                                        {
                                            cols[k].r = cols[k].g = cols[k].b = cols[k].a;
                                            cols[k].a = 1;
                                        }
                                        maskPackedFile.SetPixels(x, y, w, h, cols);
                                    }
                                }
                                File.WriteAllBytes(langPath + "/" + generatedName + "_base.png", packedFile.EncodeToPNG());
                                if(maskPackedFile != null)
                                    File.WriteAllBytes(langPath + "/" + generatedName + "_mask.png", maskPackedFile.EncodeToPNG());

                                using(StreamWriter fw = new StreamWriter(langPath + "/" + generatedName + "_uvlist.txt", false))
                                {
                                    fw.WriteLine(string.Format("{0},{1},{2}", t.name, t.width, t.height));
                                    foreach(string k in t.GetKeys())
                                    {
                                        TexUVData data = t.GetUVData(k);
                                        int x = (int)(data.u * t.width);
                                        int y = (int)(data.v * t.height);
                                        int w = (int)(data.width * t.width);
                                        int h = (int)(data.height * t.height);
                                        fw.WriteLine(string.Format("{0},{1},{2},{3},{4}", data.name, x, y, w, h));
                                    }
                                }
                            }
                            else
                            {
                                // Generate a new file
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
                                        int x = (int)(rects[j].xMin * packedFile.width) + 2;
                                        int y = (int)((1 - rects[j].yMin - rects[j].height) * packedFile.height) + 2;
                                        int w = (int)(rects[j].width * packedFile.width) - 4;
                                        int h = (int)(rects[j].height * packedFile.height) - 4;
                                        fw.WriteLine(string.Format("{0},{1},{2},{3},{4}", keys[j], x, y, w, h));
                                    }
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
