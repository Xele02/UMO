using System;

namespace XeApp.Game.Menu
{
	public class DecoChatScene : TransitionRoot
	{
		private LobbyScrollListWindow m_windowUi; // 0x48
		private LobbyFooter m_lobbyFooter; // 0x4C
		private LobbyStampMakerButton m_stampMakerButton; // 0x50
		private LobbyStampWindow m_stampWindow; // 0x54
		private Action m_updater; // 0x58
		private OKLFOAPMJAA m_chatContller; // 0x5C
		private int m_ChatPlayerId; // 0x60
		private int m_myPlayerId; // 0x64
		private bool IsInitilaized; // 0x68
		private bool m_isChange; // 0x69
		private int m_commentCount; // 0x6C
		private string m_messgeText = ""; // 0x70
		private bool m_IsSendBtnPossible; // 0x74
		private bool IsRequestNextList; // 0x75
		private long preTime; // 0x78
		private bool m_IsUpdateError; // 0x80
		private bool IsTryProfile; // 0x81
		private bool IsRequestGotoTitle; // 0x82
		private bool IsAfterAutoUpdateAct; // 0x83
		private bool IsTapGuardON; // 0x84
		private bool IsTapGuardOFF; // 0x85

		// RVA: 0xC5254C Offset: 0xC5254C VA: 0xC5254C
		private void Awake()
		{
			IsReady = true;
		}

		// RVA: 0xC52558 Offset: 0xC52558 VA: 0xC52558
		public void Update()
		{
			if (m_updater != null && !IsRequestGotoTitle)
				m_updater();
			if(IsTapGuardON)
			{
				IsTapGuardON = false;
				MenuScene.Instance.InputDisable();
				if (m_windowUi != null)
					m_windowUi.LockScroll();
			}
			if (IsTapGuardOFF)
			{
				IsTapGuardOFF = false;
				MenuScene.Instance.InputEnable();
				if (m_windowUi != null)
					m_windowUi.UnLockScroll();
			}

		}

		//// RVA: 0xC52768 Offset: 0xC52768 VA: 0xC52768
		//private void initialize() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6CFF7C Offset: 0x6CFF7C VA: 0x6CFF7C
		//// RVA: 0xC5279C Offset: 0xC5279C VA: 0xC5279C
		//private IEnumerator Co_Initialize() { }

		//// RVA: 0xC52848 Offset: 0xC52848 VA: 0xC52848
		//private void SettingLayout() { }

		// RVA: 0xC52D44 Offset: 0xC52D44 VA: 0xC52D44 Slot: 16
		protected override void OnPreSetCanvas()
		{
			if(Args != null && Args is DecoChatArgs)
			{
				m_ChatPlayerId = (Args as DecoChatArgs).playerId;
			}
			m_myPlayerId = NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId;
			m_chatContller = EBNNKJCEEFN.LIFAAGMJFEB(m_ChatPlayerId);
			IsInitilaized = false;
			IsRequestGotoTitle = false;
			this.StartCoroutineWatched(Co_Initialize());
			IsTryProfile = false;
			base.OnPreSetCanvas();
		}

		// RVA: 0xC52E80 Offset: 0xC52E80 VA: 0xC52E80 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return IsInitilaized;
		}

		// RVA: 0xC52E88 Offset: 0xC52E88 VA: 0xC52E88 Slot: 18
		protected override void OnPostSetCanvas()
		{
			base.OnPostSetCanvas();
		}

		// RVA: 0xC52E90 Offset: 0xC52E90 VA: 0xC52E90 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			return base.IsEndPostSetCanvas();
		}

		// RVA: 0xC52E98 Offset: 0xC52E98 VA: 0xC52E98 Slot: 21
		protected override void OnOpenScene()
		{
			base.OnOpenScene();
			m_updater = UpdateCommentObservation;
			if (m_lobbyFooter != null)
				m_lobbyFooter.Enter(true);
			if (m_stampMakerButton != null)
				m_stampMakerButton.Enter();
		}

		// RVA: 0xC53000 Offset: 0xC53000 VA: 0xC53000 Slot: 12
		protected override void OnStartExitAnimation()
		{
			base.OnStartExitAnimation();
			m_updater = null;
			if (m_lobbyFooter != null)
				m_lobbyFooter.Leave(true);
			if (m_stampMakerButton != null)
				m_stampMakerButton.Leave();
			if (m_stampWindow != null)
				if(m_stampWindow.IsShow)
					m_stampWindow.Leave();
		}

		// RVA: 0xC531C0 Offset: 0xC531C0 VA: 0xC531C0 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			bool res = true;
			if (m_lobbyFooter != null)
				res &= !m_lobbyFooter.IsPlayingChild();
			if (m_stampMakerButton != null)
				res &= !m_stampMakerButton.IsPlaying();
			if (m_stampWindow != null && m_stampWindow.IsShow)
				res &= !m_stampWindow.IsPlayingChild();
			return res;
		}

		// RVA: 0xC53380 Offset: 0xC53380 VA: 0xC53380 Slot: 20
		protected override bool OnBgmStart()
		{
			MenuScene.Instance.GetDefaultBgmId(SceneGroupCategory.LOBBY);
			return true;
		}

		// RVA: 0xC53424 Offset: 0xC53424 VA: 0xC53424 Slot: 14
		protected override void OnDestoryScene()
		{
			base.OnDestoryScene();
			DestroyImmediate(m_windowUi.gameObject);
			m_windowUi = null;
			DestroyImmediate(m_lobbyFooter.gameObject);
			m_lobbyFooter = null;
			DestroyImmediate(m_stampMakerButton.gameObject);
			m_stampMakerButton = null;
			DestroyImmediate(m_stampWindow.gameObject);
			m_stampWindow = null;
		}

		// RVA: 0xC5356C Offset: 0xC5356C VA: 0xC5356C Slot: 15
		protected override void OnDeleteCache()
		{
			base.OnDeleteCache();
		}

		// RVA: 0xC53574 Offset: 0xC53574 VA: 0xC53574 Slot: 29
		protected override void InputEnable()
		{
			base.InputEnable();
			if (InputStateCount > 0)
				return;
			m_lobbyFooter.InputEnable();
		}

		// RVA: 0xC535C0 Offset: 0xC535C0 VA: 0xC535C0 Slot: 30
		protected override void InputDisable()
		{
			base.InputDisable();
			if (InputStateCount < 1)
				return;
			m_lobbyFooter.InputDisable();
		}

		//// RVA: 0xC5360C Offset: 0xC5360C VA: 0xC5360C
		//private void ClickStampEditButton() { }

		//// RVA: 0xC5370C Offset: 0xC5370C VA: 0xC5370C
		//private void OnClickStamp(int stampId, int serifId) { }

		//// RVA: 0xC53850 Offset: 0xC53850 VA: 0xC53850
		//private void OnClickStampButton() { }

		//// RVA: 0xC539E4 Offset: 0xC539E4 VA: 0xC539E4
		//private void OnClickSendButton() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6CFFF4 Offset: 0x6CFFF4 VA: 0x6CFFF4
		//// RVA: 0xC53AC0 Offset: 0xC53AC0 VA: 0xC53AC0
		//private IEnumerator Co_AddMessgeItem() { }

		//// RVA: 0xC53B6C Offset: 0xC53B6C VA: 0xC53B6C
		//private void OnClickIconChangeButton() { }

		//// RVA: 0xC53DB8 Offset: 0xC53DB8 VA: 0xC53DB8
		//private void OnClickBbsUpdateButton() { }

		//// RVA: 0xC53FF0 Offset: 0xC53FF0 VA: 0xC53FF0
		//private void OnClickGotoListTop() { }

		//// RVA: 0xC5408C Offset: 0xC5408C VA: 0xC5408C
		//private void OnClickPlayerIcon(int _playerId) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D006C Offset: 0x6D006C VA: 0x6D006C
		//// RVA: 0xC5411C Offset: 0xC5411C VA: 0xC5411C
		//private IEnumerator Co_OnClickPlayerIcon(int _playerId) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D00E4 Offset: 0x6D00E4 VA: 0x6D00E4
		//// RVA: 0xC53790 Offset: 0xC53790 VA: 0xC53790
		//private IEnumerator Co_AddStampItem(int stampId, int serifId) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D015C Offset: 0x6D015C VA: 0x6D015C
		//// RVA: 0xC54204 Offset: 0xC54204 VA: 0xC54204
		//private IEnumerator Co_NetBbsStampCreate(int stampId, int serifId) { }

		//// RVA: 0xC542E4 Offset: 0xC542E4 VA: 0xC542E4
		//private void UpdateCommentObservation() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D01D4 Offset: 0x6D01D4 VA: 0x6D01D4
		//// RVA: 0xC54704 Offset: 0xC54704 VA: 0xC54704
		//private IEnumerator Co_ReloadComment() { }

		//// RVA: 0xC547B0 Offset: 0xC547B0 VA: 0xC547B0
		//private void UpdateChatComment() { }

		//// RVA: 0xC53C88 Offset: 0xC53C88 VA: 0xC53C88
		//private void CommentDisplayUpdate() { }

		//// RVA: 0xC548E0 Offset: 0xC548E0 VA: 0xC548E0
		//private void NextAddComment(int index) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D024C Offset: 0x6D024C VA: 0x6D024C
		//// RVA: 0xC54A18 Offset: 0xC54A18 VA: 0xC54A18
		//private IEnumerator Co_NetBbsUpdate() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D02C4 Offset: 0x6D02C4 VA: 0x6D02C4
		//// RVA: 0xC54AC4 Offset: 0xC54AC4 VA: 0xC54AC4
		//private IEnumerator Co_NetBbsCreate() { }

		//// RVA: 0xC546A0 Offset: 0xC546A0 VA: 0xC546A0
		//private void GetNextCommentList() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D033C Offset: 0x6D033C VA: 0x6D033C
		//// RVA: 0xC54B70 Offset: 0xC54B70 VA: 0xC54B70
		//private IEnumerator Co_GetNextCommentList() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D03B4 Offset: 0x6D03B4 VA: 0x6D03B4
		//// RVA: 0xC54C1C Offset: 0xC54C1C VA: 0xC54C1C
		//private IEnumerator AllAssetsLoad() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D042C Offset: 0x6D042C VA: 0x6D042C
		//// RVA: 0xC54CC8 Offset: 0xC54CC8 VA: 0xC54CC8
		//private IEnumerator Co_LoadAssetsLayoutScrollWindow(string bundleName, Font font) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D04A4 Offset: 0x6D04A4 VA: 0x6D04A4
		//// RVA: 0xC54DA8 Offset: 0xC54DA8 VA: 0xC54DA8
		//private IEnumerator Co_LoadAssetsLayoutFooter(string bundleName, Font font) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D051C Offset: 0x6D051C VA: 0x6D051C
		//// RVA: 0xC54E88 Offset: 0xC54E88 VA: 0xC54E88
		//private IEnumerator Co_LoadAssetsLayoutStampWindow(string bundleName, Font font) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D0594 Offset: 0x6D0594 VA: 0x6D0594
		//// RVA: 0xC54F68 Offset: 0xC54F68 VA: 0xC54F68
		//private IEnumerator Co_LoadAssetsLayoutStampMakerButton(string bundleName, Font font) { }

		//// RVA: 0xC55048 Offset: 0xC55048 VA: 0xC55048
		//private void TapGuardOn() { }

		//// RVA: 0xC55054 Offset: 0xC55054 VA: 0xC55054
		//private void TapGuardOff() { }

		//// RVA: 0xC55060 Offset: 0xC55060 VA: 0xC55060
		//private void ShowBlackListPopup() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D060C Offset: 0x6D060C VA: 0x6D060C
		//// RVA: 0xC53F48 Offset: 0xC53F48 VA: 0xC53F48
		//private IEnumerator Co_AfterAutoUpdateAct(Action act) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D0684 Offset: 0x6D0684 VA: 0x6D0684
		//// RVA: 0xC553BC Offset: 0xC553BC VA: 0xC553BC
		//private void <SettingLayout>b__25_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D0694 Offset: 0x6D0694 VA: 0x6D0694
		//// RVA: 0xC553E8 Offset: 0xC553E8 VA: 0xC553E8
		//private void <SettingLayout>b__25_1(int stamp, int serif) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D06A4 Offset: 0x6D06A4 VA: 0x6D06A4
		//// RVA: 0xC5541C Offset: 0xC5541C VA: 0xC5541C
		//private void <SettingLayout>b__25_2(string value, bool butEnable) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D06B4 Offset: 0x6D06B4 VA: 0x6D06B4
		//// RVA: 0xC55428 Offset: 0xC55428 VA: 0xC55428
		//private void <UpdateCommentObservation>b__50_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D06C4 Offset: 0x6D06C4 VA: 0x6D06C4
		//// RVA: 0xC554C0 Offset: 0xC554C0 VA: 0xC554C0
		//private void <Co_LoadAssetsLayoutScrollWindow>b__60_0(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D06D4 Offset: 0x6D06D4 VA: 0x6D06D4
		//// RVA: 0xC555FC Offset: 0xC555FC VA: 0xC555FC
		//private void <Co_LoadAssetsLayoutFooter>b__61_0(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D06E4 Offset: 0x6D06E4 VA: 0x6D06E4
		//// RVA: 0xC556CC Offset: 0xC556CC VA: 0xC556CC
		//private void <Co_LoadAssetsLayoutStampWindow>b__62_0(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D06F4 Offset: 0x6D06F4 VA: 0x6D06F4
		//// RVA: 0xC5579C Offset: 0xC5579C VA: 0xC5579C
		//private void <Co_LoadAssetsLayoutStampMakerButton>b__63_0(GameObject instance) { }
	}
}
