using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Core;

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
		//public ScrollRect layoutBgScroll { get; private set; }  0x194F734 0x194F73C
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
		//public IEnumerator SetupBg(int map) { }

		//// RVA: 0x194D1FC Offset: 0x194D1FC VA: 0x194D1FC
		//public void LoadIconImage(List<LIEJFHMGNIA> stageList) { }

		//// RVA: 0x194D6B4 Offset: 0x194D6B4 VA: 0x194D6B4
		//public void Setup() { }

		//// RVA: 0x194D8B8 Offset: 0x194D8B8 VA: 0x194D8B8
		//public bool IsLoading() { }

		//// RVA: 0x194DA74 Offset: 0x194DA74 VA: 0x194DA74
		//public void In() { }

		//// RVA: 0x194DB28 Offset: 0x194DB28 VA: 0x194DB28
		//public void Out() { }

		//// RVA: 0x194DC44 Offset: 0x194DC44 VA: 0x194DC44
		//public void Hide() { }

		//// RVA: 0x194DD60 Offset: 0x194DD60 VA: 0x194DD60
		//public void BgVisibleEnable(bool enable) { }

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
				UnityEngine.Object.Destroy(layoutArrowLeft.gameObject);
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
		//public IEnumerator LoadLayout(Transform parent, Transform parentBack, Action callback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x728594 Offset: 0x728594 VA: 0x728594
		//// RVA: 0x194ECEC Offset: 0x194ECEC VA: 0x194ECEC
		//public IEnumerator LoadLayoutBgButton(Action callback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x72860C Offset: 0x72860C VA: 0x72860C
		//// RVA: 0x194EDB4 Offset: 0x194EDB4 VA: 0x194EDB4
		//public IEnumerator LoadLayoutMapButton(Action callback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x728684 Offset: 0x728684 VA: 0x728684
		//// RVA: 0x194EE58 Offset: 0x194EE58 VA: 0x194EE58
		//public IEnumerator LoadLayoutArrowRight(Action callback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x7286FC Offset: 0x7286FC VA: 0x7286FC
		//// RVA: 0x194EF20 Offset: 0x194EF20 VA: 0x194EF20
		//public IEnumerator LoadLayoutArrowLeft(Action callback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x728774 Offset: 0x728774 VA: 0x728774
		//// RVA: 0x194EFE8 Offset: 0x194EFE8 VA: 0x194EFE8
		//public IEnumerator LoadLayoutIcon(Action callback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x7287EC Offset: 0x7287EC VA: 0x7287EC
		//// RVA: 0x194F08C Offset: 0x194F08C VA: 0x194F08C
		//public IEnumerator LoadLayoutIconL(Action callback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x728864 Offset: 0x728864 VA: 0x728864
		//// RVA: 0x194F130 Offset: 0x194F130 VA: 0x194F130
		//public IEnumerator LoadLayoutTerminationIcon(Action callback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x7288DC Offset: 0x7288DC VA: 0x7288DC
		//// RVA: 0x194F1D4 Offset: 0x194F1D4 VA: 0x194F1D4
		//public IEnumerator LoadLayoutCompleteIcon(Action callback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x728954 Offset: 0x728954 VA: 0x728954
		//// RVA: 0x194F29C Offset: 0x194F29C VA: 0x194F29C
		//public IEnumerator Co_CompleteProduction(Action callback, Action completeStageIn) { }

		//[IteratorStateMachineAttribute] // RVA: 0x7289CC Offset: 0x7289CC VA: 0x7289CC
		//// RVA: 0x194F37C Offset: 0x194F37C VA: 0x194F37C
		//public IEnumerator LoadLayoutIconScroll(Action callback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x728A44 Offset: 0x728A44 VA: 0x728A44
		//// RVA: 0x194F420 Offset: 0x194F420 VA: 0x194F420
		//public IEnumerator LoadLayoutInfo(Action callback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x728ABC Offset: 0x728ABC VA: 0x728ABC
		//// RVA: 0x194F4C4 Offset: 0x194F4C4 VA: 0x194F4C4
		//public IEnumerator LoadNoizeTexture(Action callback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x728B34 Offset: 0x728B34 VA: 0x728B34
		//// RVA: 0x194F568 Offset: 0x194F568 VA: 0x194F568
		//private IEnumerator LoadLayoutInner(string bundleName, string assetName, Action<GameObject> callback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x728BAC Offset: 0x728BAC VA: 0x728BAC
		//// RVA: 0x194F63C Offset: 0x194F63C VA: 0x194F63C
		//private IEnumerator LoadGameObjectInner(string bundleName, string assetName, Action<GameObject> callback) { }
		
		//// RVA: 0x194F744 Offset: 0x194F744 VA: 0x194F744
		//private void AddBundleCounter(string bundleName) { }

		//// RVA: 0x194F858 Offset: 0x194F858 VA: 0x194F858
		//public void LoadAssetBundle() { }

		//[IteratorStateMachineAttribute] // RVA: 0x728C44 Offset: 0x728C44 VA: 0x728C44
		//// RVA: 0x194F910 Offset: 0x194F910 VA: 0x194F910
		//private IEnumerator UnionBundle() { }

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

		//[CompilerGeneratedAttribute] // RVA: 0x728CBC Offset: 0x728CBC VA: 0x728CBC
		//// RVA: 0x194F998 Offset: 0x194F998 VA: 0x194F998
		//private void <LoadLayoutBgButton>b__85_0(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x728CCC Offset: 0x728CCC VA: 0x728CCC
		//// RVA: 0x194FA14 Offset: 0x194FA14 VA: 0x194FA14
		//private void <LoadLayoutMapButton>b__86_0(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x728CDC Offset: 0x728CDC VA: 0x728CDC
		//// RVA: 0x194FA90 Offset: 0x194FA90 VA: 0x194FA90
		//private void <LoadLayoutArrowRight>b__87_0(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x728CEC Offset: 0x728CEC VA: 0x728CEC
		//// RVA: 0x194FB0C Offset: 0x194FB0C VA: 0x194FB0C
		//private void <LoadLayoutArrowLeft>b__88_0(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x728CFC Offset: 0x728CFC VA: 0x728CFC
		//// RVA: 0x194FB88 Offset: 0x194FB88 VA: 0x194FB88
		//private void <LoadLayoutTerminationIcon>b__91_0(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x728D0C Offset: 0x728D0C VA: 0x728D0C
		//// RVA: 0x194FC04 Offset: 0x194FC04 VA: 0x194FC04
		//private void <LoadLayoutCompleteIcon>b__92_0(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x728D1C Offset: 0x728D1C VA: 0x728D1C
		//// RVA: 0x194FC80 Offset: 0x194FC80 VA: 0x194FC80
		//private void <Co_CompleteProduction>b__93_0(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x728D2C Offset: 0x728D2C VA: 0x728D2C
		//// RVA: 0x194FCFC Offset: 0x194FCFC VA: 0x194FCFC
		//private void <LoadLayoutIconScroll>b__94_0(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x728D3C Offset: 0x728D3C VA: 0x728D3C
		//// RVA: 0x194FD7C Offset: 0x194FD7C VA: 0x194FD7C
		//private void <LoadLayoutInfo>b__95_0(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x728D4C Offset: 0x728D4C VA: 0x728D4C
		//// RVA: 0x194FDF8 Offset: 0x194FDF8 VA: 0x194FDF8
		//private void <LoadNoizeTexture>b__96_0(GameObject instance) { }
	}
}
