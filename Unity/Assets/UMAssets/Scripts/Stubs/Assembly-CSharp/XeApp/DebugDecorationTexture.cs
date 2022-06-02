using System;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp
{
	[Serializable]
	public class DebugDecorationTexture
	{
		[Serializable]
		public class DecorationResource
		{
			public Sprite compressed;
			public Sprite compressedF;
			public Material material;
			public Material materialF;
			public DecorationConstants.Attribute.Type attributeType;
		}

		[SerializeField]
		private List<DebugDecorationTexture.DecorationResource> m_decoration;
		[SerializeField]
		private DecorationResource m_bg;
	}
}
