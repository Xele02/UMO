using UnityEngine;
using System.Collections.Generic;
using System;

namespace XeApp.Game.Common
{
	public class HomeSubMenu : MonoBehaviour
	{
		//[HeaderAttribute] // RVA: 0x68ACD8 Offset: 0x68ACD8 VA: 0x68ACD8
		[SerializeField]
		private List<HomeSubMenuButton> m_buttons; // 0xC
		//[HeaderAttribute] // RVA: 0x68AD28 Offset: 0x68AD28 VA: 0x68AD28
		[SerializeField]
		private InOutAnime m_inOutAnime; // 0x10
		//[HeaderAttribute] // RVA: 0x68AD70 Offset: 0x68AD70 VA: 0x68AD70
		[SerializeField]
		private CanvasGroup m_canvasGroup; // 0x14

		public Action onClickPresentButton { set { m_buttons[0].onClickButton = value; } } //0xEB16E4
		public Action onClickNoticeButton { set { m_buttons[1].onClickButton = value; } } //0xEB1784
		public Action onClickMPassButton { set { m_buttons[2].onClickButton = value; } } //0xEB181C
		public Action onClickFriendButton { set { m_buttons[3].onClickButton = value; } } //0xEB18B4
		public Action onClickSnsButton { set { m_buttons[4].onClickButton = value; } } //0xEB194C

		//// RVA: 0xEB19E4 Offset: 0xEB19E4 VA: 0xEB19E4
		private void Start()
		{
			for(int i = 0; i < m_buttons.Count; i++)
			{
				m_buttons[i].Init();
			}
		}

		//// RVA: 0xEB1B5C Offset: 0xEB1B5C VA: 0xEB1B5C
		//public void ApplyNewIcons() { }

		//// RVA: 0xEB1F58 Offset: 0xEB1F58 VA: 0xEB1F58
		//public void UpdateMonthlyPass() { }

		//// RVA: 0xEB24C0 Offset: 0xEB24C0 VA: 0xEB24C0
		//public void SetActive(bool active) { }

		//// RVA: 0xEB2598 Offset: 0xEB2598 VA: 0xEB2598
		//public void Enter() { }

		//// RVA: 0xEB25CC Offset: 0xEB25CC VA: 0xEB25CC
		//public void Enter(float animTime) { }

		//// RVA: 0xEB2614 Offset: 0xEB2614 VA: 0xEB2614
		//public void Leave() { }

		//// RVA: 0xEB2648 Offset: 0xEB2648 VA: 0xEB2648
		//public void Leave(float animTime) { }

		//// RVA: 0xEB2690 Offset: 0xEB2690 VA: 0xEB2690
		//public bool IsPlaying() { }
	}
}
