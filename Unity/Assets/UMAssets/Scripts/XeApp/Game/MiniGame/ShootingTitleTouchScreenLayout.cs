using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingTitleTouchScreenLayout : MonoBehaviour
	{
		//[HeaderAttribute] // RVA: 0x664F44 Offset: 0x664F44 VA: 0x664F44
		[SerializeField]
		private InOutAnime m_inOutAnim; // 0xC
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x664F8C Offset: 0x664F8C VA: 0x664F8C
		private SpriteAnime m_spriteAnime; // 0x10

		// RVA: 0xC92924 Offset: 0xC92924 VA: 0xC92924
		public void Enter()
		{
			m_inOutAnim.Enter(false, null);
			m_spriteAnime.Play(0, null);
		}

		//// RVA: 0xC92AAC Offset: 0xC92AAC VA: 0xC92AAC
		public void Leave()
		{
			m_inOutAnim.Leave(false, null);
			m_spriteAnime.SetKeyFrame(0);
		}
	}
}
