using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

namespace XeApp.Game.Common
{
	public class PopupButton : ActionButton
	{
		public enum ButtonType
		{
			Positive = 1,
			Other = 2,
			Negative = 3,
			Ability = 4,
			Costume = 5,
			Growth = 6,
			Episode = 7,
			Story = 8,
			Live = 9,
			Hide = 10,
		}

		public enum ButtonLabel
		{
			None = 0,
			UsedItem = 1,
			UsedChargesItem = 2,
			Ok = 3,
			Continue = 4,
			Retire = 5,
			Information = 6,
			Contact = 7,
			CacheClear = 8,
			Close = 9,
			Cancel = 10,
			No = 11,
			Update = 12,
			Release = 13,
			FinalRankings = 14,
			Return = 15,
			ExchangeOffices = 16,
			SkillRelease = 17,
			GrowthConfirm = 18,
			CostumeSelect = 19,
			PlateAllClear = 20,
			Receive = 21,
			BugReport = 22,
			Review = 23,
			Change = 24,
			NotCoop = 25,
			TakeOver = 26,
			EMailSend = 27,
			PassIssue = 28,
			Readjustment = 29,
			FriendRemove = 30,
			RequestCancel = 31,
			Accept = 32,
			Reject = 33,
			Request = 34,
			Register = 35,
			Mission = 36,
			Reset = 37,
			SpecialPage = 38,
			Skip = 39,
			Next = 40,
			Purchase = 41,
			Retry = 42,
			ReStart = 43,
			Episode = 44,
			Story = 45,
			Live = 46,
			Agree = 47,
			Disagree = 48,
			MoveConfirmMode = 49,
			Play = 50,
			Finish = 51,
			RegistSite = 52,
			Challenge = 53,
			Expired = 54,
			FastComp = 55,
			CancelOrders = 56,
			CostumeChange = 57,
			RarityUp = 58,
			PassPurchase = 59,
			CostumeUpgrade = 60,
			Reboot = 61,
			Clear = 62,
			Edit = 63,
			ReturnList = 64,
			LevelUp = 65,
			Exchange = 66,
			Collection = 67,
			Start = 68,
			PlateGrowth = 69,
			GachaPull = 70,
			Check = 71,
			MusicSelect = 72,
			StayPlay = 73,
			ThisMusicPlay = 74,
			Max = 75,
		}

		[SerializeField]
		private RawImageEx[] m_labelView; // 0x80
		private const string uvBaseUvName = "cmn_pop01_fnt_01";
		private PopupButton.ButtonLabel m_buttonLabel; // 0x84
		private PopupButton.ButtonType m_buttonType; // 0x88
		private TexUVListManager m_uvManager; // 0x90
		private TexUVList m_texUvList; // 0x94
		private WaitForEndOfFrame m_waitYieldInstruction = new WaitForEndOfFrame(); // 0x98
		private static StringBuilder s_stringBuilder = new StringBuilder(64); // 0x0

		// public PopupButton.ButtonLabel Label { get; } 0xAF88F8
		// public PopupButton.ButtonType Type { get; } 0xAF8900
		public bool IsReady { get; set; } // 0x8C

		// RVA: 0xAF8918 Offset: 0xAF8918 VA: 0xAF8918 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			UnityEngine.Debug.LogError("TODO Implement init PopupButton");
			return true;
		}

		// // RVA: 0xAF89BC Offset: 0xAF89BC VA: 0xAF89BC
		// public void SetLabel(MonoBehaviour mb, PopupButton.ButtonLabel label, PopupButton.ButtonType type = 1) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73E874 Offset: 0x73E874 VA: 0x73E874
		// // RVA: 0xAF8A04 Offset: 0xAF8A04 VA: 0xAF8A04
		// private IEnumerator SetLabelCoroutine(PopupButton.ButtonLabel label, PopupButton.ButtonType type) { }
	}
}
