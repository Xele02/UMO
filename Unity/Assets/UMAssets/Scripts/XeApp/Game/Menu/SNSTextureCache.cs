using System;

namespace XeApp.Game.Menu
{
	public class SNSIconTexture : IconTexture
	{
		//
	}
	public class SNSTextureCache : IconTextureCache
	{
		// // RVA: 0x159D2F8 Offset: 0x159D2F8 VA: 0x159D2F8 Slot: 5
		public override void Terminated()
		{
			Clear();
		}

		// // RVA: 0x159D300 Offset: 0x159D300 VA: 0x159D300 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			SNSIconTexture tex = new SNSIconTexture();
			SetupForSplitTexture(info, tex);
			return tex;
		}

		// // RVA: 0x159B494 Offset: 0x159B494 VA: 0x159B494
		public void CharIconLoad(int chara, Action<IiconTexture> callBack)
		{
			Load(string.Format("ct/sn/ch/{0:D2}.xab", chara), callBack);
		}

		// // RVA: 0x159D388 Offset: 0x159D388 VA: 0x159D388
		// public void RoomIconLoad(int room, Action<IiconTexture> callBack) { }
	}
}
