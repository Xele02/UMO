using UnityEngine;
using XeApp.Game;
using XeApp.Game.Menu;
using XeApp.Game.Title;
using XeApp.Game.Common.uGUI;
using UnityEngine.UI;
using System.Collections;
using XeApp;
using UdonLib;

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
	//private readonly int[] MLDJAIHDFOM = new int[10] {Field$<PrivateImplementationDetails>.E0D2592373A0C161E56E266306CD8405CD719D19}; // 0x40

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
        PGIGNJDPCAH.FLHLJFHILPO(false);
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
		if(MCJHELIEHMC.IsOpen())
			return;
		
		if(NOFPJPHIPBD.IsSupportPopupOpen())
			return;
		
		NOFPJPHIPBD.Buttons.CallbackClear();
		NOFPJPHIPBD.LbButtons.CallbackClear();
		SoundManager.sePlayerBoot.Play(8);
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
        UnityEngine.Debug.LogError("TODO");
		yield return null;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B3D30 Offset: 0x6B3D30 VA: 0x6B3D30
	// // RVA: 0xA06564 Offset: 0xA06564 VA: 0xA06564
	private IEnumerator GGKONDNONPP_BootCoroutine()
    {
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
		
		if(GameManager.Instance.IsSystemInitialized())
		{
			SoundResource.DecCacheClear();
			ConfigManager.SetUserData();
			GameManager.Instance.ChangePopupPriority(true);
			GameManager.Instance.SetSystemCanvasRenderMode(1);
			GameManager.Instance.SetTouchEffectVisible(true);
			DANMJLOBLIE.StartCoroutine(BLJICEOFNMM_LoadLayoutTitle());
			DANMJLOBLIE.StartCoroutine(IMDAHCEDGFK_TitleLogo());
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
					yield break;
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
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B3E20 Offset: 0x6B3E20 VA: 0x6B3E20
	// // RVA: 0xA06C44 Offset: 0xA06C44 VA: 0xA06C44
	private IEnumerator FIIEPEEMMLD_CoroutineStart()
	{
		//0xA0A82C
		ConfigManager.SetUserData();
		GameManager.Instance.fullscreenFader.Fade(0, Color.black);
		GameManager.Instance.SetResolutionDefault();
		GameManager.Instance.SetSystemCanvasRendreMode(1);
		GameManager.Instance.SetTouchEffectVisible(true);
		GameManager.Instance.SetTouchEffectMode(false);
		Vector2 screenSize;
		if(!SystemManager.isLongScreenDevice)
		{
			screenSize = GameManager.Instance.BaseScreenSize;
		}
		else
		{
			screenSize = SystemManager.longScreenReferenceResolution;
		}
		GameManager.Instance.SetSystemCanvasResolution(screenSize);
		yield return DANMJLOBLIE.StartCoroutine(BLJICEOFNMM_LoadLayoutTitle());
		LKFGMDGFKDP = false;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B3E98 Offset: 0x6B3E98 VA: 0x6B3E98
	// // RVA: 0xA06CF0 Offset: 0xA06CF0 VA: 0xA06CF0
	private IEnumerator LLMFFOGJNLH_Coroutine_Initialize()
	{
        //0xA0F2C4
		bool BEKAMBBOLBO = false;
		AssetBundleManager.isTutorialNow = false;
		if(!OKDMEMPECDO)
		{
			bool CNAIDEAFAAM = false;
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
		});
		while(!BEKAMBBOLBO)
		{
			yield return null;
		}
		NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.OLBAIKLLIFE = false;
		SoundResource.DecCacheClear();
		yield return DANMJLOBLIE.StartCoroutine(LCCKLAEOAMB_InitAREventAndTitleBG());
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B3F10 Offset: 0x6B3F10 VA: 0x6B3F10
	// // RVA: 0xA06D9C Offset: 0xA06D9C VA: 0xA06D9C
	private IEnumerator BLJICEOFNMM_LoadLayoutTitle()
	{
		//0x1404868
		if(IJCPLBPLJLJ == null)
		{
			IJCPLBPLJLJ = Object.FindObjectOfType<BgBehaviour>();
			while(IJCPLBPLJLJ == null)
			{
				yield return null;
			}
			IJCPLBPLJLJ.SetMenu();
			IJCPLBPLJLJ.ChangeColor(2);
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
			Method$IOGKADECKOP.<>c__DisplayClass30_0.AAKKDFHKLMG()
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
	}

	// // RVA: 0xA06E24 Offset: 0xA06E24 VA: 0xA06E24
	// private void PELOLGDNOGL() { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B3F88 Offset: 0x6B3F88 VA: 0x6B3F88
	// // RVA: 0xA07174 Offset: 0xA07174 VA: 0xA07174
	// private IEnumerator ABPGOJDKKHO_PopupShowSNS(Action KBCBGIGOLHP, Action AOCANKOMKFG, bool DLNDPMNLMGC = False) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B4000 Offset: 0x6B4000 VA: 0x6B4000
	// // RVA: 0xA07248 Offset: 0xA07248 VA: 0xA07248
	private IEnumerator IMDAHCEDGFK_Coroutine_TitleLogo()
	{
		//0x140845C
		LKFGMDGFKDP = true;
		
		while(NOFPJPHIPBD.TitleLogo == null || NOFPJPHIPBD.TitleLogo.IsLoaded())
		{
			yield return null;
		}
		NOFPJPHIPBD.TitleLogo.SetStatus();
		NOFPJPHIPBD.TitleLogo.Show();
		
		while(!NOFPJPHIPBD.TitleLogo.IsClose())
		{
			NOFPJPHIPBD.TitleLogo.Hide();
			LKFGMDGFKDP = false;
		}
		
        UnityEngine.Debug.LogError("TODO");
        yield break;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B4078 Offset: 0x6B4078 VA: 0x6B4078
	// // RVA: 0xA072D0 Offset: 0xA072D0 VA: 0xA072D0
	// private IEnumerator IMJGOIOLGIO_Contract(Action FHANAFNKIFC, Action DOGDHKIEBJA) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B40F0 Offset: 0x6B40F0 VA: 0x6B40F0
	// // RVA: 0xA07398 Offset: 0xA07398 VA: 0xA07398
	// private IEnumerator HNPMKCFMEGA_Inquiry() { }

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
		PGIGNJDPCAH.NNOBACMJHDM(0);
		PGIGNJDPCAH.FLHLJFHILPO(true);
		PGIGNJDPCAH.OGAIOKGEMDE = false;
		CNGFKOJANNP a = CNGFKOJANNP$$NKACBOEHELJ();
		if(a != null)
		{
			a.EGDJHGIAFGO();
		}
		GameManager.Instance.fullscreenFader.Fade(1, Color.black);
		GameManager.Instance.RemovePushBackButtonHandler(new PushBackButtonHandler());
		KEHOJEJMGLJ.NKACBOEHELJ().OFLDICKPNFD(true, () => {
			//0xA08CA4
			MenuScene.Instance.GotoTitle();
		});
		KDLPEDBKMID.NKACBOEHELJ().OFLDICKPNFD(true, () => {
			//0xA08D40
			MenuScene.Instance.GotoTitle();
		});
		TipsControl.SetSituationValue(2,1);
		yield return GameManager.Instance.WaitFadeYielder();
		
		CIOECGOMILE NLJKCDHIPEG = CIOECGOMILE.NKACBOEHELJ();
		IMMAOANGPNK MPHCKPBAKMO = IMMAOANGPNK.NKACBOEHELJ();
		NKGJPJPHLIF.NKACBOEHELJ().OIFEGPGEFEI().GOFGBIANJGF(false);
		
		BEKAMBBOLBO = false;
		CNAIDEAFAAM = false;
		OOICHDNLLJG = false;
		NKGJPJPHLIF.NKACBOEHELJ().HGJKAEOLMJN(() => {
			//0xA09290
			BEKAMBBOLBO = true;
		}, () => {
			//0xA0929C
			BEKAMBBOLBO = true;
			CNAIDEAFAAM = true;
		}, false,false);
		while(!BEKAMBBOLBO)
		{
			yield return null;
		}
		if(CNAIDEAFAAM)
		{
			NLJKCDHIPEG = null;
			MPHCKPBAKMO = null;
			DANMJLOBLIE.StartCoroutine(NNPDJBJGBFA_ReturnToTitle());
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
		
		DOKOHKJIDBO.NKACBOEHELJ().DBEPFLFHAFH(true, () => {
			//0xA092A8
			BEKAMBBOLBO = true;
		}, () => {
			//0xA092B4
			BEKAMBBOLBO = true;
			CNAIDEAFAAM = true;
		});
		while(!BEKAMBBOLBO)
		{
			yield return null;
		}
		if(CNAIDEAFAAM)
		{
			NLJKCDHIPEG = null;
			MPHCKPBAKMO = null;
			DANMJLOBLIE.StartCoroutine(NNPDJBJGBFA_ReturnToTitle());
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
		while(!BEKAMBBOLBO)
		{
			yield return null;
		}
		if(CNAIDEAFAAM)
		{
			NLJKCDHIPEG = null;
			MPHCKPBAKMO = null;
			DANMJLOBLIE.StartCoroutine(NNPDJBJGBFA_ReturnToTitle());
			yield break;
		}
		BEKAMBBOLBO = false;
		CNAIDEAFAAM = false;
		JGEOBNENMAH.NKACBOEHELJ.EMDLPEGOEJB(() => {
			//0xA092D8
			BEKAMBBOLBO = true;
		}, () => {
			//0xA092E4
			BEKAMBBOLBO = true;
			CNAIDEAFAAM = true;
		});
		while(!BEKAMBBOLBO)
		{
			yield return null;
		}
		if(CNAIDEAFAAM)
		{
			NLJKCDHIPEG = null;
			MPHCKPBAKMO = null;
			DANMJLOBLIE.StartCoroutine(NNPDJBJGBFA_ReturnToTitle());
			yield break;
		}
		FJHPOIDFLEE();
		
		BEKAMBBOLBO = false;
		CNAIDEAFAAM = false;
		KEHOJEJMGLJ.NKACBOEHELJ.PAHGEEOFEPM(2, () => {
			//0xA092F0
			BEKAMBBOLBO = true;
		}, 0, () => {
			//0xA092FC
			BEKAMBBOLBO = true;
			CNAIDEAFAAM = true;
		});
		while(!BEKAMBBOLBO)
		{
			yield return null;
		}
		if(CNAIDEAFAAM)
		{
			NLJKCDHIPEG = null;
			MPHCKPBAKMO = null;
			DANMJLOBLIE.StartCoroutine(NNPDJBJGBFA_ReturnToTitle());
			yield break;
		}
		NIFKNMFALEM();
		if(JJHGAKDMGLJ)
		{
			while(!GameManager.Instance.ProgressBar.IsReady)
				yield return null;
			
			NOFPJPHIPBD.SetVisible(false);
			IJCPLBPLJLJ.gameObject.SetActive(true);
			FHBJNLFHGPB(0);
			yield return HBBDEHKOFKN_DownloadTitleBannerTexture();
			
			//GameManager.Instance.
			// 825
		}
		
		//636
		
		
        UnityEngine.Debug.LogError("TODO");
		
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B41E0 Offset: 0x6B41E0 VA: 0x6B41E0
	// // RVA: 0xA07440 Offset: 0xA07440 VA: 0xA07440
	// private IEnumerator ACHBBAIODMC() { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B4258 Offset: 0x6B4258 VA: 0x6B4258
	// // RVA: 0xA074C8 Offset: 0xA074C8 VA: 0xA074C8
	// private IEnumerator HBBDEHKOFKN_DownloadTitleBannerTexture() { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B42D0 Offset: 0x6B42D0 VA: 0x6B42D0
	// // RVA: 0xA06AEC Offset: 0xA06AEC VA: 0xA06AEC
	// private IEnumerator KOEILOLECCF_StartARMode() { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B4348 Offset: 0x6B4348 VA: 0x6B4348
	// // RVA: 0xA07574 Offset: 0xA07574 VA: 0xA07574
	// private IEnumerator NNPDJBJGBFA_ReturnToTitle() { }

	// // RVA: 0xA075FC Offset: 0xA075FC VA: 0xA075FC
	// private void EECGCFAKEPF() { }

	// // RVA: 0xA07698 Offset: 0xA07698 VA: 0xA07698
	// private void JNBOGCGCOMH() { }

	// // RVA: 0xA0780C Offset: 0xA0780C VA: 0xA0780C
	// private void CFGABDOEHBI() { }

	// // RVA: 0xA07A3C Offset: 0xA07A3C VA: 0xA07A3C
	// private void GJLDMJFMIOD() { }

	// // RVA: 0xA07B88 Offset: 0xA07B88 VA: 0xA07B88
	// public void NIFKNMFALEM() { }

	// // RVA: 0xA07D9C Offset: 0xA07D9C VA: 0xA07D9C
	// public void FHBJNLFHGPB(int LNAHJANMJNM) { }

	// // RVA: 0xA07E70 Offset: 0xA07E70 VA: 0xA07E70
	// public void HFIBEEMGOND() { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B43C0 Offset: 0x6B43C0 VA: 0x6B43C0
	// // RVA: 0xA07FF0 Offset: 0xA07FF0 VA: 0xA07FF0
	private IEnumerator LCCKLAEOAMB_InitAREventAndTitleBG()
	{
        UnityEngine.Debug.LogError("TODO");
        yield break;
	}

	// // RVA: 0xA0809C Offset: 0xA0809C VA: 0xA0809C
	// private void GCGFGMICEGF() { }

	// // RVA: 0xA081F8 Offset: 0xA081F8 VA: 0xA081F8
	private void FJHPOIDFLEE()
	{
        UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0xA084F8 Offset: 0xA084F8 VA: 0xA084F8
	// public void .ctor() { }

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
