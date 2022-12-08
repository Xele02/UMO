using System;
using UnityEngine;

namespace XeApp.Game.Common
{
	[Serializable]
	public class UGUICurveMover
	{
		[Serializable]
		public struct CurveInfo
		{
			//[TooltipAttribute] // RVA: 0x68C5D8 Offset: 0x68C5D8 VA: 0x68C5D8
			public AnimationCurve m_curve; // 0x0
			//[TooltipAttribute] // RVA: 0x68C614 Offset: 0x68C614 VA: 0x68C614
			public float m_animTime; // 0x4
		}
		
		private enum State
		{
			Stop = 0,
			Play = 1,
			Pause = 2,
		}

		private CurveInfo m_curveInfo; // 0x8
		private State m_state; // 0x10
		private bool m_isReverse; // 0x14
		private bool m_isLoop; // 0x15
		private float m_currentTime; // 0x18
		private float m_currentNormalizeTime; // 0x1C
		public Action OnCurveEndCallback; // 0x20

		//public float CurrentTime { get; } 0x1CD2E48
		//public float CurrentNormalizeTime { get; } 0x1CD2E80
		public float CurrentValue { get { return m_curveInfo.m_curve.Evaluate(!m_isReverse ? m_currentNormalizeTime : 1 - m_currentNormalizeTime); } }  //0x1CD2EA0
		//public float AnimeLength { get; } 0x1CD2E78
		public bool IsPlaying { get { return m_state != State.Stop; } } //0x1CD2EF0
		//public bool Pause { get; set; } 0x1CD2F00  0x1CD2F14
		//public bool IsPause { get; } 0x1CD2F38
		//public bool IsLoop { get; }  0x1CD2F4C
		//public bool IsReverse { get; } 0x1CD2E70

		//// RVA: 0x1CD2D90 Offset: 0x1CD2D90 VA: 0x1CD2D90
		public void Setup(ref CurveInfo info)
		{
			m_curveInfo.m_curve = info.m_curve;
			m_curveInfo.m_animTime = info.m_animTime;
		}

		//// RVA: 0x1CD2DA4 Offset: 0x1CD2DA4 VA: 0x1CD2DA4
		public void Update(float deltaTime)
		{
			if (m_state == State.Play)
			{
				m_currentTime += deltaTime;
				m_currentNormalizeTime = m_curveInfo.m_animTime <= 0 ? 0 : m_currentTime / m_curveInfo.m_animTime;
				if (m_currentTime < m_curveInfo.m_animTime)
					return;
				if (!m_isLoop)
				{
					m_currentNormalizeTime = 1;
					m_currentTime = m_curveInfo.m_animTime;
					m_state = State.Stop;
				}
				else
				{
					m_currentTime -= m_curveInfo.m_animTime;
					m_currentNormalizeTime = m_curveInfo.m_animTime <= 0 ? 0 : m_currentTime / m_curveInfo.m_animTime;
				}
				if (OnCurveEndCallback != null)
					OnCurveEndCallback();
			}
		}

		//// RVA: 0x1CD2F54 Offset: 0x1CD2F54 VA: 0x1CD2F54
		public void Play(bool isLoop = false)
		{
			Play(false, isLoop, 0);
		}

		//// RVA: 0x1CD2F78 Offset: 0x1CD2F78 VA: 0x1CD2F78
		//public void Play(float normalizeTime, bool isLoop = False) { }

		//// RVA: 0x1CD3054 Offset: 0x1CD3054 VA: 0x1CD3054
		//public void PlayReverse(bool isLoop = False) { }

		//// RVA: 0x1CD3078 Offset: 0x1CD3078 VA: 0x1CD3078
		//public void PlayReverse(float normalizeTime, bool isLoop = False) { }

		//// RVA: 0x1CD3098 Offset: 0x1CD3098 VA: 0x1CD3098
		public void Stop()
		{
			m_state = State.Stop;
		}

		//// RVA: 0x1CD2F98 Offset: 0x1CD2F98 VA: 0x1CD2F98
		private void Play(bool isReverse, bool isLoop, float normalizeTime)
		{
			m_isReverse = isReverse;
			m_state = State.Play;
			m_isLoop = isLoop;
			m_currentNormalizeTime = Mathf.Clamp(normalizeTime, 0, 1);
			m_currentTime = m_currentNormalizeTime * m_curveInfo.m_animTime;
		}

		//// RVA: 0x1CD2DA8 Offset: 0x1CD2DA8 VA: 0x1CD2DA8
		//private void UpdateCurve(float deltaTime) { }

		//// RVA: 0x1CD30A4 Offset: 0x1CD30A4 VA: 0x1CD30A4
		//private float CulcNormalizeTime(float time, float length) { }
	}
}
