using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class HomeBannerTexture : IconTexture
	{
		public static readonly Rect IconUv = new Rect(0, 0, 1, 1); // 0x0
		public static readonly Rect GachaTitleUv = new Rect(0, 0.75f, 1, 0.25f); // 0x10
		public static readonly Rect GachaPickupIconUv = new Rect(0.25f, 0.25f, 0.5f, 0.5f); // 0x20
		public static readonly Rect GachaListIconUv = new Rect(0, 0, 1, 0.25f); // 0x30

		// RVA: 0x957254 Offset: 0x957254 VA: 0x957254 Slot: 16
		public override void Set(RawImageEx image)
		{
			base.Set(image);
			image.uvRect = IconUv;
		}

		// RVA: 0x957334 Offset: 0x957334 VA: 0x957334 Slot: 17
		public override void Set(RawImage image)
		{
			if(image != null)
			{
				base.Set(image);
				image.uvRect = IconUv;
			}
		}

		//// RVA: 0x95745C Offset: 0x95745C VA: 0x95745C
		//public void SetForGachaTitle(RawImageEx image) { }

		//// RVA: 0x957540 Offset: 0x957540 VA: 0x957540
		//public void SetForGachaTitle(RawImage image) { }

		//// RVA: 0x95766C Offset: 0x95766C VA: 0x95766C
		public void SetForGachaPickupIcon(RawImageEx image)
		{
			base.Set(image);
			image.uvRect = GachaPickupIconUv;
		}

		//// RVA: 0x957750 Offset: 0x957750 VA: 0x957750
		//public void SetForGachaPickupIcon(RawImage image) { }

		//// RVA: 0x95787C Offset: 0x95787C VA: 0x95787C
		//public void SetForGachaListIcon(RawImageEx image) { }

		//// RVA: 0x957960 Offset: 0x957960 VA: 0x957960
		//public void SetForGachaListIcon(RawImage image) { }
	}

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
			HomeBannerTexture tex = new HomeBannerTexture();
			SetupForSplitTexture(info, tex);
			return tex;
		}

		// // RVA: 0x957CF8 Offset: 0x957CF8 VA: 0x957CF8
		public void LoadForGenaral(int id, Action<IiconTexture> callback)
		{
			m_bundleName.SetFormat(BundleFormatForGeneral, id);
			Load(m_bundleName.ToString(), callback);
		}

		// // RVA: 0x957DD0 Offset: 0x957DD0 VA: 0x957DD0
		public void LoadForEvent(int eventId, Action<IiconTexture> callback)
		{
			m_bundleName.SetFormat(BundleFormatForEvent, eventId);
			Load(m_bundleName.ToString(), callback);
		}

		// // RVA: 0x957EA8 Offset: 0x957EA8 VA: 0x957EA8
		public void LoadForBingo(int bingoId, Action<IiconTexture> callback)
		{
			m_bundleName.SetFormat(BundleFormatForBingo, bingoId);
			Load(m_bundleName.ToString(), callback);
		}

		// // RVA: 0x957F80 Offset: 0x957F80 VA: 0x957F80
		public void LoadForGacha(int gachaId, Action<IiconTexture> callback)
		{
			m_bundleName.SetFormat(BundleFormatForGacha, gachaId);
			Load(m_bundleName.ToString(), callback);
		}

		// // RVA: 0x958058 Offset: 0x958058 VA: 0x958058
		// public void LoadForMission(int missionId, Action<IiconTexture> callback) { }
	}
}
