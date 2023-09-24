using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingMainScore : MonoBehaviour
	{
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x6646BC Offset: 0x6646BC VA: 0x6646BC
		private UGUINumController m_number; // 0xC
		//[HeaderAttribute] // RVA: 0x664704 Offset: 0x664704 VA: 0x664704
		[SerializeField]
		private InOutAnime m_inOutCount; // 0x10

		// RVA: 0xC8D63C Offset: 0xC8D63C VA: 0xC8D63C
		public void SetNum(int score)
		{
			m_number.SetNum(score);
		}

		// RVA: 0xC8D4E4 Offset: 0xC8D4E4 VA: 0xC8D4E4
		public void Enter()
		{
			m_inOutCount.Enter(false, null);
		}

		// RVA: 0xC8D554 Offset: 0xC8D554 VA: 0xC8D554
		public void Leave()
		{
			m_inOutCount.Leave(false, null);
		}
	}
}
