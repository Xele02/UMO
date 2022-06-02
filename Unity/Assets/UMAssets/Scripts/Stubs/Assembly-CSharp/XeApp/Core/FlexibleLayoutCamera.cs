using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Core
{
	public class FlexibleLayoutCamera : MonoBehaviour
	{
		[SerializeField]
		private List<Camera> flexibleViewportCameraList;
		[SerializeField]
		private List<Camera> flexibleFovCameraList;
		[SerializeField]
		private float baseWidth;
		[SerializeField]
		private float baseHeight;
	}
}
