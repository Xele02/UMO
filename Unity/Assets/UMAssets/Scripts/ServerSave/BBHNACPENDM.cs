using System.Collections.Generic;
using XeSys;
using XeApp;

[System.Obsolete("Use BBHNACPENDM_ServerSaveData", true)]
public class BBHNACPENDM { }
public class BBHNACPENDM_ServerSaveData
{
	public enum BDADJONBIBO
	{
		HJNNKCMLGFL = 0,
		FKNGHCNOEHO = 1,
		GGEELFGJAMP = 2,
		AFGALHECDIJ = 3,
		LPKPFMHEKEM = 4
	}
	 
	public class EMHDCKMFCGE
	{
		public long MCKEOKFMLAH; // 0x8
		public EDOHBJAPLPF_JsonData OBHAFLMHAKG; // 0x10
		public string BAKAGKBPOMJ; // 0x14
		public bool BLOCFLFHCFJ; // 0x18
		public List<string> KFGDPMNCCFO; // 0x1C

		public string DLENPPIJNPA { get; }
		public bool CHBFPFLGELK { get; }

		// RVA: 0xF20530 Offset: 0xF20530 VA: 0xF20530
		public EMHDCKMFCGE(EDOHBJAPLPF_JsonData HIEGIHHJNAL, List<string> OHNJJIMGKGK, bool LDNHNDGCPJO, long MCKEOKFMLAH)
		{
			KFGDPMNCCFO = OHNJJIMGKGK;
			this.MCKEOKFMLAH = MCKEOKFMLAH;
			OBHAFLMHAKG = HIEGIHHJNAL;
			BLOCFLFHCFJ = LDNHNDGCPJO;
		}

		//// RVA: 0xF2AC9C Offset: 0xF2AC9C VA: 0xF2AC9C
		public string PBNINEMAOPB()
		{
			if(BAKAGKBPOMJ != null)
				return BAKAGKBPOMJ;
			KIJECNFNNDB_JsonWriter writer = new KIJECNFNNDB_JsonWriter();
			OBHAFLMHAKG.EJCOJCGIBNG_ToJson(writer);
			BAKAGKBPOMJ = writer.ToString();
			return BAKAGKBPOMJ;
		}

		//// RVA: 0xF2AD7C Offset: 0xF2AD7C VA: 0xF2AD7C
		public bool LHIACHALIFC_IsEmpty()
		{
			return KFGDPMNCCFO == null || KFGDPMNCCFO.Count == 0;
		}
	}

	private delegate KLFDBFMNLBL_ServerSaveBlock FFECIIHJDJA_CreateBlockDelegate();
	
	public static bool BDMPBPLHALI = false; // 0x0
	public BBHNACPENDM_ServerSaveData.BDADJONBIBO HFCOIIHIENB; // 0x8
	public const int PKPABMAPHGE = 100;
	public const int CFDJGBNJMIM_Base = 0;
	public const int IGCDFADKKML_Common = 1;
	public const int FCMMJOJINDN_PublicStatus = 2;
	public const int OGMHFJGALII_AllData = 3;
	public const int AAMNIFDPNLB_Diva = 4;
	public const int FKFMFFHOAIA_RecordMusic = 5;
	public const int PKCGBBNGJPO_Scene = 6;
	public const int HOPCNPLPEKE_StoryRecord = 7;
	public const int MKPMBBAECPA_Unit = 8;
	public const int PGPHCJNGDMM_Costume = 9;
	public const int EFEJOKPJEEN_Episode = 10;
	public const int DMIGNJMIEEJ_Valkyrie = 11;
	public const int IOKHNFIJAIM_Sns = 12;
	public const int NCKGBJOMPIB_EventCollection = 13;
	public const int EAGPNDEDLFI_FreeScoreMax = 14;
	public const int JMBDPGJFOAK_EventQuest = 15;
	public const int NJCDKKADEOM_Quest = 16;
	public const int AELKBIDPIEH_Counter = 17;
	public const int LEDKALJFJOL_Emblem = 18;
	public const int GEEOAMAMBHI_EventScore = 19;
	public const int AECIGBCCHPA_Adventure = 20;
	public const int JMKKPDNEOMC_EventBattle = 21;
	public const int IKBDIKPCKOG_EventBattlePlayer = 22;
	public const int FKBACFGLNLB_Prism = 23;
	public const int LDNKKDBABFD_Shop = 24;
	public const int GIMPPHEENJI_EventMission = 25;
	public const int GONHNMGEOGC_EventSP = 26;
	public const int GIKKNKGJBDJ_EventBoxGacha = 27;
	public const int GGHMGCGLDIF_Ticket = 28;
	public const int FBDIFLDJDMH_ArMarker = 29;
	public const int CFEFDIPHOIA_EventAprilFool = 30;
	public const int JGGKEOIOHHN_Offer = 31;
	public const int ICJCEFCINFB_MonthlyPass = 32;
	public const int DAELEHFKOMC_RareUpItem = 33;
	public const int OEEEKEIIMAC_LimitedItem = 34;
	public const int MNOIKPAPDMF_SaveHash = 35;
	public const int LBPMJOCELBC_Bingo = 36;
	public const int FENLNECLOON_EventRaid = 37;
	public const int ANNJOIOHDKJ_EventRaidLobby = 38;
	public const int MOOLMJMBMGB_EventRaidPlayer = 39;
	public const int NEGNIBDPEEM_DecoPublicSet = 40;
	public const int HFPPAGFAOJL_DecoPrivateSet = 41;
	public const int JONEDOPANFB_DecoItem = 42;
	public const int ONOEAPIBPCN_FavoritePlayer =  43;
	public const int NCIDKAFLDDD_DecoStamp = 44;
	public const int MMOCEAIPJJE_DecoPublicInfo = 45;
	public const int LALMBEGKBIG_DecoVisit = 46;
	public const int LPGMJAHFOKI_AssistPlate = 47;
	public const int AOKLBOLKCEN_LimitedCompoItem = 48;
	public const int PPEPINOOEMP_UnitGoDiva = 49;
	public const int AICNPGADBCE_EventGoDiva = 50;
	public const int AHBBPFBHJFA_AddMusic = 51;
	public const int CDBDHHBOBNI_GachaLimit = 52;
	private const ulong HDMIBFMIMCJ = 1;
	public const ulong EFBHIFFOKAB_FlagBase =					(ulong)1 << 0;
	public const ulong MLGABKNBICG_FlagCommon =					(ulong)1 << 1;
	public const ulong NBCOGOPBDAB_FlagPublicStatus =			(ulong)1 << 2;
	public const ulong MMIMLAKPBJB_FlagAllData =				(ulong)1 << 3;
	public const ulong ELHAENACNGM_FlagDiva =					(ulong)1 << 4;
	public const ulong MKBNHHNIHPG_FlagRecordMusic =			(ulong)1 << 5;
	public const ulong KFEKIEABCCB_FlagScene =					(ulong)1 << 6;
	public const ulong PEKKJODOMBE_FlagStoryRecord =			(ulong)1 << 7;
	public const ulong NCIIFBPCHJP_FlagUnit =					(ulong)1 << 8;
	public const ulong NPBDBMFHLLA_FlagCostume =				(ulong)1 << 9;
	public const ulong LFOLAAANHFO_FlagEpisode =				(ulong)1 << 10;
	public const ulong GNKACAJCGAG_FlagValkyrie =				(ulong)1 << 11;
	public const ulong ILAPIDMOMOP_FlagSns =					(ulong)1 << 12;
	public const ulong OEODGLNMCBD_FlagEventCollection =		(ulong)1 << 13;
	public const ulong PPNFOOBHMEG_FlagFreeScoreMax =			(ulong)1 << 14;
	public const ulong JIEPLLCMFHE_FlagEventQuest =				(ulong)1 << 15;
	public const ulong PKMKECJDLAM_FlagQuest =					(ulong)1 << 16;
	public const ulong HAMGADPNBAA_FlagCounter =				(ulong)1 << 17;
	public const ulong JBMCHKLNCGC_FlagEmblem =					(ulong)1 << 18;
	public const ulong CKOBOGAHLMF_FlagEventScore =				(ulong)1 << 19;
	public const ulong PCBFDLCJEPF_FlagAdventure =				(ulong)1 << 20;
	public const ulong FDBIJACKLGM_FlagEventBattle =			(ulong)1 << 21;
	public const ulong JBIPCHCGOIE_FlagEventBattlePlayer =		(ulong)1 << 22;
	public const ulong PDKNJNCKGMM_FlagPrism =					(ulong)1 << 23;
	public const ulong DHBHGGNAFKM_FlagShop =					(ulong)1 << 24;
	public const ulong KMEJNGBCFKJ_FlagEventMission =			(ulong)1 << 25;
	public const ulong EPBMNPFALJL_FlagEventSP =				(ulong)1 << 26;
	public const ulong ODFDKLMEEIH_FlagEventBoxGacha =			(ulong)1 << 27;
	public const ulong LJKHDGEBLOP_FlagTicket =					(ulong)1 << 28;
	public const ulong GEPGLHIDGIL_FlagArMarker =				(ulong)1 << 29;
	public const ulong MDBDPNPAPFM_FlagEventAprilFool =			(ulong)1 << 30;
	public const ulong PJHDPCCMDHL_FlagOffer =					(ulong)1 << 31;
	public const ulong NNFCMAGCMMB_FlagMonthlyPass =			(ulong)1 << 32;
	public const ulong EIPGBIKOPKI_FlagRareUpItem =				(ulong)1 << 33;
	public const ulong AODFOPOJDEM_FlagLimitedItem =			(ulong)1 << 34;
	public const ulong KFGIEBKDCHM_FlagSaveHash =				(ulong)1 << 35;
	public const ulong EFKHPIFNKIM_FlagBingo =					(ulong)1 << 36;
	public const ulong MFHGLPDLDKG_FlagEventRaid =				(ulong)1 << 37;
	public const ulong OBIPEOCMCLN_FlagEventRaidLobby =			(ulong)1 << 38;
	public const ulong JLNKIFEPCHF_flagEventRaidPlayer =		(ulong)1 << 39;
	public const ulong CAHKIGMKMGB_FlagDecoPublicSet =			(ulong)1 << 40;
	public const ulong NAHJFAEAAIN_FlagDecoPrivateSet =			(ulong)1 << 41;
	public const ulong DDOOENPDKHL_FlagDecoItem =				(ulong)1 << 42;
	public const ulong FNHALPEHDDE_FlagFavoritePlayer =			(ulong)1 << 43;
	public const ulong ONLEANFPHOP_FlagDecoStamp =				(ulong)1 << 44;
	public const ulong JCNHGMBKIKL_FlagDecoPublicInfo =			(ulong)1 << 45;
	public const ulong CCPOCEMCOGA_FlagDecoVisit =				(ulong)1 << 46;
	public const ulong EMNLNBNMBAN_FlagAssistPlate =			(ulong)1 << 47;
	public const ulong LFKFBJCNDMI_FlagLimitedCompoItem =		(ulong)1 << 48;
	public const ulong PKBEAMEMNNA_FlagUnitGoDiva =				(ulong)1 << 49;
	public const ulong EBEMNGJHLBO_FlagEventGoDiva =			(ulong)1 << 50;
	public const ulong HMBMFBEOLGP_FlagAddMusic =				(ulong)1 << 51;
	public const ulong FCOIEIKLEIC_FlagGachaLimit =				(ulong)1 << CDBDHHBOBNI_GachaLimit;
	public static string[] OHNJJIMGKGK_Names = new string[53] {"base", "common", "public_status", "alldata", "diva", "record_music", "scene", "story_record",
														"unit", "costume", "episode", "valkyrie", "sns", "event_collection", "free_score_max", "event_quest",
														"quest", "counter", "emblem", "event_score", "adventure", "event_battle", "event_battle_player",
														"prism", "shop", "event_mission", "event_sp", "event_box_gacha", "ticket", "ar_marker", "event_april_fool",
														"offer", "monthly_pass", "rareup_item", "limited_item", "save_hash", "bingo", "event_raid", "event_raid_lobby", 
														"event_raid_player", "deco_public_set", "deco_private_set","deco_item", "favorite_player", "deco_stamp",
														"deco_public_info", "deco_visit", "assist_plate", "limited_compo_item", "unit_godiva", "event_godiva", 
														"add_music", "gacha_limit"}; // 0x4
	public static byte OLMMLIJLNLA; // 0x8
	public const ulong GAAEFILMAED = 8968715810897911; // 0x1FDCFFDFFFFFF7
	public const ulong HALKDHEGEDF_DefaultBlockLoad = 7841852784336887; // 0x1bdc1fa1975ff7
	public const ulong LMPDECPOEOA = 5;
	public const ulong COGCOLEJAKK = 16389;
	public const ulong DBBGFKKHGOA = 16391;
	public const ulong ICEMOLCMHGG = 1;
	private int BFACFIBJBPA; // 0xDC
	public long MCKEOKFMLAH; // 0xE0
	// private KIJECNFNNDB LAFGAPBDKML = new KIJECNFNNDB(); // 0xE8
	public List<KLFDBFMNLBL_ServerSaveBlock> MGJKEJHEBPO_Blocks; // 0xEC
	private static Dictionary<ulong, FFECIIHJDJA_CreateBlockDelegate> BGEJFKHOMOC_CreateFuncs; // 0xC
	public static readonly int FBFCCLFFIAF = 1; // 0x10
	private static int[] GHJIPAFCBNN = new int[12] {0x1, 0xd, 0xf, 0x14, 0x61, 0x64, 0x66, 0x6a, 0x25, 0x28, 0x29, 0x2f}; // 0x14
	private static int[] MABKCDEOOMC = new int[4] {1, 2, 4, 9}; // 0x18

	public JBMPOAAMGNB_Base JHFIPCIHJNL_Base { get; private set; } // 0xC KMGGEBHHBAA ECLNKICNLBG LBHPNACEDGL
	public EGOLBAPFHHD_Common KCCLEHLLOFG_Common { get; private set; } // 0x10 EGGBCKDPNNP ELICAAHFMOE MCEPFJGMKGK
	public JNMFKOHFAFB_PublicStatus MHEAEGMIKIE_PublicStatus { get; private set; } // 0x14 IPIDNJLGHHA IOINJEBJGAL BGIFNFCAEDH
	public DEKKMGAFJCG_Diva DGCJCAHIAPP_Diva { get; private set; } // 0x18 MKBNAHMKHDN POLMIBFALBJ DHNJHLEPDKD
	public JDDGGJCGOPA_RecordMusic LCKMBHDMPIP_RecordMusic { get; private set; } // 0x1C NPEKNMGCGLO ODDNMAACGHL ANPGADGAIJD
	public MMPBPOIFDAF_Scene PNLOINMCCKH_Scene { get; private set; } // 0x20 LFEPLGDPHNN HEDHDEBCDHK AKJNMANOAOK
	public NEKDCJKANAH_StoryRecord LNOOKHJBENO_StoryRecord { get; private set; } // 0x24 BFKBGNOEDIK OEINGEBANNH DIFDDCMHIID
	public FKNOCGCODBK_Unit MLAFAACKKBG_Unit { get; private set; } // 0x28 OAIPEIDEOCO GFMBIMHMNJA MAKNCHHIOKF
	public CEDOOHCPHMG_UnitGoDiva KMBJGAHCBDI_UnitGoDiva { get; private set; } // 0x2C LFCFLKOPGJI MKOMCOGEKDH OLGDMANGPPF
	public EBFLJMOCLNA_Costume BEKHNNCGIEL_Costume { get; private set; } // 0x30 PIAGLBICDHH APEFIJHBGMD AHMKJHKMCEH
	public OCLHKHAMDHF_Episode NGHJPEIKLJL_Episode { get; private set; } // 0x34 NNHADBEPECA AJKOCPKDMEJ BJAOICEINFJ
	public OIGEIIGKMNH_Valkyrie JJFFBDLIOCF_Valkyrie { get; private set; } // 0x38 KHBLHGGNPPM BLDKFABPKAE JCMIADNDCNP
	public DDEMMEPBOIA_Sns FLHMJHBOBEA_Sns { get; private set; } // 0x3C NJAJCMECMFE OOCEKNJPKHO BDPKHAHGDKL
	public FJGNPNFLHPH_EventCollection MBAHCFLBDHN_EventCollection { get; private set; } // 0x40 KMAOEHJPMLI KEFOMFIIMDJ DNGHKPCPHNJ
	public ICLNENNIMOP_FreeScoreMax FLBPFBFKBFC_FreeScoreMax { get; private set; } // 0x44 FGDKNELIAAN EEHIJENEHCF CHDOPAGKCOL
	public OFNLIBDEIFA_EventQuest PMMENILLJJE_EventQuest { get; private set; } // 0x48 LGCHDHAPJFL GPDAOMBGNFN KNMKHIGHECF
	public ODPNBADOFAN_Quest GOACJBOCLHH_Quest { get; private set; } // 0x4C ACLKEFBFCBN PLPJHOEFENP FKNHKIFCKAA
	public FNBIIGJJGKA_Counter OEKEIGFAIGN_Counter { get; private set; } // 0x50 NLNIOJAGHPL NLJLKCCAHGI IAJEENLGCJP
	public JGGLDGNKELI_Emblem OFAJDLJBMEM_Emblem { get; private set; } // 0x54 EJCLCEBBHBE NDABDADDKDA NICDJPPNPGC
	public FEHINJKHDAP_EventScore KOOKJBMGBIG_EventScore { get; private set; } // 0x58 DOCFMEIIABM GMKPFEBBMDE NHMCGBAOHID
	public HHDEBNFMIMH_Adventure HBPPNFHOMNB_Adventure { get; private set; } // 0x5C LLKJCKINCGM AHKKNEFOCCO HFACFDNLMDP
	public CCPKHBECNLH_EventBattle DKJBALDICBG_EventBattle { get; private set; } // 0x60 EMHKFNHLLJJ JMGALBBLDBB KPMJAFNCECF
	public BMIODFJCGAJ_EventBattlePlayer HIIJOEHDAIM_EventBattlePlayer { get; private set; } // 0x64 EJBIJABPPLM HKKPOJFIIJI ABACLCPJALH
	public NPOOPJIOMHF_Prism GHDDPJBBEOC_Prism { get; private set; } // 0x68 IPLNONELJJO FOCMCJMNHBC MBNICBKCALO
	public GBEFGAIGGHA_Shop IJOHDAJMBAL_Shop { get; private set; } // 0x6C KFBIDKLIFEA PNMELHHBKNG HOABHLGHPJP
	public OKLMJPBJHKL_EventMission MENGHOKMOIE_EventMission { get; private set; } // 0x70 FNEDOHPFJOM LFCCLOCCAEL IOGJIHCKLHG
	public JLOGEHCIBEJ_EventRaid DMDOCAPGOEE_EventRaid { get; private set; } // 0x74 DJKNMDDAHEG NIMPKJELABG ADECIAGKKJK
	public KBAGKBIBGPM_EventRaidLobby PJCMHDEJLGF_EventRaidLobby { get; private set; } // 0x78 ALKIMKOGGEC GIBODAGJAGA KHOKBAJEBHH
	public LGGPBMPINDL_EventRaidPlayer LLBECHBNIJG_EventRaidPlayer { get; private set; } // 0x7C NFMKIALGGHG KHNGHBIJICI JMIMDMKJHBG
	public NILOACEHJKJ_EventSP DAKCBBBMIMD_EventSP { get; private set; } // 0x80 BOHHFHHDJEB GDFFALBANKM CNNEEJHHHEH
	public ALIPBIMCAPN_EventBoxGacha MMAIJOCPJHP_EventBoxGacha { get; private set; } // 0x84 MAEOOANOPHD PGKAACOJJHH CBLMKMMCHLC
	public GGHPEFNADEN_Ticket CNCBDLFALLD_Ticket { get; private set; } // 0x88 GGLJAIGKBBG NJPCFNMCNLG ELMMACMBPIH
	public KDLBHAKPLPH_ArMarker LCLPLFCBDBB_ArMarker { get; private set; } // 0x8C ILAJMJPAODD BDJFFEOBFCH JDHEOHNPIDF
	public FMFBNHLMHPL_EventAprilFool ILINBDKMAPM_EventAprilFool { get; private set; } // 0x90 OGLGBMBBIFE AAIDDCJILPI BILCKHILOHN
	public OCMJNBIFJNM_Offer DAEJHMCMFJD_Offer { get; private set; } // 0x94 EGIAFFAECNM OGALHJNMMNL GEMOMLNAADD
	public LGIDLHLBFFJ_MonthlyPass HMMNDKHKEBC_MonthlyPass { get; private set; } // 0x98 HBPDMEDPANM HPNJLDMMLOP GAEOOJAIHJC
	public LGIOGDIPNGI_RareUpItem DPNKPPBEAGJ_RareUpItem { get; private set; } // 0x9C MMANMDKOCIH PHMKDJBPODJ FDHJGFNNJID
	public LIFGJMIHHKM_LimitedItem AFHFIPLOKMN_LimitedItem { get; private set; } // 0xA0 MABLGJEDAAO GEHCLAGHAKB LLCKLEHDGJM
	public FFMIPGABHHA_SaveHash FHLMCCPCEAI_SaveHash { get; private set; } // 0xA4 AJPJGBAIBCD MIFLPDHAFEG NGGLLCCMKNN
	 public NFMHCLHEMHB_Bingo PEGNNEFHDOP_Bingo { get; private set; } // 0xA8 DMOGGMEFGII CAJIJHHMOMG MOOKFNFALPJ
	 public DAJBODHMLAB_DecoPublicSet PDKHANKAPCI_DecoPublicSet { get; private set; } // 0xAC GJHOEAFCNDA KGBNBKPMKDG PJNPGHDEINA
	 public AHHPBMBBCFM_DecoPrivateSet DNIPIBICFGN_DecoPrivateSet { get; private set; } // 0xB0 MJMPPFHOLPG CLOJDOMJNGL NJDJFEAIEFJ
	 public BCGFHLIEKLJ_DecoItem OMMNKDEODJP_DecoItem { get; private set; } // 0xB4 NDKFLJOCAKH AFEJALGJLCG GCPCAAKJLMA
	 public LFHGFLJLGFB_FavoritePlayer GAAOPEGIPKA_FavoritePlayer { get; private set; } // 0xB8 LGPCFAGCFEI EPJOMHAEOCJ HOHLEKKNGON
	 public IOEKHJBOMDH_DecoStamp FJPOELGFPBP_DecoStamp { get; private set; } // 0xBC DNHOMJCGDIK JKCCNNCNIMK HHILGOLHGEG
	 public PKLLAKCBPAH_DecoPublicInfo OBDEIEHEPHC_DecoPublicInfo { get; private set; } // 0xC0 MNALFNMMGEP EBKBEKJHFKJ EDJENHFLPCC
	 public FNCFHIEELGO_DecoVisit AJOFHCPLLLC_DecoVisit { get; private set; } // 0xC4 FFAMGKJMGFN OAOLALOEIFA AJPKMCCCLJC
	 public MKNIBACMCDO_AssistPlate IGNHLKEMJND_AssistPlate { get; private set; } // 0xC8 DIIANAANOBE GGOHHKFJDCJ ENNNCECDONF
	 public GEGHOCKCKKA_LimitedCompoItem GJCOJBDOOJG_LimitedCompoItem { get; private set; } // 0xCC CMLGLHKJLNF KJJJCFABPEH GKEHKPEGILD
	 public CCBMJNPFPBB_EventGoDiva JMPNGBGNCFO_EventGoDiva { get; private set; } // 0xD0 LOLEIHDFOKP BDMCKFAEPIK NBGJMKCEIOI
	 public BAHFBCEPFGP_AddMusic MMGKPCIOHHC_AddMusic { get; private set; } // 0xD4 NIGNJMGNLIK CPFOEMJFADP JDGDGLJPMHP
	 public EAOHMJHHDKN_GachaLimit APFILEMHEPG_GachaLimit { get; private set; } // 0xD8 AHEKEIBBGEK MJKGKBMIEAF CFHDNDLAEMO
	// public int ABPOMNOIKDA { get; set; } // NMDJOKGPIOA 0xF1C03C NPALOAPEPAC 0xF1C050

	// // RVA: 0xF1BAEC Offset: 0xF1BAEC VA: 0xF1BAEC
	private ulong BCJKHLAOLAP_GetLoadFlags(OKGLGHCBCJP_Database NDFIEMPPMLF)
	{
		ulong val = HALKDHEGEDF_DefaultBlockLoad;
		if(NDFIEMPPMLF != null)
		{
			for(int i = 0; i < NDFIEMPPMLF.NDLAAACJOLP.Count; i++)
			{
				switch(NDFIEMPPMLF.NDLAAACJOLP[i]) 
				{
					case /*0x18*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.OBEAIJOHOAJ_EventAprilFoolA:
					case /*0x19*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.GCEPOPPDPOC_EventAprilFoolB:
					case /*0x1a*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.EMOOIGBGHLG_EventAprilFoolC:
					case /*0x1b*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.AEGNEIOAOKI_EventAprilFoolD:
					case /*0x1c*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.KNNGKODFAGC_EventAprilFoolE:
					case /*0x1d*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.AFGGHHOHILP_EventAprilFoolF:
					case /*0x1e*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.EICBLKBKMKE_EventAprilFoolG:
					case /*0x1f*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.FIKPHDFLIIM_EventAprilFoolH:
					case /*0x20*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.FNLCLINDJAF_EventAprilFoolI:
						val = val | /*0x40000000*/CFEFDIPHOIA_EventAprilFool;
					break;
					case /*0x21*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.IEICONEHLFE_EventBattleA:
					case /*0x22*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.CJLAEPKNNJE_EventBattleB:
					case /*0x23*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.MPCNKNCKBAE_EventBattleC:
						val = val | /*0x600000*/ JMKKPDNEOMC_EventBattle | IKBDIKPCKOG_EventBattlePlayer;
					break;
					case /*0x24*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.COFHBPGDPML_EventBoxGachaA:
					case /*0x25*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.BHJGBPLKMBK_EventBoxGachaB:
					case /*0x26*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.AHDKIFOPEHM_EventBoxGachaC:
					case /*0x27*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.LLEDCLGDDCD_EventBoxGachaD:
					case /*0x28*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.ACNPHHGCHAF_EventBoxGachaE:
					case /*0x29*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.FEICGBHOIPB_EventBoxGachaF:
						val = val | /*0x8000000*/ GIKKNKGJBDJ_EventBoxGacha;
					break;
					case /*0x2a*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.OAOKLHCDPON_EventCollectionA:
					case /*0x2b*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.GGKFEJFMNGP_EventCollectionB:
					case /*0x2c*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.LLHBBEMKIGD_EventCollectionC:
						val = val | /*0x2000*/NCKGBJOMPIB_EventCollection;
					break;
					case /*0x2e*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.MBMNNEODFFP_EventGoDivaA:
					case /*0x2f*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.NLIBPDOHAPH_EventGoDivaB:
					case /*0x30*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.JLGODHLEBMK_EventGoDivaC:
						val = val | /*0x4000000000000*/AICNPGADBCE_EventGoDiva;
					break;
					case /*0x33*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.DCBIDPBJHOC_EventMissionA:
					case /*0x34*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.BNCLLKEHEFH_EventMissionB:
					case /*0x35*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.BDGKKLAAJJB_EventMissionC:
						val = val | /*0x2000000*/GIMPPHEENJI_EventMission;
					break;
					case /*0x36*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.CLKOFJKPPEP_EventPresentCampaignA:
						val = val | /*0x10000000*/GGHMGCGLDIF_Ticket;
					break;
					case /*0x37*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.DCEHHGDDBPP_EventRaidA:
					case /*0x38*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.PLNOKLOLJEP_EventRaidB:
					case /*0x39*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.IJEIEHHAJNM_EventRaidC:
					case /*0x3a*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.DMKFEJGOELJ_EventRaidD:
						val = val | /*0x2000000000*/FENLNECLOON_EventRaid;
					break;
					case /*0x3b*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.IEBPINPALBD_EventRaidLobbyA:
					case /*0x3c*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.CHNHFHCEKGN_EventRaidLobbyB:
					case /*0x3d*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.FCAJCEOCDFF_EventRaidLobbyC:
					case /*0x3e*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.IJOLIEAOOJC_EventRaidLobbyD:
						val = val | /*0xc000000000*/ANNJOIOHDKJ_EventRaidLobby | MOOLMJMBMGB_EventRaidPlayer;
					break;
					case /*0x43*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.FMHLCBNFAOC_EventScoreA:
					case /*0x44*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.LCJACACCKFC_EventScoreB:
					case /*0x45*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.BPOFGIDPMBF_EventScoreC:
					case /*0x46*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.JPNKKKOHHLG_EventScoreD:
					case /*0x47*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.ECHHEGJOHGI_EventScoreE:
					case /*0x48*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.NLDGAHCIPAE_EventScoreF:
						val = val | /*0x80000*/GEEOAMAMBHI_EventScore;
					break;
					case /*0x49*/OKGLGHCBCJP_Database.BEOKNKGHFFE_Section.MHGPKDOPEDJ_EventSpA:
						val = val | /*0x4000000*/GONHNMGEOGC_EventSP;
					break;
					default:
					break;
				}
			}
		}
		return val;
	}

	// // RVA: 0xF1C064 Offset: 0xF1C064 VA: 0xF1C064
	public List<string> KPIDBPEKMFD_GetBlockList()
	{
		List<string> res = new List<string>(MGJKEJHEBPO_Blocks.Count);
		for(int i = 0; i < MGJKEJHEBPO_Blocks.Count; i++)
		{
			res.Add(MGJKEJHEBPO_Blocks[i].JIKKNHIAEKG_BlockName);
		}
		return res;
	}

	// // RVA: 0xF1C1E0 Offset: 0xF1C1E0 VA: 0xF1C1E0
	// public static List<string> KPIDBPEKMFD(ulong MKDDOJOADMF) { }

	// // RVA: 0xF1C428 Offset: 0xF1C428 VA: 0xF1C428
	public KLFDBFMNLBL_ServerSaveBlock LBDOLHGDIEB_GetBlock(string OPFGFINHFCE)
	{
		return MGJKEJHEBPO_Blocks.Find((KLFDBFMNLBL_ServerSaveBlock PKLPKMLGFGK) => {
			//0xF2AB28
			return PKLPKMLGFGK.JIKKNHIAEKG_BlockName == OPFGFINHFCE;
		});
	}

	// // RVA: -1 Offset: -1
	// public T LBDOLHGDIEB<T>(string OPFGFINHFCE) { }
	// /* GenericInstMethod :
	// |
	// |-RVA: 0x1AB5360 Offset: 0x1AB5360 VA: 0x1AB5360
	// |-BBHNACPENDM.LBDOLHGDIEB<object>
	// */

	// // RVA: 0xF1C528 Offset: 0xF1C528 VA: 0xF1C528
	public void KHEKNNFCAOI_Init(OKGLGHCBCJP_Database NKEBMCIMJND)
	{
		KHEKNNFCAOI_Init(BCJKHLAOLAP_GetLoadFlags(NKEBMCIMJND));
	}

	// // RVA: 0xF1F2AC Offset: 0xF1F2AC VA: 0xF1F2AC
	public void EBKCPELHDKN_InitWithBaseAndPublicStatus()
	{
		KHEKNNFCAOI_Init(/*5*/EFBHIFFOKAB_FlagBase | NBCOGOPBDAB_FlagPublicStatus);
	}

	// // RVA: 0xF1F2CC Offset: 0xF1F2CC VA: 0xF1F2CC
	// public void LKBHDMOBOGN() { }

	// // RVA: 0xF1F2EC Offset: 0xF1F2EC VA: 0xF1F2EC
	// public void PGPNDIHDIOD() { }

	// // RVA: 0xF1F30C Offset: 0xF1F30C VA: 0xF1F30C
	// public void PNHOEMIMCGC() { }

	// // RVA: 0xF1F330 Offset: 0xF1F330 VA: 0xF1F330
	// public void CAKOEJHBIHF() { }

	// // RVA: 0xF1F350 Offset: 0xF1F350 VA: 0xF1F350
	// public void GGBOGLKKKDM() { }

	// // RVA: 0xF1F370 Offset: 0xF1F370 VA: 0xF1F370
	// public void HIJAFAIOLIL() { }

	// // RVA: 0xF1C554 Offset: 0xF1C554 VA: 0xF1C554
	public void KHEKNNFCAOI_Init(ulong HGNJJBLEMPH)
	{
		MCKEOKFMLAH = 0;
		MGJKEJHEBPO_Blocks = new List<KLFDBFMNLBL_ServerSaveBlock>();
		if((HGNJJBLEMPH & EFBHIFFOKAB_FlagBase) != 0)					{ JHFIPCIHJNL_Base = (JBMPOAAMGNB_Base)MNMFKKKFDCL_NewBlock(CFDJGBNJMIM_Base); MGJKEJHEBPO_Blocks.Add(JHFIPCIHJNL_Base); }
		if((HGNJJBLEMPH & MLGABKNBICG_FlagCommon) != 0)					{ KCCLEHLLOFG_Common = (EGOLBAPFHHD_Common)MNMFKKKFDCL_NewBlock(IGCDFADKKML_Common); MGJKEJHEBPO_Blocks.Add(KCCLEHLLOFG_Common); }
		if((HGNJJBLEMPH & NBCOGOPBDAB_FlagPublicStatus) != 0)			{ MHEAEGMIKIE_PublicStatus = (JNMFKOHFAFB_PublicStatus)MNMFKKKFDCL_NewBlock(FCMMJOJINDN_PublicStatus); MGJKEJHEBPO_Blocks.Add(MHEAEGMIKIE_PublicStatus); }
		if((HGNJJBLEMPH & ELHAENACNGM_FlagDiva) != 0)					{ DGCJCAHIAPP_Diva = (DEKKMGAFJCG_Diva)MNMFKKKFDCL_NewBlock(AAMNIFDPNLB_Diva); MGJKEJHEBPO_Blocks.Add(DGCJCAHIAPP_Diva); }
		if((HGNJJBLEMPH & MKBNHHNIHPG_FlagRecordMusic) != 0)			{ LCKMBHDMPIP_RecordMusic = (JDDGGJCGOPA_RecordMusic)MNMFKKKFDCL_NewBlock(FKFMFFHOAIA_RecordMusic); MGJKEJHEBPO_Blocks.Add(LCKMBHDMPIP_RecordMusic); }
		if((HGNJJBLEMPH & KFEKIEABCCB_FlagScene) != 0)					{ PNLOINMCCKH_Scene = (MMPBPOIFDAF_Scene)MNMFKKKFDCL_NewBlock(PKCGBBNGJPO_Scene); MGJKEJHEBPO_Blocks.Add(PNLOINMCCKH_Scene); }
		if((HGNJJBLEMPH & PEKKJODOMBE_FlagStoryRecord) != 0)			{ LNOOKHJBENO_StoryRecord = (NEKDCJKANAH_StoryRecord)MNMFKKKFDCL_NewBlock(HOPCNPLPEKE_StoryRecord); MGJKEJHEBPO_Blocks.Add(LNOOKHJBENO_StoryRecord); }
		if ((HGNJJBLEMPH & NCIIFBPCHJP_FlagUnit) != 0)					{ MLAFAACKKBG_Unit = (FKNOCGCODBK_Unit)MNMFKKKFDCL_NewBlock(MKPMBBAECPA_Unit); MGJKEJHEBPO_Blocks.Add(MLAFAACKKBG_Unit); }
		if((HGNJJBLEMPH & NPBDBMFHLLA_FlagCostume) != 0)				{ BEKHNNCGIEL_Costume = (EBFLJMOCLNA_Costume)MNMFKKKFDCL_NewBlock(PGPHCJNGDMM_Costume); MGJKEJHEBPO_Blocks.Add(BEKHNNCGIEL_Costume); }
		if((HGNJJBLEMPH & LFOLAAANHFO_FlagEpisode) != 0)				{ NGHJPEIKLJL_Episode = (OCLHKHAMDHF_Episode)MNMFKKKFDCL_NewBlock(EFEJOKPJEEN_Episode); MGJKEJHEBPO_Blocks.Add(NGHJPEIKLJL_Episode); }
		if((HGNJJBLEMPH & GNKACAJCGAG_FlagValkyrie) != 0)				{ JJFFBDLIOCF_Valkyrie = (OIGEIIGKMNH_Valkyrie)MNMFKKKFDCL_NewBlock(DMIGNJMIEEJ_Valkyrie); MGJKEJHEBPO_Blocks.Add(JJFFBDLIOCF_Valkyrie); }
		if((HGNJJBLEMPH & ILAPIDMOMOP_FlagSns) != 0)					{ FLHMJHBOBEA_Sns = (DDEMMEPBOIA_Sns)MNMFKKKFDCL_NewBlock(IOKHNFIJAIM_Sns); MGJKEJHEBPO_Blocks.Add(FLHMJHBOBEA_Sns); }
		if ((HGNJJBLEMPH & OEODGLNMCBD_FlagEventCollection) != 0)		{ MBAHCFLBDHN_EventCollection = (FJGNPNFLHPH_EventCollection)MNMFKKKFDCL_NewBlock(NCKGBJOMPIB_EventCollection); MGJKEJHEBPO_Blocks.Add(MBAHCFLBDHN_EventCollection); }
		if((HGNJJBLEMPH & PPNFOOBHMEG_FlagFreeScoreMax) != 0)			{ FLBPFBFKBFC_FreeScoreMax = (ICLNENNIMOP_FreeScoreMax)MNMFKKKFDCL_NewBlock(EAGPNDEDLFI_FreeScoreMax); MGJKEJHEBPO_Blocks.Add(FLBPFBFKBFC_FreeScoreMax); }
		if((HGNJJBLEMPH & JIEPLLCMFHE_FlagEventQuest) != 0)				{ PMMENILLJJE_EventQuest = (OFNLIBDEIFA_EventQuest)MNMFKKKFDCL_NewBlock(JMBDPGJFOAK_EventQuest); MGJKEJHEBPO_Blocks.Add(PMMENILLJJE_EventQuest); }
		if((HGNJJBLEMPH & PKMKECJDLAM_FlagQuest) != 0)					{ GOACJBOCLHH_Quest = (ODPNBADOFAN_Quest)MNMFKKKFDCL_NewBlock(NJCDKKADEOM_Quest); MGJKEJHEBPO_Blocks.Add(GOACJBOCLHH_Quest); }
		if((HGNJJBLEMPH & HAMGADPNBAA_FlagCounter) != 0)				{ OEKEIGFAIGN_Counter = (FNBIIGJJGKA_Counter)MNMFKKKFDCL_NewBlock(AELKBIDPIEH_Counter); MGJKEJHEBPO_Blocks.Add(OEKEIGFAIGN_Counter); }
		if((HGNJJBLEMPH & JBMCHKLNCGC_FlagEmblem) != 0)					{ OFAJDLJBMEM_Emblem = (JGGLDGNKELI_Emblem)MNMFKKKFDCL_NewBlock(LEDKALJFJOL_Emblem); MGJKEJHEBPO_Blocks.Add(OFAJDLJBMEM_Emblem); }
		if((HGNJJBLEMPH & CKOBOGAHLMF_FlagEventScore) != 0)				{ KOOKJBMGBIG_EventScore = (FEHINJKHDAP_EventScore)MNMFKKKFDCL_NewBlock(GEEOAMAMBHI_EventScore); MGJKEJHEBPO_Blocks.Add(KOOKJBMGBIG_EventScore); }
		if((HGNJJBLEMPH & PCBFDLCJEPF_FlagAdventure) != 0)				{ HBPPNFHOMNB_Adventure = (HHDEBNFMIMH_Adventure)MNMFKKKFDCL_NewBlock(AECIGBCCHPA_Adventure); MGJKEJHEBPO_Blocks.Add(HBPPNFHOMNB_Adventure); }
		if((HGNJJBLEMPH & FDBIJACKLGM_FlagEventBattle) != 0)			{ DKJBALDICBG_EventBattle = (CCPKHBECNLH_EventBattle)MNMFKKKFDCL_NewBlock(JMKKPDNEOMC_EventBattle); MGJKEJHEBPO_Blocks.Add(DKJBALDICBG_EventBattle); }
		if((HGNJJBLEMPH & JBIPCHCGOIE_FlagEventBattlePlayer) != 0)		{ HIIJOEHDAIM_EventBattlePlayer = (BMIODFJCGAJ_EventBattlePlayer)MNMFKKKFDCL_NewBlock(IKBDIKPCKOG_EventBattlePlayer); MGJKEJHEBPO_Blocks.Add(HIIJOEHDAIM_EventBattlePlayer); }
		if ((HGNJJBLEMPH & PDKNJNCKGMM_FlagPrism) != 0)					{ GHDDPJBBEOC_Prism = (NPOOPJIOMHF_Prism)MNMFKKKFDCL_NewBlock(FKBACFGLNLB_Prism); MGJKEJHEBPO_Blocks.Add(GHDDPJBBEOC_Prism); }
		if((HGNJJBLEMPH & DHBHGGNAFKM_FlagShop) != 0)					{ IJOHDAJMBAL_Shop = (GBEFGAIGGHA_Shop)MNMFKKKFDCL_NewBlock(LDNKKDBABFD_Shop); MGJKEJHEBPO_Blocks.Add(IJOHDAJMBAL_Shop); }
		if((HGNJJBLEMPH & KMEJNGBCFKJ_FlagEventMission) != 0)			{ MENGHOKMOIE_EventMission = (OKLMJPBJHKL_EventMission)MNMFKKKFDCL_NewBlock(GIMPPHEENJI_EventMission); MGJKEJHEBPO_Blocks.Add(MENGHOKMOIE_EventMission); }
		if((HGNJJBLEMPH & EPBMNPFALJL_FlagEventSP) != 0)				{ DAKCBBBMIMD_EventSP = (NILOACEHJKJ_EventSP)MNMFKKKFDCL_NewBlock(GONHNMGEOGC_EventSP); MGJKEJHEBPO_Blocks.Add(DAKCBBBMIMD_EventSP); }
		if((HGNJJBLEMPH & ODFDKLMEEIH_FlagEventBoxGacha) != 0)			{ MMAIJOCPJHP_EventBoxGacha = (ALIPBIMCAPN_EventBoxGacha)MNMFKKKFDCL_NewBlock(GIKKNKGJBDJ_EventBoxGacha); MGJKEJHEBPO_Blocks.Add(MMAIJOCPJHP_EventBoxGacha); }
		if((HGNJJBLEMPH & LJKHDGEBLOP_FlagTicket) != 0)					{ CNCBDLFALLD_Ticket = (GGHPEFNADEN_Ticket)MNMFKKKFDCL_NewBlock(GGHMGCGLDIF_Ticket); MGJKEJHEBPO_Blocks.Add(CNCBDLFALLD_Ticket); }
		if((HGNJJBLEMPH & GEPGLHIDGIL_FlagArMarker) != 0)				{ LCLPLFCBDBB_ArMarker = (KDLBHAKPLPH_ArMarker)MNMFKKKFDCL_NewBlock(FBDIFLDJDMH_ArMarker); MGJKEJHEBPO_Blocks.Add(LCLPLFCBDBB_ArMarker); }
		if((HGNJJBLEMPH & MDBDPNPAPFM_FlagEventAprilFool) != 0)			{ ILINBDKMAPM_EventAprilFool = (FMFBNHLMHPL_EventAprilFool)MNMFKKKFDCL_NewBlock(CFEFDIPHOIA_EventAprilFool); MGJKEJHEBPO_Blocks.Add(ILINBDKMAPM_EventAprilFool); }
		if ((HGNJJBLEMPH & PJHDPCCMDHL_FlagOffer) != 0)					{ DAEJHMCMFJD_Offer = (OCMJNBIFJNM_Offer)MNMFKKKFDCL_NewBlock(JGGKEOIOHHN_Offer); MGJKEJHEBPO_Blocks.Add(DAEJHMCMFJD_Offer); }
		if((HGNJJBLEMPH & NNFCMAGCMMB_FlagMonthlyPass) != 0)			{ HMMNDKHKEBC_MonthlyPass = (LGIDLHLBFFJ_MonthlyPass)MNMFKKKFDCL_NewBlock(ICJCEFCINFB_MonthlyPass); MGJKEJHEBPO_Blocks.Add(HMMNDKHKEBC_MonthlyPass); }
		if((HGNJJBLEMPH & EIPGBIKOPKI_FlagRareUpItem) != 0)				{ DPNKPPBEAGJ_RareUpItem = (LGIOGDIPNGI_RareUpItem)MNMFKKKFDCL_NewBlock(DAELEHFKOMC_RareUpItem); MGJKEJHEBPO_Blocks.Add(DPNKPPBEAGJ_RareUpItem); }
		if((HGNJJBLEMPH & AODFOPOJDEM_FlagLimitedItem) != 0)			{ AFHFIPLOKMN_LimitedItem = (LIFGJMIHHKM_LimitedItem)MNMFKKKFDCL_NewBlock(OEEEKEIIMAC_LimitedItem); MGJKEJHEBPO_Blocks.Add(AFHFIPLOKMN_LimitedItem); }
		if ((HGNJJBLEMPH & KFGIEBKDCHM_FlagSaveHash) != 0)				{ FHLMCCPCEAI_SaveHash = (FFMIPGABHHA_SaveHash)MNMFKKKFDCL_NewBlock(MNOIKPAPDMF_SaveHash); MGJKEJHEBPO_Blocks.Add(FHLMCCPCEAI_SaveHash); }
		if((HGNJJBLEMPH & EFKHPIFNKIM_FlagBingo) != 0)					{ PEGNNEFHDOP_Bingo = (NFMHCLHEMHB_Bingo)MNMFKKKFDCL_NewBlock(LBPMJOCELBC_Bingo); MGJKEJHEBPO_Blocks.Add(PEGNNEFHDOP_Bingo); }
		if((HGNJJBLEMPH & MFHGLPDLDKG_FlagEventRaid) != 0)				{ DMDOCAPGOEE_EventRaid = (JLOGEHCIBEJ_EventRaid)MNMFKKKFDCL_NewBlock(FENLNECLOON_EventRaid); MGJKEJHEBPO_Blocks.Add(DMDOCAPGOEE_EventRaid); }
		if((HGNJJBLEMPH & OBIPEOCMCLN_FlagEventRaidLobby) != 0)			{ PJCMHDEJLGF_EventRaidLobby = (KBAGKBIBGPM_EventRaidLobby)MNMFKKKFDCL_NewBlock(ANNJOIOHDKJ_EventRaidLobby); MGJKEJHEBPO_Blocks.Add(PJCMHDEJLGF_EventRaidLobby); }
		if((HGNJJBLEMPH & JLNKIFEPCHF_flagEventRaidPlayer) != 0)		{ LLBECHBNIJG_EventRaidPlayer = (LGGPBMPINDL_EventRaidPlayer)MNMFKKKFDCL_NewBlock(MOOLMJMBMGB_EventRaidPlayer); MGJKEJHEBPO_Blocks.Add(LLBECHBNIJG_EventRaidPlayer); }
		if((HGNJJBLEMPH & CAHKIGMKMGB_FlagDecoPublicSet) != 0)			{ PDKHANKAPCI_DecoPublicSet = (DAJBODHMLAB_DecoPublicSet)MNMFKKKFDCL_NewBlock(NEGNIBDPEEM_DecoPublicSet); MGJKEJHEBPO_Blocks.Add(PDKHANKAPCI_DecoPublicSet); }
		if((HGNJJBLEMPH & NAHJFAEAAIN_FlagDecoPrivateSet) != 0)			{ DNIPIBICFGN_DecoPrivateSet = (AHHPBMBBCFM_DecoPrivateSet)MNMFKKKFDCL_NewBlock(HFPPAGFAOJL_DecoPrivateSet); MGJKEJHEBPO_Blocks.Add(DNIPIBICFGN_DecoPrivateSet); }
		if((HGNJJBLEMPH & DDOOENPDKHL_FlagDecoItem) != 0)				{ OMMNKDEODJP_DecoItem = (BCGFHLIEKLJ_DecoItem)MNMFKKKFDCL_NewBlock(JONEDOPANFB_DecoItem); MGJKEJHEBPO_Blocks.Add(OMMNKDEODJP_DecoItem); }
		if((HGNJJBLEMPH & FNHALPEHDDE_FlagFavoritePlayer) != 0)			{ GAAOPEGIPKA_FavoritePlayer = (LFHGFLJLGFB_FavoritePlayer)MNMFKKKFDCL_NewBlock(ONOEAPIBPCN_FavoritePlayer); MGJKEJHEBPO_Blocks.Add(GAAOPEGIPKA_FavoritePlayer); }
		if((HGNJJBLEMPH & ONLEANFPHOP_FlagDecoStamp) != 0)				{ FJPOELGFPBP_DecoStamp = (IOEKHJBOMDH_DecoStamp)MNMFKKKFDCL_NewBlock(NCIDKAFLDDD_DecoStamp); MGJKEJHEBPO_Blocks.Add(FJPOELGFPBP_DecoStamp); }
		if((HGNJJBLEMPH & JCNHGMBKIKL_FlagDecoPublicInfo) != 0)			{ OBDEIEHEPHC_DecoPublicInfo = (PKLLAKCBPAH_DecoPublicInfo)MNMFKKKFDCL_NewBlock(MMOCEAIPJJE_DecoPublicInfo); MGJKEJHEBPO_Blocks.Add(OBDEIEHEPHC_DecoPublicInfo); }
		if((HGNJJBLEMPH & CCPOCEMCOGA_FlagDecoVisit) != 0)				{ AJOFHCPLLLC_DecoVisit = (FNCFHIEELGO_DecoVisit)MNMFKKKFDCL_NewBlock(LALMBEGKBIG_DecoVisit); MGJKEJHEBPO_Blocks.Add(AJOFHCPLLLC_DecoVisit); }
		if((HGNJJBLEMPH & EMNLNBNMBAN_FlagAssistPlate) != 0)			{ IGNHLKEMJND_AssistPlate = (MKNIBACMCDO_AssistPlate)MNMFKKKFDCL_NewBlock(LPGMJAHFOKI_AssistPlate); MGJKEJHEBPO_Blocks.Add(IGNHLKEMJND_AssistPlate); }
		if((HGNJJBLEMPH & LFKFBJCNDMI_FlagLimitedCompoItem) != 0)		{ GJCOJBDOOJG_LimitedCompoItem = (GEGHOCKCKKA_LimitedCompoItem)MNMFKKKFDCL_NewBlock(AOKLBOLKCEN_LimitedCompoItem); MGJKEJHEBPO_Blocks.Add(GJCOJBDOOJG_LimitedCompoItem); }
		if((HGNJJBLEMPH & PKBEAMEMNNA_FlagUnitGoDiva) != 0)				{ KMBJGAHCBDI_UnitGoDiva = (CEDOOHCPHMG_UnitGoDiva)MNMFKKKFDCL_NewBlock(PPEPINOOEMP_UnitGoDiva); MGJKEJHEBPO_Blocks.Add(KMBJGAHCBDI_UnitGoDiva); }
		if((HGNJJBLEMPH & EBEMNGJHLBO_FlagEventGoDiva) != 0)			{ JMPNGBGNCFO_EventGoDiva = (CCBMJNPFPBB_EventGoDiva)MNMFKKKFDCL_NewBlock(AICNPGADBCE_EventGoDiva); MGJKEJHEBPO_Blocks.Add(JMPNGBGNCFO_EventGoDiva); }
		if((HGNJJBLEMPH & HMBMFBEOLGP_FlagAddMusic) != 0)				{ MMGKPCIOHHC_AddMusic = (BAHFBCEPFGP_AddMusic)MNMFKKKFDCL_NewBlock(AHBBPFBHJFA_AddMusic); MGJKEJHEBPO_Blocks.Add(MMGKPCIOHHC_AddMusic); }
		if((HGNJJBLEMPH & FCOIEIKLEIC_FlagGachaLimit) != 0)				{ APFILEMHEPG_GachaLimit = (EAOHMJHHDKN_GachaLimit)MNMFKKKFDCL_NewBlock(CDBDHHBOBNI_GachaLimit); MGJKEJHEBPO_Blocks.Add(APFILEMHEPG_GachaLimit); }
	}

	// // RVA: 0xF1F390 Offset: 0xF1F390 VA: 0xF1F390
	private KLFDBFMNLBL_ServerSaveBlock MNMFKKKFDCL_NewBlock(ulong NEJBNCHLMNJ)
	{
		KLFDBFMNLBL_ServerSaveBlock data = null;
		if(BGEJFKHOMOC_CreateFuncs.ContainsKey(NEJBNCHLMNJ))
		{
			data = BGEJFKHOMOC_CreateFuncs[NEJBNCHLMNJ]();
			data.LHPDDGIJKNB_Reset();
			data.JIKKNHIAEKG_BlockName = OHNJJIMGKGK_Names[NEJBNCHLMNJ];
		}
		return data;
	}

	// // RVA: 0xF1FA34 Offset: 0xF1FA34 VA: 0xF1FA34
	public void ODDIHGPONFL_Copy(BBHNACPENDM_ServerSaveData GPBJHKLFCEP)
	{
		for(int i = 0; i < GPBJHKLFCEP.MGJKEJHEBPO_Blocks.Count; i++)
		{
			KLFDBFMNLBL_ServerSaveBlock block = MGJKEJHEBPO_Blocks.Find((KLFDBFMNLBL_ServerSaveBlock GHPLINIACBB) =>
			{
				//0xF2AB64
				return GHPLINIACBB.JIKKNHIAEKG_BlockName == GPBJHKLFCEP.MGJKEJHEBPO_Blocks[i].JIKKNHIAEKG_BlockName;
			});
			if(block != null)
			{
				block.ODDIHGPONFL_Copy(GPBJHKLFCEP.MGJKEJHEBPO_Blocks[i]);
				// tmp debug
				//if (!block.AGBOGBEOFME(GPBJHKLFCEP.MGJKEJHEBPO_Blocks[i]))
				//	UnityEngine.Debug.LogError("Error copying block "+ GPBJHKLFCEP.MGJKEJHEBPO_Blocks[i].JIKKNHIAEKG_BlockName);
			}
		}
	}

	// // RVA: 0xF1FC9C Offset: 0xF1FC9C VA: 0xF1FC9C
	public bool IIEMACPEEBJ_Load(List<string> ANFNAHPIJDH_BlockList, EDOHBJAPLPF_JsonData AAEDAEHIONI)
	{
		for(int i = 0; i < ANFNAHPIJDH_BlockList.Count; i++)
		{			
			// public string OPFGFINHFCE; // 0x8
			// // RVA: 0xF2AC60 Offset: 0xF2AC60 VA: 0xF2AC60
			// internal bool FIMLFIMCLIK(KLFDBFMNLBL PKLPKMLGFGK) { }
			string OPFGFINHFCE_Name = ANFNAHPIJDH_BlockList[i];
			KLFDBFMNLBL_ServerSaveBlock data = MGJKEJHEBPO_Blocks.Find((KLFDBFMNLBL_ServerSaveBlock PKLPKMLGFGK) => {
				//0xF2AC60
				return PKLPKMLGFGK.JIKKNHIAEKG_BlockName == OPFGFINHFCE_Name;
			});
			if(data != null && AAEDAEHIONI != null)
			{
				EDOHBJAPLPF_JsonData jsonData = AAEDAEHIONI[OPFGFINHFCE_Name];
				long save_id = 0;
				if(jsonData.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id/*save_id*/))
				{
					save_id = JsonUtil.GetLong(jsonData, AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id, 0);
				}
				data.FJMOAAPNCJI_SaveId = save_id;
				if(data.IIEMACPEEBJ_Deserialize(AAEDAEHIONI) == false)
				{
					UnityEngine.Debug.LogError("Failed to deserialize "+OPFGFINHFCE_Name+" wih data "+AAEDAEHIONI[OPFGFINHFCE_Name].EJCOJCGIBNG_ToJson());
					return false;
				}
				data.LLBJFFFJEPJ_Deseralized = true;
				if(!jsonData.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id/*save_id*/))
				{
					data.KFKDMBPNLJK_BlockInvalid = true;
				}
				else
				{
					save_id = JsonUtil.GetLong(jsonData, AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id, 0);
					if(MCKEOKFMLAH < save_id)
						MCKEOKFMLAH = save_id;
				}
			}
		}
		return true;
	}

	// // RVA: 0xF202A4 Offset: 0xF202A4 VA: 0xF202A4
	// public BBHNACPENDM.EMHDCKMFCGE IMMANCAIDLP() { }

	// // RVA: 0xF20570 Offset: 0xF20570 VA: 0xF20570
	public EMHDCKMFCGE LEMFJICBALP(BBHNACPENDM_ServerSaveData GJLFANGDGCL, bool NNPGPAPDDMC = true)
	{
		if (MGJKEJHEBPO_Blocks == null)
			return null;
		List<int> l1 = new List<int>();
		List<string> l2 = new List<string>();
		for(int i = 0; i < MGJKEJHEBPO_Blocks.Count; i++)
		{
			if(MGJKEJHEBPO_Blocks[i] != null)
			{
				if(!MGJKEJHEBPO_Blocks[i].KFKDMBPNLJK_BlockInvalid)
				{
					if (MGJKEJHEBPO_Blocks[i].AGBOGBEOFME(GJLFANGDGCL.MGJKEJHEBPO_Blocks[i]))
						continue;
				}
				bool b = MGJKEJHEBPO_Blocks[i].DMICHEJIAJL;
				l1.Add(i);
				NNPGPAPDDMC &= MGJKEJHEBPO_Blocks[i].FHMMFHAIPLF & b & !MGJKEJHEBPO_Blocks[i].KFKDMBPNLJK_BlockInvalid;
				l2.Add(MGJKEJHEBPO_Blocks[i].JIKKNHIAEKG_BlockName);
			}
		}
		if (l1.Count == 0)
			return null;
		long v = GJLFANGDGCL.MCKEOKFMLAH + 1;
		if (NNPGPAPDDMC)
		{
			BHBONAHFKHD data = new BHBONAHFKHD();
			for(int i = 0; i < l1.Count; i++)
			{
				KLFDBFMNLBL_ServerSaveBlock b = MGJKEJHEBPO_Blocks[l1[i]];
				KLFDBFMNLBL_ServerSaveBlock b2 = GJLFANGDGCL.MGJKEJHEBPO_Blocks[l1[i]];
				b.AGHKODFKOJI(data, b2, v);
			}
			if(data.MGPEIGDOMPH.HNBFOAJIIAL_Count < 101)
			{
				EMHDCKMFCGE data2 = new EMHDCKMFCGE(data.MGPEIGDOMPH, l2, true, v);
				return data2;
			}
		}
		EDOHBJAPLPF_JsonData jsonData = new EDOHBJAPLPF_JsonData();
		for (int i = 0; i < l1.Count; i++)
		{
			GJLFANGDGCL.MGJKEJHEBPO_Blocks[l1[i]].OKJPIBHMKMJ(jsonData, v);
		}
		{
			EMHDCKMFCGE data2 = new EMHDCKMFCGE(jsonData, l2, NNPGPAPDDMC, v);
			return data2;
		}
	}

	// // RVA: 0xF20BE0 Offset: 0xF20BE0 VA: 0xF20BE0
	public void PLCFEICAKBC(List<string> HHIHCJKLJFF)
	{
		MCKEOKFMLAH++;
		for(int i = 0; i < HHIHCJKLJFF.Count; i++)
		{
            KLFDBFMNLBL_ServerSaveBlock block = LBDOLHGDIEB_GetBlock(HHIHCJKLJFF[i]);
			if(block != null)
			{
				block.KFKDMBPNLJK_BlockInvalid = false;
				block.FHMMFHAIPLF = true;
			}
        }
	}

	// // RVA: 0xF20CE0 Offset: 0xF20CE0 VA: 0xF20CE0
	public bool IPLNOMCCNBI_UpdatePublicStatus()
	{
		if (MHEAEGMIKIE_PublicStatus == null)
			return false;
		if (PNLOINMCCKH_Scene == null)
			return false;
		if (MLAFAACKKBG_Unit == null)
			return false;
		if (KCCLEHLLOFG_Common == null)
			return false;
		if (DGCJCAHIAPP_Diva == null)
			return false;
		int dId = MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault().FDBOPFEOENF_MainDivas[0].DIPKCALNIII_Id;
		if (dId == 0)
			dId = 1;
		MHEAEGMIKIE_PublicStatus.KIECDDFNCAN_PLevel = KCCLEHLLOFG_Common.KIECDDFNCAN_Level;
		MHEAEGMIKIE_PublicStatus.DIPKCALNIII_DivaId = dId;
		DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo divaInfo = DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(dId);
		MHEAEGMIKIE_PublicStatus.ANAJIAENLNB_Level = divaInfo.HEBKEJBDCBH_DivaLevel;
		MHEAEGMIKIE_PublicStatus.BEEAIAAJOHD_CostumeId = divaInfo.BEEAIAAJOHD_CostumeId;
		MHEAEGMIKIE_PublicStatus.AFNIOJHODAG_CostumeColorId = divaInfo.AFNIOJHODAG_CostumeColorId;
		if(MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault().FODKKJIDDKN_VfId != 0)
		{
			MHEAEGMIKIE_PublicStatus.FODKKJIDDKN_VfId = MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault().FODKKJIDDKN_VfId;
		}
		MHEAEGMIKIE_PublicStatus.BKIFLJAMJGG_ScnCnt = PNLOINMCCKH_Scene.IGJAAIEAJPB_GetNumUnlockedScene();
		if(OFAJDLJBMEM_Emblem != null)
		{
			MHEAEGMIKIE_PublicStatus.FHCAFLCLGAA_EmCnt = OFAJDLJBMEM_Emblem.MDKOHOCONKE[MHEAEGMIKIE_PublicStatus.ABLOIBMGLFD_EmId - 1].FHCAFLCLGAA_Cnt;
		}
		MHEAEGMIKIE_PublicStatus.FOFGELKGMAH_CosCnt = BEKHNNCGIEL_Costume.EFFKJGEDONM_GetNumUnlockedCostume(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume, DGCJCAHIAPP_Diva, true);
		MHEAEGMIKIE_PublicStatus.MIFLBHBPBNF_VfCnt = JJFFBDLIOCF_Valkyrie.IJHGOONDKLI_GetNumUnlocked(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie);
		MHEAEGMIKIE_PublicStatus.APFOBLMCLAO_QCnt = GOACJBOCLHH_Quest.KJJJNMHNMCG(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest);
		MHEAEGMIKIE_PublicStatus.JGDNCEANEBB_LvMaxCnt = PNLOINMCCKH_Scene.BNNPJLPMLLK(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene);
		MHEAEGMIKIE_PublicStatus.LDKEOMCNLBE_PfTap = OEKEIGFAIGN_Counter.NJIDHLPGBFO_TTap[4];
		MHEAEGMIKIE_PublicStatus.PCBJHBCNNGD_TClr = OEKEIGFAIGN_Counter.PCBJHBCNNGD_TClr;
		if(divaInfo.PIGLAEFPNEK_MSlot > 0 && divaInfo.PIGLAEFPNEK_MSlot < PNLOINMCCKH_Scene.OPIBAPEGCLA.Count)
		{
			MMPBPOIFDAF_Scene.PMKOFEIONEG saveScene = PNLOINMCCKH_Scene.OPIBAPEGCLA[divaInfo.PIGLAEFPNEK_MSlot - 1];
			MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[divaInfo.PIGLAEFPNEK_MSlot - 1];
			int a = dbScene.AGOEDLNOHND(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, saveScene.EMOJHJGHJLN, saveScene.JPIPENJGGDD_Mlt, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.GENHLFPKOEE(dbScene.EKLIPGELKCL_Rarity, dbScene.MCCIFLKCNKO_Feed));
			MHEAEGMIKIE_PublicStatus.AFBMEMCHJCL_MScene.DOMFHDPMCCO(divaInfo.PIGLAEFPNEK_MSlot, saveScene.PDNIFBEGMHC_Mb, saveScene.EMOJHJGHJLN, a, saveScene.JPIPENJGGDD_Mlt, saveScene.DMNIMMGGJJJ_Leaf);
			//LAB_00f21764
		}
		else
		{
			MHEAEGMIKIE_PublicStatus.AFBMEMCHJCL_MScene.DOMFHDPMCCO(0, null, null, 0, 0, 0);
		}
		//LAB_00f21764
		for(int i = 0; i < divaInfo.EBDNICPAFLB_SSlot.Count; i++)
		{
			if (divaInfo.EBDNICPAFLB_SSlot[i] > 0 && divaInfo.EBDNICPAFLB_SSlot[i] < PNLOINMCCKH_Scene.OPIBAPEGCLA.Count)
			{
				MMPBPOIFDAF_Scene.PMKOFEIONEG saveScene = PNLOINMCCKH_Scene.OPIBAPEGCLA[divaInfo.EBDNICPAFLB_SSlot[i] - 1];
				MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[divaInfo.EBDNICPAFLB_SSlot[i] - 1];
				int a = dbScene.AGOEDLNOHND(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, saveScene.EMOJHJGHJLN, saveScene.JPIPENJGGDD_Mlt, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.GENHLFPKOEE(dbScene.EKLIPGELKCL_Rarity, dbScene.MCCIFLKCNKO_Feed));
				MHEAEGMIKIE_PublicStatus.HDJOHAJPGBA_SScene[i].DOMFHDPMCCO(divaInfo.EBDNICPAFLB_SSlot[i], saveScene.PDNIFBEGMHC_Mb, saveScene.EMOJHJGHJLN, saveScene.MJBODMOLOBC_Luck, saveScene.JPIPENJGGDD_Mlt, saveScene.DMNIMMGGJJJ_Leaf);
				//LAB_00f21764
			}
			else
			{
				MHEAEGMIKIE_PublicStatus.HDJOHAJPGBA_SScene[i].DOMFHDPMCCO(0, null, null, 0, 0, 0);
			}
		}
		if(LLBECHBNIJG_EventRaidPlayer != null)
		{
			int uptime = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("lobby_uptime_duration", 300);
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			if (uptime < time - LLBECHBNIJG_EventRaidPlayer.NFIOKIBPJCJ)
				LLBECHBNIJG_EventRaidPlayer.NFIOKIBPJCJ = time;
		}
		return true;
	}

	// // RVA: 0xF21E34 Offset: 0xF21E34 VA: 0xF21E34
	// public void DOPABKCMOOI(FKAFHLIDAFD KOFLKLHPOBJ, long JHNMKKNEENE) { }

	// // RVA: 0xF21F10 Offset: 0xF21F10 VA: 0xF21F10
	public FENCAJJBLBH PFAKPFKJJKA(bool DHNFPAGENLN = true)
	{
		if(MGJKEJHEBPO_Blocks == null)
			return null;
		if(DHNFPAGENLN)
		{
			TodoLogger.Log(0, "TODO");
		}
		else
		{
			if(KCCLEHLLOFG_Common != null && KCCLEHLLOFG_Common.PFAKPFKJJKA() != null)
			{
				return KCCLEHLLOFG_Common.PFAKPFKJJKA();
			}
			if(MBAHCFLBDHN_EventCollection != null && MBAHCFLBDHN_EventCollection.PFAKPFKJJKA() != null)
			{
				return MBAHCFLBDHN_EventCollection.PFAKPFKJJKA();
			}
		}
		return null;
	}

	// // RVA: 0xF2205C Offset: 0xF2205C VA: 0xF2205C
	public void NEBDDPDPAKJ(bool FHBAKFIHFLE = false)
	{
		if(AppEnv.IsPresentation())
		{
			JCFDDJIBKPA();
		}
		else
		{
			DAKDGCGIBDJ();
		}
	}

	// // RVA: 0xF220F8 Offset: 0xF220F8 VA: 0xF220F8
	public void JCFDDJIBKPA()
	{
		TodoLogger.Log(0, "TODO");
	}

	// // RVA: 0xF23B4C Offset: 0xF23B4C VA: 0xF23B4C
	private void DAKDGCGIBDJ()
	{
		if(OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.EDLBLCGHECJ_Max < MHEAEGMIKIE_PublicStatus.AEBENOJEGOJ_MaxSc)
		{
			OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.EDLBLCGHECJ_Max = MHEAEGMIKIE_PublicStatus.AEBENOJEGOJ_MaxSc;
		}
		HLKDMJHBPON_UpdateCostumeUnlocked();
		LGMPOFPHDAD_UpdateMusicHighScore();
		OAEFGBOGOEG_UpdateEmblems();
		DFDDLNKOCEL_UpdateIntimacyExp();
		MOHHCOKOOGJ_UpdateLimitedItems();
		DMEFFHBCIKH_UpdateAddMusic();
		HCOOGOCNNML_UpdateHomeBg();
	}

	// // RVA: 0xF2446C Offset: 0xF2446C VA: 0xF2446C
	private void HLKDMJHBPON_UpdateCostumeUnlocked()
	{
		//LAB_00f246e8:
		for(int i = 0; i < DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count; i++)
		{
			if(DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].BEEAIAAJOHD_CostumeId != 0)
			{
				if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.OEMKAFGPOCE_IsCostumeAvaiable(DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].BEEAIAAJOHD_CostumeId, i))
				{
					if(!BEKHNNCGIEL_Costume.FABAGMLEKIB_List[DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].BEEAIAAJOHD_CostumeId - 1].CGKAEMGLHNK_Possessed())
					{
						DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].BEEAIAAJOHD_CostumeId = 0;
						DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].AFNIOJHODAG_CostumeColorId = 0;
					}
				}
				else
				{
					//goto LAB_00f24694;
					DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].BEEAIAAJOHD_CostumeId = 0;
					DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].AFNIOJHODAG_CostumeColorId = 0;
				}
			}
		}
		for(int i = 0; i < 16; i++)
		{
			for(int j = 0; j < MLAFAACKKBG_Unit.GCINIJEMHFK(i).FDBOPFEOENF_MainDivas.Count; j++)
			{
				if(MLAFAACKKBG_Unit.GCINIJEMHFK(i).FDBOPFEOENF_MainDivas[j].DIPKCALNIII_Id != 0)
				{
					if(!IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.OEMKAFGPOCE_IsCostumeAvaiable(MLAFAACKKBG_Unit.GCINIJEMHFK(i).FDBOPFEOENF_MainDivas[j].BEEAIAAJOHD_CId, MLAFAACKKBG_Unit.GCINIJEMHFK(i).FDBOPFEOENF_MainDivas[j].DIPKCALNIII_Id))
					{
						MLAFAACKKBG_Unit.GCINIJEMHFK(i).FDBOPFEOENF_MainDivas[j].BEEAIAAJOHD_CId = 0;
					}
					else
					{
						if(!BEKHNNCGIEL_Costume.FABAGMLEKIB_List[MLAFAACKKBG_Unit.GCINIJEMHFK(i).FDBOPFEOENF_MainDivas[j].BEEAIAAJOHD_CId - 1].CGKAEMGLHNK_Possessed())
						{
							MLAFAACKKBG_Unit.GCINIJEMHFK(i).FDBOPFEOENF_MainDivas[j].BEEAIAAJOHD_CId = 0;
							MLAFAACKKBG_Unit.GCINIJEMHFK(i).FDBOPFEOENF_MainDivas[j].AFNIOJHODAG_ColId = 0;
						}
					}
				}
			}
		}
	}

	// // RVA: 0xF24B38 Offset: 0xF24B38 VA: 0xF24B38
	private void LGMPOFPHDAD_UpdateMusicHighScore()
	{
		if(FLBPFBFKBFC_FreeScoreMax != null && LCKMBHDMPIP_RecordMusic != null)
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			List<KEODKEGFDLD_FreeMusicInfo> freeMusicsDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas;
			List<JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo> freeMusicsSave = LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo;
			for(int i = 0; i < freeMusicsDb.Count; i++)
			{
				KEODKEGFDLD_FreeMusicInfo dbMusic = freeMusicsDb[i];
				if(dbMusic.PPEGAKEIEGM_Enabled == 2)
				{
					if(dbMusic.DEPGBBJMFED_CategoryId != 5)
					{
						JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo saveMusic = freeMusicsSave[i];
						int a = saveMusic.CLBAFNFLMKL_GetMaxScore();
						int score = FLBPFBFKBFC_FreeScoreMax.BDCAICINCKK_GetScoreMusic(i + 1);
						if(score < a)
						{
							FLBPFBFKBFC_FreeScoreMax.POIKGADFLHF_SetPreciseScoreForMusic(i + 1, a);
						}
					}
				}
			}
		}
	}

	// // RVA: 0xF24E90 Offset: 0xF24E90 VA: 0xF24E90
	private void OAEFGBOGOEG_UpdateEmblems()
	{
		if(KCCLEHLLOFG_Common != null && OFAJDLJBMEM_Emblem != null)
		{
			PEBFNABDJDI_System systemDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System;
			int unlockVal = systemDb.LPJLEHAJADA("fix_unlock_battle_class_emblem_id", 165);
			if(unlockVal != 0)
			{
				JGGLDGNKELI_Emblem.AAHAAJEJNLJ embl = OFAJDLJBMEM_Emblem.MDKOHOCONKE[unlockVal - 1];
				if(embl.FJODMPGPDDD)
				{
					if(KCCLEHLLOFG_Common.CPAGIICKKNN_EvBtlClsu == 25)
					{
						KCCLEHLLOFG_Common.CPAGIICKKNN_EvBtlClsu = 26;
						KCCLEHLLOFG_Common.KFKDMBPNLJK_BlockInvalid = true;
					}
				}
			}
			JGGLDGNKELI_Emblem.AAHAAJEJNLJ embl2 = OFAJDLJBMEM_Emblem.MDKOHOCONKE[165];
			if(embl2.FJODMPGPDDD)
			{
				if (KCCLEHLLOFG_Common.CPAGIICKKNN_EvBtlClsu > 25)
					return;
				KCCLEHLLOFG_Common.CPAGIICKKNN_EvBtlClsu = 26;
				KCCLEHLLOFG_Common.KFKDMBPNLJK_BlockInvalid = true;
				return;
			}
			for(int i = 164; i > 1; i--)
			{
				embl2 = OFAJDLJBMEM_Emblem.MDKOHOCONKE[i];
				if (embl2.FJODMPGPDDD)
				{
					if (KCCLEHLLOFG_Common.CPAGIICKKNN_EvBtlClsu <= i - 139)
						return;
					KCCLEHLLOFG_Common.CPAGIICKKNN_EvBtlClsu = i - 138;
					KCCLEHLLOFG_Common.KFKDMBPNLJK_BlockInvalid = true;
					return;
				}
			}
		}
	}

	// // RVA: 0xF2524C Offset: 0xF2524C VA: 0xF2524C
	private void DFDDLNKOCEL_UpdateIntimacyExp()
	{
		if(DGCJCAHIAPP_Diva != null && DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList != null)
		{
			GJALOMELEHD_Intimacy intimacyDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy;
			GJALOMELEHD_Intimacy.MFMLEAMJJCH_LevelInfo data = intimacyDb.OOCKOCAACMD_DataByLevel[39];
			int exp = data.BDLNMOIOMHK_StartExp;
			for(int i = 0; i < DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count; i++)
			{
				DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo dinfo = DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i];
				if(dinfo.CPGFPEDMDEH != 0 && dinfo.KCCONFODCPN_IntimacyLevel == 40 && dinfo.BNDNNCHJGBB_IntimacyExp == 0)
				{
					dinfo.BNDNNCHJGBB_IntimacyExp = exp;
				}
			}
		}
	}

	// // RVA: 0xF25498 Offset: 0xF25498 VA: 0xF25498
	private void MOHHCOKOOGJ_UpdateLimitedItems()
	{
		if(KCCLEHLLOFG_Common.PCBHHJHLOLN)
		{
			if(KCCLEHLLOFG_Common.BBFIGEOBOMB_SpItem != null && GJCOJBDOOJG_LimitedCompoItem != null)
			{
				long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				int cnt = KCCLEHLLOFG_Common.JJKEDPHDEDO_GetSpItemCount(13);
				for(int i = 0; i < cnt; i++)
				{
					GJCOJBDOOJG_LimitedCompoItem.CPIICACGNBH(1, time, false);
				}
				KCCLEHLLOFG_Common.LKNGEAKLFPG_SetSpItemCount(13, 0);
			}
		}
	}

	// // RVA: 0xF2566C Offset: 0xF2566C VA: 0xF2566C
	private void DMEFFHBCIKH_UpdateAddMusic()
	{
		if (KCCLEHLLOFG_Common == null)
			return;
		if(KCCLEHLLOFG_Common.KOGNMHLAOMB)
		{
			if(KCCLEHLLOFG_Common != null && MMGKPCIOHHC_AddMusic != null)
			{
				for(int i = 0; i < 300; i++)
				{
					for(int j = 2; j < 4; j++)
					{
						if(KCCLEHLLOFG_Common.CGEPJMFFLLJ_IsShowUnitLiveAdd(i, j))
						{
							MMGKPCIOHHC_AddMusic.DDCBGCODHHN(i, j);
						}
					}
				}
			}
		}
	}

	// // RVA: 0xF25720 Offset: 0xF25720 VA: 0xF25720
	private void HCOOGOCNNML_UpdateHomeBg()
	{
		if(KCCLEHLLOFG_Common != null && KCCLEHLLOFG_Common.POCPLFJCHDD_HomeBg != null)
		{
			if(KCCLEHLLOFG_Common.HCAHHCIGLLH)
			{
				if(!CGFNKMNBNBN.CEJADGLBCPA())
					return;
				KCCLEHLLOFG_Common.IGGDICEACIK();
				CGFNKMNBNBN.HHGLKFFKFAB(-1);
			}
		}
	}

	// // RVA: 0xF257B4 Offset: 0xF257B4 VA: 0xF257B4
	public void JAIGHAGMLCJ()
	{
		TodoLogger.Log(0, "TODO");
	}

	// // RVA: 0xF23C3C Offset: 0xF23C3C VA: 0xF23C3C
	// private void CEFEHMFEDBK(int IMJIADPJJMM, int AHHJLDLAPAN, int JPIDIENBGKH, int EKFONBFDAAP, int AFBMEMCHJCL, int JBLIIHOAIJB, int HAPFNHPFBGD, long BEBJKJKBOGH) { }

	// // RVA: 0xF25BE0 Offset: 0xF25BE0 VA: 0xF25BE0
	// public void NGJEPEPIHIL(int OLNBNMKAGJG) { }

	// // RVA: 0xF25954 Offset: 0xF25954 VA: 0xF25954
	// public void NELPFCBCJAO() { }

	// // RVA: 0xF25F74 Offset: 0xF25F74 VA: 0xF25F74
	static BBHNACPENDM_ServerSaveData()
	{
		BGEJFKHOMOC_CreateFuncs = new Dictionary<ulong, FFECIIHJDJA_CreateBlockDelegate>();
		BGEJFKHOMOC_CreateFuncs.Add(CFDJGBNJMIM_Base, () => { return new JBMPOAAMGNB_Base(); }); //0xF293C0 base
		BGEJFKHOMOC_CreateFuncs.Add(IGCDFADKKML_Common, () => { return new EGOLBAPFHHD_Common(); }); //0xF2942C common
		BGEJFKHOMOC_CreateFuncs.Add(FCMMJOJINDN_PublicStatus, () => { return new JNMFKOHFAFB_PublicStatus(); }); //0xF29498 public_status
																 //alldata
		BGEJFKHOMOC_CreateFuncs.Add(AAMNIFDPNLB_Diva, () => { return new DEKKMGAFJCG_Diva(); }); //0xF29504 diva
		BGEJFKHOMOC_CreateFuncs.Add(FKFMFFHOAIA_RecordMusic, () => { return new JDDGGJCGOPA_RecordMusic(); }); //0xF29570 record_music
		BGEJFKHOMOC_CreateFuncs.Add(PKCGBBNGJPO_Scene, () => { return new MMPBPOIFDAF_Scene(); }); //0xF295DC scene
		BGEJFKHOMOC_CreateFuncs.Add(HOPCNPLPEKE_StoryRecord, () => { return new NEKDCJKANAH_StoryRecord(); }); //0xF29648 story_record
		BGEJFKHOMOC_CreateFuncs.Add(MKPMBBAECPA_Unit, () => { return new FKNOCGCODBK_Unit(); }); //0xF296B4 unit
		BGEJFKHOMOC_CreateFuncs.Add(PGPHCJNGDMM_Costume, () => { return new EBFLJMOCLNA_Costume(); }); //0xF29720 costume
		BGEJFKHOMOC_CreateFuncs.Add(EFEJOKPJEEN_Episode, () => { return new OCLHKHAMDHF_Episode(); }); //0xF2978C episode
		BGEJFKHOMOC_CreateFuncs.Add(DMIGNJMIEEJ_Valkyrie, () => { return new OIGEIIGKMNH_Valkyrie(); }); //0xF297F8 valkyrie
		BGEJFKHOMOC_CreateFuncs.Add(IOKHNFIJAIM_Sns, () => { return new DDEMMEPBOIA_Sns(); }); //0xF29864 sns
		BGEJFKHOMOC_CreateFuncs.Add(NCKGBJOMPIB_EventCollection, () => { return new FJGNPNFLHPH_EventCollection(); }); //0xF298D0 event_collection
		BGEJFKHOMOC_CreateFuncs.Add(EAGPNDEDLFI_FreeScoreMax, () => { return new ICLNENNIMOP_FreeScoreMax(); }); //0xF2993C free_score_max
		BGEJFKHOMOC_CreateFuncs.Add(JMBDPGJFOAK_EventQuest, () => { return new OFNLIBDEIFA_EventQuest(); }); //0xF299A8 StringLiteral_9555
		BGEJFKHOMOC_CreateFuncs.Add(NJCDKKADEOM_Quest, () => { return new ODPNBADOFAN_Quest(); }); //0xF29A14 quest
		BGEJFKHOMOC_CreateFuncs.Add(AELKBIDPIEH_Counter, () => { return new FNBIIGJJGKA_Counter(); }); //0xF29A80 counter
		BGEJFKHOMOC_CreateFuncs.Add(LEDKALJFJOL_Emblem, () => { return new JGGLDGNKELI_Emblem(); }); //0xF29AEC emblem
		BGEJFKHOMOC_CreateFuncs.Add(GEEOAMAMBHI_EventScore, () => { return new FEHINJKHDAP_EventScore(); }); //0xF29B58 event_score
		BGEJFKHOMOC_CreateFuncs.Add(AECIGBCCHPA_Adventure, () => { return new HHDEBNFMIMH_Adventure(); }); //0xF29BC4 adventure
		BGEJFKHOMOC_CreateFuncs.Add(JMKKPDNEOMC_EventBattle, () => { return new CCPKHBECNLH_EventBattle(); }); //0xF29C30 event_battle
		BGEJFKHOMOC_CreateFuncs.Add(IKBDIKPCKOG_EventBattlePlayer, () => { return new BMIODFJCGAJ_EventBattlePlayer(); }); //0xF29C9C event_battle_player
		BGEJFKHOMOC_CreateFuncs.Add(FKBACFGLNLB_Prism, () => { return new NPOOPJIOMHF_Prism(); }); //0xF29D08 prism
		BGEJFKHOMOC_CreateFuncs.Add(LDNKKDBABFD_Shop, () => { return new GBEFGAIGGHA_Shop(); }); //0xF29D74 shop
		BGEJFKHOMOC_CreateFuncs.Add(GIMPPHEENJI_EventMission, () => { return new OKLMJPBJHKL_EventMission(); }); //0xF29DE0 event_mission
		BGEJFKHOMOC_CreateFuncs.Add(GONHNMGEOGC_EventSP, () => { return new NILOACEHJKJ_EventSP(); }); //0xF29E4C event_sp
		BGEJFKHOMOC_CreateFuncs.Add(GIKKNKGJBDJ_EventBoxGacha, () => { return new ALIPBIMCAPN_EventBoxGacha(); }); //0xF29EB8 event_box_gacha
		BGEJFKHOMOC_CreateFuncs.Add(GGHMGCGLDIF_Ticket, () => { return new GGHPEFNADEN_Ticket(); }); //0xF29F24 ticket
		BGEJFKHOMOC_CreateFuncs.Add(FBDIFLDJDMH_ArMarker, () => { return new KDLBHAKPLPH_ArMarker(); }); //0xF29F90 ar_marker
		BGEJFKHOMOC_CreateFuncs.Add(CFEFDIPHOIA_EventAprilFool, () => { return new FMFBNHLMHPL_EventAprilFool(); }); //0xF29FFC event_april_fool
		BGEJFKHOMOC_CreateFuncs.Add(JGGKEOIOHHN_Offer, () => { return new OCMJNBIFJNM_Offer(); }); //0xF2A068 offer
		BGEJFKHOMOC_CreateFuncs.Add(ICJCEFCINFB_MonthlyPass, () => { return new LGIDLHLBFFJ_MonthlyPass(); }); //0xF2A0D4 monthly_pass
		BGEJFKHOMOC_CreateFuncs.Add(DAELEHFKOMC_RareUpItem, () => { return new LGIOGDIPNGI_RareUpItem(); }); //0xF2A140 rareup_item
		BGEJFKHOMOC_CreateFuncs.Add(OEEEKEIIMAC_LimitedItem, () => { return new LIFGJMIHHKM_LimitedItem(); }); //0xF2A1AC limited_item
		BGEJFKHOMOC_CreateFuncs.Add(MNOIKPAPDMF_SaveHash, () => { return new FFMIPGABHHA_SaveHash(); }); //0xF2A218 save_hash
		BGEJFKHOMOC_CreateFuncs.Add(LBPMJOCELBC_Bingo, () => { return new NFMHCLHEMHB_Bingo(); }); //0xF2A284 bingo
		BGEJFKHOMOC_CreateFuncs.Add(FENLNECLOON_EventRaid, () => { return new JLOGEHCIBEJ_EventRaid(); }); //0xF2A2F0 event_raid
		BGEJFKHOMOC_CreateFuncs.Add(ANNJOIOHDKJ_EventRaidLobby, () => { return new KBAGKBIBGPM_EventRaidLobby(); }); //0xF2A35C event_raid_lobby
		BGEJFKHOMOC_CreateFuncs.Add(MOOLMJMBMGB_EventRaidPlayer, () => { return new LGGPBMPINDL_EventRaidPlayer(); }); //0xF2A3C8 event_raid_player
		BGEJFKHOMOC_CreateFuncs.Add(NEGNIBDPEEM_DecoPublicSet, () => { return new DAJBODHMLAB_DecoPublicSet(); }); //0xF2A434 deco_public_set
		BGEJFKHOMOC_CreateFuncs.Add(HFPPAGFAOJL_DecoPrivateSet, () => { return new AHHPBMBBCFM_DecoPrivateSet(); }); //0xF2A4A0 deco_private_set
		BGEJFKHOMOC_CreateFuncs.Add(JONEDOPANFB_DecoItem, () => { return new BCGFHLIEKLJ_DecoItem(); }); //0xF2A50C deco_item
		BGEJFKHOMOC_CreateFuncs.Add(ONOEAPIBPCN_FavoritePlayer, () => { return new LFHGFLJLGFB_FavoritePlayer(); }); //0xF2A6F4 favorite_player
		BGEJFKHOMOC_CreateFuncs.Add(NCIDKAFLDDD_DecoStamp, () => { return new IOEKHJBOMDH_DecoStamp(); }); //0xF2A760 deco_stamp
		BGEJFKHOMOC_CreateFuncs.Add(MMOCEAIPJJE_DecoPublicInfo, () => { return new PKLLAKCBPAH_DecoPublicInfo(); }); //0xF2A7CC deco_public_info
		BGEJFKHOMOC_CreateFuncs.Add(LALMBEGKBIG_DecoVisit, () => { return new FNCFHIEELGO_DecoVisit(); }); //0xF2A838 deco_visit
		BGEJFKHOMOC_CreateFuncs.Add(LPGMJAHFOKI_AssistPlate, () => { return new MKNIBACMCDO_AssistPlate(); }); //0xF2A8A4 assist_plate
		BGEJFKHOMOC_CreateFuncs.Add(AOKLBOLKCEN_LimitedCompoItem, () => { return new GEGHOCKCKKA_LimitedCompoItem(); }); //0xF2A910 limited_compo_item
		BGEJFKHOMOC_CreateFuncs.Add(PPEPINOOEMP_UnitGoDiva, () => { return new CEDOOHCPHMG_UnitGoDiva(); }); //0xF2A97C unit_godiva
		BGEJFKHOMOC_CreateFuncs.Add(AICNPGADBCE_EventGoDiva, () => { return new CCBMJNPFPBB_EventGoDiva(); }); //0xF2A9E8 event_godiva
		BGEJFKHOMOC_CreateFuncs.Add(AHBBPFBHJFA_AddMusic, () => { return new BAHFBCEPFGP_AddMusic(); }); //0xF2AA54 add_music
		BGEJFKHOMOC_CreateFuncs.Add(CDBDHHBOBNI_GachaLimit, () => { return new EAOHMJHHDKN_GachaLimit(); }); //0xF2AABC gacha_limit
	}
}
