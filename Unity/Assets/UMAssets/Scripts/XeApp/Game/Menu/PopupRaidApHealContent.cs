using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;
using XeApp.Game.Gacha;
using XeSys;

namespace XeApp.Game.Menu
{
	public class PopupRaidApHealContentSetting : PopupSetting
	{
		public override string PrefabPath { get { return ""; } } //0x1616388
		public override string BundleName { get { return "ly/200.xab"; } } //0x16163E4
		public override string AssetName { get { return "root_sel_music_raid_pop_ap_layout_root"; } } //0x1616440
		public override bool IsAssetBundle { get { return true; } } //0x161649C
		public override bool IsPreload { get { return false; } } //0x16164A4
		public override GameObject Content { get { return m_content; } } //0x16164AC

		// // RVA: 0x16164B4 Offset: 0x16164B4 VA: 0x16164B4
		// public void SetContent(GameObject obj) { }
	}

	public class PopupRaidApHealContent : UIBehaviour, IPopupContent
	{
		private PopupRaidApHealContentSetting setup; // 0x10
		private PopupWindowControl control; // 0x14
		private RaidApHealWindow layout; // 0x18
		private PKNOKJNLPOE_EventRaid raidController; // 0x1C
		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x1612030 Offset: 0x1612030 VA: 0x1612030 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			this.control = control;
			setup = setting as PopupRaidApHealContentSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			RaidApHealWindow window = GetComponent<RaidApHealWindow>();
			window.Initialize(OnPushPaidButton, OnPushApItemButton, OnPushApItemSButton, Close);
			raidController = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as PKNOKJNLPOE_EventRaid;
		}

		// // RVA: 0x16123B4 Offset: 0x16123B4 VA: 0x16123B4
		private void OnPushPaidButton(Action closeEvent, CIOECGOMILE.LIILJGHKIDL _apHealSubType)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			if(CIOECGOMILE.HHCJCDFCLOB.DEAPMEIDCGC_GetTotalPaidCurrency() < CIOECGOMILE.HHCJCDFCLOB.CBOJGDKGCEF_GetApPrice()[(int)_apHealSubType])
			{
				this.StartCoroutineWatched(Co_PurchaseVC(closeEvent, _apHealSubType));
			}
			else
			{
				this.StartCoroutineWatched(Co_PaidVC(closeEvent, _apHealSubType));
			}
		}

		// // RVA: 0x1612728 Offset: 0x1612728 VA: 0x1612728
		private void OnPushApItemButton(Action closeEvent)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			MenuScene.Instance.GetCurrentTransitionRoot().StartCoroutineWatched(Co_PaidItem(RaidItemConstants.Type.ApHealL, closeEvent));
		}

		// // RVA: 0x1612910 Offset: 0x1612910 VA: 0x1612910
		private void OnPushApItemSButton(Action closeEvent)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			MenuScene.Instance.GetCurrentTransitionRoot().StartCoroutineWatched(Co_PaidItem(RaidItemConstants.Type.ApHealS, closeEvent));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71466C Offset: 0x71466C VA: 0x71466C
		// // RVA: 0x16125A8 Offset: 0x16125A8 VA: 0x16125A8
		private IEnumerator Co_PurchaseVC(Action closeEvent, CIOECGOMILE.LIILJGHKIDL _apHealSubType)
		{
			//0x1615D84
			MenuScene.Instance.InputDisable();
			bool t_loop = true;
			bool t_exec = false;
			PopupWindowManager.Show(MakePopupSettingRaidApRecoveryStoneNone(_apHealSubType), (PopupWindowControl cont, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1614434
				t_loop = false;
				t_exec = type == PopupButton.ButtonType.Positive;
			}, null, null, null, true, true, false);
			while(t_loop)
				yield return null;
			if(t_exec)
			{
				if(MenuScene.CheckDatelineAndAssetUpdate())
				{
					closeEvent();
					yield break;
				}
				t_loop = true;
				MenuScene.Instance.DenomControl.StartPurchaseSequence(() =>
				{
					//0x161446C
					t_loop = false;
					closeEvent();
				}, () =>
				{
					//0x16144A0
					t_loop = false;
				}, () =>
				{
					//0x16144AC
					t_loop = false;
					MenuScene.Instance.GotoTitle();
				}, (TransitionList.Type t) =>
				{
					//0x1614554
					t_loop = false;
					MenuScene.Instance.GotoTitle();
				}, null);
				while(t_loop)
					yield return null;
			}
			//LAB_0161623c
			MenuScene.Instance.InputEnable();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7146E4 Offset: 0x7146E4 VA: 0x7146E4
		// // RVA: 0x1612668 Offset: 0x1612668 VA: 0x1612668
		private IEnumerator Co_PaidVC(Action closeEvent, CIOECGOMILE.LIILJGHKIDL _apHealSubType)
		{
			//0x16159B8
			MenuScene.Instance.InputDisable();
			int t_step = 0;
			bool t_exec = false;
			PopupWindowManager.Show(MakePopupSettingRaidApRecoveryStoneUse(_apHealSubType), (PopupWindowControl cont, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1614604
				t_step = 1;
				t_exec = type == PopupButton.ButtonType.Positive;
			}, null, null, null, true, true, false);
			while(t_step == 0)
				yield return null;
			if(t_exec)
			{
				yield return Co.R(Co_ApRecovry(EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC, RaidItemConstants.Type._maxId, _apHealSubType));
				closeEvent();
			}
			//LAB_01615c4c
			MenuScene.Instance.InputEnable();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71475C Offset: 0x71475C VA: 0x71475C
		// // RVA: 0x1612850 Offset: 0x1612850 VA: 0x1612850
		private IEnumerator Co_PaidItem(RaidItemConstants.Type a_item_id, Action closeEvent)
		{
			//0x16155E8
			MenuScene.Instance.InputDisable();
			bool t_loop = true;
			bool t_exec = false;
			PopupWindowManager.Show(MakePopupSettingRaidApRecoveryItem(a_item_id), (PopupWindowControl cont, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1614644
				t_loop = false;
				t_exec = type == PopupButton.ButtonType.Positive;
			}, null, null, null, true, true, false);
			while(t_loop)
				yield return null;
			if(t_exec)
			{
				yield return Co.R(Co_ApRecovry(EKLNMHFCAOI.FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem, a_item_id, CIOECGOMILE.LIILJGHKIDL.HJNNKCMLGFL_0));
				closeEvent();
			}
			MenuScene.Instance.InputEnable();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7147D4 Offset: 0x7147D4 VA: 0x7147D4
		// // RVA: 0x1612A98 Offset: 0x1612A98 VA: 0x1612A98
		private IEnumerator Co_ApRecovry(EKLNMHFCAOI.FKGCBLHOOCL_Category a_type, RaidItemConstants.Type a_item_id/* = 4*/, CIOECGOMILE.LIILJGHKIDL _apHealSubType/* = 0*/)
		{
			MessageBank msgBank; // 0x24

			//0x16147AC
			if(MenuScene.CheckDatelineAndAssetUpdate())
				yield break;
			msgBank = MessageManager.Instance.GetBank("menu");
			int id = 0;
			if(a_type != EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC)
				id = RaidItemConstants.MakeItemId(a_item_id);
			bool t_error = false;
			bool t_failed = false;
			bool t_loop = true;
			CIOECGOMILE.HHCJCDFCLOB.DNJKDCIAHMO(a_type, id, () =>
			{
				//0x1614684
				t_loop = false;
			}, () =>
			{
				//0x1614690
				t_loop = false;
			}, () =>
			{
				//0x161469C
				t_loop = false;
				t_failed = true;
			}, () =>
			{
				//0x16146A8
				t_loop = false;
				t_error = true;
			}, JpStringLiterals.StringLiteral_9798, _apHealSubType);
			control.InputDisable();
			while(t_loop)
				yield return null;
			control.InputEnable();
			if(!t_failed)
			{
				if(t_error)
				{
					MenuScene.Instance.GotoTitle();
					yield break;
				}
				t_loop = true;
				TextPopupSetting s = new TextPopupSetting();
				s.TitleText = msgBank.GetMessageByLabel("popup_raid_ap_recovery_success_title");
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				s.Text = string.Format(msgBank.GetMessageByLabel("popup_raid_ap_recovery_success_text"), raidController.HGJAGDPPALF_GetApNum());
				PopupWindowManager.Show(s, (PopupWindowControl content, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x16146C8
					t_loop = false;
				}, null, null, null, true, true, false);
				while(t_loop)
					yield return null;
				if(raidController.GDMLCKMCMBG() == 0)
					yield break;
				if(a_type != EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC)
					yield break;
				t_loop = true;
				s = new TextPopupSetting();
				s.TitleText = msgBank.GetMessageByLabel("popup_raid_ap_recovery_success_bonus_title");
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				s.Text = string.Format(msgBank.GetMessageByLabel("popup_raid_ap_recovery_success_bonus_text"), raidController.GDMLCKMCMBG());
				PopupWindowManager.Show(s, (PopupWindowControl content, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x16146D4
					t_loop = false;
				}, null, null, null, true, true, false);
				while(t_loop)
					yield return null;
			}
			else
			{
				TextPopupSetting s = new TextPopupSetting();
				s.TitleText = msgBank.GetMessageByLabel("popup_raid_ap_recovery_title");
				s.Buttons = new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				s.Text = msgBank.GetMessageByLabel("popup_raid_ap_recovery_failed_msg");
				PopupWindowManager.Show(s, (PopupWindowControl content, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x16146BC
					t_loop = false;
				}, null, null, null, true, true, false);
				while(t_loop)
					yield return null;
			}
		}

		// // RVA: 0x1612B90 Offset: 0x1612B90 VA: 0x1612B90
		private PopupSetting MakePopupSettingRaidApRecoveryItem(RaidItemConstants.Type a_item_id)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = new TextPopupSetting();
			s.WindowSize = SizeType.Middle;
			s.TitleText = bk.GetMessageByLabel("popup_raid_ap_recovery_title");
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.UsedItem, Type = PopupButton.ButtonType.Positive }
			};
			int a = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, 
				EKLNMHFCAOI.FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem, (int)a_item_id, null);
			s.Text = string.Format(bk.GetMessageByLabel("popup_raid_ap_recovery_use_item_check_msg"), new object[5]
			{
				EKLNMHFCAOI.INCKKODFJAP_GetItemName(EKLNMHFCAOI.FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem, (int)a_item_id),
				1, 
				raidController.COEIAHBIFBN(RaidItemConstants.MakeItemId(a_item_id), CIOECGOMILE.LIILJGHKIDL.HJNNKCMLGFL_0),
				a, a - 1
			});
			return s;
		}

		// // RVA: 0x1613200 Offset: 0x1613200 VA: 0x1613200
		private PopupSetting MakePopupSettingRaidApRecoveryStoneUse(CIOECGOMILE.LIILJGHKIDL _apHealSubType)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			GachaLotPopupSetting res = new GachaLotPopupSetting();
			res.WindowSize = SizeType.Middle;
			res.TitleText = bk.GetMessageByLabel("popup_raid_ap_recovery_title");
			res.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			if(raidController.GDMLCKMCMBG() == 0)
				res.MessageText = string.Format(bk.GetMessageByLabel("popup_raid_ap_recovery_use_stone_check_msg02"), CIOECGOMILE.HHCJCDFCLOB.CBOJGDKGCEF_GetApPrice()[(int)_apHealSubType], raidController.COEIAHBIFBN(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC, 0), _apHealSubType));
			else
			{
				res.MessageText = string.Format(bk.GetMessageByLabel("popup_raid_ap_recovery_use_stone_check_msg"), new object[4]
				{
					CIOECGOMILE.HHCJCDFCLOB.CBOJGDKGCEF_GetApPrice()[(int)_apHealSubType],
					raidController.COEIAHBIFBN(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC, 0), _apHealSubType),
					NKOBMDPHNGP_EventRaidLobby.GPNELLFNPLA(),
					raidController.GDMLCKMCMBG()
				});
			}
			res.HoldCurrency = string.Format(bk.GetMessageByLabel("popup_gacha_lot_paid_count"), CIOECGOMILE.HHCJCDFCLOB.CBOJGDKGCEF_GetApPrice()[(int)_apHealSubType]);
			res.CurrencyIsTicket = false;
			res.OnClickLegalDescButton = OnClickLegalDesc;
			return res;
		}

		// // RVA: 0x16139E4 Offset: 0x16139E4 VA: 0x16139E4
		private PopupSetting MakePopupSettingRaidApRecoveryStoneNone(CIOECGOMILE.LIILJGHKIDL _apHealSubType)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			GachaLotFewPopupSetting res = new GachaLotFewPopupSetting();
			res.WindowSize = SizeType.Middle;
			res.TitleText = bk.GetMessageByLabel("popup_raid_ap_recovery_title");
			res.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Purchase, Type = PopupButton.ButtonType.Positive },
			};
			res.MessageText = string.Format(bk.GetMessageByLabel("popup_gacha_lot_paid_few_msg"), Array.Empty<object>());
			res.HoldCurrency = string.Format(bk.GetMessageByLabel("popup_gacha_lot_paid_count"), CIOECGOMILE.HHCJCDFCLOB.DEAPMEIDCGC_GetTotalPaidCurrency());
			res.NeedCurrency = string.Format(bk.GetMessageByLabel("popup_gacha_lot_paid_count"), CIOECGOMILE.HHCJCDFCLOB.CBOJGDKGCEF_GetApPrice()[(int)_apHealSubType]);
			res.MessageCaution = null;
			res.CurrencyIsTicket = false;
			res.IsTicketPeriod = false;
			res.OnClickLegalDescButton = OnClickLegalDesc;
			return res;
		}

		// // RVA: 0x1613F58 Offset: 0x1613F58 VA: 0x1613F58
		private void OnClickLegalDesc(Action endAction)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			MBCPNPNMFHB.HHCJCDFCLOB.MDGPGGLHIPB_ShowWebUrl(MHOILBOJFHL.KCAEDEHGAFO.LCCLAEBKMLD_Legals, () =>
			{
				//0x16146E0
				if(endAction != null)
					endAction();
			}, () =>
			{
				//0x16146F4
				MenuScene.Instance.GotoTitle();
				if(endAction != null)
					endAction();
			});
		}

		// RVA: 0x16140FC Offset: 0x16140FC VA: 0x16140FC Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1614104 Offset: 0x1614104 VA: 0x1614104 Slot: 19
		public void Show()
		{
			if(!IsDestroyed())
			{
				gameObject.SetActive(true);
			}
		}

		// RVA: 0x1614154 Offset: 0x1614154 VA: 0x1614154 Slot: 20
		public void Hide()
		{
			if(!IsDestroyed())
			{
				gameObject.SetActive(false);
			}
		}

		// RVA: 0x16141A4 Offset: 0x16141A4 VA: 0x16141A4
		public void Close()
		{
			control.Close(() =>
			{
				//0x1614428
				return;
			}, null);
		}

		// RVA: 0x16142E8 Offset: 0x16142E8 VA: 0x16142E8 Slot: 21
		public bool IsReady()
		{
			return layout == null || layout.IsLoaded();
		}

		// RVA: 0x16143A0 Offset: 0x16143A0 VA: 0x16143A0 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
