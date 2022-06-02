using UnityEngine;

namespace XeApp.Game.Common
{
	public class FindCanvasCamera : MonoBehaviour
	{
		[SerializeField]
		private Canvas m_canvas;
		[SerializeField]
		private bool m_isOverride;
		[SerializeField]
		private float m_near;
		[SerializeField]
		private float m_far;
		[SerializeField]
		private float m_size;
		[SerializeField]
		private float m_depth;
	}
}
