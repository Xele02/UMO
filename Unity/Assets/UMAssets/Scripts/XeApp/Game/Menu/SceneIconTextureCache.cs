using System.Text;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class SceneIconTextureCache : IconTextureCache
	{
		private Texture2D SharedAlphaTexture; // 0x20
		private IiconTexture m_loadingTexture; // 0x24
		private Material m_kira256Material; // 0x28
		private Material m_kira2048Material; // 0x2C
		private Material m_kira2048HoloMaterial; // 0x30
		private int m_kiraEnableShaderParam; // 0x34
		private StringBuilder m_strBuilder = new StringBuilder(); // 0x38
		public const string SharedAlphaTextureAssetBundleName = "ct/sc/me/01/al.xab";
		public const string TextureAssetBundleFormat = "ct/sc/me/01/{0:D6}_{1:D2}.xab";
		public const string TextureAsset2BundleFormat = "ct/sc/me/01_2/{0:D6}_{1:D2}.xab";
		public const string TextureAssetBundleVersionFormat = "ct/sc/me/01/{0:D6}_{2:D2}_{1:D2}.xab";
		public const string TextureAsset2BundleVersionFormat = "ct/sc/me/01_2/{0:D6}_{2:D2}_{1:D2}.xab";
		public const string LargeSizeTextureBundlePath = "ct/sc/me/02_2/{0:D6}_{1:D2}.xab";
		public const string KiraEffectAssetBundleName = "ct/sc/ef.xab";
		public const string KiraEffect256MaterialName = "eff_256";
		public const string KiraEffect2048MaterialName = "eff_2048";
		public const string KiraEffect2048HoloMaterialName = "holo_2048_a_mul";
		public static int IsKiraShaderParam; // 0x0

		// // RVA: 0x1370C64 Offset: 0x1370C64 VA: 0x1370C64 Slot: 5
		// public override void Terminated() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C62B0 Offset: 0x6C62B0 VA: 0x6C62B0
		// // RVA: 0x1370C74 Offset: 0x1370C74 VA: 0x1370C74
		// public IEnumerator Initialize() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C6328 Offset: 0x6C6328 VA: 0x6C6328
		// // RVA: 0x1370D20 Offset: 0x1370D20 VA: 0x1370D20
		// public IEnumerator LoadKiraMaterial(Action LoadEndAction) { }

		// // RVA: 0x1370DE8 Offset: 0x1370DE8 VA: 0x1370DE8
		// public void ReleaseKiraMaterial() { }

		// // RVA: 0x136EBA4 Offset: 0x136EBA4 VA: 0x136EBA4
		// public void SetLoadingTexture(RawImageEx image) { }

		// // RVA: 0x1370DF8 Offset: 0x1370DF8 VA: 0x1370DF8 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			UnityEngine.Debug.LogError("TODO CreateIconTexture");
			return null;
		}

		// // RVA: 0x13711B0 Offset: 0x13711B0 VA: 0x13711B0
		// private void SetupForSceneIconTexture(IconTextureLodingInfo info, IiconTexture icon, Texture2D maskTexture) { }

		// // RVA: 0x136EC84 Offset: 0x136EC84 VA: 0x136EC84
		// public void Load(int id, int rank, Action<IiconTexture> callBack) { }

		// // RVA: 0x13637A4 Offset: 0x13637A4 VA: 0x13637A4
		// public static void ChangeKiraMaterial(RawImageEx image, IconTexture texture, bool isEnable) { }

		// // RVA: 0x1371820 Offset: 0x1371820 VA: 0x1371820
		// public void ChangeKiraMaterial_2048(RawImageEx _image) { }

		// // RVA: 0x1371884 Offset: 0x1371884 VA: 0x1371884
		// public void ChangeKiraMaterial_holo(RawImageEx _image) { }

		// // RVA: 0x13718E8 Offset: 0x13718E8 VA: 0x13718E8
		// public void TryInstall(DFKGGBMFFGB playerData) { }

		// // RVA: 0x1371A2C Offset: 0x1371A2C VA: 0x1371A2C
		// public void TryInstall(int sceneId, int evolveId) { }

		// // RVA: 0x13715E0 Offset: 0x13715E0 VA: 0x13715E0
		// public StringBuilder MakeBundlePath(StringBuilder strBuilder, int sceneId, int evolvId, int baseRare, int version, bool isFeed) { }

		// // RVA: 0x1371D6C Offset: 0x1371D6C VA: 0x1371D6C
		// public StringBuilder MakeBundlePath(StringBuilder strBuilder, int sceneId, int evolvId, bool usePlateAnim, int version) { }

		// // RVA: 0x13714EC Offset: 0x13714EC VA: 0x13714EC
		// private bool IsPlateAnimation() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6C63A0 Offset: 0x6C63A0 VA: 0x6C63A0
		// // RVA: 0x1371E74 Offset: 0x1371E74 VA: 0x1371E74
		// private void <Initialize>b__20_0(IiconTexture texture) { }
	}
}
