using System;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	public class TMP_Sprite : TMP_TextElement_Legacy
	{
		public string name;
		public int hashCode;
		public int unicode;
		public Vector2 pivot;
		public Sprite sprite;
	}
}
