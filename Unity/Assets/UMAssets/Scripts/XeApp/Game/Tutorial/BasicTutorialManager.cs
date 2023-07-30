using XeSys;
using UnityEngine;
using System.Text;
using System;
using XeApp.Game.Adv;
using System.Collections.Generic;
using XeApp.Game.Common;
using UnityEngine.Events;
using System.Collections;
using XeApp.Core;
using XeApp.Game.Menu;
using UnityEngine.SceneManagement;
using XeSys.Gfx;

namespace XeApp.Game.Tutorial
{
	public enum BasicTutorialMessageId
	{
		Id_BeginAdjust = 1,
		Id_ConfirmAdjust = 25,
		Id_EndAdjust = 2,
		Id_StartGame = 3,
		Id_ManualEnd = 24,
		Id_FailedGame = 4,
		Id_GachaList = 5,
		Id_GachaMain = 6,
		Id_GachaResult = 7,
		Id_GachaEnd = 8,
		Id_Setting = 9,
		Id_PlateSelect = 10,
		Id_PlateSelected = 11,
		Id_SnsStart = 12,
		Id_RoomSelected = 13,
		Id_Sns1 = 14,
		Id_DivaSelect = 16,
		Id_DecideDiva = 26,
		Id_StartMission1 = 20,
		Id_StartMission2 = 21,
		Id_Mission = 22,
		Id_ClearMission = 23,
		Id_EpisodeMission1 = 27,
		Id_EpisodeMission2 = 28,
		Id_EpisodeMission3 = 29,
		Id_GameResult = 55,
		Id_StartMission3 = 60,
		Id_UnitAutoSetting1 = 65,
		Id_UnitAutoSetting2 = 66,
		Id_LiveClear1 = 70,
		Id_LiveClear2 = 71,
		Id_MusicOpen = 75,
		Id_SceneGrowth = 80,
		Id_DivaSelect1 = 85,
		Id_DivaSelect2 = 86,
		Id_AssistSelect = 90,
		Id_OfferRelease = 91,
		Id_OfferOrder = 92,
		Id_OfferPlatoon = 93,
		Id_OfferTransFrom = 94,
		Id_CostumeUpgradeHome = 95,
		Id_CostumeUpgradeMenu = 96,
		Id_CostumeUpgradeSelect = 97,
		Id_BingoMission = 98,
		Id_ValkyrieUpgradeHome = 99,
		Id_ValkyrieUpgradeMenu = 100,
		Id_McrsLobby = 101,
		Id_Decolture = 102,
		Id_RaidFromMcrsLobby = 103,
		Id_RaidUseFoldRadar1 = 104,
		Id_RaidUseFoldRadar2 = 105,
		Id_Unit5Help1 = 106,
		Id_Unit5Help2 = 107,
	}
	public class BasicTutorialManager : SingletonBehaviour<BasicTutorialManager>
	{
		private GameObject m_blackImageInstance; // 0xC
		private TutorialHighLight m_highLight; // 0x10
		private GameObject m_cursorInstance; // 0x14
		private TutorialPointer m_pointer; // 0x18
		private List<ButtonBase> m_buttonList = new List<ButtonBase>(); // 0x1C
		private StringBuilder m_strBuilder = new StringBuilder(10); // 0x20
		private TutorialMessageWindow m_messageWindow; // 0x24
		private int[,] m_charaTextRowColCountTable = new int[2, 3]
		{
			{8, 17, 11},
			{21, 18, 30}
		}; // 0x28

		// // RVA: 0xE3D1B0 Offset: 0xE3D1B0 VA: 0xE3D1B0
		// public bool IsLoadedLayout() { }

		// // RVA: 0xE3D23C Offset: 0xE3D23C VA: 0xE3D23C
		public static void Initialize()
		{
			BasicTutorialManager bt = GameManager.Instance.gameObject.GetComponent<BasicTutorialManager>();
			if(GameManager.Instance != null && bt == null)
			{
				bt = GameManager.Instance.gameObject.AddComponent<BasicTutorialManager>();
			}
		}

		// // RVA: 0xE3D3E8 Offset: 0xE3D3E8 VA: 0xE3D3E8
		public void PreLoadResource(UnityAction finishCb, bool isAppendLayout = true)
		{
			this.StartCoroutineWatched(PreLoadLayoutCoroutine(finishCb, isAppendLayout));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6AE360 Offset: 0x6AE360 VA: 0x6AE360
		// // RVA: 0xE3D4CC Offset: 0xE3D4CC VA: 0xE3D4CC
		public IEnumerator PreDownLoadTextureResource(BasicTutorialMessageId id)
		{
			//0xE43BCC
			ILLPGHGGKLL_TutorialMiniAdv.AFBMNDPOALE t = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LINHIDCNAMG_TutorialMiniAdv.LBDOLHGDIEB((int)id);
			if(t == null)
				yield return null;
			for(int i = 0; i < t.KGJHFFNFPOK_CharacterId.Length; i++)
			{
				KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(DivaIconTextureCache.MakeTutorialIconPath(t.KGJHFFNFPOK_CharacterId[i]));
			}
			while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
		}

		// // RVA: 0xE3D578 Offset: 0xE3D578 VA: 0xE3D578 Slot: 6
		public virtual void Release()
		{
			if(m_messageWindow != null)
			{
				Destroy(m_messageWindow.gameObject);
				m_messageWindow = null;
			}
			if(m_blackImageInstance != null)
			{
				Destroy(m_blackImageInstance.gameObject);
				m_blackImageInstance = null;
				m_highLight = null;
			}
			if(m_cursorInstance != null)
			{
				Destroy(m_cursorInstance.gameObject);
				m_cursorInstance = null;
			}
		}

		// // RVA: 0xE3D7CC Offset: 0xE3D7CC VA: 0xE3D7CC
		// public static void SetupFirstTutorialLog() { }

		// // RVA: 0xE3D9B0 Offset: 0xE3D9B0 VA: 0xE3D9B0
		public static void Log(OAGBCBBHMPF.OGBCFNIKAFI step)
		{
			TodoLogger.Log(0, "Log");
		}

		// // RVA: 0xE3DB08 Offset: 0xE3DB08 VA: 0xE3DB08
		public static void TutorialAfterFirstLoginBonus()
		{
			if((GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.NJFNCNCJMOO_FirstLogin & 1) == 0)
			{
				if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KIECDDFNCAN_Level != 1)
					return;
				TodoLogger.Log(0, "TutorialAfterFirstLoginBonus");
			}
		}

		// // RVA: 0xE3DD1C Offset: 0xE3DD1C VA: 0xE3DD1C
		public static void TutorialAfterFirstHome()
		{
			if((GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.NJFNCNCJMOO_FirstLogin & 2) == 0)
			{
				if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KIECDDFNCAN_Level != 1)
				{
					return;
				}
				TodoLogger.Log(0, "TutorialAfterFirstHome");
			}
		}

		// // RVA: 0xE3DF30 Offset: 0xE3DF30 VA: 0xE3DF30
		public void ShowMessageWindow(BasicTutorialMessageId id, Action endCallBack, AdvMessageBase.TagConvertFunc func)
		{
			ILLPGHGGKLL_TutorialMiniAdv.AFBMNDPOALE data = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LINHIDCNAMG_TutorialMiniAdv.LBDOLHGDIEB((int)id);
			if(data != null)
			{
				this.StartCoroutineWatched(ProcMessage(data, endCallBack, func));
				return;
			}
			if (endCallBack != null)
				endCallBack();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6AE3D8 Offset: 0x6AE3D8 VA: 0x6AE3D8
		// // RVA: 0xE3E078 Offset: 0xE3E078 VA: 0xE3E078
		private IEnumerator ProcMessage(ILLPGHGGKLL_TutorialMiniAdv.AFBMNDPOALE messData, Action endCallBack, AdvMessageBase.TagConvertFunc func)
		{
			TutorialMessageWindow.Position position; // 0x20
			int i; // 0x24

			//0xE440BC
			position = messData.NDFOAINJPIN_WindowPositionTop != 1 ? TutorialMessageWindow.Position.Bottom : TutorialMessageWindow.Position.Top;
			m_messageWindow.gameObject.SetActive(true);
			m_messageWindow.ResetWindow();
			for(i = 0; i < messData.JONNCMDGMKA.Length; i++)
			{
				yield return Co.R(m_messageWindow.ProcMessageCoroutine(messData.KGJHFFNFPOK_CharacterId[i], position, messData.JONNCMDGMKA[i], func));
			}
			m_messageWindow.gameObject.SetActive(false);
			if (MenuScene.Instance != null)
				MenuScene.Instance.RaycastDisable();
			yield return null;
			if (MenuScene.Instance != null)
				MenuScene.Instance.RaycastEnable();
			if (endCallBack != null)
				endCallBack();
		}

		// // RVA: 0xE3E170 Offset: 0xE3E170 VA: 0xE3E170
		public void SetInputLimit(InputLimitButton button, UnityAction onPush, Func<ButtonBase> findButton, TutorialPointer.Direction dir = TutorialPointer.Direction.Normal)
		{
			MenuHeaderControl.Button headerButton = 0;
			MenuFooterControl.Button footerButton = 0;
			bool b2 = false;
			ButtonBase buttonBase = null;
			TransitionRoot tr = MenuScene.Instance.GetCurrentTransitionRoot();
			RectTransform rt = null;
			TutorialPointer.Direction d = dir;
			Vector2 v1 = Vector2.zero;
			Vector2 v2 = Vector2.zero;
			if (button == InputLimitButton.PopupPositiveButton)
			{
				PopupWindowManager.SetInputState(false);
				buttonBase = PopupWindowManager.FindTopPopupButton(PopupButton.ButtonType.Positive);
				buttonBase.IsInputOff = false;
			}
			else
			{
				if(SceneManager.GetActiveScene().name == "Menu")
				{
					if(MenuScene.Instance != null)
					{
						tr.InputDisable(null);
						switch (button)
						{
							case InputLimitButton.CmnBack:
								headerButton = MenuHeaderControl.Button.All & ~MenuHeaderControl.Button.Back;
								footerButton = MenuFooterControl.Button.All;
								tr.InputDisable(null);
								buttonBase = MenuScene.Instance.HeaderMenu.FindButton(MenuHeaderControl.Button.Back);
								break;
							default:
								break;
							case InputLimitButton.GachaBuy:
								headerButton = MenuHeaderControl.Button.All;
								footerButton = MenuFooterControl.Button.All;
								tr.InputEnable("sw_gacha_btn_anim_r (AbsoluteLayout)", "sw_gacha_btn (AbsoluteLayout)");
								tr.InputEnable("sw_but_detail_anime (AbsoluteLayout)", "sw_gacha_legal_inout_anim (AbsoluteLayout)");
								buttonBase = tr.FindButton("sw_gacha_btn_anim_r (AbsoluteLayout)", "sw_gacha_btn (AbsoluteLayout)");
								rt = Array.Find(tr.GetComponentsInChildren<RectTransform>(true), (RectTransform x) =>
								{
									//0xE427CC
									return x.name.Contains("root_gacha_title_layout_root");
								});
								b2 = true;
								break;
							case InputLimitButton.Setting:
							case InputLimitButton.VOP:
							case InputLimitButton.Mission:
								headerButton = MenuHeaderControl.Button.All;
								footerButton = MenuFooterControl.Button.All;
								tr.InputDisable(null);
								if(button == InputLimitButton.Mission)
								{
									footerButton &= ~MenuFooterControl.Button.Mission;
									buttonBase = MenuScene.Instance.FooterMenu.FindButton(MenuFooterControl.Button.Mission);
								}
								else if (button == InputLimitButton.VOP)
								{
									footerButton &= ~MenuFooterControl.Button.VOP;
									buttonBase = MenuScene.Instance.FooterMenu.FindButton(MenuFooterControl.Button.VOP);
								}
								else
								{
									d = TutorialPointer.Direction.Down;
									if (button != InputLimitButton.Setting)
										break;
									footerButton &= ~MenuFooterControl.Button.Setting;
									buttonBase = MenuScene.Instance.FooterMenu.FindButton(MenuFooterControl.Button.Setting);
								}
								break;
							case InputLimitButton.UnitSetting:
								headerButton = MenuHeaderControl.Button.All;
								footerButton = MenuFooterControl.Button.All;
								tr.InputEnable("sw_s_m_btn_01_anim (AbsoluteLayout)", "setting_menu (AbsoluteLayout)");
								buttonBase = tr.FindButton("sw_s_m_btn_01_anim (AbsoluteLayout)", "setting_menu (AbsoluteLayout)");
								break;
							case InputLimitButton.MainScene:
								headerButton = MenuHeaderControl.Button.All;
								footerButton = MenuFooterControl.Button.All;
								CharaSet[] cs = rt.GetComponentsInChildren<CharaSet>(true);
								cs[2].MainSceneBusttons[1].IsInputOff = false;
								buttonBase = cs[2].MainSceneBusttons[1];
								break;
							case InputLimitButton.Scene:
								headerButton = MenuHeaderControl.Button.All;
								footerButton = MenuFooterControl.Button.All;
								SwapScrollList s = rt.GetComponentInChildren<SwapScrollList>(true);
								buttonBase = s.ScrollObjects[5].GetComponentInChildren<StayButton>(true);
								buttonBase.ClearOnClickCallback();
								buttonBase.IsInputOff = false;
								v1 = new Vector2(1.2f, 1.25f);
								v2 = new Vector2(-0.1f, -0.15f);
								break;
							case InputLimitButton.LobbyTab:
								buttonBase = MenuScene.Instance.LobbyButtonControl.m_lobbyTabBtn.tabBtn;
								if(buttonBase != null)
								{
									buttonBase.IsInputOff = false;
								}
								break;
							case InputLimitButton.LobbyScene:
								buttonBase = MenuScene.Instance.LobbyButtonControl.m_lobbySceneBtn.sceneBtn;
								if (buttonBase != null)
								{
									buttonBase.IsInputOff = false;
								}
								break;
							case InputLimitButton.Delegate:
								headerButton = MenuHeaderControl.Button.All;
								footerButton = MenuFooterControl.Button.All;
								if(findButton != null)
								{
									buttonBase = findButton();
									if (buttonBase != null)
									{
										buttonBase.IsInputOff = false;
									}
								}
								break;
						}
					}
					//LAB_00e3f120
				}
				else if(SceneManager.GetActiveScene().name == "GachaDirection")
				{
					TodoLogger.Log(0, "GachaDirection");
				}
				else if(SceneManager.GetActiveScene().name == "Adv" && button == InputLimitButton.SnsRoomButton)
				{
					TodoLogger.Log(0, "Adv");
				}
				//LAB_00e3f120
			}
			//LAB_00e3f120
			if(buttonBase != null)
			{
				if(headerButton != 0)
				{
					MenuScene.Instance.HeaderMenu.SetButtonDisable(headerButton);
				}
				if(footerButton != 0)
				{
					MenuScene.Instance.FooterMenu.SetButtonDisable(footerButton);
					if (button != InputLimitButton.LobbyTab && button != InputLimitButton.LobbyScene)
					{
						MenuScene.Instance.LobbyButtonControl.EnableButton(false);
					}
				}
				if(MenuScene.Instance != null)
				{
					if(MenuScene.Instance.HelpButton != null)
					{
						MenuScene.Instance.HelpButton.SetDisable();
					}
				}
				LayoutUGUIHitOnly hit = buttonBase.GetComponentInChildren<LayoutUGUIHitOnly>(true);
				if(hit != null)
				{
					if(m_cursorInstance != null)
					{
						SetCursorPosition(hit.transform as RectTransform, d);
						if (b2)
							m_cursorInstance.transform.SetAsFirstSibling();
						else
							m_cursorInstance.transform.SetAsLastSibling();
					}
				}
				if(hit != null)
				{
					if(m_blackImageInstance != null)
					{
						if (b2)
							SetRect(rt, v2, v1);
						else
							SetRect(hit, v2, v1);
						m_blackImageInstance.SetActive(true);
					}
				}
				ButtonBase.OnClickCallback onClickEvent = () =>
				{
					//0xE42918
					TodoLogger.LogNotImplemented("TutoClick");
				};
				buttonBase.AddOnClickCallback(onClickEvent);
			}
		}

		// // RVA: 0xE409E4 Offset: 0xE409E4 VA: 0xE409E4
		// private bool ObjectFindFunc(Transform ts, string name, string parentName) { }

		// // RVA: 0xE40AD4 Offset: 0xE40AD4 VA: 0xE40AD4
		// public void ShowCursor(CursorPosition positionType) { }

		// // RVA: 0xE413B4 Offset: 0xE413B4 VA: 0xE413B4
		public void HideCursor()
		{
			TodoLogger.Log(0, "TODO");
		}

		// // RVA: 0xE4146C Offset: 0xE4146C VA: 0xE4146C
		// public void ChangeCursorLastSibling() { }

		// // RVA: 0xE3FA90 Offset: 0xE3FA90 VA: 0xE3FA90
		private void SetCursorPosition(RectTransform target, TutorialPointer.Direction dir)
		{
			if(m_cursorInstance != null)
			{
				if(target != null)
				{
					Canvas c1 = m_cursorInstance.GetComponentInParent<Canvas>();
					Canvas c2 = target.GetComponentInParent<Canvas>();
					RectTransform rt = m_pointer.RectTransform;
					rt.anchorMax = new Vector2(0.5f, 0.5f);
					rt.anchorMin = new Vector2(0.5f, 0.5f);
					Vector2 v1 = new Vector2();
					RectTransformUtility.ScreenPointToLocalPointInRectangle(c1.transform as RectTransform, RectTransformUtility.WorldToScreenPoint(c2.rootCanvas.worldCamera, target.position), c1.worldCamera, out v1);
					v1.x -= target.sizeDelta.x * target.pivot.x;
					v1.y -= target.sizeDelta.y * target.pivot.y;
					v1.x += target.sizeDelta.x * 0.5f;
					m_pointer.Show(new Vector2(v1.x, v1.y + target.sizeDelta.y * 0.5f), dir);
				}
			}
		}

		// // RVA: 0xE40498 Offset: 0xE40498 VA: 0xE40498
		private void SetRect(LayoutUGUIHitOnly hitOnly, Vector2 offset, Vector2 scale)
		{
			Vector2 v1 = offset;
			if(m_blackImageInstance != null)
			{
				Canvas c1 = hitOnly.GetComponentInParent<Canvas>();
				Canvas c2 = m_blackImageInstance.GetComponentInParent<Canvas>();
				RectTransform t1 = hitOnly.transform as RectTransform;
				Vector2 v = RectTransformUtility.WorldToScreenPoint(c1.rootCanvas.worldCamera, hitOnly.transform.position);
				Vector2 v2;
				RectTransformUtility.ScreenPointToLocalPointInRectangle(c2.transform as RectTransform, v, c2.worldCamera, out v2);
				float f = 1;
				if(SystemManager.isLongScreenDevice)
				{
					f = SystemManager.rawAppScreenRect.height / SystemManager.rawScreenAreaRect.height;
				}
				v1 = new Vector2(t1.sizeDelta.x * v1.x, t1.sizeDelta.y * v1.y);
				Vector2 v3 = v2 + v1;
				Vector2 v4 = new Vector2(f * t1.sizeDelta.x * scale.x, f * t1.sizeDelta.y * scale.y);
				m_highLight.HighLightRect = new Rect(v3.x, v3.y, v4.x, v4.y);
			}
		}

		// // RVA: 0xE3FF5C Offset: 0xE3FF5C VA: 0xE3FF5C
		private void SetRect(RectTransform rt, Vector2 offset, Vector2 scale)
		{
			TodoLogger.Log(0, "SetRect2");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6AE450 Offset: 0x6AE450 VA: 0x6AE450
		// // RVA: 0xE3D40C Offset: 0xE3D40C VA: 0xE3D40C
		private IEnumerator PreLoadLayoutCoroutine(UnityAction finishCb, bool isAppendLayout = false)
		{
			//0xE43F00
			yield return this.StartCoroutineWatched(LoadBaseLayoutCoroutine());
			if(isAppendLayout)
			{
				yield return this.StartCoroutineWatched(LoadAppendLayoutCoroutine());
			}
			if(finishCb != null)
				finishCb();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6AE4C8 Offset: 0x6AE4C8 VA: 0x6AE4C8
		// // RVA: 0xE4172C Offset: 0xE4172C VA: 0xE4172C
		private IEnumerator LoadBaseLayoutCoroutine()
		{
			AssetBundleLoadAssetOperation layOp;

			//0xE43750
			if(m_messageWindow == null)
			{
				layOp = AssetBundleManager.LoadAssetAsync("to.xab", "MessageWindow", typeof(GameObject));
				yield return layOp;
				GameObject g = Instantiate(layOp.GetAsset<GameObject>());
				g.transform.SetParent(GameManager.Instance.PopupCanvas.transform.Find("Root"), false);
				m_messageWindow = g.GetComponent<TutorialMessageWindow>();
				AssetBundleManager.UnloadAssetBundle("to.xab", false);
				m_messageWindow.gameObject.SetActive(false);
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6AE540 Offset: 0x6AE540 VA: 0x6AE540
		// // RVA: 0xE417D8 Offset: 0xE417D8 VA: 0xE417D8
		private IEnumerator LoadAppendLayoutCoroutine()
		{
			int loadCount;
			AssetBundleLoadAssetOperation op;
			AssetBundleLoadLayoutOperationBase layOp;

			//0xE42F6C
			if(m_blackImageInstance != null)
				yield break;
			loadCount = 0;
			op = AssetBundleManager.LoadAssetAsync("ly/080.xab", "BlackBack", typeof(GameObject));
			loadCount++;
			yield return op;
			m_blackImageInstance = Instantiate(op.GetAsset<GameObject>());
			m_highLight = m_blackImageInstance.GetComponent<TutorialHighLight>();
			m_blackImageInstance.gameObject.SetActive(false);
			layOp = AssetBundleManager.LoadLayoutAsync("ly/080.xab", "root_cmn_tuto_finger_layout_root");
			loadCount++;
			yield return layOp;
			yield return layOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) => {
				//0xE42748
				m_cursorInstance = instance;
			});
			while(m_cursorInstance == null)
				yield return null;
			for(int i = 0; i < loadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle("ly/080.xab", false);
			}
			m_blackImageInstance.transform.SetParent(GameManager.Instance.PopupCanvas.transform, false);
			m_blackImageInstance.transform.SetAsLastSibling();
			m_blackImageInstance.SetActive(false);
			m_cursorInstance.transform.SetParent(GameManager.Instance.PopupCanvas.transform, false);
			m_cursorInstance.SetActive(false);
			m_cursorInstance.transform.SetAsLastSibling();
			m_pointer = m_cursorInstance.GetComponent<TutorialPointer>();
		}

		// // RVA: 0xE41884 Offset: 0xE41884 VA: 0xE41884
		// public void UpdateLocalPlayerData() { }

		// // RVA: 0xE419D0 Offset: 0xE419D0 VA: 0xE419D0
		// public void UpdateRecoveryPoint(ILDKBCLAFPB.CDIPJNPICCO rPoint) { }

		// // RVA: 0xE41B10 Offset: 0xE41B10 VA: 0xE41B10
		// public void SaveMusicResult() { }

		// // RVA: 0xE41D24 Offset: 0xE41D24 VA: 0xE41D24
		// public ILDKBCLAFPB.CDIPJNPICCO GetRecoveryPoint() { }

		// // RVA: 0xE41E18 Offset: 0xE41E18 VA: 0xE41E18
		// public JGEOBNENMAH.EDHCNKBMLGI SetupTutorialGame(TutorialGameMode.Type type) { }

		// // RVA: 0xE42544 Offset: 0xE42544 VA: 0xE42544
		public static bool IsBeginnerMission()
		{
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.IJHBIMNKOMC_TutorialEnd < 2;
		}
	}
}
