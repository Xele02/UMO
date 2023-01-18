using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using System;
using System.Linq;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class LayoutResultMusicInfo : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx[] diffImages = new RawImageEx[5]; // 0x14
		private AbsoluteLayout layoutRootAnim; // 0x18
		private AbsoluteLayout layoutDifficulty; // 0x1C
		private AbsoluteLayout layoutAttribute; // 0x20
		private AbsoluteLayout layoutMusicBar; // 0x24
		private AbsoluteLayout layoutRateTotalText; // 0x28
		private AbsoluteLayout layoutRateText; // 0x2C
		private AbsoluteLayout layoutRateRankIn; // 0x30
		private AbsoluteLayout layoutRateRankingNum; // 0x34
		private AbsoluteLayout layoutRateRankingEff; // 0x38
		private Text textMusicName; // 0x3C
		private Text textSingRateBefore; // 0x40
		private Text textSingRankBefore; // 0x44
		private RawImageEx imageSingRank; // 0x48
		private RawImageEx imageMusicJacket; // 0x4C
		private RawImageEx[] imageSingRankBg; // 0x50
		private NumberBase[] numSingRateAfter; // 0x54
		private NumberBase[] numSingRankAfter; // 0x58
		private TexUVListManager m_uvMan; // 0x5C
		private ActionButton singRateInfoBtn; // 0x60
		private NGJOPPIGCPM_ResultData viewResultData; // 0x64
		public Action onFinished; // 0x68
		private Coroutine m_coroutine; // 0x6C
		private bool isSkiped; // 0x70
		private static readonly string[] DiffTexTable = new string[5]
		{
			"cmn_music_diff_01", "cmn_music_diff_02", "cmn_music_diff_03", 
			"cmn_music_diff_04", "cmn_music_diff_05"
		}; // 0x0
		private static readonly string[] DiffTexTable_6Line = new string[3]
		{
			"cmn_music_diff_06", "cmn_music_diff_07", "cmn_music_diff_08"
		}; // 0x4

		// private bool isInTutorial { get; } 0x18E0140

		// RVA: 0x18E0218 Offset: 0x18E0218 VA: 0x18E0218 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_uvMan = uvMan;
			layoutRootAnim = layout.FindViewById("sw_music_bar_anim") as AbsoluteLayout;
			layoutDifficulty = layout.FindViewById("swtbl_diff") as AbsoluteLayout;
			layoutAttribute = layout.FindViewById("swtbl_zok") as AbsoluteLayout;
			layoutMusicBar = layout.FindViewById("sw_music_bar") as AbsoluteLayout;
			layoutRateTotalText = layout.FindViewById("sw_rate_num_total_up_anim") as AbsoluteLayout;
			layoutRateText = layout.FindViewById("sw_rate_num_up_anim") as AbsoluteLayout;
			layoutRateRankIn = layout.FindViewById("sw_rate_rank_in_anim") as AbsoluteLayout;
			layoutRateRankingNum = layout.FindViewById("sw_g_r_rankin") as AbsoluteLayout;
			layoutRateRankingEff = layout.FindViewById("sw_g_r_rankin_ef") as AbsoluteLayout;
			Transform t = transform.Find("sw_music_bar_anim (AbsoluteLayout)/sw_music_bar (AbsoluteLayout)");
			textMusicName = t.Find("title_fnt (AbsoluteLayout)/titletxt (TextView)").GetComponent<Text>();
			textSingRateBefore = t.Find("sw_rate_num_up_anim (AbsoluteLayout)/rate_txt_01 (AbsoluteLayout)/rate_txt_03 (TextView)").GetComponent<Text>();
			textSingRankBefore = t.Find("sw_rate_num_total_up_anim (AbsoluteLayout)/rate_txt_01 (AbsoluteLayout)/rate_txt_03 (TextView)").GetComponent<Text>();
			numSingRateAfter = new NumberBase[2];
			numSingRateAfter[0]= t.Find("sw_rate_num_up_anim (AbsoluteLayout)/swnum_g_r_num (AbsoluteLayout)").GetComponent<NumberBase>();
			numSingRateAfter[1]= t.Find("sw_rate_num_up_anim (AbsoluteLayout)/swnum_g_r_num_ef (AbsoluteLayout)").GetComponent<NumberBase>();
			numSingRankAfter = new NumberBase[2];
			numSingRankAfter[0]= t.Find("sw_rate_num_total_up_anim (AbsoluteLayout)/swnum_g_r_num (AbsoluteLayout)").GetComponent<NumberBase>();
			numSingRankAfter[1]= t.Find("sw_rate_num_total_up_anim (AbsoluteLayout)/swnum_g_r_num_ef (AbsoluteLayout)").GetComponent<NumberBase>();
			RawImageEx[] rs = GetComponentsInChildren<RawImageEx>(true);
			imageSingRank = rs.Where((RawImageEx _) => {
				//0x18E2ED4
				return _.name == "cmn_musicrate (ImageView)";
			}).First();
			imageMusicJacket = rs.Where((RawImageEx _) => {
				//0x18E2F54
				return _.name == "swtexc_cmn_cd (ImageView)";
			}).First();
			imageSingRankBg = rs.Where((RawImageEx _) => {
				//0x18E2FD4
				return _.name == "g_r_rankin_bg (ImageView)";
			}).ToArray();
			singRateInfoBtn = t.Find("sw_rate_num_total_up_anim (AbsoluteLayout)/sw_g_r_btn_rate_anim (AbsoluteLayout)").GetComponent<ActionButton>();
			singRateInfoBtn.AddOnClickCallback(() => {
				//0x18E2E54
				OnClickSingRankInfoBtn();
			});
			Loaded();
			return true;
		}

		// // RVA: 0x18E0F4C Offset: 0x18E0F4C VA: 0x18E0F4C
		// public void Setup(NGJOPPIGCPM view_data, int diff, bool isLine6Mode) { }

		// // RVA: 0x18E1ADC Offset: 0x18E1ADC VA: 0x18E1ADC
		// private void SetRankingUV(NGJOPPIGCPM.DFJMELLLNLH rankState) { }

		// // RVA: 0x18E1C74 Offset: 0x18E1C74 VA: 0x18E1C74
		public void StartBeginAnim()
		{
			layoutRootAnim.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0x18E1D00 Offset: 0x18E1D00 VA: 0x18E1D00
		// public void StartEndAnim() { }

		// // RVA: 0x18E1D8C Offset: 0x18E1D8C VA: 0x18E1D8C
		// public void StartAlreadyAnim() { }

		// // RVA: 0x18E1E08 Offset: 0x18E1E08 VA: 0x18E1E08
		public void StartSingRankUpAnim()
		{
			m_coroutine = StartCoroutine(Co_StartSingRankUpAnim());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71C13C Offset: 0x71C13C VA: 0x71C13C
		// // RVA: 0x18E1E30 Offset: 0x18E1E30 VA: 0x18E1E30
		private IEnumerator Co_StartSingRankUpAnim()
		{
			Coroutine coRank; // 0x14
			Coroutine coRankTotal; // 0x18

			//0x18E4074
			TodoLogger.Log(0, "Co_StartSingRankUpAnim");

			yield return null;
			if(onFinished != null)
				onFinished();
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71C1B4 Offset: 0x71C1B4 VA: 0x71C1B4
		// // RVA: 0x18E1EDC Offset: 0x18E1EDC VA: 0x18E1EDC
		// private IEnumerator Co_AnimRankIn() { }

		// [IteratorStateMachineAttribute] // RVA: 0x71C22C Offset: 0x71C22C VA: 0x71C22C
		// // RVA: 0x18E1F88 Offset: 0x18E1F88 VA: 0x18E1F88
		// private IEnumerator Co_AnimRankUp() { }

		// [IteratorStateMachineAttribute] // RVA: 0x71C2A4 Offset: 0x71C2A4 VA: 0x71C2A4
		// // RVA: 0x18E2034 Offset: 0x18E2034 VA: 0x18E2034
		// private IEnumerator Co_AnimRankTotalIn() { }

		// [IteratorStateMachineAttribute] // RVA: 0x71C31C Offset: 0x71C31C VA: 0x71C31C
		// // RVA: 0x18E20E0 Offset: 0x18E20E0 VA: 0x18E20E0
		// private IEnumerator Co_AnimRankTotalUp() { }

		// [IteratorStateMachineAttribute] // RVA: 0x71C394 Offset: 0x71C394 VA: 0x71C394
		// // RVA: 0x18E218C Offset: 0x18E218C VA: 0x18E218C
		// private IEnumerator Co_UpdataUtarateRanking() { }

		// [IteratorStateMachineAttribute] // RVA: 0x71C40C Offset: 0x71C40C VA: 0x71C40C
		// // RVA: 0x18E2238 Offset: 0x18E2238 VA: 0x18E2238
		// private IEnumerator Co_GetCurrentRank() { }

		// // RVA: 0x18E22E4 Offset: 0x18E22E4 VA: 0x18E22E4
		public void SkipAnim()
		{
			isSkiped = true;
			if(m_coroutine != null)
				return;
			m_coroutine = StartCoroutine(Co_StartSingRankUpAnim());
		}

		// // RVA: 0x18E2324 Offset: 0x18E2324 VA: 0x18E2324
		public void SetActiveSingRank(bool active)
		{
			imageSingRank.enabled = active;
		}

		// // RVA: 0x18E19CC Offset: 0x18E19CC VA: 0x18E19CC
		// private void StartLoadMusicJacket(int id) { }

		// // RVA: 0x18E2358 Offset: 0x18E2358 VA: 0x18E2358
		// private void OnLoadedMusicJacket(IiconTexture iconTexture) { }

		// // RVA: 0x18E2438 Offset: 0x18E2438 VA: 0x18E2438
		private void OnClickSingRankInfoBtn()
		{
			TodoLogger.LogNotImplemented("OnClickSingRankInfoBtn");
		}
	}
}
