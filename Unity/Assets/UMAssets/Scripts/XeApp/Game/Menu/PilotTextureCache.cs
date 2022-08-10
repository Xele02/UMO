namespace XeApp.Game.Menu
{
	public class PilotTextureCache : IconTextureCache
	{
		private const string TexturePath = "ct/pl/{0:D3}.xab";

		// RVA: 0xDE220C Offset: 0xDE220C VA: 0xDE220C
		public PilotTextureCache() : base(10)
		{
			return;
		}

		// RVA: 0xDE2218 Offset: 0xDE2218 VA: 0xDE2218 Slot: 5
		// public override void Terminated() { }

		// RVA: 0xDE2220 Offset: 0xDE2220 VA: 0xDE2220 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			TodoLogger.Log(0, "CreateIconTexture");
			return null;
		}

		// RVA: 0xDE22A8 Offset: 0xDE22A8 VA: 0xDE22A8
		// public void Load(int id, Action<IiconTexture> callback) { }

		// // RVA: 0xDE2350 Offset: 0xDE2350 VA: 0xDE2350
		// public void TryInstall(int id) { }
	}
}
