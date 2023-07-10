using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using XeSys.Gfx;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigDetailSLive : LayoutPopupConfigDetailBase
	{
		[SerializeField]
		private Text m_title; // 0x14
		[SerializeField]
		private Text m_descDiva3d; // 0x18
		[SerializeField]
		private Text m_descOher3d; // 0x1C
		[SerializeField]
		private ToggleButtonGroup m_toggleGroupDiva3d; // 0x20
		[SerializeField]
		private ToggleButtonGroup m_toggleGroupOher3d; // 0x24
		[SerializeField]
		private ActionButton m_defaultButton; // 0x28

		// RVA: 0x1EC3018 Offset: 0x1EC3018 VA: 0x1EC3018 Slot: 6
		public override void SetStatus()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			SetTextTitle(bk.GetMessageByLabel("config_text_27"));
			SetTextDescDiva3D(bk.GetMessageByLabel("config_text_24"));
			SetToggleButtonDiva3DEnable(ConfigManager.Instance.OptionSLive.HHMCIGLCBNG_QualityCustomDiva3D);
			SetTextOher3D(bk.GetMessageByLabel("config_text_25"));
			SetToggleButtonOher3DEnable(ConfigManager.Instance.Option.AHLFOHJMGAI_QualityCustomOther3D);
		}

		// RVA: 0x1EC3238 Offset: 0x1EC3238 VA: 0x1EC3238 Slot: 7
		public override void SetTextTitle(string text)
		{
			if (m_title != null)
				m_title.text = text;
		}

		// RVA: 0x1EC32F8 Offset: 0x1EC32F8 VA: 0x1EC32F8 Slot: 8
		public override void SetTextOher3D(string text)
		{
			if (m_descOher3d != null)
				m_descOher3d.text = text;
		}

		// RVA: 0x1EC33B8 Offset: 0x1EC33B8 VA: 0x1EC33B8 Slot: 9
		public override void SetToggleButtonOher3DEnable(int index)
		{
			if (m_toggleGroupOher3d != null)
				m_toggleGroupOher3d.SelectGroupButton(index);
		}

		// RVA: 0x1EC3474 Offset: 0x1EC3474 VA: 0x1EC3474 Slot: 12
		public override void SetTextDescDiva3D(string text)
		{
			if (m_descDiva3d != null)
				m_descDiva3d.text = text;
		}

		// RVA: 0x1EC3534 Offset: 0x1EC3534 VA: 0x1EC3534 Slot: 13
		public override void SetToggleButtonDiva3DEnable(int index)
		{
			if(m_toggleGroupDiva3d != null)
			{
				m_toggleGroupDiva3d.SelectGroupButton(index);
			}
		}

		// RVA: 0x1EC35F0 Offset: 0x1EC35F0 VA: 0x1EC35F0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			if(m_defaultButton != null)
			{
				m_defaultButton.AddOnClickCallback(() =>
				{
					//0x1EC38D0
					ConfigManager.Instance.SetQualityCustomDiva3DValue(0, true);
					ConfigManager.Instance.SetQualityCustomOther3DValue(0, true);
					SetToggleButtonDiva3DEnable(0);
					SetToggleButtonOher3DEnable(0);
					ConfigUtility.PlaySeButton();
				});
			}
			SetToggleButtonCallback(m_toggleGroupDiva3d, (int value) =>
			{
				//0x1EC3A48
				ConfigManager.Instance.SetQualityCustomDiva3DValue(value, true);
				ConfigUtility.PlaySeToggleButton();
			});
			SetToggleButtonCallback(m_toggleGroupOher3d, (int value) =>
			{
				//0x1EC3AD8
				ConfigManager.Instance.SetQualityCustomOther3DValue(value, true);
				ConfigUtility.PlaySeToggleButton();
			});
			Loaded();
			return true;
		}
	}
}
