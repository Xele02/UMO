namespace XeApp.Game.Menu
{
	public class MusicRatioTextureCache : IconTextureCache
	{
		private const int IconCount = 2;
		private const string TexturePath = "ct/mr/{0:D2}.xab";

		// RVA: 0x1053FD8 Offset: 0x1053FD8 VA: 0x1053FD8 Slot: 5
		// public override void Terminated() { }

		// RVA: 0x1053FE0 Offset: 0x1053FE0 VA: 0x1053FE0 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			TodoLogger.Log(0, "CreateIconTexture");
			return null;
		}

		// // RVA: 0x10540CC Offset: 0x10540CC VA: 0x10540CC
		// public void Load(HighScoreRatingRank.Type rank, Action<IiconTexture> callback) { }

		// // RVA: 0x1054190 Offset: 0x1054190 VA: 0x1054190
		public void EntryCache()
		{
			TodoLogger.Log(0, "EntryCache");
		}
	}
}
