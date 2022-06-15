using UnityEngine;
using System.Collections;
using System.Text;
using XeSys;
using XeApp.Core;
using System;

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

		private static readonly int INTRO_FADE_DEFAULT_MILLISEC = 4000; // 0x0
		private static readonly int VALKYRIE_MODE_JUDGE_OFFSET = -1200; // 0x4
		private static readonly int VALKYRIE_MODE_HUD_OFFSET = -600; // 0x8
		private static readonly int VALKYRIE_MODE_FADE_OFFSET = -100; // 0xC
		private static readonly int DIVA_MODE_JUDGE_OFFSET = -600; // 0x10
		private static readonly int TUTORIAL_MODE_DESCRIPTION_OFFSET = -700; // 0x14
		public int noteDisplayMillisec; // 0x20
		public int introFadeMillisec = INTRO_FADE_DEFAULT_MILLISEC; // 0x24
		public int valkyrieModeJudgeMillisec = 255; // 0x28
		public int valkyrieModeStartHUDMillisec = 255; // 0x2C
		public int valkyrieModeStartFadeMillisec = 255; // 0x30
		public int valkyrieModeStartMillisec = 255; // 0x34
		public int valkyrieModeLeaveMillisec = 255; // 0x38
		public int divaModeJudgeMillisec = 255; // 0x3C
		public int divaModeStartMillisec = 255; // 0x40
		public int rhythmGameResultStartMillisec = 255; // 0x44
		public int tutorialOneEndGameStartMillisec = 255; // 0x48
		public int tutorialTwoForceFwaveMaxStartMillisec = 255; // 0x4C
		public int tutorialTwoForceDefeatEnemyStartMillisec = 255; // 0x50
		public int tutorialTwoModeDescriptionlStartMillisec = 255; // 0x54
		private bool isLoadedCommonData; // 0x58
		private bool isLoadedScoreData; // 0x59
		private bool isLoadedCheerData; // 0x5A
		private bool isLoadedParam; // 0x5B
		// private CBBJHPBGBAJ tarFile; // 0x5C

		public EONOEHOKBEB_Music musicBase { get; set; } // 0xC
		public MusicScoreData commonData { get; set; } // 0x10
		public MusicScoreData musicScoreData { get; set; } // 0x14
		public MusicScoreData cheerScoreData { get; set; } // 0x18
		public MusicDirectionParamBase musicParam { get; set; } // 0x1C
		public bool isAllLoaded { get { return isLoadedCommonData && isLoadedScoreData && isLoadedCheerData && isLoadedParam; } set {} } // get_isAllLoaded 0xAE6264 set_isAllLoaded 0xAE629C
		public bool isARLoaded { get  { return isLoadedParam; } } // get_isARLoaded 0xAE62A0

		// // RVA: 0xAE62A8 Offset: 0xAE62A8 VA: 0xAE62A8
		public void LoadData(int musicId, int difficultyId, int stageDivaNum, bool line6Mode)
		{
			StartCoroutine(Co_LoadData(musicId, difficultyId, stageDivaNum, line6Mode));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73A424 Offset: 0x73A424 VA: 0x73A424
		// // RVA: 0xAE62E0 Offset: 0xAE62E0 VA: 0xAE62E0
		private IEnumerator Co_LoadData(int musicId, int difficultyId, int stageDivaNum, bool line6Mode)
		{
			// // Fields
			// private int <>1__state; // 0x8
			// private object <>2__current; // 0xC
			// public MusicData <>4__this; // 0x10
			// public int musicId; // 0x14
			// public int difficultyId; // 0x18
			// public bool line6Mode; // 0x1C
			// public int stageDivaNum; // 0x20
			// private StringBuilder <bundleName>5__2; // 0x24
			// private AssetBundleLoadAllAssetOperationBase <allOperation>5__3; // 0x28
			// 0xAE73BC

			isLoadedCheerData = false;
			isLoadedCommonData = false;
			isLoadedParam = false;

			musicBase = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND.IBPAFKKEKNK.IAJLOELFHKC(musicId);
			noteDisplayMillisec = GameManager.Instance.localSave.EPJOACOONAC().CNLJNGLMMHB.HBCHGGNOOCD((XeApp.Game.Common.Difficulty.Type)difficultyId, false);
			yield return StartCoroutine(LoadScoreTarFile(musicId));

			StringBuilder bundleName = new StringBuilder();

			string wavDir = GameManager.Instance.GetWavDirectoryName(musicBase.KKPAHLMJKIH, "mc/{0}/sc.xab", stageDivaNum, 1, -1, true);
			bundleName.SetFormat("mc/{0}/sc.xab", wavDir);

			AssetBundleLoadAllAssetOperationBase operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;

			yield return StartCoroutine(LoadScoreData(operation, musicBase.KKPAHLMJKIH, musicBase.BKJGCEOEPFB, -1, line6Mode, this.LoadedCommonScoreData, "s_"));

			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xAE63F4 Offset: 0xAE63F4 VA: 0xAE63F4
		// public void LoadARData(int wavId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73A49C Offset: 0x73A49C VA: 0x73A49C
		// // RVA: 0xAE6418 Offset: 0xAE6418 VA: 0xAE6418
		// private IEnumerator Co_LoadARData(int wavId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73A514 Offset: 0x73A514 VA: 0x73A514
		// // RVA: 0xAE64E0 Offset: 0xAE64E0 VA: 0xAE64E0
		private IEnumerator LoadScoreTarFile(int musicId)
		{
			UnityEngine.Debug.LogError("TODO");
			yield break;
		}

		// // RVA: 0xAE658C Offset: 0xAE658C VA: 0xAE658C
		private void LoadedCommonScoreData(MusicScoreData data)
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xAE6A78 Offset: 0xAE6A78 VA: 0xAE6A78
		// private void LoadedMusicScoreData(MusicScoreData data) { }

		// // RVA: 0xAE6A88 Offset: 0xAE6A88 VA: 0xAE6A88
		// private void LoadedCheerScoreData(MusicScoreData data) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73A58C Offset: 0x73A58C VA: 0x73A58C
		// // RVA: 0xAE6A98 Offset: 0xAE6A98 VA: 0xAE6A98
		private IEnumerator LoadScoreData(AssetBundleLoadAllAssetOperationBase operation, int wavId, int variationId, int difficultyType, bool is6Line, Action<MusicScoreData> dataSetFunc, string strPrefix = "s_")
		{
			UnityEngine.Debug.LogError("TODO");
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73A604 Offset: 0x73A604 VA: 0x73A604
		// // RVA: 0xAE6BFC Offset: 0xAE6BFC VA: 0xAE6BFC
		// private IEnumerator LoadDirectionParam(AssetBundleLoadAllAssetOperationBase operation, int wavId) { }

		// // RVA: 0xAE65AC Offset: 0xAE65AC VA: 0xAE65AC
		// private void ExtractionEventFireMillisec() { }

		// // RVA: 0xAE6CDC Offset: 0xAE6CDC VA: 0xAE6CDC
		// public MusicData.NoteModeType GetNotesModeType(MusicScoreData.InputNoteInfo noteInfo) { }
	}
}
