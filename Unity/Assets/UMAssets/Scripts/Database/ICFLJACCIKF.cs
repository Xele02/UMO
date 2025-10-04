
using System.Collections.Generic;
using UnityEngine.Localization.SmartFormat.Utilities;
using XeSys;

[System.Obsolete("Use ICFLJACCIKF_EventBattle", true)]
public class ICFLJACCIKF { }
public class ICFLJACCIKF_EventBattle : DIHHCBACKGG_DbSection
{
	public class KNLJPCCDPDK
	{
		public int OBGBAOLONDD_UniqueId; // 0x8
		public int HFNIHKOAMGC; // 0xC
		public string OPFGFINHFCE_name; // 0x10
		public string HEDAGCNPHGD_RankingName; // 0x14
		public string IDGAEEJLGIK; // 0x18
		public string OCGFKMHNEOF_name_for_api; // 0x1C
		public string OGMGLOFKKPA; // 0x20
		public string FEMMDNIELFC_Desc; // 0x24
		public long BONDDBOFBND_RankingStart; // 0x28
		public long HPNOGLIFJOP_RankingEnd; // 0x30
		public long EHHFFKAFOMC; // 0x38
		public long LNFKGHNHJKE_RankingEnd2; // 0x40
		public long JGMDAOACOJF_RewardStart; // 0x48
		public long IDDBFFBPNGI_RewardEnd; // 0x50
		public long KNLGKBBIBOH_RewardEnd2; // 0x58
		public long JBFDHOIKAIK_InventoryEndDate; // 0x60
		public int KHIKEGLBGAF_RankingRewardScene; // 0x68
		public int DPJCFLKFEPN; // 0x6C
		public int MJBKGOJBPAD_item_type; // 0x70
		public sbyte POGEFBMBPCB_MonthOdd; // 0x74
		public sbyte AHKNMANFILO_DayGroup; // 0x75
		public sbyte MOEKELIIDEO_SaveIdx; // 0x76
		public string OMCAOJJGOGG_Lb; // 0x78
		public sbyte HKKNEAGCIEB_RankingSupport; // 0x7C
		public sbyte AHKPNPNOAMO_ExtreamOpen; // 0x7D
		public int HDNCGECBIKD; // 0x80
		public int EKJFNHHKBPL; // 0x84
		public int[] JKFPADIAKCK_Songs; // 0x88
		private NNJFKLBPBNK_SecureString EBGIDCIIGDO_KeyPrefix = new NNJFKLBPBNK_SecureString(); // 0x8C
		private NNJFKLBPBNK_SecureString NJKIMJAFCPC = new NNJFKLBPBNK_SecureString(); // 0x90
		public List<int> JHPCPNJJHLI_RankingThreshold = new List<int>(); // 0x94
		private List<int> HIAMHLLHAON_PlayCost = new List<int>(); // 0x98
		private List<int> LFHLCBEBPPK_PlayCostL6 = new List<int>(); // 0x9C
		public int HIOOGLEJBKM_StartAdventureId; // 0xA0
		public int FJCADCDNPMP_EndAdventureId; // 0xA4
		public int[] EJBGHLOOLBC_HelpIds; // 0xA8
		public List<int> EEOGPJJCKHH_Drops = new List<int>(); // 0xAC

		public string OCDMGOGMHGE_KeyPrefix { get { return EBGIDCIIGDO_KeyPrefix.DNJEJEANJGL_Value; } set { EBGIDCIIGDO_KeyPrefix.DNJEJEANJGL_Value = value; } } //0x11E8E00 HBAAAKFHDBB_get_KeyPrefix 0x11E8E2C NHJLJOIPOFK_set_KeyPrefix
		public string PJBILOFOCIC { get { return NJKIMJAFCPC.DNJEJEANJGL_Value; } set { NJKIMJAFCPC.DNJEJEANJGL_Value = value; } } //0x11E8E60 NOEFEAIFHCL_get_ 0x11E8E8C GJIJFGNONEL_set_

		//// RVA: 0x11E8EC0 Offset: 0x11E8EC0 VA: 0x11E8EC0
		public void PFGFMLEEDLN(int _NANNGLGOFKH_value)
		{
			HIAMHLLHAON_PlayCost.Add(_NANNGLGOFKH_value);
		}

		//// RVA: 0x11E8F40 Offset: 0x11E8F40 VA: 0x11E8F40
		public void OJLPDKAKDMC(int _NANNGLGOFKH_value)
		{
			LFHLCBEBPPK_PlayCostL6.Add(_NANNGLGOFKH_value);
		}

		//// RVA: 0x11E8FC0 Offset: 0x11E8FC0 VA: 0x11E8FC0
		public int GEDKCAODLMM_GetPlayCost(int _AKNELONELJK_difficulty, bool _GIKLNODJKFK_IsLine6)
		{
			if(!_GIKLNODJKFK_IsLine6)
				return HIAMHLLHAON_PlayCost[_AKNELONELJK_difficulty];
			else
				return LFHLCBEBPPK_PlayCostL6[_AKNELONELJK_difficulty];
		}

		//// RVA: 0x11E9050 Offset: 0x11E9050 VA: 0x11E9050
		public void LHPDDGIJKNB_Reset()
		{
			OBGBAOLONDD_UniqueId = 0;
			HFNIHKOAMGC = 0;
			BONDDBOFBND_RankingStart = 0;
			HPNOGLIFJOP_RankingEnd = 0;
			JGMDAOACOJF_RewardStart = 0;
			IDDBFFBPNGI_RewardEnd = 0;
			JBFDHOIKAIK_InventoryEndDate = 0;
			KHIKEGLBGAF_RankingRewardScene = 0;
			DPJCFLKFEPN = 0;
			EHHFFKAFOMC = 0;
			OGMGLOFKKPA = "";
			FEMMDNIELFC_Desc = "";
			POGEFBMBPCB_MonthOdd = 0;
			AHKNMANFILO_DayGroup = 0;
			MOEKELIIDEO_SaveIdx = 0;
			MJBKGOJBPAD_item_type = 1;
			HKKNEAGCIEB_RankingSupport = 0;
			OPFGFINHFCE_name = "";
			HEDAGCNPHGD_RankingName = "";
			IDGAEEJLGIK = "";
			OCGFKMHNEOF_name_for_api = "";
			OCDMGOGMHGE_KeyPrefix = "";
			PJBILOFOCIC = "";
			JHPCPNJJHLI_RankingThreshold.Clear();
			HIAMHLLHAON_PlayCost.Clear();
			LFHLCBEBPPK_PlayCostL6.Clear();
			OMCAOJJGOGG_Lb = "";
			HIOOGLEJBKM_StartAdventureId = 0;
			FJCADCDNPMP_EndAdventureId = 0;
			EJBGHLOOLBC_HelpIds = null;
			AHKPNPNOAMO_ExtreamOpen = 0;
			EKJFNHHKBPL = 0;
			JKFPADIAKCK_Songs = null;
			EEOGPJJCKHH_Drops.Clear();
		}

		//// RVA: 0x11E91F8 Offset: 0x11E91F8 VA: 0x11E91F8
		//public uint CAOGDCBPBAN() { }
	}

	public class FGBJDLLLBEF
	{
		public int FBGGEFFJJHB_xor; // 0x8
		private int EHOIENNDEDH_IdCrypted; // 0xC
		private int FMDDJNKEBBB_Crypted; // 0x10
		private int MDKGAAMBJDJ_Crypted; // 0x14
		private int GGEBNMPPEID_Crypted; // 0x18

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E8048 DEMEPMAEJOO_get_id 0x11E8058 HIGKAIDMOKN_set_id
		public int CNKFPJCGNFE_SceneId { get { return FMDDJNKEBBB_Crypted ^ FBGGEFFJJHB_xor; } set { FMDDJNKEBBB_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x11E8068 GJBOGOFHGNP_get_SceneId 0x11E8078 GJDGIDCMJMH_set_SceneId
		public int GNFBMCGMCFO_BonusBefore { get { return MDKGAAMBJDJ_Crypted ^ FBGGEFFJJHB_xor; } set { MDKGAAMBJDJ_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x11E8088 NCIMMDJLPLJ_get_BonusBefore 0x11E8098 HNAJAFBHOLM_set_BonusBefore
		public int BFFGFAMJAIG_BonusAfter { get { return GGEBNMPPEID_Crypted ^ FBGGEFFJJHB_xor; } set { GGEBNMPPEID_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x11E80A8 PKMNOMELPMN_get_BonusAfter 0x11E80B8 IABBJBAHKCE_set_BonusAfter

		//// RVA: 0x11E80C8 Offset: 0x11E80C8 VA: 0x11E80C8
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x11E80F4 Offset: 0x11E80F4 VA: 0x11E80F4
		public void BAFFAONJPCE(int JBGJDEELLOP, int KNEFBLHBDBG, OPHFFGFJIBJ JMHECKKKMLK)
		{
			FBGGEFFJJHB_xor = KNEFBLHBDBG;
			BFFGFAMJAIG_BonusAfter = 0;
			PPFNGGCBJKC_id = 0;
			CNKFPJCGNFE_SceneId = 0;
			GNFBMCGMCFO_BonusBefore = 0;
			NFEINLOIPEP data = JMHECKKKMLK.OLACFKILCFD[JBGJDEELLOP];
			PPFNGGCBJKC_id = data.PPFNGGCBJKC_id;
			CNKFPJCGNFE_SceneId = data.CNKFPJCGNFE_SceneId;
			GNFBMCGMCFO_BonusBefore = data.GNFBMCGMCFO_BonusBefore;
			BFFGFAMJAIG_BonusAfter = data.BFFGFAMJAIG_BonusAfter;
		}

		//// RVA: 0x11E8238 Offset: 0x11E8238 VA: 0x11E8238
		//public void LHPDDGIJKNB_Reset(int KNEFBLHBDBG) { }
	}

	public class DGBPOCFMKMJ
	{
		public int FBGGEFFJJHB_xor; // 0x8
		private int EHOIENNDEDH_IdCrypted; // 0xC
		private int MDKGAAMBJDJ_Crypted; // 0x10
		private int GGEBNMPPEID_Crypted; // 0x14

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E71AC DEMEPMAEJOO_get_id 0x11E71BC HIGKAIDMOKN_set_id
		public int GNFBMCGMCFO_BonusBefore { get { return MDKGAAMBJDJ_Crypted ^ FBGGEFFJJHB_xor; } set { MDKGAAMBJDJ_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x11E71CC NCIMMDJLPLJ_get_BonusBefore 0x11E71DC HNAJAFBHOLM_set_BonusBefore
		public int BFFGFAMJAIG_BonusAfter { get { return GGEBNMPPEID_Crypted ^ FBGGEFFJJHB_xor; } set { GGEBNMPPEID_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x11E71EC PKMNOMELPMN_get_BonusAfter 0x11E71FC IABBJBAHKCE_set_BonusAfter

		//// RVA: 0x11E720C Offset: 0x11E720C VA: 0x11E720C
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x11E7230 Offset: 0x11E7230 VA: 0x11E7230
		public void BAFFAONJPCE(int JBGJDEELLOP, int KNEFBLHBDBG, OPHFFGFJIBJ JMHECKKKMLK)
		{
			FBGGEFFJJHB_xor = KNEFBLHBDBG;
			PPFNGGCBJKC_id = 0;
			GNFBMCGMCFO_BonusBefore = 0;
			BFFGFAMJAIG_BonusAfter = 0;
			PHNMAKOGBKJ data = JMHECKKKMLK.MIOCOKLMLBD[JBGJDEELLOP];
			PPFNGGCBJKC_id = data.PPFNGGCBJKC_id;
			GNFBMCGMCFO_BonusBefore = data.GNFBMCGMCFO_BonusBefore;
			BFFGFAMJAIG_BonusAfter = data.BFFGFAMJAIG_BonusAfter;
		}

		//// RVA: 0x11E7334 Offset: 0x11E7334 VA: 0x11E7334
		//public void LHPDDGIJKNB_Reset(int KNEFBLHBDBG) { }
	}

	public class GNCIKNGDGPP
	{
		public int FBGGEFFJJHB_xor; // 0x8
		private int HHEEHHHLKHC_Crypted; // 0xC
		private int LGAIHLFAPDC_Crypted; // 0x10
		public List<int> KDNMBOBEGJM_GachaIds = new List<int>(); // 0x14

		public int KHPHAAMGMJP_EpId { get { return HHEEHHHLKHC_Crypted ^ FBGGEFFJJHB_xor; } set { HHEEHHHLKHC_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x11E84D0 ABFDDKBBPCH_get_EpId 0x11E84E0 MHDOIIEMDEH_set_EpId
		public int OFIAENKCJME_BaseBonus { get { return LGAIHLFAPDC_Crypted ^ FBGGEFFJJHB_xor; } set { LGAIHLFAPDC_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x11E84F0 KADLAKFANGA_get_BaseBonus 0x11E8500 AIDAPNCEPOB_set_BaseBonus

		//// RVA: 0x11E8510 Offset: 0x11E8510 VA: 0x11E8510
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x11E85E8 Offset: 0x11E85E8 VA: 0x11E85E8
		public void BAFFAONJPCE(int JBGJDEELLOP, int KNEFBLHBDBG, OPHFFGFJIBJ JMHECKKKMLK)
		{
			LHPDDGIJKNB_Reset(KNEFBLHBDBG);
			FJOLJGPGDGD array = JMHECKKKMLK.IEJLJIHIDJC[JBGJDEELLOP];
			KHPHAAMGMJP_EpId = array.KHPHAAMGMJP_EpId;
			OFIAENKCJME_BaseBonus = array.OFIAENKCJME_BaseBonus;
			for(int i = 0; i < array.JMLCLHHLJHM.Length; i++)
			{
				KDNMBOBEGJM_GachaIds.Add(array.JMLCLHHLJHM[i]);
			}
		}

		//// RVA: 0x11E87BC Offset: 0x11E87BC VA: 0x11E87BC
		public void LHPDDGIJKNB_Reset(int KNEFBLHBDBG)
		{
			FBGGEFFJJHB_xor = KNEFBLHBDBG;
			KHPHAAMGMJP_EpId = 0;
			OFIAENKCJME_BaseBonus = 0;
			KDNMBOBEGJM_GachaIds.Clear();
		}
	}

	public class BEFNBMEMFOB
	{
		public int GLCLFMGPMAN_ItemId; // 0x8
		public int HMFFHLPNMPH_count; // 0xC
		public int NMKEOMCMIPP_RewardId; // 0x10
		public int HJAFPEBIBOP_Limit; // 0x14

		public bool PJPDOCNJNGJ_IsLimited { get { return HJAFPEBIBOP_Limit > 0; } } //0x11E6F58 MBEBLALDBHJ_bgs
	}

	public class BHBICAALJIA
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int DNBFMLBNAEE_point; // 0xC
		public List<BEFNBMEMFOB> AHJNPEAMCCH_rewards = new List<BEFNBMEMFOB>(); // 0x10
		public bool JOPPFEHKNFO_Pickup; // 0x14

		// RVA: 0x11E6F74 Offset: 0x11E6F74 VA: 0x11E6F74
		//public uint CAOGDCBPBAN() { }
	}

	public class LPJIKDAMGPC
	{
		public int FBGGEFFJJHB_xor; // 0x8
		public int DPOOAOPAAGC_Crypted; // 0xC
		public int PLCMLMADCDD_MinCrypted; // 0x10
		public int LCGJKAGIFGO_MaxCrypted; // 0x14
		public int HNDOLKNBOIJ; // 0x18
		public int HHGFOIMIGED; // 0x1C
		public int IBCMDICBGHH; // 0x20
		public int HKAILALAFDG; // 0x24
		public int PEBHLFLDIGC_Crypted; // 0x28

		public int EEAPIKNJNDB_ConsecutiveWin { get { return FBGGEFFJJHB_xor ^ DPOOAOPAAGC_Crypted; } set { DPOOAOPAAGC_Crypted = value ^ FBGGEFFJJHB_xor; } } // 0x11E94BC KNLJPLHJMHI_get_ConsecutiveWin 0x11E94CC IMHAJFDFGJL_set_ConsecutiveWin
		public int NNDBJGDFEEM_Min { get { return FBGGEFFJJHB_xor ^ PLCMLMADCDD_MinCrypted; } set { PLCMLMADCDD_MinCrypted = value ^ FBGGEFFJJHB_xor; } } // 0x11E94DC EHNOFMPHLFC_get_Min 0x11E94EC GCANPOPEKEE_set_Min
		public int DOOGFEGEKLG_max { get { return FBGGEFFJJHB_xor ^ LCGJKAGIFGO_MaxCrypted; } set { LCGJKAGIFGO_MaxCrypted = value ^ FBGGEFFJJHB_xor; } } // 0x11E94FC AECMFIOFFJN_get_max 0x11E950C NGOJJDOCIDG_set_max
		public int DJJGNDCMNHF_BonusValue { get { return FBGGEFFJJHB_xor ^ PEBHLFLDIGC_Crypted; } set { PEBHLFLDIGC_Crypted = value ^ FBGGEFFJJHB_xor; } } // 0x11E951C GEPCOAPEAJM_get_BonusValue 0x11E952C MIFJBBAJAJP_set_BonusValue

		//// RVA: 0x11E953C Offset: 0x11E953C VA: 0x11E953C
		//public int OBMHEPPBCCI(int MBMADKJEDLP) { }

		//// RVA: 0x11E9564 Offset: 0x11E9564 VA: 0x11E9564
		//public int FBCEFLKBDHO(int MBMADKJEDLP) { }
	}

	public class FKACPHEKBNF
	{
		public int FBGGEFFJJHB_xor; // 0x8
		public string OPFGFINHFCE_name; // 0xC
		public int[] MJNMPAKBNKB_NotesResult = new int[5]; // 0x10
		public int ENNCJKLIGKE_Luck; // 0x14
		public int PALEGNNHIKH_Leaf; // 0x18
		public int JCDEDIOAGKE_ExcellentRatio; // 0x1C
		public int BJHHOBEMBJG_CostumeIdCrypted; // 0x20
		public int CPCKPCJBDEL_Crypted; // 0x24
		public int AOFGNAJLLPD_DivaIdCrypted; // 0x28
		public int ENEKCBCOKNM_Crypted; // 0x2C
		public int HNJHPNPFAAN_EnabledCrypted; // 0x30
		public int CJAOMKLHFJL_Crypted; // 0x34
		public int EHOIENNDEDH_IdCrypted; // 0x38
		public int KPLDLGGMOMH_Crypted; // 0x3C
		public int HIJDFKKMONB_Crypted; // 0x40
		public int MHGDDPCAGAJ_Crypted; // 0x44
		public int GIELAFNPOCG_Crypted; // 0x48
		public int GHJIBEMCKLA_Crypted; // 0x4C
		public int NBOLDNMPJFG_scoreCrypted; // 0x50
		public int EOPEEENMHEN_Crypted; // 0x54
		public int BCKCCHGMPBG_Crypted; // 0x58
		public int JKJDDGGNEAB_TotalCrypted; // 0x5C

		public int BEEAIAAJOHD_CostumeId { get { return BJHHOBEMBJG_CostumeIdCrypted ^ FBGGEFFJJHB_xor; } set { BJHHOBEMBJG_CostumeIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E8254 DIIBIOEMHAI_get_CostumeId 0x11E8264 JIHEDMEFKAF_set_CostumeId
		public int AKNELONELJK_difficulty { get { return CPCKPCJBDEL_Crypted ^ FBGGEFFJJHB_xor; } set { CPCKPCJBDEL_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x11E8274 BPPILHGDABB_get_difficulty 0x11E8284 PMMIIHKEGCI_set_difficulty
		public int DIPKCALNIII_diva_id { get { return AOFGNAJLLPD_DivaIdCrypted ^ FBGGEFFJJHB_xor; } set { AOFGNAJLLPD_DivaIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E8294 EOGPBFIDAPF_get_diva_id 0x11E82A4 JDNCGPBAFMB_set_diva_id
		public int HEBKEJBDCBH_diva_lv { get { return ENEKCBCOKNM_Crypted ^ FBGGEFFJJHB_xor; } set { ENEKCBCOKNM_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x11E82B4 OMOHEDILHMF_get_diva_lv 0x11E82C4 FCGDHINFKHC_set_diva_lv
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E82D4 JPCJNLHHIPE_get_en 0x11E82E4 JJFJNEJLBDG_set_en
		public int GOIKCKHMBDL_FreeMusicId { get { return CJAOMKLHFJL_Crypted ^ FBGGEFFJJHB_xor; } set { CJAOMKLHFJL_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x11E82F4 BPGCGEDHBEH_get_FreeMusicId 0x11E8304 ICPMFBIDFFO_set_FreeMusicId
		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E8314 DEMEPMAEJOO_get_id 0x11E8324 HIGKAIDMOKN_set_id
		public int EDJMDDAGCEJ_Score1 { get { return KPLDLGGMOMH_Crypted ^ FBGGEFFJJHB_xor; } set { KPLDLGGMOMH_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x11E8334 BCMKDNCFOJO_get_Score1 0x11E8344 DDIAEKOKDIE_set_Score1
		public int HEFPAIOLBAG_Score2 { get { return HIJDFKKMONB_Crypted ^ FBGGEFFJJHB_xor; } set { HIJDFKKMONB_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x11E8354 EAGPNJEBOCP_get_Score2 0x11E8364 LLIGHINHLOL_set_Score2
		public int GLILAGLJLEP_SceneId { get { return MHGDDPCAGAJ_Crypted ^ FBGGEFFJJHB_xor; } set { MHGDDPCAGAJ_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x11E8374 HGPGPALMELF_get_SceneId 0x11E8384 ECHLNFNJFFO_set_SceneId
		public int ECOLMPLOPFM_SceneLevel { get { return GIELAFNPOCG_Crypted ^ FBGGEFFJJHB_xor; } set { GIELAFNPOCG_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x11E8394 BFLCGLBAFOE_get_SceneLevel 0x11E83A4 NJGKCLHFDIB_set_SceneLevel
		public int CFCIMKOHLIG_Mlt { get { return GHJIBEMCKLA_Crypted ^ FBGGEFFJJHB_xor; } set { GHJIBEMCKLA_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x11E83B4 AJNACFGNOAA_get_Mlt 0x11E83C4 LCGAFCPHDKA_set_Mlt
		public int BDLNMOIOMHK_total { get { return JKJDDGGNEAB_TotalCrypted ^ FBGGEFFJJHB_xor; } set { JKJDDGGNEAB_TotalCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E83D4 MKMAKAEDMBG_get_total 0x11E83E4 GIJPLHEDIKD_set_total
		public int NLKEBAOBJCM_combo { get { return BCKCCHGMPBG_Crypted ^ FBGGEFFJJHB_xor; } set { BCKCCHGMPBG_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x11E83F4 AECNKGBNKHH_get_combo 0x11E8404 ECHLKFHOJFP_set_combo
		public int KNIFCANOHOC_score { get { return NBOLDNMPJFG_scoreCrypted ^ FBGGEFFJJHB_xor; } set { NBOLDNMPJFG_scoreCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E8414 EOJEPLIPOMJ_get_score 0x11E8424 AEEMBPAEAAI_set_score
		public int IPPNCOHEEOD_ScoreAverage { get { return EOPEEENMHEN_Crypted ^ FBGGEFFJJHB_xor; } set { EOPEEENMHEN_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x11E8434 BNFNPCNAGAF_get_ScoreAverage 0x11E8444 GEMDEGDPJPK_set_ScoreAverage
	}

	public class FKKMACHKBFB
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int KFCIJBLDHOK_v1; // 0xC
		public int JLEIHOEGMOP_v2; // 0x10
	}

	public class OABJKIKLDKP
	{
		public int FBGGEFFJJHB_xor; // 0x8
		public int EHOIENNDEDH_IdCrypted; // 0xC
		public int HNJHPNPFAAN_EnabledCrypted; // 0x10
		public int CNMODNFFBLP_FMusicIdCrypted; // 0x14
		public int CHDLCOGBCNK_CSkillCrypted; // 0x18
		public int KNALPNKGKHD_LSkillCrypted; // 0x1C
		public long PCLNFCNIECH_OpenAtCrypted; // 0x20
		public long HHPIJHADAOB_CloseAtCrypted; // 0x28

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E9594 DEMEPMAEJOO_get_id 0x11E95A0 HIGKAIDMOKN_set_id
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E95B0 JPCJNLHHIPE_get_en 0x11E95C0 JJFJNEJLBDG_set_en
		public int MPLGPBNJDJB_FreeMusicId { get { return CNMODNFFBLP_FMusicIdCrypted ^ FBGGEFFJJHB_xor; } set { CNMODNFFBLP_FMusicIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E95D0 KADAEAOKJNE_get_FreeMusicId 0x11E95E0 MBKFNLHPNPP_set_FreeMusicId
		public int CPBFAMJEODF_c_skill { get { return CHDLCOGBCNK_CSkillCrypted ^ FBGGEFFJJHB_xor; } set { CHDLCOGBCNK_CSkillCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E95F0 GEPFGJBNHNL_get_c_skill 0x11E9600 MHBECPNIHLA_set_c_skill
		public int MGHPJNNDCIG_l_skill { get { return KNALPNKGKHD_LSkillCrypted ^ FBGGEFFJJHB_xor; } set { KNALPNKGKHD_LSkillCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E9610 GFADFBMKBMD_get_l_skill 0x11E9620 JECIKFDJMOB_set_l_skill
		public long PDBPFJJCADD_open_at { get { return PCLNFCNIECH_OpenAtCrypted ^ FBGGEFFJJHB_xor; } set { PCLNFCNIECH_OpenAtCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E9630 FOACOMBHPAC_get_open_at 0x11E9648 NBACOBCOJCA_set_open_at
		public long FDBNFFNFOND_close_at { get { return HHPIJHADAOB_CloseAtCrypted ^ FBGGEFFJJHB_xor; } set { HHPIJHADAOB_CloseAtCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E965C BPJOGHJCLDJ_get_close_at 0x11E9674 NLJKMCHOCBK_set_close_at

		//// RVA: 0x11E9688 Offset: 0x11E9688 VA: 0x11E9688
		//public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id, int KNEFBLHBDBG) { }

		//// RVA: 0x11E96B8 Offset: 0x11E96B8 VA: 0x11E96B8
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, int KNEFBLHBDBG, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) { }
		//PPFNGGCBJKC_id = id
		//PLALNIIBLOF_en = en
		//MPLGPBNJDJB_FreeMusicId = f_music_id
		//CPBFAMJEODF_c_skill = c_skill
		//MGHPJNNDCIG_l_skill = l_skill
		//PDBPFJJCADD_open_at = open_at
		//FDBNFFNFOND_close_at = close_at

		//// RVA: 0x11E99C4 Offset: 0x11E99C4 VA: 0x11E99C4
		public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, int KNEFBLHBDBG_, OPHFFGFJIBJ JMHECKKKMLK_)
		{
			FBGGEFFJJHB_xor = KNEFBLHBDBG_;
			PPFNGGCBJKC_id = _PPFNGGCBJKC_id;
			PLALNIIBLOF_en = 0;
			MPLGPBNJDJB_FreeMusicId = 0;
			CPBFAMJEODF_c_skill = 0;
			MGHPJNNDCIG_l_skill = 0;
			PDBPFJJCADD_open_at = 0;
			FDBNFFNFOND_close_at = 0;
			IJFIMCBAJDJ data = JMHECKKKMLK_.GHIHAGAOPNC[_PPFNGGCBJKC_id - 1];
			PPFNGGCBJKC_id = (int)data.PPFNGGCBJKC_id;
			PLALNIIBLOF_en = (int)data.PLALNIIBLOF_en;
			MPLGPBNJDJB_FreeMusicId = (int)data.MPLGPBNJDJB_FreeMusicId;
			CPBFAMJEODF_c_skill = (int)data.CPBFAMJEODF_c_skill;
			MGHPJNNDCIG_l_skill = (int)data.MGHPJNNDCIG_l_skill;
			PDBPFJJCADD_open_at = (int)data.PDBPFJJCADD_open_at;
			FDBNFFNFOND_close_at = (int)data.FDBNFFNFOND_close_at;
		}

		//// RVA: 0x11E9BC0 Offset: 0x11E9BC0 VA: 0x11E9BC0
		//public uint CAOGDCBPBAN() { }
	}

	public class KGHHHPHBGGM
	{
		public int FBGGEFFJJHB_xor; // 0x8
		public int EHOIENNDEDH_IdCrypted; // 0xC
		public int HNJHPNPFAAN_EnabledCrypted; // 0x10
		public int OGBOECHJCML_EvMusicIdCrypted; // 0x14
		public long PCLNFCNIECH_OpenAtCrypted; // 0x18
		public long HHPIJHADAOB_CloseAtCrypted; // 0x20

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E88D0 DEMEPMAEJOO_get_id 0x11E88DC HIGKAIDMOKN_set_id
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E88EC JPCJNLHHIPE_get_en 0x11E88FC JJFJNEJLBDG_set_en
		public int KOJMEPJBOJM_EvMusicId { get { return OGBOECHJCML_EvMusicIdCrypted ^ FBGGEFFJJHB_xor; } set { OGBOECHJCML_EvMusicIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E890C JFLEJAJJMPF_get_EvMusicId 0x11E891C DLOCAEEEJAE_set_EvMusicId
		public long PDBPFJJCADD_open_at { get { return PCLNFCNIECH_OpenAtCrypted ^ FBGGEFFJJHB_xor; } set { PCLNFCNIECH_OpenAtCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E892C FOACOMBHPAC_get_open_at 0x11E8944 NBACOBCOJCA_set_open_at
		public long FDBNFFNFOND_close_at { get { return HHPIJHADAOB_CloseAtCrypted ^ FBGGEFFJJHB_xor; } set { HHPIJHADAOB_CloseAtCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E8958 BPJOGHJCLDJ_get_close_at 0x11E8970 NLJKMCHOCBK_set_close_at

		//// RVA: 0x11E8984 Offset: 0x11E8984 VA: 0x11E8984
		//public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id, int KNEFBLHBDBG) { }

		//// RVA: 0x11E89B4 Offset: 0x11E89B4 VA: 0x11E89B4
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, int KNEFBLHBDBG, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) { }
		//PPFNGGCBJKC_id = id
		//PLALNIIBLOF_en = en
		//KOJMEPJBOJM_EvMusicId = ev_music_id
		//PDBPFJJCADD_open_at = open_at
		//FDBNFFNFOND_close_at = close_at

		//// RVA: 0x11E8C14 Offset: 0x11E8C14 VA: 0x11E8C14
		public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, int KNEFBLHBDBG, OPHFFGFJIBJ JMHECKKKMLK)
		{
			FBGGEFFJJHB_xor = KNEFBLHBDBG;
			PPFNGGCBJKC_id = _PPFNGGCBJKC_id;
			PLALNIIBLOF_en = 0;
			KOJMEPJBOJM_EvMusicId = 0;
			PDBPFJJCADD_open_at = 0;
			FDBNFFNFOND_close_at = 0;
			HJEKNHMEPBP data = JMHECKKKMLK.PLHPEOKOMHH[_PPFNGGCBJKC_id - 1];
			PPFNGGCBJKC_id = (int)data.PPFNGGCBJKC_id;
			PLALNIIBLOF_en = (int)data.PLALNIIBLOF_en;
			KOJMEPJBOJM_EvMusicId = (int)data.KOJMEPJBOJM_EvMusicId;
			PDBPFJJCADD_open_at = data.PDBPFJJCADD_open_at;
			FDBNFFNFOND_close_at = data.FDBNFFNFOND_close_at;
		}

		//// RVA: 0x11E8DAC Offset: 0x11E8DAC VA: 0x11E8DAC
		//public uint CAOGDCBPBAN() { }
	}

	public class EIIMIHPLDFJ
	{
		public int FBGGEFFJJHB_xor; // 0x8
		public int EHOIENNDEDH_IdCrypted; // 0xC
		public int HNJHPNPFAAN_EnabledCrypted; // 0x10
		public int AGACCBBEEDJ_EmblemIdCrypted; // 0x14
		public int PCFFCAAIPNB_ScoreCrypted; // 0x18
		public int[] NDOGDOPFNEG_Pnt = new int[4]; // 0x1C
		public int LNCOADKBAAP_ExBnsCrypted; // 0x20
		public int LGFBLINAGGI_BMinCrypted; // 0x24
		public int FNHJGFMGBDK_BMaxCrypted; // 0x28
		public int GPAKDLBNIOI_AMinCrypted; // 0x2C
		public int CLGFJMEKLKH_AMaxCrypted; // 0x30
		public int AJKKBHJHHLA_SMinCrypted; // 0x34
		public int MJBNEHAKLGP_SMaxCrypted; // 0x38
		public int FOJMCKKDDHP_ExMinCrypted; // 0x3C
		public int LOFGKCCABFA_ExMaxCrypted; // 0x40

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E734C DEMEPMAEJOO_get_id 0x11E735C HIGKAIDMOKN_set_id
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E736C JPCJNLHHIPE_get_en 0x11E737C JJFJNEJLBDG_set_en
		public int APGKOJKNNGP_EmblemId { get { return AGACCBBEEDJ_EmblemIdCrypted ^ FBGGEFFJJHB_xor; } set { AGACCBBEEDJ_EmblemIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E738C KGLCIOHDBLL_get_EmblemId 0x11E739C DJKADEGEAHE_set_EmblemId
		public int AFKHNFBOMKI_sc { get { return PCFFCAAIPNB_ScoreCrypted ^ FBGGEFFJJHB_xor; } set { PCFFCAAIPNB_ScoreCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E73AC NMHOKCJEIDP_get_sc 0x11E73BC MPFMEIDKANE_set_sc
		public int GCPKJPNENJJ_ExBns { get { return LNCOADKBAAP_ExBnsCrypted ^ FBGGEFFJJHB_xor; } set { LNCOADKBAAP_ExBnsCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E73CC DEFEJOEMOBM_get_ExBns 0x11E73DC POILGINHMFI_set_ExBns
		public int FLOAHHHAOLE_BMin { get { return LGFBLINAGGI_BMinCrypted ^ FBGGEFFJJHB_xor; } set { LGFBLINAGGI_BMinCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E73EC LFPPNCDDIIL_get_BMin 0x11E73FC AANNOOHGHHI_set_BMin
		public int COJMPBFFJFI_BMax { get { return FNHJGFMGBDK_BMaxCrypted ^ FBGGEFFJJHB_xor; } set { FNHJGFMGBDK_BMaxCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E740C JPPCEEKHOFC_get_BMax 0x11E741C HIOGIOLAEOI_set_BMax
		public int KPFDEBIEAME_AMin { get { return GPAKDLBNIOI_AMinCrypted ^ FBGGEFFJJHB_xor; } set { GPAKDLBNIOI_AMinCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E742C IIMKGJJGKLL_get_AMin 0x11E743C MDFOJINDCCM_set_AMin
		public int MCBDCDLKACL_AMax { get { return CLGFJMEKLKH_AMaxCrypted ^ FBGGEFFJJHB_xor; } set { CLGFJMEKLKH_AMaxCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E744C GCJBJKEJMPN_get_AMax 0x11E745C GNLEHPCNIFN_set_AMax
		public int JLDNDNNDEEH_SMin { get { return AJKKBHJHHLA_SMinCrypted ^ FBGGEFFJJHB_xor; } set { AJKKBHJHHLA_SMinCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E746C IONADHGPJOM_get_SMin 0x11E747C EIBPMJPKBMG_set_SMin
		public int LIIIGJFLAAB_SMax { get { return MJBNEHAKLGP_SMaxCrypted ^ FBGGEFFJJHB_xor; } set { MJBNEHAKLGP_SMaxCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E748C JPIBNDOCFKB_get_SMax 0x11E749C AGFPHGNJJIH_set_SMax
		public int NGNKKFNDEPD_ExMin { get { return FOJMCKKDDHP_ExMinCrypted ^ FBGGEFFJJHB_xor; } set { FOJMCKKDDHP_ExMinCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E74AC DDOMBIIGHJH_get_ExMin 0x11E74BC OHENGMHAJHL_set_ExMin
		public int MKOKEGGPFBC_ExMax { get { return LOFGKCCABFA_ExMaxCrypted ^ FBGGEFFJJHB_xor; } set { LOFGKCCABFA_ExMaxCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11E74CC LGAMCIJDOOL_get_ExMax 0x11E74DC CJGNIOCOPEO_set_ExMax

		//// RVA: 0x11E74EC Offset: 0x11E74EC VA: 0x11E74EC
		public int KEJKLJNJJDB(int _FNEIADJMHHO_st)
		{
			if(_FNEIADJMHHO_st > 3)
				return 0;
			return NDOGDOPFNEG_Pnt[_FNEIADJMHHO_st] ^ FBGGEFFJJHB_xor;
		}

		//// RVA: 0x11E754C Offset: 0x11E754C VA: 0x11E754C
		public bool PEBPOMMIHIC(int _FNEIADJMHHO_st, int _JBGEEPFKIGG_val)
		{
			NDOGDOPFNEG_Pnt[_FNEIADJMHHO_st] = _JBGEEPFKIGG_val ^ FBGGEFFJJHB_xor;
			return true;
		}

		//// RVA: 0x11E75B4 Offset: 0x11E75B4 VA: 0x11E75B4
		public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id, int KNEFBLHBDBG)
		{
			FBGGEFFJJHB_xor = KNEFBLHBDBG;
			PPFNGGCBJKC_id = _PPFNGGCBJKC_id;
			PLALNIIBLOF_en = 0;
			APGKOJKNNGP_EmblemId = 0;
			AFKHNFBOMKI_sc = 0;
			MKOKEGGPFBC_ExMax = 0;
			GCPKJPNENJJ_ExBns = 0;
			FLOAHHHAOLE_BMin = 0;
			COJMPBFFJFI_BMax = 0;
			KPFDEBIEAME_AMin = 0;
			MCBDCDLKACL_AMax = 0;
			JLDNDNNDEEH_SMin = 0;
			LIIIGJFLAAB_SMax = 0;
			NGNKKFNDEPD_ExMin = 0;
			for(int i = 0; i < 4; i++)
			{
				PEBPOMMIHIC(i, 0);
			}
		}

		//// RVA: 0x11E7614 Offset: 0x11E7614 VA: 0x11E7614
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, int KNEFBLHBDBG, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) { }
		//PPFNGGCBJKC_id = id
		//PLALNIIBLOF_en = en
		//APGKOJKNNGP_EmblemId = emblem_id
		//AFKHNFBOMKI_sc = sc
		//GCPKJPNENJJ_ExBns = ex_bns
		//FLOAHHHAOLE_BMin = b_min
		//COJMPBFFJFI_BMax = b_max
		//KPFDEBIEAME_AMin = a_min
		//MCBDCDLKACL_AMax = a_max
		//JLDNDNNDEEH_SMin = s_min
		//LIIIGJFLAAB_SMax = s_max
		//NGNKKFNDEPD_ExMin = ex_min
		//MKOKEGGPFBC_ExMax = ex_max
		//NDOGDOPFNEG_Pnt = pnt

		//// RVA: 0x11E7BA4 Offset: 0x11E7BA4 VA: 0x11E7BA4
		public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, int KNEFBLHBDBG, OPHFFGFJIBJ JMHECKKKMLK)
		{
			LHPDDGIJKNB_Reset(_PPFNGGCBJKC_id, KNEFBLHBDBG);
			HIGMGCAKFAN data = JMHECKKKMLK.NIPMOFJPFJG[_PPFNGGCBJKC_id - 1];
			PPFNGGCBJKC_id = (int)data.PPFNGGCBJKC_id;
			PLALNIIBLOF_en = (int)data.PLALNIIBLOF_en;
			APGKOJKNNGP_EmblemId = (int)data.APGKOJKNNGP_EmblemId;
			AFKHNFBOMKI_sc = (int)data.AFKHNFBOMKI_sc;
			GCPKJPNENJJ_ExBns = (int)data.GCPKJPNENJJ_ExBns;
			FLOAHHHAOLE_BMin = (int)data.FLOAHHHAOLE_BMin;
			COJMPBFFJFI_BMax = (int)data.COJMPBFFJFI_BMax;
			KPFDEBIEAME_AMin = (int)data.KPFDEBIEAME_AMin;
			MCBDCDLKACL_AMax = (int)data.MCBDCDLKACL_AMax;
			JLDNDNNDEEH_SMin = (int)data.JLDNDNNDEEH_SMin;
			LIIIGJFLAAB_SMax = (int)data.LIIIGJFLAAB_SMax;
			NGNKKFNDEPD_ExMin = (int)data.NGNKKFNDEPD_ExMin;
			MKOKEGGPFBC_ExMax = (int)data.MKOKEGGPFBC_ExMax;
			for(int i = 0; i < data.HHOFENIINIJ.Length; i++)
			{
				PEBPOMMIHIC(i, data.HHOFENIINIJ[i]);
			}
		}

		//// RVA: 0x11E7F08 Offset: 0x11E7F08 VA: 0x11E7F08
		//public uint CAOGDCBPBAN() { }
	}

	public KNLJPCCDPDK NGHKJOEDLIP_Settings = new KNLJPCCDPDK(); // 0x20
	public List<BHBICAALJIA> FCIPEDFHFEM_TotalRewards = new List<BHBICAALJIA>(); // 0x24
	public List<AKIIJBEJOEP> NNMPGOAGEOL_quests = new List<AKIIJBEJOEP>(); // 0x28
	public List<LPJIKDAMGPC> AFHHBNBCOKI = new List<LPJIKDAMGPC>(); // 0x2C
	public List<FKACPHEKBNF> OCPGCHOGHPB_DefaultRivals = new List<FKACPHEKBNF>(); // 0x30
	public List<FGBJDLLLBEF> GEGAEDDGNMA_Bonuses = new List<FGBJDLLLBEF>(); // 0x34//EpBonusByScene
	public List<DGBPOCFMKMJ> OGMHMAGDNAM_EpBonusBySceneRarity = new List<DGBPOCFMKMJ>(); // 0x38
	public List<GNCIKNGDGPP> LHAKGDAGEMM_EpBonusInfos = new List<GNCIKNGDGPP>(); // 0x3C
	public List<AIGOEAPJGEB> MBHDIJJEOFL = new List<AIGOEAPJGEB>(); // 0x48
	public List<IJNOIMLNBGN> LLCLJBEJOPM_BannerInfo = new List<IJNOIMLNBGN>(); // 0x4C
	public List<OABJKIKLDKP> IJJHFGOIDOK_EventMusic = new List<OABJKIKLDKP>(); // 0x50
	public List<KGHHHPHBGGM> GCFOLMHPDBG = new List<KGHHHPHBGGM>(); // 0x54
	public List<EIIMIHPLDFJ> PMJLEPGCAOA_ClassDatas = new List<EIIMIHPLDFJ>(); // 0x58

	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI_m_stringParam { get; private set; } // 0x40 IHKPIFIBECO GAMGELHIHHI_get_m_stringParam DDDEJIJGGBJ_set_m_stringParam
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK_m_intParam { get; private set; } // 0x44 KLDCHOIPJGB AEMNOGNEBOJ_get_m_intParam DGKDBOAMNBB_set_m_intParam

	//// RVA: 0x1221010 Offset: 0x1221010 VA: 0x1221010
	public string EFEGBHACJAL_GetStringParam(string _LJNAKDMILMC_key, string _KKMJBMKHGNH_noval)
	{
		if(FJOEBCMGDMI_m_stringParam.ContainsKey(_LJNAKDMILMC_key))
		{
			return FJOEBCMGDMI_m_stringParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
		}
		return _KKMJBMKHGNH_noval;
	}

	//// RVA: 0x12210F4 Offset: 0x12210F4 VA: 0x12210F4
	public int LPJLEHAJADA_GetIntParam(string _LJNAKDMILMC_key, int _KKMJBMKHGNH_noval)
	{
		if(OHJFBLFELNK_m_intParam.ContainsKey(_LJNAKDMILMC_key))
		{
			return OHJFBLFELNK_m_intParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
		}
		return _KKMJBMKHGNH_noval;
	}

	// RVA: 0x12211D8 Offset: 0x12211D8 VA: 0x12211D8
	public ICFLJACCIKF_EventBattle()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		FJOEBCMGDMI_m_stringParam = new Dictionary<string, NNJFKLBPBNK_SecureString>();
		OHJFBLFELNK_m_intParam = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		LMHMIIKCGPE = 28;
	}

	// RVA: 0x1221594 Offset: 0x1221594 VA: 0x1221594 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		NGHKJOEDLIP_Settings.LHPDDGIJKNB_Reset();
		FCIPEDFHFEM_TotalRewards.Clear();
		OHJFBLFELNK_m_intParam.Clear();
		FJOEBCMGDMI_m_stringParam.Clear();
		AFHHBNBCOKI.Clear();
		OCPGCHOGHPB_DefaultRivals.Clear();
		MBHDIJJEOFL.Clear();
		LLCLJBEJOPM_BannerInfo.Clear();
		IJJHFGOIDOK_EventMusic.Clear();
		GCFOLMHPDBG.Clear();
		PMJLEPGCAOA_ClassDatas.Clear();
		GEGAEDDGNMA_Bonuses.Clear();
		OGMHMAGDNAM_EpBonusBySceneRarity.Clear();
		LHAKGDAGEMM_EpBonusInfos.Clear();
	}

	// RVA: 0x122183C Offset: 0x122183C VA: 0x122183C Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		OPHFFGFJIBJ data = OPHFFGFJIBJ.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		DGKKMKLCEDF_DeserializeSetting(data);
		GPEKKMGGBPF(data);
		CFOFJPLEDEA(data);
		NFNBOEMGDPO(data);
		CMHJFPJFKAP(data);
		GJEHPJJBCDE(data);
		CDLNFNMFEEL(data);
		GMHGKHOBEKH(data);
		EGLHCMDNFOE(data);
		JBNBGGDDEGG(data);
		ABICOINNGEK(data);
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
		AIGOEAPJGEB.KHEKNNFCAOI_Init(MBHDIJJEOFL, data);
		IJNOIMLNBGN.KHEKNNFCAOI_Init(JIKKNHIAEKG_BlockName, LLCLJBEJOPM_BannerInfo, data);

		// Update dates
		UMOEventList.EventData CurrenEvent = UMOEventList.GetCurrentEvent();
		if (CurrenEvent != null && CurrenEvent.EnableBlock(JIKKNHIAEKG_BlockName))
		{
			System.DateTime date = Utility.GetLocalDateTime(Utility.GetCurrentUnixTime());
			System.DateTime date2 = Utility.GetLocalDateTime(NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart);
			date = date.AddDays(-1);
			long offset = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, date2.Hour, date2.Minute, date2.Second) - NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
			if (NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart != 0) NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart += offset;
			if (NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd != 0) NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd += offset;
			if (NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2 != 0) NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2 += offset;
			if (NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart != 0) NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart += offset;
			if (NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd != 0) NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd += offset;
			if (NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 != 0) NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 += offset;
			if (NGHKJOEDLIP_Settings.JBFDHOIKAIK_InventoryEndDate != 0) NGHKJOEDLIP_Settings.JBFDHOIKAIK_InventoryEndDate += offset;

			for(int i = 0; i < IJJHFGOIDOK_EventMusic.Count; i++)
			{
				if (IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at != 0) IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
				if (IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_close_at != 0) IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_close_at = NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
			}
			for(int i = 0; i < GCFOLMHPDBG.Count; i++)
			{
				if (GCFOLMHPDBG[i].PDBPFJJCADD_open_at != 0) GCFOLMHPDBG[i].PDBPFJJCADD_open_at = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
				if (GCFOLMHPDBG[i].FDBNFFNFOND_close_at != 0) GCFOLMHPDBG[i].FDBNFFNFOND_close_at = NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
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

	// RVA: 0x122413C Offset: 0x122413C VA: 0x122413C Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		TodoLogger.LogError(TodoLogger.DbJson, "ICFLJACCIKF_EventBattle.IIEMACPEEBJ_Deserialize");
		return true;
	}

	//// RVA: 0x1221BB0 Offset: 0x1221BB0 VA: 0x1221BB0
	private bool DGKKMKLCEDF_DeserializeSetting(OPHFFGFJIBJ JMHECKKKMLK)
	{
		NKCJNCELIJN data = JMHECKKKMLK.HMBHNLCFDIH;
		NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId = (int)data.OBGBAOLONDD_UniqueId;
		NGHKJOEDLIP_Settings.OPFGFINHFCE_name = data.OPFGFINHFCE_name;
		NGHKJOEDLIP_Settings.HEDAGCNPHGD_RankingName = data.HEDAGCNPHGD_RankingName;
		NGHKJOEDLIP_Settings.IDGAEEJLGIK = data.IDGAEEJLGIK;
		NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api = data.OCGFKMHNEOF_name_for_api;
		NGHKJOEDLIP_Settings.OGMGLOFKKPA = data.OGMGLOFKKPA;
		NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart = data.BONDDBOFBND_RankingStart;
		NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd = data.HPNOGLIFJOP_RankingEnd;
		NGHKJOEDLIP_Settings.EHHFFKAFOMC = data.EHHFFKAFOMC;
		NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2 = data.LNFKGHNHJKE_RankingEnd2;
		NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart = data.JGMDAOACOJF_RewardStart;
		NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd = data.IDDBFFBPNGI_RewardEnd;
		NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 = data.KNLGKBBIBOH_RewardEnd2;
		NGHKJOEDLIP_Settings.JBFDHOIKAIK_InventoryEndDate = data.JBFDHOIKAIK_InventoryEndDate;
		NGHKJOEDLIP_Settings.KHIKEGLBGAF_RankingRewardScene = (int)data.KHIKEGLBGAF_RankingRewardScene;
		NGHKJOEDLIP_Settings.DPJCFLKFEPN = (int)data.DPJCFLKFEPN;
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
		NGHKJOEDLIP_Settings.EKJFNHHKBPL = data.EKJFNHHKBPL;
		NGHKJOEDLIP_Settings.JKFPADIAKCK_Songs = data.JKFPADIAKCK_Songs;
		for(int i = 0; i < data.JHPCPNJJHLI_RankingThreshold.Length; i++)
		{
			if(data.JHPCPNJJHLI_RankingThreshold[i] < 1001)
			{
				NGHKJOEDLIP_Settings.JHPCPNJJHLI_RankingThreshold.Add(data.JHPCPNJJHLI_RankingThreshold[i]);
			}
		}
		for(int i = 0; i < data.HIAMHLLHAON_PlayCost.Length; i++)
		{
			if(i < data.HIAMHLLHAON_PlayCost.Length / 2)
				NGHKJOEDLIP_Settings.PFGFMLEEDLN((int)data.HIAMHLLHAON_PlayCost[i]);
			else
				NGHKJOEDLIP_Settings.OJLPDKAKDMC((int)data.HIAMHLLHAON_PlayCost[i]);
		}
		NGHKJOEDLIP_Settings.EEOGPJJCKHH_Drops.Clear();
		for(int i = 0; i < data.EEOGPJJCKHH_Drops.Length; i++)
		{
			NGHKJOEDLIP_Settings.EEOGPJJCKHH_Drops.Add((int)data.EEOGPJJCKHH_Drops[i]);
		}
		return true;
	}

	//// RVA: 0x1224144 Offset: 0x1224144 VA: 0x1224144
	//private bool DGKKMKLCEDF_DeserializeSetting(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x122414C Offset: 0x122414C VA: 0x122414C
	//private void EEEKPHDPJHG(List<int> NNDGIAEFMOG, EDOHBJAPLPF_JsonData OBHAFLMHAKG, string _OPFGFINHFCE_name, ref bool _NGJDHLGMHMH_IsInvalid) { }

	//// RVA: 0x122432C Offset: 0x122432C VA: 0x122432C
	//private void EEEKPHDPJHG(List<int> NNDGIAEFMOG, string OAIBJJHGCNM) { }

	//// RVA: 0x12226A0 Offset: 0x12226A0 VA: 0x12226A0
	private bool GPEKKMGGBPF(OPHFFGFJIBJ JMHECKKKMLK)
	{
		for(int i = 0; i < JMHECKKKMLK.MCHFABAKPMH.Length; i++)
		{
			FPJPKBBOICF array = JMHECKKKMLK.MCHFABAKPMH[i];
			BHBICAALJIA data = new BHBICAALJIA();
			data.PPFNGGCBJKC_id = (int)array.PPFNGGCBJKC_id;
			data.DNBFMLBNAEE_point = (int)array.FOILNHKHHDF_pt;
			data.JOPPFEHKNFO_Pickup = array.JOPPFEHKNFO_Pickup != 0;
			for(int j = 0; j < array.AIHOJKFNEEN_itm.Length; j++)
			{
				BEFNBMEMFOB data2 = new BEFNBMEMFOB();
				data2.GLCLFMGPMAN_ItemId = array.AIHOJKFNEEN_itm[j];
				data2.HMFFHLPNMPH_count = (int)array.BFINGCJHOHI_cnt[j];
				data2.NMKEOMCMIPP_RewardId = (int)array.JJHPDDPKBHF[j];
				data2.HJAFPEBIBOP_Limit = (int)array.HJAFPEBIBOP_Limit[j];
				data.AHJNPEAMCCH_rewards.Add(data2);
			}
			FCIPEDFHFEM_TotalRewards.Add(data);
		}
		return true;
	}

	//// RVA: 0x12244C8 Offset: 0x12244C8 VA: 0x12244C8
	//private bool GPEKKMGGBPF(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x1222AF4 Offset: 0x1222AF4 VA: 0x1222AF4
	private bool CFOFJPLEDEA(OPHFFGFJIBJ JMHECKKKMLK)
	{
		long time = Utility.GetCurrentUnixTime();
		int xor = (int)time * 11 + 1;
		for(int i = 0; i < JMHECKKKMLK.MDDOGIAFDEI.Length; i++)
		{
			AKIIJBEJOEP data = new AKIIJBEJOEP();
			data.KHEKNNFCAOI_Init(JIKKNHIAEKG_BlockName, i + 1, xor, JMHECKKKMLK);
			NNMPGOAGEOL_quests.Add(data);
			xor += 13;
		}
		return true;
	}

	//// RVA: 0x12244D0 Offset: 0x12244D0 VA: 0x12244D0
	//private bool CFOFJPLEDEA(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x1222C8C Offset: 0x1222C8C VA: 0x1222C8C
	private bool NFNBOEMGDPO(OPHFFGFJIBJ JMHECKKKMLK)
	{
		long time = Utility.GetCurrentUnixTime();
		int xor = (int)time * 11 + 1;
		for(int i = 0; i < JMHECKKKMLK.DDIGKGINBKL.Length; i++)
		{
			EBDMGCHHCFD array = JMHECKKKMLK.DDIGKGINBKL[i];
			LPJIKDAMGPC data = new LPJIKDAMGPC();
			data.FBGGEFFJJHB_xor = xor;
			data.EEAPIKNJNDB_ConsecutiveWin = array.EEAPIKNJNDB_ConsecutiveWin;
			data.NNDBJGDFEEM_Min = array.NNDBJGDFEEM_Min;
			data.DOOGFEGEKLG_max = array.DOOGFEGEKLG_max;
			data.HNDOLKNBOIJ = array.HNDOLKNBOIJ;
			data.HHGFOIMIGED = array.HHGFOIMIGED;
			data.IBCMDICBGHH = array.IBCMDICBGHH;
			data.HKAILALAFDG = array.HKAILALAFDG;
			data.DJJGNDCMNHF_BonusValue = array.DJJGNDCMNHF_BonusValue;
			AFHHBNBCOKI.Add(data);
			xor += 13;
		}
		return true;
	}

	//// RVA: 0x1222FC0 Offset: 0x1222FC0 VA: 0x1222FC0
	private bool CMHJFPJFKAP(OPHFFGFJIBJ JMHECKKKMLK)
	{
		long time = Utility.GetCurrentUnixTime();
		int xor = (int)time * 11 + 1;
        LCLCCHLDNHJ_Costume cosDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume;
        for (int i = 0; i < JMHECKKKMLK.MDMKOGDHCIC.Length; i++)
		{
			BAJEBICKGPF array = JMHECKKKMLK.MDMKOGDHCIC[i];
			FKACPHEKBNF data = new FKACPHEKBNF();
			data.FBGGEFFJJHB_xor = xor;
			data.BEEAIAAJOHD_CostumeId = 0;
			if(array.JFFOEAANFPG != 0)
			{
                LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = cosDb.NLIBHNJNJAN_GetUnlockedCostumeOrDefault(array.DIPKCALNIII_diva_id, array.JFFOEAANFPG);
                if (cos != null)
				{
					data.BEEAIAAJOHD_CostumeId = cos.JPIDIENBGKH_CostumeId;
				}
			}
			data.AKNELONELJK_difficulty = array.AKNELONELJK_difficulty;
			data.DIPKCALNIII_diva_id = array.DIPKCALNIII_diva_id;
			data.HEBKEJBDCBH_diva_lv = array.HEBKEJBDCBH_diva_lv;
			data.PLALNIIBLOF_en = array.PLALNIIBLOF_en;
			data.GOIKCKHMBDL_FreeMusicId = array.GOIKCKHMBDL_FreeMusicId;
			data.PPFNGGCBJKC_id = array.PPFNGGCBJKC_id;
			data.GLILAGLJLEP_SceneId = array.GLILAGLJLEP_SceneId;
			data.ECOLMPLOPFM_SceneLevel = array.ECOLMPLOPFM_SceneLevel;
			data.CFCIMKOHLIG_Mlt = array.CFCIMKOHLIG_Mlt;
			data.BDLNMOIOMHK_total = array.BDLNMOIOMHK_total;
			data.NLKEBAOBJCM_combo = array.NLKEBAOBJCM_combo;
			data.OPFGFINHFCE_name = array.OPFGFINHFCE_name;
			for(int j = 0; j < array.MJNMPAKBNKB_NotesResult.Length; j++)
			{
				data.MJNMPAKBNKB_NotesResult[j] = array.MJNMPAKBNKB_NotesResult[j];
			}
			data.EDJMDDAGCEJ_Score1 = array.EDJMDDAGCEJ_Score1;
			data.HEFPAIOLBAG_Score2 = array.HEFPAIOLBAG_Score2;
			data.KNIFCANOHOC_score = array.KNIFCANOHOC_score;
			data.IPPNCOHEEOD_ScoreAverage = array.IPPNCOHEEOD_ScoreAverage;
			data.ENNCJKLIGKE_Luck = array.ENNCJKLIGKE_Luck;
			data.PALEGNNHIKH_Leaf = array.PALEGNNHIKH_Leaf;
			data.JCDEDIOAGKE_ExcellentRatio = array.JCDEDIOAGKE_ExcellentRatio;
			OCPGCHOGHPB_DefaultRivals.Add(data);
			xor = xor * 3 + 13;
		}
		return true;
	}

	//// RVA: 0x1223824 Offset: 0x1223824 VA: 0x1223824
	private bool GJEHPJJBCDE(OPHFFGFJIBJ JMHECKKKMLK)
	{
		long time = Utility.GetCurrentUnixTime();
		int xor = (int)time * 11 + 1;
		for(int i = 0; i < JMHECKKKMLK.GHIHAGAOPNC.Length; i++)
		{
			OABJKIKLDKP data = new OABJKIKLDKP();
			data.KHEKNNFCAOI_Init(i + 1, xor, JMHECKKKMLK);
			IJJHFGOIDOK_EventMusic.Add(data);
			xor = xor * 3 + 13;
		}
		return true;
	}

	//// RVA: 0x12244D8 Offset: 0x12244D8 VA: 0x12244D8
	//private bool GJEHPJJBCDE(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x12239A8 Offset: 0x12239A8 VA: 0x12239A8
	private bool CDLNFNMFEEL(OPHFFGFJIBJ JMHECKKKMLK)
	{
		long time = Utility.GetCurrentUnixTime();
		int xor = (int)time * 11 + 1;
		for(int i = 0; i < JMHECKKKMLK.PLHPEOKOMHH.Length; i++)
		{
			KGHHHPHBGGM data = new KGHHHPHBGGM();
			data.KHEKNNFCAOI_Init(i + 1, xor, JMHECKKKMLK);
			GCFOLMHPDBG.Add(data);
			xor = xor * 3 + 13;
		}
		return true;
	}

	//// RVA: 0x12244E0 Offset: 0x12244E0 VA: 0x12244E0
	//private bool CDLNFNMFEEL(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x1223B2C Offset: 0x1223B2C VA: 0x1223B2C
	private bool GMHGKHOBEKH(OPHFFGFJIBJ JMHECKKKMLK)
	{
		long time = Utility.GetCurrentUnixTime();
		int xor = (int)time * 11 + 1;
		for(int i = 0; i < JMHECKKKMLK.NIPMOFJPFJG.Length; i++)
		{
			EIIMIHPLDFJ data = new EIIMIHPLDFJ();
			data.KHEKNNFCAOI_Init(i + 1, xor, JMHECKKKMLK);
			PMJLEPGCAOA_ClassDatas.Add(data);
			xor = xor * 3 + 13;
		}
		return true;
	}

	//// RVA: 0x12244E8 Offset: 0x12244E8 VA: 0x12244E8
	//private bool GMHGKHOBEKH(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x1223E34 Offset: 0x1223E34 VA: 0x1223E34
	private bool JBNBGGDDEGG(OPHFFGFJIBJ JMHECKKKMLK)
	{
		long time = Utility.GetCurrentUnixTime();
		int xor = (int)time * 11 + 1;
		for(int i = 0; i < JMHECKKKMLK.OLACFKILCFD.Length; i++)
		{
			FGBJDLLLBEF data = new FGBJDLLLBEF();
			data.BAFFAONJPCE(i, xor, JMHECKKKMLK);
			GEGAEDDGNMA_Bonuses.Add(data);
			xor = xor * 3 + 13;
		}
		return true;
	}

	//// RVA: 0x1223FB8 Offset: 0x1223FB8 VA: 0x1223FB8
	private bool ABICOINNGEK(OPHFFGFJIBJ JMHECKKKMLK)
	{
		long time = Utility.GetCurrentUnixTime();
		int xor = (int)time * 11 + 1;
		for(int i = 0; i < JMHECKKKMLK.MIOCOKLMLBD.Length; i++)
		{
			DGBPOCFMKMJ data = new DGBPOCFMKMJ();
			data.BAFFAONJPCE(i, xor, JMHECKKKMLK);
			OGMHMAGDNAM_EpBonusBySceneRarity.Add(data);
			xor = xor * 3 + 13;
		}
		return true;
	}

	//// RVA: 0x1223CB0 Offset: 0x1223CB0 VA: 0x1223CB0
	private bool EGLHCMDNFOE(OPHFFGFJIBJ JMHECKKKMLK)
	{
		long time = Utility.GetCurrentUnixTime();
		int xor = (int)time * 11 + 1;
		for(int i = 0; i < JMHECKKKMLK.IEJLJIHIDJC.Length; i++)
		{
			GNCIKNGDGPP data = new GNCIKNGDGPP();
			data.BAFFAONJPCE(i, xor, JMHECKKKMLK);
			LHAKGDAGEMM_EpBonusInfos.Add(data);
			xor = xor * 3 + 13;
		}
		return true;
	}

	// RVA: 0x12244F0 Offset: 0x12244F0 VA: 0x12244F0 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "ICFLJACCIKF_EventBattle.CAOGDCBPBAN");
		return 0;
	}
}
