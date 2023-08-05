using System.Text;

namespace XeApp.Game.Menu
{
	public class GachaPickupTextureCache : IconTextureCache
	{
		public const string BundleFormat = "ct/gc/pr/{0:D5}.xab";
		private StringBuilder m_bundleName = new StringBuilder(32); // 0x20

		// RVA: 0xEE40AC Offset: 0xEE40AC VA: 0xEE40AC
		public GachaPickupTextureCache() : base(1)
		{
			return;
		}

		// RVA: 0xEE4130 Offset: 0xEE4130 VA: 0xEE4130 Slot: 5
		public override void Terminated()
		{
			Clear();
		}

		// RVA: 0xEE4138 Offset: 0xEE4138 VA: 0xEE4138 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			TodoLogger.LogError(0, "CreateIconTexture");
			return null;
		}

		// RVA: 0xEE41C0 Offset: 0xEE41C0 VA: 0xEE41C0
		// public void Load(int gachaId, Action<IiconTexture> callback) { }
	}
}
