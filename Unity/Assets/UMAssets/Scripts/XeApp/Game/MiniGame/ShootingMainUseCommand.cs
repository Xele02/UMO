using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingMainUseCommand : MonoBehaviour
	{
		//[HeaderAttribute] // RVA: 0x66474C Offset: 0x66474C VA: 0x66474C
		[SerializeField]
		private InOutAnime m_inOutAnime; // 0xC

		// RVA: 0xC8D518 Offset: 0xC8D518 VA: 0xC8D518
		public void Enter(bool isCommand)
		{
			if (!isCommand)
				return;
			m_inOutAnime.Enter(false, null);
		}

		// RVA: 0xC8D5D8 Offset: 0xC8D5D8 VA: 0xC8D5D8
		public void Leave()
		{
			m_inOutAnime.Leave(false, null);
		}
	}
}
