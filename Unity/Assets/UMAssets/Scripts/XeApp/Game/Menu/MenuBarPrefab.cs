using XeSys.Gfx;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;
using XeApp.Core;
using XeApp.Game.Common;
using mcrs;

namespace XeApp.Game.Menu
{
	public class MenuBarPrefab : LayoutUGUIScriptBase
	{
		[SerializeField]
		private List<MenuButtonAnim> mMenuButtons; // 0x14
		private LayoutUGUIRuntime mMainRuntime; // 0x18
		private AbsoluteLayout mRootAnimeAbs; // 0x1C
		private MenuBarBadge[] m_badge; // 0x20
		private AbsoluteLayout[] m_badgeParentLayout; // 0x24
		private GameObject[] m_badgeParentObject; // 0x28
		private bool is_button_click = true; // 0x2C
		private bool is_enter; // 0x2D

		public bool IsEnter { get { return is_enter; } }// 0xEC38C0
		private Func<TransitionList.Type, bool> OnInterruptEvent { get; set; } // 0x30

		// RVA: 0xEC38D8 Offset: 0xEC38D8 VA: 0xEC38D8
		private void Start()
		{
			mMainRuntime = GetComponent<LayoutUGUIRuntime>();
		}

		// // RVA: 0xEC3940 Offset: 0xEC3940 VA: 0xEC3940
		public void Initialize()
		{
			for(int i = 0; i < m_badge.Length; i++)
			{
				m_badge[i].Initialize(m_badgeParentObject[i], m_badgeParentLayout[i]);
			}
		}

		// // RVA: 0xEC3A48 Offset: 0xEC3A48 VA: 0xEC3A48
		// public void Release() { }

		// // RVA: 0xEC3A4C Offset: 0xEC3A4C VA: 0xEC3A4C
		public void Enter(bool isEnd, MenuButtonAnim.ButtonType selectedButton)
		{
			if(!IsEnter)
			{
				Enter(isEnd);
			}
			if(selectedButton != MenuButtonAnim.ButtonType.NONE)
			{
				ChangeNotSelectBaseButtonAll();
				ChangeButtonSelect(selectedButton);
			}
		}

		// // RVA: 0xEC3A8C Offset: 0xEC3A8C VA: 0xEC3A8C
		public void Enter(bool isEnd)
		{
			if(IsEnter)
				return;
			mMainRuntime.Layout.StartAllAnimGoStop(isEnd ? "st_in" : "go_in", "st_in");
			is_enter = true;
		}

		// // RVA: 0xEC3CE8 Offset: 0xEC3CE8 VA: 0xEC3CE8
		public void Leave(bool isEnd)
		{
			if(!is_enter)
				return;
			mMainRuntime.Layout.StartAllAnimGoStop(isEnd ? "st_out" : "go_out", "st_out");
			is_enter = false;
		}

		// // RVA: 0xEC3DD0 Offset: 0xEC3DD0 VA: 0xEC3DD0
		// public bool IsButtonClick() { }

		// // RVA: 0xEC3DD8 Offset: 0xEC3DD8 VA: 0xEC3DD8
		// public void OnButtonClick() { }

		// // RVA: 0xEC3DE4 Offset: 0xEC3DE4 VA: 0xEC3DE4
		public void SetButtonClick(bool flag)
		{
			is_button_click = flag;
		}

		// // RVA: 0xEC3C4C Offset: 0xEC3C4C VA: 0xEC3C4C
		public void ChangeButtonSelect(MenuButtonAnim.ButtonType type)
		{
			mMenuButtons[(int)type].ChangeSelectBaseButton();
		}

		// // RVA: 0xEC3E34 Offset: 0xEC3E34 VA: 0xEC3E34
		// public void ChangeButtonNone(MenuButtonAnim.ButtonType type) { }

		// // RVA: 0xEC3B74 Offset: 0xEC3B74 VA: 0xEC3B74
		public void ChangeNotSelectBaseButtonAll()
		{
			for(int i = 0; i < mMenuButtons.Count; i++)
			{
				mMenuButtons[i].ChangeNotSelectBaseButton();
			}
		}

		// // RVA: 0xEC3FA8 Offset: 0xEC3FA8 VA: 0xEC3FA8
		public void SetButtonBadge(MenuButtonAnim.ButtonType buttonType, BadgeConstant.ID badgeId, string text)
		{
			m_badge[(int)buttonType].Set(badgeId, text);
		}

		// // RVA: 0xEC4018 Offset: 0xEC4018 VA: 0xEC4018
		// public void SetCallBack(ButtonBase.OnClickCallback callback, MenuButtonAnim.ButtonType type) { }

		// // RVA: 0xEC40C0 Offset: 0xEC40C0 VA: 0xEC40C0
		public void SetCallBackALLDefalt()
		{
			ButtonBase.OnClickCallback[] callbacks = new ButtonBase.OnClickCallback[8];
			callbacks[0] = this.CallBackHome;
			callbacks[1] = this.CallBackSetting;
			callbacks[2] = this.CallBackVOP;
			callbacks[3] = this.CallBackFreeBattle;
			callbacks[4] = this.CallBackGacha;
			callbacks[5] = this.CallBackQuest;
			callbacks[6] = this.CallBackMenu;
			callbacks[7] = this.CallBackBack;
			for(int i = 0; i < mMenuButtons.Count; i++)
			{
				mMenuButtons[i].AddOnClickCallback(callbacks[i]);
			}
		}

		// // RVA: 0xEC464C Offset: 0xEC464C VA: 0xEC464C
		private bool IsTopLevelScene(SceneGroupCategory category, TransitionList.Type transitionName)
		{
			if(MenuScene.Instance.GetCurrentScene().name == transitionName)
				return MenuScene.Instance.GetCurrentScene().groupCategory != category;
			return true;
		}

		// // RVA: 0xEC4728 Offset: 0xEC4728 VA: 0xEC4728
		// public bool IsPlaying() { }

		// // RVA: 0xEC478C Offset: 0xEC478C VA: 0xEC478C
		private void CallBackHome()
		{
			if (OnInterruptEvent != null && OnInterruptEvent(TransitionList.Type.HOME))
			{
				mMenuButtons[0].buttonAnimeDisable = true;
				return;
			}
			mMenuButtons[0].buttonAnimeDisable = false;
			int cueId = 6;
			if(IsTopLevelScene(SceneGroupCategory.HOME, TransitionList.Type.HOME))
			{
				cueId = 0;
				MenuScene.Instance.Mount(TransitionUniqueId.HOME, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
			}
			SoundManager.Instance.sePlayerBoot.Play(cueId);
		}

		// // RVA: 0xEC4980 Offset: 0xEC4980 VA: 0xEC4980
		private void CallBackSetting()
		{
			if(OnInterruptEvent != null && OnInterruptEvent(TransitionList.Type.SETTING_MENU))
			{
				mMenuButtons[1].buttonAnimeDisable = true;
				return;
			}
			mMenuButtons[1].buttonAnimeDisable = false;
			int cueId = 6;
			if(IsTopLevelScene(SceneGroupCategory.FORMATION, TransitionList.Type.SETTING_MENU))
			{
				MenuScene.Instance.Mount(TransitionUniqueId.SETTINGMENU, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
				cueId = 0;
				MenuScene.Instance.StatusWindowControl.ResetHistory();
			}
			SoundManager.Instance.sePlayerBoot.Play(cueId);
		}

		// // RVA: 0xEC4BB8 Offset: 0xEC4BB8 VA: 0xEC4BB8
		private void CallBackVOP()
		{
			if(OnInterruptEvent != null && OnInterruptEvent(TransitionList.Type.OFFER_SELECT))
			{
				mMenuButtons[2].buttonAnimeDisable = true;
				return;
			}
			mMenuButtons[2].buttonAnimeDisable = false;
			int cueId = 0;
			if(!MenuScene.CheckDatelineAndAssetUpdate())
			{
				if(!CheckFirstAdvVOP())
				{
					cueId = 6;
					if (IsTopLevelScene(SceneGroupCategory.VOP, TransitionList.Type.OFFER_SELECT))
					{
						MenuScene.Instance.Mount(TransitionUniqueId.OFFERSELECT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
						GameManager.Instance.SelectedGuestData = null;
						cueId = 0;
						MenuScene.Instance.StatusWindowControl.ResetHistory();
					}
				}
			}
			SoundManager.Instance.sePlayerBoot.Play(cueId);
		}

		// // RVA: 0xEC4E90 Offset: 0xEC4E90 VA: 0xEC4E90
		private bool CheckFirstAdvVOP()
		{
			if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.MLBBKNLPBBD_HasShowTuto(BOPFPIHGJMD.PDLKAKEABDP.EILIAPKFCEO_0))
			{
				int advId = 88;
				if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
					advId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.LPJLEHAJADA("first_adv_id", 88);
				GPMHOAKFALE_Adventure.NGDBKCKMDHE_AdventureData adv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EFMAIKAHFEK_Adventure.GCINIJEMHFK_GetAdventure(advId);
				if(adv == null)
				{
					IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EFMAIKAHFEK_Adventure.GCINIJEMHFK_GetAdventure(1);
				}
				else
				{
					Database.Instance.advResult.Setup("Menu", TransitionUniqueId.OFFERSELECT, new AdvSetupParam());
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.GFANLIOMMNA_SetReleased(advId);
					Database.Instance.advSetup.Setup(adv.KKPPFAHFOJI_FileId);
					MenuScene.Instance.GotoAdventure(true);
					ILCCJNDFFOB.HHCJCDFCLOB.BKLNHBHDDEJ(JpStringLiterals.StringLiteral_16417);
					return true;
				}
			}
			return false;
		}

		// // RVA: 0xEC53A4 Offset: 0xEC53A4 VA: 0xEC53A4
		private void CallBackFreeBattle()
		{
			if(OnInterruptEvent != null && OnInterruptEvent(TransitionList.Type.MUSIC_SELECT))
			{
				mMenuButtons[3].buttonAnimeDisable = true;
				return;
			}
			mMenuButtons[3].buttonAnimeDisable = false;
			int cueId = (int)cs_se_boot.SE_BTN_005;
			if(IsTopLevelScene(SceneGroupCategory.FREE, TransitionList.Type.MUSIC_SELECT))
			{
				MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, null, true, 0);
				MenuScene.Instance.StatusWindowControl.ResetHistory();
				cueId = (int)cs_se_boot.SE_BTN_000;
			}
			SoundManager.Instance.sePlayerBoot.Play(cueId);
		}

		// // RVA: 0xEC55DC Offset: 0xEC55DC VA: 0xEC55DC
		private void CallBackGacha()
		{
			if(OnInterruptEvent != null && OnInterruptEvent(TransitionList.Type.GACHA_2))
			{
				mMenuButtons[4].buttonAnimeDisable = true;
				return;
			}
			mMenuButtons[4].buttonAnimeDisable = false;
			int cueId = (int)cs_se_boot.SE_BTN_005;
			if (IsTopLevelScene(SceneGroupCategory.GACHA, TransitionList.Type.GACHA_2))
			{
				MenuScene.Instance.Mount(TransitionUniqueId.GACHA2, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
				cueId = (int)cs_se_boot.SE_BTN_000;
				MenuScene.Instance.StatusWindowControl.ResetHistory();
			}
			SoundManager.Instance.sePlayerBoot.Play(cueId);
		}

		// // RVA: 0xEC5818 Offset: 0xEC5818 VA: 0xEC5818
		private void CallBackQuest()
		{
			if(OnInterruptEvent != null && OnInterruptEvent(TransitionList.Type.QUEST))
			{
				mMenuButtons[5].buttonAnimeDisable = true;
				return;
			}
			mMenuButtons[5].buttonAnimeDisable = false;
			int cueId = (int)cs_se_boot.SE_BTN_005;
			if (IsTopLevelScene(SceneGroupCategory.QUEST, TransitionList.Type.QUEST))
			{
				MenuScene.Instance.Mount(TransitionUniqueId.QUEST, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
				cueId = (int)cs_se_boot.SE_BTN_000;
				MenuScene.Instance.StatusWindowControl.ResetHistory();
			}
			SoundManager.Instance.sePlayerBoot.Play(cueId);
		}

		// // RVA: 0xEC5A50 Offset: 0xEC5A50 VA: 0xEC5A50
		private void CallBackMenu()
		{
			if(OnInterruptEvent != null && OnInterruptEvent(TransitionList.Type.OPTION_MENU))
			{
				mMenuButtons[6].buttonAnimeDisable = true;
				return;
			}
			mMenuButtons[6].buttonAnimeDisable = false;
			int cueId = (int)cs_se_boot.SE_BTN_005;
			if (IsTopLevelScene(SceneGroupCategory.OPTION, TransitionList.Type.OPTION_MENU))
			{
				MenuScene.Instance.Mount(TransitionUniqueId.OPTIONMENU, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
				cueId = (int)cs_se_boot.SE_BTN_000;
				MenuScene.Instance.StatusWindowControl.ResetHistory();
			}
			SoundManager.Instance.sePlayerBoot.Play(cueId);
		}

		// // RVA: 0xEC5C88 Offset: 0xEC5C88 VA: 0xEC5C88
		private void CallBackBack()
		{
			return;
		}

		// // RVA: 0xEC5C8C Offset: 0xEC5C8C VA: 0xEC5C8C
		public void SetInterruptEvent(Func<TransitionList.Type, bool> callback)
		{
			OnInterruptEvent = callback;
			for(int i = 0; i < mMenuButtons.Count; i++)
			{
				mMenuButtons[i].buttonAnimeDisable = false;
			}
		}

		// // RVA: 0xEC5D74 Offset: 0xEC5D74 VA: 0xEC5D74
		public void PerformHomeClick()
		{
			mMenuButtons[0].PerformClick();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CC6E4 Offset: 0x6CC6E4 VA: 0x6CC6E4
		// // RVA: 0xEC5E10 Offset: 0xEC5E10 VA: 0xEC5E10
		public static IEnumerator Load(Transform parent, XeSys.FontInfo font, Action<MenuBarPrefab> callback)
		{
			//0xEC6788
			MenuBarPrefab menuPrefab = null;
			int loadAssetBundle = 0;
			AssetBundleLoadLayoutOperationBase operation = AssetBundleManager.LoadLayoutAsync("ly/005.xab", "UI_MenuBar");
			yield return Co.R(operation);
			yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) => {
				//0xEC6584
				instance.transform.SetParent(parent, false);
				menuPrefab = instance.GetComponent<MenuBarPrefab>();
			}));
			loadAssetBundle++;
			while(!menuPrefab.IsLoaded())
				yield return null;
			MenuBarBadge menuBadge = null;
			operation = AssetBundleManager.LoadLayoutAsync("ly/005.xab", "root_menu_badge_layout_root");
			yield return Co.R(operation);
			yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) => {
				//0xEC6648
				menuBadge = instance.GetComponent<MenuBarBadge>();
				instance.SetActive(false);
				menuPrefab.m_badge[0] = menuBadge;
			}));
			loadAssetBundle++;
			for(int i = 0; i < menuPrefab.m_badge.Length; i++)
			{
				MenuBarBadge barBadge = UnityEngine.Object.Instantiate<MenuBarBadge>(menuBadge);
				barBadge.runtime.IsLayoutAutoLoad = false;
				barBadge.runtime.Layout = menuBadge.runtime.Layout.DeepClone();
				barBadge.runtime.UvMan = menuBadge.runtime.UvMan;
				barBadge.runtime.LoadLayout();
				menuPrefab.m_badge[i] = barBadge; // ??
			}
			for(int i = 0; i < loadAssetBundle; i++)
			{
				AssetBundleManager.UnloadAssetBundle("ly/005.xab", false);
			}
			if(callback != null)
			{
				callback(menuPrefab);
			}
		}

		// RVA: 0xEC5EF0 Offset: 0xEC5EF0 VA: 0xEC5EF0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			mRootAnimeAbs = mMainRuntime.Layout.FindViewByExId("sw_menu_btn_all_anim_button") as AbsoluteLayout;
			RectTransform[] rects = Array.FindAll<RectTransform>(transform.GetComponentsInChildren<RectTransform>(true), (RectTransform x) => {
				//0xEC64E4
				return x.name.Contains("badge_");
			});
			LayoutUGUIRuntime runtimeParent = GetComponentInParent<LayoutUGUIRuntime>();

			m_badge = new MenuBarBadge[rects.Length];
			m_badgeParentLayout = new AbsoluteLayout[rects.Length];
			m_badgeParentObject = new GameObject[rects.Length];
			for(int i = 0; i < rects.Length; i++)
			{
				AbsoluteLayout al = layout.FindViewByExId(string.Format("sw_menu_btn_all_badge_{0}", i+1)) as AbsoluteLayout;
				m_badgeParentLayout[i] = al;
				m_badgeParentObject[i] = runtimeParent.FindRectTransform(al).gameObject;
			}
			SetCallBackALLDefalt();
			Loaded();
			return true;
		}
	}
}
