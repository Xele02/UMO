using XeSys.Gfx;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class CostumeSelectScroller : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.LogError(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private float m_swaip_height_value;
		[SerializeField]
		private float m_flick_height_value;
		[SerializeField]
		private RectTransform m_hit_check;
	}
}
