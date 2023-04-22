
namespace XeApp.Game.RhythmGame
{
	public class SkillTimebombTrigger : SkillTriggerBase
	{
		private float time; // 0xC
		private float startTime; // 0x10
		private float currentTime; // 0x14

		// RVA: 0x1552BB4 Offset: 0x1552BB4 VA: 0x1552BB4 Slot: 4
		public override void Initialize(int value)
		{
			startTime = 0;
			time = value;
		}

		// RVA: 0x1552C54 Offset: 0x1552C54 VA: 0x1552C54 Slot: 5
		public override bool IsFulfill(SkillTriggerParameter param)
		{
			if(param.currentLifeRate > 0)
			{
				currentTime = param.musicTime;
				return time <= param.musicTime - startTime;
			}
			return false;
		}

		//// RVA: 0x1552C9C Offset: 0x1552C9C VA: 0x1552C9C Slot: 6
		public override void OnFulfill(SkillTriggerParameter param)
		{
			startTime = currentTime;
		}

		//// RVA: 0x1552C48 Offset: 0x1552C48 VA: 0x1552C48
		//public void ResetTime(float a_time) { }
	}
}
