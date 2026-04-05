
using System.Collections.Generic;

[System.Obsolete("Use HGPEFPFODHO_HighScoreRanking", true)]
public class HGPEFPFODHO { }
public class HGPEFPFODHO_HighScoreRanking : DIHHCBACKGG_DbSection
{
	public class LGNDICJEDNE
	{
		public string ICGAKKCCFOG; // 0x8
		private int EHOIENNDEDH_IdCrypted; // 0xC
		private int CHGFBPOFICJ_RateCrypted; // 0x10
		private int ECDMGKIIKFL_PickupCrypted; // 0x14
		private int IPFBMBMNAGL_Crypted; // 0x18
		private int GFGDHCCCIBM_Crypted; // 0x1C
		private int LGJPGIHGNPP_Crypted; // 0x20
		private List<int> AHGCGHAAHOO_ItemIdCrypted = new List<int>(); // 0x24
		private List<int> FAEPDABICLE_Crypted = new List<int>(); // 0x28

		public int PPFNGGCBJKC_id { get { return FBGGEFFJJHB_xor ^ EHOIENNDEDH_IdCrypted; } set { EHOIENNDEDH_IdCrypted = FBGGEFFJJHB_xor ^ value; } } //0x1753ABC DEMEPMAEJOO_get_id 0x1752F5C HIGKAIDMOKN_set_id
		public int ADKDHKMPMHP_rate { get { return FBGGEFFJJHB_xor ^ CHGFBPOFICJ_RateCrypted; } set { CHGFBPOFICJ_RateCrypted = FBGGEFFJJHB_xor ^ value; } } //0x1753DC4 KCLKBHDMAFH_get_rate 0x1752FCC GOLECEILPOI_set_rate
		//Idx
		public int JOPPFEHKNFO_Pickup { get { return FBGGEFFJJHB_xor ^ ECDMGKIIKFL_PickupCrypted; } set { ECDMGKIIKFL_PickupCrypted = FBGGEFFJJHB_xor ^ value; } } //0x1753B28 FNIOGOJFLMG_get_Pickup 0x175303C AJIOKKIJBED_set_Pickup
		public int BGFPPGPJONG_QuestKeyId { get { return FBGGEFFJJHB_xor ^ IPFBMBMNAGL_Crypted; } set { IPFBMBMNAGL_Crypted = FBGGEFFJJHB_xor ^ value; } } //0x1753E30 LBMNPGFFCJN_bgs 0x17530AC NDNCLLKIJHA_bgs
		public int HDOEJDHGFLH_ItemFullId { get { return FBGGEFFJJHB_xor ^ GFGDHCCCIBM_Crypted; } set { GFGDHCCCIBM_Crypted = FBGGEFFJJHB_xor ^ value; } } //0x1753C78 OEGAADKHDEB_get_ItemFullId 0x1753264 NCJCOKLLAIL_set_ItemFullId
		public int GCKPDEDJFIC_ItemCount { get { return FBGGEFFJJHB_xor ^ LGJPGIHGNPP_Crypted; } set { LGJPGIHGNPP_Crypted = FBGGEFFJJHB_xor ^ value; } } //0x1753C0C BCHNEMPOICE_bgs 0x17532D4 EDIPLNMFHLD_bgs

		//// RVA: 0x1753CE4 Offset: 0x1753CE4 VA: 0x1753CE4
		public int FKNBLDPIPMC_GetItemCode(int _IOPHIHFOOEP_idx)
		{
			if (_IOPHIHFOOEP_idx > -1 && _IOPHIHFOOEP_idx < AHGCGHAAHOO_ItemIdCrypted.Count)
				return AHGCGHAAHOO_ItemIdCrypted[_IOPHIHFOOEP_idx] ^ FBGGEFFJJHB_xor;
			return 0;
		}

		//// RVA: 0x175311C Offset: 0x175311C VA: 0x175311C
		public void OEFHMMJFEKC_SetItemId(int _IOPHIHFOOEP_idx, int _JBGEEPFKIGG_val)
		{
			if (_IOPHIHFOOEP_idx < 0)
				return;
			AHGCGHAAHOO_ItemIdCrypted.Add(_JBGEEPFKIGG_val ^ FBGGEFFJJHB_xor);
		}

		//// RVA: 0x1753B94 Offset: 0x1753B94 VA: 0x1753B94
		public int AJMDFJFCIML_GetCount()
		{
			return AHGCGHAAHOO_ItemIdCrypted.Count;
		}

		//// RVA: 0x1753E9C Offset: 0x1753E9C VA: 0x1753E9C
		public int NKOHMLHLJGL_GetItemCount(int _IOPHIHFOOEP_idx)
		{
			if (_IOPHIHFOOEP_idx > -1 && _IOPHIHFOOEP_idx < FAEPDABICLE_Crypted.Count)
			{
				return FAEPDABICLE_Crypted[_IOPHIHFOOEP_idx] ^ FBGGEFFJJHB_xor;
			}
			return 0;
		}

		//// RVA: 0x17531C0 Offset: 0x17531C0 VA: 0x17531C0
		public void BLMLMOGEMCN(int _IOPHIHFOOEP_idx, int _JBGEEPFKIGG_val)
		{
			if (_IOPHIHFOOEP_idx < 0)
				return;
			FAEPDABICLE_Crypted.Add(_JBGEEPFKIGG_val ^ FBGGEFFJJHB_xor);
		}

		//// RVA: 0x1753F7C Offset: 0x1753F7C VA: 0x1753F7C
		public int HKDBDPPDCFG()
		{
			return FAEPDABICLE_Crypted.Count;
		}

		//// RVA: 0x1753FF4 Offset: 0x1753FF4 VA: 0x1753FF4
		//public void LHPDDGIJKNB_Reset() { }

		//// RVA: 0x1753430 Offset: 0x1753430 VA: 0x1753430
		//public uint CAOGDCBPBAN() { }
	}

	public static int FBGGEFFJJHB_xor; // 0x0
	public const int LDCCLENAKII = 1;
	public List<LGNDICJEDNE> PGHCCAMKCIO; // 0x20

	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI_m_stringParam { get; private set; } // 0x24 IHKPIFIBECO GAMGELHIHHI_get_m_stringParam DDDEJIJGGBJ_set_m_stringParam
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK_m_intParam { get; private set; } // 0x28 KLDCHOIPJGB AEMNOGNEBOJ_get_m_intParam DGKDBOAMNBB_set_m_intParam

	//// RVA: 0x175215C Offset: 0x175215C VA: 0x175215C
	public string EFEGBHACJAL_GetStringParam(string _LJNAKDMILMC_key, string _KKMJBMKHGNH_noval)
	{
		if (!FJOEBCMGDMI_m_stringParam.ContainsKey(_LJNAKDMILMC_key))
			return _KKMJBMKHGNH_noval;
		return FJOEBCMGDMI_m_stringParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
	}

	//// RVA: 0x1752240 Offset: 0x1752240 VA: 0x1752240
	public int LPJLEHAJADA_GetIntParam(string _LJNAKDMILMC_key, int _KKMJBMKHGNH_noval)
	{
		if (!OHJFBLFELNK_m_intParam.ContainsKey(_LJNAKDMILMC_key))
			return _KKMJBMKHGNH_noval;
		return OHJFBLFELNK_m_intParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
	}

	// RVA: 0x1752324 Offset: 0x1752324 VA: 0x1752324
	public HGPEFPFODHO_HighScoreRanking()
	{
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 52;
		FBGGEFFJJHB_xor = LPDNKHAIOLH.CEIBAFOCNCA_Int();
		PGHCCAMKCIO = new List<LGNDICJEDNE>();
		FJOEBCMGDMI_m_stringParam = new Dictionary<string, NNJFKLBPBNK_SecureString>();
		OHJFBLFELNK_m_intParam = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
	}

	// RVA: 0x17524A8 Offset: 0x17524A8 VA: 0x17524A8 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		PGHCCAMKCIO.Clear();
		FJOEBCMGDMI_m_stringParam.Clear();
		OHJFBLFELNK_m_intParam.Clear();
	}

	// RVA: 0x1752578 Offset: 0x1752578 VA: 0x1752578 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		GHFFJFCGDCB parser = GHFFJFCGDCB.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		MEEGJHBABOG(parser);
		{
			BAAELIGJGIJ[] array = parser.BHGDNGHDDAC;
			for(int i = 0; i < array.Length; i++)
			{
				CEBFFLDKAEC_SecureInt data = new CEBFFLDKAEC_SecureInt();
				data.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG_val;
				OHJFBLFELNK_m_intParam.Add(array[i].LJNAKDMILMC_key, data);
			}
		}
		{
			MKHHOIJDCAH[] array = parser.MHGMDJNOLMI;
			for (int i = 0; i < array.Length; i++)
			{
				NNJFKLBPBNK_SecureString data = new NNJFKLBPBNK_SecureString();
				data.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG_val;
				FJOEBCMGDMI_m_stringParam.Add(array[i].LJNAKDMILMC_key, data);
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
			data.PPFNGGCBJKC_id = array[i].PPFNGGCBJKC_id;
			data.ADKDHKMPMHP_rate = array[i].ADKDHKMPMHP_rate;
			data.JOPPFEHKNFO_Pickup = array[i].JOPPFEHKNFO_Pickup;
			data.BGFPPGPJONG_QuestKeyId = (int)array[i].LJNAKDMILMC_key;
			for(int j = 0; j < array[i].GLCLFMGPMAN_ItemId.Length; j++)
			{
				data.OEFHMMJFEKC_SetItemId(j, array[i].GLCLFMGPMAN_ItemId[j]);
			}
			for (int j = 0; j < array[i].ADPPAIPFHML_num.Length; j++)
			{
				data.BLMLMOGEMCN(j, array[i].ADPPAIPFHML_num[j]);
			}
			data.ICGAKKCCFOG = array[i].CHEHLCNHMII;
			data.HDOEJDHGFLH_ItemFullId = array[i].HDOEJDHGFLH_ItemFullId;
			data.GCKPDEDJFIC_ItemCount = array[i].DDLGKJOKGFJ;
			PGHCCAMKCIO.Add(data);
		}
		return true;
	}

	// RVA: 0x1753344 Offset: 0x1753344 VA: 0x1753344 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		return false;
	}

	// RVA: 0x175334C Offset: 0x175334C VA: 0x175334C Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "HGPEFPFODHO_HighScoreRanking.CAOGDCBPBAN");
		return 0;
	}

	//// RVA: 0x17536A8 Offset: 0x17536A8 VA: 0x17536A8
	public int FAJFAEOCHGK_GetItemId(int GFJGKJMBNMI)
	{
		for(int i = 0; i < PGHCCAMKCIO.Count; i++)
		{
			if(PGHCCAMKCIO[i].PPFNGGCBJKC_id == GFJGKJMBNMI + 1)
			{
				int idx = 0;
				if(PGHCCAMKCIO[i].JOPPFEHKNFO_Pickup >= 0)
				{
					idx = PGHCCAMKCIO[i].JOPPFEHKNFO_Pickup;
					if (PGHCCAMKCIO[i].AJMDFJFCIML_GetCount() <= PGHCCAMKCIO[i].JOPPFEHKNFO_Pickup)
					{
						idx = 0;
					}
				}
				if(PGHCCAMKCIO[i].GCKPDEDJFIC_ItemCount < 1)
				{
					return PGHCCAMKCIO[i].FKNBLDPIPMC_GetItemCode(idx);
				}
				return EKLNMHFCAOI_ItemManager.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(PGHCCAMKCIO[i].HDOEJDHGFLH_ItemFullId), 1);
			}
		}
		return 0;
	}
}
