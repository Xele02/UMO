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
        TryInit();
		isInitialized = true;
	}

    public T AddMovie<T>() where T : MoviePlayback
    {
        GameObject g = new GameObject();
        g.transform.parent = transform;
        return g.AddComponent<T>();
    }

    void TryInit()
    {
        if(_libVLC == null)
        {
#if !UNITY_ANDROID
			Core.Initialize(Application.dataPath+"/Scripts/LibVlCSharp/LibVLC/x64/");

            _libVLC = new LibVLC(enableDebugLogs: true);
#endif

            //Application.SetStackTraceLogType(LogType.Log, StackTraceLogType.None);
            //_libVLC.Log += (s, e) => UnityEngine.Debug.Log(e.FormattedLog); // enable this for logs in the editor
        }
    }

    void OnDestroy()
    {
        _libVLC?.Dispose();
        _libVLC = null;
    }

	public bool IsInitialized { get { return isInitialized && !RuntimeSettings.CurrentSettings.DisableMovies
    #if UNITY_EDITOR_LINUX || UNITY_EDITOR_OSX
        && false
    #endif
    ; } }
}
