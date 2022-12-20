
namespace XeApp.Game.RhythmGame
{
	public class SkillCenterLiveSkillNoteTouchTrigger : SkillTriggerBase
	{
		// RVA: 0x1552CC0 Offset: 0x1552CC0 VA: 0x1552CC0 Slot: 4
		public override void Initialize(int value)
		{
			return;
		}

		// RVA: 0x1552CC4 Offset: 0x1552CC4 VA: 0x1552CC4 Slot: 5
		public override bool IsFulfill(SkillTriggerParameter param)
		{
			if(param.currentLifeRate > 0)
			{
				if(param.touchedCenterLiveSkillNote)
				{
					param.touchedCenterLiveSkillNote = true;
				}
				return param.touchedCenterLiveSkillNote;
			}
			return false;
		}

		//// RVA: 0x1552CEC Offset: 0x1552CEC VA: 0x1552CEC Slot: 6
		public override void OnFulfill(SkillTriggerParameter param)
		{
			return;
		}
	}
}
