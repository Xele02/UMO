using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class SwapScrollList : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ScrollRect m_scrollRect;
		[SerializeField]
		private Vector2 m_contentRect;
		[SerializeField]
		private Vector2 m_leftTopPosition;
		[SerializeField]
		private List<SwapScrollListContent> m_scrollObjects;
		[SerializeField]
		private int m_rowCount;
		[SerializeField]
		private int m_columnCount;
		[SerializeField]
		private bool m_isVertical;
	}
}
