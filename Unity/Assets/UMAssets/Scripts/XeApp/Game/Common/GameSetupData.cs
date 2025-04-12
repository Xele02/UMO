using System;
using XeApp.Game.Menu;

namespace XeApp.Game.Common
{
	public class GameSetupData
	{

		public class TeamInfo
		{
			public class DivaInfo
			{
				public int divaId { get; set; } // 0x8
				public int prismDivaId { get; set; } // 0xC
				public int costumeModelId { get; set; } // 0x10
				public int prismCostumeModelId { get; set; } // 0x14
				public int costumeColorId { get; set; } // 0x18
				public int prismCostumeColorId { get; set; } // 0x1C
				public int[] sceneIdList { get; set; } // 0x20
				public int[] liveSkillIdList { get; set; } // 0x24
				public int[] liveSkillLevelList { get; set; } // 0x28
				public int activeSkillId { get; set; } // 0x2C
				public int activeSkillLevel { get; set; } // 0x30
				public int positionId { get; set; } // 0x34
				public int intimacyLv { get; set; } // 0x38

				// // RVA: 0xE9E780 Offset: 0xE9E780 VA: 0xE9E780
				public void OnAppBoot()
				{
					Initialize();
				}

				// // RVA: 0xEA02C8 Offset: 0xEA02C8 VA: 0xEA02C8
				private void Initialize()
				{
					costumeModelId = 0;
					divaId = 0;
					positionId = 0;
					sceneIdList = new int[9];
					liveSkillIdList = new int[9];
					liveSkillLevelList = new int[9];
					activeSkillId = 0;
					activeSkillLevel = 0;
				}

				// // RVA: 0xE9F6C0 Offset: 0xE9F6C0 VA: 0xE9F6C0
				public void SetupInfo(FFHPBEPOMAK_DivaInfo viewDivaData, DFKGGBMFFGB_PlayerInfo playerData, EEDKAACNBBG_MusicData musicData, AOJGDNFAIJL_PrismData.AMIECPBIALP prismData, int index, int positionId = 1)
				{
					Initialize();
					this.positionId = positionId;
					if(prismData != null && prismData.FBGAKINEIPG)
					{
						SetupPrismInfo(prismData, index);
					}
					if(viewDivaData != null)
					{
						divaId = viewDivaData.AHHJLDLAPAN_DivaId;
						costumeModelId = viewDivaData.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId;
						costumeColorId = viewDivaData.EKFONBFDAAP_ColorId;
						JJOELIOGMKK_DivaIntimacyInfo d = new JJOELIOGMKK_DivaIntimacyInfo();
						d.KHEKNNFCAOI(divaId);
						d.HCDGELDHFHB(false);
						intimacyLv = d.HEKJGCMNJAB_CurrentLevel;
						if(prismData == null || !prismData.FBGAKINEIPG)
						{
							prismDivaId = divaId;
							prismCostumeModelId = costumeModelId;
							prismCostumeColorId = costumeColorId;
						}
						int[] vals = new int[3];
						vals[0] = viewDivaData.FGFIBOBAPIA_SceneId;
						vals[1] = viewDivaData.DJICAKGOGFO_SubSceneIds[0];
						vals[2] = viewDivaData.DJICAKGOGFO_SubSceneIds[1];
						for(int i = 0; i < 3; i++)
						{
							sceneIdList[i] = vals[i];
							if(vals[i] > 0)
							{
								int skillId = playerData.OPIBAPEGCLA_Scenes[vals[i] - 1].FILPDDHMKEJ_GetLiveSkillId(false, musicData != null ? musicData.FKDCCLPGKDK_JacketAttr : 0, musicData != null ? musicData.AIHCEGFANAM_Serie : 0);
								bool lives = CheckLiveSkill(musicData, skillId);
								bool b = playerData.OPIBAPEGCLA_Scenes[vals[i] - 1].DCLLIDMKNGO_IsDivaCompatible(divaId);
								bool c = i != 0 || index != 0;
								if (c)
									b = b & lives;
								if(!c || b)
								{
									liveSkillIdList[i] = skillId;
									liveSkillLevelList[i] = playerData.OPIBAPEGCLA_Scenes[vals[i] - 1].AADFFCIDJCB_LiveSkillLevel;
								}
								if(i == 0)
								{
									activeSkillId = playerData.OPIBAPEGCLA_Scenes[vals[i] - 1].HGONFBDIBPM_ActiveSkillId;
									activeSkillLevel = playerData.OPIBAPEGCLA_Scenes[vals[i] - 1].PNHJPCPFNFI_ActiveSkillLevel;
								}
							}
						}
					}
				}

				// // RVA: 0xE9FBE0 Offset: 0xE9FBE0 VA: 0xE9FBE0
				public void SetupGoDivaInfo(FFHPBEPOMAK_DivaInfo viewDivaData, DFKGGBMFFGB_PlayerInfo playerData, EEDKAACNBBG_MusicData musicData, AOJGDNFAIJL_PrismData.AMIECPBIALP prismData, int index, int positionId/* = 1*/)
				{
					if(viewDivaData != null)
					{
						int[] vals = new int[3]
						{
							viewDivaData.FGFIBOBAPIA_SceneId,
							viewDivaData.DJICAKGOGFO_SubSceneIds[0],
							viewDivaData.DJICAKGOGFO_SubSceneIds[1]
						};
						for(int i = 0; i < 3; i++)
						{
							sceneIdList[index * 3 + i] = vals[i];
							if(vals[i] > 0)
							{
								int skillId = playerData.OPIBAPEGCLA_Scenes[vals[i] - 1].FILPDDHMKEJ_GetLiveSkillId(false, musicData == null ? 0 : musicData.FKDCCLPGKDK_JacketAttr, musicData == null ? 0 : musicData.AIHCEGFANAM_Serie);
								if(CheckLiveSkill(musicData, skillId) && 
									playerData.OPIBAPEGCLA_Scenes[vals[i] - 1].DCLLIDMKNGO_IsDivaCompatible(divaId))
								{
									liveSkillIdList[index * 3 + i] = skillId;
									liveSkillLevelList[index * 3 + i] = playerData.OPIBAPEGCLA_Scenes[vals[i] - 1].AADFFCIDJCB_LiveSkillLevel;
								}
							}
						}
					}
				}

				// // RVA: 0xEA051C Offset: 0xEA051C VA: 0xEA051C
				private bool CheckLiveSkill(EEDKAACNBBG_MusicData musicData, int a_l_skill_id)
				{
					if (a_l_skill_id < 1)
						return false;
					PPGHMBNIAEC skill = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[a_l_skill_id - 1];
					if (skill.AANDPLGPDEI())
					{
						if (!skill.HDPIEILADDH(musicData.DLAEJOBELBH_MusicId))
							return false;
					}
					if(skill.HCGDJAFINMH())
					{
						return skill.OEJNKFONOGJ(musicData.FKDCCLPGKDK_JacketAttr);
					}
					return true;
				}

				// // RVA: 0xE9FFC0 Offset: 0xE9FFC0 VA: 0xE9FFC0
				public void SetupMvInfo(AOJGDNFAIJL_PrismData.AMIECPBIALP prismData, int a_index)
				{
					Initialize();
					SetupPrismInfo(prismData, a_index);
					positionId = a_index + 1;
					divaId = prismDivaId;
					costumeModelId = prismCostumeModelId;
					costumeColorId = prismCostumeColorId;
				}

				// // RVA: 0xEA0368 Offset: 0xEA0368 VA: 0xEA0368
				private void SetupPrismInfo(AOJGDNFAIJL_PrismData.AMIECPBIALP prismData, int index)
				{
					if(prismData.PNBKLGKCKGO_GetPrismDivaIdForSlot(index) > 0)
					{
						prismDivaId = prismData.PNBKLGKCKGO_GetPrismDivaIdForSlot(index);
					}
					if(prismData.OCNHIHMAGMJ_GetPrismCostumeIdForSlot(index) > 0)
					{
						prismCostumeModelId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes[prismData.OCNHIHMAGMJ_GetPrismCostumeIdForSlot(index) - 1].DAJGPBLEEOB_PrismCostumeModelId;
						prismCostumeColorId = prismData.DOIGAGAAAOP_GetPrismCostumeColorIdForSlot(index);
					}
				}

				// // RVA: 0xEA000C Offset: 0xEA000C VA: 0xEA000C
				public void SetForcePrismData(AIPEHINPIHC_ForcedSettingInfo a_prism, int a_index)
				{
					if (a_prism.AHHJLDLAPAN_DivaId.Length <= a_index)
						return;
					if(a_prism.AHHJLDLAPAN_DivaId[a_index] > 0 && a_prism.JPIDIENBGKH_CostumeId[a_index] > 0)
					{
						prismDivaId = a_prism.AHHJLDLAPAN_DivaId[a_index];
						prismCostumeModelId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes[a_prism.JPIDIENBGKH_CostumeId[a_index] - 1].DAJGPBLEEOB_PrismCostumeModelId;
						prismCostumeColorId = 0;
					}
				}

				// // RVA: 0xEA0730 Offset: 0xEA0730 VA: 0xEA0730
				public void SetPositionId(int position_id)
				{
					positionId = position_id;
				}

				// // RVA: 0xEA0738 Offset: 0xEA0738 VA: 0xEA0738
				// public void ApplyCenterSpecialRules() { }
			}

			private DivaInfo[] divaList_ = new DivaInfo[3]; // 0x8
			private DivaInfo[] danceDivaList_ = new DivaInfo[5]; // 0xC
			private int teamLuck_; // 0x20
			private int excellentRate_; // 0x24
			private int excellentScoreAdd_; // 0x28
			private int centerLiveSkillRate_; // 0x2C
			public bool isPrismEnable; // 0x30

			public DivaInfo[] divaList { get { return divaList_; } set { divaList_ = value; } } // get_divaList 0xE9E350 set_divaList 0xE9E358
			public DivaInfo[] danceDivaList { get { return danceDivaList_; } set { danceDivaList_ = value; } } // get_danceDivaList 0xE9E360 set_danceDivaList 0xE9E368
			public int valkyrieId { get; set; } // 0x10 
			public int prismValkyrieId { get; set; } // 0x14
			public int valkyrieForm { get; set; } // 0x18
			public StatusData teamStatus { get; set; } // 0x1C
			public int teamLuck { get { return teamLuck_ ^ 0x4e8bf5d; } set { teamLuck_ = value ^ 0x4e8bf5d; } } // get_teamLuck 0xE9E3B0 set_teamLuck 0xE9E3C4
			public int excellentRate { get { return excellentRate_ ^ 0xda76a15; } set { excellentRate_ = value ^ 0xda76a15; } } // get_excellentRate 0xE9E3D8 set_excellentRate 0xE9E3EC 
			public int excellentScoreAdd { get { return excellentScoreAdd_ ^ 0xc0ae7; } set { excellentScoreAdd_= value  ^ 0xc0ae7; } } // get_excellentScoreAdd 0xE9E400 set_excellentScoreAdd 0xE9E414
			public int centerLiveSkillRate { get { return centerLiveSkillRate_ ^ 0x768078; } set { centerLiveSkillRate_= value  ^ 0x768078; } } // get_centerLiveSkillRate 0xE9E428 set_centerLiveSkillRate 0xE9E43C

			// // RVA: 0xE9CAD4 Offset: 0xE9CAD4 VA: 0xE9CAD4
			public void OnAppBoot()
			{
				Initialize();
			}

			// // RVA: 0xE9E450 Offset: 0xE9E450 VA: 0xE9E450
			private void Initialize()
			{
				for(int i = 0; i < 3; i++)
				{
					divaList[i] = new DivaInfo();
					divaList[i].OnAppBoot();
				}
				for(int i = 0; i < 5; i++)
				{
					if(i < 3)
					{
						danceDivaList_[i] = divaList[i];
					}
					else
					{
						danceDivaList_[i] = new DivaInfo();
						danceDivaList_[i].OnAppBoot();
					}
				}
				valkyrieForm = 0;
				valkyrieId = 0;
				teamStatus = new StatusData();
				teamStatus.Clear();
				isPrismEnable = false;
				teamLuck = 0;
				excellentRate = 0;
				excellentScoreAdd = 0;
				centerLiveSkillRate = 0;
			}

			// // RVA: 0xE9E784 Offset: 0xE9E784 VA: 0xE9E784
			public void SetupInfo(StatusData teamStateus, DFKGGBMFFGB_PlayerInfo playerData, int teamNo, EEDKAACNBBG_MusicData musicData, EAJCBFGKKFA_FriendInfo friendData, LimitOverStatusData limitOverStatus, AOJGDNFAIJL_PrismData.AMIECPBIALP prismData, bool isGoDiva = false)
			{
				Initialize();
				StatusData status = new StatusData();
				JLKEOGLJNOD_TeamInfo unit = playerData.DPLBHAIKPGL_GetTeam(isGoDiva);
				int luck = 0;
				if (!isGoDiva)
				{
					for(int i = 0; i < unit.BCJEAJPLGMB_MainDivas.Count; i++)
					{
						divaList_[i].SetupInfo(playerData.DPLBHAIKPGL_GetTeam(isGoDiva).BCJEAJPLGMB_MainDivas[i], playerData, musicData, prismData, i, i + 1);
						if(playerData.DPLBHAIKPGL_GetTeam(isGoDiva).BCJEAJPLGMB_MainDivas[i] != null)
						{
							luck += DivaIconDecoration.GetEquipmentLuck(playerData.DPLBHAIKPGL_GetTeam(isGoDiva).BCJEAJPLGMB_MainDivas[i], playerData);
						}
					}
				}
				else
				{
					for(int i = 0; i < unit.BCJEAJPLGMB_MainDivas.Count; i++)
					{
						if(i == 0)
						{
							divaList_[0].SetupInfo(unit.BCJEAJPLGMB_MainDivas[i], playerData, musicData, prismData, 0, i + 1);
							if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System != null)
							{
								int godiva_fold_correction_value = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("godiva_fold_correction_value", 300);
								int godiva_support_correction_value = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("godiva_support_correction_value", 300);
								int i4 = Math.Max(unit.BCJEAJPLGMB_MainDivas[i].JLJGCBOHJID_Status.fold - playerData.AHEFHIMGIBI_ServerSave.BEKHNNCGIEL_Costume.NNIKNCGNDHK_GetStatForDiva(unit.BCJEAJPLGMB_MainDivas[i].AHHJLDLAPAN_DivaId).fold, 0);
								int i5 = Math.Max(unit.BCJEAJPLGMB_MainDivas[i].JLJGCBOHJID_Status.support - playerData.AHEFHIMGIBI_ServerSave.BEKHNNCGIEL_Costume.NNIKNCGNDHK_GetStatForDiva(unit.BCJEAJPLGMB_MainDivas[i].AHHJLDLAPAN_DivaId).support, 0);
								status.fold = (int)(godiva_fold_correction_value / 100.0f * i4) - i4;
								status.support = (int)(godiva_support_correction_value / 100.0f * i5) - i5;
							}
						}
						else
						{
							divaList_[0].SetupGoDivaInfo(unit.BCJEAJPLGMB_MainDivas[i], playerData, musicData, prismData, i, i + 1);
						}
						if(unit.BCJEAJPLGMB_MainDivas[i] != null)
						{
							luck += DivaIconDecoration.GetEquipmentLuck(playerData.DPLBHAIKPGL_GetTeam(isGoDiva).BCJEAJPLGMB_MainDivas[i], playerData);
						}
					}
				}
				for(int i = 0; i < divaList_.Length; i++)
				{
					danceDivaList_[i] = divaList_[i];
				}
				if(unit.CMOPCCAJAAO_AddDivas != null)
				{
					for (int i = 0; i < unit.CMOPCCAJAAO_AddDivas.Count; i++)
					{
						danceDivaList_[i + divaList_.Length].SetupInfo(unit.CMOPCCAJAAO_AddDivas[i], playerData, musicData, prismData, i + divaList_.Length, i + divaList_.Length + 1);
					}
				}
				if(friendData != null && friendData.KHGKPKDBMOH_GetAssistScene() != null)
				{
					luck += friendData.KHGKPKDBMOH_GetAssistScene().MJBODMOLOBC_Luck;
				}
				valkyrieId = 1;
				int form = 0;
				if (unit.JOKFNBLEILN_Valkyrie != null)
				{
					valkyrieId = unit.JOKFNBLEILN_Valkyrie.GPPEFLKGGGJ_ValkyrieId;
					form = unit.JOKFNBLEILN_Valkyrie.GCCNMFHELCB_Form;
				}
				prismValkyrieId = valkyrieId;
				valkyrieForm = form;
				if(prismData != null && prismData.FBGAKINEIPG)
				{
					prismValkyrieId = prismData.FBAGIDFLHHI_PrismValkyrieId;
					isPrismEnable = true;
				}
				teamStatus = new StatusData();
				teamStatus.Copy(teamStateus);
				teamStatus.Add(status);
				teamLuck = luck;
				if(limitOverStatus != null)
				{
					excellentRate = limitOverStatus.excellentRate_SameMusicAttr + limitOverStatus.excellentRate + limitOverStatus.excellentRate_SameSeriesAttr;
					excellentScoreAdd = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.LPJLEHAJADA("ex_effect", 0);
					if(divaList_[0].liveSkillIdList[0] > 0)
					{
						centerLiveSkillRate = limitOverStatus.centerLiveSkillRate_SameMusicAttr + limitOverStatus.centerLiveSkillRate + limitOverStatus.centerLiveSkillRate_SameSeriesAttr;
					}
				}
				UnityEngine.Debug.Log(string.Concat(new object[6] { JpStringLiterals.StringLiteral_13975, excellentRate, ", " + JpStringLiterals.StringLiteral_13976, excellentScoreAdd, ", " + JpStringLiterals.StringLiteral_13977, centerLiveSkillRate }));
			}

			// // RVA: 0xE9CDAC Offset: 0xE9CDAC VA: 0xE9CDAC
			public void SetupMvInfo(StatusData teamStateus, AOJGDNFAIJL_PrismData.AMIECPBIALP info)
			{
				Initialize();
				for(int i = 0; i < 5; i++)
				{
					danceDivaList_[i].SetupMvInfo(info, i);
				}
				valkyrieId = info.PNDKNFBLKDP_GetPrismValkyrieId();
				prismValkyrieId = info.PNDKNFBLKDP_GetPrismValkyrieId();
				teamStatus = new StatusData();
				teamStatus.Copy(teamStateus);
				teamLuck = 0;
			}

			// // RVA: 0xE9D15C Offset: 0xE9D15C VA: 0xE9D15C
			public void SetForcePrismData(AIPEHINPIHC_ForcedSettingInfo a_prism)
			{
				divaList_[0].SetForcePrismData(a_prism, 0);
				divaList_[1].SetForcePrismData(a_prism, 1);
				divaList_[2].SetForcePrismData(a_prism, 2);
				if(a_prism.GPPEFLKGGGJ_ValkyrieId > 0)
				{
					prismValkyrieId = a_prism.GPPEFLKGGGJ_ValkyrieId;
				}
			}
		}

		public class MusicInfo
		{
			public struct InitFreeMusicParam
			{
				public bool isDisableBattleEventIntermediateResult; // 0x0
				public TransitionUniqueId returnTransitionUniqueId; // 0x4
			}

			private int m_prismMusicId; // 0x30
			
			public GameMode.Type mode { get; set; } // 0x8
			public bool IsMvMode { get; set; } // 0xC
			public bool IsLine6Mode { get; set; } // 0xD
			public long setupTime { get; set; } // 0x10
			public long mvLimitTime { get; set; } // 0x18
			public long LimitTime { get; set; } // 0x20
			public TutorialGameMode.Type tutorial { get; set; } // 0x28
			public int musicId { get; set; } // 0x2C
			public int prismMusicId { get {
				if(m_prismMusicId < 1)
					return musicId;
				return m_prismMusicId;
			} set { m_prismMusicId = value; } } // get_prismMusicId 0xE9D60C set_prismMusicId 0xE9D620
			public int freeMusicId { get; set; } // 0x34
			public int storyMusicId { get; set; } // 0x38
			public Difficulty.Type difficultyType { get; set; } // 0x3C
			public string musicLoadText { get; set; } // 0x40
			public bool IsDisableBattleEventIntermediateResult { get; set; } // 0x44
			public TransitionUniqueId returnTransitionUniqueId { get; set; } // 0x48
			public MHDFCLCMDKO_Enemy.CJLENGHPIDH_EnemyInfo enemyInfo { get; set; } // 0x4C
			public bool isFreeMode { get { return mode == GameMode.Type.FreeBattle; } set {} } // get_isFreeMode 0xE9D690 set_isFreeMode 0xE9D6A4
			public bool isStoryMode { get { return mode == GameMode.Type.StoryBattle; } set {} } // get_isStoryMode 0xE9D6A8 set_isStoryMode 0xE9D6B8
			public bool isTutorialOne { get { return tutorial == TutorialGameMode.Type.TutorialOne; } set {} } // get_isTutorialOne 0xE9D6BC set_isTutorialOne 0xE9D6CC
			public bool isTutorialTwo { get { return tutorial == TutorialGameMode.Type.TutorialTwo; } set {} } // get_isTutorialTwo 0xE9D6D0 set_isTutorialTwo 0xE9D6E4
			public int EventUniqueId { get; set; } // 0x50
			public int onStageDivaNum { get; set; } // 0x54
			public OHCAABOMEOF.KGOGMKMBCPP_EventType gameEventType { get; set; } // 0x58
			public OHCAABOMEOF.KGOGMKMBCPP_EventType openEventType { get; set; } // 0x5C
			public OHCAABOMEOF.KGOGMKMBCPP_EventType playEventType { get; set; } // 0x60
			public bool isEnergyRequired { get; set; } // 0x64

			// // RVA: 0xE9D4F4 Offset: 0xE9D4F4 VA: 0xE9D4F4
			public MusicInfo()
			{
				OnAppBoot();
			}

			// // RVA: 0xE9CAD8 Offset: 0xE9CAD8 VA: 0xE9CAD8
			public void OnAppBoot()
			{
				difficultyType = 0;
				setupTime = 0;
				EventUniqueId = 0;
				mode = 0;
				IsMvMode = false;
				IsLine6Mode = false;
				playEventType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0;
				openEventType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0;
				gameEventType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0;
				openEventType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0;
				musicId = 0;
				freeMusicId = 0;
				mvLimitTime = -1;
				LimitTime = 0;
				musicLoadText = "";
				enemyInfo = new MHDFCLCMDKO_Enemy.CJLENGHPIDH_EnemyInfo();
				IsDisableBattleEventIntermediateResult = false;
				returnTransitionUniqueId = TransitionUniqueId.HOME;
			}

			// // RVA: 0xE9D748 Offset: 0xE9D748 VA: 0xE9D748
			public void SetupInfoByStoryMusic(int storyMusicId, int onStageDivaNum = 1)
			{
				mode = GameMode.Type.StoryBattle;
				freeMusicId = 0;
				this.storyMusicId = storyMusicId;
				DJNPIGEFPMF_StoryMusicInfo info = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.CLHIABAKKJM_StoryMusicData[storyMusicId - 1];
				playEventType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0/*0*/;
				openEventType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0/*0*/;
				gameEventType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0/*0*/;
				tutorial = TutorialGameMode.Type.None;
				musicId = info.DLAEJOBELBH_Id;
				m_prismMusicId = 0;
				difficultyType = Difficulty.Type.Easy;
				EventUniqueId = 0;
				IsMvMode = false;
				IsLine6Mode = false;
				setupTime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				mvLimitTime = -1;
				LimitTime = 0;
				this.onStageDivaNum = onStageDivaNum;
				musicLoadText = "";
				IsDisableBattleEventIntermediateResult = false;
				returnTransitionUniqueId = TransitionUniqueId.HOME;
				enemyInfo.ODDIHGPONFL_Copy(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OPFBEAJJMJB_Enemy.CKADCLJDCJK_EnemyList[IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.FLMLJIKBIMJ_GetStoryMusicData(storyMusicId).LHICAKGHIGF[(int)difficultyType] - 1]);
			}

			// // RVA: 0xE9DAC8 Offset: 0xE9DAC8 VA: 0xE9DAC8
			public void SetupInfoByFreeMusic(int freeMusicId, Difficulty.Type difficultyType, bool isEnergyRequired,
				InitFreeMusicParam initParam, OHCAABOMEOF.KGOGMKMBCPP_EventType gameEventType = 0, 
				OHCAABOMEOF.KGOGMKMBCPP_EventType openEventType = 0, OHCAABOMEOF.KGOGMKMBCPP_EventType playEventType = 0, 
				bool isMvMode = false, bool isLine6Mode = false, string musicLoadText = "", 
				int overrideEnemyCenterSkillId = 0, int overrideEnemyLiveSkillId = 0, long mvLimitTime = -1, 
				long limitTime = 0, int eventUniqueId = 0, int onStageDivaNum = 1, long setupTime = 0)
			{
				this.mode = GameMode.Type.FreeBattle;
				this.freeMusicId = freeMusicId;
				storyMusicId = 0;
				musicId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas[freeMusicId - 1].DLAEJOBELBH_MusicId;
				prismMusicId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.CIKALPJDGMF_ResolveMusicId(freeMusicId, musicId);
				this.difficultyType = difficultyType;
				tutorial = TutorialGameMode.Type.None;
				this.gameEventType = gameEventType;
				this.openEventType = openEventType;
				this.playEventType = playEventType;
				EventUniqueId = eventUniqueId;
				this.isEnergyRequired = isEnergyRequired;
				IsMvMode = isMvMode;
				IsLine6Mode = isLine6Mode;
				if(setupTime == 0)
				{
					setupTime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				}
				this.musicLoadText = musicLoadText;
				this.onStageDivaNum = onStageDivaNum;
				returnTransitionUniqueId = initParam.returnTransitionUniqueId;
				this.setupTime = setupTime;
				this.mvLimitTime = mvLimitTime;
				LimitTime = limitTime;
				IsDisableBattleEventIntermediateResult = initParam.isDisableBattleEventIntermediateResult;
				KEODKEGFDLD_FreeMusicInfo musicInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(freeMusicId);
				enemyInfo.ODDIHGPONFL_Copy(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OPFBEAJJMJB_Enemy.CKADCLJDCJK_EnemyList[(isLine6Mode ? musicInfo.PJNFOCDANCE_EnemyIdByDiffL6 : musicInfo.LHICAKGHIGF_EnemyIdByDiff)[(int)difficultyType] - 1]);
				if(overrideEnemyCenterSkillId != 0 || overrideEnemyLiveSkillId != 0)
				{
					enemyInfo.EDLACELKJIK_LiveSkill = overrideEnemyLiveSkillId;
					enemyInfo.NJOPIPNGANO_CS = overrideEnemyCenterSkillId;
				}
			}

			// // RVA: 0xE9DF78 Offset: 0xE9DF78 VA: 0xE9DF78
			public void SetupInfoByTutorial(TutorialGameMode.Type tutorialMode)
			{
				mode = GameMode.Type.FreeBattle;
				freeMusicId = tutorialMode == TutorialGameMode.Type.TutorialOne ? 37 : 38;
				storyMusicId = 0;
				playEventType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0;
				openEventType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0;
				gameEventType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0;
				musicId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas[freeMusicId - 1].DLAEJOBELBH_MusicId;
				m_prismMusicId = 0;
				tutorial = tutorialMode;
				difficultyType = 0;
				EventUniqueId = 0;
				IsMvMode = false;
				IsLine6Mode = false;
				setupTime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				mvLimitTime = -1;
				LimitTime = 0;
				onStageDivaNum = 1;
				musicLoadText = "";
				IsDisableBattleEventIntermediateResult = false;
				returnTransitionUniqueId = TransitionUniqueId.HOME;
				enemyInfo.ODDIHGPONFL_Copy(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OPFBEAJJMJB_Enemy.CKADCLJDCJK_EnemyList[IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(freeMusicId).LHICAKGHIGF_EnemyIdByDiff[(int)difficultyType] - 1]);
			}

			// // RVA: 0xE9E308 Offset: 0xE9E308 VA: 0xE9E308
			public MHDFCLCMDKO_Enemy.CJLENGHPIDH_EnemyInfo GetEnemyInfo()
			{
				return enemyInfo;
			}

			// // RVA: 0xE9E310 Offset: 0xE9E310 VA: 0xE9E310
			public void ClearEventType()
			{
				gameEventType = 0;
				openEventType = 0;
				playEventType = 0;
				EventUniqueId = 0;
			}

			// // RVA: 0xE9E328 Offset: 0xE9E328 VA: 0xE9E328
			// public void DebugSetupOnStageDivaNum(int onStageDivaNum) { }
		}

		public class MvInfo
		{
			public bool isModeDiva { get; set; } // 0x8
			public bool isModeValkyrie { get; set; } // 0x9
			public bool isCutin { get; set; } // 0xA
			public bool isShowNotes { get; set; } // 0xB
		}

		private TeamInfo m_teamInfo = new TeamInfo(); // 0x8
		private MusicInfo m_musicInfo = new MusicInfo(); // 0xC
		private MvInfo m_mvInfo = new MvInfo(); // 0x10
		private bool initialized; // 0x18

		public TeamInfo teamInfo { get { return m_teamInfo; } set {} } // get_teamInfo 0xE9C9EC  set_teamInfo 0xE9C9F4
		public MusicInfo musicInfo { get { return m_musicInfo; } set {} } // get_musicInfo 0xE9C9F8 set_musicInfo 0xE9CA00
		public MvInfo mvInfo { get { return m_mvInfo; } set {} } // get_mvInfo 0xE9CA04 set_mvInfo 0xE9CA0C
		public AIPEHINPIHC_ForcedSettingInfo forcePrism { get; set; } // 0x14
		public bool EnableLiveSkip { get; set; } // 0x19
		public int LiveSkipTicketCount { get; set; } // 0x1C
		public bool IsNotUpdateProfile { get; set; } // 0x20
		public int SelectedDashIndex { get; set; } // 0x24

		// // RVA: 0xE9CA60 Offset: 0xE9CA60 VA: 0xE9CA60
		public void OnAppBoot()
		{
			if(initialized)
				return;

			initialized = true;
			m_teamInfo.OnAppBoot();
			m_musicInfo.OnAppBoot();
			LiveSkipTicketCount = 0;
			EnableLiveSkip = false;
			IsNotUpdateProfile = false;
			SelectedDashIndex = -1;
		}

		// // RVA: 0xE9CBC8 Offset: 0xE9CBC8 VA: 0xE9CBC8
		public void SetMvMode(StatusData teamStatus, AOJGDNFAIJL_PrismData.AMIECPBIALP prismData)
		{
			m_teamInfo.SetupMvInfo(teamStatus, prismData);
			m_mvInfo.isCutin = GameManager.Instance.localSave.EPJOACOONAC_GetSave().MHHPDGJLJGE_OptionsSLive.DADIPGPHLDD_EffectCutin == 0;
			m_mvInfo.isShowNotes = prismData.DNLCLAOPFPF_ShowNotes;
			m_mvInfo.isModeDiva = prismData.HGEKDNNJAAC_DivaMode;
			m_mvInfo.isModeValkyrie = prismData.OHLCKPIMMFH_ValkyrieMode;
		}

		// // RVA: 0xE9CF04 Offset: 0xE9CF04 VA: 0xE9CF04
		public void SetLiveSkip(bool isSkip, int ticketCount)
		{
			LiveSkipTicketCount = ticketCount;
			EnableLiveSkip = isSkip;
		}

		// // RVA: 0xE9CF10 Offset: 0xE9CF10 VA: 0xE9CF10
		public void SetIsNotUpdateProfile(bool _isNotUpdateProfile)
		{
			IsNotUpdateProfile = _isNotUpdateProfile;
		}

		// // RVA: 0xE9CBBC Offset: 0xE9CBBC VA: 0xE9CBBC
		public void ResetSelectedDashIndex()
		{
			SelectedDashIndex = -1;
		}

		// // RVA: 0xE9CF18 Offset: 0xE9CF18 VA: 0xE9CF18
		public void SetSelectedDashIndex(int index)
		{
			SelectedDashIndex = index;
		}

		// // RVA: 0xE9CF20 Offset: 0xE9CF20 VA: 0xE9CF20
		public void ForcePrismSetting()
		{
			if(m_musicInfo.freeMusicId > 0)
			{
				KEODKEGFDLD_FreeMusicInfo masterFreeMusic = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(m_musicInfo.freeMusicId);
				forcePrism = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.HBJDIFMCGAL_ForcedSettings.Find((AIPEHINPIHC_ForcedSettingInfo x) =>
				{
					//0xE9D51C
					return masterFreeMusic.BLDDNEJDFON_ForcePrismId == x.NMNDNFFJHPJ_Id;
				});
				if(forcePrism != null)
				{
					m_teamInfo.SetForcePrismData(forcePrism);
				}
			}
		}

		// // RVA: 0xE9D288 Offset: 0xE9D288 VA: 0xE9D288
		public int ForceNoteSe()
		{
			return (forcePrism != null && forcePrism.MDKNFOIMCJB_NoteSe > 0) ? forcePrism.MDKNFOIMCJB_NoteSe : 0;
		}

		// // RVA: 0xE9D2A8 Offset: 0xE9D2A8 VA: 0xE9D2A8
		public int ForceNoteType()
		{
			return (forcePrism != null && forcePrism.JIIOKINLOGM_NoteType > 0) ? forcePrism.JIIOKINLOGM_NoteType : 0;
		}

		// // RVA: 0xE9D2C8 Offset: 0xE9D2C8 VA: 0xE9D2C8
		public int ForceDivaVoice()
		{
			return (forcePrism != null && forcePrism.OOFEIPCLEKJ_DivaVoice > 0) ? forcePrism.OOFEIPCLEKJ_DivaVoice : 0;
		}

		// // RVA: 0xE9D2E8 Offset: 0xE9D2E8 VA: 0xE9D2E8
		public int ForcePilotVoice()
		{
			return (forcePrism != null && forcePrism.EDDLJBLJJOE_PilotVoice > 0) ? forcePrism.EDDLJBLJJOE_PilotVoice : 0;
		}

		// // RVA: 0xE9D308 Offset: 0xE9D308 VA: 0xE9D308
		public int ForceBG()
		{
			if(forcePrism != null)
			{
				if (forcePrism.OENPCNBFPDA_Bg < 1)
					return 0;
				return forcePrism.OENPCNBFPDA_Bg;
			}
			return 0;
		}

		// // RVA: 0xE9D328 Offset: 0xE9D328 VA: 0xE9D328
		public int ForceDivaMode()
		{
			if(forcePrism != null)
			{
				int res = forcePrism.EGMIILFFHMI_DivaMode;
				if(res < 1)
					res = 0;
				return res;
			}
			return 0;
		}

		// // RVA: 0xE9D348 Offset: 0xE9D348 VA: 0xE9D348
		public int ForceValkyrieMode()
		{
			if(forcePrism != null)
			{
				int res = forcePrism.HFMFGFHPBNB_ValkyrieMode;
				if(res < 1)
					res = 0;
				return res;
			}
			return 0;
		}

		// // RVA: 0xE9D368 Offset: 0xE9D368 VA: 0xE9D368
		public int ForceCutin()
		{
			if(forcePrism != null)
			{
				int res = forcePrism.ENAAKPKFBGN_EffectCutIn;
				if(res < 1)
					res = 0;
				return res;
			}
			return 0;
		}

		// // RVA: 0xE9D388 Offset: 0xE9D388 VA: 0xE9D388
		public int ForceSLiveResultSerifWindow()
		{
			if(forcePrism != null)
			{
				if (forcePrism.IHLDBMMOCHF_ForceSLiveResultSerifWindow < 1)
					return 0;
				return forcePrism.IHLDBMMOCHF_ForceSLiveResultSerifWindow;
			}
			return 0;
		}

	}
}
