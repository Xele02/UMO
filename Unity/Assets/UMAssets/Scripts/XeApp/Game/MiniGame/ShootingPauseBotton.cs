using System;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingPauseBotton : MonoBehaviour
	{
		//[HeaderAttribute] // RVA: 0x66517C Offset: 0x66517C VA: 0x66517C
		[SerializeField]
		private ButtonBase m_button; // 0xC
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x6651C4 Offset: 0x6651C4 VA: 0x6651C4
		private InOutAnime m_inOutAnime; // 0x10

		public Action onClickButton { private get; set; } // 0x14

		// RVA: 0xC8D6E8 Offset: 0xC8D6E8 VA: 0xC8D6E8
		private void Start()
		{
			m_button.ClearOnClickCallback();
			m_button.AddOnClickCallback(() =>
			{
				//0xC8D84C
				if (onClickButton != null)
					onClickButton();
			});
		}

		//// RVA: 0xC8D7B0 Offset: 0xC8D7B0 VA: 0xC8D7B0
		public void Enter()
		{
			m_inOutAnime.Enter(false, null);
		}

		//// RVA: 0xC8D7E4 Offset: 0xC8D7E4 VA: 0xC8D7E4
		public void Leave()
		{
			m_inOutAnime.Leave(false, null);
		}

		//// RVA: 0xC8D818 Offset: 0xC8D818 VA: 0xC8D818
		//public bool IsPlayeing() { }
	}
}
