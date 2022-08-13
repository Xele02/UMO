using UnityEngine;

namespace XeApp.Core
{
	public class TransformFixer : MonoBehaviour
	{
		private Quaternion rotationHold; // 0xC
		private Vector3 positionHold; // 0x1C
		private Vector3 scaleHold; // 0x28

		// RVA: 0x1D78010 Offset: 0x1D78010 VA: 0x1D78010
		private void OnEnable()
		{
			rotationHold = transform.parent.localRotation;
			positionHold = transform.parent.localPosition;
			scaleHold = transform.parent.localScale;
		}

		// RVA: 0x1D78148 Offset: 0x1D78148 VA: 0x1D78148
		private void LateUpdate()
		{
			transform.parent.localRotation = rotationHold;
			transform.parent.localPosition = positionHold;
			transform.parent.localScale = scaleHold;
		}
	}
}
