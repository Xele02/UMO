using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class UGUILoopScrollList : ScrollRect
	{
		[SerializeField]
		private Vector2 m_contentSize;
		[SerializeField]
		private Vector2 m_spacing;
		[SerializeField]
		private List<UGUILoopScrollContent> m_scrollObjects;
		[SerializeField]
		private int m_rowCount;
		[SerializeField]
		private int m_columnCount;
		[SerializeField]
		private AnimationCurve m_animCurve;
	}
}
