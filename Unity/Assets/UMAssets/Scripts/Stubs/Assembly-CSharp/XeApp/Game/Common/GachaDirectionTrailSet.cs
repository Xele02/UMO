using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class GachaDirectionTrailSet : GachaDirectionAnimSetBase
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private List<GameObject> m_trails;
	}
}
