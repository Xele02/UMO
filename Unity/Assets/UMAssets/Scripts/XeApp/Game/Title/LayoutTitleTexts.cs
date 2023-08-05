using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Native;

namespace XeApp.Game.Title
{
	public class LayoutTitleTexts : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_version; // 0x14
		[SerializeField]
		private Text m_id; // 0x18

		// // RVA: 0xE3B004 Offset: 0xE3B004 VA: 0xE3B004
		public void SetStatus()
		{
			SetTextVersion(string.Format("ver {0}", AppInfo.appVersion));
			SetTextID(string.Format("ID {0}", NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId));
		}

		// // RVA: 0xE3B150 Offset: 0xE3B150 VA: 0xE3B150
		public void SetTextVersion(string text)
		{
			if(m_version != null)
			{
				m_version.text = text;
			}
		}

		// // RVA: 0xE3B210 Offset: 0xE3B210 VA: 0xE3B210
		public void SetTextID(string text)
		{
			if (m_id != null)
				m_id.text = text;
		}

		// // RVA: 0xE3B2D0 Offset: 0xE3B2D0 VA: 0xE3B2D0
		// public void Reset() { }

		// // RVA: 0xE3B2D4 Offset: 0xE3B2D4 VA: 0xE3B2D4
		// public void Show() { }

		// // RVA: 0xE3B2D8 Offset: 0xE3B2D8 VA: 0xE3B2D8
		// public void Hide() { }

		// // RVA: 0xE3B2DC Offset: 0xE3B2DC VA: 0xE3B2DC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			return true;
		}
	}
}
