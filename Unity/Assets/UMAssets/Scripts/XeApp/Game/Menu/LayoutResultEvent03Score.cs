using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CriWare;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutResultEvent03Score : LayoutUGUIScriptBase
	{
		private enum CountType
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

		private class CoroutineEx
		{
			public bool IsEnd; // 0x8

			// RVA: 0x18D58D4 Offset: 0x18D58D4 VA: 0x18D58D4
			public CoroutineEx(MonoBehaviour parent, IEnumerator routine, bool isSkiped)
			{
				IsEnd = false;
				if(!isSkiped)
				{
					parent.StartCoroutineWatched(Co_(routine));
				}
				else
				{
					routine.MoveNext();
					IsEnd = true;
				}
			}

			// [IteratorStateMachineAttribute] // RVA: 0x71B78C Offset: 0x71B78C VA: 0x71B78C
			// // RVA: 0x18DA15C Offset: 0x18DA15C VA: 0x18DA15C
			private IEnumerator Co_(IEnumerator routine)
			{
				//0x18DA228
				yield return Co.R(routine);
				IsEnd = true;
			}
		}

		private static readonly int COUNT_UP_FRAME_COMBO = 15; // 0x0
		private static readonly int COUNT_UP_FRAME_SCORE = 20; // 0x4
		private Matrix23 identity; // 0x14
		private bool isSkiped; // 0x2C
		private FJIPMALKCBG viewData; // 0x30
		private AbsoluteLayout layoutRootAnim; // 0x34
		private AbsoluteLayout layoutScoreAnim; // 0x38
		private AbsoluteLayout layoutRankAnim; // 0x3C
		private AbsoluteLayout[] layoutMyExcellentAnim = new AbsoluteLayout[3]; // 0x40
		private AbsoluteLayout[] layoutRivalExcellentAnim = new AbsoluteLayout[3]; // 0x44
		private AbsoluteLayout[] layoutMyComboAnim = new AbsoluteLayout[2]; // 0x48
		private AbsoluteLayout[] layoutRivalComboAnim = new AbsoluteLayout[2]; // 0x4C
		private AbsoluteLayout layoutMyLeafNum; // 0x50
		private AbsoluteLayout layoutRivalLeafNum; // 0x54
		private Text myNameText; // 0x58
		private Text rivalNameText; // 0x5C
		private NumberBase myTotal; // 0x60
		private NumberBase rivalTotal; // 0x64
		private RawImageEx myDiffImage; // 0x68
		private RawImageEx rivalDiffImage; // 0x6C
		private Rect[] diffImageRectList = new Rect[5]; // 0x70
		private Rect[] diffImageRectList_6Line; // 0x74
		private int[] countStartFrameList = new int[7]; // 0x78
		private NumberBase myNumberCombo; // 0x7C
		private NumberBase rivalNumberCombo; // 0x80
		private NumberBase[] myNumberNoteResultCountList = new NumberBase[6]; // 0x84
		private NumberBase[] rivalNumberNoteResultCountList = new NumberBase[6]; // 0x88
		private NumberBase myNumberScore; // 0x8C
		private NumberBase myNumberBonus; // 0x90
		private NumberBase rivalNumberScore; // 0x94
		private NumberBase rivalNumberBonus; // 0x98
		private CriAtomExPlayback countUpSEPlayback; // 0x9C

		// RVA: 0x18D07F4 Offset: 0x18D07F4 VA: 0x18D07F4
		private void OnDisable()
		{
			SoundManager.Instance.sePlayerResultLoop.Stop();
		}

		// RVA: 0x18D0848 Offset: 0x18D0848 VA: 0x18D0848 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Transform t = transform.Find("sw_g_r_e3_inout_anim (AbsoluteLayout)").transform;
			layoutRootAnim = layout.FindViewById("sw_g_r_e3_inout_anim") as AbsoluteLayout;
			layoutRootAnim.StartChildrenAnimGoStop("st_wait");
			layoutScoreAnim = layout.FindViewById("sw_g_r_e3_countnum_anim") as AbsoluteLayout;
			layoutScoreAnim.StartChildrenAnimGoStop("st_wait");
			layoutRankAnim = layout.FindViewById("swtbl_g_r_e3_rival") as AbsoluteLayout;
			layoutMyExcellentAnim[0] = layout.FindViewById("swtbl_g_r_e3_ex") as AbsoluteLayout;
			layoutMyExcellentAnim[1] = layout.FindViewById("sw_g_r_e3_num_notes_anim_you") as AbsoluteLayout;
			layoutMyExcellentAnim[2] = layout.FindViewById("num_scr_you") as AbsoluteLayout;
			layoutRivalExcellentAnim[0] = layout.FindViewById("swtbl_g_r_e3_ex_rival") as AbsoluteLayout;
			layoutMyExcellentAnim[1] = layout.FindViewById("sw_g_r_e3_num_notes_anim") as AbsoluteLayout;
			layoutMyExcellentAnim[2] = layout.FindViewById("num_scr_rival") as AbsoluteLayout;
			layoutMyComboAnim[0] = layout.FindViewById("swtbl_g_r_e3_cmb_you") as AbsoluteLayout;
			layoutMyComboAnim[1] = layout.FindViewById("swtbl_g_r_e3_cmb_you_ef") as AbsoluteLayout;
			layoutRivalComboAnim[0] = layout.FindViewById("swtbl_g_r_e3_cmb") as AbsoluteLayout;
			layoutRivalComboAnim[1] = layout.FindViewById("swtbl_g_r_e3_cmb_ef") as AbsoluteLayout;
			layoutRivalLeafNum = layoutMyExcellentAnim[2].FindViewById("swtbl_btn_luc") as AbsoluteLayout;
			layoutRivalLeafNum.StartChildrenAnimGoStop("05");
			Text[] txts = GetComponentsInChildren<Text>(true);
			myNameText = txts.Where((Text _) =>
			{
				//0x18D5DF0
				return _.transform.parent.name == "fnt_you_name (AbsoluteLayout)" && _.name == "you_name (TextView)";
			}).First();
			myNameText.horizontalOverflow = HorizontalWrapMode.Overflow;
			rivalNameText = txts.Where((Text _) =>
			{
				//0x18D5EF0
				return _.transform.parent.name == "fnt_rival_name (AbsoluteLayout)" && _.name == "rival_name (TextView)";
			}).First();
			rivalNameText.horizontalOverflow = HorizontalWrapMode.Overflow;
			for(int i = 0; i < diffImageRectList.Length; i++)
			{
				diffImageRectList[i] = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("cmn_music_diff_" + (i + 1).ToString("D2")));
			}
			diffImageRectList_6Line = new Rect[3];
			for(int i = 0; i < diffImageRectList_6Line.Length; i++)
			{
				diffImageRectList_6Line[i] = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("cmn_music_diff_" + (i + 6).ToString("D2")));
			}
			RawImageEx[] imgs = GetComponentsInChildren<RawImageEx>(true);
			myDiffImage = imgs.Where((RawImageEx _) =>
			{
				//0x18D5FF0
				return _.transform.parent.name == "swtexf_cmn_music_diff_01_you (AbsoluteLayout)" && _.name == "swtexf_cmn_music_diff_01 (ImageView)";
			}).First();
			rivalDiffImage = imgs.Where((RawImageEx _) =>
			{
				//0x18D60F0
				return _.transform.parent.name == "swtexf_cmn_music_diff_01_rival (AbsoluteLayout)" && _.name == "swtexf_cmn_music_diff_01 (ImageView)";
			}).First();
			NumberBase[] numbers = t.GetComponentsInChildren<NumberBase>(true);
			myTotal = numbers.Where((NumberBase _) =>
			{
				//0x18D61F0
				return _.name == "num_ttl (AbsoluteLayout)";
			}).First();
			rivalTotal = numbers.Where((NumberBase _) =>
			{
				//0x18D6270
				return _.name == "num_ttl_rival (AbsoluteLayout)";
			}).First();
			myNumberCombo = numbers.Where((NumberBase _) =>
			{
				//0x18D62F0
				return _.name == "swnum_g_r_e3_num_cmb_you (AbsoluteLayout)";
			}).First();
			rivalNumberCombo = numbers.Where((NumberBase _) =>
			{
				//0x18D6370
				return _.name == "swnum_g_r_e3_num_cmb (AbsoluteLayout)";
			}).First();
			myNumberNoteResultCountList[0] = numbers.Where((NumberBase _) =>
			{
				//0x18D63F0
				return _.name == "swnum_notes_miss_you (AbsoluteLayout)";
			}).First();
			myNumberNoteResultCountList[1] = numbers.Where((NumberBase _) =>
			{
				//0x18D6470
				return _.name == "swnum_notes_bad_you (AbsoluteLayout)";
			}).First();
			myNumberNoteResultCountList[2] = numbers.Where((NumberBase _) =>
			{
				//0x18D64F0
				return _.name == "swnum_notes_good_you (AbsoluteLayout)";
			}).First();
			myNumberNoteResultCountList[3] = numbers.Where((NumberBase _) =>
			{
				//0x18D6570
				return _.name == "swnum_notes_great_you (AbsoluteLayout)";
			}).First();
			myNumberNoteResultCountList[4] = numbers.Where((NumberBase _) =>
			{
				//0x18D65F0
				return _.transform.parent.name == "sw_g_r_e3_num_notes_anim_you (AbsoluteLayout)" && _.name == "swnum_g_r_e3_num_notes_pfct (AbsoluteLayout)";
			}).First();
			myNumberNoteResultCountList[5] = numbers.Where((NumberBase _) =>
			{
				//0x18D66F0
				return _.transform.parent.name == "sw_g_r_e3_num_notes_anim_you (AbsoluteLayout)" && _.name == "swnum_g_r_e3_num_notes_exe (AbsoluteLayout)";
			}).First();
			myNumberNoteResultCountList[0] = numbers.Where((NumberBase _) =>
			{
				//0x18D67F0
				return _.name == "swnum_notes_miss (AbsoluteLayout)";
			}).First();
			myNumberNoteResultCountList[1] = numbers.Where((NumberBase _) =>
			{
				//0x18D6870
				return _.name == "swnum_notes_bad (AbsoluteLayout)";
			}).First();
			myNumberNoteResultCountList[2] = numbers.Where((NumberBase _) =>
			{
				//0x18D68F0
				return _.name == "swnum_notes_good (AbsoluteLayout)";
			}).First();
			myNumberNoteResultCountList[3] = numbers.Where((NumberBase _) =>
			{
				//0x18D6970
				return _.name == "swnum_notes_great (AbsoluteLayout)";
			}).First();
			myNumberNoteResultCountList[4] = numbers.Where((NumberBase _) =>
			{
				//0x18D69F0
				return _.transform.parent.name == "sw_g_r_e3_num_notes_anim (AbsoluteLayout)" && _.name == "swnum_g_r_e3_num_notes_pfct (AbsoluteLayout)";
			}).First();
			myNumberNoteResultCountList[5] = numbers.Where((NumberBase _) =>
			{
				//0x18D6AF0
				return _.transform.parent.name == "sw_g_r_e3_num_notes_anim (AbsoluteLayout)" && _.name == "swnum_g_r_e3_num_notes_exe (AbsoluteLayout)";
			}).First();
			myNumberScore = numbers.Where((NumberBase _) =>
			{
				//0x18D6BF0
				return _.transform.parent.name == "num_scr_you (AbsoluteLayout)" && _.name == "swnum_g_r_e3_num_scr (AbsoluteLayout)";
			}).First();
			myNumberBonus = numbers.Where((NumberBase _) =>
			{
				//0x18D6CF0
				return _.transform.parent.name == "num_scr_you (AbsoluteLayout)" && _.name == "swnum_g_r_e3_num_scr_bonus (AbsoluteLayout)";
			}).First();
			rivalNumberScore = numbers.Where((NumberBase _) =>
			{
				//0x18D6DF0
				return _.transform.parent.name == "num_scr_rival (AbsoluteLayout)" && _.name == "swnum_g_r_e3_num_scr (AbsoluteLayout)";
			}).First();
			rivalNumberBonus = numbers.Where((NumberBase _) =>
			{
				//0x18D6EF0
				return _.transform.parent.name == "num_scr_rival (AbsoluteLayout)" && _.name == "swnum_g_r_e3_num_scr_bonus (AbsoluteLayout)";
			}).First();
			string[] strs2 = new string[7]
			{
				"start_per", "start_gre", "start_goo", "start_bad", "start_mis", "start_combo", "start_score"
			};
			for(int i = 0; i < strs2.Length; i++)
			{
				countStartFrameList[i] = (int)layoutScoreAnim.GetView(0).FrameAnimation.SearchLabelFrame(strs2[i]);
			}
			this.StartCoroutineWatched(Co_Loading());
			return true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71B11C Offset: 0x71B11C VA: 0x71B11C
		// // RVA: 0x18D3CE4 Offset: 0x18D3CE4 VA: 0x18D3CE4
		private IEnumerator Co_Loading()
		{
			int i;

			//0x18D9910
			for(i = 0; i < rivalNumberNoteResultCountList.Length; i++)
			{
				while(!rivalNumberNoteResultCountList[i].IsLoaded())
					yield return null;
			}
			Loaded();
		}

		// // RVA: 0x18D3D90 Offset: 0x18D3D90 VA: 0x18D3D90
		public void Setup(FJIPMALKCBG viewData, int rivalStrength)
		{
			this.viewData = viewData;
			myNameText.text = viewData.HIHPPOFHMNF_Player.OPFGFINHFCE_Name;
			rivalNameText.text = viewData.EKOCEKHBHLE_Rival.OPFGFINHFCE_Name;
			layoutRankAnim.StartChildrenAnimGoStop((rivalStrength + 1).ToString("D2"));
			myTotal.SetNumber(viewData.HIHPPOFHMNF_Player.BDLNMOIOMHK_TotalStats, 0);
			rivalTotal.SetNumber(viewData.EKOCEKHBHLE_Rival.BDLNMOIOMHK_TotalStats, 0);
			if(!viewData.HIHPPOFHMNF_Player.JCOJKAHFADL_Is6Line)
			{
				myDiffImage.uvRect = diffImageRectList[viewData.HIHPPOFHMNF_Player.AKNELONELJK_Difficulty];
				GameManager.Instance.UnionTextureManager.GetTexture("cmn_tex_pack").Set(myDiffImage);
			}
			else
			{
				myDiffImage.uvRect = diffImageRectList_6Line[viewData.HIHPPOFHMNF_Player.AKNELONELJK_Difficulty - 2];
				GameManager.Instance.UnionTextureManager.GetTexture("cmn_tex_02_pack").Set(myDiffImage);
			}
			if(!viewData.EKOCEKHBHLE_Rival.JCOJKAHFADL_Is6Line)
			{
				rivalDiffImage.uvRect = diffImageRectList[viewData.EKOCEKHBHLE_Rival.AKNELONELJK_Difficulty];
				GameManager.Instance.UnionTextureManager.GetTexture("cmn_tex_pack").Set(rivalDiffImage);
			}
			else
			{
				rivalDiffImage.uvRect = diffImageRectList_6Line[viewData.EKOCEKHBHLE_Rival.AKNELONELJK_Difficulty - 2];
				GameManager.Instance.UnionTextureManager.GetTexture("cmn_tex_02_pack").Set(rivalDiffImage);
			}
			myNumberCombo.SetNumber(0, 0);
			rivalNumberCombo.SetNumber(0, 0);
			if(viewData.HIHPPOFHMNF_Player.JCOJKAHFADL_Is6Line)
			{
				viewData.HIHPPOFHMNF_Player.JEEEFDOGELK_ComboRank = 0;
			}
			if(viewData.EKOCEKHBHLE_Rival.JCOJKAHFADL_Is6Line)
			{
				viewData.EKOCEKHBHLE_Rival.JEEEFDOGELK_ComboRank = 0;
			}
			if(viewData.HIHPPOFHMNF_Player.JEEEFDOGELK_ComboRank == 2)
			{
				layoutMyComboAnim[0].StartChildrenAnimGoStop("02");
				layoutMyComboAnim[1].StartChildrenAnimGoStop("02");
			}
			else if(viewData.HIHPPOFHMNF_Player.JEEEFDOGELK_ComboRank == 1)
			{
				layoutMyComboAnim[0].StartChildrenAnimGoStop("01");
				layoutMyComboAnim[1].StartChildrenAnimGoStop("01");
			}
			else
			{
				layoutMyComboAnim[0].StartChildrenAnimGoStop("03");
				layoutMyComboAnim[1].StartChildrenAnimGoStop("03");
			}
			if(viewData.EKOCEKHBHLE_Rival.JEEEFDOGELK_ComboRank == 2)
			{
				layoutRivalComboAnim[0].StartChildrenAnimGoStop("02");
				layoutRivalComboAnim[1].StartChildrenAnimGoStop("02");
			}
			else if(viewData.EKOCEKHBHLE_Rival.JEEEFDOGELK_ComboRank == 1)
			{
				layoutRivalComboAnim[0].StartChildrenAnimGoStop("01");
				layoutRivalComboAnim[1].StartChildrenAnimGoStop("01");
			}
			else
			{
				layoutRivalComboAnim[0].StartChildrenAnimGoStop("03");
				layoutRivalComboAnim[1].StartChildrenAnimGoStop("03");
			}
			for(int i = 0; i < 5; i++)
			{
				myNumberNoteResultCountList[i].SetNumber(0, 0);
				rivalNumberNoteResultCountList[i].SetNumber(0, 0);
			}
			myNumberNoteResultCountList[5].SetNumber(viewData.HIHPPOFHMNF_Player.NKLHOLHLEEI_ExcellentCount, 0);
			rivalNumberNoteResultCountList[5].SetNumber(viewData.EKOCEKHBHLE_Rival.NKLHOLHLEEI_ExcellentCount, 0);
			myNumberScore.SetNumber(0, 0);
			rivalNumberScore.SetNumber(0, 0);
			myNumberBonus.SetNumber(viewData.HIHPPOFHMNF_Player.EACPIDGGPPO_Bonus, 0);
			rivalNumberBonus.SetNumber(viewData.EKOCEKHBHLE_Rival.EACPIDGGPPO_Bonus, 0);
		}

		// // RVA: 0x18D4AE0 Offset: 0x18D4AE0 VA: 0x18D4AE0
		public void StartBeginAnim(Action onEndCallback)
		{
			this.StartCoroutineWatched(Co_BeginAnim(onEndCallback));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71B194 Offset: 0x71B194 VA: 0x71B194
		// // RVA: 0x18D4B04 Offset: 0x18D4B04 VA: 0x18D4B04
		private IEnumerator Co_BeginAnim(Action onEndCallback)
		{
			CoroutineEx co;

			//0x18D6FF4
			co = MoveNext(Co_CountUpNotes());
			while(!co.IsEnd)
				yield return null;
			co = MoveNext(Co_WaitForSeconds(0.2f, true));
			while(!co.IsEnd)
				yield return null;
			co = MoveNext(Co_CountUpCombo());
			while(!co.IsEnd)
				yield return null;
			co = MoveNext(Co_WaitForSeconds(0.2f, true));
			while(!co.IsEnd)
				yield return null;
			co = MoveNext(Co_CountUpScore());
			while(!co.IsEnd)
				yield return null;
			if(onEndCallback != null)
				onEndCallback();
		}

		// // RVA: 0x18D4BCC Offset: 0x18D4BCC VA: 0x18D4BCC
		public void LoopAnim()
		{
			if(viewData.HIHPPOFHMNF_Player.NKLHOLHLEEI_ExcellentCount > 0)
			{
				layoutMyExcellentAnim[0].StartChildrenAnimLoop("logo_act", "loen_act");
				layoutMyExcellentAnim[1].StartChildrenAnimLoop("logo_act", "loen_act");
				layoutMyExcellentAnim[2].StartChildrenAnimLoop("logo_act", "loen_act");
			}
			if(viewData.EKOCEKHBHLE_Rival.NKLHOLHLEEI_ExcellentCount > 0)
			{
				layoutRivalExcellentAnim[0].StartChildrenAnimLoop("logo_act", "loen_act");
				layoutRivalExcellentAnim[1].StartChildrenAnimLoop("logo_act", "loen_act");
				layoutRivalExcellentAnim[2].StartChildrenAnimLoop("logo_act", "loen_act");
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71B20C Offset: 0x71B20C VA: 0x71B20C
		// // RVA: 0x18D4F20 Offset: 0x18D4F20 VA: 0x18D4F20
		private IEnumerator Co_CountUpNotes()
		{
			CoroutineEx co; // 0x14
			List<CoroutineEx> coutupCoroutines; // 0x18
			List<float> timerList; // 0x1C
			int i; // 0x20

			//0x18D7A68
			layoutRootAnim.StartChildrenAnimGoStop("go_in", "total_in");
			co = MoveNext(Co_WaitAnim(layoutRootAnim, true));
			while(!co.IsEnd)
				yield return null;
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_034);
			layoutRootAnim.StartChildrenAnimGoStop("total_in", "combo_in");
			co = MoveNext(Co_WaitAnim(layoutRootAnim, true));
			while(!co.IsEnd)
				yield return null;
			co = MoveNext(Co_WaitForSeconds(0.3f, true));
			while(!co.IsEnd)
				yield return null;
			layoutRootAnim.StartChildrenAnimGoStop("combo_in", "st_stop");
			co = MoveNext(Co_WaitAnim(layoutRootAnim, true));
			while(!co.IsEnd)
				yield return null;
			coutupCoroutines = new List<CoroutineEx>();
			timerList = new List<float>();
			NumberAnimationUtility.MakeAccelerationTimeList(4, 0.3f, 0.02f, ref timerList);
			layoutRootAnim.StartChildrenAnimGoStop("start_per", "start_combo");
			co = MoveNext(Co_WaitFrame(layoutRootAnim, countStartFrameList[0], true));
			while(!co.IsEnd)
				yield return null;
			PlayCountUpLoopSE();
			coutupCoroutines.Add(MoveNext(NumberAnimationUtility.Co_FakeCountup(viewData.HIHPPOFHMNF_Player.PGPBALKFBNK_Notes[4], timerList, (int value) =>
			{
				//0x18D5B8C
				UpdateMyNotesValue(NoteIndex.Perfect, value);
			}, null,() =>
			{
				//0x18D5B98
				return isSkiped;
			})));
			coutupCoroutines.Add(MoveNext(NumberAnimationUtility.Co_FakeCountup(viewData.EKOCEKHBHLE_Rival.PGPBALKFBNK_Notes[4], timerList, (int value) =>
			{
				//0x18D5BA0
				UpdateRivalNotesValue(NoteIndex.Perfect, value);
			}, null,() =>
			{
				//0x18D5BAC
				return isSkiped;
			})));
			co = MoveNext(Co_WaitFrame(layoutScoreAnim, countStartFrameList[1], true));
			while(!co.IsEnd)
				yield return null;
			coutupCoroutines.Add(MoveNext(NumberAnimationUtility.Co_FakeCountup(viewData.HIHPPOFHMNF_Player.PGPBALKFBNK_Notes[3], timerList, (int value) =>
			{
				//0x18D5BB4
				UpdateMyNotesValue(NoteIndex.Great, value);
			}, null,() =>
			{
				//0x18D5BC0
				return isSkiped;
			})));
			coutupCoroutines.Add(MoveNext(NumberAnimationUtility.Co_FakeCountup(viewData.EKOCEKHBHLE_Rival.PGPBALKFBNK_Notes[3], timerList, (int value) =>
			{
				//0x18D5BC8
				UpdateRivalNotesValue(NoteIndex.Great, value);
			}, null,() =>
			{
				//0x18D5BD4
				return isSkiped;
			})));
			co = MoveNext(Co_WaitFrame(layoutScoreAnim, countStartFrameList[2], true));
			while(!co.IsEnd)
				yield return null;
			coutupCoroutines.Add(MoveNext(NumberAnimationUtility.Co_FakeCountup(viewData.HIHPPOFHMNF_Player.PGPBALKFBNK_Notes[2], timerList, (int value) =>
			{
				//0x18D5BDC
				UpdateMyNotesValue(NoteIndex.Good, value);
			}, null,() =>
			{
				//0x18D5BE8
				return isSkiped;
			})));
			coutupCoroutines.Add(MoveNext(NumberAnimationUtility.Co_FakeCountup(viewData.EKOCEKHBHLE_Rival.PGPBALKFBNK_Notes[2], timerList, (int value) =>
			{
				//0x18D5BF0
				UpdateRivalNotesValue(NoteIndex.Good, value);
			}, null,() =>
			{
				//0x18D5BFC
				return isSkiped;
			})));
			co = MoveNext(Co_WaitFrame(layoutScoreAnim, countStartFrameList[3], true));
			while(!co.IsEnd)
				yield return null;
			coutupCoroutines.Add(MoveNext(NumberAnimationUtility.Co_FakeCountup(viewData.HIHPPOFHMNF_Player.PGPBALKFBNK_Notes[1], timerList, (int value) =>
			{
				//0x18D5C04
				UpdateMyNotesValue(NoteIndex.Bad, value);
			}, null,() =>
			{
				//0x18D5C10
				return isSkiped;
			})));
			coutupCoroutines.Add(MoveNext(NumberAnimationUtility.Co_FakeCountup(viewData.EKOCEKHBHLE_Rival.PGPBALKFBNK_Notes[1], timerList, (int value) =>
			{
				//0x18D5C18
				UpdateRivalNotesValue(NoteIndex.Bad, value);
			}, null,() =>
			{
				//0x18D5C24
				return isSkiped;
			})));
			co = MoveNext(Co_WaitFrame(layoutScoreAnim, countStartFrameList[4], true));
			while(!co.IsEnd)
				yield return null;
			coutupCoroutines.Add(MoveNext(NumberAnimationUtility.Co_FakeCountup(viewData.HIHPPOFHMNF_Player.PGPBALKFBNK_Notes[0], timerList, (int value) =>
			{
				//0x18D5C2C
				UpdateMyNotesValue(NoteIndex.Miss, value);
			}, null,() =>
			{
				//0x18D5C38
				return isSkiped;
			})));
			coutupCoroutines.Add(MoveNext(NumberAnimationUtility.Co_FakeCountup(viewData.EKOCEKHBHLE_Rival.PGPBALKFBNK_Notes[0], timerList, (int value) =>
			{
				//0x18D5C40
				UpdateRivalNotesValue(NoteIndex.Miss, value);
			}, null,() =>
			{
				//0x18D5C4C
				return isSkiped;
			})));
			for(i = 0; i < coutupCoroutines.Count; i++)
			{
				while(!coutupCoroutines[i].IsEnd)
				{
					yield return null;
				}
			}
			co = MoveNext(Co_WaitAnim(layoutRootAnim, true));
			while(!co.IsEnd)
				yield return null;
			countUpSEPlayback.Stop(false);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71B284 Offset: 0x71B284 VA: 0x71B284
		// // RVA: 0x18D4FCC Offset: 0x18D4FCC VA: 0x18D4FCC
		private IEnumerator Co_CountUpCombo()
		{
			List<CoroutineEx> comboCoroutines; // 0x14
			CoroutineEx co; // 0x18
			int i; // 0x1C

			//0x18D73CC
			FindFullCombo();
			layoutScoreAnim.StartChildrenAnimGoStop("start_combo", "st_combo");
			comboCoroutines = new List<CoroutineEx>();
			PlayCountUpLoopSE();
			List<float> lf = new List<float>();
			NumberAnimationUtility.MakeAccelerationTimeList(8, 0.3f, 0.02f, ref lf);
			comboCoroutines.Add(MoveNext(NumberAnimationUtility.Co_FakeCountup(viewData.HIHPPOFHMNF_Player.NLKEBAOBJCM_Combo, lf, (int value) =>
			{
				//0x18D5C54
				myNumberCombo.SetNumber(value, 0);
			}, null, () =>
			{
				//0x18D5C94
				return isSkiped;
			})));
			comboCoroutines.Add(MoveNext(NumberAnimationUtility.Co_FakeCountup(viewData.EKOCEKHBHLE_Rival.NLKEBAOBJCM_Combo, lf, (int value) =>
			{
				//0x18D5C9C
				rivalNumberCombo.SetNumber(value, 0);
			}, null, () =>
			{
				//0x18D5CDC
				return isSkiped;
			})));
			co = MoveNext(Co_WaitFrame(layoutScoreAnim, countStartFrameList[5], true));
			while(!co.IsEnd)
				yield return null;
			for(i = 0; i < comboCoroutines.Count; i++)
			{
				while(!comboCoroutines[i].IsEnd)
					yield return null;
			}
			co = MoveNext(Co_WaitAnim(layoutScoreAnim, true));
			while(!co.IsEnd)
				yield return null;
			countUpSEPlayback.Stop(false);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71B2FC Offset: 0x71B2FC VA: 0x71B2FC
		// // RVA: 0x18D5078 Offset: 0x18D5078 VA: 0x18D5078
		private IEnumerator Co_CountUpScore()
		{
			List<CoroutineEx> scoreCoroutines; // 0x14
			CoroutineEx co; // 0x18
			int i; // 0x1C

			//0x18D917C
			layoutScoreAnim.StartChildrenAnimGoStop("start_score", "st_score");
			scoreCoroutines = new List<CoroutineEx>();
			PlayCountUpLoopSE();
			List<float> lf = new List<float>();
			NumberAnimationUtility.MakeAccelerationTimeList(10, 0.3f, 0.02f, ref lf);
			scoreCoroutines.Add(MoveNext(NumberAnimationUtility.Co_FakeCountup(viewData.HIHPPOFHMNF_Player.KNIFCANOHOC_ScorePoint, lf, (int value) =>
			{
				//0x18D5CE4
				myNumberScore.SetNumber(value, 0);
			}, null, () =>
			{
				//0x18D5D24
				return isSkiped;
			})));
			scoreCoroutines.Add(MoveNext(NumberAnimationUtility.Co_FakeCountup(viewData.EKOCEKHBHLE_Rival.KNIFCANOHOC_ScorePoint, lf, (int value) =>
			{
				//0x18D5D2C
				rivalNumberScore.SetNumber(value, 0);
			}, null, () =>
			{
				//0x18D5D6C
				return isSkiped;
			})));
			for(i = 0; i < scoreCoroutines.Count; i++)
			{
				while(!scoreCoroutines[i].IsEnd)
					yield return null;
			}
			co = MoveNext(Co_WaitAnim(layoutScoreAnim, true));
			while(!co.IsEnd)
				yield return null;
			countUpSEPlayback.Stop(false);
		}

		// // RVA: 0x18D5124 Offset: 0x18D5124 VA: 0x18D5124
		private void UpdateMyNotesValue(NoteIndex type, int value)
		{
			myNumberNoteResultCountList[(int)type].SetNumber(value, 0);
		}

		// // RVA: 0x18D519C Offset: 0x18D519C VA: 0x18D519C
		private void UpdateRivalNotesValue(NoteIndex type, int value)
		{
			rivalNumberNoteResultCountList[(int)type].SetNumber(value, 0);
		}

		// // RVA: 0x18D5214 Offset: 0x18D5214 VA: 0x18D5214
		public void StartEndAnim(Action onEndCallback)
		{
			this.StartCoroutineWatched(Co_EndAnim(onEndCallback));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71B374 Offset: 0x71B374 VA: 0x71B374
		// // RVA: 0x18D5238 Offset: 0x18D5238 VA: 0x18D5238
		private IEnumerator Co_EndAnim(Action onEndCallback)
		{
			//0x18D9770
			layoutRootAnim.StartChildrenAnimGoStop("go_out", "st_out");
			yield return Co.R(Co_WaitAnim(layoutRootAnim, false));
			if(onEndCallback != null)
				onEndCallback();
		}

		// // RVA: 0x18D5300 Offset: 0x18D5300 VA: 0x18D5300
		public void SkipBeginAnim()
		{
			isSkiped = true;
		}

		// // RVA: 0x18D530C Offset: 0x18D530C VA: 0x18D530C
		private void PlayCountUpLoopSE()
		{
			if(isSkiped)
				return;
			if(countUpSEPlayback.GetStatus() == CriAtomExPlayback.Status.Playing)
				return;
			countUpSEPlayback = SoundManager.Instance.sePlayerResultLoop.Play(0);
		}

		// // RVA: 0x18D5390 Offset: 0x18D5390 VA: 0x18D5390
		// private void StopCountUpLoopSE() { }

		// // RVA: 0x18D4AB4 Offset: 0x18D4AB4 VA: 0x18D4AB4
		// private bool IsFullCombo(BKKMNPEEILG viewData) { }

		// // RVA: 0x18D4A84 Offset: 0x18D4A84 VA: 0x18D4A84
		// private bool IsPerfectFullCombo(BKKMNPEEILG viewData) { }

		// // RVA: 0x18D539C Offset: 0x18D539C VA: 0x18D539C
		private bool FindFullCombo()
		{
			bool b1 = true;
			if(viewData.HIHPPOFHMNF_Player.JEEEFDOGELK_ComboRank != 1)
			{
				b1 = false;
				if(viewData.HIHPPOFHMNF_Player.JEEEFDOGELK_ComboRank == 2)
					b1 = true;
			}
			bool b2 = true;
			if(viewData.EKOCEKHBHLE_Rival.JEEEFDOGELK_ComboRank != 1)
			{
				b2 = false;
				if(viewData.EKOCEKHBHLE_Rival.JEEEFDOGELK_ComboRank == 2)
					b2 = true;
			}
			return b1 || b2;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71B3EC Offset: 0x71B3EC VA: 0x71B3EC
		// // RVA: 0x18D5490 Offset: 0x18D5490 VA: 0x18D5490
		private IEnumerator Co_WaitForSeconds(float seconds, bool enableSkip/* = True*/)
		{
			float time;

			//0x18D9CC8
			time = 0;
			while((!isSkiped || !enableSkip) && time < seconds)
			{
				time += TimeWrapper.deltaTime;
				yield return null;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71B464 Offset: 0x71B464 VA: 0x71B464
		// // RVA: 0x18D557C Offset: 0x18D557C VA: 0x18D557C
		// private IEnumerator Co_WaitLabel(AbsoluteLayout layout, string label, bool enableSkip = True) { }

		// [IteratorStateMachineAttribute] // RVA: 0x71B4DC Offset: 0x71B4DC VA: 0x71B4DC
		// // RVA: 0x18D5674 Offset: 0x18D5674 VA: 0x18D5674
		private IEnumerator Co_WaitFrame(AbsoluteLayout layout, int frame, bool enableSkip/* = True*/)
		{
			//0x18D9E08
			while((!isSkiped || !enableSkip) && layout.GetView(0).FrameAnimation.FrameCount < frame)
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71B554 Offset: 0x71B554 VA: 0x71B554
		// // RVA: 0x18D576C Offset: 0x18D576C VA: 0x18D576C
		private IEnumerator Co_WaitAnim(AbsoluteLayout layout, bool enableSkip/* = True*/)
		{
			//0x18D9AC4
			while(layout.IsPlayingChildren())
			{
				if(!isSkiped || !enableSkip)
				{
					yield return null;
				}
				else
				{
					layout.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
					layout.UpdateAll(identity, Color.white);
				}
			}
		}

		// // RVA: 0x18D584C Offset: 0x18D584C VA: 0x18D584C
		private CoroutineEx MoveNext(IEnumerator routine)
		{
			return new CoroutineEx(this, routine, isSkiped);
		}

		// [CompilerGeneratedAttribute] // RVA: 0x71B5CC Offset: 0x71B5CC VA: 0x71B5CC
		// // RVA: 0x18D5B8C Offset: 0x18D5B8C VA: 0x18D5B8C
		// private void <Co_CountUpNotes>b__41_0(int value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x71B5DC Offset: 0x71B5DC VA: 0x71B5DC
		// // RVA: 0x18D5B98 Offset: 0x18D5B98 VA: 0x18D5B98
		// private bool <Co_CountUpNotes>b__41_1() { }

		// [CompilerGeneratedAttribute] // RVA: 0x71B5EC Offset: 0x71B5EC VA: 0x71B5EC
		// // RVA: 0x18D5BA0 Offset: 0x18D5BA0 VA: 0x18D5BA0
		// private void <Co_CountUpNotes>b__41_2(int value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x71B5FC Offset: 0x71B5FC VA: 0x71B5FC
		// // RVA: 0x18D5BAC Offset: 0x18D5BAC VA: 0x18D5BAC
		// private bool <Co_CountUpNotes>b__41_3() { }

		// [CompilerGeneratedAttribute] // RVA: 0x71B60C Offset: 0x71B60C VA: 0x71B60C
		// // RVA: 0x18D5BB4 Offset: 0x18D5BB4 VA: 0x18D5BB4
		// private void <Co_CountUpNotes>b__41_4(int value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x71B61C Offset: 0x71B61C VA: 0x71B61C
		// // RVA: 0x18D5BC0 Offset: 0x18D5BC0 VA: 0x18D5BC0
		// private bool <Co_CountUpNotes>b__41_5() { }

		// [CompilerGeneratedAttribute] // RVA: 0x71B62C Offset: 0x71B62C VA: 0x71B62C
		// // RVA: 0x18D5BC8 Offset: 0x18D5BC8 VA: 0x18D5BC8
		// private void <Co_CountUpNotes>b__41_6(int value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x71B63C Offset: 0x71B63C VA: 0x71B63C
		// // RVA: 0x18D5BD4 Offset: 0x18D5BD4 VA: 0x18D5BD4
		// private bool <Co_CountUpNotes>b__41_7() { }

		// [CompilerGeneratedAttribute] // RVA: 0x71B64C Offset: 0x71B64C VA: 0x71B64C
		// // RVA: 0x18D5BDC Offset: 0x18D5BDC VA: 0x18D5BDC
		// private void <Co_CountUpNotes>b__41_8(int value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x71B65C Offset: 0x71B65C VA: 0x71B65C
		// // RVA: 0x18D5BE8 Offset: 0x18D5BE8 VA: 0x18D5BE8
		// private bool <Co_CountUpNotes>b__41_9() { }

		// [CompilerGeneratedAttribute] // RVA: 0x71B66C Offset: 0x71B66C VA: 0x71B66C
		// // RVA: 0x18D5BF0 Offset: 0x18D5BF0 VA: 0x18D5BF0
		// private void <Co_CountUpNotes>b__41_10(int value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x71B67C Offset: 0x71B67C VA: 0x71B67C
		// // RVA: 0x18D5BFC Offset: 0x18D5BFC VA: 0x18D5BFC
		// private bool <Co_CountUpNotes>b__41_11() { }

		// [CompilerGeneratedAttribute] // RVA: 0x71B68C Offset: 0x71B68C VA: 0x71B68C
		// // RVA: 0x18D5C04 Offset: 0x18D5C04 VA: 0x18D5C04
		// private void <Co_CountUpNotes>b__41_12(int value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x71B69C Offset: 0x71B69C VA: 0x71B69C
		// // RVA: 0x18D5C10 Offset: 0x18D5C10 VA: 0x18D5C10
		// private bool <Co_CountUpNotes>b__41_13() { }

		// [CompilerGeneratedAttribute] // RVA: 0x71B6AC Offset: 0x71B6AC VA: 0x71B6AC
		// // RVA: 0x18D5C18 Offset: 0x18D5C18 VA: 0x18D5C18
		// private void <Co_CountUpNotes>b__41_14(int value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x71B6BC Offset: 0x71B6BC VA: 0x71B6BC
		// // RVA: 0x18D5C24 Offset: 0x18D5C24 VA: 0x18D5C24
		// private bool <Co_CountUpNotes>b__41_15() { }

		// [CompilerGeneratedAttribute] // RVA: 0x71B6CC Offset: 0x71B6CC VA: 0x71B6CC
		// // RVA: 0x18D5C2C Offset: 0x18D5C2C VA: 0x18D5C2C
		// private void <Co_CountUpNotes>b__41_16(int value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x71B6DC Offset: 0x71B6DC VA: 0x71B6DC
		// // RVA: 0x18D5C38 Offset: 0x18D5C38 VA: 0x18D5C38
		// private bool <Co_CountUpNotes>b__41_17() { }

		// [CompilerGeneratedAttribute] // RVA: 0x71B6EC Offset: 0x71B6EC VA: 0x71B6EC
		// // RVA: 0x18D5C40 Offset: 0x18D5C40 VA: 0x18D5C40
		// private void <Co_CountUpNotes>b__41_18(int value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x71B6FC Offset: 0x71B6FC VA: 0x71B6FC
		// // RVA: 0x18D5C4C Offset: 0x18D5C4C VA: 0x18D5C4C
		// private bool <Co_CountUpNotes>b__41_19() { }

		// [CompilerGeneratedAttribute] // RVA: 0x71B70C Offset: 0x71B70C VA: 0x71B70C
		// // RVA: 0x18D5C54 Offset: 0x18D5C54 VA: 0x18D5C54
		// private void <Co_CountUpCombo>b__42_0(int value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x71B71C Offset: 0x71B71C VA: 0x71B71C
		// // RVA: 0x18D5C94 Offset: 0x18D5C94 VA: 0x18D5C94
		// private bool <Co_CountUpCombo>b__42_1() { }

		// [CompilerGeneratedAttribute] // RVA: 0x71B72C Offset: 0x71B72C VA: 0x71B72C
		// // RVA: 0x18D5C9C Offset: 0x18D5C9C VA: 0x18D5C9C
		// private void <Co_CountUpCombo>b__42_2(int value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x71B73C Offset: 0x71B73C VA: 0x71B73C
		// // RVA: 0x18D5CDC Offset: 0x18D5CDC VA: 0x18D5CDC
		// private bool <Co_CountUpCombo>b__42_3() { }

		// [CompilerGeneratedAttribute] // RVA: 0x71B74C Offset: 0x71B74C VA: 0x71B74C
		// // RVA: 0x18D5CE4 Offset: 0x18D5CE4 VA: 0x18D5CE4
		// private void <Co_CountUpScore>b__43_0(int value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x71B75C Offset: 0x71B75C VA: 0x71B75C
		// // RVA: 0x18D5D24 Offset: 0x18D5D24 VA: 0x18D5D24
		// private bool <Co_CountUpScore>b__43_1() { }

		// [CompilerGeneratedAttribute] // RVA: 0x71B76C Offset: 0x71B76C VA: 0x71B76C
		// // RVA: 0x18D5D2C Offset: 0x18D5D2C VA: 0x18D5D2C
		// private void <Co_CountUpScore>b__43_2(int value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x71B77C Offset: 0x71B77C VA: 0x71B77C
		// // RVA: 0x18D5D6C Offset: 0x18D5D6C VA: 0x18D5D6C
		// private bool <Co_CountUpScore>b__43_3() { }
	}
}
