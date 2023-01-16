using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using XeSys;
using XeApp.Game.Menu;
using XeApp.Game.RhythmGame;

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
		public List<int> HNHCIGMKPDC; // 0x68
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
	public EAJCBFGKKFA_FriendInfo NHPGGBCKLHC; // 0xC
	// public List<IELJJAAJAOE> DCELMKFJHPG = new List<IELJJAAJAOE>(); // 0x10
	public int PFHMFKKDMBM; // 0x14
	public int LBLOIOMNEIH; // 0x18
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
	public OHCAABOMEOF.KGOGMKMBCPP_EventType NNABDGKFEMK; // 0x68
	public int BEOKMNIPFBA; // 0x6C
	public int ODOOKDGCKMF; // 0x70
	public AIPOFGJGPKI_CampaignDiva.KBLBMGDILAI HMMFHMHENAO; // 0x74
	// public JKNGJFOBADP KDKHGAPKBNI; // 0x78
	public List<int> AMJFOGHBFKJ = new List<int>(5); // 0x7C
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
	// public List<PKECIDPBEFL.DDBKLMKKCDL> CBGMOGIBALL = new List<PKECIDPBEFL.DDBKLMKKCDL>(); // 0xE0
	public long FOPBGEGCJCJ; // 0xE8

	public static JGEOBNENMAH HHCJCDFCLOB { get; private set; } // 0x0 LGMPACEDIJF NKACBOEHELJ OKPMHKNCNAL
	// public int FPPNIKFLAFM { get; set; } //  GPHMLKHBJIM 0xB02580  DHFALCHNOOF 0xB02594
	// public int FCLGIPFPIPH { get; set; } // GHFOOLBCDBM 0xB025A8 EFACKLMPIOD 0xB025BC

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
		N.a.StartCoroutine(PFEKBBONCJJ_Coroutine_GameStart(KEOCOHOFPNK, BHFHGFKBOHH, DBCEPOAHNBH, NIMPEHIECJH, AOCANKOMKFG, IGBGKGAIJPL, INLLNIEEHAN));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B6308 Offset: 0x6B6308 VA: 0x6B6308
	// // RVA: 0xB026CC Offset: 0xB026CC VA: 0xB026CC
	private IEnumerator PFEKBBONCJJ_Coroutine_GameStart(EDHCNKBMLGI KEOCOHOFPNK, IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP DBCEPOAHNBH, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK MOBEEPPKFLG, DJBHIFLHJLK IGBGKGAIJPL, JGEOBNENMAH.NNEICCOGCLL INLLNIEEHAN)
	{
		//0xB10460
		CNGFKOJANNP.HHCJCDFCLOB.BNGIDMBNILP();
		yield return null;
		AGDEBBENNCK = KEOCOHOFPNK;
		HLJJPCPAOBD = 0x5e959;
		ECHONOJEPHP = 0;
		NIJFFOPEEGK = 0;
		HMMFHMHENAO = null;
		HIGJBGFJMMO = false;
		GNAMCOJKEFE = false;
		IBJNOOLMBEH = 0;
		LIIMMJHEADN = 0;
		KIHLOJGPFII = 0x341b34c8; //??
		ACMMDAHKCIF = 0x341b34c8; //??
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
		EONOEHOKBEB_Music NEILMPDKKLJ = DLOBJHGIBJE(AGDEBBENNCK, false);
		if(NEILMPDKKLJ == null)
		{
			AGDEBBENNCK = null;
			NIMPEHIECJH();
			yield break;
		}
		else
		{
			KLBKPANJCPL_Score GIPDCDAEIKA = KFFCMNELJJB(NEILMPDKKLJ, AGDEBBENNCK.AKNELONELJK_Difficulty, AGDEBBENNCK.LFGNLKKFOCD_IsLine6);
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
				NHPGGBCKLHC = AGDEBBENNCK.NHPGGBCKLHC_FriendData;
				if(NHPGGBCKLHC != null)
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
	public void EFHPJGACNLK(HAJIFNABIFF OMNOFMEBLAD, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		N.a.StartCoroutine(IILJJMAEPCI_GameClear(OMNOFMEBLAD, BHFHGFKBOHH, MOBEEPPKFLG));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B63F8 Offset: 0x6B63F8 VA: 0x6B63F8
	// // RVA: 0xB03B1C Offset: 0xB03B1C VA: 0xB03B1C
	private IEnumerator IILJJMAEPCI_GameClear(HAJIFNABIFF OMNOFMEBLAD, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		//0xB0C53C
		TodoLogger.Log(0, "IILJJMAEPCI_GameClear");
		yield return null;
		BHFHGFKBOHH();
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B6470 Offset: 0x6B6470 VA: 0x6B6470
	// // RVA: 0xB03C14 Offset: 0xB03C14 VA: 0xB03C14
	// private IEnumerator PJEBPAKPANP_SimulationEnd(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0xB03D0C Offset: 0xB03D0C VA: 0xB03D0C
	// private JBECFDNKPFD GLNPPDPDJGN(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD) { }

	// // RVA: 0xB05AB8 Offset: 0xB05AB8 VA: 0xB05AB8
	// private void IBEIMGHLPPJ(FOCPLKMMCAL JNLKJCDFFMM, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD) { }

	// // RVA: 0xB0756C Offset: 0xB0756C VA: 0xB0756C
	public void EFHMAKNEGEA(HAJIFNABIFF OMNOFMEBLAD)
	{
		TodoLogger.Log(0, "EFHMAKNEGEA");
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B64E8 Offset: 0x6B64E8 VA: 0x6B64E8
	// // RVA: 0xB08A04 Offset: 0xB08A04 VA: 0xB08A04
	// private IEnumerator EHNDCODOBBL_Falsification(FENCAJJBLBH KOGBMDOONFA, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0xB06F28 Offset: 0xB06F28 VA: 0xB06F28
	public static EONOEHOKBEB_Music DLOBJHGIBJE(PDNNOFFFDAG OMNOFMEBLAD, bool JPGCOPGIDDM = false)
	{
		if(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId < 1)
		{
			if (OMNOFMEBLAD.KLCIIHKFPPO_StoryMusicId < 1)
				return null;
			if (OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId != 0)
				return null;
			if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.CLHIABAKKJM_StoryMusicData.Count <= OMNOFMEBLAD.KLCIIHKFPPO_StoryMusicId)
				return null;
			DJNPIGEFPMF mdata = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.CLHIABAKKJM_StoryMusicData[OMNOFMEBLAD.KLCIIHKFPPO_StoryMusicId - 1];
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
			KEODKEGFDLD mData = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas[OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId - 1];
			if (OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId != mData.GHBPLHBNMBK)
				return null;
			if (mData.DLAEJOBELBH_Id < 0)
				return null;
			if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.EPMMNEFADAP_Musics.Count <= mData.DLAEJOBELBH_Id)
				return null;
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.EPMMNEFADAP_Musics[mData.DLAEJOBELBH_Id - 1];
		}
	}

	// // RVA: 0xB08AB0 Offset: 0xB08AB0 VA: 0xB08AB0
	public static KLBKPANJCPL_Score KFFCMNELJJB(EONOEHOKBEB_Music EPMMNEFADAP, int AKNELONELJK, bool GIKLNODJKFK = false)
	{
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.ALJFMLEJEHH_GetMusicScore(EPMMNEFADAP.KKPAHLMJKIH_WavId, EPMMNEFADAP.BKJGCEOEPFB_VariationId, AKNELONELJK, GIKLNODJKFK, true);
	}

	// // RVA: 0xB08C04 Offset: 0xB08C04 VA: 0xB08C04
	// public static int NNDOEOOAMLO(JGEOBNENMAH.PDNNOFFFDAG OMNOFMEBLAD, KLBKPANJCPL KNIFCANOHOC) { }

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
	// private void NNJLMNFBCDF(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, int HJBLIJOGNPC) { }

	// // RVA: 0xB09F5C Offset: 0xB09F5C VA: 0xB09F5C
	// private bool PFELGCCNAPJ(SakashoErrorId CNAIDEAFAAM) { }

	// // RVA: 0xB09F7C Offset: 0xB09F7C VA: 0xB09F7C
	// private void CPHKNMHLFPC() { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B6560 Offset: 0x6B6560 VA: 0x6B6560
	// // RVA: 0xB0A280 Offset: 0xB0A280 VA: 0xB0A280
	// private IEnumerator PLKLMBHENKB_NewSave(bool JCCBGECHIEI, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0xB0A378 Offset: 0xB0A378 VA: 0xB0A378
	public void EMDLPEGOEJB(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
    {
		LFDFPBEAAFA = new PKECIDPBEFL();
		LFDFPBEAAFA.PEHBBKFGLNO();
		if(LFDFPBEAAFA.GKMONHIBHCL)
		{
			N.a.StartCoroutine(ODBDMBAFOIN_Coroutine_Recover(BHFHGFKBOHH, AOCANKOMKFG));
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
		UnityEngine.Debug.Log("Enter ODBDMBAFOIN_Coroutine_Recover");
		TodoLogger.Log(0, "TODO");
		UnityEngine.Debug.Log("Exit ODBDMBAFOIN_Coroutine_Recover");
		yield break;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B6650 Offset: 0x6B6650 VA: 0x6B6650
	// // RVA: 0xB0A594 Offset: 0xB0A594 VA: 0xB0A594
	// private IEnumerator HGHFHIDCNIA_ResetSaveHash(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }
}
