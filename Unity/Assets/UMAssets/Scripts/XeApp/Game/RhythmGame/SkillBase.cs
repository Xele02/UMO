using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.RhythmGame
{
	public struct SkillTriggerParameter
	{
		public float musicTime; // 0x0
		public float currentLifeRate; // 0x4
		public float currentCombo; // 0x8
		public int currentScore; // 0xC
		public int valkyeriModeEndTimeMs; // 0x10
		public RhythmGameMode.Type modeType; // 0x14
		public bool touchedSkill; // 0x18
		public bool touchedCenterLiveSkillNote; // 0x19
	}

	public abstract class SkillBase
	{
		public struct Param
		{
			public int id; // 0x0
			public int level; // 0x4
			public int ownerDivaIndex; // 0x8
			public int ownerSlotIndex; // 0xC
			public int skillIndex; // 0x10
			public bool centerPlate; // 0x14
		}

		protected Param parameter; // 0x8
		protected List<SkillTriggerBase> triggers = new List<SkillTriggerBase>(); // 0x20

		public int skillId { get { return parameter.id; } private set { return; } } //0x155252C 0x1552534
		public int skillLevel { get { return parameter.level; } private set { return; } } //0x1552538 0x1552540
		public int ownerDivaIndex { get { return parameter.ownerDivaIndex; } set { return; } } //0x1552544 0x155254C
		public int ownerSlotIndex { get { return parameter.ownerSlotIndex; } set { return; } } //0x1552550 0x1552558
		protected int skillIndex { get { return parameter.id - 1; } set { return; } } //0x155255C 0x1552568
		protected int skillLevelIndex { get { return parameter.level - 1; } set { return; } } //0x155256C 0x1552578
		public bool centerPlate { get { return parameter.centerPlate; } set { return; } } //0x155257C 0x1552584
		//public SkillTrigger.Type triggerType { get; } 0x1552588
		public abstract SkillBuffEffect.Type buffEffectType { get; }//  Slot: 4
		public abstract int buffEffectValue { get; } // Slot: 5
		public abstract SkillDuration.Type durationType { get; } // Slot: 6
		public abstract int durationValue { get; } //Slot: 7
		public abstract int lineTarget { get; }  //Slot: 8
		public int SkillIndex { get { return parameter.skillIndex; } } //0x1552618
		public virtual List<SkillBase> listEffectValueUp { get; private set; } // 0x24

		//// RVA: 0x1552630 Offset: 0x1552630 VA: 0x1552630
		public int CalcEffectValueUp(int a_base_value)
		{
			if(listEffectValueUp != null)
			{
				int valBase = a_base_value;
				for (int i = 0; i < listEffectValueUp.Count; i++)
				{
					a_base_value += (int)(listEffectValueUp[i].buffEffectValue / 100.0f * valBase);
				}
			}
			return a_base_value;
		}

		//// RVA: 0x1552794 Offset: 0x1552794 VA: 0x1552794
		public void Initialize(Param param)
		{
			parameter = param;
			listEffectValueUp = new List<SkillBase>();
			Setup();
		}

		//// RVA: 0x1552860 Offset: 0x1552860 VA: 0x1552860 Slot: 10
		protected virtual void Setup()
		{
			return;
		}

		//// RVA: 0x1552864 Offset: 0x1552864 VA: 0x1552864
		public bool IsFulfill(SkillTriggerParameter param)
		{
			for(int i = 0; i < triggers.Count; i++)
			{
				if (!triggers[i].IsFulfill(param))
					return false;
			}
			OnFulfill(param);
			return true;
		}

		//// RVA: 0x15529E0 Offset: 0x15529E0 VA: 0x15529E0 Slot: 11
		public virtual void OnFulfill(SkillTriggerParameter param)
		{
			for(int i = 0; i < triggers.Count; i++)
			{
				triggers[i].OnFulfill(param);
			}
		}
	}
}
