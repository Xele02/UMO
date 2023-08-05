using mcrs;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeApp.Game.RhythmGame;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutResultPlaylogDetail : LayoutUGUIScriptBase
	{
		private class SkillIconData
		{
			public List<RhythmGamePlayLog.SkillData> skill_list = new List<RhythmGamePlayLog.SkillData>(); // 0x8
			public bool isMultiple; // 0xC

			//// RVA: 0x1D03BFC Offset: 0x1D03BFC VA: 0x1D03BFC
			public bool IsMultipleSkill()
			{
				return skill_list.Count > 1;
			}
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
			m_ChangeGraphAnim = layout.FindViewByExId("sw_log_detail_swtbl_log_indication") as AbsoluteLayout;
			m_SelectGraphAnim = layout.FindViewByExId("sw_log_detail_swtbl_detail") as AbsoluteLayout;
			m_ChangeGraphButton = GetComponentInChildren<ActionButton>(true);
			m_ChangeGraphButton.AddOnClickCallback(() =>
			{
				//0x1D0493C
				if(m_OnChangeGraph != null)
				{
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					m_OnChangeGraph();
				}
			});
			Text[] txts = GetComponentsInChildren<Text>(true);
			Text t = txts.Where((Text _) =>
			{
				//0x1D04A40
				return _.name == "touchgauge (TextView)";
			}).First();
			t.text = MessageManager.Instance.GetMessage("menu", "result_playlog_graph_detail");
			for (int i = 0; i < 5; i++)
			{
				string name = RESULT_OBJ_NAME_TABLE[i];
				t = txts.Where((Text _) =>
				{
					//0x1D04C40
					return _.name == string.Format("{0} (TextView)", name);
				}).First();
				t.text = RESULT_NAME_TABLE[i];
				Text t2 = txts.Where((Text _) =>
				{
					//0x1D04CDC
					return _.name == string.Format("{0}num (TextView)", name);
				}).First();
				m_ResultNumText[i] = t2;
			}
			t = txts.Where((Text _) =>
			{
				//0x1D04AC0
				return _.name == "usedskill (TextView)";
			}).First();
			t.text = JpStringLiterals.StringLiteral_18022;
			m_BeginTimeText = txts.Where((Text _) =>
			{
				//0x1D04B40
				return _.name == "second1 (TextView)";
			}).First();
			m_EndTimeText = txts.Where((Text _) =>
			{
				//0x1D04BC0
				return _.name == "second2 (TextView)";
			}).First();
			m_UvListManager = uvMan;
			Loaded();
			return true;
		}

		//// RVA: 0x1D02458 Offset: 0x1D02458 VA: 0x1D02458
		public void Show()
		{
			m_SwapScroll.ScrollRect.vertical = true;
			m_ScrollRect.enabled = true;
			m_ScrollContent.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
			m_ChangeGraphButton.IsInputOff = false;
			m_SelectGraphAnim.StartChildrenAnimGoStop("01");
		}

		//// RVA: 0x1D025F0 Offset: 0x1D025F0 VA: 0x1D025F0
		public void Hide()
		{
			m_SkillLayout.Leave();
		}

		//// RVA: 0x1D02644 Offset: 0x1D02644 VA: 0x1D02644
		public void Setup(PopupPlaylogDetail.ViewPlaylogDetailData data, LayoutResultPlaylogDetailSkill ly_skill, Action cb_change_graph)
		{
			m_ViewData = data;
			m_SkillLayout = ly_skill;
			m_OnChangeGraph = cb_change_graph;
		}

		//// RVA: 0x1D02650 Offset: 0x1D02650 VA: 0x1D02650
		public void ChangeGraphType(PopupPlaylogDetail.GraphType type)
		{
			if(type == PopupPlaylogDetail.GraphType.Count)
			{
				m_ChangeGraphAnim.StartChildrenAnimGoStop("02");
			}
			else if(type == PopupPlaylogDetail.GraphType.Raito)
			{
				m_ChangeGraphAnim.StartChildrenAnimGoStop("01");
			}
		}

		//// RVA: 0x1D02704 Offset: 0x1D02704 VA: 0x1D02704
		public void SelectGraph(int index)
		{
			m_SelectGraph = index;
			PopupPlaylogDetail.ViewPlaylogDetailData.ViewNoteResultData data = m_ViewData.result_list[index];
			m_BeginTimeText.text = string.Format(JpStringLiterals.StringLiteral_18023, data.time_range_start);
			m_EndTimeText.text = string.Format(JpStringLiterals.StringLiteral_18023, data.time_range_end);
			for(int i = 0; i < 5; i++)
			{
				m_ResultNumText[i].text = string.Format(JpStringLiterals.StringLiteral_18024, data.result_count[i]);
			}
			m_skillIconList.Clear();
			for(int i = 0; i < data.skill_list.Count; i++)
			{
				SkillIconData skillData = new SkillIconData();
				bool b = false;
				for (int j = 0; j < m_skillIconList.Count; j++)
				{
					if (data.skill_list[i].sceneId == m_skillIconList[j].skill_list[0].sceneId)
					{
						if(data.skill_list[i].isActive == m_skillIconList[j].skill_list[0].isActive)
						{
							if(data.skill_list[i].skillId == m_skillIconList[j].skill_list[0].skillId)
							{
								if (data.skill_list[i].millisec == m_skillIconList[j].skill_list[0].millisec)
								{
									if(!m_skillIconList[j].isMultiple)
									{
										m_skillIconList[j].isMultiple = true;
										b = true;
										break;
									}
								}
							}
						}
					}
				}
				skillData.skill_list.Add(data.skill_list[i]);
				if(!b)
				{
					m_skillIconList.Add(skillData);
				}
			}
			SkillIconReset();
			SetupList();
			m_SelectGraphAnim.StartChildrenAnimGoStop("02");
			m_SkillLayout.Leave();
		}

		//// RVA: 0x1D02FF4 Offset: 0x1D02FF4 VA: 0x1D02FF4
		public void SkillIconReset()
		{
			for(int i = 0; i < m_SwapScroll.ScrollObjectCount; i++)
			{
				PlayLogSkillIconContent ct = m_SwapScroll.ScrollObjects[i].GetComponent<PlayLogSkillIconContent>();
				ct.SetCrossFade(false);
				ct.SetActiveIconEnable(0, false);
				ct.SetActiveIconEnable(1, false);
			}
		}

		//// RVA: 0x1D03388 Offset: 0x1D03388 VA: 0x1D03388
		private void OnUpdateList(int index, SwapScrollListContent content)
		{
			PlayLogSkillIconContent c = content as PlayLogSkillIconContent;
			if(c != null)
			{
				c.SetIconEnable(false);
				if(index < m_skillIconList.Count)
				{
					c.SetIconEnable(true);
					Rect r = new Rect();
					GetSkillIconUv(m_skillIconList[index].skill_list[0], ref r, 0);
					c.SetSkillIconImage(0, r);
					if(m_skillIconList[index].IsMultipleSkill())
					{
						GetSkillIconUv(m_skillIconList[index].skill_list[0], ref r, 1);
						c.SetSkillIconImage(1, r);
					}
					c.SetActiveIconEnable(0, m_skillIconList[index].skill_list[0].isActive);
					c.SetActiveIconEnable(1, m_skillIconList[index].skill_list[0].isActive);
					c.SkillId = index;
					c.IconPointerDown.RemoveAllListeners();
					c.IconPointerUp.RemoveAllListeners();
					c.IconPointerDown.AddListener(() =>
					{
						//0x1D04D78
						OnPointerDownSkillIcon(index);
					});
					c.IconPointerUp.AddListener(() =>
					{
						//0x1D04DA8
						OnPointerUpSkillIcon(index);
					});
				}
			}
		}

		//// RVA: 0x1D03174 Offset: 0x1D03174 VA: 0x1D03174
		public void SetupList()
		{
			m_SwapScroll.Vertical = true;
			m_SwapScroll.SetItemCount(m_skillIconList.Count);
			m_SwapScroll.OnUpdateItem.RemoveAllListeners();
			m_SwapScroll.OnUpdateItem.AddListener(OnUpdateList);
			m_SwapScroll.ResetScrollVelocity();
			m_SwapScroll.SetPosition(0, 0, 0, false);
			m_SwapScroll.VisibleRegionUpdate();
		}

		//// RVA: 0x1D03C84 Offset: 0x1D03C84 VA: 0x1D03C84
		private void OnPointerDownSkillIcon(int index)
		{
			for(int i = 0; i < m_SwapScroll.ScrollObjectCount; i++)
			{
				PlayLogSkillIconContent skillContent = m_SwapScroll.ScrollObjects[i].GetComponent<PlayLogSkillIconContent>();
				if (skillContent.SkillId == index)
				{
					m_SkillLayout.Enter(skillContent.GetComponent<RectTransform>(), m_skillIconList[index].skill_list[0]);
					return;
				}
			}
		}

		//// RVA: 0x1D03F3C Offset: 0x1D03F3C VA: 0x1D03F3C
		private void OnPointerUpSkillIcon(int index)
		{
			m_SkillLayout.Leave();
		}

		//// RVA: 0x1D03980 Offset: 0x1D03980 VA: 0x1D03980
		public bool GetSkillIconUv(RhythmGamePlayLog.SkillData data, ref Rect rect, int skillIndex = 0)
		{
			int[] a;
			if (!data.isActive)
			{
				a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[data.skillId - 1].MKPJBDFDHOL;
			}
			else
			{
				a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PABCHCAAEAA_ActiveSkills[data.skillId - 1].MKPJBDFDHOL;
			}
			rect = LayoutUGUIUtility.MakeUnityUVRect(m_UvListManager.GetUVData(string.Format("log_skill_icon_{0:00}", a[skillIndex])));
			return true;
		}
	}
}
