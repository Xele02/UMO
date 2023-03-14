using XeSys.Gfx;
using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Gacha
{
	public class GachaResultRoot : LayoutLabelScriptBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private List<GachaResultCard> m_cards;
	}
}
