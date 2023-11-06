using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class QuestTopScene : TransitionRoot
	{
		private const int ITEM_NUM = 6;
		private const string BUNDLE_NAME = "ly/059.xab";
		private LayoutQuestTab m_layoutTab; // 0x48
		private LayoutQuestScrollListVertical m_layoutScrollListV; // 0x4C
		private LayoutQuestScrollListHorizontal m_layoutScrollListH; // 0x50
		private List<LayoutQuestHorizontalItem> m_eventMissionButtonList = new List<LayoutQuestHorizontalItem>(); // 0x54
		public LayoutQuestTab.eTabType[] m_tabTbl = new LayoutQuestTab.eTabType[7] { LayoutQuestTab.eTabType.Daily, LayoutQuestTab.eTabType.Daily, LayoutQuestTab.eTabType.Normal, LayoutQuestTab.eTabType.Diva, LayoutQuestTab.eTabType.Event, LayoutQuestTab.eTabType.Beginner, LayoutQuestTab.eTabType.Bingo }; // 0x58
		private LayoutQuestTab.eTabType m_tabType = LayoutQuestTab.eTabType.Daily; // 0x5C
		private SnsScreen m_snsScreen; // 0x60
		private long m_currentTime; // 0x68
		private bool m_isSetupLayout; // 0x70

		// RVA: 0x9D9B90 Offset: 0x9D9B90 VA: 0x9D9B90 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			this.StartCoroutineWatched(Co_LoadLayout());
		}

		//// RVA: 0x9D9C4C Offset: 0x9D9C4C VA: 0x9D9C4C
		//private void SetupLayout() { }

		//// RVA: 0x9DA404 Offset: 0x9DA404 VA: 0x9DA404
		//private void SetupInCurrentTab() { }

		//// RVA: 0x9DAC70 Offset: 0x9DAC70 VA: 0x9DAC70
		//private bool IsBingoMissionEnable() { }

		//// RVA: 0x9DACB4 Offset: 0x9DACB4 VA: 0x9DACB4
		//private bool IsBingoMissionHelp() { }

		//[IteratorStateMachineAttribute] // RVA: 0x710894 Offset: 0x710894 VA: 0x710894
		//// RVA: 0x9DB288 Offset: 0x9DB288 VA: 0x9DB288
		//public IEnumerator Co_TutorialBeginnerComplete(FKMOKDCJFEN view, LayoutQuestVerticalItem layout) { }

		//// RVA: 0x9DB368 Offset: 0x9DB368 VA: 0x9DB368
		//private int GetNowDivaId() { }

		//// RVA: 0x9DB53C Offset: 0x9DB53C VA: 0x9DB53C
		//private void ChangeTab(LayoutQuestTab.eTabType type) { }

		//// RVA: 0x9DB7D0 Offset: 0x9DB7D0 VA: 0x9DB7D0
		private bool TutorialChecker(TutorialConditionId conditionId)
		{
			if(conditionId == TutorialConditionId.Condition18)
			{
				if (m_tabType != LayoutQuestTab.eTabType.Normal)
					return true;
				return !QuestUtility.IsBeginnerQuest();
			}
			return false;
		}

		//// RVA: 0x9DA924 Offset: 0x9DA924 VA: 0x9DA924
		private void CheckTabIcon()
		{
			m_layoutTab.SwitchEmphasisIcon(1, QuestUtility.IsEmphasis(LayoutQuestTab.eTabType.Normal));
			m_layoutTab.SwitchEmphasisIcon(2, QuestUtility.IsEmphasis(LayoutQuestTab.eTabType.Daily));
			m_layoutTab.SwitchEmphasisIcon(3, QuestUtility.IsEmphasis(LayoutQuestTab.eTabType.Diva));
			m_layoutTab.SwitchEmphasisIcon(4, QuestUtility.IsEmphasis(LayoutQuestTab.eTabType.Beginner));
			m_layoutTab.SwitchEmphasisIcon(0, QuestUtility.IsEmphasis(LayoutQuestTab.eTabType.Event));
			m_layoutTab.SwitchEmphasisIcon(5, QuestUtility.IsEmphasis(LayoutQuestTab.eTabType.Bingo));
		}

		//// RVA: 0x9DAFF0 Offset: 0x9DAFF0 VA: 0x9DAFF0
		//private void CheckTabIcon(LayoutQuestTab.eTabType type) { }

		//// RVA: 0x9DA05C Offset: 0x9DA05C VA: 0x9DA05C
		//private void RefleshQuestList() { }

		//// RVA: 0x9DB870 Offset: 0x9DB870 VA: 0x9DB870
		//private void ConnectEventQuest(LayoutQuestTab.eTabType tab, List<CGJKNOCAPII> viewList) { }

		//[IteratorStateMachineAttribute] // RVA: 0x71090C Offset: 0x71090C VA: 0x71090C
		//// RVA: 0x9D9BC0 Offset: 0x9D9BC0 VA: 0x9D9BC0
		private IEnumerator Co_LoadLayout()
		{
			AssetBundleLoadLayoutOperationBase operation; // 0x1C
			int poolSize; // 0x20
			int i; // 0x24

			//0x9DF120
			operation = AssetBundleManager.LoadLayoutAsync("ly/059.xab", "root_sel_que_window_layout_root");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x9DDFA8
				m_layoutTab = instance.GetComponent<LayoutQuestTab>();
			}));
			AssetBundleManager.UnloadAssetBundle("ly/059.xab", false);
			while (!m_layoutTab.IsLoaded())
				yield return null;
			m_layoutTab.transform.SetParent(transform, false);
			operation = null;
			operation = AssetBundleManager.LoadLayoutAsync("ly/059.xab", "root_sel_que_list_layout_root");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x9DE024
				m_layoutScrollListV = instance.GetComponent<LayoutQuestScrollListVertical>();
			}));
			AssetBundleManager.UnloadAssetBundle("ly/059.xab", false);
			while (!m_layoutScrollListV.IsLoaded())
				yield return null;
			m_layoutScrollListV.transform.SetParent(transform, false);
			operation = null;
			SwapScrollList scrollList = m_layoutScrollListV.List;
			poolSize = scrollList.ScrollObjectCount;
			operation = AssetBundleManager.LoadLayoutAsync("ly/059.xab", "root_sel_que_items_list_layout_root");
			yield return operation;
			LayoutUGUIRuntime baseRuntime = null;
			yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x9DE6F4
				baseRuntime = instance.GetComponent<LayoutUGUIRuntime>();
				baseRuntime.name = string.Format(baseRuntime.name + "_{0:D2}", 0);
				scrollList.AddScrollObject(instance.GetComponent<SwapScrollListContent>());
			}));
			AssetBundleManager.UnloadAssetBundle("ly/059.xab", false);
			for(i = 1; i < poolSize; i++)
			{
				LayoutUGUIRuntime r = Instantiate(baseRuntime);
				r.name = string.Format(r.name + "_{0:D2}", i);
				r.IsLayoutAutoLoad = false;
				r.Layout = baseRuntime.Layout.DeepClone();
				r.UvMan = baseRuntime.UvMan;
				r.LoadLayout();
				scrollList.AddScrollObject(r.GetComponent<SwapScrollListContent>());
			}
			scrollList.Apply();
			scrollList.SetContentEscapeMode(true);
			for(i = 0; i < scrollList.ScrollObjectCount; i++)
			{
				while(!scrollList.ScrollObjects[i].IsLoaded())
					yield return null;
			}
			operation = null;
			operation = AssetBundleManager.LoadLayoutAsync("ly/059.xab", "root_sel_que_ev_select__layout_root");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x9DE0A0
				m_layoutScrollListH = instance.GetComponent<LayoutQuestScrollListHorizontal>();
			}));
			AssetBundleManager.UnloadAssetBundle("ly/059.xab", false);
			while (!m_layoutScrollListH.IsLoaded())
				yield return null;
			m_layoutScrollListH.transform.SetParent(transform, false);
			operation = null;
			if(!m_layoutScrollListH.IsItemAttach)
			{
				operation = AssetBundleManager.LoadLayoutAsync("ly/059.xab", "root_sel_que_event_icon_layout_root");
				yield return operation;
				LayoutUGUIRuntime runtime = null;
				yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0x9DE860
					runtime = instance.GetComponent<LayoutUGUIRuntime>();
				}));
				AssetBundleManager.UnloadAssetBundle("ly/059.xab", false);
				m_eventMissionButtonList.Clear();
				for(i = 0; i < 6; i++)
				{
					LayoutUGUIRuntime r = Instantiate(runtime);
					r.IsLayoutAutoLoad = false;
					r.UvMan = runtime.UvMan;
					r.Layout = runtime.Layout.DeepClone();
					r.LoadLayout();
					m_eventMissionButtonList.Add(r.GetComponent<LayoutQuestHorizontalItem>());
				}
				for(poolSize = 0; poolSize < m_eventMissionButtonList.Count; poolSize++)
				{
					while (!m_eventMissionButtonList[i].IsLoaded())
						yield return null;
				}
				Destroy(runtime.gameObject);
				runtime = null;
				m_layoutScrollListH.AddView(m_eventMissionButtonList);
				operation = null;
			}
			//LAB_009e0434
			LoadTexture();
			while (IsLoadingTexture())
				yield return null;
			IsReady = true;
		}

		//// RVA: 0x9DC580 Offset: 0x9DC580 VA: 0x9DC580
		private void LoadTexture()
		{
			List<int> l = new List<int>();
			LoadTextureInner(QuestUtility.m_dailyViewList, l);
			LoadTextureInner(QuestUtility.m_normalViewList, l);
			LoadTextureInner(QuestUtility.m_snsViewList, l);
			LoadTextureInner(QuestUtility.m_beginnerViewList, l);
			LoadTextureInner(QuestUtility.m_eventViewList);
		}

		//// RVA: 0x9DC69C Offset: 0x9DC69C VA: 0x9DC69C
		private void LoadTextureInner(List<FKMOKDCJFEN> list, List<int> requested)
		{
			for(int i = 0; i < list.Count; i++)
			{
				if(!requested.Contains(list[i].GOOIIPFHOIG.JJBGOIMEIPF_ItemFullId))
				{
					GameManager.Instance.ItemTextureCache.Load(list[i].GOOIIPFHOIG.JJBGOIMEIPF_ItemFullId, (IiconTexture texture) =>
					{
						//0x9DE300
						return;
					});
					requested.Add(list[i].GOOIIPFHOIG.JJBGOIMEIPF_ItemFullId);
				}
			}
		}

		//// RVA: 0x9DC9A0 Offset: 0x9DC9A0 VA: 0x9DC9A0
		private void LoadTextureInner(List<CGJKNOCAPII> list)
		{
			for(int i = 0; i < list.Count; i++)
			{
				GameManager.Instance.QuestEventTextureCache.LoadIcon(list[i].JHAOHBNPMNA_EventId, (IiconTexture texture) =>
				{
					//0x9DE304
					return;
				});
				GameManager.Instance.QuestEventTextureCache.LoadFont(list[i].LFCOJABLOEN, (IiconTexture texture) =>
				{
					//0x9DE308
					return;
				});
			}
		}

		//// RVA: 0x9DCDF0 Offset: 0x9DCDF0 VA: 0x9DCDF0
		private bool IsLoadingTexture()
		{
			return GameManager.Instance.ItemTextureCache.IsLoading() || GameManager.Instance.QuestEventTextureCache.IsLoading();
		}

		//// RVA: 0x9DCF2C Offset: 0x9DCF2C VA: 0x9DCF2C
		private void UpdateList()
		{
			QuestUtility.UpdateQuestData();
			m_layoutScrollListV.SetStatus(m_tabType);
			CheckTabIcon();
			QuestUtility.FooterMenuBadge();
		}

		//// RVA: 0x9DCFDC Offset: 0x9DCFDC VA: 0x9DCFDC
		//private void OnClickReceiveAll() { }

		//// RVA: 0x9DD318 Offset: 0x9DD318 VA: 0x9DD318
		//private void LayoutIn() { }

		//// RVA: 0x9DD42C Offset: 0x9DD42C VA: 0x9DD42C
		//private void LayoutOut() { }

		//[IteratorStateMachineAttribute] // RVA: 0x710984 Offset: 0x710984 VA: 0x710984
		//// RVA: 0x9DD49C Offset: 0x9DD49C VA: 0x9DD49C
		//private IEnumerator ShowSns() { }

		//// RVA: 0x9DD548 Offset: 0x9DD548 VA: 0x9DD548
		//private void SetBackButtonSnsEmpty() { }

		// RVA: 0x9DD54C Offset: 0x9DD54C VA: 0x9DD54C Slot: 9
		protected override void OnStartEnterAnimation()
		{
			if (m_layoutTab != null)
				m_layoutTab.Show();
			if (m_tabType >= LayoutQuestTab.eTabType.Normal && m_tabType <= LayoutQuestTab.eTabType.Beginner)
				m_layoutScrollListV.Enter();
			else
			{
				if (m_tabType != LayoutQuestTab.eTabType.Bingo && m_tabType != LayoutQuestTab.eTabType.Event)
					return;
				m_layoutScrollListH.Enter();
			}
		}

		// RVA: 0x9DD550 Offset: 0x9DD550 VA: 0x9DD550 Slot: 12
		protected override void OnStartExitAnimation()
		{
			m_layoutTab.Hide();
			m_layoutScrollListV.Leave();
			m_layoutScrollListH.Leave();
		}

		// RVA: 0x9DD554 Offset: 0x9DD554 VA: 0x9DD554 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_layoutTab.IsPlaying() && !m_layoutScrollListV.IsPlaying() && !m_layoutScrollListH.IsPlaying();
		}

		// RVA: 0x9DD5E0 Offset: 0x9DD5E0 VA: 0x9DD5E0 Slot: 16
		protected override void OnPreSetCanvas()
		{
			m_currentTime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			m_layoutTab.InitializeBadge();
			for(int i = 0; i < m_eventMissionButtonList.Count; i++)
			{
				m_eventMissionButtonList[i].InitializeBadge();
			}
			QuestUtility.SetCallbackSns(() =>
			{
				//0x9DE230
				this.StartCoroutineWatched(ShowSns());
			});
			QuestUtility.UpdateQuestData(LayoutQuestTab.eTabType.Normal);
		}

		// RVA: 0x9DD880 Offset: 0x9DD880 VA: 0x9DD880 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning;
		}

		// RVA: 0x9DD920 Offset: 0x9DD920 VA: 0x9DD920 Slot: 23
		protected override void OnActivateScene()
		{
			if (BasicTutorialManager.IsBeginnerMission())
				this.StartCoroutineWatched(Co_ShowBeginnerTutorial());
			else
				this.StartCoroutineWatched(Co_Intrduce());
		}

		// RVA: 0x9DDA7C Offset: 0x9DDA7C VA: 0x9DDA7C Slot: 14
		protected override void OnDestoryScene()
		{
			m_layoutTab.ReleaseBadge();
			for(int i = 0; i < m_eventMissionButtonList.Count; i++)
			{
				m_eventMissionButtonList[i].ReleaseBadge();
			}
		}

		// RVA: 0x9DDB78 Offset: 0x9DDB78 VA: 0x9DDB78 Slot: 15
		protected override void OnDeleteCache()
		{
			if (m_snsScreen != null)
			{
				m_snsScreen.Dispose();
				m_snsScreen = null;
			}
			QuestUtility.SetCallbackSnsClear();
		}

		// RVA: 0x9DDCF4 Offset: 0x9DDCF4 VA: 0x9DDCF4 Slot: 20
		protected override bool OnBgmStart()
		{
			SoundManager.Instance.bgmPlayer.ContinuousPlay(MenuScene.Instance.GetDefaultBgmId(SceneGroupCategory.QUEST));
			return true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7109FC Offset: 0x7109FC VA: 0x7109FC
		//// RVA: 0x9DD9F0 Offset: 0x9DD9F0 VA: 0x9DD9F0
		private IEnumerator Co_Intrduce()
		{
			//0x9DEAF0
			yield return this.StartCoroutineWatched(Co_ShowHelp());
			MFDJIFIIPJD item = QuestUtility.m_selectedItemInfo;
			QuestUtility.m_selectedItemInfo = null;
			if(item != null)
			{
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				PopupQuestRewardSetting s = new PopupQuestRewardSetting();
				s.ItemInfo = item;
				s.TitleText = bk.GetMessageByLabel("popup_quest_reward_title");
				s.WindowSize = SizeType.Small;
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				bool popupWait = true;
				PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x9DE3B8
					return;
				}, null, null, null, closeWaitCallBack:() =>
				{
					//0x9DE8E4
					popupWait = false;
					return true;
				});
				while (popupWait)
					yield return null;
				UpdateList();
			}
			if (TutorialProc.CanBeginnerMissionLiveClearMissionList(PrevTransition))
			{
				yield return Co.R(TutorialProc.Co_BeginnerMissionLiveClearMissionList());
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x710A74 Offset: 0x710A74 VA: 0x710A74
		//// RVA: 0x9DD964 Offset: 0x9DD964 VA: 0x9DD964
		private IEnumerator Co_ShowBeginnerTutorial()
		{
			TodoLogger.LogError(0, "Co_ShowBeginnerTutorial");
			yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x710AEC Offset: 0x710AEC VA: 0x710AEC
		//// RVA: 0x9DDE2C Offset: 0x9DDE2C VA: 0x9DDE2C
		private IEnumerator Co_ShowHelp()
		{
			//0x9E0DAC
			MenuScene.Instance.InputDisable();
			yield return this.StartCoroutineWatched(TutorialManager.TryShowTutorialCoroutine(TutorialChecker));
			MenuScene.Instance.InputEnable();
		}

		//[CompilerGeneratedAttribute] // RVA: 0x710B64 Offset: 0x710B64 VA: 0x710B64
		//// RVA: 0x9DDFA4 Offset: 0x9DDFA4 VA: 0x9DDFA4
		//private void <SetupLayout>b__12_0(LayoutQuestTab.eTabType tabType) { }

		//[CompilerGeneratedAttribute] // RVA: 0x710BA4 Offset: 0x710BA4 VA: 0x710BA4
		//// RVA: 0x9DE11C Offset: 0x9DE11C VA: 0x9DE11C
		//private void <OnClickReceiveAll>b__30_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x710BB4 Offset: 0x710BB4 VA: 0x710BB4
		//// RVA: 0x9DE120 Offset: 0x9DE120 VA: 0x9DE120
		//private void <ShowSns>b__33_1() { }
	}
}
