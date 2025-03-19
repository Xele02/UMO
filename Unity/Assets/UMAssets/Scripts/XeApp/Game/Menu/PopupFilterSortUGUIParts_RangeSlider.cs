using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_RangeSlider : PopupFilterSortUGUIPartsBase
	{
		[SerializeField]
		private UGUIRangeSliders m_rangeSliders; // 0x10
		[SerializeField]
		private UGUIButton m_minPlusButton; // 0x14
		[SerializeField]
		private UGUIButton m_minMinusButton; // 0x18
		[SerializeField]
		private UGUIButton m_maxPlusButton; // 0x1C
		[SerializeField]
		private UGUIButton m_maxMinusButton; // 0x20
		[SerializeField]
		private Text m_minText; // 0x24
		[SerializeField]
		private Text m_maxText; // 0x28
		private bool m_isPlayedSliderSEinFrame; // 0x2D

		public override Type MyType { get { return Type.RangeSlider; } } //0x17986F0
		public bool EnableSE { get; set; } // 0x2C

		// [IteratorStateMachineAttribute] // RVA: 0x709944 Offset: 0x709944 VA: 0x709944
		// RVA: 0x1798708 Offset: 0x1798708 VA: 0x1798708 Slot: 5
		protected override IEnumerator OnInitialize()
		{
			//0x1798DC8
			m_rangeSliders.SliderMin.onValueChanged.AddListener((float val) =>
			{
				//0x1798A3C
				if(m_minText != null)
					m_minText.text = val.ToString();
				PlaySliderSE();
			});
			m_rangeSliders.SliderMax.onValueChanged.AddListener((float val) =>
			{
				//0x1798B20
				if(m_maxText != null)
					m_maxText.text = val.ToString();
				PlaySliderSE();
			});
			if(m_minPlusButton != null)
			{
				m_minPlusButton.AddOnClickCallback(() =>
				{
					//0x1798C04
					PlaySliderSE();
					m_rangeSliders.CurrentMin += 1;
				});
			}
			if(m_minMinusButton != null)
			{
				m_minMinusButton.AddOnClickCallback(() =>
				{
					//0x1798C74
					PlaySliderSE();
					m_rangeSliders.CurrentMin -= 1;
				});
			}
			if(m_maxPlusButton != null)
			{
				m_maxPlusButton.AddOnClickCallback(() =>
				{
					//0x1798CE4
					PlaySliderSE();
					m_rangeSliders.CurrentMax += 1;
				});
			}
			if(m_maxMinusButton != null)
			{
				m_maxMinusButton.AddOnClickCallback(() =>
				{
					//0x1798D54
					PlaySliderSE();
					m_rangeSliders.CurrentMax -= 1;
				});
			}
			EnableSE = true;
			yield break;
		}

		// RVA: 0x17987B4 Offset: 0x17987B4 VA: 0x17987B4
		private void Update()
		{
			m_isPlayedSliderSEinFrame = false;
		}

		// RVA: 0x17987C0 Offset: 0x17987C0 VA: 0x17987C0
		public void SetRangeLimit(float minLimit, float maxLimit)
		{
			EnableSE = false;
			m_rangeSliders.LimitMin = minLimit;
			m_rangeSliders.LimitMax = maxLimit;
			EnableSE = true;
		}

		// // RVA: 0x1798830 Offset: 0x1798830 VA: 0x1798830
		public float GetLimitMin()
		{
			return m_rangeSliders.LimitMin;
		}

		// // RVA: 0x179885C Offset: 0x179885C VA: 0x179885C
		public float GetLimitMax()
		{
			return m_rangeSliders.LimitMax;
		}

		// RVA: 0x1798888 Offset: 0x1798888 VA: 0x1798888
		public void SetMin(float min)
		{
			EnableSE = false;
			m_rangeSliders.CurrentMin = min;
			EnableSE = true;
		}

		// RVA: 0x17988D0 Offset: 0x17988D0 VA: 0x17988D0
		public void SetMax(float max)
		{
			EnableSE = false;
			m_rangeSliders.CurrentMax = max;
			EnableSE = true;
		}

		// // RVA: 0x1798918 Offset: 0x1798918 VA: 0x1798918
		public float GetMin()
		{
			return m_rangeSliders.CurrentMin;
		}

		// // RVA: 0x1798944 Offset: 0x1798944 VA: 0x1798944
		public float GetMax()
		{
			return m_rangeSliders.CurrentMax;
		}

		// // RVA: 0x1798970 Offset: 0x1798970 VA: 0x1798970
		private void PlaySliderSE()
		{
			if(!EnableSE)
				return;
			if(m_isPlayedSliderSEinFrame)
				return;
			SoundManager.Instance.sePlayerBoot.Stop();
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
		}
	}
}
