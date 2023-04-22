
using System.Collections.Generic;
using XeApp.Game.Common;

[System.Obsolete("Use LLKLAKGKNLD_LimitOver", true)]
public class LLKLAKGKNLD { }
public class LLKLAKGKNLD_LimitOver : DIHHCBACKGG_DbSection
{
	public class PBMKLFCEAAA
	{
		public List<int> IOKDGIGCJDA = new List<int>(); // 0x8
		public int EHOIENNDEDH; // 0xC

		public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0x18109E0 DEMEPMAEJOO 0x180FD54 HIGKAIDMOKN

		//// RVA: 0x180EC10 Offset: 0x180EC10 VA: 0x180EC10
		//public int DEACAHNLMNI(int OIPCCBHIKIA) { }

		//// RVA: 0x1810570 Offset: 0x1810570 VA: 0x1810570
		//public uint CAOGDCBPBAN() { }
	}

	public class ENKHACHPPFA
	{
		public int PLNGGLJCGNM; // 0x8
		public int AHGCGHAAHOO; // 0xC
		public int DNLHENCICKD; // 0x10
		public int MMEINLBEOMK; // 0x14
		public int EAJCFBCHIFB; // 0x18

		public int GNFJOONKCFH { get { return PLNGGLJCGNM ^ FBGGEFFJJHB; } set { PLNGGLJCGNM = value ^ FBGGEFFJJHB; } } //0x18106E8 LOFPOONPOMC 0x180FDF8 KEGADDBFANM
		public int GLCLFMGPMAN { get { return AHGCGHAAHOO ^ FBGGEFFJJHB; } set { AHGCGHAAHOO = value ^ FBGGEFFJJHB; } } //0x1810780 LNJAENEGDEL 0x180FE94 JHIDBGCHOKL
		public int ACGLMKEBMDL { get { return DNLHENCICKD ^ FBGGEFFJJHB; } set { DNLHENCICKD = value ^ FBGGEFFJJHB; } } //0x1810818 ALOLFIJOOHG 0x180FFCC JDPCOMJIMHG
		public int ADPPAIPFHML { get { return MMEINLBEOMK ^ FBGGEFFJJHB; } set { MMEINLBEOMK = value ^ FBGGEFFJJHB; } } //0x18108B0 LJMLHOOPGEM 0x180FF30 PHNIOCPOBGO
		public int EKLIPGELKCL { get { return EAJCFBCHIFB ^ FBGGEFFJJHB; } set { EAJCFBCHIFB = value ^ FBGGEFFJJHB; } } //0x1810948 OEEHBGECGKL 0x1810068 GHLMHLJJBIG

		//// RVA: 0x181061C Offset: 0x181061C VA: 0x181061C
		//public uint CAOGDCBPBAN() { }
	}

	public static int FBGGEFFJJHB = 0x4adfd36; // 0x0
	private List<int> BDKOIDEMCEE = new List<int>(6); // 0x20
	private List<int> LOCCHKJGJDJ = new List<int>(26); // 0x24
	private List<int> BMEHMMIPELI = new List<int>(26); // 0x28
	public List<PBMKLFCEAAA> BODDKCKFLJF = new List<PBMKLFCEAAA>(6); // 0x2C
	public List<PBMKLFCEAAA> GPPJBOCJOFI = new List<PBMKLFCEAAA>(5); // 0x30
	public List<ENKHACHPPFA> PIPHIPNEJCM = new List<ENKHACHPPFA>(5); // 0x34
	public static int DMDKPBPBDKD = -1; // 0x4
	private int EHKFGCPHHJJ; // 0x3C

	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK { get; private set; } // 0x38 KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB
	public int AJHBAOCLNDF_Enabled { get { return EHKFGCPHHJJ ^ 0x46c0baf; } set { EHKFGCPHHJJ = value ^ 0x46c0baf; } } //0x180E790 EHDOJGNECHA 0x180E910 DAHLKLKBJDB

	//// RVA: 0x180E55C Offset: 0x180E55C VA: 0x180E55C
	//public int ELFPIODODFF(int JKGFBFPIMGA) { }

	//// RVA: 0x180E628 Offset: 0x180E628 VA: 0x180E628
	public int JNLLKKHJCAD(int JKGFBFPIMGA, int MJBODMOLOBC)
	{
		int res = 0;
		if(AJHBAOCLNDF_Enabled == 2)
		{
			if(JKGFBFPIMGA == 4)
			{
				res = LOCCHKJGJDJ[MJBODMOLOBC];
			}
			else
			{
				if(JKGFBFPIMGA >= 5)
				{
					res = BMEHMMIPELI[MJBODMOLOBC];
				}
			}
			res = res ^ FBGGEFFJJHB;
		}
		return res;
	}

	//// RVA: 0x180E7A4 Offset: 0x180E7A4 VA: 0x180E7A4
	//public int BKCAECPCELG() { }

	//// RVA: 0x180E82C Offset: 0x180E82C VA: 0x180E82C
	public int LPJLEHAJADA(string LJNAKDMILMC, int KKMJBMKHGNH)
	{
		if (!OHJFBLFELNK.ContainsKey(LJNAKDMILMC))
			return KKMJBMKHGNH;
		return OHJFBLFELNK[LJNAKDMILMC].DNJEJEANJGL_Value;
	}

	//// RVA: 0x180E924 Offset: 0x180E924 VA: 0x180E924
	public void MNHPPJFNPCG(ref LimitOverStatusData DNNHDJPNIAK, int JKGFBFPIMGA, int MJBODMOLOBC, int DCMJPFFBINO)
	{
		TodoLogger.Log(0, "MNHPPJFNPCG");
	}

	// RVA: 0x180ECDC Offset: 0x180ECDC VA: 0x180ECDC
	public LLKLAKGKNLD_LimitOver()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 59;
		OHJFBLFELNK = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
	}

	// RVA: 0x180EECC Offset: 0x180EECC VA: 0x180EECC Slot: 8
	protected override void KMBPACJNEOF()
	{
		BDKOIDEMCEE.Clear();
		LOCCHKJGJDJ.Clear();
		BMEHMMIPELI.Clear();
		BODDKCKFLJF.Clear();
		GPPJBOCJOFI.Clear();
		PIPHIPNEJCM.Clear();
		OHJFBLFELNK.Clear();
		AJHBAOCLNDF_Enabled = 0;
	}

	// RVA: 0x180F058 Offset: 0x180F058 VA: 0x180F058 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		KMPKAHGGCHK parser = KMPKAHGGCHK.HEGEKFMJNCC(DBBGALAPFGC);
		{
			IMMJLLOOKCF[] array = parser.GOKCDMKKCMD;
			for(int i = 0; i < array.Length; i++)
			{
				PBMKLFCEAAA data = new PBMKLFCEAAA();
				data.PPFNGGCBJKC = array[i].PNDNJDMIKAN;
				int[] array2 = array[i].CBDOEDKIOJK;
				for(int j = 0; j < array2.Length; j++)
				{
					data.IOKDGIGCJDA.Add(array2[i] ^ FBGGEFFJJHB);
				}
				BODDKCKFLJF.Add(data);
			}
		}
		{
			CPNJPEHHNOO[] array = parser.PFGDBAIFLGL;
			for (int i = 0; i < array.Length; i++)
			{
				PBMKLFCEAAA data = new PBMKLFCEAAA();
				data.PPFNGGCBJKC = array[i].GNFJOONKCFH;
				int[] array2 = array[i].CBDOEDKIOJK;
				for (int j = 0; j < array2.Length; j++)
				{
					data.IOKDGIGCJDA.Add(array2[i] ^ FBGGEFFJJHB);
				}
				GPPJBOCJOFI.Add(data);
			}
		}
		{
			AMEBNIIIHNG[] array = parser.PPMOLKLDNLB;
			for (int i = 0; i < array.Length; i++)
			{
				ENKHACHPPFA data = new ENKHACHPPFA();
				data.GNFJOONKCFH = array[i].GNFJOONKCFH;
				data.GLCLFMGPMAN = array[i].GLCLFMGPMAN;
				data.ADPPAIPFHML = array[i].ADPPAIPFHML;
				data.ACGLMKEBMDL = array[i].ACGLMKEBMDL;
				data.EKLIPGELKCL = array[i].FBFLDFMFFOH;
				PIPHIPNEJCM.Add(data);
			}
		}
		{
			ALNDGBMAILD[] array = parser.PJFGGPOEBAH;
			for (int i = 0; i < array.Length; i++)
			{
				BDKOIDEMCEE.Add(array[i].ELHALBFPLJK);
			}
		}
		{
			DGILHAMKBKK[] array = parser.KIEKMCKCMGD;
			for (int i = 0; i < array.Length; i++)
			{
				LOCCHKJGJDJ.Add(array[i].FDAPNFDOHEJ);
				BMEHMMIPELI.Add(array[i].EDFJKODHCAN);
			}
		}
		{
			GGKLHGBDPDD[] array = parser.BHGDNGHDDAC;
			for (int i = 0; i < array.Length; i++)
			{
				CEBFFLDKAEC_SecureInt data = new CEBFFLDKAEC_SecureInt();
				data.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG;
				OHJFBLFELNK.Add(array[i].LJNAKDMILMC, data);
			}
		}
		AJHBAOCLNDF_Enabled = JKAECBCNHAN_IsEnabled(LPJLEHAJADA("master_mver", 0), LPJLEHAJADA("master_en", 0), 0);
		return true;
	}

	// RVA: 0x1810104 Offset: 0x1810104 VA: 0x1810104 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return true;
	}

	// RVA: 0x181010C Offset: 0x181010C VA: 0x181010C Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(100, "LimitOver CAOGDCBPBAN");
		return 0;
	}
}
