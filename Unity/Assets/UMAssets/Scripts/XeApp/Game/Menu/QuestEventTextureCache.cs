using System;

namespace XeApp.Game.Menu
{
	public class QuestEventIconTexture : IconTexture
	{
		//
	}

	public class QuestEventTextureCache : IconTextureCache
	{

		// RVA: 0x9D5A00 Offset: 0x9D5A00 VA: 0x9D5A00
		public QuestEventTextureCache() : base(4)
		{
			return;
		}

		// RVA: 0x9D5A0C Offset: 0x9D5A0C VA: 0x9D5A0C Slot: 5
		public override void Terminated()
		{
			Clear();
		}

		// RVA: 0x9D5A14 Offset: 0x9D5A14 VA: 0x9D5A14 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			QuestEventIconTexture tex = new QuestEventIconTexture();
			SetupForSplitTexture(info, tex);
			return tex;
		}

		// RVA: 0x9D5A9C Offset: 0x9D5A9C VA: 0x9D5A9C
		public void LoadIcon(int id, Action<IiconTexture> callback)
		{
			Load(string.Format("ct/qu/qi/{0:d5}.xab", id), callback);
		}

		// // RVA: 0x9D5B44 Offset: 0x9D5B44 VA: 0x9D5B44
		public void LoadFont(int id, Action<IiconTexture> callback)
		{
			Load(string.Format("ct/qu/qf/{0:d5}.xab", id), callback);
		}
	}
}
