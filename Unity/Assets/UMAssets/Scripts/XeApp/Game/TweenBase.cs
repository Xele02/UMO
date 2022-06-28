using UnityEngine;
using XeSys;

namespace XeApp.Game
{
	public class TweenBase : MonoBehaviour
	{
		[SerializeField]
		private AnimationCurve m_curve; // 0xC
		private float m_time; // 0x10
		private bool m_isPause; // 0x14

		public bool IsPause { get { return m_isPause; } set { m_isPause = value; } }// 0x191AB48 0x191AB50

		// RVA: 0x191AB58 Offset: 0x191AB58 VA: 0x191AB58 Slot: 4
		public virtual void UpdateCurve()
		{
			m_time += TimeWrapper.deltaTime;
		}

		// // RVA: 0x191AB88 Offset: 0x191AB88 VA: 0x191AB88
		// public void ResetTime() { }

		// // RVA: 0x191AB94 Offset: 0x191AB94 VA: 0x191AB94
		public float Evaluate()
		{
			return m_curve.Evaluate(m_time);
		}

		// // RVA: 0x191ABD0 Offset: 0x191ABD0 VA: 0x191ABD0
		// public bool IsEnd() { }

		// // RVA: 0x191ACB8 Offset: 0x191ACB8 VA: 0x191ACB8
		// public void End() { }
	}
}
