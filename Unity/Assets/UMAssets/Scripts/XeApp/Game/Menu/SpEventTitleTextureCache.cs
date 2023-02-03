namespace XeApp.Game.Menu
{
	public class SpEventTitleTextureCache : IconTextureCache
	{

		// RVA: 0x12DFBCC Offset: 0x12DFBCC VA: 0x12DFBCC
		public SpEventTitleTextureCache() : base(8)
		{
			return;
		}

		// // RVA: 0x12DFBD8 Offset: 0x12DFBD8 VA: 0x12DFBD8 Slot: 5
		public override void Terminated()
		{
			Clear();
		}

		// // RVA: 0x12DFBE0 Offset: 0x12DFBE0 VA: 0x12DFBE0 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			TodoLogger.Log(0, "CreateIconTexture");
			return null;
		}

		// // RVA: 0x12DFC68 Offset: 0x12DFC68 VA: 0x12DFC68
		// public void Load(int eventId, int subId, Action<IiconTexture> callBack) { }

		// // RVA: 0x12DFD44 Offset: 0x12DFD44 VA: 0x12DFD44
		// public void TryInstall(int eventId, int subId) { }

		// // RVA: 0x12DFC9C Offset: 0x12DFC9C VA: 0x12DFC9C
		// public static string MakeTexturePath(int eventId, int subId) { }
	}
}
