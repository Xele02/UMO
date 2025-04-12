using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game;
using XeApp.Game.Common;
using XeApp.Game.Menu;

public class NHGEHCMPDAI
{
	public long DNBFMLBNAEE_CurrentPoint; // 0x8
	public int FJOLNJLLJEJ_Rank; // 0x10
	public List<MFDJIFIIPJD> HBHMAKNGKFK = new List<MFDJIFIIPJD>(); // 0x14
}

[System.Obsolete("Use IKDICBBFBMI_EventBase", true)]
public abstract class IKDICBBFBMI { }
public abstract class IKDICBBFBMI_EventBase
{
	public class NJJDBBCHBNP
	{
		public int GJEADBKFAPA; // 0x8
		public int IJKFFIKGLJM; // 0xC
		public int DCBMFNOIENM; // 0x10
	}

	public class MEBJJBHPMEO
	{
		public int PPFNGGCBJKC; // 0x8
		public int CNKFPJCGNFE; // 0xC
		public int GNFBMCGMCFO; // 0x10
		public int BFFGFAMJAIG; // 0x14
	}

	public class CEGDBNNIDIG
	{
		public int KELFCMEOPPM_EpId; // 0x8
		public float MIHNKIHNBBL; // 0xC
		public List<int> MLLPMJFOKEC = new List<int>(); // 0x10
	}

	public class GNPOABJANKO
	{
		public int KELFCMEOPPM_EpisodeId; // 0x8
		public bool JKDJCFEBDHC; // 0xC
		public int HEDODOBGPPM_BonusValue; // 0x10
	}

	public const int NLHCFCAPBFH = 10;
	public const int NFGBMPKFEGC = 999;
	public string JOPOPMLFINI_QuestId; // 0x8
	public KGCNCBOKCBA.GNENJEHKMHD_EventStatus NGOFCFJHOMI_Status; // 0xC
	public string DGCOMDILAKM_EventName; // 0x10
	public bool IBNKPMPFLGI_IsRankReward; // 0x14
	public bool LEPALMDKEOK_IsPointReward; // 0x15
	public string DOLJEDAAKNN; // 0x18
	public List<int> HGLAFGHHFKP; // 0x1C
	public string FBHONHONKGD_MusicSelectDesc; // 0x20
	public bool PJLNJJIBFBN; // 0x24
	public long GLIMIGNNGGB_Start; // 0x28
	public long DPJCPDKALGI_End1; // 0x30
	public long LOLAANGCGDO; // 0x38
	public long JDDFILGNGFH; // 0x40
	public long LJOHLEGGGMC; // 0x48
	public long EMEKFFHCHMH_End; // 0x50
	public bool IONOAFPLANN; // 0x58
	public int PGIIDPEGGPI_EventId; // 0x5C
	public int PBHNFNIHDJJ; // 0x60
	public int NHGPCLGPEHH_TicketType; // 0x64
	public List<int> BHAHKCMJAJE; // 0x68
	public bool MNDFBBMNJGN_IsUsingTicket; // 0x6C
	public int JKIADEKHGLC_TicketItemId; // 0x70
	public List<IHAEIOAKEMG> PFPJHJJAGAG_Rewards = new List<IHAEIOAKEMG>(50); // 0x74
	public List<MAOCCKFAOPC>[] EGIPGHCDMII_RankData = new List<MAOCCKFAOPC>[10] {
		new List<MAOCCKFAOPC>(20),
		new List<MAOCCKFAOPC>(20),
		new List<MAOCCKFAOPC>(20),
		new List<MAOCCKFAOPC>(20),
		new List<MAOCCKFAOPC>(20),
		new List<MAOCCKFAOPC>(20),
		new List<MAOCCKFAOPC>(20),
		new List<MAOCCKFAOPC>(20),
		new List<MAOCCKFAOPC>(20),
		new List<MAOCCKFAOPC>(20)
	}; // 0x78
	public List<int> JOFBHHHLBBN = new List<int>(); // 0x7C
	public NHGEHCMPDAI HLFHJIDHJMP; // 0x80
	public JKNGJFOBADP JANMJPOKLFL = new JKNGJFOBADP(); // 0x84
	public List<AKIIJBEJOEP> AGLILDLEFDK_Missions; // 0x88
	public List<IKCGAJKCPFN> OLDFFDMPEBM_Quests; // 0x8C
	private int HAJJBEFHPKG; // 0x90
	private bool OEHCGLGNNPD; // 0x94
	protected bool CMEOKJMCEBH; // 0x95
	public int GFIBLLLHMPD_StartAdventureId; // 0x98
	public int CAKEOPLJDAF_EndAdventureId; // 0x9C
	public bool FKKDIDMGLMI; // 0xA0
	public bool PLOOEECNHFB; // 0xA1
	public bool GPHEKCNDDIK; // 0xA2
	public bool NPNNPNAIONN; // 0xA3
	public long EJDJIBPKKNO; // 0xA8
	public int[] CDINKAANIAA_Rank = new int[10]; // 0xB0
	public long[] KPOMHFLKMKI_LastRankUpdateTime = new long[10]; // 0xB4
	public List<string> PMHLJAIGBGK; // 0xB8
	public List<int> FMEDFGOMNBK; // 0xBC
	public List<CEGDBNNIDIG> LHAKGDAGEMM = new List<CEGDBNNIDIG>(); // 0xC0
	public List<NJJDBBCHBNP> PGDAMNENGDA = new List<NJJDBBCHBNP>(); // 0xC4
	public List<MEBJJBHPMEO> DHOMAEOEFMJ = new List<MEBJJBHPMEO>(); // 0xC8
	public bool CMPEJEHCOEI; // 0xCC
	public bool LPFJADHHLHG; // 0xCD
	public bool CBPOMDFDKPD; // 0xCE
	public MFDJIFIIPJD BHABCGJCGNO; // 0xD0
	public List<MFDJIFIIPJD> KGBCKPKLKHM_RewardItems = new List<MFDJIFIIPJD>(); // 0xD4
	public List<AIGOEAPJGEB> MBHDIJJEOFL; // 0xD8
	public int HADLPHIMBHH_BoostRatio = 1; // 0xDC
	public bool IBLPKJJNNIG; // 0xE0
	public bool BELBNINIOIE; // 0xE1
	protected bool GFHKFKHBIGM; // 0xE2
	protected bool OIMGJLOLPHK; // 0xE3
	public int OGPMLMDPGJA; // 0xE4
	public static string HOEKCEJINNA = "new_episode_mver"; // 0x0
	public static string FOKNMOMNHHD = "new_episode_help_pict_id"; // 0x4
	public const string IKCKAAKLNPL = "main_ranking_index";
	public const string HNBFGNJGNDP = "event_prologue_achv_key";
	public const string ELJKLANPBIF = "event_epilogue_achv_key";
	public const string PKCHABKLDOC = "event_prologue_achv_item_id";
	public const string HMEFMAPKOBF = "event_epilogue_achv_item_id";

	public virtual OHCAABOMEOF.KGOGMKMBCPP_EventType HIDHLFCBIDE_EventType { get { return OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0; } } //0x8DD514 DKHCGLCNKCD Slot: 4
	// public int OENLHLCKMDI { get; } // ?
	// public bool NBCFEEFEDHH { get; } // ?
	// public bool BEGOPNADOJL { get; } // ?
	// public bool JHPNNEOLHGH { get; } // ?
	// public bool DLPIPAGONIN { get; } // ?

	// // RVA: 0x8DCDBC Offset: 0x8DCDBC VA: 0x8DCDBC
	public IKDICBBFBMI_EventBase(string OPFGFINHFCE)
	{
		JOPOPMLFINI_QuestId = OPFGFINHFCE;
	}

	// // RVA: 0x8DD51C Offset: 0x8DD51C VA: 0x8DD51C Slot: 5
	public virtual string IFKKBHPMALH()
	{
		return null;
	}

	// // RVA: 0x8DD524 Offset: 0x8DD524 VA: 0x8DD524 Slot: 6
	public virtual string DCODGEOEDPG()
	{ 
		return null;
	}

	// // RVA: 0x8DD52C Offset: 0x8DD52C VA: 0x8DD52C Slot: 7
	public virtual List<int> HEACCHAKMFG_GetMusicsList()
	{
		return null;
	}

	// // RVA: 0x8DD534 Offset: 0x8DD534 VA: 0x8DD534 Slot: 8
	public virtual int OMJHBJPCFFC_GetEventBonusPercent(int EHDDADDKMFI)
	{
		return 0;
	}

	// // RVA: 0x8DD53C Offset: 0x8DD53C VA: 0x8DD53C Slot: 9
	public virtual long HOOBCIIOCJD_GetSongEndTime(int GHBPLHBNMBK)
	{
		return DPJCPDKALGI_End1;
	}

	// // RVA: 0x8DD544 Offset: 0x8DD544 VA: 0x8DD544 Slot: 10
	public virtual bool GIDDKGMPIOK_IsLimited(int GHBPLHBNMBK)
	{
		return false;
	}

	// // RVA: 0x8DD54C Offset: 0x8DD54C VA: 0x8DD54C Slot: 11
	public virtual int AELBIEDNPGB_GetTicketCount(BBHNACPENDM_ServerSaveData LDEGEHAEALK)
	{
		return 0;
	}

	// // RVA: 0x8DD554 Offset: 0x8DD554 VA: 0x8DD554 Slot: 12
	public virtual int EAMODCHMCEL(int AKNELONELJK, bool GIKLNODJKFK)
	{
		return 0;
	}

	// // RVA: 0x8DD55C Offset: 0x8DD55C VA: 0x8DD55C Slot: 13
	public virtual bool NLFIGGNLEFP(int AKNELONELJK, bool GIKLNODJKFK, int LCCGDFGGIHI)
	{
		return false;
	}

	// // RVA: 0x8DD564 Offset: 0x8DD564 VA: 0x8DD564 Slot: 14
	public virtual void HPENJEOAMBK_SetTicket(int JKIADEKHGLC, int HMFFHLPNMPH, BBHNACPENDM_ServerSaveData AHEFHIMGIBI)
	{
		return;
	}

	// // RVA: 0x8DD568 Offset: 0x8DD568 VA: 0x8DD568
	public List<EJFIKLONGDD> MGEIBMIGILL()
	{
		return EJFIKLONGDD.FKDIMODKKJD(PFPJHJJAGAG_Rewards, MAICAKMIBEM("total_reward_feature_option", ""));
	}

	// // RVA: 0x8DD5F8 Offset: 0x8DD5F8 VA: 0x8DD5F8
	// protected void CNGIENBEHID() { }

	// // RVA: 0x8DD660 Offset: 0x8DD660 VA: 0x8DD660 Slot: 15
	protected virtual int KFNINHEJCLF()
	{
		return 0;
	}

	// // RVA: 0x8DD668 Offset: 0x8DD668 VA: 0x8DD668 Slot: 16
	protected virtual bool FHKCEPMCGCK()
	{
		return true;
	}

	// // RVA: 0x8DD670 Offset: 0x8DD670 VA: 0x8DD670
	protected void KOMAHOAEMEK(bool JMPLGBCLGOF = true)
	{
		if(AGLILDLEFDK_Missions != null && OLDFFDMPEBM_Quests != null)
		{
			HAJJBEFHPKG = IOBGPMINKFI(AGLILDLEFDK_Missions, OLDFFDMPEBM_Quests);
			int count = AGLILDLEFDK_Missions.Count;
			if (OLDFFDMPEBM_Quests.Count < AGLILDLEFDK_Missions.Count)
				count = OLDFFDMPEBM_Quests.Count;
			for (int i = 0; i < count; i++)
			{
				if(JMPLGBCLGOF)
				{
					if(AGLILDLEFDK_Missions[i].PPEGAKEIEGM_Enabled == 2)
					{
						OLDFFDMPEBM_Quests[i].EALOBDHOCHP_Stat = 1;
						OLDFFDMPEBM_Quests[i].HMFFHLPNMPH_Count = 0;
					}
					else
					{
						OLDFFDMPEBM_Quests[i].EALOBDHOCHP_Stat = 0;
						OLDFFDMPEBM_Quests[i].HMFFHLPNMPH_Count = 0;
					}
					OLDFFDMPEBM_Quests[i].BEBJKJKBOGH_Date = 0;
				}
				else
				{
					if(OLDFFDMPEBM_Quests[i].HMFFHLPNMPH_Count == 0)
					{
						if(OLDFFDMPEBM_Quests[i].BEBJKJKBOGH_Date == 0)
						{
							if(AGLILDLEFDK_Missions[i].PPEGAKEIEGM_Enabled == 2)
							{
								if(OLDFFDMPEBM_Quests[i].EALOBDHOCHP_Stat == 0)
								{
									OLDFFDMPEBM_Quests[i].EALOBDHOCHP_Stat = 1;
								}
							}
							else
							{
								if(OLDFFDMPEBM_Quests[i].EALOBDHOCHP_Stat < 2)
								{
									OLDFFDMPEBM_Quests[i].EALOBDHOCHP_Stat = 0;
								}
							}
						}
					}
				}
			}
		}
	}

	// // RVA: 0x8DE17C Offset: 0x8DE17C VA: 0x8DE17C Slot: 17
	public virtual int GBADILEHLGC_GetStatus(int CMEJFJFOIIJ)
	{
		if(CMEJFJFOIIJ != 0)
		{
			if(AGLILDLEFDK_Missions != null && OLDFFDMPEBM_Quests != null && AGLILDLEFDK_Missions.Count >= CMEJFJFOIIJ && OLDFFDMPEBM_Quests.Count >= CMEJFJFOIIJ)
			{
				return OLDFFDMPEBM_Quests[CMEJFJFOIIJ - 1].EALOBDHOCHP_Stat;
			}
		}
		return 0;
	}

	// // RVA: 0x8DE290 Offset: 0x8DE290 VA: 0x8DE290 Slot: 18
	public virtual int GMFLMIHJAHB(int CMEJFJFOIIJ)
	{
		if(CMEJFJFOIIJ != 0)
		{
			if(AGLILDLEFDK_Missions != null && OLDFFDMPEBM_Quests != null && CMEJFJFOIIJ <= AGLILDLEFDK_Missions.Count && CMEJFJFOIIJ <= OLDFFDMPEBM_Quests.Count)
			{
				return OLDFFDMPEBM_Quests[CMEJFJFOIIJ - 1].HMFFHLPNMPH_Count;
			}
		}
		return 0;
	}

	// // RVA: 0x8DE3A4 Offset: 0x8DE3A4 VA: 0x8DE3A4
	public void BOHCAIIBPEJ(AKIIJBEJOEP NDFIEMPPMLF, IKCGAJKCPFN NHLBKJCPLBL, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, IKDICBBFBMI_EventBase LIKDEHHKFEH)
	{
		if(!OEHCGLGNNPD)
		{
			GBNDFCEDNMG.BBEKHCGKIAJ(NDFIEMPPMLF, NHLBKJCPLBL, OMNOFMEBLAD, LIKDEHHKFEH);
		}
		else
		{
			if(FHKCEPMCGCK())
			{
				GBNDFCEDNMG.MDBLPCIKHBJ(PGIIDPEGGPI_EventId, KFNINHEJCLF(), NDFIEMPPMLF, NHLBKJCPLBL);
			}
		}
	}

	// // RVA: 0x8DE4E0 Offset: 0x8DE4E0 VA: 0x8DE4E0 Slot: 19
	public virtual void HEFIKPAHCIA(GBNDFCEDNMG.CJDGJFINBFH HDAMBOOCIAA)
    {
        if(AGLILDLEFDK_Missions != null && OLDFFDMPEBM_Quests != null && NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6/*6*/)
		{
			int c = AGLILDLEFDK_Missions.Count;
			if (OLDFFDMPEBM_Quests.Count < c)
				c = OLDFFDMPEBM_Quests.Count;
			for(int i = 0; i < c; i++)
			{
				if(OLDFFDMPEBM_Quests[i].EALOBDHOCHP_Stat == 1)
				{
					if (GBNDFCEDNMG.HANGCDOFING(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, AGLILDLEFDK_Missions[i], this, HDAMBOOCIAA))
					{
						BOHCAIIBPEJ(AGLILDLEFDK_Missions[i], OLDFFDMPEBM_Quests[i], null, this);
					}
				}
			}
		}
    }

	// // RVA: 0x8DE830 Offset: 0x8DE830 VA: 0x8DE830 Slot: 20
	public virtual void EBHPADDEJKH(JGEOBNENMAH.EDHCNKBMLGI OMNOFMEBLAD, GBNDFCEDNMG.CJDGJFINBFH HDAMBOOCIAA)
	{
		if(AGLILDLEFDK_Missions != null && OLDFFDMPEBM_Quests != null && OMNOFMEBLAD != null)
		{
			int c = AGLILDLEFDK_Missions.Count;
			if (OLDFFDMPEBM_Quests.Count < c)
				c = OLDFFDMPEBM_Quests.Count;
			JGEOBNENMAH.HAJIFNABIFF data = new JGEOBNENMAH.HAJIFNABIFF();
			data.KNIFCANOHOC_Score = -1;
			data.GHBPLHBNMBK_FreeMusicId = OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId;
			data.AKNELONELJK_Difficulty = OMNOFMEBLAD.AKNELONELJK_Difficulty;
			data.LFGNLKKFOCD_IsLine6 = OMNOFMEBLAD.LFGNLKKFOCD_IsLine6;
			data.MNNHHJBBICA_GameEventType = OMNOFMEBLAD.MNNHHJBBICA_GameEventType;
			data.OEILJHENAHN_PlayEventType = OMNOFMEBLAD.OEILJHENAHN_PlayEventType;
			data.OBOPMHBPCFE_MvMode = OMNOFMEBLAD.OBOPMHBPCFE_MvMode;
			data.HNHCIGMKPDC_DivaIds = new List<int>(5);
			for(int i = 0; i < Database.Instance.gameSetup.teamInfo.divaList.Length; i++)
			{
				data.HNHCIGMKPDC_DivaIds.Add(Database.Instance.gameSetup.teamInfo.divaList[i].divaId);
			}
			data.NFFDIGEJHGL_ServerTime = JGEOBNENMAH.HHCJCDFCLOB.GJIICCJMDIF_GetServerTime();
			for(int i = 0; i < c; i++)
			{
				if(OLDFFDMPEBM_Quests[i].EALOBDHOCHP_Stat == 1)
				{
					if(GBNDFCEDNMG.DACHEKFEFNN(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, AGLILDLEFDK_Missions[i], data, this, false, HDAMBOOCIAA))
					{
						BOHCAIIBPEJ(AGLILDLEFDK_Missions[i], OLDFFDMPEBM_Quests[i], null, this);
					}
				}
			}
		}
	}

	// // RVA: 0x8DEE04 Offset: 0x8DEE04 VA: 0x8DEE04 Slot: 21
	public virtual void CNPHACDBLMD(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD)
	{
		if(AGLILDLEFDK_Missions != null && OLDFFDMPEBM_Quests != null && OMNOFMEBLAD != null)
		{
			int c = AGLILDLEFDK_Missions.Count;
			if (OLDFFDMPEBM_Quests.Count < c)
				c = OLDFFDMPEBM_Quests.Count;
			for(int i = 0; i < c; i++)
			{
				if(OLDFFDMPEBM_Quests[i].EALOBDHOCHP_Stat == 1)
				{
					if(GBNDFCEDNMG.EIJIGDCMJLB(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, AGLILDLEFDK_Missions[i], OMNOFMEBLAD, this, false))
					{
						BOHCAIIBPEJ(AGLILDLEFDK_Missions[i], OLDFFDMPEBM_Quests[i], OMNOFMEBLAD, this);
					}
				}
			}
		}
	}

	// // RVA: 0x8DF144 Offset: 0x8DF144 VA: 0x8DF144 Slot: 22
	public virtual void FHGEJBKNBLP(List<int> CGCFENMHJIM)
	{
		if(AGLILDLEFDK_Missions != null && OLDFFDMPEBM_Quests != null)
		{
			int cnt = AGLILDLEFDK_Missions.Count;
			if(OLDFFDMPEBM_Quests.Count < cnt)
				cnt = OLDFFDMPEBM_Quests.Count;
			for(int i = 0; i < CGCFENMHJIM.Count; i++)
			{
				if(OLDFFDMPEBM_Quests[CGCFENMHJIM[i] - 1].EALOBDHOCHP_Stat == 2)
				{
					OLDFFDMPEBM_Quests[CGCFENMHJIM[i] - 1].JIOMCDGKIAF = 1;
				}
			}
		}
	}

	// // RVA: 0x8DDBB0 Offset: 0x8DDBB0 VA: 0x8DDBB0
	private int IOBGPMINKFI(List<AKIIJBEJOEP> NJEKJBDJKLH, List<IKCGAJKCPFN> KLGILMKOHOI)
	{
		int res = 0;
		if(CIOECGOMILE.HHCJCDFCLOB != null)
		{
			for(int i = 0; i < 8; i++)
			{
				string s = MAICAKMIBEM(i == 0 ? "replace_quest_if_have_item" : string.Format("replace_quest_if_have_item_{0}", i), "");
				if (s.Length < 1)
					return res;
				if (s.Contains(","))
				{
					string[] strs = s.Split(new char[] { ',' });
					if ((strs.Length & 3) != 0)
						return res;
					for(int j = 0; j < strs.Length; j+=4)
					{
						int itemId = int.Parse(strs[j]);
						int b = int.Parse(strs[j + 1]);
						int c = int.Parse(strs[j + 2]);
						int d = int.Parse(strs[j + 3]);
						if (itemId < 1)
							break;
						int e = c;
						if (c > 0)
							e = d;
						if (e < 1)
							break;
						if(KLGILMKOHOI[c - 1].EALOBDHOCHP_Stat < 2)
						{
							if(KLGILMKOHOI[d - 1].EALOBDHOCHP_Stat < 2)
							{
								EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(itemId);
								int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(itemId);
								int num = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(null, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, cat, id, null);
								NJEKJBDJKLH[c].PPEGAKEIEGM_Enabled = 2;
								NJEKJBDJKLH[d].PPEGAKEIEGM_Enabled = 0;
								if (num < b)
								{
									NJEKJBDJKLH[c].PPEGAKEIEGM_Enabled = 0;
									NJEKJBDJKLH[d].PPEGAKEIEGM_Enabled = 2;
								}
								else
									res |= 1 << i;
							}
							else
							{
								NJEKJBDJKLH[c].PPEGAKEIEGM_Enabled = 0;
								NJEKJBDJKLH[d].PPEGAKEIEGM_Enabled = 2;
							}
						}
						else
						{
							NJEKJBDJKLH[c].PPEGAKEIEGM_Enabled = 2;
							NJEKJBDJKLH[d].PPEGAKEIEGM_Enabled = 0;
						}
					}
				}
			}
		}
		return res;
	}

	// // RVA: 0x8DF400 Offset: 0x8DF400 VA: 0x8DF400 Slot: 23
	// public virtual void CFIINCJGBJB(bool OAFPGJLCNFM, int AHGHKCGLFBG) { }

	// // RVA: 0x8DF428 Offset: 0x8DF428 VA: 0x8DF428 Slot: 24
	// public virtual bool NCGDLDGCIFM(int AHGHKCGLFBG) { }

	// // RVA: 0x8DF444 Offset: 0x8DF444 VA: 0x8DF444 Slot: 25
	// public virtual void KMCAIFKIFHM(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0x8DF69C Offset: 0x8DF69C VA: 0x8DF69C Slot: 26
	public virtual bool KKFEDJNIAAG(long JHNMKKNEENE)
	{
		if (JHNMKKNEENE < GLIMIGNNGGB_Start)
			return false;
		return LJOHLEGGGMC >= JHNMKKNEENE;
	}

	// // RVA: 0x8DF6D4 Offset: 0x8DF6D4 VA: 0x8DF6D4
	// public int CHHHPIDCDMH() { }

	// // RVA: 0x8DF6E8 Offset: 0x8DF6E8 VA: 0x8DF6E8 Slot: 27
	public virtual int HLOGNJNGDJO_GetHelpId(int OIPCCBHIKIA = 0)
	{
		return 0;
	}

	// // RVA: -1 Offset: -1 Slot: 28
	public abstract long FBGDBGKNKOD_GetCurrentPoint();

	// // RVA: 0x8DF6F0 Offset: 0x8DF6F0 VA: 0x8DF6F0
	public void ADFLCMBBNHH()
	{
		EJDJIBPKKNO = FBGDBGKNKOD_GetCurrentPoint();
	}

	// // RVA: 0x8DF718 Offset: 0x8DF718 VA: 0x8DF718 Slot: 29
	public virtual void MJFKJHJJLMN_GetRanks(int LHJCOPMMIGO = 0, bool FBBNPFFEJBN = false)
	{
		NPNNPNAIONN = false;
		PLOOEECNHFB = true;
		CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
	}

	// // RVA: -1 Offset: -1 Slot: 30
	protected abstract bool JIHMLILFOPG_IsEventActive(long JHNMKKNEENE);

	// // RVA: -1 Offset: -1 Slot: 31
	protected abstract bool IMCMNOPNGHO(long JHNMKKNEENE);

	// // RVA: 0x8DF774 Offset: 0x8DF774 VA: 0x8DF774 Slot: 32
	public virtual EECOJKDJIFG DAKMIKNKHMF_GetRankingInfoForIndex(int LHJCOPMMIGO)
	{
		return null;
	}

	// // RVA: 0x8DF77C Offset: 0x8DF77C VA: 0x8DF77C Slot: 33
	public virtual bool MPMKJNJGFEF_IsEntry()
	{
		return false;
	}

	// // RVA: 0x8DF784 Offset: 0x8DF784 VA: 0x8DF784 Slot: 34
	public virtual int JDFHIHPPAHN_UpdateDropItemSet(int NHIJBNLJGDJ, OHCAABOMEOF.KGOGMKMBCPP_EventType INDDJNMPONH)
	{
		return NHIJBNLJGDJ;
	}

	// // RVA: 0x8DF78C Offset: 0x8DF78C VA: 0x8DF78C Slot: 35
	public virtual int NCHKBINKKBH_UpdateDropRateSet(int BFOLFCOBBJD, OHCAABOMEOF.KGOGMKMBCPP_EventType INDDJNMPONH)
	{
		return BFOLFCOBBJD;
	}

	// // RVA: 0x8DF794 Offset: 0x8DF794 VA: 0x8DF794 Slot: 36
	public virtual int EEMGDCPJNEG(int JEAHDIOLGEL, OHCAABOMEOF.KGOGMKMBCPP_EventType INDDJNMPONH)
	{
		return JEAHDIOLGEL;
	}

	// // RVA: 0x8DF79C Offset: 0x8DF79C VA: 0x8DF79C Slot: 37
	public virtual int DJHOMGLGAHA(int PLLAIBDLKHB, OHCAABOMEOF.KGOGMKMBCPP_EventType INDDJNMPONH)
	{
		return PLLAIBDLKHB;
	}

	// // RVA: 0x8DF7A4 Offset: 0x8DF7A4 VA: 0x8DF7A4 Slot: 38
	public virtual void EMEPJNLHJHJ(int GJEADBKFAPA, int AKNELONELJK, bool GIKLNODJKFK, ref int APMGOLOPLFP, ref int FBBDNLAMPMH)
	{
		APMGOLOPLFP = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.JJIBDCAIBIO_LuckCoef0;
		FBBDNLAMPMH = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.AMNBEMCJCHF_LuckCoef1;
	}

	// // RVA: 0x8DF8B8 Offset: 0x8DF8B8 VA: 0x8DF8B8
	public bool GHKKPKBBEAN(long JHNMKKNEENE)
	{
		return ENBOJGJCPCP(JHNMKKNEENE);
	}

	// // RVA: 0x8DF8E0 Offset: 0x8DF8E0 VA: 0x8DF8E0 Slot: 39
	protected virtual bool ENBOJGJCPCP(long JHNMKKNEENE)
	{
		if(JIHMLILFOPG_IsEventActive(JHNMKKNEENE))
		{
			return IMCMNOPNGHO(JHNMKKNEENE);
		}
		return false;
	}

	// // RVA: 0x8DF94C Offset: 0x8DF94C VA: 0x8DF94C
	public void EHNHJKBDIJN(long JHNMKKNEENE)
	{
		NPNNPNAIONN = false;
		PLOOEECNHFB = false;
		GPHEKCNDDIK = false;
		KKFLDCBHFJA(JHNMKKNEENE);
	}

	// // RVA: 0x8DF980 Offset: 0x8DF980 VA: 0x8DF980 Slot: 40
	protected virtual void KKFLDCBHFJA(long JHNMKKNEENE)
	{
		PLOOEECNHFB = true;
	}

	// // RVA: 0x8DF98C Offset: 0x8DF98C VA: 0x8DF98C Slot: 41
	public virtual int DBOLCELMBJG_GetMainRankingIndex()
	{
		return 0;
	}

	// // RVA: 0x8DF994 Offset: 0x8DF994 VA: 0x8DF994 Slot: 42
	public virtual int DEECKJADNMJ(int LAJNCHHNLBI)
	{
		return LAJNCHHNLBI;
	}

	// // RVA: 0x8DF99C Offset: 0x8DF99C VA: 0x8DF99C
	public void NDHIFHJAAEO()
	{
		NPNNPNAIONN = false;
		PLOOEECNHFB = false;
		FCHGHAAPIBH();
	}

	// // RVA: 0x8DF9B8 Offset: 0x8DF9B8 VA: 0x8DF9B8 Slot: 43
	protected virtual void FCHGHAAPIBH()
	{
		PLOOEECNHFB = true;
	}

	// // RVA: 0x8DF9C4 Offset: 0x8DF9C4 VA: 0x8DF9C4
	protected bool OHJOJKNLHOK(SakashoErrorId KLCMLLLIANB)
	{
		return KLCMLLLIANB == SakashoErrorId.ACHIEVEMENT_PRIZE_ALREADY_RECEIVED;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BBB2C Offset: 0x6BBB2C VA: 0x6BBB2C
	// // RVA: 0x8DF9D4 Offset: 0x8DF9D4 VA: 0x8DF9D4 Slot: 44
	protected virtual IEnumerator JEIJKLPOAHP_ReceivePrologueRepeatedAchievement(DJBHIFLHJLK AOCANKOMKFG)
	{
		//0x8E4088
		KGBCKPKLKHM_RewardItems.Clear();
		yield break;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BBBA4 Offset: 0x6BBBA4 VA: 0x6BBBA4
	// // RVA: 0x8DFA80 Offset: 0x8DFA80 VA: 0x8DFA80 Slot: 45
	protected virtual IEnumerator KPBNMAEHHDF_ReceiveEpilogueRepeatedAchivement(DJBHIFLHJLK AOCANKOMKFG)
	{
		//0x8E38F4
		KGBCKPKLKHM_RewardItems.Clear();
		yield break;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BBC1C Offset: 0x6BBC1C VA: 0x6BBC1C
	// // RVA: 0x8DFB2C Offset: 0x8DFB2C VA: 0x8DFB2C
	protected IEnumerator AOGIMHOLIFB_ReceiveLoguinRepetedAchivement(List<string> MIDAMHNABAJ, DJBHIFLHJLK AOCANKOMKFG)
	{
		//0x8E3A34
		bool NKGNJJDFMPH = false;
		bool KPIGMCJMFAN = false;
		List<string> CLPMDJFKJBO = new List<string>();
		Dictionary<string,List<MFDJIFIIPJD>> JKGAGLAIEHH = new Dictionary<string, List<MFDJIFIIPJD>>();
		JGMEFHJCNHP_GetAchievementRecords req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new JGMEFHJCNHP_GetAchievementRecords());
		req.KMOBDLBKAAA_Repeatable = true;
		req.MIDAMHNABAJ_Keys = MIDAMHNABAJ;
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NHECPMNKEFK) =>
		{
			//0x8E2F44
			JGMEFHJCNHP_GetAchievementRecords r = NHECPMNKEFK as JGMEFHJCNHP_GetAchievementRecords;
			for(int i = 0; i < r.NFEAMMJIMPG.CEDLLCCONJP.Count; i++)
			{
				if(!r.NFEAMMJIMPG.CEDLLCCONJP[i].OOIJCMLEAJP_IsReceived)
				{
					CLPMDJFKJBO.Add(r.NFEAMMJIMPG.CEDLLCCONJP[i].LJNAKDMILMC_Key);
					JKGAGLAIEHH.Add(r.NFEAMMJIMPG.CEDLLCCONJP[i].LJNAKDMILMC_Key, r.NFEAMMJIMPG.CEDLLCCONJP[i].HBHMAKNGKFK);
				}
			}
			NKGNJJDFMPH = true;
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
		{
			//0x8E32D4
			NKGNJJDFMPH = true;
			KPIGMCJMFAN = true;
		};
		while(!NKGNJJDFMPH)
			yield return null;
		if(KPIGMCJMFAN)
		{
			//LAB_008e3f44
			if(AOCANKOMKFG != null)
				AOCANKOMKFG();
			yield break;
		}
		if(CLPMDJFKJBO.Count != 0)
		{
			FLONELKGABJ_ClaimAchievementPrizes req2 = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new FLONELKGABJ_ClaimAchievementPrizes());
			req2.KMOBDLBKAAA_Repeatable = true;
			req2.MIDAMHNABAJ_Keys = MIDAMHNABAJ;
			NKGNJJDFMPH = false;
			req2.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NHECPMNKEFK) =>
			{
				//0x8E32E0
				NKGNJJDFMPH = true;
				FLONELKGABJ_ClaimAchievementPrizes r = NHECPMNKEFK as FLONELKGABJ_ClaimAchievementPrizes;
				for(int i = 0; i < r.NFEAMMJIMPG.CEDLLCCONJP.Count; i++)
				{
					KGBCKPKLKHM_RewardItems.AddRange(JKGAGLAIEHH[r.NFEAMMJIMPG.CEDLLCCONJP[i].LJNAKDMILMC_Key]);
				}
			};
			req2.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
			{
				//0x8E354C
				NKGNJJDFMPH = true;
				KPIGMCJMFAN = true;
			};
			while(!NKGNJJDFMPH)
				yield return null;
			if(KPIGMCJMFAN)
			{
				if(AOCANKOMKFG != null)
					AOCANKOMKFG();
			}
		}
	}

	// // RVA: 0x8DFC0C Offset: 0x8DFC0C VA: 0x8DFC0C
	public void HCDGELDHFHB_UpdateStatus(long JHNMKKNEENE)
	{
		PJDGDNJNCNM_UpdateStatusImpl(JHNMKKNEENE);
	}

	// // RVA: 0x8DFC34 Offset: 0x8DFC34 VA: 0x8DFC34 Slot: 46
	protected virtual void PJDGDNJNCNM_UpdateStatusImpl(long JHNMKKNEENE)
	{
		return;
	}

	// // RVA: 0x8DFC38 Offset: 0x8DFC38 VA: 0x8DFC38 Slot: 47
	public virtual void NBMDAOFPKGK(int DNBFMLBNAEE)
	{
		return;
	}

	// // RVA: 0x8DFC3C Offset: 0x8DFC3C VA: 0x8DFC3C Slot: 48
	public virtual void AMKJFGLEJGE(int KPIILHGOGJD)
	{
		return;
	}

	// // RVA: 0x8DFC40 Offset: 0x8DFC40 VA: 0x8DFC40
	// public void FGMOMBKGCNF(int LHJCOPMMIGO = 0) { }

	// // RVA: 0x8DFC5C Offset: 0x8DFC5C VA: 0x8DFC5C Slot: 49
	// protected virtual void ODPJGHOJIOH(int LHJCOPMMIGO) { }

	// // RVA: 0x8DFC68 Offset: 0x8DFC68 VA: 0x8DFC68
	public void MEHIAJMOLEJ_ReceieveTotalReward(bool GIPBIDFJFLL/* = True*/)
	{
		NPNNPNAIONN = false;
		PLOOEECNHFB = false;
		PMHLJAIGBGK = null;
		FMEDFGOMNBK = null;
		MFJFBNPLFBE_OnReceieveTotalReward(GIPBIDFJFLL);
	}

	// // RVA: 0x8DFC8C Offset: 0x8DFC8C VA: 0x8DFC8C Slot: 50
	protected virtual void MFJFBNPLFBE_OnReceieveTotalReward(bool GIPBIDFJFLL)
	{
		PLOOEECNHFB = true;
	}

	// // RVA: 0x8DFC98 Offset: 0x8DFC98 VA: 0x8DFC98 Slot: 51
	public virtual IHAEIOAKEMG ILICNKILFKJ_GetNextReward()
	{
		return null;
	}

	// // RVA: 0x8DFCA0 Offset: 0x8DFCA0 VA: 0x8DFCA0 Slot: 52
	public virtual void FAMFKPBPIAA_GetRankingPlayerList(bool PFFJNEFNAMI, int CJHEHIMLGGL, int LHJCOPMMIGO, LIOLBKLMMIK KLMFJJCNBIP, DJBHIFLHJLK IDAEHNGOKAE, DJBHIFLHJLK JGKOLBLPMPG)
	{
		PLOOEECNHFB = true;
		IDAEHNGOKAE();
	}

	// // RVA: 0x8DFCD4 Offset: 0x8DFCD4 VA: 0x8DFCD4 Slot: 53
	public virtual void JPNACOLKHLB_AddRankingPlayerListSecond(int NICJGAJKODN, int NEFEFHBHFFF, LIOLBKLMMIK KLMFJJCNBIP, DJBHIFLHJLK IDAEHNGOKAE, DJBHIFLHJLK JGKOLBLPMPG)
	{
		PLOOEECNHFB = true;
		IDAEHNGOKAE();
	}

	// // RVA: 0x8DFD08 Offset: 0x8DFD08 VA: 0x8DFD08 Slot: 54
	public virtual int NGIHFKHOJOK_GetRankingMax(bool DJHLDMOPCOL = true)
	{
		return 1;
	}

	// // RVA: 0x8DFD10 Offset: 0x8DFD10 VA: 0x8DFD10 Slot: 55
	public virtual bool PIDEAJOJKKC(int LHJCOPMMIGO = 0)
	{
		return true;
	}

	// // RVA: 0x8DFD18 Offset: 0x8DFD18 VA: 0x8DFD18 Slot: 56
	public virtual bool DGOAGKOKCIJ_IsRewardReceived(int LHJCOPMMIGO)
	{
		return false;
	}

	// // RVA: 0x8DFD20 Offset: 0x8DFD20 VA: 0x8DFD20 Slot: 57
	public virtual void LHAEPPFACOB_SetRewardReceived(int LHJCOPMMIGO, bool OAFPGJLCNFM)
	{
		return;
	}

	// // RVA: 0x8DFD24 Offset: 0x8DFD24 VA: 0x8DFD24
	public void FPPNKEPDEBL(int LHJCOPMMIGO = 0)
	{
		NPNNPNAIONN = false;
		PLOOEECNHFB = false;
		LMGMELPOGMH(LHJCOPMMIGO);
	}

	// // RVA: 0x8DFD40 Offset: 0x8DFD40 VA: 0x8DFD40 Slot: 58
	protected virtual void LMGMELPOGMH(int LHJCOPMMIGO)
	{
		PLOOEECNHFB = true;
	}

	// // RVA: 0x8DFD4C Offset: 0x8DFD4C VA: 0x8DFD4C Slot: 59
	public virtual List<int> AEGDKBNNDBC_GetDrops()
	{
		return null;
	}

	// // RVA: 0x8DFD54 Offset: 0x8DFD54 VA: 0x8DFD54 Slot: 60
	public virtual bool PIBDBIKJKLD_CanPickup()
	{
		return false;
	}

	// // RVA: 0x8DFD5C Offset: 0x8DFD5C VA: 0x8DFD5C Slot: 61
	public virtual bool EMNKNFNKPAD_SetIsPickup(bool JKDJCFEBDHC)
	{
		return true;
	}

	// // RVA: 0x8DFD64 Offset: 0x8DFD64 VA: 0x8DFD64 Slot: 62
	public virtual bool MPJIJMMOHDM_IsPickup()
	{
		return false;
	}

	// // RVA: 0x8DFD6C Offset: 0x8DFD6C VA: 0x8DFD6C Slot: 63
	// public virtual MusicSelectCDSelect.EventType CFLLOAEALGN() { }

	// // RVA: 0x8DFD74 Offset: 0x8DFD74 VA: 0x8DFD74 Slot: 64
	public virtual int IBFAJICMLGF_GetJacketRibbonType()
	{
		return 0;
	}

	// // RVA: 0x8DFD7C Offset: 0x8DFD7C VA: 0x8DFD7C
	public MusicSelectCDSelect.EventType CFLLOAEALGN_GetMusicEventType(int EMDEDBFCMPD)
	{
		if (EMDEDBFCMPD > 0)
			return (MusicSelectCDSelect.EventType)(EMDEDBFCMPD - 1);
		return MusicSelectCDSelect.EventType.None;
	}

	// // RVA: 0x8DFD8C Offset: 0x8DFD8C VA: 0x8DFD8C
	public List<int> LEPNPBIMHGM(int BMMPAHHEOJC)
	{
		List<int> res = new List<int>();
		for(int i = 0; i < 3; i++)
		{
			AMCGONHBGGF d = GameManager.Instance.ViewPlayerData.DPLBHAIKPGL_GetTeam(CMEOKJMCEBH).DJPFJGKGOOF_ScoreTeam.FDBOPFEOENF_MainDivas[i];
			if(d.DIPKCALNIII_Id != 0)
			{
				for(int j = 0; j < 3; j++)
				{
					if(d.EBDNICPAFLB_SSlot[j] != 0)
					{
						MLIBEPGADJH_Scene.KKLDOOJBJMN scene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[d.EBDNICPAFLB_SSlot[j] - 1];
						if(scene.PPEGAKEIEGM_En == 2)
						{
							int KELFCMEOPPM = scene.KELFCMEOPPM_Ep;
							if(KELFCMEOPPM != 0)
							{
								HMGPODKEFBA_EpisodeInfo ep = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList[KELFCMEOPPM - 1];
								if(ep.PPEGAKEIEGM == 2)
								{
									int idx = LHAKGDAGEMM.FindIndex((IKDICBBFBMI_EventBase.CEGDBNNIDIG GHPLINIACBB) =>
									{
										//0x8E2700
										return GHPLINIACBB.KELFCMEOPPM_EpId == KELFCMEOPPM;
									});
									if(idx > -1)
									{
										int idx2 = res.FindIndex((int GHPLINIACBB) =>
										{
											//0x8E2738
											return KELFCMEOPPM == GHPLINIACBB;
										});
										if(idx2 < 0)
										{
											res.Add(KELFCMEOPPM);
										}
									}
								}
							}
						}
					}
				}
			}
		}
		if(BMMPAHHEOJC != 0)
		{
			MLIBEPGADJH_Scene.KKLDOOJBJMN scene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[BMMPAHHEOJC - 1];
			int KELFCMEOPPM = scene.KELFCMEOPPM_Ep;
			int idx = LHAKGDAGEMM.FindIndex((IKDICBBFBMI_EventBase.CEGDBNNIDIG GHPLINIACBB) =>
			{
				//0x8E274C
				return GHPLINIACBB.KELFCMEOPPM_EpId == KELFCMEOPPM;
			});
			if(idx > -1)
			{
				int idx2 = res.FindIndex((int GHPLINIACBB) =>
				{
					//0x8E2784
					return KELFCMEOPPM == GHPLINIACBB;
				});
				if(idx2 < 0)
				{
					res.Add(KELFCMEOPPM);
				}
			}
		}
		res.Sort();
		return res;
	}

	// // RVA: 0x8E06B0 Offset: 0x8E06B0 VA: 0x8E06B0
	public List<GNPOABJANKO> LMDENICBIIB_GetEpisodesBonusList(int BMMPAHHEOJC, int MHADLGMJKGK)
	{
		return EACFDLHOHKE(GameManager.Instance.ViewPlayerData.DPLBHAIKPGL_GetTeam(CMEOKJMCEBH), BMMPAHHEOJC, MHADLGMJKGK);
	}

	// // RVA: 0x8E1F74 Offset: 0x8E1F74 VA: 0x8E1F74
	public List<GNPOABJANKO> NFMDGIFKPMM(int CEHNJCIIKDN, int BMMPAHHEOJC, int MHADLGMJKGK)
	{
		return EACFDLHOHKE(GameManager.Instance.ViewPlayerData.JKIJFGGMNAN_GetUnit(CEHNJCIIKDN, CMEOKJMCEBH), BMMPAHHEOJC, MHADLGMJKGK);
	}

	// // RVA: 0x8E07F8 Offset: 0x8E07F8 VA: 0x8E07F8
	private List<GNPOABJANKO> EACFDLHOHKE(JLKEOGLJNOD_TeamInfo MLAFAACKKBG, int BMMPAHHEOJC, int MHADLGMJKGK)
	{
		List<GNPOABJANKO> res = new List<GNPOABJANKO>(LHAKGDAGEMM.Count);
		List<HMGPODKEFBA_EpisodeInfo> epList = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList;
		for(int i = 0; i < LHAKGDAGEMM.Count; i++)
		{
			if(epList[LHAKGDAGEMM[i].KELFCMEOPPM_EpId - 1].PPEGAKEIEGM == 2)
			{
				GNPOABJANKO g = new GNPOABJANKO();
				g.JKDJCFEBDHC = false;
				g.KELFCMEOPPM_EpisodeId = LHAKGDAGEMM[i].KELFCMEOPPM_EpId;
				g.HEDODOBGPPM_BonusValue = 0;
				res.Add(g);
			}
		}
		CIKHPBBNEIM cData = new CIKHPBBNEIM();
		cData.OBKGEDCKHHE(this, CMEOKJMCEBH);
		for(int i = 0; i < 3; i++)
		{
			if(MLAFAACKKBG.DJPFJGKGOOF_ScoreTeam.FDBOPFEOENF_MainDivas[i].DIPKCALNIII_Id != 0)
			{
				for(int j = 0; j < 3; j++)
				{
                    int JGJPKLCCOIO = MLAFAACKKBG.DJPFJGKGOOF_ScoreTeam.FDBOPFEOENF_MainDivas[i].EBDNICPAFLB_SSlot[j];
					if(JGJPKLCCOIO != 0)
					{
						MMPBPOIFDAF_Scene.PMKOFEIONEG saveScene = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[JGJPKLCCOIO - 1];
						MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[JGJPKLCCOIO - 1];
						bool b = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.OEEJKKFOBKD(JGJPKLCCOIO);
						int KELFCMEOPPM = dbScene.KELFCMEOPPM_Ep;
						if(KELFCMEOPPM != 0)
						{
							HMGPODKEFBA_EpisodeInfo dbEp = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList[KELFCMEOPPM - 1];
							if(dbEp.PPEGAKEIEGM == 2)
							{
								int idx = LHAKGDAGEMM.FindIndex((CEGDBNNIDIG GHPLINIACBB) =>
								{
									//0x8E27D0
									return GHPLINIACBB.KELFCMEOPPM_EpId == KELFCMEOPPM;
								});
								if(idx > -1)
								{
									CIKHPBBNEIM.PBJEFDNBBCD l = cData.GGHMLFOFELH(KELFCMEOPPM);
									GNPOABJANKO g = res.Find((GNPOABJANKO GHPLINIACBB) =>
									{
										//0x8E2808
										return GHPLINIACBB.KELFCMEOPPM_EpisodeId == KELFCMEOPPM;
									});
									if(g != null)
									{
										g.JKDJCFEBDHC = true;
										CIKHPBBNEIM.ODGCADPPIFA d = l.FLJNOOPOAGI.Find((CIKHPBBNEIM.ODGCADPPIFA GHPLINIACBB) =>
										{
											//0x8E2798
											return GHPLINIACBB.BCCHOBPJJKE_SceneId == JGJPKLCCOIO;
										});
										int a1 = d.ALDAOOLPHCH_BonusAfter;
										if(saveScene.JPIPENJGGDD_Mlt <= 0 && !b)
										{
											a1 = d.FDLEABMKOGO_BonusBefore;
										}
										if(g.HEDODOBGPPM_BonusValue < a1)
											g.HEDODOBGPPM_BonusValue = a1;
									}
								}
							}
						}
					}
                }
			}
		}
		if(BMMPAHHEOJC != 0)
		{
			MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[BMMPAHHEOJC - 1];
			int KELFCMEOPPM = dbScene.KELFCMEOPPM_Ep;
			int PONFKONDHAC = BMMPAHHEOJC;
			int LBDAABHNLGI = dbScene.KELFCMEOPPM_Ep;
			int idx = LHAKGDAGEMM.FindIndex((CEGDBNNIDIG GHPLINIACBB) =>
			{
				//0x8E2840
				return GHPLINIACBB.KELFCMEOPPM_EpId == LBDAABHNLGI;
			});
			if(idx > -1)
			{
				CIKHPBBNEIM.PBJEFDNBBCD l = cData.GGHMLFOFELH(LBDAABHNLGI);
				GNPOABJANKO g = res.Find((GNPOABJANKO GHPLINIACBB) =>
				{
					//0x8E2878
					return GHPLINIACBB.KELFCMEOPPM_EpisodeId == KELFCMEOPPM;
				});
				if(g != null)
				{
					bool b = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.OEEJKKFOBKD(BMMPAHHEOJC);
					g.JKDJCFEBDHC = true;
					CIKHPBBNEIM.ODGCADPPIFA d = l.FLJNOOPOAGI.Find((CIKHPBBNEIM.ODGCADPPIFA GHPLINIACBB) =>
					{
						//0x8E28B0
						return GHPLINIACBB.BCCHOBPJJKE_SceneId == PONFKONDHAC;
					});
					int a1 = d.ALDAOOLPHCH_BonusAfter;
					if(MHADLGMJKGK <= 0 && !b)
					{
						a1 = d.FDLEABMKOGO_BonusBefore;
					}
					if(g.HEDODOBGPPM_BonusValue < a1)
						g.HEDODOBGPPM_BonusValue = a1;
				}
			}
		}
		if(GameManager.Instance.SelectedGuestData == null)
		{
			if(BMMPAHHEOJC == 0)
				return res;
			MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[BMMPAHHEOJC - 1];
			int KELFCMEOPPM = dbScene.KELFCMEOPPM_Ep;
			int PONFKONDHAC = BMMPAHHEOJC;
			int LBDAABHNLGI = dbScene.KELFCMEOPPM_Ep;
			int idx = LHAKGDAGEMM.FindIndex((CEGDBNNIDIG GHPLINIACBB) =>
			{
				//0x8E29A4
				return GHPLINIACBB.KELFCMEOPPM_EpId == LBDAABHNLGI;
			});
			if(idx >= 0)
			{
				CIKHPBBNEIM.PBJEFDNBBCD l = cData.GGHMLFOFELH(LBDAABHNLGI);
				GNPOABJANKO g = res.Find((GNPOABJANKO GHPLINIACBB) =>
				{
					//0x8E29DC
					return GHPLINIACBB.KELFCMEOPPM_EpisodeId == KELFCMEOPPM;
				});
				if(g != null)
				{
					bool b = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.OEEJKKFOBKD(BMMPAHHEOJC);
					g.JKDJCFEBDHC = true;
					CIKHPBBNEIM.ODGCADPPIFA d = l.FLJNOOPOAGI.Find((CIKHPBBNEIM.ODGCADPPIFA GHPLINIACBB) =>
					{
						//0x8E2A14
						return GHPLINIACBB.BCCHOBPJJKE_SceneId == PONFKONDHAC;
					});
					int a1 = d.ALDAOOLPHCH_BonusAfter;
					if(MHADLGMJKGK <= 0 && !b)
					{
						a1 = d.FDLEABMKOGO_BonusBefore;
					}
					if(g.HEDODOBGPPM_BonusValue < a1)
						g.HEDODOBGPPM_BonusValue = a1;
				}
			}
		}
		else
		{
            GCIJNCFDNON_SceneInfo BNJGNKCKCBD = GameManager.Instance.SelectedGuestData.KHGKPKDBMOH_GetAssistScene();
			MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[BNJGNKCKCBD.BCCHOBPJJKE_SceneId - 1];
			int KELFCMEOPPM = dbScene.KELFCMEOPPM_Ep;
			CIKHPBBNEIM.PBJEFDNBBCD l = cData.GGHMLFOFELH(KELFCMEOPPM);
			int idx = LHAKGDAGEMM.FindIndex((CEGDBNNIDIG GHPLINIACBB) =>
			{
				//0x8E2934
				return GHPLINIACBB.KELFCMEOPPM_EpId == KELFCMEOPPM;
			});
			if(idx >= 0)
			{
				GNPOABJANKO g = res.Find((GNPOABJANKO GHPLINIACBB) =>
				{
					//0x8E296C
					return GHPLINIACBB.KELFCMEOPPM_EpisodeId == KELFCMEOPPM;
				});
				if(g != null)
				{
					bool b = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.OEEJKKFOBKD(BNJGNKCKCBD.BCCHOBPJJKE_SceneId);
					g.JKDJCFEBDHC = true;
					CIKHPBBNEIM.ODGCADPPIFA d = l.FLJNOOPOAGI.Find((CIKHPBBNEIM.ODGCADPPIFA GHPLINIACBB) =>
					{
						//0x8E28E8
						return GHPLINIACBB.BCCHOBPJJKE_SceneId == BNJGNKCKCBD.BCCHOBPJJKE_SceneId;
					});
					int a1 = d.ALDAOOLPHCH_BonusAfter;
					if(BNJGNKCKCBD.JPIPENJGGDD_NumBoard <= 0 && !b)
					{
						a1 = d.FDLEABMKOGO_BonusBefore;
					}
					if(g.HEDODOBGPPM_BonusValue < a1)
						g.HEDODOBGPPM_BonusValue = a1;
				}
			}
        }
		return res;
	}

	// // RVA: 0x8E20FC Offset: 0x8E20FC VA: 0x8E20FC
	public int CEICDKGEONG(int BMMPAHHEOJC, int MHADLGMJKGK)
	{
		List<GNPOABJANKO> l = LMDENICBIIB_GetEpisodesBonusList(BMMPAHHEOJC, MHADLGMJKGK);
		int res = 0;
		for(int i = 0; i < l.Count; i++)
		{
			if(l[i].JKDJCFEBDHC)
			{
				res += l[i].HEDODOBGPPM_BonusValue;
			}
		}
		return Mathf.Min(Mathf.Max(res, 0), 999);
	}

	// // RVA: 0x8E2288 Offset: 0x8E2288 VA: 0x8E2288
	public bool FBLGGLDPFDF_CanShowStartAdventure()
	{
		return JLPDECMHLIM_CanShowStartAdventureInternal();
	}

	// // RVA: 0x8E2298 Offset: 0x8E2298 VA: 0x8E2298 Slot: 65
	protected virtual bool JLPDECMHLIM_CanShowStartAdventureInternal()
	{
		return false;
	}

	// // RVA: 0x8E22A0 Offset: 0x8E22A0 VA: 0x8E22A0 Slot: 66
	public virtual void FGDDBFHGCGP_SetStartAdventureShown(bool JKDJCFEBDHC, long JHNMKKNEENE = 0)
	{
		return;
	}

	// // RVA: 0x8E22A4 Offset: 0x8E22A4 VA: 0x8E22A4 Slot: 67
	// public virtual int LBNKDKDMMOK() { }

	// // RVA: 0x8E22AC Offset: 0x8E22AC VA: 0x8E22AC Slot: 68
	public virtual bool GJMGKBDGMOP(long LPEKHFOMCAH)
	{
		return false;
	}

	// // RVA: 0x8E22B4 Offset: 0x8E22B4 VA: 0x8E22B4
	public bool JBPPMMMFGCA_HasRewardItems()
	{
		return KGBCKPKLKHM_RewardItems.Count > 0;
	}

	// // RVA: 0x8E233C Offset: 0x8E233C VA: 0x8E233C Slot: 69
	// public virtual void HAAEJDGMICH(LBNLAENLPNK.JEKODBEDOMM INDDJNMPONH, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0x8E2368 Offset: 0x8E2368 VA: 0x8E2368 Slot: 70
	public virtual void ADACMHAHHKC_PreSetupEventHome(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		NPNNPNAIONN = false;
		PLOOEECNHFB = true;
		if (BHFHGFKBOHH != null)
			BHFHGFKBOHH();
	}

	// // RVA: 0x8E238C Offset: 0x8E238C VA: 0x8E238C Slot: 71
	public virtual int BAEPGOAMBDK(string LJNAKDMILMC, int MNCOAGOKNAO)
	{
		return MNCOAGOKNAO;
	}

	// // RVA: 0x8E2394 Offset: 0x8E2394 VA: 0x8E2394 Slot: 72
	public virtual string MAICAKMIBEM(string LJNAKDMILMC, string MNCOAGOKNAO)
	{
		return MNCOAGOKNAO;
	}

	// // RVA: 0x8E239C Offset: 0x8E239C VA: 0x8E239C Slot: 73
	public virtual List<string> IJCPBPFEGDM_GetResourcesFilePathList(long JHNMKKNEENE)
	{
		return null;
	}

	// // RVA: 0x8E23A4 Offset: 0x8E23A4 VA: 0x8E23A4
	protected bool MNNNLDFNNCD(long JHNMKKNEENE)
	{
		if(JHNMKKNEENE < GLIMIGNNGGB_Start)
			return false;
		return LJOHLEGGGMC > JHNMKKNEENE;
	}

	// // RVA: 0x8E23DC Offset: 0x8E23DC VA: 0x8E23DC Slot: 74
	public virtual int EDNMFMBLCGF_GetWavId()
	{
		return 0;
	}

	// // RVA: 0x8E23E4 Offset: 0x8E23E4 VA: 0x8E23E4 Slot: 75
	public virtual string FEKEBPKINIM_GetSessionId()
	{
		return "";
	}

	// // RVA: 0x8E2440 Offset: 0x8E2440 VA: 0x8E2440
	public void DOCHABECLFK(int MNLNFLBKMGG)
	{
		HADLPHIMBHH_BoostRatio = MNLNFLBKMGG;
	}

	// // RVA: 0x8E2448 Offset: 0x8E2448 VA: 0x8E2448
	public void OJGHCKMPJFP()
	{
		HADLPHIMBHH_BoostRatio = 1;
	}

	// // RVA: 0x8E2454 Offset: 0x8E2454 VA: 0x8E2454
	protected bool DLHEEOIELBA(int IJEKNCDIIAE)
	{
		return IJEKNCDIIAE <= DIHHCBACKGG_DbSection.IEFOPDOOLOK_MasterVersion;
	}

	// // RVA: 0x8E24F0 Offset: 0x8E24F0 VA: 0x8E24F0 Slot: 76
	public virtual void MMIMJPNLKBK()
	{
		return;
	}

	// // RVA: 0x8E24F4 Offset: 0x8E24F4 VA: 0x8E24F4
	public bool GHAFMPBPJME()
	{
		return GFHKFKHBIGM;
	}

	// // RVA: 0x8E24FC Offset: 0x8E24FC VA: 0x8E24FC
	public bool NJHPPOFBCMA()
	{
		return OIMGJLOLPHK;
	}

	// // RVA: 0x8E2504 Offset: 0x8E2504 VA: 0x8E2504 Slot: 77
	public virtual string DBEMCLMPCFA_GetBannerText()
	{
		return "";
	}

	// // RVA: 0x8E2568 Offset: 0x8E2568 VA: 0x8E2568 Slot: 78
	public virtual long OEGAJJANHGL()
	{
		return 0;
	}

	// // RVA: 0x8E2574 Offset: 0x8E2574 VA: 0x8E2574 Slot: 79
	// public virtual bool GNGPNMHGDGE() { }

	// [IteratorStateMachineAttribute] // RVA: 0x6BBC94 Offset: 0x6BBC94 VA: 0x6BBC94
	// // RVA: 0x8E257C Offset: 0x8E257C VA: 0x8E257C
	public IEnumerator EPOOEDJCBDN_Co_CheckClosedEvent(Action<bool> GEIFEILEGGE)
	{
		//0x8E355C
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		if(IONOAFPLANN || time >= LJOHLEGGGMC)
		{
			IONOAFPLANN = false;
			bool IMCBLDILPGA = false;
			JHHBAFKMBDL.HHCJCDFCLOB.DNABPEOICIJ(() =>
			{
				//0x8E2A54
				IMCBLDILPGA = true;
			}, false);
			yield return new WaitWhile(() =>
			{
				return !IMCBLDILPGA;
			});
			GEIFEILEGGE(true);
		}
		else
			GEIFEILEGGE(false);
	}

	// // RVA: 0x8E2644 Offset: 0x8E2644 VA: 0x8E2644
	public bool HJPNJBCJPNJ(KGCNCBOKCBA.GNENJEHKMHD_EventStatus BELFNAHNMDL)
	{
		return NGOFCFJHOMI_Status <= BELFNAHNMDL && BELFNAHNMDL > KGCNCBOKCBA.GNENJEHKMHD_EventStatus.FFLKPBPBPEP_1/*1*/;
	}

	// // RVA: 0x8E2668 Offset: 0x8E2668 VA: 0x8E2668 Slot: 80
	public virtual bool PDDKJENPOBL()
	{
		return true;
	}
}
