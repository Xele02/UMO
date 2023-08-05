using System.Text;

namespace XeApp.Game.Menu
{
	public class LobbyTextureCache : IconTextureCache
	{
		public const string BundleFormatForGroupSelect = "ct/lb/gr/{0:D3}.xab";
		public const string BundleFormatForMiniChara = "ct/lb/ch/{0:D2}_{1:D3}.xab";
		private StringBuilder m_bundleName = new StringBuilder(32); // 0x20

		// RVA: 0xD2300C Offset: 0xD2300C VA: 0xD2300C
		public LobbyTextureCache() : base(1)
		{
			return;
		}

		// RVA: 0xD23090 Offset: 0xD23090 VA: 0xD23090 Slot: 5
		public override void Terminated()
		{
			Clear();
		}

		// RVA: 0xD23098 Offset: 0xD23098 VA: 0xD23098 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			TodoLogger.LogError(0, "CreateIconTexture");
			return null;
		}

		// RVA: 0xD23120 Offset: 0xD23120 VA: 0xD23120
		// public void LoadForLobbyGroupSelect(int id, Action<IiconTexture> callBack) { }

		// // RVA: 0xD1EA50 Offset: 0xD1EA50 VA: 0xD1EA50
		// public void LoadForLobbyMiniChara(int id, int sud_id, Action<IiconTexture> callBack) { }
	}
}
