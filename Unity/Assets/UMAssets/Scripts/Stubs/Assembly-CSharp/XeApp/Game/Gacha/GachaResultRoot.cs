using XeSys.Gfx;
using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Gacha
{
	public class GachaResultRoot : LayoutLabelScriptBase
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private List<GachaResultCard> m_cards;
	}
}
