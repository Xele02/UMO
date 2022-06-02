using System;
using UnityEngine.UI;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	[Serializable]
	public struct EpisodeLayoutParts
	{
		public Text episodeNameText;
		public Text bonusPointText;
		public Text bonusPointMaxText;
		public Text assistText;
		public RawImageEx episodeImage;
	}
}
