
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using smartar;
using UnityEngine;

public abstract class SmartARControllerBase : MonoBehaviour
{
    [Serializable]
    public class TargetEntry
    {
        public string fileName; // 0x8
        public string id; // 0xC
    }

	// Id :
	// AR010002 > AR010011
	// AR010017 > AR010018
	// AR020022
	// AR010023
	// AR030024 > AR030027
	// AR050028
	// AR060029
	// AR070030
	// AR080031
	// AR090032 > AR092237
	// AR100038 > AR100039
	// AR110040
	// AR120041 > AR120047
	// AR130048 > AR130057
	// AR140058
	// AR150059

    [Serializable]
    public class RecognizerSettings
    {
        public RecognitionMode recognitionMode; // 0x8
        public SceneMappingInitMode sceneMappingInitMode; // 0xC
        public TargetEntry[] targets = new TargetEntry[0]; // 0x10
        public int maxTargetsPerFrame = 1; // 0x14
        public SearchPolicy searchPolicy = SearchPolicy.SEARCH_POLICY_PRECISIVE; // 0x18
        public int maxTriangulateMasks; // 0x1C
        public DenseMapMode denseMapMode; // 0x20
        public bool useWorkerThread = true; // 0x24
    }

    [HideInInspector]
    public struct TargetManager
    {
        public bool isUse_; // 0x0
        public Target target_; // 0x4
        public TargetEntry targetEntry_; // 0x8
        public bool willChangeUsingStatus_; // 0xC

        // RVA: 0x725534 Offset: 0x725534 VA: 0x725534
        public TargetManager(TargetEntry entry, Target target, bool isUse = true, bool willChangeUsingStatus = false)
		{
			isUse_ = isUse;
			target_ = target;
			targetEntry_ = entry;
			willChangeUsingStatus_ = willChangeUsingStatus;
		}
    }

    [HideInInspector]
    protected enum RenderEventID
    {
        DoDraw = 3001,
        DoDrawInstance = 3002,
    }

    protected struct CreateParam
    {
        public IntPtr smart_; // 0x0
        public IntPtr screenDevice_; // 0x4
        public IntPtr recognizer_; // 0x8
        public IntPtr cameraImageDrawer_; // 0xC
    }

	public string licenseFileName = "img/s.png"; // 0xC
	[SerializeField]
	protected RecognizerSettings recognizerSettings = new RecognizerSettings(); // 0x10
	protected RecognizerSettings orgRecognizerSettings = new RecognizerSettings(); // 0x14
	protected bool isRecognized_; // 0x18
	protected Triangle2[] triangulateMasks; // 0x1C
	[HideInInspector]
	public IntPtr self_; // 0x20
	[HideInInspector]
	public Smart smart_; // 0x24
	[HideInInspector]
	public LandmarkDrawer landmarkDrawer_; // 0x28
	[HideInInspector]
	public Recognizer recognizer_; // 0x2C
	[HideInInspector]
	public Target[] targets_; // 0x30
	[HideInInspector]
	public Target[] onlineTargets_; // 0x34
	[HideInInspector]
	public List<TargetManager> defaultTargets_ = new List<TargetManager>(); // 0x38
	[HideInInspector]
	public List<TargetManager> currentTargets_; // 0x3C
	protected int numWorkerThreads_; // 0x40
	protected Thread[] workerThreads_; // 0x44
	protected bool started_; // 0x48
	protected bool smartInitFailed_; // 0x49
	[HideInInspector] // RVA: 0x5B429C Offset: 0x5B429C VA: 0x5B429C
	public bool enabled_; // 0x4A
	[HideInInspector] // RVA: 0x5B42AC Offset: 0x5B42AC VA: 0x5B42AC
	public bool isLoadSceneMap_; // 0x4B
	[HideInInspector] // RVA: 0x5B42BC Offset: 0x5B42BC VA: 0x5B42BC
	protected string sceneMapFilePath_; // 0x4C
	protected IntPtr landmarkBuffer_ = IntPtr.Zero; // 0x50
	protected IntPtr nodePointBuffer_ = IntPtr.Zero; // 0x54
	protected IntPtr initPointBuffer_ = IntPtr.Zero; // 0x58
	protected ulong[] recogCountBuf_; // 0x5C
	protected ulong[] recogTimeBuf_; // 0x60
	public bool PreviewOnly; // 0x64
	private string m_dictDataPath; // 0x68

	public RecognizerSettings recognizerSettings_ { get { return recognizerSettings; } set { ConfigRecognizer(value, false); } } //0x12F5298 0x12F5DF4
	// public RecognizerSettings orgRecognizerSettings_ { get; } 0x12F6DB4
	// public abstract Triangle2[] triangulateMasks_ { get; set; } Slot: 4 Slot: 5
	// public abstract ulong[] recogCount_ { get; }  Slot: 6
	// public abstract ulong[] recogTime_ { get; } Slot: 7

	// // RVA: 0x12F6DBC Offset: 0x12F6DBC VA: 0x12F6DBC
	// public bool isLastRecognized() { }

	// // RVA: 0x12F6DC4 Offset: 0x12F6DC4 VA: 0x12F6DC4
	public void SetDictDataPath(string path)
	{
		m_dictDataPath = path;
	}

	// // RVA: 0x12F6DCC Offset: 0x12F6DCC VA: 0x12F6DCC
	protected bool existsStreamingAsset(string fileName)
	{
		string s = m_dictDataPath;
		if(string.IsNullOrEmpty(m_dictDataPath))
			s = Application.streamingAssetsPath;
		return File.Exists(Path.Combine(s, fileName));
	}

	// // RVA: 0x12F6E94 Offset: 0x12F6E94 VA: 0x12F6E94
	private void CreateDefaultTargets(RecognizerSettings newSettings)
	{
		for(int i = 0; i < newSettings.targets.Length; i++)
		{
			TargetEntry entry = new TargetEntry();
			entry.fileName = newSettings.targets[i].fileName;
			entry.id = newSettings.targets[i].id;
			defaultTargets_.Add(new TargetManager(entry, null, true, false));
		}
	}

	// // RVA: 0x12F5DFC Offset: 0x12F5DFC VA: 0x12F5DFC
	private void ConfigRecognizer(RecognizerSettings newSettings, bool creating)
	{
		if(defaultTargets_.Count == 0)
			CreateDefaultTargets(newSettings);
		bool b = currentTargets_ == null || currentTargets_.Count == 0;
		changeTargetForNotInitMode();
		if(creating || newSettings.maxTargetsPerFrame != recognizerSettings.maxTargetsPerFrame)
		{
			//LAB_012f5f34;
			recognizer_.SetMaxTargetsPerFrame(newSettings.maxTargetsPerFrame);
		}
		//LAB_012f5f60
		if(creating || newSettings.searchPolicy != recognizerSettings.searchPolicy)
		{
			//LAB_012f5f90;
			recognizer_.SetSearchPolicy(newSettings.searchPolicy);
		}
		//LAB_012f5fc0
		if(creating || newSettings.maxTriangulateMasks != recognizerSettings.maxTriangulateMasks)
		{
			//LAB_012f5ff0;
			recognizer_.SetMaxTriangulateMasks(newSettings.maxTriangulateMasks);
		}
		//LAB_012f6020
		if(creating || newSettings.denseMapMode != recognizerSettings.denseMapMode)
		{
			//LAB_012f6050;
			recognizer_.SetDenseMapMode(newSettings.denseMapMode);
		}
		//LAB_012f6080
		if(creating || !Enumerable.SequenceEqual<SmartARControllerBase.TargetEntry>(newSettings.targets, recognizerSettings.targets))
		{
			Target[] oldTargets = targets_;
			targets_ = new Target[newSettings.targets.Length];
			for(int i = 0; i < newSettings.targets.Length; i++)
			{
				string s = newSettings.targets[i].fileName;
				if(newSettings.targets[i].fileName.EndsWith(".v9"))
				{
					s += ".dic";
				}
				if(!isLoadSceneMap_)
				{
					if(!s.EndsWith(".dic"))
						return;
					if(!existsStreamingAsset(s))
					{
						targets_ = null;
						isInitModeTarget();
						return;
					}
					string p = m_dictDataPath;
					if(string.IsNullOrEmpty(m_dictDataPath))
					{
						p = Application.streamingAssetsPath;
					}
					p += "/" + s;
					FileStreamIn fs = new FileStreamIn(smart_, p);
					if(p.EndsWith(".map", StringComparison.OrdinalIgnoreCase))
					{
						targets_[i] = new SceneMapTarget(smart_, fs);
					}
					else
					{
						targets_[i] = new LearnedImageTarget(smart_, fs, null, null);
#if UNITY_EDITOR
						targets_[i].self_ = new IntPtr(newSettings.targets[i].id.GetHashCode());
#endif
					}
					defaultTargets_[i] = new TargetManager(defaultTargets_[i].targetEntry_, targets_[i], defaultTargets_[i].isUse_, defaultTargets_[i].willChangeUsingStatus_);
					if(!b)
					{
						currentTargets_[i] = new TargetManager(currentTargets_[i].targetEntry_, targets_[i], currentTargets_[i].isUse_, currentTargets_[i].willChangeUsingStatus_);
					}
					fs.Close();
				}
				else
				{
					FileStreamIn fs = new FileStreamIn(smart_, sceneMapFilePath_);
					targets_[i] = new SceneMapTarget(smart_, fs);
					if(!b)
					{
						currentTargets_[i] = new TargetManager(currentTargets_[i].targetEntry_, targets_[i], currentTargets_[i].isUse_, currentTargets_[i].willChangeUsingStatus_);
					}
					defaultTargets_[i] = new TargetManager(defaultTargets_[i].targetEntry_, targets_[i], defaultTargets_[i].isUse_, defaultTargets_[i].willChangeUsingStatus_);
					fs.Close();
				}
			}
			if(b)
			{
				currentTargets_ = new List<TargetManager>(defaultTargets_);
				if(isLoadSceneMap_)
				{
					for(int i = 1; i < currentTargets_.Count; i++)
					{
						((IDisposable)currentTargets_[i].target_).Dispose();
					}
					currentTargets_.RemoveRange(1, currentTargets_.Count - 1);
				}
			}
			isLoadSceneMap_ = false;
			recognizer_.SetTargets(targets_);
			if(oldTargets != null)
			{
				for(int i = 0; i < oldTargets.Length; i++)
				{
					((IDisposable)oldTargets[i]).Dispose();
				}
			}
		}
		//LAB_012f6c3c
		recognizerSettings = newSettings;
	}

	// // RVA: 0x12F118C Offset: 0x12F118C VA: 0x12F118C Slot: 8
	protected virtual void DoCreate()
	{
		if(started_)
			return;
		smart_ = new Smart(licenseFileName);
		smartInitFailed_ = smart_.isConstructorFailed();
		if(smartInitFailed_)
			return;
		landmarkDrawer_ = new LandmarkDrawer(smart_);
		CreateRecognizer();
		landmarkBuffer_ = Marshal.AllocCoTaskMem(Recognizer.MAX_NUM_LANDMARKS * Marshal.SizeOf(typeof(Landmark)));
		nodePointBuffer_ = Marshal.AllocCoTaskMem(Recognizer.MAX_NUM_NODE_POINTS * Marshal.SizeOf(typeof(NodePoint)));
		initPointBuffer_ = Marshal.AllocCoTaskMem(Recognizer.MAX_NUM_INITIALIZATION_POINTS * Marshal.SizeOf(typeof(InitPoint)));
	}

	// // RVA: 0x12F32AC Offset: 0x12F32AC VA: 0x12F32AC
	protected void CreateRecognizer()
	{
		recognizer_ = new Recognizer(smart_, recognizerSettings.recognitionMode, recognizerSettings.sceneMappingInitMode);
		ConfigRecognizer(recognizerSettings, true);
		numWorkerThreads_ = 0;
		if(Utility.isMultiCore())
		{
			if(recognizerSettings.useWorkerThread)
			{
				numWorkerThreads_ = 1;
				if(recognizerSettings.recognitionMode == 0)
					numWorkerThreads_ = 2;
			}
		}
		recogCountBuf_ = new ulong[numWorkerThreads_];
		recogTimeBuf_ = new ulong[numWorkerThreads_];
	}

	// // RVA: -1 Offset: -1 Slot: 9
	protected abstract void DoEnable();

	// // RVA: 0x12F20F8 Offset: 0x12F20F8 VA: 0x12F20F8 Slot: 10
	protected virtual void DoDisable()
	{
		if(!enabled_)
			return;
		enabled_ = false;
		if(smartInitFailed_)
			return;
		landmarkDrawer_.Stop();
		recognizer_.Reset();
	}

	// // RVA: 0x12F2518 Offset: 0x12F2518 VA: 0x12F2518 Slot: 11
	protected virtual void DoDestroy()
	{
		if(started_)
		{
			started_ = false;
			if(smartInitFailed_)
				return;
			RemoveRecognizer();
			Marshal.FreeCoTaskMem(landmarkBuffer_);
			landmarkBuffer_ = IntPtr.Zero;
			Marshal.FreeCoTaskMem(nodePointBuffer_);
			nodePointBuffer_ = IntPtr.Zero;
			Marshal.FreeCoTaskMem(initPointBuffer_);
			initPointBuffer_ = IntPtr.Zero;
			landmarkDrawer_.Dispose();
			smart_.Dispose();
		}
	}

	// // RVA: 0x12F2DDC Offset: 0x12F2DDC VA: 0x12F2DDC
	protected void RemoveRecognizer()
	{
		if(!smartInitFailed_)
		{
			recognizer_.SetTargets(null);
			recognizer_.Dispose();
			if(targets_ != null)
			{
				for(int i = 0; i < targets_.Length; i++)
				{
					((IDisposable)targets_[i]).Dispose();
				}
			}
			if(currentTargets_ != null)
			{
				for(int i = 0; i < currentTargets_.Count; i++)
				{
					((IDisposable)currentTargets_[i].target_).Dispose();
				}
				currentTargets_.Clear();
				currentTargets_ = null;
			}
		}
	}

	// // RVA: 0x12F27A8 Offset: 0x12F27A8 VA: 0x12F27A8 Slot: 12
	public virtual void resetController()
	{
		recognizer_.Reset();
	}

	// // RVA: 0x12F767C Offset: 0x12F767C VA: 0x12F767C
	public void restartController()
	{
		DoDisable();
		DoDestroy();
		DoCreate();
	}

	// // RVA: 0x12F76C8 Offset: 0x12F76C8 VA: 0x12F76C8
	// public void reCreateController(RecognitionMode recognitionMode, SceneMappingInitMode sceneMappingInitMode = 0) { }

	// // RVA: -1 Offset: -1 Slot: 13
	// public abstract int saveSceneMap(StreamOut stream);

	// // RVA: 0x12F7ABC Offset: 0x12F7ABC VA: 0x12F7ABC
	// public void loadSceneMap(string filePath) { }

	// RVA: 0x12F7C74 Offset: 0x12F7C74 VA: 0x12F7C74 Slot: 14
	protected virtual void Awake()
	{
		DoCreate();
		orgRecognizerSettings.recognitionMode = recognizerSettings.recognitionMode;
		orgRecognizerSettings.sceneMappingInitMode = recognizerSettings.sceneMappingInitMode;
		orgRecognizerSettings.targets = new TargetEntry[recognizerSettings.targets.Length];
		for(int i = 0; i < recognizerSettings.targets.Length; i++)
		{
			orgRecognizerSettings.targets[i] = new TargetEntry();
			orgRecognizerSettings.targets[i].fileName = recognizerSettings.targets[i].fileName;
			orgRecognizerSettings.targets[i].id = recognizerSettings.targets[i].id;
		}
		orgRecognizerSettings.maxTargetsPerFrame = recognizerSettings.maxTargetsPerFrame;
		orgRecognizerSettings.searchPolicy = recognizerSettings.searchPolicy;
		orgRecognizerSettings.maxTriangulateMasks = recognizerSettings.maxTriangulateMasks;
		orgRecognizerSettings.denseMapMode = recognizerSettings.denseMapMode;
		orgRecognizerSettings.useWorkerThread = recognizerSettings.useWorkerThread;
		if(SystemInfo.graphicsDeviceType == UnityEngine.Rendering.GraphicsDeviceType.Metal)
		{
			TodoLogger.LogError(0, "Metal");
		}
	}

	// RVA: 0x12F87EC Offset: 0x12F87EC VA: 0x12F87EC
	private void OnEnable()
	{
		return;
	}

	// RVA: 0x12F87F0 Offset: 0x12F87F0 VA: 0x12F87F0
	private void OnDisable()
	{
		DoDisable();
	}

	// RVA: 0x12F8800 Offset: 0x12F8800 VA: 0x12F8800
	private void OnDestroy()
	{
		DoDisable();
		DoDestroy();
		if(defaultTargets_ != null)
		{
			for(int i = 0; i < defaultTargets_.Count; i++)
			{
				((IDisposable)defaultTargets_[i].target_).Dispose();
			}
		}
		defaultTargets_.Clear();
		defaultTargets_ = null;
	}

	// RVA: 0x12F8AD0 Offset: 0x12F8AD0 VA: 0x12F8AD0
	private void OnApplicationPause(bool pause)
	{
		DoDisable();
	}

	// RVA: 0x12F8AE0 Offset: 0x12F8AE0 VA: 0x12F8AE0
	private void OnApplicationQuit()
	{
		DoDisable();
		DoDestroy();
	}

	// RVA: 0x12F8B18 Offset: 0x12F8B18 VA: 0x12F8B18
	private void OnValidate()
	{
		if(defaultTargets_ == null)
			defaultTargets_ = new List<TargetManager>();
		if(defaultTargets_.Count == 0)
			CreateDefaultTargets(recognizerSettings);
		if(!isInitModeTarget())
		{
			if(recognizerSettings.targets.Length == 0)
				return;
			recognizerSettings.targets = new TargetEntry[] { recognizerSettings.targets[0] };
			currentTargets_.RemoveRange(1, currentTargets_.Count - 1);
		}
	}

	// // RVA: 0x12F74F0 Offset: 0x12F74F0 VA: 0x12F74F0
	public bool isInitModeTarget()
	{
		bool b = true;
		if(!isLoadSceneMap_)
		{
			b = false;
			if(currentTargets_ != null && currentTargets_.Count != 0)
			{
				if(currentTargets_[0].target_ != null)
					b = currentTargets_[0].target_ is SceneMapTarget;
			}
		}
		if(recognizerSettings.recognitionMode == RecognitionMode.RECOGNITION_MODE_SCENE_MAPPING && recognizerSettings.sceneMappingInitMode == 0)
		{
			return recognizerSettings.recognitionMode == 0 || !b;
		}
		return recognizerSettings.recognitionMode == 0;
	}

	// // RVA: 0x12F7064 Offset: 0x12F7064 VA: 0x12F7064
	protected void changeTargetForNotInitMode()
	{
		if(!isInitModeTarget())
		{
			if(recognizerSettings.targets.Length != 0)
			{
				recognizerSettings.targets = new TargetEntry[1] { recognizerSettings.targets[0] };
				currentTargets_.RemoveRange(1, currentTargets_.Count - 1);
				return;
			}
		}
		if(defaultTargets_ != null && defaultTargets_.Count > 0)
		{
			recognizerSettings.targets = new TargetEntry[defaultTargets_.Count];
			for(int i = 0; i < defaultTargets_.Count; i++)
			{
				recognizerSettings.targets[i] = new TargetEntry();
				recognizerSettings.targets[i].fileName = defaultTargets_[i].targetEntry_.fileName;
				recognizerSettings.targets[i].id = defaultTargets_[i].targetEntry_.id;
			}
		}
	}

	// // RVA: 0x12F3EA0 Offset: 0x12F3EA0 VA: 0x12F3EA0
	public int GetResult(string id, ref RecognitionResult result)
	{
		if(currentTargets_ != null)
		{
			if(id == null || id == "")
			{
				int res = CallNativeGetResult(self_, IntPtr.Zero, ref result);
				isRecognized_ = result.isRecognized_;
				return res;
			}
			else
			{
				for(int i = 0; i < currentTargets_.Count; i++)
				{
					if(currentTargets_[i].targetEntry_.id == id)
					{
						if(currentTargets_[i].isUse_)
						{
							if(targets_ != null)
							{
								int res = CallNativeGetResult(self_, currentTargets_[i].target_.self_, ref result);
								isRecognized_ = result.isRecognized_;
								if(isRecognized_)
								{
									//UnityEngine.Debug.LogError(result.position_.x_+" "+result.position_.y_+" "+result.position_.z_+" "+result.rotation_.x_+" "+result.rotation_.y_+" "+result.rotation_.z_+" "+result.rotation_.w_);
									string nodeTxt = "";
									if(result.nodePoints_ != IntPtr.Zero && result.numNodePoints_ > 0)
									{
										IntPtr p = result.nodePoints_;
										for(int j = 0; j < result.numNodePoints_; j++)
										{
											NodePoint np = (NodePoint)Marshal.PtrToStructure(p, typeof(NodePoint));

											nodeTxt += "  "+np.id_+" "+np.position_.x_+" "+np.position_.y_+" "+np.position_.z_+"\n";

											int s = Marshal.SizeOf<NodePoint>(np);
											p += s;
										}
									}
									string landTxt = "";
									if(result.landmarks_ != IntPtr.Zero && result.numLandmarks_ > 0)
									{
										IntPtr p = result.landmarks_;
										for(int j = 0; j < result.numLandmarks_; j++)
										{
											Landmark np = (Landmark)Marshal.PtrToStructure(p, typeof(Landmark));

											landTxt += "  "+np.id_+" "+np.state_+" "+np.position_.x_+" "+np.position_.y_+" "+np.position_.z_+"\n";

											int s = Marshal.SizeOf<Landmark>(np);
											p += s;
										}
									}
									string initTxt = "";
									if(result.initPoints_ != IntPtr.Zero && result.numInitPoints_ > 0)
									{
										IntPtr p = result.initPoints_;
										for(int j = 0; j < result.numInitPoints_; j++)
										{
											InitPoint np = (InitPoint)Marshal.PtrToStructure(p, typeof(InitPoint));

											initTxt += "  "+np.id_+" "+np.position_.x_+" "+np.position_.y_+"\n";

											int s = Marshal.SizeOf<InitPoint>(np);
											p += s;
										}
									}
									ARDebugScreen.Instance.AddText(ARDebugScreen.TextType.Result, currentTargets_[i].targetEntry_.id+"\n"+
											result.position_.x_+" "+result.position_.y_+" "+result.position_.z_+"\n"+
											result.rotation_.x_+" "+result.rotation_.y_+" "+result.rotation_.z_+" "+result.rotation_.w_+"\n"+
											result.targetTrackingState_+"\n"+
											result.sceneMappingState_+"\n"+
											result.numLandmarks_+"\n"+landTxt+
											result.maxLandmarks_+"\n"+
											result.numNodePoints_+"\n"+nodeTxt+
											result.maxNodePoints_+"\n"+
											result.numInitPoints_+"\n"+initTxt+
											result.maxInitPoints_+"\n"
										);
								}
								return res;
							}
							break;
						}
					}
				}
				result = new RecognitionResult();
				isRecognized_ = false;
				return Error.ERROR_INVALID_VALUE;
			}
		}
		return 0;
	}

	// // RVA: -1 Offset: -1 Slot: 15
	protected abstract int CallNativeGetResult(IntPtr self, IntPtr target, ref RecognitionResult result);

	// // RVA: 0x12F4200 Offset: 0x12F4200 VA: 0x12F4200
	// protected Matrix44 getProjMatrix(Camera camera) { }

	// // RVA: 0x12F8D40 Offset: 0x12F8D40 VA: 0x12F8D40
	public static void adjustPose(Rotation cameraRotation, Rotation screenRotation, bool isFlipX, bool isFlipY, smartar.Vector3 srcPosition, smartar.Quaternion srcRotation, out smartar.Vector3 rotPosition, out smartar.Quaternion rotRotation)
	{

        Rotation r = (Rotation)((cameraRotation + 360 - screenRotation) % 360);
        rotPosition = srcPosition;
        rotRotation = srcRotation;
        if(isFlipX)
        {
            rotPosition.x_ = -rotPosition.x_;
            srcRotation.z_ = -rotRotation.z_;
            rotRotation.y_ = -rotRotation.y_;
            rotRotation.z_ = srcRotation.z_;
        }
        if(isFlipY)
        {
            rotPosition.y_ = -rotPosition.y_;
            srcRotation.z_ = -rotRotation.z_;
            rotRotation.x_ = -rotRotation.x_;
            rotRotation.z_ = srcRotation.z_;
        }
        float f1;
        if(r == Rotation.ROTATION_0)
            return;
        else if(r == Rotation.ROTATION_90)
        {
            f1 = 0.7853982f;
        }
        else if(r == Rotation.ROTATION_180)
        {
            f1 = 1.570796f;
        }
        else if(r == Rotation.ROTATION_270)
        {
            f1 = 2.356194f;
        }
        else
        {
            throw new InvalidOperationException("unexpected value: " + r);
        }
        UnityEngine.Quaternion q = new UnityEngine.Quaternion(rotRotation.x_ , rotRotation.z_, rotRotation.y_, rotRotation.w_) * new UnityEngine.Quaternion(0, Mathf.Sin(f1), 0, Mathf.Cos(f1));
        rotRotation.x_ = q.x;
        rotRotation.y_ = q.z;
        rotRotation.z_ = q.y;
        rotRotation.w_ = q.w;
	}

	// // RVA: 0x12F8730 Offset: 0x12F8730 VA: 0x12F8730
	// private static extern IntPtr GetRenderEventFunc() { }
}
