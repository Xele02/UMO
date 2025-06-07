using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System;
using System.Collections;
using CriWare;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class RaidResultRankingLayout : LayoutUGUIScriptBase
	{
		public Action onFinished; // 0x14
		public IEnumerator onCheckScoreUpdate; // 0x18
		public Action onClickButton; // 0x1C
		private DAFGPCEKAJB m_view; // 0x20
		private Matrix23 m_identity; // 0x24
		private Coroutine m_coroutine; // 0x3C
		private AbsoluteLayout m_layoutRoot; // 0x40
		private AbsoluteLayout m_layoutMain; // 0x44
		[SerializeField] // RVA: 0x67D20C Offset: 0x67D20C VA: 0x67D20C
		private Text m_rankText; // 0x48
		[SerializeField] // RVA: 0x67D21C Offset: 0x67D21C VA: 0x67D21C
		private Text m_damageText; // 0x4C
		private bool m_isSkiped; // 0x50
		private CriAtomExPlayback m_countUpSEPlayback; // 0x54

		// RVA: 0x1BE07E0 Offset: 0x1BE07E0 VA: 0x1BE07E0
		private void OnDisable()
		{
			if(SoundManager.Instance.sePlayerResultLoop.status != CriAtomSource.Status.Playing)
				return;
			SoundManager.Instance.sePlayerResultLoop.Stop();
		}

		// RVA: 0x1BE0884 Offset: 0x1BE0884 VA: 0x1BE0884 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewByExId("root_g_r_r_ranking_bc_sw_g_r_r_ranking_bc_inout_anim") as AbsoluteLayout;
			m_layoutMain = layout.FindViewByExId("sw_g_r_r_ranking_bc_inout_anim_sw_g_r_r_ranking_bc_count_anim") as AbsoluteLayout;
			Loaded();
			return true;
		}

		// // RVA: 0x1BDC5E0 Offset: 0x1BDC5E0 VA: 0x1BDC5E0
		public void Setup(DAFGPCEKAJB view)
		{
			m_view = view;
			m_damageText.text = view.AEIMNLACMFA_Damage.ToString();
			m_rankText.text = view.FJOLNJLLJEJ_Rank.ToString();
		}

		// // RVA: 0x1BDC878 Offset: 0x1BDC878 VA: 0x1BDC878
		public void SkipBeginAnim()
		{
			m_isSkiped = true;
			if(m_coroutine != null)
				return;
			StartBeginAnim();
		}

		// // RVA: 0x1BDCD34 Offset: 0x1BDCD34 VA: 0x1BDCD34
		public void StartBeginAnim()
		{
			m_coroutine = this.StartCoroutineWatched(Co_BeginAnim());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71FBB4 Offset: 0x71FBB4 VA: 0x71FBB4
		// // RVA: 0x1BE09D4 Offset: 0x1BE09D4 VA: 0x1BE09D4
		private IEnumerator Co_BeginAnim()
		{
			//0x1BE0DBC
			this.StartCoroutineWatched(Co_EnterTitle());
			yield return Co.R(Co_EnterRanking());
			if(onFinished != null)
				onFinished();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71FC2C Offset: 0x71FC2C VA: 0x71FC2C
		// // RVA: 0x1BE0A80 Offset: 0x1BE0A80 VA: 0x1BE0A80
		private IEnumerator Co_EnterTitle()
		{
			//0x1BE1100
			m_layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
			yield return Co.R(Co_WaitAnim(m_layoutRoot, false));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71FCA4 Offset: 0x71FCA4 VA: 0x71FCA4
		// // RVA: 0x1BE0B2C Offset: 0x1BE0B2C VA: 0x1BE0B2C
		private IEnumerator Co_EnterRanking()
		{
			//0x1BE0F30
			m_layoutMain.StartChildrenAnimGoStop("go_ranking", "st_ranking");
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_035);
			yield return Co.R(Co_WaitAnim(m_layoutMain, true));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71FD1C Offset: 0x71FD1C VA: 0x71FD1C
		// // RVA: 0x1BE0BD8 Offset: 0x1BE0BD8 VA: 0x1BE0BD8
		// private IEnumerator Co_WaitLabel(AbsoluteLayout layout, string label, bool enableSkip = True) { }

		// [IteratorStateMachineAttribute] // RVA: 0x71FD94 Offset: 0x71FD94 VA: 0x71FD94
		// // RVA: 0x1BE0CD0 Offset: 0x1BE0CD0 VA: 0x1BE0CD0
		private IEnumerator Co_WaitAnim(AbsoluteLayout layout, bool enableSkip/* = True*/)
		{
			//0x1BE1284
			while(layout.IsPlayingChildren())
			{
				if(!m_isSkiped || !enableSkip)
				{
					yield return null;
				}
				else
				{
					layout.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
					layout.Update(m_identity, Color.white);
				}
			}
		}
	}
}
