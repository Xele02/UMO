using System;

namespace XeApp.Game.Menu
{
	public class SpEventButtonTextureCache : IconTextureCache
	{

		// RVA: 0x12DF9C8 Offset: 0x12DF9C8 VA: 0x12DF9C8
		public SpEventButtonTextureCache() : base(8)
		{
			return;
		}

		// // RVA: 0x12DF9D4 Offset: 0x12DF9D4 VA: 0x12DF9D4 Slot: 5
		public override void Terminated()
		{
			Clear();
		}

		// // RVA: 0x12DF9DC Offset: 0x12DF9DC VA: 0x12DF9DC Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			SpEventButtonTexture res = new SpEventButtonTexture();
			SetupForSplitTexture(info, res);
			return res;
		}

		// // RVA: 0x12DF82C Offset: 0x12DF82C VA: 0x12DF82C
		public void Load(int eventId, int btnId, Action<IiconTexture> callBack)
		{
			Load(MakeTexturePath(eventId, btnId), callBack);
		}

		// // RVA: 0x12DFB0C Offset: 0x12DFB0C VA: 0x12DFB0C
		// public void TryInstall(int eventId, int btnId) { }

		// // RVA: 0x12DFA64 Offset: 0x12DFA64 VA: 0x12DFA64
		public static string MakeTexturePath(int eventId, int btnId)
		{
			return string.Format("ct/ev/fs/{0:D4}{1:D2}.xab", eventId, btnId);
		}
	}
}
