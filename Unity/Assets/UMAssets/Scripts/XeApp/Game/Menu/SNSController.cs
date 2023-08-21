using mcrs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class SNSController : IDisposable
	{
		public enum eType
		{
			None = 0,
			Entrance = 1,
			Room = 2,
		}

		public enum eObjectOrderType
		{
			None = 0,
			First = 1,
			Last = 2,
		}
		
		private bool isOneSetup; // 0x48
		private bool isLayoutSetupEntrance; // 0x49
		private bool isLayoutSetupRoom; // 0x4A
		private FDDIIKBJNNA m_viewDataSNS; // 0x4C
		private Action m_backCallbackEntrance; // 0x50
		private Action m_backCallbackRoom; // 0x54
		private bool m_isReview; // 0x58
		private const int SNS_ENTRANCE_COUNT = 7;
		private const int SNS_TALK_R_COUNT = 7;
		private const int SNS_TALK_L_COUNT = 7;
		private const int SNS_HEADLINE = 2;
		private string[] m_bundleNames = new string[2] { "ly/050.xab", "ly/089.xab" }; // 0x5C
		private Dictionary<string, int> m_bundleCounter = new Dictionary<string, int>(8); // 0x60

		public eType LayoutType { get; set; } // 0x8
		public Transform Parent { get; set; } // 0xC
		public SNSTitleBar layoutTitleBar { get; private set; } // 0x10
		public LayoutSNSScrollList layoutScrollList { get; private set; } // 0x14
		public LayoutSNSFooter layoutFooter { get; private set; } // 0x18
		public LayoutSNSBoot layoutBoot { get; private set; } // 0x1C
		public List<LayoutSNSTalkLeft> layoutWindowL { get; private set; } // 0x20
		public List<LayoutSNSTalkRight> layoutWindowR { get; private set; } // 0x24
		public List<LayoutSNSHeadline> layoutHeadline { get; private set; } // 0x28
		public List<LayoutSNSRoomItem> layoutSnsEntrance { get; private set; } // 0x2C
		public LayoutSNSBg layoutBg { get; private set; } // 0x30
		public LayoutSNSNextButton layoutNextButton { get; private set; } // 0x34
		public LayoutSNSUnopened layoutUnopened { get; private set; } // 0x38
		public ButtonBase tapScreenButton { get; private set; } // 0x3C
		public RectTransform tapScreenRect { get; private set; } // 0x40
		public ButtonBase tapGuardPanel { get; private set; } // 0x44
		public bool IsTutorial { get { return GameManager.Instance.IsTutorial || m_isReview; } } //0xB65F78
		public bool IsLoadBundle { get; private set; } // 0x64

		// RVA: 0xB66034 Offset: 0xB66034 VA: 0xB66034
		public SNSController()
		{
			layoutWindowL = new List<LayoutSNSTalkLeft>(10);
			layoutWindowR = new List<LayoutSNSTalkRight>(10);
			layoutHeadline = new List<LayoutSNSHeadline>(4);
			layoutSnsEntrance = new List<LayoutSNSRoomItem>(8);
		}

		//// RVA: 0xB662AC Offset: 0xB662AC VA: 0xB662AC
		public void Initialize(FDDIIKBJNNA snsData, bool isReview = false)
		{
			m_isReview = isReview;
			m_viewDataSNS = snsData;
			if (m_viewDataSNS == null)
			{
				m_viewDataSNS = new FDDIIKBJNNA();
				m_viewDataSNS.KHEKNNFCAOI(false, IsTutorial, -1);
			}
		}

		//// RVA: 0xB66374 Offset: 0xB66374 VA: 0xB66374
		public void LayoutSetup(eType type, eObjectOrderType orderType)
		{
			LayoutType = type;
			if(type == eType.Room)
			{
				if(!isLayoutSetupRoom)
				{
					if(layoutScrollList != null)
					{
						layoutScrollList.AddViewRoom(layoutHeadline, layoutWindowL, layoutWindowR, layoutNextButton, layoutUnopened);
					}
					isLayoutSetupRoom = true;
				}
			}
			else if(type == eType.Entrance && !isLayoutSetupEntrance)
			{
				if(layoutScrollList != null)
				{
					layoutScrollList.AddViewEntrance(layoutSnsEntrance);
				}
				isLayoutSetupEntrance = true;
			}
			if(orderType == eObjectOrderType.Last)
			{
				if (layoutBoot != null)
					layoutBoot.transform.SetAsLastSibling();
				if (layoutBg != null)
					layoutBg.transform.SetAsLastSibling();
				if (layoutScrollList != null)
					layoutScrollList.transform.SetAsLastSibling();
				if (layoutUnopened != null)
					layoutUnopened.transform.SetAsLastSibling();
				if (layoutTitleBar != null)
					layoutTitleBar.transform.SetAsLastSibling();
				if (layoutFooter != null)
					layoutFooter.transform.SetAsLastSibling();
				if (tapScreenButton != null)
					tapScreenButton.transform.SetAsLastSibling();
				if (tapGuardPanel != null)
					tapGuardPanel.transform.SetAsLastSibling();
			}
			else if(orderType == eObjectOrderType.First)
			{
				if (tapScreenButton != null)
					tapScreenButton.transform.SetAsFirstSibling();
				if (layoutFooter != null)
					layoutFooter.transform.SetAsFirstSibling();
				if (layoutTitleBar != null)
					layoutTitleBar.transform.SetAsFirstSibling();
				if (layoutUnopened != null)
					layoutUnopened.transform.SetAsFirstSibling();
				if (layoutScrollList != null)
					layoutScrollList.transform.SetAsFirstSibling();
				if (layoutBg != null)
					layoutBg.transform.SetAsFirstSibling();
				if (layoutBoot != null)
					layoutBoot.transform.SetAsFirstSibling();
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72970C Offset: 0x72970C VA: 0x72970C
		//// RVA: 0xB66D2C Offset: 0xB66D2C VA: 0xB66D2C
		public IEnumerator SetupEntrance(Action exitCallback, Action<int> roomInCallback, bool isBackButtonEmpty, SNSTitleBar.eButtonType buttonType)
		{
			//0x1595F5C
			if(LayoutType == eType.Entrance)
			{
				int divaId = GameManager.Instance.GetHomeDiva().AHHJLDLAPAN_DivaId;
				if (IsTutorial)
					divaId = 1;
				if(layoutBg != null)
				{
					layoutBg.SetStatus(divaId);
				}
				if(layoutScrollList != null)
				{
					yield return Co.R(layoutScrollList.SetStatusEntrance(m_viewDataSNS, roomInCallback));
				}
				if(layoutTitleBar != null)
				{
					layoutTitleBar.CallbackClose = exitCallback;
					layoutTitleBar.SetStatusEntrance(buttonType);
				}
				if(m_backCallbackEntrance == null)
				{
					if(!isBackButtonEmpty)
					{
						m_backCallbackEntrance = exitCallback;
					}
					else
					{
						m_backCallbackEntrance = () =>
						{
							//0x158FE0C
							return;
						};
					}
				}
				GameManager.Instance.AddPushBackButtonHandler(BackButtonEntrance);
			}
		}

		//// RVA: 0xB66E14 Offset: 0xB66E14 VA: 0xB66E14
		//public void SetupRoom(int roomId, Action exitCallback, Action returnCallback, Action newTalkCallback, Action prevPageCallback, Action nextPageCallback, SNSTitleBar.eButtonType buttonType = 0, bool isBackButtonEmpty = False) { }

		//// RVA: 0xB67384 Offset: 0xB67384 VA: 0xB67384
		public void LoadEntranceImage()
		{
			if(m_viewDataSNS != null && m_viewDataSNS.NPKPBDIDBBG != null)
			{
				for(int i = 0; i < m_viewDataSNS.NPKPBDIDBBG.Count; i++)
				{
					GameManager.Instance.SnsIconCache.RoomIconLoad(m_viewDataSNS.NPKPBDIDBBG[i].MALFHCHNEFN, (IiconTexture textture) =>
					{
						//0x158FE14
						return;
					});
				}
			}
		}

		//// RVA: 0xB6763C Offset: 0xB6763C VA: 0xB6763C
		public void LoadCharaImage(int roomId)
		{
			if(m_viewDataSNS != null && m_viewDataSNS.KHCACDIKJLG != null)
			{
				List<int> l = new List<int>(35);
				GAKAAIHLFKI g = m_viewDataSNS.NPKPBDIDBBG.Find((GAKAAIHLFKI _) =>
				{
					//0x1590394
					return _.MALFHCHNEFN == roomId;
				});
				if(g != null)
				{
					for(int i = 0; i < g.CNEOPOINCBA.Count; i++)
					{
						if(!l.Contains(g.CNEOPOINCBA[i].IDELKEKDIFD_CharaId))
						{
							l.Add(g.CNEOPOINCBA[i].IDELKEKDIFD_CharaId);
						}
					}
					for(int i = 0; i < l.Count; i++)
					{
						GameManager.Instance.SnsIconCache.CharIconLoad(l[i], (IiconTexture textture) =>
						{
							//0x158FE18
							return;
						});
					}
				}
			}
		}

		//// RVA: 0xB67AA0 Offset: 0xB67AA0 VA: 0xB67AA0
		public bool IsLoadingSnsIconCache()
		{
			return GameManager.Instance.SnsIconCache.IsLoading();
		}

		//// RVA: 0xB67B5C Offset: 0xB67B5C VA: 0xB67B5C
		public void In()
		{
			TodoLogger.LogError(0, "In");
		}

		//// RVA: 0xB67D48 Offset: 0xB67D48 VA: 0xB67D48
		public void Out()
		{
			TodoLogger.LogError(0, "Out");
		}

		//// RVA: 0xB6800C Offset: 0xB6800C VA: 0xB6800C
		//public void Hide() { }

		//// RVA: 0xB68200 Offset: 0xB68200 VA: 0xB68200
		public void EntranceOut()
		{
			TodoLogger.LogError(0, "EntranceOut");
		}

		//// RVA: 0xB683EC Offset: 0xB683EC VA: 0xB683EC
		public void RoomOut()
		{
			TodoLogger.LogError(0, "RoomOut");
		}

		//// RVA: 0xB68648 Offset: 0xB68648 VA: 0xB68648
		public bool IsPlaying()
		{
			return layoutTitleBar.IsPlaying() ||
					layoutFooter.IsPlaying() ||
					layoutScrollList.IsPlaying() ||
					layoutBg.IsPlaying() ||
					layoutBoot.IsPlaying();
		}

		// RVA: 0xB68718 Offset: 0xB68718 VA: 0xB68718
		public void Reset()
		{
			return;
		}

		// RVA: 0xB6871C Offset: 0xB6871C VA: 0xB6871C Slot: 4
		public void Dispose()
		{
			RemoveBackButtonEntrance();
			RemoveBackButtonRoom();
			isOneSetup = false;
			if (layoutTitleBar != null)
				UnityEngine.Object.Destroy(layoutTitleBar.gameObject);
			layoutTitleBar = null;
			if (layoutFooter != null)
				UnityEngine.Object.Destroy(layoutFooter.gameObject);
			if (layoutNextButton != null)
				UnityEngine.Object.Destroy(layoutNextButton.gameObject);
			layoutNextButton = null;
			if (layoutUnopened != null)
				UnityEngine.Object.Destroy(layoutUnopened.gameObject);
			layoutUnopened = null;
			for (int i = 0; i < layoutSnsEntrance.Count; i++)
			{
				if (layoutSnsEntrance[i] != null)
					UnityEngine.Object.Destroy(layoutSnsEntrance[i].gameObject);
			}
			layoutSnsEntrance.Clear();
			for (int i = 0; i < layoutHeadline.Count; i++)
			{
				if (layoutHeadline[i] != null)
					UnityEngine.Object.Destroy(layoutHeadline[i].gameObject);
			}
			layoutHeadline.Clear();
			for (int i = 0; i < layoutWindowL.Count; i++)
			{
				if (layoutWindowL[i] != null)
					UnityEngine.Object.Destroy(layoutWindowL[i].gameObject);
			}
			layoutWindowL.Clear();
			for (int i = 0; i < layoutWindowR.Count; i++)
			{
				if (layoutWindowR[i] != null)
					UnityEngine.Object.Destroy(layoutWindowR[i].gameObject);
			}
			layoutWindowR.Clear();
			if (layoutScrollList != null)
				UnityEngine.Object.Destroy(layoutScrollList.gameObject);
			layoutScrollList = null;
			if (layoutBg != null)
				UnityEngine.Object.Destroy(layoutBg.gameObject);
			layoutBg = null;
			if (layoutBoot != null)
				UnityEngine.Object.Destroy(layoutBoot.gameObject);
			layoutBoot = null;
			if (tapScreenButton != null)
				UnityEngine.Object.Destroy(tapScreenButton.gameObject);
			tapScreenButton = null;
			if (tapScreenRect != null)
				UnityEngine.Object.Destroy(tapScreenRect.gameObject);
			tapScreenRect = null;
			if (tapGuardPanel != null)
				UnityEngine.Object.Destroy(tapGuardPanel.gameObject);
			tapGuardPanel = null;
			UnloadAssetBundle();
		}

		//// RVA: 0xB69838 Offset: 0xB69838 VA: 0xB69838
		private void BackButtonEntrance()
		{
			if (IsTutorial)
				return;
			if (m_backCallbackEntrance != null)
				m_backCallbackEntrance();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
		}

		//// RVA: 0xB698B4 Offset: 0xB698B4 VA: 0xB698B4
		private void BackButtonRoom()
		{
			if (IsTutorial)
				return;
			if (m_backCallbackRoom != null)
				m_backCallbackRoom();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_000);
		}

		//// RVA: 0xB693FC Offset: 0xB693FC VA: 0xB693FC
		public void RemoveBackButtonEntrance()
		{
			if (m_backCallbackEntrance != null)
			{
				m_backCallbackEntrance = null;
				GameManager.Instance.RemovePushBackButtonHandler(BackButtonEntrance);
			}
		}

		//// RVA: 0xB694EC Offset: 0xB694EC VA: 0xB694EC
		public void RemoveBackButtonRoom()
		{
			if(m_backCallbackRoom != null)
			{
				m_backCallbackRoom = null;
				GameManager.Instance.RemovePushBackButtonHandler(BackButtonRoom);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x729784 Offset: 0x729784 VA: 0x729784
		//// RVA: 0xB69930 Offset: 0xB69930 VA: 0xB69930
		public IEnumerator LoadLayout(eType type, Transform parent, Action callback, bool isBootIn, SNSController.eObjectOrderType objectOrderType)
		{
			//0x15904A0
			if(!isOneSetup)
			{
				isOneSetup = true;
				LoadAssetBundle();
				while (!IsLoadBundle)
					yield return null;
			}
			if (parent != null)
				Parent = parent;
			if (type != eType.None)
				LayoutType = type;
			bool isLoading = true;
			GameManager.Instance.StartCoroutineWatched(LoadLayoutBoot(() =>
			{
				//0x15903D4
				isLoading = false;
			}));
			while (isLoading)
				yield return null;
			if(isBootIn)
			{
				if(layoutBoot != null)
				{
					if(objectOrderType == eObjectOrderType.Last)
					{
						layoutBoot.transform.SetAsLastSibling();
					}
					else if(objectOrderType == eObjectOrderType.First)
					{
						layoutBoot.transform.SetAsFirstSibling();
					}
					layoutBoot.In();
				}
			}
			bool isLoadingEntranceItem = false;
			bool isLoadingRoomItemL = false;
			bool isLoadingRoomItemR = false;
			bool isLoadingRoomItemLine = false;
			bool isLoadingNextButton = false;
			bool isLoadingUnopened = false;
			bool isLoadingRoomTapScreenButton = false;
			bool isLoadingRoomTapScreenRect = false;
			bool isLoadingRoomTapGuard = false;
			if(LayoutType == eType.Entrance)
			{
				isLoadingEntranceItem = true;
				GameManager.Instance.StartCoroutineWatched(LoadLayoutSnsEntrance(() =>
				{
					//0x15903E0
					isLoadingEntranceItem = false;
				}));
			}
			else if(LayoutType == eType.Room)
			{
				isLoadingRoomItemR = true;
				GameManager.Instance.StartCoroutineWatched(LoadLayoutWindowR(() =>
				{
					//0x15903EC
					isLoadingRoomItemR = false;
				}));
				isLoadingRoomItemL = true;
				GameManager.Instance.StartCoroutineWatched(LoadLayoutWindowL(() =>
				{
					//0x15903F8
					isLoadingRoomItemL = false;
				}));
				isLoadingRoomItemLine = true;
				GameManager.Instance.StartCoroutineWatched(LoadLayoutHeadline(() =>
				{
					//0x1590404
					isLoadingRoomItemLine = false;
				}));
				isLoadingNextButton = true;
				GameManager.Instance.StartCoroutineWatched(LoadLayoutNextButton(() =>
				{
					//0x1590410
					isLoadingNextButton = false;
				}));
				isLoadingUnopened = true;
				GameManager.Instance.StartCoroutineWatched(LoadLayoutUnopened(() =>
				{
					//0x159041C
					isLoadingUnopened = false;
				}));
				isLoadingRoomTapScreenButton = true;
				GameManager.Instance.StartCoroutineWatched(LoadLayoutTapScreenButton(() =>
				{
					//0x1590428
					isLoadingRoomTapScreenButton = false;
				}));
				isLoadingRoomTapScreenRect = true;
				GameManager.Instance.StartCoroutineWatched(LoadLayoutTapScreenRect(() =>
				{
					//0x1590434
					isLoadingRoomTapScreenRect = false;
				}));
			}
			isLoadingRoomTapGuard = true;
			GameManager.Instance.StartCoroutineWatched(LoadLayoutTapGuardPanel(() =>
			{
				//0x1590440
				isLoadingRoomTapGuard = false;
			}));
			isLoading = true;
			GameManager.Instance.StartCoroutineWatched(LoadLayoutBg(() =>
			{
				//0x159044C
				isLoading = false;
			}));
			while (isLoading)
				yield return null;
			isLoading = true;
			GameManager.Instance.StartCoroutineWatched(LoadLayoutScrollList(() =>
			{
				//0x1590458
				isLoading = false;
			}));
			while (isLoading)
				yield return null;
			isLoading = true;
			GameManager.Instance.StartCoroutineWatched(LoadLayoutTitleBar(() =>
			{
				//0x1590464
				isLoading = false;
			}));
			while (isLoading)
				yield return null;
			isLoading = true;
			GameManager.Instance.StartCoroutineWatched(LoadLayoutFooter(() =>
			{
				//0x1590470
				isLoading = false;
			}));
			while (isLoading)
				yield return null;
			while (isLoadingNextButton)
				yield return null;
			while (isLoadingUnopened)
				yield return null;
			while (isLoadingRoomTapScreenRect)
				yield return null;
			while (isLoadingRoomTapScreenButton)
				yield return null;
			while (isLoadingEntranceItem)
				yield return null;
			while(isLoadingRoomItemLine)
				yield return null;
			while (isLoadingRoomItemL)
				yield return null;
			while (isLoadingRoomItemR)
				yield return null;
			while (isLoadingRoomTapGuard)
				yield return null;
			if(isBootIn)
			{
				while (layoutBoot.IsPlaying())
					yield return null;
			}
			if (callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7297FC Offset: 0x7297FC VA: 0x7297FC
		//// RVA: 0xB69A38 Offset: 0xB69A38 VA: 0xB69A38
		public IEnumerator LoadLayoutTitleBar(Action callback)
		{
			//0x1594ABC
			if(layoutTitleBar == null)
			{
				yield return Co.R(LoadLayoutInner("ly/050.xab", "root_sns_title_layout_root", (GameObject instance) =>
				{
					//0xB6A844
					layoutTitleBar = instance.GetComponent<SNSTitleBar>();
				}));
				while (layoutTitleBar == null)
					yield return null;
				while (!layoutTitleBar.IsLoaded())
					yield return null;
				layoutTitleBar.transform.SetParent(Parent, false);
				layoutTitleBar.gameObject.SetActive(false);
			}
			if (callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x729874 Offset: 0x729874 VA: 0x729874
		//// RVA: 0xB69ADC Offset: 0xB69ADC VA: 0xB69ADC
		public IEnumerator LoadLayoutFooter(Action callback)
		{
			//0x1592038
			if(layoutFooter == null)
			{
				yield return Co.R(LoadLayoutInner("ly/050.xab", "root_sns_btm_grad_layout_root", (GameObject instance) =>
				{
					//0xB6A8C0
					layoutFooter = instance.GetComponent<LayoutSNSFooter>();
				}));
				while (layoutFooter == null)
					yield return null;
				while (!layoutFooter.IsLoaded())
					yield return null;
				layoutFooter.transform.SetParent(Parent, false);
				layoutFooter.gameObject.SetActive(false);
			}
			if (callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7298EC Offset: 0x7298EC VA: 0x7298EC
		//// RVA: 0xB69B80 Offset: 0xB69B80 VA: 0xB69B80
		public IEnumerator LoadLayoutBg(Action callback)
		{
			//0x15917F8
			if(layoutBg == null)
			{
				yield return Co.R(LoadLayoutInner("ly/050.xab", "root_sns_bg_dot_layout_root", (GameObject instance) =>
				{
					//0xB6A93C
					layoutBg = instance.GetComponent<LayoutSNSBg>();
				}));
				while (layoutBg == null)
					yield return null;
				while (!layoutBg.IsLoaded())
					yield return null;
				layoutBg.transform.SetParent(Parent, false);
				layoutBg.gameObject.SetActive(false);
			}
			if (callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x729964 Offset: 0x729964 VA: 0x729964
		//// RVA: 0xB69C24 Offset: 0xB69C24 VA: 0xB69C24
		public IEnumerator LoadLayoutScrollList(Action callback)
		{
			//0x1593184
			if(layoutScrollList == null)
			{
				yield return Co.R(LoadLayoutInner("ly/050.xab", "root_sns_window_scroll_layout_root", (GameObject instance) =>
				{
					//0xB6A9B8
					layoutScrollList = instance.GetComponent<LayoutSNSScrollList>();
				}));
				while (layoutScrollList == null)
					yield return null;
				while (!layoutScrollList.IsLoaded())
					yield return null;
				layoutScrollList.transform.SetParent(Parent, false);
				layoutScrollList.gameObject.SetActive(false);
			}
			if (callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7299DC Offset: 0x7299DC VA: 0x7299DC
		//// RVA: 0xB69CC8 Offset: 0xB69CC8 VA: 0xB69CC8
		public IEnumerator LoadLayoutWindowR(Action callback)
		{
			bool isLoaded;

			//0x1595920
			if(layoutWindowR.Count < 1)
			{
				LayoutUGUIRuntime runtime = null;
				yield return Co.R(LoadLayoutInner("ly/050.xab", "root_sns_window_r_layout_root", (GameObject instance) =>
				{
					//0x158FE24
					instance.transform.SetParent(Parent, false);
					runtime = instance.GetComponent<LayoutUGUIRuntime>();
				}));
				for(int i = 0; i <= 6; i++)
				{
					LayoutUGUIRuntime r = UnityEngine.Object.Instantiate(runtime);
					r.IsLayoutAutoLoad = false;
					r.UvMan = runtime.UvMan;
					r.Layout = runtime.Layout.DeepClone();
					r.LoadLayout();
					layoutWindowR.Add(r.GetComponent<LayoutSNSTalkRight>());
				}
				UnityEngine.Object.Destroy(runtime.gameObject);
				isLoaded = false;
				for(int i = 0; i < layoutWindowR.Count; i++)
				{
					while (!layoutWindowR[i].IsLoaded())
						yield return null;
				}
			}
			if (callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x729A54 Offset: 0x729A54 VA: 0x729A54
		//// RVA: 0xB69D6C Offset: 0xB69D6C VA: 0xB69D6C
		public IEnumerator LoadLayoutWindowL(Action callback)
		{
			bool isLoaded;

			//0x15952FC
			if(layoutWindowL.Count < 1)
			{
				LayoutUGUIRuntime runtime = null;
				yield return Co.R(LoadLayoutInner("ly/050.xab", "root_sns_window_l_layout_root", (GameObject instance) =>
				{
					//0x158FF10
					runtime = instance.GetComponent<LayoutUGUIRuntime>();
				}));
				for(int i = 0; i <= 6; i++)
				{
					LayoutUGUIRuntime r = UnityEngine.Object.Instantiate(runtime);
					r.IsLayoutAutoLoad = false;
					r.UvMan = runtime.UvMan;
					r.Layout = runtime.Layout.DeepClone();
					r.LoadLayout();
					layoutWindowL.Add(r.GetComponent<LayoutSNSTalkLeft>());
				}
				UnityEngine.Object.Destroy(runtime.gameObject);
				isLoaded = false;
				for (int i = 0; i < layoutWindowL.Count; i++)
				{
					while (!layoutWindowL[i].IsLoaded())
						yield return null;
				}
			}
			if (callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x729ACC Offset: 0x729ACC VA: 0x729ACC
		//// RVA: 0xB69E10 Offset: 0xB69E10 VA: 0xB69E10
		public IEnumerator LoadLayoutHeadline(Action callback)
		{
			bool isLoaded;

			//0x1592458
			if(layoutHeadline.Count < 1)
			{
				LayoutUGUIRuntime runtime = null;
				yield return Co.R(LoadLayoutInner("ly/050.xab", "root_sns_unread_layout_root", (GameObject instance) =>
				{
					//0x158FF94
					runtime = instance.GetComponent<LayoutUGUIRuntime>();
				}));
				for(int i = 0; i <= 6; i++)
				{
					LayoutUGUIRuntime r = UnityEngine.Object.Instantiate(runtime);
					r.IsLayoutAutoLoad = false;
					r.UvMan = runtime.UvMan;
					r.Layout = runtime.Layout.DeepClone();
					r.LoadLayout();
					layoutHeadline.Add(r.GetComponent<LayoutSNSHeadline>());
				}
				UnityEngine.Object.Destroy(runtime.gameObject);
				isLoaded = false;
				for (int i = 0; i < layoutHeadline.Count; i++)
				{
					while (!layoutHeadline[i].IsLoaded())
						yield return null;
				}
			}
			if (callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x729B44 Offset: 0x729B44 VA: 0x729B44
		//// RVA: 0xB69EB4 Offset: 0xB69EB4 VA: 0xB69EB4
		public IEnumerator LoadLayoutNextButton(Action callback)
		{
			//0x1592D64
			if(layoutNextButton == null)
			{
				yield return Co.R(LoadLayoutInner("ly/050.xab", "root_sel_sns_next_btn_layout_root", (GameObject instance) =>
				{
					//0xB6AA34
					layoutNextButton = instance.GetComponent<LayoutSNSNextButton>();
				}));
				while (layoutNextButton == null)
					yield return null;
				while (!layoutNextButton.IsLoaded())
					yield return null;
				layoutNextButton.transform.SetParent(Parent, false);
				layoutNextButton.gameObject.SetActive(false);
			}
			if (callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x729BBC Offset: 0x729BBC VA: 0x729BBC
		//// RVA: 0xB69F58 Offset: 0xB69F58 VA: 0xB69F58
		public IEnumerator LoadLayoutUnopened(Action callback)
		{
			//0x1594EDC
			if(layoutUnopened == null)
			{
				yield return Co.R(LoadLayoutInner("ly/050.xab", "root_sw_sns_non_msg_layout_root", (GameObject instance) =>
				{
					//0xB6AAB0
					layoutUnopened = instance.GetComponent<LayoutSNSUnopened>();
				}));
				while (layoutUnopened == null)
					yield return null;
				while (!layoutUnopened.IsLoaded())
					yield return null;
				layoutUnopened.transform.SetParent(Parent, false);
				layoutUnopened.gameObject.SetActive(false);
			}
			if (callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x729C34 Offset: 0x729C34 VA: 0x729C34
		//// RVA: 0xB69FFC Offset: 0xB69FFC VA: 0xB69FFC
		public IEnumerator LoadLayoutSnsEntrance(Action callback)
		{
			//0x15935A4
			if(layoutSnsEntrance.Count < 1)
			{
				LayoutUGUIRuntime runtime = null;
				yield return Co.R(LoadLayoutInner("ly/050.xab", "root_sns_popup_btn_layout_root", (GameObject instance) =>
				{
					//0x1590018
					runtime = instance.GetComponent<LayoutUGUIRuntime>();
				}));
				for(int i = 0; i <= 6; i++)
				{
					LayoutUGUIRuntime r = UnityEngine.Object.Instantiate(runtime);
					r.IsLayoutAutoLoad = false;
					r.UvMan = runtime.UvMan;
					r.Layout = runtime.Layout.DeepClone();
					r.LoadLayout();
					LayoutSNSRoomItem s = r.GetComponent<LayoutSNSRoomItem>();
					s.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
					layoutSnsEntrance.Add(s);
				}
				UnityEngine.Object.Destroy(runtime.gameObject);
				for(int i = 0; i < layoutSnsEntrance.Count; i++)
				{
					while (!layoutSnsEntrance[i].IsLoaded())
					{
						yield return null;
					}
				}
				for (int i = 0; i < layoutSnsEntrance.Count; i++)
				{
					layoutSnsEntrance[i].gameObject.SetActive(false);
				}
			}
			if (callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x729CAC Offset: 0x729CAC VA: 0x729CAC
		//// RVA: 0xB6A0A0 Offset: 0xB6A0A0 VA: 0xB6A0A0
		public IEnumerator LoadLayoutBoot(Action callback)
		{
			//0x1591C18
			if(layoutBoot == null)
			{
				yield return Co.R(LoadLayoutInner("ly/089.xab", "root_start_sns_layout_root", (GameObject instance) =>
				{
					//0xB6AB2C
					layoutBoot = instance.GetComponent<LayoutSNSBoot>();
				}));
				while (layoutBoot == null)
					yield return null;
				while (!layoutBoot.IsLoaded())
					yield return null;
				layoutBoot.transform.SetParent(Parent);
				layoutBoot.gameObject.SetActive(false);
			}
			if (callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x729D24 Offset: 0x729D24 VA: 0x729D24
		//// RVA: 0xB6A144 Offset: 0xB6A144 VA: 0xB6A144
		public IEnumerator LoadLayoutTapScreenButton(Action callback)
		{
			GameObject obj;

			//0x1594288
			if(tapScreenButton == null)
			{
				obj = new GameObject("tapScreenButton");
				obj.AddComponent<LayoutUGUIHitOnly>();
				tapScreenButton = obj.AddComponent<ButtonBase>();
				obj.transform.SetParent(Parent, false);
				yield return null;
				RectTransform rt = obj.GetComponent<RectTransform>();
				rt.anchorMin = new Vector2(0, 1);
				rt.anchorMax = new Vector2(0, 1);
				rt.pivot = new Vector2(0, 1);
				rt.sizeDelta = new Vector2(1184, 792);
				rt.anchoredPosition = Vector2.zero;
				yield return null;
				tapScreenButton.gameObject.SetActive(false);
			}
			if (callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x729D9C Offset: 0x729D9C VA: 0x729D9C
		//// RVA: 0xB6A1E8 Offset: 0xB6A1E8 VA: 0xB6A1E8
		public IEnumerator LoadLayoutTapScreenRect(Action callback)
		{
			//0x159479C
			if(tapScreenRect == null)
			{
				yield return Co.R(LoadLayoutInner("ly/050.xab", "tapScreenRect", (GameObject instance) =>
				{
					//0xB6ABA8
					tapScreenRect = instance.GetComponent<RectTransform>();
					if (tapScreenRect != null)
						tapScreenRect.SetParent(Parent, false);
				}));
				if(tapScreenRect != null)
				{
					tapScreenRect.gameObject.SetActive(false);
				}
			}
			if (callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x729E14 Offset: 0x729E14 VA: 0x729E14
		//// RVA: 0xB6A28C Offset: 0xB6A28C VA: 0xB6A28C
		public IEnumerator LoadLayoutTapGuardPanel(Action callback)
		{
			GameObject obj;

			//0x1593D38
			if(tapGuardPanel == null)
			{
				obj = new GameObject("tapGuardPanel");
				obj.AddComponent<LayoutUGUIHitOnly>();
				tapGuardPanel = obj.AddComponent<ButtonBase>();
				tapGuardPanel.transform.SetParent(Parent, false);
				yield return null;
				RectTransform rt = obj.GetComponent<RectTransform>();
				rt.anchorMin = new Vector2(0, 1);
				rt.anchorMax = new Vector2(0, 1);
				rt.pivot = new Vector2(0, 1);
				rt.sizeDelta = new Vector2(1184, 792);
				rt.anchoredPosition = Vector2.zero;
				if(tapGuardPanel != null)
				{
					tapGuardPanel.gameObject.SetActive(false);
				}
			}
			if (callback != null)
				callback();
		}

		//// RVA: 0xB6A330 Offset: 0xB6A330 VA: 0xB6A330
		public void SNSInputDisable()
		{
			if (tapGuardPanel != null)
				tapGuardPanel.gameObject.SetActive(true);
		}

		//// RVA: 0xB6A408 Offset: 0xB6A408 VA: 0xB6A408
		public void SNSInputEnable()
		{
			if (tapGuardPanel != null)
				tapGuardPanel.gameObject.SetActive(false);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x729E8C Offset: 0x729E8C VA: 0x729E8C
		//// RVA: 0xB6A4E0 Offset: 0xB6A4E0 VA: 0xB6A4E0
		private IEnumerator LoadLayoutInner(string bundleName, string assetName, Action<GameObject> callback)
		{
			Font font; // 0x24
			AssetBundleLoadLayoutOperationBase operation; // 0x28

			//0x1592A7C
			font = GameManager.Instance.GetSystemFont();
			operation = AssetBundleManager.LoadLayoutAsync(bundleName, assetName);
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0x159009C
				callback(instance);
			}));
			AddBundleCounter(bundleName);
		}

		//// RVA: 0xB6A5C4 Offset: 0xB6A5C4 VA: 0xB6A5C4
		private void AddBundleCounter(string bundleName)
		{
			if(m_bundleCounter.ContainsKey(bundleName))
			{
				m_bundleCounter[bundleName]++;
			}
			else
			{
				m_bundleCounter.Add(bundleName, 1);
			}
		}

		//// RVA: 0xB6A6D8 Offset: 0xB6A6D8 VA: 0xB6A6D8
		public void LoadAssetBundle()
		{
			IsLoadBundle = false;
			GameManager.Instance.StartCoroutineWatched(UnionBundle());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x729F24 Offset: 0x729F24 VA: 0x729F24
		//// RVA: 0xB6A790 Offset: 0xB6A790 VA: 0xB6A790
		private IEnumerator UnionBundle()
		{
			int i;

			//0x15966FC
			for(i = 0; i < m_bundleNames.Length; i++)
			{
				IEnumerator e = AssetBundleManager.LoadUnionAssetBundle(m_bundleNames[i]);
				AddBundleCounter(m_bundleNames[i]);
				yield return Co.R(e);
			}
			IsLoadBundle = true;
		}

		//// RVA: 0xB695DC Offset: 0xB695DC VA: 0xB695DC
		public void UnloadAssetBundle()
		{
			foreach(var k in m_bundleCounter)
			{
				for(int i = 0; i < k.Value; i++)
				{
					AssetBundleManager.UnloadAssetBundle(k.Key, false);
				}
			}
		}

		//// RVA: 0xB6A818 Offset: 0xB6A818 VA: 0xB6A818
		//public void PerformExit() { }
	}
}
