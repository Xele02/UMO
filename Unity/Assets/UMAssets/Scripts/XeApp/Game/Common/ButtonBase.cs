using XeSys.Gfx;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class ButtonBase : LayoutUGUIScriptBase, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
	{
		public delegate void OnClickCallback();
		public delegate void AnimEndCallback();

		private enum SelectState
		{
			Normal = 0,
			Highlighted = 1,
			Pressed = 2,
			Disabled = 3,
			Hidden = 4,
			Decide = 5,
		}

		protected ButtonBase.OnClickCallback OnClickEvent = () => { return;/*0xE64D64*/}; // 0x14
		protected ButtonBase.AnimEndCallback AnimEndEvent = () => { return;/*0xE64D68*/}; // 0x18
		private ButtonBase.SelectState m_selectionState; // 0x1C
		protected bool m_isPointerInside; // 0x20
		protected bool m_isPointerDown; // 0x21
		private bool m_isDisable; // 0x22
		private bool m_isDark; // 0x23
		private bool m_isHidden; // 0x24
		protected bool m_isClick; // 0x25
		private LayoutUGUIHitOnly m_hitCheck; // 0x28

		public bool IsClick { get { return m_isClick; } } //0xE63A1C
		public bool IsInputOff { get; set; } // 0x2C
		public bool IsInputLock { get; set; } // 0x2D
		public bool Disable { get { return m_isDisable; } set {  
			if(value != m_isDisable)
			{
				m_isDisable = value;
				if(!value)
					m_selectionState = ButtonBase.SelectState.Normal;
				ChangeTranstionState();
			}
		} } //0xE63A9C 0xE63A44
		public bool Dark { get { return m_isDark; } set {
			if(m_isDark != value)
			{
				m_isDark = value;
				if(!value)
					m_selectionState = SelectState.Normal;
				ChangeTranstionState();
			}
		} } //0xE63AA4 0xE63AAC
		public bool Hidden { get { return m_isHidden; } set {
			if(m_isHidden == value)
				return;
			m_isHidden = value;
			if(!value)
				m_selectionState = ButtonBase.SelectState.Normal;
			HitCheckRaycastTarget = !value;
			ChangeTranstionState();
		} } //0xE63AD4 0xE63ADC
		private bool HitCheckRaycastTarget { set {
			if(m_hitCheck == null)
				return;
			m_hitCheck.raycastTarget = value;
		}} //0xE63B24
		public bool IsEventProcessed { get; private set; } // 0x2E

		// // RVA: 0xE63BE8 Offset: 0xE63BE8 VA: 0xE63BE8
		private void DetectHitCheck()
		{
			if(m_hitCheck != null)
			{
				m_hitCheck = GetComponentInChildren<LayoutUGUIHitOnly>(true);
			}
		}

		// RVA: 0xE5D9BC Offset: 0xE5D9BC VA: 0xE5D9BC Slot: 11
		protected virtual void Start()
		{
			LayoutUGUIHitOnly[] hits = GetComponentsInChildren<LayoutUGUIHitOnly>(true);
			for(int i = 0; i < hits.Length; i++)
			{
				if(hits[i].gameObject.activeSelf)
				{
					Button b = hits[i].GetComponent<Button>();
					if(b != null)
					{
						b.enabled = false;
					}
					hits[i].raycastTarget = true;
				}
			}
		}

		// RVA: 0xE63CAC Offset: 0xE63CAC VA: 0xE63CAC Slot: 12
		protected virtual void OnDisable()
		{
			return;
		}

		// // RVA: 0xE63CB0 Offset: 0xE63CB0 VA: 0xE63CB0 Slot: 13
		protected virtual void OnClick()
		{
			return;
		}

		// // RVA: 0xE63CB4 Offset: 0xE63CB4 VA: 0xE63CB4 Slot: 14
		// protected virtual void AnimEnd() { }

		// RVA: 0xE5DDD4 Offset: 0xE5DDD4 VA: 0xE5DDD4 Slot: 15
		public virtual void OnPointerClick(PointerEventData eventData)
		{
			IsEventProcessed = false;
			if(!IsInputOff && !IsInputLock && !Disable && !Hidden)
			{
#if UNITY_ANDROID
				if(eventData.pointerId == 0)
#else
				if(eventData.pointerId == -1)
#endif
				{
					m_selectionState = ButtonBase.SelectState.Decide;
					IsEventProcessed = true;
					ChangeTranstionState();
					PerformClick();
					m_isClick = true;
				}
			}
		}

		// RVA: 0xE5DE7C Offset: 0xE5DE7C VA: 0xE5DE7C Slot: 16
		public virtual void OnPointerEnter(PointerEventData eventData)
		{
			IsEventProcessed = false;
			if (!IsInputOff && !IsInputLock)
			{
#if UNITY_ANDROID
				if(eventData.pointerId == 0)
#else
				if (eventData.pointerId == -1)
#endif
				{
					IsEventProcessed = true;
					m_isPointerInside = true;
					SelectState state = SelectState.Pressed;
					if(!m_isPointerDown)
					{
						state = IsHighlighted(eventData) ? SelectState.Highlighted : SelectState.Normal;
					}
					m_selectionState = state;
					ChangeTranstionState();
				}
			}
		}

		// RVA: 0xE5DF0C Offset: 0xE5DF0C VA: 0xE5DF0C Slot: 17
		public virtual void OnPointerExit(PointerEventData eventData)
		{
			IsEventProcessed = false;
			if (!IsInputOff && !IsInputLock)
			{
#if UNITY_ANDROID
				if(eventData.pointerId == 0)
#else
				if (eventData.pointerId == -1)
#endif
				{
					IsEventProcessed = true;
					m_isPointerInside = false;
					m_selectionState = IsHighlighted(eventData) ? SelectState.Highlighted : SelectState.Normal;
					ChangeTranstionState();
				}
			}
		}

		// RVA: 0xE5DF90 Offset: 0xE5DF90 VA: 0xE5DF90 Slot: 18
		public virtual void OnPointerDown(PointerEventData eventData)
		{
			IsEventProcessed = false;
			if (!IsInputOff && !IsInputLock)
			{
				if (eventData.button == PointerEventData.InputButton.Left)
				{
#if UNITY_ANDROID
					if(eventData.pointerId == 0)
#else
					if (eventData.pointerId == -1)
#endif
					{
						IsEventProcessed = true;
						m_isPointerDown = true;
						SelectState state = SelectState.Pressed;
						if(!m_isPointerInside)
						{
							state = IsHighlighted(eventData) ? SelectState.Highlighted : SelectState.Normal;
						}
						m_selectionState = state;
						ChangeTranstionState();
					}
				}
			}
		}

		// RVA: 0xE5E044 Offset: 0xE5E044 VA: 0xE5E044 Slot: 19
		public virtual void OnPointerUp(PointerEventData eventData)
		{
			if (!IsInputOff && !IsInputLock)
			{
				if (eventData.button == PointerEventData.InputButton.Left)
				{
#if UNITY_ANDROID
					if(eventData.pointerId == 0)
#else
					if (eventData.pointerId == -1)
#endif
					{
						m_isPointerDown = false;
						m_selectionState = IsHighlighted(eventData) ? SelectState.Highlighted : SelectState.Normal; ;
						ChangeTranstionState();
					}
				}
			}
		}

		// RVA: 0xE5FEC4 Offset: 0xE5FEC4 VA: 0xE5FEC4
		public void ClearOnClickCallback()
		{
			OnClickEvent = () => {};
		}

		// RVA: 0xE60008 Offset: 0xE60008 VA: 0xE60008
		public void AddOnClickCallback(ButtonBase.OnClickCallback OnClickEvent)
		{
			this.OnClickEvent += OnClickEvent;
		}

		// // RVA: 0xE645C4 Offset: 0xE645C4 VA: 0xE645C4
		// public void RemoveOnClickCallback(ButtonBase.OnClickCallback OnClickEvent) { }

		// // RVA: 0xE646B0 Offset: 0xE646B0 VA: 0xE646B0
		// public void ClearAnimEndCallback() { }

		// // RVA: 0xE647F4 Offset: 0xE647F4 VA: 0xE647F4
		// public void AddAnimEndCallback(ButtonBase.AnimEndCallback AnimEndEvent) { }

		// // RVA: 0xE648E0 Offset: 0xE648E0 VA: 0xE648E0
		// public void RemoveAnimEndCallback(ButtonBase.AnimEndCallback AnimEndEvent) { }

		// // RVA: 0xE64118 Offset: 0xE64118 VA: 0xE64118
		public bool IsEnableTouchId(PointerEventData eventData)
		{
#if UNITY_ANDROID
			if(eventData.pointerId == 0)
#else
			if (eventData.pointerId == -1)
#endif
				return true;
			return false;
		}

		// // RVA: 0xE649CC Offset: 0xE649CC VA: 0xE649CC
		public void PerformClick()
		{
			OnClickEvent();
		}

		// // RVA: 0xE63A6C Offset: 0xE63A6C VA: 0xE63A6C
		private void ChangeTranstionState()
		{
			if(!m_isDisable && !m_isDark)
			{
				ButtonBase.SelectState state = m_selectionState;
				if(m_isHidden)
					state = ButtonBase.SelectState.Hidden;
				DoStateTransition(state);
				return;
			}
			DoStateTransition(ButtonBase.SelectState.Disabled);
		}

		// // RVA: 0xE64590 Offset: 0xE64590 VA: 0xE64590
		// private void UpdateSelectionState(BaseEventData eventData) { }

		// // RVA: 0xE64A74 Offset: 0xE64A74 VA: 0xE64A74
		public bool IsPressed()
		{
			return m_isPointerInside && m_isPointerDown;
		}

		// // RVA: 0xE64A94 Offset: 0xE64A94 VA: 0xE64A94
		public bool IsHighlighted(BaseEventData eventData)
		{
			if(!m_isPointerInside || (m_isPointerInside && !m_isPointerDown))
			{
				PointerEventData pointerData = eventData as PointerEventData;
				if(pointerData != null)
				{ 
					if(m_isPointerDown)
					{
						if (!m_isPointerInside)
							return false;
						if (pointerData.pointerPress == this)
							return true;
						return false;
					}
					if(m_isPointerInside)
					{
						if (pointerData.pointerPress == this)
							return true;
						if (m_isPointerDown)
							return false;
					}
					else
					{
						return false;
					}
					return pointerData.pointerPress == null;
				}
				if (m_isPointerInside)
					return true;
			}
			return false;
		}

		// // RVA: 0xE649F4 Offset: 0xE649F4 VA: 0xE649F4
		private void DoStateTransition(ButtonBase.SelectState state)
		{
			switch(state)
			{
				case SelectState.Normal:
					PlayNormal();
					break;
				case SelectState.Highlighted:
				case SelectState.Pressed:
					PlayEnter();
					break;
				case SelectState.Disabled:
					PlayDisable();
					break;
				case SelectState.Hidden:
					PlayHidden();
					break;
				case SelectState.Decide:
					PlayDecide();
					break;
				default:
					break;
			}
		}

		// // RVA: 0xE5E44C Offset: 0xE5E44C VA: 0xE5E44C Slot: 20
		public virtual void SetOn()
		{
			m_isPointerInside = false;
			m_isPointerDown = false;
			m_isDisable = false;
			m_isDark = false;
			m_isHidden = false;
			m_isClick = true;
			DetectHitCheck();
			HitCheckRaycastTarget = true;
			m_selectionState = SelectState.Normal;
		}

		// // RVA: 0xE5E574 Offset: 0xE5E574 VA: 0xE5E574 Slot: 21
		public virtual void SetOff()
		{
			m_isHidden = false;
			m_isClick = false;
			m_isPointerInside = false;
			m_isPointerDown = false;
			m_isDisable = false;
			m_isDark = false;
			DetectHitCheck();
			HitCheckRaycastTarget = true;
			m_selectionState = SelectState.Normal;
		}

		// RVA: 0xE64CC4 Offset: 0xE64CC4 VA: 0xE64CC4 Slot: 22
		protected virtual void PlayDecide()
		{
			return;
		}

		// RVA: 0xE64CC8 Offset: 0xE64CC8 VA: 0xE64CC8 Slot: 23
		protected virtual void PlayNormal()
		{
			return;
		}

		// RVA: 0xE64CCC Offset: 0xE64CCC VA: 0xE64CCC Slot: 24
		protected virtual void PlayEnter()
		{
			return;
		}

		// RVA: 0xE64CD0 Offset: 0xE64CD0 VA: 0xE64CD0 Slot: 25
		protected virtual void PlayDisable()
		{
			return;
		}

		// RVA: 0xE64CD4 Offset: 0xE64CD4 VA: 0xE64CD4 Slot: 26
		protected virtual void PlayHidden()
		{
			return;
		}

		// // RVA: 0xE64CD8 Offset: 0xE64CD8 VA: 0xE64CD8 Slot: 27
		public virtual bool IsPlaying()
		{
			return false;
		}
	}
}
