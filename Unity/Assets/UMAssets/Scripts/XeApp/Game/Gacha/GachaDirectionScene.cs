using XeApp.Core;
using System;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Menu;
using System.Collections.Generic;
using XeSys;
using System.Collections;
using mcrs;
using XeSys.uGUI;

namespace XeApp.Game.Gacha
{
	public class GachaDirectionScene : MainSceneBase
	{
		[Serializable]
		private class Setting
		{
			[SerializeField]
			internal GachaDirectionQuartzTable quartzTable; // 0x8
			[SerializeField]
			internal GachaDirectionOrbTable orbTable; // 0xC
		}

		[SerializeField]
		private Canvas m_mainCanvas; // 0x28
		[SerializeField]
		private GraphicRaycaster m_raycaster; // 0x2C
		[SerializeField]
		private Transform m_mainCanvasRoot; // 0x30
		[SerializeField]
		private GachaDirectionObject m_modelObject; // 0x34
		[SerializeField]
		private GachaDirectionCamera m_cameraObject; // 0x38
		[SerializeField]
		private Setting m_settingRegular; // 0x3C
		[SerializeField]
		private Setting m_settingTutorial; // 0x40
		private bool m_isChangedCueSheet; // 0x44
		private GachaDirectionResource m_resource; // 0x48
		private GachaDirectionHUD m_mainHud; // 0x4C
		private GachaResultRoot m_resultUi; // 0x50
		private GachaResultButtonSet m_resultButtonUi; // 0x54
		private CommonMenuTop m_userInfoUi; // 0x58
		private SceneStatePopupSetting m_sceneStatePopup; // 0x5C
		private List<NewMarkIcon> m_newMarkDecos; // 0x60
		private DenominationManager m_denomControl; // 0x64
		private GraphicRaycaster m_rayCaster; // 0x68
		private IFBCGCCJBHI m_viewPlayerStatus; // 0x6C

		private bool loadedModelResource { get; set; } // 0x70
		//private bool toSceneEnter { get; } 0x984DD4
		private bool isSkippable { get { return !m_resource.isLoading; } } //0x984DF4
		private bool inputEnable { get { return m_rayCaster.enabled; } set { m_rayCaster.enabled = value; } } //0x984E24 0x984E50
		private bool activeUserInfoUpdate { get; set; } // 0x71
		private Setting currentSetting { get {
				if(GameManager.Instance != null && GameManager.Instance.IsTutorial)
				{
					return m_settingTutorial;
				}
				return m_settingRegular;
			} } //0x984E94

		// RVA: 0x98504C Offset: 0x98504C VA: 0x98504C Slot: 9
		protected override void DoAwake()
		{
			enableFade = true;
			m_resource = gameObject.AddComponent<GachaDirectionResource>();
			m_denomControl = DenominationManager.Create(transform);
			if (!SystemManager.isLongScreenDevice)
				return;
			Camera[] cams = GetComponentsInChildren<Camera>(true);
			Array.ForEach(cams, (Camera x) =>
			{
				//0x98A85C
				if(x.name == "Main Camera")
				{
					FlexibleCameraChanger.AddComponent(x.gameObject, true, false, 0, 0);
				}
			});
		}

		// RVA: 0x985294 Offset: 0x985294 VA: 0x985294 Slot: 10
		protected override void DoStart()
		{
			loadedModelResource = false;
			this.StartCoroutineWatched(Co_LoadModelResource());
			m_isChangedCueSheet = false;
			SoundManager.Instance.RequestEntryGachaCueSheet(() =>
			{
				//0x98A5A0
				m_isChangedCueSheet = true;
			});
			SoundManager.Instance.bgmPlayer.Play(BgmPlayer.MENU_BGM_ID_BASE + 4, 1);
			m_sceneStatePopup = new SceneStatePopupSetting();
			m_sceneStatePopup.SetParent(transform);
			m_sceneStatePopup.PageSave = SceneStatusParam.PageSave.Pickup;
			m_sceneStatePopup.WindowSize = SizeType.Large;
			m_viewPlayerStatus = new IFBCGCCJBHI();
			m_viewPlayerStatus.KHEKNNFCAOI();
		}

		// RVA: 0x985508 Offset: 0x985508 VA: 0x985508 Slot: 12
		protected override bool DoUpdateEnter()
		{
			if(loadedModelResource && m_isChangedCueSheet)
			{
				GachaUtility.RegisterLegalDesc(OnClickLegalDescButton);
				StartDirection(false);
				return true;
			}
			return false;
		}

		// RVA: 0x985720 Offset: 0x985720 VA: 0x985720 Slot: 13
		protected override void DoUpdateMain()
		{
			base.DoUpdateMain();
			if (m_modelObject.canAllSkip)
				m_mainHud.ShowAllSkipButton();
			else
				m_mainHud.HideAllSkipButton();
			if (!activeUserInfoUpdate)
				return;
			m_viewPlayerStatus.FBANBDCOEJL();
			ApplyUserInfo(m_viewPlayerStatus);
		}

		// RVA: 0x985AE4 Offset: 0x985AE4 VA: 0x985AE4 Slot: 14
		protected override bool DoUpdateLeave()
		{
			GachaUtility.UnregisterLegalDesc();
			SoundManager.Instance.bgmPlayer.Stop();
			for(int i = 0; i < m_newMarkDecos.Count; i++)
			{
				m_newMarkDecos[i].Release();
			}
			return base.DoUpdateLeave();
		}

		//// RVA: 0x9857C0 Offset: 0x9857C0 VA: 0x9857C0
		private void ApplyUserInfo(IFBCGCCJBHI playerStatus)
		{
			m_userInfoUi.SetLevelLimit(playerStatus.NMCICIHMOCM_PlayerLevelLimit);
			m_userInfoUi.ChangeEnergyValue(playerStatus.EPNALMONMHB_CurEnergy, playerStatus.POKDILOKODG_MaxEnergy);
			m_userInfoUi.ChangeRemainTime(playerStatus.CMCHABFEOHH_RemainTime);
			m_userInfoUi.ChangeLevelValue(playerStatus.DMBFOMLCGBG_ChangeLevelValue);
			m_userInfoUi.ChangeEXPValue(playerStatus.OPBHNBECFII_CurExp, playerStatus.PBGFIOONCMB_MaxExp);
			m_userInfoUi.ChangeCurrencyValue(playerStatus.OIOFGIBDOPI_CurrencyNonPaid, playerStatus.FNCPAEFEECO_CurrencyPaid);
			m_userInfoUi.ChangeMedalValue(playerStatus.AHHGKGOPGDE_MedalMonth, playerStatus.GBIKGLELKEO_MedalValue);
			m_userInfoUi.ChangeUtaRateValue(playerStatus.ILELGGCCGMJ_UtaGrade, playerStatus.HDBFOIAGPJK_UtaRank);
		}

		//// RVA: 0x985CD4 Offset: 0x985CD4 VA: 0x985CD4
		private void ShowSceneStatusPopup(GCIJNCFDNON_SceneInfo sceneData, DFKGGBMFFGB_PlayerInfo playerData, Action onClose)
		{
			m_sceneStatePopup.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			m_sceneStatePopup.Scene = sceneData;
			m_sceneStatePopup.PlayerData = playerData;
			m_sceneStatePopup.IsOpenAnimeMoment = false;
			m_sceneStatePopup.IsFriend = false;
			m_sceneStatePopup.IsDiableLuckyLeaf = true;
			m_sceneStatePopup.TitleText = sceneData.OPFGFINHFCE_SceneName;
			if(sceneData.OPFGFINHFCE_SceneName == "")
			{
				m_sceneStatePopup.TitleText = GameMessageManager.GetSceneCardName(sceneData.BCCHOBPJJKE_SceneId, sceneData.JPIPENJGGDD_NumBoard, "");
			}
			PopupWindowManager.Show(m_sceneStatePopup, (PopupWindowControl control, PopupButton.ButtonType label, PopupButton.ButtonLabel type) =>
			{
				//0x98A9C0
				if(onClose != null)
					onClose();
			}, null, null, null);
		}

		//// RVA: 0x98606C Offset: 0x98606C VA: 0x98606C
		private void OnTimeLimit()
		{
			JHHBAFKMBDL.HHCJCDFCLOB.HMIHFLGLHBA(OnGachaNetError);
		}

		//// RVA: 0x986154 Offset: 0x986154 VA: 0x986154
		private bool CheckDatelineAndAssetUpdate()
		{
			return PGIGNJDPCAH.MNANNMDBHMP(() =>
			{
				//0x98A5AC
				this.StartCoroutineWatched(Co_GotoLoginBonus());
			}, () =>
			{
				//0x98A5D0
				this.StartCoroutineWatched(Co_GotoTitle());
			});
		}

		//// RVA: 0x9854D8 Offset: 0x9854D8 VA: 0x9854D8
		//private void LoadAllResources() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6C4A98 Offset: 0x6C4A98 VA: 0x6C4A98
		//// RVA: 0x986240 Offset: 0x986240 VA: 0x986240
		private IEnumerator Co_LoadModelResource()
		{
			DirectionInfo directionInfo;

			//0x98B9E4
			directionInfo = GachaUtility.directionInfo;
			m_resource.LoadResources(directionInfo, false);
			yield return null;
			while (!m_resource.isAllLoaded)
				yield return null;
			directionInfo.SetupQuartzTable(currentSetting.quartzTable);
			directionInfo.SetupOrbTable(currentSetting.orbTable);
			m_modelObject.RegisterDirectionInfo(directionInfo);
			m_modelObject.Initialize(m_resource);
			m_modelObject.RegisterCameraObject(m_cameraObject);
			m_modelObject.Setup(false);
			m_modelObject.onEndIntroCallback = OnEndIntroDirection;
			m_modelObject.onEndAllCallback = OnEndAllDirection;
			m_modelObject.onRequestDelayLoad = OnRequestDelayLoad;
			for(int i = 0; i < m_modelObject.elementRoot.childCount; i++)
			{
				GachaDirectionEventListener[] elst = m_modelObject.elementRoot.GetChild(i).GetComponentsInChildren<GachaDirectionEventListener>(true);
				for(int j = 0; j < elst.Length; j++)
				{
					elst[j].directionObject = m_modelObject;
				}
			}
			m_cameraObject.Initialize(m_resource);
			m_newMarkDecos = new List<NewMarkIcon>(10);
			m_mainHud = Instantiate(m_resource.mainHudPrefab).GetComponent<GachaDirectionHUD>();
			m_mainHud.onClickActivate = OnClickActivateButton;
			m_mainHud.onClickSkip = OnClickSkipButton;
			m_mainHud.onClickAllSkip = OnClickAllSkipButton;
			m_mainHud.transform.SetParent(m_mainCanvasRoot, false);
			m_resultUi = m_resource.resultUiPrefab.GetComponent<GachaResultRoot>();
			m_resultUi.transform.SetParent(m_mainCanvasRoot, false);
			m_resultUi.onClickCard = OnClickCardButton;
			m_resultUi.Setup(m_resource, directionInfo, (int index, GameObject go) =>
			{
				//0x98A5F4
				m_newMarkDecos.Add(new NewMarkIcon(go));
			});
			m_resultButtonUi = m_resource.resultButtonUiPrefab.GetComponent<GachaResultButtonSet>();
			m_resultButtonUi.transform.SetParent(m_mainCanvasRoot, false);
			m_resultButtonUi.onClickBackButton = OnClickExitButton;
			m_resultButtonUi.onClickRetryButton = OnClickRetryButton;
			m_resultButtonUi.onClickLegalDescButton = OnClickLegalDescButton;
			m_resultButtonUi.onClickConfirmButton = OnClickConfirmButton;
			m_resultButtonUi.HideConfirm();
			m_userInfoUi = m_resource.userInfoUiPrefab.GetComponent<CommonMenuTop>();
			m_userInfoUi.transform.SetParent(m_mainCanvasRoot, false);
			m_userInfoUi.OnRecovEne = OnClickRecovEne;
			m_userInfoUi.OnChargeMoney = OnClickChargeMoney;
			m_resultUi.gameObject.SetActive(false);
			m_resultButtonUi.gameObject.SetActive(false);
			m_userInfoUi.gameObject.SetActive(false);
			m_rayCaster = GetComponentInChildren<GraphicRaycaster>(true);
			loadedModelResource = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6C4B10 Offset: 0x6C4B10 VA: 0x6C4B10
		//// RVA: 0x9862EC Offset: 0x9862EC VA: 0x9862EC
		private IEnumerator Co_LoadRetryResource(Action onEnd)
		{
			DirectionInfo directionInfo;

			//0x98CA48
			directionInfo = GachaUtility.directionInfo;
			for(int i = 0; i < m_newMarkDecos.Count; i++)
			{
				m_newMarkDecos[i].Release();
			}
			m_newMarkDecos.Clear();
			yield return Resources.UnloadUnusedAssets();
			m_resource.LoadResources(directionInfo, true);
			yield return null;
			while (!m_resource.isAllLoaded)
				yield return null;
			directionInfo.SetupQuartzTable(currentSetting.quartzTable);
			directionInfo.SetupOrbTable(currentSetting.orbTable);
			m_modelObject.RegisterDirectionInfo(directionInfo);
			m_modelObject.Setup(true);
			m_resultUi = m_resource.resultUiPrefab.GetComponent<GachaResultRoot>();
			m_resultUi.transform.SetParent(m_mainCanvasRoot, false);
			m_resultUi.onClickCard = OnClickCardButton;
			m_resultUi.Setup(m_resource, directionInfo, (int index, GameObject go) =>
			{
				//0x98A698
				m_newMarkDecos.Add(new NewMarkIcon(go));
			});
			m_resultButtonUi.HideConfirm();
			m_resultUi.transform.SetAsLastSibling();
			m_resultButtonUi.transform.SetAsLastSibling();
			m_userInfoUi.transform.SetAsLastSibling();
			m_resultUi.gameObject.SetActive(false);
			m_resultButtonUi.gameObject.SetActive(false);
			m_userInfoUi.gameObject.SetActive(false);
			if (onEnd != null)
				onEnd();
		}

		//// RVA: 0x985684 Offset: 0x985684 VA: 0x985684
		private void StartDirection(bool isRetry)
		{
			inputEnable = false;
			m_mainHud.HideActivateButton();
			m_mainHud.HideAllSkipButton();
			m_modelObject.StartIntro(isRetry);
			m_mainHud.ShowSkipButton();
		}

		//// RVA: 0x9863B4 Offset: 0x9863B4 VA: 0x9863B4
		private void OnEndIntroDirection()
		{
			inputEnable = true;
			m_mainHud.ShowActivateButton();
		}

		//// RVA: 0x9863E8 Offset: 0x9863E8 VA: 0x9863E8
		private void OnEndAllDirection()
		{
			inputEnable = false;
			m_mainHud.HideSkipButton();
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			GachaUtility.SetupGachaLimitTime(t);
			int max = GachaUtility.netGachaProductData.GBAMENANDAN_GetMaxLimit();
			int ownedQuantity = GachaUtility.netGachaProductData.IEEHJPABKMP_GetOwnedQuantity();
			int count = max - ownedQuantity;
			int maxLimit = GachaUtility.netGachaProductData.IBNBABPKLAA_GetMaxLimit();
			int price = GachaUtility.GetMenuPrice(GachaUtility.selectCategory, GachaUtility.selectedCountType, GachaUtility.selectedLotType);
			int currentTicket = GachaUtility.GetCurrentHaveTicket();
			int count2 = maxLimit - GachaUtility.netGachaProductData.GECLFOEDJEI_GetOwnedQuantity();
			bool b1 = false;
			switch(GachaUtility.selectCategory)
			{
				case GCAHJLOGMCI.KNMMOMEHDON_GachaType.HJNNKCMLGFL_0:
					break;
				case GCAHJLOGMCI.KNMMOMEHDON_GachaType.CCAPCGPIIPF_1:
				case GCAHJLOGMCI.KNMMOMEHDON_GachaType.ANFKBNLLJFN_7:
				case GCAHJLOGMCI.KNMMOMEHDON_GachaType.BCBJMKDAAKA_8:
				case GCAHJLOGMCI.KNMMOMEHDON_GachaType.OOABDNHIEFK_9:
					m_resultButtonUi.HideRetry();
					b1 = true;
					break;
				default:
					if(GachaUtility.selectedLotType != GachaUtility.LotType.Ticket)
					{
						if (GachaUtility.selectedCountType == GachaUtility.CountType.Single)
						{
							if (max < 1 || count > 0)
							{
								m_resultButtonUi.SetRetryConsume(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC, 1), price);
								b1 = false;
							}
							else
							{
								m_resultButtonUi.HideRetry();
								b1 = true;
							}
						}
						else
						{
							if (maxLimit < 1 || count2 > 0)
							{
								m_resultButtonUi.SetRetryConsume(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC, 1), price);
								b1 = false;
							}
							else
							{
								m_resultButtonUi.HideRetry();
								b1 = true;
							}
						}
						break;
					}
					if (price <= currentTicket)
					{
						int ticketId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GKMAHADAAFI_GachaTicket.AAJILEFHFGC(GachaUtility.netGachaProductData.OMNAPCHLBHF(GachaUtility.netGachaCount)).PPFNGGCBJKC_Id;
						m_resultButtonUi.SetRetryConsume(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket, ticketId), price);
						b1 = false;
					}
					else
					{
						m_resultButtonUi.HideRetry();
						b1 = true;
					}
					break;
				case GCAHJLOGMCI.KNMMOMEHDON_GachaType.GENEIBGNMPH_3:
					//LAB_00986958
					if (maxLimit < 1 || count2 > 0)
					{
						m_resultButtonUi.SetRetryConsume(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC, 1), price);
						b1 = false;
					}
					else
					{
						m_resultButtonUi.HideRetry();
						b1 = true;
					}
					break;
				case GCAHJLOGMCI.KNMMOMEHDON_GachaType.GKDFKDLFNAJ_5:
				case GCAHJLOGMCI.KNMMOMEHDON_GachaType.BKNHBNINDOC_6:
					if (currentTicket < price)
					{
						m_resultButtonUi.HideRetry();
						b1 = true;
					}
					else
					{
						int ticketId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GKMAHADAAFI_GachaTicket.AAJILEFHFGC(GachaUtility.netGachaProductData.OMNAPCHLBHF(GachaUtility.netGachaCount)).PPFNGGCBJKC_Id;
						//LAB_009867b0
						//LAB_0098690c
						m_resultButtonUi.SetRetryConsume(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket, ticketId), price);
						b1 = false;
					}
					break;
				case GCAHJLOGMCI.KNMMOMEHDON_GachaType.DLOPEFGOAPD_10:
					if (price <= currentTicket)
					{
						m_resultButtonUi.SetRetryConsume(GachaUtility.netGachaProductData.MJNOAMAFNHA_CostItemId, price);
						b1 = false;
					}
					else
					{
						m_resultButtonUi.HideRetry();
						b1 = true;
					}
					break;
			}
			if(GachaUtility.netGachaProductData.FJAOAGNFABN_HasOneDay)
			{
				EGOLBAPFHHD_Common.PCHECKGDJDK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.BGDMJGDEKFJ_GetGachaDraw(GachaUtility.netGachaProductData.FDEBLMKEMLF_TypeAndSeriesId);
				if(d != null && GachaUtility.netGachaProductData.ABNMIDCBENB_OneDay <= d.HMFFHLPNMPH)
				{
					m_resultButtonUi.HideRetry();
					b1 = true;
				}
			}
			for(int i = 0; i < m_newMarkDecos.Count; i++)
			{
				m_newMarkDecos[i].SetActive(true);
			}
			if(!b1)
			{
				if(GachaUtility.selectedCountType == GachaUtility.CountType.Multi)
				{
					if(GachaUtility.netGachaCount >= GCAHJLOGMCI.NFCAJPIJFAM_SummonType.GOAHICNDICO_5 && GachaUtility.netGachaCount <= GCAHJLOGMCI.NFCAJPIJFAM_SummonType.LMHDFEKIDKG_6)
					{
						count2 = 0;
						maxLimit = 1;
					}
					m_resultButtonUi.SetRemainCount(count2, maxLimit);
					m_resultButtonUi.SetTelopType(GachaUtility.selectCategory, GachaUtility.netGachaMultiProduct, GachaUtility.netGachaProductData.KACECFNECON == null ? "" : GachaUtility.netGachaProductData.KACECFNECON.MKJPDIHLGBF_FreeMulti);
				}
				else if(GachaUtility.selectedCountType == GachaUtility.CountType.Single)
				{
					if (GachaUtility.netGachaCount >= GCAHJLOGMCI.NFCAJPIJFAM_SummonType.GOAHICNDICO_5 && GachaUtility.netGachaCount <= GCAHJLOGMCI.NFCAJPIJFAM_SummonType.LMHDFEKIDKG_6)
					{
						count2 = 0;
						maxLimit = 1;
					}
					m_resultButtonUi.SetRemainCount(count, max);
					m_resultButtonUi.SetTelopType(GachaUtility.selectCategory, GachaUtility.netGachaSingleProduct, GachaUtility.netGachaProductData.KACECFNECON == null ? "" : GachaUtility.netGachaProductData.KACECFNECON.NEBCAAGLDHA_FreeSingle);
				}
				m_resultButtonUi.SetDrawRarity(GachaUtility.netGachaProductData.KKODAOIJHMC_GetKakuteiText(GachaUtility.netGachaCount));
			}
			//LAB_00986cf0;
			GameManager.Instance.ResetViewPlayerData();
			m_resultUi.gameObject.SetActive(true);
			m_resultUi.Enter();
			m_resultButtonUi.gameObject.SetActive(true);
			m_resultButtonUi.Enter();
			m_userInfoUi.gameObject.SetActive(true);
			m_userInfoUi.Enter(false);
			inputEnable = true;
			if(!GameManager.Instance.IsTutorial)
			{
				GameManager.Instance.AddPushBackButtonHandler(OnBackButton);
			}
			this.StartCoroutineWatched(Co_EndAllDirection());
		}

		//// RVA: 0x9889C0 Offset: 0x9889C0 VA: 0x9889C0
		private void OnRequestDelayLoad(CardInfo cardInfo)
		{
			m_resource.LoadDelayResources(cardInfo);
			this.StartCoroutineWatched(Co_WaitForDelayLoading(() =>
			{
				//0x98A73C
				m_modelObject.SetupDelayedResource(m_resource);
			}));
		}

		//// RVA: 0x988B30 Offset: 0x988B30 VA: 0x988B30
		private void OnClickActivateButton()
		{
			m_mainHud.HideActivateButton();
			m_modelObject.StartMain();
		}

		//// RVA: 0x988B7C Offset: 0x988B7C VA: 0x988B7C
		private void OnClickExitButton()
		{
			m_modelObject.DoExit();
			if(!GameManager.Instance.IsTutorial)
			{
				GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
			}
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			inputEnable = false;
			if(!CheckDatelineAndAssetUpdate())
			{
				GachaUtility.Unregister();
				Color c = Color.black;
				c.a = 0;
				GameManager.Instance.fullscreenFader.currentColor = c;
				NextScene(string.IsNullOrEmpty(prevSceneName) ? "Menu" : prevSceneName);
			}
		}

		//// RVA: 0x988F98 Offset: 0x988F98 VA: 0x988F98
		private void OnClickRetryButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			this.StartCoroutineWatched(OpenGachaPopup());
		}

		//// RVA: 0x989098 Offset: 0x989098 VA: 0x989098
		private void OnBackButton()
		{
			if(m_resultButtonUi != null && inputEnable)
			{
				m_resultButtonUi.PerformClickButton();
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6C4B88 Offset: 0x6C4B88 VA: 0x6C4B88
		//// RVA: 0x98900C Offset: 0x98900C VA: 0x98900C
		private IEnumerator OpenGachaPopup()
		{
			//0x98D688
			bool isOk = false;
			bool isCancel = false;
			GachaUtility.CancelCause cancelCause = GachaUtility.CancelCause.ClickButton;
			inputEnable = false;
			if (!CheckDatelineAndAssetUpdate())
			{
				yield return Co.R(GachaUtility.OpenGachaPopupCoroutine(GachaScene.SelectProductInfo, m_denomControl, () =>
				{
					//0x98A9DC
					isOk = true;
				}, (GachaUtility.CancelCause cause) =>
				{
					//0x98A9E8
					isCancel = true;
					cancelCause = cause;
				}, () =>
				{
					//0x98A9F8
					this.StartCoroutineWatched(Co_GotoTitle());
				}, (TransitionList.Type gotoSceneType) =>
				{
					//0x98AA30
					OnChangeDate(gotoSceneType);
				}));
				while(!isOk)
				{
					if (isCancel)
						break;
					yield return null;
				}
			}
			else
			{
				isOk = false;
				isCancel = false;
			}
			//LAB_0098d860;
			if(isOk)
			{
				if(CheckDatelineAndAssetUpdate())
				{
					isOk = false;
					isCancel = false;
				}
			}
			if(!isOk)
			{
				if(!isCancel)
				{
					yield break;
				}
				if(cancelCause != GachaUtility.CancelCause.TimeLimit)
				{
					inputEnable = true;
					yield break;
				}
				inputEnable = false;
				OnTimeLimit();
				yield break;
			}
			bool isSuccess = false;
			bool isFewVc = false;
			bool isError = false;
			List<MFDJIFIIPJD> itemList = null;
			GachaUtility.DrawLotRetry((List<MFDJIFIIPJD> items) =>
			{
				//0x98AA68
				isSuccess = true;
				itemList = items;
			}, () =>
			{
				//0x98AA78
				isFewVc = true;
			}, () =>
			{
				//0x98AA84
				isError = true;
			});
			while (!isSuccess && !isFewVc && !isError)
				yield return null;
			if(!isSuccess)
			{
				if(!isFewVc)
				{
					inputEnable = false;
					this.StartCoroutineWatched(Co_GotoTitle());
				}
				else
				{
					inputEnable = true;
				}
			}
			else
			{
				inputEnable = false;
				OnGachaSuccess(itemList);
			}
		}

		//// RVA: 0x989300 Offset: 0x989300 VA: 0x989300
		private void OnClickLegalDescButton()
		{
			inputEnable = false;
			OnClickLegalDescButton(() =>
			{
				//0x98A770
				inputEnable = true;
			});
		}

		//// RVA: 0x98939C Offset: 0x98939C VA: 0x98939C
		private void OnClickLegalDescButton(Action endAction)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MBCPNPNMFHB.HHCJCDFCLOB.MDGPGGLHIPB_ShowWebUrl(MHOILBOJFHL.KCAEDEHGAFO.LCCLAEBKMLD_Legals, () =>
			{
				//0x98AA90
				if (endAction != null)
					endAction();
			}, () =>
			{
				//0x98AAA4
				this.StartCoroutineWatched(Co_GotoTitle());
				if (endAction != null)
					endAction();
			});
		}

		//// RVA: 0x98955C Offset: 0x98955C VA: 0x98955C
		private void OnClickConfirmButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(Co_ResultConfirmPopup());
		}

		//// RVA: 0x98965C Offset: 0x98965C VA: 0x98965C
		private void OnClickSkipButton()
		{
			if (!isSkippable)
				return;
			m_modelObject.RequestSkip();
		}

		//// RVA: 0x989698 Offset: 0x989698 VA: 0x989698
		private void OnClickAllSkipButton()
		{
			if (!isSkippable)
				return;
			m_modelObject.RequestAllSkip();
			m_mainHud.HideActivateButton();
		}

		//// RVA: 0x9896F0 Offset: 0x9896F0 VA: 0x9896F0
		private void OnClickCardButton(int cardIndex)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			inputEnable = false;
			ShowSceneStatusPopup(GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes[GachaUtility.directionInfo.GetCardInfo(cardIndex).cardId - 1], GameManager.Instance.ViewPlayerData, () =>
			{
				//0x98A778
				inputEnable = true;
			});
		}

		//// RVA: 0x989998 Offset: 0x989998 VA: 0x989998
		private void OnClickRecovEne()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			if(CheckDatelineAndAssetUpdate())
			{
				inputEnable = false;
			}
			else
			{
				if(CIOECGOMILE.HHCJCDFCLOB.BPLOEAHOPFI_StaminaUpdater.DCLKMNGMIKC() < CIOECGOMILE.HHCJCDFCLOB.BPLOEAHOPFI_StaminaUpdater.DCBENCMNOGO_GainStamina)
				{
					inputEnable = false;
					PopupWindowManager.OpenStaminaWindow(m_denomControl, () =>
					{
						//0x98A780
						inputEnable = true;
					}, () =>
					{
						//0x98A788
						inputEnable = true;
					}, OnGachaNetError, (TransitionList.Type gotoSceneType) =>
					{
						//0x98A790
						OnChangeDate(gotoSceneType);
						inputEnable = true;
					});
					return;
				}
				PopupWindowManager.OpenStaminaMaxWindow(null);
			}
		}

		//// RVA: 0x989CA4 Offset: 0x989CA4 VA: 0x989CA4
		private void OnClickChargeMoney()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			if (CheckDatelineAndAssetUpdate())
			{
				inputEnable = false;
			}
			else
			{
				if(m_denomControl != null)
				{
					inputEnable = false;
					m_denomControl.StartPurchaseSequence(() =>
					{
						//0x98A7B0
						inputEnable = true;
					}, () =>
					{
						//0x98A7B8
						inputEnable = true;
					}, OnGachaNetError, (TransitionList.Type type) =>
					{
						//0x98A7C0
						OnChangeDate(type);
						inputEnable = true;
					}, null);
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6C4C00 Offset: 0x6C4C00 VA: 0x6C4C00
		//// RVA: 0x988A88 Offset: 0x988A88 VA: 0x988A88
		private IEnumerator Co_WaitForDelayLoading(Action onEnd)
		{
			//0x98D264
			while(!m_resource.isDelayLoaded)
				yield return null;
			onEnd();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6C4C78 Offset: 0x6C4C78 VA: 0x6C4C78
		//// RVA: 0x989EF0 Offset: 0x989EF0 VA: 0x989EF0
		private IEnumerator Co_WaitForUiAnimationEnd(Action onEnd)
		{
			//0x98D3A0
			while(m_resultUi.IsPlaying())
				yield return null;
			while (m_resultButtonUi.IsPlaying())
				yield return null;
			while (m_userInfoUi.IsPlaying())
				yield return null;
			onEnd();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6C4CF0 Offset: 0x6C4CF0 VA: 0x6C4CF0
		//// RVA: 0x988934 Offset: 0x988934 VA: 0x988934
		private IEnumerator Co_EndAllDirection()
		{
			//0x98ADB8
			inputEnable = false;
			activeUserInfoUpdate = true;
			if(GachaUtility.selectedLotType == GachaUtility.LotType.Ticket)
			{
				m_resultButtonUi.HideLegalDesc();
			}
			GONMPHKGKHI_RewardView view = RecordPlateUtility.ViewInitialize(RecordPlateUtility.eSceneType.Gacha, false);
			if(view.LBHPMGDNPHK(GONMPHKGKHI_RewardView.CECMLGBLHHG.INJNLJHGGKB_4))
			{
				m_resultButtonUi.ShowConfirm();
			}
			yield return Co.R(PopupRecordPlate.Show(RecordPlateUtility.eSceneType.Gacha, null, false));
			if(GameManager.Instance.IsTutorial)
			{
				TodoLogger.LogError(1, "Tuto 22");
			}
			inputEnable = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6C4D68 Offset: 0x6C4D68 VA: 0x6C4D68
		//// RVA: 0x9895D0 Offset: 0x9895D0 VA: 0x9895D0
		private IEnumerator Co_ResultConfirmPopup()
		{
			//0x98D110
			inputEnable = false;
			activeUserInfoUpdate = true;
			yield return Co.R(PopupRecordPlate.ResultShow(RecordPlateUtility.eSceneType.Gacha, null, false));
			inputEnable = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6C4DE0 Offset: 0x6C4DE0 VA: 0x6C4DE0
		//// RVA: 0x989FF8 Offset: 0x989FF8 VA: 0x989FF8
		private IEnumerator Co_GotoTitle()
		{
			UGUIFader fade;

			//0x98B648
			m_modelObject.DoExit();
			GameManager.Instance.ClearPushBackButtonHandler();
			fade = GameManager.Instance.fullscreenFader;
			if (fade.currentColor.a < 1)
			{
				fade.Fade(0.1f, Color.black);
			}
			while (fade.isFading)
				yield return null;
			PopupWindowManager.Close(null, null);
			SoundManager.Instance.bgmPlayer.Stop();
			NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.MBOIDKCMCDL = false;
			NextScene("Title");
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6C4E58 Offset: 0x6C4E58 VA: 0x6C4E58
		//// RVA: 0x98A0A4 Offset: 0x98A0A4 VA: 0x98A0A4
		private IEnumerator Co_GotoLoginBonus()
		{
			UGUIFader fade;

			//0x98B1FC
			m_modelObject.DoExit();
			GameManager.Instance.ClearPushBackButtonHandler();
			fade = GameManager.Instance.fullscreenFader;
			if(fade.currentColor.a < 1)
			{
				fade.Fade(0.1f, Color.black);
			}
			while (fade.isFading)
				yield return null;
			PopupWindowManager.Close(null, null);
			SoundManager.Instance.bgmPlayer.Stop();
			NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.MBOIDKCMCDL = false;
			MenuScene.ComebackByRestart = true;
			NextScene("Menu");
		}

		//// RVA: 0x98A150 Offset: 0x98A150 VA: 0x98A150
		private void OnGachaSuccess(List<MFDJIFIIPJD> items)
		{
			m_resultUi.Leave();
			m_resultButtonUi.Leave();
			m_userInfoUi.Leave(false);
			if (!GameManager.Instance.IsTutorial)
			{
				GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
			}
			this.StartCoroutineWatched(Co_WaitForUiAnimationEnd(() =>
			{
				//0x98AB10
				activeUserInfoUpdate = false;
				GachaUtility.Register(items);
				this.StartCoroutineWatched(Co_LoadRetryResource(() =>
				{
					//0x98AD88
					StartDirection(true);
				}));
			}));
		}

		//// RVA: 0x98A4B0 Offset: 0x98A4B0 VA: 0x98A4B0
		//private void OnGachaFewVC() { }

		//// RVA: 0x98A4B4 Offset: 0x98A4B4 VA: 0x98A4B4
		private void OnGachaNetError()
		{
			this.StartCoroutineWatched(Co_GotoTitle());
		}

		//// RVA: 0x98A4D8 Offset: 0x98A4D8 VA: 0x98A4D8
		private void OnChangeDate(TransitionList.Type type)
		{
			if(type == TransitionList.Type.TITLE)
			{
				this.StartCoroutineWatched(Co_GotoTitle());
			}
			else if(type == TransitionList.Type.LOGIN_BONUS)
			{
				this.StartCoroutineWatched(Co_GotoLoginBonus());
			}
		}
	}
}
