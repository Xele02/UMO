using System;
using System.Collections.Generic;
using XeApp.Game.Common;

namespace XeApp.Game.RhythmGame
{
	public class SkillList : List<SkillBase>
	{
	}

	public class SkillOwner
	{
		public Action<LiveSkill> onFullfillLiveSkill; // 0x10
		public Action<EnemySkill> onFullfillEnemySkill; // 0x14
		public Action<ActiveSkill> onFullfillActiveSkill; // 0x18

		public RhythmGameStatus status { get; set; } // 0x8
		public SkillList skillList { get; private set; } // 0xC
		public ActiveSkill activeSkill { get; private set; } // 0x1C

		// RVA: 0x1552F0C Offset: 0x1552F0C VA: 0x1552F0C
		public SkillOwner()
		{
			skillList = new SkillList();
		}

		//// RVA: 0x1552F84 Offset: 0x1552F84 VA: 0x1552F84
		public void CreateList()
		{
			skillList.Clear();
			for(int i = 0; i < 3; i++)
			{
				for(int j = 0; j < Database.Instance.gameSetup.teamInfo.divaList[i].liveSkillIdList.Length; j++)
				{
					int skillId = Database.Instance.gameSetup.teamInfo.divaList[i].liveSkillIdList[j];
					if (skillId > 0)
					{
						PPGHMBNIAEC skillInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[skillId - 1];
						for(int k = 0; k < skillInfo.EGLDFPILJLG.Length; k++)
						{
							if(skillInfo.EGLDFPILJLG[k] != 0)
							{
								LiveSkill sk = new LiveSkill();
								sk.Initialize(new SkillBase.Param() {
									id = skillId,
									level = Database.Instance.gameSetup.teamInfo.divaList[i].liveSkillLevelList[j],
									ownerDivaIndex = i,
									ownerSlotIndex = j,
									skillIndex = k,
									centerPlate = i == 0 && j == 0
								});
								skillList.Add(sk);
							}
						}
					}
				}
			}
			if(Database.Instance.gameSetup.teamInfo.divaList[0].activeSkillId > 0)
			{
				CDNKOFIELMK skillInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PABCHCAAEAA_ActiveSkills[Database.Instance.gameSetup.teamInfo.divaList[0].activeSkillId - 1];
				for (int k = 0; k < skillInfo.EGLDFPILJLG.Length; k++)
				{
					if (skillInfo.EGLDFPILJLG[k] != 0)
					{
						ActiveSkill sk = new ActiveSkill();
						sk.Initialize(new SkillBase.Param()
						{
							id = Database.Instance.gameSetup.teamInfo.divaList[0].activeSkillId,
							level = Database.Instance.gameSetup.teamInfo.divaList[0].activeSkillLevel,
							ownerDivaIndex = 0,
							ownerSlotIndex = 0,
							skillIndex = k,
							centerPlate = false
						});
						skillList.Add(sk);
					}
				}
			}
			if(Database.Instance.gameSetup.musicInfo.enemyInfo != null)
			{
				if(Database.Instance.gameSetup.musicInfo.enemyInfo.EDLACELKJIK_LiveSkill > 0)
				{
					EnemySkill sk = new EnemySkill();
					sk.Initialize(new SkillBase.Param()
					{
						id = Database.Instance.gameSetup.musicInfo.enemyInfo.EDLACELKJIK_LiveSkill,
						level = 1,
						ownerDivaIndex = -1,
						ownerSlotIndex = -1,
						skillIndex = 0,
						centerPlate = false
					});
					skillList.Add(sk);
				}
			}
		}

		//// RVA: 0x1553A0C Offset: 0x1553A0C VA: 0x1553A0C
		//public void CheckTrigger(SkillTriggerParameter triggerParam, BuffEffectOwner buffOwner) { }

		//// RVA: 0x15540E0 Offset: 0x15540E0 VA: 0x15540E0
		public void CheckFirstTrigger()
		{
			for(int i = 0; i < skillList.Count; i++)
			{
				if(skillList[i] != null)
				{
					EnemySkill es = skillList[i] as EnemySkill;
					if(es != null)
					{
						if(es.masterSkill.CPNAGMFCIJK_TriggerType == (int)SkillTrigger.Type.FirstCheck)
						{
							if(es.IsFulfill(new SkillTriggerParameter()))
							{
								if (onFullfillEnemySkill != null)
									onFullfillEnemySkill(es);
							}
						}
					}
				}
			}
		}

		//// RVA: 0x1554270 Offset: 0x1554270 VA: 0x1554270
		//public void LiveSkillEffectValueUp(SkillBase a_exec_skill) { }

		//// RVA: 0x1553D24 Offset: 0x1553D24 VA: 0x1553D24
		//private void CreateBuffEffect(int index, SkillTriggerParameter triggerParam, BuffEffectOwner buffOwner) { }

		//// RVA: 0x15544D4 Offset: 0x15544D4 VA: 0x15544D4
		//private int CalcBuffEffectValue(SkillBase a_skill) { }
	}
}
