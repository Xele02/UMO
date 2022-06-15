using System;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameEnergy
	{
		private int basicValue; // 0x8
		private float awakenIncreaseRate; // 0xC
		private float awakenDecreaseRate; // 0x10
		private float rateMinValue; // 0x14
		private int specialNotesBonusValue; // 0x18
		private float[] resultRateTable; // 0x1C
		public int currentValue; // 0x2C
		private int teamPowerValue; // 0x34
		private Action<int> onPlayPilotVoice; // 0x38
		private bool usedForceSubgoal; // 0x3C
		// private RhythmGameEnergy.PilotVoiceTimingData[] pilotVoiceTimingTable; // 0x40

		public int subgoalValue { get; private set; } // 0x20
		public int goalValue { get; private set; } // 0x24
		public int maxValue { get; private set; } // 0x28
		public int evaluationNotesNum { get; private set; } // 0x30 
		// public RhythmGameEnergy.Mode mode { get; set; }// get_mode 0xDC5380 set_mode 0xDC53A8

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
		public RhythmGameEnergy()
		{
			UnityEngine.Debug.LogError("TODO");
		}
	}
}
