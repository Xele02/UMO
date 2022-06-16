using UnityEngine;
using System.Collections;

namespace XeApp.Game.Common
{
	public class SoundManager : MonoBehaviour
	{
		public enum CategoryId
		{
			MENU_SE = 0,
			MENU_VOICE = 1,
			MENU_BGM = 2,
			GAME_SE = 3,
			GAME_VOICE = 4,
			GAME_BGM = 5,
			GAME_NOTES = 6,
		}
		// private CriAtomExLatencyEstimator.EstimatorInfo estimatorInfo; // 0x6C
		public const float MAX_MARK = 20;
		public const float MAX_VOLUME = 1;
		public const float MAX_VOLUME_NOTES = 1.35f;

		public static SoundManager Instance { get; private set; } // 0x0
		public BgmPlayer bgmPlayer { get; private set; } // 0xC
		public DivaVoicePlayer voDiva { get; private set; } // 0x10
		public DivaCosVoicePlayer voDivaCos { get; private set; } // 0x14
		public DivaVoicePlayer voOtherDiva { get; private set; } // 0x18
		public TitlecallVoicePlayer voTitlecall { get; private set; } // 0x1C
		public GreetingVoicePlayer voGreeting { get; private set; } // 0x20
		public PilotVoicePlayer voPilot { get; private set; } // 0x24
		public SeasonEventVoicePlayer voSeasonEvent { get; private set; } // 0x28
		public AdvVoicePlayer voAdv { get; private set; } // 0x2C
		public CheerPlayer sePlayerCheer { get; private set; } // 0x30
		public ARDivaVoicePlayer voARDiva { get; private set; } // 0x34
		public CriAtomSource sePlayerBoot { get; private set; } // 0x38
		public CriAtomSource sePlayerMenu { get; private set; } // 0x3C
		public CriAtomSource sePlayerGacha { get; private set; } // 0x40
		public CriAtomSource sePlayerGame { get; private set; } // 0x44
		public CriAtomSource sePlayerNotes { get; private set; } // 0x48
		public CriAtomSource sePlayerLongNotes { get; private set; } // 0x4C
		public CriAtomSource sePlayerResult { get; private set; } // 0x50
		public CriAtomSource sePlayerResultLoop { get; private set; } // 0x54
		public CriAtomSource sePlayerAdv { get; private set; } // 0x58
		public CriAtomSource sePlayerRaid { get; private set; } // 0x5C
		public CriAtomSource sePlayerRaidLoop { get; private set; } // 0x60
		public CriAtomSource sePlayerMiniGame { get; private set; } // 0x64
		public bool isInitialized { get; private set; } // 0x68
		// public bool isEestimatorInitialized { get; private set; } 0x13959DC 0x13959F0
		// public int estimatedLatencyMillisec { get; private set; } 0x13959F4 0x1395A0C

		// // RVA: 0x1395A10 Offset: 0x1395A10 VA: 0x1395A10
		private void Awake()
		{
			Instance = this;
			isInitialized = false;
			StartCoroutine(SurveyLatencyEstimator());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73AFB8 Offset: 0x73AFB8 VA: 0x73AFB8
		// // RVA: 0x1395A94 Offset: 0x1395A94 VA: 0x1395A94
		private IEnumerator SurveyLatencyEstimator()
		{
			UnityEngine.Debug.LogWarning("TODO SoundManager.SurveyLatencyEstimator");
			yield break;
		}

		// // RVA: 0x1395B40 Offset: 0x1395B40 VA: 0x1395B40
		public void Initialize()
		{
			isInitialized = true;
			SoundResource.AddCueSheet("cs_se_boot");

			bgmPlayer = gameObject.AddComponent<BgmPlayer>();
			voDiva = gameObject.AddComponent<DivaVoicePlayer>();
			voDivaCos = gameObject.AddComponent<DivaCosVoicePlayer>();
			voOtherDiva = gameObject.AddComponent<DivaVoicePlayer>();
			voTitlecall = gameObject.AddComponent<TitlecallVoicePlayer>();
			voGreeting = gameObject.AddComponent<GreetingVoicePlayer>();
			voPilot = gameObject.AddComponent<PilotVoicePlayer>();
			voSeasonEvent = gameObject.AddComponent<SeasonEventVoicePlayer>();
			voAdv = gameObject.AddComponent<AdvVoicePlayer>();
			voARDiva = gameObject.AddComponent<ARDivaVoicePlayer>();

			sePlayerCheer = new CheerPlayer();
			sePlayerCheer.Create(gameObject);
			sePlayerBoot = gameObject.AddComponent<CriAtomSource>();
			sePlayerBoot.cueSheet = "cs_se_boot";
			sePlayerBoot.androidUseLowLatencyVoicePool = true;
			sePlayerMenu = gameObject.AddComponent<CriAtomSource>();
			sePlayerMenu.cueSheet = "cs_se_menu";
			sePlayerMenu.androidUseLowLatencyVoicePool = true;
			sePlayerGacha = gameObject.AddComponent<CriAtomSource>();
			sePlayerGacha.cueSheet = "cs_se_gacha";
			sePlayerGacha.androidUseLowLatencyVoicePool = true;
			sePlayerGame = gameObject.AddComponent<CriAtomSource>();
			sePlayerGame.cueSheet = "cs_se_game";
			sePlayerGame.androidUseLowLatencyVoicePool = true;
			sePlayerNotes = gameObject.AddComponent<CriAtomSource>();
			sePlayerNotes.cueSheet = "cs_se_notes";
			sePlayerNotes.androidUseLowLatencyVoicePool = true;
			sePlayerLongNotes = gameObject.AddComponent<CriAtomSource>();
			sePlayerLongNotes.cueSheet = "cs_se_notes";
			sePlayerLongNotes.androidUseLowLatencyVoicePool = true;
			sePlayerResult = gameObject.AddComponent<CriAtomSource>();
			sePlayerResult.cueSheet = "cs_se_result";
			sePlayerResult.androidUseLowLatencyVoicePool = true;
			sePlayerResultLoop = gameObject.AddComponent<CriAtomSource>();
			sePlayerResultLoop.cueSheet = "cs_se_result";
			sePlayerResultLoop.androidUseLowLatencyVoicePool = true;
			sePlayerAdv = gameObject.AddComponent<CriAtomSource>();
			sePlayerAdv.cueSheet = "cs_se_adv";
			sePlayerAdv.androidUseLowLatencyVoicePool = true;
			sePlayerRaid = gameObject.AddComponent<CriAtomSource>();
			sePlayerRaid.cueSheet = "cs_se_raid";
			sePlayerRaid.androidUseLowLatencyVoicePool = true;
			sePlayerRaidLoop = gameObject.AddComponent<CriAtomSource>();
			sePlayerRaidLoop.cueSheet = "cs_se_raid";
			sePlayerRaidLoop.androidUseLowLatencyVoicePool = true;
			sePlayerMiniGame = gameObject.AddComponent<CriAtomSource>();
			sePlayerMiniGame.cueSheet = "cs_se_minigame";
			sePlayerMiniGame.androidUseLowLatencyVoicePool = true;
		}

		// // RVA: 0x139654C Offset: 0x139654C VA: 0x139654C
		// public void RequestEntryRhythmGameCueSheet(UnityAction onLoadedCallback, int forceNoteSe = 0) { }

		// // RVA: 0x139697C Offset: 0x139697C VA: 0x139697C
		// public void RequestEntryMenuCueSheet(UnityAction onLoadedCallback) { }

		// // RVA: 0x1396BFC Offset: 0x1396BFC VA: 0x1396BFC
		// public void RequestEntryGachaCueSheet(UnityAction onLoadedCallback) { }

		// // RVA: 0x1396D70 Offset: 0x1396D70 VA: 0x1396D70
		// public void RequestEntryAdvCueSheet(UnityAction onLoadedCallback) { }

		// // RVA: 0x1396E78 Offset: 0x1396E78 VA: 0x1396E78
		// public void RequestEntryMiniGameCueSheet(UnityAction onLoadedCallback) { }

		// // RVA: 0x13967AC Offset: 0x13967AC VA: 0x13967AC
		// private void RemoveSectionallySECueSheet() { }

		// [IteratorStateMachineAttribute] // RVA: 0x73B030 Offset: 0x73B030 VA: 0x73B030
		// // RVA: 0x13968D4 Offset: 0x13968D4 VA: 0x13968D4
		// private IEnumerator Co_InstallProcess(string[] cueSheetList, UnityAction onLoadedCallback) { }

		// // RVA: 0x1396FA0 Offset: 0x1396FA0 VA: 0x1396FA0
		public void SetCategoryVolumeFromMark(CategoryId a_id, int a_mark, bool a_is_slive = false)
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x1397094 Offset: 0x1397094 VA: 0x1397094
		// public void SetCategoryVolume(SoundManager.CategoryId id, float vol) { }

		// // RVA: 0x139729C Offset: 0x139729C VA: 0x139729C
		public float GetCategoryVolume(SoundManager.CategoryId id)
		{
			UnityEngine.Debug.LogWarning("TODO SoundManager.GetCategoryVolume");
			return 0;
		}

		// // RVA: 0x13973D8 Offset: 0x13973D8 VA: 0x13973D8
		// public void StopAllSounds() { }

		// // RVA: 0x1394B14 Offset: 0x1394B14 VA: 0x1394B14
		// public bool IsUingCueSheetByVoicePlayer(string cueSheetName) { }
	}
}
