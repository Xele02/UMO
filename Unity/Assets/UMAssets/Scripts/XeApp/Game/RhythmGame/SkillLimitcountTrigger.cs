
namespace XeApp.Game.RhythmGame
{
	public class SkillLimitcountTrigger : SkillTriggerBase
	{
		private int limitCount; // 0xC
		private int count; // 0x10

		//// RVA: 0x1552E0C Offset: 0x1552E0C VA: 0x1552E0C Slot: 4
		public override void Initialize(int value)
		{
			limitCount = value;
			count = 0;
		}

		//// RVA: 0x1552E1C Offset: 0x1552E1C VA: 0x1552E1C Slot: 5
		public override bool IsFulfill(SkillTriggerParameter param)
		{
			return count < limitCount;
		}

		//// RVA: 0x1552E34 Offset: 0x1552E34 VA: 0x1552E34 Slot: 6
		public override void OnFulfill(SkillTriggerParameter param)
		{
			count++;
		}
	}
}
