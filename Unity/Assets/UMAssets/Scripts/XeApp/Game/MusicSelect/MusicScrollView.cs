using UnityEngine.EventSystems;
using UnityEngine;

namespace XeApp.Game.MusicSelect
{
	public class MusicScrollView : UIBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
	{
		//private float scrollSpling = 6; // 0xC
		//private int longScrollCount = 6; // 0x10
		//private float scrollVelocity = 1.5f; // 0x14
		//private float singleMoveSpling = 6; // 0x18
		//private float singleScrollVelocity = 0.5f; // 0x1C
		//private float centerUpdateRate = 0.6f; // 0x20
		[SerializeField]
		private MusicScrollCenterItem _centerItem; // 0x24
		[SerializeField]
		private MusicScrollItem[] _overScrollItem; // 0x28
		[SerializeField]
		private MusicScrollItem[] _underScrollItem; // 0x2C
		[SerializeField]
		private CanvasGroup m_hitRectCanvasGroup; // 0x30
		public MusicUpdateCenterItem OnUpdateCenter; // 0x34
		public MusicUpdateListItem OnUpdateListItem; // 0x38
		public MusicUpdateClipItem OnUpdateClipItem; // 0x3C
		public ScrollStartEvent OnScrollStartEvent; // 0x40
		public ScrollEndEvent OnScrollEndEvent; // 0x44
		private int _itemCount; // 0x48
		//private Vector2 _scrollValue; // 0x4C
		//private Vector2 _prevPosition; // 0x54
		//private Vector2 _velocity; // 0x5C
		//private Vector2 _clipPosition; // 0x64
		//private float _prevRate; // 0x6C
		//private bool _isDraging; // 0x70
		//private bool _isClip; // 0x71
		//private bool _isTouch; // 0x72
		//private bool _isSingleScroll; // 0x73
		//private bool _isReturn; // 0x74
		//private bool _isScrollCancel; // 0x75
		//private int _currentIndex; // 0x78
		//private float target; // 0x7C
		//private float prev; // 0x80
		//private int prevCenterIndex = -1; // 0x84
		public float StopT = 3; // 0x88
		public float ClipSpeed = 2; // 0x8C
		//private const float ScrollItemSize = 90;

		public MusicScrollCenterItem CenterItem { get { return _centerItem; } } //0xC9F66C
		public int ItemCount { get { return _itemCount; } set { if(_itemCount != value) _itemCount = value; } } //0xC9F674 0xC9F67C
		//public float DeltaTime { get; }0xCA0450

		//// RVA: 0xC9F68C Offset: 0xC9F68C VA: 0xC9F68C
		private void Awake()
		{
			UnityEngine.Debug.LogError("TODO MusicScrollView Awake");
		}

		//// RVA: 0xC9F840 Offset: 0xC9F840 VA: 0xC9F840
		//public bool IsEnableTouchId(PointerEventData eventData) { }

		//// RVA: 0xC9F87C Offset: 0xC9F87C VA: 0xC9F87C
		public void ScrollEnable(bool isEnable)
		{
			m_hitRectCanvasGroup.blocksRaycasts = isEnable;
		}

		//// RVA: 0xC9F8B0 Offset: 0xC9F8B0 VA: 0xC9F8B0
		//public void SetListEnable(bool isEnable) { }

		//// RVA: 0xC9FA20 Offset: 0xC9FA20 VA: 0xC9FA20
		//public void UpdateListPosition(bool isForce = False) { }

		//// RVA: 0xC9FC84 Offset: 0xC9FC84 VA: 0xC9FC84
		//private bool CheckUpdateCenterItem(float rate) { }

		//// RVA: 0xC9FDA4 Offset: 0xC9FDA4 VA: 0xC9FDA4
		private void UpdateCenterItem(float rate, bool isClip, bool isForce = false)
		{
			UnityEngine.Debug.LogError("TODO UpdateCenterItem");
			if (OnUpdateCenter != null)
				OnUpdateCenter.Invoke(0, _centerItem);
		}

		// RVA: 0xCA00C0 Offset: 0xCA00C0 VA: 0xCA00C0 Slot: 17
		public void OnPointerDown(PointerEventData eventData)
		{
			UnityEngine.Debug.LogError("TODO MusicScrollView OnPointerDown");
		}

		// RVA: 0xCA0134 Offset: 0xCA0134 VA: 0xCA0134 Slot: 18
		public void OnPointerUp(PointerEventData eventData)
		{
			UnityEngine.Debug.LogError("TODO MusicScrollView OnPointerUp");
		}

		// RVA: 0xCA0170 Offset: 0xCA0170 VA: 0xCA0170 Slot: 19
		public void OnBeginDrag(PointerEventData eventData)
		{
			UnityEngine.Debug.LogError("TODO MusicScrollView OnBeginDrag");
		}

		// RVA: 0xCA01E8 Offset: 0xCA01E8 VA: 0xCA01E8 Slot: 21
		public void OnDrag(PointerEventData eventData)
		{
			UnityEngine.Debug.LogError("TODO MusicScrollView OnDrag");
		}

		// RVA: 0xCA0540 Offset: 0xCA0540 VA: 0xCA0540 Slot: 20
		public void OnEndDrag(PointerEventData eventData)
		{
			UnityEngine.Debug.LogError("TODO MusicScrollView OnEndDrag");
		}

		//// RVA: 0xCA07F8 Offset: 0xCA07F8 VA: 0xCA07F8
		//private void OnApplicationPause(bool pauseStatus) { }

		//// RVA: 0xCA045C Offset: 0xCA045C VA: 0xCA045C
		//private void UpdateItemPosition(float rate) { }

		//// RVA: 0xCA08E8 Offset: 0xCA08E8 VA: 0xCA08E8
		private void LateUpdate()
		{
			UnityEngine.Debug.LogError("TODO MusicScrollView LateUpdate");
			UpdateCenterItem(0.0f, false, true);
		}

		//// RVA: 0xCA0B88 Offset: 0xCA0B88 VA: 0xCA0B88
		//private void OnClickList(MusicScrollItem scrollItem) { }

		//// RVA: 0xCA0DC8 Offset: 0xCA0DC8 VA: 0xCA0DC8
		public void SetPosition(int list_no)
		{
			UnityEngine.Debug.LogError("TODO MusicScrollView SetPosition");
		}
	}
}
