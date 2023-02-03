namespace XeApp.Game.Menu
{
	public class SceneFrameTextureCache : IconTextureCache
	{
		private bool m_useCardUv; // 0x20

		// RVA: 0x15A6610 Offset: 0x15A6610 VA: 0x15A6610
		public SceneFrameTextureCache() : base(1)
		{
			return;
		}

		// // RVA: 0x15A661C Offset: 0x15A661C VA: 0x15A661C
		// public void SetUseCardUv(bool useCardUv) { }

		// // RVA: 0x15A6624 Offset: 0x15A6624 VA: 0x15A6624 Slot: 5
		public override void Terminated()
		{
			Clear();
		}

		// RVA: 0x15A6634 Offset: 0x15A6634 VA: 0x15A6634 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			TodoLogger.Log(0, "CreateIconTexture");
			return null;
		}

		// RVA: 0x15A66C4 Offset: 0x15A66C4 VA: 0x15A66C4
		// public void Load(GameAttribute.Type attribute, int baseRare, int evolveId, Action<IiconTexture> callback) { }
	}
}
