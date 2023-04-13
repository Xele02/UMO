
using System.Collections.Generic;

[System.Obsolete("Use HGPEFPFODHO_HighScoreRanking", true)]
public class HGPEFPFODHO { }
public class HGPEFPFODHO_HighScoreRanking : DIHHCBACKGG_DbSection
{
	public class LGNDICJEDNE
	{
		public string ICGAKKCCFOG; // 0x8
		private int EHOIENNDEDH; // 0xC
		private int CHGFBPOFICJ; // 0x10
		private int ECDMGKIIKFL; // 0x14
		private int IPFBMBMNAGL; // 0x18
		private int GFGDHCCCIBM; // 0x1C
		private int LGJPGIHGNPP; // 0x20
		private List<int> AHGCGHAAHOO = new List<int>(); // 0x24
		private List<int> FAEPDABICLE = new List<int>(); // 0x28

		public int PPFNGGCBJKC { get { return FBGGEFFJJHB ^ EHOIENNDEDH; } set { EHOIENNDEDH = FBGGEFFJJHB ^ value; } } //0x1753ABC DEMEPMAEJOO 0x1752F5C HIGKAIDMOKN
		public int ADKDHKMPMHP_Rate { get { return FBGGEFFJJHB ^ CHGFBPOFICJ; } set { CHGFBPOFICJ = FBGGEFFJJHB ^ value; } } //0x1753DC4 KCLKBHDMAFH 0x1752FCC GOLECEILPOI
		public int JOPPFEHKNFO_Idx { get { return FBGGEFFJJHB ^ ECDMGKIIKFL; } set { ECDMGKIIKFL = FBGGEFFJJHB ^ value; } } //0x1753B28 FNIOGOJFLMG 0x175303C AJIOKKIJBED
		public int BGFPPGPJONG { get { return FBGGEFFJJHB ^ IPFBMBMNAGL; } set { IPFBMBMNAGL = FBGGEFFJJHB ^ value; } } //0x1753E30 LBMNPGFFCJN 0x17530AC NDNCLLKIJHA
		public int HDOEJDHGFLH_ItemFullId { get { return FBGGEFFJJHB ^ GFGDHCCCIBM; } set { GFGDHCCCIBM = FBGGEFFJJHB ^ value; } } //0x1753C78 OEGAADKHDEB 0x1753264 NCJCOKLLAIL
		public int GCKPDEDJFIC { get { return FBGGEFFJJHB ^ LGJPGIHGNPP; } set { LGJPGIHGNPP = FBGGEFFJJHB ^ value; } } //0x1753C0C BCHNEMPOICE 0x17532D4 EDIPLNMFHLD

		//// RVA: 0x1753CE4 Offset: 0x1753CE4 VA: 0x1753CE4
		public int FKNBLDPIPMC_GetItemId(int IOPHIHFOOEP)
		{
			if (IOPHIHFOOEP > -1 && IOPHIHFOOEP < AHGCGHAAHOO.Count)
				return AHGCGHAAHOO[IOPHIHFOOEP] ^ FBGGEFFJJHB;
			return 0;
		}

		//// RVA: 0x175311C Offset: 0x175311C VA: 0x175311C
		public void OEFHMMJFEKC(int IOPHIHFOOEP, int JBGEEPFKIGG)
		{
			if (IOPHIHFOOEP < 0)
				return;
			AHGCGHAAHOO.Add(JBGEEPFKIGG ^ FBGGEFFJJHB);
		}

		//// RVA: 0x1753B94 Offset: 0x1753B94 VA: 0x1753B94
		public int AJMDFJFCIML_GetCount()
		{
			return AHGCGHAAHOO.Count;
		}

		//// RVA: 0x1753E9C Offset: 0x1753E9C VA: 0x1753E9C
		public int NKOHMLHLJGL(int IOPHIHFOOEP)
		{
			if (IOPHIHFOOEP > -1 && IOPHIHFOOEP < FAEPDABICLE.Count)
			{
				return FAEPDABICLE[IOPHIHFOOEP] ^ FBGGEFFJJHB;
			}
			return 0;
		}

		//// RVA: 0x17531C0 Offset: 0x17531C0 VA: 0x17531C0
		public void BLMLMOGEMCN(int IOPHIHFOOEP, int JBGEEPFKIGG)
		{
			if (IOPHIHFOOEP < 0)
				return;
			FAEPDABICLE.Add(JBGEEPFKIGG ^ FBGGEFFJJHB);
		}

		//// RVA: 0x1753F7C Offset: 0x1753F7C VA: 0x1753F7C
		public int HKDBDPPDCFG()
		{
			return FAEPDABICLE.Count;
		}

		//// RVA: 0x1753FF4 Offset: 0x1753FF4 VA: 0x1753FF4
		//public void LHPDDGIJKNB() { }

		//// RVA: 0x1753430 Offset: 0x1753430 VA: 0x1753430
		//public uint CAOGDCBPBAN() { }
	}

	public static int FBGGEFFJJHB; // 0x0
	public const int LDCCLENAKII = 1;
	public List<LGNDICJEDNE> PGHCCAMKCIO; // 0x20

	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI_Strings { get; private set; } // 0x24 IHKPIFIBECO GAMGELHIHHI DDDEJIJGGBJ
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK_Ints { get; private set; } // 0x28 KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB

	//// RVA: 0x175215C Offset: 0x175215C VA: 0x175215C
	//public string EFEGBHACJAL(string LJNAKDMILMC, string KKMJBMKHGNH) { }

	//// RVA: 0x1752240 Offset: 0x1752240 VA: 0x1752240
	public int LPJLEHAJADA(string LJNAKDMILMC, int KKMJBMKHGNH)
	{
		if (!OHJFBLFELNK_Ints.ContainsKey(LJNAKDMILMC))
			return KKMJBMKHGNH;
		return OHJFBLFELNK_Ints[LJNAKDMILMC].DNJEJEANJGL_Value;
	}

	// RVA: 0x1752324 Offset: 0x1752324 VA: 0x1752324
	public HGPEFPFODHO_HighScoreRanking()
	{
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 52;
		FBGGEFFJJHB = LPDNKHAIOLH.CEIBAFOCNCA();
		PGHCCAMKCIO = new List<LGNDICJEDNE>();
		FJOEBCMGDMI_Strings = new Dictionary<string, NNJFKLBPBNK_SecureString>();
		OHJFBLFELNK_Ints = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
	}

	// RVA: 0x17524A8 Offset: 0x17524A8 VA: 0x17524A8 Slot: 8
	protected override void KMBPACJNEOF()
	{
		PGHCCAMKCIO.Clear();
		FJOEBCMGDMI_Strings.Clear();
		OHJFBLFELNK_Ints.Clear();
	}

	// RVA: 0x1752578 Offset: 0x1752578 VA: 0x1752578 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		GHFFJFCGDCB parser = GHFFJFCGDCB.HEGEKFMJNCC(DBBGALAPFGC);
		MEEGJHBABOG(parser);
		{
			BAAELIGJGIJ[] array = parser.BHGDNGHDDAC;
			for(int i = 0; i < array.Length; i++)
			{
				CEBFFLDKAEC_SecureInt data = new CEBFFLDKAEC_SecureInt();
				data.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG;
				OHJFBLFELNK_Ints.Add(array[i].LJNAKDMILMC, data);
			}
		}
		{
			MKHHOIJDCAH[] array = parser.MHGMDJNOLMI;
			for (int i = 0; i < array.Length; i++)
			{
				NNJFKLBPBNK_SecureString data = new NNJFKLBPBNK_SecureString();
				data.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG;
				FJOEBCMGDMI_Strings.Add(array[i].LJNAKDMILMC, data);
			}
		}
		return true;
	}

	//// RVA: 0x175284C Offset: 0x175284C VA: 0x175284C
	private bool MEEGJHBABOG(GHFFJFCGDCB AJLPJINDCBI)
	{
		FDGGBBPGKFB[] array = AJLPJINDCBI.HEHPAMADHGC;
		for(int i = 0; i < array.Length; i++)
		{
			LGNDICJEDNE data = new LGNDICJEDNE();
			data.PPFNGGCBJKC = array[i].PPFNGGCBJKC;
			data.ADKDHKMPMHP_Rate = array[i].ADKDHKMPMHP;
			data.JOPPFEHKNFO_Idx = array[i].JOPPFEHKNFO;
			data.BGFPPGPJONG = (int)array[i].LJNAKDMILMC;
			for(int j = 0; j < array[i].GLCLFMGPMAN.Length; j++)
			{
				data.OEFHMMJFEKC(j, array[i].GLCLFMGPMAN[j]);
			}
			for (int j = 0; j < array[i].ADPPAIPFHML.Length; j++)
			{
				data.BLMLMOGEMCN(j, array[i].ADPPAIPFHML[j]);
			}
			data.ICGAKKCCFOG = array[i].CHEHLCNHMII;
			data.HDOEJDHGFLH_ItemFullId = array[i].HDOEJDHGFLH;
			data.GCKPDEDJFIC = array[i].DDLGKJOKGFJ;
			PGHCCAMKCIO.Add(data);
		}
		return true;
	}

	// RVA: 0x1753344 Offset: 0x1753344 VA: 0x1753344 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return false;
	}

	// RVA: 0x175334C Offset: 0x175334C VA: 0x175334C Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "HGPEFPFODHO_HighScoreRanking.CAOGDCBPBAN");
		return 0;
	}

	//// RVA: 0x17536A8 Offset: 0x17536A8 VA: 0x17536A8
	public int FAJFAEOCHGK_GetItemId(int GFJGKJMBNMI)
	{
		for(int i = 0; i < PGHCCAMKCIO.Count; i++)
		{
			if(PGHCCAMKCIO[i].PPFNGGCBJKC == GFJGKJMBNMI + 1)
			{
				int idx = 0;
				if(PGHCCAMKCIO[i].JOPPFEHKNFO_Idx >= 0)
				{
					idx = PGHCCAMKCIO[i].JOPPFEHKNFO_Idx;
					if (PGHCCAMKCIO[i].AJMDFJFCIML_GetCount() <= PGHCCAMKCIO[i].JOPPFEHKNFO_Idx)
					{
						idx = 0;
					}
				}
				if(PGHCCAMKCIO[i].GCKPDEDJFIC < 1)
				{
					return PGHCCAMKCIO[i].FKNBLDPIPMC_GetItemId(idx);
				}
				return EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(PGHCCAMKCIO[i].HDOEJDHGFLH_ItemFullId), 1);
			}
		}
		return 0;
	}
}
