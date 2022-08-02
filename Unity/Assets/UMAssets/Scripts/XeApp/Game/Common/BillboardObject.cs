using UnityEngine;

namespace XeApp.Game.Common
{
	public class BillboardObject : MonoBehaviour
	{
		public Camera camera; // 0xC
		public bool enableVertical = true; // 0x10

		// RVA: 0xE61A1C Offset: 0xE61A1C VA: 0xE61A1C
		private void Update()
		{
			if(camera == null)
				return;
			if(!enableVertical)
			{
				transform.LookAt(new Vector3(camera.transform.position.x, transform.position.y, camera.transform.position.z));
			}
			else
			{
				transform.LookAt(camera.transform.position);
			}
		}
	}
}
