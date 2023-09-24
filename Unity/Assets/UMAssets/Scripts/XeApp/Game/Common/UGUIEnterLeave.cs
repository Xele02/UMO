using UnityEngine;

namespace XeApp.Game.Common
{
	[RequireComponent(typeof(Animator))] // RVA: 0x64F7C4 Offset: 0x64F7C4 VA: 0x64F7C4
	//[AddComponentMenu] // RVA: 0x64F7C4 Offset: 0x64F7C4 VA: 0x64F7C4
	public class UGUIEnterLeave : MonoBehaviour
	{
		[SerializeField]
		private Animator m_animatorEnterLeave; // 0xC
		private static string EnterAnimeName = "Enter"; // 0x0
		private static string LeaveAnimeName = "Leave"; // 0x4
		private bool m_isShown; // 0x10
		private bool m_isJustAnimaStart; // 0x11

		public bool IsShown { get { return m_isShown; } } //0x1CD30D4

		// // RVA: 0x1CD30DC Offset: 0x1CD30DC VA: 0x1CD30DC
		private void Awake()
		{
			Hide();
		}

		// RVA: 0x1CD31B8 Offset: 0x1CD31B8 VA: 0x1CD31B8
		private void OnEnable()
		{
			if(!m_isShown)
				Show();
			else
				Hide();
		}

		// // RVA: 0x1CD32A4 Offset: 0x1CD32A4 VA: 0x1CD32A4
		private void Update()
		{
			m_isJustAnimaStart = false;
		}

		// // RVA: 0x1CD32B0 Offset: 0x1CD32B0 VA: 0x1CD32B0
		public void Enter()
		{
			Show();
			m_isJustAnimaStart = true;
		}

		// // RVA: 0x1CD3378 Offset: 0x1CD3378 VA: 0x1CD3378
		public void Leave()
		{
			m_isShown = false;
			m_animatorEnterLeave.CrossFade(LeaveAnimeName, 0);
			m_isJustAnimaStart = true;
		}

		// // RVA: 0x1CD3440 Offset: 0x1CD3440 VA: 0x1CD3440
		public void TryEnter()
		{
			if(m_isShown)
				return;
			Enter();
		}

		// // RVA: 0x1CD3450 Offset: 0x1CD3450 VA: 0x1CD3450
		public void TryLeave()
		{
			if (m_isShown)
				Leave();
		}

		// // RVA: 0x1CD31CC Offset: 0x1CD31CC VA: 0x1CD31CC
		public void Show()
		{
			m_isShown = true;
			m_animatorEnterLeave.CrossFade(EnterAnimeName, 0, 0, 1);
		}

		// // RVA: 0x1CD30E0 Offset: 0x1CD30E0 VA: 0x1CD30E0
		public void Hide()
		{
			m_isShown = false;
			m_animatorEnterLeave.CrossFade(LeaveAnimeName, 0, 0, 1);
		}

		// // RVA: 0x1CD3460 Offset: 0x1CD3460 VA: 0x1CD3460
		public bool IsPlaying()
		{
			if(m_animatorEnterLeave != null && gameObject.activeInHierarchy && m_animatorEnterLeave.gameObject.activeSelf && m_animatorEnterLeave.enabled)
			{
				if(!m_isJustAnimaStart && !m_animatorEnterLeave.IsInTransition(0))
				{
					return m_animatorEnterLeave.GetCurrentAnimatorStateInfo(0).normalizedTime < 1;
				}
				return true;
			}
			return false;
		}
	}
}
