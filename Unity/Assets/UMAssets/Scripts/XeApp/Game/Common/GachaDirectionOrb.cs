using mcrs;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class GachaDirectionOrb : MonoBehaviour
	{
		public enum ColorType
		{
			Blue = 0,
			Gold = 1,
			_Num = 2,
		}

		private static readonly int State_NormalBlue = Animator.StringToHash("bule_orb_nomal"); // 0x0
		private static readonly int State_FlashBlue = Animator.StringToHash("bule_orb"); // 0x4
		private static readonly int State_FlashGold = Animator.StringToHash("gold_orb"); // 0x8
		private static readonly int State_ReturnBlue = Animator.StringToHash("bule_orb_return"); // 0xC
		[SerializeField]
		private Animator m_animator; // 0xC
		private GachaDirectionOrb.ColorType m_type; // 0x10
		private int m_nextState; // 0x14

		// RVA: 0x1C1D938 Offset: 0x1C1D938 VA: 0x1C1D938
		private void Update()
		{
			if(m_nextState != 0)
			{
				m_animator.Play(m_nextState, 0, 0);
				m_nextState = 0;
			}
		}

		// // RVA: 0x1C1D990 Offset: 0x1C1D990 VA: 0x1C1D990
		public void Setup(GachaDirectionOrb.ColorType type, bool isRetry = false)
		{
			m_type = type;
		}

		// // RVA: 0x1C1D998 Offset: 0x1C1D998 VA: 0x1C1D998
		public void Begin(bool isRetry = false)
		{
			if(isRetry)
			{
				m_animator.SetBool("isReturn", true);
				m_nextState = GetRetryState(isRetry ? GachaDirectionOrb.ColorType.Gold : GachaDirectionOrb.ColorType.Blue);
			}
			else
			{
				m_nextState = GetNormalState(isRetry ? GachaDirectionOrb.ColorType.Gold : GachaDirectionOrb.ColorType.Blue);
			}
		}

		// // RVA: 0x1C1DB4C Offset: 0x1C1DB4C VA: 0x1C1DB4C
		public void NotifyFlash()
		{
			m_nextState = GetFlashState(0);
		}

		// // RVA: 0x1C1DBF0 Offset: 0x1C1DBF0 VA: 0x1C1DBF0
		public void NotifyChange()
		{
			if(m_type == ColorType.Gold)
			{
				SoundManager.Instance.sePlayerGacha.Play((int)cs_se_gacha.SE_GACHA_015);
			}
			m_nextState = GetChangeState(m_type);
		}

		// // RVA: 0x1C1DAC0 Offset: 0x1C1DAC0 VA: 0x1C1DAC0
		private int GetNormalState(GachaDirectionOrb.ColorType type)
		{
			return State_NormalBlue;
		}

		// // RVA: 0x1C1DB64 Offset: 0x1C1DB64 VA: 0x1C1DB64
		private int GetFlashState(GachaDirectionOrb.ColorType type)
		{
			return State_FlashBlue;
		}

		// // RVA: 0x1C1DC64 Offset: 0x1C1DC64 VA: 0x1C1DC64
		private int GetChangeState(GachaDirectionOrb.ColorType type)
		{
			if(type != ColorType.Gold)
				return 0;
			return State_FlashGold;
		}

		// // RVA: 0x1C1DA34 Offset: 0x1C1DA34 VA: 0x1C1DA34
		private int GetRetryState(GachaDirectionOrb.ColorType type)
		{
			return State_ReturnBlue;
		}
	}
}
