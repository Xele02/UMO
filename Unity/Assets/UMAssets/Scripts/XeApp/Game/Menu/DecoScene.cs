using mcrs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Player;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;
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
			public void Init()
			{
				isAnyNew = false;
				isTabNewList = new List<bool>();
			}
		}

		private struct NewIconInfo
		{
			public bool isEditButtonNew; // 0x0
			public CategoryNewIconInfo[] categoryInfos; // 0x4

			//// RVA: 0x7FCE18 Offset: 0x7FCE18 VA: 0x7FCE18
			public void init()
			{
				isEditButtonNew = false;
				categoryInfos = new CategoryNewIconInfo[5];
			}
		}

		private class DecoProductsPicker
		{
			private List<KDKFHGHGFEK> items = new List<KDKFHGHGFEK>(); // 0x8
			private List<FJGOKILCBJA> products = new List<FJGOKILCBJA>(); // 0xC
			private Dictionary<EKLNMHFCAOI.FKGCBLHOOCL_Category, List<int>> indicesDic = new Dictionary<EKLNMHFCAOI.FKGCBLHOOCL_Category, List<int>>(); // 0x10

			//// RVA: 0x15870D8 Offset: 0x15870D8 VA: 0x15870D8
			public void Create()
			{
				List<BKPAPCMJKHE_Shop.DNOENEKHGMI> l = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.CDENCMNHNGA;
				foreach (var k in l)
				{
					if(k.HCCEFDMGPEA == 5)
					{
						AODFBGCCBPE data = new AODFBGCCBPE();
						data.KHEKNNFCAOI(k.OPKDAIMPJBH_ShopId, NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
						products = data.MHKCPJDNJKI;
						indicesDic.Clear();
						for(int i = 0; i < products.Count; i++)
						{
							KDKFHGHGFEK item = new KDKFHGHGFEK();
							item.KHEKNNFCAOI(EKLNMHFCAOI.DEACAHNLMNI_getItemId(products[i].KIJAPOFAGPN_ItemFullId), EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(products[i].KIJAPOFAGPN_ItemFullId));
							items.Add(item);
							if(item.NPADACLCNAN_Category >= EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg && item.NPADACLCNAN_Category < EKLNMHFCAOI.FKGCBLHOOCL_Category.MABCLBNIOFA_ValkyrieItem)
							{
								List<int> l2 = null;
								if(!indicesDic.TryGetValue(item.NPADACLCNAN_Category, out l2))
								{
									l2 = new List<int>();
									indicesDic[item.NPADACLCNAN_Category] = l2;
								}
								l2.Add(i);
							}
						}
					}
				}
			}

			//// RVA: 0x1587770 Offset: 0x1587770 VA: 0x1587770
			public List<FJGOKILCBJA> GetProducts(List<int> indices, Predicate<KDKFHGHGFEK> itemFilter, Predicate<FJGOKILCBJA> productFilter)
			{
				List<FJGOKILCBJA> res = new List<FJGOKILCBJA>(indices.Count);
				foreach(var i in indices)
				{
					if(itemFilter(items[i]))
					{
						if(productFilter(products[i]))
						{
							res.Add(products[i]);
						}
					}
				}
				return res;
			}

			//// RVA: 0x1587A98 Offset: 0x1587A98 VA: 0x1587A98
			public List<FJGOKILCBJA> GetProducts(EKLNMHFCAOI.FKGCBLHOOCL_Category type, Predicate<KDKFHGHGFEK> itemFilter, Predicate<FJGOKILCBJA> productFilter)
			{
				if(!indicesDic.ContainsKey(type))
				{
					return new List<FJGOKILCBJA>();
				}
				return GetProducts(indicesDic[type], itemFilter, productFilter);
			}
		}

		private static readonly StateControlData[] StateControlTbl = new StateControlData[7]
			{
				new StateControlData(true, DecorationItemManager.EnableControlType.Unique, CharaAnimationType.Normal), // Top = 0,
				new StateControlData(true, DecorationItemManager.EnableControlType.Unique, CharaAnimationType.Normal), // MenuDisable = 1,
				new StateControlData(true, DecorationItemManager.EnableControlType.Edit, CharaAnimationType.Wait), // EditMenuDisable = 2,
				new StateControlData(true, DecorationItemManager.EnableControlType.None, CharaAnimationType.Wait), // SelectPostItem = 3,
				new StateControlData(true, DecorationItemManager.EnableControlType.Edit, CharaAnimationType.Wait), // SelectEditItem = 4,
				new StateControlData(true, DecorationItemManager.EnableControlType.Edit, CharaAnimationType.Wait), // Edit = 5,
				new StateControlData(true, DecorationItemManager.EnableControlType.None, CharaAnimationType.Wait) // End = 6,
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
		private HNKMEOKCNBI m_netDecoVisitControl = new HNKMEOKCNBI(); // 0xA0
		private CHKMLHDDPHO m_netDecoChargeControl; // 0xA4
		private List<BCGFHLIEKLJ_DecoItem.GNGFGEIAGJL> m_chargeTargets; // 0xA8
		private DecorationSpCollectInfo m_decorationSpCollectInfo; // 0xAC
		private PopupDecoSpCollectSetting m_decoSpCollectPopupSetting = new PopupDecoSpCollectSetting(); // 0xE0
		private PopupDecoEnergyChargeSetting m_decoEnergyChargeSeeting = new PopupDecoEnergyChargeSetting(); // 0xE4
		private PopupDecoSpItemListSetting m_decoSpItemListSetting = new PopupDecoSpItemListSetting(); // 0xE8
		private PopupDecoSpItemLevelupePopupSetting m_decoSpItemLevelupSetting = new PopupDecoSpItemLevelupePopupSetting(); // 0xEC
		private PopupDecoOptionSetting m_decoOptionSetting = new PopupDecoOptionSetting(); // 0xF0
		private DecorationChara m_speakChara; // 0xF4
		private DecorationDecorator m_decorator; // 0xF8
		private DecorationDecorator.DecoratorType m_decoratorType; // 0xFC
		private DocorationSpItemRemovePopupSetting m_spItemRemovePopup = new DocorationSpItemRemovePopupSetting(); // 0x100
		private RectTransform m_touchGuardArea; // 0x104
		private List<int> exItemListupWork = new List<int>(); // 0x108
		private List<DecorationItemBase> m_allGetTargetList = new List<DecorationItemBase>(); // 0x10C
		private List<DecorationItemBase> m_removeTargetList = new List<DecorationItemBase>(); // 0x110
		private List<DecorationItemBase> m_levelUpTargetList = new List<DecorationItemBase>(); // 0x114
		private bool m_isKeepCanvas; // 0x118
		private bool m_isToExchangeScene; // 0x119
		private PopupDecoCountSetting m_decoCountPopupSetting = new PopupDecoCountSetting(); // 0x11C
		private int m_objSettingMax; // 0x120
		private int m_charaSettingMax; // 0x124
		private List<int> m_spItemListupList = new List<int>(); // 0x128
		private DecorationMapNameController m_mapNameController; // 0x12C
		private DecoProductsPicker m_productsPicker = new DecoProductsPicker(); // 0x130
		private Dictionary<DecorationDecorator.DecoratorType, Dictionary<DecorationDecorator.TabType, List<FJGOKILCBJA>>> m_productsCache = new Dictionary<DecorationDecorator.DecoratorType, Dictionary<DecorationDecorator.TabType, List<FJGOKILCBJA>>>(); // 0x134
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
#if UNITY_EDITOR || UNITY_STANDALONE
			BundleShaderInfo.Instance.FixMaterialShader(m_screenShotViewInstance.gameObject);
#endif
			m_screenShotViewInstance.transform.SetParent(transform, false);
			InitializeScreenShot();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_decoOptionSetting.TitleText = bk.GetMessageByLabel("pop_deco_option_title");
			m_decoOptionSetting.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive },
			};
			m_decoOptionSetting.WindowSize = SizeType.Large;
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
		private IEnumerator Co_OnActivateScene()
		{
			GameManager.PushBackButtonHandler backButtonDummy;

			//0x157A2B0
			MenuScene.Instance.InputDisable();
			SetEnableControllerTapGuard(true);
			if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsDecoltureHelp))
			{
				backButtonDummy = () =>
				{
					//0xC6E014
					return;
				};
				yield return Co.R(TutorialManager.ShowTutorial(119, null));
				bool done = false;
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.BCLKCMDGDLD(GPFlagConstant.ID.IsDecolture, true);
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.BCLKCMDGDLD(GPFlagConstant.ID.IsDecoltureHelp, true);
				MenuScene.Save(() =>
				{
					//0xC6F664
					done = true;
				}, null);
				while (!done)
					yield return null;
				GameManager.Instance.RemovePushBackButtonHandler(backButtonDummy);
				backButtonDummy = null;
			}
			//LAB_0157a7d8
			yield return Co.R(MenuScene.Instance.ShowPosterReleaseWindowCoroutine());
			yield return Co.R(MenuScene.Instance.LobbyButtonControl.Co_CheckNewMark(null));
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DOPABKCMOOI(CIOECGOMILE.HHCJCDFCLOB.LGBMDHOLOIF_decoPlayerData, NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
			bool isDone = false;
			MenuScene.Save(() =>
			{
				//0xC6F610
				isDone = true;
			}, null);
			while (!isDone)
				yield return null;
			if(m_decorationCanvas != null)
			{
				m_decorationCanvas.StartAnimation();
				m_decorationCanvas.ReloadIntimacyController();
				yield return new WaitWhile(() =>
				{
					//0xC6F61C
					return m_decorationCanvas.IsIntimacyControllerLoaded();
				});
				m_decorationCanvas.SetEnableIntimacyCounter(StateLayoutDataTbl[(int)m_state].isIntimacyCounter);
			}
			//LAB_0157ac74
			yield return this.StartCoroutineWatched(m_decorationCanvas.Co_LoadBgEffect());
			SetEnableControllerTapGuard(false);
			MenuScene.Instance.InputEnable();
		}

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
			ChangeState(StateType.End, 0);
			m_isKeepCanvas = false;
			m_postType = DecorationItemManager.PostType.None;
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
			return true;
		}

		//// RVA: 0xC5B990 Offset: 0xC5B990 VA: 0xC5B990
		private void SettingData()
		{
			m_decorationCanvas = GetComponent<DecorationCanvas>();
			if(m_decorationCanvas != null)
			{
				m_decorationCanvas.DecoLocalSaveData.PCODDPDFLHK_Load();
			}
			m_decorator = GetComponent<DecorationDecorator>();
			m_decorator.NewPostItemCallback = NewPostItemCallback;
			m_decorator.OnClickTabButton = OnClickChangeTab;
			m_decorator.BuyItemCallback = BuyItemCallback;
			m_decorator.OnStartDownLoad += () =>
			{
				//0xC6E018
				MenuScene.Instance.InputDisable();
			};
			m_decorator.OnEndDownLoad += () =>
			{
				//0xC6E0B4
				MenuScene.Instance.InputEnable();
			};
			m_isKeepCanvas = false;
			m_objSettingMax = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA("object_set_max", 50);
			m_charaSettingMax = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA("chara_set_max", 5);
			m_isToExchangeScene = false;
			m_mapNameController = GetComponent<DecorationMapNameController>();
			EnableSerifAttacherCover(false);
			m_updater = UpdateIdle;
		}

		// RVA: 0xC5CC4C Offset: 0xC5CC4C VA: 0xC5CC4C
		private void Update()
		{
			if (!IsReady)
				return;
			if (m_updater != null)
				m_updater();
		}

		//// RVA: 0xC5CC84 Offset: 0xC5CC84 VA: 0xC5CC84
		private void UpdateIdle()
		{
			if(!m_decorationCanvas.IsItemTouch() && m_state >= StateType.MenuDisable && m_state <= StateType.EditMenuDisable)
			{
				if(m_beginTouch == null)
				{
					m_canMenuEnable = true;
					m_beginTouch = InputManager.Instance.GetBeganTouchInfo(0);
				}
				else
				{
					TouchInfo end = InputManager.Instance.GetEndedTouchInfo(0);
					if (end.id == -1)
						return;
					if(IsPlayingEnd())
					{
						if((end.position - m_beginTouch.position).magnitude < 30 && m_canMenuEnable)
						{
							StateType t = m_oldState;
							if (t == StateType.Edit)
								t = StateType.SelectEditItem;
							ChangeState(t, DecorationConstants.Attribute.Type.None);
							SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
						}
					}
					m_beginTouch = null;
				}
			}
		}

		//// RVA: 0xC5CC88 Offset: 0xC5CC88 VA: 0xC5CC88
		//private void UpdateTouchMenuDisbale() { }

		// RVA: 0xC5D0F4 Offset: 0xC5D0F4 VA: 0xC5D0F4 Slot: 16
		protected override void OnPreSetCanvas()
		{
			if (Args != null && Args is DecoArgs)
				m_playerId = (Args as DecoArgs).playerId;
			DecoVisitScene.transitionType = DecoVisitScene.TransitionType.Deco;
			this.StartCoroutineWatched(Co_OnPreSetCanvas());
		}

		// RVA: 0xC5D278 Offset: 0xC5D278 VA: 0xC5D278 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return !m_isWaitOnPreSetCanvas && base.IsEndPreSetCanvas();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D17CC Offset: 0x6D17CC VA: 0x6D17CC
		//// RVA: 0xC5D1F0 Offset: 0xC5D1F0 VA: 0xC5D1F0
		private IEnumerator Co_OnPreSetCanvas()
		{
			//0x157AEA4
			m_isWaitOnPreSetCanvas = true;
			m_decorationCanvas.SetActive(true);
			bool done = false;
			bool isError = false;
			yield return this.StartCoroutineWatched(Co_LoadSetDecoData(() =>
			{
				//0xC6F678
				done = true;
			}, () =>
			{
				//0xC6F684
				done = true;
				isError = true;
			}));
			while(!done)
				yield return null;
			if(isError)
			{
				OnError();
				yield break;
			}
			yield return this.StartCoroutineWatched(Co_LoadMaterial());
			if(PrevTransition != TransitionList.Type.SHOP_PRODUCT)
			{
				yield return this.StartCoroutineWatched(Co_LoadVisitItem());
			}
			//LAB_0157af94
			while(!m_decorationCanvas.IsLoadedDecoration)
				yield return null;
			m_decorationCanvas.UpdateViewDecoItemList();
			m_decorationCanvas.StartAnimation();
			m_layoutDecorationRightButtons01.Setting(m_decoPublicSetData.LJMCPFACDGJ.CPOONLHIMKC_DecoRoomName);
			m_updater = UpdateIdle;
			UpdateDecoNumLayout();
			UpdateItemPostLayout();
			UpdateCharaPostLayout();
			UpdateNewIcon();
			if(m_speakChara != null)
			{
				UpdateSerifNewIcon(m_speakChara.Id);
				UpdateItemSelectWindowButton(DecorationDecorator.DecoratorType.Serif);
			}
			if(m_decorationCanvas != null)
			{
				if(m_decorationCanvas.m_intimacyController != null)
				{
					m_decorationCanvas.m_intimacyController.HideDeco();
				}
			}
			yield return Co.R(MenuScene.Instance.LobbyButtonControl.InitRaidLobby(() =>
			{
				//0xC6E150
				return;
			}, () =>
			{
				//0xC6F690
				GotoTitle();
			}));
			MenuScene.Instance.LobbyButtonControl.OnPreLoadAnnounce = () =>
			{
				//0xC6F6BC
				SetEnableControllerTapGuard(true);
			};
			MenuScene.Instance.LobbyButtonControl.OnEndAnnounce = () =>
			{
				//0xC6F6E8
				SetEnableControllerTapGuard(false);
			};
			yield return Resources.UnloadUnusedAssets();
			GC.Collect();
			m_isWaitOnPreSetCanvas = false;
			m_touchGuardArea.transform.SetAsLastSibling();
		}

		//// RVA: 0xC5D290 Offset: 0xC5D290 VA: 0xC5D290
		private void OnError()
		{
			m_isWaitOnPreSetCanvas = false;
			if(MenuScene.Instance.IsTransition())
			{
				GotoTitle();
				return;
			}
			MenuScene.Instance.GotoTitle();
		}

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
					ChangeState(StateType.SelectPostItem, 0);
				else
					ChangeState(StateType.SelectEditItem, 0);
			}
			else
				ChangeState(StateType.Top, 0);
		}

		// RVA: 0xC5D578 Offset: 0xC5D578 VA: 0xC5D578 Slot: 12
		protected override void OnStartExitAnimation()
		{
			ChangeState(StateType.End, 0);
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
		private bool IsPlayingEnd()
		{
			return !m_layoutDecorationLeftButtons.IsPlaying() &&
				m_layoutDecorationRightButtons01.IsPlayingEnd() &&
				m_layoutDecorationPostWindow.IsPlayingEnd() &&
				m_layoutDecorationLeftEditButton.IsPlayingEnd() &&
				m_layoutDecorationRightEditButton.IsPlayingEnd() &&
				m_layoutDecorationExchangeButton.IsPlayingEnd() &&
				m_layoutDecorationExchangeButton.IsPlayingEnd() &&
				m_decorator.IsPlayingEnd() &&
				!m_layoutDecorationMenuDisableButton.IsPlaying();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D1844 Offset: 0x6D1844 VA: 0x6D1844
		//// RVA: 0xC5BF14 Offset: 0xC5BF14 VA: 0xC5BF14
		private IEnumerator Co_LoadingSeq()
		{
			//0x1579B30
			yield return this.StartCoroutineWatched(Co_LoadCanvas());
			yield return this.StartCoroutineWatched(Co_LoadLayout());
			m_decorationCanvas.StartAnimation();
			IsReady = true;
		}

		//// RVA: 0xC5D58C Offset: 0xC5D58C VA: 0xC5D58C
		private bool CheckVisitItem()
		{
			foreach(var c in m_decorationCanvas.GetItemList())
			{
				if(c is DecorationSp && (c as DecorationSp).SpType == NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.JPPOGMHJKKJ_VisitItemSp)
				{
					return true;
				}
			}
			return false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D18BC Offset: 0x6D18BC VA: 0x6D18BC
		//// RVA: 0xC5D748 Offset: 0xC5D748 VA: 0xC5D748
		private IEnumerator Co_LoadSetDecoData(IMCBBOAFION onSuccess, DJBHIFLHJLK onError)
		{
			//0x15786C8
			bool isError = false;
			bool isConnected = true;
			if(m_decoPublicSetData == null || PrevTransition == TransitionList.Type.HOME || PrevTransition == TransitionList.Type.DECO_VISIT)
			{
				isConnected = false;
				CIOECGOMILE.HHCJCDFCLOB.CJMDNPCBEJF_LoadDecoData(() =>
				{
					//0xC6F71C
					m_decoPublicSetData = CIOECGOMILE.HHCJCDFCLOB.LGBMDHOLOIF_decoPlayerData.AHEFHIMGIBI.PDKHANKAPCI_DecoPublicSet;
					m_decoPrivateSetData = CIOECGOMILE.HHCJCDFCLOB.LGBMDHOLOIF_decoPlayerData.AHEFHIMGIBI.DNIPIBICFGN_DecoPrivateSet;
					isConnected = true;
				}, () =>
				{
					//0xC6F8A4
					isConnected = true;
					isError = true;
				}, false);
				yield return new WaitUntil(() =>
				{
					//0xC6F8B0
					return isConnected;
				});
				if(isError)
				{
					onError();
					yield break;
				}
			}
			if(JFOBOMOMENL.KIAFJHJMBFN() || NCPPAHHCCAO.MGHDHIJIGLD().Count >= 5)
			{
				isConnected = false;
				CIOECGOMILE.HHCJCDFCLOB.OEAMJGPAIGP(CIOECGOMILE.HHCJCDFCLOB.LGBMDHOLOIF_decoPlayerData, () =>
				{
					//0xC6F8B8
					isConnected = true;
				}, () =>
				{
					//0xC6F8C4
					isConnected = true;
					isError = true;
				}, null);
				yield return new WaitUntil(() =>
				{
					//0xC6F8D0
					return isConnected;
				});
				if(isError)
				{
					onError();
					yield break;
				}
				isConnected = false;
				CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
				{
					//0xC6F8D8
					isConnected = true;
				}, () =>
				{
					//0xC6F8E4
					isConnected = true;
					isError = true;
				}, null);
				yield return new WaitUntil(() =>
				{
					//0xC6F8F0
					return isConnected;
				});
				if(isError)
				{
					onError();
					yield break;
				}
			}
			//LAB_01578d04
			onSuccess();
			m_netDecoChargeControl = new CHKMLHDDPHO(CIOECGOMILE.HHCJCDFCLOB.LGBMDHOLOIF_decoPlayerData);
			m_chargeTargets = m_netDecoChargeControl.CJLGPDLLHKC(m_decoPublicSetData.LJMCPFACDGJ);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D1934 Offset: 0x6D1934 VA: 0x6D1934
		//// RVA: 0xC5D804 Offset: 0xC5D804 VA: 0xC5D804
		private IEnumerator Co_LoadVisitItem()
		{
			//0x1578F5C
			int count = 0;
			bool isConnected = false;
			bool isError = false;
			m_netDecoVisitControl.MEMCHEIHDAI_GetFriendCounter((int visitNum) =>
			{
				//0xC6F900
				isConnected = true;
				count += visitNum;
			}, () =>
			{
				//0xC6F918
				isConnected = true;
				isError = true;
			});
			yield return new WaitUntil(() =>
			{
				//0xC6F924
				return isConnected;
			});
			if(isError)
			{
				OnError();
				yield break;
			}
			if(count == 0)
			{
				isConnected = false;
				m_netDecoVisitControl.AHEFGHPBMBJ_GetFanCounter((int visitNum) =>
				{
					//0xC6F92C
					isConnected = true;
					count += visitNum;
				}, () =>
				{
					//0xC6F944
					isConnected = true;
					isError = true;
				});
				yield return new WaitUntil(() =>
				{
					//0xC6F950
					return isConnected;
				});
			}
			if(isError)
			{
				OnError();
				yield break;
			}
			if(count == 0)
			{
				isConnected = false;
				m_netDecoVisitControl.ALGLKOIKNGL_GetOtherCounter((int visitNum) =>
				{
					//0xC6F958
					isConnected = true;
					count += visitNum;
				}, () =>
				{
					//0xC6F970
					isConnected = true;
					isError = true;
				});
				yield return new WaitUntil(() =>
				{
					//0xC6F97C
					return isConnected;
				});
			}
			if(isError)
			{
				OnError();
				yield break;
			}
			List<DecorationItemBase> l = m_decorationCanvas.GetItemList();
			foreach(var d in l)
			{
				if(d is DecorationSp && (d as DecorationSp).SpType == NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.JPPOGMHJKKJ_VisitItemSp)
				{
					m_decorationCanvas.RemoveItem(d);
					RemovePublicSetDataVisitItem();
					break;
				}
			}
			if(count < 1)
				yield break;
			if(CheckVisitItem())
				yield break;
			int rId;
			DecorationItemBaseSetting set;
			SettingVisitItem(out rId, out set);
			m_decorationCanvas.LoadItemResource(rId, set, 0,null);
			yield return new WaitUntil(() =>
			{
				//0xC6F984
				return m_decorationCanvas.IsLoadedItemDecoration;
			});
			m_decorationCanvas.LoadedItem();
			SettingDecoPublicSetData();
			yield return this.StartCoroutineWatched(Co_SavePublicData(() =>
			{
				//0xC6E154
				return;
			}, () =>
			{
				//0xC6E158
				MenuScene.Instance.GotoTitle();
			}));
		}

		//// RVA: 0xC5D88C Offset: 0xC5D88C VA: 0xC5D88C
		private void SettingVisitItem(out int resourceId, out DecorationItemBaseSetting setting)
		{
			m_decorationCanvas.MakeVisitItem(out resourceId, out setting);
		}

		//// RVA: 0xC5C7DC Offset: 0xC5C7DC VA: 0xC5C7DC
		public void ChangeState(StateType state, DecorationConstants.Attribute.Type type = 0)
		{
			StateControlData data = StateControlTbl[(int)state];
			EnableControllerControl(data.enableCanvasControl, data.enableItemControl, data.charaAnim);
			if (state == m_state)
				return;
			m_oldState = m_state;
			m_state = state;
			PreLayoutControl();
			LayoutControl(m_state, m_oldState, type);
			PostLayoutControl();
		}

		//// RVA: 0xC5D980 Offset: 0xC5D980 VA: 0xC5D980
		private void PreLayoutControl()
		{
			if(m_state == StateType.SelectPostItem)
			{
				m_decorator.SetPostItemList(m_decorationCanvas.GetItemList());
				m_decorator.SetSpeakChara(m_speakChara);
				int floorId, wallLId, wallRId;
				m_decorationCanvas.GetBgResourceId(out floorId, out wallLId, out wallRId);
				m_decorator.SetBgResourceId(floorId, wallLId, wallRId);
				if(m_speakChara != null)
					EnableSerifAttacherCover(true);
			}
		}

		//// RVA: 0xC5E194 Offset: 0xC5E194 VA: 0xC5E194
		private void PostLayoutControl()
		{
			if(m_state == StateType.Top)
			{
				ResetNewFlag();
				UpdateRightButtonNewIcon();
			}
			switch(m_decoratorType)
			{
				case DecorationDecorator.DecoratorType.Bg:
				case DecorationDecorator.DecoratorType.Object:
				case DecorationDecorator.DecoratorType.Extra:
				case DecorationDecorator.DecoratorType.Serif:
					UpdateItemPostLayout();
					return;
				case DecorationDecorator.DecoratorType.Chara:
					UpdateCharaPostLayout();
					return;
				default:
					return;
			}
		}

		//// RVA: 0xC5D8C8 Offset: 0xC5D8C8 VA: 0xC5D8C8
		private void EnableControllerControl(bool enableCanvas, DecorationItemManager.EnableControlType enableControlType, CharaAnimationType charaAnimationType) 
		{
			m_decorationCanvas.EnableCanvasController(enableCanvas);
			m_decorationCanvas.EnableItemController(enableControlType);
			if(charaAnimationType == CharaAnimationType.Wait)
			{
				m_decorationCanvas.WaitingChara(true);
			}
			else if(charaAnimationType == CharaAnimationType.Normal)
			{
				m_decorationCanvas.WaitingChara(false);
			}
		}

		//// RVA: 0xC5DB20 Offset: 0xC5DB20 VA: 0xC5DB20
		private void LayoutControl(StateType m_state, StateType oldState, DecorationConstants.Attribute.Type type = 0)
		{
			StateLayoutData data = StateLayoutDataTbl[(int)m_state];
			if(oldState == StateType.None)
			{
				//??
			}
			if (!data.isLeftButtons)
				m_layoutDecorationLeftButtons.Leave();
			else
				m_layoutDecorationLeftButtons.Enter();
			if (!data.isRightButtons)
				m_layoutDecorationRightButtons01.Leave();
			else
			{
				if(!data.isEditButton)
				{
					m_layoutDecorationRightButtons01.Enter();
					m_layoutDecorationRightButtons01.OutEditButtons();
				}
				else
				{
					m_layoutDecorationRightButtons01.LeaveMap();
					m_layoutDecorationRightButtons01.EnterEditButtons();
					m_layoutDecorationRightButtons01.InEditButtons();
				}
			}
			if (!data.isExchange)
				m_layoutDecorationExchangeButton.Leave();
			else
				m_layoutDecorationExchangeButton.Enter();
			if(!data.isLobbyButton)
			{
				MenuScene.Instance.LobbyButtonControl.Hide(false);
			}
			else
			{
				MenuScene.Instance.LobbyButtonControl.Setup(HomeLobbyButtonController.Type.DOWN);
			}
			if (!data.isItemLayout)
				m_decorationCanvas.HideSelectItemLayout();
			else
				m_decorationCanvas.EnablePostArea(type);
			if(!data.isEditButton)
				LeaveEditButton();
			else
				EnterEditButton();
			if(!data.isDecorator)
			{
				if((m_decoratorType | DecorationDecorator.DecoratorType.ButtonNum) != DecorationDecorator.DecoratorType.ButtonNum)
				{
					m_layoutDecorationPostWindow.Leave();
				}
				m_decorator.Leave();
				m_decorationCanvas.TapSetItemClear();
			}
			else
			{
				if ((m_decoratorType | DecorationDecorator.DecoratorType.ButtonNum) != DecorationDecorator.DecoratorType.ButtonNum)
				{
					m_layoutDecorationPostWindow.Enter();
				}
				m_decorator.Enter();
			}
			if(!data.isHelpButton)
			{
				MenuScene.Instance.HelpButton.TryLeave();
			}
			else
			{
				MenuScene.Instance.HelpButton.TryEnter();
			}
			m_decorationCanvas.SetEnableIntimacyCounter(data.isIntimacyCounter);
			m_layoutDecorationMenuDisableButton.SetDisable(m_state == StateType.SelectPostItem);
			if (data.isMenuDisable)
				m_layoutDecorationMenuDisableButton.Enter();
			else
				m_layoutDecorationMenuDisableButton.Leave();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D19AC Offset: 0x6D19AC VA: 0x6D19AC
		//// RVA: 0xC5E5D0 Offset: 0xC5E5D0 VA: 0xC5E5D0
		private IEnumerator Co_LoadCanvas()
		{
			//0x1574C9C
			yield return this.StartCoroutineWatched(Co_LoadCanvasPrefab());
			m_decorationCanvas.LoadResource();
			yield return new WaitUntil(() =>
			{
				//0xC6CDD8
				return m_decorationCanvas.IsLoaded;
			});
			m_decorationCanvas.OnClickSerifButton = OnClickSerifButton;
			m_decorationCanvas.OnClickPriorityButton = OnClickPriorityButton;
			m_decorationCanvas.OnClickFlipButton = OnClickFlipButton;
			m_decorationCanvas.SelectCallback = SelectItemCallback;
			m_decorationCanvas.EnablePostCallback = PostPossibleCallback;
			m_decorationCanvas.PointerDownCallback = ItemPointerDownCallback;
			m_decorationCanvas.ClickCallback = ItemClickCallback;
			m_decorationCanvas.CreateItemCallback = CreateItemCallback;
			m_decorationCanvas.ChangeKiraCallback = OnClickKiraButton;
			m_decorationCanvas.TouchLeaveCallback = () =>
			{
				//0xC6CE04
				TouchLeaveCallback();
				SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_GIFT_001);
			};

		}

		//// RVA: 0xC5E658 Offset: 0xC5E658 VA: 0xC5E658
		private void OnClickSerifButton(DecorationItemBase item)
		{
			DecorationChara chara = item as DecorationChara;
			m_speakChara = chara;
			chara.SettingPrevSerif();
			m_decoratorType = DecorationDecorator.DecoratorType.Serif;
			m_layoutDecorationSerifAttacher.Show(m_speakChara.Id, chara.GetSerifId());
			SettingWindowButton(DecorationDecorator.DecoratorType.Serif);
			UpdateItemSelectWindowButton(DecorationDecorator.DecoratorType.Serif);
			EnableControllerControl(false, DecorationItemManager.EnableControlType.None, CharaAnimationType.None);
			this.StartCoroutineWatched(Co_LoadPostSelectItems(DecorationDecorator.DecoratorType.Serif));
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			m_canMenuEnable = false;
		}

		//// RVA: 0xC5EC5C Offset: 0xC5EC5C VA: 0xC5EC5C
		private void OnClickPriorityButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			UpdateEditButton();
			m_canMenuEnable = false;
		}

		//// RVA: 0xC5EE04 Offset: 0xC5EE04 VA: 0xC5EE04
		private void OnClickFlipButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			UpdateEditButton();
			m_canMenuEnable = false;
		}

		//// RVA: 0xC5EE70 Offset: 0xC5EE70 VA: 0xC5EE70
		private void OnClickKiraButton(DecorationItemBase item, bool isKira)
		{
			return;
		}

		//// RVA: 0xC5EE74 Offset: 0xC5EE74 VA: 0xC5EE74
		private void CreateItemCallback(DecorationItemBase item)
		{
			if(m_postType != DecorationItemManager.PostType.DragNewPost)
			{
				if(m_postType != DecorationItemManager.PostType.TapNewPost)
					return;
				bool b = false;
				if(item.DecorationItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara)
				{
					UpdateCharaPostLayout();
					b = IsOverPostChara();
				}
				else
				{
					UpdateItemPostLayout();
					b = IsOverPostItem();
				}
				if(b)
					ChangeState(StateType.SelectEditItem, DecorationConstants.Attribute.Type.None);
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_HOME_000);
			}
			else
			{
				SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_GIFT_000);
				m_decorationCanvas.EnablePostArea(item.AttributeType);
			}
		}

		//// RVA: 0xC5EFFC Offset: 0xC5EFFC VA: 0xC5EFFC
		private void SelectItemCallback(DecorationItemBase item)
		{
			m_decorationCanvas.CanvasFollowTouch(false);
			m_decorationCanvas.EditItem(item);
			ChangeState(StateType.Edit, item.AttributeType);
			SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_GIFT_000);
		}

		//// RVA: 0xC5F0D0 Offset: 0xC5F0D0 VA: 0xC5F0D0
		private void PostPossibleCallback(bool isPosssible)
		{
			return;
		}

		//// RVA: 0xC5F0D4 Offset: 0xC5F0D4 VA: 0xC5F0D4
		private void TouchLeaveCallback()
		{
			if(m_oldState == StateType.EditMenuDisable)
			{
				m_canMenuEnable = false;
				ChangeState(StateType.EditMenuDisable, DecorationConstants.Attribute.Type.None);
				return;
			}
			if(m_postType == DecorationItemManager.PostType.DragNewPost)
			{
				bool b = true;
				if(m_decoratorType >= DecorationDecorator.DecoratorType.Object && m_decoratorType <= DecorationDecorator.DecoratorType.Serif)
				{
					b = IsOverPostItem();
				}
				else if(m_decoratorType == DecorationDecorator.DecoratorType.Chara)
				{
					b = IsOverPostChara();
				}
				if(!b)
				{
					ChangeState(StateType.SelectPostItem, DecorationConstants.Attribute.Type.None);
					m_postType = DecorationItemManager.PostType.None;
					return;
				}
			}
			m_decorationCanvas.CanvasFollowTouch(true);
			m_decorationCanvas.RestoreEditItem();
			ChangeState(StateType.SelectEditItem, DecorationConstants.Attribute.Type.None);
			m_postType = DecorationItemManager.PostType.None;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D1A24 Offset: 0x6D1A24 VA: 0x6D1A24
		//// RVA: 0xC5F23C Offset: 0xC5F23C VA: 0xC5F23C
		private IEnumerator Co_LoadMaterial()
		{
			//0x1576BF8
			if(PrevTransition != TransitionList.Type.DECO_VISIT_LIST && 
				PrevTransition != TransitionList.Type.DECO_BAST_STORAGE && 
				PrevTransition != TransitionList.Type.SHOP_PRODUCT && 
				PrevTransition != TransitionList.Type.FRIEND_SEARCH)
			{
				m_decorationCanvas.LoadDecoration(m_decoPublicSetData.LJMCPFACDGJ);
				yield return new WaitUntil(() =>
				{
					//0xC6CE60
					return m_decorationCanvas.IsLoadedDecoration;
				});
				m_reloadSearchMember = true;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D1A9C Offset: 0x6D1A9C VA: 0x6D1A9C
		//// RVA: 0xC5F2C4 Offset: 0xC5F2C4 VA: 0xC5F2C4
		private IEnumerator Co_LoadAllBackDecoration()
		{
			List<DecorationItemBase> itemList;
			DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN saveData;

			//0x1573C8C
			itemList = m_decorationCanvas.GetItemList();
			List<bool> l = new List<bool>();
			DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN data = DecorationItemToDecoSet(ref l);
			saveData = m_decoPublicSetData.LJMCPFACDGJ;
			List<int> ToKeep = new List<int>();
			List<int> toRemove = new List<int>();
			List<int> toCreate = new List<int>();
			if(!IsMatchBg(data, saveData))
			{
				m_decorationCanvas.LoadBgResource(saveData.KIDHLCNFCKN_FloorId, saveData.DJCJMCHMIMA_WallLId, saveData.KCMEAABOIOA_WallRId, false);
			}
			for(int i = 0; i < data.HBHMAKNGKFK_Items.Count; i++)
			{
				//LAB_0157439c
				if(data.HBHMAKNGKFK_Items[i].HAJKNHNAIKL_ItemId != 0)
				{
					bool found = false;
					for(int j = 0; j < saveData.HBHMAKNGKFK_Items.Count; j++)
					{
						if(saveData.HBHMAKNGKFK_Items[j].HAJKNHNAIKL_ItemId != 0)
						{
							if(!ToKeep.Contains(j))
							{
								if(IsSameItem(data.HBHMAKNGKFK_Items[i], saveData.HBHMAKNGKFK_Items[j]))
								{
									//code_r0x0157428c
									ToKeep.Add(j);
									itemList[i].SetInfo(saveData.HBHMAKNGKFK_Items[j]);
									found = true;
									break;
								}
							}
						}
					}
					if(!found)
						toRemove.Add(i);
				}
				//LAB_01574398
			}
			ToKeep.Clear();
			//LAB_01574790
			for(int i = 0; i < saveData.HBHMAKNGKFK_Items.Count; i++)
			{
				//LAB_01574790
				if(saveData.HBHMAKNGKFK_Items[i].HAJKNHNAIKL_ItemId != 0)
				{
					bool found = false;
					for(int j = 0; j < data.HBHMAKNGKFK_Items.Count; j++)
					{
						if(data.HBHMAKNGKFK_Items[j].HAJKNHNAIKL_ItemId != 0)
						{
							if(!ToKeep.Contains(j))
							{
								if(IsSameItem(saveData.HBHMAKNGKFK_Items[i], data.HBHMAKNGKFK_Items[j]))
								{
									//code_r0x01574738
									ToKeep.Add(j);
									found = true;
								}
							}
						}
					}
					if(!found)
						toCreate.Add(i);
				}
				//LAB_0157478c
			}
			foreach(int i in toRemove)
			{
				m_decorationCanvas.RemoveItem(itemList[i]);
			}
			//LAB_01573d18
			foreach(int i in toCreate)
			{
				m_decorationCanvas.LoadItem(saveData.HBHMAKNGKFK_Items[i]);
				yield return new WaitUntil(() =>
				{
					//0xC6CE8C
					return m_decorationCanvas.IsLoadedItem;
				});
			}
			for(int i = 0; i < itemList.Count; i++)
			{
				itemList[i].UpdateKiraMaterial();
			}
			m_decorationCanvas.LoadDecorationSerif();
			m_decorationCanvas.LoadedItem();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D1B14 Offset: 0x6D1B14 VA: 0x6D1B14
		//// RVA: 0xC5F34C Offset: 0xC5F34C VA: 0xC5F34C
		private IEnumerator Co_LoadLayout()
		{
			//0x15760F8
			yield return this.StartCoroutineWatched(Co_LoadLeftButtons());
			yield return this.StartCoroutineWatched(Co_LoadRightButtons01());
			yield return this.StartCoroutineWatched(Co_LoadLeftEditButton());
			yield return this.StartCoroutineWatched(Co_LoadRightEditButton());
			yield return this.StartCoroutineWatched(Co_LoadExchangeButton());
			yield return this.StartCoroutineWatched(Co_LoadPostWindow());
			yield return this.StartCoroutineWatched(Co_LoadDecorator());
			yield return this.StartCoroutineWatched(Co_LoadSerifAttacher());
			yield return this.StartCoroutineWatched(Co_LoadMenuDisableButton());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D1B8C Offset: 0x6D1B8C VA: 0x6D1B8C
		//// RVA: 0xC5F3D4 Offset: 0xC5F3D4 VA: 0xC5F3D4
		public IEnumerator Co_LoadCanvasPrefab()
		{
			string bundleName;
			AssetBundleLoadAllAssetOperationBase op;

			//0x1575298
			m_decorationCanvas = DecorationCanvas.instance;
			if(m_decorationCanvas == null)
			{
				bundleName = DecorationConstants.cmnAssetPath;
				op = AssetBundleManager.LoadAllAssetAsync(bundleName);
				yield return op;
				m_decorationCanvasPrefab = Instantiate(op.GetAsset<GameObject>(DecorationConstants.CanvasName));
				m_decorationCanvasPrefab.transform.SetParent(null, false);
				m_decorationCanvasPrefab.name = DecorationConstants.CanvasName;
				m_decorationCanvas = m_decorationCanvasPrefab.GetComponent<DecorationCanvas>();
				m_decorationCanvas.DecoLocalSaveData.PCODDPDFLHK_Load();
				DecorationCanvas.instance = m_decorationCanvas;
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				bundleName = null;
				op = null;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D1C04 Offset: 0x6D1C04 VA: 0x6D1C04
		//// RVA: 0xC5F45C Offset: 0xC5F45C VA: 0xC5F45C
		private IEnumerator Co_LoadLeftButtons()
		{
			AssetBundleLoadLayoutOperationBase op;

			//0x15764F8
			op = AssetBundleManager.LoadLayoutAsync(DecorationConstants.BundleName, LayoutDecorationLeftButtons.AssetName);
			yield return op;
			yield return Co.R(op.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0xC6CEB8
				instance.transform.SetParent(transform, false);
				m_layoutDecorationLeftButtons = instance.GetComponent<LayoutDecorationLeftButtons>();
				m_layoutDecorationLeftButtons.OnClickReturnHomeButton = ClickHomeButton;
				m_layoutDecorationLeftButtons.OnClickVisitDecoButton = ClickVisitButton;
				m_layoutDecorationLeftButtons.OnClickAllGetButton = ClickAllGetButton;
				m_layoutDecorationLeftButtons.OnClickDecoBoardButton = ClickDecoBoardButton;
			}));
			AssetBundleManager.UnloadAssetBundle(DecorationConstants.BundleName, false);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D1C7C Offset: 0x6D1C7C VA: 0x6D1C7C
		//// RVA: 0xC5F4E4 Offset: 0xC5F4E4 VA: 0xC5F4E4
		private IEnumerator Co_LoadRightButtons01()
		{
			AssetBundleLoadLayoutOperationBase op;

			//0x1577C48
			op = AssetBundleManager.LoadLayoutAsync(DecorationConstants.BundleName, LayoutDecorationRightButtons01.AssetName);
			yield return op;
			yield return Co.R(op.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0xC6D0C8
				instance.transform.SetParent(transform, false);
				m_layoutDecorationRightButtons01 = instance.GetComponent<LayoutDecorationRightButtons01>();
				m_layoutDecorationRightButtons01.OnClickMapChangeButton = OnClickMapChageButton;
				m_layoutDecorationRightButtons01.OnClickMapNameEditButton = OnClickMapNameEditButton;
				m_layoutDecorationRightButtons01.OnClickShowEditButton = OnClickShowEditButton;
				m_layoutDecorationRightButtons01.OnClickEditButton = OnClickEditButton;
				m_layoutDecorationRightButtons01.OnClickEditMaxButton = OnClickEditMaxButton;
				m_layoutDecorationRightButtons01.OnClickDecoButton = OnClickDecoButton;
				m_layoutDecorationRightButtons01.ClickTakeButtonListener += () =>
				{
					//0xC6D4A0
					this.StartCoroutineWatched(Co_DoScreenShot());
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				};
				m_layoutDecorationRightButtons01.OnClickOptionButtonListner = Optioin;
				m_layoutDecorationRightButtons01.OnClickDecoPlayerSearchButton = OnClickFriendSearchButton;
				UpdateDecoNumLayout();
			}));
			AssetBundleManager.UnloadAssetBundle(DecorationConstants.BundleName, false);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D1CF4 Offset: 0x6D1CF4 VA: 0x6D1CF4
		//// RVA: 0xC5F56C Offset: 0xC5F56C VA: 0xC5F56C
		private IEnumerator Co_LoadLeftEditButton()
		{
			AssetBundleLoadLayoutOperationBase op;

			//0x1576878
			op = AssetBundleManager.LoadLayoutAsync(DecorationConstants.BundleName, LayoutDecorationLeftEditButton.AssetName);
			yield return op;
			yield return Co.R(op.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0xC6D510
				instance.transform.SetParent(transform, false);
				m_layoutDecorationLeftEditButton = instance.GetComponent<LayoutDecorationLeftEditButton>();
				m_layoutDecorationLeftEditButton.OnClickLeftButton = OnClickAllRemoveButton;
				m_layoutDecorationLeftEditButton.OnClickRightButton = OnClickRemoveButton;
				m_layoutDecorationLeftEditButton.Hide();
			}));
			AssetBundleManager.UnloadAssetBundle(DecorationConstants.BundleName, false);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D1D6C Offset: 0x6D1D6C VA: 0x6D1D6C
		//// RVA: 0xC5F5F4 Offset: 0xC5F5F4 VA: 0xC5F5F4
		private IEnumerator Co_LoadRightEditButton()
		{
			AssetBundleLoadLayoutOperationBase op;

			//0x1577FC8
			op = AssetBundleManager.LoadLayoutAsync(DecorationConstants.BundleName, LayoutDecorationRightEditButton.AssetName);
			yield return op;
			yield return Co.R(op.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0xC6D6A0
				instance.transform.SetParent(transform, false);
				m_layoutDecorationRightEditButton = instance.GetComponent<LayoutDecorationRightEditButton>();
				m_layoutDecorationRightEditButton.OnClickLeftButton = OnClickAllBackButton;
				m_layoutDecorationRightEditButton.OnClickRightButton = OnClickSaveButton;
				m_layoutDecorationRightEditButton.Hide();
			}));
			AssetBundleManager.UnloadAssetBundle(DecorationConstants.BundleName, false);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D1DE4 Offset: 0x6D1DE4 VA: 0x6D1DE4
		//// RVA: 0xC5F67C Offset: 0xC5F67C VA: 0xC5F67C
		private IEnumerator Co_LoadExchangeButton()
		{
			AssetBundleLoadLayoutOperationBase op;

			//0x15759D8
			op = AssetBundleManager.LoadLayoutAsync(DecorationConstants.BundleName, LayoutDecorationExchangeButton.AssetName);
			yield return op;
			yield return Co.R(op.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0xC6D830
				instance.transform.SetParent(transform, false);
				m_layoutDecorationExchangeButton = instance.GetComponent<LayoutDecorationExchangeButton>();
				m_layoutDecorationExchangeButton.OnClickExchangeButton = OnClickExchangeButton;
				m_layoutDecorationExchangeButton.Hide();
			}));
			AssetBundleManager.UnloadAssetBundle(DecorationConstants.BundleName, false);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D1E5C Offset: 0x6D1E5C VA: 0x6D1E5C
		//// RVA: 0xC5F704 Offset: 0xC5F704 VA: 0xC5F704
		private IEnumerator Co_LoadPostWindow()
		{
			AssetBundleLoadLayoutOperationBase op;

			//0x15778C8
			op = AssetBundleManager.LoadLayoutAsync(DecorationConstants.BundleName, LayoutDecorationWin01Pos.AssetName);
			yield return op;
			yield return Co.R(op.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0xC6D970
				instance.transform.SetParent(transform, false);
				m_layoutDecorationPostWindow = instance.GetComponent<LayoutDecorationWin01Pos>();
				m_layoutDecorationPostWindow.SettingPostMax(m_objSettingMax);
				m_layoutDecorationPostWindow.Hide();
			}));
			AssetBundleManager.UnloadAssetBundle(DecorationConstants.BundleName, false);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D1ED4 Offset: 0x6D1ED4 VA: 0x6D1ED4
		//// RVA: 0xC5F78C Offset: 0xC5F78C VA: 0xC5F78C
		private IEnumerator Co_LoadSerifAttacher()
		{
			AssetBundleLoadLayoutOperationBase op;

			//0x1578348
			op = AssetBundleManager.LoadLayoutAsync(DecorationConstants.BundleName, LayoutDecorationSerifAttacher.AssetName);
			yield return op;
			yield return Co.R(op.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0xC6DA88
				instance.transform.SetParent(transform, false);
				m_layoutDecorationSerifAttacher = instance.GetComponent<LayoutDecorationSerifAttacher>();
				m_layoutDecorationSerifAttacher.Hide();
			}));
			AssetBundleManager.UnloadAssetBundle(DecorationConstants.BundleName, false);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D1F4C Offset: 0x6D1F4C VA: 0x6D1F4C
		//// RVA: 0xC5F814 Offset: 0xC5F814 VA: 0xC5F814
		private IEnumerator Co_LoadDecorator()
		{
			//0x15757FC
			m_decorator.LoadResoruce();
			yield return new WaitUntil(() =>
			{
				//0xC6DB78
				return m_decorator.IsLoaded;
			});
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D1FC4 Offset: 0x6D1FC4 VA: 0x6D1FC4
		//// RVA: 0xC5F89C Offset: 0xC5F89C VA: 0xC5F89C
		private IEnumerator Co_LoadMenuDisableButton()
		{
			AssetBundleLoadLayoutOperationBase op;

			//0x1576EC0
			op = AssetBundleManager.LoadLayoutAsync(DecorationConstants.BundleName, LayoutDecorationMenuDisableButton.AssetName);
			yield return op;
			yield return Co.R(op.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0xC6DBA4
				instance.transform.SetParent(transform, false);
				m_layoutDecorationMenuDisableButton = instance.GetComponent<LayoutDecorationMenuDisableButton>();
				m_layoutDecorationMenuDisableButton.OnClickMenuDisableButton = ClickMenuDisableButton;
			}));
			AssetBundleManager.UnloadAssetBundle(DecorationConstants.BundleName, false);
		}

		//// RVA: 0xC5EA60 Offset: 0xC5EA60 VA: 0xC5EA60
		private void UpdateItemSelectWindowButton(DecorationDecorator.DecoratorType type)
		{
			if(type == DecorationDecorator.DecoratorType.Serif)
			{
				if(m_speakChara != null)
				{
					UpdateSerifSelectWindowButton(m_speakChara.IsChangeSerif());
					return;
				}
			}
			if(m_decorator.ClickLeftButtonCallback != null)
			{
				m_decorator.LeftButtonDisable = false;
			}
			if(m_decorator.ClickRightButtonCallback != null)
			{
				m_decorator.RightButtonDisable = false;
			}
		}

		//// RVA: 0xC5F924 Offset: 0xC5F924 VA: 0xC5F924
		private void UpdateSerifSelectWindowButton(bool enable)
		{
			if(m_decorator.ClickLeftButtonCallback != null)
				m_decorator.LeftButtonDisable = false;
			if(m_decorator.ClickRightButtonCallback != null)
				m_decorator.RightButtonDisable = !enable;
		}

		//// RVA: 0xC5E518 Offset: 0xC5E518 VA: 0xC5E518
		private void UpdatePostLayout(EKLNMHFCAOI.FKGCBLHOOCL_Category ctg)
		{
			if (ctg == EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara)
				UpdateCharaPostLayout();
			else
				UpdateItemPostLayout();
		}

		//// RVA: 0xC5FB20 Offset: 0xC5FB20 VA: 0xC5FB20
		private void UpdateDecoNumLayout()
		{
			m_layoutDecorationRightButtons01.SetDecoNum(m_decorationCanvas.GetHaveDecorationItemCount());
		}

		//// RVA: 0xC5FB78 Offset: 0xC5FB78 VA: 0xC5FB78
		private void MakeCategoryNewIconInfo(ref CategoryNewIconInfo info, DecorationDecorator.DecoratorType type, int charaId = -1)
		{
			info.Init();
			List<List<KDKFHGHGFEK>> l = CreateCategoryItemLists(type, charaId);
			foreach(var l2 in l)
			{
				bool b = false;
				foreach(var it in l2)
				{
					if(it.CADENLBDAEB_IsNew)
					{
						info.isAnyNew = true;
						b = true;
						break;
					}
				}
				info.isTabNewList.Add(b);
			}
		}

		//// RVA: 0xC60078 Offset: 0xC60078 VA: 0xC60078
		private void MakeNewIconInfo(ref NewIconInfo info)
		{
			info.init();
			for(int i = 0; i < 5; i++)
			{
				MakeCategoryNewIconInfo(ref info.categoryInfos[i], (DecorationDecorator.DecoratorType)i, 0);
				if(i != 4 && !info.categoryInfos[i].isAnyNew)
					info.isEditButtonNew = true;
			}
		}

		//// RVA: 0xC5E204 Offset: 0xC5E204 VA: 0xC5E204
		private void ResetNewFlag()
		{
			foreach(var f in m_resetNewFlagList)
			{
				ResetNewFlag(f);
			}
			m_resetNewFlagList.Clear();
		}

		//// RVA: 0xC60144 Offset: 0xC60144 VA: 0xC60144
		private void ResetNewFlag(ResetNewFlagData flag)
		{
			List<KDKFHGHGFEK> l = CreateSelectItemDataList(flag.m_type, flag.m_tab, flag.m_charaId);
			foreach(var item in l)
			{
				if(item.NPADACLCNAN_Category == EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp)
				{
					BCGFHLIEKLJ_DecoItem.GNGFGEIAGJL it = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.OMMNKDEODJP_DecoItem.NBKAMFFIOOG_Sp.Find((BCGFHLIEKLJ_DecoItem.GNGFGEIAGJL _) =>
					{
						//0xC6E77C
						return item.PPFNGGCBJKC_Id == _.PPFNGGCBJKC_Id;
					});
					if(it != null)
					{
						it.CADENLBDAEB_IsNew = false;
					}
				}
				else if(item.NPADACLCNAN_Category == EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif)
				{
					if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.FJPOELGFPBP_DecoStamp.DMKMNGELNAE_Serif != null)
					{
						int id = item.PPFNGGCBJKC_Id;
						IOEKHJBOMDH_DecoStamp.GFPPDCEPLCM it = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.FJPOELGFPBP_DecoStamp.DMKMNGELNAE_Serif.Find((IOEKHJBOMDH_DecoStamp.GFPPDCEPLCM _) =>
						{
							//0xC6E7E0
							return _.PPFNGGCBJKC_Id == id;
						});
						if(it != null)
						{
							it.CADENLBDAEB_IsNew = false;
						}
					}
				}
				else if(item.NPADACLCNAN_Category == EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg)
				{
					if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.OMMNKDEODJP_DecoItem.DJHBDDGEKGO_Bgs != null)
					{
						int id = item.PPFNGGCBJKC_Id;
						BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ it = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.OMMNKDEODJP_DecoItem.DJHBDDGEKGO_Bgs.Find((BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ _) =>
						{
							//0xC6E824
							return _.PPFNGGCBJKC_Id == id;
						});
						if(it != null)
						{
							it.CADENLBDAEB_IsNew = false;
						}
					}
				}
				else if(item.NPADACLCNAN_Category == EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara)
				{
					if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.OMMNKDEODJP_DecoItem.PEBDEIKBCCM_Chars != null)
					{
						int id = item.PPFNGGCBJKC_Id;
                        BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ it = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.OMMNKDEODJP_DecoItem.PEBDEIKBCCM_Chars.Find((BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ _) =>
						{
							//0xC6E868
							return _.PPFNGGCBJKC_Id == id;
						});
						if(it != null)
						{
							it.CADENLBDAEB_IsNew = false;
						}
                    }
				}
				else
				{
					if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.OMMNKDEODJP_DecoItem.KPMFLNOELIN_Objs != null)
					{
						int id = item.PPFNGGCBJKC_Id;
                        BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ it = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.OMMNKDEODJP_DecoItem.KPMFLNOELIN_Objs.Find((BCGFHLIEKLJ_DecoItem.AKAHOEBACGJ _) =>
						{
							//0xC6E8AC
							return _.PPFNGGCBJKC_Id == id;
						});
						if(it != null)
						{
							it.CADENLBDAEB_IsNew = false;
							if(id > 0)
							{
								if(item.NPADACLCNAN_Category < EKLNMHFCAOI.FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem)
								{
									if(item.NPADACLCNAN_Category == EKLNMHFCAOI.FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef)
									{
										CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[id - 1].BILHHMGCPFC(0);
									}
									else if(item.NPADACLCNAN_Category == EKLNMHFCAOI.FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft)
									{
										CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[id - 1].BILHHMGCPFC(0);
									}
								}
								else if(item.NPADACLCNAN_Category == EKLNMHFCAOI.FKGCBLHOOCL_Category.HEMGMACMGAB_DecoItemVFFigure)
								{
									CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JJFFBDLIOCF_Valkyrie.CNGNBKNBKGI_ValkList[id - 1].FJKIELICMAH_DvfNew = false;
								}
								else if(item.NPADACLCNAN_Category == EKLNMHFCAOI.FKGCBLHOOCL_Category.NNBMEEPOBIO_DecoItemCostumeTorso)
								{
									CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.BEKHNNCGIEL_Costume.FABAGMLEKIB_List[id - 1].HBNNIHCGEOG(0, false);
								}
							}
						}
                    }
				}
			}
		}

		//// RVA: 0xC61BE0 Offset: 0xC61BE0 VA: 0xC61BE0
		//private DecorationDecorator.DecoratorType GetDecorationType(NDBFKHKMMCE.ANMODBDBNPK.DBAMIACJODJ itemCategory) { }

		//// RVA: 0xC61C0C Offset: 0xC61C0C VA: 0xC61C0C
		//private NDBFKHKMMCE.ANMODBDBNPK.DBAMIACJODJ GetItemCategory(DecorationDecorator.DecoratorType decoratorType) { }

		//// RVA: 0xC5FEC8 Offset: 0xC5FEC8 VA: 0xC5FEC8
		private List<List<KDKFHGHGFEK>> CreateCategoryItemLists(DecorationDecorator.DecoratorType type, int charaId = -1)
		{
			List<List<KDKFHGHGFEK>> res = new List<List<KDKFHGHGFEK>>(DecorationDecorator.tabCallBackList[(int)type].m_typeList.Length);
			for(int i = 0; i < DecorationDecorator.tabCallBackList[(int)type].m_typeList.Length; i++)
			{
				res.Add(CreateSelectItemDataList(type, DecorationDecorator.tabCallBackList[(int)type].m_typeList[i], charaId));
			}
			return res;
		}

		//// RVA: 0xC5FA70 Offset: 0xC5FA70 VA: 0xC5FA70
		private void UpdateItemPostLayout()
		{
			int a = m_decorationCanvas.GetObjectCount();
			m_layoutDecorationPostWindow.SettingPostRest(a);
			m_layoutDecorationPostWindow.SettingPostMax(m_objSettingMax);
			m_layoutDecorationRightButtons01.UpdateItemPostMax(m_objSettingMax <= a);
		}

		//// RVA: 0xC5F9C0 Offset: 0xC5F9C0 VA: 0xC5F9C0
		private void UpdateCharaPostLayout()
		{
			int a = m_decorationCanvas.GetCharaCount();
			m_layoutDecorationPostWindow.SettingPostRest(a);
			m_layoutDecorationPostWindow.SettingPostMax(m_charaSettingMax);
			m_layoutDecorationRightButtons01.UpdateCharaPostMax(m_charaSettingMax <= a);
		}

		//// RVA: 0xC5F1F8 Offset: 0xC5F1F8 VA: 0xC5F1F8
		private bool IsOverPostItem()
		{
			return m_objSettingMax <= m_decorationCanvas.GetObjectCount();
		}

		//// RVA: 0xC5F1B4 Offset: 0xC5F1B4 VA: 0xC5F1B4
		private bool IsOverPostChara()
		{
			return m_charaSettingMax <= m_decorationCanvas.GetCharaCount();
		}

		//// RVA: 0xC61C34 Offset: 0xC61C34 VA: 0xC61C34
		private void OnClickShowEditButton(bool isOpen)
		{
			ChangeState(isOpen ? StateType.SelectEditItem : StateType.Top, DecorationConstants.Attribute.Type.None);
			HideIcon();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
		}

		//// RVA: 0xC61EC8 Offset: 0xC61EC8 VA: 0xC61EC8
		private void OnClickEditButton(DecorationDecorator.DecoratorType type)
		{
			m_decoratorType = type;
			this.StartCoroutineWatched(Co_LoadPostSelectItems(type));
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
		}

		//// RVA: 0xC61F3C Offset: 0xC61F3C VA: 0xC61F3C
		private void OnClickEditMaxButton(DecorationDecorator.DecoratorType type)
		{
			if(!CheckOverPost(type))
				return;
			ShowPostMaxPopup(type);
		}

		//// RVA: 0xC61F68 Offset: 0xC61F68 VA: 0xC61F68
		private void ShowPostMaxPopup(DecorationDecorator.DecoratorType type)
		{
			SetEnableControllerTapGuard(true);
			TextPopupSetting s = PopupWindowManager.CreateMessageBankTextContent("menu", "pop_deco_set_max_title", type == DecorationDecorator.DecoratorType.Chara ? "pop_deco_chara_set_max_desc" : "pop_deco_item_set_max_desc", SizeType.Small, new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			});
			PopupWindowManager.Show(s, null, null, null, null, true, true, false, null, () =>
			{
				//0xC6DCC4
				SetEnableControllerTapGuard(false);
			});
		}

		//// RVA: 0xC5EFDC Offset: 0xC5EFDC VA: 0xC5EFDC
		private bool CheckOverPost(DecorationDecorator.DecoratorType type)
		{
			if(type >= DecorationDecorator.DecoratorType.Object && type < DecorationDecorator.DecoratorType.Serif)
				return IsOverPostItem();
			else if(type == DecorationDecorator.DecoratorType.Chara)
				return IsOverPostChara();
			return false;
		}

		//// RVA: 0xC622E8 Offset: 0xC622E8 VA: 0xC622E8
		private void OnClickDecoButton()
		{
			SetEnableControllerTapGuard(true);
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			m_decoCountPopupSetting.SetParent(transform);
			m_decoCountPopupSetting.TitleText = MessageManager.Instance.GetMessage("menu", "pop_deco_item_title");
			m_decoCountPopupSetting.WindowSize = 0;
			m_decoCountPopupSetting.decoCount = m_decorationCanvas.GetHaveDecorationItemCount();
			m_decoCountPopupSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			PopupWindowManager.Show(m_decoCountPopupSetting, null, null, null, null, true, true, false, null, () =>
			{
				//0xC6DCCC
				SetEnableControllerTapGuard(false);
			});
		}

		//// RVA: 0xC62608 Offset: 0xC62608 VA: 0xC62608
		private void ClickHomeButton()
		{
			ILCCJNDFFOB.HHCJCDFCLOB.CLGHLKLHEAK(JpStringLiterals.StringLiteral_15475, m_playerId);
			StopAllVoice();
			MenuScene.Instance.Mount(TransitionUniqueId.HOME, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
		}

		//// RVA: 0xC62784 Offset: 0xC62784 VA: 0xC62784
		private void ClickVisitButton()
		{
			ILCCJNDFFOB.HHCJCDFCLOB.CLGHLKLHEAK(JpStringLiterals.StringLiteral_15476, m_playerId);
			MenuScene.Instance.Call(TransitionList.Type.DECO_VISIT_LIST, new DecoVisitArgs() 
			{ 
				playerId = m_playerId, 
				decoPublicSetData = m_decoPublicSetData, 
				reloadSearchMember = m_reloadSearchMember 
			}, false);
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			m_isKeepCanvas = true;
			m_reloadSearchMember = false;
		}

		//// RVA: 0xC62978 Offset: 0xC62978 VA: 0xC62978
		private void ClickDecoBoardButton()
		{
			ILCCJNDFFOB.HHCJCDFCLOB.CLGHLKLHEAK(JpStringLiterals.StringLiteral_9366, m_playerId);
			StopAllVoice();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			DecoChatArgs arg = new DecoChatArgs();
			arg.playerId = NKGJPJPHLIF.HHCJCDFCLOB.CAFHLEFMMGD_GetPlayerId();
			MenuScene.Instance.Call(TransitionList.Type.DECO_CHAT, arg, true);
		}

		//// RVA: 0xC62B7C Offset: 0xC62B7C VA: 0xC62B7C
		private void ClickAllGetButton()
		{
			ILCCJNDFFOB.HHCJCDFCLOB.CLGHLKLHEAK(JpStringLiterals.StringLiteral_15477, m_playerId);
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(Co_DoAllGet());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D203C Offset: 0x6D203C VA: 0x6D203C
		//// RVA: 0xC62C98 Offset: 0xC62C98 VA: 0xC62C98
		private IEnumerator Co_DoAllGet()
		{
			//0x1572F78
			if(NKGJPJPHLIF.HHCJCDFCLOB.DPJBHHIHJJK)
			{
				MenuScene.Instance.InputDisable();
				m_decorationCanvas.EnableCanvasController(false);
				m_decorationCanvas.EnableItemController(DecorationItemManager.EnableControlType.None);
				bool isDone = false;
				NKGJPJPHLIF.HHCJCDFCLOB.CADNBFCHAKM(() =>
				{
					//0xC6E8F8
					isDone = true;
				}, () =>
				{
					//0xC6E1F4
					MenuScene.Instance.GotoTitle();
				});
				while(!isDone)
					yield return null;
				UpdateSpItemStatus();
				MenuScene.Instance.InputEnable();
				m_decorationCanvas.EnableCanvasController(true);
				m_decorationCanvas.EnableItemController(DecorationItemManager.EnableControlType.Unique);
			}
			if(MenuScene.CheckDatelineAndAssetUpdate())
				yield break;
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			yield return this.StartCoroutineWatched(Co_ReceiveSpItem(null, time));
		}

		//// RVA: 0xC62D20 Offset: 0xC62D20 VA: 0xC62D20
		public void ClickMenuDisableButton()
		{
			if(m_state == StateType.Top)
			{
				ChangeState(StateType.MenuDisable, DecorationConstants.Attribute.Type.None);
			}
			if(m_state == StateType.SelectEditItem)
			{
				ChangeState(StateType.EditMenuDisable, DecorationConstants.Attribute.Type.None);
			}
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
		}

		//// RVA: 0xC62DB4 Offset: 0xC62DB4 VA: 0xC62DB4
		private void OnClickMapChageButton()
		{
			MenuScene.Instance.Call(TransitionList.Type.DECO_BAST_STORAGE, new DecoStorageArgs()
			{
				decoPublicSetData = m_decoPublicSetData,
				decoPrivateSetData = m_decoPrivateSetData
			}, false);
			m_isKeepCanvas = true;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
		}

		//// RVA: 0xC62F18 Offset: 0xC62F18 VA: 0xC62F18
		private void OnClickMapNameEditButton()
		{
			ILCCJNDFFOB.HHCJCDFCLOB.CLGHLKLHEAK(JpStringLiterals.StringLiteral_15478, m_playerId);
			EnableControllerControl(false, DecorationItemManager.EnableControlType.None, CharaAnimationType.None);
			m_mapNameController.MapNameEdit(m_decoPublicSetData.LJMCPFACDGJ.CPOONLHIMKC_DecoRoomName, TryChangeMapName, NoChangeMapName);
			m_mapNameController.DecoTapGuardCallback = SetEnableControllerTapGuard;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
		}

		//// RVA: 0xC63178 Offset: 0xC63178 VA: 0xC63178
		private void NoChangeMapName()
		{
			ChangeState(StateType.Top, DecorationConstants.Attribute.Type.None);
		}

		//// RVA: 0xC63184 Offset: 0xC63184 VA: 0xC63184
		private void TryChangeMapName(string mapName)
		{
			MenuScene.Instance.InputDisable();
			SetEnableControllerTapGuard(true);
			this.StartCoroutineWatched(Co_TryChangeMapName(mapName));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D20B4 Offset: 0x6D20B4 VA: 0x6D20B4
		//// RVA: 0xC63250 Offset: 0xC63250 VA: 0xC63250
		private IEnumerator Co_TryChangeMapName(string mapName)
		{
			//0x158529C
			m_decoPublicSetData.LJMCPFACDGJ.CPOONLHIMKC_DecoRoomName = mapName;
			yield return this.StartCoroutineWatched(Co_SavePublicData(() =>
			{
				//0xC6E90C
				MenuScene.Instance.InputEnable();
				SetEnableControllerTapGuard(false);
				ChangeState(StateType.Top, DecorationConstants.Attribute.Type.None);
				m_layoutDecorationRightButtons01.ChangeMapName(mapName);
			}, () =>
			{
				//0xC6EA2C
				MenuScene.Instance.InputEnable();
				SetEnableControllerTapGuard(false);
				MenuScene.Instance.GotoTitle();
				m_mapNameController.ChangeMapName(false);
			}));
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DOPABKCMOOI(CIOECGOMILE.HHCJCDFCLOB.LGBMDHOLOIF_decoPlayerData, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MHEAEGMIKIE_PublicStatus.DALCINDEJLC_DcTm);
			bool isDone = false;
			bool isError = false;
			MenuScene.Instance.InputDisable();
			SetEnableControllerTapGuard(true);
			MenuScene.Save(() =>
			{
				//0xC6EB4C
				isDone = true;
			}, () =>
			{
				//0xC6EB58
				isDone = true;
				isError = true;
			});
			while(!isDone)
				yield return null;
			if(!isError)
			{
				MenuScene.Instance.InputEnable();
				m_mapNameController.ChangeMapName(true);
				SetEnableControllerTapGuard(false);
			}
			else
			{
				MenuScene.Instance.GotoTitle();
			}
		}

		//// RVA: 0xC62150 Offset: 0xC62150 VA: 0xC62150
		private void SetEnableControllerTapGuard(bool isEnable)
		{
			if(isEnable)
			{
				m_prevState = m_state;
				m_decorationCanvas.EnableItemController(DecorationItemManager.EnableControlType.None);
				m_decorationCanvas.EnableCanvasController(false);
				UpdateEditButton();
			}
			else
			{
				StateControlData prevData = StateControlTbl[(int)m_prevState];
				m_decorationCanvas.EnableItemController(prevData.enableItemControl);
				m_decorationCanvas.EnableCanvasController(prevData.enableCanvasControl);
			}
		}

		//// RVA: 0xC632F4 Offset: 0xC632F4 VA: 0xC632F4
		private void NewPostItemCallback(LayoutDecorationSelectItemBase item, bool isTapSelect)
		{
			if(m_decorationCanvas.IsLoadedItemDecoration)
			{
				this.StartCoroutineWatched(Co_NewPostItem(item, isTapSelect));
			}
			else
			{
				m_decorator.EnableSelectItem();
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D212C Offset: 0x6D212C VA: 0x6D212C
		//// RVA: 0xC63378 Offset: 0xC63378 VA: 0xC63378
		private IEnumerator Co_NewPostItem(LayoutDecorationSelectItemBase item, bool isTapSelect)
		{
			//0x1579D38
			MenuScene.Instance.InputDisable();
			if(item.Type == LayoutDecorationWindow01.SelectItemType.Serif)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_HOME_000);
				yield return this.StartCoroutineWatched(PostSerif(item));
			}
			else if(item.Type == LayoutDecorationWindow01.SelectItemType.Bg)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_HOME_000);
				ChangeBg(item.Id, item.SubId);
				ChangeState(StateType.SelectEditItem, DecorationConstants.Attribute.Type.None);
			}
			else if(!isTapSelect)
			{
				ChangeState(StateType.Edit, DecorationConstants.MakeAttribute(item.Data));
				m_decorationCanvas.ItemLock();
				yield return this.StartCoroutineWatched(PostItem(item, isTapSelect));
			}
			else
			{
				yield return this.StartCoroutineWatched(PostItem(item, true));
			}
			item.EnableSelectItem();
			MenuScene.Instance.InputEnable();
			m_decorationCanvas.ItemUnLock();
		}

		//// RVA: 0xC63434 Offset: 0xC63434 VA: 0xC63434
		private void OnClickChangeTab(DecorationDecorator.TabType tab)
		{
			List<KDKFHGHGFEK> l = CreateSelectItemDataList(m_decoratorType, tab, -1);
			SortItemList(ref l);
			List<FJGOKILCBJA> l2 = GetProductList(m_decoratorType, tab);
			int type = MakeType(m_decoratorType, tab);
			List<FJGOKILCBJA> productList = l2;
			if(m_decoratorType == DecorationDecorator.DecoratorType.Serif)
			{
				productList = new List<FJGOKILCBJA>();
				int charaId = 0;
				SeriesAttr.Type attr = 0;
				if(m_speakChara != null)
				{
					charaId = m_speakChara.Setting.viewDecoItemData.FPCGPGJOKNH_CharaId;
					attr = m_speakChara.Setting.viewDecoItemData.CPKMLLNADLJ_Serie;
				}
				for(int i = 0; i < l2.Count; i++)
				{
					KDKFHGHGFEK data = new KDKFHGHGFEK();
					data.KHEKNNFCAOI(EKLNMHFCAOI.DEACAHNLMNI_getItemId(l2[i].KIJAPOFAGPN_ItemFullId), EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif);
					if(type == -1 || data.GJMHALIIPME_Type == type)
					{
						//LAB_00c63730
						if(data.CPKMLLNADLJ_Serie > 0 && data.CPKMLLNADLJ_Serie != attr)
							continue;
						if(data.FPCGPGJOKNH_CharaId > 0 && data.FPCGPGJOKNH_CharaId != charaId)
							continue;
						productList.Add(l2[i]);
					}
				}
			}
			m_decorator.SetSelectItemDataList(tab, l, productList);
		}

		//// RVA: 0xC6419C Offset: 0xC6419C VA: 0xC6419C
		private void BuyItemCallback()
		{
			m_decorationCanvas.UpdateViewDecoItemList();
			UpdateDecoNumLayout();
			UpdateNewIcon();
			if(m_speakChara != null)
				UpdateSerifNewIcon(m_speakChara.Id);
			SetResetNewFlag(m_decoratorType, m_decorator.GetTabType());
		}

		//// RVA: 0xC6467C Offset: 0xC6467C VA: 0xC6467C
		private void ChangeBg(int id, int subId)
		{
			switch (subId)
			{
				case 0:
					m_decorationCanvas.LoadBgResource(id, id, id, false);
					break;
				case 1:
					m_decorationCanvas.LoadBgResource(id, -1, -1, false);
					break;
				case 2:
					m_decorationCanvas.LoadBgResource(-1, id, -1, false);
					break;
				case 3:
					m_decorationCanvas.LoadBgResource(-1, -1, id, false);
					break;
				default:
					break;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D21A4 Offset: 0x6D21A4 VA: 0x6D21A4
		//// RVA: 0xC64774 Offset: 0xC64774 VA: 0xC64774
		private IEnumerator PostSerif(LayoutDecorationSelectItemBase item)
		{
			//0x1586680
			m_layoutDecorationSerifAttacher.SettingSerif(item.Id);
			yield return Co.R(PostItem(item, true));
			m_decorator.UpdateHaveRestNum();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D221C Offset: 0x6D221C VA: 0x6D221C
		//// RVA: 0xC64818 Offset: 0xC64818 VA: 0xC64818
		private IEnumerator PostItem(LayoutDecorationSelectItemBase item, bool isTapSelect = true)
		{
			//0x1586150
			DecorationItemBaseSetting s = new DecorationItemBaseSetting(item.Data);
			m_postType = isTapSelect ? DecorationItemManager.PostType.TapNewPost : DecorationItemManager.PostType.DragNewPost;
			DecorationItemArgsBase arg = null;
			if(item.Type == LayoutDecorationWindow01.SelectItemType.Serif)
			{
				arg = new DecorationSerifArgs(item.Data.GBJFNGCDKPM, item.Data.DOIGLOBENMG, item.Data.DBGAJBIBODC, m_speakChara);
				m_postType = DecorationItemManager.PostType.Posted;
			}
			else
			{
				if(DecorationConstants.IsPoster(item.Data.NPADACLCNAN_Category))
				{
					arg = new DecorationPosterArgs(m_decorationCanvas.PosterKiraMaterial, m_decorationCanvas.PosterKiraMaterialFlip);
				}
			}
			s.InitPosition = item.DragItemPostion;
			yield return this.StartCoroutineWatched(Co_LoadItem(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(item.Data.NPADACLCNAN_Category, item.Id), s, arg));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D2294 Offset: 0x6D2294 VA: 0x6D2294
		//// RVA: 0xC648D4 Offset: 0xC648D4 VA: 0xC648D4
		private IEnumerator Co_LoadItem(int resourceId, DecorationItemBaseSetting setting, DecorationItemArgsBase args)
		{
			//0x1575D58
			if(resourceId != 0)
			{
				m_decorationCanvas.LoadItemResource(resourceId, setting, m_postType, args);
				yield return new WaitUntil(() =>
				{
					//0xC6DCD4
					return m_decorationCanvas.IsLoadedItemDecoration;
				});
			}
			if(args != null)
			{
				if(args is DecorationSerifArgs)
				{
					if(m_speakChara != null)
					{
						m_speakChara.NoSerif(resourceId == 0);
					}
					UpdateSerifSelectWindowButton(m_speakChara.IsChangeSerif());
				}
			}
			if(m_postType == DecorationItemManager.PostType.TapNewPost)
			{
				m_decorator.UpdateHaveRestNum(resourceId, m_decorationCanvas.GetItemList());
			}
		}

		//// RVA: 0xC649A8 Offset: 0xC649A8 VA: 0xC649A8
		private void OnClickExchangeButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MenuScene.Instance.InputDisable();
			SetEnableControllerTapGuard(true);
			if(!MenuScene.CheckDatelineAndAssetUpdate())
			{
				AODFBGCCBPE a = AODFBGCCBPE.FKDIMODKKJD(false).Find((AODFBGCCBPE _) =>
				{
					//0xC6E290
					return _.INDDJNMPONH == AODFBGCCBPE.NJMPLEENNPO.BJNAMAANNMB_5;
				});
				if(a == null)
				{
					Debug.Log(JpStringLiterals.StringLiteral_15479);
					MenuScene.Instance.InputEnable();
					SetEnableControllerTapGuard(false);
				}
				else
				{
					a.NBJNKFPEFGC();
					ShopProductScene.ShopProductArgs arg = new ShopProductScene.ShopProductArgs();
					arg.view = a;
					MenuScene.Instance.Call(TransitionList.Type.SHOP_PRODUCT, arg, false);
					ILCCJNDFFOB.HHCJCDFCLOB.CLGHLKLHEAK(JpStringLiterals.StringLiteral_15480, m_playerId);
					m_isKeepCanvas = true;
					m_isToExchangeScene = true;
				}
			}
		}

		//// RVA: 0xC64DB0 Offset: 0xC64DB0 VA: 0xC64DB0
		private void OnClickFriendSearchButton()
		{
			MenuScene.Instance.Call(TransitionList.Type.FRIEND_SEARCH, null, true);
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			m_isKeepCanvas = true;
		}

		//// RVA: 0xC60DF0 Offset: 0xC60DF0 VA: 0xC60DF0
		private List<KDKFHGHGFEK> CreateSelectItemDataList(DecorationDecorator.DecoratorType type, DecorationDecorator.TabType tab, int charaId = -1)
		{
			List<KDKFHGHGFEK> l1 = new List<KDKFHGHGFEK>();
			List<KDKFHGHGFEK> l2 = new List<KDKFHGHGFEK>();
			int t = MakeType(type, tab);
			if(type < DecorationDecorator.DecoratorType.Bg || type > DecorationDecorator.DecoratorType.ButtonNum)
				return l1;
			int cId = charaId;
			int serieId = -1;
			switch(type)
			{
				case DecorationDecorator.DecoratorType.Bg:
				{
					List<KDKFHGHGFEK> l3 = KDKFHGHGFEK.FKDIMODKKJD(NDBFKHKMMCE_DecoItem.ANMODBDBNPK.DBAMIACJODJ.PMJFENNOEJD_Bg);
					foreach(var it in l3)
					{
						l1.Add(it);
					}
					return l1;
				}
				break;
				case DecorationDecorator.DecoratorType.Chara:
				{
					List<KDKFHGHGFEK> l3 = KDKFHGHGFEK.FKDIMODKKJD(NDBFKHKMMCE_DecoItem.ANMODBDBNPK.DBAMIACJODJ.MIIELMELDBO_Char);
					foreach(var it in l3)
					{
						if(t == -1 || t == (int)it.CPKMLLNADLJ_Serie)
						{
							l1.Add(it);
						}
					}
					if(cId < 0)
					{
						cId = 0;
						if(m_speakChara != null)
						{
							cId = m_speakChara.Setting.viewDecoItemData.FPCGPGJOKNH_CharaId;
							//LAB_00c61668
							serieId = (int)m_speakChara.Setting.viewDecoItemData.CPKMLLNADLJ_Serie;
						}
					}
					else
					{
						if(cId == 0)
							cId = 0;
						else
						{
							if(m_speakChara != null)
							{
								serieId = (int)m_speakChara.Setting.viewDecoItemData.CPKMLLNADLJ_Serie;
							}
						}
					}
					return l1;
				}
				break;
				case DecorationDecorator.DecoratorType.Object:
				{
					List<KDKFHGHGFEK> l3 = KDKFHGHGFEK.FKDIMODKKJD(NDBFKHKMMCE_DecoItem.ANMODBDBNPK.DBAMIACJODJ.JKMLKAMHJIF_Obj);
					foreach(var it in l3)
					{
						if (tab == DecorationDecorator.TabType.Poster)
						{
							if (DecorationConstants.IsPoster(it.NPADACLCNAN_Category))
							{
								l1.Add(it);
							}
						}
						else
						{ 
							if (t == -1 || t == it.GJMHALIIPME_Type)
							{
								l1.Add(it);
							}
						}
					}
					l3 = KDKFHGHGFEK.FKDIMODKKJD(NDBFKHKMMCE_DecoItem.ANMODBDBNPK.DBAMIACJODJ.AAAOOKJAMGE_Sp);
					foreach(var it in l3)
					{
						if(it.GBJFNGCDKPM == 12)
						{
							if(t == -1 || t == it.GJMHALIIPME_Type)
							{
								l1.Add(it);
							}
						}
					}
					return l1;
				}
				case DecorationDecorator.DecoratorType.Extra:
				{
					//switchD_00c60eb4_caseD_3
					List<KDKFHGHGFEK> l3 = KDKFHGHGFEK.FKDIMODKKJD(NDBFKHKMMCE_DecoItem.ANMODBDBNPK.DBAMIACJODJ.AAAOOKJAMGE_Sp);
					foreach(var it in l3)
					{
						if(it.GJMHALIIPME_Type != 0)
						{
							if(it.GBJFNGCDKPM != 12)
							{
								if(t != -1)
								{
									if(it.GJMHALIIPME_Type != t)
										continue;
								}
								l1.Add(it);
							}
						}
					}
					return l1;
				}
				default:
				{
					if(cId < 0)
					{
						cId = 0;
						if(m_speakChara != null)
						{
							cId = m_speakChara.Setting.viewDecoItemData.FPCGPGJOKNH_CharaId;
							//LAB_00c61668
							serieId = (int)m_speakChara.Setting.viewDecoItemData.CPKMLLNADLJ_Serie;
						}
					}
					else
					{
						if(cId == 0)
							cId = 0;
						else
						{
							if(m_speakChara != null)
							{
								serieId = (int)m_speakChara.Setting.viewDecoItemData.CPKMLLNADLJ_Serie;
							}
						}
					}
					List<KDKFHGHGFEK> l3 = KDKFHGHGFEK.FKDIMODKKJD(NDBFKHKMMCE_DecoItem.ANMODBDBNPK.DBAMIACJODJ.BKLKNLDCJIO_Stamp);
					//LAB_00c6175c
					foreach(var it in l3)
					{
						if(t == -1 || it.GJMHALIIPME_Type == t)
						{
							if(serieId != -1 && (int)it.CPKMLLNADLJ_Serie > 0)
							{
								if(serieId != (int)it.CPKMLLNADLJ_Serie)
									continue;
							}
							int h = cId;
							if(cId > 0)
								h = it.FPCGPGJOKNH_CharaId;
							if(h > 0)
							{
								if(cId != it.FPCGPGJOKNH_CharaId)
									continue;
							}
							l1.Add(it);
						}
					}
					return l1;
				}
			}
			return l1;
		}

		//// RVA: 0xC64040 Offset: 0xC64040 VA: 0xC64040
		private int MakeType(DecorationDecorator.DecoratorType type, DecorationDecorator.TabType tab)
		{
			if(type >= DecorationDecorator.DecoratorType.Bg && type < DecorationDecorator.DecoratorType.Num)
			{
				switch(type)
				{
					case DecorationDecorator.DecoratorType.Bg:
						if(tab >= DecorationDecorator.TabType.BgSet && tab <= DecorationDecorator.TabType.BgFloor)
							return new int[] { 0, 2, 3, 1 } [(int)tab - 15];
						break;
					case DecorationDecorator.DecoratorType.Chara:
						switch(tab)
						{
							case DecorationDecorator.TabType.McDelta:
								return 1;
							case DecorationDecorator.TabType.McFrontia:
								return 2;
							case DecorationDecorator.TabType.McSeven:
								return 3;
							case DecorationDecorator.TabType.McFirst:
								return 4;
							case DecorationDecorator.TabType.McOthers:
								return 5;
						}
						break;
					case DecorationDecorator.DecoratorType.Object:
						if(tab >= DecorationDecorator.TabType.Have && tab < DecorationDecorator.TabType.SerifCommon)
						{
							switch(tab)
							{
								case DecorationDecorator.TabType.Have:
									return -1;
								case DecorationDecorator.TabType.Furniture_L:
									return 1;
								default:
									return (int)tab;
								case DecorationDecorator.TabType.Poster:
									return 99;
								case DecorationDecorator.TabType.Furniture_S:
									return 3;
								case DecorationDecorator.TabType.Furniture_Wall:
									return 4;
							}
						}
						//if(tab == DecorationDecorator.TabType.PlushToy)
						//??
						break;
					case DecorationDecorator.DecoratorType.Extra:
						return -1;
					case DecorationDecorator.DecoratorType.Serif:
						if(tab >= DecorationDecorator.TabType.Have && tab < DecorationDecorator.TabType.Pose1)
							return new int[12] { -1, -1, -1, -1, -1, -1, -1, 1, 2, 3, 4, 5 } [(int)tab];	
						break;
				}
			}
			return -1;
		}

		//// RVA: 0xC63894 Offset: 0xC63894 VA: 0xC63894
		private void SortItemList(ref List<KDKFHGHGFEK> selectList)
		{
			selectList.Sort((KDKFHGHGFEK a, KDKFHGHGFEK b) =>
			{
				//0xC6E2C0
				if(a.AKKLMEPIJBN == b.AKKLMEPIJBN)
				{
					if(a.EILKGEADKGH > 0)
					{
						if(b.EILKGEADKGH == 0)
							return -1;
					}
					if(a.EILKGEADKGH == 0)
					{
						if(b.EILKGEADKGH > 0)
							return 1;
					}
					if(a.EILKGEADKGH == b.EILKGEADKGH)
					{
						return a.PPFNGGCBJKC_Id.CompareTo(b.PPFNGGCBJKC_Id);
					}
					else
						return a.EILKGEADKGH.CompareTo(b.EILKGEADKGH);
				}
				return a.AKKLMEPIJBN.CompareTo(b.AKKLMEPIJBN);
			});
		}

		//// RVA: 0xC5C3A0 Offset: 0xC5C3A0 VA: 0xC5C3A0
		private void CreateShopProductList()
		{
			m_productsPicker.Create();
			m_productsCache.Clear();
		}

		//// RVA: 0xC639EC Offset: 0xC639EC VA: 0xC639EC
		private List<FJGOKILCBJA> GetProductList(DecorationDecorator.DecoratorType type, DecorationDecorator.TabType tab)
		{
			Predicate<FJGOKILCBJA> productFilter = (FJGOKILCBJA _) =>
			{
				//0xC6E4BC
				return _.EAIJAAEKDAB_GetNumRemain() > 0;
			};
			Dictionary<DecorationDecorator.TabType, List<FJGOKILCBJA>> d;
			if(m_productsCache.TryGetValue(type, out d))
			{
				List<FJGOKILCBJA> f;
				if(d.TryGetValue(tab, out f))
				{
					f.RemoveAll((FJGOKILCBJA _) =>
					{
						//0xC6EB64
						return !productFilter(_);
					});
					return f;
				}
			}
			else
			{
				d = new Dictionary<DecorationDecorator.TabType, List<FJGOKILCBJA>>();
				m_productsCache.Add(type, d);
			}
			int typeId = MakeType(type, tab);
			Predicate<KDKFHGHGFEK> p = (KDKFHGHGFEK _) =>
			{
				//0xC6EBE8
				if(typeId != -1)
				{
					if(_.GJMHALIIPME_Type != 0)
						return _.GJMHALIIPME_Type == typeId;
				}
				return true;
			};
			switch(type)
			{
				case DecorationDecorator.DecoratorType.Bg:
					m_productsCache[DecorationDecorator.DecoratorType.Bg][tab] = m_productsPicker.GetProducts(EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg, p, productFilter);
					return m_productsCache[DecorationDecorator.DecoratorType.Bg][tab];
				case DecorationDecorator.DecoratorType.Chara:
					m_productsCache[DecorationDecorator.DecoratorType.Chara][tab] = m_productsPicker.GetProducts(EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara, p, productFilter);
					return m_productsCache[DecorationDecorator.DecoratorType.Chara][tab];
				case DecorationDecorator.DecoratorType.Object:
					m_productsCache[DecorationDecorator.DecoratorType.Object][tab] = m_productsPicker.GetProducts(EKLNMHFCAOI.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj, p, productFilter);
					return m_productsCache[DecorationDecorator.DecoratorType.Object][tab];
				case DecorationDecorator.DecoratorType.Extra:
					m_productsCache[DecorationDecorator.DecoratorType.Extra][tab] = m_productsPicker.GetProducts(EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp, p, productFilter);
					return m_productsCache[DecorationDecorator.DecoratorType.Extra][tab];
				case DecorationDecorator.DecoratorType.Serif:
					m_productsCache[DecorationDecorator.DecoratorType.Serif][tab] = m_productsPicker.GetProducts(EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif, p, productFilter);
					return m_productsCache[DecorationDecorator.DecoratorType.Serif][tab];
				default:
					return new List<FJGOKILCBJA>();
			}
		}

		//// RVA: 0xC64EC4 Offset: 0xC64EC4 VA: 0xC64EC4
		private void ItemPointerDownCallback(DecorationItemBase item)
		{
			return;
		}

		//// RVA: 0xC64EC8 Offset: 0xC64EC8 VA: 0xC64EC8
		private void ItemClickCallback(DecorationItemBase item)
		{
			if(item != null)
			{
				if(item is DecorationSp)
				{
					DecorationSp itemSp = item as DecorationSp;
					if(itemSp.SpType <= NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.FKEDBMECLJG_12)
					{
						if(((1 << (int)itemSp.SpType) & 0x7f0U) == 0) // 0111 1111 0000
						{
							if(((1 << (int)itemSp.SpType) & 0x80eU) == 0) // 1000 0000 1110
							{
								if(itemSp.SpType != NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.FKEDBMECLJG_12)
									return;
								PointerDownPlushToyItem(itemSp);
								return;
							}
							this.StartCoroutineWatched(Co_PointerDownCollectionItem(item));
						}
						else
						{
							PointerDownTransporter(item);
						}
						SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_GIFT_000);
					}
				}
			}
		}

		//// RVA: 0xC65168 Offset: 0xC65168 VA: 0xC65168
		private void PointerDownPlushToyItem(DecorationSp item)
		{
			if(item != null)
			{
				if(!m_decorationCanvas.ItemManager.AnyCharaReacting())
				{
					if(m_decorationCanvas.ItemManager.ReactingPlushToys)
						return;
					m_decorationCanvas.ItemManager.ReactingPlushToys = true;
					m_cancelPlushToyReaction = false;
					this.StartCoroutineWatched(CO_PointerDownPlushToyItem(item));
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D230C Offset: 0x6D230C VA: 0x6D230C
		//// RVA: 0xC652E8 Offset: 0xC652E8 VA: 0xC652E8
		private IEnumerator CO_PointerDownPlushToyItem(DecorationSp item)
		{
			//0x1571500
			DecorationChara chara = null;
            List<DecorationChara> l = m_decorationCanvas.ItemManager.GetCharaList();
			int[] ints = new int[l.Count];
			int max = 0;
			for(int i = 0; i < l.Count; i++)
			{
				ints[i] = item.ViewData.PPOJIMKEGMF(l[i].ViewData.FPCGPGJOKNH_CharaId - 1);
				max += ints[i];
			}
			if(max > 0)
			{
				int a = UnityEngine.Random.Range(0, max);
				for(int i = 0; i < l.Count; i++)
				{
					if(a < ints[i])
					{
						chara = l[i];
						break;
					}
					a -= ints[i];
				}
			}
			if(chara != null)
			{
				bool isReadyCharaVoice = false;
				chara.PrepareVoiceCueSheet(() =>
				{
					//0xC6EDC8
					isReadyCharaVoice = true;
				});
				yield return new WaitUntil(() =>
				{
					//0xC6EDD4
					return isReadyCharaVoice;
				});
			}
			bool isReadyCueSheet = false;
			m_voicePlayer.RequestChangeCueSheet(DecorationConstants.MakeCharaCueSheetName(item.ViewData.BAGLABPGMMK), () =>
			{
				//0xC6EC68
				isReadyCueSheet = true;
			});
			yield return new WaitUntil(() =>
			{
				//0xC6EC74
				return isReadyCueSheet;
			});
			if(m_state >= StateType.Top && m_state <= StateType.MenuDisable && !m_cancelPlushToyReaction)
			{
				item.ShowPopupIcon();
				m_voicePlayer.Play("nuigurumi_000");
				yield return new WaitUntil(() =>
				{
					//0xC6EC7C
					if(m_state != StateType.Top && m_state != StateType.MenuDisable)
						return false;
					if(m_cancelPlushToyReaction)
						return false;
					return m_voicePlayer.isPlaying;
				});
				item.LeavePopupIcon();
				if(m_state >= StateType.Top && m_state < StateType.EditMenuDisable && !m_cancelPlushToyReaction)
				{
					if(chara != null)
					{
						chara.PlayVoice(DecorationChara.VoiceType.PlushToy, chara.ViewData.NBGONKHPADA(chara.ViewData.FPCGPGJOKNH_CharaId - 1));
						chara.ShowReactionGlad();
						chara.PlaySpecifiedReaction(DecorationCharaAnimController.ReactionSpecifiedType.Glad);
						yield return new WaitWhile(() =>
						{
							//0xC6ED28
							if(m_state != StateType.Top && m_state != StateType.MenuDisable)
								return false;
							if(m_cancelPlushToyReaction)
								return false;
							return chara.IsPlayVoice;
						});
					}
				}
			}
			//LAB_01571be0
			m_decorationCanvas.ItemManager.ReactingPlushToys = false;
        }

		//// RVA: 0xC65018 Offset: 0xC65018 VA: 0xC65018
		//private void PointerDownCollectionItem(DecorationItemBase item) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D2384 Offset: 0x6D2384 VA: 0x6D2384
		//// RVA: 0xC6538C Offset: 0xC6538C VA: 0xC6538C
		private IEnumerator Co_PointerDownCollectionItem(DecorationItemBase item)
		{
			//0x157BEE0
			if(NKGJPJPHLIF.HHCJCDFCLOB.DPJBHHIHJJK)
			{
				MenuScene.Instance.InputDisable();
				m_decorationCanvas.EnableCanvasController(false);
				m_decorationCanvas.EnableItemController(DecorationItemManager.EnableControlType.None);
				bool isDone = false;
				NKGJPJPHLIF.HHCJCDFCLOB.CADNBFCHAKM(() =>
				{
					//0xC6EE90
					isDone = true;
				}, () =>
				{
					//0xC6E4F8
					MenuScene.Instance.GotoTitle();
				});
				while(!isDone)
					yield return null;
				MenuScene.Instance.InputEnable();
				m_decorationCanvas.EnableCanvasController(true);
				m_decorationCanvas.EnableItemController(DecorationItemManager.EnableControlType.Unique);
			}
			if(MenuScene.CheckDatelineAndAssetUpdate())
				yield break;
			UpdateSpItemStatus();
			long currentTime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(item.ResourceId);
			if(item.Id != id)
				yield break;
			NDBFKHKMMCE_DecoItem.FIDBAFHNGCF dbItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK_Sp[id - 1];
			bool isReceivable = false;
			bool b2 = false;
			if(dbItem.GBJFNGCDKPM_SpType > 0 && dbItem.GBJFNGCDKPM_SpType - 1 < 3)
			{
				isReceivable = KDKFHGHGFEK.HMDOAKPBLFL_HasItemsReady(item.ResourceId, KDKFHGHGFEK.DFMGMEDILKB(item.ResourceId), currentTime);
			}
			else
			{
				b2 = dbItem.GBJFNGCDKPM_SpType == 11;
			}
			if(b2)
			{
				this.StartCoroutineWatched(Co_ReceiveSpItem(item, currentTime));
				yield break;
			}
			MakeSpCollectInfo(item, currentTime);
			m_decoSpCollectPopupSetting.m_info = m_decorationSpCollectInfo;
			m_decoSpCollectPopupSetting.m_info.isReceivable = isReceivable;
			m_decoSpCollectPopupSetting.TitleText = EKLNMHFCAOI.INCKKODFJAP_GetItemName(item.ResourceId);
			m_decoSpCollectPopupSetting.WindowSize = SizeType.Middle;
			m_decoSpCollectPopupSetting.m_parent = transform;
			m_decoSpCollectPopupSetting.Buttons = decoCollectPopupButton001;
			if(m_decorationSpCollectInfo.lv != m_decorationSpCollectInfo.lvNext && m_decorationSpCollectInfo.isAvailableLevelup)
				m_decoSpCollectPopupSetting.Buttons = decoCollectPopupButton002;
			if(isReceivable)
				m_decoSpCollectPopupSetting.Buttons = decoCollectPopupButton003;
			m_decorationCanvas.EnableItemController(DecorationItemManager.EnableControlType.None);
			m_decorationCanvas.EnableCanvasController(false);
			PopupWindowManager.Show(m_decoSpCollectPopupSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xC6EDE4
				this.StartCoroutineWatched(Co_DecoSpPopupAction(type, label, currentTime, item, id));
			}, null, null, null);
		}

		//// RVA: 0xC65430 Offset: 0xC65430 VA: 0xC65430
		private void UpdateSpItemStatus()
		{
            List<DecorationItemBase> l = m_decorationCanvas.GetItemList();
			for(int i = 0; i < l.Count; i++)
			{
				DecorationSp item = l[i] as DecorationSp;
				if(item != null)
				{
					if(!item.IsReceivableSpItem())
					{
						if(item.IsShowIcon())
						{
							item.SetIconHide();
						}
					}
				}
			}
        }

		//[IteratorStateMachineAttribute] // RVA: 0x6D23FC Offset: 0x6D23FC VA: 0x6D23FC
		//// RVA: 0xC6560C Offset: 0xC6560C VA: 0xC6560C
		private IEnumerator Co_DecoSpPopupAction(PopupButton.ButtonType type, PopupButton.ButtonLabel label, long currentTime, DecorationItemBase item, int id)
		{
			//0x15728A8
			yield return null;
			if(NKGJPJPHLIF.HHCJCDFCLOB.DPJBHHIHJJK)
			{
				bool isDone = false;
				NKGJPJPHLIF.HHCJCDFCLOB.CADNBFCHAKM(() =>
				{
					//0xC6EEA4
					isDone = true;
				}, () =>
				{
					//0xC6E594
					MenuScene.Instance.GotoTitle();
				});
				while(!isDone)
					yield return null;
			}
			//LAB_01572b28
			if(!MenuScene.CheckDatelineAndAssetUpdate())
			{
				m_decorationCanvas.EnableItemController(DecorationItemManager.EnableControlType.Unique);
				m_decorationCanvas.EnableCanvasController(true);
				if(type == PopupButton.ButtonType.Positive)
				{
					if(label == PopupButton.ButtonLabel.Collection)
					{
						this.StartCoroutineWatched(Co_ReceiveSpItem(item, currentTime));
					}
					else if(label == PopupButton.ButtonLabel.LevelUp)
					{
						BCGFHLIEKLJ_DecoItem.GNGFGEIAGJL saveIt = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.OMMNKDEODJP_DecoItem.NBKAMFFIOOG_Sp[id - 1];
						saveIt.EMHCHMHMFHJ_ChargeTimeOffset = KDKFHGHGFEK.CFNHNIMKPCI_GetChargeTimeOffset(saveIt, currentTime);
						saveIt.FOONCJDLLIK_ChargeTime = currentTime;
						saveIt.ANAJIAENLNB_Level++;
						this.StartCoroutineWatched(Co_SpItemLevelUp(item as DecorationSp, saveIt.ANAJIAENLNB_Level - 1));
					}
				}
			}
		}

		//// RVA: 0xC65728 Offset: 0xC65728 VA: 0xC65728
		private void MakeSpCollectInfo(DecorationItemBase item, long currentTime)
		{
			int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(item.ResourceId);
			NDBFKHKMMCE_DecoItem.FIDBAFHNGCF dbItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK_Sp[id - 1];
			BCGFHLIEKLJ_DecoItem.GNGFGEIAGJL saveItem = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.OMMNKDEODJP_DecoItem.NBKAMFFIOOG_Sp[id - 1];
			List<NEGELNMPEPH_DecoSpSetting.DAGLEHBMBLF> l = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.BGKKOOGPEFD_DecoSpSetting.ILCGCPIGAFP[saveItem.ANAJIAENLNB_Level - 1];
			NEGELNMPEPH_DecoSpSetting.DAGLEHBMBLF data = l[dbItem.GBJFNGCDKPM_SpType - 1];
			int a = 0;
			int c = 0;
			int d = 0;
			if(saveItem.ANAJIAENLNB_Level < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.BGKKOOGPEFD_DecoSpSetting.ILCGCPIGAFP.Count)
			{
				NEGELNMPEPH_DecoSpSetting.DAGLEHBMBLF data2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.BGKKOOGPEFD_DecoSpSetting.ILCGCPIGAFP[saveItem.ANAJIAENLNB_Level][dbItem.GBJFNGCDKPM_SpType - 1];
				c = Mathf.Max(data2.BCGKLONODHO - m_decorationCanvas.GetHaveDecorationItemCount(), 0);
				d = data2.NANNGLGOFKH_MaxNumber;
				a = data2.KPBJHHHMOJE_TimeToChargeMin;
			}
			int e = dbItem.KIJAPOFAGPN_ItemId;
			if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(e) == EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal)
			{
				if(EKLNMHFCAOI.DEACAHNLMNI_getItemId(e) == 0)
				{
					e = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ICICKEBMEFA_Medal.DNEKJCKEOHL_GetMonthlyItemFullId(currentTime);
				}
			}
			else if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(e) == 0)
			{
				e = item.ResourceId;
			}
			m_decorationSpCollectInfo.lv = saveItem.ANAJIAENLNB_Level;
			m_decorationSpCollectInfo.itemId = e;
			m_decorationSpCollectInfo.lvNext = Mathf.Min(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.BGKKOOGPEFD_DecoSpSetting.ILCGCPIGAFP.Count, saveItem.ANAJIAENLNB_Level + 1);
			m_decorationSpCollectInfo.lvMax = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.BGKKOOGPEFD_DecoSpSetting.ILCGCPIGAFP.Count;
			m_decorationSpCollectInfo.isAvailableLevelup = KDKFHGHGFEK.HMAOJBKJIOJ(item.ResourceId, saveItem.ANAJIAENLNB_Level, m_decorationCanvas.GetHaveDecorationItemCount());
			m_decorationSpCollectInfo.lvUpRestItemNum = c;
			m_decorationSpCollectInfo.isCannon = false;
			string str = MessageManager.Instance.GetMessage("menu", "pop_deco_sp_item_cannon_suffix");
			if(dbItem.GBJFNGCDKPM_SpType == 1)
			{
				m_decorationSpCollectInfo.isCannon = true;
			}
			else if(!m_decorationSpCollectInfo.isCannon)
			{
				str = EKLNMHFCAOI.NDBLEADIDLA(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(e), EKLNMHFCAOI.DEACAHNLMNI_getItemId(e));
			}
			m_decorationSpCollectInfo.nowPoint = string.Format(MessageManager.Instance.GetMessage("menu", "pop_deco_sp_item_point_format"), KDKFHGHGFEK.IOKFJAIDMLD_GetNumItemsReady(item.ResourceId, saveItem.ANAJIAENLNB_Level, currentTime), data.NANNGLGOFKH_MaxNumber, str);
			m_decorationSpCollectInfo.nextPoint = string.Format(MessageManager.Instance.GetMessage("menu", "pop_deco_sp_item_point_format"), KDKFHGHGFEK.IOKFJAIDMLD_GetNumItemsReady(item.ResourceId, saveItem.ANAJIAENLNB_Level, currentTime), d, str);
			m_decorationSpCollectInfo.isDiffrentPoint = data.NANNGLGOFKH_MaxNumber != d;
			m_decorationSpCollectInfo.nowTime = string.Format(MessageManager.Instance.GetMessage("menu", "pop_deco_sp_item_time_format"), data.KPBJHHHMOJE_TimeToChargeMin / 60, data.KPBJHHHMOJE_TimeToChargeMin % 60);
			m_decorationSpCollectInfo.nextTime = string.Format(MessageManager.Instance.GetMessage("menu", "pop_deco_sp_item_time_format"), a / 60, a % 60);
			m_decorationSpCollectInfo.isDiffrentTime = data.KPBJHHHMOJE_TimeToChargeMin != a;
			long t = saveItem.FOONCJDLLIK_ChargeTime - currentTime + data.KPBJHHHMOJE_TimeToChargeMin * 60;
			long t2 = t - saveItem.EMHCHMHMFHJ_ChargeTimeOffset;
			if(t2 < 0)
				t2 = 0;
			m_decorationSpCollectInfo.restTime = string.Format(MessageManager.Instance.GetMessage("menu", "pop_deco_sp_item_time_format"), t2 / 60 / 60, t2 / 60 % 60);
			m_decorationSpCollectInfo.isAvailableLevelup = KDKFHGHGFEK.HMAOJBKJIOJ(item.ResourceId, saveItem.ANAJIAENLNB_Level, m_decorationCanvas.GetHaveDecorationItemCount());
		}

		//// RVA: 0xC6503C Offset: 0xC6503C VA: 0xC6503C
		private void PointerDownTransporter(DecorationItemBase item)
		{
			TransitionUniqueId uniqueId;
			if(KDKFHGHGFEK.LDKPACJFPFK(item.ResourceId, out uniqueId))
			{
				MenuScene.Instance.Mount(uniqueId, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
			}
		}

		//// RVA: 0xC66620 Offset: 0xC66620 VA: 0xC66620
		private void OnClickAllRemoveButton()
		{
			this.StartCoroutineWatched(Co_RemoveAllItem());
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
		}

		//// RVA: 0xC66718 Offset: 0xC66718 VA: 0xC66718
		private void OnClickRemoveButton()
		{
			this.StartCoroutineWatched(Co_RemoveItem());
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
		}

		//// RVA: 0xC66810 Offset: 0xC66810 VA: 0xC66810
		private void OnClickSaveButton()
		{
			this.StartCoroutineWatched(Co_SaveButton());
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D2474 Offset: 0x6D2474 VA: 0x6D2474
		//// RVA: 0xC66880 Offset: 0xC66880 VA: 0xC66880
		private IEnumerator Co_SaveButton()
		{
			//0x1583750
			MenuScene.Instance.InputDisable();
			SetEnableControllerTapGuard(true);
			bool isOk = false;
			bool isClosed = false;
			TextPopupSetting s = PopupWindowManager.CreateMessageBankTextContent("menu", "popup_deco_save_title", "popup_deco_save_desc", SizeType.Small, new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive },
			});
			PopupWindowManager.Show(s, (PopupWindowControl ctl, PopupButton.ButtonType typ, PopupButton.ButtonLabel label) =>
			{
				//0xC6EEB8
				if(typ == PopupButton.ButtonType.Positive)
					isOk = true;
				isClosed = true;
			}, null, null, null);
			yield return new WaitUntil(() =>
			{
				//0xC6EED0
				return isClosed;
			});
			if(isOk)
			{
				if(NKGJPJPHLIF.HHCJCDFCLOB.DPJBHHIHJJK)
				{
					yield return this.StartCoroutineWatched(Co_UpdateDirtyTime());
				}
				SettingDecoPublicSetData();
				bool isError = false;
				this.StartCoroutineWatched(Co_SavePlayerData(() =>
				{
					//0xC6EF5C
					isError = true;
				}));
				if(isError)
				{
					MenuScene.Instance.GotoTitle();
					yield break;
				}
				yield return this.StartCoroutineWatched(Co_SavePublicData(() =>
				{
					//0xC6EED8
					ChangeState(StateType.Top, DecorationConstants.Attribute.Type.None);
					SetEnableControllerTapGuard(true);
				}, () =>
				{
					//0xC6E630
					MenuScene.Instance.GotoTitle();
				}));
				yield return new WaitUntil(() =>
				{
					//0xC6EF2C
					return IsPlayingEnd();
				});
				
			}
			//LAB_01583d70
			yield return Resources.UnloadUnusedAssets();
			GC.Collect();
			SetEnableControllerTapGuard(false);
			MenuScene.Instance.InputEnable();
		}

		//// RVA: 0xC5E528 Offset: 0xC5E528 VA: 0xC5E528
		private void EnterEditButton()
		{
			m_layoutDecorationLeftEditButton.Enter();
			m_layoutDecorationRightEditButton.Enter();
			UpdateEditButton();
		}

		//// RVA: 0xC5E580 Offset: 0xC5E580 VA: 0xC5E580
		private void LeaveEditButton()
		{
			m_layoutDecorationLeftEditButton.Leave();
			m_layoutDecorationRightEditButton.Leave();
		}

		//// RVA: 0xC5ECC8 Offset: 0xC5ECC8 VA: 0xC5ECC8
		private void UpdateEditButton()
		{
			if(m_decorationCanvas.GetCanEditItemCount() < 1)
				m_layoutDecorationLeftEditButton.DisableLeftButton();
			else
				m_layoutDecorationLeftEditButton.EnableLeftButton();
			if(m_decorationCanvas.GetEditItem() != null)
				m_layoutDecorationLeftEditButton.EnableRightButton();
			else
				m_layoutDecorationLeftEditButton.DisableRightButton();
			UpdateAllBackButton();
		}

		//// RVA: 0xC66908 Offset: 0xC66908 VA: 0xC66908
		private void UpdateAllBackButton()
		{
			m_layoutDecorationRightEditButton.EnableLeftButton();
		}

		//// RVA: 0xC66934 Offset: 0xC66934 VA: 0xC66934
		private bool IsMatchSaveData()
		{
			List<bool> l = new List<bool>();
			DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN s = DecorationItemToDecoSet(ref l);
			if(IsMatchBg(s, m_decoPublicSetData.LJMCPFACDGJ))
			{
				for(int i = 0; i < s.HBHMAKNGKFK_Items.Count; i++)
				{
					if(l[i])
						return false;
					if(!IsMatchItem(s.HBHMAKNGKFK_Items[i], m_decoPublicSetData.LJMCPFACDGJ.HBHMAKNGKFK_Items[i]))
						return false;
				}
				return true;
			}
			return false;
		}

		//// RVA: 0xC66B30 Offset: 0xC66B30 VA: 0xC66B30
		private DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN DecorationItemToDecoSet(ref List<bool> isMoved)
		{
            List<DecorationItemBase> l = m_decorationCanvas.GetItemList();
			DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN res = new DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN();
			for(int i = 0; i < res.HBHMAKNGKFK_Items.Count; i++)
			{
				isMoved.Add(false);
			}
			for(int i = 0; i < l.Count; i++)
			{
				isMoved[i] = l[i].IsMoved;
				res.HBHMAKNGKFK_Items[i] = CreateItemInfo(l[i]);
			}
			return res;
        }

		//// RVA: 0xC673A0 Offset: 0xC673A0 VA: 0xC673A0
		private DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.MHODOAJPNHD CreateItemInfo(DecorationItemBase item)
		{
			DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.MHODOAJPNHD res = new DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.MHODOAJPNHD();
			res.HAJKNHNAIKL_ItemId = item.ResourceId;
			res.GHPLINIACBB_PosX = item.Position.x;
			res.PMBEODGMMBB_PosY = item.Position.y;
			res.BEJGNPAAKNB_Word = item.GetSerifId();
			res.BNHOEFJAAKK_Prio = -1;
			if(item.Setting.PriorityControl != DecorationItemBaseSetting.PriorityControlType.Floor)
				res.BNHOEFJAAKK_Prio = item.SortingOrder;
			res.BDEEIPPDCLE_Rvs = item.IsFlip();
			res.PMIPFEJFIHA_StatusFlag = item.m_statusFlag;
			return res;
		}

		//// RVA: 0xC66D9C Offset: 0xC66D9C VA: 0xC66D9C
		private bool IsMatchBg(DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN lhs, DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN rhs)
		{
			int floorId, wallLId, wallRId;
			m_decorationCanvas.GetBgResourceId(out floorId, out wallLId, out wallRId);
			lhs.KIDHLCNFCKN_FloorId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg, floorId);
			lhs.DJCJMCHMIMA_WallLId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg, wallLId);
			lhs.KCMEAABOIOA_WallRId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg, wallRId);
			if(lhs.KIDHLCNFCKN_FloorId == rhs.KIDHLCNFCKN_FloorId)
			{
				if(lhs.DJCJMCHMIMA_WallLId == rhs.DJCJMCHMIMA_WallLId)
				{
					if(lhs.KCMEAABOIOA_WallRId == rhs.KCMEAABOIOA_WallRId)
					{
						return lhs.HBHMAKNGKFK_Items.Count == rhs.HBHMAKNGKFK_Items.Count;
					}
				}
			}
			return false;
		}

		//// RVA: 0xC67064 Offset: 0xC67064 VA: 0xC67064
		private bool IsMatchItem(DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.MHODOAJPNHD lhs, DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.MHODOAJPNHD rhs)
		{
			if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(lhs.HAJKNHNAIKL_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara && EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(rhs.HAJKNHNAIKL_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara)
			{
				;
			}
			else if(lhs.GHPLINIACBB_PosX != rhs.GHPLINIACBB_PosX)
				return false;
			else if(lhs.PMBEODGMMBB_PosY != rhs.PMBEODGMMBB_PosY)
				return false;
			else if(lhs.BDEEIPPDCLE_Rvs != rhs.BDEEIPPDCLE_Rvs)
				return false;
			else if(lhs.PMIPFEJFIHA_StatusFlag != rhs.PMIPFEJFIHA_StatusFlag)
				return false;
			else if(rhs.BNHOEFJAAKK_Prio != -1 && lhs.BNHOEFJAAKK_Prio != rhs.BNHOEFJAAKK_Prio)
				return false;
			return lhs.HAJKNHNAIKL_ItemId == rhs.HAJKNHNAIKL_ItemId && lhs.BEJGNPAAKNB_Word == rhs.BEJGNPAAKNB_Word;
		}

		//// RVA: 0xC675EC Offset: 0xC675EC VA: 0xC675EC
		private bool IsSameItem(DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.MHODOAJPNHD lhs, DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.MHODOAJPNHD rhs)
		{
			return lhs.HAJKNHNAIKL_ItemId == rhs.HAJKNHNAIKL_ItemId;
		}

		//// RVA: 0xC6764C Offset: 0xC6764C VA: 0xC6764C
		private void RemovePublicSetDataVisitItem()
		{
			foreach(var c in m_decoPublicSetData.LJMCPFACDGJ.HBHMAKNGKFK_Items)
			{
				if(DecorationConstants.IsItemSpVisit(c))
				{
					c.LHPDDGIJKNB();
					return;
				}
			}
		}

		//// RVA: 0xC67810 Offset: 0xC67810 VA: 0xC67810
		public void OnClickAllBackButton()
		{
			this.StartCoroutineWatched(Co_AllBack());
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D24EC Offset: 0x6D24EC VA: 0x6D24EC
		//// RVA: 0xC67880 Offset: 0xC67880 VA: 0xC67880
		private IEnumerator Co_AllBack()
		{
			//0x1572090
			MenuScene.Instance.InputDisable();
			SetEnableControllerTapGuard(true);
			if(!IsMatchSaveData())
			{
				bool isOk = false;
				bool isClosed = false;
				TextPopupSetting s = PopupWindowManager.CreateMessageBankTextContent("menu", "popup_deco_all_back_title", "popup_deco_all_back_desc", SizeType.Small, new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				});
				PopupWindowManager.Show(s, (PopupWindowControl ctl, PopupButton.ButtonType typ, PopupButton.ButtonLabel label) =>
				{
					//0xC6EF70
					if(typ == PopupButton.ButtonType.Positive)
						isOk = true;
					isClosed = true;
				}, null, null, null);
				yield return new WaitUntil(() =>
				{
					//0xC6EF88
					return isClosed;
				});
				if(isOk)
				{
					m_decorationCanvas.HideLayoutController();
					yield return this.StartCoroutineWatched(Co_LoadAllBackDecoration());
					ChangeState(StateType.Top, DecorationConstants.Attribute.Type.None);
					SetEnableControllerTapGuard(true);
					yield return new WaitUntil(() =>
					{
						//0xC6DD00
						return IsPlayingEnd();
					});
				}
				//LAB_0157223c
			}
			else
			{
				ChangeState(StateType.Top, DecorationConstants.Attribute.Type.None);
				SetEnableControllerTapGuard(true);
				yield return new WaitUntil(() =>
				{
					//0xC6DD04
					return IsPlayingEnd();
				});
			}
			//LAB_01572250
			yield return Resources.UnloadUnusedAssets();
			GC.Collect();
			SetEnableControllerTapGuard(false);
			MenuScene.Instance.InputEnable();
			UpdateEditButton();
			UpdateItemPostLayout();
			UpdateCharaPostLayout();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D2564 Offset: 0x6D2564 VA: 0x6D2564
		//// RVA: 0xC67908 Offset: 0xC67908 VA: 0xC67908
		private IEnumerator Co_SavePlayerData(DJBHIFLHJLK onError)
		{
			//0x1584120
			MenuScene.Instance.InputDisable();
			bool isDone = false;
			bool isError = false;
			MenuScene.Save(() =>
			{
				//0xC6EF98
				isDone = true;
			}, () =>
			{
				//0xC6EFA4
				isDone = true;
				isError = true;
			});
			while(!isDone)
				yield return null;
			MenuScene.Instance.InputEnable();
			if(isError)
			{
				if(onError != null)
					onError();
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D25DC Offset: 0x6D25DC VA: 0x6D25DC
		//// RVA: 0xC67990 Offset: 0xC67990 VA: 0xC67990
		private IEnumerator Co_SavePublicData(Action endCallback, DJBHIFLHJLK onError) 
		{
			//0x1584458
			MenuScene.Instance.InputDisable();
			CIOECGOMILE.HHCJCDFCLOB.LGBMDHOLOIF_decoPlayerData.AHEFHIMGIBI.PDKHANKAPCI_DecoPublicSet.ODDIHGPONFL_Copy(m_decoPublicSetData);
			bool isSaved = false;
			bool isError = false;
			CIOECGOMILE.HHCJCDFCLOB.OEAMJGPAIGP(CIOECGOMILE.HHCJCDFCLOB.LGBMDHOLOIF_decoPlayerData, () =>
			{
				//0xC6EFB8
				isSaved = true;
			}, () =>
			{
				//0xC6EFC4
				isSaved = true;
				isError = true;
			}, null);
			yield return new WaitUntil(() =>
			{
				//0xC6EFD0
				return isSaved;
			});
			MenuScene.Instance.InputEnable();
			if(!isError)
			{
				if(endCallback != null)
					endCallback();
			}
			else
			{
				onError();
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D2654 Offset: 0x6D2654 VA: 0x6D2654
		//// RVA: 0xC67A4C Offset: 0xC67A4C VA: 0xC67A4C
		public static IEnumerator Co_UpdateDirtyTime()
		{
			//0x15858EC
			if(NKGJPJPHLIF.HHCJCDFCLOB.DPJBHHIHJJK)
			{
				bool isDone = false;
				NKGJPJPHLIF.HHCJCDFCLOB.CADNBFCHAKM(() =>
				{
					//0xC6EFE0
					isDone = true;
				}, () =>
				{
					//0xC6E6CC
					MenuScene.Instance.GotoTitle();
				});
				while(!isDone)
					yield return null;
			}
		}

		//// RVA: 0xC67ABC Offset: 0xC67ABC VA: 0xC67ABC
		private void SendSetDecoItemLogs()
		{
			Dictionary<long, int> dict = new Dictionary<long, int>();
			for(int i = 0; i < m_decoPublicSetData.LJMCPFACDGJ.HBHMAKNGKFK_Items.Count; i++)
			{
                DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.MHODOAJPNHD item = m_decoPublicSetData.LJMCPFACDGJ.HBHMAKNGKFK_Items[i];
                if (item.HAJKNHNAIKL_ItemId != 0)
				{
                    EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(item.HAJKNHNAIKL_ItemId);
					int a = 3;
					if(cat != EKLNMHFCAOI.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj && cat >= EKLNMHFCAOI.FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster && cat <= EKLNMHFCAOI.FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft)
					{
						a = 1;
						if(item.GHPLINIACBB_PosX >= 0)
							a = 2;
					}
					// a = a | item.HAJKNHNAIKL_ItemId??
					int v;
					if(!dict.TryGetValue(a, out v))
						dict.Add(a, 1);
					else
						dict[a] = v + 1;
                }
			}
			Dictionary<long, int> dict2 = new Dictionary<long, int>();
            List<DecorationItemBase> l = m_decorationCanvas.GetItemList();
			for(int i = 0; i < l.Count; i++)
			{
				if(l[i].ResourceId != 0)
				{
					EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(l[i].ResourceId);
					int a = 3;
					if(cat != EKLNMHFCAOI.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj && cat >= EKLNMHFCAOI.FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster && cat <= EKLNMHFCAOI.FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft)
					{
						a = 1;
						if(l[i].Position.x >= 0)
							a = 2;
					}
					// a = a | item.HAJKNHNAIKL_ItemId??
					int v;
					if(!dict.TryGetValue(a, out v))
						dict.Add(a, 1);
					else
						dict[a] = v + 1;
				}
			}
			foreach(var kv in dict)
			{
				int v;
				if(!dict2.TryGetValue(kv.Key, out v))
				{
					for(int i = 0; i < kv.Value; i++)
					{
						ILCCJNDFFOB.HHCJCDFCLOB.MIDMMEHCCFA((int)kv.Key, (int)(kv.Key >> 32), true);
					}
				}
				else
				{
					if(v < kv.Value)
					{
						int max = kv.Value - v;
						for(int i = 0; i < max; i++)
						{
							ILCCJNDFFOB.HHCJCDFCLOB.MIDMMEHCCFA((int)kv.Key, (int)(kv.Key >> 32), true);
						}
					}
				}
			}
        }

		//// RVA: 0xC68960 Offset: 0xC68960 VA: 0xC68960
		private void SettingDecoPublicSetData()
		{
			SendSetDecoItemLogs();
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			List<BCGFHLIEKLJ_DecoItem.GNGFGEIAGJL> l3 = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.OMMNKDEODJP_DecoItem.NBKAMFFIOOG_Sp;
			List<NDBFKHKMMCE_DecoItem.FIDBAFHNGCF> l2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK_Sp;
			//IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.BGKKOOGPEFD_DecoSpSetting;
            List<DecorationItemBase> l = m_decorationCanvas.GetItemList();
            exItemListupWork.Clear();
			for(int i = 0; i < m_decoPublicSetData.LJMCPFACDGJ.HBHMAKNGKFK_Items.Count; i++)
			{
                DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.MHODOAJPNHD it = m_decoPublicSetData.LJMCPFACDGJ.HBHMAKNGKFK_Items[i];
				if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(it.HAJKNHNAIKL_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp)
				{
					exItemListupWork.Add(EKLNMHFCAOI.DEACAHNLMNI_getItemId(it.HAJKNHNAIKL_ItemId));
				}
            }
			string name = m_decoPublicSetData.LJMCPFACDGJ.CPOONLHIMKC_DecoRoomName;
			m_decoPublicSetData.LJMCPFACDGJ.KMBPACJNEOF();
			for(int i = 0; i < l.Count; i++)
			{
				DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.MHODOAJPNHD data = new DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.MHODOAJPNHD();
				data.HAJKNHNAIKL_ItemId = l[i].ResourceId;
				data.GHPLINIACBB_PosX = l[i].Position.x;
				data.PMBEODGMMBB_PosY = l[i].Position.y;
				data.BEJGNPAAKNB_Word = l[i].GetSerifId();
				data.BNHOEFJAAKK_Prio = l[i].SortingOrder;
				data.BDEEIPPDCLE_Rvs = l[i].IsFlip();
				data.PMIPFEJFIHA_StatusFlag = l[i].m_statusFlag;
				m_decoPublicSetData.LJMCPFACDGJ.HBHMAKNGKFK_Items[i] = data;
				if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(l[i].ResourceId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp)
				{
					int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(l[i].ResourceId);
					if(!exItemListupWork.Exists((int x) =>
					{
						//0xC6EFEC
						return id == x;
					}))
					{
						if(l2[id - 1].GBJFNGCDKPM_SpType < 4)
						{
							l3[id - 1].FOONCJDLLIK_ChargeTime = time;
							l3[id - 1].EMHCHMHMFHJ_ChargeTimeOffset = 0;
							SendPushMessage(l2[id - 1], l3[id - 1].ANAJIAENLNB_Level, time, 0);
						}
						exItemListupWork.Remove(id);
					}
				}
			}
			for(int i = 0; i < exItemListupWork.Count; i++)
			{
				int id = exItemListupWork[i];
                NDBFKHKMMCE_DecoItem.FIDBAFHNGCF item = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK_Sp[id - 1];
				if(!m_decoPublicSetData.LJMCPFACDGJ.HBHMAKNGKFK_Items.Exists((DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.MHODOAJPNHD x) =>
				{
					//0xC6F000
					if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(x.HAJKNHNAIKL_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp)
					{
						if(EKLNMHFCAOI.DEACAHNLMNI_getItemId(x.HAJKNHNAIKL_ItemId) == id)
							return true;
					}
					return false;
				}))
				{
					EOHDAOAJOHH.HHCJCDFCLOB.NINPDKEKNEG((NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC)item.GBJFNGCDKPM_SpType);
				}
            }
			int floorId, wallFId, wallRId;
			m_decorationCanvas.GetBgResourceId(out floorId, out wallFId, out wallRId);
			m_decoPublicSetData.LJMCPFACDGJ.KIDHLCNFCKN_FloorId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg, floorId);
			m_decoPublicSetData.LJMCPFACDGJ.DJCJMCHMIMA_WallLId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg, wallFId);
			m_decoPublicSetData.LJMCPFACDGJ.KCMEAABOIOA_WallRId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg, wallRId);
			m_decoPublicSetData.LJMCPFACDGJ.CPOONLHIMKC_DecoRoomName = name;
		}

		//// RVA: 0xC69F9C Offset: 0xC69F9C VA: 0xC69F9C
		private void SendPushMessage(int itemId, long chargeTime, long chargeTimeOffset)
		{
			int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(itemId);
			NDBFKHKMMCE_DecoItem.FIDBAFHNGCF dbItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK_Sp[id - 1];
			BCGFHLIEKLJ_DecoItem.GNGFGEIAGJL saveItem = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.OMMNKDEODJP_DecoItem.NBKAMFFIOOG_Sp[id - 1];
			SendPushMessage(dbItem, saveItem.ANAJIAENLNB_Level, chargeTime, chargeTimeOffset);
		}

		//// RVA: 0xC69BAC Offset: 0xC69BAC VA: 0xC69BAC
		public static void SendPushMessage(NDBFKHKMMCE_DecoItem.FIDBAFHNGCF spItemMaster, int currentLevel, long chargeTime, long chargeTimeOffset)
		{
			string str1 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.EFEGBHACJAL("deco_push_title", "");
			string str2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.EFEGBHACJAL("deco_push_message", "");
			EOHDAOAJOHH.HHCJCDFCLOB.GCKBFMOMFCG((NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC)spItemMaster.GBJFNGCDKPM_SpType, 28 - chargeTimeOffset + IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.BGKKOOGPEFD_DecoSpSetting.ILCGCPIGAFP[currentLevel - 1][spItemMaster.GBJFNGCDKPM_SpType - 1].KPBJHHHMOJE_TimeToChargeMin * 60, str1,  string.Format(str2, EKLNMHFCAOI.INCKKODFJAP_GetItemName(EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp, spItemMaster.PPFNGGCBJKC_Id)), IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA("deco_push_pict_id", 1));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D26CC Offset: 0x6D26CC VA: 0x6D26CC
		//// RVA: 0xC5EBB8 Offset: 0xC5EBB8 VA: 0xC5EBB8
		public IEnumerator Co_LoadPostSelectItems(DecorationDecorator.DecoratorType type)
		{
			//0x1577240
			MenuScene.Instance.InputDisable();
			SetEnableControllerTapGuard(true);
			m_touchGuardArea.gameObject.SetActive(true);
			m_decorator.LoadSelectItems(type, DecorationDecorator.TabType.None);
			yield return new WaitUntil(() =>
			{
				//0xC6DD08
				return m_decorator.IsLoadedResource;
			});
			ChangeState(StateType.SelectPostItem, DecorationConstants.Attribute.Type.None);
			SetEnableControllerTapGuard(true);
			SettingWindowButton(type);
			UpdateItemSelectWindowButton(type);
			UpdateNewIcon();
			if(m_speakChara != null)
				UpdateSerifNewIcon(m_speakChara.Id);
			SetResetNewFlag(type, DecorationDecorator.TabType.None);
			m_decorationCanvas.AutoZoomOut();
			yield return new WaitUntil(() =>
			{
				//0xC6DD34
				return m_decorator.IsPlayingEnd();
			});
			if(type == DecorationDecorator.DecoratorType.Extra)
			{
				yield return this.StartCoroutineWatched(TryShowTutorial_Extra());
			}
			else if(type == DecorationDecorator.DecoratorType.Chara)
			{
				yield return this.StartCoroutineWatched(TryShowTutorial_Chara());
			}
			SetEnableControllerTapGuard(false);
			MenuScene.Instance.InputEnable();
			m_touchGuardArea.gameObject.SetActive(false);
		}

		//// RVA: 0xC64390 Offset: 0xC64390 VA: 0xC64390
		private void SetResetNewFlag(DecorationDecorator.DecoratorType type, DecorationDecorator.TabType tab)
		{
			bool f = false;
			foreach(var k in m_resetNewFlagList)
			{
				if(k.m_type == type && k.m_tab == tab)
				{
					if(m_speakChara != null)
					{
						if(m_speakChara.Id == k.m_charaId)
						{
							f = true;
						}
					}
					else
					{
						f = true;
					}
				}
			}
			if(!f)
			{
				int a = 0;
				if(m_speakChara != null)
					a = m_speakChara.Id;
				m_resetNewFlagList.Add(new ResetNewFlagData() { m_type = type, m_tab = tab, m_charaId = a });
			}
		}

		//// RVA: 0xC5E3A8 Offset: 0xC5E3A8 VA: 0xC5E3A8
		private void UpdateRightButtonNewIcon()
		{
			NewIconInfo info = new NewIconInfo();
			MakeNewIconInfo(ref info);
			List<bool> l = new List<bool>();
			for(int i = 0; i < info.categoryInfos.Length; i++)
			{
				l.Add(info.categoryInfos[i].isAnyNew);
			}
			m_layoutDecorationRightButtons01.SetEditNew(l);
			m_layoutDecorationRightButtons01.SetNew(info.isEditButtonNew);
		}

		//// RVA: 0xC642C0 Offset: 0xC642C0 VA: 0xC642C0
		private void UpdateNewIcon()
		{
			if(m_decoratorType < DecorationDecorator.DecoratorType.Num)
			{
				CategoryNewIconInfo info = new CategoryNewIconInfo();
				MakeCategoryNewIconInfo(ref info, m_decoratorType, -1);
				m_decorator.SetNewIcon(info.isTabNewList);
			}
		}

		//// RVA: 0xC64330 Offset: 0xC64330 VA: 0xC64330
		private void UpdateSerifNewIcon(int charaId)
		{
			CategoryNewIconInfo info = new CategoryNewIconInfo();
			MakeCategoryNewIconInfo(ref info, DecorationDecorator.DecoratorType.Serif, charaId);
			m_decorator.SetNewIcon(info.isTabNewList);
		}

		//// RVA: 0xC5E838 Offset: 0xC5E838 VA: 0xC5E838
		private void SettingWindowButton(DecorationDecorator.DecoratorType type)
		{
			if(type >= DecorationDecorator.DecoratorType.Chara && type <= DecorationDecorator.DecoratorType.Extra)
			{
				m_decorator.ClickLeftButtonCallback = null;
				m_decorator.ClickRightButtonCallback = OnClickSelectWindowCloseButton;
			}
			else if(type == DecorationDecorator.DecoratorType.Bg)
			{
				m_decorator.ClickLeftButtonCallback = null;
				m_decorator.ClickRightButtonCallback = OnClickSelectWindowCloseButton;
			}
			else if(type == DecorationDecorator.DecoratorType.Serif)
			{
				m_decorator.ClickLeftButtonCallback = OnClickCloseSerifButton;
				m_decorator.ClickRightButtonCallback = OnClickDecideSerifButton;
			}
			m_decorator.LeftButtonHidden = m_decorator.ClickLeftButtonCallback == null;
			m_decorator.RightButtonHidden = m_decorator.ClickRightButtonCallback == null;
		}

		//// RVA: 0xC6A22C Offset: 0xC6A22C VA: 0xC6A22C
		private void OnClickCloseSerifButton()
		{
			m_speakChara.RollbackSerif();
			CommonClickSerifButton();
		}

		//// RVA: 0xC6A300 Offset: 0xC6A300 VA: 0xC6A300
		private void OnClickDecideSerifButton()
		{
			m_speakChara.DecideSerif();
			CommonClickSerifButton();
		}

		//// RVA: 0xC6A264 Offset: 0xC6A264 VA: 0xC6A264
		private void CommonClickSerifButton()
		{
			EnableSerifAttacherCover(false);
			m_layoutDecorationSerifAttacher.Hide();
			m_speakChara = null;
			ChangeState(StateType.SelectEditItem, DecorationConstants.Attribute.Type.None);
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
		}

		//// RVA: 0xC6A338 Offset: 0xC6A338 VA: 0xC6A338
		private void OnClickSelectWindowCloseButton()
		{
			m_decorationCanvas.CanvasFollowTouch(true);
			m_decorationCanvas.RestoreEditItem();
			ChangeState(StateType.SelectEditItem, DecorationConstants.Attribute.Type.None);
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D2744 Offset: 0x6D2744 VA: 0x6D2744
		//// RVA: 0xC66788 Offset: 0xC66788 VA: 0xC66788
		private IEnumerator Co_RemoveItem()
		{
			//0x1582F4C
			yield return this.StartCoroutineWatched(Co_RemoveItem(m_decorationCanvas.GetEditItem()));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D27BC Offset: 0x6D27BC VA: 0x6D27BC
		//// RVA: 0xC6A3E8 Offset: 0xC6A3E8 VA: 0xC6A3E8
		private IEnumerator Co_RemoveItem(DecorationItemBase item)
		{
			DecorationItemBase selectItem;

			//0x15830A4
			selectItem = item;
			bool isWait = true;
			bool isDecide = true;
			if (selectItem == null)
				yield break;
			if(KDKFHGHGFEK.HANJGFKOGGO(selectItem.ResourceId))
			{
				m_spItemRemovePopup.TitleText = MessageManager.Instance.GetMessage("menu", "pop_deco_sp_item_remove_title");
				m_spItemRemovePopup.m_parent = transform;
				m_spItemRemovePopup.Buttons = new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				m_spItemRemovePopup.itemList.Clear();
				m_spItemRemovePopup.itemList.Add(item.ResourceId);
				m_spItemRemovePopup.WindowSize = SizeType.Middle;
				isDecide = false;
				PopupWindowManager.Show(m_spItemRemovePopup, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0xC6F128
					if (type == PopupButton.ButtonType.Positive)
						isDecide = true;
					isWait = false;
				}, null, null, null);
				while (isWait)
					yield return null;
			}
			//LAB_0158358c
			if(isDecide)
			{
				m_decorationCanvas.RemoveItem(selectItem);
				m_decorationCanvas.HideSelectItemLayout();
				UpdatePostLayout(item.DecorationItemCategory);
				UpdateEditButton();
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D2834 Offset: 0x6D2834 VA: 0x6D2834
		//// RVA: 0xC66690 Offset: 0xC66690 VA: 0xC66690
		private IEnumerator Co_RemoveAllItem()
		{
			//0x1582A74
			bool isOk = false;
			bool isClosed = false;
			TextPopupSetting s = PopupWindowManager.CreateMessageBankTextContent("menu", "popup_deco_all_remove_title", "popup_deco_all_remove_desc", SizeType.Small, new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive },
			});
			PopupWindowManager.Show(s, (PopupWindowControl ctl, PopupButton.ButtonType typ, PopupButton.ButtonLabel label) =>
			{
				//0xC6F148
				if(typ == PopupButton.ButtonType.Positive)
					isOk = true;
				isClosed = true;
			}, null, null, null);
			yield return new WaitUntil(() =>
			{
				//0xC6F160
				return isClosed;
			});
			if(isOk)
			{
				yield return this.StartCoroutineWatched(Co_RemoveAll());
				m_decorationCanvas.HideSelectItemLayout();
				UpdateEditButton();
				UpdateItemPostLayout();
				UpdateCharaPostLayout();
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D28AC Offset: 0x6D28AC VA: 0x6D28AC
		//// RVA: 0xC6A48C Offset: 0xC6A48C VA: 0xC6A48C
		private IEnumerator Co_RemoveAll() 
		{
			List<DecorationItemBase> items;

			//0x1581D7C
			items = m_decorationCanvas.GetItemList();
			m_spItemListupList.Clear();
			for(int i = 0; i < items.Count; i++)
			{
				if(items[i].DecorationItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp)
				{
					NDBFKHKMMCE_DecoItem.NIBEBIGPKLA_ObjItem dbIt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK_Sp[items[i].Id - 1];
					if(dbIt.GBJFNGCDKPM_SpType < 4)
					{
						m_spItemListupList.Add(items[i].ResourceId);
					}
				}
			}
			bool isDecide = true;
			if(m_spItemListupList.Count > 0)
			{
				m_spItemListupList.Sort();
				m_spItemRemovePopup.TitleText = MessageManager.Instance.GetMessage("menu", "pop_deco_sp_item_remove_title");
				m_spItemRemovePopup.m_parent = transform;
				m_spItemRemovePopup.isReplaceRoom = false;
				m_spItemRemovePopup.Buttons = new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				m_spItemRemovePopup.itemList.Clear();
				for(int i = 0; i < m_spItemListupList.Count; i++)
				{
					m_spItemRemovePopup.itemList.Add(m_spItemListupList[i]);
				}
				m_spItemRemovePopup.WindowSize = SizeType.Middle;
				bool isWait = true;
				PopupWindowManager.Show(m_spItemRemovePopup, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0xC6F178
					if(type != PopupButton.ButtonType.Positive)
						isDecide = false;
					isWait = false;
				}, null, null, null);
				while(isWait)
					yield return null;
			}
			foreach(var it in items)
			{
				if(!DecorationConstants.IsItemSpVisit(it))
				{
					if(!isDecide)
					{
						if(it.DecorationItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp)
						{
							bool b = false;
							foreach(var it2 in m_spItemListupList)
							{
								b |= it.ResourceId == it2;
							}
							if(b)
							{
								continue;
							}
						}
						m_decorationCanvas.RemoveItem(it);
					}
					else
						m_decorationCanvas.RemoveItem(it);
				}
			}
		}

		//// RVA: 0xC6A514 Offset: 0xC6A514 VA: 0xC6A514
		private void Optioin()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(Co_Option());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D2924 Offset: 0x6D2924 VA: 0x6D2924
		//// RVA: 0xC6A588 Offset: 0xC6A588 VA: 0xC6A588
		private IEnumerator Co_Option()
		{
			//0x157B900
			SetEnableControllerTapGuard(true);
			bool isDecide = false;
			bool isBgDiff = false;
			bool isPosterAnimeDiff = false;
			bool isDone = false;
			m_decorationCanvas.DecoLocalSaveData.PCODDPDFLHK_Load();
			m_decoOptionSetting.SetParent(transform);
			m_decoOptionSetting.DecorationLocalSaveData = m_decorationCanvas.DecoLocalSaveData;
			PopupWindowManager.Show(m_decoOptionSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xC6F1BC
				if(type == PopupButton.ButtonType.Positive)
				{
					bool b1 = m_decorationCanvas.DecoLocalSaveData.KOGBMDOONFA.CINLIMIKCAL_EnableBgEffect;
					bool b2 = m_decorationCanvas.DecoLocalSaveData.KOGBMDOONFA.HEKJKLJDHNN_EnablePosterAnim;
					(control.Content as PopupDecoOptionPopup).LayoutPopupConfigDeco.SetDecoOption(m_decorationCanvas.DecoLocalSaveData);
					m_decorationCanvas.DecoLocalSaveData.HJMKBCFJOOH_Save();
					isBgDiff = m_decorationCanvas.DecoLocalSaveData.KOGBMDOONFA.CINLIMIKCAL_EnableBgEffect != b1;
					isPosterAnimeDiff = m_decorationCanvas.DecoLocalSaveData.KOGBMDOONFA.HEKJKLJDHNN_EnablePosterAnim != b2;
					isDecide = true;
				}
				isDone = true;
			}, null, null, null);
			while(!isDone)
				yield return null;
			if(isDecide)
			{
				MenuScene.Instance.InputDisable();
				if(isBgDiff)
				{
					if(!m_decorationCanvas.DecoLocalSaveData.KOGBMDOONFA.CINLIMIKCAL_EnableBgEffect)
					{
						m_decorationCanvas.SetActiveBgEffect(false);
					}
					else
					{
						yield return Co.R(m_decorationCanvas.Co_LoadBgEffect());
					}
				}
				if(isPosterAnimeDiff)
				{
					yield return Co.R(Co_ReloadRareBrakeItems());
				}
				MenuScene.Instance.InputEnable();
			}
			SetEnableControllerTapGuard(false);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D299C Offset: 0x6D299C VA: 0x6D299C
		//// RVA: 0xC6A610 Offset: 0xC6A610 VA: 0xC6A610
		private IEnumerator Co_ReloadRareBrakeItems()
		{
			DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN saveData;

			//0x1581364
			List<DecorationItemBase> l = new List<DecorationItemBase>();
            List<DecorationItemBase> l2 = m_decorationCanvas.GetItemList();
			foreach(var it in l2)
			{
				if(it.ViewData.OHAMGNMKOII())
					l.Add(it);
			}
			List<int> l3 = new List<int>(l.Count);
			saveData = m_decoPublicSetData.LJMCPFACDGJ;
			foreach(var it in l)
			{
				int id = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(it.ViewData.NPADACLCNAN_Category, it.ViewData.PPFNGGCBJKC_Id);
				for(int i = 0; i < saveData.HBHMAKNGKFK_Items.Count; i++)
				{
					if(saveData.HBHMAKNGKFK_Items[i].HAJKNHNAIKL_ItemId == id)
					{
						if(!l3.Contains(i))
						{
							l3.Add(i);
							break;
						}
					}
				}
				m_decorationCanvas.RemoveItem(it);
			}
			foreach(var i in l3)
			{
				m_decorationCanvas.LoadItem(saveData.HBHMAKNGKFK_Items[i]);
				yield return new WaitUntil(() =>
				{
					//0xC6DD60
					return m_decorationCanvas.IsLoadedItem;
				});
			}
			m_decorationCanvas.LoadedItem();
        }

		//// RVA: 0xC5CBF8 Offset: 0xC5CBF8 VA: 0xC5CBF8
		private void EnableSerifAttacherCover(bool isEnable)
		{
			m_serifAttacherCover.gameObject.SetActive(isEnable);
		}

		//// RVA: 0xC6A698 Offset: 0xC6A698 VA: 0xC6A698
		public void MenuEnable(bool enable)
		{
			if(m_state != StateType.MenuDisable && !isExecute)
			{
				LayoutControl(enable ? StateType.Top : StateType.MenuDisable, StateType.None, DecorationConstants.Attribute.Type.None);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D2A14 Offset: 0x6D2A14 VA: 0x6D2A14
		//// RVA: 0xC6A6DC Offset: 0xC6A6DC VA: 0xC6A6DC
		protected IEnumerator TryShowTutorial_Chara()
		{
			GameManager.PushBackButtonHandler backButtonDummy;

			//0x158682C
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsDecoltureChara))
				yield break;
			MenuScene.Instance.InputDisable();
			SetEnableControllerTapGuard(true);
			backButtonDummy = () =>
			{
				//0xC6E768
				return;
			};
			yield return Co.R(TutorialManager.ShowTutorial(129, null));
			bool done = false;
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.BCLKCMDGDLD(GPFlagConstant.ID.IsDecoltureChara, true);
			MenuScene.Save(() =>
			{
				//0xC6F514
				done = true;
			}, null);
			while(!done)
				yield return null;
			GameManager.Instance.RemovePushBackButtonHandler(backButtonDummy);
			MenuScene.Instance.InputEnable();
			SetEnableControllerTapGuard(false);
			backButtonDummy = null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D2A8C Offset: 0x6D2A8C VA: 0x6D2A8C
		//// RVA: 0xC6A764 Offset: 0xC6A764 VA: 0xC6A764
		protected IEnumerator TryShowTutorial_Extra()
		{
			//0x1586E20
			yield return Co.R(TutorialManager.TryShowTutorialCoroutine((TutorialConditionId conditionId) =>
			{
				//0xC6E76C
				return conditionId == TutorialConditionId.Condition80;
			}));
		}

		//// RVA: 0xC5C618 Offset: 0xC5C618 VA: 0xC5C618
		private void StopAllVoice()
		{
			m_voicePlayer.Stop();
			List<DecorationChara> l = m_decorationCanvas.ItemManager.GetCharaList();
			foreach(var c in l)
			{
				c.StopVoice();
			}
			m_cancelPlushToyReaction = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D2B04 Offset: 0x6D2B04 VA: 0x6D2B04
		//// RVA: 0xC6A7D4 Offset: 0xC6A7D4 VA: 0xC6A7D4
		private IEnumerator Co_ReceiveEnergy(DecorationItemBase item, long currentTime)
		{
			DecorationSp spItemObject;
			BCGFHLIEKLJ_DecoItem.GNGFGEIAGJL spItem;
			NDBFKHKMMCE_DecoItem.FIDBAFHNGCF spItemMaster;
			int currentLevel;
			bool isMax;

			//0x157CB74
			spItemObject = item as DecorationSp;
			if(spItemObject == null)
				yield break;
			int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(item.ResourceId);
			spItem = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.OMMNKDEODJP_DecoItem.NBKAMFFIOOG_Sp[id - 1];
			spItemMaster = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK_Sp[id - 1];
			currentLevel = spItem.ANAJIAENLNB_Level;
			NEGELNMPEPH_DecoSpSetting.DAGLEHBMBLF data = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.BGKKOOGPEFD_DecoSpSetting.ILCGCPIGAFP[currentLevel - 1][spItemMaster.GBJFNGCDKPM_SpType - 1];
			isMax = false;
			int currentStock, currentGauge;
			PBOHJPIBILI.GLEPHGKFFLL(out currentStock, out currentGauge, out isMax);
			int addGauge = KDKFHGHGFEK.IOKFJAIDMLD_GetNumItemsReady(item.ResourceId, spItem.ANAJIAENLNB_Level, currentTime);
			int overflow = PBOHJPIBILI.PFNBNKCPFLP_GetCannonStockMax() * -100 + addGauge + PBOHJPIBILI.JMJOBHFFBGC_GetMcGauge() - 100;
			if(overflow < 1)
				overflow = 0;
			PBOHJPIBILI.PGAGKCDGOIN_AddMcGauge(addGauge - overflow);
			ILCCJNDFFOB.HHCJCDFCLOB.MINOEGPNBIH(addGauge - overflow, PBOHJPIBILI.JMJOBHFFBGC_GetMcGauge(), 0, 0, JpStringLiterals.StringLiteral_15497, "");
			m_decoEnergyChargeSeeting.TitleText = MessageManager.Instance.GetMessage("menu", "pop_deco_sp_item_cannon_title");
			m_decoEnergyChargeSeeting.WindowSize = SizeType.Middle;
			m_decoEnergyChargeSeeting.m_parent = transform;
			m_decoEnergyChargeSeeting.currentGauge = currentGauge;
			m_decoEnergyChargeSeeting.currentStock = currentStock;
			m_decoEnergyChargeSeeting.isCurrentMax = isMax;
			m_decoEnergyChargeSeeting.nextGauge = PBOHJPIBILI.JMJOBHFFBGC_GetMcGauge();
			m_decoEnergyChargeSeeting.isDeco = true;
			m_decoEnergyChargeSeeting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			if(KDKFHGHGFEK.HMAOJBKJIOJ(item.ResourceId, spItem.ANAJIAENLNB_Level, m_decorationCanvas.GetHaveDecorationItemCount()))
			{
				spItem.EMHCHMHMFHJ_ChargeTimeOffset = KDKFHGHGFEK.CFNHNIMKPCI_GetChargeTimeOffset(spItem, currentTime);
				spItem.EMHCHMHMFHJ_ChargeTimeOffset += KDKFHGHGFEK.GGEGLPOMJCK_TimeByUnit(spItem.PPFNGGCBJKC_Id, spItem.ANAJIAENLNB_Level + 1) * overflow;
				spItem.ANAJIAENLNB_Level++;
				m_levelUpTargetList.Add(item);
			}
			else if(addGauge - overflow > 0)
			{
				spItem.EMHCHMHMFHJ_ChargeTimeOffset = KDKFHGHGFEK.CFNHNIMKPCI_GetChargeTimeOffset(spItem, currentTime);
				spItem.EMHCHMHMFHJ_ChargeTimeOffset += KDKFHGHGFEK.GGEGLPOMJCK_TimeByUnit(spItem.PPFNGGCBJKC_Id, spItem.ANAJIAENLNB_Level) * overflow;
				spItem.FOONCJDLLIK_ChargeTime = currentTime;
			}
			if(!isMax)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_LOGIN_000);
			}
			spItemObject.ShowReceiveAnime(data.NANNGLGOFKH_MaxNumber);
			while(spItemObject.IsPlayingReceiveAnime())
				yield return null;
			bool isWait = true;
			MenuScene.Save(() =>
			{
				//0xC6F528
				isWait = false;
			}, null);
			while(isWait)
				yield return null;
			isWait = true;
			if(!isMax)
			{
				SendPushMessage(spItemMaster, currentLevel, spItem.FOONCJDLLIK_ChargeTime, spItem.EMHCHMHMFHJ_ChargeTimeOffset);
			}
			PopupWindowManager.Show(m_decoEnergyChargeSeeting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xC6F534
				isWait = false;
			}, null, null, null);
			while(isWait)
				yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D2B7C Offset: 0x6D2B7C VA: 0x6D2B7C
		//// RVA: 0xC6A898 Offset: 0xC6A898 VA: 0xC6A898
		private IEnumerator Co_ReceiveSpItem(DecorationItemBase _item, long currentTime)
		{
			BBHNACPENDM_ServerSaveData pd;
			bool isPlayingReceiveAnime;
			bool isSave;
			List<int> getItemIds;
			List<int> getItemCounts;
			bool allGetItem;
			DecorationItemBase cannonItem;
			int i;
			DecorationItemBase item;
			DecorationSp spDecoItem;
			int id;
			NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC spType;

			//0x157DC50
			MenuScene.Instance.InputDisable();
			m_decorationCanvas.EnableItemController(DecorationItemManager.EnableControlType.None);
			m_decorationCanvas.EnableCanvasController(false);
            List<NDBFKHKMMCE_DecoItem.FIDBAFHNGCF> itemDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK_Sp;
            pd = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave;
            List<DecorationItemBase> l = m_decorationCanvas.GetItemList();
            isPlayingReceiveAnime = false;
			isSave = false;
			m_allGetTargetList.Clear();
			m_removeTargetList.Clear();
			m_levelUpTargetList.Clear();
			getItemIds = new List<int>();
			allGetItem = false;
			getItemCounts = new List<int>();
			if(_item == null)
			{
				allGetItem = true;
				for(i = 0; i < l.Count; i++)
				{
					if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(l[i].ResourceId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp)
					{
						int itemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(l[i].ResourceId);
						int c = itemDb[itemId - 1].GBJFNGCDKPM_SpType;
						if(c > 0 && c < 4)
						{
							if(KDKFHGHGFEK.HMDOAKPBLFL_HasItemsReady(l[i].ResourceId, KDKFHGHGFEK.DFMGMEDILKB(l[i].ResourceId), currentTime))
							{
								m_allGetTargetList.Add(l[i]);
							}
						}
						else if(c == 11)
						{
							m_allGetTargetList.Add(l[i]);
						}
					}
				}
			}
			else
			{
				m_allGetTargetList.Add(_item);
				isPlayingReceiveAnime = true;
			}
			if(m_allGetTargetList.Count != 0)
			{
				cannonItem = null;
				m_decoSpItemListSetting.TitleText = MessageManager.Instance.GetMessage("menu", "pop_deco_sp_item_itemlist_title");
				m_decoSpItemListSetting.WindowSize = SizeType.Middle;
				m_decoSpItemListSetting.m_parent = transform;
				m_decoSpItemListSetting.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				};
				m_decoSpItemListSetting.Clear();
				CIOECGOMILE.HHCJCDFCLOB.JANMJPOKLFL.JCHLONCMPAJ();
				for(i = 0; i < m_allGetTargetList.Count; i++)
				{
					item = m_allGetTargetList[i];
					spDecoItem = item as DecorationSp;
					id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(item.ResourceId);
					spType = spDecoItem.SpType;
					int g = 0;
					if(spType < NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.JJNIMNEJPOF_3)
					{
						if(spType == NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.FIHMIDDLAKH_CanonFillSp)
						{
							int a = 0;
							int b;
							bool c = false;
							PBOHJPIBILI.GLEPHGKFFLL(out a, out b, out c);
							cannonItem = item;
							if(!c)
								isSave = true;
						}
						else if(spType == NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.IOEGFJMNDBM_2)
						{
							BCGFHLIEKLJ_DecoItem.GNGFGEIAGJL saveIt = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.OMMNKDEODJP_DecoItem.NBKAMFFIOOG_Sp[id - 1];
							NDBFKHKMMCE_DecoItem.FIDBAFHNGCF dbItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK_Sp[id - 1];
							List<NEGELNMPEPH_DecoSpSetting.DAGLEHBMBLF> l2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.BGKKOOGPEFD_DecoSpSetting.ILCGCPIGAFP[saveIt.ANAJIAENLNB_Level - 1];
							NEGELNMPEPH_DecoSpSetting.DAGLEHBMBLF data = l2[dbItem.GBJFNGCDKPM_SpType - 1];
							int a = dbItem.KIJAPOFAGPN_ItemId;
							if(EKLNMHFCAOI.DEACAHNLMNI_getItemId(a) == 0)
							{
								a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ICICKEBMEFA_Medal.DNEKJCKEOHL_GetMonthlyItemFullId(currentTime);
							}
							g = KDKFHGHGFEK.IOKFJAIDMLD_GetNumItemsReady(item.ResourceId, saveIt.ANAJIAENLNB_Level, currentTime);
							saveIt.EMHCHMHMFHJ_ChargeTimeOffset = KDKFHGHGFEK.CFNHNIMKPCI_GetChargeTimeOffset(saveIt, currentTime);
							int prevLevel = saveIt.ANAJIAENLNB_Level;
							if(KDKFHGHGFEK.HMAOJBKJIOJ(item.ResourceId, saveIt.ANAJIAENLNB_Level, m_decorationCanvas.GetHaveDecorationItemCount()))
							{
								saveIt.ANAJIAENLNB_Level++;
								m_levelUpTargetList.Add(item);
							}
							saveIt.FOONCJDLLIK_ChargeTime = currentTime;
							m_decoSpItemListSetting.Add(new PopupDecoSpItemListSetting.ItemParam() { id = a, count = g });
							CIOECGOMILE.HHCJCDFCLOB.JANMJPOKLFL.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.IOEGFJMNDBM_35, prevLevel.ToString() + ":" + saveIt.ANAJIAENLNB_Level.ToString());
							CIOECGOMILE.HHCJCDFCLOB.JANMJPOKLFL.CPIICACGNBH(pd, a, g, null, 0);
							getItemIds.Add(a);
							getItemCounts.Add(g);
							SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_LOGIN_000);
							isSave = true;
						}
					}
					else if(spType == NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.JJNIMNEJPOF_3)
					{
						bool isWait = true;
						bool isError = false;
						int giftCount = 0;
						m_netDecoVisitControl.AEAJKEGDDIG_GetPresentCounter((int count) =>
						{
							//0xC6F55C
							isWait = false;
							giftCount = count;
						}, () =>
						{
							//0xC6F56C
							isWait = false;
							isError = true;
						});
						while(isWait)
							yield return null;
						if(isError)
						{
							MenuScene.Instance.GotoTitle();
							yield break;
						}
						m_netDecoVisitControl.OGPBAJHGFLK_AddPresent(giftCount);
						if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.BGKKOOGPEFD_DecoSpSetting.JDLCJAILIME.Count <= giftCount)
						{
							giftCount = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.BGKKOOGPEFD_DecoSpSetting.JDLCJAILIME.Count - 1;
						}
						BCGFHLIEKLJ_DecoItem.GNGFGEIAGJL saveIt = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.OMMNKDEODJP_DecoItem.NBKAMFFIOOG_Sp[id - 1];
						NDBFKHKMMCE_DecoItem.FIDBAFHNGCF dbIt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK_Sp[id - 1];
						List<NEGELNMPEPH_DecoSpSetting.DAGLEHBMBLF> l2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.BGKKOOGPEFD_DecoSpSetting.ILCGCPIGAFP[saveIt.ANAJIAENLNB_Level - 1];
						NEGELNMPEPH_DecoSpSetting.DAGLEHBMBLF data = l2[dbIt.GBJFNGCDKPM_SpType - 1];
                        List<NEGELNMPEPH_DecoSpSetting.NDONMEAEGFF> l3 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.BGKKOOGPEFD_DecoSpSetting.JDLCJAILIME[giftCount];
                        g = KDKFHGHGFEK.IOKFJAIDMLD_GetNumItemsReady(item.ResourceId, saveIt.ANAJIAENLNB_Level, currentTime);
						saveIt.EMHCHMHMFHJ_ChargeTimeOffset = KDKFHGHGFEK.CFNHNIMKPCI_GetChargeTimeOffset(saveIt, currentTime);
						int prevLevel = saveIt.ANAJIAENLNB_Level;
						if(KDKFHGHGFEK.HMAOJBKJIOJ(item.ResourceId, saveIt.ANAJIAENLNB_Level, m_decorationCanvas.GetHaveDecorationItemCount()))
						{
							saveIt.ANAJIAENLNB_Level++;
							m_levelUpTargetList.Add(item);
						}
						saveIt.FOONCJDLLIK_ChargeTime = currentTime;
						CIOECGOMILE.HHCJCDFCLOB.JANMJPOKLFL.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.JJNIMNEJPOF_36, prevLevel.ToString() + ":" + saveIt.ANAJIAENLNB_Level.ToString());
						CIOECGOMILE.HHCJCDFCLOB.JANMJPOKLFL.CPIICACGNBH(pd, dbIt.KIJAPOFAGPN_ItemId, g, null, 0);
						getItemIds.Add(dbIt.KIJAPOFAGPN_ItemId);
						getItemCounts.Add(g);
						m_decoSpItemListSetting.Add(new PopupDecoSpItemListSetting.ItemParam() { id = dbIt.KIJAPOFAGPN_ItemId, count = g });
						for(int j = 0; j < l3.Count; j++)
						{
							if(l3[j].JPMAHJJMMIA != 0)
							{
								if(l3[j].HMFFHLPNMPH != 0)
								{
									m_decoSpItemListSetting.Add(new PopupDecoSpItemListSetting.ItemParam() { id = l3[j].JPMAHJJMMIA, count = l3[j].HMFFHLPNMPH });
									CIOECGOMILE.HHCJCDFCLOB.JANMJPOKLFL.CPIICACGNBH(pd, l3[j].JPMAHJJMMIA, l3[j].HMFFHLPNMPH, null, 0);
									getItemIds.Add(l3[j].JPMAHJJMMIA);
									getItemCounts.Add(l3[j].HMFFHLPNMPH);
								}
							}
						}
						SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_LOGIN_000);
						isSave = true;
					}
					else if(spType == NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.JPPOGMHJKKJ_VisitItemSp)
					{
						bool isDone = false;
						bool isError = false;
						int visitItemId = 0;
						int visitItemCount = 0;
						m_netDecoVisitControl.HADBMIIBABM_UpdateCounters((int itemId, int itemCount) =>
						{
							//0xC6F580
							visitItemId = itemId;
							visitItemCount = itemCount;
							isDone = true;
						}, () =>
						{
							//0xC6F594
							isDone = true;
							isError = true;
						});
						while(!isDone)
							yield return null;
						if(isError)
						{
							MenuScene.Instance.GotoTitle();
							yield break;
						}
						g = visitItemCount;
						CIOECGOMILE.HHCJCDFCLOB.JANMJPOKLFL.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.JPPOGMHJKKJ_37, "");
						CIOECGOMILE.HHCJCDFCLOB.JANMJPOKLFL.CPIICACGNBH(pd, visitItemId, visitItemCount, null, 0);
						getItemIds.Add(visitItemId);
						getItemCounts.Add(visitItemCount);
						m_decoSpItemListSetting.Add(new PopupDecoSpItemListSetting.ItemParam() { id = visitItemId, count = visitItemCount });
						m_removeTargetList.Add(item);
						RemovePublicSetDataVisitItem();
						SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_LOGIN_000);
					}
					if(spType != NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.FIHMIDDLAKH_CanonFillSp)
					{
						if(!isPlayingReceiveAnime)
						{
							spDecoItem.SetIconHide();
						}
						else
						{
							spDecoItem.ShowReceiveAnime(g);
							while(spDecoItem.IsPlayingReceiveAnime())
								yield return null;
						}
					}
					item = null;
					spDecoItem = null;
				}
				if(isSave)
				{
					bool isWait = true;
					MenuScene.Save(() =>
					{
						//0xC6F5A8
						isWait = false;
					}, null);
					while(isWait)
						yield return null;
					for(int j = 0; j < m_allGetTargetList.Count; j++)
					{
						if(m_allGetTargetList[j].DecorationItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp)
						{
							if((m_allGetTargetList[j].Id & 0xfffffffe) == 2)
							{
								BCGFHLIEKLJ_DecoItem.GNGFGEIAGJL saveIt = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.OMMNKDEODJP_DecoItem.NBKAMFFIOOG_Sp[m_allGetTargetList[j].Id - 1];
								NDBFKHKMMCE_DecoItem.FIDBAFHNGCF dbIt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK_Sp[m_allGetTargetList[j].Id - 1];
								SendPushMessage(dbIt, saveIt.ANAJIAENLNB_Level, saveIt.FOONCJDLLIK_ChargeTime, saveIt.EMHCHMHMFHJ_ChargeTimeOffset);
							}
						}
					}
				}
				//LAB_01580b78
				if(m_decoSpItemListSetting.Count() > 0)
				{
					if(allGetItem)
					{
						ILCCJNDFFOB.HHCJCDFCLOB.CEFIPAIKAKN(getItemIds, getItemCounts);
					}
					bool isWait = true;
					PopupWindowManager.Show(m_decoSpItemListSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
					{
						//0xC6F5BC
						isWait = false;
					}, null, null, null);
					//LAB_01580cf0
					while(isWait)
						yield return null;
				}
				//LAB_01580d28
				if(cannonItem != null)
				{
					yield return Co.R(Co_ReceiveEnergy(cannonItem, currentTime));
				}
				//LAB_01580db8
				cannonItem = null;
				//LAB_01580dc0
			}
			else
			{
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				TextPopupSetting s = new TextPopupSetting();
				s.TitleText = bk.GetMessageByLabel("pop_deco_sp_all_receive_title");
				s.Text = bk.GetMessageByLabel("pop_deco_sp_all_receive_content");
				s.WindowSize = SizeType.Small;
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				bool isWait = true;
				PopupWindowManager.Show(s, (PopupWindowControl controller, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0xC6F548
					isWait = false;
				}, null, null, null);
				while(isWait)
					yield return null;
			}
			//LAB_01580dc0
			for(i = 0; i < m_removeTargetList.Count; i++)
			{
				m_decorationCanvas.RemoveItem(m_removeTargetList[i]);
			}
			for(i = 0; i < m_levelUpTargetList.Count; i++)
			{
				//LAB_01580e84
				id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(m_levelUpTargetList[i].ResourceId);
				BCGFHLIEKLJ_DecoItem.GNGFGEIAGJL it = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.OMMNKDEODJP_DecoItem.NBKAMFFIOOG_Sp[id - 1];
				yield return this.StartCoroutineWatched(Co_SpItemLevelUp((m_levelUpTargetList[i] as DecorationSp), it.ANAJIAENLNB_Level - 1));
			}
			MenuScene.Instance.InputEnable();
			m_decorationCanvas.EnableItemController(DecorationItemManager.EnableControlType.Unique);
			m_decorationCanvas.EnableCanvasController(true);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D2BF4 Offset: 0x6D2BF4 VA: 0x6D2BF4
		//// RVA: 0xC6A95C Offset: 0xC6A95C VA: 0xC6A95C
		private IEnumerator Co_SpItemLevelUp(DecorationSp spItemObject, int prevLevel)
		{
			int itemId;
			int id;
			BCGFHLIEKLJ_DecoItem.GNGFGEIAGJL spItemPd;
			NDBFKHKMMCE_DecoItem.FIDBAFHNGCF spItemMaster;

			//0x1584924
			itemId = spItemObject.ResourceId;
			id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(itemId);
			spItemPd = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.OMMNKDEODJP_DecoItem.NBKAMFFIOOG_Sp[id - 1];
			spItemMaster = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK_Sp[id - 1];
			spItemObject.HideLevelUpIcon();
			MenuScene.Instance.InputDisable();
			m_decorationCanvas.EnableItemController(DecorationItemManager.EnableControlType.None);
			m_decorationCanvas.EnableCanvasController(false);
			bool isWait = true;
			MenuScene.Save(() =>
			{
				//0xC6F5D0
				isWait = false;
			}, null);
			while(isWait)
				yield return null;
			ILCCJNDFFOB.HHCJCDFCLOB.NOMCHDMPFFE(id, prevLevel, prevLevel + 1);
			m_decoSpItemLevelupSetting.TitleText = EKLNMHFCAOI.INCKKODFJAP_GetItemName(itemId);
			m_decoSpItemLevelupSetting.WindowSize = SizeType.Middle;
			m_decoSpItemLevelupSetting.currentLevel = prevLevel;
			m_decoSpItemLevelupSetting.itemId = itemId;
			m_decoSpItemLevelupSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			m_decoSpItemLevelupSetting.SetParent(transform);
			isWait = true;
			PopupWindowManager.Show(m_decoSpItemLevelupSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xC6F5DC
				isWait = false;
			}, null, null, null);
			while(isWait)
				yield return null;
			MenuScene.Instance.InputEnable();
			m_decorationCanvas.EnableItemController(DecorationItemManager.EnableControlType.Unique);
			m_decorationCanvas.EnableCanvasController(true);
			SendPushMessage(spItemMaster, spItemPd.ANAJIAENLNB_Level, spItemPd.FOONCJDLLIK_ChargeTime, spItemPd.EMHCHMHMFHJ_ChargeTimeOffset);
		}

		//// RVA: 0xC61CAC Offset: 0xC61CAC VA: 0xC61CAC
		private void HideIcon()
		{
            List<DecorationItemBase> l = m_decorationCanvas.GetItemList();
			for(int i = 0; i < l.Count; i++)
			{
				if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(l[i].ResourceId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp)
				{
					DecorationSp item = l[i] as DecorationSp;
					item.HideLevelUpIcon();
					item.SetIconHide();
					item.HidePopupIcon();
				}
			}
        }

		//// RVA: 0xC5BF9C Offset: 0xC5BF9C VA: 0xC5BF9C
		private void InitializeScreenShot()
		{
			m_screenShotViewInstance.PushTakeButtonListner += PushTakeButton;
			m_screenShotViewInstance.PushCloseButtonListener += ResetCaptureMode;
			m_screenShotViewInstance.PushMessagePanelButtonListner += CloseResultMessage;
			m_screenShotViewInstance.PushReturnButtonListner += ExitCaptureMode;
			m_screenShotViewInstance.PushShareButtonListner += () =>
			{
				//0xC6DD8C
				if(!string.IsNullOrEmpty(m_shareFilePath))
				{
					ILCCJNDFFOB.HHCJCDFCLOB.HNOKBPNGOEF();
					string tpl = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.EFEGBHACJAL("deco_share_message_template", "{0}");
					ScreenShot.Share(m_shareFilePath, string.Format(tpl, NKGJPJPHLIF.HHCJCDFCLOB.CAFHLEFMMGD_GetPlayerId()));
				}
			};
			m_captureLogoInstance = Instantiate(m_captureLogoPrefab);
			m_captureLogoInstance.SetActive(false);
			m_captureLogoBaseScale = m_captureLogoInstance.transform.localScale;
			m_captureLogoInstance.transform.SetParent(transform, false);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D2C6C Offset: 0x6D2C6C VA: 0x6D2C6C
		//// RVA: 0xC6AA18 Offset: 0xC6AA18 VA: 0xC6AA18
		private IEnumerator Co_DoScreenShot()
		{
			//0x15735D4
			m_captureCamera = m_decorationCanvas.GetComponentInChildren<Camera>(true);
			if(m_captureCamera == null)
				yield break;
			isExecute = true;
			m_layoutDecorationLeftButtons.Leave();
			m_layoutDecorationRightButtons01.Leave();
			m_layoutDecorationMenuDisableButton.Leave();
			MenuScene.Instance.HelpButton.TryLeave();
			MenuScene.Instance.LobbyButtonControl.Hide(false);
			m_decorationCanvas.SetEnableIntimacyCounter(false);
			m_decorationCanvas.EnableItemController(DecorationItemManager.EnableControlType.ScreenShot);
			m_screenShotViewInstance.Show();
			GameManager.Instance.AddPushBackButtonHandler(OnScreenShotAndroidBackButton);
			while(isExecute)
				yield return null;
			m_layoutDecorationLeftButtons.Enter();
			m_layoutDecorationRightButtons01.Enter();
			m_layoutDecorationMenuDisableButton.Enter();
			MenuScene.Instance.HelpButton.TryEnter();
			MenuScene.Instance.LobbyButtonControl.Show(false);
			m_decorationCanvas.SetEnableIntimacyCounter(true);
			m_decorationCanvas.EnableItemController(DecorationItemManager.EnableControlType.Unique);
			GameManager.Instance.RemovePushBackButtonHandler(OnScreenShotAndroidBackButton);
			m_screenShotViewInstance.Close();
		}

		//// RVA: 0xC6AAA0 Offset: 0xC6AAA0 VA: 0xC6AAA0
		private void OnScreenShotAndroidBackButton()
		{
			m_screenShotViewInstance.PreformReturnButton();
		}

		//// RVA: 0xC6AACC Offset: 0xC6AACC VA: 0xC6AACC
		private void UpdateLogoPosition(Vector2 logoPosition)
		{
			Canvas canvas = m_decorationCanvas.GetComponentInChildren<Canvas>(true);
			m_captureLogoInstance.transform.SetParent(canvas.transform, false);
			float s = canvas.GetComponent<CanvasScaler>().scaleFactor;
			float f = m_captureLogoBaseScale.x / s;
			m_captureLogoInstance.transform.localScale = new Vector3(f, f, 1);
			m_captureLogoInstance.GetComponent<RectTransform>().anchoredPosition = new Vector2(logoPosition.x / s, -logoPosition.y / s);
		}

		//// RVA: 0xC6AD70 Offset: 0xC6AD70 VA: 0xC6AD70
		private string MakeSaveFileName()
		{
			return string.Format(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.EFEGBHACJAL("deco_share_filename_format", "Deco{0}"), DateTime.Now.ToString(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.EFEGBHACJAL("deco_share_filename_timeformat", "yyyyMMdd_HHmmss")));
		}

		//// RVA: 0xC6AF74 Offset: 0xC6AF74 VA: 0xC6AF74
		private void PushTakeButton()
		{
			isDoTake = true;
			m_captureLogoInstance.SetActive(true);
			DoCapture();
			m_screenShotViewInstance.ShowResult(m_captureTexture);
			this.StartCoroutine(ScreenShot.SaveScreenShot(MakeSaveFileName(), m_captureTexture.EncodeToPNG(), ScreenShotCallBack, PermissionCallBack));
			m_captureLogoInstance.SetActive(false);
		}

		//// RVA: 0xC6B47C Offset: 0xC6B47C VA: 0xC6B47C
		private void CloseResultMessage()
		{
			m_screenShotViewInstance.CloseSuccessMessage();
		}

		//// RVA: 0xC6B4A8 Offset: 0xC6B4A8 VA: 0xC6B4A8
		private void ResetCaptureMode()
		{
			m_screenShotViewInstance.CloseResult();
			m_screenShotViewInstance.CloseCloseButton();
			m_screenShotViewInstance.ShowReturnButton();
			m_shareFilePath = "";
		}

		//// RVA: 0xC6B570 Offset: 0xC6B570 VA: 0xC6B570
		private void ExitCaptureMode()
		{
			isExecute = false;
		}

		//// RVA: 0xC6B57C Offset: 0xC6B57C VA: 0xC6B57C
		private void ScreenShotCallBack(ScreenShot.ReturnCode returnCode, string shareFilePath)
		{
			string str = "deco_popup_err_not_abailable_storage";
			if(returnCode != ScreenShot.ReturnCode.NotAbailableStorage)
			{
				if(returnCode != ScreenShot.ReturnCode.NotPermission)
				{
					str = "";
					if(returnCode == ScreenShot.ReturnCode.Ok)
					{
						m_shareFilePath = shareFilePath;
						m_screenShotViewInstance.ShowSuccessMessage();
					}
				}
				else
					str = "deco_popup_err_no_permission_storage";
			}
			if(!string.IsNullOrEmpty(str))
			{
				TextPopupSetting s = new TextPopupSetting();
				s.IsCaption = false;
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				s.Text = MessageManager.Instance.GetMessage("menu", str);
				PopupWindowManager.Show(s, null, null, null, null);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D2CE4 Offset: 0x6D2CE4 VA: 0x6D2CE4
		//// RVA: 0xC6B818 Offset: 0xC6B818 VA: 0xC6B818
		private IEnumerator PermissionCallBack(Action<ScreenShot.PermissionFuncResultCode> result)
		{
			TodoLogger.LogError(0, "PermissionCallBack");
			yield return null;
		}

		//// RVA: 0xC6B108 Offset: 0xC6B108 VA: 0xC6B108
		private void DoCapture()
		{
			Rect r = CalcCaptureTrimmingRect();
			if(m_captureTexture == null)
			{
				m_captureTexture = new Texture2D((int)r.width, (int)r.height, TextureFormat.RGB24, false);
			}
			if(m_renderTexture == null)
			{
				m_renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
			}
			Vector2 logoPos = r.position;
			if(SystemManager.isLongScreenDevice && SystemManager.HasSafeArea)
				logoPos.y = 0;
			UpdateLogoPosition(logoPos);
			RenderTexture prev = m_captureCamera.targetTexture;
			RenderTexture prevActive = RenderTexture.active;
			m_captureCamera.targetTexture = m_renderTexture;
			m_captureCamera.Render();
			m_captureCamera.targetTexture = prev;
			RenderTexture.active = m_renderTexture;
			m_captureTexture.ReadPixels(r, 0, 0, false);
			m_captureTexture.Apply();
			RenderTexture.active = prevActive;
		}

		//// RVA: 0xC6B8A0 Offset: 0xC6B8A0 VA: 0xC6B8A0
		private Rect CalcCaptureTrimmingRect()
		{
			Rect r = new Rect(0, 0, Screen.width, Screen.height);
			if(!SystemManager.isLongScreenDevice)
			{
                SystemManager.OverPermissionAspectResult a = SystemManager.Instance.CheckOverPermissionAspectRatio();
				if(a == SystemManager.OverPermissionAspectResult.None)
					return r;
				if(a == SystemManager.OverPermissionAspectResult.HdivV)
				{
					float f = Screen.height / SystemManager.BaseScreenSize.y * SystemManager.BaseScreenSize.x;
					return new Rect((Screen.width - f) * 0.5f, 0, f, Screen.height);
				}
				else
				{
					float f = Screen.width / SystemManager.BaseScreenSize.x * SystemManager.BaseScreenSize.y;
					return new Rect(0, (Screen.height - f) * 0.5f, Screen.width, f);
				}
            }
			else
			{
				if(SystemManager.HasSafeArea)
				{
					return SystemManager.rawAppScreenRect;
				}
				else
				{
					float f = Screen.width - Mathf.Min(Screen.height * 1.0f / Screen.width / 0.5625f, 1) * Screen.width;
					return new Rect(f * 0.5f, 0, Screen.width - f, Screen.height);
				}
			}
		}

		//// RVA: 0xC6BD28 Offset: 0xC6BD28 VA: 0xC6BD28
		//private string MakePhotoSavePath() { }
	}
}
