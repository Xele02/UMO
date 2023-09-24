using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingResultTitleLayout : MonoBehaviour
	{
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x664CF8 Offset: 0x664CF8 VA: 0x664CF8
		private InOutAnime m_inOutAnim; // 0xC

		// RVA: 0xC90368 Offset: 0xC90368 VA: 0xC90368
		public void Enter()
		{
			m_inOutAnim.Enter(false, null);
		}

		// RVA: 0xC9039C Offset: 0xC9039C VA: 0xC9039C
		public void Leave()
		{
			m_inOutAnim.Leave(false, null);
		}
	}
}
