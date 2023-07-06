using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public abstract class RankingSceneBase : TransitionRoot
	{
		public class WaitForFrame : CustomYieldInstruction
		{
			private int waitFrame; // 0x8
			private int startFrame; // 0xC

			public override bool keepWaiting { get { return Time.frameCount <= waitFrame + startFrame; } } // 0xCF7CD8

			// RVA: 0xCF4614 Offset: 0xCF4614 VA: 0xCF4614
			public WaitForFrame(int waitFrame)
			{
				this.waitFrame = waitFrame;
				this.startFrame = Time.frameCount;
			}

			//// RVA: 0xCF7C1C Offset: 0xCF7C1C VA: 0xCF7C1C
			public void Reset(int waitFrame)
			{
				this.waitFrame = waitFrame;
				startFrame = Time.frameCount;
			}
		}
		
		protected GeneralListWindow m_windowUi; // 0x48
		protected List<RankingListElemBase> m_elems = new List<RankingListElemBase>(); // 0x4C
		protected SwapScrollList m_scrollList; // 0x50
		protected List<DivaIconDecoration> m_divaDecos = new List<DivaIconDecoration>(); // 0x54
		protected List<SceneIconDecoration> m_sceneDecos = new List<SceneIconDecoration>(); // 0x58
		private bool m_isFriendList; // 0x5C
		private int m_listAddBorderPosition = -1; // 0x60
		private List<RankingListInfo> m_totalInfoList = new List<RankingListInfo>(); // 0x64
		private List<RankingListInfo> m_friendInfoList = new List<RankingListInfo>(); // 0x68
		private bool m_receivedTotalInfo; // 0x6C
		private bool m_receivedFriendInfo; // 0x6D
		private WaitForFrame waitForFrame; // 0x74
		private const int VisibleListItemCount = 2;

		private List<RankingListInfo> currentInfoList { get; set; } // 0x70
		//protected bool isFriendList { get; } 0xCF4564

		// RVA: 0xCF456C Offset: 0xCF456C VA: 0xCF456C Slot: 4
		protected override void Awake()
		{
			base.Awake();
			waitForFrame = new WaitForFrame(3);
			this.StartCoroutineWatched(Co_LoadResources());
		}

		// RVA: 0xCF46CC Offset: 0xCF46CC VA: 0xCF46CC Slot: 16
		protected override void OnPreSetCanvas()
		{
			base.OnPreSetCanvas();
			m_windowUi.Hide();
			m_windowUi.SetMessage("");
			m_windowUi.SetMessageVisible(false);
			Initialize();
		}

		// RVA: 0xCF47B8 Offset: 0xCF47B8 VA: 0xCF47B8 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			m_windowUi.transform.SetAsLastSibling();
			return true;
		}

		// RVA: 0xCF4808 Offset: 0xCF4808 VA: 0xCF4808 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			m_windowUi.Enter();
		}

		// RVA: 0xCF4834 Offset: 0xCF4834 VA: 0xCF4834 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_windowUi.IsPlaying();
		}

		// RVA: 0xCF4864 Offset: 0xCF4864 VA: 0xCF4864 Slot: 12
		protected override void OnStartExitAnimation()
		{
			m_windowUi.Leave();
		}

		// RVA: 0xCF4890 Offset: 0xCF4890 VA: 0xCF4890 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_windowUi.IsPlaying();
		}

		// RVA: 0xCF48C0 Offset: 0xCF48C0 VA: 0xCF48C0 Slot: 14
		protected override void OnDestoryScene()
		{
			Release();
		}

		// RVA: 0xCF48D0 Offset: 0xCF48D0 VA: 0xCF48D0
		private void Update()
		{
			if (m_listAddBorderPosition < 0)
				return;
			if (m_scrollList.ListTopPosition < m_listAddBorderPosition)
				return;
			m_listAddBorderPosition = -1;
			MenuScene.Instance.RaycastDisable();
			m_scrollList.SetEnableScrollBar(false);
			GetRankingListAdditive(false);
		}

		//// RVA: -1 Offset: -1 Slot: 31
		protected abstract void Initialize();

		//// RVA: -1 Offset: -1 Slot: 32
		protected abstract void Release();

		//// RVA: -1 Offset: -1 Slot: 33
		//protected abstract int GetCurrentBaseRank();

		//// RVA: -1 Offset: -1 Slot: 34
		//protected abstract void GetRankingList(int baseRank, int rankingIdx);

		//// RVA: -1 Offset: -1 Slot: 35
		protected abstract void GetRankingListAdditive(bool isUpper);

		//// RVA: -1 Offset: -1 Slot: 36
		//protected abstract string GetRankingNotFoundMessage();

		//// RVA: 0xCF49EC Offset: 0xCF49EC VA: 0xCF49EC Slot: 37
		//protected virtual void OnSetupTotalRanking() { }

		//// RVA: 0xCF49F0 Offset: 0xCF49F0 VA: 0xCF49F0 Slot: 38
		//protected virtual void OnSetupFriendRanking() { }

		//// RVA: 0xCF49F4 Offset: 0xCF49F4 VA: 0xCF49F4
		//protected bool CheckTransitByReturn() { }

		//// RVA: 0xCF4A18 Offset: 0xCF4A18 VA: 0xCF4A18
		protected int GetListEdgeRank(bool isUpper)
		{
			TodoLogger.Log(0, "GetListEdgeRank");
			return 0;
		}

		//// RVA: 0xCF4B24 Offset: 0xCF4B24 VA: 0xCF4B24
		protected void InitializeDecos()
		{
			m_divaDecos.Capacity = m_elems.Count;
			m_sceneDecos.Capacity = m_elems.Count;
			for(int i = 0; i < m_elems.Count; i++)
			{
				if(m_elems[i].GetDivaIconObject() != null)
				{
					m_divaDecos.Add(new DivaIconDecoration(m_elems[i].GetDivaIconObject(), DivaIconDecoration.Size.S, true, true, null, null));
				}
				if(m_elems[i].GetSceneIconObject() != null)
				{
					m_sceneDecos.Add(new SceneIconDecoration(m_elems[i].GetSceneIconObject(), SceneIconDecoration.Size.M, null, null));
				}
			}
		}

		//// RVA: 0xCF4EAC Offset: 0xCF4EAC VA: 0xCF4EAC
		//protected void ReleaseDecos() { }

		//// RVA: 0xCF5050 Offset: 0xCF5050 VA: 0xCF5050
		protected void OnSelectListItem(int value, SwapScrollListContent content)
		{
			TodoLogger.LogNotImplemented("OnSelectListItem");
		}

		//// RVA: 0xCF5370 Offset: 0xCF5370 VA: 0xCF5370
		protected void ResetReceivedFlag()
		{
			m_receivedTotalInfo = false;
			m_receivedFriendInfo = false;
		}

		//// RVA: 0xCF537C Offset: 0xCF537C VA: 0xCF537C
		protected void SetupTotalRanking()
		{
			TodoLogger.Log(0, "SetupTotalRanking");
		}

		//// RVA: 0xCF55F8 Offset: 0xCF55F8 VA: 0xCF55F8
		//protected void SetupFriendRanking() { }

		//// RVA: 0xCF5920 Offset: 0xCF5920 VA: 0xCF5920
		//protected void OnReceivedRankingList(int dir, List<IBIGBMDANNM> list) { }

		//// RVA: 0xCF6048 Offset: 0xCF6048 VA: 0xCF6048
		//protected void OnReceivedRankingList(List<RankingListInfo> a_list) { }

		//// RVA: 0xCF6284 Offset: 0xCF6284 VA: 0xCF6284
		protected void OnReceivedRankingListAdditive(int dir, List<IBIGBMDANNM> list)
		{
			TodoLogger.Log(0, "OnReceivedRankingListAdditive");
		}

		//// RVA: 0xCF64C4 Offset: 0xCF64C4 VA: 0xCF64C4
		//protected void OnReceivedRankingListAdditive(int dir, List<RankingListInfo> a_list) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6E15E4 Offset: 0x6E15E4 VA: 0x6E15E4
		//// RVA: 0xCF5FBC Offset: 0xCF5FBC VA: 0xCF5FBC
		//private IEnumerator Co_WaitDownLoadAsset() { }

		//// RVA: 0xCF66D4 Offset: 0xCF66D4 VA: 0xCF66D4
		protected void OnRankingError()
		{
			TodoLogger.Log(0, "OnRankingError");
		}

		//// RVA: 0xCF67B4 Offset: 0xCF67B4 VA: 0xCF67B4
		protected void OnNetError()
		{
			TodoLogger.Log(0, "OnNetError");
		}

		//// RVA: 0xCF6904 Offset: 0xCF6904 VA: 0xCF6904
		protected void OnClickTotalButton()
		{
			TodoLogger.LogNotImplemented("OnClickTotalButton");
		}

		//// RVA: 0xCF6968 Offset: 0xCF6968 VA: 0xCF6968
		protected void OnClickFriendButton()
		{
			TodoLogger.LogNotImplemented("OnClickFriendButton");
		}

		//// RVA: 0xCF5BE8 Offset: 0xCF5BE8 VA: 0xCF5BE8
		//protected void OnChangedRankingList(int changeDirection) { }

		//// RVA: 0xCF69CC Offset: 0xCF69CC VA: 0xCF69CC
		//protected void OnUpdateListItem(int index, GeneralListContent content, RankingListInfo info) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6E165C Offset: 0x6E165C VA: 0x6E165C
		//// RVA: 0xCF4640 Offset: 0xCF4640 VA: 0xCF4640
		private IEnumerator Co_LoadResources()
		{
			//0xCF791C
			yield return Co.R(Co_LoadLayout());
			IsReady = true;
		}

		//// RVA: -1 Offset: -1 Slot: 39
		protected abstract IEnumerator Co_LoadLayout();

		//[IteratorStateMachineAttribute] // RVA: 0x6E16D4 Offset: 0x6E16D4 VA: 0x6E16D4
		//// RVA: 0xCF6F60 Offset: 0xCF6F60 VA: 0xCF6F60
		protected static IEnumerator Co_LoadListElem(string bundleName, string assetName, Font font, int elemCount, string elemNameFormat, Action<LayoutUGUIRuntime> onLoadedElem)
		{
			TodoLogger.Log(0, "Co_LoadListElem");
			yield return null;
		}

		//[CompilerGeneratedAttribute] // RVA: 0x6E174C Offset: 0x6E174C VA: 0x6E174C
		//// RVA: 0xCF71E0 Offset: 0xCF71E0 VA: 0xCF71E0
		//private void <OnChangedRankingList>b__53_0(int index, SwapScrollListContent content) { }
	}
}
