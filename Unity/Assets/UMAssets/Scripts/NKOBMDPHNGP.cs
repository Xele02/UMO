
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
		HJNNKCMLGFL_0 = 0,
		KJNKFFJBPIH_1_Before = 1,
		ECAAJMPLIPG_2_Now = 2,
		OLCLJKOKJCD_3_End = 3,
	}

	public class ELKMKCNPDFO : IFICNCAHIGI
	{
		public bool HKAIJKGODHC; // 0x4D

		public int AIBFGKBACCB_LobbyId { get { return AHEFHIMGIBI_ServerData.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId; } } //0xC20A28 NAFFGDLBDGJ
		// public int KDMPHHFADMC { get; } 0xC2DF38 PNGFNKNGGHI

		// // RVA: 0xC2DF7C Offset: 0xC2DF7C VA: 0xC2DF7C Slot: 4
		public override bool EDEDFDDIOKO(int PPFNGGCBJKC, long IFNLEKOILPM, bool MLEHCBKPNGK, List<string> OHNJJIMGKGK, EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			BBHNACPENDM_ServerSaveData b = new BBHNACPENDM_ServerSaveData();
			b.KHEKNNFCAOI_Init(0x8000000005);
			HKAIJKGODHC = MLEHCBKPNGK;
			return NLENMNMCJCJ(PPFNGGCBJKC, IFNLEKOILPM, MLEHCBKPNGK, OHNJJIMGKGK, IDLHJIOMJBK, b);
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
		public int ADHMMMEOJMK_FreeSongId; // 0xC
		public int AKNELONELJK_Difficulty; // 0x10
		public int MFMPCHIJINJ_BossType; // 0x14
		public string GJAOLNLFEBD_BossName; // 0x18
		public int EJGDHAENIDC_BossRank; // 0x1C
		public int JPOIGNNOHJP_WavId; // 0x20
		public int PCPODOMOFDH_BossSerieAttr; // 0x24
		public int JNBDLNBKDCO_BossImage; // 0x28
		public bool GIKLNODJKFK_Line6; // 0x2C
		public bool IKICLMGFFPB; // 0x2D
		public bool IGNJCGMLBDA_Defeat; // 0x2E
		public bool INLLJNOMNGF_CannonAttack; // 0x2F
		public bool NANEGCHBEDN_IsFullCombo; // 0x30
		public PKNOKJNLPOE_EventRaid AIOGBKCJLHM; // 0x34
		public bool DKKJPLALNFD_Skip; // 0x38
	}

	public class KAGMKNANHBA
	{
		public ANPBHCNJIDI.NBHIMCACDHM HCAHCFGPJIF; // 0x8

		// public bool DNJGAJPIIPI { get; } 0xC25738 GALFPKKIGBH

		// // RVA: 0xC25B70 Offset: 0xC25B70 VA: 0xC25B70
		// public void LHPDDGIJKNB() { }
	}

	public delegate void BFFHCHKDHJM(KAGMKNANHBA PNNCCHGFCME);

	public class GDNGPJINPDK
	{
		public int FDBOPFEOENF_Id; // 0x8
		public int IJLLIGENJCI_Pic; // 0xC
		public string LJGOOOMOMMA_Message; // 0x10
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
	private EECOJKDJIFG KBACNOCOANM; // 0xF0
	private BBHNACPENDM_ServerSaveData FPPNANIIODA = new BBHNACPENDM_ServerSaveData(); // 0xF4
	public List<ELKMKCNPDFO> ACCNCHJBDHM_Users = new List<ELKMKCNPDFO>(100); // 0xF8
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
	public override EECOJKDJIFG DAKMIKNKHMF_GetRankingInfoForIndex(int LHJCOPMMIGO = 0)
	{
		return KBACNOCOANM;
	}

	// RVA: 0xC1E3D0 Offset: 0xC1E3D0 VA: 0xC1E3D0
	public NKOBMDPHNGP_EventRaidLobby(string OPFGFINHFCE) : base(OPFGFINHFCE)
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
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId);
		if(db != null)
		{
			return db as LDEBIBGHCGD_EventRaidLobby;
		}
		return null;
	}

	// // RVA: 0xC1E85C Offset: 0xC1E85C VA: 0xC1E85C
	// private KBAGKBIBGPM.JAIFDODKMIA KNKJHNJFONJ(BBHNACPENDM KGPIPDHHNPK) { }

	// // RVA: 0xC1E87C Offset: 0xC1E87C VA: 0xC1E87C
	private KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA KNKJHNJFONJ_GetEvSave(LDEBIBGHCGD_EventRaidLobby NDFIEMPPMLF, BBHNACPENDM_ServerSaveData BGEPKJCKKGF)
	{
		if(NDFIEMPPMLF == null)
			return null;
		if(BGEPKJCKKGF == null)
		{
			BGEPKJCKKGF = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave;
		}
		return BGEPKJCKKGF.PJCMHDEJLGF_EventRaidLobby.FBCJICEPLED[NDFIEMPPMLF.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
	}

	// // RVA: 0xC1E9B8 Offset: 0xC1E9B8 VA: 0xC1E9B8 Slot: 27
	public override int HLOGNJNGDJO_GetHelpId(int OIPCCBHIKIA = 0)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev == null)
			return 0;
		return ev.NGHKJOEDLIP.EJBGHLOOLBC_HelpIds[OIPCCBHIKIA];
    }

	// // RVA: 0xC1EA28 Offset: 0xC1EA28 VA: 0xC1EA28 Slot: 30
	protected override bool JIHMLILFOPG_IsEventActive(long JHNMKKNEENE)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
        if (ev != null)
		{
			GDIPLANPCEI g = IMMAOANGPNK.HHCJCDFCLOB.ACEFBFLFKFD_GetScheduleEventData(ev.JIKKNHIAEKG_BlockName, JHNMKKNEENE);
			if(g != null)
			{
				return JHNMKKNEENE >= ev.NGHKJOEDLIP.CJPMLAIFCDL_LobbyStart && JHNMKKNEENE <= ev.NGHKJOEDLIP.COIHIAKHFNF_End;
			}
		}
		return false;
	}

	// // RVA: 0xC1EB64 Offset: 0xC1EB64 VA: 0xC1EB64 Slot: 31
	protected override bool IMCMNOPNGHO(long JHNMKKNEENE)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null)
		{
			AGLILDLEFDK_Missions = ev.NNMPGOAGEOL_Missions;
			KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA k = KNKJHNJFONJ_GetEvSave(ev, null);
			OLDFFDMPEBM_Quests = k.NNMPGOAGEOL_Quests;
			bool b = true;
			if(k.EGBOHDFBAPB_End >= ev.NGHKJOEDLIP.CJPMLAIFCDL_LobbyStart || RuntimeSettings.CurrentSettings.UnlimitedEvent)
			{
				b = k.MPCAGEPEJJJ_Key != ev.OJGPPOKENLG_Groups[0].HEDAGCNPHGD_Key || CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LLBECHBNIJG_EventRaidPlayer.OBGBAOLONDD != ev.NGHKJOEDLIP.OBGBAOLONDD_EventId;
			}
			if(b)
			{
				k.LHPDDGIJKNB();
				k.MPCAGEPEJJJ_Key = ev.OJGPPOKENLG_Groups[0].HEDAGCNPHGD_Key;
				k.EGBOHDFBAPB_End = ev.NGHKJOEDLIP.COIHIAKHFNF_End;
				KOMAHOAEMEK(true);
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LLBECHBNIJG_EventRaidPlayer.KHEKNNFCAOI_Init(ev.NGHKJOEDLIP.OBGBAOLONDD_EventId);
			}
			KOMAHOAEMEK(false);
			return true;
		}
        return false;
	}

	// // RVA: 0xC1EE14 Offset: 0xC1EE14 VA: 0xC1EE14 Slot: 40
	protected override void KKFLDCBHFJA(long JHNMKKNEENE)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null)
		{
			DGCOMDILAKM_EventName = ev.NGHKJOEDLIP.OPFGFINHFCE_Name;
			GLIMIGNNGGB_Start = ev.NGHKJOEDLIP.CJPMLAIFCDL_LobbyStart;
			EMEKFFHCHMH_End = ev.NGHKJOEDLIP.COIHIAKHFNF_End;
			JDDFILGNGFH = ev.NGHKJOEDLIP.COIHIAKHFNF_End;
			LJOHLEGGGMC = ev.NGHKJOEDLIP.COIHIAKHFNF_End;
			DPJCPDKALGI_End1 = ev.NGHKJOEDLIP.COIHIAKHFNF_End;
			LOLAANGCGDO = ev.NGHKJOEDLIP.COIHIAKHFNF_End;
			PGIIDPEGGPI_EventId = ev.NGHKJOEDLIP.OBGBAOLONDD_EventId;
			NHGPCLGPEHH_TicketType = ev.NGHKJOEDLIP.MJBKGOJBPAD_TicketType;
			PJLNJJIBFBN = true;
			FBHONHONKGD_MusicSelectDesc = "";
			LEPALMDKEOK_IsPointReward = false;
			for(int i = 0; i < KPOMHFLKMKI_LastRankUpdateTime.Length; i++)
			{
				KPOMHFLKMKI_LastRankUpdateTime[i] = 0;
			}
		}
    }

	// // RVA: 0xC1EFB4 Offset: 0xC1EFB4 VA: 0xC1EFB4 Slot: 46
	protected override void PJDGDNJNCNM_UpdateStatusImpl(long JHNMKKNEENE)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null)
		{
			IBLPKJJNNIG = false;
			BELBNINIOIE = false;
			NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DOAENCHBAEO_11;
			if(JHNMKKNEENE < ev.NGHKJOEDLIP.COIHIAKHFNF_End)
				NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MINDIGBAJFG_3;
		}
		else
		{
			NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HJNNKCMLGFL_0;
		}
    }

	// // RVA: 0xC1F014 Offset: 0xC1F014 VA: 0xC1F014 Slot: 28
	public override long FBGDBGKNKOD_GetCurrentPoint()
	{
		return 0;
	}

	// // RVA: 0xC1F020 Offset: 0xC1F020 VA: 0xC1F020 Slot: 26
	public override bool KKFEDJNIAAG(long JHNMKKNEENE)
	{
		return false;
	}

	// // RVA: 0xC1F028 Offset: 0xC1F028 VA: 0xC1F028
	public JKOHBJPCAJL.CNNCBDKIPGE ILCPALOKKHC_GetStep()
	{
        KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA ev = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM(), null);
        if (ev != null)
		{
			return (JKOHBJPCAJL.CNNCBDKIPGE)ev.LGADCGFMLLD_Step;
		}
        return 0;
	}

	// // RVA: 0xC1F058 Offset: 0xC1F058 VA: 0xC1F058
	// public void MPCPIMOACHJ(JKOHBJPCAJL.CNNCBDKIPGE LGADCGFMLLD) { }

	// // RVA: 0xC1F08C Offset: 0xC1F08C VA: 0xC1F08C Slot: 70
	public override void ADACMHAHHKC_PreSetupEventHome(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		N.a.StartCoroutineWatched(NJIEIJJMAHK_Corotuine_PreSetupEventHome(BHFHGFKBOHH, AOCANKOMKFG));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BDB34 Offset: 0x6BDB34 VA: 0x6BDB34
	// // RVA: 0xC1F0E4 Offset: 0xC1F0E4 VA: 0xC1F0E4
	private IEnumerator NJIEIJJMAHK_Corotuine_PreSetupEventHome(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		long IBCGNDADAEE; // 0x20
		LDEBIBGHCGD_EventRaidLobby KEHCNBNPJHB; // 0x28

		//0xC2BF08
		IBCGNDADAEE = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		LPFJADHHLHG = false;
		KEHCNBNPJHB = FJLIDJJAGOM();
		if(KEHCNBNPJHB == null)
		{
			PLOOEECNHFB = true;
			NPNNPNAIONN = true;
			if(AOCANKOMKFG != null)
				AOCANKOMKFG();
			yield break;
		}
		PJDGDNJNCNM_UpdateStatusImpl(IBCGNDADAEE);
		MJFKJHJJLMN_GetRanks(0, false);
		while(!PLOOEECNHFB)
			yield return null;
		if(NPNNPNAIONN)
		{
			//LAB_00c2c2bc
			AOCANKOMKFG();
		}
		else
		{
            KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA k = KNKJHNJFONJ_GetEvSave(KEHCNBNPJHB, null);
            if (FKKDIDMGLMI)
			{
				JHHBAFKMBDL.HHCJCDFCLOB.PEIONAKEPCN_ShowRankingBanPopup(AOCANKOMKFG);
				yield break;
			}
			if(IBCGNDADAEE >= KEHCNBNPJHB.NGHKJOEDLIP.NIMLIMFPNJP_RaidStart)
			{
				if(KEHCNBNPJHB.NGHKJOEDLIP.KCBGBFMGHPA_End >= IBCGNDADAEE)
				{
					if(k.LGADCGFMLLD_Step != 4)
						k.LGADCGFMLLD_Step = 3;
				}
				else
				{
					if(k.LGADCGFMLLD_Step != 6)
						k.LGADCGFMLLD_Step = 5;
				}
			}
			else
			{
				if(k.LGADCGFMLLD_Step != 2)
					k.LGADCGFMLLD_Step = 1;
			}
			CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
			{
				//0xC29D64
				ILCCJNDFFOB.HHCJCDFCLOB.DADNPOJNIBL(this);
				if(BHFHGFKBOHH != null)
					BHFHGFKBOHH();
				PLOOEECNHFB = true;
			}, () =>
			{
				//0xC29E3C
				if(AOCANKOMKFG != null)
					AOCANKOMKFG();
				PLOOEECNHFB = true;
				NPNNPNAIONN = true;
			}, null);
		}
	}

	// // RVA: 0xC1F1C0 Offset: 0xC1F1C0 VA: 0xC1F1C0 Slot: 69
	// public override void HAAEJDGMICH(LBNLAENLPNK.JEKODBEDOMM INDDJNMPONH, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0xC1F2E8 Offset: 0xC1F2E8 VA: 0xC1F2E8 Slot: 71
	public override int BAEPGOAMBDK(string LJNAKDMILMC, int MNCOAGOKNAO)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
        if (ev != null)
		{
			return ev.LPJLEHAJADA(LJNAKDMILMC, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0xC1F320 Offset: 0xC1F320 VA: 0xC1F320 Slot: 72
	public override string MAICAKMIBEM(string LJNAKDMILMC, string MNCOAGOKNAO)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
        if (ev != null)
		{
			return ev.EFEGBHACJAL(LJNAKDMILMC, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0xC1F358 Offset: 0xC1F358 VA: 0xC1F358 Slot: 75
	public override string FEKEBPKINIM_GetSessionId()
	{
        KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA k = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM(), null);
        return k != null ? k.MDADLCOCEBN_SessionId : "";
	}

	// // RVA: 0xC1F3D0 Offset: 0xC1F3D0 VA: 0xC1F3D0
	public bool EMPOBKBHLAC(long JHNMKKNEENE)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null && !ANOPCGFIMEJ())
		{
			if(JHNMKKNEENE >= ev.NGHKJOEDLIP.NIMLIMFPNJP_RaidStart)
			{
				return JHNMKKNEENE < ev.NGHKJOEDLIP.KCBGBFMGHPA_End;
			}
		}
        return false;
	}

	// // RVA: 0xC1F4DC Offset: 0xC1F4DC VA: 0xC1F4DC
	public FIPGKDJHKCH_Phase KINIOEOOCAA_GetPhase(long JHNMKKNEENE)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev == null)
			return FIPGKDJHKCH_Phase.HJNNKCMLGFL_0;
		if(JHNMKKNEENE >= ev.NGHKJOEDLIP.CJPMLAIFCDL_LobbyStart)
		{
			if(JHNMKKNEENE < ev.NGHKJOEDLIP.NIMLIMFPNJP_RaidStart)
				return FIPGKDJHKCH_Phase.KJNKFFJBPIH_1_Before;
		}
		if(JHNMKKNEENE < ev.NGHKJOEDLIP.NIMLIMFPNJP_RaidStart)
		{
			return FIPGKDJHKCH_Phase.OLCLJKOKJCD_3_End;
		}
		if(JHNMKKNEENE >= ev.NGHKJOEDLIP.KCBGBFMGHPA_End)
		{
			return FIPGKDJHKCH_Phase.OLCLJKOKJCD_3_End;
		}
		return FIPGKDJHKCH_Phase.ECAAJMPLIPG_2_Now;
    }

	// // RVA: 0xC1F5A8 Offset: 0xC1F5A8 VA: 0xC1F5A8
	// public void COBCHBMMFPB(out long PDBPFJJCADD, out long FDBNFFNFOND) { }

	// // RVA: 0xC1F618 Offset: 0xC1F618 VA: 0xC1F618
	public void IICLCPIPENB_GetRaidTime(out long PDBPFJJCADD, out long FDBNFFNFOND)
	{
		PDBPFJJCADD = 0;
		FDBNFFNFOND = 0;
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev == null)
			return;
		PDBPFJJCADD = ev.NGHKJOEDLIP.NIMLIMFPNJP_RaidStart;
		FDBNFFNFOND = ev.NGHKJOEDLIP.KCBGBFMGHPA_End;
    }

	// // RVA: 0xC1F688 Offset: 0xC1F688 VA: 0xC1F688
	public int IICHMBONEIE_GetDayBefore(long JHNMKKNEENE)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
        DateTime dateStart = Utility.GetLocalDateTime(ev.NGHKJOEDLIP.NIMLIMFPNJP_RaidStart);
		DateTime dateCur = Utility.GetLocalDateTime(JHNMKKNEENE);
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
	public int MKACADAOPEI_GetDayNow(long JHNMKKNEENE)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
        DateTime dateStart = Utility.GetLocalDateTime(ev.NGHKJOEDLIP.KCBGBFMGHPA_End);
		DateTime dateCur = Utility.GetLocalDateTime(JHNMKKNEENE);
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
	public int PIFFFLDOJKJ_GetDayAfter(long JHNMKKNEENE)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
        DateTime dateStart = Utility.GetLocalDateTime(ev.NGHKJOEDLIP.COIHIAKHFNF_End);
		DateTime dateCur = Utility.GetLocalDateTime(JHNMKKNEENE);
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
			if(k.LGADCGFMLLD_Step >= 1 && k.LGADCGFMLLD_Step < 7)
			{
				return new FIPGKDJHKCH_Phase[] {
					FIPGKDJHKCH_Phase.KJNKFFJBPIH_1_Before,
					FIPGKDJHKCH_Phase.KJNKFFJBPIH_1_Before,
					FIPGKDJHKCH_Phase.ECAAJMPLIPG_2_Now,
					FIPGKDJHKCH_Phase.ECAAJMPLIPG_2_Now,
					FIPGKDJHKCH_Phase.OLCLJKOKJCD_3_End,
					FIPGKDJHKCH_Phase.OLCLJKOKJCD_3_End
				} [(int)k.LGADCGFMLLD_Step - 1];
			}
		}
        return FIPGKDJHKCH_Phase.HJNNKCMLGFL_0;
	}

	// // RVA: 0xC1F45C Offset: 0xC1F45C VA: 0xC1F45C
	public bool ANOPCGFIMEJ()
	{
        KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA k = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM(), null);
		if(k != null)
		{
			return k.LGADCGFMLLD_Step == 1 || k.LGADCGFMLLD_Step == 3 || k.LGADCGFMLLD_Step == 5;
		}
		return false;
	}

	// // RVA: 0xC1FD44 Offset: 0xC1FD44 VA: 0xC1FD44
	public void EGIHAHOCKPK()
	{
        KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA k = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM(), null);
		if(k != null)
		{
			if(k.LGADCGFMLLD_Step == 1)
				k.LGADCGFMLLD_Step = 2;
			if(k.LGADCGFMLLD_Step == 3)
				k.LGADCGFMLLD_Step = 4;
			if(k.LGADCGFMLLD_Step == 5)
				k.LGADCGFMLLD_Step = 6;
		}
	}

	// // RVA: 0xC1FDD4 Offset: 0xC1FDD4 VA: 0xC1FDD4
	public bool MCJFAACGLCB()
	{
        KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA save = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM(), null);
        if (save != null)
		{
			if(save.LGADCGFMLLD_Step == 4)
			{
				return true;
			}
		}
		return false;
	}

	// // RVA: 0xC1FE14 Offset: 0xC1FE14 VA: 0xC1FE14
	// private int OKEOHFMGPNG(long HMFFHLPNMPH, int JGEEFPKHHCH, int IIJMIIBLDKJ) { }

	// // RVA: 0xC1FE54 Offset: 0xC1FE54 VA: 0xC1FE54
	public int OKEOHFMGPNG_GetRoomId(long _FJOLNJLLJEJ_Position, int _JGEEFPKHHCH_Capacity, List<int> IIJMIIBLDKJ)
	{
		long l = _FJOLNJLLJEJ_Position - 1;
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
		TodoLogger.LogError(TodoLogger.ToCheck, "check this / % "+_FJOLNJLLJEJ_Position+" "+_JGEEFPKHHCH_Capacity+" "+IIJMIIBLDKJ.Count+" "+start+" "+l+" "+IIJMIIBLDKJ[idx]+" "+roomId);
		return roomId;
	}

	// // RVA: 0xC20004 Offset: 0xC20004 VA: 0xC20004
	public bool EHLFBIEGDDF()
	{
		return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LLBECHBNIJG_EventRaidPlayer.IPLBEGCODDC(PGIIDPEGGPI_EventId);
	}

	// // RVA: 0xC200EC Offset: 0xC200EC VA: 0xC200EC
	public void DEJFFGKLNHP(int FAEPBBLLANI, int DDFDEEAHCEP, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev == null)
		{
			NPNNPNAIONN = true;
			PLOOEECNHFB = true;
			MOBEEPPKFLG();
		}
		else
		{
			NPNNPNAIONN = false;
			PLOOEECNHFB = false;
			N.a.StartCoroutineWatched(JNPBHMMILOP_Corotuine_DecideLobbyPrepare(DDFDEEAHCEP, ev.OJGPPOKENLG_Groups[FAEPBBLLANI], BHFHGFKBOHH, MOBEEPPKFLG));
		}
    }

	// [IteratorStateMachineAttribute] // RVA: 0x6BDBAC Offset: 0x6BDBAC VA: 0x6BDBAC
	// // RVA: 0xC20218 Offset: 0xC20218 VA: 0xC20218
	private IEnumerator JNPBHMMILOP_Corotuine_DecideLobbyPrepare(int DDFDEEAHCEP, LDEBIBGHCGD_EventRaidLobby.HDFAGGBJGAA KGICDMIJGDF, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
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
		ELOGHEDOIGC = KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK.Find((EECOJKDJIFG HKICMNAACDA) =>
		{
			//0xC29E9C
			return HKICMNAACDA.OCGFKMHNEOF_NameForApi == KGICDMIJGDF.HEDAGCNPHGD_Key;
		});
		if(ELOGHEDOIGC != null)
		{
			//LAB_00c2b500
			for(FHACAEAHPIA = 0; FHACAEAHPIA < HOJHFFNMJEK; FHACAEAHPIA++)
			{
				long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				NMBJNEPMHOO = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new FPFPJKJNOFK_UpdateRankingScore());
				NMBJNEPMHOO.EMPNJPMAKBF_Id = ELOGHEDOIGC.PPFNGGCBJKC_Id;
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
						N.a.StartCoroutineWatched(AEPPBBLPBPE_Corotuine_DecideLobby(DDFDEEAHCEP, KGICDMIJGDF, BHFHGFKBOHH, MOBEEPPKFLG));
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
							PLOOEECNHFB = true;
							NPNNPNAIONN = true;
							MOBEEPPKFLG();
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
			Debug.LogError("Raid lobby ranking not found : "+KGICDMIJGDF.HEDAGCNPHGD_Key);
		}
		PLOOEECNHFB = true;
		NPNNPNAIONN = true;
		MOBEEPPKFLG();
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BDC24 Offset: 0x6BDC24 VA: 0x6BDC24
	// // RVA: 0xC20330 Offset: 0xC20330 VA: 0xC20330
	private IEnumerator AEPPBBLPBPE_Corotuine_DecideLobby(int _DDFDEEAHCEP_ClusterId, LDEBIBGHCGD_EventRaidLobby.HDFAGGBJGAA KGICDMIJGDF, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		//0xC2AEA0
        LDEBIBGHCGD_EventRaidLobby NDFIEMPPMLF = FJLIDJJAGOM();
		int lobby_ranking_wait = NDFIEMPPMLF.LPJLEHAJADA("lobby_ranking_wait", 3);
		if(lobby_ranking_wait > 0)
		{
			yield return new WaitForSeconds(lobby_ranking_wait);
		}
		KKLGENJKEBN.HHCJCDFCLOB.HEOKADCEAGL_GetRanks(KGICDMIJGDF.HEDAGCNPHGD_Key, () =>
		{
			//0xC29F54
			int lobby_member_divide = NDFIEMPPMLF.LPJLEHAJADA("lobby_member_divide", 40);
			int v = OKEOHFMGPNG_GetRoomId(KKLGENJKEBN.HHCJCDFCLOB.LPPCNCMEDFA_Rank, lobby_member_divide, KGICDMIJGDF.OCDBMHBNLEF);
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId = CHPLIGDOMLI_GetLobbyId(KGICDMIJGDF.PPFNGGCBJKC_GroupId, v);
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LLBECHBNIJG_EventRaidPlayer.KDMPHHFADMC_ClusterId = _DDFDEEAHCEP_ClusterId;
			ILCCJNDFFOB.HHCJCDFCLOB.PHCLHGPCFNL(this, KGICDMIJGDF.PPFNGGCBJKC_GroupId, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId, 
				OFAKIAJNPDF_GetGroupName(KGICDMIJGDF.PPFNGGCBJKC_GroupId), (int)KKLGENJKEBN.HHCJCDFCLOB.LPPCNCMEDFA_Rank, lobby_member_divide, "");
			CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
			{
				//0xC2A314
				PLOOEECNHFB = true;
				BHFHGFKBOHH();
			}, () =>
			{
				//0xC2A360
				PLOOEECNHFB = true;
				NPNNPNAIONN = true;
				MOBEEPPKFLG();
			}, null);
		}, () =>
		{
			//0xC2A3C4
			PLOOEECNHFB = true;
			NPNNPNAIONN = true;
			MOBEEPPKFLG();
		}, () =>
		{
			//0xC2A428
			PLOOEECNHFB = true;
			NPNNPNAIONN = true;
			MOBEEPPKFLG();
		}, () =>
		{
			//0xC2A48C
			JHHBAFKMBDL.HHCJCDFCLOB.PEIONAKEPCN_ShowRankingBanPopup(MOBEEPPKFLG);
		});
    }

	// // RVA: 0xC20448 Offset: 0xC20448 VA: 0xC20448
	private int CHPLIGDOMLI_GetLobbyId(int INHOGJODJFJ, int MALFHCHNEFN)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null)
		{
			int lobbyId = PDNFHDLNENO(ev.LPJLEHAJADA("lobby_id_room_mag", 10) * MALFHCHNEFN + ev.LPJLEHAJADA("lobby_id_group_mag", 1) * INHOGJODJFJ) + 1;
			Debug.LogError("lobbyId "+lobbyId+" "+INHOGJODJFJ+" "+MALFHCHNEFN);
			return lobbyId;
		}
        return 0;
	}

	// // RVA: 0xC20690 Offset: 0xC20690 VA: 0xC20690
	// public void OBBGPHPPCML(out int INHOGJODJFJ, out int MALFHCHNEFN) { }

	// // RVA: 0xC207CC Offset: 0xC207CC VA: 0xC207CC
	private void OBBGPHPPCML_GetGroupAndRoomIds(int AIBFGKBACCB, out int INHOGJODJFJ, out int MALFHCHNEFN)
	{
		INHOGJODJFJ = 0;
		MALFHCHNEFN = 0;
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null)
		{
			int lobby_id_group_mag = ev.LPJLEHAJADA("lobby_id_group_mag", 1);
			int lobby_id_room_mag = ev.LPJLEHAJADA("lobby_id_room_mag", 10);
			if(lobby_id_group_mag < lobby_id_room_mag)
			{
				MALFHCHNEFN = (AIBFGKBACCB / lobby_id_room_mag) * lobby_id_room_mag;
				INHOGJODJFJ = (AIBFGKBACCB - MALFHCHNEFN) / lobby_id_group_mag;
			}
			else
			{
				INHOGJODJFJ = (AIBFGKBACCB / lobby_id_group_mag) * lobby_id_group_mag;
				MALFHCHNEFN = (AIBFGKBACCB - INHOGJODJFJ) / lobby_id_room_mag;
			}
			Debug.LogError("Debug : "+lobby_id_group_mag+" "+lobby_id_room_mag+" "+AIBFGKBACCB+" "+MALFHCHNEFN+" "+INHOGJODJFJ);
		}
    }

	// // RVA: 0xC20900 Offset: 0xC20900 VA: 0xC20900
	// private static void OBBGPHPPCML(int AIBFGKBACCB, int BFBIEECIDIM, int IAEKNMNHCFH, out int INHOGJODJFJ, out int MALFHCHNEFN) { }

	// // RVA: 0xC20964 Offset: 0xC20964 VA: 0xC20964
	public int EEJNPNOADGC_GetGroupId(ELKMKCNPDFO AHEFHIMGIBI)
	{
		int group, room;
		OBBGPHPPCML_GetGroupAndRoomIds(AHEFHIMGIBI.AIBFGKBACCB_LobbyId >> 15, out group, out room);
		return group;
	}

	// // RVA: 0xC20A6C Offset: 0xC20A6C VA: 0xC20A6C
	public void LHIIGAMEABL_GetGroupAndRoomIds(ELKMKCNPDFO AHEFHIMGIBI, out int KGICDMIJGDF, out int GCBDNOPCGNP)
	{
		OBBGPHPPCML_GetGroupAndRoomIds(AHEFHIMGIBI.AIBFGKBACCB_LobbyId >> 15, out KGICDMIJGDF, out GCBDNOPCGNP);
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
	// public string NHACIJELHIB(int OIPCCBHIKIA) { }

	// // RVA: 0xC20C7C Offset: 0xC20C7C VA: 0xC20C7C
	public string OFAKIAJNPDF_GetGroupName(int PPFNGGCBJKC)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null)
		{
			Debug.LogError("Debug :"+PPFNGGCBJKC);
			string s = ev.HMHGPIEBKPO_GetGroup(PPFNGGCBJKC).OPFGFINHFCE_Name;
			if(s != null)
				return s;
		}
        return "";
	}

	// // RVA: 0xC20D20 Offset: 0xC20D20 VA: 0xC20D20
	public int EPPBAFDEDCD_GetGroupImageId(int OIPCCBHIKIA)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return ev.OJGPPOKENLG_Groups[OIPCCBHIKIA].AACHOBAAALA_ImageId;
		}
		return 0;
	}

	// // RVA: 0xC20DD0 Offset: 0xC20DD0 VA: 0xC20DD0
	// public int AMCHEACNLLG(int PPFNGGCBJKC) { }

	// // RVA: 0xC20E08 Offset: 0xC20E08 VA: 0xC20E08
	public int HJJBDFCMJJM_GetGroupId()
	{
		int a, b;
		int res = 0;
		if(EHLFBIEGDDF())
		{
			OBBGPHPPCML_GetGroupAndRoomIds(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId >> 15, out a, out b);
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
			OBBGPHPPCML_GetGroupAndRoomIds(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId >> 15, out a, out b);
			res = b;
		}
		return res;
	}

	// // RVA: 0xC21090 Offset: 0xC21090 VA: 0xC21090
	public void NLIJCLIGIFC(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		NPNNPNAIONN = false;
		PLOOEECNHFB = false;
		PIGBKEIAMPE_FriendManager.KIELKOCLIGG k = new PIGBKEIAMPE_FriendManager.KIELKOCLIGG();
		k.IPKCADIAAPG = SakashoPlayerCriteria.NewCriteriaFromTo("lobby_id_" + PGIIDPEGGPI_EventId.ToString(), ODALKFEBNNA, LMCNAKBEBGI);
		k.MCEGJNAABHG = PFNFFKJGBMI; //base + public status + raid player
		k.IGNHNKJOCKB = (int PPFNGGCBJKC, long IFNLEKOILPM, bool MLEHCBKPNGK, List<string> OHNJJIMGKGK, EDOHBJAPLPF_JsonData IDLHJIOMJBK) =>
		{
			//0xC28670
			return IBIGBMDANNM.HEGEKFMJNCC<ELKMKCNPDFO>(PPFNGGCBJKC, IFNLEKOILPM, MLEHCBKPNGK, OHNJJIMGKGK, IDLHJIOMJBK);
		};
		k.PHCKPOKKBGD = (IFICNCAHIGI PKLPKMLGFGK) =>
		{
			//0xC2A540
			return PKLPKMLGFGK.AHEFHIMGIBI_ServerData.LLBECHBNIJG_EventRaidPlayer.IPLBEGCODDC(PGIIDPEGGPI_EventId);
		};
		CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.EGLFECJOPPP_SearchFriendAndFavoritePlayer(k, () =>
		{
			//0xC2A5C0
			ACCNCHJBDHM_Users.Clear();
			for(int i = 0; i < CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.BFDEHIANFOG.Count; i++)
			{
				ACCNCHJBDHM_Users.Add(CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.BFDEHIANFOG[i] as ELKMKCNPDFO);
			}
			CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.OCGEPBECHGB();
			PLOOEECNHFB = true;
			BHFHGFKBOHH();
		}, () =>
		{
			//0xC2A840
			PLOOEECNHFB = true;
			NPNNPNAIONN = true;
			MOBEEPPKFLG();
		});
	}

	// // RVA: 0xC21450 Offset: 0xC21450 VA: 0xC21450
	public void EJEIHOOOBLM_JoinLobbyByPlayer(int PACBOPLFGCF, ELKMKCNPDFO EIMMNMFFBCD, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK BKLCMFMIIHF, DJBHIFLHJLK MOBEEPPKFLG)
	{
		N.a.StartCoroutineWatched(DFKDDOGBOHE_JoinLobbyByPlayer(PACBOPLFGCF, EIMMNMFFBCD, BHFHGFKBOHH, BKLCMFMIIHF, MOBEEPPKFLG));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BDC9C Offset: 0x6BDC9C VA: 0x6BDC9C
	// // RVA: 0xC214C4 Offset: 0xC214C4 VA: 0xC214C4
	private IEnumerator DFKDDOGBOHE_JoinLobbyByPlayer(int PACBOPLFGCF, ELKMKCNPDFO EIMMNMFFBCD, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK BKLCMFMIIHF, DJBHIFLHJLK MOBEEPPKFLG)
	{
		LDEBIBGHCGD_EventRaidLobby KHGBJCFJGMA; // 0x2C
		LBKPFADGHPK HPHNAEPLJGM; // 0x30

		//0xC2CA48
		KHGBJCFJGMA = FJLIDJJAGOM();
		if(KHGBJCFJGMA != null)
		{
			PLOOEECNHFB = false;
			NPNNPNAIONN = false;
			int IEDKKPFGOGK = 0;
			HPHNAEPLJGM = new LBKPFADGHPK();
			int lId = EIMMNMFFBCD.AIBFGKBACCB_LobbyId;
			HPHNAEPLJGM.IPKCADIAAPG_SakashoCrit = SakashoPlayerCriteria.NewCriteriaFromTo("lobby_id_" + PGIIDPEGGPI_EventId.ToString(), (int)(lId & 0xffff8000), (int)((lId & 0xffff8000) + 32768));
			HPHNAEPLJGM.IPKCADIAAPG_SakashoCrit.OnlyFriends = false;
			HPHNAEPLJGM.EILKGEADKGH_SearchOrder = SakashoPlayerData.SearchOrder.UPDATED_AT_DESC;
			HPHNAEPLJGM.HHIHCJKLJFF_ServerInfoBlockList = new List<string>();
			HPHNAEPLJGM.PINPBOCDKLI_OnFriendCb = (int OIPCCBHIKIA, int PPFNGGCBJKC, long IFNLEKOILPM, bool MLEHCBKPNGK, List<string> OHNJJIMGKGK, EDOHBJAPLPF_JsonData IDLHJIOMJBK) =>
			{
				//0xC2A8AC
				IEDKKPFGOGK++;
				return true;
			};
			yield return Co.R(HPHNAEPLJGM.MEGIEMBDGBE_Coroutine(null, null));
			if(!HPHNAEPLJGM.NPNNPNAIONN)
			{
				int lobby_member_max = KHGBJCFJGMA.LPJLEHAJADA("lobby_member_max", 50);
				if(lobby_member_max < 1 || IEDKKPFGOGK < lobby_member_max)
				{
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId = EIMMNMFFBCD.AIBFGKBACCB_LobbyId;
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LLBECHBNIJG_EventRaidPlayer.KDMPHHFADMC_ClusterId = PACBOPLFGCF;
					int lobby_member_divide = KHGBJCFJGMA.LPJLEHAJADA("lobby_member_divide", 40);
					int group, room;
					OBBGPHPPCML_GetGroupAndRoomIds(EIMMNMFFBCD.AIBFGKBACCB_LobbyId >> 15, out group, out room);
					ILCCJNDFFOB.HHCJCDFCLOB.PHCLHGPCFNL(this, group, EIMMNMFFBCD.AIBFGKBACCB_LobbyId, OFAKIAJNPDF_GetGroupName(group), 0, lobby_member_divide, 
						string.Concat(new object[5]
						{
							EIMMNMFFBCD.MLPEHNBNOGD_Id,
							":",
							EIMMNMFFBCD.HKAIJKGODHC,
							":",
							EIMMNMFFBCD.BBNAEPGAMMA_IsFavorite
						}));
					CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
					{
						//0xC2A8C0
						PLOOEECNHFB = true;
						BHFHGFKBOHH();
					}, () =>
					{
						//0xC2A90C
						PLOOEECNHFB = true;
						NPNNPNAIONN = true;
						MOBEEPPKFLG();
					}, null);
					yield break;
				}
				PLOOEECNHFB = true;
				NPNNPNAIONN = true;
				BKLCMFMIIHF();
				yield break;
			}
			PLOOEECNHFB = true;
			NPNNPNAIONN = true;
		}
		else
		{
			PLOOEECNHFB = true;
			NPNNPNAIONN = true;
		}
		MOBEEPPKFLG();
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
	public void NHPFMNGMMHG(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
        KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA ev = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM(), null);
		if(ev == null)
		{
			NPNNPNAIONN = true;
			PLOOEECNHFB = true;
			MOBEEPPKFLG();
		}
		else
		{
			ev.CJALBNNJOOB_IsFl = true;
			NPNNPNAIONN = false;
			PLOOEECNHFB = false;
			CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
			{
				//0xC2A970
				BHFHGFKBOHH();
				PLOOEECNHFB = true;
			}, () =>
			{
				//0xC2A9BC
				MOBEEPPKFLG();
				PLOOEECNHFB = true;
				NPNNPNAIONN = true;
			}, null);
		}
    }

	// // RVA: 0xC2182C Offset: 0xC2182C VA: 0xC2182C
	public void IIBLJMMGMPD(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		N.a.StartCoroutineWatched(FGKGCPICMDN_SearchLobbyMember(BHFHGFKBOHH, MOBEEPPKFLG));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BDD14 Offset: 0x6BDD14 VA: 0x6BDD14
	// // RVA: 0xC21884 Offset: 0xC21884 VA: 0xC21884
	private IEnumerator FGKGCPICMDN_SearchLobbyMember(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		LBKPFADGHPK PGPFBCAFOCO; // 0x20
		DPDMNBGAONP OANEIPHEOGA; // 0x24

		//0xC2D5B0
		PLOOEECNHFB = false;
		NPNNPNAIONN = false;
		ACCNCHJBDHM_Users.Clear();
		List<int> FAMHAPONILI = new List<int>();
		ELKMKCNPDFO d = new ELKMKCNPDFO();
		d.ILEBOIGEGEH();
		ACCNCHJBDHM_Users.Add(d);
		FAMHAPONILI.Add(d.MLPEHNBNOGD_Id);
		PGPFBCAFOCO = new LBKPFADGHPK();
		int lobId = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId;
		PGPFBCAFOCO.IPKCADIAAPG_SakashoCrit = SakashoPlayerCriteria.NewCriteriaFromTo("lobby_id_" + PGIIDPEGGPI_EventId.ToString(), (int)(lobId & 0xffff8000), (int)((lobId & 0xffff8000) + 32768));
		PGPFBCAFOCO.IPKCADIAAPG_SakashoCrit.OnlyFriends = false;
		PGPFBCAFOCO.EILKGEADKGH_SearchOrder = SakashoPlayerData.SearchOrder.UPDATED_AT_DESC;
		PGPFBCAFOCO.HHIHCJKLJFF_ServerInfoBlockList = BBHNACPENDM_ServerSaveData.KPIDBPEKMFD_GetBlockList(0x8000000005);
		PGPFBCAFOCO.PINPBOCDKLI_OnFriendCb = (int OIPCCBHIKIA, int PPFNGGCBJKC, long IFNLEKOILPM, bool MLEHCBKPNGK, List<string> OHNJJIMGKGK, EDOHBJAPLPF_JsonData IDLHJIOMJBK) =>
		{
			//0xC2AA28
			ELKMKCNPDFO e = IBIGBMDANNM.HEGEKFMJNCC<ELKMKCNPDFO>(PPFNGGCBJKC, IFNLEKOILPM, MLEHCBKPNGK, OHNJJIMGKGK, IDLHJIOMJBK);
			if(e != null)
			{
				ACCNCHJBDHM_Users.Add(e);
				FAMHAPONILI.Add(PPFNGGCBJKC);
				return true;
			}
			return false;
		};
		yield return Co.R(PGPFBCAFOCO.MEGIEMBDGBE_Coroutine(null, null));
		if(!PGPFBCAFOCO.NPNNPNAIONN)
		{
			if(FAMHAPONILI.Count > 0)
			{
				OANEIPHEOGA = new DPDMNBGAONP();
				OANEIPHEOGA.BIHCCEHLAOD.IHALNOJAMLE_CounterName = "fan_count";
				OANEIPHEOGA.BIHCCEHLAOD.FAMHAPONILI_PlayerList = FAMHAPONILI;
				yield return Co.R(OANEIPHEOGA.MEGIEMBDGBE_Coroutine(null, null));
				if(!OANEIPHEOGA.NPNNPNAIONN)
				{
					for(int i = 0; i < ACCNCHJBDHM_Users.Count; i++)
					{
						int v;
						if(OANEIPHEOGA.NFEAMMJIMPG.OJCNJFLJCLA.TryGetValue(ACCNCHJBDHM_Users[i].MLPEHNBNOGD_Id, out v))
						{
							ACCNCHJBDHM_Users[i].AGDBNNEAIIC_FanNum = v;
						}
					}
					PLOOEECNHFB = true;
					BHFHGFKBOHH();
					yield break;
				}
			}
			else
			{
				PLOOEECNHFB = true;
				BHFHGFKBOHH();
				yield break;
			}
		}
		PLOOEECNHFB = true;
		NPNNPNAIONN = true;
		MOBEEPPKFLG();
	}

	// // RVA: 0xC21964 Offset: 0xC21964 VA: 0xC21964
	public void KCAJBLICFPJ(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		NPNNPNAIONN = false;
		PLOOEECNHFB = false;
		List<int> l = new List<int>(ACCNCHJBDHM_Users.Count);
		List<int> l2 = new List<int>(ACCNCHJBDHM_Users.Count);
		for(int i = 0; i < ACCNCHJBDHM_Users.Count; i++)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.GAAOPEGIPKA_FavoritePlayer.FFKIDMKHIOE(ACCNCHJBDHM_Users[i].MLPEHNBNOGD_Id))
			{
				if(!ACCNCHJBDHM_Users[i].BBNAEPGAMMA_IsFavorite)
				{
					l2.Add(ACCNCHJBDHM_Users[i].MLPEHNBNOGD_Id);
				}
			}
			else if(ACCNCHJBDHM_Users[i].BBNAEPGAMMA_IsFavorite)
			{
				l.Add(ACCNCHJBDHM_Users[i].MLPEHNBNOGD_Id);
			}
		}
		if(l.Count + l2.Count != 0)
		{
			CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.EPKOLKBGOGA(l, l2, () =>
			{
				//0xC2AB44
				PLOOEECNHFB = true;
				BHFHGFKBOHH();
			}, () =>
			{
				//0xC2AB90
				PLOOEECNHFB = true;
				NPNNPNAIONN = true;
				MOBEEPPKFLG();
			}, null);
		}
		else
		{
			PLOOEECNHFB = true;
			BHFHGFKBOHH();
		}
	}

	// // RVA: 0xC21EC0 Offset: 0xC21EC0 VA: 0xC21EC0
	public void NGKIBBIEAAD()
	{
		ACCNCHJBDHM_Users.Clear();
	}

	// // RVA: 0xC21F38 Offset: 0xC21F38 VA: 0xC21F38
	public void LLLKDLPJHCF(int MLPEHNBNOGD, Action<int, int> BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		NPNNPNAIONN = false;
		PLOOEECNHFB = false;
		int PGIIDPEGGPI = 0;
		int AIBFGKBACCB = 0;
		NJNCAHLIHNI_GetPlayerData req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NJNCAHLIHNI_GetPlayerData());
		req.FAMHAPONILI_Ids = new List<int>() { MLPEHNBNOGD };
		req.HHIHCJKLJFF_BlockNames = BBHNACPENDM_ServerSaveData.KPIDBPEKMFD_GetBlockList(0x8000000000);
		req.PINPBOCDKLI = (int OIPCCBHIKIA, int PPFNGGCBJKC, long IFNLEKOILPM, List<string> OHNJJIMGKGK, EDOHBJAPLPF_JsonData IDLHJIOMJBK) =>
		{
			//0xC2ABF4
			FPPNANIIODA.KHEKNNFCAOI_Init(0x8000000000);
			if(FPPNANIIODA.IIEMACPEEBJ_Load(OHNJJIMGKGK, IDLHJIOMJBK))
			{
				PGIIDPEGGPI = FPPNANIIODA.LLBECHBNIJG_EventRaidPlayer.OBGBAOLONDD;
				AIBFGKBACCB = FPPNANIIODA.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId >> 15;
				return true;
			}
			return false;
		};
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request BHGCOECCPCO) =>
		{
			//0xC2ADB0
			BHFHGFKBOHH(PGIIDPEGGPI, AIBFGKBACCB);
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request BHGCOECCPCO) =>
		{
			//0xC2AE38
			PLOOEECNHFB = true;
			NPNNPNAIONN = true;
			MOBEEPPKFLG();
		};
	}

	// // RVA: 0xC22240 Offset: 0xC22240 VA: 0xC22240
	private void PLKPGEGNLFH(StringBuilder KOHNLDKIKPC, int AIBFGKBACCB, FLHJEJGJJGE KLMCILEDMEL)
	{
		AHAENNIFOAF.PAMKDBAMMIE(KOHNLDKIKPC, PGIIDPEGGPI_EventId, AIBFGKBACCB, KLMCILEDMEL);
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
		NIIEJKGNEBH_InitializeBbs(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId >> 15);
	}

	// // RVA: 0xC2244C Offset: 0xC2244C VA: 0xC2244C
	public void NIIEJKGNEBH_InitializeBbs(int AIBFGKBACCB)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null)
		{
			EGMBECGOHAE = new KKLGJPAIHJN(ev.LPJLEHAJADA("bbs_news_update_interval", 60), 0);
			OKMNIPKLHHK = new KKLGJPAIHJN(ev.LPJLEHAJADA("bbs_copy_interval", 15), 0);
			StringBuilder str = new StringBuilder(64);
			FCBCCOEBHJB = new OKLFOAPMJAA();
			FCBCCOEBHJB.OBKGEDCKHHE();
			KBMOEKMKGBL_ChatDatas = new OKLFOAPMJAA.BABPHOEGLPC[3];
			PLKPGEGNLFH(str, AIBFGKBACCB, FLHJEJGJJGE.GGCIMLDFDOC_0_Chat);
			int bbs_comment_load_count = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA("bbs_comment_load_count", 10);
			int v = KGGDENNDEAN_GetDaysLeft();
			OKLFOAPMJAA.BABPHOEGLPC b = new OKLFOAPMJAA.BABPHOEGLPC(str.ToString(), bbs_comment_load_count, bbs_comment_load_count, v, true, (ANPBHCNJIDI.NNPGLGHDBKN PIABJCEJIHC) =>
			{
				//0xC2852C
				ANPBHCNJIDI.AIFBLOAGFOP a = PIABJCEJIHC as ANPBHCNJIDI.AIFBLOAGFOP;
				if(a != null && a.LBODBHCBAMD)
				{
					return BJMPAPCDGIG_IsLogEnabled();
				}
				return true;
			});
			b.EEBMKLOIEMB_SetAutoUpdateInterval(ev.LPJLEHAJADA("bbs_auto_update_interval_main", 10));
			b.PFMOHFOOBCL(AHAENNIFOAF.IAOPMEAIHLH.IDGJGMNNJEF_0);
			KBMOEKMKGBL_ChatDatas[0] = b;
			PLKPGEGNLFH(str, AIBFGKBACCB, FLHJEJGJJGE.JAFEBKBFPBB_1_Battle);
			b = new OKLFOAPMJAA.BABPHOEGLPC(str.ToString(), ev.LPJLEHAJADA("bbs_battlelog_comment_load_count", 30), bbs_comment_load_count, v, false, (ANPBHCNJIDI.NNPGLGHDBKN PIABJCEJIHC) =>
			{
				//0xC28704
				return ANPBHCNJIDI.JCGBEAHDNEI_IsBattleLogMessage(PIABJCEJIHC.INDDJNMPONH_Type);
			});
			b.EEBMKLOIEMB_SetAutoUpdateInterval(ev.LPJLEHAJADA("bbs_auto_update_interval_battlelog", 60));
			b.PFMOHFOOBCL(AHAENNIFOAF.IAOPMEAIHLH.JBMJEOBODHH_1);
			KBMOEKMKGBL_ChatDatas[1] = b;
			PLKPGEGNLFH(str, AIBFGKBACCB, FLHJEJGJJGE.CEMAJAOJBEO_2_Chapter);
			b = new OKLFOAPMJAA.BABPHOEGLPC(str.ToString(), bbs_comment_load_count, bbs_comment_load_count, v, true, null);
			b.EEBMKLOIEMB_SetAutoUpdateInterval(ev.LPJLEHAJADA("bbs_auto_update_interval_memo", 10));
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
			return TimeSpan.FromSeconds(ev.NGHKJOEDLIP.COIHIAKHFNF_End - NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime()).Days;
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
            PLKPGEGNLFH(str, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId >> 15, KLMCILEDMEL);
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
	public ANPBHCNJIDI.NNPGLGHDBKN GDGCADFCDCL_GetComment(FLHJEJGJJGE KLMCILEDMEL, int OIPCCBHIKIA)
	{
		FCBCCOEBHJB.FLFJILIIMGI_SetData(KBMOEKMKGBL_ChatDatas[(int)KLMCILEDMEL]);
		return FCBCCOEBHJB.NOEMAKFEICB_GetComment(OIPCCBHIKIA);
	}

	// // RVA: 0xC23168 Offset: 0xC23168 VA: 0xC23168
	// public int DLPCLKFKINM(NKOBMDPHNGP.FLHJEJGJJGE KLMCILEDMEL) { }

	// // RVA: 0xC231F8 Offset: 0xC231F8 VA: 0xC231F8
	public bool BJMPAPCDGIG_IsLogEnabled()
	{
		return GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.KHBHOGEEHBA_RaidLobbyEvent.LALECMJIGPH_GetIsDisplayViewingText();
	}

	// // RVA: 0xC232FC Offset: 0xC232FC VA: 0xC232FC
	public void NLGAFNOHLID_SetLogEnabled(bool NANNGLGOFKH)
	{
		GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.KHBHOGEEHBA_RaidLobbyEvent.JJDBLFAGGGK_SetIsDisplayViewingText(NANNGLGOFKH);
		GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
	}

	// // RVA: 0xC23450 Offset: 0xC23450 VA: 0xC23450
	// public bool AAECCLGAMNO() { }

	// // RVA: 0xC2347C Offset: 0xC2347C VA: 0xC2347C
	public void MMMBGDHMJKC(int KPNKPGLPDHI, FLHJEJGJJGE KLMCILEDMEL, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		CLLMBGONMKE(KPNKPGLPDHI, KLMCILEDMEL, BHFHGFKBOHH, MOBEEPPKFLG, true);
	}

	// // RVA: 0xC234A0 Offset: 0xC234A0 VA: 0xC234A0
	private void CLLMBGONMKE(int KPNKPGLPDHI, FLHJEJGJJGE KLMCILEDMEL, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG, bool BELNGJDDEIB)
	{
		NPNNPNAIONN = false;
		PLOOEECNHFB = false;
		FJHLAKJBNFA = true;
		FCBCCOEBHJB.FLFJILIIMGI_SetData(KBMOEKMKGBL_ChatDatas[(int)KLMCILEDMEL]);
		FCBCCOEBHJB.JLEFHIOELGH(KPNKPGLPDHI, () =>
		{
			//0xC287A0
			if(KLMCILEDMEL == 0)
			{
				ADENMOCKJGH();
			}
			PLOOEECNHFB = true;
			FJHLAKJBNFA = false;
			BHFHGFKBOHH();
		}, () =>
		{
			//0xC28830
			PLOOEECNHFB = true;
			NPNNPNAIONN = true;
			FJHLAKJBNFA = false;
			MOBEEPPKFLG();
		}, BELNGJDDEIB);
	}

	// // RVA: 0xC236A8 Offset: 0xC236A8 VA: 0xC236A8
	public void MICOCAOLCEJ(int KPNKPGLPDHI, FLHJEJGJJGE KLMCILEDMEL, Action<List<FLHJEJGJJGE>> OKLICHHNKEA, DJBHIFLHJLK MOBEEPPKFLG)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null)
		{
			FCBCCOEBHJB.FLFJILIIMGI_SetData(KBMOEKMKGBL_ChatDatas[(int)KLMCILEDMEL]);
			FCBCCOEBHJB.FBANBDCOEJL(KPNKPGLPDHI, () =>
			{
				//0xC288B0
				if(KLMCILEDMEL == FLHJEJGJJGE.GGCIMLDFDOC_0_Chat)
					ADENMOCKJGH();
				else
				{
					if(EGMBECGOHAE.DKMLDEDKPBA)
					{
						EGMBECGOHAE.IDAPJFGJHND();
						CLLMBGONMKE(KPNKPGLPDHI, FLHJEJGJJGE.GGCIMLDFDOC_0_Chat, () =>
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
							MOBEEPPKFLG();
						}, false);
						return;
					}
				}
				List<FLHJEJGJJGE> l = new List<FLHJEJGJJGE>();
				l.Add(KLMCILEDMEL);
				OKLICHHNKEA(l);
			}, MOBEEPPKFLG);
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
	public void DJEEPILBAIH(FLHJEJGJJGE KLMCILEDMEL, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		NPNNPNAIONN = false;
		PLOOEECNHFB = false;
		FCBCCOEBHJB.FLFJILIIMGI_SetData(KBMOEKMKGBL_ChatDatas[(int)KLMCILEDMEL]);
		FJHLAKJBNFA = true;
		FCBCCOEBHJB.HDHACKFJKGM(0, () =>
		{
			//0xC28CA0
			PLOOEECNHFB = true;
			FJHLAKJBNFA = false;
			BHFHGFKBOHH();
		}, () =>
		{
			//0xC28D08
			PLOOEECNHFB = true;
			NPNNPNAIONN = true;
			FJHLAKJBNFA = false;
			MOBEEPPKFLG();
		});
	}

	// // RVA: 0xC23B18 Offset: 0xC23B18 VA: 0xC23B18
	public bool CCIKMMPIMHD()
	{
		return FCBCCOEBHJB.ONOLJCIOKOC();
	}

	// // RVA: 0xC23B44 Offset: 0xC23B44 VA: 0xC23B44
	public void HJNDLPNBBKF(FLHJEJGJJGE KLMCILEDMEL, ANPBHCNJIDI.NNPGLGHDBKN HCAHCFGPJIF, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG, DJBHIFLHJLK NKGHADCBGJO)
	{
		NPNNPNAIONN = false;
		PLOOEECNHFB = false;
		FJHLAKJBNFA = true;
		FCBCCOEBHJB.FLFJILIIMGI_SetData(KBMOEKMKGBL_ChatDatas[(int)KLMCILEDMEL]);
		FCBCCOEBHJB.NPIBJOGODKG(0, HCAHCFGPJIF, () =>
		{
			//0xC28D88
			PLOOEECNHFB = true;
			FJHLAKJBNFA = false;
			BHFHGFKBOHH();
		}, () =>
		{
			//0xC28DF0
			PLOOEECNHFB = true;
			NPNNPNAIONN = true;
			FJHLAKJBNFA = false;
			MOBEEPPKFLG();
		}, () =>
		{
			//0xC28E70
			PLOOEECNHFB = true;
			NPNNPNAIONN = true;
			FJHLAKJBNFA = false;
			NKGHADCBGJO();
		});
	}

	// // RVA: 0xC23D64 Offset: 0xC23D64 VA: 0xC23D64
	public void CADBGOEBMEO(FLHJEJGJJGE KLMCILEDMEL, ANPBHCNJIDI.NNPGLGHDBKN HCAHCFGPJIF, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		NPNNPNAIONN = false;
		PLOOEECNHFB = false;
		FCBCCOEBHJB.FLFJILIIMGI_SetData(KBMOEKMKGBL_ChatDatas[(int)KLMCILEDMEL]);
		FJHLAKJBNFA = true;
		FCBCCOEBHJB.HCMMMCFFGCA_UpdateThreadComment(HCAHCFGPJIF, () =>
		{
			//0xC28EE4
			PLOOEECNHFB = true;
			FJHLAKJBNFA = false;
			BHFHGFKBOHH();
		}, () =>
		{
			//0xC28F4C
			PLOOEECNHFB = true;
			NPNNPNAIONN = true;
			FJHLAKJBNFA = false;
			MOBEEPPKFLG();
		});
	}

	// // RVA: 0xC23F40 Offset: 0xC23F40 VA: 0xC23F40
	// public void CKONNBGNAKG(NKOBMDPHNGP.FLHJEJGJJGE KLMCILEDMEL, ANPBHCNJIDI.NNPGLGHDBKN HCAHCFGPJIF, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0xC24114 Offset: 0xC24114 VA: 0xC24114
	public void NKLFDHJKIII(FLHJEJGJJGE KLMCILEDMEL, int MLPEHNBNOGD, int LCJEPKENHCE, Action<bool> BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		NPNNPNAIONN = false;
		PLOOEECNHFB = false;
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
				return PIABJCEJIHC.MLPEHNBNOGD_WritterId == MLPEHNBNOGD;
			});
			PLOOEECNHFB = true;
			BHFHGFKBOHH(m != null);
		}, () =>
		{
			//0xC29244
			PLOOEECNHFB = true;
			NPNNPNAIONN = true;
			MOBEEPPKFLG();
		});
	}

	// // RVA: 0xC24328 Offset: 0xC24328 VA: 0xC24328
	// private int AIIPLCEICBM(ANPBHCNJIDI.NOJONDLAMOC INDDJNMPONH) { }

	// // RVA: 0xC24330 Offset: 0xC24330 VA: 0xC24330
	public string ABGDJKLFBKL_GetMessageContent(ANPBHCNJIDI.PHICILDLHJP HCAHCFGPJIF, PKNOKJNLPOE_EventRaid AIOGBKCJLHM)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null)
		{
			StringBuilder str1 = new StringBuilder(32);
            str1.SetFormat("battlelog_text_{0:D2}", (int)HCAHCFGPJIF.INDDJNMPONH_Type - 2);
			StringBuilder str2 = new StringBuilder(64);
			if(HCAHCFGPJIF.INDDJNMPONH_Type == ANPBHCNJIDI.NOJONDLAMOC.JPOGBMJKPIJ_5_FullCombo)
			{
                ANPBHCNJIDI.JLHGKKIEALB m = HCAHCFGPJIF as ANPBHCNJIDI.JLHGKKIEALB;
                StringBuilder str5 = new StringBuilder(16);
                str5.Set(Difficulty.Name[m.AKNELONELJK_Difficulty]);
				if(m.GIKLNODJKFK_Line6)
				{
                    str5.Append("+");
                }
                string s = DatabaseTextConverter.TranslateLobbyMessage(JOPOPMLFINI_QuestId, str1.ToString(), ""); //ev.EFEGBHACJAL(str1.ToString(), "");
                str2.SetFormat(s, Database.Instance.musicText.Get(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(m.ADHMMMEOJMK_FreeSongId).DLAEJOBELBH_MusicId).KNMGEEFGDNI_Nam).musicName, str5.ToString());
				if(m.IGNJCGMLBDA_HasDamage)
				{
                    str1.SetFormat("battlelog_text_{0:D2}", 1);
                    str2.Append(JpStringLiterals.StringLiteral_5812);
                    str2.AppendFormat(DatabaseTextConverter.TranslateLobbyMessage(JOPOPMLFINI_QuestId, str1.ToString(), "")/*ev.EFEGBHACJAL(str1.ToString(), "")*/, AIOGBKCJLHM.AGEJGHGEGFF_GetBossName(m.MFMPCHIJINJ_BossType), m.HALIDDHLNEG_Damage);
                }
            }
			else if(HCAHCFGPJIF.INDDJNMPONH_Type == ANPBHCNJIDI.NOJONDLAMOC.JDGLJOFPHLK_4_MaccrossCannon)
			{
                ANPBHCNJIDI.NBHIMCACDHM m = HCAHCFGPJIF as ANPBHCNJIDI.NBHIMCACDHM;
                str2.SetFormat(DatabaseTextConverter.TranslateLobbyMessage(JOPOPMLFINI_QuestId, str1.ToString(), "")/*ev.EFEGBHACJAL(str1.ToString(), "")*/, m.HALIDDHLNEG_Damage);
				if(m.IGNJCGMLBDA_Defeat)
				{
                    str1.SetFormat(DatabaseTextConverter.TranslateLobbyMessage(JOPOPMLFINI_QuestId, "battlelog_text_04", "")/*"battlelog_text_04"*/, Array.Empty<object>());
                    str2.Append(JpStringLiterals.StringLiteral_5812);
                    str2.Append(ev.EFEGBHACJAL(str1.ToString(), ""));
                }
            }
			else if(HCAHCFGPJIF.INDDJNMPONH_Type == ANPBHCNJIDI.NOJONDLAMOC.CGEPNIOPFHF_3_DefeatBoss)
			{
                ANPBHCNJIDI.KNGOGLLMKDL m = HCAHCFGPJIF as ANPBHCNJIDI.KNGOGLLMKDL;
                str2.SetFormat(DatabaseTextConverter.TranslateLobbyMessage(JOPOPMLFINI_QuestId, str1.ToString(), "")/*ev.EFEGBHACJAL(str1.ToString(), "")*/, AIOGBKCJLHM.AGEJGHGEGFF_GetBossName(m.MFMPCHIJINJ_BossType), m.HALIDDHLNEG_Damage);
            }
            return str2.ToString();
        }
        return "";
    }

	// // RVA: 0xC24BEC Offset: 0xC24BEC VA: 0xC24BEC
	public void EGBFCCFICIF(PEDPKDBKGIN PIBLLGLCJEO, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		PLOOEECNHFB = false;
		NPNNPNAIONN = false;
        ANPBHCNJIDI.PHICILDLHJP HCAHCFGPJIF = null;
        if(!PIBLLGLCJEO.INLLJNOMNGF_CannonAttack)
		{
			if(!PIBLLGLCJEO.NANEGCHBEDN_IsFullCombo || PIBLLGLCJEO.DKKJPLALNFD_Skip)
			{
                if (PIBLLGLCJEO.IGNJCGMLBDA_Defeat)
                {
					ANPBHCNJIDI.KNGOGLLMKDL m = new ANPBHCNJIDI.KNGOGLLMKDL();
                    m.HALIDDHLNEG_Damage = PIBLLGLCJEO.HALIDDHLNEG_Damage;
                    m.MFMPCHIJINJ_BossType = PIBLLGLCJEO.MFMPCHIJINJ_BossType;
                    HCAHCFGPJIF = m;
                }
            }
			else
			{
				ANPBHCNJIDI.JLHGKKIEALB m = new ANPBHCNJIDI.JLHGKKIEALB();
                m.ADHMMMEOJMK_FreeSongId = PIBLLGLCJEO.ADHMMMEOJMK_FreeSongId;
                m.AKNELONELJK_Difficulty = PIBLLGLCJEO.AKNELONELJK_Difficulty;
                m.GIKLNODJKFK_Line6 = PIBLLGLCJEO.GIKLNODJKFK_Line6;
				if(PIBLLGLCJEO.IGNJCGMLBDA_Defeat)
				{
					m.HALIDDHLNEG_Damage = PIBLLGLCJEO.HALIDDHLNEG_Damage;
                    m.MFMPCHIJINJ_BossType = PIBLLGLCJEO.MFMPCHIJINJ_BossType;
                }
                HCAHCFGPJIF = m;
            }
		}
		else
		{
            ANPBHCNJIDI.NBHIMCACDHM m = new ANPBHCNJIDI.NBHIMCACDHM();
            m.IGNJCGMLBDA_Defeat = PIBLLGLCJEO.IGNJCGMLBDA_Defeat;
            m.HALIDDHLNEG_Damage = PIBLLGLCJEO.HALIDDHLNEG_Damage;
            m.GJAOLNLFEBD_BossName = PIBLLGLCJEO.GJAOLNLFEBD_BossName;
            m.EJGDHAENIDC_BossRank = PIBLLGLCJEO.EJGDHAENIDC_BossRank;
            m.PCPODOMOFDH_BossSeriesAttr = PIBLLGLCJEO.PCPODOMOFDH_BossSerieAttr;
            m.JNBDLNBKDCO_BossImage = PIBLLGLCJEO.JNBDLNBKDCO_BossImage;
            m.KKPAHLMJKIH_WavId = PIBLLGLCJEO.JPOIGNNOHJP_WavId;
            m.IKICLMGFFPB = PIBLLGLCJEO.IKICLMGFFPB;
            m.CNOHJPEHHCH_LogId = NMMKHNDOEFB();
            HCAHCFGPJIF = m;
        }
		if(HCAHCFGPJIF == null)
		{
			PLOOEECNHFB = true;
            BHFHGFKBOHH();
        }
		else
		{
            bool CKIIGKKHDMP = GOENGHBLHDB(HCAHCFGPJIF);
            HCAHCFGPJIF.PCEHLFNFIDA(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave);
            HCAHCFGPJIF.EBBJPBGHJOL_Content = ABGDJKLFBKL_GetMessageContent(HCAHCFGPJIF, PIBLLGLCJEO.AIOGBKCJLHM);
			if(CKIIGKKHDMP)
			{
                HCAHCFGPJIF.PHGNPFJIBLF_Name = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.OPFGFINHFCE_PlayerName;
                HCAHCFGPJIF.ICFCJOEMIIJ_Id = NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId;
            }
            HDAOMKFAIPP_InitChatData(FLHJEJGJJGE.JAFEBKBFPBB_1_Battle);
            HJNDLPNBBKF(FLHJEJGJJGE.JAFEBKBFPBB_1_Battle, HCAHCFGPJIF, () =>
			{
				//0xC29484
				if(!CKIIGKKHDMP)
				{
					PLOOEECNHFB = true;
                    BHFHGFKBOHH();
                }
				else
				{
                    HCAHCFGPJIF.PCEHLFNFIDA(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave);
                    HCAHCFGPJIF.CKIIGKKHDMP_Auto = true;
                    HDAOMKFAIPP_InitChatData(FLHJEJGJJGE.GGCIMLDFDOC_0_Chat);
					HJNDLPNBBKF(FLHJEJGJJGE.GGCIMLDFDOC_0_Chat, HCAHCFGPJIF, () =>
					{
                        //0xC292A8
                        PLOOEECNHFB = true;
                        BHFHGFKBOHH();
                    }, () =>
					{
                        //0xC292F4
                        PLOOEECNHFB = true;
                        NPNNPNAIONN = true;
                        MOBEEPPKFLG();
                    }, () =>
					{
                        //0xC29358
                        PLOOEECNHFB = true;
                        NPNNPNAIONN = true;
                        MOBEEPPKFLG();
                    });
                }
			}, () =>
			{
                //0xC293BC
                PLOOEECNHFB = true;
                NPNNPNAIONN = true;
                MOBEEPPKFLG();
            }, () =>
			{
                //0xC29420
                PLOOEECNHFB = true;
                NPNNPNAIONN = true;
                MOBEEPPKFLG();
            });
        }
	}

	// // RVA: 0xC255D8 Offset: 0xC255D8 VA: 0xC255D8
	private bool GOENGHBLHDB(ANPBHCNJIDI.NNPGLGHDBKN HCAHCFGPJIF)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null && HCAHCFGPJIF != null)
		{
			ANPBHCNJIDI.NBHIMCACDHM m = HCAHCFGPJIF as ANPBHCNJIDI.NBHIMCACDHM;
			if(m != null)
			{
				int bbs_auto_copy_mcannon_damage = ev.LPJLEHAJADA("bbs_auto_copy_mcannon_damage", 20000);
				return m.IGNJCGMLBDA_Defeat && m.IKICLMGFFPB && bbs_auto_copy_mcannon_damage <= m.HALIDDHLNEG_Damage;
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
			KPPHGAAOMDN.HCAHCFGPJIF = null;
			FCBCCOEBHJB.FLFJILIIMGI_SetData(KBMOEKMKGBL_ChatDatas[0]);
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			long l = t - ev.LPJLEHAJADA("bbs_news_search_time", 180);
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
					KPPHGAAOMDN.HCAHCFGPJIF = m as ANPBHCNJIDI.NBHIMCACDHM;
					CNCPFACLJHH(KPPHGAAOMDN);
					break;
				}
			}
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.KHBHOGEEHBA_RaidLobbyEvent.AGCAONIMNAL_SetNewsletterUpdateAt(t);
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
		}
    }

	// // RVA: 0xC263A4 Offset: 0xC263A4 VA: 0xC263A4
	public void JCCAPHGLOJF_GetBbsBattleLogMacrossCannonStamp(int LGPGAPNGBGG, Action<List<ANPBHCNJIDI.BNEIDPGIAFM>> BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		N.a.StartCoroutineWatched(GPBFKOMIAAG_Corotuine_GetBbsBattleLogMacrossCannonStamp(LGPGAPNGBGG, BHFHGFKBOHH, MOBEEPPKFLG));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BDDAC Offset: 0x6BDDAC VA: 0x6BDDAC
	// // RVA: 0xC2640C Offset: 0xC2640C VA: 0xC2640C
	private IEnumerator GPBFKOMIAAG_Corotuine_GetBbsBattleLogMacrossCannonStamp(int LGPGAPNGBGG, Action<List<ANPBHCNJIDI.BNEIDPGIAFM>> BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		//0xC2BB74
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev == null)
		{
			PLOOEECNHFB = true;
			NPNNPNAIONN = true;
			MOBEEPPKFLG();
		}
		else
		{
			NPNNPNAIONN = false;
			PLOOEECNHFB = false;
			FCBCCOEBHJB.FLFJILIIMGI_SetData(KBMOEKMKGBL_ChatDatas[1]);
			int bbs_mcannon_stamp_comment_min = ev.LPJLEHAJADA("bbs_mcannon_stamp_comment_min", 90);
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
				PLOOEECNHFB = true;
				BHFHGFKBOHH(l);
			}, () =>
			{
				//0xC299A4
				PLOOEECNHFB = true;
				NPNNPNAIONN = true;
				MOBEEPPKFLG();
			});
		}
		yield break;
    }

	// // RVA: 0xC253C8 Offset: 0xC253C8 VA: 0xC253C8
	public static int NMMKHNDOEFB()
	{
        NIGIOKLMJIH.SetFormat("{0}_{1}", NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime(), NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId);
        return NIGIOKLMJIH.ToString().GetHashCode();
    }

	// // RVA: 0xC26500 Offset: 0xC26500 VA: 0xC26500
	public bool ABNLPDNFHDN()
	{
		return OKMNIPKLHHK.DKMLDEDKPBA;
	}

	// // RVA: 0xC2652C Offset: 0xC2652C VA: 0xC2652C
	public void CBOFAFKMIBE_CopyBbsBattleLogCommentToMain(ANPBHCNJIDI.PHICILDLHJP HCAHCFGPJIF, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		N.a.StartCoroutineWatched(LKNPBAGDJDF_Coroutine_CopyBbsBattleLogCommentToMain(HCAHCFGPJIF, BHFHGFKBOHH, MOBEEPPKFLG));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BDE24 Offset: 0x6BDE24 VA: 0x6BDE24
	// // RVA: 0xC26594 Offset: 0xC26594 VA: 0xC26594
	private IEnumerator LKNPBAGDJDF_Coroutine_CopyBbsBattleLogCommentToMain(ANPBHCNJIDI.PHICILDLHJP HCAHCFGPJIF, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		//0xC2C548
		PLOOEECNHFB = false;
		NPNNPNAIONN = false;
		bool FDOJOGIMHMF = false;
		bool JCGDKLJEPKJ = false;
		OKMNIPKLHHK.IDAPJFGJHND();
		HCAHCFGPJIF.PHGNPFJIBLF_Name = HCAHCFGPJIF.OPFGFINHFCE_PlayerName;
		HCAHCFGPJIF.ICFCJOEMIIJ_Id = HCAHCFGPJIF.MLPEHNBNOGD_WritterId;
		if(HCAHCFGPJIF.JOIOJMONLFL_IsWritterSelf)
		{
			CADBGOEBMEO(FLHJEJGJJGE.JAFEBKBFPBB_1_Battle, HCAHCFGPJIF, () =>
			{
				//0xC29B0C
				PLOOEECNHFB = false;
				FDOJOGIMHMF = true;
			}, () =>
			{
				//0xC29B40
				OKMNIPKLHHK.BALEALPHEEJ();
				FDOJOGIMHMF = true;
				JCGDKLJEPKJ = true;
				MOBEEPPKFLG();
			});
			while(!FDOJOGIMHMF)
				yield return null;
			if(JCGDKLJEPKJ)
				yield break;
		}
		//LAB_00c2c814
		HCAHCFGPJIF.PCEHLFNFIDA(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave);
		HJNDLPNBBKF(FLHJEJGJJGE.GGCIMLDFDOC_0_Chat, HCAHCFGPJIF, () =>
		{
			//0xC29BAC
			OKMNIPKLHHK.BALEALPHEEJ();
			PLOOEECNHFB = true;
			BHFHGFKBOHH();
		}, () =>
		{
			//0xC29C2C
			OKMNIPKLHHK.BALEALPHEEJ();
			PLOOEECNHFB = true;
			NPNNPNAIONN = true;
			MOBEEPPKFLG();
		}, () =>
		{
			//0xC29CC4
			OKMNIPKLHHK.BALEALPHEEJ();
			PLOOEECNHFB = true;
			NPNNPNAIONN = true;
			MOBEEPPKFLG();
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
		return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId >> 15;
	}

	// // RVA: 0xC26794 Offset: 0xC26794 VA: 0xC26794
	// public bool JFIACOLOCBN() { }

	// // RVA: 0xC26A0C Offset: 0xC26A0C VA: 0xC26A0C
	public void PBPBEMJGIJK()
	{
		GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.KHBHOGEEHBA_RaidLobbyEvent.IDIHHKNAIJG_SetCoopQuestUpdateAt(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
		GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
	}

	// // RVA: 0xC26BCC Offset: 0xC26BCC VA: 0xC26BCC
	public List<AKIIJBEJOEP> MHGAHHPGGAE_GetMisions()
	{
		List<AKIIJBEJOEP> l = new List<AKIIJBEJOEP>();
		long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		for(int i = 0; i < AGLILDLEFDK_Missions.Count; i++)
		{
			if(t >= AGLILDLEFDK_Missions[i].KJBGCLPMLCG_Start && t < AGLILDLEFDK_Missions[i].GJFPFFBAKGK_End)
			{
				l.Add(AGLILDLEFDK_Missions[i]);
			}
		}
		l.Sort((AKIIJBEJOEP HKICMNAACDA, AKIIJBEJOEP BNKHBCBJBKI) =>
		{
			//0xC28730
			return HKICMNAACDA.EILKGEADKGH.CompareTo(BNKHBCBJBKI.EILKGEADKGH);
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
	public void OBIDIBBDEKM(bool OAFPGJLCNFM)
	{
        KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA ev = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM(), null);
		if(ev != null)
			ev.BOKPBNGHOGM = OAFPGJLCNFM;
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
	public void MCPEJDANIAL(int IADNLGMIHDK)
	{
        KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA ev = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM(), null);
		if(ev != null)
		{
			ev.LAGLPDDLMCK = IADNLGMIHDK;
		}
	}

	// // RVA: 0xC27028 Offset: 0xC27028 VA: 0xC27028
	public bool KLEEKOAFIIK(bool FBBNPFFEJBN)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			if(t >= ev.NGHKJOEDLIP.CJPMLAIFCDL_LobbyStart)
			{
				if(t < ev.NGHKJOEDLIP.COIHIAKHFNF_End)
				{
					if(FBBNPFFEJBN || NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD != IFDJALILEOF())
					{
						MCPEJDANIAL(NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD);
						for(int i = 0; i < ev.NNMPGOAGEOL_Missions.Count; i++)
						{
							if(ev.NNMPGOAGEOL_Missions[i].PPCFIHMDMLM)
							{
								if(ev.NNMPGOAGEOL_Missions[i].OFKCGMNFGKB(t))
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
	public GDNGPJINPDK IBDNMIFLEKK(NGHEKBHLBAN INDDJNMPONH/* = 0*/)
	{
        LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
		if(ev != null)
		{
            FIPGKDJHKCH_Phase phase = CHDNDNMHJHI_GetPhase();
            if (phase != FIPGKDJHKCH_Phase.HJNNKCMLGFL_0)
			{
				List<LDEBIBGHCGD_EventRaidLobby.LNECBHIKKHK> l = new List<LDEBIBGHCGD_EventRaidLobby.LNECBHIKKHK>(ev.OIIMJFCBFFG_LobbyGuide.Count);
				for(int i = 0; i < ev.OIIMJFCBFFG_LobbyGuide.Count; i++)
				{
					if(INDDJNMPONH == NGHEKBHLBAN.CFBJGAGBJEN_0 || ev.OIIMJFCBFFG_LobbyGuide[i].INDDJNMPONH == (int)INDDJNMPONH && ev.OIIMJFCBFFG_LobbyGuide[i].GJNIPHMPMIC_Phase == (int)phase)
					{
						l.Add(ev.OIIMJFCBFFG_LobbyGuide[i]);
					}
				}
				int v = UnityEngine.Random.Range(0, l.Count);
				GDNGPJINPDK g = new GDNGPJINPDK();
				g.FDBOPFEOENF_Id = l[v].FDBOPFEOENF_Id;
				g.IJLLIGENJCI_Pic = l[v].MJMPANIBFED_Pic;
				g.LJGOOOMOMMA_Message = l[v].LICPCDCLOIO_Message;
				return g;
			}
		}
    	return null;
	}

	// // RVA: 0xC275F4 Offset: 0xC275F4 VA: 0xC275F4
	public int EHGKMLPCDBM_GetItemCount(RaidItemConstants.Type INDDJNMPONH, BBHNACPENDM_ServerSaveData AHEFHIMGIBI)
	{
        KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA ev = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM(), AHEFHIMGIBI);
		if(ev != null)
		{
			return ev.KAINPNMMAEK_GetItemCount(INDDJNMPONH);
		}
        return 0;
	}

	// // RVA: 0xC27634 Offset: 0xC27634 VA: 0xC27634
	public void NCBELAFIPDN_SetItemCount(RaidItemConstants.Type INDDJNMPONH, int HMFFHLPNMPH, BBHNACPENDM_ServerSaveData AHEFHIMGIBI)
	{
        KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA ev = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM(), AHEFHIMGIBI);
		if(ev != null)
		{
			ev.PPJAGFPBFHJ_SetItemCount(INDDJNMPONH, HMFFHLPNMPH);
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
			string fold_radar_diva_bonus_list = ev.EFEGBHACJAL("fold_radar_diva_bonus_list", "6,7");
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
	public void KCEDMGFCOAE(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, string MDADLCOCEBN, int FCLGIPFPIPH)
	{
		FDGMLPLCALF = 0;
		if(OMNOFMEBLAD.MNNHHJBBICA_GameEventType != 11 && OMNOFMEBLAD.KLCIIHKFPPO_StoryMusicId < 1)
		{
            LDEBIBGHCGD_EventRaidLobby ev = FJLIDJJAGOM();
			if(ev != null)
        	{
				int v = GGPLIBIPHLI(OMNOFMEBLAD.AKNELONELJK_Difficulty);
				if(v > 0)
				{
					int fold_radar_diva_bonus_value = ev.LPJLEHAJADA("fold_radar_diva_bonus_value", 50);
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
						if(1 < FCLGIPFPIPH)
						{
							FDGMLPLCALF *= FCLGIPFPIPH;
						}
						AKGAFHKMFOO(FDGMLPLCALF, OMNOFMEBLAD, MDADLCOCEBN);
					}
				}
			}
		}
	}

	// // RVA: 0xC27A58 Offset: 0xC27A58 VA: 0xC27A58
	private int GGPLIBIPHLI(int AKNELONELJK/* = 0*/)
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
			str.Append(AKNELONELJK + 1);
			return ev.LPJLEHAJADA(str.ToString(), 50000);
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
	public void IMBLLJAEMAI_UseTicket(int HMFFHLPNMPH)
	{
        KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA save = KNKJHNJFONJ_GetEvSave(FJLIDJJAGOM(), null);
    	if(save != null)
		{
			int a = save.KAINPNMMAEK_GetItemCount(RaidItemConstants.Type.FoldRadar);
			a -= HMFFHLPNMPH;
			if(a < 0)
				a = 0;
			save.PPJAGFPBFHJ_SetItemCount(RaidItemConstants.Type.FoldRadar, a);
			save.KMMJMDGLIFA_FrCns = 0;
		}
	}

	// // RVA: 0xC28010 Offset: 0xC28010 VA: 0xC28010
	// public void GFIJEBKPANK(int HMFFHLPNMPH) { }

	// // RVA: 0xC27BAC Offset: 0xC27BAC VA: 0xC27BAC
	public void AKGAFHKMFOO(int HMFFHLPNMPH, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, string MDADLCOCEBN)
	{
		StringBuilder str = new StringBuilder();
		str.Append(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId);
		str.Append(':');
		if(!OMNOFMEBLAD.LFGNLKKFOCD_IsLine6)
		{
			str.Append(FOCPLKMMCAL.PKFJIIJJMGL[(int)OMNOFMEBLAD.AKNELONELJK_Difficulty]);
		}
		else
		{
			str.Append(FOCPLKMMCAL.LKMFBMPKEGN[(int)OMNOFMEBLAD.AKNELONELJK_Difficulty]);
		}
		str.Append(MDADLCOCEBN);
		JANMJPOKLFL_InventoryUtil.JCHLONCMPAJ();
		JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.IMJOELNOOMB_0, str.ToString());
		JANMJPOKLFL_InventoryUtil.CPIICACGNBH_AddItem(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, RaidItemConstants.MakeItemId(RaidItemConstants.Type.FoldRadar), HMFFHLPNMPH, null, 0);
	}

	// // RVA: 0xC28134 Offset: 0xC28134 VA: 0xC28134
	public void KHGKJMODLDE(int HMFFHLPNMPH)
	{
		JANMJPOKLFL_InventoryUtil.JCHLONCMPAJ();
		JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.KGOOLKLPJIP_39, PGIIDPEGGPI_EventId.ToString());
		JANMJPOKLFL_InventoryUtil.CPIICACGNBH_AddItem(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, RaidItemConstants.MakeItemId(RaidItemConstants.Type.FoldRadar), HMFFHLPNMPH, null, 0);
	}

	// // RVA: 0xC20510 Offset: 0xC20510 VA: 0xC20510
	public int PDNFHDLNENO(int PPFNGGCBJKC)
	{
		LDEBIBGHCGD_EventRaidLobby ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LDEBIBGHCGD_EventRaidLobby;
		if(ev != null)
		{
			int cluster = DKNNNOIMMFN_GetClusterId();
			int v = cluster / 60 + PPFNGGCBJKC * 32768;
			if(cluster < 60)
				v = PPFNGGCBJKC << 15;
			return v;
		}
		return 0;
	}

	// // RVA: 0xC282B0 Offset: 0xC282B0 VA: 0xC282B0
	public int DKNNNOIMMFN_GetClusterId()
	{
		LDEBIBGHCGD_EventRaidLobby ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LDEBIBGHCGD_EventRaidLobby;
		if(ev != null)
		{
			int v = (int)(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime() - ev.NGHKJOEDLIP.NIMLIMFPNJP_RaidStart);
			return v;
		}
		return 0;
	}

	// // RVA: 0xC207B8 Offset: 0xC207B8 VA: 0xC207B8
	public static int FAKHCOJIOBD(int PPFNGGCBJKC, int NEFEFHBHFFF/* = 1*/)
	{
		int res = PPFNGGCBJKC << 15;
		if(NEFEFHBHFFF > -1)
			res = PPFNGGCBJKC >> 15;
		return res;
	}
}
