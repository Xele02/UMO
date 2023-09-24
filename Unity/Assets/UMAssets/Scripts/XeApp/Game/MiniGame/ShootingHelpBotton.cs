using System;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingHelpBotton : MonoBehaviour
	{
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x6650DC Offset: 0x6650DC VA: 0x6650DC
		private ButtonBase m_button; // 0xC
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x665124 Offset: 0x665124 VA: 0x665124
		private InOutAnime m_inOutAnime; // 0x10

		public Action onClickButton { private get; set; } // 0x14

		// RVA: 0x1CFE860 Offset: 0x1CFE860 VA: 0x1CFE860
		private void Start()
		{
			m_button.ClearOnClickCallback();
			m_button.AddOnClickCallback(() =>
			{
				//0x1CFE95C
				if (onClickButton != null)
					onClickButton();
			});
		}

		//// RVA: 0x1CFE728 Offset: 0x1CFE728 VA: 0x1CFE728
		public void Enter()
		{
			m_inOutAnime.Enter(false, null);
		}

		//// RVA: 0x1CFE75C Offset: 0x1CFE75C VA: 0x1CFE75C
		public void Leave()
		{
			m_inOutAnime.Leave(false, null);
		}

		//// RVA: 0x1CFE928 Offset: 0x1CFE928 VA: 0x1CFE928
		//public bool IsPlayeing() { }
	}
}
