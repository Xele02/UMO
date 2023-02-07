using UnityEngine;
using System.Collections.Generic;
using System;
using System.Text;

[System.Obsolete("Use OKGLGHCBCJP_Database", true)]
public class OKGLGHCBCJP{}
public class OKGLGHCBCJP_Database
{
	public enum BEOKNKGHFFE_Section
	{
		LIIJEGOIKDP_Adventure = 0,
		MLNHHIIDJAO_Anketo = 1,
		PICOGHJNOJA_Asset = 2,
		DBBOBIHPDNA_Bingo = 3,
		PEIFIFLMIIF_Board = 4,
		JOMAMMACANH_BonusVC = 5,
		DHMPHBPODCI_CampaignDiva = 6,
		DGPIFKCLAGB_Compo = 7,
		EFHFNMAIEJG_CosItem = 8,
		LOFOAIEMECN_Costume = 9,
		LHFCAMJHMLB_DecoItem = 10,
		BGMIHMDPDCM_DecoItemInit = 11,
		DBILOJAEIOO_DecoPoint = 12,
		DLFGIKANBDK_DecoSetItem = 13,
		PLJHAFGEGEB_DecoSpSetting = 14,
		DHMEFNNJANH_DecoStamp = 15,
		CNENKCCMEFL_Diva = 16,
		ACGFJFNPLKB_Diva2 = 17,
		PKDKLHJLEFA_Drop = 18,
		PGHFPIMIOKE_Emblem = 19,
		CNGPLGIMJBB_Enemy = 20,
		JBFFIPCOGEC_EnergyItem = 21,
		BBDKHAMANCB_Episode = 22,
		MIOOJINHHFO_EpiItem = 23,
		OBEAIJOHOAJ_EventAprilFoolA = 24,
		GCEPOPPDPOC_EventAprilFoolB = 25,
		EMOOIGBGHLG_EventAprilFoolC = 26,
		AEGNEIOAOKI_EventAprilFoolD = 27,
		KNNGKODFAGC_EventAprilFoolE = 28,
		AFGGHHOHILP_EventAprilFoolF = 29,
		EICBLKBKMKE_EventAprilFoolG = 30,
		FIKPHDFLIIM_EventAprilFoolH = 31,
		FNLCLINDJAF_EventAprilFoolI = 32,
		IEICONEHLFE_EventBattleA = 33,
		CJLAEPKNNJE_EventBattleB = 34,
		MPCNKNCKBAE_EventBattleC = 35,
		COFHBPGDPML_EventBoxGachaA = 36,
		BHJGBPLKMBK_EventBoxGachaB = 37,
		AHDKIFOPEHM_EventBoxGachaC = 38,
		LLEDCLGDDCD_EventBoxGachaD = 39,
		ACNPHHGCHAF_EventBoxGachaE = 40,
		FEICGBHOIPB_EventBoxGachaF = 41,
		OAOKLHCDPON_EventCollectionA = 42,
		GGKFEJFMNGP_EventCollectionB = 43,
		LLHBBEMKIGD_EventCollectionC = 44,
		HJDJGMNAJFJ_EventGachaTicket = 45,
		MBMNNEODFFP_EventGoDivaA = 46,
		NLIBPDOHAPH_EventGoDivaB = 47,
		JLGODHLEBMK_EventGoDivaC = 48,
		OFAAHIINGFD_EventGoDivaRanking = 49,
		OFGFNFAJHFE_EventItem = 50,
		DCBIDPBJHOC_EventMissionA = 51,
		BNCLLKEHEFH_EventMissionB = 52,
		BDGKKLAAJJB_EventMissionC = 53,
		CLKOFJKPPEP_EventPresentCampaignA = 54,
		DCEHHGDDBPP_EventRaidA = 55,
		PLNOKLOLJEP_EventRaidB = 56,
		IJEIEHHAJNM_EventRaidC = 57,
		DMKFEJGOELJ_EventRaidD = 58,
		IEBPINPALBD_EventRaidLobbyA = 59,
		CHNHFHCEKGN_EventRaidLobbyB = 60,
		FCAJCEOCDFF_EventRaidLobbyC = 61,
		IJOLIEAOOJC_EventRaidLobbyD = 62,
		MDAEJLJPIHN_EventRaidItem = 63,
		OJAHCPGNPDB_EventQuestA = 64,
		KGJMEGLKJDM_EventQuestB = 65,
		LNBMDELKFHI_EventQuestC = 66,
		FMHLCBNFAOC_EventScoreA = 67,
		LCJACACCKFC_EventScoreB = 68,
		BPOFGIDPMBF_EventScoreC = 69,
		JPNKKKOHHLG_EventScoreD = 70,
		ECHHEGJOHGI_EventScoreE = 71,
		NLDGAHCIPAE_EventScoreF = 72,
		MHGPKDOPEDJ_EventSpA = 73,
		AMGKNGLDHMG_EventTicket = 74,
		BKEKCFONNBG_EventWeekDay = 75,
		JLNNFLCLGBM_EventStory = 76,
		MHNJLGONIPK_Exp = 77,
		FPFHPCDNIDN_GachaLimit = 78,
		OJFINMGAFPG_GachaTicket = 79,
		HJBCLCJIAMN_Game = 80,
		JOMKJEEEGLM_GrowItem = 81,
		MGLIHABHABA_HelpBrowser = 82,
		JHIAPFBBCCJ_HomeBg = 83,
		FLANCIJMJHP_HomePickup = 84,
		BKGFKGIGJNL_HomeVoice = 85,
		NLIJGKHKMII_RichBanner = 86,
		CLAMLDCILJO_Intimacy = 87,
		FONDIJMKCAJ_LimitOver = 88,
		KPBNAHEIJIC_LimitedItem = 89,
		ECEDGCHFCEF_Medal = 90,
		HOBIIBFBMKJ_MonthlyPass = 91,
		CHOGKKCHBCJ_Music = 92,
		JMJMNDKFOIF_MvTicket = 93,
		LNCIOFKDBHD_Offer = 94,
		GPEFCGBGIHD_Pilot = 95,
		JFDOPKICHPJ_PresentItem = 96,
		HDJDAENLIBF_Quest = 97,
		KOALKJHIHFC_RareUpItem = 98,
		KNMIJOPCJCH_Scene = 99,
		ELBGPMIFOHO_Shop = 100,
		ABANJLALLBK_Skill = 101,
		HGOGFPOCKFA_Sns = 102,
		LCEEHPPLHNC_SpItem = 103,
		AOPBBHMIEPB_Story = 104,
		HGFDKEMHGHK_System = 105,
		ACECCMLEDMO_Tips = 106,
		HDDBEGLGIDK_TitleBanner = 107,
		EMHPGEHBKPG_TutorialMiniAdv = 108,
		JJMBJBFKJHK_TutorialPict = 109,
		EKLPMPHCIDL_UcItem = 110,
		OPHNLHMINEO_ValItem = 111,
		NPLKLHDPLEO_ValSkill = 112,
		EEPIDKPPLJI_Valkyrie = 113,
		LJKEOODGGJF_VcItem = 114,
		NPOPGPFPLOL_HighscoreRating = 115,
		AHKEJPLNAJK_LimitedCompoItem = 116,
		CGKOFIKBMMI = 117,

	}

	public delegate DIHHCBACKGG_DbSection BIFFPAKDHJJ_CreateSectionDelegate();

	public static BEOKNKGHFFE_Section[] GAAEFILMAED_BaseSectionList = new BEOKNKGHFFE_Section[0x47]
	{
		BEOKNKGHFFE_Section.LIIJEGOIKDP_Adventure,
		BEOKNKGHFFE_Section.MLNHHIIDJAO_Anketo,
		BEOKNKGHFFE_Section.PICOGHJNOJA_Asset,
		BEOKNKGHFFE_Section.DBBOBIHPDNA_Bingo,
		BEOKNKGHFFE_Section.PEIFIFLMIIF_Board,
		BEOKNKGHFFE_Section.JOMAMMACANH_BonusVC,
		BEOKNKGHFFE_Section.DHMPHBPODCI_CampaignDiva,
		BEOKNKGHFFE_Section.DGPIFKCLAGB_Compo,
		BEOKNKGHFFE_Section.EFHFNMAIEJG_CosItem,
		BEOKNKGHFFE_Section.LOFOAIEMECN_Costume,
		BEOKNKGHFFE_Section.LHFCAMJHMLB_DecoItem,
		BEOKNKGHFFE_Section.BGMIHMDPDCM_DecoItemInit,
		BEOKNKGHFFE_Section.DBILOJAEIOO_DecoPoint,
		BEOKNKGHFFE_Section.DLFGIKANBDK_DecoSetItem,
		BEOKNKGHFFE_Section.PLJHAFGEGEB_DecoSpSetting,
		BEOKNKGHFFE_Section.DHMEFNNJANH_DecoStamp,
		BEOKNKGHFFE_Section.CNENKCCMEFL_Diva,
		BEOKNKGHFFE_Section.ACGFJFNPLKB_Diva2,
		BEOKNKGHFFE_Section.PKDKLHJLEFA_Drop,
		BEOKNKGHFFE_Section.PGHFPIMIOKE_Emblem,
		BEOKNKGHFFE_Section.CNGPLGIMJBB_Enemy,
		BEOKNKGHFFE_Section.JBFFIPCOGEC_EnergyItem,
		BEOKNKGHFFE_Section.BBDKHAMANCB_Episode,
		BEOKNKGHFFE_Section.MIOOJINHHFO_EpiItem,
		BEOKNKGHFFE_Section.HJDJGMNAJFJ_EventGachaTicket,
		BEOKNKGHFFE_Section.OFAAHIINGFD_EventGoDivaRanking,
		BEOKNKGHFFE_Section.OFGFNFAJHFE_EventItem,
		BEOKNKGHFFE_Section.MDAEJLJPIHN_EventRaidItem,
		BEOKNKGHFFE_Section.AMGKNGLDHMG_EventTicket,
		BEOKNKGHFFE_Section.BKEKCFONNBG_EventWeekDay,
		BEOKNKGHFFE_Section.JLNNFLCLGBM_EventStory,
		BEOKNKGHFFE_Section.MHNJLGONIPK_Exp,
		BEOKNKGHFFE_Section.FPFHPCDNIDN_GachaLimit,
		BEOKNKGHFFE_Section.OJFINMGAFPG_GachaTicket,
		BEOKNKGHFFE_Section.HJBCLCJIAMN_Game,
		BEOKNKGHFFE_Section.JOMKJEEEGLM_GrowItem,
		BEOKNKGHFFE_Section.MGLIHABHABA_HelpBrowser,
		BEOKNKGHFFE_Section.JHIAPFBBCCJ_HomeBg,
		BEOKNKGHFFE_Section.FLANCIJMJHP_HomePickup,
		BEOKNKGHFFE_Section.BKGFKGIGJNL_HomeVoice,
		BEOKNKGHFFE_Section.NLIJGKHKMII_RichBanner,
		BEOKNKGHFFE_Section.CLAMLDCILJO_Intimacy,
		BEOKNKGHFFE_Section.FONDIJMKCAJ_LimitOver,
		BEOKNKGHFFE_Section.KPBNAHEIJIC_LimitedItem,
		BEOKNKGHFFE_Section.ECEDGCHFCEF_Medal,
		BEOKNKGHFFE_Section.HOBIIBFBMKJ_MonthlyPass,
		BEOKNKGHFFE_Section.CHOGKKCHBCJ_Music,
		BEOKNKGHFFE_Section.JMJMNDKFOIF_MvTicket,
		BEOKNKGHFFE_Section.LNCIOFKDBHD_Offer,
		BEOKNKGHFFE_Section.GPEFCGBGIHD_Pilot,
		BEOKNKGHFFE_Section.JFDOPKICHPJ_PresentItem,
		BEOKNKGHFFE_Section.HDJDAENLIBF_Quest,
		BEOKNKGHFFE_Section.KOALKJHIHFC_RareUpItem,
		BEOKNKGHFFE_Section.KNMIJOPCJCH_Scene,
		BEOKNKGHFFE_Section.ELBGPMIFOHO_Shop,
		BEOKNKGHFFE_Section.ABANJLALLBK_Skill,
		BEOKNKGHFFE_Section.HGOGFPOCKFA_Sns,
		BEOKNKGHFFE_Section.LCEEHPPLHNC_SpItem,
		BEOKNKGHFFE_Section.AOPBBHMIEPB_Story,
		BEOKNKGHFFE_Section.HGFDKEMHGHK_System,
		BEOKNKGHFFE_Section.ACECCMLEDMO_Tips,
		BEOKNKGHFFE_Section.HDDBEGLGIDK_TitleBanner,
		BEOKNKGHFFE_Section.EMHPGEHBKPG_TutorialMiniAdv,
		BEOKNKGHFFE_Section.JJMBJBFKJHK_TutorialPict,
		BEOKNKGHFFE_Section.EKLPMPHCIDL_UcItem,
		BEOKNKGHFFE_Section.OPHNLHMINEO_ValItem,
		BEOKNKGHFFE_Section.NPLKLHDPLEO_ValSkill,
		BEOKNKGHFFE_Section.EEPIDKPPLJI_Valkyrie,
		BEOKNKGHFFE_Section.LJKEOODGGJF_VcItem,
		BEOKNKGHFFE_Section.NPOPGPFPLOL_HighscoreRating,
		BEOKNKGHFFE_Section.AHKEJPLNAJK_LimitedCompoItem
	}; // 0x0
	public static readonly string[] IJBLEJOKEFH_SectionNames = new string[0x75] {
  		"adventure",
		"anketo",
		"asset",
		"bingo",
		"board",
		"bonus_vc",
		"campaign_diva",
		"compo",
		"cos_item",
		"costume",
		"deco_item",
		"deco_item_init",
		"deco_point",
		"deco_set_item",
		"deco_sp_setting",
		"deco_stamp",
		"diva",
		"diva2",
		"drop",
		"emblem",
		"enemy",
		"energy_item",
		"episode",
		"epi_item",
		"event_april_fool_a",
		"event_april_fool_b",
		"event_april_fool_c",
		"event_april_fool_d",
		"event_april_fool_e",
		"event_april_fool_f",
		"event_april_fool_g",
		"event_april_fool_h",
		"event_april_fool_i",
		"event_battle_a",
		"event_battle_b",
		"event_battle_c",
		"event_box_gacha_a",
		"event_box_gacha_b",
		"event_box_gacha_c",
		"event_box_gacha_d",
		"event_box_gacha_e",
		"event_box_gacha_f",
		"event_collection_a",
		"event_collection_b",
		"event_collection_c",
		"event_gacha_ticket",
		"event_godiva_a",
		"event_godiva_b",
		"event_godiva_c",
		"event_godiva_ranking",
		"event_item",
		"event_mission_a",
		"event_mission_b",
		"event_mission_c",
		"event_present_campaign_a",
		"event_raid_a",
		"event_raid_b",
		"event_raid_c",
		"event_raid_d",
		"event_raidlobby_a",
		"event_raidlobby_b",
		"event_raidlobby_c",
		"event_raidlobby_d",
		"event_raid_item",
		"event_quest_a",
		"event_quest_b",
		"event_quest_c",
		"event_score_a",
		"event_score_b",
		"event_score_c",
		"event_score_d",
		"event_score_e",
		"event_score_f",
		"event_sp_a",
		"event_ticket",
		"event_weekday",
		"event_story",
		"exp",
		"gacha_limit",
		"gacha_ticket",
		"game",
		"grow_item",
		"help_browser",
		"home_bg",
		"home_pickup",
		"home_voice",
		"rich_banner",
		"intimacy",
		"limit_over",
		"limited_item",
		"medal",
		"monthly_pass",
		"music",
		"mv_ticket",
		"offer",
		"pilot",
		"present_item",
		"quest",
		"rareup_item",
		"scene",
		"shop",
		"skill",
		"sns",
		"sp_item",
		"story",
		"system",
		"tips",
		"title_banner",
		"tutorial_mini_adv",
		"tutorial_pict",
		"uc_item",
		"val_item",
		"val_skill",
		"valkyrie",
		"vc_item",
		"highscore_rating",
		"limited_compo_item"}; // 0x4
	public List<BEOKNKGHFFE_Section> NDLAAACJOLP = new List<BEOKNKGHFFE_Section>(); // 0x8
	public string[] IIILDINMAKI_SectionNames = new string[117]; // 0xC
	public long[] GJFPFFBAKGK_SectionCloseTime = new long[117]; // 0x10

	private List<DIHHCBACKGG_DbSection> MGJKEJHEBPO_SectionList; // 0x130
	private static Dictionary<int, BIFFPAKDHJJ_CreateSectionDelegate> BGEJFKHOMOC_CreateFuncs = new Dictionary<int, BIFFPAKDHJJ_CreateSectionDelegate>() {
		{(int)BEOKNKGHFFE_Section.LIIJEGOIKDP_Adventure,() => { return new GPMHOAKFALE_Adventure(); } }, // 0x149D500				"adventure",
		{(int)BEOKNKGHFFE_Section.MLNHHIIDJAO_Anketo,() => { return new IPJBAPLFECP_Anketo(); } }, //0x149D56C				"anketo",
		 {(int)BEOKNKGHFFE_Section.PICOGHJNOJA_Asset,() => { return new LFPJCEMANCK_Asset(); } }, //0x149D5D8				"asset",
		{(int)BEOKNKGHFFE_Section.DBBOBIHPDNA_Bingo,() => { return new JKICPBIIHNE_Bingo(); } }, //0x149D644				"bingo",
		{(int)BEOKNKGHFFE_Section.PEIFIFLMIIF_Board,() => { return new KOGHKIODHPA_Board(); } }, //0x149D6B0					"board",
		{(int)BEOKNKGHFFE_Section.JOMAMMACANH_BonusVC,() => { return new HHJHIFJIKAC_BonusVc(); } }, //0x149D71C				"bonus_vc",
		{(int)BEOKNKGHFFE_Section.DHMPHBPODCI_CampaignDiva,() => { return new AIPOFGJGPKI_CampaignDiva(); } }, //0x149D788				"campaign_diva",
		{(int)BEOKNKGHFFE_Section.DGPIFKCLAGB_Compo,() => { return new HHPEMHHCKBE_Compo(); } }, //0x149D7F4				"compo",
		{(int)BEOKNKGHFFE_Section.EFHFNMAIEJG_CosItem,() => { return new PLPBJOFICEJ_CosItem(); } }, //0x149D860				"cos_item",
		{(int)BEOKNKGHFFE_Section.LOFOAIEMECN_Costume,() => { return new LCLCCHLDNHJ_Costume(); } }, //0x149D8CC					"costume",
		{(int)BEOKNKGHFFE_Section.LHFCAMJHMLB_DecoItem,() => { return new NDBFKHKMMCE_DecoItem(); } }, //0x149D938					"deco_item",
		{(int)BEOKNKGHFFE_Section.BGMIHMDPDCM_DecoItemInit,() => { return new JEPMHCPBIGD_DecoItemInit(); } }, //0x149D9A4				"deco_item_init",
		{(int)BEOKNKGHFFE_Section.DBILOJAEIOO_DecoPoint,() => { return new GAEBMAEDNAN_DecoPoint(); } }, //0x149DA10				"deco_point",
		{(int)BEOKNKGHFFE_Section.DLFGIKANBDK_DecoSetItem,() => { return new BBLECJKKKLA_DecoSetItem(); } }, //0x149DA7C					"deco_set_item",
		{(int)BEOKNKGHFFE_Section.PLJHAFGEGEB_DecoSpSetting,() => { return new NEGELNMPEPH_DecoSpSetting(); } }, //0x149DAE8				"deco_sp_setting",
		{(int)BEOKNKGHFFE_Section.DHMEFNNJANH_DecoStamp,() => { return new IHFIAFDLAAK_DecoStamp(); } }, //0x149DB54				"deco_stamp",
		{(int)BEOKNKGHFFE_Section.CNENKCCMEFL_Diva,() => { return new HPBPIOPPDCB_Diva(); } }, //0x149DBC0				"diva",
		{(int)BEOKNKGHFFE_Section.ACGFJFNPLKB_Diva2,() => { return new HMIJOOPHJLB_Diva2(); } }, //0x149DC2C				"diva2",
		{(int)BEOKNKGHFFE_Section.PKDKLHJLEFA_Drop,() => { return new NBPHJDCOECH_Drop(); } }, //0x149DC98				"drop",
		{(int)BEOKNKGHFFE_Section.PGHFPIMIOKE_Emblem,() => { return new IHGBPAJMJFK_Emblem(); } }, //0x149DD04				"emblem",
		{(int)BEOKNKGHFFE_Section.CNGPLGIMJBB_Enemy,() => { return new MHDFCLCMDKO_Enemy(); } }, //0x149DD70				"enemy",
		{(int)BEOKNKGHFFE_Section.JBFFIPCOGEC_EnergyItem,() => { return new JKDKODAPGBJ_EnergyItem(); } }, //0x149DDDC				"energy_item",
		{(int)BEOKNKGHFFE_Section.BBDKHAMANCB_Episode,() => { return new KMOGDEOKHPG_Episode(); } }, //0x149DE48				"episode",
		{(int)BEOKNKGHFFE_Section.MIOOJINHHFO_EpiItem,() => { return new KIICLPJJBNL_EpiItem(); } }, //0x149DEB4				"epi_item",
		{(int)BEOKNKGHFFE_Section.OBEAIJOHOAJ_EventAprilFoolA,() => { return new KCGOMAFPGDD_EventAprilFool(); } }, //0x149DF20				"event_april_fool_a",
		{(int)BEOKNKGHFFE_Section.GCEPOPPDPOC_EventAprilFoolB,() => { return new KCGOMAFPGDD_EventAprilFool(); } }, //0x149DF8C				"event_april_fool_b",
		{(int)BEOKNKGHFFE_Section.EMOOIGBGHLG_EventAprilFoolC,() => { return new KCGOMAFPGDD_EventAprilFool(); } }, //0x149DFF8				"event_april_fool_c",
		{(int)BEOKNKGHFFE_Section.AEGNEIOAOKI_EventAprilFoolD,() => { return new KCGOMAFPGDD_EventAprilFool(); } }, //0x149E064				"event_april_fool_d",
		{(int)BEOKNKGHFFE_Section.KNNGKODFAGC_EventAprilFoolE,() => { return new KCGOMAFPGDD_EventAprilFool(); } }, //0x149E0D0				"event_april_fool_e",
		{(int)BEOKNKGHFFE_Section.AFGGHHOHILP_EventAprilFoolF,() => { return new KCGOMAFPGDD_EventAprilFool(); } }, //0x149E13C				"event_april_fool_f",
		{(int)BEOKNKGHFFE_Section.EICBLKBKMKE_EventAprilFoolG,() => { return new KCGOMAFPGDD_EventAprilFool(); } }, //0x149E1A8				"event_april_fool_g",
		{(int)BEOKNKGHFFE_Section.FIKPHDFLIIM_EventAprilFoolH,() => { return new KCGOMAFPGDD_EventAprilFool(); } }, //0x149E214				"event_april_fool_h",
		{(int)BEOKNKGHFFE_Section.FNLCLINDJAF_EventAprilFoolI,() => { return new KCGOMAFPGDD_EventAprilFool(); } }, //0x149E280				"event_april_fool_i",
		{(int)BEOKNKGHFFE_Section.IEICONEHLFE_EventBattleA,() => { return new ICFLJACCIKF_EventBattle(); } }, //0x149E2EC				"event_battle_a",
		{(int)BEOKNKGHFFE_Section.CJLAEPKNNJE_EventBattleB,() => { return new ICFLJACCIKF_EventBattle(); } }, //0x149E358				"event_battle_b",
		{(int)BEOKNKGHFFE_Section.MPCNKNCKBAE_EventBattleC,() => { return new ICFLJACCIKF_EventBattle(); } }, //0x149E3C4				"event_battle_c",
		{(int)BEOKNKGHFFE_Section.COFHBPGDPML_EventBoxGachaA,() => { return new IMDBGDNPLJA(); } }, //0x149E430				"event_box_gacha_a",
		{(int)BEOKNKGHFFE_Section.BHJGBPLKMBK_EventBoxGachaB,() => { return new IMDBGDNPLJA(); } }, //0x149E49C				"event_box_gacha_b",
		{(int)BEOKNKGHFFE_Section.AHDKIFOPEHM_EventBoxGachaC,() => { return new IMDBGDNPLJA(); } }, //0x149E508				"event_box_gacha_c",
		{(int)BEOKNKGHFFE_Section.LLEDCLGDDCD_EventBoxGachaD,() => { return new IMDBGDNPLJA(); } }, //0x149E574				"event_box_gacha_d",
		{(int)BEOKNKGHFFE_Section.ACNPHHGCHAF_EventBoxGachaE,() => { return new IMDBGDNPLJA(); } }, //0x149E5E0				"event_box_gacha_e",
		{(int)BEOKNKGHFFE_Section.FEICGBHOIPB_EventBoxGachaF,() => { return new IMDBGDNPLJA(); } }, //0x149E64C				"event_box_gacha_f",
		{(int)BEOKNKGHFFE_Section.OAOKLHCDPON_EventCollectionA,() => { return new PHBACNMCMHG(); } }, //0x149E6B8				"event_collection_a",
		{(int)BEOKNKGHFFE_Section.GGKFEJFMNGP_EventCollectionB,() => { return new PHBACNMCMHG(); } }, //0x149E724				"event_collection_b",
		{(int)BEOKNKGHFFE_Section.LLHBBEMKIGD_EventCollectionC,() => { return new PHBACNMCMHG(); } }, //0x149E790				"event_collection_c",
		{(int)BEOKNKGHFFE_Section.HJDJGMNAJFJ_EventGachaTicket,() => { return new JNGINLMOJKH(); } }, //0x149E7FC				"event_gacha_ticket",
		{(int)BEOKNKGHFFE_Section.MBMNNEODFFP_EventGoDivaA,() => { return new LNELCMNJPIC(); } }, //0x149E868				"event_godiva_a",
		{(int)BEOKNKGHFFE_Section.NLIBPDOHAPH_EventGoDivaB,() => { return new LNELCMNJPIC(); } }, //0x149E8D4				"event_godiva_b",
		{(int)BEOKNKGHFFE_Section.JLGODHLEBMK_EventGoDivaC,() => { return new LNELCMNJPIC(); } }, //0x149E940				"event_godiva_c",
		{(int)BEOKNKGHFFE_Section.OFAAHIINGFD_EventGoDivaRanking,() => { return new JPJGOECJFEE(); } }, //0x149E9AC				"event_godiva_ranking",
		{(int)BEOKNKGHFFE_Section.OFGFNFAJHFE_eventItem,() => { return new HGLPLKKBBOL(); } }, //0x149EA18				"event_item",
		{(int)BEOKNKGHFFE_Section.DCBIDPBJHOC_EventMissionA,() => { return new ACBAHDMEFFL(); } }, //0x149EA84				"event_mission_a",
		{(int)BEOKNKGHFFE_Section.BNCLLKEHEFH_EventMissionB,() => { return new ACBAHDMEFFL(); } }, //0x149EAF0				"event_mission_b",
		{(int)BEOKNKGHFFE_Section.BDGKKLAAJJB_EventMissionC,() => { return new ACBAHDMEFFL(); } }, //0x149EB5C				"event_mission_c",
		{(int)BEOKNKGHFFE_Section.CLKOFJKPPEP_EventPresentCampaignA,() => { return new HIADOIECMFP(); } }, //0x149EBC8				"event_present_campaign_a",
		{(int)BEOKNKGHFFE_Section.DCEHHGDDBPP_EventRaidA,() => { return new BKOGPDBKFFJ(); } }, //0x149EC34				"event_raid_a",
		{(int)BEOKNKGHFFE_Section.PLNOKLOLJEP_EventRaidB,() => { return new BKOGPDBKFFJ(); } }, //0x149ECA0				"event_raid_b",
		{(int)BEOKNKGHFFE_Section.IJEIEHHAJNM_EventRaidC,() => { return new BKOGPDBKFFJ(); } }, //0x149ED0C				"event_raid_c",
		{(int)BEOKNKGHFFE_Section.DMKFEJGOELJ_EventRaidD,() => { return new BKOGPDBKFFJ(); } }, //0x149ED78				"event_raid_d",
		{(int)BEOKNKGHFFE_Section.IEBPINPALBD_EventRaidLobbyA,() => { return new LDEBIBGHCGD(); } }, //0x149EDE4				"event_raidlobby_a",
		{(int)BEOKNKGHFFE_Section.CHNHFHCEKGN_EventRaidLobbyB,() => { return new LDEBIBGHCGD(); } }, //0x149EE50				"event_raidlobby_b",
		{(int)BEOKNKGHFFE_Section.FCAJCEOCDFF_EventRaidLobbyC,() => { return new LDEBIBGHCGD(); } }, //0x149EEBC				"event_raidlobby_c",
		{(int)BEOKNKGHFFE_Section.IJOLIEAOOJC_EventRaidLobbyD,() => { return new LDEBIBGHCGD(); } }, //0x149EF28				"event_raidlobby_d",
		{(int)BEOKNKGHFFE_Section.MDAEJLJPIHN_EventRaidItem,() => { return new NKBOMKGFGIO(); } }, //0x149EF94				"event_raid_item",
		{(int)BEOKNKGHFFE_Section.OJAHCPGNPDB_EventQuestA,() => { return new LMBBEGIAKAD(); } }, //0x149F000				"event_quest_a",
		{(int)BEOKNKGHFFE_Section.KGJMEGLKJDM_EventQuestB,() => { return new LMBBEGIAKAD(); } }, //0x149F06C				"event_quest_b",
		{(int)BEOKNKGHFFE_Section.LNBMDELKFHI_EventQuestC,() => { return new LMBBEGIAKAD(); } }, //0x149F0D8				"event_quest_c",
		{(int)BEOKNKGHFFE_Section.FMHLCBNFAOC_EventScoreA,() => { return new HIHJGPDLNDN(); } }, //0x149F144				"event_score_a",
		{(int)BEOKNKGHFFE_Section.LCJACACCKFC_EventScoreB,() => { return new HIHJGPDLNDN(); } }, //0x149F1B0				"event_score_b",
		{(int)BEOKNKGHFFE_Section.BPOFGIDPMBF_EventScoreC,() => { return new HIHJGPDLNDN(); } }, //0x149F21C				"event_score_c",
		{(int)BEOKNKGHFFE_Section.JPNKKKOHHLG_EventScoreD,() => { return new HIHJGPDLNDN(); } }, //0x149F288				"event_score_d",
		{(int)BEOKNKGHFFE_Section.ECHHEGJOHGI_EventScoreE,() => { return new HIHJGPDLNDN(); } }, //0x149F2F4				"event_score_e",
		{(int)BEOKNKGHFFE_Section.NLDGAHCIPAE_EventScoreF,() => { return new HIHJGPDLNDN(); } }, //0x149F360				"event_score_f",
		{(int)BEOKNKGHFFE_Section.MHGPKDOPEDJ_EventSpA,() => { return new HIHJGPDLNDN(); } }, //0x149F3CC				"event_sp_a",
		{(int)BEOKNKGHFFE_Section.AMGKNGLDHMG_EventTicket,() => { return new OEIJEFBBJBD(); } }, //0x149F438				"event_ticket",
		{(int)BEOKNKGHFFE_Section.BKEKCFONNBG_EventWeekDay,() => { return new DKCJADHKGAN(); } }, //0x149F4A4				"event_weekday",
		{(int)BEOKNKGHFFE_Section.JLNNFLCLGBM_EventStory,() => { return new FBIOJHECAHB(); } }, //0x149F510				"event_story",
		{(int)BEOKNKGHFFE_Section.MHNJLGONIPK_Exp,() => { return new JJOPEDJCCJK_Exp(); } }, //0x149F57C					"exp",
		{(int)BEOKNKGHFFE_Section.FPFHPCDNIDN_GachaLimit,() => { return new BIHCALIAJII(); } }, //0x149F5E8				"gacha_limit",
		{(int)BEOKNKGHFFE_Section.OJFINMGAFPG_GachaTicket,() => { return new PMDCIJMMNGK_GachaTicket(); } }, //0x149F654					"gacha_ticket",
		{(int)BEOKNKGHFFE_Section.HJBCLCJIAMN_Game,() => { return new LDDDBPNGGIN_Game(); } }, //0x149F6C0					"game",
		{(int)BEOKNKGHFFE_Section.JOMKJEEEGLM_GrowItem,() => { return new KEEKEFEPKFN_GrowItem(); } }, //0x149F72C				"grow_item",
		{(int)BEOKNKGHFFE_Section.MGLIHABHABA_HelpBrowser,() => { return new KCDJCKCKKFM(); } }, //0x149F798				"help_browser",
		{(int)BEOKNKGHFFE_Section.JHIAPFBBCCJ_HomeBg,() => { return new ALJHJDHNFFB(); } }, //0x149F804				"home_bg",
		{(int)BEOKNKGHFFE_Section.FLANCIJMJHP_HomePickup,() => { return new JJCJKALEIAC(); } }, //0x149F870				"home_pickup",
		{(int)BEOKNKGHFFE_Section.BKGFKGIGJNL_HomeVoice,() => { return new NPCCDMKJBMM(); } }, //0x149F8DC				"home_voice",
		{(int)BEOKNKGHFFE_Section.NLIJGKHKMII_RichBanner,() => { return new JKMLBONMAHD(); } }, //0x149F948				"rich_banner",
		{(int)BEOKNKGHFFE_Section.CLAMLDCILJO_Intimacy,() => { return new GJALOMELEHD_Intimacy(); } }, //0x149F9B4					"intimacy",
		{(int)BEOKNKGHFFE_Section.FONDIJMKCAJ_LimitOver,() => { return new LLKLAKGKNLD_LimitOver(); } }, //0x149FA20				"limit_over",
		{(int)BEOKNKGHFFE_Section.KPBNAHEIJIC_LimitedItem,() => { return new EGLOKAEIHCB(); } }, //0x149FA8C				"limited_item",
		{(int)BEOKNKGHFFE_Section.ECEDGCHFCEF_Medal,() => { return new HHFFOACILKG_Medal(); } }, //0x149FAF8				"medal",
		{(int)BEOKNKGHFFE_Section.HOBIIBFBMKJ_MonthlyPass,() => { return new KBCCGHLCFNO_MonthlyPass(); } }, //0x149FB64					"monthly_pass",
		{(int)BEOKNKGHFFE_Section.CHOGKKCHBCJ_Music,() => { return new LPPGENBEECK_MusicMaster(); } }, //0x149FBD0		"music",
		{(int)BEOKNKGHFFE_Section.JMJMNDKFOIF_MvTicket,() => { return new GJAEGCMKMEK(); } }, //0x149FC3C				"mv_ticket",
		{(int)BEOKNKGHFFE_Section.LNCIOFKDBHD_Offer,() => { return new LGHIPHEDCNC(); } }, //0x149FCA8				"offer",
		{(int)BEOKNKGHFFE_Section.GPEFCGBGIHD_Pilot,() => { return new MPOEMCEBBJH_Pilot(); } }, //0x149FD14				"pilot",
		{(int)BEOKNKGHFFE_Section.JFDOPKICHPJ_PresentItem,() => { return new MDACFBPPIHD(); } }, //0x149FD80				"present_item",
		{(int)BEOKNKGHFFE_Section.HDJDAENLIBF_Quest,() => { return new DHOJHGODBAB(); } }, //0x149FDEC				"quest",
		{(int)BEOKNKGHFFE_Section.KOALKJHIHFC_RareUpItem,() => { return new CKDOOBKOJBB(); } }, //0x149FE58				"rareup_item",
		{(int)BEOKNKGHFFE_Section.KNMIJOPCJCH_Scene,() => { return new MLIBEPGADJH_Scene(); } }, //0x149FEC4					"scene",
		{(int)BEOKNKGHFFE_Section.ELBGPMIFOHO_Shop,() => { return new BKPAPCMJKHE(); } }, //0x149FF30				"shop",
		{(int)BEOKNKGHFFE_Section.ABANJLALLBK_Skill,() => { return new JNKEEAOKNCI_Skill(); } }, //0x149FF9C				"skill",
		{(int)BEOKNKGHFFE_Section.HGOGFPOCKFA_Sns,() => { return new BOKMNHAFJHF(); } }, //0x14A0008				"sns",
		{(int)BEOKNKGHFFE_Section.LCEEHPPLHNC_SpItem,() => { return new PPNFHHPJOKK(); } }, //0x14A0074				"sp_item",
		{(int)BEOKNKGHFFE_Section.AOPBBHMIEPB_Story,() => { return new LAEGMENIEDB(); } }, //0x14A00E0				"story",
		{(int)BEOKNKGHFFE_Section.HGFDKEMHGHK_System,() => { return new PEBFNABDJDI_System(); } }, //0x14A014C					"system",
		{(int)BEOKNKGHFFE_Section.ACECCMLEDMO_Tips,() => { return new BCKMELFCKKN(); } }, //0x14A01B8				"tips",
		{(int)BEOKNKGHFFE_Section.HDDBEGLGIDK_TitleBanner,() => { return new JOHKNBEFHHP_TitleBanner(); } }, //0x14A0224					"title_banner",
		{(int)BEOKNKGHFFE_Section.EMHPGEHBKPG_TutorialMiniAdv,() => { return new ILLPGHGGKLL(); } }, //0x14A0290				"tutorial_mini_adv",
		{(int)BEOKNKGHFFE_Section.JJMBJBFKJHK_TutorialPict,() => { return new PJANOOPJIDE(); } }, //0x14A02FC				"tutorial_pict",
		{(int)BEOKNKGHFFE_Section.EKLPMPHCIDL_UcItem,() => { return new DGDIEDDPNNG(); } }, //0x14A0368				"uc_item",
		{(int)BEOKNKGHFFE_Section.OPHNLHMINEO_ValItem,() => { return new INDEPDKCJDD(); } }, //0x14A03D4				"val_item",
		{(int)BEOKNKGHFFE_Section.NPLKLHDPLEO_ValSkill,() => { return new GKFMJAHKEMA_ValSkill(); } }, //0x14A0440				"val_skill",
		{(int)BEOKNKGHFFE_Section.EEPIDKPPLJI_Valkyrie,() => { return new JPIANKEOOMB_Valkyrie(); } }, //0x14A04AC				"valkyrie",
		{(int)BEOKNKGHFFE_Section.LJKEOODGGJF_VcItem,() => { return new DKJMDIFAKKD(); } }, //0x14A0518				"vc_item",
		{(int)BEOKNKGHFFE_Section.NPOPGPFPLOL_HighscoreRating,() => { return new HGPEFPFODHO_HighScoreRanking(); } }, //0x14A0584				"highscore_rating",
		{(int)BEOKNKGHFFE_Section.AHKEJPLNAJK_LimitedCompoItem,() => { return new JHAAHJNEBOG(); } }, //0x14A05F0				"limited_compo_item"
	}; // 0x8

	public GPMHOAKFALE_Adventure EFMAIKAHFEK_Adventure { get; private set; } // 0x14 JLLBGAHIIBG LLCFMAELHEP IEBCIAFOBIN
	public IPJBAPLFECP_Anketo OILKBADFBOK_Anketo { get; private set; } // 0x18 PMEPLHGCOPN ACKDFMAHCPG IKNMGMOEIBJ
	public LFPJCEMANCK_Asset IELDDHJMFKN_Asset { get; private set; } // 0x1C POIPNMNLPII LDEGIHHDKIM OPKDGNFPLMJ
	public JKICPBIIHNE_Bingo FPOIPGFFAPE_Bingo { get; private set; } // 0x20 IGDEDAEJHHE DGFJAPEKHFO GNMGEPPDCKA
	public KOGHKIODHPA_Board JEMMMJEJLNL_Board { get; private set; } // 0x24 JCNENMIJKJM LEOMPFKGIDH OJLDODJNICJ
	public HHJHIFJIKAC_BonusVc NBKNAAPBFFL_BonusVc { get; private set; } // 0x28 DPLHDEEFDJM ADJIKEFIPJA JNIKDFJOHFA
	public AIPOFGJGPKI_CampaignDiva NGCCGLLLDIB_CampaignDiva { get; private set; } // 0x2C AKMEDCJEFIM ONFFEFOLNJA KHNFCNCCAJE
	public HHPEMHHCKBE_Compo ALFKMKICDPP_Compo { get; private set; } // 0x30 EGAMKFEHKOH OFKPEOKIBOP FBMPHCEEOGP
	public PLPBJOFICEJ_CosItem GOGFKAECFIP_CosItem { get; private set; } // 0x34 MFAKBNOPMAL ONAJMJDFKII OKGBJKKKBJK
	public LCLCCHLDNHJ_Costume MFPNGNMFEAL_Costume { get; private set; } // 0x38 BNPFDJNHBIN BHOKMJJHOOK PCDDICJFIEI
	public NDBFKHKMMCE_DecoItem EPAHOAKPAJJ_DecoItem { get; private set; } // 0x3C LKAKMHGBHKJ JHPEPALKAMJ BHEAGEGHAJB
	public JEPMHCPBIGD_DecoItemInit CIGBHCHOPEO_DecoItemInit { get; private set; } // 0x40 BONFHNBALOL GNIGMPDFEPP LFDFGOBDAMF
	public GAEBMAEDNAN_DecoPoint PJGDIJPCHAK_DecoPoint { get; private set; } // 0x44 JCDPLJOOJLG CMDIEHHIFOK CMJFJNNDFJJ
	public BBLECJKKKLA_DecoSetItem MJALLIOHKEJ_DecoSetItem { get; private set; } // 0x48 ABEMGBAJEBL BABMGOIFCOH GIIEMCFFDBD
	public NEGELNMPEPH_DecoSpSetting BGKKOOGPEFD_DecoSpSetting { get; private set; } // 0x4C AAPCGHFOHFC BALCOIHEDMF BKGBCKMOMGN
	public IHFIAFDLAAK_DecoStamp GAPONCJOKAC_DecoStamp { get; private set; } // 0x50 NCNFBFCCPGG OJGMINMADBB NEPJLJDPKKN
	public HPBPIOPPDCB_Diva MGFMPKLLGHE_Diva { get; private set; } // 0x54 ONCMJNDIMPD // ODGINDHEIBJ GIFOPLEGJCI
	public HMIJOOPHJLB_Diva2 OAINIGNLJKC_Diva2 { get; private set; } // 0x58 EFGHBGKGCDI KNBBENGMPJL MAPJOGCOBCF
	public NBPHJDCOECH_Drop HGLIIPFLMFB_Drop { get; private set; } // 0x5C DNBKBMJEDFG GEHKLFKNGDK DAEJHNBAAHD
	public IHGBPAJMJFK_Emblem LBNBNAFGMDE_Emblem { get; private set; } // 0x60 DOKBBBOMOIP AEKIOLPFPCO PMEOIDAFOLD
	public MHDFCLCMDKO_Enemy OPFBEAJJMJB_Enemy { get; private set; } // 0x64 DMKMEHGHLAL EDGAJGHMGOK AIBFBDMGEAL
	public JKDKODAPGBJ_EnergyItem KOPOGNLKAEN_EnergyItem { get; private set; } // 0x68 DACOHEDKLPD AEOJDBAPOEN PABHKGHLLLJ
	public KIICLPJJBNL_EpiItem NEGGMILDEEF_EpiItem { get; private set; } // 0x6C EEAPHFKEOOP EPDABADJFBH CFGCGOGNBMM
	public KMOGDEOKHPG_Episode MOLEPBNJAGE_Episode { get; private set; } // 0x70 PKELMNGHNJI GJAGLJAIAGC ECGGGFGFEOH
	public JNGINLMOJKH NKOKFIMNCJM { get; private set; } // 0x74 OOLBNNCGINP CHGCEALBNFF BDBOOJDGKFP
	public JPJGOECJFEE EFHMLHKODOD { get; private set; } // 0x78 KAOFKMKMDPH PAGHOGPONBK AODLPJLNDBK
	public HGLPLKKBBOL DHOFNBMPBAG { get; private set; } // 0x7C HLPDMEMHECG ILMEKLNLPND HMDGNIKNDKM
	public NKBOMKGFGIO ONOJBMDKBLE { get; private set; } // 0x80 OLLFECMFKIC JOKCENNIGCE IJCDMHJCMBO
	public ABBOEIPOBLJ KHPOJKHKLEM { get; private set; } // 0x84 MOKKFOJJBOL GPOGPBKFNLJ DILCIJAHIOB
	public DKCJADHKGAN CLLPBOPLICM { get; private set; } // 0x88 FNJBPMENMGD GFEDAIKEGGC AIDDOHHKJGG
	public FBIOJHECAHB NBEMLGADAGK { get; private set; } // 0x8C DCKAOHBMJLM INDINPLHFPO CJBHGJLJBNJ
	public JJOPEDJCCJK_Exp FMPEMFPLPDA_Exp { get; private set; } // 0x90 NFHAGPKJMCM JBOGJKMKPHB LJNHCFIIOBB
	public BIHCALIAJII OINLLHOMEAK { get; private set; } // 0x94 NFNMMHLNOME ACMDICBGLLH AECOJNDBPPA
	public PMDCIJMMNGK_GachaTicket GKMAHADAAFI_GachaTicket { get; private set; } // 0x98 CDPNLBODAFG MIOKEFPFJPL JCGBPLBDCED
	public LDDDBPNGGIN_Game HNMMJINNHII_Game { get; private set; } // 0x9C OEGOKKFEMLN // NNKOOANMMJN FDBLNEBHBKD
	public KEEKEFEPKFN_GrowItem NKDGLGCAPEI_GrowItem { get; private set; } // 0xA0 OEBKCKBOHDC GKNAKMMFPJG FPNMNKOHIDL
	public KCDJCKCKKFM LOJAMHAADBF { get; private set; } // 0xA4 PHJBEOHOPNK BEONJGJAHHA GKIMOCCMPNE
	public ALJHJDHNFFB PFEKKPABPKL { get; private set; } // 0xA8 ODEEPLDCIDD CJNCHHCJDLG EJKAKGDGDOJ
	public JJCJKALEIAC NFDHMGGLEPN { get; private set; } // 0xAC GGHPDLEFLAF KFBIAJPDFOL BLPBJMIOOHJ
	public NPCCDMKJBMM MGIMEEEALPK { get; private set; } // 0xB0 IIGKAHAPDCK EMOJEAIPDCL KJJAAHMMPDD
	public JKMLBONMAHD MLGEHCJPAFB { get; private set; } // 0xB4 DIOBCOIDGBL KLENJIKKNGL MCEKLAONFOO
	public GJALOMELEHD_Intimacy KDIALKDKBGE_Intimacy { get; private set; } // 0xB8 AJILIAMLKCN OHOFMNKPACI AJNFIOMEBPE
	public LLKLAKGKNLD_LimitOver HDGOHBFKKDM_LimitOver { get; private set; } // 0xBC GOCPJPDCIFF HNHCBNDJBIL OMHPACMOBMD
	public EGLOKAEIHCB IHPFCIJKFIC { get; private set; } // 0xC0 DLCGGEGFOFM BKAPBBKJELI MINMKCJFHDG
	public HHFFOACILKG_Medal ICICKEBMEFA_Medal { get; private set; } // 0xC4 BLEKIIHCAEL ECAMAOEFEJK IEOJCBOIKPN
	public KBCCGHLCFNO_MonthlyPass MEGJDBJCEOC_MonthlyPass { get; private set; } // 0xC8 LAJCNNENFPJ MIALNGOCOPJ NABHFEAEHFH
	public LPPGENBEECK_MusicMaster IBPAFKKEKNK_Music { get; private set; } // 0xCC CKFEJCIKLAE AHENIIKNNJF HMKLOBHNMMI
	public GJAEGCMKMEK NEGKEEAFKHP { get; private set; } // 0xD0 NFCPFDJHNFE HEMDMBJABPN EJFOCHNEPKD
	public LGHIPHEDCNC LBCMJGOOHLJ { get; private set; } // 0xD4 NAAKJHEPHGP NFGKMIAHJHD FMJANBICBME
	public MPOEMCEBBJH_Pilot OBGGLAKOHKP_Pilot { get; private set; } // 0xD8 AHLBGPDJMCC PLOCKLBILGJ CFGIBLPKPOH
	public MDACFBPPIHD LPFEHNJEJFB { get; private set; } // 0xDC HFOPPMPKKFL BCAGHHBCENF FKMAMMGADKI
	public DHOJHGODBAB MHGPMMIDKMM { get; private set; } // 0xE0 HFKCBLFIKEC BODCNAFFNII JFGOKBPMCFL
	public CKDOOBKOJBB KKIMFMKOHFH { get; private set; } // 0xE4 NFOFMEKFHEA AMANIEHMCLH OHKJEENNABM
	public MLIBEPGADJH_Scene ECNHDEHADGL_Scene { get; private set; } // 0xE8 IEIOOBGMFNI ACAKHGDFOPE MINEODNFCJG
	public BKPAPCMJKHE IFLGCDGOLOP { get; private set; } // 0xEC LPLEPMGGDMC JPPGBAEFJHD NNMGMDJDAEB
	public JNKEEAOKNCI_Skill FOFADHAENKC_Skill { get; private set; } // 0xF0 EMMJGCNLPIC AIKMDJIOIPO ODHIIKEDPDK
	public BOKMNHAFJHF OMGFKMANMAB { get; private set; } // 0xF4 MFLNAPMHPKD IEFPCCJONCN FJJMCAEKDCM
	public PPNFHHPJOKK OOEPHOEFBNL { get; private set; } // 0xF8 GEDHKEFKHEH HCAIIFDMGHF ELGOCAOHJBM
	public LAEGMENIEDB OHCIFMDPAPD { get; private set; } // 0xFC OCCBGBFIPFH HLLFEGMBGLE IKHIJOGKIAL
	public PEBFNABDJDI_System GDEKCOOBLMA_System { get; private set; } // 0x100 PINEBDOIEIB LIJDDDCBNPL AAEDGCBNJAO
	public BCKMELFCKKN KNMFNBEOGON { get; private set; } // 0x104 CLNAKEBEBIM HAAKPEOBDIO JNKAICHDNND
	public JOHKNBEFHHP_TitleBanner ACPALDEELCL_TitleBanner { get; private set; } // 0x108 MOHDEFAGJCD HCJMPMCLFAL OEBNPODPBGG
	public DGDIEDDPNNG NMJEDFNPIPL { get; private set; } // 0x10C AIDFHJFIJJE BOGKAJBELIJ ONFDHFKPFHK
	public DKJMDIFAKKD KCCDBKIOLDJ { get; private set; } // 0x110 NFOKONGDFNH MJBBGKMNMKH LFKKHMAFIBA
	public INDEPDKCJDD FBGKBGNIHGC { get; private set; } // 0x114 MOPJLGOMNLJ BAGFGFIMNLH KPAEENCFPIH
	public GKFMJAHKEMA_ValSkill DIAEPFPGPEP_ValSkill { get; private set; } // 0x118 BCDPCPEGMHC MOJPFJFKFPG IMCKGLCKPED
	public JPIANKEOOMB_Valkyrie PEOALFEGNDH_Valkyrie { get; private set; } // 0x11C IOEEBHMLNFN HFDLJDHDCED MJFJKMCBIHC
	public HGPEFPFODHO_HighScoreRanking DCNNPEDOGOG_HighScoreRanking { get; private set; } // 0x120 DGEJGGLIBPK DDMLBAIOIHC ADFIKFDMPAN
	public ILLPGHGGKLL LINHIDCNAMG { get; private set; } // 0x124 CKMGPFOBCMH FAIKNJFGDIB MLLLCNLNJBI
	public PJANOOPJIDE KIBMNCOLJNC { get; private set; } // 0x128 KNIHEPFNDKP FDIFJJONAEA MLKGAOGFOPI
	public JHAAHJNEBOG MBAGKLJDKMH { get; private set; } // 0x12C HKMFFDNMOBN BDENFILNIID BHGPHONEKGL

	// // RVA: 0x149049C Offset: 0x149049C VA: 0x149049C
	// private static bool LIPIIKKIKOI(OKGLGHCBCJP.BEOKNKGHFFE[] NNDGIAEFMOG, OKGLGHCBCJP.BEOKNKGHFFE PPFNGGCBJKC_Id) { }

	// // RVA: 0x1490508 Offset: 0x1490508 VA: 0x1490508
	// private static bool LIPIIKKIKOI(List<OKGLGHCBCJP.BEOKNKGHFFE> NNDGIAEFMOG, OKGLGHCBCJP.BEOKNKGHFFE PPFNGGCBJKC_Id) { }

	// // RVA: 0x14905D0 Offset: 0x14905D0 VA: 0x14905D0
	public void LNAKMLCCEJG_AddSections(List<BEOKNKGHFFE_Section> NNDGIAEFMOG, BEOKNKGHFFE_Section[] FCCKCFEEOMN)
	{
		for(int i = 0; i < FCCKCFEEOMN.Length; i++)
		{
			bool found = false;
			for(int j = 0; j < NNDGIAEFMOG.Count; j++)
			{
				if(FCCKCFEEOMN[i] == NNDGIAEFMOG[j])
				{
					found = true;
					break;
				}
			}
			if(!found)
				NNDGIAEFMOG.Add(FCCKCFEEOMN[i]);
		}
	}

	// // RVA: 0x1490734 Offset: 0x1490734 VA: 0x1490734
	// private static string JEHFDJPOEFF(string HKICMNAACDA) { }

	// // RVA: 0x1490738 Offset: 0x1490738 VA: 0x1490738
	// private static bool FNHALBBECIM(OKGLGHCBCJP.BEOKNKGHFFE NEJBNCHLMNJ) { }

	// RVA: 0x1490C94 Offset: 0x1490C94 VA: 0x1490C94
	public OKGLGHCBCJP_Database()
	{
		for(int i = 0; i < 117; i++)
		{
			IIILDINMAKI_SectionNames[i] = IJBLEJOKEFH_SectionNames[i];
			GJFPFFBAKGK_SectionCloseTime[i] = 0;
		}
	}

	// RVA: 0x1490E98 Offset: 0x1490E98 VA: 0x1490E98
	public List<string> PKOJMBICNHH_GetBlockNames()
	{
		List<string> res = new List<string>(MGJKEJHEBPO_SectionList.Count);
		for(int i = 0; i < MGJKEJHEBPO_SectionList.Count; i++)
		{
			res.Add(MGJKEJHEBPO_SectionList[i].JIKKNHIAEKG_BlockName);
		}
		return res;
	}

	// // RVA: 0x149101C Offset: 0x149101C VA: 0x149101C
	// public DIHHCBACKGG LBDOLHGDIEB(string OPFGFINHFCE) { }

	// // RVA: -1 Offset: -1
	// public T LBDOLHGDIEB<T>(string OPFGFINHFCE) { }
	// /* GenericInstMethod :
	// |
	// |-RVA: 0x1AB61C8 Offset: 0x1AB61C8 VA: 0x1AB61C8
	// |-OKGLGHCBCJP.LBDOLHGDIEB<object>
	// */

	// // RVA: 0x149111C Offset: 0x149111C VA: 0x149111C
	// public bool LGLJALBIIIB() { }

	// // RVA: 0x1491240 Offset: 0x1491240 VA: 0x1491240
	public List<BEOKNKGHFFE_Section> BPCKOIDILDK_GetSectionsValid(List<GDIPLANPCEI> JOBKIDDLCPL, long JHNMKKNEENE_Time)
	{
		List<BEOKNKGHFFE_Section> res = new List<BEOKNKGHFFE_Section>(117);
		for(int i = 0; i < 117; i++)
		{
			IIILDINMAKI_SectionNames[i] = IJBLEJOKEFH_SectionNames[i];
			GJFPFFBAKGK_SectionCloseTime[i] = 0;
			bool valid = true;
			switch((BEOKNKGHFFE_Section)i)
			{
				case /*0x18*/BEOKNKGHFFE_Section.OBEAIJOHOAJ_EventAprilFoolA:
				case /*0x19*/BEOKNKGHFFE_Section.GCEPOPPDPOC_EventAprilFoolB:
				case /*0x1a*/BEOKNKGHFFE_Section.EMOOIGBGHLG_EventAprilFoolC:
				case /*0x1b*/BEOKNKGHFFE_Section.AEGNEIOAOKI_EventAprilFoolD:
				case /*0x1c*/BEOKNKGHFFE_Section.KNNGKODFAGC_EventAprilFoolE:
				case /*0x1d*/BEOKNKGHFFE_Section.AFGGHHOHILP_EventAprilFoolF:
				case /*0x1e*/BEOKNKGHFFE_Section.EICBLKBKMKE_EventAprilFoolG:
				case /*0x1f*/BEOKNKGHFFE_Section.FIKPHDFLIIM_EventAprilFoolH:
				case /*0x20*/BEOKNKGHFFE_Section.FNLCLINDJAF_EventAprilFoolI:
				case /*0x21*/BEOKNKGHFFE_Section.IEICONEHLFE_EventBattleA:
				case /*0x22*/BEOKNKGHFFE_Section.CJLAEPKNNJE_EventBattleB:
				case /*0x23*/BEOKNKGHFFE_Section.MPCNKNCKBAE_EventBattleC:
				case /*0x24*/BEOKNKGHFFE_Section.COFHBPGDPML_EventBoxGachaA:
				case /*0x25*/BEOKNKGHFFE_Section.BHJGBPLKMBK_EventBoxGachaB:
				case /*0x26*/BEOKNKGHFFE_Section.AHDKIFOPEHM_EventBoxGachaC:
				case /*0x27*/BEOKNKGHFFE_Section.LLEDCLGDDCD_EventBoxGachaD:
				case /*0x28*/BEOKNKGHFFE_Section.ACNPHHGCHAF_EventBoxGachaE:
				case /*0x29*/BEOKNKGHFFE_Section.FEICGBHOIPB_EventBoxGachaF:
				case /*0x2a*/BEOKNKGHFFE_Section.OAOKLHCDPON_EventCollectionA:
				case /*0x2b*/BEOKNKGHFFE_Section.GGKFEJFMNGP_EventCollectionB:
				case /*0x2c*/BEOKNKGHFFE_Section.LLHBBEMKIGD_EventCollectionC:
				case /*0x2e*/BEOKNKGHFFE_Section.MBMNNEODFFP_EventGoDivaA:
				case /*0x2f*/BEOKNKGHFFE_Section.NLIBPDOHAPH_EventGoDivaB:
				case /*0x30*/BEOKNKGHFFE_Section.JLGODHLEBMK_EventGoDivaC:
				case /*0x33*/BEOKNKGHFFE_Section.DCBIDPBJHOC_EventMissionA:
				case /*0x34*/BEOKNKGHFFE_Section.BNCLLKEHEFH_EventMissionB:
				case /*0x35*/BEOKNKGHFFE_Section.BDGKKLAAJJB_EventMissionC:
				case /*0x36*/BEOKNKGHFFE_Section.CLKOFJKPPEP_EventPresentCampaignA:
				case /*0x37*/BEOKNKGHFFE_Section.DCEHHGDDBPP_EventRaidA:
				case /*0x38*/BEOKNKGHFFE_Section.PLNOKLOLJEP_EventRaidB:
				case /*0x39*/BEOKNKGHFFE_Section.IJEIEHHAJNM_EventRaidC:
				case /*0x3a*/BEOKNKGHFFE_Section.DMKFEJGOELJ_EventRaidD:
				case /*0x3b*/BEOKNKGHFFE_Section.IEBPINPALBD_EventRaidLobbyA:
				case /*0x3c*/BEOKNKGHFFE_Section.CHNHFHCEKGN_EventRaidLobbyB:
				case /*0x3d*/BEOKNKGHFFE_Section.FCAJCEOCDFF_EventRaidLobbyC:
				case /*0x3e*/BEOKNKGHFFE_Section.IJOLIEAOOJC_EventRaidLobbyD:
				case /*0x40*/BEOKNKGHFFE_Section.OJAHCPGNPDB_EventQuestA:
				case /*0x41*/BEOKNKGHFFE_Section.KGJMEGLKJDM_EventQuestB:
				case /*0x42*/BEOKNKGHFFE_Section.LNBMDELKFHI_EventQuestC:
				case /*0x43*/BEOKNKGHFFE_Section.FMHLCBNFAOC_EventScoreA:
				case /*0x44*/BEOKNKGHFFE_Section.LCJACACCKFC_EventScoreB:
				case /*0x45*/BEOKNKGHFFE_Section.BPOFGIDPMBF_EventScoreC:
				case /*0x46*/BEOKNKGHFFE_Section.JPNKKKOHHLG_EventScoreD:
				case /*0x47*/BEOKNKGHFFE_Section.ECHHEGJOHGI_EventScoreE:
				case /*0x48*/BEOKNKGHFFE_Section.NLDGAHCIPAE_EventScoreF:
				case /*0x49*/BEOKNKGHFFE_Section.MHGPKDOPEDJ_EventSpA:
					valid = false;
					break;
				default:
				break;
			}
			for(int j = 0; j < JOBKIDDLCPL.Count; j++)
			{
				if(JOBKIDDLCPL[j].KBFOIECIADN_OpenedAt < JHNMKKNEENE_Time && JOBKIDDLCPL[j].EGBOHDFBAPB_ClosedAt > JHNMKKNEENE_Time)
				{
					if(IJBLEJOKEFH_SectionNames[i] != "" && JOBKIDDLCPL[j].OPFGFINHFCE_Name == IJBLEJOKEFH_SectionNames[i])
					{
						IIILDINMAKI_SectionNames[i] = JOBKIDDLCPL[j].OPFGFINHFCE_Name;
						GJFPFFBAKGK_SectionCloseTime[i] = JOBKIDDLCPL[j].EGBOHDFBAPB_ClosedAt;
						valid = true;
					}
				}
			}
			if(valid)
			{
				UnityEngine.Debug.Log("Database will load : "+IJBLEJOKEFH_SectionNames[i]);
				res.Add((BEOKNKGHFFE_Section)i);
			}
			else
			{
				UnityEngine.Debug.Log("Wont load "+IJBLEJOKEFH_SectionNames[i]);
			}
		}
		return res;
	}

	// // RVA: 0x1491860 Offset: 0x1491860 VA: 0x1491860
	// public void KHEKNNFCAOI_Init() { }

	// // RVA: 0x1494278 Offset: 0x1494278 VA: 0x1494278
	public void KHEKNNFCAOI_Init(List<BEOKNKGHFFE_Section> INBBCDGDMLC)
	{
		KHEKNNFCAOI_Init(INBBCDGDMLC.ToArray());
	}

	// // RVA: 0x14918F8 Offset: 0x14918F8 VA: 0x14918F8
	public void KHEKNNFCAOI_Init(BEOKNKGHFFE_Section[] INBBCDGDMLC)
	{
		MGJKEJHEBPO_SectionList = new List<DIHHCBACKGG_DbSection>();
		EFMAIKAHFEK_Adventure = null;
		OILKBADFBOK_Anketo = null;
		IELDDHJMFKN_Asset = null;
		FPOIPGFFAPE_Bingo = null;
		JEMMMJEJLNL_Board = null;
		NBKNAAPBFFL_BonusVc = null;
		NGCCGLLLDIB_CampaignDiva = null;
		ALFKMKICDPP_Compo = null;
		GOGFKAECFIP_CosItem = null;
		MFPNGNMFEAL_Costume = null;
		EPAHOAKPAJJ_DecoItem = null;
		CIGBHCHOPEO_DecoItemInit = null;
		PJGDIJPCHAK_DecoPoint = null;
		MJALLIOHKEJ_DecoSetItem = null;
		BGKKOOGPEFD_DecoSpSetting = null;
		GAPONCJOKAC_DecoStamp = null;
		MGFMPKLLGHE_Diva = null;
		OAINIGNLJKC_Diva2 = null;
		HGLIIPFLMFB_Drop = null;
		LBNBNAFGMDE_Emblem = null;
		OPFBEAJJMJB_Enemy = null;
		KOPOGNLKAEN_EnergyItem = null;
		NEGGMILDEEF_EpiItem = null;
		MOLEPBNJAGE_Episode = null;
		NKOKFIMNCJM = null;
		EFHMLHKODOD = null;
		DHOFNBMPBAG = null;
		ONOJBMDKBLE = null;
		KHPOJKHKLEM = null;
		CLLPBOPLICM = null;
		NBEMLGADAGK = null;
		FMPEMFPLPDA_Exp = null;
		OINLLHOMEAK = null;
		GKMAHADAAFI_GachaTicket = null;
		HNMMJINNHII_Game = null;
		NKDGLGCAPEI_GrowItem = null;
		LOJAMHAADBF = null;
		PFEKKPABPKL = null;
		NFDHMGGLEPN = null;
		MGIMEEEALPK = null;
		MLGEHCJPAFB = null;
		KDIALKDKBGE_Intimacy = null;
		HDGOHBFKKDM_LimitOver = null;
		IHPFCIJKFIC = null;
		ICICKEBMEFA_Medal = null;
		MEGJDBJCEOC_MonthlyPass = null;
		IBPAFKKEKNK_Music = null;
		NEGKEEAFKHP = null;
		LBCMJGOOHLJ = null;
		OBGGLAKOHKP_Pilot = null;
		LPFEHNJEJFB = null;
		MHGPMMIDKMM = null;
		KKIMFMKOHFH = null;
		ECNHDEHADGL_Scene = null;
		IFLGCDGOLOP = null;
		FOFADHAENKC_Skill = null;
		OMGFKMANMAB = null;
		OOEPHOEFBNL = null;
		OHCIFMDPAPD = null;
		GDEKCOOBLMA_System = null;
		KNMFNBEOGON = null;
		ACPALDEELCL_TitleBanner = null;
		NMJEDFNPIPL = null;
		KCCDBKIOLDJ = null;
		FBGKBGNIHGC = null;
		DIAEPFPGPEP_ValSkill = null;
		PEOALFEGNDH_Valkyrie = null;
		DCNNPEDOGOG_HighScoreRanking = null;
		LINHIDCNAMG = null;
		KIBMNCOLJNC = null;
		MBAGKLJDKMH = null;
		NDLAAACJOLP.Clear();
		
		for(int i = 0; i < INBBCDGDMLC.Length; i++)
		{
			DIHHCBACKGG_DbSection item = MNMFKKKFDCL(INBBCDGDMLC[i]);
			if(item != null)
			{
				NDLAAACJOLP.Add(INBBCDGDMLC[i]);
				MGJKEJHEBPO_SectionList.Add(item);
				switch(INBBCDGDMLC[i])
				{
					case BEOKNKGHFFE_Section.LIIJEGOIKDP_Adventure: EFMAIKAHFEK_Adventure = (GPMHOAKFALE_Adventure)item; break;
					case BEOKNKGHFFE_Section.MLNHHIIDJAO_Anketo: OILKBADFBOK_Anketo = (IPJBAPLFECP_Anketo)item; break;
					case BEOKNKGHFFE_Section.PICOGHJNOJA_Asset: IELDDHJMFKN_Asset = (LFPJCEMANCK_Asset)item; break;
					case BEOKNKGHFFE_Section.DBBOBIHPDNA_Bingo: FPOIPGFFAPE_Bingo = (JKICPBIIHNE_Bingo)item; break;
					case BEOKNKGHFFE_Section.PEIFIFLMIIF_Board: JEMMMJEJLNL_Board = (KOGHKIODHPA_Board)item; break;
					case BEOKNKGHFFE_Section.JOMAMMACANH_BonusVC: NBKNAAPBFFL_BonusVc = (HHJHIFJIKAC_BonusVc)item; break;
					case BEOKNKGHFFE_Section.DHMPHBPODCI_CampaignDiva: NGCCGLLLDIB_CampaignDiva = (AIPOFGJGPKI_CampaignDiva)item; break;
					case BEOKNKGHFFE_Section.DGPIFKCLAGB_Compo: ALFKMKICDPP_Compo = (HHPEMHHCKBE_Compo)item; break;
					case BEOKNKGHFFE_Section.EFHFNMAIEJG_CosItem: GOGFKAECFIP_CosItem = (PLPBJOFICEJ_CosItem)item; break;
					case BEOKNKGHFFE_Section.LOFOAIEMECN_Costume: MFPNGNMFEAL_Costume = (LCLCCHLDNHJ_Costume)item; break;
					case BEOKNKGHFFE_Section.LHFCAMJHMLB_DecoItem: EPAHOAKPAJJ_DecoItem = (NDBFKHKMMCE_DecoItem)item; break;
					case BEOKNKGHFFE_Section.BGMIHMDPDCM_DecoItemInit: CIGBHCHOPEO_DecoItemInit = (JEPMHCPBIGD_DecoItemInit)item; break;
					case BEOKNKGHFFE_Section.DBILOJAEIOO_DecoPoint: PJGDIJPCHAK_DecoPoint = (GAEBMAEDNAN_DecoPoint)item; break;
					case BEOKNKGHFFE_Section.DLFGIKANBDK_DecoSetItem: MJALLIOHKEJ_DecoSetItem = (BBLECJKKKLA_DecoSetItem)item; break;
					case BEOKNKGHFFE_Section.PLJHAFGEGEB_DecoSpSetting: BGKKOOGPEFD_DecoSpSetting = (NEGELNMPEPH_DecoSpSetting)item; break;
					case BEOKNKGHFFE_Section.DHMEFNNJANH_DecoStamp: GAPONCJOKAC_DecoStamp = (IHFIAFDLAAK_DecoStamp)item; break;
					case BEOKNKGHFFE_Section.CNENKCCMEFL_Diva: MGFMPKLLGHE_Diva = (HPBPIOPPDCB_Diva)item; break;
					case BEOKNKGHFFE_Section.ACGFJFNPLKB_Diva2: OAINIGNLJKC_Diva2 = (HMIJOOPHJLB_Diva2)item; break;
					case BEOKNKGHFFE_Section.PKDKLHJLEFA_Drop: HGLIIPFLMFB_Drop = (NBPHJDCOECH_Drop)item; break;
					case BEOKNKGHFFE_Section.PGHFPIMIOKE_Emblem: LBNBNAFGMDE_Emblem = (IHGBPAJMJFK_Emblem)item; break;
					case BEOKNKGHFFE_Section.CNGPLGIMJBB_Enemy: OPFBEAJJMJB_Enemy = (MHDFCLCMDKO_Enemy)item; break;
					case BEOKNKGHFFE_Section.JBFFIPCOGEC_EnergyItem: KOPOGNLKAEN_EnergyItem = (JKDKODAPGBJ_EnergyItem)item; break;
					case BEOKNKGHFFE_Section.BBDKHAMANCB_Episode: MOLEPBNJAGE_Episode = (KMOGDEOKHPG_Episode)item; break;
					case BEOKNKGHFFE_Section.MIOOJINHHFO_EpiItem: NEGGMILDEEF_EpiItem = (KIICLPJJBNL_EpiItem)item; break;
					case BEOKNKGHFFE_Section.HJDJGMNAJFJ_EventGachaTicket: NKOKFIMNCJM = (JNGINLMOJKH)item; break;
					case BEOKNKGHFFE_Section.OFAAHIINGFD_EventGoDivaRanking: EFHMLHKODOD = (JPJGOECJFEE)item; break;
					case BEOKNKGHFFE_Section.OFGFNFAJHFE_EventItem: DHOFNBMPBAG = (HGLPLKKBBOL)item; break;
					case BEOKNKGHFFE_Section.MDAEJLJPIHN_EventRaidItem: ONOJBMDKBLE = (NKBOMKGFGIO)item; break;
					case BEOKNKGHFFE_Section.AMGKNGLDHMG_EventTicket: KHPOJKHKLEM = (ABBOEIPOBLJ)item; break;
					case BEOKNKGHFFE_Section.BKEKCFONNBG_EventWeekDay: CLLPBOPLICM = (DKCJADHKGAN)item; break;
					case BEOKNKGHFFE_Section.JLNNFLCLGBM_EventStory: NBEMLGADAGK = (FBIOJHECAHB)item; break;
					case BEOKNKGHFFE_Section.MHNJLGONIPK_Exp: FMPEMFPLPDA_Exp = (JJOPEDJCCJK_Exp)item; break;
					case BEOKNKGHFFE_Section.FPFHPCDNIDN_GachaLimit: OINLLHOMEAK = (BIHCALIAJII)item; break;
					case BEOKNKGHFFE_Section.OJFINMGAFPG_GachaTicket: GKMAHADAAFI_GachaTicket = (PMDCIJMMNGK_GachaTicket)item; break;
					case BEOKNKGHFFE_Section.HJBCLCJIAMN_Game: HNMMJINNHII_Game = (LDDDBPNGGIN_Game)item; break;
					case BEOKNKGHFFE_Section.JOMKJEEEGLM_GrowItem: NKDGLGCAPEI_GrowItem = (KEEKEFEPKFN_GrowItem)item; break;
					case BEOKNKGHFFE_Section.MGLIHABHABA_HelpBrowser: LOJAMHAADBF = (KCDJCKCKKFM)item; break;
					case BEOKNKGHFFE_Section.JHIAPFBBCCJ_HomeBg: PFEKKPABPKL = (ALJHJDHNFFB)item; break;
					case BEOKNKGHFFE_Section.FLANCIJMJHP_HomePickup: NFDHMGGLEPN = (JJCJKALEIAC)item; break;
					case BEOKNKGHFFE_Section.BKGFKGIGJNL_HomeVoice: MGIMEEEALPK = (NPCCDMKJBMM)item; break;
					case BEOKNKGHFFE_Section.NLIJGKHKMII_RichBanner: MLGEHCJPAFB = (JKMLBONMAHD)item; break;
					case BEOKNKGHFFE_Section.CLAMLDCILJO_Intimacy: KDIALKDKBGE_Intimacy = (GJALOMELEHD_Intimacy)item; break;
					case BEOKNKGHFFE_Section.FONDIJMKCAJ_LimitOver: HDGOHBFKKDM_LimitOver = (LLKLAKGKNLD_LimitOver)item; break;
					case BEOKNKGHFFE_Section.KPBNAHEIJIC_LimitedItem: IHPFCIJKFIC = (EGLOKAEIHCB)item; break;
					case BEOKNKGHFFE_Section.ECEDGCHFCEF_Medal: ICICKEBMEFA_Medal = (HHFFOACILKG_Medal)item; break;
					case BEOKNKGHFFE_Section.HOBIIBFBMKJ_MonthlyPass: MEGJDBJCEOC_MonthlyPass = (KBCCGHLCFNO_MonthlyPass)item; break;
					case BEOKNKGHFFE_Section.CHOGKKCHBCJ_Music: IBPAFKKEKNK_Music = (LPPGENBEECK_MusicMaster)item; break;
					case BEOKNKGHFFE_Section.JMJMNDKFOIF_MvTicket: NEGKEEAFKHP = (GJAEGCMKMEK)item; break;
					case BEOKNKGHFFE_Section.LNCIOFKDBHD_Offer: LBCMJGOOHLJ = (LGHIPHEDCNC)item; break;
					case BEOKNKGHFFE_Section.GPEFCGBGIHD_Pilot: OBGGLAKOHKP_Pilot = (MPOEMCEBBJH_Pilot)item; break;
					case BEOKNKGHFFE_Section.JFDOPKICHPJ_PresentItem: LPFEHNJEJFB = (MDACFBPPIHD)item; break;
					case BEOKNKGHFFE_Section.HDJDAENLIBF_Quest: MHGPMMIDKMM = (DHOJHGODBAB)item; break;
					case BEOKNKGHFFE_Section.KOALKJHIHFC_RareUpItem: KKIMFMKOHFH = (CKDOOBKOJBB)item; break;
					case BEOKNKGHFFE_Section.KNMIJOPCJCH_Scene: ECNHDEHADGL_Scene = (MLIBEPGADJH_Scene)item; break;
					case BEOKNKGHFFE_Section.ELBGPMIFOHO_Shop: IFLGCDGOLOP = (BKPAPCMJKHE)item; break;
					case BEOKNKGHFFE_Section.ABANJLALLBK_Skill: FOFADHAENKC_Skill = (JNKEEAOKNCI_Skill)item; break;
					case BEOKNKGHFFE_Section.HGOGFPOCKFA_Sns: OMGFKMANMAB = (BOKMNHAFJHF)item; break;
					case BEOKNKGHFFE_Section.LCEEHPPLHNC_SpItem: OOEPHOEFBNL = (PPNFHHPJOKK)item; break;
					case BEOKNKGHFFE_Section.AOPBBHMIEPB_Story: OHCIFMDPAPD = (LAEGMENIEDB)item; break;
					case BEOKNKGHFFE_Section.HGFDKEMHGHK_System: GDEKCOOBLMA_System = (PEBFNABDJDI_System)item; break;
					case BEOKNKGHFFE_Section.ACECCMLEDMO_Tips: KNMFNBEOGON = (BCKMELFCKKN)item; break;
					case BEOKNKGHFFE_Section.HDDBEGLGIDK_TitleBanner: ACPALDEELCL_TitleBanner = (JOHKNBEFHHP_TitleBanner)item; break;
					case BEOKNKGHFFE_Section.EMHPGEHBKPG_TutorialMiniAdv: LINHIDCNAMG = (ILLPGHGGKLL)item; break;
					case BEOKNKGHFFE_Section.JJMBJBFKJHK_TutorialPict: KIBMNCOLJNC = (PJANOOPJIDE)item; break;
					case BEOKNKGHFFE_Section.EKLPMPHCIDL_UcItem: NMJEDFNPIPL = (DGDIEDDPNNG)item; break;
					case BEOKNKGHFFE_Section.OPHNLHMINEO_ValItem: FBGKBGNIHGC = (INDEPDKCJDD)item; break;
					case BEOKNKGHFFE_Section.NPLKLHDPLEO_ValSkill: DIAEPFPGPEP_ValSkill = (GKFMJAHKEMA_ValSkill)item; break;
					case BEOKNKGHFFE_Section.EEPIDKPPLJI_Valkyrie: PEOALFEGNDH_Valkyrie = (JPIANKEOOMB_Valkyrie)item; break;
					case BEOKNKGHFFE_Section.LJKEOODGGJF_VcItem: KCCDBKIOLDJ = (DKJMDIFAKKD)item; break;
					case BEOKNKGHFFE_Section.NPOPGPFPLOL_HighscoreRating: DCNNPEDOGOG_HighScoreRanking = (HGPEFPFODHO_HighScoreRanking)item; break;
					case BEOKNKGHFFE_Section.AHKEJPLNAJK_LimitedCompoItem: MBAGKLJDKMH = (JHAAHJNEBOG)item; break;
					default: TodoLogger.Log(TodoLogger.Database, "TODO" + INBBCDGDMLC[i]); break;
				}
			}
		}
	}

	// // RVA: 0x14942FC Offset: 0x14942FC VA: 0x14942FC
	private DIHHCBACKGG_DbSection MNMFKKKFDCL(OKGLGHCBCJP_Database.BEOKNKGHFFE_Section NEJBNCHLMNJ)
	{
		DIHHCBACKGG_DbSection res = null;
		if(BGEJFKHOMOC_CreateFuncs.ContainsKey((int)NEJBNCHLMNJ))
		{
			res = BGEJFKHOMOC_CreateFuncs[(int)NEJBNCHLMNJ]();
			res.LHPDDGIJKNB_Reset();
			res.JIKKNHIAEKG_BlockName = IIILDINMAKI_SectionNames[(int)NEJBNCHLMNJ];
		}
		return res;
	}

	// // RVA: 0x149494C Offset: 0x149494C VA: 0x149494C
	public bool IIEMACPEEBJ(List<string> ANFNAHPIJDH, EDOHBJAPLPF_JsonData AAEDAEHIONI)
	{
		TodoLogger.Log(0, "TODO");
		return false;
	}

	// // RVA: 0x1494FAC Offset: 0x1494FAC VA: 0x1494FAC
	public bool IIEMACPEEBJ(List<string> ANFNAHPIJDH_BlockNames, CBBJHPBGBAJ_Archive OCMCEKEKAPI)
	{
		CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File found = OCMCEKEKAPI.KGHAJGGMPKL_Files.Find((CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File GHPLINIACBB) => {
				//0x149D488
				return GHPLINIACBB.OPFGFINHFCE_Name == "schema_hash.bytes";
		});
		Dictionary<string, int> data = new Dictionary<string, int>();
		if(found != null)
		{
			BNBONBECPKB b = BNBONBECPKB.HEGEKFMJNCC(found.DBBGALAPFGC_Data);
			LPMLJGGJGGK[] array = b.GMLFFMJMPCC;
			for(int i = 0; i < array.Length; i++)
			{
				string str = array[i].OPFGFINHFCE;
				int val = array[i].IOIMHJAOKOO;
				data.Add(str, val);
			}
		}
		for(int i = 0; i < ANFNAHPIJDH_BlockNames.Count; i++)
		{
			string str2 = ANFNAHPIJDH_BlockNames[i];
			DIHHCBACKGG_DbSection item = MGJKEJHEBPO_SectionList.Find((DIHHCBACKGG_DbSection PKLPKMLGFGK) => {
				//0x14A06E4
				return PKLPKMLGFGK.JIKKNHIAEKG_BlockName == str2;
			});
			if(OCMCEKEKAPI != null && item != null)
			{
				string KHFAJGHCHPN = item.JIKKNHIAEKG_BlockName + ".bytes";
				CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File found2 = OCMCEKEKAPI.KGHAJGGMPKL_Files.Find((CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File GHPLINIACBB) => {
					//0x14A0728
					return GHPLINIACBB.OPFGFINHFCE_Name == KHFAJGHCHPN;
				});
				bool read = false;
				if(found2 != null)
				{
					if(!data.ContainsKey(LIGPJAIDNOA.MHDFCBBFMOA[item.LMHMIIKCGPE]))
					{
						Debug.LogError(LIGPJAIDNOA.MHDFCBBFMOA[item.LMHMIIKCGPE]+"schema not found");
						return false;
					}
					
					if(LIGPJAIDNOA.INPAHCHFIHM[item.LMHMIIKCGPE] != data[LIGPJAIDNOA.MHDFCBBFMOA[item.LMHMIIKCGPE]])
					{
						object[] strData = new object[5];
						//361
						strData[0] = LIGPJAIDNOA.MHDFCBBFMOA[item.LMHMIIKCGPE];
						strData[1] = " schema hash miss match  file=";
						strData[2] = data[LIGPJAIDNOA.MHDFCBBFMOA[item.LMHMIIKCGPE]];
						strData[3] = ",code=";
						strData[4] = LIGPJAIDNOA.INPAHCHFIHM[item.LMHMIIKCGPE];
						UnityEngine.Debug.Log(string.Concat(strData));
						return false;
					}
					read = true;
					if(!item.IIEMACPEEBJ(found2.DBBGALAPFGC_Data))
					{
						throw new Exception(item.JIKKNHIAEKG_BlockName + AFEHLCGHAEE_Strings.FAIOPNOJIBF_Slash /*'/'*/ + item.HDIDJNCGICK);
					}
				}
				string ECLJBKNPACL = item.JIKKNHIAEKG_BlockName + ".json";
				found2 = OCMCEKEKAPI.KGHAJGGMPKL_Files.Find((CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File GHPLINIACBB) => {
					//0x14A075C 
					return GHPLINIACBB.OPFGFINHFCE_Name == ECLJBKNPACL;
				});
				if(!read && found2 != null)
				{
					string jsonStr = Encoding.UTF8.GetString(found2.DBBGALAPFGC_Data);
					EDOHBJAPLPF_JsonData json = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(jsonStr);
					if(!item.IIEMACPEEBJ(json, 0))
					{
						throw new Exception(item.JIKKNHIAEKG_BlockName + AFEHLCGHAEE_Strings.FAIOPNOJIBF_Slash /*'/'*/ + item.HDIDJNCGICK);
					}
				}
			}	
		}
		return true;
	}

	// // RVA: 0x1496334 Offset: 0x1496334 VA: 0x1496334
	// public bool ALKOAPJCNFD(long JHNMKKNEENE) { }

	// // RVA: 0x1496410 Offset: 0x1496410 VA: 0x1496410
	public int PFAKPFKJJKA()
	{
		int res = 0;
		for(int i = 0; i < MGJKEJHEBPO_SectionList.Count; i++)
		{
			if(MGJKEJHEBPO_SectionList[i].HHPOFCILDGN != MGJKEJHEBPO_SectionList[i].CAOGDCBPBAN())
			{
				res |= 1 << (i & 0x1f);
			}
		}
		return res;
	}

	// // RVA: 0x1496570 Offset: 0x1496570 VA: 0x1496570
	public void IDBDAPPJOND()
	{
		for(int i = 0; i < MGJKEJHEBPO_SectionList.Count; i++)
		{
			MGJKEJHEBPO_SectionList[i].HHPOFCILDGN = MGJKEJHEBPO_SectionList[i].CAOGDCBPBAN();
		}
	}
	
}
