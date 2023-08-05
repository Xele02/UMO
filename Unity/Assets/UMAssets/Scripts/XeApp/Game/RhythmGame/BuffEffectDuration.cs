using XeApp.Game.Common;

namespace XeApp.Game.RhythmGame
{
	public abstract class BuffEffectDuration
	{
		public BuffDurationInitialParameter initialParameter; // 0x8

		//// RVA: 0xF693C8 Offset: 0xF693C8 VA: 0xF693C8 Slot: 4
		public virtual void Initialize(BuffDurationInitialParameter initialParameter)
		{
			this.initialParameter = initialParameter;
		}

		//// RVA: -1 Offset: -1 Slot: 5
		public abstract bool InDuration(BuffDurationCheckParameter checkParameter);

		//// RVA: 0xF694D8 Offset: 0xF694D8 VA: 0xF694D8 Slot: 6
		public virtual bool IsValue(RhythmGameConsts.NoteResult a_result)
		{
			return true;
		}

		//// RVA: -1 Offset: -1 Slot: 7
		public abstract float GetEndMusicTime();
	}
}
