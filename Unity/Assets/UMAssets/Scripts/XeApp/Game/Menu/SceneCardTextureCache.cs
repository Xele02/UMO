using System.Text;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class SceneCardTextureCache : IconTextureCache
	{
		public const string SharedAlphaTextureBundlePath = "ct/sc/me/02/al.xab";
		public const string TextureAssetBundleFormat = "ct/sc/me/02/{0:D6}_{1:D2}.xab";
		public const string Texture2AssetBundleFormat = "ct/sc/me/02_2/{0:D6}_{1:D2}.xab";
		public const string SilhouetteTextureAssetBundleFormat = "ct/sc/me/03/{0:D6}_{1:D2}.xab";
		private bool m_isInitialized; // 0x20
		private Texture2D SharedAlphaTexture; // 0x24
		private bool m_useMipmapBias; // 0x28
		private float m_mipmapBias; // 0x2C
		private StringBuilder m_strBuilder = new StringBuilder(); // 0x30

		// public bool IsInitialized { get; } 0x159EFA4

		// RVA: 0x159EFAC Offset: 0x159EFAC VA: 0x159EFAC
		public SceneCardTextureCache(int capacity = 1) : base(capacity)
		{
			return;
		}

		// RVA: 0x159F030 Offset: 0x159F030 VA: 0x159F030 Slot: 5
		public override void Terminated()
		{
			Clear();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6DCC6C Offset: 0x6DCC6C VA: 0x6DCC6C
		// // RVA: 0x159F038 Offset: 0x159F038 VA: 0x159F038
		// public IEnumerator Initialize(bool needAlphaTex = False) { }

		// // RVA: 0x159F100 Offset: 0x159F100 VA: 0x159F100
		// public void SetMipmapBias(float bias) { }

		// // RVA: 0x159F110 Offset: 0x159F110 VA: 0x159F110
		// public void ClearMipmapBias() { }

		// // RVA: 0x159F120 Offset: 0x159F120 VA: 0x159F120 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			TodoLogger.Log(0, "CreateIconTexture");
			return null;
		}

		// // RVA: 0x159F488 Offset: 0x159F488 VA: 0x159F488
		// public void Load(int id, int rank, Action<IiconTexture> callback) { }

		// // RVA: 0x159F87C Offset: 0x159F87C VA: 0x159F87C
		// public void LoadSilhouette(int id, int rank, Action<IiconTexture> callback) { }

		// // RVA: 0x159F824 Offset: 0x159F824 VA: 0x159F824
		// public StringBuilder MakeBundlePath(StringBuilder strBuilder, int sceneId, int evolvId, int baseRare, bool isFeed) { }

		// // RVA: 0x159F940 Offset: 0x159F940 VA: 0x159F940
		// public static StringBuilder MakeBundlePath(StringBuilder strBuilder, int sceneId, int evolvId, bool usePlateAnim) { }

		// // RVA: 0x159F730 Offset: 0x159F730 VA: 0x159F730
		// private bool IsPlateAnimation() { }
	}
}
