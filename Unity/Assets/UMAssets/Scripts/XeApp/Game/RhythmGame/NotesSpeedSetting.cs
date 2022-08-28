using UnityEngine;
using System;
using System.Collections.Generic;

namespace XeApp.Game.RhythmGame
{
	public class NotesSpeedSetting : ScriptableObject
	{
		[Serializable]
		public class Item
		{
			[SerializeField]
			private int m_speed; // 0x8
			[SerializeField]
			private int m_dispTime; // 0xC

			//public int Speed { get; } 0xF7796C
			//public int DispTime { get; } 0xF77998
		}

		private const int OUT_OF_RANGE_ADJUST_MILLISEC = 25;
		[SerializeField]
		private List<Item> m_items; // 0xC

		//// RVA: 0xF6D988 Offset: 0xF6D988 VA: 0xF6D988
		public int CalcNoteDispTime(int speed)
		{
			TodoLogger.Log(0, "CalcNoteDispTime");
			return -1;
		}

		//// RVA: 0xF6DD30 Offset: 0xF6DD30 VA: 0xF6DD30
		//public bool CheckOutOfRange(int speed) { }

		//// RVA: 0xF77974 Offset: 0xF77974 VA: 0xF77974
		//private int CalcOutOfRangeDispMillisec(NotesSpeedSetting.Item baseItem, int speed) { }
	}
}
