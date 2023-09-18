using System;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class GakuyaViewModeButton : MonoBehaviour
	{
		[SerializeField]
		private UGUIEnterLeave m_enterLeaveControl; // 0xC
		[SerializeField]
		private UGUIButton m_buttonView; // 0x10
		public Action OnClickViewButtonCallback; // 0x14

		// RVA: 0xB840C8 Offset: 0xB840C8 VA: 0xB840C8
		private void Awake()
		{
			m_buttonView.AddOnClickCallback(() =>
			{
				//0xB841FC
				if (OnClickViewButtonCallback != null)
					OnClickViewButtonCallback();
			});
		}

		//// RVA: 0xB84170 Offset: 0xB84170 VA: 0xB84170
		//public void Enter() { }

		//// RVA: 0xB8419C Offset: 0xB8419C VA: 0xB8419C
		//public void Leave() { }

		// RVA: 0xB811F8 Offset: 0xB811F8 VA: 0xB811F8
		public void TryEnter()
		{
			m_enterLeaveControl.TryEnter();
		}

		// RVA: 0xB76544 Offset: 0xB76544 VA: 0xB76544
		public void TryLeave()
		{
			m_enterLeaveControl.TryLeave();
		}

		// RVA: 0xB841C8 Offset: 0xB841C8 VA: 0xB841C8
		public void Show()
		{
			m_enterLeaveControl.Show();
		}

		// RVA: 0xB81E60 Offset: 0xB81E60 VA: 0xB81E60
		public void Hide()
		{
			m_enterLeaveControl.Hide();
		}

		// RVA: 0xB76134 Offset: 0xB76134 VA: 0xB76134
		public bool IsPlaying()
		{
			return m_enterLeaveControl.IsPlaying();
		}
	}
}
