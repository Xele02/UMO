using System;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Menu;
using XeSys;

namespace XeApp
{
	public class DecorationItemManager : MonoBehaviour
	{
		private enum DecorationAnimationType
		{
			Animator = 0,
			Animation = 1,
			Flash = 2,
			Program = 3,
			None = 4,
		}

		public enum EnableControlType
		{
			Edit = 0,
			Unique = 1,
			ScreenShot = 2,
			None = 3,
		}

		public enum PostType
		{
			Posted = 0,
			DragNewPost = 1,
			TapNewPost = 2,
			None = 3,
		}

		private class EditRestoreData
		{
			public Vector2 postion; // 0x8
			public int order; // 0x10
			public bool flip; // 0x14
			public bool isNewPost; // 0x15
			public int statusFlag; // 0x18
		}

		public enum LayoutCachaName
		{
			SpItemLeveupIcon = 0,
			SpItemPopIcon = 1,
		}

		private GameObject m_spriteBase; // 0xC
		private DecorationCanvas m_decorationCanvas; // 0x10
		//private List<KDKFHGHGFEK> m_decoItemList; // 0x14
		private List<DecorationItemBase> m_decorationItemList = new List<DecorationItemBase>(); // 0x18
		private bool m_isClearing; // 0x1C
		private DecorationItemControllerLayout m_decorationItemControllerLayout; // 0x20
		private RectTransform m_CanvasRect; // 0x24
		private Vector2 m_moveBeginOffsetPosition; // 0x28
		public Action<DecorationItemBase> OnMoveCallback; // 0x30
		public Action<DecorationItemBase> OnSelectCallback; // 0x34
		public Action OnLeaveCallback; // 0x38
		public Action<DecorationItemBase> PointerDownCallback; // 0x3C
		public Action<DecorationItemBase> ItemClickCallback; // 0x40
		public Action<DecorationItemBase> SerifButtonCallback; // 0x44
		public Action PriorityButtonCallback; // 0x48
		public Action FlipButtonCallback; // 0x4C
		public Action<DecorationItemBase> CreateItemCallback; // 0x50
		public Action<DecorationItemBase, bool> ChangeKiraCallback; // 0x54
		private Transform m_itemRootTransform; // 0x58
		private EditRestoreData m_editRestoreData = new EditRestoreData(); // 0x5C
		private Dictionary<int, List<GameObject>> m_layoutCacheDict = new Dictionary<int, List<GameObject>>(); // 0x60
		private int[] m_priorityOffset = new int[4]; // 0x64
		private bool m_isNewPostSetting; // 0x68
		private bool m_isNewPostSettingBegin; // 0x69
		private DecorationItemBase m_editItem; // 0x6C
		private bool IsSerifResource; // 0x70
		private DecorationScrollController m_scrollController; // 0x74
		private bool m_isSelectItem; // 0x78
		private bool m_isWaitingChara; // 0x79
		private bool m_isApplicationPause; // 0x7A
		private List<DecorationItemBase> m_tapSetItemList = new List<DecorationItemBase>(); // 0x84
		public bool ReactingPlushToys; // 0x88

		//public GameObject SpriteBase { get; } 0x1ABB6E8
		public EnableControlType m_controlType { get; private set; } // 0x7C
		public bool IsLoadedItemManager { get; private set; } // 0x80

		//// RVA: 0x1AB9C4C Offset: 0x1AB9C4C VA: 0x1AB9C4C
		//public void Create(GameObject canvasPrefab, DecorationCanvas canvas) { }

		//// RVA: 0x1AD6348 Offset: 0x1AD6348 VA: 0x1AD6348
		//private void InitOrderOffset() { }

		//// RVA: 0x1AD6530 Offset: 0x1AD6530 VA: 0x1AD6530
		//public void InitResource(GameObject canvasPrefab) { }

		//// RVA: 0x1AC1908 Offset: 0x1AC1908 VA: 0x1AC1908
		//public void SetItemControllerLayout(DecorationItemControllerLayout layout) { }

		//// RVA: 0x1ABB4D0 Offset: 0x1ABB4D0 VA: 0x1ABB4D0
		//public void LoadItem(int resourceId, Transform parent, DecorationItemBaseSetting setting, DecorationItemManager.PostType postType, DecorationItemArgsBase args) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AC228 Offset: 0x6AC228 VA: 0x6AC228
		//// RVA: 0x1AD6A24 Offset: 0x1AD6A24 VA: 0x1AD6A24
		//public IEnumerator Co_LoadItem(DecorationItemBase item, int resourceId, Transform parent, DecorationItemBaseSetting setting, DecorationItemArgsBase args) { }

		//// RVA: 0x1AD6B0C Offset: 0x1AD6B0C VA: 0x1AD6B0C
		//private void SetTapPostion(DecorationItemBase item) { }

		//// RVA: 0x1ABCFB0 Offset: 0x1ABCFB0 VA: 0x1ABCFB0
		//public void TapSetItemClear() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AC2A0 Offset: 0x6AC2A0 VA: 0x6AC2A0
		//// RVA: 0x1AC1DB4 Offset: 0x1AC1DB4 VA: 0x1AC1DB4
		//public IEnumerator Co_CreateLayoutCache() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AC318 Offset: 0x6AC318 VA: 0x6AC318
		//// RVA: 0x1AD7320 Offset: 0x1AD7320 VA: 0x1AD7320
		//private IEnumerator Co_CreateLayoutCache(DecorationItemManager.LayoutCachaName name, int count) { }

		//// RVA: 0x1AD73DC Offset: 0x1AD73DC VA: 0x1AD73DC
		//public GameObject AllocCache(DecorationItemManager.LayoutCachaName name) { }

		//// RVA: 0x1AD74E0 Offset: 0x1AD74E0 VA: 0x1AD74E0
		//public void FreeCache(DecorationItemManager.LayoutCachaName name, GameObject go) { }

		//// RVA: 0x1ABF134 Offset: 0x1ABF134 VA: 0x1ABF134
		//public int InitSortingOrder(DecorationItemBaseSetting.PriorityControlType priorityControlType) { }

		//// RVA: 0x1AD7624 Offset: 0x1AD7624 VA: 0x1AD7624
		//private int BaseSortingOrder(DecorationItemBaseSetting.PriorityControlType priorityControlType) { }

		//// RVA: 0x1AD673C Offset: 0x1AD673C VA: 0x1AD673C
		//private void PreLoadItem(Transform parent) { }

		//// RVA: 0x1AD766C Offset: 0x1AD766C VA: 0x1AD766C
		//private void InitItem(DecorationItemBase item) { }

		//// RVA: 0x1AD791C Offset: 0x1AD791C VA: 0x1AD791C
		//private void AddItem(DecorationItemBase item) { }

		//// RVA: 0x1AD79BC Offset: 0x1AD79BC VA: 0x1AD79BC
		//private void MoveBegin(DecorationItemBase item, Vector2 touchPostion) { }

		//// RVA: 0x1AD79D4 Offset: 0x1AD79D4 VA: 0x1AD79D4
		private void MoveBeginCallback(DecorationItemBase item, Vector2 touchPostion)
		{
			if(m_controlType == EnableControlType.Edit)
			{
				if(item.CanEdit)
				{
					if(!item.Lock)
					{
						m_moveBeginOffsetPosition = item.Position - DecorationConstants.TouchToScreen(touchPostion, m_CanvasRect);
						OnMoveCallback(item);
					}
				}
			}
			else if(item.CheckEnableControl(DecorationItemBase.ControlType.Drag))
			{
				item.BeginDrag(touchPostion);
			}
		}

		//// RVA: 0x1AD7B90 Offset: 0x1AD7B90 VA: 0x1AD7B90
		//private void Select(DecorationItemBase item) { }

		//// RVA: 0x1AD7C40 Offset: 0x1AD7C40 VA: 0x1AD7C40
		//private void SelectCallback(DecorationItemBase item, Vector2 touchPosition) { }

		//// RVA: 0x1AD7D84 Offset: 0x1AD7D84 VA: 0x1AD7D84
		private void ShowDecorationItemController(DecorationItemBase item)
		{
			m_decorationItemControllerLayout.Show(item, GetFrameButtonType(item));
		}

		//// RVA: 0x1AD7E70 Offset: 0x1AD7E70 VA: 0x1AD7E70
		//private void Move(DecorationItemBase item, Vector2 touchPostion) { }

		//// RVA: 0x1AD7E88 Offset: 0x1AD7E88 VA: 0x1AD7E88
		public void MoveCallback(DecorationItemBase item, Vector2 touchPosition)
		{
			if(m_controlType == EnableControlType.Edit)
			{
				if(item.CanEdit)
				{
					if(!item.Lock)
					{
						item.IsMoved = true;
						item.Position = DecorationConstants.TouchToScreen(touchPosition, m_CanvasRect) + m_moveBeginOffsetPosition;
						OnMoveCallback(item);
						m_decorationItemControllerLayout.UpdateFramePosition(item);
					}
				}
			}
			else if(item.CheckEnableControl(DecorationItemBase.ControlType.Drag))
			{
				item.Drag(touchPosition);
			}
		}

		//// RVA: 0x1AD806C Offset: 0x1AD806C VA: 0x1AD806C
		public void LeaveCallback(DecorationItemBase item)
		{
			if(m_controlType == EnableControlType.Edit)
			{
				if(item.CanEdit)
				{
					if (item.Lock)
						return;
					m_isNewPostSetting = false;
					m_isSelectItem = false;
					OnLeaveCallback();
					return;
				}
			}
			else if(item.CheckEnableControl(DecorationItemBase.ControlType.Tap & DecorationItemBase.ControlType.LongTap))
			{
				item.PointerUp();
			}
		}

		//// RVA: 0x1AD811C Offset: 0x1AD811C VA: 0x1AD811C
		//public void ClickCallback(DecorationItemBase item) { }

		//// RVA: 0x1AD67BC Offset: 0x1AD67BC VA: 0x1AD67BC
		//private DecorationItemBase CreateDecorationItem(int id) { }

		//// RVA: 0x1AC03A4 Offset: 0x1AC03A4 VA: 0x1AC03A4
		//public void Clear() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AC390 Offset: 0x6AC390 VA: 0x6AC390
		//// RVA: 0x1AD81DC Offset: 0x1AD81DC VA: 0x1AD81DC
		//public IEnumerator Co_Clear() { }

		//// RVA: 0x1AC0008 Offset: 0x1AC0008 VA: 0x1AC0008
		//public bool IsClearing() { }

		//// RVA: 0x1AD8264 Offset: 0x1AD8264 VA: 0x1AD8264
		//public Dictionary<string, int> GetNumList() { }

		// RVA: 0x1AD854C Offset: 0x1AD854C VA: 0x1AD854C
		private void OnApplicationPause(bool pauseStatus)
		{
			m_isApplicationPause = true;
		}

		// RVA: 0x1AD8558 Offset: 0x1AD8558 VA: 0x1AD8558
		private void Update()
		{
			if (m_isWaitingChara)
				WaitingChara();
			if(!m_isClearing)
			{
				if(IsLoadedItemManager)
				{
					if(m_isNewPostSetting)
					{
						FirstSetting();
					}
					if(m_controlType == EnableControlType.Edit)
					{
						FollowAutoScrollArea();
					}
					UpdateOrder();
				}
			}
		}

		//// RVA: 0x1AD8A30 Offset: 0x1AD8A30 VA: 0x1AD8A30
		private void FollowAutoScrollArea()
		{
			if(m_isSelectItem && m_scrollController != null)
			{
				if(m_scrollController.DeltaPosition.sqrMagnitude >= 1e-05)
				{
					m_editItem.Position -= m_scrollController.DeltaPosition;
					m_moveBeginOffsetPosition -= m_scrollController.DeltaPosition;
					OnMoveCallback(m_editItem);
					m_decorationItemControllerLayout.UpdateFramePosition(m_editItem);
				}
			}
		}

		//// RVA: 0x1ABE980 Offset: 0x1ABE980 VA: 0x1ABE980
		//public DecorationItemBase GetEditItem() { }

		//// RVA: 0x1AD87A4 Offset: 0x1AD87A4 VA: 0x1AD87A4
		private void FirstSetting()
		{
			if (!m_isApplicationPause)
			{
				if (InputManager.Instance.GetCurrentTouchInfo(0).isIllegal)
				{
					LeaveCallback(m_editItem);
					m_isNewPostSettingBegin = false;
				}
				else
				{
					if (!m_isNewPostSettingBegin)
					{
						MoveCallback(m_editItem, InputManager.Instance.GetCurrentTouchInfo(0).nativePosition);
					}
					else
					{
						m_isNewPostSettingBegin = false;
						Vector2 p = InputManager.Instance.GetCurrentTouchInfo(0).nativePosition;
						m_editItem.Position = DecorationConstants.TouchToScreen(p, m_CanvasRect);
						MoveBeginCallback(m_editItem, p);
						ShowDecorationItemController(m_editItem);
					}
				}
			}
			else
				m_isApplicationPause = false;
		}

		//// RVA: 0x1AD8C40 Offset: 0x1AD8C40 VA: 0x1AD8C40
		private void UpdateOrder()
		{
			bool[] b = new bool[m_decorationItemList.Count];
			for(int i = 0; i < b.Length; i++)
			{
				b[i] = false;
			}
			List<int> l = new List<int>();
			for(int i = 0; i < m_decorationItemList.Count; i++)
			{
				int a = -1;
				float f = float.MinValue;
				for(int j = 0; j < m_decorationItemList.Count; j++)
				{
					if(!b[j])
					{
						if(m_decorationItemList[j].Setting.PriorityControl == DecorationItemBaseSetting.PriorityControlType.Floor)
						{
							if(f <= m_decorationItemList[j].GetOrderPositionY())
							{
								a = j;
								f = m_decorationItemList[j].GetOrderPositionY();
							}
						}
						else
						{
							b[j] = true;
						}
					}
				}
				if (a == -1)
					break;
				b[a] = true;
				l.Add(a);
			}
			int k = 0;
			foreach(int c in l)
			{
				if (m_decorationItemList[c].DecorationItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara)
					k++;
				m_decorationItemList[c].SortingOrder = k + m_priorityOffset[2];
				k++;
			}
		}

		//// RVA: 0x1AD9174 Offset: 0x1AD9174 VA: 0x1AD9174
		//private void BringToFront(DecorationItemBase item) { }

		//// RVA: 0x1AD98B4 Offset: 0x1AD98B4 VA: 0x1AD98B4
		//private void SendToBack(DecorationItemBase item) { }

		//// RVA: 0x1AD9310 Offset: 0x1AD9310 VA: 0x1AD9310
		//private void ResetSortingOrder(DecorationItemBaseSetting.PriorityControlType type) { }

		//// RVA: 0x1ABC8D4 Offset: 0x1ABC8D4 VA: 0x1ABC8D4
		//public void EnableController(DecorationItemManager.EnableControlType type) { }

		//// RVA: 0x1ABCCB0 Offset: 0x1ABCCB0 VA: 0x1ABCCB0
		//public void StartAnimation() { }

		//// RVA: 0x1ABCE30 Offset: 0x1ABCE30 VA: 0x1ABCE30
		//public void StopAnimation() { }

		//// RVA: 0x1ABDB10 Offset: 0x1ABDB10 VA: 0x1ABDB10
		public int GetItemCount()
		{
			int res = 0;
			foreach(var k in m_decorationItemList)
			{
				if (!DecorationConstants.IsItemSpVisit(k))
					res++;
			}
			return res;
		}

		//// RVA: 0x1ABDCBC Offset: 0x1ABDCBC VA: 0x1ABDCBC
		//public int GetCanEditItemCount() { }

		//// RVA: 0x1ABDE58 Offset: 0x1ABDE58 VA: 0x1ABDE58
		//public int GetObjectCount() { }

		//// RVA: 0x1ABDEA4 Offset: 0x1ABDEA4 VA: 0x1ABDEA4
		//public int GetCharaCount() { }

		//// RVA: 0x1ABE034 Offset: 0x1ABE034 VA: 0x1ABE034
		//public int GetDivaCount() { }

		//// RVA: 0x1ABD98C Offset: 0x1ABD98C VA: 0x1ABD98C
		//public List<DecorationItemBase> GetItemList(ref List<int> postId) { }

		//// RVA: 0x1ABD3B4 Offset: 0x1ABD3B4 VA: 0x1ABD3B4
		//public List<DecorationItemBase> GetInteriorList(ref List<int> postId) { }

		//// RVA: 0x1ABD56C Offset: 0x1ABD56C VA: 0x1ABD56C
		//public List<DecorationItemBase> GetCharaList(ref List<int> postId) { }

		//// RVA: 0x1ABD724 Offset: 0x1ABD724 VA: 0x1ABD724
		//public List<DecorationItemBase> GetExtraList(ref List<int> postId) { }

		//// RVA: 0x1ABE21C Offset: 0x1ABE21C VA: 0x1ABE21C
		//public void RemoveEditItem() { }

		//// RVA: 0x1ABE69C Offset: 0x1ABE69C VA: 0x1ABE69C
		//public void RemoveItem(DecorationItemBase item) { }

		//// RVA: 0x1ABE338 Offset: 0x1ABE338 VA: 0x1ABE338
		//public int GetItemPostId(DecorationItemBase item) { }

		//// RVA: 0x1ABE478 Offset: 0x1ABE478 VA: 0x1ABE478
		//public void HideLayoutController() { }

		//// RVA: 0x1ABC824 Offset: 0x1ABC824 VA: 0x1ABC824
		//public void EnablePost(bool isEnable) { }

		//// RVA: 0x1ABB6F0 Offset: 0x1ABB6F0 VA: 0x1ABB6F0
		//public void Show() { }

		//// RVA: 0x1AD7DC0 Offset: 0x1AD7DC0 VA: 0x1AD7DC0
		private LayoutDecorationFrameButton.ButtonType GetFrameButtonType(DecorationItemBase item)
		{
			if (item.ItemType == LayoutDecorationWindow01.SelectItemType.Chara)
				return LayoutDecorationFrameButton.ButtonType.Serif;
			if (item.ItemType != LayoutDecorationWindow01.SelectItemType.Object)
				return LayoutDecorationFrameButton.ButtonType.None;
			LayoutDecorationFrameButton.ButtonType res = LayoutDecorationFrameButton.ButtonType.Flip;
			if(item.Setting.PriorityControl != DecorationItemBaseSetting.PriorityControlType.Floor)
			{
				res = LayoutDecorationFrameButton.ButtonType.PriUp | LayoutDecorationFrameButton.ButtonType.PriDown;
				if (item.Setting.PriorityControl == DecorationItemBaseSetting.PriorityControlType.FloorBack)
					res |= LayoutDecorationFrameButton.ButtonType.Flip;
			}
			if (item.CanKira)
				res |= LayoutDecorationFrameButton.ButtonType.Kira;
			return res;
		}

		//// RVA: 0x1ABC2C8 Offset: 0x1ABC2C8 VA: 0x1ABC2C8
		//public bool HitCheck(DecorationItemBase item, Vector2 position) { }

		//// RVA: 0x1AC47E8 Offset: 0x1AC47E8 VA: 0x1AC47E8
		public bool HitCheckThinkness(DecorationItemBase item, Vector2 position, out DecorationItemBase hitItem)
		{
			hitItem = null;
			bool b = false;
			foreach(var it in m_decorationItemList)
			{
				if(it != item)
				{
					if(item.Setting.AttributeType != DecorationConstants.Attribute.Type.None)
					{
						DecorationConstants.Attribute.Type a = DecorationConstants.Attribute.Type.None;
						if((item.Setting.AttributeType & DecorationConstants.Attribute.Type.Wall) != 0)
						{
							a = it.Setting.AttributeType & DecorationConstants.Attribute.Type.Wall;
							if((it.Setting.AttributeType & DecorationConstants.Attribute.Type.Wall) != 0)
							{
								a = DecorationConstants.Attribute.Type.WallTop;
							}
						}
						if((item.Setting.AttributeType & DecorationConstants.Attribute.Type.Floor) != 0)
						{
							if ((it.Setting.AttributeType & DecorationConstants.Attribute.Type.Floor) != 0)
								a |= DecorationConstants.Attribute.Type.WallTop;
							else
								a |= it.Setting.AttributeType & DecorationConstants.Attribute.Type.Floor;
						}
						if(a != DecorationConstants.Attribute.Type.None && CategoryCheckThinkness(item, it)
							 && !it.HitCheckThinkness(item, position))
						{
							hitItem = it;
							b = true;
							break;
						}
					}
				}
			}
			//LAB_01ac49d8
			return b;
		}

		//// RVA: 0x1ABEAF0 Offset: 0x1ABEAF0 VA: 0x1ABEAF0
		//public bool IsEdit() { }

		//// RVA: 0x1ABEBA4 Offset: 0x1ABEBA4 VA: 0x1ABEBA4
		//public void RemoveAllItem() { }

		//// RVA: 0x1ABED90 Offset: 0x1ABED90 VA: 0x1ABED90
		//public void EditItem(DecorationItemBase item, DecorationScrollController scrollController) { }

		//// RVA: 0x1ABEEAC Offset: 0x1ABEEAC VA: 0x1ABEEAC
		//public void RestroreEditItem() { }

		//// RVA: 0x1AC2620 Offset: 0x1AC2620 VA: 0x1AC2620
		//public void InitSerifResource(Transform parent) { }

		//// RVA: 0x1ABF1EC Offset: 0x1ABF1EC VA: 0x1ABF1EC
		//public bool IsItemTouch() { }

		//// RVA: 0x1ABF380 Offset: 0x1ABF380 VA: 0x1ABF380
		//public void WaitingChara(bool isWait) { }

		//// RVA: 0x1AD85BC Offset: 0x1AD85BC VA: 0x1AD85BC
		private void WaitingChara()
		{
			foreach(var k in m_decorationItemList)
			{
				DecorationChara d = k as DecorationChara;
				if(d != null)
				{
					d.WaitAnimation();
				}
			}
		}

		//// RVA: 0x1AD9B7C Offset: 0x1AD9B7C VA: 0x1AD9B7C
		//public List<DecorationChara> GetCharaList() { }

		//// RVA: 0x1AC7D4C Offset: 0x1AC7D4C VA: 0x1AC7D4C
		//public bool AnyCharaReacting() { }

		//// RVA: 0x1AC8418 Offset: 0x1AC8418 VA: 0x1AC8418
		//public void RemoveOtherCharaVoiceCueSheet(DecorationChara restChara) { }

		//// RVA: 0x1AD9948 Offset: 0x1AD9948 VA: 0x1AD9948
		//private bool CategoryCheck(DecorationItemBase item1, DecorationItemBase item2) { }

		//// RVA: 0x1AD9AA0 Offset: 0x1AD9AA0 VA: 0x1AD9AA0
		private bool CategoryCheckThinkness(DecorationItemBase item1, DecorationItemBase item2)
		{
			if(item1.DecorationItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara)
			{
				if(item2.DecorationItemCategory != EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara)
				{
					return DecorationConstants.IsRug(item2);
				}
				return true;
			}
			return false;
		}

		//// RVA: 0x1AD9E04 Offset: 0x1AD9E04 VA: 0x1AD9E04
		//private void OnClickPriorityButton(DecorationItemBase item, LayoutDecorationFrameButton.ButtonType type) { }

		//// RVA: 0x1ABFAC4 Offset: 0x1ABFAC4 VA: 0x1ABFAC4
		//public void Lock() { }

		//// RVA: 0x1ABFC44 Offset: 0x1ABFC44 VA: 0x1ABFC44
		//public void UnLock() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6AC408 Offset: 0x6AC408 VA: 0x6AC408
		//// RVA: 0x1AD9F70 Offset: 0x1AD9F70 VA: 0x1AD9F70
		//private bool <Co_Clear>b__75_0() { }
	}
}
