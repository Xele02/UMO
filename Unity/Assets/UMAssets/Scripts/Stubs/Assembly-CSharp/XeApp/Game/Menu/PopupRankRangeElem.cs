using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class PopupRankRangeElem : SwapScrollListContent
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private Text m_label;
		[SerializeField]
		private ActionButton m_button;
	}
}
