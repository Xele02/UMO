using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class RaidActSelectOptionButton : ActionButton
	{
		public enum OptionType
		{
			Ranking = 0,
			Reward = 1,
			MusicDetail = 2,
			EvRanking = 3,
			EvReward = 4,
			EnemyInfo = 5,
			EvStory = 6,
			EvMission = 7,
			EvMvp = 8,
			EvRewardList = 9,
			_Num = 10,
		}

		public const int OptionTypeNum = 10;
		private static readonly string[] s_fontUvName = new string[10]
		{
			"s_m_btn_dtl_fnt_01", "s_m_btn_dtl_fnt_02", "s_m_btn_dtl_fnt_03",
			"s_m_btn_dtl_fnt_04", "s_m_btn_dtl_fnt_05", "s_m_btn_dtl_fnt_06", 
			"s_m_btn_dtl_fnt_08", "s_m_btn_dtl_fnt_09", "s_m_btn_dtl_fnt_10", 
			"s_m_btn_dtl_fnt_11"
		}; // 0x0
		private static readonly string[] s_iconUvName = new string[10]
		{
			"s_m_btn_dtl_icon_01", "s_m_btn_dtl_icon_02", "s_m_btn_dtl_icon_03",
			"s_m_btn_dtl_icon_04", "s_m_btn_dtl_icon_05", "s_m_btn_dtl_icon_07",
			"s_m_btn_dtl_icon_08", "s_m_btn_dtl_icon_09", "s_m_btn_dtl_icon_10",
			"s_m_btn_dtl_icon_05"
		}; // 0x4
		private static readonly string[] s_buttonFgUvName = new string[10]
		{
			"s_m_btn_dtl_01_01", "s_m_btn_dtl_01_02", "s_m_btn_dtl_01_03", 
			"s_m_btn_dtl_01_04", "s_m_btn_dtl_01_04", "s_m_btn_dtl_01_05", 
			"s_m_btn_dtl_01_04", "s_m_btn_dtl_01_04", "s_m_btn_dtl_01_04",
			"s_m_btn_dtl_01_04"
		}; // 0x8
		private static readonly string[] s_buttonBgUvName = new string[10]
		{
			"s_m_btn_dtl_01_bg_01", "s_m_btn_dtl_01_bg_02", "s_m_btn_dtl_01_bg_03",
			"s_m_btn_dtl_01_bg_04", "s_m_btn_dtl_01_bg_04", "s_m_btn_dtl_01_bg_05",
			"s_m_btn_dtl_01_bg_04", "s_m_btn_dtl_01_bg_04", "s_m_btn_dtl_01_bg_04",
			"s_m_btn_dtl_01_bg_04"
		}; // 0xC
		[SerializeField]
		private RawImageEx m_fontImage; // 0x80
		[SerializeField]
		private RawImageEx m_iconImage; // 0x84
		[SerializeField]
		private RawImageEx m_buttonForeImage; // 0x88
		[SerializeField]
		private RawImageEx m_buttonBackImage; // 0x8C
		[SerializeField]
		private RawImageEx m_eventIconImage; // 0x90
		[SerializeField]
		private RawImageEx m_badgeImage; // 0x94
		[SerializeField]
		private List<RawImageEx> m_dangerImage; // 0x98
		[SerializeField]
		private OptionType m_optionType; // 0x9C
		private TexUVListManager m_uvMan; // 0xA0

		// // RVA: 0x144D214 Offset: 0x144D214 VA: 0x144D214
		public void ApplyOptionType(OptionType type)
		{
			m_optionType = type;
			m_fontImage.uvRect = GetUvRect(GetFontUvName(type));
			m_iconImage.uvRect = GetUvRect(GetIconUvName(type));
			m_buttonForeImage.uvRect = GetUvRect(GetButtonFgUvName(type));
			m_buttonBackImage.uvRect = GetUvRect(GetButtonBgUvName(type));
			m_eventIconImage.enabled = (m_optionType >= OptionType.EvStory && m_optionType < OptionType._Num) || (m_optionType >= OptionType.EvRanking && m_optionType < OptionType.EnemyInfo);
		}

		// // RVA: 0x144CAD8 Offset: 0x144CAD8 VA: 0x144CAD8
		public void ApplyEnemyDanger(bool enableDanger)
		{
			for(int i = 0; i < m_dangerImage.Count; i++)
			{
				m_dangerImage[i].enabled = m_optionType == OptionType.EnemyInfo && enableDanger;
			}
		}

		// // RVA: 0x144D390 Offset: 0x144D390 VA: 0x144D390
		public bool IsEventType()
		{
			return m_optionType == OptionType.EvRanking || 
				m_optionType == OptionType.EvReward || 
				m_optionType == OptionType.EvStory || 
				m_optionType == OptionType.EvMission || 
				m_optionType == OptionType.EvMvp || 
				m_optionType == OptionType.EvRewardList;
		}

		// RVA: 0x144CD38 Offset: 0x144CD38 VA: 0x144CD38
		public void SetBadge(bool isOn)
		{
			m_badgeImage.enabled = isOn;
		}

		// // RVA: 0x144D9FC Offset: 0x144D9FC VA: 0x144D9FC
		public OptionType GetOptionType()
		{
			return m_optionType;
		}

		// // RVA: 0x1452FB0 Offset: 0x1452FB0 VA: 0x1452FB0
		private string GetFontUvName(OptionType type)
		{
			return s_fontUvName[(int)type];
		}

		// // RVA: 0x145312C Offset: 0x145312C VA: 0x145312C
		private string GetIconUvName(OptionType type)
		{
			return s_iconUvName[(int)type];
		}

		// // RVA: 0x14531F0 Offset: 0x14531F0 VA: 0x14531F0
		private string GetButtonFgUvName(OptionType type)
		{
			return s_buttonFgUvName[(int)type];
		}

		// // RVA: 0x14532B4 Offset: 0x14532B4 VA: 0x14532B4
		private string GetButtonBgUvName(OptionType type)
		{
			return s_buttonBgUvName[(int)type];
		}

		// // RVA: 0x1453074 Offset: 0x1453074 VA: 0x1453074
		private Rect GetUvRect(string uvName)
		{
			return LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData(uvName));
		}

		// RVA: 0x1453378 Offset: 0x1453378 VA: 0x1453378 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_uvMan = uvMan;
			ApplyOptionType(m_optionType);
			ApplyEnemyDanger(false);
			m_badgeImage.enabled = false;
			Loaded();
			return true;
		}
	}
}
