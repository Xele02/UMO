using UnityEngine;

namespace XeApp.Core
{
	public class FlexibleCameraChanger : MonoBehaviour
	{
		[SerializeField]
		private bool isEnableFlexibleViewport;
		[SerializeField]
		private bool isEnableFlexibleFov;
		[SerializeField]
		private float baseWidth;
		[SerializeField]
		private float baseHeight;
	}
}
