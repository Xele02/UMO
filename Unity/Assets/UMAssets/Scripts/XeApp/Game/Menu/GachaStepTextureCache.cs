using UnityEngine;

namespace XeApp.Game.Menu
{
	public class GachaStepTextureCache : IconTextureCache
	{
		public class GachaStepTexture : IconTexture
		{
			private const float Width = 512;
			private const float Height = 40;
			private const int Column = 1;
			private const int Row = 12;
			public const int Unit = 12;

			public Material MaterialAdd { get; set; } // 0x20

			// // RVA: 0xB6CA5C Offset: 0xB6CA5C VA: 0xB6CA5C
			// public void Set(RawImageEx image, int step) { }
		}

		// RVA: 0xB6C8AC Offset: 0xB6C8AC VA: 0xB6C8AC
		public GachaStepTextureCache() : base(1)
		{
			return;
		}

		// RVA: 0xB6C8B8 Offset: 0xB6C8B8 VA: 0xB6C8B8 Slot: 5
		public override void Terminated()
		{
			Clear();
		}

		// RVA: 0xB6C8C0 Offset: 0xB6C8C0 VA: 0xB6C8C0 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			GachaStepTexture tex = new GachaStepTexture();
			SetupForSplitTexture(info, tex);
			tex.MaterialAdd = new Material(Shader.Find("XeSys/Unlit/SplitTextureAdd"));
			return tex;
		}

		// RVA: 0xB6C9AC Offset: 0xB6C9AC VA: 0xB6C9AC
		// public void Load(int id, Action<IiconTexture> callback) { }
	}
}
