
namespace XeApp.Game.RhythmGame
{
	public class SkillFirstCheckTrigger : SkillTriggerBase
	{
		private int cnt; // 0xC

		// RVA: 0x1552D84 Offset: 0x1552D84 VA: 0x1552D84 Slot: 4
		public override void Initialize(int value)
		{
			cnt = 0;
		}

		//// RVA: 0x1552D90 Offset: 0x1552D90 VA: 0x1552D90 Slot: 5
		public override bool IsFulfill(SkillTriggerParameter param)
		{
			return cnt < 1;
		}

		//// RVA: 0x1552DA4 Offset: 0x1552DA4 VA: 0x1552DA4 Slot: 6
		public override void OnFulfill(SkillTriggerParameter param)
		{
			cnt++;
		}
	}
}
