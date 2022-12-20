
namespace XeApp.Game.RhythmGame
{
	public class SkillValkyrieModeTrigger : SkillTriggerBase
	{
		// RVA: 0x1554A64 Offset: 0x1554A64 VA: 0x1554A64 Slot: 4
		public override void Initialize(int value)
		{
			return;
		}

		//// RVA: 0x1554A68 Offset: 0x1554A68 VA: 0x1554A68 Slot: 5
		public override bool IsFulfill(SkillTriggerParameter param)
		{
			if (param.currentLifeRate > 0)
				return param.modeType == RhythmGameMode.Type.Valkyrie;
			return false;
		}

		//// RVA: 0x1554A90 Offset: 0x1554A90 VA: 0x1554A90 Slot: 6
		public override void OnFulfill(SkillTriggerParameter param)
		{
			return;
		}
	}
}
