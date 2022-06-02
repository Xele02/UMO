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
			private int m_speed;
			[SerializeField]
			private int m_dispTime;
		}

		[SerializeField]
		private List<NotesSpeedSetting.Item> m_items;
	}
}
