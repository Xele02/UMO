using System;
using System.Collections;
using UnityEngine;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutResultTitleCutin : LayoutUGUIScriptBase
	{
		private AbsoluteLayout layoutRoot; // 0x14
		private bool m_isSkiped; // 0x18
		private Matrix23 m_identity; // 0x1C
		private Coroutine m_coroutine; // 0x34
		public Action onFinished; // 0x38

		// RVA: 0x1D1BBA0 Offset: 0x1D1BBA0 VA: 0x1D1BBA0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			layoutRoot = layout.FindViewById("sw_g_r_title") as AbsoluteLayout;
			Loaded();
			return true;
		}

		// // RVA: 0x1D1BC78 Offset: 0x1D1BC78 VA: 0x1D1BC78
		public void StartAnim()
		{
			layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
			m_coroutine = this.StartCoroutineWatched(Co_PlayingStartPopupAnim());
		}

		// // RVA: 0x1D1BDAC Offset: 0x1D1BDAC VA: 0x1D1BDAC
		public void SkipAnim()
		{
			m_isSkiped = true;
			if(m_coroutine != null)
				return;
			StartAnim();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71EA84 Offset: 0x71EA84 VA: 0x71EA84
		// // RVA: 0x1D1BD20 Offset: 0x1D1BD20 VA: 0x1D1BD20
		private IEnumerator Co_PlayingStartPopupAnim()
		{
			//0x1D1BED0
			yield return Co.R(Co_WaitAnim(layoutRoot, true));
			if(onFinished != null)
				onFinished();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71EAFC Offset: 0x71EAFC VA: 0x71EAFC
		// // RVA: 0x1D1BDE4 Offset: 0x1D1BDE4 VA: 0x1D1BDE4
		private IEnumerator Co_WaitAnim(AbsoluteLayout layout, bool enableSkip = true)
		{
			//0x1D1C01C
			while(layout.IsPlayingChildren())
			{
				if(!m_isSkiped || (m_isSkiped && !enableSkip))
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
