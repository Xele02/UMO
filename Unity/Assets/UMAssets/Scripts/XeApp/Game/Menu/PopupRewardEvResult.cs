using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupRewardEvResult : UIBehaviour, IPopupContent
	{
		public enum Type
		{
			NONE = -1,
			CumulativePoint = 0,
			Rankings = 1,
			RankingsEventHiScore = 2,
			RankingsEventBattleHiScore = 3,
			RankingGoDivaEvent = 4,
			NUM = 5,
		}

		public class ScrollListItem : IFlexibleListItem
		{
			private GCIJNCFDNON_SceneInfo sceneData; // 0x28

			public Vector2 Top { get; set; } // 0x8
			public float Height { get; set; } // 0x10
			public int ResourceType { get; set; } // 0x14
			public FlexibleListItemLayout Layout { get; set; } // 0x18
			public MFDJIFIIPJD Item { get; set; } // 0x1C
			public int NeedPoint { get; set; } // 0x20
			public bool IsGet { get; set; } // 0x24
			public bool isGoldFrame { get; set; } // 0x25

			//// RVA: 0x1141B0C Offset: 0x1141B0C VA: 0x1141B0C
			//public void OnShowItemDetails() { }
		}

		public class HeaderItem : IFlexibleListItem
		{
			public Vector2 Top { get; set; } // 0x8
			public float Height { get; set; } // 0x10
			public int ResourceType { get; set; } // 0x14
			public FlexibleListItemLayout Layout { get; set; } // 0x18
			public ViewRewardEvResultData Data { get; set; } // 0x1C
		}
		
		public class RankingHeader : IFlexibleListItem
		{
			public Vector2 Top { get; set; } // 0x8
			public float Height { get; set; } // 0x10
			public int ResourceType { get; set; } // 0x14
			public FlexibleListItemLayout Layout { get; set; } // 0x18
			public string RankingMess { get; set; } // 0x1C
		}

		public class PopupRewardEvResultSetting : PopupSetting
		{
			private ViewRewardEvResultData m_ViewData; // 0x34

			//public ViewRewardEvResultData GetViewData { get; } 0x1A7D548
			public Type PopupType { get; set; } // 0x38
			public int DivaId { get; set; } // 0x3C
			public override string PrefabPath { get { return ""; } } //0x1A80178
			public override string BundleName { get { return "ly/053.xab"; } } //0x1A801D4
			public override string AssetName { get { return "PopupRewardEvResult"; } } //0x1A80230
			public override bool IsAssetBundle { get { return true; } } //0x1A8028C
			public override bool IsPreload { get { return true; } } //0x1A80294
			public override GameObject Content { get { return m_content; } } //0x1A8029C

			//// RVA: 0x1A802A4 Offset: 0x1A802A4 VA: 0x1A802A4
			//public void SetContent(GameObject obj) { }

			//// RVA: 0x1A7F9D8 Offset: 0x1A7F9D8 VA: 0x1A7F9D8
			//public void Init(IKDICBBFBMI eventController, OHCAABOMEOF.KGOGMKMBCPP debugEventType = 0) { }

			//[IteratorStateMachineAttribute] // RVA: 0x70EBEC Offset: 0x70EBEC VA: 0x70EBEC
			// RVA: 0x1A802AC Offset: 0x1A802AC VA: 0x1A802AC Slot: 4
			public override IEnumerator LoadAssetBundlePrefab(Transform parent)
			{
				TodoLogger.LogError(0, "LoadAssetBundlePrefab");
				yield return null;
			}

			//[IteratorStateMachineAttribute] // RVA: 0x70EC64 Offset: 0x70EC64 VA: 0x70EC64
			//// RVA: 0x1A80334 Offset: 0x1A80334 VA: 0x1A80334
			//public IEnumerator Co_LoadPopupResource() { }

			//[CompilerGeneratedAttribute] // RVA: 0x70ECDC Offset: 0x70ECDC VA: 0x70ECDC
			//// RVA: 0x1A803E0 Offset: 0x1A803E0 VA: 0x1A803E0
			//private void <Co_LoadPopupResource>b__26_0(GameObject instance) { }
		}

		public class ViewRewardEvResultData
		{
			//public List<IHAEIOAKEMG> total_data_list = new List<IHAEIOAKEMG>(); // 0x8
			public List<MFDJIFIIPJD> rankingRewardList = new List<MFDJIFIIPJD>(); // 0xC
			public Type data_type = Type.NONE; // 0x10

			public int EventId { get; private set; } // 0x14
			public int Rank { get; private set; } // 0x18
			public int RewardHighRank { get; private set; } // 0x1C
			public int RewardLowRank { get; private set; } // 0x20
			public long CurrentPoint { get; private set; } // 0x28
			public string EventName { get; private set; } // 0x30
			public OHCAABOMEOF.KGOGMKMBCPP_EventType EventType { get; private set; } // 0x34
			public string MusicName { get; private set; } // 0x38
			public int CoverId { get; private set; } // 0x3C
			public int evHighScore { get; private set; } // 0x40
			public int evScoreRank { get; private set; } // 0x44

			//// RVA: 0x1141EB8 Offset: 0x1141EB8 VA: 0x1141EB8
			//public void Reset() { }

			//// RVA: 0x1141F64 Offset: 0x1141F64 VA: 0x1141F64
			//public void InitializeCumulativePoint(IKDICBBFBMI eventController) { }

			//// RVA: 0x11420D0 Offset: 0x11420D0 VA: 0x11420D0
			//public void InitializeRanking(IKDICBBFBMI eventController, int rankingIndex, OHCAABOMEOF.KGOGMKMBCPP debugEventType = 0) { }

			//// RVA: 0x11424F4 Offset: 0x11424F4 VA: 0x11424F4
			//public void InitializeEvHighScoreRanking(IKDICBBFBMI eventController, OHCAABOMEOF.KGOGMKMBCPP debugEventType = 0) { }
		}

		private List<IFlexibleListItem> m_scrollItemList = new List<IFlexibleListItem>(); // 0xC
		private static readonly List<ButtonInfo>[] BUTTON_LIST = new List<ButtonInfo>[5]
		{
			new List<ButtonInfo>() {
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive },
			},
			new List<ButtonInfo>() {
				new ButtonInfo() { Label = PopupButton.ButtonLabel.FinalRankings, Type = PopupButton.ButtonType.Other },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			},
			new List<ButtonInfo>() {
				new ButtonInfo() { Label = PopupButton.ButtonLabel.FinalRankings, Type = PopupButton.ButtonType.Other },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			},
			new List<ButtonInfo>() {
				new ButtonInfo() { Label = PopupButton.ButtonLabel.FinalRankings, Type = PopupButton.ButtonType.Other },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			},
			new List<ButtonInfo>() {
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive },
			}
		}; // 0x0
		private static PopupRewardEvResultSetting sm_Setting; // 0x4
		private PopupRewardEvResultSetting m_setting; // 0x14
		private PopupRewardEvResultLayout m_MainLayout; // 0x18
		private PopupRewardEvResultBannerLayout m_BannerLayout; // 0x1C
		private PopupRewardEvResultRankHeaderLayout m_RankHeaderLayout; // 0x20
		private bool m_isReady; // 0x24

		public Transform Parent { get; private set; } // 0x10

		// RVA: 0x1A7C468 Offset: 0x1A7C468 VA: 0x1A7C468 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			TodoLogger.LogError(0, "Initialize");
		}

		//// RVA: 0x1A7C6E4 Offset: 0x1A7C6E4 VA: 0x1A7C6E4
		//private void MakeScrollItem() { }

		// RVA: 0x1A7D58C Offset: 0x1A7D58C VA: 0x1A7D58C
		public void OnDestroy()
		{
			sm_Setting = null;
		}

		//// RVA: 0x1A7D61C Offset: 0x1A7D61C VA: 0x1A7D61C
		//private void SetupScrollContent() { }

		// RVA: 0x1A7D7AC Offset: 0x1A7D7AC VA: 0x1A7D7AC Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1A7D7B4 Offset: 0x1A7D7B4 VA: 0x1A7D7B4 Slot: 19
		public void Show()
		{
			TodoLogger.LogError(0, "Show");
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70E78C Offset: 0x70E78C VA: 0x70E78C
		//// RVA: 0x1A7D9CC Offset: 0x1A7D9CC VA: 0x1A7D9CC
		//private IEnumerator Co_Show() { }

		// RVA: 0x1A7DA78 Offset: 0x1A7DA78 VA: 0x1A7DA78 Slot: 20
		public void Hide()
		{
			TodoLogger.LogError(0, "Hide");
		}

		// RVA: 0x1A7DC2C Offset: 0x1A7DC2C VA: 0x1A7DC2C Slot: 21
		public bool IsReady()
		{
			TodoLogger.LogError(0, "IsReady");
			return true;
		}

		// RVA: 0x1A7DD18 Offset: 0x1A7DD18 VA: 0x1A7DD18 Slot: 22
		public void CallOpenEnd()
		{
			TodoLogger.LogError(0, "CallOpenEnd");
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70E804 Offset: 0x70E804 VA: 0x70E804
		//// RVA: 0x1A7DD3C Offset: 0x1A7DD3C VA: 0x1A7DD3C
		//private IEnumerator Co_DelayOpenEnd() { }

		//// RVA: 0x1A7DDE8 Offset: 0x1A7DDE8 VA: 0x1A7DDE8
		//private void UpdateContent(IFlexibleListItem item) { }

		//[IteratorStateMachineAttribute] // RVA: 0x70E87C Offset: 0x70E87C VA: 0x70E87C
		//// RVA: 0x1A7E4C0 Offset: 0x1A7E4C0 VA: 0x1A7E4C0
		//public static IEnumerator Co_ShowPopup_CumulativePoint(Transform parent, Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> buttonCallBack) { }

		//[IteratorStateMachineAttribute] // RVA: 0x70E8F4 Offset: 0x70E8F4 VA: 0x70E8F4
		//// RVA: 0x1A7E588 Offset: 0x1A7E588 VA: 0x1A7E588
		public static IEnumerator Co_ShowPopup_Ranking(int a_index, IKDICBBFBMI_EventBase controller, Transform parent, int divaId, Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> buttonCallBack, Action finishCallBack)
		{
			TodoLogger.LogError(0, "Co_ShowPopup_Ranking");
			yield return null;
		}

		//// RVA: 0x1A7E6B4 Offset: 0x1A7E6B4 VA: 0x1A7E6B4
		//private static void ApplySetting(PopupRewardEvResult.Type popup_type, Transform parent, int divaId = 0) { }
	}
}
