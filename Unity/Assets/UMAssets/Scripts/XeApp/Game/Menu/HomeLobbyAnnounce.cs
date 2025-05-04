using System;
using System.Collections;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class HomeLobbyAnnounce : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_layout; // 0x14
		private bool m_isSkiped; // 0x18
		private Matrix23 m_identity; // 0x1C

		// RVA: 0x965748 Offset: 0x965748 VA: 0x965748
		public void StartAnim(Action onEndCallback)
		{
			this.StartCoroutineWatched(Co_StartAnim(onEndCallback));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E270C Offset: 0x6E270C VA: 0x6E270C
		// // RVA: 0x96576C Offset: 0x96576C VA: 0x96576C
		private IEnumerator Co_StartAnim(Action onEndCallback)
		{
			//0x965A04
			m_layout.StartChildrenAnimGoStop("go_in", "st_in");
			yield return Co.R(Co_WaitAnim(m_layout, true));
			SoundManager.Instance.sePlayerMenu.Play((int)mcrs.cs_se_menu.SE_TUNEUP_000);
			m_layout.StartChildrenAnimGoStop("logo_act", "loen_act");
			yield return Co.R(Co_WaitAnim(m_layout, true));
			m_layout.StartChildrenAnimGoStop("go_out", "st_out");
			yield return Co.R(Co_WaitAnim(m_layout, true));
			if(onEndCallback != null)
				onEndCallback();
		}

		// // RVA: 0x965834 Offset: 0x965834 VA: 0x965834
		// public void SkipAnim() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E2784 Offset: 0x6E2784 VA: 0x6E2784
		// // RVA: 0x965840 Offset: 0x965840 VA: 0x965840
		private IEnumerator Co_WaitAnim(AbsoluteLayout layout, bool enableSkip/* = True*/)
		{
			//0x965CF8
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
		// RVA: 0x965920 Offset: 0x965920 VA: 0x965920 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layout = layout.FindViewById("sw_eme_anim") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
