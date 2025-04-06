using System;
using System.Collections.Generic;
using mcrs;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Menu;
using XeSys;

namespace XeApp.Game.Common
{
	public class HomeEventBanner : MonoBehaviour
	{
		
		// [HeaderAttribute] // RVA: 0x689C28 Offset: 0x689C28 VA: 0x689C28
		[SerializeField]
		private float m_autoScrollWait = 0.5f; // 0xC
		// [HeaderAttribute] // RVA: 0x689C70 Offset: 0x689C70 VA: 0x689C70
		[SerializeField]
		private GridLayoutGroup m_gridLayoutGroup; // 0x10
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x689CE4 Offset: 0x689CE4 VA: 0x689CE4
		private BannerScrollView m_scrollView; // 0x14
		// [HeaderAttribute] // RVA: 0x689D2C Offset: 0x689D2C VA: 0x689D2C
		[SerializeField]
		private HomeEventBannerContent m_objBanner; // 0x18
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x689D74 Offset: 0x689D74 VA: 0x689D74
		private Transform m_rootPageIcon; // 0x1C
		[SerializeField]
		private Toggle m_basePageIcon; // 0x20
		// [HeaderAttribute] // RVA: 0x689DEC Offset: 0x689DEC VA: 0x689DEC
		[SerializeField]
		private ButtonBase m_buttonLeft; // 0x24
		// [HeaderAttribute] // RVA: 0x689E3C Offset: 0x689E3C VA: 0x689E3C
		[SerializeField]
		private ButtonBase m_buttonRight; // 0x28
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x689E8C Offset: 0x689E8C VA: 0x689E8C
		private InOutAnime m_inOutAnime; // 0x2C
		// [HeaderAttribute] // RVA: 0x689ED4 Offset: 0x689ED4 VA: 0x689ED4
		[SerializeField]
		private CanvasGroup m_canvasGroup; // 0x30
		private XeSys.FontInfo m_font; // 0x34
		private int m_inputDisableCount; // 0x38
		private List<Toggle> m_listPageIcon = new List<Toggle>(); // 0x3C

		public Action<int> onClickBannerButton { private get; set; } // 0x40

		// RVA: 0xEA9268 Offset: 0xEA9268 VA: 0xEA9268
		private void Start()
		{
			m_buttonLeft.ClearOnClickCallback();
			m_buttonLeft.AddOnClickCallback(() => {
				//0xEABAC4
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				ChangeBanner(-1, 0.1f);
			});
			m_buttonRight.ClearLoadedCallback();
			m_buttonRight.AddOnClickCallback(() => {
				//0xEABB34
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				ChangeBanner(1, 0.1f);
			});
			m_scrollView.OnChangeItem = (int idx) => {
				//0xEABBA4
				UpdatePageIcon(idx);
				InputDisable();
			};
			m_scrollView.OnChangeEndItem = (int idx) => {
				//0xEABBC0
				UpdatePageIcon(idx);
				InputEnable();
			};
			InitScrollType();
		}

		// RVA: 0xEA9710 Offset: 0xEA9710 VA: 0xEA9710
		public void SetFont(XeSys.FontInfo font)
		{
			m_font = font;
		}

		// // RVA: 0xEA9718 Offset: 0xEA9718 VA: 0xEA9718
		public void Setup(IKDICBBFBMI_EventBase cont, long currentTime)
		{
			List<IKDICBBFBMI_EventBase> l = new List<IKDICBBFBMI_EventBase>();
			if(cont != null)
				l.Add(cont);
			Setup(l, currentTime);
		}

		// // RVA: 0xEA97F0 Offset: 0xEA97F0 VA: 0xEA97F0
		public void Setup(List<IKDICBBFBMI_EventBase> list, long currentTime)
		{
			ClearBanner();
			int cnt = 0;
			bool b = MenuScene.Instance.LobbyButtonControl.CheckLobbyAnnounce();
			for(int i = 0; i < list.Count; i++)
			{
				if(!b && OHCAABOMEOF.BPJMGICFPBJ(list[i].PGIIDPEGGPI_EventId) != OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid)
				{
					MessageBank bk = MessageManager.Instance.GetBank("menu");
					long l1, l2;
					string str;
					if(list[i].NGOFCFJHOMI_Status <= KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DOAENCHBAEO_11)
					{
						if(((1 << (int)list[i].NGOFCFJHOMI_Status) & 0xf03U) != 0)
							// 1111 0000 0011
						{
							continue;
						}
						else if(((1 << (int)list[i].NGOFCFJHOMI_Status) & 0x3cU) != 0)
							// 11 1100
						{
							l1 = list[i].GLIMIGNNGGB_Start;
							l2 = list[i].DPJCPDKALGI_End1;
							str = "home_event_counting";
						}
						else
						{
							l1 = list[i].GLIMIGNNGGB_Start;
							l2 = list[i].DPJCPDKALGI_End1;
							str = "home_event_started";
						}
						str = bk.GetMessageByLabel(str);
					}
					else
					{
						l1 = 0;
						l2 = 0;
						str = "";
					}
					PKNOKJNLPOE_EventRaid evRaid = list[i] as PKNOKJNLPOE_EventRaid;
					if(evRaid != null)
					{
						TodoLogger.LogError(TodoLogger.EventRaid_11_13, "Raid");
					}
					MANPIONIGNO_EventGoDiva evGoDiva = list[i] as MANPIONIGNO_EventGoDiva;
					if(evGoDiva != null && evGoDiva.KBKGHDFBHAP_GetBonusEndTime(currentTime) != 0)
					{
						str = bk.GetMessageByLabel("banner_godiva_fevertime");
					}
					//LAB_00ea9d4c
					string s = list[i].DBEMCLMPCFA_GetBannerText();
					if(!string.IsNullOrEmpty(s))
						str = s;
					AddBanner(list[i].PGIIDPEGGPI_EventId, l1, l2, str);
				}
			}
			m_scrollView.horizontal = cnt > 1;
		}

		// // RVA: 0xEAA048 Offset: 0xEAA048 VA: 0xEAA048
		public void AddBanner(int id, long start, long end, string text = "")
		{
			SelectScrollViewContent s = m_scrollView.scrollObjects.Find((SelectScrollViewContent x) =>
			{
				//0xEABDB8
				return id == (x as BannerScrollViewContent).pictId;
			});
			if(s == null)
			{
				string str = "";
				if(start != 0 && end != 0)
				{
					DateTime dStart = Utility.GetLocalDateTime(start);
					DateTime dEnd = Utility.GetLocalDateTime(end);
					str = string.Format(MessageManager.Instance.GetMessage("menu", "home_event_banner_period"), new object[8]
					{
						dStart.Month, dStart.Day, dStart.Hour, dStart.Minute,
						dEnd.Month, dEnd.Day, dEnd.Hour, dEnd.Minute
					});
				}
				HomeEventBannerContent content = Instantiate(m_objBanner);
				content.SetFont(m_font);
				content.SetPeriod(str);
				content.SetCampaignInfo(text);
				content.SetTexture(id, (int pictId, Action<IiconTexture> onLoaded) =>
				{
					//0xEABCEC
					GameManager.Instance.QuestEventTextureCache.LoadFont(pictId, onLoaded);
				});
				content.onClickButton = (int pictId) =>
				{
					//0xEABEC0
					if(onClickBannerButton != null)
					{
						onClickBannerButton(pictId);
					}
				};
				AddPageIcon(content);
				m_scrollView.AddScrollObject(content);
				m_scrollView.SetItemCount(m_scrollView.scrollObjects.Count);
				m_buttonLeft.gameObject.SetActive(m_scrollView.scrollObjects.Count > 1);
				m_buttonRight.gameObject.SetActive(m_scrollView.scrollObjects.Count > 1);
				InitScrollType();
			}
		}

		// // RVA: 0xEAADE4 Offset: 0xEAADE4 VA: 0xEAADE4
		public void RemoveBanner(int id)
		{
			SelectScrollViewContent s = m_scrollView.scrollObjects.Find((SelectScrollViewContent x) =>
			{
				//0xEABF74
				BannerScrollViewContent c = x as BannerScrollViewContent;
				return c.pictId == id;
			});
			if(s != null)
			{
				RemovePageIcon(s);
				m_scrollView.RemoveScrollObject(s);
				m_scrollView.SetItemCount(m_scrollView.scrollObjects.Count);
				DestroyImmediate(s.gameObject);
				InitScrollType();
			}
		}

		// // RVA: 0xEA9EE0 Offset: 0xEA9EE0 VA: 0xEA9EE0
		public void ClearBanner()
		{
			for(int i = 0; i < m_scrollView.scrollObjects.Count; i++)
			{
				BannerScrollViewContent c = m_scrollView.scrollObjects[i] as BannerScrollViewContent;
				RemoveBanner(c.pictId);
			}
		}

		// // RVA: 0xEAB328 Offset: 0xEAB328 VA: 0xEAB328
		private void InputEnable()
		{
			m_inputDisableCount = Mathf.Max(m_inputDisableCount - 1, 0);
			m_buttonLeft.enabled = m_inputDisableCount == 0;
			m_buttonRight.enabled = m_inputDisableCount == 0;
		}

		// // RVA: 0xEAB418 Offset: 0xEAB418 VA: 0xEAB418
		private void InputDisable()
		{
			m_inputDisableCount = Mathf.Max(m_inputDisableCount + 1, 0);
			m_buttonLeft.enabled = m_inputDisableCount == 0;
			m_buttonRight.enabled = m_inputDisableCount == 0;
		}

		// // RVA: 0xEAABE0 Offset: 0xEAABE0 VA: 0xEAABE0
		private void AddPageIcon(SelectScrollViewContent content)
		{
			Toggle t = Instantiate(m_basePageIcon);
			t.transform.SetParent(m_rootPageIcon, false);
			m_listPageIcon.Add(t);
			for(int i = 0; i < m_listPageIcon.Count; i++)
			{
				m_listPageIcon[i].gameObject.SetActive(m_listPageIcon.Count > 1);
			}
		}

		// // RVA: 0xEAB054 Offset: 0xEAB054 VA: 0xEAB054
		public void RemovePageIcon(SelectScrollViewContent content)
		{
			int idx = m_scrollView.scrollObjects.FindIndex((SelectScrollViewContent x) =>
			{
				//0xEAC07C
				return x == content;
			});
			if(idx > -1)
			{
				Destroy(m_listPageIcon[idx].gameObject);
				m_listPageIcon.RemoveAt(idx);
			}
			for(int i = 0; i < m_listPageIcon.Count; i++)
			{
				m_listPageIcon[i].gameObject.SetActive(m_listPageIcon.Count > 1);
			}
		}

		// // RVA: 0xEAB510 Offset: 0xEAB510 VA: 0xEAB510
		private void UpdatePageIcon(int index)
		{
			for(int i = 0; i < m_listPageIcon.Count; i++)
			{
				m_listPageIcon[i].isOn = index == i;
			}
		}

		// // RVA: 0xEA9484 Offset: 0xEA9484 VA: 0xEA9484
		private void InitScrollType()
		{
			Vector2 pos = m_scrollView.content.anchoredPosition;
			m_scrollView.content.anchoredPosition = new Vector2(pos.x, 0);
			m_scrollView.horizontal = true;
			m_scrollView.vertical = false;
			m_scrollView.horizontalNormalizedPosition = 0;
			m_scrollView.SetPosition(0, 0);
			m_scrollView.SetAutoScroll(m_autoScrollWait);
			m_gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
			m_gridLayoutGroup.constraintCount = m_scrollView.scrollObjects.Count;
			m_rootPageIcon.gameObject.SetActive(true);
		}

		// // RVA: 0xEAB5FC Offset: 0xEAB5FC VA: 0xEAB5FC
		private void ChangeBanner(int dir, float animTime)
		{
			int cur = m_scrollView.index;
			int max = m_scrollView.scrollObjects.Count;
			cur += dir;
			if(cur > max)
				cur = 0;
			else if(cur < 0)
				cur = max - 1;
			m_scrollView.SetPosition(cur, animTime);
		}

		// // RVA: 0xEAB708 Offset: 0xEAB708 VA: 0xEAB708
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

		// // RVA: 0xEAB7E0 Offset: 0xEAB7E0 VA: 0xEAB7E0
		public void Enter()
		{
			if(m_scrollView.scrollObjects.Count < 1)
				return;
			m_inOutAnime.Enter(false, null);
		}

		// // RVA: 0xEAB8A8 Offset: 0xEAB8A8 VA: 0xEAB8A8
		// public void Enter(float animTime) { }

		// // RVA: 0xEAB984 Offset: 0xEAB984 VA: 0xEAB984
		public void Leave()
		{
			m_inOutAnime.Leave(false, null);
		}

		// // RVA: 0xEAB9B8 Offset: 0xEAB9B8 VA: 0xEAB9B8
		// public void Leave(float animTime) { }

		// // RVA: 0xEABA00 Offset: 0xEABA00 VA: 0xEABA00
		public bool IsPlaying()
		{
			return m_inOutAnime.IsPlaying();
		}
	}
}
