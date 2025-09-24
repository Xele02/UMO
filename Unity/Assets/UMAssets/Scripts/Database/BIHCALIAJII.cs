
using System.Collections.Generic;

[System.Obsolete("Use BIHCALIAJII_GachaLimit", true)]
public class BIHCALIAJII { }
public class BIHCALIAJII_GachaLimit : DIHHCBACKGG_DbSection
{
	public class AICPHCIFEJL
	{
		public int EHOIENNDEDH_IdCrypted; // 0x8
		public int GNGNIKNNCNH_MVerCrypted; // 0xC
		public int HNJHPNPFAAN_EnabledCrypted; // 0x10
		public int AFOHGNGFDEB; // 0x14
		public int OFDPFGGKIKM; // 0x18
		public int BAMCNPNLEEN; // 0x1C
		public List<CEBFFLDKAEC_SecureInt> ADDCEJNOJLG_Scenes = new List<CEBFFLDKAEC_SecureInt>(); // 0x20

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } }// 0xC85150 DEMEPMAEJOO 0xC8406C HIGKAIDMOKN
		public int IJEKNCDIIAE_mver { get { return GNGNIKNNCNH_MVerCrypted ^ FBGGEFFJJHB_xor; } set { GNGNIKNNCNH_MVerCrypted = value ^ FBGGEFFJJHB_xor; } }// 0xC851E8 KJIMMIBDCIL 0xC841A4 DMEGNOKIKCD
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } }// 0xC83330 JPCJNLHHIPE 0xC84108 JJFJNEJLBDG
		public int FEFDGBPFKBJ_gid { get { return AFOHGNGFDEB ^ FBGGEFFJJHB_xor; } set { AFOHGNGFDEB = value ^ FBGGEFFJJHB_xor; } }// 0xC85038 BFIENFNOPIH 0xC84240 INLGKGJPBCP
		public int KOMKKBDABJP_end { get { return OFDPFGGKIKM ^ FBGGEFFJJHB_xor; } set { OFDPFGGKIKM = value ^ FBGGEFFJJHB_xor; } }// 0xC85280 MOMCBDJIGKO 0xC842DC NECMHGINPDE
		public int FOILNHKHHDF_pt { get { return BAMCNPNLEEN ^ FBGGEFFJJHB_xor; } set { BAMCNPNLEEN = value ^ FBGGEFFJJHB_xor; } }// 0xC833C8 FOFBHPJDHFO 0xC84378 LHPMDDKPJDP

		//// RVA: 0xC84E5C Offset: 0xC84E5C VA: 0xC84E5C
		//public uint CAOGDCBPBAN() { }
	}

	public static int FBGGEFFJJHB_xor = 0x274549; // 0x0
	public const int NJJBNDKIPEK = 100;
	public List<AICPHCIFEJL> CDENCMNHNGA_table; // 0x20
	private List<NNJFKLBPBNK_SecureString> IFBBNEGGCIH; // 0x28
	private List<CEBFFLDKAEC_SecureInt> JNJAOACIGOC; // 0x30

	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI_m_stringParam { get; private set; } // 0x24 IHKPIFIBECO GAMGELHIHHI DDDEJIJGGBJ
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK_m_intParam { get; private set; } // 0x2C KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB

	//// RVA: 0xC82F38 Offset: 0xC82F38 VA: 0xC82F38
	//public string EFEGBHACJAL_GetStringParam(string _LJNAKDMILMC_key, string _KKMJBMKHGNH_noval) { }

	//// RVA: 0xC8301C Offset: 0xC8301C VA: 0xC8301C
	//public int LPJLEHAJADA_GetIntParam(string _LJNAKDMILMC_key, int _KKMJBMKHGNH_noval) { }

	//// RVA: 0xC83100 Offset: 0xC83100 VA: 0xC83100
	//public BIHCALIAJII.AICPHCIFEJL IEOBBIBCNPH(int _HHGMPEEGFMA_GachaId) { }

	//// RVA: 0xC83200 Offset: 0xC83200 VA: 0xC83200
	public int DDHDJNCFNOC(int _HHGMPEEGFMA_GachaId)
	{
		AICPHCIFEJL a = CDENCMNHNGA_table.Find((AICPHCIFEJL _GHPLINIACBB_x) =>
		{
			//0xC850D0
			return _HHGMPEEGFMA_GachaId == _GHPLINIACBB_x.FEFDGBPFKBJ_gid;
		});
		if(a != null && a.PLALNIIBLOF_en == 2)
		{
			return a.FOILNHKHHDF_pt;
		}
		return 0;
	}

	//// RVA: 0xC83460 Offset: 0xC83460 VA: 0xC83460
	//public bool PJPDOCNJNGJ(int _HHGMPEEGFMA_GachaId, int _DNBFMLBNAEE_point) { }

	// RVA: 0xC8359C Offset: 0xC8359C VA: 0xC8359C
	public BIHCALIAJII_GachaLimit()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		CDENCMNHNGA_table = new List<AICPHCIFEJL>();
		OHJFBLFELNK_m_intParam = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		JNJAOACIGOC = new List<CEBFFLDKAEC_SecureInt>();
		FJOEBCMGDMI_m_stringParam = new Dictionary<string, NNJFKLBPBNK_SecureString>();
		IFBBNEGGCIH = new List<NNJFKLBPBNK_SecureString>();
		LMHMIIKCGPE = 47;
	}

	// RVA: 0xC83760 Offset: 0xC83760 VA: 0xC83760 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		CDENCMNHNGA_table.Clear();
		JNJAOACIGOC.Clear();
		IFBBNEGGCIH.Clear();
		OHJFBLFELNK_m_intParam.Clear();
		FJOEBCMGDMI_m_stringParam.Clear();
	}

	// RVA: 0xC83888 Offset: 0xC83888 VA: 0xC83888 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		DNKLFEPGGNC parser = DNKLFEPGGNC.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		{
			LNFHEEBKPNL[] array = parser.JFFLBNACFOH;
			for(int i = 0; i < array.Length; i++)
			{
				AICPHCIFEJL data = new AICPHCIFEJL();
				data.PPFNGGCBJKC_id = (int)array[i].PPFNGGCBJKC;
				data.IJEKNCDIIAE_mver = array[i].IJEKNCDIIAE;
				data.PLALNIIBLOF_en = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, (int)array[i].PLALNIIBLOF, 0);
				data.FEFDGBPFKBJ_gid = (int)array[i].FEFDGBPFKBJ;
				data.KOMKKBDABJP_end = (int)array[i].KOMKKBDABJP;
				data.FOILNHKHHDF_pt = (int)array[i].FOILNHKHHDF;
				data.ADDCEJNOJLG_Scenes.Clear();
				for(int j = 0; j < array[i].CIOKHGPEEKE.Length; j++)
				{
					CEBFFLDKAEC_SecureInt d = new CEBFFLDKAEC_SecureInt();
					d.DNJEJEANJGL_Value = (int)array[i].CIOKHGPEEKE[j];
					data.ADDCEJNOJLG_Scenes.Add(d);
				}
				CDENCMNHNGA_table.Add(data);
			}
		}
		{
			DNAMOAGODKD[] array = parser.BHGDNGHDDAC;
			for(int i = 0; i < array.Length; i++)
			{
				CEBFFLDKAEC_SecureInt data = new CEBFFLDKAEC_SecureInt();
				data.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG;
				OHJFBLFELNK_m_intParam.Add(array[i].LJNAKDMILMC, data);
				JNJAOACIGOC.Add(data);
			}
		}
		{
			MOGPEEGGGEC[] array = parser.MHGMDJNOLMI;
			for(int i = 0; i < array.Length; i++)
			{
				NNJFKLBPBNK_SecureString data = new NNJFKLBPBNK_SecureString();
				data.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG;
				FJOEBCMGDMI_m_stringParam.Add(array[i].LJNAKDMILMC, data);
				IFBBNEGGCIH.Add(data);
			}
		}
		return true;
	}

	// RVA: 0xC84414 Offset: 0xC84414 VA: 0xC84414 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		//CDENCMNHNGA_table = gacha_limit
		//	PPFNGGCBJKC_id = PPFNGGCBJKC_id
		//	IJEKNCDIIAE_mver = IJEKNCDIIAE_mver
		//	PLALNIIBLOF_en = PLALNIIBLOF_en
		//	FEFDGBPFKBJ_gid = FEFDGBPFKBJ_gid
		//	KOMKKBDABJP_end = KOMKKBDABJP_end
		//	FOILNHKHHDF_pt = FOILNHKHHDF_pt
		//	ADDCEJNOJLG_Scenes = CIOKHGPEEKE_sid
		TodoLogger.LogError(TodoLogger.DbJson, "BIHCALIAJII_GachaLimit.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0xC84D78 Offset: 0xC84D78 VA: 0xC84D78 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "BIHCALIAJII_GachaLimit.CAOGDCBPBAN");
		return 0;
	}
}
