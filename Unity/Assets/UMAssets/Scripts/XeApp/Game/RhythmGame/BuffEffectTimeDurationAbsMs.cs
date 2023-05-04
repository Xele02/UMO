namespace XeApp.Game.RhythmGame
{
	public class BuffEffectTimeDurationAbsMs : BuffEffectDuration
	{
		//// RVA: 0xF6B490 Offset: 0xF6B490 VA: 0xF6B490 Slot: 5
		public override bool InDuration(BuffDurationCheckParameter checkParameter)
		{
			return checkParameter.musicTime <= GetEndMusicTime();
		}

		//// RVA: 0xF6B4C8 Offset: 0xF6B4C8 VA: 0xF6B4C8 Slot: 7
		public override float GetEndMusicTime()
		{
			return RhythmGamePlayer.ToSecTime(initialParameter.durationValue);
		}
	}
}
