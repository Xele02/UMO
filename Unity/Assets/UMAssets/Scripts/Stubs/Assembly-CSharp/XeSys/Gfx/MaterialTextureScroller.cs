using UnityEngine;
using System;

namespace XeSys.Gfx
{
	public class MaterialTextureScroller : MonoBehaviour
	{
		[Serializable]
		public class ScrollInfo
		{
			public Vector2 speed;
		}

		public ScrollInfo scroll;
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement Monobehaviour");
		}
	}
}
