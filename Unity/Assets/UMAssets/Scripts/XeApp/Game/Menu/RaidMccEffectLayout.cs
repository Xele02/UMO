using System;
using System.Collections;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class RaidMccEffectLayout : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_mainAnimLayout; // 0x14

		// RVA: 0x1BD1F2C Offset: 0x1BD1F2C VA: 0x1BD1F2C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_mainAnimLayout = layout.FindViewByExId("root_sel_music_raid_mcc_ef_bc_sw_s_m_r_mcc_ef_set2_anim") as AbsoluteLayout;
			return true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7124BC Offset: 0x7124BC VA: 0x7124BC
		// RVA: 0x1BD1FF8 Offset: 0x1BD1FF8 VA: 0x1BD1FF8
		public IEnumerator Co_StartAddGaugeAnim(Action callback)
		{
			//0x1BD21A4
			m_mainAnimLayout.StartChildrenAnimGoStop("go_act", "st_act");
			while(m_mainAnimLayout.IsPlayingChildren())
			{
				if(MenuScene.Instance.IsTransition())
				{
					Stop();
					yield break;
				}
				yield return null;
			}
			Hide();
			callback();
		}

		// RVA: 0x1BD20C0 Offset: 0x1BD20C0 VA: 0x1BD20C0
		public void Hide()
		{
			m_mainAnimLayout.StartChildrenAnimGoStop("st_wait", "st_wait");
		}

		// // RVA: 0x1BD2140 Offset: 0x1BD2140 VA: 0x1BD2140
		public void Stop()
		{
			m_mainAnimLayout.StopAllAnim();
		}

		// // RVA: 0x1BD216C Offset: 0x1BD216C VA: 0x1BD216C
		public bool IsPlaying()
		{
			return m_mainAnimLayout.IsPlayingChildren();
		}
	}
}
