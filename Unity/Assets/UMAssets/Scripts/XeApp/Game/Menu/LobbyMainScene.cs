using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LobbyMainScene : TransitionRoot
	{
		public enum LobbyBgType
		{
			NONE = 0,
			SHINE = 1,
			VANISH = 2,
			SPACE = 3,
		}

		private LobbyScrollListWindow m_windowUi; // 0x48
		private LobbyFooter m_lobbyFooter; // 0x4C
		private LayoutUGUIRuntime m_layoutUGUIRuntime; // 0x50
		private NKOBMDPHNGP_EventRaidLobby m_RaidLobbyController; // 0x54
		private LobbyStampWindow m_stampWindow; // 0x58
		private LobbyChatBbsSwitchButton m_chatBbsButton; // 0x5C
		private LobbyNewsReport m_newsReport; // 0x60
		private LobbyFooterTransButtonLayout m_lobbyFooterTransButton; // 0x64
		private LobbyHomeButton m_homeButton; // 0x68
		private PopupDecoEnergyChargeSetting m_popupCannonGauge = new PopupDecoEnergyChargeSetting(); // 0x6C
		private LobbyLiveMessge m_lobbyLiveMessage; // 0x70
		private LobbyLiveWindow m_lobbyLiveWindow; // 0x74
		private LobbyLiveSkipButton m_lobbyLiveSkip; // 0x78
		private bool m_isMovieInitialize; // 0x7C
		private SeriesAttr.Type series = SeriesAttr.Type.Frontia; // 0x80
		private bool m_isAssetLoad; // 0x84
		private bool m_isPlayingMovie; // 0x85
		private string m_messgeText = ""; // 0x88
		private bool m_IsSendBtnPossible; // 0x8C
		private int m_raidSelect; // 0x90
		private int m_saveRaidSelect; // 0x94
		private bool m_isInitialized; // 0x98
		private int m_mcannonLogId; // 0x9C
		private bool m_isChange; // 0xA0
		private int m_commentCount; // 0xA4
		private int m_PlayerId; // 0xA8
		private int m_friendPlayerId; // 0xAC
		private int m_currentLobbyId; // 0xB0
		private bool IsRequestNextList; // 0xB4
		private bool IsMemberLobby = true; // 0xB5
		private Action m_updater; // 0xB8
		private bool IsHelpEnd; // 0xBC
		private bool IsTryProfile; // 0xBD
		private bool m_IsUpdateError; // 0xBE
		private EventLobbyArgs CacheArgs; // 0xC0
		private bool IsGotoNotDeco; // 0xC4
		private bool IsDestroy; // 0xC5
		private bool IsRequestGotoTitle; // 0xC7
		private bool IsNewsReportDirty; // 0xC8
		private ProfilDateArgs m_returnArgs; // 0xCC
		private bool IsAfterAutoUpdateAct; // 0xD0

		private bool IsFirstLobby { get; set; } // 0xC6

		// RVA: 0x12A17A8 Offset: 0x12A17A8 VA: 0x12A17A8 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			IsReady = true;
		}

		// RVA: 0x12A17D0 Offset: 0x12A17D0 VA: 0x12A17D0
		public void Update()
		{
			if(m_updater != null)
			{
				if(!IsRequestGotoTitle && !m_isPlayingMovie)
					m_updater();
			}
		}

		// RVA: 0x12A1800 Offset: 0x12A1800 VA: 0x12A1800 Slot: 29
		protected override void InputEnable()
		{
			base.InputEnable();
			if(InputStateCount > 0)
				return;
			m_lobbyFooter.InputEnable();
		}

		// RVA: 0x12A184C Offset: 0x12A184C VA: 0x12A184C Slot: 30
		protected override void InputDisable()
		{
			base.InputDisable();
			if(InputStateCount < 1)
				return;
			m_lobbyFooter.InputDisable();
		}

		// RVA: 0x12A1898 Offset: 0x12A1898 VA: 0x12A1898 Slot: 16
		protected override void OnPreSetCanvas()
		{
			base.OnPreSetCanvas();
			EventLobbyArgs arg = Args as EventLobbyArgs;
			if(arg == null)
				arg = CacheArgs;
			if(arg == null)
			{
				IsMemberLobby = true;
				m_PlayerId = NKGJPJPHLIF.HHCJCDFCLOB.CAFHLEFMMGD_GetPlayerId();
				m_friendPlayerId = m_PlayerId;
			}
			else
			{
				CacheArgs = arg;
				IsMemberLobby = arg.IsMyLobby;
				m_friendPlayerId = arg.playerId;
				m_PlayerId = NKGJPJPHLIF.HHCJCDFCLOB.CAFHLEFMMGD_GetPlayerId();
				if(arg.friendData != null)
				{
					m_returnArgs = new ProfilDateArgs();
					m_returnArgs.data = arg.friendData;
					m_returnArgs.infoType = ProfilMenuLayout.InfoType.PLAYER;
					m_returnArgs.btnType = ProfilMenuLayout.ButtonType.Fan;
				}
			}
			IsRequestGotoTitle = false;
			this.StartCoroutineWatched(Co_LoadResources());
			m_isInitialized = false;
			IsAfterAutoUpdateAct = false;
			IsGotoNotDeco = false;
			IsDestroy = false;
			m_isChange = GameManager.Instance.localSave.EPJOACOONAC_GetSave().NNKKOLHBGEL_ChatCommon.OCFJGGFPIBK_ChatIconState;
			IsTryProfile = false;
		}

		// RVA: 0x12A1C04 Offset: 0x12A1C04 VA: 0x12A1C04 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return m_isInitialized;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E840C Offset: 0x6E840C VA: 0x6E840C
		// // RVA: 0x12A1C0C Offset: 0x12A1C0C VA: 0x12A1C0C
		private IEnumerator Co_Initialize()
		{
			//0xD0CC80
			yield return Co.R(Initialize());
			yield return this.StartCoroutineWatched(Co_MovieInitialize());
		}

		// RVA: 0x12A1C94 Offset: 0x12A1C94 VA: 0x12A1C94 Slot: 18
		protected override void OnPostSetCanvas()
		{
			transform.SetAsFirstSibling();
			m_windowUi.transform.SetAsFirstSibling();
		}

		// RVA: 0x12A1D0C Offset: 0x12A1D0C VA: 0x12A1D0C Slot: 9
		protected override void OnStartEnterAnimation()
		{
			if(!IsMemberLobby)
			{
				if(m_lobbyFooterTransButton != null)
				{
					m_lobbyFooterTransButton.Hide();
				}
				if(m_homeButton != null)
				{
					m_homeButton.Leave();
				}
				MenuScene.Instance.HeaderMenu.MenuStack.EnterBackButton(true);
			}
			else
			{
				if(m_lobbyFooterTransButton != null)
				{
					m_lobbyFooterTransButton.Enter();
				}
				if(m_homeButton != null)
				{
					m_homeButton.Enter();
				}
			}
			if(m_chatBbsButton != null)
			{
				m_chatBbsButton.Enter();
			}
			if(m_lobbyFooter != null)
			{
				m_lobbyFooter.Enter(IsMemberLobby);
			}
		}

		// RVA: 0x12A205C Offset: 0x12A205C VA: 0x12A205C Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_stampWindow.IsPlayingChild() && !m_lobbyFooterTransButton.IsPlayingChild() && !m_lobbyFooter.IsPlayingChild() && !m_homeButton.IsPlayingChild();
		}

		// RVA: 0x12A2108 Offset: 0x12A2108 VA: 0x12A2108 Slot: 12
		protected override void OnStartExitAnimation()
		{
			base.OnStartExitAnimation();
			if(!IsFirstLobby)
			{
				if(IsMemberLobby)
				{
					if(m_stampWindow != null)
					{
						if(m_stampWindow.IsShow)
						{
							m_stampWindow.Leave();
						}
					}
					if(m_lobbyFooterTransButton != null)
					{
						m_lobbyFooterTransButton.Leave();
					}
					if(m_homeButton != null)
					{
						m_homeButton.Leave();
					}
					if(m_newsReport != null)
					{
						m_newsReport.Leave();
					}
				}
				if(m_chatBbsButton != null)
				{
					m_chatBbsButton.Leave();
				}
				if(m_lobbyFooter != null)
				{
					m_lobbyFooter.Leave(IsMemberLobby);
				}
			}
			m_updater = null;
		}

		// RVA: 0x12A2438 Offset: 0x12A2438 VA: 0x12A2438 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			Debug.Log("StringLiteral_18389 "+base.IsEndExitAnimation());
			return !m_stampWindow.IsPlayingChild() && !m_lobbyFooterTransButton.IsPlayingChild() && !m_lobbyFooter.IsPlayingChild() && !m_homeButton.IsPlayingChild() && !m_newsReport.IsPlayingChild();
		}

		// RVA: 0x12A25C8 Offset: 0x12A25C8 VA: 0x12A25C8 Slot: 21
		protected override void OnOpenScene()
		{
			base.OnOpenScene();
			if(IsMemberLobby)
			{
				this.StartCoroutineWatched(HelpFlow());
			}
			else
			{
				MenuScene.Instance.HelpButton.TryLeave();
				IsHelpEnd = true;
			}
		}

		// RVA: 0x12A274C Offset: 0x12A274C VA: 0x12A274C Slot: 22
		protected override bool IsEndOpenScene()
		{
			return IsHelpEnd;
		}

		// RVA: 0x12A2754 Offset: 0x12A2754 VA: 0x12A2754 Slot: 23
		protected override void OnActivateScene()
		{
			this.StartCoroutineWatched(Co_OnActivateScene());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E8484 Offset: 0x6E8484 VA: 0x6E8484
		// // RVA: 0x12A2778 Offset: 0x12A2778 VA: 0x12A2778
		private IEnumerator Co_OnActivateScene()
		{
			//0xD0FC70
			m_updater = UpdateCommentObservation;
			if(IsFirstLobby)
				yield break;
			if(!IsMemberLobby)
				yield break;
			m_windowUi.NaviCharaTextAnimStart();
			m_windowUi.NaviCharaVoicePlay(m_RaidLobbyController.CHDNDNMHJHI_GetPhase());
			MenuScene.Instance.InputDisable();
			if(m_RaidLobbyController.KINIOEOOCAA_GetPhase(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime()) == NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase.ECAAJMPLIPG_2_Now)
			{
				List<ActionButton> btns = new List<ActionButton>(GetComponentsInChildren<ActionButton>(true));
				yield return Co.R(TutorialProc.Co_RaidFromMcrsLobby(btns.Find((ActionButton _) =>
				{
					//0xD08924
					return _.name.Contains("sw_lb_raid_btn_01");
				})));
			}
			MenuScene.Instance.InputEnable();
		}

		// RVA: 0x12A2800 Offset: 0x12A2800 VA: 0x12A2800 Slot: 7
		protected override void OnDisable()
		{
			base.OnDisable();
		}

		// RVA: 0x12A2808 Offset: 0x12A2808 VA: 0x12A2808 Slot: 15
		protected override void OnDeleteCache()
		{
			return;
		}

		// RVA: 0x12A280C Offset: 0x12A280C VA: 0x12A280C Slot: 14
		protected override void OnDestoryScene()
		{
			base.OnDestoryScene();
			IsDestroy = true;
			m_windowUi.ResetItem();
			m_RaidLobbyController.BLDACFKPCGM();
			m_windowUi.EffectAnimLoop(false);
			if(!IsGotoNotDeco)
			{
				CacheArgs = null;
			}
			Debug.Log("StringLiteral_18390");
		}

		// RVA: 0x12A2924 Offset: 0x12A2924 VA: 0x12A2924 Slot: 20
		protected override bool OnBgmStart()
		{
			SoundManager.Instance.bgmPlayer.ContinuousPlay(MenuScene.Instance.GetDefaultBgmId(SceneGroupCategory.LOBBY), 1);
			return true;
		}

		// RVA: 0x12A2A1C Offset: 0x12A2A1C VA: 0x12A2A1C Slot: 28
		protected override TransitionArgs GetCallArgsReturn()
		{
			return m_returnArgs;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E84FC Offset: 0x6E84FC VA: 0x6E84FC
		// // RVA: 0x12A2A24 Offset: 0x12A2A24 VA: 0x12A2A24
		private IEnumerator Initialize()
		{
			//0xD11C78
			m_RaidLobbyController = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
			m_raidSelect = 0;
			if(m_newsReport != null)
				m_newsReport.Hide();
			if(m_RaidLobbyController == null)
			{
				m_isInitialized = true;
				GotoTitle();
				IsRequestGotoTitle = true;
				yield break;
			}
			bool done = false;
			bool err = false;
			m_RaidLobbyController.ADACMHAHHKC_PreSetupEventHome(() =>
			{
				//0xD09D14
				done = true;
			}, () =>
			{
				//0xD09D20
				done = true;
				err = true;
			});
			while(!done)
				yield return null;
			if(err)
			{
				m_isInitialized = true;
				GotoTitle();
				IsRequestGotoTitle = true;
				yield break;
			}
			IsFirstLobby = m_RaidLobbyController.NNNNJJADGMH();
			if(!IsMemberLobby)
			{
				yield return Co.R(SettingLobbyId());
				if(IsRequestGotoTitle)
					yield break;
				m_RaidLobbyController.NIIEJKGNEBH(m_currentLobbyId);
				yield return Co.R(LobbyViewingSystemText());
				if(IsRequestGotoTitle)
					yield break;
				m_windowUi.GuideCharaInitialize(null);
				yield return null;
			}
			m_RaidLobbyController.NIIEJKGNEBH();
			m_RaidLobbyController.MKIBMJCPHKI(OnNewReport);
			m_raidSelect = m_RaidLobbyController.JGICMFAKGFO_SelectedChatType;
			m_windowUi.GuideCharaInitialize(m_RaidLobbyController);
			yield return Co.R(m_windowUi.SettingCharaVoice());
			m_lobbyFooterTransButton.FooterPhaseInit(m_RaidLobbyController);
			m_lobbyFooterTransButton.SetDayText(m_RaidLobbyController.IICHMBONEIE_GetDayBefore(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime()));
			m_lobbyFooterTransButton.SetFoldRadar(m_RaidLobbyController.ONKKHPKHCIA_GetNumTicket());
			int curStock;
			int curGauge;
			bool IsMax;
			PBOHJPIBILI.GLEPHGKFFLL(out curStock, out curGauge, out IsMax);
			ViewCannonStockUpdate(IsMax, curStock);
			NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase phase = m_RaidLobbyController.CHDNDNMHJHI_GetPhase();
			m_windowUi.EffectAnimLoop(phase == NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase.ECAAJMPLIPG_2_Now);
			SetChatSelect(m_raidSelect);
			m_chatBbsButton.SetButton((LobbyChatBbsSwitchButton.ButtonType)m_raidSelect);
			SetIconChage(m_isChange);
			SettingFooter();
			yield return Co.R(MenuScene.Instance.BgControl.ChangeBgCoroutine(BgType.LobbyMain, (int)GetBgType(phase), SceneGroupCategory.UNDEFINED, TransitionList.Type.UNDEFINED, -1));
			yield return Co.R(Co_NetBbsUpdate());
			if(m_IsUpdateError)
			{
				//LAB_00d12548
				m_isInitialized = true;
				GotoTitle();
				IsRequestGotoTitle = true;
				yield break;
			}
			m_windowUi.GetGuidCharaBtn().AddOnClickCallback(() =>
			{
				//0xD09D2C
				if(IsMemberLobby)
				{
					m_windowUi.OnClickGuideChara(phase);
				}
			});
			m_stampWindow.HaveStampListUpdate();
			UpdateChatComment();
			m_RaidLobbyController.PBPBEMJGIJK();
			if(IsFirstLobby)
			{
				m_RaidLobbyController.KLEEKOAFIIK(true);
			}
			bool IsDone = false;
			bool IsError = false;
			PKNOKJNLPOE_EventRaid evRaid = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as PKNOKJNLPOE_EventRaid;
			if(evRaid != null)
			{
				evRaid.AMBHKLLAJID((int _bossNum, int _newBossNum) =>
				{
					//0xD09C50
					IsDone = true;
					m_lobbyFooterTransButton.SetFotterRaidNewIcon(_newBossNum > 0);
					m_lobbyFooterTransButton.SetEableBossNumText(_bossNum);
				}, () =>
				{
					//0xD09CE8
					IsDone = true;
					IsError = true;
				});
			}
			else
			{
				m_lobbyFooterTransButton.SetFotterRaidNewIcon(false);
				IsDone = true;
			}
			while(!IsDone)
				yield return null;
			if(IsError)
			{
				//LAB_00d12548
				m_isInitialized = true;
				GotoTitle();
				IsRequestGotoTitle = true;
				yield break;
			}
			IsDone = false;
			IsError = false;
			m_RaidLobbyController.KMCAIFKIFHM(() =>
			{
				//0xD09CF4
				IsDone = true;
			}, () =>
			{
				//0xD09D00
				IsDone = true;
				IsError = true;
			});
			while(!IsDone)
				yield return null;
			if(IsError)
			{
				m_isInitialized = true;
				GotoTitle();
				IsRequestGotoTitle = true;
				yield break;
			}
			if(m_RaidLobbyController == null)
			{
				m_lobbyFooterTransButton.SetFotterMisionNewIcon(false);
			}
			else
			{
				phase = m_RaidLobbyController.CHDNDNMHJHI_GetPhase();
				List<AKIIJBEJOEP> l = m_RaidLobbyController.MHGAHHPGGAE_GetMisions();
				bool b = false;
				for(int i = 0; i < l.Count; i++)
				{
					b |= m_RaidLobbyController.GBADILEHLGC_GetStatus(l[i].PPFNGGCBJKC_Id) == 2;
				}
				if(phase == NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase.ECAAJMPLIPG_2_Now)
				{
					if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsRaidFromMcrsLobby))
					{
						//LAB_00d12d18
						m_RaidLobbyController.OBIDIBBDEKM(false);
					}
				}
				else if(!IsFirstLobby)
				{
					//LAB_00d12d18
					m_RaidLobbyController.OBIDIBBDEKM(false);
				}
				m_lobbyFooterTransButton.SetFotterMisionNewIcon(b || m_RaidLobbyController.PCLDCIAKCGO());
			}
			//LAB_00d12d5c
			m_lobbyFooter.Setting();
			m_chatBbsButton.SetLogDisableButtonTex(m_RaidLobbyController.BJMPAPCDGIG_IsLogEnabled());
			m_windowUi.SetHiddengotoListTopButton(true);
			m_isInitialized = true;
		}

		// // RVA: 0x12A2AAC Offset: 0x12A2AAC VA: 0x12A2AAC
		private void SettingFooter()
		{
			if(m_raidSelect != 2)
			{
				if(m_raidSelect == 1)
				{
					m_lobbyFooter.SetFooterSwitchButtonAnimation(LobbyFooter.FooterButtonAnimType.BattleLog);
					return;
				}
				if(m_raidSelect != 0)
					return;
			}
			m_lobbyFooter.SetFooterSwitchButtonAnimation(LobbyFooter.FooterButtonAnimType.Main);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E8574 Offset: 0x6E8574 VA: 0x6E8574
		// // RVA: 0x12A2B18 Offset: 0x12A2B18 VA: 0x12A2B18
		private IEnumerator SettingLobbyId()
		{
			//0xD139C8
			bool done = false;
			bool err = false;
			m_RaidLobbyController.LLLKDLPJHCF(m_friendPlayerId, (int _uniqueId, int _lobbyId) =>
			{
				//0xD09E24
				m_currentLobbyId = _lobbyId;
				done = true;
			}, () =>
			{
				//0xD09E58
				done = true;
				err = true;
			});
			while(!done)
				yield return null;
			if(err)
			{
				m_isInitialized = true;
				GotoTitle();
				IsRequestGotoTitle = true;
			}
		}

		// // RVA: 0x12A2BA0 Offset: 0x12A2BA0 VA: 0x12A2BA0
		public LobbyBgType GetBgType(NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase _type)
		{
			if(_type <= NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase.OLCLJKOKJCD_3_End)
			{
				return new LobbyBgType[4] { LobbyBgType.SHINE, LobbyBgType.SHINE, LobbyBgType.SHINE, LobbyBgType.VANISH }[(int)_type];
			}
			return LobbyBgType.NONE;
		}

		// // RVA: 0x12A2BC4 Offset: 0x12A2BC4 VA: 0x12A2BC4
		private void SetChatSelect(int select)
		{
			if(IsMemberLobby)
			{
				m_RaidLobbyController.JGICMFAKGFO_SelectedChatType = select;
			}
			if(m_windowUi != null)
			{
				m_windowUi.RaidSelectType = select;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E85EC Offset: 0x6E85EC VA: 0x6E85EC
		// // RVA: 0x12A1B7C Offset: 0x12A1B7C VA: 0x12A1B7C
		private IEnumerator Co_LoadResources()
		{
			//0xD0E6D4
			yield return Co.R(Co_LoadLayOutData());
			yield return Co.R(Co_Initialize());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E8664 Offset: 0x6E8664 VA: 0x6E8664
		// // RVA: 0x12A2CA4 Offset: 0x12A2CA4 VA: 0x12A2CA4
		private IEnumerator Co_LoadLayOutData()
		{
			StringBuilder bundleName; // 0x14
			FontInfo systemFont; // 0x18
			int bundleLoadCount; // 0x1C
			AssetBundleLoadLayoutOperationBase operation; // 0x20

			//0xD0CE08
			bundleName = new StringBuilder(64);
			systemFont = GameManager.Instance.GetSystemFont();
			bundleName.Set("ly/203.xab");
			bundleLoadCount = 0;
			if(m_lobbyFooter == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_lobby_footer_01_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
				{
					//0x12A6C20
					m_lobbyFooter = instance.GetComponent<LobbyFooter>();
					if(m_lobbyFooter != null)
					{
						instance.transform.SetParent(transform, false);
						m_lobbyFooter.onMessgeSend = (string value, bool butEnable) =>
						{
							//0x12A6EB4
							m_messgeText = value;
							m_IsSendBtnPossible = butEnable;
						};
						m_lobbyFooter.onSendClickButton = OnClickSendButton;
						m_lobbyFooter.onStampClickButton = OnClickStampButton;
						m_lobbyFooter.onMemberClickButton = OnClickMemberButton;
					}
				}));
				while(!m_lobbyFooter.IsLoaded())
					yield return null;
				bundleLoadCount++;
			}
			//LAB_00d0d09c
			if(m_chatBbsButton == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_lobby_btn_chat_01_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
				{
					//0x12A6EC0
					instance.transform.SetParent(transform, false);
					m_chatBbsButton = instance.GetComponent<LobbyChatBbsSwitchButton>();
					if(m_chatBbsButton != null)
					{
						m_chatBbsButton.OnChatClickButton = OnClickCahtButton;
						m_chatBbsButton.OnBattleLogClickButton = OnClickBattleLogButton;
						m_chatBbsButton.OnCaptureClickButton = OnClickcapturButton;
						m_chatBbsButton.OnClickLogDisableButton = OnClickLogDisableButton;
					}
				}));
				bundleLoadCount++;
			}
			//LAB_00d0d274
			if(m_windowUi == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_lobby_scroll_01_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
				{
					//0x12A7148
					instance.transform.SetParent(transform, false);
					m_windowUi = instance.GetComponent<LobbyScrollListWindow>();
					if(m_windowUi != null)
					{
						m_windowUi.WindowType = LobbyScrollListWindow.EnWindowType.Lobby;
						m_windowUi.OnClickIconChangeButton = OnClickIconChangeButton;
						m_windowUi.OnClickBbsUpdateButton = OnClickBbsUpdateButton;
					}
				}));
				bundleLoadCount++;
				m_windowUi.Co_SettingList();
				yield return Co.R(m_windowUi.Co_LoadAssetsLayoutListItemR(bundleName.ToString(), systemFont));
				yield return Co.R(m_windowUi.Co_LoadAssetsLayoutListItemL(bundleName.ToString(), systemFont));
				m_windowUi.ReprintButtonAction = BattleRepostConfPopup;
				m_windowUi.OnClickPlayerIcon = OnClickPlayerIcon;
				m_windowUi.OnClickGotoListTop = OnClickGotoListTop;
				m_windowUi.OnClickMovieIcon = OnClickMovie;
			}
			//LAB_00d0d60c
			if(m_lobbyFooterTransButton == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_lobby_btn_01_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
				{
					//0x12A7324
					instance.transform.SetParent(transform, false);
					m_lobbyFooterTransButton = instance.GetComponent<LobbyFooterTransButtonLayout>();
					m_lobbyFooterTransButton.onPreRaidClickButton = OnClickBossInfoButton;
					m_lobbyFooterTransButton.onMissionClickButton = OnClickMissionButton;
					m_lobbyFooterTransButton.onRaideClickButton = OnClickRaidoButton;
					m_lobbyFooterTransButton.onMcGaugeClickButton = OnClickMcGaugeButton;
				}));
				bundleLoadCount++;
				while(!m_lobbyFooterTransButton.IsLoaded())
					yield return null;
			}
			//LAB_00d0d7a0
			if(m_newsReport == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_lobby_news_01_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
				{
					//0x12A7534
					instance.transform.SetParent(transform, false);
					m_newsReport = instance.GetComponent<LobbyNewsReport>();
					if(m_newsReport != null)
					{
						m_newsReport.Hide();
						m_newsReport.onNewsClickButton = OnNewReportButton;
					}
				}));
				bundleLoadCount++;
			}
			//LAB_00d0d8fc
			if(m_homeButton == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_lobby_home_btn_01_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
				{
					//0x12A76BC
					instance.transform.SetParent(transform, false);
					m_homeButton = instance.GetComponent<LobbyHomeButton>();
					if(m_homeButton != null)
					{
						m_homeButton.Hide();
						m_homeButton.OnClickHomeButton = OnClickHomeButton;
					}
				}));
				bundleLoadCount++;
			}
			//LAB_00d0da58
			if(m_lobbyLiveWindow == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_lobby_live_01_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
				{
					//0x12A7840
					instance.transform.SetParent(transform, false);
					m_lobbyLiveWindow = instance.GetComponent<LobbyLiveWindow>();
				}));
				bundleLoadCount++;
			}
			//LAB_00d0dbb4
			if(m_lobbyLiveMessage == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_lobby_live_02_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
				{
					//0x12A7950
					instance.transform.SetParent(transform, false);
					m_lobbyLiveMessage = instance.GetComponent<LobbyLiveMessge>();
				}));
				bundleLoadCount++;
			}
			//LAB_00d0dd10
			if(m_lobbyLiveSkip == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_lobby_skip_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
				{
					//0x12A7A60
					instance.transform.SetParent(transform, false);
					m_lobbyLiveSkip = instance.GetComponent<LobbyLiveSkipButton>();
					m_lobbyLiveSkip.OnClickSkip = () =>
					{
						//0xD089BC
						McrsCannonViewer.Skip();
					};
				}));
				bundleLoadCount++;
			}
			//LAB_00d0de7c
			if(m_stampWindow == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_lobby_stmp_win_01_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
				{
					//0x12A7C18
					instance.transform.SetParent(transform, false);
					m_stampWindow = instance.GetComponent<LobbyStampWindow>();
					m_stampWindow.onHideClickButton = () =>
					{
						//0x12A7D44
						m_stampWindow.Leave();
					};
				}));
				bundleLoadCount++;
				yield return Co.R(m_stampWindow.Co_LoadStampItemContent());
				m_stampWindow.OnClickStamp = (int stamp, int serif) =>
				{
					//0x12A7D70
					this.StartCoroutineWatched(Co_AddStampItem(stamp, serif));
					m_stampWindow.Leave();
				};
				m_stampWindow.OnClickStampEditButton = ClickStampEditButton;
			}
			//LAB_00d0e0dc
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
		}

		// // RVA: 0x12A2D2C Offset: 0x12A2D2C VA: 0x12A2D2C
		private void OnClickCahtButton()
		{
			if(m_raidSelect == 0)
				return;
			if(IsAfterAutoUpdateAct)
				return;
			m_raidSelect = 0;
			this.StartCoroutineWatched(Co_AfterAutoUpdateAct(() =>
			{
				//0x12A7DB4
				Debug.Log("StringLiteral_18404");
				SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
				SettingFooter();
				SetChatSelect(m_raidSelect);
				m_windowUi.RaidSelectType = m_raidSelect;
			}));
		}

		// // RVA: 0x12A2E94 Offset: 0x12A2E94 VA: 0x12A2E94
		private void OnClickBattleLogButton()
		{
			if(m_raidSelect == 1)
				return;
			if(IsAfterAutoUpdateAct)
				return;
			m_raidSelect = 1;
			this.StartCoroutineWatched(Co_AfterAutoUpdateAct(() =>
			{
				//0x12A7ECC
				Debug.Log("StringLiteral_18405");
				SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
				SettingFooter();
				SetChatSelect(m_raidSelect);
				m_windowUi.RaidSelectType = m_raidSelect;
			}));
		}

		// // RVA: 0x12A2F58 Offset: 0x12A2F58 VA: 0x12A2F58
		private void OnClickcapturButton()
		{
			if(m_raidSelect == 2)
				return;
			if(IsAfterAutoUpdateAct)
				return;
			m_raidSelect = 2;
			this.StartCoroutineWatched(Co_AfterAutoUpdateAct(() =>
			{
				//0x12A7FE4
				Debug.Log("StringLiteral_18406");
				SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
				SettingFooter();
				SetChatSelect(m_raidSelect);
				m_windowUi.RaidSelectType = m_raidSelect;
			}));
		}

		// // RVA: 0x12A301C Offset: 0x12A301C VA: 0x12A301C
		private void OnClickLogDisableButton()
		{
			if(m_RaidLobbyController == null)
				return;
			bool b = m_RaidLobbyController.BJMPAPCDGIG_IsLogEnabled();
			m_RaidLobbyController.NLGAFNOHLID_SetLogEnabled(!b);
			m_chatBbsButton.SetLogDisableButtonTex(!b);
			this.StartCoroutineWatched(Co_AfterAutoUpdateAct(() =>
			{
				//0xD089C4
				Debug.Log("StringLiteral_18408");
				SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			}));
		}

		// // RVA: 0x12A31B8 Offset: 0x12A31B8 VA: 0x12A31B8
		private void ClickStampEditButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			Debug.Log("StringLiteral_18391");
			MenuScene.Instance.Call(TransitionList.Type.DECO_STAMP, null, true);
			IsGotoNotDeco = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E86DC Offset: 0x6E86DC VA: 0x6E86DC
		// // RVA: 0x12A3308 Offset: 0x12A3308 VA: 0x12A3308
		private IEnumerator Co_ReloadComment()
		{
			//0xD113EC
			MenuScene.Instance.InputDisable();
			m_windowUi.LockScroll();
			yield return Co.R(Co_NetBbsUpdate());
			if(!m_IsUpdateError)
			{
				UpdateChatComment();
			}
			else
			{
				MenuScene.Instance.GotoTitle();
				IsRequestGotoTitle = true;
			}
			m_windowUi.UnLockScroll();
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0x12A3390 Offset: 0x12A3390 VA: 0x12A3390
		private void UpdateChatComment()
		{
			m_commentCount = m_RaidLobbyController.JIDLPGHJOIE_GetCommentsCount((NKOBMDPHNGP_EventRaidLobby.FLHJEJGJJGE) m_raidSelect);
			Debug.Log("StringLiteral_18392 "+m_raidSelect.ToString());
			Debug.Log("StringLiteral_18393 "+m_commentCount);
			m_windowUi.ResetItem();
			for(int i = m_commentCount - 1; i >= 0; i--)
			{
				ANPBHCNJIDI.NNPGLGHDBKN cm = m_RaidLobbyController.GDGCADFCDCL_GetComment( (NKOBMDPHNGP_EventRaidLobby.FLHJEJGJJGE) m_raidSelect, i);
				m_windowUi.AddBbsListItem(cm, cm.INDDJNMPONH, m_PlayerId, i, IsMemberLobby);
			}
			m_windowUi.AddScrollItem();
			m_windowUi.UpdateScroll();
		}

		// // RVA: 0x12A35D8 Offset: 0x12A35D8 VA: 0x12A35D8
		private void CommentDisplayUpdate()
		{
			m_commentCount = m_RaidLobbyController.JIDLPGHJOIE_GetCommentsCount((NKOBMDPHNGP_EventRaidLobby.FLHJEJGJJGE)m_raidSelect);
			m_windowUi.ResetItem();
			for(int i = m_commentCount - 1; i >= 0; i--)
			{
				ANPBHCNJIDI.NNPGLGHDBKN cm = m_RaidLobbyController.GDGCADFCDCL_GetComment( (NKOBMDPHNGP_EventRaidLobby.FLHJEJGJJGE) m_raidSelect, i);
				m_windowUi.AddBbsListItem(cm, cm.INDDJNMPONH, m_PlayerId, i, IsMemberLobby);
			}
			m_windowUi.AddScrollItem();
			m_windowUi.UpdateDisplayOnly();
		}

		// // RVA: 0x12A3724 Offset: 0x12A3724 VA: 0x12A3724
		private void NextAddComment(int index)
		{
			MenuScene.Instance.InputDisable();
			m_windowUi.LockScroll();
			m_commentCount = m_RaidLobbyController.JIDLPGHJOIE_GetCommentsCount((NKOBMDPHNGP_EventRaidLobby.FLHJEJGJJGE)m_raidSelect);
			m_windowUi.ResetItem();
			for(int i = m_commentCount - 1; i >= 0; i--)
			{
                ANPBHCNJIDI.NNPGLGHDBKN cm = m_RaidLobbyController.GDGCADFCDCL_GetComment((NKOBMDPHNGP_EventRaidLobby.FLHJEJGJJGE)m_raidSelect, i);
				m_windowUi.AddBbsListItem(cm, cm.INDDJNMPONH, m_PlayerId, i,IsMemberLobby);
            }
			m_windowUi.AddScrollItem();
			m_windowUi.NextCommentAddScrollLsit(index);
			m_windowUi.UnLockScroll();
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0x12A39A4 Offset: 0x12A39A4 VA: 0x12A39A4
		private void OnClickStampButton()
		{
			if(m_stampWindow != null)
			{
				if(m_lobbyFooter.IsKeyBoardOpen)
					return;
				SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
				m_stampWindow.transform.SetParent(transform.parent);
				m_stampWindow.Show();
			}
		}

		// // RVA: 0x12A3B38 Offset: 0x12A3B38 VA: 0x12A3B38
		// private void OnClickRaidButton() { }

		// // RVA: 0x12A3C4C Offset: 0x12A3C4C VA: 0x12A3C4C
		private void OnClickBossInfoButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			MenuScene.Instance.InputDisable();
			MBCPNPNMFHB.HHCJCDFCLOB.PBIKAGIOOHC(m_RaidLobbyController.MAICAKMIBEM("boss_info_key", ""), () =>
			{
				//0xD08A9C
				MenuScene.Instance.InputEnable();
			}, () =>
			{
				//0x12A80FC
				MenuScene.Instance.GotoTitle();
				IsRequestGotoTitle = true;
			});
		}

		// // RVA: 0x12A3EF8 Offset: 0x12A3EF8 VA: 0x12A3EF8
		private void OnClickMissionButton()
		{
			if(m_RaidLobbyController != null)
			{
				LobbyMissionArgs arg = new LobbyMissionArgs();
				arg.cont = m_RaidLobbyController;
				Debug.Log("StringLiteral_18395");
				SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
				MenuScene.Instance.Call(TransitionList.Type.LOBBY_MISSION, arg, true);
				IsGotoNotDeco = true;
			}
		}

		// // RVA: 0x12A408C Offset: 0x12A408C VA: 0x12A408C
		private void OnClickMemberButton()
		{
			Debug.Log("StringLiteral_18396");
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			MenuScene.Instance.Call(TransitionList.Type.LOBBY_MEMBER, null, true);
			IsGotoNotDeco = true;
		}

		// // RVA: 0x12A41DC Offset: 0x12A41DC VA: 0x12A41DC
		private void OnClickRaidoButton()
		{
			Debug.Log("StringLiteral_18397");
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			MenuScene.Instance.Call(TransitionList.Type.RAID, null, true);
			IsGotoNotDeco = true;
		}

		// // RVA: 0x12A432C Offset: 0x12A432C VA: 0x12A432C
		private void OnClickIconChangeButton()
		{
			if(m_RaidLobbyController.JHBLAGLBIAD())
				return;
			if(m_RaidLobbyController.FJHLAKJBNFA)
				return;
			Debug.Log("StringLiteral_18398");
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			SetIconChage(m_isChange);
			CommentDisplayUpdate();
		}

		// // RVA: 0x12A4468 Offset: 0x12A4468 VA: 0x12A4468
		private void SetIconChage(bool _change)
		{
			m_windowUi.UpdateDivaIconThum(_change);
			m_windowUi.IsIconChange = _change;
			m_isChange = !_change;
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().NNKKOLHBGEL_ChatCommon.OCFJGGFPIBK_ChatIconState = _change;
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
		}

		// // RVA: 0x12A45F0 Offset: 0x12A45F0 VA: 0x12A45F0
		private void OnClickBbsUpdateButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			if(IsAfterAutoUpdateAct)
				return;
			this.StartCoroutineWatched(Co_AfterAutoUpdateAct(() =>
			{
				//0xD08B38
				Debug.Log("StringLiteral_18409");
			}));
		}

		// // RVA: 0x12A4780 Offset: 0x12A4780 VA: 0x12A4780
		private void OnNewReport(NKOBMDPHNGP_EventRaidLobby.KAGMKNANHBA nl)
		{
			if(m_newsReport != null && !m_newsReport.IsShow)
				IsNewsReportDirty = true;
		}

		// // RVA: 0x12A4838 Offset: 0x12A4838 VA: 0x12A4838
		private void OnNewReportButton()
		{
			Debug.Log("StringLiteral_18399");
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			m_newsReport.Leave();
			LobbyLayoutItemR.CannonMovieInfo d = new LobbyLayoutItemR.CannonMovieInfo();
			ANPBHCNJIDI.NBHIMCACDHM m = m_RaidLobbyController.CPJAANJHBFC().HCAHCFGPJIF;
			d.userName = m.PHGNPFJIBLF_Name;
			d.bossName = m.GJAOLNLFEBD_BossName;
			d.damage = m.HALIDDHLNEG_Damage;
			d.bossRank = m.EJGDHAENIDC_BossRank;
			d.bossImageNum = m.JNBDLNBKDCO_BossImage;
			d.series = (SeriesAttr.Type) m.PCPODOMOFDH_BossSeriesAttr;
			d.logId = m.CNOHJPEHHCH_LogId;
			d.wavId = m.KKPAHLMJKIH_WavId;
			this.StartCoroutineWatched(Co_PlayMovie(d));
		}

		// // RVA: 0x12A4ABC Offset: 0x12A4ABC VA: 0x12A4ABC
		private void OnClickHomeButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			MenuScene.Instance.FooterMenu.NotSelectButtonAll();
			MenuScene.Instance.FooterMenu.SelectedButton(MenuButtonAnim.ButtonType.HOME);
			MenuScene.Instance.Mount(TransitionUniqueId.HOME, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
			ILCCJNDFFOB.HHCJCDFCLOB.LHCHBHPHLCP(2);
			IsGotoNotDeco = true;
		}

		// // RVA: 0x12A4CB8 Offset: 0x12A4CB8 VA: 0x12A4CB8
		private void OnClickGotoListTop()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			m_windowUi.StopScrollMove();
			m_windowUi.GotoListTop();
		}

		// // RVA: 0x12A4D54 Offset: 0x12A4D54 VA: 0x12A4D54
		private void OnClickPlayerIcon(int _playerId)
		{
			if(IsTryProfile)
				return;
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			IsTryProfile = true;
			this.StartCoroutineWatched(Co_OnClickPlayerIcon(_playerId));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E8754 Offset: 0x6E8754 VA: 0x6E8754
		// // RVA: 0x12A4DE4 Offset: 0x12A4DE4 VA: 0x12A4DE4
		private IEnumerator Co_OnClickPlayerIcon(int _playerId)
		{
			bool IsMyData;

			//0xD102F8
			MenuScene.Instance.RaycastDisable();
			m_windowUi.LockScroll();
			IsMyData = _playerId == NKGJPJPHLIF.HHCJCDFCLOB.CAFHLEFMMGD_GetPlayerId();
			bool isDone = false;
			bool IsError = false;
			EAJCBFGKKFA_FriendInfo friends = new EAJCBFGKKFA_FriendInfo();
            PIGBKEIAMPE_FriendManager fm = CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager;
			fm.LJMOBJNEHPM(_playerId, () =>
			{
				//0xD09E6C
				for(int i = 0; i < fm.BFDEHIANFOG.Count; i++)
				{
					EAJCBFGKKFA_FriendInfo f = new EAJCBFGKKFA_FriendInfo();
					f.KHEKNNFCAOI(fm.BFDEHIANFOG[i]);
					if(f.MLPEHNBNOGD_Id == _playerId)
						friends = f;
				}
				isDone = true;
			}, (CACGCMBKHDI_Request err) =>
			{
				//0xD09FCC
				IsError = true;
			}, (CACGCMBKHDI_Request err) =>
			{
				//0xD09FD8
				MenuScene.Instance.GotoTitle();
				IsRequestGotoTitle = true;
			});
			while(!isDone)
				yield return null;
			if(!IsError)
			{
				ProfilDateArgs arg = new ProfilDateArgs();
				arg.isFavorite = friends.PCEGKKLKFNO.NEILEPPJKIN_IsFavorite != 0;
				arg.data = friends;
				arg.infoType = ProfilMenuLayout.InfoType.PLAYER;
				arg.btnType = IsMyData ? ProfilMenuLayout.ButtonType.None : ProfilMenuLayout.ButtonType.Fan_NoLobby;
				MenuScene.Instance.Call(TransitionList.Type.PROFIL, arg, true);
				IsGotoNotDeco = true;
				m_windowUi.UnLockScroll();
				MenuScene.Instance.RaycastEnable();
				GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
			}
			else
			{
				IsTryProfile = false;
			}
        }

		// // RVA: 0x12A4E88 Offset: 0x12A4E88 VA: 0x12A4E88
		private void BattleRepostConfPopup(int index)
		{
			m_windowUi.LockScroll();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = new TextPopupSetting();
			s.IsCaption = true;
			s.WindowSize = SizeType.Small;
			if(IsInMyBlockList(index))
			{
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Return, Type = PopupButton.ButtonType.Negative }
				};
				s.Text = bk.GetMessageByLabel("popup_in_my_blocklist_text");
			}
			else
			{
				s.Buttons = new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				s.Text = bk.GetMessageByLabel("chat_post_conf_popup_text");
			}
			s.TitleText = bk.GetMessageByLabel("chat_post_conf_popup_title");
			PopupWindowManager.Show(s, (PopupWindowControl cont, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xD0A09C
				m_windowUi.UnLockScroll();
				if(label != PopupButton.ButtonLabel.Ok)
				{
					this.StartCoroutineWatched(Co_BattleCommentRepost(index));
				}
			}, null, null, null, true, true, false);
		}

		// // RVA: 0x12A5450 Offset: 0x12A5450 VA: 0x12A5450
		// private void OnClickSendStampButton() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E87CC Offset: 0x6E87CC VA: 0x6E87CC
		// // RVA: 0x12A54C4 Offset: 0x12A54C4 VA: 0x12A54C4
		// private IEnumerator Co_AddStampItem() { }

		// // RVA: 0x12A554C Offset: 0x12A554C VA: 0x12A554C
		private void OnClickSendButton()
		{
			if(m_IsSendBtnPossible)
			{
				this.StartCoroutineWatched(Co_AddMessgeItem());
			}
			else
			{
				if(m_lobbyFooter != null)
					m_lobbyFooter.SetMessgeInputOut();
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E8844 Offset: 0x6E8844 VA: 0x6E8844
		// // RVA: 0x12A5628 Offset: 0x12A5628 VA: 0x12A5628
		private IEnumerator Co_AddMessgeItem()
		{
			//0xD0A194
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			if(m_RaidLobbyController != null)
			{
				MenuScene.Instance.InputDisable();
				m_windowUi.LockScroll();
				if(!IsMemberLobby)
				{
					m_RaidLobbyController.NIIEJKGNEBH(m_currentLobbyId);
				}
				else
				{
					m_RaidLobbyController.NIIEJKGNEBH();
				}
				yield return Co.R(Co_NetBbsUpdate());
				if(m_IsUpdateError)
				{
					MenuScene.Instance.GotoTitle();
					IsRequestGotoTitle = true;
				}
				else
				{
					yield return Co.R(Co_NetBbsCreate(false));
				}
				//LAB_00d0a39c
				if(m_lobbyFooter != null)
				{
					m_lobbyFooter.SetMessgeInputOut();
				}
				MenuScene.Instance.InputEnable();
				m_windowUi.UnLockScroll();
			}
		}

		// // RVA: 0x12A5304 Offset: 0x12A5304 VA: 0x12A5304
		private bool IsInMyBlockList(int index)
		{
			ANPBHCNJIDI.PHICILDLHJP d = m_RaidLobbyController.GDGCADFCDCL_GetComment(NKOBMDPHNGP_EventRaidLobby.FLHJEJGJJGE.JAFEBKBFPBB_1_Battle, index) as ANPBHCNJIDI.PHICILDLHJP;
			return CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.DIGEHCDEAON_IsBlacklisted(d.MLPEHNBNOGD_WritterId);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E88BC Offset: 0x6E88BC VA: 0x6E88BC
		// // RVA: 0x12A56B0 Offset: 0x12A56B0 VA: 0x12A56B0
		private IEnumerator Co_BattleCommentRepost(int index)
		{
			//0xD0B514
			MenuScene.Instance.InputDisable();
			m_windowUi.LockScroll();
			while(m_RaidLobbyController.JHBLAGLBIAD() || m_RaidLobbyController.FJHLAKJBNFA)
				yield return null;
			yield return null;
			bool success = false;
			bool wait = false;
			bool error = false;
			m_RaidLobbyController.CBOFAFKMIBE(m_RaidLobbyController.GDGCADFCDCL_GetComment(NKOBMDPHNGP_EventRaidLobby.FLHJEJGJJGE.JAFEBKBFPBB_1_Battle, index) as ANPBHCNJIDI.PHICILDLHJP, () =>
			{
				//0xD08BD0
				success = true;
				wait = true;
			}, () =>
			{
				//0xD08BDC
				wait = true;
				error = true;
			});
			while(!wait)
				yield return null;
			if(success)
			{
				m_raidSelect = 0;
				SettingFooter();
				SetChatSelect(m_raidSelect);
				m_windowUi.RaidSelectType = m_raidSelect;
				this.StartCoroutineWatched(Co_ReloadComment());
				m_chatBbsButton.SetButton(LobbyChatBbsSwitchButton.ButtonType.CHAT_BUTTON);
			}
			if(error)
			{
				MenuScene.Instance.GotoTitle();
				IsRequestGotoTitle = true;
			}
			m_windowUi.UnLockScroll();
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0x12A5754 Offset: 0x12A5754 VA: 0x12A5754
		private void UpdateCommentObservation()
		{
			if(m_windowUi != null)
			{
				if(m_RaidLobbyController != null && m_isInitialized && m_RaidLobbyController.AFBNKKAHFCI())
				{
					if(IsNewsReportDirty)
					{
						Debug.Log("StringLiteral_18403");
						SoundManager.Instance.sePlayerMenu.Play((int)mcrs.cs_se_menu.SE_LOBBY_002);
						m_newsReport.Enter();
						IsNewsReportDirty = false;
					}
					m_windowUi.ScrollContentPostButtonGrayOut(!m_RaidLobbyController.ABNLPDNFHDN());
					m_lobbyFooter.IsButtonDisable(!m_RaidLobbyController.CCIKMMPIMHD());
					if(InputManager.Instance.touchCount < 1)
					{
						if(m_windowUi.IsNextUpdate())
						{
							GetNextCommentList();
							return;
						}
					}
					else
					{
						m_RaidLobbyController.PMCMAKBNJIL();
					}
					if(m_windowUi.IsUpdatePossible())
					{
						int bbs_auto_update_op = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA("bbs_auto_update_op", 1);
						m_RaidLobbyController.MICOCAOLCEJ(bbs_auto_update_op, (NKOBMDPHNGP_EventRaidLobby.FLHJEJGJJGE) m_raidSelect, (List<NKOBMDPHNGP_EventRaidLobby.FLHJEJGJJGE> blist) =>
						{
							//0x12A81A4
							if(IsDestroy)
								return;
							Debug.Log("StringLiteral_15452");
							if(IsAfterAutoUpdateAct)
								return;
							CommentDisplayUpdate();
						}, () =>
						{
							//0xD08BC4
							return;
						});
					}
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E8934 Offset: 0x6E8934 VA: 0x6E8934
		// // RVA: 0x12A5CAC Offset: 0x12A5CAC VA: 0x12A5CAC
		private IEnumerator Co_NetBbsUpdate()
		{
			//0xD0F9B8
			bool wait = false;
			m_IsUpdateError = false;
			if(m_RaidLobbyController == null)
				yield break;
			m_RaidLobbyController.MMMBGDHMJKC(0, (NKOBMDPHNGP_EventRaidLobby.FLHJEJGJJGE)m_raidSelect, () =>
			{
				//0xD08BF0
				wait = true;
				Debug.Log("StringLiteral_15456");
			}, () =>
			{
				//0xD08C88
				m_IsUpdateError = true;
				wait = true;
				Debug.Log("StringLiteral_15457");
			});
			while(!wait)
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E89AC Offset: 0x6E89AC VA: 0x6E89AC
		// // RVA: 0x12A5D34 Offset: 0x12A5D34 VA: 0x12A5D34
		private IEnumerator Co_NetBbsCreate(bool isViewing)
		{
			//0xD0ED34
			Debug.Log("StringLiteral_18419 " + m_raidSelect.ToString());
			bool wait = false;
			bool success = false;
			int divaId = GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].AHHJLDLAPAN_DivaId;
			Debug.Log("StringLiteral_18420 "+divaId);
			if(m_RaidLobbyController == null)
				yield break;
			m_RaidLobbyController.PMCMAKBNJIL();
			ANPBHCNJIDI.AIFBLOAGFOP a = new ANPBHCNJIDI.AIFBLOAGFOP();
			a.AHHJLDLAPAN_DivaId = divaId;
			a.EBBJPBGHJOL_Content = m_messgeText;
			a.LBODBHCBAMD = isViewing;
			a.PCEHLFNFIDA(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave);
			m_RaidLobbyController.HJNDLPNBBKF((NKOBMDPHNGP_EventRaidLobby.FLHJEJGJJGE) m_raidSelect, a, () =>
			{
				//0xD08D40
				wait = true;
				success = true;
				Debug.Log("StringLiteral_15454");
			}, () =>
			{
				//0xD08DD8
				wait = true;
				MenuScene.Instance.GotoTitle();
				IsRequestGotoTitle = true;
			}, () =>
			{
				//0xD08E9C
				wait = true;
				Debug.Log("StringLiteral_15455");
			});
			while(!wait)
				yield return null;
			if(success)
			{
				yield return Co.R(Co_ReloadComment());
			}
			//LAB_00d0f1d8
			if(m_lobbyFooter != null)
				m_lobbyFooter.SetMessgeInputOut();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E8A24 Offset: 0x6E8A24 VA: 0x6E8A24
		// // RVA: 0x12A5DD8 Offset: 0x12A5DD8 VA: 0x12A5DD8
		private IEnumerator LobbyViewingSystemText()
		{
			//0xD133B8
			bool isDone = false;
			bool isPost = false;
			bool isError = false;
			if(m_RaidLobbyController == null)
				yield break;
			MenuScene.Instance.InputDisable();
			m_windowUi.LockScroll();
			int viewing_another_lobby_check_num = m_RaidLobbyController.FJLIDJJAGOM().LPJLEHAJADA("viewing_another_lobby_check_num", 10);
			m_RaidLobbyController.NKLFDHJKIII(NKOBMDPHNGP_EventRaidLobby.FLHJEJGJJGE.GGCIMLDFDOC_0_Chat, m_PlayerId, viewing_another_lobby_check_num, (bool flg) =>
			{
				//0xD08F3C
				isPost = flg;
				isDone = true;
			}, () =>
			{
				//0xD08F4C
				isError = true;
				isDone = true;
			});
			while(!isDone)
				yield return null;
			if(!isError)
			{
				if(!isPost)
				{
					m_messgeText = MessageManager.Instance.GetMessage("menu", "lobby_viewing_system_text");
					yield return Co.R(Co_NetBbsUpdate());
					if(!m_IsUpdateError)
					{
						yield return Co.R(Co_NetBbsCreate(true));
						//LAB_00d1370c
					}
					else
					{
						//LAB_00d136f4
						GotoTitle();
						IsRequestGotoTitle = true;
					}
				}
			}
			else
			{
				//LAB_00d136f4
				GotoTitle();
				IsRequestGotoTitle = true;
			}
			m_messgeText = "";
			m_windowUi.UnLockScroll();
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0x12A5C40 Offset: 0x12A5C40 VA: 0x12A5C40
		private void GetNextCommentList()
		{
			if(m_RaidLobbyController.MIKMNNCEFBH( (NKOBMDPHNGP_EventRaidLobby.FLHJEJGJJGE) m_raidSelect) && !IsRequestNextList)
			{
				IsRequestNextList = true;
				this.StartCoroutineWatched(Co_GetNextCommentList());
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E8A9C Offset: 0x6E8A9C VA: 0x6E8A9C
		// // RVA: 0x12A5E60 Offset: 0x12A5E60 VA: 0x12A5E60
		private IEnumerator Co_GetNextCommentList()
		{
			NKOBMDPHNGP_EventRaidLobby.FLHJEJGJJGE bbsType; // 0x18
			int preCommentCount; // 0x1C

			//0xD0C69C
			bool success = false;
			bool IsDone = false;
			bool IsError = false;
			MenuScene.Instance.InputDisable();
			m_windowUi.LockScroll();
			yield return null;
			while(m_RaidLobbyController.JHBLAGLBIAD() || m_RaidLobbyController.FJHLAKJBNFA)
				yield return null;
			bbsType = (NKOBMDPHNGP_EventRaidLobby.FLHJEJGJJGE) m_raidSelect;
			preCommentCount = m_RaidLobbyController.JIDLPGHJOIE_GetCommentsCount(bbsType);
			yield return null;
			m_RaidLobbyController.DJEEPILBAIH(bbsType, () =>
			{
				//0xD08F64
				success = true;
				IsDone = true;
			}, () =>
			{
				//0xD08F70
				IsDone = true;
				IsError = true;
			});
			while(!IsDone)
				yield return null;
			if(success)
			{
				yield return null;
				yield return null;
				NextAddComment(m_RaidLobbyController.JIDLPGHJOIE_GetCommentsCount(bbsType) - preCommentCount);
			}
			//LAB_00d0ca64
			if(IsError)
			{
				MenuScene.Instance.GotoTitle();
				IsRequestGotoTitle = true;
			}
			m_windowUi.UnLockScroll();
			MenuScene.Instance.InputEnable();
			IsRequestNextList = false;
		}

		// // RVA: 0x12A5EE8 Offset: 0x12A5EE8 VA: 0x12A5EE8
		// private void OnClickStamp(int stampId, int serifId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E8B14 Offset: 0x6E8B14 VA: 0x6E8B14
		// // RVA: 0x12A5F0C Offset: 0x12A5F0C VA: 0x12A5F0C
		private IEnumerator Co_AddStampItem(int stampId, int serifId)
		{
			//0xD0A5DC
			MenuScene.Instance.InputDisable();
			m_windowUi.LockScroll();
			m_RaidLobbyController.NIIEJKGNEBH();
			yield return Co.R(Co_NetBbsUpdate());
			if(m_IsUpdateError)
			{
				MenuScene.Instance.GotoTitle();
				IsRequestGotoTitle = true;
			}
			else
			{
				yield return Co.R(Co_NetBbsStampCreate(stampId, serifId));
			}
			if(m_raidSelect == 1)
			{
				Debug.Log("StringLiteral_18411");
				m_lobbyLiveWindow.AddLiveStamp(serifId);
			}
			m_windowUi.UnLockScroll();
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0x12A5FC8 Offset: 0x12A5FC8 VA: 0x12A5FC8
		private void OnClickStampInMove(int stampId, int serifId)
		{
			this.StartCoroutineWatched(Co_AddStampItemInMove(stampId, serifId));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E8B8C Offset: 0x6E8B8C VA: 0x6E8B8C
		// // RVA: 0x12A5FEC Offset: 0x12A5FEC VA: 0x12A5FEC
		private IEnumerator Co_AddStampItemInMove(int stampId, int serifId)
		{
			//0xD0AC38
			m_lobbyFooter.IsButtonDisable(true);
			bool success = false;
			bool wait = false;
			m_RaidLobbyController.PMCMAKBNJIL();
			ANPBHCNJIDI.BNEIDPGIAFM d = new ANPBHCNJIDI.BNEIDPGIAFM();
			d.AHHJLDLAPAN_DivaId = GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].AHHJLDLAPAN_DivaId;
			d.NNOHKLNKGAD_CostumeId = GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].JPIDIENBGKH_CostumeId;
			d.LIBPMIHHEJD_StampDiva = d.AHHJLDLAPAN_DivaId;
			d.DJHMGDKKKFO_ColorId = GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].EKFONBFDAAP_ColorId;
			d.HEKIEDEBAEO_StampId = stampId;
			d.EKAMPLIAENM_SerifId = serifId;
			d.GKEKNMJMMPK_CannonLogId = m_mcannonLogId;
			d.PCEHLFNFIDA(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave);
			m_RaidLobbyController.HJNDLPNBBKF((NKOBMDPHNGP_EventRaidLobby.FLHJEJGJJGE)m_raidSelect, d, () =>
			{
				//0xD08F84
				success = true;
				wait = true;
				Debug.Log("StringLiteral_15454");
			}, () =>
			{
				//0xD0901C
				MenuScene.Instance.GotoTitle();
				IsRequestGotoTitle = true;
				Debug.Log("StringLiteral_18410");
			}, () =>
			{
				//0xD0911C
				wait = true;
				Debug.Log("StringLiteral_15455");
			});
			while(!wait)
				yield return null;
			m_lobbyLiveWindow.AddLiveStamp(serifId);
			m_lobbyFooter.IsButtonDisable(false);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E8C04 Offset: 0x6E8C04 VA: 0x6E8C04
		// // RVA: 0x12A60A8 Offset: 0x12A60A8 VA: 0x12A60A8
		private IEnumerator Co_NetBbsStampCreate(int stampId, int serifId)
		{
			//0xD0F37C
			bool success = false;
			bool wait = false;
			m_RaidLobbyController.PMCMAKBNJIL();
			ANPBHCNJIDI.BNEIDPGIAFM m = new ANPBHCNJIDI.BNEIDPGIAFM();
            FFHPBEPOMAK_DivaInfo d = GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0];
            m.AHHJLDLAPAN_DivaId = d.AHHJLDLAPAN_DivaId;
			m.NNOHKLNKGAD_CostumeId = d.JPIDIENBGKH_CostumeId;
			m.LIBPMIHHEJD_StampDiva = d.AHHJLDLAPAN_DivaId;
			m.DJHMGDKKKFO_ColorId = d.EKFONBFDAAP_ColorId;
			m.HEKIEDEBAEO_StampId = stampId;
			m.EKAMPLIAENM_SerifId = serifId;
			m.GKEKNMJMMPK_CannonLogId = m_mcannonLogId;
			m.PCEHLFNFIDA(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave);
			m_RaidLobbyController.HJNDLPNBBKF((NKOBMDPHNGP_EventRaidLobby.FLHJEJGJJGE) m_raidSelect, m, () =>
			{
				//0xD091BC
				success = true;
				wait = true;
				Debug.Log("StringLiteral_15454");
			}, () =>
			{
				//0xD09254
				MenuScene.Instance.GotoTitle();
				IsRequestGotoTitle = true;
				Debug.Log("StringLiteral_18410");
			}, () =>
			{
				//0xD09354
				wait = true;
				Debug.Log("StringLiteral_15455");
			});
			while(!wait)
				yield return null;
			if(success)
			{
				yield return Co.R(Co_NetBbsUpdate());
				if(m_IsUpdateError)
				{
					MenuScene.Instance.GotoTitle();
					IsRequestGotoTitle = true;
				}
				else
				{
					UpdateChatComment();
				}
			}
		}

		// // RVA: 0x12A4A98 Offset: 0x12A4A98 VA: 0x12A4A98
		public void OnClickMovie(LobbyLayoutItemR.CannonMovieInfo cannonInfo)
		{
			this.StartCoroutineWatched(Co_PlayMovie(cannonInfo));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E8C7C Offset: 0x6E8C7C VA: 0x6E8C7C
		// // RVA: 0x12A6208 Offset: 0x12A6208 VA: 0x12A6208
		private IEnumerator Co_MovieInitialize()
		{
			//0xD0E82C
			m_isMovieInitialize = false;
			m_lobbyLiveMessage.SetNmae("");
			m_lobbyLiveMessage.Hide();
			m_lobbyLiveWindow.AllHide();
			m_lobbyLiveSkip.Hide();
			yield break;
		}

		// // RVA: 0x12A6290 Offset: 0x12A6290 VA: 0x12A6290
		private void EndMovie()
		{
			this.StartCoroutineWatched(Co_EndMovie());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E8CF4 Offset: 0x6E8CF4 VA: 0x6E8CF4
		// // RVA: 0x12A62B4 Offset: 0x12A62B4 VA: 0x12A62B4
		private IEnumerator Co_EndMovie()
		{
			//0xD0BBD4
			McrsCannonViewer.Skip();
			while(McrsCannonViewer.IsPlaying())
				yield return null;
			McrsCannonViewer.DeleteCache();
			m_lobbyFooter.Hide();
			while(m_RaidLobbyController.JHBLAGLBIAD() || m_RaidLobbyController.FJHLAKJBNFA)
				yield return null;
			m_raidSelect = m_saveRaidSelect;
			m_windowUi.EffectAnimLoop(m_RaidLobbyController.CHDNDNMHJHI_GetPhase() == NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase.ECAAJMPLIPG_2_Now);
			m_lobbyFooterTransButton.FooterPhaseInit(m_RaidLobbyController);
			yield return Co.R(MenuScene.Instance.BgControl.ChangeBgCoroutine(BgType.LobbyMain, (int)GetBgType(m_RaidLobbyController.CHDNDNMHJHI_GetPhase()), SceneGroupCategory.UNDEFINED, TransitionList.Type.UNDEFINED, -1));
			m_windowUi.Show();
			m_stampWindow.OnClickStamp = (int stamp, int serif) =>
			{
				//0x12A8258
				this.StartCoroutineWatched(Co_AddStampItem(stamp, serif));
				m_stampWindow.Leave();
			};
			m_chatBbsButton.Enter();
			if(!IsMemberLobby)
			{
				MenuScene.Instance.HeaderMenu.MenuStack.EnterBackButton(false);
			}
			else
			{
				m_stampWindow.StampEditHidden(false);
				m_lobbyFooterTransButton.Enter();
				m_homeButton.Enter();
				MenuScene.Instance.HelpButton.TryEnter();
			}
			SoundManager.Instance.bgmPlayer.ContinuousPlay(MenuScene.Instance.GetDefaultBgmId(SceneGroupCategory.LOBBY), 1);
			m_lobbyFooter.SetFooterSwitchButtonAnimation((LobbyFooter.FooterButtonAnimType)m_raidSelect);
			m_lobbyFooter.Enter(IsMemberLobby);
			m_mcannonLogId = 0;
			m_isPlayingMovie = false;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E8D6C Offset: 0x6E8D6C VA: 0x6E8D6C
		// // RVA: 0x12A633C Offset: 0x12A633C VA: 0x12A633C
		private IEnumerator Co_GetBattleLogStamp()
		{
			//0xD0C3E8
			bool isDone = false;
			m_RaidLobbyController.JCCAPHGLOJF(m_mcannonLogId, (List<ANPBHCNJIDI.BNEIDPGIAFM> stamps) =>
			{
				//0xD093F4
				List<int> l = new List<int>();
				int c = stamps.Count;
				if(c > LobbyLiveWindow.GetStampMax)
				{
					c = LobbyLiveWindow.GetStampMax;
				}
				for(int i = 0; i < c; i++)
				{
					l.Add(stamps[i].EKAMPLIAENM_SerifId);
				}
				m_lobbyLiveWindow.SetSerifs(l);
				isDone = true;
			}, () =>
			{
				//0xD09628
				MenuScene.Instance.GotoTitle();
				IsRequestGotoTitle = true;
			});
			while(!isDone)
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E8DE4 Offset: 0x6E8DE4 VA: 0x6E8DE4
		// // RVA: 0x12A63C4 Offset: 0x12A63C4 VA: 0x12A63C4
		private IEnumerator Co_MovieSetting(LobbyLayoutItemR.CannonMovieInfo cannonInfo)
		{
			//0xD0EA1C
			bool done = false;
			McrsCannonViewer.Initiarize(transform, cannonInfo.wavId, cannonInfo.series, cannonInfo.bossImageNum, cannonInfo.bossRank,
				cannonInfo.bossName, cannonInfo.damage, () =>
				{
					//0xD096EC
					done = true;
				});
			while(!done)
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E8E5C Offset: 0x6E8E5C VA: 0x6E8E5C
		// // RVA: 0x12A6164 Offset: 0x12A6164 VA: 0x12A6164
		private IEnumerator Co_PlayMovie(LobbyLayoutItemR.CannonMovieInfo cannonInfo)
		{
			//0xD10A18
			if(m_RaidLobbyController == null)
				yield break;
			MenuScene.Instance.InputDisable();
			m_windowUi.LockScroll();
			while(m_RaidLobbyController.JHBLAGLBIAD() || m_RaidLobbyController.CDCAJDEPMKN())
				yield return null;
			m_stampWindow.OnClickStamp = (int stamp, int serif) =>
			{
				//0xD09700
				OnClickStampInMove(stamp, serif);
				m_stampWindow.Leave();
			};
			m_isPlayingMovie = true;
			m_lobbyLiveMessage.SetNmae(cannonInfo.userName);
			m_stampWindow.StampEditHidden(true);
			m_saveRaidSelect = m_raidSelect;
			m_raidSelect = 1;
			m_mcannonLogId = cannonInfo.logId;
			yield return this.StartCoroutineWatched(Co_GetBattleLogStamp());
			yield return this.StartCoroutineWatched(Co_MovieSetting(cannonInfo));
			m_chatBbsButton.Leave();
			m_windowUi.Hide();
			m_lobbyFooter.Leave(IsMemberLobby);
			if(!IsMemberLobby)
			{
				MenuScene.Instance.HeaderMenu.MenuStack.LeaveBackButton(false);
			}
			else
			{
				m_lobbyFooterTransButton.Leave();
				m_homeButton.Leave();
				m_newsReport.Hide();
				MenuScene.Instance.HelpButton.TryLeave();
			}
			while(IsLayoutPlayingAnim())
				yield return null;
			m_lobbyFooter.SetFooterSwitchButtonAnimation(LobbyFooter.FooterButtonAnimType.Live);
			yield return null;
			m_lobbyFooter.Enter(IsMemberLobby);
			m_windowUi.UnLockScroll();
			MenuScene.Instance.InputEnable();
			CannonEnter();
			SoundManager.Instance.bgmPlayer.Stop();
			bool isEnd = false;
			McrsCannonViewer.Play(() =>
			{
				//0xD09908
				CannonLeave();
				m_lobbyFooter.Hide();
				m_stampWindow.Hide();
			}, () =>
			{
				//0xD09B24
				isEnd = true;
				EndMovie();
			}, null);
			while(!isEnd)
				yield return null;
		}

		// // RVA: 0x12A6468 Offset: 0x12A6468 VA: 0x12A6468
		private bool IsLayoutPlayingAnim()
		{
			return m_homeButton.IsPlayingChild() || m_lobbyFooterTransButton.IsPlayingChild() || 
				m_lobbyFooter.IsPlayingChild() || m_newsReport.IsPlayingChild() || 
				m_windowUi.IsPlayingChild() || m_chatBbsButton.IsPlayingChild();
		}

		// // RVA: 0x12A6560 Offset: 0x12A6560 VA: 0x12A6560
		private void CannonEnter()
		{
			m_lobbyLiveMessage.Enter();
			m_lobbyLiveWindow.AllEnter();
			m_lobbyLiveSkip.Enter();
		}

		// // RVA: 0x12A65D8 Offset: 0x12A65D8 VA: 0x12A65D8
		private void CannonLeave()
		{
			m_lobbyLiveMessage.Leave();
			m_lobbyLiveWindow.AllLeave();
			m_lobbyLiveSkip.Leave();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E8ED4 Offset: 0x6E8ED4 VA: 0x6E8ED4
		// // RVA: 0x12A26C4 Offset: 0x12A26C4 VA: 0x12A26C4
		private IEnumerator HelpFlow()
		{
			//0xD116BC
			yield return Co.R(TutorialManager.TryShowTutorialCoroutine(CheckTutorialFunc_LOBBY_HELP));
			if(m_RaidLobbyController.KINIOEOOCAA_GetPhase(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime()) == NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase.ECAAJMPLIPG_2_Now)
			{
				yield return Co.R(TutorialManager.TryShowTutorialCoroutine(CheckTutorialFunc_LIVE_HELP));
			}
			bool isDone = false;
			bool isError = false;
			if(IsFirstLobby)
			{
				m_RaidLobbyController.NHPFMNGMMHG(() =>
				{
					//0xD09B60
					isDone = true;
					IsGotoNotDeco = true;
					MenuScene.Instance.Call(TransitionList.Type.LOBBY_MEMBER, null, true);
				}, () =>
				{
					//0xD09C38
					isError = true;
					isDone = true;
				});
			}
			else
			{
				isDone = true;
			}
			while(!isDone)
				yield return null;
			if(isError)
			{
				MenuScene.Instance.GotoTitle();
				IsRequestGotoTitle = true;
			}
			IsHelpEnd = true;
		}

		// // RVA: 0x12A663C Offset: 0x12A663C VA: 0x12A663C
		private bool CheckTutorialFunc_LOBBY_HELP(TutorialConditionId conditionId)
		{
			return !GameManager.Instance.IsTutorial && conditionId == TutorialConditionId.Condition74;
		}

		// // RVA: 0x12A66FC Offset: 0x12A66FC VA: 0x12A66FC
		private bool CheckTutorialFunc_LIVE_HELP(TutorialConditionId conditionId)
		{
			return !GameManager.Instance.IsTutorial && conditionId == TutorialConditionId.Condition75;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E8F4C Offset: 0x6E8F4C VA: 0x6E8F4C
		// // RVA: 0x12A2DF0 Offset: 0x12A2DF0 VA: 0x12A2DF0
		private IEnumerator Co_AfterAutoUpdateAct(Action act)
		{
			//0xD0B210
			IsAfterAutoUpdateAct = true;
			MenuScene.Instance.InputDisable();
			m_windowUi.LockScroll();
			while(m_RaidLobbyController.JHBLAGLBIAD() || m_RaidLobbyController.FJHLAKJBNFA)
				yield return null;
			act();
			yield return Co.R(Co_ReloadComment());
			MenuScene.Instance.InputEnable();
			m_windowUi.UnLockScroll();
			IsAfterAutoUpdateAct = false;
		}

		// // RVA: 0x12A67BC Offset: 0x12A67BC VA: 0x12A67BC
		private void OnClickMcGaugeButton()
		{
			m_popupCannonGauge.TitleText = MessageManager.Instance.GetMessage("menu", "pop_deco_sp_item_cannon_title");
			m_popupCannonGauge.m_parent = transform;
			m_popupCannonGauge.WindowSize = SizeType.Middle;
			int curStock;
			int curGauge;
			bool IsMax;
			PBOHJPIBILI.GLEPHGKFFLL(out curStock, out curGauge, out IsMax);
			ViewCannonStockUpdate(IsMax, curStock);
			m_popupCannonGauge.currentStock = curStock;
			m_popupCannonGauge.currentGauge = curGauge;
			m_popupCannonGauge.isCurrentMax = IsMax;
			m_popupCannonGauge.nextGauge = PBOHJPIBILI.JMJOBHFFBGC_GetMcGauge();
			m_popupCannonGauge.isDeco = false;
			m_popupCannonGauge.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			PopupWindowManager.Show(m_popupCannonGauge, OnClickCannonGaugePopup, null, null, null, true, true, false);
		}

		// // RVA: 0x12A6B18 Offset: 0x12A6B18 VA: 0x12A6B18
		private void ViewCannonStockUpdate(bool isMax, int currentStock)
		{
			if(!isMax)
			{
				m_lobbyFooterTransButton.SetCannonStock(currentStock);
			}
			else
			{
				m_lobbyFooterTransButton.SetCannonStock(PBOHJPIBILI.PFNBNKCPFLP_GetCannonStockMax() + 1);
			}
		}

		// // RVA: 0x12A6B7C Offset: 0x12A6B7C VA: 0x12A6B7C
		private void OnClickCannonGaugePopup(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label)
		{
			return;
		}
	}
}
