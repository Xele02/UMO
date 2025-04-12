using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System;
using CriWare;
using XeSys;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Localization.SmartFormat;

namespace XeApp.Game.Menu
{
	public class GoDivaPointResultLayoutController : LayoutUGUIScriptBase
	{
		private JLCHNKIHGHK viewEventResultData; // 0x14
		public Action onClickOkayButton; // 0x18
		public Action onClickRankingButton; // 0x1C
		private AbsoluteLayout m_layoutRoot; // 0x20
		private AbsoluteLayout m_layoutMain; // 0x24
		private AbsoluteLayout m_layoutTitle; // 0x28
		private AbsoluteLayout m_layoutEpisodeUpIcon; // 0x2C
		private AbsoluteLayout m_layoutBonusGaugeRoot; // 0x30
		private AbsoluteLayout m_layoutBonusGauge; // 0x34
		private AbsoluteLayout m_layoutBonusText; // 0x38
		private AbsoluteLayout m_layoutBonusTextEf; // 0x3C
		[SerializeField]
		private RawImageEx m_imageDiff; // 0x40
		[SerializeField]
		private RawImageEx m_imageDivaIcon; // 0x44
		private Rect[] m_imageDiffRectList = new Rect[5]; // 0x48
		private Rect[] m_imageDiffRectList_6Line; // 0x4C
		[SerializeField]
		private NumberBase m_ScorePoint; // 0x50
		[SerializeField]
		private Text m_scoreBonusText; // 0x54
		[SerializeField]
		private Text m_basePointText; // 0x58
		[SerializeField]
		private Text m_textEpisodeCount; // 0x5C
		[SerializeField]
		private Text m_textEpisodeRate; // 0x60
		[SerializeField]
		private Text m_textPoint; // 0x64
		[SerializeField]
		private Text m_textPointTotal; // 0x68
		[SerializeField]
		private Text m_textMedalNum; // 0x6C
		[SerializeField]
		private RawImageEx m_imageMedal; // 0x70
		[SerializeField]
		private Text m_textBonusMusicProbability; // 0x74
		[SerializeField]
		private Text m_textHiScore; // 0x78
		[SerializeField]
		private Text m_textScoreRanking; // 0x7C
		[SerializeField]
		private ActionButton m_rankingButton; // 0x80
		private Matrix23 m_identity; // 0x84
		private bool m_isSkiped; // 0x9C
		private bool m_isStarted; // 0x9D
		private bool m_isLoading = true; // 0x9E
		private CriAtomExPlayback m_countUpSEPlayback; // 0xA0

		// RVA: 0xE1BFF4 Offset: 0xE1BFF4 VA: 0xE1BFF4
		private void OnDisable()
		{
			SoundManager.Instance.sePlayerResultLoop.Stop();
		}

		// RVA: 0xE1C048 Offset: 0xE1C048 VA: 0xE1C048 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewById("sw_game_res_event04_pt_count_inout_anim") as AbsoluteLayout;
			m_layoutMain = layout.FindViewById("sw_game_res_event04_pt_count_anim") as AbsoluteLayout;
			m_layoutTitle = layout.FindViewById("sw_g_r_event_title_anim") as AbsoluteLayout;
			m_layoutBonusGaugeRoot = layout.FindViewById("sw_voltage_max_anim") as AbsoluteLayout;
			m_layoutBonusGauge = layout.FindViewById("g_r_event_guage2") as AbsoluteLayout;
			m_layoutBonusText = layout.FindViewById("fnt_voltage") as AbsoluteLayout;
			m_layoutBonusTextEf = layout.FindViewById("sw_fnt_shine_anim") as AbsoluteLayout;
			m_layoutEpisodeUpIcon = (layout.FindViewByExId("sw_game_res_event04_pt_count_anim_swtbl_up_2") as AbsoluteLayout).FindViewById("sw_up_anim") as AbsoluteLayout;
			for(int i = 0; i < m_imageDiffRectList.Length; i++)
			{
				m_imageDiffRectList[i] = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("cmn_music_diff_" + (i + 1).ToString("D2")));
			}
			m_imageDiffRectList_6Line = new Rect[3];
			for(int i = 0; i < m_imageDiffRectList_6Line.Length; i++)
			{
				m_imageDiffRectList_6Line[i] = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("cmn_music_diff_" + (i + 6).ToString("D2")));
			}
			m_textPoint.text = "0";
			Loaded();
			return true;
		}

		// RVA: 0xE1C7C4 Offset: 0xE1C7C4 VA: 0xE1C7C4
		public void Setup(JLCHNKIHGHK viewEventData)
		{
			viewEventResultData = viewEventData;
			m_rankingButton.AddOnClickCallback(() =>
			{
				//0xE1DE10
				if(onClickRankingButton != null)
					onClickRankingButton();
			});
			m_layoutEpisodeUpIcon.StartAnimGoStop("02");
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(!viewEventResultData.LFGNLKKFOCD_IsLine6)
			{
				m_imageDiff.uvRect = m_imageDiffRectList[viewEventResultData.AKNELONELJK_Difficulty];
				GameManager.Instance.UnionTextureManager.GetTexture("cmn_tex_pack").Set(m_imageDiff);
			}
			else
			{
				m_imageDiff.uvRect = m_imageDiffRectList_6Line[viewEventResultData.AKNELONELJK_Difficulty - 2];
				GameManager.Instance.UnionTextureManager.GetTexture("cmn_tex_02_pack").Set(m_imageDiff);
			}
			m_textEpisodeCount.text = Smart.Format(bk.GetMessageByLabel("event_reward_result_episodebonus_unit"), viewEventData.LIPIAPOGHIP_EpisodeBonus);
			m_textEpisodeRate.text = ""+(viewEventData.PFJMBKBEFMA_EpisodeRate - 100);
			m_ScorePoint.SetNumber(viewEventData.KNIFCANOHOC_ScorePoint, 0);
			m_basePointText.text = viewEventData.EJDJIBPKKNO_BasePoint.ToString();
			m_textPointTotal.text = viewEventData.AHOKAPCGJMA_NextPoint.ToString();
			m_scoreBonusText.text = viewEventData.OPILAHLPJGH_ScoreBonus.ToString();
			m_textMedalNum.text = viewEventData.ODOOKDGCKMF_MedalNum.ToString();
			m_textBonusMusicProbability.text = viewEventData.AIODBKOOCMM_BonusMusicProbaBefore.ToString();
			if(viewEventData.HGHEENFMKGH_ScoreRanking == 0)
			{
				m_textHiScore.text = JpStringLiterals.StringLiteral_6527;
				m_textScoreRanking.text = JpStringLiterals.StringLiteral_6527;
			}
			else
			{
				m_textHiScore.text = viewEventData.JLIKEOKBBAM_HighScore.ToString();
				m_textScoreRanking.text = viewEventData.HGHEENFMKGH_ScoreRanking.ToString();
			}
			int start = m_layoutBonusGauge.FrameAnimation.FrameNum + 1;
			if(viewEventData.FGKABPEBFCO_BonusMusicProbaGet == 0)
			{
				m_layoutBonusGauge.StartSiblingAnimGoStop(start, start);
				m_layoutBonusGaugeRoot.StartAllAnimGoStop("go_act", "st_act");
			}
			else
			{
				int start0 = (int)(viewEventData.AIODBKOOCMM_BonusMusicProbaBefore / 100.0f * start);
				m_layoutBonusGauge.StartSiblingAnimGoStop(start0, start0);
			}
			int loadCount = 0;
			MenuScene.Instance.ItemTextureCache.Load(viewEventData.BEOKMNIPFBA_MedalItemId, (IiconTexture texture) =>
			{
				//0xE1DE44
				texture.Set(m_imageMedal);
				loadCount++;
				if(loadCount == 2)
					m_isLoading = false;
			});
			GameManager.Instance.DivaIconCache.Load(viewEventData.AHHJLDLAPAN_DivaId, 1, 0, (IiconTexture icon) =>
			{
				//0xE1DF68
				icon.Set(m_imageDivaIcon);
				loadCount++;
				if(loadCount == 2)
					m_isLoading = false;
			});
		}

		// RVA: 0xE1D140 Offset: 0xE1D140 VA: 0xE1D140
		public bool IsSetup()
		{
			return !m_isLoading;
		}

		// RVA: 0xE1D154 Offset: 0xE1D154 VA: 0xE1D154
		private void Start()
		{
			return;
		}

		// RVA: 0xE1D158 Offset: 0xE1D158 VA: 0xE1D158
		private void Update()
		{
			if(m_isStarted && !m_isSkiped && InputManager.Instance.GetInScreenTouchCount() > 0 && ResultScene.IsScreenTouch())
			{
				m_isSkiped = true;
			}
		}

		// // RVA: 0xE1D15C Offset: 0xE1D15C VA: 0xE1D15C
		// private void CheckSkipStep() { }

		// [IteratorStateMachineAttribute] // RVA: 0x71694C Offset: 0x71694C VA: 0x71694C
		// // RVA: 0xE1D230 Offset: 0xE1D230 VA: 0xE1D230
		public IEnumerator Co_BeginAnim()
		{
			//0xE1E090
			m_isStarted = true;
			this.StartCoroutineWatched(Co_EnterTitle());
			yield return Co.R(Co_EnterGetPoint());
			yield return Co.R(Co_CountUpGetPoint());
			yield return Co.R(Co_EnterTotalPoint());
			if(!viewEventResultData.CGHNCPEKOCK_IsDaily)
			{
				yield return Co.R(Co_EnterBonusProb());
			}
			if(!viewEventResultData.FPKGGEIMAFD_HasRanking)
			{
				yield return Co.R(Co_EnterMedal(viewEventResultData.CGHNCPEKOCK_IsDaily));
			}
			else
			{
				yield return Co.R(Co_EnterMedalAndRanking(viewEventResultData.CGHNCPEKOCK_IsDaily));
			}
			yield return Co.R(Co_CountUpGauge(null));
			if(viewEventResultData.PFJMBKBEFMA_EpisodeRate != 100)
			{
				m_layoutEpisodeUpIcon.StartAnimGoStop("01");
				m_layoutEpisodeUpIcon.StartChildrenAnimLoop("lo_");
			}
		}

		// // RVA: 0xE1D2DC Offset: 0xE1D2DC VA: 0xE1D2DC
		public void EndAnim()
		{
			m_layoutRoot.StartChildrenAnimGoStop("st_wait");
			m_layoutTitle.StartChildrenAnimGoStop("st_wait");
		}

		// // RVA: 0xE1D388 Offset: 0xE1D388 VA: 0xE1D388
		// private void OnClickOkayButton() { }

		// [IteratorStateMachineAttribute] // RVA: 0x7169C4 Offset: 0x7169C4 VA: 0x7169C4
		// // RVA: 0xE1D3F8 Offset: 0xE1D3F8 VA: 0xE1D3F8
		private IEnumerator Co_EnterTitle()
		{
			//0xE1FB24
			yield return new WaitWhile(() =>
			{
				//0xE1DD2C
				return m_isLoading;
			});
			m_layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
			m_layoutTitle.StartChildrenAnimGoStop("go_in", "st_in");
			yield return Co.R(Co_WaitAnim(m_layoutRoot, true));
			yield return Co.R(Co_WaitAnim(m_layoutTitle, true));
			m_layoutTitle.StartAllAnimLoop("logo_up", "loen_up");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x716A3C Offset: 0x716A3C VA: 0x716A3C
		// // RVA: 0xE1D4A4 Offset: 0xE1D4A4 VA: 0xE1D4A4
		private IEnumerator Co_EnterGetPoint()
		{
			AbsoluteLayout layout;

			//0xE1F30C
			layout = m_layoutMain;
			m_layoutMain.StartAllAnimGoStop("go_bonus", "st_pt");
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_035);
			yield return Co.R(Co_WaitLabel(layout, "start_win_pt", true));
			yield return Co.R(Co_WaitLabel(layout, "start_score", true));
			yield return Co.R(Co_WaitLabel(layout, "start_winning", true));
			yield return Co.R(Co_WaitLabel(layout, "start_episode", true));
			yield return Co.R(Co_WaitAnim(layout, true));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x716AB4 Offset: 0x716AB4 VA: 0x716AB4
		// // RVA: 0xE1D550 Offset: 0xE1D550 VA: 0xE1D550
		private IEnumerator Co_CountUpGetPoint()
		{
			AbsoluteLayout layout;

			//0xE1EC68
			layout = m_layoutMain;
			if(viewEventResultData.JKFCHNEININ_GetPoint < 1)
				yield break;
			List<float> f = new List<float>();
			NumberAnimationUtility.MakeAccelerationTimeList(8, 0.24f, 0.2f, ref f);
			PlayCountUpLoopSE();
			yield return Co.R(NumberAnimationUtility.Co_FakeCountup(viewEventResultData.JKFCHNEININ_GetPoint, f, (int num) =>
			{
				//0xE1DD34
				m_textPoint.text = num.ToString();
			}, () =>
			{
				//0xE1DE0C
				return;
			}, () =>
			{
				//0xE1DD88
				return m_isSkiped;
			}));
			m_countUpSEPlayback.Stop(false);
			m_textPoint.text = viewEventResultData.JKFCHNEININ_GetPoint.ToString();
			layout.StartChildrenAnimGoStop("act_pt", "acten_pt");
			yield return Co.R(Co_WaitAnim(layout,true));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x716B2C Offset: 0x716B2C VA: 0x716B2C
		// // RVA: 0xE1D5FC Offset: 0xE1D5FC VA: 0xE1D5FC
		private IEnumerator Co_EnterTotalPoint()
		{
			//0xE1FE2C
			m_layoutMain.StartChildrenAnimGoStop("go_total_pt", "st_total_pt");
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_036);
			yield return Co.R(Co_WaitAnim(m_layoutMain, true));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x716BA4 Offset: 0x716BA4 VA: 0x716BA4
		// // RVA: 0xE1D6A8 Offset: 0xE1D6A8 VA: 0xE1D6A8
		private IEnumerator Co_EnterMedal(bool isDaily)
		{
			AbsoluteLayout layout;

			//0xE1F614
			string s = isDaily ? "medal4" : "medal";
			layout = m_layoutMain;
			m_layoutMain.StartChildrenAnimGoStop("go_" + s, "st_" + s);
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_025);
			yield return Co.R(Co_WaitLabel(layout, "go_" + s, true));
			yield return Co.R(Co_WaitAnim(layout, true));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x716C1C Offset: 0x716C1C VA: 0x716C1C
		// // RVA: 0xE1D770 Offset: 0xE1D770 VA: 0xE1D770
		private IEnumerator Co_EnterBonusProb()
		{
			AbsoluteLayout layout;

			//0xE1F0E4
			layout = m_layoutMain;
			layout.StartChildrenAnimGoStop("go_volt", "st_volte");
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_025);
			yield return Co.R(Co_WaitLabel(layout, "go_volt", true));
			yield return Co.R(Co_WaitAnim(layout, true));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x716C94 Offset: 0x716C94 VA: 0x716C94
		// // RVA: 0xE1D81C Offset: 0xE1D81C VA: 0xE1D81C
		// private IEnumerator Co_CountUpBonusProb() { }

		// [IteratorStateMachineAttribute] // RVA: 0x716D0C Offset: 0x716D0C VA: 0x716D0C
		// // RVA: 0xE1D8C8 Offset: 0xE1D8C8 VA: 0xE1D8C8
		private IEnumerator Co_EnterMedalAndRanking(bool isDaily)
		{
			AbsoluteLayout layout;

			//0xE1F89C
			string s = isDaily ? "medal3" : "medal2";
			layout = m_layoutMain;
			m_layoutMain.StartChildrenAnimGoStop("go_" + s, "st_" + s);
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_025);
			yield return Co.R(Co_WaitLabel(layout, "go_" + s, true));
			yield return Co.R(Co_WaitAnim(layout, true));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x716D84 Offset: 0x716D84 VA: 0x716D84
		// // RVA: 0xE1D990 Offset: 0xE1D990 VA: 0xE1D990
		private IEnumerator Co_CountUpGauge(Action onFinishCallback)
		{
			float rate; // 0x18
			float addNum; // 0x1C
			float accelPer; // 0x20
			float startNum; // 0x24
			float endNum; // 0x28

			//0xE1E660
			if(viewEventResultData.FGKABPEBFCO_BonusMusicProbaGet < 1)
			{
				if(viewEventResultData.GNNKKJDKGJO)
				{
					int frame = (int)(viewEventResultData.GKFLMGHLJAB_BonusMusicProbaAfter / 100.0f * (m_layoutBonusGauge.FrameAnimation.FrameNum + 1));
					m_layoutBonusGauge.StartSiblingAnimGoStop(frame, frame);
					m_textBonusMusicProbability.text = viewEventResultData.GKFLMGHLJAB_BonusMusicProbaAfter.ToString();
					m_layoutBonusGaugeRoot.StartAllAnimGoStop("go_act2", "st_act2");
				}
			}
			else
			{
				addNum = 1;
				accelPer = 0.1f;
				rate = m_layoutBonusGauge.FrameAnimation.FrameNum + 1;
				startNum = viewEventResultData.AIODBKOOCMM_BonusMusicProbaBefore;
				endNum = viewEventResultData.GKFLMGHLJAB_BonusMusicProbaAfter;
				PlayCountUpLoopSE();
				while(true)
				{
					startNum += (int)addNum;
					if(endNum <= startNum)
					{
						break;
					}
					else
					{
						addNum += addNum * accelPer;
						int frame_ = (int)(startNum / 100.0f * rate);
						m_layoutBonusGauge.StartSiblingAnimGoStop(frame_, frame_);
						m_textBonusMusicProbability.text = startNum.ToString();
						if(m_isSkiped)
							break;
						yield return null;
					}
				}
				int frame = (int)(endNum / 100.0f * rate);
				m_layoutBonusGauge.StartSiblingAnimGoStop(frame, frame);
				m_textBonusMusicProbability.text = endNum.ToString();
				if(viewEventResultData.AIODBKOOCMM_BonusMusicProbaBefore != endNum && endNum == 100.0f)
				{
					m_layoutBonusGaugeRoot.StartAllAnimGoStop("go_act", "st_act");
					m_layoutBonusText.StartAnimGoStop("st_wait");
					m_layoutBonusTextEf.StartAnimGoStop("st_wait");
				}
				m_countUpSEPlayback.Stop(false);
			}
			if(onFinishCallback != null)
				onFinishCallback();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x716DFC Offset: 0x716DFC VA: 0x716DFC
		// // RVA: 0xE1DA58 Offset: 0xE1DA58 VA: 0xE1DA58
		private IEnumerator Co_WaitAnim(AbsoluteLayout layout, bool enableSkip/* = True*/)
		{
			//0xE1FFFC
			while(layout.IsPlayingChildren())
			{
				if(!m_isSkiped || !enableSkip)
					yield return null;
				else
				{
					layout.UpdateAllAnimation(TimeWrapper.deltaTime * 2);
					layout.UpdateAll(m_identity, Color.white);
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x716E74 Offset: 0x716E74 VA: 0x716E74
		// // RVA: 0xE1DB38 Offset: 0xE1DB38 VA: 0xE1DB38
		private IEnumerator Co_WaitLabel(AbsoluteLayout layout, string label, bool enableSkip/* = True*/)
		{
			//0xE20200
			while((!m_isSkiped || !enableSkip) && layout.GetView(0).FrameAnimation.FrameCount < layout.GetView(0).FrameAnimation.SearchLabelFrame(label))
				yield return null;
		}

		// // RVA: 0xE1DC30 Offset: 0xE1DC30 VA: 0xE1DC30
		private void PlayCountUpLoopSE()
		{
			if(m_countUpSEPlayback.GetStatus() == CriAtomExPlayback.Status.Removed)
				return;
			m_countUpSEPlayback = SoundManager.Instance.sePlayerResultLoop.Play(0);
		}

		// // RVA: 0xE1DCA4 Offset: 0xE1DCA4 VA: 0xE1DCA4
		// private void StopCountUpLoopSE() { }
	}
}
