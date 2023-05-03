using System;
using System.Collections.Generic;
using System.Diagnostics;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class MenuDivaTalk
	{
		public delegate void OnChangedMessage(string msgLabel);

		private static readonly float s_autoTalkInterval = 10.0f; // 0x0
		private static readonly int s_autoTalkBasicWeight = 10; // 0x4
		private static readonly int s_autoTalkLimitedWeight = s_autoTalkBasicWeight; // 0x8
		private static readonly int s_autoTalkBirthdayWeight = s_autoTalkBasicWeight; // 0xC
		private List<NJOOMLFFIJB> m_limitedTalkData = new List<NJOOMLFFIJB>(); // 0x10
		private List<int> m_limitedTalkIndex = new List<int>(); // 0x14
		private NJOOMLFFIJB m_birthdayTalkData; // 0x18
		private int m_birthdayTalkIndex = -1; // 0x1C
		private int m_prevAutoTalkIndex = -1; // 0x20
		private List<int> m_autoTalkWeights; // 0x24
		private Stopwatch m_autoTalkWatch = new Stopwatch(); // 0x28
		private int m_prevReactionIndex = -1; // 0x2C
		private List<int> m_reactionWeights; // 0x30
		private long m_loginTime; // 0x38
		private HomeDivaControl m_divaControl; // 0x40

		public JJOELIOGMKK_DivaIntimacyInfo viewIntimacyData { private get; set; }  // 0x8
		public OnChangedMessage onChangedMessage { private get; set; } // 0xC
		private MenuDivaManager divaManager { get { return MenuScene.Instance.divaManager; } } //0xECD720
		private ILDKBCLAFPB saveManager { get { return GameManager.Instance.localSave; } } //0xECD7BC
		private ILDKBCLAFPB.BKLCILHFCGB_Flags talkFlags { get { return saveManager.EPJOACOONAC_GetSave().NDOKECOAPML_Login.LDCMANMNAHC_HomeTalkFlags; } } //0xECD858

		// RVA: 0xECD8B4 Offset: 0xECD8B4 VA: 0xECD8B4
		public static void ClearHomeTalkFlags()
		{
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().NDOKECOAPML_Login.LDCMANMNAHC_HomeTalkFlags.JCHLONCMPAJ_Clear();
		}

		// // RVA: 0xECD9B8 Offset: 0xECD9B8 VA: 0xECD9B8
		public MenuDivaTalk(int divaId, HomeDivaControl divaControl)
		{
			List<NJOOMLFFIJB> talkDataList = NJOOMLFFIJB.FKDIMODKKJD(divaId);
			m_divaControl = divaControl;
			m_autoTalkWeights = new List<int>();
			MenuDivaVoiceTable voiceTable = divaControl.VoiceTable;
			for (int i = 0; i < voiceTable.GetList_TimeTalk().Count; i++)
			{
				m_autoTalkWeights.Add(s_autoTalkBasicWeight);
			}
			m_limitedTalkData.Clear();
			m_limitedTalkIndex.Clear();
			for(int i = 0; i < talkDataList.Count; i++)
			{
				if(talkDataList[i].NEJBNCHLMNJ_Type == NJOOMLFFIJB.LGAJNFGABFK.AJGKPBOPIJI_Limited)
				{
					m_limitedTalkData.Add(talkDataList[i]);
					m_limitedTalkIndex.Add(m_autoTalkWeights.Count);
					m_autoTalkWeights.Add(s_autoTalkLimitedWeight);
				}
			}
			NJOOMLFFIJB data = talkDataList.Find((NJOOMLFFIJB _) =>
			{
				//0xED07B8
				return _.NEJBNCHLMNJ_Type == NJOOMLFFIJB.LGAJNFGABFK.DDAFHPDFFPI_Brithday;
			});
			m_birthdayTalkData = data;
			m_birthdayTalkIndex = m_autoTalkWeights.Count;
			m_autoTalkWeights.Add(m_birthdayTalkData == null ? 0 : s_autoTalkBirthdayWeight);
			m_reactionWeights = new List<int>(divaManager.ReactionWeights);
			TimerStop();
		}

		// // RVA: 0xECE0C4 Offset: 0xECE0C4 VA: 0xECE0C4
		public void TimerStart()
		{
			m_autoTalkWatch.Start();
		}

		// // RVA: 0xECE098 Offset: 0xECE098 VA: 0xECE098
		public void TimerStop()
		{
			m_autoTalkWatch.Stop();
		}

		// // RVA: 0xECE0F0 Offset: 0xECE0F0 VA: 0xECE0F0
		public void TimerRestart()
		{
			m_autoTalkWatch.Reset();
			m_autoTalkWatch.Start();
		}

		// // RVA: 0xECE140 Offset: 0xECE140 VA: 0xECE140
		// public bool IsTimerRunning() { }

		// // RVA: 0xECE16C Offset: 0xECE16C VA: 0xECE16C
		public void SetLoginTime(long unixtime)
		{
			m_loginTime = unixtime;
		}

		// // RVA: 0xECE17C Offset: 0xECE17C VA: 0xECE17C
		public bool IsDownLoading()
		{
			return KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning;
		}

		// // RVA: 0xECE218 Offset: 0xECE218 VA: 0xECE218
		public void RequestDelayDownLoad()
		{
			for(int i = 0; i < m_limitedTalkData.Count; i++)
			{
				m_divaControl.RequestDelayDownLoad(m_limitedTalkData[i].NKCNHKHGJHN_TalkType);
			}
		}

		// // RVA: 0xECE310 Offset: 0xECE310 VA: 0xECE310
		public void DoIntroTalk(bool resetTalkFlags = false)
		{
			DateTime d1 = Utility.GetLocalDateTime(CIOECGOMILE.HHCJCDFCLOB.PKBOFLOJNIJ);
			DateTime d2 = Utility.GetLocalDateTime(m_loginTime);
			if(d1.DayOfYear != d2.DayOfYear || resetTalkFlags)
			{
				talkFlags.JCHLONCMPAJ_Clear();
			}
			if (CheckBirthdayTalk(false))
				RequestBirthdayTalk();
			else if (CheckLimitedTalk(false))
				RequestLimitedTalk(-1);
			else
				RequestTimezoneTalk();
			if(!m_divaControl.IsActionRequested)
			{
				DoAutoTalk();
			}
			saveManager.HJMKBCFJOOH_TrySave();
		}

		// // RVA: 0xECEF14 Offset: 0xECEF14 VA: 0xECEF14
		public bool IsEnableReaction()
		{
			if(m_divaControl != null)
				return !m_divaControl.IsActionRequested;
			return false;
		}

		// // RVA: 0xECEF3C Offset: 0xECEF3C VA: 0xECEF3C
		// public int RandomTouchReactionIndex() { }

		// // RVA: 0xECF3C4 Offset: 0xECF3C4 VA: 0xECF3C4
		// public void DoTouchReaction() { }

		// // RVA: 0xECF740 Offset: 0xECF740 VA: 0xECF740
		// public void DoPresentReaction(int a_idnex = -1, MenuDivaTalk.OnChangedMessage a_callback_msg) { }

		// // RVA: 0xECF84C Offset: 0xECF84C VA: 0xECF84C
		// public void DoIntimacyReaction(MenuDivaTalk.OnChangedMessage a_callback_msg) { }

		// // RVA: 0xECF978 Offset: 0xECF978 VA: 0xECF978
		public void CancelRequest()
		{
			m_divaControl.CancelRequest();
		}

		// // RVA: 0xECF9A4 Offset: 0xECF9A4 VA: 0xECF9A4
		public void Update()
		{
			if(m_autoTalkWatch.IsRunning)
			{
				if(!PopupWindowManager.IsActivePopupWindow())
				{
					if(m_divaControl.IsActionRequested)
					{
						m_autoTalkWatch.Reset();
						m_autoTalkWatch.Start();
					}
					else
					{
						if (m_autoTalkWatch.Elapsed.TotalSeconds >= s_autoTalkInterval)
							DoAutoTalk();
					}
				}
			}
		}

		// // RVA: 0xECEBE4 Offset: 0xECEBE4 VA: 0xECEBE4
		private void DoAutoTalk()
		{
			TodoLogger.Log(0, "DoAutoTalk");
			m_autoTalkWatch.Reset();
			m_autoTalkWatch.Start();
		}

		// // RVA: 0xECE9F8 Offset: 0xECE9F8 VA: 0xECE9F8
		private void RequestTimezoneTalk()
		{
			bool isOverDay = false;
			DivaTimezoneTalk.Type talkType = DivaTimezoneTalk.GetByUnixTime(m_loginTime, out isOverDay);
			int idx = -1;
			if (talkType <= DivaTimezoneTalk.Type.Midnight)
			{
				idx = 3;
				switch (talkType)
				{
					case DivaTimezoneTalk.Type.Noon:
						idx = 4;
						break;
					case DivaTimezoneTalk.Type.Evening:
						idx = 5;
						break;
					case DivaTimezoneTalk.Type.Night:
						idx = 6;
						break;
					case DivaTimezoneTalk.Type.Midnight:
						idx = 8;
						if (!isOverDay)
							idx = 7;
						break;
				}
			}
			if(!talkFlags.ODKIHPBEOEC_IsTrue(idx))
			{
				if(m_divaControl.RequestTimezoneTalk((int)talkType, OnTalkActionEnd))
				{
					DivaTalk("talk_login_{0:D2}", (int)talkType + 1, null);
					TimerStop();
					talkFlags.EDEDFDDIOKO_SetTrue(idx);
				}
			}
		}

		// // RVA: 0xECFC70 Offset: 0xECFC70 VA: 0xECFC70
		// private void RequestComebackTalk() { }

		// // RVA: 0xECE7B4 Offset: 0xECE7B4 VA: 0xECE7B4
		private void RequestLimitedTalk(int index)
		{
			if(index == -1)
			{
				long t = -1;
				int fnd = -1;
				for(int i = 0; i < m_limitedTalkData.Count; i++)
				{
					if(t < m_limitedTalkData[i].KJBGCLPMLCG_StartAt)
					{
						t = m_limitedTalkData[i].KJBGCLPMLCG_StartAt;
						fnd = i;
					}
				}
				index = fnd;
				if (index < 1)
					index = 0;
			}
			if(m_divaControl.RequestLimitedTalk(m_limitedTalkData[index].NKCNHKHGJHN_TalkType, OnTalkActionEnd))
			{
				DivaTalk("talk_event_{0:D2}", m_limitedTalkData[index].NKCNHKHGJHN_TalkType, null);
				TimerStop();
			}
		}

		// // RVA: 0xECE5C4 Offset: 0xECE5C4 VA: 0xECE5C4
		private void RequestBirthdayTalk()
		{
			if(m_divaControl.RequestBirthdayTalk(OnTalkActionEnd))
			{
				DivaTalk("talk_birthday_{0:D2}", m_birthdayTalkData.NKCNHKHGJHN_TalkType, null);
				TimerStop();
			}
		}

		// // RVA: 0xECFB84 Offset: 0xECFB84 VA: 0xECFB84
		// private void RequestAutoTalk(int talkType) { }

		// // RVA: 0xECFD44 Offset: 0xECFD44 VA: 0xECFD44
		private void OnTalkActionEnd()
		{
			TimerRestart();
		}

		// // RVA: 0xECFD48 Offset: 0xECFD48 VA: 0xECFD48
		// private bool CheckComebackTalk(DateTime loginDate, DateTime lastLoginDate) { }

		// // RVA: 0xECE538 Offset: 0xECE538 VA: 0xECE538
		public bool CheckBirthdayTalk(bool checkOnly = true)
		{
			if(m_birthdayTalkData != null)
			{
				bool b = talkFlags.ODKIHPBEOEC_IsTrue(1);
				if (!b && !checkOnly)
				{
					talkFlags.EDEDFDDIOKO_SetTrue(1);
					return true;
				}
				return !b;
			}
			return false;
		}

		// // RVA: 0xECE6C0 Offset: 0xECE6C0 VA: 0xECE6C0
		public bool CheckLimitedTalk(bool checkOnly = true)
		{
			if (m_limitedTalkData.Count == 0)
				return false;
			bool b = talkFlags.ODKIHPBEOEC_IsTrue(2);
			if (!b && !checkOnly)
			{
				talkFlags.EDEDFDDIOKO_SetTrue(2);
				return true;
			}
			return !b;
		}

		// // RVA: 0xECF6E0 Offset: 0xECF6E0 VA: 0xECF6E0
		private void DivaTalk(string label, OnChangedMessage a_callback)
		{
			if(a_callback == null)
			{
				a_callback = onChangedMessage;
			}
			if(a_callback != null)
			{
				a_callback(divaManager.GetMessageByLabel(label));
			}
		}

		// // RVA: 0xECF644 Offset: 0xECF644 VA: 0xECF644
		private void DivaTalk(string labelFormat, int index, OnChangedMessage a_callback)
		{
			DivaTalk(string.Format(labelFormat, index), a_callback);
		}
	}
}
