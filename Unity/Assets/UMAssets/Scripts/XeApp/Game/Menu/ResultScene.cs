using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class ResultScene : TransitionRoot
	{
		private Action task; // 0x48
		private ResultScoreLayoutController.InitParam scoreLayoutInitParam; // 0x4C
		private ResultDivaLayoutController.InitParam divaLayoutInitParam; // 0x50
		private ResultDropLayoutController.InitParam dropLayoutInitParam; // 0x54
		// private ResultEvent01LayoutController.InitParam event01LayoutInitParam; // 0x58
		// private MissonResultLayoutController.InitParam event02LayoutInitParam; // 0x5C
		// private ResultEvent03ScoreLayoutController.InitParam event03ScoreLayoutInitParam; // 0x60
		// private ResultEvent03PointLayoutController.InitParam event03PointLayoutInitParam; // 0x64
		// private RaidResultPointLayoutController.InitParam raidResultPointLayoutInitParam; // 0x68
		// private RaidResultDamageLayoutController.InitParam raidResultDamageLayoutInitParam; // 0x6C
		// private RaidResultRewardLayoutController.InitParam raidResultRewardLayoutInitParam; // 0x70
		// private LayoutResultGoDivaMain.InitParam goDivaLayoutInitParam; // 0x74
		private ResultCommonLayoutController commonLayoutController; // 0x78
		private ResultScoreLayoutController scoreLayoutController; // 0x7C
		private ResultDivaLayoutController divaLayoutController; // 0x80
		private ResultDropLayoutController dropLayoutController; // 0x84
		private ResultEvent01LayoutController event01LayoutController; // 0x88
		private MissonResultLayoutController event02LayoutController; // 0x8C
		private LayoutResultGoDivaMain layoutResultGoDivaMain; // 0x90
		private ResultEvent03ScoreLayoutController event03ScoreLayoutController; // 0x94
		private ResultEvent03PointLayoutController event03PointLayoutController; // 0x98
		private RaidResultPointLayoutController raidResultPointLayoutController; // 0x9C
		private RaidResultDamageLayoutController raidResultDamageLayoutController; // 0xA0
		private RaidResultRewardLayoutController raidResultRewardLayoutController; // 0xA4
		private RaidResultBossFilterLayout raidResultBossFilter; // 0xA8
		private LayoutResultEventHiScoreWindow event01_EventHiScoreWindowLayout; // 0xAC
		private OHCAABOMEOF.KGOGMKMBCPP_EventType eventType; // 0xB0

		private bool isInTutorial { get { return Database.Instance.gameSetup.musicInfo.isTutorialOne || Database.Instance.gameSetup.musicInfo.isTutorialTwo; } } //0xB4E5D8

		// RVA: 0xB4E6B0 Offset: 0xB4E6B0 VA: 0xB4E6B0 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			IsReady = true;
		}

		// RVA: 0xB4E6D8 Offset: 0xB4E6D8 VA: 0xB4E6D8
		private void Update()
		{
			if(task != null)
				task();
		}

		// RVA: 0xB4E6EC Offset: 0xB4E6EC VA: 0xB4E6EC
		private void OnDestroy()
		{
			if(event01_EventHiScoreWindowLayout != null)
			{
				Destroy(event01_EventHiScoreWindowLayout.gameObject);
				event01_EventHiScoreWindowLayout = null;
			}
		}

		// // RVA: 0xB4E7E4 Offset: 0xB4E7E4 VA: 0xB4E7E4
		private void InitParam()
		{
			NGJOPPIGCPM_ResultData resultData = new NGJOPPIGCPM_ResultData();
			resultData.KHEKNNFCAOI(Database.Instance.gameSetup.musicInfo.freeMusicId,
							Database.Instance.gameSetup.musicInfo.difficultyType,
							Database.Instance.gameSetup.EnableLiveSkip,
							Database.Instance.gameSetup.musicInfo.IsLine6Mode, 
							(int)Database.Instance.gameSetup.musicInfo.gameEventType);
			FPGEMAIAMBF_RewardData rewardData = new FPGEMAIAMBF_RewardData();
			rewardData.CHOHLJOJKNJ(Database.Instance.gameSetup.musicInfo.freeMusicId,
								(int)Database.Instance.gameSetup.musicInfo.difficultyType,
								Database.Instance.gameSetup.musicInfo.IsLine6Mode,
								(int)Database.Instance.gameSetup.musicInfo.gameEventType);
			PopupAchieveRewardSetting rewardSetting = null;
			if (PopupAchieveRewardContent.CheckAchieve(rewardData))
			{
				rewardSetting = new PopupAchieveRewardSetting();
				rewardSetting.mode = LayoutPopupAchieveReward.eMode.Result;
				rewardSetting.selectMusicId = Database.Instance.gameSetup.musicInfo.musicId;
				rewardSetting.selectFreeMusicId = Database.Instance.gameSetup.musicInfo.freeMusicId;
				rewardSetting.diff = Database.Instance.gameSetup.musicInfo.difficultyType;
				rewardSetting.viewFreeReward = rewardData;
				rewardSetting.gameEventType = (int)Database.Instance.gameSetup.musicInfo.gameEventType;
				rewardSetting.isLine6Mode = Database.Instance.gameSetup.musicInfo.IsLine6Mode;
			}
			BPOJMOOIIFI_PlayerLevelData playerLevelData = new BPOJMOOIIFI_PlayerLevelData();
			playerLevelData.KHEKNNFCAOI();
			scoreLayoutInitParam = new ResultScoreLayoutController.InitParam()
			{
				divaId = Database.Instance.gameSetup.teamInfo.divaList[0].divaId,
				difficulty = (int)Database.Instance.gameSetup.musicInfo.difficultyType,
				isLine6Mode = Database.Instance.gameSetup.musicInfo.IsLine6Mode,
				viewPlayerLevelUpData = playerLevelData,
				viewResultData = resultData,
				layoutOkayButton = null,
				resultData = Database.Instance.gameResult,
				achieveRewardSetting = rewardSetting
			};
			GNIFOHMFDMO_DivaResultData divaResultData = new GNIFOHMFDMO_DivaResultData();
			divaResultData.KHEKNNFCAOI(Database.Instance.gameSetup.musicInfo.freeMusicId, Database.Instance.gameSetup.musicInfo.IsLine6Mode);
			divaLayoutInitParam = new ResultDivaLayoutController.InitParam()
			{
				viewDivaResultData = divaResultData,
				layoutOkayButton = null
			};
			MOLKENLNCPE_DropData dropData = new MOLKENLNCPE_DropData();
			dropData.KHEKNNFCAOI();
			dropLayoutInitParam = new ResultDropLayoutController.InitParam()
			{
				viewDropResultData = dropData,
				viewFriendPlayerData = JGEOBNENMAH.HHCJCDFCLOB.NHPGGBCKLHC_FriendPlayerData,
				layoutOkayButton = null
			};
			eventType = JGEOBNENMAH.HHCJCDFCLOB.NNABDGKFEMK_EventType;
			if(eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection)
			{
				TodoLogger.Log(0, "InitParam Event");
			}
			if(eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.NKDOEBONGNI_EventQuest)
			{
				TodoLogger.Log(0, "InitParam Event");
			}
			if (eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
			{
				TodoLogger.Log(0, "InitParam Event");
			}
			if (eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid)
			{
				TodoLogger.Log(0, "InitParam Event");
			}
			if (eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva)
			{
				TodoLogger.Log(0, "InitParam Event");
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7227BC Offset: 0x7227BC VA: 0x7227BC
		// // RVA: 0xB4F89C Offset: 0xB4F89C VA: 0xB4F89C
		private IEnumerator Co_LoadCommonLayout()
		{
			UnityEngine.Debug.Log("Enter Co_LoadCommonLayout");
			StringBuilder bundleName; // 0x14
			AssetBundleLoadLayoutOperationBase lytAssetOp; // 0x18

			//0xB5B4D0
			bundleName = new StringBuilder();
			bundleName.Set("ly/022.xab");
			lytAssetOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_ResultCommon");
			yield return lytAssetOp;
			yield return lytAssetOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) => {
				//0xB545E4
				instance.transform.SetParent(transform, false);
				commonLayoutController = instance.GetComponent<ResultCommonLayoutController>();
			});
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			UnityEngine.Debug.Log("Exit Co_LoadCommonLayout");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x722834 Offset: 0x722834 VA: 0x722834
		// // RVA: 0xB4F948 Offset: 0xB4F948 VA: 0xB4F948
		private IEnumerator Co_LoadScoreLayout()
		{
			StringBuilder bundleName; // 0x14
			AssetBundleLoadLayoutOperationBase lytAssetOp; // 0x18

			//0xB5DF0C
			bundleName = new StringBuilder();
			bundleName.Set("ly/023.xab");
			lytAssetOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_ResultScore");
			yield return lytAssetOp;
			yield return lytAssetOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) => {
				//0xB546B4
				instance.transform.SetParent(transform, false);
				scoreLayoutController = instance.GetComponent<ResultScoreLayoutController>();
			});
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7228AC Offset: 0x7228AC VA: 0x7228AC
		// // RVA: 0xB4F9F4 Offset: 0xB4F9F4 VA: 0xB4F9F4
		private IEnumerator Co_LoadDivaLayout()
		{
			StringBuilder bundleName; // 0x14
			AssetBundleLoadLayoutOperationBase lytAssetOp; // 0x18

			//0xB5B850
			bundleName = new StringBuilder();
			bundleName.Set("ly/024.xab");
			lytAssetOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_ResultDiva");
			yield return lytAssetOp;
			yield return lytAssetOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) => {
				//0xB54784
				instance.transform.SetParent(transform, false);
				divaLayoutController = instance.GetComponent<ResultDivaLayoutController>();
			});
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x722924 Offset: 0x722924 VA: 0x722924
		// // RVA: 0xB4FAA0 Offset: 0xB4FAA0 VA: 0xB4FAA0
		private IEnumerator Co_PopupAchieveRewardLayout()
		{
			AssetBundleLoadLayoutOperationBase lytAssetOp;

			//0xB5EE38
			if(scoreLayoutInitParam.achieveRewardSetting == null)
				yield break;
			lytAssetOp = AssetBundleManager.LoadLayoutAsync(scoreLayoutInitParam.achieveRewardSetting.BundleName, scoreLayoutInitParam.achieveRewardSetting.AssetName);
			yield return lytAssetOp;
			yield return lytAssetOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) => {
				//0xB54854
				scoreLayoutInitParam.achieveRewardSetting.SetContent(instance);
			});
			scoreLayoutInitParam.achieveRewardSetting.SetParent(transform);
			AssetBundleManager.UnloadAssetBundle(scoreLayoutInitParam.achieveRewardSetting.BundleName, false);
		}

		// // RVA: 0xB4FB4C Offset: 0xB4FB4C VA: 0xB4FB4C
		private bool IsReadyPopupAchieveRewardLayout()
		{
			if(scoreLayoutInitParam == null || scoreLayoutInitParam.achieveRewardSetting == null)
				return true;
			return scoreLayoutInitParam.achieveRewardSetting.Content != null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x72299C Offset: 0x72299C VA: 0x72299C
		// // RVA: 0xB4FC04 Offset: 0xB4FC04 VA: 0xB4FC04
		private IEnumerator Co_LoadDropLayout()
		{
			StringBuilder bundleName; // 0x18
			AssetBundleLoadLayoutOperationBase lytAssetOp; // 0x1C
			FontInfo fontInfo; // 0x20
			AssetBundleLoadLayoutOperationBase itemSetOp; // 0x24
			GameObject prefab; // 0x28

			//0xB5BBD0
			bundleName = new StringBuilder();
			bundleName.Set("ly/026.xab");
			lytAssetOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_ResultDrop");
			yield return lytAssetOp;
			yield return lytAssetOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) => {
				//0xB57A58
				instance.transform.SetParent(transform, false);
				dropLayoutController = instance.GetComponent<ResultDropLayoutController>();
			});
			itemSetOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "Item");
			yield return itemSetOp;
			prefab = itemSetOp.GetAsset<GameObject>();
			Layout layout = null;
			TexUVListManager uvMan = null;

			itemSetOp.CreateLayoutCoroutine(prefab.GetComponent<LayoutUGUIRuntime>(), GameManager.Instance.GetSystemFont(), (Layout loadLayout, TexUVListManager loadUvMan) => {
				//0xB57B54
				layout = loadLayout;
				uvMan = loadUvMan;
			});
			int num = dropLayoutInitParam.viewDropResultData.HBHMAKNGKFK.Count;
			dropLayoutInitParam.layoutItemList = new List<LayoutResultDropItem>(num);
			for(int i = 0; i < num; i++)
			{
				GameObject g = Instantiate(prefab);
				LayoutUGUIRuntime r = g.GetComponent<LayoutUGUIRuntime>();
				r.IsLayoutAutoLoad = false;
				r.Layout = layout.DeepClone();
				r.UvMan = uvMan;
				r.LoadLayout();
				dropLayoutInitParam.layoutItemList.Add(g.GetComponent<LayoutResultDropItem>());
			}
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);

		}

		// [IteratorStateMachineAttribute] // RVA: 0x722A14 Offset: 0x722A14 VA: 0x722A14
		// // RVA: 0xB4FCB0 Offset: 0xB4FCB0 VA: 0xB4FCB0
		private IEnumerator Co_LoadEvent01Layout()
		{
			TodoLogger.Log(0, "Co_LoadEvent01Layout");
			yield return null;
		}

		// // RVA: 0xB4FD5C Offset: 0xB4FD5C VA: 0xB4FD5C
		// private void CallbackEventHiScoreWindowLayoutOpen() { }

		// // RVA: 0xB4FDAC Offset: 0xB4FDAC VA: 0xB4FDAC
		// private void CallbackEventHiScoreWindowLayoutClose() { }

		// [IteratorStateMachineAttribute] // RVA: 0x722A8C Offset: 0x722A8C VA: 0x722A8C
		// // RVA: 0xB4FDFC Offset: 0xB4FDFC VA: 0xB4FDFC
		private IEnumerator Co_LoadEvent02Layout()
		{
			TodoLogger.Log(0, "Co_LoadEvent02Layout");
			yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x722B04 Offset: 0x722B04 VA: 0x722B04
		// // RVA: 0xB4FEA8 Offset: 0xB4FEA8 VA: 0xB4FEA8
		private IEnumerator Co_LoadEvent03Layout()
		{
			TodoLogger.Log(0, "Co_LoadEvent03Layout");
			yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x722B7C Offset: 0x722B7C VA: 0x722B7C
		// // RVA: 0xB4FF54 Offset: 0xB4FF54 VA: 0xB4FF54
		private IEnumerator Co_LoadRaidLayout()
		{
			TodoLogger.Log(0, "Co_LoadRaidLayout");
			yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x722BF4 Offset: 0x722BF4 VA: 0x722BF4
		// // RVA: 0xB50000 Offset: 0xB50000 VA: 0xB50000
		private IEnumerator Co_LoadGoDivaLayout()
		{
			TodoLogger.Log(0, "Co_LoadGoDivaLayout");
			yield return null;
		}

		// // RVA: 0xB500AC Offset: 0xB500AC VA: 0xB500AC Slot: 18
		protected override void OnPostSetCanvas()
		{
			if(TransitionType == MenuTransitionControl.TransitionType.Return)
				return;
			InitParam();
			StartCoroutine(Co_LoadLayout());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x722C6C Offset: 0x722C6C VA: 0x722C6C
		// // RVA: 0xB500EC Offset: 0xB500EC VA: 0xB500EC
		private IEnumerator Co_LoadLayout()
		{
			UnityEngine.Debug.Log("Enter Co_LoadLayout");
			//0xB5D5E0
			yield return StartCoroutine(Co_LoadCommonLayout());
			yield return StartCoroutine(Co_PopupAchieveRewardLayout());
			yield return StartCoroutine(Co_LoadScoreLayout());
			UnityEngine.Debug.Log("Exit Co_LoadLayout");
		}

		// RVA: 0xB50198 Offset: 0xB50198 VA: 0xB50198 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			if(TransitionType != MenuTransitionControl.TransitionType.Return)
			{
				if(!IsReadyPopupAchieveRewardLayout())
					return false;
				if(commonLayoutController == null)
					return false;
				if(!commonLayoutController.IsReady())
					return false;
				if(scoreLayoutController == null)
					return false;
				if(!scoreLayoutController.IsReady())
					return false;
				commonLayoutController.transform.SetAsLastSibling();
				scoreLayoutController.transform.SetAsLastSibling();
			}
			return true;
		}

		// RVA: 0xB50578 Offset: 0xB50578 VA: 0xB50578 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			if(TransitionType == MenuTransitionControl.TransitionType.Return)
			{
				MenuScene.Instance.divaManager.SetActive(false, true);
				return;
			}
			task = InitScoreResult;
		}

		// RVA: 0xB50694 Offset: 0xB50694 VA: 0xB50694 Slot: 23
		protected override void OnActivateScene()
		{
			if(TransitionType != MenuTransitionControl.TransitionType.Return)
				return;
			MenuScene.Instance.HelpButton.ShowRaidResultHelpButton();
		}

		// // RVA: 0xB50768 Offset: 0xB50768 VA: 0xB50768
		private void InitScoreResult()
		{
			GameManager.Instance.SetFPS(60);
			if(Database.Instance.gameSetup.EnableLiveSkip)
			{
				if(eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid)
				{
					TodoLogger.Log(0, "Todo Event");
				}
				TodoLogger.Log(0, "Todo Skip");
			}
			else
			{
				commonLayoutController.ChangeViewForScoreResult();
			}
			scoreLayoutInitParam.layoutHeaderTitle = commonLayoutController.LayoutHeaderTitle;
			scoreLayoutInitParam.layoutOkayButton = commonLayoutController.LayoutOkayButton;
			scoreLayoutController.Setup(scoreLayoutInitParam);
			scoreLayoutController.onClickOkayButton = OnClickScoreResultOkayButton;
			scoreLayoutController.StartAnim();
			task = UpdateScoreResult;
		}

		// // RVA: 0xB50ED4 Offset: 0xB50ED4 VA: 0xB50ED4
		private void UpdateScoreResult()
		{
			return;
		}

		// // RVA: 0xB50ED8 Offset: 0xB50ED8 VA: 0xB50ED8
		private void OnClickScoreResultOkayButton()
		{
			MenuScene.Instance.InputDisable();
			EndScoreResult();
		}

		// // RVA: 0xB50F80 Offset: 0xB50F80 VA: 0xB50F80
		private void EndScoreResult()
		{
			GameManager.Instance.fullscreenFader.Fade(0.2f, new Color(Color.white.r, Color.white.g, Color.white.b, 1));
			StartCoroutine(Co_EndScoreResult());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x722CE4 Offset: 0x722CE4 VA: 0x722CE4
		// // RVA: 0xB51094 Offset: 0xB51094 VA: 0xB51094
		private IEnumerator Co_EndScoreResult()
		{
			bool isEventCollection; // 0x14
			bool isEventMission; // 0x15
			bool isEventBattle; // 0x16
			bool isEventRaid; // 0x17
			bool isEventGoDiva; // 0x18

			//0xB58DEC
			yield return new WaitWhile(() => {
				//0xB56028
				return GameManager.Instance.fullscreenFader.isFading;
			});
			if(!isInTutorial)
			{
				yield return StartCoroutine(Co_LoadDivaLayout());
			}
			yield return StartCoroutine(Co_LoadDropLayout());
			isEventCollection = eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection;
			if(isEventCollection)
				yield return StartCoroutine(Co_LoadEvent01Layout());
			isEventMission = eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.NKDOEBONGNI_EventQuest;
			if(isEventMission)
			{
				yield return StartCoroutine(Co_LoadEvent02Layout());
			}
			isEventBattle = eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle;
			if(isEventBattle)
			{
				yield return StartCoroutine(Co_LoadEvent03Layout());
			}
			isEventRaid = eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid;
			if(isEventRaid)
			{
				yield return StartCoroutine(Co_LoadRaidLayout());
			}
			isEventGoDiva = eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva;
			if(isEventGoDiva)
			{
				divaLayoutController.SetGoDivaLayout();
				yield return StartCoroutine(Co_LoadGoDivaLayout());
			}
			
			yield return new WaitForSeconds(0.5f);

			if(!isInTutorial)
			{
				yield return new WaitWhile(() => {
					//0xB55504
					if(divaLayoutController == null)
						return true;
					return !divaLayoutController.IsReady();
				});
				divaLayoutController.PreloadDivaIcon(divaLayoutInitParam);
				yield return new WaitUntil(() => {
					//0xB555C4
					return divaLayoutController.IsPreloadedDivaIcon();
				});
			}
			yield return new WaitWhile(() => {
				//0xB555F0
				if(dropLayoutController == null)
					return true;
				return !dropLayoutController.IsReady();
			});
			if(isEventCollection)
			{
				yield return new WaitWhile(() => {
					//0xB556B0
					TodoLogger.Log(0, "Event");
					return false;
				});
			}
			if(isEventMission)
			{
				yield return new WaitWhile(() => {
					//0xB55770
					TodoLogger.Log(0, "Event");
					return false;
				});
			}
			if(isEventBattle)
			{
				yield return new WaitWhile(() => {
					//0xB55830
					TodoLogger.Log(0, "Event");
					return false;
				});
				yield return new WaitWhile(() => {
					//0xB558F0
					TodoLogger.Log(0, "Event");
					return false;
				});
			}
			if(isEventRaid)
			{
				yield return new WaitWhile(() => {
					//0xB559B0
					TodoLogger.Log(0, "Event");
					return false;
				});
				yield return new WaitWhile(() => {
					//0xB55A70
					TodoLogger.Log(0, "Event");
					return false;
				});
				yield return new WaitWhile(() => {
					//0xB55B30
					TodoLogger.Log(0, "Event");
					return false;
				});
				yield return new WaitWhile(() => {
					//0xB55BF0
					TodoLogger.Log(0, "Event");
					return false;
				});
			}
			if(isEventGoDiva)
			{
				yield return new WaitWhile(() => {
					//0xB55CB0
					TodoLogger.Log(0, "Event");
					return false;
				});
			}
			if(!isInTutorial)
			{
				divaLayoutController.gameObject.SetActive(false);
			}
			dropLayoutController.gameObject.SetActive(false);
			if(isEventCollection)
			{
				event01LayoutController.gameObject.SetActive(false);
			}
			if(isEventMission)
			{
				event02LayoutController.gameObject.SetActive(false);
			}
			if(isEventBattle)
			{
				TodoLogger.Log(0, "Event");
				//event03ScoreLayoutController.SetActive(false);
				//event03PointLayoutController.SetActive(false);
			}
			if(isEventRaid)
			{
				raidResultPointLayoutController.gameObject.SetActive(false);
				raidResultDamageLayoutController.gameObject.SetActive(false);
				raidResultRewardLayoutController.gameObject.SetActive(false);
				raidResultBossFilter.gameObject.SetActive(false);
			}
			if(isEventGoDiva)
			{
				layoutResultGoDivaMain.gameObject.SetActive(false);
			}
			if(!isInTutorial)
			{
				divaLayoutController.transform.SetAsLastSibling();
			}
			dropLayoutController.transform.SetAsLastSibling();
			if(isEventCollection)
			{
				event01LayoutController.transform.SetAsLastSibling();
			}
			if(isEventMission)
			{
				event02LayoutController.transform.SetAsLastSibling();
			}
			if(isEventBattle)
			{
				event03ScoreLayoutController.transform.SetAsLastSibling();
				event03PointLayoutController.transform.SetAsLastSibling();
			}
			if(isEventRaid)
			{
				raidResultBossFilter.transform.SetAsLastSibling();
				raidResultPointLayoutController.transform.SetAsLastSibling();
				raidResultDamageLayoutController.transform.SetAsLastSibling();
				raidResultRewardLayoutController.transform.SetAsLastSibling();
			}
			if(isEventGoDiva)
			{
				layoutResultGoDivaMain.transform.SetAsLastSibling();
			}
			commonLayoutController.transform.SetAsLastSibling();
			if(!isInTutorial)
			{
				GameManager.Instance.fullscreenFader.Fade(0.2f, 0);
			}
			MenuScene.Instance.divaManager.SetActive(false, true);
			GameManager.Instance.SetFPS(30);
			Destroy(scoreLayoutController.gameObject);
			if(!isInTutorial)
			{
				InitDivaResult();
			}
			else
			{
				while(GameManager.Instance.fullscreenFader.isFading)
					yield return null;
				StartCoroutine(Co_MountMenuScene(false));
			}
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0xB51140 Offset: 0xB51140 VA: 0xB51140
		private void InitDivaResult()
		{
			commonLayoutController.ChangeViewForDivaResult();
			divaLayoutInitParam.layoutOkayButton = commonLayoutController.LayoutOkayButton;
			divaLayoutController.gameObject.SetActive(true);
			divaLayoutController.onClickOkayButton = OnClickDivaResultOkayButton;
			divaLayoutController.Setup(divaLayoutInitParam);
			divaLayoutController.StartCountPoint();
			task = UpdateDivaResult;
		}

		// // RVA: 0xB51300 Offset: 0xB51300 VA: 0xB51300
		private void UpdateDivaResult()
		{
			return;
		}

		// // RVA: 0xB51304 Offset: 0xB51304 VA: 0xB51304
		private void OnClickDivaResultOkayButton()
		{
			MenuScene.Instance.InputDisable();
			StartCoroutine(Co_EndDivaResult());
		}

		// // RVA: 0xB513BC Offset: 0xB513BC VA: 0xB513BC
		// private void EndDivaResult() { }

		// [IteratorStateMachineAttribute] // RVA: 0x722D5C Offset: 0x722D5C VA: 0x722D5C
		// // RVA: 0xB513E0 Offset: 0xB513E0 VA: 0xB513E0
		private IEnumerator Co_EndDivaResult()
		{
			//0xB57F00
			commonLayoutController.StartEndDivaResultAnim();
			bool isEndAnim = false;
			divaLayoutController.StartEndAnim(() => {
				//0xB57B68
				isEndAnim = true;
			});
			yield return new WaitUntil(() => {
				//0xB57B74
				return isEndAnim;
			});
			Destroy(divaLayoutController.gameObject);
			InitDropResult();
			yield return null;
			while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
			StartDropResultAnim();
			MenuScene.Instance.InputEnable();
		}

		// RVA: 0xB5148C Offset: 0xB5148C VA: 0xB5148C Slot: 15
		protected override void OnDeleteCache()
		{
			FFHPBEPOMAK_DivaInfo divaInfo = GameManager.Instance.GetHomeDiva();
			if(MenuScene.Instance.divaManager.Compare(divaInfo.AHHJLDLAPAN_DivaId, divaInfo.EOJIGHEFIAA_GetHomeDivaPrismCostumeId(), divaInfo.LHGJHJLGPBE_GetHomeDivaColorId()))
			{
				return;
			}
			MenuScene.Instance.divaManager.Release(true);
		}

		// // RVA: 0xB516A0 Offset: 0xB516A0 VA: 0xB516A0
		private void InitDropResult()
		{
			commonLayoutController.ChangeViewForDropResult();
			dropLayoutInitParam.layoutOkayButton = commonLayoutController.LayoutOkayButton;
			dropLayoutController.gameObject.SetActive(true);
			dropLayoutController.onClickOkayButton = OnClickDropResultOkayButton;
			dropLayoutController.onClickSendFriendRequest = OnClickSendFriendRequest;
			dropLayoutController.Setup(dropLayoutInitParam);
			task = UpdateDropResult;
		}

		// // RVA: 0xB51890 Offset: 0xB51890 VA: 0xB51890
		private void StartDropResultAnim()
		{
			dropLayoutController.StartAnim();
		}

		// // RVA: 0xB518BC Offset: 0xB518BC VA: 0xB518BC
		private void UpdateDropResult()
		{
			return;
		}

		// // RVA: 0xB518C0 Offset: 0xB518C0 VA: 0xB518C0
		private void OnClickDropResultOkayButton()
		{
			MenuScene.Instance.InputDisable();
			StartCoroutine(Co_EndDropResult());
		}

		// // RVA: 0xB51978 Offset: 0xB51978 VA: 0xB51978
		// private void EndDropResult() { }

		// [IteratorStateMachineAttribute] // RVA: 0x722DD4 Offset: 0x722DD4 VA: 0x722DD4
		// // RVA: 0xB5199C Offset: 0xB5199C VA: 0xB5199C
		private IEnumerator Co_EndDropResult()
		{
			bool isCollectionEventOpen; // 0x18
			bool isBattleEventOpen; // 0x19
			bool isMissionEventOpen; // 0x1A
			bool isRaidEventOpen; // 0x1B
			bool isGoDivaEventOpen; // 0x1C

			//0xB582CC
			isCollectionEventOpen = eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection;
			isBattleEventOpen = eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle;
			isMissionEventOpen = eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.NKDOEBONGNI_EventQuest;
			isRaidEventOpen = eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid;
			isGoDivaEventOpen = eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva;

			if(!isGoDivaEventOpen && !isCollectionEventOpen && !isBattleEventOpen && 
				!isMissionEventOpen && !isRaidEventOpen)
			{
				GameManager.Instance.fullscreenFader.Fade(0.1f, Color.black);
			}
			bool isEndAnim = false;
			dropLayoutController.StartEndAnim(() => {
				//0xB57B84
				isEndAnim = true;
			});
			yield return new WaitUntil(() => {
				//0xB57B90
				return isEndAnim;
			});
			Destroy(dropLayoutController.gameObject);
			if(isCollectionEventOpen)
			{
				InitEvent01Result();
				while(IsEvent01ResultLoading())
					yield return null;
				StartEvent01ResultAnim();
			}
			else if(isMissionEventOpen)
			{
				InitEvent02Result();
				while(IsEvent02ResultLoading())
					yield return null;
				StartEvent02ResultAnim();
			}
			else if(isGoDivaEventOpen)
			{
				StartCoroutine(Co_InitGoDivaResult());
			}
			else if(isBattleEventOpen)
			{
				InitEvent03WinLose();
			}
			else if(isRaidEventOpen)
			{
				TodoLogger.Log(0, "Event Raid");
			}
			else
			{
				while(GameManager.Instance.fullscreenFader.isFading)
					yield return null;
				StartCoroutine(Co_MountMenuScene(false));
			}
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0xB51A48 Offset: 0xB51A48 VA: 0xB51A48
		private void OnClickSendFriendRequest()
		{
			TodoLogger.LogNotImplemented("OnClickSendFriendRequest");
		}

		// // RVA: 0xB51DB4 Offset: 0xB51DB4 VA: 0xB51DB4
		// private void OnSuccessFriendRequest() { }

		// // RVA: 0xB51A4C Offset: 0xB51A4C VA: 0xB51A4C
		// private void ShowFriendRequestPopup() { }

		// // RVA: 0xB5208C Offset: 0xB5208C VA: 0xB5208C
		// private void DoFriendRequest() { }

		// // RVA: 0xB522E8 Offset: 0xB522E8 VA: 0xB522E8
		// private void OnErrorFriendRequest(CACGCMBKHDI action) { }

		// // RVA: 0xB52384 Offset: 0xB52384 VA: 0xB52384
		// private void OnErrorToTitleFriendRequest(CACGCMBKHDI action) { }

		// [IteratorStateMachineAttribute] // RVA: 0x722E4C Offset: 0x722E4C VA: 0x722E4C
		// // RVA: 0xB52454 Offset: 0xB52454 VA: 0xB52454
		// private IEnumerator ShowDropTutorialPopup() { }

		// // RVA: 0xB52500 Offset: 0xB52500 VA: 0xB52500
		// private bool CheckTutorialCodition(TutorialConditionId conditionId) { }

		// // RVA: 0xB52510 Offset: 0xB52510 VA: 0xB52510
		private void InitEvent01Result()
		{
			TodoLogger.Log(0, "InitEvent01Result");
		}

		// // RVA: 0xB526B8 Offset: 0xB526B8 VA: 0xB526B8
		private bool IsEvent01ResultLoading()
		{
			TodoLogger.Log(0, "IsEvent01ResultLoading");
			return false;
		}

		// // RVA: 0xB526E4 Offset: 0xB526E4 VA: 0xB526E4
		private void StartEvent01ResultAnim()
		{
			TodoLogger.Log(0, "StartEvent01ResultAnim");
		}

		// // RVA: 0xB52710 Offset: 0xB52710 VA: 0xB52710
		// private void UpdateEvent01Result() { }

		// // RVA: 0xB52714 Offset: 0xB52714 VA: 0xB52714
		// private void OnClickEvent01ResultOkayButton() { }

		// // RVA: 0xB5273C Offset: 0xB5273C VA: 0xB5273C
		// private void EndEvent01Result() { }

		// // RVA: 0xB52764 Offset: 0xB52764 VA: 0xB52764
		private void InitEvent02Result()
		{
			TodoLogger.Log(0, "InitEvent02Result");
		}

		// // RVA: 0xB52904 Offset: 0xB52904 VA: 0xB52904
		private bool IsEvent02ResultLoading()
		{
			TodoLogger.Log(0, "IsEvent02ResultLoading");
			return false;
		}

		// // RVA: 0xB52930 Offset: 0xB52930 VA: 0xB52930
		private void StartEvent02ResultAnim()
		{
			TodoLogger.Log(0, "StartEvent02ResultAnim");
		}

		// // RVA: 0xB5295C Offset: 0xB5295C VA: 0xB5295C
		// private void UpdateEvent02Result() { }

		// // RVA: 0xB52960 Offset: 0xB52960 VA: 0xB52960
		// private void OnClickEvent02ResultOkayButton() { }

		// // RVA: 0xB52988 Offset: 0xB52988 VA: 0xB52988
		// private void EndEvent02Result() { }

		// // RVA: 0xB529B0 Offset: 0xB529B0 VA: 0xB529B0
		// private void InitGoDivaResult() { }

		// [IteratorStateMachineAttribute] // RVA: 0x722EC4 Offset: 0x722EC4 VA: 0x722EC4
		// // RVA: 0xB529D4 Offset: 0xB529D4 VA: 0xB529D4
		private IEnumerator Co_InitGoDivaResult()
		{
			TodoLogger.Log(0, "Co_InitGoDivaResult");
			yield return null;
		}

		// // RVA: 0xB52A80 Offset: 0xB52A80 VA: 0xB52A80
		// private bool IsGoDivaResultLoading() { }

		// // RVA: 0xB52AAC Offset: 0xB52AAC VA: 0xB52AAC
		// private void StartGoDivaResultAnim() { }

		// // RVA: 0xB52AD8 Offset: 0xB52AD8 VA: 0xB52AD8
		// private void UpdateGoDivaResult() { }

		// // RVA: 0xB52ADC Offset: 0xB52ADC VA: 0xB52ADC
		// private void EndGoDivaResult() { }

		// // RVA: 0xB52B04 Offset: 0xB52B04 VA: 0xB52B04
		private void InitEvent03WinLose()
		{
			TodoLogger.Log(0, "InitEvent03WinLose");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x722F3C Offset: 0x722F3C VA: 0x722F3C
		// // RVA: 0xB52B4C Offset: 0xB52B4C VA: 0xB52B4C
		// private IEnumerator Co_InitEvent03WinLose() { }

		// // RVA: 0xB52BF8 Offset: 0xB52BF8 VA: 0xB52BF8
		// private void UpdateEvent03WinLose() { }

		// // RVA: 0xB52BFC Offset: 0xB52BFC VA: 0xB52BFC
		// private void OnClickEvent03WinLoseOkayButton() { }

		// // RVA: 0xB52C00 Offset: 0xB52C00 VA: 0xB52C00
		// private void EndEvent03WinLose() { }

		// // RVA: 0xB52CFC Offset: 0xB52CFC VA: 0xB52CFC
		// private void InitEvent03Result() { }

		// [IteratorStateMachineAttribute] // RVA: 0x722FB4 Offset: 0x722FB4 VA: 0x722FB4
		// // RVA: 0xB52D20 Offset: 0xB52D20 VA: 0xB52D20
		// private IEnumerator Co_InitEvent03Result() { }

		// // RVA: 0xB52DCC Offset: 0xB52DCC VA: 0xB52DCC
		// private void UpdateEvent03Result() { }

		// // RVA: 0xB52DD0 Offset: 0xB52DD0 VA: 0xB52DD0
		// private void OnClickEvent03ResultOkayButton() { }

		// // RVA: 0xB52DF8 Offset: 0xB52DF8 VA: 0xB52DF8
		// private void EndEvent03Result() { }

		// // RVA: 0xB52E20 Offset: 0xB52E20 VA: 0xB52E20
		// private void InitRaidPointResult() { }

		// // RVA: 0xB53428 Offset: 0xB53428 VA: 0xB53428
		// private bool IsRaidPointResultLoading() { }

		// // RVA: 0xB53458 Offset: 0xB53458 VA: 0xB53458
		// private void StartRaidPointResultAnim() { }

		// [IteratorStateMachineAttribute] // RVA: 0x72302C Offset: 0x72302C VA: 0x72302C
		// // RVA: 0xB534F4 Offset: 0xB534F4 VA: 0xB534F4
		// private IEnumerator SetBossBg(Action callback) { }

		// // RVA: 0xB535A0 Offset: 0xB535A0 VA: 0xB535A0
		// private void OnClickRaidPointResultEnd() { }

		// // RVA: 0xB535FC Offset: 0xB535FC VA: 0xB535FC
		// private void InitRaidDamageResult() { }

		// // RVA: 0xB5375C Offset: 0xB5375C VA: 0xB5375C
		// private bool IsRaidDamageResultLoading() { }

		// // RVA: 0xB5370C Offset: 0xB5370C VA: 0xB5370C
		// private void StartRaidDamageResultAnim() { }

		// // RVA: 0xB5378C Offset: 0xB5378C VA: 0xB5378C
		// private void OnClickRaidDamageResultEnd() { }

		// // RVA: 0xB53EC0 Offset: 0xB53EC0 VA: 0xB53EC0
		// private void InitRaidRewardResult() { }

		// // RVA: 0xB540A8 Offset: 0xB540A8 VA: 0xB540A8
		// private bool IsRaidRewardResultLoading() { }

		// // RVA: 0xB54058 Offset: 0xB54058 VA: 0xB54058
		// private void StartRaidRewardResultAnim() { }

		// // RVA: 0xB540D8 Offset: 0xB540D8 VA: 0xB540D8
		// private void OnClickRaidRewardResultEnd() { }

		// // RVA: 0xB54030 Offset: 0xB54030 VA: 0xB54030
		// private void EndRaidResult() { }

		// // RVA: 0xB54100 Offset: 0xB54100 VA: 0xB54100
		// private void OnClickMemberListButton() { }

		// // RVA: 0xB530D4 Offset: 0xB530D4 VA: 0xB530D4
		// private void ShowRaidBossEscapedPop() { }

		// [IteratorStateMachineAttribute] // RVA: 0x7230A4 Offset: 0x7230A4 VA: 0x7230A4
		// // RVA: 0xB523AC Offset: 0xB523AC VA: 0xB523AC
		private IEnumerator Co_MountMenuScene(bool isError)
		{
			GameSetupData.MusicInfo musicInfo; // 0x1C

			//0xB5E28C
			if(isError)
			{
				MenuScene.Instance.GotoTitle();
			}
			else
			{
				if(GameManager.Instance.IsTutorial)
				{
					TodoLogger.Log(0, "Tuto");
				}
				else
				{
					bool isChangedCueSheet = true;
					SoundManager.Instance.voDiva.RequestChangeCueSheet(GetNowDivaId(), () => {
						//0xB57A1C
						isChangedCueSheet = false;
					});
					while(isChangedCueSheet)
						yield return null;
					PGIGNJDPCAH.HIHIEBACIHJ(PGIGNJDPCAH.FELLIEJEPIJ.NADCOIBMMJM);
					switch(Database.Instance.gameSetup.musicInfo.gameEventType)
					{
						case OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection:
							TodoLogger.Log(0, "Event");
							break;
						default:
							MusicSelectArgs args = new MusicSelectArgs();
							args.isLine6Mode = Database.Instance.gameSetup.musicInfo.IsLine6Mode;
							MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, args, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
							break;
						case OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle:
							TodoLogger.Log(0, "Event");
							break;
						case OHCAABOMEOF.KGOGMKMBCPP_EventType.KEILBOLBDHN:
							TodoLogger.Log(0, "Event");
							break;
						case OHCAABOMEOF.KGOGMKMBCPP_EventType.NKDOEBONGNI_EventQuest:
							TodoLogger.Log(0, "Event");
							break;
						case OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid:
							TodoLogger.Log(0, "Event");
							break;
						case OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva:
							TodoLogger.Log(0, "Event");
							break;
					}
				}
			}
			//LAB_00b5ec90
			Database.Instance.gameResult.Reset();
			SoundManager.Instance.bgmPlayer.Stop();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x72311C Offset: 0x72311C VA: 0x72311C
		// // RVA: 0xB541D4 Offset: 0xB541D4 VA: 0xB541D4
		// private IEnumerator Co_CheckClosedEvent_ScoreRanking(Action<bool> onFinsihed) { }

		// // RVA: 0xB54280 Offset: 0xB54280 VA: 0xB54280
		private int GetNowDivaId()
		{
			FFHPBEPOMAK_DivaInfo divaInfo = GameManager.Instance.ViewPlayerData.DPLBHAIKPGL_GetTeam(eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva).BCJEAJPLGMB_MainDivas[0];
			int res = 10;
			if(divaInfo != null)
				res = divaInfo.AHHJLDLAPAN_DivaId;
			int homeId = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.BBIOMNCILMC_HomeDivaId;
			if(homeId > 0)
			{
				res = GameManager.Instance.ViewPlayerData.NBIGLBMHEDC[homeId - 1].AHHJLDLAPAN_DivaId;
			}
			return res;
		}

		// // RVA: 0xB54488 Offset: 0xB54488 VA: 0xB54488
		public static bool IsScreenTouch()
		{
			return InputManager.Instance.IsScreenTouch();
		}

		// // RVA: 0xB54540 Offset: 0xB54540 VA: 0xB54540
		// public static int GetInScreenTouchCount() { }

		// [CompilerGeneratedAttribute] // RVA: 0x7231D4 Offset: 0x7231D4 VA: 0x7231D4
		// // RVA: 0xB5489C Offset: 0xB5489C VA: 0xB5489C
		// private void <Co_LoadEvent01Layout>b__39_0(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x7231E4 Offset: 0x7231E4 VA: 0x7231E4
		// // RVA: 0xB5496C Offset: 0xB5496C VA: 0xB5496C
		// private void <Co_LoadEvent01Layout>b__39_1(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x7231F4 Offset: 0x7231F4 VA: 0x7231F4
		// // RVA: 0xB54BC8 Offset: 0xB54BC8 VA: 0xB54BC8
		// private void <Co_LoadEvent02Layout>b__42_0(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x723204 Offset: 0x723204 VA: 0x723204
		// // RVA: 0xB54C98 Offset: 0xB54C98 VA: 0xB54C98
		// private void <Co_LoadEvent03Layout>b__43_0(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x723214 Offset: 0x723214 VA: 0x723214
		// // RVA: 0xB54DAC Offset: 0xB54DAC VA: 0xB54DAC
		// private void <Co_LoadRaidLayout>b__44_0(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x723224 Offset: 0x723224 VA: 0x723224
		// // RVA: 0xB54E7C Offset: 0xB54E7C VA: 0xB54E7C
		// private void <Co_LoadRaidLayout>b__44_1(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x723234 Offset: 0x723234 VA: 0x723234
		// // RVA: 0xB54F4C Offset: 0xB54F4C VA: 0xB54F4C
		// private void <Co_LoadRaidLayout>b__44_2(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x723244 Offset: 0x723244 VA: 0x723244
		// // RVA: 0xB5501C Offset: 0xB5501C VA: 0xB5501C
		// private void <Co_LoadRaidLayout>b__44_3(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x723254 Offset: 0x723254 VA: 0x723254
		// // RVA: 0xB550EC Offset: 0xB550EC VA: 0xB550EC
		// private void <Co_LoadGoDivaLayout>b__45_0(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x723264 Offset: 0x723264 VA: 0x723264
		// // RVA: 0xB55348 Offset: 0xB55348 VA: 0xB55348
		// private void <Co_LoadGoDivaLayout>b__45_1(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x723334 Offset: 0x723334 VA: 0x723334
		// // RVA: 0xB55D70 Offset: 0xB55D70 VA: 0xB55D70
		// private void <OnSuccessFriendRequest>b__69_0(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }

		// [CompilerGeneratedAttribute] // RVA: 0x723344 Offset: 0x723344 VA: 0x723344
		// // RVA: 0xB55E28 Offset: 0xB55E28 VA: 0xB55E28
		// private void <ShowFriendRequestPopup>b__70_0(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }

		// [CompilerGeneratedAttribute] // RVA: 0x723354 Offset: 0x723354 VA: 0x723354
		// // RVA: 0xB55E34 Offset: 0xB55E34 VA: 0xB55E34
		// private bool <Co_InitGoDivaResult>b__89_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x723364 Offset: 0x723364 VA: 0x723364
		// // RVA: 0xB55E64 Offset: 0xB55E64 VA: 0xB55E64
		// private bool <Co_InitEvent03WinLose>b__95_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x723374 Offset: 0x723374 VA: 0x723374
		// // RVA: 0xB55E90 Offset: 0xB55E90 VA: 0xB55E90
		// private void <EndEvent03WinLose>b__98_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x723384 Offset: 0x723384 VA: 0x723384
		// // RVA: 0xB55EB4 Offset: 0xB55EB4 VA: 0xB55EB4
		// private void <StartRaidPointResultAnim>b__106_0() { }
	}
}
