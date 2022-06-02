using System;
using UnityEngine;
using UnityEngine.Events;

namespace XeApp.Game.RhythmGame
{
	[Serializable]
	public struct TouchArea
	{
		public Collider2D collider;
		public UnityEvent pusheEvent;
		public UnityEvent exitEvent;
		public UnityEvent selectedEvent;
	}
}
