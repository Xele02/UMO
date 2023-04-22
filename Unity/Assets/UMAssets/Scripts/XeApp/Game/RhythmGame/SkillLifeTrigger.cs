
namespace XeApp.Game.RhythmGame
{
	public class SkillLifeTrigger : SkillTriggerBase
	{
		private int thretholdLife; // 0xC

		// RVA: 0x1552DBC Offset: 0x1552DBC VA: 0x1552DBC Slot: 4
		public override void Initialize(int value)
		{
			thretholdLife = value;
		}

		//// RVA: 0x1552DC4 Offset: 0x1552DC4 VA: 0x1552DC4 Slot: 5
		public override bool IsFulfill(SkillTriggerParameter param)
		{
			if (param.currentLifeRate > 0)
				return param.currentLifeRate <= thretholdLife / 100.0f;
			return false;
		}

		//// RVA: 0x1552E00 Offset: 0x1552E00 VA: 0x1552E00 Slot: 6
		public override void OnFulfill(SkillTriggerParameter param)
		{
			return;
		}
	}
}
