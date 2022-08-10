
namespace XeApp.Game.Menu
{
	public class CostumeTextureCache : IconTextureCache
	{
		// RVA: 0x16E8DA0 Offset: 0x16E8DA0 VA: 0x16E8DA0
		public CostumeTextureCache() : base(0)
		{
		}

		// // RVA: 0x16E8DAC Offset: 0x16E8DAC VA: 0x16E8DAC Slot: 5
		// public override void Terminated() { }

		// // RVA: 0x16E8DB4 Offset: 0x16E8DB4 VA: 0x16E8DB4 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			TodoLogger.Log(0, "CreateIconTexture");
			return null;
		}

		// // RVA: 0x16E8E3C Offset: 0x16E8E3C VA: 0x16E8E3C
		// public void Load(int cosId, int colorId, Action<IiconTexture> callBack) { }

		// // RVA: 0x16E8948 Offset: 0x16E8948 VA: 0x16E8948
		// public void Load(int divaId, int modelId, int colorId, Action<IiconTexture> callBack) { }

		// // RVA: 0x16DF598 Offset: 0x16DF598 VA: 0x16DF598
		// public static string MakeCostumeTexturePath(int divaId, int modelId, int colorId) { }

		// // RVA: 0x16E8FD0 Offset: 0x16E8FD0 VA: 0x16E8FD0
		// public void TryInstallCostume(int divaId, int modelId, int colorId) { }
	}
}