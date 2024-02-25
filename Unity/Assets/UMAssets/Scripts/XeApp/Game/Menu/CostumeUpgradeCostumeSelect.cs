using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using XeSys;
using mcrs;

namespace XeApp.Game.Menu
{
	public class CostumeUpgradeCostumeSelect : LayoutUGUIScriptBase
	{
		private struct RewardIconData
		{
			public AbsoluteLayout getIcon; // 0x0
			public AbsoluteLayout itemType; // 0x4
			public NumberBase num; // 0x8
			public RawImageEx image; // 0xC
			public RawImageEx divaImage; // 0x10
			public AbsoluteLayout rank; // 0x14
			public AbsoluteLayout iconBase; // 0x18
		}

		private struct ReleaseValueData
		{
			public NumberBase num; // 0x0
			public NumberBase max; // 0x4
		}

		private const int ShowCostumeNum = 3;
		private MOEALEGLGCH m_costumeUpgradeData; // 0x14
		private List<LFAFJCNKLML> m_filterCostumeDataList = new List<LFAFJCNKLML>(); // 0x18
		private List<LFAFJCNKLML> m_showCostumeDataList = new List<LFAFJCNKLML>(); // 0x1C
		private LFAFJCNKLML m_selectCostumeData; // 0x20
		private List<CostumeUpgradeUtility.CostumeData> m_costumeLayoutList = new List<CostumeUpgradeUtility.CostumeData>(); // 0x24
		private List<int> m_filterDivaIdList = new List<int>(); // 0x28
		private RawImageEx m_divaIconImage; // 0x2C
		private int m_loadingDivaId; // 0x30
		private Text m_costumeName; // 0x34
		private AbsoluteLayout m_rewadIconAnim; // 0x38
		private RewardIconData m_nextReawad; // 0x3C
		private RewardIconData m_targetReawad; // 0x58
		private ReleaseValueData m_releaseValue; // 0x74
		private AbsoluteLayout m_releaseLock; // 0x7C
		private AbsoluteLayout m_baseAnim; // 0x80
		private AbsoluteLayout m_baseColorAnim; // 0x84
		private AbsoluteLayout m_costumeMoveAnim; // 0x88
		private AbsoluteLayout m_buttonTable; // 0x8C
		[SerializeField]
		private ActionButton m_divaSelectButton; // 0x90
		[SerializeField]
		private ActionButton m_checkRewardButton; // 0x94
		[SerializeField]
		private ActionButton m_useItemButton; // 0x98
		[SerializeField]
		private ActionButton m_rankUpUnlockButton; // 0x9C
		[SerializeField]
		private ActionButton m_conditionCheckButton; // 0xA0
		private AbsoluteLayout m_conditionCheckButtonEffect; // 0xA4
		[SerializeField]
		private ActionButton m_leftArrowButton; // 0xA8
		[SerializeField]
		private ActionButton m_rightArrowButton; // 0xAC
		[SerializeField]
		private ActionButton m_itemDetailButton; // 0xB0
		[SerializeField]
		private List<CostumeUpgradeCostumeButton> m_costumeButton; // 0xB4
		private int m_divaId = 1; // 0xB8
		private int m_costumeModelId = 1; // 0xBC
		private int m_cursorIndex; // 0xC0
		[SerializeField] // RVA: 0x66B598 Offset: 0x66B598 VA: 0x66B598
		public CostumeUpgradeSelectScroller m_scroller; // 0xC4
		private const float CostumeScrollSec = 0.2f;
		private bool m_isKeyScrool; // 0xC8
		private CostumeDivaSelectPopupSetting m_diva_select_window = new CostumeDivaSelectPopupSetting(); // 0xCC
		private CostumeRankUpUnlockPopupSetting m_rank_unlock_window = new CostumeRankUpUnlockPopupSetting(); // 0xD0
		public bool isPrevCostumeSelect; // 0xD5
		private AbsoluteLayout m_rewadIconChildAnim; // 0xD8
		private int m_itemDetailAnimFrame; // 0xDC
		private bool m_isPressedItemDetailButton; // 0xE0

		//public List<int> DivaFilterList { get; set; } // 0x16E91D8 0x16E91E0
		public bool isItemSelectScene { get; private set; } // 0xD4

		// RVA: 0x16E9228 Offset: 0x16E9228 VA: 0x16E9228 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_baseAnim = layout.FindViewById("sw_cos_01_anim") as AbsoluteLayout;
			m_costumeMoveAnim = layout.FindViewByExId("sw_cos_01_sw_cos_01_swipe_anim") as AbsoluteLayout;
			m_baseColorAnim = layout.FindViewByExId("sw_cos_01_swtbl_c_b_win_col") as AbsoluteLayout;
			m_conditionCheckButtonEffect = layout.FindViewByExId("sw_c_b_btn_04_anim_sw_c_b_btn_p_eff_01") as AbsoluteLayout;
			string[] strs = new string[]
			{
				"cos_01_front_01 (AbsoluteLayout)",
				"cos_02 (AbsoluteLayout)",
				"cos_01_back_01 (AbsoluteLayout)",
				"cos_03 (AbsoluteLayout)",
				"cos_04 (AbsoluteLayout)"
			};
			for(int i = 0; i < strs.Length; i++)
			{
				CostumeUpgradeUtility.CostumeData data = new CostumeUpgradeUtility.CostumeData();
				data.image = transform.Find("sw_cos_01_anim (AbsoluteLayout)/sw_cos_01 (AbsoluteLayout)/sw_cos_01_swipe_anim (AbsoluteLayout)/" + strs[i]).Find("cos_01_001 (AbsoluteLayout)/cos_01_001 (ImageView)").GetComponent<RawImageEx>();
				AbsoluteLayout l1 = layout.FindViewByExId("sw_cos_01_swipe_anim_" + strs[i].Replace(" (AbsoluteLayout)", "")) as AbsoluteLayout;
				data.rank.num = (l1).FindViewByExId("swtbl_cos_01_swtbl_star_num_02") as AbsoluteLayout;
				data.rank.enable = new List<AbsoluteLayout>();
				for(int j = 0; j < 6; j++)
				{
					data.rank.enable.Add(l1.FindViewByExId("swtbl_star_num_02_swbtl_star_on_off_0" + (j + 1)) as AbsoluteLayout);
				}
				m_costumeLayoutList.Add(data);
			}
			Transform t = transform.Find("sw_cos_01_anim (AbsoluteLayout)/sw_cos_01 (AbsoluteLayout)");
			m_rewadIconAnim = layout.FindViewById("sw_cos_item_anim_lo") as AbsoluteLayout;
			m_rewadIconChildAnim = layout.FindViewById("sw_cos_item_next") as AbsoluteLayout;
			RewardLayoutInit(layout, t, ref m_nextReawad, "next");
			RewardLayoutInit(layout, t, ref m_targetReawad, "target");
			m_divaIconImage = t.Find("chara_icon_01 (AbsoluteLayout)/swtexc_cmn_chara_icon (ImageView)").GetComponent<RawImageEx>();
			m_costumeName = t.Find("sw_cos_01_swipe_anim (AbsoluteLayout)/cos_name (AbsoluteLayout)/cos_name (TextView)").GetComponent<Text>();
			m_releaseValue.max = t.Find("swtb_sw_state_num01 (AbsoluteLayout)").Find("sw_state_num01 (AbsoluteLayout)").GetComponent<NumberBase>();
			m_releaseValue.num = t.Find("swtb_sw_state_num01 (AbsoluteLayout)").Find("sw_state_num01 (AbsoluteLayout)/swnum_state_num01_l (AbsoluteLayout)").GetComponent<NumberBase>();
			m_releaseLock = layout.FindViewById("swtb_sw_state_num01") as AbsoluteLayout;
			m_buttonTable = layout.FindViewByExId("sw_cos_01_swtbl_c_b_btn") as AbsoluteLayout;
			m_divaSelectButton.AddOnClickCallback(CallBackDivaSelect);
			m_checkRewardButton.AddOnClickCallback(CallBackReward);
			m_useItemButton.AddOnClickCallback(CallBackUseItem);
			m_rankUpUnlockButton.AddOnClickCallback(CallBackRankUpUnlock);
			m_conditionCheckButton.AddOnClickCallback(CallBackConditionCheck);
			m_leftArrowButton.AddOnClickCallback(CallBackLeft);
			m_rightArrowButton.AddOnClickCallback(CallBackRight);
			m_itemDetailButton.AddOnClickCallback(CallBackItemDetail);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_diva_select_window = new CostumeDivaSelectPopupSetting();
			m_diva_select_window.TitleText = bk.GetMessageByLabel("costume_upgrade_diva_select_title_text");
			m_diva_select_window.m_parent = transform;
			m_diva_select_window.WindowSize = SizeType.Middle;
			m_diva_select_window.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive },
			};
			m_scroller.onSelectionChanged = OnSelectionChanged;
			m_scroller.onScrollRepeated = OnScrollRepeated;
			m_scroller.onScrollStarted = OnScrollStarted;
			m_scroller.onScrollUpdated = OnScrollUpdated;
			m_scroller.onScrollEnded = OnScrollEnded;
			Loaded();
			return true;
		}

		//// RVA: 0x16EA7F8 Offset: 0x16EA7F8 VA: 0x16EA7F8
		private void RewardLayoutInit(Layout layout, Transform transform, ref RewardIconData data, string str)
		{
			Transform t = transform.Find("sw_cos_item_base (AbsoluteLayout)/sw_cos_item_anim_lo (AbsoluteLayout)/sw_cos_item_" + str + " (AbsoluteLayout)");
			data.getIcon = layout.FindViewByExId("sw_cos_item_" + str + "_swtbl_get_icon_01") as AbsoluteLayout;
			data.image = t.Find("cmn_ep_item_icon_02 (AbsoluteLayout)/swtexc_cmn_item (ImageView)").GetComponent<RawImageEx>();
			data.itemType = layout.FindViewByExId("sw_cos_item_" + str + "_swtbl_item_type") as AbsoluteLayout;
			data.num = t.Find("swtbl_item_type (AbsoluteLayout)/swnum_item_num01 (AbsoluteLayout)").GetComponent<NumberBase>();
			data.divaImage = t.Find("chara_icon_02 (AbsoluteLayout)/swtexc_cmn_chara_icon (ImageView)").GetComponent<RawImageEx>();
			data.rank = layout.FindViewByExId("sw_cos_item_" + str + "_swtbl_c_b_star_s") as AbsoluteLayout;
			data.iconBase = layout.FindViewById("sw_cos_item_" + str) as AbsoluteLayout;
		}

		//// RVA: 0x16EAC68 Offset: 0x16EAC68 VA: 0x16EAC68
		public void Init()
		{
			m_costumeUpgradeData = new MOEALEGLGCH();
			m_costumeUpgradeData.KHEKNNFCAOI();
			if(!isPrevCostumeSelect)
			{
				m_filterDivaIdList = BitToDivaIdList(GameManager.Instance.localSave.EPJOACOONAC_GetSave().MOBOMOEHGAO_CostumeUpgrade.AEKKEKBMOCF_DivaFilterBit);
				SettingDivaFilter();
				SetFocus(GameManager.Instance.localSave.EPJOACOONAC_GetSave().MOBOMOEHGAO_CostumeUpgrade.BDIOOMFHPJA_SelectDivaId, GameManager.Instance.localSave.EPJOACOONAC_GetSave().MOBOMOEHGAO_CostumeUpgrade.HEEJCAOKDPE_SelectCostumeId, false);
			}
			for(int i = 0; i < m_costumeButton.Count; i++)
			{
				m_costumeButton[i].onSelectButton = (int offset) =>
				{
					//0x16F12D8
					ButtonScroll(offset);
				};
			}
		}

		//// RVA: 0x16EAFAC Offset: 0x16EAFAC VA: 0x16EAFAC
		public void SettingDivaFilter()
		{
			SettingCostumeFilter();
			if (m_diva_select_window.Content != null)
				m_diva_select_window.SetFilterDivaIdList(m_filterDivaIdList);
		}

		//// RVA: 0x16EB2B0 Offset: 0x16EB2B0 VA: 0x16EB2B0
		public void SettingCostumeFilter()
		{
			m_filterCostumeDataList = m_costumeUpgradeData.NLLHENIPDDA(m_filterDivaIdList);
		}

		//// RVA: 0x16EB2EC Offset: 0x16EB2EC VA: 0x16EB2EC
		public void Enter()
		{
			isItemSelectScene = false;
			m_baseAnim.StartChildrenAnimGoStop("go_in", "st_in");
			SettingCostume();
		}

		//// RVA: 0x16EB43C Offset: 0x16EB43C VA: 0x16EB43C
		public void Leave()
		{
			m_baseAnim.StartChildrenAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0x16EB4C8 Offset: 0x16EB4C8 VA: 0x16EB4C8
		public bool IsPlayingEnd()
		{
			return !m_baseAnim.IsPlayingChildren();
		}

		// RVA: 0x16EB4F8 Offset: 0x16EB4F8 VA: 0x16EB4F8
		public void Update()
		{
			MenuScene.Instance.CostumeIconCache.Update();
			MenuScene.Instance.DivaIconCache.Update();
			m_diva_select_window.Update();
			UpdateArrowHidden();
			UpdateItemDetailButton();
		}

		//// RVA: 0x16EB630 Offset: 0x16EB630 VA: 0x16EB630
		public void UpdateArrowHidden()
		{
			m_leftArrowButton.Hidden = m_scroller.CheckOnLeftLimitPage();
			m_rightArrowButton.Hidden = m_scroller.CheckOnRightLimitPage();
		}

		//// RVA: 0x16EB71C Offset: 0x16EB71C VA: 0x16EB71C
		public void UpdateItemDetailButton()
		{
			if(m_selectCostumeData != null)
			{
				if(m_selectCostumeData.GKIKAABHAAD_Level < m_selectCostumeData.HGBJODBCJDA - 1)
				{
					if(m_itemDetailButton.IsPressed())
					{
						for(int i = 0; i < m_rewadIconAnim.viewCount; i++)
						{
							m_rewadIconAnim[i].StopAnim();
						}
						m_itemDetailAnimFrame = m_rewadIconChildAnim.FrameAnimation.FrameCount;
						m_isPressedItemDetailButton = true;
					}
					else if(m_isPressedItemDetailButton)
					{
						m_rewadIconAnim.StartChildrenAnimLoop(m_itemDetailAnimFrame, 1, m_rewadIconChildAnim.FrameAnimation.FrameCount);
						m_isPressedItemDetailButton = false;
					}
				}
			}
		}

		//// RVA: 0x16EB388 Offset: 0x16EB388 VA: 0x16EB388
		public void SettingCostume()
		{
			SettingCostumeUI(m_cursorIndex, true, 2 < m_filterCostumeDataList.Count, m_filterCostumeDataList.Count < 3);
			SettingScrollLimit();
		}

		//// RVA: 0x16EBBC4 Offset: 0x16EBBC4 VA: 0x16EBBC4
		private void SettingScrollLimit()
		{
			if(m_filterCostumeDataList.Count > 2)
			{
				m_scroller.ClearLimit();
			}
			else
			{
				if(m_cursorIndex == 0)
				{
					m_scroller.SetLimit(0, m_filterCostumeDataList.Count - 1);
				}
				else
				{
					m_scroller.SetLimit(-1, 0);
				}
			}
		}

		//// RVA: 0x16EB95C Offset: 0x16EB95C VA: 0x16EB95C
		private void SettingCostumeUI(int cursorIndex, bool is_update_costume_image = true, bool is_move_right = false, bool is_wait = false)
		{
			m_showCostumeDataList.Clear();
			List<int> l = new List<int>();
			if (cursorIndex - 2 < 0)
				cursorIndex += m_filterCostumeDataList.Count;
			for(int i = 0; i < 5; i++)
			{
				l.Add(((cursorIndex - 2) + i) % m_filterCostumeDataList.Count);
			}
			for (int i = 0; i < 5; i++)
			{
				m_showCostumeDataList.Add(m_filterCostumeDataList[l[i]]);
			}
			if (is_update_costume_image)
				SettingCostumeIcon(is_move_right, is_wait);
			SettingSelectCostume();
		}

		//// RVA: 0x16EBD88 Offset: 0x16EBD88 VA: 0x16EBD88
		public void SettingCostumeIcon(bool is_move_right, bool is_wait)
		{
			int[][] l = new int[5][]
			{
				new int[2] { 4, -1 },
				new int[2] { 1, -1 },
				new int[2] { 0, 2 },
				new int[2] { 3, -1 },
				new int[2] { -1, -1 }
			};
			int[][] l2 = new int[5][]
			{
				new int[2] { -1, -1 },
				new int[2] { 4, -1 },
				new int[2] { 1, -1 },
				new int[2] { 0, 2 },
				new int[2] { 3, -1 }
			};
			int[][] l3 = new int[5][]
			{
				new int[2] { -1, -1 },
				new int[2] { 1, -1 },
				new int[2] { 0, 2 },
				new int[2] { 3, -1 },
				new int[2] { -1, -1 }
			};
			List<int> l4 = new List<int>();
			if(is_move_right)
				l2 = l;
			if (is_wait)
				l2 = l3;
			l4.Add(0);
			l4.Add(1);
			l4.Add(2);
			l4.Add(3);
			l4.Add(4);
			if(m_filterCostumeDataList.Count == 2)
			{
				l4.Clear();
				l4.Add(0);
				l4.Add(1);
				if(is_wait && m_cursorIndex == 0)
				{
					l4.Add(3);
				}
				else
				{
					l4.Add(1);
				}
			}
			else
			{
				if(m_filterCostumeDataList.Count == 1)
				{
					l4.Clear();
					l4.Add(0);
				}
			}
			for(int i = 0; i < m_showCostumeDataList.Count; i++)
			{
				if (!l4.Exists((int x) =>
				 {
					 //0x16F14FC
					 return i == x;
				 }))
				{
					m_costumeLayoutList[i].SetVisibleCostumeIcon(false);
				}
			}
			for(int i = 0; i < m_showCostumeDataList.Count; i++)
			{
				for(int j = 0; j < 2; j++)
				{
					int layerId = l2[i][j];
					int index = i;
					if (l4.Exists((int x) =>
					{
						//0x16F1510
						return layerId == x;
					}))
					{
						m_costumeLayoutList[layerId].SetCostumeIcon(new CostumeUpgradeUtility.CostumeData.Setting()
						{
							divaId = m_showCostumeDataList[i].AHHJLDLAPAN_DivaId,
							costumeModelId = m_showCostumeDataList[i].DAJGPBLEEOB_PrismCostumeId,
							colorId = null, isHave = m_showCostumeDataList[i].FJODMPGPDDD_Possessed, 
							rankMax = m_showCostumeDataList[i].LLLCMHENKKN_LevelMax,
							rankNum = m_showCostumeDataList[i].GKIKAABHAAD_Level
						}, (CostumeUpgradeUtility.CostumeData.Setting setting) =>
						{
							//0x16F1524
							if(m_showCostumeDataList[index].AHHJLDLAPAN_DivaId == setting.divaId)
							{
								return m_showCostumeDataList[index].DAJGPBLEEOB_PrismCostumeId == setting.costumeModelId;
							}
							return false;
						});
					}
				}
			}
		}

		//// RVA: 0x16ED254 Offset: 0x16ED254 VA: 0x16ED254
		private void SettingSelectCostume()
		{
			m_selectCostumeData = m_showCostumeDataList[2];
			m_divaId = m_selectCostumeData.AHHJLDLAPAN_DivaId;
			m_costumeModelId = m_selectCostumeData.DAJGPBLEEOB_PrismCostumeId;
			m_costumeName.text = m_selectCostumeData.OPFGFINHFCE_Name;
			m_baseColorAnim.StartAllAnimGoStop(m_selectCostumeData.AHHJLDLAPAN_DivaId + 1, m_selectCostumeData.AHHJLDLAPAN_DivaId + 1);
			SetDivaImage(m_divaId, 1, 0);
			int level = m_selectCostumeData.GKIKAABHAAD_Level;
			if(m_selectCostumeData.JHLKLPEHHCD_GetCurrentLevelInfo() == null || m_selectCostumeData.LLLCMHENKKN_LevelMax <= m_selectCostumeData.GKIKAABHAAD_Level)
			{
				m_useItemButton.Disable = true;
				m_rankUpUnlockButton.Disable = true;
				m_conditionCheckButton.Disable = true;
				level = m_selectCostumeData.LLLCMHENKKN_LevelMax - 1;
				m_releaseValue.num.SetNumber(m_selectCostumeData.OCOOHBINGBG_LevelInfo[m_selectCostumeData.LLLCMHENKKN_LevelMax - 1].DNBFMLBNAEE_NeedPoint, 0);
				m_releaseValue.max.SetNumber(m_selectCostumeData.OCOOHBINGBG_LevelInfo[m_selectCostumeData.LLLCMHENKKN_LevelMax - 1].DNBFMLBNAEE_NeedPoint, 0);
			}
			else
			{
				m_useItemButton.Disable = false;
				m_rankUpUnlockButton.Disable = false;
				m_conditionCheckButton.Disable = false;
				m_releaseValue.num.SetNumber(m_selectCostumeData.ABLHIAEDJAI_Point, 0);
				m_releaseValue.max.SetNumber(m_selectCostumeData.JHLKLPEHHCD_GetCurrentLevelInfo().DNBFMLBNAEE_NeedPoint, 0);
			}
			SettingRewardIcon(level);
			bool b = true;
			if(m_selectCostumeData.GKIKAABHAAD_Level < m_selectCostumeData.LLLCMHENKKN_LevelMax)
			{
				b = m_selectCostumeData.CDOCOLOKCJK();
			}
			SettingRelase(b);
		}

		//// RVA: 0x16EDF68 Offset: 0x16EDF68 VA: 0x16EDF68
		private void SettingRewardIcon(int rank)
		{
			LFAFJCNKLML.GFIPDFPIKIJ a;
			LFAFJCNKLML.HKKKKFLBFJN(m_selectCostumeData, rank, out a, 0);
			CostumeUpgradeUtility.SettingRewardIcon(m_selectCostumeData, a.GLCLFMGPMAN_ItemId, rank, a.NANNGLGOFKH_Value, new CostumeUpgradeUtility.RewardIconLayoutSetting(m_nextReawad.image, m_nextReawad.divaImage, m_nextReawad.itemType, m_nextReawad.num, m_nextReawad.rank), (LFAFJCNKLML viewData) =>
			{
				//0x16F12DC
				if(viewData.AHHJLDLAPAN_DivaId == m_selectCostumeData.AHHJLDLAPAN_DivaId)
				{
					if(viewData.DAJGPBLEEOB_PrismCostumeId == m_selectCostumeData.DAJGPBLEEOB_PrismCostumeId)
					{
						return true;
					}
				}
				return false;
			});
			int b = m_selectCostumeData.HGBJODBCJDA - 1;
			if(rank < b)
			{
				m_rewadIconAnim.StartChildrenAnimLoop("lo_");
				LFAFJCNKLML.HKKKKFLBFJN(m_selectCostumeData, b, out a, 0);
				CostumeUpgradeUtility.SettingRewardIcon(m_selectCostumeData, a.GLCLFMGPMAN_ItemId, b, a.NANNGLGOFKH_Value, new CostumeUpgradeUtility.RewardIconLayoutSetting(m_targetReawad.image, m_targetReawad.divaImage, m_targetReawad.itemType, m_targetReawad.num, m_targetReawad.rank), (LFAFJCNKLML viewData) =>
				{
					//0x16F138C
					if (viewData.AHHJLDLAPAN_DivaId == m_selectCostumeData.AHHJLDLAPAN_DivaId)
					{
						if (viewData.DAJGPBLEEOB_PrismCostumeId == m_selectCostumeData.DAJGPBLEEOB_PrismCostumeId)
						{
							return true;
						}
					}
					return false;
				});
			}
			else
			{
				m_rewadIconAnim.StartChildrenAnimGoStop("st_wait");
			}
			if(m_selectCostumeData.GKIKAABHAAD_Level < m_selectCostumeData.LLLCMHENKKN_LevelMax)
			{
				m_nextReawad.getIcon.StartChildrenAnimGoStop(1, 1);
				m_targetReawad.getIcon.StartChildrenAnimGoStop(1, 1);
			}
			else
			{
				m_nextReawad.getIcon.StartChildrenAnimGoStop(0, 0);
				m_targetReawad.getIcon.StartChildrenAnimGoStop(0, 0);
			}
		}

		//// RVA: 0x16EE2A8 Offset: 0x16EE2A8 VA: 0x16EE2A8
		private void SettingRelase(bool is_release)
		{
			if(is_release)
			{
				m_buttonTable.StartChildrenAnimGoStop(0, 0);
			}
			else
			{
				if(m_costumeUpgradeData.KFJHILDJCCB(m_selectCostumeData))
				{
					m_buttonTable.StartChildrenAnimGoStop(1, 1);
					m_conditionCheckButtonEffect.StartChildrenAnimLoop("lo");
				}
				else
				{
					m_buttonTable.StartChildrenAnimGoStop(2, 2);
				}
			}
			SettingReleaseLock(is_release);
		}

		//// RVA: 0x16EB094 Offset: 0x16EB094 VA: 0x16EB094
		public void SetFocus(int divaId, int cosutmeModelId, bool isUpdateFilter = false)
		{
			if (divaId == 0 || cosutmeModelId == 0)
				return;
			m_divaId = divaId;
			m_costumeModelId = cosutmeModelId;
			if(isUpdateFilter)
			{
				m_filterDivaIdList.Clear();
				m_filterDivaIdList.Add(divaId);
				SettingCostumeFilter();
				m_diva_select_window.SetFilterDivaIdList(m_filterDivaIdList);
			}
			m_cursorIndex = 0;
			for(int i = 0; i < m_filterCostumeDataList.Count; i++)
			{
				if(m_divaId == m_filterCostumeDataList[i].AHHJLDLAPAN_DivaId)
				{
					if(m_costumeModelId == m_filterCostumeDataList[i].DAJGPBLEEOB_PrismCostumeId)
					{
						m_cursorIndex = i;
						break;
					}
				}
			}
			SettingCostume();
		}

		//// RVA: 0x16EED08 Offset: 0x16EED08 VA: 0x16EED08
		public void ScrollerInputEnable(bool enable)
		{
			if(enable)
			{
				if (!m_rightArrowButton.IsInputOff)
					m_scroller.InputEnable();
			}
			m_scroller.InputDisable();
		}

		//// RVA: 0x16EEC48 Offset: 0x16EEC48 VA: 0x16EEC48
		private void SettingReleaseLock(bool is_release)
		{
			if(is_release)
			{
				if(m_selectCostumeData.GKIKAABHAAD_Level < m_selectCostumeData.LLLCMHENKKN_LevelMax)
				{
					m_releaseLock.StartChildrenAnimGoStop(0, 0);
				}
				else
				{
					m_releaseLock.StartChildrenAnimGoStop(2, 2);
				}
			}
			else
			{
				m_releaseLock.StartChildrenAnimGoStop(1, 1);
			}
		}

		//// RVA: 0x16EDD70 Offset: 0x16EDD70 VA: 0x16EDD70
		public void SetDivaImage(int divaId, int costumeModelId, int costumeColorId)
		{
			m_loadingDivaId = divaId;
			m_divaIconImage.enabled = false;
			RawImageEx image = m_divaIconImage;
			MenuScene.Instance.DivaIconCache.LoadStateIcon(divaId, costumeModelId, costumeColorId, (IiconTexture texture) =>
			{
				//0x16F168C
				if (m_loadingDivaId != divaId)
					return;
				image.enabled = true;
				texture.Set(image);
			});
		}

		//// RVA: 0x16EED90 Offset: 0x16EED90 VA: 0x16EED90
		private int DivaIdListToBit(List<int> list)
		{
			int res = 0;
			for(int i = 0; i < list.Count; i++)
			{
				res |= (1 << (list[i] - 1));
			}
			return res;
		}

		//// RVA: 0x16EAEDC Offset: 0x16EAEDC VA: 0x16EAEDC
		private List<int> BitToDivaIdList(int bit)
		{
			List<int> res = new List<int>();
			for(int i = 0; i < 10; i++)
			{
				if ((bit & (1 << (i))) != 0)
					res.Add(i + 1);
			}
			return res;
		}

		//// RVA: 0x16EEE64 Offset: 0x16EEE64 VA: 0x16EEE64
		public void SaveSelectDiva()
		{
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().MOBOMOEHGAO_CostumeUpgrade.BDIOOMFHPJA_SelectDivaId = m_divaId;
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().MOBOMOEHGAO_CostumeUpgrade.HEEJCAOKDPE_SelectCostumeId = m_costumeModelId;
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
		}

		//// RVA: 0x16EF014 Offset: 0x16EF014 VA: 0x16EF014
		private void CallBackDivaSelect()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			m_diva_select_window.FilterDivaIdList = m_filterDivaIdList;
			PopupWindowManager.Show(m_diva_select_window, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x16F143C
				if (label == PopupButton.ButtonLabel.Cancel)
					CallBackDivaSelectCancelButton();
				else if (label == PopupButton.ButtonLabel.Ok)
					CallBackDivaSelectOKButton();
			}, null, null, null);
		}

		//// RVA: 0x16EF194 Offset: 0x16EF194 VA: 0x16EF194
		private void CallBackDivaSelectOKButton()
		{
			List<int> ldiva = m_diva_select_window.GetFilterDivaIdList();
			if(ldiva.Count < 10)
			{
				foreach(var d in ldiva)
				{
					DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo dInfo = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(d);
					if(dInfo.CPGFPEDMDEH_Have == 0)
					{
						MessageBank bk = MessageManager.Instance.GetBank("menu");
						TextPopupSetting s = new TextPopupSetting();
						s.IsCaption = false;
						s.TitleText = "";
						s.Text = bk.GetMessageByLabel("costume_upgrade_diva_select_warning_text");
						s.Buttons = new ButtonInfo[1]
						{
							new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
						};
						PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel buttonLabel) =>
						{
							//0x16F17B4
							ldiva.Clear();
							for(int i = 0; i < 10; i++)
							{
								ldiva.Add(i + 1);
							}
							m_filterDivaIdList = ldiva;
							m_diva_select_window.SetFilterDivaIdList(m_filterDivaIdList);
							CallBackDivaSelect();
						}, null, null, null);
						return;
					}
				}
			}
			m_filterDivaIdList = ldiva;
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().MOBOMOEHGAO_CostumeUpgrade.AEKKEKBMOCF_DivaFilterBit = DivaIdListToBit(ldiva);
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
			m_cursorIndex = 0;
			SettingDivaFilter();
			SettingCostume();
		}

		//// RVA: 0x16EF7C0 Offset: 0x16EF7C0 VA: 0x16EF7C0
		private void CallBackDivaSelectCancelButton()
		{
			m_diva_select_window.SetFilterDivaIdList(m_filterDivaIdList);
		}

		//// RVA: 0x16EF7F4 Offset: 0x16EF7F4 VA: 0x16EF7F4
		private void CallBackReward()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			CostumeRewardPopupSetting s = new CostumeRewardPopupSetting();
			s.TitleText = bk.GetMessageByLabel("costume_upgrade_achievement_title_text");
			s.m_parent = transform;
			s.CostumeData = m_filterCostumeDataList[m_cursorIndex];
			s.WindowSize = SizeType.Large;
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			PopupWindowManager.Show(s, null, null, null, null);
		}

		//// RVA: 0x16EFAD8 Offset: 0x16EFAD8 VA: 0x16EFAD8
		private void CallBackLeft()
		{
			ButtonScroll(-1);
		}

		//// RVA: 0x16EFC04 Offset: 0x16EFC04 VA: 0x16EFC04
		private void CallBackRight()
		{
			ButtonScroll(1);
		}

		//// RVA: 0x16EFC0C Offset: 0x16EFC0C VA: 0x16EFC0C
		private void CallBackItemDetail()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			int level;
			if(m_targetReawad.iconBase.IsVisible)
			{
				level = m_selectCostumeData.HGBJODBCJDA - 1;
			}
			else
			{
				if(m_selectCostumeData.GKIKAABHAAD_Level < m_selectCostumeData.LLLCMHENKKN_LevelMax)
				{
					level = m_selectCostumeData.GKIKAABHAAD_Level;
				}
				else
				{
					level = m_selectCostumeData.LLLCMHENKKN_LevelMax - 1;
				}
			}
			CostumeUpgradeUtility.ShowItemDetailWindow(m_selectCostumeData, level, transform);
		}

		//// RVA: 0x16EFFBC Offset: 0x16EFFBC VA: 0x16EFFBC
		private void CallBackUseItem()
		{
			isItemSelectScene = true;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			CostumeUpgradeItemSelectSceneArgs arg = new CostumeUpgradeItemSelectSceneArgs();
			arg.upgradeData = m_filterCostumeDataList[m_cursorIndex];
			arg.data = m_costumeUpgradeData;
			arg.isPrevCostumeSelect = isPrevCostumeSelect;
			MenuScene.Instance.Call(TransitionList.Type.COSTUME_UPGRADE_ITEM_SELECT, arg, true);
		}

		//// RVA: 0x16F0178 Offset: 0x16F0178 VA: 0x16F0178
		private void CallBackRankUpUnlock()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			CostumeRankUpUnlockPopupSetting s = new CostumeRankUpUnlockPopupSetting();
			s.TitleText = bk.GetMessageByLabel("costume_upgrade_rankup_title_text");
			s.m_parent = transform;
			s.m_data = m_selectCostumeData;
			s.m_upgrade = m_costumeUpgradeData;
			s.WindowSize = SizeType.Middle;
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Release, Type = PopupButton.ButtonType.Positive }
			};
			m_rank_unlock_window = s;
			bool isApplyUnlockConnected = false;
			bool isStartApplyCostumeUnlock = false;
			bool isRankUpAnimation = false;
			PopupWindowManager.Show(m_rank_unlock_window, null, null, null, null, closeStartWaitCallBack: (PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x16F18FC
				if(label == PopupButton.ButtonLabel.Release)
				{
					if(!isStartApplyCostumeUnlock)
					{
						isStartApplyCostumeUnlock = true;
						m_costumeUpgradeData.JDLAFDBFLOM(m_selectCostumeData, () =>
						{
							//0x16F1AB4
							m_costumeUpgradeData.COLOGGOJGAJ();
							SettingRelase(true);
							isApplyUnlockConnected = true;
						});
					}
					if(!isApplyUnlockConnected)
						return false;
					else
					{
						if(!isRankUpAnimation)
						{
							m_rank_unlock_window.StartRankUnlockAnimation();
							isRankUpAnimation = true;
						}
						return !m_rank_unlock_window.IsPlayingAnimation();
					}
				}
				else
					return true;
			});
		}

		//// RVA: 0x16F0564 Offset: 0x16F0564 VA: 0x16F0564
		private void CallBackConditionCheck()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			CostumeRankUpUnlockPopupSetting s = new CostumeRankUpUnlockPopupSetting();
			s.TitleText = bk.GetMessageByLabel("costume_upgrade_rankup_title_text");
			s.m_parent = transform;
			s.m_data = m_selectCostumeData;
			s.m_upgrade = m_costumeUpgradeData;
			s.WindowSize = SizeType.Middle;
			s.Buttons = new ButtonInfo[1] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative } };
			m_rank_unlock_window = s;
			PopupWindowManager.Show(s, null, null, null, null);
		}

		//// RVA: 0x16EFAE0 Offset: 0x16EFAE0 VA: 0x16EFAE0
		private void ButtonScroll(int offset)
		{
			if(!m_isKeyScrool)
			{
				m_isKeyScrool = true;
				MenuScene.Instance.InputDisable();
				m_scroller.RequestFlow(offset, 0.2f, () =>
				{
					//0x16F1454
					MenuScene.Instance.InputEnable();
					m_isKeyScrool = false;
				});
			}
		}

		//// RVA: 0x16F0940 Offset: 0x16F0940 VA: 0x16F0940
		private void ChangeCostume(int offset = 0)
		{
			if(offset < 0)
			{
				if(m_cursorIndex < 1)
				{
					m_cursorIndex = m_filterCostumeDataList.Count;
				}
				m_cursorIndex--;
			}
			else
			{
				if (m_cursorIndex >= m_filterCostumeDataList.Count - 1)
					m_cursorIndex = 0;
				else
					m_cursorIndex++;
			}
			SettingCostumeUI(m_cursorIndex, false, offset < 0, false);
		}

		//// RVA: 0x16F0A40 Offset: 0x16F0A40 VA: 0x16F0A40
		protected void OnSelectionChanged(int offset)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_004);
			ChangeCostume(offset);
		}

		//// RVA: 0x16F0AAC Offset: 0x16F0AAC VA: 0x16F0AAC
		protected void OnScrollRepeated(int repeatDelta, bool isSelectionFlipped)
		{
			SettingCostumeUI(m_cursorIndex, true, -1 < repeatDelta, false);
		}

		//// RVA: 0x16F0AE0 Offset: 0x16F0AE0 VA: 0x16F0AE0
		protected void OnScrollStarted(bool isAuto)
		{
			return;
		}

		//// RVA: 0x16F0AE4 Offset: 0x16F0AE4 VA: 0x16F0AE4
		protected void OnScrollUpdated(bool isAuto)
		{
			return;
		}

		//// RVA: 0x16F0AE8 Offset: 0x16F0AE8 VA: 0x16F0AE8
		private void OnScrollEnded(bool isAuto)
		{
			SettingCostumeUI(m_cursorIndex, true, false, true);
			SettingScrollLimit();
		}

		//// RVA: 0x16F0B24 Offset: 0x16F0B24 VA: 0x16F0B24
		public void TryInstall()
		{
			for(int i = 0; i < m_costumeUpgradeData.MGJKEJHEBPO.Count; i++)
			{
				MenuScene.Instance.CostumeIconCache.TryInstallCostume(m_costumeUpgradeData.MGJKEJHEBPO[i].AHHJLDLAPAN_DivaId, m_costumeUpgradeData.MGJKEJHEBPO[i].DAJGPBLEEOB_PrismCostumeId, 0);
				MenuScene.Instance.DivaIconCache.TryInstall(m_costumeUpgradeData.MGJKEJHEBPO[i].AHHJLDLAPAN_DivaId, 1, 0);
				MenuScene.Instance.DivaIconCache.TryStateDivaIconInstall(m_costumeUpgradeData.MGJKEJHEBPO[i].AHHJLDLAPAN_DivaId, 1, 0);
				for(int j = 0; j < m_costumeUpgradeData.MGJKEJHEBPO[i].OCOOHBINGBG_LevelInfo.Count; j++)
				{
					if(m_costumeUpgradeData.MGJKEJHEBPO[i].OCOOHBINGBG_LevelInfo[j].PEEAGFNOFFO_UnlockType == LCLCCHLDNHJ_Costume.FPDJGDGEBNG_UnlockType.CFOEMAAKOMC_4_Costume/*4*/)
					{
						MenuScene.Instance.ItemTextureCache.TryInstall(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume, m_costumeUpgradeData.MGJKEJHEBPO[i].JPIDIENBGKH_CostumeId), m_costumeUpgradeData.MGJKEJHEBPO[i].OCOOHBINGBG_LevelInfo[j].KJNAHLOODKD_Value[0]);
					}
					else if(m_costumeUpgradeData.MGJKEJHEBPO[i].OCOOHBINGBG_LevelInfo[j].PEEAGFNOFFO_UnlockType == LCLCCHLDNHJ_Costume.FPDJGDGEBNG_UnlockType.NKKIKONDGPF_1/*1*/)
					{
						MenuScene.Instance.ItemTextureCache.TryInstall(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume, m_costumeUpgradeData.MGJKEJHEBPO[i].JPIDIENBGKH_CostumeId), 0);
					}
				}
			}
			MenuScene.Instance.SubPlateIconTextureCahe.TryInstall();
		}
	}
}
