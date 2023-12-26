
using System;
using System.Runtime.InteropServices;

namespace smartar
{
    public enum RecognitionMode
    {
        RECOGNITION_MODE_TARGET_TRACKING = 0,
        RECOGNITION_MODE_SCENE_MAPPING = 1,
    }

    public enum SearchPolicy
    {
        SEARCH_POLICY_FAST = 0,
        SEARCH_POLICY_PRECISIVE = 1,
    }

    public enum SceneMappingInitMode
    {
        SCENE_MAPPING_INIT_MODE_TARGET = 0,
        SCENE_MAPPING_INIT_MODE_HFG = 1,
        SCENE_MAPPING_INIT_MODE_VFG = 2,
        SCENE_MAPPING_INIT_MODE_SFM = 3,
        SCENE_MAPPING_INIT_MODE_DRY_RUN = 4,
    }

    public enum TargetTrackingState
    {
        TARGET_TRACKING_STATE_IDLE = 0,
        TARGET_TRACKING_STATE_SEARCH = 1,
        TARGET_TRACKING_STATE_TRACKING = 2,
    }

    public enum SceneMappingState
    {
        SCENE_MAPPING_STATE_IDLE = 0,
        SCENE_MAPPING_STATE_SEARCH = 1,
        SCENE_MAPPING_STATE_TRACKING = 2,
        SCENE_MAPPING_STATE_LOCALIZE = 3,
        SCENE_MAPPING_STATE_LOCALIZE_IMPOSSIBLE = 4,
    }

    public enum LandmarkState
    {
        LANDMARK_STATE_TRACKED = 0,
        LANDMARK_STATE_LOST = 1,
        LANDMARK_STATE_SUSPENDED = 2,
        LANDMARK_STATE_MASKED = 3,
    }

    public enum DenseMapMode
    {
        DENSE_MAP_DISABLE = 0,
        DENSE_MAP_SEMI_DENSE = 1,
    }

    public class Recognizer : IDisposable
    {
        private delegate void WorkDispatchedListenerDelegate();

        private delegate void RecognizedListenerDelegate(IntPtr resultHolder);

        private class MonoPInvokeCallbackAttribute : Attribute
        {
            protected Type type; // 0x8

            // RVA: 0x2B45E80 Offset: 0x2B45E80 VA: 0x2B45E80
            public MonoPInvokeCallbackAttribute(Type t)
            {
                type = t;
            }
        }

        private struct ProxyListeners
        {
            public IntPtr workDispatchedListener_; // 0x0
            public IntPtr recognizedListener_; // 0x4
        }

        private struct ProxyListenerDelegates
        {
            public IntPtr workDispatchedListenerDelegate_; // 0x0
            public IntPtr recognizedListenerDelegate_; // 0x4
        }

        public static readonly int MAX_NUM_LANDMARKS = 512; // 0x0
        public static readonly int MAX_NUM_NODE_POINTS = 2048; // 0x4
        public static readonly int MAX_NUM_INITIALIZATION_POINTS = 64; // 0x8
        public static readonly int MAX_PROPAGATION_DURATION = 3000000; // 0xC
        public IntPtr self_; // 0x8
        private static Recognizer thisObj_ = null; // 0x10
        private ProxyListenerDelegates proxyListenerDelegates_; // 0xC
        private ProxyListeners proxyListeners_; // 0x14
        private WorkDispatchedListener workDispatchedListener_; // 0x1C
        private RecognizedListener recognizedListener_; // 0x20
        private RecognitionResultHolder resultHolder_ = new RecognitionResultHolder(IntPtr.Zero); // 0x24

        // RVA: 0x20C2AD4 Offset: 0x20C2AD4 VA: 0x20C2AD4
        public Recognizer(Smart smart, RecognitionMode recogMode = 0, SceneMappingInitMode initMode = 0)
        {
            self_ = sarSmartar_SarRecognizer_SarRecognizer(smart.self_, recogMode, initMode);
            thisObj_ = this;
            proxyListenerDelegates_.workDispatchedListenerDelegate_ = Marshal.GetFunctionPointerForDelegate(new WorkDispatchedListenerDelegate(OnWorkDispatched));
            proxyListenerDelegates_.recognizedListenerDelegate_ = Marshal.GetFunctionPointerForDelegate(new RecognizedListenerDelegate(OnRecognized));
            sarSmartar_SarRecognizerProxyListeners_sarCreate(ref proxyListenerDelegates_, out proxyListeners_);
        }

        // RVA: 0x20C2EAC Offset: 0x20C2EAC VA: 0x20C2EAC Slot: 1
        ~Recognizer()
        {
            Dispose();
        }

        // RVA: 0x20C2F10 Offset: 0x20C2F10 VA: 0x20C2F10 Slot: 4
        public void Dispose()
        {
            if(self_ != null)
            {
                sarSmartar_SarRecognizer_sarDelete(self_);
                self_ = IntPtr.Zero;
                sarSmartar_SarRecognizerProxyListeners_sarDelete(ref proxyListeners_);
                thisObj_ = null;
            }
        }

        [MonoPInvokeCallbackAttribute(typeof(WorkDispatchedListenerDelegate))] // RVA: 0x5E0B3C Offset: 0x5E0B3C VA: 0x5E0B3C
        // // RVA: 0x20C27C4 Offset: 0x20C27C4 VA: 0x20C27C4
        private static void OnWorkDispatched()
        {
            thisObj_.workDispatchedListener_.OnWorkDispatched();
        }

        [MonoPInvokeCallbackAttribute(typeof(RecognizedListenerDelegate))] // RVA: 0x5E0BB4 Offset: 0x5E0BB4 VA: 0x5E0BB4
        // // RVA: 0x20C28EC Offset: 0x20C28EC VA: 0x20C28EC
        private static void OnRecognized(IntPtr resultHolder)
        {
            thisObj_.resultHolder_.self_ = resultHolder;
            thisObj_.recognizedListener_.OnRecognized(thisObj_.resultHolder_);
            thisObj_.resultHolder_.self_ = IntPtr.Zero;
        }

        // // RVA: 0x20C2DB0 Offset: 0x20C2DB0 VA: 0x20C2DB0
        [DllImport("smartar")]
        private static extern void sarSmartar_SarRecognizerProxyListeners_sarCreate(ref Recognizer.ProxyListenerDelegates delegates, out Recognizer.ProxyListeners listeners);

        // // RVA: 0x20C30C0 Offset: 0x20C30C0 VA: 0x20C30C0
        [DllImport("smartar")]
        private static extern void sarSmartar_SarRecognizerProxyListeners_sarDelete(ref Recognizer.ProxyListeners listeners);

        // // RVA: 0x20C31B4 Offset: 0x20C31B4 VA: 0x20C31B4
        public int SetCameraDeviceInfo(CameraDeviceInfo info)
        {
            return sarSmartar_SarRecognizer_sarSetCameraDeviceInfo(self_, info.self_);
        }

        // // RVA: 0x20C3350 Offset: 0x20C3350 VA: 0x20C3350
        public int SetSensorDeviceInfo(SensorDeviceInfo info)
        {
            return sarSmartar_SarRecognizer_sarSetSensorDeviceInfo(self_, info.self_);
        }

        // RVA: 0x20C34E8 Offset: 0x20C34E8 VA: 0x20C34E8
        public int SetTargets(Target[] targets)
        {
            if(targets == null)
            {
                return sarSmartar_SarRecognizer_sarSetTargets(self_, null, 0);
            }
            else
            {
                IntPtr[] l = new IntPtr[targets.Length];
                for(int i = 0; i < targets.Length; i++)
                {
                    if(targets[i] == null)
                        break;
                    l[i] = targets[i].self_;
                }
                return sarSmartar_SarRecognizer_sarSetTargets(self_, l, targets.Length);
            }
        }

        // RVA: 0x20C3798 Offset: 0x20C3798 VA: 0x20C3798
        public int Reset()
        {
            return sarSmartar_SarRecognizer_sarReset(self_);
        }

        // // RVA: 0x20C3904 Offset: 0x20C3904 VA: 0x20C3904
        // public int Run(RecognitionRequest request) { }

        // // RVA: 0x20C3AB8 Offset: 0x20C3AB8 VA: 0x20C3AB8
        // public int Dispatch(RecognitionRequest request) { }

        // // RVA: 0x20C3C70 Offset: 0x20C3C70 VA: 0x20C3C70
        // public int RunWorker() { }

        // // RVA: 0x20C3DE0 Offset: 0x20C3DE0 VA: 0x20C3DE0
        // public int SetWorkDispatchedListener(WorkDispatchedListener listener) { }

        // // RVA: 0x20C3F80 Offset: 0x20C3F80 VA: 0x20C3F80
        // public int GetNumResults() { }

        // // RVA: 0x20C40F4 Offset: 0x20C40F4 VA: 0x20C40F4
        // public int GetResults(RecognitionResult[] results) { }

        // // RVA: 0x20C42D0 Offset: 0x20C42D0 VA: 0x20C42D0
        // public int GetResult(Target target, out RecognitionResult result) { }

        // // RVA: 0x20C4528 Offset: 0x20C4528 VA: 0x20C4528
        // public int SetRecognizedListener(RecognizedListener listener) { }

        // RVA: 0x20C46C4 Offset: 0x20C46C4 VA: 0x20C46C4
        public int SetMaxTargetsPerFrame(int maxTargets)
        {
            return sarSmartar_SarRecognizer_sarSetMaxTargetsPerFrame(self_, maxTargets);
        }

        // RVA: 0x20C484C Offset: 0x20C484C VA: 0x20C484C
        public int SetSearchPolicy(SearchPolicy policy)
        {
            return sarSmartar_SarRecognizer_sarSetSearchPolicy(self_, policy);
        }

        // // RVA: 0x20C49CC Offset: 0x20C49CC VA: 0x20C49CC
        // public int PropagateResult(RecognitionResult fromResult, out RecognitionResult toResult, ulong timestamp, bool useVelocity = True) { }

        // RVA: 0x20C4D9C Offset: 0x20C4D9C VA: 0x20C4D9C
        public int SetMaxTriangulateMasks(int maxMasks)
        {
            return sarSmartar_SarRecognizer_sarSetMaxTriangulateMasks(self_, maxMasks);
        }

        // // RVA: 0x20C4F24 Offset: 0x20C4F24 VA: 0x20C4F24
        // public int SaveSceneMap(StreamOut stream) { }

        // // RVA: 0x20C50BC Offset: 0x20C50BC VA: 0x20C50BC
        // public int FixSceneMap(bool isFix) { }

        // // RVA: 0x20C5238 Offset: 0x20C5238 VA: 0x20C5238
        // public int ForceLocalize() { }

        // // RVA: 0x20C53AC Offset: 0x20C53AC VA: 0x20C53AC
        // public int RemoveLandmark(Landmark landmark) { }

        // RVA: 0x20C5544 Offset: 0x20C5544 VA: 0x20C5544
        public int SetDenseMapMode(DenseMapMode mode)
        {
            return sarSmartar_SarRecognizer_sarSetDenseMapMode(self_, mode);
        }

        // // RVA: 0x20C2CB8 Offset: 0x20C2CB8 VA: 0x20C2CB8
        [DllImport("smartar")]
        private static extern IntPtr sarSmartar_SarRecognizer_SarRecognizer(IntPtr smart, RecognitionMode recogMode, SceneMappingInitMode initMode);

        // // RVA: 0x20C2FD8 Offset: 0x20C2FD8 VA: 0x20C2FD8
        [DllImport("smartar")]
        private static extern void sarSmartar_SarRecognizer_sarDelete(IntPtr self);

        // // RVA: 0x20C3258 Offset: 0x20C3258 VA: 0x20C3258
        [DllImport("smartar")]
        private static extern int sarSmartar_SarRecognizer_sarSetCameraDeviceInfo(IntPtr self, IntPtr info);

        // // RVA: 0x20C33F0 Offset: 0x20C33F0 VA: 0x20C33F0
        [DllImport("smartar")]
        private static extern int sarSmartar_SarRecognizer_sarSetSensorDeviceInfo(IntPtr self, IntPtr info);

        // // RVA: 0x20C3698 Offset: 0x20C3698 VA: 0x20C3698
        [DllImport("smartar")]
        private static extern int sarSmartar_SarRecognizer_sarSetTargets(IntPtr self, IntPtr[] targets, int numTargets);

        // // RVA: 0x20C3820 Offset: 0x20C3820 VA: 0x20C3820
        [DllImport("smartar")]
        private static extern int sarSmartar_SarRecognizer_sarReset(IntPtr self);

        // // RVA: 0x20C39D0 Offset: 0x20C39D0 VA: 0x20C39D0
        // private static extern int sarSmartar_SarRecognizer_sarRun(IntPtr self, ref RecognitionRequest request) { }

        // // RVA: 0x20C3B80 Offset: 0x20C3B80 VA: 0x20C3B80
        // private static extern int sarSmartar_SarRecognizer_sarDispatch(IntPtr self, ref RecognitionRequest request) { }

        // // RVA: 0x20C3CF8 Offset: 0x20C3CF8 VA: 0x20C3CF8
        // private static extern int sarSmartar_SarRecognizer_sarRunWorker(IntPtr self) { }

        // // RVA: 0x20C3E80 Offset: 0x20C3E80 VA: 0x20C3E80
        // private static extern int sarSmartar_SarRecognizer_sarSetWorkDispatchedListener(IntPtr self, IntPtr listener) { }

        // // RVA: 0x20C4008 Offset: 0x20C4008 VA: 0x20C4008
        // private static extern int sarSmartar_SarRecognizer_sarGetNumResults(IntPtr self) { }

        // // RVA: 0x20C41D8 Offset: 0x20C41D8 VA: 0x20C41D8
        // private static extern int sarSmartar_SarRecognizer_sarGetResults(IntPtr self, IntPtr results, int maxResults) { }

        // // RVA: 0x20C4378 Offset: 0x20C4378 VA: 0x20C4378
        // private static extern int sarSmartar_SarRecognizer_sarGetResult(IntPtr self, IntPtr target, out RecognitionResult result) { }

        // // RVA: 0x20C45C8 Offset: 0x20C45C8 VA: 0x20C45C8
        // private static extern int sarSmartar_SarRecognizer_sarSetRecognizedListener(IntPtr self, IntPtr listener) { }

        // // RVA: 0x20C4750 Offset: 0x20C4750 VA: 0x20C4750
        [DllImport("smartar")]
        private static extern int sarSmartar_SarRecognizer_sarSetMaxTargetsPerFrame(IntPtr self, int maxTargets);

        // // RVA: 0x20C48D8 Offset: 0x20C48D8 VA: 0x20C48D8
        [DllImport("smartar")]
        private static extern int sarSmartar_SarRecognizer_sarSetSearchPolicy(IntPtr self, SearchPolicy policy);

        // // RVA: 0x20C4A90 Offset: 0x20C4A90 VA: 0x20C4A90
        // private static extern int sarSmartar_SarRecognizer_sarPropagateResult(IntPtr self, ref RecognitionResult fromResult, out RecognitionResult toResult, ulong timestamp, bool useVelocity) { }

        // // RVA: 0x20C4E28 Offset: 0x20C4E28 VA: 0x20C4E28
        [DllImport("smartar")]
        private static extern int sarSmartar_SarRecognizer_sarSetMaxTriangulateMasks(IntPtr self, int maxMasks);

        // // RVA: 0x20C4FC8 Offset: 0x20C4FC8 VA: 0x20C4FC8
        // private static extern int sarSmartar_SarRecognizer_sarSaveSceneMap(IntPtr self, IntPtr stream) { }

        // // RVA: 0x20C5148 Offset: 0x20C5148 VA: 0x20C5148
        // private static extern int sarSmartar_SarRecognizer_sarFixSceneMap(IntPtr self, bool isFix) { }

        // // RVA: 0x20C52C0 Offset: 0x20C52C0 VA: 0x20C52C0
        // private static extern int sarSmartar_SarRecognizer_sarForceLocalize(IntPtr self) { }

        // // RVA: 0x20C5450 Offset: 0x20C5450 VA: 0x20C5450
        // private static extern int sarSmartar_SarRecognizer_sarRemoveLandmark(IntPtr self, ref Landmark landmark) { }

        // // RVA: 0x20C55D0 Offset: 0x20C55D0 VA: 0x20C55D0
        [DllImport("smartar")]
        private static extern int sarSmartar_SarRecognizer_sarSetDenseMapMode(IntPtr self, DenseMapMode mode);
    }
}