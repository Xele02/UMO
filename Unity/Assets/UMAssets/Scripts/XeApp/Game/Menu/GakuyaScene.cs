using CriWare;
using mcrs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;
using XeSys;

namespace XeApp.Game.Menu
{
	public class GakuyaScene : TransitionRoot
	{
		private enum UIOrderType
		{
			ChangeDiva = 0,
			ChangeCostume = 1,
		}

		private class DivaCostumeInfo
		{
			public int divaId; // 0x8
			public int modelId; // 0xC
			public int colorId; // 0x10

			// RVA: 0xB79964 Offset: 0xB79964 VA: 0xB79964
			public DivaCostumeInfo(int divaId, int modelId, int colorId)
			{
				this.divaId = divaId;
				this.modelId = modelId;
				this.colorId = colorId;
			}
		}

		[SerializeField]
		//[TooltipAttribute] // RVA: 0x66E8A8 Offset: 0x66E8A8 VA: 0x66E8A8
		private float m_divaCameraRotDuration = 0.5f; // 0x48
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x66E910 Offset: 0x66E910 VA: 0x66E910
		private float m_intimacyHintIntervalTime = 10; // 0x4C
		//[TooltipAttribute] // RVA: 0x66E984 Offset: 0x66E984 VA: 0x66E984
		[SerializeField]
		private float m_intimacyHintDispTime = 5; // 0x50
		//[TooltipAttribute] // RVA: 0x66E9EC Offset: 0x66E9EC VA: 0x66E9EC
		[SerializeField]
		private RectTransform m_intimacyPresentEffectPos; // 0x54
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x66EA60 Offset: 0x66EA60 VA: 0x66EA60
		private Image m_imageDebugDivaHit; // 0x58
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x66EAE0 Offset: 0x66EAE0 VA: 0x66EAE0
		private float m_durationCancelCostumeChange = 0.15f; // 0x5C
		private CharTouchHitCheck m_charTouchCheck; // 0x60
		private GakuyaCurtain m_curtain; // 0x64
		private GakuyaDivaMessage m_divaMessage; // 0x68
		private GakuyaHomeButton m_homeButton; // 0x6C
		private GakuyaViewModeButton m_viewModeButton; // 0x70
		private GakuyaInfos m_infos; // 0x74
		private GakuyaStatus m_status; // 0x78
		private GakuyaCostumeListWindow m_costumeListWindow; // 0x7C
		private GakuyaPresentListWindow m_presentListWindow; // 0x80
		private GakuyaProfile m_profile; // 0x84
		private GakuyaPresentLimit m_presentLimit; // 0x88
		private List<PIGBBNDPPJC> m_episodeList; // 0x8C
		private CostumeSelectDivaResrouce m_divaResource; // 0x90
		private VoicePlayerBase m_voicePlayer; // 0x94
		private CriAtomExPlayback m_voicePlayback; // 0x98
		private int m_voicePlayIndex; // 0x9C
		private int m_voiceCueCount; // 0xA0
		private MenuDivaManager m_divaManager; // 0xA4
		private MenuDivaTalk m_divaTalk; // 0xA8
		private HomeDivaControl m_divaControl; // 0xAC
		private IntimacyController m_intimacyController; // 0xB0
		private float m_intimacyHintTimeCount; // 0xB4
		private Coroutine m_coroutineIntimacyHintLeave; // 0xB8
		private int m_stateHashIdle; // 0xBC
		private bool m_isPlayedIntimacyHint; // 0xC0
		private bool m_isEntered; // 0xC1
		private bool m_isEndPreSetCanvas; // 0xC2
		private bool m_isEndPostSetCanvas; // 0xC3
		private bool m_isChangingDiva; // 0xC4
		private bool m_isGivingPresent; // 0xC5
		private bool m_isWaitIntimacyFirstPresent; // 0xC6
		private int m_divaId; // 0xC8
		private List<DivaCostumeInfo> m_divaCostumeInfos = new List<DivaCostumeInfo>(); // 0xCC
		private DivaCostumeInfo m_requestDivaCostumeInfo = new DivaCostumeInfo(0, 0, 0); // 0xD0
		private bool m_isChangingCostume; // 0xD4
		private bool m_isReactionCostumeChange; // 0xD5
		private Coroutine m_coroutineReactionCostumeChange; // 0xD8
		private bool m_gotoEpisode; // 0xDC
		private StringBuilder m_stringBuilder = new StringBuilder(); // 0xE0

		// RVA: 0xB75780 Offset: 0xB75780 VA: 0xB75780 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			m_voicePlayer = gameObject.AddComponent<VoicePlayerBase>();
			m_divaResource = gameObject.AddComponent<CostumeSelectDivaResrouce>();
			this.StartCoroutineWatched(CO_LoadResource());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DF01C Offset: 0x6DF01C VA: 0x6DF01C
		//// RVA: 0xB75868 Offset: 0xB75868 VA: 0xB75868
		private IEnumerator CO_LoadResource()
		{
			XeSys.FontInfo systemFont; // 0x18
			StringBuilder bundleName; // 0x1C
			int bundleLoadCount; // 0x20
			AssetBundleLoadUGUIOperationBase uguiOp; // 0x24

			//0xB7B73C
			systemFont = GameManager.Instance.GetSystemFont();
			bundleName = new StringBuilder();
			bundleName.Set("ly/081.xab");
			bundleLoadCount = 0;
			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName.ToString(), "GakuyaHomeButton");
			yield return uguiOp;
			yield return Co.R(uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xB7A538
				instance.transform.SetParent(transform, false);
				m_homeButton = instance.GetComponentInChildren<GakuyaHomeButton>();
			}));
			bundleLoadCount++;
			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName.ToString(), "GakuyaViewModeButton");
			yield return uguiOp;
			yield return Co.R(uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xB7A634
				instance.transform.SetParent(transform, false);
				m_viewModeButton = instance.GetComponentInChildren<GakuyaViewModeButton>();
			}));
			bundleLoadCount++;
			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName.ToString(), "GakuyaInfos");
			yield return uguiOp;
			yield return Co.R(uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xB7A730
				instance.transform.SetParent(transform, false);
				m_infos = instance.GetComponentInChildren<GakuyaInfos>();
			}));
			bundleLoadCount++;
			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName.ToString(), "GakuyaInfoStatus");
			GameObject objectStatus = null;
			yield return uguiOp;
			yield return Co.R(uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xB7A82C
				objectStatus = instance;
				m_status = instance.GetComponentInChildren<GakuyaStatus>();
			}));
			bundleLoadCount++;
			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName.ToString(), "GakuyaInfoCostumeList");
			GameObject objectCostumeList = null;
			yield return uguiOp;
			yield return Co.R(uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xB7A8C4
				objectCostumeList = instance;
				m_costumeListWindow = instance.GetComponentInChildren<GakuyaCostumeListWindow>();
			}));
			bundleLoadCount++;
			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName.ToString(), "GakuyaInfoCostumeListContent");
			yield return uguiOp;
			yield return Co.R(uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xB7A95C
				m_costumeListWindow.Setup(instance);
			}));
			bundleLoadCount++;
			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName.ToString(), "GakuyaInfoPresentList");
			GameObject objectPresentList = null;
			yield return uguiOp;
			yield return Co.R(uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xB7A9A0
				objectPresentList = instance;
				m_presentListWindow = instance.GetComponentInChildren<GakuyaPresentListWindow>();
			}));
			bundleLoadCount++;
			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName.ToString(), "GakuyaInfoPresentListContent");
			yield return uguiOp;
			yield return Co.R(uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xB7AA38
				m_presentListWindow.Setup(instance);
			}));
			bundleLoadCount++;
			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName.ToString(), "GakuyaInfoProfile");
			GameObject objectProfile = null;
			yield return uguiOp;
			yield return Co.R(uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xB7AA7C
				objectProfile = instance;
				m_profile = instance.GetComponentInChildren<GakuyaProfile>();
			}));
			bundleLoadCount++;
			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName.ToString(), "GakuyaDivaMessage");
			yield return uguiOp;
			yield return Co.R(uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xB7AB14
				instance.transform.SetParent(transform, false);
				m_divaMessage = instance.GetComponentInChildren<GakuyaDivaMessage>();
			}));
			bundleLoadCount++;
			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName.ToString(), "GakuyaCurtain");
			yield return uguiOp;
			yield return Co.R(uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xB7AC10
				instance.transform.SetParent(transform, false);
				m_curtain = instance.GetComponentInChildren<GakuyaCurtain>();
			}));
			bundleLoadCount++;
			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName.ToString(), "GakuyaPresentLimit");
			yield return uguiOp;
			yield return Co.R(uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xB7AD0C
				instance.transform.SetParent(transform, false);
				m_presentLimit = instance.GetComponentInChildren<GakuyaPresentLimit>();
			}));
			bundleLoadCount++;
			for(int i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
			m_infos.Setup(objectStatus, objectCostumeList, objectPresentList, objectProfile);
			m_charTouchCheck = GetComponentInChildren<CharTouchHitCheck>();
			IsReady = true;
		}

		// RVA: 0xB75914 Offset: 0xB75914 VA: 0xB75914 Slot: 5
		protected override void Start()
		{
			base.Start();
		}

		// RVA: 0xB7591C Offset: 0xB7591C VA: 0xB7591C
		private void Update()
		{
			if (!IsEnableIntimacyHint())
				m_intimacyHintTimeCount = 0;
			else
			{
				m_intimacyHintTimeCount += Time.deltaTime;
				if (m_intimacyHintIntervalTime <= m_intimacyHintTimeCount)
					StartIntimacyHint();
			}
		}

		// RVA: 0xB75984 Offset: 0xB75984 VA: 0xB75984 Slot: 16
		protected override void OnPreSetCanvas()
		{
			base.OnPreSetCanvas();
			this.StartCoroutineWatched(Co_OnPreSetCanvas());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DF094 Offset: 0x6DF094 VA: 0x6DF094
		//// RVA: 0xB759B4 Offset: 0xB759B4 VA: 0xB759B4
		private IEnumerator Co_OnPreSetCanvas()
		{
			//0xB812C0
			m_isEndPreSetCanvas = false;
			m_episodeList = PIGBBNDPPJC.FKDIMODKKJD_GetAvaiableEpisodes(true);
			if(PrevTransition != TransitionList.Type.GAKUYA_DIVA_VIEW)
			{
				InitDivaCostumeInfos();
				bool isWaitIntimacyController = true;
				m_divaManager = MenuScene.Instance.divaManager;
				m_divaControl = new HomeDivaControl();
				m_divaManager.BeginControl(m_divaControl);
				m_divaTalk = new MenuDivaTalk(m_divaManager.DivaId, m_divaControl);
				m_divaTalk.RequestDelayDownLoad();
				m_divaTalk.TimerStop();
				m_intimacyController = MenuScene.Instance.IntimacyControl;
				m_intimacyController.InitGakuya(this, m_divaMessage, m_presentListWindow, m_presentLimit, m_divaTalk, m_divaControl, () =>
				{
					//0xB7AE10
					isWaitIntimacyController = false;
				});
				while (isWaitIntimacyController)
					yield return null;
				if(m_divaId == 0)
				{
					m_divaId = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.BBIOMNCILMC_HomeDivaId;
					if(m_divaId == 0)
					{
						m_divaId = GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].AHHJLDLAPAN_DivaId;
					}
				}
				yield return Co.R(Co_LoadDivaResource(m_divaId));
				yield return Co.R(Co_ApplyDivaInfos(m_divaId));
			}
			//LAB_00b813f0
			int intimacy_player_level = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("intimacy_player_level", 8);
			int level = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KIECDDFNCAN_Level;
			m_infos.SetGiftLock(level, intimacy_player_level);
			m_homeButton.OnClickHomeButtonCallback = OnClickHomeButton;
			m_viewModeButton.OnClickViewButtonCallback = OnClickViewButton;
			m_infos.OnClickChangeDivaButtonCallback = OnClickChangeDiva;
			m_infos.OnClickSelectButtonCallback = OnClickInfosSelectButton;
			m_infos.OnFinishSelectAnimCallback = OnFinishSelectAnim;
			m_status.OnClickDivaRankingButtonCallback = OnClickDivaRanking;
			m_costumeListWindow.OnClickItemCallback = OnClickCostumeItem;
			m_presentListWindow.OnClickItemCallback = OnClickPresentItem;
			m_charTouchCheck.OnClickCallback = OnClickDiva;
			m_curtain.Hide();
			m_divaMessage.Hide();
			m_homeButton.Hide();
			m_viewModeButton.Hide();
			m_infos.Hide();
			m_presentLimit.gameObject.SetActive(false);
			m_stateHashIdle = Animator.StringToHash("idle");
			m_gotoEpisode = false;
			m_isEndPreSetCanvas = true;
		}

		// RVA: 0xB75A60 Offset: 0xB75A60 VA: 0xB75A60 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return m_isEndPreSetCanvas;
		}

		// RVA: 0xB75A68 Offset: 0xB75A68 VA: 0xB75A68 Slot: 18
		protected override void OnPostSetCanvas()
		{
			base.OnPostSetCanvas();
			this.StartCoroutineWatched(Co_OnPostSetCanvas());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DF10C Offset: 0x6DF10C VA: 0x6DF10C
		//// RVA: 0xB75A98 Offset: 0xB75A98 VA: 0xB75A98
		private IEnumerator Co_OnPostSetCanvas()
		{
			//0xB80E7C
			m_isEndPostSetCanvas = false;
			SetUIOrder(UIOrderType.ChangeDiva);
			if(PrevTransition == TransitionList.Type.HOME)
			{
				MenuScene.Instance.divaManager.SetCameraRot(MenuScene.Instance.GetDivaCameraRotByScene(TransitionList.Type.HOME));
				MenuScene.Instance.divaManager.ChangeCameraRot(MenuScene.Instance.GetDivaCameraRotByScene(TransitionList.Type.GAKUYA), m_divaCameraRotDuration);
			}
			if(PrevTransition != TransitionList.Type.GAKUYA_DIVA_VIEW)
			{
				m_infos.SetSelectType(GakuyaInfos.SelectType.Status, true, false);
				PreSetAllHomeCostume();
			}
			m_homeButton.TryEnter();
			m_viewModeButton.TryEnter();
			m_infos.TryEnter();
			if(m_infos.CurrentSelectType == GakuyaInfos.SelectType.Gift)
			{
				m_intimacyController.GakuyaInfoEnter();
			}
			m_isEndPostSetCanvas = true;
			yield break;
		}

		// RVA: 0xB75B44 Offset: 0xB75B44 VA: 0xB75B44 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			return m_isEndPostSetCanvas;
		}

		// RVA: 0xB75B4C Offset: 0xB75B4C VA: 0xB75B4C Slot: 20
		protected override bool OnBgmStart()
		{
			int bgmId = BgmPlayer.MENU_BGM_ID_BASE;
			if(MenuScene.Instance.BgControl.limitedHomeBg.m_music_id == BgControl.LimitedHomeBg.INVALID_MUSIC_ID)
			{
				string home_bgm_id = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.EFEGBHACJAL("home_bgm_id", "0,0,0");
				string[] home_bgm_ids = home_bgm_id.Split(new char[] { ',' });
				if(home_bgm_ids.Length == 3)
				{
					int id = BgControl.GetHomeBgId(MenuScene.Instance.EnterToHomeTime);
					int a = 0;
					if (int.TryParse(home_bgm_ids[id - 1], out a))
					{
						bgmId += a;
					}
				}
			}
			else
			{
				bgmId += MenuScene.Instance.BgControl.limitedHomeBg.m_music_id;
			}
			SoundManager.Instance.bgmPlayer.ContinuousPlay(bgmId, 1);
			return true;
		}

		// RVA: 0xB75FFC Offset: 0xB75FFC VA: 0xB75FFC Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_homeButton.IsPlaying() && !m_viewModeButton.IsPlaying() && !m_infos.IsPlaying() && !MenuScene.Instance.divaManager.IsChangingCameraRot();
		}

		// RVA: 0xB76160 Offset: 0xB76160 VA: 0xB76160 Slot: 23
		protected override void OnActivateScene()
		{
			this.StartCoroutineWatched(Co_OnActivateScene());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DF184 Offset: 0x6DF184 VA: 0x6DF184
		//// RVA: 0xB76184 Offset: 0xB76184 VA: 0xB76184
		private IEnumerator Co_OnActivateScene()
		{
			//0xB80664
			m_isEntered = false;
			MenuScene.Instance.RaycastDisable();
			yield return Co.R(TutorialManager.TryShowTutorialCoroutine(PrivateCheckTutorialFunc));
			if(IsEnableIntimacy())
			{
				if(m_intimacyController.viewData.KCJCJLNHMKI())
				{
					CIOECGOMILE.HHCJCDFCLOB.FAFAKNJLLIC_ResetIntimacyPresentLeft();
					yield return Co.R(Co_IntimacyFirstPresent());
				}
			}
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.GDLAPBKCBFP_IsHomeDivaWindow)
			{
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.GDLAPBKCBFP_IsHomeDivaWindow = false;
				TextPopupSetting s =  PopupWindowManager.CrateTextContent("", SizeType.Small, bk.GetMessageByLabel("popup_home_diva_01"), new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					}, false, true);
				s.IsCaption = false;
				bool waitPopup = true;
				PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0xB7AE24
					waitPopup = false;
				}, null, null, null);
				while (waitPopup)
					yield return null;
			}
			GameManager.Instance.AddPushBackButtonHandler(OnBackButton);
			MenuScene.Instance.RaycastEnable();
			m_isEntered = true;
		}

		//// RVA: 0xB76230 Offset: 0xB76230 VA: 0xB76230
		private bool PrivateCheckTutorialFunc(TutorialConditionId condId)
		{
			if(condId == TutorialConditionId.Condition58)
			{
				return IsEnableIntimacy();
			}
			return false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DF1FC Offset: 0x6DF1FC VA: 0x6DF1FC
		//// RVA: 0xB76320 Offset: 0xB76320 VA: 0xB76320
		private IEnumerator Co_IntimacyFirstPresent()
		{
			Coroutine coroutineSave;

			//0xB7F304
			m_isWaitIntimacyFirstPresent = true;
			m_intimacyController.IsPupUpWindow = true;
			while (GameManager.Instance.IsTutorial)
				yield return null;
			while (TutorialManager.IsAlreadyTutorial(TutorialConditionId.Condition58))
				yield return null;
			coroutineSave = null;
			coroutineSave = this.StartCoroutineWatched(Co_Save());
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			bool isClose = false;
			string v = JKNGJFOBADP.JKOAGEAPJHI(m_intimacyController.viewData.HBODCMLFDOB.IOCFPAAEFHM_FullItemId, m_intimacyController.viewData.HBODCMLFDOB.LEAKFAFGEKK_Count, 20);
			PopupPresentSetting s = new PopupPresentSetting();
			s.TitleText = bk.GetMessageByLabel("");
			s.itemName = v;
			s.itemId = m_intimacyController.viewData.HBODCMLFDOB.IOCFPAAEFHM_FullItemId;
			s.itemDetail = m_intimacyController.viewData.HBODCMLFDOB.JLKIADFKPFL_Desc;
			s.WindowSize = 0;
			s.IsCaption = false;
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xB7AE38
				isClose = true;
			}, null, null, null);
			yield return new WaitWhile(() =>
			{
				//0xB7AE44
				return !isClose;
			});
			if(coroutineSave != null)
				yield return coroutineSave;
			this.StartCoroutineWatched(m_intimacyController.co_UpdateGakuyaList(null));
			m_intimacyController.IsPupUpWindow = false;
			m_isWaitIntimacyFirstPresent = false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DF274 Offset: 0x6DF274 VA: 0x6DF274
		//// RVA: 0xB763CC Offset: 0xB763CC VA: 0xB763CC
		private IEnumerator Co_Save()
		{
			//0xB82588
			bool done = false;
			bool err = false;
			MenuScene.Save(() =>
			{
				//0xB7AE60
				done = true;
			}, () =>
			{
				//0xB7AE6C
				done = true;
				err = true;
			});
			while(!done)
				yield return null;
			if(err)
			{
				MenuScene.Instance.GotoTitle();
			}
		}

		// RVA: 0xB76460 Offset: 0xB76460 VA: 0xB76460 Slot: 24
		protected override bool IsEndActivateScene()
		{
			return m_isEntered;
		}

		// RVA: 0xB76468 Offset: 0xB76468 VA: 0xB76468 Slot: 12
		protected override void OnStartExitAnimation()
		{
			base.OnStartExitAnimation();
			m_divaMessage.TryLeave();
			m_homeButton.TryLeave();
			m_viewModeButton.TryLeave();
			m_infos.TryLeave();
			m_intimacyController.GakuyaInfoLeave();
			CancelReactionCostumeChange();
			CancelIntimacyHint();
			if (m_coroutineIntimacyHintLeave != null)
				this.StopCoroutineWatched(m_coroutineIntimacyHintLeave);
			m_coroutineIntimacyHintLeave = null;
			m_isEntered = false;
		}

		// RVA: 0xB7687C Offset: 0xB7687C VA: 0xB7687C Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_isChangingCostume && !m_isChangingDiva && !m_divaMessage.IsPlaying() && !m_homeButton.IsPlaying()
				&& !m_viewModeButton.IsPlaying() && !m_infos.IsPlaying()
				&& !MenuScene.Instance.divaManager.IsChangingCameraRot() && m_divaTalk.IsEnableReaction();
		}

		// RVA: 0xB76A10 Offset: 0xB76A10 VA: 0xB76A10 Slot: 14
		protected override void OnDestoryScene()
		{
			GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
			if(MenuScene.Instance.GetNextScene().name != TransitionList.Type.GAKUYA_DIVA_VIEW)
			{
				m_divaResource.Release();
				m_voicePlayer.RemoveCueSheet();
				m_divaManager.EndControl(m_divaControl);
				m_intimacyController.OnDestoryScene();
			}
			base.OnDestoryScene();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DF2EC Offset: 0x6DF2EC VA: 0x6DF2EC
		//// RVA: 0xB76BF4 Offset: 0xB76BF4 VA: 0xB76BF4
		private IEnumerator Co_ApplyDivaInfos(int divaId)
		{
			//0xB7C904
			m_infos.SetActiveHideContent(true);
			m_infos.SetDiva(divaId);
			m_divaMessage.SetDiva(divaId);
			FFHPBEPOMAK_DivaInfo d = GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas.Find((FFHPBEPOMAK_DivaInfo _) =>
			{
				//0xB7AE80
				return _.AHHJLDLAPAN_DivaId == divaId;
			});
			if(d == null)
			{
				d = GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas[0];
			}
			m_status.Setup(d);
			bool isWaitRankingLoad = true;
			m_status.UpdateDivaRanking(d, (LAMCONGFONF.OJFOLGKMBIG info) =>
			{
				//0xB7AEB8
				isWaitRankingLoad = false;
			}, () =>
			{
				//0xB7AEC4
				isWaitRankingLoad = false;
			});
			while (isWaitRankingLoad)
				yield return null;
			DivaCostumeInfo c = GetDivaCostumeInfo(divaId);
			m_costumeListWindow.SetItems(divaId, c.modelId, c.colorId, false);
			m_presentListWindow.SetItems(OJEGDIBEBHP.FKDIMODKKJD());
			m_profile.Setup(divaId);
			for(int i = 0; i < m_costumeListWindow.ItemCount; i++)
			{
				GakuyaCostumeListWindow.ItemInfo cosInfo = m_costumeListWindow.GetItem(i);
				string p = ItemTextureCache.MakeItemIconTexturePath(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume, cosInfo.m_cosId), cosInfo.m_cosColor);
				KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(p);
				p = CostumeTextureCache.MakeCostumeTexturePath(divaId, cosInfo.m_viewDiva.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, cosInfo.m_cosColor);
				KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(p);
			}
			while (KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
			m_infos.SetActiveHideContent(false);
		}

		//// RVA: 0xB76CBC Offset: 0xB76CBC VA: 0xB76CBC
		private void SetUIOrder(UIOrderType type)
		{
			if(type == UIOrderType.ChangeCostume)
			{
				m_charTouchCheck.transform.SetAsLastSibling();
				m_curtain.transform.SetAsLastSibling();
				m_infos.transform.SetAsLastSibling();
				m_viewModeButton.transform.SetAsLastSibling();
				m_homeButton.transform.SetAsLastSibling();
				m_divaMessage.transform.SetAsLastSibling();
			}
			else if(type == UIOrderType.ChangeDiva)
			{
				m_charTouchCheck.transform.SetAsLastSibling();
				m_infos.transform.SetAsLastSibling();
				m_viewModeButton.transform.SetAsLastSibling();
				m_homeButton.transform.SetAsLastSibling();
				m_divaMessage.transform.SetAsLastSibling();
				m_curtain.transform.SetAsLastSibling();
			}
		}

		//// RVA: 0xB76FA4 Offset: 0xB76FA4 VA: 0xB76FA4
		private void OnClickHomeButton()
		{
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
				MenuScene.Instance.divaManager.ChangeCameraRot(MenuScene.Instance.GetDivaCameraRotByScene(TransitionList.Type.HOME), m_divaCameraRotDuration);
				this.StartCoroutineWatched(Co_ApplySavedata(() =>
				{
					//0xB7A488
					MenuScene.Instance.Return(true);
				}));
			}
		}

		//// RVA: 0xB7730C Offset: 0xB7730C VA: 0xB7730C
		private void OnClickViewButton()
		{
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
				MenuScene.Instance.Call(TransitionList.Type.GAKUYA_DIVA_VIEW, null, true);
			}
		}

		//// RVA: 0xB774FC Offset: 0xB774FC VA: 0xB774FC
		private void OnClickChangeDiva()
		{
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				PopupFilterSortInitParam s = new PopupFilterSortInitParam();
				s.Scene = PopupFilterSort.Scene.DivaSelect;
				s.FilterDiva = 1 << m_divaId;
				s.DivaChangeMode = true;
				int nextDivaId = m_divaId;
				MenuScene.Instance.ShowSortWindow(s, (PopupFilterSort content) =>
				{
					//0xB7AED0
					nextDivaId = content.ResultSelectDivaId;
				}, () =>
				{
					//0xB7AEFC
					if (nextDivaId == m_divaId)
						return;
					this.StartCoroutineWatched(Co_ChangeDiva(nextDivaId));
				});
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DF364 Offset: 0x6DF364 VA: 0x6DF364
		//// RVA: 0xB777C8 Offset: 0xB777C8 VA: 0xB777C8
		private IEnumerator Co_ChangeDiva(int divaId)
		{
			Coroutine cancelCoroutine;

			//0xB7ECA4
			m_isChangingDiva = true;
			MenuScene.Instance.InputDisable();
			CancelReactionCostumeChange();
			cancelCoroutine = CancelIntimacyHint();
			SetUIOrder(UIOrderType.ChangeDiva);
			m_curtain.SetDiva(divaId);
			m_curtain.SetMessageType(GakuyaCurtain.MessageType.ChangeDiva);
			m_curtain.TryEnter();
			while (m_curtain.IsPlaying())
				yield return null;
			yield return cancelCoroutine;
			yield return Co.R(Co_LoadDivaResource(divaId));
			MenuScene.Instance.divaManager.SetActive(false, true);
			yield return Co.R(Co_LoadDivaModel(divaId));
			MenuScene.Instance.divaManager.SetActive(true, true);
			yield return Co.R(Co_ApplyDivaInfos(divaId));
			m_divaId = divaId;
			m_divaTalk = new MenuDivaTalk(m_divaManager.DivaId, m_divaControl);
			m_divaTalk.RequestDelayDownLoad();
			m_divaTalk.TimerStop();
			m_intimacyController.GakuyaDivaChange(divaId, m_divaTalk);
			m_infos.SetSelectType(GakuyaInfos.SelectType.Status, false, false);
			m_infos.SetScrollTop();
			m_intimacyController.GakuyaInfoLeave();
			m_curtain.Leave();
			while(m_curtain.IsPlaying())
				yield return null;
			MenuScene.Instance.InputEnable();
			m_isChangingDiva = false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DF3DC Offset: 0x6DF3DC VA: 0x6DF3DC
		//// RVA: 0xB77890 Offset: 0xB77890 VA: 0xB77890
		private IEnumerator Co_LoadDivaModel(int divaId)
		{
			MenuFacialBlendAnimMediator blend;

			//0xB7FC30
			MenuScene.Instance.divaManager.Release(true);
			Resources.UnloadUnusedAssets();
			yield return null;
			blend = m_divaManager.GetComponentInChildren<MenuFacialBlendAnimMediator>();
			if(blend != null)
			{
				blend.enabled = false;
			}
			DivaCostumeInfo divaInfo = GetDivaCostumeInfo(divaId);
			MenuScene.Instance.divaManager.Load(divaId, divaInfo.modelId, divaInfo.colorId, DivaResource.MenuFacialType.Home, false);
			while (MenuScene.Instance.divaManager.IsLoading)
				yield return null;
			MenuScene.Instance.divaManager.OverrideAnimations(m_divaResource.overrideClipList);
			if(blend != null)
			{
				blend.enabled = true;
			}
			m_isPlayedIntimacyHint = false;
			MenuScene.Instance.divaManager.OnIdle("");
		}

		//// RVA: 0xB77958 Offset: 0xB77958 VA: 0xB77958
		private void OnClickInfosSelectButton(GakuyaInfos.SelectType selectType)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_000);
			if(selectType == GakuyaInfos.SelectType.Gift)
			{
				if(!m_infos.IsLockGift)
				{
					m_intimacyController.GakuyaInfoEnter();
					if(IsEnableIntimacyHint())
						StartIntimacyHint();
				}
				return;
			}
			m_intimacyController.GakuyaInfoLeave();
			if (selectType != GakuyaInfos.SelectType.Status)
				return;
			m_status.UpdateIntimacy();
		}

		//// RVA: 0xB77D44 Offset: 0xB77D44 VA: 0xB77D44
		private void OnFinishSelectAnim(GakuyaInfos.SelectType selectType)
		{
			return;
		}

		//// RVA: 0xB77D48 Offset: 0xB77D48 VA: 0xB77D48
		private void OnClickDivaRanking()
		{
			if (MenuScene.Instance.DirtyChangeScene)
				return;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
			IBJAKJJICBC d = new IBJAKJJICBC();
			d.KHEKNNFCAOI(1, false, 0, 0, 0, false, false, false);
			DivaTotalRankingSceneArgs args = new DivaTotalRankingSceneArgs();
			args.MusicData = d;
			args.DivaId = m_divaId;
			this.StartCoroutineWatched(Co_ApplySavedata(() =>
			{
				//0xB7AF84
				MenuScene.Instance.Call(TransitionList.Type.DIVA_RANKING, args, true);
			}));
		}

		//// RVA: 0xB78064 Offset: 0xB78064 VA: 0xB78064
		private void OnClickCostumeItem(int index)
		{
			if (MenuScene.Instance.DirtyChangeScene)
				return;
			GakuyaCostumeListWindow.ItemInfo item = m_costumeListWindow.GetItem(index);
			if(!item.m_isHave)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				this.StartCoroutineWatched(Co_ShowPopupUnlockInfo(item));
				return;
			}
			if (item.m_isTry)
				return;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			m_requestDivaCostumeInfo.divaId = item.m_viewDiva.AHHJLDLAPAN_DivaId;
			m_requestDivaCostumeInfo.modelId = item.m_cosModelId;
			m_requestDivaCostumeInfo.colorId = item.m_cosColor;
			if(!m_isChangingCostume)
			{
				this.StartCoroutineWatched(Co_ChangeCostume());
			}
			if(item.m_isNew)
			{
				item.m_isNew = false;
				if (item.m_cosColor == 0)
					item.m_viewDiva.LEHDLBJJBNC();
				else
					item.m_viewDiva.FFKMJNHFFFL_Costume.PDADHMIODCA(item.m_cosColor, false);
			}
			m_costumeListWindow.SetTryIndex(index);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DF454 Offset: 0x6DF454 VA: 0x6DF454
		//// RVA: 0xB78334 Offset: 0xB78334 VA: 0xB78334
		private IEnumerator Co_ChangeCostume()
		{
			Coroutine cancelCoroutine;

			//0xB7E5B8
			if (IsMatchCostumeInfo(m_requestDivaCostumeInfo))
				yield break;
			m_isChangingCostume = true;
			MenuScene.Instance.InputDisable();
			m_costumeListWindow.SetInputEnable();
			CancelReactionCostumeChange();
			cancelCoroutine = CancelIntimacyHint();
			SetUIOrder(UIOrderType.ChangeCostume);
			do
			{
				do
				{
					m_curtain.SetDiva(m_requestDivaCostumeInfo.divaId);
					m_curtain.SetMessageType(GakuyaCurtain.MessageType.ChangeCostume);
					m_curtain.TryEnter();
					while (m_curtain.IsPlaying())
						yield return null;
					yield return cancelCoroutine;
					SetDivaCostumeInfo(m_requestDivaCostumeInfo.divaId, m_requestDivaCostumeInfo.modelId, m_requestDivaCostumeInfo.colorId);
					MenuScene.Instance.divaManager.SetActive(false, true);
					yield return Co.R(Co_LoadDivaModel(m_requestDivaCostumeInfo.divaId));
					MenuScene.Instance.divaManager.SetActive(true, true);
				}
				while (!IsMatchCostumeInfo(m_requestDivaCostumeInfo));
				MenuScene.Instance.divaManager.IdleCrossFade("simple_idle");
				yield return new WaitForSeconds(0.2f);
				m_curtain.Leave();
				while (m_curtain.IsPlaying())
					yield return null;
			} while (!IsMatchCostumeInfo(m_requestDivaCostumeInfo));
			m_isChangingCostume = false;
			if (!m_gotoEpisode)
			{
				MenuScene.Instance.InputEnable();
				m_coroutineReactionCostumeChange = this.StartCoroutineWatched(Co_ReactionCostumeChange());
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DF4CC Offset: 0x6DF4CC VA: 0x6DF4CC
		//// RVA: 0xB78488 Offset: 0xB78488 VA: 0xB78488
		private IEnumerator Co_ReactionCostumeChange()
		{
			int hash;

			//0xB81F28
			m_isReactionCostumeChange = true;
			GameManager.Instance.SetFPS(60);
			MenuScene.Instance.divaManager.SetAnimParamInteger("menu_simpleLoopStart_State", 1);
			hash = Animator.StringToHash("simple_loop_start");
			while (!MenuScene.Instance.divaManager.IsCurrentBodyState(hash))
				yield return null;
			m_voicePlayback = m_voicePlayer.source.Play(m_voicePlayIndex);
			m_voicePlayIndex++;
			if (m_voicePlayIndex >= m_voiceCueCount)
				m_voicePlayIndex = 0;
			while (m_voicePlayback.GetStatus() != CriAtomExPlayback.Status.Removed)
				yield return null;
			MenuScene.Instance.divaManager.SetAnimParamInteger("menu_simpleLoopStart_State", 2);
			hash = Animator.StringToHash("simple_idle");
			while(!MenuScene.Instance.divaManager.IsCurrentBodyState(hash))
				yield return null;
			MenuScene.Instance.divaManager.SetAnimParamInteger("menu_simpleLoopStart_State", 0);
			MenuScene.Instance.divaManager.IdleCrossFade("");
			GameManager.Instance.SetFPS(30);
			m_coroutineReactionCostumeChange = null;
			m_isReactionCostumeChange = false;
		}

		//// RVA: 0xB76570 Offset: 0xB76570 VA: 0xB76570
		private void CancelReactionCostumeChange()
		{
			if(m_isReactionCostumeChange && m_coroutineReactionCostumeChange != null)
			{
				m_voicePlayback.Stop();
				this.StopCoroutineWatched(m_coroutineReactionCostumeChange);
				MenuScene.Instance.divaManager.SetAnimParamInteger("menu_simpleLoopStart_State", 0);
				MenuScene.Instance.divaManager.SetBodyCrossFade("idle", m_durationCancelCostumeChange);
				MenuScene.Instance.divaManager.PlayFacialBlendAnimator("idle", 0);
				MenuScene.Instance.divaManager.PlayFacialBlendAnimator("idle", 1);
				GameManager.Instance.SetFPS(30);
				m_coroutineReactionCostumeChange = null;
				m_isReactionCostumeChange = false;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DF544 Offset: 0x6DF544 VA: 0x6DF544
		//// RVA: 0xB783C0 Offset: 0xB783C0 VA: 0xB783C0
		private IEnumerator Co_ShowPopupUnlockInfo(GakuyaCostumeListWindow.ItemInfo costumeItemInfo)
		{
			//0xB82860
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			PIGBBNDPPJC episodeData = null;
			for(int i = 0; i < m_episodeList.Count; i++)
			{
				if(m_episodeList[i].KELFCMEOPPM_EpId == costumeItemInfo.m_viewDiva.KELFCMEOPPM_EpisodeId)
				{
					episodeData = m_episodeList[i];
				}
			}
			CostumeSelectListTermsPopup.Setting s = new CostumeSelectListTermsPopup.Setting();
			s.m_type = costumeItemInfo.m_cosColor != 0 ? CostumeSelectListTermsPopup.Type.CostumeColorChange : CostumeSelectListTermsPopup.Type.CostumeBase;
			s.TitleText = bk.GetMessageByLabel("popup_sel_cos_terms_title");
			s.m_diva_id = costumeItemInfo.m_viewDiva.AHHJLDLAPAN_DivaId;
			s.m_costume_color = costumeItemInfo.m_cosColor;
			s.m_costume_model_id = costumeItemInfo.m_cosModelId;
			s.WindowSize = SizeType.Middle;
			if(s.m_type == CostumeSelectListTermsPopup.Type.CostumeBase)
			{
				s.Buttons = new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Episode, Type = PopupButton.ButtonType.Episode }
				};
				m_stringBuilder.SetFormat(bk.GetMessageByLabel("popup_sel_cos_terms_text_base"), episodeData.OPFGFINHFCE_Name);
				s.m_text = m_stringBuilder.ToString();
			}
			else
			{
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				};
				s.m_text = "";
				if(MOEALEGLGCH.CDOCOLOKCJK())
				{
					s.m_text += bk.GetMessageByLabel("popup_sel_cos_terms_text_color02");
					s.m_text += JpStringLiterals.StringLiteral_5812;
				}
				m_stringBuilder.SetFormat(bk.GetMessageByLabel("popup_sel_cos_terms_text_color01"), costumeItemInfo.m_nameBase, CKFGMNAIBNG.MHIKGGMOPOJ(costumeItemInfo.m_viewDiva.AHHJLDLAPAN_DivaId, costumeItemInfo.m_cosId, costumeItemInfo.m_cosColor));
				s.m_text += m_stringBuilder.ToString();
			}
			m_gotoEpisode = false;
			bool isEntPopup = false;
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xB7B048
				m_gotoEpisode = label == PopupButton.ButtonLabel.Episode;
				m_costumeListWindow.SetInputDisable();
			}, null, null, null, endCallBaack:() =>
			{
				//0xB7B0B4
				isEntPopup = true;
			});
			while(!isEntPopup)
				yield return null;
			if(!m_gotoEpisode)
			{
				if(!m_isChangingCostume)
					yield break;
				m_costumeListWindow.SetInputEnable();
			}
			else
			{
				while(m_isChangingCostume)
					yield return null;
				this.StartCoroutineWatched(Co_ApplySavedata(() =>
				{
					//0xB7B0C0
					MenuScene.Instance.Mount(TransitionUniqueId.SETTINGMENU_EPISODESELECT_EPISODEDETAIL, new EpisodeDetailArgs() { data = episodeData }, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
				}));
			}
		}

		//// RVA: 0xB78554 Offset: 0xB78554 VA: 0xB78554
		private void OnClickPresentItem(int index)
		{
			if (MenuScene.Instance.DirtyChangeScene)
				return;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			bool presentDivaLimit = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.NJGEDPHNIKC_IsPresentLimitEnabled();
			if(!m_intimacyController.viewData.HBODCMLFDOB.PFIILLOIDIL || presentDivaLimit)
			{
				if(m_intimacyController.viewData.NCNAPMHEINJ())
				{
					GakuyaPresentListWindow.ItemInfo itemInfo = m_presentListWindow.GetItem(index);
					MessageBank bk = MessageManager.Instance.GetBank("menu");
					if(!presentDivaLimit)
					{
						PopupGakuyaPresentUseSetting s = new PopupGakuyaPresentUseSetting();
						s.TitleText = string.Format(bk.GetMessageByLabel("pop_gakuya_present_ask_title"), itemInfo.m_presentData.OPFGFINHFCE_Name);
						s.Buttons = new ButtonInfo[2]
						{
							new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
							new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive },
						};
						s.WindowSize = SizeType.Middle;
						s.m_divaPresentData = itemInfo.m_presentData;
						PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel buttonLabel) =>
						{
							//0xB7B278
							if(type == PopupButton.ButtonType.Positive)
							{
								m_isGivingPresent = true;
								Vector2 v = RectTransformUtility.WorldToScreenPoint(GameManager.Instance.GetSystemCanvasCamera(), m_intimacyPresentEffectPos.position);
								int useItemCount = 1;
								if(presentDivaLimit)
								{
									useItemCount = (control.Content as PopupGakuyaPresentUse2Contents).UseItemVal;
								}
								GameManager.Instance.SetFPS(60);
								m_intimacyController.StartToPresentGakuya(itemInfo.m_presentData.ADJBIEOILPJ_Id, useItemCount, v, () =>
								{
									//0xB7B1B8
									GameManager.Instance.SetFPS(30);
									m_isGivingPresent = false;
								});
							}
						}, null, null, null);
					}
					else
					{
						PopupGakuyaPresentUse2Setting s = new PopupGakuyaPresentUse2Setting();
						s.TitleText = string.Format(bk.GetMessageByLabel("pop_gakuya_present_ask_title"), itemInfo.m_presentData.OPFGFINHFCE_Name);
						s.Buttons = new ButtonInfo[2]
						{
							new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
							new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive },
						};
						s.WindowSize = SizeType.Large;
						s.m_divaPresentData = itemInfo.m_presentData;
						s.m_maxUseItemVal = m_intimacyController.viewData.LLFDOKOMJAN_GetPresentLeft();
						s.m_haveItemVal = itemInfo.m_presentData.GLHBKPNFLOP_Count;
						PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel buttonLabel) =>
						{
							//0xB7B278
							if(type == PopupButton.ButtonType.Positive)
							{
								m_isGivingPresent = true;
								Vector2 pos = RectTransformUtility.WorldToScreenPoint(GameManager.Instance.GetSystemCanvasCamera(), m_intimacyPresentEffectPos.position);
								int useItemCount = 1;
								if(presentDivaLimit)
								{
									useItemCount = (control.Content as PopupGakuyaPresentUse2Contents).UseItemVal;
								}
								GameManager.Instance.SetFPS(60);
								m_intimacyController.StartToPresentGakuya(itemInfo.m_presentData.ADJBIEOILPJ_Id, useItemCount, pos, () =>
								{
									//0xB7B1B8
									GameManager.Instance.SetFPS(30);
									m_isGivingPresent = false;
								});
							}
						}, null, null, null);
					}
				}
				else
				{
					MessageBank bk = MessageManager.Instance.GetBank("menu");
					TextPopupSetting s = new TextPopupSetting();
					s.TitleText = bk.GetMessageByLabel("pop_gakuya_present_limit_title");
					s.Text = bk.GetMessageByLabel("pop_gakuya_present_limit");
					s.Buttons = new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive },
					};
					s.WindowSize = SizeType.Small;
					PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel buttonLabel) =>
					{
						//0xB7A52C
						return;
					}, null, null, null);
				}
			}
			else
			{
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				TextPopupSetting s = new TextPopupSetting();
				s.TitleText = bk.GetMessageByLabel("pop_gakuya_present_limit_title");
				s.Text = bk.GetMessageByLabel("pop_gakuya_present_lv_max");
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive },
				};
				s.WindowSize = SizeType.Small;
				PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel buttonLabel) =>
				{
					//0xB7A528
					return;
				}, null, null, null);
			}
		}

		//// RVA: 0xB793BC Offset: 0xB793BC VA: 0xB793BC
		private void OnClickDiva()
		{
			if (MenuScene.Instance.DirtyChangeScene)
				return;
			if (!IsEnableIntimacyHint())
				return;
			m_intimacyController.charTouchPlaySe();
			StartIntimacyHint();
		}

		//// RVA: 0xB794A0 Offset: 0xB794A0 VA: 0xB794A0
		private void InitDivaCostumeInfos()
		{
			m_divaCostumeInfos.Clear();
			int id = 0;
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.BBIOMNCILMC_HomeDivaId == 0)
			{
				id = GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].AHHJLDLAPAN_DivaId;
			}
			foreach(var d in GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas)
			{
				if(id != d.AHHJLDLAPAN_DivaId)
				{
					m_divaCostumeInfos.Add(new DivaCostumeInfo(d.AHHJLDLAPAN_DivaId, d.EGAFMGDFFCH_HomeDivaCostume.DAJGPBLEEOB_PrismCostumeId, d.JFFLFIMIMOI_HomeColorId));
				}
				else
				{
					m_divaCostumeInfos.Add(new DivaCostumeInfo(d.AHHJLDLAPAN_DivaId, d.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, d.EKFONBFDAAP_ColorId));
				}
			}
		}

		//// RVA: 0xB79994 Offset: 0xB79994 VA: 0xB79994
		private DivaCostumeInfo GetDivaCostumeInfo(int divaId)
		{
			return m_divaCostumeInfos.Find((DivaCostumeInfo _) =>
			{
				//0xB7B648
				return _.divaId == divaId;
			});
		}

		//// RVA: 0xB79A94 Offset: 0xB79A94 VA: 0xB79A94
		private void SetDivaCostumeInfo(int divaId, int modelId, int colorId)
		{
			DivaCostumeInfo info = m_divaCostumeInfos.Find((DivaCostumeInfo _) =>
			{
				//0xB7B680
				return _.divaId == divaId;
			});
			if(info != null)
			{
				info.modelId = modelId;
				info.colorId = colorId;
			}
		}

		//// RVA: 0xB79BA8 Offset: 0xB79BA8 VA: 0xB79BA8
		private bool IsMatchCostumeInfo(DivaCostumeInfo info)
		{
			DivaCostumeInfo data = GetDivaCostumeInfo(info.divaId);
			if (data == null)
				return true;
			else return data.modelId == info.modelId && data.colorId == info.colorId;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DF5BC Offset: 0x6DF5BC VA: 0x6DF5BC
		//// RVA: 0xB79C14 Offset: 0xB79C14 VA: 0xB79C14
		private IEnumerator Co_LoadDivaResource(int divaId)
		{
			//0xB801F0
			m_divaResource.Release();
			m_divaResource.Initialize(divaId);
			yield return Co.R(m_divaResource.Co_LoadBasicResource());
			yield return Co.R(m_divaResource.Co_LoadMotion());
			bool isWaitLoadCueSheet = true;
			StringBuilder str = new StringBuilder(32);
			str.SetFormat("cs_coschange_{0:D3}", divaId);
			m_voicePlayer.RequestChangeCueSheet(str.ToString(), () =>
			{
				//0xB7B6C0
				isWaitLoadCueSheet = false;
			});
			m_voicePlayIndex = 0;
			while (isWaitLoadCueSheet)
				yield return null;
			CriAtomCueSheet sheet = CriAtom.GetCueSheet(m_voicePlayer.source.cueSheet);
			if(sheet != null)
			{
				CriAtomEx.CueInfo[] l = sheet.acb.GetCueInfoList();
				if(l != null)
				{
					m_voiceCueCount = l.Length;
				}
			}
		}

		//// RVA: 0xB79CDC Offset: 0xB79CDC VA: 0xB79CDC
		private void PreSetAllHomeCostume()
		{
			foreach(var d in GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas)
			{
				if(d.FJODMPGPDDD_DivaHave)
				{
					DivaCostumeInfo info = GetDivaCostumeInfo(d.AHHJLDLAPAN_DivaId);
					GameManager.Instance.ViewPlayerData.OPDBFHFKKJN_SetHomeCostume(d.AHHJLDLAPAN_DivaId, GetCostumeId(d.AHHJLDLAPAN_DivaId, info.modelId), info.colorId);
					return;
				}
			}
		}

		//// RVA: 0xB772E8 Offset: 0xB772E8 VA: 0xB772E8
		//private void ApplySaveData(Action onSuccess) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6DF634 Offset: 0x6DF634 VA: 0x6DF634
		//// RVA: 0xB7A08C Offset: 0xB7A08C VA: 0xB7A08C
		private IEnumerator Co_ApplySavedata(Action onSuccess)
		{
			//0xB7D798
			if(MenuScene.Instance.GetInputDisableCount() < 1)
			{
				MenuScene.Instance.InputDisable();
			}
			int prevDiva = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.BBIOMNCILMC_HomeDivaId;
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.BBIOMNCILMC_HomeDivaId = m_divaId;
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
			List<int> l = new List<int>();
			foreach(var diva in GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas)
			{
				if(m_divaId != diva.AHHJLDLAPAN_DivaId && diva.FJODMPGPDDD_DivaHave)
				{
					int oldCos = diva.KIIMFCFMMDN_HomeCostumeId;
					int oldCol = diva.JFFLFIMIMOI_HomeColorId;
					DivaCostumeInfo cinfo = GetDivaCostumeInfo(diva.AHHJLDLAPAN_DivaId);
					GameManager.Instance.ViewPlayerData.OPDBFHFKKJN_SetHomeCostume(diva.AHHJLDLAPAN_DivaId, GetCostumeId(diva.AHHJLDLAPAN_DivaId, cinfo.modelId), cinfo.colorId);
					int newCos = diva.KIIMFCFMMDN_HomeCostumeId;
					int newCol = diva.JFFLFIMIMOI_HomeColorId;
					if(oldCos != newCos || oldCol != newCol)
					{
						l.Add(diva.AHHJLDLAPAN_DivaId);
					}
				}
			}
			JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = true;
			JDDGPJDKHNE.HHCJCDFCLOB.NFNLGGHMEAM();
			FFHPBEPOMAK_DivaInfo d = GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas.Find((FFHPBEPOMAK_DivaInfo _) =>
			{
				//0xB7B6D4
				return _.AHHJLDLAPAN_DivaId == m_divaId;
			});
			{
				int oldCos = d.KIIMFCFMMDN_HomeCostumeId;
				int oldCol = d.JFFLFIMIMOI_HomeColorId;
				DivaCostumeInfo cinfo = GetDivaCostumeInfo(m_divaId);
				GameManager.Instance.ViewPlayerData.OPDBFHFKKJN_SetHomeCostume(m_divaId, GetCostumeId(m_divaId, cinfo.modelId), cinfo.colorId);
				int newCos = d.KIIMFCFMMDN_HomeCostumeId;
				int newCol = d.JFFLFIMIMOI_HomeColorId;
				if (oldCos != newCos || oldCol != newCol)
				{
					l.Add(m_divaId);
				}
				if(oldCos != newCos || oldCol != newCol || m_divaId != prevDiva)
				{
					ILCCJNDFFOB.HHCJCDFCLOB.NBCACPPAAMC(prevDiva, m_divaId, oldCos, newCos, oldCol, newCol);
				}
			}
			if(l.Count > 0 && GNGMCIAIKMA.HHCJCDFCLOB != null)
			{
				foreach(var a in l)
				{
					GNGMCIAIKMA.HHCJCDFCLOB.GJENEJOANEL(DKFJADMCNPI.NLKCMNHOBAI.HOOJOFACOEK/*7*/, a, 1, null);
				}
				GNGMCIAIKMA.HHCJCDFCLOB.HEFIKPAHCIA_IsBingoValid(null, -1);
			}
			bool isWait = true;
			bool isSuccess = false;
			MenuScene.Save(() =>
			{
				//0xB7B720
				isWait = false;
				isSuccess = true;
			}, () =>
			{
				//0xB7B72C
				isWait = false;
			});
			while (isWait)
				yield return null;
			MenuScene.Instance.InputEnable();
			if (isSuccess && onSuccess != null)
				onSuccess();
		}

		//// RVA: 0xB79F88 Offset: 0xB79F88 VA: 0xB79F88
		private int GetCostumeId(int divaId, int modelId)
		{
			LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.NLIBHNJNJAN_GetUnlockedCostumeOrDefault(divaId, modelId);
			if (cos != null)
				return cos.JPIDIENBGKH_CostumeId;
			return 0;
		}

		//// RVA: 0xB75920 Offset: 0xB75920 VA: 0xB75920
		//private void UpdateIntimacyHint() { }

		//// RVA: 0xB77C5C Offset: 0xB77C5C VA: 0xB77C5C
		private void StartIntimacyHint()
		{
			if (!IsEnableIntimacy())
				return;
			m_isPlayedIntimacyHint = true;
			m_intimacyController.GakuyaSerifChenge();
			m_intimacyHintTimeCount = 0;
			StartLeaveIntimacyHint();
		}

		//// RVA: 0xB767F8 Offset: 0xB767F8 VA: 0xB767F8
		private Coroutine CancelIntimacyHint()
		{
			if (!m_isPlayedIntimacyHint)
				return null;
			return this.StartCoroutineWatched(m_intimacyController.GakuyaCancelReaction());
		}

		//// RVA: 0xB77A64 Offset: 0xB77A64 VA: 0xB77A64
		private bool IsEnableIntimacyHint()
		{
			if(m_isEntered && IsEnableIntimacy())
			{
				if(m_infos.CurrentSelectType == GakuyaInfos.SelectType.Gift)
				{
					if(!m_isChangingDiva && !m_isChangingCostume)
					{
						if(m_divaTalk.IsEnableReaction())
						{
							if(!m_isGivingPresent && !m_isWaitIntimacyFirstPresent)
							{
								if(MenuScene.Instance.divaManager.IsCurrentBodyState(m_stateHashIdle))
								{
									if (!PopupWindowManager.IsOpenPopupWindow())
									{
										return !GameManager.Instance.IsTutorial;
									}
								}
							}
						}
					}
				}
			}
			return false;
		}

		//// RVA: 0xB76264 Offset: 0xB76264 VA: 0xB76264
		private bool IsEnableIntimacy()
		{
			if (m_infos != null)
				return !m_infos.IsLockGift;
			return false;
		}

		//// RVA: 0xB7A154 Offset: 0xB7A154 VA: 0xB7A154
		private void StartLeaveIntimacyHint()
		{
			if (m_coroutineIntimacyHintLeave != null)
				this.StopCoroutineWatched(m_coroutineIntimacyHintLeave);
			m_coroutineIntimacyHintLeave = null;
			m_coroutineIntimacyHintLeave = this.StartCoroutineWatched(Co_LeaveIntimacyHint());
		}

		//// RVA: 0xB7684C Offset: 0xB7684C VA: 0xB7684C
		//private void CancelLeaveIntimacyHint() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6DF6AC Offset: 0x6DF6AC VA: 0x6DF6AC
		//// RVA: 0xB7A1A0 Offset: 0xB7A1A0 VA: 0xB7A1A0
		private IEnumerator Co_LeaveIntimacyHint()
		{
			float timeCount;

			//0xB7FAD0
			timeCount = 0;
			while(timeCount <= m_intimacyHintDispTime)
			{
				timeCount += Time.deltaTime;
				yield return null;
			}
			m_divaMessage.TryLeave();
			m_coroutineIntimacyHintLeave = null;
		}

		//// RVA: 0xB7A24C Offset: 0xB7A24C VA: 0xB7A24C
		private void OnBackButton()
		{
			if (MenuScene.Instance.GetInputDisableCount() > 0)
				return;
			OnClickHomeButton();
		}
	}
}
