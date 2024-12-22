using mcrs;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutCutinFireDiva : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_root; // 0x14
		private AbsoluteLayout m_baseLayout; // 0x18
		private int m_divaId; // 0x1C

		// RVA: 0x19D9D40 Offset: 0x19D9D40 VA: 0x19D9D40
		public void SetStatus(int divaId)
		{
			m_divaId = divaId;
		}

		// RVA: 0x19D9D48 Offset: 0x19D9D48 VA: 0x19D9D48
		public void Reset()
		{
			return;
		}

		// RVA: 0x19D9D4C Offset: 0x19D9D4C VA: 0x19D9D4C
		public void Show()
		{
			SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_STORY_002);
			SoundManager.Instance.voGreeting.EntrySheet();
			SoundManager.Instance.voGreeting.Play(m_divaId, 0);
			if(m_divaId == 8)
			{
				m_root.StartAllAnimGoStop("02");
			}
			else if(m_divaId == 9)
			{
				m_root.StartAllAnimGoStop("01");
			}
			m_root.StartAllAnimGoStop("go_cutin", "st_cutin");
			gameObject.SetActive(true);
		}

		// RVA: 0x19D9F68 Offset: 0x19D9F68 VA: 0x19D9F68
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x19D9FA0 Offset: 0x19D9FA0 VA: 0x19D9FA0
		public bool IsPlaying()
		{
			return m_baseLayout.IsPlayingChildren();
		}

		// RVA: 0x19D9FCC Offset: 0x19D9FCC VA: 0x19D9FCC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.Root[0] as AbsoluteLayout;
			m_baseLayout = layout.FindViewByExId("swtbl_cutin_fire_sw_cutin_fire_base_anim") as AbsoluteLayout;
			Hide();
			Loaded();
			return true;
		}
	}
}
