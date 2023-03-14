using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_FilterPlateRarity : PopupFilterSortUGUIPartsBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private GameObject[] m_btnRoot;
		[SerializeField]
		private UGUIToggleButton[] m_btn;
		[SerializeField]
		private Image[] m_image;
		[SerializeField]
		private Text[] m_text;
	}
}
