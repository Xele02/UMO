using UnityEngine;
using System.Collections.Generic;

namespace TMPro
{
	public class TMP_SpriteAsset : TMP_Asset
	{
		[SerializeField]
		private string m_Version;
		public Texture spriteSheet;
		[SerializeField]
		private List<TMP_SpriteCharacter> m_SpriteCharacterTable;
		[SerializeField]
		private List<TMP_SpriteGlyph> m_SpriteGlyphTable;
		public List<TMP_Sprite> spriteInfoList;
		[SerializeField]
		public List<TMP_SpriteAsset> fallbackSpriteAssets;
	}
}
