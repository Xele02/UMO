using XeApp.Game.Menu;
using UnityEngine;
using System.Collections.Generic;
using System.Text;
using XeSys;

namespace XeApp.Game.Common
{
	public class MenuDivaObject : DivaObject
	{
		public enum eUnlockDivaAnimStep
		{
			Start = 0,
			Loop = 1,
		}

		public enum eUnlockCostumeAnimStep
		{
			Start = 0,
			Pose = 1,
			Loop = 2,
		}

		private const float BattleResultLose_CrossFadeSec = 0.3f;
		private const float BattleResultLose_RotationSec = 0.3f;
		private const float BattleResultLose_RotationDegree = 15;
		[SerializeField]
		private MenuDivaGazeControl.Data gazeControlData = new MenuDivaGazeControl.Data(); // 0x8C
		private Dictionary<int, List<Renderer>> rendererDict = new Dictionary<int, List<Renderer>>(); // 0x90
		private List<Renderer> rendererComponentList = new List<Renderer>(); // 0x94
		private static readonly int IdleHash = Animator.StringToHash("body.sub_menu.idle"); // 0x0
		private static readonly int IdleHashFace = Animator.StringToHash("face.sub_menu.idle"); // 0x4
		private static readonly int IdleHashMouth = Animator.StringToHash("mouth.sub_menu.idle"); // 0x8
		private static readonly int TalkLoop01Hash = Animator.StringToHash("body.sub_menu.sub_talk.talk01"); // 0xC
		private static readonly int TalkLoop02Hash = Animator.StringToHash("body.sub_menu.sub_talk.talk02"); // 0x10
		private static readonly int LoginIdleHash = Animator.StringToHash("body.sub_login.login_idle"); // 0x14
		private bool isStopFrame; // 0x98

		//public MenuDivaGazeControl.Data GazeControlData { get; } 0x110F3C8
		protected override bool useQualitySetting { get { return false; } } //0x110F3D0
		public bool IsIdleAnim { get { return animator.GetCurrentAnimatorStateInfo(0).fullPathHash == IdleHash; } private set { return; } } //0x1112268 0x111237C
		//public bool IsFacialIdelAnim { get; private set; } 0x1112380 0x1112564
		public bool IsInTransition { get { return animator.IsInTransition(0); } } //0x1112568
		public bool IsInFacialTransition { get { return facialBlendAnimMediator.selfAnimator.IsInTransition(0) || facialBlendAnimMediator.selfAnimator.IsInTransition(1); } } //0x1112598

		// RVA: 0x110F3D8 Offset: 0x110F3D8 VA: 0x110F3D8 Slot: 6
		protected override void SetupCustomComponents(DivaResource resource)
		{
			facialBlendAnimMediator = GetComponentInChildren<MenuFacialBlendAnimMediator>();
			facialBlendAnimMediator.Initialize(resource, divaPrefab);
			facialBlendAnimMediator.SetEyeMeshUvRate(ObjParam.GetEyeMeshUvRate(divaId));
			if(boneSpringController != null)
			{
				boneSpringController.Lock(0);
			}
			Transform t = divaPrefab.transform.Find("joint_root/hips");
			if(t != null)
			{
				adjustScaler = t.gameObject.GetComponent<ObjectPositionAdjuster>();
				if(adjustScaler == null)
				{
					adjustScaler = t.gameObject.AddComponent<ObjectPositionAdjuster>();
				}
				adjustScaler.Initialize(ObjParam.GetHipScaleFactor(divaId), true, true, true);
			}
			SetActiveFoundChildren(divaPrefab.transform, "game", false);
			Transform mesh = divaPrefab.transform.Find("mesh_root");
			Renderer[] rs = mesh.GetComponentsInChildren<Renderer>();
			for(int i = 0; i < rs.Length; i++)
			{
				for(int j = 0; j < rs[i].materials.Length; j++)
				{
					if(rs[i].materials[j].shader.name == "MCRS/Diva/Opaque_Outline_High")
					{
						rs[i].materials[j].SetFloat("_EdgeThickness", 35);
					}
				}
			}
			animator.playableGraph.SetTimeUpdateMode(UnityEngine.Playables.DirectorUpdateMode.GameTime);
			facialBlendAnimMediator.selfAnimator.playableGraph.SetTimeUpdateMode(UnityEngine.Playables.DirectorUpdateMode.GameTime);
			rendererDict.Clear();
			Idle("");
		}

		// RVA: 0x110FB80 Offset: 0x110FB80 VA: 0x110FB80 Slot: 5
		protected override void OverrideCustomAnimation(DivaResource resource)
		{
			StringBuilder str = new StringBuilder(64);
			overrideController["diva_cmn_menu_idle_body"] = resource.menuMotionOverride.idle.bodyClip;
			for(int i = 0; i < resource.menuMotionOverride.reactions.Count; i++)
			{
				str.SetFormat("diva_cmn_menu_reaction{0:D2}_body", i + 1);
				overrideController[str.ToString()] = resource.menuMotionOverride.reactions[i].main.bodyClip;
			}
			for (int i = 0; i < resource.menuMotionOverride.talk.Count; i++)
			{
				str.SetFormat("diva_cmn_menu_talk{0:D2}_start_body", i + 1);
				overrideController[str.ToString()] = resource.menuMotionOverride.talk[i].begin.bodyClip;
				str.SetFormat("diva_cmn_menu_talk{0:D2}_body", i + 1);
				overrideController[str.ToString()] = resource.menuMotionOverride.talk[i].main.bodyClip;
				str.SetFormat("diva_cmn_menu_talk{0:D2}_end_body", i + 1);
				overrideController[str.ToString()] = resource.menuMotionOverride.talk[i].end.bodyClip;
			}
			for (int i = 0; i < resource.menuMotionOverride.simpletalk.Count; i++)
			{
				str.SetFormat("diva_cmn_menu_simple_talk{0:D2}_body", i + 1);
				overrideController[str.ToString()] = resource.menuMotionOverride.simpletalk[i].main.bodyClip;
			}
			for (int i = 0; i < resource.menuMotionOverride.timezone.Count; i++)
			{
				str.SetFormat("diva_cmn_menu_timezone{0:D2}_body", i + 1);
				overrideController[str.ToString()] = resource.menuMotionOverride.timezone[i].main.bodyClip;
			}
			overrideController["diva_cmn_result_wait_loop_body"] = resource.resultMotionOverride.wait.bodyClip;
			overrideController["diva_cmn_result_start_body"] = resource.resultMotionOverride.start.bodyClip;
			overrideController["diva_cmn_result_end_loop_body"] = resource.resultMotionOverride.end.bodyClip;
			overrideController["diva_cmn_result_win_start_body"] = resource.resultMotionOverride.winStart.bodyClip;
			overrideController["diva_cmn_result_win_end_loop_body"] = resource.resultMotionOverride.winEnd.bodyClip;
			overrideController["diva_cmn_result_lose_start_body"] = resource.resultMotionOverride.loseStart.bodyClip;
			overrideController["diva_cmn_result_lose_end_loop_body"] = resource.resultMotionOverride.loseEnd.bodyClip;
			overrideController["diva_cmn_login_idle_body"] = resource.loginMotionOverride.idle.bodyClip;
			for (int i = 0; i < resource.loginMotionOverride.reactions.Count; i++)
			{
				str.SetFormat("diva_cmn_login_reaction{0:D2}_begin_body", i + 1);
				overrideController[str.ToString()] = resource.loginMotionOverride.reactions[i].begin.bodyClip;
				str.SetFormat("diva_cmn_login_reaction{0:D2}_end_body", i + 1);
				overrideController[str.ToString()] = resource.loginMotionOverride.reactions[i].end.bodyClip;
			}
			overrideController["diva_cmn_join_start_body"] = resource.unlockMotionOverride.start.bodyClip;
			overrideController["diva_cmn_join_loop_body"] = resource.unlockMotionOverride.end.bodyClip;
			overrideController["diva_cmn_costume_start_body"] = resource.unlockCostumeMotionOverride.start.bodyClip;
			overrideController["diva_cmn_costume_pose_body"] = resource.unlockCostumeMotionOverride.pose.bodyClip;
			overrideController["diva_cmn_costume_loop_body"] = resource.unlockCostumeMotionOverride.end.bodyClip;
			for(int i = 0; i < DivaResource.MAX_PRESENT; i++)
			{
				str.SetFormat("diva_cmn_menu_present{0:D2}_body", i + 1);
				overrideController[str.ToString()] = resource.menuMotionOverride.present[i].main.bodyClip;
			}
		}

		// RVA: 0x11108D8 Offset: 0x11108D8 VA: 0x11108D8
		private void LateUpdate()
		{
			if(isStopFrame)
			{
				transform.localPosition = new Vector3(0, 0, 0);
				transform.localEulerAngles = new Vector3(0, 0, 0);
				transform.localScale = new Vector3(1, 1, 1);
				isStopFrame = false;
			}
		}

		//// RVA: 0x1110A10 Offset: 0x1110A10 VA: 0x1110A10
		//private void ChangeVisibilityCallback(bool isVisible) { }

		//// RVA: 0x110FAA8 Offset: 0x110FAA8 VA: 0x110FAA8
		public void Idle(string stateName = "")
		{
			if (string.IsNullOrEmpty(stateName))
				stateName = "idle";
			Anim_Play(stateName, 0);
			animator.speed = 1;
			this.StartCoroutineWatched(WaitUnlockBoneSpring(0));
		}

		//// RVA: 0x1110B60 Offset: 0x1110B60 VA: 0x1110B60
		public void IdleCrossFade(string stateName = "")
		{
			if (string.IsNullOrEmpty(stateName))
				stateName = "idle";
			animator.CrossFade(stateName, 0.07f);
			facialBlendAnimMediator.selfAnimator.Play(stateName, 0);
			facialBlendAnimMediator.selfAnimator.Play(stateName, 1);
		}

		//// RVA: 0x1110C90 Offset: 0x1110C90 VA: 0x1110C90
		public void SetBodyCrossFade(string stateName, float duration = 0.07f)
		{
			animator.CrossFade(stateName, duration);
		}

		//// RVA: 0x1110CCC Offset: 0x1110CCC VA: 0x1110CCC
		public void PlayFacialBlendAnimator(string stateName, int layerIndex)
		{
			facialBlendAnimMediator.selfAnimator.Play(stateName, layerIndex);
		}

		//// RVA: 0x1110D28 Offset: 0x1110D28 VA: 0x1110D28
		public bool IsCurrentBodyState(int hash)
		{
			return animator.GetCurrentAnimatorStateInfo(0).shortNameHash == hash;
		}

		//// RVA: 0x1110DB4 Offset: 0x1110DB4 VA: 0x1110DB4
		public void Result()
		{
			Anim_SetBool("res_breakTalkLoop", false);
			Anim_SetBool("res_goStart", false);
			Anim_Play("wait_loop", 0);
			isStopFrame = true;
			this.StartCoroutineWatched(WaitUnlockBoneSpring(0));
		}

		//// RVA: 0x1110E98 Offset: 0x1110E98 VA: 0x1110E98
		public void ResultAnimStart(bool specialAnim)
		{
			Anim_SetBool("res_breakTalkLoop", false);
			Anim_SetBool("res_goStart", true);
			facialBlendAnimMediator.selfAnimator.Play(specialAnim ? "start" : "lip_sync", 1);
			facialBlendAnimMediator.selfAnimator.Play("start", 0);
		}

		//// RVA: 0x1110FE8 Offset: 0x1110FE8 VA: 0x1110FE8
		public void ResultReactionLoopBreak()
		{
			Anim_SetBool("res_breakTalkLoop", true);
		}

		//// RVA: 0x1111054 Offset: 0x1111054 VA: 0x1111054
		//public void BattleResult() { }

		//// RVA: 0x1111058 Offset: 0x1111058 VA: 0x1111058
		//public void BattleResultAnimStart(bool isWin, bool isLeftSide) { }

		//[IteratorStateMachineAttribute] // RVA: 0x737848 Offset: 0x737848 VA: 0x737848
		//// RVA: 0x1111180 Offset: 0x1111180 VA: 0x1111180
		//private IEnumerator Co_BattleResultLoseRotation(float sec, float targetDeg) { }

		//// RVA: 0x1111254 Offset: 0x1111254 VA: 0x1111254
		//public void ResetBattleResultTransform() { }

		//// RVA: 0x1111314 Offset: 0x1111314 VA: 0x1111314
		public void LoginIdle()
		{
			Anim_SetInteger("login_reactionId", 0);
			Anim_Play("login_idle", 0);
			isStopFrame = true;
			this.StartCoroutineWatched(WaitUnlockBoneSpring(0));
		}

		//// RVA: 0x11113D8 Offset: 0x11113D8 VA: 0x11113D8
		public void LoginAnimStart(int reactionId = 1)
		{
			Anim_SetTrigger("login_toReaction");
			Anim_SetInteger("login_reactionId", reactionId);
			Anim_SetBool("login_breakTalkLoop", false);
			Anim_SetTrigger("login_toTalk");
			isStopFrame = true;
			UnlockBoneSpring(false, 0);
		}

		//// RVA: 0x11114BC Offset: 0x11114BC VA: 0x11114BC
		public void LoginReactionLoopBreak()
		{
			Anim_SetTrigger("login_toBreakReaction");
		}

		//// RVA: 0x1111524 Offset: 0x1111524 VA: 0x1111524
		public void LoginTalkLoopBreak()
		{
			Anim_SetBool("login_breakTalkLoop", true);
		}

		//// RVA: 0x1111590 Offset: 0x1111590 VA: 0x1111590
		public bool IsLoginIdle()
		{
			return animator.GetCurrentAnimatorStateInfo(0).fullPathHash == LoginIdleHash;
		}

		//// RVA: 0x11116A4 Offset: 0x11116A4 VA: 0x11116A4
		public void Reaction(int type)
		{
			Anim_SetTrigger("menu_toReaction");
			Anim_SetInteger("menu_reactionId", type);
			Anim_SetBool("menu_breakReactionLoop", false);
			isStopFrame = true;
			UnlockBoneSpring(false, 0);
		}

		//// RVA: 0x111176C Offset: 0x111176C VA: 0x111176C
		public void PlayDivaUnlockAnim()
		{
			facialBlendAnimMediator.selfAnimator.Play("start", 1);
			Anim_Play("join_start", 0);
			isStopFrame = true;
			this.StartCoroutineWatched(WaitUnlockBoneSpring(0));
		}

		//// RVA: 0x1111868 Offset: 0x1111868 VA: 0x1111868
		public bool IsMatchUnlockDivaAnimStep(eUnlockDivaAnimStep step)
		{
			int hash = Animator.StringToHash(step == 0 ? "body.sub_join.join_start" : "body.sub_join.join_loop");
			return animator.GetCurrentAnimatorStateInfo(0).fullPathHash == hash;
		}

		//// RVA: 0x1111974 Offset: 0x1111974 VA: 0x1111974
		//public void PlayUnlockCostumeAnim() { }

		//// RVA: 0x1111A70 Offset: 0x1111A70 VA: 0x1111A70
		//public void PlayUnlockPoseCostumeAnim() { }

		//// RVA: 0x1111B6C Offset: 0x1111B6C VA: 0x1111B6C
		//public void SetAnimationSpeed(float speed) { }

		//// RVA: 0x1111B74 Offset: 0x1111B74 VA: 0x1111B74
		//public bool IsMatchUnlockCostumeAnimStep(MenuDivaObject.eUnlockCostumeAnimStep step) { }

		//// RVA: 0x1111C6C Offset: 0x1111C6C VA: 0x1111C6C
		public float GetNormalizedTime()
		{
			return animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
		}

		//// RVA: 0x1111CE8 Offset: 0x1111CE8 VA: 0x1111CE8
		public void Talk(int type)
		{
			Anim_SetTrigger("menu_toTalk");
			Anim_SetInteger("menu_talkType", type);
			Anim_SetBool("menu_breakTalkLoop", false);
			isStopFrame = true;
			UnlockBoneSpring(false, 0);
		}

		//// RVA: 0x1111DB0 Offset: 0x1111DB0 VA: 0x1111DB0
		public void SimpleTalk(int type)
		{
			Anim_SetTrigger("menu_toSimpleTalk");
			Anim_SetInteger("menu_simpleTalkId", type);
			isStopFrame = true;
			UnlockBoneSpring(false, 0);
		}

		//// RVA: 0x1111E58 Offset: 0x1111E58 VA: 0x1111E58
		public void SetAnimInteger(string paramName, int value)
		{
			Anim_SetInteger(paramName, value);
		}

		//// RVA: 0x1111E60 Offset: 0x1111E60 VA: 0x1111E60
		public void ReactionLoopBreak()
		{
			Anim_SetBool("menu_breakReactionLoop", true);
		}

		//// RVA: 0x1111ECC Offset: 0x1111ECC VA: 0x1111ECC
		//public bool IsInTalkLoop() { }

		//// RVA: 0x1112020 Offset: 0x1112020 VA: 0x1112020
		public void TalkLoopBreak()
		{
			Anim_SetBool("menu_breakTalkLoop", true);
		}

		//// RVA: 0x111208C Offset: 0x111208C VA: 0x111208C
		public void TimezoneTalk(int type)
		{
			Anim_SetTrigger("menu_toTimezone");
			Anim_SetInteger("menu_timezoneId", type);
			isStopFrame = true;
			UnlockBoneSpring(false, 0);
		}

		//// RVA: 0x1112134 Offset: 0x1112134 VA: 0x1112134
		public void PlayAnimationPresent(int id)
		{
			Anim_SetTrigger("menu_toPresent");
			Anim_SetInteger("menu_presentId", id);
			Anim_SetBool("menu_toPresentLoopEnd", false);
			isStopFrame = true;
			UnlockBoneSpring(false, 0);
		}

		//// RVA: 0x11121FC Offset: 0x11121FC VA: 0x11121FC
		public void StopAnimationPresent()
		{
			Anim_SetBool("menu_toPresentLoopEnd", true);
		}
		
		//// RVA: 0x111263C Offset: 0x111263C VA: 0x111263C
		public MenuDivaGazeControl StartGazeControl()
		{
			MenuDivaGazeControl res = GetComponent<MenuDivaGazeControl>();
			if(res == null)
			{
				res = gameObject.AddComponent<MenuDivaGazeControl>();
				res.ControlData = gazeControlData;
				res.Initialize();
			}
			return res;
		}

		//// RVA: 0x1112774 Offset: 0x1112774 VA: 0x1112774
		public void FinishGazeControl()
		{
			MenuDivaGazeControl res = GetComponent<MenuDivaGazeControl>();
			if (res != null)
			{
				Destroy(res);
			}
		}

		//// RVA: 0x1112858 Offset: 0x1112858 VA: 0x1112858
		public void ChangeCostumeTexture(List<Material> mtlList, int colorId)
		{
			colorId_ = colorId;
			if(rendererDict.Count == 0)
			{
				StringBuilder str = new StringBuilder(64);
				divaPrefab.GetComponentsInChildren(rendererComponentList);
				for(int i = 0; i < rendererComponentList.Count; i++)
				{
					str.Set(rendererComponentList[i].material.name);
					str.Replace(" (Instance)", "");
					List<Renderer> r_;
					if(!rendererDict.TryGetValue(str.ToString().GetHashCode(), out r_))
					{
						r_ = new List<Renderer>();
						rendererDict.Add(str.ToString().GetHashCode(), r_);
					}
					r_.Add(rendererComponentList[i]);
				}
			}
			for (int i = 0; i < mtlList.Count; i++)
			{
				List<Renderer> r_;
				if (rendererDict.TryGetValue(mtlList[i].name.GetHashCode(), out r_))
				{
					for(int j = 0; j < r_.Count; j++)
					{
						r_[j].material = mtlList[i];
					}
				}
			}
		}

		// RVA: 0x1112E2C Offset: 0x1112E2C VA: 0x1112E2C Slot: 8
		protected override void SetupEffectObject(List<GameObject> a_effect)
		{
			base.SetupEffectObject(a_effect);
			SetEnableEffect(true, false);
		}

		// RVA: 0x1112E58 Offset: 0x1112E58 VA: 0x1112E58 Slot: 9
		protected override void SetupWind(GameObject a_wind, DivaResource.BoneSpringResource a_resource)
		{
			base.SetupWind(a_wind, a_resource);
			SetEnableWind(false, false);
		}
	}
}
