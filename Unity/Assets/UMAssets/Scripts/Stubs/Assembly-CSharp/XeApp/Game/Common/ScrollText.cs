using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class ScrollText : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_text;
		[SerializeField]
		private float m_startDelay;
		[SerializeField]
		private float m_speed;
		[SerializeField]
		private float m_distance;
		[SerializeField]
		private bool m_stop;
		[SerializeField]
		private Text m_copyText;
		[SerializeField]
		private Vector2 m_basePos;
		[SerializeField]
		private Vector2 m_baseSize;
	}
}
