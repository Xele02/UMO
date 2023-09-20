using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class DecoScene : TransitionRoot
	{
		public enum StateType
		{
			Top = 0,
			MenuDisable = 1,
			EditMenuDisable = 2,
			SelectPostItem = 3,
			SelectEditItem = 4,
			Edit = 5,
			End = 6,
			Num = 7,
			None = -1,
		}

		public enum CharaAnimationType
		{
			Normal = 0,
			Wait = 1,
			None = 2,
		}

		public class StateControlData
		{
			public bool enableCanvasControl; // 0x8
			public DecorationItemManager.EnableControlType enableItemControl; // 0xC
			public CharaAnimationType charaAnim; // 0x10

			// RVA: 0x1587D14 Offset: 0x1587D14 VA: 0x1587D14
			public StateControlData(bool canvas, DecorationItemManager.EnableControlType item, CharaAnimationType chara)
			{
				enableCanvasControl = canvas;
				enableItemControl = item;
				charaAnim = chara;
			}
		}

		private struct StateLayoutData
		{
			public bool isLeftButtons; // 0x0
			public bool isRightButtons; // 0x1
			public bool isExchange; // 0x2
			public bool isLobbyButton; // 0x3
			public bool isItemLayout; // 0x4
			public bool isEditButton; // 0x5
			public bool isDecorator; // 0x6
			public bool isHelpButton; // 0x7
			public bool isIntimacyCounter; // 0x8
			public bool isMenuDisable; // 0x9

			// RVA: 0x7FCF1C Offset: 0x7FCF1C VA: 0x7FCF1C
			public StateLayoutData(bool leftButtons, bool rightButtons, bool exchange, bool lobbyButton, bool itemLayout, bool editButton, bool decorator, bool helpButton, bool intimacyCounter, bool menuDisable)
			{
				isLeftButtons = leftButtons;
				isRightButtons = rightButtons;
				isExchange = exchange;
				isLobbyButton = lobbyButton;
				isItemLayout = itemLayout;
				isEditButton = editButton;
				isDecorator = decorator;
				isHelpButton = helpButton;
				isIntimacyCounter = intimacyCounter;
				isMenuDisable = menuDisable;
			}
		}

		private struct ResetNewFlagData
		{
			public DecorationDecorator.DecoratorType m_type; // 0x0
			public DecorationDecorator.TabType m_tab; // 0x4
			public int m_charaId; // 0x8
		}

		private struct CategoryNewIconInfo
		{
			public bool isAnyNew; // 0x0
			public List<bool> isTabNewList; // 0x4

			//// RVA: 0x7FCDB4 Offset: 0x7FCDB4 VA: 0x7FCDB4
			//public void Init() { }
		}

		private struct NewIconInfo
		{
			public bool isEditButtonNew; // 0x0
			public CategoryNewIconInfo[] categoryInfos; // 0x4

			//// RVA: 0x7FCE18 Offset: 0x7FCE18 VA: 0x7FCE18
			//public void init() { }
		}

		private class DecoProductsPicker
		{
			//private List<KDKFHGHGFEK> items = new List<KDKFHGHGFEK>(); // 0x8
			private List<FJGOKILCBJA> products = new List<FJGOKILCBJA>(); // 0xC
			private Dictionary<EKLNMHFCAOI.FKGCBLHOOCL_Category, List<int>> indicesDic = new Dictionary<EKLNMHFCAOI.FKGCBLHOOCL_Category, List<int>>(); // 0x10

			//// RVA: 0x15870D8 Offset: 0x15870D8 VA: 0x15870D8
			//public void Create() { }

			//// RVA: 0x1587770 Offset: 0x1587770 VA: 0x1587770
			//public List<FJGOKILCBJA> GetProducts(List<int> indices, Predicate<KDKFHGHGFEK> itemFilter, Predicate<FJGOKILCBJA> productFilter) { }

			//// RVA: 0x1587A98 Offset: 0x1587A98 VA: 0x1587A98
			//public List<FJGOKILCBJA> GetProducts(EKLNMHFCAOI.FKGCBLHOOCL type, Predicate<KDKFHGHGFEK> itemFilter, Predicate<FJGOKILCBJA> productFilter) { }
		}

		private static readonly StateControlData[] StateControlTbl = new StateControlData[7]
			{
				new StateControlData(true, 1, CharaAnimationType.Normal),
				new StateControlData(true, 1, CharaAnimationType.Normal),
				new StateControlData(true, 0, CharaAnimationType.Wait),
				new StateControlData(true, 3, CharaAnimationType.Wait),
				new StateControlData(true, 0, CharaAnimationType.Wait),
				new StateControlData(true, 0, CharaAnimationType.Wait),
				new StateControlData(true, 3, CharaAnimationType.Wait)
			}; // 0x0
		private static readonly StateLayoutData[] StateLayoutDataTbl = new StateLayoutData[7]
			{
				new StateLayoutData(true, true, false, true, false, false, false, true, true, true),
				new StateLayoutData(false,false,false,false,false,false,false,false,false,false),
				new StateLayoutData(false,false,false,false,true,false,false,false,false,false),
				new StateLayoutData(false,false,true,false,false,false,true,true,false,true),
				new StateLayoutData(false,true,true,false,true,true,false,true,false,true),
				new StateLayoutData(false,false,false,false,true,false,false,false,false,false),
				new StateLayoutData(false,false,false,false,false,false,false,false,false,false)
			}; // 0x4
		[SerializeField]
		private DecorationScreenShotView m_screenShotViewPrefab; // 0x48
		[SerializeField]
		private GameObject m_captureLogoPrefab; // 0x4C
		[SerializeField]
		private Image m_serifAttacherCover; // 0x50
		[SerializeField]
		private const float MAGNITUDE_MIN = 30;
		private const int InvalidPriority = -1;
		private DecorationScreenShotView m_screenShotViewInstance; // 0x54
		private Action m_updater; // 0x58
		private DecorationCanvas m_decorationCanvas; // 0x5C
		private LayoutDecorationLeftButtons m_layoutDecorationLeftButtons; // 0x60
		private LayoutDecorationRightButtons01 m_layoutDecorationRightButtons01; // 0x64
		private LayoutDecorationLeftEditButton m_layoutDecorationLeftEditButton; // 0x68
		private LayoutDecorationRightEditButton m_layoutDecorationRightEditButton; // 0x6C
		private LayoutDecorationExchangeButton m_layoutDecorationExchangeButton; // 0x70
		private LayoutDecorationWin01Pos m_layoutDecorationPostWindow; // 0x74
		private LayoutDecorationSerifAttacher m_layoutDecorationSerifAttacher; // 0x78
		private LayoutDecorationMenuDisableButton m_layoutDecorationMenuDisableButton; // 0x7C
		private AHHPBMBBCFM_DecoPrivateSet m_decoPrivateSetData; // 0x80
		private DAJBODHMLAB_DecoPublicSet m_decoPublicSetData; // 0x84
		private TouchInfo m_beginTouch; // 0x88
		private GameObject m_decorationCanvasPrefab; // 0x8C
		private int m_playerId; // 0x90
		private StateType m_state = StateType.None; // 0x94
		private StateType m_oldState = StateType.None; // 0x98
		private bool m_isWaitOnPreSetCanvas; // 0x9C
		//private HNKMEOKCNBI m_netDecoVisitControl = new HNKMEOKCNBI(); // 0xA0
		//private CHKMLHDDPHO m_netDecoChargeControl; // 0xA4
		private List<BCGFHLIEKLJ_DecoItem.GNGFGEIAGJL> m_chargeTargets; // 0xA8
		//private DecorationSpCollectInfo m_decorationSpCollectInfo; // 0xAC
		//private PopupDecoSpCollectSetting m_decoSpCollectPopupSetting = new PopupDecoSpCollectSetting(); // 0xE0
		//private PopupDecoEnergyChargeSetting m_decoEnergyChargeSeeting = new PopupDecoEnergyChargeSetting(); // 0xE4
		//private PopupDecoSpItemListSetting m_decoSpItemListSetting = new PopupDecoSpItemListSetting(); // 0xE8
		//private PopupDecoSpItemLevelupePopupSetting m_decoSpItemLevelupSetting = new PopupDecoSpItemLevelupePopupSetting(); // 0xEC
		private PopupDecoOptionSetting m_decoOptionSetting = new PopupDecoOptionSetting(); // 0xF0
		private DecorationChara m_speakChara; // 0xF4
		private DecorationDecorator m_decorator; // 0xF8
		//private DecorationDecorator.DecoratorType m_decoratorType; // 0xFC
		//private DocorationSpItemRemovePopupSetting m_spItemRemovePopup = new DocorationSpItemRemovePopupSetting(); // 0x100
		private RectTransform m_touchGuardArea; // 0x104
		private List<int> exItemListupWork = new List<int>(); // 0x108
		private List<DecorationItemBase> m_allGetTargetList = new List<DecorationItemBase>(); // 0x10C
		private List<DecorationItemBase> m_removeTargetList = new List<DecorationItemBase>(); // 0x110
		private List<DecorationItemBase> m_levelUpTargetList = new List<DecorationItemBase>(); // 0x114
		private bool m_isKeepCanvas; // 0x118
		private bool m_isToExchangeScene; // 0x119
		//private PopupDecoCountSetting m_decoCountPopupSetting = new PopupDecoCountSetting(); // 0x11C
		private int m_objSettingMax; // 0x120
		private int m_charaSettingMax; // 0x124
		private List<int> m_spItemListupList = new List<int>(); // 0x128
		private DecorationMapNameController m_mapNameController; // 0x12C
		private DecoProductsPicker m_productsPicker = new DecoProductsPicker(); // 0x130
		//private Dictionary<DecorationDecorator.DecoratorType, Dictionary<DecorationDecorator.TabType, List<FJGOKILCBJA>>> m_productsCache = new Dictionary<DecorationDecorator.DecoratorType, Dictionary<DecorationDecorator.TabType, List<FJGOKILCBJA>>>(); // 0x134
		private bool m_canMenuEnable = true; // 0x138
		private StateType m_prevState; // 0x13C
		private DecorationItemManager.PostType m_postType; // 0x140
		private List<ResetNewFlagData> m_resetNewFlagList = new List<ResetNewFlagData>(); // 0x144
		private bool m_reloadSearchMember; // 0x148
		private SingleVoicePlayer m_voicePlayer; // 0x14C
		private bool m_cancelPlushToyReaction; // 0x150
		private int[] m_bgmIds; // 0x154
		private ButtonInfo[] decoCollectPopupButton001 = new ButtonInfo[1] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative } }; // 0x158
		private ButtonInfo[] decoCollectPopupButton002 = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.LevelUp, Type = PopupButton.ButtonType.Positive },
			}; // 0x15C
		private ButtonInfo[] decoCollectPopupButton003 = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Collection, Type = PopupButton.ButtonType.Positive },
			}; // 0x160
		private bool isExecute; // 0x164
		private bool isDoTake; // 0x165
		private Texture2D m_captureTexture; // 0x168
		private RenderTexture m_renderTexture; // 0x16C
		private Camera m_captureCamera; // 0x170
		private GameObject m_captureLogoInstance; // 0x174
		private Vector3 m_captureLogoBaseScale; // 0x178
		private string m_shareFilePath = ""; // 0x184

		// RVA: 0xC5B220 Offset: 0xC5B220 VA: 0xC5B220 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			SettingData();
			this.StartCoroutineWatched(Co_LoadingSeq());
			m_screenShotViewInstance = Instantiate(m_screenShotViewPrefab);
			m_screenShotViewInstance.transform.SetParent(transform, false);
			InitializeScreenShot();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_decoOptionSetting.TitleText = bk.GetMessageByLabel("pop_deco_option_title");
			m_decoOptionSetting.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive },
			};
			m_decoOptionSetting.WindowSize = 2;
			GameObject g = new GameObject("touchGuardArea");
			m_touchGuardArea = g.AddComponent<RectTransform>();
			g.AddComponent<LayoutUGUIHitOnly>();
			m_touchGuardArea.pivot = new Vector2(0.5f, 0.5f);
			m_touchGuardArea.anchorMin = new Vector2(0, 0);
			m_touchGuardArea.anchorMax = new Vector2(1, 1);
			m_touchGuardArea.transform.SetParent(transform, false);
			m_touchGuardArea.gameObject.SetActive(false);
			m_voicePlayer = gameObject.AddComponent<SingleVoicePlayer>();
			string home_bgm_id = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.EFEGBHACJAL("home_bgm_id", "0,0,0");
			string[] home_bgm_ids = home_bgm_id.Split(new char[] { ',' });
			if(home_bgm_ids.Length == 3)
			{
				m_bgmIds = new int[3];
				for (int i = 0; i < home_bgm_ids.Length; i++)
				{
					int.TryParse(home_bgm_ids[i], out m_bgmIds[i]);
				}
			}
			else
			{
				m_bgmIds = new int[1];
				m_bgmIds[0] = 27;
			}
		}

		// RVA: 0xC5C2E8 Offset: 0xC5C2E8 VA: 0xC5C2E8 Slot: 5
		protected override void Start()
		{
			return;
		}

		// RVA: 0xC5C2EC Offset: 0xC5C2EC VA: 0xC5C2EC Slot: 23
		protected override void OnActivateScene()
		{
			this.StartCoroutineWatched(Co_OnActivateScene());
			CreateShopProductList();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D1754 Offset: 0x6D1754 VA: 0x6D1754
		//// RVA: 0xC5C318 Offset: 0xC5C318 VA: 0xC5C318
		//private IEnumerator Co_OnActivateScene() { }

		// RVA: 0xC5C438 Offset: 0xC5C438 VA: 0xC5C438 Slot: 14
		protected override void OnDestoryScene()
		{
			MenuScene.Instance.LobbyButtonControl.OnPreLoadAnnounce = null;
			MenuScene.Instance.LobbyButtonControl.OnEndAnnounce = null;
			if(m_isToExchangeScene)
			{
				m_isToExchangeScene = false;
				MenuScene.Instance.InputEnable();
			}
			if(!m_isKeepCanvas)
			{
				StopAllVoice();
				m_decorationCanvas.SetActive(false);
			}
			ChangeState(6, 0);
			m_isKeepCanvas = false;
			m_postType = 3;
			m_decorationCanvas.OnDestoryScene();
		}

		// RVA: 0xC5C9DC Offset: 0xC5C9DC VA: 0xC5C9DC Slot: 20
		protected override bool OnBgmStart()
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			int id = BgControl.GetHomeBgId(time);
			int idx = id - 1;
			if (m_bgmIds.Length < idx)
				idx = 0;
			SoundManager.Instance.bgmPlayer.ContinuousPlay(m_bgmIds[idx] + BgmPlayer.MENU_BGM_ID_BASE, 1);
		}

		//// RVA: 0xC5B990 Offset: 0xC5B990 VA: 0xC5B990
		//private void SettingData() { }

		// RVA: 0xC5CC4C Offset: 0xC5CC4C VA: 0xC5CC4C
		private void Update()
		{
			if (!IsReady)
				return;
			if (m_updater != null)
				m_updater();
		}

		//// RVA: 0xC5CC84 Offset: 0xC5CC84 VA: 0xC5CC84
		//private void UpdateIdle() { }

		//// RVA: 0xC5CC88 Offset: 0xC5CC88 VA: 0xC5CC88
		//private void UpdateTouchMenuDisbale() { }

		// RVA: 0xC5D0F4 Offset: 0xC5D0F4 VA: 0xC5D0F4 Slot: 16
		protected override void OnPreSetCanvas()
		{
			if (Args != null && Args is DecoArgs)
				m_playerId = (Args as DecoArgs).playerId;
			DecoVisitScene.transitionType = 1;
			this.StartCoroutineWatched(Co_OnPreSetCanvas());
		}

		// RVA: 0xC5D278 Offset: 0xC5D278 VA: 0xC5D278 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return !m_isWaitOnPreSetCanvas && base.IsEndPreSetCanvas();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D17CC Offset: 0x6D17CC VA: 0x6D17CC
		//// RVA: 0xC5D1F0 Offset: 0xC5D1F0 VA: 0xC5D1F0
		//private IEnumerator Co_OnPreSetCanvas() { }

		//// RVA: 0xC5D290 Offset: 0xC5D290 VA: 0xC5D290
		//private void OnError() { }

		// RVA: 0xC5D3A4 Offset: 0xC5D3A4 VA: 0xC5D3A4 Slot: 15
		protected override void OnDeleteCache()
		{
			if (m_decorationCanvasPrefab != null)
				Destroy(m_decorationCanvasPrefab);
			Destroy(m_layoutDecorationRightButtons01);
			AssetBundleManager.UnloadAssetBundle(DecorationConstants.BundleName, false);
		}

		// RVA: 0xC5D530 Offset: 0xC5D530 VA: 0xC5D530 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			if (PrevTransition == TransitionList.Type.SHOP_PRODUCT)
			{
				if (m_oldState == StateType.SelectPostItem)
					ChangeState(3, 0);
				else
					ChangeState(4, 0);
			}
			else
				ChangeState(0, 0);
		}

		// RVA: 0xC5D578 Offset: 0xC5D578 VA: 0xC5D578 Slot: 12
		protected override void OnStartExitAnimation()
		{
			ChangeState(6, 0);
		}

		// RVA: 0xC5D584 Offset: 0xC5D584 VA: 0xC5D584 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return IsPlayingEnd();
		}

		// RVA: 0xC5D588 Offset: 0xC5D588 VA: 0xC5D588 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return IsPlayingEnd();
		}

		//// RVA: 0xC5CF5C Offset: 0xC5CF5C VA: 0xC5CF5C
		//private bool IsPlayingEnd() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D1844 Offset: 0x6D1844 VA: 0x6D1844
		//// RVA: 0xC5BF14 Offset: 0xC5BF14 VA: 0xC5BF14
		//private IEnumerator Co_LoadingSeq() { }

		//// RVA: 0xC5D58C Offset: 0xC5D58C VA: 0xC5D58C
		//private bool CheckVisitItem() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D18BC Offset: 0x6D18BC VA: 0x6D18BC
		//// RVA: 0xC5D748 Offset: 0xC5D748 VA: 0xC5D748
		//private IEnumerator Co_LoadSetDecoData(IMCBBOAFION onSuccess, DJBHIFLHJLK onError) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D1934 Offset: 0x6D1934 VA: 0x6D1934
		//// RVA: 0xC5D804 Offset: 0xC5D804 VA: 0xC5D804
		//private IEnumerator Co_LoadVisitItem() { }

		//// RVA: 0xC5D88C Offset: 0xC5D88C VA: 0xC5D88C
		//private void SettingVisitItem(out int resourceId, out DecorationItemBaseSetting setting) { }

		//// RVA: 0xC5C7DC Offset: 0xC5C7DC VA: 0xC5C7DC
		//public void ChangeState(DecoScene.StateType state, DecorationConstants.Attribute.Type type = 0) { }

		//// RVA: 0xC5D980 Offset: 0xC5D980 VA: 0xC5D980
		//private void PreLayoutControl() { }

		//// RVA: 0xC5E194 Offset: 0xC5E194 VA: 0xC5E194
		//private void PostLayoutControl() { }

		//// RVA: 0xC5D8C8 Offset: 0xC5D8C8 VA: 0xC5D8C8
		//private void EnableControllerControl(bool enableCanvas, DecorationItemManager.EnableControlType enableControlType, DecoScene.CharaAnimationType charaAnimationType) { }

		//// RVA: 0xC5DB20 Offset: 0xC5DB20 VA: 0xC5DB20
		//private void LayoutControl(DecoScene.StateType m_state, DecoScene.StateType oldState, DecorationConstants.Attribute.Type type = 0) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D19AC Offset: 0x6D19AC VA: 0x6D19AC
		//// RVA: 0xC5E5D0 Offset: 0xC5E5D0 VA: 0xC5E5D0
		//private IEnumerator Co_LoadCanvas() { }

		//// RVA: 0xC5E658 Offset: 0xC5E658 VA: 0xC5E658
		//private void OnClickSerifButton(DecorationItemBase item) { }

		//// RVA: 0xC5EC5C Offset: 0xC5EC5C VA: 0xC5EC5C
		//private void OnClickPriorityButton() { }

		//// RVA: 0xC5EE04 Offset: 0xC5EE04 VA: 0xC5EE04
		//private void OnClickFlipButton() { }

		//// RVA: 0xC5EE70 Offset: 0xC5EE70 VA: 0xC5EE70
		//private void OnClickKiraButton(DecorationItemBase item, bool isKira) { }

		//// RVA: 0xC5EE74 Offset: 0xC5EE74 VA: 0xC5EE74
		//private void CreateItemCallback(DecorationItemBase item) { }

		//// RVA: 0xC5EFFC Offset: 0xC5EFFC VA: 0xC5EFFC
		//private void SelectItemCallback(DecorationItemBase item) { }

		//// RVA: 0xC5F0D0 Offset: 0xC5F0D0 VA: 0xC5F0D0
		//private void PostPossibleCallback(bool isPosssible) { }

		//// RVA: 0xC5F0D4 Offset: 0xC5F0D4 VA: 0xC5F0D4
		//private void TouchLeaveCallback() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D1A24 Offset: 0x6D1A24 VA: 0x6D1A24
		//// RVA: 0xC5F23C Offset: 0xC5F23C VA: 0xC5F23C
		//private IEnumerator Co_LoadMaterial() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D1A9C Offset: 0x6D1A9C VA: 0x6D1A9C
		//// RVA: 0xC5F2C4 Offset: 0xC5F2C4 VA: 0xC5F2C4
		//private IEnumerator Co_LoadAllBackDecoration() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D1B14 Offset: 0x6D1B14 VA: 0x6D1B14
		//// RVA: 0xC5F34C Offset: 0xC5F34C VA: 0xC5F34C
		//private IEnumerator Co_LoadLayout() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D1B8C Offset: 0x6D1B8C VA: 0x6D1B8C
		//// RVA: 0xC5F3D4 Offset: 0xC5F3D4 VA: 0xC5F3D4
		//public IEnumerator Co_LoadCanvasPrefab() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D1C04 Offset: 0x6D1C04 VA: 0x6D1C04
		//// RVA: 0xC5F45C Offset: 0xC5F45C VA: 0xC5F45C
		//private IEnumerator Co_LoadLeftButtons() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D1C7C Offset: 0x6D1C7C VA: 0x6D1C7C
		//// RVA: 0xC5F4E4 Offset: 0xC5F4E4 VA: 0xC5F4E4
		//private IEnumerator Co_LoadRightButtons01() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D1CF4 Offset: 0x6D1CF4 VA: 0x6D1CF4
		//// RVA: 0xC5F56C Offset: 0xC5F56C VA: 0xC5F56C
		//private IEnumerator Co_LoadLeftEditButton() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D1D6C Offset: 0x6D1D6C VA: 0x6D1D6C
		//// RVA: 0xC5F5F4 Offset: 0xC5F5F4 VA: 0xC5F5F4
		//private IEnumerator Co_LoadRightEditButton() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D1DE4 Offset: 0x6D1DE4 VA: 0x6D1DE4
		//// RVA: 0xC5F67C Offset: 0xC5F67C VA: 0xC5F67C
		//private IEnumerator Co_LoadExchangeButton() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D1E5C Offset: 0x6D1E5C VA: 0x6D1E5C
		//// RVA: 0xC5F704 Offset: 0xC5F704 VA: 0xC5F704
		//private IEnumerator Co_LoadPostWindow() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D1ED4 Offset: 0x6D1ED4 VA: 0x6D1ED4
		//// RVA: 0xC5F78C Offset: 0xC5F78C VA: 0xC5F78C
		//private IEnumerator Co_LoadSerifAttacher() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D1F4C Offset: 0x6D1F4C VA: 0x6D1F4C
		//// RVA: 0xC5F814 Offset: 0xC5F814 VA: 0xC5F814
		//private IEnumerator Co_LoadDecorator() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D1FC4 Offset: 0x6D1FC4 VA: 0x6D1FC4
		//// RVA: 0xC5F89C Offset: 0xC5F89C VA: 0xC5F89C
		//private IEnumerator Co_LoadMenuDisableButton() { }

		//// RVA: 0xC5EA60 Offset: 0xC5EA60 VA: 0xC5EA60
		//private void UpdateItemSelectWindowButton(DecorationDecorator.DecoratorType type) { }

		//// RVA: 0xC5F924 Offset: 0xC5F924 VA: 0xC5F924
		//private void UpdateSerifSelectWindowButton(bool enable) { }

		//// RVA: 0xC5E518 Offset: 0xC5E518 VA: 0xC5E518
		//private void UpdatePostLayout(EKLNMHFCAOI.FKGCBLHOOCL ctg) { }

		//// RVA: 0xC5FB20 Offset: 0xC5FB20 VA: 0xC5FB20
		//private void UpdateDecoNumLayout() { }

		//// RVA: 0xC5FB78 Offset: 0xC5FB78 VA: 0xC5FB78
		//private void MakeCategoryNewIconInfo(ref DecoScene.CategoryNewIconInfo info, DecorationDecorator.DecoratorType type, int charaId = -1) { }

		//// RVA: 0xC60078 Offset: 0xC60078 VA: 0xC60078
		//private void MakeNewIconInfo(ref DecoScene.NewIconInfo info) { }

		//// RVA: 0xC5E204 Offset: 0xC5E204 VA: 0xC5E204
		//private void ResetNewFlag() { }

		//// RVA: 0xC60144 Offset: 0xC60144 VA: 0xC60144
		//private void ResetNewFlag(DecoScene.ResetNewFlagData flag) { }

		//// RVA: 0xC61BE0 Offset: 0xC61BE0 VA: 0xC61BE0
		//private DecorationDecorator.DecoratorType GetDecorationType(NDBFKHKMMCE.ANMODBDBNPK.DBAMIACJODJ itemCategory) { }

		//// RVA: 0xC61C0C Offset: 0xC61C0C VA: 0xC61C0C
		//private NDBFKHKMMCE.ANMODBDBNPK.DBAMIACJODJ GetItemCategory(DecorationDecorator.DecoratorType decoratorType) { }

		//// RVA: 0xC5FEC8 Offset: 0xC5FEC8 VA: 0xC5FEC8
		//private List<List<KDKFHGHGFEK>> CreateCategoryItemLists(DecorationDecorator.DecoratorType type, int charaId = -1) { }

		//// RVA: 0xC5FA70 Offset: 0xC5FA70 VA: 0xC5FA70
		//private void UpdateItemPostLayout() { }

		//// RVA: 0xC5F9C0 Offset: 0xC5F9C0 VA: 0xC5F9C0
		//private void UpdateCharaPostLayout() { }

		//// RVA: 0xC5F1F8 Offset: 0xC5F1F8 VA: 0xC5F1F8
		//private bool IsOverPostItem() { }

		//// RVA: 0xC5F1B4 Offset: 0xC5F1B4 VA: 0xC5F1B4
		//private bool IsOverPostChara() { }

		//// RVA: 0xC61C34 Offset: 0xC61C34 VA: 0xC61C34
		//private void OnClickShowEditButton(bool isOpen) { }

		//// RVA: 0xC61EC8 Offset: 0xC61EC8 VA: 0xC61EC8
		//private void OnClickEditButton(DecorationDecorator.DecoratorType type) { }

		//// RVA: 0xC61F3C Offset: 0xC61F3C VA: 0xC61F3C
		//private void OnClickEditMaxButton(DecorationDecorator.DecoratorType type) { }

		//// RVA: 0xC61F68 Offset: 0xC61F68 VA: 0xC61F68
		//private void ShowPostMaxPopup(DecorationDecorator.DecoratorType type) { }

		//// RVA: 0xC5EFDC Offset: 0xC5EFDC VA: 0xC5EFDC
		//private bool CheckOverPost(DecorationDecorator.DecoratorType type) { }

		//// RVA: 0xC622E8 Offset: 0xC622E8 VA: 0xC622E8
		//private void OnClickDecoButton() { }

		//// RVA: 0xC62608 Offset: 0xC62608 VA: 0xC62608
		//private void ClickHomeButton() { }

		//// RVA: 0xC62784 Offset: 0xC62784 VA: 0xC62784
		//private void ClickVisitButton() { }

		//// RVA: 0xC62978 Offset: 0xC62978 VA: 0xC62978
		//private void ClickDecoBoardButton() { }

		//// RVA: 0xC62B7C Offset: 0xC62B7C VA: 0xC62B7C
		//private void ClickAllGetButton() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D203C Offset: 0x6D203C VA: 0x6D203C
		//// RVA: 0xC62C98 Offset: 0xC62C98 VA: 0xC62C98
		//private IEnumerator Co_DoAllGet() { }

		//// RVA: 0xC62D20 Offset: 0xC62D20 VA: 0xC62D20
		//public void ClickMenuDisableButton() { }

		//// RVA: 0xC62DB4 Offset: 0xC62DB4 VA: 0xC62DB4
		//private void OnClickMapChageButton() { }

		//// RVA: 0xC62F18 Offset: 0xC62F18 VA: 0xC62F18
		//private void OnClickMapNameEditButton() { }

		//// RVA: 0xC63178 Offset: 0xC63178 VA: 0xC63178
		//private void NoChangeMapName() { }

		//// RVA: 0xC63184 Offset: 0xC63184 VA: 0xC63184
		//private void TryChangeMapName(string mapName) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D20B4 Offset: 0x6D20B4 VA: 0x6D20B4
		//// RVA: 0xC63250 Offset: 0xC63250 VA: 0xC63250
		//private IEnumerator Co_TryChangeMapName(string mapName) { }

		//// RVA: 0xC62150 Offset: 0xC62150 VA: 0xC62150
		//private void SetEnableControllerTapGuard(bool isEnable) { }

		//// RVA: 0xC632F4 Offset: 0xC632F4 VA: 0xC632F4
		//private void NewPostItemCallback(LayoutDecorationSelectItemBase item, bool isTapSelect) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D212C Offset: 0x6D212C VA: 0x6D212C
		//// RVA: 0xC63378 Offset: 0xC63378 VA: 0xC63378
		//private IEnumerator Co_NewPostItem(LayoutDecorationSelectItemBase item, bool isTapSelect) { }

		//// RVA: 0xC63434 Offset: 0xC63434 VA: 0xC63434
		//private void OnClickChangeTab(DecorationDecorator.TabType tab) { }

		//// RVA: 0xC6419C Offset: 0xC6419C VA: 0xC6419C
		//private void BuyItemCallback() { }

		//// RVA: 0xC6467C Offset: 0xC6467C VA: 0xC6467C
		//private void ChangeBg(int id, int subId) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D21A4 Offset: 0x6D21A4 VA: 0x6D21A4
		//// RVA: 0xC64774 Offset: 0xC64774 VA: 0xC64774
		//private IEnumerator PostSerif(LayoutDecorationSelectItemBase item) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D221C Offset: 0x6D221C VA: 0x6D221C
		//// RVA: 0xC64818 Offset: 0xC64818 VA: 0xC64818
		//private IEnumerator PostItem(LayoutDecorationSelectItemBase item, bool isTapSelect = True) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D2294 Offset: 0x6D2294 VA: 0x6D2294
		//// RVA: 0xC648D4 Offset: 0xC648D4 VA: 0xC648D4
		//private IEnumerator Co_LoadItem(int resourceId, DecorationItemBaseSetting setting, DecorationItemArgsBase args) { }

		//// RVA: 0xC649A8 Offset: 0xC649A8 VA: 0xC649A8
		//private void OnClickExchangeButton() { }

		//// RVA: 0xC64DB0 Offset: 0xC64DB0 VA: 0xC64DB0
		//private void OnClickFriendSearchButton() { }

		//// RVA: 0xC60DF0 Offset: 0xC60DF0 VA: 0xC60DF0
		//private List<KDKFHGHGFEK> CreateSelectItemDataList(DecorationDecorator.DecoratorType type, DecorationDecorator.TabType tab, int charaId = -1) { }

		//// RVA: 0xC64040 Offset: 0xC64040 VA: 0xC64040
		//private int MakeType(DecorationDecorator.DecoratorType type, DecorationDecorator.TabType tab) { }

		//// RVA: 0xC63894 Offset: 0xC63894 VA: 0xC63894
		//private void SortItemList(ref List<KDKFHGHGFEK> selectList) { }

		//// RVA: 0xC5C3A0 Offset: 0xC5C3A0 VA: 0xC5C3A0
		//private void CreateShopProductList() { }

		//// RVA: 0xC639EC Offset: 0xC639EC VA: 0xC639EC
		//private List<FJGOKILCBJA> GetProductList(DecorationDecorator.DecoratorType type, DecorationDecorator.TabType tab) { }

		//// RVA: 0xC64EC4 Offset: 0xC64EC4 VA: 0xC64EC4
		//private void ItemPointerDownCallback(DecorationItemBase item) { }

		//// RVA: 0xC64EC8 Offset: 0xC64EC8 VA: 0xC64EC8
		//private void ItemClickCallback(DecorationItemBase item) { }

		//// RVA: 0xC65168 Offset: 0xC65168 VA: 0xC65168
		//private void PointerDownPlushToyItem(DecorationSp item) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D230C Offset: 0x6D230C VA: 0x6D230C
		//// RVA: 0xC652E8 Offset: 0xC652E8 VA: 0xC652E8
		//private IEnumerator CO_PointerDownPlushToyItem(DecorationSp item) { }

		//// RVA: 0xC65018 Offset: 0xC65018 VA: 0xC65018
		//private void PointerDownCollectionItem(DecorationItemBase item) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D2384 Offset: 0x6D2384 VA: 0x6D2384
		//// RVA: 0xC6538C Offset: 0xC6538C VA: 0xC6538C
		//private IEnumerator Co_PointerDownCollectionItem(DecorationItemBase item) { }

		//// RVA: 0xC65430 Offset: 0xC65430 VA: 0xC65430
		//private void UpdateSpItemStatus() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D23FC Offset: 0x6D23FC VA: 0x6D23FC
		//// RVA: 0xC6560C Offset: 0xC6560C VA: 0xC6560C
		//private IEnumerator Co_DecoSpPopupAction(PopupButton.ButtonType type, PopupButton.ButtonLabel label, long currentTime, DecorationItemBase item, int id) { }

		//// RVA: 0xC65728 Offset: 0xC65728 VA: 0xC65728
		//private void MakeSpCollectInfo(DecorationItemBase item, long currentTime) { }

		//// RVA: 0xC6503C Offset: 0xC6503C VA: 0xC6503C
		//private void PointerDownTransporter(DecorationItemBase item) { }

		//// RVA: 0xC66620 Offset: 0xC66620 VA: 0xC66620
		//private void OnClickAllRemoveButton() { }

		//// RVA: 0xC66718 Offset: 0xC66718 VA: 0xC66718
		//private void OnClickRemoveButton() { }

		//// RVA: 0xC66810 Offset: 0xC66810 VA: 0xC66810
		//private void OnClickSaveButton() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D2474 Offset: 0x6D2474 VA: 0x6D2474
		//// RVA: 0xC66880 Offset: 0xC66880 VA: 0xC66880
		//private IEnumerator Co_SaveButton() { }

		//// RVA: 0xC5E528 Offset: 0xC5E528 VA: 0xC5E528
		//private void EnterEditButton() { }

		//// RVA: 0xC5E580 Offset: 0xC5E580 VA: 0xC5E580
		//private void LeaveEditButton() { }

		//// RVA: 0xC5ECC8 Offset: 0xC5ECC8 VA: 0xC5ECC8
		//private void UpdateEditButton() { }

		//// RVA: 0xC66908 Offset: 0xC66908 VA: 0xC66908
		//private void UpdateAllBackButton() { }

		//// RVA: 0xC66934 Offset: 0xC66934 VA: 0xC66934
		//private bool IsMatchSaveData() { }

		//// RVA: 0xC66B30 Offset: 0xC66B30 VA: 0xC66B30
		//private DAJBODHMLAB.MMLACIFMNBN DecorationItemToDecoSet(ref List<bool> isMoved) { }

		//// RVA: 0xC673A0 Offset: 0xC673A0 VA: 0xC673A0
		//private DAJBODHMLAB.MMLACIFMNBN.MHODOAJPNHD CreateItemInfo(DecorationItemBase item) { }

		//// RVA: 0xC66D9C Offset: 0xC66D9C VA: 0xC66D9C
		//private bool IsMatchBg(DAJBODHMLAB.MMLACIFMNBN lhs, DAJBODHMLAB.MMLACIFMNBN rhs) { }

		//// RVA: 0xC67064 Offset: 0xC67064 VA: 0xC67064
		//private bool IsMatchItem(DAJBODHMLAB.MMLACIFMNBN.MHODOAJPNHD lhs, DAJBODHMLAB.MMLACIFMNBN.MHODOAJPNHD rhs) { }

		//// RVA: 0xC675EC Offset: 0xC675EC VA: 0xC675EC
		//private bool IsSameItem(DAJBODHMLAB.MMLACIFMNBN.MHODOAJPNHD lhs, DAJBODHMLAB.MMLACIFMNBN.MHODOAJPNHD rhs) { }

		//// RVA: 0xC6764C Offset: 0xC6764C VA: 0xC6764C
		//private void RemovePublicSetDataVisitItem() { }

		//// RVA: 0xC67810 Offset: 0xC67810 VA: 0xC67810
		//public void OnClickAllBackButton() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D24EC Offset: 0x6D24EC VA: 0x6D24EC
		//// RVA: 0xC67880 Offset: 0xC67880 VA: 0xC67880
		//private IEnumerator Co_AllBack() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D2564 Offset: 0x6D2564 VA: 0x6D2564
		//// RVA: 0xC67908 Offset: 0xC67908 VA: 0xC67908
		//private IEnumerator Co_SavePlayerData(DJBHIFLHJLK onError) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D25DC Offset: 0x6D25DC VA: 0x6D25DC
		//// RVA: 0xC67990 Offset: 0xC67990 VA: 0xC67990
		//private IEnumerator Co_SavePublicData(Action endCallback, DJBHIFLHJLK onError) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D2654 Offset: 0x6D2654 VA: 0x6D2654
		//// RVA: 0xC67A4C Offset: 0xC67A4C VA: 0xC67A4C
		//public static IEnumerator Co_UpdateDirtyTime() { }

		//// RVA: 0xC67ABC Offset: 0xC67ABC VA: 0xC67ABC
		//private void SendSetDecoItemLogs() { }

		//// RVA: 0xC68960 Offset: 0xC68960 VA: 0xC68960
		//private void SettingDecoPublicSetData() { }

		//// RVA: 0xC69F9C Offset: 0xC69F9C VA: 0xC69F9C
		//private void SendPushMessage(int itemId, long chargeTime, long chargeTimeOffset) { }

		//// RVA: 0xC69BAC Offset: 0xC69BAC VA: 0xC69BAC
		//public static void SendPushMessage(NDBFKHKMMCE.FIDBAFHNGCF spItemMaster, int currentLevel, long chargeTime, long chargeTimeOffset) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D26CC Offset: 0x6D26CC VA: 0x6D26CC
		//// RVA: 0xC5EBB8 Offset: 0xC5EBB8 VA: 0xC5EBB8
		//public IEnumerator Co_LoadPostSelectItems(DecorationDecorator.DecoratorType type) { }

		//// RVA: 0xC64390 Offset: 0xC64390 VA: 0xC64390
		//private void SetResetNewFlag(DecorationDecorator.DecoratorType type, DecorationDecorator.TabType tab) { }

		//// RVA: 0xC5E3A8 Offset: 0xC5E3A8 VA: 0xC5E3A8
		//private void UpdateRightButtonNewIcon() { }

		//// RVA: 0xC642C0 Offset: 0xC642C0 VA: 0xC642C0
		//private void UpdateNewIcon() { }

		//// RVA: 0xC64330 Offset: 0xC64330 VA: 0xC64330
		//private void UpdateSerifNewIcon(int charaId) { }

		//// RVA: 0xC5E838 Offset: 0xC5E838 VA: 0xC5E838
		//private void SettingWindowButton(DecorationDecorator.DecoratorType type) { }

		//// RVA: 0xC6A22C Offset: 0xC6A22C VA: 0xC6A22C
		//private void OnClickCloseSerifButton() { }

		//// RVA: 0xC6A300 Offset: 0xC6A300 VA: 0xC6A300
		//private void OnClickDecideSerifButton() { }

		//// RVA: 0xC6A264 Offset: 0xC6A264 VA: 0xC6A264
		//private void CommonClickSerifButton() { }

		//// RVA: 0xC6A338 Offset: 0xC6A338 VA: 0xC6A338
		//private void OnClickSelectWindowCloseButton() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D2744 Offset: 0x6D2744 VA: 0x6D2744
		//// RVA: 0xC66788 Offset: 0xC66788 VA: 0xC66788
		//private IEnumerator Co_RemoveItem() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D27BC Offset: 0x6D27BC VA: 0x6D27BC
		//// RVA: 0xC6A3E8 Offset: 0xC6A3E8 VA: 0xC6A3E8
		//private IEnumerator Co_RemoveItem(DecorationItemBase item) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D2834 Offset: 0x6D2834 VA: 0x6D2834
		//// RVA: 0xC66690 Offset: 0xC66690 VA: 0xC66690
		//private IEnumerator Co_RemoveAllItem() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D28AC Offset: 0x6D28AC VA: 0x6D28AC
		//// RVA: 0xC6A48C Offset: 0xC6A48C VA: 0xC6A48C
		//private IEnumerator Co_RemoveAll() { }

		//// RVA: 0xC6A514 Offset: 0xC6A514 VA: 0xC6A514
		//private void Optioin() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D2924 Offset: 0x6D2924 VA: 0x6D2924
		//// RVA: 0xC6A588 Offset: 0xC6A588 VA: 0xC6A588
		//private IEnumerator Co_Option() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D299C Offset: 0x6D299C VA: 0x6D299C
		//// RVA: 0xC6A610 Offset: 0xC6A610 VA: 0xC6A610
		//private IEnumerator Co_ReloadRareBrakeItems() { }

		//// RVA: 0xC5CBF8 Offset: 0xC5CBF8 VA: 0xC5CBF8
		//private void EnableSerifAttacherCover(bool isEnable) { }

		//// RVA: 0xC6A698 Offset: 0xC6A698 VA: 0xC6A698
		//public void MenuEnable(bool enable) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D2A14 Offset: 0x6D2A14 VA: 0x6D2A14
		//// RVA: 0xC6A6DC Offset: 0xC6A6DC VA: 0xC6A6DC
		//protected IEnumerator TryShowTutorial_Chara() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D2A8C Offset: 0x6D2A8C VA: 0x6D2A8C
		//// RVA: 0xC6A764 Offset: 0xC6A764 VA: 0xC6A764
		//protected IEnumerator TryShowTutorial_Extra() { }

		//// RVA: 0xC5C618 Offset: 0xC5C618 VA: 0xC5C618
		//private void StopAllVoice() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D2B04 Offset: 0x6D2B04 VA: 0x6D2B04
		//// RVA: 0xC6A7D4 Offset: 0xC6A7D4 VA: 0xC6A7D4
		//private IEnumerator Co_ReceiveEnergy(DecorationItemBase item, long currentTime) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D2B7C Offset: 0x6D2B7C VA: 0x6D2B7C
		//// RVA: 0xC6A898 Offset: 0xC6A898 VA: 0xC6A898
		//private IEnumerator Co_ReceiveSpItem(DecorationItemBase _item, long currentTime) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D2BF4 Offset: 0x6D2BF4 VA: 0x6D2BF4
		//// RVA: 0xC6A95C Offset: 0xC6A95C VA: 0xC6A95C
		//private IEnumerator Co_SpItemLevelUp(DecorationSp spItemObject, int prevLevel) { }

		//// RVA: 0xC61CAC Offset: 0xC61CAC VA: 0xC61CAC
		//private void HideIcon() { }

		//// RVA: 0xC5BF9C Offset: 0xC5BF9C VA: 0xC5BF9C
		//private void InitializeScreenShot() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D2C6C Offset: 0x6D2C6C VA: 0x6D2C6C
		//// RVA: 0xC6AA18 Offset: 0xC6AA18 VA: 0xC6AA18
		//private IEnumerator Co_DoScreenShot() { }

		//// RVA: 0xC6AAA0 Offset: 0xC6AAA0 VA: 0xC6AAA0
		//private void OnScreenShotAndroidBackButton() { }

		//// RVA: 0xC6AACC Offset: 0xC6AACC VA: 0xC6AACC
		//private void UpdateLogoPosition(Vector2 logoPosition) { }

		//// RVA: 0xC6AD70 Offset: 0xC6AD70 VA: 0xC6AD70
		//private string MakeSaveFileName() { }

		//// RVA: 0xC6AF74 Offset: 0xC6AF74 VA: 0xC6AF74
		//private void PushTakeButton() { }

		//// RVA: 0xC6B47C Offset: 0xC6B47C VA: 0xC6B47C
		//private void CloseResultMessage() { }

		//// RVA: 0xC6B4A8 Offset: 0xC6B4A8 VA: 0xC6B4A8
		//private void ResetCaptureMode() { }

		//// RVA: 0xC6B570 Offset: 0xC6B570 VA: 0xC6B570
		//private void ExitCaptureMode() { }

		//// RVA: 0xC6B57C Offset: 0xC6B57C VA: 0xC6B57C
		//private void ScreenShotCallBack(ScreenShot.ReturnCode returnCode, string shareFilePath) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D2CE4 Offset: 0x6D2CE4 VA: 0x6D2CE4
		//// RVA: 0xC6B818 Offset: 0xC6B818 VA: 0xC6B818
		//private IEnumerator PermissionCallBack(Action<ScreenShot.PermissionFuncResultCode> result) { }

		//// RVA: 0xC6B108 Offset: 0xC6B108 VA: 0xC6B108
		//private void DoCapture() { }

		//// RVA: 0xC6B8A0 Offset: 0xC6B8A0 VA: 0xC6B8A0
		//private Rect CalcCaptureTrimmingRect() { }

		//// RVA: 0xC6BD28 Offset: 0xC6BD28 VA: 0xC6BD28
		//private string MakePhotoSavePath() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D2D5C Offset: 0x6D2D5C VA: 0x6D2D5C
		//// RVA: 0xC6CDD8 Offset: 0xC6CDD8 VA: 0xC6CDD8
		//private bool <Co_LoadCanvas>b__98_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D2D6C Offset: 0x6D2D6C VA: 0x6D2D6C
		//// RVA: 0xC6CE04 Offset: 0xC6CE04 VA: 0xC6CE04
		//private void <Co_LoadCanvas>b__98_1() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D2D7C Offset: 0x6D2D7C VA: 0x6D2D7C
		//// RVA: 0xC6CE60 Offset: 0xC6CE60 VA: 0xC6CE60
		//private bool <Co_LoadMaterial>b__107_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D2D8C Offset: 0x6D2D8C VA: 0x6D2D8C
		//// RVA: 0xC6CE8C Offset: 0xC6CE8C VA: 0xC6CE8C
		//private bool <Co_LoadAllBackDecoration>b__108_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D2D9C Offset: 0x6D2D9C VA: 0x6D2D9C
		//// RVA: 0xC6CEB8 Offset: 0xC6CEB8 VA: 0xC6CEB8
		//private void <Co_LoadLeftButtons>b__111_0(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D2DAC Offset: 0x6D2DAC VA: 0x6D2DAC
		//// RVA: 0xC6D0C8 Offset: 0xC6D0C8 VA: 0xC6D0C8
		//private void <Co_LoadRightButtons01>b__112_0(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D2DBC Offset: 0x6D2DBC VA: 0x6D2DBC
		//// RVA: 0xC6D4A0 Offset: 0xC6D4A0 VA: 0xC6D4A0
		//private void <Co_LoadRightButtons01>b__112_1() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D2DCC Offset: 0x6D2DCC VA: 0x6D2DCC
		//// RVA: 0xC6D510 Offset: 0xC6D510 VA: 0xC6D510
		//private void <Co_LoadLeftEditButton>b__113_0(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D2DDC Offset: 0x6D2DDC VA: 0x6D2DDC
		//// RVA: 0xC6D6A0 Offset: 0xC6D6A0 VA: 0xC6D6A0
		//private void <Co_LoadRightEditButton>b__114_0(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D2DEC Offset: 0x6D2DEC VA: 0x6D2DEC
		//// RVA: 0xC6D830 Offset: 0xC6D830 VA: 0xC6D830
		//private void <Co_LoadExchangeButton>b__115_0(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D2DFC Offset: 0x6D2DFC VA: 0x6D2DFC
		//// RVA: 0xC6D970 Offset: 0xC6D970 VA: 0xC6D970
		//private void <Co_LoadPostWindow>b__116_0(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D2E0C Offset: 0x6D2E0C VA: 0x6D2E0C
		//// RVA: 0xC6DA88 Offset: 0xC6DA88 VA: 0xC6DA88
		//private void <Co_LoadSerifAttacher>b__117_0(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D2E1C Offset: 0x6D2E1C VA: 0x6D2E1C
		//// RVA: 0xC6DB78 Offset: 0xC6DB78 VA: 0xC6DB78
		//private bool <Co_LoadDecorator>b__118_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D2E2C Offset: 0x6D2E2C VA: 0x6D2E2C
		//// RVA: 0xC6DBA4 Offset: 0xC6DBA4 VA: 0xC6DBA4
		//private void <Co_LoadMenuDisableButton>b__119_0(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D2E3C Offset: 0x6D2E3C VA: 0x6D2E3C
		//// RVA: 0xC6DCC4 Offset: 0xC6DCC4 VA: 0xC6DCC4
		//private void <ShowPostMaxPopup>b__138_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D2E4C Offset: 0x6D2E4C VA: 0x6D2E4C
		//// RVA: 0xC6DCCC Offset: 0xC6DCCC VA: 0xC6DCCC
		//private void <OnClickDecoButton>b__140_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D2E5C Offset: 0x6D2E5C VA: 0x6D2E5C
		//// RVA: 0xC6DCD4 Offset: 0xC6DCD4 VA: 0xC6DCD4
		//private bool <Co_LoadItem>b__160_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D2E6C Offset: 0x6D2E6C VA: 0x6D2E6C
		//// RVA: 0xC6DD00 Offset: 0xC6DD00 VA: 0xC6DD00
		//private bool <Co_AllBack>b__195_3() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D2E7C Offset: 0x6D2E7C VA: 0x6D2E7C
		//// RVA: 0xC6DD04 Offset: 0xC6DD04 VA: 0xC6DD04
		//private bool <Co_AllBack>b__195_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D2E8C Offset: 0x6D2E8C VA: 0x6D2E8C
		//// RVA: 0xC6DD08 Offset: 0xC6DD08 VA: 0xC6DD08
		//private bool <Co_LoadPostSelectItems>b__203_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D2E9C Offset: 0x6D2E9C VA: 0x6D2E9C
		//// RVA: 0xC6DD34 Offset: 0xC6DD34 VA: 0xC6DD34
		//private bool <Co_LoadPostSelectItems>b__203_1() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D2EAC Offset: 0x6D2EAC VA: 0x6D2EAC
		//// RVA: 0xC6DD60 Offset: 0xC6DD60 VA: 0xC6DD60
		//private bool <Co_ReloadRareBrakeItems>b__219_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6D2EBC Offset: 0x6D2EBC VA: 0x6D2EBC
		//// RVA: 0xC6DD8C Offset: 0xC6DD8C VA: 0xC6DD8C
		//private void <InitializeScreenShot>b__240_0() { }
	}
}
