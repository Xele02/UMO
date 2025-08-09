using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutQuestPopupMissionSettingWindow : LayoutUGUIScriptBase
	{
		public enum SelectType
		{
			Random = 1,
			PrevMusic = 0,
		}

		[SerializeField]
		private Text[] m_btnText = new Text[2]; // 0x14
		[SerializeField]
		private Text m_musicSettingText; // 0x18
		[SerializeField]
		private Text m_Info1; // 0x1C
		[SerializeField]
		private Text m_Info2; // 0x20
		[SerializeField]
		private Text m_Info3; // 0x24
		[SerializeField]
		private ToggleButton[] m_toggleButtons; // 0x28
		[SerializeField]
		private ToggleButtonGroup m_toggleButtonGrp; // 0x2C
		private AbsoluteLayout[] m_btnAnim = new AbsoluteLayout[2]; // 0x30
		private SelectType m_select_btn = SelectType.Random; // 0x34

		// RVA: 0x187C83C Offset: 0x187C83C VA: 0x187C83C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_toggleButtonGrp.OnSelectToggleButtonEvent.AddListener(OnClickBtn);
			Loaded();
			return true;
		}

		// RVA: 0x187C288 Offset: 0x187C288 VA: 0x187C288
		public void Setup(SelectType defaultButton)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_musicSettingText.text = bk.GetMessageByLabel("event_mission_setting_desc_001");
			m_Info1.text = bk.GetMessageByLabel("event_mission_setting_desc_002");
			m_Info2.text = bk.GetMessageByLabel("event_mission_setting_desc_003");
			m_Info3.text = bk.GetMessageByLabel("event_mission_setting_desc_006");
			m_btnText[0].text = bk.GetMessageByLabel("event_mission_setting_desc_004");
			m_btnText[1].text = bk.GetMessageByLabel("event_mission_setting_desc_005");
			m_toggleButtonGrp.SelectGroupButton((int)defaultButton);
			m_select_btn = defaultButton;
		}

		// // RVA: 0x187C92C Offset: 0x187C92C VA: 0x187C92C
		private void OnClickBtn(int index)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			m_select_btn = (SelectType)index;
		}

		// // RVA: 0x187C600 Offset: 0x187C600 VA: 0x187C600
		public bool IsPrevSelectMusic()
		{
			return m_select_btn == SelectType.PrevMusic;
		}
	}
}
