using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupDenomination : UIBehaviour, IPopupContent
	{
		private class PopupDenominationSetting : PopupSetting
		{
			public class ScrollObject
			{
				// Fields
				public GameObject obj; // 0x8
				public bool is_disp; // 0xC
			}

			private List<ScrollObject> m_ScrollObjList = new List<ScrollObject>(); // 0x4C
			private Vector2 m_ItemSize = Vector2.zero; // 0x50
			private List<LGDNAJACFHI> m_paidVcProductDataList = new List<LGDNAJACFHI>(); // 0x58

			public AMOCLPHDGBP NetPaidVCPurchase { get; set; } // 0x34
			public ELBOJBBIBFM OnPurchase { get; set; } // 0x38
			public JFDNPFFOACP OnCancel { get; set; } // 0x3C
			public OnDenomChangeDate OnChangeDate { get; set; } // 0x40
			public ProductListFilter Filter { get; set; } // 0x44
			public int HavePaidVC { get; set; } // 0x48
			//public List<ScrollObject> GetScrollObjList { get; } 0xF7C728
			//public Vector2 GetItemSize { get; } 0xF7C96C
			public override string PrefabPath { get { return ""; } } //0xF7FBB0
			public override string BundleName { get { return "ly/078.xab"; } } //0xF7FC0C
			public override string AssetName { get { return "PopupDenomination"; } } //0xF7FC68
			public override bool IsAssetBundle { get { return true; } } //0xF7FCC4
			public override bool IsPreload { get { return true; } } //0xF7FCCC
			public override GameObject Content { get { return m_content; } } //0xF7FCD4

			//// RVA: 0xF7FCDC Offset: 0xF7FCDC VA: 0xF7FCDC
			//public void SetContent(GameObject obj) { }

			//// RVA: 0xF7CAA4 Offset: 0xF7CAA4 VA: 0xF7CAA4
			//public void ReleaseScrollObj() { }

			//[IteratorStateMachineAttribute] // RVA: 0x6D82EC Offset: 0x6D82EC VA: 0x6D82EC
			//// RVA: 0xF7F86C Offset: 0xF7F86C VA: 0xF7F86C
			//public IEnumerator Co_LoadPopupResource() { }

			//// RVA: 0xF7FD04 Offset: 0xF7FD04 VA: 0xF7FD04
			//private LayoutUGUIRuntime CopyInstance(LayoutUGUIRuntime runtime) { }

			//[CompilerGeneratedAttribute] // RVA: 0x6D8364 Offset: 0x6D8364 VA: 0x6D8364
			//// RVA: 0xF7FE84 Offset: 0xF7FE84 VA: 0xF7FE84
			//private void <Co_LoadPopupResource>b__46_0(GameObject instance) { }
		}

		private static PopupDenominationSetting sm_Setting; // 0x0
		private static PopupWindowControl sm_Control; // 0x4
		private static DJBHIFLHJLK errorHandler; // 0x8
		private const int ScrollItemCount = 3;
		private LayoutPopupDenomination m_MainLayout; // 0x10
		private PopupWindowControl m_control; // 0x14
		//[CompilerGeneratedAttribute] // RVA: 0x66C808 Offset: 0x66C808 VA: 0x66C808
		public Action SupportSiteManagerErrorHandler; // 0x18
		private bool m_IsBuying; // 0x1C
		private List<LGDNAJACFHI> m_paidVcProductDataList = new List<LGDNAJACFHI>(); // 0x20

		public Transform Parent { get; private set; } // 0xC

		//[IteratorStateMachineAttribute] // RVA: 0x6D7FB4 Offset: 0x6D7FB4 VA: 0x6D7FB4
		//// RVA: 0xF7B788 Offset: 0xF7B788 VA: 0xF7B788
		//public static IEnumerator Co_ShowPopup(Transform parent, AMOCLPHDGBP p, ELBOJBBIBFM onPurchase, JFDNPFFOACP onCancel, DJBHIFLHJLK onError, OnDenomChangeDate onChangeDate, ProductListFilter filter) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D802C Offset: 0x6D802C VA: 0x6D802C
		//// RVA: 0xF7B8D4 Offset: 0xF7B8D4 VA: 0xF7B8D4
		public static IEnumerator Co_ClosePopup(Action onClosed)
		{
			//0xF7E8D0
			if(sm_Control != null)
			{
				bool is_close = false;
				sm_Control.Close(() =>
				{
					//0xF7E3F0
					sm_Control = null;
					is_close = true;
				}, null);
				yield return new WaitWhile(() =>
				{
					//0xF7E48C
					return !is_close;
				});
			}
			if(onClosed != null)
				onClosed();
		}

		//// RVA: 0xF7B980 Offset: 0xF7B980 VA: 0xF7B980
		public static void OnProcessingEnd()
		{
			TodoLogger.LogError(0, "OnProcessingEnd");
		}

		//// RVA: 0xF7BBB0 Offset: 0xF7BBB0 VA: 0xF7BBB0
		//private void FinishBuying() { }

		// RVA: 0xF7BCFC Offset: 0xF7BCFC VA: 0xF7BCFC Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			TodoLogger.LogError(0, "Initialize");
		}

		// RVA: 0xF7BF00 Offset: 0xF7BF00 VA: 0xF7BF00
		public void OnDestroy()
		{
			sm_Setting = null;
			sm_Control = null;
			m_control = null;
		}

		//// RVA: 0xF7BFB0 Offset: 0xF7BFB0 VA: 0xF7BFB0
		//private void Setup() { }

		//// RVA: 0xF7C15C Offset: 0xF7C15C VA: 0xF7C15C
		//private void SetupScrollContent() { }

		//// RVA: 0xF7C738 Offset: 0xF7C738 VA: 0xF7C738
		//private void SetupObject(GameObject obj, RectTransform parent, float pos) { }

		// RVA: 0xF7C980 Offset: 0xF7C980 VA: 0xF7C980 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0xF7C988 Offset: 0xF7C988 VA: 0xF7C988 Slot: 19
		public void Show()
		{
			TodoLogger.LogError(0, "Show");
		}

		// RVA: 0xF7C9CC Offset: 0xF7C9CC VA: 0xF7C9CC Slot: 20
		public void Hide()
		{
			TodoLogger.LogError(0, "Hide");
		}

		// RVA: 0xF7CBD4 Offset: 0xF7CBD4 VA: 0xF7CBD4 Slot: 21
		public bool IsReady()
		{
			TodoLogger.LogError(0, "IsReady");
			return true;
		}

		// RVA: 0xF7CC58 Offset: 0xF7CC58 VA: 0xF7CC58 Slot: 22
		public void CallOpenEnd()
		{
			TodoLogger.LogError(0, "CallOpenEnd");
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D80A4 Offset: 0x6D80A4 VA: 0x6D80A4
		//// RVA: 0xF7CC7C Offset: 0xF7CC7C VA: 0xF7CC7C
		//private IEnumerator Co_ShowTutorial() { }

		//// RVA: 0xF7CD28 Offset: 0xF7CD28 VA: 0xF7CD28
		//private bool CheckGameResultTutorialCondition(TutorialConditionId conditionId) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D811C Offset: 0x6D811C VA: 0x6D811C
		//// RVA: 0xF7CD38 Offset: 0xF7CD38 VA: 0xF7CD38
		//private IEnumerator Co_OnClickBuyButton(int index) { }

		//// RVA: 0xF7CE00 Offset: 0xF7CE00 VA: 0xF7CE00
		//private static void ApplyProductFilter(List<LGDNAJACFHI> list, AMOCLPHDGBP paidVcPurchase) { }

		//// RVA: 0xF7D120 Offset: 0xF7D120 VA: 0xF7D120
		//private void OnClickInfoButton(int index) { }

		//// RVA: 0xF7D4A0 Offset: 0xF7D4A0 VA: 0xF7D4A0
		//public static void ChangeDate(TransitionList.Type type) { }

		//// RVA: 0xF7D694 Offset: 0xF7D694 VA: 0xF7D694
		//private void OnChangeDate(TransitionList.Type type) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D8194 Offset: 0x6D8194 VA: 0x6D8194
		//// RVA: 0xF7D808 Offset: 0xF7D808 VA: 0xF7D808
		//private IEnumerator Co_CheckChangeDate(Action<TransitionList.Type> onFinished) { }

		//// RVA: 0xF7D8B4 Offset: 0xF7D8B4 VA: 0xF7D8B4
		//private void OnClickSCTL() { }

		//// RVA: 0xF7DB40 Offset: 0xF7DB40 VA: 0xF7DB40
		//private void OnClickPSA() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D820C Offset: 0x6D820C VA: 0x6D820C
		//// RVA: 0xF7DE5C Offset: 0xF7DE5C VA: 0xF7DE5C
		//private void <OnClickSCTL>b__37_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D821C Offset: 0x6D821C VA: 0x6D821C
		//// RVA: 0xF7DF28 Offset: 0xF7DF28 VA: 0xF7DF28
		//private void <OnClickPSA>b__38_0() { }
	}
}
