using XeSys.Gfx;
using System.Collections.Generic;
using XeApp.Game.Common;
using UnityEngine;
using System;

namespace XeApp.Game.Menu
{
	public class LayoutSeriesTab : LayoutUGUIScriptBase
	{
		private static readonly SeriesAttr.Type[] s_SeriesButtonIndex = new SeriesAttr.Type[5]
		{
			SeriesAttr.Type.First,
			SeriesAttr.Type.Seven,
			SeriesAttr.Type.Frontia,
			SeriesAttr.Type.Delta,
			SeriesAttr.Type.Plus
		}; // 0x0
		[SerializeField]
		private List<ActionButton> m_SeriesButtons = new List<ActionButton>(); // 0x14
		[SerializeField]
		private List<RawImageEx> m_LogoImages = new List<RawImageEx>(); // 0x18
		private AbsoluteLayout m_SeriesBtnAnim; // 0x1C
		private AbsoluteLayout m_SeriesBtnTypeAnim; // 0x20

		// RVA: 0x193E03C Offset: 0x193E03C VA: 0x193E03C
		private void Start()
		{
			return;
		}

		// RVA: 0x193E040 Offset: 0x193E040 VA: 0x193E040
		private void Update()
		{
			return;
		}

		// // RVA: 0x193E044 Offset: 0x193E044 VA: 0x193E044
		public void SetSeriesButtonCallBack(Action<SeriesAttr.Type> action)
		{
			for(int i = 0; i < m_SeriesButtons.Count; i++)
			{
				int index = i;
				m_SeriesButtons[i].AddOnClickCallback(() => {
					//0x193F168
					action.Invoke(s_SeriesButtonIndex[index]);
				});
			}
		}

		// // RVA: 0x193E214 Offset: 0x193E214 VA: 0x193E214
		// public void ApplySelectSeriesButton(int SelectSeries) { }

		// // RVA: 0x193E4BC Offset: 0x193E4BC VA: 0x193E4BC
		// public void ChangeSelectSeries(int _type, ref int SelectSeries, ref int Select) { }

		// // RVA: 0x193E524 Offset: 0x193E524 VA: 0x193E524
		// private int ConvertSeriesAttrIndex(SeriesAttr.Type type) { }

		// // RVA: 0x193E66C Offset: 0x193E66C VA: 0x193E66C
		public void SetSeriesIcon()
		{
			for(int i = 0; i < m_LogoImages.Count; i++)
			{
				m_LogoImages[i].enabled = false;
				int index = i;
				MenuScene.Instance.InputDisable();
				MenuScene.Instance.MenuResidentTextureCache.LoadLogo(s_SeriesButtonIndex[i] == SeriesAttr.Type.Plus ? 11 : (int)s_SeriesButtonIndex[i], (IiconTexture texture) => {
					//0x193EF80
					texture.Set(m_LogoImages[index]);
					m_LogoImages[index].enabled = true;
					MenuScene.Instance.InputEnable();
				});
			}
		}

		// // RVA: 0x193E98C Offset: 0x193E98C VA: 0x193E98C
		// public void Enter() { }

		// // RVA: 0x193EA18 Offset: 0x193EA18 VA: 0x193EA18
		// public void Show() { }

		// // RVA: 0x193EA1C Offset: 0x193EA1C VA: 0x193EA1C
		// public void Leave() { }

		// // RVA: 0x193EAA8 Offset: 0x193EAA8 VA: 0x193EAA8
		// public void ButtonDisable(int seriesIndex, bool IsDisable) { }

		// // RVA: 0x193EBCC Offset: 0x193EBCC VA: 0x193EBCC
		// public bool IsPlaying() { }

		// RVA: 0x193ECE4 Offset: 0x193ECE4 VA: 0x193ECE4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_SeriesBtnAnim = layout.FindViewByExId("root_sel_val_btn_sw_sel_val_btn_01") as AbsoluteLayout;
			m_SeriesBtnTypeAnim = layout.FindViewByExId("sw_sel_val_btn_01_anim_swtbl_sel_val_btn_logo") as AbsoluteLayout;
			return true;
		}
	}
}
