using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutSNSHeadline : LayoutSNSBase
	{
		[SerializeField]
		private Text m_text; // 0x14
		private RectTransform m_rootRt; // 0x18
		private AbsoluteLayout m_root; // 0x1C

		//// RVA: 0x1932768 Offset: 0x1932768 VA: 0x1932768 Slot: 13
		//public override void SetStatus(SNSTalkCreater.ViewTalk viewTalk) { }

		//// RVA: 0x1932870 Offset: 0x1932870 VA: 0x1932870 Slot: 7
		//public override void SetPosition(float pos_x, float pos_y) { }

		//// RVA: 0x19327AC Offset: 0x19327AC VA: 0x19327AC
		public void SetText(string text)
		{
			if (m_text != null)
				m_text.text = text;
		}

		// RVA: 0x1932958 Offset: 0x1932958 VA: 0x1932958
		public void Reset()
		{
			return;
		}

		//// RVA: 0x193295C Offset: 0x193295C VA: 0x193295C Slot: 12
		public override bool IsPlaying()
		{
			if (m_root != null)
				return m_root.IsPlayingChildren();
			return false;
		}

		//// RVA: 0x1932974 Offset: 0x1932974 VA: 0x1932974
		//private bool IsPlayingAnim() { }

		//// RVA: 0x193298C Offset: 0x193298C VA: 0x193298C Slot: 10
		//public override void In() { }

		//// RVA: 0x1932A54 Offset: 0x1932A54 VA: 0x1932A54 Slot: 11
		//public override void Out() { }

		//// RVA: 0x1932AD4 Offset: 0x1932AD4 VA: 0x1932AD4 Slot: 8
		//public override void Show() { }

		// RVA: 0x1932B84 Offset: 0x1932B84 VA: 0x1932B84 Slot: 9
		public override void Hide()
		{
			m_root.StartChildrenAnimGoStop("st_out", "st_out");
			gameObject.SetActive(false);
		}

		// RVA: 0x1932C34 Offset: 0x1932C34 VA: 0x1932C34 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_rootRt = GetComponent<RectTransform>();
			m_root = layout.Root[0] as AbsoluteLayout;
			m_root.StartChildrenAnimGoStop("st_wait");
			SetText("");
			Loaded();
			return true;
		}
	}
}
