using System;
using XeApp.Game.Common;

namespace XeApp.Game.RhythmGame
{
	public struct BuffEffectInitialParameter
	{
		public SkillType.Type skillType;
		public SkillBuffEffect.Type effectType;
		public int effectValue;
		public SkillDuration.Type durationType;
		public int durationValue;
		public int valkyeriModeEndTimeMs;
		public int lineTarget;
		public int ownerDivaPlaceIndex;
		public float musicTime;
		public bool isTopPriorityDisplay;
	}
}
