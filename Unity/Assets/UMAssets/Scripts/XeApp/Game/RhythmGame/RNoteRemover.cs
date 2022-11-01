using XeApp.Game.Common;
using System.Collections.Generic;

namespace XeApp.Game.RhythmGame
{
	public class RNoteRemover
	{
		public delegate void RemoveDelegate(MusicScoreData.InputNoteInfo noteInfo);

		private RNoteOwner owner; // 0x8
		private MusicData musicData; // 0xC
		private List<RNote> rNoteList; // 0x10
		private List<RNoteSingle> activeSingleList = new List<RNoteSingle>(30); // 0x14
		private List<RNoteLong> activeLongList = new List<RNoteLong>(15); // 0x18
		private List<RNoteSync> activeSyncList = new List<RNoteSync>(15); // 0x1C
		private List<RNoteSlide> activeSlideList = new List<RNoteSlide>(15); // 0x20
		public RemoveDelegate removeDelegate = (MusicScoreData.InputNoteInfo noteInfo) => {
			//0xDBD308
			return;
		}; // 0x24
		private List<RNoteObject> removeObjects = new List<RNoteObject>(32); // 0x28

		// RVA: 0xDB3534 Offset: 0xDB3534 VA: 0xDB3534
		public RNoteRemover(RNoteOwner owner, MusicData musicData, List<RNote> statusList)
		{
			this.owner = owner;
			this.musicData = musicData;
			rNoteList = statusList;
		}

		// RVA: 0xDB7458 Offset: 0xDB7458 VA: 0xDB7458
		public void Update(int musicMilliSec)
		{
			removeObjects.Clear();
			var r = owner.spawnRNoteObjects.First;
			for(int i = 0; i < owner.spawnRNoteObjects.Count; i++)
			{
				if(r.Value.isInScreen)
				{
					if(r.Value.rNote.passingStatus != RNote.PassingStatus.Alive)
					{
						removeObjects.Add(r.Value);
					}
				}
				r = r.Next;
			}
			for(int i = 0; i < removeObjects.Count; i++)
			{
				owner.FreeNote(removeObjects[i]);
			}
			owner.singlePool.MakeUsingList(ref activeSingleList);
			for(int i = 0; i < activeSingleList.Count; i++)
			{
				activeSingleList[i].CheckFree();
			}
			owner.longPool.MakeUsingList(ref activeLongList);
			for(int i = 0 ; i < activeLongList.Count; i++)
			{
				activeLongList[i].CheckFree();
			}
			owner.syncPool.MakeUsingList(ref activeSyncList);
			for(int i = 0 ; i < activeSyncList.Count; i++)
			{
				activeSyncList[i].CheckFree();
			}
			owner.slidePool.MakeUsingList(ref activeSlideList);
			for(int i = 0 ; i < activeSlideList.Count; i++)
			{
				activeSlideList[i].CheckFree();
			}
		}
	}
}
