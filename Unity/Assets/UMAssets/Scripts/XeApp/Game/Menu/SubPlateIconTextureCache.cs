using System;

namespace XeApp.Game.Menu
{
	public class SubPlateIconTexture : IconTexture
	{
	}

	public class SubPlateIconTextureCache : IconTextureCache
	{
		// // RVA: 0x1A9D7EC Offset: 0x1A9D7EC VA: 0x1A9D7EC Slot: 5
		public override void Terminated()
		{
			Clear();
		}

		// // RVA: 0x1A9D7F4 Offset: 0x1A9D7F4 VA: 0x1A9D7F4 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			SubPlateIconTexture tex = new SubPlateIconTexture();
			SetupForSplitTexture(info, tex);
			return tex;
		}

		// // RVA: 0x1A9D87C Offset: 0x1A9D87C VA: 0x1A9D87C
		public void Load(int attr, int status, Action<IiconTexture> callback)
		{
			Load(string.Format("ct/sb/{0:d2}_{1:d2}.xab", attr, status), callback);
		}

		// // RVA: 0x1A9D940 Offset: 0x1A9D940 VA: 0x1A9D940
		public void TryInstall()
		{
			for(int i = 0; i < 3; i++)
			{
				for(int j = 1; j < 4; j++)
				{
					KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(string.Format("ct/sb/{0:d2}_{1:d2}.xab", i, j));
				}
			}
		}
	}
}
