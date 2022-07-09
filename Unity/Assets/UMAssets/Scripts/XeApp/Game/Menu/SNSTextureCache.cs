namespace XeApp.Game.Menu
{
	public class SNSTextureCache : IconTextureCache
	{
		// // RVA: 0x159D2F8 Offset: 0x159D2F8 VA: 0x159D2F8 Slot: 5
		// public override void Terminated() { }

		// // RVA: 0x159D300 Offset: 0x159D300 VA: 0x159D300 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			UnityEngine.Debug.LogError("TODO CreateIconTexture");
			return null;
		}

		// // RVA: 0x159B494 Offset: 0x159B494 VA: 0x159B494
		// public void CharIconLoad(int chara, Action<IiconTexture> callBack) { }

		// // RVA: 0x159D388 Offset: 0x159D388 VA: 0x159D388
		// public void RoomIconLoad(int room, Action<IiconTexture> callBack) { }
	}
}
