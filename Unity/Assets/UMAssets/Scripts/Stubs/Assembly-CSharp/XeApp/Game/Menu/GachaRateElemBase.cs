using XeSys.Gfx;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class GachaRateElemBase : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.Log(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private RectTransform m_rectTrans;
		[SerializeField]
		private float m_elemWidth;
		[SerializeField]
		private float m_elemHeight;
	}
}
