using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using CriWare.CriMana.Detail;
using System.IO;

namespace CriWare
{
	namespace CriMana
	{
		public class Player : CriDisposable
		{
			public enum TimerType
			{
				None = 0,
				System = 1,
				Audio = 2,
				User = 3,
				Manual = 4,
			}

			public enum Status
			{
				Stop = 0,
				Dechead = 1,
				WaitPrep = 2,
				Prep = 3,
				Ready = 4,
				Playing = 5,
				PlayEnd = 6,
				Error = 7,
				StopProcessing = 8,
				ReadyForRendering = 9,
			}

			public enum SetMode
			{
				New = 0,
				Append = 1,
				AppendRepeatedly = 2,
			}
			public enum MovieEventSyncMode
			{
				FrameTime = 0,
				PlayBackTime = 1,
			}

			public enum AudioTrack
			{
				Off = 0,
				Auto = 1,
			}

			public enum CriManaUnityPlayer_RenderEventAction
			{
				UPDATE = 0,
				INITIALIZE = 256,
				RENDER = 512,
				DESTROY = 768,
			}

			public delegate void StatusChangeCallback(Player.Status status);
			public delegate void CuePointCallback(ref EventPoint eventPoint);

			public delegate void SubtitleChangeCallback(IntPtr subtitleBuffer);
			public delegate Shader ShaderDispatchCallback(MovieInfo movieInfo, bool additiveMode);

			private const int InvalidPlayerId = -1;
			private static Player updatingPlayer; // 0x0
			private int playerId = InvalidPlayerId; // 0x18
			private bool isDisposed; // 0x1C
			private Player.Status internalrequiredStatus; // 0x20
			private Player.Status _nativeStatus; // 0x24
			private Nullable<Player.Status> lastNativeStatus; // 0x28
			private Nullable<Player.Status> lastPlayerStatus; // 0x30
			private bool wasStopping; // 0x38
			private bool isPreparingForRendering; // 0x39
			private bool isNativeStartInvoked; // 0x3A
			private bool isNativeInitialized; // 0x3B
			private RendererResource rendererResource; // 0x3C
			private MovieInfo _movieInfo = new MovieInfo(); // 0x40
			private FrameInfo _frameInfo = new FrameInfo(); // 0x44
			private bool isMovieInfoAvailable; // 0x48
			private bool isFrameInfoAvailable; // 0x49
			private Player.ShaderDispatchCallback _shaderDispatchCallback; // 0x4C
			private bool enableSubtitle; // 0x50
			private int subtitleBufferSize; // 0x54
			private uint droppedFrameCount; // 0x58
			private CriAtomExPlayer _atomExPlayer; // 0x5C
			private CriAtomEx3dSource _atomEx3Dsource; // 0x60
			private Player.TimerType _timerType = TimerType.Audio; // 0x64
			private bool isStoppingForSeek; // 0x68
			public CuePointCallback cuePointCallback; // 0x6C
			public StatusChangeCallback statusChangeCallback; // 0x70
			// [CompilerGeneratedAttribute] // RVA: 0x635294 Offset: 0x635294 VA: 0x635294
			private SubtitleChangeCallback OnSubtitleChanged; // 0x74

			// internal Player.Status nativeStatus { get; } 0x2957404
			// private Player.Status requiredStatus { get; set; } 0x295740C 0x2957414
			public bool additiveMode { get; set; } // 0x78
			public int maxFrameDrop { get; set; } // 0x7C
			public bool applyTargetAlpha { get; set; } // 0x80
			public bool uiRenderMode { get; set; } // 0x81
			public bool isFrameAvailable { get { return isFrameInfoAvailable;} } //0x29577DC
			public MovieInfo movieInfo { get { return isMovieInfoAvailable ? _movieInfo : null; } } //0x29577E4
			public FrameInfo frameInfo { get { return isFrameInfoAvailable ? _frameInfo : null; } } //0x29577F8
			public Player.Status status { get {
				Status st = _nativeStatus;
				if(wasStopping)
				{
					if(_nativeStatus != Status.Stop)
					{
						return Status.StopProcessing;
					}
					st = Status.Stop;
				}
				if(internalrequiredStatus == Status.ReadyForRendering)
				{
					if(st == Status.Playing && rendererResource != null)
					{
						st = Status.Prep;
						if(rendererResource.IsPrepared())
							st = Status.ReadyForRendering;
						return st;
					}
					st = Status.Prep;
				}
				else if(st == Status.Ready && rendererResource == null)
				{
					st = Status.Prep;
				}
				return st;
			} } //0x295780C
			// public int numberOfEntries { get; } 0x29578A0
			public IntPtr subtitleBuffer { get; private set; } // 0x84
			public int subtitleSize { get; private set; } // 0x88
			// public CriAtomExPlayer atomExPlayer { get; } 0x2957A4C
			// public CriAtomEx3dSource atomEx3DsourceForAmbisonics { get; } 0x2957A54
			public Player.TimerType timerType { get { return _timerType; } } //0x2957A5C
			public CriManaMoviePlayerHolder playerHolder { get; set; } // 0x8C
			public bool isAlive { get { return playerId != -1; } } //0x295E640

			// [CompilerGeneratedAttribute] // RVA: 0x63670C Offset: 0x63670C VA: 0x63670C
			// // RVA: 0x2957584 Offset: 0x2957584 VA: 0x2957584
			// public void add_OnSubtitleChanged(Player.SubtitleChangeCallback value) { }

			// [CompilerGeneratedAttribute] // RVA: 0x63671C Offset: 0x63671C VA: 0x63671C
			// // RVA: 0x2957690 Offset: 0x2957690 VA: 0x2957690
			// public void remove_OnSubtitleChanged(Player.SubtitleChangeCallback value) { }

			// // RVA: 0x2957A74 Offset: 0x2957A74 VA: 0x2957A74
			public Player()
			{
				if(CriManaPlugin.IsLibraryInitialized())
				{
					playerId = CRIWARE4B9FFA91_criManaUnityPlayer_Create();
					additiveMode = false;
					maxFrameDrop = 0;
					CriDisposableObjectManager.Register(this, CriDisposableObjectManager.ModuleType.Mana);
				}
				else
				{
					throw new Exception("CriManaPlugin is not initialized.");
				}
			}

			// // RVA: 0x2957D9C Offset: 0x2957D9C VA: 0x2957D9C
			public Player(bool advanced_audio_mode, bool ambisonics_mode, uint max_path_length)
			{
				if(CriManaPlugin.IsLibraryInitialized())
				{
					if(max_path_length == 0 && advanced_audio_mode == false)
					{
						playerId = CRIWARE4B9FFA91_criManaUnityPlayer_Create();
					}
					else
					{
						playerId = CRIWARED1C9883A_criManaUnityPlayer_Create(advanced_audio_mode, max_path_length);
						if(advanced_audio_mode)
						{
							_atomExPlayer = new CriAtomExPlayer(null, CRIWARE453735B6(playerId));
							if(ambisonics_mode)
							{
								_atomEx3Dsource = new CriAtomEx3dSource(null, false, 0);
								_atomExPlayer.Set3dSource(_atomEx3Dsource);
								_atomExPlayer.SetPanType(CriAtomEx.PanType.Pos3d);
								_atomExPlayer.UpdateAll();
							}
						}
					}
					additiveMode = false;
					maxFrameDrop = 0;
					CriDisposableObjectManager.Register(this, CriDisposableObjectManager.ModuleType.Mana);
				}
				else
				{
					throw new Exception("CriManaPlugin is not initialized.");
				}
			}

			// // RVA: 0x29582BC Offset: 0x29582BC VA: 0x29582BC Slot: 1
			~Player()
			{
				Dispose(false);
			}

			// // RVA: 0x29585C0 Offset: 0x29585C0 VA: 0x29585C0 Slot: 5
			public override void Dispose()
			{
				Dispose(false);
				GC.SuppressFinalize(this);
			}

			// // RVA: 0x2958650 Offset: 0x2958650 VA: 0x2958650
			// public void CreateRendererResource(int width, int height, bool alpha) { }

			// // RVA: 0x29590A4 Offset: 0x29590A4 VA: 0x29590A4
			// public void DisposeRendererResource() { }

			// // RVA: 0x29590CC Offset: 0x29590CC VA: 0x29590CC
			public void Prepare()
			{
				wasStopping = false;
				if(_nativeStatus == Status.PlayEnd || _nativeStatus == Status.Stop)
				{
					internalrequiredStatus = Status.Ready;
					InvokePlayerStatusCheck();
					PrepareNativePlayer();
					UpdateNativePlayer();
				}
			}

			// // RVA: 0x29594E4 Offset: 0x29594E4 VA: 0x29594E4
			// public void PrepareForRendering() { }

			// // RVA: 0x29595E8 Offset: 0x29595E8 VA: 0x29595E8
			public void Start()
			{
				wasStopping = false;
				Status curStatus = internalrequiredStatus;
				internalrequiredStatus = Status.Playing;
				InvokePlayerStatusCheck();
				if(curStatus == Status.ReadyForRendering)
				{
					Pause(false);
					UpdateNativePlayer();
				}
				else if(_nativeStatus == Status.PlayEnd || _nativeStatus == Status.Stop)
				{
					PrepareNativePlayer();
					UpdateNativePlayer();
				}
				if(rendererResource != null)
				{
					rendererResource.OnPlayerStart();
				}
				isStoppingForSeek = false;
			}

			// // RVA: 0x2959670 Offset: 0x2959670 VA: 0x2959670
			public void Stop()
			{
				internalrequiredStatus = Status.Stop;
				isStoppingForSeek = false;
				wasStopping = true;
				InvokePlayerStatusCheck();
				if(playerId != -1)
				{
					CRIWARE0C381E92_criManaUnityPlayer_Stop(playerId);
					UpdateNativePlayer();
				}
				DisableInfos();
			}

			// // RVA: 0x2959850 Offset: 0x2959850 VA: 0x2959850
			// public void StopForSeek() { }

			// // RVA: 0x295953C Offset: 0x295953C VA: 0x295953C
			public void Pause(bool sw)
			{
				CRIWARED22E1E28_criManaUnityPlayer_Pause(playerId, (sw) ? 1 : 0);
				if(rendererResource != null)
					rendererResource.OnPlayerPause(sw);
			}

			// // RVA: 0x2959A8C Offset: 0x2959A8C VA: 0x2959A8C
			public bool IsPaused()
			{
				return CRIWARE1E2E4671(playerId);
			}

			// // RVA: 0x2959C1C Offset: 0x2959C1C VA: 0x2959C1C
			public bool SetFile(CriFsBinder binder, string moviePath, Player.SetMode setMode = 0)
			{
				System.IntPtr binderPtr = (binder == null) ? System.IntPtr.Zero : binder.nativeHandle;
				if(binder == null)
				{
					if(Common.IsStreamingAssetsPath(moviePath))
					{
						moviePath = Path.Combine(Common.streamingAssetsPath, moviePath);
					}
				}
				if(setMode != Player.SetMode.New)
				{
					return CRIWARE7FE26661_criManaUnityPlayer_EntryFile(playerId, binderPtr, moviePath, setMode == Player.SetMode.AppendRepeatedly);
				}
				CRIWARE941BB516_criManaUnityPlayer_SetFile(playerId, binderPtr, moviePath);
				return true;
			}

			// // RVA: 0x295A050 Offset: 0x295A050 VA: 0x295A050
			// public bool SetData(IntPtr data, long dataSize, Player.SetMode setMode = 0) { }

			// [ObsoleteAttribute] // RVA: 0x63680C Offset: 0x63680C VA: 0x63680C
			// // RVA: 0x295A32C Offset: 0x295A32C VA: 0x295A32C
			// public bool SetData(byte[] data, long datasize, Player.SetMode setMode = 0) { }

			// // RVA: 0x295A614 Offset: 0x295A614 VA: 0x295A614
			// public bool SetContentId(CriFsBinder binder, int contentId, Player.SetMode setMode = 0) { }

			// // RVA: 0x295A99C Offset: 0x295A99C VA: 0x295A99C
			// public bool SetFileRange(string filePath, ulong offset, long range, Player.SetMode setMode = 0) { }

			// // RVA: 0x295AD48 Offset: 0x295AD48 VA: 0x295AD48
			public void Loop(bool sw)
			{
				CRIWARE851F97C9_criManaUnityPlayer_Loop(playerId, sw ? 1 : 0);
			}

			// // RVA: 0x295AEE4 Offset: 0x295AEE4 VA: 0x295AEE4
			public void SetMasterTimerType(Player.TimerType timerType)
			{
				TodoLogger.LogError(TodoLogger.CriManaPlugin, "SetMasterTimerType");
			}

			// // RVA: 0x295B084 Offset: 0x295B084 VA: 0x295B084
			public void SetSeekPosition(int frameNumber)
			{
				CRIWAREC92A5005(playerId, frameNumber);
			}

			// // RVA: 0x295B21C Offset: 0x295B21C VA: 0x295B21C
			// public void SetMovieEventSyncMode(Player.MovieEventSyncMode mode) { }

			// // RVA: 0x295B3B4 Offset: 0x295B3B4 VA: 0x295B3B4
			// public void SetSpeed(float speed) { }

			// // RVA: 0x295B54C Offset: 0x295B54C VA: 0x295B54C
			// public void SetMaxPictureDataSize(uint maxDataSize) { }

			// // RVA: 0x295B6E4 Offset: 0x295B6E4 VA: 0x295B6E4
			// public void SetBufferingTime(float sec) { }

			// // RVA: 0x295B87C Offset: 0x295B87C VA: 0x295B87C
			// public void SetMinBufferSize(int min_buffer_size) { }

			// // RVA: 0x295BA14 Offset: 0x295BA14 VA: 0x295BA14
			// public void SetAudioTrack(int track) { }

			// // RVA: 0x295BBAC Offset: 0x295BBAC VA: 0x295BBAC
			// public void SetAudioTrack(Player.AudioTrack track) { }

			// // RVA: 0x295BC88 Offset: 0x295BC88 VA: 0x295BC88
			// public void SetSubAudioTrack(int track) { }

			// // RVA: 0x295BE24 Offset: 0x295BE24 VA: 0x295BE24
			// public void SetSubAudioTrack(Player.AudioTrack track) { }

			// // RVA: 0x295BF00 Offset: 0x295BF00 VA: 0x295BF00
			// public void SetExtraAudioTrack(int track) { }

			// // RVA: 0x295C09C Offset: 0x295C09C VA: 0x295C09C
			// public void SetExtraAudioTrack(Player.AudioTrack track) { }

			// // RVA: 0x295C178 Offset: 0x295C178 VA: 0x295C178
			// public void SetVolume(float volume) { }

			// // RVA: 0x295C314 Offset: 0x295C314 VA: 0x295C314
			// public float GetVolume() { }

			// // RVA: 0x295C49C Offset: 0x295C49C VA: 0x295C49C
			// public void SetSubAudioVolume(float volume) { }

			// // RVA: 0x295C634 Offset: 0x295C634 VA: 0x295C634
			// public float GetSubAudioVolume() { }

			// // RVA: 0x295C7BC Offset: 0x295C7BC VA: 0x295C7BC
			// public void SetExtraAudioVolume(float volume) { }

			// // RVA: 0x295C954 Offset: 0x295C954 VA: 0x295C954
			// public float GetExtraAudioVolume() { }

			// // RVA: 0x295CADC Offset: 0x295CADC VA: 0x295CADC
			// public void SetBusSendLevel(string bus_name, float level) { }

			// // RVA: 0x295CCA0 Offset: 0x295CCA0 VA: 0x295CCA0
			// public void SetSubAudioBusSendLevel(string bus_name, float volume) { }

			// // RVA: 0x295CE68 Offset: 0x295CE68 VA: 0x295CE68
			// public void SetExtraAudioBusSendLevel(string bus_name, float volume) { }

			// // RVA: 0x295D030 Offset: 0x295D030 VA: 0x295D030
			// public void SetSubtitleChannel(int channel) { }

			// // RVA: 0x295D44C Offset: 0x295D44C VA: 0x295D44C
			// public void SetShaderDispatchCallback(Player.ShaderDispatchCallback shaderDispatchCallback) { }

			// // RVA: 0x295D454 Offset: 0x295D454 VA: 0x295D454
			// public long GetTime() { }

			// // RVA: 0x295D5DC Offset: 0x295D5DC VA: 0x295D5DC
			// public int GetDisplayedFrameNo() { }

			// // RVA: 0x295D764 Offset: 0x295D764 VA: 0x295D764
			// public bool HasRenderedNewFrame() { }

			// // RVA: 0x295D784 Offset: 0x295D784 VA: 0x295D784
			// public void SetAsrRackId(int asrRackId) { }

			// // RVA: 0x295D91C Offset: 0x295D91C VA: 0x295D91C
			public void UpdateWithUserTime(ulong timeCount, ulong timeUnit)
			{
				if(_timerType != TimerType.User)
				{
					UnityEngine.Debug.LogError("[CRIWARE] Timer type is invalid.");
				}
				CRIWARE51B54144(playerId, timeCount, timeUnit);
				InternalUpdate();
			}

			// // RVA: 0x295E0B4 Offset: 0x295E0B4 VA: 0x295E0B4
			// public void SetManualTimerUnit(ulong timeUnitN, ulong timeUnitD) { }

			// // RVA: 0x295E2D4 Offset: 0x295E2D4 VA: 0x295E2D4
			// public void UpdateWithManualTimeAdvanced() { }

			// // RVA: 0x295E4B4 Offset: 0x295E4B4 VA: 0x295E4B4
			public void Update()
			{
				if(_timerType == TimerType.Manual)
					return;
				InternalUpdate();
			}

			// // RVA: 0x295E4C8 Offset: 0x295E4C8 VA: 0x295E4C8
			public void OnWillRenderObject(CriManaMovieMaterial sender)
			{
				if(rendererResource == null)
					return;
				if(_nativeStatus == Status.Playing)
				{
					rendererResource.UpdateTextures();
					IssuePluginEvent(CriManaUnityPlayer_RenderEventAction.RENDER);
				}
			}

			// // RVA: 0x295E5EC Offset: 0x295E5EC VA: 0x295E5EC
			public bool UpdateMaterial(Material material)
			{
				return rendererResource != null && isFrameAvailable && rendererResource.UpdateMaterial(material) && internalrequiredStatus != Player.Status.ReadyForRendering;
			}

			// // RVA: 0x295E510 Offset: 0x295E510 VA: 0x295E510
			public void IssuePluginEvent(Player.CriManaUnityPlayer_RenderEventAction renderEventAction)
			{
#if !UNITY_EDITOR && !UNITY_STANDALONE
#if !(UNITY_IOS || UNITY_TVOS)
				if (status == Status.Ready || status == Status.Playing)
				{
#if CRIPLUGIN_USE_OLD_LOWLEVEL_INTERFACE
					UnityEngine.GL.IssuePluginEvent(this.playerId + CriManaPlugin.renderingEventOffset);
#else
					UnityEngine.GL.IssuePluginEvent(criWareUnity_GetRenderEventFunc(), this.playerId + CriManaPlugin.renderingEventOffset);
#endif
				}
#endif
#endif
			}

			// // RVA: 0x2958324 Offset: 0x2958324 VA: 0x2958324
			private void Dispose(bool disposing)
			{
				if(isDisposed)
					return;
				isDisposed = true;
				CriDisposableObjectManager.Unregister(this);
				int frameCount = 0;
				if(rendererResource != null)
				{
					if(playerId != InvalidPlayerId)
					{
						IssuePluginEvent(CriManaUnityPlayer_RenderEventAction.DESTROY);
						frameCount = rendererResource.GetNumberOfFrameBeforeDestroy(playerId);
					}
					rendererResource.Dispose();
					rendererResource = null;
				}
				DeallocateSubtitleBuffer();
				if(playerId != InvalidPlayerId)
				{
					if(_atomExPlayer != null)
					{
						_atomExPlayer.Dispose();
						_atomExPlayer = null;
					}
					if(_atomEx3Dsource != null)
					{
						_atomEx3Dsource.Dispose();
						_atomEx3Dsource = null;
					}
					CRIWARE6536ABE0_criManaUnityPlayer_Destroy(playerId);
				}
				if(playerHolder != null)
				{
					if(frameCount < 1)
					{
						UnityEngine.Object.Destroy(playerHolder.gameObject);
					}
					else
					{
						playerHolder.StartCoroutineWatched(IssuePluginUpdatesForFrames(frameCount, playerHolder, true, playerId));
					}
				}
				cuePointCallback = null;
				playerId = InvalidPlayerId;
			}

			// // RVA: 0x295DB44 Offset: 0x295DB44 VA: 0x295DB44
			private void InternalUpdate()
			{
				CRIWARE55BA8D00(playerId);
				if(internalrequiredStatus == Status.Stop)
				{
					if(_nativeStatus == Status.Stop)
						return;
					UpdateNativePlayer();
					return;
				}
				switch(_nativeStatus)
				{
					case Status.Dechead:
					{
						UpdateNativePlayer();
						if(_nativeStatus == Status.WaitPrep)
							goto case Status.WaitPrep;
						break;
					}
					case Status.WaitPrep:
					{
						CRIWARE4A28D964_criManaUnityPlayer_GetMovieInfo(playerId, out _movieInfo);
						if(!isMovieInfoAvailable)
						{
							isMovieInfoAvailable = true;
							if(enableSubtitle)
							{
								AllocateSubtitleBuffer((int)movieInfo.maxSubtitleSize);
							}
							UnityEngine.Shader userShader = (_shaderDispatchCallback == null) ? null : _shaderDispatchCallback(movieInfo, additiveMode);
							if(rendererResource != null)
							{
								if (!rendererResource.IsSuitable(playerId, _movieInfo, additiveMode, userShader))
								{
									rendererResource.Dispose();
									rendererResource = null;
								}
							}
							if (rendererResource == null)
							{
								rendererResource = CriMana.Detail.RendererResourceFactory.DispatchAndCreate(playerId, _movieInfo, additiveMode, userShader);
								if (rendererResource == null)
								{
									Stop();
									return;
								}
							}
							rendererResource.SetApplyTargetAlpha(applyTargetAlpha);
							rendererResource.SetUiRenderMode(uiRenderMode);
						}
						rendererResource.AttachToPlayer(playerId);
						if(internalrequiredStatus != Status.Ready)
						{
							if(internalrequiredStatus != Status.ReadyForRendering && internalrequiredStatus != Status.Playing)
								break;
							CRIWARE3D38F2C2_criManaUnityPlayer_Start(playerId);
							isNativeStartInvoked = true;
							if(isNativeInitialized)
							{
								IssuePluginEvent(CriManaUnityPlayer_RenderEventAction.DESTROY);
							}
							IssuePluginEvent(CriManaUnityPlayer_RenderEventAction.INITIALIZE);
							isNativeInitialized = true;
						}
						goto case Status.Prep;
					}
					case Status.Prep:
					{
						UpdateNativePlayer();
						if(_nativeStatus != Status.Playing)
						{
							if(_nativeStatus != Status.Ready)
								break;
							goto case Status.Ready;
						}
						goto case Status.Playing;
					}
					case Status.Ready:
					{
						if(internalrequiredStatus != Status.ReadyForRendering && internalrequiredStatus != Status.Playing)
							break;
						if(!isNativeStartInvoked)
						{
							CRIWARE3D38F2C2_criManaUnityPlayer_Start(playerId);
							isNativeStartInvoked = true;
							if(isNativeInitialized)
								IssuePluginEvent(CriManaUnityPlayer_RenderEventAction.DESTROY);
							IssuePluginEvent(CriManaUnityPlayer_RenderEventAction.INITIALIZE);
							isNativeInitialized = true;
						}
						goto case Status.Playing;
					}
					case Status.Playing:
					{
						UpdateNativePlayer();
						if(_nativeStatus != Status.Playing)
							break;
						bool frameDrop;
						if(maxFrameDrop < 0)
							frameDrop = true;
						else
						{
							frameDrop = droppedFrameCount < maxFrameDrop;
						}
						bool cont;
						while(true)
						{
							cont = rendererResource.UpdateFrame(playerId, _frameInfo, ref frameDrop);
							if(!cont && !frameDrop)
								break;
							if(maxFrameDrop < 0)
								droppedFrameCount++;
							else
							{
								if(droppedFrameCount > maxFrameDrop)
									break;
								droppedFrameCount++;
								if(droppedFrameCount == maxFrameDrop)
									frameDrop = false;
							}
						}
						if(cont)
							droppedFrameCount = 0;
						isFrameInfoAvailable = cont || isFrameInfoAvailable;
						IssuePluginEvent(CriManaUnityPlayer_RenderEventAction.UPDATE);
					}
					break;
					case Status.Error:
						UpdateNativePlayer();
					break;
				}
				if(_nativeStatus == Status.Error)
				{
					DisableInfos();
				}
			}

			// [IteratorStateMachineAttribute] // RVA: 0x636864 Offset: 0x636864 VA: 0x636864
			// // RVA: 0x295E834 Offset: 0x295E834 VA: 0x295E834
			private IEnumerator IssuePluginUpdatesForFrames(int frameCount, MonoBehaviour playerHolder, bool destroy, int playerId)
			{
				//0x296044C
				while(frameCount >= 1)
				{
					IssuePluginEvent(CriManaUnityPlayer_RenderEventAction.UPDATE);
					CRIWARE55BA8D00(playerId);
					frameCount --;
					yield return null;
				}
				if(destroy)
				{
					UnityEngine.Object.Destroy(playerHolder.gameObject);
				}
			}

			// // RVA: 0x2959834 Offset: 0x2959834 VA: 0x2959834
			private void DisableInfos(bool keepFrameInfo = false)
			{
				isMovieInfoAvailable = false;
				isFrameInfoAvailable = false;
				isNativeStartInvoked = false;
				subtitleSize = 0;
			}

			// // RVA: 0x2959118 Offset: 0x2959118 VA: 0x2959118
			private void PrepareNativePlayer()
			{
				if(cuePointCallback != null)
				{
					CRIWARE044D0246_criManaUnityPlayer_SetCuePointCallback(playerId, CuePointCallbackFromNative);
				}
				CRIWARECB5086D8_criManaUnityPlayer_Prepare(playerId);
			}

			// // RVA: 0x2959220 Offset: 0x2959220 VA: 0x2959220
			private void UpdateNativePlayer()
			{
				updatingPlayer = this;
				uint subtitleSizeTmp = (uint)subtitleBufferSize;
				_nativeStatus = (Status)CRIWAREFE53CA2C_criManaUnityPlayer_Update(playerId, subtitleBuffer, ref subtitleSizeTmp);
				if(_nativeStatus != lastNativeStatus || isPreparingForRendering)
				{
					lastNativeStatus = _nativeStatus;
					InvokePlayerStatusCheck();
				}
				subtitleSize = (int)subtitleSizeTmp;
				updatingPlayer = null;
				if(enableSubtitle)
				{
					if(CRIWARE6C94B6FB(playerId))
					{
						if(OnSubtitleChanged != null)
							OnSubtitleChanged(subtitleBuffer);
						CRIWAREC9D98FAA(playerId);
					}
				}
				if(isNativeInitialized && (_nativeStatus == Status.StopProcessing || _nativeStatus == Status.Stop))
				{
					isNativeInitialized = false;
					if(isStoppingForSeek && rendererResource != null)
					{
						if(rendererResource.ShouldSkipDestroyOnStopForSeek())
						{
							return;
						}
					}
					IssuePluginEvent(CriManaUnityPlayer_RenderEventAction.DESTROY);
				}
			}

			// // RVA: 0x2957440 Offset: 0x2957440 VA: 0x2957440
			private void InvokePlayerStatusCheck()
			{
				Status s = status;
				if(lastPlayerStatus == s)
				{
					return;
				}
				lastPlayerStatus = s;
				if(statusChangeCallback != null)
					statusChangeCallback(s);
				if(isPreparingForRendering)
				{
					if(status != Status.Prep)
						isPreparingForRendering = false;
				}
			}

			// // RVA: 0x295D108 Offset: 0x295D108 VA: 0x295D108
			private void AllocateSubtitleBuffer(int size)
			{
				if(subtitleBufferSize < size)
				{
					DeallocateSubtitleBuffer();
					subtitleBufferSize = size;
					subtitleBuffer = Marshal.AllocHGlobal(size);
					subtitleSize = 0;
				}
				for(int i = 0; i < subtitleBufferSize; i++)
				{
					Marshal.WriteByte(subtitleBuffer, i, 0);
				}
				CRIWARE91AA6C29(playerId, size);
			}

			// // RVA: 0x295D254 Offset: 0x295D254 VA: 0x295D254
			private void DeallocateSubtitleBuffer()
			{
				if(subtitleBuffer != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(subtitleBuffer);
					subtitleBufferSize = 0;
					subtitleBuffer = IntPtr.Zero;
					subtitleSize = 0;
				}
				CRIWARE6AEEBF51(playerId);
			}

			public delegate void CuePointCallbackFromNativeDelegate(System.IntPtr ptr1, System.IntPtr ptr2, [In] ref EventPoint eventPoint);

			[AOT.MonoPInvokeCallback(typeof(CuePointCallbackFromNativeDelegate))]
			// [MonoPInvokeCallbackAttribute] // RVA: 0x6368DC Offset: 0x6368DC VA: 0x6368DC
			// // RVA: 0x29572E4 Offset: 0x29572E4 VA: 0x29572E4
			private static void CuePointCallbackFromNative(IntPtr ptr1, IntPtr ptr2, [In] ref EventPoint eventPoint)
			{
				if (updatingPlayer.cuePointCallback != null)
				{
					updatingPlayer.cuePointCallback(ref eventPoint);
				}
			}

			// // RVA: 0x2957CA8 Offset: 0x2957CA8 VA: 0x2957CA8
#if UNITY_ANDROID
			private static extern int CRIWARE4B9FFA91_criManaUnityPlayer_Create();
#else
			private static int CRIWARE4B9FFA91_criManaUnityPlayer_Create()
			{
#if UNITY_ANDROID
				return CRIWARE4B9FFA91();
#else
				return ExternLib.LibCriWare.CRIWARE4B9FFA91_criManaUnityPlayer_Create();
#endif
			}
#endif

			// // RVA: 0x2960140 Offset: 0x2960140 VA: 0x2960140
			// private static extern int CRIWAREC904C89F() { }

			// // RVA: 0x29580A8 Offset: 0x29580A8 VA: 0x29580A8
#if UNITY_ANDROID
			private static extern int CRIWARED1C9883A_criManaUnityPlayer_Create(bool useAtomExPlayer, uint maxPathLength);
#else
			private static int CRIWARED1C9883A_criManaUnityPlayer_Create(bool useAtomExPlayer, uint maxPathLength)
			{
#if UNITY_ANDROID
				return CRIWARED1C9883A(useAtomExPlayer, maxPathLength);
#else
				return ExternLib.LibCriWare.CRIWARED1C9883A_criManaUnityPlayer_Create(useAtomExPlayer, maxPathLength);
#endif
			}
#endif

			// // RVA: 0x295E730 Offset: 0x295E730 VA: 0x295E730
#if UNITY_ANDROID
			private static extern void CRIWARE6536ABE0_criManaUnityPlayer_Destroy(int player_id);
#else
			private static void CRIWARE6536ABE0_criManaUnityPlayer_Destroy(int player_id)
			{
#if UNITY_ANDROID
				CRIWARE6536ABE0(player_id);
#else
				ExternLib.LibCriWare.CRIWARE6536ABE0_criManaUnityPlayer_Destroy(player_id);
#endif
			}
#endif

			// // RVA: 0x2959DD8 Offset: 0x2959DD8 VA: 0x2959DD8
#if UNITY_ANDROID
			private static extern void CRIWARE941BB516_criManaUnityPlayer_SetFile(int player_id, IntPtr binder, string path);
#else
			private static void CRIWARE941BB516_criManaUnityPlayer_SetFile(int player_id, IntPtr binder, string path)
			{
#if UNITY_ANDROID
				CRIWARE941BB516(player_id, binder, path);
#else
				ExternLib.LibCriWare.CRIWARE941BB516_criManaUnityPlayer_SetFile(player_id, binder, path);
#endif
			}
#endif

			// // RVA: 0x295A760 Offset: 0x295A760 VA: 0x295A760
			// private static extern void CRIWARE7BB4D73A(int player_id, IntPtr binder, int content_id) { }

			// // RVA: 0x295AAB0 Offset: 0x295AAB0 VA: 0x295AAB0
			// private static extern void CRIWAREE6A1082E(int player_id, string path, ulong offset, long range) { }

			// // RVA: 0x295A150 Offset: 0x295A150 VA: 0x295A150
			// private static extern void CRIWARE3618D6B1(int player_id, IntPtr data, long datasize) { }

			// // RVA: 0x295A428 Offset: 0x295A428 VA: 0x295A428
			// private static extern void CRIWARE3618D6B1(int player_id, byte[] data, long datasize) { }

			// // RVA: 0x2959F08 Offset: 0x2959F08 VA: 0x2959F08
#if UNITY_ANDROID
			private static extern bool CRIWARE7FE26661_criManaUnityPlayer_EntryFile(int player_id, IntPtr binder, string path, bool repeat);
#else
			private static bool CRIWARE7FE26661_criManaUnityPlayer_EntryFile(int player_id, IntPtr binder, string path, bool repeat)
			{
#if UNITY_ANDROID
				return CRIWARE7FE26661(player_id, binder, path, repeat);
#else
				return ExternLib.LibCriWare.CRIWARE7FE26661_criManaUnityPlayer_EntryFile(player_id, binder, path, repeat);
#endif
			}
#endif

			// // RVA: 0x295A878 Offset: 0x295A878 VA: 0x295A878
			// private static extern bool CRIWAREA23263A0(int player_id, IntPtr binder, int content_id, bool repeat) { }

			// // RVA: 0x295ABF0 Offset: 0x295ABF0 VA: 0x295ABF0
			// private static extern bool CRIWARE4C3CEFB0(int player_id, string path, ulong offset, long range, bool repeat) { }

			// // RVA: 0x295A238 Offset: 0x295A238 VA: 0x295A238
			// private static extern bool CRIWAREBC6115D8(int player_id, IntPtr data, long datasize, bool repeat) { }

			// // RVA: 0x295A518 Offset: 0x295A518 VA: 0x295A518
			// private static extern bool CRIWAREBC6115D8(int player_id, byte[] data, long datasize, bool repeat) { }

			// // RVA: 0x2960238 Offset: 0x2960238 VA: 0x2960238
			// private static extern void CRIWAREE1C2EB83(int player_id) { }

			// // RVA: 0x2957928 Offset: 0x2957928 VA: 0x2957928
			// private static extern int CRIWARED0DCBD5B(int player_id) { }

			// // RVA: 0x295ECB8 Offset: 0x295ECB8 VA: 0x295ECB8
#if UNITY_ANDROID
			private static extern void CRIWARE044D0246_criManaUnityPlayer_SetCuePointCallback(int player_id, CuePointCallbackFromNativeDelegate cbfunc);
#else
			private static void CRIWARE044D0246_criManaUnityPlayer_SetCuePointCallback(int player_id, CuePointCallbackFromNativeDelegate cbfunc)
			{
#if UNITY_ANDROID
				CRIWARE044D0246(player_id, cbfunc);
#else
				ExternLib.LibCriWare.CRIWARE044D0246_criManaUnityPlayer_SetCuePointCallback(player_id, cbfunc);
#endif
			}
#endif

			// // RVA: 0x295EA38 Offset: 0x295EA38 VA: 0x295EA38
#if UNITY_ANDROID
			private static extern void CRIWARE4A28D964_criManaUnityPlayer_GetMovieInfo(int player_id, /*[Out]*/out MovieInfo movie_info);
#else
			private static void CRIWARE4A28D964_criManaUnityPlayer_GetMovieInfo(int player_id, out MovieInfo movie_info)
			{
#if UNITY_ANDROID
				CRIWARE4A28D964(player_id, out movie_info);
#else
				ExternLib.LibCriWare.CRIWARE4A28D964_criManaUnityPlayer_GetMovieInfo(player_id, out movie_info);
#endif
			}
#endif

			// // RVA: 0x295EED8 Offset: 0x295EED8 VA: 0x295EED8
#if UNITY_ANDROID
			private static extern int CRIWAREFE53CA2C_criManaUnityPlayer_Update(int player_id, IntPtr subtitle_buffer, ref uint subtitle_size);
#else
			private static int CRIWAREFE53CA2C_criManaUnityPlayer_Update(int player_id, IntPtr subtitle_buffer, ref uint subtitle_size)
			{
#if UNITY_ANDROID
				return CRIWAREFE53CA2C(player_id, subtitle_buffer, ref subtitle_size);
#else
				return ExternLib.LibCriWare.CRIWAREFE53CA2C_criManaUnityPlayer_Update(player_id, subtitle_buffer, ref subtitle_size);
#endif
			}
#endif

			// // RVA: 0x295EDD0 Offset: 0x295EDD0 VA: 0x295EDD0
#if UNITY_ANDROID
			private static extern void CRIWARECB5086D8_criManaUnityPlayer_Prepare(int player_id);
#else
			private static void CRIWARECB5086D8_criManaUnityPlayer_Prepare(int player_id)
			{
#if UNITY_ANDROID
				CRIWARECB5086D8(player_id);
#else
				ExternLib.LibCriWare.CRIWARECB5086D8_criManaUnityPlayer_Prepare(player_id);
#endif
			}
#endif

			// // RVA: 0x295EB80 Offset: 0x295EB80 VA: 0x295EB80
#if UNITY_ANDROID
			private static extern void CRIWARE3D38F2C2_criManaUnityPlayer_Start(int player_id);
#else
			private static void CRIWARE3D38F2C2_criManaUnityPlayer_Start(int player_id)
			{
#if UNITY_ANDROID
				CRIWARE3D38F2C2(player_id);
#else
				ExternLib.LibCriWare.CRIWARE3D38F2C2_criManaUnityPlayer_Start(player_id);
#endif
			}
#endif

			// // RVA: 0x2959730 Offset: 0x2959730 VA: 0x2959730
#if UNITY_ANDROID
			private static extern void CRIWARE0C381E92_criManaUnityPlayer_Stop(int player_id);
#else
			private static void CRIWARE0C381E92_criManaUnityPlayer_Stop(int player_id)
			{
#if UNITY_ANDROID
				CRIWARE0C381E92(player_id);
#else
				ExternLib.LibCriWare.CRIWARE0C381E92_criManaUnityPlayer_Stop(player_id);
#endif
			}
#endif

			// // RVA: 0x295B110 Offset: 0x295B110 VA: 0x295B110
#if UNITY_ANDROID
			private static extern void CRIWAREC92A5005(int player_id, int seek_frame_no);
#else
			private static void CRIWAREC92A5005(int player_id, int seek_frame_no)
			{
				ExternLib.LibCriWare.CRIWAREC92A5005(player_id, seek_frame_no);
			}
#endif

			// // RVA: 0x295B2A8 Offset: 0x295B2A8 VA: 0x295B2A8
			// private static extern void CRIWARECED1DC1A(int player_id, Player.MovieEventSyncMode mode) { }

			// // RVA: 0x2959980 Offset: 0x2959980 VA: 0x2959980
#if UNITY_ANDROID
			private static extern void CRIWARED22E1E28_criManaUnityPlayer_Pause(int player_id, int sw);
#else
			private static void CRIWARED22E1E28_criManaUnityPlayer_Pause(int player_id, int sw)
			{
#if UNITY_ANDROID
				CRIWARED22E1E28(player_id, sw);
#else
				ExternLib.LibCriWare.CRIWARED22E1E28_criManaUnityPlayer_Pause(player_id, sw);
#endif
			}
#endif

			// // RVA: 0x2959B10 Offset: 0x2959B10 VA: 0x2959B10
#if UNITY_ANDROID
			private static extern bool CRIWARE1E2E4671(int player_id);
#else
			private static bool CRIWARE1E2E4671(int player_id)
			{
				return ExternLib.LibCriWare.CRIWARE1E2E4671(player_id);
			}
#endif

			// // RVA: 0x295ADD8 Offset: 0x295ADD8 VA: 0x295ADD8
#if UNITY_ANDROID
			private static extern void CRIWARE851F97C9_criManaUnityPlayer_Loop(int player_id, int sw);
#else
			private static void CRIWARE851F97C9_criManaUnityPlayer_Loop(int player_id, int sw)
			{
#if UNITY_ANDROID
				CRIWARE851F97C9(player_id, sw);
#else
				ExternLib.LibCriWare.CRIWARE851F97C9_criManaUnityPlayer_Loop(player_id, sw);
#endif
			}
#endif

			// // RVA: 0x295D4D8 Offset: 0x295D4D8 VA: 0x295D4D8
			// private static extern long CRIWARE29045DE2(int player_id) { }

			// // RVA: 0x2960340 Offset: 0x2960340 VA: 0x2960340
			// private static extern int CRIWARE3125B8D0(int player_id) { }

			// // RVA: 0x29581B8 Offset: 0x29581B8 VA: 0x29581B8
#if UNITY_ANDROID
			private static extern IntPtr CRIWARE453735B6(int player_id);
			#else
			private static IntPtr CRIWARE453735B6(int player_id)
			{
				return ExternLib.LibCriWare.CRIWARE453735B6(player_id);
			}
#endif

			// // RVA: 0x295D660 Offset: 0x295D660 VA: 0x295D660
			// private static extern int CRIWAREDA2D5E4D(int player_id) { }

			// // RVA: 0x295BAA0 Offset: 0x295BAA0 VA: 0x295BAA0
			// private static extern void CRIWARE671323A7(int player_id, int track) { }

			// // RVA: 0x295C208 Offset: 0x295C208 VA: 0x295C208
			// private static extern void CRIWARE0B62FCFA(int player_id, float vol) { }

			// // RVA: 0x295C398 Offset: 0x295C398 VA: 0x295C398
			// private static extern float CRIWARE72BA8380(int player_id) { }

			// // RVA: 0x295BD18 Offset: 0x295BD18 VA: 0x295BD18
			// private static extern void CRIWAREC2B76AF1(int player_id, int track) { }

			// // RVA: 0x295C528 Offset: 0x295C528 VA: 0x295C528
			// private static extern void CRIWARE3C47671B(int player_id, float vol) { }

			// // RVA: 0x295C6B8 Offset: 0x295C6B8 VA: 0x295C6B8
			// private static extern float CRIWARE20DEC945(int player_id) { }

			// // RVA: 0x295BF90 Offset: 0x295BF90 VA: 0x295BF90
			// private static extern void CRIWARE86DEE85D(int player_id, int track) { }

			// // RVA: 0x295C848 Offset: 0x295C848 VA: 0x295C848
			// private static extern void CRIWAREFF47FA95(int player_id, float vol) { }

			// // RVA: 0x295C9D8 Offset: 0x295C9D8 VA: 0x295C9D8
			// private static extern float CRIWAREF83F25D9(int player_id) { }

			// // RVA: 0x295CB70 Offset: 0x295CB70 VA: 0x295CB70
			// private static extern void CRIWARE2E7D4F7A(int player_id, string bus_name, float level) { }

			// // RVA: 0x295CD38 Offset: 0x295CD38 VA: 0x295CD38
			// private static extern void CRIWARE5F90D6E8(int player_id, string bus_name, float level) { }

			// // RVA: 0x295CF00 Offset: 0x295CF00 VA: 0x295CF00
			// private static extern void CRIWARE9FC31CDD(int player_id, string bus_name, float level) { }

			// // RVA: 0x295D340 Offset: 0x295D340 VA: 0x295D340
			// private static extern void CRIWARE9ED3F311(int player_id, int channel) { }

			// // RVA: 0x295B440 Offset: 0x295B440 VA: 0x295B440
			// private static extern void CRIWARE83EFC312(int player_id, float speed) { }

			// // RVA: 0x295B5D8 Offset: 0x295B5D8 VA: 0x295B5D8
			// private static extern void CRIWAREC56EBA7C(int player_id, uint max_data_size) { }

			// // RVA: 0x295B770 Offset: 0x295B770 VA: 0x295B770
			// public static extern void CRIWARE050732A5(int player_id, float sec) { }

			// // RVA: 0x295B908 Offset: 0x295B908 VA: 0x295B908
			// public static extern void CRIWARED40EE322(int player_id, int min_buffer_size) { }

			// // RVA: 0x295D810 Offset: 0x295D810 VA: 0x295D810
			// public static extern void CRIWARE7999B5AF(int player_id, int asr_rack_id) { }

			// // RVA: 0x295E930 Offset: 0x295E930 VA: 0x295E930
#if UNITY_ANDROID
			private static extern void CRIWARE55BA8D00(int player_id);
#else
			private static void CRIWARE55BA8D00(int player_id)
			{
				ExternLib.LibCriWare.CRIWARE55BA8D00(player_id);
			}
#endif

			// // RVA: 0x295AF78 Offset: 0x295AF78 VA: 0x295AF78
			// private static extern void CRIWARE31D7EFF8(int player_id, Player.TimerType timer_type) { }

			// // RVA: 0x295DA20 Offset: 0x295DA20 VA: 0x295DA20
#if UNITY_ANDROID
			private static extern void CRIWARE51B54144(int player_id, ulong user_count, ulong user_unit);
#else
			private static void CRIWARE51B54144(int player_id, ulong user_count, ulong user_unit)
			{
				ExternLib.LibCriWare.CRIWARE51B54144(player_id, user_count, user_unit);
			}
#endif

			// // RVA: 0x295E1B0 Offset: 0x295E1B0 VA: 0x295E1B0
			// private static extern void CRIWARE1E9C6BEC(int player_id, ulong timer_unit_n, ulong timer_unit_d) { }

			// // RVA: 0x295E3B0 Offset: 0x295E3B0 VA: 0x295E3B0
			// private static extern void CRIWAREE4C8241F(int player_id) { }

			// // RVA: 0x295FBD8 Offset: 0x295FBD8 VA: 0x295FBD8
#if UNITY_ANDROID
			private static extern void CRIWARE6AEEBF51(int player_id);
#else
			private static void CRIWARE6AEEBF51(int player_id)
			{
				ExternLib.LibCriWare.CRIWARE6AEEBF51(player_id);
			}
#endif

			// // RVA: 0x295FAC8 Offset: 0x295FAC8 VA: 0x295FAC8
#if UNITY_ANDROID
			private static extern IntPtr CRIWARE91AA6C29(int player_id, int bufferSize);
#else
			private static IntPtr CRIWARE91AA6C29(int player_id, int bufferSize)
			{
				return ExternLib.LibCriWare.CRIWARE91AA6C29(player_id, bufferSize);
			}
#endif

			// // RVA: 0x295EFF0 Offset: 0x295EFF0 VA: 0x295EFF0
#if UNITY_ANDROID
			private static extern bool CRIWARE6C94B6FB(int player_id);
#else
			private static bool CRIWARE6C94B6FB(int player_id)
			{
				return ExternLib.LibCriWare.CRIWARE6C94B6FB(player_id);
			}
#endif

			// // RVA: 0x295F560 Offset: 0x295F560 VA: 0x295F560
#if UNITY_ANDROID
			private static extern void CRIWAREC9D98FAA(int player_id);
#else
			private static void CRIWAREC9D98FAA(int player_id)
			{
				ExternLib.LibCriWare.CRIWAREC9D98FAA(player_id);
			}
#endif

			// // RVA: 0x295E658 Offset: 0x295E658 VA: 0x295E658
#if UNITY_ANDROID
			private static extern IntPtr criWareUnity_GetRenderEventFunc();
			#else
			private static IntPtr criWareUnity_GetRenderEventFunc() 
			{ 
				return IntPtr.Zero;
			}
			#endif
		}
	}
}
