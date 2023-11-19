using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;

namespace ExternLib
{
    public static partial class LibSakasho
    {
		public static void UnlockAll(PlayerData playerData)
		{
			EDOHBJAPLPF_JsonData jsonRes = playerData.serverData;

			BBHNACPENDM_ServerSaveData newData = new BBHNACPENDM_ServerSaveData();
			newData.KHEKNNFCAOI_Init(0xFFFFFFFFFFFFFF);

			Dictionary<string, EDOHBJAPLPF_JsonData> blocks;
			blocks = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject<Dictionary<string, EDOHBJAPLPF_JsonData>>(jsonRes.EJCOJCGIBNG_ToJson());
			newData.IIEMACPEEBJ_Load(blocks.Keys.ToList(), jsonRes);

			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();

			int baseVersion = 1;
			// Config full unlocked profile
			{
				JBMPOAAMGNB_Base baseBlock = newData.LBDOLHGDIEB_GetBlock("base") as JBMPOAAMGNB_Base;
				baseVersion = baseBlock.LLNDMKBBNIJ_Version;
				baseBlock.LLNDMKBBNIJ_Version = JBMPOAAMGNB_Base.JDNKJIFMONK_CurrentVersion;
				baseBlock.PBEKKMOPENN_AgreeTosVer = 1;
				baseBlock.IJHBIMNKOMC_TutorialEnd = 2;
			}
			{
				EGOLBAPFHHD_Common commonBlock = newData.LBDOLHGDIEB_GetBlock("common") as EGOLBAPFHHD_Common;
				// set max level
				commonBlock.KIECDDFNCAN_Level = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.NGHKJOEDLIP.PIAMMJNADJH_PlayerMaxLevel;
				// set max uta grade
				commonBlock.EAHPKPADCPL_TotalUtaRate = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DCNNPEDOGOG_HighScoreRanking.PGHCCAMKCIO.Last().ADKDHKMPMHP_Rate;
				// set uta reward all get
				commonBlock.EAFLCGCIOND_RetRewRecGra = (int)HighScoreRating.GetUtaGrade(commonBlock.EAHPKPADCPL_TotalUtaRate);
				// set master version for shown new song popup
				commonBlock.MMPPEHPKGLI_AddRegularMusicMVer = DIHHCBACKGG_DbSection.IEFOPDOOLOK_MasterVersion;
				// give a lot of stamina
				commonBlock.BCFPEJODJPP_Stamina = 9999;
				// give a lot of mv ticket
				commonBlock.GKKDNOFMJJN_NumTicket = 999;
				// set all 6line & multi diva song shown
				for (int i = 1; i < EGOLBAPFHHD_Common.HKJKONOKBLN_ShowLine6AddLength * 8; i++)
				{
					commonBlock.LIPHECJKIDD(i, true);
				}
				// unlock home bgs
				for(int i = 0; i < commonBlock.POCPLFJCHDD_HomeBg.Count; i++)
				{
					if (commonBlock.POCPLFJCHDD_HomeBg[i].BEBJKJKBOGH_Date == 0)
						commonBlock.POCPLFJCHDD_HomeBg[i].BEBJKJKBOGH_Date = time;
				}
				// Setup a bg
				if(commonBlock.GPHPNEGGGBG_HomeSceneId == 0)
				{
					commonBlock.GPHPNEGGGBG_HomeSceneId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA_Divas[0].CMBCBNEODPD_HomeBgId;
					commonBlock.MDKELFPNCDB_HomeSceneEvolveId = 0;
				}
				commonBlock.ACNNFJJMEEO_StoryEnd = 999;
				commonBlock.ENIPGFLGJHH_LastStory = 999;

				commonBlock.BBFIGEOBOMB_SpItem[7].BFINGCJHOHI_Cnt = 9999999; // deco coin

			}
			{
				FNBIIGJJGKA_Counter counterBlock = newData.LBDOLHGDIEB_GetBlock("counter") as FNBIIGJJGKA_Counter;
				counterBlock.BDLNMOIOMHK_Total.GKOAPFJFKEJ_VOpC[0] = Mathf.Max(50, counterBlock.BDLNMOIOMHK_Total.GKOAPFJFKEJ_VOpC[0]);
			}
			{
				BAHFBCEPFGP_AddMusic addMusicBlock = newData.LBDOLHGDIEB_GetBlock("add_music") as BAHFBCEPFGP_AddMusic;
				for (int i = 1; i < 38 * 8; i++)
				{
					for (int j = 2; j <= 5; j++)
						addMusicBlock.DDCBGCODHHN(i, j);
				}
			}
			{
				NEKDCJKANAH_StoryRecord storyBlock = newData.LBDOLHGDIEB_GetBlock("story_record") as NEKDCJKANAH_StoryRecord;
				LAEGMENIEDB_Story storyDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story;
				for (int i = 0; i < storyDb.CDENCMNHNGA.Count; i++)
				{
					storyBlock.MMKAJBFBKNH[i].EALOBDHOCHP_Stat = 4;
					storyBlock.MMKAJBFBKNH[i].OKJMIFELDMD_Opn = 0xffff;
				}
				storyBlock.EOHHFADHHBL_Complete = true;
			}
			{
				DEKKMGAFJCG_Diva divaBlock = newData.LBDOLHGDIEB_GetBlock("diva") as DEKKMGAFJCG_Diva;
				for (int i = 0; i < divaBlock.NBIGLBMHEDC_DivaList.Count; i++)
				{
					divaBlock.NBIGLBMHEDC_DivaList[i].CPGFPEDMDEH_Have = 1;
					divaBlock.NBIGLBMHEDC_DivaList[i].KCCONFODCPN_IntimacyLevel = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.GLHEHGGKILG_GetMaxLevel();
					divaBlock.NBIGLBMHEDC_DivaList[i].JLEPLIHFPKD_IntimacySkillLevel = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.COHLJLNLBKM.Count - 1;
					for (int j = 0; j < divaBlock.NBIGLBMHEDC_DivaList[i].ANAJIAENLNB_Levels.Count; j++)
						divaBlock.NBIGLBMHEDC_DivaList[i].ANAJIAENLNB_Levels[j] = 8;
					divaBlock.NBIGLBMHEDC_DivaList[i].HEBKEJBDCBH_DivaLevel = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.AGNCAAFGLBE_MaxLevels;
				}
			}
			{
				DDEMMEPBOIA_Sns snsBlock = newData.LBDOLHGDIEB_GetBlock("sns") as DDEMMEPBOIA_Sns;
				int numSns = 0;
				for (int i = 0; i < 2000; i++)
				{
					BOKMNHAFJHF_Sns.KEIGMAOCJHK dbSns = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.CDENCMNHNGA[i];
					if (dbSns.PPEGAKEIEGM_Enabled == 2)
					{
						DDEMMEPBOIA_Sns.EFIFBJGKPJF saveSns = snsBlock.HAJEJPFGILG[i];
						if (saveSns.BEBJKJKBOGH_Date == 0)
						{
							saveSns.BEBJKJKBOGH_Date = time;
						}
						numSns++;
					}
				}
				EGOLBAPFHHD_Common commonBlock = newData.LBDOLHGDIEB_GetBlock("common") as EGOLBAPFHHD_Common;
				commonBlock.JLJJHDGEHLK_RecvSns = numSns;
			}
			{
				MLIBEPGADJH_Scene dbScenes = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene;
				MMPBPOIFDAF_Scene saveScenes = newData.LBDOLHGDIEB_GetBlock("scene") as MMPBPOIFDAF_Scene;
				for (int i = 0; i < dbScenes.CDENCMNHNGA_SceneList.Count; i++)
				{
					MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = dbScenes.CDENCMNHNGA_SceneList[i];
					if (dbScene.PPEGAKEIEGM_En == 2)
					{
						if (i < saveScenes.OPIBAPEGCLA.Count)
						{
							MMPBPOIFDAF_Scene.PMKOFEIONEG saveScene = saveScenes.OPIBAPEGCLA[i];
							if (saveScene.BEBJKJKBOGH_Date == 0)
							{
								saveScene.BEBJKJKBOGH_Date = time;
							}
							saveScene.JPIPENJGGDD_Mlt = 50;
							saveScene.IELENGDJPHF_Ulk = 1;
							saveScene.ANAJIAENLNB_Level = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LAGGGIEIPEG(dbScene.EKLIPGELKCL_Rarity, true, dbScene.MCCIFLKCNKO_Feed) + 1;
							for (int j = 0; j < 15; j++)
								saveScene.PDNIFBEGMHC_Mb[j] = 0;
							for (int j = 0; j < saveScene.ANAJIAENLNB_Level - 1; j++)
							{
								int idx = j / 8;
								int idx2 = j % 8;
								saveScene.PDNIFBEGMHC_Mb[idx] |= (byte)(1 << idx2);
							}
							for (int j = 0; j < 50; j++)
								saveScene.EMOJHJGHJLN_Sb[j] = 0xFF;
							saveScene.DMNIMMGGJJJ_Leaf = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.ELFPIODODFF(dbScene.EKLIPGELKCL_Rarity);
						}
					}
				}
			}
			{
				// posters
				for (int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.COLIEKINOPB_ItemsPoster.Count; i++)
				{
					NDBFKHKMMCE_DecoItem.IEOEMNPLANK_PosterItem item = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.COLIEKINOPB_ItemsPoster[i];
					if (item.PLALNIIBLOF_Enabled == 2)
					{
						BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ saveItem = newData.OMMNKDEODJP_DecoItem.PFNNIMBMKDL_Posters.Find((BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ JPAEDJJFFOI) =>
						{
							//0xE7B830
							return i + 1 == JPAEDJJFFOI.PPFNGGCBJKC_Id;
						});
						if(saveItem != null)
						{			
							if(saveItem.BFINGCJHOHI_Cnt < 1)
							{
								saveItem.PPJAGFPBFHJ(1);
							}
						}
					}
				}
			}
			{
				List<JGGLDGNKELI_Emblem.AAHAAJEJNLJ> saveEmblems = newData.OFAJDLJBMEM_Emblem.MDKOHOCONKE;
				List<IHGBPAJMJFK_Emblem.AKJPPHFGEFG_EmblemInfo> dbEmblem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBNBNAFGMDE_Emblem.CDENCMNHNGA_EmblemList;
				int cnt = saveEmblems.Count;
				if (dbEmblem.Count < cnt)
					cnt = dbEmblem.Count;
				for (int i = 0; i < cnt; i++)
				{
					if (dbEmblem[i].PLALNIIBLOF_En == 2)
					{
						if (saveEmblems[i].BEBJKJKBOGH_Date == 0)
						{
							saveEmblems[i].BEBJKJKBOGH_Date = time;
							saveEmblems[i].FHCAFLCLGAA_Cnt = 1;
						}
					}
				}
			}
			{
				EBFLJMOCLNA_Costume costumeBlock = newData.LBDOLHGDIEB_GetBlock("costume") as EBFLJMOCLNA_Costume;
				LCLCCHLDNHJ_Costume costumeDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume;
				for (int i = 0; i < costumeDb.CDENCMNHNGA_Costumes.Count; i++)
				{
					LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo item = costumeDb.CDENCMNHNGA_Costumes[i];
					if (item.PPEGAKEIEGM_Enabled == 2)
					{
						if (costumeBlock.FABAGMLEKIB_List[i].BEBJKJKBOGH_Date == 0)
						{
							costumeBlock.FABAGMLEKIB_List[i].BEBJKJKBOGH_Date = time;
						}
						costumeBlock.FABAGMLEKIB_List[i].ANAJIAENLNB_Level = costumeDb.CDENCMNHNGA_Costumes[i].LLLCMHENKKN_LevelMax;
					}
				}
				for (int i = 0; i < 30; i++)
				{
					costumeBlock.ILMPHFPFLJE_SetTutoStatus(i, true);
				}
			}
			{
				OIGEIIGKMNH_Valkyrie valkBlock = newData.LBDOLHGDIEB_GetBlock("valkyrie") as OIGEIIGKMNH_Valkyrie;
				GKFMJAHKEMA_ValSkill dbValkSkill = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DIAEPFPGPEP_ValSkill;
				JPIANKEOOMB_Valkyrie dbValk = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie;
				for (int i = 0; i < dbValk.CDENCMNHNGA_ValkyrieList.Count; i++)
				{
					if (dbValk.CDENCMNHNGA_ValkyrieList[i].IPJMPBANBPP_IsEnabled)
					{
						if (valkBlock.CNGNBKNBKGI_ValkList[i].BEBJKJKBOGH_Date == 0)
						{
							valkBlock.CNGNBKNBKGI_ValkList[i].BEBJKJKBOGH_Date = time;
						}
						GKFMJAHKEMA_ValSkill.CCPFGNNIBDD valkSkill = dbValkSkill.MNHBHNIHJJH(dbValk.CDENCMNHNGA_ValkyrieList[i].BMIJDLBGFNP_SkillId);
						if (valkSkill != null && valkSkill.DOOGFEGEKLG > 0)
						{
							valkBlock.CNGNBKNBKGI_ValkList[i].CIEOBFIIPLD_Level = valkSkill.DOOGFEGEKLG;
						}
					}
				}
			}
			{
				OCLHKHAMDHF_Episode epBlock = newData.LBDOLHGDIEB_GetBlock("episode") as OCLHKHAMDHF_Episode;
				KMOGDEOKHPG_Episode dbEp = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode;
				for (int i = 0; i < dbEp.BBAJKJPKOHD_EpisodeList.Count; i++)
				{
					if (dbEp.BBAJKJPKOHD_EpisodeList[i].PPEGAKEIEGM == 2)
					{
						epBlock.BBAJKJPKOHD_EpisodeList[i].EBIIIAELNAA_Step = dbEp.BBAJKJPKOHD_EpisodeList[i].FGOGPCMHPIN_Count - 1;
						if (epBlock.BBAJKJPKOHD_EpisodeList[i].BEBJKJKBOGH_Date == 0)
							epBlock.BBAJKJPKOHD_EpisodeList[i].BEBJKJKBOGH_Date = time;
						for (int j = 0; j < dbEp.BBAJKJPKOHD_EpisodeList[i].FGOGPCMHPIN_Count; j++)
						{
							epBlock.BBAJKJPKOHD_EpisodeList[i].BDPOOJDJKAA_SetRewardReceived(j, true);
						}
					}
				}
			}
			
			// Reset End all normal quest which shouldn't have been, only end beginner quests
			ODPNBADOFAN_Quest saveQuests = newData.LBDOLHGDIEB_GetBlock("quest") as ODPNBADOFAN_Quest;
			for (int i = 0; i < saveQuests.GPMKFMFEKLN_NormalQuests.Count; i++)
			{
				if(baseVersion <= 1)
				{
					saveQuests.GPMKFMFEKLN_NormalQuests[i].EALOBDHOCHP_Stat = 0;
				}
				CNLPPCFJEID_QuestInfo MABBBOEAPAA_dbQuest = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests[i];
				if(ILLPDLODANB.HHMKDAIGMKC_IsDebutMission((ILLPDLODANB.LOEGALDKHPL)MABBBOEAPAA_dbQuest.INDDJNMPONH_Type))
					saveQuests.GPMKFMFEKLN_NormalQuests[i].EALOBDHOCHP_Stat = 3;
			}
			{
				OCMJNBIFJNM_Offer offerBlock = newData.LBDOLHGDIEB_GetBlock("offer") as OCMJNBIFJNM_Offer;
				offerBlock.JLFONLABECA_ShowTuto = -1; // set all tuto read
			}

			// Unlock deco
			{
				BCGFHLIEKLJ_DecoItem decoItem = newData.OMMNKDEODJP_DecoItem;
				for(int i = 0; i < decoItem.PEBDEIKBCCM_Chars.Count; i++)
				{
					if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.KHCACDIKJLG_ItemsChara.Count <= i)
						break;
					if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.KHCACDIKJLG_ItemsChara[i].PLALNIIBLOF_Enabled == 2)
					{
						BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ it = decoItem.PEBDEIKBCCM_Chars[i];
						it.BFINGCJHOHI_Cnt = 1;
					}
				}
			}
			// Unlock deco sp
			{
				for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK_Sp.Count; i++)
				{
					NDBFKHKMMCE_DecoItem.FIDBAFHNGCF dbSp = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK_Sp[i];
					if(dbSp.PLALNIIBLOF_Enabled == 2)
					{
						BCGFHLIEKLJ_DecoItem.GNGFGEIAGJL saveSp = newData.OMMNKDEODJP_DecoItem.NBKAMFFIOOG_Sp[i];
						if(saveSp.BFINGCJHOHI_Cnt == 0)
							saveSp.BFINGCJHOHI_Cnt = 1;
					}
				}
			}

			SerializeServerSave(newData, jsonRes);
		}

        public static int SakashoPlayerDataLoadPlayerData(int callbackId, string json)
        {
            EDOHBJAPLPF_JsonData jsonData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
            EDOHBJAPLPF_JsonData names = jsonData["names"];

			EDOHBJAPLPF_JsonData jsonRes = playerAccount.playerData.serverData;
			List<string> missingBlock = new List<string>();
			if(jsonRes != null)
			{
				for (int i = 0; i < names.HNBFOAJIIAL_Count; i++)
				{
					string str = (string)names[i];
					if (!jsonRes.BBAJPINMOEP_Contains(str))
					{
						TodoLogger.LogError(0, "Server data missing block "+str);
						missingBlock.Add(str);
					}
				}
			}

			bool allBlock = jsonRes == null;

			// Init default profile data
			if (RuntimeSettings.CurrentSettings.EnableProfileSaveCheck)
			{
				SaveAccountServerData(jsonRes, playerAccount.userId, "data_initbckp.json");
			}

			CheckAccountUpdate(playerAccount.userId);
			if(jsonRes == null)
				jsonRes = playerAccount.playerData.serverData;

			SaveAccountServerData();
			if (RuntimeSettings.CurrentSettings.EnableProfileSaveCheck)
			{
				if (allBlock)
				{
					SaveAccountServerData(jsonRes, playerAccount.userId, "data_base.json");
				}
				CheckSaveFile(playerAccount.userId, "data.json", "data_error.json", jsonRes);
			}

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["created_at"] = 1501751856;
			res["data_status"] = 1;
			res["updated_at"] = 1656166393;
			res["player"] = new EDOHBJAPLPF_JsonData();
			res["player"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object);
			for (int i = 0; i < names.HNBFOAJIIAL_Count; i++)
			{
				string str = (string)names[i];
				if(!jsonRes.BBAJPINMOEP_Contains(str))
				{
					UnityEngine.Debug.LogError("player data not found : "+str);
				}
				else
					res["player"][str] = jsonRes[str];
			}

			SendMessage(callbackId, res);
			// end hack

			return 0;
        }

		public static bool CheckSaveFile(int userId, string fileName, string error_filename, EDOHBJAPLPF_JsonData replaceIfDiff = null)
		{
			string path = Application.persistentDataPath + "/Profiles/" + playerAccount.userId.ToString() + "/" +fileName;
			string jsonFile = File.ReadAllText(path);

			// reload and recreate json to remove forced var init in load
			Dictionary<string, EDOHBJAPLPF_JsonData> blocks;
			blocks = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject<Dictionary<string, EDOHBJAPLPF_JsonData>>(jsonFile);

			// Debug, reload and compare
			BBHNACPENDM_ServerSaveData newData_ = new BBHNACPENDM_ServerSaveData();
			newData_.KHEKNNFCAOI_Init(0xFFFFFFFFFFFFFF);
			newData_.IIEMACPEEBJ_Load(blocks.Keys.ToList(), IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(jsonFile));

			EDOHBJAPLPF_JsonData newJson = new EDOHBJAPLPF_JsonData();
			SerializeServerSave(newData_, newJson);
			string newFileName = error_filename;
			SaveAccountServerData(newJson, userId, newFileName);
			path = Application.persistentDataPath + "/Profiles/" + playerAccount.userId.ToString() + "/" +newFileName;
			string jsonFile2 = File.ReadAllText(path);
			if(jsonFile == jsonFile2)
			{
				File.Delete(path);
				return true;
			}
			else
			{
				TodoLogger.LogError(0, "Error in save file check "+ fileName);
				if (replaceIfDiff != null)
				{
					List<string> block = blocks.Keys.ToList();
					for(int i = 0; i < block.Count; i++)
					{
						replaceIfDiff[block[i]] = newJson[block[i]];
					}
				}
				return false;
			}
		}

		public static int SakashoPlayerDataSearchForPlayer(int callbackId, string json)
		{
			//https://sakasho.sp.mbga.jp/v2/player_search?page=1&ipp=40&from=1&to=19&exclude_account_ban=1&key=plv&namespaces=base,public_status&order_by_updated_at=2&_reqid=1654421025
			/*			string result = @"
			{
				""SAKASHO_CURRENT_ASSET_REVISION"": ""20220622141305"",
				""SAKASHO_CURRENT_DATE_TIME"": " + Utility.GetCurrentUnixTime() + @",
				""SAKASHO_CURRENT_MASTER_REVISION"": 5,
				""current_page"": 1,
				""next_page"": 0,
				""players"": [
					{
						""is_friend"": false,
						""player_data"": {
							""base"": {
								""agree_tos_ver"": 1,
								""force_rename"": 0,
								""name"": ""AA"",
								""prof"": ""BB"",
								""rename_date"": 0,
								""rev"": 2,
								""save_id"": 4853,
								""tutorial_end"": 2,
								""ver"": 1

							},
							""public_status"": {
								""assist_data"": {
									""assist_data_list"": [
										{
											""id"": 3313,
											""leaf"": 0,
											""luck"": 0,
											""lv"": 1,
											""mb"": ""//////////////////9/"",
											""mlt"": 1,
											""sb"": ""AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=""

										},
										{
											""id"": 2557,
											""leaf"": 0,
											""luck"": 0,
											""lv"": 1,
											""mb"": ""//////////////8BAAAA"",
											""mlt"": 2,
											""sb"": ""AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=""
										},
										{
											""id"": 746,
											""leaf"": 0,
											""luck"": 0,
											""lv"": 1,
											""mb"": ""//////////////8BAAAA"",
											""mlt"": 1,
											""sb"": ""AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=""
										},
										{
											""id"": 749,
											""leaf"": 0,
											""luck"": 2,
											""lv"": 1,
											""mb"": ""//////////////8BAAAA"",
											""mlt"": 3,
											""sb"": ""/wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=""
										}
									],
									""assist_name"": ""CC""
								},
								""c_col"": 0,
								""c_id"": 0,
								""cos_cnt"": 24,
								""dc_nm"": ""DD"",
								""dc_tm"": 1611282502,
								""df_clr"": [
									20,
									10,
									0,
									0,
									0
								],
								""df_clr_l6"": [
									0,
									0,
									0,
									0,
									0
								],
								""df_fcb"": [
									12,
									0,
									0,
									0,
									0
								],
								""df_fcb_l6"": [
									0,
									0,
									0,
									0,
									0
								],
								""diva_id"": 6,
								""em_cnt"": 0,
								""em_id"": 1,
								""hs_rating"": [
									{
										""df"": [
											0,
											0,
											0,
											1,
											0,
											1,
											0,
											0,
											0,
											0
										],
										""id"": [
											5,
											17,
											59,
											18,
											8,
											23,
											19,
											21,
											24,
											26
										],
										""l6"": [
											0,
											0,
											0,
											0,
											0,
											0,
											0,
											0,
											0,
											0
										],
										""sc"": [
											56,
											47,
											33,
											27,
											24,
											22,
											19,
											19,
											19,
											19
										]
									}
								],
								""lv"": 8,
								""lv_max_cnt"": 17,
								""m_scene"": {
									""id"": 3313,
									""leaf"": 0,
									""luck"": 0,
									""lv"": 1,
									""mb"": ""//////////////////9/"",
									""mlt"": 1,
									""sb"": ""AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=""
								},
								""max_df"": 0,
								""max_id"": 5,
								""max_l6"": 0,
								""max_sc"": 564997,
								""mc_power"": 44864,
								""pf_tap"": 7051,
								""plv"": 11,
								""psh"": 0,
								""q_cnt"": 277,
								""rev"": 2,
								""s_scene"": [
									{
										""id"": 193,
										""leaf"": 0,
										""luck"": 0,
										""lv"": 1,
										""mb"": ""//////////////8BAAAA"",
										""mlt"": 2,
										""sb"": ""AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=""
									},
									{
										""id"": 134,
										""leaf"": 0,
										""luck"": 2,
										""lv"": 1,
										""mb"": ""//////////////8BAAAA"",
										""mlt"": 3,
										""sb"": ""/wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=""
									}
								],
								""save_id"": 7718,
								""scn_cnt"": 1456,
								""t_clr"": 60,
								""utarate_rank"": 241982,
								""vf_cnt"": 7,
								""vf_id"": 1
							}
						},
						""player_id"": 49552951,
						""updated_at"": 1654421023,
						""value"": 11
					}
				],
				""previous_page"": 0
			}";*/

			// Send a copy of the full unlocked account as user data
			EDOHBJAPLPF_JsonData jsonData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			EDOHBJAPLPF_JsonData names = jsonData["names"];

			if(!playerAccount.players.ContainsKey(999999998))
			{
				InitAccount(999999998);
			}

			EDOHBJAPLPF_JsonData jsonRes = playerAccount.players[999999998].serverData;

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["next_page"] = 0;
			res["previous_page"] = 0;
			res["current_page"] = 1;
			res["players"] = new EDOHBJAPLPF_JsonData();
			res["players"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			res["players"].Add(new EDOHBJAPLPF_JsonData());
			res["players"][0].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object);
			res["players"][0]["is_friend"] = false;
			res["players"][0]["player_data"] = new EDOHBJAPLPF_JsonData();
			res["players"][0]["player_data"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object);
			for (int i = 0; i < names.HNBFOAJIIAL_Count; i++)
			{
				string str = (string)names[i];
				res["players"][0]["player_data"][str] = jsonRes[str];
			}

			res["players"][0]["player_id"] = 99999998;
			res["players"][0]["updated_at"] = 1654421023;
			res["players"][0]["value"] = 11; // ??

			SendMessage(callbackId, res);
			return 0;
		}
		static int saveCnt = 0;
		public static int SakashoPlayerDataSavePlayerData(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData msgData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			List<string> blockNames = new List<string>();
			for (int i = 0; i < msgData["names"].HNBFOAJIIAL_Count; i++)
			{
				blockNames.Add((string)msgData["names"][i]);
			}

			if (msgData.BBAJPINMOEP_Contains("playerData"))
			{
				EDOHBJAPLPF_JsonData playerData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject((string)msgData["playerData"]);
				for (int i = 0; i < blockNames.Count; i++)
				{
					if (playerData.BBAJPINMOEP_Contains(blockNames[i]))
					{
						playerAccount.playerData.serverData[blockNames[i]] = playerData[blockNames[i]];
					}
				}

				if (RuntimeSettings.CurrentSettings.EnableProfileSaveCheck)
				{
					SaveAccountServerData(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject((string)msgData["playerData"]), playerAccount.userId, "/data_save_" + saveCnt.ToString() + "_part.json");
					SaveAccountServerData(playerAccount.playerData.serverData, playerAccount.userId, "/data_save_" + saveCnt.ToString() + ".json");
				}

				SaveAccountServerData();
				if (RuntimeSettings.CurrentSettings.EnableProfileSaveCheck)
				{
					CheckSaveFile(playerAccount.userId, "data.json", "/data_save_" + saveCnt.ToString() + "_error.json");
				}

				saveCnt++;
			}

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["created_at"] = 1501751856;
			res["data_status"] = 1;
			res["updated_at"] = 1656166393;
			SendMessage(callbackId, res);
			return 0;
		}
		public static int SakashoPlayerDataGetPlayerData(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData jsonData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			EDOHBJAPLPF_JsonData names = jsonData["names"];
			EDOHBJAPLPF_JsonData ids = jsonData["ids"];


			// Send a copy of the full unlocked account as user data
			for (int i = 0; i < ids.HNBFOAJIIAL_Count; i++)
			{
				int accountId = (int)ids[i];
				if (!playerAccount.players.ContainsKey(accountId))
				{
					InitAccount(accountId);
				}
			}

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["players"] = new EDOHBJAPLPF_JsonData();
			res["players"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			res["players"].Add(new EDOHBJAPLPF_JsonData());
			for (int i = 0; i < ids.HNBFOAJIIAL_Count; i++)
			{
				EDOHBJAPLPF_JsonData jsonRes = playerAccount.players[(int)ids[i]].serverData;
				EDOHBJAPLPF_JsonData p = new EDOHBJAPLPF_JsonData();
				res["players"].Add(p);
				p.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object);
				p["player_data"] = new EDOHBJAPLPF_JsonData();
				p["player_data"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object);
				for (int j = 0; j < names.HNBFOAJIIAL_Count; j++)
				{
					string str = (string)names[j];
					p["player_data"][str] = jsonRes[str];
				}

				p["player_id"] = (int)ids[i];
				p["updated_at"] = 1654421023;
			}


			SendMessage(callbackId, res);
			return 0;
		}

	}
}
