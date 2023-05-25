using System;
using System.Collections;
using System.Collections.Generic;
using CriWare;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutResultScoreMain : LayoutUGUIScriptBase
	{
		public enum CountType
		{
			Perfect = 0,
			Great = 1,
			Good = 2,
			Bad = 3,
			Miss = 4,
			Combo = 5,
			Score = 6,
			Num = 7,
			Last = 6,
		}

		private enum NoteIndex
		{
			Miss = 0,
			Bad = 1,
			Good = 2,
			Great = 3,
			Perfect = 4,
			Excellent = 5,
			Num = 6,
		}

		private static readonly int COUNT_UP_FRAME_COMBO = 15; // 0x0
		private static readonly int COUNT_UP_FRAME_SCORE = 20; // 0x4
		public bool m_isSkiped; // 0x11
		private Matrix23 m_identity; // 0x14
		public Action onFinished; // 0x2C
		private NGJOPPIGCPM_ResultData viewData; // 0x30
		private GameResultData resultData; // 0x34
		private AbsoluteLayout layoutMainAnim; // 0x38
		private AbsoluteLayout[] layoutExcellentAnim = new AbsoluteLayout[3]; // 0x3C
		private NumberBase[] numberNoteResultCountList = new NumberBase[6]; // 0x40
		private int[] countStartFrameList = new int[7]; // 0x44
		private NumberBase numberScore; // 0x48
		private NumberBase numberBonus; // 0x4C
		private NumberBase numberCombo; // 0x50
		private NumberBase numberHighScore; // 0x54
		private Text textLiveSkipCaution; // 0x58
		private AbsoluteLayout layoutComboMarkTbl; // 0x5C
		private AbsoluteLayout layoutFullComboMarkAnim; // 0x60
		private AbsoluteLayout layoutPerfectFullComboMarkAnim; // 0x64
		private AbsoluteLayout layoutHighScoreMarkAnim; // 0x68
		private AbsoluteLayout layoutScoreRankTable; // 0x6C
		private AbsoluteLayout[] layoutScoreRankIconList = new AbsoluteLayout[5]; // 0x70
		private AbsoluteLayout layoutLeafNum; // 0x74
		private AbsoluteLayout layoutComboRankAnim; // 0x78
		private CriAtomExPlayback countUpSEPlayback; // 0x7C
		
		public Action<RhythmGameConsts.NoteResult, float> OnCountupNoteResult { get; set; } // 0x80
		public Action OnFinishCountupNoteResult { get; set; } // 0x84

		// RVA: 0x1D0FFD4 Offset: 0x1D0FFD4 VA: 0x1D0FFD4
		private void OnDisable()
		{
			if(SoundManager.Instance.sePlayerResultLoop.player == null)
				return;
			SoundManager.Instance.sePlayerResultLoop.Stop();
		}

		// RVA: 0x1D10078 Offset: 0x1D10078 VA: 0x1D10078 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			layoutMainAnim = layout.FindViewById("sw_g_res_anim") as AbsoluteLayout;
			layoutExcellentAnim[0] = layout.FindViewById("sw_g_res_font_jdg_perfect_ex_anim") as AbsoluteLayout;
			layoutExcellentAnim[1] = layout.FindViewById("sw_g_res_anim_sw_g_res_anim") as AbsoluteLayout;
			layoutExcellentAnim[2] = layout.FindViewById("sw_g_res_anim_swnum_score") as AbsoluteLayout;
			NumberBase[] nbs = transform.Find("sw_g_res_anim (AbsoluteLayout)").GetComponentsInChildren<NumberBase>(true);
			List<NumberBase> n = new List<NumberBase>(nbs);
			numberNoteResultCountList[0] = n.Find((NumberBase _) => {
				//0x1D137D4
				return _.name == "swnum_notes_miss (AbsoluteLayout)";
			});
			numberNoteResultCountList[1] = n.Find((NumberBase _) => {
				//0x1D13854
				return _.name == "swnum_notes_bad (AbsoluteLayout)";
			});
			numberNoteResultCountList[2] = n.Find((NumberBase _) => {
				//0x1D138D4
				return _.name == "swnum_notes_good (AbsoluteLayout)";
			});
			numberNoteResultCountList[3] = n.Find((NumberBase _) => {
				//0x1D13954
				return _.name == "swnum_notes_great (AbsoluteLayout)";
			});
			numberNoteResultCountList[4] = n.Find((NumberBase _) => {
				//0x1D139D4
				return _.transform.parent.name == "sw_g_res_anim (AbsoluteLayout)" && _.name == "swnum_notes_pfct (AbsoluteLayout)";
			});
			numberNoteResultCountList[5] = n.Find((NumberBase _) => {
				//0x1D13AD4
				return _.transform.parent.name == "sw_g_res_anim (AbsoluteLayout)" && _.name == "swnum_notes_exe (AbsoluteLayout)";
			});
			string[] strs = new string[7] { "start_per", "start_gre", "start_goo", "start_bad", 
				"start_mis", "start_combo", "start_score"
			};
			for(int i = 0; i < strs.Length; i++)
			{
				countStartFrameList[i] = Mathf.RoundToInt(layoutMainAnim.GetView(0).FrameAnimation.SearchLabelFrame(strs[i]));
			}

			numberCombo = n.Find((NumberBase _) => {
				//0x1D13BD4
				return _.name == "swnum_combo (AbsoluteLayout)";
			});
			numberScore = n.Find((NumberBase _) => {
				//0x1D13C54
				return _.transform.parent.name == "swnum_score (AbsoluteLayout)" && _.name == "swnum_score_ef (AbsoluteLayout)";
			});
			numberBonus = n.Find((NumberBase _) => {
				//0x1D13D54
				return _.transform.parent.name == "swnum_score (AbsoluteLayout)" && _.name == "swnum_score_bonus (AbsoluteLayout)";
			});
			numberHighScore = n.Find((NumberBase _) => {
				//0x1D13E54
				return _.transform.parent.name == "sw_g_res_anim (AbsoluteLayout)" && _.name == "swnum_highscore (AbsoluteLayout)";
			});
			
			List<Text> ts = new List<Text>(transform.Find("sw_g_res_anim (AbsoluteLayout)").GetComponentsInChildren<Text>(true));
			textLiveSkipCaution = ts.Find((Text _) => {
				//0x1D13F54
				return _.name == "desc_skip (TextView)";
			});
			textLiveSkipCaution.text = "";
			
			layoutComboMarkTbl = layoutMainAnim.FindViewById("swtbl_fc_pfc") as AbsoluteLayout;
			layoutFullComboMarkAnim = layoutMainAnim.FindViewById("sw_fc_anim") as AbsoluteLayout;
			layoutPerfectFullComboMarkAnim = layoutComboMarkTbl.FindViewById("sw_pfc_anim") as AbsoluteLayout;
			layoutHighScoreMarkAnim = layoutMainAnim.FindViewByExId("sw_g_res_anim_sw_hs_anim") as AbsoluteLayout;
			layoutScoreRankTable = layout.FindViewByExId("sw_g_res_anim_swtbl_rank_score") as AbsoluteLayout;
			layoutScoreRankIconList[0] = layout.FindViewByExId("swtbl_rank_score_sw_rank_score_c") as AbsoluteLayout;
			layoutScoreRankIconList[1] = layout.FindViewByExId("swtbl_rank_score_sw_rank_score_b") as AbsoluteLayout;
			layoutScoreRankIconList[2] = layout.FindViewByExId("swtbl_rank_score_sw_rank_score_a") as AbsoluteLayout;
			layoutScoreRankIconList[3] = layout.FindViewByExId("swtbl_rank_score_sw_rank_score_s") as AbsoluteLayout;
			layoutScoreRankIconList[4] = layout.FindViewByExId("swtbl_rank_score_sw_rank_score_ss") as AbsoluteLayout;
			layoutLeafNum = layout.FindViewById("swtbl_btn_luc") as AbsoluteLayout;
			layoutComboRankAnim = layout.FindViewById("swtbl_rank_cmb") as AbsoluteLayout;
			this.StartCoroutineWatched(Co_Loading());
			return true;
 		}

		// [IteratorStateMachineAttribute] // RVA: 0x71D85C Offset: 0x71D85C VA: 0x71D85C
		// // RVA: 0x1D120EC Offset: 0x1D120EC VA: 0x1D120EC
		private IEnumerator Co_Loading()
		{
			int i;

			//0x1D16CEC
			for(i = 0; i < numberNoteResultCountList.Length; i++)
			{
				while(!numberNoteResultCountList[i].IsLoaded())
					yield return null;
			}
			Loaded();
		}

		// // RVA: 0x1D12198 Offset: 0x1D12198 VA: 0x1D12198
		public void Setup(NGJOPPIGCPM_ResultData viewData, GameResultData resultData)
		{
			this.viewData = viewData;
			this.resultData = resultData;
			for (int i = 0; i < 5; i++)
			{
				numberNoteResultCountList[i].SetNumber(0, 0);
			}
			numberNoteResultCountList[5].SetNumber(resultData.GetNoteExcellentCount(), 0);
			numberBonus.SetNumber(viewData.GPMILOPNBPA_Bonus, 0);
			numberCombo.SetNumber(0, 0);
			numberScore.SetNumber(0, 0);
			numberHighScore.SetNumber(viewData.HMDHDKLDPFK_PrevScore, 0);
			if(IsPerfectFullCombo())
			{
				layoutComboMarkTbl.StartChildrenAnimGoStop("pfc");
			}
			layoutComboRankAnim.StartChildrenAnimGoStop(viewData.ILNBLNECEKB_RankCombo, viewData.ILNBLNECEKB_RankCombo);
			for(int i = 0; i < layoutScoreRankIconList.Length; i++)
			{
				layoutScoreRankIconList[i].StartChildrenAnimGoStop("st_wait");
			}
		}

		// // RVA: 0x1D1253C Offset: 0x1D1253C VA: 0x1D1253C
		// public void ChangeViewForSkipResult() { }

		// // RVA: 0x1D1260C Offset: 0x1D1260C VA: 0x1D1260C
		// public void ChangeViewForSupportResult() { }

		// // RVA: 0x1D126DC Offset: 0x1D126DC VA: 0x1D126DC
		public void SkipAnim()
		{
			m_isSkiped = true;
		}

		// // RVA: 0x1D126E8 Offset: 0x1D126E8 VA: 0x1D126E8
		public void StartAnim()
		{
			this.StartCoroutineWatched(Co_StartAnim());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71D8D4 Offset: 0x71D8D4 VA: 0x71D8D4
		// // RVA: 0x1D1270C Offset: 0x1D1270C VA: 0x1D1270C
		private IEnumerator Co_StartAnim()
		{
			//0x1D17478
			yield return Co.R(Co_WaitForSeconds(0.5f, true));
			yield return Co.R(Co_CountUpNotes());
			yield return Co.R(Co_CountUpCombo());
			yield return Co.R(Co_FullComboAnim());
			yield return Co.R(Co_EnterComboRank());
			yield return Co.R(Co_CountUpScore());
			yield return Co.R(Co_HighScoreAnim());
			yield return Co.R(Co_ScoreRankAnim());
			if(onFinished != null)
				onFinished();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71D94C Offset: 0x71D94C VA: 0x71D94C
		// // RVA: 0x1D127B8 Offset: 0x1D127B8 VA: 0x1D127B8
		private IEnumerator Co_CountUpNotes()
		{
			List<float> timerList;

			//0x1D14B64
			layoutMainAnim.StartChildrenAnimGoStop("go_notes", "st_notes");
			List<CountType> waitList = new List<CountType>();
			timerList = new List<float>();
			NumberAnimationUtility.MakeAccelerationTimeList(5, 0.3f, 0.02f, ref timerList);
			PlayCountUpLoopSE();

			{
				CountType type = CountType.Perfect;
				waitList.Add(type);
				yield return Co.R(Co_WaitFrame(layoutMainAnim, countStartFrameList[(int)type]));
				SetCountUpValue(type, timerList, (int value) =>
				{
					//0x1D13FDC
					numberNoteResultCountList[4].SetNumber(value, 0);
				}, () =>
				{
					//0x1D14060
					return m_isSkiped;
				}, () =>
				{
					//0x1D1432C
					waitList.Remove(type);
				});
			}

			{
				CountType type = CountType.Great;
				waitList.Add(type);
				yield return Co.R(Co_WaitFrame(layoutMainAnim, countStartFrameList[(int)type]));
				SetCountUpValue(type, timerList, (int value) =>
				{
					//0x1D14084
					numberNoteResultCountList[3].SetNumber(value, 0);
				}, () =>
				{
					//0x1D14108
					return m_isSkiped;
				}, () =>
				{
					//0x1D143C8
					waitList.Remove(type);
				});
			}

			{
				CountType type = CountType.Good;
				waitList.Add(type);
				yield return Co.R(Co_WaitFrame(layoutMainAnim, countStartFrameList[(int)type]));
				SetCountUpValue(type, timerList, (int value) =>
				{
					//0x1D1412C
					numberNoteResultCountList[2].SetNumber(value, 0);
				}, () =>
				{
					//0x1D141B0
					return m_isSkiped;
				}, () =>
				{
					//0x1D14464
					waitList.Remove(type);
				});
			}

			{
				CountType type = CountType.Bad;
				waitList.Add(type);
				yield return Co.R(Co_WaitFrame(layoutMainAnim, countStartFrameList[(int)type]));
				SetCountUpValue(type, timerList, (int value) =>
				{
					//0x1D141D4
					numberNoteResultCountList[1].SetNumber(value, 0);
				}, () =>
				{
					//0x1D14258
					return m_isSkiped;
				}, () =>
				{
					//0x1D14500
					waitList.Remove(type);
				});
			}

			{
				CountType type = CountType.Miss;
				waitList.Add(type);
				yield return Co.R(Co_WaitFrame(layoutMainAnim, countStartFrameList[(int)type]));
				SetCountUpValue(type, timerList, (int value) =>
				{
					//0x1D1427C
					numberNoteResultCountList[0].SetNumber(value, 0);
				}, () =>
				{
					//0x1D14300
					return m_isSkiped;
				}, () =>
				{
					//0x1D1459C
					waitList.Remove(type);
				});
			}

			while(waitList.Count > 0)
				yield return null;
			if(OnFinishCountupNoteResult != null)
				OnFinishCountupNoteResult();

			countUpSEPlayback.Stop();
		}

		// // RVA: 0x1D12864 Offset: 0x1D12864 VA: 0x1D12864
		private void SetCountUpValue(CountType type, List<float> timerList, Action<int> onChangeNumberCakllback, Func<bool> onSkiped, Action onFinished)
		{
			RhythmGameConsts.NoteResult res = RhythmGameConsts.NoteResult.None;
			int count = 0;
			switch(type)
			{
				case CountType.Perfect:
					res = RhythmGameConsts.NoteResult.Perfect;
					count = resultData.GetNoteTypeCount(res);
					break;
				case CountType.Great:
					res = RhythmGameConsts.NoteResult.Great;
					count = resultData.GetNoteTypeCount(res);
					break;
				case CountType.Good:
					res = RhythmGameConsts.NoteResult.Good;
					count = resultData.GetNoteTypeCount(res);
					break;
				case CountType.Bad:
					res = RhythmGameConsts.NoteResult.Bad;
					count = resultData.GetNoteTypeCount(res);
					break;
				case CountType.Miss:
					res = RhythmGameConsts.NoteResult.Miss;
					count = resultData.GetNoteTypeCount(res);
					break;
				case CountType.Combo:
					count = viewData.PBGLMBMEKAA_ComboCount;
					break;
				case CountType.Score:
					count = viewData.GCAPLLEIAAI_HighScore;
					break;
				default:
					count = 0;
					break;
			}
			this.StartCoroutineWatched(Co_FakeCountup(count, timerList, onChangeNumberCakllback, onSkiped, onFinished));
			if(res != RhythmGameConsts.NoteResult.None && OnCountupNoteResult != null)
			{
				OnCountupNoteResult(res, CalcNoteResultCountUpTime(count, timerList));
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71D9C4 Offset: 0x71D9C4 VA: 0x71D9C4
		// // RVA: 0x1D12A80 Offset: 0x1D12A80 VA: 0x1D12A80
		private IEnumerator Co_FakeCountup(int targetNumber, List<float> countTimeList, Action<int> onChangeNumberCakllback, Func<bool> onSkiped, Action onFinished)
		{
			Coroutine co;

			//0x1D16238
			bool isEnd = false;
			co = this.StartCoroutineWatched(NumberAnimationUtility.Co_FakeCountup(targetNumber, countTimeList, onChangeNumberCakllback, () =>
			{
				//0x1D14638
				isEnd = true;
			}, null));
			while(!onSkiped() && !isEnd)
			{
				yield return null;
			}

			if (onFinished != null)
			{
				onFinished();
			}
			if(co != null)
			{
				this.StopCoroutineWatched(co);
				co = null;
			}
			onChangeNumberCakllback(targetNumber);

		}

		// [IteratorStateMachineAttribute] // RVA: 0x71DA3C Offset: 0x71DA3C VA: 0x71DA3C
		// // RVA: 0x1D12CA4 Offset: 0x1D12CA4 VA: 0x1D12CA4
		private IEnumerator Co_CountUpCombo()
		{
			//0x1D14760
			layoutMainAnim.StartChildrenAnimGoStop("go_combo", "st_combo");
			yield return Co.R(Co_WaitFrame(layoutMainAnim, countStartFrameList[5], true));
			bool countUpEnd = false;
			List<float> f = new List<float>();
			NumberAnimationUtility.MakeAccelerationTimeList(10, 0.3f, 0.02f, ref f);
			PlayCountUpLoopSE();
			SetCountUpValue(CountType.Combo, f, (int value) =>
			{
				//0x1D1464C
				numberCombo.SetNumber(value, 0);
			}, () =>
			{
				//0x1D146A0
				return m_isSkiped;
			}, () =>
			{
				//0x1D146C4
				countUpEnd = true;
			});
			while (!countUpEnd)
				yield return null;
			countUpSEPlayback.Stop();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71DAB4 Offset: 0x71DAB4 VA: 0x71DAB4
		// // RVA: 0x1D12D50 Offset: 0x1D12D50 VA: 0x1D12D50
		private IEnumerator Co_FullComboAnim()
		{
			//0x1D16518
			if(!IsPerfectFullCombo())
			{
				if(!IsFullCombo())
				{
					PlaySound(1, true);
					yield return Co.R(Co_WaitForSeconds(0.3f, true));
				}
				else
				{
					layoutFullComboMarkAnim.StartChildrenAnimGoStop("go_in", "st_in");
					PlaySound(2, true);
					yield return Co.R(Co_WaitAnim(layoutFullComboMarkAnim, true));
					layoutFullComboMarkAnim.StartChildrenAnimLoop("logo_act", "loen_act");
				}
			}
			else
			{
				layoutPerfectFullComboMarkAnim.StartChildrenAnimGoStop("go_in", "st_in");
				PlaySound(2, true);
				yield return Co.R(Co_WaitAnim(layoutPerfectFullComboMarkAnim, true));
				layoutPerfectFullComboMarkAnim.StartChildrenAnimLoop("logo_act", "loen_act");
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71DB2C Offset: 0x71DB2C VA: 0x71DB2C
		// // RVA: 0x1D12DFC Offset: 0x1D12DFC VA: 0x1D12DFC
		private IEnumerator Co_EnterComboRank()
		{
			//0x1D160B4
			layoutMainAnim.StartChildrenAnimGoStop("go_comborank", "st_comborank");
			yield return Co.R(Co_WaitAnim(layoutMainAnim, true));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71DBA4 Offset: 0x71DBA4 VA: 0x71DBA4
		// // RVA: 0x1D12EA8 Offset: 0x1D12EA8 VA: 0x1D12EA8
		private IEnumerator Co_CountUpScore()
		{
			//0x1D15BC8
			layoutMainAnim.StartChildrenAnimGoStop("go_score", "st_score");
			yield return Co.R(Co_WaitFrame(layoutMainAnim, countStartFrameList[6], true));
			bool countUpEnd = false;
			List<float> f = new List<float>();
			NumberAnimationUtility.MakeAccelerationTimeList(10, 0.3f, 0.02f, ref f);
			PlayCountUpLoopSE();
			SetCountUpValue(CountType.Score, f, (int value) =>
			{
				//0x1D146D8
				numberScore.SetNumber(value, 0);
			}, () =>
			{
				//0x1D1472C
				return m_isSkiped;
			}, () =>
			{
				//0x1D14750
				countUpEnd = true;
			});
			while (!countUpEnd)
				yield return null;
			countUpSEPlayback.Stop();
			if(!viewData.PMCGHPOGLGM_EnableLiveSkip)
			{
				if(viewData.GCAPLLEIAAI_HighScore > viewData.HMDHDKLDPFK_PrevScore)
				{
					numberHighScore.SetNumber(viewData.GCAPLLEIAAI_HighScore, 0);
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71DC1C Offset: 0x71DC1C VA: 0x71DC1C
		// // RVA: 0x1D12F54 Offset: 0x1D12F54 VA: 0x1D12F54
		private IEnumerator Co_HighScoreAnim()
		{
			//0x1D16888
			if(viewData.HHPIAKKJBJD_IsBetterScore)
			{
				layoutHighScoreMarkAnim.StartChildrenAnimGoStop("go_in", "st_in");
				PlaySound(3, true);
				yield return Co.R(Co_WaitAnim(layoutHighScoreMarkAnim, true));

				if (!IsPerfectFullCombo())
				{
					if (!IsFullCombo())
					{
						layoutHighScoreMarkAnim.StartChildrenAnimLoop("logo_act", "loen_act");
						yield break;
					}
				}
				AbsoluteLayout l = IsPerfectFullCombo() ? layoutPerfectFullComboMarkAnim : layoutFullComboMarkAnim;
				int a = l.GetView(0).FrameAnimation.FrameCount;
				float f = layoutHighScoreMarkAnim.GetView(0).FrameAnimation.SearchLabelFrame("logo_act");
				float f2 = layoutHighScoreMarkAnim.GetView(0).FrameAnimation.SearchLabelFrame("loen_act");
				layoutHighScoreMarkAnim.StartChildrenAnimLoop(a + 1, Mathf.RoundToInt(f), Mathf.RoundToInt(f2));
			}
			else
			{
				PlaySound(1);
			}

		}

		// [IteratorStateMachineAttribute] // RVA: 0x71DC94 Offset: 0x71DC94 VA: 0x71DC94
		// // RVA: 0x1D13000 Offset: 0x1D13000 VA: 0x1D13000
		private IEnumerator Co_ScoreRankAnim()
		{
			//0x1D16EA0
			layoutMainAnim.StartChildrenAnimGoStop("go_rank");
			layoutScoreRankTable.StartChildrenAnimGoStop(viewData.PENICOGGNLF_RankScore, viewData.PENICOGGNLF_RankScore);
			layoutScoreRankIconList[viewData.PENICOGGNLF_RankScore].StartChildrenAnimGoStop("go_in", "st_in");
			yield return Co.R(Co_WaitForSeconds(0.5f, true));
			PlayJingle();
			yield return Co.R(Co_WaitAnim(layoutScoreRankIconList[viewData.PENICOGGNLF_RankScore], true));
			layoutScoreRankIconList[viewData.PENICOGGNLF_RankScore].StartChildrenAnimLoop("logo_act", "loen_act");
			if(resultData.GetNoteExcellentCount() > 0)
			{
				layoutExcellentAnim[0].StartChildrenAnimLoop("logo_act", "loen_act");
				layoutExcellentAnim[1].StartChildrenAnimLoop("logo_act", "loen_act");
				layoutExcellentAnim[2].StartChildrenAnimLoop("logo_act", "loen_act");
			}
			if (viewData.PENICOGGNLF_RankScore != 4)
				yield break;
			yield return Co.R(Co_WaitForSeconds(0.5f, true));
		}

		// // RVA: 0x1D12B8C Offset: 0x1D12B8C VA: 0x1D12B8C
		private float CalcNoteResultCountUpTime(int count, List<float> timerList)
		{
			float res = 0;
			if(count > 0)
			{
				int i = 0;
				do
				{
					if (timerList.Count <= i)
						return res;
					res += timerList[i];
					i++;
					count /= 10;
				} while (count > 9);
			}
			return res;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71DD0C Offset: 0x71DD0C VA: 0x71DD0C
		// // RVA: 0x1D130AC Offset: 0x1D130AC VA: 0x1D130AC
		private IEnumerator Co_WaitForSeconds(float wait, bool enableSkip = true)
		{
			float time;

			//0x1D178FC
			time = 0;
			while(!enableSkip || !(enableSkip && m_isSkiped))
			{
				time += TimeWrapper.deltaTime;
				if(time >= wait)
					yield break;
				yield return null;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71DD84 Offset: 0x71DD84 VA: 0x71DD84
		// // RVA: 0x1D13198 Offset: 0x1D13198 VA: 0x1D13198
		// private IEnumerator Co_WaitLabel(AbsoluteLayout layout, string label, bool enableSkip = True) { }

		// [IteratorStateMachineAttribute] // RVA: 0x71DDFC Offset: 0x71DDFC VA: 0x71DDFC
		// // RVA: 0x1D13290 Offset: 0x1D13290 VA: 0x1D13290
		private IEnumerator Co_WaitFrame(AbsoluteLayout layout, int frame, bool enableSkip = true)
		{
			//0x1D17A3C
			while(!enableSkip || !(enableSkip && m_isSkiped))
			{
				if (layout.GetView(0).FrameAnimation.FrameCount >= frame)
					yield break;
				yield return null;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71DE74 Offset: 0x71DE74 VA: 0x71DE74
		// // RVA: 0x1D13388 Offset: 0x1D13388 VA: 0x1D13388
		private IEnumerator Co_WaitAnim(AbsoluteLayout layout, bool enableSkip = true)
		{
			//0x1D176F8
			while(true)
			{
				if (!layout.IsPlayingChildren())
					yield break;
				if (!m_isSkiped || (m_isSkiped && !enableSkip))
				{
					yield return null;
				}
				else
				{
					layout.UpdateAllAnimation(2 * TimeWrapper.deltaTime, false);
					layout.Update(m_identity, Color.white);
				}
			}

		}

		// // RVA: 0x1D13468 Offset: 0x1D13468 VA: 0x1D13468
		private void PlaySound(int cueId, bool enableSkip = true)
		{
			if (m_isSkiped && enableSkip)
				return;
			SoundManager.Instance.sePlayerResult.Play(cueId);
		}

		// // RVA: 0x1D134D4 Offset: 0x1D134D4 VA: 0x1D134D4
		private void PlayJingle()
		{
			switch(viewData.PENICOGGNLF_RankScore)
			{
				case 0:
					PlaySound(23, true);
					break;
				case 1:
					PlaySound(22, true);
					break;
				case 2:
					PlaySound(21, true);
					break;
				case 3:
					PlaySound(20, true);
					break;
				case 4:
					PlaySound(19, true);
					break;
				default:
					break;
			}
		}

		// // RVA: 0x1D13570 Offset: 0x1D13570 VA: 0x1D13570
		private void PlayCountUpLoopSE()
		{
			if (countUpSEPlayback.GetStatus() == CriAtomExPlayback.Status.Playing)
				return;
			countUpSEPlayback = SoundManager.Instance.sePlayerResultLoop.Play(0);
		}

		// // RVA: 0x1D135E4 Offset: 0x1D135E4 VA: 0x1D135E4
		// private void StopCountUpLoopSE() { }

		// // RVA: 0x1D135F0 Offset: 0x1D135F0 VA: 0x1D135F0
		private bool IsFullCombo()
		{
			return viewData.DACPGGLFLJG_FullComboType == 1;
		}

		// // RVA: 0x1D12500 Offset: 0x1D12500 VA: 0x1D12500
		private bool IsPerfectFullCombo()
		{
			return viewData.DACPGGLFLJG_FullComboType == 2;
		}
	}
}
