using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_RangeSlider : PopupFilterSortUGUIPartsBase
	{
		[SerializeField]
		private UGUIRangeSliders m_rangeSliders;
		[SerializeField]
		private UGUIButton m_minPlusButton;
		[SerializeField]
		private UGUIButton m_minMinusButton;
		[SerializeField]
		private UGUIButton m_maxPlusButton;
		[SerializeField]
		private UGUIButton m_maxMinusButton;
		[SerializeField]
		private Text m_minText;
		[SerializeField]
		private Text m_maxText;
	}
}
