using System.Collections.Generic;
using UnityEngine;
using XeSys;

[System.Obsolete("Use JJOPEDJCCJK_Exp", true)]
public class JJOPEDJCCJK { }
public class JJOPEDJCCJK_Exp : DIHHCBACKGG_DbSection
{
    public class GDBAIHMLCBI_GetPExp
    {
        public int PPFNGGCBJKC_Id; // 0x8
        public int GJLFANGDGCL_Tgt; // 0xC
        public int KFJDNFCBBBL_CoefCrypted; // 0x10
        public int MNEDFIBOJAI_Key; // 0x14

        // public int DHIPGHBJLIL { get; } 0x135620C PEIEKKODNKE
    }

    public class GPLPAOGMPAM_Music
    {
        public int LKIFDCEKDCK_Exp; // 0x8
        public int HMFFHLPNMPH_Cnt; // 0xC
    }

	public const int JEMODFNIDIB = 100000;
	public const int NAJMGFDOCMH = 8;
	public const int MMPPNMHMEBF = 150;
	public const int KPKALPLCDIO = 300;
	public const int DCBJGIMHMMJ = 30;
	public const int GAGMAGDOELK = 25;
	private List<int> HLFGFGPCKNP_PExp; // 0x20
	private List<int> MLMGJJAGKDL_PExpKey; // 0x24
	private List<int> FKHFJAFKLPA_Stamina; // 0x28
	private List<int> ILJKACFDKHI_StaminaKey; // 0x2C
	private List<int> BKGEDIBAPPJ_Friend; // 0x30
	private List<int> LEKPPFJMFMH_FriendKey; // 0x34
	private List<int> HALPANEEGHO; // 0x38
	private List<int> OBGMHMBHKIH; // 0x3C
	private List<int> LMFNPINMOGK_Diva; // 0x40
	private List<int> JNIHDCMHINF_DivaKey; // 0x44
	private List<int> AOLNJDHGNGA_GetMExp_1; // 0x48
	private List<int> JIBLNGDIPIG_GetMExpKey_1; // 0x4C
	private List<int> FDDCBPLIHFG_GetMExp_2; // 0x50
	private List<int> ECAODIBMEDM_GetMExpKey_2; // 0x54
	private List<JJOPEDJCCJK_Exp.GDBAIHMLCBI_GetPExp> HBDIDGBMDIA_GetPExp; // 0x58

	public List<JJOPEDJCCJK_Exp.GPLPAOGMPAM_Music> GNIPHICJAIA_Music { get; private set; } // 0x5C LLBFAHJOJMG BNEEDCLHFHL LPFFJIGGHLG

	// // RVA: 0x13550F8 Offset: 0x13550F8 VA: 0x13550F8
	// public int ODKGLFCFJHJ() { }

	// // RVA: 0x1355170 Offset: 0x1355170 VA: 0x1355170
	// public int NDFGMMKGBAA(int CIEOBFIIPLD) { }

	// // RVA: 0x135526C Offset: 0x135526C VA: 0x135526C
	// public int DGPJNADIFNE(int CIEOBFIIPLD) { }

	// // RVA: 0x1355398 Offset: 0x1355398 VA: 0x1355398
	// public float ANADOECHNEO(float MEKJFFHMKOB, out int CIEOBFIIPLD) { }

	// // RVA: 0x1355510 Offset: 0x1355510 VA: 0x1355510
	// public int HPEOBAEGHKC(int CIEOBFIIPLD) { }

	// // RVA: 0x1355610 Offset: 0x1355610 VA: 0x1355610
	public int PCJACJANGCA(int CIEOBFIIPLD)
    {
		if(CIEOBFIIPLD > 0 && CIEOBFIIPLD <= BKGEDIBAPPJ_Friend.Count)
		{
			return BKGEDIBAPPJ_Friend[CIEOBFIIPLD - 1] ^ LEKPPFJMFMH_FriendKey[CIEOBFIIPLD - 1];
		}
        return 30;
    }

	// // RVA: 0x1355710 Offset: 0x1355710 VA: 0x1355710
	// public int DAFDPHFHANB(int CAHEFHMNBAH) { }

	// // RVA: 0x13557BC Offset: 0x13557BC VA: 0x13557BC
	public int IECLHMBPEIJ(int CIEOBFIIPLD)
	{
		if (CIEOBFIIPLD < 1)
			return 0;
		return GNIPHICJAIA_Music[Mathf.Clamp(CIEOBFIIPLD - 1, 0, GNIPHICJAIA_Music.Count - 1)].LKIFDCEKDCK_Exp;
	}

	// // RVA: 0x13558D8 Offset: 0x13558D8 VA: 0x13558D8
	// public int CMENIBIIKPJ(int CIEOBFIIPLD) { }

	// // RVA: 0x1355904 Offset: 0x1355904 VA: 0x1355904
	// public float BOLBEBNHJHG(float MEKJFFHMKOB, out int CIEOBFIIPLD) { }

	// // RVA: 0x1355A4C Offset: 0x1355A4C VA: 0x1355A4C
	// public int EMJCHPDJHEI(int LKIFDCEKDCK) { }

	// // RVA: 0x1355B30 Offset: 0x1355B30 VA: 0x1355B30
	// public float OLJFPKPHCJD(float MEKJFFHMKOB, out int CIEOBFIIPLD) { }

	// // RVA: 0x1355CB0 Offset: 0x1355CB0 VA: 0x1355CB0
	// public int IOCHHEEDIJD(int OLDOFEONEPD) { }

	// // RVA: 0x1355DCC Offset: 0x1355DCC VA: 0x1355DCC
	// public int NHEBLEFJNDO(int CIEOBFIIPLD) { }

	// // RVA: 0x1355EFC Offset: 0x1355EFC VA: 0x1355EFC
	// public int PHGMKDILOGE(int CIEOBFIIPLD) { }

	// // RVA: 0x1355FDC Offset: 0x1355FDC VA: 0x1355FDC
	// public int BIKLFCAKMPO() { }

	// // RVA: 0x1356058 Offset: 0x1356058 VA: 0x1356058
	// public int FIHFEGCDONI(int AKNELONELJK, int DCBDCHPKLCN, bool GIKLNODJKFK) { }

	// // RVA: 0x1356168 Offset: 0x1356168 VA: 0x1356168
	// public int FAANKGOFNGE(int BPLOEAHOPFI) { }

	// RVA: 0x135621C Offset: 0x135621C VA: 0x135621C
	public JJOPEDJCCJK_Exp()
    {
        JIKKNHIAEKG_BlockName = "";
        LNIMEIMBCMF = false;
        HLFGFGPCKNP_PExp = new List<int>(300);
        FKHFJAFKLPA_Stamina = new List<int>(300);
        BKGEDIBAPPJ_Friend = new List<int>(300);
        LMFNPINMOGK_Diva = new List<int>(150);
        MLMGJJAGKDL_PExpKey = new List<int>(300);
        ILJKACFDKHI_StaminaKey = new List<int>(300);
        LEKPPFJMFMH_FriendKey = new List<int>(300);
        JNIHDCMHINF_DivaKey = new List<int>(150);
        GNIPHICJAIA_Music = new List<JJOPEDJCCJK_Exp.GPLPAOGMPAM_Music>(8);
        AOLNJDHGNGA_GetMExp_1 = new List<int>(25);
        JIBLNGDIPIG_GetMExpKey_1 = new List<int>(25);
        FDDCBPLIHFG_GetMExp_2 = new List<int>(25);
        ECAODIBMEDM_GetMExpKey_2 = new List<int>(25);
        HBDIDGBMDIA_GetPExp = new List<JJOPEDJCCJK_Exp.GDBAIHMLCBI_GetPExp>();
        LMHMIIKCGPE = 46;
    }

	// // RVA: 0x13564B4 Offset: 0x13564B4 VA: 0x13564B4 Slot: 8
	protected override void KMBPACJNEOF()
    {
		HLFGFGPCKNP_PExp.Clear();
		FKHFJAFKLPA_Stamina.Clear();
		BKGEDIBAPPJ_Friend.Clear();
		LMFNPINMOGK_Diva.Clear();
		MLMGJJAGKDL_PExpKey.Clear();
		ILJKACFDKHI_StaminaKey.Clear();
		LEKPPFJMFMH_FriendKey.Clear();
		JNIHDCMHINF_DivaKey.Clear();
		GNIPHICJAIA_Music.Clear();
		AOLNJDHGNGA_GetMExp_1.Clear();
		JIBLNGDIPIG_GetMExpKey_1.Clear();
		FDDCBPLIHFG_GetMExp_2.Clear();
		ECAODIBMEDM_GetMExpKey_2.Clear();
		HBDIDGBMDIA_GetPExp.Clear();
    }

	// // RVA: 0x1356768 Offset: 0x1356768 VA: 0x1356768 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
    {
		PCFOIOGMHHL parser = PCFOIOGMHHL.HEGEKFMJNCC(DBBGALAPFGC);
		int key = (int)(Utility.GetCurrentUnixTime() ^ 0x4a6d3f);
		{
			uint[] array = parser.FJAJPKBEPPG;
			for(int i = 0; i < array.Length; i++)
			{
				MLMGJJAGKDL_PExpKey.Add(key);
				HLFGFGPCKNP_PExp.Add((int)array[i] ^ key);
				key *= 0xb0c021;
			}
		}
		{
			uint[] array = parser.BPLOEAHOPFI;
			for (int i = 0; i < array.Length; i++)
			{
				ILJKACFDKHI_StaminaKey.Add(key);
				FKHFJAFKLPA_Stamina.Add((int)array[i] ^ key);
				key *= 0x3b26c7;
			}
		}
		{
			uint[] array = parser.JPFFIBCDCNJ;
			for (int i = 0; i < array.Length; i++)
			{
				LEKPPFJMFMH_FriendKey.Add(key);
				BKGEDIBAPPJ_Friend.Add((int)array[i] ^ key);
				key *= 0x1af049;
			}
		}
		{
			CMEPJFBDNPP[] array = parser.MDFFJJKBDFC;
			for (int i = 0; i < array.Length; i++)
			{
				GPLPAOGMPAM_Music data = new GPLPAOGMPAM_Music();
				data.LKIFDCEKDCK_Exp = array[i].LKIFDCEKDCK;
				data.HMFFHLPNMPH_Cnt = array[i].BFINGCJHOHI;
				GNIPHICJAIA_Music.Add(data);
			}
		}
		{
			uint[] array = parser.FDBOPFEOENF;
			for (int i = 0; i < array.Length; i++)
			{
				JNIHDCMHINF_DivaKey.Add(key);
				LMFNPINMOGK_Diva.Add((int)array[i] ^ key);
				key *= 0xd8695;
			}
		}
		{
			uint[] array = parser.KJEJPGIHAEK;
			for (int i = 0; i < array.Length; i++)
			{
				if (i < array.Length / 2)
				{
					JIBLNGDIPIG_GetMExpKey_1.Add(key);
					AOLNJDHGNGA_GetMExp_1.Add((int)array[i] ^ key);
				}
				else
				{
					ECAODIBMEDM_GetMExpKey_2.Add(key);
					FDDCBPLIHFG_GetMExp_2.Add((int)array[i] ^ key);
				}
				key = key * 0xd + 7;
			}
		}
		{
			EJLDLIODAID[] array = parser.OGGLMPCHEDD;
			for (int i = 0; i < array.Length; i++)
			{
				GDBAIHMLCBI_GetPExp data = new GDBAIHMLCBI_GetPExp();
				data.PPFNGGCBJKC_Id = (int)array[i].PPFNGGCBJKC;
				data.GJLFANGDGCL_Tgt = (int)array[i].AGNHPHEJKMK;
				data.MNEDFIBOJAI_Key = key;
				data.KFJDNFCBBBL_CoefCrypted = (int)array[i].DHIPGHBJLIL ^ key;
				HBDIDGBMDIA_GetPExp.Add(data);
			}
		}
        return true;
    }

	// // RVA: 0x1357044 Offset: 0x1357044 VA: 0x1357044 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
    {
        TodoLogger.Log(100, "Exp Json IIEMACPEEBJ");
        return true;
    }

	// // RVA: 0x1357E44 Offset: 0x1357E44 VA: 0x1357E44 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(100, "Exp CAOGDCBPBAN");
		return 0;
	}
}
