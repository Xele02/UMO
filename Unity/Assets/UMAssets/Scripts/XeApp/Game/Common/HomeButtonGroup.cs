using System;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class HomeButtonGroup : MonoBehaviour
	{
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x6898F4 Offset: 0x6898F4 VA: 0x6898F4
		private HomeBgChangeButton m_buttonBgChange; // 0xC
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x68993C Offset: 0x68993C VA: 0x68993C
		private HomeUIHideButton m_buttonUIHide; // 0x10
		//[HeaderAttribute] // RVA: 0x689984 Offset: 0x689984 VA: 0x689984
		[SerializeField]
		private HomeStoryButton m_buttonStory; // 0x14
		//[HeaderAttribute] // RVA: 0x6899CC Offset: 0x6899CC VA: 0x6899CC
		[SerializeField]
		private HomeGakuyaButton m_buttonGakuya; // 0x18
		//[HeaderAttribute] // RVA: 0x689A14 Offset: 0x689A14 VA: 0x689A14
		[SerializeField]
		private HomeDecoRoomButton m_buttonDecoRoom; // 0x1C
		//[HeaderAttribute] // RVA: 0x689A5C Offset: 0x689A5C VA: 0x689A5C
		[SerializeField]
		private HomeBingoButton m_buttonBingo; // 0x20
		//[HeaderAttribute] // RVA: 0x689AA4 Offset: 0x689AA4 VA: 0x689AA4
		[SerializeField]
		private CanvasGroup m_canvasGroup; // 0x24

		//public HomeUIHideButton buttonUIHide { get; } 0xEA8138
		public Action onClickBgChangeButton { set { m_buttonBgChange.onClickButton = value; } } //0xEA8140
		public Action<bool> onClickUIHideButton { set { m_buttonUIHide.onClickButton = value; } } //0xEA8168
		public Action onClickStoryButton { set { m_buttonStory.onClickButton = value; } } //0xEA8198
		public Action onClickGakuyaButton { set { m_buttonGakuya.onClickButton = value; } } //0xEA81C8
		public Action onClickDecoRoomButton { set { m_buttonDecoRoom.onClickButton = value; } } //0xEA81F8
		public Action<int> onClickBingoButton { set { m_buttonBingo.onClickButton = value; } } //0xEA8228

		//// RVA: 0xEA8250 Offset: 0xEA8250 VA: 0xEA8250
		public void Setup(long currentTime)
		{
			m_buttonUIHide.Setup();
			m_buttonStory.Setup();
			m_buttonDecoRoom.Setup();
			m_buttonBingo.Setup(currentTime);
		}

		//// RVA: 0xEA870C Offset: 0xEA870C VA: 0xEA870C
		//public void SetActive(bool active) { }

		//// RVA: 0xEA879C Offset: 0xEA879C VA: 0xEA879C
		public void Enter()
		{
			m_buttonBgChange.Enter();
			m_buttonUIHide.Enter();
			m_buttonStory.Enter();
			m_buttonGakuya.Enter();
			m_buttonDecoRoom.Enter();
			m_buttonBingo.Enter();
		}

		//// RVA: 0xEA8958 Offset: 0xEA8958 VA: 0xEA8958
		//public void Enter(float animTime) { }

		//// RVA: 0xEA8B8C Offset: 0xEA8B8C VA: 0xEA8B8C
		public void Leave()
		{
			m_buttonBgChange.Leave();
			m_buttonUIHide.Leave();
			m_buttonStory.Leave();
			m_buttonGakuya.Leave();
			m_buttonDecoRoom.Leave();
			m_buttonBingo.Leave();
		}

		//// RVA: 0xEA8D48 Offset: 0xEA8D48 VA: 0xEA8D48
		//public void Leave(float animTime) { }

		//// RVA: 0xEA8F7C Offset: 0xEA8F7C VA: 0xEA8F7C
		public bool IsPlaying()
		{
			return m_buttonBgChange.IsPlaying() || m_buttonUIHide.IsPlaying() || m_buttonStory.IsPlaying() ||
				m_buttonGakuya.IsPlaying() || m_buttonDecoRoom.IsPlaying() || m_buttonBingo.IsPlaying();
		}
	}
}
