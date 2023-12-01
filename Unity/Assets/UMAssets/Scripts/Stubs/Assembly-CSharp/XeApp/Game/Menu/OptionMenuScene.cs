using mcrs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
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
			m_option_anim.SetBadge(0, total > 0 ? 7 : 0);
			int id = NKGJPJPHLIF.HHCJCDFCLOB.AFJEOKGBCNA_NumReplies > 0 ? 9 : 0;
			if(AppEnv.IsCBT())
			{
				m_option_anim.SetBadge(13, id);
			}
			else
			{
				m_option_anim.SetBadge(12, id);
			}
			m_option_anim.SetBadge(14, DKKPBBBDKMJ.CADENLBDAEB() ? 8 : 0);
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
			TodoLogger.LogNotImplemented("OnClickShop");
		}

		//// RVA: 0xDD7C64 Offset: 0xDD7C64 VA: 0xDD7C64
		private void OnClickProfile()
		{
			TodoLogger.LogNotImplemented("OnClickProfile");
		}

		//// RVA: 0xDD7D6C Offset: 0xDD7D6C VA: 0xDD7D6C
		private void OnClickItem()
		{
			TodoLogger.LogNotImplemented("OnClickItem");
		}

		//// RVA: 0xDD7E4C Offset: 0xDD7E4C VA: 0xDD7E4C
		private void OnClickConfig()
		{
			TodoLogger.LogNotImplemented("OnClickConfig");
		}

		//// RVA: 0xDD7E80 Offset: 0xDD7E80 VA: 0xDD7E80
		private void OnClickHelp()
		{
			TodoLogger.LogNotImplemented("OnClickHelp");
		}

		//// RVA: 0xDD7F34 Offset: 0xDD7F34 VA: 0xDD7F34
		private void OnClickOpinion()
		{
			TodoLogger.LogNotImplemented("OnClickOpinion");
		}

		//// RVA: 0xDD7FCC Offset: 0xDD7FCC VA: 0xDD7FCC
		private void OnClickContact()
		{
			TodoLogger.LogNotImplemented("OnClickContact");
		}

		//// RVA: 0xDD807C Offset: 0xDD807C VA: 0xDD807C
		private void OnClickBalance()
		{
			TodoLogger.LogNotImplemented("OnClickBalance");
		}

		//// RVA: 0xDD8114 Offset: 0xDD8114 VA: 0xDD8114
		private void OnClickFAQ()
		{
			TodoLogger.LogNotImplemented("OnClickFAQ");
		}

		//// RVA: 0xDD8288 Offset: 0xDD8288 VA: 0xDD8288
		private void OnClickTitle()
		{
			TodoLogger.LogNotImplemented("OnClickTitle");
		}

		//// RVA: 0xDD8320 Offset: 0xDD8320 VA: 0xDD8320
		private void OnClickBlockList()
		{
			TodoLogger.LogNotImplemented("OnClickBlockList");
		}

		//// RVA: 0xDD83D4 Offset: 0xDD83D4 VA: 0xDD83D4
		private void OnClickTakeOverData()
		{
			TodoLogger.LogNotImplemented("OnClickTakeOverData");
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FDF14 Offset: 0x6FDF14 VA: 0x6FDF14
		//// RVA: 0xDD83F8 Offset: 0xDD83F8 VA: 0xDD83F8
		//private IEnumerator Co_AccountManagment() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6FDF8C Offset: 0x6FDF8C VA: 0x6FDF8C
		//// RVA: 0xDD84A4 Offset: 0xDD84A4 VA: 0xDD84A4
		//private IEnumerator Co_LoadAccountRemoveLayout() { }

		//// RVA: 0xDD8550 Offset: 0xDD8550 VA: 0xDD8550
		private void OnClickDataManagement()
		{
			TodoLogger.LogNotImplemented("OnClickDataManagement");
		}

		//// RVA: 0xDD8918 Offset: 0xDD8918 VA: 0xDD8918
		private void OnClickInfo()
		{
			TodoLogger.LogNotImplemented("OnClickInfo");
		}

		//// RVA: 0xDD891C Offset: 0xDD891C VA: 0xDD891C
		private void OnClickInquiry()
		{
			TodoLogger.LogNotImplemented("OnClickInquiry");
		}

		//// RVA: 0xDD8920 Offset: 0xDD8920 VA: 0xDD8920
		private void OnClickLink()
		{
			TodoLogger.LogNotImplemented("OnClickLink");
		}

		//// RVA: 0xDD8C84 Offset: 0xDD8C84 VA: 0xDD8C84
		private void OnClickRanking()
		{
			TodoLogger.LogNotImplemented("OnClickRanking");
		}

		//// RVA: 0xDD8D94 Offset: 0xDD8D94 VA: 0xDD8D94
		private void OnClickHonorary()
		{
			TodoLogger.LogNotImplemented("OnClickHonorary");
		}

		//// RVA: 0xDD8E48 Offset: 0xDD8E48 VA: 0xDD8E48
		private void OnClickOption()
		{
			TodoLogger.LogNotImplemented("OnClickOption");
		}

		//// RVA: 0xDD8E4C Offset: 0xDD8E4C VA: 0xDD8E4C
		private void OnEventReview()
		{
			TodoLogger.LogNotImplemented("OnEventReview");
		}

		//// RVA: 0xDD9078 Offset: 0xDD9078 VA: 0xDD9078
		//private void OpenStartPopupCallback() { }

		//// RVA: 0xDD8924 Offset: 0xDD8924 VA: 0xDD8924
		//private void PopupShowVariousInfo() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6FE004 Offset: 0x6FE004 VA: 0x6FE004
		//// RVA: 0xDD8D20 Offset: 0xDD8D20 VA: 0xDD8D20
		//private IEnumerator Co_OpenPastRankingPopup() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6FE07C Offset: 0x6FE07C VA: 0x6FE07C
		//// RVA: 0xDD82AC Offset: 0xDD82AC VA: 0xDD82AC
		//private IEnumerator Co_GoTitle() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6FE0F4 Offset: 0x6FE0F4 VA: 0x6FE0F4
		//// RVA: 0xDD7FF0 Offset: 0xDD7FF0 VA: 0xDD7FF0
		//private IEnumerator Inquery() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6FE16C Offset: 0x6FE16C VA: 0x6FE16C
		//// RVA: 0xDD80A0 Offset: 0xDD80A0 VA: 0xDD80A0
		//private IEnumerator Balance() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6FE1E4 Offset: 0x6FE1E4 VA: 0x6FE1E4
		//// RVA: 0xDD7F58 Offset: 0xDD7F58 VA: 0xDD7F58
		//private IEnumerator Opinion() { }

		//// RVA: 0xDD9164 Offset: 0xDD9164 VA: 0xDD9164
		//private void setNewIcon() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6FE25C Offset: 0x6FE25C VA: 0x6FE25C
		//// RVA: 0xDD92A4 Offset: 0xDD92A4 VA: 0xDD92A4
		//private IEnumerator Co_AllInstall(PopupWindowControl dataManagementPopupControl) { }
		
		//[CompilerGeneratedAttribute] // RVA: 0x6FE2F4 Offset: 0x6FE2F4 VA: 0x6FE2F4
		//// RVA: 0xDD95BC Offset: 0xDD95BC VA: 0xDD95BC
		//private void <Co_LoadAccountRemoveLayout>b__46_0(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6FE304 Offset: 0x6FE304 VA: 0x6FE304
		//// RVA: 0xDD96E8 Offset: 0xDD96E8 VA: 0xDD96E8
		//private void <Co_LoadAccountRemoveLayout>b__46_1(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6FE314 Offset: 0x6FE314 VA: 0x6FE314
		//// RVA: 0xDD9814 Offset: 0xDD9814 VA: 0xDD9814
		//private void <Co_LoadAccountRemoveLayout>b__46_2(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6FE324 Offset: 0x6FE324 VA: 0x6FE324
		//// RVA: 0xDD9940 Offset: 0xDD9940 VA: 0xDD9940
		//private void <Co_LoadAccountRemoveLayout>b__46_3(GameObject instance) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6FE334 Offset: 0x6FE334 VA: 0x6FE334
		//// RVA: 0xDD9A6C Offset: 0xDD9A6C VA: 0xDD9A6C
		//private void <OnClickDataManagement>b__47_1(PopupWindowControl popupControl) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6FE344 Offset: 0x6FE344 VA: 0x6FE344
		//// RVA: 0xDD9A90 Offset: 0xDD9A90 VA: 0xDD9A90
		//private void <OnEventReview>b__54_0() { }
	}
}
