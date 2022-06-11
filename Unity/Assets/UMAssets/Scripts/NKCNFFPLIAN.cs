using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class NKCNFFPLIAN
{
	// private NNJFKLBPBNK MLCELGHBCLK = new NNJFKLBPBNK(); // 0x8
	// private CEBFFLDKAEC PJHFOFGOPDA = new CEBFFLDKAEC(); // 0xC
	// private CEBFFLDKAEC CKDHEFMLDIG = new CEBFFLDKAEC(); // 0x10
	// private NNJFKLBPBNK FINCFIGKHPA = new NNJFKLBPBNK(); // 0x14

	public string LJNAKDMILMC { get { UnityEngine.Debug.Log("TODO"); return ""; } } // LIIHHICIBKM 0x18AEE50
	public int CNDDKMJAIBG { get { UnityEngine.Debug.Log("TODO"); return 0; } } // HIGNHAEJKAH 0x18AEE7C
	public int DMJGDDEACMD { get { UnityEngine.Debug.Log("TODO"); return 0; } } // FPNFJECMBAG 0x18AEEA8
	public string OPFGFINHFCE { get // DKJOHDGOIJE 0x18AEED4
    {
        UnityEngine.Debug.LogError("TODO");
        return "";
    } }
 
	// // RVA: 0x18AEF00 Offset: 0x18AEF00 VA: 0x18AEF00
	public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
    {
        UnityEngine.Debug.LogError("TODO");
    }

	// // RVA: 0x18AF150 Offset: 0x18AF150 VA: 0x18AF150
	public static List<NKCNFFPLIAN> PCODDPDFLHK()
    {
        TextAsset text = Resources.Load("cn") as TextAsset;
        byte[] data = text.bytes;
        byte[] data2 = new byte[data.Length];
        byte k = 117;
        for(int i = 0; i < data.Length; i++)
        {
            data2[i] = (byte)(k ^ data[i]);
            k = (byte)((k * 13)%256);
        }
        byte[] data3 = BOBCNJIPPJN.JCBCBNFPJDH(data2);
        EDOHBJAPLPF_JsonData jsondata = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(Encoding.UTF8.GetString(data3));
        List<NKCNFFPLIAN> res = new List<NKCNFFPLIAN>();
        for(int i = 0; i < jsondata.HNBFOAJIIAL_Count; i++)
        {
            NKCNFFPLIAN n = new NKCNFFPLIAN();
            n.KHEKNNFCAOI(jsondata[i]);
            res.Add(n);
        }
        return res;
    }
}
