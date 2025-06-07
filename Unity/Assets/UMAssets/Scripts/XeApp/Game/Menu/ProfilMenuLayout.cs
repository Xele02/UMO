using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;
using System;
using XeSys;
using mcrs;
using System.Collections;
using XeApp.Core;
using System.Text;

namespace XeApp.Game.Menu
{
	public class ProfilMenuLayout : LayoutUGUIScriptBase
	{
		public enum InfoType
		{
			PLAYER = 0,
			SCENE = 1,
			STATS = 2,
			ASSIST = 3,
		}

		private enum ImageLoadFlags
		{
			None = 0,
			Diva = 1,
			Scene = 2,
			Degree = 4,
			Assist = 8,
			All = 15,
		}

		public enum ButtonType
		{
			None = 0,
			Fan = 1,
			Fan_NoLobby = 2,
			Raid = 3,
			Raid_Result = 4,
		}

		private class CostumeData
		{
			public CKFGMNAIBNG data; // 0x8
			public int color; // 0xC
		}

		private class AssistImageData
		{
			public int index; // 0x8
			public IiconTexture sceneTex; // 0xC
			public bool isKira; // 0x10
		}

		private const int MAIN_GUN_POWER_MAX = 999999;
		private const int FAN_COUNT_MAX = 99999;
		private const int StatsPageNum = 6;
		private const int AssistPageStatusNum = 3;
		private const int AssistPageSelectNum = 5;
		private const int AssistAttributeMax = 4;
		private const int AssistLoadImagePlayer = 20;
		private const int AssistLoadImageFriend = 4;
		private static readonly string[] DifficultUvTable = new string[5] {
			"cmn_music_diff_01", "cmn_music_diff_02", "cmn_music_diff_03",
			"cmn_music_diff_04", "cmn_music_diff_05"
		}; // 0x0
		private static readonly string[] DifficultUvTable_6Line = new string[3]
			{
				"cmn_music_diff_06", "cmn_music_diff_07", "cmn_music_diff_08"
			}; // 0x4
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x67693C Offset: 0x67693C VA: 0x67693C
		private Text m_player_name; // 0x14
		[SerializeField]
		private Text m_player_name_time; // 0x18
		[SerializeField]
		private RawImageEx m_diva_image; // 0x1C
		[SerializeField]
		private Transform m_diva_level; // 0x20
		[SerializeField]
		private ActionButton m_scene_info_tab_btn; // 0x24
		[SerializeField]
		private ActionButton m_player_info_tab_btn; // 0x28
		[SerializeField]
		private ActionButton m_stats_info_tab_btn; // 0x2C
		[SerializeField]
		private ActionButton m_assist_info_tab_btn; // 0x30
		[SerializeField]
		private ActionButton m_lobbyBrowsing_btn; // 0x34
		[SerializeField]
		private ActionButton m_fanRelease_btn; // 0x38
		[SerializeField]
		private ActionButton m_fanEntry_btn; // 0x3C
		[SerializeField]
		private ActionButton m_visit_btn; // 0x40
		[SerializeField]
		private ActionButton m_block_btn; // 0x44
		//[HeaderAttribute] // RVA: 0x676A48 Offset: 0x676A48 VA: 0x676A48
		[SerializeField]
		private Text m_degree; // 0x48
		[SerializeField]
		private Text m_comment; // 0x4C
		[SerializeField]
		private Text m_player_id; // 0x50
		[SerializeField]
		private Text m_player_level; // 0x54
		[SerializeField]
		private RawImageEx m_degree_image; // 0x58
		[SerializeField]
		private RawImageEx m_musicrate_image; // 0x5C
		[SerializeField]
		private Text m_musicrate00_text; // 0x60
		[SerializeField]
		private Text m_musicrate01_text; // 0x64
		[SerializeField]
		private ActionButton m_musicrate_popup_button; // 0x68
		[SerializeField]
		private ActionButton m_name_btn; // 0x6C
		[SerializeField]
		private ActionButton m_comment_btn; // 0x70
		[SerializeField]
		private ActionButton m_degree_btn; // 0x74
		[SerializeField]
		private ActionButton m_player_id_btn; // 0x78
		[SerializeField]
		private StayButton m_degree_info; // 0x7C
		[SerializeField]
		private NumberBase m_degree_num; // 0x80
		[SerializeField]
		private NumberBase m_fanCount_num; // 0x84
		[SerializeField]
		private Text m_mainGunPower_text; // 0x88
		//[HeaderAttribute] // RVA: 0x676B9C Offset: 0x676B9C VA: 0x676B9C
		[SerializeField]
		private Text[] m_center_skill_name; // 0x8C
		[SerializeField]
		private Text[] m_center_skill_desc; // 0x90
		[SerializeField]
		private Text[] m_center_skill_level; // 0x94
		[SerializeField]
		private RawImageEx[] m_center_skill_rank; // 0x98
		[SerializeField]
		private RawImageEx[] m_center_skill_foldout; // 0x9C
		[SerializeField]
		private ButtonBase[] m_center_skill_btn; // 0xA0
		[SerializeField]
		private RegulationButton m_center_skill_regu_btn; // 0xA4
		[SerializeField]
		private Text m_scene_name; // 0xA8
		[SerializeField]
		private RawImageEx m_scene_image; // 0xAC
		[SerializeField]
		private StayButton m_scene_info; // 0xB0
		[SerializeField]
		private LayoutUGUIHitOnly m_scene_hit_only; // 0xB4
		[SerializeField]
		private RectTransform m_scene_info_rect; // 0xB8
		[SerializeField]
		private Text m_scene_total; // 0xBC
		[SerializeField]
		private Text m_scene_soul; // 0xC0
		[SerializeField]
		private Text m_scene_voice; // 0xC4
		[SerializeField]
		private Text m_scene_charm; // 0xC8
		[SerializeField]
		private Text m_scene_life; // 0xCC
		[SerializeField]
		private Text m_scene_support; // 0xD0
		[SerializeField]
		private Text m_scene_fold; // 0xD4
		[SerializeField]
		private Text m_scene_luck; // 0xD8
		[SerializeField]
		private TextAnchor m_center_skill_name_align; // 0xDC
		[SerializeField]
		private TextAnchor m_center_skill_desc_align; // 0xE0
		[SerializeField]
		private TextAnchor m_center_skill_level_align; // 0xE4
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x676D58 Offset: 0x676D58 VA: 0x676D58
		private ActionButton m_page_left_btn; // 0xE8
		[SerializeField]
		private ActionButton m_page_right_btn; // 0xEC
		[SerializeField]
		private Text m_stats_page_num; // 0xF0
		[SerializeField]
		private Text m_stats_plate_count; // 0xF4
		[SerializeField]
		private Text m_stats_valkyrie_count; // 0xF8
		[SerializeField]
		private Text m_stats_lvmax_plate_count; // 0xFC
		[SerializeField]
		private Text m_stats_costume_count; // 0x100
		[SerializeField]
		private Text m_stats_mission_clear_count; // 0x104
		[SerializeField]
		private Text m_stats_clear_count; // 0x108
		[SerializeField]
		private Text m_stats_perfect_notes_count; // 0x10C
		[SerializeField]
		private Text m_stats_highscore_value; // 0x110
		[SerializeField]
		private Text m_stats_highscore_music; // 0x114
		[SerializeField]
		private RawImageEx m_stats_highscore_diff; // 0x118
		[SerializeField]
		private List<Text> m_stats_clear_music_count; // 0x11C
		[SerializeField]
		private List<Text> m_stats_fullcombo_music_count; // 0x120
		[SerializeField]
		private List<RawImageEx> m_stats_extreme_image; // 0x124
		[SerializeField]
		private Text m_emblem_scroll_text; // 0x128
		[SerializeField]
		private SwapScrollList m_swap_scroll; // 0x12C
		//[HeaderAttribute] // RVA: 0x676EB4 Offset: 0x676EB4 VA: 0x676EB4
		[SerializeField]
		private Text[] m_assist_attribute_title; // 0x130
		[SerializeField]
		private RawImageEx[] m_assist_scene_image; // 0x134
		[SerializeField]
		private Text m_assist_name; // 0x138
		[SerializeField]
		private Text m_assist_caution; // 0x13C
		[SerializeField]
		private Text m_assist_status_page_now; // 0x140
		[SerializeField]
		private Text m_assist_status_page_max; // 0x144
		[SerializeField]
		private Text[] m_assist_total; // 0x148
		[SerializeField]
		private Text[] m_assist_life; // 0x14C
		[SerializeField]
		private Text[] m_assist_center_skill_name; // 0x150
		[SerializeField]
		private Text[] m_assist_center_skill_level; // 0x154
		[SerializeField]
		private RawImageEx[] m_assist_certer_skill_rank; // 0x158
		[SerializeField]
		private Text[] m_assist_soul; // 0x15C
		[SerializeField]
		private Text[] m_assist_voice; // 0x160
		[SerializeField]
		private Text[] m_assist_charm; // 0x164
		[SerializeField]
		private Text[] m_assist_support; // 0x168
		[SerializeField]
		private Text[] m_assist_fold; // 0x16C
		[SerializeField]
		private Text[] m_assist_luck; // 0x170
		[SerializeField]
		private ActionButton m_assist_name_btn; // 0x174
		[SerializeField]
		private ActionButton m_assist_status_btn; // 0x178
		[SerializeField]
		private ActionButton[] m_assist_page_btn; // 0x17C
		[SerializeField]
		private StayButton[] m_assist_plate_btn; // 0x180
		[SerializeField]
		private SwaipTouch m_swaip_touch; // 0x184
		private AbsoluteLayout m_abs; // 0x188
		private AbsoluteLayout m_info_table; // 0x18C
		private AbsoluteLayout m_scene_info_btn; // 0x190
		private AbsoluteLayout m_player_info_btn; // 0x194
		private AbsoluteLayout m_stats_info_btn; // 0x198
		private AbsoluteLayout m_assist_info_btn; // 0x19C
		private AbsoluteLayout m_player_id_switch; // 0x1A0
		private AbsoluteLayout m_text_switch; // 0x1A4
		private AbsoluteLayout m_stats_page; // 0x1A8
		private AbsoluteLayout m_player_info_win; // 0x1AC
		private AbsoluteLayout m_center_skill_mask; // 0x1B0
		private AbsoluteLayout m_center_skill_cross_fade; // 0x1B4
		private AbsoluteLayout[] m_assist_status_layout; // 0x1B8
		private AbsoluteLayout m_assist_selectnum_layout; // 0x1BC
		private AbsoluteLayout[] m_assist_select_layout; // 0x1C0
		private AbsoluteLayout[] m_assist_skill_layout; // 0x1C4
		private AbsoluteLayout[] m_assist_skill_cross_fade_layout; // 0x1C8
		private AbsoluteLayout m_assist_name_btn_layout; // 0x1CC
		private AbsoluteLayout m_assist_arrow_layout; // 0x1D0
		private bool m_is_friend; // 0x1D4
		private IAPDFOPPGND m_degree_data; // 0x1D8
		private GCIJNCFDNON_SceneInfo m_scene_data; // 0x1DC
		private DivaIconDecoration m_level_icon; // 0x1E0
		private SceneIconDecoration m_scene_deco; // 0x1E4
		private SceneIconDecoration[] m_assist_scene_deco = new SceneIconDecoration[4]; // 0x1E8
		private DegreeSetPopupSetting m_degree_setting = new DegreeSetPopupSetting(); // 0x1EC
		private TextPopupSetting m_notChangedPlayerNamePopupSetting = new TextPopupSetting(); // 0x1F0
		private TextPopupSetting m_notChangedCommentPopupSetting = new TextPopupSetting(); // 0x1F4
		private Action m_updater; // 0x1F8
		private ImageLoadFlags m_imageLoadFlags; // 0x1FC
		private int m_stats_page_idx; // 0x200
		private string[] m_center_skill_full_desc = new string[2]
			{
				"", ""
			}; // 0x204
		private float m_copyButtonPrevPushSec; // 0x208
		private const float m_copyButtonIntervalSec = 3;
		private bool m_swap_scroll_loaded; // 0x20C
		private TransitionUniqueId m_transitionUniquId; // 0x210
		private List<CKFGMNAIBNG> m_costume_list; // 0x214
		private List<PNGOLKLFFLH> m_valkyrie_list; // 0x218
		private List<IAPDFOPPGND> m_emblem_list = new List<IAPDFOPPGND>(); // 0x21C
		private GHLGEECLCMH m_viewHSRatingData = new GHLGEECLCMH(); // 0x220
		private PopupDetailValkyrieSetting m_popup_setting_val = new PopupDetailValkyrieSetting(); // 0x224
		private TexUVListManager m_uvMan; // 0x228
		private EAJCBFGKKFA_FriendInfo m_friend_player_data; // 0x22C
		private bool m_enable_lobby_btn; // 0x230
		private ButtonType m_btnType; // 0x234
		private List<CostumeData> m_inner_costume_list; // 0x238
		private EEMGHIINEHN m_view_assist_data = new EEMGHIINEHN(); // 0x23C
		private int m_assist_status_page; // 0x240
		private int m_assist_select_page; // 0x244
		private int m_assist_load_image_count; // 0x248
		private int m_assist_load_image_max; // 0x24C
		private GCIJNCFDNON_SceneInfo[] m_assist_scene_data = new GCIJNCFDNON_SceneInfo[4]; // 0x250
		private List<AssistImageData> m_assist_imagedata_list = new List<AssistImageData>(); // 0x254
		private bool m_is_lock_scene; // 0x258
		private bool m_is_lock_swaip; // 0x259
		private bool m_is_stop_swaip; // 0x25A
		private bool m_is_enable_swaip; // 0x25B
		private const string LevelFormat = "Lv{0}";

		public bool IsFriend { get { return m_is_friend; } } //0x116B76C
		public List<CKFGMNAIBNG> CostumeList { get { return m_costume_list; } set { m_costume_list = value; } } //0x116B774 0x116B77C
		public List<PNGOLKLFFLH> ValkyrieList { get { return m_valkyrie_list; } set { m_valkyrie_list = value; } } //0x116B784 0x116B78C
		public List<IAPDFOPPGND> EmblemList { get { return m_emblem_list; } set { m_emblem_list = value; } } //0x116B794 0x116B79C

		// RVA: 0x116B7A4 Offset: 0x116B7A4 VA: 0x116B7A4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_uvMan = uvMan;
			m_abs = layout.FindViewByExId("root_sw_cmn_profile_sw_cmn_profile_anim") as AbsoluteLayout;
			m_info_table = layout.FindViewByExId("sw_cmn_profile_all_swtbl_cmn_pro") as AbsoluteLayout;
			m_scene_info_btn = layout.FindViewByExId("sw_cmn_pro_tab_all_swtbl_cmn_pro_tab_01") as AbsoluteLayout;
			m_player_info_btn = layout.FindViewByExId("sw_cmn_pro_tab_all_swtbl_cmn_pro_tab_02") as AbsoluteLayout;
			m_stats_info_btn = layout.FindViewByExId("sw_cmn_pro_tab_all_swtbl_cmn_pro_tab_03") as AbsoluteLayout;
			m_assist_info_btn = layout.FindViewByExId("sw_cmn_pro_tab_all_swtbl_cmn_pro_tab_04") as AbsoluteLayout;
			m_player_id_switch = layout.FindViewByExId("sw_cmn_pro_me_swtbl_cmn_pro_id") as AbsoluteLayout;
			m_text_switch = layout.FindViewByExId("sw_cmn_pro_degree_swtbl_cmn_pro_text") as AbsoluteLayout;
			m_stats_page = layout.FindViewByExId("sw_cmn_pro_grade_sw_cmn_grade_page_switch") as AbsoluteLayout;
			m_player_info_win = layout.FindViewByExId("swtbl_cmn_pro_sw_cmn_pro_me") as AbsoluteLayout;
			m_center_skill_mask = layout.FindViewByExId("sw_cmn_pro_diva_swtbl_black_onoff") as AbsoluteLayout;
			m_center_skill_cross_fade = layout.FindViewByExId("sw_cmn_pro_diva_sw_c_skill_cf_anim") as AbsoluteLayout;
			m_assist_selectnum_layout = layout.FindViewByExId("sw_assist_swtbl_bg_change_mark") as AbsoluteLayout;
			m_assist_select_layout = new AbsoluteLayout[5];
			for(int i = 0; i < m_assist_select_layout.Length; i++)
			{
				m_assist_select_layout[i] = layout.FindViewByExId(string.Format("swtbl_bg_change_mark_0{0}a", i + 1)) as AbsoluteLayout;
			}
			m_assist_status_layout = new AbsoluteLayout[4];
			m_assist_skill_layout = new AbsoluteLayout[4];
			m_assist_skill_cross_fade_layout = new AbsoluteLayout[4];
			for(int i = 0; i < m_assist_skill_layout.Length; i++)
			{
				m_assist_status_layout[i] = layout.FindViewByExId(string.Format("sw_assist_swtbl_assist_0{0}", i + 1)) as AbsoluteLayout;
				m_assist_skill_layout[i] = m_assist_status_layout[i].FindViewByExId("swtbl_assist_swtbl_note") as AbsoluteLayout;
				m_assist_skill_cross_fade_layout[i] = m_assist_status_layout[i].FindViewByExId("assist_01_sw_c_skill_cf_anim2") as AbsoluteLayout;
			}
			m_assist_name_btn_layout = layout.FindViewByExId("sw_assist_sw_asst_name_onoff_anim") as AbsoluteLayout;
			m_assist_arrow_layout = layout.FindViewByExId("sw_assist_sw_arrow_onoff") as AbsoluteLayout;
			m_scene_info_tab_btn.AddOnClickCallback(() =>
			{
				//0x117AC58
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				SetInfoTable(InfoType.SCENE);
			});
			m_player_info_tab_btn.AddOnClickCallback(() =>
			{
				//0x117ACC0
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				SetInfoTable(InfoType.PLAYER);
			});
			m_stats_info_tab_btn.AddOnClickCallback(() =>
			{
				//0x117AD28
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				SetInfoTable(InfoType.STATS);
			});
			m_assist_info_tab_btn.AddOnClickCallback(() =>
			{
				//0x117AD90
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				SetInfoTable(InfoType.ASSIST);
			});
			m_lobbyBrowsing_btn.AddOnClickCallback(OnClickLobbyBrowsing);
			m_fanRelease_btn.AddOnClickCallback(OnClickFanRelease);
			m_fanEntry_btn.AddOnClickCallback(OnClickFanEntry);
			m_visit_btn.AddOnClickCallback(OnClickVisit);
			m_block_btn.AddOnClickCallback(OnClickBlock);
			Transform t = m_player_id_btn.transform.Find("cmn_pro_font (AbsoluteLayout)/swtexf_cmn_pro_btn_font_01 (ImageView)");
			t.GetComponent<RawImageEx>().uvRect = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("cmn_pro_btn_font_03"));
			m_name_btn.AddOnClickCallback(() =>
			{
				//0x117ADF8
				OnChangePlayerName(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.OPFGFINHFCE_PlayerName);
			});
			m_comment_btn.AddOnClickCallback(() =>
			{
				//0x117AEE4
				OnChangeComment(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.CMKKFCGBILD_Prof);
			});
			m_degree_btn.AddOnClickCallback(() =>
			{
				//0x117BD90
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				MenuScene.Instance.Call(TransitionList.Type.DEGREE_SELECT, null, true);
			});
			m_degree_info.AddOnClickCallback(OnClickDegreeInfo);
			m_degree_info.AddOnStayCallback(OnClickDegreeInfo);
			m_player_id_btn.AddOnClickCallback(() =>
			{
				//0x117AFD8
				if (Time.realtimeSinceStartup - m_copyButtonPrevPushSec < 3)
					return;
				m_copyButtonPrevPushSec = Time.realtimeSinceStartup - m_copyButtonPrevPushSec;
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				OnClickPlayerIdCopy();
			});
			m_musicrate_popup_button.AddOnClickCallback(() =>
			{
				//0x117B060
				OnClickMusicRateDetail();
			});
			m_scene_info.AddOnClickCallback(() =>
			{
				//0x117B064
				OnClickSceneInfo();
			});
			m_scene_info.AddOnStayCallback(() =>
			{
				//0x117B068
				OnClickSceneInfo();
			});
			m_page_left_btn.AddOnClickCallback(() =>
			{
				//0x117B06C
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				UpdateStatsPage(m_stats_page_idx - 1);
			});
			m_page_right_btn.AddOnClickCallback(() =>
			{
				//0x117B070
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				UpdateStatsPage(m_stats_page_idx + 1);
			});
			this.StartCoroutineWatched(Load_ScrollItemIcon());
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_popup_setting_val.TitleText = bk.GetMessageByLabel("popup_title_04");
			m_popup_setting_val.SetParent(transform);
			m_assist_status_btn.AddOnClickCallback(OnClickAssistStatusPage);
			m_assist_page_btn[0].AddOnClickCallback(() =>
			{
				//0x117B074
				ChangeAssistSelectPage(m_assist_select_page - 1);
				m_is_lock_swaip = true;
				SwaipReset();
			});
			m_assist_page_btn[1].AddOnClickCallback(() =>
			{
				//0x117B0A4
				ChangeAssistSelectPage(m_assist_select_page + 1);
				m_is_lock_swaip = true;
				SwaipReset();
			});
			for(int i = 0; i < 4; i++)
			{
				int attribute = i;
				m_assist_plate_btn[i].AddOnStayCallback(() =>
				{
					//0x117C67C
					OnStayAssistScene(attribute);
				});
			}
			m_assist_name_btn.AddOnClickCallback(() =>
			{
				//0x117B0D4
				OnChangeAssitName(m_assist_select_page);
			});
			m_notChangedPlayerNamePopupSetting = PopupWindowManager.CrateTextContent(
				MessageManager.Instance.GetMessage("common", "popup_ngword_error_title"),
				0,
				MessageManager.Instance.GetMessage("menu", "popup_text_notchangedplayername"),
				new ButtonInfo[1]{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				}, false, true);
			m_notChangedCommentPopupSetting = PopupWindowManager.CrateTextContent(
				MessageManager.Instance.GetMessage("common", "popup_ngword_error_title"),
				0,
				MessageManager.Instance.GetMessage("menu", "popup_text_notchangedcomment"),
				new ButtonInfo[1]{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				}, false, true);
			this.StartCoroutineWatched(LoadDegreeInfoWindow());
			m_updater = UpdateLoad;
			return true;
		}

		// RVA: 0x116D6E8 Offset: 0x116D6E8 VA: 0x116D6E8
		private void Update()
		{
			if (m_updater != null)
				m_updater();
		}

		//// RVA: 0x116D6FC Offset: 0x116D6FC VA: 0x116D6FC
		private void UpdateLoad()
		{
			if(m_degree_setting.Content != null)
			{
				if(m_degree_num.IsLoaded())
				{
					if(m_swap_scroll_loaded)
					{
						Loaded();
						m_updater = UpdateIdle;
					}
				}
			}
		}

		//// RVA: 0x116D834 Offset: 0x116D834 VA: 0x116D834
		private void UpdateIdle()
		{
			if (!m_swaip_touch.IsReady() || m_is_stop_swaip)
				return;
			if (!m_is_enable_swaip)
				return;
			if(m_is_lock_scene)
			{
				if (!m_swaip_touch.IsSwaiping())
					m_is_lock_scene = false;
			}
			if(m_swaip_touch.IsSwaip(SwaipTouch.Direction.RIGHT) || m_swaip_touch.IsFlickNoSwaip(SwaipTouch.Direction.RIGHT))
			{
				if(!m_is_lock_swaip)
				{
					ChangeAssistSelectPage(m_assist_select_page - 1);
					m_is_lock_scene = true;
					m_is_lock_swaip = true;
				}
			}
			if (m_swaip_touch.IsSwaip(SwaipTouch.Direction.LEFT) || m_swaip_touch.IsFlickNoSwaip(SwaipTouch.Direction.LEFT))
			{
				if (!m_is_lock_swaip)
				{
					ChangeAssistSelectPage(m_assist_select_page + 1);
					m_is_lock_scene = true;
					m_is_lock_swaip = true;
				}
			}
			if(!m_assist_status_btn.IsPlaying())
			{
				if (m_is_lock_swaip)
					m_is_lock_swaip = false;
			}
		}

		//// RVA: 0x116DA00 Offset: 0x116DA00 VA: 0x116DA00
		private void WaitEnterLeave()
		{
			if (m_abs.IsPlayingChildren())
				return;
			m_updater = UpdateIdle;
		}

		//// RVA: 0x116DAB0 Offset: 0x116DAB0 VA: 0x116DAB0
		public void Out()
		{
			m_abs.StartChildrenAnimGoStop("st_out", "st_out");
		}

		//// RVA: 0x116DB30 Offset: 0x116DB30 VA: 0x116DB30
		public void Enter()
		{
			m_abs.StartChildrenAnimGoStop("go_in", "st_in");
			m_updater = WaitEnterLeave;
		}

		//// RVA: 0x116DBF8 Offset: 0x116DBF8 VA: 0x116DBF8
		public void Leave()
		{
			m_abs.StartChildrenAnimGoStop("go_out", "st_out");
			m_updater = WaitEnterLeave;
		}

		//// RVA: 0x116DCC0 Offset: 0x116DCC0 VA: 0x116DCC0
		public void OtherRelease()
		{
			if (m_level_icon != null)
				m_level_icon.Release();
			if (m_scene_deco != null)
				m_scene_deco.Release();
			for(int i = 0; i < 4; i++)
			{
				if(m_assist_scene_deco[i] != null)
				{
					m_assist_scene_deco[i].Release();
				}
			}
		}

		//// RVA: 0x116DD98 Offset: 0x116DD98 VA: 0x116DD98
		public bool IsLoadingImage()
		{
			return m_imageLoadFlags == ImageLoadFlags.All;
		}

		//// RVA: 0x116DDAC Offset: 0x116DDAC VA: 0x116DDAC
		public void Init()
		{
			m_imageLoadFlags = 0;
			m_is_friend = false;
			m_friend_player_data = null;
			m_enable_lobby_btn = false;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			JLKEOGLJNOD_TeamInfo t = GameManager.Instance.ViewPlayerData.DPLBHAIKPGL_GetTeam(false);
			SetDivaImage(t.BCJEAJPLGMB_MainDivas[0].AHHJLDLAPAN_DivaId, t.BCJEAJPLGMB_MainDivas[0].FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, t.BCJEAJPLGMB_MainDivas[0].EKFONBFDAAP_ColorId);
			SetMusicRate(GameManager.Instance.ViewPlayerData.AGJIIKKOKFJ_MusicRate);
			m_viewHSRatingData.KHEKNNFCAOI(null, null);
			GCIJNCFDNON_SceneInfo scene = null;
			if(t.BCJEAJPLGMB_MainDivas[0].FGFIBOBAPIA_SceneId > 0)
			{
				scene = GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes[t.BCJEAJPLGMB_MainDivas[0].FGFIBOBAPIA_SceneId - 1];
			}
			SetMainSceneInfo(scene);
			SetCenterSkillInfo(t.BCJEAJPLGMB_MainDivas[0], m_scene_data);
			m_player_name.text = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.OPFGFINHFCE_PlayerName;
			m_player_id.text = NKGJPJPHLIF.HHCJCDFCLOB.CAFHLEFMMGD_GetPlayerId().ToString();
			m_comment.text = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.CMKKFCGBILD_Prof;
			m_comment.horizontalOverflow = HorizontalWrapMode.Wrap;
			SetDegreeInfo(GameManager.Instance.ViewPlayerData.NDOLELKAJNL_Degree);
			m_degree_data = GetDegreeData(GameManager.Instance.ViewPlayerData.NDOLELKAJNL_Degree.MDPKLNFFDBO_EmblemId);
			int IBAKPKKEDJM = 0;
			int BAOFEFFADPD = 0;
			if (CIOECGOMILE.HHCJCDFCLOB.HNDJBAAAHDO(ref IBAKPKKEDJM, ref BAOFEFFADPD))
			{
				SetChangePlayerNameTime(IBAKPKKEDJM, BAOFEFFADPD);
			}
			else
			{
				m_player_name_time.text = "";
			}
			m_level_icon = new DivaIconDecoration(m_diva_level.gameObject, DivaIconDecoration.Size.L, null, null);
			m_level_icon.Change(t.BCJEAJPLGMB_MainDivas[0], GameManager.Instance.ViewPlayerData, DisplayType.Level);
			m_player_id_switch.StartChildrenAnimGoStop(0, 0);
			m_text_switch.StartChildrenAnimGoStop(0, 0);
			SetStatsInfo(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MHEAEGMIKIE_PublicStatus);
			AssistSelectInit();
		}

		//// RVA: 0x1171608 Offset: 0x1171608 VA: 0x1171608
		public void Init(EAJCBFGKKFA_FriendInfo data, bool a_enable_lobby_btn)
		{
			m_imageLoadFlags = 0;
			m_is_friend = true;
			m_friend_player_data = data;
			m_enable_lobby_btn = a_enable_lobby_btn;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			SetDivaImage(data.JIGONEMPPNP_Diva.AHHJLDLAPAN_DivaId, data.JIGONEMPPNP_Diva.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, data.JIGONEMPPNP_Diva.EKFONBFDAAP_ColorId);
			SetMusicRate(data.AGJIIKKOKFJ_ScoreRatingRank);
			m_viewHSRatingData = data.PPMGIDEHHDI_ViewHSRatingData;
			SetMainSceneInfo(data.JIGONEMPPNP_Diva.FGFIBOBAPIA_SceneId < 1 ? null : data.AFBMEMCHJCL_MainScene);
			SetCenterSkillInfo(data.JIGONEMPPNP_Diva, m_scene_data);
			m_player_name.text = data.LBODHBDOMGK_Name;
			m_player_id.text = "";
			m_player_name_time.text = "";
			m_comment.text = data.FGMPKKOOGCM_Comment;
			m_comment.horizontalOverflow = HorizontalWrapMode.Wrap;
			SetDegreeInfo(data.NDOLELKAJNL_DegreeData);
			m_degree_data = data.NDOLELKAJNL_DegreeData;
			m_name_btn.Hidden = true;
			m_comment_btn.Hidden = true;
			m_degree_btn.Hidden = true;
			m_player_level.text = bk.GetMessageByLabel("profil_text_04") + data.ILOJAJNCPEC_Rank.ToString();
			m_level_icon = new DivaIconDecoration(m_diva_level.gameObject, DivaIconDecoration.Size.L, null, null);
			m_level_icon.Change(data.JIGONEMPPNP_Diva, GameManager.Instance.ViewPlayerData, DisplayType.Level);
			m_player_id_switch.StartChildrenAnimGoStop(1, 1);
			m_text_switch.StartChildrenAnimGoStop(1, 1);
			SetStatsInfo(data.PCEGKKLKFNO.AHEFHIMGIBI_ServerData.MHEAEGMIKIE_PublicStatus);
			AssistSelectInit(data);
		}

		//// RVA: 0x1171E90 Offset: 0x1171E90 VA: 0x1171E90
		public void SetInfoTable(InfoType type)
		{
			m_info_table.StartChildrenAnimGoStop((int)type, (int)type);
			switch(type)
			{
				case InfoType.PLAYER:
					m_scene_info_btn.StartChildrenAnimGoStop(0, 0);
					m_player_info_btn.StartChildrenAnimGoStop(1, 1);
					m_stats_info_btn.StartChildrenAnimGoStop(0, 0);
					m_assist_info_btn.StartChildrenAnimGoStop(0, 0);
					m_is_stop_swaip = true;
					break;
				case InfoType.SCENE:
					m_scene_info_btn.StartChildrenAnimGoStop(1, 1);
					m_player_info_btn.StartChildrenAnimGoStop(0, 0);
					m_stats_info_btn.StartChildrenAnimGoStop(0, 0);
					m_assist_info_btn.StartChildrenAnimGoStop(0, 0);
					m_is_stop_swaip = true;
					break;
				case InfoType.STATS:
					m_scene_info_btn.StartChildrenAnimGoStop(0, 0);
					m_player_info_btn.StartChildrenAnimGoStop(0, 0);
					m_stats_info_btn.StartChildrenAnimGoStop(1, 1);
					m_assist_info_btn.StartChildrenAnimGoStop(0, 0);
					UpdateStatsPage(m_stats_page_idx);
					m_is_stop_swaip = true;
					break;
				case InfoType.ASSIST:
					m_scene_info_btn.StartChildrenAnimGoStop(0, 0);
					m_player_info_btn.StartChildrenAnimGoStop(0, 0);
					m_stats_info_btn.StartChildrenAnimGoStop(0, 0);
					m_assist_info_btn.StartChildrenAnimGoStop(1, 1);
					m_is_stop_swaip = false;
					break;
			}
			SwaipReset();
		}

		//// RVA: 0x11722DC Offset: 0x11722DC VA: 0x11722DC
		public void SetPlayerInfoWindow(bool IsEnableCannon, bool IsEnableFan)
		{
			string s = "";
			if (IsEnableCannon && IsEnableFan)
				s = "04";
			else
			{
				s = "01";
				if (IsEnableCannon)
					s = "03";
				if (IsEnableFan)
					s = "02";
			}
			m_player_info_win.StartChildrenAnimGoStop(s);
		}

		//// RVA: 0x11723A0 Offset: 0x11723A0 VA: 0x11723A0
		public void SetTransitionUniqueId(TransitionUniqueId uniqueId)
		{
			m_transitionUniquId = uniqueId;
		}

		//// RVA: 0x11723A8 Offset: 0x11723A8 VA: 0x11723A8
		//private int CountHaveScene() { }

		//// RVA: 0x1172564 Offset: 0x1172564 VA: 0x1172564
		public bool IsPlaying()
		{
			return m_abs.IsPlayingChildren();
		}

		//// RVA: 0x116E4F0 Offset: 0x116E4F0 VA: 0x116E4F0
		public void SetDivaImage(int diva_no, int cos_no, int color_no)
		{
			GameManager.Instance.DivaIconCache.LoadPortraitIcon(diva_no, cos_no, color_no, (IiconTexture icon) =>
			{
				//0x117B0DC
				icon.Set(m_diva_image);
				m_imageLoadFlags |= ImageLoadFlags.Diva;
			});
		}

		//// RVA: 0x116E618 Offset: 0x116E618 VA: 0x116E618
		public void SetMusicRate(HighScoreRatingRank.Type a_icon_type)
		{
			m_musicrate00_text.text = HighScoreRatingRank.GetRankName(a_icon_type);
			m_musicrate01_text.text = "---";
			GameManager.Instance.MusicRatioTextureCache.Load(a_icon_type, (IiconTexture texture) =>
			{
				//0x117C6AC
				if(texture != null && texture is MusicRatioTextureCache.MusicRatioTexture)
				{
					(texture as MusicRatioTextureCache.MusicRatioTexture).Set(m_musicrate_image, a_icon_type);
				}
			});
		}

		//// RVA: 0x1172598 Offset: 0x1172598 VA: 0x1172598
		public void SetMusicRanking(int a_rank)
		{
			m_musicrate01_text.text = OEGIPPCADNA.GEEFFAEGHAH(a_rank, true);
		}

		//// RVA: 0x11725E4 Offset: 0x11725E4 VA: 0x11725E4
		public void SetDegreeImage(int degree_no)
		{
			if (degree_no == 1)
			{
				m_degree_image.enabled = false;
				m_imageLoadFlags |= ImageLoadFlags.Degree;
			}
			else
			{
				m_degree_image.enabled = true;
				GameManager.Instance.ItemTextureCache.LoadEmblem(degree_no, (IiconTexture icon) =>
				{
					//0x117B1C8
					icon.Set(m_degree_image);
					m_imageLoadFlags |= ImageLoadFlags.Degree;
				});
			}
		}

		//// RVA: 0x117273C Offset: 0x117273C VA: 0x117273C
		public void SetSceneImage(int id, int rank, bool isKira)
		{
			GameManager.Instance.SceneIconCache.Load(id, rank, (IiconTexture icon) =>
			{
				//0x117C784
				icon.Set(m_scene_image);
				SceneIconTextureCache.ChangeKiraMaterial(m_scene_image, icon as IconTexture, isKira);
				m_imageLoadFlags |= ImageLoadFlags.Scene;
			});
		}

		//// RVA: 0x11728B8 Offset: 0x11728B8 VA: 0x11728B8
		private void SetAssistSceneImage(int id, int rank, bool isKira, int num)
		{
			int listNum = num;
			GameManager.Instance.SceneIconCache.Load(id, rank, (IiconTexture icon) =>
			{
				//0x117C920
				AssistImageData data = new AssistImageData();
				data.index = listNum;
				data.sceneTex = icon;
				data.isKira = isKira;
				m_assist_imagedata_list.Add(data);
				m_assist_load_image_count++;
				if (m_assist_load_image_count != m_assist_load_image_max)
					return;
				m_imageLoadFlags |= ImageLoadFlags.Assist;
				m_assist_load_image_count = 0;
				SetAssistSceneImage();
			});
		}

		//// RVA: 0x1172A4C Offset: 0x1172A4C VA: 0x1172A4C
		private void SetAssistSceneImage()
		{
			for(int i = 0; i < 4; i++)
			{
				for(int j = 0; j < m_assist_imagedata_list.Count; j++)
				{
					if (m_assist_imagedata_list[j].index == i + m_assist_select_page * 4)
					{
						m_assist_imagedata_list[j].sceneTex.Set(m_assist_scene_image[i]);
						SceneIconTextureCache.ChangeKiraMaterial(m_assist_scene_image[i], m_assist_imagedata_list[j].sceneTex as IconTexture, m_assist_imagedata_list[j].isKira);
					}
				}
			}
		}

		//// RVA: 0x1170374 Offset: 0x1170374 VA: 0x1170374
		private void SetChangePlayerNameTime(int mon, int day)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_player_name_time.text = string.Format(bk.GetMessageByLabel("profil_text_05"), day, mon);
		}

		//// RVA: 0x1172D10 Offset: 0x1172D10 VA: 0x1172D10
		private void OnChangePlayerName(string playerName)
		{
			int mon = 0;
			int day = 0;
			if(!CIOECGOMILE.HHCJCDFCLOB.HNDJBAAAHDO(ref mon, ref day))
			{
				this.StartCoroutineWatched(OnChangePlayerNameCoroutine(playerName));
			}
			else
			{
				FailurePlayerName();
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FE994 Offset: 0x6FE994 VA: 0x6FE994
		//// RVA: 0x1172DFC Offset: 0x1172DFC VA: 0x1172DFC
		private IEnumerator OnChangePlayerNameCoroutine(string playerName)
		{
			//0x9CE8B0
			bool isWait = true;
			bool isDecide = false;
			string inputText = "";
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			InputPopupSetting s = new InputPopupSetting();
			s.TitleText = bk.GetMessageByLabel("popup_title_profil_01");
			s.InputText = playerName;
			s.CharacterLimit = 10;
			s.WindowSize = SizeType.Middle;
			s.Description = bk.GetMessageByLabel("popup_title_profil_02");
			s.Notes = bk.GetMessageByLabel("popup_title_profil_03");
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x117CB08
				if(type == PopupButton.ButtonType.Positive)
				{
					isDecide = true;
					inputText = (control.Content as InputContent).Text;
				}
				isWait = false;
			}, null, null, null);
			while (isWait)
				yield return null;
			if (isDecide)
			{
				if(IsChangePlayerName(inputText))
				{
					MenuScene.Instance.InputDisable();
					BHLFHHBDGHO.GEJEDJNKBOF(inputText, () =>
					{
						//0x117CC48
						MenuScene.Instance.InputEnable();
						ConfirmPlayerName(inputText);
					}, () =>
					{
						//0x117BE90
						MenuScene.Instance.InputEnable();
					}, () =>
					{
						//0x117BF2C
						MenuScene.Instance.InputEnable();
						MenuScene.Instance.GotoTitle();
					});
				}
				else
				{
					ShowNotChangedPlayerNamePopup();
				}
			}
		}

		//// RVA: 0x11732FC Offset: 0x11732FC VA: 0x11732FC
		private void ConfirmPlayerName(string playerName)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting setting = new TextPopupSetting();
			setting.TitleText = bk.GetMessageByLabel("popup_title_profil_04");
			setting.WindowSize = SizeType.Middle;
			setting.Text = "\n" + playerName + bk.GetMessageByLabel("popup_title_profil_05");
			setting.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(setting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				// 0x117CD0C
				this.StartCoroutineWatched(ChangePlayerNameCoroutine(playerName));
			}, (IPopupContent content, PopupTabButton.ButtonLabel label) =>
			{
				//0x117BFF0
				return;
			}, null, null);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FEA0C Offset: 0x6FEA0C VA: 0x6FEA0C
		//// RVA: 0x11737A4 Offset: 0x11737A4 VA: 0x11737A4
		private IEnumerator ChangePlayerNameCoroutine(string playerName)
		{
			int mon; // 0x1C
			int day; // 0x20

			//0x117DAB4
			bool isError = false;
			MenuScene.Instance.InputDisable();
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.OPFGFINHFCE_PlayerName = playerName;
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.AFPONJEJKCO_RenameDate = time;
			mon = 0;
			day = 0;
			CIOECGOMILE.HHCJCDFCLOB.HNDJBAAAHDO(ref mon, ref day);
			MenuScene.Save(null, () =>
			{
				//0x117CD7C
				isError = true;
			});
			while (CIOECGOMILE.HHCJCDFCLOB.KONHMOLMOCI_IsSaving)
				yield return null;
			while(isError)
				yield return null;
			m_player_name.text = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.OPFGFINHFCE_PlayerName;
			m_comment.text = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.CMKKFCGBILD_Prof;
			MenuScene.Instance.InputEnable();
			SetChangePlayerNameTime(mon, day);
			ChangePlayerName();
		}

		//// RVA: 0x117386C Offset: 0x117386C VA: 0x117386C
		private bool IsChangePlayerName(string changedName)
		{
			return changedName != CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.OPFGFINHFCE_PlayerName;
		}

		//// RVA: 0x1173958 Offset: 0x1173958 VA: 0x1173958
		private bool IsChangeComment(string changedComment)
		{
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.CMKKFCGBILD_Prof != changedComment;
		}

		//// RVA: 0x1173A44 Offset: 0x1173A44 VA: 0x1173A44
		private void ChangePlayerName()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("popup_title_profil_06"), SizeType.Small, bk.GetMessageByLabel("popup_title_profil_07"), new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			}, false, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x117BFF4
				return;
			}, (IPopupContent content, PopupTabButton.ButtonLabel label) =>
			{
				//0x117BFF8
				return;
			}, null, null);
		}

		//// RVA: 0x1172EA0 Offset: 0x1172EA0 VA: 0x1172EA0
		private void FailurePlayerName()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("popup_title_profil_06"), SizeType.Small, 
				bk.GetMessageByLabel("popup_title_profil_08"), new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				}, false, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x117BFFC
					return;
				}, (IPopupContent content, PopupTabButton.ButtonLabel label) =>
				{
					//0x117C000
					return;
				}, null, null);
		}

		//// RVA: 0x1173E54 Offset: 0x1173E54 VA: 0x1173E54
		private void ShowNotChangedPlayerNamePopup()
		{
			PopupWindowManager.Show(m_notChangedPlayerNamePopupSetting, null, null, null, null);
		}

		//// RVA: 0x1173F18 Offset: 0x1173F18 VA: 0x1173F18
		private void ShowNotChangedCommentPopup()
		{
			PopupWindowManager.Show(m_notChangedCommentPopupSetting, null, null, null, null);
		}

		//// RVA: 0x1173FDC Offset: 0x1173FDC VA: 0x1173FDC
		private void OnChangeComment(string comment)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(OnChangeCommentCoroutine(comment));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FEA84 Offset: 0x6FEA84 VA: 0x6FEA84
		//// RVA: 0x1174058 Offset: 0x1174058 VA: 0x1174058
		private IEnumerator OnChangeCommentCoroutine(string comment)
		{
			//0x9CDFBC
			bool isWait = true;
			bool isDecide = false;
			string inputComment = "";
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			InputPopupSetting setting = new InputPopupSetting();
			setting.TitleText = bk.GetMessageByLabel("popup_title_profil_09");
			setting.InputText = comment;
			setting.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive },
			};
			setting.InputLineCount = 2;
			setting.CharacterLimit = 25;
			setting.WindowSize = SizeType.Middle;
			setting.Description = bk.GetMessageByLabel("popup_title_profil_10");
			setting.Notes = bk.GetMessageByLabel("popup_title_profil_11");
			PopupWindowManager.Show(setting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x117CD90
				if(type == PopupButton.ButtonType.Positive)
				{
					isDecide = true;
					inputComment = (control.Content as InputContent).Text;
				}
				isWait = false;
			}, null, null, null);
			while (isWait)
				yield return null;
			if(isDecide)
			{
				if(IsChangeComment(inputComment))
				{
					MenuScene.Instance.InputDisable();
					BHLFHHBDGHO.GEJEDJNKBOF(inputComment, () =>
					{
						//0x117CED8
						this.StartCoroutineWatched(OnChangeCommentCoroutine2(inputComment));
					}, () =>
					{
						//0x117C004
						MenuScene.Instance.InputEnable();
					}, () =>
					{
						//0x117C0A0
						MenuScene.Instance.InputEnable();
						MenuScene.Instance.GotoTitle();
					});
				}
				else
				{
					ShowNotChangedCommentPopup();
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FEAFC Offset: 0x6FEAFC VA: 0x6FEAFC
		//// RVA: 0x11740FC Offset: 0x11740FC VA: 0x11740FC
		private IEnumerator OnChangeCommentCoroutine2(string inputComment)
		{
			//0x9CDA64
			bool isError = false;
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.CMKKFCGBILD_Prof = inputComment;
			ILLPDLODANB.HECOAKHIAKP(ILLPDLODANB.LOEGALDKHPL.HDJGNKOIMOH/*26*/, 2, false);
			MenuScene.Save(null, () =>
			{
				//0x117CF40
				isError = true;
			});
			while (CIOECGOMILE.HHCJCDFCLOB.KONHMOLMOCI_IsSaving)
				yield return null;
			while (isError)
				yield return null;
			MenuScene.Instance.InputEnable();
			m_comment.text = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.CMKKFCGBILD_Prof;
			m_player_name.text = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.OPFGFINHFCE_PlayerName;
			ChangeComment();
		}

		//// RVA: 0x11741A0 Offset: 0x11741A0 VA: 0x11741A0
		private void ChangeComment()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("popup_title_profil_12"), SizeType.Small, bk.GetMessageByLabel("popup_title_profil_13"), new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			}, false, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x117C164
				return;
			}, (IPopupContent content, PopupTabButton.ButtonLabel label) =>
			{
				//0x117C168
				return;
			}, null, null);
		}

		//// RVA: 0x11745B0 Offset: 0x11745B0 VA: 0x11745B0
		private void OnClickPlayerIdCopy()
		{
			ClipboardSupport.SendSharedIntent(NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId.ToString());
		}

		//// RVA: 0x1174674 Offset: 0x1174674 VA: 0x1174674
		private void OnClickMusicRateDetail()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			PopupMusicRateListContentSetting s = new PopupMusicRateListContentSetting();
			s.View = m_viewHSRatingData;
			s.WindowSize = SizeType.Large;
			s.TitleText = bk.GetMessageByLabel("popup_music_rate_title");
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			s.Tabs = new PopupTabButton.ButtonLabel[2]
			{
				PopupTabButton.ButtonLabel.MusicRateDetail,
				PopupTabButton.ButtonLabel.MusicGradeView
			};
			s.DefaultTab = PopupTabButton.ButtonLabel.MusicRateDetail;
			if(m_is_friend)
			{
				s.Tabs = new PopupTabButton.ButtonLabel[0];
				s.DefaultTab = PopupTabButton.ButtonLabel.None;
			}
			PopupWindowManager.Show(s, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x117C16C
				return;
			}, (IPopupContent content, PopupTabButton.ButtonLabel label) =>
			{
				//0x117CF4C
				s.layout.ChangeTab(label);
			}, null, null);
		}

		//// RVA: 0x1174BC8 Offset: 0x1174BC8 VA: 0x1174BC8
		private void OnClickCenterSkill()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MenuScene.Instance.UnitSaveWindowControl.ShowSkillWindow(m_center_skill_name[0].text, m_center_skill_full_desc[0]);
		}

		//// RVA: 0x1174D6C Offset: 0x1174D6C VA: 0x1174D6C
		private void OnClickCenterSkill2()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MenuScene.Instance.UnitSaveWindowControl.ShowSkillWindow(m_center_skill_name[1].text, m_center_skill_full_desc[1]);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FEB74 Offset: 0x6FEB74 VA: 0x6FEB74
		//// RVA: 0x116D660 Offset: 0x116D660 VA: 0x116D660
		private IEnumerator LoadDegreeInfoWindow()
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x9CCEE4
			operation = AssetBundleManager.LoadLayoutAsync(m_degree_setting.BundleName, m_degree_setting.AssetName);
			yield return operation;
			if(!operation.IsError())
			{
				yield return Co.R(operation.InitializeLayoutCoroutine(MenuScene.Instance.GetFont(), (GameObject instance) =>
				{
					//0x117B2B4
					m_degree_setting.SetContent(instance);
				}));
				m_degree_setting.SetParent(transform);
				AssetBundleManager.UnloadAssetBundle(m_degree_setting.BundleName);
			}
		}

		//// RVA: 0x1174F10 Offset: 0x1174F10 VA: 0x1174F10
		private void OnClickDegreeInfo()
		{
			if(m_degree_data != null && m_degree_data.MDPKLNFFDBO_EmblemId > 1)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				m_degree_setting.TitleText = bk.GetMessageByLabel("popup_title_degree_01");
				m_degree_setting.SetParent(transform);
				m_degree_setting.data = m_degree_data;
				m_degree_setting.WindowSize = SizeType.Small;
				m_degree_setting.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				};
				PopupWindowManager.Show(m_degree_setting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x117C170
					return;
				}, (IPopupContent content, PopupTabButton.ButtonLabel label) =>
				{
					//0x117C174
					(content as PopupTabContents).ChangeContents((int)label);
				}, null, null);
			}
		}

		//// RVA: 0x117025C Offset: 0x117025C VA: 0x117025C
		private IAPDFOPPGND GetDegreeData(int id)
		{
			List<IAPDFOPPGND> emblems = IAPDFOPPGND.FKDIMODKKJD(true);
			for(int i = 0; i < emblems.Count; i++)
			{
				if(emblems[i].MDPKLNFFDBO_EmblemId == id)
				{
					return emblems[i];
				}
			}
			return null;
		}

		//// RVA: 0x11753B4 Offset: 0x11753B4 VA: 0x11753B4
		private void SetDegreeNum(int num, bool active = true)
		{
			m_degree_num.SetNumber(num, 0);
			RawImageEx[] imgs = m_degree_num.transform.GetComponentsInChildren<RawImageEx>();
			if(!active)
			{
				for(int i = 0; i < imgs.Length; i++)
				{
					imgs[i].enabled = false;
				}
			}
			else
			{
				for (int i = 0; i < imgs.Length; i++)
				{
					imgs[i].enabled = true;
				}
			}
		}

		//// RVA: 0x117555C Offset: 0x117555C VA: 0x117555C
		//private IAPDFOPPGND GetDegreeListIndex(int id) { }

		//// RVA: 0x116E818 Offset: 0x116E818 VA: 0x116E818
		private void SetMainSceneInfo(GCIJNCFDNON_SceneInfo sceneData)
		{
			m_scene_data = sceneData;
			if(sceneData == null)
			{
				m_scene_name.text = MessageManager.Instance.GetMessage("menu", "profil_text_01");
				SetSceneImage(0, 0, false);
				m_scene_total.text = "0";
				m_scene_soul.text = "0";
				m_scene_voice.text = "0";
				m_scene_charm.text = "0";
				m_scene_life.text = "0";
				m_scene_support.text = "0";
				m_scene_fold.text = "0";
				m_scene_luck.text = UnitWindowConstant.MakeLuckText(0);
			}
			else
			{
				m_scene_name.text = GameMessageManager.GetSceneCardName(sceneData);
				SetSceneImage(m_scene_data.BCCHOBPJJKE_SceneId, m_scene_data.CGIELKDLHGE_GetEvolveId(), m_scene_data.MBMFJILMOBP_IsKira());
				m_scene_total.text = m_scene_data.CMCKNKKCNDK_Status.Total.ToString();
				m_scene_soul.text = m_scene_data.CMCKNKKCNDK_Status.soul.ToString();
				m_scene_voice.text = m_scene_data.CMCKNKKCNDK_Status.vocal.ToString();
				m_scene_charm.text = m_scene_data.CMCKNKKCNDK_Status.charm.ToString();
				m_scene_life.text = m_scene_data.CMCKNKKCNDK_Status.life.ToString();
				m_scene_support.text = m_scene_data.CMCKNKKCNDK_Status.support.ToString();
				m_scene_fold.text = m_scene_data.CMCKNKKCNDK_Status.fold.ToString();
				m_scene_luck.text = UnitWindowConstant.MakeLuckText(sceneData.MJBODMOLOBC_Luck);
			}
			if(m_scene_deco == null)
			{
				m_scene_deco = new SceneIconDecoration(m_scene_info_rect.gameObject, SceneIconDecoration.Size.S, null, null);
			}
			else
			{
				m_scene_deco.Initialize(m_scene_info_rect.gameObject, SceneIconDecoration.Size.S, null, null);
			}
			m_scene_deco.Change(m_scene_data, DisplayType.Level);
		}

		//// RVA: 0x116EF30 Offset: 0x116EF30 VA: 0x116EF30
		private void SetCenterSkillInfo(FFHPBEPOMAK_DivaInfo divaData, GCIJNCFDNON_SceneInfo sceneData)
		{
			m_center_skill_cross_fade.StartAllAnimLoop("st_wait");
			if (divaData.FGFIBOBAPIA_SceneId > 0 && sceneData.MEOOLHNNMHL_GetCenterSkillId(false, 0, 0) > 0)
			{
				int skillId1 = sceneData.MEOOLHNNMHL_GetCenterSkillId(false, 0, 0);
				int skillId2 = sceneData.MEOOLHNNMHL_GetCenterSkillId(true, 0, 0);
				StringBuilder str = new StringBuilder();
				if (skillId1 > 0)
				{
					m_center_skill_name[0].text = sceneData.PFHJFIHGCKP_CenterSkillName1;
					m_center_skill_full_desc[0] = sceneData.IHLINMFMCDN_GetCenterSkillDesc(false);
					m_center_skill_level[0].text = "Lv" + sceneData.DDEDANKHHPN_SkillLevel.ToString();
					m_center_skill_name[0].alignment = m_center_skill_name_align;
					m_center_skill_desc[0].alignment = m_center_skill_desc_align;
					m_center_skill_level[0].alignment = m_center_skill_level_align;
					m_center_skill_rank[0].uvRect = GameManager.Instance.UnionTextureManager.GetSkillRankUvRect((SkillRank.Type)sceneData.DHEFMEGKKDN_CenterSkillRank);
					m_center_skill_btn[0].ClearOnClickCallback();
					m_center_skill_foldout[0].enabled = false;
					m_center_skill_desc[0].horizontalOverflow = HorizontalWrapMode.Wrap;
					if (UnitWindowConstant.SetSkillDetails(m_center_skill_desc[0], m_center_skill_full_desc[0], 1))
					{
						m_center_skill_btn[0].AddOnClickCallback(OnClickCenterSkill);
						m_center_skill_foldout[0].enabled = true;
					}
					m_center_skill_regu_btn.Setup(0, 0, sceneData);
					if (skillId1 != skillId2 && skillId2 > 0)
					{
						m_center_skill_name[1].text = sceneData.EFELCLMJEOL_CenterSkillName2;
						m_center_skill_full_desc[1] = sceneData.IHLINMFMCDN_GetCenterSkillDesc(true);
						m_center_skill_level[1].text = "Lv" + sceneData.DDEDANKHHPN_SkillLevel.ToString();
						m_center_skill_name[1].alignment = m_center_skill_name_align;
						m_center_skill_desc[1].alignment = m_center_skill_desc_align;
						m_center_skill_level[1].alignment = m_center_skill_level_align;
						m_center_skill_rank[1].uvRect = GameManager.Instance.UnionTextureManager.GetSkillRankUvRect((SkillRank.Type)sceneData.FFDCGHDNDFJ_CenterSkillRank2);
						m_center_skill_btn[1].ClearOnClickCallback();
						m_center_skill_foldout[1].enabled = false;
						m_center_skill_desc[1].horizontalOverflow = HorizontalWrapMode.Wrap;
						if (UnitWindowConstant.SetSkillDetails(m_center_skill_desc[1], m_center_skill_full_desc[1], 1))
						{
							m_center_skill_btn[1].AddOnClickCallback(OnClickCenterSkill2);
							m_center_skill_foldout[1].enabled = true;
						}
						m_center_skill_cross_fade.StartAllAnimLoop("logo_act");
					}
				}
			}
			else
			{
				TextAnchor[] ta = new TextAnchor[9] { TextAnchor.UpperCenter, TextAnchor.UpperCenter, TextAnchor.UpperCenter, TextAnchor.MiddleCenter, TextAnchor.MiddleCenter, TextAnchor.MiddleCenter, TextAnchor.LowerCenter, TextAnchor.LowerCenter, TextAnchor.LowerCenter };
				UnitWindowConstant.SetInvalidText(m_center_skill_name[0], ta[(int)m_center_skill_name_align]);
				UnitWindowConstant.SetInvalidText(m_center_skill_desc[0], ta[(int)m_center_skill_desc_align]);
				m_center_skill_level[0].text = "";
				m_center_skill_rank[1].uvRect = GameManager.Instance.UnionTextureManager.GetSkillRankUvRect(SkillRank.Type.None);
				m_center_skill_full_desc[0] = m_center_skill_desc[0].text;
				m_center_skill_foldout[0].enabled = false;
			}
			m_center_skill_mask.StartChildrenAnimGoStop("02");
		}

		//// RVA: 0x117008C Offset: 0x117008C VA: 0x117008C
		private void SetDegreeInfo(IAPDFOPPGND emblem)
		{
			if(emblem.MDPKLNFFDBO_EmblemId > 1)
			{
				m_degree.horizontalOverflow = HorizontalWrapMode.Overflow;
				m_degree.verticalOverflow = VerticalWrapMode.Overflow;
				TextGeneratorUtility.SetTextNewLineMessage(m_degree, emblem.ADCMNODJBGJ_EmblemName);
				SetDegreeImage(emblem.MDPKLNFFDBO_EmblemId);
				SetDegreeNum(emblem.HMFFHLPNMPH, emblem.HMFFHLPNMPH > 0);
			}
			else
			{
				m_degree.horizontalOverflow = HorizontalWrapMode.Wrap;
				m_degree.text = MessageManager.Instance.GetMessage("menu", "profil_text_02");
				SetDegreeImage(1);
				SetDegreeNum(0, false);
			}
		}

		//// RVA: 0x11704A8 Offset: 0x11704A8 VA: 0x11704A8
		private void SetStatsInfo(JNMFKOHFAFB_PublicStatus status)
		{
			m_stats_plate_count.text = status.BKIFLJAMJGG_ScnCnt.ToString();
			m_stats_valkyrie_count.text = status.MIFLBHBPBNF_VfCnt.ToString();
			m_stats_lvmax_plate_count.text = status.JGDNCEANEBB_LvMaxCnt.ToString();
			m_stats_costume_count.text = status.FOFGELKGMAH_CosCnt.ToString();
			m_stats_mission_clear_count.text = status.APFOBLMCLAO_QCnt.ToString();
			m_stats_clear_count.text = status.PCBJHBCNNGD_TClr.ToString();
			m_stats_perfect_notes_count.text = status.LDKEOMCNLBE_PfTap.ToString();
			m_stats_highscore_value.text = status.AEBENOJEGOJ_MaxSc.ToString();
			if(status.AEBENOJEGOJ_MaxSc < 1)
			{
				m_stats_highscore_music.text = "";
				m_stats_highscore_diff.enabled = false;
			}
			else
			{
				EEDKAACNBBG_MusicData mData = new EEDKAACNBBG_MusicData();
				mData.KHEKNNFCAOI(status.JHOIMONJKLG_MaxId);
				m_stats_highscore_music.text = mData.NEDBBJDAFBH_MusicName;
				m_stats_highscore_music.resizeTextForBestFit = true;
				m_stats_highscore_music.resizeTextMinSize = 10;
				m_stats_highscore_music.resizeTextMaxSize = 20;
				m_stats_highscore_music.horizontalOverflow = HorizontalWrapMode.Wrap;
				m_stats_highscore_music.verticalOverflow = VerticalWrapMode.Truncate;
				if(status.NADEAGFJDLL_MaxL6 == 1)
				{
					GameManager.Instance.UnionTextureManager.GetTexture("cmn_tex_02_pack").Set(m_stats_highscore_diff);
					m_stats_highscore_diff.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData(DifficultUvTable_6Line[status.JEENEHPOCFN_MaxDf - 2]));
				}
				else
				{
					GameManager.Instance.UnionTextureManager.GetTexture("cmn_tex_pack").Set(m_stats_highscore_diff);
					m_stats_highscore_diff.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData(DifficultUvTable[status.JEENEHPOCFN_MaxDf]));
				}
				m_stats_highscore_diff.enabled = true;
			}
			for(int i = 0; i < 5; i++)
			{
				m_stats_clear_music_count[i].text = status.PFHIOGBJDHM(i).ToString();
				m_stats_fullcombo_music_count[i].text = status.KIBCDACEFIC(i).ToString();
			}
			for(int i = 2; i < 5; i++)
			{
				m_stats_clear_music_count[i + 3].text = status.EJNGDOJAIDP(i).ToString();
				m_stats_fullcombo_music_count[i + 3].text = status.JFBMBPPHDLB(i).ToString();
			}
			m_stats_clear_music_count[4].enabled = true;
			m_stats_fullcombo_music_count[4].enabled = true;
			for(int i = 0; i < m_stats_extreme_image.Count; i++)
			{
				m_stats_extreme_image[i].enabled = true;
			}
		}

		//// RVA: 0x1175690 Offset: 0x1175690 VA: 0x1175690
		private void OnClickSceneInfo()
		{
			if (m_scene_data != null)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				ShowSceneStatusPopup(m_scene_data, GameManager.Instance.ViewPlayerData, () =>
				{
					//0x117B2E8
					SetMainSceneInfo(m_scene_data);
				});
			}
		}

		//// RVA: 0x11758CC Offset: 0x11758CC VA: 0x11758CC
		//private void OnClickPageLeft() { }

		//// RVA: 0x1175938 Offset: 0x1175938 VA: 0x1175938
		//private void OnClickPageRight() { }

		//// RVA: 0x117214C Offset: 0x117214C VA: 0x117214C
		private void UpdateStatsPage(int newPage)
		{
			if (newPage < 0)
				newPage += 6;
			if (newPage >= 6)
				newPage -= 6;
			m_stats_page_idx = newPage;
			m_stats_page_num.text = string.Format("{0}/{1}", m_stats_page_idx + 1, 6);
			this.StartCoroutineWatched(Coroutine_ChangeMcrosReportPage(m_stats_page_idx));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FEBEC Offset: 0x6FEBEC VA: 0x6FEBEC
		//// RVA: 0x11759A4 Offset: 0x11759A4 VA: 0x11759A4
		private IEnumerator Coroutine_ChangeMcrosReportPage(int a_page)
		{
			string pageLabel;

			//0x117EF78
			yield return null;
			pageLabel = "";
			switch(a_page)
			{
				case 0:
					pageLabel = "logo_act_01";
					break;
				case 1:
					pageLabel = "logo_act_02";
					yield return Co.R(Coroutine_SetupCostumeScrollList());
					break;
				case 2:
					pageLabel = "logo_act_03";
					yield return Co.R(Coroutine_SetupVarkiryScrollList());
					break;
				case 3:
					pageLabel = "logo_act_05";
					yield return Co.R(Coroutine_SetupEmblemScrollList());
					break;
				case 4:
					pageLabel = "logo_act_04";
					break;
				case 5:
					pageLabel = "logo_act_06";
					break;
			}
			m_stats_page.StartChildrenAnimGoStop(pageLabel, pageLabel);
			yield return null;
		}

		//// RVA: 0x11757E4 Offset: 0x11757E4 VA: 0x11757E4
		private void ShowSceneStatusPopup(GCIJNCFDNON_SceneInfo sceneData, DFKGGBMFFGB_PlayerInfo playerData, Action onClose)
		{
			MenuScene.Instance.ShowSceneStatusPopupWindow(sceneData, playerData, false, TransitionList.Type.UNDEFINED, onClose, m_is_friend, true, SceneStatusParam.PageSave.Player, true);
		}

		//// RVA: 0x1175674 Offset: 0x1175674 VA: 0x1175674
		//private static TextAnchor ToCenter(TextAnchor baseAnchor) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6FEC64 Offset: 0x6FEC64 VA: 0x6FEC64
		//// RVA: 0x116D5D0 Offset: 0x116D5D0 VA: 0x116D5D0
		private IEnumerator Load_ScrollItemIcon()
		{
			AssetBundleLoadLayoutOperationBase layOp;

			//0x9CD2C0
			LayoutUGUIRuntime runtime = null;
			m_swap_scroll.RemoveScrollObject();
			m_swap_scroll.SetEnableScrollBar(true);
			layOp = AssetBundleManager.LoadLayoutAsync("ly/071.xab", "UI_ProfilScrollItemIcon");
			yield return layOp;
			yield return Co.R(layOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x117CF9C
				runtime = instance.GetComponent<LayoutUGUIRuntime>();
				ProfilScrollIcon p = instance.GetComponent<ProfilScrollIcon>();
				p.SetCallbackClickIconCos(CB_ClickIcon_Costume);
				p.SetCallbackClickIconVal(CB_ClickIcon_Valkyrie);
				p.SetCallbackClickIconEmblem(CB_ClickIcon_Emblem);
				m_swap_scroll.AddScrollObject(p);
			}));
			for(int i = 1; i < m_swap_scroll.ScrollObjectCount; i++)
			{
				LayoutUGUIRuntime r = Instantiate(runtime);
				r.IsLayoutAutoLoad = false;
				r.Layout = runtime.Layout.DeepClone();
				r.UvMan = runtime.UvMan;
				r.LoadLayout();
				ProfilScrollIcon p = r.GetComponent<ProfilScrollIcon>();
				p.SetCallbackClickIconCos(CB_ClickIcon_Costume);
				p.SetCallbackClickIconVal(CB_ClickIcon_Valkyrie);
				p.SetCallbackClickIconEmblem(CB_ClickIcon_Emblem);
				m_swap_scroll.AddScrollObject(p);
			}
			m_swap_scroll.Apply();
			m_swap_scroll.SetContentEscapeMode(false);
			yield return null;
			AssetBundleManager.UnloadAssetBundle("ly/071.xab", false);
			m_swap_scroll_loaded = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FECDC Offset: 0x6FECDC VA: 0x6FECDC
		//// RVA: 0x1175A6C Offset: 0x1175A6C VA: 0x1175A6C
		private IEnumerator Coroutine_SetupCostumeScrollList()
		{
			//0x117F224
			m_swap_scroll.SetItemCount(0);
			m_swap_scroll.VisibleRegionUpdate();
			yield return null;
			m_swap_scroll.OnUpdateItem.RemoveAllListeners();
			if(m_costume_list != null)
			{ 
				m_inner_costume_list = new List<CostumeData>(m_costume_list.Count * 2);
				for(int i = 0; i < m_costume_list.Count; i++)
				{
					CostumeData data = new CostumeData();
					data.data = m_costume_list[i];
					data.color = 0;
					m_inner_costume_list.Add(data);
					for(int j = 0; j < m_costume_list[i].NLKGAAFBDFK(); j++)
					{
						CostumeData d = new CostumeData();
						d.data = m_costume_list[i];
						d.color = m_costume_list[i].LLJPMOIPBAG(j);
						m_inner_costume_list.Add(d);
					}
				}
				m_swap_scroll.SetItemCount(m_inner_costume_list.Count);
				m_swap_scroll.OnUpdateItem.AddListener((int index, SwapScrollListContent content) =>
				{
					//0x117B2F0
					OnUpdateCostumeScrollItem(index, (content as ProfilScrollIcon), m_inner_costume_list[index]);
				});
			}
			m_swap_scroll.ResetScrollVelocity();
			m_swap_scroll.SetPosition(0, 0, 0, false);
			m_swap_scroll.VisibleRegionUpdate();
		}

		//// RVA: 0x1175B18 Offset: 0x1175B18 VA: 0x1175B18
		private void OnUpdateCostumeScrollItem(int a_index, ProfilScrollIcon a_icon, CostumeData a_costume_info)
		{
			a_icon.SetCostumeIcon(a_costume_info.data, a_costume_info.color);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FED54 Offset: 0x6FED54 VA: 0x6FED54
		//// RVA: 0x1175B7C Offset: 0x1175B7C VA: 0x1175B7C
		private IEnumerator Coroutine_SetupVarkiryScrollList()
		{
			//0x9CCB98
			m_swap_scroll.SetItemCount(0);
			m_swap_scroll.VisibleRegionUpdate();
			yield return null;
			m_swap_scroll.OnUpdateItem.RemoveAllListeners();
			if(m_valkyrie_list != null)
			{
				m_swap_scroll.SetItemCount(m_valkyrie_list.Count);
				m_swap_scroll.OnUpdateItem.AddListener((int index, SwapScrollListContent content) =>
				{
					//0x117B424
					OnUpdateVarkiryScrollItem(index, content as ProfilScrollIcon, m_valkyrie_list[index]);
				});
			}
			m_swap_scroll.ResetScrollVelocity();
			m_swap_scroll.SetPosition(0, 0, 0, false);
			m_swap_scroll.VisibleRegionUpdate();
		}

		//// RVA: 0x1175C04 Offset: 0x1175C04 VA: 0x1175C04
		private void OnUpdateVarkiryScrollItem(int a_index, ProfilScrollIcon a_icon, PNGOLKLFFLH a_data)
		{
			a_icon.SetVarkiryIcon(a_data);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FEDCC Offset: 0x6FEDCC VA: 0x6FEDCC
		//// RVA: 0x1175C38 Offset: 0x1175C38 VA: 0x1175C38
		private IEnumerator Coroutine_SetupEmblemScrollList()
		{
			//0x117F7A4
			if(m_emblem_list.Count < 1)
			{
				m_emblem_scroll_text.text = MessageManager.Instance.GetMessage("menu", "cmn_profil_emblem_none");
			}
			else
			{
				m_emblem_scroll_text.text = "";
			}
			m_swap_scroll.SetItemCount(0);
			m_swap_scroll.VisibleRegionUpdate();
			yield return null;
			m_swap_scroll.OnUpdateItem.RemoveAllListeners();
			if(m_emblem_list != null)
			{
				m_swap_scroll.SetItemCount(m_emblem_list.Count);
				m_swap_scroll.OnUpdateItem.AddListener((int index, SwapScrollListContent content) =>
				{
					//0x117B55C
					OnUpdateEmblemScrollItem(index, content as ProfilScrollIcon, m_emblem_list[index]);
				});
			}
			m_swap_scroll.ResetScrollVelocity();
			m_swap_scroll.SetPosition(0, 0, 0, false);
			m_swap_scroll.VisibleRegionUpdate();
		}

		//// RVA: 0x1175CE4 Offset: 0x1175CE4 VA: 0x1175CE4
		private void OnUpdateEmblemScrollItem(int a_index, ProfilScrollIcon a_icon, IAPDFOPPGND a_emblem_info)
		{
			a_icon.SetEmblemIcon(a_emblem_info);
		}

		//// RVA: 0x1175D18 Offset: 0x1175D18 VA: 0x1175D18
		private void CB_ClickIcon_Valkyrie(PNGOLKLFFLH a_data)
		{
			if(a_data != null)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				m_popup_setting_val.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				};
				m_popup_setting_val.ViewValkyrieData = a_data;
				PopupWindowManager.Show(m_popup_setting_val, null, null, null, null);
			}
		}

		//// RVA: 0x1175F14 Offset: 0x1175F14 VA: 0x1175F14
		private void CB_ClickIcon_Costume(CKFGMNAIBNG a_data, int a_color)
		{
			if(a_data != null)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				MenuScene.Instance.ShowCostumeDetailWindow(a_data, a_color);
			}
		}

		//// RVA: 0x1176014 Offset: 0x1176014 VA: 0x1176014
		private void CB_ClickIcon_Emblem(IAPDFOPPGND a_data)
		{
			if(a_data != null)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				m_degree_setting.TitleText = bk.GetMessageByLabel("popup_title_degree_01");
				m_degree_setting.SetParent(transform);
				m_degree_setting.data = a_data;
				m_degree_setting.WindowSize = SizeType.Small;
				m_degree_setting.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				};
				PopupWindowManager.Show(m_degree_setting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x117C26C
					return;
				}, (IPopupContent content, PopupTabButton.ButtonLabel label) =>
				{
					//0x117C270
					(content as PopupTabContents).ChangeContents((int)label);
				}, null, null, true, true, false);
			}
		}

		//// RVA: 0x11764A8 Offset: 0x11764A8 VA: 0x11764A8
		public void SetFanCount(int _fanCount)
		{
			if (_fanCount >= 99999)
				_fanCount = 99999;
			m_fanCount_num.SetNumber(_fanCount, 0);
		}

		//// RVA: 0x11764F4 Offset: 0x11764F4 VA: 0x11764F4
		public void SetMainGunPower(int _power)
		{
			m_mainGunPower_text.text = _power < 1 ? "---" : (_power < 1000000 ? _power : 999999).ToString();
		}

		//// RVA: 0x11765C0 Offset: 0x11765C0 VA: 0x11765C0
		public void HiddenVisitButton(bool isHidden)
		{
			m_visit_btn.Hidden = isHidden;
		}

		//// RVA: 0x11765F4 Offset: 0x11765F4 VA: 0x11765F4
		//public void HiddenLobbyBrows(bool isHidden) { }

		//// RVA: 0x1176628 Offset: 0x1176628 VA: 0x1176628
		//public bool GetHiddenLobbyBrows() { }

		//// RVA: 0x1176654 Offset: 0x1176654 VA: 0x1176654
		//public void DecoButtonHidden(bool a_hidden) { }

		//// RVA: 0x117671C Offset: 0x117671C VA: 0x117671C
		public void SetButtonType(ButtonType a_type)
		{
			bool blockHidden = true;
			bool visitHidden = false;
			bool fanReleaseHidden = false;
			bool fanEntryHidden = false;
			bool lobbyHidden = false;
			m_btnType = a_type;
			if(a_type >= ButtonType.Raid && a_type <= ButtonType.Raid_Result)
			{
				fanEntryHidden = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.GAAOPEGIPKA_FavoritePlayer.FFKIDMKHIOE(m_friend_player_data.MLPEHNBNOGD_Id);
				lobbyHidden = true;
				visitHidden = true;
				blockHidden = true;
				fanReleaseHidden = !fanEntryHidden;
				bool b1 = true;
				if(a_type == ButtonType.Raid_Result)
				{
					//LAB_01176ab8
				}
				else
				{
					//LAB_01176938
					visitHidden = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("deco_player_level", 0) < 1;
					if(!lobbyHidden)
					{
						if(!m_enable_lobby_btn)
							lobbyHidden = true;
					}
					if(!b1)
					{
						blockHidden = CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.DIGEHCDEAON_IsBlacklisted(m_friend_player_data.MLPEHNBNOGD_Id);
						//LAB_01176ab8
					}
				}
			}
			else
			{
				if(a_type >= ButtonType.Fan && a_type <= ButtonType.Fan_NoLobby)
				{
					fanEntryHidden = false;
					lobbyHidden = true;
					fanReleaseHidden = true;
					bool b = false;
					if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.GAAOPEGIPKA_FavoritePlayer.FFKIDMKHIOE(m_friend_player_data.MLPEHNBNOGD_Id))
					{
						fanReleaseHidden = false;
						lobbyHidden = m_btnType != ButtonType.Fan;
						fanEntryHidden = true;
						b = true;
					}
					//LAB_01176938
					visitHidden = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("deco_player_level", 0) < 1;
					if(!lobbyHidden)
					{
						if (!m_enable_lobby_btn)
							m_enable_lobby_btn = true;
					}
					if(!b)
					{
						blockHidden = CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.DIGEHCDEAON_IsBlacklisted(m_friend_player_data.MLPEHNBNOGD_Id);
					}
				}
				else
				{
					lobbyHidden = true;
					fanEntryHidden = true;
					fanReleaseHidden = true;
					visitHidden = true;
				}
			}
			//LAB_01176ab8
			m_lobbyBrowsing_btn.Hidden = lobbyHidden;
			m_fanEntry_btn.Hidden = fanEntryHidden;
			m_fanRelease_btn.Hidden = fanReleaseHidden;
			m_visit_btn.Hidden = visitHidden;
			m_block_btn.Hidden = blockHidden;
		}

		//// RVA: 0x1176B94 Offset: 0x1176B94 VA: 0x1176B94
		public void OnClickFanRelease()
		{
			if(m_friend_player_data != null)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				MenuScene.Instance.InputDisable();
				PopupWindowManager.FanReleaseConfirmPopupShow(m_friend_player_data.LBODHBDOMGK_Name, () =>
				{
					//0x117B694
					List<int> l = new List<int>();
					List<int> l2 = new List<int>();
					l2.Add(m_friend_player_data.MLPEHNBNOGD_Id);
					UpdateFavoritePlayer(l, l2, null);
				}, null, () =>
				{
					//0x117C368
					MenuScene.Instance.InputEnable();
				});
			}
		}

		//// RVA: 0x1176DFC Offset: 0x1176DFC VA: 0x1176DFC
		public void OnClickFanEntry()
		{
			if(m_friend_player_data != null)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				if(PIGBKEIAMPE_FriendManager.GKDGOGCOGBK() >= PIGBKEIAMPE_FriendManager.DJHFILDBOFG_GetMaxFanPossible())
				{
					PopupFanLimit();
				}
				else
				{
					MenuScene.Instance.InputDisable();
					PopupWindowManager.FanEntryConfirmPopupShow(m_friend_player_data.LBODHBDOMGK_Name, () =>
					{
						//0x117B780
						List<int> l = new List<int>();
						List<int> l2 = new List<int>();
						l.Add(m_friend_player_data.MLPEHNBNOGD_Id);
						UpdateFavoritePlayer(l, l2, null);
					}, null, () =>
					{
						//0x117C404
						MenuScene.Instance.InputEnable();
					});
				}
			}
		}

		//// RVA: 0x117725C Offset: 0x117725C VA: 0x117725C
		public void OnClickVisit()
		{
			if(m_friend_player_data != null)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				MenuScene.Instance.InputDisable();
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				TextPopupSetting s = new TextPopupSetting();
				s.TitleText = bk.GetMessageByLabel("popup_profile_visit_title");
				s.Text = string.Format(bk.GetMessageByLabel("popup_profile_visit_msg"), m_friend_player_data.LBODHBDOMGK_Name);
				s.Buttons = new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				PopupWindowManager.Show(s, (PopupWindowControl c, PopupButton.ButtonType t, PopupButton.ButtonLabel l) =>
				{
					//0x117B86C
					MenuScene.Instance.InputEnable();
					if(t == PopupButton.ButtonType.Positive)
					{
						VisitDecoSceneArgs args = new VisitDecoSceneArgs();
						args.friendData = m_friend_player_data;
						if(m_transitionUniquId == TransitionUniqueId.HOME_LOBBYMAIN_LOBBYMEMBER_PROFIL || m_transitionUniquId == TransitionUniqueId.HOME_LOBBYMAIN_PROFIL)
						{
							DecoVisitScene.transitionType = DecoVisitScene.TransitionType.None;
						}
						if(args.friendData != null)
						{
							ILCCJNDFFOB.HHCJCDFCLOB.CLGHLKLHEAK(JpStringLiterals.StringLiteral_19704, args.friendData.MLPEHNBNOGD_Id);
							ILCCJNDFFOB.HHCJCDFCLOB.PFBIHCIFFKM(args.friendData.MLPEHNBNOGD_Id, CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.PDEACDHIJJJ_IsFriend(args.friendData.MLPEHNBNOGD_Id), true, 0);
						}
						MenuScene.Instance.MountWithFade(TransitionUniqueId.DECO_DECOVISIT, args, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					}
				}, null, null, null);
			}
		}

		//// RVA: 0x1177650 Offset: 0x1177650 VA: 0x1177650
		public void OnClickBlock()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(Co_AddBlockList());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FEE44 Offset: 0x6FEE44 VA: 0x6FEE44
		//// RVA: 0x11776C4 Offset: 0x11776C4 VA: 0x11776C4
		private IEnumerator Co_AddBlockList()
		{
			MessageBank t_menu_bank; // 0x1C
			PIGBKEIAMPE_FriendManager t_friend_man; // 0x20

			//0x117E134
			MenuScene.Instance.InputDisable();
			PopupButton.ButtonType t_type = PopupButton.ButtonType.Other;
			bool t_loop = true;
			t_menu_bank = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = new TextPopupSetting();
			s.TitleText = t_menu_bank.GetMessageByLabel("pop_block_ask_title");
			s.Text = string.Format(t_menu_bank.GetMessageByLabel("pop_block_ask_desc"), m_friend_player_data.LBODHBDOMGK_Name);
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(s, (PopupWindowControl content, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x117D19C
				t_loop = false;
				t_type = type;
			}, null, null, null);
			while(t_loop)
				yield return null;
			if(t_type == PopupButton.ButtonType.Positive)
			{
				int t_result = 0;
				t_friend_man = CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager;
				t_friend_man.HMANIPMKKFK(m_friend_player_data.MLPEHNBNOGD_Id, () =>
				{
					//0x117D280
					t_result = 1;
				}, () =>
				{
					//0x117D28C
					t_result = 2;
				}, (CACGCMBKHDI_Request act) =>
				{
					//0x117D298
					t_result = 3;
					MenuScene.Instance.GotoTitle();
				}, (CACGCMBKHDI_Request act) =>
				{
					//0x117D340
					t_result = 4;
					MenuScene.Instance.GotoTitle();
				});
				while(t_result == 0)
					yield return null;
				if(t_result == 1)
				{
					s = new TextPopupSetting();
					s.TitleText = t_menu_bank.GetMessageByLabel("pop_block_done_title");
					s.Text = string.Format(t_menu_bank.GetMessageByLabel("pop_block_done_desc"), m_friend_player_data.LBODHBDOMGK_Name);
					s.Buttons = new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					};
					t_loop = true;
					PopupWindowManager.Show(s, (PopupWindowControl content, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
					{
						//0x117D1AC
						t_loop = false;
					}, null, null, null);
					while(t_loop)
						yield return null;
				}
				else if(t_result == 2)
				{
					s = new TextPopupSetting();
					s.TitleText = t_menu_bank.GetMessageByLabel("pop_block_limit_title");
					s.Text = string.Format(t_menu_bank.GetMessageByLabel("pop_block_limit_desc"), t_friend_man.OKDGKAHNBPP());
					s.Buttons = new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					};
					t_loop = true;
					PopupWindowManager.Show(s, (PopupWindowControl content, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
					{
						//0x117D1AC
						t_loop = false;
					}, null, null, null);
					while(t_loop)
						yield return null;
				}
				if(t_result != 3)
				{
					if(t_result != 4)
					{
						t_loop = true;
						CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.EKIJICIBGOG_GetBlacklist(true, () =>
						{
							//0x117D1B8
							t_loop = false;
						}, (CACGCMBKHDI_Request error) =>
						{
							//0x117D1C4
							t_loop = false;
						}, (CACGCMBKHDI_Request error) =>
						{
							//0x117D1D0
							t_loop = false;
							MenuScene.Instance.GotoTitle();
						});
						while(t_loop)
							yield return null;
					}
				}
			}
			//LAB_0117ec58
			SetButtonType(m_btnType);
			MenuScene.Instance.InputEnable();
		}

		//// RVA: 0x1177770 Offset: 0x1177770 VA: 0x1177770
		public void OnClickLobbyBrowsing()
		{
			if(m_friend_player_data != null)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
				EventLobbyArgs arg = new EventLobbyArgs();
				arg.IsMyLobby = false;
				arg.playerId = m_friend_player_data.MLPEHNBNOGD_Id;
				arg.friendData = m_friend_player_data;
				MenuScene.Instance.Call(TransitionList.Type.LOBBY_MAIN, arg, true);
			}
		}

		//// RVA: 0x11770B8 Offset: 0x11770B8 VA: 0x11770B8
		private void PopupFanLimit()
		{
			MenuScene.Instance.InputEnable();
			PopupWindowManager.FanLimitPopupShow(() =>
			{
				//0x117C4A0
				MenuScene.Instance.InputEnable();
			});
		}

		//// RVA: 0x11778DC Offset: 0x11778DC VA: 0x11778DC
		private void UpdateFavoritePlayer(List<int> a_list_add, List<int> a_list_remove, Action a_func)
		{
			MenuScene.Instance.InputDisable();
			CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.EPKOLKBGOGA(a_list_add, a_list_remove, () =>
			{
				//0x117D3E8
				CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.NDDIOKIKCNA_GetFanCount(m_friend_player_data.MLPEHNBNOGD_Id, (int fanCount) =>
				{
					//0x117D648
					SetFanCount(fanCount);
					if(m_friend_player_data.PCEGKKLKFNO != null)
					{
						IFICNCAHIGI ifi = m_friend_player_data.PCEGKKLKFNO as IFICNCAHIGI;
						if(ifi != null)
							ifi.AGDBNNEAIIC_FanNum = fanCount;
					}
					if(a_list_add.Count < 1)
					{
						if(a_list_remove.Count > 0)
						{
							ILCCJNDFFOB.HHCJCDFCLOB.JCJCJPCHNEN(a_list_remove[0], 0, fanCount, CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.PDEACDHIJJJ_IsFriend(a_list_remove[0]));
						}
					}
					else
					{
						ILCCJNDFFOB.HHCJCDFCLOB.JCJCJPCHNEN(a_list_add[0], 1, fanCount, CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.PDEACDHIJJJ_IsFriend(a_list_add[0]));
					}
					MenuScene.Instance.InputEnable();
				}, () =>
				{
					//0x117C53C
					MenuScene.Instance.GotoTitle();
				});
				SetButtonType(m_btnType);
			}, () =>
			{
				//0x117C5D8
				MenuScene.Instance.GotoTitle();
			}, () =>
			{
				//0x117DA28
				PopupFanLimit();
			});
		}

		//// RVA: 0x1177BD0 Offset: 0x1177BD0 VA: 0x1177BD0
		private void SetAssistAttributeText()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_assist_attribute_title[0].text = bk.GetMessageByLabel("assistselect_attribute_other");
			m_assist_attribute_title[1].text = bk.GetMessageByLabel("assistselect_attribute_yellow");
			m_assist_attribute_title[2].text = bk.GetMessageByLabel("assistselect_attribute_red");
			m_assist_attribute_title[3].text = bk.GetMessageByLabel("assistselect_attribute_blue");
		}

		//// RVA: 0x1177E94 Offset: 0x1177E94 VA: 0x1177E94
		private void SetAssistName(int page)
		{
			m_assist_name.text = m_view_assist_data.IOKHHOCMNKA(page).JCJNKBKMJFK_Name;
		}

		//// RVA: 0x1177F10 Offset: 0x1177F10 VA: 0x1177F10
		private void ChangeAssistName(string assistName)
		{
			m_view_assist_data.EGENJDLKEJP(m_assist_select_page, assistName);
			m_view_assist_data.KHEKNNFCAOI();
			m_assist_name.text = assistName;
		}

		//// RVA: 0x1171110 Offset: 0x1171110 VA: 0x1171110
		private void AssistSelectInit()
		{
			m_view_assist_data.KHEKNNFCAOI();
			m_assist_status_page = 0;
			m_assist_select_page = m_view_assist_data.ILHBCOMKHOO();
			EEMGHIINEHN.OPANFJDIEGH e = m_view_assist_data.IOKHHOCMNKA(m_assist_select_page);
			for(int i = 0; i < e.JOHLGBDOLNO_AssistScenes.Length; i++)
			{
				GCIJNCFDNON_SceneInfo s = m_view_assist_data.ELBLMMPEKPH_GetAssistScene(m_assist_select_page, i);
				if (s.BCCHOBPJJKE_SceneId < 1)
					s = null;
				SetAssistSceneInfo(i, s);
			}
			m_assist_load_image_max = 20;
			m_assist_imagedata_list.Clear();
			for(int i = 0; i < 5; i++)
			{
				m_view_assist_data.IOKHHOCMNKA(i);
				for(int j = 0; j < 4; j++)
				{
					GCIJNCFDNON_SceneInfo s = m_view_assist_data.ELBLMMPEKPH_GetAssistScene(i, j);
					if(s.BCCHOBPJJKE_SceneId < 1)
					{
						SetAssistSceneImage(0, 0, false, i * 4 + j);
					}
					else
					{
						SetAssistSceneImage(s.BCCHOBPJJKE_SceneId, s.CGIELKDLHGE_GetEvolveId(), s.MBMFJILMOBP_IsKira(), i * 4 + j);
					}
				}
			}
			UpdateAssistStatusPage(m_assist_status_page);
			UpdateAssistSelectPage(m_assist_select_page);
			MyAssistInformation();
			for(int i = 0; i < 4; i++)
			{
				m_assist_plate_btn[i].ClearLoadedCallback();
				int attribute = i;
				m_assist_plate_btn[i].AddOnClickCallback(() =>
				{
					//0x117DA50
					OnClickAssistScene(attribute);
				});
			}
			m_swaip_touch.SetAdjustment(true, false, 50, 50, 50, 50, true);
			m_swaip_touch.SetMute(true);
			m_is_stop_swaip = false;
			m_is_enable_swaip = true;
		}

		//// RVA: 0x1171B00 Offset: 0x1171B00 VA: 0x1171B00
		private void AssistSelectInit(EAJCBFGKKFA_FriendInfo data)
		{
			m_assist_status_page = 0;
			m_assist_select_page = 0;
			m_assist_load_image_max = 4;
			m_assist_imagedata_list.Clear();
			for(int i = 0; i < data.MGMFOJPNDGA.JOHLGBDOLNO_AssistScenes.Length; i++)
			{
				if(data.MGMFOJPNDGA.JOHLGBDOLNO_AssistScenes[i] == null || data.MGMFOJPNDGA.JOHLGBDOLNO_AssistScenes[i].BCCHOBPJJKE_SceneId < 1)
				{
					SetAssistSceneInfo(i, null);
					SetAssistSceneImage(0, 0, false, i);
				}
				else
				{
					SetAssistSceneInfo(i, data.MGMFOJPNDGA.JOHLGBDOLNO_AssistScenes[i]);
					SetAssistSceneImage(data.MGMFOJPNDGA.JOHLGBDOLNO_AssistScenes[i].BCCHOBPJJKE_SceneId, data.MGMFOJPNDGA.JOHLGBDOLNO_AssistScenes[i].CGIELKDLHGE_GetEvolveId(), data.MGMFOJPNDGA.JOHLGBDOLNO_AssistScenes[i].MBMFJILMOBP_IsKira(), i);
				}
			}
			m_assist_status_page = 0;
			UpdateAssistStatusPage(0);
			FriendAssistInformation();
			for(int i = 0; i < 4; i++)
			{
				m_assist_plate_btn[i].ClearOnClickCallback();
				int attribute = i;
				m_assist_plate_btn[i].AddOnClickCallback(() =>
				{
					//0x117DA80
					OnStayAssistScene(attribute);
				});
			}
			m_is_stop_swaip = true;
			m_is_enable_swaip = false;
		}

		//// RVA: 0x1178DB8 Offset: 0x1178DB8 VA: 0x1178DB8
		private void MyAssistInformation()
		{
			SetAssistAttributeText();
			m_assist_name_btn.Hidden = false;
			m_assist_name_btn_layout.StartChildrenAnimGoStop("01");
			MessageBank bank = MessageManager.Instance.GetBank("menu");
			m_assist_caution.text = bank.GetMessageByLabel("assistselect_caution_01");
			m_assist_arrow_layout.StartChildrenAnimGoStop("01");
			m_assist_selectnum_layout.StartAllAnimGoStop(string.Format("{0:00}", 5));
			for(int i = 0; i < m_assist_skill_layout.Length; i++)
			{
				m_assist_skill_layout[i].StartChildrenAnimGoStop("03");
			}
		}

		//// RVA: 0x1179038 Offset: 0x1179038 VA: 0x1179038
		private void FriendAssistInformation()
		{
			SetAssistAttributeText();
			m_assist_name_btn.Hidden = true;
			m_assist_name_btn_layout.StartChildrenAnimGoStop("02");
			m_assist_caution.text = "";
			m_assist_arrow_layout.StartChildrenAnimGoStop("02");
			m_assist_selectnum_layout.StartChildrenAnimGoStop(string.Format("{0:00}", 6));
			for (int i = 0; i < m_assist_skill_layout.Length; i++)
			{
				m_assist_skill_layout[i].StartChildrenAnimGoStop("03");
			}
		}

		//// RVA: 0x1177F9C Offset: 0x1177F9C VA: 0x1177F9C
		private void SetAssistSceneInfo(int assistNum, GCIJNCFDNON_SceneInfo sceneData)
		{
			m_assist_scene_data[assistNum] = sceneData;
			if (sceneData == null)
			{
				m_assist_total[assistNum].text = "0";
				m_assist_life[assistNum].text = "0";
				SetAssistCenterSkill(null, assistNum);
				m_assist_soul[assistNum].text = "0";
				m_assist_voice[assistNum].text = "0";
				m_assist_charm[assistNum].text = "0";
				m_assist_support[assistNum].text = "0";
				m_assist_fold[assistNum].text = "0";
				m_assist_luck[assistNum].text = "0";
			}
			else
			{
				m_assist_total[assistNum].text = sceneData.CMCKNKKCNDK_Status.Total.ToString();
				m_assist_life[assistNum].text = sceneData.CMCKNKKCNDK_Status.life.ToString();
				SetAssistCenterSkill(sceneData, assistNum);
				m_assist_soul[assistNum].text = sceneData.CMCKNKKCNDK_Status.soul.ToString();
				m_assist_voice[assistNum].text = sceneData.CMCKNKKCNDK_Status.vocal.ToString();
				m_assist_charm[assistNum].text = sceneData.CMCKNKKCNDK_Status.charm.ToString();
				m_assist_support[assistNum].text = sceneData.CMCKNKKCNDK_Status.support.ToString();
				m_assist_fold[assistNum].text = sceneData.CMCKNKKCNDK_Status.fold.ToString();
				m_assist_luck[assistNum].text = UnitWindowConstant.MakeLuckText(sceneData.MJBODMOLOBC_Luck);
			}
			if (m_assist_scene_deco[assistNum] == null)
				m_assist_scene_deco[assistNum] = new SceneIconDecoration(m_assist_scene_image[assistNum].gameObject, SceneIconDecoration.Size.S, null, null);
			else
				m_assist_scene_deco[assistNum].Initialize(m_assist_scene_image[assistNum].gameObject, SceneIconDecoration.Size.S, null, null);
			m_assist_scene_deco[assistNum].Change(sceneData, DisplayType.Level);
		}

		//// RVA: 0x117924C Offset: 0x117924C VA: 0x117924C
		private void SetAssistCenterSkill(GCIJNCFDNON_SceneInfo sceneData, int assistNum)
		{
			m_assist_skill_cross_fade_layout[assistNum].StartAllAnimLoop("st_wait");
			bool b = sceneData != null && sceneData.MEOOLHNNMHL_GetCenterSkillId(false, 0, 0) > 0;
			if (b)
			{
				m_assist_center_skill_name[assistNum * 2].text = sceneData.PFHJFIHGCKP_CenterSkillName1;
				m_assist_center_skill_name[assistNum * 2 + 1].text = sceneData.EFELCLMJEOL_CenterSkillName2;
				m_assist_center_skill_level[assistNum * 2].text = string.Format("Lv{0}", sceneData.DDEDANKHHPN_SkillLevel);
				m_assist_center_skill_level[assistNum * 2 + 1].text = string.Format("Lv{0}", sceneData.DDEDANKHHPN_SkillLevel);
				GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_assist_certer_skill_rank[assistNum * 2], (SkillRank.Type)sceneData.DHEFMEGKKDN_CenterSkillRank);
				GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_assist_certer_skill_rank[assistNum * 2 + 1], (SkillRank.Type)sceneData.FFDCGHDNDFJ_CenterSkillRank2);
				if(sceneData.MEOOLHNNMHL_GetCenterSkillId(false, 0, 0) != sceneData.MEOOLHNNMHL_GetCenterSkillId(true, 0, 0))
				{
					m_assist_skill_cross_fade_layout[assistNum].StartAllAnimLoop("logo_act");
				}
			}
			else
			{
				m_assist_center_skill_name[assistNum * 2].text = "";
				UnitWindowConstant.SetInvalidText(m_assist_center_skill_level[assistNum * 2], TextAnchor.MiddleRight);
				m_assist_certer_skill_rank[assistNum * 2].uvRect = GameManager.Instance.UnionTextureManager.GetSkillRankUvRect(SkillRank.Type.None);
			}
		}

		//// RVA: 0x1178AA8 Offset: 0x1178AA8 VA: 0x1178AA8
		private void UpdateAssistStatusPage(int newPage)
		{
			if (newPage < 0)
				newPage += 3;
			if(newPage >= 3)
				newPage -= 3;
			m_assist_status_page = newPage;
			m_assist_status_page_now.text = (newPage + 1).ToString();
			m_assist_status_page_max.text = 3.ToString();
			string s = string.Format("{0:00}", newPage + 1);
			for(int i = 0; i < m_assist_status_layout.Length; i++)
			{
				m_assist_status_layout[i].StartChildrenAnimGoStop(s, s);
			}
		}

		//// RVA: 0x11798EC Offset: 0x11798EC VA: 0x11798EC
		private void OnClickAssistStatusPage()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			UpdateAssistStatusPage(m_assist_status_page + 1);
			SwaipReset();
			m_is_lock_swaip = true;
		}

		//// RVA: 0x1178C7C Offset: 0x1178C7C VA: 0x1178C7C
		private void UpdateAssistSelectPage(int newPage)
		{
			if (newPage < 0)
				newPage += 5;
			m_assist_select_page = newPage % 5;
			for(int i = 0; i < 5; i++)
			{
				string s = i == m_assist_select_page ? "02" : "01";
				m_assist_select_layout[i].StartChildrenAnimGoStop(s, s);
			}
			SetAssistName(m_assist_select_page);
			m_view_assist_data.AIMMBGFMFOD(m_assist_select_page);
		}

		//// RVA: 0x1179968 Offset: 0x1179968 VA: 0x1179968
		private void ChangeAssistSelectPage(int newPage)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			UpdateAssistSelectPage(newPage);
			EEMGHIINEHN.OPANFJDIEGH d = m_view_assist_data.IOKHHOCMNKA(m_assist_select_page);
			for(int i = 0; i < d.JOHLGBDOLNO_AssistScenes.Length; i++)
			{
				GCIJNCFDNON_SceneInfo scene = null;
				if (d.JOHLGBDOLNO_AssistScenes[i].BCCHOBPJJKE_SceneId > 0)
				{
					scene = GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes[d.JOHLGBDOLNO_AssistScenes[i].BCCHOBPJJKE_SceneId - 1];
				}
				SetAssistSceneInfo(i, scene);
			}
			SetAssistSceneImage();
			m_view_assist_data.CEIOGBFIDKI_SetPage(m_assist_select_page);
		}

		//// RVA: 0x1179BB4 Offset: 0x1179BB4 VA: 0x1179BB4
		//private void OnClickAssistSelectPage(int newPage) { }

		//// RVA: 0x1179BD8 Offset: 0x1179BD8 VA: 0x1179BD8
		//private void OnFlickOrSwaipAssistSelectPage(int newPage) { }

		//// RVA: 0x1179BF4 Offset: 0x1179BF4 VA: 0x1179BF4
		private void OnChangeAssitName(int page)
		{
			string name = m_view_assist_data.IOKHHOCMNKA(page).JCJNKBKMJFK_Name;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			InputPopupSetting setting = new InputPopupSetting();
			setting.TitleText = bk.GetMessageByLabel("assistselect_namechange_popup_title");
			setting.Description = bk.GetMessageByLabel("assistselect_namechange_popup_details_01");
			setting.InputText = name;
			setting.Notes = bk.GetMessageByLabel("assistselect_namechange_popup_details_02");
			setting.CharacterLimit = 15;
			setting.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(setting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x117BB54
				if(label == PopupButton.ButtonLabel.Ok)
				{
					ChangeAssistName((control.Content as InputContent).Text);
				}
			}, (IPopupContent content, PopupTabButton.ButtonLabel label) =>
			{
				//0x117C674
				return;
			}, null, null);
		}

		//// RVA: 0x117A120 Offset: 0x117A120 VA: 0x117A120
		private void OnStayAssistScene(int attribute)
		{
			if(!IsDoSwaip())
			{
				if(m_assist_scene_data[attribute] != null)
				{
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					ShowSceneStatusPopup(m_assist_scene_data[attribute], GameManager.Instance.ViewPlayerData, () =>
					{
						//0x117C678
						return;
					});
				}
			}
		}

		//// RVA: 0x117A3D8 Offset: 0x117A3D8 VA: 0x117A3D8
		private void OnClickAssistScene(int type)
		{
			if(!IsDoSwaip())
			{
				m_is_stop_swaip = true;
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				AssistSelectArgs arg = new AssistSelectArgs();
				arg.viewData = m_view_assist_data;
				arg.pageIndex = m_assist_select_page;
				arg.slotIndex = type;
				MenuScene.Instance.Call(TransitionList.Type.ASSIST_SELECT, arg, true);
			}
		}

		//// RVA: 0x117A388 Offset: 0x117A388 VA: 0x117A388
		private bool IsDoSwaip()
		{
			return !m_swaip_touch.IsStop() && m_is_lock_scene;
		}

		//// RVA: 0x116D838 Offset: 0x116D838 VA: 0x116D838
		//private void UpdateSwaip() { }

		//// RVA: 0x117226C Offset: 0x117226C VA: 0x117226C
		private void SwaipReset()
		{
			m_swaip_touch.ResetValue();
			m_swaip_touch.ResetInput();
			m_swaip_touch.ResetInputState();
		}
		
		//[CompilerGeneratedAttribute] // RVA: 0x6FEFFC Offset: 0x6FEFFC VA: 0x6FEFFC
		//// RVA: 0x117B2E8 Offset: 0x117B2E8 VA: 0x117B2E8
		//private void <OnClickSceneInfo>b__229_0() { }
		
		//[CompilerGeneratedAttribute] // RVA: 0x6FF06C Offset: 0x6FF06C VA: 0x6FF06C
		//// RVA: 0x117BB54 Offset: 0x117BB54 VA: 0x117BB54
		//private void <OnChangeAssitName>b__276_0(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }
	}
}
