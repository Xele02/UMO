using System;
using System.Collections;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class RaidResultRewardFinishLayout : LayoutUGUIScriptBase
	{
		public Action onFinished; // 0x14
		public Action onClickButton; // 0x18
		private Matrix23 m_identity; // 0x1C
		private Coroutine m_coroutine; // 0x34
		private AbsoluteLayout m_layoutRoot; // 0x38
		private bool m_isSkiped; // 0x3C
		private bool m_isChargeBonus; // 0x3D

		// RVA: 0x1BE1A50 Offset: 0x1BE1A50 VA: 0x1BE1A50
		private void OnDisable()
		{
			SoundManager.Instance.sePlayerResultLoop.Stop();
		}

		// RVA: 0x1BE1AA4 Offset: 0x1BE1AA4 VA: 0x1BE1AA4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewByExId("root_g_r_r_finish_cc_sw_g_r_r_finish") as AbsoluteLayout;
			m_layoutRoot.StartChildrenAnimGoStop("go_finish", "go_finish");
			Loaded();
			return true;
		}

		// RVA: 0x1BE1BAC Offset: 0x1BE1BAC VA: 0x1BE1BAC
		public void Setup()
		{
			m_coroutine = null;
			m_isSkiped = false;
			m_layoutRoot.StartChildrenAnimGoStop("go_finish", "go_finish");
		}

		// // RVA: 0x1BE1C38 Offset: 0x1BE1C38 VA: 0x1BE1C38
		// public void SkipBeginAnim() { }

		// // RVA: 0x1BE1C44 Offset: 0x1BE1C44 VA: 0x1BE1C44
		public void StartBeginAnim()
		{
			if(m_isSkiped)
				return;
			m_coroutine = this.StartCoroutineWatched(Co_BeginAnim());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x720064 Offset: 0x720064 VA: 0x720064
		// // RVA: 0x1BE1C7C Offset: 0x1BE1C7C VA: 0x1BE1C7C
		private IEnumerator Co_BeginAnim()
		{
			//0x1BE1FB8
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_030);
			yield return Co.R(Co_ShowText());
			if(onFinished != null)
				onFinished();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7200DC Offset: 0x7200DC VA: 0x7200DC
		// // RVA: 0x1BE1D28 Offset: 0x1BE1D28 VA: 0x1BE1D28
		private IEnumerator Co_ShowText()
		{
			//0x1BE2130
			m_layoutRoot.StartChildrenAnimGoStop("go_finish", "st_finish");
			yield return Co.R(Co_WaitAnim(m_layoutRoot, true));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x720154 Offset: 0x720154 VA: 0x720154
		// // RVA: 0x1BE1DD4 Offset: 0x1BE1DD4 VA: 0x1BE1DD4
		// private IEnumerator Co_WaitLabel(AbsoluteLayout layout, string label, bool enableSkip = True) { }

		// [IteratorStateMachineAttribute] // RVA: 0x7201CC Offset: 0x7201CC VA: 0x7201CC
		// // RVA: 0x1BE1ECC Offset: 0x1BE1ECC VA: 0x1BE1ECC
		private IEnumerator Co_WaitAnim(AbsoluteLayout layout, bool enableSkip/* = True*/)
		{
			//0x1BE22B4
			while(layout.IsPlayingChildren())
			{
				if(!m_isSkiped || !enableSkip)
					yield return null;
				else
				{
					layout.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
					layout.UpdateAll(m_identity, Color.white);
				}
			}
		}
	}
}
