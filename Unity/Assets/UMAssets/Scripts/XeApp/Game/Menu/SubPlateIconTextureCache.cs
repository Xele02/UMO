namespace XeApp.Game.Menu
{
	public class SubPlateIconTextureCache : IconTextureCache
	{
		// // RVA: 0x1A9D7EC Offset: 0x1A9D7EC VA: 0x1A9D7EC Slot: 5
		// public override void Terminated() { }

		// // RVA: 0x1A9D7F4 Offset: 0x1A9D7F4 VA: 0x1A9D7F4 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			UnityEngine.Debug.LogError("TODO CreateIconTexture");
			return null;
		}

		// // RVA: 0x1A9D87C Offset: 0x1A9D87C VA: 0x1A9D87C
		// public void Load(int attr, int status, Action<IiconTexture> callback) { }

		// // RVA: 0x1A9D940 Offset: 0x1A9D940 VA: 0x1A9D940
		// public void TryInstall() { }
	}
}
