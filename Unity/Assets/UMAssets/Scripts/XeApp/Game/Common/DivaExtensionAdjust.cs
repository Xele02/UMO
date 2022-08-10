using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class DivaExtensionAdjust : MonoBehaviour
	{
		//[HeaderAttribute] // RVA: 0x68647C Offset: 0x68647C VA: 0x68647C
		public float[] AdjustScaleFactor = new float[10] { 0.9506f, 1.0216f, 1.0237f, 0.9696f, 0.8915f, 0.98f, 1.0642f, 0.964f, 1, 1 }; // 0xC
		public float[] AdjustRotationFactor = new float[10] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }; // 0x10
		//[HeaderAttribute] // RVA: 0x6864B0 Offset: 0x6864B0 VA: 0x6864B0
		[SerializeField]
		private List<Transform> scaleAdjustPoint = new List<Transform>(); // 0x14
		[SerializeField]
		private List<Transform> rotationAdjustPoint = new List<Transform>(); // 0x18

		// RVA: 0x1BE8E04 Offset: 0x1BE8E04 VA: 0x1BE8E04
		public void Initialize(int divaId)
		{
			TodoLogger.Log(0, "TODOOOOOOOOOOOOOOO fix float val static");
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
