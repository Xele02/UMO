using System;
using UnityEngine.UI;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	[Serializable]
	public struct EpisodeLayoutParts
	{
		public Text episodeNameText; // 0x0
		public Text bonusPointText; // 0x4
		public Text bonusPointMaxText; // 0x8
		public Text assistText; // 0xC
		public RawImageEx episodeImage; // 0x10
		public AbsoluteLayout rootLayout; // 0x14
		public AbsoluteLayout frameLayout; // 0x18
		public AbsoluteLayout assistLayout; // 0x1C
	}
}
