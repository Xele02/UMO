using UnityEngine;
using XeSys.Gfx;
using UnityEngine.UI;

namespace XeApp.Game.DownLoad
{
	public class LayoutQuestionary : MonoBehaviour
	{
		[SerializeField]
		private GameObject m_windowPrefab;
		[SerializeField]
		private GameObject m_messWindowPrefab;
		[SerializeField]
		private LayoutUGUIHitOnly m_inputBlocker;
		[SerializeField]
		private Button m_messageTouchArea;
	}
}
