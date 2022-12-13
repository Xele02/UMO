using XeApp.Game.Menu;
using UnityEngine;
using System.Collections.Generic;

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
		//public bool IsIdleAnim { get; private set; } 0x1112268 0x111237C
		//public bool IsFacialIdelAnim { get; private set; } 0x1112380 0x1112564
		//public bool IsInTransition { get; } 0x1112568
		//public bool IsInFacialTransition { get; } 0x1112598

		// RVA: 0x110F3D8 Offset: 0x110F3D8 VA: 0x110F3D8 Slot: 6
		protected override void SetupCustomComponents(DivaResource resource)
		{
			!!!
		}

		// RVA: 0x110FB80 Offset: 0x110FB80 VA: 0x110FB80 Slot: 5
		protected override void OverrideCustomAnimation(DivaResource resource) {!!! }

		// RVA: 0x11108D8 Offset: 0x11108D8 VA: 0x11108D8
		private void LateUpdate() {!!! }

		//// RVA: 0x1110A10 Offset: 0x1110A10 VA: 0x1110A10
		//private void ChangeVisibilityCallback(bool isVisible) { }

		//// RVA: 0x110FAA8 Offset: 0x110FAA8 VA: 0x110FAA8
		//public void Idle(string stateName = "") { }

		//// RVA: 0x1110B60 Offset: 0x1110B60 VA: 0x1110B60
		//public void IdleCrossFade(string stateName = "") { }

		//// RVA: 0x1110C90 Offset: 0x1110C90 VA: 0x1110C90
		//public void SetBodyCrossFade(string stateName, float duration = 0,07) { }

		//// RVA: 0x1110CCC Offset: 0x1110CCC VA: 0x1110CCC
		//public void PlayFacialBlendAnimator(string stateName, int layerIndex) { }

		//// RVA: 0x1110D28 Offset: 0x1110D28 VA: 0x1110D28
		//public bool IsCurrentBodyState(int hash) { }

		//// RVA: 0x1110DB4 Offset: 0x1110DB4 VA: 0x1110DB4
		//public void Result() { }

		//// RVA: 0x1110E98 Offset: 0x1110E98 VA: 0x1110E98
		//public void ResultAnimStart(bool specialAnim) { }

		//// RVA: 0x1110FE8 Offset: 0x1110FE8 VA: 0x1110FE8
		//public void ResultReactionLoopBreak() { }

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
		//public void LoginIdle() { }

		//// RVA: 0x11113D8 Offset: 0x11113D8 VA: 0x11113D8
		//public void LoginAnimStart(int reactionId = 1) { }

		//// RVA: 0x11114BC Offset: 0x11114BC VA: 0x11114BC
		//public void LoginReactionLoopBreak() { }

		//// RVA: 0x1111524 Offset: 0x1111524 VA: 0x1111524
		//public void LoginTalkLoopBreak() { }

		//// RVA: 0x1111590 Offset: 0x1111590 VA: 0x1111590
		//public bool IsLoginIdle() { }

		//// RVA: 0x11116A4 Offset: 0x11116A4 VA: 0x11116A4
		//public void Reaction(int type) { }

		//// RVA: 0x111176C Offset: 0x111176C VA: 0x111176C
		//public void PlayDivaUnlockAnim() { }

		//// RVA: 0x1111868 Offset: 0x1111868 VA: 0x1111868
		//public bool IsMatchUnlockDivaAnimStep(MenuDivaObject.eUnlockDivaAnimStep step) { }

		//// RVA: 0x1111974 Offset: 0x1111974 VA: 0x1111974
		//public void PlayUnlockCostumeAnim() { }

		//// RVA: 0x1111A70 Offset: 0x1111A70 VA: 0x1111A70
		//public void PlayUnlockPoseCostumeAnim() { }

		//// RVA: 0x1111B6C Offset: 0x1111B6C VA: 0x1111B6C
		//public void SetAnimationSpeed(float speed) { }

		//// RVA: 0x1111B74 Offset: 0x1111B74 VA: 0x1111B74
		//public bool IsMatchUnlockCostumeAnimStep(MenuDivaObject.eUnlockCostumeAnimStep step) { }

		//// RVA: 0x1111C6C Offset: 0x1111C6C VA: 0x1111C6C
		//public float GetNormalizedTime() { }

		//// RVA: 0x1111CE8 Offset: 0x1111CE8 VA: 0x1111CE8
		//public void Talk(int type) { }

		//// RVA: 0x1111DB0 Offset: 0x1111DB0 VA: 0x1111DB0
		//public void SimpleTalk(int type) { }

		//// RVA: 0x1111E58 Offset: 0x1111E58 VA: 0x1111E58
		//public void SetAnimInteger(string paramName, int value) { }

		//// RVA: 0x1111E60 Offset: 0x1111E60 VA: 0x1111E60
		//public void ReactionLoopBreak() { }

		//// RVA: 0x1111ECC Offset: 0x1111ECC VA: 0x1111ECC
		//public bool IsInTalkLoop() { }

		//// RVA: 0x1112020 Offset: 0x1112020 VA: 0x1112020
		//public void TalkLoopBreak() { }

		//// RVA: 0x111208C Offset: 0x111208C VA: 0x111208C
		//public void TimezoneTalk(int type) { }

		//// RVA: 0x1112134 Offset: 0x1112134 VA: 0x1112134
		//public void PlayAnimationPresent(int id) { }

		//// RVA: 0x11121FC Offset: 0x11121FC VA: 0x11121FC
		//public void StopAnimationPresent() { }
		
		//// RVA: 0x111263C Offset: 0x111263C VA: 0x111263C
		//public MenuDivaGazeControl StartGazeControl() { }

		//// RVA: 0x1112774 Offset: 0x1112774 VA: 0x1112774
		//public void FinishGazeControl() { }

		//// RVA: 0x1112858 Offset: 0x1112858 VA: 0x1112858
		//public void ChangeCostumeTexture(List<Material> mtlList, int colorId) { }

		// RVA: 0x1112E2C Offset: 0x1112E2C VA: 0x1112E2C Slot: 8
		protected override void SetupEffectObject(List<GameObject> a_effect) {!!! }

		// RVA: 0x1112E58 Offset: 0x1112E58 VA: 0x1112E58 Slot: 9
		protected override void SetupWind(GameObject a_wind, DivaResource.BoneSpringResource a_resource) { !!!}
	}
}
