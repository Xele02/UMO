using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutOfferProgress : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Text m_plantoonName;
		[SerializeField]
		private Text m_progressTime;
		[SerializeField]
		private Text[] ValkyrieName;
		[SerializeField]
		private RawImageEx[] ValkyrieNameIcon;
	}
}
