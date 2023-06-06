using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;
using XeApp.Game.RhythmGame;
using System;

namespace XeApp.Game.Menu
{
	public class LayoutResultPlaylogDetail : LayoutUGUIScriptBase
	{
		private class SkillIconData
		{
			public List<RhythmGamePlayLog.SkillData> skill_list = new List<RhythmGamePlayLog.SkillData>(); // 0x8
			public bool isMultiple; // 0xC

			//// RVA: 0x1D03BFC Offset: 0x1D03BFC VA: 0x1D03BFC
			//public bool IsMultipleSkill() { }
		}

		private static readonly string[] RESULT_NAME_TABLE = new string[5]
			{
				"MISS", "BAD", "GOOD", "GREAT", "PERFECT"
			}; // 0x0
		private static readonly string[] RESULT_OBJ_NAME_TABLE = new string[5]
			{
				"miss", "bad", "good", "great", "perfect"
			}; // 0x4
		private static readonly string[] SKILL_ICON_TABLE = new string[9]
			{
				"log_skill_icon_02", "log_skill_icon_03", "log_skill_icon_04", "log_skill_icon_05",
				"log_skill_icon_06", "log_skill_icon_14", "log_skill_icon_15", "log_skill_icon_16",
				"log_skill_icon_13"
			}; // 0x8
		private static readonly int SKILL_COUNT = 9; // 0xC
		private TexUVListManager m_UvListManager; // 0x14
		private PopupPlaylogDetail.ViewPlaylogDetailData m_ViewData; // 0x18
		private LayoutResultPlaylogDetailSkill m_SkillLayout; // 0x1C
		private Action m_OnChangeGraph; // 0x20
		private int m_SelectGraph; // 0x24
		private AbsoluteLayout m_ChangeGraphAnim; // 0x28
		private AbsoluteLayout m_SelectGraphAnim; // 0x2C
		private ActionButton m_ChangeGraphButton; // 0x30
		private Text[] m_ResultNumText = new Text[5]; // 0x34
		private Text m_BeginTimeText; // 0x38
		private Text m_EndTimeText; // 0x3C
		[SerializeField] // RVA: 0x67D10C Offset: 0x67D10C VA: 0x67D10C
		private ScrollRect m_ScrollRect; // 0x40
		[SerializeField] // RVA: 0x67D11C Offset: 0x67D11C VA: 0x67D11C
		private RectTransform m_ScrollContent; // 0x44
		[SerializeField] // RVA: 0x67D12C Offset: 0x67D12C VA: 0x67D12C
		private RectTransform m_scoreBarRange; // 0x48
		[SerializeField] // RVA: 0x67D13C Offset: 0x67D13C VA: 0x67D13C
		private SwapScrollList m_SwapScroll; // 0x4C
		private List<SkillIconData> m_skillIconList = new List<SkillIconData>(); // 0x50

		public RectTransform GetScrollContent { get { return m_ScrollContent; } } //0x1D01A4C
		public RectTransform ScoreBarRange { get { return m_scoreBarRange; } } //0x1D01A54
		public SwapScrollList SwapScroll { get { return m_SwapScroll; } } //0x1D01A5C
		//public LayoutResultPlaylogDetailSkill SkillLayout { get; } 0x1D01A64

		// RVA: 0x1D01A6C Offset: 0x1D01A6C VA: 0x1D01A6C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			TodoLogger.Log(0, "InitializeFromLayout");
			return true;
		}

		//// RVA: 0x1D02458 Offset: 0x1D02458 VA: 0x1D02458
		public void Show()
		{
			TodoLogger.Log(0, "Show");
		}

		//// RVA: 0x1D025F0 Offset: 0x1D025F0 VA: 0x1D025F0
		public void Hide()
		{
			TodoLogger.Log(0, "Hide");
		}

		//// RVA: 0x1D02644 Offset: 0x1D02644 VA: 0x1D02644
		public void Setup(PopupPlaylogDetail.ViewPlaylogDetailData data, LayoutResultPlaylogDetailSkill ly_skill, Action cb_change_graph)
		{
			TodoLogger.Log(0, "Setup");
		}

		//// RVA: 0x1D02650 Offset: 0x1D02650 VA: 0x1D02650
		public void ChangeGraphType(PopupPlaylogDetail.GraphType type)
		{
			TodoLogger.Log(0, "ChangeGraphType");
		}

		//// RVA: 0x1D02704 Offset: 0x1D02704 VA: 0x1D02704
		public void SelectGraph(int index)
		{
			TodoLogger.Log(0, "SelectGraph");
		}

		//// RVA: 0x1D02FF4 Offset: 0x1D02FF4 VA: 0x1D02FF4
		public void SkillIconReset()
		{
			TodoLogger.Log(0, "SkillIconReset");
		}

		//// RVA: 0x1D03388 Offset: 0x1D03388 VA: 0x1D03388
		//private void OnUpdateList(int index, SwapScrollListContent content) { }

		//// RVA: 0x1D03174 Offset: 0x1D03174 VA: 0x1D03174
		public void SetupList()
		{
			TodoLogger.Log(0, "SetupList");
		}

		//// RVA: 0x1D03C84 Offset: 0x1D03C84 VA: 0x1D03C84
		//private void OnPointerDownSkillIcon(int index) { }

		//// RVA: 0x1D03F3C Offset: 0x1D03F3C VA: 0x1D03F3C
		//private void OnPointerUpSkillIcon(int index) { }

		//// RVA: 0x1D03980 Offset: 0x1D03980 VA: 0x1D03980
		public bool GetSkillIconUv(RhythmGamePlayLog.SkillData data, ref Rect rect, int skillIndex = 0)
		{
			TodoLogger.Log(0, "GetSkillIconUv");
			return false;
		}

		//[CompilerGeneratedAttribute] // RVA: 0x71CF04 Offset: 0x71CF04 VA: 0x71CF04
		//// RVA: 0x1D0493C Offset: 0x1D0493C VA: 0x1D0493C
		//private void <InitializeFromLayout>b__29_0() { }
	}
}
