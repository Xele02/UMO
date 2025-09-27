using UnityEngine;
using Cryptor;
using XeSys;
using System.Collections;
using System.Collections.Generic;
using XeApp;
using System.Security.Cryptography;
using System.Text;
using XeApp.Native;
using System.IO;
using System;
using CriWare;
using XeApp.Game.Menu;
using XeApp.Game;
using XeApp.Core;
using XeApp.Game.AR;

public class NKGJPJPHLIF
{
	public int IMDEGHBHAPC; // 0xC
	public string MLKOPOKGHHH_SakashoGameId = ""; // 0x10
	public static bool GKHEAEAPEGB = false; // 0x4
	public IKIIAFKHDFP DHEFMDMGPMG_LoginBonusManager; // 0x1C
	private CIOECGOMILE NLGFEPAJBOJ; // 0x20
	private IMMAOANGPNK EJDOEBLBGIO; // 0x24
	private JGEOBNENMAH FDOODGBBKEE; // 0x28
	private KDHGBOOECKC BOLHOKKOBFG; // 0x2C
	private GNGMCIAIKMA KOECOMOAFJM; // 0x30
	private KEHOJEJMGLJ AFKDJPJOPBH; // 0x34
	private BBGDKLLEPIB AOHJJKHIAMF; // 0x38
	private KDLPEDBKMID BJAONAJFHFA; // 0x3C
	private OEGIPPCADNA AJPPBBAOPIP; // 0x40
	private LAMCONGFONF GOKEBIILKIO; // 0x44
	private NMFABEKNBKJ GALAFFGKBCD; // 0x48
	private EOHDAOAJOHH HFPNGIDPOBF; // 0x4C
	private MBCPNPNMFHB KGHFJJKMCIH; // 0x50
	private KKLGENJKEBN INKOCAJMNLD; // 0x54
	private CNNIKANJMNG NNJPOLGAIIE; // 0x58
	private JEPBIIJDGEF_EventInfo DDNPGALFPBF; // 0x5C
	private BIFNGFAIEIL BBHAHMCFCLH; // 0x60
	private HDEEBKIFLNI GNLBDCOIDMJ; // 0x64
	private EJGJAFBLHHM KGJGLOEIOHJ; // 0x68
	private NDABOOOOENC LEJDPOCMFPL; // 0x6C
	private JDDGPJDKHNE OLKNOPIDFJG; // 0x70
	private EJHPIMANJFP HHAKOEMAOID; // 0x74
	private AGLHPOOPOCG NKFPAJGGAFF; // 0x78
	public LAPFLEEAACL[] HECNGABHNDJ; // 0x7C
	private NHPDPKHMFEP JAECPEDLEMN; // 0x80
	private DOKOHKJIDBO EHIIDBEMILF; // 0x84
	private JHHBAFKMBDL EJIGAABBKCM; // 0x88
	public HPBDNNACBAK FPNBCFJHENI; // 0x8C
	private CNGFKOJANNP BHEDLCLHGPB; // 0x90
	public long OLDKENOLHLL; // 0x98
	public int DHMLDAGGKCD; // 0xA0
	public ARMarkerSaveManager NJMOAHNLDBO;  // 0x9C // 3.1.0
	private long GOEPLCHCCBC; // 0xB0
	private int NMMCABJNNLH; // 0xB8
	public bool DPJBHHIHJJK = true; // 0xBC
	public bool PECPLBANLBN; // 0xBD
	private SakashoAPICallContext KEJNOIJMBLP; // 0xC0
	private int NCECLECJIIG; // 0xC4
	public static bool DPCCNOCAHGC = false; // 0x5
	private long LJBHLFGDBHA; // 0xC8
	public bool ECPEIINJLFL; // 0xD0
	private readonly string[] CNAINDDMPDL = new string[5] {"", "_sb", "_upd", "_qa", "_test" }; // 0xD4
	private static readonly byte[,] HPEBFGPLMBP = new byte[4, 0x10] {
			{0xBD, 0xd4, 0x1d, 0xc7, 0x66, 0x73, 0xa8, 0x47, 0xd5, 0x51, 0x6d, 0x94, 0x4c, 0x31, 0x50, 0xdf},
			{0xb8, 0xa7, 0x4e, 0x09, 0x66, 0x66, 0x25, 0xd9, 0x23, 0xb9, 0x23, 0x3a, 0xe1, 0x2e, 0x17, 0x48},
			{0x17, 0xa9, 0x32, 0x42, 0x2d, 0x31, 0x9a, 0xda, 0x4f, 0x0a, 0xa7, 0xfa, 0x01, 0x10, 0xb0, 0xed},
			{0x9e, 0xdf, 0xf7, 0x09, 0x80, 0x71, 0xe8, 0x27, 0x05, 0x27, 0x7c, 0xb5, 0x2f, 0x21, 0xce, 0x98}
			}; //TODO order ? // 0x8

	public static NKGJPJPHLIF HHCJCDFCLOB { get; private set; } // 0x0 LGMPACEDIJF / Get NKACBOEHELJ / Set OKPMHKNCNAL
	public bool CGMMHFHHLID { get; private set; } // 0x8 KLJECKGKIDJ FNMKBDKDJMO 0xC165C8 BMAMAHBGOGL 0xC165D0
	public PJKLMCGEJMK IBLPICFDGOF_ServerRequester { get; private set; }  // 0x14 BHLNCEJLGII // 0x14 // get OIFEGPGEFEI // set BCEJHLMIIGE
	public OPKDHAODJOA HKDHHMHHJOJ { get; private set; } // 0x18 KFENGIGCDMF OHMLGPPPNLK 0xC165E8 PPBPMOIOLBM 0xC165F0
	public int MDAMJIGBOLD_PlayerId { get; private set; } // PlayerId // 0xA4 HBKPDFNAAOI PIIJNAHENJE 0xC165F8 HOBDGADNPGJ 0xC16600 
	public bool DCPCLHOJEHE { get; private set; } // 0xA8 JNJNPIHKNHE AHAHNANHOCN 0xC16A3C EGPFAFPDNJH 0xC16A44
	public int AFJEOKGBCNA_NumReplies { get; private set; } // 0xAC BLKAENELKCD AFEOFCFFAHA 0xC16A4C HHLMPHKALAF 0xC16A54

	// // RVA: 0xC16608 Offset: 0xC16608 VA: 0xC16608
	public int CAFHLEFMMGD_GetPlayerId()
	{
		return MDAMJIGBOLD_PlayerId;
	}

	// // RVA: 0xC16610 Offset: 0xC16610 VA: 0xC16610
	public bool KKMCBNKDDPN(int _MLPEHNBNOGD_PlayerId)
	{
		return MDAMJIGBOLD_PlayerId == _MLPEHNBNOGD_PlayerId;
	}

	// // RVA: 0xC16624 Offset: 0xC16624 VA: 0xC16624
	public void IJMGMJHLGDG(int NJPGHGIICME)
	{
		MDAMJIGBOLD_PlayerId = NJPGHGIICME;
		LFGOHEKCDFN(NJPGHGIICME);
	}

	// RVA: 0xC16A5C Offset: 0xC16A5C VA: 0xC16A5C
	public void IJBGPAENLJA(MonoBehaviour _DANMJLOBLIE_mb)
	{
		GHNFIINGIGM.HKICMNAACDA_a();
		CEDHHAGBIBA.LBLGDJJGFIO = (uint)Utility.GetCurrentUnixTime();
		//DANMJLOBLIE_mb.gameObject
		HHCJCDFCLOB = this;
		LPDNKHAIOLH.KHEKNNFCAOI_Init((int)((CEDHHAGBIBA.LBLGDJJGFIO * 35) & 0x7fffffff));

		BHEDLCLHGPB = new CNGFKOJANNP();
		BHEDLCLHGPB.IJBGPAENLJA_Init(_DANMJLOBLIE_mb);

		MNNCBFONAOL.KHEKNNFCAOI_Init();//101
		JEHIAIPJNJF_FileDownloader.BNGLMLOLPEL_Initialize();

		OLKNOPIDFJG = new JDDGPJDKHNE(); //108
		OLKNOPIDFJG.IJBGPAENLJA();

		EHIIDBEMILF = new DOKOHKJIDBO(); //117
		EHIIDBEMILF.KIDFJDNOGDG();

		HHAKOEMAOID = new EJHPIMANJFP();
		HHAKOEMAOID.IJBGPAENLJA();

		IBLPICFDGOF_ServerRequester = new PJKLMCGEJMK(); // 133
		IBLPICFDGOF_ServerRequester.IJBGPAENLJA_Start(_DANMJLOBLIE_mb);

		HKDHHMHHJOJ = new OPKDHAODJOA();
		HKDHHMHHJOJ.IJBGPAENLJA(_DANMJLOBLIE_mb);

		NLGFEPAJBOJ = new CIOECGOMILE();
		NLGFEPAJBOJ.IJBGPAENLJA(_DANMJLOBLIE_mb);

		EJDOEBLBGIO = new IMMAOANGPNK(); //155
		EJDOEBLBGIO.IJBGPAENLJA(_DANMJLOBLIE_mb);

		FDOODGBBKEE = new JGEOBNENMAH();
		FDOODGBBKEE.IJBGPAENLJA(_DANMJLOBLIE_mb);

		BOLHOKKOBFG = new KDHGBOOECKC();
		BOLHOKKOBFG.IJBGPAENLJA(_DANMJLOBLIE_mb);

		KOECOMOAFJM = new GNGMCIAIKMA();
		KOECOMOAFJM.IJBGPAENLJA(_DANMJLOBLIE_mb);

		EJIGAABBKCM = new JHHBAFKMBDL();
		EJIGAABBKCM.IJBGPAENLJA_Start(_DANMJLOBLIE_mb);

		AFKDJPJOPBH = new KEHOJEJMGLJ();
		AFKDJPJOPBH.IJBGPAENLJA(_DANMJLOBLIE_mb);

		AOHJJKHIAMF = new BBGDKLLEPIB(); //204
		AOHJJKHIAMF.IJBGPAENLJA(_DANMJLOBLIE_mb);

		BJAONAJFHFA = new KDLPEDBKMID();
		BJAONAJFHFA.IJBGPAENLJA_OnAwake(_DANMJLOBLIE_mb);

		AJPPBBAOPIP = new OEGIPPCADNA();
		AJPPBBAOPIP.IJBGPAENLJA(_DANMJLOBLIE_mb);

		GOKEBIILKIO = new LAMCONGFONF();
		GOKEBIILKIO.IJBGPAENLJA(_DANMJLOBLIE_mb);

		GALAFFGKBCD = new NMFABEKNBKJ();
		GALAFFGKBCD.IJBGPAENLJA(_DANMJLOBLIE_mb);

		HFPNGIDPOBF = new EOHDAOAJOHH();
		HFPNGIDPOBF.IJBGPAENLJA(_DANMJLOBLIE_mb);

		FPNBCFJHENI = new HPBDNNACBAK();

		KGHFJJKMCIH = new MBCPNPNMFHB();
		KGHFJJKMCIH.IJBGPAENLJA();

		INKOCAJMNLD = new KKLGENJKEBN();
		INKOCAJMNLD.IJBGPAENLJA(_DANMJLOBLIE_mb);

		NNJPOLGAIIE = new CNNIKANJMNG();
		NNJPOLGAIIE.IJBGPAENLJA(_DANMJLOBLIE_mb);

		DDNPGALFPBF = new JEPBIIJDGEF_EventInfo();
		DDNPGALFPBF.IJBGPAENLJA(_DANMJLOBLIE_mb);

		BBHAHMCFCLH = new BIFNGFAIEIL();
		BBHAHMCFCLH.IJBGPAENLJA(_DANMJLOBLIE_mb);

		GNLBDCOIDMJ = new HDEEBKIFLNI();
		GNLBDCOIDMJ.IJBGPAENLJA(_DANMJLOBLIE_mb);

		KGJGLOEIOHJ = new EJGJAFBLHHM();
		KGJGLOEIOHJ.IJBGPAENLJA(_DANMJLOBLIE_mb);

		NKFPAJGGAFF = new AGLHPOOPOCG();

		IBLPICFDGOF_ServerRequester.LJPJJHGIEAO = EJIGAABBKCM.ICELKJMJJJH;
		IBLPICFDGOF_ServerRequester.IGAMFDCEGFC = EJIGAABBKCM.AJIJCMKMAMA;
		IBLPICFDGOF_ServerRequester.LLFDDHIIPBK = EJIGAABBKCM.NNOBHCCINEN;
		IBLPICFDGOF_ServerRequester.CCBAMLACFCF = EJIGAABBKCM.NCBLFMHKAFL;
		IBLPICFDGOF_ServerRequester.EGAOFAHEPME = EJIGAABBKCM.CIKMDHMMCIL;
		IBLPICFDGOF_ServerRequester.NIJMLFNDAJP = EJIGAABBKCM.APEODCECEON;
		IBLPICFDGOF_ServerRequester.OMAGHCDMBBI = EJIGAABBKCM.BJMLDGKHFLJ;
		IBLPICFDGOF_ServerRequester.DMPHNPAFHEG = EJIGAABBKCM.NIGGABHIFEE_ShowTransmissionIcon;
		KGHFJJKMCIH.OIPOPJCPDPC_DisplayUrlCb = EJIGAABBKCM.INCAHPACGAF_ShowWebView;
		KGHFJJKMCIH.LKKNBHCGFBG = EJIGAABBKCM.EAADBLJMIPP;

		LEJDPOCMFPL = new NDABOOOOENC();
		LEJDPOCMFPL.IJBGPAENLJA_Init();

		HECNGABHNDJ = new LAPFLEEAACL[5];
		HECNGABHNDJ[0] = new LAPFLEEAACL(/*2*/HHJHIFJIKAC_BonusVc.IJFKAIHFJLF.JEPMLKCJCPK_2_Bonus_4001_4002);
		HECNGABHNDJ[1] = new LAPFLEEAACL(/*6*/HHJHIFJIKAC_BonusVc.IJFKAIHFJLF.ONIIJLCOCAC_6);
		HECNGABHNDJ[2] = new LAPFLEEAACL(/*7*/HHJHIFJIKAC_BonusVc.IJFKAIHFJLF.MCPDGFMLJNG_7_Bonus4003);
		HECNGABHNDJ[3] = new LAPFLEEAACL(/*8*/HHJHIFJIKAC_BonusVc.IJFKAIHFJLF.PPPGDKCDACF_8_Omikuji);
		HECNGABHNDJ[4] = new LAPFLEEAACL(/*5*/HHJHIFJIKAC_BonusVc.IJFKAIHFJLF.MDIJEKDNLFC_5_SpecialTickets);

		JAECPEDLEMN = new NHPDPKHMFEP();
		JAECPEDLEMN.IJBGPAENLJA();

		DCPCLHOJEHE = false;

		NJMOAHNLDBO = new ARMarkerSaveManager();
	}

	// RVA: 0xC179B0 Offset: 0xC179B0 VA: 0xC179B0
	public void BAGMHFKPFIF()
	{
		DsfdLoader.Update();
		BJAONAJFHFA.BAGMHFKPFIF();
		IBLPICFDGOF_ServerRequester.BAGMHFKPFIF_Update();
		HKDHHMHHJOJ.BAGMHFKPFIF();
		NLGFEPAJBOJ.BAGMHFKPFIF_Update();
		EJDOEBLBGIO.BAGMHFKPFIF();
		OLKNOPIDFJG.BAGMHFKPFIF();
		BHEDLCLHGPB.BAGMHFKPFIF_Update();
		CADNBFCHAKM_UpdateServerTime();
	}

	// RVA: 0xC17D40 Offset: 0xC17D40 VA: 0xC17D40
	public void FFBCKMFKFME()
	{
		JEHIAIPJNJF_FileDownloader.IKPHNPJFNEG_Finalize();
		if (BJAONAJFHFA != null)
		{
			BJAONAJFHFA.FFBCKMFKFME();
			BJAONAJFHFA = null;
		}
		if (IBLPICFDGOF_ServerRequester != null)
		{
			IBLPICFDGOF_ServerRequester.FFBCKMFKFME();
			IBLPICFDGOF_ServerRequester = null;
		}
		MNNCBFONAOL.PDENBOEFJGE();
		HHCJCDFCLOB = this;
	}

	// // RVA: 0xC17E34 Offset: 0xC17E34 VA: 0xC17E34
	public void FGDBKOCCKOE(bool CKLGHFBPFPJ)
	{
		if(GALAFFGKBCD != null)
			GALAFFGKBCD.FGDBKOCCKOE(CKLGHFBPFPJ);
		if(HFPNGIDPOBF != null)
			HFPNGIDPOBF.FGDBKOCCKOE(CKLGHFBPFPJ);
		if(BHEDLCLHGPB != null)
			BHEDLCLHGPB.FGDBKOCCKOE(CKLGHFBPFPJ);
		if(!CKLGHFBPFPJ)
		{
			DPJBHHIHJJK = true;
			PECPLBANLBN = true;
		}
	}

	// // RVA: 0xC17E9C Offset: 0xC17E9C VA: 0xC17E9C
	public void ODLGKIJCHGH(IMCBBOAFION _KLMFJJCNBIP_OnSuccess)
	{
		N.a.StartCoroutineWatched(MAMKIDBAINA_Coroutine_InitializeSystem(_KLMFJJCNBIP_OnSuccess));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B9838 Offset: 0x6B9838 VA: 0x6B9838
	// // RVA: 0xC17EEC Offset: 0xC17EEC VA: 0xC17EEC
	private IEnumerator MAMKIDBAINA_Coroutine_InitializeSystem(IMCBBOAFION _KLMFJJCNBIP_OnSuccess)
	{
		// public NKGJPJPHLIF KIGBLACMODG; // 0x10
		// private NKGJPJPHLIF.<>c__DisplayClass73_0 OPLBFCEPDCH; // 0x14
		// public IMCBBOAFION _KLMFJJCNBIP_OnSuccess; // 0x18
		// private List<NKCNFFPLIAN> NCAAFGHKNAN; // 0x1C
		//0xC1BD5C

		yield return null;
		SakashoInitializer s = N.a.GetComponent<SakashoInitializer>();
		if (s == null)
		{
			List<NKCNFFPLIAN> NCAAFGHKNAN = NKCNFFPLIAN.PCODDPDFLHK();
			yield return N.a.StartCoroutineWatched(EEOJBAHJAIN_Coroutine_Nil());

			string LNOLGFLNAAI = AppEnv.sakashoConnectTargetType[(int)AppEnv.GetSakashoConnectTarget()];
			if (NMMCABJNNLH < CNAINDDMPDL.Length)
			{
				LNOLGFLNAAI = LNOLGFLNAAI + CNAINDDMPDL[NMMCABJNNLH];
			}
			NKCNFFPLIAN a = NCAAFGHKNAN.Find((NKCNFFPLIAN PKLPKMLGFGK) =>
			{
				// 0xC1A774
				return LNOLGFLNAAI == PKLPKMLGFGK.OPFGFINHFCE_name;
			});
			if (a != null)
			{
				N.a.A().transform.parent = N.a.transform;
				s = N.a.A().GetComponent<SakashoInitializer>();
				s.serverMode = a.CNDDKMJAIBG_mode;
				s.sakashoGameId = "" + a.DMJGDDEACMD_game_id;
				s.sakashoCommonKey = a.LJNAKDMILMC_key;
				s.paymentType = 0;
				MLKOPOKGHHH_SakashoGameId = s.sakashoGameId;
				IMDEGHBHAPC = a.CNDDKMJAIBG_mode;
				yield return new WaitForSeconds(0.1f);
			}
			else
			{
				TodoLogger.LogError(TodoLogger.Coroutine, "Exit  Error MAMKIDBAINA_Coroutine_InitializeSystem");
				yield break;
			}
		}
		CGMMHFHHLID = true;
		if (_KLMFJJCNBIP_OnSuccess != null)
			_KLMFJJCNBIP_OnSuccess();
	}

	// // RVA: 0xC17FB4 Offset: 0xC17FB4 VA: 0xC17FB4
	public void HGJKAEOLMJN_InitializePlayerToken(IMCBBOAFION KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _JGKOLBLPMPG_OnFail, bool MKFJAGGLEFL/* = true*/, bool _FBBNPFFEJBN_Force/* = false*/)
	{
		N.a.StartCoroutineWatched(PFKIHFCAPNC_Coroutine_InitializePlayerToken(KLMFJJCNBIP_OnSuccess, _JGKOLBLPMPG_OnFail, MKFJAGGLEFL, _FBBNPFFEJBN_Force));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B98B0 Offset: 0x6B98B0 VA: 0x6B98B0
	// // RVA: 0xC18024 Offset: 0xC18024 VA: 0xC18024
	private IEnumerator PFKIHFCAPNC_Coroutine_InitializePlayerToken(IMCBBOAFION KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _JGKOLBLPMPG_OnFail, bool MKFJAGGLEFL, bool _FBBNPFFEJBN_Force)
	{
		// public NKGJPJPHLIF KIGBLACMODG; // 0x10
		// private HHEIANIHCNH_RequestPlayerStatus FFEEIONIBFF; // 0x24
		// private PKNOGNLPHAE_CreatePlayer CNEMMHHJKNG; // 0x28
		//0xC1B698

		//UMO
		bool isCheat = MDAMJIGBOLD_PlayerId == 999999999;

		if(MDAMJIGBOLD_PlayerId != 0 && !_FBBNPFFEJBN_Force && ExternLib.LibSakasho.GetCurrentAccountId() == MDAMJIGBOLD_PlayerId)
		{
			//goto LAB_00c1bbc4;
			if(KLMFJJCNBIP_OnSuccess != null)
				KLMFJJCNBIP_OnSuccess();
			yield break;
		}
		HHEIANIHCNH_RequestPlayerStatus FFEEIONIBFF_Request = IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest<HHEIANIHCNH_RequestPlayerStatus>(new HHEIANIHCNH_RequestPlayerStatus());
		FFEEIONIBFF_Request.EOPCHGLLONF = MKFJAGGLEFL;
		yield return FFEEIONIBFF_Request.GDPDELLNOBO_WaitDone(N.a);

		//1

		if(FFEEIONIBFF_Request.NPNNPNAIONN_IsError)
		{
			//goto LAB_00c1b8f8;
			if(_JGKOLBLPMPG_OnFail != null)
				_JGKOLBLPMPG_OnFail();
			yield break;
		}
		//L177
		int playerId = 0;
		int accountStatus = 0;
		if(FFEEIONIBFF_Request.NFEAMMJIMPG_Result.OGADPAILFBC_IsCreated()) // iscreated
		{
			playerId = FFEEIONIBFF_Request.NFEAMMJIMPG_Result.EHGBICNIBKE_player_id;
			accountStatus = FFEEIONIBFF_Request.NFEAMMJIMPG_Result.JFMEKPDHJPP_player_account_status;
			FFEEIONIBFF_Request = null;
			//goto LAB_00c1b9d8;
		}
		else
		{
			//L214
			// UMO Display account type creation popup, check if full account is already created?
			//int accountType = 1; // 0 = normal, 1 = full unlock
			int accountType = isCheat ? 1 : 0;

			FFEEIONIBFF_Request = null;
			PKNOGNLPHAE_CreatePlayer CNEMMHHJKNG = IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new PKNOGNLPHAE_CreatePlayer());
			CNEMMHHJKNG.AccountType = accountType;
			yield return CNEMMHHJKNG.GDPDELLNOBO_WaitDone(N.a);
			//2
			if (!CNEMMHHJKNG.NPNNPNAIONN_IsError)
			{
				if(!CNEMMHHJKNG.PDAPLCPOCMA)
				{
					playerId = CNEMMHHJKNG.NFEAMMJIMPG_Result.EHGBICNIBKE_player_id;
					LFGOHEKCDFN(playerId);
					accountStatus = CNEMMHHJKNG.NFEAMMJIMPG_Result.JFMEKPDHJPP_player_account_status;
					CNEMMHHJKNG = null;
				}
				else
				{
					if (_JGKOLBLPMPG_OnFail != null)
						_JGKOLBLPMPG_OnFail();
					yield break;
				}
			}

		}
		//LAB_00c1b9d8
		object[] args = new object[4];
		args[0] = "game_id=";
		args[1] = MLKOPOKGHHH_SakashoGameId;
		args[2] = " player_id=";
		args[3] = playerId;
		Crittercism.SetUsername(String.Concat(args));
		DCPCLHOJEHE = false;
		MDAMJIGBOLD_PlayerId = playerId;
		if(accountStatus == -1)
			DCPCLHOJEHE = true;
		if(KLMFJJCNBIP_OnSuccess != null)
			KLMFJJCNBIP_OnSuccess();
	}

	// // RVA: 0xC1662C Offset: 0xC1662C VA: 0xC1662C
	public void LFGOHEKCDFN(int _MLPEHNBNOGD_PlayerId)
	{
		if (_MLPEHNBNOGD_PlayerId == 0)
			return;
		GameManager.Instance.localSave.LHPDDGIJKNB_Reset();
		UMO_PlayerPrefs.SetInt("cpid", _MLPEHNBNOGD_PlayerId);
		UMO_PlayerPrefs.Save();
		GameManager.Instance.localSave.PCODDPDFLHK_Load();
		BIFNGFAIEIL.BLICHJOLKAO_DeleteCache();
		EFLBHNFNFHA.KEIPMGOEKFL_DeleteCache();
		FPNBCFJHENI.JHPGCAHIDIO_DeleteCache();
		if(AppQualitySetting.spec < AppQualitySetting.DeviceSpec.High)
		{
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.DDHCLNFPNGK_RenderQuality = 1;
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().MHHPDGJLJGE_OptionsSLive.DDHCLNFPNGK_RenderQuality = 0;
		}
		else
		{
			if(AppQualitySetting.spec != AppQualitySetting.DeviceSpec.High)
			{
				;
			}
			else
			{
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.DDHCLNFPNGK_RenderQuality = 0;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.DDHCLNFPNGK_RenderQuality = 0;
			}
		}
		GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.GEPLOFLHAOL_NeedInitRenderQuality = 1;
		GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
		Debug.Log(JpStringLiterals.StringLiteral_12640);
		PKECIDPBEFL.GDELLNOBNDM_DeleteCache();
	}

	// // RVA: 0xC1813C Offset: 0xC1813C VA: 0xC1813C
	// public void CCMPLEKABLF(bool ILMANDAFLDL, IMCBBOAFION _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _JGKOLBLPMPG_OnFail) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B9928 Offset: 0x6B9928 VA: 0x6B9928
	// // RVA: 0xC18168 Offset: 0xC18168 VA: 0xC18168
	// private IEnumerator APIJCBPFJMM(bool ILMANDAFLDL, IMCBBOAFION _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _JGKOLBLPMPG_OnFail) { }

	// // RVA: 0xC18260 Offset: 0xC18260 VA: 0xC18260
	public void EFPOACOOAFB(bool _FBBNPFFEJBN_Force)
	{
		if(NLGFEPAJBOJ.LNAHEIEIBOI_Initialized)
		{
			NLGFEPAJBOJ.OIEBCNPOMIB_UpdateDayChange(_FBBNPFFEJBN_Force);
			NLGFEPAJBOJ.KPHFDEOFKLM_UpdateEnergyDayChange();
			NLGFEPAJBOJ.LBLNLMGHLAG_UpdateShop();
			NLGFEPAJBOJ.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.LPFFDGNDLKG_UpdateMedals(true, 2160);
			NLGFEPAJBOJ.FAFAKNJLLIC_ResetIntimacyPresentLeft();
			NLGFEPAJBOJ.CDIADEIOIHP_ResetIntimacyTouchCount();
			KDHGBOOECKC.HHCJCDFCLOB.PCPECPFJMGC();
			FPNBCFJHENI.CIEDHFEKKII();
			if(NHPDPKHMFEP.HHCJCDFCLOB != null)
			{
				NHPDPKHMFEP.HHCJCDFCLOB.DLGMLAJMLOP = true;
			}
		}
		long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.LOMEEJGIAHO.JOJFKIIHMOJ(t);
		MenuScene.IsAlreadyHome = false;
		FPNBCFJHENI.ECFNAOCFKKN_LastDate = 0;
		FPNBCFJHENI.MILIGHHGOML.Clear();
		HHAKOEMAOID.ECFNAOCFKKN_LastDate = 0;
		DateTime d = Utility.GetLocalDateTime(t);
		DHMLDAGGKCD = d.Month * 100 + d.Year * 100000 + d.Day;
		if(NLGFEPAJBOJ.LNAHEIEIBOI_Initialized)
		{
			NLGFEPAJBOJ.OFGCPFFPGHE(_FBBNPFFEJBN_Force);
			NLGFEPAJBOJ.NPAPJMLJBKM(_FBBNPFFEJBN_Force);
		}
		DCOKFLPPHEB();
	}

	// // RVA: 0xC187C4 Offset: 0xC187C4 VA: 0xC187C4
	public void NIJDPPHGHFD_ResetDates(bool _FBBNPFFEJBN_Force)
	{
		MenuScene.IsAlreadyHome = false;
		HHAKOEMAOID.ECFNAOCFKKN_LastDate = 0;
		FPNBCFJHENI.ECFNAOCFKKN_LastDate = 0;
		FPNBCFJHENI.MILIGHHGOML.Clear();
		EJDOEBLBGIO.GCELJIDIGDG = null;
		DCOKFLPPHEB();
	}

	// // RVA: 0xC18778 Offset: 0xC18778 VA: 0xC18778
	public void DCOKFLPPHEB()
	{
		FPNBCFJHENI.ECFNAOCFKKN_LastDate = 0;
		HHAKOEMAOID.ECFNAOCFKKN_LastDate = 0;
	}

	// // RVA: 0xC188EC Offset: 0xC188EC VA: 0xC188EC
	public void LBEHLMLKPDM(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		long time = IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		HFPNGIDPOBF.KCKLPAEILNH_CancelStaminaLotNotif();
		HFPNGIDPOBF.NNGHCGKIIHM_SetStaminaLotNotif(false);
		if(IBLPICFDGOF_ServerRequester.IEFOIIAEBBJ && !IBLPICFDGOF_ServerRequester.NFECEPJEMHG)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JHFIPCIHJNL_Base.IJHBIMNKOMC_tutorial_end == 2)
			{
				IBLPICFDGOF_ServerRequester.NFECEPJEMHG = true;
				int disable_recmonded_notice = EJDOEBLBGIO.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("disable_recmonded_notice", 0);
				if(disable_recmonded_notice == 0)
				{
					N.a.StartCoroutineWatched(BDJBKBMJHOP_Coroutine_UpdateNotice(_BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail));
					return;
				}
			}
		}
		if(299 >= (time - OLDKENOLHLL) && !NHPDPKHMFEP.HHCJCDFCLOB.DLGMLAJMLOP)
		{
			_BHFHGFKBOHH_OnSuccess();
		}
		N.a.StartCoroutineWatched(NGDEGDHBIHF_Coroutine_PrepareHome(_BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B99A0 Offset: 0x6B99A0 VA: 0x6B99A0
	// // RVA: 0xC18C58 Offset: 0xC18C58 VA: 0xC18C58
	private IEnumerator BDJBKBMJHOP_Coroutine_UpdateNotice(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		//0xC1D2C4
		bool BEKAMBBOLBO_Done = false;
		while(true)
		{
			BEKAMBBOLBO_Done = false;
			bool MAKBLJGIBKJ = false;
			JFDNPFFOACP BAHANNNJCGC = () =>
			{
				//0xC1A82C
				BEKAMBBOLBO_Done = true;
			};
			EJIGAABBKCM.GLJAPKKLIJJ_ShowUpdatePopup(() =>
			{
				//0xC1A840
				BEKAMBBOLBO_Done = true;
				MAKBLJGIBKJ = true;
			}, BAHANNNJCGC);
			while (!BEKAMBBOLBO_Done)
				yield return null;
			if(MAKBLJGIBKJ)
			{
				Application.OpenURL(EJDOEBLBGIO.NKEBMCIMJND_Database.GDEKCOOBLMA_System.JLJEEMEOPLE["review_android"]);
			}
			else
			{
				break;
			}
		}
		N.a.StartCoroutineWatched(NGDEGDHBIHF_Coroutine_PrepareHome(_BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B9A18 Offset: 0x6B9A18 VA: 0x6B9A18
	// // RVA: 0xC18D18 Offset: 0xC18D18 VA: 0xC18D18
	private IEnumerator NGDEGDHBIHF_Coroutine_PrepareHome(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		PIGBKEIAMPE_FriendManager FEAAEDHHBNB;
		PJKLMCGEJMK JFAIABBIPEO;
		DOLDMCAMEOD_RequestRemainingForCurrencyIds BPOJOBICBAC;

		//0xC1C714
		CIOECGOMILE.HHCJCDFCLOB.NAOGKAIBBEH();
		FEAAEDHHBNB = CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager;
		bool BEKAMBBOLBO_Done = false;
		bool CNAIDEAFAAM_Error = false;
		FEAAEDHHBNB.PFJBNPIBFMO_GetReceivedRequests(() =>
		{
			//0xC1A878
			BEKAMBBOLBO_Done = true;
		}, (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0xC1A884
			BEKAMBBOLBO_Done = true;
			CNAIDEAFAAM_Error = true;
		}, false);
		while (!BEKAMBBOLBO_Done)
			yield return null;
		if(!CNAIDEAFAAM_Error)
		{
			BEKAMBBOLBO_Done = false;
			CNAIDEAFAAM_Error = false;
			FEAAEDHHBNB.BMJANOADDCC_GetFriends(() =>
			{
				//0xC1A890
				BEKAMBBOLBO_Done = true;
			}, (CACGCMBKHDI_Request JIPCHHHLOMM) =>
			{
				//0xC1A89C
				BEKAMBBOLBO_Done = true;
				CNAIDEAFAAM_Error = true;
			}, false);
			while(!BEKAMBBOLBO_Done)
			{
				yield return null;
			}
			if(!CNAIDEAFAAM_Error)
			{
				BEKAMBBOLBO_Done = false;
				CNAIDEAFAAM_Error = false;
				NLGFEPAJBOJ.KPFKKDDOHCN.BDPMNDGIEGI_RequestInventories(() =>
				{
					//0xC1A8A8
					BEKAMBBOLBO_Done = true;
				}, (CACGCMBKHDI_Request _ADKIDBJCAJA_action) =>
				{
					//0xC1A8B4
					BEKAMBBOLBO_Done = true;
					CNAIDEAFAAM_Error = true;
				}, false);
				while (!NLGFEPAJBOJ.KPFKKDDOHCN.PLOOEECNHFB_IsDone)
					yield return null;
				if(!CNAIDEAFAAM_Error)
				{
					JFAIABBIPEO = IBLPICFDGOF_ServerRequester;
					BPOJOBICBAC = JFAIABBIPEO.IFFNCAFNEAG_AddRequest(new DOLDMCAMEOD_RequestRemainingForCurrencyIds());
					BPOJOBICBAC.CGCFENMHJIM_Ids = new List<int>(1);
					BPOJOBICBAC.CGCFENMHJIM_Ids.Add(1001);
					yield return BPOJOBICBAC.GDPDELLNOBO_WaitDone(N.a);
					if(BPOJOBICBAC.NPNNPNAIONN_IsError)
					{
						if (_AOCANKOMKFG_OnError != null)
							_AOCANKOMKFG_OnError();
						yield break;
					}
					CIOECGOMILE.HHCJCDFCLOB.DJICHKCLMCD_UpdateCurrencies(BPOJOBICBAC.NFEAMMJIMPG_Result.BBEPLKNMICJ_balances);
					OLDKENOLHLL = JFAIABBIPEO.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
					BEKAMBBOLBO_Done = false;
					CNAIDEAFAAM_Error = false;
					LLMEJNALPJD(false, () =>
					{
						//0xC1A8C0
						BEKAMBBOLBO_Done = true;
					}, () =>
					{
						//0xC1A8CC
						BEKAMBBOLBO_Done = true;
						CNAIDEAFAAM_Error = true;
					}, true);
					while (!BEKAMBBOLBO_Done)
						yield return null;
					if(!CNAIDEAFAAM_Error)
					{
						BEKAMBBOLBO_Done = false;
						CNAIDEAFAAM_Error = false;
						NHPDPKHMFEP.HHCJCDFCLOB.NDAIOIOMPGG(() =>
						{
							//0xC1A8D8
							BEKAMBBOLBO_Done = true;
						}, () =>
						{
							//0xC1A8E4
							BEKAMBBOLBO_Done = true;
							CNAIDEAFAAM_Error = true;
						});
						while (!BEKAMBBOLBO_Done)
							yield return null;
						if(!CNAIDEAFAAM_Error)
						{
							_BHFHGFKBOHH_OnSuccess();
							yield break;
						}
					}
				}
			}
		}
		_AOCANKOMKFG_OnError();
	}

	// // RVA: 0xC18E18 Offset: 0xC18E18 VA: 0xC18E18
	public void LLMEJNALPJD(bool _FBBNPFFEJBN_Force, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, bool LFIEDDHNLBE)
	{
		// // RVA: 0xC1A8F0 Offset: 0xC1A8F0 VA: 0xC1A8F0
		// internal void OOLONOGEELA(CACGCMBKHDI_Request JIPCHHHLOMM) { }
		// // RVA:  Offset: 0xC1AA34 VA: 0xC1AA34
		// internal void HPCLPPCILDO(CACGCMBKHDI_Request JIPCHHHLOMM) { }

		if((IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime() - GOEPLCHCCBC) <= 1799 && !_FBBNPFFEJBN_Force)
		{
			if(_BHFHGFKBOHH_OnSuccess != null)
			{
				_BHFHGFKBOHH_OnSuccess();
			}
			return;
		}
		IHKOJFIFPKB_RequestInquiryResponsesNumber COJNCNGHIJC_Req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest<IHKOJFIFPKB_RequestInquiryResponsesNumber>(new IHKOJFIFPKB_RequestInquiryResponsesNumber());
		if(!LFIEDDHNLBE)
		{
			COJNCNGHIJC_Req.AILPHBMCCGP = true;
			COJNCNGHIJC_Req.NBFDEFGFLPJ = (SakashoErrorId FMEMECBIDIB) => {
				//0xC1A70C
				return true;
			};
		}
		COJNCNGHIJC_Req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) => {
			//0xC1A8F0
			int numReplies = 0;
			if(COJNCNGHIJC_Req.NFEAMMJIMPG_Result != null)
			{
				numReplies = COJNCNGHIJC_Req.NFEAMMJIMPG_Result.PNAAOBECMPA_num_replies;
			}
			AFJEOKGBCNA_NumReplies = numReplies;
			GOEPLCHCCBC = IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			if(_BHFHGFKBOHH_OnSuccess != null)
			{
				_BHFHGFKBOHH_OnSuccess();
			}
		};
		COJNCNGHIJC_Req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) => {
			//0xC1AA34
			AFJEOKGBCNA_NumReplies = 0;
			if(_MOBEEPPKFLG_OnFail != null)
			{
				_MOBEEPPKFLG_OnFail();
			}
		};
	}

	// // RVA: 0xC191CC Offset: 0xC191CC VA: 0xC191CC
	public void NBLAOIPJFGL_OpenURL(string HJLDBEJOMIO)
	{
		int id = MDAMJIGBOLD_PlayerId;
		if (id == 0)
			id = UMO_PlayerPrefs.GetInt("cpid", 0);
		Application.OpenURL(HJLDBEJOMIO.Replace("saka_player_id", id.ToString()));
	}

	// // RVA: 0xC1929C Offset: 0xC1929C VA: 0xC1929C
	public void NBLAOIPJFGL_OpenURL(string HJLDBEJOMIO, IMCBBOAFION _HIDFAIBOHCC_OnSuccess)
	{
		N.a.StartCoroutineWatched(LOBOGDLABMH_Coroutine_CustomOpenURL(HJLDBEJOMIO, _HIDFAIBOHCC_OnSuccess));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B9A90 Offset: 0x6B9A90 VA: 0x6B9A90
	// // RVA: 0xC192EC Offset: 0xC192EC VA: 0xC192EC
	private IEnumerator LOBOGDLABMH_Coroutine_CustomOpenURL(string HJLDBEJOMIO, IMCBBOAFION _HIDFAIBOHCC_OnSuccess)
	{
		//0xC1AA78
		Application.OpenURL(HJLDBEJOMIO);
		yield return new WaitForSeconds(0.5f);
		_HIDFAIBOHCC_OnSuccess();
	}

	// RVA: 0xC17AC4 Offset: 0xC17AC4 VA: 0xC17AC4
	private void CADNBFCHAKM_UpdateServerTime()
	{
		if (CGMMHFHHLID)
		{
			if (KEJNOIJMBLP == null)
			{
				if (DPCCNOCAHGC && PECPLBANLBN)
				{
					if (EJDOEBLBGIO.LNAHEIEIBOI_Initialized)
					{
						if (EJDOEBLBGIO.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("server_time_auto_update", 0) == 0)
							return;
						if ((LJBHLFGDBHA - Utility.GetCurrentUnixTime()) <= 30)
						{
							PECPLBANLBN = false;
							return;
						}
						NCECLECJIIG = 0;
						KEJNOIJMBLP = SakashoSupportSite.GetToken(
							(string _IDLHJIOMJBK_data) =>
							{ // success
								//0xC1A424
								OBOKMHHMOIL_ServerInfo o = new OBOKMHHMOIL_ServerInfo();
								o.KHEKNNFCAOI_Init(_IDLHJIOMJBK_data);
								NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.EAJMLOKKOOK_SetServerTime(o.LCAINKFINEI_SakashoCurrentDateTime);
								KEJNOIJMBLP = null;
								DPJBHHIHJJK = false;
								PECPLBANLBN = false; // ?   strh r5,[r4,#0xbc]
								LJBHLFGDBHA = Utility.GetCurrentUnixTime();
								ECPEIINJLFL = false;
								UnityEngine.Debug.Log("ServerTime Auto Updated ok");
							},
							(SakashoError FMEMECBIDIB) => // Fail
							{
								//0xC1A5EC
								PECPLBANLBN = false;
								KEJNOIJMBLP = null;
								ECPEIINJLFL = true;
								UnityEngine.Debug.Log("ServerTime Auto Updated error");
							});
					}
				}
			}
			else
			{
				NCECLECJIIG = NCECLECJIIG + 1;
				if (NCECLECJIIG > 180)
				{
					KEJNOIJMBLP.CancelAPICall();
					KEJNOIJMBLP = null;
					PECPLBANLBN = false;
					ECPEIINJLFL = true;
				}
			}
		}
	}

	// // RVA: 0xC193B4 Offset: 0xC193B4 VA: 0xC193B4
	private string PKIKNNOAKMI(byte[] NIODCJLINJN)
	{
		MD5 md5 = MD5.Create();
		byte[] hash = md5.ComputeHash(NIODCJLINJN);
		md5.Clear();
		StringBuilder str = new StringBuilder();
		for (int i = 0; i < hash.Length; i++)
		{
			str.Append(hash[i].ToString("x2"));
		}
		return str.ToString();
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B9B08 Offset: 0x6B9B08 VA: 0x6B9B08
	// // RVA: 0xC19528 Offset: 0xC19528 VA: 0xC19528
	private IEnumerator EEOJBAHJAIN_Coroutine_Nil()
	{
		// private CriFsLoadFileRequest PNLGHFCFPPK_Request; // 0x14
		// 0xC1C344
		UnityEngine.Debug.Log("buildOption="+AppInfo.buildOption);
		NMMCABJNNLH = 0;
		CriFsLoadFileRequest PNLGHFCFPPK_Request = CriFsUtility.LoadFile(Path.Combine(CriWare.Common.streamingAssetsPath, "img/nil.png"), 0x100000);
		while(!PNLGHFCFPPK_Request.isDone)
		{
				yield return null;
		}
		if(PNLGHFCFPPK_Request.error == null)
		{
			if(NHNHGIJCGFG())
			{
				byte[] b = PNLGHFCFPPK_Request.bytes;
				string str = PKIKNNOAKMI(b);
				int a = GNECFAGJEOI(str);
				NMMCABJNNLH = a;
				TodoLogger.Log(TodoLogger.Base, "EEOJBAHJAIN_Coroutine_Nil key found : " + a);
				if (a > -1)
				{
					if (a < CNAINDDMPDL.Length)
						yield break;
				}
				NMMCABJNNLH = 0;
			}
		}
	}
	// // RVA: 0xC195D4 Offset: 0xC195D4 VA: 0xC195D4
	private bool NHNHGIJCGFG()
	{
		int version;
		Int32.TryParse(AppInfo.buildVersion, out version);
		version *= 0xd;
		string key = "z3b7Ps5DJk9D" + version + "MSxK7XD3khiD";
		MD5 md5 = MD5.Create();
		byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(key));
		TodoLogger.Log(TodoLogger.Filesystem, "hash : " + BitConverter.ToString(hash));
		md5.Clear();
		StringBuilder str = new StringBuilder();
		str.Append("h");
		for (int i = 0; i < hash.Length; i++)
		{
			str.Append(hash[i].ToString("x2"));
		}
		TodoLogger.Log(TodoLogger.Filesystem, "NHNHGIJCGFG : " + AppInfo.buildOption + " " + str.ToString() + " " + key);
		return AppInfo.buildOption == str.ToString();
	}

	// // RVA: 0xC19898 Offset: 0xC19898 VA: 0xC19898
	// private bool HLHBMMKKPKB() { }

	// // RVA: 0xC19C0C Offset: 0xC19C0C VA: 0xC19C0C
	private int GNECFAGJEOI(string _IOIMHJAOKOO_Hash)
	{
		StringBuilder str = new StringBuilder();
		for (int i = 0; i < HPEBFGPLMBP.GetLength(0); i++)
		{
			str.Clear();
			for (int j = 0; j < HPEBFGPLMBP.GetLength(1); j++)
			{
				str.Append((HPEBFGPLMBP[i, j] ^ 0x5f).ToString("x2"));
			}
			if (str.ToString() == _IOIMHJAOKOO_Hash)
				return i + 1;
		}
		return 0;
	}

	// // RVA: 0xC19EEC Offset: 0xC19EEC VA: 0xC19EEC
	public void CADNBFCHAKM_GetToken(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		NADBPLMLIJA_GetToken req = IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NADBPLMLIJA_GetToken());
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0xC1A714
			_BHFHGFKBOHH_OnSuccess();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0xC1A740
			_AOCANKOMKFG_OnError();
		};
	}
}
