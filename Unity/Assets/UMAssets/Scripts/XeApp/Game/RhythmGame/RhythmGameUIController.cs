using UnityEngine;
using System;
using UnityEngine.Events;
using System.Collections.Generic;
using XeApp.Game.Common;
using XeSys;
using XeApp.Game.Common.uGUI;
using System.Collections;
using XeApp.Game.Tutorial;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameUIController : MonoBehaviour
	{
		private List<Animator> m_list_anim = new List<Animator>(); // 0x1C
		private List<ParticleSystem> m_list_particle = new List<ParticleSystem>(); // 0x20
		private List<EffectBundleControllerSimple> m_list_effect = new List<EffectBundleControllerSimple>(); // 0x24

		public GameUIIntro intro { get; private set; } // 0xC
		public GameUIComplete complete { get; private set; } // 0x10
		public GameUIFailed failed { get; private set; } // 0x14
		public IRhythmGameHUD Hud { get; private set; } // 0x18

		// // RVA: 0xC0C4F0 Offset: 0xC0C4F0 VA: 0xC0C4F0
		public void Pause()
		{
			foreach(var a in m_list_anim)
			{
				a.speed = 0;
			}
			foreach(var p in m_list_particle)
			{
				if(p.IsAlive())
				{
					p.Pause();
				}
			}
			foreach(var e in m_list_effect)
			{
				e.Pause();
			}
		}

		// // RVA: 0xC0C8C0 Offset: 0xC0C8C0 VA: 0xC0C8C0
		public void Resume()
		{
			foreach(var a in m_list_anim)
			{
				a.speed = 1;
			}
			foreach(var p in m_list_particle)
			{
				if(p.isPaused)
				{
					p.Play();
				}
			}
			foreach(var e in m_list_effect)
			{
				e.Resume();
			}
		}

		// // RVA: 0xC0CC90 Offset: 0xC0CC90 VA: 0xC0CC90
		public void OnAwake()
		{
			return;
		}

		// // RVA: 0xC0CC94 Offset: 0xC0CC94 VA: 0xC0CC94
		public void OnStart()
		{
			return;
		}

		// // RVA: 0xC0CC98 Offset: 0xC0CC98 VA: 0xC0CC98
		public void OnUpdate()
		{
			return;
		}

		// // RVA: 0xC0CC9C Offset: 0xC0CC9C VA: 0xC0CC9C
		public void Initialize(RhythmGameResource resource, RhythmGamePlayer.Setting setting, RhythmGamePlayer.SettingMV mvSetting)
		{
			Canvas[] cs = transform.root.Find("Layer-Overlay").GetComponentsInChildren<Canvas>(true);
			Transform c = null;
			for(int i = 0; i < cs.Length; i++)
			{
				if (cs[i].name == "TopLayoutCanvas")
				{
					c = cs[i].transform.GetChild(0);
					break;
				}
			}
			GameObject ui = Instantiate(resource.uiPrefab);
			ui.transform.SetParent(transform.root.Find("Layer-UI").GetComponentInChildren<Canvas>(true).transform.GetChild(0).transform, false);
			Hud =  ui.GetComponent<IRhythmGameHUD>();
			Hud.isEnableCutin = setting.m_enable_cutin;
			Hud.isShowNotes = mvSetting.m_show_notes;
			Hud.Initialize();
			Hud.SetPlayerSideTexture(resource.m_pilotTexture, resource.m_divaTexture);
			Hud.SetEnemySideTexture(resource.m_enemyPilotTexture, resource.m_enemyRobotTexture);
			if(resource.enemySkillPrefab != null)
			{
				Hud.SetEnemyLiveSkillEffect(resource.enemySkillPrefab);
			}
			intro = GameManager.Instance.GameUIIntro;
			failed = resource.faildUiPrefab.GetComponent<GameUIFailed>();
			failed.transform.SetParent(c, false);
			failed.gameObject.SetActive(false);
			complete = resource.completeUiPrefab.GetComponent<GameUIComplete>();
			complete.transform.SetParent(c, false);
			complete.gameObject.SetActive(false);
			m_list_anim.Clear();
			m_list_anim.AddRange(ui.GetComponentsInChildren<Animator>(true));
			m_list_particle.Clear();
			m_list_particle.AddRange(ui.GetComponentsInChildren<ParticleSystem>(true));
			m_list_effect.Clear();
			m_list_effect.AddRange(ui.GetComponentsInChildren<EffectBundleControllerSimple>(true));
		}

		// // RVA: 0xC0D81C Offset: 0xC0D81C VA: 0xC0D81C
		public void BeginIntroAnim(Action callback)
		{
			intro.DoIntro();
			intro.onAnimationEndCallback = callback;
		}

		// // RVA: 0xBF2A8C Offset: 0xBF2A8C VA: 0xBF2A8C
		public void DeleteIntro()
		{
			GameManager.Instance.DeleteIntro();
			intro = null;
		}

		// // RVA: 0xC0D874 Offset: 0xC0D874 VA: 0xC0D874
		public void BeginFailedAnim(Action callback)
		{
			failed.BeginFailedAnim();
			failed.CleanupFailedCompletedCallback();
			failed.AddFailedCompletedCallback(callback);
		}

		// // RVA: 0xC0D8EC Offset: 0xC0D8EC VA: 0xC0D8EC
		public void BeginRetryAnim(Action callback)
		{
			failed.BeginRetryAnim();
			failed.CleanupRetryCompletedCallback();
			failed.AddRetryCompletedCallback(callback);
		}

		// // RVA: 0xC0D964 Offset: 0xC0D964 VA: 0xC0D964
		public void BeginCompleteAnim(Action callback, RhythmGameConsts.ResultComboType comboRank, bool isMvMode = false)
		{
			Hud.CloseSkillCutin();
			Hud.EndAcceptOfInput();
			Hud.HideAllToucheEffect();
			if (isMvMode)
				complete.BeginCompleteAnimSimulate();
			else
				complete.BeginCompleteAnim(comboRank);
			complete.CleanupLeaveCompletedCallback();
			complete.AddLeaveCompletedCallback(callback);
		}

		// // RVA: 0xC0DBE4 Offset: 0xC0DBE4 VA: 0xC0DBE4
		// public void EndCompleteAnim() { }

		// // RVA: 0xC0DC10 Offset: 0xC0DC10 VA: 0xC0DC10
		public void UpdateEnergy(int energy)
		{
			Hud.SetFoldWaveGaugeValue(energy);
		}

		// // RVA: 0xC0DCF0 Offset: 0xC0DCF0 VA: 0xC0DCF0
		public void UpdateEnemyLife(int damage, int threshold1, int threshold2, UnityAction onChaseModeCallback)
		{
			Hud.UpdateEnemyStatus(damage, threshold1, threshold2, onChaseModeCallback);
		}

		// // RVA: 0xC0DDFC Offset: 0xC0DDFC VA: 0xC0DDFC
		public void UpdateEnemyDamageResult(int result, Vector3 position)
		{
			Hud.EnemyDamageResult(result, position);
		}

		// // RVA: 0xC0DF08 Offset: 0xC0DF08 VA: 0xC0DF08
		public void UpdateCombo(int newCombo)
		{
			Hud.SetCombo(newCombo);
		}

		// // RVA: 0xC0DFE8 Offset: 0xC0DFE8 VA: 0xC0DFE8
		public void UpdateBattleCombo(int battleCombo)
		{
			Hud.SetBattleCombo(battleCombo);
		}

		// // RVA: 0xC0E0C8 Offset: 0xC0E0C8 VA: 0xC0E0C8
		public void EnterLIVESkill(LiveSkill skill, Material skillDesc, Material material)
		{
			Hud.EntryLiveSkillCutin(skill, skillDesc, material);
		}

		// // RVA: 0xC0E1C4 Offset: 0xC0E1C4 VA: 0xC0E1C4
		public void ShowLIVESkill()
		{
			Hud.ShowLiveSkillCutin();
		}

		// // RVA: 0xC0E29C Offset: 0xC0E29C VA: 0xC0E29C
		public void AddBuffEffect(BuffEffect buff, int line)
		{
			Hud.OnSkillEffect(line, (int)buff.effectType, buff.isTopPriorityDisplay);
		}

		// // RVA: 0xC0E3E0 Offset: 0xC0E3E0 VA: 0xC0E3E0
		public void DeleteBuffEffect(BuffEffect buff, int line)
		{
			Hud.OffSkillEffect(line, (int)buff.effectType);
		}

		// // RVA: 0xC0E4E8 Offset: 0xC0E4E8 VA: 0xC0E4E8
		public void DeleteBuffEffectTopPriorityFlagOnly(BuffEffect buff, int line)
		{
			Hud.OffTopPrioritySkillEffect(line, (int)buff.effectType);
		}

		// // RVA: 0xC0E5F0 Offset: 0xC0E5F0 VA: 0xC0E5F0
		// public void DrawBuffEffectEnable(int line, bool flag) { }

		// // RVA: 0xC0E6D8 Offset: 0xC0E6D8 VA: 0xC0E6D8
		public void EndActiveSkill()
		{
			Hud.EndActiveSkill();
		}

		// // RVA: 0xBF2FC4 Offset: 0xBF2FC4 VA: 0xBF2FC4
		public void ShowConfirmationWindow(Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> callback, DJBHIFLHJLK errorGotoTitle)
		{
			if (Database.Instance.gameSetup.musicInfo.isFreeMode)
			{
				PopupWindowManager.Show(CreateConfirmationSetting(errorGotoTitle), callback, null, null, null, true, false, false, null, null, PlayPopupOpenSe, PlayPopupButtonSe);
			}
			else
			{
				PopupWindowManager.Show(CreateConfirmationSettingForStory(), callback, null, null, null, true, false, false, null, null, PlayPopupOpenSe, PlayPopupButtonSe);
			}
		}

		// // RVA: 0xBF2E70 Offset: 0xBF2E70 VA: 0xBF2E70
		public void ShowContinueWindow(Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> callback)
		{
			PopupWindowManager.Show(CreateContinueSetting(), callback, null, null, null, true, false, false, null, null, PlayPopupOpenSe, PlayPopupButtonSe);
		}

		// // RVA: 0xC0F378 Offset: 0xC0F378 VA: 0xC0F378
		public void ShowReconfirmationWindow(Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> callback)
		{
			if(Database.Instance.gameSetup.musicInfo.isFreeMode)
			{
				PopupWindowManager.Show(CreateRetirePopupsetting(), callback, null, null, null, true, false, false, null, null, PlayPopupOpenSe, PlayPopupButtonSe);
			}
			else
			{
				PopupWindowManager.Show(CreateRetirePopupsettingForStory(), callback, null, null, null, true, false, false, null, null, PlayPopupOpenSe, PlayPopupButtonSe);
			}
		}

		// // RVA: 0xC0FBD8 Offset: 0xC0FBD8 VA: 0xC0FBD8
		public void ShowPauseWindow(Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> callback)
		{
			PopupWindowManager.Show(CreatePausePopupsetting(), callback, null, null, null, true, false, false, null, null, PlayPopupOpenSe, PlayPopupButtonSe);
		}

		// // RVA: 0xC104CC Offset: 0xC104CC VA: 0xC104CC
		public void ShowRetireConfirmationWindow(Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> callback)
		{
			if (Database.Instance.gameSetup.musicInfo.isFreeMode)
			{
				PopupWindowManager.Show(CreateRetirePopupsetting(), callback, null, null, null, true, false, false, null, null, PlayPopupOpenSe, PlayPopupButtonSe);
			}
			else
			{
				PopupWindowManager.Show(CreateRetirePopupsettingForStory(), callback, null, null, null, true, false, false, null, null, PlayPopupOpenSe, PlayPopupButtonSe);
			}
		}

		// // RVA: 0xC10730 Offset: 0xC10730 VA: 0xC10730
		public void ShowSkipConfirmationWindow(Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> callback)
		{
			if(Database.Instance.gameSetup.musicInfo.isStoryMode)
			{
				PopupWindowManager.Show(CreateSkipPopupsettingForStory(), callback, null, null, null, playSeEvent:PlayPopupOpenSe, buttonSeEvent:PlayPopupButtonSe);
			}
			else
			{
				PopupWindowManager.Show(CreateSkipPopupsettingForTutorial(), callback, null, null, null, playSeEvent:PlayPopupOpenSe, buttonSeEvent:PlayPopupButtonSe);
			}
		}

		// // RVA: 0xC10E9C Offset: 0xC10E9C VA: 0xC10E9C
		public void ShowMvModePauseWindow(Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> callback)
		{
			PopupWindowManager.Show(CreateMvModePausePopupSetting(), callback, null, null, null, true, false, false, null, null, this.PlayPopupOpenSe, this.PlayPopupButtonSe);
		}

		// // RVA: 0xC11608 Offset: 0xC11608 VA: 0xC11608
		public void ShowMvModeEndConfirmWindow(Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> callback)
		{
			PopupWindowManager.Show(CreateMvModeEndConfirmPopupSetting(), callback, null, null, null, true, false, false, null, null, this.PlayPopupOpenSe, this.PlayPopupButtonSe);
		}

		// // RVA: 0xC119E0 Offset: 0xC119E0 VA: 0xC119E0
		// public void ShowEndTutorialWindow(Action callback, bool isRetry) { }

		// // RVA: 0xC11A78 Offset: 0xC11A78 VA: 0xC11A78
		private bool PlayPopupOpenSe(PopupWindowControl.SeType type)
		{
			PopupWindowControl.PlayPopupWindowOpenSe(type, SoundManager.Instance.sePlayerGame);
			return true;
		}

		// // RVA: 0xC11B30 Offset: 0xC11B30 VA: 0xC11B30
		private bool PlayPopupButtonSe(PopupButton.ButtonLabel label, PopupButton.ButtonType type)
		{
			PopupWindowControl.PlayPopupButtonSe(label, type, SoundManager.Instance.sePlayerGame);
			return true;
		}

		// // RVA: 0xBF1884 Offset: 0xBF1884 VA: 0xBF1884
		public void ShowNotesDescriptionTutorialWindow(Action callback)
		{
			this.StartCoroutineWatched(TutorialManager.ShowTutorial(64, () =>
			{
				//0x15515B8
				callback();
			}));
		}

		// // RVA: 0xBF391C Offset: 0xBF391C VA: 0xBF391C
		public void ShowFWaveDescriptionTutorialWindow(Action callback)
		{
			this.StartCoroutineWatched(TutorialManager.ShowTutorial(66, () =>
			{
				//0x15515EC
				callback();
			}));
		}

		// // RVA: 0xC11BF0 Offset: 0xC11BF0 VA: 0xC11BF0
		// public void ShowModeDescriptionTutorialWindow(Action callback) { }

		// // RVA: 0xBF3A24 Offset: 0xBF3A24 VA: 0xBF3A24
		public void Show6LineDescriptionTutorialWindow(Action callback)
		{
			this.StartCoroutineWatched(Co_Show6LineDescriptionTutorialWindow(callback));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x746044 Offset: 0x746044 VA: 0x746044
		// // RVA: 0xC11CF8 Offset: 0xC11CF8 VA: 0xC11CF8
		private IEnumerator Co_Show6LineDescriptionTutorialWindow(Action callback)
		{
			//0x1551670
			yield return Co.R(TutorialManager.TryShowTutorialCoroutine((TutorialConditionId id) =>
			{
				//0x15515A0
				return id == TutorialConditionId.Condition70;
			}));
			if (callback != null)
				callback();
		}

		// // RVA: 0xC0FD2C Offset: 0xC0FD2C VA: 0xC0FD2C
		private PopupSetting CreatePausePopupsetting()
		{
			TextPopupSetting res = new TextPopupSetting();
			res.WindowSize = SizeType.Small;
			res.BackButtonLabel = PopupButton.ButtonLabel.ReStart;
			res.TitleText = MessageManager.Instance.GetBank("common").GetMessageByLabel("game_popup_pause_title");
			int ma = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(Database.Instance.gameSetup.musicInfo.prismMusicId).FKDCCLPGKDK_Ma;
			string diff = Difficulty.Name[(int)Database.Instance.gameSetup.musicInfo.difficultyType];
			if (Database.Instance.gameSetup.musicInfo.IsLine6Mode)
				diff += "+";
			object[] o = new object[2] { RichTextUtility.MakeColorTagString(Database.Instance.musicText.Get(ma).musicName, GameAttributeTextColor.Colors[ma - 1]),
				diff };
			res.Text = PopupWindowManager.FormatTextBank(MessageManager.Instance.GetBank("common"), "game_popup_pause_text", o);
			res.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = !Database.Instance.gameSetup.musicInfo.isTutorialOne && !Database.Instance.gameSetup.musicInfo.isTutorialTwo && !Database.Instance.gameSetup.musicInfo.isStoryMode ? PopupButton.ButtonLabel.Retire : PopupButton.ButtonLabel.Skip, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.ReStart, Type = PopupButton.ButtonType.Positive }
			};

			return res;
		}

		// // RVA: 0xC0E7B0 Offset: 0xC0E7B0 VA: 0xC0E7B0
		private PopupSetting CreateConfirmationSetting(DJBHIFLHJLK errorGotoTitle)
		{
			int diff = CIOECGOMILE.HHCJCDFCLOB.DEAPMEIDCGC_GetTotalPaidCurrency() - CIOECGOMILE.HHCJCDFCLOB.BPPGDBHGMDA_Continue_Price;
			if (diff < 0)
			{
				TextPopupSetting res = new TextPopupSetting();
				res.WindowSize = SizeType.Small;
				res.TitleText = MessageManager.Instance.GetBank("common").GetMessageByLabel("game_popup_continue_title");
				res.Text = MessageManager.Instance.GetBank("common").GetMessageByLabel("game_popup_continue_shotage_text");
				res.Buttons = new ButtonInfo[2]
				{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Purchase, Type = PopupButton.ButtonType.Positive}
				};
				return res;
			}
			else
			{
				TodoLogger.LogError(0, "CreateConfirmationSetting");
				return null;
			}
		}

		// // RVA: 0xC0F0F4 Offset: 0xC0F0F4 VA: 0xC0F0F4
		private PopupSetting CreateContinueSetting()
		{
			TextPopupSetting res = new TextPopupSetting();
			res.WindowSize = SizeType.Small;
			res.TitleText = MessageManager.Instance.GetBank("common").GetMessageByLabel("game_popup_continue_title");
			res.Text = MessageManager.Instance.GetBank("common").GetMessageByLabel("game_popup_continue_text_01");
			res.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Retire, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Continue, Type = PopupButton.ButtonType.Positive}
			};
			return res;
		}

		// // RVA: 0xC0EE70 Offset: 0xC0EE70 VA: 0xC0EE70
		private PopupSetting CreateConfirmationSettingForStory()
		{
			TodoLogger.LogError(0, "CreateConfirmationSettingForStory");
			return null;
		}

		// // RVA: 0xC0F5DC Offset: 0xC0F5DC VA: 0xC0F5DC
		private PopupSetting CreateRetirePopupsetting()
		{
			TextPopupSetting res = new TextPopupSetting();
			res.WindowSize = SizeType.Small;
			res.TitleText = MessageManager.Instance.GetBank("common").GetMessageByLabel("game_popup_retire_title");
			res.Text = MessageManager.Instance.GetBank("common").GetMessageByLabel(Database.Instance.gameSetup.musicInfo.gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva ? "game_popup_retire_text_godiva" : (Database.Instance.gameSetup.musicInfo.gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle ? "game_popup_retire_text_battle" : "game_popup_retire_text"));
			res.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Retire, Type = PopupButton.ButtonType.Positive}
			};
			return res;
		}

		// // RVA: 0xC0F954 Offset: 0xC0F954 VA: 0xC0F954
		private PopupSetting CreateRetirePopupsettingForStory()
		{
			TextPopupSetting res = new TextPopupSetting();
			res.WindowSize = SizeType.Small;
			res.TitleText = MessageManager.Instance.GetBank("common").GetMessageByLabel("game_popup_retire_title");
			res.Text = MessageManager.Instance.GetBank("common").GetMessageByLabel("game_popup_retire_story_text");
			res.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Retire, Type = PopupButton.ButtonType.Positive}
			};
			return res;
		}

		// // RVA: 0xC10994 Offset: 0xC10994 VA: 0xC10994
		private PopupSetting CreateSkipPopupsettingForStory()
		{
			MessageBank bk = MessageManager.Instance.GetBank("common");
			TextPopupSetting res = new TextPopupSetting();
			res.WindowSize = SizeType.Small;
			res.TitleText = bk.GetMessageByLabel("game_popup_skip_title");
			res.Text = bk.GetMessageByLabel("game_popup_skip_story_text");
			res.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Skip, Type = PopupButton.ButtonType.Positive }
			};
			return res;
		}

		// // RVA: 0xC10C18 Offset: 0xC10C18 VA: 0xC10C18
		private PopupSetting CreateSkipPopupsettingForTutorial()
		{
			MessageBank bk = MessageManager.Instance.GetBank("common");
			TextPopupSetting res = new TextPopupSetting();
			res.WindowSize = SizeType.Small;
			res.TitleText = bk.GetMessageByLabel("game_tutorial_skip_title");
			res.Text = bk.GetMessageByLabel("game_tutorial_skip_text");
			res.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Skip, Type = PopupButton.ButtonType.Positive }
			};
			return res;
		}

		// // RVA: 0xC10FF0 Offset: 0xC10FF0 VA: 0xC10FF0
		private PopupSetting CreateMvModePausePopupSetting()
		{
			TextPopupSetting setting = new TextPopupSetting();
			setting.WindowSize = SizeType.Small;
			setting.BackButtonLabel = PopupButton.ButtonLabel.ReStart;
			setting.TitleText = MessageManager.Instance.GetBank("menu").GetMessageByLabel("game_popup_mvpause_title");
			object[] o = new object[2];
			o[0] = Database.Instance.musicText.Get(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(Database.Instance.gameSetup.musicInfo.prismMusicId).KNMGEEFGDNI_Nam).musicName;
			o[1] = Difficulty.Name[(int)Database.Instance.gameSetup.musicInfo.difficultyType] + ((Database.Instance.gameSetup.musicInfo.IsLine6Mode) ? "+" : "");
			setting.Text = PopupWindowManager.FormatTextBank(MessageManager.Instance.GetBank("menu"), "game_popup_mvpause_text", o);
			setting.Buttons = new ButtonInfo[] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Finish, Type = PopupButton.ButtonType.Negative },
												new ButtonInfo() { Label = PopupButton.ButtonLabel.ReStart, Type = PopupButton.ButtonType.Positive }};
			return setting;
		}

		// // RVA: 0xC1175C Offset: 0xC1175C VA: 0xC1175C
		private PopupSetting CreateMvModeEndConfirmPopupSetting()
		{
			TextPopupSetting setting = new TextPopupSetting();
			setting.WindowSize = SizeType.Small;
			setting.TitleText = MessageManager.Instance.GetBank("menu").GetMessageByLabel("game_mvmode_endtitle_text");
			setting.Text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("game_mvmode_end_text");
			setting.Buttons = new ButtonInfo[2] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
												new ButtonInfo() { Label = PopupButton.ButtonLabel.Finish, Type = PopupButton.ButtonType.Positive }};
			return setting;
		}

		// // RVA: 0xC11D80 Offset: 0xC11D80 VA: 0xC11D80
	}
}
