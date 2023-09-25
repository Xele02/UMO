using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingTitleLogoLayout : MonoBehaviour
	{
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x664EFC Offset: 0x664EFC VA: 0x664EFC
		private InOutAnime m_inOutAnim; // 0xC

		// RVA: 0xC928F0 Offset: 0xC928F0 VA: 0xC928F0
		public void Enter()
		{
			m_inOutAnim.Enter(false, null);
		}

		//// RVA: 0xC92A78 Offset: 0xC92A78 VA: 0xC92A78
		public void Leave()
		{
			m_inOutAnim.Leave(false, null);
		}
	}
}
