using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using System.Collections.Generic;
using System.Text;
using XeSys;

namespace XeApp.Game.Menu
{
	public class MusicSelectDiffButton : ActionButton
	{
		public enum IconType
		{
			ILLEGAL = 0,
			EASY = 1,
			NORMAL = 2,
			HARD = 3,
			VERY_HARD = 4,
			EXTREME = 5,
			HARD_PLUS = 6,
			VERY_HARD_PLUS = 7,
			EXTREME_PLUS = 8,
		}

		private const string s_basicFontTexFormat = "s_m_btn_tab_b_fnt_{0:D2}";
		private const string s_selectedFontTexFormat = "s_m_btn_tab_p_fnt_{0:D2}";
		private const string s_lockedFontTexFormat = "s_m_btn_tab_off_fnt_{0:D2}";
		[SerializeField]
		private LayoutUGUIRuntime m_runtime; // 0x80
		[SerializeField]
		private IconType m_iconType; // 0x84
		[SerializeField]
		private List<RawImageEx> m_basicFonts; // 0x88
		[SerializeField]
		private RawImageEx m_selectedFont; // 0x8C
		[SerializeField]
		private RawImageEx m_lockedFont; // 0x90
		[SerializeField]
		private List<RawImageEx> m_lockIcons; // 0x94
		[SerializeField]
		private GameObject m_newIconParent; // 0x98
		private static string[] s_framePattern = new string[3] { "l", "c", "r" }; // 0x0
		[SerializeField]
		private RectTransform[] m_rectFrame = new RectTransform[s_framePattern.Length]; // 0x9C
		private AbsoluteLayout[] m_layoutFrame = new AbsoluteLayout[3]; // 0xA0
		private TexUVListManager m_uvMan; // 0xA4
		private StringBuilder m_stringBuilder = new StringBuilder(32); // 0xA8
		private NewMarkIcon m_newIcon; // 0xAC

		public IconType iconType { get { return m_iconType; } } //0x1674E9C

		// RVA: 0x1674EA4 Offset: 0x1674EA4 VA: 0x1674EA4
		public void MakeCache()
		{
			m_newIcon.Initialize(m_newIconParent);
			m_newIcon.SetActive(false);
		}

		// // RVA: 0x1674F00 Offset: 0x1674F00 VA: 0x1674F00
		public void ReleaseCache()
		{
			m_newIcon.Release();
		}

		// // RVA: 0x1674F2C Offset: 0x1674F2C VA: 0x1674F2C
		public void SetNew(bool isNew)
		{
			m_newIcon.SetActive(isNew);
		}

		// // RVA: 0x1674F60 Offset: 0x1674F60 VA: 0x1674F60
		public void SetLock(bool isLock)
		{
			for(int i = 0; i < m_lockIcons.Count; i++)
			{
				m_lockIcons[i].enabled = isLock;
			}
		}

		// RVA: 0x1675044 Offset: 0x1675044 VA: 0x1675044
		public void SetIconType(IconType iconType, bool simulation)
		{
			m_iconType = iconType;
			m_stringBuilder.SetFormat("s_m_btn_tab_b_fnt_{0:D2}", (int)iconType);
			if(simulation)
				m_stringBuilder.Append("_simu");
            TexUVData uvData = m_uvMan.GetUVData(m_stringBuilder.ToString());
			for(int i = 0; i < m_basicFonts.Count; i++)
			{
				m_basicFonts[i].uvRect = LayoutUGUIUtility.MakeUnityUVRect(uvData);
			}
			m_stringBuilder.SetFormat("s_m_btn_tab_p_fnt_{0:D2}", (int)iconType);
			if(simulation)
				m_stringBuilder.Append("_simu");
			m_selectedFont.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData(m_stringBuilder.ToString()));
			m_stringBuilder.SetFormat("s_m_btn_tab_off_fnt_{0:D2}", (int)iconType);
			if(simulation)
				m_stringBuilder.Append("_simu");
			m_lockedFont.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData(m_stringBuilder.ToString()));
			for(int i = 0; i < m_layoutFrame.Length; i++)
			{
				m_layoutFrame[i].StartChildrenAnimGoStop(simulation ? "02" : "01");
			}
        }

		// // RVA: 0x1675570 Offset: 0x1675570 VA: 0x1675570
		public Difficulty.Type GetDifficulty()
		{
			Difficulty.Type diff = Difficulty.Type.Illegal;
			if(m_iconType == IconType.EASY)
				diff = Difficulty.Type.Easy;
			else if(m_iconType == IconType.NORMAL)
				diff = Difficulty.Type.Normal;
			else if(m_iconType == IconType.HARD)
				diff = Difficulty.Type.Hard;
			else if(m_iconType == IconType.VERY_HARD)
				diff = Difficulty.Type.VeryHard;
			else if(m_iconType == IconType.EXTREME)
				diff = Difficulty.Type.Extreme;
			else if(m_iconType == IconType.HARD_PLUS)
				diff = Difficulty.Type.Hard;
			else if(m_iconType == IconType.VERY_HARD_PLUS)
				diff = Difficulty.Type.VeryHard;
			else if(m_iconType == IconType.EXTREME_PLUS)
				diff = Difficulty.Type.Extreme;
			return diff;
		}

		// RVA: 0x16755DC Offset: 0x16755DC VA: 0x16755DC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_uvMan = uvMan;
			m_newIcon = new NewMarkIcon();
			for(int i = 0; i < m_layoutFrame.Length; i++)
			{
				m_layoutFrame[i] = m_runtime.FindViewBase(m_rectFrame[i]) as AbsoluteLayout;
			}
			Loaded();
			return true;
		}
	}
}
