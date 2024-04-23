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
	public class MusicRateScene : TransitionRoot
	{
		public class MusicRateArgs : TransitionArgs
		{
			public int tab { get; set; } // 0x8
		}

		private LayoutMusicRateList m_layout; // 0x48
		private CommonMenuStack2 m_layoutTitle; // 0x4C
		private GHLGEECLCMH m_viewData; // 0x50
		private bool m_initialized; // 0x54
		private int m_nowGradeIndex; // 0x58
		private List<int> m_rankRangeList; // 0x5C
		private List<string> m_rankRangeLabelList; // 0x60
		private int m_currentRankRange; // 0x64
		private int m_nextRankRange; // 0x68
		private int[] m_thresholds = new int[2]; // 0x6C
		private bool m_listUpdate; // 0x70
		private bool m_isErrorToTitle; // 0x71
		private List<FlexibleListItemLayout> m_layoutRankingList; // 0x74
		public LayoutMusicRateList.Content m_selectTab; // 0x78
		public RankRangePopupSetting m_rankRangePopupSetting = new RankRangePopupSetting(); // 0x7C
		private const int VisibleListItemCount = 2;
		private RankingSceneBase.WaitForFrame waitForFrame; // 0x80

		// RVA: 0x104E8C4 Offset: 0x104E8C4 VA: 0x104E8C4 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			this.StartCoroutineWatched(Co_LoadResources());
			waitForFrame = new RankingSceneBase.WaitForFrame(3);
		}

		// RVA: 0x104E9E8 Offset: 0x104E9E8 VA: 0x104E9E8 Slot: 16
		protected override void OnPreSetCanvas()
		{
			m_selectTab = LayoutMusicRateList.Content.MusicReward;
			if (PrevTransition != TransitionList.Type.HOME)
			{
				m_selectTab = LayoutMusicRateList.Content.MusicRate;
				if (PrevTransition == TransitionList.Type.PROFIL)
				{
					m_selectTab = LayoutMusicRateList.Content.MusicRanking;
				}
			}
			if(Args != null)
			{
				if(Args is MusicRateArgs)
				{
					m_selectTab = (LayoutMusicRateList.Content)(Args as MusicRateArgs).tab;
				}
			}
			m_initialized = false;
			this.StartCoroutineWatched(Co_Initialize());
		}

		// RVA: 0x104EB10 Offset: 0x104EB10 VA: 0x104EB10 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return m_initialized && !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning;
		}

		// RVA: 0x104EBC8 Offset: 0x104EBC8 VA: 0x104EBC8 Slot: 18
		protected override void OnPostSetCanvas()
		{
			base.OnPostSetCanvas();
		}

		// RVA: 0x104EBD0 Offset: 0x104EBD0 VA: 0x104EBD0 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			m_layout.Enter();
			m_layoutTitle.EnterLabel(CommonMenuStackLabel2.LabelType.MusicRate, 0, false);
			if(IsRootScene())
			{
				m_layoutTitle.EnterBackButton(false);
				m_layoutTitle.OnClickBackButton = () =>
				{
					//0x10515B4
					MenuScene.Instance.Mount(TransitionUniqueId.HOME, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
				};
			}
		}

		// RVA: 0x104EE50 Offset: 0x104EE50 VA: 0x104EE50 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_layout.IsPlaying();
		}

		// RVA: 0x104EE80 Offset: 0x104EE80 VA: 0x104EE80 Slot: 12
		protected override void OnStartExitAnimation()
		{
			m_layout.Leave();
			m_layoutTitle.LeaveLabel();
			if (IsRootScene())
				m_layoutTitle.LeaveBackButton();
		}

		// RVA: 0x104EF04 Offset: 0x104EF04 VA: 0x104EF04 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_layout.IsPlaying();
		}

		// RVA: 0x104EF34 Offset: 0x104EF34 VA: 0x104EF34 Slot: 14
		protected override void OnDestoryScene()
		{
			ReleaseDecos();
		}

		// RVA: 0x104F0B0 Offset: 0x104F0B0 VA: 0x104F0B0 Slot: 15
		protected override void OnDeleteCache()
		{
			if(m_layoutTitle != null)
			{
				Destroy(m_layoutTitle.gameObject);
				m_layoutTitle = null;
			}
		}

		// RVA: 0x104F1A8 Offset: 0x104F1A8 VA: 0x104F1A8
		private void Update()
		{
			if (!m_initialized)
				return;
			if (m_selectTab != LayoutMusicRateList.Content.MusicRanking)
				return;
			if (m_currentRankRange == 0 || !m_listUpdate)
				return;
			float f = m_layout.FxScrollView.CurrentVerticalScrollPositon() * m_layout.FxScrollView.GetVerticalScrollSizeRatio();
			bool b = false;
			List<RankingListInfo> currentInfoList = OEGIPPCADNA.HHCJCDFCLOB.HGGPIBNLALJ;
			if (f < 1.015f || OEGIPPCADNA.HHCJCDFCLOB.FLCLIHBOHCH)
			{
				if(f < -0.015)
				{
					b = false;
					if (OEGIPPCADNA.HHCJCDFCLOB.DPPIBCENJJJ == false)
						m_listUpdate = false;
					else if (m_listUpdate)
						return;
				}
				else if (m_listUpdate)
					return;
				b = false;
			}
			else
			{
				b = true;
				m_listUpdate = false;
			}
			MenuScene.Instance.RaycastDisable();
			m_layout.FxScrollView.SetEnableScrollBar(false);
			AddRankingList(b, () =>
			{
				//0x1051690
				MenuScene.Instance.RaycastEnable();
				if (m_isErrorToTitle)
					return;
				m_listUpdate = currentInfoList.Count > 0;
				m_layout.FxScrollView.SetEnableScrollBar(true);
			});
		}

		//// RVA: 0x104EAE0 Offset: 0x104EAE0 VA: 0x104EAE0
		//private void Initialize() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6ED80C Offset: 0x6ED80C VA: 0x6ED80C
		//// RVA: 0x104F824 Offset: 0x104F824 VA: 0x104F824
		private IEnumerator Co_Initialize()
		{
			//0x1051E04
			bool done = false;
			AGLHPOOPOCG.HHCJCDFCLOB.OAGGKCHJBEO(() =>
			{
				//0x1051804
				done = true;
			}, () =>
			{
				//0x1051810
				done = true;
			}, () =>
			{
				//0x105181C
				done = true;
				NetErrorToTitle();
			});
			while (!done)
				yield return null;
			List<int> ranking_threshold = OEGIPPCADNA.HHCJCDFCLOB.IFHPGJGLPPF_GetRankingThreshold();
			m_rankRangeList = new List<int>(ranking_threshold.Count + 1);
			m_rankRangeList.Add(0);
			m_rankRangeList.AddRange(ranking_threshold);
			m_rankRangeLabelList = new List<string>(m_rankRangeList.Count);
			for(int i = 0; i < m_rankRangeList.Count; i++)
			{
				if (m_rankRangeList[i] == 0)
					m_rankRangeLabelList.Add(MessageManager.Instance.GetMessage("menu", "popup_rank_range_myself"));
				else
					m_rankRangeLabelList.Add(string.Format(MessageManager.Instance.GetMessage("menu", "popup_rank_range_place"), m_rankRangeList[i]));
			}
			InitializeDecos();
			m_viewData = new GHLGEECLCMH();
			m_viewData.KHEKNNFCAOI(null, null);
			List<HighScoreRating.UtaGradeData> gradeList = m_viewData.IEPGAGBLHBN_GetMusicGradeList();
			for (int i = 0; i < m_viewData.IEPGAGBLHBN_GetMusicGradeList().Count; i++)
			{
				if(gradeList[i].isNow)
				{
					m_nowGradeIndex = i;
				}
			}
			if (PrevTransition != TransitionList.Type.PROFIL)
			{
				m_currentRankRange = 0;
			}
			m_listUpdate = true;
			m_layout.Hide();
			m_layout.OnClickRankingButton = OnClickRankingButton;
			m_layout.OnClickRankingUserButton = OnClickRankingUserButton;
			m_layout.OnClickTabsButton = OnClickTabsButton;
			m_layout.OnPreChangeTab = OnPreChangeTab;
			m_layout.OnUpdateScrollList = OnUpdateScrollList;
			m_layout.SetStatus(m_viewData, m_selectTab, PrevTransition != TransitionList.Type.PROFIL);
			m_initialized = true;
		}

		//// RVA: 0x104F8D0 Offset: 0x104F8D0 VA: 0x104F8D0
		private void InitializeDecos()
		{
			for (int i = 0; i < m_layoutRankingList.Count; i++)
			{
				(m_layoutRankingList[i] as LayoutPopupMusicRateRankingListItem).InitializeDecos();
			}
		}

		//// RVA: 0x104EF38 Offset: 0x104EF38 VA: 0x104EF38
		private void ReleaseDecos()
		{
			for (int i = 0; i < m_layoutRankingList.Count; i++)
			{
				(m_layoutRankingList[i] as LayoutPopupMusicRateRankingListItem).ReleaseDecos();
			}
		}

		//// RVA: 0x104ED8C Offset: 0x104ED8C VA: 0x104ED8C
		private bool IsRootScene()
		{
			return MenuScene.Instance.GetCurrentScene().uniqueId == (int)TransitionUniqueId.MUSICRATE;
		}

		//// RVA: 0x104FA48 Offset: 0x104FA48 VA: 0x104FA48
		private void GetRankingList(int baseRank, int rankingIdx, Action callback)
		{
			if(m_currentRankRange > 0)
			{
				m_thresholds[0] = Mathf.Clamp((baseRank / 10) * 10, 1, 1000);
				m_thresholds[1] = Mathf.Clamp((baseRank / 10) * 10 + 10, 1, 1000);
			}
			OEGIPPCADNA.HHCJCDFCLOB.FAMFKPBPIAA(false, baseRank, rankingIdx, () =>
			{
				//0x105184C
				OnReceivedRankingList(callback);
			}, () =>
			{
				//0x105187C
				if (callback != null)
					callback();
			}, () =>
			{
				//0x1051890
				NetErrorToTitle();
				if (callback != null)
					callback();
			});
		}

		//// RVA: 0x104FCC0 Offset: 0x104FCC0 VA: 0x104FCC0
		private void OnReceivedRankingList(Action callback)
		{
			if (OEGIPPCADNA.HHCJCDFCLOB.HGGPIBNLALJ.Count > 0)
			{
				for (int i = 0; i < OEGIPPCADNA.HHCJCDFCLOB.HGGPIBNLALJ.Count; i++)
				{
					OEGIPPCADNA.HHCJCDFCLOB.HGGPIBNLALJ[i].TryInstall();
				}
				this.StartCoroutineWatched(Co_WaitDownLoadAsset(callback));
			}
			else
			{
				if (callback != null)
					callback();
			}
		}

		//// RVA: 0x104F49C Offset: 0x104F49C VA: 0x104F49C
		private void AddRankingList(bool isUpper, Action callback)
		{
			int a = 1;
			if (isUpper)
				a = -1;
			int prev = m_thresholds[isUpper ? 0 : 1];
			if (!isUpper)
			{
				m_thresholds[1] = Mathf.Clamp(m_thresholds[1] + a * 10, 1, 1000);
			}
			else
			{
				m_thresholds[0] = Mathf.Clamp(m_thresholds[0] + a * 10, 1, 1000);
			}
			OEGIPPCADNA.HHCJCDFCLOB.JPNACOLKHLB(prev, a, m_rankRangeList[m_currentRankRange], () =>
			{
				//0x10518D0
				OnReceivedRankingListAdditive(isUpper, callback);
			}, () =>
			{
				//0x1051910
				if (callback != null)
					callback();
			}, () =>
			{
				//0x1051924
				NetErrorToTitle();
				if (callback != null)
					callback();
			});
		}

		//// RVA: 0x104FEE8 Offset: 0x104FEE8 VA: 0x104FEE8
		protected void OnReceivedRankingListAdditive(bool isUpper, Action callback)
		{
			List<RankingListInfo> addInfoList = OEGIPPCADNA.HHCJCDFCLOB.BMKBAMFBAPJ;
			if(addInfoList.Count < 1)
			{
				if (callback != null)
					callback();
			}
			else
			{
				m_layout.UpdateRankingList(OEGIPPCADNA.HHCJCDFCLOB.HGGPIBNLALJ, (FlexibleItemScrollView scroll, List<IFlexibleListItem> scrollList) =>
				{
					//0x1051964
					scroll.SetupListItem(scrollList);
					if(!isUpper)
					{
						scroll.SetlistBottom(scroll.DispEndIndex);
					}
					else
					{
						scroll.SetlistTop(addInfoList.Count + scroll.DispBeginIndex);
					}
					scroll.SetZeroVelocity();
					scroll.VisibleRangeUpdate();
				});
				this.StartCoroutineWatched(Co_WaitDownLoadAsset(callback));
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6ED884 Offset: 0x6ED884 VA: 0x6ED884
		//// RVA: 0x104FE38 Offset: 0x104FE38 VA: 0x104FE38
		private IEnumerator Co_WaitDownLoadAsset(Action callback)
		{
			//0x1053DC0
			waitForFrame.Reset(3);
			yield return waitForFrame;
			while (KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
			if (callback != null)
				callback();
		}

		//// RVA: 0x10500B0 Offset: 0x10500B0 VA: 0x10500B0
		private void OnPreChangeTab(LayoutMusicRateList.Content tab, Action callback)
		{
			if(tab == LayoutMusicRateList.Content.MusicRanking && m_listUpdate)
			{
				MenuScene.Instance.RaycastDisable();
				m_layout.FxScrollView.SetEnableScrollBar(false);
				GetRankingList(m_rankRangeList[m_currentRankRange], 0, () =>
				{
					//0x1051AC0
					if (callback != null)
						callback();
					MenuScene.Instance.RaycastEnable();
					if (m_isErrorToTitle)
						return;
					m_listUpdate = OEGIPPCADNA.HHCJCDFCLOB.HGGPIBNLALJ.Count > 0;
					m_layout.FxScrollView.SetEnableScrollBar(true);
					m_layout.SetRankRange(m_rankRangeLabelList[m_currentRankRange]);
				});
			}
			else
			{
				if (callback != null)
					callback();
			}
		}

		//// RVA: 0x10502B4 Offset: 0x10502B4 VA: 0x10502B4
		private void OnUpdateScrollList(LayoutMusicRateList.Content tab, FlexibleItemScrollView scrollView, List<IFlexibleListItem> scrollList)
		{
			switch(tab)
			{
				case LayoutMusicRateList.Content.MusicReward:
					{
						int a = m_nowGradeIndex - 1;
						if (a < 1)
							a = 0;
						int top = scrollList.Count;
						List<HighScoreRating.UtaGradeData> gradeList = m_viewData.IEPGAGBLHBN_GetMusicGradeList();
						for (int i = a; i < gradeList.Count; i++)
						{
							top -= gradeList[i].items.Count;
						}
						scrollView.SetupListItem(scrollList);
						scrollView.SetlistTop(top);
					}
					break;
				case LayoutMusicRateList.Content.MusicGrade:
					scrollView.SetupListItem(scrollList);
					scrollView.SetlistBottom(Mathf.Min(m_nowGradeIndex + 3, scrollList.Count - 1));
					break;
				case LayoutMusicRateList.Content.MusicRate:
					scrollView.SetupListItem(scrollList);
					scrollView.SetlistTop(0);
					break;
				case LayoutMusicRateList.Content.MusicRanking:
					{
						int top = 0;
						if(m_currentRankRange == 0)
						{
							List<RankingListInfo> list = OEGIPPCADNA.HHCJCDFCLOB.HGGPIBNLALJ;
							int idx = list.FindIndex((RankingListInfo x) =>
							{
								//0x105166C
								return x.isOwner;
							});
							top = Mathf.Clamp(idx, 0, scrollList.Count - 1);
						}
						scrollView.SetupListItem(scrollList);
						scrollView.SetlistTop(top);
					}
					break;
				default:
					break;
			}
			scrollView.SetZeroVelocity();
			scrollView.VisibleRangeUpdate();
		}

		//// RVA: 0x10507F8 Offset: 0x10507F8 VA: 0x10507F8
		private void OnClickTabsButton(LayoutMusicRateList.Content tab)
		{
			m_selectTab = tab;
		}

		//// RVA: 0x1050800 Offset: 0x1050800 VA: 0x1050800
		private void OnClickRankingUserButton(RankingListInfo view)
		{
			TodoLogger.LogNotImplemented("OnClickRankingUserButton");
		}

		//// RVA: 0x1050968 Offset: 0x1050968 VA: 0x1050968
		private void OnClickRankingButton()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_rankRangePopupSetting.TitleText = bk.GetMessageByLabel("popup_rank_range_title");
			m_rankRangePopupSetting.SetParent(transform);
			m_rankRangePopupSetting.WindowSize = SizeType.Small;
			m_rankRangePopupSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			m_rankRangePopupSetting.itemLabels = m_rankRangeLabelList;
			m_rankRangePopupSetting.initialLabelIndex = m_currentRankRange;
			m_rankRangePopupSetting.onDecideIndex = (int next) =>
			{
				//0x1050F58
				m_nextRankRange = next;
			};
			m_nextRankRange = m_currentRankRange;
			PopupWindowManager.Show(m_rankRangePopupSetting, null, null, null, null);
		}

		//// RVA: 0x1050CE0 Offset: 0x1050CE0 VA: 0x1050CE0
		private void NetErrorToTitle()
		{
			if(MenuScene.Instance.IsTransition())
				GotoTitle();
			else
			{
				MenuScene.Instance.GotoTitle();
			}
			m_isErrorToTitle = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6ED8FC Offset: 0x6ED8FC VA: 0x6ED8FC
		//// RVA: 0x104E95C Offset: 0x104E95C VA: 0x104E95C
		private IEnumerator Co_LoadResources()
		{
			//0x1053C98
			yield return Co.R(Co_LoadLayout());
			IsReady = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6ED974 Offset: 0x6ED974 VA: 0x6ED974
		//// RVA: 0x1050E14 Offset: 0x1050E14 VA: 0x1050E14
		private IEnumerator Co_LoadLayout()
		{
			int loadCount; // 0x28
			StringBuilder bundleName; // 0x2C
			Font systemFont; // 0x30
			AssetBundleLoadLayoutOperationBase operation; // 0x34

			//0x10528AC
			loadCount = 0;
			bundleName = new StringBuilder(64);
			systemFont = GameManager.Instance.GetSystemFont();
			bundleName.Set("ly/154.xab");
			yield return AssetBundleManager.LoadUnionAssetBundle(bundleName.ToString());
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_cmn_back_layout_root");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x10512B4
				instance.transform.SetParent(MenuScene.Instance.HeaderMenu.MenuStack.transform.parent, false);
				instance.transform.SetAsFirstSibling();
				m_layoutTitle = instance.GetComponent<CommonMenuStack2>();
			}));
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			operation = null;
			bundleName.Set("ly/111.xab");
			yield return AssetBundleManager.LoadUnionAssetBundle(bundleName.ToString());
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_pop_m_rate_seane_layout_root");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1051468
				instance.transform.SetParent(transform, false);
				m_layout = instance.GetComponent<LayoutMusicRateList>();
			}));
			loadCount++;
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_pop_m_rate_layout_root");
			yield return operation;
			GameObject baseInstance = null;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1051D0C
				baseInstance = instance;
			}));
			yield return null;
			m_layout.FxScrollView.AddLayoutCache(2, baseInstance.GetComponent<LayoutUGUIRuntime>(), 6);
			Destroy(baseInstance.gameObject);
			operation = null;
			loadCount++;
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_m_rate_grade_layout_root");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1051D1C
				baseInstance = instance;
			}));
			yield return null;
			m_layout.FxScrollView.AddLayoutCache(1, baseInstance.GetComponent<LayoutUGUIRuntime>(), 10);
			Destroy(baseInstance.gameObject);
			operation = null;
			loadCount++;
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_pop_m_rate_item_pt_layout_root");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1051D2C
				baseInstance = instance;
			}));
			yield return null;
			m_layout.FxScrollView.AddLayoutCache(0, baseInstance.GetComponent<LayoutUGUIRuntime>(), 6);
			Destroy(baseInstance.gameObject);
			operation = null;
			loadCount++;
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_pop_m_rate_rank_layout_root");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1051D3C
				baseInstance = instance;
			}));
			yield return null;
			m_layout.FxScrollView.AddLayoutCache(3, baseInstance.GetComponent<LayoutUGUIRuntime>(), 7);
			Destroy(baseInstance.gameObject);
			if (m_layoutRankingList == null)
			{
				List<FlexibleListItemLayout> lf;
				m_layout.FxScrollView.PartsChache.TryGetValue(3, out lf);
				m_layoutRankingList = new List<FlexibleListItemLayout>(lf);
			}
			operation = null;
			loadCount++;
			operation = AssetBundleManager.LoadLayoutAsync(m_rankRangePopupSetting.BundleName, m_rankRangePopupSetting.AssetName);
			yield return operation;
			PopupRankRangeContent popupContent = null;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1051D4C
				m_rankRangePopupSetting.SetContent(instance);
				popupContent = instance.GetComponent<PopupRankRangeContent>();
			}));
			yield return Co.R(popupContent.Co_LoadElements(m_rankRangePopupSetting.BundleName));
			m_rankRangePopupSetting.SetParent(transform);
			operation = null;
			for(int i = 0; i < loadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
			while (!m_layout.IsLoaded())
				yield return null;
		}
		
		//[CompilerGeneratedAttribute] // RVA: 0x6ED9FC Offset: 0x6ED9FC VA: 0x6ED9FC
		//// RVA: 0x1050F60 Offset: 0x1050F60 VA: 0x1050F60
		//private void <OnClickRankingButton>b__43_1(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6EDA0C Offset: 0x6EDA0C VA: 0x6EDA0C
		//// RVA: 0x10510E4 Offset: 0x10510E4 VA: 0x10510E4
		//private void <OnClickRankingButton>b__43_2() { }
	}
}
