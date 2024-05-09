using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;

public class PoFile
{
    public Dictionary<string, string> translationData = new Dictionary<string, string>();

    public void SaveFile(string filePath, bool isTemplate = false, bool stripEmpty = false)
    {
        using(StreamWriter writer = new StreamWriter(filePath, false))
        {
            using (var provider = CodeDomProvider.CreateProvider("CSharp"))
            {
                writer.WriteLine("msgid \"\"");
                writer.WriteLine("msgstr \"\"");
                writer.WriteLine("");
                foreach(var k in translationData)
                {
                    if(stripEmpty && string.IsNullOrEmpty(k.Value))
                        continue;
                    writer.WriteLine("msgid \""+k.Key+"\"");
                    string str = k.Value;
                    str = str.Replace("\n", "\\n").Replace("\"", "\\\"");
                    writer.WriteLine("msgstr \""+(isTemplate ? "" : str)+"\"");
                    writer.WriteLine("");
                }
            }
        }
    }

    public void LoadFile(string filePath, bool clear = true)
    {
        if(clear)
            translationData.Clear();
        using(StreamReader reader = new StreamReader(filePath))
        {
            string msgId = null;
            string msgStr = null;
            while(true)
            {
                string line = reader.ReadLine();
                if(line == null)
                    break;
                if(line.StartsWith("msgid \""))
                {
                    msgId = line.Replace("msgid \"", "");
                    msgId.Remove(msgId.Length - 2, 1);
                }
                else if(line.StartsWith("msgstr \""))
                {
                    msgStr = line.Replace("msgstr \"", "");
                    msgStr.Remove(msgId.Length - 2, 1);
                }
                else if(line == "")
                {
                    if(msgStr != null && msgId != null)
                    {
                        translationData.Add(msgId, msgStr);
                    }
                    msgId = null;
                    msgStr = null;
                }
            }
        }
    }
}