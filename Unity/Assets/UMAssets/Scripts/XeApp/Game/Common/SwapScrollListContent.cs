using UnityEngine;
using UnityEngine.Events;
using XeSys.Gfx;

namespace XeApp.Game.Common
{
	public class SwapScrollListContent : LayoutUGUIScriptBase
	{
		public class SwapScrollListContentClickButtonEvent : UnityEvent<int, SwapScrollListContent> { }
		public SwapScrollListContentClickButtonEvent ClickButton = new SwapScrollListContentClickButtonEvent(); // 0x14
		private RectTransform m_rectTransform; // 0x18

		public int Index { get; set; } // 0x1C
		public RectTransform RectTransform { get { 
			if(m_rectTransform == null) m_rectTransform = GetComponent<RectTransform>();
			return m_rectTransform;
		} } //0x1CCBC44
		public Vector2 AnchoredPosition { get { return RectTransform.anchoredPosition; } set { RectTransform.anchoredPosition = value; } } //0x1CCD914 0x1CCBC04
		public Vector2 Pivot { get { return RectTransform.pivot; } set { RectTransform.pivot = value; } } //0x1CCDEB8 0x1CCBB84
		public Vector2 AnchorMin { get { return RectTransform.anchorMin; } set { RectTransform.anchorMin = value; } } //0x1CCDEF4 0x1CCBB04
		public Vector2 AnchorMax { get { return RectTransform.anchorMax; } set { RectTransform.anchorMax = value; } } //0x1CCDF30 0x1CCBB44
		public Vector2 Size { get { return RectTransform.sizeDelta; } set { RectTransform.sizeDelta = value; } } //0x1CCDF6C 0x1CCBBC4
	}
}
