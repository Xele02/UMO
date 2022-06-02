using UnityEngine;
using System;

namespace XeApp.Game.Common
{
	public class IconTextSetting : ScriptableObject
	{
		[Serializable]
		public class UvRect
		{
			public Rect m_uv;
			public float m_yTopMargin;
			public bool m_isIgnoreScale;
		}

		public Texture m_iconTexture;
		public Material m_material;
		public float m_iconTopMargin;
		public UvRect[] m_rects;
	}
}
