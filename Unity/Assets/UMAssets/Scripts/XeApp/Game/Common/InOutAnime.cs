using System;
using System.Collections;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class InOutAnime : MonoBehaviour
	{
		public enum InType
		{
			Left = 0,
			Right = 1,
			Top = 2,
			Bottom = 3,
			Scaling = 4,
			ScalingVertical = 5,
			ScalingSide = 6,
			Height = 7,
		}

		public enum State
		{
			None = 0,
			Leave = 1,
			Enter = 2,
		}

		[SerializeField]
		//[HeaderAttribute] // RVA: 0x6885A0 Offset: 0x6885A0 VA: 0x6885A0
		private InOutAnime.InType inType; // 0xC
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x6885F4 Offset: 0x6885F4 VA: 0x6885F4
		private AnimationCurve curve = AnimationCurve.EaseInOut(0, 0, 1, 1); // 0x10
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x68863C Offset: 0x68863C VA: 0x68863C
		private float animTime = 0.5f; // 0x14
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x688698 Offset: 0x688698 VA: 0x688698
		private int moveAmount = 300; // 0x18
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x6886F8 Offset: 0x6886F8 VA: 0x6886F8
		private InOutAnime.State state; // 0x1C
		private Coroutine m_animCoroutine; // 0x20
		private Vector2 m_enterPos; // 0x24
		private Vector2 m_leavePos; // 0x2C
		private bool m_isInit; // 0x34

		//public bool IsEnter { get; } 0x10FEF5C

		//// RVA: 0x10FEF70 Offset: 0x10FEF70 VA: 0x10FEF70
		//private void Start() { }

		//// RVA: 0x10FF614 Offset: 0x10FF614 VA: 0x10FF614
		//private void OnDisable() { }

		//// RVA: 0x10FF620 Offset: 0x10FF620 VA: 0x10FF620
		public bool IsPlaying()
		{
			return m_animCoroutine != null;
		}

		//// RVA: 0x10FF630 Offset: 0x10FF630 VA: 0x10FF630
		public void Enter(bool force = false, Action endCallback = null)
		{
			Enter(animTime, force, endCallback);
		}

		//// RVA: 0x10FF654 Offset: 0x10FF654 VA: 0x10FF654
		public void Enter(float animTime, bool force = false, Action endCallback = null)
		{
			UnityEngine.Debug.LogError("TODO InOutAnim Enter");
		}

		//// RVA: 0x10FFB64 Offset: 0x10FFB64 VA: 0x10FFB64
		//public void Leave(bool force = False, Action endCallback) { }

		//// RVA: 0x10FF244 Offset: 0x10FF244 VA: 0x10FF244
		//public void Leave(float animTime, bool force = False, Action endCallback) { }

		//// RVA: 0x10FFB90 Offset: 0x10FFB90 VA: 0x10FFB90
		//public void ForceLeave(Action endCallback) { }

		//// RVA: 0x10FFB9C Offset: 0x10FFB9C VA: 0x10FFB9C
		//public void ForceLeave(float animTime, Action endCallback) { }

		//// RVA: 0x10FFD6C Offset: 0x10FFD6C VA: 0x10FFD6C
		public void ForceEnter(Action endCallback)
		{
			ForceEnter(animTime, endCallback);
		}

		//// RVA: 0x10FFD78 Offset: 0x10FFD78 VA: 0x10FFD78
		public void ForceEnter(float animTime, Action endCallback)
		{
			if(state != State.Enter)
			{
				if (m_animCoroutine != null)
					StopCoroutine(m_animCoroutine);
				state = State.Enter;
				RectTransform rect = transform as RectTransform;
				m_animCoroutine = StartCoroutine(Co_Animation(rect.anchoredPosition, m_enterPos, animTime, (Vector2 vec) =>
				{
					//0x11003D4
					if(inType < InType.Scaling)
					{
						rect.anchoredPosition = vec;
						return;
					}
					if(inType < InType.Height)
					{
						rect.localScale = vec;
						return;
					}
					if(inType == InType.Height)
					{
						rect.sizeDelta = vec;
					}

				}, endCallback));
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x73CFDC Offset: 0x73CFDC VA: 0x73CFDC
		//// RVA: 0x10FFA28 Offset: 0x10FFA28 VA: 0x10FFA28
		private IEnumerator Co_Animation(Vector2 start, Vector2 end, float animTime, Action<Vector2> animCallback, Action endCallback)
		{
			//private Vector2<diff>5__2; // 0x30
			//private float <time>5__3; // 0x38
			//private float <speed>5__4; // 0x3C
			//0x1100534
			if(animTime < 0)
			{
				if (animCallback != null)
					animCallback(end);
			}
			else
			{
				float time = 0;
				Vector2 diff = end - start;
				float speed = 1.0f / animTime;

				while (time < animTime)
				{
					time = Mathf.Clamp(time = Time.deltaTime, 0, animTime);
					if (animCallback != null)
						animCallback(start + diff * curve.Evaluate(time * speed));
					yield return null;
				}

			}
			if (endCallback != null)
				endCallback();
			m_animCoroutine = null;
		}

		//// RVA: 0x10FFF68 Offset: 0x10FFF68 VA: 0x10FFF68
		//public void SetMoveAmount(int move) { }

		//// RVA: 0x10FEFA0 Offset: 0x10FEFA0 VA: 0x10FEFA0
		//private void SetInitPos() { }
	}
}
