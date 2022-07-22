using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class DivaExtensionAdjust : MonoBehaviour
	{
		//[HeaderAttribute] // RVA: 0x68647C Offset: 0x68647C VA: 0x68647C
		public float[] AdjustScaleFactor = new float[10]; //{ C906995C247542613F4C4D48C8343F3CFD6470A4 }; // 0xC
		public float[] AdjustRotationFactor = new float[10]; // { 90F7E05841CE4019124B0D0DBC487D36F62E006D; }; // 0x10
		//[HeaderAttribute] // RVA: 0x6864B0 Offset: 0x6864B0 VA: 0x6864B0
		[SerializeField]
		private List<Transform> scaleAdjustPoint = new List<Transform>(); // 0x14
		[SerializeField]
		private List<Transform> rotationAdjustPoint = new List<Transform>(); // 0x18

		// RVA: 0x1BE8E04 Offset: 0x1BE8E04 VA: 0x1BE8E04
		public void Initialize(int divaId)
		{
			UnityEngine.Debug.LogError("TODOOOOOOOOOOOOOOO fix float val static");
			for(int i = 0; i < scaleAdjustPoint.Count; i++)
			{
				ObjectPositionAdjuster adjuster = scaleAdjustPoint[i].gameObject.AddComponent<ObjectPositionAdjuster>();
				adjuster.Initialize(AdjustScaleFactor[divaId - 1], true, true, true);
			}
			for(int i = 0; i < rotationAdjustPoint.Count; i++)
			{
				ObjectRotationAdjuster adjuster = rotationAdjustPoint[i].gameObject.AddComponent<ObjectRotationAdjuster>();
				adjuster.Initialize(AdjustScaleFactor[divaId - 1], true, true, true); // Why not AdjustRotationFactor ??!!
			}
		}
	}
}
