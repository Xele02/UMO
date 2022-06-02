using System;
using UnityEngine;
using UnityEngine.TextCore;
using System.Collections.Generic;
using UnityEngine.TextCore.LowLevel;

namespace TMPro
{
	[Serializable]
	public class TMP_FontAsset : TMP_Asset
	{
		[SerializeField]
		private string m_Version;
		[SerializeField]
		internal string m_SourceFontFileGUID;
		[SerializeField]
		private Font m_SourceFontFile;
		[SerializeField]
		private AtlasPopulationMode m_AtlasPopulationMode;
		[SerializeField]
		private FaceInfo m_FaceInfo;
		[SerializeField]
		private List<Glyph> m_GlyphTable;
		[SerializeField]
		private List<TMP_Character> m_CharacterTable;
		[SerializeField]
		private Texture2D[] m_AtlasTextures;
		[SerializeField]
		internal int m_AtlasTextureIndex;
		[SerializeField]
		private List<GlyphRect> m_UsedGlyphRects;
		[SerializeField]
		private List<GlyphRect> m_FreeGlyphRects;
		[SerializeField]
		private FaceInfo_Legacy m_fontInfo;
		[SerializeField]
		public Texture2D atlas;
		[SerializeField]
		private int m_AtlasWidth;
		[SerializeField]
		private int m_AtlasHeight;
		[SerializeField]
		private int m_AtlasPadding;
		[SerializeField]
		private GlyphRenderMode m_AtlasRenderMode;
		[SerializeField]
		internal List<TMP_Glyph> m_glyphInfoList;
		[SerializeField]
		internal KerningTable m_KerningTable;
		[SerializeField]
		private TMP_FontFeatureTable m_FontFeatureTable;
		[SerializeField]
		private List<TMP_FontAsset> fallbackFontAssets;
		[SerializeField]
		public List<TMP_FontAsset> m_FallbackFontAssetTable;
		[SerializeField]
		internal FontAssetCreationSettings m_CreationSettings;
		[SerializeField]
		private TMP_FontWeightPair[] m_FontWeightTable;
		[SerializeField]
		private TMP_FontWeightPair[] fontWeights;
		public float normalStyle;
		public float normalSpacingOffset;
		public float boldStyle;
		public float boldSpacing;
		public byte italicStyle;
		public byte tabSize;
	}
}
