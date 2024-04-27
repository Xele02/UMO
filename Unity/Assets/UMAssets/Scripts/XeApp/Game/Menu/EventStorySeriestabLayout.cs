using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class EventStorySeriestabLayout : ActionButton
	{
		[SerializeField]
		private int m_logoTextureIndex; // 0x80
		[SerializeField]
		private RawImageEx m_offLogoImage; // 0x84
		[SerializeField]
		private RawImageEx m_onLogoImage; // 0x88
		[SerializeField]
		private RawImageEx new_Icon; // 0x8C

		// RVA: 0xB995F0 Offset: 0xB995F0 VA: 0xB995F0
		private void Start()
		{
			base.Start();
		}

		// RVA: 0xB995F8 Offset: 0xB995F8 VA: 0xB995F8
		private void Update()
		{
			return;
		}

		// RVA: 0xB995FC Offset: 0xB995FC VA: 0xB995FC
		public void setNewIcon(bool iconEnable)
		{
			new_Icon.enabled = iconEnable;
		}

		// RVA: 0xB99630 Offset: 0xB99630 VA: 0xB99630 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			if(m_logoTextureIndex > 0)
			{
				GameManager.Instance.MenuResidentTextureCache.LoadLogo(m_logoTextureIndex, (IiconTexture icon) =>
				{
					//0xB99780
					icon.Set(m_offLogoImage);
					icon.Set(m_onLogoImage);
				});
			}
			Loaded();
			return true;
		}
	}
}
