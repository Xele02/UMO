using XeSys.Gfx;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class MusicSelectCDScroller : LayoutLabelScriptBase
	{
		[SerializeField]
		private RectTransform m_hitRect;
		[SerializeField]
		private int m_scrollMaxFrame;
		[SerializeField]
		private float m_offsetLength;
		[SerializeField]
		private int m_selectionFlipFrame;
		[SerializeField]
		private float m_flickTime;
		[SerializeField]
		private float m_flickLength;
	}
}
