using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class TipsContent : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text[] m_titleTexts; // 0x14
		[SerializeField]
		private Text[] m_contentTexts; // 0x18
		[SerializeField]
		private RawImageEx m_image; // 0x1C
		[SerializeField]
		private string m_layerName; // 0x20
		private const float DefaultLineSpace = 0.725f;
		private const int TextOnlyContentIndex = 0;
		private const int ImageContentIndex = 1;
		private AbsoluteLayout m_animeLayout; // 0x24

		// RVA: 0xA96DC4 Offset: 0xA96DC4 VA: 0xA96DC4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_animeLayout = layout.FindViewByExId("sw_tips_window_" + m_layerName) as AbsoluteLayout;
			m_contentTexts[1].alignment = TextAnchor.UpperCenter;
			ClearLoadedCallback();
			m_image.enabled = false;
			return true;
		}

		//// RVA: 0xA96F28 Offset: 0xA96F28 VA: 0xA96F28
		//public void SetContent(string title, string tips, TipsTexture texture) { }

		//// RVA: 0xA970E4 Offset: 0xA970E4 VA: 0xA970E4
		//private void SetTitle(string title) { }

		//// RVA: 0xA97184 Offset: 0xA97184 VA: 0xA97184
		//private void SetTipsMessag(string tips, float lineSpace) { }

		//// RVA: 0xA96F94 Offset: 0xA96F94 VA: 0xA96F94
		//private void SetImage(IiconTexture texture) { }
	}
}
