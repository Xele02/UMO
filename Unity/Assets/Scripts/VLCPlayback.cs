using UnityEngine;
using System;
using LibVLCSharp.Shared;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;

[InitializeOnLoadAttribute]
public static class VLCPauseStateChanged
{
    // register an event handler when the class is initialized
    static VLCPauseStateChanged()
    {
        EditorApplication.pauseStateChanged += LogPauseState;
    }

    public static List<VLCPlayback> playbacks = new List<VLCPlayback>();

    private static void LogPauseState(PauseState state)
    {
        if(Application.isPlaying)
        {
            for(int i = 0; i < playbacks.Count; i++)
            {
                playbacks[i].SetPauseEditor(state == PauseState.Paused);
            }
        }
    }
}
#endif

/// this class serves as an example on how to configure playback in Unity with VLC for Unity using LibVLCSharp.
/// for libvlcsharp usage documentation, please visit https://code.videolan.org/videolan/LibVLCSharp/-/blob/master/docs/home.md
public class VLCPlayback : MonoBehaviour
{
    MediaPlayer _mediaPlayer;
    const int seekTimeDelta = 5000;
    Texture2D tex = null;
    bool playing;
    public string videoPath;
    
    uint width;
    uint height;
    uint pitch;
    uint lines;
    public MemoryStream ms;
    static int s_playerId = 0;
    int playerId;
    string mapFileName;

    bool loop = false;

    private VLCState state;

    bool pauseEditor = false;
    bool pause = false;

    void Awake()
    {
        //TextureHelper.FlipTextures(transform);
        playerId = s_playerId++;
        #if UNITY_EDITOR
        VLCPauseStateChanged.playbacks.Add(this);
        #endif
    }

    /*public void SeekForward()
    {
        Debug.Log("[VLC] Seeking forward !");
        _mediaPlayer.SetTime(_mediaPlayer.Time + seekTimeDelta);
    }

    public void SeekBackward()
    {
        Debug.Log("[VLC] Seeking backward !");
        _mediaPlayer.SetTime(_mediaPlayer.Time - seekTimeDelta);
    }*/

    void OnDestroy()
    {
        #if UNITY_EDITOR
        VLCPauseStateChanged.playbacks.Remove(this);
        #endif
        _mediaPlayer?.Stop();

        if(_mediaPlayer?.Media != null)
        {
            _mediaPlayer?.Media.Dispose();
        }

        _mediaPlayer?.Dispose();
        _mediaPlayer = null;


        CurrentMappedViewAccessor?.Dispose();
        CurrentMappedViewAccessor = null;
        CurrentMappedFile?.Dispose();
        CurrentMappedFile = null;

        ms?.Close();
        ms?.Dispose();
        ms = null;
        #if UNITY_EDITOR
        VLCPauseStateChanged.playbacks.Remove(this);
        #endif
    }

    void OnDisable() 
    {
        _mediaPlayer?.Stop();
        _mediaPlayer?.Dispose();
        _mediaPlayer = null;
    }

    bool isReady = false;

    public IEnumerator Prepare(int _width = -1, int _height = -1)
    {
        UnityEngine.Debug.Log("Start preparing VLC player");
        if (_mediaPlayer == null)
        {
            _mediaPlayer = new MediaPlayer(VLCManager.Instance.VLC);
        }
        if(_mediaPlayer.Media == null)
        {
            // playing remote media
            //_mediaPlayer.Media = new Media(_libVLC, new Uri("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"));
            //_mediaPlayer.Media = new Media(_libVLC, videoPath);
            _mediaPlayer.Media = new Media(VLCManager.Instance.VLC, new StreamMediaInput(ms));
        }

        mapFileName = "VLC"+playerId;

        //var task = _mediaPlayer.Media.Parse(MediaParseOptions.ParseLocal);
        // width = 888;
        // height = 504;
        if(_width == -1 || _height == -1)
        {
            this.width = 10;
            this.height = 10;
            pitch = Align(this.width * 4);
            lines = Align(this.height);
            _mediaPlayer.SetVideoFormat("RV32", this.width, this.height, pitch);
            _mediaPlayer.SetVideoCallbacks(this.Lock, null, this.Display);
            _mediaPlayer.SetRate(0);
            _mediaPlayer.Play();
            while(_mediaPlayer.Media.State != VLCState.Playing)
            {
                yield return null;
            }
            
            while(width == 10)
            {
                uint i_videoHeight = 0;
                uint i_videoWidth = 0;

                _mediaPlayer.Size(0, ref i_videoWidth, ref i_videoHeight);
                if(i_videoWidth != 0 && i_videoHeight != 0)
                {
                    width = i_videoWidth;
                    height = i_videoHeight;
                }
                yield return null;
            }
            UnityEngine.Debug.Log("Video size : "+width+" "+height);
            
            _mediaPlayer.Stop();
            while(_mediaPlayer.Media.State != VLCState.Stopped)
            {
                yield return null;
            }
            
            CurrentMappedViewAccessor.Dispose();
            CurrentMappedViewAccessor = null;
            CurrentMappedFile.Dispose();
            CurrentMappedFile = null;
        }
        else
        {
            width = (uint)_width;
            height = (uint)_height;
        }
        pitch = Align(width * 4);
        lines = Align(height);
        _mediaPlayer.SetVideoFormat("RV32", width, height, pitch);
        _mediaPlayer.SetVideoCallbacks(this.Lock, null, this.Display);

        CurrentMappedFile = MemoryMappedFile.CreateOrOpen(mapFileName, pitch * lines);
        CurrentMappedViewAccessor = CurrentMappedFile.CreateViewAccessor();
        tex = new Texture2D((int)width,
                    (int)height,
                    TextureFormat.RGBA32,
                    false,
                    true);

        state = _mediaPlayer.Media.State;
        _mediaPlayer.Media.StateChanged += OnStateChanged;
        
        UnityEngine.Debug.Log("VLC player ready");
        isReady = true;
    }

    private void OnStateChanged(object sender, MediaStateChangedEventArgs e)
    {
        state = _mediaPlayer.Media.State;
    }

    public VLCState GetState()
    {
        return state;
    }

    public bool IsReady()
    {
        return isReady;
    }

    public MediaTrack[] GetTracksInfo()
    {
        if(_mediaPlayer != null && _mediaPlayer.Media != null)
        {
            MediaTrack[] tracks = _mediaPlayer.Media.Tracks;
            return tracks;
        }
        return null;
    }

    public void PlayPause()
    {
        Debug.Log ("[VLC] Toggling Play Pause !");
        if (_mediaPlayer.IsPlaying)
        {
            _mediaPlayer.Pause();
        }
        else
        {
            StartPlay();
        }
    }

    public void SetLoop(bool loop)
    {
        this.loop = loop;
    }

    public void StartPlay()
    {
        Debug.Log ("[VLC] Start Player !");
        playing = true;

        if(!_mediaPlayer.Play())
            UnityEngine.Debug.Log("Play error");
        _mediaPlayer.SetRate(1);
    }

    public void Stop ()
    {
        Debug.Log ("[VLC] Stopping Player !");

        playing = false;
        _mediaPlayer?.Stop();
        
        // there is no need to dispose every time you stop, but you should do so when you're done using the mediaplayer and this is how:
        // _mediaPlayer?.Dispose(); 
        // _mediaPlayer = null;
        //GetComponent<Renderer>().material.mainTexture = null;
        //tex = null;
    }

    public bool IsPlaying()
    {
        return _mediaPlayer.IsPlaying;
    }

    public bool IsPaused()
    {
        return pause;
    }

    public void Pause(bool pause)
    {
        this.pause = pause;
        UpdatePause();
    }

    public void SetPauseEditor(bool pause)
    {
        pauseEditor = pause;
        UpdatePause();
    }

    private void UpdatePause()
    {
        _mediaPlayer?.SetPause(pause || pauseEditor);
    }

    public void CleanAndDestroy()
    {
        Destroy(this);
    }

    void Update()
    {
        if(!playing) return;

        if(state == VLCState.Ended && loop)
        {
            Stop();
            StartPlay();
        }
        if (tex == null)
        {
            // If received size is not null, it and scale the texture
            uint i_videoHeight = 0;
            uint i_videoWidth = 0;

            _mediaPlayer.Size(0, ref i_videoWidth, ref i_videoHeight);
            //var texptr = _mediaPlayer.GetTexture(i_videoWidth, i_videoHeight, out bool updated);
            if (i_videoWidth != 0 && i_videoHeight != 0 && CurrentMappedViewAccessor != null/* && updated && texptr != IntPtr.Zero*/)
            {
                Debug.Log("Creating texture with height " + i_videoHeight + " and width " + i_videoWidth);
                tex = new Texture2D((int)width/*i_videoWidth*/,
                    (int)/*i_videoHeight*/height,
                    TextureFormat.RGBA32,
                    false,
                    true);
                //GetComponent<Renderer>().material.mainTexture = tex;
            }
        }
        if (tex != null && CurrentMappedViewAccessor != null)
        {
            /*var texptr = _mediaPlayer.GetTexture((uint)tex.width, (uint)tex.height, out bool updated);
            if (updated)
            {
                tex.UpdateExternalTexture(texptr);
            }*/
            tex.LoadRawTextureData(CurrentMappedViewAccessor.SafeMemoryMappedViewHandle.DangerousGetHandle(), (int)(pitch * lines));
            tex.Apply();
        }
        //UnityEngine.Debug.Log(m_frameCount);
    }

    public Texture2D GetTexture()
    {
        return tex;
    }

    MemoryMappedFile CurrentMappedFile;
    MemoryMappedViewAccessor CurrentMappedViewAccessor;
    private IntPtr Lock(IntPtr opaque, IntPtr planes)
    {
        if(CurrentMappedFile == null)
        {
            CurrentMappedFile = MemoryMappedFile.CreateOrOpen(mapFileName, pitch * lines);
            CurrentMappedViewAccessor = CurrentMappedFile.CreateViewAccessor();
        }
        Marshal.WriteIntPtr(planes, CurrentMappedViewAccessor.SafeMemoryMappedViewHandle.DangerousGetHandle());

        return IntPtr.Zero;
    }

    private int m_frameCount = 0;
    private void Display(IntPtr opaque, IntPtr picture)
    {
        m_frameCount++;
    }
    uint Align(uint size)
    {
        if (size % 32 == 0)
        {
            return size;
        }

        return ((size / 32) + 1) * 32;// Align on the next multiple of 32
    }

}
