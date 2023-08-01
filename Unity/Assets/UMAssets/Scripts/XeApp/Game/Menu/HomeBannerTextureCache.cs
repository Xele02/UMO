using System.Text;

namespace XeApp.Game.Menu
{
	public class HomeBannerTextureCache : IconTextureCache
	{
		public const string BundleFormatForGeneral = "ct/ba/hm/{0:D3}.xab";
		public const string BundleFormatForEvent = "ct/ev/hm/{0:D4}.xab";
		public const string BundleFormatForGacha = "ct/gc/hm/{0:D5}.xab";
		public const string BundleFormatForBingo = "ct/bn/hm/{0:D5}.xab";
		public const string BundleFormatForMission = "ct/ba/mi/{0:D5}.xab";
		private StringBuilder m_bundleName = new StringBuilder(32); // 0x20

		// RVA: 0x957BE4 Offset: 0x957BE4 VA: 0x957BE4
		public HomeBannerTextureCache() : base(5)
		{
			return;
		}

		// // RVA: 0x957C68 Offset: 0x957C68 VA: 0x957C68 Slot: 5
		public override void Terminated()
		{
			Clear();
		}

		// // RVA: 0x957C70 Offset: 0x957C70 VA: 0x957C70 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			TodoLogger.LogError(0, "CreateIconTexture");
			return null;
		}

		// // RVA: 0x957CF8 Offset: 0x957CF8 VA: 0x957CF8
		// public void LoadForGenaral(int id, Action<IiconTexture> callback) { }

		// // RVA: 0x957DD0 Offset: 0x957DD0 VA: 0x957DD0
		// public void LoadForEvent(int eventId, Action<IiconTexture> callback) { }

		// // RVA: 0x957EA8 Offset: 0x957EA8 VA: 0x957EA8
		// public void LoadForBingo(int bingoId, Action<IiconTexture> callback) { }

		// // RVA: 0x957F80 Offset: 0x957F80 VA: 0x957F80
		// public void LoadForGacha(int gachaId, Action<IiconTexture> callback) { }

		// // RVA: 0x958058 Offset: 0x958058 VA: 0x958058
		// public void LoadForMission(int missionId, Action<IiconTexture> callback) { }
	}
}
