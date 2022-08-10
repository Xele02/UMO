using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutEventGoDivaFeverLimit : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_textRemainTime; // 0x14
		// private bool m_isShown; // 0x18
		// private AbsoluteLayout m_layoutMain; // 0x1C
		// private AbsoluteLayout m_layoutOnOff; // 0x20

		// // RVA: 0x1990978 Offset: 0x1990978 VA: 0x1990978
		// public void Enter() { }

		// // RVA: 0x1990A0C Offset: 0x1990A0C VA: 0x1990A0C
		// public void Leave() { }

		// // RVA: 0x1990AA0 Offset: 0x1990AA0 VA: 0x1990AA0
		public void TryEnter()
		{
			TodoLogger.Log(0, "LayoutEventGoDivaFeverLimit TryEnter");
		}

		// // RVA: 0x1990AB0 Offset: 0x1990AB0 VA: 0x1990AB0
		public void TryLeave()
		{
			TodoLogger.Log(0, "LayoutEventGoDivaFeverLimit TryLeave");
		}

		// // RVA: 0x1990AC0 Offset: 0x1990AC0 VA: 0x1990AC0
		// public void Show() { }

		// // RVA: 0x1990B44 Offset: 0x1990B44 VA: 0x1990B44
		public void Hide()
		{
			TodoLogger.Log(0, "LayoutEventGoDivaFeverLimit Hide");
		}

		// // RVA: 0x1990BC8 Offset: 0x1990BC8 VA: 0x1990BC8
		public bool IsPlaying()
		{
			TodoLogger.Log(0, "LayoutEventGoDivaFeverLimit IsPlaying");
			return false;
		}

		// // RVA: 0x1990BF4 Offset: 0x1990BF4 VA: 0x1990BF4
		public void SetOnOff(bool bOn)
		{
			TodoLogger.Log(0, "LayoutEventGoDivaFeverLimit SetOnOff");
		}

		// // RVA: 0x1990C88 Offset: 0x1990C88 VA: 0x1990C88
		// public void SetLimitText(string text) { }

		// // RVA: 0x1990CC4 Offset: 0x1990CC4 VA: 0x1990CC4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			TodoLogger.Log(0, "InitializeFromLayout LayoutEventGoDivaFeverLimit");
			return true;
		}
	}
}
