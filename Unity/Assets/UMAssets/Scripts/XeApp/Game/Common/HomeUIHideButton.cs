using System;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class HomeUIHideButton : MonoBehaviour
	{
		//[HeaderAttribute] // RVA: 0x68AF50 Offset: 0x68AF50 VA: 0x68AF50
		[SerializeField]
		private ButtonBase m_buttonHide; // 0xC
		//[HeaderAttribute] // RVA: 0x68AF98 Offset: 0x68AF98 VA: 0x68AF98
		[SerializeField]
		private ButtonBase m_buttonShow; // 0x10
		//[HeaderAttribute] // RVA: 0x68AFEC Offset: 0x68AFEC VA: 0x68AFEC
		[SerializeField]
		private InOutAnime m_inOutAnime; // 0x14
		private bool m_hidden; // 0x18

		public Action<bool> onClickButton { private get; set; } // 0x1C
		//public bool IsInputLock { set; } 0xEB2C10

		// RVA: 0xEB2ACC Offset: 0xEB2ACC VA: 0xEB2ACC
		private void Start()
		{
			m_buttonHide.ClearOnClickCallback();
			m_buttonHide.AddOnClickCallback(() =>
			{
				//0xEB2C74
				m_hidden = true;
				if (onClickButton != null)
					onClickButton(true);
				m_buttonShow.gameObject.SetActive(true);
			});
			m_buttonShow.ClearOnClickCallback();
			m_buttonShow.AddOnClickCallback(() =>
			{
				//0xEB2D30
				m_hidden = false;
				if (onClickButton != null)
					onClickButton(false);
				m_buttonShow.gameObject.SetActive(false);
			});
		}

		//// RVA: 0xEA8310 Offset: 0xEA8310 VA: 0xEA8310
		//public void Setup() { }

		//// RVA: 0xEA8854 Offset: 0xEA8854 VA: 0xEA8854
		//public void Enter() { }

		//// RVA: 0xEA8A2C Offset: 0xEA8A2C VA: 0xEA8A2C
		//public void Enter(float animTime) { }

		//// RVA: 0xEA8C44 Offset: 0xEA8C44 VA: 0xEA8C44
		//public void Leave() { }

		//// RVA: 0xEA8E1C Offset: 0xEA8E1C VA: 0xEA8E1C
		//public void Leave(float animTime) { }

		//// RVA: 0xEA905C Offset: 0xEA905C VA: 0xEA905C
		//public bool IsPlaying() { }
	}
}
