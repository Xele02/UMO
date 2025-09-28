
using UnityEngine;

public class MIDMMFMJFPJ
{
	public const int DKIBAEABOCL = 99999999;
	public int FBGGEFFJJHB_xor; // 0x8
	public string OCGFKMHNEOF_name_for_api; // 0xC
	public long EGBOHDFBAPB_closed_at; // 0x10
	private int OHMGPDPKGLF_ValueCrypted; // 0x18
	private int PKDOICIGHDM_Crypted; // 0x1C
	private sbyte BBOONOFIBIA_Crypted; // 0x20

	public int NANNGLGOFKH_value { get { return OHMGPDPKGLF_ValueCrypted ^ FBGGEFFJJHB_xor; } set { value = Mathf.Clamp(value, 0, 100000000); OHMGPDPKGLF_ValueCrypted = value ^ FBGGEFFJJHB_xor; PKDOICIGHDM_Crypted = value; } } //0x19553DC EDFAHCMGHKM 0x19553EC BKPDFNKGNHA
	public bool CKFKFHKHOHA_RRcv { get { return BBOONOFIBIA_Crypted == 113; } set { BBOONOFIBIA_Crypted = (sbyte)(value ? 113 : 50); } } //0x1955490 EPJGLLALNMI 0x19554A4 AEOKPBOJABO

	// // RVA: 0x19554D4 Offset: 0x19554D4 VA: 0x19554D4
	public void LHPDDGIJKNB_Reset(int KNEFBLHBDBG)
    {
        FBGGEFFJJHB_xor = KNEFBLHBDBG;
		OCGFKMHNEOF_name_for_api = "";
        NANNGLGOFKH_value = 0;
        EGBOHDFBAPB_closed_at = 0;
        CKFKFHKHOHA_RRcv = false;
    }

	// // RVA: 0x195556C Offset: 0x195556C VA: 0x195556C
	public bool AGBOGBEOFME(MIDMMFMJFPJ OIKJFMGEICL)
	{
		if(OCGFKMHNEOF_name_for_api != OIKJFMGEICL.OCGFKMHNEOF_name_for_api)
			return false;
		if(EGBOHDFBAPB_closed_at != OIKJFMGEICL.EGBOHDFBAPB_closed_at)
			return false;
		if(NANNGLGOFKH_value != OIKJFMGEICL.NANNGLGOFKH_value)
			return false;
		if(CKFKFHKHOHA_RRcv != OIKJFMGEICL.CKFKFHKHOHA_RRcv)
			return false;
		return true;
	}

	// // RVA: 0x1955668 Offset: 0x1955668 VA: 0x1955668
	public void ODDIHGPONFL_Copy(MIDMMFMJFPJ OIKJFMGEICL)
	{
		OCGFKMHNEOF_name_for_api = OIKJFMGEICL.OCGFKMHNEOF_name_for_api;
		EGBOHDFBAPB_closed_at = OIKJFMGEICL.EGBOHDFBAPB_closed_at;
		NANNGLGOFKH_value = OIKJFMGEICL.NANNGLGOFKH_value;
		CKFKFHKHOHA_RRcv = OIKJFMGEICL.CKFKFHKHOHA_RRcv;
	}

	// // RVA: 0x195570C Offset: 0x195570C VA: 0x195570C
	// public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string _JIKKNHIAEKG_BlockName, string MJBACHKCIHA, int _OIPCCBHIKIA_index, MIDMMFMJFPJ _OHMCIEMIKCE_t, bool EFOEPDLNLJG) { }

	// // RVA: 0x1956194 Offset: 0x1956194 VA: 0x1956194
	public EDOHBJAPLPF_JsonData NOJCMGAFAAC_ToJsonData()
	{
		EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
		res[AFEHLCGHAEE_Strings.LJNAKDMILMC_key] = OCGFKMHNEOF_name_for_api;
		res[AFEHLCGHAEE_Strings.KOMKKBDABJP_end] = EGBOHDFBAPB_closed_at;
		res[AFEHLCGHAEE_Strings.JBGEEPFKIGG_val] = NANNGLGOFKH_value;
		res[AFEHLCGHAEE_Strings.LDALACBKEJN_r_rcv] = CKFKFHKHOHA_RRcv ? 1 : 0;
		return res;
	}
}
