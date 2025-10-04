using System.Collections.Generic;

[System.Obsolete("Use GJALOMELEHD_Intimacy", true)]
public class GJALOMELEHD { }
public class GJALOMELEHD_Intimacy : DIHHCBACKGG_DbSection
{
	public class ELAIMNHBCFB
	{
		public int EHOIENNDEDH_IdCrypted; // 0x8
		public int ICKOHEDLEFP_ValueCrypted; // 0xC
		public int BOIPMPBGLDE_Crypted; // 0x10
		public int AHGCGHAAHOO_ItemIdCrypted; // 0x14
		public int MMIIEJCNHOF_Crypted; // 0x18
		public int HNJHPNPFAAN_EnabledCrypted; // 0x1C

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0xAAADE4 DEMEPMAEJOO_get_id 0xAA9C0C HIGKAIDMOKN_set_id
		public int JBGEEPFKIGG_val { get { return ICKOHEDLEFP_ValueCrypted ^ FBGGEFFJJHB_xor; } set { ICKOHEDLEFP_ValueCrypted = value ^ FBGGEFFJJHB_xor; } } //0xAAAE7C OLOCMINKGON_get_val 0xAA9CA8 ABAFHIBFKCE_set_val
		public int JONPKLHMOBL_Category { get { return BOIPMPBGLDE_Crypted ^ FBGGEFFJJHB_xor; } set { BOIPMPBGLDE_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAAF14 LDDGKJEDMED_get_Category 0xAA9D44 BEBCJJGHFDO_set_Category
		public int GLCLFMGPMAN_ItemId { get { return AHGCGHAAHOO_ItemIdCrypted ^ FBGGEFFJJHB_xor; } set { AHGCGHAAHOO_ItemIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0xAAAFAC LNJAENEGDEL_get_ItemId 0xAA9DE0 JHIDBGCHOKL_set_ItemId
		public int JKFLOJNPLIJ { get { return MMIIEJCNHOF_Crypted ^ FBGGEFFJJHB_xor; } set { MMIIEJCNHOF_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAB044 ABIHJLDHFEG_bgs 0xAA9E7C HPKIFMODCED_bgs
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0xAAB0DC JPCJNLHHIPE_get_en 0xAA9F18 JJFJNEJLBDG_set_en

		// RVA: 0xAAA794 Offset: 0xAAA794 VA: 0xAAA794
		// public uint CAOGDCBPBAN() { }
	}

	public class MFMLEAMJJCH_LevelInfo
	{
		public int MBCPMFPKNBA_LevelCrypted; // 0x8
		public int DFNMDAAICGH_Crypted; // 0xC
		public int JKJDDGGNEAB_TotalCrypted; // 0x10
		public int HNNLOMMFHEN_catCrypted; // 0x14
		public int BNDKLGDMGAM_Crypted; // 0x18
		public int[] DGBAEDJPAMA = new int[10]; // 0x1C

		//Level
		public int ANAJIAENLNB_lv { get { return MBCPMFPKNBA_LevelCrypted ^ FBGGEFFJJHB_xor; } set { MBCPMFPKNBA_LevelCrypted = value ^ FBGGEFFJJHB_xor; } } //0xAAB174 MMOMNMBKHJF_get_lv 0xAAA028 FEHNFGPFINK_set_lv
		public int IHGDLBBPKFI_Next { get { return DFNMDAAICGH_Crypted ^ FBGGEFFJJHB_xor; } set { DFNMDAAICGH_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAB20C ONOBDELIEFB_get_Next 0xAAA0C4 MKNICENPJBP_set_Next
		public int BDLNMOIOMHK_total { get { return JKJDDGGNEAB_TotalCrypted ^ FBGGEFFJJHB_xor; } set { JKJDDGGNEAB_TotalCrypted = value ^ FBGGEFFJJHB_xor; } } //0xAAABB0 MKMAKAEDMBG_get_total 0xAAA160 GIJPLHEDIKD_set_total
		public int DMEDKJPOLCH_cat { get { return HNNLOMMFHEN_catCrypted ^ FBGGEFFJJHB_xor; } set { HNNLOMMFHEN_catCrypted = value ^ FBGGEFFJJHB_xor; } } //0xAAB2A4 IPKCKAAEEOE_get_cat 0xAAA1FC JOGLLINFLJN_set_cat
		// SkillLEvel
		public int EIIDPKCBKEK_prm { get { return BNDKLGDMGAM_Crypted ^ FBGGEFFJJHB_xor; } set { BNDKLGDMGAM_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAB33C GNOMKOGNGAD_get_prm 0xAAA298 LIAJMHMKLLM_set_prm

		// // RVA: 0xAAB3D4 Offset: 0xAAB3D4 VA: 0xAAB3D4
		public int ECEKNKIDING(int _IOPHIHFOOEP_idx)
		{
			if (DGBAEDJPAMA.Length <= _IOPHIHFOOEP_idx)
				return 0;
			return DGBAEDJPAMA[_IOPHIHFOOEP_idx] ^ FBGGEFFJJHB_xor;
		}

		// // RVA: 0xAAA334 Offset: 0xAAA334 VA: 0xAAA334
		public void KNAMKOLCIAC(int _IOPHIHFOOEP_idx, int _JBGEEPFKIGG_val)
		{
			if (_IOPHIHFOOEP_idx >= DGBAEDJPAMA.Length)
				return;
			DGBAEDJPAMA[_IOPHIHFOOEP_idx] = _JBGEEPFKIGG_val ^ FBGGEFFJJHB_xor;
		}

		// // RVA: 0xAAA7F0 Offset: 0xAAA7F0 VA: 0xAAA7F0
		// public uint CAOGDCBPBAN() { }
	}

	public class AHIGPDEDCFO
	{
		public int EHOIENNDEDH_IdCrypted; // 0x8
		public int ICKOHEDLEFP_ValueCrypted; // 0xC

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0xAAACB4 DEMEPMAEJOO_get_id 0xAAA430 HIGKAIDMOKN_set_id
		public int JBGEEPFKIGG_val { get { return ICKOHEDLEFP_ValueCrypted ^ FBGGEFFJJHB_xor; } set { ICKOHEDLEFP_ValueCrypted = value ^ FBGGEFFJJHB_xor; } } //0xAAAD4C OLOCMINKGON_get_val 0xAAA4CC ABAFHIBFKCE_set_val

		// // RVA: 0xAAA880 Offset: 0xAAA880 VA: 0xAAA880
		// public uint CAOGDCBPBAN() { }
	}

	public const int PEJGHAJJDIG = 40;
	public const int LBBLNLCFIOH = 10;
	public static int FBGGEFFJJHB_xor = 0x4341b; // 0x0
	public List<ELAIMNHBCFB> CJAEGOMDICD = new List<ELAIMNHBCFB>(28); // 0x20
	public List<MFMLEAMJJCH_LevelInfo> OOCKOCAACMD_DataByLevel = new List<MFMLEAMJJCH_LevelInfo>(); // 0x24
	public List<AHIGPDEDCFO> COHLJLNLBKM = new List<AHIGPDEDCFO>(); // 0x28

	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK_m_intParam { get; private set; } // 0x2C KLDCHOIPJGB AEMNOGNEBOJ_get_m_intParam DGKDBOAMNBB_set_m_intParam
	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI_m_stringParam { get; private set; } // 0x30 IHKPIFIBECO GAMGELHIHHI_get_m_stringParam DDDEJIJGGBJ_set_m_stringParam

	// // RVA: 0xAA8CAC Offset: 0xAA8CAC VA: 0xAA8CAC
	// public string EFEGBHACJAL_GetStringParam(string _LJNAKDMILMC_key, string _KKMJBMKHGNH_noval) { }

	// // RVA: 0xAA8D90 Offset: 0xAA8D90 VA: 0xAA8D90
	public int LPJLEHAJADA_GetIntParam(string _LJNAKDMILMC_key, int _KKMJBMKHGNH_noval)
    {
		if (!OHJFBLFELNK_m_intParam.ContainsKey(_LJNAKDMILMC_key))
			return _KKMJBMKHGNH_noval;
		return OHJFBLFELNK_m_intParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
	}

	// // RVA: 0xAA8E74 Offset: 0xAA8E74 VA: 0xAA8E74
	public GJALOMELEHD_Intimacy()
    {
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		OHJFBLFELNK_m_intParam = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		LMHMIIKCGPE = 56;
		FJOEBCMGDMI_m_stringParam = new Dictionary<string, NNJFKLBPBNK_SecureString>();
    }

	// // RVA: 0xAA903C Offset: 0xAA903C VA: 0xAA903C Slot: 8
	protected override void KMBPACJNEOF_Reset()
    {
		CJAEGOMDICD.Clear();
		OOCKOCAACMD_DataByLevel.Clear();
		COHLJLNLBKM.Clear();
		OHJFBLFELNK_m_intParam.Clear();
		FJOEBCMGDMI_m_stringParam.Clear();
    }

	// // RVA: 0xAA9164 Offset: 0xAA9164 VA: 0xAA9164 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
    {
		AMBAEMHAMDB parser = AMBAEMHAMDB.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		NNEBKOJADBA(parser);
		CGFCKHEGOJN(parser);
		KOPMKAKPJOO(parser);
		{
			AGPHLNAPAKA[] array = parser.BHGDNGHDDAC;
			for(int i = 0; i < array.Length; i++)
			{
				CEBFFLDKAEC_SecureInt data = new CEBFFLDKAEC_SecureInt();
				data.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG_val;
				OHJFBLFELNK_m_intParam.Add(array[i].LJNAKDMILMC_key, data);
			}
		}
		{
			CMNIIDMIIHI[] array = parser.MHGMDJNOLMI;
			for (int i = 0; i < array.Length; i++)
			{
				NNJFKLBPBNK_SecureString data = new NNJFKLBPBNK_SecureString();
				data.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG_val;
				FJOEBCMGDMI_m_stringParam.Add(array[i].LJNAKDMILMC_key, data);
			}
		}
        return true;
    }

	// // RVA: 0xAA9450 Offset: 0xAA9450 VA: 0xAA9450
	public bool NNEBKOJADBA(AMBAEMHAMDB GGKAPJELKOA)
	{
		IFHOHAKPGJH[] array = GGKAPJELKOA.IINOBJKJGFK;
		for(int i = 0; i < array.Length; i++)
		{
			ELAIMNHBCFB data = new ELAIMNHBCFB();
			data.PPFNGGCBJKC_id = (int)array[i].PPFNGGCBJKC_id;
			data.JBGEEPFKIGG_val = (int)array[i].JBGEEPFKIGG_val;
			data.JONPKLHMOBL_Category = (int)array[i].DMEDKJPOLCH_cat;
			data.GLCLFMGPMAN_ItemId = (int)array[i].GLCLFMGPMAN_ItemId;
			data.JKFLOJNPLIJ = (int)array[i].HHDGLPENPFI;
			data.PLALNIIBLOF_en = (int)array[i].PLALNIIBLOF_en;
			CJAEGOMDICD.Add(data);
		}
		return true;
	}

	// // RVA: 0xAA9710 Offset: 0xAA9710 VA: 0xAA9710
	public bool CGFCKHEGOJN(AMBAEMHAMDB GGKAPJELKOA)
	{
		EMLAKILKONB[] array = GGKAPJELKOA.PMICJEAOFMA;
		for (int i = 0; i < array.Length; i++)
		{
			MFMLEAMJJCH_LevelInfo data = new MFMLEAMJJCH_LevelInfo();
			data.ANAJIAENLNB_lv = (int)array[i].ANAJIAENLNB_lv;
			data.IHGDLBBPKFI_Next = (int)array[i].IHGDLBBPKFI_Next;
			data.BDLNMOIOMHK_total = (int)array[i].BDLNMOIOMHK_total;
			data.DMEDKJPOLCH_cat = (int)array[i].DMEDKJPOLCH_cat;
			data.EIIDPKCBKEK_prm = (int)array[i].EIIDPKCBKEK_prm;
			for(int j = 0; j < data.DGBAEDJPAMA.Length; j++)
			{
				data.KNAMKOLCIAC(j, (int)array[i].DKHIHHMOIKM_bns[j]);
			}
			OOCKOCAACMD_DataByLevel.Add(data);
		}
		return true;
	}

	// // RVA: 0xAA9A34 Offset: 0xAA9A34 VA: 0xAA9A34
	public bool KOPMKAKPJOO(AMBAEMHAMDB GGKAPJELKOA)
	{
		MDJJGLEJPFN[] array = GGKAPJELKOA.MIDBJNKMPEM;
		for(int i = 0; i < array.Length; i++)
		{
			AHIGPDEDCFO data = new AHIGPDEDCFO();
			data.PPFNGGCBJKC_id = (int)array[i].PPFNGGCBJKC_id;
			data.JBGEEPFKIGG_val = (int)array[i].JBGEEPFKIGG_val;
			COHLJLNLBKM.Add(data);
		}
		return true;
	}

	// // RVA: 0xAAA568 Offset: 0xAAA568 VA: 0xAAA568 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		return false;
	}

	// // RVA: 0xAAA570 Offset: 0xAAA570 VA: 0xAAA570 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "GJALOMELEHD_Intimacy.CAOGDCBPBAN");
		return 0;
	}

	// // RVA: 0xAAA8AC Offset: 0xAAA8AC VA: 0xAAA8AC
	public int GLHEHGGKILG_GetMaxLevel()
	{
		CEBFFLDKAEC_SecureInt val = new CEBFFLDKAEC_SecureInt();
		if(OHJFBLFELNK_m_intParam.TryGetValue("level_max", out val))
		{
			if (val.DNJEJEANJGL_Value > 0)
				return val.DNJEJEANJGL_Value;
		}
		return OOCKOCAACMD_DataByLevel.Count;
	}

	// // RVA: 0xAAA9C0 Offset: 0xAAA9C0 VA: 0xAAA9C0
	public int NPKHLGBNOKO_GetMaxPresent()
	{
		return LPJLEHAJADA_GetIntParam("present_give_max", 3);
	}

	// // RVA: 0xAAAA28 Offset: 0xAAAA28 VA: 0xAAAA28
	public bool NJGEDPHNIKC_IsPresentLimitEnabled()
	{
		int a = LPJLEHAJADA_GetIntParam("present_diva_limit_enable_master_version", 0);
		return 0 < a && a <= IEFOPDOOLOK_MasterVersion;
	}

	// // RVA: 0xAAAAF4 Offset: 0xAAAAF4 VA: 0xAAAAF4
	public int JBKMPBPGFHA(int _CIEOBFIIPLD_Level)
	{
		if (_CIEOBFIIPLD_Level < 1 || GLHEHGGKILG_GetMaxLevel() <= _CIEOBFIIPLD_Level)
			return 0;
		return OOCKOCAACMD_DataByLevel[_CIEOBFIIPLD_Level].BDLNMOIOMHK_total;
	}
}
