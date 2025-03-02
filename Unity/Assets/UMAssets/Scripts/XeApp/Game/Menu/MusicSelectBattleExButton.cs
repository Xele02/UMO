using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;

namespace XeApp.Game.Menu
{
	public class MusicSelectBattleExButton : LayoutLabelScriptBase
	{
		[SerializeField]
		private ActionButton m_buttonReSelect; // 0x18
		[SerializeField]
		private ActionButton m_buttonHiScore; // 0x1C
		private LayoutSymbolData m_symbolMain; // 0x20
		private bool m_isShow; // 0x2C

		public Action onClickReSelect { private get; set; } // 0x24
		public Action onClickHiScore { private get; set; } // 0x28

		// RVA: 0x1055A30 Offset: 0x1055A30 VA: 0x1055A30
		public void TryEnter()
		{
			if(!m_isShow)
				Enter();
		}

		// RVA: 0x1055AC4 Offset: 0x1055AC4 VA: 0x1055AC4
		public void TryLeave()
		{
			if(m_isShow)
				Leave();
		}

		// // RVA: 0x1055A40 Offset: 0x1055A40 VA: 0x1055A40
		public void Enter()
		{
			m_isShow = true;
			m_symbolMain.StartAnim("enter");
		}

		// // RVA: 0x1055AD4 Offset: 0x1055AD4 VA: 0x1055AD4
		public void Leave()
		{
			m_isShow = false;
			m_symbolMain.StartAnim("leave");
		}

		// // RVA: 0x1055B58 Offset: 0x1055B58 VA: 0x1055B58
		// public void Show() { }

		// // RVA: 0x1055BDC Offset: 0x1055BDC VA: 0x1055BDC
		// public void Hide() { }

		// RVA: 0x1055C60 Offset: 0x1055C60 VA: 0x1055C60
		public bool IsPlaying()
		{
			return m_symbolMain.IsPlaying();
		}

		// RVA: 0x1055C8C Offset: 0x1055C8C VA: 0x1055C8C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_symbolMain = CreateSymbol("main", layout);
			m_symbolMain.StartAnim("wait");
			m_buttonReSelect.AddOnClickCallback(() =>
			{
				//0x1055E00
				if(onClickReSelect != null)
					onClickReSelect();
			});
			m_buttonHiScore.AddOnClickCallback(() =>
			{
				//0x1055E14
				if(onClickHiScore != null)
					onClickHiScore();
			});
			Loaded();
			return true;
		}
	}
}
