using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class MusicSelectSeriesButton : ActionButton
	{
		[SerializeField]
		private int m_logoTextureIndex; // 0x80
		[SerializeField]
		private RawImageEx m_logoImage; // 0x84
		[SerializeField]
		private RawImageEx m_newIcon; // 0x88

		// // RVA: 0xF529B8 Offset: 0xF529B8 VA: 0xF529B8
		// public void SetNew(bool isNew) { }

		// RVA: 0xF529EC Offset: 0xF529EC VA: 0xF529EC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			if(m_logoTextureIndex > 0)
			{
				GameManager.Instance.MenuResidentTextureCache.LoadLogo(m_logoTextureIndex, (IiconTexture icon) =>
				{
					//0xF52B3C
					icon.Set(m_logoImage);
				});
			}
			Loaded();
			return true;
		}
	}
}
