using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortParts_FilterGoDivaMusicExp : PopupFilterSortPartsBase
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		[SerializeField]
		private ToggleButton[] m_btn;
		[SerializeField]
		private Text[] m_btn_text;
	}
}
