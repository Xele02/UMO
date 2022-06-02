using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class GuestListWindow : LayoutLabelScriptBase
	{
		[SerializeField]
		private Text m_windowMessage;
		[SerializeField]
		private List<Text> m_countValues;
		[SerializeField]
		private List<Text> m_maxValues;
		[SerializeField]
		private Text m_cautionMessage;
	}
}
