using System;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class CharTouchHitCheck : MonoBehaviour
	{
		[SerializeField]
		private CharTouchButton m_button; // 0xC

		public Action OnClickCallback { get; set; } // 0x10
		public Action<CharTouchButton> OnStayCallback { get; set; } // 0x14

		//// RVA: 0x10AC64C Offset: 0x10AC64C VA: 0x10AC64C
		//private void Reset() { }

		// RVA: 0x10AC6B4 Offset: 0x10AC6B4 VA: 0x10AC6B4
		private void Start()
		{
			m_button.ClearOnClickCallback();
			m_button.AddOnClickCallback(OnClick);
			m_button.AddOnStayCallback(OnStay);
		}

		//// RVA: 0x10AC7D8 Offset: 0x10AC7D8 VA: 0x10AC7D8
		private void OnClick()
		{
			if (OnClickCallback != null)
				OnClickCallback();
		}

		//// RVA: 0x10AC7EC Offset: 0x10AC7EC VA: 0x10AC7EC
		private void OnStay()
		{
			if (OnStayCallback != null)
				OnStayCallback(m_button);
		}
	}
}
