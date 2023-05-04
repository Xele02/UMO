namespace XeApp.Game.RhythmGame
{
	public class BuffEffectDurarion_NoteResult_DivaMode : BuffEffectDurarion_NoteResult
	{
		//// RVA: 0xF69464 Offset: 0xF69464 VA: 0xF69464 Slot: 5
		public override bool InDuration(BuffDurationCheckParameter checkParameter)
		{
			if(checkParameter.bitNoteResult != 0)
			{
				if(checkParameter.modeType >= RhythmGameMode.Type.Diva && checkParameter.modeType <= RhythmGameMode.Type.AwakenDiva
					&& (m_duration_bit & checkParameter.bitNoteResult) != 0)
				{
					return true;
				}
				return false;
			}
			if (checkParameter.modeType < RhythmGameMode.Type.Diva && checkParameter.modeType > RhythmGameMode.Type.AwakenDiva)
				return false;
			return true;
		}
	}
}
