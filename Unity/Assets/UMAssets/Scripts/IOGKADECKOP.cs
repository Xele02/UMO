using UnityEngine;
using XeApp.Game;
using XeApp.Game.Menu;
using XeApp.Game.Title;
using XeApp.Game.Common.uGUI;
using UnityEngine.UI;
using System.Collections;
using XeApp;
using UdonLib;
using XeApp.Game.Common;
using Mana.Service.Ad;
using XeSys;
using XeApp.Core;
using SecureLib;
using XeApp.Game.AR;
using System;
using System.Collections.Generic;
using System.IO;
using mcrs;

public class IOGKADECKOP
{
    public delegate void BBCOMMKDEDF(string INHEEPHFAON);

	private MonoBehaviour DANMJLOBLIE; // 0x8
	private bool BICOBOLNFLJ; // 0xC
	private UMOInheritingMenu MCJHELIEHMC; // 0x10
	private LayoutTitleController NOFPJPHIPBD_LayoutTitleCtrl; // 0x14
	private RawImage PDOILOAFKCF_BgImage; // 0x18
	private GameObject HOFMODFAOEA; // 0x1C
	private string ABJDBPINCIC = "DownLoad"; // 0x20
	public IOGKADECKOP.BBCOMMKDEDF OGNDELCENBB; // 0x24
	private AMOCLPHDGBP OFFPKPHHLKD; // 0x28
	private bool OKDMEMPECDO; // 0x2C
	private bool LKFGMDGFKDP; // 0x2D
	private bool JJHGAKDMGLJ_NoTutorial; // 0x2E
	private BgBehaviour IJCPLBPLJLJ; // 0x30
	private bool EHKDIJELHAO; // 0x34
	private bool OOIBKCCMCAG_HasCustomBg; // 0x35
	private int NLFFEOBGFMC_BgId; // 0x38
	private int BLEAOGCLJPK_TitleBannerAssetId; // 0x3C
	private readonly int[] MLDJAIHDFOM = new int[10] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}; // 0x40

	// // RVA: 0xA061D8 Offset: 0xA061D8 VA: 0xA061D8
	public void LIGFHEAKAGD(MonoBehaviour DANMJLOBLIE)
    {
        this.DANMJLOBLIE = DANMJLOBLIE;
        for(int i = 0; i < DANMJLOBLIE.transform.parent.childCount; i++)
        {
            if(DANMJLOBLIE.transform.parent.GetChild(i).name == "Bg")
                PDOILOAFKCF_BgImage = DANMJLOBLIE.transform.parent.GetChild(i).GetComponent<RawImage>();
        }
        GameManager.Instance.SetFPS(30);
    }

	// // RVA: 0xA063BC Offset: 0xA063BC VA: 0xA063BC
	public void BHADKPGCNCP()
    {
        BICOBOLNFLJ = false;
        JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
        PGIGNJDPCAH.NNOBACMJHDM(PGIGNJDPCAH.FELLIEJEPIJ.FFPANKMKAPD);
        PGIGNJDPCAH.IPJMPBANBPP = false;
        PGIGNJDPCAH.MLPMNKKNFCJ();
        MenuScene.IsFirstTitleFlow = true;
        GameManager.Instance.ClearPushBackButtonHandler();
        GameManager.Instance.SetTransmissionIconPosition(false);
        DANMJLOBLIE.StartCoroutineWatched(GGKONDNONPP_BootCoroutine());
    }

	// // RVA: 0xA065F0 Offset: 0xA065F0 VA: 0xA065F0
	public bool FKDKMCKJNJD()
    {
		if(!BICOBOLNFLJ)
			return false;
		
        MCJHELIEHMC = UMOInheritingMenu.Create(null);
		DANMJLOBLIE.StartCoroutineWatched(LMDJGHMDDJA_LogoActCoroutine());
        return true;
    }

	// // RVA: 0xA066E0 Offset: 0xA066E0 VA: 0xA066E0
	public void FGBKOJCFMKM()
    {
		if(MCJHELIEHMC.IsOpen)
			return;
		
		if(NOFPJPHIPBD_LayoutTitleCtrl.IsSupportPopupOpen)
			return;
		
		NOFPJPHIPBD_LayoutTitleCtrl.Buttons.CallbackClear();
		NOFPJPHIPBD_LayoutTitleCtrl.LbButtons.CallbackClear();
		SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_TITLE_000);
		NOFPJPHIPBD_LayoutTitleCtrl.ScreenTap.ClearCallback();
		NOFPJPHIPBD_LayoutTitleCtrl.Screen.TapAnim();
		DANMJLOBLIE.StartCoroutineWatched(PFEKBBONCJJ_Coroutine_GameStart());
    }

	// // RVA: 0xA0694C Offset: 0xA0694C VA: 0xA0694C
	public void OCCAKNDDCMA()
	{
		if (MCJHELIEHMC.IsOpen)
			return;
		if (NOFPJPHIPBD_LayoutTitleCtrl.IsSupportPopupOpen)
			return;
		NOFPJPHIPBD_LayoutTitleCtrl.Buttons.CallbackClear();
		NOFPJPHIPBD_LayoutTitleCtrl.LbButtons.CallbackClear();
		SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_TITLE_000);
		NOFPJPHIPBD_LayoutTitleCtrl.ScreenTap.ClearCallback();
		DANMJLOBLIE.StartCoroutineWatched(KOEILOLECCF_Coroutine_StartARMode());
	}

	// // RVA: 0xA06B74 Offset: 0xA06B74 VA: 0xA06B74
	// public void GIPPBCOMDGL() { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B3CB8 Offset: 0x6B3CB8 VA: 0x6B3CB8
	// // RVA: 0xA06658 Offset: 0xA06658 VA: 0xA06658
	private IEnumerator LMDJGHMDDJA_LogoActCoroutine()
	{
		//0x14087CC
		PJKLMCGEJMK LPKMGOHDKGM = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester;
		while(!(NOFPJPHIPBD_LayoutTitleCtrl.IsSetup && !LKFGMDGFKDP))
		{
			yield return null;
		}
		if(NOFPJPHIPBD_LayoutTitleCtrl.Texts != null)
		{
			NOFPJPHIPBD_LayoutTitleCtrl.Texts.SetStatus();
		}
		yield return null;
		SoundManager.Instance.bgmPlayer.Play(BgmConstant.Name.Title, 1);
		CFGABDOEHBI();
		GameManager.FadeIn(0.4f);
		yield return GameManager.Instance.WaitFadeYielder;
		
		GameManager.Instance.InputEnabled = true;
		GameManager.Instance.AddPushBackButtonHandler(this.GJLDMJFMIOD_OnPushBackButton);
		NOFPJPHIPBD_LayoutTitleCtrl.ScreenTap.SetCallback();
		SoundManager.Instance.voTitlecall.EntrySheet();
		yield return new WaitForSeconds(0.5f);
		
		int rand = UnityEngine.Random.Range(0, MLDJAIHDFOM.Length);
		int divaId = MLDJAIHDFOM[rand];
		if(!LPKMGOHDKGM.LMBLIFCNKCJ)
		{
			SoundManager.Instance.voTitlecall.Play(divaId, 0);
		}
		NOFPJPHIPBD_LayoutTitleCtrl.LbButtons.OnUpdateBG = UpdateBG;
		NOFPJPHIPBD_LayoutTitleCtrl.Show();
		if(EHKDIJELHAO)
		{
			NOFPJPHIPBD_LayoutTitleCtrl.ShowArButton();
		}
		DANMJLOBLIE.StartCoroutineWatched(HNPMKCFMEGA_Coroutine_Inquiry());
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B3D30 Offset: 0x6B3D30 VA: 0x6B3D30
	// // RVA: 0xA06564 Offset: 0xA06564 VA: 0xA06564
	private IEnumerator GGKONDNONPP_BootCoroutine()
    {
		// 0xA0976C
		if(!GameManager.Instance.IsSystemInitialized)
		{
			yield return DANMJLOBLIE.StartCoroutineWatched(DFLFHJHBKOC_CoroutineAppBoot());
		}
		else
		{
			yield return DANMJLOBLIE.StartCoroutineWatched(FIIEPEEMMLD_CoroutineStart());
		}
		GameManager.Instance.ResetSystemCanvasCamera();
		yield return Co.R(GameManager.Instance.UnloadAllAssets());
		yield return DANMJLOBLIE.StartCoroutineWatched(LLMFFOGJNLH_Coroutine_Initialize());
		BICOBOLNFLJ = true;
    }

	// [IteratorStateMachineAttribute] // RVA: 0x6B3DA8 Offset: 0x6B3DA8 VA: 0x6B3DA8
	// // RVA: 0xA06B98 Offset: 0xA06B98 VA: 0xA06B98
	private IEnumerator DFLFHJHBKOC_CoroutineAppBoot()
	{
	// private IOGKADECKOP.<>c__DisplayClass27_0 OPLBFCEPDCH; // 0x14
	// private IOGKADECKOP.<>c__DisplayClass27_1 LBLMCMHMNGC; // 0x18
	// private IOGKADECKOP.<>c__DisplayClass27_2 PHPPCOBECCA; // 0x1C
		// 0xA09AA4
		GameManager.Instance.InitializeSystem();
		GameManager.Instance.fullscreenFader.Fade(0.0f, Color.black);
		GameManager.Instance.SetupResolutionDefault();
		
		while(!GameManager.Instance.IsSystemInitialized)
		{
			yield return null;
		}
		SoundResource.DecCacheClear();
		ConfigManager.SetUserData();
		GameManager.Instance.ChangePopupPriority(true);
		GameManager.Instance.SetSystemCanvasRenderMode(RenderMode.ScreenSpaceCamera);
		GameManager.Instance.SetTouchEffectVisible(true);
		DANMJLOBLIE.StartCoroutineWatched(BLJICEOFNMM_LoadLayoutTitle());
		DANMJLOBLIE.StartCoroutineWatched(IMDAHCEDGFK_Coroutine_TitleLogo());
		if(AppEnv.IsCBT())
		{
			TodoLogger.LogError(TodoLogger.CBT, "TODO");
		}
		else
		{
			bool BEKAMBBOLBO = false;
			NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.OLBAIKLLIFE = true;
			NKGJPJPHLIF.HHCJCDFCLOB.HGJKAEOLMJN_InitializePlayerToken(() => {
				//0xA08F1C
				BEKAMBBOLBO = true;
			}, () => {
				// 0xA08F28
				BEKAMBBOLBO = true;
			}, true, false);
			while(!BEKAMBBOLBO)
			{
				yield return null;
			}
			NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.OLBAIKLLIFE = false;
			OKDMEMPECDO = true;
			while(!StorageSupport.IsAvailableStorage())
			{
				bool HFPLKFCPHDK_ = true;
				TextPopupSetting s = new TextPopupSetting();
				s.Text = MessageManager.Instance.GetMessage("common", "popup_error_storage_size");
				s.IsCaption = false;
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Retry, Type = PopupButton.ButtonType.Positive }
				};
				PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel KAPMOPMDHJE) =>
				{
					//0xA08F48
					HFPLKFCPHDK_ = false;
				}, null, null, null);
				while(HFPLKFCPHDK_)
				{
					yield return null;
				}
			}
			ManaAdAPIHelper.Instance.SendLaunchEvent();
			ManaAdAPIHelper.Instance.TryPendingSendResumeEvent();
			BEKAMBBOLBO = false;
			NMFABEKNBKJ.HHCJCDFCLOB.OJKIKODJJCD(() => {
				//0xA08F34
				BEKAMBBOLBO = true;
			}, () => {
				return;
			});
			while(!BEKAMBBOLBO)
			{
				yield return null;
			}
			EOHDAOAJOHH.HHCJCDFCLOB.OJKIKODJJCD();
			if (IOSBridge.GetOSMajorVersion() < 14)
			{
				yield break;
			}
			bool HFPLKFCPHDK = true;
			com.adjust.sdk.Adjust.requestTrackingAuthorizationWithCompletionHandler((int LHMDABPNDDH) => {
				//0xA08F5C
				if(LHMDABPNDDH == 3)
					com.adjust.sdk.Adjust.setEnabled(true);
				HFPLKFCPHDK = false;
			}, "Adjust");
			while(HFPLKFCPHDK)
			{
				yield return null;
			}
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B3E20 Offset: 0x6B3E20 VA: 0x6B3E20
	// // RVA: 0xA06C44 Offset: 0xA06C44 VA: 0xA06C44
	private IEnumerator FIIEPEEMMLD_CoroutineStart()
	{
		//0xA0A82C
		ConfigManager.SetUserData();
		GameManager.Instance.fullscreenFader.Fade(0, Color.black);
		GameManager.Instance.SetupResolutionDefault();
		GameManager.Instance.SetSystemCanvasRenderMode(RenderMode.ScreenSpaceCamera);
		GameManager.Instance.SetTouchEffectVisible(true);
		GameManager.Instance.SetTouchEffectMode(false);
		Vector2 screenSize;
		if(!SystemManager.isLongScreenDevice)
		{
			screenSize = SystemManager.BaseScreenSize;
		}
		else
		{
			screenSize = SystemManager.longScreenReferenceResolution;
		}
		GameManager.Instance.SetSystemCanvasResolution(screenSize);
		yield return DANMJLOBLIE.StartCoroutineWatched(BLJICEOFNMM_LoadLayoutTitle());
		LKFGMDGFKDP = false;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B3E98 Offset: 0x6B3E98 VA: 0x6B3E98
	// // RVA: 0xA06CF0 Offset: 0xA06CF0 VA: 0xA06CF0
	private IEnumerator LLMFFOGJNLH_Coroutine_Initialize()
	{
        //0xA0F2C4
		bool BEKAMBBOLBO = false;
		bool CNAIDEAFAAM = false;
		AssetBundleManager.isTutorialNow = false;
		if(!OKDMEMPECDO)
		{
			NKGJPJPHLIF.HHCJCDFCLOB.HGJKAEOLMJN_InitializePlayerToken(() => {
				//0xA08F90
				BEKAMBBOLBO = true;
			}, () => {
				// 0xA08F9C
				BEKAMBBOLBO = true;
				CNAIDEAFAAM = true;
			}, true, false);
			while(!BEKAMBBOLBO)
			{
				yield return null;
			}
		}
		OKDMEMPECDO = false;
		
		BEKAMBBOLBO = false;
		CNAIDEAFAAM = false;
		NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.OLBAIKLLIFE = true;
		DOKOHKJIDBO.HHCJCDFCLOB.DBEPFLFHAFH_RequestMaster(false, () => {
			// 0xA08FA8
			BEKAMBBOLBO = true;
		}, () => {
			// 0xA08FB4
			BEKAMBBOLBO = true;
			CNAIDEAFAAM = true;
		});
		while(!BEKAMBBOLBO)
		{
			yield return null;
		}
		
		BEKAMBBOLBO = false;
		CNAIDEAFAAM = false;
		NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.OLBAIKLLIFE = true;
		NKGJPJPHLIF.HHCJCDFCLOB.LLMEJNALPJD(false, () => {
			// 0xA08FC0
			BEKAMBBOLBO = true;
		}, () => {
			// 0xA08FCC
			BEKAMBBOLBO = true;
			CNAIDEAFAAM = true;
		}, false);
		while(!BEKAMBBOLBO)
		{
			yield return null;
		}
		NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.OLBAIKLLIFE = false;
		SoundResource.DecCacheClear();
		yield return DANMJLOBLIE.StartCoroutineWatched(LCCKLAEOAMB_Coroutine_InitAREventAndTitleBG());
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B3F10 Offset: 0x6B3F10 VA: 0x6B3F10
	// // RVA: 0xA06D9C Offset: 0xA06D9C VA: 0xA06D9C
	private IEnumerator BLJICEOFNMM_LoadLayoutTitle()
	{
		//0x1404868
		if(IJCPLBPLJLJ == null)
		{
			IJCPLBPLJLJ = UnityEngine.Object.FindObjectOfType<BgBehaviour>();
			while(IJCPLBPLJLJ == null)
			{
				yield return null;
			}
			IJCPLBPLJLJ.SetMenu();
			IJCPLBPLJLJ.ChangeColor(BgBehaviour.ColorType.Setting);
			IJCPLBPLJLJ.gameObject.SetActive(false);
			IJCPLBPLJLJ.transform.SetSiblingIndex(1);
		}
		if(NOFPJPHIPBD_LayoutTitleCtrl == null)
		{
			NOFPJPHIPBD_LayoutTitleCtrl = new LayoutTitleController();
			NOFPJPHIPBD_LayoutTitleCtrl.Parent = DANMJLOBLIE.transform.parent.gameObject;
			bool CJFHNONJGIP = false;
			bool ACEAJMLOEBK = false;
			bool DEKGLHFKHBK = false;
			bool CLEFCNJNLJJ = false;
			bool AOHHKIPNNND = false;
			bool PIDLFGNJPMJ = false;
			bool IHDCDHLLAJN = false;
			bool LOAFINDJGMC = false;
			bool OPLHMBBOCCH = false;
			DANMJLOBLIE.StartCoroutineWatched(NOFPJPHIPBD_LayoutTitleCtrl.LoadLayoutTitleLogo(() => {
				// 0xA08FE0
				CJFHNONJGIP = true;
			}));
			DANMJLOBLIE.StartCoroutineWatched(NOFPJPHIPBD_LayoutTitleCtrl.LoadLayoutButtons(() => {
				// 0xA08FEC
				ACEAJMLOEBK = true;
			}));
			DANMJLOBLIE.StartCoroutineWatched(NOFPJPHIPBD_LayoutTitleCtrl.LoadLayoutLbButtons(() => {
				// 0xA08FF8
				DEKGLHFKHBK = true;
			}));
			DANMJLOBLIE.StartCoroutineWatched(NOFPJPHIPBD_LayoutTitleCtrl.LoadLayoutArButton(() => {
				// 0xA09004
				LOAFINDJGMC = true;
			}));
			DANMJLOBLIE.StartCoroutineWatched(NOFPJPHIPBD_LayoutTitleCtrl.LoadLayoutScreenTap(() => {
				// 0xA09010
				CLEFCNJNLJJ = true;
			}));
			DANMJLOBLIE.StartCoroutineWatched(NOFPJPHIPBD_LayoutTitleCtrl.LoadLayoutScreen(() => {
				// 0xA0901C
				AOHHKIPNNND = true;
			}));
			DANMJLOBLIE.StartCoroutineWatched(NOFPJPHIPBD_LayoutTitleCtrl.LoadLayoutTexts(() => {
				// 0xA09028
				PIDLFGNJPMJ = true;
			}));
			DANMJLOBLIE.StartCoroutineWatched(NOFPJPHIPBD_LayoutTitleCtrl.LoadLayoutCopyRight(() => {
				// 0xA09034
				IHDCDHLLAJN = true;
			}));
			DANMJLOBLIE.StartCoroutineWatched(NOFPJPHIPBD_LayoutTitleCtrl.LoadLayoutMonthlyPass(() => {
				// 0xA09040
				OPLHMBBOCCH = true;
			}));
			while(!CJFHNONJGIP && !ACEAJMLOEBK && !DEKGLHFKHBK && !LOAFINDJGMC && !CLEFCNJNLJJ && !AOHHKIPNNND && !PIDLFGNJPMJ && !IHDCDHLLAJN && !OPLHMBBOCCH)
			{
				yield return null;
			}
			NOFPJPHIPBD_LayoutTitleCtrl.LayoutSetup();
		}
	}

	// // RVA: 0xA06E24 Offset: 0xA06E24 VA: 0xA06E24
	private void PELOLGDNOGL()
	{
		NOFPJPHIPBD_LayoutTitleCtrl.ScreenTap.ButtonCallbackTap = this.FGBKOJCFMKM;
		NOFPJPHIPBD_LayoutTitleCtrl.Buttons.ButtonCallbackSupport = () =>
		{
			//0xA085A0
			if (NOFPJPHIPBD_LayoutTitleCtrl.IsSupportPopupOpen)
				return;
			NOFPJPHIPBD_LayoutTitleCtrl.PopupShowSupport(null);
		};
		NOFPJPHIPBD_LayoutTitleCtrl.Buttons.ButtonCallbackInheriting = () =>
		{
			//0xA085FC
			if(!MCJHELIEHMC.IsOpen)
			{
				GraphicRaycaster g = NOFPJPHIPBD_LayoutTitleCtrl.Parent.GetComponentInParent<GraphicRaycaster>();
				g.enabled = false;
				MCJHELIEHMC.PopupShowMenu(false, () =>
				{
					//0xA087F8
					if(NOFPJPHIPBD_LayoutTitleCtrl.Texts != null)
					{
						NOFPJPHIPBD_LayoutTitleCtrl.Texts.SetStatus();
					}
				}, () =>
				{
					//0xA0904C
					g.enabled = true;
				}, NOFPJPHIPBD_LayoutTitleCtrl.MonthlyPass);
			}
		};
		NOFPJPHIPBD_LayoutTitleCtrl.LbButtons.ButtonCallbackGpgs = () =>
		{
			//0xA08B2C
			NDABOOOOENC.HHCJCDFCLOB.OHFNPFMHMMJ_TryLogin(() =>
			{
				//0xA08CA0
				return;
			}, true);
		};
		NOFPJPHIPBD_LayoutTitleCtrl.ArButton.OnClickArButton = OCCAKNDDCMA;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B3F88 Offset: 0x6B3F88 VA: 0x6B3F88
	// // RVA: 0xA07174 Offset: 0xA07174 VA: 0xA07174
	private IEnumerator ABPGOJDKKHO_Coroutine_PopupShowSNS(Action KBCBGIGOLHP, Action AOCANKOMKFG, bool DLNDPMNLMGC = false)
	{
		//0x1405480
		if(!AppEnv.IsCBT())
		{
			bool BEKAMBBOLBO_IsDone = false;
			bool GIGHIFOIMNA = false;
			bool DOGDHKIEBJA_IsError = false;
			HDEEBKIFLNI.HHCJCDFCLOB.NLCBOJBAJFB_GetLinkageStatuses(() =>
			{
				//0xA09084
				BEKAMBBOLBO_IsDone = true;
			}, () =>
			{
				//0xA09090
				BEKAMBBOLBO_IsDone = true;
				GIGHIFOIMNA = true;
			}, () =>
			{
				//0xA0909C
				DOGDHKIEBJA_IsError = true;
				BEKAMBBOLBO_IsDone = true;
			});
			while (!BEKAMBBOLBO_IsDone)
				yield return null;
			if(!DOGDHKIEBJA_IsError)
			{
				bool b = HDEEBKIFLNI.HHCJCDFCLOB.EPAKLDBFECD_IsLinked(HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink.AIECBKAKOGC_Twitter/*0*/);
				bool b2 = HDEEBKIFLNI.HHCJCDFCLOB.EPAKLDBFECD_IsLinked(HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink.OKEAEMBLENP_Facebook/*2*/);
				bool b3 = HDEEBKIFLNI.HHCJCDFCLOB.EPAKLDBFECD_IsLinked(HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink.LMODEBIKEBC_Line/*1*/);
				bool b4 = GameManager.Instance.localSave.EPJOACOONAC_GetSave().OFMECFHNCHA_Popup.MDBINDIACKP_CanShowPopup(ILDKBCLAFPB.EHNBPANMAKA_Popup.FEGJEHDIEMM.HLFFEADNEHB_AccountBindPopup/*1*/);
				int snsCoopPopupDisable = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("sns_coop_popup_disable", 0);
				if (HDEEBKIFLNI.HHCJCDFCLOB.OJOFAOEGEIP_IsVersionValid(HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink.LMODEBIKEBC_Line/*1*/))
				{
					bool LFAFFICDFMJ_IsDone = false;
					JHHBAFKMBDL.HHCJCDFCLOB.NELJJPGFGOA(() =>
					{
						//0xA090DC
						LFAFFICDFMJ_IsDone = true;
					});
					while (!LFAFFICDFMJ_IsDone)
						yield return null;
					MCJHELIEHMC.PopupShowPreparationNotice(false, KBCBGIGOLHP, () => {
						//0xA090AC
						if (AOCANKOMKFG != null)
							AOCANKOMKFG();
					});
					yield break;
				}
				if(snsCoopPopupDisable < 1 && !b && !b2 && !b3 && b4)
				{
					if (MCJHELIEHMC == null)
						yield break;
					MCJHELIEHMC.PopupShowPreparationNotice(true, KBCBGIGOLHP, () => {
						//0xA090C0
						if (AOCANKOMKFG != null)
							AOCANKOMKFG();
					});
					yield break;
				}
				if (KBCBGIGOLHP != null)
					KBCBGIGOLHP();
			}
			else
			{
				if (AOCANKOMKFG != null)
					AOCANKOMKFG();
			}
		}
		if (KBCBGIGOLHP != null)
			KBCBGIGOLHP();
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B4000 Offset: 0x6B4000 VA: 0x6B4000
	// // RVA: 0xA07248 Offset: 0xA07248 VA: 0xA07248
	private IEnumerator IMDAHCEDGFK_Coroutine_TitleLogo()
	{
		//0x140845C
		LKFGMDGFKDP = true;
		
		while(NOFPJPHIPBD_LayoutTitleCtrl.TitleLogo == null || NOFPJPHIPBD_LayoutTitleCtrl.TitleLogo.IsLoaded())
		{
			yield return null;
		}
		NOFPJPHIPBD_LayoutTitleCtrl.TitleLogo.SetStatus();
		NOFPJPHIPBD_LayoutTitleCtrl.TitleLogo.Show();
		
		while(!NOFPJPHIPBD_LayoutTitleCtrl.TitleLogo.IsClose)
		{
			yield return null;
		}

		NOFPJPHIPBD_LayoutTitleCtrl.TitleLogo.Hide();
		LKFGMDGFKDP = false;

	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B4078 Offset: 0x6B4078 VA: 0x6B4078
	// // RVA: 0xA072D0 Offset: 0xA072D0 VA: 0xA072D0
	private IEnumerator IMJGOIOLGIO_Coroutine_Contract(Action FHANAFNKIFC_OnSuccess, Action DOGDHKIEBJA_OnFail)
	{
		EFLBHNFNFHA EPAIEPBGBEL;

		//0xA0ACCC
		EPAIEPBGBEL = new EFLBHNFNFHA();
		EPAIEPBGBEL.PCODDPDFLHK_Refresh();
		if(!EPAIEPBGBEL.CILPABJCBPH_AgreeTos)
		{
			bool HFPLKFCPHDK = false;
			bool CILPABJCBPH = false;
			HFPLKFCPHDK = false;
			PopupContractSetting setting = new PopupContractSetting();
			setting.TitleText = MessageManager.Instance.GetBank("common").GetMessageByLabel("popup_kiyaku_title");
			setting.WindowSize = SizeType.Small;
			setting.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Disagree, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Agree, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(setting, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel KAPMOPMDHJE) =>
			{
				//0xA090F0
				if (INDDJNMPONH == PopupButton.ButtonType.Positive)
					CILPABJCBPH = true;
			}, null, null, null, true, true, false, () =>
			{
				//0xA09100
				HFPLKFCPHDK = true;
				return true;
			});
			while (HFPLKFCPHDK == false)
				yield return null;
			if(CILPABJCBPH == false)
			{
				if(DOGDHKIEBJA_OnFail != null)
					DOGDHKIEBJA_OnFail();
				yield break;
			}
			else
			{
				EPAIEPBGBEL.HJMKBCFJOOH_SetAgreeTos();
			}
		}
		if (FHANAFNKIFC_OnSuccess != null)
			FHANAFNKIFC_OnSuccess();
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B40F0 Offset: 0x6B40F0 VA: 0x6B40F0
	// // RVA: 0xA07398 Offset: 0xA07398 VA: 0xA07398
	private IEnumerator HNPMKCFMEGA_Coroutine_Inquiry()
	{
		//0x140453C

		bool AKIJKNDJNKP_Running = false;
		if(NKGJPJPHLIF.HHCJCDFCLOB.AFJEOKGBCNA_NumReplies > 0)
		{
			AKIJKNDJNKP_Running = true;
			MBCPNPNMFHB.HHCJCDFCLOB.MDGPGGLHIPB_ShowWebUrl(MHOILBOJFHL.KCAEDEHGAFO.CCFMGBNHMNN_Inquiry/*1*/, () =>
			{
				//0xA09118
				NKGJPJPHLIF.HHCJCDFCLOB.LLMEJNALPJD(true, () =>
				{
					//0xA09264
					AKIJKNDJNKP_Running = false;
				}, () =>
				{
					//0xA09270
					AKIJKNDJNKP_Running = false;
				}, false);
			}, () =>
			{
				//0xA0927C
				AKIJKNDJNKP_Running = false;
			});
		}
		while (AKIJKNDJNKP_Running)
			yield return null;
		PELOLGDNOGL();
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B4168 Offset: 0x6B4168 VA: 0x6B4168
	// // RVA: 0xA068C0 Offset: 0xA068C0 VA: 0xA068C0
	private IEnumerator PFEKBBONCJJ_Coroutine_GameStart()
	{
	// private IOGKADECKOP.<>c__DisplayClass36_0 OPLBFCEPDCH; // 0x14
	// private IOGKADECKOP.<>c__DisplayClass36_1 LBLMCMHMNGC; // 0x18
	// private IOGKADECKOP.<>c__DisplayClass36_2 PHPPCOBECCA; // 0x1C
	// private CIOECGOMILE NLJKCDHIPEG; // 0x20
	// private IMMAOANGPNK MPHCKPBAKMO; // 0x24
	// private LAPFLEEAACL[] EMOMAPKPGGK; // 0x28
	// private NHPDPKHMFEP MGPMDNDOBFI; // 0x2C
	// private int FHACAEAHPIA; // 0x30
		//0xA0B93C
		if(UMOLogWritter.Instance != null)
		{
			UMOLogWritter.Instance.CheckEnabled();
		}

		// 0
		PGIGNJDPCAH.NNOBACMJHDM(0);
		PGIGNJDPCAH.IPJMPBANBPP = true;
		PGIGNJDPCAH.OGAIOKGEMDE = false;
		CNGFKOJANNP a = CNGFKOJANNP.HHCJCDFCLOB;
		if(a != null)
		{
			a.EGDJHGIAFGO_Start();
		}
		GameManager.Instance.fullscreenFader.Fade(0.5f, Color.black);
		GameManager.Instance.RemovePushBackButtonHandler(this.GJLDMJFMIOD_OnPushBackButton);
		KEHOJEJMGLJ.HHCJCDFCLOB.OFLDICKPNFD(true, () => {
			//0xA08CA4
			MenuScene.Instance.GotoTitle();
		});
		KDLPEDBKMID.HHCJCDFCLOB.OFLDICKPNFD(true, () => {
			//0xA08D40
			MenuScene.Instance.GotoTitle();
		});
		TipsControl.SetSituationValue(TipsControl.SituationId.Boot1stInformation,1);
			// goto LAB_00a0eba0;
		yield return GameManager.Instance.WaitFadeYielder; // To 1
		
		// 1
		CIOECGOMILE NLJKCDHIPEG = CIOECGOMILE.HHCJCDFCLOB;
		IMMAOANGPNK MPHCKPBAKMO = IMMAOANGPNK.HHCJCDFCLOB;
		NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.MBOIDKCMCDL = false;
		
		bool BEKAMBBOLBO_Done = false;
		bool CNAIDEAFAAM_IsError = false;
		bool OOICHDNLLJG_NeedTuto = false;
		NKGJPJPHLIF.HHCJCDFCLOB.HGJKAEOLMJN_InitializePlayerToken(() => {
			//0xA09290
			BEKAMBBOLBO_Done = true;
		}, () => {
			//0xA0929C
			BEKAMBBOLBO_Done = true;
			CNAIDEAFAAM_IsError = true;
		}, false,false);
			// goto LAB_00a0c574;
		// 2
		//LAB_00a0c574:
		while(!BEKAMBBOLBO_Done)
		{
			//LAB_00a0e350:
			yield return null; // To 2
		}
		// L337
		if(CNAIDEAFAAM_IsError)
		{
			// break
			NLJKCDHIPEG = null;
			MPHCKPBAKMO = null;
			DANMJLOBLIE.StartCoroutineWatched(NNPDJBJGBFA_Coroutine_ReturnToTitle());
        	TodoLogger.LogError(TodoLogger.Coroutine, "Exit  Error PFEKBBONCJJ_Coroutine_GameStart");
			yield break;
		}
		int checkSecure = 0;
		if(SecureLibAPI.isRooted())
			checkSecure = 1;
		if(SecureLibAPI.isEmulator())
			checkSecure |= 2;
		if(SecureLibAPI.isDebuggerAttachedJava())
			checkSecure |= 4;
		if(SecureLibAPI.isDebuggerAttachedNative())
			checkSecure |= 8;
		if(checkSecure != 0)
		{
			throw new BOS3LLS6G79("bits="+checkSecure);
		}
		BEKAMBBOLBO_Done = false;
		CNAIDEAFAAM_IsError = false;
		
		DOKOHKJIDBO.HHCJCDFCLOB.DBEPFLFHAFH_RequestMaster(true, () => {
			//0xA092A8
			BEKAMBBOLBO_Done = true;
		}, () => {
			//0xA092B4
			BEKAMBBOLBO_Done = true;
			CNAIDEAFAAM_IsError = true;
		});
		//LAB_00a0c790:
		while(!BEKAMBBOLBO_Done)
		{
			// goto LAB_00a0e350;
			yield return null; // to 4 // goto LAB_00a0c790;
		}
		//L424
		if(CNAIDEAFAAM_IsError)
		{
			// break;
			NLJKCDHIPEG = null;
			MPHCKPBAKMO = null;
			DANMJLOBLIE.StartCoroutineWatched(NNPDJBJGBFA_Coroutine_ReturnToTitle());
        	TodoLogger.LogError(TodoLogger.Coroutine, "Exit  Error PFEKBBONCJJ_Coroutine_GameStart");
			yield break;
		}
		BEKAMBBOLBO_Done = false;
		CNAIDEAFAAM_IsError = false;
		MPHCKPBAKMO.BAHKPIADOBI_LoadFromStorage(() => {
			//0xA092C0
			BEKAMBBOLBO_Done = true;
		}, () => {
			//0xA092CC
			BEKAMBBOLBO_Done = true;
			CNAIDEAFAAM_IsError = true;
		});
		//LAB_00a0c8d0:
		while(!BEKAMBBOLBO_Done)
		{
			//goto LAB_00a0e350;
			yield return null; // to 5 // goto LAB_00a0c8d0;
		}
		if(CNAIDEAFAAM_IsError)
		{
			// break;
			NLJKCDHIPEG = null;
			MPHCKPBAKMO = null;
			DANMJLOBLIE.StartCoroutineWatched(NNPDJBJGBFA_Coroutine_ReturnToTitle());
        	TodoLogger.LogError(TodoLogger.Coroutine, "Exit  Error PFEKBBONCJJ_Coroutine_GameStart");
			yield break;
		}
		// L473
		BEKAMBBOLBO_Done = false;
		CNAIDEAFAAM_IsError = false;
		JGEOBNENMAH.HHCJCDFCLOB.EMDLPEGOEJB_Recover(() => {
			//0xA092D8
			BEKAMBBOLBO_Done = true;
		}, () => {
			//0xA092E4
			BEKAMBBOLBO_Done = true;
			CNAIDEAFAAM_IsError = true;
		});
		//LAB_00a0caac:
		while(!BEKAMBBOLBO_Done)
		{
			//goto LAB_00a0e350;
			yield return null; // To 6 goto LAB_00a0caac;
		}
		// L515
		if(CNAIDEAFAAM_IsError)
		{
			// break;
			NLJKCDHIPEG = null;
			MPHCKPBAKMO = null;
			DANMJLOBLIE.StartCoroutineWatched(NNPDJBJGBFA_Coroutine_ReturnToTitle());
        	TodoLogger.LogError(TodoLogger.Coroutine, "Exit  Error PFEKBBONCJJ_Coroutine_GameStart");
			yield break;
		}
		// L524
		FJHPOIDFLEE_FindTitleBannerToDisplay();
		
		BEKAMBBOLBO_Done = false;
		CNAIDEAFAAM_IsError = false;
		KEHOJEJMGLJ.HHCJCDFCLOB.PAHGEEOFEPM_Install(KEHOJEJMGLJ.ACGGHEIMPHC.DEKNOKPEIHO_2, () => {
			//0xA092F0
			BEKAMBBOLBO_Done = true;
		}, () => {
			//0xA092FC
			BEKAMBBOLBO_Done = true;
			CNAIDEAFAAM_IsError = true;
		});
		//LAB_00a0cc14:
		while(!BEKAMBBOLBO_Done)
		{
			//goto LAB_00a0e350;
			yield return null; // To 7 // goto LAB_00a0cc14;
		}
		//L571
		if(CNAIDEAFAAM_IsError)
		{
			// break
			NLJKCDHIPEG = null;
			MPHCKPBAKMO = null;
			DANMJLOBLIE.StartCoroutineWatched(NNPDJBJGBFA_Coroutine_ReturnToTitle());
        	TodoLogger.LogError(TodoLogger.Coroutine, "Exit  Error PFEKBBONCJJ_Coroutine_GameStart");
			yield break;
		}
		// L 581
		NIFKNMFALEM_StartLoading();
		if(JJHGAKDMGLJ_NoTutorial)
		{
			//LAB_00a0ccc0:
			while(!GameManager.Instance.ProgressBar.IsReady)
				yield return null; // To 8 goto LAB_00a0ccc0;
			
			//L604
			NOFPJPHIPBD_LayoutTitleCtrl.SetVisible(false);
			IJCPLBPLJLJ.gameObject.SetActive(true);
			FHBJNLFHGPB_SetPercent(0);
			//LAB_00a0e094:
			// goto goto LAB_00a0eba0;
			yield return Co.R(HBBDEHKOFKN_Coroutine_DownloadTitleBannerTexture()); // To 9
			
			//9
			//L825
			GameManager.Instance.fullscreenFader.Fade(0.5f, 0);
			//goto LAB_00a0eb98;
			yield return GameManager.Instance.WaitFadeYielder; // To 10
			
			//10
			//goto LAB_00a0dbd4;
		}
		//LAB_00a0dbd4:
		FHBJNLFHGPB_SetPercent(30);
		long timestamp = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.LOMEEJGIAHO.JOJFKIIHMOJ(timestamp);
		DateTime date = Utility.GetLocalDateTime(timestamp);
		NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD = date.Month * 100 + date.Year * 100000 + date.Day;
		NKGJPJPHLIF.DPCCNOCAHGC = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("server_time_auto_update", 0) == 1;
		
		BEKAMBBOLBO_Done = false;
		CNAIDEAFAAM_IsError = false;
		NLJKCDHIPEG.ODJCMJBNDOK_Load(() => {
			//0xA09308
			BEKAMBBOLBO_Done = true;
		}, () => {
			//0xA09314
			OOICHDNLLJG_NeedTuto = true;
			BEKAMBBOLBO_Done = true;
		}, () => {
			//0xA09324
			BEKAMBBOLBO_Done = true;
			CNAIDEAFAAM_IsError = true;
		}, false);
		//LAB_00a0df8c:
		while(!BEKAMBBOLBO_Done)
		{
			//goto LAB_00a0e350;
			yield return null; // to 0xb //goto LAB_00a0df8c;
		}
		// L 764
		if(CNAIDEAFAAM_IsError) // Inversed
		{
			// break
			NLJKCDHIPEG = null;
			MPHCKPBAKMO = null;
			DANMJLOBLIE.StartCoroutineWatched(NNPDJBJGBFA_Coroutine_ReturnToTitle());
        	TodoLogger.LogError(TodoLogger.Coroutine, "Exit  Error PFEKBBONCJJ_Coroutine_GameStart");
			yield break;
		}
		bool FBBAOFKBGBA_IsError = true;
		yield return Co.R(IMJGOIOLGIO_Coroutine_Contract(() => {
			// 0xA09330
			FBBAOFKBGBA_IsError = false;
		}, () => {
			//0xA0933C
			FBBAOFKBGBA_IsError = true;
		}));
		//goto LAB_00a0e094; // goto LAB_00a0eba0; // To 0xc
		
		// 0xc
		// L859
		if(!FBBAOFKBGBA_IsError)
		{
			if(NLJKCDHIPEG.HAELBFCGHMB)
			{
				FHBJNLFHGPB_SetPercent(40);
				NLJKCDHIPEG.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.FNLNIKFNHAM_ForceRename = true;
				string str1 = NLJKCDHIPEG.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.OPFGFINHFCE_PlayerName;
				TodoLogger.LogError(TodoLogger.ToCheck, "TODO CHECK");
				if(str1 == JpStringLiterals.StringLiteral_9806)
				{
					NLJKCDHIPEG.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.AFPONJEJKCO_RenameDate = 0;
				}
				NLJKCDHIPEG.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.KFKDMBPNLJK_BlockInvalid = true;
				NLJKCDHIPEG.FMFKHDPKLOC.JHFIPCIHJNL_Base.KFKDMBPNLJK_BlockInvalid = true;
				NLJKCDHIPEG.AIKJMHBDABF_SavePlayerData(() => {
					//0xA09348
					BEKAMBBOLBO_Done = true;
				}, () => {
					//0xA09354
					BEKAMBBOLBO_Done = true;
				}, null);
				BEKAMBBOLBO_Done = false;
				//goto LAB_00a0ca2c;
				
				//0xd
				//LAB_00a0ca2c:
				//L999
				while(!BEKAMBBOLBO_Done)
				{
					//goto LAB_00a0e350;
					yield return null; // to 0xd
				}
				if(CNAIDEAFAAM_IsError)
				{
					DANMJLOBLIE.StartCoroutineWatched(NNPDJBJGBFA_Coroutine_ReturnToTitle());
        			TodoLogger.LogError(TodoLogger.Coroutine, "Exit  Error PFEKBBONCJJ_Coroutine_GameStart");
					yield break;
				}
				// L 1028
				NLJKCDHIPEG.HAELBFCGHMB = false;
				//goto LAB_00a0d064;
			}
			//goto LAB_00a0d064;
			
			//LAB_00a0d064:
			FHBJNLFHGPB_SetPercent(60);
			bool OJFKNEOJEHH_IsError = false;
			if (NLJKCDHIPEG.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.KNIKMMKNOFA_ARcv == 3)
			{
				// goto LAB_00a0d0e8;
			}
			else
			{
				//L1057
				OJFKNEOJEHH_IsError = true;
				if (KDHGBOOECKC.HHCJCDFCLOB != null) // else goto LAB_00a0be80;
				{
					yield return Co.R(KDHGBOOECKC.HHCJCDFCLOB.CEHFPAGELLE_Coroutine_ReceiveVOP_UnreceivedAchivements(() =>
					{
						//0xA09618
						OJFKNEOJEHH_IsError = false;
					}, () =>
					{
						//0xA09624
						TodoLogger.LogError(TodoLogger.Coroutine, "CEHFPAGELLE_Coroutine_ReceiveVOP_UnreceivedAchivements Error");
						OJFKNEOJEHH_IsError = true;
					})); //goto LAB_00a0e094; // to 0xe

					// 0xe

				}
			}
			//LAB_00a0be80:
			if(!OJFKNEOJEHH_IsError)
			{
				//LAB_00a0d0e8:
				BEKAMBBOLBO_Done = false;
				CNAIDEAFAAM_IsError = false;
				OFFPKPHHLKD = new AMOCLPHDGBP();
				OFFPKPHHLKD.OLNDKPDNPCM_Auto_Recover(() => {
					//0xA09360
					BEKAMBBOLBO_Done = true;
				}, () => {
					//0xA0936C
					BEKAMBBOLBO_Done = true;
				}, () => {
					//0xA09378
					BEKAMBBOLBO_Done = true;
					CNAIDEAFAAM_IsError = true;
				}, false, false);
				//goto LAB_00a0d354;
				// 0xf
				//LAB_00a0d354:
				while(!BEKAMBBOLBO_Done)
				{
					//goto LAB_00a0e350;
					yield return null; // to 0xf
				}
				if(CNAIDEAFAAM_IsError)
				{
					//break;
					NLJKCDHIPEG = null;
					MPHCKPBAKMO = null;
					DANMJLOBLIE.StartCoroutineWatched(NNPDJBJGBFA_Coroutine_ReturnToTitle());
        			TodoLogger.LogError(TodoLogger.Coroutine, "Exit  Error PFEKBBONCJJ_Coroutine_GameStart");
					yield break;
				}
				//L1159
				FHBJNLFHGPB_SetPercent(70);
				BEKAMBBOLBO_Done = false;
				CNAIDEAFAAM_IsError = false;
				NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.LILDGEPCPPG_GetProducList(() => {
					//0xA09384
					BEKAMBBOLBO_Done = true;
				}, () => {
					//0xA09390
					BEKAMBBOLBO_Done = true;
					CNAIDEAFAAM_IsError = true;
				}, false, true);
				//goto LAB_00a0d4d4;
					
				//0x10
				//LAB_00a0d4d4:
				while(!BEKAMBBOLBO_Done)
				{
					//goto LAB_00a0e350;
					yield return null; // to 0x10
				}
				if(CNAIDEAFAAM_IsError)
				{
					//break;
					NLJKCDHIPEG = null;
					MPHCKPBAKMO = null;
					DANMJLOBLIE.StartCoroutineWatched(NNPDJBJGBFA_Coroutine_ReturnToTitle());
        			TodoLogger.LogError(TodoLogger.Coroutine, "Exit  Error PFEKBBONCJJ_Coroutine_GameStart");
					yield break;
				}
				//L1223
				FHBJNLFHGPB_SetPercent(80);
				BEKAMBBOLBO_Done = false;
				CNAIDEAFAAM_IsError = false;
				long val2 = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.GHKKPKBBEAN_Prepare(val2, () => {
					//0xA0939C
					BEKAMBBOLBO_Done = true;
				}, () => {
					//0xA093A8
					BEKAMBBOLBO_Done = true;
					CNAIDEAFAAM_IsError = true;
				});
				//goto LAB_00a0d720;
					
				//0x11
				//LAB_00a0d720:
				while(!BEKAMBBOLBO_Done)
				{
					//goto LAB_00a0e350;
					yield return null; // to 0x11
				}
				if(CNAIDEAFAAM_IsError)
				{
					//break;
					NLJKCDHIPEG = null;
					MPHCKPBAKMO = null;
					DANMJLOBLIE.StartCoroutineWatched(NNPDJBJGBFA_Coroutine_ReturnToTitle());
        			TodoLogger.LogError(TodoLogger.Coroutine, "Exit  Error PFEKBBONCJJ_Coroutine_GameStart");
					yield break;
				}
				//L1304
				NLJKCDHIPEG.OFGCPFFPGHE(false);
				IKDICBBFBMI_EventBase o = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(/*7*/OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp, /*9*/KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived);
				if(o != null)
					o.HEFIKPAHCIA(/*18*/GBNDFCEDNMG.CJDGJFINBFH.KNPBBPNJNEM);
				List<IKDICBBFBMI_EventBase> l = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN;
				for(int i = 0; i < l.Count; i++)
				{
					if(l[i] != null)
					{
						l[i].HEFIKPAHCIA(/*20*/GBNDFCEDNMG.CJDGJFINBFH.DCFBLGLFJDO);
					}
				}
				if(GNGMCIAIKMA.HHCJCDFCLOB != null)
				{
					GNGMCIAIKMA.HHCJCDFCLOB.HEFIKPAHCIA_IsBingoValid(null, 0);
				}
				FHBJNLFHGPB_SetPercent(85);
					
				BEKAMBBOLBO_Done = false;
				CNAIDEAFAAM_IsError = false;
				EJHPIMANJFP.HHCJCDFCLOB.LILDGEPCPPG_GetProductList(() => {
					//0xA093B4
					BEKAMBBOLBO_Done = true;
				}, () => {
					//0xA093C0
					BEKAMBBOLBO_Done = true;
				}, () => {
					//0xA093CC
					BEKAMBBOLBO_Done = true;
					CNAIDEAFAAM_IsError = true;
				}, true, true);
				//goto LAB_00a0dacc;
				//0x12
				//LAB_00a0dacc:
				while(!BEKAMBBOLBO_Done)
				{
					//goto LAB_00a0e350;
					yield return null; // to 0x12
				}
				if(CNAIDEAFAAM_IsError)
				{
					//break;
					NLJKCDHIPEG = null;
					MPHCKPBAKMO = null;
					DANMJLOBLIE.StartCoroutineWatched(NNPDJBJGBFA_Coroutine_ReturnToTitle());
        			TodoLogger.LogError(TodoLogger.Coroutine, "Exit  Error PFEKBBONCJJ_Coroutine_GameStart");
					yield break;
				}
				//L1147
				FHBJNLFHGPB_SetPercent(90);
				LAPFLEEAACL[] EMOMAPKPGGK = NKGJPJPHLIF.HHCJCDFCLOB.HECNGABHNDJ;
				for(int i = 0; i < EMOMAPKPGGK.Length; i++)
				{
					EMOMAPKPGGK[i].OFKONDFPMLJ_GetProduct();
					//LAB_00a0e464:
					while(!EMOMAPKPGGK[i].PLOOEECNHFB_IsDone)
					{
						//goto LAB_00a0e350;
						yield return null; // To 0x13 // goto LAB_00a0e464;
					}
					// L1509
					if(EMOMAPKPGGK[i].NPNNPNAIONN_IsError)
					{
						//goto LAB_00a0e364;
						NLJKCDHIPEG = null;
						MPHCKPBAKMO = null;
						DANMJLOBLIE.StartCoroutineWatched(NNPDJBJGBFA_Coroutine_ReturnToTitle());
       					TodoLogger.LogError(TodoLogger.Coroutine, "Exit  Error PFEKBBONCJJ_Coroutine_GameStart");
						yield break;
					}
					EMOMAPKPGGK[i].LAOEGNLOJHC_Convert();
					//LAB_00a0e56c:
					while(!EMOMAPKPGGK[i].PLOOEECNHFB_IsDone)
					{
						//goto LAB_00a0e350;
						yield return null; // To 0x14 // goto LAB_00a0e56c;
					}
					//L1561
					if(EMOMAPKPGGK[i].NPNNPNAIONN_IsError)
					{
						//goto LAB_00a0e364;
						NLJKCDHIPEG = null;
						MPHCKPBAKMO = null;
						DANMJLOBLIE.StartCoroutineWatched(NNPDJBJGBFA_Coroutine_ReturnToTitle());
        				TodoLogger.LogError(TodoLogger.Coroutine, "Exit  Error PFEKBBONCJJ_Coroutine_GameStart");
						yield break;
					}
				}
				FHBJNLFHGPB_SetPercent(93);
				NHPDPKHMFEP MGPMDNDOBFI = NHPDPKHMFEP.HHCJCDFCLOB;
				BEKAMBBOLBO_Done = false;
				CNAIDEAFAAM_IsError = false;
				MGPMDNDOBFI.OFKONDFPMLJ_GetProducts(() => {
					//0xA093D8
					BEKAMBBOLBO_Done = true;
				}, () => {
					//0xA093E4
					BEKAMBBOLBO_Done = true;
					CNAIDEAFAAM_IsError = true;
				});
				//goto LAB_00a0e764;
				//0x15
				//LAB_00a0e764
				while(!BEKAMBBOLBO_Done)
				{
					//goto LAB_00a0e350
					yield return null; // to 0x15
				}
				MGPMDNDOBFI.DLGMLAJMLOP = true;
				FHBJNLFHGPB_SetPercent(94);
				NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.IFDJHOKOEGA();
				JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.IMHONIOILIG();
				NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.KCILENCPNHD();
				NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.HIKNIPGJDAI(NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD);
				EOHDAOAJOHH.HHCJCDFCLOB.OPODBGPJDCJ_SetComebackNotif();
				FHBJNLFHGPB_SetPercent(95);
				AppQualitySetting.InitDefault3dMode();
				if(!OOICHDNLLJG_NeedTuto)
				{
					CIOECGOMILE.HHCJCDFCLOB.AKCOAKHAGAL_CheckServerSaveDefaultInit();
					GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.PPOJCDCCFNI_TutorialEnd = 1;
					GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
				}
				else
				{
					JNBOGCGCOMH_StartTutorial(); // setup tutorial
				}
				FHBJNLFHGPB_SetPercent(96);
				//goto LAB_00a0eb98;
				yield return Co.R(ACHBBAIODMC_UtarateRankingUpdate()); // To 16
				//16
				FHBJNLFHGPB_SetPercent(100);
				yield return null; // To 17
				//17
				if(JJHGAKDMGLJ_NoTutorial) // Inversed // goto LAB_00a0cf04;
				{
					// L1813
					GameManager.Instance.fullscreenFader.Fade(0.5f, Color.black);
					yield return GameManager.Instance.WaitFadeYielder; // To 18
					//18
					NOFPJPHIPBD_LayoutTitleCtrl.SetVisible(true);
					IJCPLBPLJLJ.gameObject.SetActive(false);
				}
					
				//LAB_00a0cf04
				HFIBEEMGOND_EndLoading();
				yield return DANMJLOBLIE.StartCoroutineWatched(ABPGOJDKKHO_Coroutine_PopupShowSNS(() => {
					//0xA093F0
					NOFPJPHIPBD_LayoutTitleCtrl.Dispose();
					NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.MBOIDKCMCDL = false;
					SoundManager.Instance.voTitlecall.RequestRemoveCueSheet();
					OGNDELCENBB(ABJDBPINCIC);
				}, () => {
					//0xA09588
					DANMJLOBLIE.StartCoroutineWatched(NNPDJBJGBFA_Coroutine_ReturnToTitle());
				}));
				//goto LAB_00a0e3c0;
				yield break;
			}
			else
			{
				//goto LAB_00a0e370;
			}
			//goto LAB_00a0e370;
		}
		//goto LAB_00a0e370;
		//LAB_00a0e370
		DANMJLOBLIE.StartCoroutineWatched(NNPDJBJGBFA_Coroutine_ReturnToTitle());
        TodoLogger.LogError(TodoLogger.Coroutine, "Exit  Error PFEKBBONCJJ_Coroutine_GameStart");
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B41E0 Offset: 0x6B41E0 VA: 0x6B41E0
	// // RVA: 0xA07440 Offset: 0xA07440 VA: 0xA07440
	private IEnumerator ACHBBAIODMC_UtarateRankingUpdate()
	{
		EGOLBAPFHHD_Common JICFCEAHCDJ;

		//0x1408EEC
		JICFCEAHCDJ = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common;
		JNMFKOHFAFB_PublicStatus pstatus = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MHEAEGMIKIE_PublicStatus;
		bool DHGMILEPDKF_IsRankingError = false;
		if (JICFCEAHCDJ == null || pstatus == null)
			yield break;
		bool BEKAMBBOLBO_IsDone = false;
		bool CNAIDEAFAAM_IsError = false;
		OEGIPPCADNA.HHCJCDFCLOB.MJFKJHJJLMN_GetUtaRateRank(0, false, () =>
		{
			//0xA09640
			BEKAMBBOLBO_IsDone = true;
		}, () =>
		{
			//0xA0964C
			BEKAMBBOLBO_IsDone = true;
			DHGMILEPDKF_IsRankingError = true;
		}, () =>
		{
			//0xA09678
			BEKAMBBOLBO_IsDone = true;
			CNAIDEAFAAM_IsError = true;
		});
		while (!BEKAMBBOLBO_IsDone)
			yield return null;
		if(!CNAIDEAFAAM_IsError)
		{
			BEKAMBBOLBO_IsDone = false;
			CNAIDEAFAAM_IsError = false;
			if(!DHGMILEPDKF_IsRankingError)
			{
				yield break;
			}
			if(JICFCEAHCDJ.EAHPKPADCPL_TotalUtaRate < 1)
			{
				yield break;
			}
			OEGIPPCADNA.HHCJCDFCLOB.FGMOMBKGCNF_UpdateTotalUtaRate(JICFCEAHCDJ.EAHPKPADCPL_TotalUtaRate, () =>
			{
				//0xA09684
				BEKAMBBOLBO_IsDone = true;
			}, () =>
			{
				//0xA09690
				BEKAMBBOLBO_IsDone = true;
			}, () =>
			{
				//0xA0969C
				BEKAMBBOLBO_IsDone = true;
				CNAIDEAFAAM_IsError = true;
			});
			while (!BEKAMBBOLBO_IsDone)
				yield return null;
			if (!CNAIDEAFAAM_IsError)
				yield break;
			//LAB_01409244
		}
		//LAB_01409244
		DANMJLOBLIE.StartCoroutineWatched(NNPDJBJGBFA_Coroutine_ReturnToTitle());
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B4258 Offset: 0x6B4258 VA: 0x6B4258
	// // RVA: 0xA074C8 Offset: 0xA074C8 VA: 0xA074C8
	private IEnumerator HBBDEHKOFKN_Coroutine_DownloadTitleBannerTexture()
	{
		//0xA0B26C
		AssetBundleLoadAssetOperation AHBCOPDIEEH = null;
		
		if(BLEAOGCLJPK_TitleBannerAssetId > 0)
		{
			string assetName = BLEAOGCLJPK_TitleBannerAssetId.ToString("D6");
  
			string assetBundleName = String.Format("ct/bg/ld/{0:D6}.xab", BLEAOGCLJPK_TitleBannerAssetId);
			AHBCOPDIEEH = AssetBundleManager.LoadAssetAsync(assetBundleName, assetName, typeof(Texture2D));
			yield return Co.R(AHBCOPDIEEH);
			
			HOFMODFAOEA = null;
			ResourcesManager.Instance.Load(Path.Combine("Menu/Prefab/MenuBg","BgTitleBanner"), (FileResultObject NLCGHBBNOJA) => {
				//0xA088EC
				HOFMODFAOEA = UnityEngine.Object.Instantiate<GameObject>(NLCGHBBNOJA.unityObject as GameObject);
				return true;
			});
			while(HOFMODFAOEA == null)
				yield return null;
			RawImage ri = HOFMODFAOEA.GetComponent<RawImage>();
			ri.texture = AHBCOPDIEEH.GetAsset<Texture2D>();
			HOFMODFAOEA.transform.SetParent(GameManager.Instance.ProgressBar.transform.parent, false);
			HOFMODFAOEA.transform.SetSiblingIndex(GameManager.Instance.ProgressBar.transform.GetSiblingIndex());
			GameManager.Instance.ProgressBar.SetType(UILoadProgress.Type.Event);
		}
		else
		{
			GameManager.Instance.ProgressBar.SetType(UILoadProgress.Type.Normal);
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B42D0 Offset: 0x6B42D0 VA: 0x6B42D0
	// // RVA: 0xA06AEC Offset: 0xA06AEC VA: 0xA06AEC
	// RVA: 0x9C67E4 Offset: 0x9C67E4 VA: 0x9C67E4
	private IEnumerator KOEILOLECCF_Coroutine_StartARMode()
	{
		IMMAOANGPNK NOECBNCKIJD;

		//0x140620C
		//0x9D1F4C
		string ABJDBPINCIC = "AR";
		PGIGNJDPCAH.NNOBACMJHDM(PGIGNJDPCAH.FELLIEJEPIJ.JBAIEADLAGH_0);
		PGIGNJDPCAH.IPJMPBANBPP = true;
		PGIGNJDPCAH.OGAIOKGEMDE = false;
		if (CNGFKOJANNP.HHCJCDFCLOB != null)
			CNGFKOJANNP.HHCJCDFCLOB.EGDJHGIAFGO_Start();
		GameManager.Instance.fullscreenFader.Fade(0.5f, Color.black);
		GameManager.Instance.RemovePushBackButtonHandler(GJLDMJFMIOD_OnPushBackButton);
		KEHOJEJMGLJ.HHCJCDFCLOB.OFLDICKPNFD(true, () =>
		{
			//0xA08DDC
			//0x9C8BA8
			MenuScene.Instance.GotoTitle();
		});
		KDLPEDBKMID.HHCJCDFCLOB.OFLDICKPNFD(true, () =>
		{
			//0xA08E78
			//0x9C8C44
			MenuScene.Instance.GotoTitle();
		});
		yield return GameManager.Instance.WaitFadeYielder;
		GameManager.Instance.ar_session_id = JDDGPJDKHNE.GPLMOKEIOLE();
		ILCCJNDFFOB.HHCJCDFCLOB.ICAHGJMMGLM(GameManager.Instance.ar_session_id);
		NIFKNMFALEM_StartLoading();
		if(JJHGAKDMGLJ_NoTutorial)
		{
			while (!GameManager.Instance.ProgressBar.IsReady)
				yield return null;
			GameManager.Instance.fullscreenFader.Fade(0.5f, 0);
			NOFPJPHIPBD_LayoutTitleCtrl.SetVisible(false);
			IJCPLBPLJLJ.gameObject.SetActive(true);
			yield return GameManager.Instance.WaitFadeYielder;
		}
		//LAB_01406d94;
		NOECBNCKIJD = IMMAOANGPNK.HHCJCDFCLOB;
		NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.MBOIDKCMCDL = false;
		bool BEKAMBBOLBO = false;
		bool CNAIDEAFAAM = false;
		FHBJNLFHGPB_SetPercent(0);
		NKGJPJPHLIF.HHCJCDFCLOB.HGJKAEOLMJN_InitializePlayerToken(() =>
		{
			//0xA096B0
			BEKAMBBOLBO = true;
		}, () =>
		{
			//0xA096BC
			BEKAMBBOLBO = true;
			CNAIDEAFAAM = true;
		}, false, false);
		while (!BEKAMBBOLBO)
			yield return null;
		if(CNAIDEAFAAM)
		{
			//LAB_009d347c
			NOECBNCKIJD = null;
			//LAB_014072d8
			DANMJLOBLIE.StartCoroutineWatched(NNPDJBJGBFA_Coroutine_ReturnToTitle());
			yield break;
		}
		FHBJNLFHGPB_SetPercent(20);
		//Crittersism.SetLogUnhandledExceptionAsCrash(false);
		int a = SecureLibAPI.isRooted() ? 1 : 0;
		a |= SecureLibAPI.isEmulator() ? 2 : 0;
		a |= SecureLibAPI.isDebuggerAttachedJava() ? 4 : 0;
		a |= SecureLibAPI.isDebuggerAttachedNative() ? 8 : 0;
		if(a != 0)
		{
			throw new BOS3LLS6G79("bits=" + a);
		}
		//Crittersism.SetLogUnhandledExceptionAsCrash(true);
		if(SecureLibAPI.isRooted())
		{
			/*bool CKHEDJODNIP = false;
			JHHBAFKMBDL.HHCJCDFCLOB.EOKNIAMKJFB(() =>
			{
				Method$IOGKADECKOP.<>c__DisplayClass38_1.AKIAEEPHANC()
			});
			while(!CKHEDJODNIP)
				yield return null;
			*/
			//LAB_009d34b0
			DANMJLOBLIE.StartCoroutineWatched(NNPDJBJGBFA_Coroutine_ReturnToTitle());
		}
		BEKAMBBOLBO = false;
		CNAIDEAFAAM = false;
		DOKOHKJIDBO.HHCJCDFCLOB.DBEPFLFHAFH_RequestMaster(true, () =>
		{
			//0xA096C8
			BEKAMBBOLBO = true;
		}, () =>
		{
			//0xA096D4
			BEKAMBBOLBO = true;
			CNAIDEAFAAM = true;
		});
		while (!BEKAMBBOLBO)
			yield return null;
		if(CNAIDEAFAAM)
		{
			//>LAB_014072d0;
			NOECBNCKIJD = null;
			//LAB_014072d8
			DANMJLOBLIE.StartCoroutineWatched(NNPDJBJGBFA_Coroutine_ReturnToTitle());
			yield break;
		}
		BEKAMBBOLBO = false;
		CNAIDEAFAAM = false;
		NOECBNCKIJD.BAHKPIADOBI_LoadFromStorage(() =>
		{
			//0xA096E0
			BEKAMBBOLBO = true;
		}, () =>
		{
			//0xA096EC
			BEKAMBBOLBO = true;
			CNAIDEAFAAM = true;
		});
		while (!BEKAMBBOLBO)
			yield return null;
		if(CNAIDEAFAAM)
		{
			//>LAB_014072d0;
			NOECBNCKIJD = null;
			//LAB_014072d8
			DANMJLOBLIE.StartCoroutineWatched(NNPDJBJGBFA_Coroutine_ReturnToTitle());
			yield break;
		}
		FHBJNLFHGPB_SetPercent(50);
		long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.LOMEEJGIAHO.JOJFKIIHMOJ(t);
		DateTime date = Utility.GetLocalDateTime(t);
		NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD = date.Month * 100 + date.Year * 100000 + date.Day;
		int server_time_auto_update = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("server_time_auto_update", 0);
		NKGJPJPHLIF.DPCCNOCAHGC = server_time_auto_update == 1;
		BEKAMBBOLBO = false;
		CNAIDEAFAAM = false;
		ARMarkerMasterData.Instance.StartInstall(() =>
		{
			//0x9C9C9C
			BEKAMBBOLBO = true;
		}, () =>
		{
			//0x9C9CA8
			BEKAMBBOLBO = true;
			CNAIDEAFAAM = true;
		});
		while(!BEKAMBBOLBO)
			yield return null;
		if(CNAIDEAFAAM)
		{
			//LAB_009d3484
			DANMJLOBLIE.StartCoroutineWatched(NNPDJBJGBFA_Coroutine_ReturnToTitle());
		}
		BEKAMBBOLBO = false;
		CNAIDEAFAAM = false;
		NKGJPJPHLIF.HHCJCDFCLOB.NJMOAHNLDBO.Load(() =>
		{
			//0x9C9CB4
			BEKAMBBOLBO = true;
		}, () =>
		{
			//0x9C9CC0
			BEKAMBBOLBO = true;
			CNAIDEAFAAM = true;
		});
		while(!BEKAMBBOLBO)
			yield return null;
		if(CNAIDEAFAAM)
		{
			//LAB_009d3484
			DANMJLOBLIE.StartCoroutineWatched(NNPDJBJGBFA_Coroutine_ReturnToTitle());
		}
		bool FBBAOFKBGBA = true;
		yield return Co.R(IMJGOIOLGIO_Coroutine_Contract(() =>
		{
			//0xA096F8
			FBBAOFKBGBA = false;
		}, () =>
		{
			//0xA09704
			FBBAOFKBGBA = true;
		}));
		if(!FBBAOFKBGBA)
		{
			FHBJNLFHGPB_SetPercent(60);
			BEKAMBBOLBO = false;
			CNAIDEAFAAM = false;
			KEHOJEJMGLJ.HHCJCDFCLOB.PAHGEEOFEPM_Install(KEHOJEJMGLJ.ACGGHEIMPHC.DEKNOKPEIHO_2, () =>
			{
				//0xA09710
				BEKAMBBOLBO = true;
			}, () =>
			{
				//0xA0971C
				BEKAMBBOLBO = true;
				CNAIDEAFAAM = true;
			}, 0, 0);
			//LAB_01406b54
			while(!BEKAMBBOLBO)
				yield return null;
			if (!CNAIDEAFAAM)
			{
				FHBJNLFHGPB_SetPercent(80);
				BEKAMBBOLBO = false;
				KEHOJEJMGLJ.HHCJCDFCLOB.KPMCJMIEMMB(() =>
				{
					//0xA09728
					BEKAMBBOLBO = true;
				});
				//LAB_01407428;
				while (!BEKAMBBOLBO)
					yield return null;
				FHBJNLFHGPB_SetPercent(100);
				yield return null;
				if (JJHGAKDMGLJ_NoTutorial)
				{
					GameManager.Instance.fullscreenFader.Fade(0.5f, Color.black);
					yield return GameManager.Instance.WaitFadeYielder;
					NOFPJPHIPBD_LayoutTitleCtrl.SetVisible(true);
					IJCPLBPLJLJ.gameObject.SetActive(false);
				}
				//LAB_01406850;
				OGNDELCENBB(ABJDBPINCIC);
			}
		}
		//LAB_01406ba4;
		DANMJLOBLIE.StartCoroutineWatched(NNPDJBJGBFA_Coroutine_ReturnToTitle());
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B4348 Offset: 0x6B4348 VA: 0x6B4348
	// // RVA: 0xA07574 Offset: 0xA07574 VA: 0xA07574
	private IEnumerator NNPDJBJGBFA_Coroutine_ReturnToTitle()
	{
		//0x1405D14
		if(!JJHGAKDMGLJ_NoTutorial)
		{
			GameManager.Instance.fullscreenFader.Fade(0.5f, 0);
			yield return new WaitForSeconds(1);
		}
		else
		{
			GameManager.Instance.fullscreenFader.Fade(0.5f, Color.black);
			yield return GameManager.Instance.WaitFadeYielder;
			NOFPJPHIPBD_LayoutTitleCtrl.SetVisible(true);
			IJCPLBPLJLJ.gameObject.SetActive(false);
			HFIBEEMGOND_EndLoading();
			GameManager.Instance.fullscreenFader.Fade(0.5f, 0);
			yield return GameManager.Instance.WaitFadeYielder;
		}
		NOFPJPHIPBD_LayoutTitleCtrl.ScreenTap.SetCallback();
		NOFPJPHIPBD_LayoutTitleCtrl.Buttons.SetCallback();
		NOFPJPHIPBD_LayoutTitleCtrl.LbButtons.SetCallback();
	}

	// // RVA: 0xA075FC Offset: 0xA075FC VA: 0xA075FC
	// private void EECGCFAKEPF() { }

	// // RVA: 0xA07698 Offset: 0xA07698 VA: 0xA07698
	private void JNBOGCGCOMH_StartTutorial()
	{
		GameManager.Instance.IsTutorial = true;
		CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JAIGHAGMLCJ();
		ABJDBPINCIC = "Prologue";
		PGIGNJDPCAH.OGAIOKGEMDE = true;
	}

	// // RVA: 0xA0780C Offset: 0xA0780C VA: 0xA0780C
	private void CFGABDOEHBI()
	{
		GameObject go = GameObject.Find("Text_ID");
		if(go != null)
		{
			go.GetComponent<Text>().text = "Player ID : "+NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId;
		}
		go = GameObject.Find("TitleUITexts");
		if(go != null)
		{
			UnityEngine.Object.Destroy(go);
		}
	}

	// // RVA: 0xA07A3C Offset: 0xA07A3C VA: 0xA07A3C
	private void GJLDMJFMIOD_OnPushBackButton()
	{
		GameManager.Instance.RemovePushBackButtonHandler(this.GJLDMJFMIOD_OnPushBackButton);
		PopupWindowManager.ApplicationQuitPopupShow(() => {
			//0xA089D0
			GameManager.Instance.AddPushBackButtonHandler(this.GJLDMJFMIOD_OnPushBackButton);
		});
	}

	// // RVA: 0xA07B88 Offset: 0xA07B88 VA: 0xA07B88
	public void NIFKNMFALEM_StartLoading()
	{
		if(!GameManager.Instance.IsTutorial)
		{
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.PPOJCDCCFNI_TutorialEnd == 0)
				return;
			
			GameManager.Instance.ProgressBar.Begin(DANMJLOBLIE.transform.parent);
			JJHGAKDMGLJ_NoTutorial = true;
		}
	}

	// // RVA: 0xA07D9C Offset: 0xA07D9C VA: 0xA07D9C
	public void FHBJNLFHGPB_SetPercent(int LNAHJANMJNM) // Update loading percent
	{
		if (!JJHGAKDMGLJ_NoTutorial)
			return;
		TodoLogger.Log(TodoLogger.Init, "Init % : "+LNAHJANMJNM);
		GameManager.Instance.ProgressBar.SetPer(LNAHJANMJNM);
	}

	// // RVA: 0xA07E70 Offset: 0xA07E70 VA: 0xA07E70
	public void HFIBEEMGOND_EndLoading()
	{
		GameManager.Instance.ProgressBar.End();
		if(HOFMODFAOEA != null)
		{
			UnityEngine.Object.Destroy(HOFMODFAOEA.gameObject);
			HOFMODFAOEA = null;
		}
		JJHGAKDMGLJ_NoTutorial = false;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B43C0 Offset: 0x6B43C0 VA: 0x6B43C0
	// // RVA: 0xA07FF0 Offset: 0xA07FF0 VA: 0xA07FF0
	private IEnumerator LCCKLAEOAMB_Coroutine_InitAREventAndTitleBG()
	{
		//0xA0ECD8
		//private IOGKADECKOP.<>c__DisplayClass48_0 OPLBFCEPDCH; // 0x10
		//IOGKADECKOP KIGBLACMODG; // 0x14
		//AREventMasterData LGONMOHKPLF; // 0x18
		//string FCFBGJOFEHO; // 0x1C
		//AssetBundleLoadAssetOperation GDKDBPHILKG; // 0x20
		
		bool BEKAMBBOLBO = false;
		AREventMasterData LGONMOHKPLF = AREventMasterData.Instance;
		LGONMOHKPLF.ignoreError = true;
		LGONMOHKPLF.StartInstall(() => {
			//0xA09750
			BEKAMBBOLBO = true;
		}, () => {
			//0xA0975C
			BEKAMBBOLBO = true;
		});
		while(!BEKAMBBOLBO)
			yield return null;
		
		LGONMOHKPLF.ignoreError = false;
		if(LGONMOHKPLF.IsReady())
		{
			GCGFGMICEGF();
		}
		if(!OOIBKCCMCAG_HasCustomBg)
		{
			yield break;
		}
		if(PDOILOAFKCF_BgImage != null)
		{
			string FCFBGJOFEHO_bundleFile = BFGOCONGNDK.NLMBMNKEINP_GetBgFileName(NLFFEOBGFMC_BgId);
			string s1 = String.Format("{0:D4}", NLFFEOBGFMC_BgId);
			
			AssetBundleLoadAssetOperation GDKDBPHILKG = AssetBundleManager.LoadAssetAsync(FCFBGJOFEHO_bundleFile, s1, typeof(Texture));
			yield return Co.R(GDKDBPHILKG);
			
			PDOILOAFKCF_BgImage.texture = GDKDBPHILKG.GetAsset<Texture>();
			
			AssetBundleManager.UnloadAssetBundle(FCFBGJOFEHO_bundleFile, false);
			//N.a.StartCoroutineWatched(UpdateBGTest());
		}
	}

	public void UpdateBG()
	{
		N.a.StartCoroutineWatched(UpdateBGCoroutine());
	}

	IEnumerator UpdateBGCoroutine()
	{
		if(PDOILOAFKCF_BgImage != null)
		{
			AREventMasterData.Chenge_bg bg = AREventMasterData.Instance.FindChangeBG();
			if(bg == null)
				yield break;
			NLFFEOBGFMC_BgId = bg.bgId;
			string FCFBGJOFEHO_bundleFile = BFGOCONGNDK.NLMBMNKEINP_GetBgFileName(NLFFEOBGFMC_BgId);
			string s1 = String.Format("{0:D4}", NLFFEOBGFMC_BgId);
			
			AssetBundleLoadAssetOperation GDKDBPHILKG = AssetBundleManager.LoadAssetAsync(FCFBGJOFEHO_bundleFile, s1, typeof(Texture));
			yield return Co.R(GDKDBPHILKG);
			
			PDOILOAFKCF_BgImage.texture = GDKDBPHILKG.GetAsset<Texture>();
			
			AssetBundleManager.UnloadAssetBundle(FCFBGJOFEHO_bundleFile, false);
		}
	}

	IEnumerator UpdateBGTest()
	{
		List<AREventMasterData.Chenge_bg> bgs = AREventMasterData.Instance.GetChangeBGList();
		int c = 0;
		while(true)
		{
			while(!Input.GetKeyDown(KeyCode.N) && !Input.GetKeyDown(KeyCode.B))
				yield return null;
			if(Input.GetKeyDown(KeyCode.N))
				c++;
			else
				c--;
			c = Mathf.Clamp(c, 0, bgs.Count - 1);
			UnityEngine.Debug.LogError("Bg "+bgs[c].bgId+" "+Utility.GetLocalDateTime(bgs[c].startTime).ToLongDateString()+" "+Utility.GetLocalDateTime(bgs[c].endTime).ToLongDateString());
			yield return null;
			string FCFBGJOFEHO_bundleFile = BFGOCONGNDK.NLMBMNKEINP_GetBgFileName(bgs[c].bgId);
			string s1 = String.Format("{0:D4}", bgs[c].bgId);
			
			if(FileSystemProxy.FileExists(UnityEngine.Application.persistentDataPath + "/data/android/" + FCFBGJOFEHO_bundleFile))
			{
				AssetBundleLoadAssetOperation GDKDBPHILKG = AssetBundleManager.LoadAssetAsync(FCFBGJOFEHO_bundleFile, s1, typeof(Texture));
				yield return Co.R(GDKDBPHILKG);
				
				PDOILOAFKCF_BgImage.texture = GDKDBPHILKG.GetAsset<Texture>();
				
				AssetBundleManager.UnloadAssetBundle(FCFBGJOFEHO_bundleFile, false);
			}
		}
	}

	// // RVA: 0xA0809C Offset: 0xA0809C VA: 0xA0809C
	private void GCGFGMICEGF()
	{
		EHKDIJELHAO = false;
		OOIBKCCMCAG_HasCustomBg = false;
		if (AREventMasterData.Instance.IsReady())
		{
			AREventMasterData.EventTime ev = AREventMasterData.Instance.FindEventTime();
			if(ev != null)
			{
				EHKDIJELHAO = true;
				EHKDIJELHAO = UdonLib.AndroidUtils.CheckCameraHardware();
			}
			AREventMasterData.Chenge_bg bg = AREventMasterData.Instance.FindChangeBG();
			if(bg == null)
				return;
			BFGOCONGNDK a = new BFGOCONGNDK();
			a.PCODDPDFLHK_ReadStartBgInfo();
			if(a.MBGHLLHFNHH && a.DAONJOOCPFP(bg.bgId))
			{
				OOIBKCCMCAG_HasCustomBg = true;
				NLFFEOBGFMC_BgId = bg.bgId;
			}
		}
	}

	// // RVA: 0xA081F8 Offset: 0xA081F8 VA: 0xA081F8
	private void FJHPOIDFLEE_FindTitleBannerToDisplay()
	{
		long serverTime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		BLEAOGCLJPK_TitleBannerAssetId = 0;
		List<JOHKNBEFHHP_TitleBanner.NGKJHBDEELB> bannerList = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ACPALDEELCL_TitleBanner.CDENCMNHNGA_BannerList;
		for(int i = 0; i < bannerList.Count; i++)
		{
			if(bannerList[i].PPEGAKEIEGM == 2)
			{
				if(serverTime >= bannerList[i].PDBPFJJCADD_StartDate && serverTime <= bannerList[i].FDBNFFNFOND_EndDate)
				{
					BLEAOGCLJPK_TitleBannerAssetId = bannerList[i].KNHOMNONOEB_AssetId;
					return;
				}
			}
		}
		
	}

	// [CompilerGeneratedAttribute] // RVA: 0x6B4438 Offset: 0x6B4438 VA: 0x6B4438
	// // RVA: 0xA085A0 Offset: 0xA085A0 VA: 0xA085A0
	// private void <SetLayoutButtonCallback>b__31_0() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6B4468 Offset: 0x6B4468 VA: 0x6B4468
	// // RVA: 0xA088EC Offset: 0xA088EC VA: 0xA088EC
	// private bool <Coroutine_DownloadTitleBannerTexture>b__38_0(FileResultObject NLCGHBBNOJA) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6B4478 Offset: 0x6B4478 VA: 0x6B4478
	// // RVA: 0xA089D0 Offset: 0xA089D0 VA: 0xA089D0
	// private void <OnPushBackButton>b__44_0() { }
}
