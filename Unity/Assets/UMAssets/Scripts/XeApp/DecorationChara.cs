using mcrs;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;
using XeApp.Game.Menu;

namespace XeApp
{
	public class DecorationChara : DecorationItemBase
	{
		public enum VoiceType
		{
			Intimacy = 0,
			Angry = 1,
			Glad = 2,
			PlushToy = 3,
			Num = 4,
		}

		[Flags] // RVA: 0x638290 Offset: 0x638290 VA: 0x638290
		public enum CollStatus // TypeDefIndex: 7348
		{
			None = 1,
			BgFloor = 2,
			DecoItem = 4,
		}

		private DecorationSerif m_serif; // 0x9C
		private DecorationSerif m_prevSerif; // 0xA0
		private static readonly string[] VoiceCueTbl = new string[4]
			{
				"intimacy_", "angry_", "happy_", "resnuigurumi_"
			}; // 0x0
		private bool m_isAnimationLoaded; // 0xA4
		private const string anim = "dc_chara_anim_{0:D2}";
		private DecorationCharaAnimController charaControl; // 0xA8
		private Animator animator; // 0xAC
		private ReactionPhrase reaction; // 0xB0
		private Pincher pincher; // 0xB4
		private Vector2 beginDragPos; // 0xB8
		private Vector2 beginDragOfs; // 0xC0
		private Vector2 prevGroundPos; // 0xC8
		private float enterTouchTime; // 0xD0
		private float dragThreshold; // 0xD4
		private float longTapThreshold; // 0xD8
		private JJOELIOGMKK_DivaIntimacyInfo viewIntimacyData; // 0xE4
		private bool isWaitAnim; // 0xE8
		private DecorationBgManager decorationBgManager; // 0xEC
		private DecorationCanvas decorationCanvas; // 0xF0
		public DecorationContoller decorationController; // 0xF4
		private bool m_isNoSerif; // 0xF8
		private SingleVoicePlayer m_voicePlayer; // 0xFC
		private List<Vector2> dirList = new List<Vector2>()
		{
			Vector2.right, Vector2.left, new Vector2(1, 1), new Vector2(-1, 1), new Vector2(1, -1), new Vector2(-1, -1)
		}; // 0x100
		private int callCnt; // 0x104

		public override bool IsLoaded { get { return base.IsLoaded && m_isAnimationLoaded; } } //0x1AC3B1C
		public Vector2 bottomOfs { get; private set; } // 0xDC
		//private IntimacyController intimacyController { get; } 0x1AC3B64
		//public Camera cam { get; } 0x1AC3B88
		public override Vector2 Position { get { return base.Position; } set {
				base.Position = value;
				if (m_serif != null)
					UpdateSerif();
			} } //0x1AC5CA4 0x1AC5D80
		public override int SortingOrder { get
			{
				return base.SortingOrder;
			}
			set
			{
				if(m_serif != null)
				{
					m_serif.SortingOrder = value - 1;
				}
				base.SortingOrder = value;
			} } //0x1AC609C 0x1AC61A0
		//public bool IsPlayVoice { get; } 0x1AC89E0

		// RVA: 0x1AC3BC8 Offset: 0x1AC3BC8 VA: 0x1AC3BC8
		private void OnEnable()
		{
			if (!IsLoaded)
				return;
			InitViewIntimacy();
		}

		// RVA: 0x1AC3D2C Offset: 0x1AC3D2C VA: 0x1AC3D2C
		private void OnApplicationPause(bool status)
		{
			ResetInputEvent();
		}

		//// RVA: 0x1AC3D30 Offset: 0x1AC3D30 VA: 0x1AC3D30
		private void ResetInputEvent()
		{
			EventSystem.current.enabled = false;
			EventSystem.current.enabled = true;
			ResetTouch();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AB798 Offset: 0x6AB798 VA: 0x6AB798
		//// RVA: 0x1AC4028 Offset: 0x1AC4028 VA: 0x1AC4028
		//private IEnumerator Co_LoadAnim() { }

		//// RVA: 0x1AC3BFC Offset: 0x1AC3BFC VA: 0x1AC3BFC
		private void InitViewIntimacy()
		{
			if(Setting.viewDecoItemData.GBJFNGCDKPM != 1)
			{
				viewIntimacyData = null;
				return;
			}
			viewIntimacyData = new JJOELIOGMKK_DivaIntimacyInfo();
			viewIntimacyData.KHEKNNFCAOI(Setting.viewDecoItemData.FPCGPGJOKNH);
			viewIntimacyData.HCDGELDHFHB(false);
		}

		//// RVA: 0x1AC40DC Offset: 0x1AC40DC VA: 0x1AC40DC Slot: 5
		//protected override Action PreLoadResource(GameObject spriteBase, EKLNMHFCAOI.FKGCBLHOOCL itemCategory, int id, DecorationItemBaseSetting setting, DecorationItemArgsBase args) { }

		//// RVA: 0x1AC422C Offset: 0x1AC422C VA: 0x1AC422C Slot: 6
		//protected override void PostLoadResource(GameObject spriteBase, EKLNMHFCAOI.FKGCBLHOOCL itemCategory, int id, DecorationItemBaseSetting setting, DecorationItemArgsBase args) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AB810 Offset: 0x6AB810 VA: 0x6AB810
		//// RVA: 0x1AC425C Offset: 0x1AC425C VA: 0x1AC425C
		//private IEnumerator Co_InitAfterLoadResource() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AB888 Offset: 0x6AB888 VA: 0x6AB888
		//// RVA: 0x1AC4308 Offset: 0x1AC4308 VA: 0x1AC4308 Slot: 8
		//protected override IEnumerator OnObjectCreated() { }

		//// RVA: 0x1AC43B4 Offset: 0x1AC43B4 VA: 0x1AC43B4 Slot: 9
		//protected override void PostInitController() { }

		//// RVA: 0x1AC43B8 Offset: 0x1AC43B8 VA: 0x1AC43B8
		//private DecorationChara.CollStatus AdjustPos(Vector2 pos, bool isUpdatePos = True, Nullable<Vector2> dstPos, bool willEscape = False) { }

		//// RVA: 0x1AC4A88 Offset: 0x1AC4A88 VA: 0x1AC4A88
		//private bool SearchWalkableSpace(ref Vector2 pos, DecorationItemBase hitItem, ref Vector2 dir, ref Vector2 escapeVec) { }

		// RVA: 0x1AC4F60 Offset: 0x1AC4F60 VA: 0x1AC4F60
		public void WaitAnimation()
		{
			if(charaControl != null)
			{
				charaControl.ResetState(true, true, false, true, true);
				charaControl.hasEscaped = false;
				charaControl.escapeDir = Vector2.zero;
				isWaitAnim = true;
			}
		}

		// RVA: 0x1AC526C Offset: 0x1AC526C VA: 0x1AC526C
		public void Update()
		{
			if (IsStop)
				return;
			if (charaControl == null)
				return;
			if(isWaitAnim)
			{
				isWaitAnim = false;
				return;
			}
			if(!pincher.IsFloating())
			{
				prevGroundPos = Position;
				charaControl.hasPinched = false;
			}
			else
			{
				if(charaControl.hasTouched)
				{
					Position -= decorationController.scrollController.DeltaPosition;
					beginDragOfs -= decorationController.scrollController.DeltaPosition;
					charaControl.hasEscaped = false;
					charaControl.escapeDir = Vector2.zero;
				}
			}
			bool willEscape = false;
			if(!charaControl.hasEscaped)
			{
				if (charaControl.escapeDir.sqrMagnitude == 0)
					willEscape = true;
			}
			CollStatus a = AdjustPos(Position, false, null, willEscape);
			if((a & CollStatus.DecoItem) == 0)
			{
				charaControl.hasEscaped = true;
				charaControl.escapeDir = Vector2.zero;
			}
			Vector2 p = charaControl.UpdateMotion(Position);
			Vector2 p2 = Position + p;
			if(!charaControl.hasEscaped)
			{
				Vector3 p3 = new Vector3();
				a = AdjustPos(Position, false, p3, false);
				if ((a & CollStatus.BgFloor) != 0)
				{
					if ((charaControl.coll | 2) == 2)
						charaControl.coll = 1;
				}
				else
					Position = p2;
			}
			else
			{
				Vector3 p3 = new Vector3();
				a = AdjustPos(Position, false, p3, false);
				if((a != CollStatus.None))
				{
					if ((charaControl.coll | 2) == 2)
						charaControl.coll = 1;
				}
				else
					Position = p2;
			}
			a = AdjustPos(Position, false, null, false);
			if((a & CollStatus.BgFloor) != 0)
			{
				if ((charaControl.coll | 2) == 2)
					charaControl.coll = 1;
			}
			if(pincher.IsFloating)
			{
				pincher.UpdateShadowPos();
			}
		}

		//// RVA: 0x1AC5B78 Offset: 0x1AC5B78 VA: 0x1AC5B78 Slot: 16
		//protected override void PreDestroy() { }

		//// RVA: 0x1AC5CA0 Offset: 0x1AC5CA0 VA: 0x1AC5CA0 Slot: 17
		//protected override void PostDestroy() { }

		// RVA: 0x1AC5FC0 Offset: 0x1AC5FC0 VA: 0x1AC5FC0 Slot: 20
		public override float GetOrderPositionY()
		{
			return Position.y + pincher.TargetHeight * Scale * -0.5f;
		}

		//// RVA: 0x1AC61D0 Offset: 0x1AC61D0 VA: 0x1AC61D0 Slot: 15
		//public override int GetSerifId() { }

		//// RVA: 0x1AC628C Offset: 0x1AC628C VA: 0x1AC628C
		//public void AttachSerif(DecorationSerif serif) { }

		//// RVA: 0x1AC5F18 Offset: 0x1AC5F18 VA: 0x1AC5F18
		private void UpdateSerif()
		{
			m_serif.Position = new Vector2(Position.x + Size.x, Position.y + Size.y * 0.5f);
		}

		//// RVA: 0x1AC6460 Offset: 0x1AC6460 VA: 0x1AC6460
		//public void NoSerif(bool isNoSerif) { }

		//// RVA: 0x1AC5B7C Offset: 0x1AC5B7C VA: 0x1AC5B7C
		//public void DetachSerif() { }

		//// RVA: 0x1AC6468 Offset: 0x1AC6468 VA: 0x1AC6468
		//public void DecideSerif() { }

		//// RVA: 0x1AC6530 Offset: 0x1AC6530 VA: 0x1AC6530
		//public void RollbackSerif() { }

		//// RVA: 0x1AC6710 Offset: 0x1AC6710 VA: 0x1AC6710
		//public void ShowSerif() { }

		//// RVA: 0x1AC6884 Offset: 0x1AC6884 VA: 0x1AC6884
		public void HideSerif()
		{
			if (m_serif != null)
				m_serif.Hide();
		}

		//// RVA: 0x1AC6940 Offset: 0x1AC6940 VA: 0x1AC6940
		//public void ShowReactionGlad() { }

		//// RVA: 0x1AC6A04 Offset: 0x1AC6A04 VA: 0x1AC6A04
		//public void ShowReactionAngry() { }

		//// RVA: 0x1AC67D4 Offset: 0x1AC67D4 VA: 0x1AC67D4
		public void HideReaction()
		{
			if (reaction != null)
				reaction.HideAll();
		}

		//// RVA: 0x1AC6AC8 Offset: 0x1AC6AC8 VA: 0x1AC6AC8
		//public void PlaySpecifiedReaction(DecorationCharaAnimController.ReactionSpecifiedType type) { }

		//// RVA: 0x1AC6D14 Offset: 0x1AC6D14 VA: 0x1AC6D14
		//public bool IsPlayReaction() { }

		//// RVA: 0x1AC6DD8 Offset: 0x1AC6DD8 VA: 0x1AC6DD8
		//public bool IsAttachSerif() { }

		//// RVA: 0x1AC6E64 Offset: 0x1AC6E64 VA: 0x1AC6E64
		//public bool IsChangeSerif() { }

		//// RVA: 0x1AC6F9C Offset: 0x1AC6F9C VA: 0x1AC6F9C Slot: 12
		//public override void Click() { }

		//// RVA: 0x1AC6FA0 Offset: 0x1AC6FA0 VA: 0x1AC6FA0 Slot: 11
		//public override void PointerDown(Vector2 touchPosition) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AB900 Offset: 0x6AB900 VA: 0x6AB900
		//// RVA: 0x1AC71A0 Offset: 0x1AC71A0 VA: 0x1AC71A0
		//private IEnumerator Co_DetectLongTap(Vector2 touchPosition) { }

		// RVA: 0x1AC7270 Offset: 0x1AC7270 VA: 0x1AC7270 Slot: 13
		public override void BeginDrag(Vector2 touchPosition)
		{
			prevGroundPos = Position;
			beginDragPos = DecorationConstants.TouchToScreen((decorationCanvas.m_decorationItemRootRect.parent.parent as RectTransform), touchPosition.x);
			beginDragOfs = Position - beginDragPos;
		}

		// RVA: 0x1AC75F8 Offset: 0x1AC75F8 VA: 0x1AC75F8 Slot: 14
		public override void Drag(Vector2 touchPosition)
		{
			Vector2 p = DecorationConstants.TouchToScreen((decorationCanvas.m_decorationItemRootRect.parent.parent as RectTransform), touchPosition.x);
			Vector2 d = p - beginDragPos;
			if(d.sqrMagnitude >= dragThreshold * dragThreshold)
			{
				if(!charaControl.isReaction)
				{
					if(!decorationCanvas.m_decorationItemManager.ReactingPlushToys)
					{
						if(pincher.IsFloating())
						{
							Position = p + beginDragPos;
							AdjustPos(Position, true, null, false);
							pincher.UpdateShadowPos();
							return;
						}
						charaControl.OnPinch();
						SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_GIFT_000);
						pincher.Pinch();
						pincher.UpdateShadowPos();
						SetMenuEnabled(false);
						return;
					}
				}
				ResetInputEvent();
			}
		}

		// RVA: 0x1AC7BE0 Offset: 0x1AC7BE0 VA: 0x1AC7BE0 Slot: 10
		public override void PointerUp()
		{
			if(Time.time - enterTouchTime < longTapThreshold)
			{
				if(!decorationCanvas.m_decorationItemManager.AnyCharaReacting())
				{
					if (!decorationCanvas.m_decorationItemManager.ReactingPlushToys)
					{
						bool old = charaControl.isReaction;
						charaControl.OnTap();
						if (old != charaControl.isReaction)
						{
							SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_HOME_000);
						}
					}
				}
			}
			ResetTouch();
		}

		//// RVA: 0x1AC3E0C Offset: 0x1AC3E0C VA: 0x1AC3E0C
		private void ResetTouch()
		{
			if (pincher == null)
				return;
			if (decorationController == null)
				return;
			if (charaControl == null)
				return;
			if(pincher.IsFloating())
			{
				SetMenuEnabled(true);
				SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_GIFT_001);
			}
			charaControl.hasTouched = false;
			pincher.Release();
			decorationController.scrollController.IsFollowTouch = true;
			IsTouch = false;
		}

		//// RVA: 0x1AC7A94 Offset: 0x1AC7A94 VA: 0x1AC7A94
		//private void SetMenuEnabled(bool enable) { }

		//// RVA: 0x1AC7FC4 Offset: 0x1AC7FC4 VA: 0x1AC7FC4
		//public void SettingPrevSerif() { }

		//// RVA: 0x1AC8058 Offset: 0x1AC8058 VA: 0x1AC8058 Slot: 27
		//public override void SetInfo(DAJBODHMLAB.MMLACIFMNBN.MHODOAJPNHD info) { }

		//// RVA: 0x1AC820C Offset: 0x1AC820C VA: 0x1AC820C
		//private bool IsLoadedIntimacyData() { }

		//// RVA: 0x1AC8308 Offset: 0x1AC8308 VA: 0x1AC8308
		//public void PrepareVoiceCueSheet(UnityAction onEndCallback) { }

		//// RVA: 0x1AC86D0 Offset: 0x1AC86D0 VA: 0x1AC86D0
		//public void RemoveVoiceCueSheet() { }

		//// RVA: 0x1AC86FC Offset: 0x1AC86FC VA: 0x1AC86FC
		//public bool IsReadyVoiceCueSheet() { }

		//// RVA: 0x1AC8824 Offset: 0x1AC8824 VA: 0x1AC8824
		//public void PlayVoice(DecorationChara.VoiceType type, int id = 0) { }

		//// RVA: 0x1AC89B4 Offset: 0x1AC89B4 VA: 0x1AC89B4
		//public void StopVoice() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6AB978 Offset: 0x6AB978 VA: 0x6AB978
		//// RVA: 0x1AC8F58 Offset: 0x1AC8F58 VA: 0x1AC8F58
		//private bool <Co_LoadAnim>b__37_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6AB988 Offset: 0x6AB988 VA: 0x6AB988
		//// RVA: 0x1AC9004 Offset: 0x1AC9004 VA: 0x1AC9004
		//private DecorationChara.CollStatus <Co_InitAfterLoadResource>b__41_0(Vector2 v) { }

		//[DebuggerHiddenAttribute] // RVA: 0x6AB998 Offset: 0x6AB998 VA: 0x6AB998
		//[CompilerGeneratedAttribute] // RVA: 0x6AB998 Offset: 0x6AB998 VA: 0x6AB998
		//// RVA: 0x1AC906C Offset: 0x1AC906C VA: 0x1AC906C
		//private bool <>n__0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6AB9C8 Offset: 0x6AB9C8 VA: 0x6AB9C8
		//// RVA: 0x1AC9074 Offset: 0x1AC9074 VA: 0x1AC9074
		//private bool <Co_DetectLongTap>b__77_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6AB9D8 Offset: 0x6AB9D8 VA: 0x6AB9D8
		//// RVA: 0x1AC90D8 Offset: 0x1AC90D8 VA: 0x1AC90D8
		//private void <Co_DetectLongTap>b__77_1(bool isLongTap) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6AB9E8 Offset: 0x6AB9E8 VA: 0x6AB9E8
		//// RVA: 0x1AC91A0 Offset: 0x1AC91A0 VA: 0x1AC91A0
		//private void <Co_DetectLongTap>b__77_2() { }
	}
}
