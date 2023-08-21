using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System;
using mcrs;
using XeSys;

namespace XeApp.Game.Menu
{
	public class SNSTitleBar : LayoutUGUIScriptBase
	{
		public enum eButtonType
		{
			None = 0,
			Default = 1,
			Room = 2,
			Tutorial = 3,
			Adventure = 4,
		}
		
		[SerializeField]
		private ActionButton m_backButton; // 0x14
		[SerializeField]
		private ActionButton m_exitButton; // 0x18
		[SerializeField]
		private ActionButton m_nextButton; // 0x1C
		[SerializeField]
		private ActionButton m_prevButton; // 0x20
		[SerializeField]
		private ActionButton m_newTalkButton; // 0x24
		[SerializeField]
		private ActionButton m_pushLButton; // 0x28
		[SerializeField]
		private ActionButton m_pushRButton; // 0x2C
		[SerializeField]
		private Text m_roomName; // 0x30
		[SerializeField]
		private Text m_roomEntranceName; // 0x34
		private AbsoluteLayout m_newTalkAnim; // 0x38
		private AbsoluteLayout m_root; // 0x3C
		private AbsoluteLayout m_logIcon; // 0x40
		private AbsoluteLayout m_titleTbl; // 0x44
		private AbsoluteLayout m_buttonLLayout; // 0x48
		private AbsoluteLayout m_buttonRLayout; // 0x4C
		private AbsoluteLayout m_buttonReturnLayout; // 0x50
		private AbsoluteLayout m_buttonExitLayout; // 0x54
		private bool m_isNewTalkIconEnter; // 0x58
		private LayoutUGUIHitOnly m_pushLHitOnly; // 0x5C
		private LayoutUGUIHitOnly m_pushRHitOnly; // 0x60

		//public bool IsEnableBackButton { get; } 0x159032C
		//public bool IsEnableExitButton { get; } 0x159035C
		public Action CallbackClose { get; set; } // 0x64
		public Action CallbackReturn { get; set; } // 0x68
		public Action CallbackNewTalk { get; set; } // 0x6C
		public Action CallbackNextPage { get; set; } // 0x70
		public Action CallPrevPage { get; set; } // 0x74

		// RVA: 0x159D470 Offset: 0x159D470 VA: 0x159D470 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.Root[0] as AbsoluteLayout;
			m_root.StartChildrenAnimGoStop("st_wait");
			m_newTalkAnim = layout.FindViewByExId("sw_sns_title_02_sw_sns_new_transition_anim") as AbsoluteLayout;
			m_logIcon = layout.FindViewByExId("sw_sns_title_02_sel_sns_icon_02") as AbsoluteLayout;
			m_titleTbl = layout.FindViewByExId("sw_sns_title_anim_swtbl_sns_title") as AbsoluteLayout;
			m_buttonLLayout = layout.FindViewByExId("sw_sns_title_01_sw_sns_btn_l_anim") as AbsoluteLayout;
			m_buttonRLayout = layout.FindViewByExId("sw_sns_title_01_sw_sns_btn_r_anim") as AbsoluteLayout;
			m_buttonReturnLayout = layout.FindViewByExId("sw_sns_title_02_sw_sns_icon_03_anim") as AbsoluteLayout;
			m_buttonExitLayout = layout.FindViewByExId("sw_sns_title_anim_sw_sns_icon_06_anim") as AbsoluteLayout;
			m_newTalkAnim.StartChildrenAnimGoStop("st_wait");
			m_pushLHitOnly = m_pushLButton.GetComponentInChildren<LayoutUGUIHitOnly>(true);
			m_pushRHitOnly = m_pushRButton.GetComponentInChildren<LayoutUGUIHitOnly>(true);
			if(m_logIcon != null)
				m_logIcon.enabled = false;
			m_backButton.AddOnClickCallback(() =>
			{
				//0x159E914
				if (CallbackReturn != null)
					CallbackReturn();
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_000);
			});
			m_exitButton.AddOnClickCallback(() =>
			{
				//0x159E980
				if (CallbackClose != null)
					CallbackClose();
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			});
			m_prevButton.AddOnClickCallback(() =>
			{
				//0x159E9EC
				if (CallPrevPage != null)
					CallPrevPage();
				PlaySE();
			});
			m_nextButton.AddOnClickCallback(() =>
			{
				//0x159EA10
				if (CallbackNextPage != null)
					CallbackNextPage();
				PlaySE();
			});
			m_newTalkButton.AddOnClickCallback(() =>
			{
				//0x159EA34
				if (CallbackNewTalk != null)
					CallbackNewTalk();
				PlaySE();
			});
			m_pushLButton.AddOnClickCallback(() =>
			{
				//0x159EA58
				SetPushButton(true, false);
				SetPushValue(true, false);
				PlaySE();
			});
			m_pushRButton.AddOnClickCallback(() =>
			{
				//0x159EA80
				SetPushButton(false, false);
				SetPushValue(false, false);
				PlaySE();
			});
			Loaded();
			return true;
		}

		//// RVA: 0x159DC2C Offset: 0x159DC2C VA: 0x159DC2C
		private void SetPushButton(bool enable, bool isCoroutine = false)
		{
			if(!enable)
			{
				SwitchPushButtonEnable(m_pushRButton, true, false);
				SwitchPushButtonEnable(m_pushLButton, false, false);
				SwitchPushButtonHitCheckEnable(m_pushRHitOnly, false);
				SwitchPushButtonHitCheckEnable(m_pushLHitOnly, enable != true);
			}
			else
			{
				SwitchPushButtonEnable(m_pushRButton, false, false);
				SwitchPushButtonEnable(m_pushLButton, true, false);
				SwitchPushButtonHitCheckEnable(m_pushRHitOnly, true);
				SwitchPushButtonHitCheckEnable(m_pushLHitOnly, enable != true);
			}
		}

		//// RVA: 0x159DCC4 Offset: 0x159DCC4 VA: 0x159DCC4
		private void SwitchPushButtonEnable(ActionButton button, bool enable, bool isCoroutine = false)
		{
			if (button == null)
				return;
			if(enable)
			{
				m_pushLButton.enabled = false;
				m_pushRButton.enabled = true;
				m_buttonLLayout.StartChildrenAnimGoStop("go_bot_decide", "go_bot_decide");
				m_buttonRLayout.StartChildrenAnimGoStop("st_bot_imp", "st_bot_imp");
				button.SetOn();
			}
			else
			{
				m_pushLButton.enabled = true;
				m_pushRButton.enabled = false;
				m_buttonLLayout.StartChildrenAnimGoStop("st_bot_imp", "st_bot_imp");
				m_buttonRLayout.StartChildrenAnimGoStop("go_bot_decide", "go_bot_decide");
				button.SetOff();
			}
		}

		//// RVA: 0x159DEF0 Offset: 0x159DEF0 VA: 0x159DEF0
		private void SwitchPushButtonHitCheckEnable(LayoutUGUIHitOnly hitOnly, bool enable)
		{
			if(hitOnly != null)
			{
				hitOnly.enabled = enable;
			}
		}

		//// RVA: 0x159DFA4 Offset: 0x159DFA4 VA: 0x159DFA4
		private void SetPushValue(bool active, bool save = true)
		{
			if(active)
			{
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.NDOEPNGHGPF_SnsReceive = 1;
			}
			else
			{
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.NDOEPNGHGPF_SnsReceive = 0;
			}
			if (!save)
				return;
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
		}

		//// RVA: 0x159E1A4 Offset: 0x159E1A4 VA: 0x159E1A4
		private void PlaySE()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
		}

		//// RVA: 0x15964A4 Offset: 0x15964A4 VA: 0x15964A4
		public void SetStatusEntrance(eButtonType buttonType)
		{
			SwitchTitle(SNSController.eType.Entrance);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			SetEntranceName(bk.GetMessageByLabel("popup_title_sns_01"));
			bool enable = GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.NDOEPNGHGPF_SnsReceive == 1;
			SetPushButton(enable, false);
			SetButtonStatus(buttonType);
		}

		//// RVA: 0x159E450 Offset: 0x159E450 VA: 0x159E450
		//public void SetStatusRoom(GAKAAIHLFKI roomData, SNSTitleBar.eButtonType buttonType) { }

		//// RVA: 0x159E358 Offset: 0x159E358 VA: 0x159E358
		public void SetButtonStatus(eButtonType buttonType)
		{
			m_backButton.Disable = false;
			m_exitButton.Disable = false;
			if (buttonType == eButtonType.Room)
			{
				m_backButton.Disable = true;
			}
			else if (buttonType >= eButtonType.Tutorial)
			{
				m_backButton.Disable = true;
				m_exitButton.Disable = true;
				SwitchPushButtonHitCheckEnable(m_pushLHitOnly, false);
				SwitchPushButtonHitCheckEnable(m_pushRHitOnly, false);
			}
		}

		//// RVA: 0x159E1FC Offset: 0x159E1FC VA: 0x159E1FC
		public void SwitchTitle(SNSController.eType type)
		{
			if(m_titleTbl != null)
			{
				m_titleTbl.StartChildrenAnimGoStop(type == SNSController.eType.Entrance ? "02" : "01");
			}
		}

		//// RVA: 0x1598AC4 Offset: 0x1598AC4 VA: 0x1598AC4
		//public void SetLogButton(int index, int max) { }

		//// RVA: 0x159DC10 Offset: 0x159DC10 VA: 0x159DC10
		//public void SwitchLogIcon(bool enable) { }

		//// RVA: 0x159E560 Offset: 0x159E560 VA: 0x159E560
		//public void In() { }

		//// RVA: 0x159E628 Offset: 0x159E628 VA: 0x159E628
		//public void Out() { }

		//// RVA: 0x159E6A8 Offset: 0x159E6A8 VA: 0x159E6A8
		//public void Hide() { }

		//// RVA: 0x159E71C Offset: 0x159E71C VA: 0x159E71C
		//public void EnterNewTalkIcon() { }

		//// RVA: 0x159E7B0 Offset: 0x159E7B0 VA: 0x159E7B0
		//public void LeaveNewTalkIcon() { }

		//// RVA: 0x159E844 Offset: 0x159E844 VA: 0x159E844
		//public void WaitNewTalkIcon() { }

		//// RVA: 0x159E49C Offset: 0x159E49C VA: 0x159E49C
		//public void SetRoomName(string roomName) { }

		//// RVA: 0x159E294 Offset: 0x159E294 VA: 0x159E294
		public void SetEntranceName(string name)
		{
			if(m_roomEntranceName != null)
			{
				m_roomEntranceName.text = name;
			}
		}

		//// RVA: 0x159E8C8 Offset: 0x159E8C8 VA: 0x159E8C8
		public bool IsPlaying()
		{
			if (m_root != null)
				return m_root.IsPlayingChildren();
			return false;
		}

		//// RVA: 0x159E8E0 Offset: 0x159E8E0 VA: 0x159E8E0
		//public void PerformExit() { }
	}
}
