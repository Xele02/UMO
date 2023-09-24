using System;
using System.Collections;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class HomeDivaControl : MenuDivaControlBase
	{
		private const float TalkWaitKeepSec = 0.2f;
		private Coroutine m_runningCoroutine; // 0x18
		private bool isTalkMotion; // 0x1C

		public MenuDivaVoiceTable VoiceTable { get; private set; } // 0x10
		public MenuDivaVoiceTableCos VoiceTableCos { get; private set; } // 0x14
		public bool IsAnimatorRequested { get; private set; } // 0x1D
		public bool IsActionRequested { get
			{
				if (!IsAnimatorRequested && m_runningCoroutine == null)
					return false;
				return true;
			}
			private set { return; } } //0x960DA8 0x9621E8
		public bool IsInAction { get; private set; } // 0x1E
		private Action OnActionEndCallback { get; set; } // 0x20

		// RVA: 0x960AD8 Offset: 0x960AD8 VA: 0x960AD8 Slot: 7
		public override void OnLateUpdate()
		{
			if(IsAnimatorRequested)
			{
				bool b = IsInAction;
				if (!IsInAction)
				{
					IsInAction = true;
					if(DivaObject.IsIdleAnim)
					{
						IsInAction = DivaObject.IsInTransition;
					}
					return;
				}
				if(DivaObject.IsIdleAnim)
				{
					if(!DivaObject.IsInTransition)
					{
						IsAnimatorRequested = false;
						IsInAction = false;
						if (OnActionEndCallback != null)
						{
							OnActionEndCallback();
							OnActionEndCallback = null;
						}
					}
				}
			}
		}

		// RVA: 0x960BD4 Offset: 0x960BD4 VA: 0x960BD4 Slot: 8
		protected override void OnBeginControl()
		{
			VoiceTable = DivaManager.VoiceTable;
			VoiceTableCos = DivaManager.VoiceTableCos;
		}

		// RVA: 0x960C40 Offset: 0x960C40 VA: 0x960C40 Slot: 9
		protected override void OnEndControl()
		{
			if(m_runningCoroutine != null)
			{
				StopCoroutine(m_runningCoroutine);
				m_runningCoroutine = null;
			}
		}

		//// RVA: 0x960C70 Offset: 0x960C70 VA: 0x960C70
		//public bool RequestTouchReaction(int reactionType, Action onActionEndCallback) { }

		//// RVA: 0x960FD0 Offset: 0x960FD0 VA: 0x960FD0
		//public bool RequestTouchReactionCos(int a_index, Action onActionEndCallback) { }

		//// RVA: 0x96117C Offset: 0x96117C VA: 0x96117C
		//public bool RequestAutoTalk(int talkType, Action onActionEndCallback) { }

		//// RVA: 0x9614A8 Offset: 0x9614A8 VA: 0x9614A8
		public bool RequestTimezoneTalk(int talkType, Action onActionEndCallback)
		{
			if (!IsAnimatorRequested && m_runningCoroutine == null)
			{
				bool b = false;
				OnLoginTalkStart(talkType, out b);
				OnActionEndCallback = onActionEndCallback;
				IsAnimatorRequested = true;
				if(!b)
				{
					StartRunningCoroutine(Coroutine_TimezoneTalkWait(), true);
				}
				else
				{
					StartRunningCoroutine(Coroutine_TalkVoiceWait(), true);
				}
				return true;
			}
			return false;
		}

		//// RVA: 0x961738 Offset: 0x961738 VA: 0x961738
		//public bool RequestComebackTalk(Action onActionEndCallback) { }

		//// RVA: 0x9618BC Offset: 0x9618BC VA: 0x9618BC
		public bool RequestLimitedTalk(int talkType, Action onActionEndCallback)
		{
			if (!IsAnimatorRequested && m_runningCoroutine == null)
			{
				IsAnimatorRequested = true;
				StartRunningCoroutine(Co_ChangeCueSheetProcess(talkType, () =>
				{
					//0x9627CC
					OnEventTalkStart(talkType);
					OnActionEndCallback = onActionEndCallback;
					StartRunningCoroutine(Coroutine_TalkVoiceWait(), false);
				}), true);
				return true;
			}
			return false;
		}

		//// RVA: 0x961AA4 Offset: 0x961AA4 VA: 0x961AA4
		//public int RandomPresentReaction() { }

		//// RVA: 0x961B88 Offset: 0x961B88 VA: 0x961B88
		public bool RequestPresentReaction(int a_index, Action onActionEndCallback)
		{
			if(!IsAnimatorRequested && m_runningCoroutine == null)
			{
				MenuDivaVoiceTable.Data data = VoiceTable.GetPresent(a_index);
				if(data != null)
				{
					if(MotionStart(data.MotionType, onActionEndCallback))
					{
						SoundManager.Instance.voDiva.Play(DivaVoicePlayer.VoiceCategory.Present, data.VoiceId);
						DivaManager.DivaTransformReset();
						return true;
					}
				}
			}
			return false;
		}

		//// RVA: 0x961CAC Offset: 0x961CAC VA: 0x961CAC
		//public int RandomIntimacyReaction() { }

		//// RVA: 0x961D90 Offset: 0x961D90 VA: 0x961D90
		//public bool RequestIntimacyReaction(int a_index, Action onActionEndCallback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6C64D0 Offset: 0x6C64D0 VA: 0x6C64D0
		//// RVA: 0x9619FC Offset: 0x9619FC VA: 0x9619FC
		private IEnumerator Co_ChangeCueSheetProcess(int talkType, Action onChangedCallback)
		{
			//0x962884
			bool isEndedChangeCueSheet = false;
			SoundManager.Instance.voSeasonEvent.RequestChangeCueSheet(talkType, () =>
			{
				//0x96286C
				isEndedChangeCueSheet = true;
			});
			yield return new WaitUntil(() =>
			{
				//0x962878
				return isEndedChangeCueSheet;
			});
			if (onChangedCallback != null)
				onChangedCallback();
		}

		//// RVA: 0x961ED4 Offset: 0x961ED4 VA: 0x961ED4
		public bool RequestBirthdayTalk(Action onActionEndCallback)
		{
			if(!IsAnimatorRequested && m_runningCoroutine == null)
			{
				OnBirthdayTalkStart();
				OnActionEndCallback = onActionEndCallback;
				IsAnimatorRequested = true;
				StartRunningCoroutine(Coroutine_TalkVoiceWait(), true);
				return true;
			}
			return false;
		}

		//// RVA: 0x962058 Offset: 0x962058 VA: 0x962058
		public void CancelRequest()
		{
			if(!IsAnimatorRequested)
			{
				if (m_runningCoroutine == null)
					return;
				StopCoroutine(m_runningCoroutine);
				m_runningCoroutine = null;
			}
			else if(m_runningCoroutine != null)
			{
				StopCoroutine(m_runningCoroutine);
				m_runningCoroutine = null;
			}
			SoundManager.Instance.voDiva.Stop();
			SoundManager.Instance.voDivaCos.Stop();
			SoundManager.Instance.voSeasonEvent.Stop();
			IsAnimatorRequested = false;
			OnActionEndCallback = null;
		}

		//// RVA: 0x962184 Offset: 0x962184 VA: 0x962184
		public void RequestDelayDownLoad(int talkType)
		{
			SoundManager.Instance.voSeasonEvent.RequestCueSheetDelayDownLoad(talkType);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6C65A8 Offset: 0x6C65A8 VA: 0x6C65A8
		//// RVA: 0x962204 Offset: 0x962204 VA: 0x962204
		public IEnumerator Coroutine_IdleCrossFade()
		{
			//0x962AEC
			if(DivaObject.IsInTransition)
			{
				while (!DivaObject.IsIdleAnim)
					yield return null;
			}
			if(!isTalkMotion)
			{
				while (DivaObject.IsInFacialTransition)
					yield return null;
				DivaObject.ReactionLoopBreak();
				DivaObject.IdleCrossFade("");
			}
			else
			{
				DivaObject.TalkLoopBreak();
			}
			yield return null;
			while (!DivaObject.IsIdleAnim || DivaObject.IsInTransition)
				yield return null;
		}

		//// RVA: 0x960ADC Offset: 0x960ADC VA: 0x960ADC
		//private void RequestUpdate() { }

		//// RVA: 0x961458 Offset: 0x961458 VA: 0x961458
		private bool StartRunningCoroutine(IEnumerator a_co, bool a_check_null = true)
		{
			if(m_runningCoroutine == null || !a_check_null)
			{
				m_runningCoroutine = StartCoroutine(a_co);
				StartCoroutine(Coroutine_RunningCoroutineEndCheck());
				return true;
			}
			return false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6C6620 Offset: 0x6C6620 VA: 0x6C6620
		//// RVA: 0x9622B0 Offset: 0x9622B0 VA: 0x9622B0
		private IEnumerator Coroutine_RunningCoroutineEndCheck()
		{
			//0x963280
			yield return null;
			while (m_runningCoroutine == null)
				yield return null;
			yield return null;
			m_runningCoroutine = null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6C6698 Offset: 0x6C6698 VA: 0x6C6698
		//// RVA: 0x96235C Offset: 0x96235C VA: 0x96235C
		private IEnumerator Coroutine_ReactionVoiceWait()
		{
			//0x9630A0
			yield return null;
			while (SoundManager.Instance.voDiva.isPlaying)
				yield return null;
			while (SoundManager.Instance.voDivaCos.isPlaying)
				yield return null;
			while (IsAnimatorRequested)
				yield return null;
			DivaObject.ReactionLoopBreak();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6C6710 Offset: 0x6C6710 VA: 0x6C6710
		//// RVA: 0x9613CC Offset: 0x9613CC VA: 0x9613CC
		private IEnumerator Coroutine_TalkVoiceWait()
		{
			float loopKeepTime; // 0x14
			DivaVoicePlayer voDiva; // 0x18
			DivaCosVoicePlayer voDivaCos; // 0x1C
			SeasonEventVoicePlayer voSeasonEvent; // 0x20

			//0x9633BC
			yield return null;
			loopKeepTime = TimeWrapper.timeSinceLevelLoad + 0.2f;
			while (TimeWrapper.timeSinceLevelLoad < loopKeepTime)
				yield return null;
			voDiva = SoundManager.Instance.voDiva;
			voDivaCos = SoundManager.Instance.voDivaCos;
			voSeasonEvent = SoundManager.Instance.voSeasonEvent;
			while (voDiva.isPlaying || voDivaCos.isPlaying || voSeasonEvent.isPlaying)
				yield return null;
			DivaObject.TalkLoopBreak();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6C6788 Offset: 0x6C6788 VA: 0x6C6788
		//// RVA: 0x9616AC Offset: 0x9616AC VA: 0x9616AC
		private IEnumerator Coroutine_TimezoneTalkWait()
		{
			//0x963688
			yield return null;
			while (!DivaObject.IsIdleAnim)
				yield return null;
			IsAnimatorRequested = false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6C6800 Offset: 0x6C6800 VA: 0x6C6800
		//// RVA: 0x962448 Offset: 0x962448 VA: 0x962448
		private IEnumerator Coroutine_PresentMotionWait()
		{
			//0x962ECC
			yield return null;
			while (SoundManager.Instance.voDiva.isPlaying)
				yield return null;
			while (SoundManager.Instance.voDivaCos.isPlaying)
				yield return null;
			DivaObject.StopAnimationPresent();
		}

		//// RVA: 0x960DCC Offset: 0x960DCC VA: 0x960DCC
		private bool MotionStart(DivaMenuMotion.Type a_type, Action a_calback_action_end)
		{
			if (IsAnimatorRequested || m_runningCoroutine != null)
				return false;
			isTalkMotion = false;
			if(DivaMenuMotion.IsTalk(a_type))
			{
				DivaObject.Talk(DivaMenuMotion.ToMotionId(a_type));
				StartRunningCoroutine(Coroutine_TalkVoiceWait(), true);
				isTalkMotion = true;
			}
			else if(DivaMenuMotion.IsSimpleTalk(a_type))
			{
				DivaObject.SimpleTalk(DivaMenuMotion.ToMotionId(a_type));
			}
			else if(DivaMenuMotion.IsTouchReaction(a_type))
			{
				DivaObject.Reaction(DivaMenuMotion.ToMotionId(a_type));
				StartRunningCoroutine(Coroutine_ReactionVoiceWait(), true);
			}
			else if(DivaMenuMotion.IsTimezoneTalk(a_type))
			{
				DivaObject.TimezoneTalk(DivaMenuMotion.ToMotionId(a_type));
			}
			else if(DivaMenuMotion.IsPresentReaction(a_type))
			{
				DivaObject.PlayAnimationPresent(DivaMenuMotion.ToMotionId(a_type));
				StartRunningCoroutine(Coroutine_PresentMotionWait(), true);
			}
			OnActionEndCallback = a_calback_action_end;
			IsAnimatorRequested = true;
			return true;
		}

		//// RVA: 0x9624F4 Offset: 0x9624F4 VA: 0x9624F4
		//private void OnReactionStart(int reactionType, out bool useTalkMotion) { }

		//// RVA: 0x9611DC Offset: 0x9611DC VA: 0x9611DC
		//private void OnTimeTalkStart(int talkType) { }

		//// RVA: 0x961540 Offset: 0x961540 VA: 0x961540
		private void OnLoginTalkStart(int talkType, out bool useTalkMotion)
		{
			DivaManager.DivaTransformReset();
			SoundManager.Instance.voDiva.Play(DivaVoicePlayer.VoiceCategory.Home, VoiceTable.GetLoginTalk((DivaTimezoneTalk.Type)talkType).VoiceId);
			DivaMenuMotion.Type motion = VoiceTable.GetLoginTalk((DivaTimezoneTalk.Type)talkType).MotionType;
			if (!DivaMenuMotion.IsTimezoneTalk(motion))
			{
				DivaObject.Talk(DivaMenuMotion.ToMotionId(motion));
				useTalkMotion = true;
			}
			else
			{
				DivaObject.TimezoneTalk(DivaMenuMotion.ToMotionId(motion));
				useTalkMotion = false;
			}
		}

		//// RVA: 0x961798 Offset: 0x961798 VA: 0x961798
		//private void OnComebackTalkStart() { }

		//// RVA: 0x962660 Offset: 0x962660 VA: 0x962660
		private void OnEventTalkStart(int talkType)
		{
			DivaManager.DivaTransformReset();
			SoundManager.Instance.voSeasonEvent.Play(DivaManager.DivaId, VoiceTable.GetEventTalk((DivaSeasonTalk.Type)(talkType - 1)).VoiceId);
			DivaObject.Talk(DivaMenuMotion.ToMotionId(VoiceTable.GetEventTalk((DivaSeasonTalk.Type)(talkType - 1)).MotionType));
		}

		//// RVA: 0x961F34 Offset: 0x961F34 VA: 0x961F34
		private void OnBirthdayTalkStart()
		{
			DivaManager.DivaTransformReset();
			SoundManager.Instance.voDiva.Play(DivaVoicePlayer.VoiceCategory.Home, VoiceTable.GetBirthdayTalk().VoiceId);
			DivaObject.Talk(DivaMenuMotion.ToMotionId(VoiceTable.GetBirthdayTalk().MotionType));
		}

		//[ConditionalAttribute] // RVA: 0x6C6878 Offset: 0x6C6878 VA: 0x6C6878
		//// RVA: 0x9627C0 Offset: 0x9627C0 VA: 0x9627C0
		//private static void VoiceDataLog(string name, int index, MenuDivaVoiceTable.Data data) { }
	}
}
