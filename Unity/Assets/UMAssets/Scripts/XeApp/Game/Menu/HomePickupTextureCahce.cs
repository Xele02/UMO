using System.Text;

namespace XeApp.Game.Menu
{
	public class HomePickupTexture : IconTexture
	{
		//
	}

	public class HomePickupTextureCahce : IconTextureCache
	{
		public const string BundleFormatForGeneral = "ct/ba/pc/{0:D3}.xab";
		public const string BundleFormatForEvent = "ct/ev/pc/{0:D4}.xab";
		public const string BundleFormatForGacha = "ct/gc/pc/{0:D5}.xab";
		public const string BundleFormatForBingo = "ct/bn/pc/{0:D5}.xab";
		private StringBuilder m_bundleName = new StringBuilder(32); // 0x20

		// RVA: 0x96D0C8 Offset: 0x96D0C8 VA: 0x96D0C8
		public HomePickupTextureCahce() : base(1)
		{
			return;
		}

		// // RVA: 0x96D14C Offset: 0x96D14C VA: 0x96D14C Slot: 5
		public override void Terminated()
		{
			Clear();
		}

		// // RVA: 0x96D154 Offset: 0x96D154 VA: 0x96D154 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			HomePickupTexture tex = new HomePickupTexture();
			SetupForSplitTexture(info, tex);
			return tex;
		}

		// // RVA: 0x96D1DC Offset: 0x96D1DC VA: 0x96D1DC
		// public void LoadForGeneral(int id, Action<IiconTexture> callBack) { }

		// // RVA: 0x96D2B4 Offset: 0x96D2B4 VA: 0x96D2B4
		// public void LoadForEvent(int eventId, Action<IiconTexture> callBack) { }

		// // RVA: 0x96D38C Offset: 0x96D38C VA: 0x96D38C
		// public void LoadForGacha(int gachaId, Action<IiconTexture> callBack) { }

		// // RVA: 0x96D464 Offset: 0x96D464 VA: 0x96D464
		// public void LoadForBingo(int bingoId, Action<IiconTexture> callBack) { }
	}
}
