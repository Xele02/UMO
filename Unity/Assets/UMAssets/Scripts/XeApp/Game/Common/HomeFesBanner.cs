using UnityEngine;
using System;
using UnityEngine.UI;
using XeSys.Gfx;
using XeApp.Game.Menu;
using XeSys;

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
		private XeSys.FontInfo m_font; // 0x38
		private IKDICBBFBMI_EventBase m_controller; // 0x3C

		public string period { get; private set; } // 0x40
		public string status { get; private set; } // 0x44
		public Action onClickButton { private get; set; } // 0x48

		// RVA: 0xEAC1A8 Offset: 0xEAC1A8 VA: 0xEAC1A8
		public void SetFont(XeSys.FontInfo font)
		{
			m_font = font;
		}

		// // RVA: 0xEAC1B0 Offset: 0xEAC1B0 VA: 0xEAC1B0
		public void Setup(IKDICBBFBMI_EventBase cont, long currentTime)
		{
			if(cont != null)
			{
				long start = 0;
				if(cont.NGOFCFJHOMI_Status <= KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DOAENCHBAEO_11)
				{
					if(((int)cont.NGOFCFJHOMI_Status & 0xfe) == 0) // 1 to 7
					{
						if(((int)cont.NGOFCFJHOMI_Status & 0xc01) != 0) // 0/10/11
							return;
						start = cont.JDDFILGNGFH;
					}
					else
					{
						start = cont.GLIMIGNNGGB_Start;
					}
				}
				m_controller = cont;
				SetBanner(start, 0, currentTime, "");
				SetTicket(currentTime);
			}
		}

		// // RVA: 0xEAC288 Offset: 0xEAC288 VA: 0xEAC288
		public void SetBanner(long start, long end, long currentTime, string text = "")
		{
			SetIcon(m_controller, currentTime);
			if(currentTime >= start || start - currentTime == 0)
			{
				m_buttonBanner.Disable = false;
				SetPeriod("");
				SetStatus("");
			}
			else
			{
				int d, h, m, s;
				MusicSelectSceneBase.ExtractRemainTime((int)(start - currentTime), out d, out h, out m, out s);
				m_buttonBanner.Disable = true;
				SetPeriod("");
				SetStatus(MessageManager.Instance.GetMessage("menu", "home_fes_remain_prefix") + MusicSelectSceneBase.MakeRemainTime(d, h, m, s));
			}
			m_buttonBanner.ClearOnClickCallback();
			m_buttonBanner.AddOnClickCallback(() =>
			{
				//0xEACE58
				if(onClickButton != null)
					onClickButton();
			});
		}

		// // RVA: 0xEACA00 Offset: 0xEACA00 VA: 0xEACA00
		public void SetPeriod(string period)
		{
			this.period = period;
			if(period != "")
			{
				m_textPeriod.text = period;
				m_textPeriodSwitch.SetActive(true);
			}
			else
			{
				m_textPeriodSwitch.SetActive(false);
			}
		}

		// // RVA: 0xEACAE8 Offset: 0xEACAE8 VA: 0xEACAE8
		public void SetStatus(string text)
		{
			status = text;
			if(text != "")
			{
				m_textStatus.text = text;
				m_textStatusSwitch.SetActive(true);
			}
			else
			{
				m_textStatusSwitch.SetActive(false);
			}
		}

		// // RVA: 0xEAC7AC Offset: 0xEAC7AC VA: 0xEAC7AC
		public void SetIcon(IKDICBBFBMI_EventBase cont, long currentTime)
		{
			if(cont.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.OCCGDMDBCHK_EventGacha)
			{
				m_imageBannerIcon.sprite = m_tableReplace[2].sprite;
			}
			else if(cont.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp)
			{
				KNKDBNFMAKF_EventSp ev = cont as KNKDBNFMAKF_EventSp;
				if(ev.GEFCIHNPKIG())
				{
					long a, b;
					int v = ev.NJIKJJNLAPL(currentTime, out a, out b);
					if(v == 1)
					{
						m_imageBannerIcon.sprite = m_tableReplace[1].sprite;
					}
					else
					{
						m_imageBannerIcon.sprite = m_tableReplace[0].sprite;
					}
				}
				else
				{
					m_imageBannerIcon.sprite = m_tableReplace[0].sprite;
				}
			}
		}

		// // RVA: 0xEAC4E8 Offset: 0xEAC4E8 VA: 0xEAC4E8
		public void SetTicket(long currentTime)
		{
			if(m_controller == null)
				return;
			int v = m_controller.PGIIDPEGGPI_EventId;
			if(m_controller is KNKDBNFMAKF_EventSp)
			{
				if(!(m_controller as KNKDBNFMAKF_EventSp).BEDCLNJIEGF(currentTime))
					return;
				v = (m_controller as KNKDBNFMAKF_EventSp).CKBANLLONPF(currentTime);
			}
			else if(m_controller is CHHECNJBMLA_EventBoxGacha)
			{
				if(!(m_controller as CHHECNJBMLA_EventBoxGacha).BEDCLNJIEGF(currentTime))
					return;
			}
			else
			{
				return;
			}
			HGFPAFPGIKG h = new HGFPAFPGIKG(v);
			m_imageTicketIcon.enabled = false;
			GameManager.Instance.ItemTextureCache.Load(h.JHNEFBNEAAO, (IiconTexture texture) =>
			{
				//0xEACE6C
				m_imageTicketIcon.enabled = true;
				texture.Set(m_imageTicketIcon);
			});
			m_textTicketNum.text = string.Format(JpStringLiterals.StringLiteral_14007, h.MFHLHIDLKGN_NumTicket);
		}

		// // RVA: 0xEACBD0 Offset: 0xEACBD0 VA: 0xEACBD0
		public void SetActive(bool active)
		{
			if (active)
			{
				m_canvasGroup.alpha = 1;
				m_canvasGroup.interactable = true;
				m_canvasGroup.blocksRaycasts = true;
			}
			else
			{
				m_canvasGroup.alpha = 0;
				m_canvasGroup.interactable = false;
				m_canvasGroup.blocksRaycasts = false;
			}
		}

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
		public void Leave()
		{
			m_inOutAnime.Leave(false, null);
		}

		// // RVA: 0xEACD70 Offset: 0xEACD70 VA: 0xEACD70
		// public void Leave(float animTime) { }

		// // RVA: 0xEACDB8 Offset: 0xEACDB8 VA: 0xEACDB8
		public bool IsPlaying()
		{
			return m_inOutAnime.IsPlaying();
		}
	}
}
