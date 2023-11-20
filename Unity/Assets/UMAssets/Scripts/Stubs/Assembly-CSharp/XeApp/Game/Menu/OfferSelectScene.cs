using mcrs;
using System;
using System.Collections;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;
using XeSys;

namespace XeApp.Game.Menu
{
	public class OfferSelectScene : TransitionRoot
	{
		[SerializeField]
		private CharTouchHitCheck hitCheckPanel; // 0x48
		private const float AloneTime = 10;
		private const int BGM_ID = 1025;
		private OfferSelectDivaController m_divaController; // 0x4C
		private OfferSelectController m_controller; // 0x50
		private bool IsInitialize; // 0x54
		private bool IsExitAction; // 0x55
		private bool IsBootLoading; // 0x56
		private Transform AnimCanvas; // 0x5C
		private bool IsPlayBoot; // 0x60
		private bool IsTutorial; // 0x61
		private Action updater; // 0x64
		private bool IsExit; // 0x68
		private float AloneCounter; // 0x6C
		private bool IsAssetLoaded; // 0x70
		private bool IsSaveing; // 0x71
		private bool IsPopupPhase; // 0x72
		private bool IsForcedExit; // 0x73
		private bool IsEnterCorutineEnd; // 0x74
		private bool IsUpdateServerTime; // 0x75

		public LayoutOfferBoot layoutBoot { get; private set; } // 0x58

		//// RVA: 0x1709D54 Offset: 0x1709D54 VA: 0x1709D54
		//private bool IsDone() { }

		// RVA: 0x1709D90 Offset: 0x1709D90 VA: 0x1709D90
		private void Awake()
		{
			base.Awake();
			IsReady = true;
			m_controller = GetComponent<OfferSelectController>();
			m_divaController = GetComponent<OfferSelectDivaController>();
			AnimCanvas = GameManager.Instance.PopupCanvas.transform.Find("Root").transform;
		}

		// RVA: 0x1709EF8 Offset: 0x1709EF8 VA: 0x1709EF8
		private void Start()
		{
			ILCCJNDFFOB.HHCJCDFCLOB.BKLNHBHDDEJ(JpStringLiterals.StringLiteral_18923);
		}

		// RVA: 0x1709FA4 Offset: 0x1709FA4 VA: 0x1709FA4
		private void Update()
		{
			if (updater != null)
				updater();
		}

		// RVA: 0x1709FB8 Offset: 0x1709FB8 VA: 0x1709FB8 Slot: 16
		protected override void OnPreSetCanvas()
		{
			IsSaveing = false;
			IsPlayBoot = true;
			IsPopupPhase = true;
			IsForcedExit = false;
			if(PrevTransition < TransitionList.Type.OFFER_TRANSFORMATION)
			{
				if (PrevTransition == TransitionList.Type.UNLOCK_VALKYRIE || PrevTransition == TransitionList.Type.OFFER_FORMATION)
					IsPlayBoot = false;
			}
			else
			{
				if(PrevTransition == TransitionList.Type.OFFER_TRANSFORMATION)
				{
					IsPlayBoot = false;
					PGIGNJDPCAH.HIHIEBACIHJ(PGIGNJDPCAH.FELLIEJEPIJ.LPBDIINNFEE_5);
				}
				else if(PrevTransition == TransitionList.Type.OFFER_RESULT)
					IsPlayBoot = false;
			}
			IsPlayBoot |= layoutBoot == null;
			IsExit = false;
			IsInitialize = false;
			base.OnPreSetCanvas();
			if(IsPlayBoot)
			{
				this.StartCoroutineWatched(BOOTAnimation());
			}
			m_controller.IsGoToHome = true;
			this.StartCoroutineWatched(Co_initialize());
		}

		// RVA: 0x170A214 Offset: 0x170A214 VA: 0x170A214 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return IsInitialize && m_controller.IsLayoutAssetLoad;
		}

		// RVA: 0x170A250 Offset: 0x170A250 VA: 0x170A250 Slot: 18
		protected override void OnPostSetCanvas()
		{
			IsUpdateServerTime = false;
			this.StartCoroutineWatched(Co_serverTimeUpdateWait(() =>
			{
				//0x170B84C
				IsUpdateServerTime = true;
			}, () =>
			{
				//0x170B858
				GotoTitle();
				IsUpdateServerTime = true;
				transform.SetAsLastSibling();
				if(layoutBoot != null)
				{
					layoutBoot.transform.SetParent(transform);
				}
			}));
			base.OnPostSetCanvas();
		}

		// RVA: 0x170A354 Offset: 0x170A354 VA: 0x170A354 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			return IsUpdateServerTime;
		}

		// RVA: 0x170A35C Offset: 0x170A35C VA: 0x170A35C Slot: 21
		protected override void OnOpenScene()
		{
			base.OnActivateScene();
			this.StartCoroutineWatched(Co_Enter());
			this.StartCoroutineWatched(Co_DivaEnter());
		}

		// RVA: 0x170A4BC Offset: 0x170A4BC VA: 0x170A4BC Slot: 24
		protected override bool IsEndActivateScene()
		{
			return base.IsEndActivateScene();
		}

		// RVA: 0x170A4C4 Offset: 0x170A4C4 VA: 0x170A4C4 Slot: 12
		protected override void OnStartExitAnimation()
		{
			base.OnStartExitAnimation();
			IsExit = true;
			if(!m_controller.IsGoToHome)
			{
				MenuScene.Instance.HeaderMenu.Leave(false);
			}
			else
			{
				GameManager.Instance.fullscreenFader.Fade(0.1f, Color.black);
				if(m_divaController != null)
				{
					m_divaController.IsAloneMotion = false;
					m_divaController.DivaStopVoice();
				}
			}
			m_controller.EixtScene();
			this.StartCoroutineWatched(Co_ExitAction(m_controller.IsGoToHome));
		}

		// RVA: 0x170A7DC Offset: 0x170A7DC VA: 0x170A7DC Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !IsExitAction;
		}

		// RVA: 0x170A7F0 Offset: 0x170A7F0 VA: 0x170A7F0 Slot: 14
		protected override void OnDestoryScene()
		{
			base.OnDestoryScene();
			m_divaController.DestroyScene();
			if(IsForcedExit)
			{
				Destroy(layoutBoot.gameObject);
			}
			updater = null;
		}

		// RVA: 0x170A8D4 Offset: 0x170A8D4 VA: 0x170A8D4 Slot: 15
		protected override void OnDeleteCache()
		{
			base.OnDeleteCache();
			m_divaController.Release();
			m_divaController.DeleteCash();
			if(m_controller != null)
			{
				Destroy(m_controller.ItemCheck.gameObject);
			}
			MenuScene.Instance.divaManager.transform.Find("DivaCamera").GetComponent<Camera>().enabled = true;
			SoundResource.RemoveCueSheet("cs_vfo");
		}

		// RVA: 0x170AB54 Offset: 0x170AB54 VA: 0x170AB54 Slot: 20
		protected override bool OnBgmStart()
		{
			return true;
		}

		//// RVA: 0x170A330 Offset: 0x170A330 VA: 0x170A330
		//public void serverTimeUpdateWait(Action SuccessAction, Action ErrorAction) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6FBC8C Offset: 0x6FBC8C VA: 0x6FBC8C
		//// RVA: 0x170AB5C Offset: 0x170AB5C VA: 0x170AB5C
		private IEnumerator Co_serverTimeUpdateWait(Action SuccessAction, Action ErrorAction)
		{
			//0x170EC64
			MenuScene.Instance.RaycastDisable();
			bool IsDone = false;
			bool IsError = false;
			NKGJPJPHLIF.HHCJCDFCLOB.CADNBFCHAKM_GetToken(() =>
			{
				//0x170BC58
				IsDone = true;
			}, () =>
			{
				//0x170BC64
				IsDone = true;
				IsError = true;
			});
			while (!IsDone)
				yield return null;
			if(!IsError)
			{
				SuccessAction();
				MenuScene.Instance.RaycastEnable();
			}
			else
			{
				ErrorAction();
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FBD04 Offset: 0x6FBD04 VA: 0x6FBD04
		//// RVA: 0x170A188 Offset: 0x170A188 VA: 0x170A188
		private IEnumerator Co_initialize()
		{
			while (IsBootLoading)
				yield return null;
			if (layoutBoot != null)
			{
				yield return null;
				while (!layoutBoot.IsStartEnd)
					yield return null;
			}
			if(!IsAssetLoaded)
			{
				m_controller.AssetLoadStart();
				IsAssetLoaded = true;
			}
			yield return Co.R(MenuScene.Instance.BgControl.ChangeBgCoroutine(BgType.Offer, -1, SceneGroupCategory.UNDEFINED, TransitionList.Type.UNDEFINED, -1));
			hitCheckPanel.OnClickCallback = () =>
			{
				//0x170BC4C
				return;
			};
			m_divaController.initializeCamera(false);
			yield return Resources.UnloadUnusedAssets();
			IsInitialize = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FBD7C Offset: 0x6FBD7C VA: 0x6FBD7C
		//// RVA: 0x170A430 Offset: 0x170A430 VA: 0x170A430
		private IEnumerator Co_DivaEnter()
		{
			//0x170C5E8
			while (m_controller == null)
				yield return null;
			while (m_divaController == null)
				yield return null;
			if(layoutBoot != null)
			{
				while (layoutBoot.IsPlaying())
					yield return null;
			}
			yield return null;
			while(m_controller.IsAllLayoutIsPlaying())
				yield return null;
			m_divaController.Initialize(false);
			m_controller.SetDivaController(m_divaController);
			m_controller.OnEndAllDoneAction = Co_OnEndAllDoneAction();
			yield return null;
			while(!m_divaController.IsModelLoad)
				yield return null;
			yield return null;
			if (IsExit)
				yield break;
			if(!IsPlayBoot)
			{
				m_divaController.DivaEnterCamera();
			}
			while (IsPopupPhase)
				yield return null;
			if(IsPlayBoot)
			{
				m_divaController.DivaEnterCamera();
				if (!m_divaController.IsEnterSkip)
					m_divaController.DivaPlayEntry();
				else
					m_divaController.DivaPlayIdle();
			}
			hitCheckPanel.OnClickCallback = () =>
			{
				//0x170B980
				StartDivaTapMotion();
			};
		}

		//// RVA: 0x170AC64 Offset: 0x170AC64 VA: 0x170AC64
		private void StartDivaTapMotion()
		{
			if(!IsPopupPhase)
			{
				if(m_divaController != null)
				{
					if(m_divaController.IsPlayingIdle())
					{
						if (!m_divaController.IsPlayingIdleMouth())
							return;
						if(!m_divaController.IsPlayingDivaVoice() && !IsTutorial)
						{
							SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_HOME_000);
							m_divaController.DivaPlayTouchReaction();
							AloneCounter = 0;
							ILCCJNDFFOB.HHCJCDFCLOB.FJBCAHAFLNO();
						}
					}
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FBDF4 Offset: 0x6FBDF4 VA: 0x6FBDF4
		//// RVA: 0x170A3A4 Offset: 0x170A3A4 VA: 0x170A3A4
		private IEnumerator Co_Enter()
		{
			BBHNACPENDM_ServerSaveData pd; // 0x1C
			bool IsFirstOrder; // 0x20
			bool IsValkyrieHelp; // 0x21

			//0x170D020
			m_controller.initialize();
			m_controller.SetOrderButton(OrderButton, ProgressButton, CompleteButton);
			IsEnterCorutineEnd = false;
			MenuScene.Instance.InputDisable();
			pd = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave;
			if (pd != null)
			{
				if (!pd.DAEJHMCMFJD_Offer.MLBBKNLPBBD(BOPFPIHGJMD.PDLKAKEABDP.EILIAPKFCEO_0))
				{
					pd.DAEJHMCMFJD_Offer.ILMPHFPFLJE(BOPFPIHGJMD.PDLKAKEABDP.EILIAPKFCEO_0, true);
				}
			}
			IsSaveing = true;
			CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
			{
				//0x170BC78
				IsSaveing = false;
			}, () =>
			{
				//0x170BCA0
				IsForcedExit = true;
				MenuScene.Instance.GotoTitle();
			}, null);
			while (IsSaveing)
				yield return null;
			if(layoutBoot != null)
			{
				layoutBoot.Out();
			}
			yield return null;
			if(layoutBoot != null)
			{
				//LAB_0170d4f4
				while (layoutBoot.IsPlaying())
					yield return null;
				layoutBoot.transform.SetParent(transform);
			}
			//LAB_0170dfa8
			SoundManager.Instance.bgmPlayer.ContinuousPlay(1025, 1);
			m_controller.layoutAllEnter();
			KDHGBOOECKC.HHCJCDFCLOB.IOCBOGFFHFE.LHPDDGIJKNB();
			KDHGBOOECKC.HHCJCDFCLOB.CPDBAIILNPL(true);
			yield return null;
			IsFirstOrder = !pd.DAEJHMCMFJD_Offer.MLBBKNLPBBD(BOPFPIHGJMD.PDLKAKEABDP.HFKNIAGOFKC_1);
			IsValkyrieHelp = !pd.DAEJHMCMFJD_Offer.MLBBKNLPBBD(BOPFPIHGJMD.PDLKAKEABDP.GHGLPOGHBBL_3);
			m_controller.ItemCheck.ButtonDisable();
			if(IsFirstOrder)
			{
				IsTutorial = true;
				IsPopupPhase = false;
			}
			if(PrevTransition == TransitionList.Type.UNLOCK_VALKYRIE)
			{
				bool IsClosePopup = false;
				m_controller.ShowRelesePlatoonPopup(() =>
				{
					//0x170BD70
					IsClosePopup = true;
				});
				while (!IsClosePopup)
					yield return null;
				IsTutorial = true;
				yield return Co.R(TutorialManager.TryShowTutorialCoroutine(CheckTutorialFunc_GetValkyrie));
			}
			//LAB_0170d7b0
			yield return Co.R(Co_DivaOfferHelp());
			yield return Co.R(Co_CostumeUpgradeTutorial());
			if(IsValkyrieHelp && !IsFirstOrder)
			{
				IsTutorial = true;
				if(pd.DAEJHMCMFJD_Offer.MLBBKNLPBBD(BOPFPIHGJMD.PDLKAKEABDP.HFKNIAGOFKC_1))
				{
					pd.DAEJHMCMFJD_Offer.ILMPHFPFLJE(BOPFPIHGJMD.PDLKAKEABDP.GHGLPOGHBBL_3, true);
					yield return Co.R(TutorialManager.TryShowTutorialCoroutine(CheckTutorialFunc_OfferDetail));

				}
			}
			if(IsFirstOrder)
			{
				MenuScene.Instance.RaycastDisable();
				while (m_divaController.IsModelLoad)
					yield return null;
				while (!m_divaController.IsPlayingIdle())
					yield return null;
				MenuScene.Instance.RaycastEnable();
				m_controller.StartTutorial();
			}
			//LAB_0170da84
			while (m_controller.IsOrderInduction)
				yield return null;
			IsTutorial = false;
			if(KDHGBOOECKC.HHCJCDFCLOB.PHNCOGEOBAD())
			{
				KDHGBOOECKC.HHCJCDFCLOB.OLNHMMHLAGF(false);
				yield return Co.R(ShowAddOfferPopup());
			}
			//LAB_0170db24
			bool IsGetValkyrie = false;
			yield return Co.R(m_controller.Co_GoToGetValkyrie(() =>
			{
				//0x170BD5C
				IsGetValkyrie = true;
			}));
			if(!IsFirstOrder)
			{
				if(!IsGetValkyrie)
				{
					if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().DKFCBKNPPOO_Offer.FBCDKFENOEM())
					{
						GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
					}
					yield return Co.R(m_controller.Co_dailyOperationDiff());
					if(KDHGBOOECKC.HHCJCDFCLOB.MGHPDFMDFCJ())
					{
						yield return Co.R(m_controller.Co_DivaOperationDiff());
					}
					//LAB_0170dd5c
					if(!KDHGBOOECKC.HHCJCDFCLOB.OHILPCDFKCH())
					{
						yield return Co.R(m_controller.Co_PlatoonRelease());
					}
					//LAB_0170ddd8
					CheckSnsNotice();
				}
			}
			//LAB_0170ddf0
			m_controller.ItemCheck.ButtonEnable();
			MenuScene.Instance.InputEnable();
			IsEnterCorutineEnd = true;
			IsPopupPhase = false;
			updater = LeaveAlone;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FBE6C Offset: 0x6FBE6C VA: 0x6FBE6C
		//// RVA: 0x170AE60 Offset: 0x170AE60 VA: 0x170AE60
		private IEnumerator Co_OnEndAllDoneAction()
		{
			//0x170E6EC
			yield return Co.R(Co_DivaOfferHelp());
			yield return Co.R(Co_CostumeUpgradeTutorial());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FBEE4 Offset: 0x6FBEE4 VA: 0x6FBEE4
		//// RVA: 0x170AF0C Offset: 0x170AF0C VA: 0x170AF0C
		private IEnumerator Co_DivaOfferHelp()
		{
			//0x170CB7C
			if(KDHGBOOECKC.HHCJCDFCLOB.MGHPDFMDFCJ() && !CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.MLBBKNLPBBD(BOPFPIHGJMD.PDLKAKEABDP.LGJIPMIHAKC_2))
			{
				for(int i = 0; i < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count; i++)
				{
					GameManager.Instance.localSave.EPJOACOONAC_GetSave().DKFCBKNPPOO_Offer.AHOBDLOOLHD(i + 1, KDHGBOOECKC.HHCJCDFCLOB.HFLNFKFGEJH(i + 1));
				}
				GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.ILMPHFPFLJE(BOPFPIHGJMD.PDLKAKEABDP.LGJIPMIHAKC_2, true);
				yield return Co.R(TutorialManager.TryShowTutorialCoroutine(CheckTutorialFunc_OpenDivaOffer));
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FBF5C Offset: 0x6FBF5C VA: 0x6FBF5C
		//// RVA: 0x170AFB8 Offset: 0x170AFB8 VA: 0x170AFB8
		private IEnumerator Co_CostumeUpgradeTutorial()
		{
			//0x170C1E8
			if(MOEALEGLGCH.CDOCOLOKCJK() && !CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.BEKHNNCGIEL_Costume.MLBBKNLPBBD_IsTutoDone(0))
			{
				IsTutorial = true;
				IsPopupPhase = false;
				m_controller.ItemCheck.ButtonDisable();
				if(MenuScene.Instance.GetInputDisableCount() > 0)
				{
					MenuScene.Instance.InputEnable();
				}
				yield return Co.R(TutorialProc.Co_CostumeUpgrade(EBFLJMOCLNA_Costume.NDOPBOCEPJO.NHIOLMNADIO_0, MenuScene.Instance.FooterMenu.FindButton(MenuFooterControl.Button.Setting), BasicTutorialMessageId.Id_CostumeUpgradeHome, InputLimitButton.Setting, TutorialPointer.Direction.Down));
				m_controller.ItemCheck.ButtonEnable();
				IsEnterCorutineEnd = true;
				IsTutorial = false;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FBFD4 Offset: 0x6FBFD4 VA: 0x6FBFD4
		//// RVA: 0x170B064 Offset: 0x170B064 VA: 0x170B064
		private IEnumerator ShowAddOfferPopup()
		{
			//0x170F458
			bool IsClosePopup = false;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = new TextPopupSetting();
			s.IsCaption = false;
			s.Text = bk.GetMessageByLabel("popup_add_operation_text");
			s.WindowSize = SizeType.SSmall;
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(s, (PopupWindowControl cont, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x170BD84
				IsClosePopup = true;
			}, null, null, null);
			while (!IsClosePopup)
				yield return null;
		}

		//// RVA: 0x170B0F8 Offset: 0x170B0F8 VA: 0x170B0F8
		private void LeaveAlone()
		{
			if (PopupWindowManager.IsActivePopupWindow())
				return;
			if (!IsTutorial)
			{
				if (AloneCounter >= 10)
				{
					AloneCounter = 0;
					if (!m_divaController.IsPlayingIdle())
						return;
					if (m_divaController.IsPlayingDivaVoice())
						return;
					m_divaController.DivaPlayLeaveAlone();
				}
			}
			else
				AloneCounter = 0;
			if(m_divaController.IsPlayingIdleMouth())
			{
				AloneCounter += Time.deltaTime;
			}
		}

		//// RVA: 0x170B268 Offset: 0x170B268 VA: 0x170B268
		private bool CheckTutorialFunc_OfferDetail(TutorialConditionId conditionId)
		{
			return !GameManager.Instance.IsTutorial && conditionId == TutorialConditionId.Condition66;
		}

		//// RVA: 0x170B328 Offset: 0x170B328 VA: 0x170B328
		private bool CheckTutorialFunc_GetValkyrie(TutorialConditionId conditionId)
		{
			return !GameManager.Instance.IsTutorial && conditionId == TutorialConditionId.Condition67;
		}

		//// RVA: 0x170B3E8 Offset: 0x170B3E8 VA: 0x170B3E8
		private bool CheckTutorialFunc_OpenDivaOffer(TutorialConditionId conditionId)
		{
			return !GameManager.Instance.IsTutorial && conditionId == TutorialConditionId.Condition68;
		}

		//// RVA: 0x170B4A8 Offset: 0x170B4A8 VA: 0x170B4A8
		//private bool IsEnableOfferDetail() { }

		//// RVA: 0x170B4B0 Offset: 0x170B4B0 VA: 0x170B4B0
		protected void CheckSnsNotice()
		{
			if (!BIFNGFAIEIL.HHCJCDFCLOB.DNFPMBFNDCA())
				return;
			int snsId = BIFNGFAIEIL.HHCJCDFCLOB.FGGDEKAJCIF();
			if (snsId == 0)
				return;
			MenuScene.Instance.ShowSnsNotice(snsId, () =>
			{
				//0x170B984
				if(m_divaController != null)
				{
					m_divaController.IsAloneMotion = false;
					m_divaController.DivaStopVoice();
				}
				HomeArgs arg = new HomeArgs();
				arg.SetOpenSns(true);
				MenuScene.Instance.Mount(TransitionUniqueId.HOME, arg, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
			});
			BIFNGFAIEIL.HHCJCDFCLOB.ALIANOFCAEI();
		}

		//// RVA: 0x170A164 Offset: 0x170A164 VA: 0x170A164
		//private void OfferEnterAnimationStart() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6FC04C Offset: 0x6FC04C VA: 0x6FC04C
		//// RVA: 0x170B634 Offset: 0x170B634 VA: 0x170B634
		private IEnumerator BOOTAnimation()
		{
			//0x170BD94
			IsBootLoading = true;
			GameManager.Instance.StartCoroutineWatched(LoadLayoutBoot(() =>
			{
				//0x170BB00
				IsBootLoading = false;
			}));
			while (IsBootLoading)
				yield return null;
			if(layoutBoot != null)
			{
				layoutBoot.transform.SetParent(AnimCanvas, false);
				yield return null;
				layoutBoot.transform.position = Vector3.zero;
				layoutBoot.transform.SetAsFirstSibling();
				layoutBoot.In();
				SoundManager.Instance.bgmPlayer.Stop();
			}
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_ADV_TOUCH);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FC0C4 Offset: 0x6FC0C4 VA: 0x6FC0C4
		//// RVA: 0x170B6E0 Offset: 0x170B6E0 VA: 0x170B6E0
		public IEnumerator LoadLayoutBoot(Action callback)
		{
			string bundleName; // 0x18
			Font systemFont; // 0x1C
			AssetBundleLoadLayoutOperationBase operation; // 0x20

			//0x170EFFC
			if(layoutBoot == null)
			{
				bundleName = "ly/146.xab";
				systemFont = GameManager.Instance.GetSystemFont();
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_start_vfo_layout_root");
				yield return Co.R(operation);
				yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
				{
					//0x170BB0C
					instance.transform.SetParent(AnimCanvas, false);
					layoutBoot = instance.GetComponent<LayoutOfferBoot>();
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				while (layoutBoot == null)
					yield return null;
				while (!layoutBoot.IsLoaded())
					yield return null;
				layoutBoot.gameObject.SetActive(false);
			}
			//LAB_0170f354
			if (callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FC13C Offset: 0x6FC13C VA: 0x6FC13C
		//// RVA: 0x170A734 Offset: 0x170A734 VA: 0x170A734
		private IEnumerator Co_ExitAction(bool _isGotoHome)
		{
			//0x170E1E4
			GameManager.Instance.CloseSnsNotice();
			IsExitAction = true;
			while (!m_divaController.IsModelLoad)
				yield return null;
			while (GameManager.Instance.fullscreenFader.isFading)
				yield return null;
			while (!IsEnterCorutineEnd)
				yield return null;
			m_controller.layoutAllLeave();
			m_divaController.DivaLeaveCamera();
			yield return null;
			while (m_controller.IsAllLayoutIsPlaying())
				yield return null;
			while (m_divaController.IsLeaving)
				yield return null;
			m_controller.DestroyScene();
			if(_isGotoHome)
			{
				m_controller.DestroyLayout();
				m_divaController.Release();
				yield return null;
				yield return Resources.UnloadUnusedAssets();
				IsAssetLoaded = false;
			}
			//LAB_0170e5c8
			while (KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
			IsExitAction = false;
		}

		//// RVA: 0x170B7C8 Offset: 0x170B7C8 VA: 0x170B7C8
		private void OrderButton()
		{
			return;
		}

		//// RVA: 0x170B7CC Offset: 0x170B7CC VA: 0x170B7CC
		private void ProgressButton()
		{
			return;
		}

		//// RVA: 0x170B7D0 Offset: 0x170B7D0 VA: 0x170B7D0
		private void CompleteButton()
		{
			return;
		}

		//// RVA: 0x170B7D4 Offset: 0x170B7D4 VA: 0x170B7D4
		public static void GetMiddleTime(int totalSec, out int hours, out int minutes, out int seconds, bool IsSec = false)
		{
			if(!IsSec)
			{
				totalSec = totalSec / 1000;
			}
			hours = totalSec / 3600;
			minutes = totalSec - hours * 3600;
			seconds = totalSec - hours * 3600 - minutes * 60;
		}
	}
}
