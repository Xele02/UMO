using System;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameScoreEvent
	{
		public bool active = false; // 0x8
		public int millisec = -1; // 0xC
		public Action onFireEvent; // 0x10


		// RVA: 0xBFF00C Offset: 0xBFF00C VA: 0xBFF00C
		public RhythmGameScoreEvent()
		{
			active = true;
			millisec = -1;
			onFireEvent = null;
		}

		// RVA: 0xBFF044 Offset: 0xBFF044 VA: 0xBFF044
		public void Update(int musicMillisec)
		{
			if(active && millisec > -1)
			{
				if (musicMillisec < millisec)
					return;
				if (onFireEvent != null)
					onFireEvent();
				active = false;
			}
		}
	}
}
