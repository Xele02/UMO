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


		[SerializeField] // RVA: 0x66A340 Offset: 0x66A340 VA: 0x66A340
		private GameObject m_decorationPrefab; // 0xC
		[SerializeField] // RVA: 0x66A350 Offset: 0x66A350 VA: 0x66A350
		private GameObject m_decorationRoot; // 0x10
		[SerializeField] // RVA: 0x66A360 Offset: 0x66A360 VA: 0x66A360
		private RawImage m_bgImage; // 0x14
		[SerializeField] // RVA: 0x66A370 Offset: 0x66A370 VA: 0x66A370
		private TranslationTween m_transLationTween; // 0x18
		[SerializeField] // RVA: 0x66A380 Offset: 0x66A380 VA: 0x66A380
		private Image m_tileImage; // 0x1C
		[SerializeField] // RVA: 0x66A390 Offset: 0x66A390 VA: 0x66A390
		private RawImage m_tileMask; // 0x20
		[SerializeField] // RVA: 0x66A3A0 Offset: 0x66A3A0 VA: 0x66A3A0
		private Image[] m_growImages; // 0x24
		[SerializeField] // RVA: 0x66A3B0 Offset: 0x66A3B0 VA: 0x66A3B0
		private Sprite m_homeTileSprite; // 0x28
		[SerializeField] // RVA: 0x66A3C0 Offset: 0x66A3C0 VA: 0x66A3C0
		private Sprite m_menuTileSprite; // 0x2C
		[SerializeField] // RVA: 0x66A3D0 Offset: 0x66A3D0 VA: 0x66A3D0
		private Sprite m_musicTileSprite; // 0x30
		[SerializeField] // RVA: 0x66A3E0 Offset: 0x66A3E0 VA: 0x66A3E0
		private Sprite m_offerTileSprite; // 0x34
		[SerializeField] // RVA: 0x66A3F0 Offset: 0x66A3F0 VA: 0x66A3F0
		private Texture2D m_texture; // 0x38
		[SerializeField] // RVA: 0x66A400 Offset: 0x66A400 VA: 0x66A400
		private Color32[] m_colorTable; // 0x3C
		[SerializeField] // RVA: 0x66A410 Offset: 0x66A410 VA: 0x66A410
		private Vector3[] m_decorationPosition; // 0x40
		[SerializeField] // RVA: 0x66A420 Offset: 0x66A420 VA: 0x66A420
		private Vector3[] m_decorationScale; // 0x44
		[SerializeField] // RVA: 0x66A430 Offset: 0x66A430 VA: 0x66A430
		private Material[] m_decorationMaterials; // 0x48
		[SerializeField] // RVA: 0x66A440 Offset: 0x66A440 VA: 0x66A440
		private BgBehaviour.AttributeSetting m_attrSetting; // 0x4C
		[SerializeField] // RVA: 0x66A450 Offset: 0x66A450 VA: 0x66A450
		private UGUIFader m_fader; // 0x50
		[SerializeField] // RVA: 0x66A460 Offset: 0x66A460 VA: 0x66A460
		private Image m_overlay; // 0x54
		[SerializeField] // RVA: 0x66A470 Offset: 0x66A470 VA: 0x66A470
		private ScrollRect m_storyBgScroll; // 0x58
		[SerializeField] // RVA: 0x66A480 Offset: 0x66A480 VA: 0x66A480
		private GameObject m_storyBgPanel; // 0x5C
		[SerializeField] // RVA: 0x66A490 Offset: 0x66A490 VA: 0x66A490
		private Material m_bgMipmapBiasMaterialSource; // 0x60
		[SerializeField] // RVA: 0x66A4A0 Offset: 0x66A4A0 VA: 0x66A4A0
		private Material m_bgTransColoredBlurMaterialSource; // 0x64
		public static readonly float HomeSceneOverlayAlpha; // 0x0
		private List<GameObject> m_decrationInstance; // 0x68
		private List<RotationTween> m_rotationTween; // 0x6C
		private List<Image> m_colorChangeImages; // 0x70
		private BgScroll m_bgScroll; // 0x74
		private Material m_bgMipmapBiasMaterialInstance; // 0x78
		private Material m_bgTransColoredBlurMaterialInstance; // 0x7C
		private static readonly Rect TextureUv4_3; // 0x4
		private static readonly Vector2 PlateSize; // 0x14
		private static readonly Rect PlateUv; // 0x1C
		private static readonly Vector2 RectSize4_3; // 0x2C
		private static readonly Rect WhiteTextureUv; // 0x34
		private const int ColorIndexTblLength = 10;
		private static readonly int[,] m_colorIndexTbl; // 0x44

		public RawImage BgImage { get; }
		public UGUIFader Fader { get; }
		public ScrollRect storyBgScrollRect { get; set; }

		// // RVA: 0x14365E0 Offset: 0x14365E0 VA: 0x14365E0
		// public RawImage get_BgImage() { }

		// // RVA: 0x14365E8 Offset: 0x14365E8 VA: 0x14365E8
		// public UGUIFader get_Fader() { }

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
			UnityEngine.Debug.LogError("TODO");
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
			UnityEngine.Debug.LogError("TODO");
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

		// // RVA: 0x143BBD0 Offset: 0x143BBD0 VA: 0x143BBD0
		// public ScrollRect get_storyBgScrollRect() { }

		// // RVA: 0x143BBD8 Offset: 0x143BBD8 VA: 0x143BBD8
		// private void set_storyBgScrollRect(ScrollRect value) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C9F04 Offset: 0x6C9F04 VA: 0x6C9F04
		// // RVA: 0x143BBDC Offset: 0x143BBDC VA: 0x143BBDC
		// public IEnumerator SetupStoryBg(int map, Action finish) { }

		// // RVA: 0x143BCBC Offset: 0x143BCBC VA: 0x143BCBC
		// public void StoryBgShow() { }

		// // RVA: 0x143BD0C Offset: 0x143BD0C VA: 0x143BD0C
		// public void StoryBgHide() { }

		// // RVA: 0x143BD5C Offset: 0x143BD5C VA: 0x143BD5C
		// public void .ctor() { }

		// // RVA: 0x143BE50 Offset: 0x143BE50 VA: 0x143BE50
		// private static void .cctor() { }
	}
}
