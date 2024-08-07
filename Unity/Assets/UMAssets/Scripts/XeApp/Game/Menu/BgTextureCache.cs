using System;

namespace XeApp.Game.Menu
{
	public class BgTextureCache : IconTextureCache
	{
		public const string TexutreBundleFormat = "ct/bg/st/{0:D2}_{1:D2}.xab";

		// RVA: 0x10980A4 Offset: 0x10980A4 VA: 0x10980A4
		public BgTextureCache() : base(4)
		{
			return;
		}

		// RVA: 0x10980B0 Offset: 0x10980B0 VA: 0x10980B0 Slot: 5
		public override void Terminated()
		{
			Clear();
		}

		// RVA: 0x10980B8 Offset: 0x10980B8 VA: 0x10980B8 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			IconTexture res = new IconTexture();
			SetupForSingleTexture(info, res);
			return res;
		}

		// RVA: 0x1098140 Offset: 0x1098140 VA: 0x1098140
		public void Load(int map, int stage, Action<IiconTexture> callBack)
		{
			Load(string.Format(TexutreBundleFormat, map, stage), callBack);
		}
	}
}
