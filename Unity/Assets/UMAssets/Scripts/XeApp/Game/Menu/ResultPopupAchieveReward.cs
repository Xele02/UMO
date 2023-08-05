using System;
using XeApp.Game.Common;
using XeSys;

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
		public void Setup(PopupAchieveRewardSetting setting, bool levelup)
		{
			m_setting = setting;
			m_isNotAchieve = setting == null;
			if(setting != null)
			{
				PopupAchieveRewardContent ct = null;
				if (setting.Content != null)
				{
					ct = setting.Content.GetComponent<PopupAchieveRewardContent>();
				}
				m_isNotAchieve = ct == null;
			}
			isLevelUp = levelup;
		}

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
			if(!m_isShowed)
			{
				m_isShowed = true;
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				m_setting.TitleText = bk.GetMessageByLabel("popup_music_select_02");
				m_setting.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				m_setting.WindowSize = SizeType.Large;
				PopupWindowManager.Show(m_setting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0xB4E598
					if (label != PopupButton.ButtonLabel.Ok)
						return;
					if (!m_isSkip && onFinished != null)
						onFinished();
					onFinished = null;
				}, null, null, null, false, true, false);
			}
		}
	}
}
