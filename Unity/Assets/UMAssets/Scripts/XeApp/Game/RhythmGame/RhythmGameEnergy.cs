using System;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameEnergy
	{
		// // Fields
		private int basicValue; // 0x8
		private float awakenIncreaseRate; // 0xC
		private float awakenDecreaseRate; // 0x10
		private float rateMinValue; // 0x14
		private int specialNotesBonusValue; // 0x18
		private float[] resultRateTable; // 0x1C
		// [CompilerGeneratedAttribute] // RVA: 0x68E9C8 Offset: 0x68E9C8 VA: 0x68E9C8
		// private int <subgoalValue>k__BackingField; // 0x20
		// [CompilerGeneratedAttribute] // RVA: 0x68E9D8 Offset: 0x68E9D8 VA: 0x68E9D8
		// private int <goalValue>k__BackingField; // 0x24
		// [CompilerGeneratedAttribute] // RVA: 0x68E9E8 Offset: 0x68E9E8 VA: 0x68E9E8
		// private int <maxValue>k__BackingField; // 0x28
		public int currentValue; // 0x2C
		// [CompilerGeneratedAttribute] // RVA: 0x68E9F8 Offset: 0x68E9F8 VA: 0x68E9F8
		// private int <evaluationNotesNum>k__BackingField; // 0x30
		private int teamPowerValue; // 0x34
		private Action<int> onPlayPilotVoice; // 0x38
		private bool usedForceSubgoal; // 0x3C
		// private RhythmGameEnergy.PilotVoiceTimingData[] pilotVoiceTimingTable; // 0x40

		// // Properties
		public int subgoalValue { get; set; }
		public int goalValue { get; set; }
		public int maxValue { get; set; }
		public int evaluationNotesNum { get; set; }
		// public RhythmGameEnergy.Mode mode { get; set; }

		// // Methods

		// [CompilerGeneratedAttribute] // RVA: 0x746674 Offset: 0x746674 VA: 0x746674
		// // RVA: 0xDC5340 Offset: 0xDC5340 VA: 0xDC5340
		// public int get_subgoalValue() { }

		// [CompilerGeneratedAttribute] // RVA: 0x746684 Offset: 0x746684 VA: 0x746684
		// // RVA: 0xDC5348 Offset: 0xDC5348 VA: 0xDC5348
		// private void set_subgoalValue(int value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x746694 Offset: 0x746694 VA: 0x746694
		// // RVA: 0xDC5350 Offset: 0xDC5350 VA: 0xDC5350
		// public int get_goalValue() { }

		// [CompilerGeneratedAttribute] // RVA: 0x7466A4 Offset: 0x7466A4 VA: 0x7466A4
		// // RVA: 0xDC5358 Offset: 0xDC5358 VA: 0xDC5358
		// private void set_goalValue(int value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x7466B4 Offset: 0x7466B4 VA: 0x7466B4
		// // RVA: 0xDC5360 Offset: 0xDC5360 VA: 0xDC5360
		// public int get_maxValue() { }

		// [CompilerGeneratedAttribute] // RVA: 0x7466C4 Offset: 0x7466C4 VA: 0x7466C4
		// // RVA: 0xDC5368 Offset: 0xDC5368 VA: 0xDC5368
		// private void set_maxValue(int value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x7466D4 Offset: 0x7466D4 VA: 0x7466D4
		// // RVA: 0xDC5370 Offset: 0xDC5370 VA: 0xDC5370
		// public int get_evaluationNotesNum() { }

		// [CompilerGeneratedAttribute] // RVA: 0x7466E4 Offset: 0x7466E4 VA: 0x7466E4
		// // RVA: 0xDC5378 Offset: 0xDC5378 VA: 0xDC5378
		// private void set_evaluationNotesNum(int value) { }

		// // RVA: 0xDC5380 Offset: 0xDC5380 VA: 0xDC5380
		// public RhythmGameEnergy.Mode get_mode() { }

		// // RVA: 0xDC53A8 Offset: 0xDC53A8 VA: 0xDC53A8
		// private void set_mode(RhythmGameEnergy.Mode value) { }

		// // RVA: 0xDC53AC Offset: 0xDC53AC VA: 0xDC53AC
		// public void Initialize(MusicData musicData, GameSetupData.MusicInfo musicInfo, int teamPowerValue, Action<int> onPlayPilotVoice) { }

		// // RVA: 0xDC5BAC Offset: 0xDC5BAC VA: 0xDC5BAC
		public void DisableCallbackPilotVoice()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xDC5BB8 Offset: 0xDC5BB8 VA: 0xDC5BB8
		// public void Reset() { }

		// // RVA: 0xDC5C4C Offset: 0xDC5C4C VA: 0xDC5C4C
		// public int GetGaugeValue() { }

		// // RVA: 0xDC5CC0 Offset: 0xDC5CC0 VA: 0xDC5CC0
		// private int GetGaugeValue(int current) { }

		// // RVA: 0xDC5D30 Offset: 0xDC5D30 VA: 0xDC5D30
		// public void ChangeValue(RhythmGameConsts.NoteResult result, float bonusRate, RhythmGameConsts.SpecialNoteType spType) { }

		// // RVA: 0xDC5E68 Offset: 0xDC5E68 VA: 0xDC5E68
		// private int CalcIncreaseValue(RhythmGameConsts.NoteResult result, float bonusRate, int current) { }

		// // RVA: 0xDC6288 Offset: 0xDC6288 VA: 0xDC6288
		// public void ForceChangePercentage100() { }

		// // RVA: 0xDC5F6C Offset: 0xDC5F6C VA: 0xDC5F6C
		// private void PlayPilotVoice() { }

		// // RVA: 0xDC60F0 Offset: 0xDC60F0 VA: 0xDC60F0
		// private float CalcNotesBasicValue(float change, int current) { }

		// // RVA: 0xDC62A8 Offset: 0xDC62A8 VA: 0xDC62A8
		// public bool CalcPossiblityNextMode() { }

		// // RVA: 0xDC6314 Offset: 0xDC6314 VA: 0xDC6314
		// public void .ctor() { }
	}
}
