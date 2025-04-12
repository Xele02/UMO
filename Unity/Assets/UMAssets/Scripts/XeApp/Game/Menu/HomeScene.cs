using mcrs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Gacha;
using XeApp.Game.Tutorial;
using XeSys;

namespace XeApp.Game.Menu
{
	public class HomeScene : TransitionRoot
	{
		public struct limitedWarning
		{
			public IEnumerator col_action; // 0x0
			public long limit_time; // 0x8

			// RVA: 0x7FC7CC Offset: 0x7FC7CC VA: 0x7FC7CC
			public limitedWarning(IEnumerator _col, long time)
			{
				col_action = _col;
				limit_time = time;
			}
		}

		private Action m_updater; // 0x48
		private HomeSubMenu m_subMenu; // 0x4C
		private HomeButtonGroup m_buttonGroup; // 0x50
		private HomeEventBanner m_eventBanner; // 0x54
		private HomePickupBanner m_campaignBanner; // 0x58
		private HomeFesBanner m_fesBanner; // 0x5C
		private HomePickup m_pickupUi; // 0x60
		private HomeBalloonText m_leadBalloon; // 0x64
		private CharTouchHitCheck m_charTouch; // 0x68
		private CommonDivaBalloon m_divaBalloon; // 0x6C
		private HomeDivaControl m_divaControl; // 0x70
		private MenuDivaTalk m_divaTalk; // 0x74
		private HomePlayRecordBanner m_playRecordBanner; // 0x78
		private bool m_headerUiEnable = true; // 0x7C
		private bool m_sceneUiEnable = true; // 0x7D
		private bool m_footerUiEnable = true; // 0x7E
		private bool m_isSuccessPrepare; // 0x7F
		private bool m_isARMarkerConvert; // 0x80
		private bool m_isCheckEventReward; // 0x81
		private bool m_isCheckGachaProductList; // 0x82
		private bool m_isDisplayingInfo; // 0x83
		private bool m_saveDataDirty; // 0x84
		private bool m_isWaitIntro; // 0x85
		private bool m_isAbortIntro; // 0x86
		private bool m_isDivaCrossFade; // 0x87
		private bool m_isInitIntimacy; // 0x88
		private bool m_isInitRaidLobby; // 0x89
		private bool m_isStartTutorial; // 0x8A
		private bool m_isUpdateMusicRateRanking; // 0x8B
		private bool m_isHomeShowDiva = true; // 0x8C
		private bool m_isHiddenUI; // 0x8D
		private KNKDBNFMAKF_EventSp m_spEventCtrl; // 0x90
		private CHHECNJBMLA_EventBoxGacha m_boxGachaEventCtrl; // 0x94
		private PLADCDJLOBE m_balloonLeadData; // 0x98
		private SnsScreen m_snsScreen; // 0x9C
		private GachaScene.GachaArgs m_gachaArgs = new GachaScene.GachaArgs(); // 0xA0
		private HomePickupTextureCahce m_pickupTexCache; // 0xA4
		private HomeBannerTextureCache m_bannerTexCache; // 0xA8
		private List<JBCAHMMCOKK> m_pickupList = new List<JBCAHMMCOKK>(8); // 0xAC
		private List<JBCAHMMCOKK> m_pickupBannerList = new List<JBCAHMMCOKK>(8); // 0xB0
		private List<JBCAHMMCOKK> m_pickupWebViewList = new List<JBCAHMMCOKK>(8); // 0xB4
		private ONFFFKPFFGI m_richBannerData = new ONFFFKPFFGI(); // 0xB8
		private PopPassController m_pop_pass_ctrl; // 0xBC
		private Coroutine m_coOpenSnsScreen; // 0xC0
		private int m_eventAdvId; // 0xC4
		private static int m_introTalkDivaId = 0; // 0x0
		private static bool m_lastHomeShowDiva = true; // 0x4
		private List<Action> NoticeActionList = new List<Action>(); // 0xC8
		private bool m_pickupToClose; // 0xCC
		private bool m_pickupToJump; // 0xCD
		private IntimacyController m_intimacyControl; // 0xD0
		private Camera m_uiCamera; // 0xD4
		private List<limitedWarning> m_coLimitedItemList = new List<limitedWarning>(); // 0xD8
		private List<limitedWarning> m_coCurrencyItemList = new List<limitedWarning>(); // 0xDC

		private bool isValidBalloonLead { get { return m_balloonLeadData != null; } } //0x96E6EC

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
			m_charTouch = GetComponentInChildren<CharTouchHitCheck>();
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
		private void Initialize()
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			m_subMenu.onClickPresentButton = OnClickPresentButton;
			m_subMenu.onClickNoticeButton = OnClickNoticeButton;
			m_subMenu.onClickMPassButton = OnClickPassButton;
			m_subMenu.onClickFriendButton = OnClickFriendButton;
			m_subMenu.onClickSnsButton = OnClickSnsButton;
			m_subMenu.ApplyNewIcons();
			m_buttonGroup.onClickBgChangeButton = OnClickBgViewStart;
			m_buttonGroup.onClickUIHideButton = OnClickUIHideView;
			m_buttonGroup.onClickStoryButton = OnClickStoryView;
			m_buttonGroup.onClickGakuyaButton = OnClickDivaView;
			m_buttonGroup.onClickDecoRoomButton = OnClickDecoButton;
			m_buttonGroup.onClickBingoButton = OnClickBingoView;
			m_buttonGroup.Setup(time);
			m_eventBanner.onClickBannerButton = OnClickEventBannerButton;
			m_eventBanner.Setup(JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/, false), time);
			SetupPickup();
			m_campaignBanner.onClickBannerButton = OnClickHomeBanner;
			m_campaignBanner.Setup(m_pickupBannerList, m_bannerTexCache);
			IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp/*7*/, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/);
			if(ev == null)
			{
				m_spEventCtrl = null;
			}
			else
			{
				TodoLogger.LogError(TodoLogger.EventSp_7, "Event");
			}
			CHHECNJBMLA_EventBoxGacha evGacha = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.JNHHEMLIDGJ() as CHHECNJBMLA_EventBoxGacha;
			if(evGacha == null)
			{
				m_boxGachaEventCtrl = null;
			}
			else
			{
				TodoLogger.LogError(TodoLogger.EventBoxGacha_8, "Event");
			}
			if(m_playRecordBanner.IsAvailabilityPeriod(DIHHCBACKGG_DbSection.IEFOPDOOLOK_MasterVersion))
			{
				m_playRecordBanner.onClickButton = OnClickPlayRecordBannerButton;
				m_playRecordBanner.Setup();
			}
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_pickupUi.onClickCloseButton = OnClickPickupClose;
			m_pickupUi.onClickJumpButton = OnClickPickupJump;
			m_pickupUi.onClickRejectCheckbox = OnClickRejectCheckbox;
			m_pickupUi.SetCheckboxLabel(bk.GetMessageByLabel("home_pickup_checkbox"));
			m_pickupUi.gameObject.SetActive(false);
			if(m_balloonLeadData != null)
			{
				switch(m_balloonLeadData.MMMGMNAMGDF)
				{
					case PLADCDJLOBE.PNLNGHNHCNI.NHANNKGPAHM/*0*/:
						SetupBeginnerLead();
						break;
					case PLADCDJLOBE.PNLNGHNHCNI.KJHABBHBFPD/*1*/:
						SetupMissionLead();
						break;
					case PLADCDJLOBE.PNLNGHNHCNI.PAAIHBHJJMM/*2*/:
						SetupStoryLead();
						break;
					case PLADCDJLOBE.PNLNGHNHCNI.MOFPBMFPFHF/*3*/:
						SetupStoryDivaLead();
						break;
					case PLADCDJLOBE.PNLNGHNHCNI.IEGNGNLGLGN/*4*/:
						SetupStorySnsLead();
						break;
					case PLADCDJLOBE.PNLNGHNHCNI.CCDOBDNDPIL_5/*5*/:
						SetupEventHomeLead();
						break;
				}
			}
		}

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
			MenuScene.Instance.divaManager.transform.Find("DivaCamera").GetComponent<Camera>().enabled = true;
			m_eventAdvId = GetEventAdvId();
			if(CanRareBreakAdv() || m_eventAdvId > 0)
			{
				AutoFadeFlag = false;
			}
			MenuScene.Instance.FooterMenu.MenuBar.SetInterruptEvent((TransitionList.Type type) => {
				//0x13C78E0
				return TryLobbyAnnounce();
			});
			m_isInitRaidLobby = false;
			MenuScene.Instance.LobbyButtonControl.StartCoroutineWatched(MenuScene.Instance.LobbyButtonControl.InitRaidLobby(() => {
				//0x13C790C
				m_isInitRaidLobby = true;
			}, () => {
				//0x13C7934
				TodoLogger.LogError(TodoLogger.EventRaid_11_13, "InitRaidLobby");
			}));
			m_isSuccessPrepare = false;
			NKGJPJPHLIF.HHCJCDFCLOB.LBEHLMLKPDM(() => {
				//0x13C7980
				m_isSuccessPrepare = true;
			}, () => {
				//0x13C79A8
				TodoLogger.LogError(10, "TODO");
			});
			m_balloonLeadData = PLADCDJLOBE.HEGEKFMJNCC();
			Database.Instance.bonusData.ClearEpisodeBonus();
			m_isUpdateMusicRateRanking = false;
			OEGIPPCADNA.HHCJCDFCLOB.MJFKJHJJLMN_GetUtaRateRank(0, false, () => {
				//0x13C7A14
				m_isUpdateMusicRateRanking = true;
			}, () => {
				//0x13C7A3C
				m_isUpdateMusicRateRanking = true;
			});
			if(!MenuScene.IsAlreadyHome)
			{
				m_isCheckGachaProductList = false;
				NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.LILDGEPCPPG_GetProducList(() => {
					//0x13C7AD0
					MenuScene.Instance.FooterMenu.SetButtonNew(MenuFooterControl.Button.Gacha, false);
					m_isCheckGachaProductList = true;
				}, () => {
					//0x13C7B24
					OnNetErrorToTitle();
				}, false, false);
			}
			else
			{
				m_isCheckGachaProductList = true;
			}
			
			if(CGFNKMNBNBN.DGCIHGPOMCI_CheckHomeBgExpire(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime()))
			{
				this.StartCoroutineWatched(Co_ChangeBg());
			}
			MenuScene.Instance.LobbyButtonControl.Wait();
			MenuScene.Instance.DenomControl.AddResponseHandler(OnChargeMoney);
			BingoQuestStart();
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
			TodoLogger.LogError(5, "Co_ChangeBg");
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
			//0x13D126C
			m_isHomeShowDiva = JKHEOEEPBMJ.NMKPJJLAONP_GetShowHomeDiva();
			if (m_isHomeShowDiva)
			{
				MenuScene.Instance.divaManager.BeginControl(m_divaControl);
				m_divaTalk = new MenuDivaTalk(MenuScene.Instance.divaManager.DivaId, m_divaControl);
				m_divaTalk.onChangedMessage = OnChangedDivaTalk;
				m_divaTalk.RequestDelayDownLoad();
				m_charTouch.OnClickCallback = () =>
				{
					//0x97CE94
					if (!m_isHomeShowDiva)
						return;
					m_divaTalk.DoTouchReaction();
					if (m_spEventCtrl != null)
						m_spEventCtrl.CIHGOMNFPNJ();
				};
				m_charTouch.OnStayCallback = (CharTouchButton button) =>
				{
					//0x97CEE8
					if (!m_isHomeShowDiva)
						return;
					StartIntimacyUp(button);
				};
				MenuScene.Instance.LobbyButtonControl.OnStartAnnounce = () =>
				{
					//0x97CEF8
					TodoLogger.LogError(TodoLogger.EventRaid_11_13, "OnStartAnnounce ");
				};
				MenuScene.Instance.LobbyButtonControl.OnEndAnnounce = () =>
				{
					//0x97D0E8
					TodoLogger.LogError(TodoLogger.EventRaid_11_13, "OnEndAnnounce ");
				};
				MenuScene.Instance.divaManager.SetEnableDivaWind(true, false);
			}
			Initialize();
			yield return Co.R(m_campaignBanner.Co_TryInstallBanner(m_pickupBannerList));
			yield return Co.R(Co_InitIntimacy());
			m_playRecordBanner.transform.SetAsLastSibling();
			m_fesBanner.transform.SetAsLastSibling();
			m_eventBanner.transform.SetAsLastSibling();
			m_campaignBanner.transform.SetAsLastSibling();
			m_leadBalloon.transform.SetAsLastSibling();
			MenuScene.Instance.LobbyButtonControl.m_lobbyTabBtn.transform.SetAsLastSibling();
			MenuScene.Instance.LobbyButtonControl.m_lobbySceneBtn.transform.SetAsLastSibling();
			m_pickupUi.transform.SetAsLastSibling();
		}

		// RVA: 0x9718D0 Offset: 0x9718D0 VA: 0x9718D0 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			if(m_isHomeShowDiva)
			{
				if(m_divaTalk.IsDownLoading())
					return false;
			}
			if(m_subMenu.IsLoading())
				return false;
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
			int bgmId = 0;
			if(!CanRareBreakAdv() && m_eventAdvId < 1)
			{
				bgmId = BgmPlayer.MENU_BGM_ID_BASE;
				if (MenuScene.Instance.BgControl.limitedHomeBg.m_music_id == BgControl.LimitedHomeBg.INVALID_MUSIC_ID)
				{
					string str = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.EFEGBHACJAL("home_bgm_id", "0,0,0");
					string[] strs = str.Split(new char[] { ',' });
					if(strs.Length == 3)
					{
						int v = 0;
						if(int.TryParse(strs[BgControl.GetHomeBgId(MenuScene.Instance.EnterToHomeTime) - 1], out v))
						{
							bgmId += v;
						}
					}
				}
				else
				{
					bgmId = BgmPlayer.MENU_BGM_ID_BASE + MenuScene.Instance.BgControl.limitedHomeBg.m_music_id;
				}
				SoundManager.Instance.bgmPlayer.ContinuousPlay(bgmId, 1);
			}
			return true;
		}

		// RVA: 0x972010 Offset: 0x972010 VA: 0x972010 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			EnterIntimacy();
			m_eventBanner.Enter();
			m_campaignBanner.Enter();
			m_fesBanner.Enter();
			m_subMenu.Enter();
			m_buttonGroup.Enter();
			m_playRecordBanner.Enter();
			MenuScene.Instance.LobbyButtonControl.Setup(HomeLobbyButtonController.Type.DOWN);
			MenuScene.Instance.HeaderMenu.SetActive(true);
			MenuScene.Instance.HeaderMenu.Enter(false);
		}

		// RVA: 0x972284 Offset: 0x972284 VA: 0x972284 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_eventBanner.IsPlaying() && !m_campaignBanner.IsPlaying() && !m_fesBanner.IsPlaying() && !m_subMenu.IsPlaying() && 
				!m_buttonGroup.IsPlaying() && !m_playRecordBanner.IsPlaying() && base.IsEndEnterAnimation();
		}

		// RVA: 0x972398 Offset: 0x972398 VA: 0x972398 Slot: 12
		protected override void OnStartExitAnimation()
		{
			if(m_isHomeShowDiva)
			{
				m_divaTalk.CancelRequest();
				m_divaTalk.TimerStop();
				LeaveMessage(true);
			}
			LeaveIntimacy();
			m_playRecordBanner.Leave();
			m_eventBanner.Leave();
			m_campaignBanner.Leave();
			m_fesBanner.Leave();
			m_subMenu.Leave();
			m_buttonGroup.Leave();
			if(m_leadBalloon.isEntered)
			{
				m_leadBalloon.Leave(true);
			}
			MenuScene.Instance.LobbyButtonControl.Hide();
			if(MenuScene.Instance.GetCurrentScene().cacheCategory == MenuScene.Instance.GetNextScene().cacheCategory)
			{
				if(MenuScene.Instance.GetCurrentScene().fadeId == MenuScene.Instance.GetNextScene().fadeId && 
					!MenuScene.Instance.GetNextScene().isForceFading)
				{
					if(MenuScene.Instance.HeaderMenu.CheckDisableUserInfo(MenuScene.Instance.GetNextScene()))
					{
						MenuScene.Instance.HeaderMenu.Leave(false);
					}
					if(MenuScene.Instance.FooterMenu.CheckDisableFooter(MenuScene.Instance.GetNextScene()))
					{
						MenuScene.Instance.FooterMenu.Leave(false);
					}
				}
			}
		}

		// RVA: 0x97286C Offset: 0x97286C VA: 0x97286C Slot: 13
		protected override bool IsEndExitAnimation()
		{
			if(m_saveDataDirty)
			{
				GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
			}
			if(!m_isDivaCrossFade)
			{
				return !m_eventBanner.IsPlaying() && !m_campaignBanner.IsPlaying() && 
					!m_fesBanner.IsPlaying() && !m_subMenu.IsPlaying() &&
					!m_buttonGroup.IsPlaying() && !m_playRecordBanner.IsPlaying() && 
					base.IsEndExitAnimation();
			}
			return false;
		}

		// RVA: 0x972A48 Offset: 0x972A48 VA: 0x972A48 Slot: 14
		protected override void OnDestoryScene()
		{
			if(m_isHomeShowDiva)
			{
				MenuScene.Instance.divaManager.EndControl(m_divaControl);
				MenuScene.Instance.divaManager.SetEnableDivaWind(false, false);
			}
			if(m_intimacyControl != null)
			{
				m_intimacyControl.OnDestoryScene();
			}
			MenuScene.Instance.LobbyButtonControl.OnStartAnnounce = null;
			MenuScene.Instance.LobbyButtonControl.OnEndAnnounce = null;
			MenuScene.Instance.LobbyButtonControl.OnStartTutorial = null;
			MenuScene.Instance.LobbyButtonControl.OnEndTutorial = null;
			MenuScene.Instance.FooterMenu.MenuBar.SetInterruptEvent(null);
			MenuScene.Instance.DenomControl.RemoveResponseHandler(OnChargeMoney);
		}

		// RVA: 0x972E08 Offset: 0x972E08 VA: 0x972E08 Slot: 15
		protected override void OnDeleteCache()
		{
			if(m_coOpenSnsScreen != null)
			{
				this.StopCoroutineWatched(m_coOpenSnsScreen);
				m_coOpenSnsScreen = null;
			}
			if(m_snsScreen != null)
			{
				m_snsScreen.Dispose();
				m_snsScreen = null;
			}
			Destroy(m_divaBalloon.gameObject);
			m_divaBalloon = null;
			m_pickupTexCache.Terminated();
			m_pickupTexCache = null;
			m_bannerTexCache.Terminated();
			m_bannerTexCache = null;
		}

		// RVA: 0x972FA4 Offset: 0x972FA4 VA: 0x972FA4 Slot: 29
		protected override void InputEnable()
		{
			base.InputEnable();
			m_leadBalloon.SetEnable();
		}

		// RVA: 0x972FD8 Offset: 0x972FD8 VA: 0x972FD8 Slot: 30
		protected override void InputDisable()
		{
			base.InputEnable();
			m_leadBalloon.SetDisable();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E32DC Offset: 0x6E32DC VA: 0x6E32DC
		// // RVA: 0x96E890 Offset: 0x96E890 VA: 0x96E890
		private IEnumerator Co_Loading()
		{
			//0x13D0F0C
			yield return Co.R(Co_LoadLayout());
			yield return Co.R(Co_LoadDivaSerifWindow());
			IsReady = true;

		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E3354 Offset: 0x6E3354 VA: 0x6E3354
		// // RVA: 0x97300C Offset: 0x97300C VA: 0x97300C
		private IEnumerator Co_LoadLayout()
		{
			string bundleName; // 0x18
			int bundleLoadCount; // 0x1C
			AssetBundleLoadLayoutOperationBase lyOp; // 0x20
			AssetBundleLoadUGUIOperationBase operation; // 0x24

			//0x13D038C
			XeSys.FontInfo font = GameManager.Instance.GetSystemFont();
			bundleName = "ly/006.xab";
			bundleLoadCount = 0;
			lyOp = AssetBundleManager.LoadLayoutAsync("ly/006.xab", "UI_HomePickup");
			bundleLoadCount++;
			yield return lyOp;
			yield return Co.R(lyOp.InitializeLayoutCoroutine(font, (GameObject instance) => {
				//0x13C7B58
				m_pickupUi = instance.GetComponent<HomePickup>();
				m_pickupUi.transform.SetParent(transform, false);
			}));
			m_pickupUi.Hide();
			operation = AssetBundleManager.LoadUGUIAsync(bundleName, "HomeSubMenu");
			bundleLoadCount++;
			yield return operation;
			yield return Co.R(operation.InitializeUGUICoroutine(font, (GameObject instance) => {
				//0x13C7C6C
				m_subMenu = instance.GetComponent<HomeSubMenu>();
				m_subMenu.transform.SetParent(transform, false);
			}));
			operation = AssetBundleManager.LoadUGUIAsync(bundleName, "HomeButtonGroup");
			bundleLoadCount++;
			yield return operation;
			yield return Co.R(operation.InitializeUGUICoroutine(font, (GameObject instance) => {
				//0x13C7D80
				m_buttonGroup = instance.GetComponent<HomeButtonGroup>();
				m_buttonGroup.transform.SetParent(transform, false);
			}));
			operation = AssetBundleManager.LoadUGUIAsync(bundleName, "HomeEventBanner");
			bundleLoadCount++;
			yield return operation;
			yield return Co.R(operation.InitializeUGUICoroutine(font, (GameObject instance) => {
				//0x13C7E94
				m_eventBanner = instance.GetComponent<HomeEventBanner>();
				m_eventBanner.transform.SetParent(transform, false);
				m_eventBanner.SetFont(font);
			}));
			operation = AssetBundleManager.LoadUGUIAsync(bundleName, "HomeFesBanner");
			bundleLoadCount++;
			yield return operation;
			yield return Co.R(operation.InitializeUGUICoroutine(font, (GameObject instance) => {
				//0x13C7FE4
				m_fesBanner = instance.GetComponent<HomeFesBanner>();
				m_fesBanner.transform.SetParent(transform, false);
				m_fesBanner.SetFont(font);
			}));
			operation = AssetBundleManager.LoadUGUIAsync(bundleName, "HomePickupBanner");
			bundleLoadCount++;
			yield return operation;
			yield return Co.R(operation.InitializeUGUICoroutine(font, (GameObject instance) => {
				//0x13C8134
				m_campaignBanner = instance.GetComponent<HomePickupBanner>();
				m_campaignBanner.transform.SetParent(transform, false);
				m_campaignBanner.SetFont(font);
			}));
			operation = AssetBundleManager.LoadUGUIAsync(bundleName, "HomeBalloonText");
			bundleLoadCount++;
			yield return operation;
			yield return Co.R(operation.InitializeUGUICoroutine(font, (GameObject instance) => {
				//0x13C8284
				m_leadBalloon = instance.GetComponent<HomeBalloonText>();
				m_leadBalloon.transform.SetParent(transform, false);
			}));
			operation = AssetBundleManager.LoadUGUIAsync(bundleName, "HomePlayRecordBanner");
			bundleLoadCount++;
			yield return operation;
			yield return Co.R(operation.InitializeUGUICoroutine(font, (GameObject instance) => {
				//0x13C8398
				m_playRecordBanner = instance.GetComponent<HomePlayRecordBanner>();
				m_playRecordBanner.transform.SetParent(transform, false);
			}));
			for(int i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
			}
			while(!m_pickupUi.IsLoaded())
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E33CC Offset: 0x6E33CC VA: 0x6E33CC
		// // RVA: 0x973094 Offset: 0x973094 VA: 0x973094
		private IEnumerator Co_LoadDivaSerifWindow()
		{
			string bundleName; // 0x14
			int bundleLoadCount; // 0x18
			XeSys.FontInfo font; // 0x1C
			AssetBundleLoadUGUIOperationBase operation; // 0x20

			//0x13D0074
			bundleName = "ly/032.xab";
			bundleLoadCount = 0;
			font = GameManager.Instance.GetSystemFont();
			operation = AssetBundleManager.LoadUGUIAsync(bundleName, "CommonDivaBalloon");
			bundleLoadCount++;
			yield return operation;
			yield return Co.R(operation.InitializeUGUICoroutine(font, (GameObject instance) => {
				//0x97D120
				m_divaBalloon = instance.GetComponent<CommonDivaBalloon>();
				m_divaBalloon.transform.SetParent(transform, false);
			}));
			for(int i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
			}
		}

		// // RVA: 0x97311C Offset: 0x97311C VA: 0x97311C
		private void OnNetErrorToTitle()
		{
			if(m_isWaitIntro)
				m_isAbortIntro = true;
			MenuScene.Instance.GotoTitle();
		}

		// // RVA: 0x9731CC Offset: 0x9731CC VA: 0x9731CC
		// private void OnExternalTransition() { }

		// // RVA: 0x9715E0 Offset: 0x9715E0 VA: 0x9715E0
		private void BingoQuestStart()
		{
			if(GNGMCIAIKMA.HHCJCDFCLOB.GBCPDBJEDHL())
			{
				List<int> bingos = GNGMCIAIKMA.HHCJCDFCLOB.CNADOFDDNLO_GetActiveBingos();
				for(int i = 0; i < bingos.Count; i++)
				{
					JKICPBIIHNE_Bingo.HNOGDJFJGPM bingo = GNGMCIAIKMA.HHCJCDFCLOB.EBEDAPJFHCE_GetBingo(bingos[i]);
					if(bingo.MNOKEJIPOBJ != 0)
					{
						GNGMCIAIKMA.HHCJCDFCLOB.BHFGBNNEMLI(bingos[i]);
						GNGMCIAIKMA.HHCJCDFCLOB.FBHHEBDDIMO(bingos[i], true);
						GNGMCIAIKMA.HHCJCDFCLOB.HEFIKPAHCIA_IsBingoValid(null, -1);
					}
				}
			}
		}

		// // RVA: 0x9731E0 Offset: 0x9731E0 VA: 0x9731E0
		private void ShowInformation(bool disableDivaTalk = false)
		{
			if(!GameManager.Instance.IsTutorial)
			{
				if(m_isHomeShowDiva && disableDivaTalk)
				{
					this.StartCoroutineWatched(m_divaControl.Coroutine_IdleCrossFade());
					m_divaTalk.CancelRequest();
					m_divaTalk.TimerStop();
				}
				MenuScene.Instance.InputDisable();
				m_isDisplayingInfo = true;
				// UMO Disable login information screen
				/*MBCPNPNMFHB.HHCJCDFCLOB.MDGPGGLHIPB_ShowWebUrl(MHOILBOJFHL.KCAEDEHGAFO.GCCBFIFJHII_Information, () =>
				{
					//0x13C84B4
					m_isDisplayingInfo = false;
					MenuScene.Instance.InputEnable();
					if (m_isHomeShowDiva && disableDivaTalk)
					{
						m_divaTalk.TimerRestart();
					}
				}, () =>
				{
					//0x13C85D0
					m_isDisplayingInfo = false;
					MenuScene.Instance.InputEnable();
					OnNetErrorToTitle();
				});*/
				m_isDisplayingInfo = false;
				MenuScene.Instance.InputEnable();
				if (m_isHomeShowDiva && disableDivaTalk)
				{
					m_divaTalk.TimerRestart();
				}
			}
		}

		// // RVA: 0x973484 Offset: 0x973484 VA: 0x973484
		private void SetInputStatus(bool headerEnable, bool sceneEnable, bool footerEnable)
		{
			if(m_headerUiEnable != headerEnable)
			{
				if (headerEnable)
					MenuScene.Instance.HeaderMenu.SetButtonEnable(MenuHeaderControl.Button.All);
				else
					MenuScene.Instance.HeaderMenu.SetButtonDisable(MenuHeaderControl.Button.All);
				m_headerUiEnable = headerEnable;
			}
			if(m_sceneUiEnable != sceneEnable)
			{
				if (sceneEnable)
					InputEnable();
				else
					InputDisable();
				m_sceneUiEnable = sceneEnable;
			}
			if(m_footerUiEnable != footerEnable)
			{
				if (footerEnable)
				{
					MenuScene.Instance.FooterMenu.SetButtonEnable(MenuFooterControl.Button.All);
					MenuScene.Instance.LobbyButtonControl.EnableButton(true);
				}
				else
				{
					MenuScene.Instance.FooterMenu.SetButtonDisable(MenuFooterControl.Button.All);
					MenuScene.Instance.LobbyButtonControl.EnableButton(false);
				}
				m_footerUiEnable = footerEnable;
			}
		}

		// // RVA: 0x97371C Offset: 0x97371C VA: 0x97371C
		private bool TryLobbyAnnounce()
		{
			if(!m_isStartTutorial)
			{
				return MenuScene.Instance.LobbyButtonControl.TryLobbyAnnounce();
			}
			return false;
		}

		// // RVA: 0x9737E8 Offset: 0x9737E8 VA: 0x9737E8
		private void OnChargeMoney(DenominationManager.Response handler)
		{
			if(handler == DenominationManager.Response.Success)
			{
				m_fesBanner.SetTicket(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
			}
		}

		// // RVA: 0x973910 Offset: 0x973910 VA: 0x973910
		private void OnClickNoticeButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			if(MenuScene.CheckDatelineAndAssetUpdate())
				return;
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent("UMO", SizeType.Small, "Notice not avaiable", new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			}, false, true), null, null, null, null);
			//ShowInformation(true);
		}

		// // RVA: 0x9739F0 Offset: 0x9739F0 VA: 0x9739F0
		private void OnClickPresentButton()
		{
			if(!TryLobbyAnnounce())
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				MenuScene.Instance.Call(TransitionList.Type.PRESENT_LIST, null, true);
			}
		}

		// // RVA: 0x973B04 Offset: 0x973B04 VA: 0x973B04
		private void OnClickFriendButton()
		{
			if(!TryLobbyAnnounce())
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				MenuScene.Instance.Call(TransitionList.Type.FRIEND_MENU, null, true);
			}
		}

		// // RVA: 0x973C18 Offset: 0x973C18 VA: 0x973C18
		private void OnClickSnsButton()
		{
			if (TryLobbyAnnounce())
				return;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			m_coOpenSnsScreen = this.StartCoroutineWatched(Co_OpenSnsScreen());
		}

		// // RVA: 0x973D24 Offset: 0x973D24 VA: 0x973D24
		private void OnClickEventBannerButton(int eventId)
		{
			if(TryLobbyAnnounce())
				return;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
            IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(eventId);
			GotoCurrentEventScene(ev.PGIIDPEGGPI_EventId, ev.HIDHLFCBIDE_EventType, false);
        }

		// // RVA: 0x974F60 Offset: 0x974F60 VA: 0x974F60
		private void OnClickPlayRecordBannerButton()
		{
			if(TryLobbyAnnounce())
				return;
			if(MenuScene.CheckDatelineAndAssetUpdate())
				return;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			this.StartCoroutineWatched(CO_ExecutePlayRecord(false));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E3444 Offset: 0x6E3444 VA: 0x6E3444
		// // RVA: 0x975108 Offset: 0x975108 VA: 0x975108
		public IEnumerator CO_ExecutePlayRecordFirst()
		{
			//0x13C9068
			yield return CO_ExecutePlayRecord(true);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E34BC Offset: 0x6E34BC VA: 0x6E34BC
		// // RVA: 0x975064 Offset: 0x975064 VA: 0x975064
		public IEnumerator CO_ExecutePlayRecord(bool a_first)
		{
			Camera t_camera; // 0x1C
			CameraClearFlags t_clear_flg; // 0x20

			//0x13C8758
			if(MenuScene.Instance != null)
			{
				MenuScene.Instance.InputDisable();
			}
			if(GameManager.Instance != null)
			{
				GameManager.Instance.CloseSnsNotice();
				GameManager.Instance.CloseOfferNotice();
			}
			if(!a_first)
			{
				this.StartCoroutineWatched(m_divaControl.Coroutine_IdleCrossFade());
				m_divaTalk.CancelRequest();
				m_divaTalk.TimerStop();
			}
			UI_PlayRecord t_playrecord = null;
			yield return Co.R(UI_PlayRecord.CO_LoadLayout(MenuScene.Instance.m_uiRootObject.transform, (UI_PlayRecord a_ui) =>
			{
				//0x13C86B4
				t_playrecord = a_ui;
			}));
			t_playrecord.transform.SetAsLastSibling();
			t_camera = GameManager.Instance.GetSystemCanvasCamera();
			t_clear_flg = t_camera.clearFlags;
			bool t_close = false;
			yield return Co.R(t_playrecord.Initialize(() =>
			{
				//0x13C86BC
				t_close = true;
			}));
			yield return Co.R(t_playrecord.Enter());
			while (!t_close)
				yield return null;
			yield return Co.R(t_playrecord.Leave());
			Destroy(t_playrecord.gameObject);
			yield return null;
			yield return Resources.UnloadUnusedAssets();
			t_camera.clearFlags = t_clear_flg;
			if(!a_first)
			{
				m_divaTalk.TimerRestart();
			}
			if (MenuScene.Instance != null)
			{
				MenuScene.Instance.InputEnable();
			}
		}

		// // RVA: 0x975190 Offset: 0x975190 VA: 0x975190
		// private void OnClickFesButton() { }

		// // RVA: 0x975768 Offset: 0x975768 VA: 0x975768
		// private void OnClickKujiButton() { }

		// // RVA: 0x975A54 Offset: 0x975A54 VA: 0x975A54
		private void OnClickHomeBanner(int bannerId)
		{
			if(TryLobbyAnnounce())
				return;
			UnityEngine.Debug.Log("on click home banner");
			JBCAHMMCOKK b = m_pickupBannerList.Find((JBCAHMMCOKK x) =>
			{
				//0x13C86D0
				return x.EAHPLCJMPHD_EventId == bannerId;
			});
			ILCCJNDFFOB.HHCJCDFCLOB.EAGAKGNNINL(b.JLPLLECHHLG, b.FEMMDNIELFC, b.IAMFPLLOHFO);
			switch(b.NNHHNFFLCFO)
			{
				case JBCAHMMCOKK.ALEKHDPDOEA.HMGJAOOGHMM_2:
					MenuScene.Instance.InputDisable();
					NKGJPJPHLIF.HHCJCDFCLOB.NBLAOIPJFGL_OpenURL(b.IAMFPLLOHFO, () =>
					{
						//0x13C65FC
						MenuScene.Instance.InputEnable();
					});
					ILCCJNDFFOB.HHCJCDFCLOB.EAGAKGNNINL(b.JLPLLECHHLG, b.FEMMDNIELFC, b.IAMFPLLOHFO);
					break;
				case JBCAHMMCOKK.ALEKHDPDOEA.CNCMFECBJHP_3:
					MenuScene.Instance.InputDisable();
					MBCPNPNMFHB.HHCJCDFCLOB.FLLLPBIECCP(b.IAMFPLLOHFO, () =>
					{
						//0x13C6698
						MenuScene.Instance.InputEnable();
					}, () =>
					{
						//0x13C8708
						OnNetErrorToTitle();
					});
					break;
				case JBCAHMMCOKK.ALEKHDPDOEA.BPCPDNGLNGO_4:
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
					GotoCurrentEventScene(b.EAHPLCJMPHD_EventId, 0, true);
					break;
				case JBCAHMMCOKK.ALEKHDPDOEA.IDAIIJEMNMP_5:
				case JBCAHMMCOKK.ALEKHDPDOEA.NCBMILKEFCF_6:
				case JBCAHMMCOKK.ALEKHDPDOEA.KBAKCIJPCAL_18:
				case JBCAHMMCOKK.ALEKHDPDOEA.KOLKHFLCBNP_19:
				case JBCAHMMCOKK.ALEKHDPDOEA.JNFDONGNAGP_20:
				case JBCAHMMCOKK.ALEKHDPDOEA.KCOEIKAMLBD_27:
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
					GotoGachaMainScene(b.NNHHNFFLCFO, b.EAHPLCJMPHD_EventId);
					break;
				case JBCAHMMCOKK.ALEKHDPDOEA.OLJOBADEFGB_7:
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
					GotoPurchaseSequence();
					break;
				case JBCAHMMCOKK.ALEKHDPDOEA.NHANNKGPAHM_8:
					OnClickMissionLead();
					break;
				case JBCAHMMCOKK.ALEKHDPDOEA.KAEBCNOCLPJ_9:
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
					GotoCurrentRankingEventScene();
					break;
				case JBCAHMMCOKK.ALEKHDPDOEA.FKGINHFBLJE_10:
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
					GotoWeekdayEventScene();
					break;
				case JBCAHMMCOKK.ALEKHDPDOEA.AHJNOIGCCFC_11:
					{
						SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
						OHCAABOMEOF.KGOGMKMBCPP_EventType eventType = OHCAABOMEOF.BPJMGICFPBJ(b.EAHPLCJMPHD_EventId);
						if(b.EAHPLCJMPHD_EventId > -1)
						{
							IKDICBBFBMI_EventBase k = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(b.EAHPLCJMPHD_EventId);
							if(k != null)
							{
								k.HCDGELDHFHB_UpdateStatus(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
								if(((int)k.NGOFCFJHOMI_Status & 0xfffffffe) == 8)
								{
									int v1 = 0;
									if(k.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp)
									{
										//346
										TodoLogger.LogError(TodoLogger.EventSp_7, "Event SP");
									}
									else
									{
										v1 = k.CAKEOPLJDAF_EndAdventureId;
									}
									GPMHOAKFALE_Adventure.NGDBKCKMDHE_AdventureData adv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EFMAIKAHFEK_Adventure.GCINIJEMHFK_GetAdventure(v1);
									if(adv != null)
									{
										if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.FABEJIHKFGN_IsReleased(v1))
										{
											switch(eventType)
											{
												case OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection:
													TodoLogger.LogError(TodoLogger.EventCollection_1, "Event Collection");
													break;
												case OHCAABOMEOF.KGOGMKMBCPP_EventType.MKKOHBGHADL_2:
												case OHCAABOMEOF.KGOGMKMBCPP_EventType.KEILBOLBDHN_EventScore:
												case OHCAABOMEOF.KGOGMKMBCPP_EventType.ENMHPBGOOII_Week:
													//switchD_00976c24_caseD_2
													break;
												case OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle:
													Database.Instance.advResult.Setup("Menu", TransitionUniqueId.EVENTBATTLE, new AdvSetupParam() { eventUniqueId=b.EAHPLCJMPHD_EventId });
													//switchD_00976c24_caseD_2
													break;
												case OHCAABOMEOF.KGOGMKMBCPP_EventType.NKDOEBONGNI_EventQuest:
													TodoLogger.LogError(TodoLogger.EventQuest_6, "Event Quest");
													break;
												case OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp:
													TodoLogger.LogError(TodoLogger.EventSp_7, "Event Sp");
													break;
												case OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva:
													Database.Instance.advResult.Setup("Menu", TransitionUniqueId.EVENTGODIVA, new AdvSetupParam() { eventUniqueId=b.EAHPLCJMPHD_EventId });
													break;
												default:
													break;
											}
											//switchD_00976c24_caseD_2
											CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.GFANLIOMMNA_SetReleased(v1);
											ILCCJNDFFOB.HHCJCDFCLOB.LIIJEGOIKDP(v1, OAGBCBBHMPF.DKAMMIHBINF.DODPGHDOFIO_2);
											Database.Instance.advSetup.Setup(adv.KKPPFAHFOJI_FileId);
											MenuScene.Instance.GotoAdventure(true);
											MenuScene.Instance.InputDisable();
											return;
										}
									}
									//LAB_0097685c
								}
								//LAB_0097685c
							}
						}
						//LAB_0097685c
						switch(eventType)
						{
							case OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection:
								TodoLogger.LogError(TodoLogger.EventCollection_1, "Event Collection");
								break;
							default:
								MenuScene.Instance.Mount(TransitionUniqueId.HOME_NEWYEAREVENT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
								break;
							case OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle:
								MenuScene.Instance.Mount(TransitionUniqueId.EVENTBATTLE, new EventMusicSelectSceneArgs(b.EAHPLCJMPHD_EventId, false, false), true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
								break;
							case OHCAABOMEOF.KGOGMKMBCPP_EventType.NKDOEBONGNI_EventQuest:
								TodoLogger.LogError(TodoLogger.EventQuest_6, "Event Quest");
								break;
							case OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp:
								TodoLogger.LogError(TodoLogger.EventSp_7, "Event SP");
								break;
							case OHCAABOMEOF.KGOGMKMBCPP_EventType.OCCGDMDBCHK_EventGacha:
								TodoLogger.LogError(TodoLogger.EventBoxGacha_8, "Event Gacha");
								break;
							case OHCAABOMEOF.KGOGMKMBCPP_EventType.DMPMKBCPHMA_PresentCampaign:
								TodoLogger.LogError(TodoLogger.EventPresentCampaign_9, "Event");
								break;
							case OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva:
								MenuScene.Instance.Mount(TransitionUniqueId.EVENTGODIVA, new EventMusicSelectSceneArgs(b.EAHPLCJMPHD_EventId, false, false), true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
								break;
						}
					}
					break;
				case JBCAHMMCOKK.ALEKHDPDOEA.MGJDKBFHDML_15:
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
					GotoLiveScene();
					break;
				case JBCAHMMCOKK.ALEKHDPDOEA.GINEDIDMAAO_16:
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
					GotoSpPage();
					break;
				case JBCAHMMCOKK.ALEKHDPDOEA.DMPMKBCPHMA_17:
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
					GotoPresentCampaignPage();
					break;
				case JBCAHMMCOKK.ALEKHDPDOEA.KJBGPOMJFBE_21:
					OnClickPassButton();
					break;
				case JBCAHMMCOKK.ALEKHDPDOEA.CIGFHJNCKPE_22:
				case JBCAHMMCOKK.ALEKHDPDOEA.BMHJMLDAPCE_23:
					if(GNGMCIAIKMA.HHCJCDFCLOB != null)
					{
						OnClickBingoView(GNGMCIAIKMA.HHCJCDFCLOB.AMIBPGONGFE(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime(), b.NNHHNFFLCFO == JBCAHMMCOKK.ALEKHDPDOEA.CIGFHJNCKPE_22));
					}
					else
					{
						OnClickBingoView(0);
					}
					break;
				case JBCAHMMCOKK.ALEKHDPDOEA.CADKONMJEDA_26:
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
					MenuScene.Instance.LobbyButtonControl.TransitionLobbyMain();
					break;
			}
		}

		// // RVA: 0x978424 Offset: 0x978424 VA: 0x978424
		private void OnClickBeginnerLead()
		{
			if(!TryLobbyAnnounce())
			{
				QuestTopArgs arg = new QuestTopArgs(m_balloonLeadData.BGOCBNPGNKM);
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				MenuScene.Instance.Mount(TransitionUniqueId.QUEST, arg, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
			}
		}

		// // RVA: 0x977868 Offset: 0x977868 VA: 0x977868
		private void OnClickMissionLead()
		{
			if(!TryLobbyAnnounce())
			{
				QuestTopArgs arg = new QuestTopArgs(m_balloonLeadData.BGOCBNPGNKM);
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				MenuScene.Instance.Mount(TransitionUniqueId.QUEST, arg, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
			}
		}

		// // RVA: 0x978578 Offset: 0x978578 VA: 0x978578
		private void OnClickStoryLead()
		{
			if(!TryLobbyAnnounce())
			{
				StorySelectArgs arg = new StorySelectArgs();
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				MenuScene.Instance.Mount(TransitionUniqueId.STORYSELECT, arg, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
			}
		}

		// // RVA: 0x9786B0 Offset: 0x9786B0 VA: 0x9786B0
		private void OnClickEventLead()
		{
			if(TryLobbyAnnounce())
				return;
            IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(m_balloonLeadData.EKANGPODCEP);
			if(ev == null)
				return;
			int a1 = ev.CAKEOPLJDAF_EndAdventureId;
			if(m_balloonLeadData.CICPBBKEBNJ == PLADCDJLOBE.OCMHGKIFNHP.JFEDIMKFDNH_1)
				a1 = ev.GFIBLLLHMPD_StartAdventureId;
			AdvSetupParam param = new AdvSetupParam();
			param.eventUniqueId = ev.PGIIDPEGGPI_EventId;
			GPMHOAKFALE_Adventure.NGDBKCKMDHE_AdventureData adv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EFMAIKAHFEK_Adventure.GCINIJEMHFK_GetAdventure(a1);
			if(ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection)
			{
				TodoLogger.LogError(TodoLogger.EventCollection_1, "Collection");
			}
			else if(ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
			{
				Database.Instance.advResult.Setup("Menu", TransitionUniqueId.EVENTBATTLE, new AdvSetupParam() { eventUniqueId=param.eventUniqueId });
			}
			else if(ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva)
			{
				Database.Instance.advResult.Setup("Menu", TransitionUniqueId.EVENTGODIVA, new AdvSetupParam() { eventUniqueId=param.eventUniqueId });
			}
			else if(ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.NKDOEBONGNI_EventQuest)
			{
				TodoLogger.LogError(TodoLogger.EventQuest_6, "Quest");
			}
			//LAB_009789d0
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.GFANLIOMMNA_SetReleased(a1);
			ILCCJNDFFOB.HHCJCDFCLOB.LIIJEGOIKDP(a1, OAGBCBBHMPF.DKAMMIHBINF.IFEDIOFCOBC_7);
			Database.Instance.advSetup.Setup(adv.KKPPFAHFOJI_FileId);
			MenuScene.Instance.GotoAdventure();
			MenuScene.Instance.InputDisable();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
        }

		// // RVA: 0x973E84 Offset: 0x973E84 VA: 0x973E84
		private void GotoCurrentEventScene(int eventUniqueId, OHCAABOMEOF.KGOGMKMBCPP_EventType currentEventType, bool isPickup)
		{
			if(currentEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0)
			{
				currentEventType = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(eventUniqueId).HIDHLFCBIDE_EventType;
			}
			if(eventUniqueId > 0)
			{
				IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(eventUniqueId);
				if(ev != null && ev.FBLGGLDPFDF_CanShowStartAdventure())
				{
					int id = 0;
					if(ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp)
					{
						TodoLogger.LogError(TodoLogger.EventSp_7, "Event SP");
					}
					else
					{
						id = ev.GFIBLLLHMPD_StartAdventureId;
					}
                    GPMHOAKFALE_Adventure.NGDBKCKMDHE_AdventureData adv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EFMAIKAHFEK_Adventure.GCINIJEMHFK_GetAdventure(id);
					if(adv != null)
					{
						switch(currentEventType)
						{
							case OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection:
								TodoLogger.LogError(TodoLogger.EventCollection_1, "Event Collection");
								break;
							default:
								break;
							case OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle:
								Database.Instance.advResult.Setup("Menu", TransitionUniqueId.EVENTBATTLE, new AdvSetupParam() { eventUniqueId=eventUniqueId });
								break;
							case OHCAABOMEOF.KGOGMKMBCPP_EventType.NKDOEBONGNI_EventQuest:
								TodoLogger.LogError(TodoLogger.EventQuest_6, "Event Quest");
								break;
							case OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp:
								TodoLogger.LogError(TodoLogger.EventSp_7, "Event SP");
								break;
							case OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid:
								TodoLogger.LogError(TodoLogger.EventRaid_11_13, "Event Raid");
								break;
							case OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva:
								Database.Instance.advResult.Setup("Menu", TransitionUniqueId.EVENTGODIVA, new AdvSetupParam() { eventUniqueId=eventUniqueId });
								break;
						}
						CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.GFANLIOMMNA_SetReleased(id);
						ILCCJNDFFOB.HHCJCDFCLOB.LIIJEGOIKDP(id, OAGBCBBHMPF.DKAMMIHBINF.IDINJDEBPKP_6);
						Database.Instance.advSetup.Setup(adv.KKPPFAHFOJI_FileId);
						MenuScene.Instance.GotoAdventure();
						MenuScene.Instance.InputDisable();
						return;
					}
				}
			}
			//LAB_00974250
			switch(currentEventType)
			{
				case OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection:
					TodoLogger.LogError(TodoLogger.EventCollection_1, "Event Collection");
					break;
				default:
					break;
				case OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle:
					MenuScene.Instance.Mount(TransitionUniqueId.EVENTBATTLE, new EventMusicSelectSceneArgs(eventUniqueId, false, false), true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case OHCAABOMEOF.KGOGMKMBCPP_EventType.NKDOEBONGNI_EventQuest:
					TodoLogger.LogError(TodoLogger.EventQuest_6, "Event Quest");
					break;
				case OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp:
					TodoLogger.LogError(TodoLogger.EventSp_7, "Event SP");
					break;
				case OHCAABOMEOF.KGOGMKMBCPP_EventType.OCCGDMDBCHK_EventGacha:
					TodoLogger.LogError(TodoLogger.EventBoxGacha_8, "Event Gacha");
					break;
				case OHCAABOMEOF.KGOGMKMBCPP_EventType.DMPMKBCPHMA_PresentCampaign:
					TodoLogger.LogError(TodoLogger.EventPresentCampaign_9, "Event");
					break;
				case OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva:
					MenuScene.Instance.Mount(TransitionUniqueId.EVENTGODIVA, new EventMusicSelectSceneArgs(eventUniqueId, false, false), true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
			}
		}

		// // RVA: 0x977380 Offset: 0x977380 VA: 0x977380
		private void GotoPurchaseSequence()
		{
			if(MenuScene.Instance.DenomControl != null)
			{
				MenuScene.Instance.InputDisable();
				MenuScene.Instance.DenomControl.StartPurchaseSequence(
					MenuScene.Instance.InputEnable,
					MenuScene.Instance.InputEnable,
					OnNetErrorToTitle,
					(TransitionList.Type type) =>
					{
						//0x13C68A4
						if(type == TransitionList.Type.TITLE)
						{
							MenuScene.Instance.GotoTitle();
						}
						else if(type == TransitionList.Type.LOGIN_BONUS)
						{
							MenuScene.Instance.GotoLoginBonus();
						}
					}, null
				);
			}
		}

		// // RVA: 0x977678 Offset: 0x977678 VA: 0x977678
		private void GotoCurrentRankingEventScene()
		{
			MusicSelectArgs args = new MusicSelectArgs();
			args.SetSelection(OHCAABOMEOF.KGOGMKMBCPP_EventType.KEILBOLBDHN_EventScore);
			MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, args, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
		}

		// // RVA: 0x977770 Offset: 0x977770 VA: 0x977770
		private void GotoWeekdayEventScene()
		{
			MusicSelectArgs args = new MusicSelectArgs();
			args.SetSelection(OHCAABOMEOF.KGOGMKMBCPP_EventType.ENMHPBGOOII_Week);
			MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, args, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
		}

		// // RVA: 0x9779BC Offset: 0x9779BC VA: 0x9779BC
		private void GotoLiveScene()
		{
			MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
		}

		// // RVA: 0x977A74 Offset: 0x977A74 VA: 0x977A74
		private void GotoSpPage()
		{
			if(m_spEventCtrl != null)
			{
				TodoLogger.LogError(TodoLogger.EventSp_7, "Event SP");
			}
			MenuScene.Instance.Mount(TransitionUniqueId.HOME_NEWYEAREVENT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
		}

		// // RVA: 0x977F7C Offset: 0x977F7C VA: 0x977F7C
		private void GotoPresentCampaignPage()
		{
			MenuScene.Instance.Mount(TransitionUniqueId.HOME_CAMPAIGN, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
		}

		// // RVA: 0x9770F4 Offset: 0x9770F4 VA: 0x9770F4
		private void GotoGachaMainScene(JBCAHMMCOKK.ALEKHDPDOEA transitionId, int typeAndSeriesId)
		{
			if(transitionId < JBCAHMMCOKK.ALEKHDPDOEA.OLJOBADEFGB_7)
			{
				if(transitionId == JBCAHMMCOKK.ALEKHDPDOEA.IDAIIJEMNMP_5)
				{
					GachaUtility.selectCategory = GCAHJLOGMCI.KNMMOMEHDON_GachaType.GENEIBGNMPH_3;
				}
				else if(transitionId == JBCAHMMCOKK.ALEKHDPDOEA.NCBMILKEFCF_6)
				{
					GachaUtility.selectCategory = GCAHJLOGMCI.KNMMOMEHDON_GachaType.JGDEHOGIENP_4;
				}
			}
			else
			{
				switch(transitionId)
				{
					case JBCAHMMCOKK.ALEKHDPDOEA.KBAKCIJPCAL_18:
						GachaUtility.selectCategory = GCAHJLOGMCI.KNMMOMEHDON_GachaType.GENEIBGNMPH_3;
						break;
					case JBCAHMMCOKK.ALEKHDPDOEA.KOLKHFLCBNP_19:
						GachaUtility.selectCategory = GCAHJLOGMCI.KNMMOMEHDON_GachaType.BCBJMKDAAKA_8;
						break;
					case JBCAHMMCOKK.ALEKHDPDOEA.JNFDONGNAGP_20:
						GachaUtility.selectCategory = GCAHJLOGMCI.KNMMOMEHDON_GachaType.OOABDNHIEFK_9;
						break;
					default:
						break;
					case JBCAHMMCOKK.ALEKHDPDOEA.KCOEIKAMLBD_27:
						GachaUtility.selectCategory = GCAHJLOGMCI.KNMMOMEHDON_GachaType.DLOPEFGOAPD_10;
						break;
				}
			}
			GachaUtility.UpdateGachaProductCategory();
			m_gachaArgs.Init(typeAndSeriesId, true);
			MenuScene.Instance.Mount(TransitionUniqueId.GACHA2, m_gachaArgs, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E3534 Offset: 0x6E3534 VA: 0x6E3534
		// // RVA: 0x971AA4 Offset: 0x971AA4 VA: 0x971AA4
		private IEnumerator Co_SceneIntroduce()
		{
			List<Func<IEnumerator>> coList; // 0x1C
			bool isFirstHome; // 0x20
			bool isFirstTitleFlow; // 0x21
			int i; // 0x24
			GameManager.PushBackButtonHandler backButtonDummy; // 0x28

			//0x13D2790
			HomeArgs args = Args as HomeArgs;
			SetInputStatus(false, false, false);
			m_campaignBanner.StopAutoScroll();
			m_isWaitIntro = true;
			m_isAbortIntro = false;
			coList = new List<Func<IEnumerator>>();
			/*if (UI_PlayRecord.IsFirstLaunch())
			{
				if (m_playRecordBanner.IsSetup())
				{
					coList.Add(CO_ExecutePlayRecordFirst);
				}
			}*/ // Disable on UMO cause new account don't need this
			isFirstHome = !MenuScene.IsAlreadyHome;
			isFirstTitleFlow = MenuScene.IsFirstTitleFlow;
			if (isFirstHome)
			{
				coList.Add(Co_GetPaidVCProductList);
				MenuScene.Instance.InitAssitPlate();
			}
			coList.Add(Coroutine_LoginBonusPopup);
			coList.Add(Co_MonthlyPassLoginBonusPopup);
			if (isFirstTitleFlow)
			{
				coList.Add(Co_ShowRichBanner);
				coList.Add(Co_ShowPickupWebView);
				coList.Add(Coroutine_ShowInformation);
			}
			if (args != null && args.isOpenSns)
			{
				coList.Add(Co_SnsScreen);
			}
			coList.Add(MenuScene.Instance.ShowPosterReleaseWindowCoroutine);
			coList.Add(MenuScene.Instance.ShowGetLiveSkipTicketWindowCoroutine);
			coList.Add(MenuScene.Instance.ShowConvertRareupStarWindowCoroutine);
			coList.Add(MenuScene.Instance.ShowReceiveRewardWindowCoroutine);
			coList.Add(MenuScene.Instance.ShowMissionStepupWindowCoroutine);
			coList.Add(Co_HomeMissionAnnounce);
			coList.Add(Co_LimitedItemWarning);
			coList.Add(Co_CurrencyItemWarning);
			coList.Add(Co_ChangePopupLimtiedBg);
			if (MenuScene.CheckDatelineAndAssetUpdate())
				m_isAbortIntro = true;
			if (CanRareBreakAdv())
			{
				TipsControl.Instance.Close();
				//LAB_013d39d0
				while (TipsControl.Instance.isPlayingAnime())
					yield return null;
				Database.Instance.advResult.Setup("Menu", TransitionUniqueId.HOME);
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.GFANLIOMMNA_SetReleased(GetRareBreakAdvId());
				ILCCJNDFFOB.HHCJCDFCLOB.LIIJEGOIKDP(GetRareBreakAdvId(), OAGBCBBHMPF.DKAMMIHBINF.PGNFDEIHHMD/*9*/);
				Database.Instance.advSetup.Setup(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EFMAIKAHFEK_Adventure.GCINIJEMHFK_GetAdventure(GetRareBreakAdvId()).KKPPFAHFOJI_FileId);
				MenuScene.Instance.GotoAdventure(true);
				m_isAbortIntro = true;
				yield break;
			}
			if (CanGetEventAdv())
			{
				TipsControl.Instance.Close();
				//LAB_013d3d98
				while (TipsControl.Instance.isPlayingAnime())
					yield return null;
				Database.Instance.advResult.Setup("Menu", TransitionUniqueId.HOME);
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.GFANLIOMMNA_SetReleased(m_eventAdvId);
				ILCCJNDFFOB.HHCJCDFCLOB.LIIJEGOIKDP(m_eventAdvId, OAGBCBBHMPF.DKAMMIHBINF.PGNFDEIHHMD/*9*/);
				Database.Instance.advSetup.Setup(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EFMAIKAHFEK_Adventure.GCINIJEMHFK_GetAdventure(m_eventAdvId).KKPPFAHFOJI_FileId);
				MenuScene.Instance.GotoAdventure(true);
				m_isAbortIntro = true;
				yield break;
			}
			for (i = 0; i < coList.Count; i++)
			{
				if (!m_isAbortIntro)
				{
					yield return Co.R(coList[i].Invoke());
					//3
				}
			}
			coList.Clear();
			bool doTransition = false;
			if (!doTransition && !m_isAbortIntro)
			{
				yield return Co.R(MenuScene.Instance.LobbyButtonControl.Co_CheckNewMark(() =>
				{
					//0x13C6C3C
					doTransition = true;
					MenuScene.Instance.GotoTitle();
				}));
				//4
				if (MenuScene.Instance.DirtyChangeScene)
					doTransition = true;
			}
			//LAB_013d54f8
			if (!doTransition && !m_isAbortIntro)
			{
				yield return Co.R(Coroutine_EventReward());
				//5
				if (MenuScene.Instance.DirtyChangeScene)
					doTransition = true;
			}
			//LAB_013d5534
			if (!doTransition && !m_isAbortIntro && TutorialProc.CanBeginnerMissionLiveClearLiveHelp())
			{
				m_isStartTutorial = true;
				SetInputStatus(false, false, true);
				yield return Co.R(TutorialProc.Co_BeginnerMissionLiveClear(null, null));
				//6
				if (MenuScene.Instance.DirtyChangeScene)
					doTransition = true;
				m_isStartTutorial = false;
			}
			//LAB_013d4110
			if (!doTransition && !m_isAbortIntro)
			{
				yield return Co.R(Coroutine_ShowUnlock(() =>
				{
					//0x13C6CE4
					doTransition = true;
				}));
				//7
				if (MenuScene.Instance.DirtyChangeScene)
					doTransition = true;
			}
			//LAB_013d414c
			if (!doTransition && !m_isAbortIntro)
			{
				yield return Co.R(Co_CheckPlayerForceRename(() =>
				{
					//0x13C6CF0
					doTransition = true;
				}));
				//8
				if (MenuScene.Instance.DirtyChangeScene)
					doTransition = true;
			}
			//LAB_013d4188
			if (!doTransition && !m_isAbortIntro && BasicTutorialManager.IsBeginnerMission())
			{
				m_isStartTutorial = true;
				SetInputStatus(false, false, true);
				yield return Co.R(Co_BeginnerMissionMiniAdv());
				//9
				if (MenuScene.Instance.DirtyChangeScene)
					doTransition = true;
				m_isStartTutorial = false;
			}
			//LAB_013d4264
			if (!doTransition && !m_isAbortIntro)
			{
				yield return Co.R(TutorialManager.TryShowTutorialCoroutine(CheckTutorialFunc));
				//10
				if (MenuScene.Instance.DirtyChangeScene)
					doTransition = true;
			}
			//LAB_013d42a0
			if (!doTransition && !m_isAbortIntro && HNDLICBDEMI.AFGKIJMPNNN_IsDecoEnabled())
			{
				m_isStartTutorial = true;
				List<ButtonBase> btns = new List<ButtonBase>(m_buttonGroup.GetComponentsInChildren<ButtonBase>(true));
				ButtonBase btn = btns.Find((ButtonBase _) =>
				{
					//0x13C69AC
					return _.name.Contains("Button_DecoRoom");
				});
				yield return Co.R(TutorialProc.Co_Decolture(btn, () =>
				{
					//0x13C6CFC
					SetInputStatus(false, false, false);
					doTransition = true;
				}));
				//0xb
				m_isStartTutorial = false;
			}
			//LAB_013d44f8
			if (!doTransition && !m_isAbortIntro)
			{
				if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.MLBBKNLPBBD_HasShowTuto(BOPFPIHGJMD.PDLKAKEABDP.EILIAPKFCEO_0/*0*/))
				{
					if(KDHGBOOECKC.HHCJCDFCLOB.LOCAIBNPKDL_IsPlayerLevelOk())
					{
						m_isStartTutorial = true;
						SetInputStatus(false, false, true);
						ButtonBase btn = MenuScene.Instance.FooterMenu.FindButton(MenuFooterControl.Button.VOP);
						yield return Co.R(TutorialProc.Co_OffeReleaseTutorial(InputLimitButton.VOP, btn, () =>
						{
							//0x13C6A44
							return;
						}, BasicTutorialMessageId.Id_OfferRelease, true, null, null));
						//0xc
						doTransition = true;
						m_isStartTutorial = false;
					}
				}
			}
			//LAB_013d47c8
			if (!doTransition && !m_isAbortIntro)
			{
				if(GNGMCIAIKMA.HHCJCDFCLOB != null)
				{
					if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsBingoMission) && GNGMCIAIKMA.HHCJCDFCLOB.GBCPDBJEDHL())
					{
						m_isStartTutorial = true;
						MenuScene.Instance.InputDisable();
						backButtonDummy = () =>
						{
							//0x13C6A48
							return;
						};
						yield return Co.R(TutorialManager.ShowTutorial(114, null));
						//0xd
						bool done = false;
						CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.BCLKCMDGDLD(GPFlagConstant.ID.IsBingoMission, true);
						MenuScene.Save(() =>
						{
							//0x13C6D54
							done = true;
						}, null);
						while (!done)
							yield return null;
						GameManager.Instance.RemovePushBackButtonHandler(backButtonDummy);
						MenuScene.Instance.InputEnable();
						m_isStartTutorial = false;
						backButtonDummy = null;
					}
				}
			}
			//LAB_013d4804
			if (!doTransition && !m_isAbortIntro && MOEALEGLGCH.CDOCOLOKCJK() && 
				!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.BEKHNNCGIEL_Costume.MLBBKNLPBBD_IsTutoDone(0))
			{
				m_isStartTutorial = true;
				SetInputStatus(false, false, true);
				ButtonBase btn = MenuScene.Instance.FooterMenu.FindButton(MenuFooterControl.Button.Setting);
				yield return Co.R(TutorialProc.Co_CostumeUpgrade(0, btn, BasicTutorialMessageId.Id_CostumeUpgradeHome, InputLimitButton.Setting, TutorialPointer.Direction.Down));
				//0xf
				doTransition = true;
				m_isStartTutorial = false;
			}
			//LAB_013d48f0
			if (!doTransition && !m_isAbortIntro && SettingMenuPanel.IsValkyrieTuneUpUnlock() && 
				!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsValkyrieUpgrade))
			{
				m_isStartTutorial = true;
				SetInputStatus(false, false, true);
				ButtonBase btn = MenuScene.Instance.FooterMenu.FindButton(MenuFooterControl.Button.Setting);
				yield return Co.R(TutorialProc.Co_ValkyrieUpgrade(btn, BasicTutorialMessageId.Id_ValkyrieUpgradeHome, InputLimitButton.Setting, TutorialPointer.Direction.Down, null, null));
				//0x10
				doTransition = true;
				m_isStartTutorial = false;
			}
			//LAB_013d4974
			SetInputStatus(true, true, true);
			MenuScene.IsAlreadyHome = true;
			MenuScene.IsFirstTitleFlow = false;
			if(!doTransition && !m_isAbortIntro)
			{
				if(m_isHomeShowDiva)
				{
					if(GameManager.Instance.GetHomeDiva().AHHJLDLAPAN_DivaId != m_introTalkDivaId ||
						m_lastHomeShowDiva != m_isHomeShowDiva ||
						isFirstTitleFlow || isFirstHome)
					{
						m_introTalkDivaId = GameManager.Instance.GetHomeDiva().AHHJLDLAPAN_DivaId;
						MenuDivaTalk.ClearHomeTalkFlags();
					}
					bool b = true;
					if(!m_divaTalk.CheckBirthdayTalk(true))
					{
						b = m_divaTalk.CheckLimitedTalk(true);
					}
					if(!b && !(isFirstTitleFlow || isFirstHome))
					{
						m_divaTalk.TimerStart();
					}
					else
					{
						m_divaTalk.SetLoginTime(MenuScene.Instance.EnterToHomeTime);
						m_divaTalk.DoIntroTalk(false);
					}
				}
				m_lastHomeShowDiva = m_isHomeShowDiva;
				if (isValidBalloonLead)
				{
					m_leadBalloon.gameObject.SetActive(true);
					m_leadBalloon.Enter(false);
				}
				NoticeActionList.Add(CheckSnsNotice);
				NoticeActionList.Add(CheckOfferNotice);
				ShowNotice();
			}
			m_campaignBanner.StartAutoScroll();
			m_isWaitIntro = false;
		}

		// // RVA: 0x978C38 Offset: 0x978C38 VA: 0x978C38
		private void CheckSnsNotice()
		{
			if (!BIFNGFAIEIL.HHCJCDFCLOB.DNFPMBFNDCA())
				return;
			int snsId = BIFNGFAIEIL.HHCJCDFCLOB.FGGDEKAJCIF();
			if(snsId == 0)
				return;
			MenuScene.Instance.ShowSnsNotice(snsId, () =>
			{
				//0x97D1F4
				this.StartCoroutineWatched(Co_OpenSnsScreen());
			});
			BIFNGFAIEIL.HHCJCDFCLOB.ALIANOFCAEI();
		}

		// // RVA: 0x978E2C Offset: 0x978E2C VA: 0x978E2C
		private void CheckOfferNotice()
		{
			if (KDHGBOOECKC.HHCJCDFCLOB.IOCBOGFFHFE.OAFPGJLCNFM_Cond == 0)
				return;
			MenuScene.Instance.ShowOfferNotice(null);
		}

		// // RVA: 0x978F14 Offset: 0x978F14 VA: 0x978F14
		// private void AddNotice(Action action) { }

		// // RVA: 0x978F94 Offset: 0x978F94 VA: 0x978F94
		private void ShowNotice()
		{
			this.StartCoroutineWatched(Co_ShowNotice());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E35AC Offset: 0x6E35AC VA: 0x6E35AC
		// // RVA: 0x978FB8 Offset: 0x978FB8 VA: 0x978FB8
		private IEnumerator Co_ShowNotice()
		{
			//0x13D5880
			for(int i = 0; i < NoticeActionList.Count; i++)
			{
				NoticeActionList[i]();
				GameManager.Instance.snsNotification.DirtyClose = false;
				while(GameManager.Instance.snsNotification.isActiveAndEnabled)
					yield return null;
				if (GameManager.Instance.snsNotification.DirtyClose)
					break;
			}
			NoticeActionList.Clear();
		}

		// // RVA: 0x979040 Offset: 0x979040 VA: 0x979040
		private void EnterMessage()
		{
			m_divaBalloon.SetDiva(GameManager.Instance.GetHomeDiva().AHHJLDLAPAN_DivaId);
			m_divaBalloon.Enter(true);
		}

		// // RVA: 0x979140 Offset: 0x979140 VA: 0x979140
		private void ApplyMessageText(string msg)
		{
			m_divaBalloon.SetMessage(msg);
		}

		// // RVA: 0x9727C4 Offset: 0x9727C4 VA: 0x9727C4
		private void LeaveMessage(bool force = false)
		{
			m_divaBalloon.Leave(force);
		}

		// // RVA: 0x979174 Offset: 0x979174 VA: 0x979174
		private void OnClickDivaView()
		{
			if(!TryLobbyAnnounce())
			{
				if(!MenuScene.CheckDatelineAndAssetUpdate())
				{
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
					MenuScene.Instance.Call(TransitionList.Type.GAKUYA, null, true);
					this.StartCoroutineWatched(Co_WaitIdleCrossFade());
				}
			}
		}

		// // RVA: 0x97936C Offset: 0x97936C VA: 0x97936C
		private void OnClickStoryView()
		{
			if(!TryLobbyAnnounce())
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				if(!MenuScene.CheckDatelineAndAssetUpdate())
				{
					MenuScene.Instance.Mount(TransitionUniqueId.STORYSELECT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
				}
			}
		}

		// // RVA: 0x978124 Offset: 0x978124 VA: 0x978124
		private void OnClickBingoView(int _bingoId)
		{
			if(!TryLobbyAnnounce())
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				if(_bingoId > 0)
				{
					if(GNGMCIAIKMA.HHCJCDFCLOB != null)
					{
						int a1 = GNGMCIAIKMA.HHCJCDFCLOB.JBEDFJHAAFP(_bingoId, false);
						bool b1 = GNGMCIAIKMA.HHCJCDFCLOB.KJNFBLAMJOH(_bingoId);
						bool b2 = GNGMCIAIKMA.HHCJCDFCLOB.DOEGBMNNFKH(_bingoId);
						bool b3 = false;
						if(!b2)
						{
							b3 = !GNGMCIAIKMA.HHCJCDFCLOB.DHPLHALIDHH(_bingoId);
						}
						if(!(b3 && a1 < 1 && b1))
						{
							GNGMCIAIKMA.HHCJCDFCLOB.DJGFICMNGGP_SetBingoId(_bingoId);
							GNGMCIAIKMA.HHCJCDFCLOB.BHFGBNNEMLI(_bingoId);
							if(!GNGMCIAIKMA.HHCJCDFCLOB.IDKFAMEFCPD(_bingoId) && GNGMCIAIKMA.HHCJCDFCLOB.MLCGJAJCFDP(_bingoId, 0, 0) != 0)
							{
								MenuScene.Instance.Mount(TransitionUniqueId.QUEST_BINGOSELECT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
							}
							else
							{
								MenuScene.Instance.Mount(TransitionUniqueId.QUEST_BINGOMISSITON, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
							}
						}
						else
						{
							MenuScene.Instance.Mount(TransitionUniqueId.QUEST, new QuestTopArgs(PLADCDJLOBE.ENNOBKHBNCG.DIDJLIPNCKO_6), true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
						}
					}
				}
			}
		}

		// // RVA: 0x978038 Offset: 0x978038 VA: 0x978038
		private void OnClickPassButton()
		{
			if(MenuScene.CheckDatelineAndAssetUpdate())
				return;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			this.StartCoroutineWatched(Co_OpenPassWindow());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E3624 Offset: 0x6E3624 VA: 0x6E3624
		// // RVA: 0x9794C0 Offset: 0x9794C0 VA: 0x9794C0
		private IEnumerator Co_OpenPassWindow()
		{
			//0x13D1AB8
			if(m_isHomeShowDiva)
			{
				this.StartCoroutineWatched(m_divaControl.Coroutine_IdleCrossFade());
				m_divaTalk.CancelRequest();
				m_divaTalk.TimerStop();
			}
			yield return this.StartCoroutineWatched(m_pop_pass_ctrl.CoroutineOpen());
			if(m_isHomeShowDiva)
			{
				m_divaTalk.TimerRestart();
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E369C Offset: 0x6E369C VA: 0x6E369C
		// // RVA: 0x9792E4 Offset: 0x9792E4 VA: 0x9792E4
		private IEnumerator Co_WaitIdleCrossFade()
		{
			if(m_isHomeShowDiva)
			{
				m_isDivaCrossFade = true;
				yield return this.StartCoroutineWatched(m_divaControl.Coroutine_IdleCrossFade());
				m_isDivaCrossFade = false;
			}
		}

		// // RVA: 0x979548 Offset: 0x979548 VA: 0x979548
		private void OnClickDecoButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			int decoLevel;
			bool decoEnabled;
			HNDLICBDEMI.FMLGCFKNKIA_GetDecoPlayerLevelAndEnabled(out decoLevel, out decoEnabled);
			if(m_isHomeShowDiva)
			{
				this.StartCoroutineWatched(Co_WaitIdleCrossFade());
				m_divaTalk.CancelRequest();
				m_divaTalk.TimerStop();
			}
			if(!decoEnabled)
			{
				MenuScene.Instance.InputDisable();
				TextPopupSetting s = new TextPopupSetting();
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				s.Text = JpStringLiterals.StringLiteral_16419;
				PopupWindowManager.Show(s, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x97D218
					MenuScene.Instance.InputEnable();
					if (!m_isHomeShowDiva)
						return;
					m_divaTalk.TimerRestart();
				}, null, null, null);
				return;
			}
			if (TryLobbyAnnounce())
				return;
			if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsDecolture))
			{
				int d = 0;
				if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
					d = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("decolturemode_first_adv_id", 0);
				GPMHOAKFALE_Adventure.NGDBKCKMDHE_AdventureData adv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EFMAIKAHFEK_Adventure.GCINIJEMHFK_GetAdventure(d);
				if(adv == null)
				{
					adv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EFMAIKAHFEK_Adventure.GCINIJEMHFK_GetAdventure(1);
				}
				if(adv != null)
				{
					Database.Instance.advResult.Setup("Menu", TransitionUniqueId.DECO, new AdvSetupParam());
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.GFANLIOMMNA_SetReleased(d);
					Database.Instance.advSetup.Setup(adv.KKPPFAHFOJI_FileId);
					MenuScene.Instance.GotoAdventure(true);
					ILCCJNDFFOB.HHCJCDFCLOB.CLGHLKLHEAK(JpStringLiterals.StringLiteral_16417, 0);
					return;
				}
			}
			ILCCJNDFFOB.HHCJCDFCLOB.CLGHLKLHEAK(JpStringLiterals.StringLiteral_16418, 0);
			MenuScene.Instance.Mount(TransitionUniqueId.DECO, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
		}

		// // RVA: 0x979E58 Offset: 0x979E58 VA: 0x979E58
		private void OnChangedDivaTalk(string msgLabel)
		{
			ApplyMessageText(msgLabel);
			EnterMessage();
		}

		// // RVA: 0x979E74 Offset: 0x979E74 VA: 0x979E74
		private void LoginBonusPopup()
		{
			return;
		}

		// // RVA: 0x979E78 Offset: 0x979E78 VA: 0x979E78
		private bool LoginBonusPopupSetting(PopupLoginBonusSetting setting)
		{
			if (setting == null)
				return false;
			PopupWindowManager.Show(setting, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x13C6A4C
				NKGJPJPHLIF.HHCJCDFCLOB.DHEFMDMGPMG_LoginBonusManager = null;
			}, null, null, null, true, true, false);
			m_updater = LoginBonusPopup;
			return true;
		}

		// // RVA: 0x97A068 Offset: 0x97A068 VA: 0x97A068
		private EPLAAEHPCDM GetTotalLoginBonus()
		{
			if(NKGJPJPHLIF.HHCJCDFCLOB.DHEFMDMGPMG_LoginBonusManager != null)
			{
				return NKGJPJPHLIF.HHCJCDFCLOB.DHEFMDMGPMG_LoginBonusManager.FMAMKPJMFHJ.Find((EPLAAEHPCDM _) =>
				{
					//0x13C6AE4
					return _.CKHOBDIKJFN_Type == ANPGILOLNFK.CDOGFBNLIPG.MKADAMIGMPO_7/*7*/;
				});
			}
			return null;
		}

		// // RVA: 0x97A284 Offset: 0x97A284 VA: 0x97A284
		private bool IsExistTotalLoginBonus()
		{
			return NKGJPJPHLIF.HHCJCDFCLOB.DHEFMDMGPMG_LoginBonusManager != null && GetTotalLoginBonus() != null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E3714 Offset: 0x6E3714 VA: 0x6E3714
		// // RVA: 0x97A338 Offset: 0x97A338 VA: 0x97A338
		private IEnumerator Coroutine_LoginBonusPopup()
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x13DA16C
			PopupLoginBonusSetting setting = null;
			if (IsExistTotalLoginBonus())
			{
				setting = new PopupLoginBonusSetting();
				setting.TitleText = MessageManager.Instance.GetBank("menu").GetMessageByLabel("popup_loginbonus_001");
				setting.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				setting.WindowSize = 0;
				setting.loginBonusManager = NKGJPJPHLIF.HHCJCDFCLOB.DHEFMDMGPMG_LoginBonusManager;
				operation = AssetBundleManager.LoadLayoutAsync(setting.BundleName, setting.AssetName);
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0x13C6D68
					instance.transform.SetParent(transform, false);
					setting.SetContent(instance);
				}));
				AssetBundleManager.UnloadAssetBundle(setting.BundleName, false);
				operation = null;
			}
			else
			{
				NKGJPJPHLIF.HHCJCDFCLOB.DHEFMDMGPMG_LoginBonusManager = null;
			}
			if(LoginBonusPopupSetting(setting))
			{
				yield return null;
				while (!PopupWindowManager.IsActivePopupWindow())
					yield return null;
				while (PopupWindowManager.IsActivePopupWindow())
					yield return null;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E378C Offset: 0x6E378C VA: 0x6E378C
		// // RVA: 0x97A3C0 Offset: 0x97A3C0 VA: 0x97A3C0
		private IEnumerator Co_MonthlyPassLoginBonusPopup()
		{
			//0x13D1094
			yield return PopupLoginBonusMonthlyPass.Show(0, false, null, (bool received) =>
			{
				//0x97D2E4
				m_subMenu.UpdateMonthlyPass();
			});
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E3804 Offset: 0x6E3804 VA: 0x6E3804
		// // RVA: 0x97A448 Offset: 0x97A448 VA: 0x97A448
		private IEnumerator Coroutine_ShowInformation()
		{
			//0x13DA8F8
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.IJHBIMNKOMC_TutorialEnd != 2)
				yield break;
			ShowInformation(false);
			while(m_isDisplayingInfo)
				yield return null;
			yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E387C Offset: 0x6E387C VA: 0x6E387C
		// // RVA: 0x97A4D0 Offset: 0x97A4D0 VA: 0x97A4D0
		private IEnumerator Co_HomeMissionAnnounce()
		{
			LAGEHKFIPPC localSaveData; // 0x18
			int currentDay; // 0x1C
			long currentTime; // 0x20
			//List.Enumerator<IKDICBBFBMI_EventBase> <>7__wrap4; // 0x28
			AMLGMLNGMFB_EventAprilFool.OLDLIIKHDKD view; // 0x38
			AssetBundleLoadLayoutOperationBase lyOp; // 0x3C

			//0x13CD970
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.IJHBIMNKOMC_TutorialEnd != 2)
				yield break;
			localSaveData = new LAGEHKFIPPC();
			localSaveData.PCODDPDFLHK_Load();
			currentDay = NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD;
			if (currentDay == localSaveData.KOGBMDOONFA.IDCGBCGNOLH_Day)
				yield break;
			if(currentDay < localSaveData.KOGBMDOONFA.IDCGBCGNOLH_Day)
			{
				localSaveData.KOGBMDOONFA.IDCGBCGNOLH_Day = currentDay;
				localSaveData.HJMKBCFJOOH_Save();
				yield break;
			}
			currentTime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			foreach(var it in JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN)
			{
				if(it.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.DAMDPLEBNCB_AprilFool)
				{
					if(it is AMLGMLNGMFB_EventAprilFool)
					{
						AMLGMLNGMFB_EventAprilFool af = it as AMLGMLNGMFB_EventAprilFool;
						view = af.PBPJDMGEMAO(currentTime);
						if (view != null)
						{
							if(view.DDIOHHEGANL != view.ELIFBFLFAFC)
							{
								HomeComebackPopup popup = null;
								lyOp = AssetBundleManager.LoadLayoutAsync("ly/006.xab", "root_home_mission_window_layout_root");
								yield return lyOp;
								yield return Co.R(lyOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject obj) =>
								{
									//0x13C6E10
									popup = obj.GetComponent<HomeComebackPopup>();
									popup.transform.SetParent(transform.parent, false);
								}));
								AssetBundleManager.UnloadAssetBundle("ly/006.xab", false);
								yield return Co.R(popup.Co_Open(m_bannerTexCache, view.CMJEGIEJNMD, view.DDIOHHEGANL, view.ELIFBFLFAFC));
								Destroy(popup.gameObject);
								localSaveData.KOGBMDOONFA.IDCGBCGNOLH_Day = currentDay;
								localSaveData.HJMKBCFJOOH_Save();
								view = null;
								lyOp = null;
							}
						}
					}
				}
			}

		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E38F4 Offset: 0x6E38F4 VA: 0x6E38F4
		// // RVA: 0x97A558 Offset: 0x97A558 VA: 0x97A558
		private IEnumerator Co_ShowRichBanner()
		{
			AssetBundleLoadLayoutOperationBase lyOp; // 0x18
			GameManager.PushBackButtonHandler backButtonAction; // 0x1C
			int i; // 0x20

			//0x13D7AEC
			if (m_richBannerData.FPCLGFKEEFE.Count == 0)
				yield break;
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.IJHBIMNKOMC_TutorialEnd != 2)
				yield break;
			bool isWait = true;
			HomeRichBanner richBanner = null;
			lyOp = AssetBundleManager.LoadLayoutAsync("ly/130.xab", "root_rich_banner_layout_root");
			yield return lyOp;
			yield return Co.R(lyOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject obj) =>
			{
				//0x13C6F20
				richBanner = obj.GetComponent<HomeRichBanner>();
				richBanner.transform.SetParent(transform.parent, false);
			}));
			AssetBundleManager.UnloadAssetBundle("ly/130.xab", false);
			richBanner.PushOkListener = () =>
			{
				//0x13C7028
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				isWait = false;
			};
			backButtonAction = () =>
			{
				//0x13C708C
				richBanner.PerformClick();
			};
			for(i = 0; i < m_richBannerData.FPCLGFKEEFE.Count; i++)
			{
				isWait = true;
				GameManager.Instance.AddPushBackButtonHandler(backButtonAction);
				yield return Co.R(richBanner.Open(m_richBannerData.FPCLGFKEEFE[i].DCHDFOIHMJL));
				while(isWait)
					yield return null;
				GameManager.Instance.RemovePushBackButtonHandler(backButtonAction);
				yield return Co.R(richBanner.Close());
			}
			richBanner.Release();
			Destroy(richBanner.gameObject);
			richBanner = null;
			m_richBannerData.HJMKBCFJOOH();
		}

		// // RVA: 0x97A5E0 Offset: 0x97A5E0 VA: 0x97A5E0
		private void OnClickBgViewStart()
		{
			if (TryLobbyAnnounce())
				return;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			MenuScene.Instance.Call(TransitionList.Type.HOME_BG_SELECT, new HomeBgSceneSelectArg(), true);
			this.StartCoroutineWatched(Co_WaitIdleCrossFade());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E396C Offset: 0x6E396C VA: 0x6E396C
		// // RVA: 0x97A730 Offset: 0x97A730 VA: 0x97A730
		private IEnumerator Co_ChangePopupLimtiedBg()
		{
			ILDKBCLAFPB.IPHAEFKCNMN saveData; // 0x18
			CGFNKMNBNBN t_master_homebg; // 0x1C
			int sceneId; // 0x20

			//0x13CA400
			saveData = GameManager.Instance.localSave.EPJOACOONAC_GetSave();
			if (!saveData.GBCEALJIKFN_Home.MBHHHMCCOLI(MenuScene.Instance.EnterToHomeTime))
				yield break;
			t_master_homebg = null;
			if (!CGFNKMNBNBN.CLBDFPACPKE(MenuScene.Instance.EnterToHomeTime, out t_master_homebg))
				yield break;
			PopupLimitedHomeBG.Setting s = new PopupLimitedHomeBG.Setting();
			MenuScene.Instance.InputDisable();
			s.m_bundle_id = t_master_homebg.KEFGPJBKAOD_BgId;
			s.m_time_zone = 0;
			s.WindowSize = SizeType.Middle;
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Change, Type = PopupButton.ButtonType.Positive }
			};
			CGFNKMNBNBN data;
			if(CGFNKMNBNBN.CLBDFPACPKE(MenuScene.Instance.EnterToHomeTime, out data))
			{
				s.m_bg_id = data.KEFGPJBKAOD_BgId;
			}
			MenuScene.Instance.InputEnable();
			bool t_change = false;
			bool t_end_popup = false;
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x13C70C0
				t_change = label == PopupButton.ButtonLabel.Change;
			}, null, null, null, endCallBaack:() =>
			{
				//0x13C70D4
				t_end_popup = true;
			});
			while(!t_end_popup)
				yield return null;
			saveData.GBCEALJIKFN_Home.HBGKPLDGGLF(t_master_homebg.GJFPFFBAKGK_CloseAt);
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
			if(!t_change)
				yield return null;
			saveData.CNLJNGLMMHB_Options.MHACPBAPBFE_BgMode = 0;
			MenuScene.Instance.BgControl.ReserveFade(0.1f, Color.black);
			sceneId = (int)t_master_homebg.PPFNGGCBJKC_Id;
			yield return Co.R(MenuScene.Instance.BgControl.ChangeHomeBgCoroutine(BgType.Home, sceneId, 0, CGFNKMNBNBN.MHJBBLBFHIB_IsHomeBgDark(), SceneGroupCategory.HOME, TransitionList.Type.HOME, -1));
			JKHEOEEPBMJ.NDFFOBHACPE_SetHomeSceneId(sceneId, 0);
			bool done = false;
			MenuScene.Save(() =>
			{
				//0x13C70E8
				done = true;
			}, null);
			while(!done)
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E39E4 Offset: 0x6E39E4 VA: 0x6E39E4
		// // RVA: 0x97A7A0 Offset: 0x97A7A0 VA: 0x97A7A0
		// private IEnumerator Co_WaitWhile(Func<bool> condition) { }

		// // RVA: 0x97A828 Offset: 0x97A828 VA: 0x97A828
		private void OnClickUIHideView(bool hidden)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(Co_UIHideAnimation(hidden));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E3A5C Offset: 0x6E3A5C VA: 0x6E3A5C
		// // RVA: 0x97A8A4 Offset: 0x97A8A4 VA: 0x97A8A4
		private IEnumerator Co_UIHideAnimation(bool hidden)
		{
			//0x13D8584
			MenuScene.Instance.InputDisable();
			m_isHiddenUI = hidden;
			if(!m_isHiddenUI)
			{
				m_subMenu.SetActive(true);
				m_buttonGroup.SetActive(true);
				m_eventBanner.SetActive(true);
				m_campaignBanner.SetActive(true);
				m_fesBanner.SetActive(true);
				m_leadBalloon.SetActive(true);
				m_playRecordBanner.SetActive(true);
				EnterIntimacy(0);
				MenuScene.Instance.HeaderMenu.Enter(true);
				MenuScene.Instance.FooterMenu.Enter(true);
				MenuScene.Instance.LobbyButtonControl.Show(true);
				if(m_isHomeShowDiva)
				{
					m_divaBalloon.SetActive(true);
				}
			}
			else
			{
				m_subMenu.SetActive(false);
				m_buttonGroup.SetActive(false);
				m_eventBanner.SetActive(false);
				m_campaignBanner.SetActive(false);
				m_fesBanner.SetActive(false);
				m_leadBalloon.SetActive(false);
				m_playRecordBanner.SetActive(false);
				LeaveIntimacy(0);
				MenuScene.Instance.HeaderMenu.Leave(true);
				MenuScene.Instance.FooterMenu.Leave(true);
				MenuScene.Instance.LobbyButtonControl.Hide(true);
				if(m_isHomeShowDiva)
				{
					m_divaBalloon.SetActive(false);
				}
			}
			while (m_subMenu.IsPlaying())
				yield return null;
			while (m_buttonGroup.IsPlaying())
				yield return null;
			while (m_eventBanner.IsPlaying())
				yield return null;
			while (m_campaignBanner.IsPlaying())
				yield return null;
			while (m_leadBalloon.IsPlaying())
				yield return null;
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0x97A948 Offset: 0x97A948 VA: 0x97A948
		private void OnClickPickupClose()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			m_pickupToClose = true;
		}

		// // RVA: 0x97A9AC Offset: 0x97A9AC VA: 0x97A9AC
		private void OnClickPickupJump()
		{
			m_pickupToJump = true;
		}

		// // RVA: 0x97A9B8 Offset: 0x97A9B8 VA: 0x97A9B8
		private void OnClickRejectCheckbox()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
		}

		// // RVA: 0x96F7D0 Offset: 0x96F7D0 VA: 0x96F7D0
		private void SetupPickup()
		{
			m_pickupList.Clear();
			m_pickupList.AddRange(JBCAHMMCOKK.FKDIMODKKJD(false));
			m_pickupBannerList.Clear();
			m_pickupBannerList.Capacity = m_pickupList.Count;
			m_pickupWebViewList.Clear();
			m_pickupWebViewList.Capacity = m_pickupList.Count;
			m_richBannerData.KHEKNNFCAOI();
			for(int i = 0; i < m_pickupList.Count; i++)
			{
				if(m_pickupList[i].LDLFAKLAMFG)
				{
					m_pickupBannerList.Add(m_pickupList[i]);
				}
				if(m_pickupList[i].AKGKKPGAJEM)
				{
					m_pickupWebViewList.Add(m_pickupList[i]);
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E3AD4 Offset: 0x6E3AD4 VA: 0x6E3AD4
		// // RVA: 0x97AA10 Offset: 0x97AA10 VA: 0x97AA10
		// private IEnumerator Co_ShowPickup() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E3B4C Offset: 0x6E3B4C VA: 0x6E3B4C
		// // RVA: 0x97AA98 Offset: 0x97AA98 VA: 0x97AA98
		// private IEnumerator Co_ShowPickup(JBCAHMMCOKK pickup) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E3BC4 Offset: 0x6E3BC4 VA: 0x6E3BC4
		// // RVA: 0x97AB3C Offset: 0x97AB3C VA: 0x97AB3C
		private IEnumerator Co_ShowPickupWebView()
		{
			int i;

			//0x13D71BC
			if(m_pickupWebViewList.Count > 0)
			{
				if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.IJHBIMNKOMC_TutorialEnd == 2)
				{
					MenuScene.Instance.InputDisable();
					for(i = 0; i < m_pickupWebViewList.Count; i++)
					{
						if(!m_isAbortIntro)
						{
							yield return Co.R(Co_ShowPickupWebView(m_pickupWebViewList[i]));
						}
					}
					MenuScene.Instance.InputEnable();
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E3C3C Offset: 0x6E3C3C VA: 0x6E3C3C
		// // RVA: 0x97ABC4 Offset: 0x97ABC4 VA: 0x97ABC4
		private IEnumerator Co_ShowPickupWebView(JBCAHMMCOKK pickup)
		{
			//0x13D754C
			if(pickup.CLDKMLONBHJ)
				yield break;
			bool webViewClose = false;
			bool isReject = false;
			bool netErrorToTitle = false;
			MBCPNPNMFHB.HHCJCDFCLOB.BJEJNAIDDME();
			if(pickup.ICKKKEIFKJP == JBCAHMMCOKK.CFBANNFILFK.GFGNICKOBBD_1)
			{
				MBCPNPNMFHB.HHCJCDFCLOB.FLLLPBIECCP(pickup.IAMFPLLOHFO, () =>
				{
					//0x13C71F0
					webViewClose = true;
					isReject = MBCPNPNMFHB.HHCJCDFCLOB.FIFIFFGGOGB();
				}, () =>
				{
					//0x13C729C
					netErrorToTitle = true;
					webViewClose = true;
				});
			}
			else if(pickup.ICKKKEIFKJP == JBCAHMMCOKK.CFBANNFILFK.GBAFHOOEKEA_2)
			{
				MBCPNPNMFHB.HHCJCDFCLOB.PBIKAGIOOHC(pickup.IAMFPLLOHFO, () =>
				{
					//0x13C7134
					webViewClose = true;
					isReject = MBCPNPNMFHB.HHCJCDFCLOB.FIFIFFGGOGB();
				}, () =>
				{
					//0x13C71E0
					netErrorToTitle = true;
					webViewClose = true;
				});
			}
			while(!webViewClose)
				yield return null;
			if(netErrorToTitle)
			{
				OnNetErrorToTitle();
			}
			if(isReject)
			{
				pickup.HLMIOEGBAKJ();
				JBCAHMMCOKK.CKGGMNGAMLC(m_pickupList);
			}
			MBCPNPNMFHB.HHCJCDFCLOB.HFONLKDDNMJ();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E3CB4 Offset: 0x6E3CB4 VA: 0x6E3CB4
		// // RVA: 0x97AC68 Offset: 0x97AC68 VA: 0x97AC68
		private IEnumerator Co_GetPaidVCProductList()
		{
			//0x13CD614
			bool isEnd = false;
			EJHPIMANJFP.HHCJCDFCLOB.LILDGEPCPPG_GetProductList(() =>
			{
				//0x13C72B4
				isEnd = true;
			}, () =>
			{
				//0x13C72C0
				isEnd = true;
			}, () =>
			{
				//0x13C72CC
				OnNetErrorToTitle();
			}, true, false);
			while (!isEnd)
				yield return null;
		}

		// // RVA: 0x97ACF0 Offset: 0x97ACF0 VA: 0x97ACF0
		private static string GetLeadBalloonDesc(PLADCDJLOBE leadData)
		{
			if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(leadData.DEKECNIBBIB_ItemFullId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
			{
				int idx = leadData.KLMPFGOCBHC_Desc.IndexOf('\n');
				if (idx > -1)
					return leadData.KLMPFGOCBHC_Desc.Remove(idx);
			}
			return leadData.KLMPFGOCBHC_Desc;
		}

		// // RVA: 0x96FAF8 Offset: 0x96FAF8 VA: 0x96FAF8
		private void SetupBeginnerLead()
		{
			m_leadBalloon.SetStyle(HomeBalloonText.Style.Beginner);
			m_leadBalloon.SetMessage(GetLeadBalloonDesc(m_balloonLeadData));
			m_leadBalloon.SetClearMark(m_balloonLeadData.JDBLMAHMHJO_IsAchieved);
			m_leadBalloon.onClickButton = OnClickBeginnerLead;
			if(m_balloonLeadData.DEKECNIBBIB_ItemFullId == 0)
				m_leadBalloon.SetExistsItem(false);
			else
			{
				m_leadBalloon.SetExistsItem(true);
				GameManager.Instance.ItemTextureCache.Load(m_balloonLeadData.DEKECNIBBIB_ItemFullId, (IiconTexture image) =>
				{
					//0x97D318
					m_leadBalloon.SetItemIcon(image);
				});
			}
		}

		// // RVA: 0x96FD5C Offset: 0x96FD5C VA: 0x96FD5C
		private void SetupMissionLead()
		{
			m_leadBalloon.SetStyle(HomeBalloonText.Style.Mission);
			m_leadBalloon.SetMessage(GetLeadBalloonDesc(m_balloonLeadData));
			m_leadBalloon.SetClearMark(m_balloonLeadData.JDBLMAHMHJO_IsAchieved);
			m_leadBalloon.onClickButton = OnClickMissionLead;
			if (m_balloonLeadData.DEKECNIBBIB_ItemFullId == 0)
				m_leadBalloon.SetExistsItem(false);
			else
			{
				m_leadBalloon.SetExistsItem(true);
				GameManager.Instance.ItemTextureCache.Load(m_balloonLeadData.DEKECNIBBIB_ItemFullId, (IiconTexture image) =>
				{
					//0x97D348
					m_leadBalloon.SetItemIcon(image);
				});
			}
		}

		// // RVA: 0x96FFC0 Offset: 0x96FFC0 VA: 0x96FFC0
		private void SetupStoryLead()
		{
			m_leadBalloon.SetStyle(HomeBalloonText.Style.Music);
			m_leadBalloon.SetMessage(GetLeadBalloonDesc(m_balloonLeadData));
			m_leadBalloon.SetClearMark(m_balloonLeadData.JDBLMAHMHJO_IsAchieved);
			m_leadBalloon.onClickButton = OnClickStoryLead;
		}

		// // RVA: 0x970118 Offset: 0x970118 VA: 0x970118
		private void SetupStoryDivaLead()
		{
			m_leadBalloon.SetStyle(HomeBalloonText.Style.Diva);
			GameManager.Instance.DivaIconCache.LoadStoryIcon(m_balloonLeadData.PAAGIJHEIHK, 1, (IiconTexture image) =>
			{
				//0x97D378
				if(m_leadBalloon != null)
					return;
			});
			m_leadBalloon.SetMessage(GetLeadBalloonDesc(m_balloonLeadData));
			m_leadBalloon.SetClearMark(m_balloonLeadData.JDBLMAHMHJO_IsAchieved);
			m_leadBalloon.onClickButton = OnClickStoryLead;
		}

		// // RVA: 0x970358 Offset: 0x970358 VA: 0x970358
		private void SetupStorySnsLead()
		{
			m_leadBalloon.SetStyle(HomeBalloonText.Style.Sns);
			m_leadBalloon.SetMessage(GetLeadBalloonDesc(m_balloonLeadData));
			m_leadBalloon.SetClearMark(m_balloonLeadData.JDBLMAHMHJO_IsAchieved);
			m_leadBalloon.onClickButton = OnClickStoryLead;
		}

		// // RVA: 0x9704B0 Offset: 0x9704B0 VA: 0x9704B0
		private void SetupEventHomeLead()
		{
			m_leadBalloon.SetStyle(HomeBalloonText.Style.Event);
			m_leadBalloon.SetMessage(GetLeadBalloonDesc(m_balloonLeadData));
			m_leadBalloon.onClickButton = OnClickEventLead;
			if(m_balloonLeadData.DEKECNIBBIB_ItemFullId != 0)
			{
				m_leadBalloon.SetExistsItem(true);
				GameManager.Instance.ItemTextureCache.Load(m_balloonLeadData.DEKECNIBBIB_ItemFullId, (IiconTexture image) =>
				{
					//0x97D38C
					m_leadBalloon.SetItemIcon(image);
				});
			}
			else
			{
				m_leadBalloon.SetExistsItem(false);
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E3D2C Offset: 0x6E3D2C VA: 0x6E3D2C
		// // RVA: 0x97ADFC Offset: 0x97ADFC VA: 0x97ADFC
		private IEnumerator Co_SnsScreen()
		{
			//0x13D8380
			yield return Co.R(Co_OpenSnsScreen());
			if(m_snsScreen != null)
			{
				while(m_snsScreen.IsPlaying)
					yield return null;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E3DA4 Offset: 0x6E3DA4 VA: 0x6E3DA4
		// // RVA: 0x973C9C Offset: 0x973C9C VA: 0x973C9C
		private IEnumerator Co_OpenSnsScreen()
		{
			//0x13D1CC0
			GameManager.Instance.CloseSnsNotice();
			if (m_snsScreen == null)
			{
				MenuScene.Instance.InputDisable();
				m_snsScreen = SnsScreen.Create(transform.parent);
				yield return null;
				m_snsScreen.Initialize(0, false);
				m_snsScreen.OutStartCallback = () =>
				{
					//0x97D3BC
					this.StartCoroutineWatched(Co_ClosingSnsScreen());
				};
				MenuScene.Instance.InputEnable();
			}
			else
			{
				m_snsScreen.Initialize(0, false);
			}
			MenuScene.Instance.InputDisable();
			if(m_isHomeShowDiva)
			{
				this.StartCoroutineWatched(m_divaControl.Coroutine_IdleCrossFade());
				m_divaTalk.CancelRequest();
				m_divaTalk.TimerStop();
			}
			if (MenuScene.CheckDatelineAndAssetUpdate())
				yield break;
			m_snsScreen.In(SnsScreen.eSceneType.Menu, SNSController.eObjectOrderType.Last, false);
			while (m_snsScreen != null && m_snsScreen.IsPlaying)
				yield return null;
			MenuScene.Instance.InputEnable();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E3E1C Offset: 0x6E3E1C VA: 0x6E3E1C
		// // RVA: 0x97AE84 Offset: 0x97AE84 VA: 0x97AE84
		private IEnumerator Co_ClosingSnsScreen()
		{
			Stopwatch sw; // 0x14
			BgmPlayer bgmPlayer; // 0x18

			//0x13CB4E8
			MenuScene.Instance.InputDisable();
			m_balloonLeadData = PLADCDJLOBE.HEGEKFMJNCC();
			if(isValidBalloonLead)
			{
				if(m_balloonLeadData.MMMGMNAMGDF == PLADCDJLOBE.PNLNGHNHCNI.KJHABBHBFPD/*1*/)
				{
					SetupMissionLead();
				}
				else if(m_balloonLeadData.MMMGMNAMGDF == PLADCDJLOBE.PNLNGHNHCNI.NHANNKGPAHM/*0*/)
				{
					SetupBeginnerLead();
				}
			}
			m_subMenu.ApplyNewIcons();
			sw = new Stopwatch();
			sw.Start();
			bgmPlayer = SoundManager.Instance.bgmPlayer;
			while(bgmPlayer.isFading)
			{
				if (sw.Elapsed.Milliseconds < 3001)
					yield return null;
				else
					break;
			}
			while(!bgmPlayer.isPlaying)
			{
				if (sw.Elapsed.Milliseconds < 3001)
					yield return null;
				else
					break;
			}
			sw.Stop();
			while (m_snsScreen != null && m_snsScreen.IsPlaying)
				yield return null;
			if(m_isHomeShowDiva)
			{
				m_divaTalk.TimerRestart();
			}
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0x97AF0C Offset: 0x97AF0C VA: 0x97AF0C
		private bool IsCenterKaname()
		{
			return GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].AHHJLDLAPAN_DivaId == 3;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E3E94 Offset: 0x6E3E94 VA: 0x6E3E94
		// // RVA: 0x97B034 Offset: 0x97B034 VA: 0x97B034
		private IEnumerator Co_BeginnerMissionMiniAdv()
		{
			BasicTutorialMessageId messageId; // 0x1C
			List<GJDFHLBONOL> presentList; // 0x20
			
			//0x13C9190
			MenuScene.Instance.InputDisable();
			BasicTutorialManager.Initialize();
			BasicTutorialManager mrg = BasicTutorialManager.Instance;
			bool isWait = true;
			messageId = IsCenterKaname() ? BasicTutorialMessageId.Id_StartMission2 : BasicTutorialMessageId.Id_StartMission1;
			mrg.PreLoadResource(() =>
			{
				//0x13C7300
				isWait = false;
			}, true);
			while(isWait)
				yield return null;
			yield return Co.R(mrg.PreDownLoadTextureResource(messageId));
			isWait = true;
			bool err = false;
			CIOECGOMILE.HHCJCDFCLOB.KPFKKDDOHCN.MHMOFLCJDPH_FirstPresent(() =>
			{
				//0x13C730C
				isWait = false;
			}, () =>
			{
				//0x13C7318
				isWait = false;
				err = true;
			});
			while(isWait)
				yield return null;
			if(err)
			{
				//LAB_013c9ab8
				//LAB_013c9ce8
				//LAB_013c9cf8
				MenuScene.Instance.GotoTitle();
				yield break;
			}
			MenuScene.Instance.InputEnable();
			presentList = CIOECGOMILE.HHCJCDFCLOB.KPFKKDDOHCN.PGFCIDHBMNB;
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.AABHAHFCEMF();
			if(presentList.Count != 0)
			{
				isWait = true;
				mrg.ShowMessageWindow(messageId, () =>
				{
					//0x13C7324
					isWait = false;
				}, null);
				while(isWait)
					yield return null;
				bool isError = false;
				isWait = true;
				MenuScene.Instance.InputDisable();
				CIOECGOMILE.HHCJCDFCLOB.KPFKKDDOHCN.EAOGDGAEJPH(() =>
				{
					//0x13C7330
					isWait = false;
				}, (CACGCMBKHDI_Request error) =>
				{
					//0x13C73AC
					isWait = false;
					isError = true;
				});
				while(isWait)
					yield return null;
				if(isError)
				{
					MenuScene.Instance.GotoTitle();
					yield break;	
				}
				ILLPDLODANB.IHKAKFFAGPC(ILLPDLODANB.LOEGALDKHPL.PBKOKCHKGGL_46);
				isError = false;
				isWait = true;
				CIOECGOMILE.HHCJCDFCLOB.PKKCKFCLACK(presentList, () =>
				{
					//0x13C733C
					isWait = false;
				}, null, () =>
				{
					//0x13C73E0
					isError = true;
					isWait = false;
				}, false);
				while(isWait)
					yield return null;
				if(isError)
				{
					MenuScene.Instance.GotoTitle();
					yield break;	
				}
				MenuScene.Instance.InputEnable();
				GameManager.Instance.ResetViewPlayerData();
				yield return this.StartCoroutineWatched(PopupRecordPlate.Show(RecordPlateUtility.eSceneType.PresentBox, () =>
				{
					//0x13C6B18
					ILLPDLODANB.ILOGJDALEOO();
				}, true));
			}
			//LAB_013c95ec
			isWait = true;
			messageId = BasicTutorialMessageId.Id_StartMission3;
			mrg.ShowMessageWindow(BasicTutorialMessageId.Id_StartMission3, () =>
			{
				//0x13C7348
				isWait = false;
			}, null);
			while(isWait)
				yield return null;
			isWait = true;
			mrg.SetInputLimit(InputLimitButton.Mission, () =>
			{
				//0x13C7354
				mrg.SetInputLimit(InputLimitButton.None, null, null, TutorialPointer.Direction.Normal);
				isWait = false;
			}, null, TutorialPointer.Direction.Normal);
			while(isWait)
				yield return null;
		}

		// // RVA: 0x97B0BC Offset: 0x97B0BC VA: 0x97B0BC
		// private bool CheckTutorialFunc(TutorialConditionId conditionId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E3F0C Offset: 0x6E3F0C VA: 0x6E3F0C
		// // RVA: 0x97B73C Offset: 0x97B73C VA: 0x97B73C
		private IEnumerator Coroutine_EventReward()
		{
			List<IKDICBBFBMI_EventBase> eventControlers; // 0x18
			int i; // 0x1C
			IKDICBBFBMI_EventBase eventController; // 0x20
			int rankingNum; // 0x24
			int n; // 0x28
			int rankingIndex; // 0x2C

			//0x13D9054
			m_isCheckEventReward = true;
            IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DDEODFNANDO_8_ResultRewardToReceive/*8*/, false);
			if(ev != null && ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.MKKOHBGHADL_2/*2*/)
			{
				TodoLogger.LogError(TodoLogger.Event_Unknwown_2, "Coroutine_EventReward");
			}
			bool isShowReward = false;
			bool isError = false;
			bool isEnd = false;
			bool isCallRanking = false;
			eventControlers = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN;
			for(i = 0; i < eventControlers.Count; i++)
			{
				long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				eventController = eventControlers[i];
				eventController.HCDGELDHFHB_UpdateStatus(time);
				if(eventController.NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DDEODFNANDO_8_ResultRewardToReceive/*8*/)
				{
					rankingNum = eventController.NGIHFKHOJOK_GetRankingMax(false);
					for(n = 0; n < rankingNum; n++)
					{
						rankingIndex = eventController.DEECKJADNMJ(n);
						if(!eventController.PIDEAJOJKKC(rankingIndex))
						{
							eventController.LHAEPPFACOB_SetRewardReceived(rankingIndex, true);
						}
						else
						{
							eventController.FPPNKEPDEBL(rankingIndex);
							while (!eventController.PLOOEECNHFB)
								yield return null;
							if(eventController.NPNNPNAIONN)
							{
								OnNetErrorToTitle();
								yield return null;
								yield break;
							}
							isEnd = false;
							isError = false;
							CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
							{
								//0x13C7418
								isEnd = true;
							}, () =>
							{
								//0x13C7424
								isEnd = true;
								isError = true;
							}, null);
							while (!isEnd)
								yield return null;
							if(isError)
							{
								OnNetErrorToTitle();
								yield return null;
								yield break;
							}
							if(eventController.HLFHJIDHJMP != null)
							{
								isShowReward = false;
								isCallRanking = false;
								CIOECGOMILE.HHCJCDFCLOB.KPFKKDDOHCN.ECFNAOCFKKN_Date = 0;
								NKGJPJPHLIF.HHCJCDFCLOB.OLDKENOLHLL = 0;
								this.StartCoroutineWatched(PopupRewardEvResult.Co_ShowPopup_Ranking(rankingIndex, eventController, transform, rankingIndex + 1, (PopupWindowControl ctl, PopupButton.ButtonType type, PopupButton.ButtonLabel lbl) =>
								{
									//0x13C7430
									if (lbl == PopupButton.ButtonLabel.FinalRankings)
										isCallRanking = true;
								}, () =>
								{
									//0x13C7440
									isShowReward = true;
								}));
								while (!isShowReward)
									yield return null;
								if(isCallRanking)
								{
									EventRankingSceneArgs arg = new EventRankingSceneArgs(eventController, false, n, 0);
									MenuScene.Instance.Call(TransitionList.Type.EVENT_RANKING, arg, true);
									yield break;
								}
							}
						}
					}
				}
			}
			eventControlers = null;
			yield return null;
			//7
			m_isCheckEventReward = false;
        }

		// [IteratorStateMachineAttribute] // RVA: 0x6E3F84 Offset: 0x6E3F84 VA: 0x6E3F84
		// // RVA: 0x97B7C4 Offset: 0x97B7C4 VA: 0x97B7C4
		private IEnumerator Coroutine_ShowUnlock(Action onTransition)
		{
			//0x13DAB40
			yield return Co.R(PopupUnlock.Show(PopupUnlock.eSceneType.Home, (int label) => {
				//0x13C75E0
				if(label != 45)
					return;
				onTransition();
			}, true, null));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E3FFC Offset: 0x6E3FFC VA: 0x6E3FFC
		// // RVA: 0x97B84C Offset: 0x97B84C VA: 0x97B84C
		private IEnumerator Co_CheckPlayerForceRename(Action onTransition)
		{
			//0x13CAF10
			if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.FNLNIKFNHAM_ForceRename)
				yield break;
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.FNLNIKFNHAM_ForceRename = false;
			MenuScene.SaveRequest();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			bool isClosed = false;
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("popup_home_ngword_rename_title"),
				SizeType.Small, bk.GetMessageByLabel("popup_home_ngword_rename_msg"), new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				}, false, true), (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x13C761C
				isClosed = true;
			}, null, null, null);
			while(!isClosed)
				yield return null;
			onTransition();
			MenuScene.Instance.Mount(TransitionUniqueId.OPTIONMENU_PROFIL, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
		}

		// // RVA: 0x97B8D4 Offset: 0x97B8D4 VA: 0x97B8D4
		// private bool RaidEventApHeal() { }

		// // RVA: 0x971360 Offset: 0x971360 VA: 0x971360
		private bool CanRareBreakAdv()
		{
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.IJHBIMNKOMC_TutorialEnd == 2)
			{
				int id = GetRareBreakAdvId();
				if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.FABEJIHKFGN_IsReleased(id) == false)
				{
					return NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.GGBCCADCPNP();
				}
			}
			return false;
		}

		// // RVA: 0x97BC14 Offset: 0x97BC14 VA: 0x97BC14
		private int GetRareBreakAdvId()
		{
			CEBFFLDKAEC_SecureInt val = new CEBFFLDKAEC_SecureInt();
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.OHJFBLFELNK_CryptedIntValues.TryGetValue("rare_break_adv_id", out val))
			{
				return val.DNJEJEANJGL_Value;
			}
			return 128;
		}

		// // RVA: 0x97155C Offset: 0x97155C VA: 0x97155C
		private bool CanGetEventAdv()
		{
			return m_eventAdvId > 0;
		}

		// // RVA: 0x970F60 Offset: 0x970F60 VA: 0x970F60
		private int GetEventAdvId()
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.IJHBIMNKOMC_TutorialEnd == 2)
			{
				for(int i = 0; i < JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN.Count; i++)
				{
					IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN[i];
					int advId = ev.BAEPGOAMBDK("adv_id", 0);
					if (advId > 0)
					{
						if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.FABEJIHKFGN_IsReleased(advId))
						{
							long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
							if(time >= ev.GLIMIGNNGGB_Start)
							{
								if (ev.DPJCPDKALGI_End1 >= time)
									return advId;
							}
						}
					}
				}
			}
			return 0;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E4074 Offset: 0x6E4074 VA: 0x6E4074
		// // RVA: 0x97BD8C Offset: 0x97BD8C VA: 0x97BD8C
		private IEnumerator Co_InitIntimacy()
		{
			//0x13CE3F
			m_isInitIntimacy = false;
			m_intimacyControl = MenuScene.Instance.IntimacyControl;
			m_intimacyControl.InitHome(this, m_divaBalloon, m_divaTalk, null);
			if(m_divaTalk != null)
			{
				m_divaTalk.viewIntimacyData = m_intimacyControl.viewData;
			}
			m_uiCamera = GetComponentInParent<Canvas>().worldCamera;
			yield return new WaitWhile(() => {
				//0x97D3E0
				return m_intimacyControl.IsLoading();
			});
			m_isInitIntimacy = true;
		}

		// // RVA: 0x972210 Offset: 0x972210 VA: 0x972210
		private void EnterIntimacy()
		{
			m_intimacyControl.EnterCounter();
			m_intimacyControl.EnableLongTouchTips();
			m_intimacyControl.EnterLongTouchTips(false);
		}

		// // RVA: 0x97BE14 Offset: 0x97BE14 VA: 0x97BE14
		private void EnterIntimacy(float animTime)
		{
			m_intimacyControl.EnterCounter(animTime);
			m_intimacyControl.EnableLongTouchTips();
			m_intimacyControl.EnterLongTouchTips(animTime, true);
		}

		// // RVA: 0x9727F8 Offset: 0x9727F8 VA: 0x9727F8
		private void LeaveIntimacy()
		{
			m_intimacyControl.LeaveCounter();
			m_intimacyControl.DisableLongTouchTips();
			m_intimacyControl.LeaveLongTouchTips(false);
		}

		// // RVA: 0x97BE94 Offset: 0x97BE94 VA: 0x97BE94
		private void LeaveIntimacy(float animTime)
		{
			m_intimacyControl.LeaveCounter(animTime);
			m_intimacyControl.DisableLongTouchTips();
			m_intimacyControl.LeaveLongTouchTips(animTime, true);
		}

		// // RVA: 0x97BF14 Offset: 0x97BF14 VA: 0x97BF14
		private void StartIntimacyUp(CharTouchButton button)
		{
			if(m_divaTalk.IsEnableReaction())
			{
				if(m_intimacyControl.CheckUnlock())
				{
					m_divaTalk.TimerRestart();
					m_divaTalk.TimerStop();
					m_buttonGroup.buttonUIHide.IsInputLock = true;
					m_intimacyControl.StartIntimacyUp(button, (bool success) =>
					{
						//0x13C7630
						if(success)
						{
							SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_INTIMACY_001);
							m_divaTalk.DoIntimacyReaction(null);
						}
						else
						{
							m_buttonGroup.buttonUIHide.IsInputLock = false;
						}
						m_divaTalk.TimerStart();
					}, () =>
					{
						//0x13C775C
						m_buttonGroup.buttonUIHide.IsInputLock = false;
					}, () =>
					{
						//0x13C77C0
						return ContinueConfirm(button);
					});
				}
			}
		}

		// // RVA: 0x97C180 Offset: 0x97C180 VA: 0x97C180
		private bool ContinueConfirm(CharTouchButton button)
		{
			TouchInfoRecord record = InputManager.Instance.GetTouchInfoRecord(0);
			if (record != null)
			{
				TouchInfo info = record.beganInfo;
				if (record.currentInfo != null)
					info = record.currentInfo;
				if(!info.isIllegal)
				{
					if(RectTransformUtility.RectangleContainsScreenPoint(button.GetComponent<RectTransform>(), info.GetSceneInnerPosition()))
					{
						if (info.isBegan)
							return true;
						return info.isMoved;
					}
				}
			}
			return false;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E40EC Offset: 0x6E40EC VA: 0x6E40EC
		// // RVA: 0x97C348 Offset: 0x97C348 VA: 0x97C348
		private IEnumerator Co_LimitedItemWarning()
		{
			int i;

			//0x13CF5B8
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave == null)
				yield break;
			if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database == null)
				yield break;
			if (NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI == null)
				yield break;
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			m_coLimitedItemList.Clear();
			int period = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DPNKPPBEAGJ_RareUpItem.JCJKKMECCFI(time);
			m_coLimitedItemList.Add(new limitedWarning(Co_RareupStarLimitPopup(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.CIOGEKJNMBB_RareUpItem, 1), CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DPNKPPBEAGJ_RareUpItem.LDLCGGACHGA(time), time, period), period));
			List<int> l = new List<int>();
			l.Add(1);
			l.Add(2);
			l.Add(3);
			for(i = 0; i < l.Count; i++)
			{
				List<LOBDIAABMKG> l2 = NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.NDALDMHNMKI(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.DLOPEFGOAPD_LimitedItem, l[i]));
				if(l2.Count > 0)
				{
					period = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.AFHFIPLOKMN_LimitedItem.BLKPKBICPKK(l[i], time);
					if (l[i] > 0 || l2[0].EABMLBFHJBH_CloseAt >= period)
					{
						m_coLimitedItemList.Add(new limitedWarning(Co_LimitedItemPeriodPopup(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.DLOPEFGOAPD_LimitedItem, l[i]), CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.AFHFIPLOKMN_LimitedItem.HPPKOGKNKMH(l[i], time), time, period), period));
					}
					else
					{
						m_coLimitedItemList.Add(new limitedWarning(Co_LimitedItemPeriodPopup(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.DLOPEFGOAPD_LimitedItem, l[i]), CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.AFHFIPLOKMN_LimitedItem.HPPKOGKNKMH(l[i], time), time, period), period));
					}
				}
			}
			m_coLimitedItemList.Sort((limitedWarning a, limitedWarning b) =>
			{
				//0x13C6B94
				return a.limit_time.CompareTo(b.limit_time);
			});
			for(i = 0; i < m_coLimitedItemList.Count; i++)
			{
				yield return Co.R(m_coLimitedItemList[i].col_action);
			}
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E4164 Offset: 0x6E4164 VA: 0x6E4164
		// // RVA: 0x97C3D0 Offset: 0x97C3D0 VA: 0x97C3D0
		private IEnumerator Co_RareupStarLimitPopup(int itemId, int itemCount, long currentTime, long period)
		{
			ILDKBCLAFPB.FIDNFICGLEE_LimitedItemWarning saveData_limit;

			//0x13D22A8
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave == null)
				yield break;
			if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database == null)
				yield break;
			bool isClose = false;
			saveData_limit = GameManager.Instance.localSave.EPJOACOONAC_GetSave().KPHPNFBBLPA_LimitedItemWarning;
			TimeSpan timeSpan;
			int p = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DPNKPPBEAGJ_RareUpItem.JCJKKMECCFI(currentTime);
			if (IsShowLimitedPopup(currentTime, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, saveData_limit.DIKBJMJBOIL_RateUpDate, period, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("limited_item_show_warning_time", 3), out timeSpan))
			{
				yield return ShowLimitedItemPopup(itemId, itemCount, p, timeSpan, () =>
				{
					//0x13C77FC
					isClose = true;
				});
				while (!isClose)
					yield return null;
				saveData_limit.DIKBJMJBOIL_RateUpDate = currentTime;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E41DC Offset: 0x6E41DC VA: 0x6E41DC
		// // RVA: 0x97C4A8 Offset: 0x97C4A8 VA: 0x97C4A8
		private IEnumerator Co_LimitedItemPeriodPopup(int itemId, int itemCount, long currentTime, long period)
		{
			int itemValue; // 0x2C
			ILDKBCLAFPB.FIDNFICGLEE_LimitedItemWarning saveDataLimit; // 0x30

			//0x13CEFD4
			bool isClose = false;
			itemValue = EKLNMHFCAOI.DEACAHNLMNI_getItemId(itemId);
			saveDataLimit = GameManager.Instance.localSave.EPJOACOONAC_GetSave().KPHPNFBBLPA_LimitedItemWarning;
			long t = 0;
			if(itemValue == 3)
			{
				t = saveDataLimit.NKJODNGKFPB_LimitedItemGachaTicketDate;
			}
			else if(itemValue == 2)
			{
				t = saveDataLimit.LANFKFKIADL_LogboGachaTicketDate;
			}
			else if(itemValue == 1)
			{
				t = saveDataLimit.HCKHMGNIKMB_GachaTicketDate;
			}
			TimeSpan ts;
			int range = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("limited_item_show_warning_time", 3);
			long expire = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.AFHFIPLOKMN_LimitedItem.BLKPKBICPKK(itemValue, currentTime);
			if(IsShowLimitedPopup(currentTime, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, t, expire, range, out ts))
			{
				yield return Co.R(ShowLimitedItemPopup(itemId, itemCount, (int)expire, ts, () =>
				{
					//0x13C7810
					isClose = true;
				}));
				while(!isClose)
					yield return null;
				if(itemValue == 3)
				{
					saveDataLimit.NKJODNGKFPB_LimitedItemGachaTicketDate = currentTime;
				}
				else if(itemValue == 2)
				{
					saveDataLimit.LANFKFKIADL_LogboGachaTicketDate = currentTime;
				}
				else if(itemValue == 1)
				{
					saveDataLimit.HCKHMGNIKMB_GachaTicketDate = currentTime;
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E4254 Offset: 0x6E4254 VA: 0x6E4254
		// // RVA: 0x97C57C Offset: 0x97C57C VA: 0x97C57C
		private IEnumerator Co_LimitedItemGachaProductPeriodPopup(int itemId, int itemCount, long currentTime, long period)
		{
			int itemValue; // 0x30
			ILDKBCLAFPB.FIDNFICGLEE_LimitedItemWarning saveDataLimit; // 0x34
			MessageBank bank; // 0x38
			PopupItemGachaPeriodConfirmSetting setting; // 0x3C

			//0x13CE6E4
			bool isClose = false;
			itemValue = EKLNMHFCAOI.DEACAHNLMNI_getItemId(itemId);
			saveDataLimit = GameManager.Instance.localSave.EPJOACOONAC_GetSave().KPHPNFBBLPA_LimitedItemWarning;
			long a = 0;
			if(itemValue == 3)
			{
				a = saveDataLimit.NKJODNGKFPB_LimitedItemGachaTicketDate;
			}
			else if(itemValue == 2)
			{
				a = saveDataLimit.LANFKFKIADL_LogboGachaTicketDate;
			}
			else if(itemValue == 1)
			{
				a = saveDataLimit.HCKHMGNIKMB_GachaTicketDate;
			}
			int gacha_period_show_warning_time = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("gacha_period_show_warning_time", 0);
			TimeSpan ts;
			if(!IsShowLimitedPopup(currentTime, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, a, period, gacha_period_show_warning_time, out ts))
				yield break;
			bank = MessageManager.Instance.GetBank("menu");
			setting = new PopupItemGachaPeriodConfirmSetting();
			yield return Co.R(setting.LoadAssetBundlePrefab(transform));
			EKLNMHFCAOI.ADGMGNKCIGA(itemId);
			string name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(itemId);
			setting.TypeItemId = itemId;
			setting.Period = period;
			setting.OwnCount = itemCount;
			setting.TitleText = bank.GetMessageByLabel("pop_gacha_period_warning_title");
			setting.OverrideText = string.Format(bank.GetMessageByLabel("pop_gacha_period_warning_text_1"), name);
			setting.Cost = 0;
			setting.WindowSize = SizeType.Middle;
			setting.HideUseNum = true;
			setting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			PopupWindowManager.Show(setting, (PopupWindowControl cont, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x13C7824
				isClose = true;
			}, null, null, null);
			while(!isClose)
				yield return null;
			if(itemValue == 3)
			{
				saveDataLimit.NKJODNGKFPB_LimitedItemGachaTicketDate = currentTime;
			}
			else if(itemValue == 2)
			{
				saveDataLimit.LANFKFKIADL_LogboGachaTicketDate = currentTime;
			}
			else if(itemValue == 1)
			{
				saveDataLimit.HCKHMGNIKMB_GachaTicketDate = currentTime;
			}
		}

		// // RVA: 0x97C684 Offset: 0x97C684 VA: 0x97C684
		public bool IsShowLimitedPopup(long currentTime, OKGLGHCBCJP_Database md, long localSaveTime, long experioAt, int rangeTime, out TimeSpan limited_data_span)
		{
			DateTime current = Utility.GetLocalDateTime(currentTime);
			DateTime startCurrent = new DateTime(current.Year, current.Month, current.Day);
			DateTime localSave = Utility.GetLocalDateTime(localSaveTime);
			TimeSpan diff = localSave - startCurrent;
			DateTime expire = Utility.GetLocalDateTime(experioAt);
			TimeSpan diff2 = expire - startCurrent;
			limited_data_span = diff2;
			bool b = false;
			if(localSaveTime < currentTime)
			{
				if (0 <= diff.TotalDays)
					b = true;
			}
			return b && (experioAt - currentTime) != 0 && limited_data_span.Days <= rangeTime;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E42CC Offset: 0x6E42CC VA: 0x6E42CC
		// // RVA: 0x97C8C4 Offset: 0x97C8C4 VA: 0x97C8C4
		private IEnumerator ShowLimitedItemPopup(int itemId, int itemCount, int period, TimeSpan limitedSpan, Action close)
		{
			MessageBank msg; // 0x34
			PopupItemUseConfirmSetting setting; // 0x38

			//0x13DAD20
			msg = MessageManager.Instance.GetBank("menu");
			setting = new PopupItemUseConfirmSetting();
			setting.Cost = 0;
			setting.WindowSize = SizeType.Middle;
			setting.HideUseNum = true;
			setting.TypeItemId = itemId;
			setting.OwnCount = itemCount;
			setting.Period = period;
			setting.TitleText = msg.GetMessageByLabel("pop_limited_item_warning_title");
			setting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			yield return Co.R(setting.LoadAssetBundlePrefab(transform));
			string str;
			if(limitedSpan.TotalDays < 1)
			{
				str = string.Format(msg.GetMessageByLabel("pop_limited_item_warning_text_2"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(itemId));
			}
			else
			{
				str = string.Format(msg.GetMessageByLabel("pop_limited_item_warning_text_1"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(itemId), limitedSpan.TotalDays);
			}
			setting.OverrideText = str;
			PopupWindowManager.Show(setting, (PopupWindowControl cont, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x13C7838
				close();
			}, null, null, null);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E4344 Offset: 0x6E4344 VA: 0x6E4344
		// // RVA: 0x97C9E0 Offset: 0x97C9E0 VA: 0x97C9E0
		private IEnumerator Co_CurrencyItemWarning()
		{
			int i;

			//0x13CCB60
			m_coCurrencyItemList.Clear();
			if (NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI == null)
				yield break;
			for(i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GKMAHADAAFI_GachaTicket.DHIACJMOEBH.Count; i++)
			{
				int ticketId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GKMAHADAAFI_GachaTicket.DHIACJMOEBH[i];
				List<HPBDNNACBAK.MBMMGKJBJGD> l = NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.GGKFCDDFHFP.FindAll((HPBDNNACBAK.MBMMGKJBJGD x) =>
				{
					//0x13C786C
					return x.PPFNGGCBJKC_Id == ticketId;
				});
				if(l.Count > 0)
				{
					long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
					long p = l[0].DJJENNPDPCM_ExpireAt;
					int count = 0;
					for (int j = 0; j < l.Count; j++)
					{
						count += l[i].HNBFOAJIIAL_Remaining;
					}
					if(HPBDNNACBAK.FIHFDIBDKKE(ticketId))
					{
						m_coCurrencyItemList.Add(new limitedWarning(Co_CurrencyItemPeriodPopup(ticketId, count, time, p), p));
					}
					else
					{
						List<LOBDIAABMKG> l2 = NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.FIGBNDFBKPE(ticketId);
						if (l2.Count < 1)
							continue;
						if(l2[0].EABMLBFHJBH_CloseAt >= p)
						{
							m_coCurrencyItemList.Add(new limitedWarning(Co_CurrencyItemPeriodPopup(ticketId, count, time, p), p));
						}
						else
						{
							m_coCurrencyItemList.Add(new limitedWarning(Co_CurrencyItemGachaProductPeriodPopup(ticketId, count, time, l2[0].EABMLBFHJBH_CloseAt), l2[0].EABMLBFHJBH_CloseAt));
						}
					}
				}
			}
			m_coCurrencyItemList.Sort((limitedWarning a, limitedWarning b) =>
			{
				//0x13C6BE4
				return a.limit_time.CompareTo(b.limit_time);
			});
			for(i = 0; i < m_coCurrencyItemList.Count; i++)
			{
				yield return Co.R(m_coCurrencyItemList[i].col_action);
			}
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E43BC Offset: 0x6E43BC VA: 0x6E43BC
		// // RVA: 0x97CA68 Offset: 0x97CA68 VA: 0x97CA68
		private IEnumerator Co_CurrencyItemPeriodPopup(int currencyId, int count, long currentTime, long period)
		{
			ILDKBCLAFPB.FIDNFICGLEE_LimitedItemWarning saveDataLimit; // 0x30
			TimeSpan gachaTicketDateSpan; // 0x38
			MessageBank bank; // 0x40
			PopupItemUseConfirmSetting setting; // 0x44

			//0x13CC2C8
			bool isClose = false;
			saveDataLimit = GameManager.Instance.localSave.EPJOACOONAC_GetSave().KPHPNFBBLPA_LimitedItemWarning;
			if(!IsShowLimitedPopup(currentTime, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, HPBDNNACBAK.FIHFDIBDKKE(currencyId) ? saveDataLimit.LDKICHJMLOH_PassGachaTicketDate : saveDataLimit.KFPALNAJJBP_EventGachaTicketDate, period, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("limited_item_show_warning_time", 0), out gachaTicketDateSpan))
				yield break;
			bank = MessageManager.Instance.GetBank("menu");
			setting = new PopupItemUseConfirmSetting();
			yield return Co.R(setting.LoadAssetBundlePrefab(transform));
			int a = EKLNMHFCAOI.ADGMGNKCIGA(currencyId);
			setting.TypeItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket, a);
			setting.Period = (int)period;
			setting.OwnCount = count;
			setting.TitleText = bank.GetMessageByLabel("pop_limited_item_warning_title");
			setting.Cost = 0;
			setting.WindowSize = SizeType.Middle;
			setting.HideUseNum = true;
			setting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			string str;
			if(gachaTicketDateSpan.TotalDays < 1)
			{
				str = string.Format(bank.GetMessageByLabel("pop_limited_item_warning_text_2"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(setting.TypeItemId));
			}
			else
			{
				str = string.Format(bank.GetMessageByLabel("pop_limited_item_warning_text_1"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(setting.TypeItemId), gachaTicketDateSpan.TotalDays);
			}
			setting.OverrideText = str;
			PopupWindowManager.Show(setting, (PopupWindowControl cont, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x13C78B8
				isClose = true;
			}, null, null, null);
			while(!isClose)
				yield return null;
			if(HPBDNNACBAK.FIHFDIBDKKE(currencyId))
				saveDataLimit.LDKICHJMLOH_PassGachaTicketDate = currentTime;
			else
				saveDataLimit.KFPALNAJJBP_EventGachaTicketDate = currentTime;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E4434 Offset: 0x6E4434 VA: 0x6E4434
		// // RVA: 0x97CB70 Offset: 0x97CB70 VA: 0x97CB70
		private IEnumerator Co_CurrencyItemGachaProductPeriodPopup(int currencyId, int count, long currentTime, long period)
		{
			ILDKBCLAFPB.FIDNFICGLEE_LimitedItemWarning saveDataLimit; // 0x30
			MessageBank bank; // 0x34
			PopupItemGachaPeriodConfirmSetting setting; // 0x38

			//0x13CBA74
			bool isClose = false;
			saveDataLimit = GameManager.Instance.localSave.EPJOACOONAC_GetSave().KPHPNFBBLPA_LimitedItemWarning;
			TimeSpan ts;
			if(!IsShowLimitedPopup(currentTime, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, HPBDNNACBAK.FIHFDIBDKKE(currencyId) ? saveDataLimit.LDKICHJMLOH_PassGachaTicketDate : saveDataLimit.KFPALNAJJBP_EventGachaTicketDate, period, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("gacha_period_show_warning_time", 0), out ts))
				yield break;
			bank = MessageManager.Instance.GetBank("menu");
			setting = new PopupItemGachaPeriodConfirmSetting();
			yield return Co.R(setting.LoadAssetBundlePrefab(transform));
			int itemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket, EKLNMHFCAOI.ADGMGNKCIGA(currencyId));
			setting.TypeItemId = itemId;
			setting.Period = period;
			setting.OwnCount = count;
			setting.TitleText = bank.GetMessageByLabel("pop_gacha_period_warning_title");
			setting.OverrideText = string.Format(bank.GetMessageByLabel("pop_gacha_period_warning_text_1"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(itemId));
			setting.Cost = 0;
			setting.WindowSize = SizeType.Middle;
			setting.HideUseNum = true;
			setting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			PopupWindowManager.Show(setting, (PopupWindowControl cont, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x13C78CC
				isClose = true;
			}, null, null, null);
			while(!isClose)
				yield return null;
			if(HPBDNNACBAK.FIHFDIBDKKE(currencyId))
				saveDataLimit.LDKICHJMLOH_PassGachaTicketDate = currentTime;
			else
				saveDataLimit.KFPALNAJJBP_EventGachaTicketDate = currentTime;
		}

		// 	[CompilerGeneratedAttribute] // RVA: 0x6E44FC Offset: 0x6E44FC VA: 0x6E44FC
		// 	// RVA: 0x97D1F4 Offset: 0x97D1F4 VA: 0x97D1F4
		// 	private void <CheckSnsNotice>b__106_0() { }
		
		// 	[CompilerGeneratedAttribute] // RVA: 0x6E452C Offset: 0x6E452C VA: 0x6E452C
		// 	// RVA: 0x97D318 Offset: 0x97D318 VA: 0x97D318
		// 	private void <SetupBeginnerLead>b__149_0(IiconTexture image) { }
		
		private void LoadSLive()
		{
			this.StartCoroutineWatched(LoadSLiveCoroutine());
			m_updater = this.LoadSLiveWait;
		}

		private void LoadSLiveWait()
		{
			return;
		}

		private IEnumerator LoadSLiveCoroutine()
		{
			UnityEngine.Debug.Log("Generate Next Song");

			while(MenuScene.Instance.IsTransition())
				yield return null;

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
			Database.Instance.gameSetup.musicInfo.SetupInfoByFreeMusic(freemusicNum + 1, (Difficulty.Type) UnityEngine.Random.Range(0, (int)Difficulty.Type.Num)/*difficulty*/, false, new GameSetupData.MusicInfo.InitFreeMusicParam(), OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0, OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0, OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0, true, UnityEngine.Random.Range(0, 2) != 0, "", 0, 0, -1, 0, 0, numDiva);
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
