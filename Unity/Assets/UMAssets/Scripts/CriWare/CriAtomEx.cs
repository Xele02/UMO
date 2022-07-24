using System;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CriWare
{

	public class CriStructMemory<Type> : IDisposable
	{
		private GCHandle gch; // 0x0

		public byte[] bytes { get; private set; }// 0x0

		public IntPtr ptr {
			get { return gch.AddrOfPinnedObject(); }
		}
		// RVA: -1 Offset: -1
		//public IntPtr get_ptr() { }
		/* GenericInstMethod :
		|
		|-RVA: 0x26B84D4 Offset: 0x26B84D4 VA: 0x26B84D4
		|-CriStructMemory<CriAtomEx.AisacControlInfo>.get_ptr
		|
		|-RVA: 0x26B8808 Offset: 0x26B8808 VA: 0x26B8808
		|-CriStructMemory<CriAtomEx.AisacInfo>.get_ptr
		|
		|-RVA: 0x26B8B3C Offset: 0x26B8B3C VA: 0x26B8B3C
		|-CriStructMemory<CriAtomEx.CueInfo>.get_ptr
		|
		|-RVA: 0x26B8E70 Offset: 0x26B8E70 VA: 0x26B8E70
		|-CriStructMemory<CriAtomEx.GameVariableInfo>.get_ptr
		|
		|-RVA: 0x26B91A4 Offset: 0x26B91A4 VA: 0x26B91A4
		|-CriStructMemory<CriAtomEx.WaveformInfo>.get_ptr
		|
		|-RVA: 0x26B94D8 Offset: 0x26B94D8 VA: 0x26B94D8
		|-CriStructMemory<CriAtomExAcf.AcfDspBusInfo>.get_ptr
		|
		|-RVA: 0x26B980C Offset: 0x26B980C VA: 0x26B980C
		|-CriStructMemory<CriAtomExAcf.AcfDspBusLinkInfo>.get_ptr
		|
		|-RVA: 0x26B9B40 Offset: 0x26B9B40 VA: 0x26B9B40
		|-CriStructMemory<CriAtomExAcf.AcfDspSettingInfo>.get_ptr
		|
		|-RVA: 0x26B9E74 Offset: 0x26B9E74 VA: 0x26B9E74
		|-CriStructMemory<CriAtomExAcf.AcfDspSettingSnapshotInfo>.get_ptr
		|
		|-RVA: 0x26BA1A8 Offset: 0x26BA1A8 VA: 0x26BA1A8
		|-CriStructMemory<CriAtomExAcf.AcfInfo>.get_ptr
		|
		|-RVA: 0x26BA4DC Offset: 0x26BA4DC VA: 0x26BA4DC
		|-CriStructMemory<CriAtomExAcf.AisacGraphInfo>.get_ptr
		|
		|-RVA: 0x26BA810 Offset: 0x26BA810 VA: 0x26BA810
		|-CriStructMemory<CriAtomExAcf.CategoryInfo>.get_ptr
		|
		|-RVA: 0x26BAB44 Offset: 0x26BAB44 VA: 0x26BAB44
		|-CriStructMemory<CriAtomExAcf.GlobalAisacInfo>.get_ptr
		|
		|-RVA: 0x26BAE78 Offset: 0x26BAE78 VA: 0x26BAE78
		|-CriStructMemory<CriAtomExAcf.SelectorInfo>.get_ptr
		|
		|-RVA: 0x26BB1AC Offset: 0x26BB1AC VA: 0x26BB1AC
		|-CriStructMemory<CriAtomExAcf.SelectorLabelInfo>.get_ptr
		|
		|-RVA: 0x26BB4E0 Offset: 0x26BB4E0 VA: 0x26BB4E0
		|-CriStructMemory<CriAtomExAsr.BusAnalyzerInfo>.get_ptr
		|
		|-RVA: 0x26BB814 Offset: 0x26BB814 VA: 0x26BB814
		|-CriStructMemory<CriFsBinder.ContentsFileInfo>.get_ptr
		|
		|-RVA: 0x26BBB48 Offset: 0x26BBB48 VA: 0x26BBB48
		|-CriStructMemory<object>.get_ptr
		*/

		// RVA: -1 Offset: -1
		public CriStructMemory()
		{
			this.bytes = new byte[Marshal.SizeOf(typeof(Type))];
			this.gch = GCHandle.Alloc(this.bytes, GCHandleType.Pinned);
		}
		/* GenericInstMethod :
		|
		|-RVA: 0x26B84E0 Offset: 0x26B84E0 VA: 0x26B84E0
		|-CriStructMemory<CriAtomEx.AisacControlInfo>..ctor
		|
		|-RVA: 0x26B8814 Offset: 0x26B8814 VA: 0x26B8814
		|-CriStructMemory<CriAtomEx.AisacInfo>..ctor
		|
		|-RVA: 0x26B8B48 Offset: 0x26B8B48 VA: 0x26B8B48
		|-CriStructMemory<CriAtomEx.CueInfo>..ctor
		|
		|-RVA: 0x26B8E7C Offset: 0x26B8E7C VA: 0x26B8E7C
		|-CriStructMemory<CriAtomEx.GameVariableInfo>..ctor
		|
		|-RVA: 0x26B91B0 Offset: 0x26B91B0 VA: 0x26B91B0
		|-CriStructMemory<CriAtomEx.WaveformInfo>..ctor
		|
		|-RVA: 0x26B94E4 Offset: 0x26B94E4 VA: 0x26B94E4
		|-CriStructMemory<CriAtomExAcf.AcfDspBusInfo>..ctor
		|
		|-RVA: 0x26B9818 Offset: 0x26B9818 VA: 0x26B9818
		|-CriStructMemory<CriAtomExAcf.AcfDspBusLinkInfo>..ctor
		|
		|-RVA: 0x26B9B4C Offset: 0x26B9B4C VA: 0x26B9B4C
		|-CriStructMemory<CriAtomExAcf.AcfDspSettingInfo>..ctor
		|
		|-RVA: 0x26B9E80 Offset: 0x26B9E80 VA: 0x26B9E80
		|-CriStructMemory<CriAtomExAcf.AcfDspSettingSnapshotInfo>..ctor
		|
		|-RVA: 0x26BA1B4 Offset: 0x26BA1B4 VA: 0x26BA1B4
		|-CriStructMemory<CriAtomExAcf.AcfInfo>..ctor
		|
		|-RVA: 0x26BA4E8 Offset: 0x26BA4E8 VA: 0x26BA4E8
		|-CriStructMemory<CriAtomExAcf.AisacGraphInfo>..ctor
		|
		|-RVA: 0x26BA81C Offset: 0x26BA81C VA: 0x26BA81C
		|-CriStructMemory<CriAtomExAcf.CategoryInfo>..ctor
		|
		|-RVA: 0x26BAB50 Offset: 0x26BAB50 VA: 0x26BAB50
		|-CriStructMemory<CriAtomExAcf.GlobalAisacInfo>..ctor
		|
		|-RVA: 0x26BAE84 Offset: 0x26BAE84 VA: 0x26BAE84
		|-CriStructMemory<CriAtomExAcf.SelectorInfo>..ctor
		|
		|-RVA: 0x26BB1B8 Offset: 0x26BB1B8 VA: 0x26BB1B8
		|-CriStructMemory<CriAtomExAcf.SelectorLabelInfo>..ctor
		|
		|-RVA: 0x26BB4EC Offset: 0x26BB4EC VA: 0x26BB4EC
		|-CriStructMemory<CriAtomExAsr.BusAnalyzerInfo>..ctor
		|
		|-RVA: 0x26BB820 Offset: 0x26BB820 VA: 0x26BB820
		|-CriStructMemory<CriFsBinder.ContentsFileInfo>..ctor
		|
		|-RVA: 0x26BBB54 Offset: 0x26BBB54 VA: 0x26BBB54
		|-CriStructMemory<object>..ctor
		*/

		// RVA: -1 Offset: -1
		public CriStructMemory(int num)
		{
			this.bytes = new byte[Marshal.SizeOf(typeof(Type)) * num];
			this.gch = GCHandle.Alloc(this.bytes, GCHandleType.Pinned);
		}
		/* GenericInstMethod :
		|
		|-RVA: 0x26B8664 Offset: 0x26B8664 VA: 0x26B8664
		|-CriStructMemory<CriAtomEx.AisacControlInfo>..ctor
		|
		|-RVA: 0x26B8998 Offset: 0x26B8998 VA: 0x26B8998
		|-CriStructMemory<CriAtomEx.AisacInfo>..ctor
		|
		|-RVA: 0x26B8CCC Offset: 0x26B8CCC VA: 0x26B8CCC
		|-CriStructMemory<CriAtomEx.CueInfo>..ctor
		|
		|-RVA: 0x26B9000 Offset: 0x26B9000 VA: 0x26B9000
		|-CriStructMemory<CriAtomEx.GameVariableInfo>..ctor
		|
		|-RVA: 0x26B9334 Offset: 0x26B9334 VA: 0x26B9334
		|-CriStructMemory<CriAtomEx.WaveformInfo>..ctor
		|
		|-RVA: 0x26B9668 Offset: 0x26B9668 VA: 0x26B9668
		|-CriStructMemory<CriAtomExAcf.AcfDspBusInfo>..ctor
		|
		|-RVA: 0x26B999C Offset: 0x26B999C VA: 0x26B999C
		|-CriStructMemory<CriAtomExAcf.AcfDspBusLinkInfo>..ctor
		|
		|-RVA: 0x26B9CD0 Offset: 0x26B9CD0 VA: 0x26B9CD0
		|-CriStructMemory<CriAtomExAcf.AcfDspSettingInfo>..ctor
		|
		|-RVA: 0x26BA004 Offset: 0x26BA004 VA: 0x26BA004
		|-CriStructMemory<CriAtomExAcf.AcfDspSettingSnapshotInfo>..ctor
		|
		|-RVA: 0x26BA338 Offset: 0x26BA338 VA: 0x26BA338
		|-CriStructMemory<CriAtomExAcf.AcfInfo>..ctor
		|
		|-RVA: 0x26BA66C Offset: 0x26BA66C VA: 0x26BA66C
		|-CriStructMemory<CriAtomExAcf.AisacGraphInfo>..ctor
		|
		|-RVA: 0x26BA9A0 Offset: 0x26BA9A0 VA: 0x26BA9A0
		|-CriStructMemory<CriAtomExAcf.CategoryInfo>..ctor
		|
		|-RVA: 0x26BACD4 Offset: 0x26BACD4 VA: 0x26BACD4
		|-CriStructMemory<CriAtomExAcf.GlobalAisacInfo>..ctor
		|
		|-RVA: 0x26BB008 Offset: 0x26BB008 VA: 0x26BB008
		|-CriStructMemory<CriAtomExAcf.SelectorInfo>..ctor
		|
		|-RVA: 0x26BB33C Offset: 0x26BB33C VA: 0x26BB33C
		|-CriStructMemory<CriAtomExAcf.SelectorLabelInfo>..ctor
		|
		|-RVA: 0x26BB670 Offset: 0x26BB670 VA: 0x26BB670
		|-CriStructMemory<CriAtomExAsr.BusAnalyzerInfo>..ctor
		|
		|-RVA: 0x26BB9A4 Offset: 0x26BB9A4 VA: 0x26BB9A4
		|-CriStructMemory<CriFsBinder.ContentsFileInfo>..ctor
		|
		|-RVA: 0x26BBCD8 Offset: 0x26BBCD8 VA: 0x26BBCD8
		|-CriStructMemory<object>..ctor
		*/

		// RVA: -1 Offset: -1 Slot: 4
		public void Dispose()
		{
			this.gch.Free();
		}
		/* GenericInstMethod :
		|
		|-RVA: 0x26B87EC Offset: 0x26B87EC VA: 0x26B87EC
		|-CriStructMemory<CriAtomEx.AisacControlInfo>.Dispose
		|
		|-RVA: 0x26B8B20 Offset: 0x26B8B20 VA: 0x26B8B20
		|-CriStructMemory<CriAtomEx.AisacInfo>.Dispose
		|
		|-RVA: 0x26B8E54 Offset: 0x26B8E54 VA: 0x26B8E54
		|-CriStructMemory<CriAtomEx.CueInfo>.Dispose
		|
		|-RVA: 0x26B9188 Offset: 0x26B9188 VA: 0x26B9188
		|-CriStructMemory<CriAtomEx.GameVariableInfo>.Dispose
		|
		|-RVA: 0x26B94BC Offset: 0x26B94BC VA: 0x26B94BC
		|-CriStructMemory<CriAtomEx.WaveformInfo>.Dispose
		|
		|-RVA: 0x26B97F0 Offset: 0x26B97F0 VA: 0x26B97F0
		|-CriStructMemory<CriAtomExAcf.AcfDspBusInfo>.Dispose
		|
		|-RVA: 0x26B9B24 Offset: 0x26B9B24 VA: 0x26B9B24
		|-CriStructMemory<CriAtomExAcf.AcfDspBusLinkInfo>.Dispose
		|
		|-RVA: 0x26B9E58 Offset: 0x26B9E58 VA: 0x26B9E58
		|-CriStructMemory<CriAtomExAcf.AcfDspSettingInfo>.Dispose
		|
		|-RVA: 0x26BA18C Offset: 0x26BA18C VA: 0x26BA18C
		|-CriStructMemory<CriAtomExAcf.AcfDspSettingSnapshotInfo>.Dispose
		|
		|-RVA: 0x26BA4C0 Offset: 0x26BA4C0 VA: 0x26BA4C0
		|-CriStructMemory<CriAtomExAcf.AcfInfo>.Dispose
		|
		|-RVA: 0x26BA7F4 Offset: 0x26BA7F4 VA: 0x26BA7F4
		|-CriStructMemory<CriAtomExAcf.AisacGraphInfo>.Dispose
		|
		|-RVA: 0x26BAB28 Offset: 0x26BAB28 VA: 0x26BAB28
		|-CriStructMemory<CriAtomExAcf.CategoryInfo>.Dispose
		|
		|-RVA: 0x26BAE5C Offset: 0x26BAE5C VA: 0x26BAE5C
		|-CriStructMemory<CriAtomExAcf.GlobalAisacInfo>.Dispose
		|
		|-RVA: 0x26BB190 Offset: 0x26BB190 VA: 0x26BB190
		|-CriStructMemory<CriAtomExAcf.SelectorInfo>.Dispose
		|
		|-RVA: 0x26BB4C4 Offset: 0x26BB4C4 VA: 0x26BB4C4
		|-CriStructMemory<CriAtomExAcf.SelectorLabelInfo>.Dispose
		|
		|-RVA: 0x26BB7F8 Offset: 0x26BB7F8 VA: 0x26BB7F8
		|-CriStructMemory<CriAtomExAsr.BusAnalyzerInfo>.Dispose
		|
		|-RVA: 0x26BBB2C Offset: 0x26BBB2C VA: 0x26BBB2C
		|-CriStructMemory<CriFsBinder.ContentsFileInfo>.Dispose
		|
		|-RVA: 0x26BBE60 Offset: 0x26BBE60 VA: 0x26BBE60
		|-CriStructMemory<object>.Dispose
		*/
	}

	public static class CriAtomExBeatSync
	{
		public struct Info
		{
			public IntPtr playerHn; // 0x0
			public uint playbackId; // 0x4
			public uint barCount; // 0x8
			public uint beatCount; // 0xC
			public float beatProgress; // 0x10
			public float bpm; // 0x14
			public int offset; // 0x18
			public uint numBeats; // 0x1C
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void CbFunc(ref Info info);

		public static event CbFunc OnCallback {
			add {
				CriAtom.OnBeatSyncCallback += value; // 0x2898EB0
			}
			remove {
				CriAtom.OnBeatSyncCallback -= value; // 0x2898F34
			}
		}
	
		//[Obsolete("SetCallback is deprecated. Use OnBeatSyncCallback event", false)]
		// RVA: 0x2898FB8 Offset: 0x2898FB8 VA: 0x2898FB8
		// public static void SetCallback(CriAtomExBeatSync.CbFunc func){ }
	}

	public class CriAtomEx
	{

		public struct NativeVector
		{
			public float x; // 0x0
			public float y; // 0x4
			public float z; // 0x8

			// RVA: 0x81C61C Offset: 0x81C61C VA: 0x81C61C
			public NativeVector(float x, float y, float z)
			{
				this.x = x;
				this.y = y;
				this.z = z;
			}

			// RVA: 0x81C628 Offset: 0x81C628 VA: 0x81C628
			public NativeVector(Vector3 vector)
			{
				this.x = vector.x;
				this.y = vector.y;
				this.z = vector.z;
			}
		}

		public struct CueInfo
		{
			public int id; // 0x0
			public CriAtomEx.CueType type; // 0x4
			public readonly string name; // 0x8
			public readonly string userData; // 0xC
			public long length; // 0x10
			public ushort[] categories; // 0x18
			public short numLimits; // 0x1C
			public ushort numBlocks; // 0x1E
			public ushort numTracks; // 0x20
			public ushort numRelatedWaveForms; // 0x22
			public byte priority; // 0x24
			public byte headerVisibility; // 0x25
			public byte ignore_player_parameter; // 0x26
			public byte probability; // 0x27
			public CriAtomEx.PanType panType; // 0x28
			public CriAtomEx.CuePos3dInfo pos3dInfo; // 0x2C
			public CriAtomEx.GameVariableInfo gameVariableInfo; // 0x64

			// RVA: 0x81C4A4 Offset: 0x81C4A4 VA: 0x81C4A4
			public CueInfo(byte[] data, int startIndex)
			{			
				if (IntPtr.Size == 4) {
					this.id = BitConverter.ToInt32(data, startIndex + 0);
					this.type   = (CueType)BitConverter.ToInt32(data, startIndex + 4);
					this.name   = Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt32(data, startIndex + 8)));
					this.userData   = Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt32(data, startIndex + 12)));
					this.length = BitConverter.ToInt64(data, startIndex + 16);
					this.categories = new ushort[16];
					for (int i = 0; i < 16; ++i) {
						categories[i] = BitConverter.ToUInt16(data, startIndex + 24 + (2 * i));
					}
					this.numLimits  = BitConverter.ToInt16(data, startIndex + 56);
					this.numBlocks  = BitConverter.ToUInt16(data, startIndex + 58);
					this.numTracks  = BitConverter.ToUInt16(data, startIndex + 60);
					this.numRelatedWaveForms        = BitConverter.ToUInt16(data, startIndex + 62);
					this.priority                   = data[startIndex + 64];
					this.headerVisibility           = data[startIndex + 65];
					this.ignore_player_parameter    = data[startIndex + 66];
					this.probability                = data[startIndex + 67];
					this.panType                    = (PanType)BitConverter.ToInt32(data, startIndex + 68);
					this.pos3dInfo  = new CuePos3dInfo(data, startIndex + 72);
					this.gameVariableInfo   = new GameVariableInfo(data, startIndex + 132);
				} else {
					this.id = BitConverter.ToInt32(data, startIndex + 0);
					this.type   = (CueType)BitConverter.ToInt32(data, startIndex + 4);
					this.name   = Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt64(data, startIndex + 8)));
					this.userData   = Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt64(data, startIndex + 16)));
					this.length = BitConverter.ToInt64(data, startIndex + 24);
					this.categories = new ushort[16];
					for (int i = 0; i < 16; ++i) {
						categories[i] = BitConverter.ToUInt16(data, startIndex + 32 + (2 * i));
					}
					this.numLimits  = BitConverter.ToInt16(data, startIndex + 64);
					this.numBlocks  = BitConverter.ToUInt16(data, startIndex + 66);
					this.numTracks  = BitConverter.ToUInt16(data, startIndex + 68);
					this.numRelatedWaveForms        = BitConverter.ToUInt16(data, startIndex + 70);
					this.priority                   = data[startIndex + 72];
					this.headerVisibility           = data[startIndex + 73];
					this.ignore_player_parameter    = data[startIndex + 74];
					this.probability                = data[startIndex + 75];
					this.panType                    = (PanType)BitConverter.ToInt32(data, startIndex + 76);
					this.pos3dInfo  = new CuePos3dInfo(data, startIndex + 80);
					/* padded by 4 bytes */
					this.gameVariableInfo   = new GameVariableInfo(data, startIndex + 144);
				}
			}
		}

		[Serializable]
		public struct Randomize3dConfig
		{
			public const int NumOfCalcParams = 3;
			[SerializeField]
			private bool followsOriginalSource; // 0x0
			[SerializeField]
			private CriAtomEx.Randomize3dCalcType calculationType; // 0x4
			[SerializeField]
			private float[] calculationParameters; // 0x8

			public bool FollowsOriginalSource { get { return followsOriginalSource; }  } // 0x81C634
			public CriAtomEx.Randomize3dCalcType CalculationType { get { return calculationType; }  } // 0x81C63C
			public float CalculationParameter1 { get { return calculationParameters[0]; } } // 0x81C644
			public float CalculationParameter2 { get { return calculationParameters[1]; } } // 0x81C64C
			public float CalculationParameter3 { get { return calculationParameters[2]; } } // 0x81C654

			// // RVA: 0x81C65C Offset: 0x81C65C VA: 0x81C65C
			internal Randomize3dConfig(byte[] data, int startIndex)
			{
				this.followsOriginalSource = BitConverter.ToInt32(data, startIndex + 0) != 0;
				this.calculationType = (Randomize3dCalcType)BitConverter.ToInt32(data, startIndex + 4);
				this.calculationParameters = new float[NumOfCalcParams];
				for (int i = 0; i < NumOfCalcParams; ++i) {
					calculationParameters[i] = BitConverter.ToSingle(data, startIndex + 8 + (4 * i));
				}
			}

			// // RVA: 0x81C664 Offset: 0x81C664 VA: 0x81C664
			public Randomize3dConfig(bool followsOriginalSource, CriAtomEx.Randomize3dCalcType calculationType, float param1 = 0, float param2 = 0, float param3 = 0)
			{
				this.followsOriginalSource = followsOriginalSource;
				this.calculationType = calculationType;
				this.calculationParameters = new float[NumOfCalcParams];
				this.calculationParameters[0] = param1;
				this.calculationParameters[1] = param2;
				this.calculationParameters[2] = param3;
			}

			// // RVA: 0x81C690 Offset: 0x81C690 VA: 0x81C690
			public Randomize3dConfig(int dummy) : this()
			{
				followsOriginalSource = false;
				calculationType = Randomize3dCalcType.Rectangle;
				this.calculationParameters = new float[NumOfCalcParams];
				this.ClearCalcParams();
			}

			// // RVA: 0x81C698 Offset: 0x81C698 VA: 0x81C698
			public void ClearCalcParams(float initVal = 0)
			{
				for (int i = 0; i < NumOfCalcParams; ++i) {
					calculationParameters[i] = initVal;
				}
			}

			// // RVA: 0x81C6A0 Offset: 0x81C6A0 VA: 0x81C6A0
			// public bool GetParamByType(CriAtomEx.Randomize3dParamType paramType, ref float paramVal) { }

			// // RVA: 0x81C6A8 Offset: 0x81C6A8 VA: 0x81C6A8
			// public bool SetParamByType(CriAtomEx.Randomize3dParamType paramType, float paramVal) { }
		}

		public struct CuePos3dInfo
		{
			public float coneInsideAngle; // 0x0
			public float coneOutsideAngle; // 0x4
			public float minAttenuationDistance; // 0x8
			public float maxAttenuationDistance; // 0xC
			public float sourceRadius; // 0x10
			public float interiorDistance; // 0x14
			public float dopplerFactor; // 0x18
			public CriAtomEx.Randomize3dConfig randomPos; // 0x1C
			public ushort distanceAisacControl; // 0x28
			public ushort listenerBaseAngleAisacControl; // 0x2A
			public ushort sourceBaseAngleAisacControl; // 0x2C
			public ushort listenerBaseElevationAisacControl; // 0x2E
			public ushort sourceBaseElevationAisacControl; // 0x30
			public ushort[] reserved; // 0x34

			// RVA: 0x81C600 Offset: 0x81C600 VA: 0x81C600
			public CuePos3dInfo(byte[] data, int startIndex)
			{
				this.coneInsideAngle = BitConverter.ToSingle(data, startIndex + 0);
				this.coneOutsideAngle = BitConverter.ToSingle(data, startIndex + 4);
				this.minAttenuationDistance = BitConverter.ToSingle(data, startIndex + 8);
				this.maxAttenuationDistance = BitConverter.ToSingle(data, startIndex + 12);
				this.sourceRadius = BitConverter.ToSingle(data, startIndex + 16);
				this.interiorDistance = BitConverter.ToSingle(data, startIndex + 20);
				this.dopplerFactor = BitConverter.ToSingle(data, startIndex + 24);
				this.randomPos = new Randomize3dConfig(data, startIndex + 28);
				this.distanceAisacControl = BitConverter.ToUInt16(data, startIndex + 48);
				this.listenerBaseAngleAisacControl = BitConverter.ToUInt16(data, startIndex + 50);
				this.sourceBaseAngleAisacControl = BitConverter.ToUInt16(data, startIndex + 52);
				this.listenerBaseElevationAisacControl = BitConverter.ToUInt16(data, startIndex + 54);
				this.sourceBaseElevationAisacControl = BitConverter.ToUInt16(data, startIndex + 56);
				this.reserved = new ushort[1];
				for (int i = 0; i < 1; ++i)
				{
					reserved[i] = BitConverter.ToUInt16(data, startIndex + 58 + (2 * i));
				}
			}
		}

		public struct GameVariableInfo
		{
			public readonly string name; // 0x0
			public uint id; // 0x4
			public float gameValue; // 0x8

			// RVA: 0x81C608 Offset: 0x81C608 VA: 0x81C608
			public GameVariableInfo(byte[] data, int startIndex)
			{
				if (IntPtr.Size == 4) {
					this.name = Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt32(data, startIndex + 0)));
					this.id = BitConverter.ToUInt32(data, startIndex + 4);
					this.gameValue  = BitConverter.ToSingle(data, startIndex + 8);
				} else {
					this.name   = Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt64(data, startIndex + 0)));
					this.id = BitConverter.ToUInt32(data, startIndex + 8);
					this.gameValue  = BitConverter.ToSingle(data, startIndex + 12);
				}
			}

			// RVA: 0x81C610 Offset: 0x81C610 VA: 0x81C610
			public GameVariableInfo(string name, uint id, float gameValue)
			{
				this.name       = name;
				this.id         = id;
				this.gameValue  = gameValue;
			}
		}

		public enum ResumeMode
		{
			AllPlayback = 0,
			PausedPlayback = 1,
			PreparedPlayback = 2,
		}

		public enum VoiceAllocationMethod
		{
			Once = 0,
			Retry = 1,
		}

		public enum PanType
		{
			Unknown = -1,
			Pan3d = 0,
			Pos3d = 1,
			Auto = 2,
		}

		public enum CueType
		{
			Polyphonic = 0,
			Sequential = 1,
			Shuffle = 2,
			Random = 3,
			RandomNoRepeat = 4,
			SwitchGameVariable = 5,
			ComboSequential = 6,
			SwitchSelector = 7,
			TrackTransitionBySelector = 8,
		}

		public enum Randomize3dCalcType
		{
			None = -1,
			Rectangle = 0,
			Cuboid = 1,
			Circle = 2,
			Cylinder = 3,
			Sphere = 4,
			List = 6,
		}

		public enum SoundRendererType
		{
			Default = 0,
			Native = 1,
			Asr = 2,
			Hw1 = 1,
			Hw2 = 9,
		}

		public enum Randomize3dParamType
		{
			None = 0,
			Width = 1,
			Depth = 2,
			Height = 3,
			Radius = 4,
		}

		public const uint InvalidAisacControlId = 0xffffu;
		public static readonly Dictionary<CriAtomEx.Randomize3dCalcType, CriAtomEx.Randomize3dParamType[]> randomize3dParamTable = new Dictionary<CriAtomEx.Randomize3dCalcType, CriAtomEx.Randomize3dParamType[]>
																								{
																									{Randomize3dCalcType.None, new CriAtomEx.Randomize3dParamType[3]},
																									{Randomize3dCalcType.Rectangle, new CriAtomEx.Randomize3dParamType[3]},
																									{Randomize3dCalcType.Cuboid, new CriAtomEx.Randomize3dParamType[3] {CriAtomEx.Randomize3dParamType.Width, CriAtomEx.Randomize3dParamType.Depth, CriAtomEx.Randomize3dParamType.Height}},
																									{Randomize3dCalcType.Circle, new CriAtomEx.Randomize3dParamType[3]},
																									{Randomize3dCalcType.Cylinder, new CriAtomEx.Randomize3dParamType[3]},
																									{Randomize3dCalcType.Sphere, new CriAtomEx.Randomize3dParamType[3]},
																									{Randomize3dCalcType.List, new CriAtomEx.Randomize3dParamType[3]}
																								}; // 0x0
		public static CriAtomEx.SoundRendererType androidDefaultSoundRendererType = SoundRendererType.Default; // 0x4

		// // RVA: 0x28801D4 Offset: 0x28801D4 VA: 0x28801D4
		// public static void SetSpeakerAngle(CriAtomEx.SpeakerAngles6ch speakerAngle) { }

		// // RVA: 0x2880344 Offset: 0x2880344 VA: 0x2880344
		// public static void SetSpeakerAngle(CriAtomEx.SpeakerAngles8ch speakerAngle) { }

		// // RVA: 0x28804C4 Offset: 0x28804C4 VA: 0x28804C4
		// public static void SetVirtualSpeakerAngle(CriAtomEx.SpeakerAngles6ch speakerAngle) { }

		// // RVA: 0x2880634 Offset: 0x2880634 VA: 0x2880634
		// public static void SetVirtualSpeakerAngle(CriAtomEx.SpeakerAngles8ch speakerAngle) { }

		// // RVA: 0x28807B4 Offset: 0x28807B4 VA: 0x28807B4
		// public static void ControlVirtualSpeakerSetting(bool sw) { }

		// // RVA: 0x2880920 Offset: 0x2880920 VA: 0x2880920
		// public static void add_OnCueLinkCallback(CriAtomEx.CueLinkCbFunc value) { }

		// // RVA: 0x28809A0 Offset: 0x28809A0 VA: 0x28809A0
		// public static void remove_OnCueLinkCallback(CriAtomEx.CueLinkCbFunc value) { }

		// // RVA: 0x287D1AC Offset: 0x287D1AC VA: 0x287D1AC
		public static void RegisterAcf(CriFsBinder binder, string acfPath)
		{
			#if UNITY_ANDROID
			IntPtr binderHandle = (binder != null) ? binder.nativeHandle : IntPtr.Zero;
			criAtomEx_RegisterAcfFile(binderHandle, acfPath, IntPtr.Zero, 0);
			#else
			criAtomEx_RegisterAcfFile(binder, acfPath, IntPtr.Zero, 0);
			#endif
		}

		// // RVA: 0x2880B7C Offset: 0x2880B7C VA: 0x2880B7C
		// public static void RegisterAcf(IntPtr acfData, int dataSize) { }

		// [ObsoleteAttribute] // RVA: 0x635B38 Offset: 0x635B38 VA: 0x635B38
		// // RVA: 0x2880CFC Offset: 0x2880CFC VA: 0x2880CFC
		// public static void RegisterAcf(byte[] acfData) { }

		// // RVA: 0x287D134 Offset: 0x287D134 VA: 0x287D134
		public static void UnregisterAcf()
		{
			criAtomEx_UnregisterAcf();
		}

		// // RVA: 0x2880F94 Offset: 0x2880F94 VA: 0x2880F94
		// public static string GetAppliedDspBusSnapshotName() { }

		// // RVA: 0x287B1A0 Offset: 0x287B1A0 VA: 0x287B1A0
		public static void AttachDspBusSetting(string settingName)
		{
			criAtomEx_AttachDspBusSetting(settingName, IntPtr.Zero, 0);
		}

		// // RVA: 0x287B228 Offset: 0x287B228 VA: 0x287B228
		public static void DetachDspBusSetting()
		{
			criAtomEx_DetachDspBusSetting();
		}

		// // RVA: 0x2881328 Offset: 0x2881328 VA: 0x2881328
		// public static void ApplyDspBusSnapshot(string snapshot_name, int time_ms) { }

		// // RVA: 0x28814B4 Offset: 0x28814B4 VA: 0x28814B4
		// public static int GetNumGameVariables() { }

		// // RVA: 0x2881608 Offset: 0x2881608 VA: 0x2881608
		// public static bool GetGameVariableInfo(ushort index, out CriAtomEx.GameVariableInfo info) { }

		// // RVA: 0x2881AF8 Offset: 0x2881AF8 VA: 0x2881AF8
		// public static float GetGameVariable(uint game_variable_id) { }

		// // RVA: 0x2881C58 Offset: 0x2881C58 VA: 0x2881C58
		// public static float GetGameVariable(string game_variable_name) { }

		// // RVA: 0x2881DDC Offset: 0x2881DDC VA: 0x2881DDC
		// public static void SetGameVariable(uint game_variable_id, float game_variable_value) { }

		// // RVA: 0x2881F50 Offset: 0x2881F50 VA: 0x2881F50
		// public static void SetGameVariable(string game_variable_name, float game_variable_value) { }

		// // RVA: 0x28820DC Offset: 0x28820DC VA: 0x28820DC
		public static void SetRandomSeed(uint seed)
		{
			criAtomEx_SetRandomSeed(seed);
		}

		// // RVA: 0x2882274 Offset: 0x2882274 VA: 0x2882274
		// public static void ResetPerformanceMonitor() { }

		// // RVA: 0x28823C8 Offset: 0x28823C8 VA: 0x28823C8
		// public static void GetPerformanceInfo(out CriAtomEx.PerformanceInfo info) { }

		// // RVA: 0x2882524 Offset: 0x2882524 VA: 0x2882524
		// public static void SetGlobalLabelToSelectorByIndex(ushort selector_index, ushort label_index) { }

		// // RVA: 0x28826A8 Offset: 0x28826A8 VA: 0x28826A8
		// public static void SetGlobalLabelToSelectorByName(string selector_name, string label_name) { }

		// // RVA: 0x2882858 Offset: 0x2882858 VA: 0x2882858
		// public static void Lock() { }

		// // RVA: 0x28829C4 Offset: 0x28829C4 VA: 0x28829C4
		// public static void Unlock() { }

		// // RVA: 0x2882B38 Offset: 0x2882B38 VA: 0x2882B38
		// public static void SetOutputAudioDevice_PC(string deviceId) { }

		// // RVA: 0x2882B3C Offset: 0x2882B3C VA: 0x2882B3C
		// public static bool LoadAudioDeviceList_PC() { }

		// // RVA: 0x2882B44 Offset: 0x2882B44 VA: 0x2882B44
		// public static int GetNumAudioDevices_PC() { }

		// // RVA: 0x2882B4C Offset: 0x2882B4C VA: 0x2882B4C
		// public static string GetAudioDeviceName_PC(int index) { }

		// // RVA: 0x2882B54 Offset: 0x2882B54 VA: 0x2882B54
		// public static void SetOutputAudioDevice_PC(int index) { }

		// // RVA: 0x2882B58 Offset: 0x2882B58 VA: 0x2882B58
		// public static void SetOutputVolume_VITA(float volume) { }

		// // RVA: 0x2882B5C Offset: 0x2882B5C VA: 0x2882B5C
		// public static bool IsBgmPortAcquired_VITA() { }

		// // RVA: 0x2882B64 Offset: 0x2882B64 VA: 0x2882B64
		// public static bool IsSoundStopped_IOS() { }

		// // RVA: 0x2882B6C Offset: 0x2882B6C VA: 0x2882B6C
		// public static void EnableAudioSessionRestoration_IOS(bool flag) { }

		// // RVA: 0x2880A20 Offset: 0x2880A20 VA: 0x2880A20
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern bool criAtomEx_RegisterAcfFile(IntPtr binder, string path, IntPtr work, int workSize);
		#else
		private static bool criAtomEx_RegisterAcfFile(CriFsBinder binder, string path, IntPtr work, int workSize)
		{
			return ExternLib.LibCriWare.criAtomEx_RegisterAcfFile(binder, path, work, workSize);
		}
		#endif

		// // RVA: 0x2880C18 Offset: 0x2880C18 VA: 0x2880C18
		// private static extern void criAtomEx_RegisterAcfData(IntPtr acfData, int acfDataSize, IntPtr work, int workSize) { }

		// // RVA: 0x2880DA0 Offset: 0x2880DA0 VA: 0x2880DA0
		// private static extern void criAtomEx_RegisterAcfData(byte[] acfData, int acfDataSize, IntPtr work, int workSize) { }

		// // RVA: 0x2880E90 Offset: 0x2880E90 VA: 0x2880E90
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomEx_UnregisterAcf();
		#else
		private static void criAtomEx_UnregisterAcf()
		{
			ExternLib.LibCriWare.criAtomEx_UnregisterAcf();
		}
		#endif

		// // RVA: 0x2881140 Offset: 0x2881140 VA: 0x2881140
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomEx_AttachDspBusSetting(string settingName, IntPtr work, int workSize);
		#else
		private static void criAtomEx_AttachDspBusSetting(string settingName, IntPtr work, int workSize)
		{
			ExternLib.LibCriWare.criAtomEx_AttachDspBusSetting(settingName, work, workSize);
		}
		#endif

		// // RVA: 0x2881250 Offset: 0x2881250 VA: 0x2881250
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomEx_DetachDspBusSetting();
		#else
		private static void criAtomEx_DetachDspBusSetting()
		{
			ExternLib.LibCriWare.criAtomEx_DetachDspBusSetting();
		}
		#endif

		// // RVA: 0x28813B0 Offset: 0x28813B0 VA: 0x28813B0
		// private static extern void criAtomEx_ApplyDspBusSnapshot(string snapshot_name, int time_ms) { }

		// // RVA: 0x2881060 Offset: 0x2881060 VA: 0x2881060
		// private static extern IntPtr criAtomEx_GetAppliedDspBusSnapshotName() { }

		// // RVA: 0x2881530 Offset: 0x2881530 VA: 0x2881530
		// private static extern int criAtomEx_GetNumGameVariables() { }

		// // RVA: 0x2881840 Offset: 0x2881840 VA: 0x2881840
		// private static extern bool criAtomEx_GetGameVariableInfo(ushort index, IntPtr game_variable_info) { }

		// // RVA: 0x2881B78 Offset: 0x2881B78 VA: 0x2881B78
		// private static extern float criAtomEx_GetGameVariableById(uint game_variable_id) { }

		// // RVA: 0x2881CD8 Offset: 0x2881CD8 VA: 0x2881CD8
		// private static extern float criAtomEx_GetGameVariableByName(string game_variable_name) { }

		// // RVA: 0x2881E68 Offset: 0x2881E68 VA: 0x2881E68
		// private static extern void criAtomEx_SetGameVariableById(uint game_variable_id, float game_variable_value) { }

		// // RVA: 0x2881FD8 Offset: 0x2881FD8 VA: 0x2881FD8
		// private static extern void criAtomEx_SetGameVariableByName(string game_variable_name, float game_variable_value) { }

		// // RVA: 0x2882160 Offset: 0x2882160 VA: 0x2882160
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomEx_SetRandomSeed(uint seed);
		#else
		private static void criAtomEx_SetRandomSeed(uint seed)
		{
			ExternLib.LibCriWare.criAtomEx_SetRandomSeed(seed);
		}
		#endif

		// // RVA: 0x28828D0 Offset: 0x28828D0 VA: 0x28828D0
		// private static extern void criAtomEx_Lock() { }

		// // RVA: 0x2882A40 Offset: 0x2882A40 VA: 0x2882A40
		// private static extern void criAtomEx_Unlock() { }

		// // RVA: 0x28822F0 Offset: 0x28822F0 VA: 0x28822F0
		// private static extern void criAtom_ResetPerformanceMonitor() { }

		// // RVA: 0x2882448 Offset: 0x2882448 VA: 0x2882448
		// private static extern void criAtom_GetPerformanceInfo(out CriAtomEx.PerformanceInfo info) { }

		// // RVA: 0x28825B0 Offset: 0x28825B0 VA: 0x28825B0
		// private static extern void criAtomExAcf_SetGlobalLabelToSelectorByIndex(ushort selector_index, ushort label_index) { }

		// // RVA: 0x2882730 Offset: 0x2882730 VA: 0x2882730
		// private static extern void criAtomExAcf_SetGlobalLabelToSelectorByName(string selector_name, string label_name) { }

		// // RVA: 0x2880270 Offset: 0x2880270 VA: 0x2880270
		// private static extern void criAtomEx_SetSpeakerAngleArray(CriAtomEx.SpeakerSystem speaker_system, ref CriAtomEx.SpeakerAngles6ch angle_array) { }

		// // RVA: 0x28803F0 Offset: 0x28803F0 VA: 0x28803F0
		// private static extern void criAtomEx_SetSpeakerAngleArray(CriAtomEx.SpeakerSystem speaker_system, ref CriAtomEx.SpeakerAngles8ch angle_array) { }

		// // RVA: 0x2880560 Offset: 0x2880560 VA: 0x2880560
		// private static extern void criAtomEx_SetVirtualSpeakerAngleArray(CriAtomEx.SpeakerSystem speaker_system, ref CriAtomEx.SpeakerAngles6ch angle_array) { }

		// // RVA: 0x28806E0 Offset: 0x28806E0 VA: 0x28806E0
		// private static extern void criAtomEx_SetVirtualSpeakerAngleArray(CriAtomEx.SpeakerSystem speaker_system, ref CriAtomEx.SpeakerAngles8ch angle_array) { }

		// // RVA: 0x2880838 Offset: 0x2880838 VA: 0x2880838
		// private static extern void criAtomEx_ControlVirtualSpeakerSetting(bool sw) { }

		// // RVA: 0x2882B70 Offset: 0x2882B70 VA: 0x2882B70
		// public static extern void criAtom_EnableSlLatencyCheck_ANDROID(bool sw) { }

		// // RVA: 0x2882C58 Offset: 0x2882C58 VA: 0x2882C58
		// public static extern int criAtom_GetSlBufferConsumptionLatency_ANDROID() { }
	}
}