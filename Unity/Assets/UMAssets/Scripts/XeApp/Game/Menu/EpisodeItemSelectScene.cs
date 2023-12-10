using System;
using System.Collections;
using UnityEngine;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class EpisodeItemSelectScene : TransitionRoot
	{
		private Action mUpdater; // 0x48
		private EpisodeItemSelect m_item_select; // 0x4C
		private PIGBBNDPPJC m_data; // 0x50
		private EpisodeReleasePopupSetting m_release_window = new EpisodeReleasePopupSetting(); // 0x54
		private EpisodeReleaseWindow m_item_use_window; // 0x58
		private bool m_is_loaded_window; // 0x5C
		private EpisodeRewardGet m_reward_get_window; // 0x60

		// RVA: 0xEF7898 Offset: 0xEF7898 VA: 0xEF7898 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			m_item_select = transform.Find("EpisodeItemSelect").GetComponent<EpisodeItemSelect>();
			this.StartCoroutineWatched(LoadEpisodeReleaseWindow());
		}

		// RVA: 0xEF7A00 Offset: 0xEF7A00 VA: 0xEF7A00 Slot: 5
		protected override void Start()
		{
			m_reward_get_window = transform.GetComponent<EpisodeRewardGet>();
			mUpdater = UpdateLoad;
		}

		// RVA: 0xEF7AC4 Offset: 0xEF7AC4 VA: 0xEF7AC4
		private void Update()
		{
			if (mUpdater != null)
				mUpdater();
		}

		//// RVA: 0xEF7AD8 Offset: 0xEF7AD8 VA: 0xEF7AD8
		private void UpdateLoad()
		{
			if(m_reward_get_window.IsLoaded() && m_is_loaded_window)
			{
				IsReady = true;
				mUpdater = UpdateIdle;
			}
		}

		//// RVA: 0xEF7BA0 Offset: 0xEF7BA0 VA: 0xEF7BA0
		private void UpdateIdle()
		{
			return;
		}

		// RVA: 0xEF7BA4 Offset: 0xEF7BA4 VA: 0xEF7BA4 Slot: 12
		protected override void OnStartExitAnimation()
		{
			base.OnStartExitAnimation();
			m_item_select.Leave();
		}

		// RVA: 0xEF7BD8 Offset: 0xEF7BD8 VA: 0xEF7BD8 Slot: 16
		protected override void OnPreSetCanvas()
		{
			base.OnPreSetCanvas();
		}

		// RVA: 0xEF7BE0 Offset: 0xEF7BE0 VA: 0xEF7BE0 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_item_select.IsPlaying();
		}

		// RVA: 0xEF7C0C Offset: 0xEF7C0C VA: 0xEF7C0C Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			EpisodeItemSelectArgs arg = Args as EpisodeItemSelectArgs;
			if(arg != null)
			{
				m_data = arg.data;
				m_item_select.Init(m_data);
				for(int i = 0; i < m_item_select.GetBtnNum(); i++)
				{
					m_item_select.GetBtn(i).ClearOnClickCallback();
					int index = i;
					m_item_select.GetBtn(i).AddOnClickCallback(() =>
					{
						//0xEF85D0
						OnClickUseItem(index);
					});
				}
			}
			else
			{
				if(m_data != null)
				{
					m_item_select.Init(m_data);
				}
			}
			m_reward_get_window.ReStart(null);
			m_item_select.Enter();
			return true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DAD7C Offset: 0x6DAD7C VA: 0x6DAD7C
		//// RVA: 0xEF7974 Offset: 0xEF7974 VA: 0xEF7974
		private IEnumerator LoadEpisodeReleaseWindow()
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0xEF8924
			operation = AssetBundleManager.LoadLayoutAsync(m_release_window.BundleName, m_release_window.AssetName);
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(MenuScene.Instance.m_font, (GameObject instance) =>
			{
				//0xEF83B4
				m_release_window.SetContent(instance);
				m_item_use_window = instance.GetComponent<EpisodeReleaseWindow>();
			}));
			m_release_window.SetParent(transform);
			AssetBundleManager.UnloadAssetBundle(m_release_window.BundleName, false);
			while (m_release_window.Content == null)
				yield return null;
			m_is_loaded_window = true;
		}

		//// RVA: 0xEF7F1C Offset: 0xEF7F1C VA: 0xEF7F1C
		private void OnClickUseItem(int item_type)
		{
			TodoLogger.LogError(1, "TODO");
			TodoLogger.LogNotImplemented("OnClickUseItem");
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DADF4 Offset: 0x6DADF4 VA: 0x6DADF4
		//// RVA: 0xEF8028 Offset: 0xEF8028 VA: 0xEF8028
		//private IEnumerator WaitOpenUseItemWindow(int item_type) { }

		//// RVA: 0xEF80F0 Offset: 0xEF80F0 VA: 0xEF80F0
		//private void OnClickUseItemOK() { }
		
		//[CompilerGeneratedAttribute] // RVA: 0x6DAE7C Offset: 0x6DAE7C VA: 0x6DAE7C
		//// RVA: 0xEF8450 Offset: 0xEF8450 VA: 0xEF8450
		//private void <WaitOpenUseItemWindow>b__18_0(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }
	}
}
