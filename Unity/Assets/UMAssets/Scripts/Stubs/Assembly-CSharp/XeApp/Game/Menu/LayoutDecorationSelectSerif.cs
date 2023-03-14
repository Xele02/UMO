using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationSelectSerif : LayoutDecorationSelectItemBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private List<Text> m_texts;
	}
}
