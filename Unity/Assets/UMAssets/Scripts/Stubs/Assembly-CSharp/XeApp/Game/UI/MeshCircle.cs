using UnityEngine;

namespace XeApp.Game.UI
{
	public class MeshCircle : MonoBehaviour
	{
		[SerializeField]
		private int m_width;
		[SerializeField]
		private int m_height;
		[SerializeField]
		private float m_angleOrigin;
		[SerializeField]
		private float m_angleEnd;
		[SerializeField]
		private Rect m_uvRect;
		[SerializeField]
		private bool m_isInverse;
		[SerializeField]
		private bool m_isUseVertexColor;
		[SerializeField]
		private Color m_vertexColor;
	}
}
