
using System;

namespace XeApp.Game.Menu
{
	public class MusicJacketTextureCache : IconTextureCache
	{
		public const string SelectTexutreBundleFormat = "ct/mc/{0:D3}.xab";
		public const string DetailTextureBundleFormat = "ct/md/{0:D3}.xab";
		public const string EventTextureBundleFormat = "ct/ev/mc/{0:D4}.xab";

		// // RVA: 0x104B8D0 Offset: 0x104B8D0 VA: 0x104B8D0 Slot: 5
		public override void Terminated()
		{
			Clear();
		}

		// // RVA: 0x104B8D8 Offset: 0x104B8D8 VA: 0x104B8D8 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			IconTexture res = new IconTexture();
			SetupForSingleTexture(info, res);
			return res;
		}

		// // RVA: 0x104B3E8 Offset: 0x104B3E8 VA: 0x104B3E8
		public void Load(int jacketId, Action<IiconTexture> callBack)
		{
			Load(MakeJacketTexturePath(jacketId), callBack);
		}

		// // RVA: 0x104B960 Offset: 0x104B960 VA: 0x104B960
		public static string MakeJacketTexturePath(int jacketId)
		{
			return string.Format("ct/mc/{0:D3}.xab", jacketId);
		}

		// // RVA: 0x104B418 Offset: 0x104B418 VA: 0x104B418
		public void LoadDetail(int jacketId, Action<IiconTexture> callBack)
		{
			Load(string.Format("ct/md/{0:D3}.xab", jacketId), callBack);
		}

		// // RVA: 0x104B9EC Offset: 0x104B9EC VA: 0x104B9EC
		// public void LoadForEvent(int eventId, Action<IiconTexture> callback) { }

		// // RVA: 0x104BA94 Offset: 0x104BA94 VA: 0x104BA94
		public static void TryInstall(int jacketId)
		{
			KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(MakeJacketTexturePath(jacketId));
		}
	}
}
