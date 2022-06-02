using UnityEngine;

namespace XeApp.Game.Common
{
	public class DivaModeObject : MonoBehaviour
	{
		[SerializeField]
		private Renderer m_movieRenderer;
		[SerializeField]
		private Camera m_billboardCamera;
		[SerializeField]
		private float m_billboardDist;
		[SerializeField]
		private LayerMask m_overrideCullingMask1;
		[SerializeField]
		private LayerMask m_overrideCullingMask2;
	}
}
