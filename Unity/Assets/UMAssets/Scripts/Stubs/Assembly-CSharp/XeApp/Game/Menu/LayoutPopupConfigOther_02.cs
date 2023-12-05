using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using XeSys.Gfx;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigOther_02 : LayoutPopupConfigBase
	{
		[SerializeField]
		private Text m_title; // 0x38
		[SerializeField]
		private Text m_desc2; // 0x3C
		[SerializeField]
		private Text m_desc4; // 0x40
		[SerializeField]
		private ToggleButtonGroup m_toggleGroup; // 0x44
		private AbsoluteLayout m_layout; // 0x48

		// RVA: 0x1EC9074 Offset: 0x1EC9074 VA: 0x1EC9074 Slot: 6
		public override int GetContentsHeight()
		{
			return 179;
		}

		// RVA: 0x1EC907C Offset: 0x1EC907C VA: 0x1EC907C Slot: 7
		public override bool IsShow()
		{
			return true;
		}

		// RVA: 0x1EC9084 Offset: 0x1EC9084 VA: 0x1EC9084 Slot: 8
		public override void SetStatus(ScrollRect scroll)
		{
			base.SetStatus(scroll);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			SetTextTitle(bk.GetMessageByLabel("config_text_04"));
			m_layout.StartChildrenAnimGoStop("01");
			SetTextDesc(bk.GetMessageByLabel("config_text_05_android"));
			SetSelectToggleButton(m_toggleGroup, ConfigManager.Instance.Option.CJFAJNMADBA_ScreenRotation);
		}

		//// RVA: 0x1EC9220 Offset: 0x1EC9220 VA: 0x1EC9220
		public void SetTextTitle(string text)
		{
			if (m_title != null)
				m_title.text = text;
		}

		//// RVA: 0x1EC92E0 Offset: 0x1EC92E0 VA: 0x1EC92E0
		public void SetTextDesc(string text)
		{
			if (m_desc2 != null)
				m_desc2.text = text;
			if (m_desc4 != null)
				m_desc4.text = text;
		}

		// RVA: 0x1EC9410 Offset: 0x1EC9410 VA: 0x1EC9410 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			SetCallbackToggleButton(m_toggleGroup, (int value) =>
			{
				//0x1EC9540
				ConfigUtility.PlaySeToggleButton();
				ConfigManager.Instance.SetOrientation(value);
			});
			m_layout = layout.FindViewById("swtbl_other_set") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
