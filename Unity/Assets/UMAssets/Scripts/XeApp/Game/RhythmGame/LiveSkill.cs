using System.Collections.Generic;

namespace XeApp.Game.RhythmGame
{
	public class LiveSkill : LiveSkillBase
	{
		protected override List<PPGHMBNIAEC> masterSkillList { get { return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills; } set { return; } } //0xF76944 0xF76A20
		//public int ownerDivaPlaceIndex { get; private set; } 0xF76A24 0xF76A2C
		//public int ownerSlotPlaceIndex { get; private set; } 0xF76A30 0xF76A38

		//// RVA: 0xF76A3C Offset: 0xF76A3C VA: 0xF76A3C Slot: 10
		protected override void Setup()
		{
			SetupTrigger();
		}

		//// RVA: 0xF76A40 Offset: 0xF76A40 VA: 0xF76A40
		//public bool CheckModeForDurationType(RhythmGameMode.Type a_mode) { }

		//// RVA: 0xF76BF0 Offset: 0xF76BF0 VA: 0xF76BF0
		//public bool CheckGroupForEffectId(SkillBuffEffect.Type a_effect_id) { }
	}
}
