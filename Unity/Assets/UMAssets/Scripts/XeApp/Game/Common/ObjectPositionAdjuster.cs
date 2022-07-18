using UnityEngine;

namespace XeApp.Game.Common
{
	public class ObjectPositionAdjuster : MonoBehaviour
	{
		public float scale; // 0xC
		public bool enableX; // 0x10
		public bool enableY; // 0x11
		public bool enableZ; // 0x12
		public float rateX; // 0x14
		public float rateY; // 0x18
		public float rateZ; // 0x1C

		// RVA: 0xAE51BC Offset: 0xAE51BC VA: 0xAE51BC
		public void Initialize(float scale, bool enableX, bool enableY, bool enableZ)
		{
			this.enableX = enableX;
			this.scale = scale;
			this.enableY = enableY;
			this.enableZ = enableZ;
		}

		// RVA: 0xAF479C Offset: 0xAF479C VA: 0xAF479C
		private void LateUpdate()
		{
			Vector3 pos = transform.localPosition;
			if(enableX)
			{
				pos.x *= Mathf.Lerp(scale, 1.0f, rateX);
			}
			if(enableY)
			{
				pos.y *= Mathf.Lerp(scale, 1.0f, rateY);
			}
			if (enableZ)
			{
				pos.z *= Mathf.Lerp(scale, 1.0f, rateZ);
			}
			transform.localPosition = pos;
		}
	}
}
