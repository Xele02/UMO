using System;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	public class TMP_SpriteCharacter : TMP_TextElement
	{
		[SerializeField]
		private string m_Name;
		[SerializeField]
		private int m_HashCode;
	}
}
