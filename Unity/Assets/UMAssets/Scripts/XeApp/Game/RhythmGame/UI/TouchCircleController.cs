using UnityEngine;

namespace XeApp.Game.RhythmGame.UI
{
	public class TouchCircleController : MonoBehaviour
	{
		[SerializeField]
		private Animator m_touchCircleAnimator; // 0xC

		// // RVA: 0x1561CEC Offset: 0x1561CEC VA: 0x1561CEC
		public void SetAnimator(Animator anim)
		{
			m_touchCircleAnimator = anim;
		}

		// // RVA: 0x1564404 Offset: 0x1564404 VA: 0x1564404
		// public void Play(int stateHash, float normalizedTime) { }
	}
}
