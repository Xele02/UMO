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

		// // Fields
		// [CompilerGeneratedAttribute] // RVA: 0x68EAC8 Offset: 0x68EAC8 VA: 0x68EAC8
		// private RhythmGameMode <directionMode>k__BackingField; // 0x8
		// [CompilerGeneratedAttribute] // RVA: 0x68EAD8 Offset: 0x68EAD8 VA: 0x68EAD8
		// private RhythmGameMode <internalMode>k__BackingField; // 0xC
		// [CompilerGeneratedAttribute] // RVA: 0x68EAE8 Offset: 0x68EAE8 VA: 0x68EAE8
		// private RhythmGameScore <score>k__BackingField; // 0x10
		// [CompilerGeneratedAttribute] // RVA: 0x68EAF8 Offset: 0x68EAF8 VA: 0x68EAF8
		// private RhythmGameEnergy <energy>k__BackingField; // 0x14
		// [CompilerGeneratedAttribute] // RVA: 0x68EB08 Offset: 0x68EB08 VA: 0x68EB08
		// private RhythmGameLife <life>k__BackingField; // 0x18
		// [CompilerGeneratedAttribute] // RVA: 0x68EB18 Offset: 0x68EB18 VA: 0x68EB18
		// private RhythmGameCombo <combo>k__BackingField; // 0x1C
		// [CompilerGeneratedAttribute] // RVA: 0x68EB28 Offset: 0x68EB28 VA: 0x68EB28
		// private RhythmGameCombo <comboValkyrie>k__BackingField; // 0x20
		// [CompilerGeneratedAttribute] // RVA: 0x68EB38 Offset: 0x68EB38 VA: 0x68EB38
		// private RhythmGameEnemyStatus <enemy>k__BackingField; // 0x24

		// // Properties
		// public RhythmGameMode directionMode { get; set; }
		// public RhythmGameMode internalMode { get; set; }
		// public RhythmGameScore score { get; set; }
		public RhythmGameEnergy energy { get; set; }
		// public RhythmGameLife life { get; set; }
		// public RhythmGameCombo combo { get; set; }
		// public RhythmGameCombo comboValkyrie { get; set; }
		// public RhythmGameEnemyStatus enemy { get; set; }

		// // Methods

		// [CompilerGeneratedAttribute] // RVA: 0x746874 Offset: 0x746874 VA: 0x746874
		// // RVA: 0xC029C8 Offset: 0xC029C8 VA: 0xC029C8
		// public RhythmGameMode get_directionMode() { }

		// [CompilerGeneratedAttribute] // RVA: 0x746884 Offset: 0x746884 VA: 0x746884
		// // RVA: 0xC0C298 Offset: 0xC0C298 VA: 0xC0C298
		// private void set_directionMode(RhythmGameMode value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x746894 Offset: 0x746894 VA: 0x746894
		// // RVA: 0xC022F0 Offset: 0xC022F0 VA: 0xC022F0
		// public RhythmGameMode get_internalMode() { }

		// [CompilerGeneratedAttribute] // RVA: 0x7468A4 Offset: 0x7468A4 VA: 0x7468A4
		// // RVA: 0xC0C2A0 Offset: 0xC0C2A0 VA: 0xC0C2A0
		// private void set_internalMode(RhythmGameMode value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x7468B4 Offset: 0x7468B4 VA: 0x7468B4
		// // RVA: 0xC03040 Offset: 0xC03040 VA: 0xC03040
		// public RhythmGameScore get_score() { }

		// [CompilerGeneratedAttribute] // RVA: 0x7468C4 Offset: 0x7468C4 VA: 0x7468C4
		// // RVA: 0xC0C2A8 Offset: 0xC0C2A8 VA: 0xC0C2A8
		// private void set_score(RhythmGameScore value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x7468D4 Offset: 0x7468D4 VA: 0x7468D4
		// // RVA: 0xC022E8 Offset: 0xC022E8 VA: 0xC022E8
		// public RhythmGameEnergy get_energy() { }

		// [CompilerGeneratedAttribute] // RVA: 0x7468E4 Offset: 0x7468E4 VA: 0x7468E4
		// // RVA: 0xC0C2B0 Offset: 0xC0C2B0 VA: 0xC0C2B0
		// private void set_energy(RhythmGameEnergy value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x7468F4 Offset: 0x7468F4 VA: 0x7468F4
		// // RVA: 0xC006DC Offset: 0xC006DC VA: 0xC006DC
		// public RhythmGameLife get_life() { }

		// [CompilerGeneratedAttribute] // RVA: 0x746904 Offset: 0x746904 VA: 0x746904
		// // RVA: 0xC0C2B8 Offset: 0xC0C2B8 VA: 0xC0C2B8
		// private void set_life(RhythmGameLife value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x746914 Offset: 0x746914 VA: 0x746914
		// // RVA: 0xC03038 Offset: 0xC03038 VA: 0xC03038
		// public RhythmGameCombo get_combo() { }

		// [CompilerGeneratedAttribute] // RVA: 0x746924 Offset: 0x746924 VA: 0x746924
		// // RVA: 0xC0C2C0 Offset: 0xC0C2C0 VA: 0xC0C2C0
		// private void set_combo(RhythmGameCombo value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x746934 Offset: 0x746934 VA: 0x746934
		// // RVA: 0xC07B10 Offset: 0xC07B10 VA: 0xC07B10
		// public RhythmGameCombo get_comboValkyrie() { }

		// [CompilerGeneratedAttribute] // RVA: 0x746944 Offset: 0x746944 VA: 0x746944
		// // RVA: 0xC0C2C8 Offset: 0xC0C2C8 VA: 0xC0C2C8
		// private void set_comboValkyrie(RhythmGameCombo value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x746954 Offset: 0x746954 VA: 0x746954
		// // RVA: 0xC0264C Offset: 0xC0264C VA: 0xC0264C
		// public RhythmGameEnemyStatus get_enemy() { }

		// [CompilerGeneratedAttribute] // RVA: 0x746964 Offset: 0x746964 VA: 0x746964
		// // RVA: 0xC0C2D0 Offset: 0xC0C2D0 VA: 0xC0C2D0
		// private void set_enemy(RhythmGameEnemyStatus value) { }

		// // RVA: 0xC01FFC Offset: 0xC01FFC VA: 0xC01FFC
		public RhythmGameStatus(InitializeData initData, Action<int> onPlayPilotVoice)
		{
		}

		// // RVA: 0xC006B0 Offset: 0xC006B0 VA: 0xC006B0
		// public void Update() { }

		// // RVA: 0xC0C2D8 Offset: 0xC0C2D8 VA: 0xC0C2D8
		// public void Reset() { }

		// // RVA: 0xC0C3F4 Offset: 0xC0C3F4 VA: 0xC0C3F4
		// public bool IsEnableValkyrieAttack() { }

	}
}
