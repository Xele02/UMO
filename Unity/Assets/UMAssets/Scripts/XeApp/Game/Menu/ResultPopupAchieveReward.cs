using System;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class ResultPopupAchieveReward
	{
		private bool m_isShowed; // 0xD
		private bool m_isSkip; // 0xE
		private bool m_isNotAchieve; // 0xF
		private PopupAchieveRewardSetting m_setting; // 0x10

		public Action onFinished { get; set; } // 0x8
		public bool isLevelUp { get; set; } // 0xC

		// RVA: 0xB4E08C Offset: 0xB4E08C VA: 0xB4E08C
		public ResultPopupAchieveReward()
		{
			return;
		}

		// // RVA: 0xB4E094 Offset: 0xB4E094 VA: 0xB4E094
		// public void Setup(PopupAchieveRewardSetting setting, bool levelup) { }

		// // RVA: 0xB4E1E8 Offset: 0xB4E1E8 VA: 0xB4E1E8
		// public bool IsShowed() { }

		// // RVA: 0xB4E1F0 Offset: 0xB4E1F0 VA: 0xB4E1F0
		public bool IsClosed()
		{
			return !PopupWindowManager.IsActivePopupWindow();
		}

		// // RVA: 0xB4E270 Offset: 0xB4E270 VA: 0xB4E270
		public void Show()
		{
			if(!m_isSkip && m_isNotAchieve)
			{
				if(onFinished != null)
					onFinished();
				return;
			}
			else if(m_isNotAchieve)
				return;
			ShowInner();
		}

		// // RVA: 0xB4E560 Offset: 0xB4E560 VA: 0xB4E560
		// public void Skip() { }

		// // RVA: 0xB4E2C8 Offset: 0xB4E2C8 VA: 0xB4E2C8
		private void ShowInner()
		{
			TodoLogger.Log(0, "ShowInner");
			if(onFinished != null)
				onFinished();
		}

		// [CompilerGeneratedAttribute] // RVA: 0x7227AC Offset: 0x7227AC VA: 0x7227AC
		// // RVA: 0xB4E598 Offset: 0xB4E598 VA: 0xB4E598
		// private void <ShowInner>b__18_0(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }
	}
}
