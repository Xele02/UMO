using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;
using System;
using mcrs;

namespace XeApp.Game.Menu
{
	public class LayoutSNSNextButton : LayoutSNSBase
	{
		[SerializeField]
		private ActionButton m_button; // 0x14
		private AbsoluteLayout m_root; // 0x18
		private RectTransform m_rootRt; // 0x1C

		public Action CallbackButton { get; set; } // 0x20

		//// RVA: 0x1932D98 Offset: 0x1932D98 VA: 0x1932D98 Slot: 7
		//public override void SetPosition(float pos_x, float pos_y) { }

		//// RVA: 0x1932E80 Offset: 0x1932E80 VA: 0x1932E80 Slot: 8
		//public override void Show() { }

		// RVA: 0x1932F38 Offset: 0x1932F38 VA: 0x1932F38 Slot: 9
		public override void Hide()
		{
			if (m_root == null)
				return;
			m_root.StartChildrenAnimGoStop("st_out", "st_out");
			gameObject.SetActive(false);
		}

		//// RVA: 0x1932FDC Offset: 0x1932FDC VA: 0x1932FDC Slot: 10
		//public override void In() { }

		//// RVA: 0x19330A4 Offset: 0x19330A4 VA: 0x19330A4 Slot: 11
		//public override void Out() { }

		//// RVA: 0x1933124 Offset: 0x1933124 VA: 0x1933124 Slot: 12
		public override bool IsPlaying()
		{
			if (m_root != null)
				return m_root.IsPlayingChildren();
			return false;
		}

		//// RVA: 0x193313C Offset: 0x193313C VA: 0x193313C Slot: 13
		//public override void SetStatus(SNSTalkCreater.ViewTalk talk) { }

		// RVA: 0x1933140 Offset: 0x1933140 VA: 0x1933140 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.Root[0] as AbsoluteLayout;
			m_rootRt = GetComponent<RectTransform>();
			if(m_button != null)
			{
				m_button.ClearOnClickCallback();
				m_button.AddOnClickCallback(() =>
				{
					//0x1933314
					if (CallbackButton != null)
						CallbackButton();
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				});
			}
			Loaded();
			return true;
		}
	}
}
