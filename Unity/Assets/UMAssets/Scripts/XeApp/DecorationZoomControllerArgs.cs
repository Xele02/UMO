using UnityEngine;

namespace XeApp
{
	public class DecorationZoomControllerArgs : DecorationControlArgs
	{
		public Rect m_screenRect; // 0x8
		public float m_zoomMax; // 0x18
		public Rect m_zoomRect; // 0x1C
		public DecorationScrollController m_scrollController; // 0x2C
	}
}
