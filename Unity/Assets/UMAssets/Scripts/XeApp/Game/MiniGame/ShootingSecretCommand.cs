using System;
using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingSecretCommand : MonoBehaviour
	{
		public enum Command
		{
			None = -1,
			Up = 0,
			Down = 1,
			Right = 2,
			Left = 3,
			Shot = 4,
		}

		[SerializeField]
		private Command[] m_secretCommand; // 0xC
		[SerializeField]
		private float m_secretResetTimeMax; // 0x10
		private float m_secretResetTime; // 0x14
		private int m_secretCommandCount; // 0x18
		private bool m_isSecretCommand; // 0x1C
		private bool m_isInputKey = true; // 0x1D
		private Command m_checkCommand; // 0x20

		public bool IsSecretCommand { get { return m_isSecretCommand; } private set { m_isSecretCommand = value; } } //0xC90CF0 0xC8DE14
		public VirtualPad VirtualPad { get; set; } // 0x24
		public Action SuccessCallBack { get; set; } // 0x28

		//// RVA: 0xC90D18 Offset: 0xC90D18 VA: 0xC90D18
		private bool CheckSecretCommand(Command command)
		{
			Vector3 v = VirtualPad.Stick.Axis;
			bool res = false;
			for(int i = 0; i < VirtualPad.Buttons.Length; i++)
			{
				if(VirtualPad.Buttons[i].ButtonId == 1)
				{
					res |= VirtualPad.Buttons[i].IsPress;
				}
			}
			switch(command)
			{
				case Command.Up:
					return v.y > 0;
				case Command.Down:
					return v.y < 0;
				case Command.Right:
					return v.x > 0;
				case Command.Left:
					return v.x < 0;
				case Command.Shot:
					return res;
				default:
					return false;
			}
		}

		//// RVA: 0xC90F0C Offset: 0xC90F0C VA: 0xC90F0C
		private bool IsInputKey()
		{
			Vector3 v = VirtualPad.Stick.Axis;
			bool res = false;
			for (int i = 0; i < VirtualPad.Buttons.Length; i++)
			{
				if (VirtualPad.Buttons[i].ButtonId == 1)
				{
					res |= VirtualPad.Buttons[i].IsPress;
				}
			}
			return res || v.x != 0 || v.y != 0;
		}

		//// RVA: 0xC910B4 Offset: 0xC910B4 VA: 0xC910B4
		public void OnUpdate(float elapsedTime)
		{
			if (!m_isInputKey && !CheckSecretCommand(m_checkCommand))
				m_isInputKey = true;
			if(!m_isSecretCommand)
			{
				m_secretResetTime += elapsedTime;
				if(m_secretResetTimeMax <= m_secretResetTime)
				{
					m_secretResetTime = 0;
					m_secretCommandCount = 0;
					m_isSecretCommand = false;
					m_isInputKey = true;
					m_checkCommand = Command.None;
				}
				if(IsInputKey() && m_isInputKey)
				{
					if(CheckSecretCommand(m_secretCommand[m_secretCommandCount]))
					{
						if (m_secretCommandCount == 0)
							m_secretResetTime = 0;
						m_isInputKey = false;
						m_checkCommand = m_secretCommand[m_secretCommandCount];
						m_secretCommandCount++;
						if(m_secretCommand.Length <= m_secretCommandCount)
						{
							m_isSecretCommand = true;
							m_secretCommandCount = 0;
							if (SuccessCallBack != null)
								SuccessCallBack();
							return;
						}
					}
					else
					{
						m_secretResetTime = 0;
						m_secretCommandCount = 0;
						m_isSecretCommand = false;
						m_isInputKey = true;
						m_checkCommand = Command.None;
					}
				}
			}
		}

		//// RVA: 0xC91260 Offset: 0xC91260 VA: 0xC91260
		public void ResetParam()
		{
			m_secretResetTime = 0;
			m_secretCommandCount = 0;
			m_isSecretCommand = false;
			m_isInputKey = true;
			m_checkCommand = Command.None;
		}
	}
}
