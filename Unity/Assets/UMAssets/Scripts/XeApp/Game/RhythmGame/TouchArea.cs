using System;
using UnityEngine;
using UnityEngine.Events;

namespace XeApp.Game.RhythmGame
{
	[Serializable]
	public struct TouchArea
	{
		public Collider2D collider; // 0x0
		public UnityEvent pusheEvent; // 0x4
		public UnityEvent exitEvent; // 0x8
		public UnityEvent selectedEvent; // 0xC
		public int selectedFingerId; // 0x10
		public bool isSelected; // 0x14
	}
}
