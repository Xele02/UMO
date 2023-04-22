using XeSys.Gfx;
using System;
using UnityEngine.Events;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class ToggleButtonGroup : LayoutUGUIScriptBase
	{
		[Serializable]
		public class SelectButtonEvent : UnityEvent<int>
		{
		}

		[SerializeField]
		private short m_gropId; // 0x12
		[SerializeField]
		private ToggleButton[] m_toggleButtons; // 0x14
		[SerializeField]
		private SelectButtonEvent m_onSelectToggleButtonEvent; // 0x18

		// public short GropID { get; } 0x1CCF6D0
		public SelectButtonEvent OnSelectToggleButtonEvent { get { return m_onSelectToggleButtonEvent; } } //0x1CCF6D8

		// RVA: 0x1CCF6E0 Offset: 0x1CCF6E0 VA: 0x1CCF6E0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			for(int i = 0; i < m_toggleButtons.Length; i++)
			{
				int index = i;
				m_toggleButtons[i].AddOnClickCallback(() => {
					//0x1CCF9CC
					m_onSelectToggleButtonEvent.Invoke(index);
				});
			}
			return base.InitializeFromLayout(layout, uvMan);
		}

        public ToggleButton[] GetM_toggleButtons()
        {
            return m_toggleButtons;
        }

        // // RVA: 0x1CCF400 Offset: 0x1CCF400 VA: 0x1CCF400
        public void SelectGroupButton(ToggleButton button, ToggleButton[] m_toggleButtons)
		{
			for(int i = 0; i < m_toggleButtons.Length; i++)
			{
				if(m_toggleButtons[i] == button)
				{
					m_toggleButtons[i].SetOn();
				}
				else
				{
					if(!m_toggleButtons[i].Disable && !m_toggleButtons[i].Hidden)
					{
						m_toggleButtons[i].SetOff();
					}
				}
			}
		}

		// // RVA: 0x1CCF85C Offset: 0x1CCF85C VA: 0x1CCF85C
		public void SelectGroupButton(int index)
		{
			for(int i = 0; i < m_toggleButtons.Length; i++)
			{
				if(i == index)
				{
					m_toggleButtons[i].SetOn();
				}
				else
				{
					if(!m_toggleButtons[i].Disable && !m_toggleButtons[i].Hidden)
					{
						m_toggleButtons[i].SetOff();
					}
				}
			}
		}
	}
}
