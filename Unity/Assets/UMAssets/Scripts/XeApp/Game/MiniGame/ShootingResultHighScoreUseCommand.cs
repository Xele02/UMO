using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingResultHighScoreUseCommand : MonoBehaviour
	{
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x664824 Offset: 0x664824 VA: 0x664824
		private InOutAnime m_inOutAnime; // 0xC

		// RVA: 0xC90150 Offset: 0xC90150 VA: 0xC90150
		public void Enter(bool isCommand)
		{
			if (!isCommand)
				return;
			m_inOutAnime.Enter(false, null);
		}

		// RVA: 0xC9018C Offset: 0xC9018C VA: 0xC9018C
		public void Leave()
		{
			m_inOutAnime.Leave(false, null);
		}
	}
}
