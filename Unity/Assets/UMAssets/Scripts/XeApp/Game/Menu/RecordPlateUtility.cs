
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class RecordPlateUtility
	{
		public enum eSceneType
		{
			None = 0,
			Result = 1,
			PresentBox = 2,
			Gacha = 3,
			Quest = 4,
			EventResult = 5,
			Offer = 6,
			Shop = 7,
			GachaBox = 8,
			RarityUp = 9,
			Bingo = 10,
		}

		public class PlateInfo
		{
			public int id; // 0x8
			public int count; // 0xC
		}

		private static List<PlateInfo> m_plateIds = new List<PlateInfo>(8); // 0x8
		private static List<int> m_showedIdList = new List<int>(8); // 0xC

		public static JKNGJFOBADP inventoryUtil { get; set; } // 0x0
		public static bool IsResultConfirm { get; set; } // 0x4
		public static int SceneCardCount { get; set; } // 0x10

		// RVA: 0xCF7D0C Offset: 0xCF7D0C VA: 0xCF7D0C
		public RecordPlateUtility()
		{
			return;
		}
		
		//// RVA: 0xCF8068 Offset: 0xCF8068 VA: 0xCF8068
		private static void RegisterPlateIdInner(int id)
		{
			int cardId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(id);
			if (cardId < 1)
				return;
			PlateInfo info = m_plateIds.Find((PlateInfo _) =>
			{
				//0xCF9494
				return cardId == _.id;
			});
			if (info != null)
			{
				info.count++;
				return;
			}
			info = new PlateInfo();
			info.count = 1;
			info.id = cardId;
			m_plateIds.Add(info);
		}

		//// RVA: 0xCF82E4 Offset: 0xCF82E4 VA: 0xCF82E4
		public static void CheckPlateId(MOLKENLNCPE_DropData.CEFIOPJKEIC item)
		{
			if (item == null)
				return;
			RegisterPlateIdInner(item.KIJAPOFAGPN_ItemId);
		}

		//// RVA: 0xCF8370 Offset: 0xCF8370 VA: 0xCF8370
		//public static bool CheckPlateId(List<MOLKENLNCPE.CEFIOPJKEIC> itemList) { }

		//// RVA: 0xCF860C Offset: 0xCF860C VA: 0xCF860C
		//public static void CheckPlateId(JJPEIELNEJB.JLHHGLANHGE item) { }

		//// RVA: 0xCF86A4 Offset: 0xCF86A4 VA: 0xCF86A4
		//public static void CheckPlateId(ViewOfferGetItem item) { }

		//// RVA: 0xCF8730 Offset: 0xCF8730 VA: 0xCF8730
		//public static bool CheckPlateId(List<ViewOfferGetItem> itemList) { }

		//// RVA: 0xCF8A0C Offset: 0xCF8A0C VA: 0xCF8A0C
		public static void Clear()
		{
			m_plateIds.Clear();
		}

		//// RVA: 0xCF8AC0 Offset: 0xCF8AC0 VA: 0xCF8AC0
		public static void ClearShowedList()
		{
			m_showedIdList.Clear();
		}

		//// RVA: 0xCF8B74 Offset: 0xCF8B74 VA: 0xCF8B74
		public static GONMPHKGKHI_RewardView ViewInitialize(eSceneType sceneType, bool allReceive)
		{
			GONMPHKGKHI_RewardView reward = new GONMPHKGKHI_RewardView();
			TodoLogger.Log(0, "ViewInitialize");
			return reward;
		}

		//// RVA: 0xCF9300 Offset: 0xCF9300 VA: 0xCF9300
		//public static string GetPlateName(int cardId, GONMPHKGKHI.CECMLGBLHHG showType, bool isMulti = False) { }
	}
}
