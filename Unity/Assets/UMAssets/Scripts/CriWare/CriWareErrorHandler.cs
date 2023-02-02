namespace CriWare
{

	// [AddComponentMenu] // RVA: 0x63296C Offset: 0x63296C VA: 0x63296C
	public class CriWareErrorHandler : CriMonoBehaviour
	{
		public bool enableDebugPrintOnTerminal; // 0x1C
		public bool enableForceCrashOnError; // 0x1D
		public bool dontDestroyOnLoad = true; // 0x1E
		// [CompilerGeneratedAttribute] // RVA: 0x634C34 Offset: 0x634C34 VA: 0x634C34
		// private static CriWareErrorHandler.Callback OnCallback; // 0x4
		// [ObsoleteAttribute] // RVA: 0x634C44 Offset: 0x634C44 VA: 0x634C44
		// public static CriWareErrorHandler.Callback callback; // 0x8
		public uint messageBufferCounts = 8; // 0x20
		private static int initializationCount; // 0xC

		public static string errorMessage { get; set; } // 0x0

		// [CompilerGeneratedAttribute] // RVA: 0x6364FC Offset: 0x6364FC VA: 0x6364FC
		// // RVA: 0x2BAA120 Offset: 0x2BAA120 VA: 0x2BAA120
		// public static void add_OnCallback(CriWareErrorHandler.Callback value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x63650C Offset: 0x63650C VA: 0x63650C
		// // RVA: 0x2BAA2B4 Offset: 0x2BAA2B4 VA: 0x2BAA2B4
		// public static void remove_OnCallback(CriWareErrorHandler.Callback value) { }

		// // RVA: 0x2BAA448 Offset: 0x2BAA448 VA: 0x2BAA448
		private void Awake()
		{
			initializationCount++;
			if (initializationCount == 1)
			{
				TodoLogger.Log(TodoLogger.CriWareErrorHandler, "CriWareErrorHandler.Awake");
				if (!dontDestroyOnLoad)
					return;
				DontDestroyOnLoad(transform.gameObject);
			}
			else
			{
				Destroy(this);
			}
		}

		// // RVA: 0x2BAAB48 Offset: 0x2BAAB48 VA: 0x2BAAB48 Slot: 4
		protected override void OnEnable()
		{
			base.OnEnable();
			TodoLogger.Log(TodoLogger.CriWareErrorHandler, "CriWareErrorHandler.OnEnable");
		}

		// // RVA: 0x2BAAC10 Offset: 0x2BAAC10 VA: 0x2BAAC10 Slot: 5
		protected override void OnDisable()
		{
			base.OnDisable();
			TodoLogger.Log(TodoLogger.CriWareErrorHandler, "CriWareErrorHandler.OnDisable");
		}

		// // RVA: 0x2BAAC9C Offset: 0x2BAAC9C VA: 0x2BAAC9C
		private void Start()
		{
			return;
		}

		// // RVA: 0x2BAACA0 Offset: 0x2BAACA0 VA: 0x2BAACA0 Slot: 6
		public override void CriInternalUpdate()
		{
			if (enableDebugPrintOnTerminal)
				return;
			TodoLogger.Log(TodoLogger.CriWareErrorHandler, "CriWareErrorHandler.CriInternalUpdate");
		}

		// // RVA: 0x2BAAFA0 Offset: 0x2BAAFA0 VA: 0x2BAAFA0 Slot: 7
		public override void CriInternalLateUpdate()
		{
			return;
		}

		// // RVA: 0x2BAAFA4 Offset: 0x2BAAFA4 VA: 0x2BAAFA4
		private void OnDestroy()
		{
			TodoLogger.Log(0, "TODO");
		}

		// // RVA: 0x2BAACB0 Offset: 0x2BAACB0 VA: 0x2BAACB0
		// private void DequeueErrorMessages() { }

		// // RVA: 0x2BAB35C Offset: 0x2BAB35C VA: 0x2BAB35C
		// private static void HandleMessage(string errmsg) { }

		// // RVA: 0x2BAB594 Offset: 0x2BAB594 VA: 0x2BAB594
		// private static void OutputDefaultLog(string errmsg) { }

		// [MonoPInvokeCallbackAttribute] // RVA: 0x63651C Offset: 0x63651C VA: 0x63651C
		// // RVA: 0x2BA9F84 Offset: 0x2BA9F84 VA: 0x2BA9F84
		// private static void ErrorCallbackFromNative(string errmsg) { }

		// // RVA: 0x2BAA818 Offset: 0x2BAA818 VA: 0x2BAA818
		// private static extern void CRIWARE2944E024(uint length) { }

		// // RVA: 0x2BAA618 Offset: 0x2BAA618 VA: 0x2BAA618
		// private static extern void CRIWARE2DABE6AD() { }

		// // RVA: 0x2BAB170 Offset: 0x2BAB170 VA: 0x2BAB170
		// private static extern void CRIWARE992B1A7A() { }

		// // RVA: 0x2BAA920 Offset: 0x2BAA920 VA: 0x2BAA920
		// private static extern void CRIWAREE5C6ECB6(bool sw) { }

		// // RVA: 0x2BAB078 Offset: 0x2BAB078 VA: 0x2BAB078
		// private static extern void CRIWARE972AEE70() { }

		// // RVA: 0x2BAB268 Offset: 0x2BAB268 VA: 0x2BAB268
		// private static extern IntPtr CRIWARE24FFC2BE() { }

		// // RVA: 0x2BAA710 Offset: 0x2BAA710 VA: 0x2BAA710
		// private static extern void CRIWARE2AB443C5(bool sw) { }

		// // RVA: 0x2BAAA38 Offset: 0x2BAAA38 VA: 0x2BAAA38
		// private static extern void CRIWAREEA2D718D(CriWareErrorHandler.ErrorCallbackFunc callback) { }
	}
}
