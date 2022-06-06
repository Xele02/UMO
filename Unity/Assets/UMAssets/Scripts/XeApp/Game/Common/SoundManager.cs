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
		// [CompilerGeneratedAttribute] // RVA: 0x687A60 Offset: 0x687A60 VA: 0x687A60
		// private static SoundManager <Instance>k__BackingField; // 0x0
		// [CompilerGeneratedAttribute] // RVA: 0x687A70 Offset: 0x687A70 VA: 0x687A70
		// private BgmPlayer <bgmPlayer>k__BackingField; // 0xC
		// [CompilerGeneratedAttribute] // RVA: 0x687A80 Offset: 0x687A80 VA: 0x687A80
		// private DivaVoicePlayer <voDiva>k__BackingField; // 0x10
		// [CompilerGeneratedAttribute] // RVA: 0x687A90 Offset: 0x687A90 VA: 0x687A90
		// private DivaCosVoicePlayer <voDivaCos>k__BackingField; // 0x14
		// [CompilerGeneratedAttribute] // RVA: 0x687AA0 Offset: 0x687AA0 VA: 0x687AA0
		// private DivaVoicePlayer <voOtherDiva>k__BackingField; // 0x18
		// [CompilerGeneratedAttribute] // RVA: 0x687AB0 Offset: 0x687AB0 VA: 0x687AB0
		// private TitlecallVoicePlayer <voTitlecall>k__BackingField; // 0x1C
		// [CompilerGeneratedAttribute] // RVA: 0x687AC0 Offset: 0x687AC0 VA: 0x687AC0
		// private GreetingVoicePlayer <voGreeting>k__BackingField; // 0x20
		// [CompilerGeneratedAttribute] // RVA: 0x687AD0 Offset: 0x687AD0 VA: 0x687AD0
		// private PilotVoicePlayer <voPilot>k__BackingField; // 0x24
		// [CompilerGeneratedAttribute] // RVA: 0x687AE0 Offset: 0x687AE0 VA: 0x687AE0
		// private SeasonEventVoicePlayer <voSeasonEvent>k__BackingField; // 0x28
		// [CompilerGeneratedAttribute] // RVA: 0x687AF0 Offset: 0x687AF0 VA: 0x687AF0
		// private AdvVoicePlayer <voAdv>k__BackingField; // 0x2C
		// [CompilerGeneratedAttribute] // RVA: 0x687B00 Offset: 0x687B00 VA: 0x687B00
		// private CheerPlayer <sePlayerCheer>k__BackingField; // 0x30
		// [CompilerGeneratedAttribute] // RVA: 0x687B10 Offset: 0x687B10 VA: 0x687B10
		// private ARDivaVoicePlayer <voARDiva>k__BackingField; // 0x34
		// [CompilerGeneratedAttribute] // RVA: 0x687B20 Offset: 0x687B20 VA: 0x687B20
		// private CriAtomSource <sePlayerBoot>k__BackingField; // 0x38
		// [CompilerGeneratedAttribute] // RVA: 0x687B30 Offset: 0x687B30 VA: 0x687B30
		// private CriAtomSource <sePlayerMenu>k__BackingField; // 0x3C
		// [CompilerGeneratedAttribute] // RVA: 0x687B40 Offset: 0x687B40 VA: 0x687B40
		// private CriAtomSource <sePlayerGacha>k__BackingField; // 0x40
		// [CompilerGeneratedAttribute] // RVA: 0x687B50 Offset: 0x687B50 VA: 0x687B50
		// private CriAtomSource <sePlayerGame>k__BackingField; // 0x44
		// [CompilerGeneratedAttribute] // RVA: 0x687B60 Offset: 0x687B60 VA: 0x687B60
		// private CriAtomSource <sePlayerNotes>k__BackingField; // 0x48
		// [CompilerGeneratedAttribute] // RVA: 0x687B70 Offset: 0x687B70 VA: 0x687B70
		// private CriAtomSource <sePlayerLongNotes>k__BackingField; // 0x4C
		// [CompilerGeneratedAttribute] // RVA: 0x687B80 Offset: 0x687B80 VA: 0x687B80
		// private CriAtomSource <sePlayerResult>k__BackingField; // 0x50
		// [CompilerGeneratedAttribute] // RVA: 0x687B90 Offset: 0x687B90 VA: 0x687B90
		// private CriAtomSource <sePlayerResultLoop>k__BackingField; // 0x54
		// [CompilerGeneratedAttribute] // RVA: 0x687BA0 Offset: 0x687BA0 VA: 0x687BA0
		// private CriAtomSource <sePlayerAdv>k__BackingField; // 0x58
		// [CompilerGeneratedAttribute] // RVA: 0x687BB0 Offset: 0x687BB0 VA: 0x687BB0
		// private CriAtomSource <sePlayerRaid>k__BackingField; // 0x5C
		// [CompilerGeneratedAttribute] // RVA: 0x687BC0 Offset: 0x687BC0 VA: 0x687BC0
		// private CriAtomSource <sePlayerRaidLoop>k__BackingField; // 0x60
		// [CompilerGeneratedAttribute] // RVA: 0x687BD0 Offset: 0x687BD0 VA: 0x687BD0
		// private CriAtomSource <sePlayerMiniGame>k__BackingField; // 0x64
		// [CompilerGeneratedAttribute] // RVA: 0x687BE0 Offset: 0x687BE0 VA: 0x687BE0
		// private bool <isInitialized>k__BackingField; // 0x68
		// private CriAtomExLatencyEstimator.EstimatorInfo estimatorInfo; // 0x6C
		public const float MAX_MARK = 20;
		public const float MAX_VOLUME = 1;
		public const float MAX_VOLUME_NOTES = 1.35f;

		public static SoundManager Instance { get; set; }
		public BgmPlayer bgmPlayer { get; set; }
		public DivaVoicePlayer voDiva { get; set; }
		public DivaCosVoicePlayer voDivaCos { get; set; }
		public DivaVoicePlayer voOtherDiva { get; set; }
		public TitlecallVoicePlayer voTitlecall { get; set; }
		public GreetingVoicePlayer voGreeting { get; set; }
		public PilotVoicePlayer voPilot { get; set; }
		public SeasonEventVoicePlayer voSeasonEvent { get; set; }
		public AdvVoicePlayer voAdv { get; set; }
		public CheerPlayer sePlayerCheer { get; set; }
		public ARDivaVoicePlayer voARDiva { get; set; }
		public CriAtomSource sePlayerBoot { get; set; }
		public CriAtomSource sePlayerMenu { get; set; }
		public CriAtomSource sePlayerGacha { get; set; }
		public CriAtomSource sePlayerGame { get; set; }
		public CriAtomSource sePlayerNotes { get; set; }
		public CriAtomSource sePlayerLongNotes { get; set; }
		public CriAtomSource sePlayerResult { get; set; }
		public CriAtomSource sePlayerResultLoop { get; set; }
		public CriAtomSource sePlayerAdv { get; set; }
		public CriAtomSource sePlayerRaid { get; set; }
		public CriAtomSource sePlayerRaidLoop { get; set; }
		public CriAtomSource sePlayerMiniGame { get; set; }
		public bool isInitialized { get; set; }
		public bool isEestimatorInitialized { get; set; }
		public int estimatedLatencyMillisec { get; set; }

		// // Methods

		// [CompilerGeneratedAttribute] // RVA: 0x73AC98 Offset: 0x73AC98 VA: 0x73AC98
		// // RVA: 0x1388C20 Offset: 0x1388C20 VA: 0x1388C20
		// public static SoundManager get_Instance() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73ACA8 Offset: 0x73ACA8 VA: 0x73ACA8
		// // RVA: 0x1395820 Offset: 0x1395820 VA: 0x1395820
		// private static void set_Instance(SoundManager value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73ACB8 Offset: 0x73ACB8 VA: 0x73ACB8
		// // RVA: 0x1388C84 Offset: 0x1388C84 VA: 0x1388C84
		// public BgmPlayer get_bgmPlayer() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73ACC8 Offset: 0x73ACC8 VA: 0x73ACC8
		// // RVA: 0x1395884 Offset: 0x1395884 VA: 0x1395884
		// private void set_bgmPlayer(BgmPlayer value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73ACD8 Offset: 0x73ACD8 VA: 0x73ACD8
		// // RVA: 0x1388C8C Offset: 0x1388C8C VA: 0x1388C8C
		// public DivaVoicePlayer get_voDiva() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73ACE8 Offset: 0x73ACE8 VA: 0x73ACE8
		// // RVA: 0x139588C Offset: 0x139588C VA: 0x139588C
		// private void set_voDiva(DivaVoicePlayer value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73ACF8 Offset: 0x73ACF8 VA: 0x73ACF8
		// // RVA: 0x1388E94 Offset: 0x1388E94 VA: 0x1388E94
		// public DivaCosVoicePlayer get_voDivaCos() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AD08 Offset: 0x73AD08 VA: 0x73AD08
		// // RVA: 0x1395894 Offset: 0x1395894 VA: 0x1395894
		// private void set_voDivaCos(DivaCosVoicePlayer value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AD18 Offset: 0x73AD18 VA: 0x73AD18
		// // RVA: 0x139589C Offset: 0x139589C VA: 0x139589C
		// public DivaVoicePlayer get_voOtherDiva() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AD28 Offset: 0x73AD28 VA: 0x73AD28
		// // RVA: 0x13958A4 Offset: 0x13958A4 VA: 0x13958A4
		// private void set_voOtherDiva(DivaVoicePlayer value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AD38 Offset: 0x73AD38 VA: 0x73AD38
		// // RVA: 0x13958AC Offset: 0x13958AC VA: 0x13958AC
		// public TitlecallVoicePlayer get_voTitlecall() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AD48 Offset: 0x73AD48 VA: 0x73AD48
		// // RVA: 0x13958B4 Offset: 0x13958B4 VA: 0x13958B4
		// private void set_voTitlecall(TitlecallVoicePlayer value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AD58 Offset: 0x73AD58 VA: 0x73AD58
		// // RVA: 0x13958BC Offset: 0x13958BC VA: 0x13958BC
		// public GreetingVoicePlayer get_voGreeting() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AD68 Offset: 0x73AD68 VA: 0x73AD68
		// // RVA: 0x13958C4 Offset: 0x13958C4 VA: 0x13958C4
		// private void set_voGreeting(GreetingVoicePlayer value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AD78 Offset: 0x73AD78 VA: 0x73AD78
		// // RVA: 0x1388E8C Offset: 0x1388E8C VA: 0x1388E8C
		// public PilotVoicePlayer get_voPilot() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AD88 Offset: 0x73AD88 VA: 0x73AD88
		// // RVA: 0x13958CC Offset: 0x13958CC VA: 0x13958CC
		// private void set_voPilot(PilotVoicePlayer value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AD98 Offset: 0x73AD98 VA: 0x73AD98
		// // RVA: 0x1388E9C Offset: 0x1388E9C VA: 0x1388E9C
		// public SeasonEventVoicePlayer get_voSeasonEvent() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73ADA8 Offset: 0x73ADA8 VA: 0x73ADA8
		// // RVA: 0x13958D4 Offset: 0x13958D4 VA: 0x13958D4
		// private void set_voSeasonEvent(SeasonEventVoicePlayer value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73ADB8 Offset: 0x73ADB8 VA: 0x73ADB8
		// // RVA: 0x13958DC Offset: 0x13958DC VA: 0x13958DC
		// public AdvVoicePlayer get_voAdv() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73ADC8 Offset: 0x73ADC8 VA: 0x73ADC8
		// // RVA: 0x13958E4 Offset: 0x13958E4 VA: 0x13958E4
		// private void set_voAdv(AdvVoicePlayer value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73ADD8 Offset: 0x73ADD8 VA: 0x73ADD8
		// // RVA: 0x13958EC Offset: 0x13958EC VA: 0x13958EC
		// public CheerPlayer get_sePlayerCheer() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73ADE8 Offset: 0x73ADE8 VA: 0x73ADE8
		// // RVA: 0x13958F4 Offset: 0x13958F4 VA: 0x13958F4
		// private void set_sePlayerCheer(CheerPlayer value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73ADF8 Offset: 0x73ADF8 VA: 0x73ADF8
		// // RVA: 0x13958FC Offset: 0x13958FC VA: 0x13958FC
		// public ARDivaVoicePlayer get_voARDiva() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AE08 Offset: 0x73AE08 VA: 0x73AE08
		// // RVA: 0x1395904 Offset: 0x1395904 VA: 0x1395904
		// private void set_voARDiva(ARDivaVoicePlayer value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AE18 Offset: 0x73AE18 VA: 0x73AE18
		// // RVA: 0x139590C Offset: 0x139590C VA: 0x139590C
		// public CriAtomSource get_sePlayerBoot() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AE28 Offset: 0x73AE28 VA: 0x73AE28
		// // RVA: 0x1395914 Offset: 0x1395914 VA: 0x1395914
		// private void set_sePlayerBoot(CriAtomSource value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AE38 Offset: 0x73AE38 VA: 0x73AE38
		// // RVA: 0x139591C Offset: 0x139591C VA: 0x139591C
		// public CriAtomSource get_sePlayerMenu() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AE48 Offset: 0x73AE48 VA: 0x73AE48
		// // RVA: 0x1395924 Offset: 0x1395924 VA: 0x1395924
		// private void set_sePlayerMenu(CriAtomSource value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AE58 Offset: 0x73AE58 VA: 0x73AE58
		// // RVA: 0x139592C Offset: 0x139592C VA: 0x139592C
		// public CriAtomSource get_sePlayerGacha() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AE68 Offset: 0x73AE68 VA: 0x73AE68
		// // RVA: 0x1395934 Offset: 0x1395934 VA: 0x1395934
		// private void set_sePlayerGacha(CriAtomSource value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AE78 Offset: 0x73AE78 VA: 0x73AE78
		// // RVA: 0x139593C Offset: 0x139593C VA: 0x139593C
		// public CriAtomSource get_sePlayerGame() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AE88 Offset: 0x73AE88 VA: 0x73AE88
		// // RVA: 0x1395944 Offset: 0x1395944 VA: 0x1395944
		// private void set_sePlayerGame(CriAtomSource value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AE98 Offset: 0x73AE98 VA: 0x73AE98
		// // RVA: 0x139594C Offset: 0x139594C VA: 0x139594C
		// public CriAtomSource get_sePlayerNotes() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AEA8 Offset: 0x73AEA8 VA: 0x73AEA8
		// // RVA: 0x1395954 Offset: 0x1395954 VA: 0x1395954
		// private void set_sePlayerNotes(CriAtomSource value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AEB8 Offset: 0x73AEB8 VA: 0x73AEB8
		// // RVA: 0x139595C Offset: 0x139595C VA: 0x139595C
		// public CriAtomSource get_sePlayerLongNotes() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AEC8 Offset: 0x73AEC8 VA: 0x73AEC8
		// // RVA: 0x1395964 Offset: 0x1395964 VA: 0x1395964
		// private void set_sePlayerLongNotes(CriAtomSource value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AED8 Offset: 0x73AED8 VA: 0x73AED8
		// // RVA: 0x139596C Offset: 0x139596C VA: 0x139596C
		// public CriAtomSource get_sePlayerResult() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AEE8 Offset: 0x73AEE8 VA: 0x73AEE8
		// // RVA: 0x1395974 Offset: 0x1395974 VA: 0x1395974
		// private void set_sePlayerResult(CriAtomSource value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AEF8 Offset: 0x73AEF8 VA: 0x73AEF8
		// // RVA: 0x139597C Offset: 0x139597C VA: 0x139597C
		// public CriAtomSource get_sePlayerResultLoop() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AF08 Offset: 0x73AF08 VA: 0x73AF08
		// // RVA: 0x1395984 Offset: 0x1395984 VA: 0x1395984
		// private void set_sePlayerResultLoop(CriAtomSource value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AF18 Offset: 0x73AF18 VA: 0x73AF18
		// // RVA: 0x139598C Offset: 0x139598C VA: 0x139598C
		// public CriAtomSource get_sePlayerAdv() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AF28 Offset: 0x73AF28 VA: 0x73AF28
		// // RVA: 0x1395994 Offset: 0x1395994 VA: 0x1395994
		// private void set_sePlayerAdv(CriAtomSource value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AF38 Offset: 0x73AF38 VA: 0x73AF38
		// // RVA: 0x139599C Offset: 0x139599C VA: 0x139599C
		// public CriAtomSource get_sePlayerRaid() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AF48 Offset: 0x73AF48 VA: 0x73AF48
		// // RVA: 0x13959A4 Offset: 0x13959A4 VA: 0x13959A4
		// private void set_sePlayerRaid(CriAtomSource value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AF58 Offset: 0x73AF58 VA: 0x73AF58
		// // RVA: 0x13959AC Offset: 0x13959AC VA: 0x13959AC
		// public CriAtomSource get_sePlayerRaidLoop() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AF68 Offset: 0x73AF68 VA: 0x73AF68
		// // RVA: 0x13959B4 Offset: 0x13959B4 VA: 0x13959B4
		// private void set_sePlayerRaidLoop(CriAtomSource value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AF78 Offset: 0x73AF78 VA: 0x73AF78
		// // RVA: 0x13959BC Offset: 0x13959BC VA: 0x13959BC
		// public CriAtomSource get_sePlayerMiniGame() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AF88 Offset: 0x73AF88 VA: 0x73AF88
		// // RVA: 0x13959C4 Offset: 0x13959C4 VA: 0x13959C4
		// private void set_sePlayerMiniGame(CriAtomSource value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AF98 Offset: 0x73AF98 VA: 0x73AF98
		// // RVA: 0x13959CC Offset: 0x13959CC VA: 0x13959CC
		// public bool get_isInitialized() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AFA8 Offset: 0x73AFA8 VA: 0x73AFA8
		// // RVA: 0x13959D4 Offset: 0x13959D4 VA: 0x13959D4
		// private void set_isInitialized(bool value) { }

		// // RVA: 0x13959DC Offset: 0x13959DC VA: 0x13959DC
		// public bool get_isEestimatorInitialized() { }

		// // RVA: 0x13959F0 Offset: 0x13959F0 VA: 0x13959F0
		// private void set_isEestimatorInitialized(bool value) { }

		// // RVA: 0x13959F4 Offset: 0x13959F4 VA: 0x13959F4
		// public int get_estimatedLatencyMillisec() { }

		// // RVA: 0x1395A0C Offset: 0x1395A0C VA: 0x1395A0C
		// private void set_estimatedLatencyMillisec(int value) { }

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
