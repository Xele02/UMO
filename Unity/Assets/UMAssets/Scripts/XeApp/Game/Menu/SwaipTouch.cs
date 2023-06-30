using XeSys.Gfx;
using UnityEngine;
using System.Collections.Generic;
using System;
using XeSys;
using XeApp.Game.Common;
using mcrs;

namespace XeApp.Game.Menu
{
	public class SwaipTouch : LayoutUGUIScriptBase
	{
		private enum SwaipState
		{
			Initializeing = 0,
			Wait = 1,
			Swaip = 2,
		}

		public enum Direction
		{
			RIGHT = 1,
			LEFT = 2,
			UP = 4,
			DOWN = 8,
		}

		private bool m_is_swaip; // 0x11
		[SerializeField]
		private bool m_is_swaip_width_flag = true; // 0x12
		[SerializeField]
		private bool m_is_swaip_height_flag = true; // 0x13
		private Vector3 m_old_pos; // 0x14
		private float m_width; // 0x20
		private float m_height; // 0x24
		[SerializeField]
		private float m_swaip_width_value = 100; // 0x28
		[SerializeField]
		private float m_swaip_height_value = 100; // 0x2C
		[SerializeField]
		private float m_flick_width_value = 100; // 0x30
		[SerializeField]
		private float m_flick_height_value = 100; // 0x34
		[SerializeField]
		private bool m_ignoreActivePopup; // 0x38
		private int m_input_swaip; // 0x3C
		private int m_input_flick; // 0x40
		private bool m_is_once = true; // 0x44
		private bool m_stop; // 0x45
		private bool m_is_mute; // 0x46
		private Camera uiCamera; // 0x48
		private SwaipState m_swaipState; // 0x4C
		[SerializeField] // RVA: 0x670464 Offset: 0x670464 VA: 0x670464
		private RectTransform m_hit_check; // 0x50
		private const int LIST_MAX = 5;
		private List<Vector3> m_acceleration_list = new List<Vector3>(); // 0x54
		private Action m_updater; // 0x58

		// // RVA: 0xF964F8 Offset: 0xF964F8 VA: 0xF964F8
		public bool IsReady()
		{
			return m_swaipState != SwaipState.Initializeing;
		}

		// // RVA: 0xF96508 Offset: 0xF96508 VA: 0xF96508
		public void ResetCanvas()
		{
			if (GetCanvas() == null)
				return;
			uiCamera = GetCanvas().worldCamera;
		}

		// RVA: 0xF9668C Offset: 0xF9668C VA: 0xF9668C
		private void Start()
		{
			m_swaipState = SwaipState.Initializeing;
			m_updater = UpdateLoad;
		}

		// RVA: 0xF9671C Offset: 0xF9671C VA: 0xF9671C
		private void Update()
		{
			m_input_swaip = 0;
			m_input_flick = 0;
			m_updater();
		}

		// // RVA: 0xF96754 Offset: 0xF96754 VA: 0xF96754
		private void UpdateLoad()
		{
			if(GetCanvas() == null)
				return;
			uiCamera = GetCanvas().worldCamera;
			Loaded();
			InitList();
			m_swaipState = SwaipState.Wait;
			m_updater = UpdateIdle;
		}

		// // RVA: 0xF96964 Offset: 0xF96964 VA: 0xF96964
		private void UpdateIdle()
		{
			TouchInfoRecord first = InputManager.Instance.GetFirstInScreenTouchRecord();
			if(first == null)
				return;
			if(first.currentInfo.isIllegal)
				return;
			if(IsTouchEnableArea(first.currentInfo.nativePosition))
			{
				if(!m_ignoreActivePopup)
				{
					if(PopupWindowManager.IsActivePopupWindow())
					{
						m_updater = UpdateNotSwaip;
						return;
					}
				}
				m_old_pos = first.currentInfo.nativePosition;
				m_width = 0;
				m_height = 0;
				m_is_swaip = true;
				InitList();
				m_swaipState = SwaipState.Swaip;
				m_updater = UpdateSwaip;
			}
			else
			{
				m_updater = UpdateNotSwaip;
			}
		}

		// // RVA: 0xF96C50 Offset: 0xF96C50 VA: 0xF96C50
		private void UpdateSwaip()
		{
			bool b = false;
            TouchInfoRecord record = InputManager.Instance.GetFirstInScreenTouchRecord();
			if(record == null)
			{
				InputFlick();
				m_swaipState = SwaipState.Wait;
	            m_updater = UpdateIdle;
			}
			else
			{
				if(!record.currentInfo.isIllegal)
				{
					ChangeList(record.currentInfo.nativePosition - m_old_pos);
					if(!m_stop)
					{
						m_width += record.currentInfo.nativePosition.x - m_old_pos.x;
						m_height += record.currentInfo.nativePosition.y - m_old_pos.y;
					}
					if(m_is_swaip_width_flag && m_is_swaip)
					{
						if(m_swaip_width_value <= m_width)
						{
							m_input_swaip |= 1;
							if(m_is_once)
							{
								m_is_swaip = false;
							}
							else
							{
								m_width = 0;
							}
							b = true;
						}
						else if(-m_swaip_width_value >= m_width)
						{
							m_input_swaip |= 2;
							if(m_is_once)
							{
								m_is_swaip = false;
							}
							else
							{
								m_width = 0;
							}
							b = true;
						}
					}
					if(m_is_swaip_height_flag && m_is_swaip)
					{
						if(m_swaip_height_value <= m_height)
						{
							m_input_swaip |= 8;
							if(m_is_once)
							{
								m_is_swaip = false;
							}
							else
							{
								m_height = 0;
							}
							b = true;
						}
						else if(-m_swaip_height_value >= m_height)
						{
							m_input_swaip |= 4;
							if(m_is_once)
							{
								m_is_swaip = false;
							}
							else
							{
								m_height = 0;
							}
							b = true;
						}
					}
					m_old_pos = record.currentInfo.nativePosition;
				}
			}
			//LAB_00f96f3c
			if(!m_ignoreActivePopup)
			{
				if(PopupWindowManager.IsActivePopupWindow())
				{
					m_swaipState = SwaipState.Wait;
					m_updater = UpdateIdle;
				}
			}
			if(b && m_is_mute == false)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_004);
			}
		}

		// // RVA: 0xF971DC Offset: 0xF971DC VA: 0xF971DC
		private void UpdateNotSwaip()
		{
			if(InputManager.Instance.GetFirstInScreenTouchRecord() == null)
				m_updater = UpdateIdle;
		}

		// // RVA: 0xF972C0 Offset: 0xF972C0 VA: 0xF972C0
		public void Stop(bool flag)
		{
			m_stop = flag;
		}

		// // RVA: 0xF972C8 Offset: 0xF972C8 VA: 0xF972C8
		public bool IsStop()
		{
			return m_stop;
		}

		// // RVA: 0xF972D0 Offset: 0xF972D0 VA: 0xF972D0
		public void SetMute(bool isMute)
		{
			m_is_mute = isMute;
		}

		// // RVA: 0xF971D4 Offset: 0xF971D4 VA: 0xF971D4
		// public bool IsMute() { }

		// // RVA: 0xF972D8 Offset: 0xF972D8 VA: 0xF972D8
		public void ResetValue()
		{
			InitList();
			m_width = 0;
			m_height = 0;
		}

		// // RVA: 0xF972F8 Offset: 0xF972F8 VA: 0xF972F8
		public void ResetInputState()
		{
			if(IsLoaded())
			{
				m_updater = UpdateIdle;
			}
		}

		// // RVA: 0xF97394 Offset: 0xF97394 VA: 0xF97394
		// public void ResetInput() { }

		// // RVA: 0xF973A4 Offset: 0xF973A4 VA: 0xF973A4
		// public void SetAdjustment(bool width_flag, bool height_flag, int width_swaip = 50, int height_swaip = 50, int width_flick = 50, int height_flick = 50, bool once = True) { }

		// // RVA: 0xF973E8 Offset: 0xF973E8 VA: 0xF973E8
		public bool IsSwaip(SwaipTouch.Direction dir)
		{
			return (m_input_swaip & (int)dir) == (int)dir;
		}

		// // RVA: 0xF97400 Offset: 0xF97400 VA: 0xF97400
		// public bool IsFlick(SwaipTouch.Direction dir) { }

		// // RVA: 0xF97418 Offset: 0xF97418 VA: 0xF97418
		public bool IsFlickNoSwaip(SwaipTouch.Direction dir)
		{
			if(m_is_swaip)
			{
				return (m_input_flick & (int)dir) == (int)dir;
			}
			return false;
		}

		// // RVA: 0xF97440 Offset: 0xF97440 VA: 0xF97440
		public bool IsSwaiping()
		{
			if(m_is_swaip)
				return false;
			return m_swaipState == SwaipState.Swaip;
		}

		// // RVA: 0xF97468 Offset: 0xF97468 VA: 0xF97468
		public bool IsMoveFlickDistance()
		{
			if(m_is_swaip_width_flag)
			{
				if(m_flick_width_value <= Mathf.Abs(CalcWidthAcceleration()))
					return true;
			}
			if(m_is_swaip_height_flag)
			{
				if(m_flick_height_value <= Mathf.Abs(CalcHeightAcceleration()))
					return true;
			}
			return false;
		}

		// // RVA: 0xF976F4 Offset: 0xF976F4 VA: 0xF976F4
		public void SetHitCheck(RectTransform rect)
		{
			m_hit_check = rect;
		}

		// // RVA: 0xF97114 Offset: 0xF97114 VA: 0xF97114
		// private void InputSwaip(SwaipTouch.Direction dir) { }

		// // RVA: 0xF97124 Offset: 0xF97124 VA: 0xF97124
		private void InputFlick()
		{
			float w = CalcWidthAcceleration();
			float h = CalcHeightAcceleration();
			if(m_is_swaip_width_flag)
			{
				if(m_flick_width_value <= w)
				{
					m_input_flick |= 1;
				}
				else if(-m_flick_width_value >= w)
				{
					m_input_flick |= 2;
				}
			}
			if(m_is_swaip_height_flag)
			{
				if(m_flick_height_value <= w)
				{
					m_input_flick |= 8;
				}
				else if(-m_flick_height_value >= w)
				{
					m_input_flick |= 4;
				}
			}
		}

		// // RVA: 0xF96868 Offset: 0xF96868 VA: 0xF96868
		private void InitList()
		{
			m_acceleration_list.Clear();
			for(int i = 5; i > 0; i--)
			{
				m_acceleration_list.Add(new Vector3(0, 0, 0));
			}
		}

		// // RVA: 0xF97584 Offset: 0xF97584 VA: 0xF97584
		private float CalcWidthAcceleration()
		{
			float res = 0;
			for(int i = 0; i < 5; i++)
			{
				res += m_acceleration_list[i].x;
			}
			return res;
		}

		// // RVA: 0xF9763C Offset: 0xF9763C VA: 0xF9763C
		private float CalcHeightAcceleration()
		{
			float res = 0;
			for(int i = 0; i < 5; i++)
			{
				res += m_acceleration_list[i].y;
			}
			return res;
		}

		// // RVA: 0xF97048 Offset: 0xF97048 VA: 0xF97048
		private void ChangeList(Vector3 pos)
		{
			m_acceleration_list.RemoveAt(0);
			m_acceleration_list.Add(pos);
		}

		// // RVA: 0xF965C4 Offset: 0xF965C4 VA: 0xF965C4
		private Canvas GetCanvas()
		{
			Canvas res = GetComponent<Canvas>();
			if(res == null)
				res = GetComponentInParent<Canvas>();
			return res;
		}

		// // RVA: 0xF96B88 Offset: 0xF96B88 VA: 0xF96B88
		private bool IsTouchEnableArea(Vector3 touchPosition)
		{
			return RectTransformUtility.RectangleContainsScreenPoint(m_hit_check, touchPosition, uiCamera);
		}
	}
}
