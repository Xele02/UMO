using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System;
using XeApp.Game.Common;
using System.Linq;
using XeSys;
using mcrs;

namespace XeApp.Game.RhythmAdjust
{
	public class LayoutRhythmAdjustWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Slider m_sliderPrefab; // 0x14
		[SerializeField]
		private GameObject m_sliderParent; // 0x18
		private readonly string[] MODE_OBJ_NAME_TABLE = new string[2]
		{
			"sw_sel_note_adjust_btn_l_anim (AbsoluteLayout)",
			"sw_sel_note_adjust_btn_r_anim (AbsoluteLayout)"
		}; // 0x1C
		private readonly string[] MODE_EXID_TABLE = new string[2]
		{
			"sw_sel_note_adjust_win_sw_sel_note_adjust_btn_l_anim",
			"sw_sel_note_adjust_win_sw_sel_note_adjust_btn_r_anim"
		}; // 0x20
		private AbsoluteLayout m_bgAnime; // 0x24
		private AbsoluteLayout m_windowAnime; // 0x28
		private bool m_isWindowOpen; // 0x2C
		private Button[] m_ModeButton = new Button[2]; // 0x30
		private AbsoluteLayout[] m_ModeButtonAnim = new AbsoluteLayout[2]; // 0x34
		private Text m_AdjustValueText; // 0x38
		private Text m_AdjustMinText; // 0x3C
		private Text m_AdjustMaxText; // 0x40
		private TexUVListManager m_TexUvListManager; // 0x44
		private int m_AdjustMin; // 0x48
		private int m_AdjustMax; // 0x4C
		private LayoutRhythmAdjust.ModeType m_CurrMode = LayoutRhythmAdjust.ModeType.NONE; // 0x50
		public Action m_AdjustPlusCallBack; // 0x54
		public Action m_AdjustMinusCallBack; // 0x58
		public Action<LayoutRhythmAdjust.ModeType> m_ChangeModeCallBack; // 0x5C
		public Action m_DecideCallBack; // 0x60

		// RVA: 0xF5CD8C Offset: 0xF5CD8C VA: 0xF5CD8C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_TexUvListManager = uvMan;
			m_bgAnime = layout.FindViewByExId("sw_sel_note_adjust_sw_sel_note_adjust_transition_bg_anim") as AbsoluteLayout;
			m_windowAnime = layout.FindViewByExId("sw_sel_note_adjust_sw_sel_note_adjust_transition_anim") as AbsoluteLayout;
			if(!string.IsNullOrEmpty(RuntimeSettings.CurrentSettings.Language))
			{
				Utility.SearchGameObjectRecursively("set (TextView)", transform).GetComponent<Text>().alignment = TextAnchor.UpperRight;
			}
			m_bgAnime.StartChildrenAnimGoStop("st_out");
			m_windowAnime.StartChildrenAnimGoStop("st_out");
			ActionButton[] avts = GetComponentsInChildren<ActionButton>(true);
			ActionButton b1 = avts.Where((ActionButton _) =>
			{
				//0xF5E608
				return _.name == "sw_sel_note_adjust_btn_decid_anim (AbsoluteLayout)";
			}).First();
			b1.AddOnClickCallback(() =>
			{
				//0xF5E4F4
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				if(m_DecideCallBack != null)
					m_DecideCallBack();
			});
			b1 = avts.Where((ActionButton _) =>
			{
				//0xF5E688
				return _.name == "sw_sel_note_adjust_plus_btn_anim (AbsoluteLayout)";
			}).First();
			b1.AddOnClickCallback(() =>
			{
				//0xF5E564
				if(m_AdjustPlusCallBack != null)
					m_AdjustPlusCallBack();
			});
			b1 = avts.Where((ActionButton _) =>
			{
				//0xF5E708
				return _.name == "sw_sel_note_adjust_minus_btn_anim (AbsoluteLayout)";
			}).First();
			b1.AddOnClickCallback(() =>
			{
				//0xF5E578
				if(m_AdjustMinusCallBack != null)
					m_AdjustMinusCallBack();
			});
			Button[] btns = GetComponentsInChildren<Button>(true);
			for(int i = 0; i < m_ModeButton.Length; i++)
			{
				int index = i;
				m_ModeButton[i] = btns.Where((Button _) =>
				{
					//0xF5EA88
					return _.name == MODE_OBJ_NAME_TABLE[index];
				}).First();
				m_ModeButtonAnim[i] = layout.FindViewByExId(MODE_EXID_TABLE[i]) as AbsoluteLayout;
				m_ModeButton[i].onClick.AddListener(() =>
				{
					//0xF5EB18
					if(!ChangeMode((LayoutRhythmAdjust.ModeType)index))
						return;
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				});
			}
			Slider s = Instantiate(m_sliderPrefab);
			s.transform.SetParent(m_sliderParent.transform, false);
			s.transform.SetAsLastSibling();
			ChangeMode(LayoutRhythmAdjust.ModeType.ADJUST);
			TexUVData uvData = uvMan.GetUVData("sel_note_adjust_plus_btn");
			RawImageEx[] imgs = GetComponentsInChildren<RawImageEx>(true);
			RawImageEx img = imgs.Where((RawImageEx _) =>
			{
				//0xF5E788
				return _.name == "swtexf_sel_note_adjust_minus_btn (ImageView)";
			}).First();
			img.uvRect = LayoutUGUIUtility.MakeUnityUVRect(uvData);
			Text[] txts = GetComponentsInChildren<Text>(true);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_AdjustValueText = txts.Where((Text _) =>
			{
				//0xF5E808
				return _.name == "set_num (TextView)";
			}).First();
			m_AdjustMinText = txts.Where((Text _) =>
			{
				//0xF5E888
				return _.name == "minus (TextView)";
			}).First();
			m_AdjustMaxText = txts.Where((Text _) =>
			{
				//0xF5E908
				return _.name == "plus (TextView)";
			}).First();
			txts.Where((Text _) =>
			{
				//0xF5E988
				return _.name == "set (TextView)";
			}).First().text = bk.GetMessageByLabel("rhythm_adjust_set");
			txts.Where((Text _) =>
			{
				//0xF5EA08
				return _.name == "desk (TextView)";
			}).First().text = bk.GetMessageByLabel("rhythm_adjust_desc");
			Loaded();
			return true;
		}

		// // RVA: 0xF5B2D4 Offset: 0xF5B2D4 VA: 0xF5B2D4
		public bool ChangeMode(LayoutRhythmAdjust.ModeType mode)
		{
			if(m_CurrMode != mode)
			{
				m_CurrMode = mode;
				m_ModeButtonAnim[(int)mode].StartChildrenAnimGoStop("st_bot_on");
				for(int i = 0; i < m_ModeButtonAnim.Length; i++)
				{
					if((int)mode != i)
					{
						m_ModeButtonAnim[i].StartChildrenAnimGoStop("st_bot_off");
					}
				}
				if(m_ChangeModeCallBack != null)
					m_ChangeModeCallBack(mode);
			}
			return false;
		}

		// // RVA: 0xF5ABC8 Offset: 0xF5ABC8 VA: 0xF5ABC8
		public void Setup(int adjust_min, int adjust_max, Action cb_plus, Action cb_minus, Action<LayoutRhythmAdjust.ModeType> cb_change_mode, Action cb_decide)
		{
			m_AdjustMin = adjust_min;
			m_AdjustMax = adjust_max;
			m_AdjustMinText.text = m_AdjustMin.ToString("+#;-#;0");
			m_AdjustMaxText.text = m_AdjustMax.ToString("+#;-#;0");
			m_AdjustPlusCallBack = cb_plus;
			m_AdjustMinusCallBack = cb_minus;
			m_ChangeModeCallBack = cb_change_mode;
			m_DecideCallBack = cb_decide;
		}

		// // RVA: 0xF5AD14 Offset: 0xF5AD14 VA: 0xF5AD14
		public void SetAdjustValue(int value)
		{
			m_AdjustValueText.text = Mathf.Clamp(value, m_AdjustMin, m_AdjustMax).ToString("+#;-#;0");
		}

		// // RVA: 0xF5E118 Offset: 0xF5E118 VA: 0xF5E118
		// public bool IsReady() { }

		// // RVA: 0xF5AF18 Offset: 0xF5AF18 VA: 0xF5AF18
		public void Enter(bool isTutorial = false)
		{
			m_bgAnime.StartChildrenAnimGoStop("go_in", "st_in");
			if(!isTutorial)
				OpenWindow();
		}

		// // RVA: 0xF5E1B4 Offset: 0xF5E1B4 VA: 0xF5E1B4
		// public void Leave() { }

		// // RVA: 0xF5AFE0 Offset: 0xF5AFE0 VA: 0xF5AFE0
		public void OpenWindow()
		{
			if (m_isWindowOpen)
				return;
			m_windowAnime.StartChildrenAnimGoStop("go_in", "st_in");
			m_isWindowOpen = true;
		}

		// // RVA: 0xF5B0FC Offset: 0xF5B0FC VA: 0xF5B0FC
		public void CloseWindow()
		{
			if(m_isWindowOpen)
			{
				m_windowAnime.StartChildrenAnimGoStop("go_out", "st_out");
			}
			m_isWindowOpen = false;
		}

		// // RVA: 0xF5B0A8 Offset: 0xF5B0A8 VA: 0xF5B0A8
		public bool IsPlaying()
		{
			return m_windowAnime.IsPlayingChildren();
		}

		// // RVA: 0xF5E248 Offset: 0xF5E248 VA: 0xF5E248
		public void Update()
		{
			return;
		}
	}
}
