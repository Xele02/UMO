using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class RaidResultBossFilterLayout : LayoutUGUIScriptBase
	{
		public enum FilterType
		{
			Red = 1,
			Blue = 2,
			None = 3,
		}

		private AbsoluteLayout m_layoutRoot; // 0x14

		// RVA: 0x1BD8FA0 Offset: 0x1BD8FA0 VA: 0x1BD8FA0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewByExId("root_g_r_d_filter_sw_filter_onoff_anim") as AbsoluteLayout;
			Loaded();
			return true;
		}

		// RVA: 0x1BD9078 Offset: 0x1BD9078 VA: 0x1BD9078
		public void SetFilter(FilterType type)
		{
			string s = string.Format("{0:D2}", (int)type);
			m_layoutRoot.StartChildrenAnimGoStop(s, s);
			UnityEngine.Debug.Log(s);
		}

		// // RVA: 0x1BD916C Offset: 0x1BD916C VA: 0x1BD916C
		// public bool IsPlaying() { }

		// // RVA: 0x1BD9198 Offset: 0x1BD9198 VA: 0x1BD9198
		public bool IsReady()
		{
			return IsLoaded();
		}
	}
}
