using UnityEngine;

namespace XeApp.Game.Common
{
	public class UGUIGauge : MonoBehaviour
	{
		[SerializeField]
		protected RectTransform m_bandTrans; // 0xC
		[SerializeField]
		protected float m_maxValue = 100; // 0x10
		protected float m_currentValue = 100; // 0x14

		public float CurrentValue { get { return m_currentValue; } set
			{
				m_currentValue = Mathf.Clamp(value, 0, m_maxValue);
				ApplyBand();
			} } //0x1CD3704 0x1CD370C
		public float MaxValue { get { return m_maxValue; } set
			{
				m_maxValue = value;
				if (m_currentValue >= value)
					SetValue(value);
			} } //0x1CD37B8 0x1CD37C0

		// RVA: 0x1CD3874 Offset: 0x1CD3874 VA: 0x1CD3874
		private void Awake()
		{
			SetValue(m_maxValue);
		}

		//// RVA: 0x1CD3710 Offset: 0x1CD3710 VA: 0x1CD3710
		private void SetValue(float value)
		{
			CurrentValue = value;
		}

		//// RVA: 0x1CD37C4 Offset: 0x1CD37C4 VA: 0x1CD37C4
		//private void SetMaxValue(float maxValue) { }

		//// RVA: 0x1CD387C Offset: 0x1CD387C VA: 0x1CD387C
		private void ApplyBand()
		{
			if(m_bandTrans != null)
			{
				m_bandTrans.anchorMax = new Vector2(m_maxValue <= 0 ? 1 : m_currentValue / m_maxValue, 1);
			}
		}
	}
}
