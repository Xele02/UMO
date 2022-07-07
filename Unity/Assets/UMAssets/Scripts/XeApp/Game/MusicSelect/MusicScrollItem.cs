using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.MusicSelect
{
	public class MusicScrollItem : MonoBehaviour
	{
		private RectTransform _rectTransform; // 0xC
		[SerializeField]
		private Text _title; // 0x10
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
		// public MusicScrollItemLabelGroup LabelGroup { get; } 0xC9DEE8
		// public Vector2 StartPos { get; } 0xC9DEF0

		// RVA: 0xC9DF04 Offset: 0xC9DF04 VA: 0xC9DF04
		private void Awake()
		{
			_startPos = RectTransform.anchoredPosition;
			UnityEngine.Debug.LogError("TODO ScrollItem Awake");
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
		public void SetTitle(string title)
		{
			_title.text = title;
		}

		// // RVA: 0xC9E5D8 Offset: 0xC9E5D8 VA: 0xC9E5D8
		// public void SetHighLevelMusicTitle(string title) { }

		// // RVA: 0xC9E614 Offset: 0xC9E614 VA: 0xC9E614
		// public void SetEventName(string name) { }

		// // RVA: 0xC9E650 Offset: 0xC9E650 VA: 0xC9E650
		// public void SetLockIcon(bool isOpen, bool isUnlockable) { }

		// // RVA: 0xC9E700 Offset: 0xC9E700 VA: 0xC9E700
		// public void SetNewIcon(bool isNew) { }

		// // RVA: 0xC9E734 Offset: 0xC9E734 VA: 0xC9E734
		// public void SetAttribute(int attr) { }

		// // RVA: 0xC9E790 Offset: 0xC9E790 VA: 0xC9E790
		// public void SetRewardState(bool score, bool combo, bool clearCount) { }

		// // RVA: 0xC9E818 Offset: 0xC9E818 VA: 0xC9E818
		// public void SetListType(MusicScrollItem.ListType listType) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B4AE8 Offset: 0x6B4AE8 VA: 0x6B4AE8
		// // RVA: 0xC9EA70 Offset: 0xC9EA70 VA: 0xC9EA70
		// private void <Awake>b__28_0() { }
	}
}
