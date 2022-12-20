
using XeApp.Game.Common;

namespace XeApp.Game.RhythmGame
{
	public class SkillTriggerBase // TypeDefIndex: 18279
	{
		public SkillTrigger.Type m_type; // 0x8

		//// RVA: 0x1554A54 Offset: 0x1554A54 VA: 0x1554A54 Slot: 4
		public virtual void Initialize(int value)
		{
			return;
		}

		//// RVA: 0x1554A58 Offset: 0x1554A58 VA: 0x1554A58 Slot: 5
		public virtual bool IsFulfill(SkillTriggerParameter param)
		{
			return false;
		}

		//// RVA: 0x1554A60 Offset: 0x1554A60 VA: 0x1554A60 Slot: 6
		public virtual void OnFulfill(SkillTriggerParameter param)
		{
			return;
		}
	}
}
