using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class RaidActPlayButton : ActionButton
	{
		[SerializeField]
		private NumberBase m_useAp; // 0x80
		[SerializeField]
		private RawImageEx m_dlMessageImage; // 0x84

		// RVA: 0x9EBAFC Offset: 0x9EBAFC VA: 0x9EBAFC
		public void SetNeedAp(int ap)
		{
			if(m_useAp != null)
				m_useAp.SetNumber(ap, 0);
		}

		// RVA: 0x9EBBC4 Offset: 0x9EBBC4 VA: 0x9EBBC4
		public void SetDLMessage(bool isVisible)
		{
			m_dlMessageImage.enabled = isVisible;
		}

		// RVA: 0x9EBBF8 Offset: 0x9EBBF8 VA: 0x9EBBF8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			Loaded();
			return true;
		}
	}
}
