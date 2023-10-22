using System.Text;
using UnityEngine;
using XeApp.Game.Menu;
using XeSys;

namespace XeApp
{
	public class DecorationConstants
	{
		public delegate void DecideItemCallback(LayoutDecorationSelectItemBase selectItem, bool isTapSelect);

		public delegate void VisitButtonCallback(EAJCBFGKKFA_FriendInfo playerData, IiconTexture texture, MusicRatioTextureCache.MusicRatioTexture musicRatioTexture);

		public static class Attribute
		{
			public enum Type
			{
				None = 0,
				WallTop = 1,
				WallBottom = 2,
				Wall = 3,
				FloorTop = 4,
				FloorBottom = 8,
				Floor = 12,
				Both = 15,
				Num = 4,
				BgWallL = 1,
				BgWallR = 2,
				BgFloor = 4,
				BgBoth = 15,
				BgNum = 3,
			}

			public enum AreaType
			{
				None = 0,
				Inner = 1,
				Outer = 2,
				All = 3,
			}

			//// RVA: 0x1ABC760 Offset: 0x1ABC760 VA: 0x1ABC760
			//public static string GetName(DecorationConstants.Attribute.Type type) { }

			//// RVA: 0x1ACD524 Offset: 0x1ACD524 VA: 0x1ACD524
			//public static string GetAssetBundleName(DecorationConstants.Attribute.Type type) { }

			//// RVA: 0x1ACD9F0 Offset: 0x1ACD9F0 VA: 0x1ACD9F0
			public static string GetTextureName(Type type)
			{
				if((int)type > 0 && (int)type - 1 < 4)
					return new string[4] { "wallL", "wallR", "NONE", "floor" }[(int)type - 1];
				else
					return "NONE";
			}

			//// RVA: 0x1ACDA6C Offset: 0x1ACDA6C VA: 0x1ACDA6C
			public static int AttributeBgId(Type type)
			{
				if(type == Type.BgWallL)
					return 1;
				if(type != Type.BgFloor)
				{
					if(type != Type.BgWallR)
						return -1;
					return (int)type;
				}
				return 0;
			}

			//// RVA: 0x1ACDA98 Offset: 0x1ACDA98 VA: 0x1ACDA98
			public static bool CheckAttribute(Type type1, Type type2)
			{
				return (type2 & type1) > 0;
			}

			//// RVA: 0x1ACDAAC Offset: 0x1ACDAAC VA: 0x1ACDAAC
			public static bool CheckArea(AreaType type1, AreaType type2)
			{
				return (type2 & type1) > 0;
			}
		}

		public static readonly string BundleName = "ly/201.xab"; // 0x0
		public static readonly string DecoAssetPath = "dc/"; // 0x4
		public static readonly string ItemAssetPath = DecoAssetPath + "it/"; // 0x8
		public static readonly string BgAssetPath = DecoAssetPath + "bg/"; // 0xC
		public static readonly string cmnAssetPath = DecoAssetPath + "cmn.xab"; // 0x10
		public static readonly string BgCmnAssetPath = BgAssetPath + "cmn.xab"; // 0x14
		public static readonly string ItemRoot = "DecorationCanvas/ItemCanvas/ItemRoot/"; // 0x18
		public static readonly string BgRoot = "DecorationCanvas/BgCanvas/BgRoot/"; // 0x1C
		public static readonly string ItemRoot2 = "ItemCanvas/ItemRoot/"; // 0x20
		public static readonly string BgRoot2 = "BgCanvas/BgRoot/"; // 0x24
		public static readonly string CanvasName = "DecorationCanvas"; // 0x28
		public static readonly string DecorationBgMeshPrefab = "DecorationBgMeshPrefab"; // 0x2C
		public static readonly string DecorationBgHitMeshPrefab = "DecorationBgHitMeshPrefab"; // 0x30
		public static readonly string CanvasRoot = "Canvas_Menu/Root"; // 0x34
		public static readonly string[] AreaName = new string[4] { "wall_top", "wall_bottom", "floor_top", "floor_bottom" }; // 0x38
		public static readonly float DecorationWallWidth = 1024; // 0x3C
		public static readonly Vector2 ItemHitAddictionScale = new Vector2(50, 50); // 0x40
		public static readonly int AreaNum = 3; // 0x48
		public static readonly float VALUE_EPSILON = 0.0001f; // 0x4C

		//// RVA: 0x1AC7444 Offset: 0x1AC7444 VA: 0x1AC7444
		public static Vector2 TouchToScreen(Vector2 touchPosition, RectTransform canvas)
		{
			return new Vector2(touchPosition.x / Screen.width * canvas.rect.width - canvas.rect.width * 0.5f, 
				touchPosition.y / Screen.height * canvas.rect.height - canvas.rect.height * 0.5f);
		}

		//// RVA: 0x1ACCD2C Offset: 0x1ACCD2C VA: 0x1ACCD2C
		public static Attribute.Type MakeAttribute(KDKFHGHGFEK viewDecoItemData)
		{
			if(viewDecoItemData.NPADACLCNAN_Category == EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara)
				return Attribute.Type.Floor;
			if(viewDecoItemData.NPADACLCNAN_Category >= EKLNMHFCAOI.FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster && 
				viewDecoItemData.NPADACLCNAN_Category <= EKLNMHFCAOI.FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft)
				return Attribute.Type.Wall;
			return (Attribute.Type)viewDecoItemData.FJFCNGNGIBN;
		}

		//// RVA: 0x1ACCE24 Offset: 0x1ACCE24 VA: 0x1ACCE24
		public static bool IsPoster(EKLNMHFCAOI.FKGCBLHOOCL_Category ctg)
		{
			if(((int)ctg | 2) != 35)
				return ctg == EKLNMHFCAOI.FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef;
			return true;
		}

		//// RVA: 0x1ACCE48 Offset: 0x1ACCE48 VA: 0x1ACCE48
		public static bool IsItemSpVisit(DecorationItemBase item)
		{
			if (item.DecorationItemCategory != EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp)
				return false;
			return item.Id == 11;
		}

		//// RVA: 0x1ACCED0 Offset: 0x1ACCED0 VA: 0x1ACCED0
		public static bool IsItemSpVisit(DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.MHODOAJPNHD item)
		{
			return EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(item.HAJKNHNAIKL_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp && EKLNMHFCAOI.DEACAHNLMNI_getItemId(item.HAJKNHNAIKL_ItemId) == 11;
		}

		//// RVA: 0x1ACCFB4 Offset: 0x1ACCFB4 VA: 0x1ACCFB4
		public static bool IsRug(DecorationItemBase item)
		{
			if(item.DecorationItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj)
			{
				if (item.Setting.viewDecoItemData.GBJFNGCDKPM == 5)
					return true;
			}
			return false;
		}

		//// RVA: 0x1ACD03C Offset: 0x1ACD03C VA: 0x1ACD03C
		public static string GetItemAssetPathFormat(KDKFHGHGFEK viewData, bool useRareBrakePosterAnim)
		{
			if(viewData != null)
			{
				return GetItemAssetPathFormat(viewData.NPADACLCNAN_Category, useRareBrakePosterAnim);
			}
			return "";
		}

		//// RVA: 0x1ACD0F8 Offset: 0x1ACD0F8 VA: 0x1ACD0F8
		public static string GetItemAssetPathFormat(EKLNMHFCAOI.FKGCBLHOOCL_Category category, bool useRareBrakePosterAnim)
		{
			switch(category)
			{
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg:
					return "bg/{0:D4}/{1}.xab";
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj:
					return "it/{0:D4}.xab";
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara:
					return "ch/{0:D2}.xab";
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif:
					return "sf/{0:D4}.xab";
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp:
					return "sp/{0:D4}.xab";
				default:
					break;
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster:
					return "ps/{0:D6}.xab";
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef:
					return useRareBrakePosterAnim ? "ps2/{0:D6}_01.xab" : "ps/{0:D6}_01.xab";
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft:
					return useRareBrakePosterAnim ? "ps2/{0:D6}_02.xab" : "ps/{0:D6}_02.xab";
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.HEMGMACMGAB_DecoItemVFFigure:
					return "vl/{0:D2}_01.xab";
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.NNBMEEPOBIO_DecoItemCostumeTorso:
					return "cs/{0:D3}.xab";
			}
			return "";
		}

		//// RVA: 0x1ACD278 Offset: 0x1ACD278 VA: 0x1ACD278
		public static string GetItemFileNameFormat(KDKFHGHGFEK viewData)
		{
			if(viewData == null)
				return "";
			switch(viewData.NPADACLCNAN_Category)
			{
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj:
					return "deco_{0:D4}";
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara:
				default:
					return "";
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif:
					return "{0:D4}";
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp:
					return "dc_sp_{0:D4}";
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster:
					return "deco_{0:D6}";
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef:
					return "deco_{0:D6}_01";
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft:
					return "deco_{0:D6}_02";
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.HEMGMACMGAB_DecoItemVFFigure:
					return "deco_{0:D2}_01";
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.NNBMEEPOBIO_DecoItemCostumeTorso:
					return "deco_{0:D3}";
			}
		}

		//// RVA: 0x1ACD3E4 Offset: 0x1ACD3E4 VA: 0x1ACD3E4
		public static int GetItemAssetId(KDKFHGHGFEK viewData)
		{
			if(viewData != null)
			{
				switch(viewData.NPADACLCNAN_Category)
				{
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg:
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj:
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara:
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp:
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef:
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft:
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.HEMGMACMGAB_DecoItemVFFigure:
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.NNBMEEPOBIO_DecoItemCostumeTorso:
						return viewData.PPFNGGCBJKC_Id;
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif:
						return viewData.GBJFNGCDKPM;
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster:
						return EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(viewData.NPADACLCNAN_Category, viewData.PPFNGGCBJKC_Id);
				}
			}
			return 0;
		}

		//// RVA: 0x1ABA630 Offset: 0x1ABA630 VA: 0x1ABA630
		public static string GetItemBundleName(KDKFHGHGFEK viewData, bool useRareBrakePosterAnim, Attribute.Type attr = 0)
		{
			string str = GetItemAssetPathFormat(viewData, useRareBrakePosterAnim);
			if(str != "")
			{
				str = string.Format(DecoAssetPath + str, GetItemAssetId(viewData), (int)attr > 0 && (int)attr - 1 < 4 ? new string[4] { "wl", "wr", "NONE", "fl" }[(int)attr - 1] : "NONE");
			}
			return str;
		}

		//// RVA: 0x1ABA80C Offset: 0x1ABA80C VA: 0x1ABA80C
		public static string GetThumbnailBundleName(KDKFHGHGFEK viewData, DecorationConstants.Attribute.Type attr = 0)
		{
			if(viewData == null)
				return "";
			int itemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(viewData.NPADACLCNAN_Category, viewData.PPFNGGCBJKC_Id);
			switch(viewData.NPADACLCNAN_Category)
			{
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg:
					if(attr == Attribute.Type.BgWallL)
						return ItemTextureCache.MakeDecoItemIconTexturePath(itemId, 2);
					else if(attr == Attribute.Type.BgWallR)
						return ItemTextureCache.MakeDecoItemIconTexturePath(itemId, 3);
					else if(attr == Attribute.Type.BgFloor)
						return ItemTextureCache.MakeDecoItemIconTexturePath(itemId, 1);
					break;
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp:
					if(viewData.GBJFNGCDKPM == 11)
						return "";
					return ItemTextureCache.MakeDecoItemIconTexturePath(itemId, 0);
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj:
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara:
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif:
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.HEMGMACMGAB_DecoItemVFFigure:
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.NNBMEEPOBIO_DecoItemCostumeTorso:
					return ItemTextureCache.MakeDecoItemIconTexturePath(itemId, 0);
				default:
					return "";
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster:
					return ItemTextureCache.MakeDecoPosterIconTexturePath(itemId, 0);
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef:
					return ItemTextureCache.MakeDecoPosterIconTexturePath(itemId, 1);
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft:
					return ItemTextureCache.MakeDecoPosterIconTexturePath(itemId, 2);
			}
			return "";
		}

		//// RVA: 0x1AC85F8 Offset: 0x1AC85F8 VA: 0x1AC85F8
		public static string MakeCharaCueSheetName(int charaId)
		{
			StringBuilder str = new StringBuilder(32);
			str.SetFormat("cs_dec_char_{0:D3}", charaId);
			return str.ToString();
		}
	}
}
