using UnityEngine;
using System;
using LibVLCSharp.Shared;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections;

/// this class serves as an example on how to configure playback in Unity with VLC for Unity using LibVLCSharp.
/// for libvlcsharp usage documentation, please visit https://code.videolan.org/videolan/LibVLCSharp/-/blob/master/docs/home.md
public class VLCPlayback : MonoBehaviour
{
    LibVLC _libVLC;
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

    void TryInit()
    {
        if(_libVLC == null)
        {
            Core.Initialize(Application.dataPath);

            _libVLC = new LibVLC(enableDebugLogs: true);

            Application.SetStackTraceLogType(LogType.Log, StackTraceLogType.None);
            //_libVLC.Log += (s, e) => UnityEngine.Debug.Log(e.FormattedLog); // enable this for logs in the editor
        }
    }

    void Awake()
    {
        //TextureHelper.FlipTextures(transform);
        TryInit();
        //PlayPause();
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
        _mediaPlayer?.Stop();
        _mediaPlayer?.Dispose();
        _mediaPlayer = null;

        _libVLC?.Dispose();
        _libVLC = null;
    }

    void OnDisable() 
    {
        _mediaPlayer?.Stop();
        _mediaPlayer?.Dispose();
        _mediaPlayer = null;

        _libVLC?.Dispose();
        _libVLC = null;
    }

    bool isReady = false;

    public IEnumerator Prepare()
    {
        TryInit();
        if (_mediaPlayer == null)
        {
            _mediaPlayer = new MediaPlayer(_libVLC);
        }
        if(_mediaPlayer.Media == null)
        {
            // playing remote media
            //_mediaPlayer.Media = new Media(_libVLC, new Uri("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"));
            //_mediaPlayer.Media = new Media(_libVLC, videoPath);
            _mediaPlayer.Media = new Media(_libVLC, new StreamMediaInput(ms));
        }
        //var task = _mediaPlayer.Media.Parse(MediaParseOptions.ParseLocal);
        // width = 888;
        // height = 504;
        width = 10;
        height = 10;
        pitch = Align(width * 4);
        lines = Align(height);
        _mediaPlayer.SetVideoFormat("RV32", width, height, pitch);
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

        pitch = Align(width * 4);
        lines = Align(height);
        _mediaPlayer.SetVideoFormat("RV32", width, height, pitch);
        
        isReady = true;
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
        Prepare();
        if (_mediaPlayer.IsPlaying)
        {
            _mediaPlayer.Pause();
        }
        else
        {
            playing = true;

            _mediaPlayer.Play();
            _mediaPlayer.SetRate(1);
        }
    }

    public void Stop ()
    {
        Debug.Log ("[VLC] Stopping Player !");

        playing = false;
        _mediaPlayer?.Stop();
        
        // there is no need to dispose every time you stop, but you should do so when you're done using the mediaplayer and this is how:
        // _mediaPlayer?.Dispose(); 
        // _mediaPlayer = null;
        GetComponent<Renderer>().material.mainTexture = null;
        tex = null;
    }

    void Update()
    {
        if(!playing) return;

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
                GetComponent<Renderer>().material.mainTexture = tex;
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
    static MemoryMappedFile CurrentMappedFile;
    static MemoryMappedViewAccessor CurrentMappedViewAccessor;
    private IntPtr Lock(IntPtr opaque, IntPtr planes)
    {
        if(CurrentMappedFile == null)
        {
            CurrentMappedFile = MemoryMappedFile.CreateOrOpen("test", pitch * lines);
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
