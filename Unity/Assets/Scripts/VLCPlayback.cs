using UnityEngine;
using System;
using LibVLCSharp.Shared;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using VGMToolbox.format;
using CriWare.CriMana;

/// this class serves as an example on how to configure playback in Unity with VLC for Unity using LibVLCSharp.
/// for libvlcsharp usage documentation, please visit https://code.videolan.org/videolan/LibVLCSharp/-/blob/master/docs/home.md
public class VLCPlayback : MoviePlayback
{
    MediaPlayer _mediaPlayer;
    public MemoryStream ms;
    static int s_playerId = 0;
    int playerId;
    string mapFileName;


    public override void Awake()
    {
        base.Awake();
        playerId = s_playerId++;
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        if(VLCManager.Instance.IsInitialized)
        {
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
        }
    }

    void OnDisable() 
    {
        if(VLCManager.Instance.IsInitialized)
        {
            _mediaPlayer?.Stop();
            _mediaPlayer?.Dispose();
            _mediaPlayer = null;
        }
    }

    public override void Init(string path, bool loop, Action<MovieInfo> onReady)
    {
        CriUsmStream videoStream = new CriUsmStream(path);
        MpegStream.DemuxOptionsStruct demux = new MpegStream.DemuxOptionsStruct() { ExtractVideo = true, ExtractAudio = false };
        demux.ExtractedFileList = new List<string>();
        demux.Key1 = 0x44C5F5F5;
        demux.Key2 = 0x0581B687;
        demux.ExtractInMemoryStream = true;
        demux.ExtractedMemoryStream = new List<MemoryStream>();
        videoStream.DemultiplexStreams(demux);
        foreach(MemoryStream s in demux.ExtractedMemoryStream)
        {
            ms = s;
            SetLoop(loop);
            this.StartCoroutineWatched(Prepare());
            break;
        }
        onReady(videoStream.movieInfo);
    }

    public override IEnumerator Prepare(int _width = -1, int _height = -1)
    {
        if(VLCManager.Instance.IsInitialized)
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
            time = 0;

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
        else
        {
            time = 0;
            state = VLCState.NothingSpecial;
            isReady = true;
            tex = new Texture2D((int)1,
                        (int)1,
                        TextureFormat.RGBA32,
                        false,
                        true);
            (tex as Texture2D).SetPixel(0, 0, Color.black);
        }
    }

    private void OnStateChanged(object sender, MediaStateChangedEventArgs e)
    {
        state = _mediaPlayer.Media.State;
    }

    public override void PlayPause()
    {
        if(VLCManager.Instance.IsInitialized)
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
        else
        {
            if(playing)
            {
                if(state != VLCState.Paused)
                    state = VLCState.Playing;
                else
                    state = VLCState.Paused;
            }
        }
    }

    public override void StartPlay()
    {
        playing = true;
        if(VLCManager.Instance.IsInitialized)
        {
            Debug.Log ("[VLC] Start Player !");

            if(!_mediaPlayer.Play())
                UnityEngine.Debug.Log("Play error");
            _mediaPlayer.SetRate(1);
        }
        else
        {
            state = VLCState.Playing;
        }
    }

    public override void Stop ()
    {
        playing = false;
        if(VLCManager.Instance.IsInitialized)
        {
            Debug.Log ("[VLC] Stopping Player !");

            _mediaPlayer?.Stop();
            time = 0;
            
            // there is no need to dispose every time you stop, but you should do so when you're done using the mediaplayer and this is how:
            // _mediaPlayer?.Dispose(); 
            // _mediaPlayer = null;
            //GetComponent<Renderer>().material.mainTexture = null;
            //tex = null;
        }
        else
        {
            time = 0;
            state = VLCState.Stopped;
        }
    }

    public override bool IsPlaying()
    {
        if(VLCManager.Instance.IsInitialized)
            return _mediaPlayer.IsPlaying;
        else
            return false;
    }

    protected override void UpdatePause()
    {
        if(!playing)
            return;
        if(VLCManager.Instance.IsInitialized)
            _mediaPlayer?.SetPause(pause || pauseEditor);
        else
            state = pause ? VLCState.Paused : VLCState.Playing;
    }

    protected override void Update()
    {
        if(!playing) return;

        if(!VLCManager.Instance.IsInitialized)
        {
            if(state == VLCState.Playing)
            {
                time += Time.deltaTime;
                if(time > 10 && !loop)
                    state = VLCState.Ended;
            }
            return;
        }

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
            (tex as Texture2D).LoadRawTextureData(CurrentMappedViewAccessor.SafeMemoryMappedViewHandle.DangerousGetHandle(), (int)(pitch * lines));
            (tex as Texture2D).Apply();
        }
        if(state == VLCState.Playing)
            time += Time.deltaTime;
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

    private void Display(IntPtr opaque, IntPtr picture)
    {
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
