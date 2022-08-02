using UnityEngine;

namespace XeApp.Game
{
	public class TranslationTween : TweenBase
	{
		[SerializeField]
		private Vector3 m_from; // 0x18
		[SerializeField]
		private Vector3 m_to; // 0x24

		// RVA: 0xE3CEE4 Offset: 0xE3CEE4 VA: 0xE3CEE4
		private void Start()
		{
			transform.localPosition = m_from;
		}

		// RVA: 0xE3CF3C Offset: 0xE3CF3C VA: 0xE3CF3C Slot: 4
		public override void UpdateCurve()
		{
			if(!IsPause)
			{
				base.UpdateCurve();
				transform.localPosition = Vector3.Slerp(m_from, m_to, Evaluate());
			}
		}

		// // RVA: 0xE3D07C Offset: 0xE3D07C VA: 0xE3D07C
		public void ResetCurve()
		{
			ResetTime();
			transform.localPosition = Vector3.Slerp(m_from, m_to, Evaluate());
		}
	}
}
