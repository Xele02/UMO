using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class GachaDirectionRareSet : GachaDirectionAnimSetBase
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private List<Renderer> m_cardRenderers;
	}
}
