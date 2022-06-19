using System.Collections.Generic;

namespace XeApp.Game.AR
{
	public class ARMarkerMasterData : ARMasterData
	{
		public class Stamp
		{
			public string stampId = ""; // 0x8
			public bool isHave; // 0xC
		}

		public class CueSheetData
		{
			public int no; // 0x8
			public int enable; // 0xC
			public int markerNo; // 0x10
			public string cueSheetId = ""; // 0x14
			public long soundStart; // 0x18
			public long soundEnd; // 0x20
		}

		public class Data
		{
			// public int no; // 0x8
			// public int enable; // 0xC
			// public string markerId = ""; // 0x10
			// public string eventId = ""; // 0x14
			// public ARDivaPatternId pattern = -1; // 0x18
			// public int divaId; // 0x1C
			// public int costumeId; // 0x20
			// public Vector3 position = Vector3.zero; // 0x24
			// public Vector3 rotation = Vector3.zero; // 0x30
			// public float imageWidth; // 0x3C
			// public float divaHeight; // 0x40
			// public int stampId; // 0x44
			// public float angleLimit; // 0x48
			// public long markerStart; // 0x50
			// public long markerEnd; // 0x58
			// public int emblemId; // 0x60
			// public int trackingType; // 0x64
			// public ARDivaMotionId motionId; // 0x68
			// public List<ARMarkerMasterData.CueSheetData> cueSheetList; // 0x6C
			// public bool haveFlag; // 0x70

			// public string cueSheetId { get; } 0xBBA3D4
			// public int wavId { get; } 0xBBA588
		}

		private static ARMarkerMasterData sm_instance; // 0x0
		public List<ARMarkerMasterData.Data> m_markerList = new List<ARMarkerMasterData.Data>(); // 0x18

		public static ARMarkerMasterData Instance { get {
			if(sm_instance == null)
			{
				sm_instance = new ARMarkerMasterData();
				sm_instance.name = "ar_marker";
			}
			return sm_instance;
		} } // 0xBB8CAC

		// // RVA: 0xBB8E98 Offset: 0xBB8E98 VA: 0xBB8E98
		// public static void Release() { }

		// // RVA: 0xBB8F28 Offset: 0xBB8F28 VA: 0xBB8F28 Slot: 4
		protected override void Initialize(byte[] bytes)
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xBB9C50 Offset: 0xBB9C50 VA: 0xBB9C50
		// public List<ARMarkerMasterData.Data> GetMarkerList(bool isAll = False) { }

		// // RVA: 0xBB9E6C Offset: 0xBB9E6C VA: 0xBB9E6C
		// public List<ARMarkerMasterData.Data> GetStartingMarkerList() { }

		// // RVA: 0xBBA064 Offset: 0xBBA064 VA: 0xBBA064
		// public List<ARMarkerMasterData.Data> GetEventMarkerList(string eventId, bool isAll = False) { }

		// // RVA: 0xBBA1AC Offset: 0xBBA1AC VA: 0xBBA1AC
		// public List<ARMarkerMasterData.Data> GetEventStartingMarkerList(string eventId) { }

	}
}
