using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;
using XeSys;

namespace XeApp.Game.Menu
{
	public class SnsScreen : MonoBehaviour, IDisposable
	{
		public enum eSceneType
		{
			None = 0,
			Menu = 1,
			Tutorial = 2,
			Adventure = 3,
		}

		public enum eInType
		{
			None = 0,
			Entrance = 1,
			Room = 2,
			EntranceToRoom = 3,
		}

		private int m_currentRoomId; // 0x24
		private bool m_isPlayingInner; // 0x28
		private eSceneType m_sceneType; // 0x2C
		private FDDIIKBJNNA m_viewSnsData; // 0x30
		private SNSController.eObjectOrderType m_orderType; // 0x34
		private bool m_isReview; // 0x38
		private const float SNSIN_BGM_TIME = 1;
		private const float SNSOUT_BGM_TIME = 0.4f;
		private int m_prevBgmId; // 0x3C

		public SNSController layoutController { get; private set; } // 0xC
		public SNSTalkCreater talkCreater { get; private set; } // 0x10
		public bool IsPlaying { get; private set; } // 0x14
		public Action InStartCallback { get; set; } // 0x18
		public Action OutStartCallback { get; set; } // 0x1C
		public Action PhaseEndCallback { get; set; } // 0x20
		private bool IsTutorial { get { return GameManager.Instance.IsTutorial || m_isReview; } } //0x12D317C

		// RVA: 0x12D2F38 Offset: 0x12D2F38 VA: 0x12D2F38
		public static SnsScreen Create(Transform parent)
		{
			GameObject go = new GameObject("SnsScreen");
			go.transform.parent = parent;
			SnsScreen s = go.AddComponent<SnsScreen>();
			go.transform.localPosition = Vector3.zero;
			go.transform.localScale = Vector3.one;
			return s;
		}

		//// RVA: 0x12D3238 Offset: 0x12D3238 VA: 0x12D3238
		public void Initialize(int snsId = 0, bool isReview = false)
		{
			m_isReview = isReview;
			if (m_viewSnsData == null)
				m_viewSnsData = new FDDIIKBJNNA();
			if (layoutController == null)
				layoutController = new SNSController();
			if(talkCreater == null)
			{
				talkCreater = SNSTalkCreater.Create(transform.parent);
				talkCreater.snsController = layoutController;
			}
			if (snsId < 1)
				m_viewSnsData.KHEKNNFCAOI(false, IsTutorial, -1);
			else
				m_viewSnsData.KHEKNNFCAOI(snsId);
			layoutController.Initialize(m_viewSnsData, isReview);
			talkCreater.Initialize(m_viewSnsData);
		}

		// RVA: 0x12D345C Offset: 0x12D345C VA: 0x12D345C
		public void Reset()
		{
			this.StopAllCoroutinesWatched();
			IsPlaying = false;
			m_sceneType = eSceneType.None;
			m_isPlayingInner = false;
			PhaseEndCallback = null;
			OutStartCallback = null;

		}

		//// RVA: 0x12D3490 Offset: 0x12D3490 VA: 0x12D3490
		public void In(eSceneType sceneType = eSceneType.Menu, SNSController.eObjectOrderType orderType = SNSController.eObjectOrderType.Last, bool isReviewTutorial = false)
		{
			m_sceneType = sceneType;
			m_orderType = orderType;
			if (sceneType == eSceneType.Menu)
				isReviewTutorial = false;
			else
			{
				if (((int)sceneType & 0xfffffffeU) != 2)
					return;
				SetManualEnable(true);
			}
			this.StartCoroutineWatched(DefaultPhase(eInType.Entrance, 0, false, isReviewTutorial, false));
		}

		//// RVA: 0x12D36E0 Offset: 0x12D36E0 VA: 0x12D36E0
		public void InRoom(eSceneType sceneType, int roomId, SNSController.eObjectOrderType orderType = SNSController.eObjectOrderType.Last, int snsId = 0, bool isEventStory = false, bool isReview = false)
		{
			m_sceneType = sceneType;
			m_orderType = orderType;
			m_currentRoomId = roomId;
			if (sceneType == eSceneType.Menu)
				this.StartCoroutineWatched(DefaultPhase(eInType.Room, snsId, isEventStory, false, isReview));
			else if(((int)sceneType & 0xfffffffeU) == 2)
			{
				SetManualEnable(true);
				this.StartCoroutineWatched(DefaultPhase(eInType.Room, snsId, isEventStory, false, isReview));
				this.StartCoroutineWatched(Co_WaitTalkEnd());
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72A80C Offset: 0x72A80C VA: 0x72A80C
		//// RVA: 0x12D3798 Offset: 0x12D3798 VA: 0x12D3798
		private IEnumerator Co_WaitTalkEnd()
		{
			float timeWait;

			//0x12D5784
			while (!talkCreater.IsNextTalk())
				yield return null;
			yield return null;
			while (GetCurrentTalkCount() < talkCreater.GetTotalTalkCount())
				yield return null;
			timeWait = 0;
			while (timeWait < 1)
			{
				timeWait += TimeWrapper.deltaTime;
				yield return null;
			}
			talkCreater.Close();
		}

		// RVA: 0x12D3844 Offset: 0x12D3844 VA: 0x12D3844 Slot: 4
		public void Dispose()
		{
			if(talkCreater != null)
			{
				talkCreater.snsController = null;
				Destroy(talkCreater.gameObject);
				talkCreater = null;
			}
			if(layoutController != null)
			{
				layoutController.Dispose();
				layoutController = null;
			}
			Destroy(gameObject);
		}

		//// RVA: 0x12D39C4 Offset: 0x12D39C4 VA: 0x12D39C4
		//public int GetCurrentTalkIndex() { }

		//// RVA: 0x12D3A7C Offset: 0x12D3A7C VA: 0x12D3A7C
		public int GetCurrentTalkCount()
		{
			if (talkCreater != null)
				return talkCreater.GetCurrentIndex() + 1;
			return 0;
		}

		//// RVA: 0x12D3624 Offset: 0x12D3624 VA: 0x12D3624
		public void SetManualEnable(bool enable)
		{
			if (talkCreater != null)
				talkCreater.SetManualEnable(enable);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72A884 Offset: 0x72A884 VA: 0x72A884
		//// RVA: 0x12D3514 Offset: 0x12D3514 VA: 0x12D3514
		private IEnumerator DefaultPhase(SnsScreen.eInType inType, int snsId = 0, bool isEventStory = false, bool isCallTutorialEventStory = false, bool isReview = false)
		{
			//0x12D59B4
			m_isPlayingInner = true;
			IsPlaying = true;
			m_prevBgmId = SoundManager.Instance.bgmPlayer.currentBgmId;
			this.StartCoroutineWatched(ChangeBgm(1, -1));
			SNSTitleBar.eButtonType buttonType = SNSTitleBar.eButtonType.None;
			if(m_sceneType == eSceneType.Adventure)
			{
				buttonType = SNSTitleBar.eButtonType.Default;
				if (inType == eInType.Room)
					buttonType = SNSTitleBar.eButtonType.Adventure;
			}
			else if(m_sceneType == eSceneType.Tutorial)
			{
				buttonType = SNSTitleBar.eButtonType.Default;
				if (inType > eInType.None && inType <= eInType.EntranceToRoom)
					buttonType = SNSTitleBar.eButtonType.Tutorial;
			}
			else
			{
				buttonType = SNSTitleBar.eButtonType.Default;
				if(inType == eInType.Entrance)
				{
					buttonType = (SNSTitleBar.eButtonType)inType;
					if (inType != eInType.Room)
						buttonType = SNSTitleBar.eButtonType.Default;
				}
			}
			talkCreater.SceneType = m_sceneType;
			if(inType == eInType.Room)
			{
				this.StartCoroutineWatched(RoomDefault(m_currentRoomId, true, buttonType, snsId, isEventStory, isCallTutorialEventStory, isReview));
			}
			else if(inType == eInType.Entrance)
			{
				this.StartCoroutineWatched(EntranceDefault(true, buttonType, isCallTutorialEventStory));
			}
			while (m_isPlayingInner)
				yield return null;
			if (PhaseEndCallback != null)
				PhaseEndCallback();
			IsPlaying = false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72A8FC Offset: 0x72A8FC VA: 0x72A8FC
		//// RVA: 0x12D3B5C Offset: 0x12D3B5C VA: 0x12D3B5C
		private IEnumerator EntranceDefault(bool isBootAnimIn = true, SNSTitleBar.eButtonType buttonType = SNSTitleBar.eButtonType.Default, bool isReviewTutorial = false)
		{
			//0x12D5C60
			UnityEngine.Debug.LogError("EntranceDefault");
			if(m_sceneType == eSceneType.Menu)
			{
				ILLPDLODANB.MOFIPNGNNPA(ILLPDLODANB.LOEGALDKHPL.PEPILDAEIEL/*45*/, 2, false);
			}
			yield return Co.R(layoutController.LoadLayout(SNSController.eType.Entrance, transform.parent, null, isBootAnimIn, m_orderType));
			layoutController.LayoutSetup(SNSController.eType.Entrance, m_orderType);
			if(m_orderType == SNSController.eObjectOrderType.First)
			{
				talkCreater.transform.SetAsFirstSibling();
				transform.SetAsFirstSibling();
			}
			if(isBootAnimIn)
			{
				this.StartCoroutineWatched(BgmPlay());
			}
			int resultRoomId = 0;
			bool isWaitEntrance = true;
			bool isExit = false;
			layoutController.LoadEntranceImage();
			while (layoutController.IsLoadingSnsIconCache())
				yield return null;
			Action<int> roomCb = null;
			if (IsTutorial)
			{
				roomCb = (int roomId) =>
				{
					//0x12D4398
					isWaitEntrance = false;
					resultRoomId = roomId;
					TutorialRoomSelect(roomId);
				};
				this.StartCoroutineWatched(Co_RoomTutorial());
			}
			else
			{
				roomCb = (int roomId) =>
				{
					//0x12D43CC
					isWaitEntrance = false;
					resultRoomId = roomId;
				};
			}
			yield return Co.R(layoutController.SetupEntrance(() =>
			{
				//0x12D43DC
				isWaitEntrance = false;
				isExit = true;
				QuestUtility.UpdateQuestData();
				QuestUtility.FooterMenuBadge();
				GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
				BIFNGFAIEIL.HHCJCDFCLOB.DNKCCHCEPBH(true);
			}, roomCb, m_sceneType != eSceneType.Menu && ((int)m_sceneType & 0xfffffffe) == 2, buttonType));
			while (layoutController.IsPlaying())
				yield return null;
			if (InStartCallback != null && isBootAnimIn)
				InStartCallback();
			layoutController.In();
			while (isWaitEntrance)
				yield return null;
			layoutController.RemoveBackButtonEntrance();
			if(!isExit)
			{
				layoutController.EntranceOut();
				if (resultRoomId < 1)
					yield break;
				m_currentRoomId = resultRoomId;
				this.StartCoroutineWatched(RoomDefault(resultRoomId, false, m_sceneType == eSceneType.Tutorial ? SNSTitleBar.eButtonType.Tutorial : SNSTitleBar.eButtonType.Default, 0, false, isReviewTutorial, false));
			}
			else
			{
				yield return Co.R(EntranceEixtPhase());
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72A974 Offset: 0x72A974 VA: 0x72A974
		//// RVA: 0x12D3C54 Offset: 0x12D3C54 VA: 0x12D3C54
		private IEnumerator RoomDefault(int roomId, bool isBootAnimIn, SNSTitleBar.eButtonType buttonType, int snsId, bool isEventStory, bool isCallTutorialEventStory, bool isReview)
		{
			//0x12D659C
			if(m_sceneType == eSceneType.Menu)
			{
				ILLPDLODANB.MOFIPNGNNPA(ILLPDLODANB.LOEGALDKHPL.PEPILDAEIEL/*45*/, 2, false);
			}
			ILCCJNDFFOB.HHCJCDFCLOB.HGOGFPOCKFA(roomId, 0, 0);
			if(!isBootAnimIn)
			{
				GameManager.Instance.NowLoading.Show();
			}
			layoutController.LoadCharaImage(roomId);
			while (layoutController.IsLoadingSnsIconCache())
				yield return null;
			yield return Co.R(layoutController.LoadLayout(SNSController.eType.Room, transform.parent, null, isBootAnimIn, m_orderType));
			layoutController.LayoutSetup(SNSController.eType.Room, m_orderType);
			if(m_orderType == SNSController.eObjectOrderType.First)
			{
				talkCreater.transform.SetAsFirstSibling();
				transform.SetAsFirstSibling();
			}
			if(!isBootAnimIn)
			{
				GameManager.Instance.NowLoading.Hide();
			}
			else
			{
				this.StartCoroutineWatched(BgmPlay());
			}
			while (layoutController.IsPlaying())
				yield return null;
			bool isWaitRoom = true;
			bool isExit = false;
			talkCreater.Setup(() =>
			{
				//0x12D4548
				isWaitRoom = false;
				isExit = true;
				QuestUtility.UpdateQuestData();
				QuestUtility.FooterMenuBadge();
				GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
				BIFNGFAIEIL.HHCJCDFCLOB.DNKCCHCEPBH(true);
			}, () =>
			{
				//0x12D46A4
				isWaitRoom = false;
			}, roomId, buttonType, m_sceneType != eSceneType.Menu && ((int)m_sceneType & 0xfffffffe) == 2);
			if (InStartCallback != null && isBootAnimIn)
				InStartCallback();
			talkCreater.TalkStart(roomId, snsId, isEventStory, isCallTutorialEventStory, isReview);
			while(isWaitRoom)
				yield return null;
			layoutController.RemoveBackButtonRoom();
			talkCreater.TalkStop();
			if(!isExit)
			{
				layoutController.RoomOut();
				while (layoutController.IsPlaying())
					yield return null;
				this.StartCoroutineWatched(EntranceDefault(false, SNSTitleBar.eButtonType.Default, false));
			}
			else
			{
				yield return RoomExitPhase();
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72A9EC Offset: 0x72A9EC VA: 0x72A9EC
		//// RVA: 0x12D3DB8 Offset: 0x12D3DB8 VA: 0x12D3DB8
		private IEnumerator EntranceEixtPhase()
		{
			//0x12D63BC
			this.StartCoroutineWatched(ChangeBgm(0.4f, m_prevBgmId));
			layoutController.Out();
			if (OutStartCallback != null)
				OutStartCallback();
			while (layoutController.IsPlaying())
				yield return null;
			m_isPlayingInner = false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72AA64 Offset: 0x72AA64 VA: 0x72AA64
		//// RVA: 0x12D3E64 Offset: 0x12D3E64 VA: 0x12D3E64
		private IEnumerator RoomExitPhase()
		{
			//0x12D6E20
			this.StartCoroutineWatched(ChangeBgm(0.4f, m_prevBgmId));
			layoutController.Out();
			if (OutStartCallback != null)
				OutStartCallback();
			while (layoutController.IsPlaying())
				yield return null;
			m_isPlayingInner = false;
		}

		//// RVA: 0x12D3F10 Offset: 0x12D3F10 VA: 0x12D3F10
		//private SNSTitleBar.eButtonType GetTitleBarTyep(SnsScreen.eInType inType, SnsScreen.eSceneType sceneType) { }

		//// RVA: 0x12D3F60 Offset: 0x12D3F60 VA: 0x12D3F60
		//private bool IsBackButtonEmpty(SnsScreen.eSceneType sceneType) { }

		//[IteratorStateMachineAttribute] // RVA: 0x72AADC Offset: 0x72AADC VA: 0x72AADC
		//// RVA: 0x12D3F84 Offset: 0x12D3F84 VA: 0x12D3F84
		private IEnumerator ChangeBgm(float outTime, int bgmId)
		{
			//0x12D4978
			if(SoundManager.Instance.bgmPlayer.isPlaying)
			{
				SoundManager.Instance.bgmPlayer.FadeOut(outTime, () =>
				{
					//0x12D46B8
					if (bgmId == -1)
						return;
					SoundManager.Instance.bgmPlayer.ContinuousPlay(bgmId);
				});
			}
			else if(bgmId != -1)
			{
				SoundManager.Instance.bgmPlayer.ContinuousPlay(bgmId, 1);
			}
			yield break;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72AB54 Offset: 0x72AB54 VA: 0x72AB54
		//// RVA: 0x12D4058 Offset: 0x12D4058 VA: 0x12D4058
		private IEnumerator BgmPlay()
		{
			int bgmId; // 0x14
			BgmPlayer bgmPlayer; // 0x18

			//0x12D4748
			bgmId = BgmPlayer.MENU_BGM_ID_BASE + 12;
			bgmPlayer = SoundManager.Instance.bgmPlayer;
			while (bgmPlayer.isPlaying)
				yield return null;
			this.StartCoroutineWatched(ChangeBgm(0.1f, bgmId));
		}

		//// RVA: 0x12D4104 Offset: 0x12D4104 VA: 0x12D4104
		private void TutorialRoomSelect(int roomId)
		{
			BasicTutorialManager.Instance.SetInputLimit(InputLimitButton.None, null, null, TutorialPointer.Direction.Normal);
			layoutController.layoutScrollList.GetComponentInChildren<ScrollRect>(true).enabled = true;
			this.StartCoroutineWatched(Co_TalkTutorial());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72ABCC Offset: 0x72ABCC VA: 0x72ABCC
		//// RVA: 0x12D42BC Offset: 0x12D42BC VA: 0x12D42BC
		private IEnumerator Co_RoomTutorial()
		{
			BasicTutorialManager mgr;

			//0x12D4BA8
			bool isWait = false;
			mgr = BasicTutorialManager.Instance;
			isWait = true;
			mgr.ShowMessageWindow(BasicTutorialMessageId.Id_SnsStart, () =>
			{
				//0x12D4700
				isWait = false;
			}, null);
			while(isWait)
				yield return null;
			isWait = true;
			mgr.SetInputLimit(InputLimitButton.SnsRoomButton, () =>
			{
				//0x12D470C
				isWait = false;
			}, null, TutorialPointer.Direction.Normal);
			layoutController.layoutScrollList.GetComponentInChildren<ScrollRect>().enabled = false;
			while(isWait)
				yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72AC44 Offset: 0x72AC44 VA: 0x72AC44
		//// RVA: 0x12D4230 Offset: 0x12D4230 VA: 0x12D4230
		private IEnumerator Co_TalkTutorial()
		{
			BasicTutorialManager mgr; // 0x18
			int talkCount; // 0x1C
			float timeWait; // 0x20
			float tiemr; // 0x24

			//0x12D4F40
			mgr = BasicTutorialManager.Instance;
			bool isWait = false;
			talkCount = 0;
			timeWait = 0;
			tiemr = 1;
			while(!talkCreater.IsPlayingTalk)
				yield return null;
			talkCreater.PauseTalk();
			while(!talkCreater.IsNextTalk())
				yield return null;
			isWait = true;
			mgr.ShowMessageWindow(BasicTutorialMessageId.Id_RoomSelected, () =>
			{
				//0x12D4720
				isWait = false;
			}, null);
			while(isWait)
				yield return null;
			talkCreater.RestartTalk();
			while(talkCount < 4)
			{
				talkCount = GetCurrentTalkCount();
				yield return null;
			}
			talkCreater.PauseTalk();
			while(!talkCreater.IsNextTalk())
				yield return null;
			timeWait = 0;
			while(timeWait < tiemr)
			{
				tiemr += TimeWrapper.deltaTime;
				yield return null;
			}
			isWait = true;
			mgr.ShowMessageWindow(BasicTutorialMessageId.Id_Sns1, () =>
			{
				//0x12D472C
				isWait = false;
			}, null);
			while(isWait)
				yield return null;
			talkCreater.RestartTalk();
			while(talkCount < talkCreater.GetTotalTalkCount())
			{
				talkCount = GetCurrentTalkCount();
				yield return null;
			}
			talkCreater.PauseTalk();
			while(!talkCreater.IsNextTalk())
				yield return null;
			timeWait = 0;
			while(timeWait < tiemr)
			{
				tiemr += TimeWrapper.deltaTime;
				yield return null;
			}
			if(GameManager.Instance.IsTutorial)
			{
				isWait = true;
				yield return Co.R(TutorialManager.ShowTutorial(69, () =>
				{
					//0x12D4738
					isWait = false;
				}));
				while(isWait)
					yield return null;
			}
			talkCreater.Close();
		}
	}
}
