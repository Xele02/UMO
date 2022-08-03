using UnityEngine.EventSystems;
using UnityEngine;
using System;
using XeApp.Game.Common;

namespace XeApp.Game.MusicSelect
{
	public class MusicScrollView : UIBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
	{
		//private float scrollSpling = 6; // 0xC
		private int longScrollCount = 6; // 0x10
		private float scrollVelocity = 1.5f; // 0x14
		//private float singleMoveSpling = 6; // 0x18
		private float singleScrollVelocity = 0.5f; // 0x1C
		private float centerUpdateRate = 0.6f; // 0x20
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
		private Vector2 _scrollValue; // 0x4C
		private Vector2 _prevPosition; // 0x54
		private Vector2 _velocity; // 0x5C
		//private Vector2 _clipPosition; // 0x64
		private float _prevRate; // 0x6C
		private bool _isDraging; // 0x70
		private bool _isClip; // 0x71
		private bool _isTouch; // 0x72
		private bool _isSingleScroll; // 0x73
		private bool _isReturn; // 0x74
		private bool _isScrollCancel; // 0x75
		private int _currentIndex; // 0x78
		private float target; // 0x7C
		private float prev; // 0x80
		private int prevCenterIndex = -1; // 0x84
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
		public void SetListEnable(bool isEnable)
		{
			for(int i = 0; i < _overScrollItem.Length; i++)
			{
				_overScrollItem[i].gameObject.SetActive(isEnable);
			}
			for (int i = 0; i < _underScrollItem.Length; i++)
			{
				_underScrollItem[i].gameObject.SetActive(isEnable);
			}
			_centerItem.gameObject.SetActive(isEnable);
		}

		//// RVA: 0xC9FA20 Offset: 0xC9FA20 VA: 0xC9FA20
		public void UpdateListPosition(bool isForce = false)
		{
			float val = _scrollValue.y / 90.0f;
			if(Math.Truncate(val) == 0 && !isForce)
				return;
			int newIndex = _currentIndex + (int)Math.Truncate(val);
			_currentIndex = newIndex;
			if (newIndex < 0)
				_currentIndex = _itemCount - 1;
			if(newIndex >= _itemCount)
				_currentIndex = 0;
			UnityEngine.Debug.Log("Current scroll index : " + _currentIndex+" "+ newIndex);
			int startIndex = _currentIndex;
			for(int i = 0; i < _overScrollItem.Length; i++)
			{
				if(startIndex < 0)
					startIndex = _itemCount - 1;
				if(OnUpdateListItem != null)
					OnUpdateListItem.Invoke(startIndex, _overScrollItem[i]);
				startIndex--;
			}
			startIndex = _currentIndex;
			for(int i = 0; i < _underScrollItem.Length; i++)
			{
				if(startIndex >= _itemCount)
					startIndex = 0;
				if(OnUpdateListItem != null)
					OnUpdateListItem.Invoke(startIndex, _underScrollItem[i]);
				startIndex++;
			}
		}

		//// RVA: 0xC9FC84 Offset: 0xC9FC84 VA: 0xC9FC84
		//private bool CheckUpdateCenterItem(float rate) { }

		//// RVA: 0xC9FDA4 Offset: 0xC9FDA4 VA: 0xC9FDA4
		private void UpdateCenterItem(float rate, bool isClip, bool isForce = false)
		{
			float absRate = Math.Abs(rate);
			bool b = false;
			if(absRate < Math.Abs(_prevRate))
			{
				if((absRate%1) < (1 - centerUpdateRate))
					b = true;
			}
			bool c = b || isForce;
			if(centerUpdateRate <= absRate%1)
				c = true;
			if(!c)
			{
				_prevRate = rate;
				return;
			}
			int step = (int)Math.Truncate(_scrollValue.y/ 90.0);
			int index = _currentIndex;
			index = index + step;
			if(!isClip && !isForce)
			{
				if(absRate < 1.0f)
				{
					int a = !b ? 1 : 0;
					if(rate < 0)
						a = -a;
					index += a;
				}
				else
				{
					int e = 0;
					if(rate >= 0)
					{
						e = (int)Math.Truncate(absRate);
					}
					else if(!b)
					{
						e = -(int)Math.Truncate(absRate);
					}
					index += e;
				}
			}
			int d = 0;
			if(index < _itemCount)
				d = index;
			if(index < 0)
				d = _itemCount - 1;
			if(!isForce)
			{
				if(prevCenterIndex != d)
				{
					if(_itemCount != 0)
					{
						SoundManager.Instance.sePlayerMenu.Play(77);
					}
							
					if (OnUpdateCenter != null)
						OnUpdateCenter.Invoke(d, _centerItem);
				}
			}
			else
			{
				if (OnUpdateCenter != null)
					OnUpdateCenter.Invoke(d, _centerItem);
			}
			prevCenterIndex = d;
			_prevRate = rate;
		}

		// RVA: 0xCA00C0 Offset: 0xCA00C0 VA: 0xCA00C0 Slot: 17
		public void OnPointerDown(PointerEventData eventData)
		{
#if UNITY_ANDROID
			if(eventData.pointerId == 0)
#else
			if(eventData.pointerId == -1)
#endif
			{
				_isTouch = true;
				_velocity = new Vector2(0, 0);
			}
		}

		// RVA: 0xCA0134 Offset: 0xCA0134 VA: 0xCA0134 Slot: 18
		public void OnPointerUp(PointerEventData eventData)
		{
#if UNITY_ANDROID
			if(eventData.pointerId == 0)
#else
			if(eventData.pointerId == -1)
#endif
			{
				_isTouch = false;
			}
		}

		// RVA: 0xCA0170 Offset: 0xCA0170 VA: 0xCA0170 Slot: 19
		public void OnBeginDrag(PointerEventData eventData)
		{
			if(_isScrollCancel) // ?? _isScrollCancel + 3U & 3) != 3)
				return;

#if UNITY_ANDROID
			if(eventData.pointerId == 0)
#else
			if(eventData.pointerId == -1)
#endif
			{
				if(OnScrollStartEvent != null)
					OnScrollStartEvent.Invoke();
				_isTouch = false;
				_isDraging = true;
				_isClip = false;
				_isReturn = false;
			}
		}

		// RVA: g0xCA01E8g Offset: 0xCA01E8 VA: 0xCA01E8 Slot: 21
		public void OnDrag(PointerEventData eventData)
		{
			if(_isScrollCancel) // ?? _isScrollCancel + 3U & 3) != 3)
				return;

#if UNITY_ANDROID
			if(eventData.pointerId == 0)
#else
			if(eventData.pointerId == -1)
#endif
			{
				_scrollValue += eventData.delta;
				UnityEngine.Debug.Log("scroll value : "+_scrollValue);
				_velocity = Vector2.Lerp(_velocity, (_prevPosition - eventData.position) / 0.01666667f, 0.1666667f);
				UpdateItemPosition(_scrollValue.y / 90.0f);
				UpdateCenterItem(_scrollValue.y / 90.0f, false, false);
				UpdateListPosition(false);
				for(int i = 0; i < 2; i++)
				{
					_scrollValue[i] = _scrollValue[i] % 90;
				}
			}
		}

		// RVA: 0xCA0540 Offset: 0xCA0540 VA: 0xCA0540 Slot: 20
		public void OnEndDrag(PointerEventData eventData)
		{
			if(_isScrollCancel) // ?? _isScrollCancel + 3U & 3) != 3)
				return;

#if UNITY_ANDROID
			if(eventData.pointerId == 0)
#else
			if(eventData.pointerId == -1)
#endif
			{
				_isSingleScroll = false;
				_isDraging = false;
				target = 0;
				prev = 0;
				int i = 0;
				int j = 0;
				do
				{
					do
					{
						i = j;
						j = 1;
					} while(i == 0);
					int val = (int)(_scrollValue.y % 90.0f);
					if(Math.Abs(eventData.delta.y) / Screen.height < scrollVelocity * Time.deltaTime)
					{
						if(Math.Abs(eventData.delta.y) / Screen.height < singleScrollVelocity * Time.deltaTime)
						{
							if(Math.Abs(val/90.0f) < centerUpdateRate)
							{
								j = 0;
								_isSingleScroll = true;
								_isReturn = true;
							}
							else
							{
								_isSingleScroll = true;
								j = -1;
								if(val/90.0f > 0)
									j = 1;
							}
						}
						else
						{
							_isSingleScroll = true;
							j = -1;
							if(eventData.delta.y > 0)
								j = 1;
						}
					}
					else
					{
						_isSingleScroll = false;
						j = longScrollCount;
						if(eventData.delta.y < 0)
							j = -j;
					}
					_velocity[i] = 0.0f;
					target = j * 90.0f - val;
				} while(i + 1 != 2);
			}
		}

		//// RVA: 0xCA07F8 Offset: 0xCA07F8 VA: 0xCA07F8
		//private void OnApplicationPause(bool pauseStatus) { }

		//// RVA: 0xCA045C Offset: 0xCA045C VA: 0xCA045C
		private void UpdateItemPosition(float rate)
		{
			for(int i = 0; i < _overScrollItem.Length; i++)
			{
				_overScrollItem[i].UpdatePosition(rate);
			}
			for(int i = 0; i < _underScrollItem.Length; i++)
			{
				_underScrollItem[i].UpdatePosition(rate);
			}
		}

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
			_isDraging = false;
			_isScrollCancel = false;
			_isSingleScroll = false;
			_scrollValue.y  = 0;
			_currentIndex = list_no;
			target = 0;
			prev = 0;
			UpdateListPosition(true);
			UpdateCenterItem(0, false, false);
		}
	}
}
