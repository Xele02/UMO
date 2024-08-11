using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class PoFile
{
    public Dictionary<string, string> translationData = new Dictionary<string, string>();

    public string KeyPrefix = "";

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
                    str = str.Replace("\n", "\\n").Replace("\"", "\\\"").Replace("\r","\\r");
                    writer.WriteLine("msgstr \""+(isTemplate ? "" : str)+"\"");
                    writer.WriteLine("");
                }
            }
        }
    }

    public void LoadFile(string filePath, bool clear = false, bool useKeyInsteadOfString = false)
    {
        if(clear)
            translationData.Clear();
        if(!File.Exists(filePath))
        {
            UnityEngine.Debug.LogError("Cannont find "+filePath);
            return;
        }
        using(StreamReader reader = new StreamReader(filePath))
        {
            string msgId = null;
            string msgStr = null;
            while(true)
            {
                string line = reader.ReadLine();
                if(line == null || line == "")
                {
                    if(msgStr != null && msgId != null && msgId != "")
                    {
                        //UnityEngine.Debug.LogError("A Msg "+msgId+":"+msgStr);
                        msgStr = msgStr.Replace("\\\"", "\"").Replace("\\n", "\n").Replace("\\r", "\r");
                        if(translationData.ContainsKey(msgId))
                        {
                            if(!string.IsNullOrEmpty(msgStr))
                            {
                                //UnityEngine.Debug.LogError("Replace "+msgId+":"+msgStr);
                                translationData[msgId] = useKeyInsteadOfString ? KeyPrefix + msgId : msgStr;
                            }
                        }
                        else
                        {
                            //UnityEngine.Debug.LogError("Add "+msgId+":"+msgStr);
                            translationData.Add(msgId, useKeyInsteadOfString ? KeyPrefix + msgId : msgStr);
                        }
                    }
                    msgId = null;
                    msgStr = null;
                }
                if(line == null)
                    break;
                if(line.StartsWith("msgid \""))
                {
                    msgId = line.Replace("msgid \"", "");
                    msgId = msgId.Remove(msgId.Length - 1, 1);
                    //UnityEngine.Debug.LogError("Read Id "+msgId+":"+msgStr);
                }
                else if(line.StartsWith("msgstr \""))
                {
                    msgStr = line.Replace("msgstr \"", "");
                    msgStr = msgStr.Remove(msgStr.Length - 1, 1);
                    //UnityEngine.Debug.LogError("Read Msg "+msgId+":"+msgStr);
                }
                else if(line.StartsWith("\""))
                {
                    string s = line.Replace("\"", "");
                    if(msgStr == null)
                    {
                        if(msgId != null)
                            msgId += s;
                    }
                    else
                    {
                        msgStr += s;
                    }
                }
            }
        }
    }

    public void WriteToArchiveAsBankData(CBBJHPBGBAJ_Archive archive, string fileName)
    {
        // Generate db translated file
        // Binary format : (From MessageBank : SetupFromBinary)
        // 0 : int32 numStrings
        // 4 - 14 : 0xff
        // loop num (4 * 4 * num)
        //    int32 offset1
        //    int32 size1
        //    int32 offset2
        //    int32 size2
        // loop strings
        //    string (offset, size) Encoding.Unicode.GetString
        if(translationData.Count > 0)
        {
            using(MemoryStream stream = new MemoryStream())
            {
                using(BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(translationData.Count);
                    for(int i = 4; i < 16; i++)
                        writer.Write((byte)0xff);
                    for(int i = 0; i < translationData.Count; i++)
                    {
                        int v = 0;
                        writer.Write(v);
                        writer.Write(v);
                        writer.Write(v);
                        writer.Write(v);
                    }
                    int infoOffset = 16;
                    int curOffset = 16 + 4 * 4 * translationData.Count;
                    foreach(var k in translationData)
                    {
                        byte[] strByte = Encoding.Unicode.GetBytes(k.Value);
                        writer.Write(strByte);
                        writer.Seek(infoOffset, SeekOrigin.Begin);
                        writer.Write(curOffset);
                        writer.Write(strByte.Length);
                        curOffset += strByte.Length;
                        writer.Seek(0, SeekOrigin.End);
                        infoOffset += 8;

                        strByte = Encoding.Unicode.GetBytes(k.Key);
                        writer.Write(strByte);
                        writer.Seek(infoOffset, SeekOrigin.Begin);
                        writer.Write(curOffset);
                        writer.Write(strByte.Length);
                        curOffset += strByte.Length;
                        writer.Seek(0, SeekOrigin.End);
                        infoOffset += 8;
                    }
                    writer.Flush();
                    byte[] data = stream.ToArray();
                    archive.KGHAJGGMPKL_Files.Add(new CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File() { OPFGFINHFCE_Name = fileName, DBBGALAPFGC_Data = data });
                    writer.Close();
                }
            }
        }
    }
}