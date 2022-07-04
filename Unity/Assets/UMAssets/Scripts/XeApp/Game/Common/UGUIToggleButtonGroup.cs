using UnityEngine;
using System;
using UnityEngine.Events;

namespace XeApp.Game.Common
{
	public class UGUIToggleButtonGroup : MonoBehaviour
	{
		[Serializable]
		public class SelectButtonEvent : UnityEvent<int>
		{
		}

		[SerializeField]
		private short m_gropId; // 0xC
		[SerializeField]
		private UGUIToggleButton[] m_toggleButtons; // 0x10
		[SerializeField]
		private UGUIToggleButtonGroup.SelectButtonEvent m_onSelectToggleButtonEvent; // 0x14

		// public short GropID { get; } 0x1CDCBE4
		public UGUIToggleButtonGroup.SelectButtonEvent OnSelectToggleButtonEvent { get { return m_onSelectToggleButtonEvent; } } //0x1CDCBEC

		// RVA: 0x1CDCBF4 Offset: 0x1CDCBF4 VA: 0x1CDCBF4
		private void Awake()
		{
			for(int i = 0; i < m_toggleButtons.Length; i++)
			{
				m_toggleButtons[i].AddOnClickCallback(() => {
					//0x1CDCF64
					m_onSelectToggleButtonEvent.Invoke(i);
				});
			}
		}

		// // RVA: 0x1CDC518 Offset: 0x1CDC518 VA: 0x1CDC518
		// public void SelectGroupButton(UGUIToggleButton button) { }

		// // RVA: 0x1CDCD5C Offset: 0x1CDCD5C VA: 0x1CDCD5C
		// public void SelectGroupButton(int index) { }

		// // RVA: 0x1CDCEC4 Offset: 0x1CDCEC4 VA: 0x1CDCEC4
		// public int GetSelectIndex() { }
	}
}
