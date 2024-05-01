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
using XeApp.Game.Gacha;
using UnityEngine.UI;

namespace XeApp.Game.Tutorial
{
	public enum CursorPosition
	{
		None = -1,
		RhythmAdjust = 0,
		ActiveSkill = 1,
		MissionMenuButton = 2,
	}
	public enum BasicTutorialMessageId
	{
		Id_BeginAdjust = 1,
		Id_ConfirmAdjust = 25,
		Id_EndAdjust = 2,
		Id_StartGame = 3,
		Id_ManualEnd = 24,
		Id_FailedGame = 4, // ShowEndTutorialWindow
		Id_GachaList = 5, // ??
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
		Id_McrsLobby = 101,	//?
		Id_Decolture = 102, // lvl 5+
		Id_RaidFromMcrsLobby = 103, //?
		Id_RaidUseFoldRadar1 = 104, //?
		Id_RaidUseFoldRadar2 = 105, //?
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
		public bool IsLoadedLayout()
		{
			return m_messageWindow != null;
		}

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
				yield break;
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
		public static void SetupFirstTutorialLog()
		{
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.KINJOEIAHFK_StartTime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
			if (GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.OLDAGCNLJOI_Progress != 0)
				return;
			Log(OAGBCBBHMPF.OGBCFNIKAFI.FKPEAGGKNLC_0);
		}

		// // RVA: 0xE3D9B0 Offset: 0xE3D9B0 VA: 0xE3D9B0
		public static void Log(OAGBCBBHMPF.OGBCFNIKAFI step)
		{
			ILCCJNDFFOB.HHCJCDFCLOB.ALABPEPENHH(step, GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.KINJOEIAHFK_StartTime);
		}

		// // RVA: 0xE3DB08 Offset: 0xE3DB08 VA: 0xE3DB08
		public static void TutorialAfterFirstLoginBonus()
		{
			if((GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.NJFNCNCJMOO_FirstLogin & 1) == 0)
			{
				if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KIECDDFNCAN_Level != 1)
					return;
				Log(OAGBCBBHMPF.OGBCFNIKAFI.CFHINEFGHPC_47);
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.NJFNCNCJMOO_FirstLogin |= 1;
				GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
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
				Log(OAGBCBBHMPF.OGBCFNIKAFI.LGFGBNKFPGH_48);
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.NJFNCNCJMOO_FirstLogin |= 2;
				GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
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
			RectTransform rt = null;
			TutorialPointer.Direction d = dir;
			Vector2 v1 = Vector2.one;
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
						TransitionRoot tr = MenuScene.Instance.GetCurrentTransitionRoot();
						tr.InputDisable(null);
						//UnityEngine.Debug.LogError(button);
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
								CharaSet[] cs = tr.GetComponentsInChildren<CharaSet>(true);
								cs[2].MainSceneBusttons[1].IsInputOff = false;
								buttonBase = cs[2].MainSceneBusttons[1];
								break;
							case InputLimitButton.Scene:
								headerButton = MenuHeaderControl.Button.All;
								footerButton = MenuFooterControl.Button.All;
								SwapScrollList s = tr.GetComponentInChildren<SwapScrollList>(true);
								buttonBase = s.ScrollObjects[5].GetComponentInChildren<StayButton>(true);
								(buttonBase as StayButton).ClearOnStayCallback();
								buttonBase.IsInputOff = false;
								v1 = new Vector2(1.2f, 1.25f);
								v2 = new Vector2(-0.1f, 0.15f);
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
					GachaDirectionScene scene = FindObjectOfType<GachaDirectionScene>();
					if(scene != null)
					{
						scene.GetComponentsInChildren(m_buttonList);
						for(int i = 0; i < m_buttonList.Count; i++)
						{
							m_buttonList[i].IsInputOff = true;
						}
						if(button == InputLimitButton.GachaReturn)
						{
							buttonBase = m_buttonList.Find((ButtonBase x) =>
							{
								//0xE42864
								return ObjectFindFunc(x.transform, "gatsha_drop_btn03_anim (AbsoluteLayout)", "");
							});
							buttonBase.IsInputOff = false;
							d = TutorialPointer.Direction.Down;
							//>LAB_00e3f120
						}
						else
						{
							//>switchD_00e3e504_caseD_1
						}
					}
				}
				else if(SceneManager.GetActiveScene().name == "Adv" && button == InputLimitButton.SnsRoomButton)
				{
					LayoutSNSScrollList sns = FindObjectOfType<LayoutSNSScrollList>();
					if(sns != null)
					{
						buttonBase = sns.GetComponentInChildren<ScrollRect>(true).content.GetChild(0).GetComponentInChildren<ButtonBase>(true);
						sns.GetComponentsInChildren(m_buttonList);
						for(int i = 0; i < m_buttonList.Count; i++)
						{
							m_buttonList[i].IsInputOff = true;
						}
						buttonBase.IsInputOff = false;
					}
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
				ButtonBase.OnClickCallback onClickEvent = null;
				onClickEvent = () =>
				{
					//0xE42918
					if(m_cursorInstance != null)
					{
						m_cursorInstance.SetActive(false);
					}
					if(m_blackImageInstance != null)
					{
						m_blackImageInstance.SetActive(false);
					}
					if(onPush != null)
					{
						onPush();
					}
					if(headerButton != MenuHeaderControl.Button.None)
					{
						MenuScene.Instance.HeaderMenu.SetButtonEnable(headerButton);
					}
					if(footerButton != MenuFooterControl.Button.None)
					{
						MenuScene.Instance.FooterMenu.SetButtonEnable(footerButton);
						if(button != InputLimitButton.LobbyTab)
						{
							if(button != InputLimitButton.LobbyScene)
							{
								MenuScene.Instance.LobbyButtonControl.EnableButton(true);
							}
						}
					}
					if(MenuScene.Instance != null)
					{
						if(MenuScene.Instance.HelpButton != null)
						{
							MenuScene.Instance.HelpButton.SetEnable();
						}
					}
					if(button == InputLimitButton.PopupPositiveButton)
					{
						buttonBase.IsInputOff = true;
					}
					buttonBase.RemoveOnClickCallback(onClickEvent);
				};
				buttonBase.AddOnClickCallback(onClickEvent);
			}
		}

		// // RVA: 0xE409E4 Offset: 0xE409E4 VA: 0xE409E4
		private bool ObjectFindFunc(Transform ts, string name, string parentName)
		{
			if(ts.name == name)
			{
				if(!string.IsNullOrEmpty(parentName))
				{
					if(ts.parent.name == parentName)
						return true;
				}
				else
				{
					return true;
				}
			}
			return false;
		}

		// // RVA: 0xE40AD4 Offset: 0xE40AD4 VA: 0xE40AD4
		public void ShowCursor(CursorPosition positionType)
		{
			if (m_cursorInstance == null)
				return;
			Transform t = GameManager.Instance.PopupCanvas.transform.Find("Root");
			m_pointer.RectTransform.anchorMax = new Vector2(0.5f, 0.5f);
			m_pointer.RectTransform.anchorMin = new Vector2(0.5f, 0.5f);
			LayoutUGUIHitOnly l = null;
			TutorialPointer.Direction dir = TutorialPointer.Direction.Normal;
			Vector2 anchor = new Vector2(0.5f, 0.5f);
			Vector2 pos = new Vector2(0, 0);
			if (positionType == CursorPosition.MissionMenuButton)
			{
				l = MenuScene.Instance.FooterMenu.FindButton(MenuFooterControl.Button.Mission).GetComponentInChildren<LayoutUGUIHitOnly>(true);
				dir = TutorialPointer.Direction.Down;
			}
			else if(positionType == CursorPosition.ActiveSkill)
			{
				pos = new Vector2(t.localScale.x * 0, (t.localPosition.y * 2 + 56) * t.localScale.y);
				anchor = new Vector2(0.5f, 0);
			}
			else if(positionType == CursorPosition.RhythmAdjust)
			{
				pos = new Vector2(t.localScale.x * 300, (t.localPosition.y * 2 - 200) * t.localScale.y);
				if(SystemManager.isLongScreenDevice)
				{
					pos.y -= t.localPosition.y;
				}
			}
			m_cursorInstance.SetActive(true);
			m_cursorInstance.transform.SetAsFirstSibling();
			if(l != null)
			{
				SetCursorPosition(l.transform as RectTransform, dir);
			}
			else
			{
				m_pointer.RectTransform.anchorMax = anchor;
				m_pointer.RectTransform.anchorMin = anchor;
				m_pointer.ShowAnchorPosition(pos, dir);
			}
		}

		// // RVA: 0xE413B4 Offset: 0xE413B4 VA: 0xE413B4
		public void HideCursor()
		{
			if (m_cursorInstance == null)
				return;
			m_cursorInstance.SetActive(false);
		}

		// // RVA: 0xE4146C Offset: 0xE4146C VA: 0xE4146C
		public void ChangeCursorLastSibling()
		{
			if (m_cursorInstance == null)
				return;
			m_cursorInstance.transform.SetAsLastSibling();
		}

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
					f = SystemManager.rawSafeAreaRect.height / SystemManager.rawScreenAreaRect.height;
				}
				Vector2 v1 = new Vector2(t1.sizeDelta.x * offset.x, t1.sizeDelta.y * offset.y);
				Vector2 v3 = v2 + v1;
				Vector2 v4 = new Vector2(f * t1.sizeDelta.x * scale.x, f * t1.sizeDelta.y * scale.y);
				m_highLight.HighLightRect = new Rect(v3, v4);
			}
		}

		// // RVA: 0xE3FF5C Offset: 0xE3FF5C VA: 0xE3FF5C
		private void SetRect(RectTransform rt, Vector2 offset, Vector2 scale)
		{
			if(m_blackImageInstance != null)
			{
				Canvas c = rt.GetComponentInParent<Canvas>();
				Canvas c2 = m_blackImageInstance.GetComponentInParent<Canvas>();
				Vector2 v3;
				Vector2 v4 = RectTransformUtility.WorldToScreenPoint(c.rootCanvas.worldCamera, rt.transform.position);
				RectTransformUtility.ScreenPointToLocalPointInRectangle(c2.transform as RectTransform, v4, c2.worldCamera, out v3);
				float f1 = 1;
				if(SystemManager.isLongScreenDevice)
					f1 = SystemManager.rawSafeAreaRect.height / SystemManager.rawScreenAreaRect.height;
				Vector2 v1 = v3 + rt.sizeDelta * offset;
				Vector2 v2 = new Vector2(f1 * rt.sizeDelta.x * rt.localScale.x * scale.x, f1 * rt.sizeDelta.y * rt.localScale.y * scale.y);
				//UnityEngine.Debug.LogError(rt.gameObject.name+" "+new Rect(v1, v2)+" "+rt.localScale+" "+rt.sizeDelta+" "+f1+" "+scale);
				m_highLight.HighLightRect = new Rect(v1, v2);
			}
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
		public void UpdateLocalPlayerData()
		{
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.LFNEPDFBINM(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave);
		}

		// // RVA: 0xE419D0 Offset: 0xE419D0 VA: 0xE419D0
		public void UpdateRecoveryPoint(ILDKBCLAFPB.CDIPJNPICCO_RecoveryPoint rPoint)
		{
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.DGMFOHADMHN(rPoint);
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
		}

		// // RVA: 0xE41B10 Offset: 0xE41B10 VA: 0xE41B10
		public void SaveMusicResult()
		{
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.AHEFHIMGIBI_PlayerData.EJFNMIFOFME(JGEOBNENMAH.HHCJCDFCLOB, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, Database.Instance.gameSetup, Database.Instance.gameResult);
			UpdateLocalPlayerData();
			UpdateRecoveryPoint(ILDKBCLAFPB.CDIPJNPICCO_RecoveryPoint.KIDJFNEGAHO_7_ToMusicResult);
		}

		// // RVA: 0xE41D24 Offset: 0xE41D24 VA: 0xE41D24
		public ILDKBCLAFPB.CDIPJNPICCO_RecoveryPoint GetRecoveryPoint()
		{
			return GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.KMKIGHHCAGE();
		}

		// // RVA: 0xE41E18 Offset: 0xE41E18 VA: 0xE41E18
		public JGEOBNENMAH.EDHCNKBMLGI SetupTutorialGame(TutorialGameMode.Type type)
		{
			StatusData status1 = new StatusData();
			StatusData status2 = new StatusData();
			Database.Instance.gameSetup.musicInfo.SetupInfoByTutorial(type);
			AEGLGBOGDHH a = new AEGLGBOGDHH();
			a.OBKGEDCKHHE();
			IBJAKJJICBC ib = new IBJAKJJICBC();
			ib.KHEKNNFCAOI(Database.Instance.gameSetup.musicInfo.freeMusicId, false, 0, 0, 0, false, false, false);
			CMMKCEPBIHI.DIDENKKDJKI(ref a, GameManager.Instance.ViewPlayerData.NPFCMHCCDDH, GameManager.Instance.ViewPlayerData, ib, null, ib.MGJKEJHEBPO_DiffInfos[0].HPBPDHPIBGN_EnemyData);
			a.GEEDEOHGMOM(ref status1);
			status2.Clear();
			status2.Copy(GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.CMCKNKKCNDK_GoDivaStatus);
			status2.Add(status1);
			Database.Instance.gameSetup.teamInfo.SetupInfo(status2, GameManager.Instance.ViewPlayerData, 0, ib, null, null, null, false);
			JGEOBNENMAH.EDHCNKBMLGI res = new JGEOBNENMAH.EDHCNKBMLGI();
			res.GHBPLHBNMBK_FreeMusicId = Database.Instance.gameSetup.musicInfo.freeMusicId;
			res.KLCIIHKFPPO_StoryMusicId = Database.Instance.gameSetup.musicInfo.storyMusicId;
			res.AKNELONELJK_Difficulty = (int)Database.Instance.gameSetup.musicInfo.difficultyType;
			res.OALJNDABDHK = GameManager.Instance.ViewPlayerData.NPFCMHCCDDH;
			res.NHPGGBCKLHC_FriendData = null;
			res.KAIPAEILJHO_TicketCount = 0;
			res.PMCGHPOGLGM_IsSkip = false;
			res.MNNHHJBBICA_GameEventType = 0;
			res.MFJKNCACBDG_OpenEventType = 0;
			res.OEILJHENAHN_PlayEventType = 0;
			res.JPJMALBLKDI_Tutorial = 1;
			int luck = 0;
			for(int i = 0; i < GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas.Count; i++)
			{
				luck += DivaIconDecoration.GetEquipmentLuck(GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[i], GameManager.Instance.ViewPlayerData);
			}
			StatusData status = new StatusData();
			status.Clear();
			a.DIJOPLHIMBO(res.ENMGODCHGAC_Log, GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.JLJGCBOHJID_Status, status, luck, 0);
			return res;
		}

		// // RVA: 0xE42544 Offset: 0xE42544 VA: 0xE42544
		public static bool IsBeginnerMission()
		{
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.IJHBIMNKOMC_TutorialEnd < 2;
		}
	}
}
