using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationSpItemRemoveContent : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.LogError(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Text[] m_texts;
		[SerializeField]
		private RawImageEx[] m_iconImage;
		[SerializeField]
		private StayButton[] m_stayButton;
	}
}
