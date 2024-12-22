using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Collections.Generic;
using System;
using System.Collections;
using XeSys;
using mcrs;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_FilterPlateSkill : PopupFilterSortUGUIPartsBase
	{
		private enum bitFrag
		{
			LSkill = 1,
			ASkill = 2,
			CSkill = 4,
		}

		private enum type
		{
			Live = 0,
			Active = 1,
			Center = 2,
		}

		private RectTransform m_rect; // 0x10
		[SerializeField]
		private InOutAnime m_inOutAnime; // 0x14
		[SerializeField]
		private UGUIToggleButton[] m_RangeBtn; // 0x18
		[SerializeField]
		private UGUIToggleButton[] m_RankBtn; // 0x1C
		[SerializeField]
		private UGUIToggleButton[] m_SkillBtn; // 0x20
		[SerializeField]
		private Text[] m_Text; // 0x24
		[SerializeField]
		private int skillType; // 0x28
		[SerializeField]
		public UGUIToggleButton m_showBtn; // 0x2C
		[SerializeField]
		private GameObject m_setupContents; // 0x30
		private bool isSetup; // 0x34
		[SerializeField]
		private UGUIToggleButton m_allBtn; // 0x38
		[SerializeField]
		private UGUIButton m_releaseBtn; // 0x3C
		[SerializeField]
		private RectTransform[] m_longshortArea; // 0x40
		private StringBuilder m_strBuilder = new StringBuilder(); // 0x44
		private OKGLGHCBCJP_Database m_masterData; // 0x48
		private List<UGUIToggleButton> m_buttonList = new List<UGUIToggleButton>(); // 0x4C

		public override Type MyType { get { return Type.FilterSkill; } } //0x1CA5914
		public Action OhClickShowHideButtonListener { get; set; } // 0x50

		// [IteratorStateMachineAttribute] // RVA: 0x709284 Offset: 0x709284 VA: 0x709284
		// RVA: 0x1CA5924 Offset: 0x1CA5924 VA: 0x1CA5924 Slot: 5
		protected override IEnumerator OnInitialize()
		{
			//0x1794754
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_buttonList.Clear();
			m_buttonList.AddRange(m_RangeBtn);
			m_buttonList.AddRange(m_RankBtn);
			m_buttonList.AddRange(m_SkillBtn);
			for(int i = 0; i < m_RangeBtn.Length; i++)
			{
				m_RangeBtn[i].AddOnClickCallback(() =>
				{
					//0x1CA62A8
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					m_allBtn.SetOff();
					SetupIcon();
				});
			}
			for(int i = 0; i < m_RankBtn.Length; i++)
			{
				m_RankBtn[i].AddOnClickCallback(() =>
				{
					//0x1CA6334
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					m_allBtn.SetOff();
					SetupIcon();
				});
			}
			for(int i = 0; i < m_SkillBtn.Length; i++)
			{
				m_SkillBtn[i].AddOnClickCallback(() =>
				{
					//0x1CA63C0
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					m_allBtn.SetOff();
					SetupIcon();
				});
			}
			m_showBtn.AddOnClickCallback(() =>
			{
				//0x1CA644C
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				bool b = m_showBtn.IsOn;
				m_showBtn.IsInputLock = true;
				if(b)
					Show();
				else
					Hide();
			});
			m_allBtn.SetOff();
			m_allBtn.AddOnClickCallback(() =>
			{
				//0x1CA6508
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				AllSelect();
			});
			m_releaseBtn.AddOnClickCallback(() =>
			{
				//0x1CA656C
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				AllRelease();
			});
			m_masterData = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database;
			MessageBank bkMaster = MessageManager.Instance.GetBank("master");
			if(skillType == 2)
			{
				int i;
				for(i = 0; i < m_masterData.FOFADHAENKC_Skill.NHGMDOIBNDE.Count; i++)
				{
					if(m_masterData.FOFADHAENKC_Skill.NHGMDOIBNDE[i].PLALNIIBLOF < 2)
					{
						m_SkillBtn[i].Hidden = true;
					}
					else
					{
						m_strBuilder.SetFormat("fc_nm_{0:D4}", m_masterData.FOFADHAENKC_Skill.NHGMDOIBNDE[i].PPFNGGCBJKC);
						m_Text[i].text = bkMaster.GetMessageByLabel(m_strBuilder.ToString());
						m_SkillBtn[i].Hidden = false;
					}
				}
				for(; i < m_SkillBtn.Length; i++)
				{
					m_SkillBtn[i].Hidden = true;
				}
				for(i = 0; i < m_longshortArea.Length; i++)
				{
					m_longshortArea[i].gameObject.SetActive(false);
				}
				for(i = 0; i < m_RangeBtn.Length; i++)
				{
					m_RangeBtn[i].Hidden = true;
				}
				transform.Find("Caption/PopupFilterSortUGUIParts_Title02/Title/Text_Title").GetComponent<Text>().text = MessageManager.Instance.GetMessage("menu", "pop_score_detail_item_name_04");
			}
			else if(skillType == 1)
			{
				int i;
				for(i = 0; i < m_masterData.FOFADHAENKC_Skill.OEELDELPIIP.Count; i++)
				{
					if(m_masterData.FOFADHAENKC_Skill.OEELDELPIIP[i].PLALNIIBLOF < 2)
					{
						m_SkillBtn[i].Hidden = true;
					}
					else
					{
						m_strBuilder.SetFormat("fa_nm_{0:D4}", m_masterData.FOFADHAENKC_Skill.OEELDELPIIP[i].PPFNGGCBJKC);
						m_Text[i].text = bkMaster.GetMessageByLabel(m_strBuilder.ToString());
						m_SkillBtn[i].Hidden = false;
					}
				}
				for(; i < m_SkillBtn.Length; i++)
				{
					m_SkillBtn[i].Hidden = true;
				}
				for(i = 0; i < m_longshortArea.Length; i++)
				{
					m_longshortArea[i].gameObject.SetActive(false);
				}
				for(i = 0; i < m_RangeBtn.Length; i++)
				{
					m_RangeBtn[i].Hidden = true;
				}
				transform.Find("Caption/PopupFilterSortUGUIParts_Title02/Title/Text_Title").GetComponent<Text>().text = MessageManager.Instance.GetMessage("menu", "popup_sort_item_active_skill");
			}
			else if(skillType == 0)
			{
				int i;
				for(i = 0; i < m_masterData.FOFADHAENKC_Skill.GAGNFDHGJGC.Count; i++)
				{
					if(m_masterData.FOFADHAENKC_Skill.GAGNFDHGJGC[i].PLALNIIBLOF < 2)
					{
						m_SkillBtn[i].Hidden = true;
					}
					else
					{
						m_strBuilder.SetFormat("fl_nm_{0:D4}", m_masterData.FOFADHAENKC_Skill.GAGNFDHGJGC[i].PPFNGGCBJKC);
						m_Text[i].text = bkMaster.GetMessageByLabel(m_strBuilder.ToString());
						m_SkillBtn[i].Hidden = false;
					}
				}
				for(; i < m_SkillBtn.Length; i++)
				{
					m_SkillBtn[i].Hidden = true;
				}
				for(i = 2; i < m_RangeBtn.Length; i++)
				{
					m_RangeBtn[i].Hidden = true;
				}
				m_RangeBtn[0].transform.Find("All/Top/Text_Name").GetComponent<Text>().text = MessageManager.Instance.GetMessage("menu", "popup_sort_filter_range_long");
				m_RangeBtn[1].transform.Find("All/Top/Text_Name").GetComponent<Text>().text = MessageManager.Instance.GetMessage("menu", "popup_sort_filter_range_short");
				transform.Find("Caption/PopupFilterSortUGUIParts_Title02/Title/Text_Title").GetComponent<Text>().text = MessageManager.Instance.GetMessage("menu", "popup_sort_item_live_skill");
				transform.Find("PopupFilterSortUGUIParts_Title02/Title/Text_Title").GetComponent<Text>().text = JpStringLiterals.UMO_SkillFilterLongNote;
			}
			transform.Find("Caption/PopupFilterSortUGUIParts_Title02/Title/SetupIcon/Text_Setup").GetComponent<Text>().text = JpStringLiterals.UMO_SkillFilterActive;
			transform.Find("PopupFilterSortUGUIParts_Title02 (1)/Title/Text_Title").GetComponent<Text>().text = JpStringLiterals.UMO_SkillFilterRank;
			m_releaseBtn.transform.Find("All/Top/Text_Name").GetComponent<Text>().text = JpStringLiterals.UMO_SkillFilterDisableAll;
			m_RankBtn[0].transform.Find("All/Top/Text_Name").GetComponent<Text>().text = JpStringLiterals.UMO_SkillFilterBRank;
			m_RankBtn[1].transform.Find("All/Top/Text_Name").GetComponent<Text>().text = JpStringLiterals.UMO_SkillFilterARank;
			m_RankBtn[2].transform.Find("All/Top/Text_Name").GetComponent<Text>().text = JpStringLiterals.UMO_SkillFilterSRank;
			m_RankBtn[3].transform.Find("All/Top/Text_Name").GetComponent<Text>().text = JpStringLiterals.UMO_SkillFilterSSRank;
			transform.Find("PopupFilterSortUGUIParts_Title02 (2)/Title/Text_Title").GetComponent<Text>().text = MessageManager.Instance.GetMessage("menu", "popup_sort_item_skill");
			yield return null;
			m_rect = gameObject.GetComponent<RectTransform>();
			m_inOutAnime.SetMoveAmount((int)(m_rect.transform.GetChild(m_rect.transform.childCount - 1).GetComponent<RectTransform>().sizeDelta.y + Mathf.Abs(m_rect.transform.GetChild(m_rect.transform.childCount - 1).GetComponent<RectTransform>().anchoredPosition.y) - m_rect.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.y));
			m_rect.sizeDelta = new Vector2(m_rect.sizeDelta.x, m_rect.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.y);
			SetupStateFilter();
		}

		// // RVA: 0x1C9BB6C Offset: 0x1C9BB6C VA: 0x1C9BB6C
		public void SetBitSkillRange(uint bitFlag)
		{
			SetFilterButtons(m_RangeBtn, bitFlag);
		}

		// // RVA: 0x1C9C544 Offset: 0x1C9C544 VA: 0x1C9C544
		public uint GetBitSkillRange()
		{
			return GetFilterButtonsBit(m_RangeBtn);
		}

		// // RVA: 0x1C9BB74 Offset: 0x1C9BB74 VA: 0x1C9BB74
		public void SetBitSkillRank(uint bitFlag)
		{
			SetFilterButtons(m_RankBtn, bitFlag);
		}

		// // RVA: 0x1C9C54C Offset: 0x1C9C54C VA: 0x1C9C54C
		public uint GetBitSkillRank()
		{
			return GetFilterButtonsBit(m_RankBtn);
		}

		// // RVA: 0x1C9BB7C Offset: 0x1C9BB7C VA: 0x1C9BB7C
		public void SetBitSkill(ulong bitFlag)
		{
			int i;
			if(skillType == 2)
			{
				for(i = 0; i < m_masterData.FOFADHAENKC_Skill.NHGMDOIBNDE.Count; i++)
				{
					if((bitFlag & ((ulong)1 << m_masterData.FOFADHAENKC_Skill.NHGMDOIBNDE[i].MKDDOJOADMF)) == 0)
						m_SkillBtn[i].SetOff();
					else
						m_SkillBtn[i].SetOn();
				}
			}
			else if(skillType == 1)
			{
				for(i = 0; i < m_masterData.FOFADHAENKC_Skill.OEELDELPIIP.Count; i++)
				{
					if((bitFlag & ((ulong)1 << m_masterData.FOFADHAENKC_Skill.OEELDELPIIP[i].MKDDOJOADMF)) == 0)
						m_SkillBtn[i].SetOff();
					else
						m_SkillBtn[i].SetOn();
				}
			}
			else if(skillType == 0)
			{
				for(i = 0; i < m_masterData.FOFADHAENKC_Skill.GAGNFDHGJGC.Count; i++)
				{
					if((bitFlag & ((ulong)1 << m_masterData.FOFADHAENKC_Skill.GAGNFDHGJGC[i].MKDDOJOADMF)) == 0)
						m_SkillBtn[i].SetOff();
					else
						m_SkillBtn[i].SetOn();
				}
			}
		}

		// // RVA: 0x1C9C554 Offset: 0x1C9C554 VA: 0x1C9C554
		public ulong GetBitSkill()
		{
			ulong res = 0;
			if(skillType == 2)
			{
				for(int i = 0; i < m_masterData.FOFADHAENKC_Skill.NHGMDOIBNDE.Count; i++)
				{
					if(m_SkillBtn[i].IsOn)
					{
						res |= (ulong)1 << m_masterData.FOFADHAENKC_Skill.NHGMDOIBNDE[i].MKDDOJOADMF;
					}
				}
			}
			else if(skillType == 1)
			{
				for(int i = 0; i < m_masterData.FOFADHAENKC_Skill.OEELDELPIIP.Count; i++)
				{
					if(m_SkillBtn[i].IsOn)
					{
						res |= (ulong)1 << m_masterData.FOFADHAENKC_Skill.OEELDELPIIP[i].MKDDOJOADMF;
					}
				}
			}
			else if(skillType == 0)
			{
				for(int i = 0; i < m_masterData.FOFADHAENKC_Skill.GAGNFDHGJGC.Count; i++)
				{
					if(m_SkillBtn[i].IsOn)
					{
						res |= (ulong)1 << m_masterData.FOFADHAENKC_Skill.GAGNFDHGJGC[i].MKDDOJOADMF;
					}
				}
			}
			return res;
		}

		// // RVA: 0x1C9C344 Offset: 0x1C9C344 VA: 0x1C9C344
		public void SetAllButton()
		{
			int cnt = 0;
			int cnt2 = 0;
			foreach(var k in m_buttonList)
			{
				if(!k.Hidden)
				{
					cnt2++;
					if(k.IsOn)
						cnt++;
				}
			}
			if(cnt == cnt2)
				m_allBtn.SetOn();
			else
				m_allBtn.SetOff();
		}

		// // RVA: 0x1C9C13C Offset: 0x1C9C13C VA: 0x1C9C13C
		public void SetupIcon()
		{
			isSetup = false;
			for(int i = 0; i < m_RangeBtn.Length; i++)
			{
				if(m_RangeBtn[i].IsOn)
					isSetup = true;
			}
			for(int i = 0; i < m_RankBtn.Length; i++)
			{
				if(m_RankBtn[i].IsOn)
					isSetup = true;
			}
			for(int i = 0; i < m_SkillBtn.Length; i++)
			{
				if(m_SkillBtn[i].IsOn)
					isSetup = true;
			}
			m_setupContents.gameObject.SetActive(isSetup);
		}

		// // RVA: 0x1CA59AC Offset: 0x1CA59AC VA: 0x1CA59AC
		private void Show()
		{
			m_inOutAnime.Enter(false, null);
			m_showBtn.SetOn();
			if(OhClickShowHideButtonListener != null)
				OhClickShowHideButtonListener();
			SaveStateFilter();
		}

		// // RVA: 0x1CA5BC0 Offset: 0x1CA5BC0 VA: 0x1CA5BC0
		private void Hide()
		{
			m_inOutAnime.Leave(false, null);
			m_showBtn.SetOff();
			if(OhClickShowHideButtonListener != null)
				OhClickShowHideButtonListener();
			SaveStateFilter();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7092FC Offset: 0x7092FC VA: 0x7092FC
		// // RVA: 0x1CA5C3C Offset: 0x1CA5C3C VA: 0x1CA5C3C
		// private IEnumerator Co_ShowHideAnimation() { }

		// // RVA: 0x1C9E47C Offset: 0x1C9E47C VA: 0x1C9E47C
		public bool IsPlaying()
		{
			return m_inOutAnime.IsPlaying();
		}

		// // RVA: 0x1CA5CE8 Offset: 0x1CA5CE8 VA: 0x1CA5CE8
		private void AllSelect()
		{
			m_allBtn.SetOn();
			int num = 0;
			if(skillType == 2)
			{
				num = m_masterData.FOFADHAENKC_Skill.NHGMDOIBNDE.Count;
			}
			else if(skillType == 1)
			{
				num = m_masterData.FOFADHAENKC_Skill.OEELDELPIIP.Count;
			}
			else if(skillType == 0)
			{
				num = m_masterData.FOFADHAENKC_Skill.GAGNFDHGJGC.Count;
				for(int i = 0; i < 2; i++)
				{
					m_RangeBtn[i].SetOn();
				}
			}
			for(int i = 0; i < m_RankBtn.Length; i++)
			{
				m_RankBtn[i].SetOn();
			}
			for(int i = 0; i < num; i++)
			{
				m_SkillBtn[i].SetOn();
			}
			SetupIcon();
		}

		// // RVA: 0x1C9CEB0 Offset: 0x1C9CEB0 VA: 0x1C9CEB0
		public void AllRelease()
		{
			m_allBtn.SetOff();
			for(int i = 0; i < m_RangeBtn.Length; i++)
			{
				m_RangeBtn[i].SetOff();
			}
			for(int i = 0; i < m_RankBtn.Length; i++)
			{
				m_RankBtn[i].SetOff();
			}
			for(int i = 0; i < m_SkillBtn.Length; i++)
			{
				m_SkillBtn[i].SetOff();
			}
			SetupIcon();
		}

		// // RVA: 0x1CA6034 Offset: 0x1CA6034 VA: 0x1CA6034
		private void UpdateFilterState(uint bit)
		{
			if((GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.DPFFNBOKKAO & bit) == 0)
			{
				m_inOutAnime.Leave(0.1f, false, null);
				m_showBtn.SetOff();
			}
			else
			{
				m_inOutAnime.Enter(0.1f, false, null);
				m_showBtn.SetOn();
			}
			if(OhClickShowHideButtonListener != null)
				OhClickShowHideButtonListener();
		}

		// // RVA: 0x1CA5A28 Offset: 0x1CA5A28 VA: 0x1CA5A28
		private void SaveStateFilter()
		{
			uint v = (uint)GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.DPFFNBOKKAO;
			if(skillType == 2)
			{
				if(m_showBtn.IsOn)
					v |= 4;
				else
					v &= 0xfffffffb;
			}
			else if(skillType == 1)
			{
				if(m_showBtn.IsOn)
					v |= 2;
				else
					v &= 0xfffffffd;
			}
			else if(skillType == 0)
			{
				if(m_showBtn.IsOn)
					v |= 1;
				else
					v &= 0xfffffffe;
			}
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.DPFFNBOKKAO = (int)v;
		}

		// // RVA: 0x1C9D450 Offset: 0x1C9D450 VA: 0x1C9D450
		public void SetupStateFilter()
		{
			if(skillType == 2)
			{
				UpdateFilterState(4);
			}
			else if(skillType == 1)
			{
				UpdateFilterState(1);
			}
			else if(skillType == 0)
			{
				UpdateFilterState(2);
			}
		}
	}
}
