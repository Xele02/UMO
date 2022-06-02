using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class HomeBgSelectList : MonoBehaviour
	{
		[SerializeField]
		private SwapScrollList m_scrollList;
		[SerializeField]
		private UGUIButton m_filterButton;
		[SerializeField]
		private UGUIToggleButtonGroup m_sceneToggleGroup;
		[SerializeField]
		private UGUIToggleButtonGroup m_divaToggleGroup;
		[SerializeField]
		private UGUIToggleButtonGroup m_bgDarkToggleGroup;
		[SerializeField]
		private Text m_invalidText;
	}
}
