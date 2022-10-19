using XeApp.Game.Common;

namespace XeApp.Game.RhythmGame
{
	public class BuffEffectDurarion_NoteResult : BuffEffectDuration
	{
		public RhythmGameConsts.NoteResult m_result_duration; // 0x14
		public RhythmGameConsts.NoteResult m_result_value; // 0x18
		public int m_duration_bit; // 0x1C

		//// RVA: 0xF692DC Offset: 0xF692DC VA: 0xF692DC
		//public int BitResult(RhythmGameConsts.NoteResult a_result) { }

		//// RVA: 0xF69308 Offset: 0xF69308 VA: 0xF69308 Slot: 4
		public override void Initialize(BuffDurationInitialParameter initialParameter)
		{
			base.Initialize(initialParameter);
			if (initialParameter.durationValue > 0 && initialParameter.durationValue < 7)
			{
				switch (initialParameter.durationValue)
				{
					case 1:
						m_result_duration = RhythmGameConsts.NoteResult.Perfect;
						m_result_value = RhythmGameConsts.NoteResult.Perfect;
						break;
					case 3:
						m_result_duration = RhythmGameConsts.NoteResult.Good;
						m_result_value = RhythmGameConsts.NoteResult.Good;
						break;
					case 4:
						m_result_duration = RhythmGameConsts.NoteResult.Great;
						m_result_value = RhythmGameConsts.NoteResult.Perfect;
						break;
					case 5:
						m_result_duration = RhythmGameConsts.NoteResult.Good;
						m_result_value = RhythmGameConsts.NoteResult.Perfect;
						break;
					case 6:
						m_result_duration = RhythmGameConsts.NoteResult.Good;
						m_result_value = RhythmGameConsts.NoteResult.Great;
						break;
					default:
						m_result_duration = RhythmGameConsts.NoteResult.Great;
						m_result_duration = RhythmGameConsts.NoteResult.Great;
						break;
				}
			}
			m_duration_bit = m_result_duration < RhythmGameConsts.NoteResult.Bad ? 1 : 0;
			if (m_result_duration < RhythmGameConsts.NoteResult.Good)
				m_duration_bit |= 2;
			if (m_result_duration < RhythmGameConsts.NoteResult.Great)
				m_duration_bit |= 4;
			if (m_result_duration < RhythmGameConsts.NoteResult.Perfect)
				m_duration_bit |= 8;
			if (m_result_duration < RhythmGameConsts.NoteResult.Num)
				m_duration_bit |= 16;
		}

		//// RVA: 0xF693D4 Offset: 0xF693D4 VA: 0xF693D4 Slot: 5
		//public override bool InDuration(BuffDurationCheckParameter checkParameter) { }

		//// RVA: 0xF693F8 Offset: 0xF693F8 VA: 0xF693F8 Slot: 6
		public override bool IsValue(RhythmGameConsts.NoteResult a_result)
		{
			if(a_result < RhythmGameConsts.NoteResult.Num)
			{
				return m_result_value <= a_result;
			}
			return true;
		}

		//// RVA: 0xF6941C Offset: 0xF6941C VA: 0xF6941C Slot: 7
		//public override float GetEndMusicTime() { }
	}
}
