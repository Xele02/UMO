using System;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class GakuyaHomeButton : MonoBehaviour
	{
		[SerializeField]
		private UGUIEnterLeave m_enterLeaveControl; // 0xC
		[SerializeField]
		private UGUIButton m_buttonHome; // 0x10
		public Action OnClickHomeButtonCallback; // 0x14

		// RVA: 0xB71DA4 Offset: 0xB71DA4 VA: 0xB71DA4
		private void Awake()
		{
			m_buttonHome.AddOnClickCallback(() =>
			{
				//0xB71F88
				if (OnClickHomeButtonCallback != null)
					OnClickHomeButtonCallback();
			});
		}

		//// RVA: 0xB71E4C Offset: 0xB71E4C VA: 0xB71E4C
		//public void Enter() { }

		//// RVA: 0xB71E78 Offset: 0xB71E78 VA: 0xB71E78
		//public void Leave() { }

		// RVA: 0xB71EA4 Offset: 0xB71EA4 VA: 0xB71EA4
		public void TryEnter()
		{
			m_enterLeaveControl.TryEnter();
		}

		// RVA: 0xB71ED0 Offset: 0xB71ED0 VA: 0xB71ED0
		public void TryLeave()
		{
			m_enterLeaveControl.TryLeave();
		}

		//// RVA: 0xB71EFC Offset: 0xB71EFC VA: 0xB71EFC
		//public void Show() { }

		// RVA: 0xB71F28 Offset: 0xB71F28 VA: 0xB71F28
		public void Hide()
		{
			m_enterLeaveControl.Hide();
		}

		// RVA: 0xB71F54 Offset: 0xB71F54 VA: 0xB71F54
		public bool IsPlaying()
		{
			return m_enterLeaveControl.IsPlaying();
		}
	}
}
