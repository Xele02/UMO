using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.UI;
using System;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class LayoutEventGoDivaRadarChart : LayoutUGUIScriptBase
	{
		private enum StatusType
		{
			Soul = 0,
			Voice = 1,
			Charm = 2,
			Num = 3,
		}

		private static float MinChartValue = 0.1f; // 0x0
		private static string StatusTextFormat = "{0}/{1}"; // 0x4
		[SerializeField] // RVA: 0x672DB4 Offset: 0x672DB4 VA: 0x672DB4
		private Text[] m_textStatus = new Text[3]; // 0x14
		private bool m_isShown; // 0x18
		private AbsoluteLayout m_layoutMain; // 0x1C
		private AbsoluteLayout m_layoutAllMax; // 0x20
		private AbsoluteLayout[] m_layoutStatusMax = new AbsoluteLayout[3]; // 0x24
		private ModifierRadarChart m_radarChart; // 0x28
		private int[] m_maxStatusValues = new int[3] { 10, 10, 10 }; // 0x2C
		private int[] m_curStatusValues = new int[3]; // 0x30
		private int[] m_prevStatusValues = new int[3]; // 0x34
		private Coroutine m_coroutineWaitEnter; // 0x38
		private Coroutine m_coroutineMoveRadarChart; // 0x3C

		// // RVA: 0x1994AE4 Offset: 0x1994AE4 VA: 0x1994AE4
		public void SetMaxStatusValues(int soul, int voice, int charm)
		{
			m_maxStatusValues[0] = soul;
			m_maxStatusValues[1] = voice;
			m_maxStatusValues[2] = charm;
		}

		// // RVA: 0x1994B9C Offset: 0x1994B9C VA: 0x1994B9C
		public void Enter()
		{
			m_isShown = true;
			m_layoutMain.StartChildrenAnimGoStop("go_in", "st_in");
			SetRadarChartPreMove();
			m_coroutineWaitEnter = this.StartCoroutineWatched(Co_WaitEnter());
		}

		// // RVA: 0x1995088 Offset: 0x1995088 VA: 0x1995088
		public void Leave()
		{
			m_isShown = false;
			m_layoutMain.StartChildrenAnimGoStop("go_out", "st_out");
			if(m_coroutineWaitEnter != null)
				this.StopCoroutineWatched(m_coroutineWaitEnter);
			if(m_coroutineMoveRadarChart != null)
				this.StopCoroutineWatched(m_coroutineMoveRadarChart);
		}

		// // RVA: 0x199514C Offset: 0x199514C VA: 0x199514C
		public void TryEnter()
		{
			if(!m_isShown)
				Enter();
		}

		// // RVA: 0x199515C Offset: 0x199515C VA: 0x199515C
		public void TryLeave()
		{
			if(m_isShown)
				Leave();
		}

		// // RVA: 0x199516C Offset: 0x199516C VA: 0x199516C
		// public void Show() { }

		// // RVA: 0x1995614 Offset: 0x1995614 VA: 0x1995614
		public void Hide()
		{
			m_isShown = false;
			m_layoutMain.StartChildrenAnimGoStop("st_wait");
		}

		// RVA: 0x1995698 Offset: 0x1995698 VA: 0x1995698
		public bool IsPlaying()
		{
			return m_layoutMain.IsPlayingChildren();
		}

		// // RVA: 0x19956C4 Offset: 0x19956C4 VA: 0x19956C4
		public void SetStatus(int soul, int voice, int charm)
		{
			Array.Copy(m_curStatusValues, m_prevStatusValues, m_curStatusValues.Length);
			m_curStatusValues[0] = soul;
			m_curStatusValues[1] = voice;
			m_curStatusValues[2] = charm;
			if(m_isShown)
			{
				if(m_coroutineMoveRadarChart != null)
					this.StopCoroutineWatched(m_coroutineMoveRadarChart);
				m_coroutineMoveRadarChart = this.StartCoroutineWatched(Co_MoveRadarChart());
			}
		}

		// // RVA: 0x1995874 Offset: 0x1995874 VA: 0x1995874
		// public bool IsMovingRadarChart() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F1724 Offset: 0x6F1724 VA: 0x6F1724
		// // RVA: 0x1994FFC Offset: 0x1994FFC VA: 0x1994FFC
		private IEnumerator Co_WaitEnter()
		{
			//0x1996604
			while(IsPlaying())
				yield return null;
			m_coroutineMoveRadarChart = this.StartCoroutineWatched(Co_MoveRadarChart());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F179C Offset: 0x6F179C VA: 0x6F179C
		// // RVA: 0x19957E8 Offset: 0x19957E8 VA: 0x19957E8
		private IEnumerator Co_MoveRadarChart()
		{
			//0x19960F8
			m_radarChart.SetValues(GetValuesForRadarChart(), true);
			bool b = true;
			for(int i = 0; i < 3; i++)
			{
				if((m_curStatusValues[i] < m_maxStatusValues[i]) || (m_curStatusValues[i] != m_prevStatusValues[i]))
				{
					//LAB_01996308
					m_layoutStatusMax[i].StartChildrenAnimGoStop("01");
					m_textStatus[i].text = string.Format("StatusTextFormat", m_curStatusValues[i], m_maxStatusValues[i]);
					b = false;
				}
			}
			if(!b)
			{
				m_layoutAllMax.StartChildrenAnimGoStop("01");
			}
			while(m_radarChart.IsMoving())
				yield return null;
			SetRadarChartPostMove();
		}

		// // RVA: 0x19958E0 Offset: 0x19958E0 VA: 0x19958E0
		private float[] GetValuesForRadarChart()
		{
			float[] res = new float[3];
			for(int i = 0; i < 3; i++)
			{
				res[i] = Math.Min(1, MinChartValue + (m_curStatusValues[i] * 1.0f / m_maxStatusValues[i]) * (1.0f - MinChartValue));
			}
			return res;
		}

		// // RVA: 0x1994C54 Offset: 0x1994C54 VA: 0x1994C54
		private void SetRadarChartPreMove()
		{
			m_radarChart.SetValues(new float[3] { MinChartValue, MinChartValue, MinChartValue }, false);
			for(int i = 0; i < 3; i++)
			{
				m_textStatus[i].text = string.Format(StatusTextFormat, m_curStatusValues[i], m_maxStatusValues[i]);
				m_layoutStatusMax[i].StartChildrenAnimGoStop("01");
			}
			m_layoutAllMax.StartChildrenAnimGoStop("01");
		}

		// // RVA: 0x1995228 Offset: 0x1995228 VA: 0x1995228
		private void SetRadarChartPostMove()
		{
			m_radarChart.SetValues(GetValuesForRadarChart(), false);
			bool b = true;
			for(int i = 0; i < 3; i++)
			{
				if(m_curStatusValues[i] < m_maxStatusValues[i])
				{
					m_layoutStatusMax[i].StartChildrenAnimGoStop("01");
					m_textStatus[i].text = string.Format(StatusTextFormat, m_curStatusValues[i], m_maxStatusValues[i]);
					b = false;
				}
				else
				{
					m_layoutStatusMax[i].StartChildrenAnimGoStop("02");
					m_textStatus[i].text = "";
				}
			}
			m_layoutAllMax.StartChildrenAnimGoStop(b ? "02" : "01");
		}

		// RVA: 0x1995AD8 Offset: 0x1995AD8 VA: 0x1995AD8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_layoutMain = layout.FindViewById("sw_sel_me3_rader_chart_inout_anim") as AbsoluteLayout;
			m_layoutAllMax = layout.FindViewById("swtbl_sel_me3_rader_chart_ef_anim") as AbsoluteLayout;
			m_layoutStatusMax[0] = layout.FindViewById("swtbl_sel_me3_rader_soul") as AbsoluteLayout;
			m_layoutStatusMax[1] = layout.FindViewById("swtbl_sel_me3_rader_voice") as AbsoluteLayout;
			m_layoutStatusMax[2] = layout.FindViewById("swtbl_sel_me3_rader_charm") as AbsoluteLayout;
			m_radarChart = GetComponentInChildren<ModifierRadarChart>();
			Loaded();
			return true;
		}
	}
}
