namespace XeApp.Game.Menu
{
	public class ItemPackImageTextureCache : IconTextureCache
	{
		private const string TexturePath = "ct/ip/{0:D2}.xab";

		// RVA: 0x14BCD00 Offset: 0x14BCD00 VA: 0x14BCD00 Slot: 5
		// public override void Terminated() { }

		// RVA: 0x14BCD08 Offset: 0x14BCD08 VA: 0x14BCD08 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			UnityEngine.Debug.LogError("TODO CreateIconTexture");
			return null;
		}

		// RVA: 0x14BCDF4 Offset: 0x14BCDF4 VA: 0x14BCDF4
		// public void Load(ItemPackImageTextureCache.Type type, Action<IiconTexture> callback) { }

		// // RVA: 0x14BCEB0 Offset: 0x14BCEB0 VA: 0x14BCEB0
		// public void EntryCache() { }
	}
}
