using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class DivaExtensionAdjust : MonoBehaviour
	{
		public float[] AdjustScaleFactor;
		public float[] AdjustRotationFactor;
		[SerializeField]
		private List<Transform> scaleAdjustPoint;
		[SerializeField]
		private List<Transform> rotationAdjustPoint;
	}
}
