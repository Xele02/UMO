using UnityEngine;
using LibVLCSharp.Shared;
using XeSys;

public class VLCManager : SingletonMonoBehaviour<VLCManager>
{
    private LibVLC _libVLC;
    public LibVLC VLC { get { return _libVLC;} }

	private bool isInitialized = false;

    public void Awake()
    {
        UnityEngine.Object.DontDestroyOnLoad(this);
		isInitialized = true;
        TryInit();
	}

    void TryInit()
    {
        if(_libVLC == null)
        {
#if !UNITY_ANDROID
			Core.Initialize(Application.dataPath+"/Scripts/LibVlCSharp/LibVLC/x64/");
#endif

            _libVLC = new LibVLC(enableDebugLogs: true);

            //Application.SetStackTraceLogType(LogType.Log, StackTraceLogType.None);
            //_libVLC.Log += (s, e) => UnityEngine.Debug.Log(e.FormattedLog); // enable this for logs in the editor
        }
    }

    void OnDestroy()
    {
        _libVLC?.Dispose();
        _libVLC = null;
    }

	public bool IsInitialized { get { return isInitialized; } }
}
