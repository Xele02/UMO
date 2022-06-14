using System;

namespace XeApp
{
    namespace Core
    {
        namespace WorkerThread
        {
			public class WorkerThreadQueue
			{
				// private List<Action> jobs; // 0x8
				// private object sync; // 0xC
				// private AutoResetEvent resetEvent; // 0x10
				// private Thread thread; // 0x18

				// private bool isAbort { get; set; } // 0x14
				// public bool isRunning { get; private set; } // 0x15

				// // RVA: 0x1D79FAC Offset: 0x1D79FAC VA: 0x1D79FAC
				public WorkerThreadQueue() 
				{
					UnityEngine.Debug.LogError("TODO WorkerThreadQueue");
					//jobs
					//sync
					//resetEvent
				}

				// // RVA: 0x1D7A088 Offset: 0x1D7A088 VA: 0x1D7A088
				public void Start() 
				{ 
					UnityEngine.Debug.LogError("TODO WorkerThreadQueue.Start");
					//thread
				}

				// // RVA: 0x1D7A1A4 Offset: 0x1D7A1A4 VA: 0x1D7A1A4
				// public void Abort() { }

				// // RVA: 0x1D7A28C Offset: 0x1D7A28C VA: 0x1D7A28C
				public void Add(Action job)
				{
					UnityEngine.Debug.LogError("TODO");
				}

				// // RVA: 0x1D7A3C4 Offset: 0x1D7A3C4 VA: 0x1D7A3C4
				// private void ThreadUpdate() { }

				// // RVA: 0x1D7A604 Offset: 0x1D7A604 VA: 0x1D7A604
				// private Action GetJob() { }
			}
        }
    }
}