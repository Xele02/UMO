using UnityEngine;
using System.Threading;
using System.Collections.Generic;
using System;

namespace CriWare
{
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
			lock (refList) {
				int listCount = CriDisposableObjectManager.refList.Count;
				for (int i = listCount - 1; i >= 0; --i) {
					if (CriDisposableObjectManager.refList[i].guid == disposable.guid) {
						return i;
					}
				}
			}
			return -1;
		}

		// // RVA: 0x2897DC4 Offset: 0x2897DC4 VA: 0x2897DC4
		public static void Register(CriDisposable disposable, CriDisposableObjectManager.ModuleType type)
		{
			if (CriDisposableObjectManager.SearchForDisposable(disposable) >= 0) {
				UnityEngine.Debug.LogWarning("[CRIWARE] Internal: Duplicated object GUID");
				return;
			}
			/* Keep reference directly */
			lock (refList) {
				CriDisposableObjectManager.refList.Add(new ObjectRef(disposable.guid, disposable, type));
			}
		}

		// // RVA: 0x2898368 Offset: 0x2898368 VA: 0x2898368
		public static bool Unregister(CriDisposable disposable)
		{
			lock (refList) {
				int index = CriDisposableObjectManager.SearchForDisposable(disposable);
				if (index >= 0) {
					CriDisposableObjectManager.refList.RemoveAt(index);
					return true;
				}
			}
			return false;
		}

		// // RVA: 0x28BAF04 Offset: 0x28BAF04 VA: 0x28BAF04
		// public static bool IsDisposed(CriDisposable disposable) { }

		// // RVA: 0x289BBF8 Offset: 0x289BBF8 VA: 0x289BBF8
		public static void CallOnModuleFinalization(CriDisposableObjectManager.ModuleType type)
		{
			CriDisposableObjectManager.DisposeAll(type);
		}

		// // RVA: 0x28BB3B4 Offset: 0x28BB3B4 VA: 0x28BB3B4
		private static int GetNextWithType(CriDisposableObjectManager.ModuleType type)
		{
			int listCount = CriDisposableObjectManager.refList.Count;
			for (int i = listCount - 1; i >= 0; --i) {
				if (CriDisposableObjectManager.refList[i].type == type) {
					return i;
				}
			}
			return -1;
		}

		// // RVA: 0x28BAF88 Offset: 0x28BAF88 VA: 0x28BAF88
		public static void DisposeAll(CriDisposableObjectManager.ModuleType type)
		{
			lock (refList) {
				while (true) {
					int index = GetNextWithType(type);
					if (index < 0) {
						break;
					}
		#if CRIWARE_DISPOSABLEOBJECTMANAGER_USE_WEAKREF
					var target = (CriDisposable)CriDisposableObjectManager.refList[index].weakRef.Target;
		#else
					var target = CriDisposableObjectManager.refList[index].disposable;
		#endif
					if (target != null) {
						target.Dispose();
					} else {
						/* Unsafe fallback */
						UnityEngine.Debug.LogWarning("[CRIWARE] Internal: Object disposal(Type:" +
													CriDisposableObjectManager.refList[index].type.ToString() +
													") not handled by CriDisposableObjectManager; " +
													"memory leak may have occured.");
						CriDisposableObjectManager.refList.RemoveAt(index);
					}
				}
			}
		}
	}
}