using UnityEngine;

namespace XeApp
{
	public class DecorationScrollControllerArgs : DecorationControlArgs
	{
		public Rect m_screenRect; // 0x8
		public Rect m_scrollRect; // 0x18
		public Camera m_decorationCamera; // 0x28
	}
}
