using UnityEngine;
using System.Threading;
using System.Collections.Generic;
using System;

public static class CriDisposableObjectManager
{
    public enum ModuleType
    {
        Atom = 0,
        AtomMic = 1,
        Fs = 2,
        FsWeb = 3,
        Mana = 4,
        Lips = 5,
        Vip = 6,
    }

	public struct ObjectRef
	{
		public Guid guid; // 0x0
		public CriDisposableObjectManager.ModuleType type; // 0x10
		public CriDisposable disposable; // 0x14

		// RVA: 0x821D20 Offset: 0x821D20 VA: 0x821D20
		public ObjectRef(Guid _guid, CriDisposable _disposable, CriDisposableObjectManager.ModuleType _type)
		{
			guid = _guid;
			disposable = _disposable;
			type = _type;
		}
	}


	private static List<CriDisposableObjectManager.ObjectRef> refList = new List<CriDisposableObjectManager.ObjectRef>(); // 0x0

	// // RVA: 0x28BAB70 Offset: 0x28BAB70 VA: 0x28BAB70
	private static int SearchForDisposable(CriDisposable disposable)
	{
		// ghidra bug
		Debug.LogWarning("TODO SearchForDisposable real code");
		bool isLocked = false;
		Monitor.Enter(refList, ref isLocked);

		int index = -1;

		for(int i = 0; i < refList.Count; i++)
		{
			if(disposable.guid == refList[i].guid)
			{
				index = i;
				break;
			}
		}

		if(isLocked)
			Monitor.Exit(refList);

		return index;
	}

	// // RVA: 0x2897DC4 Offset: 0x2897DC4 VA: 0x2897DC4
	public static void Register(CriDisposable disposable, CriDisposableObjectManager.ModuleType type)
    {
		int index = SearchForDisposable(disposable);
        if(index < 0)
		{
			bool isLocked = false;
			Monitor.Enter(refList, ref isLocked);
			refList.Add(new ObjectRef(disposable.guid, disposable, type));
			if(isLocked)
				Monitor.Exit(refList);
		}
		else
		{
			Debug.LogWarning("[CRIWARE] Internal: Duplicated object GUID");
		}
    }

	// // RVA: 0x2898368 Offset: 0x2898368 VA: 0x2898368
	public static bool Unregister(CriDisposable disposable)
	{
		bool res = false;
		bool isLocked = false;
		Monitor.Enter(refList, ref isLocked);

		int index = SearchForDisposable(disposable);
		if(index >= 0)
		{
			refList.RemoveAt(index);
			res = true;
		}

		if(isLocked)
			Monitor.Exit(refList);

		return res;
	}

	// // RVA: 0x28BAF04 Offset: 0x28BAF04 VA: 0x28BAF04
	// public static bool IsDisposed(CriDisposable disposable) { }

	// // RVA: 0x289BBF8 Offset: 0x289BBF8 VA: 0x289BBF8
	// public static void CallOnModuleFinalization(CriDisposableObjectManager.ModuleType type) { }

	// // RVA: 0x28BB3B4 Offset: 0x28BB3B4 VA: 0x28BB3B4
	// private static int GetNextWithType(CriDisposableObjectManager.ModuleType type) { }

	// // RVA: 0x28BAF88 Offset: 0x28BAF88 VA: 0x28BAF88
	// public static void DisposeAll(CriDisposableObjectManager.ModuleType type) { }

	// // RVA: 0x28BB514 Offset: 0x28BB514 VA: 0x28BB514
	// private static void .cctor() { }
}
