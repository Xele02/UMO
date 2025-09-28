
using System.Collections.Generic;
using XeApp.Game.Common;

[System.Obsolete("Use ALJHJDHNFFB_HomeBg", true)]
public class ALJHJDHNFFB { }
public class ALJHJDHNFFB_HomeBg : DIHHCBACKGG_DbSection
{
	public class ADLLAFIDFAM
	{
		public int EHOIENNDEDH_IdCrypted; // 0x8
		public int NOFECLGOLAI_TypeCrypted; // 0xC
		public int BMMPCNHLGOA; // 0x10
		public int HKCDOJFHMFC; // 0x14
		public long PCLNFCNIECH_OpenAtCrypted; // 0x18
		public long HHPIJHADAOB_CloseAtCrypted; // 0x20
		public int HNJHPNPFAAN_EnabledCrypted; // 0x28
		public int GNGNIKNNCNH_MVerCrypted; // 0x2C
		public int NJPJGPGNAOG; // 0x30
		public NNJFKLBPBNK_SecureString FINCFIGKHPA_Name = new NNJFKLBPBNK_SecureString(); // 0x38

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0xCDF86C DEMEPMAEJOO 0xCDE414 HIGKAIDMOKN
		// Type
		public int GBJFNGCDKPM_typ { get { return NOFECLGOLAI_TypeCrypted ^ FBGGEFFJJHB_xor; } set { NOFECLGOLAI_TypeCrypted = value ^ FBGGEFFJJHB_xor; } } //0xCDF970 CEJJMKODOGK 0xCDE4B0 HOHCEBMMACI
		public int OENPCNBFPDA_bg_id { get { return BMMPCNHLGOA ^ FBGGEFFJJHB_xor; } set { BMMPCNHLGOA = value ^ FBGGEFFJJHB_xor; } } //0xCDFA08 BNLALNCFJPB 0xCDE54C KPJBLJCKBLF
		public int KFNDHKFLPPK_mus_id { get { return HKCDOJFHMFC ^ FBGGEFFJJHB_xor; } set { HKCDOJFHMFC = value ^ FBGGEFFJJHB_xor; } } //0xCDFAA0 CCPAPHPPGOB 0xCDE5E8 ICBGFBNICOE
		public long PDBPFJJCADD_open_at { get { return PCLNFCNIECH_OpenAtCrypted ^ FBGGEFFJJHB_xor; } set { PCLNFCNIECH_OpenAtCrypted = value ^ FBGGEFFJJHB_xor; } } //0xCDF69C FOACOMBHPAC 0xCDE684 NBACOBCOJCA
		public long FDBNFFNFOND_close_at { get { return HHPIJHADAOB_CloseAtCrypted ^ FBGGEFFJJHB_xor; } set { HHPIJHADAOB_CloseAtCrypted = value ^ FBGGEFFJJHB_xor; } } //0xCDF7D0 BPJOGHJCLDJ 0xCDE728 NLJKMCHOCBK
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0xCDF738 JPCJNLHHIPE 0xCDE7CC JJFJNEJLBDG
		public int IJEKNCDIIAE_mver { get { return GNGNIKNNCNH_MVerCrypted ^ FBGGEFFJJHB_xor; } set { GNGNIKNNCNH_MVerCrypted = value ^ FBGGEFFJJHB_xor; } } //0xCDFB38 KJIMMIBDCIL 0xCDE868 DMEGNOKIKCD
		public string OPFGFINHFCE_name { get { return FINCFIGKHPA_Name.DNJEJEANJGL_Value; } set { FINCFIGKHPA_Name.DNJEJEANJGL_Value = value; } } //0xCDFBD0 DKJOHDGOIJE 0xCDE9A8 MJAMIGECMMF
		public int LEJOJFHKHIJ_Have { get { return GNGNIKNNCNH_MVerCrypted ^ FBGGEFFJJHB_xor; } set { GNGNIKNNCNH_MVerCrypted = value ^ FBGGEFFJJHB_xor; } } //0xCDFBFC PGCOGCIHNGG 0xCDE904 PJDCNPKFOBE
		public SeriesAttr.Type AIHCEGFANAM_SerieAttr { get; set; } // 0x34 FJOGAAMLJMA ANEJPLENMAL HEHDOGFEIOL

		//// RVA: 0xCDF06C Offset: 0xCDF06C VA: 0xCDF06C
		//public uint CAOGDCBPBAN() { }
	}

	public static int FBGGEFFJJHB_xor = 0x609d5; // 0x0
	public const int GHGNOHPLBPF = 100;
	public List<ADLLAFIDFAM> CDENCMNHNGA_table = new List<ADLLAFIDFAM>(); // 0x20

	// RVA: 0xCDDD80 Offset: 0xCDDD80 VA: 0xCDDD80
	public ALJHJDHNFFB_HomeBg()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 53;
	}

	//// RVA: 0xCDDE74 Offset: 0xCDDE74 VA: 0xCDDE74
	public ADLLAFIDFAM GCINIJEMHFK_Get(int _PPFNGGCBJKC_id)
	{
		if (_PPFNGGCBJKC_id != 0)
		{
			if (_PPFNGGCBJKC_id <= CDENCMNHNGA_table.Count)
			{
				return CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1];
			}
		}
		return null;
	}

	// RVA: 0xCDDF3C Offset: 0xCDDF3C VA: 0xCDDF3C Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		CDENCMNHNGA_table.Clear();
	}

	// RVA: 0xCDDFB4 Offset: 0xCDDFB4 VA: 0xCDDFB4 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		LEGLJNFOBGN parser = LEGLJNFOBGN.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		BEHPCLGJNDE[] array = parser.AFNCMAJBLGO;
		for(int i = 0; i < array.Length; i++)
		{
			ADLLAFIDFAM data = new ADLLAFIDFAM();
			data.PPFNGGCBJKC_id = (int)array[i].PPFNGGCBJKC_id;
			data.GBJFNGCDKPM_typ = (int)array[i].GBJFNGCDKPM_typ;
			data.OENPCNBFPDA_bg_id = array[i].OENPCNBFPDA_bg_id;
			data.KFNDHKFLPPK_mus_id = array[i].KFNDHKFLPPK_mus_id;
			data.PDBPFJJCADD_open_at = array[i].PDBPFJJCADD_open_at;
			data.FDBNFFNFOND_close_at = array[i].FDBNFFNFOND_close_at;
			data.PLALNIIBLOF_en = (int)array[i].PLALNIIBLOF_en;
			data.IJEKNCDIIAE_mver = array[i].IJEKNCDIIAE_mver;
			data.LEJOJFHKHIJ_Have = array[i].LEJOJFHKHIJ_Have;
			data.AIHCEGFANAM_SerieAttr = (SeriesAttr.Type)array[i].JPFMJHLCMJL_sa;
			data.OPFGFINHFCE_name = DatabaseTextConverter.TranslateHomeBgName(i, array[i].OPFGFINHFCE_name);

			if(RuntimeSettings.CurrentSettings.RemoveHomeBgDateLimit)
			{
				data.FDBNFFNFOND_close_at = 0;
				data.PDBPFJJCADD_open_at = 0;
			}

			CDENCMNHNGA_table.Add(data);
		}
		return true;
	}

	// RVA: 0xCDE9DC Offset: 0xCDE9DC VA: 0xCDE9DC Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		//CDENCMNHNGA_table = home_bg
		//	PPFNGGCBJKC_id = PPFNGGCBJKC_id
		//	GBJFNGCDKPM_typ = GBJFNGCDKPM_typ
		//	OENPCNBFPDA_bg_id = OENPCNBFPDA_bg_id
		//	KFNDHKFLPPK_mus_id = KFNDHKFLPPK_mus_id
		//	PDBPFJJCADD_open_at = PDBPFJJCADD_open_at
		//	FDBNFFNFOND_close_at = FDBNFFNFOND_close_at
		//	PLALNIIBLOF_en = PLALNIIBLOF_en
		//	IJEKNCDIIAE_mver = IJEKNCDIIAE_mver
		//	LEJOJFHKHIJ_Have = CPGFPEDMDEH_have
		//	AIHCEGFANAM_SerieAttr = JPFMJHLCMJL_sa
		//	OPFGFINHFCE_name = OPFGFINHFCE_name
		TodoLogger.LogError(TodoLogger.DbJson, "ALJHJDHNFFB_HomeBg");
		return true;
	}

	// RVA: 0xCDEF88 Offset: 0xCDEF88 VA: 0xCDEF88 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "ALJHJDHNFFB_HomeBg.CAOGDCBPBAN");
		return 0;
	}

	//// RVA: 0xCDF0F0 Offset: 0xCDF0F0 VA: 0xCDF0F0
	public ADLLAFIDFAM NLPKHJDEDPI(int _PPFNGGCBJKC_id)
	{
		if(_PPFNGGCBJKC_id > 0)
		{
			if (_PPFNGGCBJKC_id - 1 < CDENCMNHNGA_table.Count)
			{
				return CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1];
			}
		}
		return null;
	}

	//// RVA: 0xCDF1BC Offset: 0xCDF1BC VA: 0xCDF1BC
	private bool OFKCGMNFGKB_IsTimeValid(long _KJBGCLPMLCG_OpenedAt, long _GJFPFFBAKGK_CloseAt, long _JHNMKKNEENE_Time/* = -1*/)
	{
		if(_JHNMKKNEENE_Time < 0)
			_JHNMKKNEENE_Time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		return _JHNMKKNEENE_Time >= _KJBGCLPMLCG_OpenedAt && _GJFPFFBAKGK_CloseAt >= _JHNMKKNEENE_Time;
	}

	//// RVA: 0xCDF2E8 Offset: 0xCDF2E8 VA: 0xCDF2E8
	public List<int> NIJNOFHBKEB_GetAvaiableBgs()
	{
		List<int> res = new List<int>();
		res.Clear();
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		for(int i = 0; i < CDENCMNHNGA_table.Count; i++)
		{
			if(CDENCMNHNGA_table[i].PDBPFJJCADD_open_at != 0)
			{
				if(CDENCMNHNGA_table[i].PLALNIIBLOF_en == 2)
				{
					if(OFKCGMNFGKB_IsTimeValid(CDENCMNHNGA_table[i].PDBPFJJCADD_open_at, CDENCMNHNGA_table[i].FDBNFFNFOND_close_at, time))
					{
						res.Add(CDENCMNHNGA_table[i].PPFNGGCBJKC_id);
					}
				}
			}
		}
		return res;
	}
}
