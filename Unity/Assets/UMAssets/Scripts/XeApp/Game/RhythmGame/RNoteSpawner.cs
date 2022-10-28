using XeApp.Game.Common;
using System.Collections.Generic;

namespace XeApp.Game.RhythmGame
{
	public class RNoteSpawner
	{
		private RNoteOwner owner; // 0x8
		private MusicData musicData; // 0xC
		private List<RNote> rNoteList; // 0x10

		// RVA: 0xDB3504 Offset: 0xDB3504 VA: 0xDB3504
		public RNoteSpawner(RNoteOwner owner, MusicData musicData, List<RNote> statusList)
		{
			this.owner = owner;
			this.musicData = musicData;
			rNoteList = statusList;
		}

		// RVA: 0xDB72BC Offset: 0xDB72BC VA: 0xDB72BC
		public void Update(int musicMilliSec)
		{
			for(int i = owner.checkStartNotesIndex; i < rNoteList.Count; i++)
			{
				if(rNoteList[i].passingStatus == RNote.PassingStatus.Alive)
				{
					owner.AllocNote(rNoteList[i]);
				}
				else if(rNoteList[i].passingStatus == RNote.PassingStatus.After)
				{
					owner.checkStartNotesIndex = i;
				}
				else if (rNoteList[i].passingStatus == RNote.PassingStatus.Before)
				{
					owner.checkEndNotesIndex = i;
					return;
				}
			}
		}
	}
}
