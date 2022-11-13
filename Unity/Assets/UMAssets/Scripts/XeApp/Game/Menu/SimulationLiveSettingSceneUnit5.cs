using System.Collections;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class SimulationLiveSettingSceneUnit5 : LiveBeforeSceneBaseUnit5
	{
		private UGUIObject m_headButtonsObject; // 0x64
		private UGUIObject m_prismSettingButtonsObject; // 0x68
		private UGUIObject m_valkyrieButtonObject; // 0x6C
		private UGUIObject m_musicInfoObject; // 0x70
		private UGUIObject m_playButtonsObject; // 0x74
		private UGUIObject m_prismUnitInfoObject; // 0x78
		private SetDeckHeadButtons m_headButtons; // 0x7C
		private SetDeckPrismSettingButtons m_prismSettingButtons; // 0x80
		private SetDeckValkyrieButton m_valkyrieButton; // 0x84
		private SetDeckMusicInfo m_musicInfo; // 0x88
		private SetDeckPlayButtons m_playButtons; // 0x8C
		private SetDeckUnitInfoSLive m_prismUnitInfo; // 0x90
		private ConfigMenu m_gameSettingMenu; // 0x94
		private bool m_isWaitOnPostSetCanvas; // 0x98
		private bool m_isWaitActivateScene; // 0x99
		private bool m_isWaitExitAnimation; // 0x9A

		// // RVA: 0x12CD360 Offset: 0x12CD360 VA: 0x12CD360
		private void Awake()
		{
			SetupPrismPopupSetting();
			m_gameSettingMenu = ConfigMenu.Create(null);
			StartCoroutine(Co_LoadResource());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x72743C Offset: 0x72743C VA: 0x72743C
		// // RVA: 0x12CD3A0 Offset: 0x12CD3A0 VA: 0x12CD3A0
		private IEnumerator Co_LoadResource()
		{
			//0x12D05EC
			yield return CreateUGUIObjectCache();
			IsReady = true;
		}

		// // RVA: 0x12CD44C Offset: 0x12CD44C VA: 0x12CD44C Slot: 16
		protected override void OnPreSetCanvas()
		{
			InitializeUGUIObject();
			GameSetupData.MusicInfo musicInfo = Database.Instance.gameSetup.musicInfo;
			m_headButtons.OnClickSettingButton = this.OnClickGameSettingButton;
			m_prismSettingButtons.OnClickOriginalSettingButton = this.OnClickOriginalSetting;
			m_valkyrieButton.OnClickValkyrieButton = this.OnClickValkyrieButton;
			m_playButtons.OnClickPlayButton = this.OnClickPlayButton;
			m_prismUnitInfo.OnClickItem = this.OnClickPrismIetms;
			UpdatePrismData(Database.Instance.selectedMusic.GetSelectedMusicData().DLAEJOBELBH_MusicId, musicInfo);
			bool hasSettings = CheckExistOriginalSetting(m_prismData);
			m_headButtons.SetType(SetDeckHeadButtons.Type.SLive);
			m_prismSettingButtons.UpdateContent(m_prismData, SetDeckPrismSettingButtons.ModeType.SLive, hasSettings);
			m_valkyrieButton.UpdateContent(m_prismData);
			m_musicInfo.Set(Database.Instance.selectedMusic.GetSelectedMusicData(), musicInfo, true, SetDeckMusicInfo.BottomType.Description);
			m_musicInfo.SetPosType(SetDeckMusicInfo.PosType.SLive);
			m_playButtons.Set(SetDeckPlayButtons.SkipButtoType.Hide, 0, SetDeckPlayButtons.PlayButtonType.Play, 0);
			m_playButtons.SetPosType(SetDeckPlayButtons.PosType.SLive);
			m_prismUnitInfo.UpdateContent(m_prismData, musicInfo);
			base.OnPreSetCanvas();
		}

		// // RVA: 0x12CE1A0 Offset: 0x12CE1A0 VA: 0x12CE1A0 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			if(!IsApplyWait())
			{
				return base.IsEndPreSetCanvas();
			}
			return false;
		}

		// // RVA: 0x12CE228 Offset: 0x12CE228 VA: 0x12CE228 Slot: 18
		protected override void OnPostSetCanvas()
		{
			StartCoroutine(Co_OnPostSetCanvas());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7274B4 Offset: 0x7274B4 VA: 0x7274B4
		// // RVA: 0x12CE24C Offset: 0x12CE24C VA: 0x12CE24C
		private IEnumerator Co_OnPostSetCanvas() {
			//0x12D0718
			m_isWaitOnPostSetCanvas = true;
			yield return null;
			m_isWaitOnPostSetCanvas = false;
			yield break;
		}

		// // RVA: 0x12CE2F8 Offset: 0x12CE2F8 VA: 0x12CE2F8 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			if (!m_isWaitOnPostSetCanvas)
				return base.IsEndPostSetCanvas();
			return false;
		}

		// // RVA: 0x12CE310 Offset: 0x12CE310 VA: 0x12CE310 Slot: 14
		protected override void OnDestoryScene()
		{
			FinalizeUGUIObject();
			base.OnDestoryScene();
		}

		// // RVA: 0x12CE610 Offset: 0x12CE610 VA: 0x12CE610 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			m_headButtons.InOut.Enter(false, null);
			m_prismSettingButtons.InOut.Enter(false, null);
			m_valkyrieButton.InOut.Enter(false, null);
			m_prismUnitInfo.AnimeControl.TryEnter();
			m_musicInfo.InOut.Enter(false, null);
			m_musicInfo.ResetDescriptionScroll();
			m_playButtons.InOut.Enter(false, null);
		}

		// // RVA: 0x12CE7E8 Offset: 0x12CE7E8 VA: 0x12CE7E8 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !IsPlaying();
		}

		// // RVA: 0x12CE9BC Offset: 0x12CE9BC VA: 0x12CE9BC Slot: 12
		protected override void OnStartExitAnimation()
		{
			StartCoroutine(Co_ExitAnimation());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x72752C Offset: 0x72752C VA: 0x72752C
		// // RVA: 0x12CE9E0 Offset: 0x12CE9E0 VA: 0x12CE9E0
		private IEnumerator Co_ExitAnimation()
		{
			//0x12D0288
			m_isWaitExitAnimation = true;
			while (IsPlaying())
				yield return null;
			m_headButtons.InOut.Leave(false);
			m_prismSettingButtons.InOut.Leave(false);
			m_valkyrieButton.InOut.Leave(false);
			m_prismUnitInfo.AnimeControl.TryLeave();
			m_musicInfo.InOut.Leave(false);
			m_playButtons.InOut.Leave(false);
			while (IsPlaying())
				yield return null;
			m_isWaitExitAnimation = false;
		}

		// // RVA: 0x12CEA8C Offset: 0x12CEA8C VA: 0x12CEA8C Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return m_isWaitExitAnimation == false;
		}

		// // RVA: 0x12CEAA0 Offset: 0x12CEAA0 VA: 0x12CEAA0 Slot: 23
		protected override void OnActivateScene()
		{
			TodoLogger.Log(0, "OnActivateScene");
		}

		// // RVA: 0x12CEB50 Offset: 0x12CEB50 VA: 0x12CEB50 Slot: 24
		protected override bool IsEndActivateScene()
		{
			TodoLogger.Log(0, "IsEndActivateScene");
			return true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7275A4 Offset: 0x7275A4 VA: 0x7275A4
		// // RVA: 0x12CEAC4 Offset: 0x12CEAC4 VA: 0x12CEAC4
		// private IEnumerator Co_ShowHelp() { }

		// // RVA: 0x12CD8A8 Offset: 0x12CD8A8 VA: 0x12CD8A8
		private void InitializeUGUIObject()
		{
			m_headButtonsObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckHeadButtons");
			m_prismSettingButtonsObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckPrismSettingButtons");
			m_valkyrieButtonObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckValkyrieButton");
			m_musicInfoObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckMusicInfo");
			m_playButtonsObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckPlayButtons");
			m_prismUnitInfoObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckUnitInfo_SLive");
			m_headButtons = m_headButtonsObject.instanceObject.GetComponentInChildren<SetDeckHeadButtons>();
			m_prismSettingButtons = m_prismSettingButtonsObject.instanceObject.GetComponentInChildren<SetDeckPrismSettingButtons>();
			m_valkyrieButton = m_valkyrieButtonObject.instanceObject.GetComponentInChildren<SetDeckValkyrieButton>();
			m_musicInfo = m_musicInfoObject.instanceObject.GetComponentInChildren<SetDeckMusicInfo>();
			m_playButtons = m_playButtonsObject.instanceObject.GetComponentInChildren<SetDeckPlayButtons>();
			m_prismUnitInfo = m_prismUnitInfoObject.instanceObject.GetComponentInChildren<SetDeckUnitInfoSLive>();
			m_headButtonsObject.SetParent(transform, null);
			m_prismSettingButtonsObject.SetParent(transform, null);
			m_valkyrieButtonObject.SetParent(transform, null);
			m_musicInfoObject.SetParent(transform, null);
			m_playButtonsObject.SetParent(transform, null);
			m_prismUnitInfoObject.SetParent(transform, null);
			m_prismUnitInfo.transform.SetAsLastSibling();
			m_prismSettingButtons.transform.SetAsLastSibling();
			m_valkyrieButton.transform.SetAsLastSibling();
			m_headButtons.transform.SetAsLastSibling();
			m_musicInfo.transform.SetAsLastSibling();
			m_playButtons.transform.SetAsLastSibling();
			m_headButtonsObject.instanceObject.SetActive(true);
			m_prismSettingButtonsObject.instanceObject.SetActive(true);
			m_valkyrieButtonObject.instanceObject.SetActive(true);
			m_musicInfoObject.instanceObject.SetActive(true);
			m_playButtonsObject.instanceObject.SetActive(true);
			m_prismUnitInfoObject.instanceObject.SetActive(true);
			ClearUGUIObjectListener();
			HideUGUIObject();
		}

		// // RVA: 0x12CE330 Offset: 0x12CE330 VA: 0x12CE330
		private void FinalizeUGUIObject()
		{
			ClearUGUIObjectListener();
			HideUGUIObject();
			GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckHeadButtons", m_headButtonsObject);
			GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckPrismSettingButtons", m_prismSettingButtonsObject);
			GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckValkyrieButton", m_valkyrieButtonObject);
			GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckMusicInfo", m_musicInfoObject);
			GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckPlayButtons", m_playButtonsObject);
			GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckUnitInfo_SLive", m_prismUnitInfoObject);
			m_prismUnitInfoObject = null;
			m_headButtonsObject = null;
			m_prismSettingButtonsObject = null;
			m_valkyrieButtonObject = null;
			m_playButtonsObject = null;
			m_musicInfoObject = null;
		}

		// // RVA: 0x12CEB84 Offset: 0x12CEB84 VA: 0x12CEB84
		private void ClearUGUIObjectListener()
		{
			m_headButtons.OnClickAutoSettingButton = null;
			m_headButtons.OnClickUnitSetButton = null;
			m_headButtons.OnClickPrismButton = null;
			m_headButtons.OnClickUnitButton = null;
			m_headButtons.OnClickSettingButton = null;
			m_prismSettingButtons.OnClickOriginalSettingButton = null;
			m_valkyrieButton.OnClickValkyrieButton = null;
			m_valkyrieButton.OnStayValkyrieButton = null;
			m_musicInfo.OnClickExpectedScoreDescButton = null;
			m_playButtons.OnClickPlayButton = null;
			m_playButtons.OnClickSkipButton = null;
			m_prismUnitInfo.OnClickItem = null;
		}

		// // RVA: 0x12CECCC Offset: 0x12CECCC VA: 0x12CECCC
		private void HideUGUIObject()
		{
			m_headButtons.InOut.Leave(0, false, null);
			m_prismSettingButtons.InOut.Leave(0, false, null);
			m_valkyrieButton.InOut.Leave(0, false, null);
			m_musicInfo.InOut.Leave(0, false, null);
			m_playButtons.InOut.Leave(0, false, null);
			m_prismUnitInfo.AnimeControl.Hide();
		}

		// // RVA: 0x12CE1CC Offset: 0x12CE1CC VA: 0x12CE1CC
		private bool IsApplyWait()
		{
			if(!m_valkyrieButton.IsUpdatingContent)
			{
				return m_prismUnitInfo.IsUpdatingContent();
			}
			return true;
		}

		// // RVA: 0x12CE7FC Offset: 0x12CE7FC VA: 0x12CE7FC
		private bool IsPlaying()
		{
			return m_headButtons.InOut.IsPlaying() ||
					m_prismSettingButtons.InOut.IsPlaying() ||
					m_valkyrieButton.InOut.IsPlaying() ||
					m_musicInfo.InOut.IsPlaying() ||
					m_playButtons.InOut.IsPlaying() ||
					m_prismUnitInfo.AnimeControl.IsPlaying();
		}

		// // RVA: 0x12CEEB4 Offset: 0x12CEEB4 VA: 0x12CEEB4
		private void OnClickGameSettingButton()
		{
			TodoLogger.Log(0, "OnClickGameSettingButton");
		}

		// // RVA: 0x12CEF38 Offset: 0x12CEF38 VA: 0x12CEF38
		private void OnClickOriginalSetting()
		{
			TodoLogger.Log(0, "OnClickOriginalSetting");
		}

		// // RVA: 0x12CF0E8 Offset: 0x12CF0E8 VA: 0x12CF0E8
		private void OnClickValkyrieButton()
		{
			SoundManager.Instance.sePlayerBoot.Play(3);
			ShowPrismSelectPopup(PopupMvModeSelectListContent.SelectTarget.Valkyrie, 0, Database.Instance.selectedMusic.GetSelectedMusicData().DLAEJOBELBH_MusicId, Database.Instance.gameSetup.musicInfo, false, () =>
			{
				//0x12CFE44
				m_valkyrieButton.UpdateContent(m_prismData);
				StartApplyWait();
			}, null);
		}

		// // RVA: 0x12CF2A0 Offset: 0x12CF2A0 VA: 0x12CF2A0
		private void OnClickPlayButton()
		{
			SoundManager.Instance.sePlayerBoot.Play(1);
			AdvanceGame();
		}

		// // RVA: 0x12CF308 Offset: 0x12CF308 VA: 0x12CF308
		private void AdvanceGame()
		{
			TodoLogger.MinLog = 99;
			if (!CheckSetAllDiva(m_prismData))
			{
				NotSetAllDivaShow();
				return;
			}
			StatusData data = new StatusData();
			data.fold = 900;
			data.life = 500;
			data.soul = 30000;
			data.vocal = 15000;
			data.charm = 5000;
			data.support = 900;
			Database.Instance.gameSetup.SetMvMode(data, m_prismData);
			AdvanceGame(data, m_playerData, null, null, false, 0, 0, new JGEOBNENMAH.NEDILFPPCJF(), false);
		}

		// // RVA: 0x12CF4F8 Offset: 0x12CF4F8 VA: 0x12CF4F8
		private bool CheckSetAllDiva(AOJGDNFAIJL_PrismData.AMIECPBIALP prismData)
		{
			for(int i = 0;  i < Database.Instance.gameSetup.musicInfo.onStageDivaNum; i++)
			{
				if (prismData.PNBKLGKCKGO_GetPrismDivaIdForSlot(i) == 0 || prismData.OCNHIHMAGMJ_GetPrismCostumeIdForSlot(i) == 0)
					return false;
			}
			return prismData.PNDKNFBLKDP_GetPrismValkyrieId() > 0;
		}

		// // RVA: 0x12CF644 Offset: 0x12CF644 VA: 0x12CF644
		private void NotSetAllDivaShow()
		{
			MenuScene.Instance.InputDisable();
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(string.Empty, SizeType.Small, MessageManager.Instance.GetBank("menu").GetMessageByLabel("unit_multi_dance_popup_02"), new ButtonInfo[1] {
				new ButtonInfo() { Type = PopupButton.ButtonType.Positive, Label = PopupButton.ButtonLabel.Ok }
			}, false, false), (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x12CFFEC
				MenuScene.Instance.InputEnable();
			}, null, null, null);
		}

		// // RVA: 0x12CF9A8 Offset: 0x12CF9A8 VA: 0x12CF9A8
		private void OnClickPrismIetms(PopupMvModeSelectListContent.SelectTarget target, int divaSlotNumber)
		{
			ShowPrismSelectPopup(target, divaSlotNumber, Database.Instance.selectedMusic.GetSelectedMusicData().DLAEJOBELBH_MusicId, Database.Instance.gameSetup.musicInfo, false, () =>
			{
				//0x12CFE94
				m_prismUnitInfo.UpdateContent(m_prismData, Database.Instance.gameSetup.musicInfo);
				StartApplyWait();
			}, null);
		}

		// // RVA: 0x12CFB68 Offset: 0x12CFB68 VA: 0x12CFB68
		private void StartApplyWait()
		{
			StartCoroutine(Co_ApplyWait());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x72761C Offset: 0x72761C VA: 0x72761C
		// // RVA: 0x12CFB8C Offset: 0x12CFB8C VA: 0x12CFB8C
		private IEnumerator Co_ApplyWait()
		{
			//0x12D008C
			MenuScene.Instance.RaycastDisable();
			while(IsApplyWait())
				yield return null;
			MenuScene.Instance.RaycastEnable();
		}

		// // RVA: 0x12CFC38 Offset: 0x12CFC38 VA: 0x12CFC38
		// private bool CheckTutorialCondition(TutorialConditionId conditionId) { }

		// [CompilerGeneratedAttribute] // RVA: 0x727694 Offset: 0x727694 VA: 0x727694
		// // RVA: 0x12CFD68 Offset: 0x12CFD68 VA: 0x12CFD68
		// private void <OnClickOriginalSetting>b__39_0() { }
	}
}
