using UnityEngine;
using System;

namespace XeApp.Game.Common
{
	public class IconTextSetting : ScriptableObject
	{
		[Serializable]
		public class UvRect
		{
			public Rect m_uv; // 0x8
			public float m_yTopMargin; // 0x18
			public bool m_isIgnoreScale; // 0x1C
		}
		
		public Texture m_iconTexture; // 0xC
		public Material m_material; // 0x10
		public float m_iconTopMargin; // 0x14
		public UvRect[] m_rects; // 0x18
		private static UvRect m_simpleRect = new UvRect(); // 0x0

		public static UvRect SimpleRect { get { return m_simpleRect; } } //0x10FE070

		// RVA: 0x10FE04C Offset: 0x10FE04C VA: 0x10FE04C
		//public bool IsNullOrEmpty() { }
	}
}
