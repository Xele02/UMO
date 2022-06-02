using System;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	public class TMP_TextElement
	{
		[SerializeField]
		protected TextElementType m_ElementType;
		[SerializeField]
		private uint m_Unicode;
		[SerializeField]
		private uint m_GlyphIndex;
		[SerializeField]
		private float m_Scale;
	}
}
