using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_RangeSlider : PopupFilterSortUGUIPartsBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
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

		public override Type MyType { get { TodoLogger.Log(0, "Type"); return 0; } }
		protected override System.Collections.IEnumerator OnInitialize() { TodoLogger.Log(0, "OnInitialize"); yield return null; }
	}
}
