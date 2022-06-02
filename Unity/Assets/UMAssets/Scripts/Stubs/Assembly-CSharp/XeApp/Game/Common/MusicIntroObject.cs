using UnityEngine;
using XeSys.uGUI;

namespace XeApp.Game.Common
{
	public class MusicIntroObject : MonoBehaviour
	{
		[SerializeField]
		private Camera m_musicCamera;
		[SerializeField]
		private Camera m_demoCamera;
		[SerializeField]
		private GameValkyrieObject m_valkyrie;
		[SerializeField]
		private UGUIFader fader;
	}
}
