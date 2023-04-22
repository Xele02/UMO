using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;
using XeApp.Game.RhythmGame;

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

			// public PopupPlaylogDetail.ViewPlaylogDetailData GetViewData { get; } 0x160C050
			// public List<GameObject> GetScrollObjList { get; } 0x160D110
			// public GameObject GetSelectFrameObj { get; } 0x160E560
			// public GameObject GetSkillBalloonObj { get; } 0x160C048
			// public Vector2 GetGraphBarSize { get; } 0x160D324
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
			// public IEnumerator Co_LoadPopupResource(RhythmGamePlayLog playlog, Action<PopupPlaylogDetail> onfinished) { }

			// // RVA: 0x160F618 Offset: 0x160F618 VA: 0x160F618
			// private LayoutUGUIRuntime CopyInstance(LayoutUGUIRuntime runtime) { }

			// [CompilerGeneratedAttribute] // RVA: 0x707004 Offset: 0x707004 VA: 0x707004
			// // RVA: 0x160F798 Offset: 0x160F798 VA: 0x160F798
			// private void <Co_LoadPopupResource>b__34_0(GameObject instance) { }

			// [CompilerGeneratedAttribute] // RVA: 0x707014 Offset: 0x707014 VA: 0x707014
			// // RVA: 0x160F7A0 Offset: 0x160F7A0 VA: 0x160F7A0
			// private void <Co_LoadPopupResource>b__34_3(GameObject instance) { }

			// [CompilerGeneratedAttribute] // RVA: 0x707024 Offset: 0x707024 VA: 0x707024
			// // RVA: 0x160F7A8 Offset: 0x160F7A8 VA: 0x160F7A8
			// private void <Co_LoadPopupResource>b__34_4(GameObject instance) { }
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
				// public void AddNoteData(RhythmGamePlayLog.NoteData data) { }
			}

			public RhythmGamePlayLog playlog_data; // 0x8
			public List<ViewNoteResultData> result_list = new List<ViewNoteResultData>(); // 0xC
			public int max_count; // 0x10

			// // RVA: 0x1610A7C Offset: 0x1610A7C VA: 0x1610A7C
			// public void Init(RhythmGamePlayLog playlog) { }

			// // RVA: 0x1611078 Offset: 0x1611078 VA: 0x1611078
			// private void AddResultData(int count) { }
		}

		public static readonly string BUNDLE_NAME = "ly/023.xab"; // 0x0
		public static readonly int GRAPHBAR_INTERVAL_SECOND = 10; // 0x4
		public static readonly int GRAPHBAR_INTERVAL_MILLISECOND = GRAPHBAR_INTERVAL_SECOND * 1000; // 0x8
		private static PopupPlaylogDetail.PopupPlaylogDetailSetting sm_Setting = null; // 0xC
		private LayoutResultPlaylogDetail m_MainLayout; // 0x10
		private PopupPlaylogDetail.GraphType m_GraphType = GraphType.None; // 0x14
		private float m_ScrollAreaWidth; // 0x18
		private int m_SelectGraph = -1; // 0x1C

		public Transform Parent { get; private set; } // 0xC

		// [IteratorStateMachineAttribute] // RVA: 0x706F14 Offset: 0x706F14 VA: 0x706F14
		// // RVA: 0x160B980 Offset: 0x160B980 VA: 0x160B980
		// public static IEnumerator Co_LoadResource(Transform parent, RhythmGamePlayLog playlog, Action<PopupPlaylogDetail> onfinished) { }

		// // RVA: 0x160BA60 Offset: 0x160BA60 VA: 0x160BA60
		// public void ShowPopup(Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> buttonCallBack) { }

		// RVA: 0x160BB64 Offset: 0x160BB64 VA: 0x160BB64 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			TodoLogger.Log(0, "Initialize");
		}

		// // RVA: 0x160BD04 Offset: 0x160BD04 VA: 0x160BD04
		// public void OnDestroy() { }

		// // RVA: 0x160BD94 Offset: 0x160BD94 VA: 0x160BD94
		// public void Setup(LayoutResultPlaylogGraphParts graph_parts) { }

		// // RVA: 0x160C058 Offset: 0x160C058 VA: 0x160C058
		// private void SetupScrollContent(LayoutResultPlaylogGraphParts graph_parts) { }

		// // RVA: 0x160D338 Offset: 0x160D338 VA: 0x160D338
		// private void SetupModeObject(List<GameObject> range_list, List<GameObject> line_list, List<GameObject> icon_list, RhythmGamePlayLog.ModeData data, LayoutResultPlaylogGraphParts.PartsData.ModeParts parts, GameObject line_obj, RectTransform parent, float area_width, float area_space, int end_time, bool is_show_end_line = True) { }

		// // RVA: 0x160DC14 Offset: 0x160DC14 VA: 0x160DC14
		// private void SetupSkillObject(List<GameObject> obj_list, GameObject obj, List<RhythmGamePlayLog.SkillData> skill_list, RectTransform parent, float area_height, float area_width, float area_space, int end_time) { }

		// // RVA: 0x160D118 Offset: 0x160D118 VA: 0x160D118
		// private void SetupObject(GameObject obj, RectTransform parent, float pos) { }

		// // RVA: 0x160E568 Offset: 0x160E568 VA: 0x160E568 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// // RVA: 0x160E570 Offset: 0x160E570 VA: 0x160E570 Slot: 19
		public void Show()
		{
			TodoLogger.Log(0, "Show");
		}

		// // RVA: 0x160E5CC Offset: 0x160E5CC VA: 0x160E5CC Slot: 20
		public void Hide()
		{
			TodoLogger.Log(0, "Hide");
		}

		// // RVA: 0x160E6E0 Offset: 0x160E6E0 VA: 0x160E6E0 Slot: 21
		public bool IsReady()
		{
			TodoLogger.Log(0, "IsReady");
			return false;
		}

		// // RVA: 0x160E860 Offset: 0x160E860 VA: 0x160E860 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}

		// // RVA: 0x160E864 Offset: 0x160E864 VA: 0x160E864
		// public bool IsChangeGraphType() { }

		// // RVA: 0x160CEA4 Offset: 0x160CEA4 VA: 0x160CEA4
		// private void OnChangeGraphType() { }

		// // RVA: 0x160E9D4 Offset: 0x160E9D4 VA: 0x160E9D4
		// private void OnClickGraph(int index) { }
	}
}
