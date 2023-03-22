
using System;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeSys;

namespace XeApp.Game.Gacha
{
	public class GachaUtility
	{
		public enum CountType
		{
			None = 0,
			Single = 1,
			Multi = 2,
		}

		public enum LotType
		{
			None = 0,
			PaidVC = 1,
			Ticket = 2,
		}

		public enum Timezone
		{
			Morning = 0,
			Noon = 1,
			Night = 2,
		}

		public enum CancelCause
		{
			ClickButton = 0,
			ToPurchase = 1,
			TimeLimit = 2,
		}

		private class IconInfo
		{
			public int ItemId { get; private set; } // 0x8
			public string UvName { get; private set; } // 0xC

			// RVA: 0x999330 Offset: 0x999330 VA: 0x999330
			public IconInfo(int itemId, string uvName)
			{
				ItemId = itemId;
				UvName = uvName;
			}
		}

		private static GCAHJLOGMCI.KNMMOMEHDON m_selectCategory = GCAHJLOGMCI.KNMMOMEHDON.HJNNKCMLGFL; // 0x0
		private static int m_typeAndSeriesId = -1; // 0x4
		private static Action<Action> m_onClickLegalDesc = null; // 0x10
		private static PopPassController m_pop_pass_ctrl = null; // 0x38
		public const int DirectionCardMax = 10;
		// private static DirectionInfo s_directionInfo = null; // 0x3C

		// public static GCAHJLOGMCI.KNMMOMEHDON selectCategory { get; set; } 0x9873E8 0x9902C8
		// public static int typeAndSeriesId { get; set; } 0x990C3C 0x990E78
		public static GachaUtility.LotType selectedLotType { get; private set; } // 0x8
		public static GachaUtility.CountType selectedCountType { get; set; } // 0xC
		private static long currentGachaLimitTime { get; set; } // 0x18
		private static int timezoneMorn { get; set; } // 0x20
		private static int timezoneNoon { get; set; } // 0x24
		private static int timezoneNight { get; set; } // 0x28
		private static int timezoneEnd { get; set; } // 0x2C
		public static GachaUtility.Timezone currentTimezone { get; private set; } // 0x30
		public static bool canLotCurrentTimezone { get; private set; } // 0x34
		// public static bool hasDirectionInfo { get; } 0x995C38
		// public static DirectionInfo directionInfo { get; } 0x989904
		public static GCAHJLOGMCI.NFCAJPIJFAM netGachaCount { get; set; } // 0x40
		public static GCAHJLOGMCI.NFCAJPIJFAM netGachaCountForAppearRate { get; private set; } // 0x44
		private static int netGachaProductIndex { get; set; } // 0x48
		// private static HPBDNNACBAK gpm { get; } 0x990CC8
		// private static CIOECGOMILE pdm { get; } 0x995E58
		// public static List<LOBDIAABMKG> netGachaProducts { get; } 0x995ED4
		// public static LOBDIAABMKG netGachaProductData { get; } 0x9872D8
		// public static KBPDNHOKEKD netGachaSingleProduct { get; } 0x987CB8
		// public static KBPDNHOKEKD netGachaMultiProduct { get; } 0x9881C0
		// public static KBPDNHOKEKD netGachaProduct { get; } 0x995F6C
		// public static int currentHavePaidVC { get; } 0x996010

		// // RVA: 0x990358 Offset: 0x990358 VA: 0x990358
		// public static void UpdateGachaProductCategory() { }

		// // RVA: 0x990F98 Offset: 0x990F98 VA: 0x990F98
		// public static void UpdateCountType(bool isTicket) { }

		// // RVA: 0x9913B8 Offset: 0x9913B8 VA: 0x9913B8
		// public static int GetMenuSinglePrice(GCAHJLOGMCI.KNMMOMEHDON type, GachaUtility.LotType lotType) { }

		// // RVA: 0x99146C Offset: 0x99146C VA: 0x99146C
		// public static int GetMenuMultiPrice(GCAHJLOGMCI.KNMMOMEHDON type, GachaUtility.LotType lotType) { }

		// // RVA: 0x9916F8 Offset: 0x9916F8 VA: 0x9916F8
		// public static int GetMenuSingleLotCount(GCAHJLOGMCI.KNMMOMEHDON type) { }

		// // RVA: 0x9917F0 Offset: 0x9917F0 VA: 0x9917F0
		// public static int GetMenuMultiLotCount(GCAHJLOGMCI.KNMMOMEHDON type, GachaUtility.LotType lotType) { }

		// // RVA: 0x987618 Offset: 0x987618 VA: 0x987618
		// public static int GetMenuPrice(GCAHJLOGMCI.KNMMOMEHDON type, GachaUtility.CountType countType, GachaUtility.LotType lotType) { }

		// // RVA: 0x991A0C Offset: 0x991A0C VA: 0x991A0C
		// public static int GetMenuLotCount(GCAHJLOGMCI.KNMMOMEHDON type, GachaUtility.CountType countType, GachaUtility.LotType lotType) { }

		// // RVA: 0x991AE8 Offset: 0x991AE8 VA: 0x991AE8
		// public static string GetGachaDetailWebViewTemplate() { }

		// // RVA: 0x9855F4 Offset: 0x9855F4 VA: 0x9855F4
		// public static void RegisterLegalDesc(Action<Action> onClickButton) { }

		// // RVA: 0x985C44 Offset: 0x985C44 VA: 0x985C44
		// public static void UnregisterLegalDesc() { }

		// // RVA: 0x991C30 Offset: 0x991C30 VA: 0x991C30
		// private static void OnClickLegalDesc(Action endAction) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C45B8 Offset: 0x6C45B8 VA: 0x6C45B8
		// // RVA: 0x991D2C Offset: 0x991D2C VA: 0x991D2C
		// public static IEnumerator OpenGachaTicketSelectPopupCoroutine(BEPHBEGDFFK view, DenominationManager denomControl, Action onOk, Action<GachaUtility.CancelCause> onCancel, DJBHIFLHJLK onNetError, OnDenomChangeDate onChangeDate) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C4630 Offset: 0x6C4630 VA: 0x6C4630
		// // RVA: 0x98DE00 Offset: 0x98DE00 VA: 0x98DE00
		// public static IEnumerator OpenGachaPopupCoroutine(BEPHBEGDFFK.DMBKENKBIJD selectProductInfo, DenominationManager denomControl, Action onOk, Action<GachaUtility.CancelCause> onCancel, DJBHIFLHJLK onNetError, OnDenomChangeDate onChangeDate) { }

		// // RVA: 0x986F80 Offset: 0x986F80 VA: 0x986F80
		// public static void SetupGachaLimitTime(long unixTime) { }

		// // RVA: 0x992564 Offset: 0x992564 VA: 0x992564
		// private static bool CheckLimitTime() { }

		// // RVA: 0x992A24 Offset: 0x992A24 VA: 0x992A24
		public static void SetupFreeTimezone()
		{
			TodoLogger.Log(0, "SetupFreeTimezone");
		}

		// // RVA: 0x991F98 Offset: 0x991F98 VA: 0x991F98
		public static Timezone GetTimezoneFor(long unixTime)
		{
			TodoLogger.Log(0, "GetTimezoneFor");
			return 0;
		}

		// // RVA: 0x992C04 Offset: 0x992C04 VA: 0x992C04
		// public static string MakeTimezoneDesc() { }

		// // RVA: 0x9930E8 Offset: 0x9930E8 VA: 0x9930E8
		// private static string MakeTime(string fmt, int minutes) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C4788 Offset: 0x6C4788 VA: 0x6C4788
		// // RVA: 0x9931A0 Offset: 0x9931A0 VA: 0x9931A0
		// public static IEnumerator OpenPurchaseVCWindow(DenominationManager denomControl, DJBHIFLHJLK onNetError, OnDenomChangeDate onChangeDate, ProductListFilter filter) { }

		// // RVA: 0x993298 Offset: 0x993298 VA: 0x993298
		// public static void OpenFewVCPopup(Action onClose) { }

		// // RVA: 0x9935E4 Offset: 0x9935E4 VA: 0x9935E4
		// public static void OpenTimeLimitPopup(Action onClose) { }

		// // RVA: 0x993928 Offset: 0x993928 VA: 0x993928
		// public static void InitPurchasePassWindow(Transform transform) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C4800 Offset: 0x6C4800 VA: 0x6C4800
		// // RVA: 0x993AD0 Offset: 0x993AD0 VA: 0x993AD0
		// public static IEnumerator OpenPurchasePassWindow(Transform transform) { }

		// // RVA: 0x993B7C Offset: 0x993B7C VA: 0x993B7C
		// private static PopupSetting MakePopupSettingForPaid(int havePaidVC, int price, int lotCount) { }

		// // RVA: 0x994050 Offset: 0x994050 VA: 0x994050
		// private static PopupSetting MakePopupSettingForFewPaid(int havePaidVC, int price) { }

		// // RVA: 0x994438 Offset: 0x994438 VA: 0x994438
		// private static PopupSetting MakePopupSettingForFree() { }

		// // RVA: 0x994804 Offset: 0x994804 VA: 0x994804
		// private static PopupSetting MakePopupSettingForTicket(string ticketName, int haveTicket, int price, int lotCount) { }

		// // RVA: 0x994D58 Offset: 0x994D58 VA: 0x994D58
		// private static PopupSetting MakePopupSettingForFewBonusTicket(string ticketName, int haveTicket, int price, bool isPeriod) { }

		// // RVA: 0x9951C4 Offset: 0x9951C4 VA: 0x9951C4
		// private static PopupSetting MakePopupSettingForFewPassTicket(string ticketName, int haveTicket, int price, int status) { }

		// // RVA: 0x9956A8 Offset: 0x9956A8 VA: 0x9956A8
		// private static PopupSetting MakePopupSettingForFewLimitedItem(string ticketName, int haveTicket, int price) { }

		// // RVA: 0x994C30 Offset: 0x994C30 VA: 0x994C30
		// private static string MakePopupMessage(string format, string name, int n0, int n1) { }

		// // RVA: 0x993F34 Offset: 0x993F34 VA: 0x993F34
		// private static string MakePopupMessage(string format, int n0, int n1) { }

		// // RVA: 0x99470C Offset: 0x99470C VA: 0x99470C
		// private static string MakePopupMessage(string format, int n0) { }

		// // RVA: 0x98AC48 Offset: 0x98AC48 VA: 0x98AC48
		// public static void Register(List<MFDJIFIIPJD> items) { }

		// // RVA: 0x988F00 Offset: 0x988F00 VA: 0x988F00
		// public static void Unregister() { }

		// // RVA: 0x995CCC Offset: 0x995CCC VA: 0x995CCC
		// public static int GetSeIdForMenuLeaving() { }

		// // RVA: 0x995AA0 Offset: 0x995AA0 VA: 0x995AA0
		// private static int GetDivaIdForCutin() { }

		// // RVA: 0x9960DC Offset: 0x9960DC VA: 0x9960DC
		// public static bool IsNextFree() { }

		// // RVA: 0x9876F8 Offset: 0x9876F8 VA: 0x9876F8
		// public static int GetCurrentHaveTicket() { }

		// // RVA: 0x996178 Offset: 0x996178 VA: 0x996178
		// public static long GetCurrentHaveTicketPeriod() { }

		// // RVA: 0x996394 Offset: 0x996394 VA: 0x996394
		// public static void DrawLot(BEPHBEGDFFK.DMBKENKBIJD selectProductInfo, CDOPFBOHDEF onSuccess, DJBHIFLHJLK onFewVC, DJBHIFLHJLK onNetError) { }

		// // RVA: 0x98DF10 Offset: 0x98DF10 VA: 0x98DF10
		// public static void DrawLotRetry(CDOPFBOHDEF onSuccess, DJBHIFLHJLK onFewVC, DJBHIFLHJLK onNetError) { }

		// // RVA: 0x9965FC Offset: 0x9965FC VA: 0x9965FC
		// public static void ClearNetData() { }

		// // RVA: 0x996690 Offset: 0x996690 VA: 0x996690
		public static BadgeConstant.ID GetFooterMenuBadgeId(ref string badgeText)
		{
			HPBDNNACBAK h = NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI;
			if (h == null)
				return 0;
			h.OKINLIEHCEC();
			h.ANGMDEPOBEE();
			if (h.PFLJNIANOHE)
				return BadgeConstant.ID.Gacha_Update;
			string s = "";
			KBPDNHOKEKD_ProductId.KNEKLJHNHAK v = h.FJICMLBOJCH(out s);
			if (v == 0)
			{
				if (!h.CPGNMGCIIKI())
					return 0;
				SetupFreeTimezone();
				long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				Timezone t = GetTimezoneFor(time);
				if ((int)t < 3)
					return (BadgeConstant.ID)(t + (int)BadgeConstant.ID.Gacha_FreeMorning);
				return 0;
			}
			if(string.IsNullOrEmpty(s))
			{
				switch(v)
				{
					case KBPDNHOKEKD_ProductId.KNEKLJHNHAK.LCLLMJGIMHC/*1*/:
						badgeText = MessageManager.Instance.GetMessage("menu", "badge_label_gacha_oneday");
						break;
					case KBPDNHOKEKD_ProductId.KNEKLJHNHAK.PBEMIDKNPNH/*2*/:
						badgeText = MessageManager.Instance.GetMessage("menu", "badge_label_gacha_firsttime");
						break;
					case KBPDNHOKEKD_ProductId.KNEKLJHNHAK.DKIKNLEDDBK/*3*/:
						return 0;
					case KBPDNHOKEKD_ProductId.KNEKLJHNHAK.AAPLMEGMNJA/*4*/:
						badgeText = MessageManager.Instance.GetMessage("menu", "badge_label_gacha_thistime");
						break;
				}
			}
			else
			{
				badgeText = s;
			}
			return BadgeConstant.ID.Label;
		}

		// // RVA: 0x9969C8 Offset: 0x9969C8 VA: 0x9969C8
		public static long GetGachaProductOpenTime(LOBDIAABMKG product)
		{
			if(product.KACECFNECON != null && product.KACECFNECON.JOFAGCFNKIO != 0)
			{
				return product.KACECFNECON.JOFAGCFNKIO;
			}
			return product.KJBGCLPMLCG_OpenedAt;
		}

		// // RVA: 0x996A48 Offset: 0x996A48 VA: 0x996A48
		// public static long GetGachaProductsLastOpenTime() { }
	}
}
