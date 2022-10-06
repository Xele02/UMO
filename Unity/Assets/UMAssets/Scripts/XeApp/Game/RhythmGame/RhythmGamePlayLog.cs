using System.Collections.Generic;
using XeApp.Game.Common;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGamePlayLog
	{
		public struct SkillData
		{
			public bool isActive; // 0x0
			public int skillId; // 0x4
			public int skillLevel; // 0x8
			public SkillBuffEffect.Type skillType; // 0xC
			public int millisec; // 0x10
			public int sceneId; // 0x14
		}

		public struct NoteData
		{
			public RhythmGameConsts.NoteResult result; // 0x0
			public int millisec; // 0x4
		}

		public struct ModeData
		{
			public RhythmGameMode.Type type; // 0x0
			public int beginMillisec; // 0x4
			public int endMillisec; // 0x8
		}

		public List<SkillData> skillDataList = new List<SkillData>(16); // 0x8
		public List<NoteData> noteDataList = new List<NoteData>(2048); // 0xC
		public ModeData valkyrieModeData; // 0x10
		public ModeData divaModeData; // 0x1C
		public bool isImpossibleValkyrieMode; // 0x28
		public bool isImpossibleDivaMode; // 0x29
	}
}
