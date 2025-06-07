using System;
using System.Collections;
using System.Collections.Generic;
using mcrs;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class DecoVisitScene : TransitionRoot
	{
		public enum TransitionType
		{
			None = 0,
			Deco = 1,
		}

		private HNKMEOKCNBI m_visitControl = new HNKMEOKCNBI(); // 0x48
		private bool m_isInitialized; // 0x4C
		private bool m_isWaitPreSetCanvas; // 0x4D
		private EAJCBFGKKFA_FriendInfo m_friendPlayerData; // 0x50
		private DecorationCanvas m_decorationCanvas; // 0x54
		private bool m_isReturnLobby; // 0x58
		private bool m_isHideDecorationCanvas; // 0x59
		private LayoutDecorationLeftButtons m_decoLeftButtons; // 0x5C
		private LayoutDecorationMenuDisableButton m_decoMenuDisabletButtons; // 0x60
		private LayoutDecorationVisitRightButtons m_decoRightButtons; // 0x64
		private ButtonBase m_showMenuButton; // 0x68
		private PopupDecoSentGiftSetting m_sentGiftPopupSetting = new PopupDecoSentGiftSetting(); // 0x6C
		private TextPopupSetting m_sentGiftErrorPopupSetting; // 0x70
		private ButtonInfo[] m_popupButtons = new ButtonInfo[1]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
		}; // 0x74
		private List<int> m_addFavList = new List<int>(); // 0x78
		private List<int> m_removeFavList = new List<int>(); // 0x7C
		public static TransitionType transitionType; // 0x0
		private bool m_isTranstion; // 0x80
		private int[] m_bgmIds; // 0x84

		// RVA: 0x11D5F8C Offset: 0x11D5F8C VA: 0x11D5F8C Slot: 4
		protected override void Awake()
		{
			string bgm_ids = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.EFEGBHACJAL("home_bgm_id", "0,0,0");
			string[] bgm_ids_array = bgm_ids.Split(new char[] { ',' });
			if(bgm_ids_array.Length == 3)
			{
				m_bgmIds = new int[3];
				for(int i = 0; i < bgm_ids_array.Length; i++)
				{
					int.TryParse(bgm_ids_array[i], out m_bgmIds[i]);
				}
			}
			else
			{
				m_bgmIds = new int[1];
				m_bgmIds[0] = 27;
			}
			this.StartCoroutineWatched(Co_Initialize());
		}

		// RVA: 0x11D62C0 Offset: 0x11D62C0 VA: 0x11D62C0 Slot: 16
		protected override void OnPreSetCanvas()
		{
			this.StartCoroutineWatched(Co_PreSetCanvas());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6D5864 Offset: 0x6D5864 VA: 0x6D5864
		// // RVA: 0x11D62E4 Offset: 0x11D62E4 VA: 0x11D62E4
		private IEnumerator Co_PreSetCanvas()
		{
			VisitDecoSceneArgs args; // 0x18
			EAJCBFGKKFA_FriendInfo player; // 0x1C

			//0x11DC364
			m_isWaitPreSetCanvas = true;
			m_decoRightButtons.Initialize();
			m_decorationCanvas.SetActive(true);
			if(Args != null && Args is VisitDecoSceneArgs)
			{
				args = Args as VisitDecoSceneArgs;
				player = args.friendData;
				bool isDone = false;
				bool isError = false;
				if(player.PCEGKKLKFNO.LHMDABPNDDH_Type == IBIGBMDANNM.LJJOIIAEICI.CCAPCGPIIPF_Guest || player.PDIPANKOKOL_FriendType == IBIGBMDANNM.LJJOIIAEICI.CCAPCGPIIPF_Guest)
				{
					//LAB_011dca68
					CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.CKJHFFHFPLH_GetFriends(() =>
					{
						//0x11D9108
						isDone = true;
					}, (CACGCMBKHDI_Request action) =>
					{
						//0x11D9114
						isDone = true;
						isError = true;
					}, (CACGCMBKHDI_Request action) =>
					{
						//0x11D9120
						isDone = true;
						isError = true;
					});
					//LAB_011dc414
					while(!isDone)
						yield return null;
					if(isError)
					{
						GotoTitle();
						m_isWaitPreSetCanvas = false;
						m_isInitialized = true;
						yield break;
					}
					if(CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.PDEACDHIJJJ_IsFriend(player.MLPEHNBNOGD_Id))
					{
						player.PCEGKKLKFNO.LHMDABPNDDH_Type = IBIGBMDANNM.LJJOIIAEICI.HEEJBCDDOJJ_Friend;
						player.PDIPANKOKOL_FriendType = IBIGBMDANNM.LJJOIIAEICI.HEEJBCDDOJJ_Friend;
					}
				}
				//LAB_011dc774
				HNKMEOKCNBI.BEABGIOEFLG a = HNKMEOKCNBI.BEABGIOEFLG.HEEJBCDDOJJ_Friend/*0*/;
				if(player.PCEGKKLKFNO is IFICNCAHIGI)
				{
					a = HNKMEOKCNBI.BEABGIOEFLG.HEEJBCDDOJJ_Friend/*0*/;
					if(player.PCEGKKLKFNO.LHMDABPNDDH_Type != IBIGBMDANNM.LJJOIIAEICI.HEEJBCDDOJJ_Friend)
					{
						a = HNKMEOKCNBI.BEABGIOEFLG.KJHABBHBFPD_Other/*2*/;
						if((player.PCEGKKLKFNO as IFICNCAHIGI).BBNAEPGAMMA_IsFavorite)
							a = HNKMEOKCNBI.BEABGIOEFLG.HNANENNPBCO_Fan/*1*/;
					}
				}
				else
				{
					a = HNKMEOKCNBI.BEABGIOEFLG.KJHABBHBFPD_Other/*2*/;
					if(player.PCEGKKLKFNO.LHMDABPNDDH_Type == IBIGBMDANNM.LJJOIIAEICI.HEEJBCDDOJJ_Friend)
						a = HNKMEOKCNBI.BEABGIOEFLG.HEEJBCDDOJJ_Friend/*0*/;
				}
				m_friendPlayerData = args.friendData;
				this.StartCoroutineWatched(Co_InitializeDecoData(args.friendData, a));
				if(m_visitControl.MHGJGAPLMFO(player.MLPEHNBNOGD_Id))
				{
					m_decoRightButtons.DisableButton_Gift();
				}
				if(a == 0)
				{
					m_decoRightButtons.HiddenButton_Friend();
				}
				m_isReturnLobby = transitionType == TransitionType.None;
			}
			else
			{
				args = null;
				bool b = false;
				if(m_friendPlayerData.PCEGKKLKFNO is IFICNCAHIGI)
				{
					if(m_friendPlayerData.PCEGKKLKFNO.LHMDABPNDDH_Type != IBIGBMDANNM.LJJOIIAEICI.HEEJBCDDOJJ_Friend)
					{
						//(m_friendPlayerData.PCEGKKLKFNO as IFICNCAHIGI).BBNAEPGAMMA;
						b = true;
					}
				}
				else
				{
					b = true;
					if(m_friendPlayerData.PCEGKKLKFNO.LHMDABPNDDH_Type == IBIGBMDANNM.LJJOIIAEICI.HEEJBCDDOJJ_Friend)
						b = false;
				}
				if(m_visitControl.MHGJGAPLMFO(m_friendPlayerData.MLPEHNBNOGD_Id))
				{
					m_decoRightButtons.DisableButton_Gift();
				}
				if(!b)
				{
					m_decoRightButtons.HiddenButton_Friend();
				}
				m_decoRightButtons.UpdateFanButton(m_friendPlayerData);
				m_decoRightButtons.UpdateFriendIcon(m_friendPlayerData);
			}
			//LAB_011dc940
			m_decorationCanvas.EnableCanvasController(true);
			m_decorationCanvas.EnableItemController(DecorationItemManager.EnableControlType.None);
			m_decorationCanvas.WaitingChara(false);
			yield return Resources.UnloadUnusedAssets();
			m_isWaitPreSetCanvas = false;
		}

		// RVA: 0x11D6390 Offset: 0x11D6390 VA: 0x11D6390 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return m_isInitialized && !m_isWaitPreSetCanvas;
		}

		// RVA: 0x11D63B4 Offset: 0x11D63B4 VA: 0x11D63B4 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			if(!m_isReturnLobby)
				m_decoLeftButtons.EnterVisit();
			else
				m_decoLeftButtons.EnterLobbyVisit();
			m_decoRightButtons.Enter();
			m_decoMenuDisabletButtons.Enter();
		}

		// RVA: 0x11D6438 Offset: 0x11D6438 VA: 0x11D6438 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_decoLeftButtons.IsPlaying() && 
					!m_decoRightButtons.IsPlaying() && 
					!m_decoMenuDisabletButtons.IsPlaying() &&
					base.IsEndEnterAnimation();
		}

		// RVA: 0x11D64D4 Offset: 0x11D64D4 VA: 0x11D64D4 Slot: 12
		protected override void OnStartExitAnimation()
		{ 
			m_decoLeftButtons.Leave();
			m_decoRightButtons.Leave();
			m_decoMenuDisabletButtons.Leave();
		}

		// RVA: 0x11D6544 Offset: 0x11D6544 VA: 0x11D6544 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_decoLeftButtons.IsPlaying() &&
					!m_decoRightButtons.IsPlaying() && 
					!m_decoMenuDisabletButtons.IsPlaying() &&
					base.IsEndExitAnimation();
		}

		// RVA: 0x11D65E0 Offset: 0x11D65E0 VA: 0x11D65E0 Slot: 14
		protected override void OnDestoryScene()
		{
			m_decorationCanvas.EnableCanvasController(false);
			m_decoRightButtons.Release();
			if(m_isHideDecorationCanvas)
				m_decorationCanvas.SetActive(false);
			m_isHideDecorationCanvas =false;
			if(!m_isTranstion)
				return;
			MenuScene.Instance.InputEnable();
		}

		// RVA: 0x11D6708 Offset: 0x11D6708 VA: 0x11D6708 Slot: 15
		protected override void OnDeleteCache()
		{
			if(m_decorationCanvas != null)
				Destroy(m_decorationCanvas.gameObject);
			AssetBundleManager.UnloadAssetBundle(DecorationConstants.BundleName, false);
		}

		// RVA: 0x11D6878 Offset: 0x11D6878 VA: 0x11D6878 Slot: 20
		protected override bool OnBgmStart()
		{
			int id = BgControl.GetHomeBgId(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
			int idx = id - 1;
			if(m_bgmIds.Length  < id - 1)
				idx = 0;
			SoundManager.Instance.bgmPlayer.ContinuousPlay(BgmPlayer.MENU_BGM_ID_BASE + m_bgmIds[idx], 1);
			return true;
		}

		// // RVA: 0x11D6A94 Offset: 0x11D6A94 VA: 0x11D6A94
		private void OnDisableMenuButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			m_decoLeftButtons.Leave();
			m_decoRightButtons.Leave();
			m_decoMenuDisabletButtons.Leave();
			m_showMenuButton.gameObject.SetActive(true);
		}

		// // RVA: 0x11D6B94 Offset: 0x11D6B94 VA: 0x11D6B94
		private void OnEnableMenuButton()
		{
			if(!m_isReturnLobby)
				m_decoLeftButtons.EnterVisit();
			else
				m_decoLeftButtons.EnterLobbyVisit();
			m_decoRightButtons.Enter();
			m_decoMenuDisabletButtons.Enter();
			m_showMenuButton.gameObject.SetActive(false);
		}

		// // RVA: 0x11D6C5C Offset: 0x11D6C5C VA: 0x11D6C5C
		private void OnPushDecoRoomButton()
		{
			ILCCJNDFFOB.HHCJCDFCLOB.CLGHLKLHEAK(JpStringLiterals.StringLiteral_15553, 0);
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MenuScene.Instance.Mount(TransitionUniqueId.DECO, null,true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
			m_isTranstion = true;
			MenuScene.Instance.InputDisable();
		}

		// // RVA: 0x11D6DFC Offset: 0x11D6DFC VA: 0x11D6DFC
		private void OnPushLobbyButton()
		{
			ILCCJNDFFOB.HHCJCDFCLOB.CLGHLKLHEAK(JpStringLiterals.StringLiteral_15554, 0);
			m_isHideDecorationCanvas = true;
			EventLobbyArgs arg = new EventLobbyArgs();
			arg.IsMyLobby = true;
			arg.playerId = NKGJPJPHLIF.HHCJCDFCLOB.CAFHLEFMMGD_GetPlayerId();
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			MenuScene.Instance.Mount(TransitionUniqueId.HOME_LOBBYMAIN, arg, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
			m_isTranstion = true;
			MenuScene.Instance.InputDisable();
		}

		// // RVA: 0x11D7034 Offset: 0x11D7034 VA: 0x11D7034
		private void OnPushVisitButton()
		{
			if(m_friendPlayerData != null)
			{
				ILCCJNDFFOB.HHCJCDFCLOB.CLGHLKLHEAK("StringLiteral_15476", m_friendPlayerData.MLPEHNBNOGD_Id);
			}
			m_decorationCanvas.WaitingChara(true);
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			MenuScene.Instance.Call(TransitionList.Type.DECO_VISIT_LIST, null, true);
			m_isTranstion = true;
			MenuScene.Instance.InputDisable();
		}

		// // RVA: 0x11D7218 Offset: 0x11D7218 VA: 0x11D7218
		private void OnPushChatButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			if(m_friendPlayerData != null)
			{
				m_isHideDecorationCanvas = true;
				MenuScene.Instance.InputDisable();
				CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.LJLKGPDFEAD_IsBlacklisted(m_friendPlayerData.MLPEHNBNOGD_Id, () =>
				{
					//0x11D8308
					DecoChatArgs arg = new DecoChatArgs();
					arg.playerId = m_friendPlayerData.MLPEHNBNOGD_Id;
					if(m_friendPlayerData != null)
					{
						ILCCJNDFFOB.HHCJCDFCLOB.CLGHLKLHEAK("StringLiteral_15555", m_friendPlayerData.MLPEHNBNOGD_Id);
					}
					MenuScene.Instance.Call(TransitionList.Type.DECO_CHAT, arg, true);
					m_isTranstion = true;
				}, () =>
				{
					//0x11D8B80
					TextPopupSetting s = new TextPopupSetting();
					s.TitleText = MessageManager.Instance.GetMessage("menu", "pop_blocked_title");
					s.Text = MessageManager.Instance.GetMessage("menu", "pop_blocked_text");
					s.WindowSize = SizeType.Small;
					s.IsCaption = true;
					s.Buttons = new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					};
					PopupWindowManager.Show(s, (PopupWindowControl a, PopupButton.ButtonType b, PopupButton.ButtonLabel c) =>
					{
						//0x11D8F28
						MenuScene.Instance.InputEnable();
					}, null, null, null, true, true, false);
				}, (CACGCMBKHDI_Request error) =>
				{
					//0x11D8FC4
					MenuScene.Instance.InputEnable();
				}, (CACGCMBKHDI_Request error) =>
				{
					//0x11D9060
					MenuScene.Instance.GotoTitle();
				});
			}
		}

		// // RVA: 0x11D764C Offset: 0x11D764C VA: 0x11D764C
		private void OnPushGiftButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(Co_SendingGift(m_friendPlayerData.MLPEHNBNOGD_Id));
		}

		// // RVA: 0x11D7780 Offset: 0x11D7780 VA: 0x11D7780
		private void OnPushFriendButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(Co_FriendRequest());
		}

		// // RVA: 0x11D7880 Offset: 0x11D7880 VA: 0x11D7880
		private void OnPushFanButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(Co_RequestFan(m_friendPlayerData));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6D58DC Offset: 0x6D58DC VA: 0x6D58DC
		// // RVA: 0x11D6234 Offset: 0x11D6234 VA: 0x11D6234
		private IEnumerator Co_Initialize()
		{
			//0x11DA818
			yield return AssetBundleManager.LoadUnionAssetBundle(DecorationConstants.BundleName);
			yield return Co.R(Co_InitializeLayout());
			m_decorationCanvas = DecorationCanvas.instance;
			if(m_decorationCanvas == null)
			{
				yield return Co.R(Co_InitializeDecoration());
			}
			//LAB_011daa24
			IsReady = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6D5954 Offset: 0x6D5954 VA: 0x6D5954
		// // RVA: 0x11D79C0 Offset: 0x11D79C0 VA: 0x11D79C0
		private IEnumerator Co_InitializeDecoration()
		{
			string bundleName;
			AssetBundleLoadAllAssetOperationBase op;

			//0x11DB2EC
			bundleName = DecorationConstants.cmnAssetPath;
			op = AssetBundleManager.LoadAllAssetAsync(bundleName);
			yield return op;
			GameObject g = Instantiate(op.GetAsset<GameObject>(DecorationConstants.CanvasName));
			g.transform.SetParent(null, false);
			g.name = DecorationConstants.CanvasName;
			m_decorationCanvas = g.AddComponent<DecorationCanvas>();
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			DecorationCanvas.instance = m_decorationCanvas;
			m_decorationCanvas.LoadResource();
			yield return new WaitUntil(() =>
			{
				//0x11D84A0
				return m_decorationCanvas.IsLoaded;
			});
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6D59CC Offset: 0x6D59CC VA: 0x6D59CC
		// // RVA: 0x11D7A6C Offset: 0x11D7A6C VA: 0x11D7A6C
		private IEnumerator Co_InitializeLayout()
		{
			AssetBundleLoadLayoutOperationBase op;
			XeSys.FontInfo font;

			//0x11DB764
			m_sentGiftPopupSetting.WindowSize = 0;
			m_sentGiftPopupSetting.SetParent(transform);
			m_sentGiftPopupSetting.TitleText =MessageManager.Instance.GetMessage("menu", "pop_deco_gift_success_title");
			m_sentGiftPopupSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_sentGiftErrorPopupSetting = PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("pop_deco_gift_failed_title"),
				SizeType.Small, bk.GetMessageByLabel("pop_deco_gift_failed_message"), m_popupButtons, false, true);
			op = AssetBundleManager.LoadLayoutAsync(DecorationConstants.BundleName, LayoutDecorationLeftButtons.AssetName);
			yield return op;
			font = GameManager.Instance.GetSystemFont();
			yield return Co.R(op.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0x11D84CC
				instance.transform.SetParent(transform, false);
				m_decoLeftButtons = instance.GetComponent<LayoutDecorationLeftButtons>();
				m_decoLeftButtons.OnClickReturnDecoButton = OnPushDecoRoomButton;
				m_decoLeftButtons.OnClickReturnLobbyButton = OnPushLobbyButton;
				m_decoLeftButtons.OnClickVisitDecoButton = OnPushVisitButton;
				m_decoLeftButtons.OnClickDecoBoardButton = OnPushChatButton;
				m_decoLeftButtons.Hide();
			}));
			AssetBundleManager.UnloadAssetBundle(DecorationConstants.BundleName, false);
			op = AssetBundleManager.LoadLayoutAsync(DecorationConstants.BundleName, LayoutDecorationVisitRightButtons.AssetName);
			yield return op;
			yield return Co.R(op.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0x11D86FC
				instance.transform.SetParent(transform, false);
				m_decoRightButtons = instance.GetComponent<LayoutDecorationVisitRightButtons>();
				m_decoRightButtons.ClickDivaIconCallback = () =>
				{
					//0x11D90FC
					return;
				};
				m_decoRightButtons.ClickFriendButtonCallback = OnPushFriendButton;
				m_decoRightButtons.ClickGiftButtonCallback = OnPushGiftButton;
				m_decoRightButtons.ClickFanButtonCallback = OnPushFanButton;
				m_decoRightButtons.Hide();
			}));
			AssetBundleManager.UnloadAssetBundle(DecorationConstants.BundleName, false);
			op = AssetBundleManager.LoadLayoutAsync(DecorationConstants.BundleName, LayoutDecorationMenuDisableButton.AssetName);
			yield return op;
			yield return Co.R(op.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0x11D89C4
				instance.transform.SetParent(transform, false);
				m_decoMenuDisabletButtons = instance.GetComponent<LayoutDecorationMenuDisableButton>();
				m_decoMenuDisabletButtons.OnClickMenuDisableButton = OnDisableMenuButton;
				m_decoRightButtons.Hide();
			}));
			AssetBundleManager.UnloadAssetBundle(DecorationConstants.BundleName, false);
			GameObject g = new GameObject("touchArea");
			RectTransform rt = g.AddComponent<RectTransform>();
			g.AddComponent<LayoutUGUIHitOnly>();
			m_showMenuButton = g.AddComponent<ButtonBase>();
			rt.anchorMin = new Vector2(0, 0);
			rt.anchorMax = new Vector2(1, 1);
			rt.sizeDelta = new Vector2(0, 0);
			rt.transform.SetParent(transform, false);
			m_showMenuButton.AddOnClickCallback(OnEnableMenuButton);
			m_showMenuButton.gameObject.SetActive(false);
		}

		// // RVA: 0x11D7B18 Offset: 0x11D7B18 VA: 0x11D7B18
		private void UpdatePlayerInfo(EAJCBFGKKFA_FriendInfo friendPlayerData, DAJBODHMLAB_DecoPublicSet decoPublicSet)
		{
			m_decoRightButtons.UpdateContent(friendPlayerData, decoPublicSet.LJMCPFACDGJ.CPOONLHIMKC_DecoRoomName);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6D5A44 Offset: 0x6D5A44 VA: 0x6D5A44
		// // RVA: 0x11D7B88 Offset: 0x11D7B88 VA: 0x11D7B88
		private IEnumerator Co_InitializeDecoData(EAJCBFGKKFA_FriendInfo friendPlayerData, HNKMEOKCNBI.BEABGIOEFLG visitType)
		{
			int playerId;

			//0x11DAB10
			DAJBODHMLAB_DecoPublicSet decoSet = null;
			playerId = friendPlayerData.MLPEHNBNOGD_Id;
			m_isInitialized = false;
			bool isDone = false;
			bool isError = false;
			if(friendPlayerData.BHJLNGEDEGN)
			{
				yield return Co.R(Co_RequestPlayerDecoSet(playerId, (DAJBODHMLAB_DecoPublicSet data) =>
				{
					//0x11D9134
					decoSet = data;
				}));
				if(decoSet == null)
				{
					m_isInitialized = true;
					yield break;
				}
			}
			else
			{
				decoSet = new DAJBODHMLAB_DecoPublicSet();
				JFOBOMOMENL.AOFAHDGAMKH(decoSet, null, null, null, null, null, false);
			}
			isDone = false;
			isError = false;
			m_visitControl.MFMIENLDJIL(playerId, visitType, () =>
			{
				//0x11D913C
				isDone = true;
			}, () =>
			{
				//0x11D9148
				isDone = true;
				isError = true;
			});
			while(!isDone)
				yield return null;
			if(isError)
			{
				m_isInitialized = true;
				GotoTitle();
				yield break;
			}
			JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.HEFIKPAHCIA(GBNDFCEDNMG.CJDGJFINBFH.CHIIAHIJFCB/*33*/);
			isDone = false;
			isError = false;
			PBJPACKDIIB.NPIJAIOCACL(() =>
			{
				//0x11D9154
				isDone = true;
			}, () =>
			{
				//0x11D9160
				isDone = true;
				isError = true;
			});
			while(!isDone)
				yield return null;
			m_decorationCanvas.SetActive(true);
			m_decorationCanvas.LoadDecoration(decoSet.LJMCPFACDGJ);
			yield return new WaitUntil(() =>
			{
				//0x11D916C
				return m_decorationCanvas.IsLoadedDecoration;
			});
			UpdatePlayerInfo(friendPlayerData, decoSet);
			m_decorationCanvas.StartAnimation();
			m_isTranstion = false;
			m_isInitialized = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6D5ABC Offset: 0x6D5ABC VA: 0x6D5ABC
		// // RVA: 0x11D7C68 Offset: 0x11D7C68 VA: 0x11D7C68
		private IEnumerator Co_RequestPlayerDecoSet(int playerId, Action<DAJBODHMLAB_DecoPublicSet> onSuccess)
		{
			//0x11DD7E8
			bool isDone = false;
			bool isError = false;
			m_visitControl.CHEAPBCCBBN_GetUserDecoSet(playerId, (DAJBODHMLAB_DecoPublicSet decoSet) =>
			{
				//0x11D91B4
				isDone = true;
				if(onSuccess != null)
					onSuccess(decoSet);
			}, () =>
			{
				//0x11D9230
				isDone = true;
				isError = true;
			});
			while(!isDone)
				yield return null;
			if(isError)
				GotoTitle();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6D5B34 Offset: 0x6D5B34 VA: 0x6D5B34
		// // RVA: 0x11D76D8 Offset: 0x11D76D8 VA: 0x11D76D8
		private IEnumerator Co_SendingGift(int playerId)
		{
			//0x11DDACC
			MenuScene.Instance.InputDisable();
            BBHNACPENDM_ServerSaveData pd = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave;
			bool isDone = false;
			bool isExcess = false;
			bool isError = false;
			bool isAlreadySent = false;
			if(NKGJPJPHLIF.HHCJCDFCLOB.DPJBHHIHJJK)
			{
				yield return this.StartCoroutineWatched(DecoScene.Co_UpdateDirtyTime());
			}
			if(MenuScene.CheckDatelineAndAssetUpdate())
				yield break;
			m_visitControl.KCKOFIIHDBJ_SendGift(playerId, (int itemId, int count) =>
			{
				//0x11D9248
				isDone = true;
				CIOECGOMILE.HHCJCDFCLOB.JANMJPOKLFL.JCHLONCMPAJ();
				CIOECGOMILE.HHCJCDFCLOB.JANMJPOKLFL.CPIICACGNBH_AddItem(pd, itemId, count, null, 0);
				m_sentGiftPopupSetting.itemId = itemId;
				m_sentGiftPopupSetting.count = count;
				m_sentGiftPopupSetting.sentCount = 1;
			}, () =>
			{
				//0x11D93F4
				isExcess = true;
				isDone = true;
			}, () =>
			{
				//0x11D9404
				isAlreadySent = true;
				isDone = true;
			}, () =>
			{
				//0x11D9414
				isError = true;
				isDone = true;
			});
			while(!isDone)
				yield return null;
			if(isError)
			{
				MenuScene.Instance.GotoTitle();
				yield break;
			}
			isDone = false;
			if(!isExcess)
			{
				MenuScene.Save(() =>
				{
					//0x11D9430
					isDone = true;
				}, null);
				while(!isDone)
					yield return null;
				isDone = false;
				PopupWindowManager.Show(m_sentGiftPopupSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x11D943C
					isDone = true;
				}, null, null, null, true, true, false);
				while(!isDone)
					yield return null;
				m_decoRightButtons.DisableButton_Gift();
			}
			else
			{
				PopupWindowManager.Show(m_sentGiftErrorPopupSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x11D9424
					isDone = true;
				}, null, null, null, true, true, false);
				while(!isDone)
					yield return null;
			}
			MenuScene.Instance.InputEnable();
        }

		// [IteratorStateMachineAttribute] // RVA: 0x6D5BAC Offset: 0x6D5BAC VA: 0x6D5BAC
		// // RVA: 0x11D77F4 Offset: 0x11D77F4 VA: 0x11D77F4
		private IEnumerator Co_FriendRequest()
		{
			//0x11DA22C
			MenuScene.Instance.InputDisable();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			bool isRequest = false;
			bool isDone = false;
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("popup_friend_request_title"), SizeType.Small, string.Format(bk.GetMessageByLabel("popup_friend_request_msg"), m_friendPlayerData.LBODHBDOMGK_Name), new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Request, Type = PopupButton.ButtonType.Positive }
			}, false, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x11D9450
				isDone = true;
				isRequest = type == PopupButton.ButtonType.Positive;
			}, null, null, null, true, true, false);
			while(!isDone)
				yield return null;
			if(isRequest)
			{
				this.StartCoroutineWatched(Co_DoFriendRequest(m_friendPlayerData.MLPEHNBNOGD_Id, m_friendPlayerData.LBODHBDOMGK_Name, m_friendPlayerData.ILOJAJNCPEC_Rank));
			}
			MenuScene.Instance.InputEnable();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6D5C24 Offset: 0x6D5C24 VA: 0x6D5C24
		// // RVA: 0x11D7D88 Offset: 0x11D7D88 VA: 0x11D7D88
		private IEnumerator Co_DoFriendRequest(int playerId, string playerName, int playerRank)
		{
			//0x11D9BB8
			bool isDone = false;
			bool isError = false;
			bool isGotoTitle = false;
			CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.AOHLMBKILED(playerId, playerName, playerRank, () =>
			{
				//0x11D9470
				isDone = true;
			}, (CACGCMBKHDI_Request action) =>
			{
				//0x11D947C
				isDone = true;
				isError = true;
			}, (CACGCMBKHDI_Request action) =>
			{
				//0x11D9488
				isGotoTitle = true;
				isDone = true;
			});
			while(!isDone)
				yield return null;
			if(isGotoTitle)
			{
				MenuScene.Instance.GotoTitle();
				yield break;
			}
			if(isError)
				yield break;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			isDone = false;
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("popup_friend_requested_title"), SizeType.Small, bk.GetMessageByLabel("popup_friend_requested_msg"), new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			}, false, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x11D9498
				isDone = true;
			}, null, null, null, true, true, false);
			while(!isDone)
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6D5C9C Offset: 0x6D5C9C VA: 0x6D5C9C
		// // RVA: 0x11D78F8 Offset: 0x11D78F8 VA: 0x11D78F8
		private IEnumerator Co_RequestFan(EAJCBFGKKFA_FriendInfo friendData)
		{
			bool isFav;

			//0x11DCCD8
			isFav = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.GAAOPEGIPKA_FavoritePlayer.FFKIDMKHIOE(friendData.MLPEHNBNOGD_Id);
			bool isDone = false;
			bool isError = false;
			bool isOk = false;
			MenuScene.Instance.InputDisable();
			m_decorationCanvas.EnableCanvasController(false);
			if(!isFav)
			{
				if(PIGBKEIAMPE_FriendManager.DJHFILDBOFG_GetMaxFanPossible() <= PIGBKEIAMPE_FriendManager.GKDGOGCOGBK())
				{
					PopupWindowManager.FanLimitPopupShow(() =>
					{
						//0x11D94C4
						MenuScene.Instance.InputEnable();
						m_decorationCanvas.EnableCanvasController(false);
					});
					yield break;
				}
				PopupWindowManager.FanEntryConfirmPopupShow(friendData.LBODHBDOMGK_Name, () =>
				{
					//0x11D959C
					isOk = true;
				}, null, () =>
				{
					//0x11D95A8
					isDone = true;
				});
			}
			else
			{
				PopupWindowManager.FanReleaseConfirmPopupShow(friendData.LBODHBDOMGK_Name, () =>
				{
					//0x11D94AC
					isOk = true;
				}, null, () =>
				{
					//0x11D94B8
					isDone = true;
				});
			}
			yield return new WaitUntil(() =>
			{
				//0x11D95B4
				return isDone;
			});
			isDone = false;
			if(!isOk)
			{
				MenuScene.Instance.InputEnable();
			}
			else
			{
				m_addFavList.Clear();
				m_removeFavList.Clear();
				if(!isFav)
				{
					m_addFavList.Add(friendData.MLPEHNBNOGD_Id);
				}
				else
				{
					m_removeFavList.Add(friendData.MLPEHNBNOGD_Id);
				}
				CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.EPKOLKBGOGA(m_addFavList, m_removeFavList, () =>
				{
					//0x11D95BC
					CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.NDDIOKIKCNA_GetFanCount(friendData.MLPEHNBNOGD_Id, (int fanCount) =>
					{
						//0x11D9748
						if(m_addFavList.Count == 0)
						{
							if(m_removeFavList.Count != 0)
							{
								ILCCJNDFFOB.HHCJCDFCLOB.JCJCJPCHNEN(m_removeFavList[0], 1, fanCount, CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.PDEACDHIJJJ_IsFriend(m_removeFavList[0]));
							}
						}
						else
						{
							ILCCJNDFFOB.HHCJCDFCLOB.JCJCJPCHNEN(m_addFavList[0], 1, fanCount, CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.PDEACDHIJJJ_IsFriend(m_addFavList[0]));
						}
						isDone = true;
					}, () =>
					{
						//0x11D9AC4
						isError = true;
						isDone = true;
					});
				}, () =>
				{
					//0x11D9AD4
					isError = true;
					isDone = true;
				}, () =>
				{
					//0x11D9AE4
					PopupFanLimit(() =>
					{
						//0x11D9B94
						isDone = true;
					});
				});
				while(!isDone)
					yield return null;
				if(isError)
				{
					MenuScene.Instance.GotoTitle();
					yield break;
				}
				m_decoRightButtons.UpdateFriendIcon(friendData);
				m_decoRightButtons.FanButtonLabelChange(!isFav);
				MenuScene.Instance.InputEnable();
			}
			m_decorationCanvas.EnableCanvasController(true);
		}

		// // RVA: 0x11D7E88 Offset: 0x11D7E88 VA: 0x11D7E88
		private void PopupFanLimit(Action onEndPopup)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = new TextPopupSetting();
			s.TitleText = bk.GetMessageByLabel("pop_lobby_member_fan_capacityover_title");
			s.Text = bk.GetMessageByLabel("pop_lobby_member_capacityover_desc");
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(s, (PopupWindowControl c, PopupButton.ButtonType t, PopupButton.ButtonLabel l) =>
			{
				//0x11D9BA0
				if(onEndPopup != null)
					onEndPopup();
			}, null, null, null, true, true, false);
		}
	}
}
