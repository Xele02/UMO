namespace XeApp.Game.Menu
{
	public class KiraDivaTextureCache : IconTextureCache
	{
		private const string KiraDivaTexPath = "ct/dv/gc/kira/{0:D2}.xab";

		// RVA: 0x14BE488 Offset: 0x14BE488 VA: 0x14BE488
		public KiraDivaTextureCache() : base(4)
		{
			return;
		}

		// RVA: 0x14BE494 Offset: 0x14BE494 VA: 0x14BE494 Slot: 5
		// public override void Terminated() { }

		// RVA: 0x14BE49C Offset: 0x14BE49C VA: 0x14BE49C Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			TodoLogger.Log(0, "CreateIconTexture");
			return null;
		}

		// RVA: 0x14BE524 Offset: 0x14BE524 VA: 0x14BE524
		// public void Load(int id, Action<IiconTexture> callback) { }
	}
}
