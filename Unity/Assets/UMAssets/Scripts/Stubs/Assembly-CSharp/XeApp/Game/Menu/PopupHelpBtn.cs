using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class PopupHelpBtn : SwapScrollListContent
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private Text m_btn_name;
		[SerializeField]
		private ActionButton m_btn;
	}
}
