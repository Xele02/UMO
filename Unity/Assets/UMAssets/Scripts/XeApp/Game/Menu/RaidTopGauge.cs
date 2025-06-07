using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using XeSys;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class RaidTopGauge : LayoutUGUIScriptBase
	{
		public enum GaugeType
		{
			None = 0,
			NotStock = 1,
			Stock = 2,
			MAX = 3,
		}

		// Fields
		private RaidTopGauge.GaugeType currentGaugeType; // 0x14
		[SerializeField]
		private NumberBase m_apNowNum; // 0x18
		[SerializeField]
		private NumberBase m_apMaxNum; // 0x1C
		[SerializeField]
		private NumberBase m_paidStoneNum; // 0x20
		[SerializeField]
		private Text m_timeText; // 0x24
		[SerializeField]
		private Text m_balloonText; // 0x28
		[SerializeField]
		private ActionButton m_apPlusButton; // 0x2C
		[SerializeField]
		private ActionButton m_vcPlusButton; // 0x30
		[SerializeField]
		private ActionButton m_chargeButton; // 0x34
		private AbsoluteLayout m_raidBarAnim; // 0x38
		private AbsoluteLayout m_gaugeAnim; // 0x3C
		private AbsoluteLayout m_switchGauge; // 0x40
		private AbsoluteLayout m_switchNumAnim; // 0x44
		private AbsoluteLayout m_addGaugeAnim; // 0x48
		private AbsoluteLayout m_sphereAnim; // 0x4C
		private AbsoluteLayout m_balloonAnim; // 0x50
		private bool m_isShow; // 0x54
		private PKNOKJNLPOE_EventRaid raidController; // 0x58
		private PopupRaidApHealContentSetting m_apHealSetting; // 0x5C
		private IFBCGCCJBHI m_viewPlayerStatus; // 0x60
		private long healTime; // 0x68
		public UnityAction UpdateMacrossGaugeListner; // 0x70
		public Func<bool> OnUseItemChargeMacrossCannon; // 0x74

		// // RVA: 0xCEE17C Offset: 0xCEE17C VA: 0xCEE17C
		public void Initialize()
		{
			UpdateGauge(true);
		}

		// RVA: 0xCEE304 Offset: 0xCEE304 VA: 0xCEE304
		private void Update()
		{
			if(raidController == null)
				return;
			raidController.LHEPBBADNIH();
			ChangeRemainTime(raidController.DMNDFBJODBA_GetApLoadTimeLeft());
			SetAPNum(raidController.HGJAGDPPALF_GetApNum(), raidController.BFPIHPBKEGK_GetApMax());
			m_viewPlayerStatus.FBANBDCOEJL();
			m_paidStoneNum.SetNumber(m_viewPlayerStatus.FNCPAEFEECO_CurrencyPaid, 0);
		}

		// RVA: 0xCEE648 Offset: 0xCEE648 VA: 0xCEE648 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			raidController = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as PKNOKJNLPOE_EventRaid;
			m_isShow = false;
			currentGaugeType = GaugeType.None;
			healTime = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA("raid_event_ap_second", 1200);
			m_viewPlayerStatus = new IFBCGCCJBHI();
			m_viewPlayerStatus.KHEKNNFCAOI();
			m_raidBarAnim = layout.FindViewByExId("sw_raid_bar_anim_01_sw_raid_bar_01") as AbsoluteLayout;
			m_gaugeAnim = layout.FindViewByExId("swtbl_bar_01_sw_bar_anim") as AbsoluteLayout;
			m_switchGauge = layout.FindViewByExId("sw_raid_bar_01_swtbl_bar_01") as AbsoluteLayout;
			m_addGaugeAnim = layout.FindViewByExId("sw_s_m_r_mcc_ef_set_anim_s_m_r_mcc_ef_04") as AbsoluteLayout;
			m_sphereAnim = layout.FindViewByExId("sw_s_m_r_mcc_ef_02_anim_s_m_r_mcc_ef_02_2") as AbsoluteLayout;
			m_balloonAnim = layout.FindViewByExId("sw_raid_bar_01_sw_raid_win_balloon_01_anim") as AbsoluteLayout;
			m_switchNumAnim = layout.FindViewByExId("swtbl_bar_01_raid_ap_fnt_1") as AbsoluteLayout;
			m_apPlusButton.AddOnClickCallback(OnClickChargeAp);
			m_vcPlusButton.AddOnClickCallback(OnClickChargeMoney);
			m_chargeButton.AddOnClickCallback(OnClickChargeMC);
			Loaded();
			return true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71578C Offset: 0x71578C VA: 0x71578C
		// // RVA: 0xCEECAC Offset: 0xCEECAC VA: 0xCEECAC
		public IEnumerator Co_StartAddGaugeAnim(Action callback)
		{
			float waitTime;

			//0xCF1DEC
			m_addGaugeAnim.StartSiblingAnimGoStop("go_act", "st_act");
			m_sphereAnim.StartSiblingAnimGoStop("go_act", "st_act");
			waitTime = 2;
			while(waitTime >= 0)
			{
				waitTime -= Time.deltaTime;
				if(MenuScene.Instance.IsTransition())
				{
					Stop();
					yield break;
				}
				yield return null;
			}
			if(MenuScene.Instance.IsTransition())
				yield break;
			UpdateGauge(false);
			while(m_addGaugeAnim.IsPlayingSibling())
			{
				if(MenuScene.Instance.IsTransition())
				{
					Stop();
					yield break;
				}
				yield return null;
			}
			m_sphereAnim.StopAllAnim();
			HideAddGaugeAnim();
			callback();
		}

		// // RVA: 0xCEED74 Offset: 0xCEED74 VA: 0xCEED74
		public void HideAddGaugeAnim()
		{
			m_addGaugeAnim.StartSiblingAnimGoStop("st_wait", "st_wait");
		}

		// // RVA: 0xCEEDF4 Offset: 0xCEEDF4 VA: 0xCEEDF4
		public void HideBalloonAnim()
		{
			m_balloonAnim.StartChildrenAnimGoStop("st_wait", "st_wait");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x715804 Offset: 0x715804 VA: 0x715804
		// // RVA: 0xCEEE74 Offset: 0xCEEE74 VA: 0xCEEE74
		public IEnumerator Co_StartBalloonAnim(Action callback)
		{
			//0xCF21FC
			m_balloonAnim.StartChildrenAnimGoStop("go_in", "st_in");
			yield return new WaitForSeconds(2);
			m_balloonAnim.StartChildrenAnimGoStop("go_out", "st_out");
			while(m_balloonAnim.IsPlayingChildren())
				yield return null;
			callback();
		}

		// // RVA: 0xCED0CC Offset: 0xCED0CC VA: 0xCED0CC
		public void SetBalloonText(string str)
		{
			m_balloonText.text = str;
		}

		// // RVA: 0xCEE184 Offset: 0xCEE184 VA: 0xCEE184
		public void UpdateGauge(bool isInitialize/* = False*/)
		{
			int stock, b;
			bool isMax;
			raidController.HAPDLPAKMLF(out stock, out b, out isMax);
			if(stock == 0)
				SwitchGauge(GaugeType.NotStock);
			else if(!isMax)
				SwitchGauge(GaugeType.Stock);
			else
				SwitchGauge(GaugeType.MAX);
			string lbl = string.Format("{0:D2}", b / 100 + stock);
			m_switchNumAnim.StartChildrenAnimGoStop(lbl, lbl);
			m_gaugeAnim.StartChildrenAnimGoStop(b, b);
			if(!isInitialize && UpdateMacrossGaugeListner != null)
				UpdateMacrossGaugeListner();
		}

		// // RVA: 0xCEEF3C Offset: 0xCEEF3C VA: 0xCEEF3C
		private void SwitchGauge(GaugeType type)
		{
			if(currentGaugeType == type)
				return;
			currentGaugeType = type;
			if(type == GaugeType.MAX)
			{
				m_switchGauge.StartChildrenAnimGoStop("03", "03");
			}
			else if(type == GaugeType.Stock)
			{
				m_switchGauge.StartChildrenAnimGoStop("02", "02");
			}
			else if(type == GaugeType.NotStock)
			{
				m_switchGauge.StartChildrenAnimGoStop("01", "01");
			}
		}

		// // RVA: 0xCEE590 Offset: 0xCEE590 VA: 0xCEE590
		public void SetAPNum(int num, int max)
		{
			m_apNowNum.SetNumber(num, 0);
			m_apMaxNum.SetNumber(max, 0);
		}

		// // RVA: 0xCEF034 Offset: 0xCEF034 VA: 0xCEF034
		// public void SetGauge(int val) { }

		// // RVA: 0xCEE434 Offset: 0xCEE434 VA: 0xCEE434
		public void ChangeRemainTime(long seconds)
		{
			if(seconds == 0)
			{
				m_timeText.text = JpStringLiterals.StringLiteral_11085;
			}
			else
			{
				m_timeText.text = JpStringLiterals.StringLiteral_11083 + (seconds % 60) + ":" + (seconds / 60).ToString("00");
			}
		}

		// // RVA: 0xCEE608 Offset: 0xCEE608 VA: 0xCEE608
		// public void SetPaidStone(int num) { }

		// // RVA: 0xCEF04C Offset: 0xCEF04C VA: 0xCEF04C
		public void ShowApHealPopup(Action callback)
		{
			if(raidController.EIEDIDECECD() != 0)
			{
				if(m_apHealSetting == null)
				{
					m_apHealSetting = new PopupRaidApHealContentSetting();
					m_apHealSetting.SetParent(transform);
					m_apHealSetting.WindowSize = SizeType.Large;
					m_apHealSetting.TitleText = MessageManager.Instance.GetMessage("menu", "pop_raid_ap_heal_title");
					m_apHealSetting.Buttons = new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
					};
				}
				PopupWindowManager.Show(m_apHealSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0xCF05DC
					return;
				}, null, null, null, true, true, false, null, callback);
			}
			else
			{
				PopupWindowManager.Show(PopupWindowManager.CrateTextContent(MessageManager.Instance.GetMessage("menu", "popup_raid_ap_recovery_success_bonus_title"), SizeType.Small, 
					MessageManager.Instance.GetMessage("menu", "popup_raid_ap_recovery_max_text"), new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					}, false, true), (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0xCF05E0
					return;
				}, null, null, null, true, true, false, null, callback);
			}
		}

		// // RVA: 0xCEF6A0 Offset: 0xCEF6A0 VA: 0xCEF6A0
		private bool IsEndRaidEvent()
		{
			raidController.HCDGELDHFHB_UpdateStatus(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
			if(raidController.NGOFCFJHOMI_Status > KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5)
			{
				JHHBAFKMBDL.HHCJCDFCLOB.DNABPEOICIJ(() =>
				{
					//0xCF05E4
					MenuScene.Instance.Mount(TransitionUniqueId.HOME, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
				}, false);
				return true;
			}
			return false;
		}

		// // RVA: 0xCEF91C Offset: 0xCEF91C VA: 0xCEF91C
		private void OnClickChargeAp()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			ShowApHealPopup(null);
		}

		// // RVA: 0xCEF984 Offset: 0xCEF984 VA: 0xCEF984
		private void OnClickChargeMoney()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			if(!MenuScene.CheckDatelineAndAssetUpdate())
			{
				GameManager.Instance.CloseSnsNotice();
				GameManager.Instance.CloseOfferNotice();
				if(MenuScene.Instance.DenomControl != null)
				{
					MenuScene.Instance.InputDisable();
					MenuScene.Instance.DenomControl.StartPurchaseSequence(() =>
					{
						//0xCF069C
						MenuScene.Instance.InputEnable();
					}, () =>
					{
						//0xCF0738
						MenuScene.Instance.InputEnable();
					}, () =>
					{
						//0xCF07D4
						MenuScene.Instance.GotoTitle();
					}, (TransitionList.Type type) =>
					{
						//0xCF0870
						if(type == TransitionList.Type.TITLE)
						{
							MenuScene.Instance.GotoTitle();
						}
						else if(type == TransitionList.Type.LOGIN_BONUS)
						{
							MenuScene.Instance.GotoLoginBonus();
						}
						MenuScene.Instance.InputEnable();
					}, null);
				}
			}
		}

		// // RVA: 0xCEFF0C Offset: 0xCEFF0C VA: 0xCEFF0C
		private void OnClickChargeMC()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			GameManager.Instance.CloseSnsNotice();
			GameManager.Instance.CloseOfferNotice();
			if(MenuScene.CheckDatelineAndAssetUpdate())
				return;
			if(IsEndRaidEvent())
				return;
			this.StartCoroutineWatched(Co_ChargeMC());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71587C Offset: 0x71587C VA: 0x71587C
		// // RVA: 0xCF0088 Offset: 0xCF0088 VA: 0xCF0088
		private IEnumerator Co_ChargeMC()
		{
			int itemId;

			//0xCF10F4
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			itemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 6);
			int stock, gauge;
			bool isMax;
			PBOHJPIBILI.GLEPHGKFFLL(out stock, out gauge, out isMax);
			string str = EKLNMHFCAOI.INCKKODFJAP_GetItemName(itemId);
			ButtonInfo[] btns;
			if(!isMax)
			{
				int a = PBOHJPIBILI.GJPMPGIIPHA(itemId);
				if(a < 1)
				{
					str = string.Format(bk.GetMessageByLabel("pop_raid_heal_item_cannon_text003"), str);
					btns = new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
					};
				}
				else
				{
					str = string.Format(bk.GetMessageByLabel("pop_raid_heal_item_cannon_text002"), new object[5]
					{
						str, 1, PBOHJPIBILI.DIDALOAJHBE(itemId), a, a - 1
					});
					btns = new ButtonInfo[2]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
						new ButtonInfo() { Label = PopupButton.ButtonLabel.UsedItem, Type = PopupButton.ButtonType.Positive }
					};
				}
			}
			else
			{
				str = bk.GetMessageByLabel("pop_raid_heal_item_cannon_text004");
				btns = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				};
			}
			bool done = false;
			bool cancel = false;
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("pop_raid_heal_item_cannon_text001"), SizeType.Small, str, btns, false, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xCF0B10
				if(type == PopupButton.ButtonType.Negative)
				{
					done = true;
					cancel = true;
				}
				else if(type == PopupButton.ButtonType.Positive)
				{
					done = true;
				}
			}, null, null, null, true, true, false);
			MenuScene.Instance.InputDisable();
			while(!done)
				yield return null;
			MenuScene.Instance.InputEnable();
			if(cancel)
				yield break;
			if(PGIGNJDPCAH.MNANNMDBHMP(() =>
			{
				//0xCF09CC
				MenuScene.Instance.GotoLoginBonus();
			}, () =>
			{
				//0xCF0A68
				MenuScene.Instance.GotoTitle();
			}))
			{
				yield break;
			}
			MenuScene.Instance.InputDisable();
			yield return Co.R(Co_ApplyChargeMC(itemId, () =>
			{
				//0xCF0B38
				bool a = false;
				if(OnUseItemChargeMacrossCannon != null)
					a = OnUseItemChargeMacrossCannon();
				UpdateGauge(a);
			}, () =>
			{
				//0xCF0B04
				return;
			}));
			MenuScene.Instance.InputEnable();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7158F4 Offset: 0x7158F4 VA: 0x7158F4
		// // RVA: 0xCF0134 Offset: 0xCF0134 VA: 0xCF0134
		public IEnumerator Co_ApplyChargeMC(int itemId, Action recoveryCallBack, DJBHIFLHJLK errorCallBack)
		{
			int ret;

			//0xCF0C34
			bool done = false;
			ret = PBOHJPIBILI.BPAOMGFCODD(itemId, () =>
			{
				//0xCF0C18
				done = true;
			});
			while(!done)
				yield return null;
			if(ret != 1)
			{
				if(errorCallBack != null)
					errorCallBack();
				yield break;
			}
			if(recoveryCallBack != null)
				recoveryCallBack();
			done = false;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("pop_raid_heal_item_cannon_text001"), SizeType.Small, 
				bk.GetMessageByLabel("pop_raid_heal_item_cannon_text005"), new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				}, false, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0xCF0C24
					done = true;
				}, null, null, null, true, true, false);
			while(!done)
				yield return null;
		}

		// // RVA: 0xCF0214 Offset: 0xCF0214 VA: 0xCF0214
		// public void Show() { }

		// // RVA: 0xCF029C Offset: 0xCF029C VA: 0xCF029C
		public void Hide()
		{
			m_isShow = false;
			m_raidBarAnim.StartSiblingAnimGoStop("st_out", "st_out");
			m_addGaugeAnim.StartSiblingAnimGoStop("st_out", "st_out");
			m_sphereAnim.StartSiblingAnimGoStop("st_wait", "st_wait");
			HideAddGaugeAnim();
			HideBalloonAnim();
		}

		// // RVA: 0xCF039C Offset: 0xCF039C VA: 0xCF039C
		public void Enter()
		{
			if(!m_isShow)
			{
				m_raidBarAnim.StartSiblingAnimGoStop("go_in", "st_in");
			}
			m_isShow = true;
		}

		// // RVA: 0xCF043C Offset: 0xCF043C VA: 0xCF043C
		public void Leave()
		{
			if(m_isShow)
			{
				m_raidBarAnim.StartSiblingAnimGoStop("go_out", "st_out");
			}
			m_isShow = false;
		}

		// // RVA: 0xCF04DC Offset: 0xCF04DC VA: 0xCF04DC
		public void Stop()
		{
			m_addGaugeAnim.StopAllAnim();
			m_sphereAnim.StopAllAnim();
		}

		// // RVA: 0xCF052C Offset: 0xCF052C VA: 0xCF052C
		public bool IsPlaying()
		{
			return m_raidBarAnim.IsPlayingSibling();
		}
	}
}
