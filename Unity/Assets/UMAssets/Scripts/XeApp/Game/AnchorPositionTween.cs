using UnityEngine;

namespace XeApp.Game
{
	public class AnchorPositionTween : TweenBase
	{
		[SerializeField]
		private Vector2 m_from; // 0x18
		[SerializeField]
		private Vector2 m_to; // 0x20
		[SerializeField]
		private RectTransform m_rectTransform; // 0x28

		// RVA: 0xE5C5FC Offset: 0xE5C5FC VA: 0xE5C5FC
		private void Reset()
		{
			m_rectTransform = GetComponent<RectTransform>();
			m_from = m_rectTransform.anchoredPosition;
			m_to = m_rectTransform.anchoredPosition;
		}

		// RVA: 0xE5C6A4 Offset: 0xE5C6A4 VA: 0xE5C6A4 Slot: 4
		public override void UpdateCurve()
		{
			if(!IsPause)
			{
				base.UpdateCurve();
				m_rectTransform.anchoredPosition = Vector3.Slerp(m_from, m_to, Evaluate());
			}
		}

		//// RVA: 0xE5C828 Offset: 0xE5C828 VA: 0xE5C828
		//public void ResetCurve() { }
	}
}
