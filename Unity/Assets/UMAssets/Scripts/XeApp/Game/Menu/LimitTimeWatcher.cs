namespace XeApp.Game.Menu
{
	public class LimitTimeWatcher
	{
		public delegate void OnEndCallback(long currentTime);
		public delegate void OnElapsedCallback(long currentTime, long limitTime, long remainTime);
		private long m_limitTime; // 0x8
		private long m_limitTimeMirror; // 0x10
		private long m_savedCurrentTime; // 0x18
		private bool m_isForceCount; // 0x20

		public bool isRunning { get; private set; } // 0x21
		public OnElapsedCallback onElapsedCallback { private get; set; } // 0x24
		public OnEndCallback onEndCallback { private get; set; } // 0x28

		// // RVA: 0x154049C Offset: 0x154049C VA: 0x154049C
		public void Update()
		{
			if(!NKGJPJPHLIF.HHCJCDFCLOB.PECPLBANLBN)
			{
				if(!isRunning)
				{
					if(m_isForceCount)
					{
						CheckRestart();
						return;
					}
				}
				else
				{
					long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
					if(time != m_savedCurrentTime)
					{
						m_savedCurrentTime = time;
						long remain = m_limitTime - time;
						if(onElapsedCallback != null)
						{
							onElapsedCallback(time, m_limitTime, remain);
						}
						if(remain == 0)
						{
							if(onEndCallback != null)
								onEndCallback(time);
							m_savedCurrentTime = 0;
							m_limitTime = 0;
							isRunning = false;
						}
					}
				}
			}
		}

		// // RVA: 0x15411A8 Offset: 0x15411A8 VA: 0x15411A8
		public void WatchStart(long limitTime, bool forceCount = false)
		{
			m_limitTime = limitTime;
			m_savedCurrentTime = 0;
			m_isForceCount = forceCount;
			isRunning = true;
			m_limitTimeMirror = limitTime;
			Update();
		}

		// // RVA: 0x154118C Offset: 0x154118C VA: 0x154118C
		public void WatchStop()
		{
			m_limitTime = 0;
			m_savedCurrentTime = 0;
			isRunning = false;
		}

		// // RVA: 0x15406BC Offset: 0x15406BC VA: 0x15406BC
		public void CheckRestart()
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			if(m_savedCurrentTime == time)
				return;
			m_savedCurrentTime = time;
			if(m_limitTimeMirror >= time)
			{
				isRunning = true;
				m_limitTime = m_limitTimeMirror;
				Update();
			}
		}
	}
}
