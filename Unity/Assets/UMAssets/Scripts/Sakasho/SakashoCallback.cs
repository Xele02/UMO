using UnityEngine;
using System;
using System.Threading;
using System.Collections.Generic;

public class SakashoCallback : MonoBehaviour, ISakashoQueueHolder
{
    public class ThreadQueue
    {
        private List<Action> jobs = new List<Action>(); // 0x8
        private bool terminating; // 0xC
        private AutoResetEvent resetEvent; // 0x10

        // RVA: 0x2BB84B8 Offset: 0x2BB84B8 VA: 0x2BB84B8
        public ThreadQueue(bool isWorker = false)
        {
            if(!isWorker)
                return;
            resetEvent = new AutoResetEvent(false);
        }

        // // RVA: 0x2BB8E7C Offset: 0x2BB8E7C VA: 0x2BB8E7C
        public void Start()
        {
            Process(false);
        }

        // // RVA: 0x2BB85C8 Offset: 0x2BB85C8 VA: 0x2BB85C8
        public void Process(bool once)
        {
            do
            {
                bool isLocked = false;
                Monitor.Enter(this, ref isLocked);
                Action job = null;
                if(!terminating)
                {
                    if(jobs.Count > 0)
                    {
                        job = jobs[0];
                        jobs.RemoveAt(0);
                    }
                    
                }
                else
                {
                    once = true;
                }
                if(isLocked)
                    Monitor.Exit(this);
                if(job != null)
                {
                    job();
                }
                if(once)
                    return;
                if(jobs.Count == 0)
                {
                    resetEvent.WaitOne();
                }
            } while (true);
        }

        // // RVA: 0x2BB8C08 Offset: 0x2BB8C08 VA: 0x2BB8C08
        public bool Push(Action action)
        {
            bool added = false;
            bool isLocked = false;
            Monitor.Enter(this, ref isLocked);

            if(!terminating)
            {
                jobs.Add(action);
                added = true;
            }

            if(isLocked)
                Monitor.Exit(this);

            return added;
        }

        // // RVA: 0x2BB8980 Offset: 0x2BB8980 VA: 0x2BB8980
        public void Terminate()
        {
            bool isLocked = false;
            Monitor.Enter(this, ref isLocked);

            terminating = true;
            if(resetEvent != null)
                resetEvent.Set();
            if(isLocked)
                Monitor.Exit(this);
        }

        // // RVA: 0x2BB8860 Offset: 0x2BB8860 VA: 0x2BB8860
        public void ResumeIfJobExists()
        {
            if(resetEvent != null)
            {
                if(jobs.Count < 1)
                    return;
                resetEvent.Set();
            }
        }
    }

	private static SakashoCallback instance; // 0x0
	private Thread worker; // 0xC
	private SakashoCallback.ThreadQueue mainQueue; // 0x10
	private SakashoCallback.ThreadQueue workerQueue; // 0x14

	// RVA: 0x2BB8214 Offset: 0x2BB8214 VA: 0x2BB8214
	private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            SakashoCallbackRegistry.MainThreadQueueHolder = this;
            SakashoCallbackRegistry.GameObjectName = transform.gameObject.name;
            UnityEngine.Object.DontDestroyOnLoad(transform.gameObject);
        }
        mainQueue = new ThreadQueue(false);
        workerQueue = new ThreadQueue(true);
        worker = new Thread(workerQueue.Start);
        worker.Name = "Sakasho Worker";
        worker.Start();
    }

	// RVA: 0x2BB857C Offset: 0x2BB857C VA: 0x2BB857C
	private void Update()
    {
        mainQueue.Process(true);
        workerQueue.ResumeIfJobExists();
    }

	// RVA: 0x2BB890C Offset: 0x2BB890C VA: 0x2BB890C
	private void OnDestroy()
    {
        if(worker != null)
        {
            if(workerQueue != null)
            {
                workerQueue.Terminate();
            }
            worker.Join();
            worker = null;
        }
        workerQueue = null;
        if(mainQueue != null)
        {
            mainQueue.Terminate();
            mainQueue = null;
        }
    }

	// // RVA: 0x2BB8A38 Offset: 0x2BB8A38 VA: 0x2BB8A38
	public void NotifyOnSuccess(string message)
    {
        workerQueue.Push(() => {
            // 0x2BB8D6C
            SakashoCallbackRegistry.FireOnSuccess(message);
        });
    }

	// // RVA: 0x2BB8B20 Offset: 0x2BB8B20 VA: 0x2BB8B20
	// public void NotifyOnError(string message) { }

	// RVA: 0x2BB8BF4 Offset: 0x2BB8BF4 VA: 0x2BB8BF4 Slot: 4
	public bool PushToQueue(Action action)
    {
        if(mainQueue != null)
            return mainQueue.Push(action);
        return false;
    }

	// // RVA: 0x2BB8B0C Offset: 0x2BB8B0C VA: 0x2BB8B0C
	// private bool RunOnWorkerThread(Action action) { }
}
