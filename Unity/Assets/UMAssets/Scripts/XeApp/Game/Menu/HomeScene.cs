using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class HomeScene : TransitionRoot
	{
		private Action m_updater; // 0x48
		private HomeSubMenu m_subMenu; // 0x4C
		private HomeButtonGroup m_buttonGroup; // 0x50
		private HomeEventBanner m_eventBanner; // 0x54
		private HomePickupBanner m_campaignBanner; // 0x58
		private HomeFesBanner m_fesBanner; // 0x5C
		// private HomePickup m_pickupUi; // 0x60
		private HomeBalloonText m_leadBalloon; // 0x64
		private CharTouchHitCheck m_charTouch; // 0x68
		// private CommonDivaBalloon m_divaBalloon; // 0x6C
		private HomeDivaControl m_divaControl; // 0x70
		private MenuDivaTalk m_divaTalk; // 0x74
		private HomePlayRecordBanner m_playRecordBanner; // 0x78
		private bool m_headerUiEnable = true; // 0x7C
		private bool m_sceneUiEnable = true; // 0x7D
		private bool m_footerUiEnable = true; // 0x7E
		private bool m_isSuccessPrepare; // 0x7F
		// private bool m_isARMarkerConvert; // 0x80
		// private bool m_isCheckEventReward; // 0x81
		private bool m_isCheckGachaProductList; // 0x82
		// private bool m_isDisplayingInfo; // 0x83
		// private bool m_saveDataDirty; // 0x84
		private bool m_isWaitIntro; // 0x85
		// private bool m_isAbortIntro; // 0x86
		// private bool m_isDivaCrossFade; // 0x87
		private bool m_isInitIntimacy; // 0x88
		private bool m_isInitRaidLobby; // 0x89
		// private bool m_isStartTutorial; // 0x8A
		private bool m_isUpdateMusicRateRanking; // 0x8B
		private bool m_isHomeShowDiva = true; // 0x8C
		// private bool m_isHiddenUI; // 0x8D
		// private KNKDBNFMAKF m_spEventCtrl; // 0x90
		// private CHHECNJBMLA m_boxGachaEventCtrl; // 0x94
		// private PLADCDJLOBE m_balloonLeadData; // 0x98
		// private SnsScreen m_snsScreen; // 0x9C
		// private GachaScene.GachaArgs m_gachaArgs = new GachaScene.GachaArgs(); // 0xA0
		private HomePickupTextureCahce m_pickupTexCache; // 0xA4
		private HomeBannerTextureCache m_bannerTexCache; // 0xA8
		// private List<JBCAHMMCOKK> m_pickupList = new List<JBCAHMMCOKK>(8); // 0xAC
		// private List<JBCAHMMCOKK> m_pickupBannerList = new List<JBCAHMMCOKK>(8); // 0xB0
		// private List<JBCAHMMCOKK> m_pickupWebViewList = new List<JBCAHMMCOKK>(8); // 0xB4
		// private ONFFFKPFFGI m_richBannerData = new ONFFFKPFFGI(); // 0xB8
		private PopPassController m_pop_pass_ctrl; // 0xBC
		// private Coroutine m_coOpenSnsScreen; // 0xC0
		private int m_eventAdvId; // 0xC4
		// private static int m_introTalkDivaId = 0; // 0x0
		// private static bool m_lastHomeShowDiva = 1; // 0x4
		// private List<Action> NoticeActionList = new List<Action>(); // 0xC8
		// private bool m_pickupToClose; // 0xCC
		// private bool m_pickupToJump; // 0xCD
		// private IntimacyController m_intimacyControl; // 0xD0
		// private Camera m_uiCamera; // 0xD4
		// private List<HomeScene.limitedWarning> m_coLimitedItemList = new List<HomeScene.limitedWarning>(); // 0xD8
		// private List<HomeScene.limitedWarning> m_coCurrencyItemList = new List<HomeScene.limitedWarning>(); // 0xDC

		// private bool isValidBalloonLead { get; } 0x96E6EC

		// RVA: 0x96E6FC Offset: 0x96E6FC VA: 0x96E6FC Slot: 4
		protected override void Awake()
		{
			base.Awake();
			m_updater = this.WaitLoad;
			m_pickupTexCache = new HomePickupTextureCahce();
			m_bannerTexCache = new HomeBannerTextureCache();
			m_divaControl = new HomeDivaControl();
			this.StartCoroutineWatched(Co_Loading());
			if(m_pop_pass_ctrl != null)
				return;
			m_pop_pass_ctrl = gameObject.AddComponent<PopPassController>();
		}

		// RVA: 0x96E918 Offset: 0x96E918 VA: 0x96E918 Slot: 5
		protected override void Start()
		{
			base.Start();
			m_charTouch = new CharTouchHitCheck();
			MenuScene.Instance.UpdateEnterToHomeTime();
		}

		// // RVA: 0x96E9E0 Offset: 0x96E9E0 VA: 0x96E9E0
		private void WaitLoad()
		{
			if(!IsReady)
				return;
			if(RuntimeSettings.CurrentSettings.SLiveViewer)
				m_updater = this.LoadSLive;
			else
				m_updater = this.Idle;
		}

		// // RVA: 0x96EA7C Offset: 0x96EA7C VA: 0x96EA7C
		private void Idle()
		{
			return;
		}

		// // RVA: 0x96EA80 Offset: 0x96EA80 VA: 0x96EA80
		// private void Initialize() { }

		// RVA: 0x9706D4 Offset: 0x9706D4 VA: 0x9706D4
		private void Update()
		{
			m_pickupTexCache.Update();
			m_bannerTexCache.Update();
			if(m_divaTalk != null)
				m_divaTalk.Update();
			m_updater();
		}

		// RVA: 0x970740 Offset: 0x970740 VA: 0x970740 Slot: 16
		protected override void OnPreSetCanvas()
		{
			// MenuScene.Instance.divaManager.transform.Find("DivaCamera").GetComponent<Camera>().enabled = true;
			TodoLogger.Log(0, "diva 3d");
			m_eventAdvId = GetEventAdvId();
			if(CanRareBreakAdv() || m_eventAdvId > 0)
			{
				AutoFadeFlag = false;
			}
			MenuScene.Instance.FooterMenu.MenuBar.SetInterruptEvent((TransitionList.Type type) => {
				//0x13C78E0
				TodoLogger.Log(10, "TODO");
				return false;
			});
			m_isInitRaidLobby = false;
			TodoLogger.Log(5, "Raid");
			/*MenuScene.Instance.LobbyButtonControl.StartCoroutineWatched(MenuScene.Instance.LobbyButtonControl.InitRaidLobby(() => {
				//0x13C790C*/
				m_isInitRaidLobby = true;
			/*}, () => {
				//0x13C7934
				TodoLogger.Log(10, "TODO");
			}));*/
			m_isSuccessPrepare = false;
			NKGJPJPHLIF.HHCJCDFCLOB.LBEHLMLKPDM(() => {
				//0x13C7980
				m_isSuccessPrepare = true;
			}, () => {
				//0x13C79A8
				TodoLogger.Log(10, "TODO");
			});
			TodoLogger.Log(5, "m_balloonLeadData");
			// m_balloonLeadData = PLADCDJLOBE.PLADCDJLOBE();
			// Database.Instance.bonusData.ClearEpisodeBonus();
			m_isUpdateMusicRateRanking = false;
			/*OEGIPPCADNA.HHCJCDFCLOB.MJFKJHJJLMN(0, false, () => {
				//0x13C7A14*/
				m_isUpdateMusicRateRanking = true;
			/*}, () => {
				//0x13C7A3C
				TodoLogger.Log(10, "TODO");
			});*/
			if(!MenuScene.IsAlreadyHome)
			{
				m_isCheckGachaProductList = false;
				NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.LILDGEPCPPG_GetProducList(() => {
					//0x13C7AD0
					TodoLogger.Log(10, "TODO");
					m_isCheckGachaProductList = true;
				}, () => {
					//0x13C7B24
					TodoLogger.Log(10, "TODO");
				}, false, false);
			}
			else
			{
				m_isCheckGachaProductList = true;
			}
			
			if(CGFNKMNBNBN.DGCIHGPOMCI(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime()))
			{
				this.StartCoroutineWatched(Co_ChangeBg());
			}
			TodoLogger.Log(5, "end OnPreSetCanvas");
			// MenuScene.Instance.LobbyButtonControl.Wait();
			// MenuScene.Instance.DenomControl.AddResponseHandler(this.OnChargeMoney);
			// BingoQuestStart();
		}

		// RVA: 0x9717EC Offset: 0x9717EC VA: 0x9717EC Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return m_isInitRaidLobby && m_isUpdateMusicRateRanking && m_isCheckGachaProductList && m_isSuccessPrepare;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E31EC Offset: 0x6E31EC VA: 0x6E31EC
		// // RVA: 0x971570 Offset: 0x971570 VA: 0x971570
		private IEnumerator Co_ChangeBg()
		{
			TodoLogger.Log(5, "Co_ChangeBg");
			yield return null;
		}

		// RVA: 0x971824 Offset: 0x971824 VA: 0x971824 Slot: 18
		protected override void OnPostSetCanvas()
		{
			this.StartCoroutineWatched(Co_OnPostSetCanvas());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E3264 Offset: 0x6E3264 VA: 0x6E3264
		// // RVA: 0x971848 Offset: 0x971848 VA: 0x971848
		private IEnumerator Co_OnPostSetCanvas()
		{
			TodoLogger.Log(0, "Co_OnPostSetCanvas");
			m_isInitIntimacy = true;
			yield return null;
		}

		// RVA: 0x9718D0 Offset: 0x9718D0 VA: 0x9718D0 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			if(m_isHomeShowDiva)
			{
				TodoLogger.Log(0, "3d diva");
				//if(m_divaTalk.IsDownLoading())
				//	return false;
			}
			if(GameManager.Instance.EventBannerTextureCache.IsLoading())
				return false;
			return m_isInitIntimacy;
		}

		// RVA: 0x9719D4 Offset: 0x9719D4 VA: 0x9719D4 Slot: 23
		protected override void OnActivateScene()
		{
			m_footerUiEnable = true;
			m_headerUiEnable = true;
			m_sceneUiEnable = true;
			if(GameManager.Instance.IsTutorial)
				return;
			this.StartCoroutineWatched(Co_SceneIntroduce());
		}

		// RVA: 0x971B2C Offset: 0x971B2C VA: 0x971B2C Slot: 24
		protected override bool IsEndActivateScene()
		{
			return !m_isWaitIntro;
		}

		// RVA: 0x971B40 Offset: 0x971B40 VA: 0x971B40 Slot: 20
		protected override bool OnBgmStart()
		{
			TodoLogger.Log(0, "OnBgmStart");
			//SoundManager.Instance.bgmPlayer.ContinuousPlay(BgmPlayer.MENU_BGM_ID_BASE);
			return true;
		}

		// RVA: 0x972010 Offset: 0x972010 VA: 0x972010 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			TodoLogger.Log(0, "OnStartEnterAnimation");
			// EnterIntimacy();
			// m_eventBanner.Enter();
			// m_campaignBanner.Enter();
			// m_fesBanner.Enter();
			// m_subMenu.Enter();
			// m_buttonGroup.Enter();
			// m_playRecordBanner.Enter();
			// MenuScene.Instance.LobbyButtonControl.Setup(1);
			// MenuScene.Instance.HeaderMenu.SetActive(true);
			// MenuScene.Instance.HeaderMenu.Enter(false);
		}

		// RVA: 0x972284 Offset: 0x972284 VA: 0x972284 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			TodoLogger.Log(0, "IsEndEnterAnimation");
			return true;
			//return !m_eventBanner.IsPlaying() && !m_campaignBanner.IsPlaying() && !m_fesBanner.IsPlaying() && !m_subMenu.IsPlaying() && 
			//	!m_buttonGroup.IsPlaying() && !m_playRecordBanner.IsPlaying() && base.IsEndEnterAnimation();
		}

		// RVA: 0x972398 Offset: 0x972398 VA: 0x972398 Slot: 12
		protected override void OnStartExitAnimation()
		{
			TodoLogger.Log(0, "OnStartExitAnimation");
			// if(m_isHomeShowDiva)
			// {
			// 	TodoLogger.Log(0, "3d diva");
			// }
			// LeaveIntimacy();
			// m_playRecordBanner.Leave();
			// m_eventBanner.Leave();
			// m_campaignBanner.Leave();
			// m_fesBanner.Leave();
			// m_subMenu.Leave();
			// m_buttonGroup.Leave();
			// if(m_leadBalloon.isEntered)
			// {
			// 	m_leadBalloon.Leave();
			// }
			// MenuScene.Instance.
		}

		// RVA: 0x97286C Offset: 0x97286C VA: 0x97286C Slot: 13
		protected override bool IsEndExitAnimation()
		{
			TodoLogger.Log(0, "TODO");
			return true;
		}

		// RVA: 0x972A48 Offset: 0x972A48 VA: 0x972A48 Slot: 14
		protected override void OnDestoryScene()
		{
			TodoLogger.Log(0, "TODO");
		}

		// RVA: 0x972E08 Offset: 0x972E08 VA: 0x972E08 Slot: 15
		protected override void OnDeleteCache()
		{
			TodoLogger.Log(0, "TODO");
		}

		// RVA: 0x972FA4 Offset: 0x972FA4 VA: 0x972FA4 Slot: 29
		protected override void InputEnable()
		{
			TodoLogger.Log(0, "HomeScene InputEnable");
		}

		// RVA: 0x972FD8 Offset: 0x972FD8 VA: 0x972FD8 Slot: 30
		protected override void InputDisable()
		{
			TodoLogger.Log(0, "HomeScene InputDisable");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E32DC Offset: 0x6E32DC VA: 0x6E32DC
		// // RVA: 0x96E890 Offset: 0x96E890 VA: 0x96E890
		private IEnumerator Co_Loading()
		{
			//0x13D0F0C
			TodoLogger.Log(0, "TODO");
			IsReady = true;
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E3354 Offset: 0x6E3354 VA: 0x6E3354
		// // RVA: 0x97300C Offset: 0x97300C VA: 0x97300C
		// private IEnumerator Co_LoadLayout() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E33CC Offset: 0x6E33CC VA: 0x6E33CC
		// // RVA: 0x973094 Offset: 0x973094 VA: 0x973094
		// private IEnumerator Co_LoadDivaSerifWindow() { }

		// // RVA: 0x97311C Offset: 0x97311C VA: 0x97311C
		// private void OnNetErrorToTitle() { }

		// // RVA: 0x9731CC Offset: 0x9731CC VA: 0x9731CC
		// private void OnExternalTransition() { }

		// // RVA: 0x9715E0 Offset: 0x9715E0 VA: 0x9715E0
		// private void BingoQuestStart() { }

		// // RVA: 0x9731E0 Offset: 0x9731E0 VA: 0x9731E0
		// private void ShowInformation(bool disableDivaTalk = False) { }

		// // RVA: 0x973484 Offset: 0x973484 VA: 0x973484
		// private void SetInputStatus(bool headerEnable, bool sceneEnable, bool footerEnable) { }

		// // RVA: 0x97371C Offset: 0x97371C VA: 0x97371C
		// private bool TryLobbyAnnounce() { }

		// // RVA: 0x9737E8 Offset: 0x9737E8 VA: 0x9737E8
		// private void OnChargeMoney(DenominationManager.Response handler) { }

		// // RVA: 0x973910 Offset: 0x973910 VA: 0x973910
		// private void OnClickNoticeButton() { }

		// // RVA: 0x9739F0 Offset: 0x9739F0 VA: 0x9739F0
		// private void OnClickPresentButton() { }

		// // RVA: 0x973B04 Offset: 0x973B04 VA: 0x973B04
		// private void OnClickFriendButton() { }

		// // RVA: 0x973C18 Offset: 0x973C18 VA: 0x973C18
		// private void OnClickSnsButton() { }

		// // RVA: 0x973D24 Offset: 0x973D24 VA: 0x973D24
		// private void OnClickEventBannerButton(int eventId) { }

		// // RVA: 0x974F60 Offset: 0x974F60 VA: 0x974F60
		// private void OnClickPlayRecordBannerButton() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E3444 Offset: 0x6E3444 VA: 0x6E3444
		// // RVA: 0x975108 Offset: 0x975108 VA: 0x975108
		// public IEnumerator CO_ExecutePlayRecordFirst() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E34BC Offset: 0x6E34BC VA: 0x6E34BC
		// // RVA: 0x975064 Offset: 0x975064 VA: 0x975064
		// public IEnumerator CO_ExecutePlayRecord(bool a_first) { }

		// // RVA: 0x975190 Offset: 0x975190 VA: 0x975190
		// private void OnClickFesButton() { }

		// // RVA: 0x975768 Offset: 0x975768 VA: 0x975768
		// private void OnClickKujiButton() { }

		// // RVA: 0x975A54 Offset: 0x975A54 VA: 0x975A54
		// private void OnClickHomeBanner(int bannerId) { }

		// // RVA: 0x978424 Offset: 0x978424 VA: 0x978424
		// private void OnClickBeginnerLead() { }

		// // RVA: 0x977868 Offset: 0x977868 VA: 0x977868
		// private void OnClickMissionLead() { }

		// // RVA: 0x978578 Offset: 0x978578 VA: 0x978578
		// private void OnClickStoryLead() { }

		// // RVA: 0x9786B0 Offset: 0x9786B0 VA: 0x9786B0
		// private void OnClickEventLead() { }

		// // RVA: 0x973E84 Offset: 0x973E84 VA: 0x973E84
		// private void GotoCurrentEventScene(int eventUniqueId, OHCAABOMEOF.KGOGMKMBCPP currentEventType, bool isPickup) { }

		// // RVA: 0x977380 Offset: 0x977380 VA: 0x977380
		// private void GotoPurchaseSequence() { }

		// // RVA: 0x977678 Offset: 0x977678 VA: 0x977678
		// private void GotoCurrentRankingEventScene() { }

		// // RVA: 0x977770 Offset: 0x977770 VA: 0x977770
		// private void GotoWeekdayEventScene() { }

		// // RVA: 0x9779BC Offset: 0x9779BC VA: 0x9779BC
		// private void GotoLiveScene() { }

		// // RVA: 0x977A74 Offset: 0x977A74 VA: 0x977A74
		// private void GotoSpPage() { }

		// // RVA: 0x977F7C Offset: 0x977F7C VA: 0x977F7C
		// private void GotoPresentCampaignPage() { }

		// // RVA: 0x9770F4 Offset: 0x9770F4 VA: 0x9770F4
		// private void GotoGachaMainScene(JBCAHMMCOKK.ALEKHDPDOEA transitionId, int typeAndSeriesId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E3534 Offset: 0x6E3534 VA: 0x6E3534
		// // RVA: 0x971AA4 Offset: 0x971AA4 VA: 0x971AA4
		private IEnumerator Co_SceneIntroduce()
		{
			//0x13D2790
			TodoLogger.Log(0, "Co_SceneIntroduce");
			yield return null;
		}

		// // RVA: 0x978C38 Offset: 0x978C38 VA: 0x978C38
		// private void CheckSnsNotice() { }

		// // RVA: 0x978E2C Offset: 0x978E2C VA: 0x978E2C
		// private void CheckOfferNotice() { }

		// // RVA: 0x978F14 Offset: 0x978F14 VA: 0x978F14
		// private void AddNotice(Action action) { }

		// // RVA: 0x978F94 Offset: 0x978F94 VA: 0x978F94
		// private void ShowNotice() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E35AC Offset: 0x6E35AC VA: 0x6E35AC
		// // RVA: 0x978FB8 Offset: 0x978FB8 VA: 0x978FB8
		// private IEnumerator Co_ShowNotice() { }

		// // RVA: 0x979040 Offset: 0x979040 VA: 0x979040
		// private void EnterMessage() { }

		// // RVA: 0x979140 Offset: 0x979140 VA: 0x979140
		// private void ApplyMessageText(string msg) { }

		// // RVA: 0x9727C4 Offset: 0x9727C4 VA: 0x9727C4
		// private void LeaveMessage(bool force = False) { }

		// // RVA: 0x979174 Offset: 0x979174 VA: 0x979174
		// private void OnClickDivaView() { }

		// // RVA: 0x97936C Offset: 0x97936C VA: 0x97936C
		// private void OnClickStoryView() { }

		// // RVA: 0x978124 Offset: 0x978124 VA: 0x978124
		// private void OnClickBingoView(int _bingoId) { }

		// // RVA: 0x978038 Offset: 0x978038 VA: 0x978038
		// private void OnClickPassButton() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E3624 Offset: 0x6E3624 VA: 0x6E3624
		// // RVA: 0x9794C0 Offset: 0x9794C0 VA: 0x9794C0
		// private IEnumerator Co_OpenPassWindow() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E369C Offset: 0x6E369C VA: 0x6E369C
		// // RVA: 0x9792E4 Offset: 0x9792E4 VA: 0x9792E4
		// private IEnumerator Co_WaitIdleCrossFade() { }

		// // RVA: 0x979548 Offset: 0x979548 VA: 0x979548
		// private void OnClickDecoButton() { }

		// // RVA: 0x979E58 Offset: 0x979E58 VA: 0x979E58
		// private void OnChangedDivaTalk(string msgLabel) { }

		// // RVA: 0x979E74 Offset: 0x979E74 VA: 0x979E74
		// private void LoginBonusPopup() { }

		// // RVA: 0x979E78 Offset: 0x979E78 VA: 0x979E78
		// private bool LoginBonusPopupSetting(PopupLoginBonusSetting setting) { }

		// // RVA: 0x97A068 Offset: 0x97A068 VA: 0x97A068
		// private EPLAAEHPCDM GetTotalLoginBonus() { }

		// // RVA: 0x97A284 Offset: 0x97A284 VA: 0x97A284
		// private bool IsExistTotalLoginBonus() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E3714 Offset: 0x6E3714 VA: 0x6E3714
		// // RVA: 0x97A338 Offset: 0x97A338 VA: 0x97A338
		// private IEnumerator Coroutine_LoginBonusPopup() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E378C Offset: 0x6E378C VA: 0x6E378C
		// // RVA: 0x97A3C0 Offset: 0x97A3C0 VA: 0x97A3C0
		// private IEnumerator Co_MonthlyPassLoginBonusPopup() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E3804 Offset: 0x6E3804 VA: 0x6E3804
		// // RVA: 0x97A448 Offset: 0x97A448 VA: 0x97A448
		// private IEnumerator Coroutine_ShowInformation() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E387C Offset: 0x6E387C VA: 0x6E387C
		// // RVA: 0x97A4D0 Offset: 0x97A4D0 VA: 0x97A4D0
		// private IEnumerator Co_HomeMissionAnnounce() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E38F4 Offset: 0x6E38F4 VA: 0x6E38F4
		// // RVA: 0x97A558 Offset: 0x97A558 VA: 0x97A558
		// private IEnumerator Co_ShowRichBanner() { }

		// // RVA: 0x97A5E0 Offset: 0x97A5E0 VA: 0x97A5E0
		// private void OnClickBgViewStart() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E396C Offset: 0x6E396C VA: 0x6E396C
		// // RVA: 0x97A730 Offset: 0x97A730 VA: 0x97A730
		// private IEnumerator Co_ChangePopupLimtiedBg() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E39E4 Offset: 0x6E39E4 VA: 0x6E39E4
		// // RVA: 0x97A7A0 Offset: 0x97A7A0 VA: 0x97A7A0
		// private IEnumerator Co_WaitWhile(Func<bool> condition) { }

		// // RVA: 0x97A828 Offset: 0x97A828 VA: 0x97A828
		// private void OnClickUIHideView(bool hidden) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E3A5C Offset: 0x6E3A5C VA: 0x6E3A5C
		// // RVA: 0x97A8A4 Offset: 0x97A8A4 VA: 0x97A8A4
		// private IEnumerator Co_UIHideAnimation(bool hidden) { }

		// // RVA: 0x97A948 Offset: 0x97A948 VA: 0x97A948
		// private void OnClickPickupClose() { }

		// // RVA: 0x97A9AC Offset: 0x97A9AC VA: 0x97A9AC
		// private void OnClickPickupJump() { }

		// // RVA: 0x97A9B8 Offset: 0x97A9B8 VA: 0x97A9B8
		// private void OnClickRejectCheckbox() { }

		// // RVA: 0x96F7D0 Offset: 0x96F7D0 VA: 0x96F7D0
		// private void SetupPickup() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E3AD4 Offset: 0x6E3AD4 VA: 0x6E3AD4
		// // RVA: 0x97AA10 Offset: 0x97AA10 VA: 0x97AA10
		// private IEnumerator Co_ShowPickup() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E3B4C Offset: 0x6E3B4C VA: 0x6E3B4C
		// // RVA: 0x97AA98 Offset: 0x97AA98 VA: 0x97AA98
		// private IEnumerator Co_ShowPickup(JBCAHMMCOKK pickup) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E3BC4 Offset: 0x6E3BC4 VA: 0x6E3BC4
		// // RVA: 0x97AB3C Offset: 0x97AB3C VA: 0x97AB3C
		// private IEnumerator Co_ShowPickupWebView() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E3C3C Offset: 0x6E3C3C VA: 0x6E3C3C
		// // RVA: 0x97ABC4 Offset: 0x97ABC4 VA: 0x97ABC4
		// private IEnumerator Co_ShowPickupWebView(JBCAHMMCOKK pickup) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E3CB4 Offset: 0x6E3CB4 VA: 0x6E3CB4
		// // RVA: 0x97AC68 Offset: 0x97AC68 VA: 0x97AC68
		// private IEnumerator Co_GetPaidVCProductList() { }

		// // RVA: 0x97ACF0 Offset: 0x97ACF0 VA: 0x97ACF0
		// private static string GetLeadBalloonDesc(PLADCDJLOBE leadData) { }

		// // RVA: 0x96FAF8 Offset: 0x96FAF8 VA: 0x96FAF8
		// private void SetupBeginnerLead() { }

		// // RVA: 0x96FD5C Offset: 0x96FD5C VA: 0x96FD5C
		// private void SetupMissionLead() { }

		// // RVA: 0x96FFC0 Offset: 0x96FFC0 VA: 0x96FFC0
		// private void SetupStoryLead() { }

		// // RVA: 0x970118 Offset: 0x970118 VA: 0x970118
		// private void SetupStoryDivaLead() { }

		// // RVA: 0x970358 Offset: 0x970358 VA: 0x970358
		// private void SetupStorySnsLead() { }

		// // RVA: 0x9704B0 Offset: 0x9704B0 VA: 0x9704B0
		// private void SetupEventHomeLead() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E3D2C Offset: 0x6E3D2C VA: 0x6E3D2C
		// // RVA: 0x97ADFC Offset: 0x97ADFC VA: 0x97ADFC
		// private IEnumerator Co_SnsScreen() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E3DA4 Offset: 0x6E3DA4 VA: 0x6E3DA4
		// // RVA: 0x973C9C Offset: 0x973C9C VA: 0x973C9C
		// private IEnumerator Co_OpenSnsScreen() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E3E1C Offset: 0x6E3E1C VA: 0x6E3E1C
		// // RVA: 0x97AE84 Offset: 0x97AE84 VA: 0x97AE84
		// private IEnumerator Co_ClosingSnsScreen() { }

		// // RVA: 0x97AF0C Offset: 0x97AF0C VA: 0x97AF0C
		// private bool IsCenterKaname() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E3E94 Offset: 0x6E3E94 VA: 0x6E3E94
		// // RVA: 0x97B034 Offset: 0x97B034 VA: 0x97B034
		// private IEnumerator Co_BeginnerMissionMiniAdv() { }

		// // RVA: 0x97B0BC Offset: 0x97B0BC VA: 0x97B0BC
		// private bool CheckTutorialFunc(TutorialConditionId conditionId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E3F0C Offset: 0x6E3F0C VA: 0x6E3F0C
		// // RVA: 0x97B73C Offset: 0x97B73C VA: 0x97B73C
		// private IEnumerator Coroutine_EventReward() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E3F84 Offset: 0x6E3F84 VA: 0x6E3F84
		// // RVA: 0x97B7C4 Offset: 0x97B7C4 VA: 0x97B7C4
		// private IEnumerator Coroutine_ShowUnlock(Action onTransition) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E3FFC Offset: 0x6E3FFC VA: 0x6E3FFC
		// // RVA: 0x97B84C Offset: 0x97B84C VA: 0x97B84C
		// private IEnumerator Co_CheckPlayerForceRename(Action onTransition) { }

		// // RVA: 0x97B8D4 Offset: 0x97B8D4 VA: 0x97B8D4
		// private bool RaidEventApHeal() { }

		// // RVA: 0x971360 Offset: 0x971360 VA: 0x971360
		private bool CanRareBreakAdv()
		{
			TodoLogger.Log(0, "CanRareBreakAdv");
			return false;
		}

		// // RVA: 0x97BC14 Offset: 0x97BC14 VA: 0x97BC14
		// private int GetRareBreakAdvId() { }

		// // RVA: 0x97155C Offset: 0x97155C VA: 0x97155C
		// private bool CanGetEventAdv() { }

		// // RVA: 0x970F60 Offset: 0x970F60 VA: 0x970F60
		private int GetEventAdvId()
		{
			TodoLogger.Log(0, "GetEventAdvId");
			return 0;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E4074 Offset: 0x6E4074 VA: 0x6E4074
		// // RVA: 0x97BD8C Offset: 0x97BD8C VA: 0x97BD8C
		// private IEnumerator Co_InitIntimacy() { }

		// // RVA: 0x972210 Offset: 0x972210 VA: 0x972210
		// private void EnterIntimacy() { }

		// // RVA: 0x97BE14 Offset: 0x97BE14 VA: 0x97BE14
		// private void EnterIntimacy(float animTime) { }

		// // RVA: 0x9727F8 Offset: 0x9727F8 VA: 0x9727F8
		// private void LeaveIntimacy() { }

		// // RVA: 0x97BE94 Offset: 0x97BE94 VA: 0x97BE94
		// private void LeaveIntimacy(float animTime) { }

		// // RVA: 0x97BF14 Offset: 0x97BF14 VA: 0x97BF14
		// private void StartIntimacyUp(CharTouchButton button) { }

		// // RVA: 0x97C180 Offset: 0x97C180 VA: 0x97C180
		// private bool ContinueConfirm(CharTouchButton button) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E40EC Offset: 0x6E40EC VA: 0x6E40EC
		// // RVA: 0x97C348 Offset: 0x97C348 VA: 0x97C348
		// private IEnumerator Co_LimitedItemWarning() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E4164 Offset: 0x6E4164 VA: 0x6E4164
		// // RVA: 0x97C3D0 Offset: 0x97C3D0 VA: 0x97C3D0
		// private IEnumerator Co_RareupStarLimitPopup(int itemId, int itemCount, long currentTime, long period) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E41DC Offset: 0x6E41DC VA: 0x6E41DC
		// // RVA: 0x97C4A8 Offset: 0x97C4A8 VA: 0x97C4A8
		// private IEnumerator Co_LimitedItemPeriodPopup(int itemId, int itemCount, long currentTime, long period) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E4254 Offset: 0x6E4254 VA: 0x6E4254
		// // RVA: 0x97C57C Offset: 0x97C57C VA: 0x97C57C
		// private IEnumerator Co_LimitedItemGachaProductPeriodPopup(int itemId, int itemCount, long currentTime, long period) { }

		// // RVA: 0x97C684 Offset: 0x97C684 VA: 0x97C684
		// public bool IsShowLimitedPopup(long currentTime, OKGLGHCBCJP md, long localSaveTime, long experioAt, int rangeTime, out TimeSpan limited_data_span) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E42CC Offset: 0x6E42CC VA: 0x6E42CC
		// // RVA: 0x97C8C4 Offset: 0x97C8C4 VA: 0x97C8C4
		// private IEnumerator ShowLimitedItemPopup(int itemId, int itemCount, int period, TimeSpan limitedSpan, Action close) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E4344 Offset: 0x6E4344 VA: 0x6E4344
		// // RVA: 0x97C9E0 Offset: 0x97C9E0 VA: 0x97C9E0
		// private IEnumerator Co_CurrencyItemWarning() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E43BC Offset: 0x6E43BC VA: 0x6E43BC
		// // RVA: 0x97CA68 Offset: 0x97CA68 VA: 0x97CA68
		// private IEnumerator Co_CurrencyItemPeriodPopup(int currencyId, int count, long currentTime, long period) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E4434 Offset: 0x6E4434 VA: 0x6E4434
		// // RVA: 0x97CB70 Offset: 0x97CB70 VA: 0x97CB70
		// private IEnumerator Co_CurrencyItemGachaProductPeriodPopup(int currencyId, int count, long currentTime, long period) { }

		// 	[CompilerGeneratedAttribute] // RVA: 0x6E44AC Offset: 0x6E44AC VA: 0x6E44AC
		// 	// RVA: 0x97CE94 Offset: 0x97CE94 VA: 0x97CE94
		// 	private void <Co_OnPostSetCanvas>b__59_0() { }

		// 	[CompilerGeneratedAttribute] // RVA: 0x6E44BC Offset: 0x6E44BC VA: 0x6E44BC
		// 	// RVA: 0x97CEE8 Offset: 0x97CEE8 VA: 0x97CEE8
		// 	private void <Co_OnPostSetCanvas>b__59_1(CharTouchButton button) { }

		// 	[CompilerGeneratedAttribute] // RVA: 0x6E44CC Offset: 0x6E44CC VA: 0x6E44CC
		// 	// RVA: 0x97CEF8 Offset: 0x97CEF8 VA: 0x97CEF8
		// 	private void <Co_OnPostSetCanvas>b__59_2() { }

		// 	[CompilerGeneratedAttribute] // RVA: 0x6E44DC Offset: 0x6E44DC VA: 0x6E44DC
		// 	// RVA: 0x97D0E8 Offset: 0x97D0E8 VA: 0x97D0E8
		// 	private void <Co_OnPostSetCanvas>b__59_3() { }

		// 	[CompilerGeneratedAttribute] // RVA: 0x6E44EC Offset: 0x6E44EC VA: 0x6E44EC
		// 	// RVA: 0x97D120 Offset: 0x97D120 VA: 0x97D120
		// 	private void <Co_LoadDivaSerifWindow>b__74_0(GameObject instance) { }

		// 	[CompilerGeneratedAttribute] // RVA: 0x6E44FC Offset: 0x6E44FC VA: 0x6E44FC
		// 	// RVA: 0x97D1F4 Offset: 0x97D1F4 VA: 0x97D1F4
		// 	private void <CheckSnsNotice>b__106_0() { }

		// 	[CompilerGeneratedAttribute] // RVA: 0x6E450C Offset: 0x6E450C VA: 0x6E450C
		// 	// RVA: 0x97D218 Offset: 0x97D218 VA: 0x97D218
		// 	private void <OnClickDecoButton>b__121_0(PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }

		// 	[CompilerGeneratedAttribute] // RVA: 0x6E451C Offset: 0x6E451C VA: 0x6E451C
		// 	// RVA: 0x97D2E4 Offset: 0x97D2E4 VA: 0x97D2E4
		// 	private void <Co_MonthlyPassLoginBonusPopup>b__128_0(bool received) { }

		// 	[CompilerGeneratedAttribute] // RVA: 0x6E452C Offset: 0x6E452C VA: 0x6E452C
		// 	// RVA: 0x97D318 Offset: 0x97D318 VA: 0x97D318
		// 	private void <SetupBeginnerLead>b__149_0(IiconTexture image) { }

		// 	[CompilerGeneratedAttribute] // RVA: 0x6E453C Offset: 0x6E453C VA: 0x6E453C
		// 	// RVA: 0x97D348 Offset: 0x97D348 VA: 0x97D348
		// 	private void <SetupMissionLead>b__150_0(IiconTexture image) { }

		// 	[CompilerGeneratedAttribute] // RVA: 0x6E454C Offset: 0x6E454C VA: 0x6E454C
		// 	// RVA: 0x97D378 Offset: 0x97D378 VA: 0x97D378
		// 	private void <SetupStoryDivaLead>b__152_0(IiconTexture image) { }

		// 	[CompilerGeneratedAttribute] // RVA: 0x6E455C Offset: 0x6E455C VA: 0x6E455C
		// 	// RVA: 0x97D38C Offset: 0x97D38C VA: 0x97D38C
		// 	private void <SetupEventHomeLead>b__154_0(IiconTexture image) { }

		// 	[CompilerGeneratedAttribute] // RVA: 0x6E456C Offset: 0x6E456C VA: 0x6E456C
		// 	// RVA: 0x97D3BC Offset: 0x97D3BC VA: 0x97D3BC
		// 	private void <Co_OpenSnsScreen>b__156_0() { }

		// 	[CompilerGeneratedAttribute] // RVA: 0x6E457C Offset: 0x6E457C VA: 0x6E457C
		// 	// RVA: 0x97D3E0 Offset: 0x97D3E0 VA: 0x97D3E0
		// 	private bool <Co_InitIntimacy>b__171_0() { }

		private void LoadSLive()
		{
			this.StartCoroutineWatched(LoadSLiveCoroutine());
			m_updater = this.LoadSLiveWait;
		}

		private void LoadSLiveWait()
		{

		}

		private IEnumerator LoadSLiveCoroutine()
		{
			UnityEngine.Debug.Log("Generate Next Song");

			// select a song
			var freemusics = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas;
			int freemusicNum = 0;
			do
			{
				freemusicNum = UnityEngine.Random.Range(0, freemusics.Count);
			} while(freemusics[freemusicNum].PPEGAKEIEGM_Enabled != 2);
			UnityEngine.Debug.Log("Select Free Music : "+(freemusicNum + 1));

			int musicId = freemusics[freemusicNum].DLAEJOBELBH_MusicId;
			UnityEngine.Debug.Log("Music Id : "+musicId);
			var musicInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.EPMMNEFADAP_Musics[musicId - 1];
			UnityEngine.Debug.Log("Wav Id : "+musicInfo.KKPAHLMJKIH_WavId);

			EEDKAACNBBG_MusicData song = new EEDKAACNBBG_MusicData();
			song.KHEKNNFCAOI(musicInfo.DLAEJOBELBH_Id);
			UnityEngine.Debug.Log("Music Name : "+song.NEDBBJDAFBH_MusicName);

			// select num diva
			int numDiva = 1;
			if(musicInfo.NJAOOMHCIHL_DivaSolo != 0 && musicInfo.PECMGDOMLAF_DivaMulti == 0)
				numDiva = 1;
			else if(musicInfo.NJAOOMHCIHL_DivaSolo == 0 && musicInfo.PECMGDOMLAF_DivaMulti != 0)
				numDiva = musicInfo.PECMGDOMLAF_DivaMulti;
			else
				numDiva = UnityEngine.Random.Range(0, 2) == 0 ? 1 : musicInfo.PECMGDOMLAF_DivaMulti;
			UnityEngine.Debug.Log("Select NumDiva : "+numDiva);

			// load music 
			string waveName = GameManager.Instance.GetWavDirectoryName(musicInfo.KKPAHLMJKIH_WavId, "mc/{0}/sc.xab", numDiva, 1, -1, true);
			StringBuilder bundleName = new StringBuilder();
			StringBuilder assetName = new StringBuilder();
			bundleName.SetFormat("mc/{0}/sc.xab", waveName);
			assetName.SetFormat("p_{0:D4}", musicInfo.KKPAHLMJKIH_WavId);
			var operation = AssetBundleManager.LoadAssetAsync(bundleName.ToString(), assetName.ToString(), typeof(MusicDirectionParamBase));
			yield return Co.R(operation);

			Database.Instance.gameSetup.teamInfo.valkyrieId = 0;
			Database.Instance.gameSetup.teamInfo.prismValkyrieId = 0;
			Database.Instance.gameSetup.musicInfo.SetupInfoByFreeMusic(freemusicNum + 1, (Difficulty.Type) UnityEngine.Random.Range(0, (int)Difficulty.Type.Num)/*difficulty*/, false, new GameSetupData.MusicInfo.InitFreeMusicParam(), OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL, OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL, OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL, true, UnityEngine.Random.Range(0, 2) != 0, "", 0, 0, -1, 0, 0, numDiva);
			GameSetupData.TeamInfo team = Database.Instance.gameSetup.teamInfo;
			for(int i = 0; i < 5; i++)
			{
				team.danceDivaList[i].divaId = 0;
				team.danceDivaList[i].prismDivaId = 0;
				team.danceDivaList[i].costumeModelId = 0;
				team.danceDivaList[i].prismCostumeModelId = 0;
				team.danceDivaList[i].costumeColorId = 0;
				team.danceDivaList[i].prismCostumeColorId = 0;
				team.danceDivaList[i].positionId = i+1;
			}

			List<int> excludedDiva = new List<int>();
			Dictionary<int, int> excludedDivaPos = new Dictionary<int, int>();
			List<int> excludedCostume = new List<int>();
			Dictionary<int, int> excludedCostumePos = new Dictionary<int, int>();


			// 10% chance to launch a completely random setup
			if(UnityEngine.Random.Range(0, 100) > 10)
			{

				// Get a random setup
				MusicDirectionParamBase param = operation.GetAsset<MusicDirectionParamBase>();
				List<MusicDirectionParamBase.SpecialDirectionData> randomData = param.GetRandomSetup();

				// Fill diva list
				UnityEngine.Debug.Log("Using Random Param : ");
				for (int i = 0; i < randomData.Count; i++)
				{
					UnityEngine.Debug.Log("Diva Id : "+randomData[i].divaId +
											" - Costume Id : "+randomData[i].costumeModelId +
											" - Positon Id : "+randomData[i].positionId +
											" - Valkyrie Id : "+randomData[i].valkyrieId +
											" - Pilot Id : "+randomData[i].pilotId +
											" - DirectionGroup Id : "+randomData[i].directionGroupId);
				}

				// First setup position locked diva
				for (int i = 0; i < randomData.Count; i++)
				{
					if(randomData[i].positionId > 0)
					{
						if(randomData[i].divaId > 0 && randomData[i].costumeModelId >= 0)
						{
							if(team.danceDivaList[randomData[i].positionId - 1].divaId == 0)
							{
								team.danceDivaList[randomData[i].positionId - 1].divaId = randomData[i].divaId;
								team.danceDivaList[randomData[i].positionId - 1].costumeModelId = randomData[i].costumeModelId;
								UnityEngine.Debug.Log("Setting Diva "+randomData[i].divaId+" in forced position "+randomData[i].positionId);
								UnityEngine.Debug.Log("Setting Costume "+randomData[i].costumeModelId+" in forced position "+randomData[i].positionId);
								excludedDiva.Add(randomData[i].divaId);
							}
						}
						if(randomData[i].divaId < 0)
						{
							excludedDivaPos.Add(Mathf.Abs(randomData[i].divaId), randomData[i].positionId);
							UnityEngine.Debug.Log("Exclude diva "+randomData[i].divaId+" from position "+randomData[i].positionId);
						}
						if(randomData[i].costumeModelId < 0)
						{
							excludedCostumePos.Add(Mathf.Abs(randomData[i].divaId) * 1000 + Mathf.Abs(randomData[i].costumeModelId), randomData[i].positionId);
							UnityEngine.Debug.Log("Exclude costume "+randomData[i].costumeModelId+" from position "+randomData[i].positionId);
						}
					}
				}

				// Fill with other non positioned diva
				for (int i = 0; i < randomData.Count; i++)
				{
					if(randomData[i].positionId == 0)
					{
						if(randomData[i].divaId > 0 && randomData[i].costumeModelId >= 0)
						{
							if(team.danceDivaList[i].divaId == 0)
							{
								team.danceDivaList[i].divaId = randomData[i].divaId;
								team.danceDivaList[i].costumeModelId = randomData[i].costumeModelId;
								UnityEngine.Debug.Log("Setting Diva "+randomData[i].divaId+" in position "+(i+1));
								UnityEngine.Debug.Log("Setting Costume "+randomData[i].costumeModelId+" in position "+(i+1));
								excludedDiva.Add(randomData[i].divaId);
							}
						}
						if(randomData[i].divaId < 0)
						{
							excludedDiva.Add(Mathf.Abs(randomData[i].divaId));
							UnityEngine.Debug.Log("Exclude diva "+randomData[i].divaId);
						}
						if(randomData[i].costumeModelId < 0)
						{
							excludedCostume.Add(Mathf.Abs(randomData[i].divaId) * 1000 + Mathf.Abs(randomData[i].costumeModelId));
							UnityEngine.Debug.Log("Exclude costume "+randomData[i].costumeModelId);
						}
					}
					if(randomData[i].valkyrieId != 0)
					{
						Database.Instance.gameSetup.teamInfo.prismValkyrieId = randomData[i].valkyrieId;
						UnityEngine.Debug.Log("Set valkyrie Id "+randomData[i].valkyrieId);
					}
				}
			}

			// Fill with other diva / costume
			for(int i = 0; i < numDiva; i++)
			{
				if(team.danceDivaList[i].divaId == 0)
				{
					do
					{
						team.danceDivaList[i].divaId = UnityEngine.Random.Range(1, 11);
					} while(excludedDiva.Contains(team.danceDivaList[i].divaId)
						|| (excludedDivaPos.ContainsKey(team.danceDivaList[i].divaId) && 
							excludedDivaPos[team.danceDivaList[i].divaId] == i + 1));
					UnityEngine.Debug.Log("Fill with Diva "+team.danceDivaList[i].divaId+" in position "+(i+1));
					excludedDiva.Add(team.danceDivaList[i].divaId);
				}
				if(team.danceDivaList[i].costumeModelId == 0)
				{
                    LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cosInfo = null;
					do
					{
						team.danceDivaList[i].costumeModelId = UnityEngine.Random.Range(1, 50);
						cosInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.NLIBHNJNJAN_GetUnlockedCostumeOrDefault(team.danceDivaList[i].divaId, team.danceDivaList[i].costumeModelId);
					} while(cosInfo.DAJGPBLEEOB_PrismCostumeModelId != team.danceDivaList[i].costumeModelId || 
						excludedCostume.Contains(team.danceDivaList[i].divaId * 1000 + team.danceDivaList[i].costumeModelId)
						|| (excludedCostumePos.ContainsKey(team.danceDivaList[i].divaId * 1000 + team.danceDivaList[i].costumeModelId) && 
							excludedCostumePos[team.danceDivaList[i].divaId * 1000 + team.danceDivaList[i].costumeModelId] == i + 1));
					UnityEngine.Debug.Log("Fill with Costume "+team.danceDivaList[i].costumeModelId+" in position "+(i+1));
				}
			}
			for(int i = 0; i < 5; i++)
			{
				team.danceDivaList[i].prismDivaId = team.danceDivaList[i].divaId;
				team.danceDivaList[i].prismCostumeModelId = team.danceDivaList[i].costumeModelId;
				team.danceDivaList[i].prismCostumeColorId = team.danceDivaList[i].costumeColorId;
			}
			if(team.prismValkyrieId == 0)
			{
				do
				{
					team.prismValkyrieId = UnityEngine.Random.Range(0, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_ValkyrieList.Count) + 1;
				} while(!IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.PILGJJCABME_IsValkyrieAvaiable(team.prismValkyrieId));
				UnityEngine.Debug.Log("Fill with Valkyrie "+team.prismValkyrieId);
			}
			team.valkyrieId = team.prismValkyrieId;

			Database.Instance.gameSetup.mvInfo.isShowNotes = true;
			Database.Instance.gameSetup.mvInfo.isModeDiva = true;
			Database.Instance.gameSetup.mvInfo.isModeValkyrie = true;
			Database.Instance.gameSetup.ForcePrismSetting();

			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), true);

			StatusData data = new StatusData();
			data.fold = 900;
			data.life = 500;
			data.soul = 30000;
			data.vocal = 15000;
			data.charm = 5000;
			data.support = 900;
			Database.Instance.gameSetup.teamInfo.teamStatus = new StatusData();
			Database.Instance.gameSetup.teamInfo.teamStatus.Copy(data);

			//TodoLogger.MinLog = 99;
			// setup and launch
			MenuScene.Instance.GotoRhythmGame(false, 0, false);

		}
	}
}
