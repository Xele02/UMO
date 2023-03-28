using System;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class HomeBingoButton : MonoBehaviour
	{
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x6897B8 Offset: 0x6897B8 VA: 0x6897B8
		private ButtonBase m_button; // 0xC
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x689800 Offset: 0x689800 VA: 0x689800
		private GameObject m_iconNew; // 0x10
		//[HeaderAttribute] // RVA: 0x689848 Offset: 0x689848 VA: 0x689848
		[SerializeField]
		private GameObject m_iconBegginer; // 0x14
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x68989C Offset: 0x68989C VA: 0x68989C
		private InOutAnime m_inOutAnime; // 0x18
		private int m_bingoId; // 0x1C

		public Action<int> onClickButton { private get; set; } // 0x20

		// RVA: 0xEA7CBC Offset: 0xEA7CBC VA: 0xEA7CBC
		private void Start()
		{
			m_button.ClearOnClickCallback();
			m_button.AddOnClickCallback(() =>
			{
				//0xEA80C8
				if (onClickButton != null)
					onClickButton(m_bingoId);
			});
		}

		//// RVA: 0xEA7D84 Offset: 0xEA7D84 VA: 0xEA7D84
		//public void Setup(long currentTime) { }

		//// RVA: 0xEA7F9C Offset: 0xEA7F9C VA: 0xEA7F9C
		//public void Enter() { }

		//// RVA: 0xEA7FD0 Offset: 0xEA7FD0 VA: 0xEA7FD0
		//public void Enter(float animTime) { }

		//// RVA: 0xEA8018 Offset: 0xEA8018 VA: 0xEA8018
		//public void Leave() { }

		//// RVA: 0xEA804C Offset: 0xEA804C VA: 0xEA804C
		//public void Leave(float animTime) { }

		//// RVA: 0xEA8094 Offset: 0xEA8094 VA: 0xEA8094
		//public bool IsPlaying() { }
	}
}
