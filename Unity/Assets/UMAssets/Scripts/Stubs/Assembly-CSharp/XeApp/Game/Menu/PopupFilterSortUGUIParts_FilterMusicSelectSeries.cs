using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_FilterMusicSelectSeries : PopupFilterSortUGUIPartsBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private UGUIToggleButtonGroup m_btnGroup;
		[SerializeField]
		private UGUIToggleButton[] m_btn;
		[SerializeField]
		private RawImageEx[] m_seriesImage;

		public override Type MyType { get { TodoLogger.Log(0, "Type"); return 0; } }
		protected override System.Collections.IEnumerator OnInitialize() { TodoLogger.Log(0, "OnInitialize"); yield return null; }
	}
}
