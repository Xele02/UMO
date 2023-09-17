using XeApp.Game.Common;

namespace XeApp.Game.RhythmGame
{
	public class BuffEffect
	{
		private BuffEffectInitialParameter initialParameter; // 0x8
		public BuffEffectPoisonEvent OnPerSecondPoisonEffect; // 0x34
		private int perSecondCount; // 0x38

		public SkillBuffEffect.Type effectType { get { return initialParameter.effectType; } private set { return; } } //0xF68F84 0xF68F8C
		public SkillType.Type skillType { get { return initialParameter.skillType; } } //0xF68F90
		public int effectValue { get { return initialParameter.effectValue; } private set { return; } } //0xF68F98 0xF68FA0
		public int lineTarget { get { return initialParameter.lineTarget; } private set { return; } } //0xF68FA4 0xF68FAC
		public int ownerDivaPlaceIndex { get { return initialParameter.ownerDivaPlaceIndex; } private set { return; } } //0xF68FB0 0xF68FB8
		public bool isTopPriorityDisplay { get { return initialParameter.isTopPriorityDisplay; } private set { return; } } //0xF68FBC 0xF68FC4
		public BuffEffectDuration duration { get; private set; } // 0x30

		// RVA: 0xF68FD8 Offset: 0xF68FD8 VA: 0xF68FD8
		public BuffEffect(BuffEffectInitialParameter initialParameter)
		{
			this.initialParameter = initialParameter;
			switch(initialParameter.durationType)
			{
				case Common.SkillDuration.Type.Time:
					duration = new BuffEffectTimeDuration();
					break;
				case Common.SkillDuration.Type.Permanency:
					duration = new BuffEffectPermanencyDurarion();
					break;
				case Common.SkillDuration.Type.ValkyrieModeEnd:
					duration = new BuffEffectTimeDurationAbsMs();
					break;
				case Common.SkillDuration.Type.ValkyrieModeAndNoteResult:
					duration = new BuffEffectDurarion_NoteResult_ValkyrieMode();
					break;
				case Common.SkillDuration.Type.DivaModeAndNoteResult:
					duration = new BuffEffectDurarion_NoteResult_DivaMode();
					break;
				case Common.SkillDuration.Type.AwakenDivaModeAndNoteResult:
					duration = new BuffEffectDurarion_NoteResult_AwakenDivaMode();
					break;
				default:
					break;
			}
			duration.Initialize(new BuffDurationInitialParameter() { durationType = initialParameter.durationType, durationValue = initialParameter.durationValue, musicTime = initialParameter.musicTime });
			perSecondCount = 0;
		}

		//// RVA: 0xF691BC Offset: 0xF691BC VA: 0xF691BC
		public void OnUpdate(BuffDurationCheckParameter checkParameter)
		{
			if(initialParameter.effectType == SkillBuffEffect.Type.Poison)
			{
				if (checkParameter.musicTime - initialParameter.musicTime <= perSecondCount)
					return;
				OnPerSecondPoisonEffect.Invoke(this);
				perSecondCount = perSecondCount + 1;
			}
		}

		//// RVA: 0xF69274 Offset: 0xF69274 VA: 0xF69274
		public bool InDuration(BuffDurationCheckParameter checkParameter)
		{
			if(duration != null)
			{
				return duration.InDuration(checkParameter);
			}
			return false;
		}

		//// RVA: 0xF692BC Offset: 0xF692BC VA: 0xF692BC
		public bool IsValue(RhythmGameConsts.NoteResult a_result)
		{
			if(duration != null)
			{
				return duration.IsValue(a_result);
			}
			return true;
		}
	}
}
