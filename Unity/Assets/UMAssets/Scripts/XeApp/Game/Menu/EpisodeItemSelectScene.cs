using mcrs;
using System;
using System.Collections;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

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
			yield return Co.R(operation.InitializeLayoutCoroutine(MenuScene.Instance.GetFont(), (GameObject instance) =>
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
			MenuScene.Instance.InputDisable();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(WaitOpenUseItemWindow(item_type));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DADF4 Offset: 0x6DADF4 VA: 0x6DADF4
		//// RVA: 0xEF8028 Offset: 0xEF8028 VA: 0xEF8028
		private IEnumerator WaitOpenUseItemWindow(int item_type)
		{
			//0xEF8D6C
			yield return Co.R(m_item_use_window.CO_Init(m_data, item_type));
			MenuScene.Instance.InputEnable();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_release_window.TitleText = bk.GetMessageByLabel("popup_title_episode_02");
			m_release_window.SetParent(transform);
			m_release_window.data = m_data;
			m_release_window.item_type = item_type;
			m_release_window.WindowSize = SizeType.Large;
			m_release_window.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.UsedItem, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(m_release_window, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xEF8450
				if (type != PopupButton.ButtonType.Positive)
					return;
				OnClickUseItemOK();
			}, (IPopupContent content, PopupTabButton.ButtonLabel label) =>
			{
				//0xEF84D8
				(content as PopupTabContents).ChangeContents((int)label);
			}, null, null);
		}

		//// RVA: 0xEF80F0 Offset: 0xEF80F0 VA: 0xEF80F0
		private void OnClickUseItemOK()
		{
			if(m_item_use_window.GetItemUseCount() > 0)
			{
				if(m_data.HADPDBAGEIB(m_item_use_window.GetItemUseType() + 1, m_item_use_window.GetItemUseCount()) > 0)
				{
					int point = m_item_use_window.GetAddEpisodePoint();
					MenuScene.Instance.InputDisable();
					m_data.PFMLAOPEAMJ(m_item_use_window.GetItemUseType() + 1, m_item_use_window.GetItemUseCount(), () =>
					{
						//0xEF8600
						MenuScene.Instance.InputEnable();
						m_data.AFGOBPPKFBF();
						m_item_select.Init(m_data);
						m_reward_get_window.Show(ref m_data, point, CIOECGOMILE.HHCJCDFCLOB.EBEGGFECPOE, (PopupButton.ButtonLabel label) =>
						{
							//0xEF88BC
							m_item_select.Init(m_data);
						}, false);
					});
				}
			}
		}
	}
}
