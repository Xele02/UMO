using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class GachaDirectionQuartzSet : GachaDirectionAnimSetBase
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private List<GachaDirectionStone.RefData> m_quartzRefData;
	}
}
