using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutSNSUnopened : LayoutSNSBase
	{
		[SerializeField]
		private Text m_title; // 0x14
		[SerializeField]
		private Text m_text; // 0x18
		private AbsoluteLayout m_root; // 0x1C
		private RectTransform m_rootRt; // 0x20
		public bool IsOpen { get; private set; } // 0x24

		//// RVA: 0x193D9A0 Offset: 0x193D9A0 VA: 0x193D9A0
		//public void SetTitle(string text) { }

		//// RVA: 0x193DA64 Offset: 0x193DA64 VA: 0x193DA64
		//public void SetText(string text) { }

		//// RVA: 0x193DB28 Offset: 0x193DB28 VA: 0x193DB28 Slot: 7
		//public override void SetPosition(float pos_x, float pos_y) { }

		//// RVA: 0x193DBB4 Offset: 0x193DBB4 VA: 0x193DBB4 Slot: 8
		//public override void Show() { }

		// RVA: 0x193DC84 Offset: 0x193DC84 VA: 0x193DC84 Slot: 9
		public override void Hide()
		{
			if(m_root != null && IsOpen)
			{
				IsOpen = false;
				m_root.StartChildrenAnimGoStop("st_wait", "st_wait");
			}
		}

		//// RVA: 0x193DD0C Offset: 0x193DD0C VA: 0x193DD0C Slot: 10
		//public override void In() { }

		//// RVA: 0x193DDEC Offset: 0x193DDEC VA: 0x193DDEC Slot: 11
		//public override void Out() { }

		//// RVA: 0x193DE80 Offset: 0x193DE80 VA: 0x193DE80 Slot: 12
		public override bool IsPlaying()
		{
			if (m_root != null)
				return m_root.IsPlayingChildren();
			return false;
		}

		//// RVA: 0x193DE98 Offset: 0x193DE98 VA: 0x193DE98 Slot: 13
		//public override void SetStatus(SNSTalkCreater.ViewTalk talk) { }

		// RVA: 0x193DEFC Offset: 0x193DEFC VA: 0x193DEFC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.Root[0] as AbsoluteLayout;
			m_rootRt = GetComponent<RectTransform>();
			m_root.StartAllAnimGoStop("st_wait");
			Loaded();
			return true;
		}
	}
}
