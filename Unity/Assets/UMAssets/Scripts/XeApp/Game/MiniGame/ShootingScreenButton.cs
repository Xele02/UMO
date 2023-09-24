using System;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingScreenButton : MonoBehaviour
	{
		//[HeaderAttribute] // RVA: 0x66521C Offset: 0x66521C VA: 0x66521C
		[SerializeField]
		private ButtonBase m_changeSceneButton; // 0xC

		public Action onClickChangeSceneButton { private get; set; } // 0x10

		// RVA: 0xC90978 Offset: 0xC90978 VA: 0xC90978
		private void Start()
		{
			m_changeSceneButton.ClearOnClickCallback();
			m_changeSceneButton.AddOnClickCallback(() =>
			{
				//0xC90A48
				if (onClickChangeSceneButton != null)
					onClickChangeSceneButton();
			});
		}
	}
}
