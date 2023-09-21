using UnityEngine;
using XeApp.Game.Menu;

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
			//public static string GetTextureName(DecorationConstants.Attribute.Type type) { }

			//// RVA: 0x1ACDA6C Offset: 0x1ACDA6C VA: 0x1ACDA6C
			//public static int AttributeBgId(DecorationConstants.Attribute.Type type) { }

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
		//public static DecorationConstants.Attribute.Type MakeAttribute(KDKFHGHGFEK viewDecoItemData) { }

		//// RVA: 0x1ACCE24 Offset: 0x1ACCE24 VA: 0x1ACCE24
		//public static bool IsPoster(EKLNMHFCAOI.FKGCBLHOOCL ctg) { }

		//// RVA: 0x1ACCE48 Offset: 0x1ACCE48 VA: 0x1ACCE48
		public static bool IsItemSpVisit(DecorationItemBase item)
		{
			if (item.DecorationItemCategory != EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp)
				return false;
			return item.Id == 11;
		}

		//// RVA: 0x1ACCED0 Offset: 0x1ACCED0 VA: 0x1ACCED0
		//public static bool IsItemSpVisit(DAJBODHMLAB.MMLACIFMNBN.MHODOAJPNHD item) { }

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
		//public static string GetItemAssetPathFormat(KDKFHGHGFEK viewData, bool useRareBrakePosterAnim) { }

		//// RVA: 0x1ACD0F8 Offset: 0x1ACD0F8 VA: 0x1ACD0F8
		//public static string GetItemAssetPathFormat(EKLNMHFCAOI.FKGCBLHOOCL category, bool useRareBrakePosterAnim) { }

		//// RVA: 0x1ACD278 Offset: 0x1ACD278 VA: 0x1ACD278
		//public static string GetItemFileNameFormat(KDKFHGHGFEK viewData) { }

		//// RVA: 0x1ACD3E4 Offset: 0x1ACD3E4 VA: 0x1ACD3E4
		//public static int GetItemAssetId(KDKFHGHGFEK viewData) { }

		//// RVA: 0x1ABA630 Offset: 0x1ABA630 VA: 0x1ABA630
		//public static string GetItemBundleName(KDKFHGHGFEK viewData, bool useRareBrakePosterAnim, DecorationConstants.Attribute.Type attr = 0) { }

		//// RVA: 0x1ABA80C Offset: 0x1ABA80C VA: 0x1ABA80C
		//public static string GetThumbnailBundleName(KDKFHGHGFEK viewData, DecorationConstants.Attribute.Type attr = 0) { }

		//// RVA: 0x1AC85F8 Offset: 0x1AC85F8 VA: 0x1AC85F8
		//public static string MakeCharaCueSheetName(int charaId) { }
	}
}
