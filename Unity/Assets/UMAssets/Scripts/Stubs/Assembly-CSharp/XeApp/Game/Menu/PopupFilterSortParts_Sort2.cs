using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortParts_Sort2 : PopupFilterSortPartsBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private ToggleButton[] m_btn;
		[SerializeField]
		private Text[] m_text;
		[SerializeField]
		private Text[] m_text_wide;
	}
}
