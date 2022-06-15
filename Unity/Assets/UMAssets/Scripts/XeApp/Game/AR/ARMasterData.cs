namespace XeApp.Game.AR
{
	public class ARMasterData
	{
		private const string LIST_NAME = "db";
		private const string DATA_PATH = "/db/{0}.dat";
		private bool m_isReady; // 0x8
		private string m_name = "ar"; // 0xC
		public bool ignoreError; // 0x10
		public float timeoutTime = 6.0f; // 0x14
		private const int RETRY_LIMIT = 1;

		// public string name { get; set; } 0xBBA77C 0xBB6E94

		// // RVA: -1 Offset: -1 Slot: 4
		// protected abstract void Initialize(byte[] bytes);

		// RVA: 0xBBA784 Offset: 0xBBA784 VA: 0xBBA784
		public bool IsReady()
		{
			UnityEngine.Debug.LogError("TODO");
			return false;
		}

		// // RVA: 0xBBA78C Offset: 0xBBA78C VA: 0xBBA78C
		public void StartInstall(IMCBBOAFION onSuccess, DJBHIFLHJLK onError)
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x741AC4 Offset: 0x741AC4 VA: 0x741AC4
		// // RVA: 0xBBA7E4 Offset: 0xBBA7E4 VA: 0xBBA7E4
		// private IEnumerator Coroutine_Install(IMCBBOAFION onSuccess, DJBHIFLHJLK onError) { }

		// [IteratorStateMachineAttribute] // RVA: 0x741B3C Offset: 0x741B3C VA: 0x741B3C
		// // RVA: 0xBBA8C4 Offset: 0xBBA8C4 VA: 0xBBA8C4
		// private IEnumerator Coroutine_LoadTarFile(string path, Action<byte[]> onFinished) { }

		// [IteratorStateMachineAttribute] // RVA: 0x741BB4 Offset: 0x741BB4 VA: 0x741BB4
		// // RVA: 0xBBA9A4 Offset: 0xBBA9A4 VA: 0xBBA9A4
		// private IEnumerator Coroutine_Download(DJBHIFLHJLK onError) { }

		// // RVA: 0xBBAA6C Offset: 0xBBAA6C VA: 0xBBAA6C
		// private string CalcMD5(string path) { }

		// // RVA: 0xBBADA4 Offset: 0xBBADA4 VA: 0xBBADA4
		// private bool ValidateSchemaHash(byte[] hashBytes, string name) { }

		// [CompilerGeneratedAttribute] // RVA: 0x741C2C Offset: 0x741C2C VA: 0x741C2C
		// // RVA: 0xBBB100 Offset: 0xBBB100 VA: 0xBBB100
		// private bool <Coroutine_LoadTarFile>b__14_1(CBBJHPBGBAJ.JBCFNCNGLPM _) { }

		// [CompilerGeneratedAttribute] // RVA: 0x741C3C Offset: 0x741C3C VA: 0x741C3C
		// // RVA: 0xBBB1A4 Offset: 0xBBB1A4 VA: 0xBBB1A4
		// private bool <Coroutine_Download>b__15_1(GCGNICILKLD _) { }
	}
}
