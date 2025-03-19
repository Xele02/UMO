using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CriWare;
using UnityEngine;
using UnityEngine.Localization.SmartFormat;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutResultEvent03Point : LayoutUGUIScriptBase
	{
		public Action onFinished; // 0x14
		public IEnumerator onCheckScoreUpdate; // 0x18
		public Action onClickButton; // 0x1C
		private GJOOGLGLFID m_view; // 0x20
		private List<EMGOCNMMPHC> m_list; // 0x24
		private AbsoluteLayout m_layoutRoot; // 0x28
		private AbsoluteLayout m_layoutMain; // 0x2C
		private AbsoluteLayout m_layoutTitle; // 0x30
		private AbsoluteLayout m_layoutWinResult; // 0x34
		private AbsoluteLayout m_layoutWinBonus; // 0x38
		private AbsoluteLayout m_layoutExRival; // 0x3C
		private AbsoluteLayout[] m_layoutRank = new AbsoluteLayout[2]; // 0x40
		private AbsoluteLayout[] m_layoutDash = new AbsoluteLayout[2]; // 0x44
		private AbsoluteLayout[] m_layoutUp = new AbsoluteLayout[2]; // 0x48
		private Text m_textClassRank; // 0x4C
		private Text m_textWinResult; // 0x50
		private Text m_textLoseResult; // 0x54
		private Text m_textWinLosePoint; // 0x58
		private RawImageEx m_imageDiff; // 0x5C
		private Rect[] m_imageDiffRectList = new Rect[5]; // 0x60
		private Rect[] m_imageDiffRectList_6Line; // 0x64
		private Text m_textDiffBonus; // 0x68
		private NumberBase m_ScorePoint; // 0x6C
		private Text m_ScoreBonusText; // 0x70
		private Text m_textEpisodeCount; // 0x74
		private Text m_textEpisodeRate; // 0x78
		private Text[] m_textPoint; // 0x7C
		private Text m_textTotal; // 0x80
		private Text[] m_textDashBonus; // 0x84
		private Text m_textMedalNum; // 0x88
		private RawImageEx m_imageMedal; // 0x8C
		private NumberBase m_RankNum; // 0x90
		private Text m_textWinBonus; // 0x94
		private Text m_textLoseBonus; // 0x98
		private Text m_textExBonus; // 0x9C
		private Text m_textExPoint; // 0xA0
		private Text m_textExHiScore; // 0xA4
		private Text m_textExRanking; // 0xA8
		private RawImageEx[] m_imageJacket = new RawImageEx[3]; // 0xAC
		private ActionButton m_button; // 0xB0
		private LayoutBattleExGauge m_layoutGauge; // 0xB4
		private Matrix23 m_identity; // 0xB8
		private Coroutine m_coroutine; // 0xD0
		private bool m_isSkiped; // 0xD4
		private bool m_isLoading; // 0xD5
		private CriAtomExPlayback m_countUpSEPlayback; // 0xD8

		// RVA: 0x1DA0510 Offset: 0x1DA0510 VA: 0x1DA0510
		private void Start()
		{
			return;
		}

		// RVA: 0x1DA0514 Offset: 0x1DA0514 VA: 0x1DA0514
		private void Update()
		{
			return;
		}

		// RVA: 0x1DA0518 Offset: 0x1DA0518 VA: 0x1DA0518
		private void OnDisable()
		{
			SoundManager.Instance.sePlayerResultLoop.Stop();
		}

		// RVA: 0x1DA056C Offset: 0x1DA056C VA: 0x1DA056C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewById("sw_game_res_event03_pt_count_inout_anim") as AbsoluteLayout;
			m_layoutMain = layout.FindViewById("sw_game_res_event03_pt_count_anim") as AbsoluteLayout;
			m_layoutTitle = layout.FindViewById("sw_g_r_event_title_anim") as AbsoluteLayout;
			m_layoutWinResult = layout.FindViewById("swtbl_fnt_win_lose") as AbsoluteLayout;
			m_layoutWinBonus = layout.FindViewByExId("swtbl_rival_ex_swtbl_rival_win_lose") as AbsoluteLayout;
			m_layoutExRival = layout.FindViewByExId("sw_game_res_event03_pt_count_anim_swtbl_rival_win_lose") as AbsoluteLayout;
			m_layoutRank[0] = layout.FindViewByExId("sw_game_res_event03_pt_count_anim_g_r_e3_rival_ex") as AbsoluteLayout;
			m_layoutRank[1] = layout.FindViewById("swtbl_g_r_e3_rival") as AbsoluteLayout;
			m_layoutDash[0] = layout.FindViewById("swtbl_dash") as AbsoluteLayout;
			m_layoutDash[1] = (layout.FindViewById("sw_get_medal") as AbsoluteLayout).FindViewById("swtbl_dash") as AbsoluteLayout;
			m_layoutUp[0] = layout.FindViewById("swtbl_up") as AbsoluteLayout;
			m_layoutUp[1] = layout.FindViewById("swtbl_up_2") as AbsoluteLayout;
			m_layoutGauge = GetComponentInChildren<LayoutBattleExGauge>(true);
			m_layoutGauge.layoutMain = layout.FindViewById("g_r_e3_ga_base") as AbsoluteLayout;
			m_layoutGauge.layoutDiff = layout.FindViewById("sw_ga_plus_anim") as AbsoluteLayout;
			m_layoutGauge.layoutIn = layout.FindViewById("sw_ga_ef_inout_anim_in") as AbsoluteLayout;
			m_layoutGauge.layoutOut = layout.FindViewById("sw_ga_ef_inout_anim_out") as AbsoluteLayout;
			RawImageEx[] imgs = GetComponentsInChildren<RawImageEx>(true);
			m_imageMedal = imgs.Where((RawImageEx _) =>
			{
				//0x1DA5668
				return _.name == "swtexc_cmn_item_170002 (ImageView)";
			}).First();
			m_imageDiff = imgs.Where((RawImageEx _) =>
			{
				//0x1DA56E8
				return _.name == "swtexf_cmn_music_diff_01 (ImageView)";
			}).First();
			for(int i = 0; i < m_imageDiffRectList.Length; i++)
			{
				m_imageDiffRectList[i] = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("cmn_music_diff_" + (i + 1).ToString("D2")));
			}
			m_imageDiffRectList_6Line = new Rect[3];
			for(int i = 0; i < m_imageDiffRectList_6Line.Length; i++)
			{
				m_imageDiffRectList_6Line[i] = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("cmn_music_diff_" + (i + 6).ToString("D2")));
			}
			m_imageJacket[0] = imgs.Where((RawImageEx _) =>
			{
				//0x1DA5768
				return _.transform.parent.name == "jacket_01 (AbsoluteLayout)" && _.name == "swtexc_cmn_cd (ImageView)";
			}).First();
			m_imageJacket[1] = imgs.Where((RawImageEx _) =>
			{
				//0x1DA5868
				return _.transform.parent.name == "jacket_02 (AbsoluteLayout)" && _.name == "swtexc_cmn_cd (ImageView)";
			}).First();
			m_imageJacket[2] = imgs.Where((RawImageEx _) =>
			{
				//0x1DA5968
				return _.transform.parent.name == "jacket_03 (AbsoluteLayout)" && _.name == "swtexc_cmn_cd (ImageView)";
			}).First();
			Text[] txts = GetComponentsInChildren<Text>(true);
			m_textWinResult = txts.Where((Text _) =>
			{
				//0x1DA5A68
				return _.transform.parent.name == "fnt_win (AbsoluteLayout)" && _.name == "win (TextView)";
			}).First();
			m_textLoseResult = txts.Where((Text _) =>
			{
				//0x1DA5B68
				return _.transform.parent.name == "fnt_lose (AbsoluteLayout)" && _.name == "lose (TextView)";
			}).First();
			m_textWinLosePoint = txts.Where((Text _) =>
			{
				//0x1DA5C68
				return _.transform.parent.name == "num_pt (AbsoluteLayout)" && _.name == "pt (TextView)";
			}).First();
			m_ScoreBonusText = txts.Where((Text _) =>
			{
				//0x1DA5D68
				return _.transform.parent.name == "num_scr_pt (AbsoluteLayout)" && _.name == "scr_pt (TextView)";
			}).First();
			m_textClassRank = txts.Where((Text _) =>
			{
				//0x1DA5E68
				return _.transform.parent.name == "fnt_class (AbsoluteLayout)" && _.name == "class (TextView)";
			}).First();
			m_textDiffBonus = txts.Where((Text _) =>
			{
				//0x1DA5F68
				return _.transform.parent.name == "num_multi_winning (AbsoluteLayout)" && _.name == "multi (TextView)";
			}).First();
			m_textEpisodeCount = txts.Where((Text _) =>
			{
				//0x1DA6068
				return _.transform.parent.name == "fnt_bonus_epi (AbsoluteLayout)" && _.name == "bonus_epi (TextView)";
			}).First();
			m_textEpisodeRate = txts.Where((Text _) =>
			{
				//0x1DA6168
				return _.transform.parent.name == "num_multi_episode (AbsoluteLayout)" && _.name == "multi (TextView)";
			}).First();
			m_textPoint = txts.Where((Text _) =>
			{
				//0x1DA6268
				return _.transform.parent.name == "num_event_points (AbsoluteLayout)" && _.name == "points (TextView)";
			}).ToArray();
			m_textTotal = txts.Where((Text _) =>
			{
				//0x1DA6368
				return _.transform.parent.name == "num_event_total (AbsoluteLayout)" && _.name == "total (TextView)";
			}).First();
			m_textDashBonus = txts.Where((Text _) =>
			{
				//0x1DA6468
				return _.name == "dash (TextView)";
			}).ToArray();
			m_textMedalNum = txts.Where((Text _) =>
			{
				//0x1DA64E8
				return _.name == "medal (TextView)";
			}).First();
			m_textWinBonus = txts.Where((Text _) =>
			{
				//0x1DA6568
				return _.name == "win_bns (TextView)";
			}).First();
			m_textLoseBonus = txts.Where((Text _) =>
			{
				//0x1DA65E8
				return _.name == "lose_s (TextView)";
			}).First();
			m_textExBonus = txts.Where((Text _) =>
			{
				//0x1DA6668
				return _.name == "plus_ex (TextView)";
			}).First();
			m_textExPoint = txts.Where((Text _) =>
			{
				//0x1DA66E8
				return _.name == "ex_ga_num (TextView)";
			}).First();
			m_textExHiScore = txts.Where((Text _) =>
			{
				//0x1DA6768
				return _.name == "eve_hiscore (TextView)";
			}).First();
			m_textExRanking = txts.Where((Text _) =>
			{
				//0x1DA67E8
				return _.name == "eve_mrank (TextView)";
			}).First();
			NumberBase[] numbers = GetComponentsInChildren<NumberBase>(true);
			m_ScorePoint = numbers.Where((NumberBase _) =>
			{
				//0x1DA6868
				return _.name == "swnum_g_r_e3_num_scr (AbsoluteLayout)";
			}).First();
			m_RankNum = numbers.Where((NumberBase _) =>
			{
				//0x1DA68E8
				return _.name == "swnum_g_r_e3_num_evpt (AbsoluteLayout)";
			}).First();
			m_button = GetComponentsInChildren<ActionButton>(true).Where((ActionButton _) =>
			{
				//0x1DA6968
				return _.name == "sw_g_eve_btn_dtl_anim (AbsoluteLayout)";
			}).First();
			m_button.AddOnClickCallback(() =>
			{
				//0x1DA5400
				if(onClickButton != null)
					onClickButton.Invoke();
			});
			Loaded();
			return true;
		}

		// // RVA: 0x1DA324C Offset: 0x1DA324C VA: 0x1DA324C
		public void Setup(GJOOGLGLFID view, List<EMGOCNMMPHC> list)
		{
			m_view = view;
			m_list = list;
            MessageBank menuBk = MessageManager.Instance.GetBank("menu");
			if(!m_view.DPCFADCFMOA_RewardWin)
			{
				m_textLoseResult.text = menuBk.GetMessageByLabel("event_reward_result_lose");
				m_textLoseBonus.text = menuBk.GetMessageByLabel("event_reward_result_lose");
				m_layoutWinResult.StartChildrenAnimGoStop("02");
				m_layoutWinBonus.StartChildrenAnimGoStop("02");
			}
			else
			{
				m_textWinResult.text = menuBk.GetMessageByLabel("event_reward_result_win");
				m_textWinBonus.text = menuBk.GetMessageByLabel("event_reward_result_win");
				m_layoutWinResult.StartChildrenAnimGoStop("01");
				m_layoutWinBonus.StartChildrenAnimGoStop("01");
			}
			m_layoutRank[0].StartChildrenAnimGoStop((m_view.IDBJPDBLIIG_ScoreResultRank + 1).ToString("D2"));
			m_layoutRank[1].StartChildrenAnimGoStop((m_view.IDBJPDBLIIG_ScoreResultRank + 1).ToString("D2"));
			if(!m_view.LFGNLKKFOCD_IsLine6)
			{
				m_imageDiff.uvRect = m_imageDiffRectList[m_view.AKNELONELJK_Difficulty];
				GameManager.Instance.UnionTextureManager.GetTexture("cmn_tex_pack").Set(m_imageDiff);
			}
			else
			{
				m_imageDiff.uvRect = m_imageDiffRectList_6Line[m_view.AKNELONELJK_Difficulty - 2];
				GameManager.Instance.UnionTextureManager.GetTexture("cmn_tex_02_pack").Set(m_imageDiff);
			}
			m_textWinLosePoint.text = m_view.IOOBNLAHLEJ_Point2.ToString();
			m_ScorePoint.SetNumber(m_view.GCAPLLEIAAI_Score, 0);
			m_ScoreBonusText.text = m_view.GBLHPHCAPLG_ScoreBonus.ToString();
			m_textClassRank.text = string.Format(menuBk.GetMessageByLabel("music_event_battle_class"), m_view.BGJDHCEOIDB_BattleClass);
			m_textDiffBonus.text = (m_view.OHDIGACEJPM_DifficultyBonus - 100).ToString();
			m_layoutUp[0].StartChildrenAnimGoStop(m_view.OHDIGACEJPM_DifficultyBonus < 101 ? "02" : "01");
			m_textEpisodeCount.text = Smart.Format(menuBk.GetMessageByLabel("event_reward_result_episodebonus_unit"), m_view.FOFJCOHAFCG_EpisodeCnt);
			m_textEpisodeRate.text = (m_view.CLEFJPKPOGB_EpBonusCnt - 100).ToString();
			m_layoutUp[1].StartChildrenAnimGoStop(m_view.CLEFJPKPOGB_EpBonusCnt < 101 ? "02" : "01");
			for(int i = 0; i < m_textPoint.Length; i++)
			{
				m_textPoint[i].text = "0";
			}
			m_textTotal.text = m_view.AHOKAPCGJMA_NewPoint.ToString();
			m_RankNum.SetNumber(m_view.BJJGECFMNIP_Rank, 0);
			if(m_view.FCLGIPFPIPH_DashBonus < 2)
			{
				m_layoutDash[0].StartChildrenAnimGoStop("02", "02");
				m_layoutDash[1].StartChildrenAnimGoStop("02", "02");
			}
			else
			{
				m_layoutDash[0].StartChildrenAnimGoStop("01", "01");
				m_layoutDash[1].StartChildrenAnimGoStop("01", "01");
				for(int i = 0; i < m_textDashBonus.Length; i++)
				{
					m_textDashBonus[i].text = string.Format(menuBk.GetMessageByLabel("event_reward_result_dash_bonus"), m_view.FCLGIPFPIPH_DashBonus);
				}
			}
			m_textMedalNum.text = m_view.ODOOKDGCKMF_MedalNum.ToString();
			m_isLoading = true;
			MenuScene.Instance.ItemTextureCache.Load(m_view.BEOKMNIPFBA_MedalId, (IiconTexture texture) =>
			{
				//0x1DA5414
				texture.Set(m_imageMedal);
				m_isLoading = false;
			});
			if(m_view.IDBJPDBLIIG_ScoreResultRank == 3)
			{
				for(int i = 0; i < m_list.Count; i++)
				{
					SetJacketImage(i, m_list[i].JNCPEGJGHOG_JackedId);
				}
				m_textExPoint.text = "" + 100 + "/" + 100;
				m_layoutGauge.Setup(100, 100, 0);
				m_textExHiScore.text = m_view.IGIPKOJJIIA_ExBattleScoreTotalAfter.ToString();
				m_textExRanking.text = m_view.EKOEECDHABK_ExRanking > 0 ? m_view.EKOEECDHABK_ExRanking.ToString() : "---";
				m_layoutExRival.StartChildrenAnimGoStop("03");
			}
			else
			{
				m_textExPoint.text = m_view.GLOKIBHBNDN_PrevExPoint + "/" + 100;
				m_textExBonus.text = m_view.LENOCEEGFLD_GetExGauge.ToString("+#;-#;");
				m_layoutGauge.Setup(m_view.GLOKIBHBNDN_PrevExPoint, 100, 0);
				m_layoutExRival.StartChildrenAnimGoStop(m_view.GLOKIBHBNDN_PrevExPoint < 100 ? "01" : "02");
			}
        }

		// // RVA: 0x1DA46E8 Offset: 0x1DA46E8 VA: 0x1DA46E8
		private void SetJacketImage(int index, int coverId)
		{
			m_imageJacket[index].enabled = false;
			MenuScene.Instance.MusicJacketTextureCache.Load(coverId, (IiconTexture texture) =>
			{
				//0x1DA69F0
				m_imageJacket[index].enabled = true;
				texture.Set(m_imageJacket[index]);
			});
		}

		// // RVA: 0x1DA48C0 Offset: 0x1DA48C0 VA: 0x1DA48C0
		private void SetPoint(int point)
		{
			int v = point;
			for(int i = 0; i < m_textPoint.Length; i++)
			{
				m_textPoint[i].text = v.ToString();
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71A694 Offset: 0x71A694 VA: 0x71A694
		// // RVA: 0x1DA497C Offset: 0x1DA497C VA: 0x1DA497C
		// private IEnumerator Co_Countup(int startNum, int endNum, float accelPer, Action<int> onChangeNumberCallback) { }

		// // RVA: 0x1DA4A98 Offset: 0x1DA4A98 VA: 0x1DA4A98
		public void SkipBeginAnim()
		{
			m_isSkiped = true;
			m_layoutGauge.SkipCountUp();
			if(m_coroutine == null)
			{
				m_coroutine = this.StartCoroutineWatched(Co_BeginAnim());
			}
		}

		// // RVA: 0x1DA4AF8 Offset: 0x1DA4AF8 VA: 0x1DA4AF8
		public void StartBeginAnim()
		{
			m_coroutine = this.StartCoroutineWatched(Co_BeginAnim());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71A70C Offset: 0x71A70C VA: 0x71A70C
		// // RVA: 0x1DA4B20 Offset: 0x1DA4B20 VA: 0x1DA4B20
		private IEnumerator Co_BeginAnim()
		{
			//0x1DA6B90
			this.StartCoroutineWatched(Co_EnterTitle());
			yield return Co.R(Co_EnterGetPoint());
			yield return Co.R(Co_CountUpGetPoint());
			yield return Co.R(Co_EnterTotalPoint());
			yield return Co.R(Co_EnterMedalAndExGauge());
			if(m_view.IDBJPDBLIIG_ScoreResultRank == 3)
			{
				yield return new WaitForSeconds(0.5f);
				//5
				yield return Co.R(Co_LeaveExGauge());
				if(onCheckScoreUpdate != null)
					yield return Co.R(onCheckScoreUpdate);
				yield return Co.R(Co_EnterExHiScore());
			}
			else
			{
				yield return Co.R(Co_StartCountUp());
				//9
				yield return Co.R(Co_EntryExRival());
			}
			if(onFinished != null)
				onFinished.Invoke();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71A784 Offset: 0x71A784 VA: 0x71A784
		// // RVA: 0x1DA4BCC Offset: 0x1DA4BCC VA: 0x1DA4BCC
		private IEnumerator Co_EnterTitle()
		{
			//0x18CF3EC
			yield return new WaitWhile(() =>
			{
				//0x1DA54FC
				return m_isLoading;
			});
			m_layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
			m_layoutTitle.StartChildrenAnimGoStop("go_in", "st_in");
			yield return Co.R(Co_WaitAnim(m_layoutRoot, true));
			yield return Co.R(Co_WaitAnim(m_layoutTitle, true));
			m_layoutTitle.StartAllAnimLoop("logo_up", "loen_up");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71A7FC Offset: 0x71A7FC VA: 0x71A7FC
		// // RVA: 0x1DA4C54 Offset: 0x1DA4C54 VA: 0x1DA4C54
		private IEnumerator Co_EnterGetPoint()
		{
			AbsoluteLayout layout;

			//0x1DA772C
			layout = m_layoutMain;
			m_layoutMain.StartAllAnimGoStop("go_bonus", "st_pt");
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_035);
			yield return Co.R(Co_WaitLabel(layout, "start_win_pt", true));
			yield return Co.R(Co_WaitLabel(layout, "start_score", true));
			yield return Co.R(Co_WaitLabel(layout, "start_winning", true));
			yield return Co.R(Co_WaitLabel(layout, "start_episode", true));
			yield return Co.R(Co_WaitAnim(layout, true));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71A874 Offset: 0x71A874 VA: 0x71A874
		// // RVA: 0x1DA4D00 Offset: 0x1DA4D00 VA: 0x1DA4D00
		private IEnumerator Co_CountUpGetPoint()
		{
			AbsoluteLayout layout;

			//0x1DA6F20
			layout = m_layoutMain;
			if(m_view.PHPANNCGOKC_PointDiff > 0)
			{
				List<float> lf = new List<float>();
				NumberAnimationUtility.MakeAccelerationTimeList(8, 0.24f, 0.02f, ref lf);
				PlayCountUpLoopSE();
				yield return Co.R(NumberAnimationUtility.Co_FakeCountup(m_view.PHPANNCGOKC_PointDiff, lf, (int num) =>
				{
					//0x1DA5504
					SetPoint(num);
				}, () =>
				{
					//0x1DA69E8
					return;
				}, () =>
				{
					//0x1DA5508
					return m_isSkiped;
				}));
				m_countUpSEPlayback.Stop(false);
				SetPoint(m_view.PHPANNCGOKC_PointDiff);
				layout.StartChildrenAnimGoStop("act_pt", "acten_pt");
				yield return Co.R(Co_WaitAnim(layout, true));
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71A8EC Offset: 0x71A8EC VA: 0x71A8EC
		// // RVA: 0x1DA4DAC Offset: 0x1DA4DAC VA: 0x1DA4DAC
		private IEnumerator Co_EnterTotalPoint()
		{
			//0x18CF71C
			m_layoutMain.StartChildrenAnimGoStop("go_total_pt", "st_total_pt");
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_036);
			yield return Co.R(Co_WaitAnim(m_layoutMain, true));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71A964 Offset: 0x71A964 VA: 0x71A964
		// // RVA: 0x1DA4E34 Offset: 0x1DA4E34 VA: 0x1DA4E34
		private IEnumerator Co_EnterMedalAndExGauge()
		{
			AbsoluteLayout layout;

			//0x1DA7A34
			layout = m_layoutMain;
			layout.StartChildrenAnimGoStop("go_medal", "st_ga");
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_025);
			yield return Co.R(Co_WaitLabel(layout, "go_medal", true));
			yield return Co.R(Co_WaitLabel(layout, "go_ga", true));
			yield return Co.R(Co_WaitAnim(layout, true));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71A9DC Offset: 0x71A9DC VA: 0x71A9DC
		// // RVA: 0x1DA4EE0 Offset: 0x1DA4EE0 VA: 0x1DA4EE0
		private IEnumerator Co_EnterExHiScore() 
		{
			//0x1DA755C
			m_layoutMain.StartChildrenAnimGoStop("go_ex_scr", "st_stop");
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_025);
			yield return Co.R(Co_WaitAnim(m_layoutMain, true));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71AA54 Offset: 0x71AA54 VA: 0x71AA54
		// // RVA: 0x1DA4F8C Offset: 0x1DA4F8C VA: 0x1DA4F8C
		private IEnumerator Co_EntryExRival()
		{
			AbsoluteLayout layout;

			//0x18CF910
			if(m_view.GLOKIBHBNDN_PrevExPoint == 100)
				yield break;
			if(m_view.IBNOJFPGLHI_NextExPoint != 100)
				yield break;
			layout = m_layoutMain;
			m_layoutMain.StartChildrenAnimGoStop("go_ex", "st_ex");
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_038);
			yield return null;
			yield return Co.R(Co_WaitLabel(layout, "go_ex2", false));
			yield return Co.R(Co_WaitLabel(layout, "go_ex3", false));
			yield return Co.R(Co_WaitLabel(layout, "go_ex4", false));
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_034);
			yield return Co.R(Co_WaitAnim(layout, false));
			m_layoutExRival.StartChildrenAnimGoStop("02");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71AACC Offset: 0x71AACC VA: 0x71AACC
		// // RVA: 0x1DA5014 Offset: 0x1DA5014 VA: 0x1DA5014
		private IEnumerator Co_LeaveExGauge()
		{
			AbsoluteLayout layout;

			//0x18CFD38
			layout = m_layoutMain;
			m_layoutMain.StartChildrenAnimGoStop("go_change", "st_change");
			yield return Co.R(Co_WaitLabel(layout, "change_ga", false));
			m_textExPoint.text = "" + 0 + "/" + 100;
			m_layoutGauge.Setup(0, 100, 0);
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_034);
			yield return Co.R(Co_WaitAnim(layout, false));
			layout.StartChildrenAnimGoStop("go_ga_out", "st_ga_out");
			yield return Co.R(Co_WaitAnim(layout, false));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71AB44 Offset: 0x71AB44 VA: 0x71AB44
		// // RVA: 0x1DA509C Offset: 0x1DA509C VA: 0x1DA509C
		private IEnumerator Co_WaitLabel(AbsoluteLayout layout, string label, bool enableSkip/* = True*/)
		{
			//0x18D0610
			if(!m_isSkiped || !enableSkip)
			{
				while(layout.GetView(0).FrameAnimation.FrameCount < (int)layout.GetView(0).FrameAnimation.SearchLabelFrame(label))
					yield return null;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71ABBC Offset: 0x71ABBC VA: 0x71ABBC
		// // RVA: 0x1DA5170 Offset: 0x1DA5170 VA: 0x1DA5170
		private IEnumerator Co_WaitAnim(AbsoluteLayout layout, bool enableSkip/* = True*/)
		{
			//0x18D03EC
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

		// [IteratorStateMachineAttribute] // RVA: 0x71AC34 Offset: 0x71AC34 VA: 0x71AC34
		// // RVA: 0x1DA522C Offset: 0x1DA522C VA: 0x1DA522C
		private IEnumerator Co_StartCountUp()
		{
			//0x18D00D8
			m_layoutGauge.OnCountUpEvent = (int value) =>
			{
				//0x1DA5510
				m_textExPoint.text = "" + value + "/" + 100;
			};
			m_layoutGauge.OnCountMaxEvent = () =>
			{
				//0x1DA69EC
				return;
			};
			yield return Co.R(m_layoutGauge.StartCountUp(m_view.IBNOJFPGLHI_NextExPoint - m_view.GLOKIBHBNDN_PrevExPoint, null));
		}

		// // RVA: 0x1DA52B4 Offset: 0x1DA52B4 VA: 0x1DA52B4
		private void PlayCountUpLoopSE()
		{
			if(m_countUpSEPlayback.GetStatus() == CriAtomExPlayback.Status.Playing)
				return;
			m_countUpSEPlayback = SoundManager.Instance.sePlayerResultLoop.Play(0);
		}

		// // RVA: 0x1DA5328 Offset: 0x1DA5328 VA: 0x1DA5328
		// private void StopCountUpLoopSE() { }

		// [CompilerGeneratedAttribute] // RVA: 0x71ACBC Offset: 0x71ACBC VA: 0x71ACBC
		// // RVA: 0x1DA5414 Offset: 0x1DA5414 VA: 0x1DA5414
		// private void <Setup>b__50_0(IiconTexture texture) { }
	}
}
