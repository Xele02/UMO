using System.Collections;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class CampaignScene : TransitionRoot
	{
		private LayoutCampaign m_layoutEntry; // 0x48
		private LayoutCampaignStamp m_layoutEntryStamp; // 0x4C
		private OLLAFCBLMIJ m_viewEntry; // 0x50
		private Coroutine m_loadCoroutine; // 0x54

		// RVA: 0x10A8814 Offset: 0x10A8814 VA: 0x10A8814 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			this.StartCoroutineWatched(Co_InitializeLayout());
		}

		// RVA: 0x10A8868 Offset: 0x10A8868 VA: 0x10A8868 Slot: 16
		protected override void OnPreSetCanvas()
		{
			base.OnPreSetCanvas();
			m_viewEntry = new OLLAFCBLMIJ();
			m_viewEntry.KHEKNNFCAOI();
			m_layoutEntry.Setup(m_viewEntry, true);
			m_loadCoroutine = this.StartCoroutineWatched(Co_BgLoad(m_viewEntry.EKANGPODCEP_EventId));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CAE7C Offset: 0x6CAE7C VA: 0x6CAE7C
		// // RVA: 0x10A8960 Offset: 0x10A8960 VA: 0x10A8960
		private IEnumerator Co_BgLoad(int eventId)
		{
			//0x10AA374
			yield return Co.R(MenuScene.Instance.BgControl.ChangeBgCoroutine(BgType.Campaign, eventId, SceneGroupCategory.UNDEFINED, TransitionList.Type.UNDEFINED, -1));
			m_loadCoroutine = null;
		}

		// RVA: 0x10A8A28 Offset: 0x10A8A28 VA: 0x10A8A28 Slot: 18
		protected override void OnPostSetCanvas()
		{ 
			base.OnPostSetCanvas();
		}

		// RVA: 0x10A8A30 Offset: 0x10A8A30 VA: 0x10A8A30 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning && m_loadCoroutine == null;
		}

		// RVA: 0x10A8AF4 Offset: 0x10A8AF4 VA: 0x10A8AF4 Slot: 20
		protected override bool OnBgmStart()
		{
			SoundManager.Instance.bgmPlayer.Play(BgmPlayer.MINIGAME_BGM_ID_BASE, 1);
			return true;
		}

		// RVA: 0x10A8BD4 Offset: 0x10A8BD4 VA: 0x10A8BD4 Slot: 14
		protected override void OnDestoryScene()
		{
			return;
		}

		// // RVA: 0x10A8BD8 Offset: 0x10A8BD8 VA: 0x10A8BD8
		private void OnPrizeListButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			MenuScene.Instance.InputDisable();
			MBCPNPNMFHB.HHCJCDFCLOB.FLLLPBIECCP(m_viewEntry.MIKNPHMPNII_PrizeTemplate, () =>
			{
				//0x10A9BF8
				MenuScene.Instance.InputEnable();
			}, () =>
			{
				//0x10A9A2C
				MenuScene.Instance.InputEnable();
				GoToTitle();
			});
		}

		// // RVA: 0x10A8E50 Offset: 0x10A8E50 VA: 0x10A8E50
		private void OnRegistButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			if(!MenuScene.CheckDatelineAndAssetUpdate())
			{
				OpenPopupCampaignRegist();
			}
		}

		// // RVA: 0x10A8F2C Offset: 0x10A8F2C VA: 0x10A8F2C
		private void OpenPopupCampaignRegist()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			PopupCampaignRegistSetting s = new PopupCampaignRegistSetting();
			s.View = m_viewEntry;
			s.WindowSize = SizeType.Large;
			s.TitleText = bk.GetMessageByLabel("popup_campaign_title");
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.RegistSite, Type = PopupButton.ButtonType.Positive }
			};
			bool done = false;
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x10A9D54
				if(type == PopupButton.ButtonType.Positive && !MenuScene.CheckDatelineAndAssetUpdate())
				{
					NKGJPJPHLIF.HHCJCDFCLOB.NBLAOIPJFGL_OpenURL(m_viewEntry.MLIMPBOKIAM_EntryUrl);
				}
			}, null, null, null, true, true, false, null, () =>
			{
				//0x10A9E6C
				done = true;
			});
		}

		// // RVA: 0x10A92C4 Offset: 0x10A92C4 VA: 0x10A92C4
		private void OnContractButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			MenuScene.Instance.InputDisable();
			MBCPNPNMFHB.HHCJCDFCLOB.FLLLPBIECCP(m_viewEntry.DLPGGMOLFHA_KiyakuTemplate, () =>
			{
				//0x10A9C94
				MenuScene.Instance.InputEnable();
			}, () =>
			{
				//0x10A9AD4
				MenuScene.Instance.InputEnable();
				GoToTitle();
			});
		}

		// // RVA: 0x10A953C Offset: 0x10A953C VA: 0x10A953C
		private void OnEntryButton(ButtonBase button)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			if(!MenuScene.CheckDatelineAndAssetUpdate())
			{
				this.StartCoroutineWatched(Co_Entry(button));
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CAEF4 Offset: 0x6CAEF4 VA: 0x6CAEF4
		// // RVA: 0x10A9630 Offset: 0x10A9630 VA: 0x10A9630
		private IEnumerator Co_Entry(ButtonBase button)
		{
			bool isFirstEntry; // 0x1C
			OLLAFCBLMIJ.KAAHBIABMBC today; // 0x20

			//0x10AA550
			MenuScene.Instance.InputDisable();
			m_layoutEntry.Setup(m_viewEntry, true);
			isFirstEntry = m_viewEntry.CKPIHCGOEDP.Find((OLLAFCBLMIJ.KAAHBIABMBC x) =>
			{
				//0x10A9D30
				return x.CDMGDFLPPHN_HasStamp;
			}) == null;
			today = m_viewEntry.DHNCPKGDEFL();
			if(today != null)
			{
				if(today.OJDNGPNOMDE())
				{
					bool done = false;
					bool cancel = false;
					m_viewEntry.MFEGLKEAPLA(today.ECDKPAIEFFA_DayId, () =>
					{
						//0x10A9E80
						done = true;
					}, () =>
					{
						//0x10A9E8C
						done = true;
						cancel = true;
					}, () =>
					{
						//0x10A9E98
						GoToTitle();
					});
					yield return new WaitWhile(() =>
					{
						//0x10A9EC0
						return !done;
					});
					if(!cancel)
					{
						yield return Co.R(Co_StartStamp(today.ECDKPAIEFFA_DayId));
						button.Disable = true;
						m_viewEntry.KHEKNNFCAOI();
						m_layoutEntry.Setup(m_viewEntry, false);
						MenuScene.Instance.InputEnable();
						if(isFirstEntry)
							OpenPopupCampaignRegist();
					}
					else
					{
						MenuScene.Instance.InputEnable();
					}
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CAF6C Offset: 0x6CAF6C VA: 0x6CAF6C
		// // RVA: 0x10A96F8 Offset: 0x10A96F8 VA: 0x10A96F8
		public IEnumerator Co_StartStamp(int dayId)
		{
			LayoutCampaignIcon layoutIcon;

			//0x10AB9A0
			layoutIcon = m_layoutEntry.List.ScrollObjects.Find((SwapScrollListContent x) =>
			{
				//0x10A9EDC
				return x is LayoutCampaignIcon && x.gameObject.activeSelf && (x as LayoutCampaignIcon).dayId == dayId;
			}) as LayoutCampaignIcon;
			if(layoutIcon != null)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_LOGIN_000);
				m_layoutEntryStamp.gameObject.SetActive(true);
				(m_layoutEntryStamp.transform as RectTransform).sizeDelta = (layoutIcon.transform as RectTransform).sizeDelta;
				(m_layoutEntryStamp.transform as RectTransform).anchorMax = (layoutIcon.transform as RectTransform).anchorMax;
				(m_layoutEntryStamp.transform as RectTransform).anchorMin = (layoutIcon.transform as RectTransform).anchorMin;
				(m_layoutEntryStamp.transform as RectTransform).pivot = (layoutIcon.transform as RectTransform).pivot;
				(m_layoutEntryStamp.transform as RectTransform).position = (layoutIcon.transform as RectTransform).position;
				yield return Co.R(m_layoutEntryStamp.StartStamp());
				layoutIcon.SetStamp(true);
				yield return null;
				m_layoutEntryStamp.gameObject.SetActive(false);
			}
		}

		// // RVA: 0x10A97C0 Offset: 0x10A97C0 VA: 0x10A97C0
		private void GoToTitle()
		{
			if(MenuScene.Instance.IsTransition())
			{
				GotoTitle();
			}
			else
			{
				MenuScene.Instance.GotoTitle();
			}
		}

		// // RVA: 0x10A8844 Offset: 0x10A8844 VA: 0x10A8844
		// private void InitializeLayout() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6CAFE4 Offset: 0x6CAFE4 VA: 0x6CAFE4
		// // RVA: 0x10A98CC Offset: 0x10A98CC VA: 0x10A98C
		private IEnumerator Co_InitializeLayout()
		{
			//0x10AAC30
			yield return Co.R(Co_LoadLayout());
			IsReady = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CB05C Offset: 0x6CB05C VA: 0x6CB05C
		// // RVA: 0x10A9978 Offset: 0x10A9978 VA: 0x10A9978
		private IEnumerator Co_LoadLayout()
		{
			StringBuilder bundleName; // 0x18
			FontInfo systemFont; // 0x1C
			AssetBundleLoadLayoutOperationBase operation; // 0x20
			int poolSize; // 0x24

			//0x10AAD58
			bundleName = new StringBuilder(64);
			systemFont = GameManager.Instance.GetSystemFont();
			bundleName.Set("ly/119.xab");
			yield return AssetBundleManager.LoadUnionAssetBundle(bundleName.ToString());
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_cpn_live_01_layout_root");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x10A9FF4
				instance.transform.SetParent(transform, false);
				m_layoutEntry = instance.GetComponent<LayoutCampaign>();
			}));
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_get_stamp_layout_root");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x10AA0F0
				instance.transform.SetParent(transform, false);
				m_layoutEntryStamp = instance.transform.GetComponent<LayoutCampaignStamp>();
			}));
			poolSize = m_layoutEntry.List.ScrollObjectCount;
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_get_icon_layout_root");
			yield return operation;
			LayoutUGUIRuntime baseRuntime = null;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x10AA1EC
				baseRuntime = instance.GetComponent<LayoutUGUIRuntime>();
				baseRuntime.name = baseRuntime.name.Replace("(Clone)", "_00");
				m_layoutEntry.List.AddScrollObject(instance.GetComponent<SwapScrollListContent>());
			}));
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			for(int i = 1; i < poolSize; i++)
			{
				LayoutUGUIRuntime l = Instantiate(baseRuntime);
				l.name = baseRuntime.name.Replace("00", i.ToString("D2"));
				l.IsLayoutAutoLoad = false;
				l.Layout = baseRuntime.Layout.DeepClone();
				l.UvMan = baseRuntime.UvMan;
				l.LoadLayout();
				m_layoutEntry.List.AddScrollObject(l.GetComponent<SwapScrollListContent>());
			}
			m_layoutEntry.List.Apply();
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			m_layoutEntry.OnClickButtonPrizeList = OnPrizeListButton;
			m_layoutEntry.OnClickButtonRegist = OnRegistButton;
			m_layoutEntry.OnClickButtonContract = OnContractButton;
			m_layoutEntry.OnClickButtonEntry = OnEntryButton;
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			while(!m_layoutEntry.IsLoaded())
				yield return null;
			
		}
	}
}
