using mcrs;
using System;
using System.Collections;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;

namespace XeApp.Game.Menu
{
	public class OfferTransformationScene : TransitionRoot
	{
		public readonly string AssetPath = "mn/of/go.xab"; // 0x48
		[SerializeField]
		private CharTouchHitCheck m_hitCheck_1; // 0x4C
		[SerializeField]
		private CharTouchHitCheck m_hitCheck_2; // 0x50
		private GameObject m_viewValkyrieModeObj; // 0x54
		private ViewScreenValkyrie m_viewValkyrie; // 0x58
		private HEFCLPGPMLK.ANKPCIEKPAH ValkyrieData; // 0x5C
		private bool IsTransfrom; // 0x60
		private OfferInfoLayout m_InfoLayout; // 0x64
		private OfferTransformationLayout m_layout; // 0x68
		private OfferTouchLead m_touchLeadLayout; // 0x6C
		private OfferHaveItemCheck itemCheckButton; // 0x70
		private HEFCLPGPMLK m_view; // 0x74
		private HEFCLPGPMLK.AAOPGOGGMID m_offerInfo; // 0x78
		private OfferSortiePilotLayout m_pilotCutIn; // 0x7C
		private OfferSortieLayout m_sortieLayout; // 0x80
		private bool IsAssetLoaded; // 0x84
		private bool m_IsSortie; // 0x85
		private int platoonId; // 0x88
		private KDHGBOOECKC.JNHGHDKLDEM m_transFormationData; // 0x8C
		private OfferSortCamAnimController cameraAnim; // 0x90
		private bool m_IsTutorial; // 0x94
		private int form; // 0x98
		private GameObject m_EffectPrefab; // 0x9C
		private GameObject m_EffectInstance; // 0xA0
		private bool m_IsLoadEffect; // 0xA4
		private bool IsCreateValkyrie; // 0xA5

		// RVA: 0x171426C Offset: 0x171426C VA: 0x171426C
		private void Awake()
		{
			IsReady = true;
		}

		// RVA: 0x1714278 Offset: 0x1714278 VA: 0x1714278
		private void Start()
		{
			ILCCJNDFFOB.HHCJCDFCLOB.BKLNHBHDDEJ(JpStringLiterals.StringLiteral_18944);
		}

		// RVA: 0x1714324 Offset: 0x1714324 VA: 0x1714324
		private void Update()
		{
			return;
		}

		// RVA: 0x1714328 Offset: 0x1714328 VA: 0x1714328 Slot: 16
		protected override void OnPreSetCanvas()
		{
			base.OnPreSetCanvas();
			m_IsSortie = false;
			OfferTransformationArgs arg = Args as OfferTransformationArgs;
			if(arg != null)
			{
				ValkyrieData = arg.valData;
				m_InfoLayout = arg.offerInfo;
				platoonId = arg.plattonId;
				m_hitCheck_1.OnClickCallback = () =>
				{
					//0x1716964
					if (!m_IsSortie && !m_IsTutorial)
						OnClickTransformation();
				};
				m_hitCheck_2.OnClickCallback = () =>
				{
					//0x1716980
					if (!m_IsSortie && !m_IsTutorial)
						OnClickTransformation();
				};
				itemCheckButton = arg.itemCheckButton;
			}
			m_view = new HEFCLPGPMLK();
			form = 0;
			m_offerInfo = m_InfoLayout.ViewOfferInfo;
			if(m_EffectPrefab == null)
			{
				this.StartCoroutineWatched(Co_LoadEffect());
			}
			this.StartCoroutineWatched(AllAssetLoad());
		}

		// RVA: 0x1714688 Offset: 0x1714688 VA: 0x1714688 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return IsAssetLoaded;
		}

		// RVA: 0x1714690 Offset: 0x1714690 VA: 0x1714690 Slot: 18
		protected override void OnPostSetCanvas()
		{
			m_touchLeadLayout.AnimLoopStart();
			m_layout.Enter();
			itemCheckButton.Enter();
			itemCheckButton.transform.SetAsLastSibling();
			this.StartCoroutineWatched(Co_CreateValkyrie());
			base.OnPostSetCanvas();
		}

		// RVA: 0x1714800 Offset: 0x1714800 VA: 0x1714800 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			return IsCreateValkyrie;
		}

		// RVA: 0x1714808 Offset: 0x1714808 VA: 0x1714808 Slot: 21
		protected override void OnOpenScene()
		{
			base.OnOpenScene();
			this.StartCoroutineWatched(Co_Tuto());
		}

		// RVA: 0x17148C4 Offset: 0x17148C4 VA: 0x17148C4 Slot: 12
		protected override void OnStartExitAnimation()
		{
			base.OnStartExitAnimation();
			if (m_viewValkyrieModeObj == null)
				return;
			m_layout.Leave();
			itemCheckButton.Leave();
			if(form == 0)
			{
				IsTransfrom = true;
				this.StartCoroutineWatched(AllRelease(() =>
				{
					//0x1716A48
					IsTransfrom = false;
				}));
			}
			else
			{
				form = 0;
				m_viewValkyrie.ChangeFormType(0, true);
				SoundManager.Instance.sePlayerMenu.Play((int)cs_se_boot.SE_BTN_004);
				IsTransfrom = true;
				this.StartCoroutineWatched(m_viewValkyrie.Co_WaitEnableTransformation(() =>
				{
					//0x171699C
					this.StartCoroutineWatched(AllRelease(() =>
					{
						//0x1716A3C
						IsTransfrom = false;
					}));
				}));
			}
		}

		// RVA: 0x1714B94 Offset: 0x1714B94 VA: 0x1714B94 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !IsTransfrom;
		}

		// RVA: 0x1714BA8 Offset: 0x1714BA8 VA: 0x1714BA8 Slot: 14
		protected override void OnDestoryScene()
		{
			base.OnDestoryScene();
			GC.Collect();
		}

		// RVA: 0x1714C34 Offset: 0x1714C34 VA: 0x1714C34 Slot: 15
		protected override void OnDeleteCache()
		{
			base.OnDeleteCache();
			if(m_viewValkyrieModeObj != null)
			{
				m_viewValkyrie.ValkyrieAllRelease();
				Destroy(m_viewValkyrieModeObj);
				m_viewValkyrieModeObj = null;
				m_viewValkyrie = null;
			}
			Destroy(m_EffectInstance);
			m_EffectPrefab = null;
			m_EffectInstance = null;
		}

		//// RVA: 0x1714D84 Offset: 0x1714D84 VA: 0x1714D84
		private void OnClickTransformation()
		{
			if(m_viewValkyrieModeObj != null)
			{
				if(m_viewValkyrie != null)
				{
					if(m_viewValkyrie.IsShow())
					{
						if(m_touchLeadLayout != null)
						{
							m_touchLeadLayout.Leave();
						}
						if(!MenuScene.Instance.DirtyChangeScene)
						{
							form++;
							if (form > 2)
								form -= 3;
							m_InfoLayout.StartChengeEnemyPower(platoonId, false, form, true);
							BOPFPIHGJMD.ADMNKELOLPN a1 = KDHGBOOECKC.HHCJCDFCLOB.KJGAJBOBIHK(m_offerInfo.FGHGMHPNEMG_Category, m_offerInfo.PPFNGGCBJKC);
							m_layout.SettingText(KDHGBOOECKC.HHCJCDFCLOB.KGLLKKCFDEL((FKGMGBHBNOC.HPJOCKGKNCC_Form)form, a1, BOPFPIHGJMD.HBJMIJIOCAM.FMHLGHDKJBC_0) * KDHGBOOECKC.HHCJCDFCLOB.LBDENPEGONA(platoonId, BOPFPIHGJMD.HBJMIJIOCAM.FMHLGHDKJBC_0) / 100,
								KDHGBOOECKC.HHCJCDFCLOB.KGLLKKCFDEL((FKGMGBHBNOC.HPJOCKGKNCC_Form)form, a1, BOPFPIHGJMD.HBJMIJIOCAM.JIOPJDJBLFK_1) * KDHGBOOECKC.HHCJCDFCLOB.LBDENPEGONA(platoonId, BOPFPIHGJMD.HBJMIJIOCAM.JIOPJDJBLFK_1) / 100);
							m_layout.SetTransformation(form);
							m_layout.LowPowerIconEnable(platoonId, form);
							m_viewValkyrie.ChangeFormType(form, true);
							SoundManager.Instance.sePlayerMenu.Play((int)cs_se_boot.SE_BTN_004);
							IsTransfrom = true;
							this.StartCoroutineWatched(m_viewValkyrie.Co_WaitEnableTransformation(() =>
							{
								//0x1716A54
								IsTransfrom = false;
							}));
							return;
						}
					}
				}
			}
		}

		//// RVA: 0x17152A4 Offset: 0x17152A4 VA: 0x17152A4
		private void AnimationStart()
		{
			if (PGIGNJDPCAH.MNANNMDBHMP(() =>
			{
				//0x1716E30
				MenuScene.Instance.GotoLoginBonus();
			}, () =>
			{
				//0x1716ECC
				MenuScene.Instance.GotoTitle();
			}))
			{ 
				return;
			}
			MenuScene.Instance.InputDisable();
			PGIGNJDPCAH.NNOBACMJHDM(PGIGNJDPCAH.FELLIEJEPIJ.LPBDIINNFEE_5);
			m_InfoLayout.Leave();
			m_layout.Leave();
			m_touchLeadLayout.Leave();
			itemCheckButton.Leave();
			itemCheckButton.transform.SetParent(transform.parent, false);
			MenuScene.Instance.HeaderMenu.MenuStack.LeaveBackButton(false);
			MenuScene.Instance.HeaderMenu.MenuStack.LeaveLabel(false);
			MenuScene.Instance.HelpButton.TryHide(TransitionList.Type.OFFER_SELECT);
			JDDGPJDKHNE.HHCJCDFCLOB.NFNLGGHMEAM();
			JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = true;
			if(KDHGBOOECKC.HHCJCDFCLOB != null)
			{
				KDHGBOOECKC.HHCJCDFCLOB.NKHGLFOBOJD(KDHGBOOECKC.HHCJCDFCLOB.CNNICINEKBJ().FGHGMHPNEMG, KDHGBOOECKC.HHCJCDFCLOB.CNNICINEKBJ().MLDPDLPHJPM, platoonId, form);
				ILCCJNDFFOB.HHCJCDFCLOB.OEGCKACJMPM(KDHGBOOECKC.HHCJCDFCLOB.CNNICINEKBJ().FGHGMHPNEMG, KDHGBOOECKC.HHCJCDFCLOB.CNNICINEKBJ().MLDPDLPHJPM);
			}
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer != null)
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.ILMPHFPFLJE(BOPFPIHGJMD.PDLKAKEABDP.HFKNIAGOFKC_1, true);
			this.StartCoroutineWatched(Animation());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FC8F4 Offset: 0x6FC8F4 VA: 0x6FC8F4
		//// RVA: 0x1715998 Offset: 0x1715998 VA: 0x1715998
		private IEnumerator Animation()
		{
			//0x1718074
			bool IsSaveing = true;
			CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
			{
				//0x171713C
				JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
				IsSaveing = false;
			}, () =>
			{
				//0x1716F68
				JDDGPJDKHNE.HHCJCDFCLOB.FOKEGEOKGDG();
				JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
				SoundManager.Instance.sePlayerMenu.Stop();
				MenuScene.Instance.GotoTitle();
			}, null);
			while(m_layout.IsPlaying())
				yield return null;
			if(cameraAnim == null)
			{
				m_viewValkyrie.ValkyrieCamera.GetComponent<ViewModeCameraMan>().IsInfluence = false;
				cameraAnim = m_viewValkyrie.ValkyrieCamera.gameObject.AddComponent<OfferSortCamAnimController>();
				yield return Co.R(cameraAnim.Co_loadAssets(form, () =>
				{
					//0x1717174
					m_pilotCutIn.Enter();
					SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_VFOPS_002);
					SoundManager.Instance.voPilot.Play(PilotVoicePlayer.VoiceCategory.Offer_Sortie, 0);
				}));
			}
			while(m_pilotCutIn.IsPlaying())
				yield return null;
			yield return null;
			#if !UNITY_ANDROID
			SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_VFOPS_004); // This will cancel the SE_VFOPS_002 whichis more important?
			#endif
			if(cameraAnim != null)
			{
				while(cameraAnim.IsPlayingAnim())
					yield return null;
			}
			//LAB_0171845c
			SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_VFOPS_003);
			m_pilotCutIn.SortieLeave();
			m_sortieLayout.AnimStart();
			yield return null;
			yield return null;
			ValkyrieRelease();
			while(IsSaveing)
				yield return null;
			while(!m_sortieLayout.IsSortieEnd)
				yield return null;
			m_sortieLayout.AnimLeave();
			yield return null;
			while(m_sortieLayout.IsPlaying())
				yield return null;
			SoundManager.Instance.sePlayerMenu.Stop();
			yield return Co.R(AllRelease(null));
			MenuScene.Instance.InputEnable();
			MenuScene.Instance.Mount(TransitionUniqueId.OFFERSELECT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FC96C Offset: 0x6FC96C VA: 0x6FC96C
		//// RVA: 0x17145FC Offset: 0x17145FC VA: 0x17145FC
		private IEnumerator AllAssetLoad()
		{
			string bundleName; // 0x18
			XeSys.FontInfo systemFont; // 0x1C
			KDLPEDBKMID install; // 0x20
			bool InstallCheck; // 0x24

			//0x17172AC
			IsAssetLoaded = false;
			bundleName = "ly/141.xab";
			systemFont = GameManager.Instance.GetSystemFont();
			yield return AssetBundleManager.LoadUnionAssetBundle(bundleName);
			yield return Co.R(Co_LoadAssetsTransformationLayout(bundleName, systemFont));
			yield return Co.R(Co_LoadAssetsTouchLeadLayout(bundleName, systemFont));
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			bundleName = "ly/147.xab";
			yield return AssetBundleManager.LoadUnionAssetBundle(bundleName);
			yield return Co.R(Co_LoadAssetsSortieLayout(bundleName, systemFont));
			yield return Co.R(Co_LoadAssetsPilotCutinLayout(bundleName, systemFont));
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			while (!m_layout.IsLoaded())
				yield return null;
			while (!m_touchLeadLayout.IsLoaded())
				yield return null;
			while (!m_sortieLayout.IsLoaded())
				yield return null;
			while (!m_pilotCutIn.IsLoaded())
				yield return null;
			KDHGBOOECKC.NKMCJCAJIGD d1 = KDHGBOOECKC.HHCJCDFCLOB.CNNICINEKBJ();
			KDHGBOOECKC.JNHGHDKLDEM d = new KDHGBOOECKC.JNHGHDKLDEM();
			m_transFormationData = d.JGJOAFJPIIH(d1.FGHGMHPNEMG, d1.MLDPDLPHJPM);
			m_transFormationData.FMHLGHDKJBC = KDHGBOOECKC.HHCJCDFCLOB.LBDENPEGONA(platoonId, BOPFPIHGJMD.HBJMIJIOCAM.FMHLGHDKJBC_0);
			m_transFormationData.JIOPJDJBLFK = KDHGBOOECKC.HHCJCDFCLOB.LBDENPEGONA(platoonId, BOPFPIHGJMD.HBJMIJIOCAM.JIOPJDJBLFK_1);
			m_layout.initialize(m_transFormationData, m_offerInfo, platoonId);
			m_layout.SetSortieCallback(() =>
			{
				//0x1717254
				AnimationStart();
				m_IsSortie = true;
			});
			m_layout.SetTransformation(0);
			m_InfoLayout.StartChengeEnemyPower(platoonId, false, form, true);
			m_layout.LowPowerIconEnable(platoonId, form);
			m_pilotCutIn.SetUp(ValkyrieData.PFGJJLGLPAC_PilotId, true);
			m_sortieLayout.Hide();
			m_pilotCutIn.Hide();
			yield return null;
			while (m_layout.IsImageLoading())
				yield return null;
			while (!m_IsLoadEffect)
				yield return null;
			install = KDLPEDBKMID.HHCJCDFCLOB;
			InstallCheck = false;
			InstallCheck = install.BDOFDNICMLC_StartInstallIfNeeded(AssetPath);
			install.OFLDICKPNFD(true, () =>
			{
				//0x1717098
				MenuScene.Instance.GotoTitle();
			});
			yield return null;
			if (InstallCheck)
			{
				while (install.LNHFLJBGGJB_IsRunning)
					yield return null;
			}
			//LAB_017179d8;
			IsAssetLoaded = true;
			bool IsCueChenged = false;
			SoundManager.Instance.voPilot.RequestChangeCueSheet_offer(ValkyrieData.PFGJJLGLPAC_PilotId, () =>
			{
				//0x171729C
				IsCueChenged = true;
			});
			while (!IsCueChenged)
				yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FC9E4 Offset: 0x6FC9E4 VA: 0x6FC9E4
		//// RVA: 0x1715A64 Offset: 0x1715A64 VA: 0x1715A64
		private IEnumerator Co_LoadAssetsSortieLayout(string bundleName, XeSys.FontInfo font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x1718D88
			if(m_sortieLayout == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sortie_vfo_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0x1716A60
					instance.transform.SetParent(transform, false);
					m_sortieLayout = instance.GetComponent<OfferSortieLayout>();
				}));
				operation = null;
			}
			else
			{
				m_sortieLayout.transform.SetParent(transform, false);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FCA5C Offset: 0x6FCA5C VA: 0x6FCA5C
		//// RVA: 0x1715B44 Offset: 0x1715B44 VA: 0x1715B44
		private IEnumerator Co_LoadAssetsPilotCutinLayout(string bundleName, XeSys.FontInfo font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x1718AB4
			if(m_pilotCutIn == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sortie_vfo_pilot_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0x1716B30
					instance.transform.SetParent(transform, false);
					m_pilotCutIn = instance.GetComponent<OfferSortiePilotLayout>();
				}));
				operation = null;
			}
			else
			{
				m_pilotCutIn.transform.SetParent(transform, false);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FCAD4 Offset: 0x6FCAD4 VA: 0x6FCAD4
		//// RVA: 0x1715C24 Offset: 0x1715C24 VA: 0x1715C24
		private IEnumerator Co_LoadAssetsTransformationLayout(string bundleName, XeSys.FontInfo font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x1719330
			if(m_layout == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_vfo_form_01_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0x1716C00
					instance.transform.SetParent(transform, false);
					m_layout = instance.GetComponent<OfferTransformationLayout>();
				}));
				operation = null;
			}
			else
			{
				m_layout.transform.SetParent(transform, false);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FCB4C Offset: 0x6FCB4C VA: 0x6FCB4C
		//// RVA: 0x1715D04 Offset: 0x1715D04 VA: 0x1715D04
		private IEnumerator Co_LoadAssetsTouchLeadLayout(string bundleName, XeSys.FontInfo font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x171905C
			if(m_touchLeadLayout == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_vfo_notice_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0x1716CD0
					instance.transform.SetParent(transform, false);
					m_touchLeadLayout = instance.GetComponent<OfferTouchLead>();
				}));
				operation = null;
			}
			else
			{
				m_layout.transform.SetParent(transform, false);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FCBC4 Offset: 0x6FCBC4 VA: 0x6FCBC4
		//// RVA: 0x1714838 Offset: 0x1714838 VA: 0x1714838
		public IEnumerator Co_Tuto()
		{
			//0x17199BC
			if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.MLBBKNLPBBD_HasShowTuto(BOPFPIHGJMD.PDLKAKEABDP.HFKNIAGOFKC_1))
			{
				m_IsTutorial = true;
				yield return Co.R(TutorialProc.Co_OffeReleaseTutorial(InputLimitButton.Delegate, null, () =>
				{
					//0x1716DA0
					m_IsTutorial = false;
				}, BasicTutorialMessageId.Id_OfferTransFrom, false, null, null));
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FCC3C Offset: 0x6FCC3C VA: 0x6FCC3C
		//// RVA: 0x1714774 Offset: 0x1714774 VA: 0x1714774
		private IEnumerator Co_CreateValkyrie()
		{
			//0x1718960
			IsCreateValkyrie = false;
			CreateValkyrie();
			yield return Co.R(ValkyrieChengeMonitoring());
			IsCreateValkyrie = true;
		}

		//// RVA: 0x1715E24 Offset: 0x1715E24 VA: 0x1715E24
		private void CreateValkyrie()
		{
			if(m_viewValkyrieModeObj == null)
			{
				HEFCLPGPMLK.ANKPCIEKPAH h = m_view.FFGHIOAOABE(platoonId);
				m_viewValkyrieModeObj = ViewScreenValkyrie.Create(h == null || h.LLOBHDMHJIG_Id < 2 ? 1 : h.LLOBHDMHJIG_Id, 0, () =>
				{
					//0x1716DAC
					if (m_EffectInstance == null)
						return;
					m_EffectInstance.SetActive(true);
					MenuScene.Instance.InputDisable();
				}, () =>
				{
					//0x1716DB0
					if (m_EffectInstance == null)
						return;
					m_EffectInstance.SetActive(false);
					MenuScene.Instance.InputEnable();
				}, true);
				if(m_viewValkyrie == null)
				{
					m_viewValkyrie = m_viewValkyrieModeObj.GetComponent<ViewScreenValkyrie>();
				}
			}
		}

		//// RVA: 0x1716030 Offset: 0x1716030 VA: 0x1716030
		//private bool IsLoadedValkyrie() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6FCCB4 Offset: 0x6FCCB4 VA: 0x6FCCB4
		//// RVA: 0x171615C Offset: 0x171615C VA: 0x171615C
		private IEnumerator ValkyrieChengeMonitoring()
		{
			//0x1719C04
			MenuScene.Instance.RaycastDisable();
			yield return null;
			while (m_viewValkyrie.IsLoading)
				yield return null;
			yield return null;
			MenuScene.Instance.RaycastEnable();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FCD2C Offset: 0x6FCD2C VA: 0x6FCD2C
		//// RVA: 0x1714570 Offset: 0x1714570 VA: 0x1714570
		private IEnumerator Co_LoadEffect()
		{
			string bundleName; // 0x14
			string assetName; // 0x18
			AssetBundleLoadAllAssetOperationBase operation; // 0x1C	//0x1719604

			//0x1719604
			m_IsLoadEffect = false;
			bundleName = "ef/cmn.xab";
			assetName = "model_loading";
			operation = AssetBundleManager.LoadAllAssetAsync(bundleName);
			yield return operation;
			m_EffectPrefab = operation.GetAsset<GameObject>(assetName);
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			if(m_EffectInstance == null)
			{
				m_EffectInstance = Instantiate(m_EffectPrefab, new Vector3(0, 1, 0), m_EffectPrefab.transform.rotation);
			}
			m_EffectInstance.SetActive(false);
			m_IsLoadEffect = true;
		}

		//// RVA: 0x1716228 Offset: 0x1716228 VA: 0x1716228
		//public void ShowLoadingEffect() { }

		//// RVA: 0x1716334 Offset: 0x1716334 VA: 0x1716334
		//public void HideLoadingEffect() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6FCDA4 Offset: 0x6FCDA4 VA: 0x6FCDA4
		//// RVA: 0x1714AEC Offset: 0x1714AEC VA: 0x1714AEC
		private IEnumerator AllRelease(Action endcallBack)
		{
			//0x1717E70
			LayoutRelease();
			ValkyrieRelease();
			yield return null;
			yield return Resources.UnloadUnusedAssets();
			yield return null;
			GC.Collect();
			if (endcallBack != null)
				endcallBack();
		}

		//// RVA: 0x1716460 Offset: 0x1716460 VA: 0x1716460
		private void ValkyrieRelease()
		{
			if(m_viewValkyrieModeObj != null)
			{
				m_viewValkyrie.ValkyrieAllRelease();
				DestroyImmediate(m_viewValkyrieModeObj);
				m_viewValkyrieModeObj = null;
				m_viewValkyrie = null;
			}
			if(m_EffectInstance != null)
			{
				DestroyImmediate(m_EffectInstance.gameObject);
				m_EffectPrefab = null;
				m_EffectInstance = null;
			}
		}

		//// RVA: 0x171660C Offset: 0x171660C VA: 0x171660C
		private void LayoutRelease()
		{
			if(m_layout != null)
			{
				DestroyImmediate(m_layout.gameObject);
			}
			if(m_touchLeadLayout != null)
			{
				DestroyImmediate(m_touchLeadLayout.gameObject);
			}
			if(m_pilotCutIn != null)
			{
				DestroyImmediate(m_pilotCutIn.gameObject);
			}
			if(m_sortieLayout != null)
			{
				DestroyImmediate(m_sortieLayout.gameObject);
			}
			m_touchLeadLayout = null;
			m_pilotCutIn = null;
			m_sortieLayout = null;
		}
		
		//[CompilerGeneratedAttribute] // RVA: 0x6FCE6C Offset: 0x6FCE6C VA: 0x6FCE6C
		//// RVA: 0x1716A54 Offset: 0x1716A54 VA: 0x1716A54
		//private void <OnClickTransformation>b__38_0() { }
	}
}
