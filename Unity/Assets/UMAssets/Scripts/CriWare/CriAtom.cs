// [AddComponentMenu] // RVA: 0x632684 Offset: 0x632684 VA: 0x632684
using System;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

namespace CriWare
{

	[AddComponentMenu("CRIWARE/CRI Atom")]
	public class CriAtom : CriMonoBehaviour
	{
		public string acfFile = ""; // 0x1C
		private bool acfIsLoading; // 0x20
#if CRIWARE_FORCE_LOAD_ASYNC
		private byte[] acfData = null;
#endif
		public CriAtomCueSheet[] cueSheets = new CriAtomCueSheet[0]; // 0x24
		public string dspBusSetting = ""; // 0x28
		public bool dontDestroyOnLoad = false; // 0x2C
		// private static CriAtomExSequencer.EventCallback eventUserCallback; // 0x0
		// private static CriAtomExSequencer.EventCbFunc eventUserCbFunc; // 0x4
		// [CompilerGeneratedAttribute] // RVA: 0x63461C Offset: 0x63461C VA: 0x63461C
		private static event CriAtomExBeatSync.CbFunc beatsyncUserCbFunc = null; // 0x8
		// private static CriAtomExBeatSync.CbFunc obsoleteBeatSyncFunc; // 0xC
		// [CompilerGeneratedAttribute] // RVA: 0x63462C Offset: 0x63462C VA: 0x63462C
		// private static CriAtomEx.CueLinkCbFunc cueLinkUserCbFunc; // 0x10
		private GCHandle acfRegisterGCHandle; // 0x30
		public bool dontRemoveExistsCueSheet; // 0x34

		private static CriAtom instance { get; set; } // 0x14
		// public static bool CueSheetsAreLoading { get; } 0x287C270
		internal static event CriAtomExBeatSync.CbFunc OnBeatSyncCallback
		{
			add { // 0x287A59C
				RegisterBeatSyncCallbackChain(value);
			}
			remove { // 0x287A7A0
				UnregisterBeatSyncCallbackChain(value);
			}
		}

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

		// // RVA: 0x287B09C Offset: 0x287B09C VA: 0x287B09C
		public static void AttachDspBusSetting(string settingName)
		{
			CriAtom.instance.dspBusSetting = settingName;
			if (!String.IsNullOrEmpty(settingName)) {
				CriAtomEx.AttachDspBusSetting(settingName);
			} else {
				CriAtomEx.DetachDspBusSetting();
			}
		}

		// // RVA: 0x287B2A0 Offset: 0x287B2A0 VA: 0x287B2A0
		// public static void DetachDspBusSetting() { }

		// // RVA: 0x287B370 Offset: 0x287B370 VA: 0x287B370
		public static CriAtomCueSheet GetCueSheet(string name)
		{
			return CriAtom.instance.GetCueSheetInternal(name);
		}

		// // RVA: 0x287B4B4 Offset: 0x287B4B4 VA: 0x287B4B4
		public static CriAtomCueSheet AddCueSheet(string name, string acbFile, string awbFile, CriFsBinder binder)
		{
		#if CRIWARE_FORCE_LOAD_ASYNC
			return CriAtom.AddCueSheetAsync(name, acbFile, awbFile, binder);
		#else
			CriAtomCueSheet cueSheet = CriAtom.instance.AddCueSheetInternal(name, acbFile, awbFile, binder);
			if (Application.isPlaying) {
				cueSheet.acb = CriAtom.instance.LoadAcbFile(binder, acbFile, awbFile);
			}
			return cueSheet;
		#endif
		}

		// // RVA: 0x287B9C0 Offset: 0x287B9C0 VA: 0x287B9C0
		// public static CriAtomCueSheet AddCueSheetAsync(string name, string acbFile, string awbFile, CriFsBinder binder, bool loadAwbOnMemory = False) { }

		// // RVA: 0x287BB60 Offset: 0x287BB60 VA: 0x287BB60
		// public static CriAtomCueSheet AddCueSheet(string name, byte[] acbData, string awbFile, CriFsBinder awbBinder) { }

		// // RVA: 0x287BDE8 Offset: 0x287BDE8 VA: 0x287BDE8
		// public static CriAtomCueSheet AddCueSheetAsync(string name, byte[] acbData, string awbFile, CriFsBinder awbBinder, bool loadAwbOnMemory = False) { }

		// // RVA: 0x287BF74 Offset: 0x287BF74 VA: 0x287BF74
		public static void RemoveCueSheet(string name)
		{
			if (CriAtom.instance == null) {
				return;
			}
			CriAtom.instance.RemoveCueSheetInternal(name);
		}

		// // RVA: 0x287C3FC Offset: 0x287C3FC VA: 0x287C3FC
		public static CriAtomExAcb GetAcb(string cueSheetName)
		{
			foreach (var cueSheet in CriAtom.instance.cueSheets) {
				if (cueSheetName == cueSheet.name) {
					return cueSheet.acb;
				}
			}
			Debug.LogWarning(cueSheetName + " is not loaded.");
			return null;
		}

		// // RVA: 0x287C564 Offset: 0x287C564 VA: 0x287C564
		// public static void SetCategoryVolume(string name, float volume) { }

		// // RVA: 0x287C56C Offset: 0x287C56C VA: 0x287C56C
		public static void SetCategoryVolume(int id, float volume)
		{
			CriAtomExCategory.SetVolume(id, volume);
		}

		// // RVA: 0x287C574 Offset: 0x287C574 VA: 0x287C574
		// public static float GetCategoryVolume(string name) { }

		// // RVA: 0x287C57C Offset: 0x287C57C VA: 0x287C57C
		public static float GetCategoryVolume(int id)
		{
			return CriAtomExCategory.GetVolume(id);
		}

		// // RVA: 0x287C584 Offset: 0x287C584 VA: 0x287C584
		// public static void SetBusAnalyzer(string busName, bool sw) { }

		// // RVA: 0x287C5DC Offset: 0x287C5DC VA: 0x287C5DC
		public static void SetBusAnalyzer(bool sw)
		{
			if(!sw)
			{
				CriAtomExAsr.DetachBusAnalyzer();
			}
			else
			{
				CriAtomExAsr.AttachBusAnalyzer(50, 1000);
			}
		}

		// // RVA: 0x287C69C Offset: 0x287C69C VA: 0x287C69C
		// public static CriAtomExAsr.BusAnalyzerInfo GetBusAnalyzerInfo(string busName) { }

		// [ObsoleteAttribute] // RVA: 0x63547C Offset: 0x63547C VA: 0x63547C
		// // RVA: 0x287C8C0 Offset: 0x287C8C0 VA: 0x287C8C0
		// public static CriAtomExAsr.BusAnalyzerInfo GetBusAnalyzerInfo(int busId) { }

		// // RVA: 0x287CAE4 Offset: 0x287CAE4 VA: 0x287CAE4
		public void Setup()
		{
			if (CriAtom.instance != null && CriAtom.instance != this) {
				var obj = CriAtom.instance.gameObject;
				CriAtom.instance.Shutdown();
				CriAtomEx.UnregisterAcf();
				GameObject.Destroy(obj);
			}

			CriAtom.instance = this;

			CriAtomPlugin.InitializeLibrary();

			if (!String.IsNullOrEmpty(this.acfFile)) {
				string acfPath = Path.Combine(CriWare.Common.streamingAssetsPath, this.acfFile);
				CriAtomEx.RegisterAcf(null, acfPath);
			}

			if (!String.IsNullOrEmpty(dspBusSetting)) {
				AttachDspBusSetting(dspBusSetting);
			}

			foreach (var cueSheet in this.cueSheets) {
				cueSheet.acb = this.LoadAcbFile(null, cueSheet.acbFile, cueSheet.awbFile);
			}

			if (this.dontDestroyOnLoad) {
				GameObject.DontDestroyOnLoad(this.gameObject);
			}
		}

		// // RVA: 0x287CF88 Offset: 0x287CF88 VA: 0x287CF88
		public void Shutdown()
		{
			foreach (var cueSheet in this.cueSheets) {
				if (cueSheet.acb != null) {
					cueSheet.acb.Dispose();
					cueSheet.acb = null;
				}
			}
			CriAtomPlugin.FinalizeLibrary();
			if (CriAtom.instance == this) {
				CriAtom.instance = null;
			}
		}

		// // RVA: 0x287D264 Offset: 0x287D264 VA: 0x287D264
		private void Awake()
		{
			if (CriAtom.instance != null && CriAtom.instance != this) {
				if (CriAtom.instance.acfFile != this.acfFile) {
					var obj = CriAtom.instance.gameObject;
					CriAtom.instance.Shutdown();
					CriAtomEx.UnregisterAcf();
					GameObject.Destroy(obj);
					return;
				}
				if (CriAtom.instance.dspBusSetting != this.dspBusSetting) {
					CriAtom.AttachDspBusSetting(this.dspBusSetting);
				}
				CriAtom.instance.MargeCueSheet(this.cueSheets, this.dontRemoveExistsCueSheet);
				GameObject.Destroy(this.gameObject);
			}
		}

		// // RVA: 0x287D88C Offset: 0x287D88C VA: 0x287D88C Slot: 4
		protected override void OnEnable()
		{
			base.OnEnable();
		#if UNITY_EDITOR
			if (CriAtomPlugin.previewCallback != null) {
				CriAtomPlugin.previewCallback();
			}
		#endif
			if (CriAtom.instance != null) {
				return;
			}

		#if CRIWARE_FORCE_LOAD_ASYNC
			this.SetupAsync();
		#else
			this.Setup();
		#endif
		}

		// // RVA: 0x287D964 Offset: 0x287D964 VA: 0x287D964
		private void OnDestroy()
		{
			if (this != CriAtom.instance) {
				return;
			}
			if (beatsyncUserCbFunc != null) {
				beatsyncUserCbFunc = null;
				CriAtomPlugin.CRIWARE2DDFB51C_criAtomUnity_SetBeatSyncCallback(IntPtr.Zero);
			}
			if (this.acfRegisterGCHandle.IsAllocated) {
				CriAtomEx.UnregisterAcf();
				this.acfRegisterGCHandle.Free();
			}
			this.Shutdown();
		}

		// // RVA: 0x287DB40 Offset: 0x287DB40 VA: 0x287DB40 Slot: 6
		public override void CriInternalUpdate()
		{
			CriAtomPlugin.criAtomUnity_ExecuteQueuedCueLinkCallbacks();
			CriAtomPlugin.CRIWARE148BE2F8_criAtomUnitySequencer_ExecuteQueuedEventCallbacks();
			CriAtomPlugin.CRIWARE75F073A2_criAtomUnity_ExecuteQueuedBeatSyncCallbacks();
			#if !UNITY_ANDROID
			ExternLib.LibCriWare.CheckSoundStatus();
			#endif
		}

		// // RVA: 0x287DBCC Offset: 0x287DBCC VA: 0x287DBCC Slot: 7
		public override void CriInternalLateUpdate()
		{
			return;
		}

		// // RVA: 0x287B40C Offset: 0x287B40C VA: 0x287B40C
		public CriAtomCueSheet GetCueSheetInternal(string name)
		{
			for (int i = 0; i < this.cueSheets.Length; i++) {
				CriAtomCueSheet cueSheet = this.cueSheets[i];
				if (cueSheet.name == name) {
					return cueSheet;
				}
			}
			return null;
		}

		// // RVA: 0x287B5EC Offset: 0x287B5EC VA: 0x287B5EC
		public CriAtomCueSheet AddCueSheetInternal(string name, string acbFile, string awbFile, CriFsBinder binder)
		{
			var cueSheets = new CriAtomCueSheet[this.cueSheets.Length + 1];
			this.cueSheets.CopyTo(cueSheets, 0);
			this.cueSheets = cueSheets;

			var cueSheet = new CriAtomCueSheet();
			this.cueSheets[this.cueSheets.Length - 1] = cueSheet;
			if (String.IsNullOrEmpty(name)) {
				cueSheet.name = Path.GetFileNameWithoutExtension(acbFile);
			} else {
				cueSheet.name = name;
			}
			cueSheet.acbFile = acbFile;
			cueSheet.awbFile = awbFile;
			return cueSheet;
		}

		// // RVA: 0x287C088 Offset: 0x287C088 VA: 0x287C088
		public void RemoveCueSheetInternal(string name)
		{
			int index = -1;
			for (int i = 0; i < this.cueSheets.Length; i++) {
				if (name == this.cueSheets[i].name) {
					index = i;
				}
			}
			if (index < 0) {
				return;
			}

			var cueSheet = this.cueSheets[index];
			if (cueSheet.acb != null) {
				cueSheet.acb.Dispose();
				cueSheet.acb = null;
			}

			var cueSheets = new CriAtomCueSheet[this.cueSheets.Length - 1];
			Array.Copy(this.cueSheets, 0, cueSheets, 0, index);
			Array.Copy(this.cueSheets, index + 1, cueSheets, index, this.cueSheets.Length - index - 1);
			this.cueSheets = cueSheets;
		}

		// // RVA: 0x287D5E8 Offset: 0x287D5E8 VA: 0x287D5E8
		private void MargeCueSheet(CriAtomCueSheet[] newCueSheets, bool newDontRemoveExistsCueSheet)
		{
			if (!newDontRemoveExistsCueSheet) {
				for (int i = 0; i < this.cueSheets.Length; ) {
					int index = Array.FindIndex(newCueSheets, sheet => sheet.name == this.cueSheets[i].name);
					if (index < 0) {
						CriAtom.RemoveCueSheet(this.cueSheets[i].name);
					} else {
						i++;
					}
				}
			}

			foreach (var sheet1 in newCueSheets) {
				var sheet2 = this.GetCueSheetInternal(sheet1.name);
				if (sheet2 == null) {
					CriAtom.AddCueSheet(null, sheet1.acbFile, sheet1.awbFile, null);
				}
			}
		}

		// // RVA: 0x287B7A4 Offset: 0x287B7A4 VA: 0x287B7A4
		private CriAtomExAcb LoadAcbFile(CriFsBinder binder, string acbFile, string awbFile)
		{
			if (String.IsNullOrEmpty(acbFile)) {
				return null;
			}

			string acbPath = acbFile;
			if ((binder == null) && CriWare.Common.IsStreamingAssetsPath(acbPath)) {
				acbPath = Path.Combine(CriWare.Common.streamingAssetsPath, acbPath);
			}

			string awbPath = awbFile;
			if (!String.IsNullOrEmpty(awbPath)) {
				if ((binder == null) && CriWare.Common.IsStreamingAssetsPath(awbPath)) {
					awbPath = Path.Combine(CriWare.Common.streamingAssetsPath, awbPath);
				}
			}

			return CriAtomExAcb.LoadAcbFile(binder, acbPath, awbPath);
		}

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

		// // RVA: 0x2879BC4 Offset: 0x2879BC4 VA: 0x2879BC4
		[AOT.MonoPInvokeCallback(typeof(CriAtomExBeatSync.CbFunc))]
		public static void BeatSyncCallbackFromNative(ref CriAtomExBeatSync.Info info)
		{
			if (beatsyncUserCbFunc != null) {
				beatsyncUserCbFunc(ref info);
			}
		}

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
		private static void RegisterBeatSyncCallbackChain(CriAtomExBeatSync.CbFunc func)
		{
			if (beatsyncUserCbFunc == null) {
				CriAtomExBeatSync.CbFunc delegateObject;
				delegateObject = new CriAtomExBeatSync.CbFunc(CriAtom.BeatSyncCallbackFromNative);
				var ptr = Marshal.GetFunctionPointerForDelegate(delegateObject);
				CriAtomPlugin.CRIWARE2DDFB51C_criAtomUnity_SetBeatSyncCallback(ptr);
			}
			beatsyncUserCbFunc += func;
		}

		// // RVA: 0x287A820 Offset: 0x287A820 VA: 0x287A820
		private static void UnregisterBeatSyncCallbackChain(CriAtomExBeatSync.CbFunc func) 
		{
			beatsyncUserCbFunc -= func;
			if (beatsyncUserCbFunc == null) {
				CriAtomPlugin.CRIWARE2DDFB51C_criAtomUnity_SetBeatSyncCallback(IntPtr.Zero);
			}
		}

		// // RVA: 0x287ACA0 Offset: 0x287ACA0 VA: 0x287ACA0
		// private static void RegisterCueLinkCallbackChain(CriAtomEx.CueLinkCbFunc func) { }

		// // RVA: 0x287AEA8 Offset: 0x287AEA8 VA: 0x287AEA8
		// private static void UnregisterCueLinkCallbackChain(CriAtomEx.CueLinkCbFunc func) { }
	}

	public static class CriAtomExCategory
	{
		// // RVA: 0x2899574 Offset: 0x2899574 VA: 0x2899574
		// public static void SetVolume(string name, float volume) { }

		// // RVA: 0x2899680 Offset: 0x2899680 VA: 0x2899680
		public static void SetVolume(int id, float volume)
		{
			criAtomExCategory_SetVolumeById(id, volume);
		}

		// // RVA: 0x2899770 Offset: 0x2899770 VA: 0x2899770
		// public static float GetVolume(string name) { }

		// // RVA: 0x2899880 Offset: 0x2899880 VA: 0x2899880
		public static float GetVolume(int id)
		{
			return criAtomExCategory_GetVolumeById(id);
		}

		// // RVA: 0x2899968 Offset: 0x2899968 VA: 0x2899968
		// public static void Mute(string name, bool mute) { }

		// // RVA: 0x2899A74 Offset: 0x2899A74 VA: 0x2899A74
		// public static void Mute(int id, bool mute) { }

		// // RVA: 0x2899B5C Offset: 0x2899B5C VA: 0x2899B5C
		// public static bool IsMuted(string name) { }

		// // RVA: 0x2899C6C Offset: 0x2899C6C VA: 0x2899C6C
		// public static bool IsMuted(int id) { }

		// // RVA: 0x2899D58 Offset: 0x2899D58 VA: 0x2899D58
		// public static void Solo(string name, bool solo, float muteVolume) { }

		// // RVA: 0x2899E6C Offset: 0x2899E6C VA: 0x2899E6C
		// public static void Solo(int id, bool solo, float muteVolume) { }

		// // RVA: 0x2899F5C Offset: 0x2899F5C VA: 0x2899F5C
		// public static bool IsSoloed(string name) { }

		// // RVA: 0x289A070 Offset: 0x289A070 VA: 0x289A070
		// public static bool IsSoloed(int id) { }

		// // RVA: 0x289A160 Offset: 0x289A160 VA: 0x289A160
		// public static void Pause(string name, bool pause) { }

		// // RVA: 0x289A26C Offset: 0x289A26C VA: 0x289A26C
		// public static void Pause(int id, bool pause) { }

		// // RVA: 0x289A354 Offset: 0x289A354 VA: 0x289A354
		// public static bool IsPaused(string name) { }

		// // RVA: 0x289A468 Offset: 0x289A468 VA: 0x289A468
		// public static bool IsPaused(int id) { }

		// // RVA: 0x289A558 Offset: 0x289A558 VA: 0x289A558
		// public static void SetAisacControl(string name, string controlName, float value) { }

		// [ObsoleteAttribute] // RVA: 0x635B84 Offset: 0x635B84 VA: 0x635B84
		// // RVA: 0x289A68C Offset: 0x289A68C VA: 0x289A68C
		// public static void SetAisac(string name, string controlName, float value) { }

		// // RVA: 0x289A690 Offset: 0x289A690 VA: 0x289A690
		// public static void SetAisacControl(int id, int controlId, float value) { }

		// [ObsoleteAttribute] // RVA: 0x635BB8 Offset: 0x635BB8 VA: 0x635BB8
		// // RVA: 0x289A790 Offset: 0x289A790 VA: 0x289A790
		// public static void SetAisac(int id, int controlId, float value) { }

		// // RVA: 0x289A798 Offset: 0x289A798 VA: 0x289A798
		// public static void SetReactParameter(string name, CriAtomExCategory.ReactParameter parameter) { }

		// // RVA: 0x289A970 Offset: 0x289A970 VA: 0x289A970
		// public static bool GetReactParameter(string name, out CriAtomExCategory.ReactParameter parameter) { }

		// // RVA: 0x289AAF0 Offset: 0x289AAF0 VA: 0x289AAF0
		// public static bool GetAttachedAisacInfoById(uint id, int aisacAttachedIndex, out CriAtomEx.AisacInfo aisacInfo) { }

		// // RVA: 0x289AE34 Offset: 0x289AE34 VA: 0x289AE34
		// public static bool GetAttachedAisacInfoByName(string name, int aisacAttachedIndex, out CriAtomEx.AisacInfo aisacInfo) { }

		// // RVA: 0x289B19C Offset: 0x289B19C VA: 0x289B19C
		// public static bool GetCurrentAisacControlValue(string categoryName, string aisacControlName, out float controlValue) { }

		// // RVA: 0x2899578 Offset: 0x2899578 VA: 0x2899578
		// private static extern void criAtomExCategory_SetVolumeByName(string name, float volume) { }

		// // RVA: 0x2899778 Offset: 0x2899778 VA: 0x2899778
		// private static extern float criAtomExCategory_GetVolumeByName(string name) { }

		// // RVA: 0x2899688 Offset: 0x2899688 VA: 0x2899688
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomExCategory_SetVolumeById(int id, float volume);
		#else
		private static void criAtomExCategory_SetVolumeById(int id, float volume)
		{
			ExternLib.LibCriWare.criAtomExCategory_SetVolumeById(id, volume);
		}
		#endif

		// // RVA: 0x2899888 Offset: 0x2899888 VA: 0x2899888
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern float criAtomExCategory_GetVolumeById(int id);
		#else
		private static float criAtomExCategory_GetVolumeById(int id)
		{
			return ExternLib.LibCriWare.criAtomExCategory_GetVolumeById(id);
		}
		#endif

		// // RVA: 0x2899A78 Offset: 0x2899A78 VA: 0x2899A78
		// private static extern void criAtomExCategory_MuteById(int id, bool mute) { }

		// // RVA: 0x2899C70 Offset: 0x2899C70 VA: 0x2899C70
		// private static extern bool criAtomExCategory_IsMutedById(int id) { }

		// // RVA: 0x2899970 Offset: 0x2899970 VA: 0x2899970
		// private static extern void criAtomExCategory_MuteByName(string name, bool mute) { }

		// // RVA: 0x2899B60 Offset: 0x2899B60 VA: 0x2899B60
		// private static extern bool criAtomExCategory_IsMutedByName(string name) { }

		// // RVA: 0x2899E70 Offset: 0x2899E70 VA: 0x2899E70
		// private static extern void criAtomExCategory_SoloById(int id, bool solo, float volume) { }

		// // RVA: 0x289A078 Offset: 0x289A078 VA: 0x289A078
		// private static extern bool criAtomExCategory_IsSoloedById(int id) { }

		// // RVA: 0x2899D60 Offset: 0x2899D60 VA: 0x2899D60
		// private static extern void criAtomExCategory_SoloByName(string name, bool solo, float volume) { }

		// // RVA: 0x2899F60 Offset: 0x2899F60 VA: 0x2899F60
		// private static extern bool criAtomExCategory_IsSoloedByName(string name) { }

		// // RVA: 0x289A270 Offset: 0x289A270 VA: 0x289A270
		// private static extern void criAtomExCategory_PauseById(int id, bool pause) { }

		// // RVA: 0x289A470 Offset: 0x289A470 VA: 0x289A470
		// private static extern bool criAtomExCategory_IsPausedById(int id) { }

		// // RVA: 0x289A168 Offset: 0x289A168 VA: 0x289A168
		// private static extern void criAtomExCategory_PauseByName(string name, bool pause) { }

		// // RVA: 0x289A358 Offset: 0x289A358 VA: 0x289A358
		// private static extern bool criAtomExCategory_IsPausedByName(string name) { }

		// // RVA: 0x289A698 Offset: 0x289A698 VA: 0x289A698
		// private static extern void criAtomExCategory_SetAisacControlById(int id, ushort controlId, float value) { }

		// // RVA: 0x289A560 Offset: 0x289A560 VA: 0x289A560
		// private static extern void criAtomExCategory_SetAisacControlByName(string name, string controlName, float value) { }

		// // RVA: 0x289A7F8 Offset: 0x289A7F8 VA: 0x289A7F8
		// private static extern void criAtomExCategory_SetReactParameter(string react_name, ref CriAtomExCategory.ReactParameter parameter) { }

		// // RVA: 0x289A978 Offset: 0x289A978 VA: 0x289A978
		// private static extern bool criAtomExCategory_GetReactParameter(string react_name, out CriAtomExCategory.ReactParameter parameter) { }

		// // RVA: 0x289AD30 Offset: 0x289AD30 VA: 0x289AD30
		// private static extern bool criAtomExCategory_GetAttachedAisacInfoById(uint id, int aisacAttachedIndex, IntPtr aisacInfo) { }

		// // RVA: 0x289B070 Offset: 0x289B070 VA: 0x289B070
		// private static extern bool criAtomExCategory_GetAttachedAisacInfoByName(string name, int aisacAttachedIndex, IntPtr aisacInfo) { }

		// // RVA: 0x289B1A0 Offset: 0x289B1A0 VA: 0x289B1A0
		// private static extern bool criAtomExCategory_GetCurrentAisacControlValueByName(string category_name, string aisac_control_name, out float control_value) { }
	}

	public class CriAtomExAsr
	{
		[StructLayout(LayoutKind.Sequential)]
		private struct BusAnalyzerConfig
		{
			public int interval; // 0x0
			public int peakHoldTime; // 0x4
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BusAnalyzerInfo
		{
			public int numChannels; // 0x0
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
			public float[] rmsLevels; // 0x4
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
			public float[] peakLevels; // 0x8
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
			public float[] peakHoldLevels; // 0xC

			// RVA: 0x81E0A4 Offset: 0x81E0A4 VA: 0x81E0A4
			public BusAnalyzerInfo(byte[] data)
			{
				if(data == null)
				{
					numChannels = 0;
					rmsLevels = new float[8];
					peakLevels = new float[8];
					peakHoldLevels = new float[8];
				}
				else
				{
					numChannels = BitConverter.ToInt32(data, 0);
					rmsLevels = new float[8];
					for(int i = 0; i < 8; i++)
					{
						rmsLevels[i] = BitConverter.ToSingle(data, 4 + i * 4);
					}
					peakLevels = new float[8];
					for(int i = 0; i < 8; i++)
					{
						peakLevels[i] = BitConverter.ToSingle(data, 36 + i * 4);
					}
					peakHoldLevels = new float[8];
					for(int i = 0; i < 8; i++)
					{
						peakHoldLevels[i] = BitConverter.ToSingle(data, 68 + i * 4);
					}
				}
			}
		}

		// // RVA: 0x287C5BC Offset: 0x287C5BC VA: 0x287C5BC
		// public static void AttachBusAnalyzer(string busName, int interval, int peakHoldTime) { }

		// // RVA: 0x287C644 Offset: 0x287C644 VA: 0x287C644
		public static void AttachBusAnalyzer(int interval, int peakHoldTime)
		{
			BusAnalyzerConfig config;
			config.interval = interval;
			config.peakHoldTime = peakHoldTime;
			for(int i = 0; i < 8; i++)
			{
				criAtomExAsr_AttachBusAnalyzer(i, ref config);
			}
		}

		// // RVA: 0x287C5D8 Offset: 0x287C5D8 VA: 0x287C5D8
		// public static void DetachBusAnalyzer(string busName) { }

		// // RVA: 0x287C678 Offset: 0x287C678 VA: 0x287C678
		public static void DetachBusAnalyzer()
		{
			for(int i = 0; i < 8; i++)
			{
				criAtomExAsr_DetachBusAnalyzer(i);
			}
		}

		// // RVA: 0x287C6D4 Offset: 0x287C6D4 VA: 0x287C6D4
		// public static void GetBusAnalyzerInfo(string busName, out CriAtomExAsr.BusAnalyzerInfo info) { }

		// [ObsoleteAttribute] // RVA: 0x635C8C Offset: 0x635C8C VA: 0x635C8C
		// // RVA: 0x287C8F8 Offset: 0x287C8F8 VA: 0x287C8F8
		// public static void GetBusAnalyzerInfo(int busId, out CriAtomExAsr.BusAnalyzerInfo info) { }

		// // RVA: 0x2895FD8 Offset: 0x2895FD8 VA: 0x2895FD8
		// public static void SetBusVolume(string busName, float volume) { }

		// [ObsoleteAttribute] // RVA: 0x635CC0 Offset: 0x635CC0 VA: 0x635CC0
		// // RVA: 0x28960E4 Offset: 0x28960E4 VA: 0x28960E4
		// public static void SetBusVolume(int busId, float volume) { }

		// // RVA: 0x2896208 Offset: 0x2896208 VA: 0x2896208
		// public static void SetBusSendLevel(string busName, string sendTo, float level) { }

		// [ObsoleteAttribute] // RVA: 0x635D28 Offset: 0x635D28 VA: 0x635D28
		// // RVA: 0x2896338 Offset: 0x2896338 VA: 0x2896338
		// public static void SetBusSendLevel(int busId, int sendTo, float level) { }

		// // RVA: 0x2896430 Offset: 0x2896430 VA: 0x2896430
		// public static void SetBusMatrix(string busName, int inputChannels, int outputChannels, float[] matrix) { }

		// [ObsoleteAttribute] // RVA: 0x635D5C Offset: 0x635D5C VA: 0x635D5C
		// // RVA: 0x2896564 Offset: 0x2896564 VA: 0x2896564
		// public static void SetBusMatrix(int busId, int inputChannels, int outputChannels, float[] matrix) { }

		// // RVA: 0x28966B8 Offset: 0x28966B8 VA: 0x28966B8
		// public static void SetEffectBypass(string busName, string effectName, bool bypass) { }

		// // RVA: 0x28967E4 Offset: 0x28967E4 VA: 0x28967E4
		// public static void SetEffectParameter(string busName, string effectName, uint parameterIndex, float parameterValue) { }

		// // RVA: 0x2896A60 Offset: 0x2896A60 VA: 0x2896A60
		// public static float GetEffectParameter(string busName, string effectName, uint parameterIndex) { }

		// // RVA: 0x2896B94 Offset: 0x2896B94 VA: 0x2896B94
		// public static bool RegisterEffectInterface(IntPtr afx_interface) { }

		// // RVA: 0x2896C88 Offset: 0x2896C88 VA: 0x2896C88
		// public static void UnregisterEffectInterface(IntPtr afx_interface) { }

		// // RVA: 0x2896D78 Offset: 0x2896D78 VA: 0x2896D78
		// public static void GetBusVolume(string busName, out float volume) { }

		// // RVA: 0x28956E8 Offset: 0x28956E8 VA: 0x28956E8
		// private static extern void criAtomExAsr_AttachBusAnalyzerByName(string busName, ref CriAtomExAsr.BusAnalyzerConfig config) { }

		// // RVA: 0x28957F8 Offset: 0x28957F8 VA: 0x28957F8
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomExAsr_AttachBusAnalyzer(int busNo, ref BusAnalyzerConfig config);
		#else
		private static void criAtomExAsr_AttachBusAnalyzer(int busNo, ref BusAnalyzerConfig config)
		{

		}
		#endif

		// // RVA: 0x28958E0 Offset: 0x28958E0 VA: 0x28958E0
		// private static extern void criAtomExAsr_DetachBusAnalyzerByName(string busName) { }

		// // RVA: 0x28959E8 Offset: 0x28959E8 VA: 0x28959E8
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomExAsr_DetachBusAnalyzer(int busNo);
		#else
		private static void criAtomExAsr_DetachBusAnalyzer(int busNo)
		{

		}
		#endif

		// // RVA: 0x2895AC8 Offset: 0x2895AC8 VA: 0x2895AC8
		// private static extern void criAtomExAsr_GetBusAnalyzerInfoByName(string busName, IntPtr info) { }

		// // RVA: 0x2895EF0 Offset: 0x2895EF0 VA: 0x2895EF0
		// private static extern void criAtomExAsr_GetBusAnalyzerInfo(int busNo, IntPtr info) { }

		// // RVA: 0x2895FE0 Offset: 0x2895FE0 VA: 0x2895FE0
		// private static extern void criAtomExAsr_SetBusVolumeByName(string busName, float volume) { }

		// // RVA: 0x28960E8 Offset: 0x28960E8 VA: 0x28960E8
		// private static extern void criAtomExAsr_SetBusVolume(int busNo, float volume) { }

		// // RVA: 0x2896210 Offset: 0x2896210 VA: 0x2896210
		// private static extern void criAtomExAsr_SetBusSendLevelByName(string busName, string sendtoName, float level) { }

		// // RVA: 0x2896340 Offset: 0x2896340 VA: 0x2896340
		// private static extern void criAtomExAsr_SetBusSendLevel(int busNo, int sendtoNo, float level) { }

		// // RVA: 0x2896448 Offset: 0x2896448 VA: 0x2896448
		// private static extern void criAtomExAsr_SetBusMatrixByName(string busName, int inputChannels, int outputChannels, float[] matrix) { }

		// // RVA: 0x2896580 Offset: 0x2896580 VA: 0x2896580
		// private static extern void criAtomExAsr_SetBusMatrix(int busNo, int inputChannels, int outputChannels, float[] matrix) { }

		// // RVA: 0x28966C0 Offset: 0x28966C0 VA: 0x28966C0
		// private static extern void criAtomExAsr_SetEffectBypass(string busName, string effectName, bool bypass) { }

		// // RVA: 0x2896940 Offset: 0x2896940 VA: 0x2896940
		// private static extern void criAtomExAsr_UpdateEffectParameters(string busName, string effectName) { }

		// // RVA: 0x2896810 Offset: 0x2896810 VA: 0x2896810
		// private static extern void criAtomExAsr_SetEffectParameter(string busName, string effectName, uint parameterIndex, float parameterValue) { }

		// // RVA: 0x2896A68 Offset: 0x2896A68 VA: 0x2896A68
		// private static extern float criAtomExAsr_GetEffectParameter(string busName, string effectName, uint parameterIndex) { }

		// // RVA: 0x2896B98 Offset: 0x2896B98 VA: 0x2896B98
		// private static extern bool criAtomExAsr_RegisterEffectInterface(IntPtr afx_interface) { }

		// // RVA: 0x2896C90 Offset: 0x2896C90 VA: 0x2896C90
		// private static extern void criAtomExAsr_UnregisterEffectInterface(IntPtr afx_interface) { }

		// // RVA: 0x2896D80 Offset: 0x2896D80 VA: 0x2896D80
		// private static extern void criAtomExAsr_GetBusVolumeByName(string busName, out float volume) { }
	}

}
