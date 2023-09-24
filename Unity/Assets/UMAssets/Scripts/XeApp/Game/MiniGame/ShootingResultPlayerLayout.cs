using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingResultPlayerLayout : MonoBehaviour
	{
		//[HeaderAttribute] // RVA: 0x664B90 Offset: 0x664B90 VA: 0x664B90
		[SerializeField]
		private InOutAnime m_inOutAnim; // 0xC

		// RVA: 0xC907D8 Offset: 0xC907D8 VA: 0xC907D8
		public void Enter()
		{
			m_inOutAnim.Enter(false, null);
		}

		// RVA: 0xC9080C Offset: 0xC9080C VA: 0xC9080C
		public void Leave()
		{
			m_inOutAnim.Leave(false, null);
		}
	}
}
