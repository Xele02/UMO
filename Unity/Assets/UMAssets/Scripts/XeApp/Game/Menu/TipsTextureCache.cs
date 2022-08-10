namespace XeApp.Game.Menu
{
	public class TipsTextureCache : IconTextureCache
	{
		// // RVA: 0xA9C044 Offset: 0xA9C044 VA: 0xA9C044 Slot: 5
		// public override void Terminated() { }

		// // RVA: 0xA9C04C Offset: 0xA9C04C VA: 0xA9C04C Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			TodoLogger.Log(0, "CreateIconTexture");
			return null;
		}

		// // RVA: 0xA992F0 Offset: 0xA992F0 VA: 0xA992F0
		// public void Load(int imageId, Action<IiconTexture> callBack) { }

		// // RVA: 0xA99398 Offset: 0xA99398 VA: 0xA99398
		// public void LoadGraffiti(int id, Action<IiconTexture> callBack) { }

		// // RVA: 0xA99450 Offset: 0xA99450 VA: 0xA99450
		// public void LoadChara(int dir, int id, Action<IiconTexture> callBack) { }
	}
}
