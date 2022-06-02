using System;
using XeApp.Game.Common;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameStatus
	{
		public struct InitializeData
		{
			public MusicData musicData;
			public int teamScoreValue;
			public int teamEnergyValue;
			public float supportRate;
			public int valkyrieId;
			public int maxLife;
			public bool isLiveSkip;
		}

		public RhythmGameStatus(RhythmGameStatus.InitializeData initData, Action<int> onPlayPilotVoice)
		{
		}

	}
}
