using System.Collections.Generic;
using XeApp.Game.Common;

namespace XeApp.Game.RhythmGame
{
	public class LiveSkill : LiveSkillBase
	{
		protected override List<PPGHMBNIAEC> masterSkillList { get { return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills; } set { return; } } //0xF76944 0xF76A20
		public int ownerDivaPlaceIndex { get { return parameter.ownerDivaIndex; } private set { return; } } //0xF76A24 0xF76A2C
		public int ownerSlotPlaceIndex { get { return parameter.ownerSlotIndex; } private set { return; } } //0xF76A30 0xF76A38

		//// RVA: 0xF76A3C Offset: 0xF76A3C VA: 0xF76A3C Slot: 10
		protected override void Setup()
		{
			SetupTrigger();
		}

		//// RVA: 0xF76A40 Offset: 0xF76A40 VA: 0xF76A40
		public bool CheckModeForDurationType(RhythmGameMode.Type a_mode)
		{
			for(int i = 0; i < masterSkill.EGLDFPILJLG_SkillBuffEffect.Length; i++)
			{
				if(masterSkill.EGLDFPILJLG_SkillBuffEffect[i] != 0)
				{
					if(masterSkill.FPMFEKIPFPI_DurationType[i] == (int)SkillDuration.Type.AwakenDivaModeAndNoteResult)
					{
						if (a_mode != RhythmGameMode.Type.AwakenDiva)
							return false;
					}
					else if (masterSkill.FPMFEKIPFPI_DurationType[i] == (int)SkillDuration.Type.DivaModeAndNoteResult)
					{
						if (a_mode != RhythmGameMode.Type.AwakenDiva && a_mode != RhythmGameMode.Type.Diva)
							return false;
					}
					else if (masterSkill.FPMFEKIPFPI_DurationType[i] == (int)SkillDuration.Type.ValkyrieModeAndNoteResult && a_mode != RhythmGameMode.Type.Valkyrie)
					{
						return false;
					}
				}
			}
			return true;
		}

		//// RVA: 0xF76BF0 Offset: 0xF76BF0 VA: 0xF76BF0
		public bool CheckGroupForEffectId(SkillBuffEffect.Type a_effect_id)
		{
			if(targetSkillEffectId != 0)
			{
				List<ALECCMCNIBG> l = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.KGICDMIJGDF_TargetSkillEffects;
				for(int i = 0; i < l.Count; i++)
				{
					if(l[i].PPFNGGCBJKC_Id == targetSkillEffectId)
					{
						for(int j = 0; j < l[i].LGFLNOJDHHC_SkillBuffEffects.Length; j++)
						{
							if (l[i].LGFLNOJDHHC_SkillBuffEffects[j] == (int)a_effect_id)
								return true;
						}
					}
				}
			}
			return false;
		}
	}
}
