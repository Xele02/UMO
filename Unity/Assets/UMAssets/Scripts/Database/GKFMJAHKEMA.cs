
using System.Collections.Generic;

[System.Obsolete("Use GKFMJAHKEMA_ValSkill", true)]
public class GKFMJAHKEMA { }
public class GKFMJAHKEMA_ValSkill : DIHHCBACKGG_DbSection
{
	public class CCPFGNNIBDD
	{
		private int FBGGEFFJJHB; // 0x8
		private long BBEGLBMOBOF; // 0x10
		private int EHOIENNDEDH; // 0x18
		private int LCGJKAGIFGO; // 0x1C
		private int KJPMILGACLK; // 0x20
		private int KICEHBDNKPA; // 0x24
		private int JMIGCLKOKDA; // 0x28
		private int GNGNIKNNCNH; // 0x2C
		private int HNJHPNPFAAN; // 0x30

		public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0xAB1788 DEMEPMAEJOO 0xAB05A0 HIGKAIDMOKN
		public int DOOGFEGEKLG { get { return LCGJKAGIFGO ^ FBGGEFFJJHB; } set { LCGJKAGIFGO = value ^ FBGGEFFJJHB; } } //0xAB1898 AECMFIOFFJN 0xAB05D0 NGOJJDOCIDG
		public int KFLIHDFDBOA { get { return KJPMILGACLK ^ FBGGEFFJJHB; } set { KJPMILGACLK = value ^ FBGGEFFJJHB; } } //0xAB18A8 LLMHFPBDMPM 0xAB05E0 CHHBOLFOPAA
		public int OGMLPLGLELF { get { return KICEHBDNKPA ^ FBGGEFFJJHB; } set { KICEHBDNKPA = value ^ FBGGEFFJJHB; } } //0xAB18B8 CKEFNICFCIN 0xAB05F0 MFFKMNBMBNJ
		public int NHFDCMNPFDK { get { return JMIGCLKOKDA ^ FBGGEFFJJHB; } set { JMIGCLKOKDA = value ^ FBGGEFFJJHB; } } //0xAB18C8 PENKBCJGKAF 0xAB0600 FLNEBAEGCFI
		public int IJEKNCDIIAE { get { return GNGNIKNNCNH ^ FBGGEFFJJHB; } set { GNGNIKNNCNH = value ^ FBGGEFFJJHB; } } //0xAB18D8 KJIMMIBDCIL 0xAB05B0 DMEGNOKIKCD
		public int PLALNIIBLOF { get { return HNJHPNPFAAN ^ FBGGEFFJJHB; } set { HNJHPNPFAAN = value ^ FBGGEFFJJHB; } } //0xAB1798 JPCJNLHHIPE 0xAB05C0 JJFJNEJLBDG

		// RVA: 0xAB04EC Offset: 0xAB04EC VA: 0xAB04EC
		public CCPFGNNIBDD()
		{
			FBGGEFFJJHB = LPDNKHAIOLH.CEIBAFOCNCA();
			NHFDCMNPFDK = 0;
			IJEKNCDIIAE = 0;
			PLALNIIBLOF = 0;
			BBEGLBMOBOF = ~FBGGEFFJJHB;
			EHOIENNDEDH = 0;
			LCGJKAGIFGO = 0;
			KJPMILGACLK = 0;
			KICEHBDNKPA = 0;
		}

		// RVA: 0xAB147C Offset: 0xAB147C VA: 0xAB147C
		//public uint CAOGDCBPBAN() { }
	}

	public class GBDONNIHJHG
	{
		private int FBGGEFFJJHB; // 0x8
		private long BBEGLBMOBOF; // 0x10
		private int EHOIENNDEDH; // 0x18
		private int OOGFJFNEHEC; // 0x1C
		private int OOHFGOACFHL; // 0x20
		private int LCGOPHGPKPH; // 0x24
		private int GFGHIDAJGDO; // 0x28
		private List<int> DNHMKIAGFAM = new List<int>(); // 0x2C

		public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0xAB17E8 DEMEPMAEJOO 0xAB071C HIGKAIDMOKN
		public int CBDFEJIBAMO { get { return OOGFJFNEHEC ^ FBGGEFFJJHB; } set { OOGFJFNEHEC = value ^ FBGGEFFJJHB; } } //0xAB2374 HJIDKFIKAAI 0xAB072C COHECJJEMMI
		public int PFBDNFPPNEJ { get { return OOHFGOACFHL ^ FBGGEFFJJHB; } set { OOHFGOACFHL = value ^ FBGGEFFJJHB; } }// 0xAB2384 JHCOKFLOONM 0xAB073C CMJFGGKIOFG
		public int GAMEFFJONIJ { get { return LCGOPHGPKPH ^ FBGGEFFJJHB; } set { LCGOPHGPKPH = value ^ FBGGEFFJJHB; } } //0xAB2394 CDOHKAHAKNH 0xAB074C NFOBBJMJFOI
		public int ODMJFHDIGLP { get { return GFGHIDAJGDO ^ FBGGEFFJJHB; } set { GFGHIDAJGDO = value ^ FBGGEFFJJHB; } } //0xAB23A4 IEACLNIEABJ 0xAB075C KEOPEEKGMDO

		//// RVA: 0xAB076C Offset: 0xAB076C VA: 0xAB076C
		public void DMPKBBHNKBH()
		{
			DNHMKIAGFAM.Clear();
		}

		//// RVA: 0xAB07E4 Offset: 0xAB07E4 VA: 0xAB07E4
		public void JPNADFKGNJH(int JBGEEPFKIGG)
		{
			DNHMKIAGFAM.Add(JBGEEPFKIGG ^ FBGGEFFJJHB);
		}

		//// RVA: 0xAB23B4 Offset: 0xAB23B4 VA: 0xAB23B4
		public int NBMPBLECFJD(int IOPHIHFOOEP)
		{
			if(IOPHIHFOOEP > -1 && IOPHIHFOOEP < DNHMKIAGFAM.Count)
			{
				return DNHMKIAGFAM[IOPHIHFOOEP] ^ FBGGEFFJJHB;
			}
			return 0;
		}

		//// RVA: 0xAB2480 Offset: 0xAB2480 VA: 0xAB2480
		//public void OKBPHBEBHAN(int IOPHIHFOOEP, int JBGEEPFKIGG) { }

		// RVA: 0xAB0610 Offset: 0xAB0610 VA: 0xAB0610
		public GBDONNIHJHG()
		{
			FBGGEFFJJHB = LPDNKHAIOLH.CEIBAFOCNCA();
			ODMJFHDIGLP = 0;
			BBEGLBMOBOF = ~FBGGEFFJJHB;
			EHOIENNDEDH = 0;
			OOGFJFNEHEC = 0;
			OOHFGOACFHL = 0;
			LCGOPHGPKPH = 0;
			DNHMKIAGFAM.Clear();
		}

		// RVA: 0xAB14C4 Offset: 0xAB14C4 VA: 0xAB14C4
		//public uint CAOGDCBPBAN() { }
	}

	public class FCHIPJMDHBM
	{
		private int FBGGEFFJJHB; // 0x8
		private long BBEGLBMOBOF; // 0x10
		private int EHOIENNDEDH; // 0x18
		private List<int> ONJNHLABLLC = new List<int>(); // 0x1C
		private List<int> HKLBJCBAIEN = new List<int>(); // 0x20
		private List<int> BKKNICIKHKI = new List<int>(); // 0x24
		private List<int> GEECBABNMHK = new List<int>(); // 0x28

		public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0xAB1838 DEMEPMAEJOO 0xAB0A34 HIGKAIDMOKN

		//// RVA: 0xAB0A44 Offset: 0xAB0A44 VA: 0xAB0A44
		public void LLFALHKEICO()
		{
			ONJNHLABLLC.Clear();
		}

		//// RVA: 0xAB0ABC Offset: 0xAB0ABC VA: 0xAB0ABC
		public void GFEGKFCLAPM(int JBGEEPFKIGG)
		{
			ONJNHLABLLC.Add(JBGEEPFKIGG ^ FBGGEFFJJHB);
		}

		//// RVA: 0xAB18E8 Offset: 0xAB18E8 VA: 0xAB18E8
		public int AFGPHBOOHJH(int IOPHIHFOOEP)
		{
			int res = 0;
			if(IOPHIHFOOEP > -1 && IOPHIHFOOEP < ONJNHLABLLC.Count)
			{
				res = ONJNHLABLLC[IOPHIHFOOEP] ^ FBGGEFFJJHB;
			}
			return res;
		}

		//// RVA: 0xAB19B4 Offset: 0xAB19B4 VA: 0xAB19B4
		//public void OIPMPJDOFAG(int IOPHIHFOOEP, int JBGEEPFKIGG) { }

		//// RVA: 0xAB0B40 Offset: 0xAB0B40 VA: 0xAB0B40
		public void LIHOGOPMPFO()
		{
			HKLBJCBAIEN.Clear();
		}

		//// RVA: 0xAB0BB8 Offset: 0xAB0BB8 VA: 0xAB0BB8
		public void ELLLMJAMBOF(int JBGEEPFKIGG)
		{
			HKLBJCBAIEN.Add(JBGEEPFKIGG ^ FBGGEFFJJHB);
		}

		//// RVA: 0xAB1A80 Offset: 0xAB1A80 VA: 0xAB1A80
		public int IFDKNGCDNHP(int IOPHIHFOOEP)
		{
			int res = 0;
			if (IOPHIHFOOEP > -1 && IOPHIHFOOEP < HKLBJCBAIEN.Count)
			{
				res = HKLBJCBAIEN[IOPHIHFOOEP] ^ FBGGEFFJJHB;
			}
			return res;
		}

		//// RVA: 0xAB1B4C Offset: 0xAB1B4C VA: 0xAB1B4C
		//public void IDLIHDFEONH(int IOPHIHFOOEP, int JBGEEPFKIGG) { }

		//// RVA: 0xAB0C3C Offset: 0xAB0C3C VA: 0xAB0C3C
		public void LIEBGPMFBDF()
		{
			BKKNICIKHKI.Clear();
		}

		//// RVA: 0xAB0CB4 Offset: 0xAB0CB4 VA: 0xAB0CB4
		public void DNCBOGHFNOH(int JBGEEPFKIGG)
		{
			BKKNICIKHKI.Add(JBGEEPFKIGG ^ FBGGEFFJJHB);
		}

		//// RVA: 0xAB1C18 Offset: 0xAB1C18 VA: 0xAB1C18
		public int MKGGFAKEGFL(int IOPHIHFOOEP)
		{
			int res = 0;
			if (IOPHIHFOOEP > -1 && IOPHIHFOOEP < BKKNICIKHKI.Count)
			{
				res = BKKNICIKHKI[IOPHIHFOOEP] ^ FBGGEFFJJHB;
			}
			return res;
		}

		//// RVA: 0xAB1CE4 Offset: 0xAB1CE4 VA: 0xAB1CE4
		//public void EJNBIPBGOJD(int IOPHIHFOOEP, int JBGEEPFKIGG) { }

		//// RVA: 0xAB0D38 Offset: 0xAB0D38 VA: 0xAB0D38
		public void FIFBLGBHFGL()
		{
			GEECBABNMHK.Clear();
		}

		//// RVA: 0xAB0DB0 Offset: 0xAB0DB0 VA: 0xAB0DB0
		public void FIHBIFNEALC(int JBGEEPFKIGG)
		{
			GEECBABNMHK.Add(JBGEEPFKIGG ^ FBGGEFFJJHB);
		}

		//// RVA: 0xAB1DB0 Offset: 0xAB1DB0 VA: 0xAB1DB0
		public int BFNMADOFKHI(int IOPHIHFOOEP)
		{
			int res = 0;
			if (IOPHIHFOOEP > -1 && IOPHIHFOOEP < GEECBABNMHK.Count)
			{
				res = GEECBABNMHK[IOPHIHFOOEP] ^ FBGGEFFJJHB;
			}
			return res;
		}

		//// RVA: 0xAB1E7C Offset: 0xAB1E7C VA: 0xAB1E7C
		//public void PJLPLKNPMOG(int IOPHIHFOOEP, int JBGEEPFKIGG) { }

		//// RVA: 0xAB0868 Offset: 0xAB0868 VA: 0xAB0868
		public FCHIPJMDHBM()
		{
			FBGGEFFJJHB = LPDNKHAIOLH.CEIBAFOCNCA();
			BBEGLBMOBOF = ~FBGGEFFJJHB;
			PPFNGGCBJKC = 0;
			ONJNHLABLLC.Clear();
			HKLBJCBAIEN.Clear();
			BKKNICIKHKI.Clear();
			GEECBABNMHK.Clear();
		}

		//// RVA: 0xAB1598 Offset: 0xAB1598 VA: 0xAB1598
		//public uint CAOGDCBPBAN() { }
	}

	public class FIKGJJDIBPH
	{
		private int FBGGEFFJJHB; // 0x8
		private long BBEGLBMOBOF; // 0x10
		private int EHOIENNDEDH; // 0x18
		public List<int> JKLOKAKFJKP = new List<int>(); // 0x1C
		public List<int> IFEHKNJONPL = new List<int>(); // 0x20

		public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0xAB1888 DEMEPMAEJOO 0xAB0F78 HIGKAIDMOKN

		//// RVA: 0xAB0F88 Offset: 0xAB0F88 VA: 0xAB0F88
		public void MJGPMLBMKFC()
		{
			JKLOKAKFJKP.Clear();
		}

		//// RVA: 0xAB1000 Offset: 0xAB1000 VA: 0xAB1000
		public void OPFHCMDOHHC(int JBGEEPFKIGG)
		{
			JKLOKAKFJKP.Add(JBGEEPFKIGG ^ FBGGEFFJJHB);
		}

		//// RVA: 0xAB1F48 Offset: 0xAB1F48 VA: 0xAB1F48
		//public int MLIJKJFMOHN(int IOPHIHFOOEP) { }

		//// RVA: 0xAB2014 Offset: 0xAB2014 VA: 0xAB2014
		//public void JFKBPEBPGCK(int IOPHIHFOOEP, int JBGEEPFKIGG) { }

		//// RVA: 0xAB1084 Offset: 0xAB1084 VA: 0xAB1084
		public void OIKGBOJBEIL()
		{
			IFEHKNJONPL.Clear();
		}

		//// RVA: 0xAB10FC Offset: 0xAB10FC VA: 0xAB10FC
		public void NGCIEKBKPJJ(int JBGEEPFKIGG)
		{
			IFEHKNJONPL.Add(JBGEEPFKIGG ^ FBGGEFFJJHB);
		}

		//// RVA: 0xAB20E0 Offset: 0xAB20E0 VA: 0xAB20E0
		//public int IMALGGGJDJO(int IOPHIHFOOEP) { }

		//// RVA: 0xAB21AC Offset: 0xAB21AC VA: 0xAB21AC
		//public void BHJNIOKNDLM(int IOPHIHFOOEP, int JBGEEPFKIGG) { }

		//// RVA: 0xAB0E34 Offset: 0xAB0E34 VA: 0xAB0E34
		public FIKGJJDIBPH()
		{
			FBGGEFFJJHB = LPDNKHAIOLH.CEIBAFOCNCA();
			BBEGLBMOBOF = ~FBGGEFFJJHB;
			PPFNGGCBJKC = 0;
			JKLOKAKFJKP.Clear();
			IFEHKNJONPL.Clear();
		}

		//// RVA: 0xAB2278 Offset: 0xAB2278 VA: 0xAB2278
		//public uint CAOGDCBPBAN() { }
	}

	public List<CCPFGNNIBDD> CCIDMMKDJDJ { get; private set; } // 0x20 GAJJKFGKAAD BEBMBNKNOJP GDCBAJNEFAJ
	public List<GBDONNIHJHG> OJGFDCNOPBP { get; private set; } // 0x24 JEDFAIFBPOI MCEBEEIJALO LDOMAJLOECD
	public List<FCHIPJMDHBM> CIHIKBNGDLA { get; private set; } // 0x28 DHDAFCENGPC BJIKIGNBILA HIMKPPFMILN
	public List<FIKGJJDIBPH> AELABGDHIHC { get; private set; } // 0x2C JFBHNMCJAJD IOIJBJLKBJN KOOKPGPEJAF
	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI { get; private set; } // 0x30 IHKPIFIBECO GAMGELHIHHI DDDEJIJGGBJ
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK { get; private set; } // 0x34 KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB

	//// RVA: 0xAAEC28 Offset: 0xAAEC28 VA: 0xAAEC28
	public CCPFGNNIBDD MNHBHNIHJJH(int PPFNGGCBJKC)
	{
		return CCIDMMKDJDJ.Find((CCPFGNNIBDD JGNBPFCJLKI) =>
		{
			//0xAB1734
			return JGNBPFCJLKI.PPFNGGCBJKC == PPFNGGCBJKC && JGNBPFCJLKI.PLALNIIBLOF == 2;
		});
	}

	//// RVA: 0xAAED28 Offset: 0xAAED28 VA: 0xAAED28
	public GBDONNIHJHG OOEFAGKHOCE(int PPFNGGCBJKC)
	{
		return OJGFDCNOPBP.Find((GBDONNIHJHG JGNBPFCJLKI) =>
		{
			//0xAB17A8
			return JGNBPFCJLKI.PPFNGGCBJKC == PPFNGGCBJKC;
		});
	}

	//// RVA: 0xAAEE28 Offset: 0xAAEE28 VA: 0xAAEE28
	public FCHIPJMDHBM MFFFFDKBOFK(int PPFNGGCBJKC)
	{
		return CIHIKBNGDLA.Find((FCHIPJMDHBM JGNBPFCJLKI) =>
		{
			//0xAB17F8
			return JGNBPFCJLKI.PPFNGGCBJKC == PPFNGGCBJKC;
		});
	}

	//// RVA: 0xAAEF28 Offset: 0xAAEF28 VA: 0xAAEF28
	//public GKFMJAHKEMA.FIKGJJDIBPH NIIADANCEKL(int PPFNGGCBJKC) { }

	//// RVA: 0xAAF048 Offset: 0xAAF048 VA: 0xAAF048
	//public string EFEGBHACJAL(string LJNAKDMILMC, string KKMJBMKHGNH) { }

	//// RVA: 0xAAF12C Offset: 0xAAF12C VA: 0xAAF12C
	public int LPJLEHAJADA(string LJNAKDMILMC, int KKMJBMKHGNH_DefaultValue)
	{
		if (!OHJFBLFELNK.ContainsKey(LJNAKDMILMC))
			return KKMJBMKHGNH_DefaultValue;
		return OHJFBLFELNK[LJNAKDMILMC].DNJEJEANJGL_Value;
	}

	//// RVA: 0xAAF210 Offset: 0xAAF210 VA: 0xAAF210
	public GKFMJAHKEMA_ValSkill()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		CCIDMMKDJDJ = new List<CCPFGNNIBDD>();
		OJGFDCNOPBP = new List<GBDONNIHJHG>();
		CIHIKBNGDLA = new List<FCHIPJMDHBM>();
		AELABGDHIHC = new List<FIKGJJDIBPH>();
		OHJFBLFELNK = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		FJOEBCMGDMI = new Dictionary<string, NNJFKLBPBNK_SecureString>();
		LMHMIIKCGPE = 87;
	}

	//// RVA: 0xAAF408 Offset: 0xAAF408 VA: 0xAAF408 Slot: 8
	protected override void KMBPACJNEOF()
	{
		CCIDMMKDJDJ.Clear();
		OJGFDCNOPBP.Clear();
		CIHIKBNGDLA.Clear();
		AELABGDHIHC.Clear();
		OHJFBLFELNK.Clear();
		FJOEBCMGDMI.Clear();
	}

	//// RVA: 0xAAF55C Offset: 0xAAF55C VA: 0xAAF55C Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		MIAGFHOGPPN reader = MIAGFHOGPPN.HEGEKFMJNCC(DBBGALAPFGC);
		BOLKGDELCCF(reader);
		OMAGEPNAFAI(reader);
		KHLOIECCOBG(reader);
		CFNIDHGEHKA(reader);
		{
			DNAIGLNMDBK[] array = reader.BHGDNGHDDAC;
			for(int i = 0; i < array.Length; i++)
			{
				CEBFFLDKAEC_SecureInt data = new CEBFFLDKAEC_SecureInt();
				data.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG;
				OHJFBLFELNK.Add(array[i].LJNAKDMILMC, data);
			}
		}
		{
			JMCDAINNDDJ[] array = reader.MHGMDJNOLMI;
			for (int i = 0; i < array.Length; i++)
			{
				NNJFKLBPBNK_SecureString data = new NNJFKLBPBNK_SecureString();
				data.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG;
				FJOEBCMGDMI.Add(array[i].LJNAKDMILMC, data);
			}
		}
		return true;
	}

	//// RVA: 0xAB04E4 Offset: 0xAB04E4 VA: 0xAB04E4 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return true;
	}

	//// RVA: 0xAAF854 Offset: 0xAAF854 VA: 0xAAF854
	private bool BOLKGDELCCF(MIAGFHOGPPN JMHECKKKMLK)
	{
		NPBFADCGACE[] array = JMHECKKKMLK.MMJDALHDALP;
		for(int i = 0; i < array.Length; i++)
		{
			CCPFGNNIBDD data = new CCPFGNNIBDD();
			data.PPFNGGCBJKC = array[i].PPFNGGCBJKC;
			data.IJEKNCDIIAE = array[i].IJEKNCDIIAE;
			data.PLALNIIBLOF = (int)array[i].PLALNIIBLOF;
			data.DOOGFEGEKLG = array[i].DOOGFEGEKLG;
			data.KFLIHDFDBOA = array[i].KFLIHDFDBOA;
			data.OGMLPLGLELF = array[i].OGMLPLGLELF;
			data.NHFDCMNPFDK = array[i].NHFDCMNPFDK;
			CCIDMMKDJDJ.Add(data);
		}
		return true;
	}

	//// RVA: 0xAAFB10 Offset: 0xAAFB10 VA: 0xAAFB10
	private bool OMAGEPNAFAI(MIAGFHOGPPN JMHECKKKMLK)
	{
		JIABMKPKEOP[] array = JMHECKKKMLK.JNEJFDOCIDN;
		for(int i = 0; i < array.Length; i++)
		{
			GBDONNIHJHG data = new GBDONNIHJHG();
			data.PPFNGGCBJKC = array[i].PPFNGGCBJKC;
			data.CBDFEJIBAMO = array[i].CBDFEJIBAMO;
			data.PFBDNFPPNEJ = array[i].PFBDNFPPNEJ;
			data.GAMEFFJONIJ = array[i].GAMEFFJONIJ;
			data.ODMJFHDIGLP = array[i].ODMJFHDIGLP;
			int[] array2 = array[i].KFCIJBLDHOK;
			data.DMPKBBHNKBH();
			for(int j = 0; j < array2.Length; j++)
			{
				data.JPNADFKGNJH(array2[j]);
			}
			OJGFDCNOPBP.Add(data);
		}
		return true;
	}

	//// RVA: 0xAAFE04 Offset: 0xAAFE04 VA: 0xAAFE04
	private bool KHLOIECCOBG(MIAGFHOGPPN JMHECKKKMLK)
	{
		PJMLNHMCMOG[] array = JMHECKKKMLK.FLDJCNDHENP;
		for(int i = 0; i < array.Length; i++)
		{
			FCHIPJMDHBM data = new FCHIPJMDHBM();
			data.PPFNGGCBJKC = array[i].PPFNGGCBJKC;
			{
				int[] array2 = array[i].GHFAMFHCLLO;
				data.LLFALHKEICO();
				for (int j = 0; j < array2.Length; j++)
				{
					data.GFEGKFCLAPM(array2[j]);
				}
			}
			{
				int[] array2 = array[i].FFGGEGECPMM;
				data.LIHOGOPMPFO();
				for(int j = 0; j < array2.Length; j++)
				{
					data.ELLLMJAMBOF(array2[j]);
				}
			}
			{
				int[] array2 = array[i].ECGHPHPNKFG;
				data.LIEBGPMFBDF();
				for (int j = 0; j < array2.Length; j++)
				{
					data.DNCBOGHFNOH(array2[j]);
				}
			}
			{
				int[] array2 = array[i].OBJCCILIBIB;
				data.FIFBLGBHFGL();
				for (int j = 0; j < array2.Length; j++)
				{
					data.FIHBIFNEALC(array2[j]);
				}
			}
			CIHIKBNGDLA.Add(data);
		}
		return true;
	}

	//// RVA: 0xAB0214 Offset: 0xAB0214 VA: 0xAB0214
	private bool CFNIDHGEHKA(MIAGFHOGPPN JMHECKKKMLK)
	{
		CDNNOHNNJJE[] array = JMHECKKKMLK.KMAFAMDPEKG;
		for(int i = 0; i < array.Length; i++)
		{
			FIKGJJDIBPH data = new FIKGJJDIBPH();
			data.PPFNGGCBJKC = array[i].PPFNGGCBJKC;
			{
				int[] array2 = array[i].GKIKBPGMEBB;
				data.MJGPMLBMKFC();
				for (int j = 0; j < array2.Length; j++)
				{
					data.OPFHCMDOHHC(array2[j]);
				}
			}
			{
				int[] array2 = array[i].JIMBKGOPKHE;
				data.OIKGBOJBEIL();
				for (int j = 0; j < array2.Length; j++)
				{
					data.NGCIEKBKPJJ(array2[j]);
				}
			}
			AELABGDHIHC.Add(data);
		}
		return true;
	}

	//// RVA: 0xAB1180 Offset: 0xAB1180 VA: 0xAB1180 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "GKFMJAHKEMA_ValSkill.CAOGDCBPBAN");
		return 0;
	}
}
