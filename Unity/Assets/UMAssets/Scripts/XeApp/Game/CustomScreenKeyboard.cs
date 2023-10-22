using XeSys.Gfx;
using System.Collections.Generic;
using XeApp.Game.Common;
using UnityEngine;
using XeSys;
using XeApp.Game.Menu;
using System;

namespace XeApp.Game
{
	public class CustomScreenKeyboard : LayoutUGUIScriptBase
	{
		[SerializeField]
		private List<ButtonBase> CustomInputList = new List<ButtonBase>(); // 0x14
		public int InputFieldCount; // 0x18
		public TouchScreenKeyboard m_keyboard; // 0x1C
		public bool IsOpenKeyboard; // 0x20
		private int m_characterLimit; // 0x24
		private string m_Text = ""; // 0x28
		private bool IsTouchInputField; // 0x2C
		private int m_tapGuardCount; // 0x30
		private bool m_closeEnd = true; // 0x34

		//public bool IsActive { get; set; } 0xD39DDC 0xD39E08
		//public bool IsDone { get; set; } 0xD39E3C 0xD39E68
		//public bool IsCancel { get; set; } 0xD39E6C 0xD39E98

		// RVA: 0xD39E9C Offset: 0xD39E9C VA: 0xD39E9C
		public void LateUpdate()
		{
			if(m_keyboard != null)
			{
				SettingKeyBoardText();
				if(m_keyboard.done || m_keyboard.wasCanceled || InputManager.Instance.GetInScreenTouchCount() > 0)
				{
					if(!IsTouchInputField)
					{
						m_keyboard.active = false;
						IsOpenKeyboard = false;
						m_keyboard = null;
						m_closeEnd = false;
					}
				}
			}
			if (InputManager.Instance.touchCount > 0)
				return;
			IsTouchInputField = false;
			if (m_closeEnd)
				return;
			m_closeEnd = true;
			TapGuardOFF();
		}

		//// RVA: 0xD3A1E8 Offset: 0xD3A1E8 VA: 0xD3A1E8
		public string GetKeyboardText()
		{
			return m_Text;
		}

		//// RVA: 0xD3A06C Offset: 0xD3A06C VA: 0xD3A06C
		private void SettingKeyBoardText()
		{
			if(m_characterLimit > 0)
			{
				if(m_characterLimit < m_Text.Length)
				{
					m_Text = m_keyboard.text.Substring(0, m_characterLimit);
					m_keyboard.text = m_Text;
					return;
				}
			}
			m_Text = m_keyboard.text;
		}

		//// RVA: 0xD3A1F0 Offset: 0xD3A1F0 VA: 0xD3A1F0
		public void SetOnClickInputField(int _index, Action ClickInput)
		{
			CustomInputList[_index].ClearOnClickCallback();
			CustomInputList[_index].AddOnClickCallback(() =>
			{
				//0xD3A750
				ClickInput();
			});
		}

		//// RVA: 0xD3A35C Offset: 0xD3A35C VA: 0xD3A35C
		public void OpenKeyboard(string _text, int charaLimit, TouchScreenKeyboardType _type = 0, bool autocorrection = false, bool mulitline = false, bool secure = false, bool alert = false, string textPlaceholder = "")
		{
			m_keyboard = TouchScreenKeyboard.Open(_text, _type, autocorrection, mulitline, secure, alert, textPlaceholder);
			IsOpenKeyboard = true;
			IsTouchInputField = true;
			m_characterLimit = charaLimit;
			m_Text = "";
			TapGuardON();
		}

		//// RVA: 0xD3A430 Offset: 0xD3A430 VA: 0xD3A430
		private void TapGuardON()
		{
			MenuScene.Instance.InputDisable();
			m_tapGuardCount++;
		}

		//// RVA: 0xD3A130 Offset: 0xD3A130 VA: 0xD3A130
		private void TapGuardOFF()
		{
			if (m_tapGuardCount < 1)
				return;
			MenuScene.Instance.InputEnable();
			m_tapGuardCount--;
		}

		//// RVA: 0xD3A4DC Offset: 0xD3A4DC VA: 0xD3A4DC
		//private void TapGuardAllOFF() { }

		//// RVA: 0xD3A5A4 Offset: 0xD3A5A4 VA: 0xD3A5A4
		//public void SetEnableInputFieldArea(bool _enable) { }
	}
}
