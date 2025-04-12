using XeSys.Gfx;
using System.Collections.Generic;
using UnityEngine;
using System;
using XeApp.Game.Common;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class MusicSelectSeriesInfo : LayoutLabelScriptBase
	{
		private static readonly FreeCategoryId.Type[] s_buttonIndexToSeries = new FreeCategoryId.Type[6] {
			FreeCategoryId.Type.Macross, 
			FreeCategoryId.Type.Seven,
			FreeCategoryId.Type.Frontia,
			FreeCategoryId.Type.Delta,
			FreeCategoryId.Type.Other,
			FreeCategoryId.Type.Event
		}; // 0x0
		[SerializeField]
		private List<MusicSelectSeriesButton> m_seriesButtons; // 0x18
		private LayoutSymbolData m_symbolMain; // 0x1C
		private LayoutSymbolData m_symbolSeriesTab; // 0x20
		private FreeCategoryId.Type m_selectedCategoryId; // 0x24
		private bool m_isShow; // 0x28

		public Action<FreeCategoryId.Type> onChangedSeries { private get; set; } // 0x2C

		// // RVA: 0xF52C24 Offset: 0xF52C24 VA: 0xF52C24
		public void TryEnter()
		{
			if(!m_isShow)
				Enter();
		}

		// // RVA: 0xF52CB8 Offset: 0xF52CB8 VA: 0xF52CB8
		public void TryLeave()
		{
			if(m_isShow)
				Leave();
		}

		// // RVA: 0xF52C34 Offset: 0xF52C34 VA: 0xF52C34
		public void Enter()
		{
			m_isShow = true;
			m_symbolMain.StartAnim("enter");
		}

		// // RVA: 0xF52CC8 Offset: 0xF52CC8 VA: 0xF52CC8
		public void Leave()
		{
			m_isShow = false;
			m_symbolMain.StartAnim("leave");
		}

		// // RVA: 0xF52D4C Offset: 0xF52D4C VA: 0xF52D4C
		// public void Show() { }

		// // RVA: 0xF52DD0 Offset: 0xF52DD0 VA: 0xF52DD0
		public void Hide()
		{
			m_isShow = false;
			m_symbolMain.StartAnim("wait");
		}

		// // RVA: 0xF390A4 Offset: 0xF390A4 VA: 0xF390A4
		public bool IsPlaying()
		{
			for(int i = 0; i < m_seriesButtons.Count; i++)
			{
				if(m_seriesButtons[i].IsPlaying())
					return true;
			}
			return m_symbolMain.IsPlaying();
		}

		// // RVA: 0xF52E54 Offset: 0xF52E54 VA: 0xF52E54
		public void ChangeSelectedTab(FreeCategoryId.Type categoryId, bool immediate/* = False*/)
		{
			for(int i = 0; i < s_buttonIndexToSeries.Length; i++)
			{
				if(s_buttonIndexToSeries[i] == categoryId)
				{
					int frame = i;
					if(categoryId == FreeCategoryId.Type.Other)
						frame = 4;
					if(categoryId == FreeCategoryId.Type.Event)
						frame = 5;
					m_symbolSeriesTab.GoToFrame("index", frame);
					if(immediate)
					{
						m_seriesButtons[i].enabled = false;
						m_seriesButtons[i].SetOn();
					}
					else
					{
						m_seriesButtons[i].IsInputOff = true;
					}
				}
				else
				{
					m_seriesButtons[i].enabled = true;
					m_seriesButtons[i].IsInputOff = false;
					m_seriesButtons[i].SetOff();
				}
			}
			m_selectedCategoryId = categoryId;
		}

		// // RVA: 0xF53124 Offset: 0xF53124 VA: 0xF53124
		public void ResetLockTabs()
		{
			for(int i = 0; i < s_buttonIndexToSeries.Length; i++)
			{
				if(m_selectedCategoryId == s_buttonIndexToSeries[i])
				{
					m_seriesButtons[i].enabled = false;
					m_seriesButtons[i].SetOn();
				}
				else
				{
					m_seriesButtons[i].enabled = true;
					m_seriesButtons[i].SetOff();
				}
			}
		}

		// // RVA: 0xF5332C Offset: 0xF5332C VA: 0xF5332C
		// public void SetTabNew(FreeCategoryId.Type categoryId, bool isNew) { }

		// // RVA: 0xF534D4 Offset: 0xF534D4 VA: 0xF534D4
		private void OnClickSeriesButton(int index)
		{
			if(onChangedSeries != null)
				onChangedSeries(s_buttonIndexToSeries[index]);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F52B4 Offset: 0x6F52B4 VA: 0x6F52B4
		// // RVA: 0xF535C0 Offset: 0xF535C0 VA: 0xF535C0
		private IEnumerator Co_Initialize()
		{
			//0xF53948
			yield return null;
			Loaded();
		}

		// // RVA: 0xF5366C Offset: 0xF5366C VA: 0xF5366C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_symbolMain = CreateSymbol("main", layout);
			m_symbolSeriesTab = CreateSymbol("series_tab", layout);
			for(int i = 0; i < m_seriesButtons.Count; i++)
			{
				int tmpIndex = i;
				m_seriesButtons[i].AddOnClickCallback(() =>
				{
					//0xF53914
					OnClickSeriesButton(tmpIndex);
				});
			}
			this.StartCoroutineWatched(Co_Initialize());
			return true;
		}
	}
}
