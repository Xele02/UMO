using System;
using UnityEngine;

namespace XeSys.Gfx
{
	[Serializable]
	public class ViewAnimation
	{
		public enum LoopType
		{
			none = 0,
			loop = 1,
			round = 2,
		}

		public enum InterpolationType
		{
			linear = 0,
			acc = 1,
			dec = 2,
		}

		[SerializeField]
		private ViewTransformData m_BaseTransform = new ViewTransformData(); // 0x8
		[SerializeField]
		private ViewTransformData m_TargetTransform = new ViewTransformData(); // 0xC
		[SerializeField]
		private float m_timeScale = 1.0f; // 0x10
		[SerializeField]
		private float m_AnimTime = 1.0f; // 0x14
		[SerializeField]
		private float m_AnimCount; // 0x18
		[SerializeField]
		private bool m_IsAnimEnd = true; // 0x1C
		[SerializeField]
		private ViewAnimation.LoopType m_LoopType; // 0x20
		private int m_LoopCount; // 0x24
		[SerializeField]
		private ViewAnimation.InterpolationType m_InterType; // 0x28
		public bool m_IsPosAnim = true; // 0x2C
		public bool m_IsSizeAnim = true; // 0x2D
		public bool m_IsScaleAnim = true; // 0x2E
		public bool m_IsRotAnim = true; // 0x2F
		public bool m_IsColAnim = true; // 0x30
		public bool m_IsCenterAnim = true; // 0x31
		private const float ACC_P2 = 0;
		private const float ACC_P3 = 0.5f;
		private const float DEC_P2 = 0.5f;
		private const float DEC_P3 = 1;

		// public ViewTransformData Base { get; } 0x1EE52F0
		// public ViewTransformData Target { get; } 0x1EE52F8
		// public float TimeScale { get; set; } 0x1EE5300 0x1EE5308
		// public float AnimTime { get; set; } 0x1EE5310 0x1EE5318
		// public float AnimCount { get; set; } 0x1EE5320 0x1EE5328
		public bool IsAnimEnd { get { return m_IsAnimEnd; } set { m_IsAnimEnd = value; } } //0x1EE5330 0x1EE5338
		// public ViewAnimation.LoopType loopType { get; set; } 0x1EE5340 0x1EE5348
		// public int loopCount { get; set; } 0x1EE5350 0x1EE5358
		// public ViewAnimation.InterpolationType interpolationType { get; set; } 0x1EE5360 0x1EE5368
		// public bool IsPosAnim { get; set; } 0x1EE5370 0x1EE5378
		// public bool IsSizeAnim { get; set; } 0x1EE5380 0x1EE5388
		// public bool IsScaleAnim { get; set; } 0x1EE5390 0x1EE5398
		// public bool IsRotAnim { get; set; } 0x1EE53A0 0x1EE53A8
		// public bool IsColAnim { get; set; } 0x1EE53B0 0x1EE53B8
		// public bool IsCenterAnim { get; set; } 0x1EE53C0 0x1EE53C8

		// // RVA: 0x1EE53D0 Offset: 0x1EE53D0 VA: 0x1EE53D0
		// public void SetBase(ViewTransformData data) { }

		// // RVA: 0x1EE54B0 Offset: 0x1EE54B0 VA: 0x1EE54B0
		// public void AnimStart(float time) { }

		// // RVA: 0x1EE54C4 Offset: 0x1EE54C4 VA: 0x1EE54C4
		public void Update(float dt)
		{
			if(m_IsAnimEnd)
				return;
			m_AnimCount = m_AnimCount + m_timeScale * dt;
			if(m_AnimCount < m_AnimTime)
				return;
			if(m_LoopType != LoopType.none && m_LoopCount > 0)
			{
				m_AnimCount = 0.0f;
				m_LoopCount = m_LoopCount - 1;
				return;
			}
			m_IsAnimEnd = true;
			m_AnimCount = m_AnimTime;
		}

		// // RVA: 0x1EE5538 Offset: 0x1EE5538 VA: 0x1EE5538
		public void GetAnimTransform(ViewTransformData data, ref bool isUpdateSRT)
		{
			float length = m_AnimTime;
			float percent = m_AnimCount / m_AnimTime;
			if(m_LoopType == LoopType.round)
			{
				length = 1.0f;
				percent = percent + percent;
				if(percent >= 1.0f)
				{
					percent = 1.0f - (percent - 1.0f);
				}
			}
			
			if(m_InterType == InterpolationType.dec)
			{
				float invPercent = 1.0f - percent;
				float a = invPercent * 3;
				length = percent * percent * invPercent * 3.0f;
				invPercent = percent * invPercent * invPercent * 3.0f * 0.5f;
				length = length + a * 0.0f + invPercent;
				percent = percent * percent * percent + length;
			}
			else if(m_InterType == InterpolationType.acc)
			{
				length = 1.0f - percent;
				float a = length * length * length;
				float b = percent * length * length * 3.0f * 0.0f;
				length = percent * percent * length * 3.0f * 0.5f;
				length = length + a * 0.0f + b;
				percent = percent * percent * percent + length;
			}
			if(m_IsPosAnim)
			{
				data.m.Pos = Vector2.Lerp(m_BaseTransform.m.Pos, m_TargetTransform.m.Pos, percent);
				isUpdateSRT = true;
			}
			if(m_IsSizeAnim)
			{
				data.m.Size = Vector2.Lerp(m_BaseTransform.m.Size, m_TargetTransform.m.Size, percent);
				isUpdateSRT = true;
			}
			if(m_IsScaleAnim)
			{
				data.m.Scale = Vector2.Lerp(m_BaseTransform.m.Scale, m_TargetTransform.m.Scale, percent);
				isUpdateSRT = true;
			}
			if(m_IsRotAnim)
			{
				data.m.Rot = m_BaseTransform.m.Rot + percent * (m_TargetTransform.m.Rot - m_BaseTransform.m.Rot);
				isUpdateSRT = true;
			}
			if(m_IsColAnim)
			{
				data.m.Color = Color.Lerp(m_BaseTransform.m.Color, m_TargetTransform.m.Color, percent);
				isUpdateSRT = true;
			}
			if(m_IsCenterAnim)
			{
				data.m.Center = Vector2.Lerp(m_BaseTransform.m.Center, m_TargetTransform.m.Center, percent);
				isUpdateSRT = true;
			}
		}

		// // RVA: 0x1EE5A7C Offset: 0x1EE5A7C VA: 0x1EE5A7C
		// private float GetBezierValue(float t, float p1, float p2, float p3, float p4) { }

		// // RVA: 0x1EE5B94 Offset: 0x1EE5B94 VA: 0x1EE5B94
		// public void CopyTo(ViewAnimation data) { }

		// // RVA: 0x1EE5C80 Offset: 0x1EE5C80 VA: 0x1EE5C80
		// public ViewAnimation DeepClone() { }
	}
}
