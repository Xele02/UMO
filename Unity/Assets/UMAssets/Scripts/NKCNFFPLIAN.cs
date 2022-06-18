using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class NKCNFFPLIAN
{
	private NNJFKLBPBNK MLCELGHBCLK = new NNJFKLBPBNK(); // 0x8
	private CEBFFLDKAEC PJHFOFGOPDA = new CEBFFLDKAEC(); // 0xC
	private CEBFFLDKAEC CKDHEFMLDIG = new CEBFFLDKAEC(); // 0x10
	private NNJFKLBPBNK FINCFIGKHPA = new NNJFKLBPBNK(); // 0x14

	public string LJNAKDMILMC { get { return MLCELGHBCLK.DNJEJEANJGL; } } // LIIHHICIBKM 0x18AEE50
	public int CNDDKMJAIBG { get { return PJHFOFGOPDA.DNJEJEANJGL; } } // HIGNHAEJKAH 0x18AEE7C
	public int DMJGDDEACMD { get { return CKDHEFMLDIG.DNJEJEANJGL; } } // FPNFJECMBAG 0x18AEEA8
	public string OPFGFINHFCE { get { return FINCFIGKHPA.DNJEJEANJGL; } } // DKJOHDGOIJE 0x18AEED4
 
	// // RVA: 0x18AEF00 Offset: 0x18AEF00 VA: 0x18AEF00
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
    {
        MLCELGHBCLK.DNJEJEANJGL = ((string)OBHAFLMHAKG[AFEHLCGHAEE.LJNAKDMILMC]);
        PJHFOFGOPDA.DNJEJEANJGL = ((int)OBHAFLMHAKG[AFEHLCGHAEE.CNDDKMJAIBG]);
        FINCFIGKHPA.DNJEJEANJGL = ((string)OBHAFLMHAKG[AFEHLCGHAEE.OPFGFINHFCE]);
        CKDHEFMLDIG.DNJEJEANJGL = ((int)OBHAFLMHAKG[AFEHLCGHAEE.DMJGDDEACMD]);
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
            n.KHEKNNFCAOI_Init(jsondata[i]);
            res.Add(n);
        }
        return res;
    }
}
