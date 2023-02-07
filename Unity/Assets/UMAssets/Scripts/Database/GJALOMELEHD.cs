using System.Collections.Generic;

[System.Obsolete("Use GJALOMELEHD_Intimacy", true)]
public class GJALOMELEHD { }
public class GJALOMELEHD_Intimacy : DIHHCBACKGG_DbSection
{
	public class ELAIMNHBCFB
	{
		public int EHOIENNDEDH; // 0x8
		public int ICKOHEDLEFP; // 0xC
		public int BOIPMPBGLDE; // 0x10
		public int AHGCGHAAHOO; // 0x14
		public int MMIIEJCNHOF; // 0x18
		public int HNJHPNPFAAN; // 0x1C

		public int PPFNGGCBJKC_Id { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0xAAADE4 DEMEPMAEJOO 0xAA9C0C HIGKAIDMOKN
		public int JBGEEPFKIGG { get { return ICKOHEDLEFP ^ FBGGEFFJJHB; } set { ICKOHEDLEFP = value ^ FBGGEFFJJHB; } } //0xAAAE7C OLOCMINKGON 0xAA9CA8 ABAFHIBFKCE
		public int JONPKLHMOBL { get { return BOIPMPBGLDE ^ FBGGEFFJJHB; } set { BOIPMPBGLDE = value ^ FBGGEFFJJHB; } } //0xAAAF14 LDDGKJEDMED 0xAA9D44 BEBCJJGHFDO
		public int GLCLFMGPMAN { get { return AHGCGHAAHOO ^ FBGGEFFJJHB; } set { AHGCGHAAHOO = value ^ FBGGEFFJJHB; } } //0xAAAFAC LNJAENEGDEL 0xAA9DE0 JHIDBGCHOKL
		public int JKFLOJNPLIJ { get { return MMIIEJCNHOF ^ FBGGEFFJJHB; } set { MMIIEJCNHOF = value ^ FBGGEFFJJHB; } } //0xAAB044 ABIHJLDHFEG 0xAA9E7C HPKIFMODCED
		public int PLALNIIBLOF { get { return HNJHPNPFAAN ^ FBGGEFFJJHB; } set { HNJHPNPFAAN = value ^ FBGGEFFJJHB; } } //0xAAB0DC JPCJNLHHIPE 0xAA9F18 JJFJNEJLBDG

		// RVA: 0xAAA794 Offset: 0xAAA794 VA: 0xAAA794
		// public uint CAOGDCBPBAN() { }
	}

	public class MFMLEAMJJCH_LevelInfo
	{
		public int MBCPMFPKNBA; // 0x8
		public int DFNMDAAICGH; // 0xC
		public int JKJDDGGNEAB; // 0x10
		public int HNNLOMMFHEN; // 0x14
		public int BNDKLGDMGAM; // 0x18
		public int[] DGBAEDJPAMA = new int[10]; // 0x1C

		public int ANAJIAENLNB { get { return MBCPMFPKNBA ^ FBGGEFFJJHB; } set { MBCPMFPKNBA = value ^ FBGGEFFJJHB; } } //0xAAB174 MMOMNMBKHJF 0xAAA028 FEHNFGPFINK
		public int IHGDLBBPKFI { get { return DFNMDAAICGH ^ FBGGEFFJJHB; } set { DFNMDAAICGH = value ^ FBGGEFFJJHB; } } //0xAAB20C ONOBDELIEFB 0xAAA0C4 MKNICENPJBP
		public int BDLNMOIOMHK_StartExp { get { return JKJDDGGNEAB ^ FBGGEFFJJHB; } set { JKJDDGGNEAB = value ^ FBGGEFFJJHB; } } //0xAAABB0 MKMAKAEDMBG 0xAAA160 GIJPLHEDIKD
		public int DMEDKJPOLCH { get { return HNNLOMMFHEN ^ FBGGEFFJJHB; } set { HNNLOMMFHEN = value ^ FBGGEFFJJHB; } } //0xAAB2A4 IPKCKAAEEOE 0xAAA1FC JOGLLINFLJN
		public int EIIDPKCBKEK_SkillLevel { get { return BNDKLGDMGAM ^ FBGGEFFJJHB; } set { BNDKLGDMGAM = value ^ FBGGEFFJJHB; } } //0xAAB33C GNOMKOGNGAD 0xAAA298 LIAJMHMKLLM

		// // RVA: 0xAAB3D4 Offset: 0xAAB3D4 VA: 0xAAB3D4
		public int ECEKNKIDING(int IOPHIHFOOEP)
		{
			if (DGBAEDJPAMA.Length <= IOPHIHFOOEP)
				return 0;
			return DGBAEDJPAMA[IOPHIHFOOEP] ^ FBGGEFFJJHB;
		}

		// // RVA: 0xAAA334 Offset: 0xAAA334 VA: 0xAAA334
		public void KNAMKOLCIAC(int IOPHIHFOOEP, int JBGEEPFKIGG)
		{
			if (IOPHIHFOOEP >= DGBAEDJPAMA.Length)
				return;
			DGBAEDJPAMA[IOPHIHFOOEP] = JBGEEPFKIGG ^ FBGGEFFJJHB;
		}

		// // RVA: 0xAAA7F0 Offset: 0xAAA7F0 VA: 0xAAA7F0
		// public uint CAOGDCBPBAN() { }
	}

	public class AHIGPDEDCFO
	{
		public int EHOIENNDEDH; // 0x8
		public int ICKOHEDLEFP; // 0xC

		public int PPFNGGCBJKC_Id { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0xAAACB4 DEMEPMAEJOO 0xAAA430 HIGKAIDMOKN
		public int JBGEEPFKIGG { get { return ICKOHEDLEFP ^ FBGGEFFJJHB; } set { ICKOHEDLEFP = value ^ FBGGEFFJJHB; } } //0xAAAD4C OLOCMINKGON 0xAAA4CC ABAFHIBFKCE

		// // RVA: 0xAAA880 Offset: 0xAAA880 VA: 0xAAA880
		// public uint CAOGDCBPBAN() { }
	}

	public const int PEJGHAJJDIG = 40;
	public const int LBBLNLCFIOH = 10;
	public static int FBGGEFFJJHB = 0x4341b; // 0x0
	public List<ELAIMNHBCFB> CJAEGOMDICD = new List<ELAIMNHBCFB>(28); // 0x20
	public List<MFMLEAMJJCH_LevelInfo> OOCKOCAACMD_DataByLevel = new List<MFMLEAMJJCH_LevelInfo>(); // 0x24
	public List<AHIGPDEDCFO> COHLJLNLBKM = new List<AHIGPDEDCFO>(); // 0x28

	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK_IntArray { get; private set; } // 0x2C KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB
	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI_StringArray { get; private set; } // 0x30 IHKPIFIBECO GAMGELHIHHI DDDEJIJGGBJ

	// // RVA: 0xAA8CAC Offset: 0xAA8CAC VA: 0xAA8CAC
	// public string EFEGBHACJAL(string LJNAKDMILMC, string KKMJBMKHGNH) { }

	// // RVA: 0xAA8D90 Offset: 0xAA8D90 VA: 0xAA8D90
	public int LPJLEHAJADA_GetValue(string LJNAKDMILMC, int KKMJBMKHGNH)
    {
		if (!OHJFBLFELNK_IntArray.ContainsKey(LJNAKDMILMC))
			return KKMJBMKHGNH;
		return OHJFBLFELNK_IntArray[LJNAKDMILMC].DNJEJEANJGL_Value;
	}

	// // RVA: 0xAA8E74 Offset: 0xAA8E74 VA: 0xAA8E74
	public GJALOMELEHD_Intimacy()
    {
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		OHJFBLFELNK_IntArray = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		LMHMIIKCGPE = 56;
		FJOEBCMGDMI_StringArray = new Dictionary<string, NNJFKLBPBNK_SecureString>();
    }

	// // RVA: 0xAA903C Offset: 0xAA903C VA: 0xAA903C Slot: 8
	protected override void KMBPACJNEOF()
    {
		CJAEGOMDICD.Clear();
		OOCKOCAACMD_DataByLevel.Clear();
		COHLJLNLBKM.Clear();
		OHJFBLFELNK_IntArray.Clear();
		FJOEBCMGDMI_StringArray.Clear();
    }

	// // RVA: 0xAA9164 Offset: 0xAA9164 VA: 0xAA9164 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
    {
		AMBAEMHAMDB parser = AMBAEMHAMDB.HEGEKFMJNCC(DBBGALAPFGC);
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
				FJOEBCMGDMI_StringArray.Add(array[i].LJNAKDMILMC, data);
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
			data.PPFNGGCBJKC_Id = (int)array[i].PPFNGGCBJKC;
			data.JBGEEPFKIGG = (int)array[i].JBGEEPFKIGG;
			data.JONPKLHMOBL = (int)array[i].DMEDKJPOLCH;
			data.GLCLFMGPMAN = (int)array[i].GLCLFMGPMAN;
			data.JKFLOJNPLIJ = (int)array[i].HHDGLPENPFI;
			data.PLALNIIBLOF = (int)array[i].PLALNIIBLOF;
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
			data.ANAJIAENLNB = (int)array[i].ANAJIAENLNB;
			data.IHGDLBBPKFI = (int)array[i].IHGDLBBPKFI;
			data.BDLNMOIOMHK_StartExp = (int)array[i].BDLNMOIOMHK;
			data.DMEDKJPOLCH = (int)array[i].DMEDKJPOLCH;
			data.EIIDPKCBKEK_SkillLevel = (int)array[i].EIIDPKCBKEK;
			for(int j = 0; j < data.DGBAEDJPAMA.Length; j++)
			{
				data.KNAMKOLCIAC(i, (int)array[i].DKHIHHMOIKM[j]);
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
			data.PPFNGGCBJKC_Id = (int)array[i].PPFNGGCBJKC;
			data.JBGEEPFKIGG = (int)array[i].JBGEEPFKIGG;
			COHLJLNLBKM.Add(data);
		}
		return true;
	}

	// // RVA: 0xAAA568 Offset: 0xAAA568 VA: 0xAAA568 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return false;
	}

	// // RVA: 0xAAA570 Offset: 0xAAA570 VA: 0xAAA570 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "GJALOMELEHD_Intimacy.CAOGDCBPBAN");
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
	// public int NPKHLGBNOKO() { }

	// // RVA: 0xAAAA28 Offset: 0xAAAA28 VA: 0xAAAA28
	// public bool NJGEDPHNIKC() { }

	// // RVA: 0xAAAAF4 Offset: 0xAAAAF4 VA: 0xAAAAF4
	// public int JBKMPBPGFHA(int CIEOBFIIPLD) { }
}
