using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingResultHighScoreNumLayout : MonoBehaviour
	{
		//[HeaderAttribute] // RVA: 0x664794 Offset: 0x664794 VA: 0x664794
		[SerializeField]
		private UGUINumController m_number; // 0xC
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x6647DC Offset: 0x6647DC VA: 0x6647DC
		private InOutAnime m_inOutAnim; // 0x10

		//// RVA: 0xC900AC Offset: 0xC900AC VA: 0xC900AC
		public void SetScore(int score)
		{
			m_number.SetNum(score);
		}

		// RVA: 0xC900E0 Offset: 0xC900E0 VA: 0xC900E0
		public void Enter()
		{
			m_inOutAnim.Enter(false, null);
		}

		// RVA: 0xC90114 Offset: 0xC90114 VA: 0xC90114
		public void Leave()
		{
			m_inOutAnim.Leave(false, null);
		}
	}
}
