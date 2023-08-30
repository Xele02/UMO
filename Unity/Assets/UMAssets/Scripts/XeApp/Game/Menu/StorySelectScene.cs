using System.Collections;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;

namespace XeApp.Game.Menu
{
	public class StorySelectScene : TransitionRoot
	{
		private LayoutStorySelectController m_storySelectController = new LayoutStorySelectController(); // 0x48
		private StorySelectStageCreater m_stageCreater; // 0x4C
		private bool m_isEndPostSetCanvas; // 0x50
		private int m_prevDivaCount; // 0x54
		private bool m_isNavigation; // 0x58

		// RVA: 0x12E52A4 Offset: 0x12E52A4 VA: 0x12E52A4 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			this.StartCoroutineWatched(LoadLayout());
		}

		// RVA: 0x12E5360 Offset: 0x12E5360 VA: 0x12E5360 Slot: 12
		protected override void OnStartExitAnimation()
		{
			HideNavigation();
			base.OnStartExitAnimation();
		}

		// RVA: 0x12E5448 Offset: 0x12E5448 VA: 0x12E5448 Slot: 18
		protected override void OnPostSetCanvas()
		{
			GameManager.Instance.SelectedGuestData = null;
			m_prevDivaCount = GetHasDivaCount();
			this.StartCoroutineWatched(Setup());
		}

		// RVA: 0x12E5708 Offset: 0x12E5708 VA: 0x12E5708 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			return m_isEndPostSetCanvas;
		}

		// RVA: 0x12E5710 Offset: 0x12E5710 VA: 0x12E5710 Slot: 23
		protected override void OnActivateScene()
		{
			MenuScene.Instance.InputDisable();
			m_stageCreater.In(PrevTransition);
		}

		// RVA: 0x12E57E4 Offset: 0x12E57E4 VA: 0x12E57E4 Slot: 15
		protected override void OnDeleteCache()
		{
			if(m_stageCreater != null)
			{
				m_stageCreater.storySelectController = null;
				Destroy(m_stageCreater.gameObject);
				m_stageCreater = null;
			}
			if(m_storySelectController != null)
			{
				m_storySelectController.Dispose();
				m_storySelectController = null;
			}
			MenuScene.Instance.StoryImageCache.Terminated();
		}

		// RVA: 0x12E5998 Offset: 0x12E5998 VA: 0x12E5998 Slot: 20
		protected override bool OnBgmStart()
		{
			SoundManager.Instance.bgmPlayer.ContinuousPlay(BgmPlayer.MENU_BGM_ID_BASE + 3, 1);
			return true;
		}

		//// RVA: 0x12E5A7C Offset: 0x12E5A7C VA: 0x12E5A7C
		private void SetCallbackButton()
		{
			if (m_storySelectController.layoutBgButton == null)
				return;
			m_storySelectController.layoutBgButton.CallbackButton = () =>
			{
				//0x12E620C
				this.StartCoroutineWatched(Co_ShowBgMode());
				HideNavigation();
			};
			m_storySelectController.layoutBgButton.CallbackScreenTap = () =>
			{
				//0x12E6238
				this.StartCoroutineWatched(Co_CloseBgMode());
				HideNavigation();
			};
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72D2F4 Offset: 0x72D2F4 VA: 0x72D2F4
		//// RVA: 0x12E5BC8 Offset: 0x12E5BC8 VA: 0x12E5BC8
		private IEnumerator Co_ShowBgMode()
		{
			StorySelectBgButtonLayout bgButton;

			//0x12E6788
			bgButton = m_storySelectController.layoutBgButton;
			MenuScene.Instance.InputDisable();
			m_storySelectController.BgVisibleEnable(true);
			m_stageCreater.HideAll();
			MenuScene.Instance.HeaderLeave();
			MenuScene.Instance.FooterLeave();
			yield return null;
			while(bgButton.IsExecuteAnimationList())
				yield return null;
			GameManager.Instance.AddPushBackButtonHandler(OnBackButton);
			MenuScene.Instance.InputEnable();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72D36C Offset: 0x72D36C VA: 0x72D36C
		//// RVA: 0x12E5C74 Offset: 0x12E5C74 VA: 0x12E5C74
		private IEnumerator Co_CloseBgMode()
		{
			StorySelectBgButtonLayout bgButton;

			//0x12E6430
			bgButton = m_storySelectController.layoutBgButton;
			MenuScene.Instance.InputDisable();
			m_storySelectController.BgVisibleEnable(false);
			m_stageCreater.ShowAll();
			MenuScene.Instance.HeaderEnter();
			MenuScene.Instance.FooterEnter();
			GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
			yield return null;
			while (bgButton.IsExecuteAnimationList())
				yield return null;
			MenuScene.Instance.InputEnable();
		}

		//// RVA: 0x12E5D20 Offset: 0x12E5D20 VA: 0x12E5D20
		//private void LeaveUI() { }

		//// RVA: 0x12E5EA4 Offset: 0x12E5EA4 VA: 0x12E5EA4
		//private void EnterUI() { }

		//[IteratorStateMachineAttribute] // RVA: 0x72D3E4 Offset: 0x72D3E4 VA: 0x72D3E4
		//// RVA: 0x12E52D4 Offset: 0x12E52D4 VA: 0x12E52D4
		private IEnumerator LoadLayout()
		{
			//0x12E6F60
			if(m_stageCreater == null)
			{
				m_stageCreater = StorySelectStageCreater.Create(transform);
				m_stageCreater.storySelectController = m_storySelectController;
				m_stageCreater.Initialize();
			}
			bool isLoading = true;
			this.StartCoroutineWatched(m_storySelectController.LoadLayout(transform, MenuScene.Instance.m_bgRootObject.transform, () =>
			{
				//0x12E6420
				isLoading = false;
			}));
			while (isLoading)
				yield return null;
			m_storySelectController.LoadIconImage(m_stageCreater.GetViewDataStageList());
			while(m_storySelectController.IsLoading())
				yield return null;
			m_storySelectController.Setup();
			IsReady = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72D45C Offset: 0x72D45C VA: 0x72D45C
		//// RVA: 0x12E567C Offset: 0x12E567C VA: 0x12E567C
		private IEnumerator Setup()
		{
			//0x12E73B4
			if (!m_stageCreater.IsSetup)
			{
				yield return Co.R(m_stageCreater.Setup());
				yield return Co.R(m_storySelectController.SetupBg(m_stageCreater.page + 1));
				SetCallbackButton();
			}
			else
			{
				yield return Co.R(m_stageCreater.Check());
			}
			MenuScene.Instance.BgControl.StoryBgShow();
			if(PrevTransition != TransitionList.Type.UNLOCK_DIVA)
			{
				m_stageCreater.CallbackEffectEnd = () =>
				{
					//0x12E6264
					MenuScene.Instance.InputEnable();
					if (!m_stageCreater.IsEffectStart)
						return;
					FDDIIKBJNNA.FLKIIDJEJJM(0);
					MenuScene.Instance.HeaderEnter();
					MenuScene.Instance.FooterEnter();
					m_storySelectController.layoutBgButton.Show();
				};
				m_stageCreater.CallbackEffectEnd += () =>
				{
					//0x12E63F0
					this.StartCoroutineWatched(EffectEndAfter());
				};
			}
			m_stageCreater.CallbackEffectOneStart = () =>
			{
				//0x12E6414
				LeaveUI();
			};
			FDDIIKBJNNA.FLKIIDJEJJM(0);
			PGIGNJDPCAH.NNOBACMJHDM(PGIGNJDPCAH.FELLIEJEPIJ.LPBDIINNFEE/*5*/);
			m_isEndPostSetCanvas = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72D4D4 Offset: 0x72D4D4 VA: 0x72D4D4
		//// RVA: 0x12E6008 Offset: 0x12E6008 VA: 0x12E6008
		//private IEnumerator EffectEndAfter() { }

		//// RVA: 0x12E5380 Offset: 0x12E5380 VA: 0x12E5380
		private void HideNavigation()
		{
			if (!m_isNavigation)
				return;
			BasicTutorialManager.Instance.HideCursor();
			BasicTutorialManager.Instance.ChangeCursorLastSibling();
			m_isNavigation = false;
		}

		//// RVA: 0x12E550C Offset: 0x12E550C VA: 0x12E550C
		private int GetHasDivaCount()
		{
			int res = 0;
			for(int i = 0; i < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count; i++)
			{
				if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].CPGFPEDMDEH_Have > 0)
					res++;
			}
			return res;
		}

		//// RVA: 0x12E60B4 Offset: 0x12E60B4 VA: 0x12E60B4
		private void OnBackButton()
		{
			if(m_storySelectController.layoutBgButton != null)
			{
				if(m_storySelectController.layoutBgButton.IsShowBg)
				{
					m_storySelectController.layoutBgButton.PerformClick();
				}
			}
		}
	}
}
