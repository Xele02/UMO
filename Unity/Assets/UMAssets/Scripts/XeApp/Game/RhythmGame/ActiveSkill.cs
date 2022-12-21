using System.Collections.Generic;
using XeApp.Game.Common;

namespace XeApp.Game.RhythmGame
{
	public class ActiveSkill : SkillBase
	{
		public int m_activated_max = 1; // 0x28
		public int m_activated_cnt; // 0x2C

		protected List<CDNKOFIELMK> masterSkillList { get { return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PABCHCAAEAA_ActiveSkills; } set { return; } } //0xF67D9C 0xF67E78
		protected CDNKOFIELMK masterSkill { get { return masterSkillList[skillIndex]; } set { return; } } //0xF67E7C 0xF67F0C
		public override SkillBuffEffect.Type buffEffectType { get { return (SkillBuffEffect.Type)masterSkill.EGLDFPILJLG_BuffEffectType[parameter.skillIndex]; } } //0xF67F10 Slot: 4
		public override int buffEffectValue { get { return masterSkill.NKGHBKFMFCI_BuffValueByIndexAndLevel[skillIndex, skillLevelIndex]; } } //0xF67F74 Slot: 5
		public override SkillDuration.Type durationType { get { return (SkillDuration.Type)masterSkill.FPMFEKIPFPI_DurationType[skillIndex]; } } //0xF68010 Slot: 6
		public override int durationValue { get { return masterSkill.PHAGNOHBMCM_DurationByIndexAndLevel[skillIndex, skillLevelIndex]; } } //0xF68074 Slot: 7
		public override int lineTarget { get { return masterSkill.JGDJACOPHJP_LineTarget; } } //0xF68110 Slot: 8

		//// RVA: 0xF68138 Offset: 0xF68138 VA: 0xF68138 Slot: 10
		protected override void Setup()
		{
			SetupTrigger();
			m_activated_cnt = 0;
			m_activated_max = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PABCHCAAEAA_ActiveSkills[skillIndex].NLCJNOBOBAH_MaxActivation;
		}

		//// RVA: 0xF683EC Offset: 0xF683EC VA: 0xF683EC Slot: 11
		public override void OnFulfill(SkillTriggerParameter param)
		{
			base.OnFulfill(param);
			m_activated_cnt++;
		}

		//// RVA: 0xF68434 Offset: 0xF68434 VA: 0xF68434
		public bool IsRestart()
		{
			return m_activated_cnt < m_activated_max;
		}

		//// RVA: 0xF6844C Offset: 0xF6844C VA: 0xF6844C
		public void Restart()
		{
			SetupTrigger();
		}

		//// RVA: 0xF68284 Offset: 0xF68284 VA: 0xF68284
		private void SetupTrigger()
		{
			triggers.Clear();
			SkillLimitcountTrigger tr = new SkillLimitcountTrigger();
			tr.Initialize(1);
			triggers.Add(tr);
			SkillTouchTrigger tr2 = new SkillTouchTrigger();
			tr2.Initialize(0);
			triggers.Add(tr2);
		}
	}
}
