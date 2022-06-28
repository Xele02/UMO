using XeSys.Gfx;
using XeApp.Game.Adv;
using UnityEngine;

namespace XeApp.Game.DownLoad
{
	public class LayoutQuestionaryMessWindow : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private AdvMessage m_message;
		[SerializeField]
		private float m_messageSpeed;
	}
}
