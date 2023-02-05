#if UNITY_EDITOR
using System;
using System.Collections;
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
using XeSys;

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
    public static string CurrentVersion = "";
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
        GameManager.Instance.StartCoroutine(GenerateWikiCoroutine());
    }

    static IEnumerator GenerateWikiCoroutine()
    {
        if(!CheckStart())
            yield break;
        string basePath = WikiGeneratorSetting.CurrentSettings.OutputPath;

        CurrentVersion = System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");

        EDOHBJAPLPF_JsonData pageExchangeData = new EDOHBJAPLPF_JsonData();
        pageExchangeData["publisher"] = "Xele";
        pageExchangeData["author"] = "Xele";
        pageExchangeData["language"] = "en";
        pageExchangeData["url"] = "https://github.com/Xele02/UMO/";
        pageExchangeData["packages"] = new EDOHBJAPLPF_JsonData();
        pageExchangeData["packages"]["UMO"] = new EDOHBJAPLPF_JsonData();
        pageExchangeData["packages"]["UMO"]["globalID"] = "umo.dataset";
        pageExchangeData["packages"]["UMO"]["version"] = CurrentVersion;
        pageExchangeData["packages"]["UMO"]["pages"] = new EDOHBJAPLPF_JsonData();


        yield return UpdatePages(basePath, pageExchangeData["packages"]["UMO"]["pages"]);

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

    static public IEnumerator CheckTime(WikiIteratorContext ctxt)
    {
        if(Time.realtimeSinceStartup - ctxt.updateTime > 1)
        {
            UnityEngine.Debug.LogError(""+ctxt.numTodo+"/"+ctxt.numDone);
            ctxt.updateTime = Time.realtimeSinceStartup;
            yield return null;
        }
    }

    static private IEnumerator UpdatePages(string basePath, EDOHBJAPLPF_JsonData pages)
    {
        Debug.LogError("Export pages");
        
        WikiIteratorContext ctx = new WikiIteratorContext();
        ctx.toExport.Add(new Tuple<object, string>(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, null));
        ctx.toExport.Add(new Tuple<object, string>(MessageManager.Instance, null));
        ctx.basePath = basePath;
        ctx.pages = pages;

        ctx.numTodo += ctx.toExport.Count;
		while(ctx.toExport.Count > 0)
		{
            Tuple<object, string> obj = ctx.toExport[0];
            ctx.toExport.RemoveAt(0);

            Type t = obj.Item1.GetType();

            WikiPageAttribute pageAttr = t.GetCustomAttributes(typeof(WikiPageAttribute), true).FirstOrDefault() as WikiPageAttribute;
            if(pageAttr == null)
                continue;

            yield return CheckTime(ctx);

            pageAttr.Export(obj.Item1, obj.Item2, ctx);
            ctx.numDone++;
		}

        yield break;
    }

}
#endif

public static class WikiUtils
{

    public static System.Reflection.BindingFlags flags = System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Static;

    public static void ForEachWikiMember(System.Object obj, Func<WikiPropertyAttribute, System.Object, bool> func, WikiIteratorContext ctx)
    {
        bool cont = true;
        Type t = obj.GetType();
        foreach(var p in t.GetFields(flags))
        {
            if(cont)
            {
                WikiPropertyAttribute propAttr = p.GetCustomAttributes(typeof(WikiPropertyAttribute), true).FirstOrDefault() as WikiPropertyAttribute;
                if(propAttr != null)
                {
                    if(!func(propAttr, p.GetValue(obj)))
                        cont = false;
                }
            }
        }
        foreach(var p in t.GetProperties(flags))
        {
            if(cont)
            {
                WikiPropertyAttribute propAttr = p.GetCustomAttributes(typeof(WikiPropertyAttribute), true).FirstOrDefault() as WikiPropertyAttribute;
                if(propAttr != null)
                {
                    if(!func(propAttr, p.GetValue(obj)))
                        cont = false;
                }
            }
        }
    }

    static Regex replaceFindRe = new Regex(@"\{(\w*?)(:\w+)?\}", RegexOptions.Compiled);

    public static string ReplaceParams(System.Object obj, string text, WikiIteratorContext ctx)
    {
        text = text.Replace("IdFromParent", ctx.parent);
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
            }, null);
            return key;
        });
        return q;
    }

}

public class WikiIteratorContext
{
    public float updateTime;
    public int numTodo;
    public int numDone;

    public List<Tuple<System.Object, string>> toExport = new List<Tuple<System.Object, string>>();
    public string basePath;
    public EDOHBJAPLPF_JsonData pages;

    public string subObjectTxt = "";

    public Dictionary<string, List<string>> properties = new Dictionary<string, List<string>>();
    public string parent;

}

public class WikiContainerAttribute : System.Attribute
{
    public WikiPropertyAttribute FindProperty(object obj, string name)
    {
        WikiPropertyAttribute res = null;
        WikiUtils.ForEachWikiMember(obj, (WikiPropertyAttribute propAttr, System.Object val) =>
        {
            if(propAttr.GetMemberName() == name)
                res = propAttr;
            return res == null;
        }, null);
        return res;
    }

    public bool CanExtract(object obj)
    {
        bool isValid = true;
        WikiUtils.ForEachWikiMember(obj, (WikiPropertyAttribute propAttr, System.Object val) =>
        {
            if(!propAttr.IsContainerCheckValid(obj))
            {
                isValid = false;
                return false;;
            }
            return true;
        }, null);
        return isValid;
    }

}

[System.AttributeUsage(System.AttributeTargets.Class |  
                       System.AttributeTargets.Struct)  
] 
public class WikiSubobjectAttribute : WikiContainerAttribute
{
    public string name;

    public WikiSubobjectAttribute(string name = null)
    {
        this.name = name;
    }

    public void Export(object obj, object parentValue, WikiIteratorContext ctx, Action<string> cb)
    {
        if(!CanExtract(obj))
            return;
        string fileOutput = "{{"+name+"\n";

        Dictionary<string, List<string>> properties = ctx.properties; 
        ctx.properties = new Dictionary<string, List<string>>();

        WikiUtils.ForEachWikiMember(obj, (WikiPropertyAttribute propAttr, System.Object val) =>
        {
            propAttr.Export(obj, val, ctx);
            return true;
        }, ctx);

        foreach(var k in ctx.properties)
        {
            if(k.Value.Count > 0)
                fileOutput += " |"+k.Key+"="+string.Join(";", k.Value).Replace("\n","<br/>")+"\n";
        }

        if(parentValue != null)
        {
            fileOutput += " | Has Parent="+parentValue.ToString()+"\n";
        }

        fileOutput +=   "}}\n";
        ctx.subObjectTxt += fileOutput;
        ctx.properties = properties;
        cb(null);
    }
}

[System.AttributeUsage(System.AttributeTargets.Class |  
                       System.AttributeTargets.Struct)  
]  
public class WikiPageAttribute : WikiContainerAttribute
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

    public string GetFileName(System.Object obj, WikiIteratorContext ctx)
    {
        return WikiUtils.ReplaceParams(obj, filename, ctx);
    }

    public string GetTemplateName(System.Object obj, WikiIteratorContext ctx)
    {
        return WikiUtils.ReplaceParams(obj, templateName, ctx);
    }

    public string GetTitle(System.Object obj, WikiIteratorContext ctx)
    {
        return WikiUtils.ReplaceParams(obj, title, ctx);
    }

    public void Export(object obj, string parentProp, WikiIteratorContext ctx, Action<string> onDone = null)
    {
        if(!CanExtract(obj))
            return;
        if(parentProp != null)
        {
            ctx.parent = parentProp;
        }

        string fileName = GetFileName(obj, ctx)+".mediawiki";

        string fileOutput = "";
        string templateName = GetTemplateName(obj, ctx);
        string title = GetTitle(obj, ctx);
        fileOutput += "{{"+templateName+"\n";

        ctx.subObjectTxt = "";
        ctx.properties = new Dictionary<string, List<string>>();

        WikiUtils.ForEachWikiMember(obj, (WikiPropertyAttribute propAttr, System.Object val) => {
            propAttr.Export(obj, val, ctx);
            return true;
        }, ctx);

        foreach(var k in ctx.properties)
        {
            if(k.Value.Count > 0)
                fileOutput += " |"+k.Key+"="+string.Join(";", k.Value).Replace("\n","<br/>")+"\n";
        }

        fileOutput +=   "}}\n";
        fileOutput += ctx.subObjectTxt;
        fileOutput += "[[Category:Generated]]\n";

        EDOHBJAPLPF_JsonData pageInfo = new EDOHBJAPLPF_JsonData();
        pageInfo["name"] = title;
        pageInfo["namespace"] = "NS_MAIN";
        pageInfo["url"] = "https://raw.githubusercontent.com/Xele02/UMO/Wiki/Wiki/"+fileName;
        ctx.pages.Add(pageInfo);

        Directory.CreateDirectory(Path.GetDirectoryName(ctx.basePath + fileName));
        File.WriteAllText(ctx.basePath + fileName, fileOutput);

        if(onDone != null)
            onDone(title);
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
    object[] containerValidChecker;
    string memberName;
    string addExport;
    string parentId;
  

    public string GetMemberName() { return memberName; }
    public WikiPropertyAttribute(string name = null, object[] containerValidChecker = null, string addExport = null, string parentId = null, [CallerMemberName] string memberName = "")  
    {  
        this.name = name;
        this.containerValidChecker = containerValidChecker;
        this.memberName = memberName;
        this.addExport = addExport;
        this.parentId = parentId;
    }

    public bool IsContainerCheckValid(System.Object obj)
    {
        if(containerValidChecker != null)
        {
            if((bool)(containerValidChecker[0] as Type).GetMethod("IsValid").Invoke(null, new object[] {obj, GetValue(obj), containerValidChecker }) == false)
                return false;
        }
        return true;
    }

    public void ExportValue(object parent, object propValue, WikiIteratorContext ctx, Action<string> cb)
    {
        InsertAddExport(parent, ctx);
        string fileOutput = null;
        WikiSubobjectAttribute subAttr = propValue.GetType().GetCustomAttributes(typeof(WikiSubobjectAttribute), true).FirstOrDefault() as WikiSubobjectAttribute;
        if(subAttr != null)
        {
            object parentValue = null;
            if(parentId != null)
            {
                WikiContainerAttribute contAttr = parent.GetType().GetCustomAttributes(typeof(WikiContainerAttribute), true).FirstOrDefault() as WikiContainerAttribute;
                if(contAttr != null)
                {
                    WikiPropertyAttribute prop = contAttr.FindProperty(parent, parentId);
                    if(prop != null)
                        parentValue = prop.GetValue(parent);
                }
            }
            subAttr.Export(propValue, parentValue, ctx, (string res) => {fileOutput = res;});
        }
        else
        {
            WikiPageAttribute pageAttr = propValue.GetType().GetCustomAttributes(typeof(WikiPageAttribute), true).FirstOrDefault() as WikiPageAttribute;
            if(pageAttr != null)
            {
                //pageAttr.Export(propValue, ctx, (string res) => { fileOutput = res; });
                fileOutput = pageAttr.GetTitle(propValue, ctx);
                ctx.toExport.Add(new Tuple<object, string>(propValue, ctx.parent));
                ctx.numTodo++;
            }
            else
            {
                fileOutput = propValue.ToString();
            }
        }
        cb(fileOutput);
    }

    private void AddToExport(object res, WikiIteratorContext ctx)
    {
        if(name == null)
            return;
        if(res == null)
            return;
        if(!ctx.properties.ContainsKey(name))
            ctx.properties.Add(name, new List<string>());
        ctx.properties[name].Add(res.ToString());
    }

    public void Export(object parent, object propValue, WikiIteratorContext ctx)
    {
        if(propValue is System.Array)
        {
            UnityEngine.Debug.LogError("Todo System.Array");
        }
        else if(propValue.GetType().IsGenericType && propValue is IDictionary)
        {
            // Dictionary are axtracted with subobject
            IDictionary valDic = propValue as IDictionary;
            ICollection valKeys = valDic.Keys;
            foreach(var k in valKeys)
            {
                string v = null;
                ctx.parent = k.ToString();
                ExportValue(parent, valDic[k], ctx, (string val) => {
                    v = val;
                });
                if(name != null && v != null)
                {
                    ctx.subObjectTxt += @"
{{"+name+@":
 | Key="+k.ToString()+@"
 | Value="+valDic[k].ToString().Replace("\n","<br/>")+@"
}}
                    ";
                }
            }
        }
        else if(propValue.GetType().IsGenericType && propValue is IList)
        {
            IList valList = propValue as IList;
            for(int i = 0; i < valList.Count; i++)
            {
                ExportValue(parent, valList[i], ctx, (string val) => {
                    AddToExport(val, ctx);
                });
            }
        }
        else
        {
            ExportValue(parent, propValue, ctx, (string val) => {
                AddToExport(val, ctx);
            });

        }
    }

    public void InsertAddExport(System.Object obj, WikiIteratorContext ctx)
    { 
        if(addExport != null)
        {
            if(addExport == "MusicText")
            {
                ctx.toExport.Add(new Tuple<object, string>(Database.Instance.musicText.Get(System.Convert.ToInt32(GetValue(obj))), null));
                ctx.numTodo ++;
            }
        }
    }

    public System.Object GetValue(System.Object obj)
    {
        System.Reflection.FieldInfo field = obj.GetType().GetField(memberName, WikiUtils.flags);
        if(field != null)
            return field.GetValue(obj);
        
        System.Reflection.PropertyInfo prop = obj.GetType().GetProperty(memberName, WikiUtils.flags);
        if(prop != null)
            return prop.GetValue(obj);

        UnityEngine.Debug.LogError("Property "+memberName+" not found");

        return null;
    }
}  