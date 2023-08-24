using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeSys;

namespace XeApp.Game.Menu
{
	public class SNSTalkCreater : MonoBehaviour
	{
		public class ViewTalk
		{
			public IMKNEDJDNGC talk; // 0x8
			public FHFEHOBCIIP chara; // 0xC
		}

		private class PageIndexGroup
		{
			public int start; // 0x8
			public int end; // 0xC

			// RVA: 0x1599968 Offset: 0x1599968 VA: 0x1599968
			public PageIndexGroup(int in_start, int in_end)
			{
				start = in_start;
				end = in_end;
			}
		}

		private FDDIIKBJNNA m_viewDataSNS; // 0xC
		private GAKAAIHLFKI m_viewDataRoom; // 0x10
		private List<ViewTalk> m_talkList = new List<ViewTalk>(); // 0x14
		private int m_currentTalkIndex; // 0x24
		private int m_unReadIndex; // 0x28
		private bool m_isReception; // 0x2C
		private int m_pageIndex; // 0x30
		private int m_pageMax; // 0x34
		private bool m_isLatestPage; // 0x38
		private int m_roomId; // 0x3C
		private bool m_isManual; // 0x40
		private Action m_tapCallback; // 0x44
		private bool m_isTap; // 0x48
		private Action m_callbackExit; // 0x4C
		private bool m_isSkip; // 0x50
		private bool m_initialized; // 0x51
		private bool m_isPause; // 0x52
		private bool m_isSaved; // 0x53
		private Coroutine m_achieveCoroutine; // 0x54
		private int m_achieveQuestId; // 0x58
		private bool m_isCallReviewTutorial; // 0x5C
		private bool m_isReview; // 0x5D
		public const int TutorialDivaId = 1;
		private Dictionary<int, PageIndexGroup> m_pageInexDict = new Dictionary<int, PageIndexGroup>(128); // 0x60
		private List<IEnumerator> m_mainPhase = new List<IEnumerator>(8); // 0x64
		private Vector3 m_startTapPos; // 0x68
		private const float TAPWAIT_DISTANCE = 16;
		private Camera m_screenCam; // 0x74

		public SNSController snsController { get; set; } // 0x18
		public bool IsPlayingTalk { get; private set; } // 0x1C
		public bool IsClose { get; private set; } // 0x1D
		public SnsScreen.eSceneType SceneType { get; set; } // 0x20
		private bool IsTutorial { get { return GameManager.Instance.IsTutorial || m_isCallReviewTutorial; } } //0x1596E74

		// RVA: 0x1596D48 Offset: 0x1596D48 VA: 0x1596D48
		public static SNSTalkCreater Create(Transform parent)
		{
			GameObject g = new GameObject("SNSTalkCreater");
			g.transform.SetParent(parent, false);
			return g.AddComponent<SNSTalkCreater>();
		}

		// RVA: 0x1596F30 Offset: 0x1596F30 VA: 0x1596F30
		private void Update()
		{
			if (m_mainPhase.Count < 1)
				return;
			if (m_mainPhase[0].MoveNext())
				return;
			m_mainPhase.RemoveAt(0);
		}

		//// RVA: 0x15970A8 Offset: 0x15970A8 VA: 0x15970A8
		public void Initialize(FDDIIKBJNNA viewSnsData)
		{
			m_viewDataSNS = viewSnsData;
			if (viewSnsData != null)
				return;
			m_viewDataSNS = new FDDIIKBJNNA();
		}

		// RVA: 0x1597128 Offset: 0x1597128 VA: 0x1597128
		public void Reset()
		{
			m_isReception = false;
			m_isManual = false;
			m_isLatestPage = false;
			m_isTap = false;
			m_isPause = false;
			m_isSkip = false;
			m_initialized = false;
			m_callbackExit = null;
			m_mainPhase.Clear();
			m_pageInexDict.Clear();
			m_talkList.Clear();
			m_roomId = 0;
			m_pageIndex = 0;
			m_pageMax = 0;
			m_currentTalkIndex = 0;
			m_unReadIndex = 0;
		}

		//// RVA: 0x1597230 Offset: 0x1597230 VA: 0x1597230
		public void TalkStart(int room_id, int snsId, bool isEventStory, bool isCallEventStoryTutorial, bool isReview)
		{
			m_isReview = isReview;
			m_isCallReviewTutorial = isCallEventStoryTutorial;
			InitializeTalk(room_id, false, snsId, isEventStory);
			if (snsController != null)
				snsController.In();
		}

		//// RVA: 0x159774C Offset: 0x159774C VA: 0x159774C
		public void TalkStop()
		{
			m_mainPhase.Clear();
			snsController.layoutScrollList.TalkOut();
		}

		//// RVA: 0x1597804 Offset: 0x1597804 VA: 0x1597804
		//public int GetCurrentIndex() { }

		//// RVA: 0x159780C Offset: 0x159780C VA: 0x159780C
		//public int GetTotalTalkCount() { }

		//// RVA: 0x159794C Offset: 0x159794C VA: 0x159794C
		public void NextTalk()
		{
			if(m_initialized && m_isManual)
			{
				if(!m_isTap)
				{
					m_isSkip = true;
				}
				else
				{
					m_isReception = true;
				}
			}
		}

		//// RVA: 0x1597980 Offset: 0x1597980 VA: 0x1597980
		//public bool IsNextTalk() { }

		//// RVA: 0x15979B0 Offset: 0x15979B0 VA: 0x15979B0
		//public void PauseTalk() { }

		//// RVA: 0x15979D0 Offset: 0x15979D0 VA: 0x15979D0
		//public void RestartTalk() { }

		//// RVA: 0x1597A70 Offset: 0x1597A70 VA: 0x1597A70
		//public void Close() { }

		//// RVA: 0x1597A84 Offset: 0x1597A84 VA: 0x1597A84
		public void SetManualEnable(bool isManual)
		{
			m_isManual = isManual;
			if (isManual)
				return;
			if (snsController.tapScreenButton != null)
			{
				snsController.tapScreenButton.ClearOnClickCallback();
				snsController.tapScreenButton.gameObject.SetActive(m_isManual);
			}
		}

		//// RVA: 0x1597BFC Offset: 0x1597BFC VA: 0x1597BFC
		private void SetupTap()
		{
			if (!m_isManual)
				return;
			if(snsController.tapScreenButton != null)
			{
				snsController.tapScreenButton.ClearOnClickCallback();
				snsController.tapScreenButton.gameObject.SetActive(m_isManual);
				m_tapCallback = NextTalk;
				snsController.tapScreenButton.AddOnClickCallback(() =>
				{
					//0x159A190
					if (m_tapCallback != null)
						m_tapCallback();
				});
			}
		}

		//// RVA: 0x1597288 Offset: 0x1597288 VA: 0x1597288
		private void InitializeTalk(int room_id, bool allText, int snsId, bool isEventStory)
		{
			GetLayoutScrollList().ResetListObject();
			if(isEventStory)
			{
				m_viewDataSNS.KHEKNNFCAOI(allText, IsTutorial, room_id);
			}
			else
			{
				if(snsId < 1)
				{
					m_viewDataSNS.KHEKNNFCAOI(allText, IsTutorial, -1);
				}
				else
				{
					m_viewDataSNS.KHEKNNFCAOI(snsId);
				}
			}
			int rid = room_id;
			m_viewDataRoom = m_viewDataSNS.NPKPBDIDBBG_RoomData.Find((GAKAAIHLFKI x) =>
			{
				//0x159A3DC
				return x.MALFHCHNEFN_Id == rid;
			});
			m_roomId = room_id;
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			m_currentTalkIndex = m_viewDataRoom.FOBEBCPEILE_GetCurrentTalkIndex(time, false, false);
			m_unReadIndex = m_viewDataRoom.MCGDHHHFBMO_GetUnreadIndex(time, false);
			CalcPageIndex();
			bool b = false;
			int idx1 = 0;
			int idx2 = -1;
			if(isEventStory)
			{
				idx1 = m_currentTalkIndex;
				idx2 = m_viewDataRoom.CNEOPOINCBA.FindIndex((IMKNEDJDNGC x) =>
				{
					//0x159A414
					return x.AIPLIEMLHGC == snsId;
				});
				if(!m_viewDataRoom.CNEOPOINCBA[idx2].GAIEHFCHAOK)
				{
					int p = GetPageCountByIndex(m_currentTalkIndex);
					m_currentTalkIndex = idx2;
					idx2 = GetPageCountByIndex(idx2);
					m_unReadIndex = -1;
					b = p <= idx2;
				}
				else
				{
					idx1 = m_unReadIndex;
					idx2 = -1;
					b = true;
				}
			}
			else
			{
				if(GetUnreadIndex() > -1)
				{
					idx1 = m_unReadIndex;
				}
				else
				{
					m_unReadIndex = -1;
					idx1 = m_currentTalkIndex;
				}
				idx2 = -1;
				b = true;
			}
			idx1 = GetPageCountByIndex(idx1);
			m_pageIndex = idx1;
			m_pageMax = m_pageIndex + 1;
			if (idx2 > -1)
				m_pageIndex = idx2;
			ResetPage(b);
			SetupTapRect();
			SetupTap();
			m_isSkip = false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72B05C Offset: 0x72B05C VA: 0x72B05C
		//// RVA: 0x15985A8 Offset: 0x15985A8 VA: 0x15985A8
		private IEnumerator UpdateWaitTalk()
		{
			IEnumerator rnt;

			//0x159C740
			rnt = null;
			while (true)
			{
				if (!m_isPause)
					yield return null;
				rnt = ReceptionNewTalk();
				if(rnt != null)
				{
					while(rnt.MoveNext())
					{
						UpdateTapSkip();
						yield return null;
					}
				}
				else
				{
					yield return null;
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72B0D4 Offset: 0x72B0D4 VA: 0x72B0D4
		//// RVA: 0x1598654 Offset: 0x1598654 VA: 0x1598654
		private IEnumerator ReceptionNewTalk()
		{
			int realCount; // 0x1C
			float wait; // 0x20
			ViewTalk talk; // 0x24
			LayoutSNSScrollList scrollList; // 0x28
			SnsItemObject snsScrollObject; // 0x2C

			//0x159A6D8
			if (!m_isReception)
				yield break;
			m_isTap = false;
			realCount = GetReadMessageCount();
			if (!m_pageInexDict.ContainsKey(m_pageIndex))
				yield break;
			if(m_pageInexDict[m_pageIndex].end <= realCount)
			{
				IsClose = true;
				m_isReception = false;
				yield break;
			}
			wait = 0;
			while(wait < m_viewDataRoom.CNEOPOINCBA[realCount].FMDCAFCHBJH_Offset && !m_isSkip)
			{
				wait += TimeWrapper.deltaTime;
				yield return null;
			}
			m_viewDataRoom.CNEOPOINCBA[realCount].GAIEHFCHAOK = false;
			m_currentTalkIndex = realCount;
			realCount++;
			m_isReception = false;
			if(!m_isLatestPage)
			{
				if(GetUnreadIndex() < 0)
				{
					snsController.layoutFooter.WritingOut();
					yield break;
				}
				m_isReception = true;
				m_isSkip = false;
				m_isTap = true;
				if (realCount < m_pageInexDict[m_pageIndex].end)
					yield break;
				m_isReception = false;
				m_isTap = true;
				yield break;
			}
			talk = RegisterViewTalk(m_currentTalkIndex);
			if(talk.chara.IDELKEKDIFD_CharaId > 0)
			{
				snsController.SNSInputDisable();
				GameManager.Instance.SnsIconCache.CharIconLoad(talk.chara.IDELKEKDIFD_CharaId, (IiconTexture texture) =>
				{
					//0x159A3A4
					return;
				});
				while (GameManager.Instance.SnsIconCache.IsLoading())
					yield return null;
				snsController.SNSInputEnable();
			}
			scrollList = GetLayoutScrollList();
			int diva = GameManager.Instance.GetHomeDiva().AHHJLDLAPAN_DivaId;
			if (IsTutorial)
				diva = 1;
			snsScrollObject = scrollList.SetStatusTalk(talk, diva, GetPageMsgCount(m_pageIndex));
			int a = 0;
			if(scrollList.GetListCount() - 1 > -1)
			{
				a = scrollList.GetListCount() - 1;
			}
			snsController.layoutFooter.WritingOut();
			if (scrollList.IsCheckRange(a, false))
			{
				IsPlayingTalk = true;
				snsController.SNSInputDisable();
				yield return null;
				snsScrollObject.animType = SnsItemObject.eAnimType.In;
				bool isWaitFocus = true;
				scrollList.TalkIn(() =>
				{
					//0x159A454
					isWaitFocus = false;
				});
				while (isWaitFocus)
					yield return null;
				snsController.SNSInputEnable();
				IsPlayingTalk = false;
			}
			//LAB_0159afe8
			if(GetUnreadIndex() > -1 && !m_isPause)
			{
				snsController.layoutFooter.WritingIn();
			}
			UpdatePage();
			m_isReception = true;
			m_isSkip = false;
			m_isTap = true;
			if (realCount < m_pageInexDict[m_pageIndex].end)
				yield break;
			m_isReception = false;
			m_isTap = true;
			if(GetPageMsgCount(m_pageIndex) == 1)
			{
				snsController.layoutFooter.SetIconHyphen();
				yield break;
			}
			snsController.layoutFooter.SetIconEnd(true);
			UpdateAllRead(false, false);
			if(!IsTutorial)
			{
				m_achieveCoroutine = this.StartCoroutineWatched(ShowPopupAchieve(() =>
				{
					//0x159A1A4
					m_achieveCoroutine = null;
				}));
			}
			if (IsTutorial)
				yield break;
			if (!m_pageInexDict.ContainsKey(m_pageIndex + 1))
				yield break;
			snsScrollObject = null;
			if(m_viewDataRoom.IHCEJBAEEDO != 0)
			{
				snsScrollObject = scrollList.SetNextPageButton();
			}
			a = 0;
			if(scrollList.GetListCount() - 1 > -1)
			{
				a = scrollList.GetListCount() - 1;
			}
			if(scrollList.IsCheckRange(a, false))
			{
				IsPlayingTalk = true;
				yield return null;
				if (snsScrollObject != null)
					snsScrollObject.animType = SnsItemObject.eAnimType.In;
				bool isWaitFocus = true;
				scrollList.TalkIn(() =>
				{
					//0x159A468
					isWaitFocus = false;
				});
				while (isWaitFocus)
					yield return null;
				IsPlayingTalk = false;
			}
		}

		//// RVA: 0x1598700 Offset: 0x1598700 VA: 0x1598700
		private ViewTalk RegisterViewTalk(int index)
		{
			ViewTalk res = new ViewTalk();
			res.talk = m_viewDataRoom.CNEOPOINCBA[index];
			res.chara = m_viewDataSNS.KHCACDIKJLG[m_viewDataRoom.CNEOPOINCBA[index].IDELKEKDIFD_CharaId - 1];
			m_talkList.Add(res);
			return res;
		}

		//// RVA: 0x15988AC Offset: 0x15988AC VA: 0x15988AC
		private void UpdatePage()
		{
			m_currentTalkIndex = GetReadMessageCount();
			m_isLatestPage = m_pageMax - 1 == m_pageIndex;
			snsController.layoutTitleBar.SetLogButton(m_pageIndex, m_pageMax);
		}

		//// RVA: 0x15982CC Offset: 0x15982CC VA: 0x15982CC
		private void ResetPage(bool isLatestPage = false)
		{
			snsController.layoutFooter.SetIconNone();
			snsController.SNSInputDisable();
			this.StartCoroutineWatched(ResetPageInner(isLatestPage, true, () =>
			{
				//0x159A1B0
				snsController.SNSInputEnable();
				m_mainPhase.Add(UpdateWaitTalk());
				int unread = GetUnreadIndex();
				if (unread < 0)
					snsController.layoutFooter.SetIconEnd(false);
				else
					snsController.layoutFooter.WritingWait();
				int msgCount = GetPageMsgCount(m_pageIndex);
				if(msgCount < 2)
				{
					snsController.layoutFooter.SetIconHyphen();
				}
				m_isReception = true;
				m_isTap = true;
				m_initialized = true;
			}));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72B14C Offset: 0x72B14C VA: 0x72B14C
		//// RVA: 0x1598B8C Offset: 0x1598B8C VA: 0x1598B8C
		private IEnumerator ResetPageInner(bool isLatestPage, bool isUpdateAllRead, Action callback)
		{
			//0x159B5D8
			m_mainPhase.Clear();
			UpdatePage();
			int start, end;
			GetPageIndex(m_pageIndex, out start, out end);
			if (m_currentTalkIndex < end)
				end = m_currentTalkIndex;
			m_talkList.Clear();
			for(int i = start; i < end; i++)
			{
				RegisterViewTalk(i);
			}
			int divaId = GameManager.Instance.GetHomeDiva().AHHJLDLAPAN_DivaId;
			if (IsTutorial)
				divaId = 1;
			bool setupTalkStatus = false;
			GetLayoutScrollList().SetStatusTalk(m_talkList, divaId, GetUnReadIndexValue(), () =>
			{
				//0x159A47C
				setupTalkStatus = true;
			}, !isLatestPage && m_viewDataRoom.IHCEJBAEEDO != 0);
			while (!setupTalkStatus)
				yield return null;
			while (snsController.IsPlaying())
				yield return null;
			if(isUpdateAllRead && !IsTutorial)
			{
				UpdateAllRead(!IsTutorial, false);
				while(m_isSaved)
					yield return null;
			}
			if (callback != null)
				callback();
		}

		//// RVA: 0x1598C84 Offset: 0x1598C84 VA: 0x1598C84
		public void NextPage()
		{
			if (m_pageMax - 1 <= m_pageIndex)
				return;
			m_pageIndex++;
			ResetPage(!m_pageInexDict.ContainsKey(m_pageIndex + 1));
		}

		//// RVA: 0x1598D28 Offset: 0x1598D28 VA: 0x1598D28
		//public void PrevPage() { }

		//// RVA: 0x1598D44 Offset: 0x1598D44 VA: 0x1598D44
		//public void LatestPage() { }

		//// RVA: 0x1598D58 Offset: 0x1598D58 VA: 0x1598D58
		public void UnreadPage()
		{
			if (!m_pageInexDict.ContainsKey(m_pageIndex + 1))
				return;
			UpdateAllRead(false, false);
			if (m_pageMax <= m_pageIndex + 1)
			{
				if (m_pageInexDict.ContainsKey(m_pageMax))
				{
					m_pageIndex = m_pageMax;
					m_pageMax++;
					ResetPage(true);
					return;
				}
			}
			NextPage();
		}

		//// RVA: 0x1598E64 Offset: 0x1598E64 VA: 0x1598E64
		public void UpdateAllRead(bool isSnsCheck = false, bool isReadMessage = false)
		{
			if (isReadMessage)
				ReadMessage();
			if(!m_isSaved)
			{
				m_isSaved = true;
				int start, end;
				GetPageIndex(m_pageIndex, out start, out end);
				for(int i = start; i < end; i++)
				{
					m_viewDataRoom.CNEOPOINCBA[i].FCFDHFAJKPB();
				}
				if (isSnsCheck)
					CheckSNSQuest();
				MenuScene.Save(() =>
				{
					//0x159A31C
					m_isSaved = false;
				}, null);
			}
		}

		//// RVA: 0x1599014 Offset: 0x1599014 VA: 0x1599014
		private void ReadMessage()
		{
			int start, end;
			GetPageIndex(m_pageIndex, out start, out end);
			for(int i = start; i < end; i++)
			{
				m_viewDataRoom.CNEOPOINCBA[i].GAIEHFCHAOK = false;
			}
		}

		//// RVA: 0x159932C Offset: 0x159932C VA: 0x159932C
		private int GetUnReadIndexValue()
		{
			int res = 0;
			for(int i = 0; i < m_talkList.Count; i++)
			{
				if (m_talkList[i].talk.EDCBHGECEBE)
					res = i;
				if (m_talkList[i].talk.GAIEHFCHAOK)
					return res;
			}
			return -1;
		}

		//// RVA: 0x1597E30 Offset: 0x1597E30 VA: 0x1597E30
		private LayoutSNSScrollList GetLayoutScrollList()
		{
			if(snsController != null)
			{
				if (snsController.layoutScrollList != null)
					return snsController.layoutScrollList;
			}
			return null;
		}

		//// RVA: 0x1599494 Offset: 0x1599494 VA: 0x1599494
		public void Setup(Action exitCallback, Action returnCallback, int roomId, SNSTitleBar.eButtonType buttonType, bool isBackButtonEmpty)
		{
			if (m_isManual)
				m_callbackExit = exitCallback;
			if(snsController != null)
			{
				if(snsController.layoutTitleBar != null)
				{
					snsController.SetupRoom(roomId, () =>
					{
						//0x159A488
						if(m_achieveCoroutine != null)
						{
							this.StopCoroutineWatched(m_achieveCoroutine);
							m_achieveCoroutine = null;
						}
						UpdateAllRead(true, true);
						exitCallback();
					}, () =>
					{
						//0x159A510
						if(m_achieveCoroutine != null)
						{
							this.StopCoroutineWatched(m_achieveCoroutine);
							m_achieveCoroutine = null;
						}
						UpdateAllRead(true, true);
						returnCallback();
					}, () =>
					{
						//0x159A598
						m_pageIndex = m_pageMax - 1;
						ResetPage(true);
					}, () =>
					{
						//0x159A5D0
						if(m_achieveCoroutine != null)
						{
							this.StopCoroutineWatched(m_achieveCoroutine);
							m_achieveCoroutine = null;
						}
						UpdateAllRead(true, true);
						if (m_pageIndex < 1)
							return;
						m_pageIndex--;
						ResetPage(false);
					}, () =>
					{
						//0x159A66C
						NextPage();
					}, buttonType, isBackButtonEmpty);
				}
				if(snsController.layoutNextButton != null)
				{
					snsController.layoutNextButton.CallbackButton = () =>
					{
						//0x159A694
						UnreadPage();
					};
				}
			}
		}

		//// RVA: 0x1597F00 Offset: 0x1597F00 VA: 0x1597F00
		private void CalcPageIndex()
		{
			m_pageInexDict.Clear();
			int end = m_viewDataRoom.CNEOPOINCBA.Count;
			int start = 0;
			int page = 0;
			bool b = false;
			for(int i = 0; i < end; i++)
			{
				if(m_viewDataRoom.CNEOPOINCBA[i].EDCBHGECEBE && !b)
				{
					b = true;
					start = i;
				}
				else
				{
					if(b && m_viewDataRoom.CNEOPOINCBA[i].EDCBHGECEBE)
					{
						SetPageIndex(page, start, i);
						page++;
						start = i;
					}
				}
			}
			if(start != end)
			{
				SetPageIndex(page, start, end);
			}
		}

		//// RVA: 0x15997EC Offset: 0x15997EC VA: 0x15997EC
		private void SetPageIndex(int page, int start, int end)
		{
			if (!m_pageInexDict.ContainsKey(page))
			{
				m_pageInexDict.Add(page, new PageIndexGroup(start, end));
			}
			else
			{
				m_pageInexDict[page].start = start;
				m_pageInexDict[page].end = end;
			}
		}

		//// RVA: 0x1599100 Offset: 0x1599100 VA: 0x1599100
		private bool GetPageIndex(int page, out int start, out int end)
		{
			start = 0;
			end = 0;
			bool b = false;
			if(m_pageInexDict.ContainsKey(page))
			{
				start = m_pageInexDict[page].start;
				end = m_pageInexDict[page].end;
				b = true;
			}
			return b;
		}

		//// RVA: 0x15980C4 Offset: 0x15980C4 VA: 0x15980C4
		private int GetPageCountByIndex(int index)
		{
			int cnt = 0;
			foreach(var k in m_pageInexDict)
			{
				if (index >= k.Value.start && index < k.Value.end)
					return cnt;
				cnt++;
			}
			if (cnt > 0)
				return cnt - 1;
			return 0;
		}

		//// RVA: 0x1597A50 Offset: 0x1597A50 VA: 0x1597A50
		//public bool IsUnreadMessage() { }

		//// RVA: 0x1599990 Offset: 0x1599990 VA: 0x1599990
		private int GetUnreadIndex()
		{
			int start, end;
			GetPageIndex(m_pageIndex, out start, out end);
			for(int i = start; i < end; i++)
			{
				if (m_viewDataRoom.CNEOPOINCBA[i].GAIEHFCHAOK)
					return i;
			}
			return -1;
		}

		//// RVA: 0x159892C Offset: 0x159892C VA: 0x159892C
		private int GetReadMessageCount()
		{
			return m_viewDataRoom.CNEOPOINCBA.FindAll((IMKNEDJDNGC _) =>
			{
				//0x159A3A8
				return _.GAIEHFCHAOK == false;
			}).Count;
		}

		//// RVA: 0x1599A94 Offset: 0x1599A94 VA: 0x1599A94
		private int GetPageMsgCount(int page = -1)
		{
			if (page == -1)
				page = m_pageMax - 1;
			int start, end;
			GetPageIndex(page, out start, out end);
			if (end - start > 0)
				return end - start;
			return 0;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72B1C4 Offset: 0x72B1C4 VA: 0x72B1C4
		//// RVA: 0x1599AE4 Offset: 0x1599AE4 VA: 0x1599AE4
		private IEnumerator ShowPopupAchieve(Action finish)
		{
			GameManager.PushBackButtonHandler dummyCallback; // 0x1C
			float wait; // 0x20
			float waitTime; // 0x24
			bool prevScrollEnable; // 0x28

			//0x159BAE4
			if(m_achieveQuestId > 0)
			{
				TodoLogger.LogError(0, "ShowPopupAchieve");
				yield return null;
			}
			if (finish != null)
				finish();
		}

		//// RVA: 0x1599BAC Offset: 0x1599BAC VA: 0x1599BAC
		//private void StopShowPopupAchieve() { }

		//// RVA: 0x159923C Offset: 0x159923C VA: 0x159923C
		private void CheckSNSQuest()
		{
			if (IsTutorial)
				return;
			m_achieveQuestId = 0;
			if (!ILLPDLODANB.OHFOAIDPDEM(m_roomId, out m_achieveQuestId))
				return;
			ILLPDLODANB.CIEDCPPINCB(m_achieveQuestId, 2);
		}

		//// RVA: 0x1599BDC Offset: 0x1599BDC VA: 0x1599BDC
		private void UpdateTapSkip()
		{
			if(!m_isManual && m_initialized)
			{
				TouchInfoRecord rec = InputManager.Instance.GetFirstInScreenTouchRecord();
				if(rec != null)
				{
					if(rec.currentInfo.isBegan)
					{
						if(IsTapRect(rec.currentInfo.nativePosition))
						{
							m_startTapPos = rec.currentInfo.nativePosition;
							return;
						}
					}
					if(rec.currentInfo.isEnded)
					{
						if (IsTapRect(rec.currentInfo.nativePosition))
						{
							if (Vector3.Distance(m_startTapPos, rec.currentInfo.nativePosition) < 16)
								m_isSkip = true;
						}
					}
				}
			}
		}

		//// RVA: 0x15983E0 Offset: 0x15983E0 VA: 0x15983E0
		private void SetupTapRect()
		{
			m_screenCam = GameManager.Instance.transform.Find("SystemCanvasCamera").GetComponent<Camera>();
			if (snsController == null)
				return;
			if (snsController.tapScreenRect == null)
				return;
			snsController.tapScreenRect.gameObject.SetActive(true);
		}

		//// RVA: 0x1599E88 Offset: 0x1599E88 VA: 0x1599E88
		private bool IsTapRect(Vector3 nativaPosition)
		{
			if(m_screenCam != null)
			{
				if(snsController.tapScreenRect != null)
				{
					return RectTransformUtility.RectangleContainsScreenPoint(snsController.tapScreenRect, nativaPosition, m_screenCam);
				}
			}
			return false;
		}

		//[CompilerGeneratedAttribute] // RVA: 0x72B23C Offset: 0x72B23C VA: 0x72B23C
		//// RVA: 0x159A158 Offset: 0x159A158 VA: 0x159A158
		//private bool <GetTotalTalkCount>b__52_0(GAKAAIHLFKI _) { }
		
		//[CompilerGeneratedAttribute] // RVA: 0x72B25C Offset: 0x72B25C VA: 0x72B25C
		//// RVA: 0x159A1A4 Offset: 0x159A1A4 VA: 0x159A1A4
		//private void <ReceptionNewTalk>b__62_1() { }
	}
}
