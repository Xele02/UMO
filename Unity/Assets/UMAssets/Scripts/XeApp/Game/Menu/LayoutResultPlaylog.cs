using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.RhythmGame;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutResultPlaylog : LayoutUGUIScriptBase
	{
		private class HintData
		{
			public int id; // 0x8
			private Func<RhythmGamePlayLog, bool> func; // 0xC
			public int priority; // 0x10
			public bool is_special; // 0x14

			// RVA: 0x1D01998 Offset: 0x1D01998 VA: 0x1D01998
			public HintData(int id, Func<RhythmGamePlayLog, bool> func, int prio, bool is_sp) { }

			// // RVA: 0x1D019D0 Offset: 0x1D019D0 VA: 0x1D019D0
			// public bool IsCheckHint(RhythmGamePlayLog playlog) { }
		}

		private static readonly string GRAPH_PARENT_OBJ = "sw_playlog_in (AbsoluteLayout)/sw_playlog_set (AbsoluteLayout)"; // 0x0
		private static readonly int GRAPH_COUNT = 10; // 0x4
		private static readonly float GRAPH_PARTS_FADE_TIME = 0.5f; // 0x8
		private static readonly LayoutResultPlaylog.HintData[] hintDataTable = new LayoutResultPlaylog.HintData[12]
		{
			new HintData(0, CheckHintFunc_FoldStaus, 1, true),
			new HintData(1, CheckHintFunc_SupportStatus, 1, true),
			new HintData(2, CheckHintFunc_MissBad, 2, false),
			new HintData(3, CheckHintFunc_PlateLevel, 2, false),
			new HintData(4, CheckHintFunc_PlateRarity, 2, false),
			new HintData(5, CheckHintFunc_MaxCombo, 3, false),
			new HintData(6, CheckHintFunc_ActiveSkillOther, 2, false),
			new HintData(7, CheckHintFunc_PlateCompatible, 4, false),
			new HintData(8, CheckHintFunc_ValkyrieMode, 4, true),
			new HintData(9, CheckHintFunc_DivaMode, 4, true),
			new HintData(10, CheckHintFunc_SuperDivaMode, 4, true),
			new HintData(11, CheckHintFunc_ActiveSkillRecovery, 2, false)
		}; // 0xC
		public RhythmGamePlayLog playlog; // 0x14
		public Action onFinished; // 0x18
		public Action onDetailButton; // 0x1C
		private AbsoluteLayout layoutRoot; // 0x20
		private AbsoluteLayout layoutDetailButton; // 0x24
		private AbsoluteLayout layoutHintAnim; // 0x28
		private ActionButton detailButton; // 0x2C
		private bool isStartInitialize; // 0x30
		private GameObject[] graphObjects = new GameObject[GRAPH_COUNT]; // 0x34
		private GameObject[] graphObjectsHL = new GameObject[GRAPH_COUNT]; // 0x38
		private Vector2 graphSize = Vector2.zero; // 0x3C
		private Vector2 graphSizeHL = Vector2.zero; // 0x44
		private int endTime; // 0x4C
		private int showHintId = -1; // 0x50
		private bool isShowHit; // 0x54
		private bool isHintTouch; // 0x55

		// RVA: 0x18E8928 Offset: 0x18E8928 VA: 0x18E8928
		private void Start()
		{
			return;
		}

		// RVA: 0x18E892C Offset: 0x18E892C VA: 0x18E892C
		private void Update()
		{
			return;
		}

		// RVA: 0x18E8930 Offset: 0x18E8930 VA: 0x18E8930 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			layoutDetailButton = layout.FindViewById("sw_btn_log_detail") as AbsoluteLayout;
			layoutDetailButton.enabled = false;
			if(!isStartInitialize)
				StartCoroutine(Co_Initialize(layout, uvMan));
			return IsLoaded();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71CC6C Offset: 0x71CC6C VA: 0x71CC6C
		// // RVA: 0x18E8A54 Offset: 0x18E8A54 VA: 0x18E8A54
		private IEnumerator Co_Initialize(Layout layout, TexUVListManager uvMan)
		{
			string bundle_name; // 0x18
			AssetBundleLoadAssetOperation operation; // 0x1C
			Transform parent; // 0x20

			//0x1D00758
			isStartInitialize = true;
			bundle_name = PopupPlaylogDetail.BUNDLE_NAME;
			operation = AssetBundleManager.LoadAssetAsync(bundle_name, "PlaylogBarObj", typeof(GameObject));
			yield return operation;

			GameObject g = operation.GetAsset<GameObject>();
			parent = transform.Find(GRAPH_PARENT_OBJ);
			graphSize = parent.Find("graph_01 (AbsoluteLayout)").GetComponent<RectTransform>().sizeDelta;
			graphSizeHL = parent.Find("graph_01_hl (AbsoluteLayout)").GetComponent<RectTransform>().sizeDelta;
			for(int i = 0; i < GRAPH_COUNT; i++)
			{
				graphObjects[i] = Instantiate(g);
				graphObjectsHL[i] = Instantiate(g);
			}
			yield return null;
			AssetBundleManager.UnloadAssetBundle(bundle_name, false);
			yield return null;
			if(playlog != null)
			{
				List<RhythmGamePlayLog.NoteData>[] data = new List<RhythmGamePlayLog.NoteData>[GRAPH_COUNT];
				for(int i = 0; i < GRAPH_COUNT; i++)
				{
					data[i] = new List<RhythmGamePlayLog.NoteData>();
				}
				for(int i = 0; i < playlog.noteDataList.Count; i++)
				{
					endTime = Mathf.Max(endTime, playlog.noteDataList[i].millisec);
				}
				for(int i = 0; i < playlog.noteDataList.Count; i++)
				{
					data[Mathf.Min(Mathf.RoundToInt(playlog.noteDataList[i].millisec / endTime * GRAPH_COUNT), GRAPH_COUNT - 1)].Add(playlog.noteDataList[i]);
				}
				for(int i = 0; i < GRAPH_COUNT; i++)
				{
					graphObjects[i].GetComponent<ResultPlaylogBarController>().Setup(0, graphSize, data[i], endTime);
					graphObjectsHL[i].GetComponent<ResultPlaylogBarController>().Setup(0, graphSizeHL, data[i], endTime);
				}
				yield return null;
				yield return new WaitWhile(() => {
					//0x18ED0B4
					for(int i = 0; i < GRAPH_COUNT; i++)
					{
						if(graphObjects[i].GetComponent<ResultPlaylogBarController>().IsPlayingChangeGraphAnim())
							return true;
						if(graphObjectsHL[i].GetComponent<ResultPlaylogBarController>().IsPlayingChangeGraphAnim())
							return true;
					}
					return false;
				});
				for(int i = 0; i < GRAPH_COUNT; i++)
				{
					graphObjects[i].transform.SetParent(parent.Find(string.Format("graph_{0:00} (AbsoluteLayout)", i + 1)), false);
					graphObjectsHL[i].transform.SetParent(parent.Find(string.Format("graph_{0:00}_hl (AbsoluteLayout)", i + 1)), false);
				}
			}
			layoutRoot = layout.FindViewById("sw_playlog_in") as AbsoluteLayout;
			layoutHintAnim = layout.FindViewByExId("sw_playlog_set_sw_hint_anim") as AbsoluteLayout;
			detailButton = GetComponentInChildren<ActionButton>(true);
			detailButton.AddOnClickCallback(() => {
				//0x18ED288
				if(onDetailButton != null)
					onDetailButton();
			});
			Loaded();
		}

		// // RVA: 0x18E8AF8 Offset: 0x18E8AF8 VA: 0x18E8AF8
		// public void Setup(LayoutResultPlaylogGraphParts graph_parts, NGJOPPIGCPM view_data) { }

		// // RVA: 0x18E955C Offset: 0x18E955C VA: 0x18E955C
		// private void SetupModeObject(List<GameObject> range_list, List<GameObject> line_list, List<GameObject> icon_list, RhythmGamePlayLog.ModeData data, LayoutResultPlaylogGraphParts.PartsData.ModeParts parts, GameObject line_obj, RectTransform parent, int end_time, bool is_show_end_line = True) { }

		// // RVA: 0x18EA670 Offset: 0x18EA670 VA: 0x18EA670
		// private void SetupObject(GameObject obj, RectTransform parent, float pos) { }

		// // RVA: 0x18E9E60 Offset: 0x18E9E60 VA: 0x18E9E60
		// private int CheckShowHint(NGJOPPIGCPM view_data) { }

		// // RVA: 0x18EA87C Offset: 0x18EA87C VA: 0x18EA87C
		// public void SkipAnim() { }

		// // RVA: 0x18EAB18 Offset: 0x18EAB18 VA: 0x18EAB18
		// public void StartAnim(RhythmGameConsts.NoteResult type, float time) { }

		// // RVA: 0x18EA884 Offset: 0x18EA884 VA: 0x18EA884
		public void FinishAnim(bool is_skip = false)
		{
			TodoLogger.Log(0, "FinishAnim");
		}

		// // RVA: 0x18EB00C Offset: 0x18EB00C VA: 0x18EB00C
		public void EnterHint()
		{
			if(showHintId > -1 && !isShowHit)
			{
				StartCoroutine(Co_EnterHint());
				isShowHit = true;
				return;
			}
			layoutDetailButton.enabled = true;
			if(onFinished != null)
				onFinished();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71CCE4 Offset: 0x71CCE4 VA: 0x71CCE4
		// // RVA: 0x18EB098 Offset: 0x18EB098 VA: 0x18EB098
		private IEnumerator Co_EnterHint()
		{
			//0x1D004DC
			layoutHintAnim.StartChildrenAnimGoStop("go_in", "st_in");
			yield return null;
			yield return new WaitWhile(() => {
				//0x18ED398
				return layoutHintAnim.IsPlayingChildren();
			});
			layoutDetailButton.enabled = true;
			if(onFinished != null)
				onFinished();
		}

		// // RVA: 0x18EACF0 Offset: 0x18EACF0 VA: 0x18EACF0
		// private void ShowGraphParts() { }

		// // RVA: 0x18EA3AC Offset: 0x18EA3AC VA: 0x18EA3AC
		// private void HideGraphParts() { }

		// [IteratorStateMachineAttribute] // RVA: 0x71CD5C Offset: 0x71CD5C VA: 0x71CD5C
		// // RVA: 0x18EAF84 Offset: 0x18EAF84 VA: 0x18EAF84
		// private IEnumerator Co_EnterGraphParts() { }

		// // RVA: 0x18EA63C Offset: 0x18EA63C VA: 0x18EA63C
		public void SetActiveDetailButton(bool is_active)
		{
			detailButton.Disable = !is_active;
		}

		// // RVA: 0x18EB120 Offset: 0x18EB120 VA: 0x18EB120
		// public void SetActiveHintButton(bool is_active) { }

		// // RVA: 0x18EB128 Offset: 0x18EB128 VA: 0x18EB128
		private static bool CheckHintFunc_FoldStaus(RhythmGamePlayLog playlog)
		{
			TodoLogger.Log(0, "CheckHintFunc_FoldStaus");
			return false;
		}

		// // RVA: 0x18EB14C Offset: 0x18EB14C VA: 0x18EB14C
		private static bool CheckHintFunc_SupportStatus(RhythmGamePlayLog playlog)
		{
			TodoLogger.Log(0, "CheckHintFunc_SupportStatus");
			return false;
		}

		// // RVA: 0x18EB198 Offset: 0x18EB198 VA: 0x18EB198
		private static bool CheckHintFunc_MissBad(RhythmGamePlayLog playlog)
		{
			TodoLogger.Log(0, "CheckHintFunc_MissBad");
			return false;
		}

		// // RVA: 0x18EB2C8 Offset: 0x18EB2C8 VA: 0x18EB2C8
		private static bool CheckHintFunc_PlateLevel(RhythmGamePlayLog playlog)
		{
			TodoLogger.Log(0, "CheckHintFunc_PlateLevel");
			return false;
		}

		// // RVA: 0x18EB694 Offset: 0x18EB694 VA: 0x18EB694
		private static bool CheckHintFunc_PlateRarity(RhythmGamePlayLog playlog)
		{
			TodoLogger.Log(0, "CheckHintFunc_PlateRarity");
			return false;
		}

		// // RVA: 0x18EB9BC Offset: 0x18EB9BC VA: 0x18EB9BC
		private static bool CheckHintFunc_MaxCombo(RhythmGamePlayLog playlog)
		{
			TodoLogger.Log(0, "CheckHintFunc_MaxCombo");
			return false;
		}

		// // RVA: 0x18EBB50 Offset: 0x18EBB50 VA: 0x18EBB50
		private static bool CheckHintFunc_ActiveSkillOther(RhythmGamePlayLog playlog)
		{
			TodoLogger.Log(0, "CheckHintFunc_ActiveSkillOther");
			return false;
		}

		// // RVA: 0x18EBEBC Offset: 0x18EBEBC VA: 0x18EBEBC
		private static bool CheckHintFunc_ActiveSkillRecovery(RhythmGamePlayLog playlog)
		{
			TodoLogger.Log(0, "CheckHintFunc_ActiveSkillRecovery");
			return false;
		}

		// // RVA: 0x18EC18C Offset: 0x18EC18C VA: 0x18EC18C
		private static bool CheckHintFunc_PlateCompatible(RhythmGamePlayLog playlog)
		{
			TodoLogger.Log(0, "CheckHintFunc_PlateCompatible");
			return false;
		}

		// // RVA: 0x18EC474 Offset: 0x18EC474 VA: 0x18EC474
		private static bool CheckHintFunc_ValkyrieMode(RhythmGamePlayLog playlog)
		{
			TodoLogger.Log(0, "CheckHintFunc_ValkyrieMode");
			return false;
		}

		// // RVA: 0x18EC4A4 Offset: 0x18EC4A4 VA: 0x18EC4A4
		private static bool CheckHintFunc_DivaMode(RhythmGamePlayLog playlog)
		{
			TodoLogger.Log(0, "CheckHintFunc_DivaMode");
			return false;
		}

		// // RVA: 0x18EC4F0 Offset: 0x18EC4F0 VA: 0x18EC4F0
		private static bool CheckHintFunc_SuperDivaMode(RhythmGamePlayLog playlog)
		{
			TodoLogger.Log(0, "CheckHintFunc_SuperDivaMode");
			return false;
		}

		// [CompilerGeneratedAttribute] // RVA: 0x71CDF4 Offset: 0x71CDF4 VA: 0x71CDF4
		// // RVA: 0x18ED29C Offset: 0x18ED29C VA: 0x18ED29C
		// private void <Setup>b__25_2() { }
	}
}
