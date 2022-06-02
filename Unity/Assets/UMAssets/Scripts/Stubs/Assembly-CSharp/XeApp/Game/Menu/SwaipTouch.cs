using XeSys.Gfx;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class SwaipTouch : LayoutUGUIScriptBase
	{
		[SerializeField]
		private bool m_is_swaip_width_flag;
		[SerializeField]
		private bool m_is_swaip_height_flag;
		[SerializeField]
		private float m_swaip_width_value;
		[SerializeField]
		private float m_swaip_height_value;
		[SerializeField]
		private float m_flick_width_value;
		[SerializeField]
		private float m_flick_height_value;
		[SerializeField]
		private bool m_ignoreActivePopup;
		[SerializeField]
		private RectTransform m_hit_check;
	}
}
