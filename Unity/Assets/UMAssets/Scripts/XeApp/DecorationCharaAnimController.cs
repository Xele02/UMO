using System;
using UnityEngine;

namespace XeApp
{
	public class DecorationCharaAnimController : MonoBehaviour
	{
		public enum ReactionSpecifiedType
		{
			Glad = 0,
			Angry = 1,
		}

		private enum State
		{
			Wait = 0,
			Move = 1,
			Speak = 2,
			GladJump = 3,
			AngrySway = 4,
			Pinched = 5,
			GladJumpIntimacy = 6,
			TouchKeep = 7,
			TouchKeepIntimacy = 8,
		}

		private enum Coll
		{
			None = 0,
			Enter = 1,
			Turn = 2,
		}

		private DecorationChara chara; // 0xC
		private Vector2 initPos; // 0x10
		private Vector2 to; // 0x18
		private Vector2 from; // 0x20
		private Vector2 prevTo; // 0x28
		private Vector2 diffPos; // 0x30
		private Animator animator; // 0x38
		private Func<Vector2, DecorationChara.CollStatus> hitcheck; // 0x3C
		private static readonly int HashWait = Animator.StringToHash("Wait"); // 0x0
		private static readonly int HashWalkL = Animator.StringToHash("WalkL"); // 0x4
		private static readonly int HashWalkR = Animator.StringToHash("WalkR"); // 0x8
		private static readonly int HashGlad = Animator.StringToHash("Glad"); // 0xC
		private static readonly int HashAngry = Animator.StringToHash("Angry"); // 0x10
		private static readonly int HashGladJump = HashGlad; // 0x14
		private static readonly int HashAngrySway = HashAngry; // 0x18
		private static readonly int HashWaitSway = Animator.StringToHash("WaitSway"); // 0x1C
		private float angleMax; // 0x40
		private float rangeMax; // 0x44
		private float rangeMin; // 0x48
		private float waitSecMin; // 0x4C
		private float waitSecMax; // 0x50
		private float moveSecMin; // 0x54
		private float moveSecMax; // 0x58
		private int angryInterval; // 0x5C
		private float leftSpeakBlank; // 0x60
		private float leftGladBlank; // 0x64
		private float reactionGladBlank; // 0x68
		private float reactionAngryBlank; // 0x6C
		private float intimacyBlank; // 0x70
		private State _state; // 0x74
		private State prevState; // 0x78
		private float currentStateSec; // 0x7C
		private float waitSec; // 0x80
		private float moveSec; // 0x84
		private float elapsedSec; // 0x88
		private bool isWaitStartAnim; // 0x8C
		private int enabledHash; // 0x90
		private bool isWaitNextAnim; // 0x94
		private float nextBlankSec; // 0x98
		private Action stateChangePreprocess; // 0x9C
		private Coll coll; // 0xA0
		private int touchCnt; // 0xA4
		private bool _hasEscaped; // 0xB0

		private State state { get { return _state; } set
			{
				if(stateChangePreprocess != null)
				{
					stateChangePreprocess();
					stateChangePreprocess = null;
				}
				prevState = _state;
				_state = value;
				ResetSec();
			}
		} //0x1ACA90C 0x1ACA914
		public Vector2 escapeDir { get; set; } // 0xA8
		public bool hasTouched { get; private set; } // 0xB1
		public bool hasPinched { get; private set; } // 0xB2
		public bool isReaction { get; private set; } // 0xB3
		public bool hasEscaped { get { return _hasEscaped; } set { _hasEscaped = value; } } //0x1AC593C 0x1AC5264

		//// RVA: 0x1ACA820 Offset: 0x1ACA820 VA: 0x1ACA820
		private int GetInt(string key, int defaultValue)
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA(key, defaultValue);
		}

		// RVA: 0x1ACA9B4 Offset: 0x1ACA9B4 VA: 0x1ACA9B4
		private void OnEnable()
		{
			touchCnt = 0;
			ResetState(true, true, true, true, false);
			_hasEscaped = false;
		}

		// RVA: 0x1AC99B8 Offset: 0x1AC99B8 VA: 0x1AC99B8
		public void Init(DecorationChara chara, Animator animator, Func<Vector2, DecorationChara.CollStatus> hitcheck)
		{
			this.chara = chara;
			initPos = chara.Position;
			this.animator = animator;
			CheckAnim();
			this.hitcheck = hitcheck;
			angleMax = GetInt("move_angle_max", 50);
			rangeMax = GetInt("move_range_max", 200);
			rangeMin = GetInt("move_range_min", 150);
			waitSecMin = GetInt("wait_milli_short", 2000) / 1000.0f;
			waitSecMax = GetInt("wait_milli_long", 3000) / 1000.0f;
			moveSecMin = GetInt("move_milli_short", 3000) / 1000.0f;
			moveSecMax = GetInt("move_milli_long", 4000) / 1000.0f;
			angryInterval = GetInt("angry_interval_cnt", 3);
			leftSpeakBlank = GetInt("left_speak_blank_milli", 1000) / 1000.0f;
			leftGladBlank = GetInt("left_glad_blank_milli", 2000) / 1000.0f;
			reactionGladBlank = GetInt("reaction_glad_blank_milli", 2000) / 1000.0f;
			reactionAngryBlank = GetInt("reaction_angry_blank_milli", 2000) / 1000.0f;
			intimacyBlank = GetInt("intimacy_anim_blank_milli", 2000) / 1000.0f;
			touchCnt = 0;
			ResetState(true, true, true, true, false);
			_hasEscaped = false;
			escapeDir = Vector2.zero;
		}

		//[ConditionalAttribute] // RVA: 0x6ABD68 Offset: 0x6ABD68 VA: 0x6ABD68
		//// RVA: 0x1ACAB10 Offset: 0x1ACAB10 VA: 0x1ACAB10
		//private void dbg_MoveForced(ref Vector2 pos) { }

		//// RVA: 0x1AC5958 Offset: 0x1AC5958 VA: 0x1AC5958
		public Vector2 UpdateMotion(Vector2 pos)
		{
			if(!isWaitNextAnim)
			{
				elapsedSec += Time.deltaTime;
			}
			else
			{
				if(enabledHash == GetAnimHash())
				{
					elapsedSec += Time.deltaTime;
					isWaitNextAnim = false;
					currentStateSec = nextBlankSec + GetAnimSec();
					nextBlankSec = 0;
				}
			}
			bool isEscape = false;
			if (!_hasEscaped && escapeDir.sqrMagnitude != 0)
				isEscape = true;
			switch(_state)
			{
				case State.Wait:
					if (!isEscape && !DecideMoveDst(ref pos))
						UpdateState_Wait(ref pos);
					break;
				case State.Move:
					UpdateState_Move(ref pos);
					break;
				case State.Speak:
					if (isEscape)
						DecideMoveDst(ref pos);
					else
						UpdateState_Speak(ref pos);
					break;
				case State.GladJump:
				case State.GladJumpIntimacy:
					UpdateState_GladJump(ref pos, isEscape);
					break;
				case State.AngrySway:
					UpdateState_AngrySway(ref pos, isEscape);
					break;
				case State.Pinched:
					UpdateState_Pinched();
					break;
				case State.TouchKeep:
				case State.TouchKeepIntimacy:
					UpdateState_TouchKeep();
					break;
				default:
					ResetState(true, true, true, true, false);
					break;
			}
			return diffPos;
		}

		//// RVA: 0x1AC50B0 Offset: 0x1AC50B0 VA: 0x1AC50B0
		public void ResetState(bool isResetFlag = true, bool isHidePhrase = true, bool isChangeAnimForced = true, bool isResetEscape = true, bool isResetColl = false)
		{
			if(isResetFlag)
			{
				isReaction = false;
				isWaitStartAnim = false;
				hasTouched = false;
				hasPinched = false;
			}
			if (isResetEscape)
				_hasEscaped = false;
			if(chara != null && isHidePhrase)
			{
				chara.HideReaction();
				chara.HideSerif();
			}
			if(isResetColl)
			{
				coll = Coll.None;
				prevTo = Vector2.zero;
			}
			diffPos = Vector2.zero;
			AnimWait(isChangeAnimForced);
		}

		//// RVA: 0x1ACB7D0 Offset: 0x1ACB7D0 VA: 0x1ACB7D0
		private void AnimWait(bool isChangeForced = true)
		{
			state = 0;
			ChangeAnim(HashWait, isChangeForced);
			currentStateSec = waitSec;
		}

		//// RVA: 0x1ACB8F4 Offset: 0x1ACB8F4 VA: 0x1ACB8F4
		private void AnimLeftSpeak()
		{
			state = State.Speak;
			ChangeAnim(HashGlad, true);
			if (chara != null)
				chara.ShowSerif();
			isWaitNextAnim = true;
			nextBlankSec = leftSpeakBlank;
		}

		//// RVA: 0x1ACBA1C Offset: 0x1ACBA1C VA: 0x1ACBA1C
		private void AnimLeftGlad()
		{
			state = State.GladJump;
			ChangeAnim(HashGladJump, true);
			isWaitNextAnim = true;
			nextBlankSec = leftGladBlank;
		}

		//// RVA: 0x1ACBAD4 Offset: 0x1ACBAD4 VA: 0x1ACBAD4
		//private void AnimReactionGlad() { }

		//// RVA: 0x1ACBB98 Offset: 0x1ACBB98 VA: 0x1ACBB98
		//private void AnimReactionAngry() { }

		//// RVA: 0x1AC6B80 Offset: 0x1AC6B80 VA: 0x1AC6B80
		//public void AnimReactionSpecified(DecorationCharaAnimController.ReactionSpecifiedType type) { }

		//// RVA: 0x1ACBC5C Offset: 0x1ACBC5C VA: 0x1ACBC5C
		//private void AnimPinch(bool isInitiation) { }

		//// RVA: 0x1ACBEAC Offset: 0x1ACBEAC VA: 0x1ACBEAC
		private void AnimTouchKeep()
		{
			state = State.TouchKeep;
			if (GetAnimHash() != HashWait)
				;//? elapsedSec = elapsedSec;
		}

		//// RVA: 0x1ACBF60 Offset: 0x1ACBF60 VA: 0x1ACBF60
		//private void AnimTouchKeepIntimacy() { }

		//// RVA: 0x1ACC008 Offset: 0x1ACC008 VA: 0x1ACC008
		//private void AnimIntimacyUp() { }

		//// RVA: 0x1ACC128 Offset: 0x1ACC128 VA: 0x1ACC128
		//public void Direct(Vector2 move, bool isChangeForced = False) { }

		//// RVA: 0x1ACB884 Offset: 0x1ACB884 VA: 0x1ACB884
		private void ChangeAnim(int hash, bool isChangeForced = true)
		{
			if(CheckAnim())
			{
				if(isChangeForced || enabledHash != hash)
				{
					animator.Play(hash);
					enabledHash = hash;
				}
			}
		}

		//// RVA: 0x1ACBA0C Offset: 0x1ACBA0C VA: 0x1ACBA0C
		//private void WaitAnimSec(float blank) { }

		//// RVA: 0x1ACABAC Offset: 0x1ACABAC VA: 0x1ACABAC
		private float GetAnimSec()
		{
			if(CheckAnim())
			{
				return animator.GetCurrentAnimatorStateInfo(0).length;
			}
			return 0;
		}

		//// RVA: 0x1ACBE08 Offset: 0x1ACBE08 VA: 0x1ACBE08
		//private float GetAnimNormalizedTime() { }

		//// RVA: 0x1ACAB14 Offset: 0x1ACAB14 VA: 0x1ACAB14
		private int GetAnimHash()
		{
			if(CheckAnim())
			{
				return animator.GetCurrentAnimatorStateInfo(0).shortNameHash;
			}
			return 0;
		}

		//// RVA: 0x1ACA9F4 Offset: 0x1ACA9F4 VA: 0x1ACA9F4
		private bool CheckAnim()
		{
			if(animator != null)
			{
				if(animator.isActiveAndEnabled)
				{
					return animator.runtimeAnimatorController != null;
				}
			}
			return false;
		}

		//// RVA: 0x1AC5B58 Offset: 0x1AC5B58 VA: 0x1AC5B58
		public void OnCollide(bool enterForced = false)
		{
			if ((coll | Coll.Turn) != Coll.Turn && !enterForced)
				return;
			coll = Coll.Enter;
		}

		//// RVA: 0x1AC7EC4 Offset: 0x1AC7EC4 VA: 0x1AC7EC4
		//public void OnTap() { }

		//// RVA: 0x1AC79B0 Offset: 0x1AC79B0 VA: 0x1AC79B0
		//public void OnPinch() { }

		//// RVA: 0x1AC5928 Offset: 0x1AC5928 VA: 0x1AC5928
		public void OnGround()
		{
			hasPinched = false;
		}

		//// RVA: 0x1AC70D4 Offset: 0x1AC70D4 VA: 0x1AC70D4
		//public void OnTouchEnter() { }

		//// RVA: 0x1AC957C Offset: 0x1AC957C VA: 0x1AC957C
		//public bool OnBeginIntimacyCheck() { }

		//// RVA: 0x1AC918C Offset: 0x1AC918C VA: 0x1AC918C
		//public void OnLongTap() { }

		//// RVA: 0x1AC7FB8 Offset: 0x1AC7FB8 VA: 0x1AC7FB8
		//public void OnTouchUp() { }

		//// RVA: 0x1ACAE84 Offset: 0x1ACAE84 VA: 0x1ACAE84
		private void UpdateState_Wait(ref Vector2 pos)
		{
			if (elapsedSec <= currentStateSec)
				return;
			if(_hasEscaped)
			{
				int a = UnityEngine.Random.Range(0, 1000);
				if((a & 1) != 0)
				{
					if((a & 2) == 0)
					{
						AnimLeftSpeak();
						return;
					}
					AnimLeftGlad();
					return;
				}
			}
			DecideMoveDst(ref pos);
		}

		//// RVA: 0x1ACAEFC Offset: 0x1ACAEFC VA: 0x1ACAEFC
		private void UpdateState_Speak(ref Vector2 pos)
		{
			if(currentStateSec < elapsedSec)
			{
				chara.HideSerif();
				if(hasTouched)
				{
					AnimTouchKeep();
					return;
				}
				ResetState(true, true, true, true, false);
			}
		}

		//// RVA: 0x1ACAF84 Offset: 0x1ACAF84 VA: 0x1ACAF84
		private void UpdateState_GladJump(ref Vector2 pos, bool isEscape = false)
		{
			if(!isWaitStartAnim)
			{
				if(currentStateSec < elapsedSec)
				{
					if(chara != null)
					{
						if(chara.IsPlayVoice())
							return;
					}
					if(!isEscape || !DecideMoveDst(ref pos))
					{
						if (!hasTouched)
							ResetState(true, true, true, true, false);
						else
							AnimTouchKeep();
						isReaction = false;
					}
				}
			}
			else
			{
				if(chara != null)
				{
					if (!chara.IsReadyVoiceCueSheet())
						return;
				}
				isWaitStartAnim = false;
				ChangeAnim(HashGladJump, true);
				if(chara != null)
				{
					chara.ShowReactionGlad();
					chara.PlayVoice(2, 0);
				}
				isWaitNextAnim = true;
				nextBlankSec = reactionGladBlank;
			}
		}

		//// RVA: 0x1ACB224 Offset: 0x1ACB224 VA: 0x1ACB224
		private void UpdateState_Move(ref Vector2 pos)
		{
			if(coll != Coll.Enter)
			{
				if(elapsedSec <= currentStateSec)
				{
					if(!CollDst(ref to))
					{
						MoveTo(to, from);
						return;
					}
					if (!_hasEscaped)
						return;
					coll = Coll.Enter;
					return;
				}
				DecideMoveDst(ref pos);
				if (!_hasEscaped && escapeDir.sqrMagnitude != 0)
					return;
			}
			ResetState(true, true, true, true, false);
		}

		//// RVA: 0x1ACB314 Offset: 0x1ACB314 VA: 0x1ACB314
		private void UpdateState_AngrySway(ref Vector2 pos, bool isEscape = false)
		{
			if(!isWaitStartAnim)
			{
				if(currentStateSec < elapsedSec)
				{
					if(chara != null)
					{
						if(chara.IsPlayVoice())
							return;
					}
					if(!isEscape || !DecideMoveDst(ref pos))
					{
						if (!hasTouched)
							ResetState(true, true, true, true, false);
						else
							AnimTouchKeep();
						isReaction = false;
					}
				}
			}
			else
			{
				if(chara != null)
				{
					if (!chara.IsReadyVoiceCueSheet())
						return;
				}
				isWaitStartAnim = false;
				ChangeAnim(HashAngrySway, true);
				if(chara != null)
				{
					chara.ShowReactionAngry();
					chara.PlayVoice(1, 0);
				}
				isWaitNextAnim = true;
				nextBlankSec = reactionAngryBlank;
			}
		}

		//// RVA: 0x1ACB5B4 Offset: 0x1ACB5B4 VA: 0x1ACB5B4
		private void UpdateState_Pinched()
		{
			if(!hasPinched)
			{
				ResetState(true, true, true, true, false);
				return;
			}
			if (!hasTouched)
				return;
			AnimPinch(false);
		}

		//// RVA: 0x1ACB608 Offset: 0x1ACB608 VA: 0x1ACB608
		private void UpdateState_TouchKeep()
		{
			if(GetAnimHash() != HashWait && currentStateSec <= elapsedSec)
			{
				if(chara != null)
				{
					chara.HideReaction();
					chara.HideSerif();
				}
				ChangeAnim(HashWait, true);
			}
			if (!hasPinched && !hasTouched)
				ResetState(true, true, false, true, false);
		}

		//// RVA: 0x1ACA958 Offset: 0x1ACA958 VA: 0x1ACA958
		private void ResetSec()
		{
			elapsedSec = 0;
			waitSec = UnityEngine.Random.Range(waitSecMin, waitSecMax);
			moveSec = UnityEngine.Random.Range(moveSecMin, moveSecMax);
		}

		//// RVA: 0x1ACC2E8 Offset: 0x1ACC2E8 VA: 0x1ACC2E8
		//private void MoveTo(Vector2 to, Vector2 from) { }

		//// RVA: 0x1ACAC50 Offset: 0x1ACAC50 VA: 0x1ACAC50
		private bool DecideMoveDst(ref Vector2 fromPos)
		{
			state = State.Move;
			chara.HideReaction();
			chara.HideSerif();
			isReaction = false;
			if(!_hasEscaped)
			{
				if (!TryEscape(fromPos))
					return false;
			}
			else
			{
				if (!TryMoveRandom(fromPos))
					return false;
			}
			if(coll == Coll.Enter)
			{
				coll = Coll.Turn;
				stateChangePreprocess += () =>
				{
					//0x1ACCD20
					coll = Coll.None;
				};
			}
			Direct(to - from, false);
			currentStateSec = moveSec;
			return true;
		}

		//// RVA: 0x1ACC984 Offset: 0x1ACC984 VA: 0x1ACC984
		//private bool AdjustDst() { }

		//// RVA: 0x1ACC42C Offset: 0x1ACC42C VA: 0x1ACC42C
		//private bool TryEscape(ref Vector2 fromPos) { }

		//// RVA: 0x1ACC62C Offset: 0x1ACC62C VA: 0x1ACC62C
		//private bool TryMoveRandom(ref Vector2 fromPos) { }

		//[ConditionalAttribute] // RVA: 0x6ABD9C Offset: 0x6ABD9C VA: 0x6ABD9C
		//// RVA: 0x1ACCAA4 Offset: 0x1ACCAA4 VA: 0x1ACCAA4
		//private void dbg_OverwriteDst() { }

		//// RVA: 0x1ACC22C Offset: 0x1ACC22C VA: 0x1ACC22C
		//private bool CollDst(ref Vector2 dst) { }
	}
}
