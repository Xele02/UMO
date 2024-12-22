using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Core;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutStorySelectController : IDisposable
	{
		private bool m_isOneSetup; // 0x45
		private bool m_isLayoutSetup; // 0x46
		private const int ICON_NUM = 7;
		private const int ICON_L_NUM = 6;
		private const int BG_NUM = 8;
		private string[] m_bundleNames = new string[1] { "ly/011.xab" }; // 0x48
		private Dictionary<string, int> m_bundleCounter = new Dictionary<string, int>(8); // 0x4C

		public Transform Parent { get; set; } // 0x8
		public Transform ParentBack { get; set; } // 0xC
		public StorySelectBgButtonLayout layoutBgButton { get; set; } // 0x10
		public StorySelectMapButtonLayout layoutMapButton { get; private set; } // 0x14
		public LayoutStorySelectArrowLeft layoutArrowLeft { get; private set; } // 0x18
		public LayoutStorySelectArrowRight layoutArrowRight { get; private set; } // 0x1C
		public List<StorySelectStageIcon> layoutIcon { get; private set; } // 0x20
		public List<StorySelectStageIcon> layoutIconL { get; private set; } // 0x24
		public StorySelectStageTerminationIcon layoutTerminationIcon { get; private set; } // 0x28
		public StorySelectStageCompleteIcon layoutCompleteIcon { get; private set; } // 0x2C
		public StorySelectCompleteProduction layoutCompleteProduction { get; private set; } // 0x30
		public ScrollRect layoutBgScroll { get { return MenuScene.Instance.BgControl.storyBgScrollRect; } private set { return; } } // 0x194CDE0 0x194CE9C
		public ScrollRect layoutIconScroll { get; private set; } // 0x34
		public NewMarkIcon layoutNewIconMark { get; private set; } // 0x38
		public LayoutStorySelectInfo layoutInfo { get; private set; } // 0x3C
		public NoizeTexture noizeTexture { get; private set; } // 0x40
		public bool IsLoadlayout { get; private set; } // 0x44
		public bool IsLoadBundle { get; private set; } // 0x50

		// RVA: 0x194CEF0 Offset: 0x194CEF0 VA: 0x194CEF0
		public LayoutStorySelectController()
		{
			layoutIcon = new List<StorySelectStageIcon>(5);
			layoutIconL = new List<StorySelectStageIcon>(5);
			layoutNewIconMark = new NewMarkIcon();
		}

		//// RVA: 0x194D094 Offset: 0x194D094 VA: 0x194D094
		public void AttachNewIcon(GameObject attachObject, bool isActive)
		{
			if (attachObject == null)
				return;
			layoutNewIconMark.Initialize(attachObject);
			layoutNewIconMark.SetActive(isActive);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7284A4 Offset: 0x7284A4 VA: 0x7284A4
		//// RVA: 0x194D174 Offset: 0x194D174 VA: 0x194D174
		public IEnumerator SetupBg(int map)
		{
			//0x1533184
			yield return Co.R(MenuScene.Instance.BgControl.SetStoryBgTexture(map, null));
		}

		//// RVA: 0x194D1FC Offset: 0x194D1FC VA: 0x194D1FC
		public void LoadIconImage(List<LIEJFHMGNIA> stageList)
		{
			for(int i = 0; i < stageList.Count; i++)
			{
				if(stageList[i].MMEGDFPNONJ_HasDivaId)
				{
					GameManager.Instance.DivaIconCache.LoadStoryIcon(stageList[i].AHHJLDLAPAN_DivaId, 1, (IiconTexture icon) =>
					{
						//0x194FEF0
						return;
					});
				}
				else
				{
					GameManager.Instance.MusicJacketTextureCache.Load(stageList[i].JNCPEGJGHOG_JacketId, (IiconTexture icon) =>
					{
						//0x194FEF4
						return;
					});
				}
			}
		}

		//// RVA: 0x194D6B4 Offset: 0x194D6B4 VA: 0x194D6B4
		public void Setup()
		{
			if (noizeTexture == null)
				return;
			for (int i = 0; i < layoutIcon.Count; i++)
			{
				noizeTexture.SetRegisterImage(layoutIcon[i].GetNoizeImage());
			}
			for(int i = 0; i < layoutIconL.Count; i++)
			{
				noizeTexture.SetRegisterImage(layoutIconL[i].GetNoizeImage());
			}
		}

		//// RVA: 0x194D8B8 Offset: 0x194D8B8 VA: 0x194D8B8
		public bool IsLoading()
		{
			return GameManager.Instance.BgTextureCache.IsLoading() || GameManager.Instance.DivaIconCache.IsLoading() || GameManager.Instance.MusicJacketTextureCache.IsLoading();
		}

		//// RVA: 0x194DA74 Offset: 0x194DA74 VA: 0x194DA74
		//public void In() { }

		//// RVA: 0x194DB28 Offset: 0x194DB28 VA: 0x194DB28
		//public void Out() { }

		//// RVA: 0x194DC44 Offset: 0x194DC44 VA: 0x194DC44
		//public void Hide() { }

		//// RVA: 0x194DD60 Offset: 0x194DD60 VA: 0x194DD60
		public void BgVisibleEnable(bool enable)
		{
			if (!enable)
				return;
			if (layoutMapButton != null)
				layoutMapButton.Hide();
			if (layoutArrowLeft != null)
				layoutArrowLeft.Hide();
			if (layoutArrowRight != null)
				layoutArrowRight.Hide();
		}

		//// RVA: 0x194DEEC Offset: 0x194DEEC VA: 0x194DEEC
		//public void Reset() { }

		// RVA: 0x194DEF0 Offset: 0x194DEF0 VA: 0x194DEF0 Slot: 4
		public void Dispose()
		{
			if (layoutNewIconMark != null)
				layoutNewIconMark.Release();
			layoutNewIconMark = null;
			if(noizeTexture != null)
			{
				noizeTexture.Dispose();
				UnityEngine.Object.Destroy(noizeTexture.gameObject);
			}
			noizeTexture = null;
			if (layoutBgButton != null)
				UnityEngine.Object.Destroy(layoutBgButton.gameObject);
			layoutBgButton = null;
			if (layoutMapButton != null)
				UnityEngine.Object.Destroy(layoutMapButton.gameObject);
			layoutMapButton = null;
			if (layoutArrowLeft != null)
				UnityEngine.Object.Destroy(layoutArrowLeft.gameObject);
			layoutArrowLeft = null;
			if (layoutArrowRight != null)
				UnityEngine.Object.Destroy(layoutArrowRight.gameObject);
			layoutArrowRight = null;
			for(int i = 0; i < layoutIconL.Count; i++)
			{
				if(layoutIconL[i] != null)
				{
					UnityEngine.Object.Destroy(layoutIconL[i].gameObject);
				}
			}
			layoutIconL.Clear();
			for(int i = 0; i < layoutIcon.Count; i++)
			{
				if(layoutIcon[i] != null)
				{
					UnityEngine.Object.Destroy(layoutIcon[i].gameObject);
				}
			}
			layoutIcon.Clear();
			if (layoutIconScroll != null)
				UnityEngine.Object.Destroy(layoutIconScroll.gameObject);
			layoutIconScroll = null;
			if (layoutInfo != null)
				UnityEngine.Object.Destroy(layoutInfo.gameObject);
			layoutInfo = null;
			if (layoutTerminationIcon != null)
				UnityEngine.Object.Destroy(layoutTerminationIcon.gameObject);
			layoutTerminationIcon = null;
			if (layoutCompleteIcon != null)
				UnityEngine.Object.Destroy(layoutCompleteIcon.gameObject);
			layoutCompleteIcon = null;
			if (layoutCompleteProduction != null)
				UnityEngine.Object.Destroy(layoutCompleteProduction.gameObject);
			layoutCompleteProduction = null;
			UnloadAssetBundle();
			MenuScene.Instance.BgControl.StoryBgHide();
			IsLoadlayout = false;
			IsLoadBundle = false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72851C Offset: 0x72851C VA: 0x72851C
		//// RVA: 0x194EBF4 Offset: 0x194EBF4 VA: 0x194EBF4
		public IEnumerator LoadLayout(Transform parent, Transform parentBack, Action callback)
		{
			//0x19507FC
			if(!m_isOneSetup)
			{
				m_isOneSetup = true;
				LoadAssetBundle();
				while (!IsLoadBundle)
					yield return null;
			}
			if (parent != null)
				Parent = parent;
			if (parentBack != null)
				ParentBack = parentBack;
			bool isLoading = true;
			GameManager.Instance.StartCoroutineWatched(LoadLayoutIconScroll(() =>
			{
				//0x194FF00
				isLoading = false;
			}));
			while (isLoading)
				yield return null;
			isLoading = true;
			GameManager.Instance.StartCoroutineWatched(LoadLayoutIcon(() =>
			{
				//0x194FF0C
				isLoading = false;
			}));
			while (isLoading)
				yield return null;
			isLoading = true;
			GameManager.Instance.StartCoroutineWatched(LoadLayoutIconL(() =>
			{
				//0x194FF18
				isLoading = false;
			}));
			while (isLoading)
				yield return null;
			isLoading = true;
			GameManager.Instance.StartCoroutineWatched(LoadLayoutTerminationIcon(() =>
			{
				//0x194FF24
				isLoading = false;
			}));
			while (isLoading)
				yield return null;
			isLoading = true;
			GameManager.Instance.StartCoroutineWatched(LoadLayoutCompleteIcon(() =>
			{
				//0x194FF30
				isLoading = false;
			}));
			while (isLoading)
				yield return null;
			bool isLoadingBgButton = true;
			bool isLoadingMapButton = true;
			bool isLoadingArrowRight = true;
			bool isLoadingArrowLeft = true;
			GameManager.Instance.StartCoroutineWatched(LoadLayoutBgButton(() =>
			{
				//0x194FF3C
				isLoadingBgButton = false;
			}));
			GameManager.Instance.StartCoroutineWatched(LoadLayoutMapButton(() =>
			{
				//0x194FF48
				isLoadingMapButton = false;
			}));
			GameManager.Instance.StartCoroutineWatched(LoadLayoutArrowRight(() =>
			{
				//0x194FF54
				isLoadingArrowRight = false;
			}));
			GameManager.Instance.StartCoroutineWatched(LoadLayoutArrowLeft(() =>
			{
				//0x194FF60
				isLoadingArrowLeft = false;
			}));
			while (isLoadingMapButton)
				yield return null;
			while (isLoadingBgButton)
				yield return null;
			while (isLoadingArrowRight)
				yield return null;
			while (isLoadingArrowLeft)
				yield return null;
			isLoading = true;
			GameManager.Instance.StartCoroutineWatched(LoadNoizeTexture(() =>
			{
				//0x194FF6C
				isLoading = false;
			}));
			while (isLoading)
				yield return null;
			if (callback != null)
				callback();
			IsLoadlayout = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x728594 Offset: 0x728594 VA: 0x728594
		//// RVA: 0x194ECEC Offset: 0x194ECEC VA: 0x194ECEC
		public IEnumerator LoadLayoutBgButton(Action callback)
		{
			//0x1951ABC
			if(layoutBgButton == null)
			{
				yield return Co.R(LoadLayoutInner("ly/011.xab", "root_story_bg_btn_layout_root", (GameObject instance) =>
				{
					//0x194F998
					layoutBgButton = instance.GetComponent<StorySelectBgButtonLayout>();
				}));
				while (layoutBgButton == null)
					yield return null;
				while (!layoutBgButton.IsLoaded())
					yield return null;
				layoutBgButton.transform.SetParent(Parent, false);
			}
			if (callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72860C Offset: 0x72860C VA: 0x72860C
		//// RVA: 0x194EDB4 Offset: 0x194EDB4 VA: 0x194EDB4
		public IEnumerator LoadLayoutMapButton(Action callback)
		{
			//0x15326CC
			if(layoutMapButton == null)
			{
				yield return Co.R(LoadLayoutInner("ly/011.xab", "root_story_map_layout_root", (GameObject instance) =>
				{
					//0x194FA14
					layoutMapButton = instance.GetComponent<StorySelectMapButtonLayout>();
				}));
				while (layoutMapButton == null)
					yield return null;
				while (!layoutMapButton.IsLoaded())
					yield return null;
				layoutMapButton.transform.SetParent(Parent, false);
				layoutMapButton.gameObject.SetActive(false);
			}
			if (callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x728684 Offset: 0x728684 VA: 0x728684
		//// RVA: 0x194EE58 Offset: 0x194EE58 VA: 0x194EE58
		public IEnumerator LoadLayoutArrowRight(Action callback)
		{
			//0x1951790
			if(layoutArrowRight == null)
			{
				yield return Co.R(LoadLayoutInner("ly/011.xab", "root_story_arr_r_layout_root", (GameObject instance) =>
				{
					//0x194FA90
					layoutArrowRight = instance.GetComponent<LayoutStorySelectArrowRight>();
				}));
				while(layoutArrowRight == null)
					yield return null;
				while(!layoutArrowRight.IsLoaded())
					yield return null;
				layoutArrowRight.transform.SetParent(Parent, false);
			}
			if (callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7286FC Offset: 0x7286FC VA: 0x7286FC
		//// RVA: 0x194EF20 Offset: 0x194EF20 VA: 0x194EF20
		public IEnumerator LoadLayoutArrowLeft(Action callback)
		{
			//0x1951464
			if(layoutArrowLeft == null)
			{
				yield return Co.R(LoadLayoutInner("ly/011.xab", "root_story_arr_l_layout_root", (GameObject instance) =>
				{
					//0x194FB0C
					layoutArrowLeft = instance.GetComponent<LayoutStorySelectArrowLeft>();
				}));
				while (layoutArrowLeft == null)
					yield return null;
				while (!layoutArrowLeft.IsLoaded())
					yield return null;
				layoutArrowLeft.transform.SetParent(Parent, false);
			}
			if (callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x728774 Offset: 0x728774 VA: 0x728774
		//// RVA: 0x194EFE8 Offset: 0x194EFE8 VA: 0x194EFE8
		public IEnumerator LoadLayoutIcon(Action callback)
		{
			//0x1530FF4
			if(layoutIcon.Count < 1)
			{
				LayoutUGUIRuntime runtime = null;
				yield return Co.R(LoadLayoutInner("ly/011.xab", "StoryStageIconPrefab", (GameObject instance) =>
				{
					//0x194FF80
					runtime = instance.GetComponent<LayoutUGUIRuntime>();
				}));
				for(int i = 0; i < 7; i++)
				{
					LayoutUGUIRuntime r = UnityEngine.Object.Instantiate(runtime);
					r.IsLayoutAutoLoad = false;
					r.UvMan = runtime.UvMan;
					r.Layout = runtime.Layout.DeepClone();
					r.LoadLayout();
					layoutIcon.Add(r.GetComponent<StorySelectStageIcon>());
					r.transform.SetParent(layoutIconScroll.content, false);
				}
				UnityEngine.Object.Destroy(runtime.gameObject);
				for(int i = 0; i < layoutIcon.Count; i++)
				{
					while (!layoutIcon[i].IsLoaded())
						yield return null;
				}
			}
			if (callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7287EC Offset: 0x7287EC VA: 0x7287EC
		//// RVA: 0x194F08C Offset: 0x194F08C VA: 0x194F08C
		public IEnumerator LoadLayoutIconL(Action callback)
		{
			//0x153169C
			if(layoutIconL.Count < 1)
			{
				LayoutUGUIRuntime runtime = null;
				yield return Co.R(LoadLayoutInner("ly/011.xab", "StoryStageLargeIconPrefab", (GameObject instance) =>
				{
					//0x194FF80
					runtime = instance.GetComponent<LayoutUGUIRuntime>();
				}));
				for(int i = 0; i < 7; i++)
				{
					LayoutUGUIRuntime r = UnityEngine.Object.Instantiate(runtime);
					r.IsLayoutAutoLoad = false;
					r.UvMan = runtime.UvMan;
					r.Layout = runtime.Layout.DeepClone();
					r.LoadLayout();
					layoutIconL.Add(r.GetComponent<StorySelectStageIcon>());
					r.transform.SetParent(layoutIconScroll.content, false);
				}
				UnityEngine.Object.Destroy(runtime.gameObject);
				// UMO : fixed UM bug while was testing layoutIcon
				for (int i = 0; i < layoutIconL.Count; i++)
				{
					while (!layoutIconL[i].IsLoaded())
						yield return null;
				}
			}
			if (callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x728864 Offset: 0x728864 VA: 0x728864
		//// RVA: 0x194F130 Offset: 0x194F130 VA: 0x194F130
		public IEnumerator LoadLayoutTerminationIcon(Action callback)
		{
			//0x1532AEC
			if(layoutTerminationIcon == null)
			{
				yield return Co.R(LoadLayoutInner("ly/011.xab", "root_story_termnal_layout_root", (GameObject instance) =>
				{
					//0x194FB88
					layoutTerminationIcon = instance.GetComponent<StorySelectStageTerminationIcon>();
				}));
				while (layoutTerminationIcon == null)
					yield return null;
				while(!layoutTerminationIcon.IsLoaded())
					yield return null;
				layoutTerminationIcon.transform.SetParent(layoutIconScroll.content, false);
				layoutTerminationIcon.gameObject.SetActive(false);
			}
			if (callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7288DC Offset: 0x7288DC VA: 0x7288DC
		//// RVA: 0x194F1D4 Offset: 0x194F1D4 VA: 0x194F1D4
		public IEnumerator LoadLayoutCompleteIcon(Action callback)
		{
			//0x1951DE8
			if(layoutCompleteIcon == null)
			{
				yield return Co.R(LoadLayoutInner("ly/011.xab", "root_story_comp_layout_root", (GameObject instance) =>
				{
					//0x194FC04
					layoutCompleteIcon = instance.GetComponent<StorySelectStageCompleteIcon>();
				}));
				while (layoutCompleteIcon == null)
					yield return null;
				while (!layoutCompleteIcon.IsLoaded())
					yield return null;
				layoutCompleteIcon.transform.SetParent(layoutIconScroll.content, false);
				layoutCompleteIcon.gameObject.SetActive(false);
			}
			if (callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x728954 Offset: 0x728954 VA: 0x728954
		//// RVA: 0x194F29C Offset: 0x194F29C VA: 0x194F29C
		public IEnumerator Co_CompleteProduction(Action callback, Action completeStageIn)
		{
			//0x195010C
			yield return Co.R(LoadLayoutInner("ly/011.xab", "root_story_comp_bg_layout_root", (GameObject instance) =>
			{
				//0x194FC80
				layoutCompleteProduction = instance.GetComponent<StorySelectCompleteProduction>();
			}));
			while(layoutCompleteProduction == null)
				yield return null;
			while(!layoutCompleteProduction.IsLoaded())
				yield return null;
			layoutCompleteProduction.transform.SetParent(MenuScene.Instance.GetCurrentTransitionRoot().transform.parent, false);
			layoutCompleteProduction.transform.SetAsLastSibling();
			layoutCompleteProduction.gameObject.SetActive(true);
			yield return Co.R(layoutCompleteProduction.CompleteProduction(completeStageIn));
			if(callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7289CC Offset: 0x7289CC VA: 0x7289CC
		//// RVA: 0x194F37C Offset: 0x194F37C VA: 0x194F37C
		public IEnumerator LoadLayoutIconScroll(Action callback)
		{
			//0x1531D44
			if(layoutIconScroll == null)
			{
				yield return Co.R(LoadLayoutInner("ly/011.xab", "MainScroll", (GameObject instance) =>
				{
					//0x194FCFC
					layoutIconScroll = instance.GetComponentInChildren<ScrollRect>(true);
				}));
				layoutIconScroll.transform.SetParent(Parent, false);
			}
			if (callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x728A44 Offset: 0x728A44 VA: 0x728A44
		//// RVA: 0x194F420 Offset: 0x194F420 VA: 0x194F420
		public IEnumerator LoadLayoutInfo(Action callback)
		{
			//0x1532024
			if(layoutInfo == null)
			{
				yield return Co.R(LoadLayoutInner("ly/011.xab", "root_story_info_layout_root", (GameObject instance) =>
				{
					//0x194FD7C
					layoutInfo = instance.GetComponent<LayoutStorySelectInfo>();
				}));
			}
			if (callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x728ABC Offset: 0x728ABC VA: 0x728ABC
		//// RVA: 0x194F4C4 Offset: 0x194F4C4 VA: 0x194F4C4
		public IEnumerator LoadNoizeTexture(Action callback)
		{
			//0x1532F2C
			if(noizeTexture == null)
			{
				yield return Co.R(LoadGameObjectInner("ly/011.xab", "NoizeIconObject", (GameObject instance) =>
				{
					//0x194FDF8
					noizeTexture = instance.GetComponent<NoizeTexture>();
				}));
			}
			if (callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x728B34 Offset: 0x728B34 VA: 0x728B34
		//// RVA: 0x194F568 Offset: 0x194F568 VA: 0x194F568
		private IEnumerator LoadLayoutInner(string bundleName, string assetName, Action<GameObject> callback)
		{
			XeSys.FontInfo font; // 0x24
			AssetBundleLoadLayoutOperationBase operation; // 0x28

			//0x15323E4
			font = GameManager.Instance.GetSystemFont();
			operation = AssetBundleManager.LoadLayoutAsync(bundleName, assetName);
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0x1950088
				callback(instance);
			}));
			AddBundleCounter(bundleName);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x728BAC Offset: 0x728BAC VA: 0x728BAC
		//// RVA: 0x194F63C Offset: 0x194F63C VA: 0x194F63C
		private IEnumerator LoadGameObjectInner(string bundleName, string assetName, Action<GameObject> callback)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x1950554
			operation = AssetBundleManager.LoadLayoutAsync(bundleName, assetName);
			yield return operation;
			GameObject g = UnityEngine.Object.Instantiate(operation.GetAsset<GameObject>());
			AddBundleCounter(bundleName);
			callback(g);
		}

		//// RVA: 0x194F744 Offset: 0x194F744 VA: 0x194F744
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

		//// RVA: 0x194F858 Offset: 0x194F858 VA: 0x194F858
		public void LoadAssetBundle()
		{
			IsLoadBundle = false;
			GameManager.Instance.StartCoroutineWatched(UnionBundle());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x728C44 Offset: 0x728C44 VA: 0x728C44
		//// RVA: 0x194F910 Offset: 0x194F910 VA: 0x194F910
		private IEnumerator UnionBundle()
		{
			int i;

			//0x1533344
			for(i = 0; i < m_bundleNames.Length; i++)
			{
				UnionAssetBundleLoadOperation op = AssetBundleManager.LoadUnionAssetBundle(m_bundleNames[i]);
				AddBundleCounter(m_bundleNames[i]);
				yield return op;
			}
			IsLoadBundle = true;
		}

		//// RVA: 0x194E998 Offset: 0x194E998 VA: 0x194E998
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
	}
}
