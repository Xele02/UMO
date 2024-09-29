using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using TMPro;
using XeSys.Gfx;
using System;
using System.Text;
using XeApp.Game.Menu;
using System.Collections.Generic;

namespace XeApp.Game.MusicSelect
{
	public class MusicScrollCenterItem : MonoBehaviour
	{
		public enum ListType
		{
			Normal = 0,
			EventEntrance = 1,
			LimitedSLive = 2,
			HighLevel = 3,
		}

		//[HeaderAttribute] // RVA: 0x665A54 Offset: 0x665A54 VA: 0x665A54
		[SerializeField]
		private Text m_musicName; // 0xC
		[SerializeField]
		private Text m_musicNameAlt; // 0xC
		//[HeaderAttribute] // RVA: 0x665A9C Offset: 0x665A9C VA: 0x665A9C
		[SerializeField]
		private Text m_singerNameText; // 0x10
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x665AE8 Offset: 0x665AE8 VA: 0x665AE8
		private UGUIButton m_rewardButton; // 0x14
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x665B30 Offset: 0x665B30 VA: 0x665B30
		private UGUIButton m_rankingButton; // 0x18
		//[HeaderAttribute] // RVA: 0x665B78 Offset: 0x665B78 VA: 0x665B78
		[SerializeField]
		private UGUIButton m_musicInfoButton; // 0x1C
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x665BD0 Offset: 0x665BD0 VA: 0x665BD0
		private UGUIButton m_enemyInfoButton; // 0x20
		[SerializeField]
		private XeApp.Game.Common.ScrollText m_musicNameScroll; // 0x24
		[SerializeField]
		private XeApp.Game.Common.ScrollText m_musicNameAltScroll; // 0x24
		[SerializeField]
		private XeApp.Game.Common.ScrollText m_singerNameScroll; // 0x28
		[SerializeField]
		private XeApp.Game.Common.ScrollText m_eventNameScroll; // 0x2C
		[SerializeField]
		private XeApp.Game.Common.ScrollText m_eventDescScroll; // 0x30
		[SerializeField]
		private Image m_newIcon; // 0x34
		[SerializeField]
		private TextMeshProUGUI m_musicListNo; // 0x38
		[SerializeField]
		private MusicScrollItemLabelGroup m_labelGroup; // 0x3C
		[SerializeField]
		private RawImageEx m_seriesLogo; // 0x40
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x665CA4 Offset: 0x665CA4 VA: 0x665CA4
		private Image m_attrIcon; // 0x44
		[SerializeField]
		private MusicAttrIconScriptableObject m_attrIconSet; // 0x48
		//[HeaderAttribute] // RVA: 0x665CFC Offset: 0x665CFC VA: 0x665CFC
		[SerializeField]
		private Image m_attrBack; // 0x4C
		[SerializeField]
		private MusicAttrIconScriptableObject m_attrBackSet; // 0x50
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x665D5C Offset: 0x665D5C VA: 0x665D5C
		private Image m_attrArrow; // 0x54
		[SerializeField]
		private MusicAttrIconScriptableObject m_attrArrowSet; // 0x58
		//[HeaderAttribute] // RVA: 0x665DBC Offset: 0x665DBC VA: 0x665DBC
		[SerializeField]
		private CanvasGroup m_lockObj; // 0x5C
		[SerializeField]
		private Image m_unlockableImage; // 0x60
		//[HeaderAttribute] // RVA: 0x665E14 Offset: 0x665E14 VA: 0x665E14
		[SerializeField]
		private CanvasGroup m_rewardObj; // 0x64
		[SerializeField]
		private Image m_scoreReward; // 0x68
		[SerializeField]
		private Image m_comboReward; // 0x6C
		[SerializeField]
		private Image m_clearCountReward; // 0x70
		//[HeaderAttribute] // RVA: 0x665E8C Offset: 0x665E8C VA: 0x665E8C
		[SerializeField]
		private Text m_eventName; // 0x74
		[SerializeField]
		private Text m_eventDesc; // 0x78
		[SerializeField]
		private Text m_eventPeriod; // 0x7C
		//[HeaderAttribute] // RVA: 0x665EF4 Offset: 0x665EF4 VA: 0x665EF4
		[SerializeField]
		private CanvasGroup m_highLevelObj; // 0x80
		[SerializeField]
		private Text m_highLevelMusicName; // 0x84
		[SerializeField]
		private Text m_highLevelSingerName; // 0x88
		[SerializeField]
		private XeApp.Game.Common.ScrollText m_highLevelMusicNameScroll; // 0x8C
		[SerializeField]
		private XeApp.Game.Common.ScrollText m_highLevelSingerNameScroll; // 0x90
		private StringBuilder m_musicNumSb = new StringBuilder(); // 0xA4
		private string m_musicNumSign = " / "; // 0xA8

		public MusicScrollItemLabelGroup LabelGroup { get { return m_labelGroup; } } //0xC9C80C
		public Action OnRewardButtonClickListener { private get; set; } // 0x94
		public Action OnRankingButtonClickListener { private get; set; } // 0x98
		public Action OnMusicInfoButtonClickListener { private get; set; } // 0x9C
		public Action OnEnemyInfoButtonClickListener { private get; set; } // 0xA0

		//// RVA: 0xC9C854 Offset: 0xC9C854 VA: 0xC9C854
		private void Awake()
		{
			m_rewardButton.ClearOnClickCallback();
			m_rewardButton.AddOnClickCallback(() =>
			{
				//0xC9DCDC
				if (OnRewardButtonClickListener != null)
					OnRewardButtonClickListener();
			});
			m_rankingButton.ClearOnClickCallback();
			m_rankingButton.AddOnClickCallback(() =>
			{
				//0xC9DCF0
				if (OnRankingButtonClickListener != null)
					OnRankingButtonClickListener();
			});
			m_musicInfoButton.ClearOnClickCallback();
			m_musicInfoButton.AddOnClickCallback(() =>
			{
				//0xC9DD04
				if (OnMusicInfoButtonClickListener != null)
					OnMusicInfoButtonClickListener();
			});
			m_enemyInfoButton.ClearOnClickCallback();
			m_enemyInfoButton.AddOnClickCallback(() =>
			{
				//0xC9DD18
				if (OnEnemyInfoButtonClickListener != null)
					OnEnemyInfoButtonClickListener();
			});

			if(true)
			{
				m_singerNameText.fontSize = 14;
				m_singerNameText.transform.parent.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -10);
				m_singerNameText.transform.GetChild(0).GetComponent<Text>().fontSize = 14;
				m_musicName.transform.parent.GetComponent<RectTransform>().anchoredPosition = new Vector3(244, 10);
				m_rewardObj.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(222, 13);
				m_attrIcon.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(-246, 17);
				
				GameObject musicAltMask = new GameObject("TitleMaskAlt");
				RectTransform rt = musicAltMask.AddComponent<RectTransform>();
				musicAltMask.transform.SetParent(m_musicName.transform.parent.parent, false);
				musicAltMask.transform.SetSiblingIndex(m_musicName.transform.parent.GetSiblingIndex());
				rt.pivot = new Vector3(0.5f, 0.5f);
				rt.anchorMin = new Vector3(0, 0.5f);
				rt.anchorMax = new Vector3(0, 0.5f);
				rt.anchoredPosition = new Vector3(244, 32);
				rt.sizeDelta = new Vector3(390, 45);
				musicAltMask.AddComponent<RectMask2D>();

				m_musicNameAlt = new GameObject("Title").AddComponent<Text>();
				m_musicNameAlt.rectTransform.SetParent(rt, false);
				m_musicNameAlt.rectTransform.anchoredPosition = new Vector3(0, 0);
				m_musicNameAlt.rectTransform.sizeDelta = new Vector3(450, 45);
				m_musicNameAlt.rectTransform.pivot = new Vector3(0, 1);
				m_musicNameAlt.rectTransform.anchorMin = new Vector3(0, 1);
				m_musicNameAlt.rectTransform.anchorMax = new Vector3(0, 1);
				m_musicNameAlt.font = m_musicName.font;
				m_musicNameAlt.supportRichText = m_musicName.supportRichText;
				m_musicNameAlt.alignment = m_musicName.alignment;
				m_musicNameAlt.horizontalOverflow = m_musicName.horizontalOverflow;
				m_musicNameAlt.verticalOverflow = m_musicName.verticalOverflow;
				m_musicNameAlt.color = m_musicName.color;
				m_musicNameAlt.fontSize = 16;

				Text m_musicNameAltCopy = new GameObject("copyText").AddComponent<Text>();
				m_musicNameAltCopy.rectTransform.SetParent(m_musicNameAlt.rectTransform, false);
				m_musicNameAltCopy.rectTransform.anchoredPosition = new Vector3(510, 0);
				m_musicNameAltCopy.rectTransform.sizeDelta = new Vector3(450, 45);
				m_musicNameAltCopy.rectTransform.pivot = new Vector3(0, 1);
				m_musicNameAltCopy.font = m_musicName.font;
				m_musicNameAltCopy.supportRichText = m_musicName.supportRichText;
				m_musicNameAltCopy.alignment = m_musicName.alignment;
				m_musicNameAltCopy.horizontalOverflow = m_musicName.horizontalOverflow;
				m_musicNameAltCopy.verticalOverflow = m_musicName.verticalOverflow;
				m_musicNameAltCopy.color = m_musicName.color;
				m_musicNameAltCopy.fontSize = 16;

				m_musicNameAltScroll = m_musicNameAlt.gameObject.AddComponent<Common.ScrollText>();
				m_musicNameAltScroll.Setup(m_musicNameAltCopy, 3, 30, 60);
			}
		}

		//// RVA: 0xC9CA90 Offset: 0xC9CA90 VA: 0xC9CA90
		public void ResetScroll()
		{
			m_musicNameScroll.ResetScroll();
			if(m_musicNameAltScroll != null)
				m_musicNameAltScroll.ResetScroll();
			m_singerNameScroll.ResetScroll();
			m_eventNameScroll.ResetScroll();
			m_eventDescScroll.ResetScroll();
			m_highLevelMusicNameScroll.ResetScroll();
			m_highLevelSingerNameScroll.ResetScroll();
		}

		//// RVA: 0xC9CB60 Offset: 0xC9CB60 VA: 0xC9CB60
		public void SetSeries(int logoType)
		{
			if (logoType < 1)
				return;
			GameManager.Instance.MenuResidentTextureCache.LoadLogo(logoType, (IiconTexture texture) =>
			{
				//0xC9DD2C 
				texture.Set(m_seriesLogo);
			});
		}

		//// RVA: 0xC9CC78 Offset: 0xC9CC78 VA: 0xC9CC78
		public void SetTitle(string title, string title_jp, string title_rm)
		{
			m_musicName.text = title;
			if(m_musicNameAlt != null)
			{
				List<string> txt = new List<string>() { title_rm, title_jp };
				txt.RemoveAll((x) => string.IsNullOrEmpty(x));
				m_musicNameAlt.text = string.Join(" / ", txt);
			}
		}

		//// RVA: 0xC9CCB4 Offset: 0xC9CCB4 VA: 0xC9CCB4
		public void SetHighLevelMusicTitle(string title)
		{
			m_highLevelMusicName.text = title;
		}

		//// RVA: 0xC9CCF0 Offset: 0xC9CCF0 VA: 0xC9CCF0
		public void SetEventName(string text)
		{
			m_eventName.text = text;
		}

		//// RVA: 0xC9CD2C Offset: 0xC9CD2C VA: 0xC9CD2C
		public void SetEventDescription(string text)
		{
			m_eventDesc.text = text;
		}

		//// RVA: 0xC9CD68 Offset: 0xC9CD68 VA: 0xC9CD68
		public void SetEventPeriod(string text)
		{
			m_eventPeriod.text = text;
		}

		//// RVA: 0xC9CDA4 Offset: 0xC9CDA4 VA: 0xC9CDA4
		public void SetLockIcon(bool isOpen, bool isUnlockable)
		{
			m_lockObj.alpha = isOpen ? 0 : 1;
			m_rewardObj.alpha = isOpen ? 1 : 0;
			m_lockObj.blocksRaycasts = !isOpen;
			m_unlockableImage.enabled = !isOpen && isUnlockable;
		}

		//// RVA: 0xC9CE7C Offset: 0xC9CE7C VA: 0xC9CE7C
		public void SetNewIcon(bool isNew)
		{
			m_newIcon.enabled = isNew;
		}

		//// RVA: 0xC9CEB0 Offset: 0xC9CEB0 VA: 0xC9CEB0
		public void SetAttribute(int attr)
		{
			if (attr == 0)
			{
				m_attrIcon.gameObject.SetActive(false);
				m_attrBack.sprite = m_attrBackSet.GetMusicAttrIconSprite(5);
				m_attrArrow.sprite = m_attrArrowSet.GetMusicAttrIconSprite(5);
			}
			else
			{
				m_attrIcon.gameObject.SetActive(true);
				m_attrIcon.sprite = m_attrIconSet.GetMusicAttrIconSprite(attr);
				m_attrBack.sprite = m_attrBackSet.GetMusicAttrIconSprite(attr);
				m_attrArrow.sprite = m_attrArrowSet.GetMusicAttrIconSprite(attr);
			}
		}

		//// RVA: 0xC9D090 Offset: 0xC9D090 VA: 0xC9D090
		public void SetRewardState(bool score, bool combo, bool clearCount)
		{
			m_scoreReward.enabled = score;
			m_comboReward.enabled = combo;
			m_clearCountReward.enabled = clearCount;
		}

		//// RVA: 0xC9D118 Offset: 0xC9D118 VA: 0xC9D118
		public void SetMusicNo(int index, int count)
		{
			m_musicNumSb.Clear();
			m_musicNumSb.Append(index);
			m_musicNumSb.Append(m_musicNumSign);
			m_musicNumSb.Append(count);
			m_musicListNo.text = m_musicNumSb.ToString();
		}

		//// RVA: 0xC9D210 Offset: 0xC9D210 VA: 0xC9D210
		public void SetSingerName(string singerName)
		{
			m_singerNameText.text = singerName;
		}

		//// RVA: 0xC9D24C Offset: 0xC9D24C VA: 0xC9D24C
		public void SetHighLevelSingerName(string singerName)
		{
			m_highLevelSingerName.text = singerName;
		}

		//// RVA: 0xC9D288 Offset: 0xC9D288 VA: 0xC9D288
		public void SetRankingButton(bool isEnable)
		{
			m_rankingButton.gameObject.SetActive(isEnable);
		}

		//// RVA: 0xC9D2DC Offset: 0xC9D2DC VA: 0xC9D2DC
		public void SetListType(MusicScrollCenterItem.ListType listType)
		{
			m_attrIcon.enabled = false;
			m_musicName.enabled = false;
			if(m_musicNameAlt != null)
				m_musicNameAlt.enabled = false;
			m_singerNameText.enabled = false;
			m_seriesLogo.enabled = false;
			m_eventDesc.enabled = false;
			m_eventName.enabled = false;
			m_eventPeriod.enabled = false;
			m_highLevelMusicName.enabled = false;
			m_highLevelSingerName.enabled = false;
			m_highLevelObj.alpha = 0;
			m_enemyInfoButton.gameObject.SetActive(false);
			m_musicInfoButton.gameObject.SetActive(false);
			m_rankingButton.gameObject.SetActive(false);
			m_rewardButton.gameObject.SetActive(false);
			m_eventNameScroll.StopScroll();
			m_eventDescScroll.StopScroll();
			m_musicNameScroll.StopScroll();
			if(m_musicNameScroll != null)
				m_musicNameScroll.StopScroll();
			m_singerNameScroll.StopScroll();
			m_highLevelMusicNameScroll.StopScroll();
			m_highLevelSingerNameScroll.StopScroll();
			switch(listType)
			{
				case ListType.Normal:
					m_attrIcon.enabled = true;
					m_musicName.enabled = true;
					if(m_musicNameAlt != null)
						m_musicNameAlt.enabled = true;
					m_singerNameText.enabled = true;
					m_seriesLogo.enabled = true;
					m_enemyInfoButton.gameObject.SetActive(true);
					m_musicInfoButton.gameObject.SetActive(true);
					m_rankingButton.gameObject.SetActive(true);
					m_rewardButton.gameObject.SetActive(true);
					m_musicNameScroll.StartScroll();
					if(m_musicNameScroll != null)
						m_musicNameScroll.StartScroll();
					m_singerNameScroll.StartScroll();
					break;
				case ListType.EventEntrance:
					SetAttribute(0);
					m_eventDesc.enabled = true;
					m_eventName.enabled = true;
					m_eventPeriod.enabled = true;
					m_rewardObj.alpha = 0;
					m_lockObj.alpha = 0;
					m_lockObj.blocksRaycasts = false;
					break;
				case ListType.LimitedSLive:
					m_eventDesc.enabled = true;
					m_eventName.enabled = true;
					m_seriesLogo.enabled = true;
					m_rewardObj.alpha = 0;
					m_lockObj.alpha = 0;
					m_lockObj.blocksRaycasts = false;
					m_musicInfoButton.gameObject.SetActive(true);
					break;
				case ListType.HighLevel:
					m_highLevelObj.alpha = 1;
					m_attrIcon.enabled = true;
					m_seriesLogo.enabled = true;
					m_highLevelMusicName.enabled = true;
					m_highLevelSingerName.enabled = true;
					m_enemyInfoButton.gameObject.SetActive(true);
					m_musicInfoButton.gameObject.SetActive(true);
					m_rankingButton.gameObject.SetActive(true);
					m_rewardButton.gameObject.SetActive(true);
					m_highLevelMusicNameScroll.StartScroll();
					m_highLevelSingerNameScroll.StartScroll();
					break;
				default:
					return;
			}
			m_eventDescScroll.StartScroll();
		}
	}
}
