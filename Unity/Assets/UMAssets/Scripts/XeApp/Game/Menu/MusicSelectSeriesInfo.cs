using XeSys.Gfx;
using System.Collections.Generic;
using UnityEngine;
using System;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class MusicSelectSeriesInfo : LayoutLabelScriptBase
	{
		// private static readonly FreeCategoryId.Type[] s_buttonIndexToSeries = new FreeCategoryId.Type[6] {
		// 	1, 2, 3, 4, 6, 5
		// }; // 0x0
		[SerializeField]
		private List<MusicSelectSeriesButton> m_seriesButtons; // 0x18
		// private LayoutSymbolData m_symbolMain; // 0x1C
		// private LayoutSymbolData m_symbolSeriesTab; // 0x20
		// private FreeCategoryId.Type m_selectedCategoryId; // 0x24
		// private bool m_isShow; // 0x28

		public Action<FreeCategoryId.Type> onChangedSeries { private get; set; } // 0x2C

		// // RVA: 0xF52C24 Offset: 0xF52C24 VA: 0xF52C24
		// public void TryEnter() { }

		// // RVA: 0xF52CB8 Offset: 0xF52CB8 VA: 0xF52CB8
		public void TryLeave()
		{
			UnityEngine.Debug.LogError("TODO MusicSelectSeriesInfo TryLeave");
		}

		// // RVA: 0xF52C34 Offset: 0xF52C34 VA: 0xF52C34
		public void Enter()
		{
			UnityEngine.Debug.LogError("TODO MusicSelectSeriesInfo Enter");
		}

		// // RVA: 0xF52CC8 Offset: 0xF52CC8 VA: 0xF52CC8
		// public void Leave() { }

		// // RVA: 0xF52D4C Offset: 0xF52D4C VA: 0xF52D4C
		// public void Show() { }

		// // RVA: 0xF52DD0 Offset: 0xF52DD0 VA: 0xF52DD0
		// public void Hide() { }

		// // RVA: 0xF390A4 Offset: 0xF390A4 VA: 0xF390A4
		public bool IsPlaying()
		{
			UnityEngine.Debug.LogError("TODO MusicSelectSeriesInfo IsPlaying");
			return false;
		}

		// // RVA: 0xF52E54 Offset: 0xF52E54 VA: 0xF52E54
		// public void ChangeSelectedTab(FreeCategoryId.Type categoryId, bool immediate = False) { }

		// // RVA: 0xF53124 Offset: 0xF53124 VA: 0xF53124
		// public void ResetLockTabs() { }

		// // RVA: 0xF5332C Offset: 0xF5332C VA: 0xF5332C
		// public void SetTabNew(FreeCategoryId.Type categoryId, bool isNew) { }

		// // RVA: 0xF534D4 Offset: 0xF534D4 VA: 0xF534D4
		// private void OnClickSeriesButton(int index) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F52B4 Offset: 0x6F52B4 VA: 0x6F52B4
		// // RVA: 0xF535C0 Offset: 0xF535C0 VA: 0xF535C0
		// private IEnumerator Co_Initialize() { }

		// // RVA: 0xF5366C Offset: 0xF5366C VA: 0xF5366C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			UnityEngine.Debug.LogError("TODO InitializeFromLayout MusicSelectSeriesInfo");
			return true;
		}
	}
}
