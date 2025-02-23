using System;
using System.Collections;
using CriWare;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutBattleExGauge : LayoutUGUIScriptBase
	{
		public Action<int> OnCountUpEvent; // 0x24
		public Action OnCountMaxEvent; // 0x28
		private int m_base; // 0x2C
		private int m_diff0; // 0x30
		private int m_diff; // 0x34
		private int m_max = 100; // 0x38
		private bool m_isSkiped; // 0x3C
		private CriAtomExPlayback m_countUpSEPlayback; // 0x40

		public AbsoluteLayout layoutMain { get; set; } // 0x14
		public AbsoluteLayout layoutDiff { get; set; } // 0x18
		public AbsoluteLayout layoutIn { get; set; } // 0x1C
		public AbsoluteLayout layoutOut { get; set; } // 0x20

		// RVA: 0x14C109C Offset: 0x14C109C VA: 0x14C109C
		private void OnDisable()
		{
			m_countUpSEPlayback.Stop(false);
		}

		// // RVA: 0x14C10B4 Offset: 0x14C10B4 VA: 0x14C10B4
		public void Setup(int _base, int max, int diff0 = 0)
		{
			m_max = max;
			m_base = _base;
			m_diff0 = Mathf.Clamp(diff0, 0, max - _base);
			m_diff = m_diff0;
			if(max < m_diff)
			{
				UpdateGaugePosition(layoutMain, 1);
				UpdateGaugePosition(layoutDiff, 1);
				UpdateGaugePosition(layoutIn, 0);
				UpdateGaugePosition(layoutOut, 0);
			}
			else
			{
				float n = Mathf.Clamp(m_base * 1.0f / m_max, 0, 1);
				float n2 = Mathf.Clamp(m_diff0 * 1.0f / m_max, 0, 1);
				UpdateGaugePosition(layoutMain, n + n2);
				UpdateGaugePosition(layoutDiff, n);
				UpdateGaugePosition(layoutIn, n + n2);
				UpdateGaugePosition(layoutOut, n);
			}
		}

		// // RVA: 0x14C12E0 Offset: 0x14C12E0 VA: 0x14C12E0
		public void SkipCountUp()
		{
			m_isSkiped = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EE9EC Offset: 0x6EE9EC VA: 0x6EE9EC
		// // RVA: 0x14C12EC Offset: 0x14C12EC VA: 0x14C12EC
		public IEnumerator StartCountUp(int diff, Action callback)
		{
			//0x14C1DC0
			m_diff = Mathf.Clamp(diff, 0, m_max - m_base);
			yield return Co.R(Co_GaugeAnim());
			if(callback != null)
				callback();
		}

		// // RVA: 0x14C1264 Offset: 0x14C1264 VA: 0x14C1264
		private void UpdateGaugePosition(AbsoluteLayout layout, float normalizePos)
		{
			if(layout != null)
			{
				int v = (int)((layout.FrameAnimation.FrameNum + 1) * normalizePos);
				layout.StartAnimGoStop(v, v);
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EEA64 Offset: 0x6EEA64 VA: 0x6EEA64
		// // RVA: 0x14C13CC Offset: 0x14C13CC VA: 0x14C13CC
		private IEnumerator Co_GaugeAnim()
		{
			float startValue; // 0x14
			float endValue; // 0x18
			float maxValue; // 0x1C
			float currentTime; // 0x20
			float timeLength; // 0x24

			//0x14C18D0
			startValue = Mathf.Clamp((m_base + m_diff0) * 1.0f / m_max, 0, 1);
			maxValue = 1.0f;
			endValue = Mathf.Clamp((m_diff + m_base) * 1.0f / m_max, 0, 1);
			currentTime = 0;
			timeLength = 1.5f;
			FadeInGauge();
			UpdateGaugePosition(layoutDiff, startValue);
			PlayCountUpLoopSE();
			float f;
			while(true)
			{
				currentTime += TimeWrapper.deltaTime;
				f = XeSys.Math.Tween.EasingInOutCubic(startValue, endValue, currentTime / timeLength) % 1;
				UpdateGaugePosition(layoutMain, f);
				UpdateGaugePosition(layoutIn, f);
				if(OnCountUpEvent != null)
				{
					OnCountUpEvent.Invoke((int)(f * m_max));
				}
				if(maxValue <= currentTime)
				{
					m_countUpSEPlayback.Stop(false);
					SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_005);
					if(OnCountMaxEvent != null)
						OnCountMaxEvent.Invoke();
					break;
				}
				if(timeLength <= currentTime)
				{
					break;
				}
				if(!m_isSkiped)
					yield return null;
			}
			UpdateGaugePosition(layoutMain, endValue);
			UpdateGaugePosition(layoutIn, f);
			if(OnCountUpEvent != null)
				OnCountUpEvent.Invoke(m_diff + m_base);
			m_countUpSEPlayback.Stop(false);
			this.StartCoroutineWatched(Co_FadeOutGauge(60));
		}

		// // RVA: 0x14C1478 Offset: 0x14C1478 VA: 0x14C1478
		private void FadeInGauge()
		{
			if(layoutDiff != null)
			{
				layoutDiff.StartChildrenAnimGoStop("st_wait");
			}
			if(layoutOut != null)
			{
				layoutOut.StartChildrenAnimGoStop("go_in", "st_in");
			}
			if(layoutIn != null)
			{
				layoutIn.StartChildrenAnimGoStop("st_stop");
			}
		}

		// // RVA: 0x14C1540 Offset: 0x14C1540 VA: 0x14C1540
		// private void FadeOutGauge(int delay) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6EEADC Offset: 0x6EEADC VA: 0x6EEADC
		// // RVA: 0x14C1564 Offset: 0x14C1564 VA: 0x14C1564
		private IEnumerator Co_FadeOutGauge(int delay)
		{
			int i;

			//0x14C16B8
			if(!m_isSkiped)
			{
				for(i = 0; i < delay; i++)
					yield return null;
			}
			//LAB_014c1780
			if(layoutDiff != null)
				layoutDiff.StartChildrenAnimGoStop("go_out", "st_out");
			if(layoutOut != null)
				layoutOut.StartChildrenAnimGoStop("go_out", "st_out");
			if(layoutIn != null)
				layoutIn.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0x14C162C Offset: 0x14C162C VA: 0x14C162C
		private void PlayCountUpLoopSE()
		{
			m_countUpSEPlayback = SoundManager.Instance.sePlayerResult.Play(4);
		}

		// // RVA: 0x14C10A8 Offset: 0x14C10A8 VA: 0x14C10A8
		// private void StopCountUpLoopSE() { }

		// RVA: 0x14C168C Offset: 0x14C168C VA: 0x14C168C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			return true;
		}
	}
}
