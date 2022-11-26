using UnityEngine.UI;
using UnityEngine;

namespace XeSys.Gfx
{
	public class ImageEx : Image, IAlphaTexture
	{
		[SerializeField]
		private Texture m_AlphaTexture;
		[SerializeField]
		private Material m_MaterialMul;
		[SerializeField]
		private Material m_MaterialAdd;
		[SerializeField]
		private string m_TextureName;

		public Material MaterialMul { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
		public Material MaterialAdd { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
	}
}
