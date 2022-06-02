using UnityEngine;

namespace XeSys.Gfx
{
	public class PostRenderManager : MonoBehaviour
	{
		[SerializeField]
		private Canvas canvasPrefab;
		[SerializeField]
		private OnPostRenderer renderPrefab;
		public bool mUseGL;
	}
}
