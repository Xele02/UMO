using System;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class NoizeTexture : MonoBehaviour, IDisposable
	{
		[SerializeField]
		private Camera m_noizeCamera;
		[SerializeField]
		private RenderTexture m_renderTexture;
		[SerializeField]
		private RawImage m_image;

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		private void Awake()
		{
			TodoLogger.LogError(0, "Implement Monobehaviour");
		}
	}
}
