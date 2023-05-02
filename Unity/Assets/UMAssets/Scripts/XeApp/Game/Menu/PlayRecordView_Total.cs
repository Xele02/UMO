
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PlayRecordView_Total // TypeDefIndex: 13767
	{
		public enum MusicSeries
		{
			First = 0,
			Seven = 1,
			Frontia = 2,
			Delta = 3,
			Plus = 4,
			Max = 5,
		}

		public enum MusicDifficulty
		{
			Easy = 0,
			Normal = 1,
			Hard = 2,
			VelyHard = 3,
			Extreme = 4,
			HardPlus = 5,
			VelyHardPlus = 6,
			ExtremePlus = 7,
			Max = 8,
		}

		public int m_login; // 0x8
		public int m_mission; // 0xC
		public int m_achievement; // 0x10
		public int m_achievement_max; // 0x14
		public int m_music_total; // 0x18
		public int[] m_music_series; // 0x1C
		public int[] m_music_difficulty; // 0x20
		public int m_plate_now; // 0x24
		public int m_plate_max; // 0x28
		public int m_plate_upgrade; // 0x2C
		public int m_plate_premium; // 0x30
		public int m_costume_now; // 0x34
		public int m_costume_max; // 0x38
		public int m_costume_upgrade_now; // 0x3C
		public int m_costume_upgrade_max; // 0x40
		public int m_costume_color_now; // 0x44
		public int m_costume_color_max; // 0x48
		public int m_valkyrie_now; // 0x4C
		public int m_valkyrie_max; // 0x50
		public int m_valkyrie_upgrade_now; // 0x54
		public int m_valkyrie_upgrade_max; // 0x58
		public int m_deco_now; // 0x5C
		public int m_deco_max; // 0x60
		public int m_deco_phrase_now; // 0x64
		public int m_deco_phrase_max; // 0x68
		public int m_deco_interia_now; // 0x6C
		public int m_deco_interia_max; // 0x70
		public int m_deco_bg_now; // 0x74
		public int m_deco_bg_max; // 0x78
		public int m_deco_mascot_now; // 0x7C
		public int m_deco_mascot_max; // 0x80
		public int m_player_level; // 0x84
		public HighScoreRatingRank.Type m_uta_grade; // 0x88

		//// RVA: 0xDE3EC0 Offset: 0xDE3EC0 VA: 0xDE3EC0
		public void Setup(BBHNACPENDM_ServerSaveData a_player_data)
		{
			m_player_level = a_player_data.MHEAEGMIKIE_PublicStatus.KIECDDFNCAN_PLevel;
			m_uta_grade = HighScoreRating.GetUtaGrade(a_player_data.KCCLEHLLOFG_Common.EAHPKPADCPL_TotalUtaRate);
			m_login = a_player_data.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.BJDKMJFCOOM_LCnt;
			m_mission = a_player_data.MHEAEGMIKIE_PublicStatus.APFOBLMCLAO_QCnt;
			Setup_Music(a_player_data);
			Setup_Plate(a_player_data);
			Setup_Valkyrie(a_player_data);
			Setup_Deco(a_player_data);
			Setup_Emblem(a_player_data);
		}

		//// RVA: 0xDE4E74 Offset: 0xDE4E74 VA: 0xDE4E74
		private void Setup_Music(BBHNACPENDM_ServerSaveData a_player_data)
		{
			m_music_total = a_player_data.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.MILCBLJDADN_MusicClear;
			m_music_series = new int[5];
			for(int i = 0; i < a_player_data.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.LHOCOEOKFNO_SerieClear.Length; i++)
			{
				m_music_series[new int[] { 3, 2, 1, 0, 4 }[i]] = a_player_data.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.LHOCOEOKFNO_SerieClear[i];
			}
			m_music_difficulty = new int[8];
			for(int i = 0; i < a_player_data.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.PHPPOGOEOAF_DiffClear.Length; i++)
			{
				m_music_difficulty[i] = a_player_data.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.PHPPOGOEOAF_DiffClear[i];
			}
			m_music_difficulty[5] = a_player_data.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.IAFPEPABGJJ_DiffClear16[2];
			m_music_difficulty[6] = a_player_data.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.IAFPEPABGJJ_DiffClear16[3];
			m_music_difficulty[7] = a_player_data.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.IAFPEPABGJJ_DiffClear16[4];
		}

		//// RVA: 0xDE51BC Offset: 0xDE51BC VA: 0xDE51BC
		private void Setup_Plate(BBHNACPENDM_ServerSaveData a_player_data)
		{
			m_plate_now = 0;
			m_plate_max = 0;
			m_plate_upgrade = 0;
			m_plate_premium = 0;
			MLIBEPGADJH_Scene dbScenes = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene;
			MMPBPOIFDAF_Scene saveScenes = a_player_data.PNLOINMCCKH_Scene;
			for(int i = 0; i < dbScenes.CDENCMNHNGA_SceneList.Count; i++)
			{
				MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = dbScenes.CDENCMNHNGA_SceneList[i];
				if(dbScene.PPEGAKEIEGM_En == 2)
				{
					if(dbScene.DCICNKHCBJK_Support1 > 0)
					{
						m_plate_max++;
						if(i < saveScenes.OPIBAPEGCLA.Count)
						{
							MMPBPOIFDAF_Scene.PMKOFEIONEG saveScene = saveScenes.OPIBAPEGCLA[i];
							if(saveScene.BEBJKJKBOGH_Date != 0)
							{
								m_plate_now++;
								if (dbScenes.ELKHCOEMNOJ(dbScene.BCCHOBPJJKE_Id, saveScene.DMNIMMGGJJJ_Leaf, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver) == 1)
									m_plate_premium++;
								if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LAGGGIEIPEG(dbScene.EKLIPGELKCL_Rarity, true, dbScene.MCCIFLKCNKO_Feed) <=
									saveScene.ANAJIAENLNB_Level)
									m_plate_upgrade++;
							}
						}
					}
				}
			}
		}

		//// RVA: 0xDE5774 Offset: 0xDE5774 VA: 0xDE5774
		private void Setup_Valkyrie(BBHNACPENDM_ServerSaveData a_player_data)
		{
			m_valkyrie_max = 0;
			m_valkyrie_now = 0;
			m_valkyrie_upgrade_max = 0;
			m_valkyrie_upgrade_now = 0;
			for(int i = 0; i < 100; i++)
			{
				JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo dbValk = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_ValkyrieList[i];
				if(dbValk.IPJMPBANBPP_IsEnabled)
				{
					GKFMJAHKEMA_ValSkill.CCPFGNNIBDD valkSkill = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DIAEPFPGPEP_ValSkill.MNHBHNIHJJH(dbValk.BMIJDLBGFNP_SkillId);
					if (valkSkill != null && valkSkill.DOOGFEGEKLG > 0)
						m_valkyrie_upgrade_max++;
					m_valkyrie_max++;
					if(i < a_player_data.JJFFBDLIOCF_Valkyrie.CNGNBKNBKGI_ValkList.Count)
					{
						OIGEIIGKMNH_Valkyrie.HLNPGNNPCGO_ValkyrieInfo saveValk = a_player_data.JJFFBDLIOCF_Valkyrie.CNGNBKNBKGI_ValkList[i];
						if(dbValk.GPPEFLKGGGJ_Id != 1)
						{
							if (!saveValk.FJODMPGPDDD)
								continue;
						}
						m_valkyrie_now++;
						if(valkSkill != null)
						{
							if (valkSkill.DOOGFEGEKLG <= saveValk.CIEOBFIIPLD_Level)
								m_valkyrie_upgrade_now++;
						}
					}
				}
			}
		}

		//// RVA: 0xDE5B1C Offset: 0xDE5B1C VA: 0xDE5B1C
		private void Setup_Deco(BBHNACPENDM_ServerSaveData a_player_data)
		{
			m_deco_bg_now = 0;
			m_deco_bg_max = 0;
			for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GJLHEJPHEDA_ItemsBg.Count; i++)
			{
				NDBFKHKMMCE_DecoItem.EHLEEEBJLAM_BgItem dbItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GJLHEJPHEDA_ItemsBg[i];
				if(dbItem.PLALNIIBLOF == 2)
				{
					m_deco_bg_max++;
					if (dbItem.PPFNGGCBJKC_Id - 1 < a_player_data.OMMNKDEODJP_DecoItem.DJHBDDGEKGO_Bgs.Count)
					{
						if (a_player_data.OMMNKDEODJP_DecoItem.DJHBDDGEKGO_Bgs[dbItem.PPFNGGCBJKC_Id - 1].BFINGCJHOHI_Cnt > 0)
							m_deco_bg_now++;
					}
				}
			}
			m_deco_interia_now = 0;
			m_deco_interia_max = 0;
			for (int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GHOLIPLDMPJ_ItemsObj.Count; i++)
			{
				NDBFKHKMMCE_DecoItem.NIBEBIGPKLA_ObjItem dbItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GHOLIPLDMPJ_ItemsObj[i];
				if (dbItem.PLALNIIBLOF == 2)
				{
					m_deco_interia_max++;
					if (dbItem.PPFNGGCBJKC_Id - 1 < a_player_data.OMMNKDEODJP_DecoItem.KPMFLNOELIN_Objs.Count)
					{
						if (a_player_data.OMMNKDEODJP_DecoItem.KPMFLNOELIN_Objs[dbItem.PPFNGGCBJKC_Id - 1].BFINGCJHOHI_Cnt > 0)
							m_deco_interia_now++;
					}
				}
			}
			m_deco_mascot_now = 0;
			m_deco_mascot_max = 0;
			for (int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK.Count; i++)
			{
				NDBFKHKMMCE_DecoItem.FIDBAFHNGCF dbItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK[i];
				if (dbItem.PLALNIIBLOF == 2 && dbItem.GBJFNGCDKPM == 12)
				{
					m_deco_mascot_max++;
					if (dbItem.PPFNGGCBJKC_Id - 1 < a_player_data.OMMNKDEODJP_DecoItem.NBKAMFFIOOG_Sp.Count)
					{
						if (a_player_data.OMMNKDEODJP_DecoItem.NBKAMFFIOOG_Sp[dbItem.PPFNGGCBJKC_Id - 1].BFINGCJHOHI_Cnt > 0)
							m_deco_mascot_now++;
					}
				}
			}
			m_deco_phrase_now = 0;
			m_deco_phrase_max = 0;
			for (int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.DMKMNGELNAE_Serif.Count; i++)
			{
				IHFIAFDLAAK_DecoStamp.MCBOAJEIFNP dbItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.DMKMNGELNAE_Serif[i];
				if (dbItem.PLALNIIBLOF_Enabled == 2)
				{
					m_deco_phrase_max++;
					if (dbItem.PPFNGGCBJKC - 1 < a_player_data.OMMNKDEODJP_DecoItem.KPMFLNOELIN_Objs.Count)
					{
						if (a_player_data.OMMNKDEODJP_DecoItem.KPMFLNOELIN_Objs[dbItem.PPFNGGCBJKC - 1].BFINGCJHOHI_Cnt > 0)
							m_deco_phrase_now++;
					}
				}
			}
			m_deco_now = m_deco_phrase_now + m_deco_mascot_now + m_deco_interia_now + m_deco_bg_now;
			m_deco_max = m_deco_interia_max + m_deco_phrase_max + m_deco_bg_max + m_deco_mascot_max;
		}

		//// RVA: 0xDE63D0 Offset: 0xDE63D0 VA: 0xDE63D0
		public void Setup_Emblem(BBHNACPENDM_ServerSaveData a_player_data)
		{
			m_achievement_max = 0;
			m_achievement = 0;
			for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBNBNAFGMDE_Emblem.CDENCMNHNGA_EmblemList.Count; i++)
			{
				IHGBPAJMJFK_Emblem.AKJPPHFGEFG_EmblemInfo dbEmblem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBNBNAFGMDE_Emblem.CDENCMNHNGA_EmblemList[i];
				if (dbEmblem.PLALNIIBLOF_En == 2 && dbEmblem.EKLIPGELKCL_Rar > 0)
				{
					m_achievement_max++;
					if (a_player_data.OFAJDLJBMEM_Emblem.MDKOHOCONKE[i].FJODMPGPDDD)
						m_achievement++;
				}
			}
		}
	}
}
