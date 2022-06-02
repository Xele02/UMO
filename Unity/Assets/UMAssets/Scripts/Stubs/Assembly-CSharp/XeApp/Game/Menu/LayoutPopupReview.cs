using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutPopupReview : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_title;
		[SerializeField]
		private Text[] m_description;
		[SerializeField]
		private RectTransform[] m_star_hit_check;
	}
}
