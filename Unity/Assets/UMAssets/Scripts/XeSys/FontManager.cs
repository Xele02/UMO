using UnityEngine;

namespace XeSys
{
	public class FontManager : MonoBehaviour
	{
		[SerializeField]
		private FontInfo[] fontTable; // 0xC

		// RVA: 0x203D27C Offset: 0x203D27C VA: 0x203D27C
		public FontInfo GetFontInfo(int index)
		{
			return fontTable[index];
		}
	}
}
