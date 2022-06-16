using System.Diagnostics;
using UnityEngine;
using System;

namespace XeSys
{
	public class IdleProcessManager : SingletonMonoBehaviour<IdleProcessManager>
	{
		public enum ProcessResult
		{
			Continue = 0,
			Next = 1,
			End = 2,
		}

		public struct IdleProcess
		{
			public Func<IdleProcessManager.ProcessResult> Process; // 0x0
			public int Priority; // 0x4
			public int Next; // 0x8
			public int Prev; // 0xC
			public int State; // 0x10
			public uint Weight; // 0x14
			public uint Age; // 0x18
		}

		private const int IDLE = 0;
		private const int REGISTERED = 1;
		private const int ACTIVE = 2;
		private const int AGE_MAX = 16;
		public int initialProcessesCount = 256; // 0xC
		private IdleProcessManager.IdleProcess[] processes; // 0x10
		private int active; // 0x14
		private int idle; // 0x18
		private int registered; // 0x1C
		private Stopwatch sw = new Stopwatch(); // 0x20
		public int lazyCount; // 0x34
		private const int LAZY_LIMIT_COUNT = 2;
		private WaitForEndOfFrame recycle = new WaitForEndOfFrame(); // 0x40

		public float ProcessingRate { get; set; } // 0x24
		public bool IsFixedTime { get; set; } // 0x28
		public int ProcessingMilliSeconds { get; set; } // 0x2C
		public bool IsAutoExtention { get; set; } // 0x30
		public bool IsBurstEnable { get; set; } // 0x38
		public float BurstProcessingRate { get; set; } // 0x3C

		// // RVA: 0x1EF2A28 Offset: 0x1EF2A28 VA: 0x1EF2A28
		private void Awake()
		{
			UnityEngine.Debug.LogWarning("TODO IdleProcessManager.Awake()");
		}

		// // RVA: 0x1EF2CD4 Offset: 0x1EF2CD4 VA: 0x1EF2CD4
		private void Update()
		{
			UnityEngine.Debug.LogWarning("TODO IdleProcessManager.Update()");
		}

		// // RVA: 0x1EF2D24 Offset: 0x1EF2D24 VA: 0x1EF2D24
		// public int Register(Func<IdleProcessManager.ProcessResult> process, int priority, float weight = 0) { }

		// // RVA: 0x1EF34C8 Offset: 0x1EF34C8 VA: 0x1EF34C8
		// public int Register(IEnumerator coroutine, int priority, float weight = 0) { }

		// // RVA: 0x1EF35BC Offset: 0x1EF35BC VA: 0x1EF35BC
		// public void Unregister(int index) { }

		// // RVA: 0x1EF2B1C Offset: 0x1EF2B1C VA: 0x1EF2B1C
		// private static void InitializeRange(IdleProcessManager.IdleProcess[] processes, int prev, int next, int start, int end) { }

		// [IteratorStateMachineAttribute] // RVA: 0x691DB4 Offset: 0x691DB4 VA: 0x691DB4
		// // RVA: 0x1EF2C48 Offset: 0x1EF2C48 VA: 0x1EF2C48
		// private IEnumerator IdleCoroutine() { }

		// // RVA: 0x1EF3744 Offset: 0x1EF3744 VA: 0x1EF3744
		// private void Idle() { }

		// // RVA: 0x1EF2F68 Offset: 0x1EF2F68 VA: 0x1EF2F68
		// private void Extend(int count) { }

		// // RVA: 0x1EF3B84 Offset: 0x1EF3B84 VA: 0x1EF3B84
		// private void Activate() { }

		// // RVA: 0x1EF3180 Offset: 0x1EF3180 VA: 0x1EF3180
		// private void Unlink(ref int top, int target) { }

		// // RVA: 0x1EF3398 Offset: 0x1EF3398 VA: 0x1EF3398
		// private void Link(ref int top, int prev, int next, int target) { }
	}
}
