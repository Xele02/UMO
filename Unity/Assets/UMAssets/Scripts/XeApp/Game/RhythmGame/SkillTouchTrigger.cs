
namespace XeApp.Game.RhythmGame
{
	public class SkillTouchTrigger : SkillTriggerBase
	{
		// RVA: 0x1554A1C Offset: 0x1554A1C VA: 0x1554A1C Slot: 4
		public override void Initialize(int value)
		{
			return;
		}

		//// RVA: 0x1554A20 Offset: 0x1554A20 VA: 0x1554A20 Slot: 5
		public override bool IsFulfill(SkillTriggerParameter param)
		{
			if(param.currentLifeRate > 0)
			{
				if (param.touchedSkill)
					param.touchedSkill = true;
				return param.touchedSkill;
			}
			return false;
		}

		//// RVA: 0x1554A48 Offset: 0x1554A48 VA: 0x1554A48 Slot: 6
		public override void OnFulfill(SkillTriggerParameter param)
		{
			return;
		}
	}
}
