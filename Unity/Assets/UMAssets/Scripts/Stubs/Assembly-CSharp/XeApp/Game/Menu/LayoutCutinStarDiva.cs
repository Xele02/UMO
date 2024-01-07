using XeSys.Gfx;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutCutinStarDiva : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_name; // 0x14
		[SerializeField]
		private RawImageEx m_diva; // 0x18
		private AbsoluteLayout m_root; // 0x1C
		private AbsoluteLayout m_baseLayout; // 0x20
		private int m_divaId; // 0x24

		// RVA: 0x19DB814 Offset: 0x19DB814 VA: 0x19DB814
		public void SetStatus(int divaId)
		{
			m_divaId = divaId;
		}

		// RVA: 0x19DB9D4 Offset: 0x19DB9D4 VA: 0x19DB9D4
		public void SetDivaIcon(int divaId)
		{
			//
		}

		// RVA: 0x19DBA60 Offset: 0x19DBA60 VA: 0x19DBA60
		public void SetDivaName(int divaId)
		{
			//
		}

		// RVA: 0x19DBAEC Offset: 0x19DBAEC VA: 0x19DBAEC
		public void Reset()
		{
			return;
		}

		// RVA: 0x19DB81C Offset: 0x19DB81C VA: 0x19DB81C
		public void Show()
		{
			m_root.StartAllAnimGoStop("go_cutin", "st_cutin");
			gameObject.SetActive(true);
		}

		// RVA: 0x19DB904 Offset: 0x19DB904 VA: 0x19DB904
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x19DB8D8 Offset: 0x19DB8D8 VA: 0x19DB8D8
		public bool IsPlaying()
		{
			return m_baseLayout.IsPlayingChildren();
		}

		// RVA: 0x19DBAF0 Offset: 0x19DBAF0 VA: 0x19DBAF0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.Root[0] as AbsoluteLayout;
			m_baseLayout = layout.FindViewByExId("sw_cutin_star_sw_cutin_star_base_anim") as AbsoluteLayout;
			Hide();
			Loaded();
			return true;
		}
	}
}
