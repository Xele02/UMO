using System;
using System.Collections;
using mcrs;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class StorySelectCompleteProduction : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_productionAnim; // 0x14

		// RVA: 0x12E4A0C Offset: 0x12E4A0C VA: 0x12E4A0C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_productionAnim = layout.FindViewByExId("root_story_comp_bg_sw_sel_story_last_anim") as AbsoluteLayout;
			Loaded();
			return true;
		}

		// RVA: 0x12E4AE4 Offset: 0x12E4AE4 VA: 0x12E4AE4
		public bool IsPlaying()
		{
			return m_productionAnim != null && m_productionAnim.IsPlayingChildren();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x72B6FC Offset: 0x72B6FC VA: 0x72B6FC
		// RVA: 0x12E4AFC Offset: 0x12E4AFC VA: 0x12E4AFC
		public IEnumerator CompleteProduction(Action completeStageIn)
		{
			//0x12E4BD0
			m_productionAnim.StartChildrenAnimGoStop("go_in", "st_in");
			SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_UNLOCK_001);
			while(IsPlaying())
				yield return null;
			m_productionAnim.StartChildrenAnimGoStop("logo_act", "loen_act");
			while(IsPlaying())
				yield return null;
			if(completeStageIn != null)
				completeStageIn();
			m_productionAnim.StartChildrenAnimGoStop("go_out", "st_out");
			while(IsPlaying())
				yield return null;
			yield return null;
		}
	}
}
