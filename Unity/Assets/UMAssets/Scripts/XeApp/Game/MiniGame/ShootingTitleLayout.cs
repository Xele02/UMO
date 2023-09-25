using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingTitleLayout : MonoBehaviour
	{
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x664E18 Offset: 0x664E18 VA: 0x664E18
		private ShootingTitleLogoLayout m_titleLogo; // 0xC
		//[HeaderAttribute] // RVA: 0x664E6C Offset: 0x664E6C VA: 0x664E6C
		[SerializeField]
		private ShootingTitleTouchScreenLayout m_titleTouchScreen; // 0x10
		//[HeaderAttribute] // RVA: 0x664EB4 Offset: 0x664EB4 VA: 0x664EB4
		[SerializeField]
		private ShootingTitleUseCommandLayout m_titleUseCommand; // 0x14

		// RVA: 0xC9288C Offset: 0xC9288C VA: 0xC9288C
		public void Enter()
		{
			m_titleLogo.Enter();
			m_titleTouchScreen.Enter();
			m_titleUseCommand.Leave();
		}

		// RVA: 0xC929B8 Offset: 0xC929B8 VA: 0xC929B8
		public void UseCommandEnter()
		{
			m_titleUseCommand.Enter();
		}

		//// RVA: 0xC92A14 Offset: 0xC92A14 VA: 0xC92A14
		public void Leave()
		{
			m_titleLogo.Leave();
			m_titleTouchScreen.Leave();
			m_titleUseCommand.Leave();
		}
	}
}
