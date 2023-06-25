using UnityEngine;
using System.Collections.Generic;
using XeApp.Game.Common;
using XeSys;
using XeApp.Core;
using System.Text;

namespace XeApp.Game.RhythmGame
{
	public class RNoteOwner : MonoBehaviour
	{
		private struct PausingInputData
		{
			public int fingerId; // 0x0
			public bool release; // 0x4

			//// RVA: 0x7FB49C Offset: 0x7FB49C VA: 0x7FB49C
			public void Reset()
			{
				release = false;
				fingerId = -1;
			}
		}

		private MusicData musicData; // 0xC
		private MusicScoreData musicScoreData; // 0x10
		[SerializeField]
		private List<RNote> rNoteList; // 0x14
		private RNoteSpawner rNoteSpawner; // 0x18
		private RNoteRemover rNoteRemover; // 0x1C
		private RNoteLaneManager rNoteLaneManager; // 0x20
		[SerializeField]
		private GameObject judgePointObject; // 0x24
		[SerializeField]
		private GameObject judgePointObjectWide; // 0x28
		[SerializeField]
		private Transform[] judgePointTransforms; // 0x2C
		[SerializeField]
		private float[] neutralCounter; // 0x30
		private int[] lineTouchFingerIds; // 0x34
		public bool isPause; // 0x4C
		private RNoteOwner.PausingInputData[] pausingInputData; // 0x50
		private List<RNoteSingle> activeSingleList = new List<RNoteSingle>(30); // 0x58
		private List<RNoteLong> activeLongList = new List<RNoteLong>(15); // 0x5C
		private List<RNoteSlide> activeSlideList = new List<RNoteSlide>(15); // 0x60
		private RNoteObject.DelegateOverrideNoteJudged delegateOverrideNoteJudgeList; // 0x64
		private RNoteObject.NoteJudgedDelegate judgedDelegate; // 0x68
		private RNoteObject.NoteBeyondDelegate beyondDelegate; // 0x6C
		private RNoteObject.NotePassedDelegate passedDelegate; // 0x70
		private RhythmGameSpecialNotesAssigner specialNotesAssigner = new RhythmGameSpecialNotesAssigner(); // 0x74
		private RhythmGameMode gameMode; // 0x78
		private BuffEffectOwner buffOwner; // 0x7C
		private int[] evaluationOffsetMillisec; // 0x80
		public int checkStartNotesIndex = 1; // 0x84
		public int checkEndNotesIndex = 1; // 0x88
		public bool assignedCenterLiveSkillNote; // 0x8C
		private int limitNoteJudgeScaleUp; // 0x90
		private int limitNoteJudgeScaleDown; // 0x94

		public RNoteObjectPool objectPool { get; private set; } // 0x38
		public RNoteSinglePool singlePool { get; private set; } // 0x3C
		public RNoteLongPool longPool { get; private set; } // 0x40
		public RNoteSyncPool syncPool { get; private set; } // 0x44
		public RNoteSlidePool slidePool { get; private set; } // 0x48
		public LinkedList<RNoteObject> spawnRNoteObjects { get; private set; } // 0x54

		//// RVA: 0xDB12E4 Offset: 0xDB12E4 VA: 0xDB12E4
		private int LimitNoteJudgeValue(int a_limit, int a_value)
		{
			if (a_limit >= 1 && a_value < 1)
				return a_value;
			return Mathf.Min(a_limit, a_value);
		}

		//// RVA: 0xDB1384 Offset: 0xDB1384 VA: 0xDB1384
		public void Initialize(MusicData muiscData, RhythmGameMode gameMode, BuffEffectOwner buffOwner, RhythmGameSpecialNotesAssigner.AssignInfo a_assing_info, bool a_setting_mv, bool a_notes_seeting_mv, bool a_setting_skip = false)
		{
			musicData = muiscData;
			musicScoreData = muiscData.musicScoreData;
			this.gameMode = gameMode;
			this.buffOwner = buffOwner;
			neutralCounter = new float[RhythmGameConsts.LineNum];
			for(int i = 0; i < neutralCounter.Length; i++)
			{
				neutralCounter[i] = 0;
			}
			lineTouchFingerIds = new int[RhythmGameConsts.LineNum];
			for(int i = 0; i < lineTouchFingerIds.Length; i++)
			{
				lineTouchFingerIds[i] = -1;
			}
			SetJudgePointTransform();
			pausingInputData = new PausingInputData[RhythmGameConsts.LineNum];
			evaluationOffsetMillisec = new int[RhythmGameConsts.LineNum];
			LDDDBPNGGIN_Game gameDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game;
			RNoteResultJudge j1 = new RNoteResultJudge(gameDb.BFDLLHNGICE_TapSt, gameDb.ICNFEDCCODF_TapEd);
			RNoteResultJudge j2 = new RNoteResultJudge(gameDb.EKONPEGLAND_PrsSt, gameDb.ILIEHCECHOA_PrsEd);
			RNoteResultJudge j3 = new RNoteResultJudge(gameDb.NPNCNFKCIAE_RelSt, gameDb.HODKHINFHGH_RelEd);
			RNoteResultJudge j4 = new RNoteResultJudge(gameDb.MNGGGOOCJBM_SFlkSt, gameDb.BLEDLGDGBHI_SFlkEd);
			RNoteResultJudge j5 = new RNoteResultJudge(gameDb.PLGLPDGAADE_LFlkSt, gameDb.IFHAPIJOCOJ_LFlkEd);
			RNoteResultJudge j6 = new RNoteResultJudge(gameDb.DDLNCIOPBBB_SlRelSt, gameDb.DDGNKEJKJCK_SlRelEd);
			RNoteResultJudge j7 = new RNoteResultJudge(gameDb.KDGGKFOAGAE_SlFlkSt, gameDb.FBKOFEHDENI_SlFlkEd);
			RNoteResultJudge j8 = new RNoteResultJudge(gameDb.KBOIDPDGCLA_PasSt, gameDb.GGAMKBLHGGI_PasEd);

			limitNoteJudgeScaleUp = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.LPJLEHAJADA_GetIntParam("limit_note_judge_scale_up", 0);
			limitNoteJudgeScaleDown = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.LPJLEHAJADA_GetIntParam("limit_note_judge_scale_down", 0);

			for(int i = 0; i < pausingInputData.Length; i++)
			{
				pausingInputData[i].release = false;
				pausingInputData[i].fingerId = -1;
			}

			int[] ints = new int[4];
			rNoteList = new List<RNote>(musicScoreData.inputNoteTrack.Count);
			for(int i = 0; i < musicScoreData.inputNoteTrack.Count; i++)
			{
				RNoteResultJudge judgeType = null;
				if (musicScoreData.inputNoteTrack[i].flick == MusicScoreData.FlickType.None)
				{
					judgeType = j2;
					if(musicScoreData.inputNoteTrack[i].longTouch != MusicScoreData.TouchState.Start)
					{
						if(musicScoreData.inputNoteTrack[i].swipe != MusicScoreData.TouchState.Start)
						{
							if(musicScoreData.inputNoteTrack[i].longTouch != MusicScoreData.TouchState.End && musicScoreData.inputNoteTrack[i].swipe != MusicScoreData.TouchState.End)
							{
								judgeType = j1;
							}
							else
							{
								judgeType = j3;
								if (musicScoreData.inputNoteTrack[i].isSlide)
									judgeType = j6;
							}
						}
					}
				}
				else
				{
					judgeType = j4;
					if(musicScoreData.inputNoteTrack[i].longTouch == MusicScoreData.TouchState.End)
					{
						judgeType = j5;
						if (musicScoreData.inputNoteTrack[i].isSlide)
							judgeType = j7;
					}
				}
				MusicData.NoteModeType modeType = musicData.GetNotesModeType(musicScoreData.inputNoteTrack[i]);
				rNoteList.Add(new RNote(musicScoreData.inputNoteTrack[i], judgeType, j8, modeType, ints[(int)modeType]));
				ints[(int)modeType]++;
			}
			checkStartNotesIndex = 1;
			checkEndNotesIndex = 1;
			assignedCenterLiveSkillNote = false;
			if(!a_setting_mv)
			{
				specialNotesAssigner.Initialize(musicData, a_assing_info, this.OnModeAttrAssign, this.OnModeItemInfoAssign);
				specialNotesAssigner.Assign(rNoteList);
			}
			rNoteSpawner = new RNoteSpawner(this, musicData, rNoteList);
			rNoteRemover = new RNoteRemover(this, musicData, rNoteList);
			rNoteLaneManager = new RNoteLaneManager();
			rNoteLaneManager.Initialize(rNoteList);

			if (objectPool != null)
				objectPool.Dispose();
			if (singlePool != null)
				singlePool.Dispose();
			if (longPool != null)
				longPool.Dispose();
			if (syncPool != null)
				syncPool.Dispose();
			if (slidePool != null)
				slidePool.Dispose();
			if(spawnRNoteObjects != null)
				spawnRNoteObjects.Clear();
			objectPool = new RNoteObjectPool();
			singlePool = new RNoteSinglePool();
			longPool = new RNoteLongPool();
			syncPool = new RNoteSyncPool();
			slidePool = new RNoteSlidePool();
			spawnRNoteObjects = new LinkedList<RNoteObject>();

			int noteType = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.KDNKCOAJGCM_NotesType;
			if (Database.Instance.gameSetup.ForceNoteType() > 0)
			{
				noteType = Database.Instance.gameSetup.ForceNoteType();
			}

			RNoteObject r1 = Resources.Load<RNoteObject>(string.Format("MusicGame/NoteObject_{0:D2}/RNoteObject", noteType));
			RNoteObject pr1 = Instantiate(r1);
			RNoteSingle r2 = Resources.Load<RNoteSingle>(string.Format("MusicGame/NoteObject_{0:D2}/rNoteSingle", noteType));
			RNoteSingle pr2 = Instantiate(r2);
			RNoteLong r3 = Resources.Load<RNoteLong>(string.Format("MusicGame/NoteObject_{0:D2}/rNoteLong", noteType));
			RNoteLong pr3 = Instantiate(r3);
			RNoteSync r4 = Resources.Load<RNoteSync>(string.Format("MusicGame/NoteObject_{0:D2}/rNoteSync", noteType));
			RNoteSync pr4 = Instantiate(r4);
			RNoteSlide r5 = Resources.Load<RNoteSlide>(string.Format("MusicGame/NoteObject_{0:D2}/rNoteSlide", noteType));
			RNoteSlide pr5 = Instantiate(r5);

			RuntimeAnimatorController ctrl = Resources.Load<RuntimeAnimatorController>(RhythmGameConsts.IsWideLine() ? "MusicGame/Animation/GameNotesLineAnimationW" : "MusicGame/Animation/GameNotesLineAnimation");
			RNotePositionAnimator.InitializeAnim();

			pr1.gameObject.SetActive(true);
			pr1.positionAnimator.SetRuntimeAnimatorController(ctrl);
			pr1.positionAnimator.PrecalculationSampleAnim(pr1.gameObject, false);
			pr1.gameObject.SetActive(false);

			pr2.CreateSpecialNotesUVOffsetList();

			objectPool.Create("RNoteObject_", gameObject, pr1, 50, false);
			singlePool.Create("RNoteSingle_", gameObject, pr2, 50, false);
			longPool.Create("RNoteLong_", gameObject, pr3, 15, false);
			syncPool.Create("RNoteSync_", gameObject, pr4, 15, false);
			slidePool.Create("RNoteSlide_", gameObject, pr5, 30, false);

			longPool.RootObject.transform.SetLocalPositionZ(100); // XeSys.TransformExtension
			syncPool.RootObject.transform.SetLocalPositionZ(5);
			slidePool.RootObject.transform.SetLocalPositionZ(100);
			if(a_setting_mv)
			{
				SetEnableRenderer(a_notes_seeting_mv);
				for(int i = 0; i < objectPool.list.Count; i++)
				{
					objectPool.list[i].funcForceOverwriteNoteResult = () =>
					{
						//0xDBC5F8
						return RhythmGameConsts.NoteResult.Perfect;
					};
				}
			}
			if(a_setting_skip)
			{
				SetEnableRenderer(false);
				for (int i = 0; i < objectPool.list.Count; i++)
				{
					objectPool.list[i].funcForceOverwriteNoteResult = () =>
					{
						//0xDBC600
						return RhythmGameConsts.NoteResult.Perfect;
					};
				}
			}
			Destroy(pr1.gameObject);
			Destroy(pr2.gameObject);
			Destroy(pr3.gameObject);
			Destroy(pr4.gameObject);
			Destroy(pr5.gameObject);
		}

		//// RVA: 0xDB2F30 Offset: 0xDB2F30 VA: 0xDB2F30
		private void SetJudgePointTransform()
		{
			GameObject judgeObject = null;
			if(RhythmGameConsts.IsWideLine())
			{
				judgePointObjectWide.SetActive(true);
				judgePointObject.SetActive(false);
				judgeObject = judgePointObjectWide;
			}
			else
			{
				judgePointObjectWide.SetActive(false);
				judgePointObject.SetActive(true);
				judgeObject = judgePointObject;
			}
			judgePointTransforms = new Transform[judgeObject.transform.childCount];
			for (int i = 0; i < judgePointTransforms.Length; i++)
			{
				judgePointTransforms[i] = judgeObject.transform.GetChild(i);
			}
		}

		//// RVA: 0xDB4FF8 Offset: 0xDB4FF8 VA: 0xDB4FF8
		public void SetLineAlphaCallback(RNoteLaneManager.LineAlphaCallback callback)
		{
			rNoteLaneManager.SetLineAlphaCallback(callback);
		}

		//// RVA: 0xDB4A58 Offset: 0xDB4A58 VA: 0xDB4A58
		public void SetEnableRenderer(bool a_renderer)
		{
			foreach(var o in singlePool.list)
			{
				o.SetEnableRenderer(a_renderer);
			}
			foreach (var o in longPool.list)
			{
				o.SetEnableRenerer(a_renderer);
			}
			foreach (var o in syncPool.list)
			{
				o.SetEnableRenerer(a_renderer);
			}
			foreach (var o in slidePool.list)
			{
				o.SetEnableRenerer(a_renderer);
			}
		}

		//// RVA: 0xDB5204 Offset: 0xDB5204 VA: 0xDB5204
		//public void Free() { }

		//// RVA: 0xDB53E8 Offset: 0xDB53E8 VA: 0xDB53E8
		public void Pause()
		{
			if (isPause)
				return;
			isPause = true;
			if(pausingInputData != null)
			{
				for(int i = 0; i < pausingInputData.Length; i++)
				{
					pausingInputData[i].Reset();
				}
				longPool.MakeUsingList(ref activeLongList);
				for(int i = 0; i < activeLongList.Count; i++)
				{
					activeLongList[i].Pause();
				}
				slidePool.MakeUsingList(ref activeSlideList);
				for(int i = 0; i < activeSlideList.Count; i++)
				{
					activeSlideList[i].Pause();
				}
			}
		}

		//// RVA: 0xDB565C Offset: 0xDB565C VA: 0xDB565C
		public void Resume()
		{
			if (!isPause)
				return;
			isPause = false;
			if (pausingInputData == null)
				return;

			slidePool.MakeUsingList(ref activeSlideList);
			for (int i = 0; i < activeSlideList.Count; i++)
			{
				activeSlideList[i].Resume();
				if (activeSlideList[i].gameObject.activeSelf && activeSlideList[i].touchFingerId >= 0)
				{
					bool cont = true;
					for (int j = 0; cont && j < pausingInputData.Length; j++)
					{
						if (!pausingInputData[j].release && pausingInputData[j].fingerId > -1)
						{
							if (NotesSoundPlayer.LineIDToLineGroup(j) == NotesSoundPlayer.LineIDToLineGroup(activeSlideList[i].firstRNoteObject.rNote.noteInfo.trackID))
							{
								activeSlideList[i].IsPauseKeep = true;
								activeSlideList[i].BeginTouch(pausingInputData[j].fingerId);
								cont = false;
								break;
							}
						}
					}
				}
			}
			singlePool.MakeUsingList(ref activeSingleList);
			longPool.MakeUsingList(ref activeLongList);
			for (int i = 0; i < activeLongList.Count; i++)
			{
				activeLongList[i].Resume();
			}
			for (int i = 0; i < pausingInputData.Length; i++)
			{
				if(pausingInputData[i].fingerId > -1)
				{
					if(!pausingInputData[i].release)
					{
						lineTouchFingerIds[i] = pausingInputData[i].fingerId;
						for(int j = 0; j < activeSingleList.Count; j++)
						{
							if(activeSingleList[j].touchFingerId == -1 && activeSingleList[j].noteObject.rNote.noteInfo.flick != MusicScoreData.FlickType.None && activeSingleList[j].noteObject.rNote.noteInfo.longTouch == MusicScoreData.TouchState.None && activeSingleList[j].noteObject.gameObject.activeSelf && activeSingleList[j].noteObject.rNote.noteInfo.trackID == i)
							{
								activeSingleList[j].touchFingerId = pausingInputData[i].fingerId;
							}
						}
						for (int j = 0; j < activeLongList.Count; j++)
						{
							if (activeLongList[j].touchFingerId == -1 && activeLongList[j].firstRNoteObject.gameObject.activeSelf && activeLongList[j].firstRNoteObject.rNote.noteInfo.trackID == i)
							{
								activeLongList[j].BeginTouch(pausingInputData[i].fingerId);
							}
						}
					}
					else
					{
						EndedTouch(i, i, pausingInputData[i].fingerId, false, true);
					}
				}
			}
			for (int i = 0; i < activeSlideList.Count; i++)
			{
				activeSlideList[i].IsPauseKeep = false;
			}
		}

		//// RVA: 0xDB6E6C Offset: 0xDB6E6C VA: 0xDB6E6C
		public void RemoveAllDelegate()
		{
			delegateOverrideNoteJudgeList = null;
			judgedDelegate = null;
			beyondDelegate = null;
			passedDelegate = null;
		}

		//// RVA: 0xDB6E7C Offset: 0xDB6E7C VA: 0xDB6E7C
		public void SetDelegateOverrideNoteJudge(RNoteObject.DelegateOverrideNoteJudged a_delegate)
		{
			delegateOverrideNoteJudgeList = a_delegate;
		}

		//// RVA: 0xDB6E84 Offset: 0xDB6E84 VA: 0xDB6E84
		public void AddJudgeDelegate(RNoteObject.NoteJudgedDelegate judgedDelegate)
		{
			if (judgedDelegate != null)
				this.judgedDelegate += judgedDelegate;
		}

		//// RVA: 0xDB6E90 Offset: 0xDB6E90 VA: 0xDB6E90
		//public void AddBeyondDelegate(RNoteObject.NoteBeyondDelegate beyondDelegate) { }

		//// RVA: 0xDB6E9C Offset: 0xDB6E9C VA: 0xDB6E9C
		//public void AddPassedDelegate(RNoteObject.NotePassedDelegate passedDelegate) { }

		//// RVA: 0xDB6EA8 Offset: 0xDB6EA8 VA: 0xDB6EA8
		public void OnUpdate(int musicMilliSec)
		{
			for(int i = 0; i < evaluationOffsetMillisec.Length; i++)
			{
				evaluationOffsetMillisec[i] = LimitNoteJudgeValue(limitNoteJudgeScaleUp, buffOwner.effectiveBuffList.GetEffectValue(SkillBuffEffect.Type.EasyMode, i, RhythmGameConsts.NoteResult.None));
				evaluationOffsetMillisec[i] -= LimitNoteJudgeValue(limitNoteJudgeScaleDown, buffOwner.effectiveBuffList.GetEffectValue(SkillBuffEffect.Type.HardMode, i, RhythmGameConsts.NoteResult.None));
			}
			for(int i = checkStartNotesIndex; i < rNoteList.Count; i++)
			{
				rNoteList[i].Update(musicMilliSec, musicData.noteDisplayMillisec, evaluationOffsetMillisec[rNoteList[i].noteInfo.trackID]);
				if (rNoteList[i].noteInfo.time > (musicData.noteDisplayMillisec + musicMilliSec))
					break;
			}
			rNoteSpawner.Update(musicData.noteDisplayMillisec + musicMilliSec);
			rNoteRemover.Update(musicData.noteDisplayMillisec + musicMilliSec);
			rNoteLaneManager.Update(musicMilliSec);
		}

		//// RVA: 0xDB7AA4 Offset: 0xDB7AA4 VA: 0xDB7AA4
		public void AllocNote(RNote rNote)
		{
			RNoteObject res;
			if(AllocNoteObject(rNote, true, out res))
			{
				RNoteSingle single = singlePool.Alloc();
				if(single != null)
				{
					single.gameObject.SetActive(true);
					single.Initialize(res, gameMode);
					if(rNote.noteInfo.sync == MusicScoreData.TouchState.Start)
					{
						RNoteObject[] rn = new RNoteObject[2];
						rn[0] = res;
						AllocNoteObject(rNoteList[rNote.noteInfo.syncIndex], false, out rn[1]);
						if(!res.IsJudged())
						{
							RNoteSync sync = syncPool.Alloc();
							if (sync == null)
								return;
							sync.Initialize(rn);
						}
					}
					if(rNote.noteInfo.longTouch == MusicScoreData.TouchState.Start)
					{
						List<int> l = new List<int>(20);
						for(int i = rNote.noteInfo.nextIndex; i != 0; )
						{
							l.Add(i);
							i = rNoteList[i].noteInfo.nextIndex;
						}
						for(int i = 0; i < l.Count; i++)
						{
							RNoteObject[] rn = new RNoteObject[2];
							rn[0] = res;
							AllocNoteObject(rNoteList[l[i]], false, out rn[1]);
							RNoteLong longNote = !rn[0].rNote.noteInfo.isSlide ? longPool.Alloc() : slidePool.Alloc();
							if (longNote == null)
								return;
							longNote.Initialize(rn);
							res = rn[1];
						}
					}
				}
			}
		}

		//// RVA: 0xDB8288 Offset: 0xDB8288 VA: 0xDB8288
		private bool AllocNoteObject(RNote rNote, bool isInScreen, out RNoteObject outputObject)
		{
			var r = spawnRNoteObjects.First;
			for(int i = 0; i < spawnRNoteObjects.Count; i++)
			{
				if(r.Value.rNote == rNote)
				{
					outputObject = r.Value;
					if (outputObject.isInScreen)
						return false;
					if (!isInScreen)
						return false;
					outputObject.InScreen();
					return true;
				}
				r = r.Next;
			}
			outputObject = objectPool.Alloc();
			if(outputObject != null)
			{
				outputObject.Initialize(rNote, judgePointTransforms[rNote.noteInfo.trackID], isInScreen);
				outputObject.AddJudgedEvent(judgedDelegate);
				outputObject.AddBeyondEvent(beyondDelegate);
				outputObject.AddPassedEvent(passedDelegate);
				outputObject.SetDelegateOverrideNoteJudge(delegateOverrideNoteJudgeList);
				spawnRNoteObjects.AddLast(outputObject);
				rNote.Spawn();
				return true;
			}
			return false;
		}

		//// RVA: 0xDB8AC8 Offset: 0xDB8AC8 VA: 0xDB8AC8
		public void FreeNote(RNoteObject obj)
		{
			if(obj == null)
				return;
			if(!obj.IsJudged())
				return;
			obj.Passed();
			spawnRNoteObjects.Remove(obj);
			obj.Free();
		}

		//// RVA: 0xDB8BEC Offset: 0xDB8BEC VA: 0xDB8BEC
		public bool BeganTouch(int lineNo, int fingerId)
		{
			if(!isPause)
			{
				neutralCounter[fingerId] = 0;
				if(lineTouchFingerIds[lineNo] == -1)
				{
					lineTouchFingerIds[lineNo] = fingerId;
					singlePool.MakeUsingList(ref activeSingleList);
					activeSingleList.RemoveAll((RNoteSingle _) =>
					{
						//0xDBC608
						return _.noteObject.rNote.GetLineNo() != lineNo;
					});
					activeSingleList.Sort(SinglePoolSortTimeFunc);
					for(int i = 0; i < activeSingleList.Count; i++)
					{
						if (activeSingleList[i].noteObject.rNote.noteInfo.longTouch != MusicScoreData.TouchState.None)
							break;
						if(activeSingleList[i].gameObject.activeSelf)
						{
							RhythmGameConsts.NoteResult res = activeSingleList[i].noteObject.rNote.CalcEvaluation(evaluationOffsetMillisec[activeSingleList[i].noteObject.rNote.noteInfo.trackID]);
							if (res != RhythmGameConsts.NoteResult.Exempt)
							{
								if(activeSingleList[i].noteObject.rNote.noteInfo.flick != MusicScoreData.FlickType.None)
								{
									activeSingleList[i].BeginTouch(fingerId, res);
									return true;
								}
								return activeSingleList[i].noteObject.Judged(res, RhythmGameConsts.NoteJudgeType.Normal);
							}
						}
					}
					longPool.MakeUsingList(ref activeLongList);
					activeLongList.Sort(LongPoolSortFirstTimeFunc);
					for(int i = 0; i < activeLongList.Count; i++)
					{
						if(activeLongList[i].gameObject.activeSelf && activeLongList[i].firstRNoteObject.rNote.noteInfo.trackID == lineNo)
						{
							RhythmGameConsts.NoteResult res = activeLongList[i].firstRNoteObject.rNote.CalcEvaluation(evaluationOffsetMillisec[activeLongList[i].firstRNoteObject.rNote.noteInfo.trackID]);
							if(res != RhythmGameConsts.NoteResult.Exempt)
							{
								activeLongList[i].BeginTouch(fingerId);
								return activeLongList[i].firstRNoteObject.Judged(res, RhythmGameConsts.NoteJudgeType.Normal);
							}
						}
					}
					slidePool.MakeUsingList(ref activeSlideList);
					activeSlideList.Sort(LongPoolSortFirstTimeFunc);
					for(int i = 0; i < activeSlideList.Count; i++)
					{
						if (activeSlideList[i].gameObject.activeSelf && activeSlideList[i].firstRNoteObject.rNote.noteInfo.trackID == lineNo)
						{
							if(activeSlideList[i].touchFingerId == -1)
							{
								RhythmGameConsts.NoteResult res = activeSlideList[i].firstRNoteObject.rNote.CalcEvaluation(evaluationOffsetMillisec[activeSlideList[i].firstRNoteObject.rNote.noteInfo.trackID]);
								if(res != RhythmGameConsts.NoteResult.Exempt)
								{
									activeSlideList[i].BeginTouch(fingerId);
									int nextIdx = activeSlideList[i].firstRNoteObject.rNote.noteInfo.nextIndex;
									while (nextIdx != 0)
									{
										if (rNoteList[nextIdx].noteInfo.isSlide)
										{
											for (int j = 0; j < activeSlideList.Count; j++)
											{
												if (rNoteList[nextIdx].noteInfo.thisIndex == activeSlideList[j].firstRNoteObject.rNote.noteInfo.nextIndex
													|| rNoteList[nextIdx].noteInfo.thisIndex == activeSlideList[j].lastRNoteObject.rNote.noteInfo.nextIndex)
												{
													if (activeSlideList[j].touchFingerId == -1)
													{
														activeSlideList[j].BeginTouch(fingerId);
														break;
													}
												}
											}
										}
										nextIdx = rNoteList[nextIdx].noteInfo.nextIndex;
									}
									return activeSlideList[i].firstRNoteObject.Judged(res, RhythmGameConsts.NoteJudgeType.Normal);
								}
							}
						}
					}
					return false;
				}
				return true;
			}
			else if(lineNo < 0)
			{
				return false;
			}
			else
			{
				pausingInputData[lineNo].fingerId = fingerId;
				pausingInputData[lineNo].release = false;
				return false;
			}
		}

		//// RVA: 0xDB5FF8 Offset: 0xDB5FF8 VA: 0xDB5FF8
		public void EndedTouch(int lineNo, int lineNo_Begin, int fingerId, bool forceMiss, bool checkLine = false)
		{
			if(isPause)
			{
				if(lineNo > -1)
				{
					pausingInputData[lineNo].fingerId = fingerId;
					pausingInputData[lineNo].release = true;
				}
				return;
			}
			neutralCounter[fingerId] = 0;
			for(int i = 0; i < lineTouchFingerIds.Length; i++)
			{
				if(lineTouchFingerIds[lineNo] == fingerId)
				{
					lineTouchFingerIds[lineNo] = -1;
				}
			}
			singlePool.MakeUsingList(ref activeSingleList);
			activeSingleList.Sort(SinglePoolSortTimeFunc);
			for(int i = 0; i < activeSingleList.Count; i++)
			{
				if(activeSingleList[i].touchFingerId != -1 && activeSingleList[i].touchFingerId == fingerId)
				{
					bool b = true;
					if(checkLine)
					{
						b = false;
						if (activeSingleList[i].noteObject.rNote.noteInfo.trackID == lineNo)
							b = true;
					}
					if(b && activeSingleList[i].noteObject.rNote.noteInfo.flick != MusicScoreData.FlickType.None &&
						activeSingleList[i].gameObject.activeSelf && activeSingleList[i].noteObject.rNote.noteInfo.longTouch == MusicScoreData.TouchState.None &&
						activeSingleList[i].noteObject.rNote.noteInfo.swipe == MusicScoreData.TouchState.None)
					{
						activeSingleList[i].noteObject.Judged(RhythmGameConsts.NoteResult.Miss, RhythmGameConsts.NoteJudgeType.Normal);
						return;
					}
				}
			}
			longPool.MakeUsingList(ref activeLongList);
			activeLongList.Sort(LongPoolSortLastTimeFunc);
			for(int i = 0; i < activeLongList.Count; i++)
			{
				if(activeLongList[i].touchFingerId != -1 && activeLongList[i].touchFingerId == fingerId)
				{
					if((!checkLine || activeLongList[i].lastRNoteObject.rNote.noteInfo.trackID == lineNo_Begin) && activeLongList[i].gameObject.activeSelf)
					{
						RhythmGameConsts.NoteResult res = activeLongList[i].lastRNoteObject.rNote.CalcEvaluation(evaluationOffsetMillisec[activeLongList[i].lastRNoteObject.rNote.noteInfo.trackID]);
						if (res == RhythmGameConsts.NoteResult.Exempt)
							res = RhythmGameConsts.NoteResult.Miss;
						#if !UNITY_EDITOR // UMO : disable flick on long line
						if(activeLongList[i].lastRNoteObject.rNote.noteInfo.flick != MusicScoreData.FlickType.None)
							res = RhythmGameConsts.NoteResult.Miss;
						#endif
						if(forceMiss)
							res = RhythmGameConsts.NoteResult.Miss;
						activeLongList[i].lastRNoteObject.Judged(res, RhythmGameConsts.NoteJudgeType.Normal);
						return;
					}
				}
			}
			slidePool.MakeUsingList(ref activeSlideList);
			activeSlideList.Sort(LongPoolSortLastTimeFunc);
			for(int i = 0; i < activeSlideList.Count; i++)
			{
				if(activeSlideList[i].touchFingerId != -1 && activeSlideList[i].touchFingerId == fingerId && !activeSlideList[i].IsPauseKeep)
				{
					if(activeSlideList[i].gameObject.activeSelf)
					{
						RhythmGameConsts.NoteResult res = RhythmGameConsts.NoteResult.Miss;
						if (!checkLine || activeSlideList[i].lastRNoteObject.rNote.noteInfo.trackID == lineNo)
						{
							if(activeSlideList[i].lastRNoteObject.rNote.noteInfo.longTouch == MusicScoreData.TouchState.End)
							{
								res = activeSlideList[i].lastRNoteObject.rNote.CalcEvaluation(evaluationOffsetMillisec[activeSlideList[i].lastRNoteObject.rNote.noteInfo.trackID]);
							}
						}
						if (res == RhythmGameConsts.NoteResult.Exempt)
							res = RhythmGameConsts.NoteResult.Miss;
						if (activeSlideList[i].lastRNoteObject.rNote.noteInfo.flick != MusicScoreData.FlickType.None)
							res = RhythmGameConsts.NoteResult.Miss;
						if (forceMiss)
							res = RhythmGameConsts.NoteResult.Miss;
						activeSlideList[i].lastRNoteObject.Judged(res, RhythmGameConsts.NoteJudgeType.EndedTouch);
						if (res != RhythmGameConsts.NoteResult.Miss)
							return;
						int nextIdx = activeSlideList[i].firstRNoteObject.rNote.noteInfo.nextIndex;
						while(nextIdx != 0)
						{
							if(rNoteList[nextIdx].noteInfo.isSlide)
							{
								for(int j = 0; j < activeSlideList.Count; j++)
								{
									if(rNoteList[nextIdx].noteInfo.thisIndex == activeSlideList[j].firstRNoteObject.rNote.noteInfo.nextIndex ||
										rNoteList[nextIdx].noteInfo.thisIndex == activeSlideList[j].lastRNoteObject.rNote.noteInfo.nextIndex)
									{
										if (rNoteList[nextIdx].result == RhythmGameConsts.NoteResult.None)
											activeSlideList[j].StopAnimation();
									}
								}
							}
							nextIdx = rNoteList[nextIdx].noteInfo.nextIndex;
						}
					}
				}
			}
		}

		//// RVA: 0xDB9A9C Offset: 0xDB9A9C VA: 0xDB9A9C
		public void ReleaseLine(int lineNo, int lineNo_Begin, int fingerId, bool forceMiss, bool checkLine = false)
		{
			if (IsSlideBeganTouched(lineNo))
				EndedTouch(lineNo, lineNo_Begin, fingerId, forceMiss, checkLine);
		}

		//// RVA: 0xDB9BDC Offset: 0xDB9BDC VA: 0xDB9BDC
		public void NextLine(int lineNo0, int lineNo1, int fingerId, bool forceMiss, bool checkLine = false)
		{
			return;
		}

		//// RVA: 0xDB9BE0 Offset: 0xDB9BE0 VA: 0xDB9BE0
		public void SwipedTouch(int lineNo, int fingerId, bool isRight, bool isDown, bool isLeft, bool isUp)
		{
			if(!isPause)
			{
				if(neutralCounter[fingerId] < 0)
				{
					bool[] flag = new bool[5];
					flag[1] = isLeft;
					flag[2] = isRight;
					flag[3] = isUp;
					flag[4] = isDown;
					singlePool.MakeUsingList(ref activeSingleList);
					activeSingleList.Sort(SinglePoolSortTimeFunc);
					for(int i = 0; i < activeSingleList.Count; i++)
					{
						if(activeSingleList[i].touchFingerId != -1 && activeSingleList[i].touchFingerId == fingerId)
						{
							if(IsSuccessFlick(activeSingleList[i].noteObject.rNote.noteInfo, flag) &&
								activeSingleList[i].noteObject.rNote.noteInfo.flick != MusicScoreData.FlickType.None && activeSingleList[i].gameObject.activeSelf && activeSingleList[i].noteObject.rNote.noteInfo.longTouch == MusicScoreData.TouchState.None &&
								activeSingleList[i].noteObject.rNote.noteInfo.swipe == MusicScoreData.TouchState.None)
							{
								RhythmGameConsts.NoteResult res = activeSingleList[i].noteObject.rNote.CalcEvaluation(evaluationOffsetMillisec[activeSingleList[i].noteObject.rNote.noteInfo.trackID]);
								activeSingleList[i].noteObject.Judged(res, RhythmGameConsts.NoteJudgeType.Normal);
								return;
							}
						}
					}
					longPool.MakeUsingList(ref activeLongList);
					activeLongList.Sort(LongPoolSortLastTimeFunc);
					for(int i = 0; i < activeLongList.Count; i++)
					{
						if(activeLongList[i].touchFingerId != -1 && activeLongList[i].touchFingerId == fingerId)
						{
							if (IsSuccessFlick(activeLongList[i].lastRNoteObject.rNote.noteInfo, flag) &&
								activeLongList[i].lastRNoteObject.rNote.noteInfo.flick != MusicScoreData.FlickType.None && 
								activeLongList[i].gameObject.activeSelf)
							{
								RhythmGameConsts.NoteResult res = activeLongList[i].lastRNoteObject.rNote.CalcEvaluation(evaluationOffsetMillisec[activeLongList[i].lastRNoteObject.rNote.noteInfo.trackID]);
								if (res != RhythmGameConsts.NoteResult.Exempt)
								{
									activeLongList[i].lastRNoteObject.Judged(res, RhythmGameConsts.NoteJudgeType.Normal);
									neutralCounter[fingerId] = 0.05f;
									return;
								}
							}
						}
					}
					slidePool.MakeUsingList(ref activeSlideList);
					activeSlideList.Sort(LongPoolSortLastTimeFunc);
					for(int i = 0; i < activeSlideList.Count; i++)
					{
						if(activeSlideList[i].touchFingerId != -1 && activeSlideList[i].touchFingerId == fingerId)
						{
							if (IsSuccessFlick(activeSlideList[i].lastRNoteObject.rNote.noteInfo, flag) &&
								activeSlideList[i].lastRNoteObject.rNote.noteInfo.flick != MusicScoreData.FlickType.None &&
								activeSlideList[i].gameObject.activeSelf &&
								activeSlideList[i].lastRNoteObject.rNote.noteInfo.trackID == lineNo)
							{
								RhythmGameConsts.NoteResult res = activeSlideList[i].lastRNoteObject.rNote.CalcEvaluation(evaluationOffsetMillisec[activeSlideList[i].lastRNoteObject.rNote.noteInfo.trackID]);
								if (res != RhythmGameConsts.NoteResult.Exempt)
								{
									activeSlideList[i].lastRNoteObject.Judged(res, RhythmGameConsts.NoteJudgeType.Normal);
									neutralCounter[fingerId] = 0.05f;
									return;
								}
							}
						}
					}
				}
			}
		}

		//// RVA: 0xDBA644 Offset: 0xDBA644 VA: 0xDBA644
		private bool IsSuccessFlick(MusicScoreData.InputNoteInfo info, bool[] flag)
		{
			bool b = flag[(int)info.flick];
			if(info.isWing)
			{
				int a = 3;
				if (RhythmGameConsts.IsWingLine(info.trackID))
					a = 4;
				b |= flag[a];
			}
			return b;
		}

		//// RVA: 0xDBA7A4 Offset: 0xDBA7A4 VA: 0xDBA7A4
		public void NeutralTouch(int lineNo, int fingerId)
		{
			if(isPause)
			{
				if(lineNo > -1)
				{
					pausingInputData[lineNo].fingerId = fingerId;
					pausingInputData[lineNo].release = false;
				}
				return;
			}
			if(neutralCounter[fingerId] >= 0)
			{
				neutralCounter[fingerId] -= Time.deltaTime;
			}
			slidePool.MakeUsingList(ref activeSlideList);
			activeSlideList.Sort(LongPoolSortFirstTimeFunc);
			for(int i = 0; i < activeSlideList.Count; i++)
			{
				if(activeSlideList[i].touchFingerId == fingerId)
				{
					if(activeSlideList[i].gameObject.activeSelf)
					{
						if(activeSlideList[i].lastRNoteObject.rNote.noteInfo.longTouch == MusicScoreData.TouchState.Continue)
						{
							if(activeSlideList[i].lastRNoteObject.rNote.noteInfo.trackID == lineNo)
							{
								if(activeSlideList[i].lastRNoteObject.rNote.gapMilliSec > -1)
								{
									RhythmGameConsts.NoteResult res = activeSlideList[i].lastRNoteObject.rNote.CalcEvaluation(evaluationOffsetMillisec[activeSlideList[i].lastRNoteObject.rNote.noteInfo.trackID]);
									if(res != RhythmGameConsts.NoteResult.Exempt)
									{
										activeSlideList[i].lastRNoteObject.Judged(RhythmGameConsts.NoteResult.Perfect, RhythmGameConsts.NoteJudgeType.Normal);
										return;
									}
								}
							}
						}
					}
				}
			}
		}

		//// RVA: 0xDBAC34 Offset: 0xDBAC34 VA: 0xDBAC34
		public void CheckInputCallback(RhythmGameInputPerformer.InputSaver inputSaver)
		{
			for(int i = 0; i < lineTouchFingerIds.Length; i++)
			{
				if(lineTouchFingerIds[i] != -1)
				{
					if(!inputSaver.IsActive(lineTouchFingerIds[i]))
					{
						lineTouchFingerIds[i] = -1;
					}
				}
			}
		}

		//// RVA: 0xDBAD54 Offset: 0xDBAD54 VA: 0xDBAD54
		private int SinglePoolSortTimeFunc(RNoteSingle a, RNoteSingle b)
		{
			return a.noteObject.rNote.noteInfo.time - b.noteObject.rNote.noteInfo.time;
		}

		//// RVA: 0xDBAE5C Offset: 0xDBAE5C VA: 0xDBAE5C
		private int LongPoolSortFirstTimeFunc(RNoteLong a, RNoteLong b)
		{
			return a.firstRNoteObject.rNote.noteInfo.time - b.firstRNoteObject.rNote.noteInfo.time;
		}

		//// RVA: 0xDBAF40 Offset: 0xDBAF40 VA: 0xDBAF40
		private int LongPoolSortLastTimeFunc(RNoteLong a, RNoteLong b)
		{
			return a.lastRNoteObject.rNote.noteInfo.time - b.lastRNoteObject.rNote.noteInfo.time;
		}

		//// RVA: 0xDBB024 Offset: 0xDBB024 VA: 0xDBB024
		public bool IsLongBeganTouched(int lineNo)
		{
			for(int i = 0; i < activeLongList.Count; i++)
			{
				if (activeLongList[i].firstRNoteObject.rNote.GetLineNo() == lineNo)
					return activeLongList[i].touchFingerId != -1;
			}
			return false;
		}

		//// RVA: 0xDB9AF4 Offset: 0xDB9AF4 VA: 0xDB9AF4
		public bool IsSlideBeganTouched(int fingerId)
		{
			for(int i = 0; i < activeSlideList.Count; i++)
			{
				if (activeSlideList[i].touchFingerId == fingerId)
					return true;
			}
			return false;
		}

		//// RVA: 0xDBB150 Offset: 0xDBB150 VA: 0xDBB150
		public RNoteSlide GetRNoteSlide(RNoteObject startNote)
		{
			slidePool.MakeUsingList(ref activeSlideList);
			for(int i = 0; i < activeSlideList.Count; i++)
			{
				if (activeSlideList[i].firstRNoteObject == startNote)
					return activeSlideList[i];
			}
			return null;
		}

		//// RVA: 0xDBB2AC Offset: 0xDBB2AC VA: 0xDBB2AC
		public bool IsLongLastEvaluation(int lineNo)
		{
			for(int i = 0; i < activeLongList.Count; i++)
			{
				if(activeLongList[i].firstRNoteObject.rNote.GetLineNo() == lineNo && activeLongList[i].touchFingerId != -1)
				{
					RhythmGameConsts.NoteResult res = activeLongList[i].lastRNoteObject.rNote.CalcEvaluation(evaluationOffsetMillisec[lineNo]);
					return res != RhythmGameConsts.NoteResult.Exempt;
				}
			}
			return false;
		}

		//// RVA: 0xDBB458 Offset: 0xDBB458 VA: 0xDBB458
		public bool IsSlideLastEvaluation(int fingerId)
		{
			for(int i = 0; i < activeSlideList.Count; i++)
			{
				if(activeSlideList[i].touchFingerId == fingerId && fingerId != -1)
				{
					if(activeSlideList[i].lastRNoteObject.rNote.noteInfo.longTouch == MusicScoreData.TouchState.End)
					{
						RhythmGameConsts.NoteResult res = activeSlideList[i].lastRNoteObject.rNote.CalcEvaluation(evaluationOffsetMillisec[activeSlideList[i].lastRNoteObject.rNote.noteInfo.trackID]);
						return res != RhythmGameConsts.NoteResult.Exempt;
					}
				}
			}
			return false;
		}

		//// RVA: 0xDBB66C Offset: 0xDBB66C VA: 0xDBB66C
		public void SetupNoteResultData(ref int[] countArray, RhythmGamePlayLogger logger)
		{
			for(int i = 1; i < rNoteList.Count; i++)
			{
				if(rNoteList[i].result < RhythmGameConsts.NoteResult.Num)
				{
					countArray[(int)rNoteList[i].result]++;
					logger.AddNoteData(new RhythmGamePlayLog.NoteData() { result = rNoteList[i].result, millisec = rNoteList[i].noteInfo.time });
				}
			}
		}

		//// RVA: 0xDBB848 Offset: 0xDBB848 VA: 0xDBB848
		public int GetExcellentResultNoteCount()
		{
			int res = 0;
			for(int i = 0; i < rNoteList.Count; i++)
			{
				res += rNoteList[i].resultEx.m_excellent ? 1 : 0;
			}
			return res;
		}

		//// RVA: 0xDBB948 Offset: 0xDBB948 VA: 0xDBB948
		//public float CalcSuccessNotesRate() { }

		//// RVA: 0xDBBA70 Offset: 0xDBBA70 VA: 0xDBBA70
		public bool IsAllPerfectResult()
		{
			for(int i = 1; i < rNoteList.Count; i++)
			{
				if (rNoteList[i].result != RhythmGameConsts.NoteResult.Perfect)
					return false;
			}
			return true;
		}

		//// RVA: 0xDBBB60 Offset: 0xDBBB60 VA: 0xDBBB60
		public void OnChangeGameMode()
		{
			singlePool.MakeUsingList(ref activeSingleList);
			for(int i = 0; i < activeSingleList.Count; i++)
			{
				activeSingleList[i].SetupSpecialType(gameMode);
			}
		}

		//// RVA: 0xDBBD00 Offset: 0xDBBD00 VA: 0xDBBD00
		private void OnModeAttrAssign(int noteIndex, KLJCBKMHKNK.HHMPIIILOLD mode, RhythmGameConsts.SpecialNoteType noteType)
		{
			rNoteList[noteIndex].SetModeAttr(mode, noteType);
			if (noteType == RhythmGameConsts.SpecialNoteType.CenterLiveSkill)
				assignedCenterLiveSkillNote = true;
		}

		//// RVA: 0xDBBDBC Offset: 0xDBBDBC VA: 0xDBBDBC
		private void OnModeItemInfoAssign(int noteIndex, KLJCBKMHKNK.HHMPIIILOLD mode, int itemId, int itemIndex)
		{
			rNoteList[noteIndex].SetModeItemInfo(mode, itemId, itemIndex);
		}

		//// RVA: 0xDBBE80 Offset: 0xDBBE80 VA: 0xDBBE80
		public int GetRareItemRandomSeed()
		{
			return specialNotesAssigner.GetRareItemRandomSeed();
		}

		//// RVA: 0xDB9A80 Offset: 0xDB9A80 VA: 0xDB9A80
		//public RhythmGameConsts.NoteResult OverwriteCheatNoteResult(RhythmGameConsts.NoteResult result, int lineNo) { }

		//// RVA: 0xDBBEAC Offset: 0xDBBEAC VA: 0xDBBEAC
		public bool CheckAllNotesEnd()
		{
			for(int i = rNoteList.Count - RhythmGameConsts.LineNum; i < rNoteList.Count; i++)
			{
				if (rNoteList[i].result == RhythmGameConsts.NoteResult.None)
					return false;
			}
			return true;
		}

		//// RVA: 0xDBC000 Offset: 0xDBC000 VA: 0xDBC000
		public string SerializeForNotesLog()
		{
			StringBuilder str = new StringBuilder(3000);
			bool comma = false;
			for(int i = 0; i < rNoteList.Count; i++)
			{
				if(rNoteList[i].result < RhythmGameConsts.NoteResult.Num)
				{
					if (comma)
						str.Append(',');
					str.Append(rNoteList[i].result);
				}
			}
			return str.ToString();
		}

		//// RVA: 0xDBC188 Offset: 0xDBC188 VA: 0xDBC188
		public RNote GetNote(int index)
		{
			return rNoteList[index];
		}

		//// RVA: 0xDBC208 Offset: 0xDBC208 VA: 0xDBC208
		public int GetNoteListNum()
		{
			return rNoteList.Count;
		}

		//// RVA: 0xDBC280 Offset: 0xDBC280 VA: 0xDBC280
		//public void UpdateObjectPool() { }
	}
}
