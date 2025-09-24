
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use ACBAHDMEFFL_EventMission", true)]
public class ACBAHDMEFFL { }
public class ACBAHDMEFFL_EventMission : DIHHCBACKGG_DbSection
{
	public class IEPCJEPOFCO
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
		public long JBFDHOIKAIK_InventoryEndDate; // 0x58
		public int KHIKEGLBGAF_RankingRewardScene; // 0x60
		public int DPJCFLKFEPN; // 0x64
		public int MJBKGOJBPAD_item_type; // 0x68 TicketType
		public int EKJFNHHKBPL; // 0x6C
		public sbyte POGEFBMBPCB_MonthOdd; // 0x70
		public sbyte AHKNMANFILO_DayGroup; // 0x71
		public sbyte MOEKELIIDEO_SaveIdx; // 0x72
		public sbyte HKKNEAGCIEB_RankingSupport; // 0x73
		public sbyte AHKPNPNOAMO_ExtreamOpen; // 0x74
		public string OMCAOJJGOGG_Lb; // 0x78
		private NNJFKLBPBNK_SecureString EBGIDCIIGDO_KeyPrefix = new NNJFKLBPBNK_SecureString(); // 0x7C
		private NNJFKLBPBNK_SecureString NJKIMJAFCPC = new NNJFKLBPBNK_SecureString(); // 0x80
		public List<int> JHPCPNJJHLI_RankingThreshold = new List<int>(); // 0x84
		public int HIOOGLEJBKM_StartAdventureId; // 0x88
		public int FJCADCDNPMP_EndAdventureId; // 0x8C
		public int[] EJBGHLOOLBC_HelpIds; // 0x90
		public List<int> JKFPADIAKCK_Songs = new List<int>(); // 0x94
		public List<int> EEOGPJJCKHH_Drops = new List<int>(); // 0x98

		public string OCDMGOGMHGE_RewardPrefix { get { return EBGIDCIIGDO_KeyPrefix.DNJEJEANJGL_Value; } set { EBGIDCIIGDO_KeyPrefix.DNJEJEANJGL_Value = value; } } //0x15B7B48 HBAAAKFHDBB 0x15B5690 NHJLJOIPOFK
		public string PJBILOFOCIC { get { return NJKIMJAFCPC.DNJEJEANJGL_Value; } set { NJKIMJAFCPC.DNJEJEANJGL_Value = value; } } //0x15B7B74 NOEFEAIFHCL 0x15B56C4 GJIJFGNONEL

		//// RVA: 0x15B3298 Offset: 0x15B3298 VA: 0x15B3298
		public void LHPDDGIJKNB_Reset()
		{
			OBGBAOLONDD_UniqueId = 0;
			BONDDBOFBND_RankingStart = 0;
			HPNOGLIFJOP_RankingEnd = 0;
			JGMDAOACOJF_RewardStart = 0;
			IDDBFFBPNGI_RewardEnd = 0;
			JBFDHOIKAIK_InventoryEndDate = 0;
			KHIKEGLBGAF_RankingRewardScene = 0;
			DPJCFLKFEPN = 0;
			EHHFFKAFOMC = 0;
			MJBKGOJBPAD_item_type = 1;
			POGEFBMBPCB_MonthOdd = 0;
			AHKNMANFILO_DayGroup = 0;
			OPFGFINHFCE_name = null;
			HEDAGCNPHGD_RankingName = null;
			OCGFKMHNEOF_name_for_api = null;
			FEMMDNIELFC_Desc = null;
			OCDMGOGMHGE_RewardPrefix = "";
			PJBILOFOCIC = "";
			JHPCPNJJHLI_RankingThreshold.Clear();
			EKJFNHHKBPL = 0;
			OMCAOJJGOGG_Lb = "";
			HIOOGLEJBKM_StartAdventureId = 0;
			FJCADCDNPMP_EndAdventureId = 0;
			EJBGHLOOLBC_HelpIds = null;
			AHKPNPNOAMO_ExtreamOpen = 0;
			JKFPADIAKCK_Songs.Clear();
			EEOGPJJCKHH_Drops.Clear();
		}

		//// RVA: 0x15B6F3C Offset: 0x15B6F3C VA: 0x15B6F3C
		//public uint CAOGDCBPBAN() { }
	}

	public class FFAKNKMPIPH
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int KFCIJBLDHOK_v1; // 0xC
		public int JLEIHOEGMOP_v2; // 0x10
	}

	public class APANPEKLFBC
	{
		public int FBGGEFFJJHB_xor; // 0x8
		private int EHOIENNDEDH_IdCrypted; // 0xC
		private int FMDDJNKEBBB_Crypted; // 0x10
		private int MDKGAAMBJDJ_Crypted; // 0x14
		private int GGEBNMPPEID_Crypted; // 0x18

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x15B73E0 DEMEPMAEJOO 0x15B73F0 HIGKAIDMOKN
		public int CNKFPJCGNFE_SceneId { get { return FMDDJNKEBBB_Crypted ^ FBGGEFFJJHB_xor; } set { FMDDJNKEBBB_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x15B7400 GJBOGOFHGNP 0x15B7410 GJDGIDCMJMH
		public int GNFBMCGMCFO_BonusBefore { get { return MDKGAAMBJDJ_Crypted ^ FBGGEFFJJHB_xor; } set { MDKGAAMBJDJ_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x15B7420 NCIMMDJLPLJ 0x15B7430 HNAJAFBHOLM
		public int BFFGFAMJAIG_BonusAfter { get { return GGEBNMPPEID_Crypted ^ FBGGEFFJJHB_xor; } set { GGEBNMPPEID_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x15B7440 PKMNOMELPMN 0x15B7450 IABBJBAHKCE

		//// RVA: 0x15B72B8 Offset: 0x15B72B8 VA: 0x15B72B8
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x15B6258 Offset: 0x15B6258 VA: 0x15B6258
		public void BAFFAONJPCE(int JBGJDEELLOP, int KNEFBLHBDBG, EDHLNJNFNDN JMHECKKKMLK)
		{
			FBGGEFFJJHB_xor = KNEFBLHBDBG;
			PPFNGGCBJKC_id = 0;
			CNKFPJCGNFE_SceneId = 0;
			GNFBMCGMCFO_BonusBefore = 0;
			BFFGFAMJAIG_BonusAfter = 0;
			BPLJDGIFPNH d = JMHECKKKMLK.OLACFKILCFD[JBGJDEELLOP];
			PPFNGGCBJKC_id = d.PPFNGGCBJKC;
			CNKFPJCGNFE_SceneId = d.CNKFPJCGNFE;
			GNFBMCGMCFO_BonusBefore = d.GNFBMCGMCFO;
			BFFGFAMJAIG_BonusAfter = d.BFFGFAMJAIG;
		}

		//// RVA: 0x15B7460 Offset: 0x15B7460 VA: 0x15B7460
		//public void LHPDDGIJKNB_Reset(int KNEFBLHBDBG) { }
	}

	public class HJEGIDJGEBO
	{
		public int FBGGEFFJJHB_xor; // 0x8
		private int EHOIENNDEDH_IdCrypted; // 0xC
		private int MDKGAAMBJDJ_Crypted; // 0x10
		private int GGEBNMPPEID_Crypted; // 0x14

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x15B7AD8 DEMEPMAEJOO 0x15B7AE8 HIGKAIDMOKN
		public int GNFBMCGMCFO_BonusBefore { get { return MDKGAAMBJDJ_Crypted ^ FBGGEFFJJHB_xor; } set { MDKGAAMBJDJ_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x15B7AF8 NCIMMDJLPLJ 0x15B7B08 HNAJAFBHOLM
		public int BFFGFAMJAIG_BonusAfter { get { return GGEBNMPPEID_Crypted ^ FBGGEFFJJHB_xor; } set { GGEBNMPPEID_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x15B7B18 PKMNOMELPMN 0x15B7B28 IABBJBAHKCE

		//// RVA: 0x15B72E4 Offset: 0x15B72E4 VA: 0x15B72E4
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x15B63A4 Offset: 0x15B63A4 VA: 0x15B63A4
		public void BAFFAONJPCE(int JBGJDEELLOP, int KNEFBLHBDBG, EDHLNJNFNDN JMHECKKKMLK)
		{
			PPFNGGCBJKC_id = 0;
			GNFBMCGMCFO_BonusBefore = 0;
			BFFGFAMJAIG_BonusAfter = 0;
			LCDGEKPFHLD d = JMHECKKKMLK.MIOCOKLMLBD[JBGJDEELLOP];
			PPFNGGCBJKC_id = d.PPFNGGCBJKC;
			GNFBMCGMCFO_BonusBefore = d.GNFBMCGMCFO;
			BFFGFAMJAIG_BonusAfter = d.BFFGFAMJAIG;
		}

		//// RVA: 0x15B7B38 Offset: 0x15B7B38 VA: 0x15B7B38
		//public void LHPDDGIJKNB_Reset(int KNEFBLHBDBG) { }
	}

	public class JGNKPAJPDLN
	{
		public int FBGGEFFJJHB_xor; // 0x8
		private int HHEEHHHLKHC_Crypted; // 0xC
		private int LGAIHLFAPDC_Crypted; // 0x10
		public List<int> KDNMBOBEGJM_GachaIds = new List<int>(); // 0x14

		public int KHPHAAMGMJP_EpId { get { return HHEEHHHLKHC_Crypted ^ FBGGEFFJJHB_xor; } set { HHEEHHHLKHC_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x15B7BA0 ABFDDKBBPCH 0x15B7BB0 MHDOIIEMDEH
		public int OFIAENKCJME_BaseBonus { get { return LGAIHLFAPDC_Crypted ^ FBGGEFFJJHB_xor; } set { LGAIHLFAPDC_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x15B7BC0 KADLAKFANGA 0x15B7BD0 AIDAPNCEPOB

		//// RVA: 0x15B7308 Offset: 0x15B7308 VA: 0x15B7308
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x15B6534 Offset: 0x15B6534 VA: 0x15B6534
		public void BAFFAONJPCE(int JBGJDEELLOP, int KNEFBLHBDBG, EDHLNJNFNDN JMHECKKKMLK)
		{
			LHPDDGIJKNB_Reset(KNEFBLHBDBG);
			JOBECEGAHID d = JMHECKKKMLK.IEJLJIHIDJC[JBGJDEELLOP];
			KHPHAAMGMJP_EpId = d.KHPHAAMGMJP;
			OFIAENKCJME_BaseBonus = d.OFIAENKCJME;
			for(int j = 0; j < d.JMLCLHHLJHM.Length; j++)
			{
				KDNMBOBEGJM_GachaIds.Add(d.JMLCLHHLJHM[j]);
			}
		}

		//// RVA: 0x15B7BE0 Offset: 0x15B7BE0 VA: 0x15B7BE0
		public void LHPDDGIJKNB_Reset(int KNEFBLHBDBG)
		{
			FBGGEFFJJHB_xor = KNEFBLHBDBG;
			KHPHAAMGMJP_EpId = 0;
			OFIAENKCJME_BaseBonus = 0;
			KDNMBOBEGJM_GachaIds.Clear();
		}
	}

	public class PFKENFLKIOP
	{
		public int GLCLFMGPMAN_ItemId; // 0x8
		public int HMFFHLPNMPH_count; // 0xC
		public int NMKEOMCMIPP_RewardId; // 0x10
		public int HJAFPEBIBOP_Limit; // 0x14

		public bool PJPDOCNJNGJ { get { return HJAFPEBIBOP_Limit > 0; } } //0x15B81CC MBEBLALDBHJ
	}

	public class IOFFAADEIGD
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int DNBFMLBNAEE_point; // 0xC
		public List<PFKENFLKIOP> AHJNPEAMCCH_rewards = new List<PFKENFLKIOP>(); // 0x10
		public bool JOPPFEHKNFO_Pickup; // 0x14

		//// RVA: 0x15B7008 Offset: 0x15B7008 VA: 0x15B7008
		//public uint CAOGDCBPBAN() { }
	}

	public class FILIHFENGDB
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int PLALNIIBLOF_en; // 0xC
		public int MPLGPBNJDJB_FreeMusicId; // 0x10
		public int CJFEGGPILMF_MusicAttr; // 0x14
		public int GBJBMBEABOP_SerieAttr; // 0x18
		public int DKHIHHMOIKM_bns; // 0x1C Bonus
		public long PDBPFJJCADD_open_at; // 0x20
		public long FDBNFFNFOND_close_at; // 0x28

		//// RVA: 0x15B77D8 Offset: 0x15B77D8 VA: 0x15B77D8
		//public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id) { }

		//// RVA: 0x15B77FC Offset: 0x15B77FC VA: 0x15B77FC
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) { }
		// PPFNGGCBJKC_id = id
		// PLALNIIBLOF_en = en
		// MPLGPBNJDJB_FreeMusicId = f_music_id
		// CJFEGGPILMF_MusicAttr = music_attr
		// GBJBMBEABOP_SerieAttr = series_attr
		// DKHIHHMOIKM_bns = bns
		// PDBPFJJCADD_open_at = open_at
		// FDBNFFNFOND_close_at = close_at

		//// RVA: 0x15B5B10 Offset: 0x15B5B10 VA: 0x15B5B10
		public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, EDHLNJNFNDN JMHECKKKMLK)
		{
			PPFNGGCBJKC_id = _PPFNGGCBJKC_id;
			DKHIHHMOIKM_bns = 0;
			PDBPFJJCADD_open_at = 0;
			PLALNIIBLOF_en = 0;
			MPLGPBNJDJB_FreeMusicId = 0;
			CJFEGGPILMF_MusicAttr = 0;
			GBJBMBEABOP_SerieAttr = 0;
			FDBNFFNFOND_close_at = 0;
			OFJIGCDEOFA d = JMHECKKKMLK.GHIHAGAOPNC[_PPFNGGCBJKC_id - 1];
			PPFNGGCBJKC_id = (int)d.PPFNGGCBJKC;
			PLALNIIBLOF_en = (int)d.PLALNIIBLOF;
			MPLGPBNJDJB_FreeMusicId = (int)d.MPLGPBNJDJB;
			CJFEGGPILMF_MusicAttr = d.CJFEGGPILMF;
			GBJBMBEABOP_SerieAttr = d.GBJBMBEABOP;
			DKHIHHMOIKM_bns = (int)d.DKHIHHMOIKM;
			PDBPFJJCADD_open_at = d.PDBPFJJCADD;
			FDBNFFNFOND_close_at = d.FDBNFFNFOND;
		}

		//// RVA: 0x15B71B4 Offset: 0x15B71B4 VA: 0x15B71B4
		//public uint CAOGDCBPBAN() { }
	}

	public class BFHPHDAPEKA : AKIIJBEJOEP
	{
		//// RVA: 0x15B7474 Offset: 0x15B7474 VA: 0x15B7474
		//public void LHPDDGIJKNB_Reset(string _JOPOPMLFINI_QuestName, int _PPFNGGCBJKC_id, int KNEFBLHBDBG) { }

		//// RVA: 0x15B5CE4 Offset: 0x15B5CE4 VA: 0x15B5CE4
		public void BKEJPFLCLFC(string _JOPOPMLFINI_QuestName, int _PPFNGGCBJKC_id, int KNEFBLHBDBG, EDHLNJNFNDN JMHECKKKMLK)
		{
			FDKFKPGFHNE(_JOPOPMLFINI_QuestName, _PPFNGGCBJKC_id, KNEFBLHBDBG, JMHECKKKMLK);
		}

		//// RVA: 0x15B7200 Offset: 0x15B7200 VA: 0x15B7200
		//public uint CAOGDCBPBAN() { }
	}

	public class ONECEEIOJCP
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int PLALNIIBLOF_en; // 0xC
		public int FCBDGLEPGFJ_mid; // 0x10
		public string FEMMDNIELFC_Desc; // 0x14
		public int MLKFDMFDFCE_enemy_c_skill; // 0x18
		public int DKOPDNHDLIA_enemy_l_skill; // 0x1C

		public bool JKPDKNPDEBC_EnemyHasSkill { get { return MLKFDMFDFCE_enemy_c_skill > 0 || DKOPDNHDLIA_enemy_l_skill > 0; } } //0x15B7EA0 CPKGABEEPPO

		//// RVA: 0x15B7EC8 Offset: 0x15B7EC8 VA: 0x15B7EC8
		//public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id) { }

		//// RVA: 0x15B7F44 Offset: 0x15B7F44 VA: 0x15B7F44
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) { }
		//PPFNGGCBJKC_id = id
		//PLALNIIBLOF_en = en
		//FCBDGLEPGFJ_mid = mid
		//FEMMDNIELFC_Desc = desc
		//MLKFDMFDFCE_enemy_c_skill = enemy_c_skill
		//DKOPDNHDLIA_enemy_l_skill = enemy_l_skill

		//// RVA: 0x15B5D70 Offset: 0x15B5D70 VA: 0x15B5D70
		public void KHEKNNFCAOI_Init(string blockName, int _PPFNGGCBJKC_id, EDHLNJNFNDN JMHECKKKMLK)
		{
			PLALNIIBLOF_en = 0;
			PPFNGGCBJKC_id = _PPFNGGCBJKC_id;
			FCBDGLEPGFJ_mid = 0;
			MLKFDMFDFCE_enemy_c_skill = 0;
			FEMMDNIELFC_Desc = "";
			DKOPDNHDLIA_enemy_l_skill = 0;

			HFAHCMKLNBI d = JMHECKKKMLK.GAKHDIGGJNO[_PPFNGGCBJKC_id - 1];
			PPFNGGCBJKC_id = (int)d.PPFNGGCBJKC;
			PLALNIIBLOF_en = (int)d.PLALNIIBLOF;
			FCBDGLEPGFJ_mid = (int)d.FCBDGLEPGFJ;
			FEMMDNIELFC_Desc = DatabaseTextConverter.TranslateEventMissionMissionDesc(blockName, PPFNGGCBJKC_id, d.FEMMDNIELFC);
			MLKFDMFDFCE_enemy_c_skill = (int)d.MLKFDMFDFCE;
			DKOPDNHDLIA_enemy_l_skill = (int)d.DKOPDNHDLIA;
		}

		//// RVA: 0x15B721C Offset: 0x15B721C VA: 0x15B721C
		//public uint CAOGDCBPBAN() { }
	}

	public class BIMNGKEMMJM
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int PLALNIIBLOF_en; // 0xC
		public int MKNDAOHGOAK_weight; // 0x10
		public int BGFPMGPHGJJ_Mid1; // 0x14
		public int KEEHMNJCONJ_Mid2; // 0x18
		public int CFMIPHDGCAG_Mid3; // 0x1C
		public int JKAEKMMOJMF_Bns1; // 0x20
		public int DHDBOPKADII_Bns2; // 0x24
		public int OPNNCHMFEBH_Bns3; // 0x28

		//// RVA: 0x15B7494 Offset: 0x15B7494 VA: 0x15B7494
		//public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id) { }

		//// RVA: 0x15B74B0 Offset: 0x15B74B0 VA: 0x15B74B0
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) { }
		//PPFNGGCBJKC_id = id
		//PLALNIIBLOF_en = en
		//MKNDAOHGOAK_weight = weight
		//BGFPMGPHGJJ_Mid1 = mid1
		//KEEHMNJCONJ_Mid2 = mid2
		//CFMIPHDGCAG_Mid3 = mid3
		//JKAEKMMOJMF_Bns1 = bns1
		//DHDBOPKADII_Bns2 = bns2
		//OPNNCHMFEBH_Bns3 = bns3

		//// RVA: 0x15B5F3C Offset: 0x15B5F3C VA: 0x15B5F3C
		public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, EDHLNJNFNDN JMHECKKKMLK)
		{
			PPFNGGCBJKC_id = _PPFNGGCBJKC_id;
			CFMIPHDGCAG_Mid3 = 0;
			JKAEKMMOJMF_Bns1 = 0;
			DHDBOPKADII_Bns2 = 0;
			OPNNCHMFEBH_Bns3 = 0;
			PLALNIIBLOF_en = 0;
			MKNDAOHGOAK_weight = 0;
			BGFPMGPHGJJ_Mid1 = 0;
			KEEHMNJCONJ_Mid2 = 0;
			IMEGMKJJBML d = JMHECKKKMLK.JKMOLCDPLMI[_PPFNGGCBJKC_id - 1];
			PPFNGGCBJKC_id = (int)d.PPFNGGCBJKC;
			PLALNIIBLOF_en = (int)d.PLALNIIBLOF;
			MKNDAOHGOAK_weight = (int)d.MKNDAOHGOAK;
			BGFPMGPHGJJ_Mid1 = (int)d.BGFPMGPHGJJ;
			KEEHMNJCONJ_Mid2 = (int)d.KEEHMNJCONJ;
			CFMIPHDGCAG_Mid3 = (int)d.CFMIPHDGCAG;
			JKAEKMMOJMF_Bns1 = (int)d.JKAEKMMOJMF;
			DHDBOPKADII_Bns2 = (int)d.DHDBOPKADII;
			OPNNCHMFEBH_Bns3 = (int)d.OPNNCHMFEBH;
		}

		//// RVA: 0x15B724C Offset: 0x15B724C VA: 0x15B724C
		//public uint CAOGDCBPBAN() { }
	}

	public class KOBIAJFBPKG
	{
		public int PPFNGGCBJKC_id; // 0x8
		public string FEMMDNIELFC_Desc; // 0xC
		public int NANNGLGOFKH_value; // 0x10

		//// RVA: 0x15B7C68 Offset: 0x15B7C68 VA: 0x15B7C68
		//public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id) { }

		//// RVA: 0x15B7CD8 Offset: 0x15B7CD8 VA: 0x15B7CD8
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) { }
		//PPFNGGCBJKC_id = id
		//FEMMDNIELFC_Desc = desc
		//NANNGLGOFKH_value = value

		//// RVA: 0x15B6130 Offset: 0x15B6130 VA: 0x15B6130
		public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, EDHLNJNFNDN JMHECKKKMLK)
		{
			PPFNGGCBJKC_id = _PPFNGGCBJKC_id;
			FEMMDNIELFC_Desc = "";
			NANNGLGOFKH_value = 0;
			ACLIHCONIEL d = JMHECKKKMLK.EENKKKDBABF[_PPFNGGCBJKC_id - 1];
			PPFNGGCBJKC_id = (int)d.PPFNGGCBJKC;
			FEMMDNIELFC_Desc = d.FEMMDNIELFC;
			NANNGLGOFKH_value = (int)d.NANNGLGOFKH;
		}

		//// RVA: 0x15B72A0 Offset: 0x15B72A0 VA: 0x15B72A0
		//public uint CAOGDCBPBAN() { }
	}

	public IEPCJEPOFCO NGHKJOEDLIP_Settings = new IEPCJEPOFCO(); // 0x20
	public List<IOFFAADEIGD> FCIPEDFHFEM_TotalRewards = new List<IOFFAADEIGD>(); // 0x24 //total_rewards
	public List<AKIIJBEJOEP> NNMPGOAGEOL_quests = new List<AKIIJBEJOEP>(); // 0x28 // quests
	public List<FILIHFENGDB> IJJHFGOIDOK_EventMusic = new List<FILIHFENGDB>(); // 0x2C // event music
	public List<BFHPHDAPEKA> GAAHOOBMDEE_Mission = new List<BFHPHDAPEKA>(); // 0x30 // Mission
	public List<ONECEEIOJCP> LGODPKPFGHF_MissionCond = new List<ONECEEIOJCP>(); // 0x34 // mission cond
	public List<BIMNGKEMMJM> ABJIDJODLIM_MissionSet = new List<BIMNGKEMMJM>(); // 0x38 // mission set
	public List<KOBIAJFBPKG> FHDCGHEKJLL = new List<KOBIAJFBPKG>(); // 0x3C // base point
	public List<KOBIAJFBPKG> JFJJOCODMIB = new List<KOBIAJFBPKG>(); // 0x40
	public List<APANPEKLFBC> GEGAEDDGNMA_Bonuses = new List<APANPEKLFBC>(); // 0x44//EpBonusByScene
	public List<HJEGIDJGEBO> OGMHMAGDNAM_EpBonusBySceneRarity = new List<HJEGIDJGEBO>(); // 0x48
	public List<JGNKPAJPDLN> LHAKGDAGEMM_EpBonusInfos = new List<JGNKPAJPDLN>(); // 0x4C
	public List<FFAKNKMPIPH> ADPFKHEMNBL = new List<FFAKNKMPIPH>(); // 0x58
	public List<AIGOEAPJGEB> MBHDIJJEOFL = new List<AIGOEAPJGEB>(); // 0x5C
	public List<IJNOIMLNBGN> LLCLJBEJOPM_BannerInfo = new List<IJNOIMLNBGN>(); // 0x60

	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI_m_stringParam { get; private set; } // 0x50 IHKPIFIBECO GAMGELHIHHI DDDEJIJGGBJ
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK_m_intParam { get; private set; } // 0x54 KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB

	//// RVA: 0x15B2904 Offset: 0x15B2904 VA: 0x15B2904
	public string EFEGBHACJAL_GetStringParam(string _LJNAKDMILMC_key, string _KKMJBMKHGNH_noval)
	{
		if(FJOEBCMGDMI_m_stringParam.ContainsKey(_LJNAKDMILMC_key))
			return FJOEBCMGDMI_m_stringParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
		return _KKMJBMKHGNH_noval;
	}

	//// RVA: 0x15B29E8 Offset: 0x15B29E8 VA: 0x15B29E8
	public int LPJLEHAJADA_GetIntParam(string _LJNAKDMILMC_key, int _KKMJBMKHGNH_noval)
	{
		if(OHJFBLFELNK_m_intParam.ContainsKey(_LJNAKDMILMC_key))
			return OHJFBLFELNK_m_intParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
		return _KKMJBMKHGNH_noval;
	}

	// RVA: 0x15B2ACC Offset: 0x15B2ACC VA: 0x15B2ACC
	public ACBAHDMEFFL_EventMission()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		OHJFBLFELNK_m_intParam = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		FJOEBCMGDMI_m_stringParam = new Dictionary<string, NNJFKLBPBNK_SecureString>();
		LMHMIIKCGPE = 37;
	}

	// RVA: 0x15B2FC8 Offset: 0x15B2FC8 VA: 0x15B2FC8 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		NGHKJOEDLIP_Settings.LHPDDGIJKNB_Reset();
		FCIPEDFHFEM_TotalRewards.Clear();
		NNMPGOAGEOL_quests.Clear();
		IJJHFGOIDOK_EventMusic.Clear();
		GAAHOOBMDEE_Mission.Clear();
		LGODPKPFGHF_MissionCond.Clear();
		ABJIDJODLIM_MissionSet.Clear();
		FHDCGHEKJLL.Clear();
		JFJJOCODMIB.Clear();
		OHJFBLFELNK_m_intParam.Clear();
		FJOEBCMGDMI_m_stringParam.Clear();
		ADPFKHEMNBL.Clear();
		GEGAEDDGNMA_Bonuses.Clear();
		LHAKGDAGEMM_EpBonusInfos.Clear();
		OGMHMAGDNAM_EpBonusBySceneRarity.Clear();
	}

	// RVA: 0x15B33F8 Offset: 0x15B33F8 VA: 0x15B33F8 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		EDHLNJNFNDN reader = EDHLNJNFNDN.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		DGKKMKLCEDF(reader);
		GPEKKMGGBPF(reader);
		CFOFJPLEDEA(reader);
		GJEHPJJBCDE(reader);
		EFLPPDGDHBM(reader);
		KPOGKBAFHAI(reader);
		HBOCGBHBKCH(reader);
		GDMNJDONAPE(reader);
		ABICOINNGEK(reader);
		EGLHCMDNFOE(reader);
		JBNBGGDDEGG(reader);
		for(int i = 0; i < reader.BHGDNGHDDAC.Length; i++)
		{
			CEBFFLDKAEC_SecureInt d = new CEBFFLDKAEC_SecureInt();
			d.DNJEJEANJGL_Value = reader.BHGDNGHDDAC[i].JBGEEPFKIGG;
			OHJFBLFELNK_m_intParam.Add(reader.BHGDNGHDDAC[i].LJNAKDMILMC, d);
		}
		for(int i = 0; i < reader.MHGMDJNOLMI.Length; i++)
		{
			NNJFKLBPBNK_SecureString d = new NNJFKLBPBNK_SecureString();
			d.DNJEJEANJGL_Value = reader.MHGMDJNOLMI[i].JBGEEPFKIGG;
			FJOEBCMGDMI_m_stringParam.Add(reader.MHGMDJNOLMI[i].LJNAKDMILMC, d);
		}
		for(int i = 0; i < reader.KIEKMCKCMGD.Length; i++)
		{
			FFAKNKMPIPH d = new FFAKNKMPIPH();
			d.PPFNGGCBJKC_id = reader.KIEKMCKCMGD[i].PPFNGGCBJKC;
			d.KFCIJBLDHOK_v1 = reader.KIEKMCKCMGD[i].KFCIJBLDHOK;
			d.JLEIHOEGMOP_v2 = reader.KIEKMCKCMGD[i].JLEIHOEGMOP;
			ADPFKHEMNBL.Add(d);
		}

		UnityEngine.Debug.LogError(NGHKJOEDLIP_Settings.OPFGFINHFCE_name+" "+NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId+", Gacha : "+LPJLEHAJADA_GetIntParam("gacha_box_event_id", 0));

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
			if (NGHKJOEDLIP_Settings.EHHFFKAFOMC != 0) NGHKJOEDLIP_Settings.EHHFFKAFOMC += offset;
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
			for(int i = 0; i < NNMPGOAGEOL_quests.Count; i++)
			{
				if (NNMPGOAGEOL_quests[i].KJBGCLPMLCG_OpenedAt != 0) NNMPGOAGEOL_quests[i].KJBGCLPMLCG_OpenedAt = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
				if (NNMPGOAGEOL_quests[i].GJFPFFBAKGK_CloseAt != 0) NNMPGOAGEOL_quests[i].GJFPFFBAKGK_CloseAt = NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
			}
			for(int i = 0; i < GAAHOOBMDEE_Mission.Count; i++)
			{
				if (GAAHOOBMDEE_Mission[i].KJBGCLPMLCG_OpenedAt != 0) NNMPGOAGEOL_quests[i].KJBGCLPMLCG_OpenedAt = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
				if (GAAHOOBMDEE_Mission[i].GJFPFFBAKGK_CloseAt != 0) NNMPGOAGEOL_quests[i].GJFPFFBAKGK_CloseAt = NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
			}
			for(int i = 0; i < LLCLJBEJOPM_BannerInfo.Count; i++)
			{
				if (LLCLJBEJOPM_BannerInfo[i].PDBPFJJCADD_open_at != 0) LLCLJBEJOPM_BannerInfo[i].PDBPFJJCADD_open_at = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
				if (LLCLJBEJOPM_BannerInfo[i].FDBNFFNFOND_close_at != 0) LLCLJBEJOPM_BannerInfo[i].FDBNFFNFOND_close_at = NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
			}
		}
		return true;
	}

	// RVA: 0x15B5410 Offset: 0x15B5410 VA: 0x15B5410 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		//NGHKJOEDLIP_Settings = setting
		//FCIPEDFHFEM_TotalRewards = total_rewards
		//NNMPGOAGEOL_quests = quests
		//IJJHFGOIDOK_EventMusic = event_music
		//GAAHOOBMDEE_Mission = mission
		//LGODPKPFGHF_MissionCond = mission_cond
		//ABJIDJODLIM_MissionSet = mission_set
		//FHDCGHEKJLL = base_point??
		TodoLogger.LogError(TodoLogger.DbJson, "ACBAHDMEFFL_EventMission.IIEMACPEEBJ");
		return true;
	}

	//// RVA: 0x15B388C Offset: 0x15B388C VA: 0x15B388C
	private bool DGKKMKLCEDF(EDHLNJNFNDN LKOMBCHIDMB)
	{
		NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId = (int)LKOMBCHIDMB.HMBHNLCFDIH.OBGBAOLONDD;
		NGHKJOEDLIP_Settings.OPFGFINHFCE_name = LKOMBCHIDMB.HMBHNLCFDIH.OPFGFINHFCE;
		NGHKJOEDLIP_Settings.HEDAGCNPHGD_RankingName = LKOMBCHIDMB.HMBHNLCFDIH.HEDAGCNPHGD;
		NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api = LKOMBCHIDMB.HMBHNLCFDIH.OCGFKMHNEOF;
		NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart = LKOMBCHIDMB.HMBHNLCFDIH.BONDDBOFBND;
		NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd = LKOMBCHIDMB.HMBHNLCFDIH.HPNOGLIFJOP;
		NGHKJOEDLIP_Settings.EHHFFKAFOMC = LKOMBCHIDMB.HMBHNLCFDIH.EHHFFKAFOMC;
		NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2 = LKOMBCHIDMB.HMBHNLCFDIH.LNFKGHNHJKE;
		NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart = LKOMBCHIDMB.HMBHNLCFDIH.JGMDAOACOJF;
		NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd = LKOMBCHIDMB.HMBHNLCFDIH.IDDBFFBPNGI;
		NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 = LKOMBCHIDMB.HMBHNLCFDIH.KNLGKBBIBOH;
		NGHKJOEDLIP_Settings.JBFDHOIKAIK_InventoryEndDate = LKOMBCHIDMB.HMBHNLCFDIH.JBFDHOIKAIK;
		NGHKJOEDLIP_Settings.KHIKEGLBGAF_RankingRewardScene = (int)LKOMBCHIDMB.HMBHNLCFDIH.KHIKEGLBGAF;
		NGHKJOEDLIP_Settings.DPJCFLKFEPN = (int)LKOMBCHIDMB.HMBHNLCFDIH.DPJCFLKFEPN;
		NGHKJOEDLIP_Settings.POGEFBMBPCB_MonthOdd = (sbyte)LKOMBCHIDMB.HMBHNLCFDIH.JMJDLDEIFKE;
		NGHKJOEDLIP_Settings.AHKNMANFILO_DayGroup = (sbyte)LKOMBCHIDMB.HMBHNLCFDIH.AHKNMANFILO;
		NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx = (sbyte)LKOMBCHIDMB.HMBHNLCFDIH.MOEKELIIDEO;
		NGHKJOEDLIP_Settings.OCDMGOGMHGE_RewardPrefix = LKOMBCHIDMB.HMBHNLCFDIH.OCDMGOGMHGE;
		NGHKJOEDLIP_Settings.PJBILOFOCIC = LKOMBCHIDMB.HMBHNLCFDIH.PJBILOFOCIC;
		NGHKJOEDLIP_Settings.MJBKGOJBPAD_item_type = LKOMBCHIDMB.HMBHNLCFDIH.MJBKGOJBPAD;
		NGHKJOEDLIP_Settings.FEMMDNIELFC_Desc = LKOMBCHIDMB.HMBHNLCFDIH.FEMMDNIELFC;
		NGHKJOEDLIP_Settings.HKKNEAGCIEB_RankingSupport = (sbyte)LKOMBCHIDMB.HMBHNLCFDIH.HKKNEAGCIEB;
		NGHKJOEDLIP_Settings.HIOOGLEJBKM_StartAdventureId = LKOMBCHIDMB.HMBHNLCFDIH.HIOOGLEJBKM;
		NGHKJOEDLIP_Settings.FJCADCDNPMP_EndAdventureId = LKOMBCHIDMB.HMBHNLCFDIH.FJCADCDNPMP;
		NGHKJOEDLIP_Settings.EJBGHLOOLBC_HelpIds = LKOMBCHIDMB.HMBHNLCFDIH.EJBGHLOOLBC;
		NGHKJOEDLIP_Settings.AHKPNPNOAMO_ExtreamOpen = (sbyte)LKOMBCHIDMB.HMBHNLCFDIH.AHKPNPNOAMO;
		NGHKJOEDLIP_Settings.OMCAOJJGOGG_Lb = LKOMBCHIDMB.HMBHNLCFDIH.OMCAOJJGOGG;
		NGHKJOEDLIP_Settings.EKJFNHHKBPL = LKOMBCHIDMB.HMBHNLCFDIH.EKJFNHHKBPL;
		for(int i = 0; i < LKOMBCHIDMB.HMBHNLCFDIH.JHPCPNJJHLI.Length; i++)
		{
			if(LKOMBCHIDMB.HMBHNLCFDIH.JHPCPNJJHLI[i] < 1001)
			{
				NGHKJOEDLIP_Settings.JHPCPNJJHLI_RankingThreshold.Add(LKOMBCHIDMB.HMBHNLCFDIH.JHPCPNJJHLI[i]);
			}
		}
		NGHKJOEDLIP_Settings.JKFPADIAKCK_Songs.Clear();
		for(int i = 0; i < LKOMBCHIDMB.HMBHNLCFDIH.JKFPADIAKCK.Length; i++)
		{
			NGHKJOEDLIP_Settings.JKFPADIAKCK_Songs.Add(LKOMBCHIDMB.HMBHNLCFDIH.JKFPADIAKCK[i]);
		}
		NGHKJOEDLIP_Settings.EEOGPJJCKHH_Drops.Clear();
		for(int i = 0; i < LKOMBCHIDMB.HMBHNLCFDIH.EEOGPJJCKHH.Length; i++)
		{
			NGHKJOEDLIP_Settings.EEOGPJJCKHH_Drops.Add((int)LKOMBCHIDMB.HMBHNLCFDIH.EEOGPJJCKHH[i]);
		}
		AIGOEAPJGEB.KHEKNNFCAOI_Init(MBHDIJJEOFL, LKOMBCHIDMB);
		IJNOIMLNBGN.KHEKNNFCAOI_Init(JIKKNHIAEKG_BlockName, LLCLJBEJOPM_BannerInfo, LKOMBCHIDMB);
		return true;
	}

	//// RVA: 0x15B5650 Offset: 0x15B5650 VA: 0x15B5650
	//private bool DGKKMKLCEDF(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x15B56F8 Offset: 0x15B56F8 VA: 0x15B56F8
	//private void EEEKPHDPJHG(List<int> NNDGIAEFMOG, EDOHBJAPLPF_JsonData OBHAFLMHAKG, string _OPFGFINHFCE_name, ref bool _NGJDHLGMHMH_IsInvalid) { }

	//// RVA: 0x15B58D8 Offset: 0x15B58D8 VA: 0x15B58D8
	//private void EEEKPHDPJHG(List<int> NNDGIAEFMOG, string OAIBJJHGCNM) { }

	//// RVA: 0x15B4304 Offset: 0x15B4304 VA: 0x15B4304
	private bool GPEKKMGGBPF(EDHLNJNFNDN LKOMBCHIDMB)
	{
		for(int i = 0; i < LKOMBCHIDMB.MCHFABAKPMH.Length; i++)
		{
			IOFFAADEIGD d = new IOFFAADEIGD();
			d.PPFNGGCBJKC_id = (int)LKOMBCHIDMB.MCHFABAKPMH[i].PPFNGGCBJKC;
			d.DNBFMLBNAEE_point = (int)LKOMBCHIDMB.MCHFABAKPMH[i].FOILNHKHHDF;
			d.JOPPFEHKNFO_Pickup = LKOMBCHIDMB.MCHFABAKPMH[i].JOPPFEHKNFO != 0;
			for(int j = 0; j < LKOMBCHIDMB.MCHFABAKPMH[i].AIHOJKFNEEN.Length; j++)
			{
				PFKENFLKIOP d2 = new PFKENFLKIOP();
				d2.GLCLFMGPMAN_ItemId = LKOMBCHIDMB.MCHFABAKPMH[i].AIHOJKFNEEN[j];
				d2.HMFFHLPNMPH_count = (int)LKOMBCHIDMB.MCHFABAKPMH[i].BFINGCJHOHI[j];
				d2.NMKEOMCMIPP_RewardId = (int)LKOMBCHIDMB.MCHFABAKPMH[i].JJHPDDPKBHF[j];
				d2.HJAFPEBIBOP_Limit = (int)LKOMBCHIDMB.MCHFABAKPMH[i].HJAFPEBIBOP[j];
				d.AHJNPEAMCCH_rewards.Add(d2);
			}
			FCIPEDFHFEM_TotalRewards.Add(d);
		}
		return true;
	}

	//// RVA: 0x15B5658 Offset: 0x15B5658 VA: 0x15B5658
	//private bool GPEKKMGGBPF(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x15B4754 Offset: 0x15B4754 VA: 0x15B4754
	private bool CFOFJPLEDEA(EDHLNJNFNDN LKOMBCHIDMB)
	{
		int xor = (int)Utility.GetCurrentUnixTime() * 11 + 1;
		for(int i = 0; i < LKOMBCHIDMB.MDDOGIAFDEI.Length; i++)
		{
			AKIIJBEJOEP d = new AKIIJBEJOEP();
			d.KHEKNNFCAOI_Init(JIKKNHIAEKG_BlockName, i + 1, xor, LKOMBCHIDMB);
			NNMPGOAGEOL_quests.Add(d);
			xor += 13;
		}
		return true;
	}

	//// RVA: 0x15B5660 Offset: 0x15B5660 VA: 0x15B5660
	//private bool CFOFJPLEDEA(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x15B48EC Offset: 0x15B48EC VA: 0x15B48EC
	private bool GJEHPJJBCDE(EDHLNJNFNDN LKOMBCHIDMB)
	{
		for(int i = 0; i < LKOMBCHIDMB.GHIHAGAOPNC.Length; i++)
		{
			FILIHFENGDB d = new FILIHFENGDB();
			d.KHEKNNFCAOI_Init(i + 1, LKOMBCHIDMB);
			IJJHFGOIDOK_EventMusic.Add(d);
		}
		return true;
	}

	//// RVA: 0x15B5668 Offset: 0x15B5668 VA: 0x15B5668
	//private bool GJEHPJJBCDE(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x15B4A08 Offset: 0x15B4A08 VA: 0x15B4A08
	private bool EFLPPDGDHBM(EDHLNJNFNDN LKOMBCHIDMB)
	{
		int xor = (int)NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime() * 77;
		for(int i = 0; i < LKOMBCHIDMB.HBMGNHBFPHC.Length; i++)
		{
			BFHPHDAPEKA d = new BFHPHDAPEKA();
			d.BKEJPFLCLFC(JIKKNHIAEKG_BlockName, i + 1, xor, LKOMBCHIDMB);
			GAAHOOBMDEE_Mission.Add(d);
			xor *= 11;
		}
		return true;
	}

	//// RVA: 0x15B5670 Offset: 0x15B5670 VA: 0x15B5670
	//private bool EFLPPDGDHBM(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x15B4BF8 Offset: 0x15B4BF8 VA: 0x15B4BF8
	private bool KPOGKBAFHAI(EDHLNJNFNDN LKOMBCHIDMB)
	{
		for(int i = 0; i < LKOMBCHIDMB.GAKHDIGGJNO.Length; i++)
		{
			ONECEEIOJCP d = new ONECEEIOJCP();
			d.KHEKNNFCAOI_Init(JIKKNHIAEKG_BlockName, i + 1, LKOMBCHIDMB);
			LGODPKPFGHF_MissionCond.Add(d);
		}
		return true;
	}

	//// RVA: 0x15B5678 Offset: 0x15B5678 VA: 0x15B5678
	//private bool KPOGKBAFHAI(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x15B4D14 Offset: 0x15B4D14 VA: 0x15B4D14
	private bool HBOCGBHBKCH(EDHLNJNFNDN LKOMBCHIDMB)
	{
		for(int i = 0; i < LKOMBCHIDMB.JKMOLCDPLMI.Length; i++)
		{
			BIMNGKEMMJM d = new BIMNGKEMMJM();
			d.KHEKNNFCAOI_Init(i + 1, LKOMBCHIDMB);
			ABJIDJODLIM_MissionSet.Add(d);
		}
		return true;
	}

	//// RVA: 0x15B5680 Offset: 0x15B5680 VA: 0x15B5680
	//private bool HBOCGBHBKCH(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x15B4E30 Offset: 0x15B4E30 VA: 0x15B4E30
	private bool GDMNJDONAPE(EDHLNJNFNDN LKOMBCHIDMB)
	{
		for(int i = 0; i < LKOMBCHIDMB.EENKKKDBABF.Length; i++)
		{
			KOBIAJFBPKG d = new KOBIAJFBPKG();
			d.KHEKNNFCAOI_Init(i + 1, LKOMBCHIDMB);
			if(i < LKOMBCHIDMB.EENKKKDBABF.Length / 2)
				FHDCGHEKJLL.Add(d);
			else
				JFJJOCODMIB.Add(d);
		}
		return true;
	}

	//// RVA: 0x15B5688 Offset: 0x15B5688 VA: 0x15B5688
	//private bool GDMNJDONAPE(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x15B528C Offset: 0x15B528C VA: 0x15B528C
	private bool JBNBGGDDEGG(EDHLNJNFNDN JMHECKKKMLK)
	{
		int xor = (int)Utility.GetCurrentUnixTime() * 11 + 1;
		for(int i = 0; i < JMHECKKKMLK.OLACFKILCFD.Length; i++)
		{
			APANPEKLFBC d = new APANPEKLFBC();
			d.BAFFAONJPCE(i, xor, JMHECKKKMLK);
			GEGAEDDGNMA_Bonuses.Add(d);
			xor = xor * 3 + 13;
		}
		return true;
	}

	//// RVA: 0x15B4F98 Offset: 0x15B4F98 VA: 0x15B4F98
	private bool ABICOINNGEK(EDHLNJNFNDN JMHECKKKMLK)
	{
		int xor = (int)Utility.GetCurrentUnixTime() * 11 + 1;
		for(int i = 0; i < JMHECKKKMLK.MIOCOKLMLBD.Length; i++)
		{
			HJEGIDJGEBO d = new HJEGIDJGEBO();
			d.BAFFAONJPCE(i, xor, JMHECKKKMLK);
			OGMHMAGDNAM_EpBonusBySceneRarity.Add(d);
			xor = xor * 3 + 13;
		}
		return true;
	}

	//// RVA: 0x15B5114 Offset: 0x15B5114 VA: 0x15B5114
	private bool EGLHCMDNFOE(EDHLNJNFNDN JMHECKKKMLK)
	{
		int xor = (int)Utility.GetCurrentUnixTime() * 11 + 1;
		for(int i = 0; i < JMHECKKKMLK.IEJLJIHIDJC.Length; i++)
		{
			JGNKPAJPDLN d = new JGNKPAJPDLN();
			d.BAFFAONJPCE(i, xor, JMHECKKKMLK);
			LHAKGDAGEMM_EpBonusInfos.Add(d);
		}
		return true;
	}

	// RVA: 0x15B6708 Offset: 0x15B6708 VA: 0x15B6708 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "ACBAHDMEFFL_EventMission.CAOGDCBPBAN");
		return 0;
	}
}
