using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingResultScoreUseCommand : MonoBehaviour
	{
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x664C68 Offset: 0x664C68 VA: 0x664C68
		private InOutAnime m_inOutAnime; // 0xC

		// RVA: 0xC904FC Offset: 0xC904FC VA: 0xC904FC
		public void Enter(bool isCommand)
		{
			if (!isCommand)
				return;
			m_inOutAnime.Enter(false, null);
		}

		// RVA: 0xC905A0 Offset: 0xC905A0 VA: 0xC905A0
		public void Leave()
		{
			m_inOutAnime.Leave(false, null);
		}
	}
}
