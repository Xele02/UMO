using System.Text;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class SceneViewerPageLamp : LayoutUGUIScriptBase
	{
		private int m_currentPage; // 0x14
		private int m_maxPage; // 0x18
		private AbsoluteLayout m_rootAnimeLayout; // 0x1C
		private AbsoluteLayout[] m_lampChangeLayout; // 0x20
		private AbsoluteLayout m_ChengeIconNum; // 0x24

		public int Page { get { return m_currentPage; } } //0xA64C9C
		//public int MaxPage { get; } 0xA64CA4
		//public bool IsFirstPage { get; } 0xA64CAC
		//public bool IsLastPage { get; } 0xA64CC0

		// RVA: 0xA64CDC Offset: 0xA64CDC VA: 0xA64CDC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_rootAnimeLayout = layout.FindViewByExId("sw_chk_scene_browse_anim_sw_cmn_chk_browse_anim") as AbsoluteLayout;
			m_lampChangeLayout = new AbsoluteLayout[3];
			StringBuilder str = new StringBuilder(64);
			for(int i = 0; i < m_lampChangeLayout.Length; i++)
			{
				str.Clear();
				str.SetFormat("swtbl_cmn_chk_browse_swtbl_cmn_chk_mark_{0:D2}", i + 1);
				m_lampChangeLayout[i] = layout.FindViewByExId(str.ToString()) as AbsoluteLayout;
			}
			ClearLoadedCallback();
			m_ChengeIconNum = layout.FindViewByExId("sw_cmn_chk_browse_anim_swtbl_cmn_chk_browse") as AbsoluteLayout;
			Loaded();
			return true;
		}

		//// RVA: 0xA65078 Offset: 0xA65078 VA: 0xA65078
		public void SetPage(int page)
		{
			m_currentPage = page;
			UpdatePage();
		}

		//// RVA: 0xA65178 Offset: 0xA65178 VA: 0xA65178
		//public void SetMaxPage(int maxPage, bool _isSixStar) { }

		//// RVA: 0xA65288 Offset: 0xA65288 VA: 0xA65288
		public void Show()
		{
			m_rootAnimeLayout.StartAnimGoStop("st_in");
		}

		//// RVA: 0xA65304 Offset: 0xA65304 VA: 0xA65304
		public void Hide()
		{
			m_rootAnimeLayout.StartAnimGoStop("st_out");
		}

		//// RVA: 0xA65080 Offset: 0xA65080 VA: 0xA65080
		public void UpdatePage()
		{
			for(int i = 0; i < m_lampChangeLayout.Length; i++)
			{
				m_lampChangeLayout[i].StartChildrenAnimGoStop(m_currentPage == i ? "02" : "01");
			}
		}
	}
}
