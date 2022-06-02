using System;
using UnityEngine;
using System.Collections.Generic;

namespace TMPro
{
	[Serializable]
	public class TMP_Settings : ScriptableObject
	{
		[SerializeField]
		private bool m_enableWordWrapping;
		[SerializeField]
		private bool m_enableKerning;
		[SerializeField]
		private bool m_enableExtraPadding;
		[SerializeField]
		private bool m_enableTintAllSprites;
		[SerializeField]
		private bool m_enableParseEscapeCharacters;
		[SerializeField]
		private bool m_EnableRaycastTarget;
		[SerializeField]
		private bool m_GetFontFeaturesAtRuntime;
		[SerializeField]
		private int m_missingGlyphCharacter;
		[SerializeField]
		private bool m_warningsDisabled;
		[SerializeField]
		private TMP_FontAsset m_defaultFontAsset;
		[SerializeField]
		private string m_defaultFontAssetPath;
		[SerializeField]
		private float m_defaultFontSize;
		[SerializeField]
		private float m_defaultAutoSizeMinRatio;
		[SerializeField]
		private float m_defaultAutoSizeMaxRatio;
		[SerializeField]
		private Vector2 m_defaultTextMeshProTextContainerSize;
		[SerializeField]
		private Vector2 m_defaultTextMeshProUITextContainerSize;
		[SerializeField]
		private bool m_autoSizeTextContainer;
		[SerializeField]
		private List<TMP_FontAsset> m_fallbackFontAssets;
		[SerializeField]
		private bool m_matchMaterialPreset;
		[SerializeField]
		private TMP_SpriteAsset m_defaultSpriteAsset;
		[SerializeField]
		private string m_defaultSpriteAssetPath;
		[SerializeField]
		private string m_defaultColorGradientPresetsPath;
		[SerializeField]
		private bool m_enableEmojiSupport;
		[SerializeField]
		private TMP_StyleSheet m_defaultStyleSheet;
		[SerializeField]
		private TextAsset m_leadingCharacters;
		[SerializeField]
		private TextAsset m_followingCharacters;
	}
}
