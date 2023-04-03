using System;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class HomeBgChangeButton : MonoBehaviour
	{
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x6896D0 Offset: 0x6896D0 VA: 0x6896D0
		private ButtonBase m_button; // 0xC
		//[HeaderAttribute] // RVA: 0x689718 Offset: 0x689718 VA: 0x689718
		[SerializeField]
		private GameObject m_iconNew; // 0x10
		//[HeaderAttribute] // RVA: 0x689760 Offset: 0x689760 VA: 0x689760
		[SerializeField]
		private InOutAnime m_inOutAnime; // 0x14

		public Action onClickButton { private get; set; } // 0x18

		// RVA: 0xEA7AA0 Offset: 0xEA7AA0 VA: 0xEA7AA0
		private void Start()
		{
			m_button.ClearOnClickCallback();
			m_button.AddOnClickCallback(() =>
			{
				//0xEA7C98
				if (onClickButton != null)
					onClickButton();
			});
		}

		//// RVA: 0xEA7B68 Offset: 0xEA7B68 VA: 0xEA7B68
		//public void Setup() { }

		//// RVA: 0xEA7B6C Offset: 0xEA7B6C VA: 0xEA7B6C
		public void Enter()
		{
			m_inOutAnime.Enter(false, null);
		}

		//// RVA: 0xEA7BA0 Offset: 0xEA7BA0 VA: 0xEA7BA0
		//public void Enter(float animTime) { }

		//// RVA: 0xEA7BE8 Offset: 0xEA7BE8 VA: 0xEA7BE8
		//public void Leave() { }

		//// RVA: 0xEA7C1C Offset: 0xEA7C1C VA: 0xEA7C1C
		//public void Leave(float animTime) { }

		//// RVA: 0xEA7C64 Offset: 0xEA7C64 VA: 0xEA7C64
		public bool IsPlaying()
		{
			return m_inOutAnime.IsPlaying();
		}
	}
}
