using System;

namespace XeApp.Game.Menu
{
	public class EventBannerTextureCache : IconTextureCache
	{

		// RVA: 0xF0ED7C Offset: 0xF0ED7C VA: 0xF0ED7C
		public EventBannerTextureCache() : base(32)
		{
			return;
		}

		// RVA: 0xF0ED88 Offset: 0xF0ED88 VA: 0xF0ED88 Slot: 5
		public override void Terminated()
		{
			Clear();
		}

		// RVA: 0xF0ED90 Offset: 0xF0ED90 VA: 0xF0ED90 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			TodoLogger.Log(0, "EventBannerTextureCache CreateIconTexture");
			return null;
		}

		// // RVA: 0xF0EE18 Offset: 0xF0EE18 VA: 0xF0EE18
		public void LoadBanner(int id, Action<IiconTexture> callback)
		{
			TodoLogger.Log(0, "EventBannerTextureCache LoadBanner");
		}

		// // RVA: 0xF0EED4 Offset: 0xF0EED4 VA: 0xF0EED4
		// public void LoadShortBanner(int id, Action<IiconTexture> callBack) { }

		// // RVA: 0xF0EF90 Offset: 0xF0EF90 VA: 0xF0EF90
		// public void LoadEventStoryThumbnail(int id, Action<IiconTexture> callback) { }

		// // RVA: 0xF0F038 Offset: 0xF0F038 VA: 0xF0F038
		// public void TryInstallEventStoryThumbnail(int id) { }

		// // RVA: 0xF0EE48 Offset: 0xF0EE48 VA: 0xF0EE48
		// public static string MakeBannerPath(int id) { }

		// // RVA: 0xF0EF04 Offset: 0xF0EF04 VA: 0xF0EF04
		// public static string MakeShortBannerPath(int id) { }
	}
}
