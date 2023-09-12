using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingResultTouchScreenLayout : MonoBehaviour
	{
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x664D88 Offset: 0x664D88 VA: 0x664D88
		private InOutAnime m_inOutAnim; // 0xC
		//[HeaderAttribute] // RVA: 0x664DD0 Offset: 0x664DD0 VA: 0x664DD0
		[SerializeField]
		private SpriteAnime m_spriteAnime; // 0x10

		// RVA: 0xC906F4 Offset: 0xC906F4 VA: 0xC906F4
		public void Enter()
		{
			m_inOutAnim.Enter(false, null);
			m_spriteAnime.Play(0, null);
		}

		// RVA: 0xC90754 Offset: 0xC90754 VA: 0xC90754
		public void Leave()
		{
			m_inOutAnim.Leave(false, null);
			m_spriteAnime.SetKeyFrame(0);
		}
	}
}
