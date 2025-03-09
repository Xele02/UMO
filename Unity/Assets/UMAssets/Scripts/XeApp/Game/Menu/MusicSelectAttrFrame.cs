using XeSys.Gfx;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class MusicSelectAttrFrame : LayoutUGUIScriptBase
	{
		public enum AlignType
		{
			tl = 0,
			tc = 1,
			tr = 2,
			cl = 3,
			cr = 4,
			bl = 5,
			bc = 6,
			br = 7,
			_Num = 8,
		}

		private static readonly string[] s_frameAttrUvFormat = new string[5]
		{
			"s_m_cd_jakt_fr_sel_zok_05_{0:D2}", 
			"s_m_cd_jakt_fr_sel_zok_01_{0:D2}",
			"s_m_cd_jakt_fr_sel_zok_02_{0:D2}",
			"s_m_cd_jakt_fr_sel_zok_03_{0:D2}",
			"s_m_cd_jakt_fr_sel_zok_04_{0:D2}"
		}; // 0x0
		private static readonly string s_frameSLiveUvFormat = "s_m_cd_jakt_fr_sel_zok_06_{0:D2}"; // 0x4
		private static readonly string[] s_subFrameAttrUvFormat = new string[5]
		{
			"s_m_cd_jakt_fr_sel_zok_a05_{0:D2}",
			"s_m_cd_jakt_fr_sel_zok_a01_{0:D2}",
			"s_m_cd_jakt_fr_sel_zok_a02_{0:D2}",
			"s_m_cd_jakt_fr_sel_zok_a03_{0:D2}",
			"s_m_cd_jakt_fr_sel_zok_a04_{0:D2}"
		}; // 0x8
		[SerializeField]
		private List<RawImageEx> m_frameImages; // 0x14
		[SerializeField]
		private List<RawImageEx> m_subFrameImages; // 0x18
		[SerializeField]
		private List<RawImageEx> m_rewardBgImages; // 0x1C
		[SerializeField]
		private TextureListSupport m_texListSupport; // 0x20
		private TexUVListManager m_uvMan; // 0x24

		// RVA: 0x1054F34 Offset: 0x1054F34 VA: 0x1054F34
		public void SetAttribute(GameAttribute.Type attr)
		{
			SetUv(s_frameAttrUvFormat[(int)attr], s_subFrameAttrUvFormat[(int)attr]);
		}

		// // RVA: 0x1055270 Offset: 0x1055270 VA: 0x1055270
		public void SetSimulationLiveFrame()
		{
			SetUv(s_frameAttrUvFormat[0], s_subFrameAttrUvFormat[0]);
		}

		// // RVA: 0x105533C Offset: 0x105533C VA: 0x105533C
		public void SetRewardVisible(bool isVisible)
		{
			for(int i = 0; i < m_subFrameImages.Count; i++)
			{
				m_subFrameImages[i].enabled = isVisible;
			}
			for(int i = 0; i < m_rewardBgImages.Count; i++)
			{
				m_rewardBgImages[i].enabled = isVisible;
			}
		}

		// // RVA: 0x1055054 Offset: 0x1055054 VA: 0x1055054
		protected void SetUv(string uvFormat, string subUvFormat)
		{
			for(int i = 0; i < m_frameImages.Count; i++)
			{
				m_texListSupport.SetImage(m_frameImages[i], string.Format(uvFormat, i + 1));
			}
			for(int i = 0; i < m_subFrameImages.Count; i++)
			{
				m_texListSupport.SetImage(m_subFrameImages[i], string.Format(subUvFormat, i + 1));
			}
		}

		// RVA: 0x10554B4 Offset: 0x10554B4 VA: 0x10554B4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_uvMan = uvMan;
			Loaded();
			return true;
		}
	}
}
