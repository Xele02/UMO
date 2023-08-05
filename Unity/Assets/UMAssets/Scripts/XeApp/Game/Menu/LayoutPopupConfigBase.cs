using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;
using UnityEngine.Events;
using XeSys;
using System.Collections;

namespace XeApp.Game.Menu
{
	public abstract class LayoutPopupConfigBase : LayoutUGUIScriptBase
	{
		protected class TextSet
		{
			public int index; // 0x8
			public string label; // 0xC
		}

		[SerializeField]
		protected Text[] m_texts; // 0x14
		[SerializeField]
		protected ActionButton[] m_buttons; // 0x18
		[SerializeField]
		protected ToggleButtonGroup[] m_toggleButtonGroups; // 0x1C
		protected Dictionary<int, Slider> m_sliders = new Dictionary<int, Slider>(); // 0x20
		protected bool m_changeSliderSePlay = true; // 0x24
		protected ScrollRect m_scroll; // 0x28
		protected Coroutine m_scrollCoroutine; // 0x2C

		public ConfigMenu.eType ConfigType { get; set; } // 0x30
		public Transform Parent { get; set; } // 0x34

		//// RVA: -1 Offset: -1 Slot: 6
		public abstract int GetContentsHeight();

		//// RVA: -1 Offset: -1 Slot: 7
		public abstract bool IsShow();

		//// RVA: 0x1EBF10C Offset: 0x1EBF10C VA: 0x1EBF10C Slot: 8
		public virtual void SetStatus(ScrollRect scroll)
		{
			if(scroll != null)
			{
				m_scroll = scroll;
				m_scroll.onValueChanged.AddListener((Vector2 value) =>
				{
					//0x1EBFE44
					if(m_scrollCoroutine == null)
					{
						if(InputManager.Instance.touchCount > 1)
						{
							if(gameObject.activeSelf)
							{
								m_scrollCoroutine = this.StartCoroutineWatched(Co_ScrollLock());
							}
						}
					}
				});
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x701534 Offset: 0x701534 VA: 0x701534
		//// RVA: 0x1EBF234 Offset: 0x1EBF234 VA: 0x1EBF234
		protected IEnumerator Co_ScrollLock()
		{
			//0x1EBFF4C
			for(int i = 0; i < m_sliders.Count; i++)
			{
				m_sliders[i].enabled = false;
			}
			while (InputManager.Instance.touchCount > 0)
				yield return null;
			for (int i = 0; i < m_sliders.Count; i++)
			{
				m_sliders[i].enabled = true;
			}
			m_scrollCoroutine = null;
		}

		//// RVA: 0x1EBF2E0 Offset: 0x1EBF2E0 VA: 0x1EBF2E0
		public void SetPosY(float posY)
		{
			(transform as RectTransform).anchoredPosition = new Vector2((transform as RectTransform).anchoredPosition.x, posY);
		}

		// RVA: 0x1EBF3BC Offset: 0x1EBF3BC VA: 0x1EBF3BC
		public void Reset()
		{
			return;
		}

		//// RVA: 0x1EBF3C0 Offset: 0x1EBF3C0 VA: 0x1EBF3C0
		public void Show()
		{
			gameObject.SetActive(true);
		}

		//// RVA: 0x1EBF3F8 Offset: 0x1EBF3F8 VA: 0x1EBF3F8
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		//// RVA: 0x1EBF430 Offset: 0x1EBF430 VA: 0x1EBF430
		public void SetText(int index, string text)
		{
			if(m_texts[index] != null)
			{
				m_texts[index].text = text;
			}
		}

		//// RVA: 0x1EBF560 Offset: 0x1EBF560 VA: 0x1EBF560
		protected void SetValueSlider(Slider slider, float value)
		{
			if(slider != null)
			{
				slider.value = value;
			}
		}

		//// RVA: 0x1EBF61C Offset: 0x1EBF61C VA: 0x1EBF61C
		protected void SetValueSlider(int type, float value)
		{
			SetValueSlider(m_sliders[type], value);
		}

		//// RVA: 0x1EBF6AC Offset: 0x1EBF6AC VA: 0x1EBF6AC
		protected void SetCallbackSlider(Slider slider, UnityAction<float> callback)
		{
			if(slider != null)
			{
				slider.onValueChanged.RemoveAllListeners();
				slider.onValueChanged.AddListener(callback);
			}
		}

		//// RVA: 0x1EBF7C8 Offset: 0x1EBF7C8 VA: 0x1EBF7C8
		protected void SetCallbackSlider(int type, UnityAction<float> callback)
		{
			SetCallbackSlider(m_sliders[type], callback);
		}

		//// RVA: 0x1EBF858 Offset: 0x1EBF858 VA: 0x1EBF858
		protected void SetLimitValueSlider(Slider slider, float minValue, int maxValue)
		{
			if(slider != null)
			{
				slider.minValue = minValue;
				slider.maxValue = maxValue;
			}
		}

		//// RVA: 0x1EBF944 Offset: 0x1EBF944 VA: 0x1EBF944
		protected void SetLimitValueSlider(int type, float minValue, int maxValue)
		{
			SetLimitValueSlider(m_sliders[type], minValue, maxValue);
		}

		//// RVA: 0x1EBF9E4 Offset: 0x1EBF9E4 VA: 0x1EBF9E4
		protected void SetCallbackToggleButton(ToggleButtonGroup group, UnityAction<int> callback)
		{
			if(group != null)
			{
				group.OnSelectToggleButtonEvent.RemoveAllListeners();
				group.OnSelectToggleButtonEvent.AddListener(callback);
			}
		}

		//// RVA: 0x1EBFB00 Offset: 0x1EBFB00 VA: 0x1EBFB00
		protected void SetCallbackToggleButton(int type, UnityAction<int> callback)
		{
			SetCallbackToggleButton(m_toggleButtonGroups[type], callback);
		}

		//// RVA: 0x1EBFB54 Offset: 0x1EBFB54 VA: 0x1EBFB54
		protected void SetSelectToggleButton(ToggleButtonGroup group, int index)
		{
			if (group != null)
				group.SelectGroupButton(index);
		}

		//// RVA: 0x1EBFC08 Offset: 0x1EBFC08 VA: 0x1EBFC08
		protected void SetSelectToggleButton(int type, int index)
		{
			SetSelectToggleButton(m_toggleButtonGroups[type], index);
		}

		//// RVA: 0x1EBFC5C Offset: 0x1EBFC5C VA: 0x1EBFC5C
		protected void SetCallbackButton(ActionButton button, ButtonBase.OnClickCallback callback)
		{
			if(button != null)
			{
				button.ClearOnClickCallback();
				button.AddOnClickCallback(callback);
			}
		}

		//// RVA: 0x1EBFD38 Offset: 0x1EBFD38 VA: 0x1EBFD38
		protected void SetCallbackButton(int type, ButtonBase.OnClickCallback callback)
		{
			SetCallbackButton(m_buttons[type], callback);
		}

		//// RVA: 0x1EBFD8C Offset: 0x1EBFD8C VA: 0x1EBFD8C
		//protected void PlaySeToggleButton() { }

		//// RVA: 0x1EBFD94 Offset: 0x1EBFD94 VA: 0x1EBFD94
		//protected void PlaySeSlider() { }

		//// RVA: 0x1EBFDA8 Offset: 0x1EBFDA8 VA: 0x1EBFDA8
		//protected void PlaySeButton() { }
	}
}
