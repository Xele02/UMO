using mcrs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.RhythmGame;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopupPlaylogDetail : UIBehaviour, IPopupContent
	{
		public enum GraphType
		{
			None = -1,
			Raito = 0,
			Count = 1,
			Num = 2,
			Hide = 3,
			Begin = 0,
			End = 2,
			Default = 0,
		}

		private class PopupPlaylogDetailSetting : PopupSetting
		{
			private PopupPlaylogDetail.ViewPlaylogDetailData m_ViewData; // 0x34
			private List<GameObject> m_ScrollObjList = new List<GameObject>(); // 0x38
			private GameObject m_SelectFrameObj; // 0x3C
			private GameObject m_SkillBalloonObj; // 0x40
			private Vector2 m_GraphBarSize = Vector2.zero; // 0x44
			private Vector2 m_SelectFrameSize = Vector2.zero; // 0x4C
			private Vector2 m_SkillBalloonSize = Vector2.zero; // 0x54

			public ViewPlaylogDetailData GetViewData { get { return m_ViewData; } } //0x160C050
			public List<GameObject> GetScrollObjList { get { return m_ScrollObjList; } } //0x160D110
			public GameObject GetSelectFrameObj { get { return m_SelectFrameObj; } } //0x160E560
			public GameObject GetSkillBalloonObj { get { return m_SkillBalloonObj; } } //0x160C048
			public Vector2 GetGraphBarSize { get { return m_GraphBarSize; } } //0x160D324
			// public Vector2 GetSelectFrameSize { get; } 0x160F46C
			// public Vector2 GetSkillBalloonSize { get; } 0x160F480
			public override string PrefabPath { get { return ""; } } //0x160F494
			public override string BundleName { get { return PopupPlaylogDetail.BUNDLE_NAME; } } //0x160F4F0
			public override string AssetName { get { return "PlaylogDetail"; } } //0x160F57C
			public override bool IsAssetBundle { get { return true; } } //0x160F5D8
			public override bool IsPreload { get { return true; } } //0x160F5E0
			public override GameObject Content { get { return m_content; } } //0x160F5E8

			// // RVA: 0x160F5F0 Offset: 0x160F5F0 VA: 0x160F5F0
			// public void SetContent(GameObject obj) { }

			// [IteratorStateMachineAttribute] // RVA: 0x706F8C Offset: 0x706F8C VA: 0x706F8C
			// // RVA: 0x160F314 Offset: 0x160F314 VA: 0x160F314
			public IEnumerator Co_LoadPopupResource(RhythmGamePlayLog playlog, Action<PopupPlaylogDetail> onfinished)
			{
				int loadCount; // 0x24
				AssetBundleLoadLayoutOperationBase operation; // 0x28
				List<ViewPlaylogDetailData.ViewNoteResultData> list; // 0x2C
				int i; // 0x30
				LayoutUGUIRuntime inst; // 0x34
				LayoutResultPlaylogGraphBar layout; // 0x38

				//0x160F954
				m_ViewData = new ViewPlaylogDetailData();
				m_ViewData.Init(playlog);
				loadCount = 0;
				if(m_content == null)
				{
					operation = AssetBundleManager.LoadLayoutAsync(BundleName, "PlaylogDetail");
					yield return operation;
					yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
					{
						//0x160F798
						m_content = instance;
					}));
					loadCount++;
					yield return null;
					operation = null;
				}
				GameObject graphbar_inst = null;
				operation = AssetBundleManager.LoadLayoutAsync(BundleName, "PlaylogGraphBar");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0x160F7B8
					graphbar_inst = instance;
				}));
				yield return new WaitWhile(() =>
				{
					//0x160F7C0
					return !graphbar_inst.GetComponent<LayoutResultPlaylogGraphBar>().IsLoaded();
				});
				m_GraphBarSize = graphbar_inst.transform.Find("sw_graph_set (AbsoluteLayout)").GetComponent<RectTransform>().sizeDelta;
				loadCount++;
				list = m_ViewData.result_list;
				i = 0;
				while(i < list.Count)
				{
					inst = CopyInstance(graphbar_inst.GetComponent<LayoutUGUIRuntime>());
					layout = inst.GetComponent<LayoutResultPlaylogGraphBar>();
					yield return Co.R(layout.Co_LoadAsset());
					layout.Setup(i, list[i], m_ViewData.max_count);
					m_ScrollObjList.Add(inst.gameObject);
					i++;
				}
				Destroy(graphbar_inst);
				yield return null;
				operation = null;
				operation = AssetBundleManager.LoadLayoutAsync(BundleName, "PlaylogDetailSelect");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0x160F7A0
					m_SelectFrameObj = instance;
				}));
				m_SelectFrameSize = m_SelectFrameObj.GetComponent<RectTransform>().sizeDelta;
				loadCount++;
				yield return null;
				operation = null;

				operation = AssetBundleManager.LoadLayoutAsync(BundleName, "PlaylogDetailSkill");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0x160F7A8
					m_SkillBalloonObj = instance;
				}));
				m_SkillBalloonSize = m_SkillBalloonObj.GetComponent<RectTransform>().sizeDelta;
				loadCount++;
				yield return null;
				LayoutUGUIRuntime runtime = null;
				LayoutResultPlaylogDetail layout_ = m_content.GetComponent<LayoutResultPlaylogDetail>();
				operation = AssetBundleManager.LoadLayoutAsync(BundleName, "root_log_skill_icon_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0x160F864
					runtime = instance.GetComponent<LayoutUGUIRuntime>();
					layout_.SwapScroll.AddScrollObject(instance.GetComponent<PlayLogSkillIconContent>());
				}));
				for(i = 1; i < layout_.SwapScroll.ScrollObjectCount; i++)
				{
					LayoutUGUIRuntime r = CopyInstance(runtime);
					layout_.SwapScroll.AddScrollObject(r.GetComponent<PlayLogSkillIconContent>());
				}
				loadCount++;
				yield return null;
				operation = null;
				for(i = 0; i < loadCount; i++)
				{
					AssetBundleManager.UnloadAssetBundle(BundleName);
				}
				if(onfinished != null)
				{
					onfinished(m_content.GetComponent<PopupPlaylogDetail>());
				}
			}

			// // RVA: 0x160F618 Offset: 0x160F618 VA: 0x160F618
			private LayoutUGUIRuntime CopyInstance(LayoutUGUIRuntime runtime)
			{
				LayoutUGUIRuntime r = Instantiate(runtime);
				r.IsLayoutAutoLoad = false;
				r.UvMan = runtime.UvMan;
				r.Layout = runtime.Layout.DeepClone();
				r.LoadLayout();
				return r;
			}
		}

		public class ViewPlaylogDetailData
		{
			public class ViewNoteResultData
			{
				public int time_range_start; // 0x8
				public int time_range_end; // 0xC
				public int[] result_count = new int[5]; // 0x10
				public List<RhythmGamePlayLog.NoteData> note_list = new List<RhythmGamePlayLog.NoteData>(); // 0x14
				public List<RhythmGamePlayLog.SkillData> skill_list = new List<RhythmGamePlayLog.SkillData>(); // 0x18

				// RVA: 0x1611230 Offset: 0x1611230 VA: 0x1611230
				public void AddNoteData(RhythmGamePlayLog.NoteData data)
				{
					result_count[(int)data.result]++;
					note_list.Add(data);
				}
			}

			public RhythmGamePlayLog playlog_data; // 0x8
			public List<ViewNoteResultData> result_list = new List<ViewNoteResultData>(); // 0xC
			public int max_count; // 0x10

			// // RVA: 0x1610A7C Offset: 0x1610A7C VA: 0x1610A7C
			public void Init(RhythmGamePlayLog playlog)
			{
				playlog_data = playlog;
				for(int i = 0; i < playlog.noteDataList.Count; i++)
				{
					int v = playlog_data.noteDataList[i].millisec / GRAPHBAR_INTERVAL_MILLISECOND;
					if (result_list.Count <= v)
					{
						AddResultData(v + 1 - result_list.Count);
					}
					result_list[v].AddNoteData(playlog.noteDataList[i]);
				}
				for(int i = 0; i < result_list.Count; i++)
				{
					if(max_count < result_list[i].note_list.Count)
					{
						max_count = result_list[i].note_list.Count;
					}
				}
				for(int i = 0; i < playlog_data.skillDataList.Count; i++)
				{
					int v = playlog_data.skillDataList[i].millisec / GRAPHBAR_INTERVAL_MILLISECOND;
					if (result_list.Count <= v)
					{
						AddResultData(v + 1 - result_list.Count);
					}
					result_list[v].skill_list.Add(playlog_data.skillDataList[i]);
				}
			}

			// // RVA: 0x1611078 Offset: 0x1611078 VA: 0x1611078
			private void AddResultData(int count)
			{
				for(int i = 0; i < count; i++)
				{
					ViewNoteResultData data = new ViewNoteResultData();
					data.time_range_start = GRAPHBAR_INTERVAL_SECOND * result_list.Count;
					data.time_range_end = GRAPHBAR_INTERVAL_SECOND * (result_list.Count + 1);
					result_list.Add(data);
				}
			}
		}

		public static readonly string BUNDLE_NAME = "ly/023.xab"; // 0x0
		public static readonly int GRAPHBAR_INTERVAL_SECOND = 10; // 0x4
		public static readonly int GRAPHBAR_INTERVAL_MILLISECOND = GRAPHBAR_INTERVAL_SECOND * 1000; // 0x8
		private static PopupPlaylogDetailSetting sm_Setting = null; // 0xC
		private LayoutResultPlaylogDetail m_MainLayout; // 0x10
		private GraphType m_GraphType = GraphType.None; // 0x14
		private float m_ScrollAreaWidth; // 0x18
		private int m_SelectGraph = -1; // 0x1C

		public Transform Parent { get; private set; } // 0xC

		// [IteratorStateMachineAttribute] // RVA: 0x706F14 Offset: 0x706F14 VA: 0x706F14
		// // RVA: 0x160B980 Offset: 0x160B980 VA: 0x160B980
		public static IEnumerator Co_LoadResource(Transform parent, RhythmGamePlayLog playlog, Action<PopupPlaylogDetail> onfinished)
		{
			//0x160EEF8
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			PopupPlaylogDetailSetting s = new PopupPlaylogDetailSetting();
			s.WindowSize = SizeType.Large;
			s.TitleText = bk.GetMessageByLabel("popup_result_playlog_detail_title");
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			s.SetParent(parent);
			sm_Setting = s;
			yield return Co.R(s.Co_LoadPopupResource(playlog, onfinished));
		}

		// // RVA: 0x160BA60 Offset: 0x160BA60 VA: 0x160BA60
		public void ShowPopup(Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> buttonCallBack)
		{
			PopupWindowManager.Show(sm_Setting, buttonCallBack, null, null, null);
		}

		// RVA: 0x160BB64 Offset: 0x160BB64 VA: 0x160BB64 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupPlaylogDetailSetting s = setting as PopupPlaylogDetailSetting;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			Parent = setting.m_parent;
			gameObject.SetActive(true);
		}

		// // RVA: 0x160BD04 Offset: 0x160BD04 VA: 0x160BD04
		public void OnDestroy()
		{
			sm_Setting = null;
		}

		// // RVA: 0x160BD94 Offset: 0x160BD94 VA: 0x160BD94
		public void Setup(LayoutResultPlaylogGraphParts graph_parts)
		{
			m_MainLayout = GetComponentInChildren<LayoutResultPlaylogDetail>(true);
			sm_Setting.GetSkillBalloonObj.transform.SetParent(m_MainLayout.transform, false);
			m_MainLayout.Setup(sm_Setting.GetViewData, sm_Setting.GetSkillBalloonObj.GetComponentInChildren<LayoutResultPlaylogDetailSkill>(), OnChangeGraphType);
			SetupScrollContent(graph_parts);
			m_GraphType = (GraphType)GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.BAGJHPGGCCI_PlayLogGraphType - 1;
			OnChangeGraphType();
		}

		// // RVA: 0x160C058 Offset: 0x160C058 VA: 0x160C058
		private void SetupScrollContent(LayoutResultPlaylogGraphParts graph_parts)
		{
			float pos = 10;
			for(int i = 0; i < sm_Setting.GetScrollObjList.Count; i++)
			{
				SetupObject(sm_Setting.GetScrollObjList[i], m_MainLayout.ScoreBarRange, pos);
				sm_Setting.GetScrollObjList[i].GetComponent<LayoutResultPlaylogGraphBar>().OnClickGraph = OnClickGraph;
				pos += sm_Setting.GetGraphBarSize.x;
			}
			Vector2 v = new Vector2(pos + 10, 0);
			m_MainLayout.GetScrollContent.sizeDelta = v;
			int maxTime = 0;
			for(int i = 0; i < sm_Setting.GetViewData.result_list.Count; i++)
			{
				maxTime = Mathf.Max(maxTime, sm_Setting.GetViewData.result_list[i].time_range_end);
			}
			List<GameObject> l1 = new List<GameObject>();
			List<GameObject> l2 = new List<GameObject>();
			List<GameObject> l3 = new List<GameObject>();
			LayoutResultPlaylogGraphParts.PartsData.ModeParts parts = graph_parts.GetPartsData(LayoutResultPlaylogGraphParts.SizeType.L).mode_parts[0];
			LayoutResultPlaylogGraphParts.PartsData.ModeParts parts2 = graph_parts.GetPartsData(LayoutResultPlaylogGraphParts.SizeType.L).mode_parts[1];
			LayoutResultPlaylogGraphParts.PartsData.ModeParts parts3 = graph_parts.GetPartsData(LayoutResultPlaylogGraphParts.SizeType.L).mode_parts[2];
			LayoutResultPlaylogGraphParts.PartsData.ModeParts parts4 = graph_parts.GetPartsData(LayoutResultPlaylogGraphParts.SizeType.L).mode_parts[3];
			GameObject dvLine = graph_parts.GetPartsData(LayoutResultPlaylogGraphParts.SizeType.L).division_line;
			SetupModeObject(l1, l2, l3, 
				new RhythmGamePlayLog.ModeData() { type = RhythmGameMode.Type.Normal, beginMillisec = 0, endMillisec = sm_Setting.GetViewData.playlog_data.valkyrieModeData.beginMillisec },
				parts, dvLine,
				m_MainLayout.ScoreBarRange, pos + 10, 10, maxTime, true);
			if (sm_Setting.GetViewData.playlog_data.valkyrieModeData.type != RhythmGameMode.Type.Valkyrie)
				parts2 = parts;
			SetupModeObject(l1, l2, l3,
				new RhythmGamePlayLog.ModeData() { type = sm_Setting.GetViewData.playlog_data.valkyrieModeData.type, beginMillisec = sm_Setting.GetViewData.playlog_data.valkyrieModeData.beginMillisec, endMillisec = sm_Setting.GetViewData.playlog_data.divaModeData.beginMillisec },
				parts2, dvLine,
				m_MainLayout.ScoreBarRange, pos + 10, 10, maxTime, true);
			if (sm_Setting.GetViewData.playlog_data.divaModeData.type == RhythmGameMode.Type.AwakenDiva)
				parts = parts4;
			if (sm_Setting.GetViewData.playlog_data.divaModeData.type == RhythmGameMode.Type.Diva)
				parts = parts3;
			SetupModeObject(l1, l2, l3,
				new RhythmGamePlayLog.ModeData() { type = sm_Setting.GetViewData.playlog_data.divaModeData.type, beginMillisec = sm_Setting.GetViewData.playlog_data.divaModeData.beginMillisec, endMillisec = maxTime * 1000 },
				parts, dvLine,
				m_MainLayout.ScoreBarRange, pos + 10, 10, maxTime, false);
			List<GameObject> l4 = new List<GameObject>();
			SetupSkillObject(l4, graph_parts.GetPartsData(LayoutResultPlaylogGraphParts.SizeType.L).skill_icon, sm_Setting.GetViewData.playlog_data.skillDataList, m_MainLayout.ScoreBarRange, dvLine.GetComponent<RectTransform>().sizeDelta.y * dvLine.GetComponent<RectTransform>().localScale.y, pos + 10, 10, maxTime);
			for(int i = 0; i < l2.Count; i++)
			{
				l2[i].transform.SetAsLastSibling();
				l2[i].GetComponent<RawImageEx>().raycastTarget = false;
			}
			for(int i = 0; i < l4.Count; i++)
			{
				l4[i].transform.SetAsLastSibling();
				{
					RawImageEx[] imgs = l4[i].GetComponentsInChildren<RawImageEx>(true);
					for (int j = 0; j < imgs.Length; j++)
					{
						imgs[j].raycastTarget = false;
					}
				}
			}
			for(int i = 0; i < l3.Count; i++)
			{
				l3[i].transform.SetAsLastSibling();
				l3[i].GetComponent<RawImageEx>().raycastTarget = false;
			}
			SetupObject(sm_Setting.GetSelectFrameObj, m_MainLayout.ScoreBarRange, 0);
			sm_Setting.GetSelectFrameObj.SetActive(false);
			{
				RawImageEx[] imgs = sm_Setting.GetSelectFrameObj.GetComponentsInChildren<RawImageEx>(true);
				for (int i = 0; i < imgs.Length; i++)
				{
					imgs[i].raycastTarget = false;
				}
			}
			m_MainLayout.SwapScroll.Apply();
			m_MainLayout.SkillIconReset();
			m_MainLayout.SetupList();
		}

		// // RVA: 0x160D338 Offset: 0x160D338 VA: 0x160D338
		private void SetupModeObject(List<GameObject> range_list, List<GameObject> line_list, List<GameObject> icon_list, RhythmGamePlayLog.ModeData data, LayoutResultPlaylogGraphParts.PartsData.ModeParts parts, GameObject line_obj, RectTransform parent, float area_width, float area_space, int end_time, bool is_show_end_line = true)
		{
			float a = Mathf.Clamp((data.beginMillisec / 1000.0f) / end_time, 0, 1);
			float b = Mathf.Clamp((data.endMillisec / 1000.0f) / end_time, 0, 1);
			float f = Mathf.Clamp(Mathf.Lerp(a, b, 0.5f), 0, 1);
			float f2 = area_width + area_space * -2;
			GameObject line = Instantiate(parts.line);
			f = f * f2 + area_space;
			SetupObject(line, parent, f);
			range_list.Add(line);
			GameObject l = null;
			if(is_show_end_line)
			{
				l = Instantiate(line_obj);
			}
			if(l != null)
			{
				SetupObject(l, parent, f2 * b + area_space);
				line_list.Add(l);
			}
			GameObject icon = null;
			if(parts.icon != null)
			{
				icon = Instantiate(parts.icon);
			}
			if(icon != null)
			{
				SetupObject(icon, parent, f);
				icon_list.Add(icon);
			}
			float h = line_obj.GetComponent<RectTransform>().sizeDelta.y * line_obj.GetComponent<RectTransform>().localScale.y;
			if (l != null)
			{
				l.GetComponent<RectTransform>().anchoredPosition -= new Vector2(0, h * 0.5f);
			}
			RectTransform rt = line.GetComponent<RectTransform>();
			RawImageEx img = rt.GetComponentInChildren<RawImageEx>(true);
			rt.localScale = new Vector3(Mathf.Abs(f2 * a - f2 * b) / img.rectTransform.sizeDelta.x, 1, 1);
			rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, -(h + rt.sizeDelta.y * -0.5f));
			if(icon != null)
			{
				icon.GetComponent<RectTransform>().anchoredPosition = new Vector2(icon.GetComponent<RectTransform>().anchoredPosition.x + icon.GetComponent<RectTransform>().sizeDelta.x * -0.5f, -(h - icon.GetComponent<RectTransform>().sizeDelta.y + 12));
			}
			if(l != null)
			{
				l.SetActive(is_show_end_line);
			}
		}

		// // RVA: 0x160DC14 Offset: 0x160DC14 VA: 0x160DC14
		private void SetupSkillObject(List<GameObject> obj_list, GameObject obj, List<RhythmGamePlayLog.SkillData> skill_list, RectTransform parent, float area_height, float area_width, float area_space, int end_time)
		{
			for(int i = 0; i < skill_list.Count; i++)
			{
				RhythmGamePlayLog.SkillData data = skill_list[i];
				if(i > 0)
				{
					RhythmGamePlayLog.SkillData data2 = skill_list[i - 1];
					if (data.millisec == data2.millisec)
						continue;
				}
				GameObject o = Instantiate(obj);
				//UnityEngine.Debug.LogError((area_width + area_space * -2) * ((data.millisec / 1000.0f) / end_time) + area_space+" "+area_width+" "+area_space+" "+data.millisec+" "+end_time);
				SetupObject(o, parent, (area_width + area_space * -2) * ((data.millisec / 1000.0f) / end_time) + area_space);
				obj_list.Add(o);
				RawImageEx[] imgs = o.GetComponentsInChildren<RawImageEx>(true);
				RawImageEx img = imgs.Where((RawImageEx _) =>
				{
					//0x160ED74
					return _.name == "swtexf_log_skill_icon (ImageView)";
				}).First();
				Rect r = new Rect();
				if(m_MainLayout.GetSkillIconUv(data, ref r, 0))
				{
					img.uvRect = r;
				}
				img = imgs.Where((RawImageEx _) =>
				{
					//0x160EDF4
					return _.name == "log_skill_icon_as (ImageView)";
				}).First();
				img.enabled = data.isActive;
				img = imgs.Where((RawImageEx _) =>
				{
					//0x160EE74
					return _.name == "log_skill_point_2 (ImageView)";
				}).First();
				bool b = false;
				if(i + 1 < skill_list.Count)
				{
					if (skill_list[i + 1].sceneId != data.sceneId && skill_list[i + 1].millisec == data.millisec)
						b = true;
				}
				img.enabled = b;
				o.GetComponent<RectTransform>().anchoredPosition = new Vector2(o.GetComponent<RectTransform>().anchoredPosition.x, -(area_height + img.rectTransform.sizeDelta.y * -0.5f));
			}
		}

		// // RVA: 0x160D118 Offset: 0x160D118 VA: 0x160D118
		private void SetupObject(GameObject obj, RectTransform parent, float pos)
		{
			Vector2 s = parent.sizeDelta;
			obj.transform.SetParent(parent, false);
			obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(-s.x, s.y) * 0.5f;
			obj.GetComponent<RectTransform>().anchoredPosition += new Vector2(pos, 0);
		}

		// // RVA: 0x160E568 Offset: 0x160E568 VA: 0x160E568 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// // RVA: 0x160E570 Offset: 0x160E570 VA: 0x160E570 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
			m_MainLayout.Show();
		}

		// // RVA: 0x160E5CC Offset: 0x160E5CC VA: 0x160E5CC Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
			m_MainLayout.Hide();
			sm_Setting.GetSelectFrameObj.SetActive(false);
		}

		// // RVA: 0x160E6E0 Offset: 0x160E6E0 VA: 0x160E6E0 Slot: 21
		public bool IsReady()
		{
			LayoutResultPlaylogDetail l = GetComponent<LayoutResultPlaylogDetail>();
			if (l.IsLoaded())
			{
				for(int i = 0; i < l.SwapScroll.ScrollObjectCount; i++)
				{
					if (!l.SwapScroll.ScrollObjects[i].IsLoaded())
						return false;
				}
				return true;
			}
			return false;
		}

		// // RVA: 0x160E860 Offset: 0x160E860 VA: 0x160E860 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}

		// // RVA: 0x160E864 Offset: 0x160E864 VA: 0x160E864
		public bool IsChangeGraphType()
		{
			for(int i = 0; i < sm_Setting.GetScrollObjList.Count; i++)
			{
				if (sm_Setting.GetScrollObjList[i].GetComponent<LayoutResultPlaylogGraphBar>().IsPlayingChangeGraphAnim())
					return false;
			}
			return true;
		}

		// // RVA: 0x160CEA4 Offset: 0x160CEA4 VA: 0x160CEA4
		private void OnChangeGraphType()
		{
			if(IsChangeGraphType())
			{
				m_GraphType = m_GraphType == GraphType.None ? GraphType.Begin : m_GraphType + 1;
				if (m_GraphType >= GraphType.End)
					m_GraphType = GraphType.Begin;
				m_MainLayout.ChangeGraphType(m_GraphType);
				for(int i = 0; i < sm_Setting.GetScrollObjList.Count; i++)
				{
					sm_Setting.GetScrollObjList[i].GetComponent<LayoutResultPlaylogGraphBar>().ChangeGraphType(m_GraphType);
				}
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.BAGJHPGGCCI_PlayLogGraphType = (int)m_GraphType;
			}
		}

		// // RVA: 0x160E9D4 Offset: 0x160E9D4 VA: 0x160E9D4
		private void OnClickGraph(int index)
		{
			m_SelectGraph = index;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			sm_Setting.GetSelectFrameObj.GetComponent<RectTransform>().anchoredPosition = sm_Setting.GetScrollObjList[m_SelectGraph].GetComponent<RectTransform>().anchoredPosition;
			sm_Setting.GetSelectFrameObj.SetActive(true);
			m_MainLayout.SelectGraph(m_SelectGraph);
		}
	}
}
