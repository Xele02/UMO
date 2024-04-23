using mcrs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class OptionMenuScene : TransitionRoot
	{
		public class OptionMenuArgs : TransitionArgs
		{
			public bool openConfig; // 0x8
			public bool openSnsLink; // 0x9
		}
		
		private LayoutUGUIRuntime m_runtime; // 0x48
		private OptionMenuArgs optionMenuArgs; // 0x4C
		private PopupWindowControl popupWindowControl; // 0x50
		private float forceScrollChangeValue = -1; // 0x54
		private OptionMenuLayout m_option_anim; // 0x58
		private InheritingMenu m_inheritingMenu; // 0x5C
		private ConfigMenu m_configMenu; // 0x60
		private EventStoryWindowLayout m_storyEventLayout; // 0x64
		private List<EventStoryBannerListContent> m_eventListContent = new List<EventStoryBannerListContent>(); // 0x68
		private List<EventStoryBannerListContent> m_plateStoryListContent = new List<EventStoryBannerListContent>(); // 0x6C
		private DownloadCancelButton m_bunchInstallCancelButton; // 0x70
		private AccountManagementWindow m_accountManagementWindow; // 0x74
		private AccountAgreeWindow m_accountAgreeWindow; // 0x78
		private AccountConfirmWindow m_accountConfirmWindow; // 0x7C
		private AccountRemoveTextWindow m_accountRemoveTextWindow; // 0x80
		private bool m_isLoadedAccountLayout; // 0x84

		// RVA: 0xDD6C08 Offset: 0xDD6C08 VA: 0xDD6C08 Slot: 5
		protected override void Start()
		{
			m_runtime = GetComponent<LayoutUGUIRuntime>();
			this.StartCoroutineWatched(WaitLayout());
			m_option_anim = transform.GetComponent<OptionMenuLayout>();
			m_configMenu = ConfigMenu.Create(transform.parent);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FDD34 Offset: 0x6FDD34 VA: 0x6FDD34
		//// RVA: 0xDD6CFC Offset: 0xDD6CFC VA: 0xDD6CFC
		private IEnumerator WaitLayout()
		{
			string bundleName;

			//0xDE00AC
			while(!m_runtime.IsReady)
				yield return null;
			if(!AppEnv.IsCBT() && !AppEnv.IsPresentation())
			{
				OptionMenuLayout.ButtonLabel[] btns = new OptionMenuLayout.ButtonLabel[16]
				{
					OptionMenuLayout.ButtonLabel.SHOP,
					OptionMenuLayout.ButtonLabel.ITEM,
					OptionMenuLayout.ButtonLabel.PROFILE,
					OptionMenuLayout.ButtonLabel.HONORARY,
					OptionMenuLayout.ButtonLabel.EVENT_REVIEW,
					OptionMenuLayout.ButtonLabel.CONFIG,
					OptionMenuLayout.ButtonLabel.HELP,
					OptionMenuLayout.ButtonLabel.RANKING,
					OptionMenuLayout.ButtonLabel.CACHE_CLEAR,
					OptionMenuLayout.ButtonLabel.TAKEOVER_DATA,
					OptionMenuLayout.ButtonLabel.LINK,
					OptionMenuLayout.ButtonLabel.BALANCE,
					OptionMenuLayout.ButtonLabel.OPINION,
					OptionMenuLayout.ButtonLabel.CONTACT,
					OptionMenuLayout.ButtonLabel.TITLE,
					OptionMenuLayout.ButtonLabel.BLOCKLIST,
				};
				ButtonBase.OnClickCallback[] cbs = new ButtonBase.OnClickCallback[16]
				{
					OnClickShop,
					OnClickItem,
					OnClickProfile,
					OnClickHonorary,
					OnClickConfig,
					OnClickHelp,
					OnClickRanking,
					OnClickDataManagement,
					OnClickTakeOverData,
					OnClickLink,
					OnClickBalance,
					OnClickOpinion,
					OnClickContact,
					OnClickTitle,
					OnEventReview,
					OnClickBlockList
				};
				for(int i = 0; i < 16; i++)
				{
					m_option_anim.SetButtonEnable(i, true);
					m_option_anim.SetButtonLabel(i, btns[i]);
					m_option_anim.AddButtonClickEvent(i, cbs[i]);
					m_option_anim.AddButtonClickEvent(i, () =>
					{
						//0xDD9BD4
						SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					});
				}
			}
			else
			{
				OptionMenuLayout.ButtonLabel[] btns = new OptionMenuLayout.ButtonLabel[16]
				{
					OptionMenuLayout.ButtonLabel.SHOP,
					OptionMenuLayout.ButtonLabel.ITEM,
					OptionMenuLayout.ButtonLabel.PROFILE,
					OptionMenuLayout.ButtonLabel.HONORARY,
					OptionMenuLayout.ButtonLabel.EVENT_REVIEW,
					OptionMenuLayout.ButtonLabel.CONFIG,
					OptionMenuLayout.ButtonLabel.HELP,
					OptionMenuLayout.ButtonLabel.RANKING,
					OptionMenuLayout.ButtonLabel.CACHE_CLEAR,
					OptionMenuLayout.ButtonLabel.TAKEOVER_DATA,
					OptionMenuLayout.ButtonLabel.LINK,
					OptionMenuLayout.ButtonLabel.BALANCE,
					OptionMenuLayout.ButtonLabel.OPINION,
					OptionMenuLayout.ButtonLabel.CONTACT,
					OptionMenuLayout.ButtonLabel.TITLE,
					OptionMenuLayout.ButtonLabel.BLOCKLIST,
				};
				ButtonBase.OnClickCallback[] cbs = new ButtonBase.OnClickCallback[16]
				{
					OnClickShop,
					OnClickItem,
					OnClickProfile,
					OnClickHonorary,
					OnClickConfig,
					OnClickHelp,
					OnClickRanking,
					OnClickDataManagement,
					OnClickTakeOverData,
					OnClickLink,
					OnClickBalance,
					OnClickOpinion,
					OnClickContact,
					OnClickTitle,
					OnEventReview,
					OnClickBlockList
				};
				for(int i = 0; i < 16; i++)
				{
					m_option_anim.SetButtonEnable(i, true);
					m_option_anim.SetButtonLabel(i, btns[i]);
					m_option_anim.AddButtonClickEvent(i, cbs[i]);
					m_option_anim.AddButtonClickEvent(i, () =>
					{
						//0xDD9B7C
						SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					});
				}
			}
			//LAB_00de1d2c;
			if(!IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.MDECFOOCLHG_IsBlockListEnabled())
			{
				m_option_anim.SetButtonEnable(15, false);
			}
			m_inheritingMenu = InheritingMenu.Create(transform);
			bundleName = "ly/121.xab";
			yield return AssetBundleManager.LoadUnionAssetBundle(bundleName);
			yield return Co.R(Co_LoadAssetsLayoutEventStoryWindow(bundleName, GameManager.Instance.GetSystemFont()));
			yield return Co.R(Co_LoadAssetsLayoutPresentListItem(bundleName, GameManager.Instance.GetSystemFont()));
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			while (m_storyEventLayout == null)
				yield return null;
			while (!m_storyEventLayout.IsLoaded())
				yield return null;
			while (m_storyEventLayout.List.ScrollObjects.Count < 1)
				yield return null;
			m_storyEventLayout.InitEvStWindow(null);
			m_storyEventLayout.Hide();
			m_storyEventLayout.SetRoot(transform);
			m_storyEventLayout.ChangeTablistener += ChangeTabLayout;
			bundleName = "ly/009.xab";
			yield return AssetBundleManager.LoadUnionAssetBundle(bundleName);
			yield return Co.R(Co_LoadAssetsLayoutDownloadCancelButton(bundleName, GameManager.Instance.GetSystemFont()));
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			m_bunchInstallCancelButton.OnClickCancelButton = null;
			m_bunchInstallCancelButton.gameObject.SetActive(false);
			m_bunchInstallCancelButton.transform.SetParent(transform, false);
			IsReady = true;
		}

		//// RVA: 0xDD6DA8 Offset: 0xDD6DA8 VA: 0xDD6DA8
		private void ChangeTabLayout(EventStoryWindowLayout.Series arg0)
		{
			return;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FDDAC Offset: 0x6FDDAC VA: 0x6FDDAC
		//// RVA: 0xDD6DAC Offset: 0xDD6DAC VA: 0xDD6DAC
		private IEnumerator Co_LoadAssetsLayoutEventStoryWindow(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0xDDDEA8
			if(m_storyEventLayout == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_pop_eve_story_window_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0xDD941C
					instance.transform.SetParent(transform, false);
					m_storyEventLayout = instance.GetComponent<EventStoryWindowLayout>();
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				operation = null;
			}
			else
			{
				m_storyEventLayout.transform.SetParent(transform, false);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FDE24 Offset: 0x6FDE24 VA: 0x6FDE24
		//// RVA: 0xDD6E8C Offset: 0xDD6E8C VA: 0xDD6E8C
		private IEnumerator Co_LoadAssetsLayoutPresentListItem(string bundleName, Font font)
		{
			int loadCount; // 0x20
			AssetBundleLoadLayoutOperationBase operation; // 0x24
			int i; // 0x28

			//0xDDE1BC
			loadCount = 0;
			if (m_eventListContent.Count < 1)
			{
				loadCount++;
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sw_p_e_s_btn_bnr_layout_root");
				LayoutUGUIRuntime baseRuntime = null;
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0xDDA21C
					baseRuntime = instance.GetComponent<LayoutUGUIRuntime>();
					baseRuntime.name = baseRuntime.name.Replace("(Clone)", "_00");
					instance.transform.SetParent(transform, false);
					m_eventListContent.Add(instance.GetComponent<EventStoryBannerListContent>());
				}));
				for(i = 1; i < m_storyEventLayout.List.ScrollObjectCount; i++)
				{
					LayoutUGUIRuntime r = Instantiate(baseRuntime);
					r.name = baseRuntime.name.Replace("00", i.ToString("D2"));
					r.IsLayoutAutoLoad = false;
					r.Layout = baseRuntime.Layout.DeepClone();
					r.UvMan = baseRuntime.UvMan;
					r.transform.SetParent(transform, false);
					r.LoadLayout();
					m_eventListContent.Add(r.GetComponent<EventStoryBannerListContent>());
				}
				operation = null;
			}
			for(i = 0; i < loadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
			}
			for(i = 0; i < m_eventListContent.Count; i++)
			{
				while(!m_eventListContent[i].IsLoaded())
					yield return null;
				m_storyEventLayout.List.AddScrollObject(m_eventListContent[i]);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FDE9C Offset: 0x6FDE9C VA: 0x6FDE9C
		//// RVA: 0xDD6F6C Offset: 0xDD6F6C VA: 0xDD6F6C
		private IEnumerator Co_LoadAssetsLayoutDownloadCancelButton(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0xDDDBBC
			if(m_bunchInstallCancelButton == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, DownloadCancelButton.AssetName);
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0xDD94EC
					instance.transform.SetParent(transform, false);
					m_bunchInstallCancelButton = instance.GetComponent<DownloadCancelButton>();
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				operation = null;
			}
		}

		// RVA: 0xDD704C Offset: 0xDD704C VA: 0xDD704C Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			if(m_option_anim.IsLoaded())
			{
				if(AppEnv.IsCBT())
				{
					m_option_anim.RemoveButtonClickEvent(9);
					m_option_anim.ButtonDarkEnable(9, true);
				}
				m_option_anim.Enter();
				return true;
			}
			return false;
		}

		// RVA: 0xDD7168 Offset: 0xDD7168 VA: 0xDD7168 Slot: 16
		protected override void OnPreSetCanvas()
		{
			optionMenuArgs = Args as OptionMenuArgs;
			m_option_anim.InitializeBadge();
			List<AODFBGCCBPE> l = AODFBGCCBPE.FKDIMODKKJD(false);
			int total = 0;
			for(int i = 0; i < l.Count; i++)
			{
				total += l[i].CADENLBDAEB ? 1 : 0;
			}
			m_option_anim.SetBadge(0, total > 0 ? BadgeConstant.ID.Menu_ShopCheck : BadgeConstant.ID.None);
			BadgeConstant.ID id = NKGJPJPHLIF.HHCJCDFCLOB.AFJEOKGBCNA_NumReplies > 0 ? BadgeConstant.ID.Menu_ResvMsg : BadgeConstant.ID.None;
			if(AppEnv.IsCBT())
			{
				m_option_anim.SetBadge(13, id);
			}
			else
			{
				m_option_anim.SetBadge(12, id);
			}
			m_option_anim.SetBadge(14, DKKPBBBDKMJ.CADENLBDAEB() ? BadgeConstant.ID.Menu_NewFuncAdd : BadgeConstant.ID.None);
		}

		// RVA: 0xDD7410 Offset: 0xDD7410 VA: 0xDD7410 Slot: 12
		protected override void OnStartExitAnimation()
		{
			base.OnStartExitAnimation();
			m_option_anim.Leave();
		}

		// RVA: 0xDD7444 Offset: 0xDD7444 VA: 0xDD7444 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_option_anim.IsPlaying();
		}

		// RVA: 0xDD7470 Offset: 0xDD7470 VA: 0xDD7470 Slot: 21
		protected override void OnOpenScene()
		{
			if(optionMenuArgs != null)
			{
				if(optionMenuArgs.openConfig)
				{
					m_configMenu.ShowPopupConfig(null, null);
					return;
				}
				if(optionMenuArgs.openSnsLink)
				{
					MenuScene.Instance.InputDisable();
					m_inheritingMenu.PopupShowMenu(true, () =>
					{
						//0xDD9C2C
						return;
					}, () =>
					{
						//0xDD9C30
						MenuScene.Instance.InputEnable();
					}, null);
				}
			}
		}

		// RVA: 0xDD7730 Offset: 0xDD7730 VA: 0xDD7730 Slot: 23
		protected override void OnActivateScene()
		{
			base.OnActivateScene();
			if(PrevTransition == TransitionList.Type.EVENT_STORY && TransitionType == MenuTransitionControl.TransitionType.Return)
			{
				if(m_storyEventLayout != null)
				{
					m_storyEventLayout.OpenWindow();
				}
			}
		}

		// RVA: 0xDD781C Offset: 0xDD781C VA: 0xDD781C Slot: 14
		protected override void OnDestoryScene()
		{
			m_option_anim.ReleaseBadge();
		}

		// RVA: 0xDD7844 Offset: 0xDD7844 VA: 0xDD7844 Slot: 15
		protected override void OnDeleteCache()
		{
			if(m_configMenu != null)
			{
				m_configMenu.Dispose();
				m_configMenu = null;
			}
			if(m_accountManagementWindow != null)
			{
				Destroy(m_accountManagementWindow.gameObject);
				m_accountManagementWindow = null;
			}
			if(m_accountAgreeWindow != null)
			{
				Destroy(m_accountAgreeWindow.gameObject);
				m_accountAgreeWindow = null;
			}
			if(m_accountConfirmWindow != null)
			{
				Destroy(m_accountConfirmWindow.gameObject);
				m_accountConfirmWindow = null;
			}
			if(m_accountRemoveTextWindow != null)
			{
				Destroy(m_accountRemoveTextWindow.gameObject);
				m_accountRemoveTextWindow = null;
			}
		}

		//// RVA: 0xDD7BB0 Offset: 0xDD7BB0 VA: 0xDD7BB0
		private void OnClickShop()
		{
			MenuScene.Instance.Call(TransitionList.Type.SHOP, null, true);
		}

		//// RVA: 0xDD7C64 Offset: 0xDD7C64 VA: 0xDD7C64
		private void OnClickProfile()
		{
			ProfilDateArgs args = new ProfilDateArgs();
			args.infoType = ProfilMenuLayout.InfoType.PLAYER;
			args.isShowMyProfil = true;
			MenuScene.Instance.Call(TransitionList.Type.PROFIL, null, true);
		}

		//// RVA: 0xDD7D6C Offset: 0xDD7D6C VA: 0xDD7D6C
		private void OnClickItem()
		{
			if (MenuScene.CheckDatelineAndAssetUpdate())
				return;

			MenuScene.Instance.ShowItemListWindow(PopupItemList.ItemType.Growth, true);
		}

		//// RVA: 0xDD7E4C Offset: 0xDD7E4C VA: 0xDD7E4C
		private void OnClickConfig()
		{
			m_configMenu.ShowPopupConfig(null, null);
		}

		//// RVA: 0xDD7E80 Offset: 0xDD7E80 VA: 0xDD7E80
		private void OnClickHelp()
		{
			MenuScene.Instance.Call(TransitionList.Type.HELP_LIST, null, true);
		}

		//// RVA: 0xDD7F34 Offset: 0xDD7F34 VA: 0xDD7F34
		private void OnClickOpinion()
		{
			this.StartCoroutineWatched(Opinion());
		}

		//// RVA: 0xDD7FCC Offset: 0xDD7FCC VA: 0xDD7FCC
		private void OnClickContact()
		{
			this.StartCoroutineWatched(Inquery());
		}

		//// RVA: 0xDD807C Offset: 0xDD807C VA: 0xDD807C
		private void OnClickBalance()
		{
			this.StartCoroutineWatched(Balance());
		}

		//// RVA: 0xDD8114 Offset: 0xDD8114 VA: 0xDD8114
		private void OnClickFAQ()
		{
			NKGJPJPHLIF.HHCJCDFCLOB.NBLAOIPJFGL_OpenURL(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.JLJEEMEOPLE["official_wiki_faq"]);
		}

		//// RVA: 0xDD8288 Offset: 0xDD8288 VA: 0xDD8288
		private void OnClickTitle()
		{
			this.StartCoroutineWatched(Co_GoTitle());
		}

		//// RVA: 0xDD8320 Offset: 0xDD8320 VA: 0xDD8320
		private void OnClickBlockList()
		{
			MenuScene.Instance.Call(TransitionList.Type.BLOCK_LIST, null, false);
		}

		//// RVA: 0xDD83D4 Offset: 0xDD83D4 VA: 0xDD83D4
		private void OnClickTakeOverData()
		{
			this.StartCoroutineWatched(Co_AccountManagment());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FDF14 Offset: 0x6FDF14 VA: 0x6FDF14
		//// RVA: 0xDD83F8 Offset: 0xDD83F8 VA: 0xDD83F8
		private IEnumerator Co_AccountManagment()
		{
			BBHNACPENDM_ServerSaveData playerData; // 0x18
			NKGJPJPHLIF sakashoMrg; // 0x1C
			HDEEBKIFLNI linkageMrg; // 0x20
			MCKCJMLOAFP_CurrencyInfo balanceData; // 0x24
			MessageBank messageBank; // 0x28
			bool isLoop; // 0x2C
			bool startAccountRemove; // 0x2D
			AccountRemove accountRemove; // 0x30

			//0xDDB108
			MenuScene.Instance.InputDisable();
			if(!m_isLoadedAccountLayout)
			{
				yield return Co.R(Co_LoadAccountRemoveLayout());
				m_isLoadedAccountLayout = true;
			}
			//LAB_00ddb27c
			playerData = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave;
			sakashoMrg = NKGJPJPHLIF.HHCJCDFCLOB;
			linkageMrg = HDEEBKIFLNI.HHCJCDFCLOB;
			balanceData = CIOECGOMILE.HHCJCDFCLOB.JBEKNFEGFFI();
			messageBank = MessageManager.Instance.GetBank("common");
			bool isWait = true;
			bool isCancel = false;
			bool isGotoTitle = false;
			isLoop = true;
			//LAB_00ddb83c
			startAccountRemove = false;
			//LAB_00ddb840
			while(true)
			{ 
				if (!isLoop)
				{
					yield return Co.R(m_accountManagementWindow.Co_Close());
					if(!startAccountRemove)
					{
						//LAB_00ddbb5c
						MenuScene.Instance.InputEnable();
						break;
					}
					yield return Co.R(m_accountRemoveTextWindow.Co_Show(messageBank.GetMessageByLabel("popup_account_remove_title"), messageBank.GetMessageByLabel("popup_account_remove_text001")));
					accountRemove = new AccountRemove();
					yield return Co.R(accountRemove.Execute());
					if (accountRemove.RemoveAcctounResult == AccountRemove.Result.Failure)
					{
						//LAB_00ddbb04
						MenuScene.Instance.GotoTitle();
						break;
					}
					if(accountRemove.RemoveAcctounResult != AccountRemove.Result.Success)
					{
						accountRemove = null;
						//LAB_00ddbb5c
						MenuScene.Instance.InputEnable();
						break;
					}
					yield return Co.R(m_accountRemoveTextWindow.Co_Close());
					yield return Co.R(m_accountRemoveTextWindow.Co_Show(messageBank.GetMessageByLabel("popup_account_remove_title"), messageBank.GetMessageByLabel("popup_account_remove_text002")));
					break;
				}
				else
				{
					yield return Co.R(m_accountManagementWindow.Co_Show());
					yield return Co.R(m_accountManagementWindow.Co_Run());
					if(m_accountManagementWindow.WindowResult != AccountManagementWindow.Result.AccountRemove)
					{
						if(m_accountManagementWindow.WindowResult != AccountManagementWindow.Result.TakeOver)
						{
							if (m_accountManagementWindow.WindowResult == AccountManagementWindow.Result.Close)
								isLoop = false;
							//LAB_00ddb840;
							continue;
						}
						isWait = true;
						m_inheritingMenu.PopupShowMenu(true, () =>
						{
							//0xDD9CCC
							return;
						}, () =>
						{
							//0xDDA3FC
							isWait = false;
						}, null);
						//LAB_00ddbd38;
						while (isWait)
							yield return null;
						//LAB_00ddbd70;
						continue;
					}
					yield return Co.R(m_accountAgreeWindow.Co_Show());
					yield return Co.R(m_accountAgreeWindow.Co_Run());
					yield return Co.R(m_accountAgreeWindow.Co_Close());
					if(m_accountAgreeWindow.WindowResult == AccountAgreeWindow.Result.AccountRemove)
					{
						isWait = true;
						isCancel = false;
						isGotoTitle = false;
						linkageMrg.NLCBOJBAJFB_GetLinkageStatuses(() =>
						{
							//0xDDA408
							isWait = false;
						}, () =>
						{
							//0xDDA414
							isWait = false;
							isCancel = true;
						}, () =>
						{
							//0xDDA420
							isWait = false;
							isGotoTitle = true;
						});
						//LAB_00ddb710
						while (isWait)
							yield return null;
						if(!isCancel)
						{
							if(!isGotoTitle)
							{
								m_accountConfirmWindow.SetContent(sakashoMrg.MDAMJIGBOLD_PlayerId, playerData.JHFIPCIHJNL_Base.OPFGFINHFCE_PlayerName, playerData.KCCLEHLLOFG_Common.KIECDDFNCAN_Level,
									linkageMrg.EPAKLDBFECD_IsLinked(HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink.OKEAEMBLENP_Facebook),
									linkageMrg.EPAKLDBFECD_IsLinked(HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink.AIECBKAKOGC_Twitter),
									linkageMrg.EPAKLDBFECD_IsLinked(HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink.LMODEBIKEBC_Line),
									false, balanceData, NHPDPKHMFEP.HHCJCDFCLOB.GBCPDBJEDHL(false), NHPDPKHMFEP.HHCJCDFCLOB.ENAAHAPDMCO());
								yield return null;
								yield return Co.R(m_accountConfirmWindow.Co_Show());
								yield return Co.R(m_accountConfirmWindow.Co_Wait());
								yield return Co.R(m_accountConfirmWindow.Co_Close());
								if (m_accountConfirmWindow.WindowResult == AccountConfirmWindow.Result.OK)
								{
									isLoop = false;
									startAccountRemove = true;
									//LAB_00ddb83c;
								}
								//LAB_00ddb840;
								continue;
							}
							//LAB_00ddbb04
							MenuScene.Instance.GotoTitle();
							break;
						}
						//LAB_00ddbd70
						continue;
					}
					//LAB_00ddb840
					continue;
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FDF8C Offset: 0x6FDF8C VA: 0x6FDF8C
		//// RVA: 0xDD84A4 Offset: 0xDD84A4 VA: 0xDD84A4
		private IEnumerator Co_LoadAccountRemoveLayout()
		{
			int loadCount; // 0x14
			Font systemFont; // 0x18
			AssetBundleLoadUGUIOperationBase op; // 0x1C

			//0xDDD5B8
			loadCount = 0;
			systemFont = GameManager.Instance.GetSystemFont();
			op = AssetBundleManager.LoadUGUIAsync("ly/300.xab", "AccountManagmentWindow");
			yield return op;
			yield return Co.R(op.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xDD95BC
				instance.transform.SetParent(MenuScene.Instance.m_uiRootObject.transform, false);
				m_accountManagementWindow = instance.GetComponent<AccountManagementWindow>();
			}));
			loadCount++;
			op = AssetBundleManager.LoadUGUIAsync("ly/300.xab", "AccountAgreeWindow");
			yield return op;
			yield return Co.R(op.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xDD96E8
				instance.transform.SetParent(MenuScene.Instance.m_uiRootObject.transform, false);
				m_accountAgreeWindow = instance.GetComponent<AccountAgreeWindow>();
			}));
			loadCount++;
			op = AssetBundleManager.LoadUGUIAsync("ly/300.xab", "AccountConfirmWindow");
			yield return op;
			yield return Co.R(op.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xDD9814
				instance.transform.SetParent(MenuScene.Instance.m_uiRootObject.transform, false);
				m_accountConfirmWindow = instance.GetComponent<AccountConfirmWindow>();
			}));
			loadCount++;
			op = AssetBundleManager.LoadUGUIAsync("ly/300.xab", "AccountRemoveTextWindow");
			yield return op;
			yield return Co.R(op.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xDD9940
				instance.transform.SetParent(MenuScene.Instance.m_uiRootObject.transform, false);
				m_accountRemoveTextWindow = instance.GetComponent<AccountRemoveTextWindow>();
			}));
			loadCount++;
			for(int i = 0; i < loadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle("ly/300.xab", false);
			}
		}

		//// RVA: 0xDD8550 Offset: 0xDD8550 VA: 0xDD8550
		private void OnClickDataManagement()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			PopupDataOptionSetting s = new PopupDataOptionSetting();
			s.TitleText = bk.GetMessageByLabel("popup_option_data_title");
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			s.WindowSize = SizeType.Middle;
			s.IsCaption = true;
			s.OnClickBunchInstall = (PopupWindowControl popupControl) =>
			{
				//0xDD9A6C
				this.StartCoroutineWatched(Co_AllInstall(popupControl));
			};
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel buttonLabel) =>
			{
				//0xDD9CD0
				return;
			}, null, null, null);
		}

		//// RVA: 0xDD8918 Offset: 0xDD8918 VA: 0xDD8918
		private void OnClickInfo()
		{
			return;
		}

		//// RVA: 0xDD891C Offset: 0xDD891C VA: 0xDD891C
		private void OnClickInquiry()
		{
			return;
		}

		//// RVA: 0xDD8920 Offset: 0xDD8920 VA: 0xDD8920
		private void OnClickLink()
		{
			PopupShowVariousInfo();
		}

		//// RVA: 0xDD8C84 Offset: 0xDD8C84 VA: 0xDD8C84
		private void OnClickRanking()
		{
			if (MenuScene.CheckDatelineAndAssetUpdate())
				return;
			this.StartCoroutineWatched(Co_OpenPastRankingPopup());
		}

		//// RVA: 0xDD8D94 Offset: 0xDD8D94 VA: 0xDD8D94
		private void OnClickHonorary()
		{
			MenuScene.Instance.Call(TransitionList.Type.DEGREE_SELECT, null, true);
		}

		//// RVA: 0xDD8E48 Offset: 0xDD8E48 VA: 0xDD8E48
		private void OnClickOption()
		{
			return;
		}

		//// RVA: 0xDD8E4C Offset: 0xDD8E4C VA: 0xDD8E4C
		private void OnEventReview()
		{
			if(DKKPBBBDKMJ.CADENLBDAEB())
			{
				DKKPBBBDKMJ.EMNNLEFCKHM(true);
				CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
				{
					//0xDD9A90
					setNewIcon();
					m_option_anim.SetBadge(14, DKKPBBBDKMJ.CADENLBDAEB() ? BadgeConstant.ID.Menu_NewFuncAdd : BadgeConstant.ID.None);
					JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
				}, () =>
				{
					//0xDD9CD4
					JDDGPJDKHNE.HHCJCDFCLOB.FOKEGEOKGDG();
					JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
					MenuScene.Instance.GotoTitle();
				}, null);
			}
			Database.Instance.selectedEventStoryEventId = -1;
			m_storyEventLayout.OpenWindow();
		}

		//// RVA: 0xDD9078 Offset: 0xDD9078 VA: 0xDD9078
		//private void OpenStartPopupCallback() { }

		//// RVA: 0xDD8924 Offset: 0xDD8924 VA: 0xDD8924
		private void PopupShowVariousInfo()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			PopupVariousInfoSetting s = new PopupVariousInfoSetting();
			s.TitleText = bk.GetMessageByLabel("popup_option_various_info");
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			s.WindowSize = SizeType.Large;
			s.IsCaption = true;
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel buttonLabel) =>
			{
				//0xDD9DBC
				return;
			}, null, null, null);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FE004 Offset: 0x6FE004 VA: 0x6FE004
		//// RVA: 0xDD8D20 Offset: 0xDD8D20 VA: 0xDD8D20
		private IEnumerator Co_OpenPastRankingPopup()
		{
			bool inputDisable; // 0x14
			IKDICBBFBMI_EventBase scoreCtrl; // 0x18
			IKDICBBFBMI_EventBase eventCtrl; // 0x1C

			//0xDDEA0C
			MenuScene.Instance.InputDisable();
			inputDisable = false;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			eventCtrl = null;
			scoreCtrl = null;
			bool toScore = false;
			bool toEvent = false;
			List<IKDICBBFBMI_EventBase> evList = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.CADBMICNIJJ();
			if(evList == null || evList.Count == 0)
			{
				PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("popup_option_ranking_notfound_title"), SizeType.Middle, bk.GetMessageByLabel("popup_option_ranking_notfound_msg"), new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					}, false, true), (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
					{
						//0xDD9DC0
						return;
					}, null, null, null);
			}
			else
			{
				for(int i = 0; i < evList.Count; i++)
				{
					if (evList[i].HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.KEILBOLBDHN_EventScore)
						scoreCtrl = evList[i];
					else
						eventCtrl = evList[i];
				}
				PopupPastRankingSetting s = new PopupPastRankingSetting();
				s.TitleText = bk.GetMessageByLabel("popup_option_ranking_title");
				s.WindowSize = SizeType.Small;
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				};
				if(scoreCtrl != null)
				{
					s.ScoreRankingIconId = scoreCtrl.PGIIDPEGGPI_EventId;
					s.OnClickScoreRanking = () =>
					{
						//0xDDA43C
						SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
						toScore = true;
						PopupWindowManager.Close(null, null);
					};
				}
				if(eventCtrl != null)
				{
					s.EventRankingIconId = eventCtrl.PGIIDPEGGPI_EventId;
					s.OnClickEventRanking = () =>
					{
						//0xDDA518
						SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
						toEvent = true;
						PopupWindowManager.Close(null, null);
					};
				}
				PopupWindowManager.Show(s, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0xDD9DC4
					return;
				}, null, null, null);
			}
			while (!PopupWindowManager.IsActivePopupWindow())
				yield return null;
			while (PopupWindowManager.IsActivePopupWindow())
				yield return null;
			if(!toScore)
			{
				if(toEvent)
				{
					EventRankingSceneArgs args = new EventRankingSceneArgs(eventCtrl, true, 0, 0);
					MenuScene.Instance.Call(TransitionList.Type.EVENT_RANKING, args, true);
					inputDisable = true;
				}
			}
			else
			{
				EventRankingSceneArgs args = new EventRankingSceneArgs(scoreCtrl, true, 0, 0);
				MenuScene.Instance.Call(TransitionList.Type.EVENT_RANKING, args, true);
				inputDisable = true;
			}
			if (inputDisable)
			{
				while (MenuScene.Instance.DirtyChangeScene)
					yield return null;
			}
			MenuScene.Instance.InputEnable();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FE07C Offset: 0x6FE07C VA: 0x6FE07C
		//// RVA: 0xDD82AC Offset: 0xDD82AC VA: 0xDD82AC
		private IEnumerator Co_GoTitle()
		{
			//0xDDD034
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = new TextPopupSetting();
			s.TitleText = "";
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			s.WindowSize = SizeType.Small;
			s.Text = bk.GetMessageByLabel("popup_gotitle_001");
			s.IsCaption = false;
			bool isOk = false;
			bool isWait = true;
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel buttonLabel) =>
			{
				//0xDDA5FC
				if (type == PopupButton.ButtonType.Positive)
					isOk = true;
			}, null, null, null, closeWaitCallBack: () =>
			{
				//0xDDA60C
				isWait = false;
				return true;
			});
			while (isWait)
				yield return null;
			if (isOk)
				MenuScene.Instance.GotoTitle();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FE0F4 Offset: 0x6FE0F4 VA: 0x6FE0F4
		//// RVA: 0xDD7FF0 Offset: 0xDD7FF0 VA: 0xDD7FF0
		private IEnumerator Inquery()
		{
			//0xDDF6BC
			bool isDone = false;
			MenuScene.Instance.RaycastDisable();
			MBCPNPNMFHB.HHCJCDFCLOB.MDGPGGLHIPB_ShowWebUrl(MHOILBOJFHL.KCAEDEHGAFO.CCFMGBNHMNN_Inquiry, () =>
			{
				//0xDDA624
				isDone = true;
			}, () =>
			{
				//0xDD9DC8
				MenuScene.Instance.RaycastEnable();
				MenuScene.Instance.GotoTitle();
			});
			while(!isDone)
				yield return null;
			isDone = false;
			NKGJPJPHLIF.HHCJCDFCLOB.LLMEJNALPJD(true, () =>
			{
				//0xDDA630
				isDone = true;
			}, () =>
			{
				//0xDD9E8C
				MenuScene.Instance.RaycastEnable();
				MenuScene.Instance.GotoTitle();
			}, true);
			while (!isDone)
				yield return null;
			MenuScene.Instance.RaycastEnable();
			setNewIcon();
			m_option_anim.SetBadge(AppEnv.IsCBT() ? 13 : 12, NKGJPJPHLIF.HHCJCDFCLOB.AFJEOKGBCNA_NumReplies > 0 ? BadgeConstant.ID.Menu_ResvMsg : BadgeConstant.ID.None);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FE16C Offset: 0x6FE16C VA: 0x6FE16C
		//// RVA: 0xDD80A0 Offset: 0xDD80A0 VA: 0xDD80A0
		private IEnumerator Balance()
		{
			//0xDDADB8
			MenuScene.Instance.RaycastDisable();
			MBCPNPNMFHB.HHCJCDFCLOB.MDGPGGLHIPB_ShowWebUrl(MHOILBOJFHL.KCAEDEHGAFO.LCNNIHGFBMP_Balance, () =>
			{
				//0xDD9F50
				MenuScene.Instance.RaycastEnable();
			}, () =>
			{
				//0xDD9FEC
				MenuScene.Instance.RaycastEnable();
				MenuScene.Instance.GotoTitle();
			});
			yield break;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FE1E4 Offset: 0x6FE1E4 VA: 0x6FE1E4
		//// RVA: 0xDD7F58 Offset: 0xDD7F58 VA: 0xDD7F58
		private IEnumerator Opinion()
		{
			//0xDDFD5C
			MenuScene.Instance.RaycastDisable();
			MBCPNPNMFHB.HHCJCDFCLOB.MDGPGGLHIPB_ShowWebUrl(MHOILBOJFHL.KCAEDEHGAFO.FFIDPICMNKN_Opinion, () =>
			{
				//0xDDA0B0
				MenuScene.Instance.RaycastEnable();
			}, () =>
			{
				//0xDDA14C
				MenuScene.Instance.RaycastEnable();
				MenuScene.Instance.GotoTitle();
			});
			yield break;
		}

		//// RVA: 0xDD9164 Offset: 0xDD9164 VA: 0xDD9164
		private void setNewIcon()
		{
			bool isNew = true;
			if (NKGJPJPHLIF.HHCJCDFCLOB.AFJEOKGBCNA_NumReplies < 1 && !AODFBGCCBPE.PLKKMHBFDCJ())
				isNew = DKKPBBBDKMJ.CADENLBDAEB();
			MenuScene.Instance.FooterMenu.SetButtonNew(MenuFooterControl.Button.Menu, isNew);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FE25C Offset: 0x6FE25C VA: 0x6FE25C
		//// RVA: 0xDD92A4 Offset: 0xDD92A4 VA: 0xDD92A4
		private IEnumerator Co_AllInstall(PopupWindowControl dataManagementPopupControl)
		{
			//0xDDC0DC
			if (MenuScene.CheckDatelineAndAssetUpdate())
			{
				dataManagementPopupControl.Close(() =>
				{
					//0xDDA210
					return;
				}, null);
				yield break;
			}
			dataManagementPopupControl.InputDisable();
			MenuScene.Instance.InputDisable();
			XeSys.uGUI.UGUIFader fader = GameManager.Instance.fullscreenFader;
			TipsControl tipsCtrl = TipsControl.Instance;
			NHMKBENBIPI installManager = new NHMKBENBIPI();
			bool isEnterTips = false;
			bool waitPopupClose = false;
			bool isClosePopup = false;
			Transform cancelButtonParent = m_bunchInstallCancelButton.transform.parent;
			m_bunchInstallCancelButton.transform.SetParent(TipsControl.Instance.transform, false);
			installManager.OEPPEGHGNNO = (int type, float per) =>
			{
				//0xDDA644
				bool res = false;
				switch(type)
				{
					case 1:
						fader.Fade(0.5f, new Color(0, 0, 0, 0.5f));
						tipsCtrl.Show(10);
						isEnterTips = true;
						waitPopupClose = true;
						dataManagementPopupControl.Close(() =>
						{
							//0xDDAB78
							waitPopupClose = false;
						}, null);
						isClosePopup = true;
						m_bunchInstallCancelButton.gameObject.SetActive(true);
						m_bunchInstallCancelButton.OnClickCancelButton = () =>
						{
							//0xDDAB84
							installManager.CEDCKHPBKLL(true);
						};
						m_bunchInstallCancelButton.SetInputOff(false);
						break;
					case 2:
						m_bunchInstallCancelButton.gameObject.SetActive(false);
						m_bunchInstallCancelButton.OnClickCancelButton = null;
						break;
					case 3:
						GameManager.Instance.DownloadBar.HighResolutionModeFlag = true;
						break;
					case 4:
						if(!fader.isFading)
						{
							if(!tipsCtrl.IsLoading)
							{
								if (!tipsCtrl.isPlayingAnime() && !waitPopupClose)
									res = true;
							}
						}
						break;
					default:
						break;
				}
				OMIFMMJPMDJ o = KDLPEDBKMID.HHCJCDFCLOB.OEPPEGHGNNO;
				if(o != null)
				{
					res &= o(type, per);
				}
				return res;
			};
			installManager.OFLDICKPNFD(true, () =>
			{
				//0xDDABB4
				m_bunchInstallCancelButton.transform.SetParent(cancelButtonParent, false);
				MenuScene.Instance.GotoTitle();
			});
			bool isWait = true;
			bool isComplete = false;
			bool isError = false;
			installManager.PAHGEEOFEPM(true, () =>
			{
				//0xDDACB4
				isComplete = true;
				isWait = false;
			}, () =>
			{
				//0xDDACC0
				isWait = false;
			}, () =>
			{
				//0xDDACCC
				isWait = false;
				isError = true;
			});
			yield return new WaitWhile(() =>
			{
				//0xDDACD8
				return isWait;
			});
			if(isError)
			{
				m_bunchInstallCancelButton.transform.SetParent(cancelButtonParent, false);
				MenuScene.Instance.GotoTitle();
			}
			else
			{
				if(isComplete)
				{
					bool waitPopup = true;
					TextPopupSetting s = new TextPopupSetting();
					s.TitleText = MessageManager.Instance.GetMessage("menu", "popup_bunchdownload_complete_title");
					s.Text = MessageManager.Instance.GetMessage("menu", "popup_bunchdownload_complete");
					s.Buttons = new ButtonInfo[1] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive } };
					PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel buttonLabel) =>
					{
						//0xDDADA0
						waitPopup = false;
					}, null, null, null);
					yield return new WaitWhile(() =>
					{
						//0xDDADAC
						return waitPopup;
					});
				}
				if(isEnterTips)
				{
					fader.Fade(0.5f, 0);
					tipsCtrl.Close();
				}
				MenuScene.Instance.InputEnable();
				if(!isClosePopup)
				{
					yield return new WaitWhile(() =>
					{
						//0xDDACE0
						return fader.isFading || tipsCtrl.isPlayingAnime();
					});
					dataManagementPopupControl.InputEnable();
				}
				else
				{
					OnClickDataManagement();
				}
				yield return new WaitWhile(() =>
				{
					//0xDDAD3C
					return fader.isFading || tipsCtrl.isPlayingAnime();
				});
				m_bunchInstallCancelButton.transform.SetParent(cancelButtonParent, false);
			}
		}
	}
}
