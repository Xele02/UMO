using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class HelpListElemBase : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_labelText; // 0x14
		[SerializeField]
		private ScrollListButton m_selectButton; // 0x18

		//// RVA: 0xE32690 Offset: 0xE32690 VA: 0xE32690
		public void SetLabel(string label)
		{
			m_labelText.text = label;
		}

		// RVA: 0xE326CC Offset: 0xE326CC VA: 0xE326CC
		protected void InvokeSelectItem(int value)
		{
			HelpListContent content = GetComponent<HelpListContent>();
			content.ClickButton.Invoke(value, content);
		}

		// RVA: 0xE3277C Offset: 0xE3277C VA: 0xE3277C
		private void OnClickSelectButton()
		{
			InvokeSelectItem(0);
		}

		// RVA: 0xE32784 Offset: 0xE32784 VA: 0xE32784 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_selectButton.ClearOnClickCallback();
			m_selectButton.AddOnClickCallback(OnClickSelectButton);
			Loaded();
			return true;
		}
	}
}
