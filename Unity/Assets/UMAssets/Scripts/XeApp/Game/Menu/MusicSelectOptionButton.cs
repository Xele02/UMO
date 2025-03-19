using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class MusicSelectOptionButton : ActionButton
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
			_Num = 8,
		}

		public const int OptionTypeNum = 8;
		private static readonly string[] s_fontUvName = new string[8]
		{
			"s_m_btn_dtl_fnt_01", "s_m_btn_dtl_fnt_02", "s_m_btn_dtl_fnt_03", "s_m_btn_dtl_fnt_04",
			"s_m_btn_dtl_fnt_05", "s_m_btn_dtl_fnt_06", "s_m_btn_dtl_fnt_08", "s_m_btn_dtl_fnt_09"
		}; // 0x0
		private static readonly string[] s_iconUvName = new string[8]
		{
			"s_m_btn_dtl_icon_01", "s_m_btn_dtl_icon_02", "s_m_btn_dtl_icon_03", "s_m_btn_dtl_icon_04",
			"s_m_btn_dtl_icon_05", "s_m_btn_dtl_icon_07", "s_m_btn_dtl_icon_08", "s_m_btn_dtl_icon_09"
		}; // 0x4
		private static readonly string[] s_buttonFgUvName = new string[8]
		{
			"s_m_btn_dtl_01_01", "s_m_btn_dtl_01_02", "s_m_btn_dtl_01_03", "s_m_btn_dtl_01_04",
			"s_m_btn_dtl_01_04", "s_m_btn_dtl_01_05", "s_m_btn_dtl_01_04", "s_m_btn_dtl_01_04"
		}; // 0x8
		private static readonly string[] s_buttonBgUvName = new string[8]
		{
			"s_m_btn_dtl_01_bg_01", "s_m_btn_dtl_01_bg_02", "s_m_btn_dtl_01_bg_03", "s_m_btn_dtl_01_bg_04",
			"s_m_btn_dtl_01_bg_04", "s_m_btn_dtl_01_bg_05", "s_m_btn_dtl_01_bg_04", "s_m_btn_dtl_01_bg_04"
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

		// // RVA: 0x166B614 Offset: 0x166B614 VA: 0x166B614
		public void ApplyOptionType(OptionType type)
		{
			m_optionType = type;
			m_fontImage.uvRect = GetUvRect(GetFontUvName(type));
			m_iconImage.uvRect = GetUvRect(GetIconUvName(type));
			m_buttonForeImage.uvRect = GetUvRect(GetButtonFgUvName(type));
			m_buttonBackImage.uvRect = GetUvRect(GetButtonBgUvName(type));
			m_eventIconImage.enabled = IsEventType();
		}

		// RVA: 0x166AF30 Offset: 0x166AF30 VA: 0x166AF30
		public void ApplyEnemyDanger(bool enableDanger)
		{
			for(int i = 0; i < m_dangerImage.Count; i++)
			{
				m_dangerImage[i].enabled = enableDanger && m_optionType == OptionType.EnemyInfo;
			}
		}

		// // RVA: 0x166B790 Offset: 0x166B790 VA: 0x166B790
		public bool IsEventType()
		{
			return m_optionType == OptionType.EvStory || m_optionType == OptionType.EvMission || m_optionType == OptionType.EvRanking || m_optionType == OptionType.EvReward;
		}

		// RVA: 0x166B190 Offset: 0x166B190 VA: 0x166B190
		public void SetBadge(bool isOn)
		{
			m_badgeImage.enabled = isOn;
		}

		// // RVA: 0x166BE00 Offset: 0x166BE00 VA: 0x166BE00
		public OptionType GetOptionType()
		{
			return m_optionType;
		}

		// // RVA: 0x167CA00 Offset: 0x167CA00 VA: 0x167CA00
		private string GetFontUvName(OptionType type)
		{
			return s_fontUvName[(int)type];
		}

		// // RVA: 0x167CB7C Offset: 0x167CB7C VA: 0x167CB7C
		private string GetIconUvName(OptionType type)
		{
			return s_iconUvName[(int)type];
		}

		// // RVA: 0x167CC40 Offset: 0x167CC40 VA: 0x167CC40
		private string GetButtonFgUvName(OptionType type)
		{
			return s_buttonFgUvName[(int)type];
		}

		// // RVA: 0x167CD04 Offset: 0x167CD04 VA: 0x167CD04
		private string GetButtonBgUvName(OptionType type)
		{
			return s_buttonBgUvName[(int)type];
		}

		// // RVA: 0x167CAC4 Offset: 0x167CAC4 VA: 0x167CAC4
		private Rect GetUvRect(string uvName)
		{
			return LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData(uvName));
		}

		// RVA: 0x167CDC8 Offset: 0x167CDC8 VA: 0x167CDC8 Slot: 5
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
