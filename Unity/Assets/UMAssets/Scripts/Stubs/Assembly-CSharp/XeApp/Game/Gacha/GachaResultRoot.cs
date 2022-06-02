using XeSys.Gfx;
using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Gacha
{
	public class GachaResultRoot : LayoutLabelScriptBase
	{
		[SerializeField]
		private List<GachaResultCard> m_cards;
	}
}
