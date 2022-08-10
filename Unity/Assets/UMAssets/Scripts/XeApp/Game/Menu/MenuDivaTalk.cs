namespace XeApp.Game.Menu
{
	public class MenuDivaTalk
	{
		// private static readonly float s_autoTalkInterval = 10.0f; // 0x0
		// private static readonly int s_autoTalkBasicWeight = 10; // 0x4
		// private static readonly int s_autoTalkLimitedWeight = s_autoTalkBasicWeight; // 0x8
		// private static readonly int s_autoTalkBirthdayWeight = s_autoTalkBasicWeight; // 0xC
		// private List<NJOOMLFFIJB> m_limitedTalkData; // 0x10
		// private List<int> m_limitedTalkIndex; // 0x14
		// private NJOOMLFFIJB m_birthdayTalkData; // 0x18
		// private int m_birthdayTalkIndex; // 0x1C
		// private int m_prevAutoTalkIndex; // 0x20
		// private List<int> m_autoTalkWeights; // 0x24
		// private Stopwatch m_autoTalkWatch; // 0x28
		// private int m_prevReactionIndex; // 0x2C
		// private List<int> m_reactionWeights; // 0x30
		// private long m_loginTime; // 0x38
		// private HomeDivaControl m_divaControl; // 0x40

		// public JJOELIOGMKK viewIntimacyData { private get; set; }  // 0x8
		// public MenuDivaTalk.OnChangedMessage onChangedMessage { private get; set; } // 0xC
		// private MenuDivaManager divaManager { get; } 0xECD720
		// private ILDKBCLAFPB saveManager { get; } 0xECD7BC
		// private ILDKBCLAFPB.BKLCILHFCGB talkFlags { get; } 0xECD858

		// RVA: 0xECD8B4 Offset: 0xECD8B4 VA: 0xECD8B4
		// public static void ClearHomeTalkFlags() { }

		// // RVA: 0xECD9B8 Offset: 0xECD9B8 VA: 0xECD9B8
		// public void .ctor(int divaId, HomeDivaControl divaControl) { }

		// // RVA: 0xECE0C4 Offset: 0xECE0C4 VA: 0xECE0C4
		// public void TimerStart() { }

		// // RVA: 0xECE098 Offset: 0xECE098 VA: 0xECE098
		// public void TimerStop() { }

		// // RVA: 0xECE0F0 Offset: 0xECE0F0 VA: 0xECE0F0
		// public void TimerRestart() { }

		// // RVA: 0xECE140 Offset: 0xECE140 VA: 0xECE140
		// public bool IsTimerRunning() { }

		// // RVA: 0xECE16C Offset: 0xECE16C VA: 0xECE16C
		// public void SetLoginTime(long unixtime) { }

		// // RVA: 0xECE17C Offset: 0xECE17C VA: 0xECE17C
		// public bool IsDownLoading() { }

		// // RVA: 0xECE218 Offset: 0xECE218 VA: 0xECE218
		// public void RequestDelayDownLoad() { }

		// // RVA: 0xECE310 Offset: 0xECE310 VA: 0xECE310
		// public void DoIntroTalk(bool resetTalkFlags = False) { }

		// // RVA: 0xECEF14 Offset: 0xECEF14 VA: 0xECEF14
		// public bool IsEnableReaction() { }

		// // RVA: 0xECEF3C Offset: 0xECEF3C VA: 0xECEF3C
		// public int RandomTouchReactionIndex() { }

		// // RVA: 0xECF3C4 Offset: 0xECF3C4 VA: 0xECF3C4
		// public void DoTouchReaction() { }

		// // RVA: 0xECF740 Offset: 0xECF740 VA: 0xECF740
		// public void DoPresentReaction(int a_idnex = -1, MenuDivaTalk.OnChangedMessage a_callback_msg) { }

		// // RVA: 0xECF84C Offset: 0xECF84C VA: 0xECF84C
		// public void DoIntimacyReaction(MenuDivaTalk.OnChangedMessage a_callback_msg) { }

		// // RVA: 0xECF978 Offset: 0xECF978 VA: 0xECF978
		// public void CancelRequest() { }

		// // RVA: 0xECF9A4 Offset: 0xECF9A4 VA: 0xECF9A4
		public void Update()
		{
			TodoLogger.Log(5, "MenuDivaTalk Update");
		}

		// // RVA: 0xECEBE4 Offset: 0xECEBE4 VA: 0xECEBE4
		// private void DoAutoTalk() { }

		// // RVA: 0xECE9F8 Offset: 0xECE9F8 VA: 0xECE9F8
		// private void RequestTimezoneTalk() { }

		// // RVA: 0xECFC70 Offset: 0xECFC70 VA: 0xECFC70
		// private void RequestComebackTalk() { }

		// // RVA: 0xECE7B4 Offset: 0xECE7B4 VA: 0xECE7B4
		// private void RequestLimitedTalk(int index) { }

		// // RVA: 0xECE5C4 Offset: 0xECE5C4 VA: 0xECE5C4
		// private void RequestBirthdayTalk() { }

		// // RVA: 0xECFB84 Offset: 0xECFB84 VA: 0xECFB84
		// private void RequestAutoTalk(int talkType) { }

		// // RVA: 0xECFD44 Offset: 0xECFD44 VA: 0xECFD44
		// private void OnTalkActionEnd() { }

		// // RVA: 0xECFD48 Offset: 0xECFD48 VA: 0xECFD48
		// private bool CheckComebackTalk(DateTime loginDate, DateTime lastLoginDate) { }

		// // RVA: 0xECE538 Offset: 0xECE538 VA: 0xECE538
		// public bool CheckBirthdayTalk(bool checkOnly = True) { }

		// // RVA: 0xECE6C0 Offset: 0xECE6C0 VA: 0xECE6C0
		// public bool CheckLimitedTalk(bool checkOnly = True) { }

		// // RVA: 0xECF6E0 Offset: 0xECF6E0 VA: 0xECF6E0
		// private void DivaTalk(string label, MenuDivaTalk.OnChangedMessage a_callback) { }

		// // RVA: 0xECF644 Offset: 0xECF644 VA: 0xECF644
		// private void DivaTalk(string labelFormat, int index, MenuDivaTalk.OnChangedMessage a_callback) { }
	}
}
