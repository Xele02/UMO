using XeSys.Gfx;
using System;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game
{
	public class TextureListSupport : LayoutUGUIScriptBase
	{
		[Serializable]
		public class Data
		{
			public Data(RawImageEx image)
			{
			}

			[SerializeField]
			private string m_texName;
			[SerializeField]
			private Texture m_baseTex;
			[SerializeField]
			private Texture m_maskTex;
			[SerializeField]
			private Material m_mulMat;
			[SerializeField]
			private Material m_addMat;
		}

		[SerializeField]
		private List<TextureListSupport.Data> m_refs;
	}
}
