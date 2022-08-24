using System.Collections;
using System.Collections.Generic;

public class ANCJLICGOLP
{

    private enum CPJMLNDMMHJ
    {
        IKAHLMCKDDF = 0,
        HKFLDNJGGBB = 1,
        HDEONBGNOIO = 2
    }

	private Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK; // 0x8
	private Dictionary<string, JDEFIJBCJLC_EncryptedString> FJOEBCMGDMI; // 0xC
	public List<MFJONNINDCJ> JGJJIBPPEPD_List; // 0x10
	private static List<string> OHNJJIMGKGK_TypesStr; // 0x0

	// RVA: 0xD52C1C Offset: 0xD52C1C VA: 0xD52C1C
	public int LPJLEHAJADA(string LJNAKDMILMC, int KKMJBMKHGNH)
	{
		if(!OHJFBLFELNK.ContainsKey(LJNAKDMILMC))
		{
			return KKMJBMKHGNH;
		}
		return OHJFBLFELNK[LJNAKDMILMC].DNJEJEANJGL_Value;
	}

	// RVA: 0xD52D00 Offset: 0xD52D00 VA: 0xD52D00
	//public string EFEGBHACJAL(string LJNAKDMILMC, string KKMJBMKHGNH) { }

	// RVA: 0xD52DE4 Offset: 0xD52DE4 VA: 0xD52DE4
	public List<string> ELJGLMPOINC_GetTypesStr()
	{
		return OHNJJIMGKGK_TypesStr;
	}

	public void KHEKNNFCAOI_Init()
	{
		OHJFBLFELNK = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		FJOEBCMGDMI = new Dictionary<string, JDEFIJBCJLC_EncryptedString>();
		JGJJIBPPEPD_List = new List<MFJONNINDCJ>();
	}

	// RVA: 0xD52F58 Offset: 0xD52F58 VA: 0xD52F58
	public bool IIEMACPEEBJ(List<string> ANFNAHPIJDH, EDOHBJAPLPF_JsonData AAEDAEHIONI)
	{
		int cnt = 0;    // var7
		int cnt2 = 0;  // var9
		do
		{
			int size = ANFNAHPIJDH.Count;
			if(size <= cnt)
			{
				size = OHNJJIMGKGK_TypesStr.Count;
				return size == cnt2;
			}
			if(AAEDAEHIONI != null)
			{
				string s = ANFNAHPIJDH[cnt];
				bool r = AAEDAEHIONI.BBAJPINMOEP_Contains(s);
				if(r)
				{
					EDOHBJAPLPF_JsonData a = AAEDAEHIONI[s];
					a = a[AFEHLCGHAEE.IDLHJIOMJBK]; // data
					EDOHBJAPLPF_JsonData b = AAEDAEHIONI[s];
					b = b[AFEHLCGHAEE.KAPMOPMDHJE]; // label
					int label = (int)b;
					int idx = OHNJJIMGKGK_TypesStr.FindIndex((/*string*/ GHPLINIACBB) => {
						return ANFNAHPIJDH[cnt] == GHPLINIACBB;
					});
					if(-1 < idx)
					{
						if(MILGMGJNOJI((ANCJLICGOLP.CPJMLNDMMHJ)idx, a))
							cnt2++;
					}    
				}
			}
			cnt ++;
		} while(true);
	}

	// RVA: 0xD53558 Offset: 0xD53558 VA: 0xD53558
	private bool MILGMGJNOJI(ANCJLICGOLP.CPJMLNDMMHJ LKJJEMDAFBB, EDOHBJAPLPF_JsonData IMKIBKOICBF)
	{
		if(LKJJEMDAFBB == ANCJLICGOLP.CPJMLNDMMHJ.HDEONBGNOIO)
		{
			AHOHBHIPIHA(IMKIBKOICBF);
		}
		else if(LKJJEMDAFBB == ANCJLICGOLP.CPJMLNDMMHJ.HKFLDNJGGBB)
		{
			NEFHLEAEKLG(IMKIBKOICBF);
		}
		else
		{
			if(LKJJEMDAFBB != ANCJLICGOLP.CPJMLNDMMHJ.IKAHLMCKDDF)
				return false;
			IDOLIOLEKID(IMKIBKOICBF);
		}
		return true;
	}

	// RVA: 0xD535A8 Offset: 0xD535A8 VA: 0xD535A8
	private bool IDOLIOLEKID(EDOHBJAPLPF_JsonData IMKIBKOICBF) 
	{
		int OIPCCBHIKIA = 0;
		int size = IMKIBKOICBF.HNBFOAJIIAL_Count; // TODO
		if(size > 0)
		{
			do
			{
				EDOHBJAPLPF_JsonData a = IMKIBKOICBF[OIPCCBHIKIA];
				MFJONNINDCJ b = new MFJONNINDCJ();
				EDOHBJAPLPF_JsonData IDLHJIOMJBK = a["f"];
				string s = (string)IDLHJIOMJBK;
				b.MKANHLNEEGL = s;
				EDOHBJAPLPF_JsonData c = a["k"];
				int NANNGLGOFKH = (int)c;
				b.JBGEEPFKIGG = NANNGLGOFKH;
				JGJJIBPPEPD_List.Add(b);
				OIPCCBHIKIA++;
			} while(OIPCCBHIKIA != size);
		}
		return true;
	}

	// RVA: 0xD53798 Offset: 0xD53798 VA: 0xD53798
	private bool NEFHLEAEKLG(EDOHBJAPLPF_JsonData IMKIBKOICBF) 
	{ 
		int idx = 0;
		if(0 < IMKIBKOICBF.HNBFOAJIIAL_Count)
		{
			do
			{
				EDOHBJAPLPF_JsonData data = IMKIBKOICBF[idx];
				EDOHBJAPLPF_JsonData subData = data["v"];
				int val = (int)subData;
				CEBFFLDKAEC_SecureInt elem = new CEBFFLDKAEC_SecureInt();
				elem.DNJEJEANJGL_Value = val;
				subData = data["k"];
				string key = (string)subData;
				OHJFBLFELNK.Add(key, elem);
				idx++;
			} while(idx != IMKIBKOICBF.HNBFOAJIIAL_Count);
		}
		return true;
	}

	// RVA: 0xD5398C Offset: 0xD5398C VA: 0xD5398C
	private bool AHOHBHIPIHA(EDOHBJAPLPF_JsonData IMKIBKOICBF) 
	{
		int OIPCCBHIKIA = 0;
		int size = IMKIBKOICBF.HNBFOAJIIAL_Count;
		if(0 < size)
		{
			do
			{
				EDOHBJAPLPF_JsonData data = IMKIBKOICBF[OIPCCBHIKIA];
				JDEFIJBCJLC_EncryptedString elem = new JDEFIJBCJLC_EncryptedString();
				elem.DNJEJEANJGL_Value = (string)data["v"];
				FJOEBCMGDMI.Add((string)data["k"], elem);
				OIPCCBHIKIA++;
			} while(OIPCCBHIKIA != size);
		}
		return true;
	}

	// RVA: 0xD53B88 Offset: 0xD53B88 VA: 0xD53B88
	static ANCJLICGOLP()
	{
		OHNJJIMGKGK_TypesStr = new List<string>();
		OHNJJIMGKGK_TypesStr.Add("s_ak");
		OHNJJIMGKGK_TypesStr.Add("s_sys_int");
		OHNJJIMGKGK_TypesStr.Add("s_sys_str");
	}
}
