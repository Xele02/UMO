using mcrs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeSys;

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
		public Camera cam { get { return decorationController.scrollController.m_decorationCamera; } } //0x1AC3B88
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
		public bool IsPlayVoice { get { return m_voicePlayer.isPlaying; } } //0x1AC89E0

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
			EventSystem ev = EventSystem.current;
			ev.enabled = false;
			ev.enabled = true;
			ResetTouch();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AB798 Offset: 0x6AB798 VA: 0x6AB798
		//// RVA: 0x1AC4028 Offset: 0x1AC4028 VA: 0x1AC4028
		private IEnumerator Co_LoadAnim()
		{
			SpriteRenderer sr; // 0x14
			string cbn; // 0x18
			string bn; // 0x1C
			AssetBundleLoadAllAssetOperationBase op; // 0x20
			Animator animator; // 0x24

			//0x1AC9D70
			sr = m_spriteRenderer;
			if(sr == null)
				yield break;
			int chara_long_tap_threshold_milli = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA("chara_long_tap_threshold_milli", 2000);
			longTapThreshold = chara_long_tap_threshold_milli / 1000.0f;
			cbn = DecorationConstants.DecoAssetPath + string.Format(AssetPathFormat, "cmn");
			yield return AssetBundleManager.LoadAllAssetAsync(cbn);
			bn = DecorationConstants.DecoAssetPath + string.Format(AssetPathFormat, Id);
			op = AssetBundleManager.LoadAllAssetAsync(bn);
			yield return op;
			animator = sr.gameObject.AddComponent<Animator>();
			animator.runtimeAnimatorController = op.GetAsset<AnimatorOverrideController>(string.Format("dc_chara_anim_{0:D2}", Id));
			yield return new WaitUntil(() =>
			{
				//0x1AC8F58
				return m_spriteRenderer.sprite != null;
			});
			this.animator = animator;
			dragThreshold = sr.sprite.bounds.size.x * sr.transform.localScale.x * 0.125f;
			AssetBundleManager.UnloadAssetBundle(bn, false);
			AssetBundleManager.UnloadAssetBundle(cbn, false);
		}

		//// RVA: 0x1AC3BFC Offset: 0x1AC3BFC VA: 0x1AC3BFC
		private void InitViewIntimacy()
		{
			if(Setting.viewDecoItemData.GBJFNGCDKPM_Attribute != 1)
			{
				viewIntimacyData = null;
				return;
			}
			viewIntimacyData = new JJOELIOGMKK_DivaIntimacyInfo();
			viewIntimacyData.KHEKNNFCAOI(Setting.viewDecoItemData.FPCGPGJOKNH_CharaId);
			viewIntimacyData.HCDGELDHFHB(false);
		}

		//// RVA: 0x1AC40DC Offset: 0x1AC40DC VA: 0x1AC40DC Slot: 5
		protected override Action PreLoadResource(GameObject spriteBase, EKLNMHFCAOI.FKGCBLHOOCL_Category itemCategory, int id, DecorationItemBaseSetting setting, DecorationItemArgsBase args)
		{
			DecorationCharaArgs arg = args as DecorationCharaArgs;
			decorationBgManager = arg.decorationBgManager;
			decorationCanvas = arg.decorationCanvas;
			decorationController = arg.decorationController;
			return base.PreLoadResource(spriteBase, itemCategory, id, setting, args);
		}

		//// RVA: 0x1AC422C Offset: 0x1AC422C VA: 0x1AC422C Slot: 6
		protected override void PostLoadResource(GameObject spriteBase, EKLNMHFCAOI.FKGCBLHOOCL_Category itemCategory, int id, DecorationItemBaseSetting setting, DecorationItemArgsBase args)
		{
			m_isAnimationLoaded = false;
			this.StartCoroutineWatched(Co_InitAfterLoadResource());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AB810 Offset: 0x6AB810 VA: 0x6AB810
		//// RVA: 0x1AC425C Offset: 0x1AC425C VA: 0x1AC425C
		private IEnumerator Co_InitAfterLoadResource()
		{
			//0x1AC9654
			while(!base.IsLoaded)
				yield return null;
			yield return Co.R(Co_LoadAnim());
			int deco_chara_scale = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA("deco_chara_scale", 1000);
			m_object.transform.localScale = new Vector3(deco_chara_scale / 1000.0f, deco_chara_scale / 1000.0f, 1);
			pincher = Pincher.Instantiate(this, m_spriteRenderer);
			reaction = ReactionPhrase.Instantiate(m_spriteRenderer.transform, this);
			InitViewIntimacy();
			charaControl = gameObject.AddComponent<DecorationCharaAnimController>();
			charaControl.Init(this, animator, (Vector2 v) =>
			{
				//0x1AC9004
				decorationBgManager.GetFloor();
				return AdjustPos(v, false, null, false);
			});
			bottomOfs = new Vector2(0, Size.y * -0.5f);
			m_isAnimationLoaded = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AB888 Offset: 0x6AB888 VA: 0x6AB888
		//// RVA: 0x1AC4308 Offset: 0x1AC4308 VA: 0x1AC4308 Slot: 8
		protected override IEnumerator OnObjectCreated()
		{
			//0x1ACA524
			m_voicePlayer = m_object.AddComponent<SingleVoicePlayer>();
			bool isReadyCueSheet = false;
			m_voicePlayer.RequestChangeCueSheet(DecorationConstants.MakeCharaCueSheetName(ViewData.FPCGPGJOKNH_CharaId), () =>
			{
				//0x1AC922C
				isReadyCueSheet = true;
			});
			yield return new WaitUntil(() =>
			{
				//0x1AC9238
				return isReadyCueSheet;
			});
			m_voicePlayer.RemoveCueSheet();
		}

		//// RVA: 0x1AC43B4 Offset: 0x1AC43B4 VA: 0x1AC43B4 Slot: 9
		protected override void PostInitController()
		{
			return;
		}

		//// RVA: 0x1AC43B8 Offset: 0x1AC43B8 VA: 0x1AC43B8
		private CollStatus AdjustPos(Vector2 pos, bool isUpdatePos = true, Vector2? dstPos = null, bool willEscape = false)
		{
			if (dstPos.HasValue)
				pos = dstPos.Value;
			CollStatus res = CollStatus.None;
			bool b1 = false;
			DecorationItemBase hitItem = null;
			bool b2 = decorationCanvas.ItemManager.HitCheckThinkness(this, pos, out hitItem);
			if (b2)
			{
				res |= CollStatus.DecoItem;
				b1 = willEscape;
			}
			if (b2 && b1)
			{
				int a = -1;
				Vector2? r1 = null;
				for(int i = 0; i < dirList.Count; i++)
				{
					Vector2 v = dirList[i];
					Vector2 v2 = Vector2.zero;
					if (SearchWalkableSpace(ref pos, hitItem, ref v, ref v2))
					{
						if(!r1.HasValue || r1.Value.sqrMagnitude > v2.sqrMagnitude)
						{
							r1 = v2;
							a = i;
						}
					}
				}
				if (a < 0)
					charaControl.escapeDir = Vector2.zero;
				else
				{
					charaControl.escapeDir = dirList[a];
				}
				res = CollStatus.None | CollStatus.DecoItem;
			}
			if(decorationBgManager.CheckAdjustPosition(this, ref pos))
			{
				if(isUpdatePos)
				{
					Position = pos;
				}
				res |= CollStatus.BgFloor;
			}
			return res;
		}

		//// RVA: 0x1AC4A88 Offset: 0x1AC4A88 VA: 0x1AC4A88
		private bool SearchWalkableSpace(ref Vector2 pos, DecorationItemBase hitItem, ref Vector2 dir, ref Vector2 escapeVec)
		{
			callCnt++;
			DecorationItemBase hitItem2 = null;
			if (hitItem != null)
			{
				Vector2 v = dir * (hitItem.Size * 0.5f + Size) - dir * (pos - hitItem.Position).magnitude;
				escapeVec += v;
				if(!decorationCanvas.ItemManager.HitCheckThinkness(this, v + pos, out hitItem2))
				{
					callCnt = 0;
					Vector2 v2 = v + pos;
					return !decorationBgManager.CheckAdjustPosition(this, ref v2);
				}
				if(callCnt <= decorationCanvas.ItemManager.GetItemCount())
				{
					Vector2 v2 = v + pos;
					return SearchWalkableSpace(ref v2, hitItem2, ref dir, ref escapeVec);
				}
			}
			callCnt = 0;
			return false;
		}

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
			if(!pincher.IsFloating)
			{
				prevGroundPos = Position;
				charaControl.OnGround();
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
				a = AdjustPos(Position, false, p2, false);
				if ((a & CollStatus.BgFloor) != 0)
				{
					charaControl.OnCollide(false);
				}
				else
					Position = p2;
			}
			else
			{
				a = AdjustPos(Position, false, p2, false);
				if((a != CollStatus.None))
				{
					charaControl.OnCollide(false);
				}
				else
					Position = p2;
			}
			a = AdjustPos(Position, true, null, false);
			if((a & CollStatus.BgFloor) != 0)
			{
				charaControl.OnCollide(false);
			}
			if(pincher.IsFloating)
			{
				pincher.UpdateShadowPos();
			}
		}

		//// RVA: 0x1AC5B78 Offset: 0x1AC5B78 VA: 0x1AC5B78 Slot: 16
		protected override void PreDestroy()
		{
			DetachSerif();
		}

		//// RVA: 0x1AC5CA0 Offset: 0x1AC5CA0 VA: 0x1AC5CA0 Slot: 17
		protected override void PostDestroy()
		{
			return;
		}

		// RVA: 0x1AC5FC0 Offset: 0x1AC5FC0 VA: 0x1AC5FC0 Slot: 20
		public override float GetOrderPositionY()
		{
			return Position.y + pincher.TargetHeight * Scale * -0.5f;
		}

		//// RVA: 0x1AC61D0 Offset: 0x1AC61D0 VA: 0x1AC61D0 Slot: 15
		public override int GetSerifId()
		{
			return m_serif != null && !m_isNoSerif ? m_serif.Id : 0;
		}

		//// RVA: 0x1AC628C Offset: 0x1AC628C VA: 0x1AC628C
		public void AttachSerif(DecorationSerif serif)
		{
			if(m_prevSerif != m_serif)
			{
				m_serif.Destory();
			}
			m_serif = serif;
			serif.SortingOrder = SortingOrder;
			UpdateSerif();
		}

		//// RVA: 0x1AC5F18 Offset: 0x1AC5F18 VA: 0x1AC5F18
		private void UpdateSerif()
		{
			m_serif.Position = new Vector2(Position.x + Size.x, Position.y + Size.y * 0.5f);
		}

		//// RVA: 0x1AC6460 Offset: 0x1AC6460 VA: 0x1AC6460
		public void NoSerif(bool isNoSerif)
		{
			m_isNoSerif = isNoSerif;
		}

		//// RVA: 0x1AC5B7C Offset: 0x1AC5B7C VA: 0x1AC5B7C
		public void DetachSerif()
		{
			if(m_serif != null)
			{
				m_serif.Destory();
				m_serif = null;
			}
			if(m_prevSerif != null)
			{
				m_prevSerif.Destory();
				m_prevSerif = null;
			}
		}

		//// RVA: 0x1AC6468 Offset: 0x1AC6468 VA: 0x1AC6468
		public void DecideSerif()
		{
			if(m_isNoSerif)
				DetachSerif();
			if(m_prevSerif != null)
			{
				m_prevSerif.Destory();
				m_prevSerif = null;
			}
		}

		//// RVA: 0x1AC6530 Offset: 0x1AC6530 VA: 0x1AC6530
		public void RollbackSerif()
		{
			if(m_serif == null && m_prevSerif == null)
				return;
			if(m_prevSerif == null)
			{
				DetachSerif();
				return;
			}
			if(m_serif != null)
			{
				if(m_serif.Id == m_prevSerif.Id)
					return;
			}
			m_serif.Destory();
			m_serif = m_prevSerif;
			UpdateSerif();
		}

		//// RVA: 0x1AC6710 Offset: 0x1AC6710 VA: 0x1AC6710
		public void ShowSerif()
		{
			HideReaction();
			if(m_serif != null)
				m_serif.Show();
		}

		//// RVA: 0x1AC6884 Offset: 0x1AC6884 VA: 0x1AC6884
		public void HideSerif()
		{
			if (m_serif != null)
				m_serif.Hide();
		}

		//// RVA: 0x1AC6940 Offset: 0x1AC6940 VA: 0x1AC6940
		public void ShowReactionGlad()
		{
			HideReaction();
			HideSerif();
			if (reaction != null)
				reaction.SetGlad(true);
		}

		//// RVA: 0x1AC6A04 Offset: 0x1AC6A04 VA: 0x1AC6A04
		public void ShowReactionAngry()
		{
			HideReaction();
			HideSerif();
			if (reaction != null)
				reaction.SetAngry(true);
		}

		//// RVA: 0x1AC67D4 Offset: 0x1AC67D4 VA: 0x1AC67D4
		public void HideReaction()
		{
			if (reaction != null)
				reaction.HideAll();
		}

		//// RVA: 0x1AC6AC8 Offset: 0x1AC6AC8 VA: 0x1AC6AC8
		public void PlaySpecifiedReaction(DecorationCharaAnimController.ReactionSpecifiedType type)
		{
			if(charaControl != null)
				charaControl.AnimReactionSpecified(type);
		}

		//// RVA: 0x1AC6D14 Offset: 0x1AC6D14 VA: 0x1AC6D14
		public bool IsPlayReaction()
		{
			if (charaControl != null)
				return charaControl.isReaction;
			return false;
		}

		//// RVA: 0x1AC6DD8 Offset: 0x1AC6DD8 VA: 0x1AC6DD8
		//public bool IsAttachSerif() { }

		//// RVA: 0x1AC6E64 Offset: 0x1AC6E64 VA: 0x1AC6E64
		public bool IsChangeSerif()
		{
			if(m_prevSerif != null || !m_isNoSerif)
			{
				if(m_prevSerif != null && !m_isNoSerif)
				{
					if(m_prevSerif.Id != m_serif.Id)
						return true;
					return false;
				}
				return true;
			}
			return false;
		}

		//// RVA: 0x1AC6F9C Offset: 0x1AC6F9C VA: 0x1AC6F9C Slot: 12
		public override void Click()
		{
			return;
		}

		//// RVA: 0x1AC6FA0 Offset: 0x1AC6FA0 VA: 0x1AC6FA0 Slot: 11
		public override void PointerDown(Vector2 touchPosition)
		{
			IsTouch = true;
			enterTouchTime = Time.time;
			if(charaControl != null)
			{
				charaControl.OnTouchEnter();
			}
			decorationController.scrollController.IsFollowTouch = false;
			if(CheckEnableControl(ControlType.LongTap))
			{
				this.StartCoroutineWatched(Co_DetectLongTap(touchPosition));
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AB900 Offset: 0x6AB900 VA: 0x6AB900
		//// RVA: 0x1AC71A0 Offset: 0x1AC71A0 VA: 0x1AC71A0
		private IEnumerator Co_DetectLongTap(Vector2 touchPosition)
		{
			//0x1AC9244
			while(Mathf.Abs(enterTouchTime - Time.time) <= longTapThreshold)
			{
				if(!charaControl.hasTouched)
					yield break;
				if(pincher.IsFloating)
					yield break;
				yield return null;
			}
			if(IsLoadedIntimacyData())
			{
				if(decorationCanvas.m_intimacyController.CheckIntimacyDeco(viewIntimacyData, this))
				{
					if(!decorationCanvas.ItemManager.ReactingPlushToys)
					{
						if(charaControl.OnBeginIntimacyCheck())
						{
							decorationCanvas.m_intimacyController.TouchDecoCharactor(viewIntimacyData, this, touchPosition, () =>
							{
								//0x1AC9074
								if(charaControl.hasTouched)
									return !charaControl.hasPinched;
								return false;
							}, (bool isLongTap) =>
							{
								//0x1AC90D8
								if(!isLongTap)
								{
									m_decoCanvas.m_intimacyController.DetachDeco();
								}
								else
								{
									charaControl.OnLongTap();
									m_decoCanvas.EnableItemController(DecorationItemManager.EnableControlType.None);
									m_decoCanvas.EnableCanvasController(false);
								}
							}, () =>
							{
								//0x1AC91A0
								m_decoCanvas.m_intimacyController.DetachDeco();
								m_decoCanvas.EnableItemController(DecorationItemManager.EnableControlType.Unique);
								m_decoCanvas.EnableCanvasController(true);
							});
						}
					}
				}
			}
		}

		// RVA: 0x1AC7270 Offset: 0x1AC7270 VA: 0x1AC7270 Slot: 13
		public override void BeginDrag(Vector2 touchPosition)
		{
			prevGroundPos = Position;
			beginDragPos = DecorationConstants.TouchToScreen(touchPosition, decorationCanvas.GetItemRootRectTransform().parent.parent as RectTransform);
			beginDragOfs = Position - beginDragPos;
		}

		// RVA: 0x1AC75F8 Offset: 0x1AC75F8 VA: 0x1AC75F8 Slot: 14
		public override void Drag(Vector2 touchPosition)
		{
			Vector2 p = DecorationConstants.TouchToScreen(touchPosition, decorationCanvas.GetItemRootRectTransform().parent.parent as RectTransform);
			Vector2 d = p - beginDragPos;
			if(d.sqrMagnitude >= dragThreshold * dragThreshold)
			{
				if(!charaControl.isReaction)
				{
					if(!decorationCanvas.ItemManager.ReactingPlushToys)
					{
						if(pincher.IsFloating)
						{
							Position = p + beginDragOfs;
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
				if(!decorationCanvas.ItemManager.AnyCharaReacting())
				{
					if (!decorationCanvas.ItemManager.ReactingPlushToys)
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
			if(pincher.IsFloating)
			{
				SetMenuEnabled(true);
				SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_GIFT_001);
			}
			charaControl.OnTouchUp();
			pincher.Release();
			decorationController.scrollController.IsFollowTouch = true;
			IsTouch = false;
		}

		//// RVA: 0x1AC7A94 Offset: 0x1AC7A94 VA: 0x1AC7A94
		private void SetMenuEnabled(bool enable)
		{
			DecoScene s = MenuScene.Instance.GetCurrentTransitionRoot() as DecoScene;
			if(s != null)
			{
				s.MenuEnable(enable);
			}
		}

		//// RVA: 0x1AC7FC4 Offset: 0x1AC7FC4 VA: 0x1AC7FC4
		public void SettingPrevSerif()
		{
			m_prevSerif = m_serif;
			m_isNoSerif = m_serif == null;
		}

		//// RVA: 0x1AC8058 Offset: 0x1AC8058 VA: 0x1AC8058 Slot: 27
		public override void SetInfo(DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.MHODOAJPNHD info)
		{
			base.SetInfo(info);
			if(Setting.InitWord != 0)
				return;
			DetachSerif();
		}

		//// RVA: 0x1AC820C Offset: 0x1AC820C VA: 0x1AC820C
		private bool IsLoadedIntimacyData()
		{
			if(viewIntimacyData == null)
				return false;
			return decorationCanvas.m_intimacyController != null && !decorationCanvas.m_intimacyController.IsLoading();
		}

		//// RVA: 0x1AC8308 Offset: 0x1AC8308 VA: 0x1AC8308
		public void PrepareVoiceCueSheet(UnityAction onEndCallback)
		{
			decorationCanvas.ItemManager.RemoveOtherCharaVoiceCueSheet(this);
			m_voicePlayer.RequestChangeCueSheet(DecorationConstants.MakeCharaCueSheetName(ViewData.FPCGPGJOKNH_CharaId), onEndCallback);
		}

		//// RVA: 0x1AC86D0 Offset: 0x1AC86D0 VA: 0x1AC86D0
		public void RemoveVoiceCueSheet()
		{
			m_voicePlayer.RemoveCueSheet();
		}

		//// RVA: 0x1AC86FC Offset: 0x1AC86FC VA: 0x1AC86FC
		public bool IsReadyVoiceCueSheet()
		{
			if(m_voicePlayer.source != null)
			{
				return m_voicePlayer.source.cueSheet != "";
			}
			return false;
		}

		//// RVA: 0x1AC8824 Offset: 0x1AC8824 VA: 0x1AC8824
		public void PlayVoice(VoiceType type, int id = 0)
		{
			StringBuilder str = new StringBuilder(32);
			str.SetFormat("{0:D3}", id);
			m_voicePlayer.Play(VoiceCueTbl[(int)type] + str.ToString());
		}

		//// RVA: 0x1AC89B4 Offset: 0x1AC89B4 VA: 0x1AC89B4
		public void StopVoice()
		{
			m_voicePlayer.Stop();
		}

		//[DebuggerHiddenAttribute] // RVA: 0x6AB998 Offset: 0x6AB998 VA: 0x6AB998
		//[CompilerGeneratedAttribute] // RVA: 0x6AB998 Offset: 0x6AB998 VA: 0x6AB998
		//// RVA: 0x1AC906C Offset: 0x1AC906C VA: 0x1AC906C
		//private bool <>n__0() { }

		public void LateUpdate()
		{
#if UNITY_EDITOR || UNITY_STANDALONE
			if (m_spriteRenderer != null && m_spriteRenderer.material != null)
				BundleShaderInfo.Instance.FixMaterialShader(m_spriteRenderer.material);
#endif
		}
	}
}
