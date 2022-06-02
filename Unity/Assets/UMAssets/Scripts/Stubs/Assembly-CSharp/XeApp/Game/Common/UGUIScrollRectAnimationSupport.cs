using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class UGUIScrollRectAnimationSupport : MonoBehaviour
	{
		[SerializeField]
		private ScrollRect m_scroll;
		public float m_rate_v;
		public float m_rate_h;
		public bool m_enable_v;
		public bool m_enable_h;
	}
}
