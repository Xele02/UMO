using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class RaidBossHelpWindow : LayoutUGUIScriptBase
	{
		private enum HelpType
		{
			All = 0,
			Loby = 1,
		}
 
		public enum SelectType
		{
			All = 0,
			Loby = 1,
			LobyPrioFriend = 2,
		}

		[SerializeField]
		private Text m_text01; // 0x14
		[SerializeField]
		private Text m_text02; // 0x18
		[SerializeField]
		private Text m_text03; // 0x1C
		[SerializeField]
		private Text m_text04; // 0x20
		[SerializeField]
		private ToggleButtonGroup m_toggleBtnGroup; // 0x24
		[SerializeField]
		private CheckboxButton m_checkboxButton; // 0x28
		private bool m_IsInialize; // 0x2C
		private bool m_isCheckboxOn; // 0x2D
		private HelpType m_currentHelpType; // 0x30
		private Action<SelectType> onSelectType; // 0x34

		// RVA: 0x145BB90 Offset: 0x145BB90 VA: 0x145BB90 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			return true;
		}

		// RVA: 0x145BBA8 Offset: 0x145BBA8 VA: 0x145BBA8
		public void Initialize(Action<SelectType> _onSelectType)
		{
			PKNOKJNLPOE_EventRaid ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as PKNOKJNLPOE_EventRaid;
			ev.NPICFLFAIJK_GetNumTicket();
			onSelectType = _onSelectType;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_text01.text = bk.GetMessageByLabel("pop_raid_helprequest_loby");
			m_text02.text = bk.GetMessageByLabel("pop_raid_helprequest_friend");
			m_text03.text = bk.GetMessageByLabel("pop_raid_helprequest_all");
			m_text04.text = bk.GetMessageByLabel("pop_raid_helprequest_text");
			m_currentHelpType = HelpType.Loby;
			m_toggleBtnGroup.SelectGroupButton(1);
			m_toggleBtnGroup.OnSelectToggleButtonEvent.AddListener(OnSelectToggleButton);
			m_checkboxButton.AddOnClickCallback(OnClickCheckbox);
			UpdateSelectType();
			m_IsInialize = true;
		}

		// // RVA: 0x145C084 Offset: 0x145C084 VA: 0x145C084
		public void OnClickCheckbox()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			m_isCheckboxOn = m_checkboxButton.IsChecked;
			UpdateSelectType();
		}

		// // RVA: 0x145C10C Offset: 0x145C10C VA: 0x145C10C
		public void OnSelectToggleButton(int value)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			m_currentHelpType = (HelpType)value;
			if(value == 0)
			{
				m_checkboxButton.SetOff();
				m_checkboxButton.Disable = true;
			}
			else
			{
				m_checkboxButton.Disable = false;
				if(m_isCheckboxOn)
				{
					m_checkboxButton.SetOn();
				}
			}
			UpdateSelectType();
		}

		// // RVA: 0x145C214 Offset: 0x145C214 VA: 0x145C214
		// public RaidBossHelpWindow.SelectType GetSelectType() { }

		// // RVA: 0x145BFE4 Offset: 0x145BFE4 VA: 0x145BFE4
		public void UpdateSelectType()
		{
			onSelectType(m_currentHelpType == HelpType.All ? SelectType.All : (m_isCheckboxOn ? SelectType.LobyPrioFriend : SelectType.Loby));
		}
	}
}
