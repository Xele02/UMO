using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class DivaObjectParam : ScriptableObject
	{
		[SerializeField]
		private List<float> m_hipScaleFactor;
		[SerializeField]
		private List<Vector2> m_eyeMeshUvRate;
	}
}
