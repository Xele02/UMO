using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class UseItemList : LayoutUGUIScriptBase
	{
		[SerializeField]
		private LayoutUGUIScrollSupport m_scrollSupport;
		[SerializeField]
		private ScrollRect m_scrollRect;
		[SerializeField]
		private Text[] m_texts;
		[SerializeField]
		private RawImageEx[] m_gradImages;
		[SerializeField]
		private AnimeCurveScriptableObject m_animeCurve;
	}
}
