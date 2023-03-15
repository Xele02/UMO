using System;

namespace XeApp.Game.Menu
{
	public class TipsTexture : IconTexture
	{
	}

	public class TipsTextureCache : IconTextureCache
	{
		// RVA: 0xA99FAC Offset: 0xA99FAC VA: 0xA99FAC
		public TipsTextureCache() : base(0)
		{
			return;
		}

		// // RVA: 0xA9C044 Offset: 0xA9C044 VA: 0xA9C044 Slot: 5
		public override void Terminated()
		{
			Clear();
		}

		// // RVA: 0xA9C04C Offset: 0xA9C04C VA: 0xA9C04C Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			TipsTexture tex = new TipsTexture();
			SetupForSplitTexture(info, tex);
			return tex;
		}

		// // RVA: 0xA992F0 Offset: 0xA992F0 VA: 0xA992F0
		public void Load(int imageId, Action<IiconTexture> callBack)
		{
			Load(string.Format("ct/tp/ti/{0:D2}.xab", imageId), callBack);
		}

		// // RVA: 0xA99398 Offset: 0xA99398 VA: 0xA99398
		public void LoadGraffiti(int id, Action<IiconTexture> callBack)
		{
			Load(string.Format("ct/tp/tg/{0:D3}.xab", (id - 1) / 2 + 1), callBack);
		}

		// // RVA: 0xA99450 Offset: 0xA99450 VA: 0xA99450
		public void LoadChara(int dir, int id, Action<IiconTexture> callBack)
		{
			Load(string.Format("ct/tp/tc/{0}{1:D7}.xab", dir == 1 ? "r" : "l", id), callBack);
		}
	}
}
