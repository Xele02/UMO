using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class GrowthAbilityIcon : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_labelImage; // 0x14
		[SerializeField]
		private Text m_statusText; // 0x18
		private AbsoluteLayout m_colorAnimeLayout; // 0x1C
		private TexUVListManager m_uvManager; // 0x20
		private AbsoluteLayout m_abs; // 0x24
		private static readonly string[] m_panelColorLabel = new string[22]
		{
			"", "green", "soul", "voice", "charm", "skill", "skill", "l_skill", "green", "green",
			"green", "notes", "episode", "episode", "episode", "episode", "episode", "", "episode",
			"green", "episode", "story"
		}; // 0x0
		private static readonly string[] m_uvNameTbl = new string[22]
		{
			"", "ab_pop_ab_01", "ab_pop_ab_02", "ab_pop_ab_03", "ab_pop_ab_04", "ab_pop_ab_05", "ab_pop_ab_06",
			"ab_pop_ab_07", "ab_pop_ab_08", "ab_pop_ab_09", "ab_pop_ab_10", "ab_pop_ab_11",
			"ab_pop_ab_12", "ab_pop_ab_12", "ab_pop_ab_12", "ab_pop_ab_12", "ab_pop_ab_12", 
			"", "ab_pop_ab_12", "ab_pop_ab_10", "ab_pop_ab_10", "ab_pop_ab_13"
		}; // 0x4

		// RVA: 0xE206C0 Offset: 0xE206C0 VA: 0xE206C0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			ClearLoadedCallback();
			m_colorAnimeLayout = layout.FindViewByExId("root_pop_ability_swtbl_ab_pop_abbase") as AbsoluteLayout;
			m_uvManager = uvMan;
			return true;
		}

		// RVA: 0xE207A0 Offset: 0xE207A0 VA: 0xE207A0
		public void SetValue(int label, int value)
		{
			m_colorAnimeLayout.StartChildrenAnimGoStop(label.ToString("00"));
			m_statusText.text = string.Format("+{0,3}", value);
			m_colorAnimeLayout.StartChildrenAnimGoStop(m_panelColorLabel[label]);
			m_labelImage.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData(m_uvNameTbl[label]));
		}
	}
}
