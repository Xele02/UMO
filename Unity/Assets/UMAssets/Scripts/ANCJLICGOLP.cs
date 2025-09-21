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

	private Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK_IntArray; // 0x8
	private Dictionary<string, JDEFIJBCJLC_EncryptedString> FJOEBCMGDMI_String; // 0xC
	public List<MFJONNINDCJ> JGJJIBPPEPD_List; // 0x10
	private static List<string> OHNJJIMGKGK_Names; // 0x0

	// RVA: 0xD52C1C Offset: 0xD52C1C VA: 0xD52C1C
	public int LPJLEHAJADA(string _LJNAKDMILMC_key, int KKMJBMKHGNH)
	{
		if(!OHJFBLFELNK_IntArray.ContainsKey(_LJNAKDMILMC_key))
		{
			return KKMJBMKHGNH;
		}
		return OHJFBLFELNK_IntArray[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
	}

	// RVA: 0xD52D00 Offset: 0xD52D00 VA: 0xD52D00
	//public string EFEGBHACJAL(string _LJNAKDMILMC_key, string KKMJBMKHGNH) { }

	// RVA: 0xD52DE4 Offset: 0xD52DE4 VA: 0xD52DE4
	public List<string> ELJGLMPOINC_GetTypesStr()
	{
		return OHNJJIMGKGK_Names;
	}

	public void KHEKNNFCAOI_Init()
	{
		OHJFBLFELNK_IntArray = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		FJOEBCMGDMI_String = new Dictionary<string, JDEFIJBCJLC_EncryptedString>();
		JGJJIBPPEPD_List = new List<MFJONNINDCJ>();
	}

	// RVA: 0xD52F58 Offset: 0xD52F58 VA: 0xD52F58
	public bool IIEMACPEEBJ_Deserialize(List<string> _ANFNAHPIJDH_BlockNames, EDOHBJAPLPF_JsonData AAEDAEHIONI)
	{
		int cnt = 0;    // var7
		int cnt2 = 0;  // var9
		do
		{
			int size = _ANFNAHPIJDH_BlockNames.Count;
			if(size <= cnt)
			{
				size = OHNJJIMGKGK_Names.Count;
				return size == cnt2;
			}
			if(AAEDAEHIONI != null)
			{
				string s = _ANFNAHPIJDH_BlockNames[cnt];
				bool r = AAEDAEHIONI.BBAJPINMOEP_Contains(s);
				if(r)
				{
					EDOHBJAPLPF_JsonData a = AAEDAEHIONI[s];
					a = a[AFEHLCGHAEE_Strings.IDLHJIOMJBK_Data]; // data
					EDOHBJAPLPF_JsonData b = AAEDAEHIONI[s];
					b = b[AFEHLCGHAEE_Strings.KAPMOPMDHJE_label]; // label
					int label = (int)b;
					int idx = OHNJJIMGKGK_Names.FindIndex((/*string*/ _GHPLINIACBB_x) => {
						return _ANFNAHPIJDH_BlockNames[cnt] == _GHPLINIACBB_x;
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
		int OIPCCBHIKIA_index = 0;
		int size = IMKIBKOICBF.HNBFOAJIIAL_Count; // TODO
		if(size > 0)
		{
			do
			{
				EDOHBJAPLPF_JsonData a = IMKIBKOICBF[OIPCCBHIKIA_index];
				MFJONNINDCJ b = new MFJONNINDCJ();
				EDOHBJAPLPF_JsonData IDLHJIOMJBK_Data = a["f"];
				string s = (string)IDLHJIOMJBK_Data;
				b.MKANHLNEEGL_filter = s;
				EDOHBJAPLPF_JsonData c = a["k"];
				int NANNGLGOFKH_value = (int)c;
				b.JBGEEPFKIGG_val = NANNGLGOFKH_value;
				JGJJIBPPEPD_List.Add(b);
				OIPCCBHIKIA_index++;
			} while(OIPCCBHIKIA_index != size);
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
				OHJFBLFELNK_IntArray.Add(key, elem);
				idx++;
			} while(idx != IMKIBKOICBF.HNBFOAJIIAL_Count);
		}
		return true;
	}

	// RVA: 0xD5398C Offset: 0xD5398C VA: 0xD5398C
	private bool AHOHBHIPIHA(EDOHBJAPLPF_JsonData IMKIBKOICBF) 
	{
		int OIPCCBHIKIA_index = 0;
		int size = IMKIBKOICBF.HNBFOAJIIAL_Count;
		if(0 < size)
		{
			do
			{
				EDOHBJAPLPF_JsonData data = IMKIBKOICBF[OIPCCBHIKIA_index];
				JDEFIJBCJLC_EncryptedString elem = new JDEFIJBCJLC_EncryptedString();
				elem.DNJEJEANJGL_Value = (string)data["v"];
				FJOEBCMGDMI_String.Add((string)data["k"], elem);
				OIPCCBHIKIA_index++;
			} while(OIPCCBHIKIA_index != size);
		}
		return true;
	}

	// RVA: 0xD53B88 Offset: 0xD53B88 VA: 0xD53B88
	static ANCJLICGOLP()
	{
		OHNJJIMGKGK_Names = new List<string>();
		OHNJJIMGKGK_Names.Add("s_ak");
		OHNJJIMGKGK_Names.Add("s_sys_int");
		OHNJJIMGKGK_Names.Add("s_sys_str");
	}
}
