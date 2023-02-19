using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using XeSys;
using XeApp.Game.Menu;
using XeApp.Game.RhythmGame;
using XeApp.Game;
using System;

public class GAMEENDEXCEPTION : Exception
{
	// RVA: 0x140098C Offset: 0x140098C VA: 0x140098C
	public GAMEENDEXCEPTION() : base() { }

	// RVA: 0x1400A10 Offset: 0x1400A10 VA: 0x1400A10
	public GAMEENDEXCEPTION(string message) : base(message) { }

	// RVA: 0x1400A9C Offset: 0x1400A9C VA: 0x1400A9C
	public GAMEENDEXCEPTION(string message, Exception inner) : base(message, inner) { }
}


public class JGEOBNENMAH
{
	public delegate void NNEICCOGCLL(NHCDBBBMFFG CMCKNKKCNDK);

	public class NEDILFPPCJF
	{
		public int HBKBKHACHHI; // 0x8
		public int GMECIBOJCFF; // 0xC
		public int MIMLMJGGNJH; // 0x10
		public int IPEKDLNEOFI; // 0x14
		public int BFHPKJEKJNN; // 0x18
		public int DDBEJNGJIPF; // 0x1C
		public int CBOCBLLOMHE; // 0x20
		public int MINAGJOIGOP; // 0x24
		public int ICBJAAPJNEI; // 0x28
		public int AGNGKDFONAM; // 0x2C
		public int KAEHAANLPKF; // 0x30
		public int NIBMFONLOME; // 0x34
		public int PLMGHHHFAGL; // 0x38
		public int EKKCKGDGNPM; // 0x3C
		public int GCAOLGILAAI; // 0x40
		public int IBFPGFJDLEI; // 0x44
		public int APPEPDLOPAA; // 0x48
		public int LHBINHCMEDA; // 0x4C
		public int BPNAAEDJGPC; // 0x50
		public int NDKKNEIDCFF_TotalScoreExpected; // 0x54
		public int IFHMFONMGPE; // 0x58
		public int AKNKIOKELEP; // 0x5C
		public int LPKBGBLIDCE; // 0x60
		public int LCFAJIELMMF; // 0x64
		public int OIKJEAEJOME; // 0x68
		public int JJDKFJACLMD; // 0x6C
		public const int GIAEAOIMOME = 3;
		public int[] EEKANKOEJIL = new int[3]; // 0x70
		public int[] HNINPGMPGMJ = new int[3]; // 0x74
		public int[] DNGJJFFKOBG = new int[3]; // 0x78
		public int[] IPPIIBLLDDG = new int[3]; // 0x7C
		public int[] HHNPILDOHKP = new int[3]; // 0x80
		public int[] MHPLFJHDIEP = new int[3]; // 0x84
		public int[] NBCMAGJGHLC = new int[3]; // 0x88
		public int[] LBGNJCODPEJ = new int[3]; // 0x8C
		public int[] EGEKLGIEKLL = new int[3]; // 0x90
	}

	public class PDNNOFFFDAG
	{
		public int GHBPLHBNMBK_FreeMusicId; // 0x8
		public int KLCIIHKFPPO_StoryMusicId; // 0xC
		public int AKNELONELJK_Difficulty; // 0x10
		public int MNNHHJBBICA_GameEventType; // 0x14
		public int MFJKNCACBDG_OpenEventType; // 0x18
		public int OEILJHENAHN_PlayEventType; // 0x1C
		public int JPJMALBLKDI_Tutorial; // 0x20
		public bool LFGNLKKFOCD_IsLine6; // 0x24
		public bool OBOPMHBPCFE_MvMode; // 0x25
		public long FMBLKADNICN_MvTimeLimit; // 0x28
		public int IEMFPDGIAHG; // 0x30
		public NEDILFPPCJF ENMGODCHGAC_Log = new NEDILFPPCJF(); // 0x34
		public bool PMCGHPOGLGM_IsSkip; // 0x38
		public int KAIPAEILJHO_TicketCount; // 0x3C
		public bool CEPCBJHNMJA_IsNotUpdateProfile; // 0x40
	}

	public class HAJIFNABIFF : PDNNOFFFDAG
	{
		public const int ICHDNOBHIKG = 268435456;
		public const int HFGMKEIHLJL = 536870912;
		public const int PNBIOIMJDCG = 1073741824;
		public long NFFDIGEJHGL_ServerTime; // 0x48
		public int KNIFCANOHOC_Score; // 0x50
		public int EACPIDGGPPO_ExcellentScore; // 0x54
		public int NLKEBAOBJCM_MaxCombo; // 0x58
		public int MJBODMOLOBC_TeamLuck; // 0x5C
		public int LCOHGOIDMDF_ComboRank; // 0x60
		public List<int> DGMPBPMDBEC_DropItemList; // 0x64
		public List<int> HNHCIGMKPDC_DivaIds; // 0x68
		public List<int> OJFNDOIFOOE_NoteResultCount; // 0x6C
		public int FEGLNPOFDJC_ExcellentCount; // 0x70
		public int OOPEJLMNIAH_EventItemCount; // 0x74
		public int FDNEPIEMMFN_AssignedCenterLiveSkillNote; // 0x78
		public int HJIECNDECNO_TouchedCenterLiveSkill; // 0x7C
		public List<int> JBCKLEMCEBD_LiveSkillActivateCount; // 0x80
		public int JEKDIEFPEON_RareItemRandomSeed; // 0x84
		public bool OOOGNIPJMDE_HadDivaMode; // 0x88
		public bool HGEKDNNJAAC_HadAwakenDivaMode; // 0x89
		public bool KNCBNGCDMII_HadValkyrieMode; // 0x8A
		public int BCGBODDEFKP_NumSkillActive; // 0x8C
		public int JNNDFGPMEDA_EnergyLeft; // 0x90
		public int JKPPKAHPPKH_LifeLeft; // 0x94
		public int EHCFOHAABDA_EnemyLeft; // 0x98
		public int OJDDNGGBJOG_AverageFPS; // 0x9C
		public int BIIGPMLBOOD_MinFPS; // 0xA0
		public int DEAHHPAPDNC; // 0xA4
		public int GLGLFDAPNIF_ContinueCount; // 0xA8
		public int IHDIJODHCGD_LastSkillMillisec; // 0xAC
		public int IPEKDLNEOFI_TeamLife; // 0xB0
		public int HBKBKHACHHI_TeamSoul; // 0xB4
		public int GMECIBOJCFF_TeamVocal; // 0xB8
		public int MIMLMJGGNJH_TeamCharm; // 0xBC
		public int BFHPKJEKJNN_TeamSupport; // 0xC0
		public int DDBEJNGJIPF_Fold; // 0xC4
		public List<RhythmGamePlayLog.SkillData> CPNOKMINILL_SkillDataList; // 0xC8
		public string FJCIPNCOBNA_SerializedNoteResultInfo; // 0xCC
		public FENCAJJBLBH NMNHBJIAPGG_CheckFalsification; // 0xD0
		public bool OPEBKHLLMPH; // 0xD4

		// // RVA: 0xB16360 Offset: 0xB16360 VA: 0xB16360
		// public int HCFGMNPMIHL() { }
	}

	
	public class EDHCNKBMLGI : PDNNOFFFDAG
	{
		public JLKEOGLJNOD_TeamInfo OALJNDABDHK; // 0x44
		public EAJCBFGKKFA_FriendInfo NHPGGBCKLHC_FriendData; // 0x48

		//public FFHPBEPOMAK GNLFLDMNBGG { get; } 0xB162D0 KHAFJOIGEAK
	}


	public static bool PNLJLBEHIBN; // 0x4
	private EDHCNKBMLGI AGDEBBENNCK; // 0x8
	public EAJCBFGKKFA_FriendInfo NHPGGBCKLHC_FriendPlayerData; // 0xC
	public List<IELJJAAJAOE> DCELMKFJHPG = new List<IELJJAAJAOE>(); // 0x10
	public int PFHMFKKDMBM_FreeMusicId; // 0x14
	public int LBLOIOMNEIH_Difficulty; // 0x18
	public int IKBLCEFCGDE_LastLuck; // 0x1C
	public int GCAPLLEIAAI_LastScore; // 0x20
	public int GPMILOPNBPA_LastScoreExcellent; // 0x24
	public int PBGLMBMEKAA_LastCombo; // 0x28
	public int CODDMAKLBDO_LastComboRank; // 0x2C
	public int PENICOGGNLF; // 0x30
	public int CFNCNCBEPED; // 0x34
	public int NMDKKAAOIOI_LastBaseUnionCredit; // 0x38
	public int MJKFDDKLLFP_LastDropUnionCredit; // 0x3C
	public int PLMBDFGGBAJ; // 0x40
	public int MMMKNPEMBIL; // 0x44
	public int NGDDIIDJFNG; // 0x48
	public int LKGONGDLJBH; // 0x4C
	public int HGHMMDOEGEF; // 0x50
	public int MKEPHNGLHDL; // 0x54
	public int CBCIFACJGHI; // 0x58
	public int HBAJPMDOMPL; // 0x5C
	public int FOIPBBCHBIB; // 0x60
	public int[] NEFFKLNAAJI; // 0x64
	public OHCAABOMEOF.KGOGMKMBCPP_EventType NNABDGKFEMK_EventType; // 0x68
	public int BEOKMNIPFBA; // 0x6C
	public int ODOOKDGCKMF; // 0x70
	public AIPOFGJGPKI_CampaignDiva.KBLBMGDILAI HMMFHMHENAO; // 0x74
	public JKNGJFOBADP KDKHGAPKBNI; // 0x78
	public List<int> AMJFOGHBFKJ_DivaIds = new List<int>(5); // 0x7C
	public int FFDBCEDKMGN; // 0x80
	public int MMLPAMGJEOD; // 0x84
	public List<int> JCDPLILNKDG = new List<int> {0, 0, 0}; // 0x88
	public List<int> CMCDIOOEHMI; // 0x8C
	public bool CPABPPPPKEP; // 0x90
	public bool HKHCCJCGAKK; // 0x91
	private int HLJJPCPAOBD; // 0x94
	public int ECHONOJEPHP; // 0x98
	public long NFFDIGEJHGL_ServerTime; // 0xA0
	public string NKGFGDGFGFM = ""; // 0xA8
	public int KIHLOJGPFII; // 0xAC
	public int ACMMDAHKCIF; // 0xB0
	public int JKEPHFPCKMD; // 0xB4
	public int NMLNPELGLPN; // 0xB8
	public int NIJFFOPEEGK; // 0xBC
	public bool HIGJBGFJMMO; // 0xC0
	public bool GNAMCOJKEFE; // 0xC1
	private int IBJNOOLMBEH; // 0xC4
	private int LIIMMJHEADN; // 0xC8
	// private EIIGCIHOGPB FCBNNDPGNGH = new EIIGCIHOGPB(); // 0xCC
	private PKECIDPBEFL LFDFPBEAAFA; // 0xD0
	private List<string> DDGBLKBDAFC; // 0xD4
	private List<int> DFDEALBHBDB; // 0xD8
	// private KIJECNFNNDB LAFGAPBDKML = new KIJECNFNNDB(); // 0xDC
	public List<PKECIDPBEFL.DDBKLMKKCDL> CBGMOGIBALL = new List<PKECIDPBEFL.DDBKLMKKCDL>(); // 0xE0
	public long FOPBGEGCJCJ; // 0xE8

	public static JGEOBNENMAH HHCJCDFCLOB { get; private set; } // 0x0 LGMPACEDIJF NKACBOEHELJ OKPMHKNCNAL
	public int FPPNIKFLAFM { get { return HLJJPCPAOBD ^ 0x5e959; } set { HLJJPCPAOBD = value ^ 0x5e959; } } //  GPHMLKHBJIM 0xB02580  DHFALCHNOOF 0xB02594
	public int FCLGIPFPIPH { get { return KIHLOJGPFII ^ 0x341b34c9; } set { KIHLOJGPFII = value ^ 0x341b34c9; } } // GHFOOLBCDBM 0xB025A8 EFACKLMPIOD 0xB025BC

	// // RVA: 0xB02578 Offset: 0xB02578 VA: 0xB02578
	public long GJIICCJMDIF_GetServerTime()
	{
		return NFFDIGEJHGL_ServerTime;
	}

	// // RVA: 0xB025D0 Offset: 0xB025D0 VA: 0xB025D0
	public void IJBGPAENLJA(MonoBehaviour DANMJLOBLIE)
	{
		HHCJCDFCLOB = this;
	}

	// // RVA: 0xB02650 Offset: 0xB02650 VA: 0xB02650
	public void OLDDILMKJND(EDHCNKBMLGI KEOCOHOFPNK, IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP DBCEPOAHNBH, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK AOCANKOMKFG, DJBHIFLHJLK IGBGKGAIJPL, JGEOBNENMAH.NNEICCOGCLL INLLNIEEHAN)
	{
		N.a.StartCoroutineWatched(PFEKBBONCJJ_Coroutine_GameStart(KEOCOHOFPNK, BHFHGFKBOHH, DBCEPOAHNBH, NIMPEHIECJH, AOCANKOMKFG, IGBGKGAIJPL, INLLNIEEHAN));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B6308 Offset: 0x6B6308 VA: 0x6B6308
	// // RVA: 0xB026CC Offset: 0xB026CC VA: 0xB026CC
	private IEnumerator PFEKBBONCJJ_Coroutine_GameStart(EDHCNKBMLGI KEOCOHOFPNK, IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP DBCEPOAHNBH, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK MOBEEPPKFLG, DJBHIFLHJLK IGBGKGAIJPL, JGEOBNENMAH.NNEICCOGCLL INLLNIEEHAN)
	{
		//0xB10460
		CNGFKOJANNP.HHCJCDFCLOB.BNGIDMBNILP_ManualCheck();
		yield return null;
		AGDEBBENNCK = KEOCOHOFPNK;
		FPPNIKFLAFM = 0;
		ECHONOJEPHP = 0;
		NIJFFOPEEGK = 0;
		HMMFHMHENAO = null;
		HIGJBGFJMMO = false;
		GNAMCOJKEFE = false;
		IBJNOOLMBEH = 0;
		LIIMMJHEADN = 0;
		FCLGIPFPIPH = -1;
		ACMMDAHKCIF = 0;
		JKEPHFPCKMD = 0;
		NMLNPELGLPN = 0;
		if(KEOCOHOFPNK.JPJMALBLKDI_Tutorial > 0)
		{
			PGIGNJDPCAH.NNOBACMJHDM(PGIGNJDPCAH.FELLIEJEPIJ.ONHOCOBCINO);
			NKGFGDGFGFM = JDDGPJDKHNE.GPLMOKEIOLE();
			ILCCJNDFFOB.HHCJCDFCLOB.FKODKMNGCEH(AGDEBBENNCK, NKGFGDGFGFM, CIOECGOMILE.HHCJCDFCLOB.BPLOEAHOPFI.DCLKMNGMIKC(), 0);
			AGDEBBENNCK = null;
			BHFHGFKBOHH();
			yield break;
		}
		EONOEHOKBEB_Music NEILMPDKKLJ = DLOBJHGIBJE_GetMusicInfo(AGDEBBENNCK, false);
		if(NEILMPDKKLJ == null)
		{
			AGDEBBENNCK = null;
			NIMPEHIECJH();
			yield break;
		}
		else
		{
			KLBKPANJCPL_Score GIPDCDAEIKA = KFFCMNELJJB_GetMusicScore(NEILMPDKKLJ, AGDEBBENNCK.AKNELONELJK_Difficulty, AGDEBBENNCK.LFGNLKKFOCD_IsLine6);
			if (GIPDCDAEIKA != null)
			{
				if (NKGJPJPHLIF.HHCJCDFCLOB.PECPLBANLBN || NKGJPJPHLIF.HHCJCDFCLOB.ECPEIINJLFL)
				{
					//LAB_00b10b8c
					NADBPLMLIJA_GetToken GHPOKNKDBGO = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.IFFNCAFNEAG_AddRequest<NADBPLMLIJA_GetToken>(new NADBPLMLIJA_GetToken());
					yield return GHPOKNKDBGO.GDPDELLNOBO_WaitDone(N.a);
					//2
					if(GHPOKNKDBGO.NPNNPNAIONN)
					{
						AGDEBBENNCK = null;
						MOBEEPPKFLG();
						yield break;
					}
				}
				//LAB_00b10684
				NFFDIGEJHGL_ServerTime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				if(AGDEBBENNCK.OBOPMHBPCFE_MvMode)
				{
					if(AGDEBBENNCK.FMBLKADNICN_MvTimeLimit > 0)
					{
						if (AGDEBBENNCK.FMBLKADNICN_MvTimeLimit < NFFDIGEJHGL_ServerTime)
						{
							//LAB_00b112b8
							JHHBAFKMBDL.HHCJCDFCLOB.DNABPEOICIJ(IGBGKGAIJPL, false);
							AGDEBBENNCK = null;
							yield break;
						}
					}
				}
				FOPBGEGCJCJ = Utility.RoundDownDayUnixTime(NFFDIGEJHGL_ServerTime, 1209600);
				CIOECGOMILE LGAALOEKCAC = CIOECGOMILE.HHCJCDFCLOB;
				if(AGDEBBENNCK.MNNHHJBBICA_GameEventType != 0)
				{
					TodoLogger.Log(0, "Event");
					//L 499
				}
				if(AGDEBBENNCK.MFJKNCACBDG_OpenEventType == 1)
				{
					TodoLogger.Log(0, "Event");
					//L1111
				}
				if(!AGDEBBENNCK.OBOPMHBPCFE_MvMode)
				{
					TodoLogger.Log(0, "Play mode");
					//L1156
				}
				else
				{
					if(LGAALOEKCAC.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.GKKDNOFMJJN_NumTicket < 1)
					{
						NIMPEHIECJH();
						yield break;
					}
					LGAALOEKCAC.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.GKKDNOFMJJN_NumTicket--;
					IBJNOOLMBEH = LGAALOEKCAC.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.GKKDNOFMJJN_NumTicket;
					LIIMMJHEADN = 1;
				}
				if(AGDEBBENNCK.GHBPLHBNMBK_FreeMusicId > 0)
				{
					HMMFHMHENAO = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NGCCGLLLDIB_CampaignDiva.MDKOCDHIDMA(NFFDIGEJHGL_ServerTime);
				}
				bool b = false;
				int t = 1;
				if(!AGDEBBENNCK.PMCGHPOGLGM_IsSkip || AGDEBBENNCK.KAIPAEILJHO_TicketCount < 2 || AGDEBBENNCK.KAIPAEILJHO_TicketCount > 0)
				{
					if(!(!AGDEBBENNCK.PMCGHPOGLGM_IsSkip || AGDEBBENNCK.KAIPAEILJHO_TicketCount < 2))
						t = AGDEBBENNCK.KAIPAEILJHO_TicketCount;
					//LAB_00b11758
					for (int i = 0; i < JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN.Count; i++)
					{
						TodoLogger.Log(0, "Event");
						// L1350
					}
					b = true;
				}
				else
				{
					t = AGDEBBENNCK.KAIPAEILJHO_TicketCount;
				}
				if(GNGMCIAIKMA.HHCJCDFCLOB != null)
				{
					HAJIFNABIFF h = new HAJIFNABIFF();
					h.KNIFCANOHOC_Score = -1;
					h.OEILJHENAHN_PlayEventType = AGDEBBENNCK.OEILJHENAHN_PlayEventType;
					h.OBOPMHBPCFE_MvMode = AGDEBBENNCK.OBOPMHBPCFE_MvMode;
					GNGMCIAIKMA.HHCJCDFCLOB.GJENEJOANEL(/*15*/DKFJADMCNPI.NLKCMNHOBAI.GJPEANBALKF, 0, t, h);
					GNGMCIAIKMA.HHCJCDFCLOB.HEFIKPAHCIA(null, -1);
				}
				QuestUtility.UpdateQuestData(LayoutQuestTab.eTabType.Event);
				if (b)
				{
					do
					{
						MJOFDDCIABC(AGDEBBENNCK, NEILMPDKKLJ); // ??
						t--;
					} while (t != 0);
				}
				if (KEHOJEJMGLJ.HHCJCDFCLOB.KLIJFOBEKBE.JCENJHBMDIP(NEILMPDKKLJ.KKPAHLMJKIH_WavId, NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime(), IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IELDDHJMFKN_Asset.MCHKDCGEAOB()))
				{
					KEHOJEJMGLJ.HHCJCDFCLOB.KLIJFOBEKBE.HJMKBCFJOOH();
				}
				NHPGGBCKLHC_FriendPlayerData = AGDEBBENNCK.NHPGGBCKLHC_FriendData;
				if(NHPGGBCKLHC_FriendPlayerData != null)
				{
					TodoLogger.Log(0, "Friend");
				}
				PGIGNJDPCAH.NNOBACMJHDM(AGDEBBENNCK.MNNHHJBBICA_GameEventType == 2 ? PGIGNJDPCAH.FELLIEJEPIJ.ANGNLABPOIH/*4*/ : PGIGNJDPCAH.FELLIEJEPIJ.NADCOIBMMJM/*2*/);
				if (BHFHGFKBOHH != null)
					BHFHGFKBOHH();
			}
			else
			{
				AGDEBBENNCK = null;
				NIMPEHIECJH();
			}
		}
	}

	// // RVA: 0xB02834 Offset: 0xB02834 VA: 0xB02834
	// public void CNNNAAACEHE(bool DKKJPLALNFD, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B6380 Offset: 0x6B6380 VA: 0x6B6380
	// // RVA: 0xB0289C Offset: 0xB0289C VA: 0xB0289C
	// private IEnumerator KMOBPDBOCHJ(bool DKKJPLALNFD, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0xB02994 Offset: 0xB02994 VA: 0xB02994
	private void MJOFDDCIABC(JGEOBNENMAH.EDHCNKBMLGI OMNOFMEBLAD, EONOEHOKBEB_Music EPMMNEFADAP)
	{
		if(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId < 1)
		{
			if(OMNOFMEBLAD.KLCIIHKFPPO_StoryMusicId > 0)
			{
				TodoLogger.Log(0, "MJOFDDCIABC Story");
			}
		}
		else if(!OMNOFMEBLAD.OBOPMHBPCFE_MvMode)
		{
			if(OMNOFMEBLAD.MNNHHJBBICA_GameEventType != 2)
			{
				if(OMNOFMEBLAD.MNNHHJBBICA_GameEventType == 3)
				{
					TodoLogger.Log(0, "MJOFDDCIABC Event");
				}
				else
				{
					TodoLogger.Log(0, "MJOFDDCIABC Event");
				}
			}
		}
	}

	// // RVA: 0xB03AB4 Offset: 0xB03AB4 VA: 0xB03AB4
	public void EFHPJGACNLK(HAJIFNABIFF OMNOFMEBLAD, IMCBBOAFION BHFHGFKBOHH_CbSuccess, DJBHIFLHJLK MOBEEPPKFLG_CbError)
	{
		N.a.StartCoroutineWatched(IILJJMAEPCI_GameClear(OMNOFMEBLAD, BHFHGFKBOHH_CbSuccess, MOBEEPPKFLG_CbError));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B63F8 Offset: 0x6B63F8 VA: 0x6B63F8
	// // RVA: 0xB03B1C Offset: 0xB03B1C VA: 0xB03B1C
	private IEnumerator IILJJMAEPCI_GameClear(HAJIFNABIFF OMNOFMEBLAD, IMCBBOAFION BHFHGFKBOHH_CbSuccess, DJBHIFLHJLK MOBEEPPKFLG_CbError)
	{
		//0xB0C53C
		CNGFKOJANNP.HHCJCDFCLOB.BNGIDMBNILP_ManualCheck();
		yield return null;
		IMMAOANGPNK.HHCJCDFCLOB.PFAKPFKJJKA();
		if(IMMAOANGPNK.HHCJCDFCLOB.ENEBEGGOHFP != 0)
		{
			UnityEngine.Debug.LogError("Exit Error IILJJMAEPCI_GameClear");
			yield return N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(null, MOBEEPPKFLG_CbError));
			yield break;
		}
		else
		{
			FENCAJJBLBH check = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PFAKPFKJJKA(true);
			if (check != null)
			{
				UnityEngine.Debug.LogError("Exit Error IILJJMAEPCI_GameClear");
				yield return N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(check, MOBEEPPKFLG_CbError));
				yield break;
			}
			else if (OMNOFMEBLAD.NMNHBJIAPGG_CheckFalsification != null)
			{
				UnityEngine.Debug.LogError("Exit Error IILJJMAEPCI_GameClear");
				yield return N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(OMNOFMEBLAD.NMNHBJIAPGG_CheckFalsification, MOBEEPPKFLG_CbError));
				yield break;
			}
			else if (OMNOFMEBLAD.OBOPMHBPCFE_MvMode)
			{
				UnityEngine.Debug.LogError("Exit IILJJMAEPCI_GameClear");
				yield return N.a.StartCoroutineWatched(PJEBPAKPANP_Coroutine_SimulationEnd(OMNOFMEBLAD, BHFHGFKBOHH_CbSuccess, MOBEEPPKFLG_CbError));
				yield break;
			}
			else
			{
				IKDICBBFBMI_EventBase eventInfo = null;
				if (OMNOFMEBLAD.MNNHHJBBICA_GameEventType == 4)
				{
					eventInfo = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.AJLEDCKMFLP(KGCNCBOKCBA.GNENJEHKMHD.EMAMLLFAOJI);
				}
				else
				{
					eventInfo = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB(KGCNCBOKCBA.GNENJEHKMHD.EMAMLLFAOJI, true);
				}
				if(eventInfo == null)
				{
					if(OMNOFMEBLAD.MNNHHJBBICA_GameEventType != 0)
					{
						TodoLogger.Log(0, "Event");
						// L 289
					}
				}
				else
				{
					TodoLogger.Log(0, "Event");
					// L331
				}
				DCELMKFJHPG.Clear();
				AMJFOGHBFKJ_DivaIds.Clear();
				for(int i = 0; i < OMNOFMEBLAD.HNHCIGMKPDC_DivaIds.Count; i++)
				{
					AMJFOGHBFKJ_DivaIds.Add(OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[i]);
				}
				CBGMOGIBALL.Clear();
				CIOECGOMILE NLJKCDHIPEG_serverData = CIOECGOMILE.HHCJCDFCLOB;
				BBHNACPENDM_ServerSaveData prevServerData = NLJKCDHIPEG_serverData.MNJHBCIIHED_PrevServerData;
				BBHNACPENDM_ServerSaveData serverData = NLJKCDHIPEG_serverData.AHEFHIMGIBI_ServerSave;
				prevServerData.ODDIHGPONFL_Copy(serverData);
				FOCPLKMMCAL KFIEMBCDEFO = new FOCPLKMMCAL();
				KFIEMBCDEFO.NKGFGDGFGFM = NKGFGDGFGFM;
				KFIEMBCDEFO.HMMFHMHENAO = HMMFHMHENAO;
				KFIEMBCDEFO.FCLGIPFPIPH = FCLGIPFPIPH;
				if(!OMNOFMEBLAD.PMCGHPOGLGM_IsSkip || OMNOFMEBLAD.KAIPAEILJHO_TicketCount < 2)
				{
					KFIEMBCDEFO.LFGNFNDDLJH_TicketCount = 1;
				}
				else
				{
					KFIEMBCDEFO.LFGNFNDDLJH_TicketCount = OMNOFMEBLAD.KAIPAEILJHO_TicketCount;
				}
				KFIEMBCDEFO.ACMMDAHKCIF = ACMMDAHKCIF;
				KFIEMBCDEFO.GNAMCOJKEFE = GNAMCOJKEFE;
				KFIEMBCDEFO.INKMIAAMIEO_EventRareDropDenom = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("event_rare_drop_denom", 10000);
				KFIEMBCDEFO.BCCJLLJMPAA_EventRareDropDenomRand = UnityEngine.Random.Range(0, KFIEMBCDEFO.INKMIAAMIEO_EventRareDropDenom);
				KFIEMBCDEFO.HIEBJGOKEID_ItemId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ICICKEBMEFA_Medal.DNEKJCKEOHL(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
				BEOKMNIPFBA = KFIEMBCDEFO.HIEBJGOKEID_ItemId;
				ODOOKDGCKMF = 0;
				JDDGPJDKHNE.HHCJCDFCLOB.NFNLGGHMEAM();
				JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = true;
				if(OMNOFMEBLAD.JPJMALBLKDI_Tutorial == 0)
				{
					JDDGPJDKHNE.HHCJCDFCLOB.CDIFNFCHDCC();
				}
				int FNAFPJGPGAC = 0;
				if(OMNOFMEBLAD.MNNHHJBBICA_GameEventType == 11)
				{
					TodoLogger.Log(0, "Event");
					//L585
				}
				KFIEMBCDEFO.MDPFLKOIJFN(OMNOFMEBLAD, NHPGGBCKLHC_FriendPlayerData);
				IBEIMGHLPPJ(KFIEMBCDEFO, OMNOFMEBLAD);
				if (KFIEMBCDEFO.HNNPBABEPBP(OMNOFMEBLAD, NHPGGBCKLHC_FriendPlayerData))
				{
					DDGBLKBDAFC = null;
					DFDEALBHBDB = null;
					NEFFKLNAAJI = new int[10];
					for (int i = 0; i < NEFFKLNAAJI.Length; i++)
					{
						NEFFKLNAAJI[i] = 0;
					}
					PGIGNJDPCAH.NNOBACMJHDM(PGIGNJDPCAH.FELLIEJEPIJ.NADCOIBMMJM/*2*/);
					if (OMNOFMEBLAD.MNNHHJBBICA_GameEventType == 4)
					{
						TodoLogger.Log(0, "Event");
						//L692
					}
					if (OMNOFMEBLAD.MFJKNCACBDG_OpenEventType != 1)
					{
						if (OMNOFMEBLAD.MNNHHJBBICA_GameEventType == 2)
						{
							TodoLogger.Log(0, "Event");
							//733
						}
						else if (OMNOFMEBLAD.MNNHHJBBICA_GameEventType == 3)
						{
							TodoLogger.Log(0, "Event");
							//780
						}
						else if (OMNOFMEBLAD.MNNHHJBBICA_GameEventType == 6)
						{
							TodoLogger.Log(0, "Event");
							//834
						}
						else if (OMNOFMEBLAD.MNNHHJBBICA_GameEventType == 11)
						{
							TodoLogger.Log(0, "Event");
							//883
						}
						else if (OMNOFMEBLAD.MNNHHJBBICA_GameEventType == 14)
						{
							TodoLogger.Log(0, "Event");
							//932
						}
					}
					else
					{
						TodoLogger.Log(0, "Event");
						//1023
					}
					//1065
					if (LAMCONGFONF.HHCJCDFCLOB != null)
					{
						TodoLogger.Log(0, "Todo");
						//1065
					}
					if (OMNOFMEBLAD.JPJMALBLKDI_Tutorial == 0)
					{
						if (JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG, KGCNCBOKCBA.GNENJEHKMHD.EMAMLLFAOJI) != null)
						{
							TodoLogger.Log(0, "Event");
							//1169
						}
						int c = 0;
						if (!OMNOFMEBLAD.PMCGHPOGLGM_IsSkip || OMNOFMEBLAD.KAIPAEILJHO_TicketCount < 2)
						{
							c = 1;
						}
						else if (OMNOFMEBLAD.KAIPAEILJHO_TicketCount > 0)
						{
							c = OMNOFMEBLAD.KAIPAEILJHO_TicketCount;
						}
						for (int i = 0; i < c; i++)
						{
							for (int j = 0; j < JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN.Count; j++)
							{
								TodoLogger.Log(0, "Event");
								/*if(JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN[j].AGLILDLEFDK != null)
								{
									JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN[j].
								}*/
							}
							if (OMNOFMEBLAD.KLCIIHKFPPO_StoryMusicId == 0 && GNGMCIAIKMA.HHCJCDFCLOB != null)
							{
								GNGMCIAIKMA.HHCJCDFCLOB.HEFIKPAHCIA(OMNOFMEBLAD, -1);
							}
						}
						QuestUtility.UpdateQuestData(LayoutQuestTab.eTabType.Event);
					}
					for(int i = 0; i < KFIEMBCDEFO.DCELMKFJHPG.Count; i++)
					{
						DCELMKFJHPG.Add(KFIEMBCDEFO.DCELMKFJHPG[i]);
					}
					PFHMFKKDMBM_FreeMusicId = OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId;
					LBLOIOMNEIH_Difficulty = OMNOFMEBLAD.AKNELONELJK_Difficulty;
					IKBLCEFCGDE_LastLuck = OMNOFMEBLAD.MJBODMOLOBC_TeamLuck;
					GCAPLLEIAAI_LastScore = OMNOFMEBLAD.KNIFCANOHOC_Score;
					GPMILOPNBPA_LastScoreExcellent = OMNOFMEBLAD.EACPIDGGPPO_ExcellentScore;
					PBGLMBMEKAA_LastCombo = OMNOFMEBLAD.NLKEBAOBJCM_MaxCombo;
					CODDMAKLBDO_LastComboRank = OMNOFMEBLAD.LCOHGOIDMDF_ComboRank;
					NNABDGKFEMK_EventType = (OHCAABOMEOF.KGOGMKMBCPP_EventType)OMNOFMEBLAD.MNNHHJBBICA_GameEventType;
					PENICOGGNLF = KFIEMBCDEFO.PENICOGGNLF_ScoreRank;
					CFNCNCBEPED = KFIEMBCDEFO.CFNCNCBEPED;
					NMDKKAAOIOI_LastBaseUnionCredit = KFIEMBCDEFO.NMDKKAAOIOI_BaseUnionCredit;
					MJKFDDKLLFP_LastDropUnionCredit = KFIEMBCDEFO.MJKFDDKLLFP_DropUnionCredit;
					PLMBDFGGBAJ = KFIEMBCDEFO.PLMBDFGGBAJ;
					MMMKNPEMBIL = KFIEMBCDEFO.MMMKNPEMBIL;
					NGDDIIDJFNG = KFIEMBCDEFO.NGDDIIDJFNG;
					LKGONGDLJBH = KFIEMBCDEFO.LKGONGDLJBH;
					HGHMMDOEGEF = KFIEMBCDEFO.HGHMMDOEGEF;
					MKEPHNGLHDL = KFIEMBCDEFO.MKEPHNGLHDL;
					CBCIFACJGHI = KFIEMBCDEFO.CBCIFACJGHI;
					HBAJPMDOMPL = KFIEMBCDEFO.HBAJPMDOMPL;
					FOIPBBCHBIB = KFIEMBCDEFO.FOIPBBCHBIB;
					FFDBCEDKMGN = KFIEMBCDEFO.FFDBCEDKMGN;
					MMLPAMGJEOD = KFIEMBCDEFO.MMLPAMGJEOD;
					if(OMNOFMEBLAD.JPJMALBLKDI_Tutorial == 0)
					{
						if(OMNOFMEBLAD.KLCIIHKFPPO_StoryMusicId == 0)
						{
							int divaId = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.BBIOMNCILMC_HomeDivaId;
							if (divaId < 1)
							{
								divaId = OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0];
							}
							KDHGBOOECKC.HHCJCDFCLOB.IOCBOGFFHFE.LHPDDGIJKNB();
							for(int i = 0; i < KFIEMBCDEFO.LFGNFNDDLJH_TicketCount; i++)
							{
								KDHGBOOECKC.HHCJCDFCLOB.PANBPMDADAH(divaId, OMNOFMEBLAD.AKNELONELJK_Difficulty);
							}
						}
					}
					CMCDIOOEHMI = KFIEMBCDEFO.IONINNDIAFO;
					KDKHGAPKBNI = KFIEMBCDEFO.JANMJPOKLFL;
					BEOKMNIPFBA = KFIEMBCDEFO.HIEBJGOKEID_ItemId;
					ODOOKDGCKMF = KFIEMBCDEFO.GIPMPIMJHLE;
					if(OMNOFMEBLAD.JPJMALBLKDI_Tutorial == 0)
					{
						BIFNGFAIEIL.HHCJCDFCLOB.DNKCCHCEPBH(false);
					}
					if(OMNOFMEBLAD.JPJMALBLKDI_Tutorial > 0)
					{
						TodoLogger.Log(0, "Tutorial");
						// L1601
					}
					if(CPABPPPPKEP)
					{
						//LAB_00b0e7f8;
						NDABOOOOENC.HHCJCDFCLOB.NKFNJMEELMP();
						JDDGPJDKHNE.HHCJCDFCLOB.FECGDGCNGGN();
						//LAB_00b0e874
						JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
						if (BHFHGFKBOHH_CbSuccess != null)
							BHFHGFKBOHH_CbSuccess();
						UnityEngine.Debug.LogError("Exit IILJJMAEPCI_GameClear");
						yield break;
					}
					else
					{
						//L1621
						bool BEKAMBBOLBO = false;
						bool CNAIDEAFAAM = false;
						NLJKCDHIPEG_serverData.JHOKIPPIHII = true;
						FFMIPGABHHA_SaveHash saveHash = serverData.FHLMCCPCEAI_SaveHash;
						saveHash.IOIMHJAOKOO = FFMIPGABHHA_SaveHash.CAOGDCBPBAN(NKGFGDGFGFM, OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId, (OMNOFMEBLAD.LFGNLKKFOCD_IsLine6 ? 0 : 10) + OMNOFMEBLAD.AKNELONELJK_Difficulty);
						saveHash.BEBJKJKBOGH_Time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
						if(FNAFPJGPGAC == 0)
						{
							if(!KFIEMBCDEFO.EDDMMPBELBM)
							{
								NLJKCDHIPEG_serverData.AIKJMHBDABF(() =>
								{
									//0xB0AAB0
									BEKAMBBOLBO = true;
								}, () =>
								{
									//0xB0AABC
									BEKAMBBOLBO = true;
									CNAIDEAFAAM = true;
								}, null);
							}
							else
							{
								NLJKCDHIPEG_serverData.BMKEBEJJKBE(() =>
								{
									//0xB0AA98
									BEKAMBBOLBO = true;
								}, () =>
								{
									//0xB0AAA4
									BEKAMBBOLBO = true;
									CNAIDEAFAAM = true;
								}, 1);
							}
						}
						else
						{
							NLJKCDHIPEG_serverData.LOOCNGEPAMI(() =>
							{
								//0xB0AA80
								BEKAMBBOLBO = true;
							}, () =>
							{
								//0xB0AA8C
								BEKAMBBOLBO = true;
								CNAIDEAFAAM = true;
							}, FNAFPJGPGAC);
						}
						//goto LAB_00b0c804

						//0xc
						//LAB_00b0c804
						while (!BEKAMBBOLBO)
							yield return null;
						NLJKCDHIPEG_serverData.JHOKIPPIHII = false;
						if(!CNAIDEAFAAM)
						{
							BEKAMBBOLBO = false;
							NNJLMNFBCDF(OMNOFMEBLAD, FNAFPJGPGAC);
							NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.BNJPAKLNOPA_WorkerThreadQueue.Add(() =>
							{
								//0xB0AAC8
								LFDFPBEAAFA.IJLKLIHFMBG();
								BEKAMBBOLBO = true;
							});
							// 0xd
							while(!BEKAMBBOLBO)
							{
								yield return null;
							}
							BEKAMBBOLBO = false;
							CNAIDEAFAAM = false;
							JDDGPJDKHNE.HHCJCDFCLOB.FECGDGCNGGN();
							yield return N.a.StartCoroutineWatched(PLKLMBHENKB_NewSave(false, () =>
							{
								//0xB0AB14
								BEKAMBBOLBO = true;
							}, () =>
							{
								//0xB0AB20
								BEKAMBBOLBO = true;
								CNAIDEAFAAM = true;
							}));
							while(!BEKAMBBOLBO)
							{
								yield return null;
							}
							if(CNAIDEAFAAM)
							{
								NLJKCDHIPEG_serverData.JHOKIPPIHII = false;
								JDDGPJDKHNE.HHCJCDFCLOB.FECGDGCNGGN();
								JDDGPJDKHNE.HHCJCDFCLOB.FOKEGEOKGDG();
								JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
								LFDFPBEAAFA = null;
								MOBEEPPKFLG_CbError();
								UnityEngine.Debug.LogError("Exit Error IILJJMAEPCI_GameClear");
								yield break;
							}
							else
							{
								CPHKNMHLFPC();
								LFDFPBEAAFA.OJCJPCHFPGO();
								LFDFPBEAAFA = null;
								JJOPEDJCCJK_Exp dbExp = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FMPEMFPLPDA_Exp;
								if(dbExp.PCJACJANGCA_GetFriendForLevel(prevServerData.KCCLEHLLOFG_Common.KIECDDFNCAN_Level) < dbExp.PCJACJANGCA_GetFriendForLevel(serverData.KCCLEHLLOFG_Common.KIECDDFNCAN_Level))
								{
									BEKAMBBOLBO = false;
									CNAIDEAFAAM = false;
									CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.PGPLAOGALHD(dbExp.PCJACJANGCA_GetFriendForLevel(serverData.KCCLEHLLOFG_Common.KIECDDFNCAN_Level), () =>
									{
										//0xB0AB2C
										BEKAMBBOLBO = true;
									}, (CACGCMBKHDI_Request ADKIDBJCAJA) =>
									{
										//0xB0AB38
										BEKAMBBOLBO = true;
										CNAIDEAFAAM = true;
									});
									while (!BEKAMBBOLBO)
										yield return null;
									if(!CNAIDEAFAAM)
									{
										//LAB_00b0e7f8
										NDABOOOOENC.HHCJCDFCLOB.NKFNJMEELMP();
										JDDGPJDKHNE.HHCJCDFCLOB.FECGDGCNGGN();
										//LAB_00b0e874
										JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
										if (BHFHGFKBOHH_CbSuccess != null)
											BHFHGFKBOHH_CbSuccess();
										UnityEngine.Debug.LogError("Exit IILJJMAEPCI_GameClear");
										yield break;
									}
								}
								else
								{
									//LAB_00b0e7f8
									NDABOOOOENC.HHCJCDFCLOB.NKFNJMEELMP();
									JDDGPJDKHNE.HHCJCDFCLOB.FECGDGCNGGN();
									//LAB_00b0e874
									JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
									if (BHFHGFKBOHH_CbSuccess != null)
										BHFHGFKBOHH_CbSuccess();
									UnityEngine.Debug.LogError("Exit IILJJMAEPCI_GameClear");
									yield break;
								}
							}
						}
						// switch break
					}
				}
				// switch break
			}
		}
		JDDGPJDKHNE.HHCJCDFCLOB.FECGDGCNGGN();
		JDDGPJDKHNE.HHCJCDFCLOB.FOKEGEOKGDG();
		JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
		UnityEngine.Debug.LogError("Exit Error IILJJMAEPCI_GameClear");
		MOBEEPPKFLG_CbError();
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B6470 Offset: 0x6B6470 VA: 0x6B6470
	// // RVA: 0xB03C14 Offset: 0xB03C14 VA: 0xB03C14
	private IEnumerator PJEBPAKPANP_Coroutine_SimulationEnd(HAJIFNABIFF OMNOFMEBLAD, IMCBBOAFION BHFHGFKBOHH_CbSuccess, DJBHIFLHJLK MOBEEPPKFLG_CbError)
	{
		//0xB15CF4
		yield return null;
		CPHJGFLEFNF d = new CPHJGFLEFNF();
		d.HBODCMLFDOB = 1;
		d.ICJEDACBMMF_ServerTime = NFFDIGEJHGL_ServerTime;
		d.IMIEPNOECFD_HasValkyrieMode = OMNOFMEBLAD.KNCBNGCDMII_HadValkyrieMode ? 1 : 0;
		int divaMode = 2;
		if(!OMNOFMEBLAD.HGEKDNNJAAC_HadAwakenDivaMode)
		{
			divaMode = OMNOFMEBLAD.OOOGNIPJMDE_HadDivaMode ? 1 : 0;
		}
		d.GFODFMFGLJG_HadDivaMode = divaMode;
		d.LMOBPKIDIHF_AverageFps = OMNOFMEBLAD.OJDDNGGBJOG_AverageFPS;
		d.IPAAOFCGEAB_MinFps = OMNOFMEBLAD.BIIGPMLBOOD_MinFPS;
		ILCCJNDFFOB.HHCJCDFCLOB.GDHNBIIOKMF(d, OMNOFMEBLAD, NKGFGDGFGFM);
		CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.OEKEIGFAIGN_Counter.BDLNMOIOMHK.LLKJHBIPCOP();
		if(GNGMCIAIKMA.HHCJCDFCLOB != null)
		{
			GNGMCIAIKMA.HHCJCDFCLOB.HEFIKPAHCIA(OMNOFMEBLAD, -1);
		}
		bool BEKAMBBOLBO = false;
		bool CNAIDEAFAAM = false;
		CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF(() =>
		{
			//0xB0AB4C
			BEKAMBBOLBO = true;
		}, () =>
		{
			//0xB0AB58
			BEKAMBBOLBO = true;
			CNAIDEAFAAM = true;
		}, null);
		while (!BEKAMBBOLBO)
			yield return null;
		if(!CNAIDEAFAAM)
		{
			Debug.LogError("Exit PJEBPAKPANP_Coroutine_SimulationEnd");
			BHFHGFKBOHH_CbSuccess();
		}
		else
		{
			CIOECGOMILE.HHCJCDFCLOB.JHOKIPPIHII = false;
			JDDGPJDKHNE.HHCJCDFCLOB.FOKEGEOKGDG();
			JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
			Debug.LogError("Exit Error PJEBPAKPANP_Coroutine_SimulationEnd");
			MOBEEPPKFLG_CbError();
		}
	}

	// // RVA: 0xB03D0C Offset: 0xB03D0C VA: 0xB03D0C
	// private JBECFDNKPFD GLNPPDPDJGN(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD) { }

	// // RVA: 0xB05AB8 Offset: 0xB05AB8 VA: 0xB05AB8
	private void IBEIMGHLPPJ(FOCPLKMMCAL JNLKJCDFFMM, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD)
	{
		TodoLogger.Log(0, "IBEIMGHLPPJ");
	}

	// // RVA: 0xB0756C Offset: 0xB0756C VA: 0xB0756C
	public void EFHMAKNEGEA(HAJIFNABIFF OMNOFMEBLAD)
	{
		TodoLogger.Log(0, "EFHMAKNEGEA");
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B64E8 Offset: 0x6B64E8 VA: 0x6B64E8
	// // RVA: 0xB08A04 Offset: 0xB08A04 VA: 0xB08A04
	private IEnumerator EHNDCODOBBL_Coroutine_Falsification(FENCAJJBLBH KOGBMDOONFA, DJBHIFLHJLK MOBEEPPKFLG)
	{
		//0xB0BE58
		yield return null;
		throw new GAMEENDEXCEPTION();
		//??
	}

	// // RVA: 0xB06F28 Offset: 0xB06F28 VA: 0xB06F28
	public static EONOEHOKBEB_Music DLOBJHGIBJE_GetMusicInfo(PDNNOFFFDAG OMNOFMEBLAD, bool JPGCOPGIDDM = false)
	{
		if(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId < 1)
		{
			if (OMNOFMEBLAD.KLCIIHKFPPO_StoryMusicId < 1)
				return null;
			if (OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId != 0)
				return null;
			if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.CLHIABAKKJM_StoryMusicData.Count <= OMNOFMEBLAD.KLCIIHKFPPO_StoryMusicId)
				return null;
			DJNPIGEFPMF_StoryMusicInfo mdata = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.CLHIABAKKJM_StoryMusicData[OMNOFMEBLAD.KLCIIHKFPPO_StoryMusicId - 1];
			if (mdata.KLCIIHKFPPO != OMNOFMEBLAD.KLCIIHKFPPO_StoryMusicId)
				return null;
			if (mdata.DLAEJOBELBH_Id < 0)
				return null;
			if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.EPMMNEFADAP_Musics.Count <= mdata.DLAEJOBELBH_Id)
				return null;
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.EPMMNEFADAP_Musics[mdata.DLAEJOBELBH_Id - 1];
		}
		else
		{
			if (OMNOFMEBLAD.KLCIIHKFPPO_StoryMusicId != 0)
				return null;
			if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas.Count < OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId)
				return null;
			KEODKEGFDLD_FreeMusicInfo mData = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas[OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId - 1];
			if (OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId != mData.GHBPLHBNMBK_FreeMusicId)
				return null;
			if (mData.DLAEJOBELBH_MusicId < 0)
				return null;
			if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.EPMMNEFADAP_Musics.Count <= mData.DLAEJOBELBH_MusicId)
				return null;
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.EPMMNEFADAP_Musics[mData.DLAEJOBELBH_MusicId - 1];
		}
	}

	// // RVA: 0xB08AB0 Offset: 0xB08AB0 VA: 0xB08AB0
	public static KLBKPANJCPL_Score KFFCMNELJJB_GetMusicScore(EONOEHOKBEB_Music EPMMNEFADAP, int AKNELONELJK, bool GIKLNODJKFK = false)
	{
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.ALJFMLEJEHH_GetMusicScore(EPMMNEFADAP.KKPAHLMJKIH_WavId, EPMMNEFADAP.BKJGCEOEPFB_VariationId, AKNELONELJK, GIKLNODJKFK, true);
	}

	// // RVA: 0xB08C04 Offset: 0xB08C04 VA: 0xB08C04
	public static int NNDOEOOAMLO_GetMusicStamina(PDNNOFFFDAG OMNOFMEBLAD, KLBKPANJCPL_Score KNIFCANOHOC_ScoreInfo)
	{
		if(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId > 0)
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.HHEEPBJNAKA_GetEnergy(KNIFCANOHOC_ScoreInfo.ANAJIAENLNB_F_pt, OMNOFMEBLAD.LFGNLKKFOCD_IsLine6);
		}
		if (OMNOFMEBLAD.KLCIIHKFPPO_StoryMusicId < 1)
			return 0;
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.MMLNFAJOPCB_GetStoryEnergy(KNIFCANOHOC_ScoreInfo.ANAJIAENLNB_F_pt);
	}

	// // RVA: 0xB08E08 Offset: 0xB08E08 VA: 0xB08E08
	// public int MFMPOFABICK() { }

	// // RVA: 0xB08F70 Offset: 0xB08F70 VA: 0xB08F70
	// public int BHOAOPKAPGD(int GHBPLHBNMBK) { }

	// // RVA: 0xB091F4 Offset: 0xB091F4 VA: 0xB091F4
	// public int HMPOCCFEIBJ(int GHBPLHBNMBK) { }

	// // RVA: 0xB09454 Offset: 0xB09454 VA: 0xB09454
	// public bool HCFONACBEBD(OKGLGHCBCJP LKMHPJKIFDN, BBHNACPENDM LDEGEHAEALK, int GHBPLHBNMBK, int MNLNFGKJANA) { }

	// // RVA: 0xB095C8 Offset: 0xB095C8 VA: 0xB095C8
	// public bool IGJJIDDOOJO(int GHBPLHBNMBK) { }

	// // RVA: 0xB097F8 Offset: 0xB097F8 VA: 0xB097F8
	// public bool KKKHEOCDFAL(int GHBPLHBNMBK) { }

	// // RVA: 0xB09B1C Offset: 0xB09B1C VA: 0xB09B1C
	// public void CADNBFCHAKM(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0xB09B58 Offset: 0xB09B58 VA: 0xB09B58
	private void NNJLMNFBCDF(HAJIFNABIFF OMNOFMEBLAD, int HJBLIJOGNPC)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
		for(int i = 0; i < JDDGPJDKHNE.HHCJCDFCLOB.FBCJICEPLED.HNBFOAJIIAL_Count; i++)
		{
			data.Add(JDDGPJDKHNE.HHCJCDFCLOB.FBCJICEPLED[i]);
		}
		LFDFPBEAAFA = new PKECIDPBEFL();
		LFDFPBEAAFA.DOMFHDPMCCO(CBGMOGIBALL, DDGBLKBDAFC, DFDEALBHBDB, CIOECGOMILE.HHCJCDFCLOB.PMHLJAIGBGK, CIOECGOMILE.HHCJCDFCLOB.FMEDFGOMNBK, 
			!CIOECGOMILE.HHCJCDFCLOB.KDLBAGCENNC.BLOCFLFHCFJ, CIOECGOMILE.HHCJCDFCLOB.KDLBAGCENNC.KFGDPMNCCFO,
			CIOECGOMILE.HHCJCDFCLOB.KDLBAGCENNC.OBHAFLMHAKG, data, NDABOOOOENC.HHCJCDFCLOB.HHKNOHKGAHP(), CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.FHLMCCPCEAI_SaveHash.BEBJKJKBOGH_Time,
			FOPBGEGCJCJ, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.FHLMCCPCEAI_SaveHash.IOIMHJAOKOO, HJBLIJOGNPC, PBJPACKDIIB.JAFKPMFPICA());
	}

	// // RVA: 0xB09F5C Offset: 0xB09F5C VA: 0xB09F5C
	// private bool PFELGCCNAPJ(SakashoErrorId CNAIDEAFAAM) { }

	// // RVA: 0xB09F7C Offset: 0xB09F7C VA: 0xB09F7C
	private void CPHKNMHLFPC()
	{
		TodoLogger.Log(0, "CPHKNMHLFPC");
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B6560 Offset: 0x6B6560 VA: 0x6B6560
	// // RVA: 0xB0A280 Offset: 0xB0A280 VA: 0xB0A280
	private IEnumerator PLKLMBHENKB_NewSave(bool JCCBGECHIEI, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		yield return null;
		TodoLogger.Log(0, "PLKLMBHENKB_NewSave");
		BHFHGFKBOHH();
	}

	// // RVA: 0xB0A378 Offset: 0xB0A378 VA: 0xB0A378
	public void EMDLPEGOEJB_Recover(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
    {
		LFDFPBEAAFA = new PKECIDPBEFL();
		LFDFPBEAAFA.PEHBBKFGLNO();
		if(LFDFPBEAAFA.GKMONHIBHCL)
		{
			N.a.StartCoroutineWatched(ODBDMBAFOIN_Coroutine_Recover(BHFHGFKBOHH, AOCANKOMKFG));
			return;
		}
		LFDFPBEAAFA.OJCJPCHFPGO();
		LFDFPBEAAFA = null;
		BHFHGFKBOHH();
    }

	// [IteratorStateMachineAttribute] // RVA: 0x6B65D8 Offset: 0x6B65D8 VA: 0x6B65D8
	// // RVA: 0xB0A4B4 Offset: 0xB0A4B4 VA: 0xB0A4B4
	private IEnumerator ODBDMBAFOIN_Coroutine_Recover(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		//UnityEngine.Debug.Log("Enter ODBDMBAFOIN_Coroutine_Recover");
		TodoLogger.Log(0, "TODO");
		//UnityEngine.Debug.Log("Exit ODBDMBAFOIN_Coroutine_Recover");
		yield break;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B6650 Offset: 0x6B6650 VA: 0x6B6650
	// // RVA: 0xB0A594 Offset: 0xB0A594 VA: 0xB0A594
	// private IEnumerator HGHFHIDCNIA_ResetSaveHash(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }
}
