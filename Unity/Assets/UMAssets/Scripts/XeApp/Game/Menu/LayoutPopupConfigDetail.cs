using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using XeSys.Gfx;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigDetail : LayoutPopupConfigDetailBase
	{
		[SerializeField]
		private Text m_title; // 0x14
		[SerializeField]
		private Text m_descDiva3d; // 0x18
		[SerializeField]
		private Text m_descOher3d; // 0x1C
		[SerializeField]
		private Text m_desc2d; // 0x20
		[SerializeField]
		private ToggleButtonGroup m_toggleGroupDiva3d; // 0x24
		[SerializeField]
		private ToggleButtonGroup m_toggleGroupOher3d; // 0x28
		[SerializeField]
		private ToggleButtonGroup m_toggleGroup2d; // 0x2C
		[SerializeField]
		private ActionButton m_defaultButton; // 0x30

		// RVA: 0x1EC1F7C Offset: 0x1EC1F7C VA: 0x1EC1F7C Slot: 6
		public override void SetStatus()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			SetTextTitle(bk.GetMessageByLabel("config_text_27"));
			SetTextDescDiva3D(bk.GetMessageByLabel("config_text_24"));
			SetToggleButtonDiva3DEnable(ConfigManager.Instance.Option.HHMCIGLCBNG_QualityCustomDiva3D);
			SetTextOher3D(bk.GetMessageByLabel("config_text_25"));
			SetToggleButtonOher3DEnable(ConfigManager.Instance.Option.AHLFOHJMGAI_QualityCustomOther3D);
			SetTextDesc2d(bk.GetMessageByLabel("config_text_26"));
			SetToggleButton2DEnable(ConfigManager.Instance.Option.FPJHOLMLDGC_QualityCustom2D);
		}

		//// RVA: 0x1EC2240 Offset: 0x1EC2240 VA: 0x1EC2240 Slot: 7
		public override void SetTextTitle(string text)
		{
			if(m_title != null)
			{
				m_title.text = text;
			}
		}

		//// RVA: 0x1EC2300 Offset: 0x1EC2300 VA: 0x1EC2300 Slot: 8
		public override void SetTextOher3D(string text)
		{
			if(m_descOher3d != null)
			{
				m_descOher3d.text = text;
			}
		}

		//// RVA: 0x1EC23C0 Offset: 0x1EC23C0 VA: 0x1EC23C0 Slot: 9
		public override void SetToggleButtonOher3DEnable(int index)
		{
			if(m_toggleGroupOher3d != null)
			{
				m_toggleGroupOher3d.SelectGroupButton(index);
			}
		}

		//// RVA: 0x1EC247C Offset: 0x1EC247C VA: 0x1EC247C Slot: 10
		public override void SetTextDesc2d(string text)
		{
			if(m_desc2d != null)
			{
				m_desc2d.text = text;
			}
		}

		//// RVA: 0x1EC253C Offset: 0x1EC253C VA: 0x1EC253C Slot: 11
		public override void SetToggleButton2DEnable(int index)
		{
			if(m_toggleGroup2d != null)
			{
				m_toggleGroup2d.SelectGroupButton(index);
			}
		}

		//// RVA: 0x1EC25F8 Offset: 0x1EC25F8 VA: 0x1EC25F8 Slot: 12
		public override void SetTextDescDiva3D(string text)
		{
			if(m_descDiva3d != null)
			{
				m_descDiva3d.text = text;
			}
		}

		//// RVA: 0x1EC26B8 Offset: 0x1EC26B8 VA: 0x1EC26B8 Slot: 13
		public override void SetToggleButtonDiva3DEnable(int index)
		{
			if(m_toggleGroupDiva3d != null)
			{
				m_toggleGroupDiva3d.SelectGroupButton(index);
			}
		}

		// RVA: 0x1EC2774 Offset: 0x1EC2774 VA: 0x1EC2774 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			if(m_defaultButton != null)
			{
				m_defaultButton.AddOnClickCallback(() =>
				{
					//0x1EC2C28
					ConfigManager.Instance.SetQualityCustomDiva3DValue(0, false);
					ConfigManager.Instance.SetQualityCustomOther3DValue(0, false);
					ConfigManager.Instance.SetQualityCustom2DValue(1);
					SetToggleButtonDiva3DEnable(0);
					SetToggleButtonOher3DEnable(0);
					SetToggleButton2DEnable(0);
					ConfigUtility.PlaySeButton();
				});
			}
			SetToggleButtonCallback(m_toggleGroupDiva3d, (int value) =>
			{
				//0x1EC2DF0
				ConfigManager.Instance.SetQualityCustomDiva3DValue(value, false);
			});
			SetToggleButtonCallback(m_toggleGroupOher3d, (int value) =>
			{
				//0x1EC2E80
				ConfigManager.Instance.SetQualityCustomOther3DValue(value, false);
			});
			SetToggleButtonCallback(m_toggleGroup2d, (int value) =>
			{
				//0x1EC2F10
				ConfigManager.Instance.SetQualityCustom2DValue(value);
				ConfigUtility.PlaySeToggleButton();
			});
			Loaded();
			return true;
		}
	}
}
