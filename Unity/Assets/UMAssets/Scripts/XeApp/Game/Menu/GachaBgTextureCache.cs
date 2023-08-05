namespace XeApp.Game.Menu
{
	public class GachaBgTextureCache : IconTextureCache
	{
		public const string TexutreBundleFormat = "ct/bg/gc/{0:D5}.xab";

		// RVA: 0xEDB6B4 Offset: 0xEDB6B4 VA: 0xEDB6B4
		public GachaBgTextureCache() : base(4)
		{
			return;
		}

		// RVA: 0xEDB6C0 Offset: 0xEDB6C0 VA: 0xEDB6C0 Slot: 5
		public override void Terminated()
		{
			Clear();
		}

		// RVA: 0xEDB6C8 Offset: 0xEDB6C8 VA: 0xEDB6C8 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			TodoLogger.LogError(0, "CreateIconTexture");
			return null;
		}

		// RVA: 0xEDB750 Offset: 0xEDB750 VA: 0xEDB750
		// public void Load(int gachaId, Action<IiconTexture> callBack) { }
	}
}
