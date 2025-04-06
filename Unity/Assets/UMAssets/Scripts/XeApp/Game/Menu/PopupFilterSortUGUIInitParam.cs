
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIInitParam
	{
		public class MusicSelectParamClass
		{
			public OHCAABOMEOF.KGOGMKMBCPP_EventType EventType { get; set; } // 0x8
			public Difficulty.Type Difficulty { get; set; } // 0xC
			public bool IsLine6Mode { get; set; } // 0x10
		}

		public class VerticalMusicSelectParamClass
		{
			public MusicSelectConsts.SeriesType Series { get; set; } // 0x8
		}

		public class MissionMusicSelectParamClass
		{
			public Difficulty.Type Difficulty { get; set; } // 0x8
			public bool IsLine6Mode { get; set; } // 0xC
		}

		public class GoDivaMusicSelectParamClass
		{
			public Difficulty.Type Difficulty { get; set; } // 0x8
			public bool IsLine6Mode { get; set; } // 0xC
		}
 
		public class PlateSelectParamClass
		{
			public int SelectedDivaId { get; set; } // 0x8
		}

		public class ShopProductParamClass
		{
			public int RarityMin { get; set; } // 0x8
			public int RarityMax { get; set; } // 0xC
		}

		public PopupFilterSortUGUI.Scene Scene { get; set; } // 0x8
		public bool EnableSave { get; set; } // 0xC
		public MusicSelectParamClass MusicSelectParam { get; set; } // 0x10
		public VerticalMusicSelectParamClass VerticalMusicSelectParam { get; set; } // 0x14
		public MissionMusicSelectParamClass MissionMusicSelectParam { get; set; } // 0x18
		public GoDivaMusicSelectParamClass GoDivaMusicSelectParam { get; set; } // 0x1C
		public PlateSelectParamClass PlateSelectParam { get; set; } // 0x20
		public ShopProductParamClass ShopProductParam { get; set; } // 0x24

		//// RVA: 0x1C9E810 Offset: 0x1C9E810 VA: 0x1C9E810
		//public void SetMusicSelectParam(OHCAABOMEOF.KGOGMKMBCPP eventType, Difficulty.Type difficulty, bool isLine6Mode, bool enableSave = True) { }

		//// RVA: 0x1C9E8F8 Offset: 0x1C9E8F8 VA: 0x1C9E8F8
		public void SetVerticalMusicSelectParam(MusicSelectConsts.SeriesType series, bool enableSave = true)
		{
			EnableSave = enableSave;
			Scene = PopupFilterSortUGUI.Scene.VerticalMusicSelect;
		}

		//// RVA: 0x1C9E908 Offset: 0x1C9E908 VA: 0x1C9E908
		//public void SetMissionMusicSelectParam(Difficulty.Type difficulty, bool isLine6Mode, bool enableSave = True) { }

		//// RVA: 0x1C9E9CC Offset: 0x1C9E9CC VA: 0x1C9E9CC
		public void SetGoDivaMusicSelectParam(Difficulty.Type difficulty, bool isLine6Mode, bool enableSave/* = True*/)
		{
			EnableSave = enableSave;
			Scene = PopupFilterSortUGUI.Scene.GoDivaMusicSelect;
			GoDivaMusicSelectParam = new GoDivaMusicSelectParamClass();
			GoDivaMusicSelectParam.Difficulty = difficulty;
			GoDivaMusicSelectParam.IsLine6Mode = isLine6Mode;
		}

		//// RVA: 0x1C9EA90 Offset: 0x1C9EA90 VA: 0x1C9EA90
		public void SetPlateSelectParam(int divaId, bool enableSave = true)
		{
			EnableSave = enableSave;
			Scene = PopupFilterSortUGUI.Scene.PlateSelect;
			PlateSelectParam = new PlateSelectParamClass();
			PlateSelectParam.SelectedDivaId = divaId;
		}

		//// RVA: 0x1C9EB38 Offset: 0x1C9EB38 VA: 0x1C9EB38
		public void SetShopProductParam(int rarityMin, int rarityMax, bool enableSave = true)
		{
			EnableSave = enableSave;
			Scene = PopupFilterSortUGUI.Scene.ShopProduct;
			ShopProductParam = new ShopProductParamClass();
			ShopProductParam.RarityMin = rarityMin;
			ShopProductParam.RarityMax = rarityMax;
		}
	}
}
