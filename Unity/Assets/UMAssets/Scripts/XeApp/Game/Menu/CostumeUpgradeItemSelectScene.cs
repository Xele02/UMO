using System.Collections;
using mcrs;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class CostumeUpgradeItemSelectScene : TransitionRoot
	{
		private const int MakinaId = 4;
		private CostumeUpgradeDivaController m_divaController; // 0x48
		private SimpleVoicePlayer m_makinaVoicePlayer; // 0x4C
		private const string BundleName = "ly/128.xab";
		private bool m_isSuccess; // 0x50
		private bool m_isDownLoading; // 0x51
		private CostumeItemSelectWindow m_item_select_window; // 0x54
		private CostumeItemUsePopupSetting m_item_use_popup = new CostumeItemUsePopupSetting(); // 0x58
		private CostumeItemUseWindow m_item_use_window; // 0x5C
		private LFAFJCNKLML m_upgradeData; // 0x60
		private MOEALEGLGCH m_data; // 0x64
		private CostumeRewardGet m_reward_get_window; // 0x68
		private GameObject m_EffectPrefab; // 0x6C
		private GameObject m_EffectInstance; // 0x70

		// RVA: 0x16F3FA8 Offset: 0x16F3FA8 VA: 0x16F3FA8 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			m_divaController = GetComponent<CostumeUpgradeDivaController>();
			this.StartCoroutineWatched(Co_Initilize());
		}

		// RVA: 0x16F40C0 Offset: 0x16F40C0 VA: 0x16F40C0 Slot: 5
		protected override void Start()
		{
			m_reward_get_window = transform.GetComponent<CostumeRewardGet>();
		}

		// RVA: 0x16F4148 Offset: 0x16F4148 VA: 0x16F4148
		private void Update()
		{
			return;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CEB8C Offset: 0x6CEB8C VA: 0x6CEB8C
		// // RVA: 0x16F4034 Offset: 0x16F4034 VA: 0x16F4034
		private IEnumerator Co_Initilize()
		{
			//0x16F5870
			yield return Co.R(AssetBundleManager.LoadUnionAssetBundle("ly/128.xab"));
			yield return this.StartCoroutineWatched(Co_LoadEffect());
			m_item_select_window = transform.Find("CostumeUpgradeItemSelect").GetComponent<CostumeItemSelectWindow>();
			yield return this.StartCoroutineWatched(LoadReleaseWindow());
			m_makinaVoicePlayer = GetComponent<SimpleVoicePlayer>();
			bool isEndChangeCueSheet = false;
			m_makinaVoicePlayer.RequestChangeCueSheet("cs_cosupg", () =>
			{
				//0x16F5570
				isEndChangeCueSheet = true;
			});
			while(!isEndChangeCueSheet)
				yield return null;
			m_reward_get_window.m_voicePlayer = m_makinaVoicePlayer;
			IsReady = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CEC04 Offset: 0x6CEC04 VA: 0x6CEC04
		// // RVA: 0x16F416C Offset: 0x16F416C VA: 0x16F416C
		private IEnumerator LoadReleaseWindow()
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x16F6CA4
			operation = AssetBundleManager.LoadLayoutAsync(m_item_use_popup.BundleName, m_item_use_popup.AssetName);
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x16F5138
				m_item_use_popup.SetContent(instance);
				m_item_use_window = instance.GetComponent<CostumeItemUseWindow>();
			}));
			m_item_use_popup.SetParent(transform);
			AssetBundleManager.UnloadAssetBundle(m_item_use_popup.BundleName, false);
			yield return new WaitUntil(() =>
			{
				//0x16F51D8
				return m_item_use_popup.Content != null;
			});
			yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CEC7C Offset: 0x6CEC7C VA: 0x6CEC7C
		// // RVA: 0x16F4218 Offset: 0x16F4218 VA: 0x16F4218
		private IEnumerator Co_LoadEffect()
		{
			string bundleName; // 0x14
			string assetName; // 0x18
			AssetBundleLoadAllAssetOperationBase operation; // 0x1C

			//0x16F5CF4
			bundleName = "ef/cmn.xab";
			assetName = "model_loading";
			operation = AssetBundleManager.LoadAllAssetAsync(bundleName);
			yield return operation;
			m_EffectPrefab = operation.GetAsset<GameObject>(assetName);
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			m_EffectInstance = Instantiate(m_EffectPrefab, new Vector3(-6.5f, 0, 0), m_EffectPrefab.transform.rotation);
			m_EffectInstance.SetActive(true);
			yield return null;
		}

		// RVA: 0x16F42C4 Offset: 0x16F42C4 VA: 0x16F42C4 Slot: 16
		protected override void OnPreSetCanvas()
		{
			CostumeUpgradeItemSelectSceneArgs arg = Args as CostumeUpgradeItemSelectSceneArgs;
			if(arg == null)
				return;
			m_upgradeData = arg.upgradeData;
			m_data = arg.data;
			m_reward_get_window.m_isPrevCostumeSelect = arg.isPrevCostumeSelect;
		}

		// RVA: 0x16F43E8 Offset: 0x16F43E8 VA: 0x16F43E8 Slot: 18
		protected override void OnPostSetCanvas()
		{
			return;
		}

		// RVA: 0x16F43EC Offset: 0x16F43EC VA: 0x16F43EC Slot: 14
		protected override void OnDestoryScene()
		{
			m_divaController.Release();
			m_EffectInstance.SetActive(false);
		}

		// RVA: 0x16F443C Offset: 0x16F443C VA: 0x16F443C Slot: 15
		protected override void OnDeleteCache()
		{
			AssetBundleManager.UnloadAssetBundle("ly/128.xab", false);
		}

		// RVA: 0x16F44CC Offset: 0x16F44CC VA: 0x16F44CC Slot: 23
		protected override void OnActivateScene()
		{
			return;
		}

		// RVA: 0x16F44D0 Offset: 0x16F44D0 VA: 0x16F44D0 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			m_isSuccess = false;
			m_isDownLoading = true;
			this.StartCoroutineWatched(Co_LoadResource());
		}

		// RVA: 0x16F458C Offset: 0x16F458C VA: 0x16F458C Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_isDownLoading;
		}

		// RVA: 0x16F45A0 Offset: 0x16F45A0 VA: 0x16F45A0 Slot: 12
		protected override void OnStartExitAnimation()
		{
			m_item_select_window.Leave();
		}

		// RVA: 0x16F45CC Offset: 0x16F45CC VA: 0x16F45CC Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_item_select_window.IsPlaying();
		}

		// RVA: 0x16F45FC Offset: 0x16F45FC VA: 0x16F45FC Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			EnterItemSelectWindow();
			if(PrevTransition == TransitionList.Type.COSTUME_SELECT)
			{
				m_upgradeData.AHLONCCGGHP();
				m_reward_get_window.ReShow(m_upgradeData, CloseCostumeCompWindow);
			}
			else
			{
				m_reward_get_window.Restart(CloseCostumeCompWindow);
			}
			return true;
		}

		// // RVA: 0x16F474C Offset: 0x16F474C VA: 0x16F474C
		public void EnterItemSelectWindow()
		{
			m_item_select_window.Init(1);
			for(int i = 0; i < m_item_select_window.GetButtonNum(); i++)
			{
				int index = i;
				m_item_select_window.GetButton(i).ClearOnClickCallback();
				m_item_select_window.GetButton(i).AddOnClickCallback(() =>
				{
					//0x16F557C
					this.StartCoroutineWatched(Co_ShowUseItemWindow(index));
				});
				m_item_select_window.GetDetailButton(i).ClearOnClickCallback();
				m_item_select_window.GetDetailButton(i).AddOnClickCallback(() =>
				{
					//0x16F55BC
					m_item_select_window.ShowItemDetailWindow(index);
				});
			}
			m_item_select_window.Enter();
		}

		// // RVA: 0x16F4A08 Offset: 0x16F4A08 VA: 0x16F4A08
		public bool CloseCostumeCompWindow(PopupButton.ButtonLabel label)
		{
			m_upgradeData.AHLONCCGGHP();
			if(m_upgradeData.GKIKAABHAAD_Level < m_upgradeData.LLLCMHENKKN_LevelMax)
			{
				if(m_upgradeData.CDOCOLOKCJK())
					return false;
			}
			MenuScene.Instance.Return(false);
			return true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CECF4 Offset: 0x6CECF4 VA: 0x6CECF4
		// // RVA: 0x16F4500 Offset: 0x16F4500 VA: 0x16F4500
		private IEnumerator Co_LoadResource()
		{
			//0x16F606C
			m_EffectInstance.SetActive(true);
			m_divaController.TryInstall(m_upgradeData.AHHJLDLAPAN_DivaId, m_upgradeData.DAJGPBLEEOB_PrismCostumeId);
			while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
			m_isDownLoading = false;
			m_divaController.Initialize(CostumeUpgradeDivaController.Controlype.ItemSelect, m_upgradeData.AHHJLDLAPAN_DivaId, m_upgradeData.DAJGPBLEEOB_PrismCostumeId, 0);
			m_divaController.LoadDivaResource();
			yield return new WaitUntil(() =>
			{
				//0x16F528C
				return m_divaController.isLoadedModel;
			});
			m_EffectInstance.SetActive(false);
			m_divaController.StartIdleMotion();
			m_isSuccess = true;
		}

		// // RVA: 0x16F4B6C Offset: 0x16F4B6C VA: 0x16F4B6C
		// private void OnClickSelectItem(int item_type) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6CED6C Offset: 0x6CED6C VA: 0x6CED6C
		// // RVA: 0x16F4B90 Offset: 0x16F4B90 VA: 0x16F4B90
		private IEnumerator Co_ShowUseItemWindow(int item_type)
		{
			//0x16F6478
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			m_makinaVoicePlayer.PlayVoiceRandom(CostumeUpgradeVoiceDataTable.VoiceSetting(CostumeUpgradeVoiceDataTable.VoiceType.ItemSelect, m_upgradeData.AHHJLDLAPAN_DivaId));
			MenuScene.Instance.InputDisable();
			yield return Co.R(m_item_use_window.CO_Init(m_upgradeData, item_type));
			MenuScene.Instance.InputEnable();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_item_use_popup.TitleText = bk.GetMessageByLabel("costume_upgrade_item_use_title_text");
			m_item_use_popup.SetParent(transform);
			m_item_use_popup.data = m_upgradeData;
			m_item_use_popup.item_type = item_type;
			m_item_use_popup.WindowSize = SizeType.Large;
			m_item_use_popup.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.UsedItem, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(m_item_use_popup, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x16F52B0
				if(type == PopupButton.ButtonType.Positive)
				{
					OnClickUseItemOK();
				}
			}, (IPopupContent content, PopupTabButton.ButtonLabel label) =>
			{
				//0x16F5338
				(content as PopupTabContents).ChangeContents((int)label);
			}, null, null);
		}

		// // RVA: 0x16F4C58 Offset: 0x16F4C58 VA: 0x16F4C58
		private void OnClickUseItemOK()
		{
			int max = m_item_use_window.GetItemUseCount();
			if(max > 0)
			{
				if(m_data.DLJJACACBDI(m_upgradeData.JPIDIENBGKH_CostumeId, m_item_use_window.GetItemUseType() + 1, max) > 0)
				{
					if(!PGIGNJDPCAH.MNANNMDBHMP(() =>
					{
						//0x16F5430
						MenuScene.Instance.GotoLoginBonus();
					}, () =>
					{
						//0x16F54CC
						MenuScene.Instance.GotoTitle();
					}))
					{
						int point = m_item_use_window.GetAddCostumePoint();
						int prev_offer_difficult = KDHGBOOECKC.HHCJCDFCLOB.BCACCAGCPCO();
						MenuScene.Instance.InputDisable();
						m_data.CALNLFGDMEE(m_upgradeData.JPIDIENBGKH_CostumeId, m_item_use_window.GetItemUseType() + 1, max, () =>
						{
							//0x16F5608
							MenuScene.Instance.InputEnable();
							GameManager.Instance.ResetViewPlayerData();
							m_item_select_window.Init(m_upgradeData.AHHJLDLAPAN_DivaId);
							LFAFJCNKLML.HEGEKFMJNCC(m_upgradeData.AHHJLDLAPAN_DivaId);
							m_reward_get_window.Show(ref m_upgradeData, point, prev_offer_difficult, CloseCostumeCompWindow);
						});
					}
				}
			}
		}
	}
}
