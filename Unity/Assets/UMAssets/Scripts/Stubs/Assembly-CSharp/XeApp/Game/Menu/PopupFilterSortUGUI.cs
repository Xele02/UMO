using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUI : UIBehaviour, IPopupContent
	{
		public enum Parts
		{
			Line = 0,
			Title01 = 1,
			Title02 = 2,
			Sort = 3,
			ToggleButtons = 4,
			ExclusiveToggleButtons = 5,
			CheckBoxes = 6,
			RangeSlider = 7,
			RangeSliderSingle = 8,
			FilterSeries = 9,
			FilterMusicAttr = 10,
			FilterGoDivaMusicExp = 11,
			FilterUnitLive = 12,
			FilterComb = 13,
			FilterReward = 14,
			FilterDifficulty = 15,
			FilterBonus = 16,
			FilterPlate = 17,
			FilterMusicLock = 18,
			FilterMusicBookMark = 19,
			FilterRange = 20,
			FilterMusicSelectSeries = 21,
			FilterMusicSelect = 22,
			FilterShopProduct = 23,
			Max = 24,
		}

		public enum Scene
		{
			None = -1,
			MusicSelect = 0,
			GoDivaMusicSelect = 1,
			MissionMusicSelect = 2,
			UnitDispType = 3,
			PlateSelect = 4,
			VerticalMusicSelect = 5,
			ShopProduct = 6,
			Max = 7,
		}

		private enum GoDivaMusicSelect
		{
			Filter_Title = 0,
			Filter_Difficulty_Title = 1,
			Filter_Difficulty_Button = 2,
			Filter_Difficulty_Line = 3,
			Filter_MusicLevel_Title = 4,
			Filter_MusicLevel_Slider = 5,
			Filter_MusicLevel_Line = 6,
			Filter_MusicAttr_Title = 7,
			Filter_MusicAttr_Button = 8,
			Filter_MusicAttr_Line = 9,
			Filter_Combo_Title = 10,
			Filter_Combo_Button = 11,
			Filter_Combo_Line = 12,
			Filter_Reward_Title = 13,
			Filter_Reward_Button = 14,
			Filter_Reward_Line = 15,
			Filter_MusicExp_Title = 16,
			Filter_MusicExp_Button = 17,
			Filter_MusicExp_Line = 18,
			Max = 19,
		}

		private enum MissionMusicSelect
		{
			Filter_Title = 0,
			Filter_Difficulty_Title = 1,
			Filter_Difficulty_Button = 2,
			Filter_Difficulty_Line = 3,
			Filter_MusicLevel_Title = 4,
			Filter_MusicLevel_Slider = 5,
			Filter_MusicLevel_Line = 6,
			Filter_MusicAttr_Title = 7,
			Filter_MusicAttr_Button = 8,
			Filter_MusicAttr_Line = 9,
			Filter_Combo_Title = 10,
			Filter_Combo_Button = 11,
			Filter_Combo_Line = 12,
			Filter_Reward_Title = 13,
			Filter_Reward_Button = 14,
			Filter_Reward_Line = 15,
			Filter_Unit_Title = 16,
			Filter_Unit_Button = 17,
			Filter_Unit_Line = 18,
			Filter_Bonus_Title = 19,
			Filter_Bonus_Button = 20,
			Filter_Bonus_Line = 21,
			Max = 22,
		}

		private enum MusicSelect
		{
			Filter_Title = 0,
			Filter_Difficulty_Title = 1,
			Filter_Difficulty_Button = 2,
			Filter_Difficulty_Line = 3,
			Filter_MusicLevel_Title = 4,
			Filter_MusicLevel_Slider = 5,
			Filter_MusicLevel_Line = 6,
			Filter_MusicAttr_Title = 7,
			Filter_MusicAttr_Button = 8,
			Filter_MusicAttr_Line = 9,
			Filter_Combo_Title = 10,
			Filter_Combo_Button = 11,
			Filter_Combo_Line = 12,
			Filter_Reward_Title = 13,
			Filter_Reward_Button = 14,
			Filter_Reward_Line = 15,
			Filter_Unit_Title = 16,
			Filter_Unit_Button = 17,
			Filter_Unit_Line = 18,
			Max = 19,
		}

		private enum PlateSelect
		{
			Filter_Plate = 0,
			Max = 1,
		}

		private enum ShopProduct
		{
			Filter_Shop = 0,
			Max = 1,
		}

		private enum UnitDispType
		{
			Filter_Scene_Title = 0,
			Filter_Scene_Sort = 1,
			Filter_Diva_Title = 2,
			Filter_Diva_Sort = 3,
			Max = 4,
		}

		private enum VerticalMusicSelect
		{
			Filter_MusicSelect = 0,
			Max = 1,
		}

		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		public Transform Parent => null; //throw new System.NotImplementedException();

		public void CallOpenEnd()
		{
			//throw new System.NotImplementedException();
		}

		public void Hide()
		{
			//throw new System.NotImplementedException();
		}

		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			//throw new System.NotImplementedException();
		}

		public bool IsReady()
		{
			//throw new System.NotImplementedException();
			return true;
		}

		public bool IsScrollable()
		{
			//throw new System.NotImplementedException();
			return true;
		}

		public void Show()
		{
			//throw new System.NotImplementedException();
		}
	}
}
