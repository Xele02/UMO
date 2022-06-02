using UnityEngine;
using System;
using UnityEngine.UI;
using XeApp.Game;
using XeSys.uGUI;

namespace XeApp.Game.Menu
{
	public class BgBehaviour : MonoBehaviour
	{
		[Serializable]
		private class AttributeSetting
		{
			[Serializable]
			private class Preset
			{
				[SerializeField]
				private Sprite m_sourceImage;
				[SerializeField]
				private Color m_color;
			}

			[SerializeField]
			private Image m_targetImage;
			[SerializeField]
			private Preset m_presetHoshi;
			[SerializeField]
			private Preset m_presetAi;
			[SerializeField]
			private Preset m_presetInochi;
			[SerializeField]
			private Preset m_presetZen;
		}

		[SerializeField]
		private GameObject m_decorationPrefab;
		[SerializeField]
		private GameObject m_decorationRoot;
		[SerializeField]
		private RawImage m_bgImage;
		[SerializeField]
		private TranslationTween m_transLationTween;
		[SerializeField]
		private Image m_tileImage;
		[SerializeField]
		private RawImage m_tileMask;
		[SerializeField]
		private Image[] m_growImages;
		[SerializeField]
		private Sprite m_homeTileSprite;
		[SerializeField]
		private Sprite m_menuTileSprite;
		[SerializeField]
		private Sprite m_musicTileSprite;
		[SerializeField]
		private Sprite m_offerTileSprite;
		[SerializeField]
		private Texture2D m_texture;
		[SerializeField]
		private Color32[] m_colorTable;
		[SerializeField]
		private Vector3[] m_decorationPosition;
		[SerializeField]
		private Vector3[] m_decorationScale;
		[SerializeField]
		private Material[] m_decorationMaterials;
		[SerializeField]
		private AttributeSetting m_attrSetting;
		[SerializeField]
		private UGUIFader m_fader;
		[SerializeField]
		private Image m_overlay;
		[SerializeField]
		private ScrollRect m_storyBgScroll;
		[SerializeField]
		private GameObject m_storyBgPanel;
		[SerializeField]
		private Material m_bgMipmapBiasMaterialSource;
		[SerializeField]
		private Material m_bgTransColoredBlurMaterialSource;
	}
}
