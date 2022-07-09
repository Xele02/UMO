using System.Text;

namespace XeApp.Game.Menu
{
	public class DecorationItemTextureCache : IconTextureCache
	{
		public const string BundleFormatForChara01 = "ct/dc/ch/01/{0:D2}_{1:D3}.xab";
		public const string BundleFormatForChara02 = "ct/dc/ch/02/{0:D2}_{1:D3}.xab";
		public const string BundleFormatForBg = "ct/dc/bg/ic/{0:D4}_{1:D2}.xab";
		public const string BundleFormatForSerif = "dc/sf/{0:D4}.xab";
		private StringBuilder m_bundleName = new StringBuilder(32); // 0x20

		// RVA: 0x11E0C20 Offset: 0x11E0C20 VA: 0x11E0C20
		public DecorationItemTextureCache() : base(16)
		{
			return;
		}

		// RVA: 0x11E0CA4 Offset: 0x11E0CA4 VA: 0x11E0CA4 Slot: 5
		// public override void Terminated() { }

		// RVA: 0x11E0CAC Offset: 0x11E0CAC VA: 0x11E0CAC Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			UnityEngine.Debug.LogError("TODO CreateIconTexture");
			return null;
		}

		// RVA: 0x11E0D34 Offset: 0x11E0D34 VA: 0x11E0D34
		// public void LoadForSelectChara(int id, Action<IiconTexture> callBack) { }

		// // RVA: 0x11E0E2C Offset: 0x11E0E2C VA: 0x11E0E2C
		// public void LoadForDecoCustom(int id, int subId, Action<IiconTexture> callBack) { }

		// // RVA: 0x11E0F24 Offset: 0x11E0F24 VA: 0x11E0F24
		// public void LoadForSelectedDecoCustom(int id, int subId, Action<IiconTexture> callBack) { }

		// // RVA: 0x11E101C Offset: 0x11E101C VA: 0x11E101C
		// public void LoadForSelectBg(int id, int subId, Action<IiconTexture> callBack) { }

		// // RVA: 0x11E1114 Offset: 0x11E1114 VA: 0x11E1114
		// public void LoadForSelectSerif(int id, Action<IiconTexture> callBack) { }
	}
}
