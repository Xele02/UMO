using System.Text;

namespace XeApp.Game.Menu
{
	public class DivaIconTextureCache : IconTextureCache
	{
		//private DivaIconTexture m_loadingDivaIcon; // 0x20
		//private DivaIconTexture m_loadingStatusDivaIcon; // 0x24
		private const string DivaSSizeIconPath = "ct/dv/me/01/{0:D2}_{1:D2}.xab";
		private const string DivaMSizeIconPath = "ct/dv/me/02/{0:D2}_{1:D2}.xab";
		private const string DivaLSizeIconPath = "ct/dv/me/03/{0:D2}_{1:D2}.xab";
		private const string DivaPSIconPath = "ct/dv/ps/{0:D2}_{1:D2}.xab";
		public const string DivaStoryIconPath = "ct/dv/me/05/{0:D2}_{1:D2}.xab";
		public const string DivaSmallBustupPath = "ct/dv/me/06/{0:D2}_{1:D2}.xab";
		public const string DivaStandingCostumeIconPath = "ct/dv/me/07/{0:D2}_{1:D2}.xab";
		public const string DivaEventGoDivaIconPath = "ct/dv/me/08/{0:D2}_01.xab";
		public const string DivaEventGoDivaIconTypedPath = "ct/dv/me/08/{0:D2}_{1:D2}.xab";
		private const string DivaSSizeIconInColorPath = "ct/dv/me/01/{0:D2}_{1:D2}_{2:D2}.xab";
		private const string DivaMSizeIconInColorPath = "ct/dv/me/02/{0:D2}_{1:D2}_{2:D2}.xab";
		private const string DivaLSizeIconInColorPath = "ct/dv/me/03/{0:D2}_{1:D2}_{2:D2}.xab";
		private const string DivaPSIconInColorPath = "ct/dv/ps/{0:D2}_{1:D2}_{2:D2}.xab";
		private StringBuilder m_strBuilder = new StringBuilder(); // 0x28
		private static string[][] IconFormatTable; // 0x0

		// // RVA: 0x17E3444 Offset: 0x17E3444 VA: 0x17E3444
		// public static string GetIconPath(DivaIconTextureCache.IconType type, int divaId, int modelId, int colorId) { }

		// // RVA: 0x17E3714 Offset: 0x17E3714 VA: 0x17E3714 Slot: 5
		// public override void Terminated() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C5FB8 Offset: 0x6C5FB8 VA: 0x6C5FB8
		// // RVA: 0x17E375C Offset: 0x17E375C VA: 0x17E375C
		// public IEnumerator EntryLoadingTexture() { }

		// // RVA: 0x17E3808 Offset: 0x17E3808 VA: 0x17E3808
		// public void SetLoadingIcon(RawImageEx image) { }

		// // RVA: 0x17E3844 Offset: 0x17E3844 VA: 0x17E3844
		// public void SetStatusLoadingIcon(RawImageEx image) { }

		// // RVA: 0x17E3880 Offset: 0x17E3880 VA: 0x17E3880 Slot: 7
		// protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info) { }

		// // RVA: 0x17E3908 Offset: 0x17E3908 VA: 0x17E3908
		// public void Load(int id, int modelId, int colorId, Action<IiconTexture> callBack) { }

		// // RVA: 0x17D255C Offset: 0x17D255C VA: 0x17D255C
		// public void LoadStateIcon(int id, int modelId, int colorId, Action<IiconTexture> callBack) { }

		// // RVA: 0x17E39C0 Offset: 0x17E39C0 VA: 0x17E39C0
		// public void LoadLobbyIcon(int cosId, int colorId, Action<IiconTexture> callBack) { }

		// // RVA: 0x17E061C Offset: 0x17E061C VA: 0x17E061C
		// public void LoadPortraitIcon(int id, int modelId, int colorId, Action<IiconTexture> callBack) { }

		// // RVA: 0x17E3B88 Offset: 0x17E3B88 VA: 0x17E3B88
		// public void LoadStoryIcon(int id, int modelId, Action<IiconTexture> callBack) { }

		// // RVA: 0x17E3C4C Offset: 0x17E3C4C VA: 0x17E3C4C
		// public void LoadStandingCostumeIcon(int id, int modelId, Action<IiconTexture> callBack) { }

		// // RVA: 0x17E3D10 Offset: 0x17E3D10 VA: 0x17E3D10
		// public void LoadTutorialIcon(int charId, Action<IiconTexture> callBack) { }

		// // RVA: 0x17E3E38 Offset: 0x17E3E38 VA: 0x17E3E38
		// public void LoadDivaUpIco(int id, int modelId, int colorId, Action<IiconTexture> callBack) { }

		// // RVA: 0x17E3EE4 Offset: 0x17E3EE4 VA: 0x17E3EE4
		// public static string GetDivaUpIconPath(int id, int modelId, int colorId) { }

		// // RVA: 0x17E3F80 Offset: 0x17E3F80 VA: 0x17E3F80
		// public void LoadDivaSmallBustupIcon(int id, int modelId, Action<IiconTexture> callBack) { }

		// // RVA: 0x17E4044 Offset: 0x17E4044 VA: 0x17E4044
		// public void LoadEventGoDivaIcon(int id, Action<IiconTexture> callBack) { }

		// // RVA: 0x17E40EC Offset: 0x17E40EC VA: 0x17E40EC
		// public void LoadEventGoDivaIcon(int id, DivaIconTextureCache.GoDivaIconType type, Action<IiconTexture> callBack) { }

		// // RVA: 0x17E41B4 Offset: 0x17E41B4 VA: 0x17E41B4
		// public static string GetDivaStandingCostumeIconPath(int id, int modelId) { }

		// // RVA: 0x17E3DAC Offset: 0x17E3DAC VA: 0x17E3DAC
		// public static string MakeTutorialIconPath(int charId) { }

		// // RVA: 0x17E425C Offset: 0x17E425C VA: 0x17E425C
		// public void TryInstall(DFKGGBMFFGB playerData) { }

		// // RVA: 0x17E43CC Offset: 0x17E43CC VA: 0x17E43CC
		// public void TryInstall(int divaId, int modelId, int colorId) { }

		// // RVA: 0x17E4504 Offset: 0x17E4504 VA: 0x17E4504
		// public void TryStateDivaIconInstall(int divaId, int modelId, int colorId) { }

		// // RVA: 0x17E463C Offset: 0x17E463C VA: 0x17E463C
		// public void TryStateDivaUpIconInstall(int divaId, int modelId, int colorId) { }

		// // RVA: 0x17E4774 Offset: 0x17E4774 VA: 0x17E4774
		// public void TryLoadStoryIconInstall(int divaId, int modelId) { }

		// // RVA: 0x17E48B0 Offset: 0x17E48B0 VA: 0x17E48B0
		// public void TryLoadStandingCostumeIconInstall(int divaId, int modelId) { }

		// // RVA: 0x17E49EC Offset: 0x17E49EC VA: 0x17E49EC
		// public void TryLoadDivaSmallBustupIcon(int divaId, int modelId) { }

		// // RVA: 0x17E4B28 Offset: 0x17E4B28 VA: 0x17E4B28
		// public void TryLoadEventGoDivaIcon(int divaId) { }

		// // RVA: 0x17E4C44 Offset: 0x17E4C44 VA: 0x17E4C44
		static DivaIconTextureCache()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// [CompilerGeneratedAttribute] // RVA: 0x6C6030 Offset: 0x6C6030 VA: 0x6C6030
		// // RVA: 0x17E5200 Offset: 0x17E5200 VA: 0x17E5200
		// private void <EntryLoadingTexture>b__22_0(IiconTexture texture) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6C6040 Offset: 0x6C6040 VA: 0x6C6040
		// // RVA: 0x17E52F4 Offset: 0x17E52F4 VA: 0x17E52F4
		// private void <EntryLoadingTexture>b__22_1(IiconTexture texture) { }
	}
}