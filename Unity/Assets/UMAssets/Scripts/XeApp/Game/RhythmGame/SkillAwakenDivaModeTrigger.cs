
namespace XeApp.Game.RhythmGame
{
	public class SkillAwakenDivaModeTrigger : SkillTriggerBase
	{
		// RVA: 0x15524EC Offset: 0x15524EC VA: 0x15524EC Slot: 4
		public override void Initialize(int value)
		{
			return;
		}

		//// RVA: 0x15524F0 Offset: 0x15524F0 VA: 0x15524F0 Slot: 5
		public override bool IsFulfill(SkillTriggerParameter param)
		{
			if (param.currentLifeRate > 0)
				return param.modeType == RhythmGameMode.Type.AwakenDiva;
			return false;
		}

		//// RVA: 0x1552518 Offset: 0x1552518 VA: 0x1552518 Slot: 6
		public override void OnFulfill(SkillTriggerParameter param)
		{
			return;
		}
	}
}
