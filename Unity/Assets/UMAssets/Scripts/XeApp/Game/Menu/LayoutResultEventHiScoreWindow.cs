using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using System;
using XeSys;
using System.Text;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class LayoutResultEventHiScoreWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_image_jacket; // 0x14
		[SerializeField]
		private Text m_text_episode; // 0x18
		[SerializeField]
		private Text m_text_episode_rate; // 0x1C
		[SerializeField]
		private Text m_text_rank; // 0x20
		[SerializeField]
		private ActionButton m_btn_ok; // 0x24
		[SerializeField]
		private NumberBase m_Number01; // 0x28
		[SerializeField]
		private NumberBase m_Number02; // 0x2C
		[SerializeField]
		private NumberBase m_Number03; // 0x30
		private AbsoluteLayout m_Anime_Root; // 0x34
		private AbsoluteLayout m_Anime_NewRecode; // 0x38
		private AbsoluteLayout m_Anime_EpisodeUp; // 0x3C
		private bool m_is_anim_new_recode; // 0x40
		private bool m_is_anim_episode_up; // 0x41
		private bool m_isJacket; // 0x42
		private bool m_isSetup; // 0x43
		private bool m_isOpen; // 0x44
		public Action m_OnOpen; // 0x48
		public Action m_OnClose; // 0x4C
		// private GCODMEIACDE m_view_data; // 0x50

		// RVA: 0x18DB904 Offset: 0x18DB904 VA: 0x18DB904
		public void Setup(JLCHNKIHGHK data)
		{
			m_isJacket = false;
			m_isSetup = false;
			m_Number01.SetNumber(0, 0);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			StringBuilder str = new StringBuilder();
			str.SetFormatSmart(bk.GetMessageByLabel("event_result_episode"), data.LIPIAPOGHIP_EpisodeBonus);
			m_text_episode.text = str.ToString();
			m_text_episode_rate.text = (data.PFJMBKBEFMA_EpisodeRate - 100).ToString();
			m_is_anim_episode_up = data.PFJMBKBEFMA_EpisodeRate - 100 > 0;
			m_Number01.SetNumber(data.KNIFCANOHOC_ScorePoint, 0);
			m_Number02.SetNumber(data.LMBFJMBIIGN, 0);
			m_Number03.SetNumber(data.JLIKEOKBBAM_HighScore, 0);
			m_is_anim_new_recode = data.FFHMPNGJCLK_NewRecode;
			if(data.HGHEENFMKGH_ScoreRanking == 0)
			{
				m_text_rank.text = JpStringLiterals.StringLiteral_6527;
			}
			else
			{
				m_text_rank.text = data.HGHEENFMKGH_ScoreRanking.ToString();
			}
			MenuScene.Instance.MusicJacketTextureCache.Load(data.JNCPEGJGHOG_JacketId, (IiconTexture texture) =>
			{
				//0x18DC788
				texture.Set(m_image_jacket);
				m_isJacket = true;
			});
			m_isJacket = true;
			m_isSetup = true;
		}

		// // RVA: 0x18DBD1C Offset: 0x18DBD1C VA: 0x18DBD1C
		// public void Setup(GCODMEIACDE data) { }

		// // RVA: 0x18DC210 Offset: 0x18DC210 VA: 0x18DC210
		public bool IsSetup()
		{
			return m_isJacket && m_isSetup;
		}

		// // RVA: 0x18DC230 Offset: 0x18DC230 VA: 0x18DC230
		public bool IsOpen()
		{
			return m_isOpen;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71BE94 Offset: 0x71BE94 VA: 0x71BE94
		// // RVA: 0x18DC238 Offset: 0x18DC238 VA: 0x18DC238
		public IEnumerator Co_PlayAnimOpen(int a_open_se/* = 0*/)
		{
			//0x18DCC30
			m_isOpen = true;
			if(m_OnOpen != null)
				m_OnOpen();
			if(m_Anime_EpisodeUp != null)
				m_Anime_EpisodeUp.StartChildrenAnimGoStop(m_is_anim_episode_up ? 0 : 1, m_is_anim_episode_up ? 0 : 1);
			if(m_Anime_NewRecode != null)
				m_Anime_NewRecode.StartChildrenAnimGoStop(m_is_anim_new_recode ? 0 : 1, m_is_anim_new_recode ? 0 : 1);
			m_Anime_Root.StartChildrenAnimGoStop("go_in", "st_in");
			yield return null;
			yield return new WaitWhile(() =>
			{
				//0x18DC958
				return m_Anime_Root.IsPlayingChildren();
			});
			SoundManager.Instance.sePlayerBoot.Play(a_open_se == 1 ? (int)mcrs.cs_se_boot.SE_WND_004 : (int)mcrs.cs_se_boot.SE_WND_000);
			m_btn_ok.IsInputOff = false;
			GameManager.Instance.AddPushBackButtonHandler(OnClickButton_BackKey);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71BF0C Offset: 0x71BF0C VA: 0x71BF0C
		// // RVA: 0x18DC300 Offset: 0x18DC300 VA: 0x18DC300
		private IEnumerator Co_PlayAnimClose()
		{
			//0x18DC9B4
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_WND_001);
			m_Anime_Root.StartChildrenAnimGoStop("go_out", "st_out");
			yield return null;
			yield return new WaitWhile(() =>
			{
				//0x18DC984
				return m_Anime_Root.IsPlayingChildren();
			});
			if(m_OnClose != null)
				m_OnClose();
			m_isOpen = false;
		}

		// RVA: 0x18DC3AC Offset: 0x18DC3AC VA: 0x18DC3AC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_Anime_Root = layout.FindViewById("sw_game_res_event01_rank_inout_anim") as AbsoluteLayout;
			m_Anime_NewRecode = layout.FindViewById("swtbl_g_r_e_newrec") as AbsoluteLayout;
			m_Anime_EpisodeUp = layout.FindViewById("swtbl_up") as AbsoluteLayout;
			m_btn_ok.AddOnClickCallback(OnClickButton_CloseWindow);
			return true;
		}

		// // RVA: 0x18DC5C4 Offset: 0x18DC5C4 VA: 0x18DC5C4
		private void OnClickButton_CloseWindow()
		{
			m_btn_ok.IsInputOff = true;
			GameManager.Instance.RemovePushBackButtonHandler(OnClickButton_BackKey);
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			this.StartCoroutineWatched(Co_PlayAnimClose());
		}

		// // RVA: 0x18DC728 Offset: 0x18DC728 VA: 0x18DC728
		private void OnClickButton_BackKey()
		{
			if(m_btn_ok.IsInputOff)
				return;
			m_btn_ok.PerformClick();
		}

		// [CompilerGeneratedAttribute] // RVA: 0x71BF94 Offset: 0x71BF94 VA: 0x71BF94
		// // RVA: 0x18DC870 Offset: 0x18DC870 VA: 0x18DC870
		// private void <Setup>b__20_0(IiconTexture texture) { }
	}
}
