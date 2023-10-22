using XeApp.Game.Common;
using UnityEngine;
using System.Collections.Generic;
using XeSys.Gfx;
using UnityEngine.EventSystems;
using XeSys;
using UnityEngine.UI;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationSelectItemBase : SwapScrollListContent, IPointerDownHandler, IEventSystemHandler, IPointerClickHandler, IDragHandler, IEndDragHandler
	{
		// Namespace: 
		public class TouchState
		{
			public enum State // TypeDefIndex: 11588
			{
				None = 0,
				TouchObj = 1,
				TouchScroll = 2,
			}

			public State nowState = State.None; // 0x8
			public Vector3 prePos = Vector3.zero; // 0xC
			public Vector3 currntPos = Vector3.zero; // 0x18
		}

		private const float deleteTime = 0.5f;
		[SerializeField]
		private Vector2 m_size; // 0x20
		[SerializeField]
		private ActionButton m_detailButton; // 0x28
		[SerializeField]
		private NumberBase m_haveNumLayout; // 0x2C
		[SerializeField]
		private NumberBase m_restNumLayout; // 0x30
		[SerializeField]
		private string m_grayoutId; // 0x34
		[SerializeField]
		private List<RawImageEx> m_itemImage; // 0x38
		[SerializeField]
		private ButtonBase m_button; // 0x3C
		[SerializeField]
		private float m_selectLength = 16; // 0x40
		[SerializeField]
		private GameObject m_draggingObject; // 0x44
		[SerializeField]
		private GameObject m_hitObject; // 0x48
		private GameObject m_tapGuard; // 0x4C
		private AbsoluteLayout m_newIcon; // 0x54
		private AbsoluteLayout m_restTbl; // 0x58
		private AbsoluteLayout m_grayoutAbs; // 0x5C
		private AbsoluteLayout m_statusAbs; // 0x60
		private AbsoluteLayout m_kiraAbs; // 0x64
		private TouchState m_touchState = new TouchState(); // 0x68
		public DecorationConstants.DecideItemCallback DecideItemCallback; // 0x6C
		protected DecorationSelectItemTextureLoaderBase m_selectItemTextureLoader; // 0x70
		private bool m_isPressedItem; // 0x85
		private TouchInfo m_beginInfo; // 0x88
		private readonly float m_selectRange = 0.7071068f; // 0x8C
		private readonly Vector2 m_selectTarnsVector = new Vector2(-1, 0); // 0x90
		private int m_restNum; // 0x9C
		private int m_haveNum; // 0xA0
		private bool m_isProduct; // 0xA4
		private bool IsTouchUp; // 0xA5
		private bool IsDrag; // 0xA6
		private PointerEventData m_touchEventData; // 0xA8
		private TouchInfoRecord m_touchData; // 0xAC
		protected LayoutDecorationWindow01 m_window; // 0xB0
		private GameObject m_parent; // 0xB4
		private Camera UICamara; // 0xB8
		protected int m_textureId; // 0xC8
		private bool m_enableSelectItem; // 0xCC
		private bool m_isTouchCancel; // 0xCE
		private Coroutine Co_ObsDragObject; // 0xD0

		public Vector2 Size { get { return m_size; } } //0x18B3B88
		public GameObject Instance { get; protected set; } // 0x50
		public int Id { get; protected set; } // 0x74
		public int SubId { get; protected set; } // 0x78
		public int PostId { get; protected set; } // 0x7C
		public LayoutDecorationWindow01.SelectItemType Type { get; protected set; } // 0x80
		public bool IsNew { get; protected set; } // 0x84
		public KDKFHGHGFEK Data { get; protected set; } // 0x98
		public Vector3 DragItemPostion { get; private set; } // 0xBC
		public bool IsUpdateRestNum { get; set; } // 0xCD
		private RawImageEx ItemImage { get {
			if(m_itemImage.Count < 1)
				return null;
			return m_itemImage[0];
		} } //0x18B6B74

		// RVA: 0x18B32AC Offset: 0x18B32AC VA: 0x18B32AC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_newIcon = layout.FindViewById("swtbl_new_icon_01") as AbsoluteLayout;
			m_newIcon.StartChildrenAnimGoStop(1, 1);
			m_grayoutAbs = layout.FindViewById(m_grayoutId) as AbsoluteLayout;
			m_statusAbs = layout.FindViewById("swtbl_item_num") as AbsoluteLayout;
			m_isProduct = false;
			m_kiraAbs = layout.FindViewByExId("sw_deco_item_01_sw_kira_frm_onoff") as AbsoluteLayout;
			SetEnabledNumStatus(true);
			m_detailButton.AddOnClickCallback(() =>
			{
				//0x18B72E4
				ShowItemDetailPopup();
			});
			m_restTbl = layout.FindViewById("swtbl_item_num_all") as AbsoluteLayout;
			m_itemImage.ForEach((RawImageEx _) =>
			{
				//0x18B7364
				_.enabled = false;
				_.raycastTarget = false;
			});
			m_restNum = 0;
			m_haveNum = -1;
			m_isPressedItem = false;
			m_enableSelectItem = false;
			IsDrag = false;
			IsUpdateRestNum = false;
			CreateHitObject();
			return true;
		}

		// // RVA: 0x18B3CA8 Offset: 0x18B3CA8 VA: 0x18B3CA8
		private void CreateHitObject()
		{
			if(m_hitObject == null)
			{
				m_hitObject = new GameObject("Hit Check Object");
				m_hitObject.transform.SetParent(transform);
				m_hitObject.transform.SetSiblingIndex(0);
				Image im = m_hitObject.AddComponent<Image>();
				im.raycastTarget = true;
				im.color = new Color(0, 0, 0, 0);
				RectTransform rt = m_hitObject.transform as RectTransform;
				rt.anchorMin = new Vector2(0, 1);
				rt.anchorMax = new Vector2(0, 1);
				rt.pivot = new Vector2(0, 1);
				rt.sizeDelta = m_size;
				rt.position = Vector2.zero;
			}
		}

		// // RVA: 0x18B4078 Offset: 0x18B4078 VA: 0x18B4078
		public void SetNum(int have, int rest)
		{
			if(m_restNumLayout != null)
			{
				bool b = false;
				if(m_haveNumLayout != null)
				{
					if(rest < 1 && !m_isProduct)
						b = true;
					int r = rest;
					int h = have;
					int start = rest < 1 ? 1 : 0;
					if(Data.KGBAOKCMALD == 0)
					{
						m_haveNum = 0;
						r = rest >= 0 ? 1 : 0;
						h = rest < 0 ? 1 : 0;
						start = 0;
					}
					m_restNum = r;
					m_haveNumLayout.SetNumber(have, 0);
					m_restNumLayout.SetNumber(m_restNum, 0);
					SetEnabledGrayout(b);
					m_restTbl.StartChildrenAnimGoStop(start, start);
					IsUpdateRestNum = false;
				}
			}
		}

		// // RVA: 0x18B42A8 Offset: 0x18B42A8 VA: 0x18B42A8 Slot: 10
		public virtual void Setting(KDKFHGHGFEK item, int postNum, bool canKira, DecorationDecorator.TabType tab, LayoutDecorationWindow01.SelectItemType type, LayoutDecorationWindow01 window)
		{
			int subId = MakeSubid(item, tab, 0);
			Data = item;
			m_window = window;
			m_isProduct = false;
			SetEnabledNumStatus(true);
			SetDetailButtonShow();
			SetNewIcon(item.CADENLBDAEB_IsNew);
			SetNum(item.BFINGCJHOHI, item.BFINGCJHOHI - postNum);
			SetStatusIcon(-1 < postNum);
			Id = item.PPFNGGCBJKC_Id;
			SubId = subId;
			Type = type;
			m_textureId = Id;
			m_selectItemTextureLoader = CreateSelectItemTextureLoader();
			SetKira(canKira);
		}

		// // RVA: 0x18B4644 Offset: 0x18B4644 VA: 0x18B4644
		public void SettingExchange(FJGOKILCBJA item, DecorationDecorator.TabType tab, LayoutDecorationWindow01.SelectItemType type, LayoutDecorationWindow01 window)
		{
			KDKFHGHGFEK k = new KDKFHGHGFEK();
			k.KHEKNNFCAOI(EKLNMHFCAOI.DEACAHNLMNI_getItemId(item.KIJAPOFAGPN_ItemFullId), EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(item.KIJAPOFAGPN_ItemFullId));
			Setting(k, 0, false, tab, type, window);
			IsNew = false;
			if(m_newIcon != null)
				m_newIcon.StartChildrenAnimGoStop(1, 1);
			SetEnabledExchangable(true);
		}

		// // RVA: 0x18B43F0 Offset: 0x18B43F0 VA: 0x18B43F0
		private int MakeSubid(KDKFHGHGFEK item, DecorationDecorator.TabType tab, LayoutDecorationWindow01.SelectItemType type)
		{
			if(item.NPADACLCNAN_Category == EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg && tab >= DecorationDecorator.TabType.BgSet && tab <= DecorationDecorator.TabType.BgFloor)
			{
				return new int[4] { 0, 2, 3, 1 } [(int)tab - 15];
			}
			if(item.NPADACLCNAN_Category != EKLNMHFCAOI.FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster)
			{
				if(item.NPADACLCNAN_Category != EKLNMHFCAOI.FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef)
				{
					if(item.NPADACLCNAN_Category == EKLNMHFCAOI.FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft)
						return 2;
					return 0;
				}
				return 1;
			}
			return 0;
		}

		// // RVA: 0x18B4598 Offset: 0x18B4598 VA: 0x18B4598
		public void SetData(int id, int subId, LayoutDecorationWindow01.SelectItemType type)
		{
			Id = id;
			SubId = subId;
			Type = type;
			m_textureId = id;
			m_selectItemTextureLoader = CreateSelectItemTextureLoader();
		}

		// // RVA: 0x18B49BC Offset: 0x18B49BC VA: 0x18B49BC Slot: 11
		public virtual void LoadTexture()
		{
			ClearItemImage();
			m_selectItemTextureLoader.Load(m_textureId, SubId, LoadedTexture);
		}

		// // RVA: 0x18B4AF4 Offset: 0x18B4AF4 VA: 0x18B4AF4
		public void ClearItemImage()
		{
			m_itemImage.ForEach((RawImageEx _) =>
			{
				//0x18B73C8
				_.enabled = false;
			});
		}

		// // RVA: 0x18B4C4C Offset: 0x18B4C4C VA: 0x18B4C4C
		public void LoadedTexture(IiconTexture texture, int loadedId, int loadedSubId)
		{
			if(loadedId == m_textureId && loadedSubId == SubId)
			{
				m_itemImage.ForEach((RawImageEx _) =>
				{
					//0x18B73F8
					if(_ == null)
						return;
					_.enabled = true;
					texture.Set(_);
				});
			}
		}

		// // RVA: 0x18B4D6C Offset: 0x18B4D6C VA: 0x18B4D6C
		public void ItemDecideCallback(bool isTapDecide = false)
		{
			if(!m_isProduct)
				m_enableSelectItem = false;
			IsUpdateRestNum = true;
			DecideItemCallback(this, isTapDecide);
		}

		// // RVA: 0x18B3C84 Offset: 0x18B3C84 VA: 0x18B3C84
		// private void InitData() { }

		// RVA: 0x18B4DC0 Offset: 0x18B4DC0 VA: 0x18B4DC0 Slot: 6
		public void OnPointerDown(PointerEventData pointerEventData)
		{
			if(IsTouchActionEnable(pointerEventData))
			{
				m_touchEventData = pointerEventData;
				m_touchData = InputManager.Instance.GetTouchInfoRecord(0);
				m_touchState.nowState = TouchState.State.None;
				m_touchState.prePos = m_touchEventData.position;
				m_window.ScrollRect.OnBeginDrag(m_touchEventData);
				m_isTouchCancel = false;
				IsTouchUp = false;
			}
		}

		// RVA: 0x18B5000 Offset: 0x18B5000 VA: 0x18B5000 Slot: 7
		public void OnPointerClick(PointerEventData pointerEventData)
		{
			if(IsTouchUpActionEnable(pointerEventData))
			{
				if(MenuScene.Instance.GetInputDisableCount() > 0)
				{
					m_isTouchCancel = true;
					IsTouchUp = false;
					IsDrag = false;
					TouchReset();
					DestroyDragObject();
					return;
				}
				if(m_isProduct)
				{
					ItemDecideCallback(false);
					return;
				}
				bool b = false;
				if(Type == LayoutDecorationWindow01.SelectItemType.Serif)
					b = false;
				else if(Type == LayoutDecorationWindow01.SelectItemType.Bg)
				{
					b = !m_statusAbs.enabled;
				}
				else
				{
					if(IsDrag)
						return;
					if(m_restNum < 1)
						return;
					ItemDecideCallback(true);
					return;
				}
				if(m_restNum > 0)
					b = true;
				if(b)
					ItemDecideCallback(true);
			}
		}

		// RVA: 0x18B5224 Offset: 0x18B5224 VA: 0x18B5224 Slot: 8
		public void OnDrag(PointerEventData pointerEventData)
		{
			if(IsTouchActionEnable(pointerEventData) && m_touchData != null && !m_isTouchCancel)
			{
				if(MenuScene.Instance.GetInputDisableCount() > 0)
				{
					if(Co_ObsDragObject != null)
					{
						this.StopCoroutineWatched(Co_ObsDragObject);
						Co_ObsDragObject = null;
					}
					m_isTouchCancel = true;
					IsTouchUp = false;
					IsDrag = false;
					TouchReset();
					DestroyDragObject();
					return;
				}
				m_touchEventData = pointerEventData;
				m_touchData.Update(TouchPhase.Moved, pointerEventData.position);
				if(m_touchState.nowState == TouchState.State.None)
				{
					m_touchState.currntPos = m_touchEventData.position;
					TouchStateCheck(Math.CalcAngleType(4, m_touchState.prePos, m_touchState.currntPos, true));
					if(m_touchState.nowState == TouchState.State.TouchObj)
					{
						if(m_restNum < 1)
						{
							m_touchState.nowState = 0;
						}
						else
						{
							CreateDragObject();
							CalcObjPos(m_touchEventData.position);
						}
					}
					Co_ObsDragObject = this.StartCoroutineWatched(Co_DragObject_Delete());
					IsTouchUp = false;
					IsDrag = true;
				}
				else if(m_touchState.nowState == TouchState.State.TouchObj)
				{
					CalcObjPos(m_touchEventData.position);
					if(!hitCheck(m_window.ScrollRect.transform as RectTransform, m_draggingObject))
					{
						TouchReset();
						DestroyDragObject();
						ItemDecideCallback(false);
					}
				}
				else if(m_touchState.nowState == TouchState.State.TouchScroll)
				{
					m_window.ScrollRect.OnDrag(m_touchEventData);
				}
			}
		}

		// // RVA: 0x18B6530 Offset: 0x18B6530 VA: 0x18B6530
		private bool hitCheck(RectTransform _rect, GameObject _touchObj)
		{
			if(_touchObj != null)
			{
				Vector2 v = GameManager.Instance.GetSystemCanvasCamera().WorldToScreenPoint(_touchObj.transform.position);
				UICamara = GameManager.Instance.GetSystemCanvasCamera();
				Vector2 v2 = v + new Vector2(ItemImage.rectTransform.rect.width * 0.5f, ItemImage.rectTransform.rect.height * 0.5f);
				if(!RectTransformUtility.RectangleContainsScreenPoint(_rect, v2, UICamara))
				{
					v2.x = v.x - ItemImage.rectTransform.rect.width * 0.5f;
					if(!RectTransformUtility.RectangleContainsScreenPoint(_rect, v2, UICamara))
					{						
						v2.x = v.x + ItemImage.rectTransform.rect.width * 0.5f;
						v2.y = v.y - ItemImage.rectTransform.rect.height * 0.5f;
						if(!RectTransformUtility.RectangleContainsScreenPoint(_rect, v2, UICamara))
						{
							v2.x = v.x - ItemImage.rectTransform.rect.width * 0.5f;
							v2.y = v.y - ItemImage.rectTransform.rect.height * 0.5f;
							return RectTransformUtility.RectangleContainsScreenPoint(_rect, v2, UICamara);
						}
					}
				}
				return true;
			}
			return false;
		}

		// // RVA: 0x18B61F4 Offset: 0x18B61F4 VA: 0x18B61F4
		private void CalcObjPos(Vector3 touchPos)
		{
			if(m_draggingObject == null)
			{
				TouchReset();
				return;
			}
			UICamara = GameManager.Instance.GetSystemCanvasCamera();
			Vector3 v = UICamara.ScreenToWorldPoint(touchPos);
			m_draggingObject.transform.position = v;
			m_draggingObject.transform.localPosition = new Vector3(m_draggingObject.transform.localPosition.x + ItemImage.rectTransform.sizeDelta.x * -0.5f, m_draggingObject.transform.localPosition.y, 0);
			DragItemPostion = m_draggingObject.transform.localPosition;
		}

		// // RVA: 0x18B69CC Offset: 0x18B69CC VA: 0x18B69CC
		private void TouchReset()
		{
			m_touchData.UpdateReleased();
			m_touchState.nowState = TouchState.State.None;
			m_touchData = null;
		}

		// // RVA: 0x18B51F4 Offset: 0x18B51F4 VA: 0x18B51F4
		// private void TouchCancel() { }

		// // RVA: 0x18B58CC Offset: 0x18B58CC VA: 0x18B58CC
		private void CreateDragObject()
		{
			m_tapGuard = new GameObject("Dragging TapGuard");
			m_parent = m_window.transform.parent.gameObject;
			m_tapGuard.transform.SetParent(m_parent.transform);
			m_tapGuard.transform.SetAsLastSibling();
			m_tapGuard.transform.localScale = Vector3.one;
			Image im = m_tapGuard.AddComponent<Image>();
			im.raycastTarget = true;
			m_tapGuard.transform.localScale = new Vector3(Screen.width, Screen.height, 0);
			im.color = new Color(0, 0, 0, 0);
			m_draggingObject = new GameObject("Dragging Object");
			m_draggingObject.transform.SetParent(m_parent.transform);
			m_draggingObject.transform.SetAsLastSibling();
			m_draggingObject.transform.localScale = Vector3.one;
			m_draggingObject.transform.localPosition = new Vector3(-100, -100, -100);
			RectTransform rt = m_draggingObject.AddComponent<RectTransform>();
			rt.anchorMax = Vector2.zero;
			rt.anchorMin = Vector2.zero;
			rt.pivot = new Vector2(0.5f, 0.5f);
			m_draggingObject.AddComponent<CanvasGroup>().blocksRaycasts = false;
			RawImageEx rex = m_draggingObject.AddComponent<RawImageEx>();
			rex.texture = ItemImage.texture;
			rex.alphaTexture = ItemImage.alphaTexture;
			rex.rectTransform.sizeDelta = ItemImage.rectTransform.sizeDelta;
			rex.color = new Color(ItemImage.color.r, ItemImage.color.g, ItemImage.color.b, 0.75f);
			rex.material = ItemImage.material;
		}

		// RVA: 0x18B6C2C Offset: 0x18B6C2C VA: 0x18B6C2C Slot: 9
		public void OnEndDrag(PointerEventData pointerEventData)
		{
			if(!IsTouchActionEnable(pointerEventData))
				return;
			if(m_touchData != null)
			{
				if(m_isTouchCancel)
				{
					m_isTouchCancel = false;
					return;
				}
				m_touchEventData = pointerEventData;
				IsTouchUp = true;
				IsDrag = false;
			}
		}

		// // RVA: 0x18B452C Offset: 0x18B452C VA: 0x18B452C
		public void SetStatusIcon(bool isEnable)
		{
			if(Data.KGBAOKCMALD == 0)
				isEnable = false;
			m_statusAbs.enabled = isEnable;
		}

		// // RVA: 0x18B6C78 Offset: 0x18B6C78 VA: 0x18B6C78
		public void EnableSelectItem()
		{
			m_enableSelectItem = true;
		}

		// // RVA: 0x18B6C84 Offset: 0x18B6C84 VA: 0x18B6C84
		public void DisableSelectItem()
		{
			m_enableSelectItem = false;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6D693C Offset: 0x6D693C VA: 0x6D693C
		// // RVA: 0x18B64A4 Offset: 0x18B64A4 VA: 0x18B64A4
		private IEnumerator Co_DragObject_Delete()
		{
			//0x18B78D8
			while(!InputManager.Instance.GetCurrentTouchInfo(0).isIllegal && !IsTouchUp)
				yield return null;
			TouchUp();
			while(m_window.IsAnimPlaying)
				yield return null;
			NonAnimDelete();
			IsTouchUp = false;
			IsDrag = false;
		}

		// // RVA: 0x18B6CB0 Offset: 0x18B6CB0 VA: 0x18B6CB0
		private void TouchUp()
		{
			if(!m_window.IsAnimPlaying)
			{
				if(m_touchState.nowState != TouchState.State.None)
				{
					m_touchData.Update(TouchPhase.Ended, m_touchEventData.position);
					m_touchData.UpdateReleased();
					if(m_touchState.nowState == TouchState.State.TouchObj)
					{
						m_window.IsAnimPlaying = true;
						if(!m_window.GetIsDragCancel())
						{
							this.StartCoroutineWatched(Co_DragObjDelete());
						}
						else
						{
							NonAnimDelete();
						}
					}
					m_touchState.nowState = TouchState.State.None;
					m_touchData = null;
					if(m_touchEventData != null)
					{
						m_window.ScrollRect.OnEndDrag(m_touchEventData);
					}
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6D69B4 Offset: 0x6D69B4 VA: 0x6D69B4
		// // RVA: 0x18B6F3C Offset: 0x18B6F3C VA: 0x18B6F3C
		private IEnumerator Co_DragObjDelete()
		{
			//0x18B7540
			MenuScene.Instance.InputDisable();
			while(true)
			{
				bool b1 = m_draggingObject.transform.localScale.x >= 0;
				bool b2 = m_draggingObject.transform.localScale.x == 0;
				float f1 = m_draggingObject.transform.localScale.x;
				if(b1 && !b2)
					f1 = m_draggingObject.transform.localScale.y;
				bool b3 = b2;
				bool b4 = b1;
				if(b1 && !b2)
				{
					b3 = f1 == 0;
					b4 = 0 <= f1;
				}
				if(b1 && !b2)
				{
					b1 = b4;
					b2 = b3;
				}
				if(b1 && !b2)
				{
					Vector3 s = m_draggingObject.transform.localScale;
					if(s.x >= 0)
					{
						s.x += Time.deltaTime * -2;
					}
					if(s.y >= 0)
					{
						s.y += Time.deltaTime * -2;
					}
					if(s.z >= 0)
					{
						s.z += Time.deltaTime * -2;
					}
					m_draggingObject.transform.localScale = s;
					yield return null;
				}
				else
					break;
			}
			m_window.IsAnimPlaying = false;
			m_touchData = null;
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0x18B701C Offset: 0x18B701C VA: 0x18B701C
		// private bool isDisappear(Vector3 scale) { }

		// // RVA: 0x18B6FC8 Offset: 0x18B6FC8 VA: 0x18B6FC8
		private void NonAnimDelete()
		{
			DestroyDragObject();
			m_window.IsAnimPlaying = false;
			m_touchData = null;
		}

		// // RVA: 0x18B6A10 Offset: 0x18B6A10 VA: 0x18B6A10
		private void DestroyDragObject()
		{
			if(m_draggingObject != null)
			{
				Destroy(m_draggingObject);
				m_draggingObject = null;
			}
			if(m_tapGuard != null)
			{
				Destroy(m_tapGuard);
				m_tapGuard = null;
			}
		}

		// // RVA: 0x18B4F7C Offset: 0x18B4F7C VA: 0x18B4F7C
		private bool IsTouchActionEnable(PointerEventData pointerEventData)
		{
			if(!m_window.IsAnimPlaying && !IsTouchUp && m_enableSelectItem)
			{
				return 
#if UNITY_ANDROID
				pointerEventData.pointerId == 0
#else
				pointerEventData.pointerId == -1
#endif
				;
			}
			return false;
		}

		// // RVA: 0x18B5184 Offset: 0x18B5184 VA: 0x18B5184
		private bool IsTouchUpActionEnable(PointerEventData pointerEventData)
		{
			if(m_touchState.nowState != TouchState.State.TouchScroll && m_enableSelectItem)
			{
				return 
#if UNITY_ANDROID
				pointerEventData.pointerId == 0
#else
				pointerEventData.pointerId == -1
#endif
				;
			}
			return false;
		}

		// // RVA: 0x18B5760 Offset: 0x18B5760 VA: 0x18B5760
		private void TouchStateCheck(int at)
		{
			if(((int)Type & 0xfffffffeU) == 2)
			{
				m_touchState.nowState = TouchState.State.TouchScroll;
				return;
			}
			if(m_window.ScrollRect == null || m_window.ScrollRect.vertical)
			{
				if(at == 1 || at == 3)
				{
					m_touchState.nowState = TouchState.State.TouchScroll;
					if(at != 2)
						return;
				}
				else if(at != 2)
					return;
			}
			m_touchState.nowState = TouchState.State.TouchObj;
		}

		// // RVA: 0x18B704C Offset: 0x18B704C VA: 0x18B704C
		private void ShowItemDetailPopup()
		{
			MenuScene.Instance.ShowItemDetail(Data.KGBAOKCMALD, SubId, 0, Data.OPFGFINHFCE_Name, Data.FEMMDNIELFC_Desc, null);
		}

		// // RVA: 0x18B3C3C Offset: 0x18B3C3C VA: 0x18B3C3C
		protected void SetEnabledExchangable(bool isEnable)
		{
			m_isProduct = isEnable;
			if(isEnable && m_grayoutAbs != null)
				m_grayoutAbs.StartChildrenAnimGoStop(0, 0);
			SetEnabledNumStatus(!isEnable);
		}

		// // RVA: 0x18B4280 Offset: 0x18B4280 VA: 0x18B4280
		protected void SetEnabledGrayout(bool isEnable)
		{
			if(m_grayoutAbs != null)
				m_grayoutAbs.StartChildrenAnimGoStop(isEnable ? 1 : 0, isEnable ? 1 : 0);
		}

		// // RVA: 0x18B717C Offset: 0x18B717C VA: 0x18B717C
		private void SetEnabledNumStatus(bool isEnable)
		{
			if(m_statusAbs == null)
				return;
			m_statusAbs.enabled = true;
			m_statusAbs.StartChildrenAnimGoStop(isEnable ? 0 : 1, isEnable ? 0 : 1);
		}

		// // RVA: 0x18B47D0 Offset: 0x18B47D0 VA: 0x18B47D0
		private DecorationSelectItemTextureLoaderBase CreateSelectItemTextureLoader()
		{
			switch(Data.NPADACLCNAN_Category)
			{
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg:
					return new SelectBgTextureLoader();
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj:
					return new SelectItemTextureLoader();
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara:
					return new SelectCharaTextureLoader();
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif:
					return new SelectSerifTextureLoader();
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp:
					return new SelectSpTextureLoader();
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster:
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef:
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft:
					return new SelectPosterTextureLoader();
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.HEMGMACMGAB_DecoItemVFFigure:
					return new SelectVFFigureTextureLoader();
				case EKLNMHFCAOI.FKGCBLHOOCL_Category.NNBMEEPOBIO_DecoItemCostumeTorso:
					return new SelectCostumeTorsoTextureLoader();
			}
			return null;
		}

		// // RVA: 0x18B44FC Offset: 0x18B44FC VA: 0x18B44FC
		protected void SetNewIcon(bool isNew)
		{
			IsNew = isNew;
			if(m_newIcon != null)
				m_newIcon.StartChildrenAnimGoStop(isNew ? 0 : 1, isNew ? 0 : 1);
		}

		// // RVA: 0x18B71EC Offset: 0x18B71EC VA: 0x18B71EC
		protected void SetDetailButtonHidden()
		{
			m_detailButton.Hidden = true;
		}

		// // RVA: 0x18B44CC Offset: 0x18B44CC VA: 0x18B44CC
		protected void SetDetailButtonShow()
		{
			m_detailButton.Hidden = false;
		}

		// // RVA: 0x18B45C0 Offset: 0x18B45C0 VA: 0x18B45C0
		protected void SetKira(bool canKira)
		{
			if(m_kiraAbs != null)
				m_kiraAbs.StartChildrenAnimGoStop(canKira ? "01" : "02");
		}

		// // RVA: 0x18B3720 Offset: 0x18B3720 VA: 0x18B3720 Slot: 12
		public virtual void LayoutAllUpdate()
		{
			if(m_newIcon != null)
			{
				m_newIcon.UpdateAllAnimation(2 * TimeWrapper.deltaTime, false);
				m_newIcon.UpdateAll(new Matrix23(), Color.white);
			}
			if(m_restTbl != null)
			{
				m_restTbl.UpdateAllAnimation(2 * TimeWrapper.deltaTime, false);
				m_restTbl.UpdateAll(new Matrix23(), Color.white);
			}
			if(m_grayoutAbs != null)
			{
				m_grayoutAbs.UpdateAllAnimation(2 * TimeWrapper.deltaTime, false);
				m_grayoutAbs.UpdateAll(new Matrix23(), Color.white);
			}
			if(m_statusAbs != null)
			{
				m_statusAbs.UpdateAllAnimation(2 * TimeWrapper.deltaTime, false);
				m_statusAbs.UpdateAll(new Matrix23(), Color.white);
			}
			if(m_kiraAbs != null)
			{
				m_kiraAbs.UpdateAllAnimation(2 * TimeWrapper.deltaTime, false);
				m_kiraAbs.UpdateAll(new Matrix23(), Color.white);
			}
		}
	}
}
