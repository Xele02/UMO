namespace XeApp.Game.Menu
{
	public class GachaStepTextureCache : IconTextureCache
	{
		// RVA: 0xB6C8AC Offset: 0xB6C8AC VA: 0xB6C8AC
		public GachaStepTextureCache() : base(1)
		{
			return;
		}

		// RVA: 0xB6C8B8 Offset: 0xB6C8B8 VA: 0xB6C8B8 Slot: 5
		// public override void Terminated() { }

		// RVA: 0xB6C8C0 Offset: 0xB6C8C0 VA: 0xB6C8C0 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			TodoLogger.Log(0, "CreateIconTexture");
			return null;
		}

		// RVA: 0xB6C9AC Offset: 0xB6C9AC VA: 0xB6C9AC
		// public void Load(int id, Action<IiconTexture> callback) { }
	}
}
