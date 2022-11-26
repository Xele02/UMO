using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class CommonMenuStack2 : LayoutLabelScriptBase
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private ActionButton m_backButton;
		[SerializeField]
		private CommonMenuStackLabel2 m_label;
	}
}
