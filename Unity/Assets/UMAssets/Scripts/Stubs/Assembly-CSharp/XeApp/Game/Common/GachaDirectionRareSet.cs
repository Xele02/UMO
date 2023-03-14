using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class GachaDirectionRareSet : GachaDirectionAnimSetBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private List<Renderer> m_cardRenderers;
	}
}
