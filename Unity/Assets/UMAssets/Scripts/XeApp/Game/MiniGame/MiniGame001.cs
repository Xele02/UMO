using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;
using XeSys;
using XeSys.uGUI;

namespace XeApp.Game.MiniGame
{
	public class MiniGame001 : MonoBehaviour
	{
		private interface MiniGameObj
		{
			// RVA: -1 Offset: -1 Slot: 0
			//public abstract void OnUpdate();
		}

		private MiniGameScene m_scene; // 0xC
		private GKFPMAPFHIK_ViewEventAprilFoolMiniGameData m_viewShootingData; // 0x10
		private ShootingResulData m_resultData; // 0x14
		[SerializeField]
		private VirtualPad virtualPad; // 0x18
		[SerializeField]
		private UGUIFader fadePlane; // 0x1C
		[SerializeField]
		private RectTransform m_mainSceenSize; // 0x20
		private ShootingTitleLayout m_titleLayout; // 0x24
		private ShootingMainLayout m_mainLayout; // 0x28
		private ShootingResultLayout m_resultLayout; // 0x2C
		private ShootingFrameUITitleLayout m_frameUiTitleLayout; // 0x30
		private ShootingFrameUIMainLayout m_frameUiMainLayout; // 0x34
		private ShootingScreenButton m_screenButton; // 0x38
		private ButtonBase[] m_shootingButtons; // 0x3C
		private ShootingSoundManager m_soundManager; // 0x40
		private ShootingSecretCommand m_secretCommand; // 0x44
		private ShootingEffectManager m_effectManager; // 0x48
		private ShootingCollisionManager m_coliisionManager; // 0x4C
		private ShootingPlayerCharacter m_player; // 0x50
		private ShootingBulletManager m_bulletManager; // 0x54
		private ShootingEnemyManager m_enemyManager; // 0x58
		private ShootingItemManager m_itemManager; // 0x5C
		private ShootingEmersionManager m_emersioManager; // 0x60
		private ShootingScrollBg[] m_scrollBg; // 0x64
		private ShootingTaskManager m_systemManager; // 0x68
		public ShootingTaskManager m_applicationManager; // 0x6C
		protected List<int> m_helpId = new List<int>(2); // 0x70
		private bool m_isClear; // 0x74
		private bool m_isPause; // 0x75
		private Coroutine m_bgmCoroutine; // 0x78
		private Action<float> m_update; // 0x7C

		// RVA: 0x1CE9C5C Offset: 0x1CE9C5C VA: 0x1CE9C5C
		public void OnDestroy()
		{
			return;
		}

		// RVA: 0x1CE9C60 Offset: 0x1CE9C60 VA: 0x1CE9C60
		private void OnApplicationPause(bool pauseStatus)
		{
			Pause();
		}

		// RVA: 0x1CEA288 Offset: 0x1CEA288 VA: 0x1CEA288
		private void Awake()
		{
			GameManager.Instance.SetFPS(30);
			fadePlane.gameObject.SetActive(true);
			fadePlane.Fade(0, 0);
			m_viewShootingData = new GKFPMAPFHIK_ViewEventAprilFoolMiniGameData();
			m_viewShootingData.KHEKNNFCAOI();
			m_resultData = new ShootingResulData();
			m_resultData.Initialize();
			m_titleLayout = GetComponentInChildren<ShootingTitleLayout>(true);
			m_mainLayout = GetComponentInChildren<ShootingMainLayout>(true);
			m_resultLayout = GetComponentInChildren<ShootingResultLayout>(true);
			m_frameUiTitleLayout = GetComponentInChildren<ShootingFrameUITitleLayout>(true);
			m_frameUiTitleLayout.onCleckSceneBackBotton = BackScene;
			m_frameUiTitleLayout.onCleckHelpBotton = HelpButton;
			m_frameUiMainLayout = GetComponentInChildren<ShootingFrameUIMainLayout>(true);
			m_frameUiMainLayout.onCleckPauseBotton = PauseButton;
			m_screenButton = GetComponentInChildren<ShootingScreenButton>(true);
			m_screenButton.onClickChangeSceneButton = ChangeSceneButton;
			m_shootingButtons = GetComponentsInChildren<ButtonBase>(true);
			m_soundManager = GetComponentInChildren<ShootingSoundManager>(true);
			m_secretCommand = GetComponentInChildren<ShootingSecretCommand>(true);
			m_secretCommand.VirtualPad = virtualPad;
			m_secretCommand.SuccessCallBack = CommandSuccess;
			m_effectManager = GetComponentInChildren<ShootingEffectManager>(true);
			m_effectManager.OnAwake();
			m_coliisionManager = GetComponentInChildren<ShootingCollisionManager>(true);
			m_coliisionManager.OnAwake();
			m_bulletManager = GetComponentInChildren<ShootingBulletManager>(true);
			m_bulletManager.MainScreen = m_mainSceenSize;
			m_bulletManager.CollisionManager = m_coliisionManager;
			m_bulletManager.OnAwake();
			m_player = GetComponentInChildren<ShootingPlayerCharacter>(true);
			m_player.VirtualPad = virtualPad;
			m_player.CollisionManager = m_coliisionManager;
			m_player.BulletManager = m_bulletManager;
			m_player.MainScreen = m_mainSceenSize;
			m_player.SoundManager = m_soundManager;
			m_player.SecretCommand = m_secretCommand;
			m_player.OnAwake();
			m_itemManager = GetComponentInChildren<ShootingItemManager>(true);
			m_itemManager.ResulData = m_resultData;
			m_itemManager.CollisionManager = m_coliisionManager;
			m_itemManager.MainScreen = m_mainSceenSize;
			m_itemManager.OnAwake();
			m_enemyManager = GetComponentInChildren<ShootingEnemyManager>(true);
			m_enemyManager.CollisionManager = m_coliisionManager;
			m_enemyManager.BulletManager = m_bulletManager;
			m_enemyManager.Player = m_player;
			m_enemyManager.MainScreen = m_mainSceenSize;
			m_enemyManager.ResulData = m_resultData;
			m_enemyManager.EffectManager = m_effectManager;
			m_enemyManager.SoundManager = m_soundManager;
			m_enemyManager.ItemManager = m_itemManager;
			m_enemyManager.OnAwake();
			m_emersioManager = GetComponentInChildren<ShootingEmersionManager>(true);
			m_emersioManager.EnemyManager = m_enemyManager;
			m_emersioManager.ItemManager = m_itemManager;
			m_emersioManager.StageNum = MiniGameScene.stageNum;
			m_emersioManager.OnAwake();
			m_scrollBg = GetComponentsInChildren<ShootingScrollBg>(true);
			for (int i = 0; i < m_scrollBg.Length; i++)
			{
				m_scrollBg[i].OnAwake();
			}
			m_systemManager = new ShootingTaskManager();
			m_applicationManager = new ShootingTaskManager();
			m_update = EventSetUpInUpdate;
		}

		// RVA: 0x1CEAE54 Offset: 0x1CEAE54 VA: 0x1CEAE54
		private void Start()
		{
			m_scene = transform.parent.GetComponentInParent<MiniGameScene>();
			m_effectManager.OnStart();
			m_coliisionManager.OnStart();
			m_bulletManager.OnStart();
			m_player.OnStart();
			m_itemManager.OnStart();
			m_enemyManager.OnStart();
			m_emersioManager.OnStart();
			m_scrollBg = GetComponentsInChildren<ShootingScrollBg>(true);
			for (int i = 0; i < m_scrollBg.Length; i++)
			{
				m_scrollBg[i].OnStart();
			}
		}

		// RVA: 0x1CEB0C0 Offset: 0x1CEB0C0 VA: 0x1CEB0C0
		private void Update()
		{
			float t = 1.0f / Application.targetFrameRate;
			if(m_update != null)
			{
				m_update(t);
			}
			m_systemManager.OnUpdate(t);
			m_applicationManager.OnUpdate(t);
			m_systemManager.OnLateUpdate(t);
			m_applicationManager.OnLateUpdate(t);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6B1968 Offset: 0x6B1968 VA: 0x6B1968
		//// RVA: 0x1CEB1E4 Offset: 0x1CEB1E4 VA: 0x1CEB1E4
		public IEnumerator Fade(float endAlpha)
		{
			//0x1CEE08C
			fadePlane.Fade(1, endAlpha);
			while (fadePlane.isFading)
				yield return null;
		}

		//// RVA: 0x1CEB2B8 Offset: 0x1CEB2B8 VA: 0x1CEB2B8
		private void WaitUpdate(float elapsedTime)
		{
			return;
		}

		//// RVA: 0x1CEB2BC Offset: 0x1CEB2BC VA: 0x1CEB2BC
		private void EventSetUpInUpdate(float elapsedTime)
		{
			m_update = WaitUpdate;
			this.StartCoroutineWatched(EventSetUpIn());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6B19E0 Offset: 0x6B19E0 VA: 0x6B19E0
		//// RVA: 0x1CEB368 Offset: 0x1CEB368 VA: 0x1CEB368
		private IEnumerator EventSetUpIn()
		{
			AMLGMLNGMFB_EventAprilFool controller;

			//0x1CEDA28
			ShootingButtonDisable();
			bool done = false;
			bool err = false;
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			controller = m_viewShootingData.OEGDCBLNNFF(time, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/);
			if(controller != null)
			{
				controller.ADACMHAHHKC_PreSetupEventHome(() =>
				{
					//0x1CED040
					done = true;
				}, () =>
				{
					//0x1CED04C
					done = true;
					err = true;
				});
				while (!done)
					yield return null;
				if(err)
				{
					m_scene.GotoTitle();
					yield break;
				}
			}
			done = false;
			err = false;
			CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
			{
				//0x1CED058
				done = true;
			}, () =>
			{
				//0x1CED064
				done = true;
				err = true;
			}, null);
			while (!done)
				yield return null;
			if (err)
			{
				m_scene.GotoTitle();
				yield break;
			}
			m_helpId.Clear();
			if(controller != null)
			{
				if(controller.CMPEJEHCOEI)
				{
					int id = controller.HLOGNJNGDJO_GetHelpId(0);
					if(id > 0)
					{
						m_helpId.Add(id);
					}
				}
				controller.CMPEJEHCOEI = false;
			}
			m_update = ResourceInstallInUpdate;
			yield return null;
		}

		//// RVA: 0x1CEB414 Offset: 0x1CEB414 VA: 0x1CEB414
		private void ResourceInstallInUpdate(float elapsedTime)
		{
			m_update = WaitUpdate;
			this.StartCoroutineWatched(ResourceInstallIn());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6B1A58 Offset: 0x6B1A58 VA: 0x6B1A58
		//// RVA: 0x1CEB4C0 Offset: 0x1CEB4C0 VA: 0x1CEB4C0
		private IEnumerator ResourceInstallIn()
		{
			//0x1CEF368
			fadePlane.gameObject.SetActive(true);
			fadePlane.Fade(0, 0);
			m_titleLayout.Enter();
			GameManager.Instance.SetTouchEffectVisible(false);
			m_soundManager.InstallCueSheet();
			while (!m_soundManager.IsReady())
				yield return null;
			while (KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
			GameManager.FadeIn(0.4f);
			while (GameManager.IsFading())
				yield return null;
			m_update = TitleInUpdate;
			yield return null;
		}

		//// RVA: 0x1CEB56C Offset: 0x1CEB56C VA: 0x1CEB56C
		private void TitleInUpdate(float elapsedTime)
		{
			m_update = WaitUpdate;
			ShootingGameSceneState.SceneState = ShootingGameSceneState.GameSceneState.Title;
			this.StartCoroutineWatched(TitleIn());
		}

		//// RVA: 0x1CEB760 Offset: 0x1CEB760 VA: 0x1CEB760
		private void TitleMainUpdate(float elapsedTime)
		{
			m_secretCommand.OnUpdate(elapsedTime);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6B1AD0 Offset: 0x6B1AD0 VA: 0x6B1AD0
		//// RVA: 0x1CEB6D4 Offset: 0x1CEB6D4 VA: 0x1CEB6D4
		private IEnumerator TitleIn()
		{
			int i;

			//0x1CF0200
			m_soundManager.BgmPlay(ShootingSoundManager.BGM_ID.Title);
			m_titleLayout.Enter();
			m_frameUiTitleLayout.Enter();
			GameManager.Instance.AddPushBackButtonHandler(TitleBackButton);
			yield return Co.R(Fade(0));
			for(i = 0; i < m_helpId.Count; i++)
			{
				yield return Co.R(TutorialManager.ShowTutorial(m_helpId[i], () =>
				{
					//0x1CED034
					return;
				}));
			}
			m_helpId.Clear();
			m_secretCommand.ResetParam();
			ShootingButtonEnable();
			m_update = TitleMainUpdate;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6B1B48 Offset: 0x6B1B48 VA: 0x6B1B48
		//// RVA: 0x1CEB7B4 Offset: 0x1CEB7B4 VA: 0x1CEB7B4
		private IEnumerator TitleOut()
		{
			//0x1CF06E4
			if (m_scene.CheckDateLineAndAssetUpdate())
				yield break;
			ShootingButtonDisable();
			GameManager.Instance.RemovePushBackButtonHandler(TitleBackButton);
			m_soundManager.BgmFadeOut(1, null);
			yield return Co.R(Fade(1));
			m_titleLayout.Leave();
			m_frameUiTitleLayout.Leave();
			m_update = MainInUpdate;
		}

		//// RVA: 0x1CEB860 Offset: 0x1CEB860 VA: 0x1CEB860
		private void MainInUpdate(float elapsedTime)
		{
			m_update = WaitUpdate;
			this.StartCoroutineWatched(MainIn());
		}

		//// RVA: 0x1CEB998 Offset: 0x1CEB998 VA: 0x1CEB998
		private void MainUpdate(float elapsedTime)
		{
			m_mainLayout.LayoutUpdate(m_resultData.Score);
			if(ShootingGameSceneState.SceneState == ShootingGameSceneState.GameSceneState.GameOver)
			{
				m_update = WaitUpdate;
				this.StartCoroutineWatched(MainGameOver());
			}
			else if(ShootingGameSceneState.SceneState == ShootingGameSceneState.GameSceneState.GameClear)
			{
				m_update = WaitUpdate;
				this.StartCoroutineWatched(MainGameClear());
			}
			if(ShootingGameSceneState.MainSceneState == ShootingGameSceneState.GameMainState.BossEntry)
			{
				m_bgmCoroutine = this.StartCoroutineWatched(MainBossEntry());
			}
		}

		//// RVA: 0x1CEBE28 Offset: 0x1CEBE28 VA: 0x1CEBE28
		private void MainOutUpdate(float elapsedTime)
		{
			m_update = WaitUpdate;
			this.StartCoroutineWatched(MainOut());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6B1BC0 Offset: 0x6B1BC0 VA: 0x6B1BC0
		//// RVA: 0x1CEB90C Offset: 0x1CEB90C VA: 0x1CEB90C
		private IEnumerator MainIn()
		{
			//0x1CEE6D8
			bool m_isPause = false;
			ShootingGameSceneState.MainSceneState = ShootingGameSceneState.GameMainState.Normal;
			m_soundManager.BgmPlay(ShootingSoundManager.BGM_ID.Main);
			m_viewShootingData.KHEKNNFCAOI();
			m_resultData.Initialize();
			m_effectManager.Initialize();
			m_coliisionManager.Initialize();
			m_emersioManager.Initialize();
			m_player.Initialize();
			m_enemyManager.Initialize();
			m_bulletManager.Initialize();
			m_itemManager.Initialize();
			for(int i = 0; i < m_scrollBg.Length; i++)
			{
				m_scrollBg[i].Initialize();
			}
			while (!m_emersioManager.IsReady)
				yield return null;
			m_applicationManager.AddTask(m_emersioManager);
			m_applicationManager.AddTask(m_player);
			m_applicationManager.AddTask(m_enemyManager);
			m_applicationManager.AddTask(m_bulletManager);
			m_applicationManager.AddTask(m_coliisionManager);
			m_applicationManager.AddTask(m_effectManager);
			m_applicationManager.AddTask(m_itemManager);
			for(int i = 0; i < m_scrollBg.Length; i++)
			{
				m_applicationManager.AddTask(m_scrollBg[i]);
			}
			m_frameUiMainLayout.Enter();
			m_mainLayout.LayoutUpdate(0);
			m_mainLayout.Enter(m_secretCommand.IsSecretCommand);
			yield return Co.R(Fade(0));
			ShootingButtonEnable();
			GameManager.Instance.AddPushBackButtonHandler(MainBackButton);
			ShootingGameSceneState.SceneState = ShootingGameSceneState.GameSceneState.MainScene;
			m_update = MainUpdate;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6B1C38 Offset: 0x6B1C38 VA: 0x6B1C38
		//// RVA: 0x1CEBC20 Offset: 0x1CEBC20 VA: 0x1CEBC20
		private IEnumerator MainGameClear()
		{
			//0x1CEE498
			m_mainLayout.GameClearEnter();
			yield return Co.R(ChangeMainOut());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6B1CB0 Offset: 0x6B1CB0 VA: 0x6B1CB0
		//// RVA: 0x1CEBCAC Offset: 0x1CEBCAC VA: 0x1CEBCAC
		private IEnumerator MainGameOver()
		{
			//0x1CEE5B8
			m_mainLayout.GameOverEnter();
			yield return Co.R(ChangeMainOut());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6B1D28 Offset: 0x6B1D28 VA: 0x6B1D28
		//// RVA: 0x1CEBFC0 Offset: 0x1CEBFC0 VA: 0x1CEBFC0
		private IEnumerator MainRetry()
		{
			//0x1CEF210
			ShootingGameSceneState.SceneState = ShootingGameSceneState.GameSceneState.Retry;
			yield return Co.R(ChangeMainOut());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6B1DA0 Offset: 0x6B1DA0 VA: 0x6B1DA0
		//// RVA: 0x1CEC06C Offset: 0x1CEC06C VA: 0x1CEC06C
		private IEnumerator ChangeMainOut()
		{
			//0x1CED68C
			if (m_bgmCoroutine != null)
				this.StopCoroutineWatched(m_bgmCoroutine);
			m_bgmCoroutine = null;
			ShootingGameSceneState.MainSceneState = ShootingGameSceneState.GameMainState.None;
			ShootingButtonDisable();
			GameManager.Instance.RemovePushBackButtonHandler(MainBackButton);
			m_coliisionManager.OnSleep();
			m_applicationManager.RemoveTask(m_coliisionManager);
			m_soundManager.BgmFadeOut(1, null);
			yield return new WaitForSeconds(1);
			m_update = MainOutUpdate;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6B1E18 Offset: 0x6B1E18 VA: 0x6B1E18
		//// RVA: 0x1CEBD9C Offset: 0x1CEBD9C VA: 0x1CEBD9C
		private IEnumerator MainBossEntry()
		{
			//0x1CEE1FC
			ShootingGameSceneState.MainSceneState = ShootingGameSceneState.GameMainState.BossMain;
			bool isStop = false;
			m_soundManager.BgmFadeOut(1, () =>
			{
				//0x1CED078
				isStop = true;
			});
			while (!isStop)
				yield return null;
			m_soundManager.BgmPlay(ShootingSoundManager.BGM_ID.MainBoss);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6B1E90 Offset: 0x6B1E90 VA: 0x6B1E90
		//// RVA: 0x1CEBED4 Offset: 0x1CEBED4 VA: 0x1CEBED4
		private IEnumerator MainOut()
		{
			//0x1CEEEAC
			yield return Co.R(Fade(1));
			m_mainLayout.Leave();
			m_frameUiMainLayout.Leave();
			m_emersioManager.OnSleep();
			m_player.OnSleep();
			m_enemyManager.OnSleep();
			m_bulletManager.OnSleep();
			m_effectManager.OnSleep();
			m_itemManager.OnSleep();
			RemoveMainTask();
			m_isClear = ShootingGameSceneState.SceneState == ShootingGameSceneState.GameSceneState.GameClear;
			m_update = RetryOrResultInUpdate;
		}

		//// RVA: 0x1CEC158 Offset: 0x1CEC158 VA: 0x1CEC158
		private void RemoveMainTask()
		{
			m_applicationManager.RemoveTask(m_emersioManager);
			m_applicationManager.RemoveTask(m_player);
			m_applicationManager.RemoveTask(m_enemyManager);
			m_applicationManager.RemoveTask(m_bulletManager);
			m_applicationManager.RemoveTask(m_coliisionManager);
			m_applicationManager.RemoveTask(m_effectManager);
			m_applicationManager.RemoveTask(m_itemManager);
			for(int i = 0; i < m_scrollBg.Length; i++)
			{
				m_applicationManager.RemoveTask(m_scrollBg[i]);
			}
		}

		//// RVA: 0x1CEC308 Offset: 0x1CEC308 VA: 0x1CEC308
		private void AddMainTask()
		{
			m_applicationManager.AddTask(m_emersioManager);
			m_applicationManager.AddTask(m_player);
			m_applicationManager.AddTask(m_enemyManager);
			m_applicationManager.AddTask(m_bulletManager);
			m_applicationManager.AddTask(m_coliisionManager);
			m_applicationManager.AddTask(m_effectManager);
			m_applicationManager.AddTask(m_itemManager);
			for(int i = 0; i < m_scrollBg.Length; i++)
			{
				m_applicationManager.AddTask(m_scrollBg[i]);
			}
		}

		//// RVA: 0x1CEC4B8 Offset: 0x1CEC4B8 VA: 0x1CEC4B8
		private void RetryOrResultInUpdate(float elapsedTime)
		{
			if (ShootingGameSceneState.SceneState == ShootingGameSceneState.GameSceneState.Retry)
			{
				m_update = TitleInUpdate;
			}
			else
			{
				m_update = ResultInUpdate;
			}
		}

		//// RVA: 0x1CEC5C4 Offset: 0x1CEC5C4 VA: 0x1CEC5C4
		private void ResultInUpdate(float elapsedTime)
		{
			ShootingGameSceneState.SceneState = ShootingGameSceneState.GameSceneState.Result;
			m_update = WaitUpdate;
			this.StartCoroutineWatched(ResultIn());
		}

		//// RVA: 0x1CEC754 Offset: 0x1CEC754 VA: 0x1CEC754
		private void ResultMainUpdate(float elapsedTime)
		{
			return;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6B1F08 Offset: 0x6B1F08 VA: 0x6B1F08
		//// RVA: 0x1CEC6C8 Offset: 0x1CEC6C8 VA: 0x1CEC6C8
		private IEnumerator ResultIn()
		{
			int score; // 0x18
			int highScore; // 0x1C
			bool isUseCommandScore; // 0x20
			bool isUseCommandHighScore; // 0x21

			//0x1CEF750
			for(int i = 0; i < m_scrollBg.Length; i++)
			{
				m_applicationManager.AddTask(m_scrollBg[i]);
			}
			m_resultLayout.PlayerEnter();
			yield return Co.R(Fade(0));
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			AMLGMLNGMFB_EventAprilFool af = m_viewShootingData.OEGDCBLNNFF(time, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/);
			score = m_resultData.Score;
			highScore = m_viewShootingData.LGDLEHHOIEL_HighScore;
			isUseCommandScore = false;
			isUseCommandHighScore = false;
			if(af != null)
			{
				AMLGMLNGMFB_EventAprilFool.JPGMKBANFGF data = new AMLGMLNGMFB_EventAprilFool.JPGMKBANFGF();
				data.BCGLDMKODLC_IsClear = m_isClear;
				data.KNIFCANOHOC_Score = score;
				data.CHPIFIEEEEC_IsSecretCommand = m_secretCommand.IsSecretCommand;
				af.LPFLADBKPNL(data, false);
				score = af.MMICFFPMHIC.KNIFCANOHOC_Score;
				highScore = af.MMICFFPMHIC.LGDLEHHOIEL_HighScore;
				isUseCommandScore = af.MMICFFPMHIC.PIBCFBBLHBB_IsUseCommandScore;
				isUseCommandHighScore = af.MMICFFPMHIC.LNDLJBINJDE_IsUseCommandHighScore;
			}
			bool isSave = true;
			CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
			{
				//0x1CED08C
				isSave = false;
			}, () =>
			{
				//0x1CED098
				m_scene.GotoTitle();
			}, null);
			while (isSave)
				yield return null;
			yield return new WaitForSeconds(0.5f);
			m_resultLayout.ResultEnter();
			yield return new WaitForSeconds(0.5f);
			m_resultLayout.HighScoreEnter(highScore, isUseCommandHighScore);
			yield return new WaitForSeconds(0.5f);
			m_resultLayout.ScoreEnter(score, isUseCommandScore);
			yield return new WaitForSeconds(0.5f);
			m_resultLayout.TouchScreenEnter();
			ShootingButtonEnable();
			m_update = ResultMainUpdate;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6B1F80 Offset: 0x6B1F80 VA: 0x6B1F80
		//// RVA: 0x1CEC778 Offset: 0x1CEC778 VA: 0x1CEC778
		private IEnumerator ResultOut()
		{
			//0x1CEFFB8
			yield return Co.R(Fade(1));
			m_resultLayout.Leave();
			for(int i = 0; i < m_scrollBg.Length; i++)
			{
				m_applicationManager.RemoveTask(m_scrollBg[i]);
			}
			m_update = TitleInUpdate;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6B1FF8 Offset: 0x6B1FF8 VA: 0x6B1FF8
		//// RVA: 0x1CEC824 Offset: 0x1CEC824 VA: 0x1CEC824
		private IEnumerator BackSceneOut()
		{
			//0x1CED2DC
			if(m_scene != null)
			{
				ShootingButtonEnable();
				GameManager.Instance.RemovePushBackButtonHandler(TitleBackButton);
				m_soundManager.BgmFadeOut(1, null);
				GameManager.FadeOut(0.4f);
				while (GameManager.IsFading())
					yield return null;
				GameManager.Instance.SetTouchEffectVisible(true);
				m_scene.BackScene();
			}
		}

		//// RVA: 0x1CEC8D0 Offset: 0x1CEC8D0 VA: 0x1CEC8D0
		public void BackScene()
		{
			m_soundManager.SystemSePlay(3);
			this.StartCoroutineWatched(BackSceneOut());
		}

		//// RVA: 0x1CEC91C Offset: 0x1CEC91C VA: 0x1CEC91C
		public void HelpButton()
		{
			m_soundManager.SystemSePlay(3);
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			AMLGMLNGMFB_EventAprilFool af = m_viewShootingData.OEGDCBLNNFF(time, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/);
			if(af != null)
			{
				int id = af.HLOGNJNGDJO_GetHelpId(0);
				if(id > 0)
				{
					m_update = WaitUpdate;
					ShootingButtonDisable();
					this.StartCoroutineWatched(TutorialManager.ShowTutorial(id, () =>
					{
						//0x1CECF1C
						m_update = TitleMainUpdate;
						ShootingButtonEnable();
					}));
				}
			}
		}

		//// RVA: 0x1CECBF8 Offset: 0x1CECBF8 VA: 0x1CECBF8
		public void ChangeSceneButton()
		{
			if (ShootingGameSceneState.SceneState == ShootingGameSceneState.GameSceneState.Result)
				this.StartCoroutineWatched(ResultOut());
			else if (ShootingGameSceneState.SceneState == ShootingGameSceneState.GameSceneState.Title)
				this.StartCoroutineWatched(TitleOut());
		}

		//// RVA: 0x1CECC90 Offset: 0x1CECC90 VA: 0x1CECC90
		public void ShootingButtonEnable()
		{
			for (int i = 0; i < m_shootingButtons.Length; i++)
			{
				m_shootingButtons[i].IsInputLock = false;
			}
		}

		//// RVA: 0x1CECB64 Offset: 0x1CECB64 VA: 0x1CECB64
		public void ShootingButtonDisable()
		{
			for(int i = 0; i < m_shootingButtons.Length; i++)
			{
				m_shootingButtons[i].IsInputLock = true;
			}
		}

		//// RVA: 0x1CECD24 Offset: 0x1CECD24 VA: 0x1CECD24
		private void TaskPause()
		{
			m_systemManager.Pause();
			m_applicationManager.Pause();
			RemoveMainTask();
		}

		//// RVA: 0x1CECD7C Offset: 0x1CECD7C VA: 0x1CECD7C
		private void TaskUnPause()
		{
			AddMainTask();
			m_systemManager.UnPause();
			m_applicationManager.UnPause();
		}

		//// RVA: 0x1CECDD0 Offset: 0x1CECDD0 VA: 0x1CECDD0
		//public void UnPause() { }

		//// RVA: 0x1CE9C64 Offset: 0x1CE9C64 VA: 0x1CE9C64
		public void Pause()
		{
			if(ShootingGameSceneState.SceneState == ShootingGameSceneState.GameSceneState.MainScene && !m_isPause)
			{
				m_isPause = true;
				TaskPause();
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				TextPopupSetting s = new TextPopupSetting();
				s.TitleText = bk.GetMessageByLabel("popup_minigame001_pause_title");
				s.Text = string.Format(bk.GetMessageByLabel("popup_minigame001_pause_text"), m_resultData.Score);
				s.Buttons = new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Retire, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.ReStart, Type = PopupButton.ButtonType.Positive }
				};
				s.BackButtonLabel = PopupButton.ButtonLabel.ReStart;
				TextPopupSetting RetirePopup = new TextPopupSetting();
				RetirePopup.TitleText = bk.GetMessageByLabel("popup_minigame001_retire_title");
				RetirePopup.Text = bk.GetMessageByLabel("popup_minigame001_retire_text");
				RetirePopup.Buttons = new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Retire, Type = PopupButton.ButtonType.Positive }
				};
				PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x1CED108
					if(type == PopupButton.ButtonType.Negative)
					{
						PopupWindowManager.Show(RetirePopup, (PopupWindowControl c, PopupButton.ButtonType t, PopupButton.ButtonLabel l) =>
						{
							//0x1CED258
							if(t != PopupButton.ButtonType.Positive)
							{
								TaskUnPause();
								m_isPause = false;
							}
							else
							{
								this.StartCoroutineWatched(MainRetry());
							}
						}, null, null, null);
					}
					else
					{
						TaskUnPause();
						m_isPause = false;
					}
				}, null, null, null);
			}
		}

		//// RVA: 0x1CECDF4 Offset: 0x1CECDF4 VA: 0x1CECDF4
		public void PauseButton()
		{
			m_soundManager.SystemSePlay(3);
			Pause();
		}

		//// RVA: 0x1CECE30 Offset: 0x1CECE30 VA: 0x1CECE30
		public void CommandSuccess()
		{
			m_soundManager.SePlay(9);
			m_titleLayout.UseCommandEnter();
		}

		//// RVA: 0x1CECE84 Offset: 0x1CECE84 VA: 0x1CECE84
		public void TitleBackButton()
		{
			BackScene();
		}

		//// RVA: 0x1CECE88 Offset: 0x1CECE88 VA: 0x1CECE88
		public void MainBackButton()
		{
			m_soundManager.SystemSePlay(3);
			Pause();
		}
	}
}
