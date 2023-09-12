using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingMainGameOver : MonoBehaviour
	{
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x664500 Offset: 0x664500 VA: 0x664500
		private InOutAnime m_inOutAnim; // 0xC

		// RVA: 0xC8D3C8 Offset: 0xC8D3C8 VA: 0xC8D3C8
		public void Enter()
		{
			m_inOutAnim.Enter(false, null);
		}

		// RVA: 0xC8D3FC Offset: 0xC8D3FC VA: 0xC8D3FC
		public void Leave()
		{
			m_inOutAnim.Leave(false, null);
		}
	}
}
