
using System.Collections.Generic;
using UnityEngine.Localization.SmartFormat.Utilities;
using XeSys;

[System.Obsolete("Use BKOGPDBKFFJ_EventRaid", true)]
public class BKOGPDBKFFJ { }
public class BKOGPDBKFFJ_EventRaid : DIHHCBACKGG_DbSection
{
	public class FODAKGKGJEL
	{
		public int OBGBAOLONDD_UniqueId; // 0x8
		public string OPFGFINHFCE_name; // 0xC
		public string HEDAGCNPHGD_RankingName; // 0x10
		public string OCGFKMHNEOF_name_for_api; // 0x14
		public string FEMMDNIELFC_Desc; // 0x18
		public long BONDDBOFBND_RankingStart; // 0x20
		public long HPNOGLIFJOP_RankingEnd; // 0x28
		public long EHHFFKAFOMC; // 0x30
		public long LNFKGHNHJKE_RankingEnd2; // 0x38
		public long JGMDAOACOJF_RewardStart; // 0x40
		public long IDDBFFBPNGI_RewardEnd; // 0x48
		public long KNLGKBBIBOH_RewardEnd2; // 0x50
		public int MJBKGOJBPAD_item_type; // 0x58 TicketType
		public sbyte POGEFBMBPCB_MonthOdd; // 0x5C
		public sbyte AHKNMANFILO_DayGroup; // 0x5D
		public sbyte MOEKELIIDEO_SaveIdx; // 0x5E
		public sbyte HKKNEAGCIEB_RankingSupport; // 0x5F
		public sbyte AHKPNPNOAMO_ExtreamOpen; // 0x60
		public string OMCAOJJGOGG_Lb; // 0x64
		private NNJFKLBPBNK_SecureString EBGIDCIIGDO_KeyPrefix = new NNJFKLBPBNK_SecureString(); // 0x68
		private NNJFKLBPBNK_SecureString NJKIMJAFCPC = new NNJFKLBPBNK_SecureString(); // 0x6C
		public List<int> JHPCPNJJHLI_RankingThreshold = new List<int>(); // 0x70
		public int HIOOGLEJBKM_StartAdventureId; // 0x74
		public int FJCADCDNPMP_EndAdventureId; // 0x78
		public int[] EJBGHLOOLBC_HelpIds; // 0x7C

		public string OCDMGOGMHGE_KeyPrefix { get { return EBGIDCIIGDO_KeyPrefix.DNJEJEANJGL_Value; } set { EBGIDCIIGDO_KeyPrefix.DNJEJEANJGL_Value = value; } } //0x19B1B0C HBAAAKFHDBB 0x19B1B38 NHJLJOIPOFK
		public string PJBILOFOCIC { get { return NJKIMJAFCPC.DNJEJEANJGL_Value; } set { NJKIMJAFCPC.DNJEJEANJGL_Value = value; } } //0x19B1B6C NOEFEAIFHCL 0x19B1B98 GJIJFGNONEL

		//// RVA: 0x19B1BCC Offset: 0x19B1BCC VA: 0x19B1BCC
		public void LHPDDGIJKNB_Reset()
		{
			OBGBAOLONDD_UniqueId = 0;
			BONDDBOFBND_RankingStart = 0;
			HPNOGLIFJOP_RankingEnd = 0;
			JGMDAOACOJF_RewardStart = 0;
			IDDBFFBPNGI_RewardEnd = 0;
			EHHFFKAFOMC = 0;
			MJBKGOJBPAD_item_type = 1;
			POGEFBMBPCB_MonthOdd = 0;
			AHKNMANFILO_DayGroup = 0;
			OPFGFINHFCE_name = null;
			HEDAGCNPHGD_RankingName = null;
			OCGFKMHNEOF_name_for_api = null;
			FEMMDNIELFC_Desc = null;
			OCDMGOGMHGE_KeyPrefix = "";
			PJBILOFOCIC = "";
			JHPCPNJJHLI_RankingThreshold.Clear();
			OMCAOJJGOGG_Lb = "";
			HIOOGLEJBKM_StartAdventureId = 0;
			FJCADCDNPMP_EndAdventureId = 0;
			EJBGHLOOLBC_HelpIds = null;
			AHKPNPNOAMO_ExtreamOpen = 0;
		}

		//// RVA: 0x19B1CC4 Offset: 0x19B1CC4 VA: 0x19B1CC4
		//public uint CAOGDCBPBAN() { }
	}

	public class NEOBLDCCPFI
	{
		public int FBGGEFFJJHB_xor; // 0x8
		private int EHOIENNDEDH_IdCrypted; // 0xC
		private int FMDDJNKEBBB_Crypted; // 0x10
		private int MDKGAAMBJDJ_Crypted; // 0x14
		private int GGEBNMPPEID_Crypted; // 0x18

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19B2FF0 DEMEPMAEJOO 0x19B3000 HIGKAIDMOKN
		public int CNKFPJCGNFE_SceneId { get { return FMDDJNKEBBB_Crypted ^ FBGGEFFJJHB_xor; } set { FMDDJNKEBBB_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x19B3010 GJBOGOFHGNP 0x19B3020 GJDGIDCMJMH
		public int GNFBMCGMCFO_BonusBefore { get { return MDKGAAMBJDJ_Crypted ^ FBGGEFFJJHB_xor; } set { MDKGAAMBJDJ_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x19B3030 NCIMMDJLPLJ 0x19B3040 HNAJAFBHOLM
		public int BFFGFAMJAIG_BonusAfter { get { return GGEBNMPPEID_Crypted ^ FBGGEFFJJHB_xor; } set { GGEBNMPPEID_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x19B3050 PKMNOMELPMN 0x19B3060 IABBJBAHKCE

		//// RVA: 0x19B3070 Offset: 0x19B3070 VA: 0x19B3070
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x19B309C Offset: 0x19B309C VA: 0x19B309C
		public void BAFFAONJPCE(int JBGJDEELLOP, int KNEFBLHBDBG, NPAJGBIFLHB JMHECKKKMLK)
		{
			BFFGFAMJAIG_BonusAfter = 0;
			FBGGEFFJJHB_xor = KNEFBLHBDBG;
			PPFNGGCBJKC_id = 0;
			CNKFPJCGNFE_SceneId = 0;
			GNFBMCGMCFO_BonusBefore = 0;
            ALFLHDKBNIB data = JMHECKKKMLK.OLACFKILCFD[JBGJDEELLOP];
			PPFNGGCBJKC_id = data.PPFNGGCBJKC_id;
			CNKFPJCGNFE_SceneId = data.CNKFPJCGNFE_SceneId;
			GNFBMCGMCFO_BonusBefore = data.GNFBMCGMCFO_BonusBefore;
			BFFGFAMJAIG_BonusAfter = data.BFFGFAMJAIG_BonusAfter;
        }

		//// RVA: 0x19B31E0 Offset: 0x19B31E0 VA: 0x19B31E0
		//public void LHPDDGIJKNB_Reset(int KNEFBLHBDBG) { }
	}

	public class LOJCDFAHECI
	{
		public int FBGGEFFJJHB_xor; // 0x8
		private int EHOIENNDEDH_IdCrypted; // 0xC
		private int MDKGAAMBJDJ_Crypted; // 0x10
		private int GGEBNMPPEID_Crypted; // 0x14

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19B2D08 DEMEPMAEJOO 0x19B2D18 HIGKAIDMOKN
		public int GNFBMCGMCFO_BonusBefore { get { return MDKGAAMBJDJ_Crypted ^ FBGGEFFJJHB_xor; } set { MDKGAAMBJDJ_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x19B2D28 NCIMMDJLPLJ 0x19B2D38 HNAJAFBHOLM
		public int BFFGFAMJAIG_BonusAfter { get { return GGEBNMPPEID_Crypted ^ FBGGEFFJJHB_xor; } set { GGEBNMPPEID_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x19B2D48 PKMNOMELPMN 0x19B2D58 IABBJBAHKCE

		//// RVA: 0x19B2D68 Offset: 0x19B2D68 VA: 0x19B2D68
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x19B2D8C Offset: 0x19B2D8C VA: 0x19B2D8C
		public void BAFFAONJPCE(int JBGJDEELLOP, int KNEFBLHBDBG, NPAJGBIFLHB JMHECKKKMLK)
		{
			PPFNGGCBJKC_id = 0;
			GNFBMCGMCFO_BonusBefore = 0;
			BFFGFAMJAIG_BonusAfter = 0;
            CNDLLOPINDF data = JMHECKKKMLK.MIOCOKLMLBD[JBGJDEELLOP];
			PPFNGGCBJKC_id = data.PPFNGGCBJKC_id;
			GNFBMCGMCFO_BonusBefore = data.GNFBMCGMCFO_BonusBefore;
			BFFGFAMJAIG_BonusAfter = data.BFFGFAMJAIG_BonusAfter;
        }

		//// RVA: 0x19B2E90 Offset: 0x19B2E90 VA: 0x19B2E90
		//public void LHPDDGIJKNB_Reset(int KNEFBLHBDBG) { }
	}

	public class LIPNCAJACFG
	{
		public int FBGGEFFJJHB_xor; // 0x8
		private int HHEEHHHLKHC_Crypted; // 0xC
		private int LGAIHLFAPDC_Crypted; // 0x10
		public List<int> KDNMBOBEGJM_GachaIds = new List<int>(); // 0x14

		public int KHPHAAMGMJP_EpId { get { return HHEEHHHLKHC_Crypted ^ FBGGEFFJJHB_xor; } set { HHEEHHHLKHC_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x19B2908 ABFDDKBBPCH 0x19B2918 MHDOIIEMDEH
		public int OFIAENKCJME_BaseBonus { get { return LGAIHLFAPDC_Crypted ^ FBGGEFFJJHB_xor; } set { LGAIHLFAPDC_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x19B2928 KADLAKFANGA 0x19B2938 AIDAPNCEPOB

		//// RVA: 0x19B2948 Offset: 0x19B2948 VA: 0x19B2948
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x19B2A20 Offset: 0x19B2A20 VA: 0x19B2A20
		public void BAFFAONJPCE(int JBGJDEELLOP, int KNEFBLHBDBG, NPAJGBIFLHB JMHECKKKMLK)
		{
			LHPDDGIJKNB_Reset(KNEFBLHBDBG);
            MDDFBKANJDJ data = JMHECKKKMLK.IEJLJIHIDJC[JBGJDEELLOP];
			KHPHAAMGMJP_EpId = data.KHPHAAMGMJP_EpId;
			OFIAENKCJME_BaseBonus = data.OFIAENKCJME_BaseBonus;
			for(int i = 0; i < data.JMLCLHHLJHM.Length; i++)
			{
				KDNMBOBEGJM_GachaIds.Add(data.JMLCLHHLJHM[i]);
			}
        }

		//// RVA: 0x19B2BF4 Offset: 0x19B2BF4 VA: 0x19B2BF4
		public void LHPDDGIJKNB_Reset(int KNEFBLHBDBG)
		{
			FBGGEFFJJHB_xor = KNEFBLHBDBG;
			KHPHAAMGMJP_EpId = 0;
			OFIAENKCJME_BaseBonus = 0;
			KDNMBOBEGJM_GachaIds.Clear();
		}
	}

	public class LEFPDKNJDBF
	{
		public int GLCLFMGPMAN_ItemId; // 0x8
		public int HMFFHLPNMPH_count; // 0xC
		public int NMKEOMCMIPP_RewardId; // 0x10
	}

	public class BKKPDFFANHE
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int DNBFMLBNAEE_point; // 0xC
		public List<LEFPDKNJDBF> AHJNPEAMCCH_rewards = new List<LEFPDKNJDBF>(); // 0x10
		public bool JOPPFEHKNFO_Pickup; // 0x14

		//// RVA: 0x19B1938 Offset: 0x19B1938 VA: 0x19B1938
		//public uint CAOGDCBPBAN() { }
	}

	public class HECLALNLPEC
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int PLALNIIBLOF_en; // 0xC
		public int MPLGPBNJDJB_FreeMusicId; // 0x10
		public int HMHHNHEPAPP_BossId; // 0x14
		public long PDBPFJJCADD_open_at; // 0x18
		public long FDBNFFNFOND_close_at; // 0x20

		//// RVA: 0x19B1FF4 Offset: 0x19B1FF4 VA: 0x19B1FF4
		//public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id) { }

		//// RVA: 0x19B2010 Offset: 0x19B2010 VA: 0x19B2010
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) { }
		//PPFNGGCBJKC_id = id
		//PLALNIIBLOF_en = en
		//MPLGPBNJDJB_FreeMusicId = f_music_id
		//HMHHNHEPAPP_BossId = boss_id
		//PDBPFJJCADD_open_at = open_at
		//FDBNFFNFOND_close_at = close_at

		//// RVA: 0x19B2250 Offset: 0x19B2250 VA: 0x19B2250
		public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, NPAJGBIFLHB JMHECKKKMLK)
		{
			PPFNGGCBJKC_id = _PPFNGGCBJKC_id;
			PDBPFJJCADD_open_at = 0;
			FDBNFFNFOND_close_at = 0;
			PLALNIIBLOF_en = 0;
			MPLGPBNJDJB_FreeMusicId = 0;
			HMHHNHEPAPP_BossId = 0;
            CJHLABKGKAA data = JMHECKKKMLK.GHIHAGAOPNC[_PPFNGGCBJKC_id - 1];
			PPFNGGCBJKC_id = (int)data.PPFNGGCBJKC_id;
			PLALNIIBLOF_en = (int)data.PLALNIIBLOF_en;
			MPLGPBNJDJB_FreeMusicId = (int)data.MPLGPBNJDJB_FreeMusicId;
			HMHHNHEPAPP_BossId = (int)data.HMHHNHEPAPP_BossId;
			PDBPFJJCADD_open_at = data.PDBPFJJCADD_open_at;
			FDBNFFNFOND_close_at = data.FDBNFFNFOND_close_at;
        }

		//// RVA: 0x19B23C4 Offset: 0x19B23C4 VA: 0x19B23C4
		//public uint CAOGDCBPBAN() { }
	}

	public class HAGIHCECBGH
	{
		public int PPFNGGCBJKC_id; // 0x8
		public string OPFGFINHFCE_name; // 0xC
		public int CPKMLLNADLJ_Serie; // 0x10
		public int PIPCIMIALOO_sp; // 0x14
		public int NNLAMKCDMEL_RewardDefeat; // 0x18
		public int FCDNMBBPBKI_RewardFirst; // 0x1C
		public int EPMCPGDIBHI_RewardMvp; // 0x20
		public int AKBHPFBDDOL_Val; // 0x24 Rate

		//// RVA: 0x19B1E54 Offset: 0x19B1E54 VA: 0x19B1E54
		public void KHEKNNFCAOI_Init(string blockName, KCFGJMAMFCH _IDLHJIOMJBK_data)
		{
			PPFNGGCBJKC_id = (int)_IDLHJIOMJBK_data.PPFNGGCBJKC_id;
			OPFGFINHFCE_name = DatabaseTextConverter.TranslateRaidBossName(blockName, PPFNGGCBJKC_id, _IDLHJIOMJBK_data.OPFGFINHFCE_name);
			CPKMLLNADLJ_Serie = _IDLHJIOMJBK_data.CPKMLLNADLJ_Serie;
			PIPCIMIALOO_sp = _IDLHJIOMJBK_data.PIPCIMIALOO_sp;
			NNLAMKCDMEL_RewardDefeat = _IDLHJIOMJBK_data.NNLAMKCDMEL_RewardDefeat;
			FCDNMBBPBKI_RewardFirst = _IDLHJIOMJBK_data.FCDNMBBPBKI_RewardFirst;
			EPMCPGDIBHI_RewardMvp = _IDLHJIOMJBK_data.EPMCPGDIBHI_RewardMvp;
			AKBHPFBDDOL_Val = _IDLHJIOMJBK_data.AKBHPFBDDOL_Val;
		}

		//// RVA: 0x19B1FA4 Offset: 0x19B1FA4 VA: 0x19B1FA4
		//public uint CAOGDCBPBAN() { }
	}

	public class PIDMOGPJNNA
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int LLNDMKBBNIJ_ver; // 0xC
		public int OMIEMNDOPKA; // 0x10
		public int ICLFADEFBIH_UtaGrade; // 0x14
		public int FJOLNJLLJEJ_rank; // 0x18
		public int OJLDNEGBFFG_DefeatRewardCount; // 0x1C
		public int DIDNBKKKEDK_FirstRewardCount; // 0x20
		public int CAFDIAFJDKP_MvpSpRewardCount; // 0x24
		public int EHOBDMHPMHB_DefeatSpRewardCount; // 0x28
		public int DIGJFGFKEJC_FirstSpRewardCount; // 0x2C
		public int JJELLPDAAEI_MvpRewardCount; // 0x30

		//// RVA: 0x19B33D4 Offset: 0x19B33D4 VA: 0x19B33D4
		public void KHEKNNFCAOI_Init(LJIJADDCDBE _IDLHJIOMJBK_data)
		{
			PPFNGGCBJKC_id = (int)_IDLHJIOMJBK_data.PPFNGGCBJKC_id;
			LLNDMKBBNIJ_ver = _IDLHJIOMJBK_data.LLNDMKBBNIJ_ver;
			OMIEMNDOPKA = _IDLHJIOMJBK_data.OMIEMNDOPKA;
			ICLFADEFBIH_UtaGrade = (int)_IDLHJIOMJBK_data.ICLFADEFBIH_UtaGrade;
			FJOLNJLLJEJ_rank = (int)_IDLHJIOMJBK_data.FJOLNJLLJEJ_rank;
			OJLDNEGBFFG_DefeatRewardCount = (int)_IDLHJIOMJBK_data.OJLDNEGBFFG_DefeatRewardCount;
			DIDNBKKKEDK_FirstRewardCount = (int)_IDLHJIOMJBK_data.DIDNBKKKEDK_FirstRewardCount;
			CAFDIAFJDKP_MvpSpRewardCount = (int)_IDLHJIOMJBK_data.CAFDIAFJDKP_MvpSpRewardCount;
			EHOBDMHPMHB_DefeatSpRewardCount = (int)_IDLHJIOMJBK_data.EHOBDMHPMHB_DefeatSpRewardCount;
			DIGJFGFKEJC_FirstSpRewardCount = (int)_IDLHJIOMJBK_data.DIGJFGFKEJC_FirstSpRewardCount;
			JJELLPDAAEI_MvpRewardCount = (int)_IDLHJIOMJBK_data.JJELLPDAAEI_MvpRewardCount;
		}

		//// RVA: 0x19B359C Offset: 0x19B359C VA: 0x19B359C
		//public uint CAOGDCBPBAN() { }
	}

	public class MNFPNLMPOEB
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int JIMJHIDEHNM_ApCounter; // 0xC ApCost
		public int KMHIOCCFPEM_PointBonus; // 0x10
		public int PIABNPEFLEJ_SupportBonus; // 0x14
		public int BMAHHKLNOGA_CanonBaseChargeValue; // 0x18
		public int DHGAILOFNIP_McCannonAdd; // 0x1C

		//// RVA: 0x19B2EA8 Offset: 0x19B2EA8 VA: 0x19B2EA8
		public void KHEKNNFCAOI_Init(KLBFLPLFPNF _IDLHJIOMJBK_data)
		{
			PPFNGGCBJKC_id = (int)_IDLHJIOMJBK_data.PPFNGGCBJKC_id;
			JIMJHIDEHNM_ApCounter = (int)_IDLHJIOMJBK_data.JIMJHIDEHNM_ApCounter;
			KMHIOCCFPEM_PointBonus = (int)_IDLHJIOMJBK_data.KMHIOCCFPEM_PointBonus;
			PIABNPEFLEJ_SupportBonus = (int)_IDLHJIOMJBK_data.PIABNPEFLEJ_SupportBonus;
			BMAHHKLNOGA_CanonBaseChargeValue = (int)_IDLHJIOMJBK_data.BMAHHKLNOGA_CanonBaseChargeValue;
			DHGAILOFNIP_McCannonAdd = (int)_IDLHJIOMJBK_data.DHGAILOFNIP_McCannonAdd;
		}

		//// RVA: 0x19B2FA8 Offset: 0x19B2FA8 VA: 0x19B2FA8
		//public uint CAOGDCBPBAN() { }
	}

	public class KHPDKADKOCP
	{
		public enum GMHNAPBHMMA
		{
			KBHGPMNGALJ_1_Costume = 1,
			PFIOMNHDHCO_2_Valkyrie = 2,
			EKHDECEEFFJ = 3,
			LMIDAHNABGK = 11,
			ALMFFEOGPDN = 12,
			AHKGJELHFKN = 13,
		}

		public int PPFNGGCBJKC_id; // 0x8
		public int INDDJNMPONH_type; // 0xC
		public int GLCLFMGPMAN_ItemId; // 0x10

		//// RVA: 0x19B2408 Offset: 0x19B2408 VA: 0x19B2408
		public void KHEKNNFCAOI_Init(JHBMNFIHGBI _IDLHJIOMJBK_data)
		{
			PPFNGGCBJKC_id = (int)_IDLHJIOMJBK_data.PPFNGGCBJKC_id;
			INDDJNMPONH_type = (int)_IDLHJIOMJBK_data.GBJFNGCDKPM_typ;
			GLCLFMGPMAN_ItemId = (int)_IDLHJIOMJBK_data.GLCLFMGPMAN_ItemId;
		}

		//// RVA: 0x19B2490 Offset: 0x19B2490 VA: 0x19B2490
		//public uint CAOGDCBPBAN() { }
	}

	public class LDCCKEPPFMG
	{
		public class NEGFCJPAPLC
		{
			public int AIHOJKFNEEN_itm; // 0x8
			public int BFINGCJHOHI_cnt; // 0xC
			public int EHKJFNAABMC_rat; // 0x10 Rate
			public int DOOGFEGEKLG_max; // 0x14
			public int DCFAPPHINAO_IsPickup; // 0x18

			//// RVA: 0x19B28D0 Offset: 0x19B28D0 VA: 0x19B28D0
			//public uint CAOGDCBPBAN() { }
		}

		public int PPFNGGCBJKC_id; // 0x8
		public NEGFCJPAPLC[] CMIGGBMMBKK_drop; // 0xC

		//// RVA: 0x19B24BC Offset: 0x19B24BC VA: 0x19B24BC
		public void KHEKNNFCAOI_Init(KGNNHHFGLBG _IDLHJIOMJBK_data)
		{
			PPFNGGCBJKC_id = (int)_IDLHJIOMJBK_data.PPFNGGCBJKC_id;
			CMIGGBMMBKK_drop = new NEGFCJPAPLC[_IDLHJIOMJBK_data.AIHOJKFNEEN_itm.Length];
			for(int i = 0; i < _IDLHJIOMJBK_data.AIHOJKFNEEN_itm.Length; i++)
			{
				CMIGGBMMBKK_drop[i] = new NEGFCJPAPLC();
				CMIGGBMMBKK_drop[i].AIHOJKFNEEN_itm = (int)_IDLHJIOMJBK_data.AIHOJKFNEEN_itm[i];
				CMIGGBMMBKK_drop[i].BFINGCJHOHI_cnt = (int)_IDLHJIOMJBK_data.BFINGCJHOHI_cnt[i];
				CMIGGBMMBKK_drop[i].EHKJFNAABMC_rat = (int)_IDLHJIOMJBK_data.EHKJFNAABMC_rat[i];
				CMIGGBMMBKK_drop[i].DOOGFEGEKLG_max = (int)_IDLHJIOMJBK_data.DOOGFEGEKLG_max[i];
				CMIGGBMMBKK_drop[i].DCFAPPHINAO_IsPickup = (int)_IDLHJIOMJBK_data.DCFAPPHINAO_IsPickup[i];
			}
		}

		//// RVA: 0x19B2820 Offset: 0x19B2820 VA: 0x19B2820
		//public uint CAOGDCBPBAN() { }
	}

	public class NJLOJAKKGFK : AKIIJBEJOEP
	{
		public int DJJGNDCMNHF_BonusValue; // 0x94
		public int MCNEIJAOLNO_Select; // 0x98 RateNormal
		public int PENMGPNPHHG_BonusSp; // 0x9C
		public int PDJJELPFMJB_RateSp; // 0xA0

		//// RVA: 0x19B31FC Offset: 0x19B31FC VA: 0x19B31FC
		//public void LHPDDGIJKNB_Reset(string _JOPOPMLFINI_QuestName, int _PPFNGGCBJKC_id, int KNEFBLHBDBG) { }

		//// RVA: 0x19B321C Offset: 0x19B321C VA: 0x19B321C
		public void BKEJPFLCLFC(string _JOPOPMLFINI_QuestName, int _PPFNGGCBJKC_id, int KNEFBLHBDBG, NPAJGBIFLHB JMHECKKKMLK)
		{
			FDKFKPGFHNE(_JOPOPMLFINI_QuestName, _PPFNGGCBJKC_id, KNEFBLHBDBG, JMHECKKKMLK);
            DFPOGOFGFBN data = JMHECKKKMLK.HBMGNHBFPHC[_PPFNGGCBJKC_id - 1];
			DJJGNDCMNHF_BonusValue = (int)data.DJJGNDCMNHF_BonusValue;
			MCNEIJAOLNO_Select = (int)data.MCNEIJAOLNO_Select;
			PENMGPNPHHG_BonusSp = (int)data.PENMGPNPHHG_BonusSp;
			PDJJELPFMJB_RateSp = (int)data.PDJJELPFMJB_RateSp;
			FEMMDNIELFC_Desc = DatabaseTextConverter.TranslateEventMissionDesc(_JOPOPMLFINI_QuestName, 10000 + _PPFNGGCBJKC_id, data.FEMMDNIELFC_Desc);
        }

		//// RVA: 0x19B336C Offset: 0x19B336C VA: 0x19B336C
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x19B33A4 Offset: 0x19B33A4 VA: 0x19B33A4
		public int ECEKNKIDING(bool _MPKBLMCNHOM_MissionIsSpecial)
		{
			return _MPKBLMCNHOM_MissionIsSpecial ? PENMGPNPHHG_BonusSp : DJJGNDCMNHF_BonusValue;
		}

		//// RVA: 0x19B33B8 Offset: 0x19B33B8 VA: 0x19B33B8
		public int JKMDPGCCAJP(bool _MPKBLMCNHOM_MissionIsSpecial)
		{
			return _MPKBLMCNHOM_MissionIsSpecial ? PDJJELPFMJB_RateSp : MCNEIJAOLNO_Select;
		}
	}

	public FODAKGKGJEL NGHKJOEDLIP_Settings = new FODAKGKGJEL(); // 0x20
	public List<AKIIJBEJOEP> NNMPGOAGEOL_quests = new List<AKIIJBEJOEP>(); // 0x24
	public List<HECLALNLPEC> IJJHFGOIDOK_EventMusic = new List<HECLALNLPEC>(); // 0x28
	public List<HAGIHCECBGH> GJFJLEOGFLD_RaidBoss = new List<HAGIHCECBGH>(); // 0x2C
	public List<PIDMOGPJNNA> BFKJBHMHKAH_BossLevelsInfo = new List<PIDMOGPJNNA>(); // 0x30
	public List<MNFPNLMPOEB> NFOECEGILLC_AttacksInfo = new List<MNFPNLMPOEB>(); // 0x34
	public List<KHPDKADKOCP> HKLGCBKONJG_ValkCosBonusList = new List<KHPDKADKOCP>(); // 0x38
	public List<LDCCKEPPFMG> FNHDKHBNBBN_Rewards = new List<LDCCKEPPFMG>(); // 0x3C
	public List<NJLOJAKKGFK> HDMADAHNLDN_Missions = new List<NJLOJAKKGFK>(); // 0x40 // bossmission
	public List<NEOBLDCCPFI> GEGAEDDGNMA_Bonuses = new List<NEOBLDCCPFI>(); // 0x44//EpBonusByScene
	public List<LOJCDFAHECI> OGMHMAGDNAM_EpBonusBySceneRarity = new List<LOJCDFAHECI>(); // 0x48
	public List<LIPNCAJACFG> LHAKGDAGEMM_EpBonusInfos = new List<LIPNCAJACFG>(); // 0x4C
	public List<IJNOIMLNBGN> LLCLJBEJOPM_BannerInfo = new List<IJNOIMLNBGN>(); // 0x58

	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI_m_stringParam { get; private set; } // 0x50 IHKPIFIBECO GAMGELHIHHI DDDEJIJGGBJ
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK_m_intParam { get; private set; } // 0x54 KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB

	//// RVA: 0xC8A760 Offset: 0xC8A760 VA: 0xC8A760
	public PIDMOGPJNNA ODMCAHDEEBK(int _ANAJIAENLNB_lv)
	{
		if(_ANAJIAENLNB_lv > 0 && _ANAJIAENLNB_lv <= BFKJBHMHKAH_BossLevelsInfo.Count)
		{
			return BFKJBHMHKAH_BossLevelsInfo[_ANAJIAENLNB_lv - 1];
		}
		return null;
	}

	//// RVA: 0xC8A820 Offset: 0xC8A820 VA: 0xC8A820
	public HAGIHCECBGH POCOCNENCOE_GetBossInfo(int _MFMPCHIJINJ_BossType)
	{
		if(_MFMPCHIJINJ_BossType > 0 && _MFMPCHIJINJ_BossType - 1 < GJFJLEOGFLD_RaidBoss.Count)
		{
			return GJFJLEOGFLD_RaidBoss[_MFMPCHIJINJ_BossType - 1];
		}
		return null;
	}

	//// RVA: 0xC8A8E0 Offset: 0xC8A8E0 VA: 0xC8A8E0
	public string EFEGBHACJAL_GetStringParam(string _LJNAKDMILMC_key, string _KKMJBMKHGNH_noval)
	{
		if(!FJOEBCMGDMI_m_stringParam.ContainsKey(_LJNAKDMILMC_key))
			return _KKMJBMKHGNH_noval;
		return FJOEBCMGDMI_m_stringParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
	}

	//// RVA: 0xC8A9C4 Offset: 0xC8A9C4 VA: 0xC8A9C4
	public bool GNKACELEIAC(string _LJNAKDMILMC_key)
	{
		return FJOEBCMGDMI_m_stringParam.ContainsKey(_LJNAKDMILMC_key);
	}

	//// RVA: 0xC8AA44 Offset: 0xC8AA44 VA: 0xC8AA44
	public int LPJLEHAJADA_GetIntParam(string _LJNAKDMILMC_key, int _KKMJBMKHGNH_noval)
	{
		if(!OHJFBLFELNK_m_intParam.ContainsKey(_LJNAKDMILMC_key))
			return _KKMJBMKHGNH_noval;
		return OHJFBLFELNK_m_intParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
	}

	// RVA: 0xC8AB28 Offset: 0xC8AB28 VA: 0xC8AB28
	public BKOGPDBKFFJ_EventRaid()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		OHJFBLFELNK_m_intParam = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		FJOEBCMGDMI_m_stringParam = new Dictionary<string, NNJFKLBPBNK_SecureString>();
		LMHMIIKCGPE = 38;
	}

	// RVA: 0xC8AEE4 Offset: 0xC8AEE4 VA: 0xC8AEE4 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		NGHKJOEDLIP_Settings.LHPDDGIJKNB_Reset();
		NNMPGOAGEOL_quests.Clear();
		IJJHFGOIDOK_EventMusic.Clear();
		OHJFBLFELNK_m_intParam.Clear();
		FJOEBCMGDMI_m_stringParam.Clear();
		GJFJLEOGFLD_RaidBoss.Clear();
		BFKJBHMHKAH_BossLevelsInfo.Clear();
		NFOECEGILLC_AttacksInfo.Clear();
		HKLGCBKONJG_ValkCosBonusList.Clear();
		FNHDKHBNBBN_Rewards.Clear();
		GEGAEDDGNMA_Bonuses.Clear();
		OGMHMAGDNAM_EpBonusBySceneRarity.Clear();
		LHAKGDAGEMM_EpBonusInfos.Clear();
	}

	// RVA: 0xC8B160 Offset: 0xC8B160 VA: 0xC8B160 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		NPAJGBIFLHB data = NPAJGBIFLHB.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		DGKKMKLCEDF_DeserializeSetting(data);
		CFOFJPLEDEA(data);
		GJEHPJJBCDE(data);
		JFIFGGCOJHN(data);
		EPGINHNJKGL(data);
		ONOPGNAJBPH(data);
		HFLMDOKCAAP(data);
		DOJBHOBIMCG(data);
		PCKILNACEKE(data);
		ABICOINNGEK(data);
		EGLHCMDNFOE(data);
		JBNBGGDDEGG(data);
		for(int i = 0; i < data.BHGDNGHDDAC.Length; i++)
		{
			CEBFFLDKAEC_SecureInt d = new CEBFFLDKAEC_SecureInt();
			d.DNJEJEANJGL_Value = data.BHGDNGHDDAC[i].JBGEEPFKIGG_val;
			OHJFBLFELNK_m_intParam.Add(data.BHGDNGHDDAC[i].LJNAKDMILMC_key, d);
		}
		for(int i = 0; i < data.MHGMDJNOLMI.Length; i++)
		{
			NNJFKLBPBNK_SecureString d = new NNJFKLBPBNK_SecureString();
			d.DNJEJEANJGL_Value = data.MHGMDJNOLMI[i].JBGEEPFKIGG_val;
			FJOEBCMGDMI_m_stringParam.Add(data.MHGMDJNOLMI[i].LJNAKDMILMC_key, d);
		}

		UnityEngine.Debug.LogError(NGHKJOEDLIP_Settings.OPFGFINHFCE_name+" "+NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId);

		// Update dates
		UMOEventList.EventData CurrenEvent = UMOEventList.GetCurrentEvent();
		if (CurrenEvent != null && CurrenEvent.EnableBlock(JIKKNHIAEKG_BlockName))
		{
			UnityEngine.Debug.LogError("Raid : "+NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart+" "+NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd+" "+NGHKJOEDLIP_Settings.EHHFFKAFOMC+" "+NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2+" "+NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart+" "+NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd+" "+NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2);
			System.DateTime date = Utility.GetLocalDateTime(Utility.GetCurrentUnixTime());
			System.DateTime date2 = Utility.GetLocalDateTime(NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart);
			date = date.AddDays(-1);
			long offset = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, date2.Hour, date2.Minute, date2.Second) - NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
			if (NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart != 0) NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart += offset;
			if (NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd != 0) NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd += offset;
			if (NGHKJOEDLIP_Settings.EHHFFKAFOMC != 0) NGHKJOEDLIP_Settings.EHHFFKAFOMC += offset;
			if (NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2 != 0) NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2 += offset;
			if (NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart != 0) NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart += offset;
			if (NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd != 0) NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd += offset;
			if (NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 != 0) NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 += offset;

			for(int i = 0; i < IJJHFGOIDOK_EventMusic.Count; i++)
			{
				if (IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at != 0) IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
				if (IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_close_at != 0) IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_close_at = NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
			}
			for(int i = 0; i < NNMPGOAGEOL_quests.Count; i++)
			{
				if (NNMPGOAGEOL_quests[i].KJBGCLPMLCG_OpenedAt != 0) NNMPGOAGEOL_quests[i].KJBGCLPMLCG_OpenedAt = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
				if (NNMPGOAGEOL_quests[i].GJFPFFBAKGK_CloseAt != 0) NNMPGOAGEOL_quests[i].GJFPFFBAKGK_CloseAt = NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
			}
			for(int i = 0; i < LLCLJBEJOPM_BannerInfo.Count; i++)
			{
				if (LLCLJBEJOPM_BannerInfo[i].PDBPFJJCADD_open_at != 0) LLCLJBEJOPM_BannerInfo[i].PDBPFJJCADD_open_at = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
				if (LLCLJBEJOPM_BannerInfo[i].FDBNFFNFOND_close_at != 0) LLCLJBEJOPM_BannerInfo[i].FDBNFFNFOND_close_at = NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
			}
		}

		return true;
	}

	// RVA: 0xC8CC78 Offset: 0xC8CC78 VA: 0xC8CC78 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		return true;
	}

	//// RVA: 0xC8B4B8 Offset: 0xC8B4B8 VA: 0xC8B4B8
	private bool DGKKMKLCEDF_DeserializeSetting(NPAJGBIFLHB KNOEHKKNIJA)
	{
		DGALLBPNAMN data = KNOEHKKNIJA.HMBHNLCFDIH;
		NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId = (int)data.OBGBAOLONDD_UniqueId;
		NGHKJOEDLIP_Settings.OPFGFINHFCE_name = data.OPFGFINHFCE_name;
		NGHKJOEDLIP_Settings.HEDAGCNPHGD_RankingName = data.HEDAGCNPHGD_RankingName;
		NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api = data.OCGFKMHNEOF_name_for_api;
		NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart = data.BONDDBOFBND_RankingStart;
		NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd = data.HPNOGLIFJOP_RankingEnd;
		NGHKJOEDLIP_Settings.EHHFFKAFOMC = data.EHHFFKAFOMC;
		NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2 = data.LNFKGHNHJKE_RankingEnd2;
		NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart = data.JGMDAOACOJF_RewardStart;
		NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd = data.IDDBFFBPNGI_RewardEnd;
		NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 = data.KNLGKBBIBOH_RewardEnd2;
		NGHKJOEDLIP_Settings.POGEFBMBPCB_MonthOdd = (sbyte)data.JMJDLDEIFKE;
		NGHKJOEDLIP_Settings.AHKNMANFILO_DayGroup = (sbyte)data.AHKNMANFILO_DayGroup;
		NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx = (sbyte)data.MOEKELIIDEO_SaveIdx;
		NGHKJOEDLIP_Settings.OCDMGOGMHGE_KeyPrefix = data.OCDMGOGMHGE_KeyPrefix;
		NGHKJOEDLIP_Settings.PJBILOFOCIC = data.PJBILOFOCIC;
		NGHKJOEDLIP_Settings.MJBKGOJBPAD_item_type = data.MJBKGOJBPAD_item_type;
		NGHKJOEDLIP_Settings.FEMMDNIELFC_Desc = data.FEMMDNIELFC_Desc;
		NGHKJOEDLIP_Settings.HKKNEAGCIEB_RankingSupport = (sbyte)data.HKKNEAGCIEB_RankingSupport;
		NGHKJOEDLIP_Settings.HIOOGLEJBKM_StartAdventureId = data.HIOOGLEJBKM_StartAdventureId;
		NGHKJOEDLIP_Settings.FJCADCDNPMP_EndAdventureId = data.FJCADCDNPMP_EndAdventureId;
		NGHKJOEDLIP_Settings.EJBGHLOOLBC_HelpIds = data.EJBGHLOOLBC_HelpIds;
		NGHKJOEDLIP_Settings.AHKPNPNOAMO_ExtreamOpen = (sbyte)data.AHKPNPNOAMO_ExtreamOpen;
		NGHKJOEDLIP_Settings.OMCAOJJGOGG_Lb = data.OMCAOJJGOGG_Lb;
		for(int i = 0; i < data.JHPCPNJJHLI_RankingThreshold.Length; i++)
		{
			if(data.JHPCPNJJHLI_RankingThreshold[i] < 1001)
			{
				NGHKJOEDLIP_Settings.JHPCPNJJHLI_RankingThreshold.Add(data.JHPCPNJJHLI_RankingThreshold[i]);
			}
		}
		IJNOIMLNBGN.KHEKNNFCAOI_Init(JIKKNHIAEKG_BlockName, LLCLJBEJOPM_BannerInfo, KNOEHKKNIJA);
		return true;
	}

	//// RVA: 0xC8BC10 Offset: 0xC8BC10 VA: 0xC8BC10
	private bool CFOFJPLEDEA(NPAJGBIFLHB KNOEHKKNIJA)
	{
		MJDMKEIPOLH[] array = KNOEHKKNIJA.MDDOGIAFDEI;
		int xor = (int)Utility.GetCurrentUnixTime() * 11 + 1;
		for(int i = 0; i < array.Length; i++)
		{
			AKIIJBEJOEP data = new AKIIJBEJOEP();
			data.KHEKNNFCAOI_Init(JIKKNHIAEKG_BlockName, i + 1, xor, KNOEHKKNIJA);
			NNMPGOAGEOL_quests.Add(data);
			xor += 13;
		}
		return true;
	}

	//// RVA: 0xC8BDA8 Offset: 0xC8BDA8 VA: 0xC8BDA8
	private bool GJEHPJJBCDE(NPAJGBIFLHB KNOEHKKNIJA)
	{
		for(int i = 0; i < KNOEHKKNIJA.GHIHAGAOPNC.Length; i++)
		{
			HECLALNLPEC data = new HECLALNLPEC();
			data.KHEKNNFCAOI_Init(i + 1, KNOEHKKNIJA);
			IJJHFGOIDOK_EventMusic.Add(data);
		}
		return true;
	}

	//// RVA: 0xC8BEC8 Offset: 0xC8BEC8 VA: 0xC8BEC8
	private bool JFIFGGCOJHN(NPAJGBIFLHB KNOEHKKNIJA)
	{
		for(int i = 0; i < KNOEHKKNIJA.EENBPAPDNBP.Length; i++)
		{
			HAGIHCECBGH data = new HAGIHCECBGH();
			data.KHEKNNFCAOI_Init(JIKKNHIAEKG_BlockName, KNOEHKKNIJA.EENBPAPDNBP[i]);
			GJFJLEOGFLD_RaidBoss.Add(data);
		}
		return true;
	}

	//// RVA: 0xC8C038 Offset: 0xC8C038 VA: 0xC8C038
	private bool EPGINHNJKGL(NPAJGBIFLHB KNOEHKKNIJA)
	{
		for(int i = 0; i < KNOEHKKNIJA.JLKPDLCFEIM.Length; i++)
		{
			PIDMOGPJNNA data = new PIDMOGPJNNA();
			data.KHEKNNFCAOI_Init(KNOEHKKNIJA.JLKPDLCFEIM[i]);
			BFKJBHMHKAH_BossLevelsInfo.Add(data);
		}
		return true;
	}

	//// RVA: 0xC8C1A8 Offset: 0xC8C1A8 VA: 0xC8C1A8
	private bool ONOPGNAJBPH(NPAJGBIFLHB KNOEHKKNIJA)
	{
		for(int i = 0; i < KNOEHKKNIJA.JFLFHONDDNM.Length; i++)
		{
			MNFPNLMPOEB data = new MNFPNLMPOEB();
			data.KHEKNNFCAOI_Init(KNOEHKKNIJA.JFLFHONDDNM[i]);
			NFOECEGILLC_AttacksInfo.Add(data);
		}
		return true;
	}

	//// RVA: 0xC8C318 Offset: 0xC8C318 VA: 0xC8C318
	private bool HFLMDOKCAAP(NPAJGBIFLHB KNOEHKKNIJA)
	{
		for(int i = 0; i < KNOEHKKNIJA.PNMLJIPOOPO.Length; i++)
		{
			KHPDKADKOCP data = new KHPDKADKOCP();
			data.KHEKNNFCAOI_Init(KNOEHKKNIJA.PNMLJIPOOPO[i]);
			HKLGCBKONJG_ValkCosBonusList.Add(data);
		}
		return true;
	}

	//// RVA: 0xC8C488 Offset: 0xC8C488 VA: 0xC8C488
	private bool DOJBHOBIMCG(NPAJGBIFLHB KNOEHKKNIJA)
	{
		for(int i = 0; i < KNOEHKKNIJA.DOKBJLFIGDM.Length; i++)
		{
			LDCCKEPPFMG data = new LDCCKEPPFMG();
			data.KHEKNNFCAOI_Init(KNOEHKKNIJA.DOKBJLFIGDM[i]);
			FNHDKHBNBBN_Rewards.Add(data);
		}
		return true;
	}

	//// RVA: 0xC8C5F8 Offset: 0xC8C5F8 VA: 0xC8C5F8
	private bool PCKILNACEKE(NPAJGBIFLHB KNOEHKKNIJA)
	{
		int xor = (int)NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		xor *= 18;
		for(int i = 0; i < KNOEHKKNIJA.HBMGNHBFPHC.Length; i++)
		{
			NJLOJAKKGFK data = new NJLOJAKKGFK();
			data.BKEJPFLCLFC(JIKKNHIAEKG_BlockName, i + 1, xor, KNOEHKKNIJA);
			HDMADAHNLDN_Missions.Add(data);
		}
		return true;
	}

	//// RVA: 0xC8CAF4 Offset: 0xC8CAF4 VA: 0xC8CAF4
	private bool JBNBGGDDEGG(NPAJGBIFLHB JMHECKKKMLK)
	{
		int xor = (int)Utility.GetCurrentUnixTime() * 11 + 1;
		for(int i = 0; i < JMHECKKKMLK.OLACFKILCFD.Length; i++)
		{
			NEOBLDCCPFI data = new NEOBLDCCPFI();
			data.BAFFAONJPCE(i, xor, JMHECKKKMLK);
			GEGAEDDGNMA_Bonuses.Add(data);
			xor = xor * 3 + 13;
		}
		return true;
	}

	//// RVA: 0xC8C7EC Offset: 0xC8C7EC VA: 0xC8C7EC
	private bool ABICOINNGEK(NPAJGBIFLHB JMHECKKKMLK)
	{
		int xor = (int)Utility.GetCurrentUnixTime() * 11 + 1;
		for(int i = 0; i < JMHECKKKMLK.MIOCOKLMLBD.Length; i++)
		{
			LOJCDFAHECI data = new LOJCDFAHECI();
			data.BAFFAONJPCE(i, xor, JMHECKKKMLK);
			OGMHMAGDNAM_EpBonusBySceneRarity.Add(data);
			xor = xor * 3 + 13;
		}
		return true;
	}

	//// RVA: 0xC8C970 Offset: 0xC8C970 VA: 0xC8C970
	private bool EGLHCMDNFOE(NPAJGBIFLHB JMHECKKKMLK)
	{
		int xor = (int)Utility.GetCurrentUnixTime() * 11 + 1;
		for(int i = 0; i < JMHECKKKMLK.IEJLJIHIDJC.Length; i++)
		{
			LIPNCAJACFG data = new LIPNCAJACFG();
			data.BAFFAONJPCE(i, xor, JMHECKKKMLK);
			LHAKGDAGEMM_EpBonusInfos.Add(data);
			xor = xor * 3 + 13;
		}
		return true;
	}

	// RVA: 0xC8CC80 Offset: 0xC8CC80 VA: 0xC8CC80 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "BKOGPDBKFFJ_EventRaid.CAOGDCBPBAN");
		return 0;
	}
}
