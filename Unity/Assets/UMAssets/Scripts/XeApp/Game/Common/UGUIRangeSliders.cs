using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class UGUIRangeSliders : MonoBehaviour
	{
		// [TooltipAttribute] // RVA: 0x68CAC4 Offset: 0x68CAC4 VA: 0x68CAC4
		[SerializeField]
		private Slider m_sliderMin; // 0xC
		// [TooltipAttribute] // RVA: 0x68CB24 Offset: 0x68CB24 VA: 0x68CB24
		[SerializeField]
		private Slider m_sliderMax; // 0x10
		// [TooltipAttribute] // RVA: 0x68CB84 Offset: 0x68CB84 VA: 0x68CB84
		[SerializeField]
		private RectTransform m_fillTransMinLeft; // 0x14
		// [TooltipAttribute] // RVA: 0x68CBE8 Offset: 0x68CBE8 VA: 0x68CBE8
		[SerializeField]
		private RectTransform m_fillTransMinRight; // 0x18
		// [TooltipAttribute] // RVA: 0x68CC64 Offset: 0x68CC64 VA: 0x68CC64
		[SerializeField]
		private RectTransform m_fillTransCenter; // 0x1C
		// [TooltipAttribute] // RVA: 0x68CCC0 Offset: 0x68CCC0 VA: 0x68CCC0
		[SerializeField]
		private RectTransform m_fillTransMaxLeft; // 0x20
		// [TooltipAttribute] // RVA: 0x68CD3C Offset: 0x68CD3C VA: 0x68CD3C
		[SerializeField]
		private RectTransform m_fillTransMaxRight; // 0x24

		public Slider SliderMin { get { return m_sliderMin; } } //0x1CDA0B0
		public Slider SliderMax { get { return m_sliderMax; } } //0x1CDA0B8
		public float CurrentMin { get { return m_sliderMin.value; } set { m_sliderMin.value = value; } } //0x1CDA0C0 0x1CDA0F4
		public float CurrentMax { get { return m_sliderMax.value; } set { m_sliderMax.value = value; } } //0x1CDA130 0x1CDA164
		public float LimitMin { get { return m_sliderMin.minValue; } set { m_sliderMin.minValue = value; m_sliderMax.minValue = value; } } //0x1CDA1A0 0x1CDA1CC
		public float LimitMax { get { return m_sliderMin.maxValue; } set { m_sliderMin.maxValue = value; m_sliderMax.maxValue = value; } } //0x1CDA228 0x1CDA254

		// RVA: 0x1CDA2B0 Offset: 0x1CDA2B0 VA: 0x1CDA2B0
		private void Awake()
		{
			m_sliderMin.onValueChanged.AddListener(OnChangeSliderMin);
			m_sliderMax.onValueChanged.AddListener(OnChangeSliderMax);
		}

		// // RVA: 0x1CDA424 Offset: 0x1CDA424 VA: 0x1CDA424
		private void OnChangeSliderMin(float val)
		{
			if(m_sliderMax.value < val)
			{
				m_sliderMax.value = val;
			}
			UpdateFillSize();
		}

		// // RVA: 0x1CDA944 Offset: 0x1CDA944 VA: 0x1CDA944
		private void OnChangeSliderMax(float val)
		{
			if(m_sliderMin.value > val)
			{
				m_sliderMin.value = val;
			}
			UpdateFillSize();
		}

		// // RVA: 0x1CDA4B0 Offset: 0x1CDA4B0 VA: 0x1CDA4B0
		private void UpdateFillSize()
		{
			if(m_fillTransMinLeft != null)
			{
				m_fillTransMinLeft.anchorMax = new Vector2(m_sliderMin.fillRect.anchorMax.x, 1);
			}
			if(m_fillTransMinRight != null)
			{
				m_fillTransMinRight.anchorMin = new Vector2(m_sliderMin.fillRect.anchorMax.x, 0);
				m_fillTransMinRight.anchorMax = new Vector2((m_sliderMin.fillRect.anchorMax.x + m_sliderMax.fillRect.anchorMax.x) * 0.5f, 0);
			}
			if(m_fillTransCenter != null)
			{
				m_fillTransCenter.anchorMin = new Vector2(m_sliderMin.fillRect.anchorMax.x, 0);
				m_fillTransCenter.anchorMax = new Vector2(m_sliderMax.fillRect.anchorMax.x, 0);
			}
			if(m_fillTransMaxLeft != null)
			{
				m_fillTransMaxLeft.anchorMin = new Vector2((m_sliderMin.fillRect.anchorMax.x + m_sliderMax.fillRect.anchorMax.x) * 0.5f, 0);
				m_fillTransMaxLeft.anchorMax = new Vector2(m_sliderMax.fillRect.anchorMax.x, 0);
			}
			if(m_fillTransMaxRight != null)
			{
				m_fillTransMaxRight.anchorMin = new Vector2(m_sliderMax.fillRect.anchorMax.x, 0);
			}
		}
	}
}
