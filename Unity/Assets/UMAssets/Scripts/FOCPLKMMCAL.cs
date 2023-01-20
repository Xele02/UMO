
using System.Collections.Generic;

public class FOCPLKMMCAL
{
	public List<IELJJAAJAOE> ACNDIGLMCAA = new List<IELJJAAJAOE>(); // 0x8
	public List<IELJJAAJAOE> HHMHOAKGBHF = new List<IELJJAAJAOE>(); // 0xC
	public List<IELJJAAJAOE> DCELMKFJHPG = new List<IELJJAAJAOE>(); // 0x10
	public int NMDKKAAOIOI_BaseUnionCredit; // 0x14
	public int MJKFDDKLLFP_DropUnionCredit; // 0x18
	public int PLMBDFGGBAJ; // 0x1C
	public int MMMKNPEMBIL; // 0x20
	public int MNJGODHNPNO; // 0x24
	public int NGDDIIDJFNG; // 0x28
	public int LKGONGDLJBH; // 0x2C
	public int HGHMMDOEGEF; // 0x30
	public int CBCIFACJGHI; // 0x34
	public int MKEPHNGLHDL; // 0x38
	public int HBAJPMDOMPL; // 0x3C
	public int FOIPBBCHBIB; // 0x40
	public int PMPBDEJMHOJ_Level; // 0x44
	public int FFDBCEDKMGN; // 0x48
	public int MMLPAMGJEOD; // 0x4C
	public int PENICOGGNLF_ScoreRank; // 0x50
	public int CFNCNCBEPED; // 0x54
	public bool EDDMMPBELBM; // 0x58
	private bool DAKKOLCGFCN; // 0x59
	public int[] FFDDBFEIJKI = new int[10]; // 0x5C
	private bool HCPKKNBPHNN = true; // 0x60
	public int FCLGIPFPIPH = 1; // 0x64
	public int HIEBJGOKEID_ItemId; // 0x68
	public int GIPMPIMJHLE; // 0x6C
	public int ACMMDAHKCIF; // 0x70
	public bool GNAMCOJKEFE; // 0x74
	public int INKMIAAMIEO_EventRareDropDenom = 10000; // 0x78
	public int BCCJLLJMPAA_EventRareDropDenomRand; // 0x7C
	public int LFGNFNDDLJH_TicketCount = 1; // 0x80
	public static string[] PKFJIIJJMGL = new string[5] {
		"Easy", "Normal", "Hard", "VeryHard", "Extreme"
	}; // 0x0
	public static string[] LKMFBMPKEGN = new string[5] {
		"Easy+", "Normal+", "Hard+", "VeryHard+", "Extreme+"
	}; // 0x4
	public string NKGFGDGFGFM = ""; // 0x84
	public JKNGJFOBADP JANMJPOKLFL = new JKNGJFOBADP(); // 0x88
	public AIPOFGJGPKI_CampaignDiva.KBLBMGDILAI HMMFHMHENAO; // 0x8C

	//public List<int> PPBHHLGPMBK { get; } 0x13E8850 GHMCBPAFMNO
	public List<int> IONINNDIAFO { get { return JANMJPOKLFL.IONINNDIAFO; } } //0x13E8874 IICAOCOECKE

	//// RVA: 0x13E8898 Offset: 0x13E8898 VA: 0x13E8898
	public bool MDPFLKOIJFN(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, EAJCBFGKKFA_FriendInfo IPGFALGDLHN_FriendInfo)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("disable_split_raredrop", 0) != 1)
		{
			HCPKKNBPHNN = false;
		}
		EONOEHOKBEB_Music music = JGEOBNENMAH.DLOBJHGIBJE_GetMusicInfo(OMNOFMEBLAD, true);
		if(music != null)
		{
			KLBKPANJCPL_Score k = JGEOBNENMAH.KFFCMNELJJB_GetMusicScore(music, OMNOFMEBLAD.AKNELONELJK_Difficulty, OMNOFMEBLAD.LFGNLKKFOCD_IsLine6);
			if(k != null)
			{
				if(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId < 1)
				{
					if(OMNOFMEBLAD.KLCIIHKFPPO_StoryMusicId > 0)
					{
						DJNPIGEFPMF_StoryMusicInfo storyMusicInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.FLMLJIKBIMJ_GetStoryMusicData(OMNOFMEBLAD.KLCIIHKFPPO_StoryMusicId);
						PENICOGGNLF_ScoreRank = storyMusicInfo.COGKJBAFBKN_ByDiff[0].DLPBHJALHCK_GetScoreRank(OMNOFMEBLAD.KNIFCANOHOC_Score);
						return BEEAKFJAPOB(OMNOFMEBLAD, music, true);
					}
				}
				else
				{
					KEODKEGFDLD_FreeMusicInfo freeMusicInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId);
					PENICOGGNLF_ScoreRank = freeMusicInfo.EMJCHPDJHEI(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6, OMNOFMEBLAD.AKNELONELJK_Difficulty).DLPBHJALHCK_GetScoreRank(OMNOFMEBLAD.KNIFCANOHOC_Score);
					if(OMNOFMEBLAD.JPJMALBLKDI_Tutorial == 0)
					{
						BDKANJGDMPK_GetBaseUnionCredit(k.ANAJIAENLNB_F_pt, true, OMNOFMEBLAD.LFGNLKKFOCD_IsLine6);
					}
					HKEFOCFIKIL(OMNOFMEBLAD, music, true);
					LDNMDBMFIIK_UpdateHighScore(OMNOFMEBLAD, music, true);
					ILDLMKGBKIL(OMNOFMEBLAD, music, true);
					if (!BEEAKFJAPOB(OMNOFMEBLAD, music, true))
						return false;
					EMLKKEHCKMI(OMNOFMEBLAD, music, true);
					int sceneId = 0;
					int c = 0;
					if(IPGFALGDLHN_FriendInfo != null && IPGFALGDLHN_FriendInfo.KHGKPKDBMOH() != null)
					{
						sceneId = IPGFALGDLHN_FriendInfo.KHGKPKDBMOH().BCCHOBPJJKE_SceneId;
						c = IPGFALGDLHN_FriendInfo.KHGKPKDBMOH().JPIPENJGGDD;
					}
					if(OMNOFMEBLAD.MNNHHJBBICA_GameEventType == 6)
					{
						TodoLogger.Log(0, "Event");
						// L268
					}
					else if(OMNOFMEBLAD.MNNHHJBBICA_GameEventType == 1)
					{
						TodoLogger.Log(0, "Event");
						// L207
					}
					else if (OMNOFMEBLAD.MNNHHJBBICA_GameEventType == 3)
					{
						TodoLogger.Log(0, "Event");
						// L237
					}
					else if (OMNOFMEBLAD.MNNHHJBBICA_GameEventType == 14)
					{
						TodoLogger.Log(0, "Event");
						// L298
					}
				}
				return true;
			}
		}
		return false;
	}

	//// RVA: 0x13EF978 Offset: 0x13EF978 VA: 0x13EF978
	public bool HNNPBABEPBP(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, EAJCBFGKKFA_FriendInfo IPGFALGDLHN_FriendInfo)
	{
		TodoLogger.Log(0, "HNNPBABEPBP");
		return false;
	}

	//// RVA: 0x13E9200 Offset: 0x13E9200 VA: 0x13E9200
	private void BDKANJGDMPK_GetBaseUnionCredit(int ANAJIAENLNB_FPt, bool JCCBGECHIEI, bool GIKLNODJKFK_IsLine6)
	{
		NMDKKAAOIOI_BaseUnionCredit = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.GFODAIJMBAH_GetUc(ANAJIAENLNB_FPt, GIKLNODJKFK_IsLine6);
		if (JCCBGECHIEI)
			return;
		CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ENEMPFLFEHP_AddUc(NMDKKAAOIOI_BaseUnionCredit);
		CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.OEKEIGFAIGN_Counter.BDLNMOIOMHK.EJJAPFPJLHP(NMDKKAAOIOI_BaseUnionCredit);
	}

	//// RVA: 0x13E9420 Offset: 0x13E9420 VA: 0x13E9420
	private void HKEFOCFIKIL(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, EONOEHOKBEB_Music EPMMNEFADAP_MusicInfo, bool JCCBGECHIEI)
	{
		TodoLogger.Log(0, "HKEFOCFIKIL");
	}

	//// RVA: 0x13ED3D4 Offset: 0x13ED3D4 VA: 0x13ED3D4
	private bool BEEAKFJAPOB(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, EONOEHOKBEB_Music EPMMNEFADAP_MusicInfo, bool JCCBGECHIEI)
	{
		if (OMNOFMEBLAD.DGMPBPMDBEC_DropItemList == null)
			return false;
		NBPHJDCOECH_Drop dbDrop = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HGLIIPFLMFB_Drop;
		string[] txt = null;
		COOFLMBIHML data = new COOFLMBIHML();
		if (!OMNOFMEBLAD.LFGNLKKFOCD_IsLine6)
		{
			txt = PKFJIIJJMGL;
		}
		else
		{
			txt = LKMFBMPKEGN;
		}
		string difftxt = txt[OMNOFMEBLAD.AKNELONELJK_Difficulty];
		FFDBCEDKMGN = 0;
		int v1 = 0;
		int v2 = 0;
		int v3 = 0;
		int v4 = 0;
		int v5 = 0;
		int v6 = 0;
		int v7 = 0;
		int scoreRank = 0;
		if (OMNOFMEBLAD.JPJMALBLKDI_Tutorial < 1)
		{
			if(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId < 1)
			{
				if (OMNOFMEBLAD.KLCIIHKFPPO_StoryMusicId < 1)
					return false;
				JANMJPOKLFL.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.EDHFDPBEFKA, OMNOFMEBLAD.KLCIIHKFPPO_StoryMusicId.ToString());
				DJNPIGEFPMF_StoryMusicInfo storyMusicInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.FLMLJIKBIMJ_GetStoryMusicData(OMNOFMEBLAD.KLCIIHKFPPO_StoryMusicId);
				v1 = storyMusicInfo.MGLDIOILOFF;
				v5 = storyMusicInfo.KCNHKNKNGNH;
				v5 += OMNOFMEBLAD.AKNELONELJK_Difficulty;
				data.KHEKNNFCAOI(EPMMNEFADAP_MusicInfo.FKDCCLPGKDK_Ma, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, false);
				v2 = 0;
				v3 = 0;
				v4 = 0;
				v6 = 0;
				v7 = 0;
				scoreRank = 0;
			}
			else
			{
				string[] strs = new string[5];
				strs[0] = OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId.ToString();
				strs[1] = ":";
				strs[2] = difftxt;
				strs[3] = ":";
				strs[4] = NKGFGDGFGFM;
				JANMJPOKLFL.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.IMJOELNOOMB, string.Concat(strs));
				bool d = false;
				IKDICBBFBMI_EventBase event_ = null;
				if(OMNOFMEBLAD.MFJKNCACBDG_OpenEventType == 0 || JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB(KGCNCBOKCBA.GNENJEHKMHD.EMAMLLFAOJI, false) == null)
				{
					d = false;
				}
				else
				{
					TodoLogger.Log(0, "Event");
					/*event_ = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB(KGCNCBOKCBA.GNENJEHKMHD.EMAMLLFAOJI, false);
					FFDBCEDKMGN = event_.FBGDBGKNKOD();
					d = true;*/
				}
				KEODKEGFDLD_FreeMusicInfo freeInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId);
				v1 = freeInfo.MGLDIOILOFF;
				if (d)
				{
					TodoLogger.Log(0, "Event");
					// L291
				}
				v5 = freeInfo.KDIKCKEEPDA(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6);
				if(d)
				{
					TodoLogger.Log(0, "Event");
					// L310
				}
				v7 = 0;
				v6 = freeInfo.JCDKMICANJO;
				if (v6 != 0)
				{
					v7 = OMNOFMEBLAD.AKNELONELJK_Difficulty + freeInfo.ONLFLGPMAAN(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6);
				}
				v3 = freeInfo.CCLIOBOGFHC;
				v4 = 0;
				if(d)
				{
					TodoLogger.Log(0, "Event");
					// L346
				}
				if(v3 != 0)
				{
					int j = freeInfo.NCCFJCDMBFO(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6);
					if(d)
					{
						TodoLogger.Log(0, "Event");
						// L366
					}
					v4 = OMNOFMEBLAD.AKNELONELJK_Difficulty + j;
				}
				v2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.NBIAKELCBLC_GetNumItems(OMNOFMEBLAD.MJBODMOLOBC_TeamLuck, OMNOFMEBLAD.JEKDIEFPEON_RareItemRandomSeed);
				if(OMNOFMEBLAD.MNNHHJBBICA_GameEventType == 0)
				{
					if(OMNOFMEBLAD.MFJKNCACBDG_OpenEventType == 1)
					{
						TodoLogger.Log(0, "Event");
						// L389
					}
				}
				else
				{
					TodoLogger.Log(0, "Event");
					// L412
				}

				scoreRank = freeInfo.EMJCHPDJHEI(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6, OMNOFMEBLAD.AKNELONELJK_Difficulty).DLPBHJALHCK_GetScoreRank(OMNOFMEBLAD.KNIFCANOHOC_Score);
				v5 = OMNOFMEBLAD.AKNELONELJK_Difficulty + v5;
				data.KHEKNNFCAOI(EPMMNEFADAP_MusicInfo.FKDCCLPGKDK_Ma, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, false);
				if(d)
				{
					TodoLogger.Log(0, "Event");
					// L464
				}
			}
		}
		else
		{
			TodoLogger.Log(0, "Tuto");
			// L476
		}
		List<int> l = new List<int>();
		HNJKJCDDIMG_SetInfo setInfo = dbDrop.NMGAAKPJPLB(v1);
		OPGDJANLKBM_RateInfo rateInfo = dbDrop.KPDHGNEILPO(v5);
		HNJKJCDDIMG_SetInfo setInfo3 = dbDrop.OHGDKJFDIKK_GetSet(v6);
		OPGDJANLKBM_RateInfo rateInfo3 = dbDrop.OGBNNMOIBOP_GetRate(v7);
		HNJKJCDDIMG_SetInfo setInfo2 = dbDrop.OHGDKJFDIKK_GetSet(v3);
		OPGDJANLKBM_RateInfo rateInfo2 = dbDrop.OGBNNMOIBOP_GetRate(v4);
		int f = LFGNFNDDLJH_TicketCount;
		if (OMNOFMEBLAD.OOPEJLMNIAH_EventItemCount > 0)
		{
			TodoLogger.Log(0, "Tuto");
			// L648
		}
		if(setInfo != null && rateInfo != null)
		{
			OMNOFMEBLAD.DGMPBPMDBEC_DropItemList.Sort();
			int cnt = 0;
			bool ba = false;
			for (int i = 0; i < OMNOFMEBLAD.DGMPBPMDBEC_DropItemList.Count; i++)
			{
				int item = OMNOFMEBLAD.DGMPBPMDBEC_DropItemList[i];
				if((item & 0x10000000) == 0)
				{
					if((item & 0x20000000) != 0)
					{
						if(LFGNFNDDLJH_TicketCount * v2 <= cnt)
						{
							UnityEngine.Debug.Log("RareDrop Overflow");
							ba = true;
							continue;
						}
						if(setInfo2 != null && rateInfo2 != null)
						{
							int itemIdx = (int)(item & 0xdfffffff);
							int itemId = setInfo2.FKNBLDPIPMC_GetItemId(itemIdx);
							if (itemId != 0)
							{
								if(rateInfo2.HMFFHLPNMPH_Cnt[itemIdx] > 0)
								{
									if (itemId == 170000)
										itemId = HIEBJGOKEID_ItemId;
									else if(itemId == 400001)
									{
										int v = 0;
										if (l.Count < 1)
										{
											v = data.NEHHNEPPIBK();
										}
										else
										{
											v = l[OMNOFMEBLAD.JEKDIEFPEON_RareItemRandomSeed % l.Count];
										}
										itemId = 40000 + v;
									}
									else if(itemId == 40000)
									{
										itemId = 40000 + data.NEHHNEPPIBK();
									}
									if(JCCBGECHIEI)
									{
										//LAB_013ee8e4
										BDMIIPKOIKL(item, itemId, rateInfo2.HMFFHLPNMPH_Cnt[itemIdx] * LFGNFNDDLJH_TicketCount, false);
									}
									else
									{
										DFKOELMCDDL(item, itemId, rateInfo2.HMFFHLPNMPH_Cnt[itemIdx] * LFGNFNDDLJH_TicketCount, false);
									}
								}
							}
						}
					}
					else
					{
						int itemIdx = (int)(item & 0xbfffffff);
						if(itemIdx > -1 && itemIdx < setInfo.KAINPNMMAEK_GetItemsCount() && setInfo.FKNBLDPIPMC_GetItemId(itemIdx) != 0)
						{
							if(rateInfo.HMFFHLPNMPH_Cnt[itemIdx] > 0)
							{
								int itemId = setInfo.FKNBLDPIPMC_GetItemId(itemIdx);
								if (itemId == 170000)
									itemId = HIEBJGOKEID_ItemId;
								else if(itemId == 40001)
								{
									int v = 0;
									if(l.Count < 1)
									{
										v = data.NEHHNEPPIBK();
									}
									else
									{
										v = l[OMNOFMEBLAD.JEKDIEFPEON_RareItemRandomSeed % l.Count];
									}
									itemId = v + 40000;
								}
								else if(itemId == 40000)
								{
									itemId = 40000 + data.NEHHNEPPIBK();
								}
								if(JCCBGECHIEI)
								{
									BDMIIPKOIKL(item, itemId, rateInfo2.HMFFHLPNMPH_Cnt[itemIdx] * LFGNFNDDLJH_TicketCount, false);
								}
								else
								{
									DFKOELMCDDL(item, itemId, rateInfo2.HMFFHLPNMPH_Cnt[itemIdx] * LFGNFNDDLJH_TicketCount, false);
								}
							}
						}
					}
				}
				else
				{
					if(LFGNFNDDLJH_TicketCount * v2 <= cnt)
					{
						UnityEngine.Debug.Log("RareDrop Overflow");
						ba = true;
						continue;
					}
					if(setInfo3 != null && rateInfo3 != null)
					{
						int itemIdx = (int)(item & 0xefffffff);
						int itemId = setInfo3.FKNBLDPIPMC_GetItemId(itemIdx);
						if(itemId != 0)
						{
							if(rateInfo3.HMFFHLPNMPH_Cnt[itemIdx] > 0)
							{
								if(itemId == 170000)
								{
									itemId = HIEBJGOKEID_ItemId;
								}
								else if (itemId == 40001)
								{
									int v = 0;
									if (l.Count < 1)
									{
										v = data.NEHHNEPPIBK();
									}
									else
									{
										v = l[OMNOFMEBLAD.JEKDIEFPEON_RareItemRandomSeed % l.Count];
									}
									itemId = v + 40000;
								}
								else if (itemId == 40000)
								{
									itemId = 40000 + data.NEHHNEPPIBK();
								}
								if (JCCBGECHIEI)
								{
									BDMIIPKOIKL(item, itemId, rateInfo3.HMFFHLPNMPH_Cnt[itemIdx] * LFGNFNDDLJH_TicketCount, false);
								}
								else
								{
									DFKOELMCDDL(item, itemId, rateInfo3.HMFFHLPNMPH_Cnt[itemIdx] * LFGNFNDDLJH_TicketCount, false);
								}
							}
						}
					}
					cnt += LFGNFNDDLJH_TicketCount;
				}
			}
			if(ba)
				return false;
		}
		HDBDNGJMCIA(scoreRank, JCCBGECHIEI);
		if (!JCCBGECHIEI)
			ACMDMANBMEN();
		return true;
	}

	//// RVA: 0x13F2D60 Offset: 0x13F2D60 VA: 0x13F2D60
	private void DFKOELMCDDL(int OIPCCBHIKIA_ItemCode, int KIJAPOFAGPN_ItemId, int HMFFHLPNMPH_Cnt, bool OEIGPPHPPFN = false)
	{
		if (KIJAPOFAGPN_ItemId == 0)
			return;
		IELJJAAJAOE data = new IELJJAAJAOE();
		if (OEIGPPHPPFN)
		{
			data.KIJAPOFAGPN_ItemId = KIJAPOFAGPN_ItemId;
			data.OIPCCBHIKIA_ItemCode = OIPCCBHIKIA_ItemCode;
			data.OMAJOEOOAJJ_Cnt = HMFFHLPNMPH_Cnt;
			data.BAKFIPIFDLE = true;
			HHMHOAKGBHF.Add(data);
		}
		else
		{
			if((OIPCCBHIKIA_ItemCode & 0x30000000U) == 0 || !HCPKKNBPHNN)
			{
				IELJJAAJAOE exist = HHMHOAKGBHF.Find((IELJJAAJAOE JGNBPFCJLKI) =>
				{
					//0x13F5344
					return JGNBPFCJLKI.OIPCCBHIKIA_ItemCode == OIPCCBHIKIA_ItemCode;
				});
				if(exist != null)
				{
					exist.OMAJOEOOAJJ_Cnt += HMFFHLPNMPH_Cnt;
					return;
				}
				data.KIJAPOFAGPN_ItemId = KIJAPOFAGPN_ItemId;
				data.OIPCCBHIKIA_ItemCode = OIPCCBHIKIA_ItemCode;
				data.OMAJOEOOAJJ_Cnt = HMFFHLPNMPH_Cnt;
				data.PHJHJGDLPED = (OIPCCBHIKIA_ItemCode & 0x30000000) != 0;
				HHMHOAKGBHF.Add(data);
			}
			else
			{
				data.KIJAPOFAGPN_ItemId = KIJAPOFAGPN_ItemId;
				data.OIPCCBHIKIA_ItemCode = OIPCCBHIKIA_ItemCode;
				data.OMAJOEOOAJJ_Cnt = HMFFHLPNMPH_Cnt;
				data.PHJHJGDLPED = (OIPCCBHIKIA_ItemCode & 0x30000000) != 0;
				HHMHOAKGBHF.Add(data);
			}
		}
	}

	//// RVA: 0x13F2A20 Offset: 0x13F2A20 VA: 0x13F2A20
	private void BDMIIPKOIKL(int OIPCCBHIKIA_ItemCode, int KIJAPOFAGPN_ItemId, int HMFFHLPNMPH_Cnt, bool OEIGPPHPPFN = false)
	{
		if (KIJAPOFAGPN_ItemId == 0)
			return;
		IELJJAAJAOE data = new IELJJAAJAOE();
		if (OEIGPPHPPFN)
		{
			data.KIJAPOFAGPN_ItemId = KIJAPOFAGPN_ItemId;
			data.OIPCCBHIKIA_ItemCode = OIPCCBHIKIA_ItemCode;
			data.OMAJOEOOAJJ_Cnt = HMFFHLPNMPH_Cnt;
			data.BAKFIPIFDLE = true;
			ACNDIGLMCAA.Add(data);
		}
		else
		{
			if ((OIPCCBHIKIA_ItemCode & 0x30000000U) == 0 || !HCPKKNBPHNN)
			{
				IELJJAAJAOE exist = HHMHOAKGBHF.Find((IELJJAAJAOE JGNBPFCJLKI) =>
				{
					//0x13F537C
					return JGNBPFCJLKI.OIPCCBHIKIA_ItemCode == OIPCCBHIKIA_ItemCode;
				});
				if (exist != null)
				{
					exist.OMAJOEOOAJJ_Cnt += HMFFHLPNMPH_Cnt;
					return;
				}
				data.KIJAPOFAGPN_ItemId = KIJAPOFAGPN_ItemId;
				data.OIPCCBHIKIA_ItemCode = OIPCCBHIKIA_ItemCode;
				data.OMAJOEOOAJJ_Cnt = HMFFHLPNMPH_Cnt;
				data.PHJHJGDLPED = (OIPCCBHIKIA_ItemCode & 0x30000000) != 0;
				ACNDIGLMCAA.Add(data);
			}
			else
			{
				data.KIJAPOFAGPN_ItemId = KIJAPOFAGPN_ItemId;
				data.OIPCCBHIKIA_ItemCode = OIPCCBHIKIA_ItemCode;
				data.OMAJOEOOAJJ_Cnt = HMFFHLPNMPH_Cnt;
				data.PHJHJGDLPED = (OIPCCBHIKIA_ItemCode & 0x30000000) != 0;
				ACNDIGLMCAA.Add(data);
			}
		}
	}

	//// RVA: 0x13F30A0 Offset: 0x13F30A0 VA: 0x13F30A0
	private void HDBDNGJMCIA(int DCBDCHPKLCN, bool JCCBGECHIEI)
	{
		TodoLogger.Log(0, "HDBDNGJMCIA");
	}

	//// RVA: 0x13EF670 Offset: 0x13EF670 VA: 0x13EF670
	//public int ENCNIGKPEFB() { }

	//// RVA: 0x13F38C0 Offset: 0x13F38C0 VA: 0x13F38C0
	private void ACMDMANBMEN()
	{
		TodoLogger.Log(0, "ACMDMANBMEN");
	}

	//// RVA: 0x13F45AC Offset: 0x13F45AC VA: 0x13F45AC
	//private void BGGHEILFEIN(EKLNMHFCAOI.FKGCBLHOOCL INDDJNMPONH, int PPFNGGCBJKC, int HMFFHLPNMPH) { }

	//// RVA: 0x13F46B0 Offset: 0x13F46B0 VA: 0x13F46B0
	//private bool AICDDFECEKD(byte GJLFANGDGCL, int CJHEHIMLGGL) { }

	//// RVA: 0x13F46D8 Offset: 0x13F46D8 VA: 0x13F46D8
	//private int DNGKOEDJOBB(int CJHEHIMLGGL) { }

	//// RVA: 0x13EC288 Offset: 0x13EC288 VA: 0x13EC288
	private bool ILDLMKGBKIL(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, EONOEHOKBEB_Music EPMMNEFADAP_MusicInfo, bool JCCBGECHIEI)
	{
		TodoLogger.Log(0, "ILDLMKGBKIL");
		return false;
	}

	//// RVA: 0x13F2428 Offset: 0x13F2428 VA: 0x13F2428
	//private void KJAFCPAFDBK(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, EONOEHOKBEB EPMMNEFADAP) { }

	//// RVA: 0x13F4C3C Offset: 0x13F4C3C VA: 0x13F4C3C
	//private bool CCAMCAEBPFI(int OIPCCBHIKIA, int KIJAPOFAGPN, int HMFFHLPNMPH) { }

	//// RVA: 0x13F2940 Offset: 0x13F2940 VA: 0x13F2940
	//private bool KALFMENHPFE(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, int AKNELONELJK, int PPFNGGCBJKC, int KIJAPOFAGPN, int HMFFHLPNMPH) { }

	//// RVA: 0x13F4CF8 Offset: 0x13F4CF8 VA: 0x13F4CF8
	//private void LIEOONNJFBF(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, EONOEHOKBEB EPMMNEFADAP) { }

	//// RVA: 0x13F4CFC Offset: 0x13F4CFC VA: 0x13F4CFC
	//private void OFFCNFDBNNB(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, EONOEHOKBEB EPMMNEFADAP) { }

	//// RVA: 0x13EF0EC Offset: 0x13EF0EC VA: 0x13EF0EC
	private void EMLKKEHCKMI(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, EONOEHOKBEB_Music EPMMNEFADAP_MusicInfo, bool JCCBGECHIEI)
	{
		if(OMNOFMEBLAD.JPJMALBLKDI_Tutorial < 1)
		{
			EGOLBAPFHHD_Common saveCommon = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common;
			JJOPEDJCCJK_Exp dbExp = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FMPEMFPLPDA_Exp;
			PEBFNABDJDI_System dbSystem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System;
			int v = dbExp.FAANKGOFNGE_GetExp(JGEOBNENMAH.NNDOEOOAMLO_GetMusicStamina(OMNOFMEBLAD, JGEOBNENMAH.KFFCMNELJJB_GetMusicScore(EPMMNEFADAP_MusicInfo, OMNOFMEBLAD.AKNELONELJK_Difficulty, OMNOFMEBLAD.LFGNLKKFOCD_IsLine6)));
			int v2 = 0;
			if (NHPDPKHMFEP.HHCJCDFCLOB != null)
				v2 = NHPDPKHMFEP.HHCJCDFCLOB.PIEFCAPBEAI();
			HBAJPMDOMPL = v2;
			if(v2 > 0)
			{
				v = ((v * v2 * 10) / 100 + 5) / 10 + v;
			}
			if(OMNOFMEBLAD.PMCGHPOGLGM_IsSkip)
			{
				v *= (OMNOFMEBLAD.KAIPAEILJHO_TicketCount < 2 ? 1 : OMNOFMEBLAD.KAIPAEILJHO_TicketCount);
			}
			FOIPBBCHBIB = v;
			int j = saveCommon.KIECDDFNCAN_Level;
			for (int i = saveCommon.ANGGCMBPKKC_AddExp(v, dbExp, dbSystem); i > 0; i--)
			{
				j++;
				if(!JCCBGECHIEI)
				{
					CIOECGOMILE.HHCJCDFCLOB.GIFFIGPKOFE_AddStamina(dbExp.HPEOBAEGHKC_GetStaminaGainForLevel(i));
				}
			}
			PMPBDEJMHOJ_Level = saveCommon.KIECDDFNCAN_Level;
			if(JCCBGECHIEI)
			{
				saveCommon.KIECDDFNCAN_Level = CIOECGOMILE.HHCJCDFCLOB.MNJHBCIIHED_PrevServerData.KCCLEHLLOFG_Common.KIECDDFNCAN_Level;
				saveCommon.EOHDMCMHBKJ_Exp = CIOECGOMILE.HHCJCDFCLOB.MNJHBCIIHED_PrevServerData.KCCLEHLLOFG_Common.EOHDMCMHBKJ_Exp;
			}
		}
	}

	//// RVA: 0x13F1918 Offset: 0x13F1918 VA: 0x13F1918
	//private void LKDINNAPACD(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, EONOEHOKBEB EPMMNEFADAP) { }

	//// RVA: 0x13F102C Offset: 0x13F102C VA: 0x13F102C
	//private void GDIKFPFDJKH(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, EONOEHOKBEB EPMMNEFADAP) { }

	//// RVA: 0x13F0ECC Offset: 0x13F0ECC VA: 0x13F0ECC
	//private bool HMJONPNKLFA(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD) { }

	//// RVA: 0x13EBEB0 Offset: 0x13EBEB0 VA: 0x13EBEB0
	private void LDNMDBMFIIK_UpdateHighScore(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, EONOEHOKBEB_Music EPMMNEFADAP_MusicInfo, bool IKGLAFOHGDO_DoNotSave)
	{
		if(!OMNOFMEBLAD.PMCGHPOGLGM_IsSkip)
		{
			KEODKEGFDLD_FreeMusicInfo freeInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId);
			if(freeInfo.PPEGAKEIEGM_Enabled == 2)
			{
				if(freeInfo.DEPGBBJMFED_CategoryId != 5)
				{
					JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo recordMusic = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId - 1];
					long date = recordMusic.NLIDBKHMBBD_HighScoreDate;
					bool saveScore = false;
					if(date == 0)
					{
						saveScore = true;
					}
					else
					{
						saveScore = recordMusic.IFNDLIGGGHP_HighScoreScore < OMNOFMEBLAD.KNIFCANOHOC_Score;
					}
					if(saveScore && !IKGLAFOHGDO_DoNotSave)
					{
						recordMusic.IFNDLIGGGHP_HighScoreScore = OMNOFMEBLAD.KNIFCANOHOC_Score;
						recordMusic.NOCLBJAGNHD_HighScoreDiff = OMNOFMEBLAD.AKNELONELJK_Difficulty;
						recordMusic.NLIDBKHMBBD_HighScoreDate = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
						recordMusic.AOGEGMMBGEN_HighScoreLine6 = OMNOFMEBLAD.LFGNLKKFOCD_IsLine6 ? 1 : 0;
					}
				}
			}
		}
	}
}
