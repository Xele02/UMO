using System;

namespace XeApp
{
    namespace Core
    {
        namespace WorkerThread
        {
public class WorkerThreadQueue // TypeDefIndex: 18501
{
	// Fields
	// private List<Action> jobs; // 0x8
	// private object sync; // 0xC
	// private AutoResetEvent resetEvent; // 0x10
	// [CompilerGeneratedAttribute] // RVA: 0x68F75C Offset: 0x68F75C VA: 0x68F75C
	// private bool <isAbort>k__BackingField; // 0x14
	// [CompilerGeneratedAttribute] // RVA: 0x68F76C Offset: 0x68F76C VA: 0x68F76C
	// private bool <isRunning>k__BackingField; // 0x15
	// private Thread thread; // 0x18

	// // Properties
	// private bool isAbort { get; set; }
	// public bool isRunning { get; set; }

	// // Methods

	// [CompilerGeneratedAttribute] // RVA: 0x748908 Offset: 0x748908 VA: 0x748908
	// // RVA: 0x1D79F8C Offset: 0x1D79F8C VA: 0x1D79F8C
	// private bool get_isAbort() { }

	// [CompilerGeneratedAttribute] // RVA: 0x748918 Offset: 0x748918 VA: 0x748918
	// // RVA: 0x1D79F94 Offset: 0x1D79F94 VA: 0x1D79F94
	// private void set_isAbort(bool value) { }

	// [CompilerGeneratedAttribute] // RVA: 0x748928 Offset: 0x748928 VA: 0x748928
	// // RVA: 0x1D79F9C Offset: 0x1D79F9C VA: 0x1D79F9C
	// public bool get_isRunning() { }

	// [CompilerGeneratedAttribute] // RVA: 0x748938 Offset: 0x748938 VA: 0x748938
	// // RVA: 0x1D79FA4 Offset: 0x1D79FA4 VA: 0x1D79FA4
	// private void set_isRunning(bool value) { }

	// // RVA: 0x1D79FAC Offset: 0x1D79FAC VA: 0x1D79FAC
	public WorkerThreadQueue() 
	{
		UnityEngine.Debug.LogWarning("TODO WorkerThreadQueue");
		//jobs
		//sync
		//resetEvent
	}

	// // RVA: 0x1D7A088 Offset: 0x1D7A088 VA: 0x1D7A088
	public void Start() 
    { 
        UnityEngine.Debug.LogWarning("TODO WorkerThreadQueue.Start");
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