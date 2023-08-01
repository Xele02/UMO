using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_ExclusiveToggleButtons : PopupFilterSortUGUIPartsBase
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		[SerializeField]
		private int m_columnCount;
		[SerializeField]
		private UGUIToggleButtonGroup m_group;
		[SerializeField]
		private UGUIToggleButton[] m_btn;
		[SerializeField]
		private Text[] m_text;

		public override Type MyType { get { TodoLogger.LogError(0, "Type"); return 0; } }
		protected override System.Collections.IEnumerator OnInitialize() { TodoLogger.LogError(0, "OnInitialize"); yield return null; }
	}
}
