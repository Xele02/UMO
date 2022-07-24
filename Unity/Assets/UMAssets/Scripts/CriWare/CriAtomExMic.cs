using System;

namespace CriWare
{
	public class CriAtomExMic : CriDisposable
	{

		// private const string errorInvalidHandle = "[CRIWARE] Invalid native handle of CriAtomMic.";
		// private const string errorInvalidBufferLength = "[CRIWARE] Invalid buffer length for CriAtomMic.ReadData.";
		// private const string errorInvalidNumBuffers = "[CRIWARE] Number of buffers are not same with channels of CriAtomMic.";
		// private const string errorAlreadyInitialized = "[CRIWARE] CriAtomMic module is already initialized.";
		// private const string errorNotInitialized = "[CRIWARE] CriAtomMic module is not initialized.";
		// private IntPtr handle; // 0x18
		// private IntPtr[] bufferPointers; // 0x1C
		// private GCHandle[] gcHandles; // 0x20
		// private CriAudioWriteStream outputWriteStream; // 0x24
		// private static int _initializationCount; // 0x4

		// public static bool isInitialized { get; private set; } // 0x0

		// // RVA: 0x289B7E4 Offset: 0x289B7E4 VA: 0x289B7E4
		// public static void InitializeModule() { }

		// // RVA: 0x289BA04 Offset: 0x289BA04 VA: 0x289BA04
		// public static void FinalizeModule() { }

		// // RVA: 0x289BD80 Offset: 0x289BD80 VA: 0x289BD80
		// public static CriAtomExMic.DeviceInfo[] GetDevices() { }

		// // RVA: 0x289C188 Offset: 0x289C188 VA: 0x289C188
		// public static int GetNumDevices() { }

		// // RVA: 0x289C200 Offset: 0x289C200 VA: 0x289C200
		// public static Nullable<CriAtomExMic.DeviceInfo> GetDefaultDevice() { }

		// // RVA: 0x289C4CC Offset: 0x289C4CC VA: 0x289C4CC
		// public static bool IsFormatSupported(CriAtomExMic.Config config) { }

		// // RVA: 0x289C690 Offset: 0x289C690 VA: 0x289C690
		// public static CriAtomExMic Create(Nullable<CriAtomExMic.Config> config) { }

		// // RVA: 0x289CA74 Offset: 0x289CA74 VA: 0x289CA74
		private CriAtomExMic(IntPtr handle)
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x289CBD8 Offset: 0x289CBD8 VA: 0x289CBD8 Slot: 5
		public override void Dispose()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x289CC68 Offset: 0x289CC68 VA: 0x289CC68
		// private void Dispose(bool disposing) { }

		// // RVA: 0x289CE4C Offset: 0x289CE4C VA: 0x289CE4C
		public void Start()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x289CFD8 Offset: 0x289CFD8 VA: 0x289CFD8
		// public void Stop() { }

		// // RVA: 0x289CB54 Offset: 0x289CB54 VA: 0x289CB54
		// public int GetNumChannels() { }

		// // RVA: 0x289D280 Offset: 0x289D280 VA: 0x289D280
		// public int GetSamplingRate() { }

		// // RVA: 0x289D3E4 Offset: 0x289D3E4 VA: 0x289D3E4
		// public uint GetNumBufferredSamples() { }

		// // RVA: 0x289D54C Offset: 0x289D54C VA: 0x289D54C
		// public bool IsAvailable() { }

		// // RVA: 0x289D70C Offset: 0x289D70C VA: 0x289D70C
		// public uint ReadData(float[] bufferMono) { }

		// // RVA: 0x289D740 Offset: 0x289D740 VA: 0x289D740
		// public uint ReadData(float[] bufferMono, uint numToRead) { }

		// // RVA: 0x289D9B0 Offset: 0x289D9B0 VA: 0x289D9B0
		// public uint ReadData(float[] bufferL, float[] bufferR) { }

		// // RVA: 0x289D9F4 Offset: 0x289D9F4 VA: 0x289D9F4
		// public uint ReadData(float[] bufferL, float[] bufferR, uint numToRead) { }

		// // RVA: 0x289DC18 Offset: 0x289DC18 VA: 0x289DC18
		// public uint ReadData(float[][] buffers) { }

		// // RVA: 0x289DCA8 Offset: 0x289DCA8 VA: 0x289DCA8
		// public uint ReadData(float[][] buffers, uint numToRead) { }

		// // RVA: 0x289DE38 Offset: 0x289DE38 VA: 0x289DE38
		// public void SetOutputWriteStream(CriAudioWriteStream stream) { }

		// // RVA: 0x289E020 Offset: 0x289E020 VA: 0x289E020
		// public CriAudioReadStream GetOutputReadStream() { }

		// // RVA: 0x289E1D0 Offset: 0x289E1D0 VA: 0x289E1D0
		// public CriAtomExMic.Effect AttachEffect(IntPtr afxInterface, float[] configParameters) { }

		// // RVA: 0x289E568 Offset: 0x289E568 VA: 0x289E568
		// public void DetachEffect(CriAtomExMic.Effect effect) { }

		// // RVA: 0x289E72C Offset: 0x289E72C VA: 0x289E72C
		// public void SetEffectParameter(CriAtomExMic.Effect effect, int parameterIndex, float parameterValue) { }

		// // RVA: 0x289E8E0 Offset: 0x289E8E0 VA: 0x289E8E0
		// public float GetEffectParameter(CriAtomExMic.Effect effect, int parameterIndex) { }

		// // RVA: 0x289EA78 Offset: 0x289EA78 VA: 0x289EA78
		// public void SetEffectBypass(CriAtomExMic.Effect effect, bool bypass) { }

		// // RVA: 0x289EC0C Offset: 0x289EC0C VA: 0x289EC0C
		// public void UpdateEffectParameters(CriAtomExMic.Effect effect) { }

		// // RVA: 0x289D7E4 Offset: 0x289D7E4 VA: 0x289D7E4
		// private uint InternalReadDataFromBufferPointers(uint numToRead) { }

		// // RVA: 0x289D878 Offset: 0x289D878 VA: 0x289D878
		// private void InternalClearBuffers() { }

		// // RVA: 0x289B930 Offset: 0x289B930 VA: 0x289B930
		// private static extern void criAtomMicUnity_Initialize() { }

		// // RVA: 0x289BC78 Offset: 0x289BC78 VA: 0x289BC78
		// private static extern void criAtomMicUnity_Finalize() { }

		// // RVA: 0x289BF28 Offset: 0x289BF28 VA: 0x289BF28
		// private static extern int criAtomMic_GetNumDevices() { }

		// // RVA: 0x289C030 Offset: 0x289C030 VA: 0x289C030
		// private static extern bool criAtomMic_GetDevice(int index, out CriAtomExMic.DeviceInfo info) { }

		// // RVA: 0x289C3A8 Offset: 0x289C3A8 VA: 0x289C3A8
		// private static extern bool criAtomMic_GetDefaultDevice(out CriAtomExMic.DeviceInfo info) { }

		// // RVA: 0x289C570 Offset: 0x289C570 VA: 0x289C570
		// private static extern bool criAtomMic_IsFormatSupported(in CriAtomExMic.Config config) { }

		// // RVA: 0x289C928 Offset: 0x289C928 VA: 0x289C928
		// private static extern IntPtr criAtomMic_Create(in CriAtomExMic.Config config, IntPtr work, int work_size) { }

		// // RVA: 0x289CD40 Offset: 0x289CD40 VA: 0x289CD40
		// private static extern void criAtomMic_Destroy(IntPtr mic) { }

		// // RVA: 0x289CED0 Offset: 0x289CED0 VA: 0x289CED0
		// private static extern void criAtomMic_Start(IntPtr mic) { }

		// // RVA: 0x289D060 Offset: 0x289D060 VA: 0x289D060
		// private static extern void criAtomMic_Stop(IntPtr mic) { }

		// // RVA: 0x289D168 Offset: 0x289D168 VA: 0x289D168
		// private static extern int criAtomMic_GetNumChannels(IntPtr mic) { }

		// // RVA: 0x289D308 Offset: 0x289D308 VA: 0x289D308
		// private static extern int criAtomMic_GetSamplingRate(IntPtr mic) { }

		// // RVA: 0x289D468 Offset: 0x289D468 VA: 0x289D468
		// private static extern uint criAtomMic_GetNumBufferredSamples(IntPtr mic) { }

		// // RVA: 0x289D5F0 Offset: 0x289D5F0 VA: 0x289D5F0
		// private static extern bool criAtomMic_IsAvailable(IntPtr mic) { }

		// // RVA: 0x289EDA0 Offset: 0x289EDA0 VA: 0x289EDA0
		// private static extern uint criAtomMic_ReadData(IntPtr mic, IntPtr[] data, uint num_samples) { }

		// // RVA: 0x289DF30 Offset: 0x289DF30 VA: 0x289DF30
		// private static extern void criAtomMic_SetOutputWriteStream(IntPtr mic, IntPtr stream_cbfunc, IntPtr stream_ptr) { }

		// // RVA: 0x289E0D0 Offset: 0x289E0D0 VA: 0x289E0D0
		// private static extern IntPtr criAtomMic_GetOutputReadStream() { }

		// // RVA: 0x289EEC8 Offset: 0x289EEC8 VA: 0x289EEC8
		// private static extern int criAtomMic_CalculateWorkSizeForEffect(IntPtr mic, IntPtr afx_interface, float[] config_parameters, uint num_config_parameters) { }

		// // RVA: 0x289E310 Offset: 0x289E310 VA: 0x289E310
		// private static extern IntPtr criAtomMic_AttachEffect(IntPtr mic, IntPtr afx_interface, float[] config_parameters, uint num_config_parameters, IntPtr work, int work_size) { }

		// // RVA: 0x289E610 Offset: 0x289E610 VA: 0x289E610
		// private static extern void criAtomMic_DetachEffect(IntPtr mic, IntPtr effect) { }

		// // RVA: 0x289E458 Offset: 0x289E458 VA: 0x289E458
		// private static extern IntPtr criAtomMic_GetEffectInstance(IntPtr mic, IntPtr effect) { }

		// // RVA: 0x289EB20 Offset: 0x289EB20 VA: 0x289EB20
		// private static extern void criAtomMic_SetEffectBypass(IntPtr mic, IntPtr effect, bool bypass) { }

		// // RVA: 0x289E7E8 Offset: 0x289E7E8 VA: 0x289E7E8
		// private static extern void criAtomMic_SetEffectParameter(IntPtr mic, IntPtr effect, uint parameter_index, float parameter_value) { }

		// // RVA: 0x289E988 Offset: 0x289E988 VA: 0x289E988
		// private static extern float criAtomMic_GetEffectParameter(IntPtr mic, IntPtr effect, uint parameter_index) { }

		// // RVA: 0x289ECB0 Offset: 0x289ECB0 VA: 0x289ECB0
		// private static extern void criAtomMic_UpdateEffectParameters(IntPtr mic, IntPtr effect) { }
	}
}