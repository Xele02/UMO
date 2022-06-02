using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class NoizeTexture : MonoBehaviour
	{
		[SerializeField]
		private Camera m_noizeCamera;
		[SerializeField]
		private RenderTexture m_renderTexture;
		[SerializeField]
		private RawImage m_image;
	}
}
