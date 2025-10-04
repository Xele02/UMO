
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;

[System.Obsolete("Use LLKLAKGKNLD_LimitOver", true)]
public class LLKLAKGKNLD { }
public class LLKLAKGKNLD_LimitOver : DIHHCBACKGG_DbSection
{
	public class PBMKLFCEAAA
	{
		public List<int> IOKDGIGCJDA = new List<int>(); // 0x8
		public int EHOIENNDEDH_IdCrypted; // 0xC

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x18109E0 DEMEPMAEJOO_get_id 0x180FD54 HIGKAIDMOKN_set_id

		//// RVA: 0x180EC10 Offset: 0x180EC10 VA: 0x180EC10
		public int DEACAHNLMNI_getItemId(int _OIPCCBHIKIA_index)
		{
			return IOKDGIGCJDA[_OIPCCBHIKIA_index] ^ FBGGEFFJJHB_xor;
		}

		//// RVA: 0x1810570 Offset: 0x1810570 VA: 0x1810570
		//public uint CAOGDCBPBAN() { }
	}

	public class ENKHACHPPFA
	{
		public int PLNGGLJCGNM_Crypted; // 0x8
		public int AHGCGHAAHOO_ItemIdCrypted; // 0xC
		public int DNLHENCICKD_UcCrypted; // 0x10
		public int MMEINLBEOMK_NumCrypted; // 0x14
		public int EAJCFBCHIFB_RarityCrypted; // 0x18

		public int GNFJOONKCFH { get { return PLNGGLJCGNM_Crypted ^ FBGGEFFJJHB_xor; } set { PLNGGLJCGNM_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x18106E8 LOFPOONPOMC_get_ 0x180FDF8 KEGADDBFANM_set_
		public int GLCLFMGPMAN_ItemId { get { return AHGCGHAAHOO_ItemIdCrypted ^ FBGGEFFJJHB_xor; } set { AHGCGHAAHOO_ItemIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1810780 LNJAENEGDEL_get_ItemId 0x180FE94 JHIDBGCHOKL_set_ItemId
		public int ACGLMKEBMDL_uc { get { return DNLHENCICKD_UcCrypted ^ FBGGEFFJJHB_xor; } set { DNLHENCICKD_UcCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1810818 ALOLFIJOOHG_get_uc 0x180FFCC JDPCOMJIMHG_set_uc
		public int ADPPAIPFHML_num { get { return MMEINLBEOMK_NumCrypted ^ FBGGEFFJJHB_xor; } set { MMEINLBEOMK_NumCrypted = value ^ FBGGEFFJJHB_xor; } } //0x18108B0 LJMLHOOPGEM_get_num 0x180FF30 PHNIOCPOBGO_set_num
		public int EKLIPGELKCL_Rarity { get { return EAJCFBCHIFB_RarityCrypted ^ FBGGEFFJJHB_xor; } set { EAJCFBCHIFB_RarityCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1810948 OEEHBGECGKL_get_Rarity 0x1810068 GHLMHLJJBIG_set_Rarity

		//// RVA: 0x181061C Offset: 0x181061C VA: 0x181061C
		//public uint CAOGDCBPBAN() { }
	}

	public static int FBGGEFFJJHB_xor = 0x4adfd36; // 0x0
	private List<int> BDKOIDEMCEE = new List<int>(6); // 0x20
	private List<int> LOCCHKJGJDJ = new List<int>(26); // 0x24
	private List<int> BMEHMMIPELI = new List<int>(26); // 0x28
	public List<PBMKLFCEAAA> BODDKCKFLJF = new List<PBMKLFCEAAA>(6); // 0x2C
	public List<PBMKLFCEAAA> GPPJBOCJOFI = new List<PBMKLFCEAAA>(5); // 0x30
	public List<ENKHACHPPFA> PIPHIPNEJCM = new List<ENKHACHPPFA>(5); // 0x34
	public static int DMDKPBPBDKD = -1; // 0x4
	private int EHKFGCPHHJJ_MasterSwCrypted; // 0x3C

	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK_m_intParam { get; private set; } // 0x38 KLDCHOIPJGB AEMNOGNEBOJ_get_m_intParam DGKDBOAMNBB_set_m_intParam
	public int AJHBAOCLNDF_MasterSw { get { return EHKFGCPHHJJ_MasterSwCrypted ^ 0x46c0baf; } set { EHKFGCPHHJJ_MasterSwCrypted = value ^ 0x46c0baf; } } //0x180E790 EHDOJGNECHA_bgs 0x180E910 DAHLKLKBJDB_bgs

	//// RVA: 0x180E55C Offset: 0x180E55C VA: 0x180E55C
	public int ELFPIODODFF(int _JKGFBFPIMGA_Rarity)
	{
		return BDKOIDEMCEE[_JKGFBFPIMGA_Rarity - 1] ^ FBGGEFFJJHB_xor;
	}

	//// RVA: 0x180E628 Offset: 0x180E628 VA: 0x180E628
	public int JNLLKKHJCAD(int _JKGFBFPIMGA_Rarity, int _MJBODMOLOBC_luck)
	{
		int res = 0;
		if(AJHBAOCLNDF_MasterSw == 2)
		{
			if(_JKGFBFPIMGA_Rarity == 4)
			{
				res = LOCCHKJGJDJ[_MJBODMOLOBC_luck] ^ FBGGEFFJJHB_xor;
			}
			else if(_JKGFBFPIMGA_Rarity >= 5)
			{
				res = BMEHMMIPELI[_MJBODMOLOBC_luck] ^ FBGGEFFJJHB_xor;
			}
		}
		return res;
	}

	//// RVA: 0x180E7A4 Offset: 0x180E7A4 VA: 0x180E7A4
	public int BKCAECPCELG()
	{
		return LOCCHKJGJDJ.Count;
	}

	//// RVA: 0x180E82C Offset: 0x180E82C VA: 0x180E82C
	public int LPJLEHAJADA_GetIntParam(string _LJNAKDMILMC_key, int _KKMJBMKHGNH_noval)
	{
		if (!OHJFBLFELNK_m_intParam.ContainsKey(_LJNAKDMILMC_key))
			return _KKMJBMKHGNH_noval;
		return OHJFBLFELNK_m_intParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
	}

	//// RVA: 0x180E924 Offset: 0x180E924 VA: 0x180E924
	public void MNHPPJFNPCG(ref LimitOverStatusData DNNHDJPNIAK, int _JKGFBFPIMGA_Rarity, int _MJBODMOLOBC_luck, int DCMJPFFBINO)
	{
		int a = ELFPIODODFF(_JKGFBFPIMGA_Rarity);
		if(a < DCMJPFFBINO)
		{
			Debug.LogError("leafNum > leafMaxNum");
			DCMJPFFBINO = a;
		}
		a = JNLLKKHJCAD(_JKGFBFPIMGA_Rarity, _MJBODMOLOBC_luck);
		if(a < DCMJPFFBINO)
		{
			Debug.LogError("leafNum > GetLuckToLeafMaxNum");
			DCMJPFFBINO = a;
		}

		PBMKLFCEAAA t0 = BODDKCKFLJF[_JKGFBFPIMGA_Rarity - 1];
		PBMKLFCEAAA t1 = GPPJBOCJOFI[DCMJPFFBINO];

		for(int i = 0; i < 6; i++)
		{
			int b = 0;
			if(t1.DEACAHNLMNI_getItemId(i) == 1)
			{
				b = t0.DEACAHNLMNI_getItemId(i);
			}
			switch(i)
			{
				case 0:
					DNNHDJPNIAK.excellentRate = b;
					break;
				case 1:
					DNNHDJPNIAK.centerLiveSkillRate = b;
					break;
				case 2:
					DNNHDJPNIAK.excellentRate_SameMusicAttr = b;
					break;
				case 3:
					DNNHDJPNIAK.centerLiveSkillRate_SameMusicAttr = b;
					break;
				case 4:
					DNNHDJPNIAK.excellentRate_SameSeriesAttr = b;
					break;
				case 5:
					DNNHDJPNIAK.centerLiveSkillRate_SameSeriesAttr = b;
					break;
				default:
					break;
				case 7:
					DNNHDJPNIAK.excellentEffect = b;
					break;
			}
		}
	}

	// RVA: 0x180ECDC Offset: 0x180ECDC VA: 0x180ECDC
	public LLKLAKGKNLD_LimitOver()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 59;
		OHJFBLFELNK_m_intParam = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
	}

	// RVA: 0x180EECC Offset: 0x180EECC VA: 0x180EECC Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		BDKOIDEMCEE.Clear();
		LOCCHKJGJDJ.Clear();
		BMEHMMIPELI.Clear();
		BODDKCKFLJF.Clear();
		GPPJBOCJOFI.Clear();
		PIPHIPNEJCM.Clear();
		OHJFBLFELNK_m_intParam.Clear();
		AJHBAOCLNDF_MasterSw = 0;
	}

	// RVA: 0x180F058 Offset: 0x180F058 VA: 0x180F058 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		KMPKAHGGCHK parser = KMPKAHGGCHK.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		{
			IMMJLLOOKCF[] array = parser.GOKCDMKKCMD;
			for(int i = 0; i < array.Length; i++)
			{
				PBMKLFCEAAA data = new PBMKLFCEAAA();
				data.PPFNGGCBJKC_id = array[i].PNDNJDMIKAN;
				int[] array2 = array[i].CBDOEDKIOJK_ev;
				for(int j = 0; j < array2.Length; j++)
				{
					data.IOKDGIGCJDA.Add(array2[j] ^ FBGGEFFJJHB_xor);
				}
				BODDKCKFLJF.Add(data);
			}
		}
		{
			CPNJPEHHNOO[] array = parser.PFGDBAIFLGL;
			for (int i = 0; i < array.Length; i++)
			{
				PBMKLFCEAAA data = new PBMKLFCEAAA();
				data.PPFNGGCBJKC_id = array[i].GNFJOONKCFH;
				int[] array2 = array[i].CBDOEDKIOJK_ev;
				for (int j = 0; j < array2.Length; j++)
				{
					data.IOKDGIGCJDA.Add(array2[j] ^ FBGGEFFJJHB_xor);
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
				data.GLCLFMGPMAN_ItemId = array[i].GLCLFMGPMAN_ItemId;
				data.ADPPAIPFHML_num = array[i].ADPPAIPFHML_num;
				data.ACGLMKEBMDL_uc = array[i].ACGLMKEBMDL_uc;
				data.EKLIPGELKCL_Rarity = array[i].FBFLDFMFFOH_rar;
				PIPHIPNEJCM.Add(data);
			}
		}
		{
			ALNDGBMAILD[] array = parser.PJFGGPOEBAH;
			for (int i = 0; i < array.Length; i++)
			{
				BDKOIDEMCEE.Add(array[i].ELHALBFPLJK ^ FBGGEFFJJHB_xor);
			}
		}
		{
			DGILHAMKBKK[] array = parser.KIEKMCKCMGD;
			for (int i = 0; i < array.Length; i++)
			{
				LOCCHKJGJDJ.Add(array[i].FDAPNFDOHEJ ^ FBGGEFFJJHB_xor);
				BMEHMMIPELI.Add(array[i].EDFJKODHCAN ^ FBGGEFFJJHB_xor);
			}
		}
		{
			GGKLHGBDPDD[] array = parser.BHGDNGHDDAC;
			for (int i = 0; i < array.Length; i++)
			{
				CEBFFLDKAEC_SecureInt data = new CEBFFLDKAEC_SecureInt();
				data.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG_val;
				OHJFBLFELNK_m_intParam.Add(array[i].LJNAKDMILMC_key, data);
			}
		}
		AJHBAOCLNDF_MasterSw = JKAECBCNHAN_IsEnabled(LPJLEHAJADA_GetIntParam("master_mver", 0), LPJLEHAJADA_GetIntParam("master_en", 0), 0);
		return true;
	}

	// RVA: 0x1810104 Offset: 0x1810104 VA: 0x1810104 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		return true;
	}

	// RVA: 0x181010C Offset: 0x181010C VA: 0x181010C Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "LLKLAKGKNLD_LimitOver.CAOGDCBPBAN");
		return 0;
	}
}
