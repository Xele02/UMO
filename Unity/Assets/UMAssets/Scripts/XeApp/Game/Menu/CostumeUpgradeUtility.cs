using System.Collections.Generic;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class CostumeUpgradeUtility
	{
		public struct RewardIconLayoutSetting
		{
			public RawImageEx item_image; // 0x0
			public RawImageEx diva_image; // 0x4
			public AbsoluteLayout item_type; // 0x8
			public NumberBase get_num; // 0xC
			public AbsoluteLayout item_rank; // 0x10

			// RVA: 0x7FD6C4 Offset: 0x7FD6C4 VA: 0x7FD6C4
			public RewardIconLayoutSetting(RawImageEx image, RawImageEx diva, AbsoluteLayout type, NumberBase num, AbsoluteLayout rank)
			{
				item_image = image;
				diva_image = diva;
				item_type = type;
				get_num = num;
				item_rank = rank;
			}
		}

		public class CostumeData
		{
			public struct RankData
			{
				public enum Animation
				{
					Enbale = 0,
					Disable = 1,
					Visible = 2,
				}

				public AbsoluteLayout num; // 0x0
				public List<AbsoluteLayout> enable; // 0x4
				public List<AbsoluteLayout> rank_up_anim; // 0x8
				public AbsoluteLayout rank_unlock_num; // 0xC
				public List<AbsoluteLayout> rank_unlock_anim; // 0x10

				//public bool Visible { set; } 0x7FD48C
			}

			private enum Animation
			{
				Enbale = 0,
				Disable = 1,
				Lock = 2,
			}

			public struct Setting
			{
				public int divaId; // 0x0
				public int costumeModelId; // 0x4
				public short[] colorId; // 0x8
				public bool isHave; // 0xC
				public int rankMax; // 0x10
				public int rankNum; // 0x14
			}

			private string[] AnimationLabelList = new string[3] { "01", "02", "03" }; // 0x8
			public AbsoluteLayout enable; // 0xC
			public RawImageEx image; // 0x10
			public RankData rank; // 0x14
			private Dictionary<RawImageEx, Setting> loadingCostumeImage = new Dictionary<RawImageEx, Setting>(); // 0x28

			//// RVA: 0x16ED7A0 Offset: 0x16ED7A0 VA: 0x16ED7A0
			//public void SetVisibleCostumeIcon(bool isVisible) { }

			//// RVA: 0x16FC030 Offset: 0x16FC030 VA: 0x16FC030
			//public int GetColorId(short[] colorId) { }

			//// RVA: 0x16ED810 Offset: 0x16ED810 VA: 0x16ED810
			//public void SetCostumeIcon(CostumeUpgradeUtility.CostumeData.Setting setting, Func<CostumeUpgradeUtility.CostumeData.Setting, bool> validater) { }

			//// RVA: 0x16FC054 Offset: 0x16FC054 VA: 0x16FC054
			//public void StartRankUpAnimation(int lv) { }

			//// RVA: 0x16FC108 Offset: 0x16FC108 VA: 0x16FC108
			//public void StartRankUnlockAnimation(int lv) { }
		}

		public const int RANK_MAX = 6;
		public const int STATUSUP_BORDER_RANK = 3;

		//// RVA: 0x16EE3EC Offset: 0x16EE3EC VA: 0x16EE3EC
		//public static void SettingRewardIcon(LFAFJCNKLML data, int item_id, int rank, int value, CostumeUpgradeUtility.RewardIconLayoutSetting layout_setting, Func<LFAFJCNKLML, bool> validater) { }

		//// RVA: 0x16FA950 Offset: 0x16FA950 VA: 0x16FA950
		//private static void SettingRewardIcon(CostumeUpgradeUtility.RewardIconLayoutSetting layout_setting, IiconTexture texture, int rank, bool is_item, bool is_status_up, bool is_show_num, LCLCCHLDNHJ.FPDJGDGEBNG rewardType, bool isTargetReward = False) { }

		//// RVA: 0x16FAC5C Offset: 0x16FAC5C VA: 0x16FAC5C
		//public static List<LFAFJCNKLML.FHLDDEKAJKI> GetRewardList(LFAFJCNKLML data, int add_point) { }

		//// RVA: 0x16FAE3C Offset: 0x16FAE3C VA: 0x16FAE3C
		//public static void ShowCommonAchieveWindow(Action buttonCallBack) { }

		//// RVA: 0x16FB1C4 Offset: 0x16FB1C4 VA: 0x16FB1C4
		//public static void ShowReleaseDailyOperationWindow(int prev, Action buttonCallBack) { }

		//// RVA: 0x16EFD58 Offset: 0x16EFD58 VA: 0x16EFD58
		//public static void ShowItemDetailWindow(LFAFJCNKLML upgradeData, int level, Transform parent) { }
	}
}
