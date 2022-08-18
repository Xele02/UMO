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
		private CBBJHPBGBAJ_Archive tarFile; // 0x5C

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
    		UnityEngine.Debug.Log("Enter Co_LoadData");
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

			musicBase = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(musicId);
			noteDisplayMillisec = GameManager.Instance.localSave.EPJOACOONAC().CNLJNGLMMHB_Options.HBCHGGNOOCD_GetNotesDisplayTiming((XeApp.Game.Common.Difficulty.Type)difficultyId, false);
			yield return StartCoroutine(LoadScoreTarFile(musicId));

			StringBuilder bundleName = new StringBuilder();

			string wavDir = GameManager.Instance.GetWavDirectoryName(musicBase.KKPAHLMJKIH_WavId, "mc/{0}/sc.xab", stageDivaNum, 1, -1, true);
			bundleName.SetFormat("mc/{0}/sc.xab", wavDir);

			AssetBundleLoadAllAssetOperationBase operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;

			yield return StartCoroutine(LoadScoreData(operation, musicBase.KKPAHLMJKIH_WavId, musicBase.BKJGCEOEPFB_VariationId, -1, line6Mode, this.LoadedCommonScoreData, "s_"));

			yield return StartCoroutine(LoadScoreData(operation, musicBase.KKPAHLMJKIH_WavId, musicBase.BKJGCEOEPFB_VariationId, -1, line6Mode, this.LoadedCheerScoreData, "mv_"));

			yield return StartCoroutine(LoadScoreData(operation, musicBase.KKPAHLMJKIH_WavId, musicBase.BKJGCEOEPFB_VariationId, difficultyId, line6Mode, this.LoadedMusicScoreData, "s_"));

			yield return StartCoroutine(LoadScoreData(operation, musicBase.KKPAHLMJKIH_WavId, musicBase.BKJGCEOEPFB_VariationId, difficultyId, false, this.LoadedMusicScoreData, "s_"));

			yield return StartCoroutine(LoadDirectionParam(operation, musicBase.KKPAHLMJKIH_WavId));

			AssetBundleManager.UnloadAssetBundle(bundleName.ToString());
			RhythmGameConsts.SetWide(musicScoreData.isWideTrack);
    		UnityEngine.Debug.Log("Exit Co_LoadData");
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
    		UnityEngine.Debug.Log("Enter LoadScoreTarFile");
			//0xAE8584
			StringBuilder str = new StringBuilder(64);
			str.AppendFormat("sc/{0:D4}.dat", musicBase.KKPAHLMJKIH_WavId);
			StringBuilder str2 = new StringBuilder(64);
			str2.Clear();
			if(!AssetBundleManager.isTutorialNow)
			{
				str2.Append(KEHOJEJMGLJ.CGAHFOBGHIM_PersistentPlatformDataPath);
				str2.Append("/");
			}
			else
			{
				str2.Append(Application.streamingAssetsPath);
				str2.Append("/android/");
			}
			str2.Append(str);
			bool done = false;
			int hash = FileLoader.Instance.Request(str2.ToString(), str.ToString(), (FileResultObject fro) => {
				//0xAE6F38
				done = true;
				tarFile = new CBBJHPBGBAJ_Archive();
				tarFile.KHEKNNFCAOI_Load(fro.bytes);
				return true;
			}, null, 0, true);
			FileLoader.Instance.Load();

			while(!done)
				yield return null;
			FileLoader.Instance.Unload(hash);
    		UnityEngine.Debug.Log("Exit LoadScoreTarFile");
			yield break;
		}

		// // RVA: 0xAE658C Offset: 0xAE658C VA: 0xAE658C
		private void LoadedCommonScoreData(MusicScoreData data)
		{
			commonData = data;
			ExtractionEventFireMillisec();
			isLoadedCommonData = true;
		}

		// // RVA: 0xAE6A78 Offset: 0xAE6A78 VA: 0xAE6A78
		private void LoadedMusicScoreData(MusicScoreData data)
		{
			isLoadedScoreData = true;
			musicScoreData = data;
		}

		// // RVA: 0xAE6A88 Offset: 0xAE6A88 VA: 0xAE6A88
		private void LoadedCheerScoreData(MusicScoreData data)
		{
			isLoadedCheerData = true;
			cheerScoreData = data;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73A58C Offset: 0x73A58C VA: 0x73A58C
		// // RVA: 0xAE6A98 Offset: 0xAE6A98 VA: 0xAE6A98
		private IEnumerator LoadScoreData(AssetBundleLoadAllAssetOperationBase operation, int wavId, int variationId, int difficultyType, bool is6Line, Action<MusicScoreData> dataSetFunc, string strPrefix = "s_")
		{
    		UnityEngine.Debug.Log("Enter LoadScoreData");
			//0xAE8084

			MusicScoreData res = null;

			int score_id = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.CHBLIEKBOLL_GetScoreId(wavId, variationId, difficultyType, is6Line);
			StringBuilder str = new StringBuilder();
			str.SetFormat("{0}{1:D8}", strPrefix, score_id);
			if(tarFile != null)
			{
				CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File file = tarFile.KGHAJGGMPKL_Files.Find((CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File x) =>
				{
					//0xAE702C
					return x.OPFGFINHFCE_Name.Contains(str.ToString());
				});
				if (file != null)
				{
					res = MusicScoreData.Instantiate(file.DBBGALAPFGC_Data);
				}
				else
				{
					string listFiles = "";
					foreach(var f in tarFile.KGHAJGGMPKL_Files)
					{
						listFiles += f.OPFGFINHFCE_Name +" ";
					}
					UnityEngine.Debug.LogError("File "+str.ToString()+" not found in tarFile. Files are : "+listFiles);
				}
			}
			if (res == null)
			{
				TextAsset textAsset = operation.GetAsset<TextAsset>(str.ToString());
				if (textAsset != null)
				{
					res = MusicScoreData.Instantiate(textAsset.bytes);
				}
			}
			dataSetFunc(res);

			UnityEngine.Debug.Log("Exit LoadScoreData");
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73A604 Offset: 0x73A604 VA: 0x73A604
		// // RVA: 0xAE6BFC Offset: 0xAE6BFC VA: 0xAE6BFC
		private IEnumerator LoadDirectionParam(AssetBundleLoadAllAssetOperationBase operation, int wavId)
		{
			//0xAE7DB0
			StringBuilder str = new StringBuilder();
			str.SetFormat("p_{0:D4}", wavId);
			musicParam = operation.GetAsset<MusicDirectionParamBase>(str.ToString());
			str.SetFormat("bp_{0:D4}", wavId);
			musicParam.BoolParam = operation.GetAsset<MusicDirectionBoolParam>(str.ToString());
			isLoadedParam = true;
			yield break;
		}

		// // RVA: 0xAE65AC Offset: 0xAE65AC VA: 0xAE65AC
		private void ExtractionEventFireMillisec()
		{
			introFadeMillisec = MusicData.INTRO_FADE_DEFAULT_MILLISEC;
			valkyrieModeJudgeMillisec = -1;
			valkyrieModeStartFadeMillisec = -1;
			valkyrieModeStartMillisec = -1;
			valkyrieModeLeaveMillisec = -1;
			divaModeJudgeMillisec = -1;
			rhythmGameResultStartMillisec = -1;
			tutorialOneEndGameStartMillisec = -1;
			tutorialTwoForceFwaveMaxStartMillisec = -1;
			tutorialTwoForceDefeatEnemyStartMillisec = -1;
			tutorialTwoModeDescriptionlStartMillisec = -1;
			if(commonData != null)
			{
				for(int i = 0; i < commonData.eventTrack10.Count; i++)
				{
					if(commonData.eventTrack10[i].value == MusicScoreData.INTRO_FADE)
						introFadeMillisec = commonData.eventTrack10[i].time;
					else if(commonData.eventTrack10[i].value == MusicScoreData.START_VALKYRIE_MODE)
					{
						valkyrieModeJudgeMillisec = commonData.eventTrack10[i].time + MusicData.VALKYRIE_MODE_JUDGE_OFFSET;
						valkyrieModeStartHUDMillisec = commonData.eventTrack10[i].time + MusicData.VALKYRIE_MODE_HUD_OFFSET;
						valkyrieModeStartFadeMillisec = commonData.eventTrack10[i].time + MusicData.VALKYRIE_MODE_FADE_OFFSET;
						valkyrieModeStartMillisec = commonData.eventTrack10[i].time;
						tutorialTwoModeDescriptionlStartMillisec = commonData.eventTrack10[i].time + MusicData.TUTORIAL_MODE_DESCRIPTION_OFFSET;
					}
					else if(commonData.eventTrack10[i].value == MusicScoreData.LEAVE_VALKYRIE_MODE)
					{
						valkyrieModeLeaveMillisec = commonData.eventTrack10[i].time;
						divaModeJudgeMillisec = commonData.eventTrack10[i].time + MusicData.DIVA_MODE_JUDGE_OFFSET;
					}
					else if(commonData.eventTrack10[i].value == MusicScoreData.START_DIVA_MODE)
					{
						divaModeStartMillisec = commonData.eventTrack10[i].time;
					}
					else if(commonData.eventTrack10[i].value == MusicScoreData.START_COMBO_RESULT)
					{
					}
					else if(commonData.eventTrack10[i].value == MusicScoreData.TUTORIAL_ONE_END_GAME)
					{
						tutorialOneEndGameStartMillisec = commonData.eventTrack10[i].time;
					}
					else if(commonData.eventTrack10[i].value == MusicScoreData.TUTORIAL_TWO_FORCE_FWAVE_MAX)
					{
						tutorialTwoForceFwaveMaxStartMillisec = commonData.eventTrack10[i].time;
					}
					else if(commonData.eventTrack10[i].value == MusicScoreData.TUTORIAL_TWO_FORCE_DEFEAT_ENEMY)
					{
						tutorialTwoForceDefeatEnemyStartMillisec = commonData.eventTrack10[i].time;
					}
				}
			}
		}

		// // RVA: 0xAE6CDC Offset: 0xAE6CDC VA: 0xAE6CDC
		// public MusicData.NoteModeType GetNotesModeType(MusicScoreData.InputNoteInfo noteInfo) { }
	}
}
