using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutResultEvent03Telop : LayoutUGUIScriptBase
	{
		private AbsoluteLayout layoutRoot; // 0x14
		private AbsoluteLayout layoutBack; // 0x18
		private AbsoluteLayout layoutPoint; // 0x1C
		private NumberBase scorePoint; // 0x20
		private NumberBase scoreBonus; // 0x24
		private FJIPMALKCBG viewData; // 0x28
		private bool isSkiped; // 0x2C
		private Matrix23 identity; // 0x30

		// RVA: 0x18DA320 Offset: 0x18DA320 VA: 0x18DA320 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			layoutRoot = layout.FindViewById("sw_g_r_e3_win_anim") as AbsoluteLayout;
			layoutRoot.StartChildrenAnimGoStop("st_wait");
			layoutBack = layout.FindViewById("sw_g_r_e3_black_anim") as AbsoluteLayout;
			layoutBack.StartChildrenAnimGoStop("st_in");
			layoutPoint = layout.FindViewById("num_scr_ef") as AbsoluteLayout;
			layoutPoint.StartChildrenAnimGoStop("st_wait");
			List<NumberBase> numbers = new List<NumberBase>(GetComponentsInChildren<NumberBase>(true));
			scorePoint = numbers.Find((NumberBase _) =>
			{
				//0x18DAF18
				return _.name == "swnum_g_r_e3_num_scr (AbsoluteLayout)";
			});
			scoreBonus = numbers.Find((NumberBase _) =>
			{
				//0x18DAF98
				return _.name == "swnum_g_r_e3_num_scr_bonus (AbsoluteLayout)";
			});
			Loaded();
			return true;
		}

		// // RVA: 0x18DA7D8 Offset: 0x18DA7D8 VA: 0x18DA7D8
		public void Setup(FJIPMALKCBG viewData)
		{
			this.viewData = viewData;
			if(!viewData.GGOPOOLMLBA_IsPlayerWin)
			{
				layoutRoot.StartAnimGoStop("02");
				scorePoint.SetNumber(viewData.EKOCEKHBHLE_Rival.KNIFCANOHOC_ScorePoint, 0);
				scoreBonus.SetNumber(viewData.EKOCEKHBHLE_Rival.EACPIDGGPPO_Bonus, 0);
			}
			else
			{
				layoutRoot.StartAnimGoStop("01");
				scorePoint.SetNumber(viewData.HIHPPOFHMNF_Player.KNIFCANOHOC_ScorePoint, 0);
				scoreBonus.SetNumber(viewData.HIHPPOFHMNF_Player.EACPIDGGPPO_Bonus, 0);
			}
		}

		// // RVA: 0x18DA998 Offset: 0x18DA998 VA: 0x18DA998
		public void StartAnim(Action<int> onEndCallback)
		{
			this.StartCoroutineWatched(Co_PlayingStartPopupAnim(onEndCallback));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71BB74 Offset: 0x71BB74 VA: 0x71BB74
		// // RVA: 0x18DA9BC Offset: 0x18DA9BC VA: 0x18DA9BC
		private IEnumerator Co_PlayingStartPopupAnim(Action<int> onEndCallback)
		{
			//0x18DB01C
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_030);
			layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
			layoutBack.StartChildrenAnimGoStop("go_in", "st_in");
			yield return Co.R(Co_WaitLabel(layoutRoot, "go_act", false));
			yield return Co.R(Co_WaitFrame(layoutBack, layoutRoot.GetView(0).FrameAnimation.FrameCount, false));
			if(onEndCallback != null)
				onEndCallback(0);
			yield return Co.R(Co_WaitAnim(layoutRoot, true));
			if(onEndCallback != null)
				onEndCallback(1);
		}

		// // RVA: 0x18DAA84 Offset: 0x18DAA84 VA: 0x18DAA84
		public void LoopAnim()
		{
			layoutRoot.StartChildrenAnimLoop("logo_act", "loen_act");
			BKKMNPEEILG d = viewData.GGOPOOLMLBA_IsPlayerWin ? viewData.HIHPPOFHMNF_Player : viewData.EKOCEKHBHLE_Rival;
			if(d.NKLHOLHLEEI_ExcellentCount > 0)
			{
				layoutPoint.StartChildrenAnimLoop("logo_act", "loen_act");
			}
		}

		// // RVA: 0x18DABB8 Offset: 0x18DABB8 VA: 0x18DABB8
		public void SkipAnim()
		{
			isSkiped = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71BBEC Offset: 0x71BBEC VA: 0x71BBEC
		// // RVA: 0x18DABC4 Offset: 0x18DABC4 VA: 0x18DABC4
		private IEnumerator Co_WaitLabel(AbsoluteLayout layout, string label, bool enableSkip/* = True*/)
		{
			//0x18DB720
			while((!isSkiped || !enableSkip) && layout.GetView(0).FrameAnimation.FrameCount < (int)layout.GetView(0).FrameAnimation.SearchLabelFrame(label))
			{
				yield return null;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71BC64 Offset: 0x71BC64 VA: 0x71BC64
		// // RVA: 0x18DACBC Offset: 0x18DACBC VA: 0x18DACBC
		private IEnumerator Co_WaitFrame(AbsoluteLayout layout, int frame, bool enableSkip/* = True*/)
		{
			//0x18DB5B0
			while((!isSkiped || !enableSkip) && layout.GetView(0).FrameAnimation.FrameCount < frame)
			{
				yield return null;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71BCDC Offset: 0x71BCDC VA: 0x71BCDC
		// // RVA: 0x18DADB4 Offset: 0x18DADB4 VA: 0x18DADB4
		private IEnumerator Co_WaitAnim(AbsoluteLayout layout, bool enableSkip/* = True*/)
		{
			//0x18DB3AC
			while(layout.IsPlayingChildren())
			{
				if(!isSkiped || !enableSkip)
					yield return null;
				else
				{
					layout.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
					layout.UpdateAll(identity, Color.white);
				}
			}
		}
	}
}
