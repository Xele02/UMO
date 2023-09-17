using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.EventSystems;
using System.Collections;

namespace XeApp.Game.Common
{
	public class SelectScrollView : ScrollRect
	{
		public bool isSingleTouch = true; // 0xF0
		private bool isEnableTouch = true; // 0xF1
		private Coroutine m_coroutine; // 0xF4
		public AnimationCurve curve; // 0xF8
		public int m_itemCount = -1; // 0xFC
		public float selectVelocity = 15; // 0x100
		public Vector2 itemSize = Vector2.one; // 0x104
		public Vector2 spacing = Vector2.zero; // 0x10C

		public List<SelectScrollViewContent> scrollObjects { get; private set; } // 0x114
		public int index { get; private set; } // 0x118
		public bool isDrag { get; private set; } // 0x11C
		public Action<int> OnChangeItem { private get; set; } // 0x120
		public Action<int> OnChangeEndItem { private get; set; } // 0x124
		public Action<bool> OnSwipe { private get; set; } // 0x128

		// // RVA: 0x13900D0 Offset: 0x13900D0 VA: 0x13900D0
		// public void SetItemCount(int count) { }

		// // RVA: 0x13900D8 Offset: 0x13900D8 VA: 0x13900D8 Slot: 61
		// public virtual void AddScrollObject(SelectScrollViewContent obj) { }

		// // RVA: 0x13901AC Offset: 0x13901AC VA: 0x13901AC Slot: 62
		// public virtual void RemoveScrollObject(SelectScrollViewContent obj) { }

		// // RVA: 0x1390284 Offset: 0x1390284 VA: 0x1390284 Slot: 63
		// public virtual void ClearScrollObject() { }

		// // RVA: 0x13903C0 Offset: 0x13903C0 VA: 0x13903C0
		// public void SetPosition(SelectScrollViewContent content, float animTime = 0) { }

		// // RVA: 0x13904EC Offset: 0x13904EC VA: 0x13904EC Slot: 64
		public virtual void SetPosition(int pos, float animTime = 0)
		{
			int cnt = m_itemCount;
			if (m_itemCount < 0)
			{
				cnt = scrollObjects.Count;
			}
			IEnumerator co = Co_SetPosition(Mathf.Clamp(pos, 0, cnt - 1), animTime);
			if (animTime <= 0)
			{
				co.MoveNext();
			}
			else
			{
				m_coroutine = this.StartCoroutineWatched(co);
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73D2AC Offset: 0x73D2AC VA: 0x73D2AC
		// // RVA: 0x1390688 Offset: 0x1390688 VA: 0x1390688
		private IEnumerator Co_SetPosition(int pos, float animTime)
		{
			Vector2 start; // 0x1C
			Vector2 end; // 0x24
			Vector2 diff; // 0x2C
			float time; // 0x34
			float speed; // 0x38

			//0x13916D8
			start = content.anchoredPosition;
			end = start;
			if(vertical)
			{
				end.y = (itemSize.y + spacing.y) * pos;
			}
			if(horizontal)
			{
				end.x = (itemSize.x + spacing.x) * pos;
			}
			index = pos;
			if (OnChangeItem != null)
				OnChangeItem(index);
			diff = end - start;
			time = 0;
			speed = 1.0f / animTime;
			while(time <= animTime)
			{
				time += Time.deltaTime;
				float v = curve.Evaluate(time * speed);
				Vector2 p = (diff * v) + start;
				content.anchoredPosition = p;
				yield return null;
			}
			content.anchoredPosition = end;
			velocity = Vector2.zero;
			if (OnChangeEndItem != null)
				OnChangeEndItem(index);
			m_coroutine = null;
		}

		// // RVA: 0x1390774 Offset: 0x1390774 VA: 0x1390774
		// public bool IsEnableTouchId(PointerEventData eventData) { }

		// RVA: 0x13907B0 Offset: 0x13907B0 VA: 0x13907B0 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			scrollObjects = new List<SelectScrollViewContent>();
			curve = AnimationCurve.EaseInOut(0, 0, 1, 1);
			HorizontalLayoutGroup hlg = content.GetComponent<HorizontalLayoutGroup>();
			if(hlg != null)
			{
				spacing = new Vector2(hlg.spacing, 0);
			}
			VerticalLayoutGroup vlg = content.GetComponent<VerticalLayoutGroup>();
			if (vlg != null)
			{
				spacing = new Vector2(0, vlg.spacing);
			}
			GridLayoutGroup glg = content.GetComponent<GridLayoutGroup>();
			if (glg != null)
			{
				spacing = glg.spacing;
			}
		}

		// RVA: 0x1390AA0 Offset: 0x1390AA0 VA: 0x1390AA0 Slot: 6
		protected override void Start()
		{
			base.Start();
			for(int i = 0; i < content.childCount; i++)
			{
				SelectScrollViewContent rt = content.GetChild(i).GetComponent<SelectScrollViewContent>();
				if(rt != null)
				{
					scrollObjects.Add(rt);
				}
			}
			if(scrollObjects.Count > 0)
			{
				itemSize = scrollObjects[0].GetItemSize();
			}
		}

		// RVA: 0x1390CB0 Offset: 0x1390CB0 VA: 0x1390CB0 Slot: 48
		protected override void LateUpdate()
		{
			if (!isEnableTouch)
				return;
			if(isDrag)
			{
				base.LateUpdate();
				return;
			}
			Vector2 pos = content.anchoredPosition;
			bool b = m_coroutine != null;
			if (vertical)
			{
				if(verticalNormalizedPosition >= 0)
				{
					if(verticalNormalizedPosition <= 1)
					{
						float size = itemSize.y + spacing.y;
						float f = pos.y % size;
						if(Mathf.Abs(f) < size * 0.5f)
						{
							pos.y -= f * Time.deltaTime * selectVelocity;
						}
						else
						{
							float f2 = -1;
							if (pos.y >= 0)
								f2 = 1;
							pos.y += (f2 * size - f) * Time.deltaTime * selectVelocity;
						}
					}
					else
					{
						b = true;
					}
				}
				else
				{
					b = true;
				}
			}
			if(horizontal)
			{
				if (horizontalNormalizedPosition >= 0)
				{
					if (horizontalNormalizedPosition <= 1)
					{
						float size = itemSize.x + spacing.x;
						float f = pos.x % size;
						if (Mathf.Abs(f) < size * 0.5f)
						{
							if (!b)
							{
								pos.x -= f * Time.deltaTime * selectVelocity;
								content.anchoredPosition = pos;
								return;
							}
						}
						else
						{
							float f2 = -1;
							if (pos.x >= 0)
								f2 = 1;
							if (!b)
							{
								pos.x += (f2 * size - f) * Time.deltaTime * selectVelocity;
								content.anchoredPosition = pos;
								return;
							}
						}
					}
				}
			}
			if(!b)
			{
				content.anchoredPosition = pos;
				return;
			}
			base.LateUpdate();
		}

		// RVA: 0x1391018 Offset: 0x1391018 VA: 0x1391018 Slot: 42
		public override void OnScroll(PointerEventData eventData)
		{
			TodoLogger.LogError(0, "OnScroll()");
		}

		// RVA: 0x139102C Offset: 0x139102C VA: 0x139102C Slot: 46
		public override void OnDrag(PointerEventData eventData)
		{
			TodoLogger.LogError(0, "OnDrag()");
		}

		// RVA: 0x1391040 Offset: 0x1391040 VA: 0x1391040 Slot: 44
		public override void OnBeginDrag(PointerEventData eventData)
		{
			TodoLogger.LogError(0, "OnBeginDrag()");
		}

		// RVA: 0x1391124 Offset: 0x1391124 VA: 0x1391124 Slot: 45
		public override void OnEndDrag(PointerEventData eventData)
		{
			TodoLogger.LogError(0, "OnEndDrag()");
		}
	}
}
