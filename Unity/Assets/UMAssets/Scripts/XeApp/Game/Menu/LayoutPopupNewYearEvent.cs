using System.Linq;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupNewYearEvent : LayoutUGUIScriptBase
	{
		private RawImageEx m_image; // 0x14
		private HomePickupTextureCahce m_pickupTexCache; // 0x18
		private bool is_image_load; // 0x1C

		// RVA: 0x173A864 Offset: 0x173A864 VA: 0x173A864 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			RawImageEx[] imgs = transform.GetComponentsInChildren<RawImageEx>(true);
			m_image = imgs.Where((RawImageEx _) =>
			{
				//0x173ACC0
				return _.name == "cmn_bnr_pickup_001 (ImageView)";
			}).First();
			m_pickupTexCache = new HomePickupTextureCahce();
			Loaded();
			return true;
		}

		// RVA: 0x173AA48 Offset: 0x173AA48 VA: 0x173AA48
		public void LoadImageUpdate()
		{
			if(m_pickupTexCache != null)
				m_pickupTexCache.Update();
		}

		// RVA: 0x173AA5C Offset: 0x173AA5C VA: 0x173AA5C
		public void Setup(int bannerId)
		{
			is_image_load = true;
			m_pickupTexCache.LoadForGeneral(bannerId, (IiconTexture image) =>
			{
				//0x173AB30
				image.Set(m_image);
				m_image.raycastTarget = false;
				is_image_load = false;
			});
		}

		// RVA: 0x173AB20 Offset: 0x173AB20 VA: 0x173AB20
		public bool IsLoadImage()
		{
			return is_image_load;
		}
	}
}
