using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_FilterSeries : PopupFilterSortUGUIPartsBase
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		[SerializeField]
		private UGUIToggleButton[] m_btn;
		[SerializeField]
		private RawImageEx[] m_btn_image;
		[SerializeField]
		private Text[] m_btn_text;

		public override Type MyType { get { TodoLogger.LogError(0, "Type"); return 0; } }
		protected override System.Collections.IEnumerator OnInitialize() { TodoLogger.LogError(0, "OnInitialize"); yield return null; }
	}
}
