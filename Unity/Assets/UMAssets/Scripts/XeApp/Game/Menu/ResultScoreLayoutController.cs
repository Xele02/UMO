using System;
using System.Collections;
using mcrs;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.RhythmGame;
using XeApp.Game.Tutorial;
using XeSys;

namespace XeApp.Game.Menu
{
	public class ResultScoreLayoutController : MonoBehaviour
	{
		public class InitParam
		{
			public int divaId; // 0x8
			public int difficulty; // 0xC
			public bool isLine6Mode; // 0x10
			public BPOJMOOIIFI_PlayerLevelData viewPlayerLevelUpData; // 0x14
			public NGJOPPIGCPM_ResultData viewResultData; // 0x18
			public GameResultData resultData; // 0x1C
			public LayoutResultHeaderTitle layoutHeaderTitle; // 0x20
			public LayoutResultOkayButton layoutOkayButton; // 0x24
			public PopupAchieveRewardSetting achieveRewardSetting; // 0x28
		}

		private ResultScoreLayoutController.InitParam initParam; // 0xC
		private Action updater; // 0x10
		private LayoutResultTitleCutin layoutTitleCutin; // 0x14
		private LayoutResultMusicInfo layoutMusicInfo; // 0x18
		private LayoutResultScoreMain layoutScoreMain; // 0x1C
		private LayoutResultPlaylog layoutPlaylog; // 0x20
		private LayoutResultPlayerRank layoutPlayerRank; // 0x24
		private LayoutResultHeaderTitle layoutHeaderTitle; // 0x28
		private LayoutResultOkayButton layoutOkayButton; // 0x2C
		private ResultPopupAchieveReward popupAchieveReward; // 0x30
		private PopupPlaylogDetail popupPlaylogDetail; // 0x34
		private LayoutResultPlaylogGraphParts playlogGraphParts; // 0x38
		private LayoutResultSingRateEffect m_singRankrateEffect; // 0x3C
		private LayoutResultSingRateEffectIcon m_singRankrateEffectIcon; // 0x40
		private RhythmGamePlayLog playlog; // 0x44
		private bool m_isSkiped; // 0x48
		private bool m_isPlayerRankAnimEnd; // 0x49
		private bool m_isRankUpScoreRating; // 0x4A
		private Coroutine m_coroutine; // 0x4C
		public Action onClickOkayButton; // 0x50
		public Action onChangeSingRank; // 0x54
		private bool isShowingGuide; // 0x58
		private ResultDivaControl divaControl = new ResultDivaControl(); // 0x5C
		private float skipIgnoreCounter; // 0x60
		private const float skipIgnoreTime = 1;

		private bool isInTutorial { get { return Database.Instance.gameSetup.musicInfo.isTutorialOne || Database.Instance.gameSetup.musicInfo.isTutorialTwo; } } //0xB5F71C

		// // RVA: 0xB5D06C Offset: 0xB5D06C VA: 0xB5D06C
		// public ResultDivaControl TransferDivaControl() { }

		// RVA: 0xB5F7F4 Offset: 0xB5F7F4 VA: 0xB5F7F4
		private void Awake()
		{
			layoutTitleCutin = transform.Find("TitleCutin").GetComponent<LayoutResultTitleCutin>();
			layoutMusicInfo = transform.Find("MusicInfo").GetComponent<LayoutResultMusicInfo>();
			layoutScoreMain = transform.Find("ScoreMain").GetComponent<LayoutResultScoreMain>();
			layoutPlaylog = transform.Find("Playlog").GetComponent<LayoutResultPlaylog>();
			layoutPlayerRank = transform.Find("PlayerRank").GetComponent<LayoutResultPlayerRank>();
			popupAchieveReward = new ResultPopupAchieveReward();
			playlog = Database.Instance.gameResult.gameLog;
			layoutPlaylog.playlog = playlog;
			playlogGraphParts = transform.Find("PlaylogGraphParts").GetComponent<LayoutResultPlaylogGraphParts>();
			if(isInTutorial)
			{
				layoutScoreMain.OnCountupNoteResult = null;
				layoutScoreMain.OnFinishCountupNoteResult = null;
			}
			else
			{
				layoutScoreMain.OnCountupNoteResult = OnCountupNoteResult;
				layoutScoreMain.OnFinishCountupNoteResult = OnFinishCountupNoteResult;
			}
			this.StartCoroutineWatched(Co_LoadSingRankRateEffectLayout());
			MenuScene.Instance.divaManager.BeginControl(divaControl);
		}

		// // RVA: 0xB5FD84 Offset: 0xB5FD84 VA: 0xB5FD84
		private void OnCountupNoteResult(RhythmGameConsts.NoteResult type, float time)
		{
			layoutPlaylog.StartAnim(type, time);
		}

		// // RVA: 0xB5FDC0 Offset: 0xB5FDC0 VA: 0xB5FDC0
		private void OnFinishCountupNoteResult()
		{
			layoutPlaylog.FinishAnim(m_isSkiped);
		}

		// RVA: 0xB5FDFC Offset: 0xB5FDFC VA: 0xB5FDFC
		private void Update()
		{
			if(IsReady())
			{
				skipIgnoreCounter += Time.deltaTime;
				if(skipIgnoreCounter > 1)
				{
					CheckSkipStep();
				}
			}
		}

		// RVA: 0xB600A4 Offset: 0xB600A4 VA: 0xB600A4
		private void OnDestroy()
		{
			if(divaControl != null)
			{
				if(MenuScene.Instance == null)
					return;
				MenuScene.Instance.divaManager.EndControl(divaControl);
			}
		}

		// // RVA: 0xB50384 Offset: 0xB50384 VA: 0xB50384
		public bool IsReady()
		{
			return layoutTitleCutin.IsLoaded() && layoutMusicInfo.IsLoaded() && layoutScoreMain.IsLoaded() && 
			layoutPlaylog.IsLoaded() && layoutPlayerRank.IsLoaded() && m_singRankrateEffect != null && 
			m_singRankrateEffect.IsLoaded() && m_singRankrateEffectIcon != null && m_singRankrateEffectIcon.IsLoaded();
		}

		// // RVA: 0xB50B48 Offset: 0xB50B48 VA: 0xB50B48
		public void Setup(InitParam initParam)
		{
			this.initParam = initParam;
			layoutHeaderTitle = initParam.layoutHeaderTitle;
			layoutOkayButton = initParam.layoutOkayButton;
			layoutMusicInfo.Setup(initParam.viewResultData, initParam.difficulty, initParam.isLine6Mode);
			layoutScoreMain.Setup(initParam.viewResultData, initParam.resultData);
			layoutPlayerRank.Setup(initParam.viewPlayerLevelUpData);
			m_singRankrateEffect.Setup(initParam.viewResultData.PFEIDJKAOLH_ScoreRatingRanking);
			m_singRankrateEffectIcon.Setup(initParam.viewResultData.PFEIDJKAOLH_ScoreRatingRanking);
			m_isRankUpScoreRating = initParam.viewResultData.BEFGMPGFGHA_IsBetterScoreRatingRanking;
			layoutPlaylog.onDetailButton = OnClickPlaylogDetailButton;
			layoutOkayButton.onClick = OnClickOkayButton;
			popupAchieveReward.Setup(initParam.achieveRewardSetting, initParam.viewPlayerLevelUpData.LDHOOPGDBJC_IsLevelUp);
			if(!isInTutorial)
			{
				layoutPlaylog.Setup(playlogGraphParts, initParam.viewResultData);
			}
			divaControl.OnResultStart();
		}

		// // RVA: 0xB50B1C Offset: 0xB50B1C VA: 0xB50B1C
		public void ChangeViewForSkipResult()
		{
			layoutScoreMain.ChangeViewForSkipResult();
		}

		// // RVA: 0xB50AF0 Offset: 0xB50AF0 VA: 0xB50AF0
		// public void ChangeViewForSupportResult() { }

		// // RVA: 0xB5FE58 Offset: 0xB5FE58 VA: 0xB5FE58
		private void CheckSkipStep()
		{
			if(!m_isSkiped)
			{
				if(!layoutPlayerRank.IsOpenRankupPopup() && !m_singRankrateEffect.IsOpen() && 
				!m_singRankrateEffectIcon.IsOpen() && popupAchieveReward.IsClosed())
				{
					int count = InputManager.Instance.GetInScreenTouchCount();
					if(count > 0 && ResultScene.IsScreenTouch())
					{
						m_isSkiped = true;
						layoutHeaderTitle.SkipAnim();
						layoutTitleCutin.SkipAnim();
						layoutScoreMain.SkipAnim();
						layoutMusicInfo.SkipAnim();
						layoutPlayerRank.SkipAnim();
						if(!isInTutorial)
						{
							this.StartCoroutineWatched(Co_StartPlayerRankAnim());
						}
						if(m_coroutine != null)
							return;
						m_coroutine = this.StartCoroutineWatched(Co_StartAnim());
					}
				}
			}
		}

		// // RVA: 0xB50EAC Offset: 0xB50EAC VA: 0xB50EAC
		public void StartAnim()
		{
			m_coroutine = this.StartCoroutineWatched(Co_StartAnim());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x723A24 Offset: 0x723A24 VA: 0x723A24
		// // RVA: 0xB60284 Offset: 0xB60284 VA: 0xB60284
		private IEnumerator Co_StartAnim()
		{
			//0xB62CF8
			MenuScene.Instance.RaycastDisable();
			layoutHeaderTitle.StartBeginAnim();
			layoutMusicInfo.StartBeginAnim();
			yield return Co.R(Co_StartTitleCutinAnim());
			yield return Co.R(Co_StartScoreMainAnim());
			if(!isInTutorial)
			{
				yield return Co.R(Co_StartMusicInfoAnim());
				yield return Co.R(Co_WaitSingRankRateEffect());
				yield return Co.R(Co_OpenSingRankRateReward());
				yield return Co.R(Co_StartPlayerRankAnim());
				yield return Co.R(Co_OpenPlayerRankLevelUp());
				yield return Co.R(Co_OpenMissionStepup());
				yield return Co.R(Co_StartPlaylogAnim());
				yield return Co.R(Co_AchieveReward());
			}
			yield return Co.R(Co_StartOkeyButton());
			MenuScene.Instance.RaycastEnable();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x723A9C Offset: 0x723A9C VA: 0x723A9C
		// // RVA: 0xB60330 Offset: 0xB60330 VA: 0xB60330
		private IEnumerator Co_StartTitleCutinAnim()
		{
			//0xB63CA0
			bool done = false;
			layoutTitleCutin.onFinished = () => {
				//0xB61758
				done = true;
			};
			layoutTitleCutin.StartAnim();
			while(!done)
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x723B14 Offset: 0x723B14 VA: 0x723B14
		// // RVA: 0xB603DC Offset: 0xB603DC VA: 0xB603DC
		private IEnumerator Co_StartScoreMainAnim()
		{
			//0xB63A84
			bool done = false;
			layoutScoreMain.onFinished = () => {
				//0xB6176C
				done = true;
			};
			layoutScoreMain.StartAnim();
			while(!done)
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x723B8C Offset: 0x723B8C VA: 0x723B8C
		// // RVA: 0xB60488 Offset: 0xB60488 VA: 0xB60488
		private IEnumerator Co_StartMusicInfoAnim()
		{
			//0xB6310C
			bool done = false;
			layoutMusicInfo.onFinished = () => {
				//0xB61780
				done = true;
			};
			layoutMusicInfo.StartSingRankUpAnim();
			while(!done)
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x723C04 Offset: 0x723C04 VA: 0x723C04
		// // RVA: 0xB601F8 Offset: 0xB601F8 VA: 0xB601F8
		private IEnumerator Co_StartPlayerRankAnim()
		{
			//0xB63634
			if(m_isPlayerRankAnimEnd)
				yield break;
			m_isPlayerRankAnimEnd = true;
			bool done = false;
			layoutPlayerRank.onFinished = () => {
				//0xB61794
				done = true;
			};
			layoutPlayerRank.StartAnim();
			while(!done)
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x723C7C Offset: 0x723C7C VA: 0x723C7C
		// // RVA: 0xB60554 Offset: 0xB60554 VA: 0xB60554
		private IEnumerator Co_OpenPlayerRankLevelUp()
		{
			//0xB627D0
			yield return Co.R(layoutPlayerRank.Co_ShowRankupPopup());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x723CF4 Offset: 0x723CF4 VA: 0x723CF4
		// // RVA: 0xB60600 Offset: 0xB60600 VA: 0xB60600
		private IEnumerator Co_OpenMissionStepup()
		{
			//0xB6265C
			yield return Co.R(MenuScene.Instance.ShowMissionStepupWindowCoroutine());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x723D6C Offset: 0x723D6C VA: 0x723D6C
		// // RVA: 0xB60694 Offset: 0xB60694 VA: 0xB60694
		private IEnumerator Co_StartPlaylogAnim()
		{
			//0xB63868
			bool done = false;
			layoutPlaylog.onFinished = () => {
				//0xB617A8
				done = true;
			};
			layoutPlaylog.EnterHint();
			while(!done)
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x723DE4 Offset: 0x723DE4 VA: 0x723DE4
		// // RVA: 0xB60740 Offset: 0xB60740 VA: 0xB60740
		private IEnumerator Co_AchieveReward()
		{
			//0xB6197C
			bool done = false;
			popupAchieveReward.onFinished = () => {
				//0xB617BC
				done = true;
			};
			popupAchieveReward.Show();
			while(!done)
				yield return null;
			layoutPlaylog.SetActiveDetailButton(true);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x723E5C Offset: 0x723E5C VA: 0x723E5C
		// // RVA: 0xB607EC Offset: 0xB607EC VA: 0xB607EC
		private IEnumerator Co_StartOkeyButton()
		{
			//0xB63328
			bool done = false;
			layoutOkayButton.onFinished = () => {
				//0xB617D0
				done = true;
			};
			layoutOkayButton.StartBeginAnim();
			while(!done)
				yield return null;
			isShowingGuide = true;
			yield return Co.R(TryTutorialCoroutine(CheckGameResultTutorialCondition, () => {
				//0xB617DC
				divaControl.RequestResultAnimStart((ResultScoreRank.Type)initParam.viewResultData.PENICOGGNLF_RankScore);
				layoutPlayerRank.StartFinishGaugeAnim();
				isShowingGuide = false;
				layoutPlaylog.SetActiveHintButton(true);
			}));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x723ED4 Offset: 0x723ED4 VA: 0x723ED4
		// // RVA: 0xB60898 Offset: 0xB60898 VA: 0xB60898
		private IEnumerator TryTutorialCoroutine(Func<TutorialConditionId, bool> checker, Action finish)
		{
			//0xB6424C
			if(GameManager.Instance.IsTutorial)
			{
				bool isWait = true;
				BasicTutorialManager.Instance.ShowMessageWindow(BasicTutorialMessageId.Id_GameResult, () =>
				{
					//0xB61908
					isWait = false;
				}, null);
				while(isWait)
					yield return null;
				yield return Co.R(TutorialManager.ShowTutorial(68, null));
			}
			//LAB_00b6441c
			yield return TutorialManager.TryShowTutorialCoroutine(checker);
			if (finish != null)
				finish();
		}

		// // RVA: 0xB60960 Offset: 0xB60960 VA: 0xB60960
		private void OnClickOkayButton()
		{
			if(isShowingGuide)
				return;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			if(onClickOkayButton != null)
				onClickOkayButton();
			layoutPlayerRank.StopFinishGaugeAnim();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x723F4C Offset: 0x723F4C VA: 0x723F4C
		// // RVA: 0xB609FC Offset: 0xB609FC VA: 0xB609FC
		private IEnumerator Co_ShowPlaylogDetail()
		{
			//0xB62A5C
			if (popupPlaylogDetail == null)
				yield return Co.R(Co_LoadPlaylogDetail());
			popupPlaylogDetail.ShowPopup((PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xB61694
				GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
			});
		}

		// [IteratorStateMachineAttribute] // RVA: 0x723FC4 Offset: 0x723FC4 VA: 0x723FC4
		// // RVA: 0xB60AA8 Offset: 0xB60AA8 VA: 0xB60AA8
		private IEnumerator Co_LoadPlaylogDetail()
		{
			//0xB61BC8
			if(popupPlaylogDetail == null)
			{
				MenuScene.Instance.InputDisable();
				GameManager.Instance.NowLoading.Show();
				this.StartCoroutineWatched(PopupPlaylogDetail.Co_LoadResource(transform, playlog, (PopupPlaylogDetail data) =>
				{
					//0xB613B4
					popupPlaylogDetail = data;
				}));
				yield return new WaitWhile(() =>
				{
					//0xB613BC
					return popupPlaylogDetail == null;
				});
				popupPlaylogDetail.Setup(playlogGraphParts);
				yield return null;
				yield return new WaitWhile(() =>
				{
					//0xB61448
					return !popupPlaylogDetail.IsChangeGraphType();
				});
				GameManager.Instance.NowLoading.Hide();
				MenuScene.Instance.InputEnable();
			}
		}

		// // RVA: 0xB60B54 Offset: 0xB60B54 VA: 0xB60B54
		private void OnClickPlaylogDetailButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(Co_ShowPlaylogDetail());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x72403C Offset: 0x72403C VA: 0x72403C
		// // RVA: 0xB60BC8 Offset: 0xB60BC8 VA: 0xB60BC8
		private IEnumerator Co_WaitSingRankRateEffect()
		{
			//0xB63EBC
			if(!m_isRankUpScoreRating)
				yield break;
			bool done = false;
			m_singRankrateEffect.onFinished = () => {
				//0xB6191C
				done = true;
			};
			m_singRankrateEffect.Enter();
			while(!done)
				yield return null;
			done = false;
			m_singRankrateEffectIcon.onChange = () => {
				//0xB61928
				layoutMusicInfo.SetActiveSingRank(false);
			};
			m_singRankrateEffectIcon.onFinished = () => {
				//0xB6196C
				done = true;
			};
			m_singRankrateEffectIcon.Enter();
			while(!done)
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7240B4 Offset: 0x7240B4 VA: 0x7240B4
		// // RVA: 0xB60C74 Offset: 0xB60C74 VA: 0xB60C74
		private IEnumerator Co_OpenSingRankRateReward()
		{
			//0xB628E8
			yield return Co.R(MenuScene.Instance.ShowReceiveRewardWindowCoroutine());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x72412C Offset: 0x72412C VA: 0x72412C
		// // RVA: 0xB5FCF8 Offset: 0xB5FCF8 VA: 0xB5FCF8
		private IEnumerator Co_LoadSingRankRateEffectLayout()
		{
			string bundleName; // 0x14
			AssetBundleLoadLayoutOperationBase operation; // 0x18
			FontInfo fontInfo; // 0x1C

			//0xB620FC
			bundleName = "ly/110.xab";
			yield return Co.R(AssetBundleManager.LoadUnionAssetBundle(bundleName));
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_game_res_mgrade_layout_root");
			yield return Co.R(operation);
			yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0xB61478
				instance.transform.SetParent(transform, false);
				m_singRankrateEffect = instance.GetComponent<LayoutResultSingRateEffect>();
			}));
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_game_res_mgrade_icon_layout_root");
			yield return Co.R(operation);
			yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0xB61548
				instance.transform.SetParent(transform, false);
				m_singRankrateEffectIcon = instance.GetComponent<LayoutResultSingRateEffectIcon>();
			}));
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);


		}

		// // RVA: 0xB60D28 Offset: 0xB60D28 VA: 0xB60D28
		private bool CheckGameResultTutorialCondition(TutorialConditionId conditionId)
		{
			if(!GameManager.Instance.IsTutorial)
			{
				if(conditionId < TutorialConditionId.Condition21)
				{
					if(conditionId == TutorialConditionId.Condition6)
					{
						if(initParam.viewResultData.DACPGGLFLJG_FullComboType == 0)
						{
							return Database.Instance.gameSetup.musicInfo.difficultyType > Difficulty.Type.Normal;
						}
					}
					else if(conditionId == TutorialConditionId.Condition20)
					{
						for(int i = 0; i < playlog.skillDataList.Count; i++)
						{
							if (!playlog.skillDataList[i].isActive)
								return true;
						}
					}
				}
				else
				{
					switch(conditionId)
					{
						case TutorialConditionId.Condition43:
							if(!GameManager.Instance.IsTutorial)
							{
								bool b9 = false;
								if(initParam.viewResultData.DACPGGLFLJG_FullComboType != 0)
								{
									if(initParam.viewResultData.PENICOGGNLF_RankScore < 2)
										b9 = true;
								}
								bool b2 = false;
								if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KIECDDFNCAN_Level > 9)
								{
									if (initParam.viewResultData.PENICOGGNLF_RankScore < 2)
										b2 = true;
								}
								return b9 || b2;
							}
							break;
						case TutorialConditionId.Condition44:
							if (!GameManager.Instance.IsTutorial)
							{
								return layoutPlaylog.playlog.valkyrieModeData.type != RhythmGameMode.Type.Valkyrie;
							}
							break;
						case TutorialConditionId.Condition45:
							if (!GameManager.Instance.IsTutorial)
							{
								if (layoutPlaylog.playlog.valkyrieModeData.type != RhythmGameMode.Type.Valkyrie)
									return false;
								return layoutPlaylog.playlog.divaModeData.type == RhythmGameMode.Type.None;
							}
							break;
						case TutorialConditionId.Condition52:
							if (!GameManager.Instance.IsTutorial)
							{
								return !m_isRankUpScoreRating;
							}
							break;
					}
				}
			}
			return false;
		}
		
		// [CompilerGeneratedAttribute] // RVA: 0x7241D4 Offset: 0x7241D4 VA: 0x7241D4
		// // RVA: 0xB61478 Offset: 0xB61478 VA: 0xB61478
		// private void <Co_LoadSingRankRateEffectLayout>b__57_0(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x7241E4 Offset: 0x7241E4 VA: 0x7241E4
		// // RVA: 0xB61548 Offset: 0xB61548 VA: 0xB61548
		// private void <Co_LoadSingRankRateEffectLayout>b__57_1(GameObject instance) { }
	}
}
