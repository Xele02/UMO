using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys.Gfx;
using XeSys;

namespace XeApp.Game.Menu
{
	public class PopupEpisodeBonusList : UIBehaviour, IPopupContent, ILayoutUGUIPaste
	{
		private Transform parent; // 0xC
		[SerializeField]
		private EpisodeLayoutParts[] m_episodeLayoutParts; // 0x10
		[SerializeField]
		private Text m_episodePointText; // 0x14
		[SerializeField]
		private Text m_episodePointNoteText; // 0x18
		[SerializeField]
		private ActionButton[] m_episodeButtons; // 0x1C
		private PopupEpisodeBonusListSetting m_setting; // 0x20
		private int m_loadCount; // 0x24
		private int m_loadedCount; // 0x28
		private PopupEpisodeBonusPlateSortList m_plateEpisodeList = new PopupEpisodeBonusPlateSortList(); // 0x2C
		private HomeBannerTextureCache m_homeBannerTextureCache; // 0x30

		public Transform Parent { get { return parent; } } //0xF85C40

		// RVA: 0xF845CC Offset: 0xF845CC VA: 0xF845CC Slot: 25
		public virtual bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			for(int i = 0; i < m_episodeLayoutParts.Length; i++)
			{
				m_episodeLayoutParts[i].rootLayout = layout.FindViewByExId(string.Format("sw_pop_ep_eve_swtbl_episode_{0:D2}", i + 1)) as AbsoluteLayout;
				m_episodeLayoutParts[i].frameLayout = m_episodeLayoutParts[i].rootLayout.FindViewByExId("sw_episode_swtbl_ep_eve_cursor_01") as AbsoluteLayout;
				m_episodeLayoutParts[i].assistLayout = m_episodeLayoutParts[i].rootLayout.FindViewByExId("sw_episode_sw_assist_onoff_anim") as AbsoluteLayout;
			}
			m_homeBannerTextureCache = new HomeBannerTextureCache();
			return true;
		}

		// RVA: 0xF84988 Offset: 0xF84988 VA: 0xF84988 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			RectTransform rt = GetComponent<RectTransform>();
			m_setting = setting as PopupEpisodeBonusListSetting;
			parent = setting.m_parent;
			m_plateEpisodeList.bannerTexCache = m_homeBannerTextureCache;
			m_plateEpisodeList.Initialize(parent, this);
			rt.sizeDelta = new Vector2(980, 460);
			Initialize();
			gameObject.SetActive(true);
		}

		// RVA: 0xF85BE0 Offset: 0xF85BE0 VA: 0xF85BE0 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0xF85BE8 Offset: 0xF85BE8 VA: 0xF85BE8 Slot: 19
		public void Show()
		{
			return;
		}

		// RVA: 0xF85BEC Offset: 0xF85BEC VA: 0xF85BEC Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0xF85C24 Offset: 0xF85C24 VA: 0xF85C24 Slot: 21
		public bool IsReady()
		{
			return m_loadCount == m_loadedCount;
		}

		// RVA: 0xF85C3C Offset: 0xF85C3C VA: 0xF85C3C Slot: 22
		public void CallOpenEnd()
		{
			return;
		}

		// RVA: 0xF84D78 Offset: 0xF84D78 VA: 0xF84D78
		private void Initialize()
		{
			m_loadCount = 0;
			m_loadedCount = 0;
			for(int i = 0; i < m_episodeButtons.Length; i++)
			{
				m_episodeButtons[i].ClearOnClickCallback();
			}
			int bonusValueTotal = 0;
			for(int i = 0; i < m_setting.EpisodeList.Count; i++)
			{
				if(m_setting.EpisodeList[i].KELFCMEOPPM_EpisodeId != 0)
				{
					int idx = m_loadCount;
					int episodeId = m_setting.EpisodeList[i].KELFCMEOPPM_EpisodeId;
					m_loadCount++;
					GameManager.Instance.EpisodeIconCache.LoadBg(episodeId, (IiconTexture texture) =>
					{
						//0xF85DBC
						texture.Set(m_episodeLayoutParts[idx].episodeImage);
						m_loadedCount++;
					});
					m_episodeLayoutParts[idx].rootLayout.StartChildrenAnimGoStop("01");
					m_episodeLayoutParts[idx].rootLayout.StartAllAnimDecoLoop();
					m_episodeLayoutParts[idx].episodeNameText.text = PIGBBNDPPJC.EJOJNFDHDHN_GetEpName(episodeId);
					int bonusMax = -1;
					CIKHPBBNEIM.ODGCADPPIFA d = new CIKHPBBNEIM.ODGCADPPIFA();
					CIKHPBBNEIM.PBJEFDNBBCD p = m_setting.ViewEpisodeBonus.GGHMLFOFELH(episodeId);
					bool fromAssist = false;
					bool b21 = false;
					bool possessed = false;
					for(int j = 0; j < p.FLJNOOPOAGI.Count; j++)
					{
						bonusMax = Mathf.Max(bonusMax, p.FLJNOOPOAGI[j].ALDAOOLPHCH_BonusAfter);
						if(p.FLJNOOPOAGI[j].ILOKENBBBAE_Available)
						{
							b21 = true;
							fromAssist |= p.FLJNOOPOAGI[j].GKBNFLFEIOF_IsAssist;
						}
						possessed |= p.FLJNOOPOAGI[j].IADCHIFJHOJ_Unlocked;
					}
					if(m_setting.EpisodeList[i].JKDJCFEBDHC_BonusEnabled)
					{
						bonusValueTotal += m_setting.EpisodeList[i].HEDODOBGPPM_BonusValue;
					}
					bonusValueTotal = Mathf.Min(999, bonusValueTotal);
					m_episodeLayoutParts[idx].bonusPointMaxText.text = string.Format(MessageManager.Instance.GetMessage("menu", "popup_episodebonus_max"), bonusMax);
					if(RuntimeSettings.CurrentSettings.Language != "jp")
					{
						m_episodeLayoutParts[idx].bonusPointText.resizeTextForBestFit = true;
						m_episodeLayoutParts[idx].bonusPointText.resizeTextMinSize = 1;
						m_episodeLayoutParts[idx].bonusPointText.resizeTextMaxSize = m_episodeLayoutParts[idx].bonusPointText.fontSize;
						m_episodeLayoutParts[idx].bonusPointText.horizontalOverflow = HorizontalWrapMode.Wrap;
						m_episodeLayoutParts[idx].bonusPointText.verticalOverflow = VerticalWrapMode.Truncate;
					}
					if(b21)
					{
						m_episodeLayoutParts[idx].bonusPointText.text = string.Format("+{0}%", m_setting.EpisodeList[i].HEDODOBGPPM_BonusValue);
						m_episodeLayoutParts[idx].frameLayout.StartChildrenAnimGoStop("01");
					}
					else if(!possessed)
					{
						m_episodeLayoutParts[idx].bonusPointText.text = MessageManager.Instance.GetMessage("menu", "not_possessed");
						m_episodeLayoutParts[idx].frameLayout.StartChildrenAnimGoStop("03");
					}
					else
					{
						m_episodeLayoutParts[idx].bonusPointText.text = MessageManager.Instance.GetMessage("menu", "unorganized");
						m_episodeLayoutParts[idx].frameLayout.StartChildrenAnimGoStop("02");
					}
					if(!fromAssist)
						m_episodeLayoutParts[idx].assistLayout.StartAllAnimGoStop("02");
					else
					{
						m_episodeLayoutParts[idx].assistLayout.StartAllAnimGoStop("01");
						m_episodeLayoutParts[idx].assistText.text = MessageManager.Instance.GetMessage("menu", "episode_assist");
					}
					m_episodeButtons[idx].AddOnClickCallback(() =>
					{
						//0xF85F1C
						SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
						m_plateEpisodeList.Setup(episodeId, m_setting.ViewEpisodeBonus);
						m_plateEpisodeList.Show();
					});
				}
			}
			for(int i = m_loadCount; i < m_episodeLayoutParts.Length; i++)
			{
				m_episodeLayoutParts[i].rootLayout.StartChildrenAnimGoStop("02");
			}
			m_episodePointText.text = string.Format("{0}<color={2}>{1}</color>%", bonusValueTotal > 0 ? "+" : "", bonusValueTotal, SystemTextColor.ImportantColor);
			m_episodePointNoteText.text = MessageManager.Instance.GetMessage("menu", "popup_episodebonus_note_01");
		}

		// RVA: 0xF85C60 Offset: 0xF85C60 VA: 0xF85C60
		private void Update()
		{
			if(m_homeBannerTextureCache != null)
				m_homeBannerTextureCache.Update();
		}

		// RVA: 0xF85C74 Offset: 0xF85C74 VA: 0xF85C74 Slot: 8
		protected override void OnDestroy()
		{
			base.OnDestroy();
			if(m_homeBannerTextureCache != null)
				m_homeBannerTextureCache.Terminated();
		}
	}
}
