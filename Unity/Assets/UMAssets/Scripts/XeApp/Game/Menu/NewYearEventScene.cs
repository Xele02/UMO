using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;

namespace XeApp.Game.Menu
{
	public class NewYearEventScene : TransitionRoot
	{
		private LayoutNewYearEvent m_layoutMain; // 0x48
		private PopupNewYearEventSettingWindow m_popupEvent = new PopupNewYearEventSettingWindow(); // 0x4C
		private LayoutPopupNewYearEvent m_popupLayout; // 0x50
		private KNKDBNFMAKF_EventSp m_eventCtrl; // 0x54
		private List<IKDICBBFBMI_EventBase> m_spChildEventControllers = new List<IKDICBBFBMI_EventBase>(); // 0x58
		private List<int> m_eventHelpId = new List<int>(); // 0x5C
		private bool m_isWaitPresetCanvas; // 0x60
		private bool m_isEventTimeLimit; // 0x61
		private bool m_isEventChecked; // 0x62
		private bool m_isInitialized; // 0x63
		private bool m_isShowFirstHelp; // 0x64
		private bool m_isEndActivateScene; // 0x65
		private IHKJLKLAMMC m_viewDataSpPage = new IHKJLKLAMMC(); // 0x68
		private long m_currentTime; // 0x70

		// RVA: 0x15165D0 Offset: 0x15165D0 VA: 0x15165D0
		private void Awake()
		{
			m_layoutMain = transform.Find("Main").GetComponent<LayoutNewYearEvent>();
			m_layoutMain.OnPushButton = OnPushButton;
			this.StartCoroutineWatched(Co_Load());
		}

		// // RVA: 0x1516788 Offset: 0x1516788 VA: 0x1516788
		private void OnPushButton(OHKECKAPJJL info)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			if(!MenuScene.CheckDatelineAndAssetUpdate())
			{
				this.StartCoroutineWatched(Co_PushButton(info));
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F740C Offset: 0x6F740C VA: 0x6F740C
		// // RVA: 0x151687C Offset: 0x151687C VA: 0x151687C
		private IEnumerator Co_PushButton(OHKECKAPJJL info)
		{
			//0x151A060
			if(info.LHMOAJAIJCO_IsNew)
			{
				MenuScene.Instance.InputDisable();
				m_eventCtrl.DHHNKEIBCOK(info.PPFNGGCBJKC_Id, false);
				bool done = false;
				MenuScene.Save(() =>
				{
					//0x151891C
					done = true;
				}, null);
				while(!done)
					yield return null;
				MenuScene.Instance.InputEnable();
				info.LHMOAJAIJCO_IsNew = false;
				m_layoutMain.Apply(m_viewDataSpPage, m_currentTime);
			}
			if(info.LPDLBACJKIB_TransId == 0)
			{
				ShowStoneSalePopup();
			}
			else if(info.LPDLBACJKIB_TransId == 5)
			{
				GotoEventGame(info);
			}
			else if(info.LPDLBACJKIB_TransId == 3)
			{
				ShowCampaignPopup();
			}
			else
			{
				m_viewDataSpPage.GEOGJOBNKHG(info);
			}
		}

		// // RVA: 0x1516944 Offset: 0x1516944 VA: 0x1516944
		private void GotoEventGame(OHKECKAPJJL pageInfo)
		{
            IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(pageInfo.GGHDEDJFFOM);
			//pageInfo.PNDEAHGLJIC
			if(ev != null)
			{
				if(ev.NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DDEODFNANDO_8_ResultRewardToReceive)
				{
					if(ev.FBLGGLDPFDF_CanShowStartAdventure())
					{
						m_viewDataSpPage.GEOGJOBNKHG(pageInfo);
						return;
					}
					GotoEventAdv(ev.GFIBLLLHMPD_StartAdventureId, ev.PGIIDPEGGPI_EventId, ev.HIDHLFCBIDE_EventType);
				}
				else
				{
					if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.FABEJIHKFGN_IsReleased(ev.CAKEOPLJDAF_EndAdventureId))
					{
						m_viewDataSpPage.GEOGJOBNKHG(pageInfo);
						return;
					}
					GotoEventAdv(ev.CAKEOPLJDAF_EndAdventureId, ev.PGIIDPEGGPI_EventId, ev.HIDHLFCBIDE_EventType);
				}
			}
        }

		// // RVA: 0x1516B68 Offset: 0x1516B68 VA: 0x1516B68
		private void GotoEventAdv(int advId, int eventUniqueId, OHCAABOMEOF.KGOGMKMBCPP_EventType eventType)
		{
			if(eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection)
			{
				Database.Instance.advResult.Setup("Menu", TransitionUniqueId.EVENTMUSICSELECT, new AdvSetupParam() { eventUniqueId = eventUniqueId });
			}
			else
			{
				Database.Instance.advResult.Setup("Menu", TransitionUniqueId.HOME_NEWYEAREVENT);
			}
			int fId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EFMAIKAHFEK_Adventure.GCINIJEMHFK_GetAdventure(advId).KKPPFAHFOJI_FileId;
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.GFANLIOMMNA_SetReleased(advId);
			ILCCJNDFFOB.HHCJCDFCLOB.LIIJEGOIKDP(advId, OAGBCBBHMPF.DKAMMIHBINF.KDDHGLNCFMF_8);
			Database.Instance.advSetup.Setup(fId);
			MenuScene.Instance.GotoAdventure(true);
		}

		// RVA: 0x1516EEC Offset: 0x1516EEC VA: 0x1516EEC
		private void Update()
		{
			if(m_popupLayout != null)
				m_popupLayout.LoadImageUpdate();
		}

		// RVA: 0x1516FA0 Offset: 0x1516FA0 VA: 0x1516FA0 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			base.OnStartEnterAnimation();
			m_layoutMain.Enter();
		}

		// RVA: 0x1516FD8 Offset: 0x1516FD8 VA: 0x1516FD8 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_layoutMain.IsPlaying();
		}

		// RVA: 0x1517008 Offset: 0x1517008 VA: 0x1517008 Slot: 23
		protected override void OnActivateScene()
		{
			this.StartCoroutineWatched(Co_OnActivateScene());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F7484 Offset: 0x6F7484 VA: 0x6F7484
		// // RVA: 0x151702C Offset: 0x151702C VA: 0x151702C
		private IEnumerator Co_OnActivateScene()
		{
			//0x1519A18
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				if(m_isShowFirstHelp)
				{
					yield return Co.R(Co_ShowHelp());
				}
			}
			m_isEndActivateScene = true;
		}

		// RVA: 0x15170D8 Offset: 0x15170D8 VA: 0x15170D8 Slot: 14
		protected override void OnDestoryScene()
		{
			m_layoutMain.Release();
		}

		// RVA: 0x1517104 Offset: 0x1517104 VA: 0x1517104 Slot: 24
		protected override bool IsEndActivateScene()
		{
			return m_isEndActivateScene;
		}

		// RVA: 0x151710C Offset: 0x151710C VA: 0x151710C Slot: 12
		protected override void OnStartExitAnimation()
		{
			base.OnStartExitAnimation();
			m_layoutMain.Leave();
		}

		// RVA: 0x1517144 Offset: 0x1517144 VA: 0x1517144 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_layoutMain.IsPlaying();
		}

		// RVA: 0x1517174 Offset: 0x1517174 VA: 0x1517174 Slot: 16
		protected override void OnPreSetCanvas()
		{
			base.OnPreSetCanvas();
			this.StartCoroutineWatched(Co_PresetCanvas());
		}

		// RVA: 0x1517230 Offset: 0x1517230 VA: 0x1517230 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return m_isEventChecked && base.IsEndPreSetCanvas() && m_isWaitPresetCanvas && m_isInitialized;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F74FC Offset: 0x6F74FC VA: 0x6F74FC
		// // RVA: 0x15171A4 Offset: 0x15171A4 VA: 0x15171A4
		private IEnumerator Co_PresetCanvas()
		{
			//0x1519BD8
			m_isEventTimeLimit = false;
			m_currentTime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			m_isEventChecked = false;
			m_eventCtrl = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as KNKDBNFMAKF_EventSp;
			if(!MenuScene.Instance.CheckEventLimit(m_eventCtrl, false, true))
			{
				this.StartCoroutineWatched(Co_ChangeBg());
				m_isEventChecked = true;
				this.StartCoroutineWatched(Co_Initialize());
			}
			else
			{
				while(!PopupWindowManager.IsActivePopupWindow())
					yield return null;
				while(PopupWindowManager.IsActivePopupWindow())
					yield return null;
				AutoFadeFlag = false;
				m_isEventTimeLimit = true;
				m_isEventChecked = true;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F7574 Offset: 0x6F7574 VA: 0x6F7574
		// // RVA: 0x15172A0 Offset: 0x15172A0 VA: 0x15172A0
		private IEnumerator Co_Initialize()
		{
			//0x1518F88
			if(m_isEventTimeLimit)
			{
				if(IsRequestGotoTitle)
					m_isInitialized = true;
				yield break;
			}
			m_isInitialized = false;
			bool done = false;
			bool err = false;
			m_eventCtrl.ADACMHAHHKC_PreSetupEventHome(() =>
			{
				//0x1518930
				done = true;
			}, () =>
			{
				//0x151893C
				done = true;
				err = true;
			});
			while(!done)
				yield return null;
			if(!err)
			{
				done = false;
				err = false;
				JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.LFOBIPKFOEF(OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp, 0, () =>
				{
					//0x1518948
					done = true;
				}, () =>
				{
					//0x1518954
					done = true;
					err = true;
				}, false);
				while(!done)
					yield return null;
				if(!err)
				{
					done = false;
					err = false;
					CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
					{
						//0x1518960
						done = true;
					}, () =>
					{
						//0x151896C
						done = true;
						err = true;
					}, null);
					while(!done)
						yield return null;
					if(!err)
					{
						m_spChildEventControllers.Clear();
						for(int i = 0; i < m_eventCtrl.BAEEGPJJHKD_GetNumSubSp(); i++)
						{
							m_spChildEventControllers.Add(JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(m_eventCtrl.NBLGLKGOKOD_GetSubSpId(i)));
						}
						yield return Co.R(Co_GetGachaProductList());
						m_viewDataSpPage.KHEKNNFCAOI(NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.MHKCPJDNJKI_GatchaProducts);
						m_layoutMain.Apply(m_viewDataSpPage, m_currentTime);
						while(!m_layoutMain.IsDownloaded)
							yield return null;
						SetupHelp();
						m_isInitialized = true;
						yield break;
					}
				}
			}
			m_isInitialized = true;
			GotoTitle();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F75EC Offset: 0x6F75EC VA: 0x6F75EC
		// // RVA: 0x151734C Offset: 0x151734C VA: 0x151734C
		private IEnumerator Co_GetGachaProductList()
		{
			//0x1518C68
			bool isEnd = false;
			NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.LILDGEPCPPG_GetProducList(() =>
			{
				//0x1518980
				isEnd = true;
			}, () =>
			{
				//0x15184A8
				MenuScene.Instance.GotoTitle();
			}, false, false);
			while(!isEnd)
				yield return null;
		}

		// // RVA: 0x15173E0 Offset: 0x15173E0 VA: 0x15173E0
		protected void SetupHelp()
		{
			m_eventHelpId.Clear();
			if(m_eventCtrl.CMPEJEHCOEI)
			{
				List<int> l = m_eventCtrl.GFPCPHOEAFG();
				if(l.Count > 0)
				{
					m_eventHelpId.AddRange(l);
				}
				m_eventCtrl.FJHIHFCAHMH(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
			}
			m_isShowFirstHelp = m_eventCtrl.CMPEJEHCOEI;
			m_eventCtrl.CMPEJEHCOEI = false;
			m_eventCtrl.MMIMJPNLKBK();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F7664 Offset: 0x6F7664 VA: 0x6F7664
		// // RVA: 0x1517640 Offset: 0x1517640 VA: 0x1517640
		protected IEnumerator Co_ShowHelp()
		{
			int helpCount; // 0x18
			int i; // 0x1C

			//0x151A510
			if(m_eventHelpId.Count != 0)
			{
				helpCount = 0;
				for(i = 0; i < m_eventHelpId.Count; i++)
				{
					if(m_eventHelpId[i] != 0)
					{
						MenuScene.Instance.InputDisable();
						yield return Co.R(TutorialManager.ShowTutorial(m_eventHelpId[i], () =>
						{
							//0x1518544
							MenuScene.Instance.InputEnable();
						}));
						helpCount++;
					}
				}
				if(helpCount > 0)
				{
					MenuScene.Instance.InputDisable();
					bool done = false;
					MenuScene.Save(() =>
					{
						//0x1518994
						done = true;
					}, null);
					while(!done)
						yield return null;
					MenuScene.Instance.InputEnable();
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F76DC Offset: 0x6F76DC VA: 0x6F76DC
		// // RVA: 0x15176EC Offset: 0x15176EC VA: 0x15176EC
		private IEnumerator Co_ChangeBg()
		{
			//0x15189F8
			m_isWaitPresetCanvas = false;
			int v;
			int.TryParse(m_viewDataSpPage.AFMHNPCDAFI(m_currentTime), out v);
			yield return this.StartCoroutineWatched(MenuScene.Instance.BgControl.ChangeBgCoroutine(BgType.NewYearEvent, v, SceneGroupCategory.UNDEFINED, TransitionList.Type.UNDEFINED, -1));
			m_isWaitPresetCanvas = true;
		}

		// RVA: 0x1517798 Offset: 0x1517798 VA: 0x1517798 Slot: 20
		protected override bool OnBgmStart()
		{
			SoundManager.Instance.bgmPlayer.ContinuousPlay(BgmPlayer.MINIGAME_BGM_ID_BASE, 1);
			return true;
		}

		// // RVA: 0x1517878 Offset: 0x1517878 VA: 0x1517878
		private void ShowCampaignPopup()
		{
			OHKECKAPJJL btnInfo = m_viewDataSpPage.IMOGBABIDFF(OHKECKAPJJL.GPNHNIGPGCL.NOBPFBOJLJD_3_Campaign);
			if(btnInfo.LPDLBACJKIB_TransId == 0)
			{
				m_popupEvent.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				};
			}
			else
			{
				m_popupEvent.Buttons = new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Live, Type = PopupButton.ButtonType.Live }
				};
			}
			m_popupEvent.IsCaption = false;
			m_popupEvent.WindowSize = SizeType.Middle;
			m_popupEvent.bannerId = btnInfo.LCCDKCPBJAK;
			PopupWindowManager.Show(m_popupEvent, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x15189A0
				m_viewDataSpPage.GEOGJOBNKHG(btnInfo);
			}, (IPopupContent content, PopupTabButton.ButtonLabel label) =>
			{
				//0x15185E0
				return;
			}, null, null, true, true, false);
		}

		// // RVA: 0x1517D10 Offset: 0x1517D10 VA: 0x1517D10
		private void ShowStoneSalePopup()
		{
			if(MenuScene.Instance.DenomControl != null)
			{
				MenuScene.Instance.InputDisable();
				MenuScene.Instance.DenomControl.StartPurchaseSequence(() =>
				{
					//0x15185E4
					MenuScene.Instance.InputEnable();
				}, () =>
				{
					//0x1518680
					MenuScene.Instance.InputEnable();
				}, () =>
				{
					//0x151871C
					MenuScene.Instance.GotoTitle();
				}, (TransitionList.Type type) =>
				{
					//0x15187B8
					if(type == TransitionList.Type.TITLE)
					{
						MenuScene.Instance.GotoTitle();
					}
					else if(type == TransitionList.Type.LOGIN_BONUS)
					{
						MenuScene.Instance.GotoLoginBonus();
					}
					MenuScene.Instance.InputEnable();
				}, null);
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F7754 Offset: 0x6F7754 VA: 0x6F7754
		// // RVA: 0x15166FC Offset: 0x15166FC VA: 0x15166FC
		private IEnumerator Co_Load()
		{
			//0x1519884
			yield return this.StartCoroutineWatched(LoadPopupWindow());
			while(!m_layoutMain.IsLoaded())
				yield return null;
			IsReady = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F77CC Offset: 0x6F77CC VA: 0x6F77CC
		// // RVA: 0x15181B4 Offset: 0x15181B4 VA: 0x15181B4
		private IEnumerator LoadPopupWindow()
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x151AA78
			operation = AssetBundleManager.LoadLayoutAsync(m_popupEvent.BundleName, m_popupEvent.AssetName);
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(MenuScene.Instance.GetFont(), (GameObject instance) =>
			{
				//0x151836C
				m_popupEvent.SetContent(instance);
				m_popupLayout = instance.GetComponent<LayoutPopupNewYearEvent>();
			}));
			m_popupEvent.SetParent(transform);
			AssetBundleManager.UnloadAssetBundle(m_popupEvent.BundleName, false);
		}
	}
}
