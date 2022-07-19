using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class DivaObjectParam : ScriptableObject
	{
		[SerializeField]
		private List<float> m_hipScaleFactor = new List<float>(10); // 0xC
		[SerializeField]
		private List<Vector2> m_eyeMeshUvRate = new List<Vector2>(10); // 0x10

		// RVA: 0x1BF7D8C Offset: 0x1BF7D8C VA: 0x1BF7D8C
		public float GetHipScaleFactor(int divaId)
		{
			return m_hipScaleFactor[divaId - 1];
		}

		// RVA: 0x1BF7E0C Offset: 0x1BF7E0C VA: 0x1BF7E0C
		public Vector2 GetEyeMeshUvRate(int divaId)
		{
			return m_eyeMeshUvRate[divaId - 1];
		}
	}
}
