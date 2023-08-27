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

			public int Speed { get { return m_speed; } } //0xF7796C
			public int DispTime { get { return m_dispTime; } } //0xF77998
		}

		private const int OUT_OF_RANGE_ADJUST_MILLISEC = 25;
		[SerializeField]
		private List<Item> m_items; // 0xC

		//// RVA: 0xF6D988 Offset: 0xF6D988 VA: 0xF6D988
		public int CalcNoteDispTime(int speed)
		{
			if(m_items[0].Speed <= speed)
			{
				if(m_items[m_items.Count - 1].Speed >= speed)
				{
					int idx = m_items.FindIndex(0, (NotesSpeedSetting.Item item) => {
						// 0xF779A8
						return item.Speed <= speed;
					});
					int idx2 = m_items.FindIndex(idx + 1, (NotesSpeedSetting.Item item) => {
						// 0xF779E0
						return speed <= item.Speed;
					});
					return Mathf.RoundToInt(Mathf.Lerp(m_items[idx].DispTime, m_items[idx2].DispTime, (speed - m_items[idx].Speed) * 1.0f / (m_items[idx2].Speed - m_items[idx].Speed)));
				}
				return m_items[m_items.Count - 1].DispTime;
			}
			return m_items[0].DispTime;
		}

		//// RVA: 0xF6DD30 Offset: 0xF6DD30 VA: 0xF6DD30
		//public bool CheckOutOfRange(int speed) { }

		//// RVA: 0xF77974 Offset: 0xF77974 VA: 0xF77974
		//private int CalcOutOfRangeDispMillisec(NotesSpeedSetting.Item baseItem, int speed) { }
	}
}
