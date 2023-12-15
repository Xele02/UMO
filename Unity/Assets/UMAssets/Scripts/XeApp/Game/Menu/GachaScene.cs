using mcrs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Gacha;
using XeApp.Game.Tutorial;
using XeSys;

namespace XeApp.Game.Menu
{
	public class GachaScene : TransitionRoot
	{
		public class GachaArgs : TransitionArgs
		{
			public int TypeAndSeriesId { get; private set; } // 0x8
			public bool UpdateGachaProduct { get; private set; } // 0xC

			// RVA: 0xB6C850 Offset: 0xB6C850 VA: 0xB6C850
			public GachaArgs()
			{
				UpdateGachaProduct = true;
				TypeAndSeriesId = 10001;
			}

			// RVA: 0xB6C884 Offset: 0xB6C884 VA: 0xB6C884
			public GachaArgs(int typeAndSeriesId, bool updateGachaProduct = true)
			{
				UpdateGachaProduct = updateGachaProduct;
				TypeAndSeriesId = typeAndSeriesId;
			}

			//// RVA: 0xB6C878 Offset: 0xB6C878 VA: 0xB6C878
			public void Init(int typeAndSeriesId, bool updateGachaProduct = true)
			{
				UpdateGachaProduct = updateGachaProduct;
				TypeAndSeriesId = typeAndSeriesId;
			}
		}

		private class AppearLot
		{
			public List<BPADANIKFHP> limited_groups { get; private set; } // 0x8
			public List<BPADANIKFHP> basic_groups { get; private set; } // 0xC
			public List<IJPECOFPOCH> limited_episodes { get; private set; } // 0x10
			public List<IJPECOFPOCH> basic_episodes { get; private set; } // 0x14
			public IKMBBPDBECA extra_info { get; private set; } // 0x18
			//public bool hasLimitedGroups { get; } 0xB6C708
			//public bool hasLimitedEpisodes { get; } 0xB6C718
			//public bool hasBasicGroups { get; } 0xB6C728
			//public bool hasBasicEpisodes { get; } 0xB6C738
			//public bool hasLimited { get; } 0xB6C748
			//public bool hasBasic { get; } 0xB6C768

			// RVA: 0xB6C788 Offset: 0xB6C788 VA: 0xB6C788
			public AppearLot(HIMAFGJCECK limitedLot, HIMAFGJCECK basicLot, IKMBBPDBECA extra)
			{
				if(limitedLot != null)
				{
					limited_groups = limitedLot.OJGPPOKENLG_ProbabilityPerGroupKey;
					limited_episodes = limitedLot.DDGPEFEEKFP_Items;
				}
				if(basicLot != null)
				{
					basic_groups = basicLot.OJGPPOKENLG_ProbabilityPerGroupKey;
					basic_episodes = basicLot.DDGPEFEEKFP_Items;
				}
				if (extra != null)
					extra_info = extra;
			}

			// RVA: 0xB6C7DC Offset: 0xB6C7DC VA: 0xB6C7DC
			public AppearLot(ABPEPHGCNDA limitedLot, ABPEPHGCNDA basicLot, IKMBBPDBECA extra)
			{
				if (limitedLot != null)
				{
					limited_groups = limitedLot.OJGPPOKENLG_ProbabilityPerGroupKey;
					limited_episodes = limitedLot.DDGPEFEEKFP_Items;
				}
				if (basicLot != null)
				{
					basic_groups = basicLot.OJGPPOKENLG_ProbabilityPerGroupKey;
					basic_episodes = basicLot.DDGPEFEEKFP_Items;
				}
				if (extra != null)
					extra_info = extra;
			}
		}

		private BEPHBEGDFFK m_view; // 0x48
		private LayoutGachaBg m_layoutBg; // 0x4C
		private LayoutGachaTitle m_layoutTitle; // 0x50
		private LayoutGachaBannerList m_layoutBannerList; // 0x54
		private LayoutGachaHeaderInfo m_layoutHeaderInfo; // 0x58
		private LayoutGachaLegalButton m_layoutLegalButton; // 0x5C
		private LayoutGachaDrawButtonGroup m_layoutDrawButtonGroup; // 0x60
		private bool m_isEndOnPreSetCanvas; // 0x64
		private GachaRatePopupSetting m_gachaRatePopupSetting = new GachaRatePopupSetting(); // 0x68
		private EpisodeRewardPopupSetting m_episodeRewardPopupSetting = new EpisodeRewardPopupSetting(); // 0x6C
		private SceneStatePopupSetting m_sceneStatePopup; // 0x70
		private GachaScene.AppearLot m_appearLot; // 0x74
		private List<GachaRateInfo> m_rateInfoList; // 0x78
		private List<GachaRateInfo> m_episodeInfoList; // 0x7C

		public static int SelectIndex { get; private set; } // 0x0
		public static List<LOBDIAABMKG> GachaProductList { get; private set; } // 0x4
		public static BEPHBEGDFFK.DMBKENKBIJD SelectProductInfo { get; set; } // 0x8

		// RVA: 0xEE6830 Offset: 0xEE6830 VA: 0xEE6830 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			m_sceneStatePopup = new SceneStatePopupSetting();
			m_sceneStatePopup.SetParent(transform);
			m_sceneStatePopup.PageSave = SceneStatusParam.PageSave.Pickup;
			m_sceneStatePopup.WindowSize = Common.SizeType.Large;
			m_rateInfoList = new List<GachaRateInfo>();
			m_episodeInfoList = new List<GachaRateInfo>();
			MenuScene.Instance.DenomControl.AddResponseHandler(UpdatePurchased);
			this.StartCoroutineWatched(Co_LoadResources());
		}

		// RVA: 0xEE6ACC Offset: 0xEE6ACC VA: 0xEE6ACC
		private void Update()
		{
			if (m_view != null)
				m_view.FBANBDCOEJL_Update();
		}

		// RVA: 0xEE6AE0 Offset: 0xEE6AE0 VA: 0xEE6AE0 Slot: 16
		protected override void OnPreSetCanvas()
		{
			this.StartCoroutineWatched(Co_OnPreSetCanvas());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DCD94 Offset: 0x6DCD94 VA: 0x6DCD94
		//// RVA: 0xEE6B04 Offset: 0xEE6B04 VA: 0xEE6B04
		private IEnumerator Co_OnPreSetCanvas()
		{
			bool isGetGachaProduct; // 0x24
			DOLDMCAMEOD_RequestRemainingForCurrencyIds req; // 0x28
			HPBDNNACBAK gpm; // 0x2C

			//0xEEF650
			m_isEndOnPreSetCanvas = false;
			isGetGachaProduct = true;
			int defaultGahcaId = 0;
			if(PrevTransition == TransitionList.Type.EPISODE_APPEAL || PrevTransition == TransitionList.Type.GACHA_CHECK_NEW_COSTUME || PrevTransition == TransitionList.Type.GACHA_CHECK_NEW_VALKYRIE)
			{
				defaultGahcaId = GachaProductList[SelectIndex].FDEBLMKEMLF_TypeAndSeriesId;
				isGetGachaProduct = false;
			}
			else
			{
				GachaArgs arg = Args as GachaArgs;
				if(arg != null)
				{
					defaultGahcaId = arg.TypeAndSeriesId;
					isGetGachaProduct = arg.UpdateGachaProduct;
				}
			}
			req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new DOLDMCAMEOD_RequestRemainingForCurrencyIds());
			req.CGCFENMHJIM_Ids = new List<int>(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GKMAHADAAFI_GachaTicket.DHIACJMOEBH);
			bool done = false;
			bool err = false;
			req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request ba) =>
			{
				//0xEEDD50
				done = true;
			};
			req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request ba) =>
			{
				//0xEEDD5C
				done = true;
				err = true;
			};
			while (!done)
				yield return null;
			if(!err)
			{
				CIOECGOMILE.HHCJCDFCLOB.DJICHKCLMCD_UpdateCurrencies(req.NFEAMMJIMPG.BBEPLKNMICJ_CurrenciesList);
				req = null;
				done = false;
				err = false;
				NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.OMPBFINJHDF_RequestVirtualCurrencyBalancesWithExpiredAt(() =>
				{
					//0xEEDD70
					done = true;
				}, () =>
				{
					//0xEEDD7C
					done = true;
					err = true;
				});
				while (!done)
					yield return null;
				if(!err)
				{
					if(isGetGachaProduct)
					{
						gpm = NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI;
						done = false;
						err = false;
						gpm.LILDGEPCPPG_GetProducList(() =>
						{
							//0xEEDD90
							done = true;
						}, () =>
						{
							//0xEEDD9C
							done = true;
							err = true;
						}, GameManager.Instance.IsTutorial, true);
						while (!done)
							yield return null;
						if(!err)
						{
							GachaProductList = gpm.MHKCPJDNJKI_GatchaProducts;
							gpm = null;
						}
						else
						{
							if (MenuScene.Instance.IsTransition())
							{
								GotoTitle();
							}
							else
							{
								MenuScene.Instance.GotoTitle();
							}
							m_isEndOnPreSetCanvas = true;
							yield break;
						}
					}
					if(m_view == null)
					{
						m_view = new BEPHBEGDFFK();
						m_view.KHEKNNFCAOI();
					}
					SelectIndex = GachaProductList.FindIndex((LOBDIAABMKG x) =>
					{
						//0xEED948
						GCAHJLOGMCI.KNMMOMEHDON_GachaType a = GCAHJLOGMCI.OLMFIANJBOB_GetGachaType(defaultGahcaId * 100);
						if (a == GCAHJLOGMCI.KNMMOMEHDON_GachaType.CCAPCGPIIPF_1)
							return defaultGahcaId == 1;
						else
							return defaultGahcaId == x.FDEBLMKEMLF_TypeAndSeriesId;
					});
					if (SelectIndex < 0)
						SelectIndex = 0;
					LOBDIAABMKG l = GachaProductList[SelectIndex];
					if(GameManager.Instance.IsTutorial)
					{
						TodoLogger.LogError(0, "Tuto");
					}
					bool isEndChangeGacha = false;
					this.StartCoroutineWatched(Co_ChangeGacha(l, false, () =>
					{
						//0xEED9A4
						isEndChangeGacha = true;
					}));
					m_layoutBg.OnClickBgImage = OnClickCardImage;
					m_layoutBg.OnChangeBgScene = (int sceneId) =>
					{
						//0xEED9B0
						m_layoutLegalButton.SwitchEpisode(sceneId);
					};
					m_layoutBg.OnSwipeToLeft = OnSwipeToLeft;
					m_layoutBg.OnSwipeToRight = OnSwipeToRight;
					m_layoutBannerList.OnSelectGacha = (int index) =>
					{
						//0xEED9F8
						if (SelectIndex == index)
							return;
						SelectIndex = index;
						SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
						this.StartCoroutineWatched(Co_ChangeGacha(GachaProductList[SelectIndex], true, () =>
						{
							//0xEEDCA8
							this.StartCoroutineWatched(Co_ShowTutorial());
						}));
					};
					m_layoutBannerList.OnSwipeScroll = (bool isSwipe) =>
					{
						//0xEEDCFC
						m_layoutBg.SetChangeBgLoopState(isSwipe, 0);
					};
					m_layoutHeaderInfo.OnClickVCButton = OnClickPurchaseButton;
					if (GameManager.Instance.IsTutorial)
						m_layoutLegalButton.OnClickDetailButton = OnClickTutorialAppearRate;
					else
						m_layoutLegalButton.OnClickDetailButton = OnClickAppearRate;
					m_layoutLegalButton.OnClickPickupButton = OnClickGachaDetail;
					m_layoutLegalButton.OnClickEpisodeButton = OnClickEpisodeReward;
					m_layoutLegalButton.OnClickMovieButton = OnClickEpisodeAppeal;
					m_layoutLegalButton.OnClickPassPurchaseButton = OnClickPassPurchaseButton;
					m_layoutLegalButton.OnClickRarityButton = OnClickRarityChange;
					m_layoutDrawButtonGroup.OnClickButton = OnClickDrawGacha;
					m_layoutDrawButtonGroup.OnClickSetSaleButton = OnClickBonusTicketPurchaseButton;
					m_layoutDrawButtonGroup.OnClickPeriodButton = OnClickTicketConfirmButton;
					GachaUtility.RegisterLegalDesc(OnClickLegalDesc);
					while (!isEndChangeGacha)
						yield return null;
					m_isEndOnPreSetCanvas = true;
				}
				else
				{
					if (MenuScene.Instance.IsTransition())
					{
						GotoTitle();
					}
					else
					{
						MenuScene.Instance.GotoTitle();
					}
					m_isEndOnPreSetCanvas = true;
				}
			}
			else
			{
				if(MenuScene.Instance.IsTransition())
				{
					GotoTitle();
				}
				else
				{
					MenuScene.Instance.GotoTitle();
				}
				m_isEndOnPreSetCanvas = true;
			}
		}

		// RVA: 0xEE6BB0 Offset: 0xEE6BB0 VA: 0xEE6BB0 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return m_isEndOnPreSetCanvas;
		}

		// RVA: 0xEE6BB8 Offset: 0xEE6BB8 VA: 0xEE6BB8 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			m_layoutTitle.Enter();
			m_layoutHeaderInfo.Enter();
			m_layoutLegalButton.Enter();
			m_layoutDrawButtonGroup.Enter();
		}

		// RVA: 0xEE6C48 Offset: 0xEE6C48 VA: 0xEE6C48 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_layoutTitle.IsPlaying() && !m_layoutHeaderInfo.IsPlaying() && !m_layoutLegalButton.IsPlaying() && !m_layoutDrawButtonGroup.IsPlaying();
		}

		// RVA: 0xEE6CFC Offset: 0xEE6CFC VA: 0xEE6CFC Slot: 12
		protected override void OnStartExitAnimation()
		{
			m_layoutTitle.Leave();
			m_layoutHeaderInfo.Leave();
			m_layoutLegalButton.Leave();
			m_layoutDrawButtonGroup.Leave();
		}

		// RVA: 0xEE6D8C Offset: 0xEE6D8C VA: 0xEE6D8C Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_layoutTitle.IsPlaying() && !m_layoutHeaderInfo.IsPlaying() && !m_layoutLegalButton.IsPlaying() && !m_layoutDrawButtonGroup.IsPlaying();
		}

		// RVA: 0xEE6E40 Offset: 0xEE6E40 VA: 0xEE6E40 Slot: 23
		protected override void OnActivateScene()
		{
			this.StartCoroutineWatched(Co_OnActivateScene());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DCE0C Offset: 0x6DCE0C VA: 0x6DCE0C
		//// RVA: 0xEE6E64 Offset: 0xEE6E64 VA: 0xEE6E64
		private IEnumerator Co_OnActivateScene()
		{
			//0xEEF530
			m_layoutBg.StartChangeBgLoop();
			yield return this.StartCoroutineWatched(Co_ShowTutorial());
		}

		// RVA: 0xEE6F10 Offset: 0xEE6F10 VA: 0xEE6F10 Slot: 14
		protected override void OnDestoryScene()
		{
			Release();
			GachaUtility.UnregisterLegalDesc();
			if(GachaProductList != null && GachaProductList.Count > 0)
			{
				for(int i = 0; i < GachaProductList.Count; i++)
				{
					GachaProductList[i].CADENLBDAEB = false;
				}
			}
		}

		// RVA: 0xEE7134 Offset: 0xEE7134 VA: 0xEE7134 Slot: 15
		protected override void OnDeleteCache()
		{
			MenuScene.Instance.DenomControl.RemoveResponseHandler(UpdatePurchased);
		}

		//// RVA: 0xEE7230 Offset: 0xEE7230 VA: 0xEE7230
		private void UpdatePurchased(DenominationManager.Response response)
		{
			m_layoutHeaderInfo.Setup(m_view);
			m_layoutDrawButtonGroup.Setup(m_view);
		}

		// RVA: 0xEE7290 Offset: 0xEE7290 VA: 0xEE7290 Slot: 25
		protected override void OnTutorial()
		{
			this.StartCoroutineWatched(Co_OnTutorial());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DCE84 Offset: 0x6DCE84 VA: 0x6DCE84
		//// RVA: 0xEE72B4 Offset: 0xEE72B4 VA: 0xEE72B4
		private IEnumerator Co_OnTutorial()
		{
			//0xB6ACBC
			bool done = false;
			if(BasicTutorialManager.Instance.GetRecoveryPoint() != ILDKBCLAFPB.CDIPJNPICCO.FBFBGLONIME_4)
			{
				BasicTutorialManager.Log(OAGBCBBHMPF.OGBCFNIKAFI.PHOGGPBMGAE_20);
				BasicTutorialManager.Instance.UpdateRecoveryPoint(ILDKBCLAFPB.CDIPJNPICCO.DOEHLCLBCNN_3);
				done = false;
				BasicTutorialManager.Instance.ShowMessageWindow(BasicTutorialMessageId.Id_GachaMain, () =>
				{
					//0xEEDDC8
					done = true;
				}, null);
				while (!done)
					yield return null;
				BasicTutorialManager.Instance.SetInputLimit(InputLimitButton.GachaBuy, null, null, TutorialPointer.Direction.Normal);
			}
			else
			{ 
				done = false;
				BasicTutorialManager.Instance.ShowMessageWindow(BasicTutorialMessageId.Id_GachaEnd, () =>
				{
					//0xEEDDB0
					done = true;
				}, null);
				while (!done)
					yield return null;
				done = false;
				BasicTutorialManager.Instance.SetInputLimit(InputLimitButton.Setting, () =>
				{
					//0xEEDDBC
					done = true;
				}, null, TutorialPointer.Direction.Normal);
				while (!done)
					yield return null;
				BasicTutorialManager.Instance.UpdateRecoveryPoint(ILDKBCLAFPB.CDIPJNPICCO.DJPFJGKGOOF_5);
			}
		}

		// RVA: 0xEE7324 Offset: 0xEE7324 VA: 0xEE7324
		private void ChangeGacha(LOBDIAABMKG product, bool isFade, Action endCallback)
		{
			this.StartCoroutineWatched(Co_ChangeGacha(product, isFade, endCallback));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DCEFC Offset: 0x6DCEFC VA: 0x6DCEFC
		//// RVA: 0xEE7350 Offset: 0xEE7350 VA: 0xEE7350
		private IEnumerator Co_ChangeGacha(LOBDIAABMKG product, bool isFade, Action endCallback)
		{
			//0xEEE2D8
			m_appearLot = null;
			m_rateInfoList.Clear();
			m_episodeInfoList.Clear();
			product.CADENLBDAEB = false;
			NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.DKHDHGAFPGC();
			NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.ANGMDEPOBEE();
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			GachaUtility.typeAndSeriesId = product.FDEBLMKEMLF_TypeAndSeriesId;
			GachaUtility.selectCategory = product.INDDJNMPONH_Category;
			GachaUtility.UpdateGachaProductCategory();
			GachaUtility.SetupFreeTimezone();
			GachaUtility.SetupGachaLimitTime(time);
			int a = 0;
			if(m_view.DPBDFPPMIPH_Gacha == null || m_view.DPBDFPPMIPH_Gacha.FDEBLMKEMLF_TypeAndSeriesId != product.FDEBLMKEMLF_TypeAndSeriesId)
			{
				//LAB_00eee614
				a = 0;
				if(product.MFICPBJPCCJ_GachaBgId < 1)
				{
					a = product.HNKHCIDOKFF_PlateBgId;
				}
			}
			else
			{
				a = m_view.BADFIKBADNH_PickupId;
			}
			m_view.DOMFHDPMCCO(product, a, time);
			m_layoutBg.Setup(m_view, isFade);
			m_layoutTitle.Setup(m_view);
			m_layoutBannerList.Setup(m_view, GachaProductList, SelectIndex);
			m_layoutHeaderInfo.Setup(m_view);
			m_layoutLegalButton.Setup(m_view);
			m_layoutDrawButtonGroup.Setup(m_view);
			MenuScene.Instance.InputDisable();
			while (m_view.CJOOOBKFMGJ_IsLoading())
				yield return null;
			MenuScene.Instance.InputEnable();
			if (endCallback != null)
				endCallback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DCF74 Offset: 0x6DCF74 VA: 0x6DCF74
		//// RVA: 0xEE7448 Offset: 0xEE7448 VA: 0xEE7448
		private IEnumerator Co_ShowTutorial()
		{
			//0xB6B5B0
			MenuScene.Instance.RaycastDisable();
			yield return Co.R(TutorialManager.TryShowTutorialCoroutine((TutorialConditionId conditionId) =>
			{
				//0xEECB20
				if (conditionId != TutorialConditionId.Condition36)
					return false;
				return m_view.DPBDFPPMIPH_Gacha.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON_GachaType.CCAPCGPIIPF_1;
			}));
			yield return Co.R(TutorialManager.TryShowTutorialCoroutine((TutorialConditionId conditionId) =>
			{
				//0xEECB84
				if (conditionId != TutorialConditionId.Condition87)
					return false;
				return m_view.NLFPCMJMAEM();
			}));
			MenuScene.Instance.RaycastEnable();
		}

		//// RVA: 0xEE7074 Offset: 0xEE7074 VA: 0xEE7074
		private void Release()
		{
			m_appearLot = null;
			m_rateInfoList.Clear();
			m_episodeInfoList.Clear();
			if (m_view != null)
				m_view.FFCMGLOBPAJ_Release();
		}

		//// RVA: 0xEE74D0 Offset: 0xEE74D0 VA: 0xEE74D0
		private int FindRelatedEpisodeId(int cardId)
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[cardId - 1].KELFCMEOPPM_Ep;
		}

		//// RVA: 0xEE7600 Offset: 0xEE7600 VA: 0xEE7600
		private void ShowSceneStatusPopup(GCIJNCFDNON_SceneInfo sceneData, DFKGGBMFFGB_PlayerInfo playerData, bool isDiableLuckyLeaf, Action onClose)
		{
			m_sceneStatePopup.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			m_sceneStatePopup.Scene = sceneData;
			m_sceneStatePopup.PlayerData = playerData;
			m_sceneStatePopup.IsOpenAnimeMoment = false;
			m_sceneStatePopup.IsFriend = false;
			m_sceneStatePopup.IsDisableZoom = true;
			m_sceneStatePopup.IsDiableLuckyLeaf = isDiableLuckyLeaf;
			m_sceneStatePopup.TitleText = GameMessageManager.GetSceneCardName(sceneData);
			PopupWindowManager.Show(m_sceneStatePopup, (PopupWindowControl control, PopupButton.ButtonType label, PopupButton.ButtonLabel type) =>
			{
				//0xEEDDD4
				if (onClose != null)
					onClose();
			}, null, null, null);
		}

		//// RVA: 0xEE7948 Offset: 0xEE7948 VA: 0xEE7948
		private void OnTimeLimit()
		{
			if(m_view.DPBDFPPMIPH_Gacha.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON_GachaType.CCAPCGPIIPF_1)
			{
				GachaUtility.OpenTimeLimitPopup(ResetLotInfo);
			}
			else
			{
				JHHBAFKMBDL.HHCJCDFCLOB.HMIHFLGLHBA(OnGachaNetError);
			}
		}

		//// RVA: 0xEE7AE4 Offset: 0xEE7AE4 VA: 0xEE7AE4
		private void ResetLotInfo()
		{
			m_layoutDrawButtonGroup.Setup(m_view);
		}

		//// RVA: 0xEE7B18 Offset: 0xEE7B18 VA: 0xEE7B18
		private void OnClickEpisodeReward()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			int id = FindRelatedEpisodeId(m_view.BADFIKBADNH_PickupId);
			LGMEPLIJLNB data = LGMEPLIJLNB.BMFKMFNPGPC(id, true);
			PIGBBNDPPJC p = new PIGBBNDPPJC();
			p.KHEKNNFCAOI(id);
			int fullItemId = data.GOOIIPFHOIG.JJBGOIMEIPF_ItemFullId;
            EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(fullItemId);
            int itemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(fullItemId);
			if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie)
			{
				JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo valk = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_ValkyrieList[itemId - 1];
				CheckNewValkyrieArgs arg = new CheckNewValkyrieArgs();
				arg.pilot_id = valk.PFGJJLGLPAC_PilotId;
				arg.val_id = valk.GPPEFLKGGGJ_Id;
				MenuScene.Instance.Call(TransitionList.Type.GACHA_CHECK_NEW_VALKYRIE, arg, true);
			}
			else if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume)
			{
				LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes[itemId - 1];
				CheckNewCostumeArgs arg = new CheckNewCostumeArgs();
				arg.cos_id = cos.DAJGPBLEEOB_PrismCostumeModelId;
				arg.diva_id = cos.AHHJLDLAPAN_PrismDivaId;
				MenuScene.Instance.Call(TransitionList.Type.GACHA_CHECK_NEW_COSTUME, arg, true);
			}
		}

		//// RVA: 0xEE7FE4 Offset: 0xEE7FE4 VA: 0xEE7FE4
		private void OnClickEpisodeAppeal()
		{
			TodoLogger.LogNotImplemented("OnClickEpisodeAppeal");
		}

		//// RVA: 0xEE8188 Offset: 0xEE8188 VA: 0xEE8188
		private void OnClickDrawGacha(int lotCount)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			this.StartCoroutineWatched(OpenGachaPopup(GachaUtility.netGachaProductData.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON_GachaType.GENEIBGNMPH_3 || lotCount > 1 ? GachaUtility.CountType.Multi : GachaUtility.CountType.Single));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DCFEC Offset: 0x6DCFEC VA: 0x6DCFEC
		//// RVA: 0xEE829C Offset: 0xEE829C VA: 0xEE829C
		private IEnumerator OpenGachaPopup(GachaUtility.CountType type)
		{
			//0xB6BD94
			bool isOk = false;
			bool isCancel = false;
			GachaUtility.CancelCause cancelCause = GachaUtility.CancelCause.ClickButton;
			MenuScene.Instance.InputDisable();
			if (!MenuScene.CheckDatelineAndAssetUpdate())
			{
				GachaUtility.selectedCountType = type;
				yield return Co.R(GachaUtility.OpenGachaTicketSelectPopupCoroutine(m_view, MenuScene.Instance.DenomControl, () =>
				{
					//0xEEDDF0
					isOk = true;
				}, (GachaUtility.CancelCause cause) =>
				{
					//0xEEDDFC
					cancelCause = cause;
					isCancel = true;
				}, () =>
				{
					//0xEEDE0C
					OnGachaNetError();
				}, (TransitionList.Type gotoSceneType) =>
				{
					//0xEED198
					if (gotoSceneType == TransitionList.Type.TITLE)
						MenuScene.Instance.GotoTitle();
					else if (gotoSceneType == TransitionList.Type.LOGIN_BONUS)
						MenuScene.Instance.GotoLoginBonus();
					MenuScene.Instance.InputEnable();
				}));
			}
			else
			{
				isOk = false;
				isCancel = false;
			}
			if (isOk)
			{
				if (MenuScene.CheckDatelineAndAssetUpdate())
				{
					isOk = false;
					isCancel = false;
				}
			}
			if(!isOk)
			{
				if(isCancel)
				{
					if (cancelCause == GachaUtility.CancelCause.TimeLimit)
						OnTimeLimit();
				}
				MenuScene.Instance.InputEnable();
				yield break;
			}
			bool isSuccess = false;
			bool isFewVc = false;
			bool isError = false;
			List<MFDJIFIIPJD> itemList = null;
			GachaUtility.DrawLot(SelectProductInfo, (List<MFDJIFIIPJD> items) =>
			{
				//0xEEDE3C
				isSuccess = true;
				itemList = items;
			}, () =>
			{
				//
				isFewVc = true;
			}, () =>
			{
				//0xEEDE58
				isError = true;
			});
			while (!isSuccess && !isFewVc && !isError)
				yield return null;
			if(!isSuccess)
			{
				if (!isFewVc)
					OnGachaNetError();
				else
					OnGachaFewVC();
			}
			else
			{
				OnDoGachaSuccess(itemList);
			}
			MenuScene.Instance.InputEnable();
		}

		//// RVA: 0xEE8340 Offset: 0xEE8340 VA: 0xEE8340
		private void OnSwipeToLeft()
		{
			if(MenuScene.Instance.GetInputDisableCount() < 1)
			{
				if(MenuScene.Instance.GetRaycastDisableCount() < 1)
				{
					if (MenuScene.Instance.IsTransition())
						return;
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_004);
					m_layoutBg.NextChangeBg();
				}
			}
		}

		//// RVA: 0xEE8510 Offset: 0xEE8510 VA: 0xEE8510
		private void OnSwipeToRight()
		{
			if(MenuScene.Instance.GetInputDisableCount() < 1)
			{
				if(MenuScene.Instance.GetRaycastDisableCount() < 1)
				{
					if (MenuScene.Instance.IsTransition())
						return;
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_004);
					m_layoutBg.PrevChangeBg();
				}
			}
		}

		//// RVA: 0xEE86E0 Offset: 0xEE86E0 VA: 0xEE86E0
		private void OnClickCardImage()
		{
			if(m_view.BADFIKBADNH_PickupId > 0)
			{
				if(!m_layoutBg.IsFading())
				{
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					GCIJNCFDNON_SceneInfo scene = new GCIJNCFDNON_SceneInfo();
					scene.IJIKIPDKCPP = m_view.EFCJADAPOMN ? 2 : 1;
					scene.KHEKNNFCAOI(m_view.BADFIKBADNH_PickupId, null, null, m_view.EFCJADAPOMN ? 1 : 0, 0, 0, false, 0, 0);
					m_layoutBg.SetChangeBgLoopState(true, -1);
					ShowSceneStatusPopup(scene, GameManager.Instance.ViewPlayerData, true, () =>
					{
						//0xEECBBC
						m_layoutBg.SetChangeBgLoopState(m_view.DPBDFPPMIPH_Gacha.MFICPBJPCCJ_GachaBgId > 0, -1);
					});
				}
			}
		}

		//// RVA: 0xEE895C Offset: 0xEE895C VA: 0xEE895C
		private void OnClickGachaDetail()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			if(!MenuScene.CheckDatelineAndAssetUpdate())
			{
				MenuScene.Instance.InputDisable();
				string s = GachaUtility.GetGachaDetailWebViewTemplate();
				MBCPNPNMFHB.HHCJCDFCLOB.FLLLPBIECCP(s, () =>
				{
					//0xEED2F4
					MenuScene.Instance.InputEnable();
				}, () =>
				{
					//0xEED390
					MenuScene.Instance.GotoTitle();
				});
			}
		}

		//// RVA: 0xEE8CB4 Offset: 0xEE8CB4 VA: 0xEE8CB4
		private void OnClickPurchaseButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			if (MenuScene.CheckDatelineAndAssetUpdate())
				return;
			this.StartCoroutineWatched(Co_PurchaseButton(null));
		}

		//// RVA: 0xEE8E48 Offset: 0xEE8E48 VA: 0xEE8E48
		private void OnClickBonusTicketPurchaseButton()
		{
			TodoLogger.LogNotImplemented("OnClickBonusTicketPurchaseButton");
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DD064 Offset: 0x6DD064 VA: 0x6DD064
		//// RVA: 0xEE8DA4 Offset: 0xEE8DA4 VA: 0xEE8DA4
		private IEnumerator Co_PurchaseButton(ProductListFilter filter)
		{
			//0xB6B1E8
			MenuScene.Instance.InputDisable();
			yield return Co.R(GachaUtility.OpenPurchaseVCWindow(MenuScene.Instance.DenomControl, () =>
			{
				//0xEECC38
				OnGachaNetError();
			}, (TransitionList.Type gotoSceneType) =>
			{
				//0xEED544
				if(gotoSceneType == TransitionList.Type.TITLE)
				{
					MenuScene.Instance.GotoTitle();
				}
				else if(gotoSceneType == TransitionList.Type.LOGIN_BONUS)
				{
					MenuScene.Instance.GotoLoginBonus();
				}
				MenuScene.Instance.InputEnable();
			}, filter));
			m_layoutHeaderInfo.Setup(m_view);
			MenuScene.Instance.InputEnable();
		}

		//// RVA: 0xEE9038 Offset: 0xEE9038 VA: 0xEE9038
		private void OnClickPassPurchaseButton()
		{
			TodoLogger.LogNotImplemented("OnClickPassPurchaseButton");
		}

		//// RVA: 0xEE9118 Offset: 0xEE9118 VA: 0xEE9118
		private void OnClickTicketConfirmButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			List<NKFJNAANPNP.MOJLCADLMKH> v = m_view.BNGLMLIMFDM();
			int v2 = m_view.DPBDFPPMIPH_Gacha.OMNAPCHLBHF(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.GOAHICNDICO_5);
			if (v2 == 0)
			{
				v2 = m_view.DPBDFPPMIPH_Gacha.OMNAPCHLBHF(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.LMHDFEKIDKG_6);
			}
			int v3 = 0;
			string s = "";
			if(m_view.DPBDFPPMIPH_Gacha.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON_GachaType.DLOPEFGOAPD_10)
			{
				v3 = m_view.DPBDFPPMIPH_Gacha.MJNOAMAFNHA_CostItemId;
				s = EKLNMHFCAOI.INCKKODFJAP_GetItemName(v3);
			}
			else
			{
				PMDCIJMMNGK_GachaTicket.EJAKHFONNGN tkt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GKMAHADAAFI_GachaTicket.AAJILEFHFGC(v2);
				if (tkt != null)
				{
					v3 = tkt.PPFNGGCBJKC_Id;
					s = EKLNMHFCAOI.INCKKODFJAP_GetItemName(v3);
				}
			}
			PopupItemPeriodComfirmListSetting setting = new PopupItemPeriodComfirmListSetting();
			setting.TitleText = string.Format(bk.GetMessageByLabel("item_use_period_title"), s);
			setting.WindowSize = SizeType.Middle;
			setting.TypeItemId = v3;
			setting.List = v;
			setting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			PopupWindowManager.Show(setting, null, null, null, null);
		}

		//// RVA: 0xEE9698 Offset: 0xEE9698 VA: 0xEE9698
		private void OnClickRarityChange()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			m_view.EFCJADAPOMN = !m_view.EFCJADAPOMN;
			m_layoutBg.SwitchRarity(m_view.EFCJADAPOMN);
			m_layoutLegalButton.SwitchRarity(m_view.EFCJADAPOMN);
		}

		//// RVA: 0xEE97B0 Offset: 0xEE97B0 VA: 0xEE97B0
		private void OnClickLegalDesc(Action callback)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MBCPNPNMFHB.HHCJCDFCLOB.MDGPGGLHIPB_ShowWebUrl(MHOILBOJFHL.KCAEDEHGAFO.LCCLAEBKMLD_Legals, () =>
			{
				//0xEEDE64
				if(callback != null)
					callback();
			}, () =>
			{
				//0xEEDE78
				MenuScene.Instance.GotoTitle();
				if(callback != null)
					callback();
			});
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DD0DC Offset: 0x6DD0DC VA: 0x6DD0DC
		//// RVA: 0xEE6A40 Offset: 0xEE6A40 VA: 0xEE6A40
		private IEnumerator Co_LoadResources()
		{
			//0xEEF32C
			this.StartCoroutineWatched(Co_LoadLayout());
			GachaUtility.InitPurchasePassWindow(transform);
			yield return Co.R(Co_WaitForLoaded());
			IsReady = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DD154 Offset: 0x6DD154 VA: 0x6DD154
		//// RVA: 0xEE9974 Offset: 0xEE9974 VA: 0xEE9974
		private IEnumerator Co_LoadLayout()
		{
			StringBuilder bundleName; // 0x14
			Font font; // 0x18
			int bundleLoadCount; // 0x1C
			AssetBundleLoadLayoutOperationBase layoutOp; // 0x20

			//0xEEE9FC
			bundleName = new StringBuilder();
			font = GameManager.Instance.GetSystemFont();
			bundleLoadCount = 0;
			bundleName.Set("ly/155.xab");
			layoutOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_gacha_bg_layout_root");
			yield return layoutOp;
			yield return Co.R(layoutOp.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0xEECC3C
				instance.transform.SetParent(transform, false);
				m_layoutBg = instance.GetComponent<LayoutGachaBg>();
			}));
			bundleLoadCount++;
			layoutOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_gacha_title_layout_root");
			yield return layoutOp;
			yield return Co.R(layoutOp.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0xEECD0C
				instance.transform.SetParent(transform, false);
				m_layoutTitle = instance.GetComponent<LayoutGachaTitle>();
			}));
			bundleLoadCount++;
			layoutOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_bannar_area_layout_root");
			yield return layoutOp;
			yield return Co.R(layoutOp.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0xEECDDC
				instance.transform.SetParent(transform, false);
				m_layoutBannerList = instance.GetComponent<LayoutGachaBannerList>();
			}));
			bundleLoadCount++;
			layoutOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_gacha_stone_layout_root");
			yield return layoutOp;
			yield return Co.R(layoutOp.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0xEECEAC
				instance.transform.SetParent(transform, false);
				m_layoutHeaderInfo = instance.GetComponent<LayoutGachaHeaderInfo>();
			}));
			bundleLoadCount++;
			layoutOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_gacha_legal_layout_root");
			yield return layoutOp;
			yield return Co.R(layoutOp.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0xEECF7C
				instance.transform.SetParent(transform, false);
				m_layoutLegalButton = instance.GetComponent<LayoutGachaLegalButton>();
			}));
			bundleLoadCount++;
			layoutOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_gacha_btn_layout_root");
			yield return layoutOp;
			yield return Co.R(layoutOp.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0xEED04C
				instance.transform.SetParent(transform, false);
				m_layoutDrawButtonGroup = instance.GetComponent<LayoutGachaDrawButtonGroup>();
			}));
			bundleLoadCount++;
			for(int i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DD1CC Offset: 0x6DD1CC VA: 0x6DD1CC
		//// RVA: 0xEE9A20 Offset: 0xEE9A20 VA: 0xEE9A20
		private IEnumerator Co_WaitForLoaded()
		{
			//0xB6B8BC
			while (m_layoutBg == null || !m_layoutBg.IsLoaded())
				yield return null;
			while (m_layoutTitle == null || !m_layoutTitle.IsLoaded())
				yield return null;
			while (m_layoutBannerList == null || !m_layoutBannerList.IsLoaded())
				yield return null;
			while (m_layoutHeaderInfo == null || !m_layoutHeaderInfo.IsLoaded())
				yield return null;
			while (m_layoutLegalButton == null || !m_layoutLegalButton.IsLoaded())
				yield return null;
			while (m_layoutDrawButtonGroup == null || !m_layoutDrawButtonGroup.IsLoaded())
				yield return null;
		}

		//// RVA: 0xEE9AA8 Offset: 0xEE9AA8 VA: 0xEE9AA8
		private void OnDoGachaSuccess(List<MFDJIFIIPJD> items)
		{
			GachaUtility.Register(items);
			MenuScene.Instance.GotoGachaDirection();
			if(!GameManager.Instance.IsTutorial)
				return;
			TodoLogger.LogError(1, "Tuto 21");
		}

		//// RVA: 0xEE9C74 Offset: 0xEE9C74 VA: 0xEE9C74
		private void OnGachaFewVC()
		{
			GachaUtility.OpenFewVCPopup(MenuScene.Instance.InputEnable);
		}

		//// RVA: 0xEE9D38 Offset: 0xEE9D38 VA: 0xEE9D38
		private void OnGachaNetError()
		{
			MenuScene.Instance.GotoTitle();
		}

		//// RVA: 0xEE9DD4 Offset: 0xEE9DD4 VA: 0xEE9DD4
		private void FetchAppearRate(Action onSuccess)
		{
			if(m_appearLot != null)
			{
				SetupAppearRate();
				onSuccess();
			}
			else
			{
				MenuScene.Instance.RaycastDisable();
				NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.CAILKLPCFHK(m_view.DPBDFPPMIPH_Gacha, () =>
				{
					//0xEEDF2C
					MenuScene.Instance.RaycastEnable();
					SetupAppearRate();
					onSuccess();
				}, () =>
				{
					//0xEED6A0
					MenuScene.Instance.RaycastEnable();
					MenuScene.Instance.GotoTitle();
				});
			}
		}

		//// RVA: 0xEEA0B4 Offset: 0xEEA0B4 VA: 0xEEA0B4
		private void SetupAppearRate()
		{
			m_rateInfoList.Clear();
			m_episodeInfoList.Clear();
			if (GachaUtility.selectCategory == GCAHJLOGMCI.KNMMOMEHDON_GachaType.BCBJMKDAAKA_8)
				MakeAppearRateForStepUp(-1);
			else
				MakeAppearRateForBasic();
		}

		//// RVA: 0xEEA36C Offset: 0xEEA36C VA: 0xEEA36C
		private void MakeAppearRateForBasic()
		{
			LOBDIAABMKG product = GachaUtility.netGachaProductData;
			HIMAFGJCECK limitedLot = product.OHBCGMINBDP(GachaUtility.netGachaCountForAppearRate, true);
			HIMAFGJCECK basicLot = product.OHBCGMINBDP(GachaUtility.netGachaCountForAppearRate, false);
			if(product.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON_GachaType.OOABDNHIEFK_9)
			{
				if (limitedLot == null)
				{
					if (GachaUtility.netGachaCountForAppearRate == GCAHJLOGMCI.NFCAJPIJFAM_SummonType.GOAHICNDICO_5)
					{
						limitedLot = product.OHBCGMINBDP(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.LMHDFEKIDKG_6, true);
					}
					else
					{
						limitedLot = product.OHBCGMINBDP(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.GOAHICNDICO_5, true);
					}
				}
				if(basicLot == null)
				{
					if (GachaUtility.netGachaCountForAppearRate == GCAHJLOGMCI.NFCAJPIJFAM_SummonType.GOAHICNDICO_5)
					{
						basicLot = product.OHBCGMINBDP(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.LMHDFEKIDKG_6, false);
					}
					else
					{
						basicLot = product.OHBCGMINBDP(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.GOAHICNDICO_5, false);
					}
				}
			}
			m_appearLot = new AppearLot(limitedLot, basicLot, product.KACECFNECON);
			MakeAppearRateInGroup(m_rateInfoList, m_appearLot);
			MakeAppearRateInEpisode(m_episodeInfoList, m_appearLot);
		}

		//// RVA: 0xEEA1AC Offset: 0xEEA1AC VA: 0xEEA1AC
		private void MakeAppearRateForStepUp(int stepIndex = -1)
		{
			LOBDIAABMKG product = GachaUtility.netGachaProductData;
			if (stepIndex < 0)
			{
				stepIndex = product.NECDFDNBHFK.LKHAAGIJEPG_PlayerStatus.DBNAGGGJDAB_CurrentStepIndex;
			}
			m_appearLot = new AppearLot(product.NLGPIELHAKC(stepIndex, true), product.NLGPIELHAKC(stepIndex, false), product.KACECFNECON);
			MakeAppearRateInGroup(m_rateInfoList, m_appearLot);
			MakeAppearRateInEpisode(m_episodeInfoList, m_appearLot);
		}

		//// RVA: 0xEEA548 Offset: 0xEEA548 VA: 0xEEA548
		private void MakeAppearRateInGroup(List<GachaRateInfo> infoList, AppearLot lot)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(lot.basic_groups != null)
			{
				BPADANIKFHP r6 = SelectRarity(lot.basic_groups, 6);
				BPADANIKFHP r5 = SelectRarity(lot.basic_groups, 5);
				BPADANIKFHP r4 = SelectRarity(lot.basic_groups, 4);
				BPADANIKFHP r3 = SelectRarity(lot.basic_groups, 3);
				BPADANIKFHP r2 = SelectRarity(lot.basic_groups, 2);
				BPADANIKFHP r1 = SelectRarity(lot.basic_groups, 1);
				GachaRateHeaderInfo info = new GachaRateHeaderInfo();
				info.isLimited = false;
				info.headerTitle = bk.GetMessageByLabel("popup_gacha_rate_basic_header");
				info.s6Percent = r6 != null ? r6.MMOJHIPAAIK : "";
				info.s5Percent = r5 != null ? r5.MMOJHIPAAIK : "";
				info.s4Percent = r4 != null ? r4.MMOJHIPAAIK : "";
				info.s3Percent = r3 != null ? r3.MMOJHIPAAIK : "";
				info.s2Percent = r2 != null ? r2.MMOJHIPAAIK : "";
				info.s1Percent = r1 != null ? r1.MMOJHIPAAIK : "";
				info.listTitle = bk.GetMessageByLabel("popup_gacha_rate_basic_list");
				infoList.Add(info);
				if (r6 != null)
					MakeAppearRateInGroup(infoList, r6, false);
				if (r5 != null)
					MakeAppearRateInGroup(infoList, r5, false);
				if (r4 != null)
					MakeAppearRateInGroup(infoList, r4, false);
				if (r3 != null)
					MakeAppearRateInGroup(infoList, r3, false);
				if (r2 != null)
					MakeAppearRateInGroup(infoList, r2, false);
				if (r1 != null)
					MakeAppearRateInGroup(infoList, r1, false);
			}
			if(lot.limited_episodes != null)
			{
				if(lot.basic_episodes != null)
				{
					infoList.Add(new GachaRateSeparatorInfo());
				}
			}
			if(lot.limited_groups != null)
			{
				BPADANIKFHP r6 = SelectRarity(lot.limited_groups, 6);
				BPADANIKFHP r5 = SelectRarity(lot.limited_groups, 5);
				BPADANIKFHP r4 = SelectRarity(lot.limited_groups, 4);
				GachaRateHeaderInfo info = new GachaRateHeaderInfo();
				info.isLimited = true;
				info.s6Percent = r6 != null ? r6.MMOJHIPAAIK : "";
				info.s5Percent = r5 != null ? r5.MMOJHIPAAIK : "";
				info.s4Percent = r4 != null ? r4.MMOJHIPAAIK : "";
				bool isHideRareMark = string.IsNullOrEmpty(info.s4Percent) && string.IsNullOrEmpty(info.s6Percent);
				bool isHideRareMark2 = string.IsNullOrEmpty(info.s4Percent) && string.IsNullOrEmpty(info.s5Percent);
				info.headerTitle = bk.GetMessageByLabel(lot.basic_groups == null ? "popup_gacha_rate_basic_header" : (isHideRareMark || isHideRareMark2 ? "popup_gacha_rate_limited5_header" : "popup_gacha_rate_limited_header"));
				info.listTitle = bk.GetMessageByLabel(lot.basic_groups == null ? "popup_gacha_rate_basic_list" : (isHideRareMark || isHideRareMark2 ? "popup_gacha_rate_limited5_list" : "popup_gacha_rate_limited_list"));
				infoList.Add(info);
				if (r6 != null)
					MakeAppearRateInGroup(infoList, r6, isHideRareMark2);
				if (r5 != null)
					MakeAppearRateInGroup(infoList, r5, isHideRareMark);
				if (r4 != null)
					MakeAppearRateInGroup(infoList, r4, false);
			}
			infoList.Add(new GachaRateSeparatorInfo());
			GachaRateMessageInfo info2 = new GachaRateMessageInfo();
			if (lot.extra_info != null && !string.IsNullOrEmpty(lot.extra_info.EIODHCIJDKO_Label))
				info2.message = bk.GetMessageByLabel(lot.extra_info.EIODHCIJDKO_Label);
			else
				info2.message = bk.GetMessageByLabel("popup_gacha_rate_warning");
			infoList.Add(info2);
		}

		//// RVA: 0xEEACCC Offset: 0xEEACCC VA: 0xEEACCC
		private void MakeAppearRateInEpisode(List<GachaRateInfo> infoList, GachaScene.AppearLot lot)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(lot.basic_episodes != null)
			{
				BPADANIKFHP r6 = SelectRarity(lot.basic_groups, 6);
				BPADANIKFHP r5 = SelectRarity(lot.basic_groups, 5);
				BPADANIKFHP r4 = SelectRarity(lot.basic_groups, 4);
				BPADANIKFHP r3 = SelectRarity(lot.basic_groups, 3);
				BPADANIKFHP r2 = SelectRarity(lot.basic_groups, 2);
				BPADANIKFHP r1 = SelectRarity(lot.basic_groups, 1);
				GachaRateHeaderInfo info = new GachaRateHeaderInfo();
				info.isLimited = false;
				info.headerTitle = bk.GetMessageByLabel("popup_gacha_rate_basic_header");
				info.s6Percent = r6 != null ? r6.MMOJHIPAAIK : "";
				info.s5Percent = r5 != null ? r5.MMOJHIPAAIK : "";
				info.s4Percent = r4 != null ? r4.MMOJHIPAAIK : "";
				info.s3Percent = r3 != null ? r3.MMOJHIPAAIK : "";
				info.s2Percent = r2 != null ? r2.MMOJHIPAAIK : "";
				info.s1Percent = r1 != null ? r1.MMOJHIPAAIK : "";
				info.listTitle = bk.GetMessageByLabel("popup_gacha_rate_basic_list");
				infoList.Add(info);
				for(int i = 0; i < lot.basic_episodes.Count; i++)
				{
					MakeAppearRateInEpisode(infoList, lot.basic_episodes[i]);
				}
			}
			if(lot.limited_episodes != null)
			{
				if(lot.basic_episodes != null)
				{
					infoList.Add(new GachaRateSeparatorInfo());
				}
			}
			if(lot.limited_episodes != null)
			{
				BPADANIKFHP r6 = SelectRarity(lot.limited_groups, 6);
				BPADANIKFHP r5 = SelectRarity(lot.limited_groups, 5);
				BPADANIKFHP r4 = SelectRarity(lot.limited_groups, 4);
				GachaRateHeaderInfo info = new GachaRateHeaderInfo();
				info.isLimited = true;
				info.s6Percent = r6 != null ? r6.MMOJHIPAAIK : "";
				info.s5Percent = r5 != null ? r5.MMOJHIPAAIK : "";
				info.s4Percent = r4 != null ? r4.MMOJHIPAAIK : "";
				bool isHideRareMark = string.IsNullOrEmpty(info.s4Percent) && string.IsNullOrEmpty(info.s6Percent);
				info.headerTitle = bk.GetMessageByLabel(lot.basic_groups == null ? "popup_gacha_rate_basic_header" : (isHideRareMark ? "popup_gacha_rate_limited5_header" : "popup_gacha_rate_limited_header"));
				info.listTitle = bk.GetMessageByLabel(lot.basic_groups == null ? "popup_gacha_rate_basic_list" : (isHideRareMark ? "popup_gacha_rate_limited5_list" : "popup_gacha_rate_limited_list"));
				infoList.Add(info);
				for (int i = 0; i < lot.limited_episodes.Count; i++)
				{
					MakeAppearRateInEpisode(infoList, lot.limited_episodes[i]);
				}
			}
			infoList.Add(new GachaRateSeparatorInfo());
			GachaRateMessageInfo info2 = new GachaRateMessageInfo();
			if (lot.extra_info != null && !string.IsNullOrEmpty(lot.extra_info.EIODHCIJDKO_Label))
				info2.message = bk.GetMessageByLabel(lot.extra_info.EIODHCIJDKO_Label);
			else
				info2.message = bk.GetMessageByLabel("popup_gacha_rate_warning");
			infoList.Add(info2);
		}

		//// RVA: 0xEEB604 Offset: 0xEEB604 VA: 0xEEB604
		private void MakeAppearRateInGroup(List<GachaRateInfo> infoList, BPADANIKFHP lot, bool isHideRareMark = false)
		{
			if(!isHideRareMark)
			{
				GachaRateRarityInfo info = new GachaRateRarityInfo();
				info.starNum = lot.EKLIPGELKCL;
				info.percent = lot.MMOJHIPAAIK;
				infoList.Add(info);
			}
			for(int i = 0; i < lot.HBHMAKNGKFK.Count; i++)
			{
				GachaRateItemInfo info = new GachaRateItemInfo();
				info.attribute = GetCardAttributeType(lot.HBHMAKNGKFK[i].JJBGOIMEIPF_ItemId);
				info.name = lot.HBHMAKNGKFK[i].JBLCNEILLMJ_ItemName;
				info.percent = lot.HBHMAKNGKFK[i].MMOJHIPAAIK_Probability;
				info.pickup = lot.HBHMAKNGKFK[i].JOPPFEHKNFO_IsPickup;
				infoList.Add(info);
			}
		}

		//// RVA: 0xEEB87C Offset: 0xEEB87C VA: 0xEEB87C
		private void MakeAppearRateInEpisode(List<GachaRateInfo> infoList, IJPECOFPOCH lot)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			GachaRateEpDetailInfo info = new GachaRateEpDetailInfo();
			info.episodeId = lot.GDEJFKCMNAC_EpisodeId;
			info.episodeContent = PIGBBNDPPJC.EJOJNFDHDHN_GetEpName(lot.GDEJFKCMNAC_EpisodeId);
			infoList.Add(info);
			for(int i = 0; i < lot.HBHMAKNGKFK.Count; i++)
			{
				GachaRateEpItemInfo info2 = new GachaRateEpItemInfo();
				info2.attribute = GetCardAttributeType(lot.HBHMAKNGKFK[i].JJBGOIMEIPF_ItemId);
				info2.name = lot.HBHMAKNGKFK[i].JBLCNEILLMJ_ItemName;
				info2.percent = lot.HBHMAKNGKFK[i].MMOJHIPAAIK_Probability;
				info2.pickup = lot.HBHMAKNGKFK[i].JOPPFEHKNFO_IsPickup;
				info2.starNum = lot.HBHMAKNGKFK[i].FJNGOPBGEOI_GroupIdx;
				infoList.Add(info2);
			}
		}

		//// RVA: 0xEEB4F0 Offset: 0xEEB4F0 VA: 0xEEB4F0
		private static BPADANIKFHP SelectRarity(List<BPADANIKFHP> groups, int rare)
		{
			for(int i = 0; i < groups.Count; i++)
			{
				if (groups[i].EKLIPGELKCL == rare)
					return groups[i];
			}
			return null;
		}

		//// RVA: 0xEEBB74 Offset: 0xEEBB74 VA: 0xEEBB74
		private static GameAttribute.Type GetCardAttributeType(int app_item_id)
		{
			int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(app_item_id);
			return (GameAttribute.Type)IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[id - 1].FKDCCLPGKDK_Ma;
		}

		//// RVA: 0xEEBCE4 Offset: 0xEEBCE4 VA: 0xEEBCE4
		private void OnClickTutorialAppearRate()
		{
			TodoLogger.LogNotImplemented("OnClickTutorialAppearRate");
		}

		//// RVA: 0xEEC0EC Offset: 0xEEC0EC VA: 0xEEC0EC
		private void OnClickAppearRate()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			if(!MenuScene.CheckDatelineAndAssetUpdate())
			{
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				m_gachaRatePopupSetting.TitleText = bk.GetMessageByLabel("popup_gacha_rate_title");
				m_gachaRatePopupSetting.SetParent(transform);
				m_gachaRatePopupSetting.Data = GachaUtility.netGachaProductData;
				m_gachaRatePopupSetting.Mode = GachaUtility.selectCategory;
				m_gachaRatePopupSetting.WindowSize = SizeType.Large;
				m_gachaRatePopupSetting.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				};
				m_gachaRatePopupSetting.Tabs = new PopupTabButton.ButtonLabel[2]
				{
					PopupTabButton.ButtonLabel.Rarity, PopupTabButton.ButtonLabel.Episode
				};
				m_gachaRatePopupSetting.DefaultTab = m_gachaRatePopupSetting.Tabs[0];
				m_gachaRatePopupSetting.OnClickRewardButton = OnClickEpisodeReward;
				m_gachaRatePopupSetting.OnClickStepButton = OnClickStepInfo;
				MenuScene.Instance.RaycastDisable();
				FetchAppearRate(() =>
				{
					//0xEEE008
					m_gachaRatePopupSetting.RarityInfoList = m_rateInfoList;
					m_gachaRatePopupSetting.EpisodeInfoList = m_episodeInfoList;
					PopupWindowManager.Show(m_gachaRatePopupSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
					{
						//0xEED768
						MenuScene.Instance.RaycastEnable();
					}, (IPopupContent content, PopupTabButton.ButtonLabel tabLabel) =>
					{
						//0xEED804
						PopupGachaRate c = content as PopupGachaRate;
						if(tabLabel == PopupTabButton.ButtonLabel.Episode)
						{
							c.SwitchToEpisodeContent();
						}
						else if(tabLabel == PopupTabButton.ButtonLabel.Rarity)
						{
							c.SwitchToRarityContent();
						}
					}, null, null);
				});
			}
		}

		//// RVA: 0xEEC680 Offset: 0xEEC680 VA: 0xEEC680
		private void OnClickEpisodeReward(int episodeId)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			m_episodeRewardPopupSetting.TitleText = MessageManager.Instance.GetMessage("menu", "popup_title_episode_01");
			m_episodeRewardPopupSetting.SetParent(transform);
			m_episodeRewardPopupSetting.WindowSize = SizeType.Large;
			m_episodeRewardPopupSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			PopupWindowManager.Show(m_episodeRewardPopupSetting, null, null, null, null);
		}

		//// RVA: 0xEEC948 Offset: 0xEEC948 VA: 0xEEC948
		private void OnClickStepInfo(int stepIndex)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			m_rateInfoList.Clear();
			m_episodeInfoList.Clear();
			MakeAppearRateForStepUp(stepIndex);
			m_gachaRatePopupSetting.RarityInfoList = m_rateInfoList;
			m_gachaRatePopupSetting.EpisodeInfoList = m_episodeInfoList;
		}
	}
}
