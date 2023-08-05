using System.Collections;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;

namespace XeApp.Game.Menu
{
	public class EpisodeDetailScene : TransitionRoot
	{
		private EpisodeDetailWindow m_detail_window; // 0x48
		private PIGBBNDPPJC m_data; // 0x4C
		private const string BundleName = "ly/052.xab";
		private bool m_isLoadBundle; // 0x50
		private bool m_isBeginner; // 0x51
		private const string TutorialInputLimitButtonName = "sw_sel_ep_btn_scene_anim (AbsoluteLayout)";

		// RVA: 0x128539C Offset: 0x128539C VA: 0x128539C Slot: 4
		protected override void Awake()
		{
			base.Awake();
			m_detail_window = transform.Find("EpisodeDetail").GetComponent<EpisodeDetailWindow>();
			m_detail_window.PushSceneListHandler += OnPushSceneListButton;
			this.StartCoroutineWatched(LoadAssetBundle());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DAAA4 Offset: 0x6DAAA4 VA: 0x6DAAA4
		//// RVA: 0x12854E0 Offset: 0x12854E0 VA: 0x12854E0
		private IEnumerator LoadAssetBundle()
		{
			//0xEF1098
			yield return AssetBundleManager.LoadUnionAssetBundle(BundleName);
			IsReady = true;
		}

		// RVA: 0x1285568 Offset: 0x1285568 VA: 0x1285568 Slot: 15
		protected override void OnDeleteCache()
		{
			AssetBundleManager.UnloadAssetBundle(BundleName, false);
		}

		// RVA: 0x12855F8 Offset: 0x12855F8 VA: 0x12855F8 Slot: 12
		protected override void OnStartExitAnimation()
		{
			base.OnStartExitAnimation();
			m_detail_window.Leave();
		}

		// RVA: 0x1285630 Offset: 0x1285630 VA: 0x1285630 Slot: 16
		protected override void OnPreSetCanvas()
		{
			m_isBeginner = false;
			EpisodeDetailArgs arg = Args as EpisodeDetailArgs;
			if(arg != null)
			{
				m_data = arg.data;
				m_isBeginner = arg.isFromBeginner;
			}
			m_data.LEHDLBJJBNC();
			m_data.FBANBDCOEJL();
			m_detail_window.Init(m_data);
			m_detail_window.Enter();
			MenuScene.Instance.StatusWindowControl.ResetHistory();
			base.OnPreSetCanvas();
		}

		// RVA: 0x12857E8 Offset: 0x12857E8 VA: 0x12857E8 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_detail_window.IsPlaying();
		}

		// RVA: 0x1285818 Offset: 0x1285818 VA: 0x1285818 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return !m_detail_window.IsLodingImage();
		}

		// RVA: 0x1285848 Offset: 0x1285848 VA: 0x1285848 Slot: 23
		protected override void OnActivateScene()
		{
			if(m_isBeginner)
			{
				ButtonBase[] buttons = m_detail_window.GetComponentsInChildren<ButtonBase>(true);
				int enableButtonIndex = -1;
				for(int i = 0; i < buttons.Length; i++)
				{
					if(buttons[i].name == "sw_sel_ep_btn_scene_anim (AbsoluteLayout)")
					{
						enableButtonIndex = i;
						break;
					}
				}
				if(enableButtonIndex > -1)
				{
					GameManager.PushBackButtonHandler dymmyBackButton = () =>
					{
						//0xEF0F78
						return;
					};
					GameManager.Instance.AddPushBackButtonHandler(dymmyBackButton);
					BasicTutorialManager.Instance.SetInputLimit(InputLimitButton.Delegate, () =>
					{
						//0xEF0F84
						GameManager.Instance.RemovePushBackButtonHandler(dymmyBackButton);
					}, () =>
					{
						//0xEF102C
						return buttons[enableButtonIndex];
					}, TutorialPointer.Direction.Normal);
				}
			}
		}

		//// RVA: 0x1285C1C Offset: 0x1285C1C VA: 0x1285C1C
		private void OnPushSceneListButton(EpisodeSceneListArgs args)
		{
			args.isFromBeginner = m_isBeginner;
			MenuScene.Instance.Call(TransitionList.Type.SCENE_ABILITY_RELEASE_LIST, args, true);
		}

		// RVA: 0x1285CF0 Offset: 0x1285CF0 VA: 0x1285CF0 Slot: 28
		protected override TransitionArgs GetCallArgsReturn()
		{
			EpisodeDetailBackArgs a = new EpisodeDetailBackArgs();
			a.data = m_data;
			return a;
		}
	}
}
