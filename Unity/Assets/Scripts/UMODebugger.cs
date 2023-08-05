
using Sakasho.JSON;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using XeApp.Game.Common;
using XeApp.Game.RhythmGame;
using XeSys;

public class UMODebugger : SingletonMonoBehaviour<UMODebugger>
{
	public class MusicRecordInfo
	{
		public class TouchInfo
		{
			public float time;
			public InputManager.KeyTouchInfoRecord.KeyType key;
			public TouchPhase phase;
		}

		public class NoteInfo
		{
			public float time;
			public int trackId;
			public RhythmGameConsts.NoteResult result;
		}

		public int freeMusicId;
		public Difficulty.Type difficulty;
		public bool isLine6;

		public List<TouchInfo> inputList = new List<TouchInfo>();
		public List<NoteInfo> notesList = new List<NoteInfo>();

		public float currentTime = 0;
	}
	MusicRecordInfo musicRecordInfo;
	MusicRecordInfo musicRecordInfoSaved;

	public void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	public void StartSong()
	{
		GameSetupData gameSetup = Database.Instance.gameSetup;
		musicRecordInfo = new MusicRecordInfo();
		musicRecordInfo.freeMusicId = gameSetup.musicInfo.freeMusicId;
		musicRecordInfo.difficulty = gameSetup.musicInfo.difficultyType;
		musicRecordInfo.isLine6 = gameSetup.musicInfo.IsLine6Mode;
	}

	[MenuItem("UMO/Create song notes debug data")]
	public static void CreateNoteDebugData()
	{
		MusicRecordInfo record = Instance.musicRecordInfo;
		if (record == null)
			record = Instance.musicRecordInfoSaved;
		if(record != null)
		{
			Hashtable h = new Hashtable();
			h["musicId"] = record.freeMusicId;
			h["diff"] = record.difficulty.ToString();
			h["lane6"] = record.isLine6;
			ArrayList l = new ArrayList();
			for(int i = 0; i < record.notesList.Count; i++)
			{
				Hashtable h2 = new Hashtable();
				h2["time"] = record.notesList[i].time;
				h2["trackId"] = record.notesList[i].trackId;
				h2["result"] = record.notesList[i].result.ToString();
				l.Add(h2);
			}
			h["notes"] = l;
			l = new ArrayList();
			for (int i = 0; i < record.inputList.Count; i++)
			{
				Hashtable h2 = new Hashtable();
				h2["time"] = record.inputList[i].time;
				h2["key"] = record.inputList[i].key.ToString();
				h2["phase"] = record.inputList[i].phase.ToString();
				l.Add(h2);
			}
			h["inputs"] = l;
			string newFile = Path.GetTempPath() + "UMOInputDump.txt";
			File.WriteAllText(newFile, MiniJSON.jsonEncode(h));
			Debug.LogError("Debug file saved in "+ newFile);
		}
	}

	public void EndSong()
	{
		// Generate log data;
		musicRecordInfoSaved = musicRecordInfo;
		musicRecordInfo = null;
	}

	public void AddInputInfo(InputManager.KeyTouchInfoRecord record, TouchPhase phase)
	{
		if(musicRecordInfo != null)
		{
			if(phase == TouchPhase.Began || phase == TouchPhase.Ended)
			{
				musicRecordInfo.inputList.Add(new MusicRecordInfo.TouchInfo() { key = record.keyType, phase = phase, time = musicRecordInfo.currentTime });
			}
		}
	}

	public void UpdateSongTime(float time)
	{
		if(musicRecordInfo != null)
		{
			musicRecordInfo.currentTime = time;
		}
	}

	public void AddNoteInfo(RNote note, RhythmGameConsts.NoteResult result)
	{
		if(musicRecordInfo != null)
		{
			musicRecordInfo.notesList.Add(new MusicRecordInfo.NoteInfo() { time = musicRecordInfo.currentTime, trackId = note.noteInfo.trackID, result = result });
		}
	}
}
