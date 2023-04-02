using UnityEngine;
using System;
using UnityEngine.UI;
using XeSys.Gfx;

namespace XeApp.Game.Common
{
	public class HomeFesBanner : MonoBehaviour
	{
		public enum Style
		{
			Fes = 0,
			EveFes = 1,
			Kuzi = 2,
			Num = 3,
		}

		[Serializable]
		public class ReplaceInfo
		{
			public string name; // 0x8
			public Sprite sprite; // 0xC
		}

		// [HeaderAttribute] // RVA: 0x689FAC Offset: 0x689FAC VA: 0x689FAC
		[SerializeField]
		private ReplaceInfo[] m_tableReplace = new ReplaceInfo[3]; // 0xC
		// [HeaderAttribute] // RVA: 0x689FF4 Offset: 0x689FF4 VA: 0x689FF4
		[SerializeField]
		private Image m_imageBannerIcon; // 0x10
		// [HeaderAttribute] // RVA: 0x68A044 Offset: 0x68A044 VA: 0x68A044
		[SerializeField]
		private ButtonBase m_buttonBanner; // 0x14
		// [HeaderAttribute] // RVA: 0x68A08C Offset: 0x68A08C VA: 0x68A08C
		[SerializeField]
		private GameObject m_textPeriodSwitch; // 0x18
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x68A0EC Offset: 0x68A0EC VA: 0x68A0EC
		private Text m_textPeriod; // 0x1C
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x68A154 Offset: 0x68A154 VA: 0x68A154
		private GameObject m_textStatusSwitch; // 0x20
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x68A19C Offset: 0x68A19C VA: 0x68A19C
		private Text m_textStatus; // 0x24
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x68A1E4 Offset: 0x68A1E4 VA: 0x68A1E4
		private RawImageEx m_imageTicketIcon; // 0x28
		// [HeaderAttribute] // RVA: 0x68A250 Offset: 0x68A250 VA: 0x68A250
		[SerializeField]
		private Text m_textTicketNum; // 0x2C
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x68A2A4 Offset: 0x68A2A4 VA: 0x68A2A4
		private InOutAnime m_inOutAnime; // 0x30
		// [HeaderAttribute] // RVA: 0x68A2EC Offset: 0x68A2EC VA: 0x68A2EC
		[SerializeField]
		private CanvasGroup m_canvasGroup; // 0x34
		private Font m_font; // 0x38
		private IKDICBBFBMI_EventBase m_controller; // 0x3C

		public string period { get; private set; } // 0x40
		public string status { get; private set; } // 0x44
		public Action onClickButton { private get; set; } // 0x48

		// RVA: 0xEAC1A8 Offset: 0xEAC1A8 VA: 0xEAC1A8
		public void SetFont(Font font)
		{
			m_font = font;
		}

		// // RVA: 0xEAC1B0 Offset: 0xEAC1B0 VA: 0xEAC1B0
		// public void Setup(IKDICBBFBMI cont, long currentTime) { }

		// // RVA: 0xEAC288 Offset: 0xEAC288 VA: 0xEAC288
		// public void SetBanner(long start, long end, long currentTime, string text = "") { }

		// // RVA: 0xEACA00 Offset: 0xEACA00 VA: 0xEACA00
		// public void SetPeriod(string period) { }

		// // RVA: 0xEACAE8 Offset: 0xEACAE8 VA: 0xEACAE8
		// public void SetStatus(string text) { }

		// // RVA: 0xEAC7AC Offset: 0xEAC7AC VA: 0xEAC7AC
		// public void SetIcon(IKDICBBFBMI cont, long currentTime) { }

		// // RVA: 0xEAC4E8 Offset: 0xEAC4E8 VA: 0xEAC4E8
		// public void SetTicket(long currentTime) { }

		// // RVA: 0xEACBD0 Offset: 0xEACBD0 VA: 0xEACBD0
		// public void SetActive(bool active) { }

		// // RVA: 0xEACCA8 Offset: 0xEACCA8 VA: 0xEACCA8
		public void Enter()
		{
			if(m_controller == null)
				return;
			m_inOutAnime.Enter(false, null);
		}

		// // RVA: 0xEACCE8 Offset: 0xEACCE8 VA: 0xEACCE8
		// public void Enter(float animTime) { }

		// // RVA: 0xEACD3C Offset: 0xEACD3C VA: 0xEACD3C
		// public void Leave() { }

		// // RVA: 0xEACD70 Offset: 0xEACD70 VA: 0xEACD70
		// public void Leave(float animTime) { }

		// // RVA: 0xEACDB8 Offset: 0xEACDB8 VA: 0xEACDB8
		// public bool IsPlaying() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73D614 Offset: 0x73D614 VA: 0x73D614
		// // RVA: 0xEACE58 Offset: 0xEACE58 VA: 0xEACE58
		// private void <SetBanner>b__29_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73D624 Offset: 0x73D624 VA: 0x73D624
		// // RVA: 0xEACE6C Offset: 0xEACE6C VA: 0xEACE6C
		// private void <SetTicket>b__33_0(IiconTexture texture) { }
	}
}
