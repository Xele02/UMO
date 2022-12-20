
namespace XeApp.Game.RhythmGame
{
	public class SkillComboTrigger : SkillTriggerBase
	{
		private int thretholdCombo; // 0xC

		// RVA: 0x1552CF8 Offset: 0x1552CF8 VA: 0x1552CF8 Slot: 4
		public override void Initialize(int value)
		{
			thretholdCombo = value;
		}

		//// RVA: 0x1552D00 Offset: 0x1552D00 VA: 0x1552D00 Slot: 5
		public override bool IsFulfill(SkillTriggerParameter param)
		{
			if (param.currentLifeRate > 0)
				return thretholdCombo <= param.currentCombo;
			return false;
		}

		//// RVA: 0x1552D34 Offset: 0x1552D34 VA: 0x1552D34 Slot: 6
		public override void OnFulfill(SkillTriggerParameter param)
		{
			return;
		}
	}
}
