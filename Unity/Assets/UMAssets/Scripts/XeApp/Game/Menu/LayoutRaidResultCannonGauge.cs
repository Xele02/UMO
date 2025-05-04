using System;
using System.Collections;
using CriWare;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutRaidResultCannonGauge : LayoutUGUIScriptBase
	{
		public Action<int> OnCountUpEvent; // 0x1C
		public Action OnStockCountUpEvent; // 0x20
		public Action OnCountMaxEvent; // 0x24
		private int m_base; // 0x28
		private int m_diff; // 0x2C
		private int m_max = 100; // 0x30
		private bool m_isSkiped; // 0x34
		private CriAtomExPlayback m_countUpSEPlayback; // 0x38

		public AbsoluteLayout layoutMain { get; set; } // 0x14
		public AbsoluteLayout layoutDiff { get; set; } // 0x18

		// RVA: 0x188327C Offset: 0x188327C VA: 0x188327C
		private void OnDisable()
		{
			m_countUpSEPlayback.Stop(false);
		}

		// // RVA: 0x1883294 Offset: 0x1883294 VA: 0x1883294
		public void Setup(int _base, int max)
		{
			m_max = max;
			m_base = _base;
			if(layoutMain != null)
			{
				if(_base == max)
				{
					layoutMain.StartChildrenAnimGoStop(101, 101);
				}
				else
				{
					layoutMain.StartChildrenAnimGoStop((int)(((_base / 100.0f) % 1) * 101), (int)(((_base / 100.0f) % 1) * 101));
				}
			}
		}

		// // RVA: 0x1883350 Offset: 0x1883350 VA: 0x1883350
		public void SkipCountUp()
		{
			m_isSkiped = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x715AEC Offset: 0x715AEC VA: 0x715AEC
		// // RVA: 0x188335C Offset: 0x188335C VA: 0x188335C
		public IEnumerator StartCountUp(int diff, Action callback)
		{
			//0x1883D6C
			m_diff = Mathf.Clamp(diff, 0, m_max - m_base);
			yield return Co.R(Co_GaugeAnim());
			if(callback != null)
				callback();
		}

		// // RVA: 0x1883320 Offset: 0x1883320 VA: 0x1883320
		// private void UpdateGaugePosition(AbsoluteLayout layout, float normalizePos) { }

		// [IteratorStateMachineAttribute] // RVA: 0x715B64 Offset: 0x715B64 VA: 0x715B64
		// // RVA: 0x188343C Offset: 0x188343C VA: 0x188343C
		private IEnumerator Co_GaugeAnim()
		{
			float maxValue; // 0x14
			float startValue; // 0x18
			float endValue; // 0x1C
			float baseValue; // 0x20
			float currentTime; // 0x24
			float timeLength; // 0x28

			//0x1883788
			maxValue = m_max / 100.0f;
			startValue = Mathf.Clamp(m_base / 100.0f, 0, maxValue);
			endValue = Mathf.Clamp((m_diff + m_base) / 100.0f, 0, maxValue);
			currentTime = 0;
			baseValue = m_base == m_max ? 1 : startValue % 1;
			timeLength = 1.5f;
			if(layoutDiff != null)
				layoutDiff.StartChildrenAnimGoStop(0, 0);
			PlayCountUpLoopSE();
			while(true)
			{
				currentTime += TimeWrapper.deltaTime;
				float r = XeSys.Math.Tween.EasingInOutCubic(startValue, endValue, currentTime / timeLength);
				float r2 = (r - baseValue) % 1;
				if(r < maxValue)
				{
					if(layoutDiff != null)
						layoutDiff.StartChildrenAnimGoStop((int)(r2 * 101), (int)(r2 * 101));
				}
				if(OnCountUpEvent != null)
				{
					OnCountUpEvent((int)(r2 * 100));
				}
				if(maxValue <= r)
				{
					m_countUpSEPlayback.Stop(false);
					SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_005);
					if(OnCountMaxEvent != null)
						OnCountMaxEvent();
					if(layoutDiff != null)
						layoutDiff.StartChildrenAnimGoStop((int)((1 - baseValue) * 101), (int)((1 - baseValue) * 101));
					break;
				}
				if(baseValue + r2 >= 1 && OnStockCountUpEvent != null)
				{
					OnStockCountUpEvent();
					if(layoutMain != null)
						layoutMain.StartChildrenAnimGoStop(0, 0);
					if(layoutDiff != null)
						layoutDiff.StartChildrenAnimGoStop(0, 0);
					baseValue = 0;
				}
				if(timeLength <= currentTime)
				{
					if(layoutDiff != null)
						layoutDiff.StartChildrenAnimGoStop((int)(((endValue - baseValue) % 1) * 101), (int)(((endValue - baseValue) % 1) * 101));
					break;
				}
				if(!m_isSkiped)
					yield return null;
			}
			if(OnCountUpEvent != null)
				OnCountUpEvent(m_diff + m_base);
			m_countUpSEPlayback.Stop(false);
			this.StartCoroutineWatched(Co_FadeOutGauge(60));
		}

		// // RVA: 0x18834E8 Offset: 0x18834E8 VA: 0x18834E8
		// private void FadeOutGauge(int delay) { }

		// [IteratorStateMachineAttribute] // RVA: 0x715BDC Offset: 0x715BDC VA: 0x715BDC
		// // RVA: 0x188350C Offset: 0x188350C VA: 0x188350C
		private IEnumerator Co_FadeOutGauge(int delay)
		{
			int i;

			//0x1883660
			if(!m_isSkiped)
			{
				for(i = 0; i < delay; i++)
					yield return null;
			}
		}

		// // RVA: 0x18835D4 Offset: 0x18835D4 VA: 0x18835D4
		private void PlayCountUpLoopSE()
		{
			m_countUpSEPlayback = SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_004);
		}

		// // RVA: 0x1883288 Offset: 0x1883288 VA: 0x1883288
		// private void StopCountUpLoopSE() { }

		// RVA: 0x1883634 Offset: 0x1883634 VA: 0x1883634 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			return true;
		}
	}
}
