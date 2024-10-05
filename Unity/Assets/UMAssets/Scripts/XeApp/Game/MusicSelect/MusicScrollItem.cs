using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.MusicSelect
{
	public class MusicScrollItem : MonoBehaviour
	{
		public enum ListType
		{
			Normal = 0,
			EventEntrance = 1,
			HighLevel = 2,
		}

		private RectTransform _rectTransform; // 0xC
		[SerializeField]
		private Text _title; // 0x10
		[SerializeField]
		private Text _titleAlt;
		[SerializeField]
		private Text _titleAlt2;
		[SerializeField]
		private UGUIButton m_button; // 0x14
		[SerializeField]
		private MusicScrollItemLabelGroup m_labelGroup; // 0x18
		[SerializeField]
		private Image m_newIcon; // 0x1C
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x665FFC Offset: 0x665FFC VA: 0x665FFC
		private Image m_attrIcon; // 0x20
		[SerializeField]
		private MusicAttrIconScriptableObject m_attrIconSet; // 0x24
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x666054 Offset: 0x666054 VA: 0x666054
		private CanvasGroup m_lockObj; // 0x28
		[SerializeField]
		private Image m_unlockableImage; // 0x2C
		// [HeaderAttribute] // RVA: 0x6660AC Offset: 0x6660AC VA: 0x6660AC
		[SerializeField]
		private CanvasGroup m_rewardObj; // 0x30
		[SerializeField]
		private Image m_scoreReward; // 0x34
		[SerializeField]
		private Image m_comboReward; // 0x38
		[SerializeField]
		private Image m_clearCountReward; // 0x3C
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x666124 Offset: 0x666124 VA: 0x666124
		private Text m_eventName; // 0x40
		// [HeaderAttribute] // RVA: 0x66616C Offset: 0x66616C VA: 0x66616C
		[SerializeField]
		private CanvasGroup m_highLevelObj; // 0x44
		[SerializeField]
		private Text m_highLevelMusicName; // 0x48
		public Action<MusicScrollItem> OnClickList; // 0x4C
		private Vector2 _startPos; // 0x50
		private Vector2 _prev; // 0x58
		private Vector2 _next; // 0x60
		private List<MusicScrollItem> _tmpList = new List<MusicScrollItem>(16); // 0x68

		public RectTransform RectTransform { get {
			if(_rectTransform == null)
			{
				_rectTransform = transform as RectTransform;
			}
			return _rectTransform;
		} } //0xC9DE0C
		public MusicScrollItemLabelGroup LabelGroup { get { return m_labelGroup; } } //0xC9DEE8
		// public Vector2 StartPos { get; } 0xC9DEF0

		// RVA: 0xC9DF04 Offset: 0xC9DF04 VA: 0xC9DF04
		private void Awake()
		{
			_startPos = RectTransform.anchoredPosition;
			m_button.ClearOnClickCallback();
			m_button.AddOnClickCallback(() =>
			{
				//0xC9EA70
				if (OnClickList != null)
					OnClickList(this);
			});

			if(RuntimeSettings.CurrentSettings.Language != "" && (RuntimeSettings.CurrentSettings.EnableMusicSecondDisplay || RuntimeSettings.CurrentSettings.EnableMusicThirdDisplay))
			{
				m_attrIcon.GetComponent<RectTransform>().anchoredPosition = new Vector3(-206, -8);
				m_rewardObj.GetComponent<RectTransform>().anchoredPosition = new Vector3(178, -8);
				_title.transform.parent.GetComponent<RectTransform>().anchoredPosition = new Vector3(-25, -9);
				
				{
					GameObject musicAltMask = new GameObject("TitleMaskAlt");
					RectTransform rt = musicAltMask.AddComponent<RectTransform>();
					musicAltMask.transform.SetParent(_title.transform.parent.parent, false);
					musicAltMask.transform.SetSiblingIndex(_title.transform.parent.GetSiblingIndex());
					rt.pivot = new Vector3(0.5f, 0.5f);
					rt.anchorMin = new Vector3(0.5f, 0.5f);
					rt.anchorMax = new Vector3(0.5f, 0.5f);
					rt.anchoredPosition = new Vector3(15, 8.5f);
					rt.sizeDelta = new Vector3(400, 30);
					musicAltMask.AddComponent<RectMask2D>();

					_titleAlt = new GameObject("Title").AddComponent<Text>();
					_titleAlt.rectTransform.SetParent(rt, false);
					_titleAlt.rectTransform.anchoredPosition = new Vector3(0, 15);
					_titleAlt.rectTransform.sizeDelta = new Vector3(400, 30);
					_titleAlt.rectTransform.pivot = new Vector3(0, 1);
					_titleAlt.rectTransform.anchorMin = new Vector3(0, 0.5f);
					_titleAlt.rectTransform.anchorMax = new Vector3(0, 0.5f);
					_titleAlt.font = _title.font;
					_titleAlt.supportRichText = _title.supportRichText;
					_titleAlt.alignment = _title.alignment;
					_titleAlt.horizontalOverflow = _title.horizontalOverflow;
					_titleAlt.verticalOverflow = _title.verticalOverflow;
					_titleAlt.color = _title.color;
					_titleAlt.fontSize = 12;
				}
				{
					GameObject musicAltMask = new GameObject("TitleMaskAlt2");
					RectTransform rt = musicAltMask.AddComponent<RectTransform>();
					musicAltMask.transform.SetParent(_title.transform.parent.parent, false);
					musicAltMask.transform.SetSiblingIndex(_title.transform.parent.GetSiblingIndex() + 1);
					rt.pivot = new Vector3(0.5f, 0.5f);
					rt.anchorMin = new Vector3(0.5f, 0.5f);
					rt.anchorMax = new Vector3(0.5f, 0.5f);
					rt.anchoredPosition = new Vector3(15, -26);
					rt.sizeDelta = new Vector3(400, 30);
					musicAltMask.AddComponent<RectMask2D>();

					_titleAlt2 = new GameObject("Title").AddComponent<Text>();
					_titleAlt2.rectTransform.SetParent(rt, false);
					_titleAlt2.rectTransform.anchoredPosition = new Vector3(0, 15);
					_titleAlt2.rectTransform.sizeDelta = new Vector3(400, 30);
					_titleAlt2.rectTransform.pivot = new Vector3(0, 1);
					_titleAlt2.rectTransform.anchorMin = new Vector3(0, 0.5f);
					_titleAlt2.rectTransform.anchorMax = new Vector3(0, 0.5f);
					_titleAlt2.font = _title.font;
					_titleAlt2.supportRichText = _title.supportRichText;
					_titleAlt2.alignment = _title.alignment;
					_titleAlt2.horizontalOverflow = _title.horizontalOverflow;
					_titleAlt2.verticalOverflow = _title.verticalOverflow;
					_titleAlt2.color = _title.color;
					_titleAlt2.fontSize = 12;
				}
			}
		}

		// RVA: 0xC9E00C Offset: 0xC9E00C VA: 0xC9E00C
		private void Start()
		{
			transform.parent.GetComponentsInChildren<MusicScrollItem>(true, _tmpList);
			for(int i = 0; i < _tmpList.Count; i++)
			{
				if(_tmpList[i] == this)
				{
					int index = i - 1;
					if(index > -1)
					{
						_prev = _tmpList[index]._startPos;
					}
					if(index + 2 < _tmpList.Count)
					{
						_next = _tmpList[index + 2]._startPos;
					}
					if(index < 0)
					{
						_prev = (_startPos - _next) + _startPos;
						// not sure
					}
					if(index + 2 >= _tmpList.Count)
					{
						_next = (_startPos - _prev) + _startPos;
					}
					return;
				}
			}
		}

		// // RVA: 0xC9E3C0 Offset: 0xC9E3C0 VA: 0xC9E3C0
		public void UpdatePosition(float rate)
		{
			if(rate >= 0)
			{
				_rectTransform.anchoredPosition = (_prev - _startPos) * rate + _startPos;
			}
			else
			{
				_rectTransform.anchoredPosition = _startPos - (_next - _startPos) * rate;
			}
		}

		// // RVA: 0xC9E59C Offset: 0xC9E59C VA: 0xC9E59C
		public void SetTitle(string title, string title_2, string title_3)
		{
			_title.text = title;
			if(_titleAlt != null)
				_titleAlt.text = title_2;
			if(_titleAlt2 != null)
				_titleAlt2.text = title_3;
		}

		// // RVA: 0xC9E5D8 Offset: 0xC9E5D8 VA: 0xC9E5D8
		public void SetHighLevelMusicTitle(string title)
		{
			m_highLevelMusicName.text = title;
		}

		// // RVA: 0xC9E614 Offset: 0xC9E614 VA: 0xC9E614
		public void SetEventName(string name)
		{
			m_eventName.text = name;
		}

		// // RVA: 0xC9E650 Offset: 0xC9E650 VA: 0xC9E650
		public void SetLockIcon(bool isOpen, bool isUnlockable)
		{
			m_lockObj.alpha = isOpen ? 0 : 1;
			m_rewardObj.alpha = isOpen ? 1 : 0;
			m_unlockableImage.enabled = isUnlockable && !isOpen;
		}

		// // RVA: 0xC9E700 Offset: 0xC9E700 VA: 0xC9E700
		public void SetNewIcon(bool isNew)
		{
			m_newIcon.enabled = isNew;
		}

		// // RVA: 0xC9E734 Offset: 0xC9E734 VA: 0xC9E734
		public void SetAttribute(int attr)
		{
			m_attrIcon.sprite = m_attrIconSet.GetMusicAttrIconSprite(attr);
		}

		// // RVA: 0xC9E790 Offset: 0xC9E790 VA: 0xC9E790
		public void SetRewardState(bool score, bool combo, bool clearCount)
		{
			m_scoreReward.enabled = score;
			m_comboReward.enabled = combo;
			m_clearCountReward.enabled = clearCount;
		}

		// // RVA: 0xC9E818 Offset: 0xC9E818 VA: 0xC9E818
		public void SetListType(MusicScrollItem.ListType listType)
		{
			_title.enabled = false;
			if(_titleAlt != null)
				_titleAlt.enabled = false;
			if(_titleAlt2 != null)
				_titleAlt2.enabled = false;
			m_eventName.enabled = false;
			m_attrIcon.enabled = false;
			m_highLevelMusicName.enabled = false;
			m_highLevelObj.alpha = 0;
			if(listType == ListType.HighLevel)
			{
				m_highLevelObj.alpha = 1;
				m_attrIcon.enabled = true;
				m_highLevelMusicName.enabled = true;
			}
			else if(listType == ListType.EventEntrance)
			{
				m_lockObj.alpha = 0;
				m_rewardObj.alpha = 0;
				m_eventName.enabled = true;
			}
			else
			{
				m_attrIcon.enabled = true;
				_title.enabled = true;
				if(_titleAlt != null)
					_titleAlt.enabled = true;
				if(_titleAlt2 != null)
					_titleAlt2.enabled = true;
			}
		}
	}
}
