using mcrs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.RhythmGame;
using XeSys;
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
			public HintData(int id, Func<RhythmGamePlayLog, bool> func, int prio, bool is_sp)
			{
				this.id = id;
				this.func = func;
				priority = prio;
				is_special = is_sp;
			}

			// // RVA: 0x1D019D0 Offset: 0x1D019D0 VA: 0x1D019D0
			public bool IsCheckHint(RhythmGamePlayLog playlog)
			{
				if (func != null)
					return func(playlog);
				return false;
			}
		}

		private static readonly string GRAPH_PARENT_OBJ = "sw_playlog_in (AbsoluteLayout)/sw_playlog_set (AbsoluteLayout)"; // 0x0
		private static readonly int GRAPH_COUNT = 10; // 0x4
		private static readonly float GRAPH_PARTS_FADE_TIME = 0.5f; // 0x8
		private static readonly HintData[] hintDataTable = new LayoutResultPlaylog.HintData[12]
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
				this.StartCoroutineWatched(Co_Initialize(layout, uvMan));
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
			yield return Co.R(operation);

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
					data[Mathf.Min((int)(playlog.noteDataList[i].millisec * 1.0f / endTime * GRAPH_COUNT), GRAPH_COUNT - 1)].Add(playlog.noteDataList[i]);
				}
				for(int i = 0; i < GRAPH_COUNT; i++)
				{
					graphObjects[i].GetComponent<ResultPlaylogBarController>().Setup(0, graphSize, data[i], endTime);
					graphObjects[i].GetComponent<ResultPlaylogBarController>().ChangeGraphType(PopupPlaylogDetail.GraphType.Hide);
					graphObjectsHL[i].GetComponent<ResultPlaylogBarController>().Setup(0, graphSizeHL, data[i], endTime);
					graphObjectsHL[i].GetComponent<ResultPlaylogBarController>().ChangeGraphType(PopupPlaylogDetail.GraphType.Hide);
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
		public void Setup(LayoutResultPlaylogGraphParts graph_parts, NGJOPPIGCPM_ResultData view_data)
		{
			RectTransform t = transform.Find(GRAPH_PARENT_OBJ).GetComponent<RectTransform>();
			RectTransform t2 = t.GetComponent<RectTransform>().Find("devision_area (AbsoluteLayout)").GetComponent<RectTransform>();
			RectTransform t3 = t.GetComponent<RectTransform>().Find("sw_btn_log_detail (AbsoluteLayout)").GetComponent<RectTransform>();
			t2.SetSiblingIndex(t3.GetSiblingIndex() - 1);
			List<GameObject> lg = new List<GameObject>();
			List<GameObject> lg2 = new List<GameObject>();
			List<GameObject> lg3 = new List<GameObject>();
			SetupModeObject(lg, lg2, lg3, 
				new RhythmGamePlayLog.ModeData() { type = RhythmGameMode.Type.Normal, beginMillisec = 0, endMillisec = playlog.valkyrieModeData.beginMillisec }, 
				graph_parts.GetPartsData(0).mode_parts[0], graph_parts.GetPartsData(0).division_line, t2, endTime, true);
			SetupModeObject(lg, lg2, lg3,
				new RhythmGamePlayLog.ModeData() { type = playlog.valkyrieModeData.type, beginMillisec = playlog.valkyrieModeData.beginMillisec, endMillisec = playlog.divaModeData.beginMillisec },
				playlog.valkyrieModeData.type != RhythmGameMode.Type.Valkyrie ? graph_parts.GetPartsData(0).mode_parts[0] : graph_parts.GetPartsData(0).mode_parts[1], graph_parts.GetPartsData(0).division_line, t2, endTime, true);
			SetupModeObject(lg, lg2, lg3, playlog.divaModeData,
				playlog.divaModeData.type == RhythmGameMode.Type.AwakenDiva ? graph_parts.GetPartsData(0).mode_parts[3] : (playlog.divaModeData.type == RhythmGameMode.Type.Diva ? graph_parts.GetPartsData(0).mode_parts[2] : graph_parts.GetPartsData(0).mode_parts[0]), graph_parts.GetPartsData(0).division_line, t2, endTime, false);
			for(int i = 0; i < lg2.Count; i++)
			{
				lg2[i].transform.SetAsLastSibling();
			}
			for (int i = 0; i < lg3.Count; i++)
			{
				lg3[i].transform.SetAsLastSibling();
			}
			showHintId = CheckShowHint(view_data);
			if(showHintId > -1)
			{
				Text txt = GetComponentsInChildren<Text>(true).Where((Text _) =>
				{
					//0x18ED440
					return _.name == "hinttxt (TextView)";
				}).First();
				txt.text = MessageManager.Instance.GetBank("menu").GetMessageByLabel(string.Format("result_playlog_hint_{0:000}", showHintId + 1));
				txt.horizontalOverflow = HorizontalWrapMode.Wrap;
				if(!string.IsNullOrEmpty(RuntimeSettings.CurrentSettings.Language))
				{
					txt.verticalOverflow = VerticalWrapMode.Truncate;
					txt.resizeTextForBestFit = true;
					txt.resizeTextMaxSize = txt.fontSize;
				}
				Button b = GetComponentsInChildren<Button>(true).Where((Button _) =>
				{
					//0x18ED4C0
					return _.name == "hit_check (AbsoluteLayout)";
				}).First();
				b.onClick.AddListener(() =>
				{
					//0x18ED29C
					if(isHintTouch && isShowHit)
					{
						SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
						layoutHintAnim.StartChildrenAnimGoStop("go_out", "st_out");
						isShowHit = false;
						showHintId = -1;
					}
				});
			}
			layoutRoot.StartChildrenAnimGoStop("st_in");
			HideGraphParts();
			SetActiveDetailButton(false);
		}

		// // RVA: 0x18E955C Offset: 0x18E955C VA: 0x18E955C
		private void SetupModeObject(List<GameObject> range_list, List<GameObject> line_list, List<GameObject> icon_list, RhythmGamePlayLog.ModeData data, LayoutResultPlaylogGraphParts.PartsData.ModeParts parts, GameObject line_obj, RectTransform parent, int end_time, bool is_show_end_line = true)
		{
			float f = Mathf.Clamp(data.beginMillisec * 1.0f / end_time, 0, 1);
			float f2 = Mathf.Clamp(data.endMillisec * 1.0f / end_time, 0, 1);
			float f5 = Mathf.Clamp(Mathf.Lerp(f, f2, 0.5f), 0, 1);
			GameObject line = Instantiate(parts.line);
			SetupObject(line, parent, f5 * parent.sizeDelta.x);
			range_list.Add(line);
			GameObject go2 = null;
			if(is_show_end_line)
			{
				go2 = Instantiate(line_obj);
			}
			if(go2 != null)
			{
				SetupObject(go2, parent, f2 * parent.sizeDelta.x);
				line_list.Add(go2);
			}
			GameObject go3 = null;
			if(parts.icon != null)
			{
				go3 = Instantiate(parts.icon);
			}
			if(go3 != null)
			{
				SetupObject(go3, parent, f5 * parent.sizeDelta.x + go3.GetComponent<RectTransform>().anchoredPosition.x);
				icon_list.Add(go3);
			}
			if(go2 != null)
			{
				RectTransform r = go2.GetComponent<RectTransform>();
				r.anchoredPosition = new Vector2(r.anchoredPosition.x + r.sizeDelta.x * -0.5f, (parent.sizeDelta.y - r.sizeDelta.y) * -0.5f);
			}
			RectTransform r2 = line.GetComponent<RectTransform>();
			r2.sizeDelta = new Vector2(f * parent.sizeDelta.x - f2 * parent.sizeDelta.x, r2.sizeDelta.y);
			r2.anchoredPosition = new Vector2(f + r2.sizeDelta.x * -0.5f, -(parent.sizeDelta.y - r2.sizeDelta.y));
			if(go3 != null)
			{
				RectTransform r3 = go3.GetComponent<RectTransform>();
				r3.anchoredPosition = new Vector2(r3.anchoredPosition.x, r2.sizeDelta.y * 0.5f - parent.sizeDelta.y);
			}
			if(go2 != null)
			{
				go2.SetActive(is_show_end_line);
			}
		}

		// // RVA: 0x18EA670 Offset: 0x18EA670 VA: 0x18EA670
		private void SetupObject(GameObject obj, RectTransform parent, float pos)
		{
			Vector2 size = parent.sizeDelta;
			obj.transform.SetParent(parent, false);
			RectTransform rt = obj.GetComponent<RectTransform>();
			rt.anchoredPosition = new Vector2(0, 0) * 0.5f; // ??
			rt.anchoredPosition += new Vector2(pos, 0);
		}

		// // RVA: 0x18E9E60 Offset: 0x18E9E60 VA: 0x18E9E60
		private int CheckShowHint(NGJOPPIGCPM_ResultData view_data)
		{
			int minPrio = 999;
			int maxPrio = 0;
			for(int i = 0; i < hintDataTable.Length; i++)
			{
				minPrio = Mathf.Min(minPrio, hintDataTable[i].priority);
				maxPrio = Mathf.Max(maxPrio, hintDataTable[i].priority);
			}
			int find_prio = minPrio;
			for(; find_prio <= maxPrio; find_prio++)
			{
				List<HintData> hints2 = new List<HintData>();
				HintData[] hints = hintDataTable.Where((HintData _) =>
				{
					//0x18ED540
					return _.priority == find_prio;
				}).ToArray();
				for(int j = 0; j < hints.Length; j++)
				{
					if(view_data.PENICOGGNLF_RankScore < 2)
					{
						if(hints[j].IsCheckHint(playlog))
						{
							hints2.Add(hints[j]);
						}
					}
					else
					{
						if(hints[j].is_special && hints[j].IsCheckHint(playlog))
						{
							hints2.Add(hints[j]);
						}
					}
				}
				if (hints2.Count > 0)
				{
					int idx = UnityEngine.Random.Range(0, hints2.Count);
					return hints2[idx].id;
				}
			}
			return -1;
		}

		// // RVA: 0x18EA87C Offset: 0x18EA87C VA: 0x18EA87C
		// public void SkipAnim() { }

		// // RVA: 0x18EAB18 Offset: 0x18EAB18 VA: 0x18EAB18
		public void StartAnim(RhythmGameConsts.NoteResult type, float time)
		{
			for(int i = 0; i < GRAPH_COUNT; i++)
			{
				graphObjects[i].GetComponent<ResultPlaylogBarController>().EnterGraphAnim(type, time);
				graphObjectsHL[i].GetComponent<ResultPlaylogBarController>().EnterGraphAnim(type, time);
			}
		}

		// // RVA: 0x18EA884 Offset: 0x18EA884 VA: 0x18EA884
		public void FinishAnim(bool is_skip = false)
		{
			for(int i = 0; i < GRAPH_COUNT; i++)
			{
				graphObjects[i].GetComponent<ResultPlaylogBarController>().FinishAnim();
				graphObjectsHL[i].GetComponent<ResultPlaylogBarController>().FinishAnim();
			}
			if(!is_skip)
			{
				this.StartCoroutineWatched(Co_EnterGraphParts());
			}
			else
			{
				layoutRoot.StartChildrenAnimGoStop("st_in");
				if(showHintId > -1 && !isShowHit)
				{
					layoutHintAnim.StartChildrenAnimGoStop("st_in");
					isShowHit = true;
				}
				layoutDetailButton.enabled = true;
				ShowGraphParts();
			}
		}

		// // RVA: 0x18EB00C Offset: 0x18EB00C VA: 0x18EB00C
		public void EnterHint()
		{
			if(showHintId > -1 && !isShowHit)
			{
				this.StartCoroutineWatched(Co_EnterHint());
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
		private void ShowGraphParts()
		{
			Transform t = transform.Find(GRAPH_PARENT_OBJ);
			RectTransform rt = t.GetComponent<RectTransform>();
			RectTransform rt2 = t.Find("devision_area (AbsoluteLayout)").GetComponent<RectTransform>();
			RawImageEx[] imgs = rt2.GetComponentsInChildren<RawImageEx>(true);
			for (int i = 0; i < imgs.Length; i++)
			{
				Color col = imgs[i].color;
				col.a = 1;
				imgs[i].color = col;
			}
		}

		// // RVA: 0x18EA3AC Offset: 0x18EA3AC VA: 0x18EA3AC
		private void HideGraphParts()
		{
			Transform t = transform.Find(GRAPH_PARENT_OBJ);
			RectTransform rt = t.GetComponent<RectTransform>();
			RectTransform rt2 = t.Find("devision_area (AbsoluteLayout)").GetComponent<RectTransform>();
			RawImageEx[] imgs = rt2.GetComponentsInChildren<RawImageEx>(true);
			for(int i = 0; i < imgs.Length; i++)
			{
				Color col = imgs[i].color;
				col.a = 0;
				imgs[i].color = col;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71CD5C Offset: 0x71CD5C VA: 0x71CD5C
		// // RVA: 0x18EAF84 Offset: 0x18EAF84 VA: 0x18EAF84
		private IEnumerator Co_EnterGraphParts()
		{
			//0x1D00150
			RectTransform t = transform.Find(GRAPH_PARENT_OBJ).GetComponent<RectTransform>();
			RectTransform t2 = t.Find("devision_area (AbsoluteLayout)").GetComponent<RectTransform>();
			RawImageEx[] images = t2.GetComponentsInChildren<RawImageEx>(true);
			float fade_time = GRAPH_PARTS_FADE_TIME;
			float elapsed_time = 0;
			yield return new WaitWhile(() =>
			{
				//0x18ED580
				elapsed_time += Time.deltaTime;
				float r = elapsed_time / fade_time;
				if(r < 1)
				{
					for(int i = 0; i < images.Length; i++)
					{
						Color col = images[i].color;
						col.a = r;
						images[i].color = col;
					}
				}
				return r < 1;
			});
			ShowGraphParts();
		}

		// // RVA: 0x18EA63C Offset: 0x18EA63C VA: 0x18EA63C
		public void SetActiveDetailButton(bool is_active)
		{
			detailButton.Disable = !is_active;
		}

		// // RVA: 0x18EB120 Offset: 0x18EB120 VA: 0x18EB120
		public void SetActiveHintButton(bool is_active)
		{
			isHintTouch = is_active;
		}

		// // RVA: 0x18EB128 Offset: 0x18EB128 VA: 0x18EB128
		private static bool CheckHintFunc_FoldStaus(RhythmGamePlayLog playlog)
		{
			return playlog.isImpossibleValkyrieMode;
		}

		// // RVA: 0x18EB14C Offset: 0x18EB14C VA: 0x18EB14C
		private static bool CheckHintFunc_SupportStatus(RhythmGamePlayLog playlog)
		{
			if(playlog.valkyrieModeData.type == RhythmGameMode.Type.Valkyrie)
			{
				if (playlog.divaModeData.type == RhythmGameMode.Type.AwakenDiva ||
					playlog.divaModeData.type == RhythmGameMode.Type.Diva)
					return false;
				return playlog.isImpossibleDivaMode;
			}
			return false;
		}

		// // RVA: 0x18EB198 Offset: 0x18EB198 VA: 0x18EB198
		private static bool CheckHintFunc_MissBad(RhythmGamePlayLog playlog)
		{
			int cnt = 0;
			for(int i = 0; i < playlog.noteDataList.Count; i++)
			{
				if (playlog.noteDataList[i].result < RhythmGameConsts.NoteResult.Good)
					cnt++;
			}
			return 0.03f <= cnt * 1.0f / playlog.noteDataList.Count;
		}

		// // RVA: 0x18EB2C8 Offset: 0x18EB2C8 VA: 0x18EB2C8
		private static bool CheckHintFunc_PlateLevel(RhythmGamePlayLog playlog)
		{
			LDDDBPNGGIN_Game gameDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game;
			List<GCIJNCFDNON_SceneInfo> scenes = GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes;
			GameSetupData.TeamInfo team = Database.Instance.gameSetup.teamInfo;
			for(int i = 0; i < team.divaList.Length; i++)
			{
				for(int j = 0; j < team.divaList[i].sceneIdList.Length; j++)
				{
					int sceneId = team.divaList[i].sceneIdList[j] - 1;
					if (sceneId > 0 && sceneId < scenes.Count)
					{
						GCIJNCFDNON_SceneInfo scene = scenes[sceneId];
						int a = gameDb.LAGGGIEIPEG(scene.JKGFBFPIMGA_Rarity, scene.CGIELKDLHGE_GetEvolveId() > 1, scene.MCCIFLKCNKO_Feed);
						if (scene.CIEOBFIIPLD_SceneLevel <= a / 3) // ??
							return true;
					}
				}
			}
			return false;
		}

		// // RVA: 0x18EB694 Offset: 0x18EB694 VA: 0x18EB694
		private static bool CheckHintFunc_PlateRarity(RhythmGamePlayLog playlog)
		{
			LDDDBPNGGIN_Game gameDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game;
			List<GCIJNCFDNON_SceneInfo> scenes = GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes;
			GameSetupData.TeamInfo team = Database.Instance.gameSetup.teamInfo;

			int cnt = 0;
			for (int i = 0; i < team.divaList.Length; i++)
			{
				for (int j = 0; j < team.divaList[i].sceneIdList.Length; j++)
				{
					int sceneId = team.divaList[i].sceneIdList[j] - 1;
					if (sceneId > 0 && sceneId < scenes.Count)
					{
						GCIJNCFDNON_SceneInfo scene = scenes[sceneId];
						if (scene.EKLIPGELKCL_SceneRarity > 3)
							cnt++;
					}
				}
			}
			return cnt < 6;
		}

		// // RVA: 0x18EB9BC Offset: 0x18EB9BC VA: 0x18EB9BC
		private static bool CheckHintFunc_MaxCombo(RhythmGamePlayLog playlog)
		{
			int combo = 0;
			for(int i = 0; i < playlog.noteDataList.Count; i++)
			{
				if (playlog.noteDataList[i].result > RhythmGameConsts.NoteResult.Miss)
					combo++;
				else
					combo = 0;
			}
			return combo * 1.0f / playlog.noteDataList.Count < 0.3f;
		}

		// // RVA: 0x18EBB50 Offset: 0x18EBB50 VA: 0x18EBB50
		private static bool CheckHintFunc_ActiveSkillOther(RhythmGamePlayLog playlog)
		{
			GameSetupData.TeamInfo.DivaInfo[] divaList = Database.Instance.gameSetup.teamInfo.divaList;
			if(divaList != null)
			{
				if(divaList[0] != null && divaList[0].activeSkillId > 0)
				{
					JNKEEAOKNCI_Skill skillDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill;
					CDNKOFIELMK skill = skillDb.PABCHCAAEAA_ActiveSkills[divaList[0].activeSkillId - 1];
					for(int i = 0; i < skill.EGLDFPILJLG_BuffEffectType.Length; i++)
					{
						if ((skill.EGLDFPILJLG_BuffEffectType[i] | 8) == 10) // 3, 8, 10?
							return false;
					}
					for(int i = 0; i < playlog.skillDataList.Count; i++)
					{
						if (playlog.skillDataList[i].isActive)
							return false;
					}
					return true;
				}
			}
			return false;
		}

		// // RVA: 0x18EBEBC Offset: 0x18EBEBC VA: 0x18EBEBC
		private static bool CheckHintFunc_ActiveSkillRecovery(RhythmGamePlayLog playlog)
		{
			GameSetupData.TeamInfo.DivaInfo[] divaList = Database.Instance.gameSetup.teamInfo.divaList;
			if (divaList != null)
			{
				if (divaList[0] != null && divaList[0].activeSkillId > 0)
				{
					JNKEEAOKNCI_Skill skillDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill;
					CDNKOFIELMK skill = skillDb.PABCHCAAEAA_ActiveSkills[divaList[0].activeSkillId - 1];
					for (int i = 0; i < skill.EGLDFPILJLG_BuffEffectType.Length; i++)
					{
						if ((skill.EGLDFPILJLG_BuffEffectType[i] | 8) == 10) // 3, 8, 10?
							return false;
					}
					return true;
				}
			}
			return false;
		}

		// // RVA: 0x18EC18C Offset: 0x18EC18C VA: 0x18EC18C
		private static bool CheckHintFunc_PlateCompatible(RhythmGamePlayLog playlog)
		{
			List<GCIJNCFDNON_SceneInfo> scenes = GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes;
			GameSetupData.TeamInfo team = Database.Instance.gameSetup.teamInfo;

			int cnt = 0;
			for (int i = 0; i < team.divaList.Length; i++)
			{
				for (int j = 0; j < team.divaList[i].sceneIdList.Length; j++)
				{
					int sceneId = team.divaList[i].sceneIdList[j] - 1;
					if (sceneId > 0 && sceneId < scenes.Count)
					{
						GCIJNCFDNON_SceneInfo scene = scenes[sceneId];
						if (!scene.DCLLIDMKNGO_IsDivaCompatible(team.divaList[i].divaId))
							cnt++;
					}
				}
			}
			return cnt > 4;
		}

		// // RVA: 0x18EC474 Offset: 0x18EC474 VA: 0x18EC474
		private static bool CheckHintFunc_ValkyrieMode(RhythmGamePlayLog playlog)
		{
			return playlog.valkyrieModeData.type != RhythmGameMode.Type.Valkyrie;
		}

		// // RVA: 0x18EC4A4 Offset: 0x18EC4A4 VA: 0x18EC4A4
		private static bool CheckHintFunc_DivaMode(RhythmGamePlayLog playlog)
		{
			return playlog.valkyrieModeData.type == RhythmGameMode.Type.Valkyrie && playlog.divaModeData.type != RhythmGameMode.Type.AwakenDiva && playlog.divaModeData.type != RhythmGameMode.Type.Diva;
		}

		// // RVA: 0x18EC4F0 Offset: 0x18EC4F0 VA: 0x18EC4F0
		private static bool CheckHintFunc_SuperDivaMode(RhythmGamePlayLog playlog)
		{
			return playlog.divaModeData.type == RhythmGameMode.Type.Diva;
		}
	}
}
