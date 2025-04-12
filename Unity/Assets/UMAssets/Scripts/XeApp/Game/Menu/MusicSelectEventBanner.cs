using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System;

namespace XeApp.Game.Menu
{
	public class MusicSelectEventBanner : LayoutLabelScriptBase
	{
		public enum Style
		{
			Enable = 0,
			Disable = 1,
			Ticket = 2,
			Period = 3,
			Counting = 4,
			Raid = 5,
		}

		[SerializeField]
		private RawImageEx m_eventBannerImage; // 0x18
		[SerializeField]
		private RawImageEx m_eventTicketImage; // 0x1C
		[SerializeField]
		private RawImageEx m_timeImage; // 0x20
		[SerializeField]
		private ButtonBase m_bannerButton; // 0x24
		[SerializeField]
		private Text m_disabledText; // 0x28
		[SerializeField]
		private Text m_limitTimeText; // 0x2C
		[SerializeField]
		private NumberBase m_curTicketCount; // 0x30
		private LayoutSymbolData m_symbolMain; // 0x34
		private LayoutSymbolData m_symbolStatus; // 0x38
		private string m_music_event_remain_prefix = ""; // 0x3C
		private string m_music_event_remain_time = ""; // 0x40
		private bool m_isDisabled; // 0x44
		private bool m_isShow; // 0x4C

		public Action onClickBanner { private get; set; } // 0x48

		// // RVA: 0x1675AE4 Offset: 0x1675AE4 VA: 0x1675AE4
		public void TryEnter()
		{
			if(!m_isShow)
				Enter();
		}

		// // RVA: 0x1675B78 Offset: 0x1675B78 VA: 0x1675B78
		public void TryLeave()
		{
			if(m_isShow)
				Leave();
		}

		// // RVA: 0x1675AF4 Offset: 0x1675AF4 VA: 0x1675AF4
		public void Enter()
		{
			m_isShow = true;
			m_symbolMain.StartAnim("enter");
		}

		// // RVA: 0x1675B88 Offset: 0x1675B88 VA: 0x1675B88
		public void Leave()
		{
			m_isShow = false;
			m_symbolMain.StartAnim("leave");
		}

		// // RVA: 0x1675C0C Offset: 0x1675C0C VA: 0x1675C0C
		// public void Show() { }

		// // RVA: 0x1675C90 Offset: 0x1675C90 VA: 0x1675C90
		public void Hide()
		{
			m_isShow = false;
			m_symbolMain.StartAnim("wait");
		}

		// // RVA: 0x1675D14 Offset: 0x1675D14 VA: 0x1675D14
		public bool IsPlaying()
		{
			return m_symbolMain.IsPlaying();
		}

		// // RVA: 0x1675D40 Offset: 0x1675D40 VA: 0x1675D40
		public void ChangeEventBanner(int eventId)
		{
			m_bannerButton.Hidden = true;
			m_eventBannerImage.enabled = false;
			if(eventId != 0)
			{
				GameManager.Instance.EventBannerTextureCache.LoadBanner(eventId, (IiconTexture image) =>
				{
					//0x1676428
					image.Set(m_eventBannerImage);
					m_bannerButton.Hidden = false;
					m_eventBannerImage.enabled = true;
				});
			}
		}

		// // RVA: 0x1675EA0 Offset: 0x1675EA0 VA: 0x1675EA0
		public void SetEventTicket(IiconTexture image)
		{
			if(image == null)
				m_eventTicketImage.enabled = false;
			else
			{
				m_eventTicketImage.enabled = true;
				image.Set(m_eventTicketImage);
			}
		}

		// // RVA: 0x1675FB0 Offset: 0x1675FB0 VA: 0x1675FB0
		// public void SetDisableLabel(string label) { }

		// // RVA: 0x1675FEC Offset: 0x1675FEC VA: 0x1675FEC
		public void SetMusicEventRemainPrefix(string a_text)
		{
			m_music_event_remain_prefix = a_text;
			m_limitTimeText.text = a_text + m_music_event_remain_time;
		}

		// // RVA: 0x1676040 Offset: 0x1676040 VA: 0x1676040
		public void SetLimitTimeLabel(string label)
		{
			m_music_event_remain_time = label;
			m_limitTimeText.text = m_music_event_remain_prefix + label;
		}

		// // RVA: 0x1676090 Offset: 0x1676090 VA: 0x1676090
		// public void SetAttendEnable(bool enable) { }

		// // RVA: 0x1676094 Offset: 0x1676094 VA: 0x1676094
		// public void SetAttendLabel(string label) { }

		// // RVA: 0x1676098 Offset: 0x1676098 VA: 0x1676098
		public void SetStyle(Style style)
		{
			switch(style)
			{
				case Style.Enable:
					m_symbolStatus.StartAnim("enable");
					m_isDisabled = false;
					break;
				case Style.Disable:
					m_symbolStatus.StartAnim("disable");
					m_isDisabled = true;
					break;
				case Style.Ticket:
					m_symbolStatus.StartAnim("ticket");
					m_isDisabled = false;
					break;
				case Style.Period:
					m_symbolStatus.StartAnim("period");
					m_isDisabled = true;
					break;
				case Style.Counting:
					m_symbolStatus.StartAnim("counting");
					m_isDisabled = false;
					break;
				case Style.Raid:
					m_symbolStatus.StartAnim("raid");
					m_isDisabled = false;
					break;
				default:
					break;
			}
		}

		// // RVA: 0x1676218 Offset: 0x1676218 VA: 0x1676218
		// public void SetTicketCount(int count) { }

		// // RVA: 0x1676258 Offset: 0x1676258 VA: 0x1676258 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_symbolMain = CreateSymbol("main", layout);
			m_symbolStatus = CreateSymbol("status", layout);
			m_bannerButton.ClearOnClickCallback();
			m_bannerButton.AddOnClickCallback(() =>
			{
				//0x1676550
				if(!m_isDisabled)
				{
					if(onClickBanner != null)
						onClickBanner();
				}
			});
			m_eventTicketImage.enabled = false;
			Loaded();
			return true;
		}
	}
}
