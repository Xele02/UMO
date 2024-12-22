using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;
using UnityEngine.UI;
using XeSys;
using mcrs;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigOther_01 : LayoutPopupConfigBase
	{
		private enum eTextType
		{
			Title = 0,
			Caution = 1,
			NoticeDesc = 2,
			TimeDesc = 3,
			TimeCaution = 4,
			EnRecoveryDesc = 5,
			SnsDesc = 6,
			OfferDesc = 7,
			ApRecoveryDesc = 8,
			ExEnemyDesc = 9,
			ExEnemyCaution = 10,
			DecoModeDesc = 11,
			LimitedItemDesc = 12,
			Num = 13,
		}

		private enum eButtonType
		{
			TimeZone_00_04 = 0,
			TimeZone_04_08 = 1,
			TimeZone_08_12 = 2,
			TimeZone_12_16 = 3,
			TimeZone_16_20 = 4,
			TimeZone_20_24 = 5,
			Num = 6,
		}

		private enum eToggleGroup
		{
			EnRecovery = 0,
			Notice = 1,
			Sns = 2,
			Offer = 3,
			ApRecovery = 4,
			ExEnemy = 5,
			DecoMode = 6,
			LimitedItem = 7,
			Num = 8,
		}

		[SerializeField]
		private ToggleButton[] m_toggleButtons; // 0x38
		private AbsoluteLayout m_layout; // 0x3C
		private int m_height; // 0x40

		// RVA: 0x1EC74FC Offset: 0x1EC74FC VA: 0x1EC74FC Slot: 6
		public override int GetContentsHeight()
		{
			return m_height;
		}

		// RVA: 0x1EC7504 Offset: 0x1EC7504 VA: 0x1EC7504 Slot: 7
		public override bool IsShow()
		{
			return true;
		}

		// RVA: 0x1EC750C Offset: 0x1EC750C VA: 0x1EC750C Slot: 8
		public override void SetStatus(ScrollRect scroll)
		{
			base.SetStatus(scroll);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			SetText(0, bk.GetMessageByLabel("set_notification_text_00"));
			SetText(1, bk.GetMessageByLabel("set_notification_text_01"));
			SetText(2, bk.GetMessageByLabel("set_notification_text_02"));
			SetText(3, bk.GetMessageByLabel("set_notification_text_03"));
			SetText(4, bk.GetMessageByLabel("set_notification_text_04"));
			SetText(5, bk.GetMessageByLabel("set_notification_text_05"));
			SetText(6, bk.GetMessageByLabel("set_notification_text_06"));
			SetText(7, bk.GetMessageByLabel("set_notification_text_07"));
			SetText(8, bk.GetMessageByLabel("set_notification_text_08"));
			SetText(9, bk.GetMessageByLabel("set_notification_text_09"));
			SetText(10, bk.GetMessageByLabel("set_notification_text_10"));
			SetText(11, bk.GetMessageByLabel("set_notification_text_11"));
			SetText(12, bk.GetMessageByLabel("set_notification_text_12"));
			SetSelectToggleButton(1, ConfigManager.Instance.Notification.ILNIHDCCOEO_EventReceive != 1 ? 1 : 0);
			SetSelectToggleButton(0, ConfigManager.Instance.Notification.KNOLBNCEHFB_StaminaReceive != 1 ? 1 : 0);
			SetSelectToggleButton(2, ConfigManager.Instance.Notification.NDOEPNGHGPF_SnsReceive != 1 ? 1 : 0);
			SetSelectToggleButton(3, ConfigManager.Instance.Notification.JAFLKPEEGIM_OfferReceive != 1 ? 1 : 0);
			SetSelectToggleButton(4, ConfigManager.Instance.Notification.HILOMEJEJAM_ApReceive != 1 ? 1 : 0);
			SetSelectToggleButton(5, ConfigManager.Instance.Notification.EJGJPICOCBI != 1 ? 1 : 0);
			SetSelectToggleButton(6, ConfigManager.Instance.Notification.PIPOIELPKBP_DecoReceive != 1 ? 1 : 0);
			SetSelectToggleButton(7, ConfigManager.Instance.Notification.OKGKFFLMFKH_LimitedReceive != 1 ? 1 : 0);
			for(int i = 0; i < 6; i++)
			{
				if (ConfigManager.Instance.Notification.OCKFGNLLBFA(i))
					m_toggleButtons[i].SetOn();
				else
					m_toggleButtons[i].SetOff();
			}
		}

		//// RVA: 0x1EC7F34 Offset: 0x1EC7F34 VA: 0x1EC7F34
		private void OnPushTimeButton(int index)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			if(m_toggleButtons[index].IsOn)
			{
				m_toggleButtons[index].SetOn();
				ConfigManager.Instance.Notification.AAHGFMHAJFG(index, true);
			}
			else
			{
				m_toggleButtons[index].SetOff();
				ConfigManager.Instance.Notification.AAHGFMHAJFG(index, false);
			}
		}

		// RVA: 0x1EC8150 Offset: 0x1EC8150 VA: 0x1EC8150 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			SetCallbackToggleButton(1, (int value) =>
			{
				//0x1EC8AD8
				ConfigUtility.PlaySeToggleButton();
				ConfigManager.Instance.Notification.ILNIHDCCOEO_EventReceive = (value == 0) ? (sbyte)1 : (sbyte)0;
			});
			SetCallbackToggleButton(0, (int value) =>
			{
				//0x1EC8B84
				ConfigUtility.PlaySeToggleButton();
				ConfigManager.Instance.Notification.KNOLBNCEHFB_StaminaReceive = (value == 0) ? (sbyte)1 : (sbyte)0;
			});
			SetCallbackToggleButton(2, (int value) =>
			{
				//0x1EC8C30
				ConfigUtility.PlaySeToggleButton();
				ConfigManager.Instance.Notification.NDOEPNGHGPF_SnsReceive = (value == 0) ? (sbyte)1 : (sbyte)0;
			});
			SetCallbackToggleButton(3, (int value) =>
			{
				//0x1EC8CDC
				ConfigUtility.PlaySeToggleButton();
				ConfigManager.Instance.Notification.JAFLKPEEGIM_OfferReceive = (value == 0) ? (sbyte)1 : (sbyte)0;
			});
			SetCallbackToggleButton(4, (int value) =>
			{
				//0x1EC8D88
				ConfigUtility.PlaySeToggleButton();
				ConfigManager.Instance.Notification.HILOMEJEJAM_ApReceive = (value == 0) ? (sbyte)1 : (sbyte)0;
			});
			SetCallbackToggleButton(5, (int value) =>
			{
				//0x1EC8E34
				ConfigUtility.PlaySeToggleButton();
				ConfigManager.Instance.Notification.EJGJPICOCBI = (value == 0) ? (sbyte)1 : (sbyte)0;
			});
			SetCallbackToggleButton(6, (int value) =>
			{
				//0x1EC8EEC
				ConfigUtility.PlaySeToggleButton();
				ConfigManager.Instance.Notification.PIPOIELPKBP_DecoReceive = (value == 0) ? (sbyte)1 : (sbyte)0;
			});
			SetCallbackToggleButton(7, (int value) =>
			{
				//0x1EC8F98
				ConfigUtility.PlaySeToggleButton();
				ConfigManager.Instance.Notification.OKGKFFLMFKH_LimitedReceive = (value == 0) ? (sbyte)1 : (sbyte)0;
			});
			m_toggleButtons[0].AddOnClickCallback(() =>
			{
				//0x1EC9044
				OnPushTimeButton(0);
			});
			m_toggleButtons[1].AddOnClickCallback(() =>
			{
				//0x1EC904C
				OnPushTimeButton(1);
			});
			m_toggleButtons[2].AddOnClickCallback(() =>
			{
				//0x1EC9054
				OnPushTimeButton(2);
			});
			m_toggleButtons[3].AddOnClickCallback(() =>
			{
				//0x1EC905C
				OnPushTimeButton(3);
			});
			m_toggleButtons[4].AddOnClickCallback(() =>
			{
				//0x1EC9064
				OnPushTimeButton(4);
			});
			m_toggleButtons[5].AddOnClickCallback(() =>
			{
				//0x1EC906C
				OnPushTimeButton(5);
			});
			m_layout = layout.FindViewById("swtbl_notice_set") as AbsoluteLayout;
			bool b1 = HNDLICBDEMI.AAFGGLHPPJN();
			bool b2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.BEFGHIJNEBL();
			if(!b2 && b1)
			{
				m_height = 724;
				m_layout.StartChildrenAnimGoStop("02");
			}
			else if(b2 && !b1)
			{
				m_height = 834;
				m_layout.StartChildrenAnimGoStop("03");
			}
			else
			{
				m_height = 653;
				m_layout.StartChildrenAnimGoStop("01");
				if(b1 && b2)
				{
					m_height = 904;
					m_layout.StartChildrenAnimGoStop("04");
				}
			}
			Loaded();
			return true;
		}
	}
}
