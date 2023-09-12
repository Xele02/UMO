using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingTitleUseCommandLayout : MonoBehaviour
	{
		//[HeaderAttribute] // RVA: 0x664FD4 Offset: 0x664FD4 VA: 0x664FD4
		[SerializeField]
		private InOutAnime m_inOutAnim; // 0xC

		// RVA: 0xC929E0 Offset: 0xC929E0 VA: 0xC929E0
		public void Enter()
		{
			m_inOutAnim.Enter(false);
		}

		// RVA: 0xC92984 Offset: 0xC92984 VA: 0xC92984
		public void Leave()
		{
			m_inOutAnim.Leave(false);
		}
	}
}
