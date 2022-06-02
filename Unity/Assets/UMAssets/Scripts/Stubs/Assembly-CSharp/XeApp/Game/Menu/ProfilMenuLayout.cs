using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class ProfilMenuLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_player_name;
		[SerializeField]
		private Text m_player_name_time;
		[SerializeField]
		private RawImageEx m_diva_image;
		[SerializeField]
		private Transform m_diva_level;
		[SerializeField]
		private ActionButton m_scene_info_tab_btn;
		[SerializeField]
		private ActionButton m_player_info_tab_btn;
		[SerializeField]
		private ActionButton m_stats_info_tab_btn;
		[SerializeField]
		private ActionButton m_assist_info_tab_btn;
		[SerializeField]
		private ActionButton m_lobbyBrowsing_btn;
		[SerializeField]
		private ActionButton m_fanRelease_btn;
		[SerializeField]
		private ActionButton m_fanEntry_btn;
		[SerializeField]
		private ActionButton m_visit_btn;
		[SerializeField]
		private ActionButton m_block_btn;
		[SerializeField]
		private Text m_degree;
		[SerializeField]
		private Text m_comment;
		[SerializeField]
		private Text m_player_id;
		[SerializeField]
		private Text m_player_level;
		[SerializeField]
		private RawImageEx m_degree_image;
		[SerializeField]
		private RawImageEx m_musicrate_image;
		[SerializeField]
		private Text m_musicrate00_text;
		[SerializeField]
		private Text m_musicrate01_text;
		[SerializeField]
		private ActionButton m_musicrate_popup_button;
		[SerializeField]
		private ActionButton m_name_btn;
		[SerializeField]
		private ActionButton m_comment_btn;
		[SerializeField]
		private ActionButton m_degree_btn;
		[SerializeField]
		private ActionButton m_player_id_btn;
		[SerializeField]
		private StayButton m_degree_info;
		[SerializeField]
		private NumberBase m_degree_num;
		[SerializeField]
		private NumberBase m_fanCount_num;
		[SerializeField]
		private Text m_mainGunPower_text;
		[SerializeField]
		private Text[] m_center_skill_name;
		[SerializeField]
		private Text[] m_center_skill_desc;
		[SerializeField]
		private Text[] m_center_skill_level;
		[SerializeField]
		private RawImageEx[] m_center_skill_rank;
		[SerializeField]
		private RawImageEx[] m_center_skill_foldout;
		[SerializeField]
		private ButtonBase[] m_center_skill_btn;
		[SerializeField]
		private RegulationButton m_center_skill_regu_btn;
		[SerializeField]
		private Text m_scene_name;
		[SerializeField]
		private RawImageEx m_scene_image;
		[SerializeField]
		private StayButton m_scene_info;
		[SerializeField]
		private LayoutUGUIHitOnly m_scene_hit_only;
		[SerializeField]
		private RectTransform m_scene_info_rect;
		[SerializeField]
		private Text m_scene_total;
		[SerializeField]
		private Text m_scene_soul;
		[SerializeField]
		private Text m_scene_voice;
		[SerializeField]
		private Text m_scene_charm;
		[SerializeField]
		private Text m_scene_life;
		[SerializeField]
		private Text m_scene_support;
		[SerializeField]
		private Text m_scene_fold;
		[SerializeField]
		private Text m_scene_luck;
		[SerializeField]
		private TextAnchor m_center_skill_name_align;
		[SerializeField]
		private TextAnchor m_center_skill_desc_align;
		[SerializeField]
		private TextAnchor m_center_skill_level_align;
		[SerializeField]
		private ActionButton m_page_left_btn;
		[SerializeField]
		private ActionButton m_page_right_btn;
		[SerializeField]
		private Text m_stats_page_num;
		[SerializeField]
		private Text m_stats_plate_count;
		[SerializeField]
		private Text m_stats_valkyrie_count;
		[SerializeField]
		private Text m_stats_lvmax_plate_count;
		[SerializeField]
		private Text m_stats_costume_count;
		[SerializeField]
		private Text m_stats_mission_clear_count;
		[SerializeField]
		private Text m_stats_clear_count;
		[SerializeField]
		private Text m_stats_perfect_notes_count;
		[SerializeField]
		private Text m_stats_highscore_value;
		[SerializeField]
		private Text m_stats_highscore_music;
		[SerializeField]
		private RawImageEx m_stats_highscore_diff;
		[SerializeField]
		private List<Text> m_stats_clear_music_count;
		[SerializeField]
		private List<Text> m_stats_fullcombo_music_count;
		[SerializeField]
		private List<RawImageEx> m_stats_extreme_image;
		[SerializeField]
		private Text m_emblem_scroll_text;
		[SerializeField]
		private SwapScrollList m_swap_scroll;
		[SerializeField]
		private Text[] m_assist_attribute_title;
		[SerializeField]
		private RawImageEx[] m_assist_scene_image;
		[SerializeField]
		private Text m_assist_name;
		[SerializeField]
		private Text m_assist_caution;
		[SerializeField]
		private Text m_assist_status_page_now;
		[SerializeField]
		private Text m_assist_status_page_max;
		[SerializeField]
		private Text[] m_assist_total;
		[SerializeField]
		private Text[] m_assist_life;
		[SerializeField]
		private Text[] m_assist_center_skill_name;
		[SerializeField]
		private Text[] m_assist_center_skill_level;
		[SerializeField]
		private RawImageEx[] m_assist_certer_skill_rank;
		[SerializeField]
		private Text[] m_assist_soul;
		[SerializeField]
		private Text[] m_assist_voice;
		[SerializeField]
		private Text[] m_assist_charm;
		[SerializeField]
		private Text[] m_assist_support;
		[SerializeField]
		private Text[] m_assist_fold;
		[SerializeField]
		private Text[] m_assist_luck;
		[SerializeField]
		private ActionButton m_assist_name_btn;
		[SerializeField]
		private ActionButton m_assist_status_btn;
		[SerializeField]
		private ActionButton[] m_assist_page_btn;
		[SerializeField]
		private StayButton[] m_assist_plate_btn;
		[SerializeField]
		private SwaipTouch m_swaip_touch;
	}
}
