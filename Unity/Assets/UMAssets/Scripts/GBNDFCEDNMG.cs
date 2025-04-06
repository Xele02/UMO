
using System.Collections.Generic;
using XeApp.Game.Common;

public class GBNDFCEDNMG
{

    public enum IPGHCHBMMII
    {
        HJNNKCMLGFL = 0,
        HIFIGCJNJDO = 1,
        LMGPFIBKECF = 2,
        MJOJFOFGCKJ = 3,
        EEAMJNCBLJA = 4,
        DLPIILJLCOL = 5,
        PDAILHHMPOA = 6,
    }

    public enum KCMJJNMEPDK
    {
        HJNNKCMLGFL = 0,
        JHMIMFOCHJP = 1,
        CCAPCGPIIPF = 2,
        KGLPGOOBPDF = 3,
        NENEKKPKCCN = 4,
        KBOKNLKMGAE = 5,
    }

    public enum FLFNOJCEBOI
    {
        HJNNKCMLGFL = 0,
        NAFALPHEMKB = 1,
        LCLMLKPGKBJ = 2,
        GPKIDHFPFKP = 3,
        IAOAMNDGFCM = 4,
        FOCGMJJEMOJ = 5,
        DKDJOMMBODG = 6,
        OCACGNJEGPD = 7,
        EJMNFKNOJKN = 8,
        NGFNJOOOIDB = 9,
        CINJPAPDNGC = 10,
        IGBDBJHOICE = 11,
        KFDCEEMPJJE = 12,
        MIGOEDMJFCH = 13,
    }

    public enum CJDGJFINBFH
    {
        HJNNKCMLGFL = 0,
        JCHLONCMPAJ = 1,
        JKADCABEELM = 2,
        KHCOOPDAGOE = 3,
        KEILBOLBDHN = 4,
        ONBNGGDFAJK = 5,
        GEJCJDEMCMK = 6,
        BPGCMBDNPBE = 7,
        BMBKDNBPMAH = 8,
        OBBKKNLLLEN = 9,
        NKPDHENIBIA = 10,
        GJPAALJHLHN = 11,
        JPOGBMJKPIJ = 12,
        FHOEKNNOLCK = 13,
        BGMDGMELPHJ = 14,
        IELDCHLKEHG = 15,
        JIFAFBPHACI = 16,
        JEMNFEKLHOA = 17,
        KNPBBPNJNEM = 18,
        ADCDEIPMKJI = 19,
        DCFBLGLFJDO = 20,
        HKMENCLLHJB = 21,
        ABHINADBMOE = 22,
        KAMDLPNNGCG = 23,
        HFMIOBKCKHD = 24,
        NJKNOEPAELH = 25,
        POHBAGJLOLI = 26,
        EBCMMPMCHIK = 27,
        BEKIJHOCDFE = 28,
        APIDIDMAKHL = 29,
        OOGEAGAJKAG = 30,
        PMMOLBAAHEM_31 = 31,
        JLFJCIOOABC_32 = 32,
        CHIIAHIJFCB = 33,
        DMNIOHMDJEI = 34,
        KMHJDFJHMEP = 35,
        EKKMNHIKGKF = 36,
        PCPDPJAMPBP = 37,
        FDIEEMDFMGO = 38,
        ABFDKJGHHPG = 39,
        LJGBOEOMJHK = 40,
        EKBKFCOCKPJ_41 = 41,
        NCABFNABDFI_42 = 42,
        DIMCIJDJLGK_43 = 43,
        GNNHECOPEID = 44,
        GHLDBIHKCOK = 45,
        MBOFBJKDJFA = 46,
        BIJEBKHNHDP = 47,
        ICFDOFMJJND = 48,
        JNPNFMCPJJN = 49,
    }

	public static OHCAABOMEOF.KGOGMKMBCPP_EventType[] JIMACAGJJKP = new OHCAABOMEOF.KGOGMKMBCPP_EventType[2] { /*7*/OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp, /*8*/OHCAABOMEOF.KGOGMKMBCPP_EventType.OCCGDMDBCHK_EventGacha }; // 0x0

	// // RVA: 0x16A2D88 Offset: 0x16A2D88 VA: 0x16A2D88
	public static bool LLNJFONIECK(OHCAABOMEOF.KGOGMKMBCPP_EventType HIDHLFCBIDE)
	{
		for(int i = 0; i < JIMACAGJJKP.Length; i++)
		{
			if (JIMACAGJJKP[i] == HIDHLFCBIDE)
				return true;
		}
		return false;
	}

	// // RVA: 0x16A2ED0 Offset: 0x16A2ED0 VA: 0x16A2ED0
	public static bool EIJIGDCMJLB(OKGLGHCBCJP_Database LKMHPJKIFDN, BBHNACPENDM_ServerSaveData LDEGEHAEALK, AKIIJBEJOEP NDFIEMPPMLF, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, IKDICBBFBMI_EventBase LIKDEHHKFEH, bool NPFECBGCJPG)
	{
		if(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId != 0)
		{
			if(NDFIEMPPMLF.PPEGAKEIEGM_Enabled == 2)
			{
				if(DINDNEELMOD_CheckDate(LKMHPJKIFDN, LDEGEHAEALK, NDFIEMPPMLF, OMNOFMEBLAD, LIKDEHHKFEH))
				{
					if(MEAJMANDEOL_CheckTargetMusic(LKMHPJKIFDN, LDEGEHAEALK, NDFIEMPPMLF, OMNOFMEBLAD, LIKDEHHKFEH))
					{
						if(PDPGLIBBCPJ_CheckDifficulty(NDFIEMPPMLF, OMNOFMEBLAD.AKNELONELJK_Difficulty, NPFECBGCJPG))
						{
							if(GCFIJFKDJBE_CheckTargetUnit(LKMHPJKIFDN, LDEGEHAEALK, NDFIEMPPMLF, OMNOFMEBLAD))
							{
								if(LBOCNEHCMLB(LKMHPJKIFDN, LDEGEHAEALK, NDFIEMPPMLF, OMNOFMEBLAD, LIKDEHHKFEH, 0, OMNOFMEBLAD.NFFDIGEJHGL_ServerTime))
								{
									if(NDFIEMPPMLF.OOLNFBFBONH > 0)
									{
										if (!LBOCNEHCMLB(LKMHPJKIFDN, LDEGEHAEALK, NDFIEMPPMLF, OMNOFMEBLAD, LIKDEHHKFEH, 1, OMNOFMEBLAD.NFFDIGEJHGL_ServerTime))
											return false;
									}
									if(LIKDEHHKFEH.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp)
									{
										if (LIKDEHHKFEH is KNKDBNFMAKF_EventSp)
										{
											return NDFIEMPPMLF.KGICDMIJGDF_Group == (LIKDEHHKFEH as KNKDBNFMAKF_EventSp).MEDEJHKNAFG(OMNOFMEBLAD.NFFDIGEJHGL_ServerTime);
										}
									}
									return true;
								}
							}
						}
					}
				}
			}
		}
		return false;
	}

	// // RVA: 0x16A7210 Offset: 0x16A7210 VA: 0x16A7210
	public static bool HANGCDOFING(OKGLGHCBCJP_Database LKMHPJKIFDN, BBHNACPENDM_ServerSaveData LDEGEHAEALK, AKIIJBEJOEP NDFIEMPPMLF, IKDICBBFBMI_EventBase LIKDEHHKFEH, CJDGJFINBFH HDAMBOOCIAA = 0)
	{
		if(NDFIEMPPMLF.PPEGAKEIEGM_Enabled == 2)
		{
			if(MHMCIHJIJEC(LKMHPJKIFDN, LDEGEHAEALK, NDFIEMPPMLF, null, LIKDEHHKFEH))
			{
				if (HDAMBOOCIAA != CJDGJFINBFH.HJNNKCMLGFL/*0*/ && NDFIEMPPMLF.HDAMBOOCIAA_ClearType != (int)HDAMBOOCIAA)
					return false;
				long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				if (LBOCNEHCMLB(LKMHPJKIFDN, LDEGEHAEALK, NDFIEMPPMLF, null, LIKDEHHKFEH, 0, time))
				{
					if(LIKDEHHKFEH.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp/*7*/)
					{
						return NDFIEMPPMLF.KGICDMIJGDF_Group == (LIKDEHHKFEH as KNKDBNFMAKF_EventSp).MEDEJHKNAFG(time);
					}
					return true;
				}
			}
		}
		return false;
	}

	// // RVA: 0x16A7670 Offset: 0x16A7670 VA: 0x16A7670
	public static bool DACHEKFEFNN(OKGLGHCBCJP_Database LKMHPJKIFDN, BBHNACPENDM_ServerSaveData LDEGEHAEALK, AKIIJBEJOEP NDFIEMPPMLF, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, IKDICBBFBMI_EventBase LIKDEHHKFEH, bool NPFECBGCJPG, CJDGJFINBFH HDAMBOOCIAA = 0)
	{
		if(OMNOFMEBLAD == null || OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId != 0)
		{
			if(NDFIEMPPMLF.PPEGAKEIEGM_Enabled == 2)
			{
				if(MHMCIHJIJEC(LKMHPJKIFDN, LDEGEHAEALK, NDFIEMPPMLF, OMNOFMEBLAD, LIKDEHHKFEH))
				{
					if(MEAJMANDEOL_CheckTargetMusic(LKMHPJKIFDN, LDEGEHAEALK, NDFIEMPPMLF, OMNOFMEBLAD, LIKDEHHKFEH))
					{
						if(OMNOFMEBLAD != null)
						{
							if (!PDPGLIBBCPJ_CheckDifficulty(NDFIEMPPMLF, OMNOFMEBLAD.AKNELONELJK_Difficulty, NPFECBGCJPG))
								return false;
						}
						if(GCFIJFKDJBE_CheckTargetUnit(LKMHPJKIFDN, LDEGEHAEALK, NDFIEMPPMLF, OMNOFMEBLAD))
						{
							if (HDAMBOOCIAA != CJDGJFINBFH.HJNNKCMLGFL/*0*/ && NDFIEMPPMLF.HDAMBOOCIAA_ClearType != (int)HDAMBOOCIAA)
								return false;
							long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
							if (LBOCNEHCMLB(LKMHPJKIFDN, LDEGEHAEALK, NDFIEMPPMLF, OMNOFMEBLAD, LIKDEHHKFEH, 0, time))
							{
								if(LIKDEHHKFEH.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp)
								{
									if(LIKDEHHKFEH is KNKDBNFMAKF_EventSp)
									{
										return (LIKDEHHKFEH as KNKDBNFMAKF_EventSp).MEDEJHKNAFG(time) == NDFIEMPPMLF.KGICDMIJGDF_Group;
									}
								}
								return true;
							}
						}
					}
				}
			}
		}
		return false;
	}

	// // RVA: 0x16A79F0 Offset: 0x16A79F0 VA: 0x16A79F0
	public static bool BBEKHCGKIAJ(AKIIJBEJOEP NDFIEMPPMLF, IKCGAJKCPFN NHLBKJCPLBL, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, IKDICBBFBMI_EventBase LIKDEHHKFEH)
	{
		if(NHLBKJCPLBL.EALOBDHOCHP_Stat != 1)
			return false;
		int target;
		if(NDFIEMPPMLF.HDAMBOOCIAA_ClearType == 13)
		{
			if(OMNOFMEBLAD != null)
			{
				NHLBKJCPLBL.HMFFHLPNMPH_Count += OMNOFMEBLAD.KNIFCANOHOC_Score;
			}
			target = NDFIEMPPMLF.JJECMJFDEEP_ClearConditionValue;
		}
		else
		{
			if(NDFIEMPPMLF.HDAMBOOCIAA_ClearType == 36)
			{
				if(LIKDEHHKFEH != null)
				{
					PKNOKJNLPOE_EventRaid d = LIKDEHHKFEH as PKNOKJNLPOE_EventRaid;
					if(d != null)
					{
						NHLBKJCPLBL.HMFFHLPNMPH_Count = d.NENNACLBKJJ + NHLBKJCPLBL.HMFFHLPNMPH_Count;
					}
				}
			}
			else
			{
				NHLBKJCPLBL.HMFFHLPNMPH_Count += 1;
			}
			target = NDFIEMPPMLF.GLDIGCJNOBO_ClearCount;
		}
		if(target <= NHLBKJCPLBL.HMFFHLPNMPH_Count)
		{
			NHLBKJCPLBL.EALOBDHOCHP_Stat = 2;
		}
		return true;
	}

	// // RVA: 0x16A7C78 Offset: 0x16A7C78 VA: 0x16A7C78
	public static bool MDBLPCIKHBJ(int EKANGPODCEP, int AIBFGKBACCB, AKIIJBEJOEP NDFIEMPPMLF, IKCGAJKCPFN NHLBKJCPLBL)
	{
		if(NHLBKJCPLBL.EALOBDHOCHP_Stat == 1)
		{
			if(NDFIEMPPMLF.HDAMBOOCIAA_ClearType != 13)
			{
				PBJPACKDIIB.IFCOFHAFMON p = new PBJPACKDIIB.IFCOFHAFMON();
				p.EKANGPODCEP_EId = EKANGPODCEP;
				p.AIBFGKBACCB_LId = AIBFGKBACCB;
				p.CMEJFJFOIIJ_QId = NDFIEMPPMLF.PPFNGGCBJKC_Id;
				p.FKPEAGGKNLC_Start = NDFIEMPPMLF.KJBGCLPMLCG_Start;
				p.KOMKKBDABJP_End = NDFIEMPPMLF.GJFPFFBAKGK_End;
				p.CGHNCPEKOCK_Dai = NDFIEMPPMLF.PPCFIHMDMLM;
				PBJPACKDIIB.Instance.CGJLFIGBHCG(p);
				return true;
			}
		}
		return false;
	}

	// // RVA: 0x16A7E48 Offset: 0x16A7E48 VA: 0x16A7E48
	// public static bool KMFPHOPBFEA(AKIIJBEJOEP NDFIEMPPMLF, IKCGAJKCPFN NHLBKJCPLBL, int HMFFHLPNMPH) { }

	// // RVA: 0x16A7F3C Offset: 0x16A7F3C VA: 0x16A7F3C
	// public static bool GLDHKNMLEIG(AKIIJBEJOEP NDFIEMPPMLF, OFNLIBDEIFA.AGFEALDEJOL NHLBKJCPLBL, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD) { }

	// // RVA: 0x16A8018 Offset: 0x16A8018 VA: 0x16A8018
	// public static void BBEKHCGKIAJ(AKIIJBEJOEP NDFIEMPPMLF, OFNLIBDEIFA.AGFEALDEJOL NHLBKJCPLBL, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD) { }

	// // RVA: 0x16A80C4 Offset: 0x16A80C4 VA: 0x16A80C4
	// public static int NKGDIBMNLNO(AKIIJBEJOEP NDFIEMPPMLF) { }

	// // RVA: 0x16A8100 Offset: 0x16A8100 VA: 0x16A8100
	// public static bool EGKODECGHNM(AKIIJBEJOEP NDFIEMPPMLF, OFNLIBDEIFA.AGFEALDEJOL NHLBKJCPLBL) { }

	// // RVA: 0x16A81D0 Offset: 0x16A81D0 VA: 0x16A81D0
	// private static bool PKNNAFJGBGD(long KJBGCLPMLCG, long GJFPFFBAKGK, long LPEKHFOMCAH) { }

	// // RVA: 0x16A7480 Offset: 0x16A7480 VA: 0x16A7480
	private static bool MHMCIHJIJEC(OKGLGHCBCJP_Database LKMHPJKIFDN, BBHNACPENDM_ServerSaveData LDEGEHAEALK, AKIIJBEJOEP NDFIEMPPMLF, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, IKDICBBFBMI_EventBase LIKDEHHKFEH)
	{
		if(LIKDEHHKFEH != null)
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			LIKDEHHKFEH.HCDGELDHFHB_UpdateStatus(time);
			if(LIKDEHHKFEH.NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EIFKDKFAHPH_7/*7*/)
			{
				if(NDFIEMPPMLF.KJBGCLPMLCG_Start != 0 || NDFIEMPPMLF.GJFPFFBAKGK_End != 0)
				{
					return time >= NDFIEMPPMLF.KJBGCLPMLCG_Start && time < NDFIEMPPMLF.GJFPFFBAKGK_End;
				}
				return true;
			}
		}
		return false;
	}

	// // RVA: 0x16A3224 Offset: 0x16A3224 VA: 0x16A3224
	private static bool DINDNEELMOD_CheckDate(OKGLGHCBCJP_Database LKMHPJKIFDN, BBHNACPENDM_ServerSaveData LDEGEHAEALK, AKIIJBEJOEP NDFIEMPPMLF, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, IKDICBBFBMI_EventBase LIKDEHHKFEH)
	{
		if(LIKDEHHKFEH != null)
		{
			if(LIKDEHHKFEH.LOLAANGCGDO >= OMNOFMEBLAD.NFFDIGEJHGL_ServerTime)
			{
				if(NDFIEMPPMLF.KJBGCLPMLCG_Start != 0 || NDFIEMPPMLF.GJFPFFBAKGK_End != 0)
				{
					return OMNOFMEBLAD.NFFDIGEJHGL_ServerTime >= NDFIEMPPMLF.KJBGCLPMLCG_Start && OMNOFMEBLAD.NFFDIGEJHGL_ServerTime < NDFIEMPPMLF.GJFPFFBAKGK_End;
				}
				return true;
			}
		}
		return false;
	}

	// // RVA: 0x16A336C Offset: 0x16A336C VA: 0x16A336C
	private static bool MEAJMANDEOL_CheckTargetMusic(OKGLGHCBCJP_Database LKMHPJKIFDN, BBHNACPENDM_ServerSaveData LDEGEHAEALK, AKIIJBEJOEP NDFIEMPPMLF, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, IKDICBBFBMI_EventBase LIKDEHHKFEH)
	{
		if (OMNOFMEBLAD == null)
			return false;
		KEODKEGFDLD_FreeMusicInfo fm = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId);
		EONOEHOKBEB_Music m = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fm.DLAEJOBELBH_MusicId);
		switch(NDFIEMPPMLF.HMOJCCPIPBP_TargetMusicType)
		{
			case 0:
				return true;
			case 1:
				return OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId == NDFIEMPPMLF.HBJJCDIMOPO_TargetMusicConditionId;
			case 2:
				return m.FKDCCLPGKDK_Ma == NDFIEMPPMLF.HBJJCDIMOPO_TargetMusicConditionId;
			case 3:
				return m.AIHCEGFANAM_SerieAttr == NDFIEMPPMLF.HBJJCDIMOPO_TargetMusicConditionId;
			case 4:
				if (LIKDEHHKFEH == null)
					return false;
				if(LLNJFONIECK(LIKDEHHKFEH.HIDHLFCBIDE_EventType))
				{
					LIKDEHHKFEH = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/, false);
					if (LIKDEHHKFEH == null)
						return false;
				}
				List<int> l = LIKDEHHKFEH.HEACCHAKMFG_GetMusicsList();
				if (l == null)
					return false;
				int idx = l.FindIndex((int GHPLINIACBB) =>
				{
					//0x16A8EF4
					return OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId == GHPLINIACBB;
				});
				return idx > -1;
			case 5:
				return m.DLAEJOBELBH_Id == NDFIEMPPMLF.HBJJCDIMOPO_TargetMusicConditionId;
			case 6:
				if (LIKDEHHKFEH == null)
					return false;
				if (LIKDEHHKFEH.HIDHLFCBIDE_EventType != OHCAABOMEOF.KGOGMKMBCPP_EventType.DAMDPLEBNCB_AprilFool)
					return false;
				AMLGMLNGMFB_EventAprilFool af = LIKDEHHKFEH as AMLGMLNGMFB_EventAprilFool;
				return af.GOHABONFBDM(OMNOFMEBLAD) == NDFIEMPPMLF.HBJJCDIMOPO_TargetMusicConditionId;
			default:
				return false;
		}
	}

	// // RVA: 0x16A38E0 Offset: 0x16A38E0 VA: 0x16A38E0
	private static bool PDPGLIBBCPJ_CheckDifficulty(AKIIJBEJOEP NDFIEMPPMLF, int AKNELONELJK, bool HCBMLNNKKLN)
	{
		switch(NDFIEMPPMLF.DGMIADAEGAI_TargetDifficultyType)
		{
			default:
				break;
			case 1:
				if (HCBMLNNKKLN)
					return AKNELONELJK == 0;
				return AKNELONELJK > -1;
			case 2:
				if (HCBMLNNKKLN)
					return AKNELONELJK == 1;
				return AKNELONELJK > 0;
			case 3:
				if (HCBMLNNKKLN)
					return AKNELONELJK == 2;
				return AKNELONELJK > 1;
			case 4:
				if (HCBMLNNKKLN)
					return AKNELONELJK == 3;
				return AKNELONELJK > 2;
			case 5:
				if (HCBMLNNKKLN)
					return AKNELONELJK == 4;
				return AKNELONELJK > 3;
		}
		return true;
	}

	// // RVA: 0x16A39F8 Offset: 0x16A39F8 VA: 0x16A39F8
	private static bool GCFIJFKDJBE_CheckTargetUnit(OKGLGHCBCJP_Database LKMHPJKIFDN, BBHNACPENDM_ServerSaveData LDEGEHAEALK, AKIIJBEJOEP NDFIEMPPMLF, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD)
	{
		CIFHILOJJFC defaultUnit = LDEGEHAEALK.MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault();
		List<MLIBEPGADJH_Scene.KKLDOOJBJMN> BLPGDHGACAJ = LKMHPJKIFDN.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList;
		switch(NDFIEMPPMLF.NAPODHGLKAJ_TargetUnitType)
		{
			case 1:
				return NDFIEMPPMLF.FAHLEOKHBGH_TargetUnitConditionValue <= defaultUnit.EIDAHHCEPPC_GetNumScenes();
			case 2:
				return defaultUnit.EIDAHHCEPPC_GetNumScenes() <= NDFIEMPPMLF.FAHLEOKHBGH_TargetUnitConditionValue;
			case 3:
				return NDFIEMPPMLF.FAHLEOKHBGH_TargetUnitConditionValue <= defaultUnit.CJJIHFDLNMJ_CountForEachDivaScene((int AHHJLDLAPAN, int BCCHOBPJJKE) =>
				{
					//0x16A8F28
					return (int)BLPGDHGACAJ[BCCHOBPJJKE - 1].AIHCEGFANAM_Serie == NDFIEMPPMLF.FHILEEHDDKN_TargetUnitConditionId;
				});
			case 4:
				return defaultUnit.CJJIHFDLNMJ_CountForEachDivaScene((int AHHJLDLAPAN, int BCCHOBPJJKE) =>
				{
					//0x16A8FFC
					return (int)BLPGDHGACAJ[BCCHOBPJJKE - 1].AIHCEGFANAM_Serie == NDFIEMPPMLF.FHILEEHDDKN_TargetUnitConditionId;
				}) <= NDFIEMPPMLF.FAHLEOKHBGH_TargetUnitConditionValue;
			case 5:
				return NDFIEMPPMLF.FAHLEOKHBGH_TargetUnitConditionValue <= defaultUnit.CJJIHFDLNMJ_CountForEachDivaScene((int AHHJLDLAPAN, int BCCHOBPJJKE) =>
				{
					//0x16A90D0
					return BLPGDHGACAJ[BCCHOBPJJKE - 1].KELFCMEOPPM_Ep == NDFIEMPPMLF.FHILEEHDDKN_TargetUnitConditionId;
				});
			case 6:
				return defaultUnit.CJJIHFDLNMJ_CountForEachDivaScene((int AHHJLDLAPAN, int BCCHOBPJJKE) =>
				{
					//0x16A91A4
					return BLPGDHGACAJ[BCCHOBPJJKE - 1].KELFCMEOPPM_Ep == NDFIEMPPMLF.FHILEEHDDKN_TargetUnitConditionId;
				}) <= NDFIEMPPMLF.FAHLEOKHBGH_TargetUnitConditionValue;
			case 7:
				return NDFIEMPPMLF.FAHLEOKHBGH_TargetUnitConditionValue <= defaultUnit.CJJIHFDLNMJ_CountForEachDivaScene((int AHHJLDLAPAN, int BCCHOBPJJKE) =>
				{
					//0x16A9278
					return (int)BLPGDHGACAJ[BCCHOBPJJKE - 1].AIHCEGFANAM_Serie == NDFIEMPPMLF.FHILEEHDDKN_TargetUnitConditionId;
				});
			case 8:
				return defaultUnit.CJJIHFDLNMJ_CountForEachDivaScene((int AHHJLDLAPAN, int BCCHOBPJJKE) =>
				{
					//0x16A934C
					return (int)BLPGDHGACAJ[BCCHOBPJJKE - 1].AIHCEGFANAM_Serie == NDFIEMPPMLF.FHILEEHDDKN_TargetUnitConditionId;
				}) <= NDFIEMPPMLF.FAHLEOKHBGH_TargetUnitConditionValue;
			case 9:
				bool res = true;
				for(int i = 0; i < OMNOFMEBLAD.HNHCIGMKPDC_DivaIds.Count; i++)
				{
					int a = (NDFIEMPPMLF.FAHLEOKHBGH_TargetUnitConditionValue >> ((i * 8) & 24)) & 0xff;
					if (a != 0)
					{
						res &= OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[i] == a - 1;
					}
				}
				return res;
			case 10:
				if (defaultUnit.FDBOPFEOENF_MainDivas[0].DIPKCALNIII_Id == 0)
					return false;
				if (defaultUnit.FDBOPFEOENF_MainDivas[0].EBDNICPAFLB_SSlot[0] != 0)
				{
					MLIBEPGADJH_Scene.KKLDOOJBJMN saveScene = BLPGDHGACAJ[defaultUnit.FDBOPFEOENF_MainDivas[0].EBDNICPAFLB_SSlot[0] - 1];
					int EMAGAIKNHDN = saveScene.EMAGAIKNHDN_CS;
					MMPBPOIFDAF_Scene.PMKOFEIONEG dbScene = LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA[defaultUnit.FDBOPFEOENF_MainDivas[0].EBDNICPAFLB_SSlot[0] - 1];
					if(dbScene.JPIPENJGGDD_Mlt < 2)
					{
						if (EMAGAIKNHDN == 0)
							return false;
					}
					else
					{
						EMAGAIKNHDN = saveScene.AEIBPIEIBFO_CS2;
						if(EMAGAIKNHDN == 0)
						{
							EMAGAIKNHDN = saveScene.EMAGAIKNHDN_CS;
							if (EMAGAIKNHDN == 0)
								return false;
						}
					}
					HBDCPGLAPHH skill = LKMHPJKIFDN.FOFADHAENKC_Skill.COLCPGFABLP_CenterSkills.Find((HBDCPGLAPHH GHPLINIACBB) =>
					{
						//0x16A9628
						return GHPLINIACBB.JBFLEDKDFCO_CId == EMAGAIKNHDN;
					});
					if (skill == null)
						return false;
					if(skill.HEKHODDJHAO_P1 > 0)
					{
						KFCIIMBBNCD k = LKMHPJKIFDN.FOFADHAENKC_Skill.PEPLECGHBFA_SceneEffectInfo[skill.HEKHODDJHAO_P1 - 1];
						if (NDFIEMPPMLF.FAHLEOKHBGH_TargetUnitConditionValue == k.INDDJNMPONH_ModifierType)
							return true;
					}
					if(skill.AKGNPLBDKLN_P2 > 0)
					{
						KFCIIMBBNCD k = LKMHPJKIFDN.FOFADHAENKC_Skill.PEPLECGHBFA_SceneEffectInfo[skill.AKGNPLBDKLN_P2 - 1];
						if (NDFIEMPPMLF.FAHLEOKHBGH_TargetUnitConditionValue == k.INDDJNMPONH_ModifierType)
							return true;
					}
				}
				return false;
			case 11:
				if (defaultUnit.FDBOPFEOENF_MainDivas[0].DIPKCALNIII_Id == 0)
					return false;
				if (defaultUnit.FDBOPFEOENF_MainDivas[0].EBDNICPAFLB_SSlot[0] != 0)
				{
					MLIBEPGADJH_Scene.KKLDOOJBJMN saveScene = BLPGDHGACAJ[defaultUnit.FDBOPFEOENF_MainDivas[0].EBDNICPAFLB_SSlot[0] - 1];
					int HGONFBDIBPM = saveScene.PBEPKDEEBBK_AS;
					MMPBPOIFDAF_Scene.PMKOFEIONEG dbScene = LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA[defaultUnit.FDBOPFEOENF_MainDivas[0].EBDNICPAFLB_SSlot[0] - 1];
					if(dbScene.JPIPENJGGDD_Mlt < 2)
					{
						if (HGONFBDIBPM == 0)
							return false;
					}
					else
					{
						HGONFBDIBPM = saveScene.ECKJJCGPOPN_AS2;
						if(HGONFBDIBPM == 0)
						{
							HGONFBDIBPM = saveScene.PBEPKDEEBBK_AS;
							if (HGONFBDIBPM == 0)
								return false;
						}
					}
					CDNKOFIELMK skill = LKMHPJKIFDN.FOFADHAENKC_Skill.PABCHCAAEAA_ActiveSkills.Find((CDNKOFIELMK GHPLINIACBB) =>
					{
						//0x16A9660
						return GHPLINIACBB.DDMENKOHCGM == HGONFBDIBPM;
					});
					if (skill == null)
						return false;
					for(int i = 0; i < skill.EGLDFPILJLG_BuffEffectType.Length; i++)
					{
						if (skill.EGLDFPILJLG_BuffEffectType[i] == NDFIEMPPMLF.FHILEEHDDKN_TargetUnitConditionId)
							return true;
					}
				}
				return false;
			default:
				return true;
			case 12:
				int v = 0;
				if(OMNOFMEBLAD != null && OMNOFMEBLAD.JBCKLEMCEBD_LiveSkillActivateCount != null)
				{
					for(int i = 0; i < defaultUnit.FDBOPFEOENF_MainDivas.Count; i++)
					{
						if(defaultUnit.FDBOPFEOENF_MainDivas[i].DIPKCALNIII_Id != 0)
						{
							for(int j = 0; j < defaultUnit.FDBOPFEOENF_MainDivas[i].EBDNICPAFLB_SSlot.Length; j++)
							{
								int a = defaultUnit.FDBOPFEOENF_MainDivas.Count * i * j;
								if(OMNOFMEBLAD.JBCKLEMCEBD_LiveSkillActivateCount[a] > 0)
								{
									PPGHMBNIAEC skill = LKMHPJKIFDN.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[defaultUnit.FDBOPFEOENF_MainDivas[i].EBDNICPAFLB_SSlot[j] - 1];
									bool b = false;
									for(int k = 0; k < skill.EGLDFPILJLG_SkillBuffEffect.Length; k++)
									{
										b |= skill.EGLDFPILJLG_SkillBuffEffect[k] == NDFIEMPPMLF.FHILEEHDDKN_TargetUnitConditionId;
									}
									if(b)
									{
										v += OMNOFMEBLAD.JBCKLEMCEBD_LiveSkillActivateCount[a];
									}
								}
							}
						}
					}
				}
				return NDFIEMPPMLF.FHILEEHDDKN_TargetUnitConditionId <= v;
			case 13:
				{
					int v1 = defaultUnit.CJJIHFDLNMJ_CountForEachDivaScene((int AHHJLDLAPAN, int BCCHOBPJJKE) =>
					{
						//0x16A9420
						return BLPGDHGACAJ[BCCHOBPJJKE - 1].AIHCEGFANAM_Serie == XeApp.Game.Common.SeriesAttr.Type.Delta;
					});
					int v2 = defaultUnit.CJJIHFDLNMJ_CountForEachDivaScene((int AHHJLDLAPAN, int BCCHOBPJJKE) =>
					{
						//0x16A94C8
						return BLPGDHGACAJ[BCCHOBPJJKE - 1].AIHCEGFANAM_Serie == XeApp.Game.Common.SeriesAttr.Type.Frontia;
					});
					int v3 = defaultUnit.CJJIHFDLNMJ_CountForEachDivaScene((int AHHJLDLAPAN, int BCCHOBPJJKE) =>
					{
						//0x16A9578
						return BLPGDHGACAJ[BCCHOBPJJKE - 1].AIHCEGFANAM_Serie == XeApp.Game.Common.SeriesAttr.Type.Seven;
					});
					if(NDFIEMPPMLF.FHILEEHDDKN_TargetUnitConditionId < v1)
					{
						if(NDFIEMPPMLF.FHILEEHDDKN_TargetUnitConditionId < v2)
						{
							return NDFIEMPPMLF.FHILEEHDDKN_TargetUnitConditionId < v3;
						}
					}
					return false;
				}
		}
	}

	// // RVA: 0x16A5134 Offset: 0x16A5134 VA: 0x16A5134
	private static bool LBOCNEHCMLB(OKGLGHCBCJP_Database LKMHPJKIFDN, BBHNACPENDM_ServerSaveData LDEGEHAEALK, AKIIJBEJOEP NDFIEMPPMLF, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, IKDICBBFBMI_EventBase LIKDEHHKFEH, int OIPCCBHIKIA, long LPEKHFOMCAH)
	{
		if (LKMHPJKIFDN == null || LDEGEHAEALK == null)
			return false;
		if (NDFIEMPPMLF == null || LIKDEHHKFEH == null)
			return false;
		int aa3 = NDFIEMPPMLF.GHCDDKIBJGK(OIPCCBHIKIA);
		int aa4 = NDFIEMPPMLF.KJFKPGABANO(OIPCCBHIKIA);
		switch(NDFIEMPPMLF.GONJEDOAPFJ(OIPCCBHIKIA))
		{
			case 18:
				{
					int cnt = 0;
					for(int i = 0; i < LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count; i++)
					{
						if(LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].CPGFPEDMDEH_Have > 0)
							cnt++;
						if(cnt >= aa3)
							return true;
					}
				}
				return false;
			case 19:
				return aa3 <= BJHFBOMILHG(NDFIEMPPMLF, LIKDEHHKFEH, LPEKHFOMCAH);
			case 20:
				{
					List<IKCGAJKCPFN> l = new List<IKCGAJKCPFN>();
					for(int i = 0; i < LIKDEHHKFEH.AGLILDLEFDK_Missions.Count; i++)
					{
						if((LIKDEHHKFEH.AGLILDLEFDK_Missions[i].KJBGCLPMLCG_Start == 0 && LIKDEHHKFEH.AGLILDLEFDK_Missions[i].GJFPFFBAKGK_End == 0) ||
						(LPEKHFOMCAH >= LIKDEHHKFEH.AGLILDLEFDK_Missions[i].KJBGCLPMLCG_Start && LPEKHFOMCAH < LIKDEHHKFEH.AGLILDLEFDK_Missions[i].GJFPFFBAKGK_End))
						{
							if(LIKDEHHKFEH.AGLILDLEFDK_Missions[i].GBJFNGCDKPM_Type == 2)
							{
								if(LIKDEHHKFEH.OLDFFDMPEBM_Quests[i].EALOBDHOCHP_Stat > 0)
								{
									l.Add(LIKDEHHKFEH.OLDFFDMPEBM_Quests[i]);
								}
							}
						}
					}
					for(int i = 0; i < l.Count; i++)
					{
						if(l[i].EALOBDHOCHP_Stat == 1)
						{
							if(l[i].PPFNGGCBJKC_Id != NDFIEMPPMLF.PPFNGGCBJKC_Id)
								return false;
						}
					}
					return true;
				}
			case 21:
				if(LIKDEHHKFEH.HIDHLFCBIDE_EventType != OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp)
					return false;
				TodoLogger.LogError(TodoLogger.EventSp_7, "Event SP");
				break;
			default:
				if(OMNOFMEBLAD == null)
					return false;
				if(NDFIEMPPMLF.HMOJCCPIPBP_TargetMusicType == 4)
				{
					List<int> l = LIKDEHHKFEH.HEACCHAKMFG_GetMusicsList();
					if(l != null && l.Count > 0)
					{
						if(!LLNJFONIECK(LIKDEHHKFEH.HIDHLFCBIDE_EventType) && OMNOFMEBLAD.OEILJHENAHN_PlayEventType != (int)LIKDEHHKFEH.HIDHLFCBIDE_EventType)
						{
							return false;
						}
					}
				}
				//LKMHPJKIFDN.IBPAFKKEKNK_Music
				break;
			case 26:
				if(LIKDEHHKFEH.HIDHLFCBIDE_EventType != OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp)
					return false;
				TodoLogger.LogError(TodoLogger.EventSp_7, "Event SP");
				break;
			case 27:
			case 28:
			case 34:
			case 36:
				if(OMNOFMEBLAD != null)
					return false;
				if(LIKDEHHKFEH.HIDHLFCBIDE_EventType != OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid)
					return false;
				TodoLogger.LogError(TodoLogger.EventRaid_11_13, "Event Raid");
				break;
			case 30:
			case 31:
			case 32:
			case 33:
			case 35:
				return OMNOFMEBLAD == null;
			case 41:
				if(OMNOFMEBLAD != null)
					return false;
				if(LIKDEHHKFEH.HIDHLFCBIDE_EventType != OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva)
					return false;
				{
					MANPIONIGNO_EventGoDiva ev = LIKDEHHKFEH as MANPIONIGNO_EventGoDiva;
					return (ev.CMCEGEKGEEP.MKMIEGPOKGG_Soul.CIEOBFIIPLD_AfterLevel - ev.CMCEGEKGEEP.MKMIEGPOKGG_Soul.KFEMFDFPCGO_BeforeLevel) > 0;
				}
			case 42:
				if(OMNOFMEBLAD != null)
					return false;
				if(LIKDEHHKFEH.HIDHLFCBIDE_EventType != OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva)
					return false;
				{
					MANPIONIGNO_EventGoDiva ev = LIKDEHHKFEH as MANPIONIGNO_EventGoDiva;
					return (ev.CMCEGEKGEEP.EACDINDLGLF_Voice.CIEOBFIIPLD_AfterLevel - ev.CMCEGEKGEEP.EACDINDLGLF_Voice.KFEMFDFPCGO_BeforeLevel) > 0;
				}
			case 43:
				if(OMNOFMEBLAD != null)
					return false;
				if(LIKDEHHKFEH.HIDHLFCBIDE_EventType != OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva)
					return false;
				{
					MANPIONIGNO_EventGoDiva ev = LIKDEHHKFEH as MANPIONIGNO_EventGoDiva;
					return (ev.CMCEGEKGEEP.LDLHPACIIAB_Charm.CIEOBFIIPLD_AfterLevel - ev.CMCEGEKGEEP.LDLHPACIIAB_Charm.KFEMFDFPCGO_BeforeLevel) > 0;
				}
			case 49:
				{
					if(OMNOFMEBLAD != null)
						return false;
					if(LIKDEHHKFEH.HIDHLFCBIDE_EventType != OHCAABOMEOF.KGOGMKMBCPP_EventType.DAMDPLEBNCB_AprilFool)
						return false;
					AMLGMLNGMFB_EventAprilFool evApril = LIKDEHHKFEH as AMLGMLNGMFB_EventAprilFool;
					return evApril.MMICFFPMHIC.BCGLDMKODLC_IsClear;
				}
		}
        KEODKEGFDLD_FreeMusicInfo fminfo = LKMHPJKIFDN.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId);
        switch (NDFIEMPPMLF.GONJEDOAPFJ(OIPCCBHIKIA))
		{
			case 0:
			case 1:
			case 13:
				return true;
			case 2:
				if(Database.Instance.gameSetup.EnableLiveSkip)
					return false;
				return aa3 <= OMNOFMEBLAD.NLKEBAOBJCM_MaxCombo;
			case 3:
				return aa3 <= fminfo.EMJCHPDJHEI(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6, OMNOFMEBLAD.AKNELONELJK_Difficulty).DLPBHJALHCK_GetScoreRank(OMNOFMEBLAD.KNIFCANOHOC_Score);
			case 4:
				return aa3 <= OMNOFMEBLAD.KNIFCANOHOC_Score;
			case 5:
				return aa3 <= OMNOFMEBLAD.JNNDFGPMEDA_EnergyLeft;
			case 6:
				return LIKDEHHKFEH.FBGDBGKNKOD_GetCurrentPoint() >= aa3;
			case 7:
				if(OMNOFMEBLAD.HGEKDNNJAAC_HadAwakenDivaMode)
					return true;
				return OMNOFMEBLAD.OOOGNIPJMDE_HadDivaMode;
			case 8:
				return OMNOFMEBLAD.HGEKDNNJAAC_HadAwakenDivaMode;
			case 9:
				{
					if(OMNOFMEBLAD.OJFNDOIFOOE_NoteResultCount == null)
						return false;
					int v = 0;
					for(int i = 0; i < OMNOFMEBLAD.OJFNDOIFOOE_NoteResultCount.Count; i++)
					{
						if(NDFIEMPPMLF.DEIEONIILLJ_ClearConditionId <= i)
						{
							v += OMNOFMEBLAD.OJFNDOIFOOE_NoteResultCount[i];
						}
					}
					return aa3 <= v;
				}
			case 10:
				{
					if(OMNOFMEBLAD.OJFNDOIFOOE_NoteResultCount == null)
						return false;
					int v = 0;
					for(int i = 0; i < OMNOFMEBLAD.OJFNDOIFOOE_NoteResultCount.Count; i++)
					{
						if(NDFIEMPPMLF.DEIEONIILLJ_ClearConditionId <= i)
						{
							v += OMNOFMEBLAD.OJFNDOIFOOE_NoteResultCount[i];
						}
					}
					return v <= aa3;
				}
			case 11:
				if(OMNOFMEBLAD.IPEKDLNEOFI_TeamLife == 0)
					return false;
				return aa3 <= OMNOFMEBLAD.JKPPKAHPPKH_LifeLeft * 100 / OMNOFMEBLAD.IPEKDLNEOFI_TeamLife;
			case 12:
				if(Database.Instance.gameSetup.EnableLiveSkip)
					return false;
				return OMNOFMEBLAD.LCOHGOIDMDF_ComboRank != 0;
			case 14:
				if(LIKDEHHKFEH.HIDHLFCBIDE_EventType != OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
					return false;
				{
					HAEDCCLHEMN_EventBattle ev = LIKDEHHKFEH as HAEDCCLHEMN_EventBattle;
					//LAB_016a6ab8
					return ev.CKCPAMDDNPF.DPCFADCFMOA_IsWin;
				}
			case 15:
				if(LIKDEHHKFEH.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
				{
					HAEDCCLHEMN_EventBattle ev = LIKDEHHKFEH as HAEDCCLHEMN_EventBattle;
					if(aa3 <= ev.CKCPAMDDNPF.PGNECHOCIAN_CWinMax)
						return true;
				}
				break;
			case 16:
				if(LIKDEHHKFEH.HIDHLFCBIDE_EventType != OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
					return false;
				if(aa3 < 1)
					return false;
				{
					HAEDCCLHEMN_EventBattle ev = LIKDEHHKFEH as HAEDCCLHEMN_EventBattle;
					if(ev.CKCPAMDDNPF.JIMGIIBCABI_ScoreResultRank != aa3 - 1)
						return false;
					//LAB_016a6ab8
					return ev.CKCPAMDDNPF.DPCFADCFMOA_IsWin;
				}
			case 17:
				if(LIKDEHHKFEH.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.NKDOEBONGNI_EventQuest)
				{
					TodoLogger.LogError(TodoLogger.EventQuest_6, "Event Quest");
				}
				break;
			case 22:
				if(Database.Instance.gameSetup.EnableLiveSkip)
					return false;
				return NDFIEMPPMLF.JJECMJFDEEP_ClearConditionValue <= fminfo.EMJCHPDJHEI(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6, OMNOFMEBLAD.AKNELONELJK_Difficulty).CCFAAPPKILD_GetRankCombo(OMNOFMEBLAD.NLKEBAOBJCM_MaxCombo);
			case 23:
				if(LIKDEHHKFEH.HIDHLFCBIDE_EventType != OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
					return false;
				{
					HAEDCCLHEMN_EventBattle ev = LIKDEHHKFEH as HAEDCCLHEMN_EventBattle;
					if(ev.KKMFHMGIIKN_GetCls() < aa4)
					{
						return false;
					}
					if(aa3 != 0)
					{
						if(ev.CKCPAMDDNPF.JIMGIIBCABI_ScoreResultRank != aa3 - 1)
							return false;
					}
					//LAB_016a6ab8
					return ev.CKCPAMDDNPF.DPCFADCFMOA_IsWin;
				}
			case 24:
				if(OMNOFMEBLAD.KNIFCANOHOC_Score == -1)
				{
					if(!OMNOFMEBLAD.OBOPMHBPCFE_MvMode)
						return aa4 != 1;
					else
						return aa4 != 0;
				}
				break;
			case 25:
				if(OMNOFMEBLAD.KNIFCANOHOC_Score == -1)
				{
					if(!OMNOFMEBLAD.OBOPMHBPCFE_MvMode)
					{
						if(aa4 == 1)
							return false;
					}
					else
					{
						if(aa4 == 0)
							return false;
					}
					for(int i = 0; i < OMNOFMEBLAD.HNHCIGMKPDC_DivaIds.Count; i++)
					{
						if(OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[i] > 0)
						{
                            DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo d = LDEGEHAEALK.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[i]);
                            LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.LBDOLHGDIEB_GetUnlockedCostumeOrDefault(OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[i], d.BEEAIAAJOHD_CostumeId);
							if(cos != null && cos.JPIDIENBGKH_CostumeId > 0 && cos.JPIDIENBGKH_CostumeId == aa3)
								return true;
                        }
					}
				}
				break;
			case 29:
				if(LIKDEHHKFEH.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid)
				{
					TodoLogger.LogError(TodoLogger.EventRaid_11_13, "Event raid");
				}
				break;
			case 37:
				return OMNOFMEBLAD.OEILJHENAHN_PlayEventType > 0;
			case 38:
				if(Database.Instance.gameSetup.EnableLiveSkip)
					return false;
				if(OMNOFMEBLAD.OEILJHENAHN_PlayEventType < 1)
					return false;
				return OMNOFMEBLAD.LCOHGOIDMDF_ComboRank != 0;
			case 39:
				if(OMNOFMEBLAD.OEILJHENAHN_PlayEventType < 1)
					return false;
				return aa3 <= fminfo.EMJCHPDJHEI(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6, OMNOFMEBLAD.AKNELONELJK_Difficulty).DLPBHJALHCK_GetScoreRank(OMNOFMEBLAD.KNIFCANOHOC_Score);
			case 40:
				if(OMNOFMEBLAD.OEILJHENAHN_PlayEventType < 1)
					return false;
				return aa3 <= OMNOFMEBLAD.KNIFCANOHOC_Score;
			case 44:
				if(LIKDEHHKFEH.HIDHLFCBIDE_EventType != OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva)
					return false;
				{
					MANPIONIGNO_EventGoDiva ev = LIKDEHHKFEH as MANPIONIGNO_EventGoDiva;
					return ev.CMCEGEKGEEP.JGBIFJLPCHM_IsBonusStart;
				}
			case 45:
				if(OMNOFMEBLAD.OEILJHENAHN_PlayEventType != (int)LIKDEHHKFEH.HIDHLFCBIDE_EventType)
					return false;
				return OMNOFMEBLAD.OEILJHENAHN_PlayEventType > 0;
			case 46:
				if(OMNOFMEBLAD.OEILJHENAHN_PlayEventType != (int)LIKDEHHKFEH.HIDHLFCBIDE_EventType)
					return false;
				if(Database.Instance.gameSetup.EnableLiveSkip)
					return false;
				if(OMNOFMEBLAD.OEILJHENAHN_PlayEventType < 1)
					return false;
				return OMNOFMEBLAD.LCOHGOIDMDF_ComboRank != 0;
			case 47:
				if(OMNOFMEBLAD.OEILJHENAHN_PlayEventType != (int)LIKDEHHKFEH.HIDHLFCBIDE_EventType)
					return false;
				if(OMNOFMEBLAD.OEILJHENAHN_PlayEventType < 1)
					return false;
				return aa3 <= fminfo.EMJCHPDJHEI(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6, OMNOFMEBLAD.AKNELONELJK_Difficulty).DLPBHJALHCK_GetScoreRank(OMNOFMEBLAD.KNIFCANOHOC_Score);
			case 48:
				if(OMNOFMEBLAD.OEILJHENAHN_PlayEventType != (int)LIKDEHHKFEH.HIDHLFCBIDE_EventType)
					return false;
				if(OMNOFMEBLAD.OEILJHENAHN_PlayEventType < 1)
					return false;
				return aa3 <= OMNOFMEBLAD.KNIFCANOHOC_Score;
		}
		return false;
	}

	// // RVA: 0x16A84F8 Offset: 0x16A84F8 VA: 0x16A84F8
	// private static bool EFIBGMJACOK(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD) { }

	// // RVA: 0x16A8528 Offset: 0x16A8528 VA: 0x16A8528
	// public static int GHAJJNPENFI(OKGLGHCBCJP LKMHPJKIFDN, BBHNACPENDM LDEGEHAEALK, AKIIJBEJOEP NDFIEMPPMLF, List<int> DBEHMKDDKHM) { }

	// // RVA: 0x16A8240 Offset: 0x16A8240 VA: 0x16A8240
	public static int BJHFBOMILHG(AKIIJBEJOEP NDFIEMPPMLF, IKDICBBFBMI_EventBase LIKDEHHKFEH, long LPEKHFOMCAH)
	{
		int a = 0;
		if(LIKDEHHKFEH.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp)
		{
			TodoLogger.LogError(TodoLogger.EventSp_7, "Event SP");
		}
		int a1 = 0;
		for(int i = 0; i < LIKDEHHKFEH.OLDFFDMPEBM_Quests.Count; i++)
		{
			if(LIKDEHHKFEH.OLDFFDMPEBM_Quests[i].EALOBDHOCHP_Stat > 1)
			{
				if(NDFIEMPPMLF.PPFNGGCBJKC_Id != LIKDEHHKFEH.OLDFFDMPEBM_Quests[i].PPFNGGCBJKC_Id)
				{
					if(i < LIKDEHHKFEH.AGLILDLEFDK_Missions.Count)
					{
						if(LIKDEHHKFEH.AGLILDLEFDK_Missions[i].KGICDMIJGDF_Group != a)
							continue;
					}
					a1++;
				}
			}
		}
		return a1;
	}

}
