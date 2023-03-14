using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class SNSTalkWindow : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.Log(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Text m_talk;
		[SerializeField]
		private Text m_name;
		[SerializeField]
		private RawImageEx m_image;
	}
}
