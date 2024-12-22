using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using XeApp.Game;

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
					if(RuntimeSettings.CurrentSettings.WorkerThreadUseCoroutine)
					{
						GameManager.Instance.StartCoroutineWatched(WorkerCoroutine());
						TodoLogger.Log(TodoLogger.Job, "Created WorkerThread Coroutine");
					}
					else
					{
						thread = new Thread(this.ThreadUpdate);
						thread.Name = "XeAppWorkerThread";
						if(!RuntimeSettings.CurrentSettings.WorkerThreadPriorityNormal)
							thread.Priority = ThreadPriority.BelowNormal;
						thread.Start();	
						TodoLogger.Log(TodoLogger.Job, "Created WorkerThread Thread. Normal Priority : "+RuntimeSettings.CurrentSettings.WorkerThreadPriorityNormal);
					}
				}

				public IEnumerator WorkerCoroutine()
				{
					while(!isAbort)
					{
						while(jobs.Count == 0)
						{
							if(isAbort)
								yield break;
							yield return null;
						}
						isRunning = true;
						Action job = jobs[0];
						TodoLogger.Log(TodoLogger.Job, "Executing job " +job.Method+" "+job.Target);
						job();
						TodoLogger.Log(TodoLogger.Job, "Executed job " +job.Method+" "+job.Target);
						jobs.RemoveAt(0);
						isRunning = false;
						yield return null;
					}
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
					TodoLogger.Log(TodoLogger.Job, "ThreadUpdate Start");
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
					TodoLogger.Log(TodoLogger.Job, "ThreadUpdate End");
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
						TodoLogger.Log(TodoLogger.Job, "GetJob wait event");
						resetEvent.WaitOne();
						TodoLogger.Log(TodoLogger.Job, "GetJob check next job");
					}
					TodoLogger.Log(TodoLogger.Job, "GetJob return null");
					return null;
				}
			}
        }
    }
}
