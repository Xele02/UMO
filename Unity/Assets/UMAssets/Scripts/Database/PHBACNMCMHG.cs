
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use PHBACNMCMHG_EventCollection", true)]
public class PHBACNMCMHG { }
public class PHBACNMCMHG_EventCollection : DIHHCBACKGG_DbSection
{
	public class IHCDILMMOJM
	{
		public int OBGBAOLONDD_UniqueId; // 0x8
		public string OPFGFINHFCE_name; // 0xC
		public string HEDAGCNPHGD_RankingName; // 0x10
		public string IDGAEEJLGIK; // 0x14
		public string OCGFKMHNEOF_name_for_api; // 0x18
		public string OGMGLOFKKPA; // 0x1C
		public string FEMMDNIELFC_Desc; // 0x20
		public long BONDDBOFBND_RankingStart; // 0x28
		public long EHHFFKAFOMC; // 0x30
		public long HPNOGLIFJOP_RankingEnd; // 0x38
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
		public int EKJFNHHKBPL; // 0x7C
		private NNJFKLBPBNK_SecureString EBGIDCIIGDO_KeyPrefix = new NNJFKLBPBNK_SecureString(); // 0x80
		private NNJFKLBPBNK_SecureString NJKIMJAFCPC = new NNJFKLBPBNK_SecureString(); // 0x84
		public sbyte MPKNCMEAMLO; // 0x88
		public sbyte AHKPNPNOAMO_ExtreamOpen; // 0x89
		public sbyte HKKNEAGCIEB_RankingSupport; // 0x8A
		public List<int> CAPAPAABKDP_FreeMusic = new List<int>(); // 0x8C
		public List<int> HKEAFPNNAPC = new List<int>(); // 0x90
		public List<int> MCDPPHKEMJI = new List<int>(); // 0x94
		public List<int> BJHHDGCOACI = new List<int>(); // 0x98
		public List<int> JDDIOIMOFDE = new List<int>(); // 0x9C
		private List<int> DMDHPBNAPKI = new List<int>(); // 0xA0
		private List<int> HOJFGDGNBCF = new List<int>(); // 0xA4
		public List<int> JHPCPNJJHLI_RankingThreshold = new List<int>(); // 0xA8
		public int HIOOGLEJBKM_StartAdventureId; // 0xAC
		public int FJCADCDNPMP_EndAdventureId; // 0xB0
		public int[] EJBGHLOOLBC_HelpIds; // 0xB4
		public List<int> EEOGPJJCKHH_Drops = new List<int>(); // 0xB8

		public string OCDMGOGMHGE_RewardPrefix { get { return EBGIDCIIGDO_KeyPrefix.DNJEJEANJGL_Value; } set { EBGIDCIIGDO_KeyPrefix.DNJEJEANJGL_Value = value; } } //0x16CF088 HBAAAKFHDBB 0x16CD898 NHJLJOIPOFK
		public string PJBILOFOCIC { get { return NJKIMJAFCPC.DNJEJEANJGL_Value; } set { NJKIMJAFCPC.DNJEJEANJGL_Value = value; } } //0x16CF0B4 NOEFEAIFHCL 0x16CD8CC GJIJFGNONEL

		//// RVA: 0x16CDA9C Offset: 0x16CDA9C VA: 0x16CDA9C
		public void LLMCLICMLLG(int _NANNGLGOFKH_value)
		{
			DMDHPBNAPKI.Add(_NANNGLGOFKH_value);
		}

		//// RVA: 0x16CDB1C Offset: 0x16CDB1C VA: 0x16CDB1C
		public void DJBHHJEJPFK(int _NANNGLGOFKH_value)
		{
			HOJFGDGNBCF.Add(_NANNGLGOFKH_value);
		}

		//// RVA: 0x16CF0E0 Offset: 0x16CF0E0 VA: 0x16CF0E0
		public int KIGCDOJGJEP(int _AKNELONELJK_difficulty, bool _GIKLNODJKFK_IsLine6)
		{
			if(_GIKLNODJKFK_IsLine6)
				return HOJFGDGNBCF[_AKNELONELJK_difficulty];
			else
				return DMDHPBNAPKI[_AKNELONELJK_difficulty];
		}

		//// RVA: 0x16CB724 Offset: 0x16CB724 VA: 0x16CB724
		public void LHPDDGIJKNB_Reset()
		{
			OBGBAOLONDD_UniqueId = 0;
			JGMDAOACOJF_RewardStart = 0;
			IDDBFFBPNGI_RewardEnd = 0;
			JBFDHOIKAIK_InventoryEndDate = 0;
			KHIKEGLBGAF_RankingRewardScene = 0;
			DPJCFLKFEPN = 0;
			BONDDBOFBND_RankingStart = 0;
			EHHFFKAFOMC = 0;
			HPNOGLIFJOP_RankingEnd = 0;
			OGMGLOFKKPA = "";
			FEMMDNIELFC_Desc = "";
			POGEFBMBPCB_MonthOdd = 0;
			AHKNMANFILO_DayGroup = 0;
			MOEKELIIDEO_SaveIdx = 0;
			MJBKGOJBPAD_item_type = 1;
			EKJFNHHKBPL = 0;
			OPFGFINHFCE_name = null;
			HEDAGCNPHGD_RankingName = null;
			IDGAEEJLGIK = null;
			OCGFKMHNEOF_name_for_api = null;
			OCDMGOGMHGE_RewardPrefix = "";
			PJBILOFOCIC = "";
			MPKNCMEAMLO = 0;
			CAPAPAABKDP_FreeMusic.Clear();
			HKEAFPNNAPC.Clear();
			MCDPPHKEMJI.Clear();
			BJHHDGCOACI.Clear();
			JDDIOIMOFDE.Clear();
			DMDHPBNAPKI.Clear();
			HOJFGDGNBCF.Clear();
			JHPCPNJJHLI_RankingThreshold.Clear();
			HKKNEAGCIEB_RankingSupport = 0;
			EEOGPJJCKHH_Drops.Clear();
			OMCAOJJGOGG_Lb = "";
			HIOOGLEJBKM_StartAdventureId = 0;
			FJCADCDNPMP_EndAdventureId = 0;
			EJBGHLOOLBC_HelpIds = null;
		}

		//// RVA: 0x16CE8DC Offset: 0x16CE8DC VA: 0x16CE8DC
		//public uint CAOGDCBPBAN() { }
	}

	public class ALBKHBLGHHN
	{
		public int FBGGEFFJJHB_xor; // 0x8
		private int EHOIENNDEDH_IdCrypted; // 0xC
		private int FMDDJNKEBBB_Crypted; // 0x10
		private int MDKGAAMBJDJ_Crypted; // 0x14
		private int GGEBNMPPEID_Crypted; // 0x18

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x16CEFAC DEMEPMAEJOO 0x16CEFBC HIGKAIDMOKN
		public int CNKFPJCGNFE_SceneId { get { return FMDDJNKEBBB_Crypted ^ FBGGEFFJJHB_xor; } set { FMDDJNKEBBB_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x16CEFCC GJBOGOFHGNP 0x16CEFDC GJDGIDCMJMH
		public int GNFBMCGMCFO_BonusBefore { get { return MDKGAAMBJDJ_Crypted ^ FBGGEFFJJHB_xor; } set { MDKGAAMBJDJ_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x16CEFEC NCIMMDJLPLJ 0x16CEFFC HNAJAFBHOLM
		public int BFFGFAMJAIG_BonusAfter { get { return GGEBNMPPEID_Crypted ^ FBGGEFFJJHB_xor; } set { GGEBNMPPEID_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x16CF00C PKMNOMELPMN 0x16CF01C IABBJBAHKCE

		//// RVA: 0x16CEEB8 Offset: 0x16CEEB8 VA: 0x16CEEB8
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x16CE020 Offset: 0x16CE020 VA: 0x16CE020
		public void BAFFAONJPCE(int JBGJDEELLOP, int KNEFBLHBDBG, HMNJADGBKFA JMHECKKKMLK)
		{
			FBGGEFFJJHB_xor = KNEFBLHBDBG;
			PPFNGGCBJKC_id = 0;
			CNKFPJCGNFE_SceneId = 0;
			GNFBMCGMCFO_BonusBefore = 0;
			BFFGFAMJAIG_BonusAfter = 0;
			KPFPLABANJG data = JMHECKKKMLK.OLACFKILCFD[JBGJDEELLOP];
			PPFNGGCBJKC_id = data.PPFNGGCBJKC_id;
			CNKFPJCGNFE_SceneId = data.CNKFPJCGNFE_SceneId;
			GNFBMCGMCFO_BonusBefore = data.GNFBMCGMCFO_BonusBefore;
			BFFGFAMJAIG_BonusAfter = data.BFFGFAMJAIG_BonusAfter;
		}

		//// RVA: 0x16CF02C Offset: 0x16CF02C VA: 0x16CF02C
		//public void LHPDDGIJKNB_Reset(int KNEFBLHBDBG) { }
	}

	public class MAPOMNOALHJ
	{
		public int FBGGEFFJJHB_xor; // 0x8
		private int EHOIENNDEDH_IdCrypted; // 0xC
		private int MDKGAAMBJDJ_Crypted; // 0x10
		private int GGEBNMPPEID_Crypted; // 0x14

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x16CF408 DEMEPMAEJOO 0x16CF418 HIGKAIDMOKN
		public int GNFBMCGMCFO_BonusBefore { get { return MDKGAAMBJDJ_Crypted ^ FBGGEFFJJHB_xor; } set { MDKGAAMBJDJ_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x16CF428 NCIMMDJLPLJ 0x16CF438 HNAJAFBHOLM
		public int BFFGFAMJAIG_BonusAfter { get { return GGEBNMPPEID_Crypted ^ FBGGEFFJJHB_xor; } set { GGEBNMPPEID_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x16CF448 PKMNOMELPMN 0x16CF458 IABBJBAHKCE

		//// RVA: 0x16CEE94 Offset: 0x16CEE94 VA: 0x16CEE94
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x16CE16C Offset: 0x16CE16C VA: 0x16CE16C
		public void BAFFAONJPCE(int JBGJDEELLOP, int KNEFBLHBDBG, HMNJADGBKFA JMHECKKKMLK)
		{
			FBGGEFFJJHB_xor = KNEFBLHBDBG;
			PPFNGGCBJKC_id = 0;
			GNFBMCGMCFO_BonusBefore = 0;
			BFFGFAMJAIG_BonusAfter = 0;
			CNFAHCDJNKD data = JMHECKKKMLK.MIOCOKLMLBD[JBGJDEELLOP];
			PPFNGGCBJKC_id = data.PPFNGGCBJKC_id;
			GNFBMCGMCFO_BonusBefore = data.GNFBMCGMCFO_BonusBefore;
			BFFGFAMJAIG_BonusAfter = data.BFFGFAMJAIG_BonusAfter;
		}

		//// RVA: 0x16CF468 Offset: 0x16CF468 VA: 0x16CF468
		//public void LHPDDGIJKNB_Reset(int KNEFBLHBDBG) { }
	}

	public class ABGNMIEBCDN
	{
		public int FBGGEFFJJHB_xor; // 0x8
		private int HHEEHHHLKHC_Crypted; // 0xC
		private int LGAIHLFAPDC_Crypted; // 0x10
		public List<int> KDNMBOBEGJM_GachaIds = new List<int>(); // 0x14

		public int KHPHAAMGMJP_Id { get { return HHEEHHHLKHC_Crypted ^ FBGGEFFJJHB_xor; } set { HHEEHHHLKHC_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x16CEEE4 ABFDDKBBPCH 0x16CEEF4 MHDOIIEMDEH
		public int OFIAENKCJME_BaseBonus { get { return LGAIHLFAPDC_Crypted ^ FBGGEFFJJHB_xor; } set { LGAIHLFAPDC_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x16CEF04 KADLAKFANGA 0x16CEF14 AIDAPNCEPOB

		//// RVA: 0x16CEDBC Offset: 0x16CEDBC VA: 0x16CEDBC
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x16CE2FC Offset: 0x16CE2FC VA: 0x16CE2FC
		public void BAFFAONJPCE(int JBGJDEELLOP, int KNEFBLHBDBG, HMNJADGBKFA JMHECKKKMLK)
		{
			LHPDDGIJKNB_Reset(KNEFBLHBDBG);
			CFFKBKJMNNN data = JMHECKKKMLK.IEJLJIHIDJC[JBGJDEELLOP];
			KHPHAAMGMJP_Id = data.KHPHAAMGMJP;
			OFIAENKCJME_BaseBonus = data.OFIAENKCJME;
			for(int i = 0; i < data.JMLCLHHLJHM.Length; i++)
			{
				KDNMBOBEGJM_GachaIds.Add(data.JMLCLHHLJHM[i]);
			}
		}

		//// RVA: 0x16CEF24 Offset: 0x16CEF24 VA: 0x16CEF24
		public void LHPDDGIJKNB_Reset(int KNEFBLHBDBG)
		{
			FBGGEFFJJHB_xor = KNEFBLHBDBG;
			KHPHAAMGMJP_Id = 0;
			OFIAENKCJME_BaseBonus = 0;
			KDNMBOBEGJM_GachaIds.Clear();
		}
	}

	public class PFGFDNLGPKP
	{
		public int FBGGEFFJJHB_xor = 0x341e805b; // 0x8
		public int AHGCGHAAHOO_ItemIdCrypted; // 0xC
		public int HLMAFFLCCKD_CountCrypted; // 0x10
		public int JCCHHFPCACO_Crypted; // 0x14
		public bool JOPPFEHKNFO_Pickup; // 0x18
		private int HJAFPEBIBOP_Limit; // 0x1C

		public int GLCLFMGPMAN_ItemId { get { return AHGCGHAAHOO_ItemIdCrypted ^ FBGGEFFJJHB_xor; } set { AHGCGHAAHOO_ItemIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x16CF478 LNJAENEGDEL 0x16CDE3C JHIDBGCHOKL
		public int HMFFHLPNMPH_count { get { return HLMAFFLCCKD_CountCrypted ^ FBGGEFFJJHB_xor; } set { HLMAFFLCCKD_CountCrypted = value ^ FBGGEFFJJHB_xor; } } //0x16CF488 NJOGDDPICKG 0x16CDE4C NBBGMMBICNA
		public int NMKEOMCMIPP_RewardId { get { return JCCHHFPCACO_Crypted ^ FBGGEFFJJHB_xor; } set { JCCHHFPCACO_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x16CF498 EKDBBLNLMBC 0x16CDE5C LJHKEDCGLPO
		public bool PJPDOCNJNGJ_IsLimited { get { return HJAFPEBIBOP_Limit == 117; } set { HJAFPEBIBOP_Limit = value ? 117 : 85; } } //0x16CF4A8 MBEBLALDBHJ 0x16CDE6C ENPODKCLKMC

		//// RVA: 0x16CF060 Offset: 0x16CF060 VA: 0x16CF060
		//public uint CAOGDCBPBAN() { }
	}

	public class GBBANJEDBOP
	{
		public int FBGGEFFJJHB_xor; // 0x8
		public int EHOIENNDEDH_IdCrypted; // 0xC
		public int AADPAJOLEEF_PointCrypted; // 0x10
		public bool JOPPFEHKNFO_Pickup; // 0x14
		public List<PFGFDNLGPKP> AHJNPEAMCCH_rewards = new List<PFGFDNLGPKP>(); // 0x18

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x16CF040 DEMEPMAEJOO 0x16CDE08 HIGKAIDMOKN
		public int DNBFMLBNAEE_point { get { return AADPAJOLEEF_PointCrypted ^ FBGGEFFJJHB_xor; } set { AADPAJOLEEF_PointCrypted = value ^ FBGGEFFJJHB_xor; } } //0x16CF050 JKHIIAEMMDE 0x16CDE18 PFFKLBLEPKB

		// RVA: 0x16CECAC Offset: 0x16CECAC VA: 0x16CECAC
		//public uint CAOGDCBPBAN() { }
	}

	public class LLFNMNJGLNL
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int PLALNIIBLOF_en; // 0xC
		public int MPLGPBNJDJB_FreeMusicId; // 0x10
		public int DKHIHHMOIKM_bns; // 0x14 Bonus
		public long PDBPFJJCADD_open_at; // 0x18
		public long FDBNFFNFOND_close_at; // 0x20

		//// RVA: 0x16CF170 Offset: 0x16CF170 VA: 0x16CF170
		//public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id) { }

		//// RVA: 0x16CF18C Offset: 0x16CF18C VA: 0x16CF18C
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) { }
		//PPFNGGCBJKC_id = id
		//PLALNIIBLOF_en = en
		//MPLGPBNJDJB_FreeMusicId = f_music_id
		//DKHIHHMOIKM_bns = bns
		//PDBPFJJCADD_open_at = open_at
		//FDBNFFNFOND_close_at = close_at

		//// RVA: 0x16CDEA4 Offset: 0x16CDEA4 VA: 0x16CDEA4
		public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, HMNJADGBKFA JMHECKKKMLK)
		{
			PPFNGGCBJKC_id = _PPFNGGCBJKC_id;
			PDBPFJJCADD_open_at = 0;
			FDBNFFNFOND_close_at = 0;
			PLALNIIBLOF_en = 0;
			MPLGPBNJDJB_FreeMusicId = 0;
			DKHIHHMOIKM_bns = 0;
			ENAEMKEKAOE d = JMHECKKKMLK.GHIHAGAOPNC[_PPFNGGCBJKC_id - 1];
			PPFNGGCBJKC_id = (int)d.PPFNGGCBJKC_id;
			PLALNIIBLOF_en = (int)d.PLALNIIBLOF_en;
			MPLGPBNJDJB_FreeMusicId = (int)d.MPLGPBNJDJB_FreeMusicId;
			DKHIHHMOIKM_bns = (int)d.DKHIHHMOIKM_bns;
			PDBPFJJCADD_open_at = d.PDBPFJJCADD_open_at;
			FDBNFFNFOND_close_at = d.FDBNFFNFOND_close_at;
		}

		//// RVA: 0x16CF3CC Offset: 0x16CF3CC VA: 0x16CF3CC
		//public uint CAOGDCBPBAN() { }
	}

	public class OLLFEBCLPIL
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int KFCIJBLDHOK_v1; // 0xC
		public int JLEIHOEGMOP_v2; // 0x10
	}

	public IHCDILMMOJM NGHKJOEDLIP_Settings = new IHCDILMMOJM(); // 0x20
	public List<GBBANJEDBOP> FCIPEDFHFEM_TotalRewards = new List<GBBANJEDBOP>(); // 0x24
	public List<LLFNMNJGLNL> IJJHFGOIDOK_EventMusic = new List<LLFNMNJGLNL>(); // 0x28
	public List<AKIIJBEJOEP> NNMPGOAGEOL_quests = new List<AKIIJBEJOEP>(); // 0x2C
	public List<ALBKHBLGHHN> GEGAEDDGNMA_Bonuses = new List<ALBKHBLGHHN>(); // 0x30
	public List<MAPOMNOALHJ> OGMHMAGDNAM_EpBonusBySceneRarity = new List<MAPOMNOALHJ>(); // 0x34//EpBonusByScene
	public List<ABGNMIEBCDN> LHAKGDAGEMM_EpBonusInfos = new List<ABGNMIEBCDN>(); // 0x38
	private List<NNJFKLBPBNK_SecureString> IFBBNEGGCIH; // 0x44
	private List<CEBFFLDKAEC_SecureInt> JNJAOACIGOC; // 0x48
	public List<OLLFEBCLPIL> ADPFKHEMNBL = new List<OLLFEBCLPIL>(); // 0x4C
	public List<OLLFEBCLPIL> GKCBPNPEJJF = new List<OLLFEBCLPIL>(); // 0x50
	public List<AIGOEAPJGEB> MBHDIJJEOFL = new List<AIGOEAPJGEB>(); // 0x54
	public List<IJNOIMLNBGN> LLCLJBEJOPM_BannerInfo = new List<IJNOIMLNBGN>(); // 0x58

	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI_m_stringParam { get; private set; } // 0x3C IHKPIFIBECO GAMGELHIHHI DDDEJIJGGBJ
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK_m_intParam { get; private set; } // 0x40 KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB

	//// RVA: 0x16CAD94 Offset: 0x16CAD94 VA: 0x16CAD94
	public string EFEGBHACJAL_GetStringParam(string _LJNAKDMILMC_key, string _KKMJBMKHGNH_noval)
	{
		if(FJOEBCMGDMI_m_stringParam.ContainsKey(_LJNAKDMILMC_key))
		{
			return FJOEBCMGDMI_m_stringParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
		}
		return _KKMJBMKHGNH_noval;
	}

	//// RVA: 0x16CAE78 Offset: 0x16CAE78 VA: 0x16CAE78
	public int LPJLEHAJADA_GetIntParam(string _LJNAKDMILMC_key, int _KKMJBMKHGNH_noval)
	{
		if(OHJFBLFELNK_m_intParam.ContainsKey(_LJNAKDMILMC_key))
		{
			return OHJFBLFELNK_m_intParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
		}
		return _KKMJBMKHGNH_noval;
	}

	// RVA: 0x16CAF5C Offset: 0x16CAF5C VA: 0x16CAF5C
	public PHBACNMCMHG_EventCollection()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		OHJFBLFELNK_m_intParam = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		JNJAOACIGOC = new List<CEBFFLDKAEC_SecureInt>();
		FJOEBCMGDMI_m_stringParam = new Dictionary<string, NNJFKLBPBNK_SecureString>();
		IFBBNEGGCIH = new List<NNJFKLBPBNK_SecureString>();
		LMHMIIKCGPE = 30;
	}

	// RVA: 0x16CB480 Offset: 0x16CB480 VA: 0x16CB480 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		NGHKJOEDLIP_Settings.LHPDDGIJKNB_Reset();
		FCIPEDFHFEM_TotalRewards.Clear();
		NNMPGOAGEOL_quests.Clear();
		OHJFBLFELNK_m_intParam.Clear();
		JNJAOACIGOC.Clear();
		FJOEBCMGDMI_m_stringParam.Clear();
		IFBBNEGGCIH.Clear();
		ADPFKHEMNBL.Clear();
		GKCBPNPEJJF.Clear();
		MBHDIJJEOFL.Clear();
		LLCLJBEJOPM_BannerInfo.Clear();
		GEGAEDDGNMA_Bonuses.Clear();
		OGMHMAGDNAM_EpBonusBySceneRarity.Clear();
		LHAKGDAGEMM_EpBonusInfos.Clear();
	}

	// RVA: 0x16CB9A8 Offset: 0x16CB9A8 VA: 0x16CB9A8 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		HMNJADGBKFA data = HMNJADGBKFA.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		DGKKMKLCEDF(data);
		GPEKKMGGBPF(data);
		GJEHPJJBCDE(data);
		CFOFJPLEDEA(data);
		ABICOINNGEK(data);
		EGLHCMDNFOE(data);
		JBNBGGDDEGG(data);
		{
			DPCNINPPGFC[] array = data.BHGDNGHDDAC;
			for(int i = 0; i < array.Length; i++)
			{
				CEBFFLDKAEC_SecureInt d = new CEBFFLDKAEC_SecureInt();
				d.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG_val;
				OHJFBLFELNK_m_intParam.Add(array[i].LJNAKDMILMC_key, d);
				JNJAOACIGOC.Add(d);
			}
		}
		{
			KNLJCIJAAME[] array = data.MHGMDJNOLMI;
			for(int i = 0; i < array.Length; i++)
			{
				NNJFKLBPBNK_SecureString d = new NNJFKLBPBNK_SecureString();
				d.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG_val;
				FJOEBCMGDMI_m_stringParam.Add(array[i].LJNAKDMILMC_key, d);
				IFBBNEGGCIH.Add(d);
			}
		}
		{
			CBFHDJAILAO[] array = data.KIEKMCKCMGD;
			for(int i = 0; i < array.Length; i++)
			{
				OLLFEBCLPIL d = new OLLFEBCLPIL();
				d.PPFNGGCBJKC_id = array[i].PPFNGGCBJKC_id;
				d.KFCIJBLDHOK_v1 = array[i].KFCIJBLDHOK_v1;
				d.JLEIHOEGMOP_v2 = array[i].JLEIHOEGMOP_v2;
				if(i < array.Length / 2)
					ADPFKHEMNBL.Add(d);
				else
					GKCBPNPEJJF.Add(d);
			}
		}
		AIGOEAPJGEB.KHEKNNFCAOI_Init(MBHDIJJEOFL, data);
		IJNOIMLNBGN.KHEKNNFCAOI_Init(JIKKNHIAEKG_BlockName, LLCLJBEJOPM_BannerInfo, data);

		UnityEngine.Debug.LogError(NGHKJOEDLIP_Settings.OPFGFINHFCE_name+" "+NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId);

		// Update dates
		UMOEventList.EventData CurrenEvent = UMOEventList.GetCurrentEvent();
		if (CurrenEvent != null && CurrenEvent.EnableBlock(JIKKNHIAEKG_BlockName))
		{
			System.DateTime date = Utility.GetLocalDateTime(Utility.GetCurrentUnixTime());
			System.DateTime date2 = Utility.GetLocalDateTime(NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart);
			date = date.AddDays(-1);
			long offset = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, date2.Hour, date2.Minute, date2.Second) - NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
			if (NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart != 0) NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart += offset;
			if (NGHKJOEDLIP_Settings.EHHFFKAFOMC != 0) NGHKJOEDLIP_Settings.EHHFFKAFOMC += offset;
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

	// RVA: 0x16CD738 Offset: 0x16CD738 VA: 0x16CD738 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		//NGHKJOEDLIP_Settings = setting
		//FCIPEDFHFEM_TotalRewards = total_rewards
		//IJJHFGOIDOK_EventMusic = event_music
		//NNMPGOAGEOL_quests = quests
		TodoLogger.LogError(TodoLogger.DbJson, "PHBACNMCMHG_EventCollection.IIEMACPEEBJ_Deserialize");
		return true;
	}

	//// RVA: 0x16CBEF4 Offset: 0x16CBEF4 VA: 0x16CBEF4
	private bool DGKKMKLCEDF(HMNJADGBKFA OPHJCBPIPLM)
	{
		NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId = (int)OPHJCBPIPLM.HMBHNLCFDIH.OBGBAOLONDD_UniqueId;
		NGHKJOEDLIP_Settings.OPFGFINHFCE_name = OPHJCBPIPLM.HMBHNLCFDIH.OPFGFINHFCE_name;
		NGHKJOEDLIP_Settings.HEDAGCNPHGD_RankingName = OPHJCBPIPLM.HMBHNLCFDIH.HEDAGCNPHGD_RankingName;
		NGHKJOEDLIP_Settings.IDGAEEJLGIK = OPHJCBPIPLM.HMBHNLCFDIH.IDGAEEJLGIK;
		NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api = OPHJCBPIPLM.HMBHNLCFDIH.OCGFKMHNEOF_name_for_api;
		NGHKJOEDLIP_Settings.OGMGLOFKKPA = OPHJCBPIPLM.HMBHNLCFDIH.OGMGLOFKKPA;
		NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart = OPHJCBPIPLM.HMBHNLCFDIH.BONDDBOFBND_RankingStart;
		NGHKJOEDLIP_Settings.EHHFFKAFOMC = OPHJCBPIPLM.HMBHNLCFDIH.EHHFFKAFOMC;
		NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd = OPHJCBPIPLM.HMBHNLCFDIH.HPNOGLIFJOP_RankingEnd;
		NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2 = OPHJCBPIPLM.HMBHNLCFDIH.LNFKGHNHJKE_RankingEnd2;
		NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart = OPHJCBPIPLM.HMBHNLCFDIH.JGMDAOACOJF_RewardStart;
		NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd = OPHJCBPIPLM.HMBHNLCFDIH.IDDBFFBPNGI_RewardEnd;
		NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 = OPHJCBPIPLM.HMBHNLCFDIH.KNLGKBBIBOH_RewardEnd2;
		NGHKJOEDLIP_Settings.JBFDHOIKAIK_InventoryEndDate = OPHJCBPIPLM.HMBHNLCFDIH.JBFDHOIKAIK_InventoryEndDate;
		NGHKJOEDLIP_Settings.KHIKEGLBGAF_RankingRewardScene = (int)OPHJCBPIPLM.HMBHNLCFDIH.KHIKEGLBGAF_RankingRewardScene;
		NGHKJOEDLIP_Settings.DPJCFLKFEPN = (int)OPHJCBPIPLM.HMBHNLCFDIH.DPJCFLKFEPN;
		NGHKJOEDLIP_Settings.POGEFBMBPCB_MonthOdd = (sbyte)OPHJCBPIPLM.HMBHNLCFDIH.JMJDLDEIFKE;
		NGHKJOEDLIP_Settings.AHKNMANFILO_DayGroup = (sbyte)OPHJCBPIPLM.HMBHNLCFDIH.AHKNMANFILO_DayGroup;
		NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx = (sbyte)OPHJCBPIPLM.HMBHNLCFDIH.MOEKELIIDEO_SaveIdx;
		NGHKJOEDLIP_Settings.OCDMGOGMHGE_RewardPrefix = OPHJCBPIPLM.HMBHNLCFDIH.OCDMGOGMHGE;
		NGHKJOEDLIP_Settings.PJBILOFOCIC = OPHJCBPIPLM.HMBHNLCFDIH.PJBILOFOCIC;
		NGHKJOEDLIP_Settings.MJBKGOJBPAD_item_type = OPHJCBPIPLM.HMBHNLCFDIH.MJBKGOJBPAD_item_type;
		NGHKJOEDLIP_Settings.MPKNCMEAMLO = (sbyte)OPHJCBPIPLM.HMBHNLCFDIH.MPKNCMEAMLO;
		NGHKJOEDLIP_Settings.AHKPNPNOAMO_ExtreamOpen = (sbyte)OPHJCBPIPLM.HMBHNLCFDIH.AHKPNPNOAMO_ExtreamOpen;
		NGHKJOEDLIP_Settings.FEMMDNIELFC_Desc = OPHJCBPIPLM.HMBHNLCFDIH.FEMMDNIELFC_Desc;
		NGHKJOEDLIP_Settings.HKKNEAGCIEB_RankingSupport = (sbyte)OPHJCBPIPLM.HMBHNLCFDIH.HKKNEAGCIEB_RankingSupport;
		NGHKJOEDLIP_Settings.HIOOGLEJBKM_StartAdventureId = OPHJCBPIPLM.HMBHNLCFDIH.HIOOGLEJBKM_StartAdventureId;
		NGHKJOEDLIP_Settings.FJCADCDNPMP_EndAdventureId = OPHJCBPIPLM.HMBHNLCFDIH.FJCADCDNPMP_EndAdventureId;
		NGHKJOEDLIP_Settings.EJBGHLOOLBC_HelpIds = OPHJCBPIPLM.HMBHNLCFDIH.EJBGHLOOLBC_HelpIds;
		NGHKJOEDLIP_Settings.EKJFNHHKBPL = OPHJCBPIPLM.HMBHNLCFDIH.EKJFNHHKBPL;
		NGHKJOEDLIP_Settings.OMCAOJJGOGG_Lb = OPHJCBPIPLM.HMBHNLCFDIH.OMCAOJJGOGG_Lb;
		EEEKPHDPJHG(NGHKJOEDLIP_Settings.CAPAPAABKDP_FreeMusic, OPHJCBPIPLM.HMBHNLCFDIH.KOHMHBGOFFI_free_music);
		EEEKPHDPJHG(NGHKJOEDLIP_Settings.HKEAFPNNAPC, OPHJCBPIPLM.HMBHNLCFDIH.HKEAFPNNAPC);
		EEEKPHDPJHG(NGHKJOEDLIP_Settings.MCDPPHKEMJI, OPHJCBPIPLM.HMBHNLCFDIH.MCDPPHKEMJI);
		EEEKPHDPJHG(NGHKJOEDLIP_Settings.BJHHDGCOACI, OPHJCBPIPLM.HMBHNLCFDIH.BJHHDGCOACI);
		EEEKPHDPJHG(NGHKJOEDLIP_Settings.JDDIOIMOFDE, OPHJCBPIPLM.HMBHNLCFDIH.JDDIOIMOFDE);
		{
			uint[] array = OPHJCBPIPLM.HMBHNLCFDIH.DMDHPBNAPKI;
			for(int i = 0; i < array.Length; i++)
			{
				if(i < array.Length / 2)
					NGHKJOEDLIP_Settings.LLMCLICMLLG((int)array[i]);
				else
					NGHKJOEDLIP_Settings.DJBHHJEJPFK((int)array[i]);
			}
		}
		for(int i = 0; i < OPHJCBPIPLM.HMBHNLCFDIH.JHPCPNJJHLI_RankingThreshold.Length; i++)
		{
			if(OPHJCBPIPLM.HMBHNLCFDIH.JHPCPNJJHLI_RankingThreshold[i] < 1001)
			{
				NGHKJOEDLIP_Settings.JHPCPNJJHLI_RankingThreshold.Add(OPHJCBPIPLM.HMBHNLCFDIH.JHPCPNJJHLI_RankingThreshold[i]);
			}
		}
		NGHKJOEDLIP_Settings.EEOGPJJCKHH_Drops.Clear();
		for(int i = 0; i < OPHJCBPIPLM.HMBHNLCFDIH.EEOGPJJCKHH_Drops.Length; i++)
		{
			NGHKJOEDLIP_Settings.EEOGPJJCKHH_Drops.Add((int)OPHJCBPIPLM.HMBHNLCFDIH.EEOGPJJCKHH_Drops[i]);
		}
		return true;
	}

	//// RVA: 0x16CD878 Offset: 0x16CD878 VA: 0x16CD878
	//private bool DGKKMKLCEDF(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x16CDB9C Offset: 0x16CDB9C VA: 0x16CDB9C
	//private void EEEKPHDPJHG(List<int> NNDGIAEFMOG, EDOHBJAPLPF_JsonData OBHAFLMHAKG, string _OPFGFINHFCE_name, ref bool _NGJDHLGMHMH_IsInvalid) { }

	//// RVA: 0x16CD900 Offset: 0x16CD900 VA: 0x16CD900
	private void EEEKPHDPJHG(List<int> NNDGIAEFMOG, string OAIBJJHGCNM)
	{
		string[] strs = OAIBJJHGCNM.Split(new char[] {','});
		NNDGIAEFMOG.Clear();
		for(int i = 0; i < strs.Length; i++)
		{
			if(!string.IsNullOrEmpty(strs[i]))
			{
				NNDGIAEFMOG.Add(int.Parse(strs[i]));
			}
		}
	}

	//// RVA: 0x16CCB3C Offset: 0x16CCB3C VA: 0x16CCB3C
	private bool GPEKKMGGBPF(HMNJADGBKFA OPHJCBPIPLM)
	{
		MCFPAFGFPJC[] array = OPHJCBPIPLM.MCHFABAKPMH;
		for(int i = 0; i < array.Length; i++)
		{
			GBBANJEDBOP d = new GBBANJEDBOP();
			d.FBGGEFFJJHB_xor = 0xa38887a;
			d.PPFNGGCBJKC_id = (int)array[i].PPFNGGCBJKC_id;
			d.DNBFMLBNAEE_point = (int)array[i].FOILNHKHHDF_pt;
			d.JOPPFEHKNFO_Pickup = array[i].JOPPFEHKNFO_Pickup != 0;
			for(int j = 0; j < array[i].AIHOJKFNEEN_itm.Length; j++)
			{
				PFGFDNLGPKP d2 = new PFGFDNLGPKP();
				d2.FBGGEFFJJHB_xor = 0x341e805b;
				d2.GLCLFMGPMAN_ItemId = array[i].AIHOJKFNEEN_itm[j];
				d2.HMFFHLPNMPH_count = (int)array[i].BFINGCJHOHI_cnt[j];
				d2.NMKEOMCMIPP_RewardId = (int)array[i].JJHPDDPKBHF[j];
				d2.PJPDOCNJNGJ_IsLimited = array[i].HJAFPEBIBOP_Limit[j] != 0;
				d.AHJNPEAMCCH_rewards.Add(d2);
			}
			FCIPEDFHFEM_TotalRewards.Add(d);
		}
		return true;
	}

	//// RVA: 0x16CD880 Offset: 0x16CD880 VA: 0x16CD880
	//private bool GPEKKMGGBPF(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x16CD00C Offset: 0x16CD00C VA: 0x16CD00C
	private bool GJEHPJJBCDE(HMNJADGBKFA OPHJCBPIPLM)
	{
		ENAEMKEKAOE[] array = OPHJCBPIPLM.GHIHAGAOPNC;
		for(int i = 0; i < array.Length; i++)
		{
			LLFNMNJGLNL d = new LLFNMNJGLNL();
			d.KHEKNNFCAOI_Init(i + 1, OPHJCBPIPLM);
			IJJHFGOIDOK_EventMusic.Add(d);
		}
		return true;
	}

	//// RVA: 0x16CD888 Offset: 0x16CD888 VA: 0x16CD888
	//private bool GJEHPJJBCDE(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x16CD128 Offset: 0x16CD128 VA: 0x16CD128
	private bool CFOFJPLEDEA(HMNJADGBKFA OPHJCBPIPLM)
	{
		OFFLOKADBGI[] array = OPHJCBPIPLM.MDDOGIAFDEI;
		int xor = (int)Utility.GetCurrentUnixTime() * 0xb + 1;
		for(int i = 0; i < array.Length; i++)
		{
			AKIIJBEJOEP d = new AKIIJBEJOEP();
			d.KHEKNNFCAOI_Init(JIKKNHIAEKG_BlockName, i + 1, xor, OPHJCBPIPLM);
			NNMPGOAGEOL_quests.Add(d);
			xor += 0xd;
		}
		return true;
	}

	//// RVA: 0x16CD890 Offset: 0x16CD890 VA: 0x16CD890
	//private bool CFOFJPLEDEA(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x16CD5B4 Offset: 0x16CD5B4 VA: 0x16CD5B4
	private bool JBNBGGDDEGG(HMNJADGBKFA JMHECKKKMLK)
	{
		KPFPLABANJG[] array = JMHECKKKMLK.OLACFKILCFD;
		int xor = (int)Utility.GetCurrentUnixTime() * 0xb + 1;
		for(int i = 0; i < array.Length; i++)
		{
			ALBKHBLGHHN d = new ALBKHBLGHHN();
			d.BAFFAONJPCE(i, xor, JMHECKKKMLK);
			GEGAEDDGNMA_Bonuses.Add(d);
			xor = xor * 3 + 0xd;
		}
		return true;
	}

	//// RVA: 0x16CD2C0 Offset: 0x16CD2C0 VA: 0x16CD2C0
	private bool ABICOINNGEK(HMNJADGBKFA JMHECKKKMLK)
	{
		CNFAHCDJNKD[] array = JMHECKKKMLK.MIOCOKLMLBD;
		int xor = (int)Utility.GetCurrentUnixTime() * 0xb + 1;
		for(int i = 0; i < array.Length; i++)
		{
			MAPOMNOALHJ d = new MAPOMNOALHJ();
			d.BAFFAONJPCE(i, xor, JMHECKKKMLK);
			OGMHMAGDNAM_EpBonusBySceneRarity.Add(d);
			xor = xor * 3 + 0xd;
		}
		return true;
	}

	//// RVA: 0x16CD43C Offset: 0x16CD43C VA: 0x16CD43C
	private bool EGLHCMDNFOE(HMNJADGBKFA JMHECKKKMLK)
	{
		CFFKBKJMNNN[] array = JMHECKKKMLK.IEJLJIHIDJC;
		int xor = (int)Utility.GetCurrentUnixTime() * 0xb + 1;
		for(int i = 0; i < array.Length; i++)
		{
			ABGNMIEBCDN d = new ABGNMIEBCDN();
			d.BAFFAONJPCE(i, xor, JMHECKKKMLK);
			LHAKGDAGEMM_EpBonusInfos.Add(d);
			xor = xor * 3 + 0xd;
		}
		return true;
	}

	// RVA: 0x16CE4D0 Offset: 0x16CE4D0 VA: 0x16CE4D0 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "PHBACNMCMHG_EventCollection.CAOGDCBPBAN");
		return 0;
	}
}
