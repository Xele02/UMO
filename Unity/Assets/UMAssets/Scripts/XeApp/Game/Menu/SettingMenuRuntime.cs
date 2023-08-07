using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class SettingMenuRuntime : LayoutLabelScriptBase
	{
		private AbsoluteLayout m_episodePlateLayout; // 0x18
		private LayoutSymbolData m_layoutSymbolData; // 0x1C

		// RVA: 0xC3D7C0 Offset: 0xC3D7C0 VA: 0xC3D7C0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutSymbolData = CreateSymbol("setting_menu", layout);
			m_episodePlateLayout = layout.FindViewByExId("s_m_icon_2_sw_s_m_icon_ep_onoff_anim") as AbsoluteLayout;
			Loaded();
			return true;
		}

		//// RVA: 0xC3C590 Offset: 0xC3C590 VA: 0xC3C590
		public void UpdateContent(DFKGGBMFFGB_PlayerInfo vpd)
		{
			m_episodePlateLayout.StartChildrenAnimGoStop(vpd.JBCIDDKDJMM ? "01" : "02");
		}
	}
}
