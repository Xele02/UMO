namespace XeApp.Game.RhythmGame
{
	public class BuffEffectDurarion_NoteResult_AwakenDivaMode : BuffEffectDurarion_NoteResult
	{
		//// RVA: 0xF69438 Offset: 0xF69438 VA: 0xF69438 Slot: 5
		public override bool InDuration(BuffDurationCheckParameter checkParameter)
		{
			if (checkParameter.bitNoteResult != 0 && (m_duration_bit & checkParameter.bitNoteResult) == 0)
				return false;
			return checkParameter.modeType == RhythmGameMode.Type.AwakenDiva;
		}
	}
}
