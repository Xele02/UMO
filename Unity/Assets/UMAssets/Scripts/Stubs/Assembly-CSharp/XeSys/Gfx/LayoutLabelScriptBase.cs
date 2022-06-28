using UnityEngine;

namespace XeSys.Gfx
{
	public class LayoutLabelScriptBase : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private LayoutLabelDef m_labelDef;
	}
}
