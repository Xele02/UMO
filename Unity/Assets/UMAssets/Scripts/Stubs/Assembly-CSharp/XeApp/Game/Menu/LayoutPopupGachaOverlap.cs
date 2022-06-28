using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutPopupGachaOverlap : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Text m_plateName;
		[SerializeField]
		private Text m_desc;
		[SerializeField]
		private RawImageEx m_imagePlate;
	}
}
