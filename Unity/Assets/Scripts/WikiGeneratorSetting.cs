#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEditor;
#endif
using UnityEngine;
using XeApp.Game;
using XeApp.Game.Common;
using XeApp.Game.Menu;

[CreateAssetMenu(fileName = "WikiGeneratorSetting", menuName = "ScriptableObjects/WikiGeneratorSetting", order = 1)]
class WikiGeneratorSetting : ScriptableObject
{
	private static WikiGeneratorSetting m_currentSettings;
	public static WikiGeneratorSetting CurrentSettings
	{
		get
		{
			if (m_currentSettings == null)
			{
				m_currentSettings = Resources.Load<WikiGeneratorSetting>("WikiGeneratorSetting");
				if (m_currentSettings == null)
					m_currentSettings = new WikiGeneratorSetting();
			}
			return m_currentSettings;
		}
	}

    public string OutputPath = "";
}


#if UNITY_EDITOR
static class WikiGenerator
{
    static private bool CheckStart()
    {
        string basePath = WikiGeneratorSetting.CurrentSettings.OutputPath;
        if(basePath == "")
            return false;
        if(!Directory.Exists(basePath))
        {
            Debug.LogError("Directory not found");
            return false;
        }

        if(IMMAOANGPNK.HHCJCDFCLOB == null || IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database == null || ! IMMAOANGPNK.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
        {
            Debug.LogError("Database not running, start the game first");
            return false;
        }
        return true;
    }

    [MenuItem("UMO/Generate Wiki/Images/Diva")]
    static public void GenerateImageDiva()
    {
        if(!CheckStart())
            return;
        string basePath = WikiGeneratorSetting.CurrentSettings.OutputPath;

        basePath += "/images/diva/";

        Debug.LogError("Export diva");

        CleanDirectory(basePath);

        int total = 0;

        for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes.Count; i++)
        {
            LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes[i];
            if(cos.PPEGAKEIEGM_Enabled == 2)
            {
                for(int j = 0; j < (int)DivaIconTextureCache.IconType.Num; j++)
                {
                    total++;
                    int divaId = cos.AHHJLDLAPAN_PrismDivaId;
                    int costume = cos.DAJGPBLEEOB_PrismCostumeModelId;
                    int type = j;
                    string typestr = "";
                    switch((DivaIconTextureCache.IconType)type)
                    {
                        case DivaIconTextureCache.IconType.SSize: typestr = "s"; break;
                        case DivaIconTextureCache.IconType.LSize: typestr = "l"; break;
                        case DivaIconTextureCache.IconType.MSize: typestr = "m"; break;
                        case DivaIconTextureCache.IconType.PS: typestr = "ps"; break;
                        default: break;
                    }
                    GameManager.Instance.DivaIconCache.Load(DivaIconTextureCache.GetIconPath((DivaIconTextureCache.IconType)type, divaId, costume, 0), (IiconTexture texture) =>
                    {
                        Material mat = new Material(Shader.Find("MCRS/SplitTextureRGB16A8"));
                        mat.SetTexture("_MainTex", texture.BaseTexture);
                        mat.SetTexture("_MaskTex", texture.MaskTexture);
                        Texture2D tex = TextureHelper.Copy(texture.BaseTexture, -1, -1, mat);
                        File.WriteAllBytes(basePath + string.Format("cs_{0:D2}_{1:D3}_{2}_{3}", divaId, costume, 0, typestr) + ".png", tex.EncodeToPNG());
                        total--;
                        UnityEngine.Debug.LogError("Export left : "+total);
                    });
                    short[] cols = cos.CHDBGFLFPNC_GetAllAvaiableColors();
                    for(int k = 0; k < cols.Length; k++)
                    {
                        total++;
                        int col = cols[k];
                        GameManager.Instance.DivaIconCache.Load(DivaIconTextureCache.GetIconPath((DivaIconTextureCache.IconType)type, divaId, costume, col), (IiconTexture texture) =>
                        {
                            Material mat = new Material(Shader.Find("MCRS/SplitTextureRGB16A8"));
                            mat.SetTexture("_MainTex", texture.BaseTexture);
                            mat.SetTexture("_MaskTex", texture.MaskTexture);
                            Texture2D tex = TextureHelper.Copy(texture.BaseTexture, -1, -1, mat);
                            File.WriteAllBytes(basePath + string.Format("cs_{0:D2}_{1:D3}_{2}_{3}", divaId, costume, col, typestr) + ".png", tex.EncodeToPNG());
                            total--;
                            UnityEngine.Debug.LogError("Export left : "+total);
                        });
                    }
                }
            }
        }
    }

    [MenuItem("UMO/Generate Wiki/Images/Music")]
    static public void GenerateImageMusic()
    {
        if(!CheckStart())
            return;
        string basePath = WikiGeneratorSetting.CurrentSettings.OutputPath;

        basePath += "/images/music/";

        int total = 0;

        Debug.LogError("Export music");

        CleanDirectory(basePath);

        LPPGENBEECK_MusicMaster MusicDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music;
		for (int i = 0; i < MusicDb.EPMMNEFADAP_Musics.Count; i++)
		{
			if (MusicDb.EPMMNEFADAP_Musics[i].JNCPEGJGHOG_Cov > 0)
			{
                total++;
                int covId = MusicDb.EPMMNEFADAP_Musics[i].JNCPEGJGHOG_Cov;
                GameManager.Instance.MusicJacketTextureCache.Load(covId, (IiconTexture texture) =>
                {
                    Material mat = new Material(Shader.Find("MCRS/SplitTextureRGB16A8"));
                    mat.SetTexture("_MainTex", texture.BaseTexture);
                    mat.SetTexture("_MaskTex", texture.MaskTexture);
                    Texture2D tex = TextureHelper.Copy(texture.BaseTexture, -1, -1, mat);
                    File.WriteAllBytes(basePath + string.Format("mc_{0:D3}_jacket", covId) + ".png", tex.EncodeToPNG());
                    total--;
                    UnityEngine.Debug.LogError("Export left : "+total);
                });
            }
        }
    }

    [MenuItem("UMO/Generate Wiki/Files")]
    static public void GenerateWiki()
    {
        if(!CheckStart())
            return;
        string basePath = WikiGeneratorSetting.CurrentSettings.OutputPath;

        string version = "v_0.3";

        EDOHBJAPLPF_JsonData pageExchangeData = new EDOHBJAPLPF_JsonData();
        pageExchangeData["publisher"] = "Xele";
        pageExchangeData["author"] = "Xele";
        pageExchangeData["language"] = "en";
        pageExchangeData["url"] = "https://github.com/Xele02/UMO/";
        pageExchangeData["packages"] = new EDOHBJAPLPF_JsonData();
        pageExchangeData["packages"]["UMO"] = new EDOHBJAPLPF_JsonData();
        pageExchangeData["packages"]["UMO"]["globalID"] = "umo.dataset";
        pageExchangeData["packages"]["UMO"]["version"] = version;
        pageExchangeData["packages"]["UMO"]["pages"] = new EDOHBJAPLPF_JsonData();


        UpdatePages(basePath, pageExchangeData["packages"]["UMO"]["pages"]);

        File.WriteAllText(basePath + "page-exchange.json", pageExchangeData.EJCOJCGIBNG_ToJson());

        Debug.LogError("Done");
    }

    static private void CleanDirectory(string path)
    {
        if(Directory.Exists(path))
        {
            Directory.Delete(path, true);
        }
        Directory.CreateDirectory(path);
    }

    static private void UpdatePages(string basePath, EDOHBJAPLPF_JsonData pages)
    {
        Debug.LogError("Export pages");
        
        List<System.Object> toExport = new List<System.Object>();

        toExport.AddRange(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.EPMMNEFADAP_Musics);
        toExport.AddRange(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA_Divas);
        toExport.AddRange(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes);

		while(toExport.Count > 0)
		{
            System.Object obj = toExport[0];
            toExport.RemoveAt(0);

            Type t = obj.GetType();

		    string fileOutput = "";
            WikiPageAttribute pageAttr = t.GetCustomAttributes(typeof(WikiPageAttribute), true).FirstOrDefault() as WikiPageAttribute;
            if(pageAttr == null)
                continue;

            string fileName = pageAttr.GetFileName(obj)+".mediawiki";

            string templateName = pageAttr.GetTemplateName(obj);
            string title = pageAttr.GetTitle(obj);
            fileOutput += "{{"+templateName+"\n";

            bool pageValid = true;
            WikiPageAttribute.ForEachWikiMember(obj, (WikiPropertyAttribute propAttr, System.Object val) =>
            {
                if(!propAttr.IsPageValid(obj))
                {
                    pageValid = false;
                    return false;;
                }
                return true;
            });
            if(!pageValid)
                continue;
                
            
            WikiPageAttribute.ForEachWikiMember(obj, (WikiPropertyAttribute propAttr, System.Object val) =>
            {
                fileOutput += " |"+propAttr.name+"="+val.ToString()+"\n";
                propAttr.InsertAddExport(obj, ref toExport);
                return true;
            });

            fileOutput +=   "}}\n";
            fileOutput += "[[Category:Generated]]\n";

            EDOHBJAPLPF_JsonData pageInfo = new EDOHBJAPLPF_JsonData();
            pageInfo["name"] = title;
            pageInfo["namespace"] = "NS_MAIN";
            pageInfo["url"] = "https://raw.githubusercontent.com/Xele02/UMO/Wiki/Wiki/"+fileName;
            pages.Add(pageInfo);

            Directory.CreateDirectory(Path.GetDirectoryName(basePath + fileName));
            File.WriteAllText(basePath + fileName, fileOutput);
		}
    }

}
#endif

[System.AttributeUsage(System.AttributeTargets.Class |  
                       System.AttributeTargets.Struct)  
]  
public class WikiPageAttribute : System.Attribute  
{  
    public string title;
    public string filename;
    public string templateName;
  
    public WikiPageAttribute(string title = null, string filename = null, string templateName = null)
    {
        this.title = title;
        this.filename = filename;
        this.templateName = templateName;
    }

    public static System.Reflection.BindingFlags flags = System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Static;

    public static void ForEachWikiMember(System.Object obj, Func<WikiPropertyAttribute, System.Object, bool> func)
    {
        Type t = obj.GetType();
        foreach(var p in t.GetFields(flags))
        {
            WikiPropertyAttribute propAttr = p.GetCustomAttributes(typeof(WikiPropertyAttribute), true).FirstOrDefault() as WikiPropertyAttribute;
            if(propAttr != null)
            {
                if(!func(propAttr, p.GetValue(obj)))
                    return;
            }
        }
        foreach(var p in t.GetProperties(flags))
        {
            WikiPropertyAttribute propAttr = p.GetCustomAttributes(typeof(WikiPropertyAttribute), true).FirstOrDefault() as WikiPropertyAttribute;
            if(propAttr != null)
            {
                if(!func(propAttr, p.GetValue(obj)))
                    return;
            }
        }
    }

    Regex replaceFindRe = new Regex(@"\{(\w*?)(:\w+)?\}", RegexOptions.Compiled);

    private string ReplaceParams(System.Object obj, string text)
    {
        string q = replaceFindRe.Replace(text, delegate(Match match)
        {
            string key = match.Groups[1].Value;
            ForEachWikiMember(obj, (WikiPropertyAttribute propAttr, System.Object val) => {
                if(propAttr.name == key)
                {
                    key = string.Format("{0"+match.Groups[2].Value+"}", val);
                    return false;
                }
                return true;
            });
            return key;
        });
        return q;
    }

    public string GetFileName(System.Object obj)
    {
        return ReplaceParams(obj, filename);
    }

    public string GetTemplateName(System.Object obj)
    {
        return ReplaceParams(obj, templateName);
    }

    public string GetTitle(System.Object obj)
    {
        return ReplaceParams(obj, title);
    }
}

public static class WikiValidNotEqual
{
    public static bool IsValid(System.Object obj, System.Object val, object[] p)
    {
        return System.Convert.ToInt32(val) != System.Convert.ToInt32(p[1]);
    }
}

[System.AttributeUsage(System.AttributeTargets.Property | System.AttributeTargets.Field)]  
public class WikiPropertyAttribute : System.Attribute  
{
    public string name;
    object[] pageValidChecker;
    string memberName;
    string addExport;
  
    public WikiPropertyAttribute(string name, object[] pageValidChecker = null, string addExport = null, [CallerMemberName] string memberName = "")  
    {  
        this.name = name;
        this.pageValidChecker = pageValidChecker;
        this.memberName = memberName;
        this.addExport = addExport;
    }

    public bool IsPageValid(System.Object obj)
    {
        if(pageValidChecker != null)
        {
            if((bool)(pageValidChecker[0] as Type).GetMethod("IsValid").Invoke(null, new object[] {obj, GetValue(obj), pageValidChecker }) == false)
                return false;
        }
        return true;
    }

    public void InsertAddExport(System.Object obj, ref List<System.Object> toExport)
    { 
        if(addExport != null)
        {
            if(addExport == "MusicText")
            {
                toExport.Add(Database.Instance.musicText.Get(System.Convert.ToInt32(GetValue(obj))));
            }
        }
    }

    public System.Object GetValue(System.Object obj)
    {
        System.Reflection.FieldInfo field = obj.GetType().GetField(memberName, WikiPageAttribute.flags);
        if(field != null)
            return field.GetValue(obj);
        
        System.Reflection.PropertyInfo prop = obj.GetType().GetProperty(memberName, WikiPageAttribute.flags);
        if(prop != null)
            return prop.GetValue(obj);
        return null;
    }
}  