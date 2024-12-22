using System;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;
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

				public bool Visible { set
					{
						num.enabled = value;
						foreach(var v in enable)
						{
							v.enabled = value;
						}
						if (rank_up_anim != null)
						{
							foreach (var v in rank_up_anim)
							{
								v.enabled = value;
							}
						}
						if (rank_unlock_anim != null)
						{
							foreach (var v in rank_unlock_anim)
							{
								v.enabled = value;
							}
						}
					}
				} //0x7FD48C
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
			public void SetVisibleCostumeIcon(bool isVisible)
			{
				rank.Visible = isVisible;
				image.enabled = isVisible;
				if (enable == null)
					return;
				enable.enabled = isVisible;
			}

			//// RVA: 0x16FC030 Offset: 0x16FC030 VA: 0x16FC030
			//public int GetColorId(short[] colorId) { }

			//// RVA: 0x16ED810 Offset: 0x16ED810 VA: 0x16ED810
			public void SetCostumeIcon(Setting setting, Func<Setting, bool> validater)
			{
				SetVisibleCostumeIcon(false);
				int dvId = setting.divaId;
				int mdlId = setting.costumeModelId;
				RawImageEx image2 = image;
				int clrId = setting.colorId == null || mdlId == 0 ? 0 : 1;
				loadingCostumeImage[image] = setting;
				MenuScene.Instance.CostumeIconCache.Load(dvId, mdlId, clrId, (IiconTexture texture) =>
				{
					//0x16FC1BC
					if(validater == null || validater(setting))
					{
						Setting s = loadingCostumeImage[image];
						if (s.divaId == dvId && s.costumeModelId == mdlId)
						{
							int cId = s.colorId == null || s.colorId.Length == 0 ? 0 : 1;
							if (cId == clrId)
							{
								SetVisibleCostumeIcon(true);
								texture.Set(image2);
							}
						}
					}
				});
				if(enable != null)
				{
					enable.StartChildrenAnimGoStop(AnimationLabelList[setting.isHave ? 0 : 2]);
				}
				rank.num.StartChildrenAnimGoStop(setting.rankMax - 1, setting.rankMax - 1);
				for(int i = 0; i < setting.rankMax; i++)
				{
					if(setting.rankNum - 1 < i)
					{
						rank.enable[i].StartChildrenAnimGoStop(AnimationLabelList[1], AnimationLabelList[1]);
					}
					else
					{
						rank.enable[i].StartChildrenAnimGoStop(AnimationLabelList[0], AnimationLabelList[0]);
					}
					if(rank.rank_up_anim != null)
					{
						rank.rank_up_anim[i].StartChildrenAnimGoStop(0, 0);
					}
				}
				if (rank.rank_unlock_num != null)
					rank.rank_unlock_num.StartChildrenAnimGoStop(setting.rankMax - 1, setting.rankMax - 1);
			}

			//// RVA: 0x16FC054 Offset: 0x16FC054 VA: 0x16FC054
			public void StartRankUpAnimation(int lv)
			{
				if(rank.rank_up_anim == null)
					return;
				rank.rank_up_anim[lv].StartChildrenAnimGoStop("go_in", "st_in");
			}

			//// RVA: 0x16FC108 Offset: 0x16FC108 VA: 0x16FC108
			public void StartRankUnlockAnimation(int lv)
			{
				if(rank.rank_unlock_anim == null)
					return;
				rank.rank_unlock_anim[lv].StartChildrenAnimGoStop("go_in", "st_in");
			}
		}

		public const int RANK_MAX = 6;
		public const int STATUSUP_BORDER_RANK = 3;

		//// RVA: 0x16EE3EC Offset: 0x16EE3EC VA: 0x16EE3EC
		public static void SettingRewardIcon(LFAFJCNKLML data, int item_id, int rank, int value, RewardIconLayoutSetting layout_setting, Func<LFAFJCNKLML, bool> validater)
		{
			NumberBase num = layout_setting.get_num;
			LFAFJCNKLML.FHLDDEKAJKI d = data.OCOOHBINGBG_LevelInfo[rank];
			bool isTargetReward = data.HGBJODBCJDA - 1 <= rank;
			layout_setting.diva_image.enabled = false;
			layout_setting.item_image.enabled = false;
			switch(d.PEEAGFNOFFO_UnlockType)
			{
				case LCLCCHLDNHJ_Costume.FPDJGDGEBNG_UnlockType.NKKIKONDGPF_1_CostumeEffect/*1*/:
					MenuScene.Instance.ItemTextureCache.Load(data.JPIDIENBGKH_CostumeId + item_id, (IiconTexture texture) =>
					{
						//0x16FB624
						if(validater == null || validater(data))
						{
							SettingRewardIcon(layout_setting, texture, rank, true, true, false, d.PEEAGFNOFFO_UnlockType, false);
						}
					});
					break;
				default:
					MenuScene.Instance.ItemTextureCache.Load(item_id, (IiconTexture texture) =>
					{
						//0x16FB900
						if(validater == null || validater(data))
						{
							if(num != null)
							{
								num.SetNumber(value, 0);
							}
							SettingRewardIcon(layout_setting, texture, rank, true, false, num != null, d.PEEAGFNOFFO_UnlockType, false);
						}
					});
					break;
				case LCLCCHLDNHJ_Costume.FPDJGDGEBNG_UnlockType.CFOEMAAKOMC_4_CostumeColor/*4*/:
					MenuScene.Instance.ItemTextureCache.Load(data.JPIDIENBGKH_CostumeId + item_id, CKFGMNAIBNG.LLJPMOIPBAG(data.AHHJLDLAPAN_DivaId, data.JPIDIENBGKH_CostumeId, rank), (IiconTexture texture) =>
					{
						//0x16FB718
						if(validater == null || validater(data))
						{
							SettingRewardIcon(layout_setting, texture, rank, true, false, false, d.PEEAGFNOFFO_UnlockType, false);
						}
					});
					break;
				case LCLCCHLDNHJ_Costume.FPDJGDGEBNG_UnlockType.PJJJGFBLIAP_5_Stat/*5*/:
					MenuScene.Instance.DivaIconCache.Load(data.AHHJLDLAPAN_DivaId, 1, 0, (IiconTexture texture) =>
					{
						//0x16FB530
						if(validater == null || validater(data))
						{
							SettingRewardIcon(layout_setting, texture, rank, false, true, false, d.PEEAGFNOFFO_UnlockType, false);
						}
					});
					break;
				case LCLCCHLDNHJ_Costume.FPDJGDGEBNG_UnlockType.JDPFMDOMMJE_6_Support/*6*/:
					MenuScene.Instance.SubPlateIconTextureCahe.Load(d.KJNAHLOODKD_Value[0], d.KJNAHLOODKD_Value[1], (IiconTexture texture) =>
					{
						//0x16FB80C
						if (validater == null || validater(data))
						{
							SettingRewardIcon(layout_setting, texture, rank, true, true, false, d.PEEAGFNOFFO_UnlockType, false);
						}
					});
					break;
			}
		}

		//// RVA: 0x16FA950 Offset: 0x16FA950 VA: 0x16FA950
		private static void SettingRewardIcon(RewardIconLayoutSetting layout_setting, IiconTexture texture, int rank, bool is_item, bool is_status_up, bool is_show_num, LCLCCHLDNHJ_Costume.FPDJGDGEBNG_UnlockType rewardType, bool isTargetReward = false)
		{
			if(is_item)
			{
				layout_setting.item_image.enabled = true;
				layout_setting.diva_image.enabled = false;
				texture.Set(layout_setting.item_image);
			}
			else
			{
				layout_setting.item_image.enabled = false;
				layout_setting.diva_image.enabled = true;
				texture.Set(layout_setting.diva_image);
			}
			if(is_status_up)
			{
				if(rank < 3 || rewardType != LCLCCHLDNHJ_Costume.FPDJGDGEBNG_UnlockType.PJJJGFBLIAP_5_Stat/*5*/)
				{
					layout_setting.item_type.StartChildrenAnimGoStop(1, 1);
				}
				else
				{
					layout_setting.item_type.StartChildrenAnimGoStop(2, 2);
				}
			}
			else
			{
				layout_setting.item_type.StartChildrenAnimGoStop(3, 3);
			}
			if(is_show_num)
			{
				layout_setting.item_type.StartChildrenAnimGoStop(0, 0);
			}
			if (layout_setting.item_rank != null)
				layout_setting.item_rank.StartAllAnimGoStop(rank, rank);
		}

		//// RVA: 0x16FAC5C Offset: 0x16FAC5C VA: 0x16FAC5C
		public static List<LFAFJCNKLML.FHLDDEKAJKI> GetRewardList(LFAFJCNKLML data, int add_point)
		{
			List<LFAFJCNKLML.FHLDDEKAJKI> res = new List<LFAFJCNKLML.FHLDDEKAJKI>();
			int a1 = add_point;
			int a2 = data.ABLHIAEDJAI_Point;
			for(int i = data.GKIKAABHAAD_Level; i < data.OCOOHBINGBG_LevelInfo.Count; i++)
			{
				if(data.OCOOHBINGBG_LevelInfo[i].DNBFMLBNAEE_NeedPoint >= a2 + a1)
				{
					res.Add(data.OCOOHBINGBG_LevelInfo[i]);
					a1 = data.OCOOHBINGBG_LevelInfo[i].DNBFMLBNAEE_NeedPoint - a2;
					a2 = 0;
				}
			}
			return res;
		}

		//// RVA: 0x16FAE3C Offset: 0x16FAE3C VA: 0x16FAE3C
		public static void ShowCommonAchieveWindow(Action buttonCallBack)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			MFDJIFIIPJD m = new MFDJIFIIPJD();
			m.KHEKNNFCAOI(10001, MOEALEGLGCH.FLGEJDKMNMI());
			PopupQuestRewardSetting s = new PopupQuestRewardSetting();
			s.TitleText = bk.GetMessageByLabel("costume_upgrade_achievement_title_text");
			s.IsCaption = true;
			s.WindowSize = SizeType.Small;
			s.Buttons = new ButtonInfo[1] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive } };
			s.ItemInfo = m;
			PopupWindowManager.Show(s, (PopupWindowControl ctrl, PopupButton.ButtonType typ, PopupButton.ButtonLabel lbl) =>
			{
				//0x16FBABC
				buttonCallBack();
			}, null, null, null);
		}

		//// RVA: 0x16FB1C4 Offset: 0x16FB1C4 VA: 0x16FB1C4
		public static void ShowReleaseDailyOperationWindow(int prev, Action buttonCallBack)
		{
			int nowDifficult = KDHGBOOECKC.HHCJCDFCLOB.BCACCAGCPCO();
			if(prev < nowDifficult)
			{
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				PopupOfferUnclokDiffSetting s = new PopupOfferUnclokDiffSetting();
				s.TitleText = "";
				s.IsCaption = false;
				s.preDiff = prev;
				s.popupMsg = bk.GetMessageByLabel("offer_daily_offer_levelup_text");
				s.nextDiff = nowDifficult;
				s.WindowSize = SizeType.Small;
				s.Buttons = new ButtonInfo[1] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative } };
				PopupWindowManager.Show(s, (PopupWindowControl ctrl, PopupButton.ButtonType typ, PopupButton.ButtonLabel lbl) =>
				{
					//0x16FBAE8
					buttonCallBack();
					GameManager.Instance.localSave.EPJOACOONAC_GetSave().DKFCBKNPPOO_Offer.AHAECLAKMIB_UpdateDailyLv(nowDifficult);
					GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
				}, null, null, null);
			}
			else
			{
				buttonCallBack();
			}
		}

		//// RVA: 0x16EFD58 Offset: 0x16EFD58 VA: 0x16EFD58
		public static void ShowItemDetailWindow(LFAFJCNKLML upgradeData, int level, Transform parent)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			CostumeItemDetailPopupSetting s = new CostumeItemDetailPopupSetting();
			s.data = upgradeData;
			s.lv = level;
			s.m_parent = parent;
			s.TitleText = bk.GetMessageByLabel("costume_upgrade_detail_item_title_text");
			s.WindowSize = SizeType.Middle;
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			PopupWindowManager.Show(s, null, null, null, null);
		}
	}
}
