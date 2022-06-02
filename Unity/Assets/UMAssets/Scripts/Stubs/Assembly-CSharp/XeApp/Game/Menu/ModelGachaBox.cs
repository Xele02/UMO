using UnityEngine;
using System;

namespace XeApp.Game.Menu
{
	public class ModelGachaBox : MonoBehaviour
	{
		[Serializable]
		private class BoxTexture
		{
			[Serializable]
			public class TextureSet
			{
				public Texture main;
				public Texture add;
				public Texture effect;
			}

			public TextureSet[] box;
		}

		[SerializeField]
		private Animator m_animObject;
		[SerializeField]
		private Animator m_animCamera;
		[SerializeField]
		private Animator m_animBgFade;
		[SerializeField]
		private Animator m_animBgEffect;
		[SerializeField]
		private Camera m_camera;
		[SerializeField]
		private MeshRenderer[] m_meshes;
		[SerializeField]
		private MeshRenderer m_addMeshes;
		[SerializeField]
		private Material m_effect;
		[SerializeField]
		private BoxTexture[] m_textures;
	}
}
