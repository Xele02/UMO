using UnityEngine;
using AVBBXYAZ;
using System;
using System.IO;

namespace CriWare
{
	public class CriWareInitializer : CriMonoBehaviour
	{
		public bool initializesFileSystem = true; // 0x1C
		public CriFsConfig fileSystemConfig = new CriFsConfig(); // 0x20
		public bool initializesAtom = true; // 0x24
		public CriAtomConfig atomConfig = new CriAtomConfig(); // 0x28
		public bool initializesMana = true; // 0x2C
		public CriManaConfig manaConfig = new CriManaConfig(); // 0x30
		public bool useDecrypter; // 0x34
		public CriWareDecrypterConfig decrypterConfig = new CriWareDecrypterConfig(); // 0x38
		public bool dontInitializeOnAwake; // 0x3C
		public bool dontDestroyOnLoad; // 0x3D
		private static int initializationCount; // 0x0

		// // RVA: 0x2BAC848 Offset: 0x2BAC848 VA: 0x2BAC848
		private void Awake()
		{
			CriWare.Common.CheckBinaryVersionCompatibility();
			if(dontInitializeOnAwake)
				return;
			Initialize();
		}

		// // RVA: 0x2BAD110 Offset: 0x2BAD110 VA: 0x2BAD110 Slot: 4
		protected override void OnEnable()
		{
			base.OnEnable();
		}

		// // RVA: 0x2BAD118 Offset: 0x2BAD118 VA: 0x2BAD118
		private void Start()
		{
			return;
		}

		// // RVA: 0x2BAD11C Offset: 0x2BAD11C VA: 0x2BAD11C
		private void OnDestroy()
		{
			TodoLogger.Log(TodoLogger.CriWareInitializer, "CriWareInitializer.OnDestroy");
		}

		// // RVA: 0x2BAD38C Offset: 0x2BAD38C VA: 0x2BAD38C Slot: 6
		public override void CriInternalUpdate()
		{
			return;
		}

		// // RVA: 0x2BAD390 Offset: 0x2BAD390 VA: 0x2BAD390 Slot: 7
		public override void CriInternalLateUpdate()
		{
			return;
		}

		// // RVA: 0x2BAC8D8 Offset: 0x2BAC8D8 VA: 0x2BAC8D8
		public void Initialize()
		{
			initializationCount = initializationCount + 1;
			if(initializationCount != 1)
			{
				UnityEngine.Object.Destroy(this);
				return;
			}
			if((CriFsPlugin.IsLibraryInitialized() || CriAtomPlugin.IsLibraryInitialized() || CriManaPlugin.IsLibraryInitialized()))
			{
				if(initializesMana)
				{
					CriManaPlugin.FinalizeLibrary();
				}
				if(initializesAtom)
				{
					CriAtomExLatencyEstimator.EstimatorInfo info = CriAtomExLatencyEstimator.GetCurrentInfo();
					while(info.status != CriAtomExLatencyEstimator.Status.Stop)
					{
						CriAtomExLatencyEstimator.FinalizeModule();
						info = CriAtomExLatencyEstimator.GetCurrentInfo();
					}
					CriAtomPlugin.FinalizeLibrary();
				}
				if(initializesFileSystem)
				{
					CriFsPlugin.FinalizeLibrary();
				}
			}
			if(initializesFileSystem)
			{
				InitializeFileSystem(fileSystemConfig);
			}
			if(initializesAtom)
			{
				if(atomConfig.inGamePreviewMode == CriAtomConfig.InGamePreviewSwitchMode.FollowBuildSetting)
				{
					atomConfig.usesInGamePreview = Debug.isDebugBuild;
				}
				else if(atomConfig.inGamePreviewMode == CriAtomConfig.InGamePreviewSwitchMode.Enable)
				{
					atomConfig.usesInGamePreview = true;
				}
				else if(atomConfig.inGamePreviewMode == CriAtomConfig.InGamePreviewSwitchMode.Disable)
				{
					atomConfig.usesInGamePreview = false;
				}
				InitializeAtom(atomConfig);
			}
			if(initializesMana)
			{
				InitializeMana(manaConfig);
			}
			if(!useDecrypter)
			{
				CriWareDecrypter.Initialize("0", "", false, false);
			}
			else
			{
				string key, authFile;
				KYXCRISDA.POISZES(out key, out authFile);
				ulong k_ = Convert.ToUInt64(key);
				if(CriWare.Common.IsStreamingAssetsPath(authFile))
				{
					authFile = Path.Combine(CriWare.Common.streamingAssetsPath, authFile);
				}
				
				CriWareDecrypter.Initialize(key, authFile, decrypterConfig.enableAtomDecryption, decrypterConfig.enableManaDecryption);
			}
			if(dontDestroyOnLoad)
			{
				UnityEngine.Object.DontDestroyOnLoad(transform.gameObject);
				UnityEngine.Object.DontDestroyOnLoad(CriWare.Common.managerObject);
			}
		}

		// // RVA: 0x2BAD120 Offset: 0x2BAD120 VA: 0x2BAD120
		// public void Shutdown() { }

		// // RVA: 0x2BADEE0 Offset: 0x2BADEE0 VA: 0x2BADEE0
		// public static bool IsInitialized() { }

		// // RVA: 0x2BADFAC Offset: 0x2BADFAC VA: 0x2BADFAC
		// public static void AddAudioEffectInterface(IntPtr effect_interface) { }

		// // RVA: 0x2BAD394 Offset: 0x2BAD394 VA: 0x2BAD394
		public static bool InitializeFileSystem(CriFsConfig config)
		{
			if(!CriFsPlugin.IsLibraryInitialized())
			{
				CriFsPlugin.SetConfigParameters(config.numberOfLoaders, config.numberOfBinders, config.numberOfInstallers, config.installBufferSize, config.maxPath, config.minimizeFileDescriptorUsage, config.enableCrcCheck);
				if(config.androidDeviceReadBitrate == 0)
					config.androidDeviceReadBitrate = 50000000;
			}
#if UNITY_ANDROID
			CriFsPlugin.SetConfigAdditionalParameters_ANDROID(config.androidDeviceReadBitrate);
#endif
			CriFsPlugin.InitializeLibrary();
			if(config.userAgentString.Length != 0)
			{
				CriFsUtility.SetUserAgentString(config.userAgentString);
				return true;
			}		
			return false;
		}

		// // RVA: 0x2BAD5B0 Offset: 0x2BAD5B0 VA: 0x2BAD5B0
		public static bool InitializeAtom(CriAtomConfig config)
		{
			if(!CriAtomPlugin.IsLibraryInitialized())
			{
				int virtualVoiceCount = Math.Max(config.maxVirtualVoices, CriAtomPlugin.GetRequiredMaxVirtualVoices(config));
				CriAtomPlugin.SetConfigParameters(virtualVoiceCount, 
						config.maxVoiceLimitGroups, 
						config.maxCategories, 
						config.maxSequenceEventsPerFrame, 
						config.maxBeatSyncCallbacksPerFrame, 
						config.maxCueLinkCallbacksPerFrame, 
						config.standardVoicePoolConfig.memoryVoices, 
						config.standardVoicePoolConfig.streamingVoices, 
						config.hcaMxVoicePoolConfig.memoryVoices, 
						config.hcaMxVoicePoolConfig.streamingVoices, 
						config.outputSamplingRate, 
						config.asrOutputChannels, 
						config.usesInGamePreview, 
						config.serverFrequency, 
						config.maxParameterBlocks, 
						config.categoriesPerPlayback, 
						config.maxBuses, 
						config.vrMode);
				CriAtomPlugin.SetConfigMonitorParametes(config.inGamePreviewConfig.maxPreviewObjects,
														config.inGamePreviewConfig.communicationBufferSize,
														config.inGamePreviewConfig.playbackPositionUpdateInterval);
				CriAtomPlugin.SetConfigAdditionalParameters_PC(config.pcBufferingTime);
				CriAtomPlugin.SetConfigAdditionalParameters_LINUX(config.linuxOutput, config.linuxPulseLatencyUsec);
				CriAtomPlugin.SetConfigAdditionalParameters_IOS(config.iosEnableSonicSync, (uint)Math.Max(config.iosBufferingTime, 16), config.iosOverrideIPodMusic);
				if(config.androidBufferingTime == 0)
					config.androidBufferingTime = (int)(4000.0f / config.serverFrequency);
				if(config.androidStartBufferingTime == 0)
					config.androidStartBufferingTime = (int)(3000.0f / config.serverFrequency);
				CriAtomEx.androidDefaultSoundRendererType = (config.androidForceToUseAsrForDefaultPlayback ? CriAtomEx.SoundRendererType.Asr : CriAtomEx.SoundRendererType.Default);
				CriAtomPlugin.SetConfigAdditionalParameters_ANDROID(config.androidEnableSonicSync, 
																	config.androidLowLatencyStandardVoicePoolConfig.memoryVoices,
																	config.androidLowLatencyStandardVoicePoolConfig.streamingVoices,
																	config.androidBufferingTime,
																	config.androidStartBufferingTime,
																	config.androidUsesAndroidFastMixer,
																	config.androidUsesAAudio);
				CriAtomPlugin.SetConfigAdditionalParameters_VITA(config.vitaAtrac9VoicePoolConfig.memoryVoices,
																config.vitaAtrac9VoicePoolConfig.streamingVoices,
																config.vitaManaVoicePoolConfig.numberOfManaDecoders);
															
				config.ps4Audio3dConfig.useAudio3D |= config.vrMode;
				CriAtomPlugin.SetConfigAdditionalParameters_PS4(config.ps4Atrac9VoicePoolConfig.memoryVoices,
																config.ps4Atrac9VoicePoolConfig.streamingVoices,
																config.ps4Audio3dConfig.useAudio3D,
																config.ps4Audio3dConfig.voicePoolConfig.memoryVoices,
																config.ps4Audio3dConfig.voicePoolConfig.streamingVoices);
				CriAtomPlugin.SetConfigAdditionalParameters_SWITCH(config.switchOpusVoicePoolConfig.memoryVoices,
																	config.switchOpusVoicePoolConfig.streamingVoices,
																	config.switchInitializeSocket);
				CriAtomPlugin.SetConfigAdditionalParameters_WEBGL(config.webglWebAudioVoicePoolConfig.voices);
				CriAtomPlugin.InitializeLibrary();
				if(config.useRandomSeedWithTime)
				{
					CriAtomEx.SetRandomSeed((uint)DateTime.Now.Ticks);
				}
				if(config.acfFileName.Length != 0)
				{
					string path = config.acfFileName;
					if(CriWare.Common.IsStreamingAssetsPath(path))
					{
						path = Path.Combine(CriWare.Common.streamingAssetsPath, path);
					}
					CriAtomEx.RegisterAcf(null, path);
				}
				CriAtomServer.KeepPlayingSoundOnPause = config.keepPlayingSoundOnPause;
				return true;
			}
			return false;
		}

		// // RVA: 0x2BADD88 Offset: 0x2BADD88 VA: 0x2BADD88
		public static bool InitializeMana(CriManaConfig config)
		{
			if(!CriManaPlugin.IsLibraryInitialized())
			{
				CriManaPlugin.SetConfigParameters(config.graphicsMultiThreaded, config.numberOfDecoders, config.numberOfMaxEntries);
				CriManaPlugin.SetConfigAdditonalParameters_ANDROID(true);
				CriManaPlugin.InitializeLibrary();
				if(QualitySettings.activeColorSpace == ColorSpace.Linear)
				{
					Shader.EnableKeyword("CRI_LINEAR_COLORSPACE");
				}
				return true;
			}
			return false;
		}

		// [ObsoleteAttribute] // RVA: 0x636594 Offset: 0x636594 VA: 0x636594
		// // RVA: 0x2BAE078 Offset: 0x2BAE078 VA: 0x2BAE078
		// public static bool InitializeDecrypter(CriWareDecrypterConfig config) { }
	}
}
