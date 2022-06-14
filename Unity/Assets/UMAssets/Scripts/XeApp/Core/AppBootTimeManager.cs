using UnityEngine;
using System;

namespace XeApp.Core
{
	public class AppBootTimeManager : MonoBehaviour
	{
		private double cachedElapsedTime; // 0x10
		private const double FAR_FIRE_TIME = 7776000;
		private DateTime baseDateTime; // 0x18

		public double Elapsed { get { return cachedElapsedTime; } } // 0xE0D764
		public long ElapsedMilliseconds { get { return (long)(cachedElapsedTime * 1000.0); } } // 0xE0D770

		// // RVA: 0xE0D798 Offset: 0xE0D798 VA: 0xE0D798
		private void Awake()
		{
			baseDateTime = DateTime.Now;
		}

		// // RVA: 0xE0D82C Offset: 0xE0D82C VA: 0xE0D82C Slot: 4
		protected virtual void OnDestroy()
		{
			return;
		}

		// // RVA: 0xE0D830 Offset: 0xE0D830 VA: 0xE0D830
		private void Update()
		{
			cachedElapsedTime = GetElapsed();
		}

		// // RVA: 0xE0D848 Offset: 0xE0D848 VA: 0xE0D848
		public void UpdateElapsedTime()
		{
			cachedElapsedTime = GetElapsed();
		}

		// // RVA: 0xE0D860 Offset: 0xE0D860 VA: 0xE0D860
		public double GetElapsed()
		{
			return (DateTime.Now - baseDateTime).TotalSeconds;
		}
	}
}
