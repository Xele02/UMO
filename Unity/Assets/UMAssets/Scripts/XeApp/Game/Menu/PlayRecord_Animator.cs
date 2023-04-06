using UnityEngine;

namespace XeApp.Game.Menu
{
	public class PlayRecord_Animator
	{
		private static readonly int HASH_ENTER_FIRST = Animator.StringToHash("Enter_First"); // 0x0
		private static readonly int HASH_ENTER = Animator.StringToHash("Enter"); // 0x4
		private static readonly int HASH_LEAVE = Animator.StringToHash("Leave"); // 0x8
		private Animator m_animator; // 0x8

		// RVA: 0xDE67E8 Offset: 0xDE67E8 VA: 0xDE67E8
		public PlayRecord_Animator(Animator a_animator)
		{
			m_animator = a_animator;
		}

		//// RVA: 0xDE6808 Offset: 0xDE6808 VA: 0xDE6808
		public void EnterFirst()
		{
			m_animator.CrossFadeInFixedTime(HASH_ENTER_FIRST, 0.5f);
		}

		//// RVA: 0xDE68C0 Offset: 0xDE68C0 VA: 0xDE68C0
		public void Enter()
		{
			m_animator.CrossFadeInFixedTime(HASH_ENTER, 0.5f);
		}

		//// RVA: 0xDE6978 Offset: 0xDE6978 VA: 0xDE6978
		public void Leave()
		{
			m_animator.CrossFadeInFixedTime(HASH_LEAVE, 0.5f);
		}

		//// RVA: 0xDE6A30 Offset: 0xDE6A30 VA: 0xDE6A30
		public bool IsPlaying()
		{
			return m_animator != null && m_animator.gameObject.activeSelf && m_animator.enabled && (m_animator.IsInTransition(0) || m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1);
		}
	}
}
