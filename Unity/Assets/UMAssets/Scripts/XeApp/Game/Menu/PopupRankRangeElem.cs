using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopupRankRangeElem : SwapScrollListContent
	{
		[SerializeField]
		private Text m_label; // 0x20
		[SerializeField]
		private ActionButton m_button; // 0x24

		public int elemIndex { get; set; } // 0x28

		//// RVA: 0x1618700 Offset: 0x1618700 VA: 0x1618700
		public void SetLabel(string label)
		{
			m_label.text = label;
		}

		//// RVA: 0x161873C Offset: 0x161873C VA: 0x161873C
		public void SetButtonLock(bool isLock)
		{
			m_button.IsInputOff = isLock;
		}

		//// RVA: 0x1618770 Offset: 0x1618770 VA: 0x1618770
		public void SetButtonOn()
		{
			m_button.SetOn();
		}

		//// RVA: 0x16187A4 Offset: 0x16187A4 VA: 0x16187A4
		public void SetButtonOff()
		{
			m_button.SetOff();
		}

		// RVA: 0x1619BF4 Offset: 0x1619BF4 VA: 0x1619BF4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_button.ClearOnClickCallback();
			m_button.AddOnClickCallback(() =>
			{
				//0x1619CF0
				ClickButton.Invoke(0, this);
			});
			Loaded();
			return true;
		}
	}
}
