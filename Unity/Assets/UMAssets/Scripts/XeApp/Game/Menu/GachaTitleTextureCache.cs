namespace XeApp.Game.Menu
{
	public class GachaTitleTextureCache : IconTextureCache
	{

		// RVA: 0xB6CEE0 Offset: 0xB6CEE0 VA: 0xB6CEE0
		public GachaTitleTextureCache() : base(1)
		{
			return;
		}

		// RVA: 0xB6CEEC Offset: 0xB6CEEC VA: 0xB6CEEC Slot: 5
		public override void Terminated()
		{
			Clear();
		}

		// RVA: 0xB6CEF4 Offset: 0xB6CEF4 VA: 0xB6CEF4 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			IconTexture tex = new IconTexture();
			SetupForSplitTexture(info, tex);
			return tex;
		}

		// RVA: 0xB6CF7C Offset: 0xB6CF7C VA: 0xB6CF7C
		// public void Load(int id, Action<IiconTexture> callback) { }
	}
}
