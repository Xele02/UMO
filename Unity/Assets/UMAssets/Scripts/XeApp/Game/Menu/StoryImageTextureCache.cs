using System;

namespace XeApp.Game.Menu
{
	public class StoryImageIconTexture : IconTexture
	{
		//
	}

	public class StoryImageTextureCache : IconTextureCache
	{

		// RVA: 0x12E36C4 Offset: 0x12E36C4 VA: 0x12E36C4
		public StoryImageTextureCache() : base(4)
		{
			return;
		}

		// // RVA: 0x12E36D0 Offset: 0x12E36D0 VA: 0x12E36D0 Slot: 5
		public override void Terminated()
		{
			Clear();
		}

		// // RVA: 0x12E36D8 Offset: 0x12E36D8 VA: 0x12E36D8 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			StoryImageIconTexture tex = new StoryImageIconTexture();
			SetupForSplitTexture(info, tex);
			return tex;
		}

		// // RVA: 0x12E3760 Offset: 0x12E3760 VA: 0x12E3760
		public void LoadImage(int id, Action<IiconTexture> callback)
		{
			Load(string.Format("ct/st/sc/{0:d3}.xab", id), callback);
		}
	}
}
