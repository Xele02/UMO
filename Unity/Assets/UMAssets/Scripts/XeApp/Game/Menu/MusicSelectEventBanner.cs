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
		// private LayoutSymbolData m_symbolMain; // 0x34
		// private LayoutSymbolData m_symbolStatus; // 0x38
		// private string m_music_event_remain_prefix = ""; // 0x3C
		// private string m_music_event_remain_time = ""; // 0x40
		// private bool m_isDisabled; // 0x44
		// private bool m_isShow; // 0x4C

		public Action onClickBanner { private get; set; } // 0x48

		// // RVA: 0x1675AE4 Offset: 0x1675AE4 VA: 0x1675AE4
		public void TryEnter()
		{
			UnityEngine.Debug.LogError("TODO MusicSelectEventBanner TryEnter");
		}

		// // RVA: 0x1675B78 Offset: 0x1675B78 VA: 0x1675B78
		public void TryLeave()
		{
			UnityEngine.Debug.LogError("TODO MusicSelectEventBanner TryLeave");
		}

		// // RVA: 0x1675AF4 Offset: 0x1675AF4 VA: 0x1675AF4
		// public void Enter() { }

		// // RVA: 0x1675B88 Offset: 0x1675B88 VA: 0x1675B88
		// public void Leave() { }

		// // RVA: 0x1675C0C Offset: 0x1675C0C VA: 0x1675C0C
		// public void Show() { }

		// // RVA: 0x1675C90 Offset: 0x1675C90 VA: 0x1675C90
		public void Hide()
		{
			UnityEngine.Debug.LogError("TODO MusicSelectEventBanner Hide");
		}

		// // RVA: 0x1675D14 Offset: 0x1675D14 VA: 0x1675D14
		public bool IsPlaying()
		{
			UnityEngine.Debug.LogError("TODO MusicSelectEventBanner IsPlaying");
			return false;
		}

		// // RVA: 0x1675D40 Offset: 0x1675D40 VA: 0x1675D40
		// public void ChangeEventBanner(int eventId) { }

		// // RVA: 0x1675EA0 Offset: 0x1675EA0 VA: 0x1675EA0
		// public void SetEventTicket(IiconTexture image) { }

		// // RVA: 0x1675FB0 Offset: 0x1675FB0 VA: 0x1675FB0
		// public void SetDisableLabel(string label) { }

		// // RVA: 0x1675FEC Offset: 0x1675FEC VA: 0x1675FEC
		// public void SetMusicEventRemainPrefix(string a_text) { }

		// // RVA: 0x1676040 Offset: 0x1676040 VA: 0x1676040
		// public void SetLimitTimeLabel(string label) { }

		// // RVA: 0x1676090 Offset: 0x1676090 VA: 0x1676090
		// public void SetAttendEnable(bool enable) { }

		// // RVA: 0x1676094 Offset: 0x1676094 VA: 0x1676094
		// public void SetAttendLabel(string label) { }

		// // RVA: 0x1676098 Offset: 0x1676098 VA: 0x1676098
		public void SetStyle(MusicSelectEventBanner.Style style)
		{
			UnityEngine.Debug.LogError("TODO MusicSelectEventBanner SetStyle");
		}

		// // RVA: 0x1676218 Offset: 0x1676218 VA: 0x1676218
		// public void SetTicketCount(int count) { }

		// // RVA: 0x1676258 Offset: 0x1676258 VA: 0x1676258 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			UnityEngine.Debug.LogError("TODO InitializeFromLayout MusicSelectEventBanner");
			return true;
		}

		// [CompilerGeneratedAttribute] // RVA: 0x6F363C Offset: 0x6F363C VA: 0x6F363C
		// // RVA: 0x1676428 Offset: 0x1676428 VA: 0x1676428
		// private void <ChangeEventBanner>b__25_0(IiconTexture image) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F364C Offset: 0x6F364C VA: 0x6F364C
		// // RVA: 0x1676550 Offset: 0x1676550 VA: 0x1676550
		// private void <InitializeFromLayout>b__34_0() { }
	}
}
