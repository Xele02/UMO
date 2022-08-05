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

public class IOGKADECKOP
{
    public delegate void BBCOMMKDEDF(string INHEEPHFAON);

	private MonoBehaviour DANMJLOBLIE; // 0x8
	private bool BICOBOLNFLJ; // 0xC
	private InheritingMenu MCJHELIEHMC; // 0x10
	private LayoutTitleController NOFPJPHIPBD; // 0x14
	private RawImage PDOILOAFKCF; // 0x18
	private GameObject HOFMODFAOEA; // 0x1C
	private string ABJDBPINCIC = "DownLoad"; // 0x20
	public IOGKADECKOP.BBCOMMKDEDF OGNDELCENBB; // 0x24
	private AMOCLPHDGBP OFFPKPHHLKD; // 0x28
	private bool OKDMEMPECDO; // 0x2C
	private bool LKFGMDGFKDP; // 0x2D
	private bool JJHGAKDMGLJ; // 0x2E
	private BgBehaviour IJCPLBPLJLJ; // 0x30
	private bool EHKDIJELHAO; // 0x34
	private bool OOIBKCCMCAG; // 0x35
	private int NLFFEOBGFMC; // 0x38
	private int BLEAOGCLJPK; // 0x3C
	private readonly int[] MLDJAIHDFOM = new int[10] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}; // 0x40

	// // RVA: 0xA061D8 Offset: 0xA061D8 VA: 0xA061D8
	public void LIGFHEAKAGD(MonoBehaviour DANMJLOBLIE)
    {
        this.DANMJLOBLIE = DANMJLOBLIE;
        for(int i = 0; i < DANMJLOBLIE.transform.parent.childCount; i++)
        {
            if(DANMJLOBLIE.transform.parent.GetChild(i).name == "Bg")
                PDOILOAFKCF = DANMJLOBLIE.transform.parent.GetChild(i).GetComponent<RawImage>();
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
        DANMJLOBLIE.StartCoroutine(GGKONDNONPP_BootCoroutine());
    }

	// // RVA: 0xA065F0 Offset: 0xA065F0 VA: 0xA065F0
	public bool FKDKMCKJNJD()
    {
		if(!BICOBOLNFLJ)
			return false;
		
        MCJHELIEHMC = InheritingMenu.Create(null);
		DANMJLOBLIE.StartCoroutine(LMDJGHMDDJA_LogoActCoroutine());
        return true;
    }

	// // RVA: 0xA066E0 Offset: 0xA066E0 VA: 0xA066E0
	public void FGBKOJCFMKM()
    {
		if(MCJHELIEHMC.IsOpen)
			return;
		
		if(NOFPJPHIPBD.IsSupportPopupOpen)
			return;
		
		NOFPJPHIPBD.Buttons.CallbackClear();
		NOFPJPHIPBD.LbButtons.CallbackClear();
		SoundManager.Instance.sePlayerBoot.Play(8);
		NOFPJPHIPBD.ScreenTap.ClearCallback();
		NOFPJPHIPBD.Screen.TapAnim();
		DANMJLOBLIE.StartCoroutine(PFEKBBONCJJ_Coroutine_GameStart());
    }

	// // RVA: 0xA0694C Offset: 0xA0694C VA: 0xA0694C
	// public void OCCAKNDDCMA() { }

	// // RVA: 0xA06B74 Offset: 0xA06B74 VA: 0xA06B74
	// public void GIPPBCOMDGL() { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B3CB8 Offset: 0x6B3CB8 VA: 0x6B3CB8
	// // RVA: 0xA06658 Offset: 0xA06658 VA: 0xA06658
	private IEnumerator LMDJGHMDDJA_LogoActCoroutine()
	{
        UnityEngine.Debug.Log("Enter LMDJGHMDDJA_LogoActCoroutine");
		//0x14087CC
		PJKLMCGEJMK LPKMGOHDKGM = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF;
		while(!(NOFPJPHIPBD.IsSetup && !LKFGMDGFKDP))
		{
			yield return null;
		}
		if(NOFPJPHIPBD.Texts != null)
		{
			NOFPJPHIPBD.Texts.SetStatus();
		}
		yield return null;
		SoundManager.Instance.bgmPlayer.Play(BgmConstant.Name.Title, 1);
		CFGABDOEHBI();
		GameManager.FadeIn(0.4f);
		yield return GameManager.Instance.WaitFadeYielder;
		
		GameManager.Instance.InputEnabled = true;
		GameManager.Instance.AddPushBackButtonHandler(this.GJLDMJFMIOD_OnPushBackButton);
		NOFPJPHIPBD.ScreenTap.SetCallback();
		SoundManager.Instance.voTitlecall.EntrySheet();
		yield return new WaitForSeconds(0.5f);
		
		int rand = UnityEngine.Random.Range(0, MLDJAIHDFOM.Length);
		int divaId = MLDJAIHDFOM[rand];
		if(LPKMGOHDKGM == null)
		{
			SoundManager.Instance.voTitlecall.Play(divaId, 0);
		}
		NOFPJPHIPBD.Show();
		if(EHKDIJELHAO)
		{
			NOFPJPHIPBD.ShowArButton();
		}
		DANMJLOBLIE.StartCoroutine(HNPMKCFMEGA_Coroutine_Inquiry());
        UnityEngine.Debug.Log("Exit LMDJGHMDDJA_LogoActCoroutine");

		//UnityEngine.Debug.LogError("Hack to remove");
		//FGBKOJCFMKM();
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B3D30 Offset: 0x6B3D30 VA: 0x6B3D30
	// // RVA: 0xA06564 Offset: 0xA06564 VA: 0xA06564
	private IEnumerator GGKONDNONPP_BootCoroutine()
    {
        UnityEngine.Debug.Log("Enter GGKONDNONPP_BootCoroutine");
		// 0xA0976C
		if(!GameManager.Instance.IsSystemInitialized)
		{
			yield return DANMJLOBLIE.StartCoroutine(DFLFHJHBKOC_CoroutineAppBoot());
		}
		else
		{
			yield return DANMJLOBLIE.StartCoroutine(FIIEPEEMMLD_CoroutineStart());
		}
		GameManager.Instance.ResetSystemCanvasCamera();
		yield return GameManager.Instance.UnloadAllAssets();
		yield return DANMJLOBLIE.StartCoroutine(LLMFFOGJNLH_Coroutine_Initialize());
		BICOBOLNFLJ = true;
        UnityEngine.Debug.Log("Exit GGKONDNONPP_BootCoroutine");
    }

	// [IteratorStateMachineAttribute] // RVA: 0x6B3DA8 Offset: 0x6B3DA8 VA: 0x6B3DA8
	// // RVA: 0xA06B98 Offset: 0xA06B98 VA: 0xA06B98
	private IEnumerator DFLFHJHBKOC_CoroutineAppBoot()
	{
        UnityEngine.Debug.Log("Enter DFLFHJHBKOC_CoroutineAppBoot");
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
		DANMJLOBLIE.StartCoroutine(BLJICEOFNMM_LoadLayoutTitle());
		DANMJLOBLIE.StartCoroutine(IMDAHCEDGFK_Coroutine_TitleLogo());
		if(AppEnv.IsCBT())
		{
			UnityEngine.Debug.LogError("TODO");
		}
		else
		{
			bool BEKAMBBOLBO = false;
			NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.OLBAIKLLIFE = true;
			NKGJPJPHLIF.HHCJCDFCLOB.HGJKAEOLMJN(() => {
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
			NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.OLBAIKLLIFE = false;
			OKDMEMPECDO = true;
			while(!StorageSupport.IsAvailableStorage())
			{
				yield return null;
				UnityEngine.Debug.LogError("TODO");
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
			if(IOSBridge.GetOSMajorVersion() < 14)
			{
        		UnityEngine.Debug.LogError("Exit  Error DFLFHJHBKOC_CoroutineAppBoot");
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
		UnityEngine.Debug.Log("Exit DFLFHJHBKOC_CoroutineAppBoot");
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B3E20 Offset: 0x6B3E20 VA: 0x6B3E20
	// // RVA: 0xA06C44 Offset: 0xA06C44 VA: 0xA06C44
	private IEnumerator FIIEPEEMMLD_CoroutineStart()
	{
        UnityEngine.Debug.Log("Enter FIIEPEEMMLD_CoroutineStart");
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
		yield return DANMJLOBLIE.StartCoroutine(BLJICEOFNMM_LoadLayoutTitle());
		LKFGMDGFKDP = false;
        UnityEngine.Debug.Log("Exit FIIEPEEMMLD_CoroutineStart");
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B3E98 Offset: 0x6B3E98 VA: 0x6B3E98
	// // RVA: 0xA06CF0 Offset: 0xA06CF0 VA: 0xA06CF0
	private IEnumerator LLMFFOGJNLH_Coroutine_Initialize()
	{
        UnityEngine.Debug.Log("Enter LLMFFOGJNLH_Coroutine_Initialize");
        //0xA0F2C4
		bool BEKAMBBOLBO = false;
		bool CNAIDEAFAAM = false;
		AssetBundleManager.isTutorialNow = false;
		if(!OKDMEMPECDO)
		{
			NKGJPJPHLIF.HHCJCDFCLOB.HGJKAEOLMJN(() => {
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
		NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.OLBAIKLLIFE = true;
		DOKOHKJIDBO.HHCJCDFCLOB.DBEPFLFHAFH(false, () => {
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
		NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.OLBAIKLLIFE = true;
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
		NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.OLBAIKLLIFE = false;
		SoundResource.DecCacheClear();
		yield return DANMJLOBLIE.StartCoroutine(LCCKLAEOAMB_Coroutine_InitAREventAndTitleBG());
        UnityEngine.Debug.Log("Exit LLMFFOGJNLH_Coroutine_Initialize");
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B3F10 Offset: 0x6B3F10 VA: 0x6B3F10
	// // RVA: 0xA06D9C Offset: 0xA06D9C VA: 0xA06D9C
	private IEnumerator BLJICEOFNMM_LoadLayoutTitle()
	{
        UnityEngine.Debug.Log("Enter BLJICEOFNMM_LoadLayoutTitle");
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
		if(NOFPJPHIPBD == null)
		{
			NOFPJPHIPBD = new LayoutTitleController();
			NOFPJPHIPBD.Parent = DANMJLOBLIE.transform.parent.gameObject;
			bool CJFHNONJGIP = false;
			bool ACEAJMLOEBK = false;
			bool DEKGLHFKHBK = false;
			bool CLEFCNJNLJJ = false;
			bool AOHHKIPNNND = false;
			bool PIDLFGNJPMJ = false;
			bool IHDCDHLLAJN = false;
			bool LOAFINDJGMC = false;
			bool OPLHMBBOCCH = false;
			DANMJLOBLIE.StartCoroutine(NOFPJPHIPBD.LoadLayoutTitleLogo(() => {
				// 0xA08FE0
				CJFHNONJGIP = true;
			}));
			DANMJLOBLIE.StartCoroutine(NOFPJPHIPBD.LoadLayoutButtons(() => {
				// 0xA08FEC
				ACEAJMLOEBK = true;
			}));
			DANMJLOBLIE.StartCoroutine(NOFPJPHIPBD.LoadLayoutLbButtons(() => {
				// 0xA08FF8
				DEKGLHFKHBK = true;
			}));
			DANMJLOBLIE.StartCoroutine(NOFPJPHIPBD.LoadLayoutArButton(() => {
				// 0xA09004
				LOAFINDJGMC = true;
			}));
			DANMJLOBLIE.StartCoroutine(NOFPJPHIPBD.LoadLayoutScreenTap(() => {
				// 0xA09010
				CLEFCNJNLJJ = true;
			}));
			DANMJLOBLIE.StartCoroutine(NOFPJPHIPBD.LoadLayoutScreen(() => {
				// 0xA0901C
				AOHHKIPNNND = true;
			}));
			DANMJLOBLIE.StartCoroutine(NOFPJPHIPBD.LoadLayoutTexts(() => {
				// 0xA09028
				PIDLFGNJPMJ = true;
			}));
			DANMJLOBLIE.StartCoroutine(NOFPJPHIPBD.LoadLayoutCopyRight(() => {
				// 0xA09034
				IHDCDHLLAJN = true;
			}));
			DANMJLOBLIE.StartCoroutine(NOFPJPHIPBD.LoadLayoutMonthlyPass(() => {
				// 0xA09040
				OPLHMBBOCCH = true;
			}));
			while(!CJFHNONJGIP && !ACEAJMLOEBK && !DEKGLHFKHBK && !LOAFINDJGMC && !CLEFCNJNLJJ && !AOHHKIPNNND && !PIDLFGNJPMJ && !IHDCDHLLAJN && !OPLHMBBOCCH)
			{
				yield return null;
			}
			NOFPJPHIPBD.LayoutSetup();
		}
        UnityEngine.Debug.Log("Exit BLJICEOFNMM_LoadLayoutTitle");
	}

	// // RVA: 0xA06E24 Offset: 0xA06E24 VA: 0xA06E24
	private void PELOLGDNOGL()
	{
		UnityEngine.Debug.LogWarning("TODO PELOLGDNOGL");
		NOFPJPHIPBD.ScreenTap.ButtonCallbackTap = this.FGBKOJCFMKM;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B3F88 Offset: 0x6B3F88 VA: 0x6B3F88
	// // RVA: 0xA07174 Offset: 0xA07174 VA: 0xA07174
	private IEnumerator ABPGOJDKKHO_PopupShowSNS(Action KBCBGIGOLHP, Action AOCANKOMKFG, bool DLNDPMNLMGC = false)
	{
        UnityEngine.Debug.Log("Enter ABPGOJDKKHO_PopupShowSNS");
		UnityEngine.Debug.LogError("TODO");
        UnityEngine.Debug.Log("Exit ABPGOJDKKHO_PopupShowSNS");
		KBCBGIGOLHP();
		yield break;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B4000 Offset: 0x6B4000 VA: 0x6B4000
	// // RVA: 0xA07248 Offset: 0xA07248 VA: 0xA07248
	private IEnumerator IMDAHCEDGFK_Coroutine_TitleLogo()
	{
        UnityEngine.Debug.Log("Enter IMDAHCEDGFK_Coroutine_TitleLogo");
		//0x140845C
		LKFGMDGFKDP = true;
		
		while(NOFPJPHIPBD.TitleLogo == null || NOFPJPHIPBD.TitleLogo.IsLoaded())
		{
			yield return null;
		}
		NOFPJPHIPBD.TitleLogo.SetStatus();
		NOFPJPHIPBD.TitleLogo.Show();
		
		while(!NOFPJPHIPBD.TitleLogo.IsClose)
		{
			yield return null;
		}

		NOFPJPHIPBD.TitleLogo.Hide();
		LKFGMDGFKDP = false;

        UnityEngine.Debug.Log("Exit IMDAHCEDGFK_Coroutine_TitleLogo");
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B4078 Offset: 0x6B4078 VA: 0x6B4078
	// // RVA: 0xA072D0 Offset: 0xA072D0 VA: 0xA072D0
	private IEnumerator IMJGOIOLGIO_Contract(Action FHANAFNKIFC, Action DOGDHKIEBJA)
	{
        UnityEngine.Debug.Log("Enter IMJGOIOLGIO_Contract");
		UnityEngine.Debug.LogError("TODO");
        UnityEngine.Debug.Log("Exit IMJGOIOLGIO_Contract");
		FHANAFNKIFC();
		yield break;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B40F0 Offset: 0x6B40F0 VA: 0x6B40F0
	// // RVA: 0xA07398 Offset: 0xA07398 VA: 0xA07398
	private IEnumerator HNPMKCFMEGA_Coroutine_Inquiry()
	{
        UnityEngine.Debug.Log("Enter HNPMKCFMEGA_Coroutine_Inquiry");
		//0x140453C
		UnityEngine.Debug.LogWarning("TODO HNPMKCFMEGA_Coroutine_Inquiry");
		PELOLGDNOGL();
        UnityEngine.Debug.Log("Exit HNPMKCFMEGA_Coroutine_Inquiry");
		yield break;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B4168 Offset: 0x6B4168 VA: 0x6B4168
	// // RVA: 0xA068C0 Offset: 0xA068C0 VA: 0xA068C0
	private IEnumerator PFEKBBONCJJ_Coroutine_GameStart()
	{
        UnityEngine.Debug.Log("Enter PFEKBBONCJJ_Coroutine_GameStart");
	// private IOGKADECKOP.<>c__DisplayClass36_0 OPLBFCEPDCH; // 0x14
	// private IOGKADECKOP.<>c__DisplayClass36_1 LBLMCMHMNGC; // 0x18
	// private IOGKADECKOP.<>c__DisplayClass36_2 PHPPCOBECCA; // 0x1C
	// private CIOECGOMILE NLJKCDHIPEG; // 0x20
	// private IMMAOANGPNK MPHCKPBAKMO; // 0x24
	// private LAPFLEEAACL[] EMOMAPKPGGK; // 0x28
	// private NHPDPKHMFEP MGPMDNDOBFI; // 0x2C
	// private int FHACAEAHPIA; // 0x30
		//0xA0B93C
		// 0
		PGIGNJDPCAH.NNOBACMJHDM(0);
		PGIGNJDPCAH.IPJMPBANBPP = true;
		PGIGNJDPCAH.OGAIOKGEMDE = false;
		CNGFKOJANNP a = CNGFKOJANNP.HHCJCDFCLOB;
		if(a != null)
		{
			a.EGDJHGIAFGO();
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
		NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.MBOIDKCMCDL = false;
		
		bool BEKAMBBOLBO = false;
		bool CNAIDEAFAAM = false;
		bool OOICHDNLLJG = false;
		NKGJPJPHLIF.HHCJCDFCLOB.HGJKAEOLMJN(() => {
			//0xA09290
			BEKAMBBOLBO = true;
		}, () => {
			//0xA0929C
			BEKAMBBOLBO = true;
			CNAIDEAFAAM = true;
		}, false,false);
			// goto LAB_00a0c574;
		// 2
		//LAB_00a0c574:
		while(!BEKAMBBOLBO)
		{
			//LAB_00a0e350:
			yield return null; // To 2
		}
		// L337
		if(CNAIDEAFAAM)
		{
			// break
			NLJKCDHIPEG = null;
			MPHCKPBAKMO = null;
			DANMJLOBLIE.StartCoroutine(NNPDJBJGBFA_Coroutine_ReturnToTitle());
        	UnityEngine.Debug.LogError("Exit  Error PFEKBBONCJJ_Coroutine_GameStart");
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
		BEKAMBBOLBO = false;
		CNAIDEAFAAM = false;
		
		DOKOHKJIDBO.HHCJCDFCLOB.DBEPFLFHAFH(true, () => {
			//0xA092A8
			BEKAMBBOLBO = true;
		}, () => {
			//0xA092B4
			BEKAMBBOLBO = true;
			CNAIDEAFAAM = true;
		});
		//LAB_00a0c790:
		while(!BEKAMBBOLBO)
		{
			// goto LAB_00a0e350;
			yield return null; // to 4 // goto LAB_00a0c790;
		}
		//L424
		if(CNAIDEAFAAM)
		{
			// break;
			NLJKCDHIPEG = null;
			MPHCKPBAKMO = null;
			DANMJLOBLIE.StartCoroutine(NNPDJBJGBFA_Coroutine_ReturnToTitle());
        	UnityEngine.Debug.LogError("Exit  Error PFEKBBONCJJ_Coroutine_GameStart");
			yield break;
		}
		BEKAMBBOLBO = false;
		CNAIDEAFAAM = false;
		MPHCKPBAKMO.BAHKPIADOBI(() => {
			//0xA092C0
			BEKAMBBOLBO = true;
		}, () => {
			//0xA092CC
			BEKAMBBOLBO = true;
			CNAIDEAFAAM = true;
		});
		//LAB_00a0c8d0:
		while(!BEKAMBBOLBO)
		{
			//goto LAB_00a0e350;
			yield return null; // to 5 // goto LAB_00a0c8d0;
		}
		if(CNAIDEAFAAM)
		{
			// break;
			NLJKCDHIPEG = null;
			MPHCKPBAKMO = null;
			DANMJLOBLIE.StartCoroutine(NNPDJBJGBFA_Coroutine_ReturnToTitle());
        	UnityEngine.Debug.LogError("Exit  Error PFEKBBONCJJ_Coroutine_GameStart");
			yield break;
		}
		// L473
		BEKAMBBOLBO = false;
		CNAIDEAFAAM = false;
		JGEOBNENMAH.HHCJCDFCLOB.EMDLPEGOEJB(() => {
			//0xA092D8
			BEKAMBBOLBO = true;
		}, () => {
			//0xA092E4
			BEKAMBBOLBO = true;
			CNAIDEAFAAM = true;
		});
		//LAB_00a0caac:
		while(!BEKAMBBOLBO)
		{
			//goto LAB_00a0e350;
			yield return null; // To 6 goto LAB_00a0caac;
		}
		// L515
		if(CNAIDEAFAAM)
		{
			// break;
			NLJKCDHIPEG = null;
			MPHCKPBAKMO = null;
			DANMJLOBLIE.StartCoroutine(NNPDJBJGBFA_Coroutine_ReturnToTitle());
        	UnityEngine.Debug.LogError("Exit  Error PFEKBBONCJJ_Coroutine_GameStart");
			yield break;
		}
		// L524
		FJHPOIDFLEE();
		
		BEKAMBBOLBO = false;
		CNAIDEAFAAM = false;
		KEHOJEJMGLJ.HHCJCDFCLOB.PAHGEEOFEPM(KEHOJEJMGLJ.ACGGHEIMPHC.DEKNOKPEIHO, () => {
			//0xA092F0
			BEKAMBBOLBO = true;
		}, () => {
			//0xA092FC
			BEKAMBBOLBO = true;
			CNAIDEAFAAM = true;
		});
		//LAB_00a0cc14:
		while(!BEKAMBBOLBO)
		{
			//goto LAB_00a0e350;
			yield return null; // To 7 // goto LAB_00a0cc14;
		}
		//L571
		if(CNAIDEAFAAM)
		{
			// break
			NLJKCDHIPEG = null;
			MPHCKPBAKMO = null;
			DANMJLOBLIE.StartCoroutine(NNPDJBJGBFA_Coroutine_ReturnToTitle());
        	UnityEngine.Debug.LogError("Exit  Error PFEKBBONCJJ_Coroutine_GameStart");
			yield break;
		}
		// L 581
		NIFKNMFALEM();
		if(JJHGAKDMGLJ)
		{
			//LAB_00a0ccc0:
			while(!GameManager.Instance.ProgressBar.IsReady)
				yield return null; // To 8 goto LAB_00a0ccc0;
			
			//L604
			NOFPJPHIPBD.SetVisible(false);
			IJCPLBPLJLJ.gameObject.SetActive(true);
			FHBJNLFHGPB(0);
			//LAB_00a0e094:
			// goto goto LAB_00a0eba0;
			yield return HBBDEHKOFKN_Coroutine_DownloadTitleBannerTexture(); // To 9
			
			//9
			//L825
			GameManager.Instance.fullscreenFader.Fade(0.5f, 0);
			//goto LAB_00a0eb98;
			yield return GameManager.Instance.WaitFadeYielder; // To 10
			
			//10
			//goto LAB_00a0dbd4;
		}
		//LAB_00a0dbd4:
		FHBJNLFHGPB(30);
		long timestamp = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.FJDBNGEPKHL.KMEFBNBFJHI();
		NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.LOMEEJGIAHO.JOJFKIIHMOJ(timestamp);
		DateTime date = Utility.GetLocalDateTime(timestamp);
		NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD = date.Month * 100 + date.Year * 100000 + date.Day;
		NKGJPJPHLIF.DPCCNOCAHGC = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("server_time_auto_update", 0) == 1;
		
		BEKAMBBOLBO = false;
		CNAIDEAFAAM = false;
		NLJKCDHIPEG.ODJCMJBNDOK(() => {
			//0xA09308
			BEKAMBBOLBO = true;
		}, () => {
			//0xA09314
			OOICHDNLLJG = true;
			BEKAMBBOLBO = true;
		}, () => {
			//0xA09324
			BEKAMBBOLBO = true;
			CNAIDEAFAAM = true;
		}, false);
		//LAB_00a0df8c:
		while(!BEKAMBBOLBO)
		{
			//goto LAB_00a0e350;
			yield return null; // to 0xb //goto LAB_00a0df8c;
		}
		// L 764
		if(CNAIDEAFAAM) // Inversed
		{
			// break
			NLJKCDHIPEG = null;
			MPHCKPBAKMO = null;
			DANMJLOBLIE.StartCoroutine(NNPDJBJGBFA_Coroutine_ReturnToTitle());
        	UnityEngine.Debug.LogError("Exit  Error PFEKBBONCJJ_Coroutine_GameStart");
			yield break;
		}
		bool FBBAOFKBGBA = true;
		yield return IMJGOIOLGIO_Contract(() => {
			// 0xA09330
			FBBAOFKBGBA = false;
		}, () => {
			//0xA0933C
			FBBAOFKBGBA = true;
		});
		//goto LAB_00a0e094; // goto LAB_00a0eba0; // To 0xc
		
		// 0xc
		// L859
		if(!FBBAOFKBGBA)
		{
			if(NLJKCDHIPEG.HAELBFCGHMB)
			{
				FHBJNLFHGPB(40);
				NLJKCDHIPEG.AHEFHIMGIBI_Save.JHFIPCIHJNL.FNLNIKFNHAM = true;
				string str1 = NLJKCDHIPEG.AHEFHIMGIBI_Save.JHFIPCIHJNL.OPFGFINHFCE;
				Debug.LogError("TODO CHECK");
				if(str1 == "") // StringLiteral_9806 UTF8?
				{
					NLJKCDHIPEG.AHEFHIMGIBI_Save.JHFIPCIHJNL.AFPONJEJKCO = 0;
				}
				NLJKCDHIPEG.AHEFHIMGIBI_Save.JHFIPCIHJNL.KFKDMBPNLJK = true;
				NLJKCDHIPEG.FMFKHDPKLOC.JHFIPCIHJNL.KFKDMBPNLJK = true;
				NLJKCDHIPEG.AIKJMHBDABF(() => {
					//0xA09348
					BEKAMBBOLBO = true;
				}, () => {
					//0xA09354
					BEKAMBBOLBO = true;
				}, null);
				BEKAMBBOLBO = false;
				//goto LAB_00a0ca2c;
				
				//0xd
				//LAB_00a0ca2c:
				//L999
				while(!BEKAMBBOLBO)
				{
					//goto LAB_00a0e350;
					yield return null; // to 0xd
				}
				if(CNAIDEAFAAM)
				{
					DANMJLOBLIE.StartCoroutine(NNPDJBJGBFA_Coroutine_ReturnToTitle());
        			UnityEngine.Debug.LogError("Exit  Error PFEKBBONCJJ_Coroutine_GameStart");
					yield break;
				}
				// L 1028
				NLJKCDHIPEG.HAELBFCGHMB = false;
				//goto LAB_00a0d064;
			}
			//goto LAB_00a0d064;
			
			//LAB_00a0d064:
			FHBJNLFHGPB(60);
			if(NLJKCDHIPEG.AHEFHIMGIBI_Save.DAEJHMCMFJD.KNIKMMKNOFA == 3)
			{
				// goto LAB_00a0d0e8;
			}
			else
			{
			//L1057
				bool OJFKNEOJEHH = true;
				if(KDHGBOOECKC.HHCJCDFCLOB != null) // else goto LAB_00a0be80;
				{
					yield return KDHGBOOECKC.HHCJCDFCLOB.CEHFPAGELLE_ReceiveVOP_UnreceivedAchievements(() => {
						//0xA09618
						OJFKNEOJEHH = false;
					}, () => {
						//0xA09624
						OJFKNEOJEHH = true;
					}); //goto LAB_00a0e094; // to 0xe
					
					// 0xe
					
				}
				//LAB_00a0be80:
				if(!OJFKNEOJEHH)
				{
					//LAB_00a0d0e8:
					BEKAMBBOLBO = false;
					CNAIDEAFAAM = false;
					OFFPKPHHLKD = new AMOCLPHDGBP();
					OFFPKPHHLKD.OLNDKPDNPCM(() => {
						//0xA09360
						BEKAMBBOLBO = true;
					}, () => {
						//0xA0936C
						BEKAMBBOLBO = true;
					}, () => {
						//0xA09378
						BEKAMBBOLBO = true;
						CNAIDEAFAAM = true;
					}, false, false);
					//goto LAB_00a0d354;
					// 0xf
					//LAB_00a0d354:
					while(!BEKAMBBOLBO)
					{
						//goto LAB_00a0e350;
						yield return null; // to 0xf
					}
					if(CNAIDEAFAAM)
					{
						//break;
						NLJKCDHIPEG = null;
						MPHCKPBAKMO = null;
						DANMJLOBLIE.StartCoroutine(NNPDJBJGBFA_Coroutine_ReturnToTitle());
        				UnityEngine.Debug.LogError("Exit  Error PFEKBBONCJJ_Coroutine_GameStart");
						yield break;
					}
					//L1159
					FHBJNLFHGPB(70);
					BEKAMBBOLBO = false;
					CNAIDEAFAAM = false;
					NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.LILDGEPCPPG(() => {
						//0xA09384
						BEKAMBBOLBO = true;
					}, () => {
						//0xA09390
						BEKAMBBOLBO = true;
						CNAIDEAFAAM = true;
					}, false, true);
					//goto LAB_00a0d4d4;
					
					//0x10
					//LAB_00a0d4d4:
					while(!BEKAMBBOLBO)
					{
						//goto LAB_00a0e350;
						yield return null; // to 0x10
					}
					if(CNAIDEAFAAM)
					{
						//break;
						NLJKCDHIPEG = null;
						MPHCKPBAKMO = null;
						DANMJLOBLIE.StartCoroutine(NNPDJBJGBFA_Coroutine_ReturnToTitle());
        				UnityEngine.Debug.LogError("Exit  Error PFEKBBONCJJ_Coroutine_GameStart");
						yield break;
					}
					//L1223
					FHBJNLFHGPB(80);
					BEKAMBBOLBO = false;
					CNAIDEAFAAM = false;
					long val2 = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.FJDBNGEPKHL.KMEFBNBFJHI();
					JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.GHKKPKBBEAN(val2, () => {
						//0xA0939C
						BEKAMBBOLBO = true;
					}, () => {
						//0xA093A8
						BEKAMBBOLBO = true;
						CNAIDEAFAAM = true;
					});
					//goto LAB_00a0d720;
					
					//0x11
					//LAB_00a0d720:
					while(!BEKAMBBOLBO)
					{
						//goto LAB_00a0e350;
						yield return null; // to 0x11
					}
					if(CNAIDEAFAAM)
					{
						//break;
						NLJKCDHIPEG = null;
						MPHCKPBAKMO = null;
						DANMJLOBLIE.StartCoroutine(NNPDJBJGBFA_Coroutine_ReturnToTitle());
        				UnityEngine.Debug.LogError("Exit  Error PFEKBBONCJJ_Coroutine_GameStart");
						yield break;
					}
					//L1304
					NLJKCDHIPEG.OFGCPFFPGHE(false);
					IKDICBBFBMI_EventBase o = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(/*7*/OHCAABOMEOF.KGOGMKMBCPP.ENPJADLIFAB, /*9*/KGCNCBOKCBA.GNENJEHKMHD.BCKENOKGLIJ);
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
						GNGMCIAIKMA.HHCJCDFCLOB.HEFIKPAHCIA(null, 0);
					}
					FHBJNLFHGPB(85);
					
					BEKAMBBOLBO = false;
					CNAIDEAFAAM = false;
					EJHPIMANJFP.HHCJCDFCLOB.LILDGEPCPPG(() => {
						//0xA093B4
						BEKAMBBOLBO = true;
					}, () => {
						//0xA093C0
						BEKAMBBOLBO = true;
					}, () => {
						//0xA093CC
						BEKAMBBOLBO = true;
						CNAIDEAFAAM = true;
					}, true, true);
					//goto LAB_00a0dacc;
					//0x12
					//LAB_00a0dacc:
					while(!BEKAMBBOLBO)
					{
						//goto LAB_00a0e350;
						yield return null; // to 0x12
					}
					if(CNAIDEAFAAM)
					{
						//break;
						NLJKCDHIPEG = null;
						MPHCKPBAKMO = null;
						DANMJLOBLIE.StartCoroutine(NNPDJBJGBFA_Coroutine_ReturnToTitle());
        				UnityEngine.Debug.LogError("Exit  Error PFEKBBONCJJ_Coroutine_GameStart");
						yield break;
					}
					//L1147
					FHBJNLFHGPB(90);
					LAPFLEEAACL[] EMOMAPKPGGK = NKGJPJPHLIF.HHCJCDFCLOB.HECNGABHNDJ;
					for(int i = 0; i < EMOMAPKPGGK.Length; i++)
					{
						EMOMAPKPGGK[i].OFKONDFPMLJ();
						//LAB_00a0e464:
						while(!EMOMAPKPGGK[i].PLOOEECNHFB)
						{
							//goto LAB_00a0e350;
							yield return null; // To 0x13 // goto LAB_00a0e464;
						}
						// L1509
						if(EMOMAPKPGGK[i].NPNNPNAIONN)
						{
							//goto LAB_00a0e364;
							NLJKCDHIPEG = null;
							MPHCKPBAKMO = null;
							DANMJLOBLIE.StartCoroutine(NNPDJBJGBFA_Coroutine_ReturnToTitle());
       						UnityEngine.Debug.LogError("Exit  Error PFEKBBONCJJ_Coroutine_GameStart");
							yield break;
						}
						EMOMAPKPGGK[i].LAOEGNLOJHC();
						//LAB_00a0e56c:
						while(!EMOMAPKPGGK[i].PLOOEECNHFB)
						{
							//goto LAB_00a0e350;
							yield return null; // To 0x14 // goto LAB_00a0e56c;
						}
						//L1561
						if(EMOMAPKPGGK[i].NPNNPNAIONN)
						{
							//goto LAB_00a0e364;
							NLJKCDHIPEG = null;
							MPHCKPBAKMO = null;
							DANMJLOBLIE.StartCoroutine(NNPDJBJGBFA_Coroutine_ReturnToTitle());
        					UnityEngine.Debug.LogError("Exit  Error PFEKBBONCJJ_Coroutine_GameStart");
							yield break;
						}
					}
					FHBJNLFHGPB(93);
					NHPDPKHMFEP MGPMDNDOBFI = NHPDPKHMFEP.HHCJCDFCLOB;
					BEKAMBBOLBO = false;
					CNAIDEAFAAM = false;
					MGPMDNDOBFI.OFKONDFPMLJ(() => {
						//0xA093D8
						BEKAMBBOLBO = true;
					}, () => {
						//0xA093E4
						BEKAMBBOLBO = true;
						CNAIDEAFAAM = true;
					});
					//goto LAB_00a0e764;
					//0x15
					//LAB_00a0e764
					while(!BEKAMBBOLBO)
					{
						//goto LAB_00a0e350
						yield return null; // to 0x15
					}
					MGPMDNDOBFI.DLGMLAJMLOP = true;
					FHBJNLFHGPB(94);
					NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.IFDJHOKOEGA();
					JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.IMHONIOILIG();
					NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.KCILENCPNHD();
					NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.HIKNIPGJDAI(NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD);
					EOHDAOAJOHH.HHCJCDFCLOB.OPODBGPJDCJ();
					FHBJNLFHGPB(95);
					AppQualitySetting.InitDefault3dMode();
					if(!OOICHDNLLJG)
					{
						CIOECGOMILE.HHCJCDFCLOB.AKCOAKHAGAL();
						GameManager.Instance.localSave.EPJOACOONAC().IAHLNPMFJMH_Tutorial.PPOJCDCCFNI_TutorialEnd = 1;
						GameManager.Instance.localSave.HJMKBCFJOOH();
					}
					else
					{
						JNBOGCGCOMH(); // setup tutorial
					}
					FHBJNLFHGPB(96);
					//goto LAB_00a0eb98;
					yield return ACHBBAIODMC(); // To 16
					//16
					FHBJNLFHGPB(100);
					yield return null; // To 17
					//17
					if(JJHGAKDMGLJ) // Inversed // goto LAB_00a0cf04;
					{
						// L1813
						GameManager.Instance.fullscreenFader.Fade(0.5f, Color.black);
						yield return GameManager.Instance.WaitFadeYielder; // To 18
						//18
						NOFPJPHIPBD.SetVisible(true);
						IJCPLBPLJLJ.gameObject.SetActive(false);
					}
					
					//LAB_00a0cf04
					HFIBEEMGOND();
					yield return DANMJLOBLIE.StartCoroutine(ABPGOJDKKHO_PopupShowSNS(() => {
						//0xA093F0
						NOFPJPHIPBD.Dispose();
						NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.MBOIDKCMCDL = false;
						SoundManager.Instance.voTitlecall.RequestRemoveCueSheet();
						OGNDELCENBB(ABJDBPINCIC);
					}, () => {
						//0xA09588
						DANMJLOBLIE.StartCoroutine(NNPDJBJGBFA_Coroutine_ReturnToTitle());
					}));
					//goto LAB_00a0e3c0;
        			UnityEngine.Debug.Log("Exit PFEKBBONCJJ_Coroutine_GameStart");
					yield break;
				}
				else
				{
					//goto LAB_00a0e370;
				}
				//goto LAB_00a0e370;
			}
		}
		//goto LAB_00a0e370;
		//LAB_00a0e370
		DANMJLOBLIE.StartCoroutine(NNPDJBJGBFA_Coroutine_ReturnToTitle());
        UnityEngine.Debug.LogError("Exit  Error PFEKBBONCJJ_Coroutine_GameStart");
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B41E0 Offset: 0x6B41E0 VA: 0x6B41E0
	// // RVA: 0xA07440 Offset: 0xA07440 VA: 0xA07440
	private IEnumerator ACHBBAIODMC()
	{
        UnityEngine.Debug.Log("Enter ACHBBAIODMC");
		UnityEngine.Debug.LogError("TODO UtarateRankingUpdate");
        UnityEngine.Debug.Log("Exit ACHBBAIODMC");
		yield break;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B4258 Offset: 0x6B4258 VA: 0x6B4258
	// // RVA: 0xA074C8 Offset: 0xA074C8 VA: 0xA074C8
	private IEnumerator HBBDEHKOFKN_Coroutine_DownloadTitleBannerTexture()
	{
        UnityEngine.Debug.Log("Enter HBBDEHKOFKN_Coroutine_DownloadTitleBannerTexture");
		//0xA0B26C
		AssetBundleLoadAssetOperation AHBCOPDIEEH = null;
		
		if(BLEAOGCLJPK > 0)
		{
			string assetName = BLEAOGCLJPK.ToString("D6");
  
			string assetBundleName = String.Format("ct/bg/ld/{0:D6}.xab", BLEAOGCLJPK);
			AHBCOPDIEEH = AssetBundleManager.LoadAssetAsync(assetBundleName, assetName, typeof(Texture2D));
			yield return AHBCOPDIEEH;
			
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
        UnityEngine.Debug.Log("Exit HBBDEHKOFKN_Coroutine_DownloadTitleBannerTexture");
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B42D0 Offset: 0x6B42D0 VA: 0x6B42D0
	// // RVA: 0xA06AEC Offset: 0xA06AEC VA: 0xA06AEC
	// private IEnumerator KOEILOLECCF_StartARMode() { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B4348 Offset: 0x6B4348 VA: 0x6B4348
	// // RVA: 0xA07574 Offset: 0xA07574 VA: 0xA07574
	private IEnumerator NNPDJBJGBFA_Coroutine_ReturnToTitle()
	{
        UnityEngine.Debug.Log("Enter NNPDJBJGBFA_Coroutine_ReturnToTitle");
		//0x1405D14
		
        UnityEngine.Debug.LogError("TODO");
        UnityEngine.Debug.Log("Exit NNPDJBJGBFA_Coroutine_ReturnToTitle");
		yield break;
	}

	// // RVA: 0xA075FC Offset: 0xA075FC VA: 0xA075FC
	// private void EECGCFAKEPF() { }

	// // RVA: 0xA07698 Offset: 0xA07698 VA: 0xA07698
	private void JNBOGCGCOMH()
	{
		GameManager.Instance.IsTutorial = true;
		CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_Save.JAIGHAGMLCJ();
		ABJDBPINCIC = "Prologue";
		PGIGNJDPCAH.OGAIOKGEMDE = true;
	}

	// // RVA: 0xA0780C Offset: 0xA0780C VA: 0xA0780C
	private void CFGABDOEHBI()
	{
		GameObject go = GameObject.Find("Text_ID");
		if(go != null)
		{
			go.GetComponent<Text>().text = "Player ID : "+NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD;
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
	public void NIFKNMFALEM()
	{
		if(!GameManager.Instance.IsTutorial)
		{
			if(GameManager.Instance.localSave.EPJOACOONAC().IAHLNPMFJMH_Tutorial.PPOJCDCCFNI_TutorialEnd == 0)
				return;
			
			GameManager.Instance.ProgressBar.Begin(DANMJLOBLIE.transform.parent);
			JJHGAKDMGLJ = true;
		}
	}

	// // RVA: 0xA07D9C Offset: 0xA07D9C VA: 0xA07D9C
	public void FHBJNLFHGPB(int LNAHJANMJNM) // Update loading percent
	{
		UnityEngine.Debug.Log("Init % : "+LNAHJANMJNM);
		GameManager.Instance.ProgressBar.SetPer(LNAHJANMJNM);
	}

	// // RVA: 0xA07E70 Offset: 0xA07E70 VA: 0xA07E70
	public void HFIBEEMGOND()
	{
		GameManager.Instance.ProgressBar.End();
		if(HOFMODFAOEA != null)
		{
			UnityEngine.Object.Destroy(HOFMODFAOEA.gameObject);
			HOFMODFAOEA = null;
		}
		JJHGAKDMGLJ = false;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B43C0 Offset: 0x6B43C0 VA: 0x6B43C0
	// // RVA: 0xA07FF0 Offset: 0xA07FF0 VA: 0xA07FF0
	private IEnumerator LCCKLAEOAMB_Coroutine_InitAREventAndTitleBG()
	{
        UnityEngine.Debug.Log("Enter LCCKLAEOAMB_Coroutine_InitAREventAndTitleBG");
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
		if(!OOIBKCCMCAG)
		{
        	UnityEngine.Debug.LogError("Exit  Error LCCKLAEOAMB_Coroutine_InitAREventAndTitleBG");
			yield break;
		}
		if(PDOILOAFKCF != null)
		{
			string FCFBGJOFEHO = BFGOCONGNDK.NLMBMNKEINP(NLFFEOBGFMC);
			string s1 = String.Format("{0:D4}", NLFFEOBGFMC);
			
			AssetBundleLoadAssetOperation GDKDBPHILKG = AssetBundleManager.LoadAssetAsync(FCFBGJOFEHO, s1, typeof(Texture));
			yield return GDKDBPHILKG;
			
			PDOILOAFKCF.texture = GDKDBPHILKG.GetAsset<Texture>();
			
			AssetBundleManager.UnloadAssetBundle(FCFBGJOFEHO, false);
		}
        UnityEngine.Debug.Log("Exit LCCKLAEOAMB_Coroutine_InitAREventAndTitleBG");
	}

	// // RVA: 0xA0809C Offset: 0xA0809C VA: 0xA0809C
	private void GCGFGMICEGF()
	{
		EHKDIJELHAO = false;
		if(AREventMasterData.Instance.IsReady())
		{
			AREventMasterData.Chenge_bg bg = AREventMasterData.Instance.FindChangeBG();
			if(bg == null)
				return;
			BFGOCONGNDK a = new BFGOCONGNDK();
			a.PCODDPDFLHK();
			if(a.MBGHLLHFNHH && a.DAONJOOCPFP(bg.bgId))
			{
				OOIBKCCMCAG = true;
				NLFFEOBGFMC = bg.bgId;
			}
		}
	}

	// // RVA: 0xA081F8 Offset: 0xA081F8 VA: 0xA081F8
	private void FJHPOIDFLEE()
	{
		long val1 = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.FJDBNGEPKHL.KMEFBNBFJHI();
		BLEAOGCLJPK = 0;
		List<JOHKNBEFHHP_TitleBanner.NGKJHBDEELB> l = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ACPALDEELCL_TitleBanner.CDENCMNHNGA;
		for(int i = 0; i < l.Count; i++)
		{
			if(l[i].PPEGAKEIEGM == 2)
			{
				UnityEngine.Debug.LogError("TODO Check "+val1+" "+l[i].PDBPFJJCADD+" "+l[i].FDBNFFNFOND);
				if(val1 >= l[i].PDBPFJJCADD && val1 <= l[i].FDBNFFNFOND)
				{
					BLEAOGCLJPK = l[i].KNHOMNONOEB;
					return;
				}
			}
		}
		
	}

	// [CompilerGeneratedAttribute] // RVA: 0x6B4438 Offset: 0x6B4438 VA: 0x6B4438
	// // RVA: 0xA085A0 Offset: 0xA085A0 VA: 0xA085A0
	// private void <SetLayoutButtonCallback>b__31_0() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6B4448 Offset: 0x6B4448 VA: 0x6B4448
	// // RVA: 0xA085FC Offset: 0xA085FC VA: 0xA085FC
	// private void <SetLayoutButtonCallback>b__31_1() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6B4458 Offset: 0x6B4458 VA: 0x6B4458
	// // RVA: 0xA087F8 Offset: 0xA087F8 VA: 0xA087F8
	// private void <SetLayoutButtonCallback>b__31_3() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6B4468 Offset: 0x6B4468 VA: 0x6B4468
	// // RVA: 0xA088EC Offset: 0xA088EC VA: 0xA088EC
	// private bool <Coroutine_DownloadTitleBannerTexture>b__38_0(FileResultObject NLCGHBBNOJA) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6B4478 Offset: 0x6B4478 VA: 0x6B4478
	// // RVA: 0xA089D0 Offset: 0xA089D0 VA: 0xA089D0
	// private void <OnPushBackButton>b__44_0() { }
}
