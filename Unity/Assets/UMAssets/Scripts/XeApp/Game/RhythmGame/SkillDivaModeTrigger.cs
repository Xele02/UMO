
namespace XeApp.Game.RhythmGame
{
	public class SkillDivaModeTrigger : SkillTriggerBase
	{
		// RVA: 0x1552D40 Offset: 0x1552D40 VA: 0x1552D40 Slot: 4
		public override void Initialize(int value)
		{
			return;
		}

		//// RVA: 0x1552D44 Offset: 0x1552D44 VA: 0x1552D44 Slot: 5
		public override bool IsFulfill(SkillTriggerParameter param)
		{
			if(0 < param.currentLifeRate)
			{
				if (param.modeType == RhythmGameMode.Type.Diva)
					return true;
				if (param.modeType == RhythmGameMode.Type.AwakenDiva)
					return true;
			}
			return false;
		}

		//// RVA: 0x1552D78 Offset: 0x1552D78 VA: 0x1552D78 Slot: 6
		public override void OnFulfill(SkillTriggerParameter param)
		{
			return;
		}
	}
}
