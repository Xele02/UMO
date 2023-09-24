using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.Serialization;
using System;
using XeSys;

namespace XeApp.Core
{
	public class CustomInputModule : PointerInputModule
	{
		[Obsolete("Mode is no longer needed on input module as it handles both mouse and keyboard simultaneously.", false)] // RVA: 0x6512A4 Offset: 0x6512A4 VA: 0x6512A4
		public enum InputMode
		{
			Mouse = 0,
			Buttons = 1,
		}

		private float m_PrevActionTime; // 0x2C
		private Vector2 m_LastMoveVector; // 0x30
		private int m_ConsecutiveMoveCount; // 0x38
		private Vector2 m_LastMousePosition; // 0x3C
		private Vector2 m_MousePosition; // 0x44
		private int m_LastFingerId = -1; // 0x4C
		[SerializeField]
		private string m_HorizontalAxis = "Horizontal"; // 0x50
		[SerializeField]
		private string m_VerticalAxis = "Vertical"; // 0x54
		[SerializeField]
		private string m_SubmitButton = "Submit"; // 0x58
		[SerializeField]
		private string m_CancelButton = "Cancel"; // 0x5C
		[SerializeField]
		private float m_InputActionsPerSecond = 10; // 0x60
		[SerializeField]
		private float m_RepeatDelay = 0.5f; // 0x64
		[FormerlySerializedAs("m_AllowActivationOnMobileDevice")] // RVA: 0x68F464 Offset: 0x68F464 VA: 0x68F464
		[SerializeField]
		private bool m_ForceModuleActive; // 0x68
		private int m_disableTouchBit; // 0x6C

		[Obsolete("Mode is no longer needed on input module as it handles both mouse and keyboard simultaneously.", false)] // RVA: 0x7498E4 Offset: 0x7498E4 VA: 0x7498E4
		public CustomInputModule.InputMode inputMode { get { return InputMode.Mouse; } } //0x1D6B934
		[Obsolete("allowActivationOnMobileDevice has been deprecated. Use forceModuleActive instead (UnityUpgradable) -> forceModuleActive")] // RVA: 0x74991C Offset: 0x74991C VA: 0x74991C
		public bool allowActivationOnMobileDevice { get { return m_ForceModuleActive; } set { m_ForceModuleActive = value; } } //0x1D6B93C 0x1D6B944
		public bool forceModuleActive { get { return m_ForceModuleActive; } set { m_ForceModuleActive = value; } } //0x1D6B94C 0x1D6B954
		public float inputActionsPerSecond { get { return m_InputActionsPerSecond; } set { m_InputActionsPerSecond = value; } } //0x1D6B95C 0x1D6B964
		public float repeatDelay { get { return m_RepeatDelay; } set { m_RepeatDelay = value; } } //0x1D6B96C 0x1D6B974
		public string horizontalAxis { get { return m_HorizontalAxis; } set { m_HorizontalAxis = value; } } //0x1D6B97C 0x1D6B984
		public string verticalAxis { get { return m_VerticalAxis; } set { m_VerticalAxis = value; } } //0x1D6B98C 0x1D6B994
		public string submitButton { get { return m_SubmitButton; } set { m_SubmitButton = value; } } //0x1D6B99C 0x1D6B9A4
		public string cancelButton { get { return m_CancelButton; } set { m_CancelButton = value; } } //0x1D6B9AC 0x1D6B9B4
		
		// RVA: 0x1D6B9BC Offset: 0x1D6B9BC VA: 0x1D6B9BC Slot: 24
		public override void UpdateModule()
		{
			m_LastMousePosition = m_MousePosition;
			m_MousePosition = Input.mousePosition;
		}

		// RVA: 0x1D6BA7C Offset: 0x1D6BA7C VA: 0x1D6BA7C Slot: 25
		public override bool IsModuleSupported()
		{
			if(!m_ForceModuleActive)
			{
				if(!Input.mousePresent)
				{
					return Input.touchSupported;
				}
			}
			return true;
		}

		// RVA: 0x1D6BAB4 Offset: 0x1D6BAB4 VA: 0x1D6BAB4 Slot: 21
		public override bool ShouldActivateModule()
		{
			if(base.ShouldActivateModule())
			{
				return Input.touchCount > 0 || Input.GetMouseButtonDown(0) ||
					m_ForceModuleActive || Input.GetButtonDown(m_SubmitButton) ||
					Input.GetButtonDown(m_CancelButton) || !Mathf.Approximately(Input.GetAxisRaw(m_HorizontalAxis), 0) ||
					!Mathf.Approximately(Input.GetAxisRaw(m_VerticalAxis), 0) || (m_MousePosition - m_LastMousePosition).sqrMagnitude >= 0;
			}
			return false;
		}

		// RVA: 0x1D6BC84 Offset: 0x1D6BC84 VA: 0x1D6BC84 Slot: 23
		public override void ActivateModule()
		{
			base.ActivateModule();
			m_MousePosition = Input.mousePosition;
			m_LastMousePosition = Input.mousePosition;
			GameObject g = eventSystem.currentSelectedGameObject;
			if (g == null)
				g = eventSystem.firstSelectedGameObject;
			eventSystem.SetSelectedGameObject(g, GetBaseEventData());
		}

		// RVA: 0x1D6BE64 Offset: 0x1D6BE64 VA: 0x1D6BE64 Slot: 22
		public override void DeactivateModule()
		{
			base.DeactivateModule();
			ClearSelection();
		}

		// RVA: 0x1D6BE88 Offset: 0x1D6BE88 VA: 0x1D6BE88 Slot: 17
		public override void Process()
		{
			bool b = SendUpdateEventToSelectedObject();
			if(!b && eventSystem.sendNavigationEvents && !SendMoveEventToSelectedObject())
			{
				SendSubmitEventToSelectedObject();
			}
			if(!ProcessTouchEvents())
			{
				if (!Input.mousePresent)
					return;
				ProcessMouseEvent(0);
			}
		}

		//// RVA: 0x1D6C608 Offset: 0x1D6C608 VA: 0x1D6C608
		private bool ProcessTouchEvents()
		{
			Rect r = SystemManager.rawAppScreenRect;
			int a = 0;
			int c = -1;
			int d = 0;
			for(int i = 0; i < Input.touchCount; i++)
			{
				Touch info = Input.GetTouch(i);
				if(info.type == TouchType.Indirect)
				{
					if(r.x < info.position.x)
					{
						if(info.position.x <= r.xMax)
						{
							if(r.y < info.position.y)
							{
								if(info.position.y <= r.yMax)
								{
									if((m_disableTouchBit & (1 << (info.fingerId & 0x1f))) == 0)
									{
										m_LastFingerId = info.fingerId;
										a = 1 << (info.fingerId & 0x1f);
										c = i;
										d = info.fingerId;
										break;
									}
								}
							}
						}
					}
				}
			}
			for(int i = 0; i < Input.touchCount; i++)
			{
				Touch info = Input.GetTouch(i);
				if (info.type != TouchType.Indirect)
				{
					if (r.x < info.position.x)
					{
						if (info.position.x <= r.xMax)
						{
							if (r.y < info.position.y)
							{
								if (info.position.y <= r.yMax)
								{
									a = a | (1 << (info.fingerId & 0x1f));
									if(d != info.fingerId)
									{
										m_disableTouchBit |= 1 << (info.fingerId & 0x1f);
									}
								}
							}
						}
					}
				}
			}
			m_disableTouchBit &= a;
			if(c < 0)
			{
				if (Input.touchCount < 1)
					return false;
				for(int i = 0; i < Input.touchCount; i++)
				{
					Touch info = Input.GetTouch(i);
					if(info.fingerId != m_LastFingerId)
					{
						bool press, release;
						PointerEventData edata = GetTouchPointerEventData(info, out press, out release);
						ProcessTouchPress(edata, press, release);
						if (!release)
							return false;
						RemovePointerData(edata);
						m_LastFingerId = -1;
						return false;
					}
				}
				return false;
			}
			{
				Touch info = Input.GetTouch(c);
				bool press, release;
				PointerEventData edata = GetTouchPointerEventData(info, out press, out release);
				ProcessTouchPress(edata, press, release);
				if (release)
				{
					RemovePointerData(edata);
					return true;
				}
				if (r.x < info.position.x)
				{
					if (info.position.x <= r.xMax)
					{
						if (r.y < info.position.y)
						{
							if (info.position.y <= r.yMax)
							{
								return true;
							}
						}
					}
				}
				ProcessMove(edata);
				ProcessDrag(edata);
			}
			return true;
		}

		//// RVA: 0x1D6CDF0 Offset: 0x1D6CDF0 VA: 0x1D6CDF0
		private void ProcessTouchPress(PointerEventData pointerEvent, bool pressed, bool released)
		{
			RaycastResult rayCast = pointerEvent.pointerCurrentRaycast;
			GameObject g = rayCast.gameObject;
			if (pressed)
			{
				pointerEvent.eligibleForClick = true;
				pointerEvent.delta = Vector2.zero;
				pointerEvent.dragging = false;
				pointerEvent.useDragThreshold = true;
				pointerEvent.pressPosition = pointerEvent.position;
				pointerEvent.pointerPressRaycast = pointerEvent.pointerCurrentRaycast;
				DeselectIfSelectionChanged(g, pointerEvent);
				if(pointerEvent.pointerEnter != g)
				{
					HandlePointerExitAndEnter(pointerEvent, g);
					pointerEvent.pointerEnter = g;
				}
				GameObject g2 = ExecuteEvents.ExecuteHierarchy(g, pointerEvent, ExecuteEvents.pointerDownHandler);
				if(g2 == null)
				{
					g2 = ExecuteEvents.GetEventHandler<IPointerClickHandler>(g);
				}
				float t = Time.unscaledTime;
				if (pointerEvent.lastPress == g2)
				{
					int count = 0;
					if (0.3f <= t - pointerEvent.clickTime)
						count = 1;
					else
						count = pointerEvent.clickCount + 1;
					pointerEvent.clickCount = count;
					pointerEvent.clickTime = t;
				}
				else
					pointerEvent.clickCount = 1;
				pointerEvent.pointerPress = g2;
				pointerEvent.rawPointerPress = g;
				pointerEvent.clickTime = t;
				pointerEvent.pointerDrag = ExecuteEvents.GetEventHandler<IDragHandler>(g);
				if(pointerEvent.pointerDrag != null)
				{
					ExecuteEvents.Execute(pointerEvent.pointerDrag, pointerEvent, ExecuteEvents.initializePotentialDrag);
				}
			}
			if (released)
			{
				ExecuteEvents.Execute(pointerEvent.pointerPress, pointerEvent, ExecuteEvents.pointerUpHandler);
				GameObject g2 = ExecuteEvents.GetEventHandler<IPointerClickHandler>(g);
				if(pointerEvent.pointerPress == g2 && pointerEvent.eligibleForClick)
				{
					ExecuteEvents.Execute(pointerEvent.pointerPress, pointerEvent, ExecuteEvents.pointerClickHandler);
				}
				else
				{
					if(pointerEvent.pointerDrag != null)
					{
						if(pointerEvent.dragging)
						{
							ExecuteEvents.ExecuteHierarchy(g, pointerEvent, ExecuteEvents.dropHandler);
						}
					}
				}
				pointerEvent.eligibleForClick = false;
				pointerEvent.pointerPress = null;
				pointerEvent.rawPointerPress = null;
				if(pointerEvent.pointerDrag != null)
				{
					if(pointerEvent.dragging)
					{
						ExecuteEvents.Execute(pointerEvent.pointerDrag, pointerEvent, ExecuteEvents.endDragHandler);
					}
				}
				pointerEvent.dragging = false;
				pointerEvent.pointerDrag = null;
				if (pointerEvent.pointerDrag != null)
				{
					ExecuteEvents.Execute(pointerEvent.pointerDrag, pointerEvent, ExecuteEvents.endDragHandler);
				}
				pointerEvent.pointerDrag = null;
				ExecuteEvents.ExecuteHierarchy(pointerEvent.pointerEnter, pointerEvent, ExecuteEvents.pointerExitHandler);
				pointerEvent.pointerEnter = null;
			}
		}

		//// RVA: 0x1D6C3D4 Offset: 0x1D6C3D4 VA: 0x1D6C3D4
		protected bool SendSubmitEventToSelectedObject()
		{
			GameObject g = eventSystem.currentSelectedGameObject;
			if (g == null)
				return false;
			BaseEventData ev = GetBaseEventData();
			if(Input.GetButtonDown(m_SubmitButton))
			{
				ExecuteEvents.Execute(g, ev, ExecuteEvents.submitHandler);
			}
			if(Input.GetButtonDown(m_CancelButton))
			{
				ExecuteEvents.Execute(g, ev, ExecuteEvents.cancelHandler);
			}
			return ev.used;
		}

		//// RVA: 0x1D6DB50 Offset: 0x1D6DB50 VA: 0x1D6DB50
		private Vector2 GetRawMoveVector()
		{
			float x = Input.GetAxisRaw(m_HorizontalAxis);
			float y = Input.GetAxisRaw(m_VerticalAxis);
			if (Input.GetButtonDown(m_HorizontalAxis))
			{
				if (x < 0)
					x = -1;
				if (x >= 0)
					x = 1;
			}
			if(Input.GetButtonDown(m_VerticalAxis))
			{
				if (y < 0)
					y = -1;
				if (y >= 0)
					y = 1;
			}
			return new Vector2(x, y);
		}

		//// RVA: 0x1D6C0A0 Offset: 0x1D6C0A0 VA: 0x1D6C0A0
		protected bool SendMoveEventToSelectedObject()
		{
			Vector2 v = GetRawMoveVector();
			if(Mathf.Approximately(v.x, 0))
			{
				if(Mathf.Approximately(v.y, 0))
				{
					m_ConsecutiveMoveCount = 0;
					return false;
				}
			}
			bool b = false;
			if (!Input.GetButtonDown(m_HorizontalAxis))
				b = !Input.GetButtonDown(m_VerticalAxis);
			float f = Vector2.Dot(v, m_LastMoveVector);
			float t = Time.unscaledTime;
			if (b)
			{
				float f2 = 0;
				if (f < 0 || m_ConsecutiveMoveCount != 1)
					f2 = m_PrevActionTime + 1.0f / m_InputActionsPerSecond;
				else
					f2 = m_PrevActionTime + m_RepeatDelay;
				if (t < f2)
					return false;
			}
			AxisEventData ae = GetAxisEventData(v.x, v.y, 0.6f);
			if (ae.moveDir == MoveDirection.None)
				m_ConsecutiveMoveCount = 0;
			else
			{
				if(f < 0)
				{
					m_ConsecutiveMoveCount = 1;
				}
				else
				{
					m_ConsecutiveMoveCount++;
				}
				m_PrevActionTime = t;
				m_LastMoveVector = v;
			}
			return ae.used;
		}

		//// RVA: 0x1D6CDE8 Offset: 0x1D6CDE8 VA: 0x1D6CDE8
		//protected void ProcessMouseEvent() { }

		//// RVA: 0x1D6DC74 Offset: 0x1D6DC74 VA: 0x1D6DC74
		protected void ProcessMouseEvent(int id)
		{
			MouseState ev = GetMousePointerEventData(id);
			MouseButtonEventData data1 = ev.GetButtonState(PointerEventData.InputButton.Left).eventData;
			ProcessMousePress(data1);
			ProcessMove(data1.buttonData);
			ProcessDrag(data1.buttonData);
			MouseButtonEventData data = ev.GetButtonState(PointerEventData.InputButton.Right).eventData;
			ProcessMousePress(data);
			ProcessDrag(data.buttonData);
			data = ev.GetButtonState(PointerEventData.InputButton.Middle).eventData;
			ProcessMousePress(data);
			ProcessDrag(data.buttonData);
			if(!Mathf.Approximately(data1.buttonData.scrollDelta.sqrMagnitude, 0))
			{
				ExecuteEvents.ExecuteHierarchy(ExecuteEvents.GetEventHandler<IScrollHandler>(data1.buttonData.pointerCurrentRaycast.gameObject), data1.buttonData, ExecuteEvents.scrollHandler);
			}
		}

		//// RVA: 0x1D6BF1C Offset: 0x1D6BF1C VA: 0x1D6BF1C
		protected bool SendUpdateEventToSelectedObject()
		{
			GameObject g = eventSystem.currentSelectedGameObject;
			if (g == null)
				return false;
			BaseEventData eventData = GetBaseEventData();
			ExecuteEvents.Execute(g, eventData, ExecuteEvents.updateSelectedHandler);
			return eventData.used;
		}

		//// RVA: 0x1D6E06C Offset: 0x1D6E06C VA: 0x1D6E06C
		protected void ProcessMousePress(MouseButtonEventData data)
		{
			GameObject g = data.buttonData.pointerCurrentRaycast.gameObject;
			if(data.PressedThisFrame())
			{
				data.buttonData.eligibleForClick = true;
				data.buttonData.delta = Vector2.zero;
				data.buttonData.dragging = false;
				data.buttonData.useDragThreshold = true;
				data.buttonData.pressPosition = data.buttonData.position;
				data.buttonData.pointerPressRaycast = data.buttonData.pointerCurrentRaycast;
				DeselectIfSelectionChanged(g, data.buttonData);
				GameObject g2 = ExecuteEvents.ExecuteHierarchy(g, data.buttonData, ExecuteEvents.pointerDownHandler);
				if(g2 == null)
				{
					g2 = ExecuteEvents.GetEventHandler<IPointerClickHandler>(g);
				}
				float t = Time.unscaledTime;
				if(g2 == data.buttonData.lastPress)
				{
					int count = 0;
					if (0.3f <= t - data.buttonData.clickTime)
						count = 1;
					else
						count = data.buttonData.clickCount + 1;
					data.buttonData.clickCount = count;
					data.buttonData.clickTime = t;
				}
				else
				{
					data.buttonData.clickCount = 1;
				}
				data.buttonData.pointerPress = g2;
				data.buttonData.rawPointerPress = g;
				data.buttonData.clickTime = t;
				data.buttonData.pointerDrag = ExecuteEvents.GetEventHandler<IDragHandler>(g);
				if(data.buttonData.pointerDrag != null)
				{
					ExecuteEvents.Execute(data.buttonData.pointerDrag, data.buttonData, ExecuteEvents.initializePotentialDrag);
				}
			}
			if(data.ReleasedThisFrame())
			{
				ExecuteEvents.Execute(data.buttonData.pointerPress, data.buttonData, ExecuteEvents.pointerUpHandler);
				GameObject g2 = ExecuteEvents.GetEventHandler<IPointerClickHandler>(g);
				if(data.buttonData.pointerPress == g2 && data.buttonData.eligibleForClick)
				{
					ExecuteEvents.Execute(data.buttonData.pointerPress, data.buttonData, ExecuteEvents.pointerClickHandler);
				}
				else
				{
					if(data.buttonData.pointerDrag != null && data.buttonData.dragging)
					{
						ExecuteEvents.ExecuteHierarchy(g, data.buttonData, ExecuteEvents.dropHandler);
					}
				}
				data.buttonData.eligibleForClick = false;
				data.buttonData.pointerPress = null;
				data.buttonData.rawPointerPress = null;
				if(data.buttonData.pointerDrag != null && data.buttonData.dragging)
				{
					ExecuteEvents.Execute(data.buttonData.pointerDrag, data.buttonData, ExecuteEvents.endDragHandler);
				}
				data.buttonData.dragging = false;
				data.buttonData.pointerDrag = null;
				if(data.buttonData.pointerEnter != null)
				{
					HandlePointerExitAndEnter(data.buttonData, null);
					HandlePointerExitAndEnter(data.buttonData, g);
				}
			}
		}
	}
}
