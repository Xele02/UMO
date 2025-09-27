
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using XeApp.Game;
using XeApp.Game.Common;
using XeSys;

[System.Obsolete("Use NKOBMDPHNGP_EventRaidLobby", true)]
public class NKOBMDPHNGP { }
public class NKOBMDPHNGP_EventRaidLobby : IKDICBBFBMI_EventBase
{
	
	public enum FIPGKDJHKCH_Phase
	{
		HJNNKCMLGFL_0_None = 0,
		KJNKFFJBPIH_1_Before = 1,
		ECAAJMPLIPG_2_Now = 2,
		OLCLJKOKJCD_3_End = 3,
	}

	public class ELKMKCNPDFO : IFICNCAHIGI
	{
		public bool HKAIJKGODHC; // 0x4D

		public int AIBFGKBACCB_LobbyId { get { return AHEFHIMGIBI_PlayerData.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId; } } //0xC20A28 NAFFGDLBDGJ
		// public int KDMPHHFADMC_ClusterId { get; } 0xC2DF38 PNGFNKNGGHI

		// // RVA: 0xC2DF7C Offset: 0xC2DF7C VA: 0xC2DF7C Slot: 4
		public override bool EDEDFDDIOKO_Set(int _PPFNGGCBJKC_id, long _IFNLEKOILPM_updated_at, bool _MLEHCBKPNGK_IsFriend, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
		{
			BBHNACPENDM_ServerSaveData b = new BBHNACPENDM_ServerSaveData();
			b.KHEKNNFCAOI_Init(0x8000000005);
			HKAIJKGODHC = _MLEHCBKPNGK_IsFriend;
			return NLENMNMCJCJ(_PPFNGGCBJKC_id, _IFNLEKOILPM_updated_at, _MLEHCBKPNGK_IsFriend, _OHNJJIMGKGK_Names, _IDLHJIOMJBK_data, b);
		}
	}

	public enum FLHJEJGJJGE
	{
		GGCIMLDFDOC_0_Chat = 0,
		JAFEBKBFPBB_1_Battle = 1,
		CEMAJAOJBEO_2_Chapter = 2,
		AEFCOHJBLPO = 3,
		JFJDFBIKBGP = 0,
	}

	public class PEDPKDBKGIN
	{
		public int HALIDDHLNEG_Damage; // 0x8
		public int ADHMMMEOJMK_FreeMusicId; // 0xC
		public int AKNELONELJK_difficulty; // 0x10
		public int MFMPCHIJINJ_BossType; // 0x14
		public string GJAOLNLFEBD_BossName; // 0x18
		public int EJGDHAENIDC_BossRank; // 0x1C
		public int JPOIGNNOHJP_WavId; // 0x20
		public int PCPODOMOFDH_BossSerieAttr; // 0x24
		public int JNBDLNBKDCO_BossImage; // 0x28
		public bool GIKLNODJKFK_IsLine6; // 0x2C
		public bool IKICLMGFFPB_IsSpecial; // 0x2D
		public bool IGNJCGMLBDA_Defeat; // 0x2E
		public bool INLLJNOMNGF_CannonAttack; // 0x2F
		public bool NANEGCHBEDN_IsFullCombo; // 0x30
		public PKNOKJNLPOE_EventRaid AIOGBKCJLHM; // 0x34
		public bool DKKJPLALNFD_Skip; // 0x38
	}

	public class KAGMKNANHBA
	{
		public ANPBHCNJIDI.NBHIMCACDHM HCAHCFGPJIF_Desc; // 0x8

		// public bool DNJGAJPIIPI { get; } 0xC25738 GALFPKKIGBH

		// // RVA: 0xC25B70 Offset: 0xC25B70 VA: 0xC25B70
		// public void LHPDDGIJKNB_Reset() { }
	}

	public delegate void BFFHCHKDHJM(KAGMKNANHBA PNNCCHGFCME);

	public class GDNGPJINPDK
	{
		public int FDBOPFEOENF_diva; // 0x8
		public int IJLLIGENJCI_Pic; // 0xC
		public string LJGOOOMOMMA_message; // 0x10
	}

	public enum NGHEKBHLBAN
	{
		CFBJGAGBJEN_0 = 0,
		DMBDNIEEMCB = 1,
		BKLKNLDCJIO = 2,
	}

	// private const int GHJHJDIDCFA = 3;
	// private const int HDNDLJNKFFF = 100;
	public const int ODALKFEBNNA = 1;
	public const int LMCNAKBEBGI = 2147483647;
	// public const int HJLEHBHKDNC = 15;
	// private const int HIIDHBDPHJD = 1000;
	public int JGICMFAKGFO_SelectedChatType; // 0xE8
	public bool FJHLAKJBNFA; // 0xEC
	private EECOJKDJIFG KBACNOCOANM_Ranking; // 0xF0
	private BBHNACPENDM_ServerSaveData FPPNANIIODA = new BBHNACPENDM_ServerSaveData(); // 0xF4
	public List<ELKMKCNPDFO> ACCNCHJBDHM_UsersList = new List<ELKMKCNPDFO>(100); // 0xF8
	private const ulong PFNFFKJGBMI = 549755813893;
	// public const int BDNKGIAJANK = 3;
	private KKLGJPAIHJN EGMBECGOHAE; // 0xFC
	private KKLGJPAIHJN OKMNIPKLHHK; // 0x100
	private OKLFOAPMJAA FCBCCOEBHJB; // 0x104
	private OKLFOAPMJAA.BABPHOEGLPC[] KBMOEKMKGBL_ChatDatas; // 0x108
	private BFFHCHKDHJM CNCPFACLJHH; // 0x110
	private static StringBuilder NIGIOKLMJIH = new StringBuilder(32); // 0x0
	private List<int> OKGDAODFFBF_FoldRadarDivaBonusList = new List<int>(16); // 0x118

	public override OHCAABOMEOF.KGOGMKMBCPP_EventType HIDHLFCBIDE_EventType { get { return OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby; } } //0xC1E3C0 DKHCGLCNKCD  Slot: 4
	// public bool IFGKKLPOONJ { get; }
	// public bool LLJAIPIDANN { get; }
	// public bool IPLBEGCODDC { get; }
	// public int AMICDJMOGMA { get; }
	// public bool BGKKGPNBPJJ { get; }
	// public bool NLNIDMNBMPO { get; }
	// public bool IHDHKJBMMJP { get; set; }
	// public bool OOCDOBAALCB { get; }
	// public bool CDCDLDIKIBE { get; }
	public KAGMKNANHBA KPPHGAAOMDN { get; private set; } // 0x10C JLCLGIBMKEK CPJAANJHBFC KELONCIDGHP
	// public bool LDCEDHEKDPK { get; }
	// public bool IICNDOGFDLD { get; }
	// public int AMFIHIEMPND { get; }
	public int FDGMLPLCALF { get; private set; } // 0x114 KNKBBLLHNPF JNCAEPBEEAH IHJMHGEAOFN
	// public List<int> HOFEMNJNDCC { get; }
	// public static int EAIBKGDAMLE { get; }
	// public static string JKOGDCFELHF { get; }
	// public bool NLLFHIKOKLM { get; }
	// public bool FCLIMIPGPAB { get; }

	// // RVA: 0xC1E3C8 Offset: 0xC1E3C8 VA: 0xC1E3C8 Slot: 32
	public override EECOJKDJIFG DAKMIKNKHMF_GetRankingInfoForIndex(int LHJCOPMMIGO/* = 0*/)
	{
		return KBACNOCOANM_Ranking;
	}

	// RVA: 0xC1E3D0 Offset: 0xC1E3D0 VA: 0xC1E3D0
	public NKOBMDPHNGP_EventRaidLobby(string _OPFGFINHFCE_name) : base(_OPFGFINHFCE_name)
    {
        if(FJLIDJJAGOM() == null)
            return;
        FPPNANIIODA.EBKCPELHDKN_InitWithBaseAndPublicStatus();
        MALEKMPDKKF();
        CNGIENBEHID();
    }

	// // RVA: 0xC1E560 Offset: 0xC1E560 VA: 0xC1E560
	public LDEBIBGHCGD_EventRaidLobby FJLIDJJAGOM()
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			return db as LDEBIBGHCGD_EventRaidLobby;
		}
		return null;
	}

	// // RVA: 0xC1E85C Offset: 0xC1E85C VA: 0xC1E85C
	// private KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA KNKJHNJFONJ(BBHNACPENDM KGPIPDHHNPK) { }

	// // RVA: 0xC1E87C Offset: 0xC1E87C VA: 0xC1E87C
	private KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA KNKJHNJFONJ_GetEvSave(LDEBIBGHCGD_EventRaidLobby _NDFIEMPPMLF_master, BBHNACPENDM_ServerSaveData BGEPKJCKKGF)
	{
		if(_NDFIEMPPMLF_master == null)
			return null;
		if(BGEPKJCKKGF == null)
		{
			BGEPKJCKKGF = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData;
		}
		return BGEPKJCKKGF.PJCMHDEJLGF_EventRaidLobby.FBCJICEPLED[_NDFIEMPPMLF_master.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
	}

	// // RVA: 0xC1E9B8 Offset: 0xC1E9B8 VA: 0xC1E9B8 Slot: 27
	public override int HLOGNJNGDJO_GetHelpId(int _OIPCCBHIKIA_index/* = 0*/)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev == null)
			return 0;
		return ev.NGHKJOEDLIP_Settings.EJBGHLOOLBC_HelpIds[_OIPCCBHIKIA_index];
    }

	// // RVA: 0xC1EA28 Offset: 0xC1EA28 VA: 0xC1EA28 Slot: 30
	protected override bool JIHMLILFOPG_IsEventActive(long _JHNMKKNEENE_Time)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
        if (ev != null)
		{
			GDIPLANPCEI g = IMMAOANGPNK.HHCJCDFCLOB.ACEFBFLFKFD_GetScheduleEventData(ev.JIKKNHIAEKG_BlockName, _JHNMKKNEENE_Time);
			if(g != null)
			{
				return _JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.CJPMLAIFCDL_LobbyStart && _JHNMKKNEENE_Time <= ev.NGHKJOEDLIP_Settings.COIHIAKHFNF_End;
			}
		}
		return false;
	}

	// // RVA: 0xC1EB64 Offset: 0xC1EB64 VA: 0xC1EB64 Slot: 31
	protected override bool IMCMNOPNGHO(long _JHNMKKNEENE_Time)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null)
		{
			AGLILDLEFDK_Missions = ev.NNMPGOAGEOL_quests;
			KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA k = KNKJHNJFONJ_GetEvSave(ev, null);
			OLDFFDMPEBM_Quests = k.NNMPGOAGEOL_quests;
			bool b = true;
			if(k.EGBOHDFBAPB_closed_at >= ev.NGHKJOEDLIP_Settings.CJPMLAIFCDL_LobbyStart || RuntimeSettings.CurrentSettings.UnlimitedEvent)
			{
				b = k.MPCAGEPEJJJ_Key != ev.OJGPPOKENLG_Groups[0].HEDAGCNPHGD_RankingName || CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LLBECHBNIJG_EventRaidPlayer.OBGBAOLONDD_UniqueId != ev.NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId;
			}
			if(b)
			{
				k.LHPDDGIJKNB_Reset();
				k.MPCAGEPEJJJ_Key = ev.OJGPPOKENLG_Groups[0].HEDAGCNPHGD_RankingName;
				k.EGBOHDFBAPB_closed_at = ev.NGHKJOEDLIP_Settings.COIHIAKHFNF_End;
				KOMAHOAEMEK(true);
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LLBECHBNIJG_EventRaidPlayer.KHEKNNFCAOI_Init(ev.NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId);
			}
			KOMAHOAEMEK(false);
			return true;
		}
        return false;
	}

	// // RVA: 0xC1EE14 Offset: 0xC1EE14 VA: 0xC1EE14 Slot: 40
	protected override void KKFLDCBHFJA(long _JHNMKKNEENE_Time)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null)
		{
			DGCOMDILAKM_EventName = ev.NGHKJOEDLIP_Settings.OPFGFINHFCE_name;
			GLIMIGNNGGB_RankingStart = ev.NGHKJOEDLIP_Settings.CJPMLAIFCDL_LobbyStart;
			EMEKFFHCHMH_RewardEnd2 = ev.NGHKJOEDLIP_Settings.COIHIAKHFNF_End;
			JDDFILGNGFH_RewardStart = ev.NGHKJOEDLIP_Settings.COIHIAKHFNF_End;
			LJOHLEGGGMC_RewardEnd = ev.NGHKJOEDLIP_Settings.COIHIAKHFNF_End;
			DPJCPDKALGI_RankingEnd = ev.NGHKJOEDLIP_Settings.COIHIAKHFNF_End;
			LOLAANGCGDO_RankingEnd2 = ev.NGHKJOEDLIP_Settings.COIHIAKHFNF_End;
			PGIIDPEGGPI_EventId = ev.NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId;
			NHGPCLGPEHH_TicketType = ev.NGHKJOEDLIP_Settings.MJBKGOJBPAD_item_type;
			PJLNJJIBFBN_HasExtremeDiff = true;
			FBHONHONKGD_MusicSelectDesc = "";
			LEPALMDKEOK_IsPointReward = false;
			for(int i = 0; i < KPOMHFLKMKI_LastRankUpdateTime.Length; i++)
			{
				KPOMHFLKMKI_LastRankUpdateTime[i] = 0;
			}
		}
    }

	// // RVA: 0xC1EFB4 Offset: 0xC1EFB4 VA: 0xC1EFB4 Slot: 46
	protected override void PJDGDNJNCNM_UpdateStatusImpl(long _JHNMKKNEENE_Time)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null)
		{
			IBLPKJJNNIG = false;
			BELBNINIOIE = false;
			NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DOAENCHBAEO_11;
			if(_JHNMKKNEENE_Time < ev.NGHKJOEDLIP_Settings.COIHIAKHFNF_End)
				NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MINDIGBAJFG_3;
		}
		else
		{
			NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HJNNKCMLGFL_0_None;
		}
    }

	// // RVA: 0xC1F014 Offset: 0xC1F014 VA: 0xC1F014 Slot: 28
	public override long FBGDBGKNKOD_GetCurrentPoint()
	{
		return 0;
	}

	// // RVA: 0xC1F020 Offset: 0xC1F020 VA: 0xC1F020 Slot: 26
	public override bool KKFEDJNIAAG(long _JHNMKKNEENE_Time)
	{
		return false;
	}

	// // RVA: 0xC1F028 Offset: 0xC1F028 VA: 0xC1F028
	public JKOHBJPCAJL.CNNCBDKIPGE ILCPALOKKHC_GetStep()
	{
        KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA ev = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM(), null);
        if (ev != null)
		{
			return (JKOHBJPCAJL.CNNCBDKIPGE)ev.LGADCGFMLLD_step;
		}
        return 0;
	}

	// // RVA: 0xC1F058 Offset: 0xC1F058 VA: 0xC1F058
	// public void MPCPIMOACHJ(JKOHBJPCAJL.CNNCBDKIPGE _LGADCGFMLLD_step) { }

	// // RVA: 0xC1F08C Offset: 0xC1F08C VA: 0xC1F08C Slot: 70
	public override void ADACMHAHHKC_PreSetupEventHome(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		N.a.StartCoroutineWatched(NJIEIJJMAHK_Corotuine_PreSetupEventHome(_BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BDB34 Offset: 0x6BDB34 VA: 0x6BDB34
	// // RVA: 0xC1F0E4 Offset: 0xC1F0E4 VA: 0xC1F0E4
	private IEnumerator NJIEIJJMAHK_Corotuine_PreSetupEventHome(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		long IBCGNDADAEE_Time; // 0x20
		LDEBIBGHCGD_EventRaidLobby KEHCNBNPJHB; // 0x28

		//0xC2BF08
		IBCGNDADAEE_Time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		LPFJADHHLHG = false;
		KEHCNBNPJHB = FJLIDJJAGOM();
		if(KEHCNBNPJHB == null)
		{
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
			if(_AOCANKOMKFG_OnError != null)
				_AOCANKOMKFG_OnError();
			yield break;
		}
		PJDGDNJNCNM_UpdateStatusImpl(IBCGNDADAEE_Time);
		MJFKJHJJLMN_GetRanks(0, false);
		while(!PLOOEECNHFB_IsDone)
			yield return null;
		if(NPNNPNAIONN_IsError)
		{
			//LAB_00c2c2bc
			_AOCANKOMKFG_OnError();
		}
		else
		{
            KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA k = KNKJHNJFONJ_GetEvSave(KEHCNBNPJHB, null);
            if (FKKDIDMGLMI_IsDroppedPlayer)
			{
				JHHBAFKMBDL.HHCJCDFCLOB.PEIONAKEPCN_ShowRankingBanPopup(_AOCANKOMKFG_OnError);
				yield break;
			}
			if(IBCGNDADAEE_Time >= KEHCNBNPJHB.NGHKJOEDLIP_Settings.NIMLIMFPNJP_RaidStart)
			{
				if(KEHCNBNPJHB.NGHKJOEDLIP_Settings.KCBGBFMGHPA_End >= IBCGNDADAEE_Time)
				{
					if(k.LGADCGFMLLD_step != 4)
						k.LGADCGFMLLD_step = 3;
				}
				else
				{
					if(k.LGADCGFMLLD_step != 6)
						k.LGADCGFMLLD_step = 5;
				}
			}
			else
			{
				if(k.LGADCGFMLLD_step != 2)
					k.LGADCGFMLLD_step = 1;
			}
			CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
			{
				//0xC29D64
				ILCCJNDFFOB.HHCJCDFCLOB.DADNPOJNIBL(this);
				if(_BHFHGFKBOHH_OnSuccess != null)
					_BHFHGFKBOHH_OnSuccess();
				PLOOEECNHFB_IsDone = true;
			}, () =>
			{
				//0xC29E3C
				if(_AOCANKOMKFG_OnError != null)
					_AOCANKOMKFG_OnError();
				PLOOEECNHFB_IsDone = true;
				NPNNPNAIONN_IsError = true;
			}, null);
		}
	}

	// // RVA: 0xC1F1C0 Offset: 0xC1F1C0 VA: 0xC1F1C0 Slot: 69
	public override void HAAEJDGMICH(LBNLAENLPNK.JEKODBEDOMM _INDDJNMPONH_type, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		string s = null;
		if(_INDDJNMPONH_type == 0)
		{
			s = JOPOPMLFINI_QuestName + "_rule";
		}
		if(string.IsNullOrEmpty(s))
		{
			_BHFHGFKBOHH_OnSuccess();
		}
		else
		{
			MBCPNPNMFHB.HHCJCDFCLOB.FLLLPBIECCP(s, _BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError);
		}
	}

	// // RVA: 0xC1F2E8 Offset: 0xC1F2E8 VA: 0xC1F2E8 Slot: 71
	public override int BAEPGOAMBDK(string _LJNAKDMILMC_key, int MNCOAGOKNAO)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
        if (ev != null)
		{
			return ev.LPJLEHAJADA_GetIntParam(_LJNAKDMILMC_key, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0xC1F320 Offset: 0xC1F320 VA: 0xC1F320 Slot: 72
	public override string MAICAKMIBEM(string _LJNAKDMILMC_key, string MNCOAGOKNAO)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
        if (ev != null)
		{
			return ev.EFEGBHACJAL_GetStringParam(_LJNAKDMILMC_key, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0xC1F358 Offset: 0xC1F358 VA: 0xC1F358 Slot: 75
	public override string FEKEBPKINIM_GetSessionId()
	{
        KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA k = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM(), null);
        return k != null ? k.MDADLCOCEBN_session_id : "";
	}

	// // RVA: 0xC1F3D0 Offset: 0xC1F3D0 VA: 0xC1F3D0
	public bool EMPOBKBHLAC(long _JHNMKKNEENE_Time)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null && !ANOPCGFIMEJ())
		{
			if(_JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.NIMLIMFPNJP_RaidStart)
			{
				return _JHNMKKNEENE_Time < ev.NGHKJOEDLIP_Settings.KCBGBFMGHPA_End;
			}
		}
        return false;
	}

	// // RVA: 0xC1F4DC Offset: 0xC1F4DC VA: 0xC1F4DC
	public FIPGKDJHKCH_Phase KINIOEOOCAA_GetPhase(long _JHNMKKNEENE_Time)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev == null)
			return FIPGKDJHKCH_Phase.HJNNKCMLGFL_0_None;
		if(_JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.CJPMLAIFCDL_LobbyStart)
		{
			if(_JHNMKKNEENE_Time < ev.NGHKJOEDLIP_Settings.NIMLIMFPNJP_RaidStart)
				return FIPGKDJHKCH_Phase.KJNKFFJBPIH_1_Before;
		}
		if(_JHNMKKNEENE_Time < ev.NGHKJOEDLIP_Settings.NIMLIMFPNJP_RaidStart)
		{
			return FIPGKDJHKCH_Phase.OLCLJKOKJCD_3_End;
		}
		if(_JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.KCBGBFMGHPA_End)
		{
			return FIPGKDJHKCH_Phase.OLCLJKOKJCD_3_End;
		}
		return FIPGKDJHKCH_Phase.ECAAJMPLIPG_2_Now;
    }

	// // RVA: 0xC1F5A8 Offset: 0xC1F5A8 VA: 0xC1F5A8
	// public void COBCHBMMFPB(out long _PDBPFJJCADD_open_at, out long _FDBNFFNFOND_close_at) { }

	// // RVA: 0xC1F618 Offset: 0xC1F618 VA: 0xC1F618
	public void IICLCPIPENB_GetRaidTime(out long _PDBPFJJCADD_open_at, out long _FDBNFFNFOND_close_at)
	{
		_PDBPFJJCADD_open_at = 0;
		_FDBNFFNFOND_close_at = 0;
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev == null)
			return;
		_PDBPFJJCADD_open_at = ev.NGHKJOEDLIP_Settings.NIMLIMFPNJP_RaidStart;
		_FDBNFFNFOND_close_at = ev.NGHKJOEDLIP_Settings.KCBGBFMGHPA_End;
    }

	// // RVA: 0xC1F688 Offset: 0xC1F688 VA: 0xC1F688
	public int IICHMBONEIE_GetDayBefore(long _JHNMKKNEENE_Time)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
        DateTime dateStart = Utility.GetLocalDateTime(ev.NGHKJOEDLIP_Settings.NIMLIMFPNJP_RaidStart);
		DateTime dateCur = Utility.GetLocalDateTime(_JHNMKKNEENE_Time);
        TimeSpan diff = dateStart - dateCur;
		int a = diff.Days;
		if(a < 1)
		{
			if(dateStart.Month == dateCur.Month)
			{
				a = dateStart.Day != dateCur.Day ? 1 : 0;
			}
			else
			{
				a = 1;
			}
		}
        return Mathf.Max(a, 0);
	}

	// // RVA: 0xC1F8A8 Offset: 0xC1F8A8 VA: 0xC1F8A8
	public int MKACADAOPEI_GetDayNow(long _JHNMKKNEENE_Time)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
        DateTime dateStart = Utility.GetLocalDateTime(ev.NGHKJOEDLIP_Settings.KCBGBFMGHPA_End);
		DateTime dateCur = Utility.GetLocalDateTime(_JHNMKKNEENE_Time);
        TimeSpan diff = dateStart - dateCur;
		int a = diff.Days;
		if(a < 1)
		{
			if(dateStart.Month == dateCur.Month)
			{
				a = dateStart.Day != dateCur.Day ? 1 : 0;
			}
			else
			{
				a = 1;
			}
		}
        return Mathf.Max(a, 0);
	}

	// // RVA: 0xC1FAC8 Offset: 0xC1FAC8 VA: 0xC1FAC8
	public int PIFFFLDOJKJ_GetDayAfter(long _JHNMKKNEENE_Time)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
        DateTime dateStart = Utility.GetLocalDateTime(ev.NGHKJOEDLIP_Settings.COIHIAKHFNF_End);
		DateTime dateCur = Utility.GetLocalDateTime(_JHNMKKNEENE_Time);
        TimeSpan diff = dateStart - dateCur;
		int a = diff.Days;
		if(a < 1)
		{
			if(dateStart.Month == dateCur.Month)
			{
				a = dateStart.Day != dateCur.Day ? 1 : 0;
			}
			else
			{
				a = 1;
			}
		}
        return Mathf.Max(a, 0);
	}

	// // RVA: 0xC1FCE8 Offset: 0xC1FCE8 VA: 0xC1FCE8
	public FIPGKDJHKCH_Phase CHDNDNMHJHI_GetPhase()
	{
        KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA k = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM(), null);
		if(k != null)
		{
			if(k.LGADCGFMLLD_step >= 1 && k.LGADCGFMLLD_step < 7)
			{
				return new FIPGKDJHKCH_Phase[] {
					FIPGKDJHKCH_Phase.KJNKFFJBPIH_1_Before,
					FIPGKDJHKCH_Phase.KJNKFFJBPIH_1_Before,
					FIPGKDJHKCH_Phase.ECAAJMPLIPG_2_Now,
					FIPGKDJHKCH_Phase.ECAAJMPLIPG_2_Now,
					FIPGKDJHKCH_Phase.OLCLJKOKJCD_3_End,
					FIPGKDJHKCH_Phase.OLCLJKOKJCD_3_End
				} [(int)k.LGADCGFMLLD_step - 1];
			}
		}
        return FIPGKDJHKCH_Phase.HJNNKCMLGFL_0_None;
	}

	// // RVA: 0xC1F45C Offset: 0xC1F45C VA: 0xC1F45C
	public bool ANOPCGFIMEJ()
	{
        KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA k = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM(), null);
		if(k != null)
		{
			return k.LGADCGFMLLD_step == 1 || k.LGADCGFMLLD_step == 3 || k.LGADCGFMLLD_step == 5;
		}
		return false;
	}

	// // RVA: 0xC1FD44 Offset: 0xC1FD44 VA: 0xC1FD44
	public void EGIHAHOCKPK()
	{
        KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA k = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM(), null);
		if(k != null)
		{
			if(k.LGADCGFMLLD_step == 1)
				k.LGADCGFMLLD_step = 2;
			if(k.LGADCGFMLLD_step == 3)
				k.LGADCGFMLLD_step = 4;
			if(k.LGADCGFMLLD_step == 5)
				k.LGADCGFMLLD_step = 6;
		}
	}

	// // RVA: 0xC1FDD4 Offset: 0xC1FDD4 VA: 0xC1FDD4
	public bool MCJFAACGLCB()
	{
        KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA save = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM(), null);
        if (save != null)
		{
			if(save.LGADCGFMLLD_step == 4)
			{
				return true;
			}
		}
		return false;
	}

	// // RVA: 0xC1FE14 Offset: 0xC1FE14 VA: 0xC1FE14
	// private int OKEOHFMGPNG(long _HMFFHLPNMPH_count, int JGEEFPKHHCH, int IIJMIIBLDKJ) { }

	// // RVA: 0xC1FE54 Offset: 0xC1FE54 VA: 0xC1FE54
	public int OKEOHFMGPNG_GetRoomId(long _FJOLNJLLJEJ_rank, int _JGEEFPKHHCH_Capacity, List<int> IIJMIIBLDKJ)
	{
		long l = _FJOLNJLLJEJ_rank - 1;
		int idx = 0;
		int start = 0;
		while(true)
		{
			if(l - 1 < IIJMIIBLDKJ[idx] * _JGEEFPKHHCH_Capacity)
				break;
			l -= IIJMIIBLDKJ[idx] * _JGEEFPKHHCH_Capacity;
			start += IIJMIIBLDKJ[idx];
			if(idx < IIJMIIBLDKJ.Count - 1)
				idx++;
		}
		int roomId = (int)(start + ((l % (IIJMIIBLDKJ[idx] * _JGEEFPKHHCH_Capacity)) / IIJMIIBLDKJ[idx]) + 1);
		TodoLogger.LogError(TodoLogger.ToCheck, "check this / % "+_FJOLNJLLJEJ_rank+" "+_JGEEFPKHHCH_Capacity+" "+IIJMIIBLDKJ.Count+" "+start+" "+l+" "+IIJMIIBLDKJ[idx]+" "+roomId);
		return roomId;
	}

	// // RVA: 0xC20004 Offset: 0xC20004 VA: 0xC20004
	public bool EHLFBIEGDDF()
	{
		return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LLBECHBNIJG_EventRaidPlayer.IPLBEGCODDC(PGIIDPEGGPI_EventId);
	}

	// // RVA: 0xC200EC Offset: 0xC200EC VA: 0xC200EC
	public void DEJFFGKLNHP(int FAEPBBLLANI, int _DDFDEEAHCEP_ClusterId, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev == null)
		{
			NPNNPNAIONN_IsError = true;
			PLOOEECNHFB_IsDone = true;
			_MOBEEPPKFLG_OnFail();
		}
		else
		{
			NPNNPNAIONN_IsError = false;
			PLOOEECNHFB_IsDone = false;
			N.a.StartCoroutineWatched(JNPBHMMILOP_Corotuine_DecideLobbyPrepare(_DDFDEEAHCEP_ClusterId, ev.OJGPPOKENLG_Groups[FAEPBBLLANI], _BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail));
		}
    }

	// [IteratorStateMachineAttribute] // RVA: 0x6BDBAC Offset: 0x6BDBAC VA: 0x6BDBAC
	// // RVA: 0xC20218 Offset: 0xC20218 VA: 0xC20218
	private IEnumerator JNPBHMMILOP_Corotuine_DecideLobbyPrepare(int _DDFDEEAHCEP_ClusterId, LDEBIBGHCGD_EventRaidLobby.HDFAGGBJGAA _KGICDMIJGDF_Group, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		int HOJHFFNMJEK; // 0x28
		int JJKHJPMAHKM; // 0x2C
		int JIAMHIMJCBO; // 0x30
		EECOJKDJIFG ELOGHEDOIGC; // 0x34
		int FHACAEAHPIA; // 0x38
		FPFPJKJNOFK_UpdateRankingScore NMBJNEPMHOO; // 0x3C

		//0xC2B280
		HOJHFFNMJEK = BAEPGOAMBDK("deceide_lobby_retry_num", 3);
		JJKHJPMAHKM = BAEPGOAMBDK("deceide_wait_rand_min", 1);
		JIAMHIMJCBO = BAEPGOAMBDK("deceide_wait_rand_max", 5);
		ELOGHEDOIGC = KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK_rankings.Find((EECOJKDJIFG _HKICMNAACDA_a) =>
		{
			//0xC29E9C
			return _HKICMNAACDA_a.OCGFKMHNEOF_name_for_api == _KGICDMIJGDF_Group.HEDAGCNPHGD_RankingName;
		});
		if(ELOGHEDOIGC != null)
		{
			//LAB_00c2b500
			for(FHACAEAHPIA = 0; FHACAEAHPIA < HOJHFFNMJEK; FHACAEAHPIA++)
			{
				long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
				NMBJNEPMHOO = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new FPFPJKJNOFK_UpdateRankingScore());
				NMBJNEPMHOO.EMPNJPMAKBF_Id = ELOGHEDOIGC.PPFNGGCBJKC_id;
				NMBJNEPMHOO.HOCPLDLAIGL_Score = t * 0.000001f;
				NMBJNEPMHOO.NBFDEFGFLPJ = (SakashoErrorId LJJGBICGLLF) =>
				{
					//0xC28660
					return LJJGBICGLLF == 0;
				};
				//LAB_00c2b724
				while(!NMBJNEPMHOO.PLOOEECNHFB_IsDone)
					yield return null;
				if(NMBJNEPMHOO.PLOOEECNHFB_IsDone)
				{
					if(!NMBJNEPMHOO.NPNNPNAIONN_IsError)
					{
						N.a.StartCoroutineWatched(AEPPBBLPBPE_Corotuine_DecideLobby(_DDFDEEAHCEP_ClusterId, _KGICDMIJGDF_Group, _BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail));
						yield break;
					}
				}
				if(NMBJNEPMHOO.CJMFJOMECKI_ErrorId == SakashoErrorId.UNKNOWN)
				{
					if(HOJHFFNMJEK != FHACAEAHPIA + 1)
					{
						yield return new WaitForSeconds(UnityEngine.Random.Range(JJKHJPMAHKM, JIAMHIMJCBO));
					}
					else
					{
						JHHBAFKMBDL.HHCJCDFCLOB.AJIJCMKMAMA(NMBJNEPMHOO.CJMFJOMECKI_ErrorId, NMBJNEPMHOO, 0, () =>
						{
							//0xC29EE8
							PLOOEECNHFB_IsDone = true;
							NPNNPNAIONN_IsError = true;
							_MOBEEPPKFLG_OnFail();
						});
						yield break;
					}
				}
				else
				{
					break;
				}
			}
		}
		else
		{
			Debug.LogError("Raid lobby ranking not found : "+_KGICDMIJGDF_Group.HEDAGCNPHGD_RankingName);
		}
		PLOOEECNHFB_IsDone = true;
		NPNNPNAIONN_IsError = true;
		_MOBEEPPKFLG_OnFail();
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BDC24 Offset: 0x6BDC24 VA: 0x6BDC24
	// // RVA: 0xC20330 Offset: 0xC20330 VA: 0xC20330
	private IEnumerator AEPPBBLPBPE_Corotuine_DecideLobby(int _DDFDEEAHCEP_ClusterId, LDEBIBGHCGD_EventRaidLobby.HDFAGGBJGAA _KGICDMIJGDF_Group, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		//0xC2AEA0
        LDEBIBGHCGD_EventRaidLobby NDFIEMPPMLF_master = FJLIDJJAGOM();
		int lobby_ranking_wait = NDFIEMPPMLF_master.LPJLEHAJADA_GetIntParam("lobby_ranking_wait", 3);
		if(lobby_ranking_wait > 0)
		{
			yield return new WaitForSeconds(lobby_ranking_wait);
		}
		KKLGENJKEBN.HHCJCDFCLOB.HEOKADCEAGL_GetRanks(_KGICDMIJGDF_Group.HEDAGCNPHGD_RankingName, () =>
		{
			//0xC29F54
			int lobby_member_divide = NDFIEMPPMLF_master.LPJLEHAJADA_GetIntParam("lobby_member_divide", 40);
			int v = OKEOHFMGPNG_GetRoomId(KKLGENJKEBN.HHCJCDFCLOB.LPPCNCMEDFA_Rank, lobby_member_divide, _KGICDMIJGDF_Group.OCDBMHBNLEF);
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId = CHPLIGDOMLI_GetLobbyId(_KGICDMIJGDF_Group.PPFNGGCBJKC_id, v);
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LLBECHBNIJG_EventRaidPlayer.KDMPHHFADMC_ClusterId = _DDFDEEAHCEP_ClusterId;
			ILCCJNDFFOB.HHCJCDFCLOB.PHCLHGPCFNL(this, _KGICDMIJGDF_Group.PPFNGGCBJKC_id, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId, 
				OFAKIAJNPDF_GetGroupName(_KGICDMIJGDF_Group.PPFNGGCBJKC_id), (int)KKLGENJKEBN.HHCJCDFCLOB.LPPCNCMEDFA_Rank, lobby_member_divide, "");
			CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
			{
				//0xC2A314
				PLOOEECNHFB_IsDone = true;
				_BHFHGFKBOHH_OnSuccess();
			}, () =>
			{
				//0xC2A360
				PLOOEECNHFB_IsDone = true;
				NPNNPNAIONN_IsError = true;
				_MOBEEPPKFLG_OnFail();
			}, null);
		}, () =>
		{
			//0xC2A3C4
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
			_MOBEEPPKFLG_OnFail();
		}, () =>
		{
			//0xC2A428
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
			_MOBEEPPKFLG_OnFail();
		}, () =>
		{
			//0xC2A48C
			JHHBAFKMBDL.HHCJCDFCLOB.PEIONAKEPCN_ShowRankingBanPopup(_MOBEEPPKFLG_OnFail);
		});
    }

	// // RVA: 0xC20448 Offset: 0xC20448 VA: 0xC20448
	private int CHPLIGDOMLI_GetLobbyId(int INHOGJODJFJ_GroupId, int _MALFHCHNEFN_RoomId)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null)
		{
			int lobbyId = PDNFHDLNENO(ev.LPJLEHAJADA_GetIntParam("lobby_id_room_mag", 10) * _MALFHCHNEFN_RoomId + ev.LPJLEHAJADA_GetIntParam("lobby_id_group_mag", 1) * INHOGJODJFJ_GroupId) + 1;
			Debug.LogError("lobbyId "+lobbyId+" "+INHOGJODJFJ_GroupId+" "+_MALFHCHNEFN_RoomId);
			return lobbyId;
		}
        return 0;
	}

	// // RVA: 0xC20690 Offset: 0xC20690 VA: 0xC20690
	// public void OBBGPHPPCML(out int _INHOGJODJFJ_GroupId, out int _MALFHCHNEFN_RoomId) { }

	// // RVA: 0xC207CC Offset: 0xC207CC VA: 0xC207CC
	private void OBBGPHPPCML_GetGroupAndRoomIds(int _AIBFGKBACCB_LobbyId, out int _INHOGJODJFJ_GroupId, out int _MALFHCHNEFN_RoomId)
	{
		_INHOGJODJFJ_GroupId = 0;
		_MALFHCHNEFN_RoomId = 0;
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null)
		{
			int lobby_id_group_mag = ev.LPJLEHAJADA_GetIntParam("lobby_id_group_mag", 1);
			int lobby_id_room_mag = ev.LPJLEHAJADA_GetIntParam("lobby_id_room_mag", 10);
			if(lobby_id_group_mag < lobby_id_room_mag)
			{
				_MALFHCHNEFN_RoomId = (_AIBFGKBACCB_LobbyId / lobby_id_room_mag) * lobby_id_room_mag;
				_INHOGJODJFJ_GroupId = (_AIBFGKBACCB_LobbyId - _MALFHCHNEFN_RoomId) / lobby_id_group_mag;
			}
			else
			{
				_INHOGJODJFJ_GroupId = (_AIBFGKBACCB_LobbyId / lobby_id_group_mag) * lobby_id_group_mag;
				_MALFHCHNEFN_RoomId = (_AIBFGKBACCB_LobbyId - _INHOGJODJFJ_GroupId) / lobby_id_room_mag;
			}
			Debug.LogError("Debug : "+lobby_id_group_mag+" "+lobby_id_room_mag+" "+_AIBFGKBACCB_LobbyId+" "+_MALFHCHNEFN_RoomId+" "+_INHOGJODJFJ_GroupId);
		}
    }

	// // RVA: 0xC20900 Offset: 0xC20900 VA: 0xC20900
	// private static void OBBGPHPPCML(int _AIBFGKBACCB_LobbyId, int BFBIEECIDIM, int IAEKNMNHCFH, out int _INHOGJODJFJ_GroupId, out int _MALFHCHNEFN_RoomId) { }

	// // RVA: 0xC20964 Offset: 0xC20964 VA: 0xC20964
	public int EEJNPNOADGC_GetGroupId(ELKMKCNPDFO _AHEFHIMGIBI_PlayerData)
	{
		int group, room;
		OBBGPHPPCML_GetGroupAndRoomIds(_AHEFHIMGIBI_PlayerData.AIBFGKBACCB_LobbyId >> 15, out group, out room);
		return group;
	}

	// // RVA: 0xC20A6C Offset: 0xC20A6C VA: 0xC20A6C
	public void LHIIGAMEABL_GetGroupAndRoomIds(ELKMKCNPDFO _AHEFHIMGIBI_PlayerData, out int _KGICDMIJGDF_Group, out int GCBDNOPCGNP)
	{
		OBBGPHPPCML_GetGroupAndRoomIds(_AHEFHIMGIBI_PlayerData.AIBFGKBACCB_LobbyId >> 15, out _KGICDMIJGDF_Group, out GCBDNOPCGNP);
	}

	// // RVA: 0xC20B28 Offset: 0xC20B28 VA: 0xC20B28
	public int EDILJHGLMNG_GetNumLobbies()
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return ev.OJGPPOKENLG_Groups.Count;
		}
        return 0;
	}

	// // RVA: 0xC20BB8 Offset: 0xC20BB8 VA: 0xC20BB8
	// public string NHACIJELHIB(int _OIPCCBHIKIA_index) { }

	// // RVA: 0xC20C7C Offset: 0xC20C7C VA: 0xC20C7C
	public string OFAKIAJNPDF_GetGroupName(int _PPFNGGCBJKC_id)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null)
		{
			Debug.LogError("Debug :"+_PPFNGGCBJKC_id);
			string s = ev.HMHGPIEBKPO_GetGroup(_PPFNGGCBJKC_id).OPFGFINHFCE_name;
			if(s != null)
				return s;
		}
        return "";
	}

	// // RVA: 0xC20D20 Offset: 0xC20D20 VA: 0xC20D20
	public int EPPBAFDEDCD_GetGroupImageId(int _OIPCCBHIKIA_index)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return ev.OJGPPOKENLG_Groups[_OIPCCBHIKIA_index].AACHOBAAALA_ImageId;
		}
		return 0;
	}

	// // RVA: 0xC20DD0 Offset: 0xC20DD0 VA: 0xC20DD0
	// public int AMCHEACNLLG(int _PPFNGGCBJKC_id) { }

	// // RVA: 0xC20E08 Offset: 0xC20E08 VA: 0xC20E08
	public int HJJBDFCMJJM_GetGroupId()
	{
		int a, b;
		int res = 0;
		if(EHLFBIEGDDF())
		{
			OBBGPHPPCML_GetGroupAndRoomIds(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId >> 15, out a, out b);
			res = a;
		}
		return res;
	}

	// // RVA: 0xC20F4C Offset: 0xC20F4C VA: 0xC20F4C
	public int GAHICKBDHFO_GetRoomId()
	{
		int a, b;
		int res = 0;
		if(EHLFBIEGDDF())
		{
			OBBGPHPPCML_GetGroupAndRoomIds(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId >> 15, out a, out b);
			res = b;
		}
		return res;
	}

	// // RVA: 0xC21090 Offset: 0xC21090 VA: 0xC21090
	public void NLIJCLIGIFC(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		NPNNPNAIONN_IsError = false;
		PLOOEECNHFB_IsDone = false;
		PIGBKEIAMPE_FriendManager.KIELKOCLIGG k = new PIGBKEIAMPE_FriendManager.KIELKOCLIGG();
		k.IPKCADIAAPG_Criteria = SakashoPlayerCriteria.NewCriteriaFromTo("lobby_id_" + PGIIDPEGGPI_EventId.ToString(), ODALKFEBNNA, LMCNAKBEBGI);
		k.MCEGJNAABHG = PFNFFKJGBMI; //base + public status + raid player
		k.IGNHNKJOCKB = (int _PPFNGGCBJKC_id, long _IFNLEKOILPM_updated_at, bool _MLEHCBKPNGK_IsFriend, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) =>
		{
			//0xC28670
			return IBIGBMDANNM.HEGEKFMJNCC<ELKMKCNPDFO>(_PPFNGGCBJKC_id, _IFNLEKOILPM_updated_at, _MLEHCBKPNGK_IsFriend, _OHNJJIMGKGK_Names, _IDLHJIOMJBK_data);
		};
		k.PHCKPOKKBGD = (IFICNCAHIGI PKLPKMLGFGK) =>
		{
			//0xC2A540
			return PKLPKMLGFGK.AHEFHIMGIBI_PlayerData.LLBECHBNIJG_EventRaidPlayer.IPLBEGCODDC(PGIIDPEGGPI_EventId);
		};
		CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.EGLFECJOPPP_SearchFriendAndFavoritePlayer(k, () =>
		{
			//0xC2A5C0
			ACCNCHJBDHM_UsersList.Clear();
			for(int i = 0; i < CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.BFDEHIANFOG.Count; i++)
			{
				ACCNCHJBDHM_UsersList.Add(CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.BFDEHIANFOG[i] as ELKMKCNPDFO);
			}
			CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.OCGEPBECHGB();
			PLOOEECNHFB_IsDone = true;
			_BHFHGFKBOHH_OnSuccess();
		}, () =>
		{
			//0xC2A840
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
			_MOBEEPPKFLG_OnFail();
		});
	}

	// // RVA: 0xC21450 Offset: 0xC21450 VA: 0xC21450
	public void EJEIHOOOBLM_JoinLobbyByPlayer(int PACBOPLFGCF, ELKMKCNPDFO EIMMNMFFBCD, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK BKLCMFMIIHF, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		N.a.StartCoroutineWatched(DFKDDOGBOHE_JoinLobbyByPlayer(PACBOPLFGCF, EIMMNMFFBCD, _BHFHGFKBOHH_OnSuccess, BKLCMFMIIHF, _MOBEEPPKFLG_OnFail));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BDC9C Offset: 0x6BDC9C VA: 0x6BDC9C
	// // RVA: 0xC214C4 Offset: 0xC214C4 VA: 0xC214C4
	private IEnumerator DFKDDOGBOHE_JoinLobbyByPlayer(int PACBOPLFGCF, ELKMKCNPDFO EIMMNMFFBCD, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK BKLCMFMIIHF, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		LDEBIBGHCGD_EventRaidLobby KHGBJCFJGMA; // 0x2C
		LBKPFADGHPK HPHNAEPLJGM; // 0x30

		//0xC2CA48
		KHGBJCFJGMA = FJLIDJJAGOM();
		if(KHGBJCFJGMA != null)
		{
			PLOOEECNHFB_IsDone = false;
			NPNNPNAIONN_IsError = false;
			int IEDKKPFGOGK = 0;
			HPHNAEPLJGM = new LBKPFADGHPK();
			int lId = EIMMNMFFBCD.AIBFGKBACCB_LobbyId;
			HPHNAEPLJGM.IPKCADIAAPG_Criteria = SakashoPlayerCriteria.NewCriteriaFromTo("lobby_id_" + PGIIDPEGGPI_EventId.ToString(), (int)(lId & 0xffff8000), (int)((lId & 0xffff8000) + 32768));
			HPHNAEPLJGM.IPKCADIAAPG_Criteria.OnlyFriends = false;
			HPHNAEPLJGM.EILKGEADKGH_Order = SakashoPlayerData.SearchOrder.UPDATED_AT_DESC;
			HPHNAEPLJGM.HHIHCJKLJFF_Names = new List<string>();
			HPHNAEPLJGM.PINPBOCDKLI_OnPlayerCb = (int _OIPCCBHIKIA_index, int _PPFNGGCBJKC_id, long _IFNLEKOILPM_updated_at, bool _MLEHCBKPNGK_IsFriend, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) =>
			{
				//0xC2A8AC
				IEDKKPFGOGK++;
				return true;
			};
			yield return Co.R(HPHNAEPLJGM.MEGIEMBDGBE_Coroutine(null, null));
			if(!HPHNAEPLJGM.NPNNPNAIONN_IsError)
			{
				int lobby_member_max = KHGBJCFJGMA.LPJLEHAJADA_GetIntParam("lobby_member_max", 50);
				if(lobby_member_max < 1 || IEDKKPFGOGK < lobby_member_max)
				{
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId = EIMMNMFFBCD.AIBFGKBACCB_LobbyId;
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LLBECHBNIJG_EventRaidPlayer.KDMPHHFADMC_ClusterId = PACBOPLFGCF;
					int lobby_member_divide = KHGBJCFJGMA.LPJLEHAJADA_GetIntParam("lobby_member_divide", 40);
					int group, room;
					OBBGPHPPCML_GetGroupAndRoomIds(EIMMNMFFBCD.AIBFGKBACCB_LobbyId >> 15, out group, out room);
					ILCCJNDFFOB.HHCJCDFCLOB.PHCLHGPCFNL(this, group, EIMMNMFFBCD.AIBFGKBACCB_LobbyId, OFAKIAJNPDF_GetGroupName(group), 0, lobby_member_divide, 
						string.Concat(new object[5]
						{
							EIMMNMFFBCD.MLPEHNBNOGD_PlayerId,
							":",
							EIMMNMFFBCD.HKAIJKGODHC,
							":",
							EIMMNMFFBCD.BBNAEPGAMMA_IsFavorite
						}));
					CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
					{
						//0xC2A8C0
						PLOOEECNHFB_IsDone = true;
						_BHFHGFKBOHH_OnSuccess();
					}, () =>
					{
						//0xC2A90C
						PLOOEECNHFB_IsDone = true;
						NPNNPNAIONN_IsError = true;
						_MOBEEPPKFLG_OnFail();
					}, null);
					yield break;
				}
				PLOOEECNHFB_IsDone = true;
				NPNNPNAIONN_IsError = true;
				BKLCMFMIIHF();
				yield break;
			}
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
		}
		else
		{
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
		}
		_MOBEEPPKFLG_OnFail();
	}

	// // RVA: 0xC215F4 Offset: 0xC215F4 VA: 0xC215F4
	public bool NNNNJJADGMH()
	{
        KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA ev = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM(), null);
        if (ev != null)
		{
			return !ev.CJALBNNJOOB_IsFl;
		}
		return false;
	}

	// // RVA: 0xC21630 Offset: 0xC21630 VA: 0xC21630
	public void NHPFMNGMMHG(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
        KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA ev = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM(), null);
		if(ev == null)
		{
			NPNNPNAIONN_IsError = true;
			PLOOEECNHFB_IsDone = true;
			_MOBEEPPKFLG_OnFail();
		}
		else
		{
			ev.CJALBNNJOOB_IsFl = true;
			NPNNPNAIONN_IsError = false;
			PLOOEECNHFB_IsDone = false;
			CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
			{
				//0xC2A970
				_BHFHGFKBOHH_OnSuccess();
				PLOOEECNHFB_IsDone = true;
			}, () =>
			{
				//0xC2A9BC
				_MOBEEPPKFLG_OnFail();
				PLOOEECNHFB_IsDone = true;
				NPNNPNAIONN_IsError = true;
			}, null);
		}
    }

	// // RVA: 0xC2182C Offset: 0xC2182C VA: 0xC2182C
	public void IIBLJMMGMPD(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		N.a.StartCoroutineWatched(FGKGCPICMDN_SearchLobbyMember(_BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BDD14 Offset: 0x6BDD14 VA: 0x6BDD14
	// // RVA: 0xC21884 Offset: 0xC21884 VA: 0xC21884
	private IEnumerator FGKGCPICMDN_SearchLobbyMember(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		LBKPFADGHPK PGPFBCAFOCO; // 0x20
		DPDMNBGAONP OANEIPHEOGA; // 0x24

		//0xC2D5B0
		PLOOEECNHFB_IsDone = false;
		NPNNPNAIONN_IsError = false;
		ACCNCHJBDHM_UsersList.Clear();
		List<int> FAMHAPONILI_PlayerIds = new List<int>();
		ELKMKCNPDFO d = new ELKMKCNPDFO();
		d.ILEBOIGEGEH();
		ACCNCHJBDHM_UsersList.Add(d);
		FAMHAPONILI_PlayerIds.Add(d.MLPEHNBNOGD_PlayerId);
		PGPFBCAFOCO = new LBKPFADGHPK();
		int lobId = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId;
		PGPFBCAFOCO.IPKCADIAAPG_Criteria = SakashoPlayerCriteria.NewCriteriaFromTo("lobby_id_" + PGIIDPEGGPI_EventId.ToString(), (int)(lobId & 0xffff8000), (int)((lobId & 0xffff8000) + 32768));
		PGPFBCAFOCO.IPKCADIAAPG_Criteria.OnlyFriends = false;
		PGPFBCAFOCO.EILKGEADKGH_Order = SakashoPlayerData.SearchOrder.UPDATED_AT_DESC;
		PGPFBCAFOCO.HHIHCJKLJFF_Names = BBHNACPENDM_ServerSaveData.KPIDBPEKMFD_GetNames(0x8000000005);
		PGPFBCAFOCO.PINPBOCDKLI_OnPlayerCb = (int _OIPCCBHIKIA_index, int _PPFNGGCBJKC_id, long _IFNLEKOILPM_updated_at, bool _MLEHCBKPNGK_IsFriend, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) =>
		{
			//0xC2AA28
			ELKMKCNPDFO e = IBIGBMDANNM.HEGEKFMJNCC<ELKMKCNPDFO>(_PPFNGGCBJKC_id, _IFNLEKOILPM_updated_at, _MLEHCBKPNGK_IsFriend, _OHNJJIMGKGK_Names, _IDLHJIOMJBK_data);
			if(e != null)
			{
				ACCNCHJBDHM_UsersList.Add(e);
				FAMHAPONILI_PlayerIds.Add(_PPFNGGCBJKC_id);
				return true;
			}
			return false;
		};
		yield return Co.R(PGPFBCAFOCO.MEGIEMBDGBE_Coroutine(null, null));
		if(!PGPFBCAFOCO.NPNNPNAIONN_IsError)
		{
			if(FAMHAPONILI_PlayerIds.Count > 0)
			{
				OANEIPHEOGA = new DPDMNBGAONP();
				OANEIPHEOGA.BIHCCEHLAOD.IHALNOJAMLE_PlayerCounterMasterName = "fan_count";
				OANEIPHEOGA.BIHCCEHLAOD.FAMHAPONILI_PlayerIds = FAMHAPONILI_PlayerIds;
				yield return Co.R(OANEIPHEOGA.MEGIEMBDGBE_Coroutine(null, null));
				if(!OANEIPHEOGA.NPNNPNAIONN_IsError)
				{
					for(int i = 0; i < ACCNCHJBDHM_UsersList.Count; i++)
					{
						int v;
						if(OANEIPHEOGA.NFEAMMJIMPG_Result.OJCNJFLJCLA_player_counters.TryGetValue(ACCNCHJBDHM_UsersList[i].MLPEHNBNOGD_PlayerId, out v))
						{
							ACCNCHJBDHM_UsersList[i].AGDBNNEAIIC_FanNum = v;
						}
					}
					PLOOEECNHFB_IsDone = true;
					_BHFHGFKBOHH_OnSuccess();
					yield break;
				}
			}
			else
			{
				PLOOEECNHFB_IsDone = true;
				_BHFHGFKBOHH_OnSuccess();
				yield break;
			}
		}
		PLOOEECNHFB_IsDone = true;
		NPNNPNAIONN_IsError = true;
		_MOBEEPPKFLG_OnFail();
	}

	// // RVA: 0xC21964 Offset: 0xC21964 VA: 0xC21964
	public void KCAJBLICFPJ(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		NPNNPNAIONN_IsError = false;
		PLOOEECNHFB_IsDone = false;
		List<int> l = new List<int>(ACCNCHJBDHM_UsersList.Count);
		List<int> l2 = new List<int>(ACCNCHJBDHM_UsersList.Count);
		for(int i = 0; i < ACCNCHJBDHM_UsersList.Count; i++)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.GAAOPEGIPKA_FavoritePlayer.FFKIDMKHIOE(ACCNCHJBDHM_UsersList[i].MLPEHNBNOGD_PlayerId))
			{
				if(!ACCNCHJBDHM_UsersList[i].BBNAEPGAMMA_IsFavorite)
				{
					l2.Add(ACCNCHJBDHM_UsersList[i].MLPEHNBNOGD_PlayerId);
				}
			}
			else if(ACCNCHJBDHM_UsersList[i].BBNAEPGAMMA_IsFavorite)
			{
				l.Add(ACCNCHJBDHM_UsersList[i].MLPEHNBNOGD_PlayerId);
			}
		}
		if(l.Count + l2.Count != 0)
		{
			CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.EPKOLKBGOGA(l, l2, () =>
			{
				//0xC2AB44
				PLOOEECNHFB_IsDone = true;
				_BHFHGFKBOHH_OnSuccess();
			}, () =>
			{
				//0xC2AB90
				PLOOEECNHFB_IsDone = true;
				NPNNPNAIONN_IsError = true;
				_MOBEEPPKFLG_OnFail();
			}, null);
		}
		else
		{
			PLOOEECNHFB_IsDone = true;
			_BHFHGFKBOHH_OnSuccess();
		}
	}

	// // RVA: 0xC21EC0 Offset: 0xC21EC0 VA: 0xC21EC0
	public void NGKIBBIEAAD()
	{
		ACCNCHJBDHM_UsersList.Clear();
	}

	// // RVA: 0xC21F38 Offset: 0xC21F38 VA: 0xC21F38
	public void LLLKDLPJHCF(int _MLPEHNBNOGD_PlayerId, Action<int, int> _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		NPNNPNAIONN_IsError = false;
		PLOOEECNHFB_IsDone = false;
		int PGIIDPEGGPI_EventId = 0;
		int AIBFGKBACCB_LobbyId = 0;
		NJNCAHLIHNI_GetPlayerData req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NJNCAHLIHNI_GetPlayerData());
		req.FAMHAPONILI_PlayerIds = new List<int>() { _MLPEHNBNOGD_PlayerId };
		req.HHIHCJKLJFF_Names = BBHNACPENDM_ServerSaveData.KPIDBPEKMFD_GetNames(0x8000000000);
		req.PINPBOCDKLI_OnPlayerCb = (int _OIPCCBHIKIA_index, int _PPFNGGCBJKC_id, long _IFNLEKOILPM_updated_at, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) =>
		{
			//0xC2ABF4
			FPPNANIIODA.KHEKNNFCAOI_Init(0x8000000000);
			if(FPPNANIIODA.IIEMACPEEBJ_Deserialize(_OHNJJIMGKGK_Names, _IDLHJIOMJBK_data))
			{
				PGIIDPEGGPI_EventId = FPPNANIIODA.LLBECHBNIJG_EventRaidPlayer.OBGBAOLONDD_UniqueId;
				AIBFGKBACCB_LobbyId = FPPNANIIODA.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId >> 15;
				return true;
			}
			return false;
		};
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request BHGCOECCPCO) =>
		{
			//0xC2ADB0
			_BHFHGFKBOHH_OnSuccess(PGIIDPEGGPI_EventId, AIBFGKBACCB_LobbyId);
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request BHGCOECCPCO) =>
		{
			//0xC2AE38
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
			_MOBEEPPKFLG_OnFail();
		};
	}

	// // RVA: 0xC22240 Offset: 0xC22240 VA: 0xC22240
	private void PLKPGEGNLFH(StringBuilder _KOHNLDKIKPC_sb, int _AIBFGKBACCB_LobbyId, FLHJEJGJJGE KLMCILEDMEL)
	{
		AHAENNIFOAF.PAMKDBAMMIE(_KOHNLDKIKPC_sb, PGIIDPEGGPI_EventId, _AIBFGKBACCB_LobbyId, KLMCILEDMEL);
	}

	// // RVA: 0xC222EC Offset: 0xC222EC VA: 0xC222EC
	public bool AFBNKKAHFCI()
	{
		return FCBCCOEBHJB != null;
	}

	// // RVA: 0xC222FC Offset: 0xC222FC VA: 0xC222FC
	public bool JHBLAGLBIAD()
	{
		return FCBCCOEBHJB != null && FCBCCOEBHJB.OKNCPELPJJO;
	}

	// // RVA: 0xC2231C Offset: 0xC2231C VA: 0xC2231C
	public bool CDCAJDEPMKN()
	{
		return FCBCCOEBHJB != null && FCBCCOEBHJB.FKPJGFFFCDG;
	}

	// // RVA: 0xC2233C Offset: 0xC2233C VA: 0xC2233C
	public void NIIEJKGNEBH_InitializeBbs()
	{
		NIIEJKGNEBH_InitializeBbs(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId >> 15);
	}

	// // RVA: 0xC2244C Offset: 0xC2244C VA: 0xC2244C
	public void NIIEJKGNEBH_InitializeBbs(int _AIBFGKBACCB_LobbyId)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null)
		{
			EGMBECGOHAE = new KKLGJPAIHJN(ev.LPJLEHAJADA_GetIntParam("bbs_news_update_interval", 60), 0);
			OKMNIPKLHHK = new KKLGJPAIHJN(ev.LPJLEHAJADA_GetIntParam("bbs_copy_interval", 15), 0);
			StringBuilder str = new StringBuilder(64);
			FCBCCOEBHJB = new OKLFOAPMJAA();
			FCBCCOEBHJB.OBKGEDCKHHE();
			KBMOEKMKGBL_ChatDatas = new OKLFOAPMJAA.BABPHOEGLPC[3];
			PLKPGEGNLFH(str, _AIBFGKBACCB_LobbyId, FLHJEJGJJGE.GGCIMLDFDOC_0_Chat);
			int bbs_comment_load_count = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA_GetIntParam("bbs_comment_load_count", 10);
			int v = KGGDENNDEAN_GetDaysLeft();
			OKLFOAPMJAA.BABPHOEGLPC b = new OKLFOAPMJAA.BABPHOEGLPC(str.ToString(), bbs_comment_load_count, bbs_comment_load_count, v, true, (ANPBHCNJIDI.NNPGLGHDBKN PIABJCEJIHC) =>
			{
				//0xC2852C
				ANPBHCNJIDI.AIFBLOAGFOP a = PIABJCEJIHC as ANPBHCNJIDI.AIFBLOAGFOP;
				if(a != null && a.LBODBHCBAMD_Vwt)
				{
					return BJMPAPCDGIG_IsLogEnabled();
				}
				return true;
			});
			b.EEBMKLOIEMB_SetAutoUpdateInterval(ev.LPJLEHAJADA_GetIntParam("bbs_auto_update_interval_main", 10));
			b.PFMOHFOOBCL(AHAENNIFOAF.IAOPMEAIHLH.IDGJGMNNJEF_0);
			KBMOEKMKGBL_ChatDatas[0] = b;
			PLKPGEGNLFH(str, _AIBFGKBACCB_LobbyId, FLHJEJGJJGE.JAFEBKBFPBB_1_Battle);
			b = new OKLFOAPMJAA.BABPHOEGLPC(str.ToString(), ev.LPJLEHAJADA_GetIntParam("bbs_battlelog_comment_load_count", 30), bbs_comment_load_count, v, false, (ANPBHCNJIDI.NNPGLGHDBKN PIABJCEJIHC) =>
			{
				//0xC28704
				return ANPBHCNJIDI.JCGBEAHDNEI_IsBattleLogMessage(PIABJCEJIHC.INDDJNMPONH_type);
			});
			b.EEBMKLOIEMB_SetAutoUpdateInterval(ev.LPJLEHAJADA_GetIntParam("bbs_auto_update_interval_battlelog", 60));
			b.PFMOHFOOBCL(AHAENNIFOAF.IAOPMEAIHLH.JBMJEOBODHH_1);
			KBMOEKMKGBL_ChatDatas[1] = b;
			PLKPGEGNLFH(str, _AIBFGKBACCB_LobbyId, FLHJEJGJJGE.CEMAJAOJBEO_2_Chapter);
			b = new OKLFOAPMJAA.BABPHOEGLPC(str.ToString(), bbs_comment_load_count, bbs_comment_load_count, v, true, null);
			b.EEBMKLOIEMB_SetAutoUpdateInterval(ev.LPJLEHAJADA_GetIntParam("bbs_auto_update_interval_memo", 10));
			b.PFMOHFOOBCL(AHAENNIFOAF.IAOPMEAIHLH.ANLJMCJAMFJ_2);
			KBMOEKMKGBL_ChatDatas[2] = b;
			KPPHGAAOMDN = new KAGMKNANHBA();
			CNCPFACLJHH = null;
		}
    }

	// // RVA: 0xC22BD0 Offset: 0xC22BD0 VA: 0xC22BD0
	private int KGGDENNDEAN_GetDaysLeft()
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return TimeSpan.FromSeconds(ev.NGHKJOEDLIP_Settings.COIHIAKHFNF_End - NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime()).Days;
		}
		return 1;
    }

	// // RVA: 0xC22D6C Offset: 0xC22D6C VA: 0xC22D6C
	private void HDAOMKFAIPP_InitChatData(FLHJEJGJJGE KLMCILEDMEL)
	{
		if(FCBCCOEBHJB == null)
		{
            FCBCCOEBHJB = new OKLFOAPMJAA();
            FCBCCOEBHJB.OBKGEDCKHHE();
        }
		if(KBMOEKMKGBL_ChatDatas == null)
		{
            KBMOEKMKGBL_ChatDatas = new OKLFOAPMJAA.BABPHOEGLPC[3];
        }
		if(KBMOEKMKGBL_ChatDatas[(int)KLMCILEDMEL] == null)
		{
            StringBuilder str = new StringBuilder(64);
            PLKPGEGNLFH(str, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId >> 15, KLMCILEDMEL);
            KBMOEKMKGBL_ChatDatas[(int)KLMCILEDMEL] = new OKLFOAPMJAA.BABPHOEGLPC(str.ToString(), KGGDENNDEAN_GetDaysLeft(), false, null);
        }
	}

	// // RVA: 0xC23040 Offset: 0xC23040 VA: 0xC23040
	public int JIDLPGHJOIE_GetCommentsCount(FLHJEJGJJGE KLMCILEDMEL)
	{
		FCBCCOEBHJB.FLFJILIIMGI_SetData(KBMOEKMKGBL_ChatDatas[(int)KLMCILEDMEL]);
		return FCBCCOEBHJB.NJMOALFKKIK_GetCommentCount();
	}

	// // RVA: 0xC230D0 Offset: 0xC230D0 VA: 0xC230D0
	public ANPBHCNJIDI.NNPGLGHDBKN GDGCADFCDCL_GetComment(FLHJEJGJJGE KLMCILEDMEL, int _OIPCCBHIKIA_index)
	{
		FCBCCOEBHJB.FLFJILIIMGI_SetData(KBMOEKMKGBL_ChatDatas[(int)KLMCILEDMEL]);
		return FCBCCOEBHJB.NOEMAKFEICB_GetComment(_OIPCCBHIKIA_index);
	}

	// // RVA: 0xC23168 Offset: 0xC23168 VA: 0xC23168
	// public int DLPCLKFKINM(NKOBMDPHNGP_EventRaidLobby.FLHJEJGJJGE KLMCILEDMEL) { }

	// // RVA: 0xC231F8 Offset: 0xC231F8 VA: 0xC231F8
	public bool BJMPAPCDGIG_IsLogEnabled()
	{
		return GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.KHBHOGEEHBA_RaidLobbyEvent.LALECMJIGPH_GetIsDisplayViewingText();
	}

	// // RVA: 0xC232FC Offset: 0xC232FC VA: 0xC232FC
	public void NLGAFNOHLID_SetLogEnabled(bool _NANNGLGOFKH_value)
	{
		GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.KHBHOGEEHBA_RaidLobbyEvent.JJDBLFAGGGK_SetIsDisplayViewingText(_NANNGLGOFKH_value);
		GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
	}

	// // RVA: 0xC23450 Offset: 0xC23450 VA: 0xC23450
	// public bool AAECCLGAMNO() { }

	// // RVA: 0xC2347C Offset: 0xC2347C VA: 0xC2347C
	public void MMMBGDHMJKC(int _KPNKPGLPDHI_Op, FLHJEJGJJGE KLMCILEDMEL, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		CLLMBGONMKE(_KPNKPGLPDHI_Op, KLMCILEDMEL, _BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail, true);
	}

	// // RVA: 0xC234A0 Offset: 0xC234A0 VA: 0xC234A0
	private void CLLMBGONMKE(int _KPNKPGLPDHI_Op, FLHJEJGJJGE KLMCILEDMEL, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, bool BELNGJDDEIB)
	{
		NPNNPNAIONN_IsError = false;
		PLOOEECNHFB_IsDone = false;
		FJHLAKJBNFA = true;
		FCBCCOEBHJB.FLFJILIIMGI_SetData(KBMOEKMKGBL_ChatDatas[(int)KLMCILEDMEL]);
		FCBCCOEBHJB.JLEFHIOELGH(_KPNKPGLPDHI_Op, () =>
		{
			//0xC287A0
			if(KLMCILEDMEL == 0)
			{
				ADENMOCKJGH();
			}
			PLOOEECNHFB_IsDone = true;
			FJHLAKJBNFA = false;
			_BHFHGFKBOHH_OnSuccess();
		}, () =>
		{
			//0xC28830
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
			FJHLAKJBNFA = false;
			_MOBEEPPKFLG_OnFail();
		}, BELNGJDDEIB);
	}

	// // RVA: 0xC236A8 Offset: 0xC236A8 VA: 0xC236A8
	public void MICOCAOLCEJ(int _KPNKPGLPDHI_Op, FLHJEJGJJGE KLMCILEDMEL, Action<List<FLHJEJGJJGE>> OKLICHHNKEA, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null)
		{
			FCBCCOEBHJB.FLFJILIIMGI_SetData(KBMOEKMKGBL_ChatDatas[(int)KLMCILEDMEL]);
			FCBCCOEBHJB.FBANBDCOEJL(_KPNKPGLPDHI_Op, () =>
			{
				//0xC288B0
				if(KLMCILEDMEL == FLHJEJGJJGE.GGCIMLDFDOC_0_Chat)
					ADENMOCKJGH();
				else
				{
					if(EGMBECGOHAE.DKMLDEDKPBA)
					{
						EGMBECGOHAE.IDAPJFGJHND();
						CLLMBGONMKE(_KPNKPGLPDHI_Op, FLHJEJGJJGE.GGCIMLDFDOC_0_Chat, () =>
						{
							//0xC28AE8
							EGMBECGOHAE.BALEALPHEEJ();
							List<FLHJEJGJJGE> l2 = new List<FLHJEJGJJGE>();
							l2.Add(KLMCILEDMEL);
							OKLICHHNKEA(l2);
						}, () =>
						{
							//0xC28C3C
							EGMBECGOHAE.BALEALPHEEJ();
							_MOBEEPPKFLG_OnFail();
						}, false);
						return;
					}
				}
				List<FLHJEJGJJGE> l = new List<FLHJEJGJJGE>();
				l.Add(KLMCILEDMEL);
				OKLICHHNKEA(l);
			}, _MOBEEPPKFLG_OnFail);
		}
    }

	// // RVA: 0xC23884 Offset: 0xC23884 VA: 0xC23884
	public void PMCMAKBNJIL()
	{
		FCBCCOEBHJB.MFFPEIEMGGM();
	}

	// // RVA: 0xC238B0 Offset: 0xC238B0 VA: 0xC238B0
	public bool MIKMNNCEFBH(FLHJEJGJJGE KLMCILEDMEL)
	{
		FCBCCOEBHJB.FLFJILIIMGI_SetData(KBMOEKMKGBL_ChatDatas[(int)KLMCILEDMEL]);
		return FCBCCOEBHJB.JFLNJEIOFDE();
	}

	// // RVA: 0xC23940 Offset: 0xC23940 VA: 0xC23940
	public void DJEEPILBAIH(FLHJEJGJJGE KLMCILEDMEL, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		NPNNPNAIONN_IsError = false;
		PLOOEECNHFB_IsDone = false;
		FCBCCOEBHJB.FLFJILIIMGI_SetData(KBMOEKMKGBL_ChatDatas[(int)KLMCILEDMEL]);
		FJHLAKJBNFA = true;
		FCBCCOEBHJB.HDHACKFJKGM(0, () =>
		{
			//0xC28CA0
			PLOOEECNHFB_IsDone = true;
			FJHLAKJBNFA = false;
			_BHFHGFKBOHH_OnSuccess();
		}, () =>
		{
			//0xC28D08
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
			FJHLAKJBNFA = false;
			_MOBEEPPKFLG_OnFail();
		});
	}

	// // RVA: 0xC23B18 Offset: 0xC23B18 VA: 0xC23B18
	public bool CCIKMMPIMHD()
	{
		return FCBCCOEBHJB.ONOLJCIOKOC();
	}

	// // RVA: 0xC23B44 Offset: 0xC23B44 VA: 0xC23B44
	public void HJNDLPNBBKF(FLHJEJGJJGE KLMCILEDMEL, ANPBHCNJIDI.NNPGLGHDBKN _HCAHCFGPJIF_Desc, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, DJBHIFLHJLK NKGHADCBGJO)
	{
		NPNNPNAIONN_IsError = false;
		PLOOEECNHFB_IsDone = false;
		FJHLAKJBNFA = true;
		FCBCCOEBHJB.FLFJILIIMGI_SetData(KBMOEKMKGBL_ChatDatas[(int)KLMCILEDMEL]);
		FCBCCOEBHJB.NPIBJOGODKG(0, _HCAHCFGPJIF_Desc, () =>
		{
			//0xC28D88
			PLOOEECNHFB_IsDone = true;
			FJHLAKJBNFA = false;
			_BHFHGFKBOHH_OnSuccess();
		}, () =>
		{
			//0xC28DF0
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
			FJHLAKJBNFA = false;
			_MOBEEPPKFLG_OnFail();
		}, () =>
		{
			//0xC28E70
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
			FJHLAKJBNFA = false;
			NKGHADCBGJO();
		});
	}

	// // RVA: 0xC23D64 Offset: 0xC23D64 VA: 0xC23D64
	public void CADBGOEBMEO(FLHJEJGJJGE KLMCILEDMEL, ANPBHCNJIDI.NNPGLGHDBKN _HCAHCFGPJIF_Desc, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		NPNNPNAIONN_IsError = false;
		PLOOEECNHFB_IsDone = false;
		FCBCCOEBHJB.FLFJILIIMGI_SetData(KBMOEKMKGBL_ChatDatas[(int)KLMCILEDMEL]);
		FJHLAKJBNFA = true;
		FCBCCOEBHJB.HCMMMCFFGCA_UpdateThreadComment(_HCAHCFGPJIF_Desc, () =>
		{
			//0xC28EE4
			PLOOEECNHFB_IsDone = true;
			FJHLAKJBNFA = false;
			_BHFHGFKBOHH_OnSuccess();
		}, () =>
		{
			//0xC28F4C
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
			FJHLAKJBNFA = false;
			_MOBEEPPKFLG_OnFail();
		});
	}

	// // RVA: 0xC23F40 Offset: 0xC23F40 VA: 0xC23F40
	// public void CKONNBGNAKG(NKOBMDPHNGP_EventRaidLobby.FLHJEJGJJGE KLMCILEDMEL, ANPBHCNJIDI.NNPGLGHDBKN _HCAHCFGPJIF_Desc, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail) { }

	// // RVA: 0xC24114 Offset: 0xC24114 VA: 0xC24114
	public void NKLFDHJKIII(FLHJEJGJJGE KLMCILEDMEL, int _MLPEHNBNOGD_PlayerId, int LCJEPKENHCE, Action<bool> _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		NPNNPNAIONN_IsError = false;
		PLOOEECNHFB_IsDone = false;
		FCBCCOEBHJB.FLFJILIIMGI_SetData(KBMOEKMKGBL_ChatDatas[(int)KLMCILEDMEL]);
		FCBCCOEBHJB.DADODHBGLKP(0, LCJEPKENHCE, (List<ANPBHCNJIDI.NNPGLGHDBKN> CEGPFLLDBGM) =>
		{
			//0xC2907C
			if(LCJEPKENHCE < CEGPFLLDBGM.Count)
			{
				CEGPFLLDBGM = CEGPFLLDBGM.GetRange(0, LCJEPKENHCE);
			}
			ANPBHCNJIDI.NNPGLGHDBKN m = CEGPFLLDBGM.Find((ANPBHCNJIDI.NNPGLGHDBKN PIABJCEJIHC) =>
			{
				//0xC2920C
				return PIABJCEJIHC.MLPEHNBNOGD_PlayerId == _MLPEHNBNOGD_PlayerId;
			});
			PLOOEECNHFB_IsDone = true;
			_BHFHGFKBOHH_OnSuccess(m != null);
		}, () =>
		{
			//0xC29244
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
			_MOBEEPPKFLG_OnFail();
		});
	}

	// // RVA: 0xC24328 Offset: 0xC24328 VA: 0xC24328
	// private int AIIPLCEICBM(ANPBHCNJIDI.NOJONDLAMOC _INDDJNMPONH_type) { }

	// // RVA: 0xC24330 Offset: 0xC24330 VA: 0xC24330
	public string ABGDJKLFBKL_GetMessageContent(ANPBHCNJIDI.PHICILDLHJP _HCAHCFGPJIF_Desc, PKNOKJNLPOE_EventRaid AIOGBKCJLHM)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null)
		{
			StringBuilder str1 = new StringBuilder(32);
            str1.SetFormat("battlelog_text_{0:D2}", (int)_HCAHCFGPJIF_Desc.INDDJNMPONH_type - 2);
			StringBuilder str2 = new StringBuilder(64);
			if(_HCAHCFGPJIF_Desc.INDDJNMPONH_type == ANPBHCNJIDI.NOJONDLAMOC.JPOGBMJKPIJ_5_FullCombo)
			{
                ANPBHCNJIDI.JLHGKKIEALB m = _HCAHCFGPJIF_Desc as ANPBHCNJIDI.JLHGKKIEALB;
                StringBuilder str5 = new StringBuilder(16);
                str5.Set(Difficulty.Name[m.AKNELONELJK_difficulty]);
				if(m.GIKLNODJKFK_IsLine6)
				{
                    str5.Append("+");
                }
                string s = DatabaseTextConverter.TranslateLobbyMessage(JOPOPMLFINI_QuestName, str1.ToString(), ""); //ev.EFEGBHACJAL_GetStringParam(str1.ToString(), "");
                str2.SetFormat(s, Database.Instance.musicText.Get(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(m.ADHMMMEOJMK_FreeMusicId).DLAEJOBELBH_MusicId).KNMGEEFGDNI_Name).musicName, str5.ToString());
				if(m.IGNJCGMLBDA_Defeat)
				{
                    str1.SetFormat("battlelog_text_{0:D2}", 1);
                    str2.Append(JpStringLiterals.StringLiteral_5812);
                    str2.AppendFormat(DatabaseTextConverter.TranslateLobbyMessage(JOPOPMLFINI_QuestName, str1.ToString(), "")/*ev.EFEGBHACJAL_GetStringParam(str1.ToString(), "")*/, AIOGBKCJLHM.AGEJGHGEGFF_GetBossName(m.MFMPCHIJINJ_BossType), m.HALIDDHLNEG_Damage);
                }
            }
			else if(_HCAHCFGPJIF_Desc.INDDJNMPONH_type == ANPBHCNJIDI.NOJONDLAMOC.JDGLJOFPHLK_4_MaccrossCannon)
			{
                ANPBHCNJIDI.NBHIMCACDHM m = _HCAHCFGPJIF_Desc as ANPBHCNJIDI.NBHIMCACDHM;
                str2.SetFormat(DatabaseTextConverter.TranslateLobbyMessage(JOPOPMLFINI_QuestName, str1.ToString(), "")/*ev.EFEGBHACJAL_GetStringParam(str1.ToString(), "")*/, m.HALIDDHLNEG_Damage);
				if(m.IGNJCGMLBDA_Defeat)
				{
                    str1.SetFormat(DatabaseTextConverter.TranslateLobbyMessage(JOPOPMLFINI_QuestName, "battlelog_text_04", "")/*"battlelog_text_04"*/, Array.Empty<object>());
                    str2.Append(JpStringLiterals.StringLiteral_5812);
                    str2.Append(ev.EFEGBHACJAL_GetStringParam(str1.ToString(), ""));
                }
            }
			else if(_HCAHCFGPJIF_Desc.INDDJNMPONH_type == ANPBHCNJIDI.NOJONDLAMOC.CGEPNIOPFHF_3_DefeatBoss)
			{
                ANPBHCNJIDI.KNGOGLLMKDL m = _HCAHCFGPJIF_Desc as ANPBHCNJIDI.KNGOGLLMKDL;
                str2.SetFormat(DatabaseTextConverter.TranslateLobbyMessage(JOPOPMLFINI_QuestName, str1.ToString(), "")/*ev.EFEGBHACJAL_GetStringParam(str1.ToString(), "")*/, AIOGBKCJLHM.AGEJGHGEGFF_GetBossName(m.MFMPCHIJINJ_BossType), m.HALIDDHLNEG_Damage);
            }
            return str2.ToString();
        }
        return "";
    }

	// // RVA: 0xC24BEC Offset: 0xC24BEC VA: 0xC24BEC
	public void EGBFCCFICIF(PEDPKDBKGIN _PIBLLGLCJEO_Param, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		PLOOEECNHFB_IsDone = false;
		NPNNPNAIONN_IsError = false;
        ANPBHCNJIDI.PHICILDLHJP HCAHCFGPJIF_Desc = null;
        if(!_PIBLLGLCJEO_Param.INLLJNOMNGF_CannonAttack)
		{
			if(!_PIBLLGLCJEO_Param.NANEGCHBEDN_IsFullCombo || _PIBLLGLCJEO_Param.DKKJPLALNFD_Skip)
			{
                if (_PIBLLGLCJEO_Param.IGNJCGMLBDA_Defeat)
                {
					ANPBHCNJIDI.KNGOGLLMKDL m = new ANPBHCNJIDI.KNGOGLLMKDL();
                    m.HALIDDHLNEG_Damage = _PIBLLGLCJEO_Param.HALIDDHLNEG_Damage;
                    m.MFMPCHIJINJ_BossType = _PIBLLGLCJEO_Param.MFMPCHIJINJ_BossType;
                    HCAHCFGPJIF_Desc = m;
                }
            }
			else
			{
				ANPBHCNJIDI.JLHGKKIEALB m = new ANPBHCNJIDI.JLHGKKIEALB();
                m.ADHMMMEOJMK_FreeMusicId = _PIBLLGLCJEO_Param.ADHMMMEOJMK_FreeMusicId;
                m.AKNELONELJK_difficulty = _PIBLLGLCJEO_Param.AKNELONELJK_difficulty;
                m.GIKLNODJKFK_IsLine6 = _PIBLLGLCJEO_Param.GIKLNODJKFK_IsLine6;
				if(_PIBLLGLCJEO_Param.IGNJCGMLBDA_Defeat)
				{
					m.HALIDDHLNEG_Damage = _PIBLLGLCJEO_Param.HALIDDHLNEG_Damage;
                    m.MFMPCHIJINJ_BossType = _PIBLLGLCJEO_Param.MFMPCHIJINJ_BossType;
                }
                HCAHCFGPJIF_Desc = m;
            }
		}
		else
		{
            ANPBHCNJIDI.NBHIMCACDHM m = new ANPBHCNJIDI.NBHIMCACDHM();
            m.IGNJCGMLBDA_Defeat = _PIBLLGLCJEO_Param.IGNJCGMLBDA_Defeat;
            m.HALIDDHLNEG_Damage = _PIBLLGLCJEO_Param.HALIDDHLNEG_Damage;
            m.GJAOLNLFEBD_BossName = _PIBLLGLCJEO_Param.GJAOLNLFEBD_BossName;
            m.EJGDHAENIDC_BossRank = _PIBLLGLCJEO_Param.EJGDHAENIDC_BossRank;
            m.PCPODOMOFDH_BossSerieAttr = _PIBLLGLCJEO_Param.PCPODOMOFDH_BossSerieAttr;
            m.JNBDLNBKDCO_BossImage = _PIBLLGLCJEO_Param.JNBDLNBKDCO_BossImage;
            m.KKPAHLMJKIH_WavId = _PIBLLGLCJEO_Param.JPOIGNNOHJP_WavId;
            m.IKICLMGFFPB_IsSpecial = _PIBLLGLCJEO_Param.IKICLMGFFPB_IsSpecial;
            m.CNOHJPEHHCH_StampId = NMMKHNDOEFB();
            HCAHCFGPJIF_Desc = m;
        }
		if(HCAHCFGPJIF_Desc == null)
		{
			PLOOEECNHFB_IsDone = true;
            _BHFHGFKBOHH_OnSuccess();
        }
		else
		{
            bool CKIIGKKHDMP_Auto = GOENGHBLHDB(HCAHCFGPJIF_Desc);
            HCAHCFGPJIF_Desc.PCEHLFNFIDA(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData);
            HCAHCFGPJIF_Desc.EBBJPBGHJOL_text = ABGDJKLFBKL_GetMessageContent(HCAHCFGPJIF_Desc, _PIBLLGLCJEO_Param.AIOGBKCJLHM);
			if(CKIIGKKHDMP_Auto)
			{
                HCAHCFGPJIF_Desc.PHGNPFJIBLF_Name = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JHFIPCIHJNL_Base.OPFGFINHFCE_name;
                HCAHCFGPJIF_Desc.ICFCJOEMIIJ_Id = NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId;
            }
            HDAOMKFAIPP_InitChatData(FLHJEJGJJGE.JAFEBKBFPBB_1_Battle);
            HJNDLPNBBKF(FLHJEJGJJGE.JAFEBKBFPBB_1_Battle, HCAHCFGPJIF_Desc, () =>
			{
				//0xC29484
				if(!CKIIGKKHDMP_Auto)
				{
					PLOOEECNHFB_IsDone = true;
                    _BHFHGFKBOHH_OnSuccess();
                }
				else
				{
                    HCAHCFGPJIF_Desc.PCEHLFNFIDA(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData);
                    HCAHCFGPJIF_Desc.CKIIGKKHDMP_Auto = true;
                    HDAOMKFAIPP_InitChatData(FLHJEJGJJGE.GGCIMLDFDOC_0_Chat);
					HJNDLPNBBKF(FLHJEJGJJGE.GGCIMLDFDOC_0_Chat, HCAHCFGPJIF_Desc, () =>
					{
                        //0xC292A8
                        PLOOEECNHFB_IsDone = true;
                        _BHFHGFKBOHH_OnSuccess();
                    }, () =>
					{
                        //0xC292F4
                        PLOOEECNHFB_IsDone = true;
                        NPNNPNAIONN_IsError = true;
                        _MOBEEPPKFLG_OnFail();
                    }, () =>
					{
                        //0xC29358
                        PLOOEECNHFB_IsDone = true;
                        NPNNPNAIONN_IsError = true;
                        _MOBEEPPKFLG_OnFail();
                    });
                }
			}, () =>
			{
                //0xC293BC
                PLOOEECNHFB_IsDone = true;
                NPNNPNAIONN_IsError = true;
                _MOBEEPPKFLG_OnFail();
            }, () =>
			{
                //0xC29420
                PLOOEECNHFB_IsDone = true;
                NPNNPNAIONN_IsError = true;
                _MOBEEPPKFLG_OnFail();
            });
        }
	}

	// // RVA: 0xC255D8 Offset: 0xC255D8 VA: 0xC255D8
	private bool GOENGHBLHDB(ANPBHCNJIDI.NNPGLGHDBKN _HCAHCFGPJIF_Desc)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null && _HCAHCFGPJIF_Desc != null)
		{
			ANPBHCNJIDI.NBHIMCACDHM m = _HCAHCFGPJIF_Desc as ANPBHCNJIDI.NBHIMCACDHM;
			if(m != null)
			{
				int bbs_auto_copy_mcannon_damage = ev.LPJLEHAJADA_GetIntParam("bbs_auto_copy_mcannon_damage", 20000);
				return m.IGNJCGMLBDA_Defeat && m.IKICLMGFFPB_IsSpecial && bbs_auto_copy_mcannon_damage <= m.HALIDDHLNEG_Damage;
			}
		}
        return false;
	}

	// // RVA: 0xC2570C Offset: 0xC2570C VA: 0xC2570C
	// public bool APMIOHBDCPP() { }

	// // RVA: 0xC25748 Offset: 0xC25748 VA: 0xC25748
	public void MKIBMJCPHKI(BFFHCHKDHJM KBCBGIGOLHP)
	{
		CNCPFACLJHH = KBCBGIGOLHP;
	}

	// // RVA: 0xC25750 Offset: 0xC25750 VA: 0xC25750
	public void BLDACFKPCGM()
	{
		CNCPFACLJHH = null;
	}

	// // RVA: 0xC2575C Offset: 0xC2575C VA: 0xC2575C
	private void ADENMOCKJGH()
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null)
		{
			KPPHGAAOMDN.HCAHCFGPJIF_Desc = null;
			FCBCCOEBHJB.FLFJILIIMGI_SetData(KBMOEKMKGBL_ChatDatas[0]);
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			long l = t - ev.LPJLEHAJADA_GetIntParam("bbs_news_search_time", 180);
			long saveV = GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.KHBHOGEEHBA_RaidLobbyEvent.HJEMMCMEKED_GetNewsletterUpdateAt();
			if(l < saveV)
				l = saveV;
			for(int i = 0; i < FCBCCOEBHJB.KJFPHBPJDDF(); i++)
			{
                ANPBHCNJIDI.NNPGLGHDBKN m = FCBCCOEBHJB.JMBDOIIIDJH(i);
                if (l >= m.EKEGHNPNCEH_UpdateAt)
				{
					break;
				}
				ANPBHCNJIDI.PHICILDLHJP m2 = m as ANPBHCNJIDI.PHICILDLHJP;
				if(m2 != null && m2.CKIIGKKHDMP_Auto && GOENGHBLHDB(m2))
				{
					KPPHGAAOMDN.HCAHCFGPJIF_Desc = m as ANPBHCNJIDI.NBHIMCACDHM;
					CNCPFACLJHH(KPPHGAAOMDN);
					break;
				}
			}
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.KHBHOGEEHBA_RaidLobbyEvent.AGCAONIMNAL_SetNewsletterUpdateAt(t);
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
		}
    }

	// // RVA: 0xC263A4 Offset: 0xC263A4 VA: 0xC263A4
	public void JCCAPHGLOJF_GetBbsBattleLogMacrossCannonStamp(int LGPGAPNGBGG, Action<List<ANPBHCNJIDI.BNEIDPGIAFM>> _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		N.a.StartCoroutineWatched(GPBFKOMIAAG_Corotuine_GetBbsBattleLogMacrossCannonStamp(LGPGAPNGBGG, _BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BDDAC Offset: 0x6BDDAC VA: 0x6BDDAC
	// // RVA: 0xC2640C Offset: 0xC2640C VA: 0xC2640C
	private IEnumerator GPBFKOMIAAG_Corotuine_GetBbsBattleLogMacrossCannonStamp(int LGPGAPNGBGG, Action<List<ANPBHCNJIDI.BNEIDPGIAFM>> _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		//0xC2BB74
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev == null)
		{
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
			_MOBEEPPKFLG_OnFail();
		}
		else
		{
			NPNNPNAIONN_IsError = false;
			PLOOEECNHFB_IsDone = false;
			FCBCCOEBHJB.FLFJILIIMGI_SetData(KBMOEKMKGBL_ChatDatas[1]);
			int bbs_mcannon_stamp_comment_min = ev.LPJLEHAJADA_GetIntParam("bbs_mcannon_stamp_comment_min", 90);
			FCBCCOEBHJB.DADODHBGLKP(0, bbs_mcannon_stamp_comment_min, (List<ANPBHCNJIDI.NNPGLGHDBKN> CEGPFLLDBGM) =>
			{
				//0xC297F4
				List<ANPBHCNJIDI.BNEIDPGIAFM> l = new List<ANPBHCNJIDI.BNEIDPGIAFM>(CEGPFLLDBGM.Count);
				CEGPFLLDBGM.ForEach((ANPBHCNJIDI.NNPGLGHDBKN PIABJCEJIHC) =>
				{
					//0xC29A08
					ANPBHCNJIDI.BNEIDPGIAFM m = PIABJCEJIHC as ANPBHCNJIDI.BNEIDPGIAFM;
					if(m != null)
					{
						if(m.GKEKNMJMMPK_CannonLogId != LGPGAPNGBGG)
							return;
						l.Add(m);
					}
				});
				PLOOEECNHFB_IsDone = true;
				_BHFHGFKBOHH_OnSuccess(l);
			}, () =>
			{
				//0xC299A4
				PLOOEECNHFB_IsDone = true;
				NPNNPNAIONN_IsError = true;
				_MOBEEPPKFLG_OnFail();
			});
		}
		yield break;
    }

	// // RVA: 0xC253C8 Offset: 0xC253C8 VA: 0xC253C8
	public static int NMMKHNDOEFB()
	{
        NIGIOKLMJIH.SetFormat("{0}_{1}", NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime(), NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId);
        return NIGIOKLMJIH.ToString().GetHashCode();
    }

	// // RVA: 0xC26500 Offset: 0xC26500 VA: 0xC26500
	public bool ABNLPDNFHDN()
	{
		return OKMNIPKLHHK.DKMLDEDKPBA;
	}

	// // RVA: 0xC2652C Offset: 0xC2652C VA: 0xC2652C
	public void CBOFAFKMIBE_CopyBbsBattleLogCommentToMain(ANPBHCNJIDI.PHICILDLHJP _HCAHCFGPJIF_Desc, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		N.a.StartCoroutineWatched(LKNPBAGDJDF_Coroutine_CopyBbsBattleLogCommentToMain(_HCAHCFGPJIF_Desc, _BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BDE24 Offset: 0x6BDE24 VA: 0x6BDE24
	// // RVA: 0xC26594 Offset: 0xC26594 VA: 0xC26594
	private IEnumerator LKNPBAGDJDF_Coroutine_CopyBbsBattleLogCommentToMain(ANPBHCNJIDI.PHICILDLHJP _HCAHCFGPJIF_Desc, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		//0xC2C548
		PLOOEECNHFB_IsDone = false;
		NPNNPNAIONN_IsError = false;
		bool FDOJOGIMHMF = false;
		bool JCGDKLJEPKJ = false;
		OKMNIPKLHHK.IDAPJFGJHND();
		_HCAHCFGPJIF_Desc.PHGNPFJIBLF_Name = _HCAHCFGPJIF_Desc.OPFGFINHFCE_name;
		_HCAHCFGPJIF_Desc.ICFCJOEMIIJ_Id = _HCAHCFGPJIF_Desc.MLPEHNBNOGD_PlayerId;
		if(_HCAHCFGPJIF_Desc.JOIOJMONLFL_IsWritterSelf)
		{
			CADBGOEBMEO(FLHJEJGJJGE.JAFEBKBFPBB_1_Battle, _HCAHCFGPJIF_Desc, () =>
			{
				//0xC29B0C
				PLOOEECNHFB_IsDone = false;
				FDOJOGIMHMF = true;
			}, () =>
			{
				//0xC29B40
				OKMNIPKLHHK.BALEALPHEEJ();
				FDOJOGIMHMF = true;
				JCGDKLJEPKJ = true;
				_MOBEEPPKFLG_OnFail();
			});
			while(!FDOJOGIMHMF)
				yield return null;
			if(JCGDKLJEPKJ)
				yield break;
		}
		//LAB_00c2c814
		_HCAHCFGPJIF_Desc.PCEHLFNFIDA(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData);
		HJNDLPNBBKF(FLHJEJGJJGE.GGCIMLDFDOC_0_Chat, _HCAHCFGPJIF_Desc, () =>
		{
			//0xC29BAC
			OKMNIPKLHHK.BALEALPHEEJ();
			PLOOEECNHFB_IsDone = true;
			_BHFHGFKBOHH_OnSuccess();
		}, () =>
		{
			//0xC29C2C
			OKMNIPKLHHK.BALEALPHEEJ();
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
			_MOBEEPPKFLG_OnFail();
		}, () =>
		{
			//0xC29CC4
			OKMNIPKLHHK.BALEALPHEEJ();
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
			_MOBEEPPKFLG_OnFail();
		});
	}

	// // RVA: 0xC2668C Offset: 0xC2668C VA: 0xC2668C Slot: 16
	protected override bool FHKCEPMCGCK()
	{
		return EHLFBIEGDDF();
	}

	// // RVA: 0xC26690 Offset: 0xC26690 VA: 0xC26690 Slot: 15
	protected override int KFNINHEJCLF()
	{
		return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId >> 15;
	}

	// // RVA: 0xC26794 Offset: 0xC26794 VA: 0xC26794
	// public bool JFIACOLOCBN() { }

	// // RVA: 0xC26A0C Offset: 0xC26A0C VA: 0xC26A0C
	public void PBPBEMJGIJK()
	{
		GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.KHBHOGEEHBA_RaidLobbyEvent.IDIHHKNAIJG_SetCoopQuestUpdateAt(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
		GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
	}

	// // RVA: 0xC26BCC Offset: 0xC26BCC VA: 0xC26BCC
	public List<AKIIJBEJOEP> MHGAHHPGGAE_GetMisions()
	{
		List<AKIIJBEJOEP> l = new List<AKIIJBEJOEP>();
		long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		for(int i = 0; i < AGLILDLEFDK_Missions.Count; i++)
		{
			if(t >= AGLILDLEFDK_Missions[i].KJBGCLPMLCG_OpenedAt && t < AGLILDLEFDK_Missions[i].GJFPFFBAKGK_CloseAt)
			{
				l.Add(AGLILDLEFDK_Missions[i]);
			}
		}
		l.Sort((AKIIJBEJOEP _HKICMNAACDA_a, AKIIJBEJOEP _BNKHBCBJBKI_b) =>
		{
			//0xC28730
			return _HKICMNAACDA_a.EILKGEADKGH_Order.CompareTo(_BNKHBCBJBKI_b.EILKGEADKGH_Order);
		});
		return l;
	}

	// // RVA: 0xC26F60 Offset: 0xC26F60 VA: 0xC26F60
	public bool PCLDCIAKCGO()
	{
        KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA ev = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM(), null);
		if(ev != null)
			return ev.BOKPBNGHOGM;
        return false;
	}

	// // RVA: 0xC26F90 Offset: 0xC26F90 VA: 0xC26F90
	public void OBIDIBBDEKM(bool _OAFPGJLCNFM_cond)
	{
        KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA ev = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM(), null);
		if(ev != null)
			ev.BOKPBNGHOGM = _OAFPGJLCNFM_cond;
	}

	// // RVA: 0xC26FC4 Offset: 0xC26FC4 VA: 0xC26FC4
	public int IFDJALILEOF()
	{
        KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA ev = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM(), null);
		if(ev != null)
		{
			return ev.LAGLPDDLMCK;
		}
        return 0;
	}

	// // RVA: 0xC26FF4 Offset: 0xC26FF4 VA: 0xC26FF4
	public void MCPEJDANIAL(int _IADNLGMIHDK_IsStarted)
	{
        KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA ev = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM(), null);
		if(ev != null)
		{
			ev.LAGLPDDLMCK = _IADNLGMIHDK_IsStarted;
		}
	}

	// // RVA: 0xC27028 Offset: 0xC27028 VA: 0xC27028
	public bool KLEEKOAFIIK(bool _FBBNPFFEJBN_Force)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			if(t >= ev.NGHKJOEDLIP_Settings.CJPMLAIFCDL_LobbyStart)
			{
				if(t < ev.NGHKJOEDLIP_Settings.COIHIAKHFNF_End)
				{
					if(_FBBNPFFEJBN_Force || NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD != IFDJALILEOF())
					{
						MCPEJDANIAL(NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD);
						for(int i = 0; i < ev.NNMPGOAGEOL_quests.Count; i++)
						{
							if(ev.NNMPGOAGEOL_quests[i].PPCFIHMDMLM)
							{
								if(ev.NNMPGOAGEOL_quests[i].OFKCGMNFGKB(t))
								{
									OBIDIBBDEKM(true);
									return true;
								}
							}
						}
						OBIDIBBDEKM(false);
					}
				}
			}
		}
        return false;
	}

	// // RVA: 0xC27304 Offset: 0xC27304 VA: 0xC27304
	public GDNGPJINPDK IBDNMIFLEKK(NGHEKBHLBAN _INDDJNMPONH_type/* = 0*/)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null)
		{
            FIPGKDJHKCH_Phase phase = CHDNDNMHJHI_GetPhase();
            if (phase != FIPGKDJHKCH_Phase.HJNNKCMLGFL_0_None)
			{
				List<LDEBIBGHCGD_EventRaidLobby.LNECBHIKKHK> l = new List<LDEBIBGHCGD_EventRaidLobby.LNECBHIKKHK>(ev.OIIMJFCBFFG_LobbyGuide.Count);
				for(int i = 0; i < ev.OIIMJFCBFFG_LobbyGuide.Count; i++)
				{
					if(_INDDJNMPONH_type == NGHEKBHLBAN.CFBJGAGBJEN_0 || ev.OIIMJFCBFFG_LobbyGuide[i].INDDJNMPONH_type == (int)_INDDJNMPONH_type && ev.OIIMJFCBFFG_LobbyGuide[i].GJNIPHMPMIC_Phase == (int)phase)
					{
						l.Add(ev.OIIMJFCBFFG_LobbyGuide[i]);
					}
				}
				int v = UnityEngine.Random.Range(0, l.Count);
				GDNGPJINPDK g = new GDNGPJINPDK();
				g.FDBOPFEOENF_diva = l[v].FDBOPFEOENF_diva;
				g.IJLLIGENJCI_Pic = l[v].MJMPANIBFED_pid;
				g.LJGOOOMOMMA_message = l[v].LICPCDCLOIO_Message;
				return g;
			}
		}
    	return null;
	}

	// // RVA: 0xC275F4 Offset: 0xC275F4 VA: 0xC275F4
	public int EHGKMLPCDBM_GetItemCount(RaidItemConstants.Type _INDDJNMPONH_type, BBHNACPENDM_ServerSaveData _AHEFHIMGIBI_PlayerData)
	{
        KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA ev = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM(), _AHEFHIMGIBI_PlayerData);
		if(ev != null)
		{
			return ev.KAINPNMMAEK_GetItemCount(_INDDJNMPONH_type);
		}
        return 0;
	}

	// // RVA: 0xC27634 Offset: 0xC27634 VA: 0xC27634
	public void NCBELAFIPDN_SetItemCount(RaidItemConstants.Type _INDDJNMPONH_type, int _HMFFHLPNMPH_count, BBHNACPENDM_ServerSaveData _AHEFHIMGIBI_PlayerData)
	{
        KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA ev = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM(), _AHEFHIMGIBI_PlayerData);
		if(ev != null)
		{
			ev.PPJAGFPBFHJ_SetItemCount(_INDDJNMPONH_type, _HMFFHLPNMPH_count);
		}
	}

	// // RVA: 0xC27674 Offset: 0xC27674 VA: 0xC27674
	public int ONKKHPKHCIA_GetNumTicket()
	{
		return EHGKMLPCDBM_GetItemCount(RaidItemConstants.Type.FoldRadar, null);
	}

	// // RVA: 0xC27690 Offset: 0xC27690 VA: 0xC27690
	// public List<int> ACNLOIIGPLL() { }

	// // RVA: 0xC27698 Offset: 0xC27698 VA: 0xC27698
	public static int ADPMLOEOAFD_GetTicketId()
	{
		return RaidItemConstants.MakeItemId(RaidItemConstants.Type.FoldRadar);
	}

	// // RVA: 0xC276A4 Offset: 0xC276A4 VA: 0xC276A4
	public static string GPNELLFNPLA()
	{
		return EKLNMHFCAOI.INCKKODFJAP_GetItemName(RaidItemConstants.MakeItemId(RaidItemConstants.Type.FoldRadar));
	}

	// // RVA: 0xC1E674 Offset: 0xC1E674 VA: 0xC1E674
	private void MALEKMPDKKF()
	{
		OKGDAODFFBF_FoldRadarDivaBonusList.Clear();
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null)
		{
			string fold_radar_diva_bonus_list = ev.EFEGBHACJAL_GetStringParam("fold_radar_diva_bonus_list", "6,7");
			if(!string.IsNullOrEmpty(fold_radar_diva_bonus_list))
			{
				string[] strs = fold_radar_diva_bonus_list.Split(new char[] { ',' });
				for(int i = 0; i < strs.Length; i++)
				{
					int v;
					if(int.TryParse(strs[i], out v))
					{
						OKGDAODFFBF_FoldRadarDivaBonusList.Add(v);
					}
				}
			}
		}
    }

	// // RVA: 0xC27760 Offset: 0xC27760 VA: 0xC27760
	public void KCEDMGFCOAE(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, string _MDADLCOCEBN_session_id, int _FCLGIPFPIPH_DashBonus)
	{
		FDGMLPLCALF = 0;
		if(OMNOFMEBLAD.MNNHHJBBICA_GameEventType != 11 && OMNOFMEBLAD.KLCIIHKFPPO_StoryMusicId < 1)
		{
            LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
			if(ev != null)
        	{
				int v = GGPLIBIPHLI(OMNOFMEBLAD.AKNELONELJK_difficulty);
				if(v > 0)
				{
					int fold_radar_diva_bonus_value = ev.LPJLEHAJADA_GetIntParam("fold_radar_diva_bonus_value", 50);
					for(int i = 0; i < GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas.Count; i++)
					{
						if(GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[i] != null)
						{
							if(OKGDAODFFBF_FoldRadarDivaBonusList.Contains(GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[i].AHHJLDLAPAN_DivaId))
							{
								v = (fold_radar_diva_bonus_value + 100) * v / 100;
								break;
							}
						}
					}
					FDGMLPLCALF = v / 100000;
					int v2 = UnityEngine.Random.Range(0, 100000);
					if(v2 < v)
						FDGMLPLCALF++;
					if(FDGMLPLCALF > 0)
					{
						if(1 < _FCLGIPFPIPH_DashBonus)
						{
							FDGMLPLCALF *= _FCLGIPFPIPH_DashBonus;
						}
						AKGAFHKMFOO(FDGMLPLCALF, OMNOFMEBLAD, _MDADLCOCEBN_session_id);
					}
				}
			}
		}
	}

	// // RVA: 0xC27A58 Offset: 0xC27A58 VA: 0xC27A58
	private int GGPLIBIPHLI(int _AKNELONELJK_difficulty/* = 0*/)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null)
		{
			StringBuilder str = new StringBuilder(64);
            FIPGKDJHKCH_Phase phase = CHDNDNMHJHI_GetPhase();
			if(phase == FIPGKDJHKCH_Phase.OLCLJKOKJCD_3_End)
			{
				str.Set("fold_radar_get_end_");
			}
			else if(phase == FIPGKDJHKCH_Phase.ECAAJMPLIPG_2_Now)
			{
				str.Set("fold_radar_get_appearance_");
			}
			else if(phase == FIPGKDJHKCH_Phase.KJNKFFJBPIH_1_Before)
			{
				str.Set("fold_radar_get_preparation_");
			}
			str.Append(_AKNELONELJK_difficulty + 1);
			return ev.LPJLEHAJADA_GetIntParam(str.ToString(), 50000);
        }
        return 0;
	}

	// // RVA: 0xC27EE0 Offset: 0xC27EE0 VA: 0xC27EE0
	public bool AKNOOLKMEGJ()
	{
		return GGPLIBIPHLI(0) > 0;
	}

	// // RVA: 0xC27F04 Offset: 0xC27F04 VA: 0xC27F04
	public void OMNKLDDHNNE()
	{
        KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA ev = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM(), null);
		if(ev != null)
			ev.KMMJMDGLIFA_FrCns = 1;
    }

	// // RVA: 0xC27F34 Offset: 0xC27F34 VA: 0xC27F34
	public bool LDEPDKGNAPK()
	{
        KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA save = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM(), null);
		if(save != null)
		{
			return save.KMMJMDGLIFA_FrCns != 0;
		}
		return false;
    }

	// // RVA: 0xC27F74 Offset: 0xC27F74 VA: 0xC27F74
	public void DOCCMMJMJMP()
	{
        KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA save = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM(), null);
		if(save != null)
		{
			save.KMMJMDGLIFA_FrCns = 0;
		}
    }

	// // RVA: 0xC27FA4 Offset: 0xC27FA4 VA: 0xC27FA4
	public void IMBLLJAEMAI_UseTicket(int _HMFFHLPNMPH_count)
	{
        KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA save = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM(), null);
    	if(save != null)
		{
			int a = save.KAINPNMMAEK_GetItemCount(RaidItemConstants.Type.FoldRadar);
			a -= _HMFFHLPNMPH_count;
			if(a < 0)
				a = 0;
			save.PPJAGFPBFHJ_SetItemCount(RaidItemConstants.Type.FoldRadar, a);
			save.KMMJMDGLIFA_FrCns = 0;
		}
	}

	// // RVA: 0xC28010 Offset: 0xC28010 VA: 0xC28010
	// public void GFIJEBKPANK(int _HMFFHLPNMPH_count) { }

	// // RVA: 0xC27BAC Offset: 0xC27BAC VA: 0xC27BAC
	public void AKGAFHKMFOO(int _HMFFHLPNMPH_count, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, string _MDADLCOCEBN_session_id)
	{
		StringBuilder str = new StringBuilder();
		str.Append(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId);
		str.Append(':');
		if(!OMNOFMEBLAD.LFGNLKKFOCD_IsLine6)
		{
			str.Append(FOCPLKMMCAL.PKFJIIJJMGL[(int)OMNOFMEBLAD.AKNELONELJK_difficulty]);
		}
		else
		{
			str.Append(FOCPLKMMCAL.LKMFBMPKEGN[(int)OMNOFMEBLAD.AKNELONELJK_difficulty]);
		}
		str.Append(_MDADLCOCEBN_session_id);
		JANMJPOKLFL_InventoryUtil.JCHLONCMPAJ();
		JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.IMJOELNOOMB_0, str.ToString());
		JANMJPOKLFL_InventoryUtil.CPIICACGNBH_AddItem(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, RaidItemConstants.MakeItemId(RaidItemConstants.Type.FoldRadar), _HMFFHLPNMPH_count, null, 0);
	}

	// // RVA: 0xC28134 Offset: 0xC28134 VA: 0xC28134
	public void KHGKJMODLDE(int _HMFFHLPNMPH_count)
	{
		JANMJPOKLFL_InventoryUtil.JCHLONCMPAJ();
		JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.KGOOLKLPJIP_39, PGIIDPEGGPI_EventId.ToString());
		JANMJPOKLFL_InventoryUtil.CPIICACGNBH_AddItem(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, RaidItemConstants.MakeItemId(RaidItemConstants.Type.FoldRadar), _HMFFHLPNMPH_count, null, 0);
	}

	// // RVA: 0xC20510 Offset: 0xC20510 VA: 0xC20510
	public int PDNFHDLNENO(int _PPFNGGCBJKC_id)
	{
		LDEBIBGHCGD_EventRaidLobby ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as LDEBIBGHCGD_EventRaidLobby;
		if(ev != null)
		{
			int cluster = DKNNNOIMMFN_GetClusterId();
			int v = cluster / 60 + _PPFNGGCBJKC_id * 32768;
			if(cluster < 60)
				v = _PPFNGGCBJKC_id << 15;
			return v;
		}
		return 0;
	}

	// // RVA: 0xC282B0 Offset: 0xC282B0 VA: 0xC282B0
	public int DKNNNOIMMFN_GetClusterId()
	{
		LDEBIBGHCGD_EventRaidLobby ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as LDEBIBGHCGD_EventRaidLobby;
		if(ev != null)
		{
			int v = (int)(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime() - ev.NGHKJOEDLIP_Settings.NIMLIMFPNJP_RaidStart);
			return v;
		}
		return 0;
	}

	// // RVA: 0xC207B8 Offset: 0xC207B8 VA: 0xC207B8
	public static int FAKHCOJIOBD(int _PPFNGGCBJKC_id, int NEFEFHBHFFF/* = 1*/)
	{
		int res = _PPFNGGCBJKC_id << 15;
		if(NEFEFHBHFFF > -1)
			res = _PPFNGGCBJKC_id >> 15;
		return res;
	}
}
