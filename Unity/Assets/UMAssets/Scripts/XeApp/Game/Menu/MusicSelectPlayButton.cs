using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class MusicSelectPlayButton : ActionButton
	{
		[SerializeField]
		private NumberBase m_useEnergy; // 0x80
		[SerializeField]
		private RawImageEx m_dlMessageImage; // 0x84

		// // RVA: 0x1668210 Offset: 0x1668210 VA: 0x1668210
		// public void SetNeedEnergy(int energy) { }

		// RVA: 0x1668178 Offset: 0x1668178 VA: 0x1668178
		public void SetDLMessage(bool isVisible)
		{
			m_dlMessageImage.enabled = isVisible;
		}

		// RVA: 0x167DD14 Offset: 0x167DD14 VA: 0x167DD14 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			Loaded();
			return true;
		}
	}
}
