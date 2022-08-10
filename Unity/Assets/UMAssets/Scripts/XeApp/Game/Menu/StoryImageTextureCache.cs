namespace XeApp.Game.Menu
{
	public class StoryImageTextureCache : IconTextureCache
	{

		// RVA: 0x12E36C4 Offset: 0x12E36C4 VA: 0x12E36C4
		public StoryImageTextureCache() : base(4)
		{
			return;
		}

		// // RVA: 0x12E36D0 Offset: 0x12E36D0 VA: 0x12E36D0 Slot: 5
		// public override void Terminated() { }

		// // RVA: 0x12E36D8 Offset: 0x12E36D8 VA: 0x12E36D8 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			TodoLogger.Log(0, "CreateIconTexture");
			return null;
		}

		// // RVA: 0x12E3760 Offset: 0x12E3760 VA: 0x12E3760
		// public void LoadImage(int id, Action<IiconTexture> callback) { }
	}
}
