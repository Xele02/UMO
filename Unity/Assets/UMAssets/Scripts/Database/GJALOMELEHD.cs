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

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0xAAADE4 DEMEPMAEJOO 0xAA9C0C HIGKAIDMOKN
		public int JBGEEPFKIGG_Value { get { return ICKOHEDLEFP_ValueCrypted ^ FBGGEFFJJHB_xor; } set { ICKOHEDLEFP_ValueCrypted = value ^ FBGGEFFJJHB_xor; } } //0xAAAE7C OLOCMINKGON 0xAA9CA8 ABAFHIBFKCE
		public int JONPKLHMOBL_Category { get { return BOIPMPBGLDE_Crypted ^ FBGGEFFJJHB_xor; } set { BOIPMPBGLDE_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAAF14 LDDGKJEDMED 0xAA9D44 BEBCJJGHFDO
		public int GLCLFMGPMAN_ItemId { get { return AHGCGHAAHOO_ItemIdCrypted ^ FBGGEFFJJHB_xor; } set { AHGCGHAAHOO_ItemIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0xAAAFAC LNJAENEGDEL 0xAA9DE0 JHIDBGCHOKL
		public int JKFLOJNPLIJ { get { return MMIIEJCNHOF_Crypted ^ FBGGEFFJJHB_xor; } set { MMIIEJCNHOF_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAB044 ABIHJLDHFEG 0xAA9E7C HPKIFMODCED
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0xAAB0DC JPCJNLHHIPE 0xAA9F18 JJFJNEJLBDG

		// RVA: 0xAAA794 Offset: 0xAAA794 VA: 0xAAA794
		// public uint CAOGDCBPBAN() { }
	}

	public class MFMLEAMJJCH_LevelInfo
	{
		public int MBCPMFPKNBA_LevelCrypted; // 0x8
		public int DFNMDAAICGH_Crypted; // 0xC
		public int JKJDDGGNEAB_TotalCrypted; // 0x10
		public int HNNLOMMFHEN_Crypted; // 0x14
		public int BNDKLGDMGAM_Crypted; // 0x18
		public int[] DGBAEDJPAMA = new int[10]; // 0x1C

		public int ANAJIAENLNB_Level { get { return MBCPMFPKNBA_LevelCrypted ^ FBGGEFFJJHB_xor; } set { MBCPMFPKNBA_LevelCrypted = value ^ FBGGEFFJJHB_xor; } } //0xAAB174 MMOMNMBKHJF 0xAAA028 FEHNFGPFINK
		public int IHGDLBBPKFI_Next { get { return DFNMDAAICGH_Crypted ^ FBGGEFFJJHB_xor; } set { DFNMDAAICGH_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAB20C ONOBDELIEFB 0xAAA0C4 MKNICENPJBP
		public int BDLNMOIOMHK_Total { get { return JKJDDGGNEAB_TotalCrypted ^ FBGGEFFJJHB_xor; } set { JKJDDGGNEAB_TotalCrypted = value ^ FBGGEFFJJHB_xor; } } //0xAAABB0 MKMAKAEDMBG 0xAAA160 GIJPLHEDIKD
		public int DMEDKJPOLCH_Category { get { return HNNLOMMFHEN_Crypted ^ FBGGEFFJJHB_xor; } set { HNNLOMMFHEN_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAB2A4 IPKCKAAEEOE 0xAAA1FC JOGLLINFLJN
		// SkillLEvel
		public int EIIDPKCBKEK_prm { get { return BNDKLGDMGAM_Crypted ^ FBGGEFFJJHB_xor; } set { BNDKLGDMGAM_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAB33C GNOMKOGNGAD 0xAAA298 LIAJMHMKLLM

		// // RVA: 0xAAB3D4 Offset: 0xAAB3D4 VA: 0xAAB3D4
		public int ECEKNKIDING(int IOPHIHFOOEP)
		{
			if (DGBAEDJPAMA.Length <= IOPHIHFOOEP)
				return 0;
			return DGBAEDJPAMA[IOPHIHFOOEP] ^ FBGGEFFJJHB_xor;
		}

		// // RVA: 0xAAA334 Offset: 0xAAA334 VA: 0xAAA334
		public void KNAMKOLCIAC(int IOPHIHFOOEP, int _JBGEEPFKIGG_Value)
		{
			if (IOPHIHFOOEP >= DGBAEDJPAMA.Length)
				return;
			DGBAEDJPAMA[IOPHIHFOOEP] = _JBGEEPFKIGG_Value ^ FBGGEFFJJHB_xor;
		}

		// // RVA: 0xAAA7F0 Offset: 0xAAA7F0 VA: 0xAAA7F0
		// public uint CAOGDCBPBAN() { }
	}

	public class AHIGPDEDCFO
	{
		public int EHOIENNDEDH_IdCrypted; // 0x8
		public int ICKOHEDLEFP_ValueCrypted; // 0xC

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0xAAACB4 DEMEPMAEJOO 0xAAA430 HIGKAIDMOKN
		public int JBGEEPFKIGG_Value { get { return ICKOHEDLEFP_ValueCrypted ^ FBGGEFFJJHB_xor; } set { ICKOHEDLEFP_ValueCrypted = value ^ FBGGEFFJJHB_xor; } } //0xAAAD4C OLOCMINKGON 0xAAA4CC ABAFHIBFKCE

		// // RVA: 0xAAA880 Offset: 0xAAA880 VA: 0xAAA880
		// public uint CAOGDCBPBAN() { }
	}

	public const int PEJGHAJJDIG = 40;
	public const int LBBLNLCFIOH = 10;
	public static int FBGGEFFJJHB_xor = 0x4341b; // 0x0
	public List<ELAIMNHBCFB> CJAEGOMDICD = new List<ELAIMNHBCFB>(28); // 0x20
	public List<MFMLEAMJJCH_LevelInfo> OOCKOCAACMD_DataByLevel = new List<MFMLEAMJJCH_LevelInfo>(); // 0x24
	public List<AHIGPDEDCFO> COHLJLNLBKM = new List<AHIGPDEDCFO>(); // 0x28

	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK_IntArray { get; private set; } // 0x2C KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB
	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI_String { get; private set; } // 0x30 IHKPIFIBECO GAMGELHIHHI DDDEJIJGGBJ

	// // RVA: 0xAA8CAC Offset: 0xAA8CAC VA: 0xAA8CAC
	// public string EFEGBHACJAL(string _LJNAKDMILMC_key, string KKMJBMKHGNH) { }

	// // RVA: 0xAA8D90 Offset: 0xAA8D90 VA: 0xAA8D90
	public int LPJLEHAJADA_GetValue(string _LJNAKDMILMC_key, int KKMJBMKHGNH)
    {
		if (!OHJFBLFELNK_IntArray.ContainsKey(_LJNAKDMILMC_key))
			return KKMJBMKHGNH;
		return OHJFBLFELNK_IntArray[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
	}

	// // RVA: 0xAA8E74 Offset: 0xAA8E74 VA: 0xAA8E74
	public GJALOMELEHD_Intimacy()
    {
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		OHJFBLFELNK_IntArray = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		LMHMIIKCGPE = 56;
		FJOEBCMGDMI_String = new Dictionary<string, NNJFKLBPBNK_SecureString>();
    }

	// // RVA: 0xAA903C Offset: 0xAA903C VA: 0xAA903C Slot: 8
	protected override void KMBPACJNEOF_Reset()
    {
		CJAEGOMDICD.Clear();
		OOCKOCAACMD_DataByLevel.Clear();
		COHLJLNLBKM.Clear();
		OHJFBLFELNK_IntArray.Clear();
		FJOEBCMGDMI_String.Clear();
    }

	// // RVA: 0xAA9164 Offset: 0xAA9164 VA: 0xAA9164 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_Data)
    {
		AMBAEMHAMDB parser = AMBAEMHAMDB.HEGEKFMJNCC(_DBBGALAPFGC_Data);
		NNEBKOJADBA(parser);
		CGFCKHEGOJN(parser);
		KOPMKAKPJOO(parser);
		{
			AGPHLNAPAKA[] array = parser.BHGDNGHDDAC;
			for(int i = 0; i < array.Length; i++)
			{
				CEBFFLDKAEC_SecureInt data = new CEBFFLDKAEC_SecureInt();
				data.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG;
				OHJFBLFELNK_IntArray.Add(array[i].LJNAKDMILMC, data);
			}
		}
		{
			CMNIIDMIIHI[] array = parser.MHGMDJNOLMI;
			for (int i = 0; i < array.Length; i++)
			{
				NNJFKLBPBNK_SecureString data = new NNJFKLBPBNK_SecureString();
				data.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG;
				FJOEBCMGDMI_String.Add(array[i].LJNAKDMILMC, data);
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
			data.PPFNGGCBJKC_id = (int)array[i].PPFNGGCBJKC;
			data.JBGEEPFKIGG_Value = (int)array[i].JBGEEPFKIGG;
			data.JONPKLHMOBL_Category = (int)array[i].DMEDKJPOLCH;
			data.GLCLFMGPMAN_ItemId = (int)array[i].GLCLFMGPMAN;
			data.JKFLOJNPLIJ = (int)array[i].HHDGLPENPFI;
			data.PLALNIIBLOF_en = (int)array[i].PLALNIIBLOF;
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
			data.ANAJIAENLNB_Level = (int)array[i].ANAJIAENLNB;
			data.IHGDLBBPKFI_Next = (int)array[i].IHGDLBBPKFI;
			data.BDLNMOIOMHK_Total = (int)array[i].BDLNMOIOMHK;
			data.DMEDKJPOLCH_Category = (int)array[i].DMEDKJPOLCH;
			data.EIIDPKCBKEK_prm = (int)array[i].EIIDPKCBKEK;
			for(int j = 0; j < data.DGBAEDJPAMA.Length; j++)
			{
				data.KNAMKOLCIAC(j, (int)array[i].DKHIHHMOIKM[j]);
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
			data.PPFNGGCBJKC_id = (int)array[i].PPFNGGCBJKC;
			data.JBGEEPFKIGG_Value = (int)array[i].JBGEEPFKIGG;
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
		if(OHJFBLFELNK_IntArray.TryGetValue("level_max", out val))
		{
			if (val.DNJEJEANJGL_Value > 0)
				return val.DNJEJEANJGL_Value;
		}
		return OOCKOCAACMD_DataByLevel.Count;
	}

	// // RVA: 0xAAA9C0 Offset: 0xAAA9C0 VA: 0xAAA9C0
	public int NPKHLGBNOKO_GetMaxPresent()
	{
		return LPJLEHAJADA_GetValue("present_give_max", 3);
	}

	// // RVA: 0xAAAA28 Offset: 0xAAAA28 VA: 0xAAAA28
	public bool NJGEDPHNIKC_IsPresentLimitEnabled()
	{
		int a = LPJLEHAJADA_GetValue("present_diva_limit_enable_master_version", 0);
		return 0 < a && a <= IEFOPDOOLOK_MasterVersion;
	}

	// // RVA: 0xAAAAF4 Offset: 0xAAAAF4 VA: 0xAAAAF4
	public int JBKMPBPGFHA(int _CIEOBFIIPLD_Level)
	{
		if (_CIEOBFIIPLD_Level < 1 || GLHEHGGKILG_GetMaxLevel() <= _CIEOBFIIPLD_Level)
			return 0;
		return OOCKOCAACMD_DataByLevel[_CIEOBFIIPLD_Level].BDLNMOIOMHK_Total;
	}
}
