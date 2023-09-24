using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingMainGameClear : MonoBehaviour
	{
		//[HeaderAttribute] // RVA: 0x6644B8 Offset: 0x6644B8 VA: 0x6644B8
		[SerializeField]
		private InOutAnime m_inOutAnim; // 0xC

		// RVA: 0xC8D358 Offset: 0xC8D358 VA: 0xC8D358
		public void Enter()
		{
			m_inOutAnim.Enter(false, null);
		}

		// RVA: 0xC8D38C Offset: 0xC8D38C VA: 0xC8D38C
		public void Leave()
		{
			m_inOutAnim.Leave(false, null);
		}
	}
}
