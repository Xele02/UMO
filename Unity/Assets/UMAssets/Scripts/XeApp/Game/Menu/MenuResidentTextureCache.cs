using System;

namespace XeApp.Game.Menu
{
	public class MenuResidentTextureCache : IconTextureCache
	{
		// RVA: 0xB2D630 Offset: 0xB2D630 VA: 0xB2D630 Slot: 5
		public override void Terminated()
		{
			Clear();
		}

		// RVA: 0xB2D638 Offset: 0xB2D638 VA: 0xB2D638 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			BgTexture tex = new BgTexture();
			SetupForSplitTexture(info, tex);
			return tex;
		}

		// // RVA: 0xB2D6C0 Offset: 0xB2D6C0 VA: 0xB2D6C0
		public void LoadLogo(int seriase, Action<IiconTexture> callBack)
		{
			Load(string.Format("ct/lo/{0:D2}.xab", seriase), callBack);
		}

		// // RVA: 0xB2D768 Offset: 0xB2D768 VA: 0xB2D768
		public void LoadLogoUnlock(int seriase, Action<IiconTexture> callBack)
		{
			Load(string.Format("ct/lu/{0:D2}.xab", seriase), callBack);
		}

		// // RVA: 0xB2D810 Offset: 0xB2D810 VA: 0xB2D810
		// public void LoadDegree(int id, int subId, Action<IiconTexture> callBack) { }

		// // RVA: 0xB2D8D4 Offset: 0xB2D8D4 VA: 0xB2D8D4
		public void EntryCache()
		{
			for(int i = 1; i < 5; i++)
			{
				LoadLogo(i, null);
			}
		}
	}
}
