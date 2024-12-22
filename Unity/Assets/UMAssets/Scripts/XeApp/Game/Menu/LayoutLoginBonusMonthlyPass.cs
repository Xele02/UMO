using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using System.Collections.Generic;
using System;
using mcrs;
using System.Collections;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutLoginBonusMonthlyPass : LayoutUGUIScriptBase
	{
		[SerializeField]
		private LayoutUGUIRuntime m_runtime; // 0x14
		[SerializeField]
		private Text[] m_textRarityUpGet = new Text[2]; // 0x18
		[SerializeField]
		private Text m_textDesc; // 0x1C
		[SerializeField]
		private NumberBase m_numberRemain; // 0x20
		[SerializeField]
		private ActionButton m_buttonAbout; // 0x24
		[SerializeField]
		private ActionButton[] m_buttonClose = new ActionButton[2]; // 0x28
		[SerializeField]
		private List<LayoutLoginBonusMonthlyPassItemButton> m_buttonItems; // 0x2C
		[SerializeField]
		private LayoutLoginBonusMonthlyPassItemButton m_buttonNextItem; // 0x30
		private AbsoluteLayout m_layoutRoot; // 0x34
		private AbsoluteLayout m_layoutTitle; // 0x38
		private AbsoluteLayout m_layoutNextDays; // 0x3C
		private AbsoluteLayout m_layoutNextAnim; // 0x40
		private AbsoluteLayout m_layoutStampDays; // 0x44
		private AbsoluteLayout m_layoutStampAnim; // 0x48
		private AbsoluteLayout m_layoutRemain; // 0x4C
		private AbsoluteLayout m_layoutButton; // 0x50
		private GJFMKMJOFMB m_view; // 0x54
		private bool m_isGetAnim; // 0x58
		private bool m_isSkiped; // 0x59
		private Matrix23 m_identity; // 0x64

		public bool IsOpen { get; private set; } // 0x5A
		public Action OnClickAboutButton { get; set; } // 0x5C
		public Action OnClickCloseButton { get; set; } // 0x60

		// // RVA: 0x1D5AD2C Offset: 0x1D5AD2C VA: 0x1D5AD2C
		public static void OpenItemPackPopup(List<MFDJIFIIPJD> items, List<MFDJIFIIPJD> spItems, bool isTelop, Action closeCallback)
		{
			CAEDGOPBDNK c = new CAEDGOPBDNK();
			c.HBHMAKNGKFK_Items = items;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			PopupLoginBonusPackSetting s = new PopupLoginBonusPackSetting();
			s.TitleText = bk.GetMessageByLabel("pop_pass_loginbonus_title");
			s.IsCaption = false;
			s.WindowSize = items.Count > 1 ? SizeType.Middle : SizeType.Small;
			s.Data = c;
			s.SpItems = spItems;
			s.IsTelop = isTelop;
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = isTelop ? PopupButton.ButtonLabel.Ok : PopupButton.ButtonLabel.Close, Type = isTelop ? PopupButton.ButtonType.Positive : PopupButton.ButtonType.Negative }
			};
			PopupWindowManager.Show(s, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1D5D990
				return;
			}, null, null, null, endCallBaack:closeCallback);
		}

		// // RVA: 0x1D5B12C Offset: 0x1D5B12C VA: 0x1D5B12C
		// public static void OpenTelopGetItemPopup(int itemId, int count, Action closeCallback) { }

		// // RVA: 0x1D5B27C Offset: 0x1D5B27C VA: 0x1D5B27C
		// public void Setup(GJFMKMJOFMB view, bool isTitlePass = False, bool forceNewReward = False) { }

		// RVA: 0x1D5BB54 Offset: 0x1D5BB54 VA: 0x1D5BB54
		public void SetSkip()
		{
			m_isSkiped = true;
		}

		// // RVA: 0x1D5BB60 Offset: 0x1D5BB60 VA: 0x1D5BB60
		// public void Enter(Transform parent, bool isGetAnim = False) { }

		// [IteratorStateMachineAttribute] // RVA: 0x705B24 Offset: 0x705B24 VA: 0x705B24
		// // RVA: 0x1D5BF68 Offset: 0x1D5BF68 VA: 0x1D5BF68
		// private IEnumerator Co_EnterAnim() { }

		// [IteratorStateMachineAttribute] // RVA: 0x705B9C Offset: 0x705B9C VA: 0x705B9C
		// // RVA: 0x1D5BFF4 Offset: 0x1D5BFF4 VA: 0x1D5BFF4
		// private IEnumerator Co_WaitEnterAnim() { }

		// RVA: 0x1D5C0C0 Offset: 0x1D5C0C0 VA: 0x1D5C0C0
		public void Leave(Action callback)
		{
			m_layoutRoot.StartChildrenAnimGoStop("go_out", "st_out");
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_001);
			GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
			this.StartCoroutineWatched(Co_LeveAnimeWait(callback));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x705C14 Offset: 0x705C14 VA: 0x705C14
		// // RVA: 0x1D5C2F0 Offset: 0x1D5C2F0 VA: 0x1D5C2F0
		private IEnumerator Co_LeaveAnim(Action callback)
		{
			//0x1D5E3A4
			yield return Co.R(Co_WaitAnim(m_layoutRoot, true));
			if(callback != null)
				callback();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x705C8C Offset: 0x705C8C VA: 0x705C8C
		// // RVA: 0x1D5C248 Offset: 0x1D5C248 VA: 0x1D5C248
		private IEnumerator Co_LeveAnimeWait(Action callback)
		{
			//0x1D5E4E0
			yield return this.StartCoroutineWatched(Co_LeaveAnim(callback));
			IsOpen = false;
		}

		// // RVA: 0x1D5C3D8 Offset: 0x1D5C3D8 VA: 0x1D5C3D8
		// public void EnterStamp(int day, Action animEndCallback) { }

		// [IteratorStateMachineAttribute] // RVA: 0x705D04 Offset: 0x705D04 VA: 0x705D04
		// // RVA: 0x1D5C4AC Offset: 0x1D5C4AC VA: 0x1D5C4AC
		// private IEnumerator Co_StampAnim(Action animEndCallback) { }

		// // RVA: 0x1D5C574 Offset: 0x1D5C574 VA: 0x1D5C574
		// public void EnterNext(int day) { }

		// [IteratorStateMachineAttribute] // RVA: 0x705D7C Offset: 0x705D7C VA: 0x705D7C
		// // RVA: 0x1D5C650 Offset: 0x1D5C650 VA: 0x1D5C650
		// private IEnumerator Co_ChangeAnim() { }

		// // RVA: 0x1D5C6FC Offset: 0x1D5C6FC VA: 0x1D5C6FC
		public void InputEnable()
		{
			m_buttonAbout.IsInputOff = false;
			m_buttonNextItem.IsInputOff = false;
			for(int i = 0; i < m_buttonClose.Length; i++)
			{
				m_buttonClose[i].IsInputOff = false;
			}
			for(int i = 0; i < m_buttonItems.Count; i++)
			{
				m_buttonItems[i].IsInputOff = false;
			}
		}

		// // RVA: 0x1D5C8A8 Offset: 0x1D5C8A8 VA: 0x1D5C8A8
		public void InputDisable()
		{
			m_buttonAbout.IsInputOff = true;
			m_buttonNextItem.IsInputOff = true;
			for(int i = 0; i < m_buttonClose.Length; i++)
			{
				m_buttonClose[i].IsInputOff = true;
			}
			for(int i = 0; i < m_buttonItems.Count; i++)
			{
				m_buttonItems[i].IsInputOff = true;
			}
		}

		// // RVA: 0x1D5CA54 Offset: 0x1D5CA54 VA: 0x1D5CA54
		// public bool IsLoading() { }

		// // RVA: 0x1D5CAF0 Offset: 0x1D5CAF0 VA: 0x1D5CAF0
		// public bool IsReady() { }

		// // RVA: 0x1D5B834 Offset: 0x1D5B834 VA: 0x1D5B834
		// private List<GJFMKMJOFMB.OJIMKCKABGE> GetDays(GJFMKMJOFMB view, bool forceNewReward = False) { }

		// [IteratorStateMachineAttribute] // RVA: 0x705DF4 Offset: 0x705DF4 VA: 0x705DF4
		// // RVA: 0x1D5CC2C Offset: 0x1D5CC2C VA: 0x1D5CC2C
		// private IEnumerator Co_WaitLabel(AbsoluteLayout layout, string label, bool enableSkip = True) { }

		// [IteratorStateMachineAttribute] // RVA: 0x705E6C Offset: 0x705E6C VA: 0x705E6C
		// // RVA: 0x1D5CD24 Offset: 0x1D5CD24 VA: 0x1D5CD24
		private IEnumerator Co_WaitAnim(AbsoluteLayout layout, bool enableSkip = true)
		{
			//0x1D5E8E4
			while(true)
			{
				if(!layout.IsPlayingChildren())
					yield break;
				if(!m_isSkiped || !enableSkip)
					yield return null;
				else
				{
					layout.UpdateAllAnimation(TimeWrapper.deltaTime * 2);
					layout.UpdateAll(m_identity, Color.white);
				}
			}
		}

		// RVA: 0x1D5CE04 Offset: 0x1D5CE04 VA: 0x1D5CE04 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.Root[0] as AbsoluteLayout;
			m_layoutRoot.StartChildrenAnimGoStop("st_wait");
			m_layoutTitle = layout.FindViewById("swtbl_sp_log_title") as AbsoluteLayout;
			m_layoutNextDays = layout.FindViewById("swtbl_item_next_icon") as AbsoluteLayout;
			m_layoutNextAnim = layout.FindViewById("sw_sp_item_next_icon_anim") as AbsoluteLayout;
			m_layoutNextAnim.StartChildrenAnimGoStop("st_wait");
			m_layoutStampDays = layout.FindViewById("swtbl_item_get_eff") as AbsoluteLayout;
			m_layoutStampAnim = layout.FindViewById("sw_sp_item_get_eff_anim") as AbsoluteLayout;
			m_layoutStampAnim.StartChildrenAnimGoStop("st_wait");
			m_layoutButton = layout.FindViewById("swtbl_adv_login_btn") as AbsoluteLayout;
			m_layoutRemain = layout.FindViewById("swtbl_day_rimit") as AbsoluteLayout;
			m_buttonAbout.AddOnClickCallback(() =>
			{
				//0x1D5D6B4
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				if(OnClickAboutButton != null)
					OnClickAboutButton();
			});
			for(int i = 0; i < m_buttonClose.Length; i++)
			{
				m_buttonClose[i].AddOnClickCallback(() =>
				{
					//0x1D5D724
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
					Leave(() =>
					{
						//0x1D5D800
						if(OnClickCloseButton != null)
							OnClickCloseButton();
					});
				});
			}
			for(int i = 0; i < m_buttonItems.Count; i++)
			{
				m_buttonNextItem.OnClickButton = (List<MFDJIFIIPJD> items, List<MFDJIFIIPJD> spItems) =>
				{
					//0x1D5D814
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					InputDisable();
					OpenItemPackPopup(items, spItems, false, () =>
					{
						//0x1D5D910
						InputEnable();
					});
				};
				m_buttonItems[i].OnClickButton = m_buttonNextItem.OnClickButton;
			}
			Loaded();
			return true;
		}

		// // RVA: 0x1D5D4D8 Offset: 0x1D5D4D8 VA: 0x1D5D4D8
		private void OnBackButton()
		{
			for(int i = 0; i < m_buttonClose.Length; i++)
			{
				if((m_isGetAnim ? 1 : 0) == i && !m_buttonClose[i].IsInputOff && !m_buttonClose[i].Disable)
				{
					m_buttonClose[i].PerformClick();
				}
			}
		}
	}
}
