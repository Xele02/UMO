using System;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingBackBotton : MonoBehaviour
	{
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x66503C Offset: 0x66503C VA: 0x66503C
		private ButtonBase m_button; // 0xC
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x665084 Offset: 0x665084 VA: 0x665084
		private InOutAnime m_inOutAnime; // 0x10

		public Action onClickButton { private get; set; } // 0x14

		// RVA: 0x1CF2CA4 Offset: 0x1CF2CA4 VA: 0x1CF2CA4
		private void Start()
		{
			m_button.ClearOnClickCallback();
			m_button.AddOnClickCallback(() =>
			{
				//0x1CF2E08
				if (onClickButton != null)
					onClickButton();
			});
		}

		//// RVA: 0x1CF2D6C Offset: 0x1CF2D6C VA: 0x1CF2D6C
		//public void Enter() { }

		//// RVA: 0x1CF2DA0 Offset: 0x1CF2DA0 VA: 0x1CF2DA0
		//public void Leave() { }

		//// RVA: 0x1CF2DD4 Offset: 0x1CF2DD4 VA: 0x1CF2DD4
		//public bool IsPlayeing() { }
	}
}
