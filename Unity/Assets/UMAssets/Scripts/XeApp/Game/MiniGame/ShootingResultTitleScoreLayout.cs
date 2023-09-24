using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingResultTitleScoreLayout : MonoBehaviour
	{
		//[HeaderAttribute] // RVA: 0x664D40 Offset: 0x664D40 VA: 0x664D40
		[SerializeField]
		private InOutAnime m_inOutAnim; // 0xC

		// RVA: 0xC90460 Offset: 0xC90460 VA: 0xC90460
		public void Enter()
		{
			m_inOutAnim.Enter(false, null);
		}

		// RVA: 0xC90538 Offset: 0xC90538 VA: 0xC90538
		public void Leave()
		{
			m_inOutAnim.Leave(false, null);
		}
	}
}
