using System.Collections.Generic;
using XeApp.Game.Common;

namespace XeApp.Game.RhythmGame
{
	public class LiveSkillBase : SkillBase
	{
		protected virtual List<PPGHMBNIAEC> masterSkillList { get; set; } // 0x28
		public PPGHMBNIAEC masterSkill { get {
				return masterSkillList[skillIndex];
			} set { return; } } //0xF76B50 0xF76E64
		public int skillType { get { return masterSkill.FLJHGGKIOJH_SkillType; } } //0xF76E68
		public override SkillBuffEffect.Type buffEffectType { get { return (SkillBuffEffect.Type)masterSkill.EGLDFPILJLG_SkillBuffEffect[SkillIndex]; } } //0xF76E90  Slot: 4
		public override int buffEffectValue { get { return CalcEffectValueUp(baseBuffEffectValue); } } //0xF76EF4  Slot: 5
		public int baseBuffEffectValue { get { return masterSkill.NKGHBKFMFCI_BuffValueByIndexAndLevel[skillLevelIndex, SkillIndex]; } } //0xF76F18 
		public override SkillDuration.Type durationType { get { return (SkillDuration.Type)masterSkill.FPMFEKIPFPI_DurationType[SkillIndex]; } } //0xF76FB4 Slot: 6
		public override int durationValue { get { return masterSkill.PHAGNOHBMCM_DurationByIndexAndLevel[skillLevelIndex, SkillIndex]; } } //0xF77018 Slot: 7
		public override int lineTarget { get { return masterSkill.JGDJACOPHJP_LineTarget; } } //0xF770B4 Slot: 8
		public int targetSkillType { get { return masterSkill.DPGDCJFBFGK_TargetSkillType; } } //0xF770DC
		public int targetSkillEffectId { get { return masterSkill.POMLAENHCHA_TargetSkillEffectId; } } //0xF76E1C
		public int buffEffectValue_SkillCutin { get; set; } = -1; // 0x2C

		//// RVA: 0xF73DE0 Offset: 0xF73DE0 VA: 0xF73DE0
		protected void SetupTrigger()
		{
			triggers.Clear();
			SkillLimitcountTrigger t = new SkillLimitcountTrigger();
			if (masterSkill.CPNAGMFCIJK_TriggerType == (int)SkillTrigger.Type.EveryScore && !centerPlate)
			{
				t.Initialize(masterSkill.ELEPHBOKIGK_LimitCount[0]);
				triggers.Add(t);
			}
			else if (masterSkill.CPNAGMFCIJK_TriggerType != (int)SkillTrigger.Type.EveryTime || centerPlate)
			{
				t.Initialize(1);
				triggers.Add(t);
			}
			SkillTriggerBase tr = null;
			if (centerPlate)
			{
				tr = new SkillCenterLiveSkillNoteTouchTrigger();
			}
			else
			{
				switch (masterSkill.CPNAGMFCIJK_TriggerType)
				{
					case (int)SkillTrigger.Type.Life:
						tr = new SkillLifeTrigger();
						break;
					case (int)SkillTrigger.Type.Combo:
						tr = new SkillComboTrigger();
						break;
					case (int)SkillTrigger.Type.ValkyrieMode:
						tr = new SkillValkyrieModeTrigger();
						break;
					case (int)SkillTrigger.Type.DivaMode:
						tr = new SkillDivaModeTrigger();
						break;
					case (int)SkillTrigger.Type.AwakenDivaMode:
						tr = new SkillAwakenDivaModeTrigger();
						break;
					case (int)SkillTrigger.Type.Timebomb:
					case (int)SkillTrigger.Type.EveryTime:
						tr = new SkillTimebombTrigger();
						break;
					case (int)SkillTrigger.Type.FirstCheck:
						tr = new SkillFirstCheckTrigger();
						break;
					case (int)SkillTrigger.Type.EveryScore:
						tr = new SkillScoreCheckTrigger();
						break;
					default:
						return;
				}
			}
			if (tr != null)
			{
				tr.Initialize(masterSkill.LFGFBMJNBKN_ConfigValue[skillLevelIndex]);
				tr.m_type = (SkillTrigger.Type)masterSkill.CPNAGMFCIJK_TriggerType;
				triggers.Add(tr);
			}
		}
	}
}
