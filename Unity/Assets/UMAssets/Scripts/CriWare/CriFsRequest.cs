
using System;

namespace CriWare
{
	public class CriFsRequest : CriDisposable
	{
		public delegate void DoneDelegate(CriFsRequest request);

		public CriFsRequest.DoneDelegate doneDelegate { get; set; } // 0x18
		public bool isDone { get; set; } // 0x1C
		public string error { get; set; } // 0x20
		public bool isDisposed { get; set; } // 0x24

		// // RVA: 0x294AEF8 Offset: 0x294AEF8 VA: 0x294AEF8 Slot: 5
		public override void Dispose()
		{
			if (isDisposed)
				return;
			Dispose(true);
			isDisposed = true;
			GC.SuppressFinalize(this);
		}

		// // RVA: 0x294AFA8 Offset: 0x294AFA8 VA: 0x294AFA8 Slot: 6
		public virtual void Stop()
		{
			TodoLogger.LogError(TodoLogger.CriFsPlugin, "TODO");
		}

		// // RVA: 0x294AFAC Offset: 0x294AFAC VA: 0x294AFAC
		// public YieldInstruction WaitForDone(MonoBehaviour mb) { }

		// // RVA: 0x294B070 Offset: 0x294B070 VA: 0x294B070 Slot: 7
		protected virtual void Dispose(bool disposing)
		{
			return;
		}

		// // RVA: 0x294B074 Offset: 0x294B074 VA: 0x294B074 Slot: 8
		public virtual void Update()
		{
			return;
		}

		// // RVA: 0x29444B0 Offset: 0x29444B0 VA: 0x29444B0
		// protected void Done() { }

		// [IteratorStateMachineAttribute] // RVA: 0x636160 Offset: 0x636160 VA: 0x636160
		// // RVA: 0x294AFE4 Offset: 0x294AFE4 VA: 0x294AFE4
		// private IEnumerator CheckDone() { }

		// // RVA: 0x294B8C0 Offset: 0x294B8C0 VA: 0x294B8C0 Slot: 1
		// protected override void Finalize() { }
	}
}
