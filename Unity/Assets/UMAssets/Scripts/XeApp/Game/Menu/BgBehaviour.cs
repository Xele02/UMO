using UnityEngine;
using System;
using UnityEngine.UI;
using XeApp.Game;
using XeSys.uGUI;
using System.Collections.Generic;

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
		
		public enum ColorType
		{
			None = 0,
			Home = 1,
			Setting = 2,
			Gacha = 3,
			Quest = 4,
			Option = 5,
			DownLoad = 6,
			CostumeSelect = 7,
			HomeEvening = 8,
			HomeNight = 9,
		}


		[SerializeField]
		private GameObject m_decorationPrefab; // 0xC
		[SerializeField]
		private GameObject m_decorationRoot; // 0x10
		[SerializeField]
		private RawImage m_bgImage; // 0x14
		[SerializeField]
		private TranslationTween m_transLationTween; // 0x18
		[SerializeField]
		private Image m_tileImage; // 0x1C
		[SerializeField]
		private RawImage m_tileMask; // 0x20
		[SerializeField]
		private Image[] m_growImages; // 0x24
		[SerializeField]
		private Sprite m_homeTileSprite; // 0x28
		[SerializeField]
		private Sprite m_menuTileSprite; // 0x2C
		[SerializeField]
		private Sprite m_musicTileSprite; // 0x30
		[SerializeField]
		private Sprite m_offerTileSprite; // 0x34
		[SerializeField]
		private Texture2D m_texture; // 0x38
		[SerializeField]
		private Color32[] m_colorTable; // 0x3C
		[SerializeField]
		private Vector3[] m_decorationPosition; // 0x40
		[SerializeField]
		private Vector3[] m_decorationScale; // 0x44
		[SerializeField]
		private Material[] m_decorationMaterials; // 0x48
		[SerializeField]
		private BgBehaviour.AttributeSetting m_attrSetting; // 0x4C
		[SerializeField]
		private UGUIFader m_fader; // 0x50
		[SerializeField]
		private Image m_overlay; // 0x54
		[SerializeField]
		private ScrollRect m_storyBgScroll; // 0x58
		[SerializeField]
		private GameObject m_storyBgPanel; // 0x5C
		[SerializeField]
		private Material m_bgMipmapBiasMaterialSource; // 0x60
		[SerializeField]
		private Material m_bgTransColoredBlurMaterialSource; // 0x64
		public static readonly float HomeSceneOverlayAlpha = 0.3f; // 0x0
		private List<GameObject> m_decrationInstance = new List<GameObject>(); // 0x68
		private List<RotationTween> m_rotationTween = new List<RotationTween>(); // 0x6C
		private List<Image> m_colorChangeImages = new List<Image>(); // 0x70
		private BgScroll m_bgScroll; // 0x74
		private Material m_bgMipmapBiasMaterialInstance; // 0x78
		private Material m_bgTransColoredBlurMaterialInstance; // 0x7C
		private static readonly Rect TextureUv4_3 = new Rect(0.0234375f, 0.142578f, 0.953125f, 0.714844f); // 0x4
		private static readonly Vector2 PlateSize = new Vector2(244, 244); // 0x14
		private static readonly Rect PlateUv = new Rect(0, 0, 1, 1); // 0x1C
		private static readonly Vector2 RectSize4_3 = new Vector2(244, 183); // 0x2C
		private static readonly Rect WhiteTextureUv = new Rect(0.396484f, 0.45459f, 0.00976562f, 0.00488281f); // 0x34
		private const int ColorIndexTblLength = 10;
		private static readonly int[,] m_colorIndexTbl = new int[10, 10] { 
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 5, 6, 7, 8, 5, 6, 7, 8, 9, 9 },
			{ 10, 11, 12, 13, 10, 11, 12, 13, 14, 14},
			{ 15, 16, 17, 18, 15, 16, 17, 18, 19, 19},
			{ 20, 21, 22, 23, 20, 21, 22, 23, 24, 24},
			{ 25, 26, 27, 28, 25, 26, 27, 28, 29, 29},
			{ 35, 36, 37, 38, 35, 36, 37, 38, 39, 39},
			{ 30, 31, 32, 33, 30, 31, 32, 28, 34, 34},
			{ 40, 41, 42, 43, -1, -1, -1, -1, -1, -1},
			{ 44, 45, 46, 47, -1, -1, -1, -1, -1, -1} }; // 0x44

		// public RawImage BgImage { get; } 0x14365E0
		// public UGUIFader Fader { get; } 0x14365E8
		// public ScrollRect storyBgScrollRect { get; private set; } 0x143BBD0 0x143BBD8

		// // RVA: 0x14365F0 Offset: 0x14365F0 VA: 0x14365F0
		private void Awake()
		{
			UnityEngine.Debug.LogWarning("TODO BgBehaviour.Awake");
		}

		// // RVA: 0x1436BB4 Offset: 0x1436BB4 VA: 0x1436BB4
		private void Start()
		{
			UnityEngine.Debug.LogWarning("TODO BgBehaviour.Awake");
		}

		// // RVA: 0x1436C34 Offset: 0x1436C34 VA: 0x1436C34
		private void Update()
		{
			UnityEngine.Debug.LogWarning("TODO BgBehaviour.Update");
		}

		// // RVA: 0x1436D4C Offset: 0x1436D4C VA: 0x1436D4C
		// public void ClearBg() { }

		// // RVA: 0x1436D7C Offset: 0x1436D7C VA: 0x1436D7C
		// public void SetHomeBgTexture(BgControl.BgTexture texture, bool isScene, bool isBlur = False) { }

		// // RVA: 0x1436EA4 Offset: 0x1436EA4 VA: 0x1436EA4
		// public void SetBgTexture(Texture2D texture, bool isScene, bool isBlur = False) { }

		// // RVA: 0x143718C Offset: 0x143718C VA: 0x143718C
		public void ChangeColor(BgBehaviour.ColorType type)
		{
			UnityEngine.Debug.LogWarning("TODO BgBehaviour ChangeColor");
		}

		// // RVA: 0x14374E4 Offset: 0x14374E4 VA: 0x14374E4
		// public void SetHome(bool isBgDark) { }

		// // RVA: 0x1437E00 Offset: 0x1437E00 VA: 0x1437E00
		// public void SetHomeScene(bool isBgDark) { }

		// // RVA: 0x1438148 Offset: 0x1438148 VA: 0x1438148
		// public void SetHomeSceneView() { }

		// // RVA: 0x143842C Offset: 0x143842C VA: 0x143842C
		public void SetMenu()
		{
			UnityEngine.Debug.LogWarning("TODO BgBehaviour SetMenu");
		}

		// // RVA: 0x1438B40 Offset: 0x1438B40 VA: 0x1438B40
		// public void GachaPickup() { }

		// // RVA: 0x1438E14 Offset: 0x1438E14 VA: 0x1438E14
		// public void SetMusic(bool simulation = False) { }

		// // RVA: 0x1439294 Offset: 0x1439294 VA: 0x1439294
		// public void SetVerticalMusic() { }

		// // RVA: 0x1439708 Offset: 0x1439708 VA: 0x1439708
		// public void SetDownLoad() { }

		// // RVA: 0x143970C Offset: 0x143970C VA: 0x143970C
		// public void SetValkyrieSelect() { }

		// // RVA: 0x1439930 Offset: 0x1439930 VA: 0x1439930
		// public void SetCostumeSelect() { }

		// // RVA: 0x1439EF8 Offset: 0x1439EF8 VA: 0x1439EF8
		// public void SetResult() { }

		// // RVA: 0x143A0F8 Offset: 0x143A0F8 VA: 0x143A0F8
		// public void SetLoginBonus() { }

		// // RVA: 0x143A31C Offset: 0x143A31C VA: 0x143A31C
		// public void SetUnlockValkyrie() { }

		// // RVA: 0x143A4FC Offset: 0x143A4FC VA: 0x143A4FC
		// public void SetGachaBox() { }

		// // RVA: 0x143A720 Offset: 0x143A720 VA: 0x143A720
		// public void SetNewYearEvent() { }

		// // RVA: 0x143AAC4 Offset: 0x143AAC4 VA: 0x143AAC4
		// public void SetLimitedHomeScene() { }

		// // RVA: 0x143ADFC Offset: 0x143ADFC VA: 0x143ADFC
		// public void SetCampaign() { }

		// // RVA: 0x143B020 Offset: 0x143B020 VA: 0x143B020
		// public void SetOffer() { }

		// // RVA: 0x143B244 Offset: 0x143B244 VA: 0x143B244
		// public void SetDecoration() { }

		// // RVA: 0x143B468 Offset: 0x143B468 VA: 0x143B468
		// public void SetLobbyMain() { }

		// // RVA: 0x143B7CC Offset: 0x143B7CC VA: 0x143B7CC
		// public void SetRaid() { }

		// // RVA: 0x1437A4C Offset: 0x1437A4C VA: 0x1437A4C
		// public void ResetBgImageRectSize(bool isPlate) { }

		// // RVA: 0x1436C04 Offset: 0x1436C04 VA: 0x1436C04
		// public void ChangeAttribute(GameAttribute.Type attr) { }

		// // RVA: 0x14379A4 Offset: 0x14379A4 VA: 0x14379A4
		// public void ShowOverlay(float alpha) { }

		// // RVA: 0x1436BD4 Offset: 0x1436BD4 VA: 0x1436BD4
		// public void HideOverlay() { }

		// // RVA: 0x1438A94 Offset: 0x1438A94 VA: 0x1438A94
		// public void ChangeTilingType(BgBehaviour.TilingType type, bool mask = False) { }

		// // RVA: 0x143BABC Offset: 0x143BABC VA: 0x143BABC
		// public void ChangeTilingFade(float time, float alpha) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C9E8C Offset: 0x6C9E8C VA: 0x6C9E8C
		// // RVA: 0x143BAE0 Offset: 0x143BAE0 VA: 0x143BAE0
		// public IEnumerator Co_ChangeTilingFade(float time, float alpha) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C9F04 Offset: 0x6C9F04 VA: 0x6C9F04
		// // RVA: 0x143BBDC Offset: 0x143BBDC VA: 0x143BBDC
		// public IEnumerator SetupStoryBg(int map, Action finish) { }

		// // RVA: 0x143BCBC Offset: 0x143BCBC VA: 0x143BCBC
		// public void StoryBgShow() { }

		// // RVA: 0x143BD0C Offset: 0x143BD0C VA: 0x143BD0C
		// public void StoryBgHide() { }
	}
}
