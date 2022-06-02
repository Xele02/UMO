using UnityEngine.UI;
using UnityEngine;

namespace TMPro
{
	public class TMP_Text : MaskableGraphic
	{
		[SerializeField]
		protected string m_text;
		[SerializeField]
		protected bool m_isRightToLeft;
		[SerializeField]
		protected TMP_FontAsset m_fontAsset;
		[SerializeField]
		protected Material m_sharedMaterial;
		[SerializeField]
		protected Material[] m_fontSharedMaterials;
		[SerializeField]
		protected Material m_fontMaterial;
		[SerializeField]
		protected Material[] m_fontMaterials;
		[SerializeField]
		protected Color32 m_fontColor32;
		[SerializeField]
		protected Color m_fontColor;
		[SerializeField]
		protected bool m_enableVertexGradient;
		[SerializeField]
		protected ColorMode m_colorMode;
		[SerializeField]
		protected VertexGradient m_fontColorGradient;
		[SerializeField]
		protected TMP_ColorGradient m_fontColorGradientPreset;
		[SerializeField]
		protected TMP_SpriteAsset m_spriteAsset;
		[SerializeField]
		protected bool m_tintAllSprites;
		[SerializeField]
		protected bool m_overrideHtmlColors;
		[SerializeField]
		protected Color32 m_faceColor;
		[SerializeField]
		protected Color32 m_outlineColor;
		[SerializeField]
		protected float m_fontSize;
		[SerializeField]
		protected float m_fontSizeBase;
		[SerializeField]
		protected FontWeight m_fontWeight;
		[SerializeField]
		protected bool m_enableAutoSizing;
		[SerializeField]
		protected float m_fontSizeMin;
		[SerializeField]
		protected float m_fontSizeMax;
		[SerializeField]
		protected FontStyles m_fontStyle;
		[SerializeField]
		protected TextAlignmentOptions m_textAlignment;
		[SerializeField]
		protected float m_characterSpacing;
		[SerializeField]
		protected float m_wordSpacing;
		[SerializeField]
		protected float m_lineSpacing;
		[SerializeField]
		protected float m_lineSpacingMax;
		[SerializeField]
		protected float m_paragraphSpacing;
		[SerializeField]
		protected float m_charWidthMaxAdj;
		[SerializeField]
		protected bool m_enableWordWrapping;
		[SerializeField]
		protected float m_wordWrappingRatios;
		[SerializeField]
		protected TextOverflowModes m_overflowMode;
		[SerializeField]
		protected int m_firstOverflowCharacterIndex;
		[SerializeField]
		protected TMP_Text m_linkedTextComponent;
		[SerializeField]
		protected bool m_isLinkedTextComponent;
		[SerializeField]
		protected bool m_isTextTruncated;
		[SerializeField]
		protected bool m_enableKerning;
		[SerializeField]
		protected bool m_enableExtraPadding;
		[SerializeField]
		protected bool checkPaddingRequired;
		[SerializeField]
		protected bool m_isRichText;
		[SerializeField]
		protected bool m_parseCtrlCharacters;
		[SerializeField]
		protected bool m_isOrthographic;
		[SerializeField]
		protected bool m_isCullingEnabled;
		[SerializeField]
		protected bool m_ignoreRectMaskCulling;
		[SerializeField]
		protected bool m_ignoreCulling;
		[SerializeField]
		protected TextureMappingOptions m_horizontalMapping;
		[SerializeField]
		protected TextureMappingOptions m_verticalMapping;
		[SerializeField]
		protected float m_uvLineOffset;
		[SerializeField]
		protected VertexSortingOrder m_geometrySortingOrder;
		[SerializeField]
		protected bool m_VertexBufferAutoSizeReduction;
		[SerializeField]
		protected int m_firstVisibleCharacter;
		[SerializeField]
		protected bool m_useMaxVisibleDescender;
		[SerializeField]
		protected int m_pageToDisplay;
		[SerializeField]
		protected Vector4 m_margin;
		[SerializeField]
		protected TMP_TextInfo m_textInfo;
		[SerializeField]
		protected bool m_isUsingLegacyAnimationComponent;
		[SerializeField]
		protected bool m_isVolumetricText;
		[SerializeField]
		protected TMP_SpriteAnimator m_spriteAnimator;
	}
}
