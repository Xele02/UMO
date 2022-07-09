namespace XeApp.Game.Menu
{
	public class MenuResidentTextureCache : IconTextureCache
	{
		// RVA: 0xB2D630 Offset: 0xB2D630 VA: 0xB2D630 Slot: 5
		// public override void Terminated() { }

		// RVA: 0xB2D638 Offset: 0xB2D638 VA: 0xB2D638 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			UnityEngine.Debug.LogError("TODO CreateIconTexture");
			return null;
		}

		// // RVA: 0xB2D6C0 Offset: 0xB2D6C0 VA: 0xB2D6C0
		// public void LoadLogo(int seriase, Action<IiconTexture> callBack) { }

		// // RVA: 0xB2D768 Offset: 0xB2D768 VA: 0xB2D768
		// public void LoadLogoUnlock(int seriase, Action<IiconTexture> callBack) { }

		// // RVA: 0xB2D810 Offset: 0xB2D810 VA: 0xB2D810
		// public void LoadDegree(int id, int subId, Action<IiconTexture> callBack) { }

		// // RVA: 0xB2D8D4 Offset: 0xB2D8D4 VA: 0xB2D8D4
		// public void EntryCache() { }
	}
}
