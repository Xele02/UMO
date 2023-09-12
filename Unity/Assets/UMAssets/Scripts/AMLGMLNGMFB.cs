
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game;
using XeApp.Game.Common;
using XeSys;

[System.Obsolete("Use AMLGMLNGMFB_EventAprilFool", true)]
public class AMLGMLNGMFB { }
public class AMLGMLNGMFB_EventAprilFool : IKDICBBFBMI_EventBase
{
	private enum IGIPPPLKDJP
	{
		HJNNKCMLGFL = 0,
		KEBIIAMNKAJ = 1,
	}

	private enum HODGPGLCPKM
	{
		HJNNKCMLGFL = 0,
		EBKLKECECIF = 1,
	}

	public enum MMKMPKEBLBF
	{
		HJNNKCMLGFL = 0,
		DMPOKMFNPKP = 1,
	}

	public enum ANFKADJMHPO
	{
		LOFOEPLBMID = 0,
		LGMPDPNEPGD = 1,
		BPJBNFNKGOJ = 2,
	}

	public class FOFMLBPMIIC
	{
		public int JJJNKGBCFMI = 0; // 0x8
		public int AGKIABJHDDG = 0; // 0xC
		public string FEMMDNIELFC = ""; // 0x10
		public int JNCPEGJGHOG = 0; // 0x14
		public string NEDBBJDAFBH = ""; // 0x18
	}

	public class OLDLIIKHDKD
	{
		public int CMJEGIEJNMD { get; private set; } // 0x8 IDFDLCAMDJH AGEDDPBMIKH LOLNKOKFIIE
		public MMKMPKEBLBF GODBCGAFMBE { get; private set; } // 0xC JLPCLKOHCAH GJHPPLPNIIF BLONDJKOIOG
		public int DDIOHHEGANL { get; private set; } // 0x10 GHPIIFOKMPM IIFKOIEJFKF DGIPAMDIKPD
		public int ELIFBFLFAFC { get; private set; } // 0x14 IGMJIGLNICF FIIPNJGPEFL EAPCKJIHFEA

		// RVA: 0xCE6E2C Offset: 0xCE6E2C VA: 0xCE6E2C
		public OLDLIIKHDKD(int IGHPMLOFGMO, int AGEGAHMDMPH, int KKFMFGPBHKM, int LGCKAMEEDGC)
		{
			CMJEGIEJNMD = IGHPMLOFGMO;
			GODBCGAFMBE = (MMKMPKEBLBF)AGEGAHMDMPH;
			DDIOHHEGANL = LGCKAMEEDGC;
			ELIFBFLFAFC = KKFMFGPBHKM;
		}
	}

	public class JPGMKBANFGF
	{
		private int FBGGEFFJJHB = 0x13c7dd4; // 0x8
		private sbyte ALPDMEILILP_IsClearCrypted; // 0xC
		private int NBOLDNMPJFG_ScoreCrypted; // 0x10
		private sbyte JAFNIDLINKN_IssecrenCommandCrypted; // 0x14

		public bool BCGLDMKODLC_IsClear { get { return ALPDMEILILP_IsClearCrypted == 115; } set { ALPDMEILILP_IsClearCrypted = (sbyte)(value ? 115 : 54); } } //0xCE7DC8 NNGALFPBDNA 0xCE8E40 JJBMOHCMALD
		public int KNIFCANOHOC_Score { get { return NBOLDNMPJFG_ScoreCrypted ^ FBGGEFFJJHB; } set { NBOLDNMPJFG_ScoreCrypted = value ^ FBGGEFFJJHB; } } //0xCE7D00 EOJEPLIPOMJ 0xCE8E70 AEEMBPAEAAI
		public bool CHPIFIEEEEC_IsSecretCommand { get { return JAFNIDLINKN_IssecrenCommandCrypted == 115; } set { JAFNIDLINKN_IssecrenCommandCrypted = (sbyte)(value ? 115 : 54); } }// 0xCE7D20 FLHPOBEBLBH 0xCE8E80 LIJEMJDBNPD
	}

	public class IMFNPKNPDDP
	{
		private int FBGGEFFJJHB; // 0x8
		private sbyte ALPDMEILILP_IsClearCrypted; // 0xC
		private int NBOLDNMPJFG_ScoreCrypted; // 0x10
		private sbyte NLKIOJKEKNM_IsUseCommandScoreCrypted; // 0x14
		private int KGNDGJAOFJG_HighScoreCrypted; // 0x18
		private sbyte MNOIODAMMCC_IsUseCommandHighScoreCrypted; // 0x1C

		public bool BCGLDMKODLC_IsClear { get { return ALPDMEILILP_IsClearCrypted == 89; } set { ALPDMEILILP_IsClearCrypted = (sbyte)(value ? 89 : 51); } } //0xCE7E0C NNGALFPBDNA 0xCE7DDC JJBMOHCMALD
		public int KNIFCANOHOC_Score { get { return NBOLDNMPJFG_ScoreCrypted ^ FBGGEFFJJHB; } set { NBOLDNMPJFG_ScoreCrypted = value ^ FBGGEFFJJHB; } } // 0xCE8DE4 EOJEPLIPOMJ 0xCE7D10 AEEMBPAEAAI
		public bool PIBCFBBLHBB_IsUseCommandScore { get { return NLKIOJKEKNM_IsUseCommandScoreCrypted == 89; } set { NLKIOJKEKNM_IsUseCommandScoreCrypted = (sbyte)(value ? 89 : 51); } } //0xCE8DF4 BLHCJKNODGF 0xCE7D34 ILCPMIBDKPB
		public int LGDLEHHOIEL_HighScore { get { return KGNDGJAOFJG_HighScoreCrypted ^ FBGGEFFJJHB; } set { KGNDGJAOFJG_HighScoreCrypted = value ^ FBGGEFFJJHB; } } //0xCE7DA4 OMFCCEBAODD 0xCE7D64 JGIJCMFGKEP
		public bool LNDLJBINJDE_IsUseCommandHighScore { get { return MNOIODAMMCC_IsUseCommandHighScoreCrypted == 89; } set { MNOIODAMMCC_IsUseCommandHighScoreCrypted = (sbyte)(value ? 89 : 51); } } //0xCE7DB4 HHNJLPDNDPN 0xCE7D74 CCOMADGCMEG

		// RVA: 0xCE1F20 Offset: 0xCE1F20 VA: 0xCE1F20
		public IMFNPKNPDDP()
		{
			FBGGEFFJJHB = (int)(Utility.GetCurrentUnixTime() ^ 0x346293);
			KNIFCANOHOC_Score = 0;
			BCGLDMKODLC_IsClear = false;
			LGDLEHHOIEL_HighScore = 0;
		}

		// RVA: 0xCE8E08 Offset: 0xCE8E08 VA: 0xCE8E08
		//private void KHEKNNFCAOI(int KNEFBLHBDBG) { }
	}

	private const int GHJHJDIDCFA = 3;
	private List<KCGOMAFPGDD_EventAprilFool.EIEGCBJHGCP> NFMDLCBJOIB = new List<KCGOMAFPGDD_EventAprilFool.EIEGCBJHGCP>(); // 0xE8
	private EECOJKDJIFG KBACNOCOANM; // 0xEC
	public IMFNPKNPDDP MMICFFPMHIC = new IMFNPKNPDDP(); // 0xF0

	public override OHCAABOMEOF.KGOGMKMBCPP_EventType HIDHLFCBIDE_EventType { get { return OHCAABOMEOF.KGOGMKMBCPP_EventType.DAMDPLEBNCB_AprilFool;} }// 0xCE1CB0 DKHCGLCNKCD  Slot: 4

	// // RVA: 0xCE1CB8 Offset: 0xCE1CB8 VA: 0xCE1CB8 Slot: 5
	// public override string IFKKBHPMALH() { }

	// RVA: 0xCE1E40 Offset: 0xCE1E40 VA: 0xCE1E40
	public AMLGMLNGMFB_EventAprilFool(string OPFGFINHFCE) : base(OPFGFINHFCE)
    {
        return;
    }

	// // RVA: 0xCE1FE0 Offset: 0xCE1FE0 VA: 0xCE1FE0
	private List<int> DAFEPLPDCJD(long JHNMKKNEENE)
	{
		List<int> l = new List<int>();
		l.Clear();
		for(int i = 0; i < AGLILDLEFDK.Count; i++)
		{
			if(AGLILDLEFDK[i].HMOJCCPIPBP_TargetMusicType == 6)
			{
				if(AGLILDLEFDK[i].HBJJCDIMOPO_TargetMusicConditionId > 0)
				{
					l.Add(AGLILDLEFDK[i].HBJJCDIMOPO_TargetMusicConditionId);
				}
			}
		}
		List<FKMOKDCJFEN> l2 = FKMOKDCJFEN.KJHKBBBDBAL(JOPOPMLFINI, true, -1);
		for(int i = 0; i < l2.Count; i++)
		{
			if(l2[i].DLAFBGPFEON > 0 && l2[i].CMCKNKKCNDK_Status == FKMOKDCJFEN.ADCPCCNCOMD_Status.HIDGJCIFFNJ/*1*/)
			{
				l.Remove(l2[i].DLAFBGPFEON);
			}
		}
		return l;
	}

	// // RVA: 0xCE224C Offset: 0xCE224C VA: 0xCE224C
	// public int BMBELGEDKEG(int PPFNGGCBJKC_Id) { }

	// // RVA: 0xCE24AC Offset: 0xCE24AC VA: 0xCE24AC
	public int GOHABONFBDM(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD)
	{
		List<KCGOMAFPGDD_EventAprilFool.EIEGCBJHGCP> l = LEAGIGKFMPE(false, OMNOFMEBLAD.NFFDIGEJHGL_ServerTime);
		MHDFCLCMDKO_Enemy.CJLENGHPIDH_EnemyInfo eInfo = Database.Instance.gameSetup.musicInfo.enemyInfo;
		for(int i = 0; i < l.Count; i++)
		{
			if(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId == l[i].MPLGPBNJDJB_FreeMusicId)
			{
				if (eInfo.NJOPIPNGANO_CS == l[i].MLKFDMFDFCE_EnemyCSkill && eInfo.EDLACELKJIK_LiveSkill == l[i].DKOPDNHDLIA_EnemyLSkill)
					return l[i].PPFNGGCBJKC_Id;
			}
		}
		return 0;
	}

	// // RVA: 0xCE266C Offset: 0xCE266C VA: 0xCE266C
	private List<KCGOMAFPGDD_EventAprilFool.EIEGCBJHGCP> LEAGIGKFMPE(bool DHNFPAGENLN, long JHNMKKNEENE = -1)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI);
		if (db != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = db as KCGOMAFPGDD_EventAprilFool;
			if (JHNMKKNEENE < 0)
				JHNMKKNEENE = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			List<int> l = null;
			if (!DHNFPAGENLN)
				l = DAFEPLPDCJD(JHNMKKNEENE);
			NFMDLCBJOIB.Clear();
			for(int i = 0; i < dbAf.IJJHFGOIDOK_Songs.Count; i++)
			{
				KCGOMAFPGDD_EventAprilFool.EIEGCBJHGCP MABBBOEAPAA = dbAf.IJJHFGOIDOK_Songs[i];
				if (MABBBOEAPAA.PLALNIIBLOF_Enabled == 2)
				{
					if (MABBBOEAPAA.MPLGPBNJDJB_FreeMusicId != 0)
					{
						if (l != null)
						{
							int idx = l.FindIndex((int GHPLINIACBB) =>
							{
								//0xCE7E20
								return MABBBOEAPAA.PPFNGGCBJKC_Id == GHPLINIACBB;
							});
							if (idx > -1)
								continue;
						}
						if(MABBBOEAPAA.PDBPFJJCADD_OpenAt != 0 || MABBBOEAPAA.FDBNFFNFOND_CloseAt != 0)
						{
							if(JHNMKKNEENE >= MABBBOEAPAA.PDBPFJJCADD_OpenAt)
							{
								if(MABBBOEAPAA.FDBNFFNFOND_CloseAt >= JHNMKKNEENE)
									NFMDLCBJOIB.Add(MABBBOEAPAA);
							}
						}
						else
						{
							NFMDLCBJOIB.Add(MABBBOEAPAA);
						}
					}
				}
			}
			return NFMDLCBJOIB;
		}
		return null;
	}

	// // RVA: 0xCE2BC4 Offset: 0xCE2BC4 VA: 0xCE2BC4
	public List<KCGOMAFPGDD_EventAprilFool.EIEGCBJHGCP> KOBMFPACBMB()
	{
		if(NFMDLCBJOIB.Count < 1)
		{
			return LEAGIGKFMPE(false, -1);
		}
		return NFMDLCBJOIB;
	}

	// // RVA: 0xCE2C68 Offset: 0xCE2C68 VA: 0xCE2C68
	public void BEFJOAGGAJD()
	{
		NFMDLCBJOIB.Clear();
	}

	// // RVA: 0xCE2CE0 Offset: 0xCE2CE0 VA: 0xCE2CE0 Slot: 7
	public override List<int> HEACCHAKMFG()
	{
		List<int> l = new List<int>();
		l.Clear();
		BEFJOAGGAJD();
		List<KCGOMAFPGDD_EventAprilFool.EIEGCBJHGCP> l2 = KOBMFPACBMB();
		if(l2 != null)
		{
			for(int i = 0; i < l2.Count; i++)
			{
				l.Add(l2[i].MPLGPBNJDJB_FreeMusicId);
			}
		}
		return l;
	}

	// // RVA: 0xCE2E54 Offset: 0xCE2E54 VA: 0xCE2E54 Slot: 9
	public override long HOOBCIIOCJD_GetEndTime(int GHBPLHBNMBK)
	{
		List<KCGOMAFPGDD_EventAprilFool.EIEGCBJHGCP> l = KOBMFPACBMB();
		if(l != null)
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			for(int i = 0; i < l.Count; i++)
			{
				if(l[i].PDBPFJJCADD_OpenAt != 0 && l[i].FDBNFFNFOND_CloseAt != 0 && time >= l[i].PDBPFJJCADD_OpenAt && l[i].FDBNFFNFOND_CloseAt >= time)
				{
					if(l[i].MPLGPBNJDJB_FreeMusicId == GHBPLHBNMBK)
					{
						return l[i].FDBNFFNFOND_CloseAt;
					}
				}
			}
		}
		return base.HOOBCIIOCJD_GetEndTime(GHBPLHBNMBK);
	}

	// // RVA: 0xCE3154 Offset: 0xCE3154 VA: 0xCE3154 Slot: 10
	public override bool GIDDKGMPIOK(int GHBPLHBNMBK)
	{
		List<KCGOMAFPGDD_EventAprilFool.EIEGCBJHGCP> l = KOBMFPACBMB();
		if (l != null)
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			for (int i = 0; i < l.Count; i++)
			{
				if (l[i].PDBPFJJCADD_OpenAt != 0 && l[i].FDBNFFNFOND_CloseAt != 0 && l[i].FDBNFFNFOND_CloseAt < DPJCPDKALGI_End1 && time >= l[i].PDBPFJJCADD_OpenAt && l[i].FDBNFFNFOND_CloseAt >= time)
				{
					if (l[i].MPLGPBNJDJB_FreeMusicId == GHBPLHBNMBK)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	// // RVA: 0xCE3474 Offset: 0xCE3474 VA: 0xCE3474 Slot: 28
	public override long FBGDBGKNKOD()
	{
		return 0;
	}

	// // RVA: 0xCE3480 Offset: 0xCE3480 VA: 0xCE3480 Slot: 30
	protected override bool JIHMLILFOPG_IsEventActive(long JHNMKKNEENE)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI);
		if(db != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = db as KCGOMAFPGDD_EventAprilFool;
			GDIPLANPCEI g = IMMAOANGPNK.HHCJCDFCLOB.ACEFBFLFKFD_GetScheduleEventData(dbAf.JIKKNHIAEKG_BlockName, JHNMKKNEENE);
			if(g != null)
			{
				if(JHNMKKNEENE >= dbAf.NGHKJOEDLIP.BONDDBOFBND_Start)
				{
					if (dbAf.NGHKJOEDLIP.KNLGKBBIBOH_End >= JHNMKKNEENE)
						return true;
				}
			}
		}
		return false;
	}

	// // RVA: 0xCE368C Offset: 0xCE368C VA: 0xCE368C Slot: 31
	protected override bool IMCMNOPNGHO(long JHNMKKNEENE)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI);
		if (db != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = db as KCGOMAFPGDD_EventAprilFool;
			FMFBNHLMHPL_EventAprilFool.LCFOEDLCCON save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.ILINBDKMAPM_EventAprilFool.FBCJICEPLED[dbAf.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			AGLILDLEFDK = dbAf.NNMPGOAGEOL_Missions;
			OLDFFDMPEBM = save.NNMPGOAGEOL;
			if (save.MPCAGEPEJJJ_Key != dbAf.NGHKJOEDLIP.OCGFKMHNEOF_Key || save.EGBOHDFBAPB_End < dbAf.NGHKJOEDLIP.BONDDBOFBND_Start)
			{
				save.LHPDDGIJKNB();
				save.MPCAGEPEJJJ_Key = dbAf.NGHKJOEDLIP.OCGFKMHNEOF_Key;
				save.LGADCGFMLLD_Step = 0;
				save.BEBJKJKBOGH_Date = JHNMKKNEENE;
				KOMAHOAEMEK(true);
				OAFLKGCGEOA(false);
			}
			KOMAHOAEMEK(false);
			return true;
		}
		return false;
	}

	// // RVA: 0xCE3B0C Offset: 0xCE3B0C VA: 0xCE3B0C Slot: 40
	protected override void KKFLDCBHFJA(long JHNMKKNEENE)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI);
		if (db != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = db as KCGOMAFPGDD_EventAprilFool;
			IBNKPMPFLGI = false;
			DGCOMDILAKM_EventName = dbAf.NGHKJOEDLIP.OPFGFINHFCE;
			DOLJEDAAKNN = dbAf.NGHKJOEDLIP.HEDAGCNPHGD;
			GLIMIGNNGGB_Start = dbAf.NGHKJOEDLIP.BONDDBOFBND_Start;
			DPJCPDKALGI_End1 = dbAf.NGHKJOEDLIP.HPNOGLIFJOP_End1;
			LOLAANGCGDO = dbAf.NGHKJOEDLIP.LNFKGHNHJKE;
			JDDFILGNGFH = dbAf.NGHKJOEDLIP.JGMDAOACOJF;
			LJOHLEGGGMC = dbAf.NGHKJOEDLIP.IDDBFFBPNGI;
			EMEKFFHCHMH_End = dbAf.NGHKJOEDLIP.KNLGKBBIBOH_End;
			PGIIDPEGGPI_EventId = dbAf.NGHKJOEDLIP.OBGBAOLONDD;
			FBHONHONKGD_MusicSelectDesc = MAICAKMIBEM("music_select_desc", "");
			GFIBLLLHMPD = 0;
			CAKEOPLJDAF = 0;
			LHAKGDAGEMM.Clear();
			MNDFBBMNJGN = false;
			LEPALMDKEOK = false;
			GPHEKCNDDIK = true;
			PJLNJJIBFBN = dbAf.NGHKJOEDLIP.AHKPNPNOAMO != 0;
			for(int i = 0; i < KPOMHFLKMKI.Length; i++)
			{
				KPOMHFLKMKI[i] = 0;
			}
		}
	}

	// // RVA: 0xCE3ED0 Offset: 0xCE3ED0 VA: 0xCE3ED0 Slot: 46
	protected override void PJDGDNJNCNM_UpdateStatusImpl(long JHNMKKNEENE)
	{
		NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD.HJNNKCMLGFL/*0*/;
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI);
		if (db != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = db as KCGOMAFPGDD_EventAprilFool;
			NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD.FFLKPBPBPEP/*1*/;
			if (JHNMKKNEENE >= GLIMIGNNGGB_Start)
			{
				NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD.MINDIGBAJFG/*3*/;
				if(DPJCPDKALGI_End1 < JHNMKKNEENE)
				{
					NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD.EMAMLLFAOJI/*6*/;
					if(JHNMKKNEENE >= dbAf.NGHKJOEDLIP.JGMDAOACOJF)
					{
						NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD.BCKENOKGLIJ/*9*/;
						if(JHNMKKNEENE >= dbAf.NGHKJOEDLIP.IDDBFFBPNGI)
						{
							NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD.DOAENCHBAEO/*11*/;
							if(JHNMKKNEENE < dbAf.NGHKJOEDLIP.KNLGKBBIBOH_End)
								NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD.HINPDNKNAHO/*10*/;
						}
					}
				}
			}
		}
	}

	// // RVA: 0xCE40BC Offset: 0xCE40BC VA: 0xCE40BC Slot: 27
	public override int HLOGNJNGDJO_GetHelpId(int OIPCCBHIKIA = 0)
	{
		NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD.HJNNKCMLGFL/*0*/;
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI);
		if (db != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = db as KCGOMAFPGDD_EventAprilFool;
			return dbAf.IHKIFGPICLG_HelpIds[OIPCCBHIKIA];
		}
		return 0;
	}

	// // RVA: 0xCE4258 Offset: 0xCE4258 VA: 0xCE4258 Slot: 70
	public override void ADACMHAHHKC(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		N.a.StartCoroutineWatched(NJIEIJJMAHK_Corotuine_PreSetupEventHome(BHFHGFKBOHH, AOCANKOMKFG));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BB91C Offset: 0x6BB91C VA: 0x6BB91C
	// // RVA: 0xCE42B0 Offset: 0xCE42B0 VA: 0xCE42B0
	private IEnumerator NJIEIJJMAHK_Corotuine_PreSetupEventHome(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		//0xCE8904
		while (CIOECGOMILE.HHCJCDFCLOB.KONHMOLMOCI)
			yield return null;
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI);
		if (db != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = db as KCGOMAFPGDD_EventAprilFool;
			PJDGDNJNCNM_UpdateStatusImpl(time);
			FMFBNHLMHPL_EventAprilFool.LCFOEDLCCON save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.ILINBDKMAPM_EventAprilFool.FBCJICEPLED[dbAf.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			if(!save.IMFBCJOIJKJ_Entry)
			{
				CMPEJEHCOEI = true;
				save.IMFBCJOIJKJ_Entry = true;
			}
			BHFHGFKBOHH();
			yield return null;
		}
		else
		{
			NPNNPNAIONN = true;
			PLOOEECNHFB = true;
			if (AOCANKOMKFG != null)
				AOCANKOMKFG();
		}
	}

	// // RVA: 0xCE4390 Offset: 0xCE4390 VA: 0xCE4390
	// private int APJDIPINLLK(List<int> HNLFPKNBOHE, int PPFNGGCBJKC_Id) { }

	// // RVA: 0xCE4488 Offset: 0xCE4488 VA: 0xCE4488 Slot: 33
	public override bool MPMKJNJGFEF()
	{
		return true;
	}

	// // RVA: 0xCE4490 Offset: 0xCE4490 VA: 0xCE4490 Slot: 69
	// public override void HAAEJDGMICH(LBNLAENLPNK.JEKODBEDOMM INDDJNMPONH, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0xCE45B8 Offset: 0xCE45B8 VA: 0xCE45B8 Slot: 71
	public override int BAEPGOAMBDK(string LJNAKDMILMC, int MNCOAGOKNAO)
	{
		NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD.HJNNKCMLGFL/*0*/;
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI);
		if (db != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = db as KCGOMAFPGDD_EventAprilFool;
			return dbAf.LPJLEHAJADA(LJNAKDMILMC, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0xCE4738 Offset: 0xCE4738 VA: 0xCE4738 Slot: 72
	public override string MAICAKMIBEM(string LJNAKDMILMC, string MNCOAGOKNAO)
	{
		DIHHCBACKGG_DbSection dbBlock = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI);
		if(dbBlock != null)
		{
			return (dbBlock as KCGOMAFPGDD_EventAprilFool).EFEGBHACJAL(LJNAKDMILMC, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0xCE48B8 Offset: 0xCE48B8 VA: 0xCE48B8 Slot: 38
	// public override void EMEPJNLHJHJ(int GJEADBKFAPA, int AKNELONELJK, bool GIKLNODJKFK, ref int APMGOLOPLFP, ref int FBBDNLAMPMH) { }

	// // RVA: 0xCE4B1C Offset: 0xCE4B1C VA: 0xCE4B1C Slot: 60
	public override bool PIBDBIKJKLD_CanPickup()
	{
		DIHHCBACKGG_DbSection dbBlock = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI);
		if (dbBlock != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = dbBlock as KCGOMAFPGDD_EventAprilFool;
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
			{
				return dbAf.LPJLEHAJADA("pickup_enable_rank", 6) <= CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KIECDDFNCAN_Level;
			}
		}
		return false;
	}

	// // RVA: 0xCE4D44 Offset: 0xCE4D44 VA: 0xCE4D44 Slot: 61
	public override bool EMNKNFNKPAD_SetIsPickup(bool JKDJCFEBDHC)
	{
		DIHHCBACKGG_DbSection dbBlock = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI);
		if (dbBlock != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = dbBlock as KCGOMAFPGDD_EventAprilFool;
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.ILINBDKMAPM_EventAprilFool.FBCJICEPLED[dbAf.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx].PPKAKKGCAOJ_IsPickup = JKDJCFEBDHC;
			return true;
		}
		return false;
	}

	// // RVA: 0xCE4FB0 Offset: 0xCE4FB0 VA: 0xCE4FB0 Slot: 62
	public override bool MPJIJMMOHDM_IsPickup()
	{
		DIHHCBACKGG_DbSection dbBlock = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI);
		if (dbBlock != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = dbBlock as KCGOMAFPGDD_EventAprilFool;
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.ILINBDKMAPM_EventAprilFool.FBCJICEPLED[dbAf.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx].PPKAKKGCAOJ_IsPickup;
		}
		return false;
	}

	// // RVA: 0xCE520C Offset: 0xCE520C VA: 0xCE520C Slot: 64
	public override int IBFAJICMLGF_GetJacketRibbonType()
	{
		return BAEPGOAMBDK("jacket_ribbon_type", 0);
	}

	// // RVA: 0xCE5280 Offset: 0xCE5280 VA: 0xCE5280
	public int HLPEBPOPCPI_GetChangeMusicSelectUI()
	{
		return BAEPGOAMBDK("change_music_select_ui", 0);
	}

	// // RVA: 0xCE52F4 Offset: 0xCE52F4 VA: 0xCE52F4 Slot: 26
	public override bool KKFEDJNIAAG(long JHNMKKNEENE)
	{
		NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD.HJNNKCMLGFL/*0*/;
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI);
		if (db != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = db as KCGOMAFPGDD_EventAprilFool;
			if(dbAf.NGHKJOEDLIP.OILIKPOBBGD == 1)
			{
				if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.ILINBDKMAPM_EventAprilFool.FBCJICEPLED[dbAf.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx].CFKFIODHFNC_Act < 2)
					return false;
			}
		}
		return base.KKFEDJNIAAG(JHNMKKNEENE);
	}

	// // RVA: 0xCE5598 Offset: 0xCE5598 VA: 0xCE5598
	public void LEGMNFOCKGE(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		N.a.StartCoroutineWatched(JCEFGGHMAGK_Co_ReceiveActivateItem(BHFHGFKBOHH, AOCANKOMKFG));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BB994 Offset: 0x6BB994 VA: 0x6BB994
	// // RVA: 0xCE55F0 Offset: 0xCE55F0 VA: 0xCE55F0
	private IEnumerator JCEFGGHMAGK_Co_ReceiveActivateItem(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		FMFBNHLMHPL_EventAprilFool.LCFOEDLCCON NGHLIKFIIGI_SaveData; // 0x1C
		string HPHKCOMJELK; // 0x20
		int HLGAPELJDPA; // 0x24
		List<GJDFHLBONOL> CJHGIMICABA; // 0x28
		SakashoInventoryCriteria KGJIJEKKFDB; // 0x2C
		LGJOOFGOGCD_RequestInventories NMBJNEPMHOO; // 0x30

		//0xCE7F00
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI);
		if (db != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = db as KCGOMAFPGDD_EventAprilFool;
			if(dbAf.NGHKJOEDLIP.OILIKPOBBGD == 1)
			{
				NGHLIKFIIGI_SaveData = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.ILINBDKMAPM_EventAprilFool.FBCJICEPLED[dbAf.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
				if(NGHLIKFIIGI_SaveData.CFKFIODHFNC_Act == 0)
				{
					HPHKCOMJELK = dbAf.EFEGBHACJAL("activate_item_name", "");
					HLGAPELJDPA = dbAf.LPJLEHAJADA("activate_item_value", 0);
					CJHGIMICABA = new List<GJDFHLBONOL>();
					KGJIJEKKFDB = new SakashoInventoryCriteria();
					KGJIJEKKFDB.OnlyUnreceived = true;
					int page = 1;
					while(true)
					{
						NMBJNEPMHOO = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new LGJOOFGOGCD_RequestInventories());
						NMBJNEPMHOO.IGNIIEBMFIN_Page = page;
						NMBJNEPMHOO.MLPLGFLKKLI_Ipp = 30;
						NMBJNEPMHOO.IPKCADIAAPG_Criteria = KGJIJEKKFDB;
						while (!NMBJNEPMHOO.PLOOEECNHFB_IsDone)
							yield return null;
						if(NMBJNEPMHOO.NPNNPNAIONN_IsError)
						{
							AOCANKOMKFG();
							yield break;
						}
						for(int i = 0; i < NMBJNEPMHOO.NFEAMMJIMPG_ResultData.PJJFEAHIPGL.Count; i++)
						{
							if(NMBJNEPMHOO.NFEAMMJIMPG_ResultData.PJJFEAHIPGL[i].HAAJGNCFNJM_ItemName == HPHKCOMJELK)
							{
								if(NMBJNEPMHOO.NFEAMMJIMPG_ResultData.PJJFEAHIPGL[i].OCNINMIMHGC_ItemValue == HLGAPELJDPA)
								{
									CJHGIMICABA.Add(NMBJNEPMHOO.NFEAMMJIMPG_ResultData.PJJFEAHIPGL[i]);
								}
							}
						}
						if (NMBJNEPMHOO.NFEAMMJIMPG_ResultData.MDIBIIHAAPN_NextPage == 0)
							break;
						page = NMBJNEPMHOO.NFEAMMJIMPG_ResultData.MDIBIIHAAPN_NextPage;
					}
					if(CJHGIMICABA.Count != 0)
					{
						NGHLIKFIIGI_SaveData.CFKFIODHFNC_Act = 2;
						List<long> l = new List<long>();
						for(int i = 0; i < CJHGIMICABA.Count; i++)
						{
							l.Add(CJHGIMICABA[i].MDPJFPHOPCH_Id);
						}
						CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(BHFHGFKBOHH, AOCANKOMKFG, l);
						yield break;
					}
					NGHLIKFIIGI_SaveData.CFKFIODHFNC_Act = 1;
				}
			}
		}
		BHFHGFKBOHH();
	}

	// // RVA: 0xCE56D0 Offset: 0xCE56D0 VA: 0xCE56D0
	public List<CEBFFLDKAEC_SecureInt> LANDONNJDEA()
	{
		NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD.HJNNKCMLGFL/*0*/;
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI);
		if (db != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = db as KCGOMAFPGDD_EventAprilFool;
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.ILINBDKMAPM_EventAprilFool.FBCJICEPLED[dbAf.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx].AAJOOBMPOEP;
		}
		return null;
	}

	// // RVA: 0xCE5928 Offset: 0xCE5928 VA: 0xCE5928
	public void ALEPIOKNOCL()
	{
		List<CEBFFLDKAEC_SecureInt> l = LANDONNJDEA();
		l[0].DNJEJEANJGL_Value = 0;
	}

	// // RVA: 0xCE39F0 Offset: 0xCE39F0 VA: 0xCE39F0
	public void OAFLKGCGEOA(bool NLNNKIKIPBJ)
	{
		GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.AAFEFCNONGL_StepUpQuest.IAPNOPFIPAG_IsShowNextInfo = NLNNKIKIPBJ;
		GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
	}

	// // RVA: 0xCE59C0 Offset: 0xCE59C0 VA: 0xCE59C0 Slot: 21
	public override void CNPHACDBLMD(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD)
	{
		if(AGLILDLEFDK != null && OLDFFDMPEBM != null)
		{
			List<int> l = new List<int>();
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			bool b = false;
			if(time - GLIMIGNNGGB_Start > 0)
			{
				if(time - DPJCPDKALGI_End1 < 0)
				{
					b = true;
				}
			}
			int c = AGLILDLEFDK.Count;
			if (OLDFFDMPEBM.Count < c)
				c = OLDFFDMPEBM.Count;
			for(int i = 0; i < c; i++)
			{
				if(OLDFFDMPEBM[i].EALOBDHOCHP_Stat == 1)
				{
					if(GBNDFCEDNMG.EIJIGDCMJLB(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, AGLILDLEFDK[i], OMNOFMEBLAD, this, false))
					{
						BOHCAIIBPEJ(AGLILDLEFDK[i], OLDFFDMPEBM[i], OMNOFMEBLAD, this);
						if(b)
						{
							if(OLDFFDMPEBM[i].EALOBDHOCHP_Stat == 2)
							{
								if(AGLILDLEFDK[i].HMOJCCPIPBP_TargetMusicType == 6)
								{
									for(int j = 0; j < c; j++)
									{
										if(AGLILDLEFDK[j].PPEGAKEIEGM_Enabled == 2)
										{
											if(AGLILDLEFDK[j].HHIBBHFHENH_NextStepId == AGLILDLEFDK[i].PPFNGGCBJKC_Id)
											{
												l.Add(AGLILDLEFDK[j].PPFNGGCBJKC_Id);
											}
										}
									}
									if (l.Count == 0)
										l.Add(-1);
								}
							}
						}
					}
				}
			}
			if(l.Count > 0)
			{
				ALEPIOKNOCL();
				List<CEBFFLDKAEC_SecureInt> l2 = LANDONNJDEA();
				if(l2 != null)
				{
					int m = Mathf.Min(l2.Count, l.Count);
					for(int i = 0; i < m; i++)
					{
						l2[i].DNJEJEANJGL_Value = l[i];
					}
				}
				OAFLKGCGEOA(true);
			}
		}
	}

	// // RVA: 0xCE6138 Offset: 0xCE6138 VA: 0xCE6138
	// public List<AMLGMLNGMFB.FOFMLBPMIIC> KLJKKJLFPDF() { }

	// // RVA: 0xCE68E8 Offset: 0xCE68E8 VA: 0xCE68E8
	public OLDLIIKHDKD PBPJDMGEMAO(long JHNMKKNEENE)
	{
		DIHHCBACKGG_DbSection dbSection = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI);
		if (dbSection != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = dbSection as KCGOMAFPGDD_EventAprilFool;
			if(dbAf.NGHKJOEDLIP.AMCPINEGNPG == 1 && AGLILDLEFDK != null)
			{
				if(JHNMKKNEENE < dbAf.NGHKJOEDLIP.HPNOGLIFJOP_End1)
				{
					FMFBNHLMHPL_EventAprilFool.LCFOEDLCCON save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.ILINBDKMAPM_EventAprilFool.FBCJICEPLED[dbAf.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
					if(save.CFKFIODHFNC_Act > 1)
					{
						int c = AGLILDLEFDK.Count;
						if (OLDFFDMPEBM.Count < c)
							c = OLDFFDMPEBM.Count;
						int a = 0;
						int d = 0;
						for(int i = 0; i < c; i++)
						{
							if(OLDFFDMPEBM[i].EALOBDHOCHP_Stat > 0)
							{
								if(AGLILDLEFDK[i].HDAMBOOCIAA_ClearType != dbAf.NGHKJOEDLIP.OFGDLGBFOOA)
								{
									a++;
									if (OLDFFDMPEBM[i].EALOBDHOCHP_Stat > 2)
										c++;
								}
							}
						}
						OLDLIIKHDKD data = new OLDLIIKHDKD(dbAf.NGHKJOEDLIP.HBACKHIOIBG, dbAf.NGHKJOEDLIP.BMKDEHFGHFG, a, c);
						return data;
					}
				}
			}
		}
		return null;
	}

	// // RVA: 0xCE6E64 Offset: 0xCE6E64 VA: 0xCE6E64
	public FMFBNHLMHPL_EventAprilFool.LCFOEDLCCON NDNDIAFEBFJ()
	{
		DIHHCBACKGG_DbSection dbSection = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI);
		if (dbSection != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = dbSection as KCGOMAFPGDD_EventAprilFool;
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.ILINBDKMAPM_EventAprilFool.FBCJICEPLED[dbAf.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
		}
		return null;
	}

	// // RVA: 0xCE70A8 Offset: 0xCE70A8 VA: 0xCE70A8 Slot: 73
	public override List<string> IJCPBPFEGDM(long JHNMKKNEENE)
	{
		DIHHCBACKGG_DbSection dbSection = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI);
		if(dbSection != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = dbSection as KCGOMAFPGDD_EventAprilFool;
			if(NDIILFIFCDL_GetMinigameId() > 0)
			{
				if(MNNNLDFNNCD(JHNMKKNEENE))
				{
					List<int> l = HEACCHAKMFG();
					if(l.Count > 0)
					{
						KEODKEGFDLD_FreeMusicInfo fm = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(l[0]);
						return SoundResource.CreateBgmFilePathList(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fm.DLAEJOBELBH_MusicId).KKPAHLMJKIH_WavId);
					}
				}
			}
		}
		return null;
	}

	// // RVA: 0xCE746C Offset: 0xCE746C VA: 0xCE746C Slot: 74
	public override int EDNMFMBLCGF_GetWavId()
	{
		List<int> l = HEACCHAKMFG();
		if (l.Count == 0)
			return 0;
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(l[0]).DLAEJOBELBH_MusicId).KKPAHLMJKIH_WavId;
	}

	// // RVA: 0xCE73F8 Offset: 0xCE73F8 VA: 0xCE73F8
	public int NDIILFIFCDL_GetMinigameId()
	{
		return BAEPGOAMBDK("mini_game_id", 0);
	}

	// // RVA: 0xCE7634 Offset: 0xCE7634 VA: 0xCE7634
	public void LPFLADBKPNL(JPGMKBANFGF OMNOFMEBLAD, bool IKGLAFOHGDO)
	{
		DIHHCBACKGG_DbSection dbSection = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI);
		if (dbSection != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = dbSection as KCGOMAFPGDD_EventAprilFool;
			FMFBNHLMHPL_EventAprilFool.LCFOEDLCCON save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.ILINBDKMAPM_EventAprilFool.FBCJICEPLED[dbAf.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			if(IKGLAFOHGDO)
			{
				FMFBNHLMHPL_EventAprilFool.LCFOEDLCCON data = new FMFBNHLMHPL_EventAprilFool.LCFOEDLCCON();
				data.LHPDDGIJKNB();
				data.ODDIHGPONFL(save);
				save = data;
			}
			ILDKBCLAFPB.AKKDKBOBKGH_AprilFool.OEAIOIHGMIH localSave = GameManager.Instance.localSave.EPJOACOONAC_GetSave().ICFDECCGKIL_AprilFool.MNKOCOODFKH_MiniGameShooting;
			if (IKGLAFOHGDO)
			{
				ILDKBCLAFPB.AKKDKBOBKGH_AprilFool.OEAIOIHGMIH data = new ILDKBCLAFPB.AKKDKBOBKGH_AprilFool.OEAIOIHGMIH();
				data.ODDIHGPONFL(localSave);
				localSave = data;
			}
			MMICFFPMHIC.KNIFCANOHOC_Score = OMNOFMEBLAD.KNIFCANOHOC_Score;
			MMICFFPMHIC.PIBCFBBLHBB_IsUseCommandScore = OMNOFMEBLAD.CHPIFIEEEEC_IsSecretCommand;
			if(localSave.LJKLECGFIEN_GetHighScore() < OMNOFMEBLAD.KNIFCANOHOC_Score)
			{
				MMICFFPMHIC.LGDLEHHOIEL_HighScore = OMNOFMEBLAD.KNIFCANOHOC_Score;
				MMICFFPMHIC.LNDLJBINJDE_IsUseCommandHighScore = OMNOFMEBLAD.CHPIFIEEEEC_IsSecretCommand;
			}
			else
			{
				MMICFFPMHIC.LGDLEHHOIEL_HighScore = localSave.LJKLECGFIEN_GetHighScore();
				MMICFFPMHIC.LNDLJBINJDE_IsUseCommandHighScore = localSave.PFBGBGLGBLA_GetIsUseCommand();
			}
			localSave.BIEBAEDGDIA_SetHighScore(MMICFFPMHIC.LGDLEHHOIEL_HighScore);
			localSave.JBCCMOKKCPA_SetIsUseCommand(MMICFFPMHIC.LNDLJBINJDE_IsUseCommandHighScore);
			MMICFFPMHIC.BCGLDMKODLC_IsClear = OMNOFMEBLAD.BCGLDMKODLC_IsClear;
			if(!save.KBAHNBKMFDL_IsMinigameClear)
			{
				save.KBAHNBKMFDL_IsMinigameClear = MMICFFPMHIC.BCGLDMKODLC_IsClear;
			}
			else
			{
				save.KBAHNBKMFDL_IsMinigameClear = true;
			}
			if(!IKGLAFOHGDO)
			{
				if (MMICFFPMHIC.BCGLDMKODLC_IsClear)
					HEFIKPAHCIA(GBNDFCEDNMG.CJDGJFINBFH.JNPNFMCPJJN/*49*/);
				GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
			}
		}
	}
}
