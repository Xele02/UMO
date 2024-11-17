using System;

namespace XeApp.Game.Menu
{
	public class GachaProductTexture : IconTexture
	{
		//
	}

	public class GachaProductTextureCache : IconTextureCache
	{
		// RVA: 0xEE42A0 Offset: 0xEE42A0 VA: 0xEE42A0
		public GachaProductTextureCache() : base(4)
		{
			return;
		}

		// RVA: 0xEE42AC Offset: 0xEE42AC VA: 0xEE42AC Slot: 5
		public override void Terminated()
		{
			Clear();
		}

		// RVA: 0xEE42B4 Offset: 0xEE42B4 VA: 0xEE42B4 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			GachaProductTexture tex = new GachaProductTexture();
			SetupForSplitTexture(info, tex);
			return tex;
		}

		// RVA: 0xEE433C Offset: 0xEE433C VA: 0xEE433C Slot: 6
		public override void Load(string id, Action<IiconTexture> callback)
		{
			base.Load(string.Format("ct/gc/pd/{0}.xab", id), callback);
		}
	}
}
