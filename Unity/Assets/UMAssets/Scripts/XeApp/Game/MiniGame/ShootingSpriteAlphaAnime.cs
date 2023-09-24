using System;
using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingSpriteAlphaAnime : MonoBehaviour
	{
		public enum StartType
		{
			Show = 0,
			Hide = 1,
		}

		//[HeaderAttribute] // RVA: 0x6652B4 Offset: 0x6652B4 VA: 0x6652B4
		[SerializeField]
		protected StartType m_startAlpha; // 0xC
		//[HeaderAttribute] // RVA: 0x665308 Offset: 0x665308 VA: 0x665308
		[SerializeField]
		private SpriteRenderer[] m_spriteRenderer; // 0x10
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x665358 Offset: 0x665358 VA: 0x665358
		private float m_animTimMax = 0.3f; // 0x14
		private float m_animTime; // 0x18
		//[HeaderAttribute] // RVA: 0x6653B4 Offset: 0x6653B4 VA: 0x6653B4
		[SerializeField]
		private float m_blinkingTimeMax = 0.15f; // 0x1C
		private float m_blinkingTime; // 0x20
		private bool m_isPlay; // 0x24

		// RVA: 0xC917DC Offset: 0xC917DC VA: 0xC917DC
		private void Start()
		{
			SetEnable(m_startAlpha == 0);
		}

		//// RVA: 0xC91804 Offset: 0xC91804 VA: 0xC91804
		private void SetEnable(bool enable)
		{
			for(int i = 0; i < m_spriteRenderer.Length; i++)
			{
				m_spriteRenderer[i].enabled = enable;
			}
		}

		//// RVA: 0xC9189C Offset: 0xC9189C VA: 0xC9189C
		protected void Blinking()
		{
			for(int i = 0; i < m_spriteRenderer.Length; i++)
			{
				m_spriteRenderer[i].enabled = !m_spriteRenderer[i].enabled;
			}
		}

		//// RVA: 0xC917F0 Offset: 0xC917F0 VA: 0xC917F0
		//protected void ResetAlpha() { }

		//// RVA: 0xC91984 Offset: 0xC91984 VA: 0xC91984
		public void Stop()
		{
			m_isPlay = false;
			SetEnable(m_startAlpha == 0);
		}

		//// RVA: 0xC9199C Offset: 0xC9199C VA: 0xC9199C
		public void Play()
		{
			m_animTime = 0;
			if(!m_isPlay)
			{
				m_blinkingTime = 0;
				Blinking();
			}
			m_isPlay = true;
		}

		// RVA: 0xC919D4 Offset: 0xC919D4 VA: 0xC919D4
		public void OnUpdate(float elapsedTime, Action finishCallBack)
		{
			if(m_isPlay)
			{
				m_animTime += elapsedTime;
				if(m_animTimMax <= m_animTime)
				{
					m_isPlay = false;
					m_animTime = 0;
					SetEnable(m_startAlpha == 0);
					if (finishCallBack != null)
						finishCallBack();
				}
				else
				{
					m_blinkingTime += elapsedTime;
					if (m_blinkingTime < m_blinkingTimeMax)
						return;
					Blinking();
					m_blinkingTime = 0;
				}
			}
		}
	}
}
