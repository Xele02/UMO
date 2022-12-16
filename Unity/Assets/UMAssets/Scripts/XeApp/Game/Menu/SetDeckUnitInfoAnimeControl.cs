using UnityEngine;

namespace XeApp.Game.Menu
{
	public class SetDeckUnitInfoAnimeControl : MonoBehaviour
	{
		public enum DispType
		{
			Skill = 0,
			Divas = 1,
			Num = 2,
		}

		private static readonly string[] EnterAnimeStateNames = new string[2] { "Enter_Skill", "Enter_Normal" }; // 0x0
		private static readonly string[] LeaveAnimeStateNames = new string[2] { "Leave_Skill", "Leave_Normal" }; // 0x4
		private static readonly string[][] ChangeAnimeStateNames = new string[2][] { new string[2] { "", "Skill_to_Normal" }, new string[2] { "Normal_to_Skill", "" } }; // 0x8
		//[TooltipAttribute] // RVA: 0x6843B8 Offset: 0x6843B8 VA: 0x6843B8
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x6843B8 Offset: 0x6843B8 VA: 0x6843B8
		private Animator m_animator; // 0xC
		//[HeaderAttribute] // RVA: 0x684448 Offset: 0x684448 VA: 0x684448
		private bool m_isShown; // 0x10
		private bool m_isJustAnimeStart; // 0x11
		private DispType m_currentDispType = DispType.Divas; // 0x14

		//public DispType CurrentDispType { get; } 0xC34CF8
		//public bool IsShown { get; } 0xC34D00

		// RVA: 0xC34D08 Offset: 0xC34D08 VA: 0xC34D08
		private void Update()
		{
			m_isJustAnimeStart = false;
		}

		//// RVA: 0xC34D14 Offset: 0xC34D14 VA: 0xC34D14
		public void Enter(DispType dispType)
		{
			m_animator.CrossFade(GetEnterAnimeStateName(dispType), 0);
			m_currentDispType = dispType;
			m_isShown = true;
			m_isJustAnimeStart = true;
		}

		//// RVA: 0xC34E28 Offset: 0xC34E28 VA: 0xC34E28
		public void Enter()
		{
			Enter(m_currentDispType);
		}

		//// RVA: 0xC34E30 Offset: 0xC34E30 VA: 0xC34E30
		public void TryEnter(DispType dispType)
		{
			if (m_isShown)
				return;
			Enter(dispType);
		}

		//// RVA: 0xC34E40 Offset: 0xC34E40 VA: 0xC34E40
		public void TryEnter()
		{
			if (m_isShown)
				return;
			Enter(m_currentDispType);
		}

		//// RVA: 0xC34E54 Offset: 0xC34E54 VA: 0xC34E54
		public void Leave()
		{
			m_animator.CrossFade(GetLeaveAnimeStateName(m_currentDispType), 0);
			m_isShown = false;
			m_isJustAnimeStart = false;
		}

		//// RVA: 0xC34F64 Offset: 0xC34F64 VA: 0xC34F64
		public void TryLeave()
		{
			if (!m_isShown)
				return;
			Leave();
		}

		//// RVA: 0xC34F74 Offset: 0xC34F74 VA: 0xC34F74
		//public void Show(SetDeckUnitInfoAnimeControl.DispType dispType) { }

		//// RVA: 0xC34FDC Offset: 0xC34FDC VA: 0xC34FDC
		//public void Show() { }

		//// RVA: 0xC34FE4 Offset: 0xC34FE4 VA: 0xC34FE4
		public void Hide()
		{
			m_animator.CrossFade(GetLeaveAnimeStateName(m_currentDispType), 0, 0, 1);
			m_isShown = false;
		}

		//// RVA: 0xC35040 Offset: 0xC35040 VA: 0xC35040
		public bool IsPlaying()
		{
			if(m_animator != null)
			{
				if(m_animator.gameObject.activeInHierarchy)
				{
					if(m_animator.gameObject.activeSelf)
					{
						if(m_animator.enabled)
						{
							if(!m_isJustAnimeStart)
							{
								if(!m_animator.IsInTransition(0))
								{
									if(m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
									{
										return false;
									}
								}
							}
							return true;
						}
					}
				}
			}
			return false;
		}

		//// RVA: 0xC3524C Offset: 0xC3524C VA: 0xC3524C
		public void ChangeDispType(DispType dispType)
		{
			string name = GetChangeAnimeStateName(m_currentDispType, dispType);
			if (name.Length < 1)
				return;
			m_animator.CrossFade(name, 0);
			m_currentDispType = dispType;
			m_isShown = true;
			m_isJustAnimeStart = true;
		}

		//// RVA: 0xC353C4 Offset: 0xC353C4 VA: 0xC353C4
		//public void QuickChangeDispType(SetDeckUnitInfoAnimeControl.DispType dispType) { }

		//// RVA: 0xC34D64 Offset: 0xC34D64 VA: 0xC34D64
		private string GetEnterAnimeStateName(DispType dispType)
		{
			return EnterAnimeStateNames[(int)dispType];
		}

		//// RVA: 0xC34EA0 Offset: 0xC34EA0 VA: 0xC34EA0
		private string GetLeaveAnimeStateName(DispType dispType)
		{
			return LeaveAnimeStateNames[(int)dispType];
		}

		//// RVA: 0xC352C8 Offset: 0xC352C8 VA: 0xC352C8
		private string GetChangeAnimeStateName(DispType prevDispType, DispType nextDispType)
		{
			return ChangeAnimeStateNames[(int)prevDispType][(int)nextDispType];
		}
	}
}
