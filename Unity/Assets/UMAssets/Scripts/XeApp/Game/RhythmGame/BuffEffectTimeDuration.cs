namespace XeApp.Game.RhythmGame
{
	public class BuffEffectTimeDuration : BuffEffectDuration
	{
		// RVA: 0xF6B440 Offset: 0xF6B440 VA: 0xF6B440 Slot: 5
		public override bool InDuration(BuffDurationCheckParameter checkParameter)
		{
			return checkParameter.musicTime <= GetEndMusicTime();
		}

		// RVA: 0xF6B478 Offset: 0xF6B478 VA: 0xF6B478 Slot: 7
		public override float GetEndMusicTime()
		{
			return initialParameter.musicTime + initialParameter.durationValue;
		}
	}
}
