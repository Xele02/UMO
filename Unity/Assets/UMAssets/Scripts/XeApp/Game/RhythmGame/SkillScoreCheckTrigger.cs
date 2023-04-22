
namespace XeApp.Game.RhythmGame
{
	public class SkillScoreCheckTrigger : SkillTriggerBase
	{
		private int m_now_score; // 0xC
		private int m_cmp_score; // 0x10

		// RVA: 0x15549D0 Offset: 0x15549D0 VA: 0x15549D0 Slot: 4
		public override void Initialize(int value)
		{
			m_cmp_score = value * 10000;
		}

		//// RVA: 0x15549E0 Offset: 0x15549E0 VA: 0x15549E0 Slot: 5
		public override bool IsFulfill(SkillTriggerParameter param)
		{
			return m_cmp_score <= param.currentScore - m_now_score;
		}

		//// RVA: 0x1554A00 Offset: 0x1554A00 VA: 0x1554A00 Slot: 6
		public override void OnFulfill(SkillTriggerParameter param)
		{
			m_now_score += m_cmp_score;
		}
	}
}
