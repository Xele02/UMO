using UnityEngine;

namespace XeApp.Game.Common
{
	public class ObjectRotationAdjuster : MonoBehaviour
	{
		public float scale; // 0xC
		public bool enableX; // 0x10
		public bool enableY; // 0x11
		public bool enableZ; // 0x12

		// RVA: 0xAF49A4 Offset: 0xAF49A4 VA: 0xAF49A4
		public void Initialize(float scale, bool enableX, bool enableY, bool enableZ)
		{
			this.scale = scale;
			this.enableX = enableX;
			this.enableY = enableY;
			this.enableZ = enableZ;
		}

		// RVA: 0xAF49BC Offset: 0xAF49BC VA: 0xAF49BC
		private void LateUpdate()
		{
			Vector3 angle = transform.localEulerAngles;
			if(enableX)
			{
				angle.x *= scale;
			}
			if (enableY)
			{
				angle.y *= scale;
			}
			if (enableZ)
			{
				angle.z *= scale;
			}
			transform.localEulerAngles = angle;
		}
	}
}
