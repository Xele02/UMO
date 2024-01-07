using System;

namespace XeApp.Game.Menu
{
	public class DenomIconTexture : IconTexture
	{
		//
	}

	public class DenomIconTextureCache : IconTextureCache
	{

		// RVA: 0x17CF3AC Offset: 0x17CF3AC VA: 0x17CF3AC
		public DenomIconTextureCache() : base(0)
		{
			return;
		}

		// RVA: 0x17CF3B8 Offset: 0x17CF3B8 VA: 0x17CF3B8 Slot: 5
		public override void Terminated()
		{
			Clear();
		}

		// RVA: 0x17CF3C0 Offset: 0x17CF3C0 VA: 0x17CF3C0 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			DenomIconTexture tex = new DenomIconTexture();
			SetupForSplitTexture(info, tex);
			return tex;
		}

		// RVA: 0x17CF448 Offset: 0x17CF448 VA: 0x17CF448
		public void Load(int id, Action<IiconTexture> callback)
		{
			Load(string.Format("ct/dm/{0:D3}.xab", id), callback);
		}
	}
}
