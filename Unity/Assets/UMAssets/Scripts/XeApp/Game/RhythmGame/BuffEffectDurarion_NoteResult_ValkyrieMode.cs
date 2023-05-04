namespace XeApp.Game.RhythmGame
{
	public class BuffEffectDurarion_NoteResult_ValkyrieMode : BuffEffectDurarion_NoteResult
	{
		//// RVA: 0xF694AC Offset: 0xF694AC VA: 0xF694AC Slot: 5
		public override bool InDuration(BuffDurationCheckParameter checkParameter)
		{
			if (checkParameter.bitNoteResult != 0 && (m_duration_bit & checkParameter.bitNoteResult) == 0)
				return false;
			return checkParameter.modeType == RhythmGameMode.Type.Valkyrie;
		}
	}
}
