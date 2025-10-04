
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Game;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeSys;

public class LIEJFHMGNIA : EEDKAACNBBG_MusicData
{
	public class AGDCEJNCPDE
	{
		// Fields
		public const int JIKCABGFIEG = 0;
		public const int IPJKMCONMEB = 1;
		public const int EFFOOAJNBKC = 2;
		public const int DDBPGOCNAGL = 4;
		public const int JAOBGNNJFLA = 8;
		public const int KBMMFEFPHMI = 16;
	}

	public static bool DHNMLIJIKNA; // 0x0
	public static bool OJEBNBLHPNP; // 0x1
	public static int IBODEOADPCP; // 0x4
	public int LFLLLOPAKCO_StoryId; // 0x40
	public bool EOBACDCDGOF_IsTerminate; // 0x44
	public bool ENEKMHMKNFK; // 0x45
	public int KLCIIHKFPPO_StoryMusicId; // 0x48
	public int AHHJLDLAPAN_DivaId; // 0x4C
	public bool CADENLBDAEB_IsNew; // 0x50
	public bool BCGLDMKODLC_IsClear; // 0x51
	public int DDNCFHEKBAF_LockCondition; // 0x54
	public string FHPHCFEEBMP; // 0x58
	public bool NDLKPJDHHCN_NotShown; // 0x5C
	public bool DHPNLACAGPG; // 0x5D
	public bool PGCCOCKGCKO; // 0x5E
	public bool MBJOBPJKGBO; // 0x5F
	public bool CGDIFBMIJJH_AddDiva; // 0x60
	public int KEFGPJBKAOD_BgId; // 0x64 WavId
	public int JJPKBHLKILC_BgId; // 0x68
	public bool JJFMMNBEABA_IsStoryEnd; // 0x6C
	public bool ELIHAGFNOBN_IsStoryEndAndCompleted; // 0x6D
	public EJKBKMBJMGL_EnemyData HPBPDHPIBGN_enemy; // 0x70
	public int NDFOAINJPIN_pos; // 0x74
	private int GJIIGKLIGLA; // 0x78

	public bool MMEGDFPNONJ_HasDivaId { get { return AHHJLDLAPAN_DivaId != 0; } } //0x17F754C LCEFNOMFGCC_bgs
	public bool HHBJAEOIGIH_IsLocked { get { return DDNCFHEKBAF_LockCondition != 0; } } //0x17F755C EEGJFFAIOPD_bgs
	public bool PCFICCCLBNP_IsLastStoryAndCompleted { get
		{
			if(BCGLDMKODLC_IsClear)
			{
				return JJFMMNBEABA_IsStoryEnd;
			}
			return false;
		} } //0x17F756C NNCIIIFBKEG_bgs
	//public bool GOELFAECHGI { get; } 0x17F758C AAFHNPBKGCH_bgs

	//// RVA: 0x17F76D8 Offset: 0x17F76D8 VA: 0x17F76D8
	public new void KHEKNNFCAOI_Init(int _LFLLLOPAKCO_StoryId)
	{
		this.LFLLLOPAKCO_StoryId = _LFLLLOPAKCO_StoryId;
		LAEGMENIEDB_Story.ALGOILKGAAH dbStory = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA_table[_LFLLLOPAKCO_StoryId - 1];
		NEKDCJKANAH_StoryRecord.HKDNILFKCFC saveStory = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[_LFLLLOPAKCO_StoryId - 1];
		KLCIIHKFPPO_StoryMusicId = dbStory.KLCIIHKFPPO_StoryMusicId;
		JJPKBHLKILC_BgId = dbStory.JJPKBHLKILC_BgId;
		NDFOAINJPIN_pos = saveStory.NDFOAINJPIN_pos;
		if (dbStory.KLCIIHKFPPO_StoryMusicId < 1)
		{
			if (dbStory.JHPPLIGJFPI < 1)
			{
				if (dbStory.NOCGGJPABMA > 0)
				{
					base.KHEKNNFCAOI_Init(1);
					if (dbStory.NOCGGJPABMA == 2)
						AHHJLDLAPAN_DivaId = 8;
					else if(dbStory.NOCGGJPABMA == 1)
						AHHJLDLAPAN_DivaId = 9;
				}
			}
			else
			{
				base.KHEKNNFCAOI_Init(1);
				AHHJLDLAPAN_DivaId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.GFIPALLLPMF(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.NIKCFOALFJC_diva_1st, dbStory.JHPPLIGJFPI);
			}
		}
		else
		{
			DJNPIGEFPMF_StoryMusicInfo storyMusic = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.CLHIABAKKJM_StoryMusicData[KLCIIHKFPPO_StoryMusicId - 1];
			base.KHEKNNFCAOI_Init(storyMusic.DLAEJOBELBH_MusicId);
			HPBPDHPIBGN_enemy = new EJKBKMBJMGL_EnemyData();
			HPBPDHPIBGN_enemy.KHEKNNFCAOI_Init(storyMusic.LHICAKGHIGF_EnemyIdByDiff[0], storyMusic.LJPKLMJPLAC_DIn[0]);
			AIHCEGFANAM_SerieAttr = storyMusic.DEPGBBJMFED_CategoryId;
			KEFGPJBKAOD_BgId = storyMusic.KEFGPJBKAOD_BgId;
			if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("story_finish_id", 81) == _LFLLLOPAKCO_StoryId)
				JJFMMNBEABA_IsStoryEnd = true;
		}
		HCDGELDHFHB_UpdateStatus();
	}

	//// RVA: 0x17F7FB4 Offset: 0x17F7FB4 VA: 0x17F7FB4
	//public void OIAMHMDHGKE(int _HMFFHLPNMPH_count) { }

	//// RVA: 0x17F810C Offset: 0x17F810C VA: 0x17F810C
	//public void PMBLGPGHNEE(int _HMFFHLPNMPH_count) { }

	//// RVA: 0x17F8138 Offset: 0x17F8138 VA: 0x17F8138
	public static int MGKOEEMNFJD(int _LFLLLOPAKCO_StoryId)
	{
		LAEGMENIEDB_Story.ALGOILKGAAH dbStory = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA_table[_LFLLLOPAKCO_StoryId - 1];
		if (dbStory.PPEGAKEIEGM_Enabled < 2)
			return 16;
		NEKDCJKANAH_StoryRecord.HKDNILFKCFC saveStory = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[_LFLLLOPAKCO_StoryId - 1];
		if(saveStory.NDFOAINJPIN_pos > 1)
		{
			Debug.Log("prevPos=" + (saveStory.NDFOAINJPIN_pos - 1));
			for(int i = 0; i < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH.Count; i++)
			{
				if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[i].NDFOAINJPIN_pos == saveStory.NDFOAINJPIN_pos - 1)
				{
					if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[i].EALOBDHOCHP_stat != 4)
					{
						LAEGMENIEDB_Story.ALGOILKGAAH dbStory2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA_table[CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[i].BMPFHHHCNJC_story_id - 1];
						if (dbStory2.JHPPLIGJFPI < 1)
							return 4;
						if (MGKOEEMNFJD(dbStory2.LFLLLOPAKCO_StoryId) != 0)
							return 4;
					}
					break;
				}
			}
		}
		int a = 0;
		if(dbStory.JIHMAJENMDO_MinLevel > 0)
		{
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KIECDDFNCAN_Level < dbStory.JIHMAJENMDO_MinLevel)
				a = 1;
		}
		if(dbStory.ICKPLIABPKC_FreeMusicId > 0)
		{
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[dbStory.LFLLLOPAKCO_StoryId - 1].EJKHAFIALGK_mclr == 0)
				a |= 2;
		}
		if(dbStory.EPBBNFDFLLD_or != 0)
		{
			if(dbStory.JIHMAJENMDO_MinLevel > 0)
			{
				if (dbStory.ICKPLIABPKC_FreeMusicId > 0 && a - 1 <= 1)
					a = 0;
			}
		}
		return a;
	}

	//// RVA: 0x17F87C8 Offset: 0x17F87C8 VA: 0x17F87C8
	//private void IHKEMKHANHM() { }

	//// RVA: 0x17F7CDC Offset: 0x17F7CDC VA: 0x17F7CDC
	public void HCDGELDHFHB_UpdateStatus()
	{
		if (EOBACDCDGOF_IsTerminate)
			return;
		FHPHCFEEBMP = "";
		CADENLBDAEB_IsNew = false;
		BCGLDMKODLC_IsClear = false;
		NDLKPJDHHCN_NotShown = false;
		DHPNLACAGPG = false;
		MBJOBPJKGBO = false;
		CGDIFBMIJJH_AddDiva = false;
		DDNCFHEKBAF_LockCondition = MGKOEEMNFJD(LFLLLOPAKCO_StoryId);
		NEKDCJKANAH_StoryRecord.HKDNILFKCFC saveStory = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[LFLLLOPAKCO_StoryId - 1];
		if((saveStory.OKJMIFELDMD_Opn & 1) == 0)
		{
			NDLKPJDHHCN_NotShown = true;
			if ((AHHJLDLAPAN_DivaId & 0xfffffffe) == 8)
				CGDIFBMIJJH_AddDiva = true;
		}
		if(DDNCFHEKBAF_LockCondition == 0)
		{
			if((saveStory.OKJMIFELDMD_Opn & 2) == 0)
			{
				DHPNLACAGPG = true;
			}
			if ((saveStory.OKJMIFELDMD_Opn & 8) == 0 && AHHJLDLAPAN_DivaId == 0)
				MBJOBPJKGBO = true;
			if (saveStory.EALOBDHOCHP_stat < 3)
				CADENLBDAEB_IsNew = true;
			else if (saveStory.EALOBDHOCHP_stat != 3)
				BCGLDMKODLC_IsClear = true;
		}
		FLIFKFOGEAM();
	}

	//// RVA: 0x17F9134 Offset: 0x17F9134 VA: 0x17F9134
	public string EJKPLJCMHMP_GetLockDetails()
	{
		LAEGMENIEDB_Story.ALGOILKGAAH dbStory = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA_table[LFLLLOPAKCO_StoryId - 1];
		NEKDCJKANAH_StoryRecord.HKDNILFKCFC saveStory = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[LFLLLOPAKCO_StoryId - 1];
		MessageBank bk = MessageManager.Instance.GetBank("menu");
		MessageBank bk2 = MessageManager.Instance.GetBank("master");
		StringBuilder str = new StringBuilder(200);
		if(AHHJLDLAPAN_DivaId == 0 && dbStory.ICKPLIABPKC_FreeMusicId > 0 && dbStory.JIHMAJENMDO_MinLevel > 0)
		{
			str.Append(bk.GetMessageByLabel("popup_music_unlock_text06"));
			str.Append("\n\n");
		}
		bool b = false;
		if(dbStory.JIHMAJENMDO_MinLevel > 0)
		{
			if(dbStory.ICKPLIABPKC_FreeMusicId < 1)
			{
				str.AppendFormat(bk.GetMessageByLabel("popup_music_unlock_text05"), dbStory.JIHMAJENMDO_MinLevel);
			}
			else
			{
				str.AppendFormat(bk.GetMessageByLabel("popup_music_unlock_text02"), dbStory.JIHMAJENMDO_MinLevel);
			}
			b = true;
		}
		if(dbStory.ICKPLIABPKC_FreeMusicId > 0)
		{
			if(b)
				str.Append("\n\n");
			KEODKEGFDLD_FreeMusicInfo fminfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(dbStory.ICKPLIABPKC_FreeMusicId);
			EONOEHOKBEB_Music minfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fminfo.DLAEJOBELBH_MusicId);
			string musicName = Database.Instance.musicText.Get(minfo.KNMGEEFGDNI_Name).musicName;
			string diffText = bk2.GetMessageByLabel("df_" + dbStory.JOPNDOKOIHI_Difficulty.ToString("00"));
			if(dbStory.GGOCFLLMHPH_Rank < 1)
			{
				str.AppendFormat(bk.GetMessageByLabel("story_unlock_05"), diffText, musicName);
			}
			else
			{
				string rank = "";
				switch(dbStory.GGOCFLLMHPH_Rank)
				{
					case 1:
						rank = "B";
						break;
					case 2:
						rank = "A";
						break;
					case 3:
						rank = "S";
						break;
					case 4:
						rank = "SS";
						break;
					default:
						break;
				}
				str.AppendFormat(bk.GetMessageByLabel("popup_music_unlock_text07"), diffText, rank, musicName);
			}
		}
		//LAB_017f992c
		return str.ToString();
	}

	//// RVA: 0x17F87CC Offset: 0x17F87CC VA: 0x17F87CC
	private void FLIFKFOGEAM()
	{
		LAEGMENIEDB_Story.ALGOILKGAAH dbStory = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA_table[LFLLLOPAKCO_StoryId - 1];
		NEKDCJKANAH_StoryRecord.HKDNILFKCFC asveStory = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[LFLLLOPAKCO_StoryId - 1];
		MessageBank bkMenu = MessageManager.Instance.GetBank("menu");
		MessageBank bkMaster = MessageManager.Instance.GetBank("master");
		if(DDNCFHEKBAF_LockCondition > 3)
		{
			if (((DDNCFHEKBAF_LockCondition / 4) % 2) != 0) // 4-7 / 12-15 / ...
			{
				return;
			}
			FHPHCFEEBMP = bkMaster.GetMessageByLabel("story_unlock_07");
			Debug.Log(FHPHCFEEBMP);
		}
		else
		{
			StringBuilder str = new StringBuilder(200);
			int a = dbStory.JIHMAJENMDO_MinLevel > 0 ? 1 : 0;
			if (dbStory.ICKPLIABPKC_FreeMusicId > 0)
				a += 1;
			if(AHHJLDLAPAN_DivaId == 0)
			{
				if(a != 1)
				{
					str.Append(bkMenu.GetMessageByLabel("story_unlock_03"));
					str.Append("\n\n");
				}
			}
			else if(a != 1)
			{
				str.Append(bkMenu.GetMessageByLabel("story_unlock_11"));
				str.Append("\n\n");
			}
			bool b = false;
			if(dbStory.JIHMAJENMDO_MinLevel > 0)
			{
				str.AppendFormat(bkMenu.GetMessageByLabel("story_unlock_04"), dbStory.JIHMAJENMDO_MinLevel);
				b = true;
			}
			if(dbStory.ICKPLIABPKC_FreeMusicId > 0)
			{
				if (b)
					str.Append("\n");
				KEODKEGFDLD_FreeMusicInfo fm = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(dbStory.ICKPLIABPKC_FreeMusicId);
				EONOEHOKBEB_Music m = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fm.DLAEJOBELBH_MusicId);
				string mname = Database.Instance.musicText.Get(m.KNMGEEFGDNI_Name).musicName;
				string n = bkMaster.GetMessageByLabel("df_" + dbStory.JOPNDOKOIHI_Difficulty.ToString("00"));
				if (dbStory.GGOCFLLMHPH_Rank < 1)
				{
					str.AppendFormat(bkMenu.GetMessageByLabel("story_unlock_05"), n, mname);
				}
				else
				{
					string s = "";
					switch (dbStory.GGOCFLLMHPH_Rank)
					{
						case 1:
							s = "B";
							break;
						case 2:
							s = "A";
							break;
						case 3:
							s = "S";
							break;
						case 4:
							s = "SS";
							break;
						default:
							break;
					}
					str.AppendFormat(bkMenu.GetMessageByLabel("story_unlock_06"), n, s, mname);
				}
			}
			//LAB_017f904c
			FHPHCFEEBMP = str.ToString();
			Debug.Log(FHPHCFEEBMP);
		}
	}

	//// RVA: 0x17F99CC Offset: 0x17F99CC VA: 0x17F99CC
	public void JLHOLHCDELP()
	{
		NEKDCJKANAH_StoryRecord.HKDNILFKCFC saveStory = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[LFLLLOPAKCO_StoryId - 1];
		saveStory.EALOBDHOCHP_stat = 2;
		saveStory.OKJMIFELDMD_Opn |= 7;
		if(AHHJLDLAPAN_DivaId > 0)
		{
			if(!JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA)
			{
				JDDGPJDKHNE.HHCJCDFCLOB.NFNLGGHMEAM();
				JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = true;
			}
			ILCCJNDFFOB.HHCJCDFCLOB.AOPBBHMIEPB_Story(LFLLLOPAKCO_StoryId);
			PGCCOCKGCKO = true;
			DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo dinfo = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[AHHJLDLAPAN_DivaId - 1];
			saveStory.EALOBDHOCHP_stat = 4;
			dinfo.CPGFPEDMDEH_have = 1;
			CADENLBDAEB_IsNew = false;
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.BEKHNNCGIEL_Costume.CGBCFBGJHKC(AHHJLDLAPAN_DivaId);
			KNKDBNFMAKF_EventSp ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp/*7*/, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/) as KNKDBNFMAKF_EventSp;
			if(ev != null)
			{
				ev.HEFIKPAHCIA_UpdateMission(GBNDFCEDNMG.CJDGJFINBFH.KNPBBPNJNEM_18);
				ev.HEFIKPAHCIA_UpdateMission(GBNDFCEDNMG.CJDGJFINBFH.DCFBLGLFJDO_20);
				ev.HEFIKPAHCIA_UpdateMission(GBNDFCEDNMG.CJDGJFINBFH.ADCDEIPMKJI_19);
				QuestUtility.UpdateQuestData(LayoutQuestTab.eTabType.Event);
				QuestUtility.FooterMenuBadge();
			}
			GameManager.Instance.ResetViewPlayerData();
			ILLPDLODANB.MOFIPNGNNPA(ILLPDLODANB.LOEGALDKHPL.FMOCAEEMHFJ/*43*/, 2, false);
		}
		HCDGELDHFHB_UpdateStatus();
	}

	//// RVA: 0x17F9F24 Offset: 0x17F9F24 VA: 0x17F9F24
	public void CPIPDGGOLFO()
	{
		if (!EOBACDCDGOF_IsTerminate)
		{
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[LFLLLOPAKCO_StoryId - 1].OKJMIFELDMD_Opn |= 1;
			HCDGELDHFHB_UpdateStatus();
			if (GNGMCIAIKMA.HHCJCDFCLOB != null)
			{
				GNGMCIAIKMA.HHCJCDFCLOB.HEFIKPAHCIA_UpdateMission(null, -1);
				QuestUtility.UpdateQuestData(LayoutQuestTab.eTabType.Bingo);
				QuestUtility.FooterMenuBadge();
				return;
			}
		}
		else
		{
			NDLKPJDHHCN_NotShown = false;
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.ACNNFJJMEEO_StoryEnd = GJIIGKLIGLA;
		}
	}

	//// RVA: 0x17FA138 Offset: 0x17FA138 VA: 0x17FA138
	public void MFEGPPKFCEI()
	{
		if (EOBACDCDGOF_IsTerminate)
			return;
		CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[LFLLLOPAKCO_StoryId - 1].OKJMIFELDMD_Opn |= 8;
		HCDGELDHFHB_UpdateStatus();
	}

	//// RVA: 0x17FA294 Offset: 0x17FA294 VA: 0x17FA294
	public static int PJIJLMFBBCJ()
	{
		return 1;
	}

	//// RVA: 0x17FA29C Offset: 0x17FA29C VA: 0x17FA29C
	public static List<LIEJFHMGNIA> FKDIMODKKJD_GetList(int KFOLEAPKGFC/* = 0*/, bool _POOMOBGPCNE_IsLocked/* = true*/, bool OKIAAPADPLM/* = true*/, bool HFOAFJBMNOF/* = false*/)
	{
		int storyEnd = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.ACNNFJJMEEO_StoryEnd;
		LAEGMENIEDB_Story.ALGOILKGAAH LODFKHJLGJP = null;
		List<LIEJFHMGNIA> res = new List<LIEJFHMGNIA>();
		int a = 0;
		for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA_table.Count; i++)
		{
			LAEGMENIEDB_Story.ALGOILKGAAH dbStory = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA_table[i];
			if(dbStory.PPEGAKEIEGM_Enabled == 2)
			{
				NEKDCJKANAH_StoryRecord.HKDNILFKCFC saveStory = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[i];
				if(saveStory.EALOBDHOCHP_stat != 0)
				{
					if (storyEnd > 0 && storyEnd != a)
					{
						LODFKHJLGJP = dbStory;
					}
					if (dbStory.NOCGGJPABMA > 0)
						storyEnd++;
					a++;
					if(dbStory.MHPAFEEPBNJ == KFOLEAPKGFC + 1)
					{
						LIEJFHMGNIA data = new LIEJFHMGNIA();
						data.KHEKNNFCAOI_Init(dbStory.LFLLLOPAKCO_StoryId);
						res.Add(data);
					}
				}
			}
		}
		if(LODFKHJLGJP != null)
		{
			LIEJFHMGNIA d = res.Find((LIEJFHMGNIA _GHPLINIACBB_x) =>
			{
				//0x17FE088
				return LODFKHJLGJP.LFLLLOPAKCO_StoryId == _GHPLINIACBB_x.LFLLLOPAKCO_StoryId;
			});
			if (d != null && d.NDLKPJDHHCN_NotShown)
				d.ENEKMHMKNFK = true;
		}
		res.Sort((LIEJFHMGNIA _HKICMNAACDA_a, LIEJFHMGNIA _BNKHBCBJBKI_b) =>
		{
			//0x17FE01C
			return _HKICMNAACDA_a.NDFOAINJPIN_pos.CompareTo(_BNKHBCBJBKI_b.NDFOAINJPIN_pos);
		});
		if (!OKIAAPADPLM)
			return res;
		if(res.Count == 0 || !(
			!res[res.Count - 1].BCGLDMKODLC_IsClear && (res[res.Count - 1].AHHJLDLAPAN_DivaId < 1 || res[res.Count - 1].DDNCFHEKBAF_LockCondition != 0)
			))
		{
			for (int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA_table.Count; i++)
			{
				LAEGMENIEDB_Story.ALGOILKGAAH dbStory = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA_table[i];
				if (dbStory.PPEGAKEIEGM_Enabled == 2)
				{
					NEKDCJKANAH_StoryRecord.HKDNILFKCFC saveStory = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[i];
					if (dbStory.MHPAFEEPBNJ == KFOLEAPKGFC + 1)
					{
						if(saveStory.EALOBDHOCHP_stat == 0)
						{
							if(dbStory.NOCGGJPABMA == 0)
							{
								CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.ODOKNPHEIFN(dbStory.LFLLLOPAKCO_StoryId, 1);
								LIEJFHMGNIA data = new LIEJFHMGNIA();
								data.KHEKNNFCAOI_Init(dbStory.LFLLLOPAKCO_StoryId);
								res.Add(data);
								if (data.DDNCFHEKBAF_LockCondition != 0)
									break;
								if (data.AHHJLDLAPAN_DivaId == 0 && !data.BCGLDMKODLC_IsClear)
									break;
							}
						}
					}
				}
			}
		}
		if(HFOAFJBMNOF)
		{
			FDEGGJPAOHM(res);
			PHNNCGBNCGO(res);
		}
		return res;
	}

	//// RVA: 0x17FB06C Offset: 0x17FB06C VA: 0x17FB06C
	public static void PMBEMMPPNMN(List<LIEJFHMGNIA> NNDGIAEFMOG) 
	{
		LIEJFHMGNIA tmp = NNDGIAEFMOG[NNDGIAEFMOG.Count - 1];
		NNDGIAEFMOG[NNDGIAEFMOG.Count - 1] = NNDGIAEFMOG[NNDGIAEFMOG.Count - 2];
		NNDGIAEFMOG[NNDGIAEFMOG.Count - 2] = tmp;
		LIEJFHMGNIA l = NNDGIAEFMOG.Find((LIEJFHMGNIA _GHPLINIACBB_x) =>
		{
			//0x17FE064
			return _GHPLINIACBB_x.EOBACDCDGOF_IsTerminate;
		});
		if(l == null)
		{
			NEKDCJKANAH_StoryRecord.HKDNILFKCFC s = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[tmp.LFLLLOPAKCO_StoryId - 1];
			int pos = s.NDFOAINJPIN_pos - 1;
			int i;
			for(i = 0; i < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH.Count; i++)
			{
				if(pos != 0 && CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[i].NDFOAINJPIN_pos == pos)
					break;
			}
			NEKDCJKANAH_StoryRecord.HKDNILFKCFC s2 = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[i];
			s2.NDFOAINJPIN_pos = s.NDFOAINJPIN_pos;
			s2.EALOBDHOCHP_stat = 1;
			s2.OKJMIFELDMD_Opn = 1;
			s.NDFOAINJPIN_pos = pos;
		}
		NEKDCJKANAH_StoryRecord.HKDNILFKCFC s3 = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[tmp.LFLLLOPAKCO_StoryId - 1];
		s3.OKJMIFELDMD_Opn |= 1;
		NNDGIAEFMOG[NNDGIAEFMOG.Count - 2].HCDGELDHFHB_UpdateStatus();
		NNDGIAEFMOG[NNDGIAEFMOG.Count - 1].HCDGELDHFHB_UpdateStatus();
	}

	//// RVA: 0x17FAE64 Offset: 0x17FAE64 VA: 0x17FAE64
	public static bool FDEGGJPAOHM(List<LIEJFHMGNIA> NNDGIAEFMOG)
	{
		if(OCIKEFNDJKC(NNDGIAEFMOG, 1))
		{
			LIEJFHMGNIA data = DJAHKAIDCKH(1);
			if(data != null)
			{
				data.CGDIFBMIJJH_AddDiva = true;
				NNDGIAEFMOG.Add(data);
			}
			return true;
		}
		return false;
	}

	//// RVA: 0x17FAF6C Offset: 0x17FAF6C VA: 0x17FAF6C
	public static bool PHNNCGBNCGO(List<LIEJFHMGNIA> NNDGIAEFMOG)
	{
		if (OCIKEFNDJKC(NNDGIAEFMOG, 2))
		{
			LIEJFHMGNIA data = DJAHKAIDCKH(2);
			if (data != null)
			{
				data.CGDIFBMIJJH_AddDiva = true;
				NNDGIAEFMOG.Add(data);
			}
		}
		return false;
	}

	//// RVA: 0x17FB76C Offset: 0x17FB76C VA: 0x17FB76C
	private static bool OCIKEFNDJKC(List<LIEJFHMGNIA> NNDGIAEFMOG, int _INDDJNMPONH_type)
	{
		int cat1Id = 0;
		int cat2Id = 0;
		for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA_table.Count; i++)
		{
			LAEGMENIEDB_Story.ALGOILKGAAH dbStory = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA_table[i];
			if(dbStory.PPEGAKEIEGM_Enabled == 2)
			{
				if(dbStory.NOCGGJPABMA == 1)
				{
					cat1Id = dbStory.LFLLLOPAKCO_StoryId;
				}
				if(dbStory.NOCGGJPABMA == 2)
				{
					cat2Id = dbStory.LFLLLOPAKCO_StoryId;
					break;
				}
			}
		}
		if(_INDDJNMPONH_type == 2)
		{
			if (cat2Id == 0)
				return false;
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[cat1Id - 1].EALOBDHOCHP_stat < 2)
				return false;
			cat1Id = cat2Id;
		}
		else
		{
			if (_INDDJNMPONH_type != 1)
				return false;
			if (cat1Id == 0)
				return false;
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[2].EALOBDHOCHP_stat != 4)
				return false;
		}
		return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[cat1Id - 1].EALOBDHOCHP_stat == 0;
	}

	//// RVA: 0x17FBC28 Offset: 0x17FBC28 VA: 0x17FBC28
	private static LIEJFHMGNIA DJAHKAIDCKH(int _INDDJNMPONH_type)
	{
		int cat1Id = 0;
		int cat2Id = 0;
		for (int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA_table.Count; i++)
		{
			LAEGMENIEDB_Story.ALGOILKGAAH dbStory = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA_table[i];
			if (dbStory.PPEGAKEIEGM_Enabled == 2)
			{
				if (dbStory.NOCGGJPABMA == 1)
				{
					cat1Id = dbStory.LFLLLOPAKCO_StoryId;
				}
				if (dbStory.NOCGGJPABMA == 2)
				{
					cat2Id = dbStory.LFLLLOPAKCO_StoryId;
					break;
				}
			}
		}
		if (_INDDJNMPONH_type == 2)
		{
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[cat1Id - 1].EALOBDHOCHP_stat < 2)
				return null;
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[cat2Id - 1].EALOBDHOCHP_stat != 0)
				return null;
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.ODOKNPHEIFN(cat2Id, 1);
			cat1Id = cat2Id;
		}
		else
		{
			if (_INDDJNMPONH_type != 1)
				return null;
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[cat1Id - 1].EALOBDHOCHP_stat != 0)
				return null;
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.ODOKNPHEIFN(cat1Id, 1);
		}
		LIEJFHMGNIA data = new LIEJFHMGNIA();
		data.KHEKNNFCAOI_Init(cat1Id);
		return data;
	}

	//// RVA: 0x17FC24C Offset: 0x17FC24C VA: 0x17FC24C
	//public static void PJHMKEGKMGH(List<LIEJFHMGNIA> NNDGIAEFMOG, bool OKIAAPADPLM) { }

	//// RVA: 0x17FC808 Offset: 0x17FC808 VA: 0x17FC808
	//public static int GOLBKEOBAOH(List<LIEJFHMGNIA> NNDGIAEFMOG) { }

	//// RVA: 0x17FC8E0 Offset: 0x17FC8E0 VA: 0x17FC8E0
	//public static int GIEHPDAHFJE(List<LIEJFHMGNIA> NNDGIAEFMOG) { }

	//// RVA: 0x17FC9BC Offset: 0x17FC9BC VA: 0x17FC9BC
	//public static void BPFPIOLIOEM(List<LIEJFHMGNIA> NNDGIAEFMOG) { }

	//// RVA: 0x17FCAD8 Offset: 0x17FCAD8 VA: 0x17FCAD8
	//public static int DKOPDAPDKHE(List<LIEJFHMGNIA> NNDGIAEFMOG) { }

	//// RVA: 0x17FCBB4 Offset: 0x17FCBB4 VA: 0x17FCBB4
	//public static int BKCFCGKBCDC(List<LIEJFHMGNIA> NNDGIAEFMOG) { }

	//// RVA: 0x17FCD28 Offset: 0x17FCD28 VA: 0x17FCD28
	//public static void BELAIBFFJNF(List<LIEJFHMGNIA> NNDGIAEFMOG) { }

	//// RVA: 0x17FCE44 Offset: 0x17FCE44 VA: 0x17FCE44
	//public static int AHJNFDFPCBH(List<LIEJFHMGNIA> NNDGIAEFMOG) { }

	//// RVA: 0x17FCF20 Offset: 0x17FCF20 VA: 0x17FCF20
	//public string MNNKOKNBJNC() { }

	//// RVA: 0x17FD51C Offset: 0x17FD51C VA: 0x17FD51C
	//public static int KLOHKIPGCME(List<LIEJFHMGNIA> NNDGIAEFMOG) { }

	//// RVA: 0x17FD644 Offset: 0x17FD644 VA: 0x17FD644
	public static LIEJFHMGNIA HDKCNAKPAAC(FDDIIKBJNNA ANJGLKIGLAN)
	{
		List<LIEJFHMGNIA> l = FKDIMODKKJD_GetList(0, false, false, false);
		for(int i = 0; i < l.Count; i++)
		{
			if(l[i].CADENLBDAEB_IsNew)
			{
				return l[i];
			}
		}
		return null;
	}

	//// RVA: 0x17FD794 Offset: 0x17FD794 VA: 0x17FD794
	public static int CCOJMPONIOC()
	{
		int res = 0;
		for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA_table.Count; i++)
		{
			LAEGMENIEDB_Story.ALGOILKGAAH dbStory = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA_table[i];
			if (dbStory.PPEGAKEIEGM_Enabled == 2)
			{
				if(dbStory.NOCGGJPABMA < 1)
				{
					if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[i].EALOBDHOCHP_stat < 4)
						return 0;
					res++;
				}
			}
		}
		return res;
	}

	//// RVA: 0x17FDA24 Offset: 0x17FDA24 VA: 0x17FDA24
	public static bool OCHGOAKIPPM(List<LIEJFHMGNIA> DJPCNPLJJAF)
	{
		if(DJPCNPLJJAF.Count != 0)
		{
			if (!DJPCNPLJJAF[DJPCNPLJJAF.Count - 1].EOBACDCDGOF_IsTerminate)
			{
				if(!DJPCNPLJJAF[DJPCNPLJJAF.Count - 1].BCGLDMKODLC_IsClear || !DJPCNPLJJAF[DJPCNPLJJAF.Count - 1].JJFMMNBEABA_IsStoryEnd)
				{
					int a = CCOJMPONIOC();
					if (a > 0)
					{
						LIEJFHMGNIA data = new LIEJFHMGNIA();
						data.EOBACDCDGOF_IsTerminate = true;
						data.NDFOAINJPIN_pos = 10000;
						data.GJIIGKLIGLA = a;
						data.NDLKPJDHHCN_NotShown = data.NNPFKBOJBCI(a);
						for(int i = a + 1; i - 2 >= 0; i--)
						{
							if (!DJPCNPLJJAF[i - 2].CGDIFBMIJJH_AddDiva)
								DJPCNPLJJAF.Insert(i, data);
						}
					}
				}
			}
			return true;
		}
		return false;
	}

	//// RVA: 0x17FDD2C Offset: 0x17FDD2C VA: 0x17FDD2C
	public static bool DJMAJKMBJNE(List<LIEJFHMGNIA> DJPCNPLJJAF)
	{
		if (DJPCNPLJJAF.Count == 0)
			return false;
		if(!DJPCNPLJJAF[DJPCNPLJJAF.Count - 1].EOBACDCDGOF_IsTerminate)
		{
			if(DJPCNPLJJAF[DJPCNPLJJAF.Count - 1].BCGLDMKODLC_IsClear && DJPCNPLJJAF[DJPCNPLJJAF.Count - 1].JJFMMNBEABA_IsStoryEnd)
			{
				LIEJFHMGNIA data = new LIEJFHMGNIA();
				data.BCGLDMKODLC_IsClear = true;
				data.ELIHAGFNOBN_IsStoryEndAndCompleted = true;
				data.JJFMMNBEABA_IsStoryEnd = true;
				data.EOBACDCDGOF_IsTerminate = false;
				data.NDFOAINJPIN_pos = 10000;
				data.GJIIGKLIGLA = DJPCNPLJJAF.Count + 1;
				data.NDLKPJDHHCN_NotShown = false;
				DJPCNPLJJAF.Add(data);
			}
		}
		return true;
	}

	//// RVA: 0x17F7FE0 Offset: 0x17F7FE0 VA: 0x17F7FE0
	private bool NNPFKBOJBCI(int _HMFFHLPNMPH_count)
	{
		if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.ACNNFJJMEEO_StoryEnd < 1)
			return true;
		return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.ACNNFJJMEEO_StoryEnd < _HMFFHLPNMPH_count;
	}
}
