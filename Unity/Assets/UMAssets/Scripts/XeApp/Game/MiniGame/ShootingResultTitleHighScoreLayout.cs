using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingResultTitleHighScoreLayout : MonoBehaviour
	{
		//[HeaderAttribute] // RVA: 0x664CB0 Offset: 0x664CB0 VA: 0x664CB0
		[SerializeField]
		private InOutAnime m_inOutAnim; // 0xC

		// RVA: 0xC90664 Offset: 0xC90664 VA: 0xC90664
		public void Enter()
		{
			m_inOutAnim.Enter(false, null);
		}

		// RVA: 0xC90698 Offset: 0xC90698 VA: 0xC90698
		public void Leave()
		{
			m_inOutAnim.Leave(false, null);
		}
	}
}
