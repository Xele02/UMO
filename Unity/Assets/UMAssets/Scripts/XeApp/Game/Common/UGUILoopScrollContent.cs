using UnityEngine;

namespace XeApp.Game.Common
{
	public class UGUILoopScrollContent : MonoBehaviour
	{
		private RectTransform m_rectTransform; // 0xC

		public RectTransform RectTransform { get
			{
				if(m_rectTransform == null)
				{
					m_rectTransform = GetComponent<RectTransform>();
				}
				return m_rectTransform;
			}
		} //0x1CD3994
		public Vector2 AnchoredPosition { get { return RectTransform.anchoredPosition; } set { RectTransform.anchoredPosition = value; } } //0x1CD3A48 0x1CD3A84
		//public Vector2 Pivot { get; set; } 0x1CD3AC4 0x1CD3B00
		//public Vector2 AnchorMin { get; set; } 0x1CD3B40 0x1CD3B7C
		//public Vector2 AnchorMax { get; set; } 0x1CD3BBC 0x1CD3BF8
		//public Vector2 Size { get; set; } 0x1CD3C38 0x1CD3C74

		//// RVA: 0x1CD3CB4 Offset: 0x1CD3CB4 VA: 0x1CD3CB4 Slot: 4
		//public virtual int GetIndex() { }
	}
}
