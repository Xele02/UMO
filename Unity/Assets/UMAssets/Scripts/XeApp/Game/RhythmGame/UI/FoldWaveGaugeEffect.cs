using UnityEngine;

namespace XeApp.Game.RhythmGame.UI
{
	public class FoldWaveGaugeEffect : MonoBehaviour
	{
		[SerializeField]
		private GameObject m_markEffect; // 0xC
		[SerializeField]
		private GameObject m_markEffectParticle; // 0x10
		[SerializeField]
		private GameObject[] m_gaugeParticles; // 0x14
		private Animator m_animator; // 0x18
		private static readonly int GalugeFlashStageHash = Animator.StringToHash("gage_flash"); // 0x0
		private const float MinMarkPosition = -310;
		private const float GaugeWidth = 268;

		// // RVA: 0x155F3A8 Offset: 0x155F3A8 VA: 0x155F3A8
		public void Initialize()
		{
			m_animator = GetComponent<Animator>();
			m_animator.Play(GalugeFlashStageHash, 3, 1);
		}

		// // RVA: 0x1560130 Offset: 0x1560130 VA: 0x1560130
		public void ShowHighlight(bool isLowSpec)
		{
			m_animator.Play(GalugeFlashStageHash, 3, 0);
		}

		// // RVA: 0x155FAA8 Offset: 0x155FAA8 VA: 0x155FAA8
		public void SetMarkPosition(float position)
		{
			Vector3 p = m_markEffect.transform.localPosition;
			Vector3 s = m_markEffect.transform.localScale;
			float f = Mathf.Clamp01(position / 0.16f);
			float f2 = Mathf.Clamp01(position / 0.06f);
			m_markEffect.transform.localPosition = new Vector3(position * 268 + 310, p.y, p.z);
			m_markEffect.SetActive(position < 1);
			m_markEffect.transform.localScale = new Vector3(f, f2 * 0.4f + 0.6f, s.z);
		}

		// // RVA: 0x155FD28 Offset: 0x155FD28 VA: 0x155FD28
		public void UpdateGaugeEffectScale(float rate)
		{
			float f = Mathf.Clamp01(rate + rate);
			float f2 = Mathf.Clamp01(rate - 0.5f + rate - 0.5f);
			if(m_gaugeParticles[0] != null)
			{
				m_gaugeParticles[0].transform.localScale = new Vector3(f, m_gaugeParticles[0].transform.localScale.y, m_gaugeParticles[0].transform.localScale.z);
			}
			if(m_gaugeParticles[1] != null)
			{
				m_gaugeParticles[1].transform.localScale = new Vector3(f2, m_gaugeParticles[1].transform.localScale.y, m_gaugeParticles[1].transform.localScale.z);
			}
		}
	}
}
