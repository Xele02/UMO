using System.Collections;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class RaidResultCannonDamageLayout : RaidResultEffectBaseLayout
	{

		// [IteratorStateMachineAttribute] // RVA: 0x71EC14 Offset: 0x71EC14 VA: 0x71EC14
		// // RVA: 0x1BD91A8 Offset: 0x1BD91A8 VA: 0x1BD91A8 Slot: 6
		public override IEnumerator StartAnime()
		{
			float maxWait; // 0x14
			float time; // 0x18
			bool skip; // 0x1C

			//0x1BD9738
			SoundResource.AddCueSheet(SoundManager.Instance.sePlayerGame.cueSheet);
			SoundManager.Instance.sePlayerGame.Play((int)mcrs.cs_se_game.SE_GAME_019);
			m_layoutRoot.StartChildrenAnimGoStop("go_act_01", "st_act_01");
			yield return Co.R(Co_WaitLabel(m_layoutRoot, "se", false));
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_019);
			yield return Co.R(Co_WaitAnim(m_layoutRoot, false));
			m_layoutRoot.StartChildrenAnimLoop("logo_act", "loen_act");
			time = 0;
			maxWait = 0;
			skip = false;
			while(true)
			{
				if(time < 1 || !skip)
					time += TimeWrapper.deltaTime;
				else
					time = maxWait;
				if(InputManager.Instance.GetInScreenTouchCount() > 0)
					skip = true;
				yield return null;
				if(maxWait <= time)
					break;
			}
			SoundResource.RemoveCueSheet(SoundManager.Instance.sePlayerGame.cueSheet);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71EC8C Offset: 0x71EC8C VA: 0x71EC8C
		// // RVA: 0x1BD9254 Offset: 0x1BD9254 VA: 0x1BD9254 Slot: 7
		public override IEnumerator EndAnime()
		{
			//0x1BD9464
			yield return new WaitForSeconds(0.3f);
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_WND_001);
			m_layoutRoot.StartChildrenAnimGoStop("go_act_02", "st_act_02");
			yield return Co.R(Co_WaitAnim(m_layoutRoot, false));
		}

		// RVA: 0x1BD9300 Offset: 0x1BD9300 VA: 0x1BD9300 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewByExId("root_g_r_r_damage_cc_sw_g_r_r_damage") as AbsoluteLayout;
			m_layoutRank = layout.FindViewByExId("raid_b_r_icon_base_set2_sw_raid_boss_rank") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
