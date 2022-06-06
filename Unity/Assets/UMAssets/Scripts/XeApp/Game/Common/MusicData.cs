using UnityEngine;

namespace XeApp.Game.Common
{
	public class MusicData : MonoBehaviour
	{
		public enum NoteModeType
		{
			None = 0,
			Normal = 1,
			Valkyrie = 2,
			Diva = 3,
			Num = 4,
		}

		// // Fields
		private static readonly int INTRO_FADE_DEFAULT_MILLISEC; // 0x0
		private static readonly int VALKYRIE_MODE_JUDGE_OFFSET; // 0x4
		private static readonly int VALKYRIE_MODE_HUD_OFFSET; // 0x8
		private static readonly int VALKYRIE_MODE_FADE_OFFSET; // 0xC
		private static readonly int DIVA_MODE_JUDGE_OFFSET; // 0x10
		private static readonly int TUTORIAL_MODE_DESCRIPTION_OFFSET; // 0x14
		// [CompilerGeneratedAttribute] // RVA: 0x6879A0 Offset: 0x6879A0 VA: 0x6879A0
		// private EONOEHOKBEB <musicBase>k__BackingField; // 0xC
		// [CompilerGeneratedAttribute] // RVA: 0x6879B0 Offset: 0x6879B0 VA: 0x6879B0
		// private MusicScoreData <commonData>k__BackingField; // 0x10
		// [CompilerGeneratedAttribute] // RVA: 0x6879C0 Offset: 0x6879C0 VA: 0x6879C0
		// private MusicScoreData <musicScoreData>k__BackingField; // 0x14
		// [CompilerGeneratedAttribute] // RVA: 0x6879D0 Offset: 0x6879D0 VA: 0x6879D0
		// private MusicScoreData <cheerScoreData>k__BackingField; // 0x18
		// [CompilerGeneratedAttribute] // RVA: 0x6879E0 Offset: 0x6879E0 VA: 0x6879E0
		// private MusicDirectionParamBase <musicParam>k__BackingField; // 0x1C
		public int noteDisplayMillisec; // 0x20
		public int introFadeMillisec; // 0x24
		public int valkyrieModeJudgeMillisec; // 0x28
		public int valkyrieModeStartHUDMillisec; // 0x2C
		public int valkyrieModeStartFadeMillisec; // 0x30
		public int valkyrieModeStartMillisec; // 0x34
		public int valkyrieModeLeaveMillisec; // 0x38
		public int divaModeJudgeMillisec; // 0x3C
		public int divaModeStartMillisec; // 0x40
		public int rhythmGameResultStartMillisec; // 0x44
		public int tutorialOneEndGameStartMillisec; // 0x48
		public int tutorialTwoForceFwaveMaxStartMillisec; // 0x4C
		public int tutorialTwoForceDefeatEnemyStartMillisec; // 0x50
		public int tutorialTwoModeDescriptionlStartMillisec; // 0x54
		private bool isLoadedCommonData; // 0x58
		private bool isLoadedScoreData; // 0x59
		private bool isLoadedCheerData; // 0x5A
		private bool isLoadedParam; // 0x5B
		// private CBBJHPBGBAJ tarFile; // 0x5C

		// // Properties
		public EONOEHOKBEB_Music musicBase { get; set; }
		public MusicScoreData commonData { get; set; }
		public MusicScoreData musicScoreData { get; set; }
		public MusicScoreData cheerScoreData { get; set; }
		public MusicDirectionParamBase musicParam { get; set; }
		public bool isAllLoaded { get; set; }
		public bool isARLoaded { get; }

		// // Methods

		// [CompilerGeneratedAttribute] // RVA: 0x73A384 Offset: 0x73A384 VA: 0x73A384
		// // RVA: 0xAE6214 Offset: 0xAE6214 VA: 0xAE6214
		// public EONOEHOKBEB get_musicBase() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73A394 Offset: 0x73A394 VA: 0x73A394
		// // RVA: 0xAE621C Offset: 0xAE621C VA: 0xAE621C
		// private void set_musicBase(EONOEHOKBEB value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73A3A4 Offset: 0x73A3A4 VA: 0x73A3A4
		// // RVA: 0xAE6224 Offset: 0xAE6224 VA: 0xAE6224
		// public MusicScoreData get_commonData() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73A3B4 Offset: 0x73A3B4 VA: 0x73A3B4
		// // RVA: 0xAE622C Offset: 0xAE622C VA: 0xAE622C
		// private void set_commonData(MusicScoreData value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73A3C4 Offset: 0x73A3C4 VA: 0x73A3C4
		// // RVA: 0xAE6234 Offset: 0xAE6234 VA: 0xAE6234
		// public MusicScoreData get_musicScoreData() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73A3D4 Offset: 0x73A3D4 VA: 0x73A3D4
		// // RVA: 0xAE623C Offset: 0xAE623C VA: 0xAE623C
		// private void set_musicScoreData(MusicScoreData value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73A3E4 Offset: 0x73A3E4 VA: 0x73A3E4
		// // RVA: 0xAE6244 Offset: 0xAE6244 VA: 0xAE6244
		// public MusicScoreData get_cheerScoreData() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73A3F4 Offset: 0x73A3F4 VA: 0x73A3F4
		// // RVA: 0xAE624C Offset: 0xAE624C VA: 0xAE624C
		// private void set_cheerScoreData(MusicScoreData value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73A404 Offset: 0x73A404 VA: 0x73A404
		// // RVA: 0xAE6254 Offset: 0xAE6254 VA: 0xAE6254
		// public MusicDirectionParamBase get_musicParam() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73A414 Offset: 0x73A414 VA: 0x73A414
		// // RVA: 0xAE625C Offset: 0xAE625C VA: 0xAE625C
		// private void set_musicParam(MusicDirectionParamBase value) { }

		// // RVA: 0xAE6264 Offset: 0xAE6264 VA: 0xAE6264
		// public bool get_isAllLoaded() { }

		// // RVA: 0xAE629C Offset: 0xAE629C VA: 0xAE629C
		// private void set_isAllLoaded(bool value) { }

		// // RVA: 0xAE62A0 Offset: 0xAE62A0 VA: 0xAE62A0
		// public bool get_isARLoaded() { }

		// // RVA: 0xAE62A8 Offset: 0xAE62A8 VA: 0xAE62A8
		public void LoadData(int musicId, int difficultyId, int stageDivaNum, bool line6Mode)
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73A424 Offset: 0x73A424 VA: 0x73A424
		// // RVA: 0xAE62E0 Offset: 0xAE62E0 VA: 0xAE62E0
		// private IEnumerator Co_LoadData(int musicId, int difficultyId, int stageDivaNum, bool line6Mode) { }

		// // RVA: 0xAE63F4 Offset: 0xAE63F4 VA: 0xAE63F4
		// public void LoadARData(int wavId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73A49C Offset: 0x73A49C VA: 0x73A49C
		// // RVA: 0xAE6418 Offset: 0xAE6418 VA: 0xAE6418
		// private IEnumerator Co_LoadARData(int wavId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73A514 Offset: 0x73A514 VA: 0x73A514
		// // RVA: 0xAE64E0 Offset: 0xAE64E0 VA: 0xAE64E0
		// private IEnumerator LoadScoreTarFile(int musicId) { }

		// // RVA: 0xAE658C Offset: 0xAE658C VA: 0xAE658C
		// private void LoadedCommonScoreData(MusicScoreData data) { }

		// // RVA: 0xAE6A78 Offset: 0xAE6A78 VA: 0xAE6A78
		// private void LoadedMusicScoreData(MusicScoreData data) { }

		// // RVA: 0xAE6A88 Offset: 0xAE6A88 VA: 0xAE6A88
		// private void LoadedCheerScoreData(MusicScoreData data) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73A58C Offset: 0x73A58C VA: 0x73A58C
		// // RVA: 0xAE6A98 Offset: 0xAE6A98 VA: 0xAE6A98
		// private IEnumerator LoadScoreData(AssetBundleLoadAllAssetOperationBase operation, int wavId, int variationId, int difficultyType, bool is6Line, Action<MusicScoreData> dataSetFunc, string strPrefix = "s_") { }

		// [IteratorStateMachineAttribute] // RVA: 0x73A604 Offset: 0x73A604 VA: 0x73A604
		// // RVA: 0xAE6BFC Offset: 0xAE6BFC VA: 0xAE6BFC
		// private IEnumerator LoadDirectionParam(AssetBundleLoadAllAssetOperationBase operation, int wavId) { }

		// // RVA: 0xAE65AC Offset: 0xAE65AC VA: 0xAE65AC
		// private void ExtractionEventFireMillisec() { }

		// // RVA: 0xAE6CDC Offset: 0xAE6CDC VA: 0xAE6CDC
		// public MusicData.NoteModeType GetNotesModeType(MusicScoreData.InputNoteInfo noteInfo) { }

		// // RVA: 0xAE6DD8 Offset: 0xAE6DD8 VA: 0xAE6DD8
		// public void .ctor() { }

		// // RVA: 0xAE6E88 Offset: 0xAE6E88 VA: 0xAE6E88
		// private static void .cctor() { }
	}
}
