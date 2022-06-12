using XeSys;
using System;
using UnityEngine;
using System.Collections;

namespace XeApp.Game.Common
{
	public class MessageLoader : Singleton<MessageLoader>, IDisposable
	{
		public enum InstallSource
		{
			Resource = 0,
			LocalStorage = 1,
		}
		
		public enum eSheet // TypeDefIndex: 16997
		{
			common = 0,
			data_ = 1,
			menu = 2,
			master = 3,
			diva001 = 4,
			diva002 = 5,
			diva003 = 6,
			diva004 = 7,
			diva005 = 8,
			diva006 = 9,
			diva007 = 10,
			diva008 = 11,
			diva009 = 12,
			diva010 = 13,
		}

		private string[] s_path; // 0x8
		private bool m_isLoading; // 0xC
		public MessageLoader.InstallSource defaultInstallSource; // 0x10


		public bool IsLoading { get; }

		// // RVA: 0x1115A74 Offset: 0x1115A74 VA: 0x1115A74
		// public bool get_IsLoading() { }

		// // RVA: 0x1115A7C Offset: 0x1115A7C VA: 0x1115A7C
		public void Request(MessageLoader.eSheet sheet, int version)
		{
			UnityEngine.Debug.LogWarning("TODO MessageLoader Request");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x739A3C Offset: 0x739A3C VA: 0x739A3C
		// // RVA: 0x1116178 Offset: 0x1116178 VA: 0x1116178
		// private IEnumerator Coroutine_SecureFileLoad(IIEDOGCMCIE tar, MessageLoader.eSheet sheet, int version) { }

		// // RVA: 0x111626C Offset: 0x111626C VA: 0x111626C
		// public void Request(string bankName, string fileName) { }

		// // RVA: 0x11166C4 Offset: 0x11166C4 VA: 0x11166C4
		// public bool Request(CBBJHPBGBAJ tar, MessageLoader.eSheet sheet, int version) { }

		// // RVA: 0x11169AC Offset: 0x11169AC VA: 0x11169AC
		// private bool LoadCallback(FileResultObject fro) { }

		// // RVA: 0x1116B24 Offset: 0x1116B24 VA: 0x1116B24
		// private bool LoadCallbackStorage(FileResultObject fro) { }

		// // RVA: 0x1116C38 Offset: 0x1116C38 VA: 0x1116C38
		// private bool LoadCallbackStorage2(FileResultObject fro) { }

		// // RVA: 0x1117054 Offset: 0x1117054 VA: 0x1117054 Slot: 4
		public void Dispose()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x1116088 Offset: 0x1116088 VA: 0x1116088
		// public void Release(MessageLoader.eSheet sheet) { }

		// // RVA: 0x1117058 Offset: 0x1117058 VA: 0x1117058
		public YieldInstruction WaitForDone(MonoBehaviour mb)
		{
			return mb.StartCoroutine(CheckDone());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x739AB4 Offset: 0x739AB4 VA: 0x739AB4
		// // RVA: 0x1117090 Offset: 0x1117090 VA: 0x1117090
		private IEnumerator CheckDone()
		{
			UnityEngine.Debug.LogWarning("TODO MessageLoader CheckDone");
			yield break;
		}

		// // RVA: 0x111713C Offset: 0x111713C VA: 0x111713C
		// public static MessageLoader.eSheet DivaIdToSheet(int divaId) { }

		// // RVA: 0x1117144 Offset: 0x1117144 VA: 0x1117144
		// public void .ctor() { }
	}
}
