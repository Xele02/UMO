using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Title
{
	public class LayoutTitleTexts : LayoutUGUIScriptBase
	{
		// Fields
		[SerializeField]
		private Text m_version; // 0x14
		[SerializeField]
		private Text m_id; // 0x18

		// Methods

		// // RVA: 0xE3B004 Offset: 0xE3B004 VA: 0xE3B004
		public void SetStatus()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xE3B150 Offset: 0xE3B150 VA: 0xE3B150
		// public void SetTextVersion(string text) { }

		// // RVA: 0xE3B210 Offset: 0xE3B210 VA: 0xE3B210
		// public void SetTextID(string text) { }

		// // RVA: 0xE3B2D0 Offset: 0xE3B2D0 VA: 0xE3B2D0
		// public void Reset() { }

		// // RVA: 0xE3B2D4 Offset: 0xE3B2D4 VA: 0xE3B2D4
		// public void Show() { }

		// // RVA: 0xE3B2D8 Offset: 0xE3B2D8 VA: 0xE3B2D8
		// public void Hide() { }

		// // RVA: 0xE3B2DC Offset: 0xE3B2DC VA: 0xE3B2DC Slot: 5
		// public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan) { }

		// // RVA: 0xE3B2F4 Offset: 0xE3B2F4 VA: 0xE3B2F4
		// public void .ctor() { }
	}
}
