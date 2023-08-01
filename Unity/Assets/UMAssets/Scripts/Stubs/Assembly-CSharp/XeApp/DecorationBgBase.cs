using UnityEngine;
using System;
using System.Collections.Generic;

namespace XeApp
{
	public class DecorationBgBase : MonoBehaviour
	{
		[Serializable]
		public class BgMeshData
		{
			public List<int> triangles;
			public List<Vector2> vertices;
		}

		private void Awake()
		{
			TodoLogger.LogError(0, "Implement Monobehaviour");
		}
	}
}
