using UnityEngine;

namespace XeApp.Game
{
	public class RotationTween : TweenBase
	{
		[SerializeField]
		private Vector3 m_from; // 0x18
		[SerializeField]
		private Vector3 m_to; // 0x24

		// RVA: 0x156ACAC Offset: 0x156ACAC VA: 0x156ACAC
		private void Start() 
		{
			transform.localRotation = Quaternion.Euler(m_from);
		}

		// RVA: 0x156AD90 Offset: 0x156AD90 VA: 0x156AD90 Slot: 4
		public override void UpdateCurve()
		{
			base.UpdateCurve();
			transform.localRotation = Quaternion.Euler(Vector3.Slerp(m_from, m_to, Evaluate()));
		}
	}
}
