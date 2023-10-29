using System;
using System.Collections.Generic;
using System.Threading;

namespace XeApp
{
    namespace Core
    {
        namespace WorkerThread
        {
			public class WorkerThreadQueue
			{
				private List<Action> jobs; // 0x8
				private object sync; // 0xC
				private AutoResetEvent resetEvent; // 0x10
				private Thread thread; // 0x18

				private bool isAbort { get; set; } // 0x14
				public bool isRunning { get; private set; } // 0x15

				// // RVA: 0x1D79FAC Offset: 0x1D79FAC VA: 0x1D79FAC
				public WorkerThreadQueue() 
				{
					jobs = new List<Action>(32);
					sync = new object();
					resetEvent = new AutoResetEvent(false);
				}

				// // RVA: 0x1D7A088 Offset: 0x1D7A088 VA: 0x1D7A088
				public void Start() 
				{ 
					thread = new Thread(this.ThreadUpdate);
					thread.Name = "XeAppWorkerThread";
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();	
				}

				// // RVA: 0x1D7A1A4 Offset: 0x1D7A1A4 VA: 0x1D7A1A4
				public void Abort()
				{
					bool isLocked = false;
					Monitor.Enter(sync, ref isLocked);
					isAbort = true;
					resetEvent.Set();
					if(isLocked)
						Monitor.Exit(sync);
					if(thread != null)
					{
						thread.Join();
						thread = null;
					}
				}

				// // RVA: 0x1D7A28C Offset: 0x1D7A28C VA: 0x1D7A28C
				public void Add(Action job)
				{
					bool isLocked = false;
					Monitor.Enter(sync, ref isLocked);
					jobs.Add(job);
					resetEvent.Set();
					TodoLogger.Log(TodoLogger.Job, "Added job " +job.Method+" "+job.Target);
					if(isLocked)
						Monitor.Exit(sync);
				}

				// // RVA: 0x1D7A3C4 Offset: 0x1D7A3C4 VA: 0x1D7A3C4
				private void ThreadUpdate()
				{
					Action job = GetJob();
					while(job != null)
					{
						TodoLogger.Log(TodoLogger.Job, "Executing job " +job.Method+" "+job.Target);
						job();
						TodoLogger.Log(TodoLogger.Job, "Executed job " +job.Method+" "+job.Target);
						bool isLocked = false;
						Monitor.Enter(sync, ref isLocked);

						jobs.RemoveAt(0);
						if(isLocked)
							Monitor.Exit(sync);

						job = GetJob();
					}
				}

				// // RVA: 0x1D7A604 Offset: 0x1D7A604 VA: 0x1D7A604
				private Action GetJob()
				{
					Action job = null;
					while(!isAbort)
					{
						bool isLocked = false;
						Monitor.Enter(sync, ref isLocked);
						if(jobs.Count > 0)
						{
							isRunning = true;
							job = jobs[0];
						}
						if(isLocked)
							Monitor.Exit(sync);
						if(job != null)
							return job;
						isRunning = false;
						resetEvent.WaitOne();
					}
					return null;
				}
			}
        }
    }
}
