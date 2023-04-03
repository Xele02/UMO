using System;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class HomeGakuyaButton : MonoBehaviour
	{
		//[HeaderAttribute] // RVA: 0x68A364 Offset: 0x68A364 VA: 0x68A364
		[SerializeField]
		private ButtonBase m_button; // 0xC
		//[HeaderAttribute] // RVA: 0x68A3AC Offset: 0x68A3AC VA: 0x68A3AC
		[SerializeField]
		private InOutAnime m_inOutAnime; // 0x10

		public Action onClickButton { private get; set; } // 0x14

		// RVA: 0xEACF80 Offset: 0xEACF80 VA: 0xEACF80
		private void Start()
		{
			m_button.ClearOnClickCallback();
			m_button.AddOnClickCallback(() =>
			{
				//0xEAD050
				if (onClickButton != null)
					onClickButton();
			});
		}

		//// RVA: 0xEA85BC Offset: 0xEA85BC VA: 0xEA85BC
		//public void Setup() { }

		//// RVA: 0xEA88F0 Offset: 0xEA88F0 VA: 0xEA88F0
		public void Enter()
		{
			m_inOutAnime.Enter(false, null);
		}

		//// RVA: 0xEA8AFC Offset: 0xEA8AFC VA: 0xEA8AFC
		//public void Enter(float animTime) { }

		//// RVA: 0xEA8CE0 Offset: 0xEA8CE0 VA: 0xEA8CE0
		//public void Leave() { }

		//// RVA: 0xEA8EEC Offset: 0xEA8EEC VA: 0xEA8EEC
		//public void Leave(float animTime) { }

		//// RVA: 0xEA90B4 Offset: 0xEA90B4 VA: 0xEA90B4
		public bool IsPlaying()
		{
			return m_inOutAnime.IsPlaying();
		}
	}
}
