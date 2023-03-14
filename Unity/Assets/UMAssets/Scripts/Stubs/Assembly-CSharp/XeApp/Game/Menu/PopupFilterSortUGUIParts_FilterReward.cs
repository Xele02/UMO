using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_FilterReward : PopupFilterSortUGUIPartsBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private UGUIToggleButton[] m_btn;
		[SerializeField]
		private Text[] m_btn_text;
	}
}
