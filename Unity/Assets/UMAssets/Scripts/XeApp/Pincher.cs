
using UnityEngine;

namespace XeApp
{ 
	internal class Pincher : MonoBehaviour
	{
		private Transform pt; // 0xC
		private DecorationChara target; // 0x10
		private Transform tt; // 0x14
		private SpriteRenderer tsr; // 0x18
		private SpriteRenderer sr; // 0x1C
		private Transform st; // 0x20
		private float heightOffset; // 0x24
		private float fall; // 0x28
		[SerializeField]
		private float heightOffsetRate; // 0x2C
		private bool hasPinched; // 0x30

		public bool IsFloating { get { return hasPinched; } } //0x1923150
		public float TargetHeight { get; private set; } // 0x34

		//// RVA: 0x1923168 Offset: 0x1923168 VA: 0x1923168
		//public static Pincher Instantiate(DecorationChara pinchTarget, SpriteRenderer sr) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6ABC20 Offset: 0x6ABC20 VA: 0x6ABC20
		//// RVA: 0x1923478 Offset: 0x1923478 VA: 0x1923478
		//private IEnumerator Co_LoadShadow() { }

		// RVA: 0x1923524 Offset: 0x1923524 VA: 0x1923524
		public void UpdateShadowPos()
		{
			if(sr != null)
			{
				sr.sortingOrder = tsr.sortingOrder - 1;
			}
			if(st != null)
			{
				st.localPosition = new Vector3(0, TargetHeight * -0.5f - heightOffset, 0) + tt.localPosition;
			}
		}

		// RVA: 0x1923728 Offset: 0x1923728 VA: 0x1923728
		public void Pinch()
		{
			hasPinched = true;
			heightOffset = TargetHeight * heightOffsetRate;
			pt.localPosition = new Vector3(0, heightOffset, 0);
			if (sr != null)
				sr.enabled = true;
		}

		// RVA: 0x192384C Offset: 0x192384C VA: 0x192384C
		public void Release()
		{
			fall = 0;
			hasPinched = false;
			if (sr != null)
				sr.enabled = false;
		}

		// RVA: 0x192390C Offset: 0x192390C VA: 0x192390C
		public void Update()
		{
			if(!hasPinched)
			{
				if(heightOffset > 0)
				{
					fall += 1;
					heightOffset -= Mathf.Min(heightOffset, fall);
					pt.localPosition = new Vector3(0, heightOffset, 0);
					UpdateShadowPos();
				}
			}
			if(tt == null)
			{
				Destroy(gameObject);
			}
		}
	}
}
