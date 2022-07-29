using System;
using XeApp.Game.Common;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameStatus
	{
		public struct InitializeData
		{
			public MusicData musicData; // 0x0
			public int teamScoreValue; // 0x4
			public int teamEnergyValue; // 0x8
			public float supportRate; // 0xC
			public int valkyrieId; // 0x10
			public int maxLife; // 0x14
			public bool isLiveSkip; // 0x18
		}

		// public RhythmGameMode directionMode { get; private set; } // 0x8
		// public RhythmGameMode internalMode { get; private set; } // 0xC
		// public RhythmGameScore score { get; private set; } // 0x10
		public RhythmGameEnergy energy { get; private set; } // 0x14
		// public RhythmGameLife life { get; private set; } // 0x18
		// public RhythmGameCombo combo { get; private set; } // 0x1C
		// public RhythmGameCombo comboValkyrie { get; private set; } // 0x20
		// public RhythmGameEnemyStatus enemy { get; private set; } // 0x24

		// // RVA: 0xC01FFC Offset: 0xC01FFC VA: 0xC01FFC
		public RhythmGameStatus(InitializeData initData, Action<int> onPlayPilotVoice)
		{
		}

		// // RVA: 0xC006B0 Offset: 0xC006B0 VA: 0xC006B0
		public void Update()
		{
			UnityEngine.Debug.LogError("TODO RhythmGameStatus Update");
		}

		// // RVA: 0xC0C2D8 Offset: 0xC0C2D8 VA: 0xC0C2D8
		// public void Reset() { }

		// // RVA: 0xC0C3F4 Offset: 0xC0C3F4 VA: 0xC0C3F4
		// public bool IsEnableValkyrieAttack() { }

	}
}
