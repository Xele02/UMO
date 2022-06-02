using UnityEngine.EventSystems;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class DivaComparisonPopup : UIBehaviour
	{
		[SerializeField]
		private DivaComparisonParam[] m_params;
		[SerializeField]
		private InfoButton m_infoButton;
		[SerializeField]
		private LayoutUGUIRuntime m_runtime;
	}
}
