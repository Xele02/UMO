namespace XeApp.Game.RhythmGame
{
	public class RhythmGamePlayLogger
	{
		public RhythmGamePlayLog log; // 0x8

		//// RVA: 0x9AF0C0 Offset: 0x9AF0C0 VA: 0x9AF0C0
		public void Initialize(RhythmGamePlayLog log)
		{
			this.log = log;
			log.skillDataList.Clear();
			log.noteDataList.Clear();
			log.valkyrieModeData.beginMillisec = -1;
			log.valkyrieModeData.endMillisec = -1;
			log.divaModeData.beginMillisec = -1;
			log.divaModeData.endMillisec = -1;
		}

		//// RVA: 0x9AF1AC Offset: 0x9AF1AC VA: 0x9AF1AC
		public void AddSkillData(RhythmGamePlayLog.SkillData data)
		{
			log.skillDataList.Add(data);
		}

		//// RVA: 0x9AF274 Offset: 0x9AF274 VA: 0x9AF274
		public void AddNoteData(RhythmGamePlayLog.NoteData data)
		{
			log.noteDataList.Add(data);
		}

		//// RVA: 0x9AF310 Offset: 0x9AF310 VA: 0x9AF310
		public void SetValkyrieModeTime(int beginMillisec, int endMillisec)
		{
			log.valkyrieModeData.beginMillisec = beginMillisec;
			log.valkyrieModeData.endMillisec = endMillisec;
		}

		//// RVA: 0x9AF358 Offset: 0x9AF358 VA: 0x9AF358
		public void SetDivaModeTime(int beginMillisec, int endMillisec)
		{
			log.divaModeData.beginMillisec = beginMillisec;
			log.divaModeData.endMillisec = endMillisec;
		}

		//// RVA: 0x9AF3A0 Offset: 0x9AF3A0 VA: 0x9AF3A0
		//public void SetValkyrieModeType(RhythmGameMode.Type type) { }

		//// RVA: 0x9AF3C8 Offset: 0x9AF3C8 VA: 0x9AF3C8
		//public void SetDivaModeType(RhythmGameMode.Type type) { }
	}
}
