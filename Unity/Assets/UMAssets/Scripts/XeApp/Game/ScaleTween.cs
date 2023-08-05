using UnityEngine;

namespace XeApp.Game
{
	public class ScaleTween : TweenBase
	{
		[SerializeField]
		private Vector3 m_from; // 0x18
		[SerializeField]
		private Vector3 m_to; // 0x24
		[SerializeField]
		private Transform m_target; // 0x30

		// RVA: 0x156E868 Offset: 0x156E868 VA: 0x156E868
		private void Reset()
		{
			m_target = transform;
			m_from = transform.localScale;
			m_to = m_from;
		}

		// RVA: 0x156E8C4 Offset: 0x156E8C4 VA: 0x156E8C4 Slot: 4
		public override void UpdateCurve()
		{
			base.UpdateCurve();
			m_target.localScale = Vector3.Lerp(m_from, m_to, Evaluate());
		}
	}
}
