using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System;
using CriWare;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class LayoutResultDivaPoint : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_layout_root; // 0x14
		private AbsoluteLayout m_layout_score_anim; // 0x18
		private AbsoluteLayout m_layout_diff_type; // 0x1C
		private AbsoluteLayout m_layout_frame_loop_1; // 0x20
		private AbsoluteLayout m_layout_frame_loop_2; // 0x24
		private Action m_updater; // 0x28
		[SerializeField]
		private NumberBase[] m_total_point; // 0x2C
		[SerializeField]
		private NumberBase m_diff_point; // 0x30
		[SerializeField]
		private NumberBase m_score_point; // 0x34
		[SerializeField]
		private NumberBase m_score_magnification; // 0x38
		[SerializeField]
		private Text m_music_name; // 0x3C
		[SerializeField]
		private RawImageEx m_music_cd_image; // 0x40
		private float COUNT_POINT_TIME = 0.5f; // 0x44
		private GNIFOHMFDMO_DivaResultData viewResultDivaData; // 0x48
		private CriAtomExPlayback countScoreSEPlayback; // 0x4C
		private bool m_is_open_window; // 0x50
		private Coroutine m_coroutine; // 0x54
		private bool m_isLoadingImage; // 0x58

		// RVA: 0x1D8B100 Offset: 0x1D8B100 VA: 0x1D8B100 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layout_root = layout.FindViewById("sw_res_juku_p_anim") as AbsoluteLayout;
			m_layout_diff_type = layout.FindViewById("swtbl_g_r_fnt_dif") as AbsoluteLayout;
			m_layout_frame_loop_1 = layout.FindViewByExId("sw_res_juku_p_anim_g_r_juku_p_pop_eff_01_1") as AbsoluteLayout;
			m_layout_frame_loop_1.StartChildrenAnimLoop("logo", "loen");
			m_layout_frame_loop_2 = layout.FindViewByExId("sw_res_juku_p_anim_g_r_juku_p_pop_eff_01_2") as AbsoluteLayout;
			m_layout_frame_loop_2.StartChildrenAnimLoop("logo", "loen");
			m_layout_score_anim = layout.FindViewByExId("sw_juku_num_anim_set_sw_juku_num_anim_1") as AbsoluteLayout;
			m_layout_score_anim.StartChildrenAnimGoStop("st_non", "st_non");
			return true;
		}

		// RVA: 0x1D8B454 Offset: 0x1D8B454 VA: 0x1D8B454
		private void Update()
		{
			GameManager.Instance.MusicJacketTextureCache.Update();
		}

		//// RVA: 0x1D8B510 Offset: 0x1D8B510 VA: 0x1D8B510
		public void Skip()
		{
			if(m_coroutine != null)
			{
				StopCoroutine(m_coroutine);
			}
			m_is_open_window = false;
			countScoreSEPlayback.Stop();
			m_layout_root.StartChildrenAnimGoStop("st_out", "st_out");
			m_layout_score_anim.StartChildrenAnimGoStop("st_out", "st_out");
			SetTotalScore(viewResultDivaData.BMGKGDPKJFA_Point);
		}

		//// RVA: 0x1D8B6C0 Offset: 0x1D8B6C0 VA: 0x1D8B6C0
		//private void UpdateIdle() { }

		//// RVA: 0x1D8B6C4 Offset: 0x1D8B6C4 VA: 0x1D8B6C4
		public void StartBeginAnim()
		{
			m_is_open_window = true;
			m_coroutine = this.StartCoroutineWatched(Co_StartCount());
		}

		//// RVA: 0x1D8B784 Offset: 0x1D8B784 VA: 0x1D8B784
		public void Setup(GNIFOHMFDMO_DivaResultData viewResultDivaData)
		{
			this.viewResultDivaData = viewResultDivaData;
			m_diff_point.SetNumber(viewResultDivaData.OGFBKCGGPBC_DiffPoint, 0);
			m_score_point.SetNumber(viewResultDivaData.GCAPLLEIAAI_LastScore, 0);
			m_score_magnification.SetNumber(viewResultDivaData.FFEBMCAKOHK - 100, 0);
			SetTotalScore(0);
			int a = viewResultDivaData.LFGNLKKFOCD_Is6Line ? viewResultDivaData.AKNELONELJK + 3 : viewResultDivaData.AKNELONELJK;
			m_layout_diff_type.StartChildrenAnimGoStop(a, a);
			m_layout_score_anim.StartChildrenAnimGoStop("st_non", "st_non");
			m_is_open_window = false;
			EEDKAACNBBG_MusicData mdata = new EEDKAACNBBG_MusicData();
			mdata.KHEKNNFCAOI(viewResultDivaData.DLAEJOBELBH_MusicId);
			m_music_name.text = mdata.NEDBBJDAFBH_MusicName;
			m_music_name.horizontalOverflow = HorizontalWrapMode.Wrap;
			m_music_name.verticalOverflow = VerticalWrapMode.Truncate;
			SetCD(mdata.JNCPEGJGHOG_JacketId);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7186D4 Offset: 0x7186D4 VA: 0x7186D4
		//// RVA: 0x1D8B6F8 Offset: 0x1D8B6F8 VA: 0x1D8B6F8
		private IEnumerator Co_StartCount()
		{
			//0x1D8D448
			while (m_isLoadingImage)
				yield return null;
			yield return this.StartCoroutineWatched(Co_EnterAnim());
			yield return this.StartCoroutineWatched(Co_EnterDiffAnim());
			yield return this.StartCoroutineWatched(Co_EnterTotalScoreAnim());
			yield return this.StartCoroutineWatched(Co_CountTotalPoint(0, viewResultDivaData.OGFBKCGGPBC_DiffPoint, COUNT_POINT_TIME));
			yield return new WaitForSeconds(0.5f);
			yield return this.StartCoroutineWatched(Co_EnterScoreAnim());
			yield return this.StartCoroutineWatched(Co_CountTotalPoint(viewResultDivaData.OGFBKCGGPBC_DiffPoint, viewResultDivaData.BMGKGDPKJFA_Point, COUNT_POINT_TIME));
			yield return this.StartCoroutineWatched(Co_EffectTotalScoreAnim());
			yield return new WaitForSeconds(0.5f);
			yield return this.StartCoroutineWatched(Co_LeaveAnim());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x71874C Offset: 0x71874C VA: 0x71874C
		//// RVA: 0x1D8BB2C Offset: 0x1D8BB2C VA: 0x1D8BB2C
		private IEnumerator Co_EnterAnim()
		{
			//0x1D8C92C
			SoundManager.Instance.sePlayerResult.Play(25);
			m_layout_root.StartChildrenAnimGoStop("go_in", "st_in");
			yield return null;
			yield return new WaitWhile(() =>
			{
				//0x1D8C0B0
				return m_layout_root.IsPlayingChildren();
			});
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7187C4 Offset: 0x7187C4 VA: 0x7187C4
		//// RVA: 0x1D8BBD8 Offset: 0x1D8BBD8 VA: 0x1D8BBD8
		private IEnumerator Co_EnterDiffAnim()
		{
			//0x1D8CB70
			SoundManager.Instance.sePlayerResult.Play(26);
			m_layout_root.StartChildrenAnimGoStop("go_difficulty", "st_difficulty");
			yield return null;
			yield return new WaitWhile(() =>
			{
				//0x1D8C0DC
				return m_layout_root.IsPlayingChildren();
			});
		}

		//[IteratorStateMachineAttribute] // RVA: 0x71883C Offset: 0x71883C VA: 0x71883C
		//// RVA: 0x1D8BC84 Offset: 0x1D8BC84 VA: 0x1D8BC84
		private IEnumerator Co_EnterScoreAnim()
		{
			//0x1D8CDB4
			SoundManager.Instance.sePlayerResult.Play(26);
			m_layout_root.StartChildrenAnimGoStop("go_score", "st_score");
			yield return null;
			yield return new WaitWhile(() =>
			{
				//0x1D8C108
				return m_layout_root.IsPlayingChildren();
			});
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7188B4 Offset: 0x7188B4 VA: 0x7188B4
		//// RVA: 0x1D8BD30 Offset: 0x1D8BD30 VA: 0x1D8BD30
		private IEnumerator Co_LeaveAnim()
		{
			//0x1D8D1F0
			m_is_open_window = false;
			m_layout_root.StartChildrenAnimGoStop("go_out", "st_out");
			m_layout_score_anim.StartChildrenAnimGoStop("go_out", "st_out");
			yield return null;
			yield return new WaitWhile(() =>
			{
				//0x1D8C134
				return m_layout_root.IsPlayingChildren() || m_layout_score_anim.IsPlayingChildren();
			});
		}

		//[IteratorStateMachineAttribute] // RVA: 0x71892C Offset: 0x71892C VA: 0x71892C
		//// RVA: 0x1D8BDDC Offset: 0x1D8BDDC VA: 0x1D8BDDC
		private IEnumerator Co_EnterTotalScoreAnim()
		{
			//0x1D8CFF8
			m_layout_score_anim.StartChildrenAnimGoStop("go_in", "st_in");
			yield return null;
			yield return new WaitWhile(() =>
			{
				//0x1D8C190
				return m_layout_score_anim.IsPlayingChildren();
			});
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7189A4 Offset: 0x7189A4 VA: 0x7189A4
		//// RVA: 0x1D8BE88 Offset: 0x1D8BE88 VA: 0x1D8BE88
		private IEnumerator Co_EffectTotalScoreAnim()
		{
			//0x1D8C734
			m_layout_score_anim.StartChildrenAnimGoStop("go_eff", "st_eff");
			yield return null;
			yield return new WaitWhile(() =>
			{
				//0x1D8C1BC
				return m_layout_score_anim.IsPlayingChildren();
			});
		}

		//[IteratorStateMachineAttribute] // RVA: 0x718A1C Offset: 0x718A1C VA: 0x718A1C
		//// RVA: 0x1D8BF34 Offset: 0x1D8BF34 VA: 0x1D8BF34
		private IEnumerator Co_CountTotalPoint(int start, int end, float sec)
		{
			//0x1D8C3FC
			if(start < end)
			{
				PlayScoreCountSE();
			}
			float elapsed = 0;
			yield return new WaitWhile(() =>
			{
				//0x1D8C2D8
				float r = elapsed / sec;
				int val = Mathf.RoundToInt(Mathf.Lerp(start, end, r));
				SetTotalScore(val);
				elapsed += Time.deltaTime;
				return r < 1;
			});
			countScoreSEPlayback.Stop();
			SetTotalScore(end);
			SoundManager.Instance.sePlayerResult.Play(27);
		}

		//// RVA: 0x1D8B61C Offset: 0x1D8B61C VA: 0x1D8B61C
		private void SetTotalScore(int score)
		{
			for(int i = 0; i < m_total_point.Length; i++)
			{
				m_total_point[i].SetNumber(score, 0);
			}
		}

		//// RVA: 0x1D8C038 Offset: 0x1D8C038 VA: 0x1D8C038
		private void PlayScoreCountSE()
		{
			countScoreSEPlayback = SoundManager.Instance.sePlayerResult.Play(0);
		}

		//// RVA: 0x1D8B610 Offset: 0x1D8B610 VA: 0x1D8B610
		//private void StopScoreCountSE() { }

		//// RVA: 0x1D8B9F4 Offset: 0x1D8B9F4 VA: 0x1D8B9F4
		public void SetCD(int coverId)
		{
			m_isLoadingImage = true;
			GameManager.Instance.MusicJacketTextureCache.Load(coverId, (IiconTexture icon) =>
			{
				//0x1D8C1E8
				icon.Set(m_music_cd_image);
				m_isLoadingImage = false;
			});
		}

		//// RVA: 0x1D8C098 Offset: 0x1D8C098 VA: 0x1D8C098
		public bool IsOpenWindow()
		{
			return m_is_open_window;
		}
	}
}
