using System;
using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingFrameUIMainLayout : MonoBehaviour
	{
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x6643CC Offset: 0x6643CC VA: 0x6643CC
		private ShootingPauseBotton m_pauseButton; // 0xC

		public Action onCleckPauseBotton { set { m_pauseButton.onClickButton = value; } } //0x1CEADA0

		//// RVA: 0x1CEEDE4 Offset: 0x1CEEDE4 VA: 0x1CEEDE4
		public void Enter()
		{
			m_pauseButton.Enter();
		}

		//// RVA: 0x1CEF148 Offset: 0x1CEF148 VA: 0x1CEF148
		public void Leave()
		{
			m_pauseButton.Leave();
		}
	}
}
