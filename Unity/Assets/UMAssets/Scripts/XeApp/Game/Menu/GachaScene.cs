using System;
using System.Collections;
using System.Collections.Generic;
using XeApp.Game.Gacha;

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
			//public void Init(int typeAndSeriesId, bool updateGachaProduct = True) { }
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
					limited_groups = limitedLot.OJGPPOKENLG;
					limited_episodes = limitedLot.DDGPEFEEKFP;
				}
				if(basicLot != null)
				{
					basic_groups = basicLot.OJGPPOKENLG;
					basic_episodes = basicLot.DDGPEFEEKFP;
				}
				if (extra != null)
					extra_info = extra;
			}

			// RVA: 0xB6C7DC Offset: 0xB6C7DC VA: 0xB6C7DC
			public AppearLot(ABPEPHGCNDA limitedLot, ABPEPHGCNDA basicLot, IKMBBPDBECA extra)
			{
				if (limitedLot != null)
				{
					limited_groups = limitedLot.OJGPPOKENLG;
					limited_episodes = limitedLot.DDGPEFEEKFP;
				}
				if (basicLot != null)
				{
					basic_groups = basicLot.OJGPPOKENLG;
					basic_episodes = basicLot.DDGPEFEEKFP;
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
				m_view.FBANBDCOEJL();
		}

		// RVA: 0xEE6AE0 Offset: 0xEE6AE0 VA: 0xEE6AE0 Slot: 16
		protected override void OnPreSetCanvas()
		{
			this.StartCoroutineWatched(Co_OnPreSetCanvas());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DCD94 Offset: 0x6DCD94 VA: 0x6DCD94
		//// RVA: 0xEE6B04 Offset: 0xEE6B04 VA: 0xEE6B04
		//private IEnumerator Co_OnPreSetCanvas() { }

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
		//private IEnumerator Co_OnActivateScene() { }

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
		//private void UpdatePurchased(DenominationManager.Response response) { }

		// RVA: 0xEE7290 Offset: 0xEE7290 VA: 0xEE7290 Slot: 25
		protected override void OnTutorial()
		{
			this.StartCoroutineWatched(Co_OnTutorial());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DCE84 Offset: 0x6DCE84 VA: 0x6DCE84
		//// RVA: 0xEE72B4 Offset: 0xEE72B4 VA: 0xEE72B4
		//private IEnumerator Co_OnTutorial() { }

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
			if(m_view.DPBDFPPMIPH == null || m_view.DPBDFPPMIPH.FDEBLMKEMLF_TypeAndSeriesId != product.FDEBLMKEMLF_TypeAndSeriesId)
			{
				//LAB_00eee614
				a = 0;
				if(product.MFICPBJPCCJ < 1)
				{
					a = product.HNKHCIDOKFF;
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
			while (m_view.CJOOOBKFMGJ())
				yield return null;
			MenuScene.Instance.InputEnable();
			if (endCallback != null)
				endCallback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DCF74 Offset: 0x6DCF74 VA: 0x6DCF74
		//// RVA: 0xEE7448 Offset: 0xEE7448 VA: 0xEE7448
		//private IEnumerator Co_ShowTutorial() { }

		//// RVA: 0xEE7074 Offset: 0xEE7074 VA: 0xEE7074
		//private void Release() { }

		//// RVA: 0xEE74D0 Offset: 0xEE74D0 VA: 0xEE74D0
		//private int FindRelatedEpisodeId(int cardId) { }

		//// RVA: 0xEE7600 Offset: 0xEE7600 VA: 0xEE7600
		//private void ShowSceneStatusPopup(GCIJNCFDNON sceneData, DFKGGBMFFGB playerData, bool isDiableLuckyLeaf, Action onClose) { }

		//// RVA: 0xEE7948 Offset: 0xEE7948 VA: 0xEE7948
		//private void OnTimeLimit() { }

		//// RVA: 0xEE7AE4 Offset: 0xEE7AE4 VA: 0xEE7AE4
		//private void ResetLotInfo() { }

		//// RVA: 0xEE7B18 Offset: 0xEE7B18 VA: 0xEE7B18
		//private void OnClickEpisodeReward() { }

		//// RVA: 0xEE7FE4 Offset: 0xEE7FE4 VA: 0xEE7FE4
		//private void OnClickEpisodeAppeal() { }

		//// RVA: 0xEE8188 Offset: 0xEE8188 VA: 0xEE8188
		//private void OnClickDrawGacha(int lotCount) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6DCFEC Offset: 0x6DCFEC VA: 0x6DCFEC
		//// RVA: 0xEE829C Offset: 0xEE829C VA: 0xEE829C
		//private IEnumerator OpenGachaPopup(GachaUtility.CountType type) { }

		//// RVA: 0xEE8340 Offset: 0xEE8340 VA: 0xEE8340
		//private void OnSwipeToLeft() { }

		//// RVA: 0xEE8510 Offset: 0xEE8510 VA: 0xEE8510
		//private void OnSwipeToRight() { }

		//// RVA: 0xEE86E0 Offset: 0xEE86E0 VA: 0xEE86E0
		//private void OnClickCardImage() { }

		//// RVA: 0xEE895C Offset: 0xEE895C VA: 0xEE895C
		//private void OnClickGachaDetail() { }

		//// RVA: 0xEE8CB4 Offset: 0xEE8CB4 VA: 0xEE8CB4
		//private void OnClickPurchaseButton() { }

		//// RVA: 0xEE8E48 Offset: 0xEE8E48 VA: 0xEE8E48
		//private void OnClickBonusTicketPurchaseButton() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6DD064 Offset: 0x6DD064 VA: 0x6DD064
		//// RVA: 0xEE8DA4 Offset: 0xEE8DA4 VA: 0xEE8DA4
		//private IEnumerator Co_PurchaseButton(ProductListFilter filter) { }

		//// RVA: 0xEE9038 Offset: 0xEE9038 VA: 0xEE9038
		//private void OnClickPassPurchaseButton() { }

		//// RVA: 0xEE9118 Offset: 0xEE9118 VA: 0xEE9118
		//private void OnClickTicketConfirmButton() { }

		//// RVA: 0xEE9698 Offset: 0xEE9698 VA: 0xEE9698
		//private void OnClickRarityChange() { }

		//// RVA: 0xEE97B0 Offset: 0xEE97B0 VA: 0xEE97B0
		//private void OnClickLegalDesc(Action callback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6DD0DC Offset: 0x6DD0DC VA: 0x6DD0DC
		//// RVA: 0xEE6A40 Offset: 0xEE6A40 VA: 0xEE6A40
		//private IEnumerator Co_LoadResources() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6DD154 Offset: 0x6DD154 VA: 0x6DD154
		//// RVA: 0xEE9974 Offset: 0xEE9974 VA: 0xEE9974
		//private IEnumerator Co_LoadLayout() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6DD1CC Offset: 0x6DD1CC VA: 0x6DD1CC
		//// RVA: 0xEE9A20 Offset: 0xEE9A20 VA: 0xEE9A20
		//private IEnumerator Co_WaitForLoaded() { }

		//// RVA: 0xEE9AA8 Offset: 0xEE9AA8 VA: 0xEE9AA8
		//private void OnDoGachaSuccess(List<MFDJIFIIPJD> items) { }

		//// RVA: 0xEE9C74 Offset: 0xEE9C74 VA: 0xEE9C74
		//private void OnGachaFewVC() { }

		//// RVA: 0xEE9D38 Offset: 0xEE9D38 VA: 0xEE9D38
		//private void OnGachaNetError() { }

		//// RVA: 0xEE9DD4 Offset: 0xEE9DD4 VA: 0xEE9DD4
		//private void FetchAppearRate(Action onSuccess) { }

		//// RVA: 0xEEA0B4 Offset: 0xEEA0B4 VA: 0xEEA0B4
		//private void SetupAppearRate() { }

		//// RVA: 0xEEA36C Offset: 0xEEA36C VA: 0xEEA36C
		//private void MakeAppearRateForBasic() { }

		//// RVA: 0xEEA1AC Offset: 0xEEA1AC VA: 0xEEA1AC
		//private void MakeAppearRateForStepUp(int stepIndex = -1) { }

		//// RVA: 0xEEA548 Offset: 0xEEA548 VA: 0xEEA548
		//private void MakeAppearRateInGroup(List<GachaRateInfo> infoList, GachaScene.AppearLot lot) { }

		//// RVA: 0xEEACCC Offset: 0xEEACCC VA: 0xEEACCC
		//private void MakeAppearRateInEpisode(List<GachaRateInfo> infoList, GachaScene.AppearLot lot) { }

		//// RVA: 0xEEB604 Offset: 0xEEB604 VA: 0xEEB604
		//private void MakeAppearRateInGroup(List<GachaRateInfo> infoList, BPADANIKFHP lot, bool isHideRareMark = False) { }

		//// RVA: 0xEEB87C Offset: 0xEEB87C VA: 0xEEB87C
		//private void MakeAppearRateInEpisode(List<GachaRateInfo> infoList, IJPECOFPOCH lot) { }

		//// RVA: 0xEEB4F0 Offset: 0xEEB4F0 VA: 0xEEB4F0
		//private static BPADANIKFHP SelectRarity(List<BPADANIKFHP> groups, int rare) { }

		//// RVA: 0xEEBB74 Offset: 0xEEBB74 VA: 0xEEBB74
		//private static GameAttribute.Type GetCardAttributeType(int app_item_id) { }

		//// RVA: 0xEEBCE4 Offset: 0xEEBCE4 VA: 0xEEBCE4
		//private void OnClickTutorialAppearRate() { }

		//// RVA: 0xEEC0EC Offset: 0xEEC0EC VA: 0xEEC0EC
		//private void OnClickAppearRate() { }

		//// RVA: 0xEEC680 Offset: 0xEEC680 VA: 0xEEC680
		//private void OnClickEpisodeReward(int episodeId) { }

		//// RVA: 0xEEC948 Offset: 0xEEC948 VA: 0xEEC948
		//private void OnClickStepInfo(int stepIndex) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6DD244 Offset: 0x6DD244 VA: 0x6DD244
		//// RVA: 0xEECB20 Offset: 0xEECB20 VA: 0xEECB20
		//private bool <Co_ShowTutorial>b__44_0(TutorialConditionId conditionId) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6DD254 Offset: 0x6DD254 VA: 0x6DD254
		//// RVA: 0xEECB84 Offset: 0xEECB84 VA: 0xEECB84
		//private bool <Co_ShowTutorial>b__44_1(TutorialConditionId conditionId) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6DD264 Offset: 0x6DD264 VA: 0x6DD264
		//// RVA: 0xEECBBC Offset: 0xEECBBC VA: 0xEECBBC
		//private void <OnClickCardImage>b__56_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6DD274 Offset: 0x6DD274 VA: 0x6DD274
		//// RVA: 0xEECC38 Offset: 0xEECC38 VA: 0xEECC38
		//private void <Co_PurchaseButton>b__60_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6DD284 Offset: 0x6DD284 VA: 0x6DD284
		//// RVA: 0xEECC3C Offset: 0xEECC3C VA: 0xEECC3C
		//private void <Co_LoadLayout>b__66_0(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6DD294 Offset: 0x6DD294 VA: 0x6DD294
		//// RVA: 0xEECD0C Offset: 0xEECD0C VA: 0xEECD0C
		//private void <Co_LoadLayout>b__66_1(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6DD2A4 Offset: 0x6DD2A4 VA: 0x6DD2A4
		//// RVA: 0xEECDDC Offset: 0xEECDDC VA: 0xEECDDC
		//private void <Co_LoadLayout>b__66_2(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6DD2B4 Offset: 0x6DD2B4 VA: 0x6DD2B4
		//// RVA: 0xEECEAC Offset: 0xEECEAC VA: 0xEECEAC
		//private void <Co_LoadLayout>b__66_3(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6DD2C4 Offset: 0x6DD2C4 VA: 0x6DD2C4
		//// RVA: 0xEECF7C Offset: 0xEECF7C VA: 0xEECF7C
		//private void <Co_LoadLayout>b__66_4(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6DD2D4 Offset: 0x6DD2D4 VA: 0x6DD2D4
		//// RVA: 0xEED04C Offset: 0xEED04C VA: 0xEED04C
		//private void <Co_LoadLayout>b__66_5(GameObject instance) { }
	}
}
