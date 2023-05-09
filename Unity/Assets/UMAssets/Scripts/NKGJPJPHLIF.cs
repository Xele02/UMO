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
	public int CAFHLEFMMGD()
	{
		return MDAMJIGBOLD_PlayerId;
	}

	// // RVA: 0xC16610 Offset: 0xC16610 VA: 0xC16610
	// public bool KKMCBNKDDPN(int MLPEHNBNOGD) { }

	// // RVA: 0xC16624 Offset: 0xC16624 VA: 0xC16624
	// public void IJMGMJHLGDG(int NJPGHGIICME) { }

	// RVA: 0xC16A5C Offset: 0xC16A5C VA: 0xC16A5C
	public void IJBGPAENLJA(MonoBehaviour DANMJLOBLIE)
	{
		GHNFIINGIGM.HKICMNAACDA();
		CEDHHAGBIBA.LBLGDJJGFIO = (uint)Utility.GetCurrentUnixTime();
		//DANMJLOBLIE.gameObject
		HHCJCDFCLOB = this;
		LPDNKHAIOLH.KHEKNNFCAOI_Init((int)((CEDHHAGBIBA.LBLGDJJGFIO * 35) & 0x7fffffff));

		BHEDLCLHGPB = new CNGFKOJANNP();
		BHEDLCLHGPB.IJBGPAENLJA_Init(DANMJLOBLIE);

		MNNCBFONAOL.KHEKNNFCAOI_Init();//101
		JEHIAIPJNJF_FileDownloader.BNGLMLOLPEL_Initialize();

		OLKNOPIDFJG = new JDDGPJDKHNE(); //108
		OLKNOPIDFJG.IJBGPAENLJA();

		EHIIDBEMILF = new DOKOHKJIDBO(); //117
		EHIIDBEMILF.KIDFJDNOGDG();

		HHAKOEMAOID = new EJHPIMANJFP();
		HHAKOEMAOID.IJBGPAENLJA();

		IBLPICFDGOF_ServerRequester = new PJKLMCGEJMK(); // 133
		IBLPICFDGOF_ServerRequester.IJBGPAENLJA_Start(DANMJLOBLIE);

		HKDHHMHHJOJ = new OPKDHAODJOA();
		HKDHHMHHJOJ.IJBGPAENLJA(DANMJLOBLIE);

		NLGFEPAJBOJ = new CIOECGOMILE();
		NLGFEPAJBOJ.IJBGPAENLJA(DANMJLOBLIE);

		EJDOEBLBGIO = new IMMAOANGPNK(); //155
		EJDOEBLBGIO.IJBGPAENLJA(DANMJLOBLIE);

		FDOODGBBKEE = new JGEOBNENMAH();
		FDOODGBBKEE.IJBGPAENLJA(DANMJLOBLIE);

		BOLHOKKOBFG = new KDHGBOOECKC();
		BOLHOKKOBFG.IJBGPAENLJA(DANMJLOBLIE);

		KOECOMOAFJM = new GNGMCIAIKMA();
		KOECOMOAFJM.IJBGPAENLJA(DANMJLOBLIE);

		EJIGAABBKCM = new JHHBAFKMBDL();
		EJIGAABBKCM.IJBGPAENLJA_Start(DANMJLOBLIE);

		AFKDJPJOPBH = new KEHOJEJMGLJ();
		AFKDJPJOPBH.IJBGPAENLJA(DANMJLOBLIE);

		AOHJJKHIAMF = new BBGDKLLEPIB(); //204
		AOHJJKHIAMF.IJBGPAENLJA(DANMJLOBLIE);

		BJAONAJFHFA = new KDLPEDBKMID();
		BJAONAJFHFA.IJBGPAENLJA_OnAwake(DANMJLOBLIE);

		AJPPBBAOPIP = new OEGIPPCADNA();
		AJPPBBAOPIP.IJBGPAENLJA(DANMJLOBLIE);

		GOKEBIILKIO = new LAMCONGFONF();
		GOKEBIILKIO.IJBGPAENLJA(DANMJLOBLIE);

		GALAFFGKBCD = new NMFABEKNBKJ();
		GALAFFGKBCD.IJBGPAENLJA(DANMJLOBLIE);

		HFPNGIDPOBF = new EOHDAOAJOHH();
		HFPNGIDPOBF.IJBGPAENLJA(DANMJLOBLIE);

		FPNBCFJHENI = new HPBDNNACBAK();

		KGHFJJKMCIH = new MBCPNPNMFHB();
		KGHFJJKMCIH.IJBGPAENLJA();

		INKOCAJMNLD = new KKLGENJKEBN();
		INKOCAJMNLD.IJBGPAENLJA(DANMJLOBLIE);

		NNJPOLGAIIE = new CNNIKANJMNG();
		NNJPOLGAIIE.IJBGPAENLJA(DANMJLOBLIE);

		DDNPGALFPBF = new JEPBIIJDGEF_EventInfo();
		DDNPGALFPBF.IJBGPAENLJA(DANMJLOBLIE);

		BBHAHMCFCLH = new BIFNGFAIEIL();
		BBHAHMCFCLH.IJBGPAENLJA(DANMJLOBLIE);

		GNLBDCOIDMJ = new HDEEBKIFLNI();
		GNLBDCOIDMJ.IJBGPAENLJA(DANMJLOBLIE);

		KGJGLOEIOHJ = new EJGJAFBLHHM();
		KGJGLOEIOHJ.IJBGPAENLJA(DANMJLOBLIE);

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
		HECNGABHNDJ[0] = new LAPFLEEAACL(/*2*/HHJHIFJIKAC_BonusVc.IJFKAIHFJLF.JEPMLKCJCPK);
		HECNGABHNDJ[1] = new LAPFLEEAACL(/*6*/HHJHIFJIKAC_BonusVc.IJFKAIHFJLF.ONIIJLCOCAC);
		HECNGABHNDJ[2] = new LAPFLEEAACL(/*7*/HHJHIFJIKAC_BonusVc.IJFKAIHFJLF.MCPDGFMLJNG);
		HECNGABHNDJ[3] = new LAPFLEEAACL(/*8*/HHJHIFJIKAC_BonusVc.IJFKAIHFJLF.PPPGDKCDACF);
		HECNGABHNDJ[4] = new LAPFLEEAACL(/*5*/HHJHIFJIKAC_BonusVc.IJFKAIHFJLF.MDIJEKDNLFC);

		JAECPEDLEMN = new NHPDPKHMFEP();
		JAECPEDLEMN.IJBGPAENLJA();

		DCPCLHOJEHE = false;
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
	// public void FGDBKOCCKOE(bool CKLGHFBPFPJ) { }

	// // RVA: 0xC17E9C Offset: 0xC17E9C VA: 0xC17E9C
	public void ODLGKIJCHGH(IMCBBOAFION KLMFJJCNBIP)
	{
		N.a.StartCoroutineWatched(MAMKIDBAINA_Coroutine_InitializeSystem(KLMFJJCNBIP));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B9838 Offset: 0x6B9838 VA: 0x6B9838
	// // RVA: 0xC17EEC Offset: 0xC17EEC VA: 0xC17EEC
	private IEnumerator MAMKIDBAINA_Coroutine_InitializeSystem(IMCBBOAFION KLMFJJCNBIP)
	{
		//UnityEngine.Debug.Log("Enter MAMKIDBAINA_Coroutine_InitializeSystem");
		// public NKGJPJPHLIF KIGBLACMODG; // 0x10
		// private NKGJPJPHLIF.<>c__DisplayClass73_0 OPLBFCEPDCH; // 0x14
		// public IMCBBOAFION KLMFJJCNBIP; // 0x18
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
				return LNOLGFLNAAI == PKLPKMLGFGK.OPFGFINHFCE;
			});
			if (a != null)
			{
				N.a.A().transform.parent = N.a.transform;
				s = N.a.A().GetComponent<SakashoInitializer>();
				s.serverMode = a.CNDDKMJAIBG;
				s.sakashoGameId = "" + a.DMJGDDEACMD;
				s.sakashoCommonKey = a.LJNAKDMILMC;
				s.paymentType = 0;
				MLKOPOKGHHH_SakashoGameId = s.sakashoGameId;
				IMDEGHBHAPC = a.CNDDKMJAIBG;
				yield return new WaitForSeconds(0.1f);
			}
			else
			{
				UnityEngine.Debug.LogError("Exit  Error MAMKIDBAINA_Coroutine_InitializeSystem");
				yield break;
			}
		}
		CGMMHFHHLID = true;
		if (KLMFJJCNBIP != null)
			KLMFJJCNBIP();
		//UnityEngine.Debug.Log("Exit MAMKIDBAINA_Coroutine_InitializeSystem");
	}

	// // RVA: 0xC17FB4 Offset: 0xC17FB4 VA: 0xC17FB4
	public void HGJKAEOLMJN_InitializePlayerToken(IMCBBOAFION KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK JGKOLBLPMPG_OnFail, bool MKFJAGGLEFL = true, bool FBBNPFFEJBN = false)
	{
		N.a.StartCoroutineWatched(PFKIHFCAPNC_Coroutine_InitializePlayerToken(KLMFJJCNBIP_OnSuccess, JGKOLBLPMPG_OnFail, MKFJAGGLEFL, FBBNPFFEJBN));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B98B0 Offset: 0x6B98B0 VA: 0x6B98B0
	// // RVA: 0xC18024 Offset: 0xC18024 VA: 0xC18024
	private IEnumerator PFKIHFCAPNC_Coroutine_InitializePlayerToken(IMCBBOAFION KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK JGKOLBLPMPG_OnFail, bool MKFJAGGLEFL, bool FBBNPFFEJBN)
	{
    	//UnityEngine.Debug.Log("Enter PFKIHFCAPNC_Coroutine_InitializePlayerToken");
		// public NKGJPJPHLIF KIGBLACMODG; // 0x10
		// private HHEIANIHCNH FFEEIONIBFF; // 0x24
		// private PKNOGNLPHAE CNEMMHHJKNG; // 0x28
		//0xC1B698

		if(MDAMJIGBOLD_PlayerId != 0 && !FBBNPFFEJBN)
		{
			//goto LAB_00c1bbc4;
			if(KLMFJJCNBIP_OnSuccess != null)
				KLMFJJCNBIP_OnSuccess();
    		//UnityEngine.Debug.Log("Exit PFKIHFCAPNC_Coroutine_InitializePlayerToken");
			yield break;
		}
		HHEIANIHCNH_RequestPlayerStatus FFEEIONIBFF_Request = IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest<HHEIANIHCNH_RequestPlayerStatus>(new HHEIANIHCNH_RequestPlayerStatus());
		FFEEIONIBFF_Request.EOPCHGLLONF = MKFJAGGLEFL;
		yield return FFEEIONIBFF_Request.GDPDELLNOBO_WaitDone(N.a);

		//1

		if(FFEEIONIBFF_Request.NPNNPNAIONN_IsError)
		{
			//goto LAB_00c1b8f8;
			if(JGKOLBLPMPG_OnFail != null)
				JGKOLBLPMPG_OnFail();
			yield break;
		}
		//L177
		int playerId = 0;
		int accountStatus = 0;
		if(FFEEIONIBFF_Request.NFEAMMJIMPG_Result.OGADPAILFBC_IsCreated()) // iscreated
		{
			playerId = FFEEIONIBFF_Request.NFEAMMJIMPG_Result.EHGBICNIBKE_PlayerId;
			accountStatus = FFEEIONIBFF_Request.NFEAMMJIMPG_Result.JFMEKPDHJPP_PlayerAccountStatus;
			FFEEIONIBFF_Request = null;
			//goto LAB_00c1b9d8;
		}
		else
		{
			//L214
			FFEEIONIBFF_Request = null;
			PKNOGNLPHAE_CreatePlayer CNEMMHHJKNG = IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new PKNOGNLPHAE_CreatePlayer());
			yield return CNEMMHHJKNG.GDPDELLNOBO_WaitDone(N.a);
			//2
			if (!CNEMMHHJKNG.NPNNPNAIONN_IsError)
			{
				if(!CNEMMHHJKNG.PDAPLCPOCMA)
				{
					playerId = CNEMMHHJKNG.NFEAMMJIMPG.EHGBICNIBKE_PlayerId;
					LFGOHEKCDFN(playerId);
					accountStatus = CNEMMHHJKNG.NFEAMMJIMPG.JFMEKPDHJPP_PlayerAccountStatus;
					CNEMMHHJKNG = null;
				}
				else
				{
					if (JGKOLBLPMPG_OnFail != null)
						JGKOLBLPMPG_OnFail();
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
    	//UnityEngine.Debug.Log("Exit PFKIHFCAPNC_Coroutine_InitializePlayerToken");
	}

	// // RVA: 0xC1662C Offset: 0xC1662C VA: 0xC1662C
	public void LFGOHEKCDFN(int MLPEHNBNOGD)
	{
		if (MLPEHNBNOGD == 0)
			return;
		GameManager.Instance.localSave.LHPDDGIJKNB_Reset();
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
		PlayerPrefs.SetInt("cpid", MLPEHNBNOGD);
		PlayerPrefs.Save();
		PKECIDPBEFL.GDELLNOBNDM_DeleteCache();
	}

	// // RVA: 0xC1813C Offset: 0xC1813C VA: 0xC1813C
	// public void CCMPLEKABLF(bool ILMANDAFLDL, IMCBBOAFION KLMFJJCNBIP, DJBHIFLHJLK JGKOLBLPMPG) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B9928 Offset: 0x6B9928 VA: 0x6B9928
	// // RVA: 0xC18168 Offset: 0xC18168 VA: 0xC18168
	// private IEnumerator APIJCBPFJMM(bool ILMANDAFLDL, IMCBBOAFION KLMFJJCNBIP, DJBHIFLHJLK JGKOLBLPMPG) { }

	// // RVA: 0xC18260 Offset: 0xC18260 VA: 0xC18260
	public void EFPOACOOAFB(bool FBBNPFFEJBN)
	{
		if(NLGFEPAJBOJ.LNAHEIEIBOI_Initialized)
		{
			NLGFEPAJBOJ.OIEBCNPOMIB_UpdateDayChange(FBBNPFFEJBN);
			NLGFEPAJBOJ.KPHFDEOFKLM_UpdateEnergyDayChange();
			NLGFEPAJBOJ.LBLNLMGHLAG_UpdateShop();
			NLGFEPAJBOJ.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.LPFFDGNDLKG_UpdateMedals(true, 2160);
			NLGFEPAJBOJ.FAFAKNJLLIC_ResetIntimacyPresentLeft();
			NLGFEPAJBOJ.CDIADEIOIHP_ResetIntimacyTouchCount();
			KDHGBOOECKC.HHCJCDFCLOB.PCPECPFJMGC();
			FPNBCFJHENI.CIEDHFEKKII();
			if(NHPDPKHMFEP.HHCJCDFCLOB != null)
			{
				NHPDPKHMFEP.HHCJCDFCLOB.DLGMLAJMLOP = true;
			}
		}
		long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.LOMEEJGIAHO.JOJFKIIHMOJ(t);
		MenuScene.IsAlreadyHome = false;
		FPNBCFJHENI.ECFNAOCFKKN = 0;
		FPNBCFJHENI.MILIGHHGOML.Clear();
		HHAKOEMAOID.ECFNAOCFKKN_LastRequestProductTime = 0;
		DateTime d = Utility.GetLocalDateTime(t);
		DHMLDAGGKCD = d.Month * 100 + d.Year * 100000 + d.Day;
		if(NLGFEPAJBOJ.LNAHEIEIBOI_Initialized)
		{
			NLGFEPAJBOJ.OFGCPFFPGHE(FBBNPFFEJBN);
			NLGFEPAJBOJ.NPAPJMLJBKM(FBBNPFFEJBN);
		}
		DCOKFLPPHEB();
	}

	// // RVA: 0xC187C4 Offset: 0xC187C4 VA: 0xC187C4
	public void NIJDPPHGHFD_ResetDates(bool FBBNPFFEJBN)
	{
		MenuScene.IsAlreadyHome = false;
		HHAKOEMAOID.ECFNAOCFKKN_LastRequestProductTime = 0;
		FPNBCFJHENI.ECFNAOCFKKN = 0;
		FPNBCFJHENI.MILIGHHGOML.Clear();
		EJDOEBLBGIO.GCELJIDIGDG = null;
		DCOKFLPPHEB();
	}

	// // RVA: 0xC18778 Offset: 0xC18778 VA: 0xC18778
	public void DCOKFLPPHEB()
	{
		FPNBCFJHENI.ECFNAOCFKKN = 0;
		HHAKOEMAOID.ECFNAOCFKKN_LastRequestProductTime = 0;
	}

	// // RVA: 0xC188EC Offset: 0xC188EC VA: 0xC188EC
	public void LBEHLMLKPDM(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		long time = IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		HFPNGIDPOBF.KCKLPAEILNH();
		HFPNGIDPOBF.NNGHCGKIIHM(false);
		if(IBLPICFDGOF_ServerRequester.IEFOIIAEBBJ && !IBLPICFDGOF_ServerRequester.NFECEPJEMHG)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.IJHBIMNKOMC_TutorialEnd == 2)
			{
				IBLPICFDGOF_ServerRequester.NFECEPJEMHG = true;
				int disable_recmonded_notice = EJDOEBLBGIO.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("disable_recmonded_notice", 0);
				if(disable_recmonded_notice == 0)
				{
					N.a.StartCoroutineWatched(BDJBKBMJHOP_Coroutine_UpdateNotice(BHFHGFKBOHH, MOBEEPPKFLG));
					return;
				}
			}
		}
		if(299 >= (time - OLDKENOLHLL) && !NHPDPKHMFEP.HHCJCDFCLOB.DLGMLAJMLOP)
		{
			BHFHGFKBOHH();
		}
		N.a.StartCoroutineWatched(NGDEGDHBIHF_Coroutine_PrepareHome(BHFHGFKBOHH, MOBEEPPKFLG));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B99A0 Offset: 0x6B99A0 VA: 0x6B99A0
	// // RVA: 0xC18C58 Offset: 0xC18C58 VA: 0xC18C58
	private IEnumerator BDJBKBMJHOP_Coroutine_UpdateNotice(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		//0xC1D2C4
		bool BEKAMBBOLBO = false;
		while(true)
		{
			BEKAMBBOLBO = false;
			bool MAKBLJGIBKJ = false;
			JFDNPFFOACP BAHANNNJCGC = () =>
			{
				//0xC1A82C
				BEKAMBBOLBO = true;
			};
			EJIGAABBKCM.GLJAPKKLIJJ_ShowUpdatePopup(() =>
			{
				//0xC1A840
				BEKAMBBOLBO = true;
				MAKBLJGIBKJ = true;
			}, BAHANNNJCGC);
			while (!BEKAMBBOLBO)
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
		N.a.StartCoroutineWatched(NGDEGDHBIHF_Coroutine_PrepareHome(BHFHGFKBOHH, AOCANKOMKFG));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B9A18 Offset: 0x6B9A18 VA: 0x6B9A18
	// // RVA: 0xC18D18 Offset: 0xC18D18 VA: 0xC18D18
	private IEnumerator NGDEGDHBIHF_Coroutine_PrepareHome(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		PIGBKEIAMPE_FriendManager FEAAEDHHBNB;
		PJKLMCGEJMK JFAIABBIPEO;
		DOLDMCAMEOD_RequestRemainingForCurrencyIds BPOJOBICBAC;

		//0xC1C714
		CIOECGOMILE.HHCJCDFCLOB.NAOGKAIBBEH();
		FEAAEDHHBNB = CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager;
		bool BEKAMBBOLBO = false;
		bool CNAIDEAFAAM = false;
		FEAAEDHHBNB.PFJBNPIBFMO_GetReceivedRequests(() =>
		{
			//0xC1A878
			BEKAMBBOLBO = true;
		}, (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0xC1A884
			BEKAMBBOLBO = true;
			CNAIDEAFAAM = true;
		}, false);
		while (!BEKAMBBOLBO)
			yield return null;
		if(!CNAIDEAFAAM)
		{
			BEKAMBBOLBO = false;
			CNAIDEAFAAM = false;
			FEAAEDHHBNB.BMJANOADDCC_GetFriends(() =>
			{
				//0xC1A890
				BEKAMBBOLBO = true;
			}, (CACGCMBKHDI_Request JIPCHHHLOMM) =>
			{
				//0xC1A89C
				BEKAMBBOLBO = true;
				CNAIDEAFAAM = true;
			}, false);
			while(!BEKAMBBOLBO)
			{
				yield return null;
			}
			if(!CNAIDEAFAAM)
			{
				BEKAMBBOLBO = false;
				CNAIDEAFAAM = false;
				NLGFEPAJBOJ.KPFKKDDOHCN.BDPMNDGIEGI_RequestInventories(() =>
				{
					//0xC1A8A8
					BEKAMBBOLBO = true;
				}, (CACGCMBKHDI_Request ADKIDBJCAJA) =>
				{
					//0xC1A8B4
					BEKAMBBOLBO = true;
					CNAIDEAFAAM = true;
				}, false);
				while (!NLGFEPAJBOJ.KPFKKDDOHCN.PLOOEECNHFB)
					yield return null;
				if(!CNAIDEAFAAM)
				{
					JFAIABBIPEO = IBLPICFDGOF_ServerRequester;
					BPOJOBICBAC = JFAIABBIPEO.IFFNCAFNEAG_AddRequest(new DOLDMCAMEOD_RequestRemainingForCurrencyIds());
					BPOJOBICBAC.CGCFENMHJIM_Ids = new List<int>(1);
					BPOJOBICBAC.CGCFENMHJIM_Ids.Add(1001);
					yield return BPOJOBICBAC.GDPDELLNOBO_WaitDone(N.a);
					if(BPOJOBICBAC.NPNNPNAIONN_IsError)
					{
						if (AOCANKOMKFG != null)
							AOCANKOMKFG();
						yield break;
					}
					CIOECGOMILE.HHCJCDFCLOB.DJICHKCLMCD_UpdateCurrencies(BPOJOBICBAC.NFEAMMJIMPG.BBEPLKNMICJ_CurrenciesList);
					OLDKENOLHLL = JFAIABBIPEO.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
					BEKAMBBOLBO = false;
					CNAIDEAFAAM = false;
					LLMEJNALPJD(false, () =>
					{
						//0xC1A8C0
						BEKAMBBOLBO = true;
					}, () =>
					{
						//0xC1A8CC
						BEKAMBBOLBO = true;
						CNAIDEAFAAM = true;
					}, true);
					while (!BEKAMBBOLBO)
						yield return null;
					if(!CNAIDEAFAAM)
					{
						BEKAMBBOLBO = false;
						CNAIDEAFAAM = false;
						NHPDPKHMFEP.HHCJCDFCLOB.NDAIOIOMPGG(() =>
						{
							//0xC1A8D8
							BEKAMBBOLBO = true;
						}, () =>
						{
							//0xC1A8E4
							BEKAMBBOLBO = true;
							CNAIDEAFAAM = true;
						});
						while (!BEKAMBBOLBO)
							yield return null;
						if(!CNAIDEAFAAM)
						{
							BHFHGFKBOHH();
							yield break;
						}
					}
				}
			}
		}
		AOCANKOMKFG();
	}

	// // RVA: 0xC18E18 Offset: 0xC18E18 VA: 0xC18E18
	public void LLMEJNALPJD(bool FBBNPFFEJBN, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG, bool LFIEDDHNLBE)
	{
		// // RVA: 0xC1A8F0 Offset: 0xC1A8F0 VA: 0xC1A8F0
		// internal void OOLONOGEELA(CACGCMBKHDI JIPCHHHLOMM) { }
		// // RVA:  Offset: 0xC1AA34 VA: 0xC1AA34
		// internal void HPCLPPCILDO(CACGCMBKHDI JIPCHHHLOMM) { }

		if((IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime() - GOEPLCHCCBC) <= 1799 && !FBBNPFFEJBN)
		{
			if(BHFHGFKBOHH != null)
			{
				BHFHGFKBOHH();
			}
			return;
		}
		IHKOJFIFPKB_RequestInquiryResponsesNumber COJNCNGHIJC = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest<IHKOJFIFPKB_RequestInquiryResponsesNumber>(new IHKOJFIFPKB_RequestInquiryResponsesNumber());
		if(!LFIEDDHNLBE)
		{
			COJNCNGHIJC.AILPHBMCCGP = true;
			COJNCNGHIJC.NBFDEFGFLPJ = (SakashoErrorId FMEMECBIDIB) => {
				//0xC1A70C
				return true;
			};
		}
		COJNCNGHIJC.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) => {
			//0xC1A8F0
			int numReplies = 0;
			if(COJNCNGHIJC.NFEAMMJIMPG != null)
			{
				numReplies = COJNCNGHIJC.NFEAMMJIMPG.PNAAOBECMPA_NumReplies;
			}
			AFJEOKGBCNA_NumReplies = numReplies;
			GOEPLCHCCBC = IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			if(BHFHGFKBOHH != null)
			{
				BHFHGFKBOHH();
			}
		};
		COJNCNGHIJC.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) => {
			//0xC1AA34
			AFJEOKGBCNA_NumReplies = 0;
			if(MOBEEPPKFLG != null)
			{
				MOBEEPPKFLG();
			}
		};
	}

	// // RVA: 0xC191CC Offset: 0xC191CC VA: 0xC191CC
	// public void NBLAOIPJFGL(string HJLDBEJOMIO) { }

	// // RVA: 0xC1929C Offset: 0xC1929C VA: 0xC1929C
	// public void NBLAOIPJFGL(string HJLDBEJOMIO, IMCBBOAFION HIDFAIBOHCC) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B9A90 Offset: 0x6B9A90 VA: 0x6B9A90
	// // RVA: 0xC192EC Offset: 0xC192EC VA: 0xC192EC
	// private IEnumerator LOBOGDLABMH(string HJLDBEJOMIO, IMCBBOAFION HIDFAIBOHCC) { }

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
						if (EJDOEBLBGIO.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("server_time_auto_update", 0) == 0)
							return;
						if ((LJBHLFGDBHA - Utility.GetCurrentUnixTime()) <= 30)
						{
							PECPLBANLBN = false;
							return;
						}
						NCECLECJIIG = 0;
						KEJNOIJMBLP = SakashoSupportSite.GetToken(
							(string IDLHJIOMJBK) =>
							{ // success
								//0xC1A424
								OBOKMHHMOIL_ServerInfo o = new OBOKMHHMOIL_ServerInfo();
								o.KHEKNNFCAOI_Init(IDLHJIOMJBK);
								NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.EAJMLOKKOOK_SetServerTime(o.LCAINKFINEI_ServerCurrentDateTime);
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
    	//UnityEngine.Debug.Log("Enter EEOJBAHJAIN_Coroutine_Nil");
		// private CriFsLoadFileRequest PNLGHFCFPPK; // 0x14
		// 0xC1C344
		UnityEngine.Debug.Log("buildOption="+AppInfo.buildOption);
		NMMCABJNNLH = 0;
		CriFsLoadFileRequest PNLGHFCFPPK = CriFsUtility.LoadFile(Path.Combine(CriWare.Common.streamingAssetsPath, "img/nil.png"), 0x100000);
		while(!PNLGHFCFPPK.isDone)
		{
				yield return null;
		}
		if(PNLGHFCFPPK.error == null)
		{
			if(NHNHGIJCGFG())
			{
				byte[] b = PNLGHFCFPPK.bytes;
				string str = PKIKNNOAKMI(b);
				int a = GNECFAGJEOI(str);
				NMMCABJNNLH = a;
				UnityEngine.Debug.LogError("EEOJBAHJAIN_Coroutine_Nil key found : "+a);
				if (a > -1)
				{
					if (a < CNAINDDMPDL.Length)
						yield break;
				}
				NMMCABJNNLH = 0;
			}
		}
    	//UnityEngine.Debug.Log("Exit EEOJBAHJAIN_Coroutine_Nil");
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
		UnityEngine.Debug.Log("hash : " + BitConverter.ToString(hash));
		md5.Clear();
		StringBuilder str = new StringBuilder();
		str.Append("h");
		for (int i = 0; i < hash.Length; i++)
		{
			str.Append(hash[i].ToString("x2"));
		}
		UnityEngine.Debug.Log("NHNHGIJCGFG : " + AppInfo.buildOption + " " + str.ToString() + " " + key);
		return AppInfo.buildOption == str.ToString();
	}

	// // RVA: 0xC19898 Offset: 0xC19898 VA: 0xC19898
	// private bool HLHBMMKKPKB() { }

	// // RVA: 0xC19C0C Offset: 0xC19C0C VA: 0xC19C0C
	private int GNECFAGJEOI(string IOIMHJAOKOO)
	{
		StringBuilder str = new StringBuilder();
		for (int i = 0; i < HPEBFGPLMBP.GetLength(0); i++)
		{
			str.Clear();
			for (int j = 0; j < HPEBFGPLMBP.GetLength(1); j++)
			{
				str.Append((HPEBFGPLMBP[i, j] ^ 0x5f).ToString("x2"));
			}
			if (str.ToString() == IOIMHJAOKOO)
				return i + 1;
		}
		return 0;
	}

	// // RVA: 0xC19EEC Offset: 0xC19EEC VA: 0xC19EEC
	// public void CADNBFCHAKM(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }
}
