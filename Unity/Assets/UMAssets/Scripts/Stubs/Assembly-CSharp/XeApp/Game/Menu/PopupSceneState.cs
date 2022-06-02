using UnityEngine.EventSystems;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopupSceneState : UIBehaviour
	{
		[SerializeField]
		private SceneStatusParam m_param;
		[SerializeField]
		private LayoutUGUIRuntime m_runtime;
	}
}
