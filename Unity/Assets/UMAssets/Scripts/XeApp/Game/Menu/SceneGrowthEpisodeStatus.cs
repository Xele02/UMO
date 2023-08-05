using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using XeSys;
using XeApp.Game.Common.uGUI;

namespace XeApp.Game.Menu
{
	public class SceneGrowthEpisodeStatus : LayoutUGUIScriptBase
	{
		[SerializeField]
		private NumberBase m_den; // 0x14
		[SerializeField]
		private NumberBase m_num; // 0x18
		[SerializeField]
		private NumberBase m_rewardNum; // 0x1C
		[SerializeField]
		private RawImageEx m_rewordIcon; // 0x20
		[SerializeField]
		private Text m_episodeName; // 0x24
		[SerializeField]
		private Text m_nextRewordPoint; // 0x28
		private AbsoluteLayout m_compAnimeLayout; // 0x2C
		private StringBuilder m_strBuilder = new StringBuilder(64); // 0x30

		// RVA: 0x15AD8E0 Offset: 0x15AD8E0 VA: 0x15AD8E0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_compAnimeLayout = layout.FindViewByExId("sw_ab_fr_set_p3_swtbl_num_comp") as AbsoluteLayout;
			ClearLoadedCallback();
			return true;
		}

		// RVA: 0x15AD9B8 Offset: 0x15AD9B8 VA: 0x15AD9B8
		public void UpdateContent(PIGBBNDPPJC episodeData)
		{
			if(episodeData.DKMLDEDKPBA_HasEpisode)
			{
				m_strBuilder.SetFormat("{0} {1}", episodeData.JBFLCHFEIGL.OJELCGDDAOM_MissingPoint, RichTextUtility.MakeSizeTagString("EP", 19));
				m_episodeName.text = episodeData.OPFGFINHFCE_Name;
				m_nextRewordPoint.text = m_strBuilder.ToString();
				if(!episodeData.CCBKMCLDGAD_HasReward)
				{
					m_compAnimeLayout.StartChildrenAnimGoStop("num");
					m_num.SetNumber(episodeData.ABLHIAEDJAI_CurrentPoint, 0);
					m_den.SetNumber(episodeData.DMHDNKILKGI_MaxPoint, 0);
				}
				else
				{
					m_compAnimeLayout.StartChildrenAnimGoStop("comp");
				}
				GameManager.Instance.ItemTextureCache.Load(episodeData.JBFLCHFEIGL.GOOIIPFHOIG.JJBGOIMEIPF_ItemFullId, (IiconTexture texture) =>
				{
					//0x15ADE04
					texture.Set(m_rewordIcon);
				});
				m_rewardNum.SetNumber(episodeData.JBFLCHFEIGL.GOOIIPFHOIG.MBJIFDBEDAC_Cnt, 0);
			}
		}
	}
}
