// [AddComponentMenu] // RVA: 0x632684 Offset: 0x632684 VA: 0x632684
public class CriAtom : CriMonoBehaviour
{
	public string acfFile = ""; // 0x1C
	// private bool acfIsLoading; // 0x20
	public CriAtomCueSheet[] cueSheets = new CriAtomCueSheet[0](); // 0x24
	public string dspBusSetting = ""; // 0x28
	public bool dontDestroyOnLoad; // 0x2C
	// private static CriAtomExSequencer.EventCallback eventUserCallback; // 0x0
	// private static CriAtomExSequencer.EventCbFunc eventUserCbFunc; // 0x4
	// [CompilerGeneratedAttribute] // RVA: 0x63461C Offset: 0x63461C VA: 0x63461C
	// private static CriAtomExBeatSync.CbFunc beatsyncUserCbFunc; // 0x8
	// private static CriAtomExBeatSync.CbFunc obsoleteBeatSyncFunc; // 0xC
	// [CompilerGeneratedAttribute] // RVA: 0x63462C Offset: 0x63462C VA: 0x63462C
	// private static CriAtomEx.CueLinkCbFunc cueLinkUserCbFunc; // 0x10
	// [CompilerGeneratedAttribute] // RVA: 0x63463C Offset: 0x63463C VA: 0x63463C
	// private static CriAtom <instance>k__BackingField; // 0x14
	// private GCHandle acfRegisterGCHandle; // 0x30
	public bool dontRemoveExistsCueSheet; // 0x34

	// private static CriAtom instance { get; set; }
	// public static bool CueSheetsAreLoading { get; }

	// // RVA: 0x2879DA0 Offset: 0x2879DA0 VA: 0x2879DA0
	// internal static void add_OnEventSequencerCallback(CriAtomExSequencer.EventCallback value) { }

	// // RVA: 0x287A060 Offset: 0x287A060 VA: 0x287A060
	// internal static void remove_OnEventSequencerCallback(CriAtomExSequencer.EventCallback value) { }

	// [CompilerGeneratedAttribute] // RVA: 0x63541C Offset: 0x63541C VA: 0x63541C
	// // RVA: 0x287A274 Offset: 0x287A274 VA: 0x287A274
	// private static void add_beatsyncUserCbFunc(CriAtomExBeatSync.CbFunc value) { }

	// [CompilerGeneratedAttribute] // RVA: 0x63542C Offset: 0x63542C VA: 0x63542C
	// // RVA: 0x287A408 Offset: 0x287A408 VA: 0x287A408
	// private static void remove_beatsyncUserCbFunc(CriAtomExBeatSync.CbFunc value) { }

	// // RVA: 0x287A59C Offset: 0x287A59C VA: 0x287A59C
	// internal static void add_OnBeatSyncCallback(CriAtomExBeatSync.CbFunc value) { }

	// // RVA: 0x287A7A0 Offset: 0x287A7A0 VA: 0x287A7A0
	// internal static void remove_OnBeatSyncCallback(CriAtomExBeatSync.CbFunc value) { }

	// [CompilerGeneratedAttribute] // RVA: 0x63543C Offset: 0x63543C VA: 0x63543C
	// // RVA: 0x287A8F8 Offset: 0x287A8F8 VA: 0x287A8F8
	// private static void add_cueLinkUserCbFunc(CriAtomEx.CueLinkCbFunc value) { }

	// [CompilerGeneratedAttribute] // RVA: 0x63544C Offset: 0x63544C VA: 0x63544C
	// // RVA: 0x287AA8C Offset: 0x287AA8C VA: 0x287AA8C
	// private static void remove_cueLinkUserCbFunc(CriAtomEx.CueLinkCbFunc value) { }

	// // RVA: 0x287AC20 Offset: 0x287AC20 VA: 0x287AC20
	// internal static void add_OnCueLinkCallback(CriAtomEx.CueLinkCbFunc value) { }

	// // RVA: 0x287AE28 Offset: 0x287AE28 VA: 0x287AE28
	// internal static void remove_OnCueLinkCallback(CriAtomEx.CueLinkCbFunc value) { }

	// [CompilerGeneratedAttribute] // RVA: 0x63545C Offset: 0x63545C VA: 0x63545C
	// // RVA: 0x287AF80 Offset: 0x287AF80 VA: 0x287AF80
	// private static CriAtom get_instance() { }

	// [CompilerGeneratedAttribute] // RVA: 0x63546C Offset: 0x63546C VA: 0x63546C
	// // RVA: 0x287B00C Offset: 0x287B00C VA: 0x287B00C
	// private static void set_instance(CriAtom value) { }

	// // RVA: 0x287B09C Offset: 0x287B09C VA: 0x287B09C
	// public static void AttachDspBusSetting(string settingName) { }

	// // RVA: 0x287B2A0 Offset: 0x287B2A0 VA: 0x287B2A0
	// public static void DetachDspBusSetting() { }

	// // RVA: 0x287B370 Offset: 0x287B370 VA: 0x287B370
	// public static CriAtomCueSheet GetCueSheet(string name) { }

	// // RVA: 0x287B4B4 Offset: 0x287B4B4 VA: 0x287B4B4
	// public static CriAtomCueSheet AddCueSheet(string name, string acbFile, string awbFile, CriFsBinder binder) { }

	// // RVA: 0x287B9C0 Offset: 0x287B9C0 VA: 0x287B9C0
	// public static CriAtomCueSheet AddCueSheetAsync(string name, string acbFile, string awbFile, CriFsBinder binder, bool loadAwbOnMemory = False) { }

	// // RVA: 0x287BB60 Offset: 0x287BB60 VA: 0x287BB60
	// public static CriAtomCueSheet AddCueSheet(string name, byte[] acbData, string awbFile, CriFsBinder awbBinder) { }

	// // RVA: 0x287BDE8 Offset: 0x287BDE8 VA: 0x287BDE8
	// public static CriAtomCueSheet AddCueSheetAsync(string name, byte[] acbData, string awbFile, CriFsBinder awbBinder, bool loadAwbOnMemory = False) { }

	// // RVA: 0x287BF74 Offset: 0x287BF74 VA: 0x287BF74
	// public static void RemoveCueSheet(string name) { }

	// // RVA: 0x287C270 Offset: 0x287C270 VA: 0x287C270
	// public static bool get_CueSheetsAreLoading() { }

	// // RVA: 0x287C3FC Offset: 0x287C3FC VA: 0x287C3FC
	// public static CriAtomExAcb GetAcb(string cueSheetName) { }

	// // RVA: 0x287C564 Offset: 0x287C564 VA: 0x287C564
	// public static void SetCategoryVolume(string name, float volume) { }

	// // RVA: 0x287C56C Offset: 0x287C56C VA: 0x287C56C
	// public static void SetCategoryVolume(int id, float volume) { }

	// // RVA: 0x287C574 Offset: 0x287C574 VA: 0x287C574
	// public static float GetCategoryVolume(string name) { }

	// // RVA: 0x287C57C Offset: 0x287C57C VA: 0x287C57C
	// public static float GetCategoryVolume(int id) { }

	// // RVA: 0x287C584 Offset: 0x287C584 VA: 0x287C584
	// public static void SetBusAnalyzer(string busName, bool sw) { }

	// // RVA: 0x287C5DC Offset: 0x287C5DC VA: 0x287C5DC
	// public static void SetBusAnalyzer(bool sw) { }

	// // RVA: 0x287C69C Offset: 0x287C69C VA: 0x287C69C
	// public static CriAtomExAsr.BusAnalyzerInfo GetBusAnalyzerInfo(string busName) { }

	// [ObsoleteAttribute] // RVA: 0x63547C Offset: 0x63547C VA: 0x63547C
	// // RVA: 0x287C8C0 Offset: 0x287C8C0 VA: 0x287C8C0
	// public static CriAtomExAsr.BusAnalyzerInfo GetBusAnalyzerInfo(int busId) { }

	// // RVA: 0x287CAE4 Offset: 0x287CAE4 VA: 0x287CAE4
	// public void Setup() { }

	// // RVA: 0x287CF88 Offset: 0x287CF88 VA: 0x287CF88
	// public void Shutdown() { }

	// // RVA: 0x287D264 Offset: 0x287D264 VA: 0x287D264
	private void Awake()
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x287D88C Offset: 0x287D88C VA: 0x287D88C Slot: 4
	protected override void OnEnable()
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x287D964 Offset: 0x287D964 VA: 0x287D964
	private void OnDestroy()
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x287DB40 Offset: 0x287DB40 VA: 0x287DB40 Slot: 6
	public override void CriInternalUpdate()
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x287DBCC Offset: 0x287DBCC VA: 0x287DBCC Slot: 7
	public override void CriInternalLateUpdate()
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x287B40C Offset: 0x287B40C VA: 0x287B40C
	// public CriAtomCueSheet GetCueSheetInternal(string name) { }

	// // RVA: 0x287B5EC Offset: 0x287B5EC VA: 0x287B5EC
	// public CriAtomCueSheet AddCueSheetInternal(string name, string acbFile, string awbFile, CriFsBinder binder) { }

	// // RVA: 0x287C088 Offset: 0x287C088 VA: 0x287C088
	// public void RemoveCueSheetInternal(string name) { }

	// // RVA: 0x287D5E8 Offset: 0x287D5E8 VA: 0x287D5E8
	// private void MargeCueSheet(CriAtomCueSheet[] newCueSheets, bool newDontRemoveExistsCueSheet) { }

	// // RVA: 0x287B7A4 Offset: 0x287B7A4 VA: 0x287B7A4
	// private CriAtomExAcb LoadAcbFile(CriFsBinder binder, string acbFile, string awbFile) { }

	// // RVA: 0x287BCA4 Offset: 0x287BCA4 VA: 0x287BCA4
	// private CriAtomExAcb LoadAcbData(byte[] acbData, CriFsBinder binder, string awbFile) { }

	// // RVA: 0x287BAF0 Offset: 0x287BAF0 VA: 0x287BAF0
	// private void LoadAcbFileAsync(CriAtomCueSheet cueSheet, CriFsBinder binder, string acbFile, string awbFile, bool loadAwbOnMemory) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6354D8 Offset: 0x6354D8 VA: 0x6354D8
	// // RVA: 0x287DEE0 Offset: 0x287DEE0 VA: 0x287DEE0
	// private IEnumerator LoadAcbFileCoroutine(CriAtomCueSheet cueSheet, CriFsBinder binder, string acbPath, string awbPath, bool loadAwbOnMemory) { }

	// // RVA: 0x287BF38 Offset: 0x287BF38 VA: 0x287BF38
	// private void LoadAcbDataAsync(CriAtomCueSheet cueSheet, byte[] acbData, CriFsBinder awbBinder, string awbFile, bool loadAwbOnMemory) { }

	// [IteratorStateMachineAttribute] // RVA: 0x635550 Offset: 0x635550 VA: 0x635550
	// // RVA: 0x287E00C Offset: 0x287E00C VA: 0x287E00C
	// private IEnumerator LoadAcbDataCoroutine(CriAtomCueSheet cueSheet, byte[] acbData, CriFsBinder awbBinder, string awbPath, bool loadAwbOnMemory) { }

	// [MonoPInvokeCallbackAttribute] // RVA: 0x6355C8 Offset: 0x6355C8 VA: 0x6355C8
	// // RVA: 0x28799E4 Offset: 0x28799E4 VA: 0x28799E4
	// public static void SequenceEventCallbackFromNative(string eventString) { }

	// [MonoPInvokeCallbackAttribute] // RVA: 0x635640 Offset: 0x635640 VA: 0x635640
	// // RVA: 0x2879AD4 Offset: 0x2879AD4 VA: 0x2879AD4
	// private static void SequenceCallbackFromNative(ref CriAtomExSequencer.CriAtomExSequenceEventInfo criAtomExSequenceInfo) { }

	// [MonoPInvokeCallbackAttribute] // RVA: 0x6356B8 Offset: 0x6356B8 VA: 0x6356B8
	// // RVA: 0x2879BC4 Offset: 0x2879BC4 VA: 0x2879BC4
	// public static void BeatSyncCallbackFromNative(ref CriAtomExBeatSync.Info info) { }

	// [MonoPInvokeCallbackAttribute] // RVA: 0x635730 Offset: 0x635730 VA: 0x635730
	// // RVA: 0x2879CB4 Offset: 0x2879CB4 VA: 0x2879CB4
	// public static void CueLinkCallbackFromNative(ref CriAtomEx.CueLinkInfo info) { }

	// // RVA: 0x287E5A0 Offset: 0x287E5A0 VA: 0x287E5A0
	// public static void SetEventCallback(CriAtomExSequencer.EventCbFunc func, string separator) { }

	// // RVA: 0x2879E20 Offset: 0x2879E20 VA: 0x2879E20
	// private static void RegisterEventCallbackChain(CriAtomExSequencer.EventCallback func) { }

	// // RVA: 0x287A0E0 Offset: 0x287A0E0 VA: 0x287A0E0
	// private static void UnregisterEventCallbackChain(CriAtomExSequencer.EventCallback func) { }

	// // RVA: 0x287E700 Offset: 0x287E700 VA: 0x287E700
	// public static void SetBeatSyncCallback(CriAtomExBeatSync.CbFunc func) { }

	// // RVA: 0x287A61C Offset: 0x287A61C VA: 0x287A61C
	// private static void RegisterBeatSyncCallbackChain(CriAtomExBeatSync.CbFunc func) { }

	// // RVA: 0x287A820 Offset: 0x287A820 VA: 0x287A820
	// private static void UnregisterBeatSyncCallbackChain(CriAtomExBeatSync.CbFunc func) { }

	// // RVA: 0x287ACA0 Offset: 0x287ACA0 VA: 0x287ACA0
	// private static void RegisterCueLinkCallbackChain(CriAtomEx.CueLinkCbFunc func) { }

	// // RVA: 0x287AEA8 Offset: 0x287AEA8 VA: 0x287AEA8
	// private static void UnregisterCueLinkCallbackChain(CriAtomEx.CueLinkCbFunc func) { }
}
