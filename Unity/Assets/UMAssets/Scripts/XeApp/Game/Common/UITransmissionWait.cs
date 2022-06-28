using XeSys.Gfx;

namespace XeApp.Game.Common
{
	public class UITransmissionWait : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_root; // 0x14

		// RVA: 0x1CDED84 Offset: 0x1CDED84 VA: 0x1CDED84
		private void Start()
		{
			return;
		}

		// RVA: 0x1CDED88 Offset: 0x1CDED88 VA: 0x1CDED88
		private void Update()
		{
			return;
		}

		// RVA: 0x1CDED8C Offset: 0x1CDED8C VA: 0x1CDED8C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.FindViewByExId("root_cmn_cnct_layout_root") as AbsoluteLayout;
			m_root.StartAllAnimLoop("logo_");
			Loaded();
			gameObject.SetActive(false);
			return true;
		}
	}
}
