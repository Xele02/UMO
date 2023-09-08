using System;
using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingFrameUITitleLayout : MonoBehaviour
	{
		//[HeaderAttribute] // RVA: 0x664414 Offset: 0x664414 VA: 0x664414
		[SerializeField]
		private ShootingBackBotton m_backButton; // 0xC
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x664470 Offset: 0x664470 VA: 0x664470
		private ShootingHelpBotton m_helpButton; // 0x10

		public Action onCleckSceneBackBotton { set { m_backButton.onClickButton = value; } } //0x1CEAD50
		public Action onCleckHelpBotton { set { m_helpButton.onClickButton = value; } } //0x1CEAD78

		//// RVA: 0x1CF0600 Offset: 0x1CF0600 VA: 0x1CF0600
		//public void Enter() { }

		//// RVA: 0x1CF09F4 Offset: 0x1CF09F4 VA: 0x1CF09F4
		//public void Leave() { }
	}
}
