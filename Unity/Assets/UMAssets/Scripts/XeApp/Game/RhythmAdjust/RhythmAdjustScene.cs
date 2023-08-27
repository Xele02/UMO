using XeApp.Core;
using System.Collections.Generic;
using XeApp.Game.RhythmGame;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Adv;
using System;
using XeApp.Game.RhythmGame.UI;
using XeApp.Game.Menu;
using XeApp.Game.Common;
using XeSys;
using System.Collections;
using System.Text;
using mcrs;
using XeApp.Game.Tutorial;
using CriWare;

namespace XeApp.Game.RhythmAdjust
{
	public class RhythmAdjustScene : MainSceneBase
	{
		private enum NoteSEType
		{
			Exempt = 0,
			LongLoop = 1,
			Bad = 2,
			Good = 3,
			Great = 4,
			Perfect = 5,
			FlickGreat = 6,
			FlickPerfect = 7,
			Num = 8,
		}

		private readonly int notes_button_Anim_Hash = Animator.StringToHash("notes_button"); // 0x28
		private readonly int UI_rhythm_Push_IN_HashCode = "UI_rhythm_Push_IN".GetHashCode(); // 0x2C
		private readonly int UI_rhythm_Push_OUT_HashCode = "UI_rhythm_Push_OUT".GetHashCode(); // 0x30
		private readonly int UI_rhythm_Long_OUT_HashCode = "UI_rhythm_Long_OUT".GetHashCode(); // 0x34
		private readonly int[] ResultAnimationStateTable = new int[6]
		{
			"Miss".GetHashCode(),
			"Bad".GetHashCode(),
			"Good".GetHashCode(),
			"Great".GetHashCode(),
			"Perfect".GetHashCode(),
			"Excellent".GetHashCode()
		}; // 0x38
		private readonly int[] noteTouchSEIndex = new int[8]
		{
			8, 5, 12, 11, 10, 9, 7, 6
		}; // 0x3C
		private readonly int minSliderValue = -75; // 0x40
		private readonly int maxSliderValue = 75; // 0x44
		private List<RNoteObject> activeObjectList = new List<RNoteObject>(10); // 0x50
		private List<RNoteSingle> activeSingleList = new List<RNoteSingle>(10); // 0x54
		[SerializeField]
		private List<RNote> rNoteList; // 0x58
		[SerializeField]
		private GameObject notesOwner; // 0x5C
		[SerializeField]
		private RNoteObject rNoteObject; // 0x60
		[SerializeField]
		private RNoteSingle[] rNoteSingle; // 0x64
		[SerializeField]
		private RectTransform touchRect; // 0x68
		private Slider adjustSlider; // 0x6C
		private AdvCharacter m_character; // 0x70
		private AdvCharacterData m_characterData; // 0x74
		[SerializeField]
		private Transform judgePointTransform; // 0x78
		[SerializeField]
		private TextAsset scoreDataResource; // 0x80
		private MusicScoreData scoreData; // 0x84
		private bool isTestMode; // 0x88
		private bool isTutorialConfirm; // 0x89
		private bool isDecide; // 0x8A
		private int noteOffsetMillisec; // 0x8C
		private int notePrefOffsetMilllisec; // 0x90
		private int touchedNotesIndex = -1; // 0x94
		private Action updater; // 0x98
		private Action<bool> onConfirm; // 0x9C
		private GameObject touchEffectObject; // 0xA0
		private GameObject notesMarkerObject; // 0xA4
		private TouchPrefabInstance touchEffect; // 0xA8
		private bool isSliderSeDisable; // 0xAC
		[SerializeField]
		private GameObject layoutRoot; // 0xB0
		private LayoutRhythmAdjust layoutData; // 0xB4
		[SerializeField]
		private GameObject bgRoot; // 0xB8
		private BgControl bgControl; // 0xBC
		private bool m_decideConfirmButton; // 0xC0
		private LayoutRhythmAdjustTutorialConfirmWindow.ButtonType m_confirmButtonType; // 0xC4

		private BgmPlayer bgmPlayer { get { return SoundManager.Instance.bgmPlayer; } set { return; } } //0xF5EB9C 0xF5EBD0
		public RNoteObjectPool objectPool { get; private set; } // 0x48
		public RNoteSinglePool singlePool { get; private set; } // 0x4C
		public LinkedList<RNoteObject> spawnRNoteObjects { get; private set; } // 0x7C

		// RVA: 0xF5EC04 Offset: 0xF5EC04 VA: 0xF5EC04 Slot: 9
		protected override void DoAwake()
		{
			GameManager.Instance.SetFPS(60);
			enableFade = false;
			GameManager.Instance.SetTouchEffectVisible(false);
			if(SystemManager.isLongScreenDevice)
			{
				FlexibleLayoutCamera fl = GetComponent<FlexibleLayoutCamera>();
				fl.IsEnableViewPort = false;
				fl.SetDisable();
				for(int i = 0; i < fl.FlexibleFovCameraList.Count; i++)
				{
					fl.FlexibleFovCameraList[i].rect = new Rect(0, 0, 1, 1);
				}
			}
			this.StartCoroutineWatched(Co_LoadUIAsset());
		}

		// RVA: 0xF5EF58 Offset: 0xF5EF58 VA: 0xF5EF58 Slot: 10
		protected override void DoStart()
		{
			return;
		}

		// RVA: 0xF5EF5C Offset: 0xF5EF5C VA: 0xF5EF5C Slot: 12
		protected override bool DoUpdateEnter()
		{
			return updater != null;
		}

		// RVA: 0xF5EF6C Offset: 0xF5EF6C VA: 0xF5EF6C Slot: 13
		protected override void DoUpdateMain()
		{
			if(updater != null)
				updater();
		}

		// RVA: 0xF5EF80 Offset: 0xF5EF80 VA: 0xF5EF80 Slot: 14
		protected override bool DoUpdateLeave()
		{
			bgmPlayer.Stop();
			return true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B0400 Offset: 0x6B0400 VA: 0x6B0400
		// // RVA: 0xF5EFB4 Offset: 0xF5EFB4 VA: 0xF5EFB4
		// private IEnumerator Co_InitializeMaster() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6B0478 Offset: 0x6B0478 VA: 0x6B0478
		// // RVA: 0xF5EECC Offset: 0xF5EECC VA: 0xF5EECC
		private IEnumerator Co_LoadUIAsset()
		{
			StringBuilder unionBundleName;
			StringBuilder bundleName;
			StringBuilder assetName;
			WaitUntil soundWait;
			int loadCount;
			AssetBundleLoadAssetOperation operationTouchEffect;
			AssetBundleLoadAssetOperation operationNotesButton;

			//0xF64F58
			MessageLoader.Create();
			MessageLoader.Instance.Request(MessageLoader.eSheet.common, 0);
			yield return MessageLoader.Instance.WaitForDone(this);
			MessageLoader.Instance.Request(MessageLoader.eSheet.menu, 0);
			yield return MessageLoader.Instance.WaitForDone(this);
			unionBundleName = new StringBuilder();
			loadCount = 0;
			bundleName = new StringBuilder();
			assetName = new StringBuilder();
			unionBundleName.SetFormat("gm/if/un.xab", Array.Empty<object>());
			yield return AssetBundleManager.LoadUnionAssetBundle(unionBundleName.ToString());
			bundleName.SetFormat("gm/if/hi.xab", Array.Empty<object>());
			assetName.SetFormat("TouchEffect", Array.Empty<object>());
			operationTouchEffect = AssetBundleManager.LoadAssetAsync(bundleName.ToString(), assetName.ToString(), typeof(GameObject));
			yield return operationTouchEffect;
			touchEffectObject = Instantiate(operationTouchEffect.GetAsset<GameObject>());
			touchEffect = touchEffectObject.GetComponent<TouchPrefabInstance>();
			loadCount++;
			assetName.SetFormat("notes_button_high", Array.Empty<object>());
			operationNotesButton = AssetBundleManager.LoadAssetAsync(bundleName.ToString(), assetName.ToString(), typeof(GameObject));
			yield return operationNotesButton;
			notesMarkerObject = Instantiate(operationNotesButton.GetAsset<GameObject>());
			loadCount++;
			for(int i = 0; i < loadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
			operationTouchEffect = null;
			operationNotesButton = null;
			AssetBundleManager.UnloadAssetBundle(unionBundleName.ToString(), false);
			SetNotesRenderSort(touchEffect.GetComponentsInChildren<UIPriority>(true));
			SetNotesRenderSort(notesMarkerObject.GetComponentsInChildren<UIPriority>(true));
			notesMarkerObject.transform.localPosition = new Vector3(notesMarkerObject.transform.localPosition.x, notesMarkerObject.transform.localPosition.y, 45);
			notesMarkerObject.SetActive(false);
			yield return Co.R(LayoutRhythmAdjust.Co_LoadLayout(layoutRoot.transform, GameManager.Instance.IsTutorial, (LayoutRhythmAdjust layout) =>
			{
				//0xF6496C
				layoutData = layout;
				layoutData.Setup(minSliderValue, maxSliderValue, PlusAdjustValue, MinusAdjustValue, SwitchMode, Decide);
				adjustSlider = layoutData.GetComponentInChildren<Slider>(true);
				adjustSlider.minValue = minSliderValue;
				adjustSlider.maxValue = maxSliderValue;
			}));
			bgControl = new BgControl(bgRoot);
			yield return this.StartCoroutineWatched(bgControl.Load(null));
			yield return Co.R(bgControl.ChangeBgCoroutine(BgType.Result, -1, SceneGroupCategory.UNDEFINED, TransitionList.Type.UNDEFINED, -1));
			SoundManager.Instance.Initialize();
			bool isSoundLoaded = false;
			soundWait = new WaitUntil(() =>
			{
				//0xF64C44
				return isSoundLoaded;
			});
			SoundManager.Instance.RequestEntryRhythmGameCueSheet(() =>
			{
				//0xF64C4C
				isSoundLoaded = true;
			}, 0);
			SoundManager.Instance.bgmPlayer.Stop();
			loadCount = 1;
			bundleName.SetFormat("ad/ch/{0:D4}_001.xab", 1);
			assetName.Set("CharaData");
			FileResultObject fo = null;
			ResourcesManager.Instance.Load("Adv/Prefab/AdvCharacter", (FileResultObject x) =>
			{
				//0xF64C60
				fo = x;
				return true;
			});
			while(fo == null)
				yield return null;
			m_character = (Instantiate(fo.unityObject) as GameObject).GetComponent<AdvCharacter>();
			operationNotesButton = AssetBundleManager.LoadAssetAsync(bundleName.ToString(), assetName.ToString(), typeof(AdvCharacterData));
			yield return operationNotesButton;
			m_characterData = operationNotesButton.GetAsset<AdvCharacterData>();
			m_character.SetCharacterData(loadCount, m_characterData, 0, false, 0);
			m_character.transform.SetParent(layoutRoot.transform, false);
			m_character.SetFace(1);
			this.StartCoroutineWatched(m_character.ShowCoroutine(false));
			m_character.SetPosition(new Vector2(-270, 0));
			m_character.transform.SetSiblingIndex(m_character.transform.GetSiblingIndex() - 1);
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			operationNotesButton = null;
			yield return soundWait;
			layoutData.Enter(GameManager.Instance.IsTutorial);
			Initialize();
		}

		// // RVA: 0xF5F080 Offset: 0xF5F080 VA: 0xF5F080
		private void SetNotesRenderSort(UIPriority[] priority)
		{
			for(int i = 0; i < priority.Length; i++)
			{
				for(int j = 0; j < priority[i].m_meshPrioritySets.Length; j++)
				{
					priority[i].m_meshPrioritySets[j].priority = UIPriority.Priority.Default;
					priority[i].m_meshPrioritySets[j].offset = -100;
				}
				for(int j = 0; j < priority[i].m_particlePrioritySets.Length; j++)
				{
					priority[i].m_particlePrioritySets[j].priority = UIPriority.Priority.Default;
					priority[i].m_particlePrioritySets[j].offset = -100;
				}
			}
		}

		// // RVA: 0xF5F340 Offset: 0xF5F340 VA: 0xF5F340
		private void Initialize()
		{
			enableFade = true;
			scoreData = MusicScoreData.Instantiate(scoreDataResource.bytes);
			RNotePositionAnimator.InitializeAnim();
			LDDDBPNGGIN_Game gameDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game;
			RNoteResultJudge j1 = new RNoteResultJudge(gameDb.BFDLLHNGICE_TapSt, gameDb.ICNFEDCCODF_TapEd);
			RNoteResultJudge j2 = new RNoteResultJudge(gameDb.EKONPEGLAND_PrsSt, gameDb.ILIEHCECHOA_PrsEd);
			RNoteResultJudge j3 = new RNoteResultJudge(gameDb.NPNCNFKCIAE_RelSt, gameDb.HODKHINFHGH_RelEd);
			RNoteResultJudge j4 = new RNoteResultJudge(gameDb.MNGGGOOCJBM_SFlkSt, gameDb.BLEDLGDGBHI_SFlkEd);
			RNoteResultJudge j5 = new RNoteResultJudge(gameDb.PLGLPDGAADE_LFlkSt, gameDb.IFHAPIJOCOJ_LFlkEd);
			RNoteResultJudge j6 = new RNoteResultJudge(gameDb.KBOIDPDGCLA_PasSt, gameDb.GGAMKBLHGGI_PasEd);
			rNoteList = new List<RNote>(scoreData.inputNoteTrack.Count);
			for(int i = 0; i < scoreData.inputNoteTrack.Count; i++)
			{
				RNoteResultJudge r = j4;
				if(scoreData.inputNoteTrack[i].flick == MusicScoreData.FlickType.None)
				{
					r = j2;
					if(scoreData.inputNoteTrack[i].longTouch != MusicScoreData.TouchState.Start)
					{
						if(scoreData.inputNoteTrack[i].swipe != MusicScoreData.TouchState.Start)
						{
							r = j3;
							if(scoreData.inputNoteTrack[i].longTouch != MusicScoreData.TouchState.End)
							{
								r = j1;
								if(scoreData.inputNoteTrack[i].swipe == MusicScoreData.TouchState.End)
									r = j3;
							}
						}
					}
				}
				else
				{
					if(scoreData.inputNoteTrack[i].longTouch == MusicScoreData.TouchState.End)
						r = j5;
				}
				rNoteList.Add(new RNote(scoreData.inputNoteTrack[i], r, j6, MusicData.NoteModeType.None, 0));
			}
			rNoteObject.gameObject.SetActive(true);
			rNoteObject.positionAnimator.PrecalculationSampleAnim(rNoteObject.gameObject, true);
			rNoteObject.gameObject.SetActive(false);
			RNoteSingle note = Instantiate(rNoteSingle[GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.KDNKCOAJGCM_NotesType]);
			note.CreateSpecialNotesUVOffsetList();
			if(objectPool != null)
				objectPool.Dispose();
			objectPool = new RNoteObjectPool();
			objectPool.Create("RNoteObject_", notesOwner, rNoteObject, 10, false);
			if(singlePool != null)
				singlePool.Dispose();
			singlePool = new RNoteSinglePool();
			singlePool.Create("RNoteSingle_", notesOwner, note, 10, false);
			Destroy(note.gameObject);
			if(spawnRNoteObjects != null)
				spawnRNoteObjects.Clear();
			spawnRNoteObjects = new LinkedList<RNoteObject>();
			noteOffsetMillisec = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.OJAJHIMOIEC_NoteOffset * 10;
			notePrefOffsetMilllisec = noteOffsetMillisec;
			adjustSlider.onValueChanged.AddListener((float value) =>
			{
				//0xF64578
				noteOffsetMillisec = (int)(value) * 10;
				if(notePrefOffsetMilllisec != noteOffsetMillisec && !isSliderSeDisable)
				{
					SoundManager.Instance.sePlayerBoot.Stop();
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				}
				notePrefOffsetMilllisec = noteOffsetMillisec;
				isSliderSeDisable = false;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.OJAJHIMOIEC_NoteOffset = (int)value;
				layoutData.SetAdjustValue((int)value);
			});
			SetAdjustValue(noteOffsetMillisec / 10);
			SwitchMode(false);
			touchEffect.Instantiate();
			touchEffect.touchEffect.Play(UI_rhythm_Push_OUT_HashCode, 0);
			touchEffect.touchEffect.Play(UI_rhythm_Long_OUT_HashCode, 0);
			touchEffect.SkillEffect.Initialize();
			touchEffectObject.transform.SetParent(judgePointTransform, false);
			notesMarkerObject.transform.SetParent(judgePointTransform, false);
			notesMarkerObject.SetActive(true);
			notesMarkerObject.GetComponent<Animator>().Play(notes_button_Anim_Hash, 0, 1);
			if(!GameManager.Instance.IsTutorial)
			{
				ShowAdjustModeStartPopup();
				updater = UpdatePopupTask;
				return;
			}
			SwitchMode(true);
			layoutData.ChangeMode(LayoutRhythmAdjust.ModeType.CHECK);
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.OLDAGCNLJOI_Progress == 2)
			{
				this.StartCoroutineWatched(Co_TutorialEndFlow());
			}
			else
			{
				BasicTutorialManager.Log(OAGBCBBHMPF.OGBCFNIKAFI.JHMCNBGOOJF/*14*/);
				this.StartCoroutineWatched(Co_TutorialIntroFlow());
			}
		}

		// // RVA: 0xF612C4 Offset: 0xF612C4 VA: 0xF612C4
		private void ShowConfirmPopup(bool isDecide)
		{
			if(!isDecide)
			{
				if(layoutData.GetMode() == LayoutRhythmAdjust.ModeType.CHECK)
				{
					ShowAdjustFinishCheckPopup();
				}
				else if(layoutData.GetMode() == LayoutRhythmAdjust.ModeType.ADJUST)
				{
					ShowAdjustMoveConfirmModePopup();
				}
			}
			else
			{
				ShowAdjustFinishCheckPopup();
			}
			updater = UpdatePopupTask;
		}

		// // RVA: 0xF61DCC Offset: 0xF61DCC VA: 0xF61DCC
		// private void ShowTutorialConfirmPopup(bool isDecide) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6B04F0 Offset: 0x6B04F0 VA: 0x6B04F0
		// // RVA: 0xF61E84 Offset: 0xF61E84 VA: 0xF61E84
		// private IEnumerator Co_TutorialConfirmEvent() { }

		// // RVA: 0xF61F30 Offset: 0xF61F30 VA: 0xF61F30
		// private void OnBackButton() { }

		// // RVA: 0xF61F58 Offset: 0xF61F58 VA: 0xF61F58
		// private void PushConfirmWindowButton(LayoutRhythmAdjustTutorialConfirmWindow.ButtonType type) { }

		// // RVA: 0xF61FC4 Offset: 0xF61FC4 VA: 0xF61FC4
		// private void ConfirmWindowResult(LayoutRhythmAdjustTutorialConfirmWindow.ButtonType type) { }

		// // RVA: 0xF62414 Offset: 0xF62414 VA: 0xF62414
		private void UpdateAdjustTask()
		{
			int milli = GetRawMusicMillisec();
			if(isTestMode)
				milli -= noteOffsetMillisec;
			for(int i = 1; i < rNoteList.Count; i++)
			{
				rNoteList[i].Update(milli, 1800, 0);
			}
			for(int i = 1; i < rNoteList.Count; i++)
			{
				if(rNoteList[i].passingStatus == RNote.PassingStatus.Alive)
					AllocNote(rNoteList[i]);
			}
			TouchInfoRecord record = InputManager.Instance.GetFirstInScreenTouchRecord();
#if !UNITY_ANDROID
			if (record == null)
			{
				for (int i = 0; record == null && i < (int)InputManager.KeyTouchInfoRecord.KeyType.Num; i++)
				{
					record = InputManager.Instance.GetKeyTouchInfoRecord((InputManager.KeyTouchInfoRecord.KeyType)i);
					if (record.currentInfo.isIllegal)
						record = null;
				}
			}
#endif
			if(record != null)
			{
				if(!record.currentInfo.isBegan)
				{
					if(record.currentInfo.isEnded)
					{
						HideToucheEffect();
					}
				}
				else
				{
					bool isKeyOk = false;
#if !UNITY_ANDROID
					if(record is InputManager.KeyTouchInfoRecord)
					{
						InputManager.KeyTouchInfoRecord kr = record as InputManager.KeyTouchInfoRecord;
						isKeyOk |= kr.keyType == InputManager.KeyTouchInfoRecord.KeyType.Line1Touch;
						isKeyOk |= kr.keyType == InputManager.KeyTouchInfoRecord.KeyType.Line2Touch;
						isKeyOk |= kr.keyType == InputManager.KeyTouchInfoRecord.KeyType.Line3Touch;
						isKeyOk |= kr.keyType == InputManager.KeyTouchInfoRecord.KeyType.Line4Touch;
						isKeyOk |= kr.keyType == InputManager.KeyTouchInfoRecord.KeyType.Line5Touch;
						isKeyOk |= kr.keyType == InputManager.KeyTouchInfoRecord.KeyType.Line6Touch;
					}
#endif
					if(RectTransformUtility.RectangleContainsScreenPoint(touchRect, record.currentInfo.nativePosition) || isKeyOk)
					{
						if(!isTestMode)
						{
							isSliderSeDisable = true;
							JudgeGap();
						}
						else
						{
							JudgeResult();
						}
					}
				}
			}
			if(!bgmPlayer.isPlaying)
			{
				if(onConfirm != null)
					onConfirm(isDecide);
				isDecide = false;
				onConfirm = null;
				HideToucheEffect();
			}
		}

		// // RVA: 0xF62DB0 Offset: 0xF62DB0 VA: 0xF62DB0
		private void UpdatePopupTask()
		{
			return;
		}

		// // RVA: 0xF62BA0 Offset: 0xF62BA0 VA: 0xF62BA0
		private void JudgeGap()
		{
			for(int i = 0; i < rNoteList.Count; i++)
			{
				int t = Mathf.RoundToInt(rNoteList[i].gapMilliSec / 10.0f);
				if(t >= minSliderValue && t <= maxSliderValue && i != touchedNotesIndex)
				{
					SetAdjustValue(t);
					ShowTouchEffect();
					PlayNotesSE(NoteSEType.Exempt);
					touchedNotesIndex = i;
					return;
				}
			}
		}

		// // RVA: 0xF629C8 Offset: 0xF629C8 VA: 0xF629C8
		private void JudgeResult()
		{
			singlePool.MakeUsingList(ref activeSingleList);
			for(int i = 0; i < activeSingleList.Count; i++)
			{
				if(activeSingleList[i].noteObject.gameObject.activeSelf)
				{
					if(activeSingleList[i].noteObject.rNote.CalcEvaluation(0) != RhythmGameConsts.NoteResult.Exempt)
					{
						ShowTouchEffect();
						activeSingleList[i].noteObject.Judged(activeSingleList[i].noteObject.rNote.CalcEvaluation(0), 0);
						return;
					}
				}
			}
		}

		// // RVA: 0xF627B0 Offset: 0xF627B0 VA: 0xF627B0
		private int GetRawMusicMillisec()
		{
			return (int)bgmPlayer.timeSyncedWithAudio;
		}

		// // RVA: 0xF62FF0 Offset: 0xF62FF0 VA: 0xF62FF0
		// private int IncludeDeviceLatency(int rawMillisec) { }

		// // RVA: 0xF627F8 Offset: 0xF627F8 VA: 0xF627F8
		// private int IncludeNotesOffsert(int rawMillisec) { }

		// // RVA: 0xF628B4 Offset: 0xF628B4 VA: 0xF628B4
		public void AllocNote(RNote rNote)
		{
			RNoteObject note;
			if(AllocNoteObject(rNote, true, out note))
			{
				RNoteSingle n = singlePool.Alloc();
				n.gameObject.SetActive(true);
				n.Initialize(note, null);
			}
		}

		// // RVA: 0xF6302C Offset: 0xF6302C VA: 0xF6302C
		private bool AllocNoteObject(RNote rNote, bool isInScreen, out RNoteObject outputObject)
		{
			LinkedListNode<RNoteObject> n = spawnRNoteObjects.First;
			for(int i = 0; i < spawnRNoteObjects.Count; i++)
			{
				if(n.Value.rNote == rNote)
				{
					outputObject = n.Value;
					if(!outputObject.isInScreen && isInScreen)
					{
						outputObject.InScreen();
						return true;
					}
					return false;
				}
				n = n.Next;
			}
			outputObject = objectPool.Alloc();
			if(outputObject == null)
				return false;
			outputObject.Initialize(rNote, judgePointTransform, isInScreen);
			outputObject.AddJudgedEvent(OnJudgeNotes);
			spawnRNoteObjects.AddLast(outputObject);
			rNote.Spawn();
			return true;
		}

		// // RVA: 0xF633EC Offset: 0xF633EC VA: 0xF633EC
		private void ShowResultEffect(RhythmGameConsts.NoteResult result)
		{
			if(touchEffect.resultEffectSimple == null)
				return;
			touchEffect.resultEffectSimple.Play(ResultAnimationStateTable[(int)result]);
		}

		// // RVA: 0xF62DBC Offset: 0xF62DBC VA: 0xF62DBC
		private void ShowTouchEffect()
		{
			touchEffect.touchEffect.Play(UI_rhythm_Push_IN_HashCode, 0);
			if(touchEffect.RandomRotate != null)
			{
				touchEffect.RandomRotate.Do();
			}
			touchEffect.FingerId = 1;
		}

		// // RVA: 0xF62D0C Offset: 0xF62D0C VA: 0xF62D0C
		private void HideToucheEffect()
		{
			if(touchEffect.FingerId < 0)
				return;
			touchEffect.touchEffect.Play(UI_rhythm_Push_OUT_HashCode, 0);
			touchEffect.FingerId = -1;
		}

		// // RVA: 0xF63610 Offset: 0xF63610 VA: 0xF63610
		private void OnJudgeNotes(RNoteObject noteObject, RhythmGameConsts.NoteResultEx result_ex, RhythmGameConsts.NoteJudgeType judge_type)
		{
			if(!isTestMode)
				return;
			ShowResultEffect(result_ex.m_result);
			PlayNoteSEByResult(result_ex.m_result);
		}

		// // RVA: 0xF63674 Offset: 0xF63674 VA: 0xF63674
		private void PlayNoteSEByResult(RhythmGameConsts.NoteResult result)
		{
			NoteSEType type = NoteSEType.Bad;
			switch(result)
			{
				case RhythmGameConsts.NoteResult.Good:
					type = NoteSEType.Good;
					break;
				case RhythmGameConsts.NoteResult.Great:
					type = NoteSEType.Great;
					break;
				case RhythmGameConsts.NoteResult.Perfect:
					type = NoteSEType.Perfect;
					break;
			}
			PlayNotesSE(type);
		}

		// // RVA: 0xF62F1C Offset: 0xF62F1C VA: 0xF62F1C
		private CriAtomExPlayback PlayNotesSE(NoteSEType type)
		{
			return SoundManager.Instance.sePlayerNotes.Play(noteTouchSEIndex[(int)type]);
		}

		// // RVA: 0xF605D8 Offset: 0xF605D8 VA: 0xF605D8
		public void SwitchMode(bool testMode)
		{
			isTestMode = testMode;
			for(int i = 0; i < singlePool.list.Count; i++)
			{
				singlePool.list[i].GetComponentInChildren<MeshRenderer>(true).enabled = testMode;
			}
		}

		// // RVA: 0xF636E8 Offset: 0xF636E8 VA: 0xF636E8
		public void Decide()
		{
			spawnRNoteObjects.Clear();
			objectPool.FreeAll();
			singlePool.FreeAll();
			bgmPlayer.Stop();
			isDecide = true;
		}

		// // RVA: 0xF60570 Offset: 0xF60570 VA: 0xF60570
		public void SetAdjustValue(int value)
		{
			adjustSlider.value = value;
			layoutData.SetAdjustValue(value);
		}

		// // RVA: 0xF637E4 Offset: 0xF637E4 VA: 0xF637E4
		// public int GetAdjustValue() { }

		// // RVA: 0xF63824 Offset: 0xF63824 VA: 0xF63824
		public void MinusAdjustValue()
		{
			SetAdjustValue((int)(adjustSlider.value) - 1);
		}

		// // RVA: 0xF63874 Offset: 0xF63874 VA: 0xF63874
		public void PlusAdjustValue()
		{
			SetAdjustValue((int)(adjustSlider.value) + 1);
		}

		// // RVA: 0xF618B0 Offset: 0xF618B0 VA: 0xF618B0
		private void ShowAdjustMoveConfirmModePopup()
		{
			adjustSlider.enabled = false;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = new TextPopupSetting();
			s.TitleText = bk.GetMessageByLabel("rhythm_adjust_confirmmode_title");
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Readjustment, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.MoveConfirmMode, Type = PopupButton.ButtonType.Positive },
			};
			s.Text = string.Format(bk.GetMessageByLabel("rhythm_adjust_confirmmode_text"), adjustSlider.value.ToString("+#;-#;0"));
			if(GameManager.Instance.IsTutorial)
			{
				PopupWindowManager.Show(s, AdjustTutorialMoveConfirmMode, null, () =>
				{
					//0xF647DC
					BasicTutorialManager.Instance.HideCursor();
				}, null);
			}
			else
			{
				PopupWindowManager.Show(s, AdjustMoveConfirmMode, null, null, null);
			}
		}

		// // RVA: 0xF61394 Offset: 0xF61394 VA: 0xF61394
		private void ShowAdjustFinishCheckPopup()
		{
			adjustSlider.enabled = false;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = new TextPopupSetting();
			s.TitleText = bk.GetMessageByLabel("popup_rhythm_adjust_result_title");
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Readjustment, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive },
			};
			s.Text = string.Format(bk.GetMessageByLabel("popup_rhythm_adjust_result_text"), adjustSlider.value.ToString("+#;-#;0"));
			if(GameManager.Instance.IsTutorial)
			{
				PopupWindowManager.Show(s, AdjustTutorialConfirmPopupResult, null, () =>
				{
					//0xF64858
					BasicTutorialManager.Instance.HideCursor();
				}, null);
			}
			else
			{
				PopupWindowManager.Show(s, AdjustConfirmPopupResult, null, null, null);
			}
		}

		// // RVA: 0xF638C4 Offset: 0xF638C4 VA: 0xF638C4
		private void AdjustMoveConfirmMode(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label)
		{
			if(type == PopupButton.ButtonType.Positive)
			{
				SwitchMode(true);
				layoutData.ChangeMode(LayoutRhythmAdjust.ModeType.CHECK);
			}
			adjustSlider.enabled = true;
			ChangeAdjustTask(ShowConfirmPopup);
		}

		// // RVA: 0xF639BC Offset: 0xF639BC VA: 0xF639BC
		private void AdjustTutorialMoveConfirmMode(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label)
		{
			TodoLogger.LogError(0, "AdjustTutorialMoveConfirmMode");
		}

		// // RVA: 0xF63A58 Offset: 0xF63A58 VA: 0xF63A58
		private void AdjustConfirmPopupResult(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label)
		{
			if(type == PopupButton.ButtonType.Negative)
			{
				adjustSlider.enabled = true;
				SwitchMode(false);
				layoutData.ChangeMode(LayoutRhythmAdjust.ModeType.ADJUST);
				ChangeAdjustTask(ShowConfirmPopup);
			}
			else if(type == PopupButton.ButtonType.Positive)
			{
				GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
				NextScene("Menu");
			}
		}

		// // RVA: 0xF63BEC Offset: 0xF63BEC VA: 0xF63BEC
		private void AdjustTutorialConfirmPopupResult(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label)
		{
			TodoLogger.LogError(0, "AdjustTutorialConfirmPopupResult");
		}

		// // RVA: 0xF60F40 Offset: 0xF60F40 VA: 0xF60F40
		private void ShowAdjustModeStartPopup()
		{
			adjustSlider.enabled = false;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = new TextPopupSetting();
			s.TitleText = bk.GetMessageByLabel("popup_rhythm_adjust_start_title");
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			s.Text = bk.GetMessageByLabel("popup_rhythm_adjust_start_text");
			if(GameManager.Instance.IsTutorial)
				PopupWindowManager.Show(s, AdjustTutorialPopupResult, null, null, null);
			else
				PopupWindowManager.Show(s, AdjustPopupResult, null, null, null);
		}

		// // RVA: 0xF63D30 Offset: 0xF63D30 VA: 0xF63D30
		private void AdjustPopupResult(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label)
		{
			adjustSlider.enabled = true;
			ChangeAdjustTask(ShowConfirmPopup);
		}

		// // RVA: 0xF63DF0 Offset: 0xF63DF0 VA: 0xF63DF0
		private void AdjustTutorialPopupResult(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label)
		{
			TodoLogger.LogError(0, "AdjustTutorialPopupResult");
		}

		// // RVA: 0xF62288 Offset: 0xF62288 VA: 0xF62288
		private void ChangeAdjustTask(Action<bool> onConfirmAction)
		{
			spawnRNoteObjects.Clear();
			objectPool.FreeAll();
			singlePool.FreeAll();
			bgmPlayer.Play(BgmPlayer.ADJUST_BGM, 1);
			touchedNotesIndex = -1;
			updater = UpdateAdjustTask;
			onConfirm = onConfirmAction;
		}

		// // RVA: 0xF6217C Offset: 0xF6217C VA: 0xF6217C
		// private void EndTutorialAdjust() { }

		// // RVA: 0xF63E84 Offset: 0xF63E84 VA: 0xF63E84
		// private void GotoTutorialGame() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6B0568 Offset: 0x6B0568 VA: 0x6B0568
		// // RVA: 0xF63FB8 Offset: 0xF63FB8 VA: 0xF63FB8
		// private IEnumerator GotoTutorialGameCoroutine(JGEOBNENMAH.EDHCNKBMLGI setup) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6B05E0 Offset: 0x6B05E0 VA: 0x6B05E0
		// // RVA: 0xF60EB4 Offset: 0xF60EB4 VA: 0xF60EB4
		private IEnumerator Co_TutorialIntroFlow()
		{
			TodoLogger.LogError(0, "Co_TutorialIntroFlow");
			yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B0658 Offset: 0x6B0658 VA: 0x6B0658
		// // RVA: 0xF60E28 Offset: 0xF60E28 VA: 0xF60E28
		private IEnumerator Co_TutorialEndFlow()
		{
			TodoLogger.LogError(0, "Co_TutorialEndFlow");
			yield return null;
		}
	}
}
