using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game
{
	public class ColorTween : TweenBase
	{
		[SerializeField]
		private Color m_from; // 0x18
		[SerializeField]
		private Color m_to; // 0x28
		[SerializeField]
		private Graphic m_target; // 0x38

		// RVA: 0xE5D184 Offset: 0xE5D184 VA: 0xE5D184
		private void Reset()
		{
			m_target = GetComponent<Graphic>();
			m_from = m_target.color;
			m_to = m_target.color;
		}

		// RVA: 0xE5D234 Offset: 0xE5D234 VA: 0xE5D234 Slot: 4
		public override void UpdateCurve()
		{
			base.UpdateCurve();
			m_target.color = Color.Lerp(m_from, m_to, Evaluate());
		}

		// RVA: 0xE58F00 Offset: 0xE58F00 VA: 0xE58F00
		//public void UpdateValue() { }
	}
}
