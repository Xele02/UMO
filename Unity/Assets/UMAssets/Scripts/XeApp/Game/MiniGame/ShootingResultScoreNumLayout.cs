using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingResultScoreNumLayout : MonoBehaviour
	{
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x664BD8 Offset: 0x664BD8 VA: 0x664BD8
		private UGUINumController m_number; // 0xC
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x664C20 Offset: 0x664C20 VA: 0x664C20
		private InOutAnime m_inOutAnim; // 0x10

		//// RVA: 0xC904C8 Offset: 0xC904C8 VA: 0xC904C8
		public void SetScore(int score)
		{
			m_number.SetNum(score);
		}

		// RVA: 0xC90494 Offset: 0xC90494 VA: 0xC90494
		public void Enter()
		{
			m_inOutAnim.Enter(false, null);
		}

		// RVA: 0xC9056C Offset: 0xC9056C VA: 0xC9056C
		public void Leave()
		{
			m_inOutAnim.Leave(false, null);
		}
	}
}
